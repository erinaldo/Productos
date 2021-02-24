package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Adaptadores.ConsultaDevolucionAdapter;
import com.elephantworks.movilvennda.Adaptadores.ConsultaVentaAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IConsultarVentas;
import com.elephantworks.movilvennda.Modelos.Abono;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Cobranza;
import com.elephantworks.movilvennda.Modelos.Devolucion;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.Session;

import java.util.Date;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 16/07/2017.
 */
public class PresentadorConsultaVentas {

    private IConsultarVentas mVista;
    private Context context;
    private Realm realm;
    private Session session;
    private Staff staffGoblal;

    public PresentadorConsultaVentas(IConsultarVentas mVista, Context context) {
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    public void cargarLista(int tipoBusqueda){
        try {
            if(tipoBusqueda != Constantes.TipoVenta.DEVOLUCION){
                RealmQuery<Venta> query = realm.where(Venta.class);
                RealmResults<Venta> listaVenta = null;

                switch (tipoBusqueda){
                    case Constantes.TipoVenta.AMBAS:
                        listaVenta = query.isNull("staffCancelacion").findAll();
                        break;
                    case Constantes.TipoVenta.CONTADO:
                        listaVenta = query.isNull("staffCancelacion").equalTo("tipo",Constantes.TipoVenta.CONTADO).findAll();
                        break;
                    case Constantes.TipoVenta.CREDITO:
                        listaVenta = query.isNull("staffCancelacion").greaterThan("saldo",0.0).equalTo("tipo",Constantes.TipoVenta.CREDITO).findAll();
                        break;
                }

                ConsultaVentaAdapter adapter = new ConsultaVentaAdapter(context, listaVenta);
                mVista.cargarLista(adapter);
            }else{
                RealmQuery<Devolucion> query = realm.where(Devolucion.class);
                RealmResults<Devolucion> listaDevolucion = query.findAll();

                ConsultaDevolucionAdapter adapter = new ConsultaDevolucionAdapter(context, listaDevolucion);
                mVista.cargarListaDevolucion(adapter);
            }

        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }
    }

    public void cargarLista(int tipoBusqueda, String cliente){
        try {
            RealmQuery<Venta> query = realm.where(Venta.class);
            RealmResults<Venta> listaVenta = null;

            switch (tipoBusqueda){
                case Constantes.TipoVenta.AMBAS:
                    listaVenta = query.isNull("staffCancelacion").contains("cliente.razonSocial", cliente).findAll();
                    break;
                case Constantes.TipoVenta.CONTADO:
                    listaVenta = query.isNull("staffCancelacion").contains("cliente.razonSocial", cliente).equalTo("tipo",Constantes.TipoVenta.CONTADO).findAll();
                    break;
                case Constantes.TipoVenta.CREDITO:
                    listaVenta = query.isNull("staffCancelacion").greaterThan("saldo",0.0).contains("cliente.razonSocial", cliente).equalTo("tipo",Constantes.TipoVenta.CREDITO).findAll();
                    break;
            }

            ConsultaVentaAdapter adapter = new ConsultaVentaAdapter(context, listaVenta);
            mVista.cargarLista(adapter);
        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }
    }

    public void cancelarVenta(final Venta venta, final String motivo){
        //Todo checar que pasa si la venta es a credito
        RealmResults<VentaDetalle> ventaDetalle = realm.where(VentaDetalle.class).equalTo("venta.idVenta", venta.getIdVenta()).findAll();
        this.recuperarProductoInventario(ventaDetalle);
        final Staff staff = staffGoblal;
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm2) {
                venta.setStaffCancelacion(staff);
                venta.setFechaCancelacion(new Date());
                venta.setMotivoCancelacion(motivo);

                //actualizar saldo del cliente
                Clientes cliente = venta.getCliente();
                double saldoActual = cliente.getCreditoActual() - venta.getTotal();
                cliente.setCreditoActual(saldoActual);
            }
        });

    }

    public void recuperarProductoInventario(RealmResults<VentaDetalle> ventaDetalle){
        for (final VentaDetalle detalle : ventaDetalle){
            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {
                    Inventario inventario = realm2.where(Inventario.class).equalTo("productos.idProducto",detalle.getProducto().getIdProducto()).findFirst();
                    double cantidadNueva = inventario.getCantidad() + detalle.getCantidadProducto();
                    inventario.setCantidad(cantidadNueva);
                }
            });
        }
    }

    public String validarUsuario(String numEmpleado, String pin){
        String mensaje = "";

        Staff staff = realm.where(Staff.class).equalTo("numEmpleado", numEmpleado).equalTo("pin", pin).findFirst();

        if(staff != null){
            if(!staff.getAutorizaCancelacion()){
                mensaje = context.getResources().getString(R.string.msjAutorizacionInvalida).replace("$0$", numEmpleado);
            }else {
                staffGoblal = staff;
            }
        }else{
            mensaje = context.getResources().getString(R.string.msjUsuarioIncorrecto);
        }

        return mensaje;
    }

    public void abonarSaldo(final Venta venta, final String referencia, final double monto, final boolean acredito){

        final double saldoAbono = venta.getSaldo() - monto;
        RealmQuery<Abono> query2 = realm.where(Abono.class);
        final int idAbono = ((query2.max("idAbono") == null ? 1 : query2.max("idAbono").intValue() + 1));

        realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
            @Override
            public void execute(Realm realm2) {

                Abono abono = realm2.createObject(Abono.class,idAbono);
                abono.setReferencia(referencia);
                abono.setMetodoPago(acredito ? Constantes.TipoVenta.CREDITO : Constantes.TipoVenta.CONTADO);
                abono.setMonto(monto);
                abono.setEnvio(0);


                RealmQuery<Cobranza> query2 = realm.where(Cobranza.class);
                final int idCobranza = ((query2.max("idCobranza") == null ? 1 : query2.max("idCobranza").intValue() + 1));
                Cobranza cobranza = realm2.createObject(Cobranza.class,idCobranza);
                cobranza.setVenta(venta);
                cobranza.setAbono(realm2.where(Abono.class).equalTo("idAbono", idAbono).findFirst());
                cobranza.setFecha(new Date());
                cobranza.setSaldo(venta.getSaldo());
                cobranza.setSaldoAbono(saldoAbono);
                cobranza.setEnvio(0);

                venta.setSaldo(saldoAbono);
                venta.setEnvio(0);
                //actualizar saldo del cliente
                Clientes cliente = venta.getCliente();
                double saldoActual = cliente.getCreditoActual() - monto;
                cliente.setCreditoActual(saldoActual);
            }
        });

    }

    public boolean tieneAbono(boolean esCredito, Venta venta){
        boolean pasa = false;
        if(!esCredito){
            pasa= true;
        }else {
            RealmResults<Cobranza> cobranza = realm.where(Cobranza.class).equalTo("venta.idVenta",venta.getIdVenta()).findAll();
            if (cobranza.size() <= 0){
                pasa = true;
            }
        }

        return pasa;
    }
}
