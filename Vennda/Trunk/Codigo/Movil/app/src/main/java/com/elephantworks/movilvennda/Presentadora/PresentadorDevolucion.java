package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Adaptadores.DevolucionProductosAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IConsultarVentas;
import com.elephantworks.movilvennda.Interfaces.IDevolucion;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Devolucion;
import com.elephantworks.movilvennda.Modelos.DevolucionDetalle;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;

import java.util.Date;
import java.util.Map;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by elephantworkss.adec.v on 09/12/17.
 */

public class PresentadorDevolucion {

    private IDevolucion mVista;
    private Context context;
    private Realm realm;
    private Session session;
    private Venta ventaDevolucion;
    private Staff staffGoblal;
    private int idDevolucion;

    public PresentadorDevolucion(IDevolucion mVista, Context context) {
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    public void iniciar(){
        ventaDevolucion = realm.where(Venta.class).equalTo("folio",session.getDevolucion()).findFirst();
        String cliente = ventaDevolucion.getCliente().getRazonSocial();
        String folio = ventaDevolucion.getFolio();
        String fecha = MetodosEstaticos.getFechaStr(ventaDevolucion.getFechaCreacion());
        String total = MetodosEstaticos.getFormatoDecimal(ventaDevolucion.getTotal(), "###0.00");

        mVista.llenarTitulos(cliente, folio, fecha, total);

    }

    public void cargarLista(){
        try {
            RealmQuery<VentaDetalle> query = realm.where(VentaDetalle.class).equalTo("venta.idVenta",ventaDevolucion.getIdVenta());
            RealmResults<VentaDetalle> listaProducto = query.findAll();

            DevolucionProductosAdapter adapter = new DevolucionProductosAdapter(context, listaProducto);
            mVista.cargarLista(adapter);
        }catch (Exception ex){
            mVista.mostrarError(ex.getMessage());
        }
    }


    public String validarDevolucion(Map<Integer, Double> mapa, DevolucionProductosAdapter adapter){
        if(mapa.size() <= 0){
            return "Es necesario seleccionar por lo menos una cantidad en un producto, para hacer una devolución.";
        }

        for(int x = 0; x < mapa.size(); x++){
            Double cantidad = mapa.get(x);
            VentaDetalle ventaDetalle = adapter.getItem(x);

            if(cantidad > ventaDetalle.getCantidadProducto()){
                return "El producto "+ventaDetalle.getProducto().getDescripcion()+" solo tiene "+ventaDetalle.getCantidadProducto()+" para devolver.";
            }

            if(cantidad <= 0){
                return "El producto "+ventaDetalle.getProducto().getDescripcion()+" no tiene cantidad para devolver, por favor seleccione una cantidad mayor a 0.";
            }

            double cantidadDevuelta = 0.0;
            if(ventaDetalle.getCantidadDevuelta() != null){
                cantidadDevuelta = ventaDetalle.getCantidadDevuelta();
            }
            double cantidadProxima = cantidadDevuelta + cantidad;
            if (cantidadProxima > ventaDetalle.getCantidadProducto()) {
                return "El producto " + ventaDetalle.getProducto().getDescripcion() + " sobrepasa la cantidad permitida para devolver (" + ventaDetalle.getCantidadProducto() + ")";
            }

        }

        return "";
    }

    public int guardarDevoluciones(final Map<Integer, Double> mapa, final DevolucionProductosAdapter adapter, final String motivo){

        realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
            @Override
            public void execute(Realm realm2) {


                RealmQuery<Devolucion> query22 = realm.where(Devolucion.class);
                final int id = ((query22.max("idDevolucion") == null ? 1 : query22.max("idDevolucion").intValue() + 1));
                Devolucion devolucion = realm2.createObject(Devolucion.class,id);

                devolucion.setTipo(ventaDevolucion.getTipo());
                devolucion.setFechaCreacion(new Date());
                devolucion.setFolio(ventaDevolucion.getFolio());
                devolucion.setSubtotal(ventaDevolucion.getSubtotal());
                devolucion.setImpuestos(ventaDevolucion.getImpuestos());
                devolucion.setTotal(ventaDevolucion.getTotal());
                devolucion.setSaldo(ventaDevolucion.getSaldo());
                devolucion.setDescuento(ventaDevolucion.getDescuento());
                devolucion.setMotivo(motivo);
                devolucion.setStaff(ventaDevolucion.getStaff());
                devolucion.setStaffDevolucion(staffGoblal);
                devolucion.setCliente(ventaDevolucion.getCliente());
                devolucion.setPuntoVenta(ventaDevolucion.getPuntoVenta());
                devolucion.setVenta(ventaDevolucion);
                devolucion.setEnvio(0);


                for(int x = 0; x < mapa.size(); x++){
                    Double cantidad = mapa.get(x);
                    VentaDetalle ventaDetalle = adapter.getItem(x);

                    double cantidadDevuelta = 0.0;
                    if(ventaDetalle.getCantidadDevuelta() != null){
                        cantidadDevuelta = ventaDetalle.getCantidadDevuelta();
                    }
                    cantidad = cantidadDevuelta + cantidad;
                    ventaDetalle.setCantidadDevuelta(cantidad);


                    RealmQuery<DevolucionDetalle> query33 = realm.where(DevolucionDetalle.class);
                    final int idD = ((query33.max("idDevolucionDetalle") == null ? 1 : query33.max("idDevolucionDetalle").intValue() + 1));
                    DevolucionDetalle devolucionDetalle = realm2.createObject(DevolucionDetalle.class,idD);

                    devolucionDetalle.setListaPrecio(ventaDetalle.getListaPrecio());
                    devolucionDetalle.setCantidadProducto(cantidad);
                    devolucionDetalle.setPrecioUnitario(ventaDetalle.getPrecioUnitario());
                    devolucionDetalle.setImpuestoUnitario(ventaDetalle.getImpuestoUnitario());
                    devolucionDetalle.setImpuestoTotal(ventaDetalle.getImpuestoTotal());
                    devolucionDetalle.setSubtotal(ventaDetalle.getSubtotal());
                    devolucionDetalle.setTotal(ventaDetalle.getTotal());
                    devolucionDetalle.setDescuento(ventaDetalle.getDescuento());
                    devolucionDetalle.setmFechaHora(ventaDetalle.getmFechaHora());
                    devolucionDetalle.setmUsuario(ventaDetalle.getmUsuario());
                    devolucionDetalle.setDevolucion(devolucion);
                    devolucionDetalle.setProducto(ventaDetalle.getProducto());
                    devolucionDetalle.setEnvio(0);


                    actualizarInventario(ventaDetalle.getCantidadDevuelta(), ventaDetalle.getProducto());

                }

                idDevolucion = devolucion.getIdDevolucion();

            }
        });

        return idDevolucion;
    }


    private void actualizarInventario(final double cantidad, final Productos producto){

        RealmQuery<Inventario> query = realm.where(Inventario.class);
        Inventario inventario = query.equalTo("productos.idProducto", producto.getIdProducto()).findFirst();
        double cantidadActual = inventario.getCantidad() + cantidad;
        inventario.setCantidad(cantidadActual);

    }

    public String validarUsuario(String numEmpleado, String pin){
        String mensaje = "";

        Staff staff = realm.where(Staff.class).equalTo("numEmpleado", numEmpleado).equalTo("pin", pin).findFirst();

        if(staff != null){
            if(!staff.getAutorizaCancelacion()){
                mensaje = context.getResources().getString(R.string.msjAutorizacionInvalidaDevolucin).replace("$0$", numEmpleado);
            }else {
                staffGoblal = staff;
            }
        }else{
            mensaje = context.getResources().getString(R.string.msjUsuarioIncorrecto);
        }

        return mensaje;
    }
}
