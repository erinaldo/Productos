package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;

import com.elephantworks.movilvennda.Adaptadores.CambiarClienteAdapter;
import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IVentas;
import com.elephantworks.movilvennda.Modelos.CarritoImpuesto;
import com.elephantworks.movilvennda.Modelos.CarritoVentas;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Cobranza;
import com.elephantworks.movilvennda.Modelos.FoliosVenta;
import com.elephantworks.movilvennda.Modelos.ImpuestoDetalle;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.PuntoVenta;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;

import java.util.Date;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 10/06/2017.
 */
public class PresentadorVentas {

    private IVentas mVista;
    private Context context;
    private Session session;
    private Realm realm;
    private String folio;

    public PresentadorVentas(IVentas mVista, Context context) {
        session = new Session(context);
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
    }

    public void llenarDatosMenuVenta(){
        String puntoVenta = "";
        String fecha = MetodosEstaticos.getFechaActualStr();
        folio = MetodosEstaticos.getFolio(context);
        String cliente = "";
        String limiteCredito = "";
        String saldoCredito = "";

        RealmQuery<PuntoVenta> query = realm.where(PuntoVenta.class);
        PuntoVenta puntoVentaRealmResults = query.equalTo("idPuntoVenta", session.getPuntoVenta()).findFirst();

        if(puntoVentaRealmResults != null){
            puntoVenta = puntoVentaRealmResults.getNombreNegocio();
        }

        Clientes clienteBD = MetodosEstaticos.getClienteSesion(context, session.getIdClienteVentas());
        if(clienteBD != null){
            cliente = clienteBD.getRazonSocial();
            limiteCredito =  MetodosEstaticos.getFormatoDecimal(clienteBD.getLimiteCredito(),"###0.00");
            saldoCredito = MetodosEstaticos.getFormatoDecimal(clienteBD.getCreditoActual(),"###0.00");
        }



        mVista.llenarTitulosMenuVenta(puntoVenta, fecha, folio, cliente,limiteCredito,saldoCredito);
    }

    public void refrescarTotales(){
        String subtotal = "0.00";
        String descuento = "0.00";
        String impuesto = "0.00";
        String total = "0.00";

        RealmQuery<CarritoVentas> query = realm.where(CarritoVentas.class);
        RealmResults<CarritoVentas> carrito = query.findAll();

        if(carrito.size() > 0){
            subtotal = MetodosEstaticos.getFormatoDecimal(Double.parseDouble(query.sum("subtotal").toString()),"###0.00");
            descuento = MetodosEstaticos.getFormatoDecimal(Double.parseDouble(query.sum("descuento").toString()),"###0.00");
            impuesto = MetodosEstaticos.getFormatoDecimal(Double.parseDouble(query.sum("impuestos").toString()),"###0.00");
            total = MetodosEstaticos.getFormatoDecimal(Double.parseDouble(query.sum("total").toString()),"###0.00");
        }

        mVista.actualizarTotales(subtotal, descuento, impuesto, total);
    }

    public CambiarClienteAdapter llenarListaClientes(){
        CambiarClienteAdapter clienteAdapter = null;
        try {
            RealmQuery<Clientes> query = realm.where(Clientes.class);
            RealmResults<Clientes> listaClientes = query.findAll();

            clienteAdapter = new CambiarClienteAdapter(context, listaClientes);

        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }

        return clienteAdapter;
    }

    public int guardarVenta(final boolean acredito, Clientes cliente, PuntoVenta puntoVenta, final int formaPago, final double recibido){

        final boolean credito = acredito;
        final Clientes clienteC = cliente;
        final PuntoVenta puntoVentaP = puntoVenta;
        final Staff staff = MetodosEstaticos.getVendedorSession(context, session.getCorreoElectronicoStaff());
        RealmQuery<Venta> query2 = realm.where(Venta.class);
        final int id = ((query2.max("idVenta") == null ? 1 : query2.max("idVenta").intValue() + 1));

        RealmQuery<CarritoVentas> query = realm.where(CarritoVentas.class);
        RealmResults<CarritoVentas> carrito = query.findAll();

        final double subtotal = Double.parseDouble(query.sum("subtotal").toString());
        final double descuento = Double.parseDouble(query.sum("descuento").toString());
        final double impuesto =  Double.parseDouble(query.sum("impuestos").toString());
        final double total = Double.parseDouble(query.sum("total").toString());

        realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
            @Override
            public void execute(Realm realm2) {

                Venta venta = realm2.createObject(Venta.class,id);
                venta.setTipo((credito ? Constantes.TipoVenta.CREDITO : Constantes.TipoVenta.CONTADO));
                venta.setFormaPago(formaPago);
                venta.setFechaCreacion(new Date());
                venta.setFolio(folio);
                venta.setSubtotal(subtotal);
                venta.setImpuestos(impuesto);
                venta.setDescuento(descuento);
                venta.setTotal(total);
                venta.setFechaCancelacion(null);
                venta.setMotivoCancelacion(null);
                venta.setStaff(staff);
                venta.setStaffCancelacion(null);
                venta.setCliente(clienteC);
                venta.setPuntoVenta(puntoVentaP);
                venta.setRecibido(recibido);
                double cambio = recibido - total;
                venta.setCambio((cambio >= 0 ? cambio : 0.0 ));
                if(credito){
                    venta.setFechaVencimiento(MetodosEstaticos.getFechaVencimiento(clienteC.getDiasCredito()));
                }else{
                    venta.setFechaVencimiento(null);
                }
                venta.setEnvio(0);
                if(acredito){
                    venta.setSaldo(total);
                }else {
                    venta.setSaldo(0.0);
                }

            }
        });

        Venta venta = query2.equalTo("idVenta", id).findFirst();
        this.guardarVentaDetalle(carrito, venta, staff);
        if(acredito){
            this.actualizarCreditoCliente(cliente, total);
        }

        this.actualizarFolio();

        return id;
    }

    public void guardarVentaDetalle( RealmResults<CarritoVentas> carritoVentas, final Venta venta, final Staff staff){

        for (CarritoVentas carrito: carritoVentas  ) {
            final CarritoVentas carrito2 = carrito;

            actualizarInventario(carrito2.getCantidad(), carrito2.getProducto());

            realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
                @Override
                public void execute(Realm realm2) {

                    RealmQuery<VentaDetalle> query2 = realm.where(VentaDetalle.class);
                    final int id = ((query2.max("idVentaDetalle") == null ? 1 : query2.max("idVentaDetalle").intValue() + 1));
                    VentaDetalle ventaDetalle = realm2.createObject(VentaDetalle.class,id);
                    ventaDetalle.setListaPrecio(String.valueOf(venta.getCliente().getListaPrecios()));
                    ventaDetalle.setCantidadProducto(carrito2.getCantidad());
                    ventaDetalle.setPrecioUnitario(carrito2.getPrecio());
                    double impuestoUni = carrito2.getImpuestos() / carrito2.getCantidad();
                    ventaDetalle.setImpuestoUnitario(impuestoUni);
                    ventaDetalle.setImpuestoTotal(carrito2.getImpuestos());
                    ventaDetalle.setSubtotal(carrito2.getSubtotal());
                    ventaDetalle.setDescuento(carrito2.getDescuento());
                    ventaDetalle.setPartida(0);
                    ventaDetalle.setmFechaHora(new Date());
                    ventaDetalle.setmUsuario(staff.getNombre());
                    ventaDetalle.setVenta(venta);
                    ventaDetalle.setProducto(carrito2.getProducto());
                    ventaDetalle.setTotal(carrito2.getTotal());
                    ventaDetalle.setEnvio(0);

                    //sacamos los datos de carrito impuesto
                    CarritoImpuesto carritoImpuesto = realm2.where(CarritoImpuesto.class).equalTo("carrito.idCarrito", carrito2.getIdCarrito()).findFirst();

                    if(carritoImpuesto != null){
                        // guardamos impuesto detalle de lo datos de carritoImpuesto
                        RealmQuery<ImpuestoDetalle> queryImp = realm.where(ImpuestoDetalle.class);
                        int idImp = ((queryImp.max("idImpuestoDetalle") == null ? 1 : queryImp.max("idImpuestoDetalle").intValue() + 1));
                        ImpuestoDetalle impuestoDetalle = realm2.createObject(ImpuestoDetalle.class,idImp);
                        impuestoDetalle.setVentaDetalle(ventaDetalle);
                        impuestoDetalle.setPrecioBase(carritoImpuesto.getPrecioBase());
                        impuestoDetalle.setTasa(carritoImpuesto.getTasa());
                        impuestoDetalle.setImporte(carritoImpuesto.getImporte());
                        impuestoDetalle.setEnvio(0);

                        //ya que pasamos los datos a venta detalle se elimina de carro
                        carritoImpuesto.deleteFromRealm();

                    }

                    carrito2.deleteFromRealm();

                }
            });
        }
    }

    public void actualizarInventario(final double cantidad, final Productos producto){
        realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
            @Override
            public void execute(Realm realm2) {

                RealmQuery<Inventario> query = realm2.where(Inventario.class);
                Inventario inventario = query.equalTo("productos.idProducto", producto.getIdProducto()).findFirst();
                double cantidadActual = inventario.getCantidad() - cantidad;
                inventario.setCantidad(cantidadActual);

            }
        });
    }

    public boolean validarProductosCambioCliente(){
        boolean hayDatos = false;
        try {
            RealmQuery<CarritoVentas> query = realm.where(CarritoVentas.class);
            RealmResults<CarritoVentas> carrito = query.findAll();

            if(carrito.size() > 0 ){
                hayDatos = true;
            }else {
                hayDatos = false;
            }

        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }

        return hayDatos;
    }

    public void eliminarProductosPorCambioCliente(){

        try {

            realm.executeTransaction(new Realm.Transaction() {
                @Override
                public void execute(Realm realm2) {

                    realm2.where(CarritoVentas.class).findAll().deleteAllFromRealm();

                }
            });
        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }
    }

    public void actualizarCreditoCliente(final Clientes cliente, final double total){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                cliente.setCreditoActual(cliente.getCreditoActual() + total);
            }
        });
    }

    public boolean validarClienteCredito(Clientes cliente){
        RealmQuery<CarritoVentas> query = realm.where(CarritoVentas.class);
        double total = Double.parseDouble(query.sum("total").toString());

        double validarCredito = cliente.getCreditoActual() + total;
        boolean puedeComprar = true;
        if(validarCredito > cliente.getLimiteCredito()){
            puedeComprar = false;
        }

        return puedeComprar;
    }

    public void actualizarFolio(){

        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm2) {
                try{

                    FoliosVenta query = realm.where(FoliosVenta.class).findFirst();

                    if(query != null){
                        FoliosVenta foliosVenta = realm.where(FoliosVenta.class).findFirst();
                        int consecutivo = foliosVenta.getConsecutivo() + 1;
                        foliosVenta.setConsecutivo(consecutivo);
                    }

                }catch (Exception ex){
                    mVista.error(ex.getMessage());
                }
            }
        });
    }


}
