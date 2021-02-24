package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Adaptadores.VentasAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IListaVentas;
import com.elephantworks.movilvennda.Modelos.CarritoImpuesto;
import com.elephantworks.movilvennda.Modelos.CarritoVentas;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Impuesto;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Modelos.Staff;
import com.elephantworks.movilvennda.Modelos.ValoresImpuesto;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;

import java.util.ArrayList;
import java.util.HashMap;

import io.realm.Realm;
import io.realm.RealmList;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 10/07/2017.
 */
public class PresentadorListaVentas {

    private IListaVentas mVista;
    private Context context;
    private Realm realm;
    private ClienteAdapter mCliente;
    private Session session;
    private VentasAdapter mVentas;

    public PresentadorListaVentas(IListaVentas mVista, Context context){
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    public void agregarProductoVenta(){

        try {
            RealmQuery<CarritoVentas> query = realm.where(CarritoVentas.class);
            RealmResults<CarritoVentas> listaCarrito = query.findAll();

            // Inicializar el adaptador con la fuente de datos.
            mVentas = new VentasAdapter(context, listaCarrito);
            mVista.cargarLista(mVentas);
        }catch (Exception ex){
            mVista.error(ex.getMessage());
        }

    }

    public Double cantidadInventarioProducto(Productos producto){
        RealmQuery<Inventario> query = realm.where(Inventario.class);
        Inventario inventario = query.equalTo("productos.idProducto", producto.getIdProducto()).findFirst();

        return inventario.getCantidad();
    }

    public boolean validarDescuntoVendedor(){
        Staff staff = MetodosEstaticos.getVendedorSession(context, session.getCorreoElectronicoStaff());

        return staff.getPorcentajeDescuento() > 0.0;
    }

    public void guardarVentaCarrito(final Productos producto, final double cantidad, final double descuentoAplicado){
        final Staff staff = MetodosEstaticos.getVendedorSession(context, session.getCorreoElectronicoStaff());
        final Clientes cliente = MetodosEstaticos.getClienteSesion(context, session.getIdClienteVentas());

        realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
            @Override
            public void execute(Realm realm2) {
                try{
                    double cant = cantidad;
                    RealmQuery<CarritoVentas> query = realm.where(CarritoVentas.class);
                    CarritoVentas carrito = query.equalTo("producto.idProducto", producto.getIdProducto()).findFirst();
                    if(carrito == null){
                        query = realm.where(CarritoVentas.class);
                        int id = ((query.max("idCarrito") == null ? 1 : query.max("idCarrito").intValue() + 1));
                        carrito = realm2.createObject(CarritoVentas.class,id);
                    }

                    double precio = MetodosEstaticos.getListaPrecio(producto,cliente.getListaPrecios());
                    double subtotal = precio * cant;
                    double descuentoVendedor = descuentoAplicado;
                    double descuento = ((subtotal * descuentoVendedor) / 100);
                    double subtotalDescueto = subtotal;
                    if(descuento > 0.0){
                        subtotalDescueto = subtotal - descuento;
                    }
                    double impuesto = calcularImpuesto(producto, subtotalDescueto);
                    double total = (subtotal + impuesto) - descuento;

                    carrito.setCantidad(cant);
                    carrito.setPrecio(precio);
                    carrito.setSubtotal(subtotal);
                    carrito.setDescuentoVendedor(descuentoVendedor);
                    carrito.setDescuento(descuento);
                    carrito.setImpuestos(impuesto);
                    carrito.setTotal(total);
                    carrito.setProducto(producto);

                    guardarCarritoImpuesto(producto,subtotal,carrito);

                }catch (Exception ex){
                    mVista.error(ex.getMessage());
                }
            }
        });

        this.agregarProductoVenta();
    }

    public void eliminarProductoCarrito(final CarritoVentas carrito){
        realm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                RealmResults<CarritoImpuesto> results2 = realm.where(CarritoImpuesto.class).equalTo("carrito.idCarrito",carrito.getIdCarrito()).findAll();
                results2.deleteAllFromRealm();
                RealmResults<CarritoVentas> result = realm.where(CarritoVentas.class).equalTo("idCarrito",carrito.getIdCarrito()).findAll();
                result.deleteAllFromRealm();
            }
        });

        this.agregarProductoVenta();
    }

    public Double calcularImpuesto(Productos producto, double subtotal) {

        Double totalImpuesto = 0.0;
        Double precioImp = 0.0;
        RealmList<Impuesto> impuestos = new RealmList<Impuesto>();
        impuestos = producto.getImpuestos();

        for (Impuesto impuesto : impuestos) {

            if (impuesto.isActivo()) {

                ValoresImpuesto valor = impuesto.getValoresImpuestos().last();
                double tasa = valor.getTasa();

                if (impuesto.getTipoAplicacion() == Constantes.TipoAplicaionImpusto.PORCENTAJE) {
                    precioImp = (tasa * subtotal) / 100;
                } else if (impuesto.getTipoAplicacion() == Constantes.TipoAplicaionImpusto.IMPORTE) {
                    precioImp = subtotal - tasa;
                }

                totalImpuesto = totalImpuesto + precioImp;
            }

        }

        return totalImpuesto;
    }

    public void guardarCarritoImpuesto(final Productos producto, final double subtotal, final CarritoVentas carritoVentas){

        RealmList<Impuesto> impuestos = new RealmList<Impuesto>();
        impuestos = producto.getImpuestos();

        for (Impuesto impuesto : impuestos) {

            if (impuesto.isActivo()) {

                ValoresImpuesto valor = impuesto.getValoresImpuestos().last();

                final double tasa = valor.getTasa();
                double precioImp = 0.0;

                if (impuesto.getTipoAplicacion() == Constantes.TipoAplicaionImpusto.PORCENTAJE) {
                    precioImp = (tasa * subtotal) / 100;
                } else if (impuesto.getTipoAplicacion() == Constantes.TipoAplicaionImpusto.IMPORTE) {
                    precioImp = subtotal - tasa;
                }

                final double precioImporte = precioImp;

                RealmQuery<CarritoImpuesto> query = realm.where(CarritoImpuesto.class);
                CarritoImpuesto carrito = query.equalTo("carrito.idCarrito", carritoVentas.getIdCarrito()).findFirst();
                if(carrito == null){
                    query = realm.where(CarritoImpuesto.class);
                    int id = ((query.max("idCarritoImpuesto") == null ? 1 : query.max("idCarritoImpuesto").intValue() + 1));
                    carrito = realm.createObject(CarritoImpuesto.class,id);
                }

                carrito.setCarrito(carritoVentas);
                carrito.setPrecioBase(subtotal);
                carrito.setTasa(tasa);
                carrito.setImporte(precioImporte);

            }

        }
    }

}
