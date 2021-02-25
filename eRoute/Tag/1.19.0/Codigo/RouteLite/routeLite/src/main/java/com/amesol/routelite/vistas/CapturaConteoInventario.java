package com.amesol.routelite.vistas;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ConteoInventarioDet;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarConteoInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaConteoInventario;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

public class CapturaConteoInventario extends Vista implements ICapturaConteoInventario{

    CapturarConteoInventario mPresenta;
    CapturaProducto captura;

    String mAccion;
    ListView lista;

    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        try
        {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();
            setContentView(R.layout.captura_conteo_inventario);
            deshabilitarBarra(true);

            TextView texto = (TextView) findViewById(R.id.lblFechaHoraAlta);
            texto.setText(Mensajes.get("XFecha") + ": " + Generales.getFechaActualStr() );

            texto = (TextView) findViewById(R.id.lblProducto);
            texto.setText(Mensajes.get("XProducto"));

            texto = (TextView) findViewById(R.id.lblUnidad);
            texto.setText(Mensajes.get("XUnidad"));

            Button btnContinuar = (Button)findViewById(R.id.btnContinuar);
            btnContinuar.setText(Mensajes.get("BTContinuar"));
            btnContinuar.setOnClickListener(mContinuar);

            lista = (ListView) findViewById(R.id.lsConteoInventarioDetalle);
            lista.setItemsCanFocus(false);
            registerForContextMenu(lista);
            mPresenta = new CapturarConteoInventario(this,mAccion);
            mPresenta.iniciar();
            if (mPresenta.getErrorInicial().length()>0){
                mostrarError(mPresenta.getErrorInicial(),10);
            }
            captura = (CapturaProducto) findViewById(R.id.capturaProducto);
            captura.setCadenaListasPrecios("");
            captura.setTipoTransProd((short)Enumeradores.TiposTransProd.CONTEO_INVENTARIO);
            captura.setTransProdIds("'" + mPresenta.getConteoInventario().ContId  + "'");
            captura.setOnAgregarProductoListener(mAgregarProductoListener);

        }catch (Exception ex){
            mostrarError(ex.getMessage(), 10);

        }
    }

    @Override
    public void iniciar() {

    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS)
        {
            //si esta regresando de la busqueda de productos
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
            {
                //si selecciono Agregar en la busqueda de productos, obtener la seleccion y agregarlos al pedido
                if (Sesion.get(Sesion.Campo.ResultadoActividad) != null)
                {
                    insertarSeleccion((HashMap<String, TransProdDetalle>) Sesion.get(Sesion.Campo.ResultadoActividad));
                    Sesion.remove(Sesion.Campo.ResultadoActividad);
                    captura.setFinBusqueda();
                }else{
                    if (data != null) {
                        txtScanner.setTexto(data.getStringExtra("mensajeIniciar"));
                        captura.IngresaProductoBusquedaSimple(data.getStringExtra("mensajeIniciar"));
                    }
                }
            }else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
            {
                if (data != null)
                {
                    String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                    if (!mensajeError.equals(""))
                    { // cuando se presiona back se manda el mensaje vacio
                        mostrarError(mensajeError);
                    }
                }
                captura.setFinBusqueda();
            }
        }
    }

    public void insertarSeleccion(HashMap<String, TransProdDetalle> transProdDetalles)
    {
        try
        {
            Iterator it = transProdDetalles.entrySet().iterator();
            while (it.hasNext())
            { //recorrer los productos
                Map.Entry producto = (Map.Entry) it.next();
                    try
                    {
                        Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(((TransProdDetalle) producto.getValue()).ProductoClave);
                        //En caso de venir de la busqueda no hay errores por devolver, por eso se omite el error
                        mPresenta.generarConteoInventarioDet(oProducto, (short)((TransProdDetalle) producto.getValue()).TipoUnidad, ((TransProdDetalle) producto.getValue()).Cantidad);
                       // mPresenta.agregarProductoUnidad(oProducto, ((TransProdDetalle) producto.getValue()), tipoMotivo, true);
                    }
                    catch (Exception ex)
                    {
                        mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
                    }
            }
            refrescarProductos();
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 10) {//Error finalizar
            try{
                BDVend.rollback();
            }catch(Exception ex){

            }
            finalizar();
        }
    }
    private CapturaProducto.onAgregarProductoListener mAgregarProductoListener = new CapturaProducto.onAgregarProductoListener() {
        @Override
        public void onAgregarProducto (Producto producto, int tipoUnidad, float cantidad)
        {
            try
            {
               mPresenta.generarConteoInventarioDet(producto, (short) tipoUnidad, cantidad);
                refrescarProductos();
   /*             producto.obtenerExcepcionSubEmpresaID(((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave);
                Object aTransProdDetalle[] = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(producto.ProductoClave, String.valueOf(tipoUnidad), mPresenta.getTransaccionesIds());

                MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Sesion.Campo.MOTConfiguracion);
                //validacion NoAdicionProducto
                if(modificando == true && (Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && motConf.get("NoAdicionProducto").toString().equals("1")){
                    if(aTransProdDetalle == null){
                        //no existe en el pedido, no se puede agregar
                        mostrarAdvertencia(Mensajes.get("E0908"));
                        return;
                    }

                    //si existe, validar cantidades
                    float valorOriginal = Float.parseFloat(aTransProdDetalle[2].toString());
                    float valorActual = cantidad;
                    if(valorOriginal < valorActual){
                        captura.setEnableCantidadAgregar(false);
                        mostrarAdvertencia(Mensajes.get("E0908"));
                        return;
                    }
                }

                if (aTransProdDetalle != null)
                { // si ya existe, seleccionarlo de la lista E0714
                    if (Float.parseFloat(aTransProdDetalle[2].toString()) != cantidad)
                    {
                        AtomicReference<Float> existencia = new AtomicReference<Float>();
                        StringBuilder error = new StringBuilder();
                        if (mPresenta.getTipoValidacionExistencia() != com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.NoValidar)
                        {
                            float cantValidar = cantidad;
                            boolean bValidar = true;

                            if (producto.Contenido && producto.Venta)
                            {
                                float SaldoPrestamoIni = mPresenta.obtenerSaldoDeEnvase(producto.ProductoClave);
                                if (SaldoPrestamoIni < 0)
                                    SaldoPrestamoIni = 0;

                                if (SaldoPrestamoIni < cantidad)
                                    cantValidar -= SaldoPrestamoIni;
                                else
                                    bValidar = false;
                            }

                            if (bValidar) {
                                if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantValidar, Float.parseFloat(aTransProdDetalle[2].toString()), mPresenta.getModuloMovDetalle(), false, existencia, error)) {
                                    captura.setError(error.toString());
                                    if (mPresenta.getTipoValidacionExistencia() == com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.ValidacionRestrictiva) {
                                        if (!validarVenderApartado(producto, Short.parseShort(String.valueOf(tipoUnidad)), cantValidar, Float.parseFloat(aTransProdDetalle[2].toString()), aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString()))
                                            return;
                                        if (existencia.get() != null && existencia.get() > 0) {
                                            captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) + existencia.get());
                                        } else {
                                            captura.setCantidad(cantidad);
                                        }
                                        return;
                                    }
                                } else {
                                    captura.setAdvertencia(error.toString());
                                }
                            }
                        }

                        if(!mPresenta.validarCantMax(cantidad)){
                            //no esta configurada ninguna cantidad, continuar normal
                            mPresenta.eliminarDetalle(aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString(), producto.SubEmpresaId, producto.ProductoClave, tipoUnidad, Float.parseFloat(aTransProdDetalle[2].toString()), false);
                            if((Integer.parseInt(Sesion.get(Sesion.Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO))
                                mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"),Float.parseFloat(aTransProdDetalle[2].toString()), aTransProdDetalle[1].toString());
                            else
                                mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"), aTransProdDetalle[1].toString());
                        }else{
                            //guardar la info en las varibles para poder agregar el producto si contesta que si a la pregunta
                            productoAgregar = producto;
                            tipoUnidadAgregar = Short.parseShort(String.valueOf(tipoUnidad)) ;
                            cantidadAgregar = cantidad;
                            cantidadOriginalAgregar = Float.parseFloat(aTransProdDetalle[2].toString());
                            transprodIDEliminar = aTransProdDetalle[0].toString();
                            transprodDetalleIDEliminar = aTransProdDetalle[1].toString();
                            existe = true;
                        }

                    }
                }
                else
                {
                    AtomicReference<Float> existencia = new AtomicReference<Float>();
                    StringBuilder error = new StringBuilder();

                    if (mPresenta.getTipoValidacionExistencia() != com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.NoValidar)
                    {
                        float cantValidar = cantidad;
                        boolean bValidar = true;

                        if (producto.Contenido && producto.Venta)
                        {
                            float SaldoPrestamoIni = mPresenta.obtenerSaldoDeEnvase(producto.ProductoClave);
                            if (SaldoPrestamoIni < 0)
                                SaldoPrestamoIni = 0;

                            if (SaldoPrestamoIni < cantidad)
                                cantValidar -= SaldoPrestamoIni;
                            else
                                bValidar = false;
                        }

                        if (bValidar) {
                            if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantValidar, mPresenta.getModuloMovDetalle(), existencia, error)) {
                                captura.setError(error.toString());
                                if (mPresenta.getTipoValidacionExistencia() == com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.ValidacionRestrictiva) {
                                    if (!validarVenderApartado(producto, tipoUnidad, cantValidar))
                                        return;
                                    if (existencia.get() != null && existencia.get() > 0) {
                                        captura.setCantidad(existencia.get());
                                    } else {
                                        captura.setCantidad(Float.valueOf(0));
                                    }
                                    return;
                                }
                            } else {
                                captura.setAdvertencia(error.toString());
                            }
                        }
                    }
                    //mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"));
                    if(!mPresenta.validarCantMax(cantidad)){
                        //no esta configurada ninguna cantidad, continuar normal
                        mPresenta.agregarProductoUnidad(producto.ProductoClave, producto.SubEmpresaId, tipoUnidad, cantidad, Float.parseFloat("-1"));
                    }else{
                        //guardar la info en las varibles para poder agregar el producto si contesta que si a la pregunta
                        productoAgregar = producto;
                        tipoUnidadAgregar = tipoUnidad;
                        cantidadAgregar = cantidad;
                        existe = false;
                    }

                }*/
            }
            catch (Exception e)
            {
                mostrarError(e.getMessage());
            }
        }
    };
    public void refrescarProductos()
    {
        try
        {
            if (lista.getAdapter() != null){
                stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
                ((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
            }
            ISetDatos stConteoInventarioDet = Consultas.ConsultasConteoInventario.obtenerConteoInventarioDetalle(mPresenta.getConteoInventario().ContId);

            Cursor cProductos = (Cursor) stConteoInventarioDet.getOriginal();
            startManagingCursor(cProductos);
            try
            {

                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_conteo_inventario, cProductos, new String[]
                        { "TipoUnidad", "ProductoClave",  "BuenEstadoF" }, new int[]
                        { R.id.lblUnidad, R.id.lblProductoClaveDescripcion,  R.id.lblBuenEstadoF});
                adapter.setViewBinder(new vista());
                lista.setAdapter(adapter);

               /* lista.setOnItemClickListener(new AdapterView.OnItemClickListener()
                                             {

                                                 public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
                                                 {
                                                     Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
                                                     lista.requestFocusFromTouch();
                                                     lista.setSelection(pos);
                                                     // Se crea el objeto producto con lo que se trae en la
                                                     // consulta para eficientar tiempos.
                                                     Producto oProducto = new Producto();
                                                     oProducto.ProductoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
                                                     oProducto.Nombre = producto.getString(producto.getColumnIndex("Descripcion"));
                                                     //oProducto.SubEmpresaId = producto.getString(producto.getColumnIndex("SubEmpresaId"));
                                                     //oProducto.Venta = ((producto.getShort(producto.getColumnIndex("Venta")) == 1) ? true : false);
                                                     //oProducto.Contenido = ((producto.getShort(producto.getColumnIndex("Contenido")) == 1) ? true : false);
                                                     llenarProductoUnidad(oProducto, producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Inventario")), producto.getFloat(producto.getColumnIndex("PEntregado")));
                                                 }
                                             }
                );*/

                stopManagingCursor(cProductos);
            }
            catch (Exception e)
            {
                mostrarError(e.getMessage());
            }

            txtScanner.requestFocus();
            //calculando = false;

        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }
    private class vista implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            try {
                int viewId = view.getId();
                switch (viewId) {
                    case R.id.lblUnidad:
                        TextView unidadproducto = (TextView) view;
                        if (cursor.getColumnName(columnIndex).equalsIgnoreCase("TipoUnidad")) { // tipo unidad
                            unidadproducto.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
                        }
                        break;
                    case R.id.lblBuenEstadoF:
                        TextView cantidad = (TextView) view;
                        cantidad.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));
                        break;
                    case R.id.lblProductoClaveDescripcion:
                        TextView lblDescripcion = (TextView) view;
                        lblDescripcion.setText(cursor.getString(columnIndex) + "-" + cursor.getString(cursor.getColumnIndex("Descripcion")));
                        break;
                    default:
                        TextView texto = (TextView) view;
                        texto.setVisibility(View.GONE);
                        break;
                }
            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }
            return true;

        }
    }

    private View.OnClickListener mContinuar = new View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            try {
                BDVend.commit();
            }catch(Exception ex){
                try{
                    BDVend.rollback();
                }catch(Exception ex2){
                    mostrarError("Error: " + ex2.getMessage());
                }
            }
            finalizar();
        }
    };

}
