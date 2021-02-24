package com.elephantworks.movilvennda.Presentadora;

import android.content.Context;

import com.elephantworks.movilvennda.Adaptadores.ProductoAdapter;
import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Interfaces.IProductos;
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

import java.util.Date;

import io.realm.Realm;
import io.realm.RealmList;
import io.realm.RealmQuery;
import io.realm.RealmResults;
import io.realm.Sort;

/**
 * Created by ldelatorre on 10/06/2017.
 */
public class PresentadorProductos {

    private IProductos mVista;
    private Session session;
    private Context context;
    private Realm realm;

    public PresentadorProductos(IProductos mVista, Context context) {
        this.mVista = mVista;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    public void defaultDatosLista() {
        try {
            RealmQuery<Productos> query = realm.where(Productos.class);
            RealmResults<Productos> listaProductos = query.findAll();

            ProductoAdapter adapter = new ProductoAdapter(context, listaProductos);
            mVista.cargarListaProductos(adapter);
        } catch (Exception ex) {
            mVista.error(ex.getMessage());
        }
    }

    public void cambiarDatosLista(int id) {
        try {
            RealmQuery<Productos> query;
            if (id == 0) {
                query = realm.where(Productos.class);
            } else {
                query = realm.where(Productos.class).equalTo("categorias.idCategoria", id);
            }
            RealmResults<Productos> listaProductos = query.findAll();

            ProductoAdapter adapter = new ProductoAdapter(context, listaProductos);
            mVista.cargarListaProductos(adapter);
        } catch (Exception ex) {
            mVista.error(ex.getMessage());
        }
    }

    public void filtrarDatosLista(int idCategoria, String nombreProducto) {
        try {
            RealmQuery<Productos> query;
            if (nombreProducto.equals("")) {
                if (idCategoria == 0) {
                    query = realm.where(Productos.class);
                } else {
                    query = realm.where(Productos.class).equalTo("categorias.idCategoria", idCategoria);
                }
            } else {
                if (idCategoria == 0) {
                    query = realm.where(Productos.class).contains("nombre", nombreProducto);
                } else {
                    query = realm.where(Productos.class).contains("nombre", nombreProducto).equalTo("categorias.idCategoria", idCategoria);
                }
            }

            RealmResults<Productos> listaProductos = query.findAll();

            ProductoAdapter adapter = new ProductoAdapter(context, listaProductos);
            mVista.cargarListaProductos(adapter);
        } catch (Exception ex) {
            mVista.error(ex.getMessage());
        }
    }

    public void guardarVentaCarrito(final Productos producto, final double cantidad, final double descuentoAplicado) {
        final Staff staff = MetodosEstaticos.getVendedorSession(context, session.getCorreoElectronicoStaff());
        final Clientes cliente = MetodosEstaticos.getClienteSesion(context, session.getIdClienteVentas());

        realm.executeTransaction(new Realm.Transaction() { // TODO: move write to background thread
            @Override
            public void execute(Realm realm2) {
                try {
                    double cant = cantidad;
                    RealmQuery<CarritoVentas> query = realm.where(CarritoVentas.class);
                    CarritoVentas carrito = query.equalTo("producto.idProducto", producto.getIdProducto()).findFirst();
                    if (carrito == null) {
                        query = realm.where(CarritoVentas.class);
                        int id = ((query.max("idCarrito") == null ? 1 : query.max("idCarrito").intValue() + 1));
                        carrito = realm2.createObject(CarritoVentas.class, id);
                    } else {
                        cant = cant + carrito.getCantidad();
                    }

                    //asignamos el precio de la lista que tiene configurado el cliente
                    double precio = MetodosEstaticos.getListaPrecio(producto, cliente.getListaPrecios());
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

                } catch (Exception ex) {
                    mVista.error(ex.getMessage());
                }
            }
        });


    }

    public Double cantidadInventarioProducto(Productos producto) {
        RealmQuery<Inventario> query = realm.where(Inventario.class);
        Inventario inventario = query.equalTo("productos.idProducto", producto.getIdProducto()).findFirst();

        return inventario.getCantidad();
    }

    public boolean validarDescuntoVendedor() {
        Staff staff = MetodosEstaticos.getVendedorSession(context, session.getCorreoElectronicoStaff());

        return staff.getPorcentajeDescuento() > 0.0;
    }

    public Double calcularImpuesto(Productos producto, double subtotal) {

        Double totalImpuesto = 0.0;
        Double precioImp = 0.0;
        //Todo checar esta funcionalidad con chema
        double despuesImp = 0.0;
        RealmResults<Impuesto> impuestos = producto.getImpuestos().where().findAllSorted("jerarquia", Sort.DESCENDING);

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
