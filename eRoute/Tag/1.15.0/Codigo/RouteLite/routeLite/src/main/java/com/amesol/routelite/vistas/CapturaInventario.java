package com.amesol.routelite.vistas;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.InputType;
import android.util.Log;
import android.view.ContextMenu;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.InventarioMercadeo;
import com.amesol.routelite.datos.InventarioMercadeoDetalle;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.presentadores.interfaces.ICapturaInventario;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

public class CapturaInventario  extends Vista implements ICapturaInventario {

    TextBoxScanner txtScannerInv;

    boolean bClaveManual = false;
    boolean bMostrandoBusqueda = false;
    EditText txtCantidad;
    EditText txtInventario;

    ImageButton btnAgregar;
    TextView lblProDescripcion;
    TextView lblProUnidad;

    String listasPrecio;
    Producto oProducto = null;
    ListView lista;

    boolean bModificando = false;
    private int tipoValidarExistencia;
    ModuloMovDetalle moduloMovDetalle;
    HashMap<String,LinkedHashMap<String, Float>> preciosProductos;

    InventarioMercadeo oInventarioMercadeo;

    HashMap<String, TransProdDetalle> seleccionTPD;

    Boolean imprimiendo = false;

    Boolean blnHuboCambios = false;
    HashMap<String,InventarioMercadeoDetalle> imdOrig;

    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_inventario_pedido);
        deshabilitarBarra(true);

        HashMap<String, Object> oParametros = null;
        if (getIntent().getSerializableExtra("parametros") != null)
        {
            oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
            if (oParametros != null)
            {
                listasPrecio = oParametros.get("ListasPrecio").toString();
                tipoValidarExistencia = (Integer) oParametros.get("TipoValidarExistencia");

                try {
                    if (oParametros.containsKey("InventarioID") && !oParametros.get("InventarioID").equals("")) {
                        oInventarioMercadeo = new InventarioMercadeo();
                        oInventarioMercadeo.InventarioID = oParametros.get("InventarioID").toString();
                        BDVend.recuperar(oInventarioMercadeo);
                        BDVend.recuperar(oInventarioMercadeo, InventarioMercadeoDetalle.class);
                        bModificando = true;
                        if (oInventarioMercadeo == null){
                            mostrarError("Error al recuperar el Inventario Mercadeo");
                        }else{
                            imdOrig = new HashMap<String, InventarioMercadeoDetalle>();
                            for (InventarioMercadeoDetalle imd : oInventarioMercadeo.InventarioMercadeoDetalle) {
                                imdOrig.put(imd.ProductoClave, imd);
                                if (imd.PEntregado >0){
                                    StringBuilder sbPrecio = new StringBuilder();
                                    Float precio = ListaPrecio.BuscarPrecio(imd.ProductoClave, imd.TipoUnidad,  listasPrecio, sbPrecio, imd.PEntregado);
                                    if (precio >0) {
                                        if (preciosProductos == null) {
                                            preciosProductos = new HashMap<String, LinkedHashMap<String, Float>>();
                                        }

                                        if (!preciosProductos.containsKey(imd.ProductoClave)) {
                                            LinkedHashMap<String, Float> hmPrecio = new LinkedHashMap<String, Float>();
                                            hmPrecio.put(sbPrecio.toString(), precio);
                                            preciosProductos.put(imd.ProductoClave, hmPrecio);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }catch (Exception ex){
                    mostrarError("Error al recuperar el inventario");
                }
            }
        }

        String sModuloMovDetalleClave = (String) Sesion.get(Sesion.Campo.ModuloMovDetalleClave);
        moduloMovDetalle = new ModuloMovDetalle();
        moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
        try{
            BDVend.recuperar(moduloMovDetalle);
        }catch(Exception ex){
            if (ex != null)
                mostrarError(ex.getMessage());
            else
                mostrarError("Error al recuperar el módulo");
        }
        setTitulo(Mensajes.get("XTomaInventario"));

        TextView texto = (TextView) findViewById(R.id.lblProducto);
        texto.setText(Mensajes.get("XProducto"));

        texto = (TextView) findViewById(R.id.lblInventario);
        texto.setText(Mensajes.get("XInventario") + ":");

        texto = (TextView) findViewById(R.id.lblPedido);
        texto.setText(Mensajes.get("XPedido") + ":");

        Button boton = (Button) findViewById(R.id.btnContinuar);
        boton.setText(Mensajes.get("XContinuar"));
        boton.setOnClickListener(mContinuar);

        ImageButton btnBuscar = (ImageButton) findViewById(R.id.btnBuscarProducto);
        btnBuscar.setOnClickListener(mBuscarProducto);

        btnAgregar = (ImageButton) findViewById(R.id.btnAgregar);
        btnAgregar.setOnClickListener(mAgregarProducto);

        lblProDescripcion = (TextView)findViewById(R.id.lblProDescripcion);
        lblProUnidad = (TextView)findViewById(R.id.lblProUnidad);

        txtCantidad = (EditText) findViewById(R.id.txtCantidad);
        txtCantidad.selectAll();
        txtCantidad.setSelectAllOnFocus(true);
        txtCantidad.setOnKeyListener(new View.OnKeyListener()
        {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event)
            {
                if (event.getAction() == KeyEvent.ACTION_UP)
                {
                    // check if the right key was pressed
                    if (keyCode == KeyEvent.KEYCODE_ENTER)
                    {
                        btnAgregar.performClick();
                        return true;
                    }
                }
                return false;
            }
        });

        txtInventario = (EditText) findViewById(R.id.txtInventario);
        txtInventario.selectAll();
        txtInventario.setSelectAllOnFocus(true);
        txtInventario.setOnKeyListener(new View.OnKeyListener()
        {

            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event)
            {
                if (event.getAction() == KeyEvent.ACTION_UP)
                {
                    // check if the right key was pressed
                    if (keyCode == KeyEvent.KEYCODE_ENTER)
                    {
                        txtCantidad.requestFocus();
                        return true;
                    }
                }
                return false;
            }
        });

        // Obtenemos las referencias a los distintos controles
        txtScannerInv = (TextBoxScanner) findViewById(R.id.textBoxScanner);
        txtScannerInv.setOnCodigoIngresado(mCodigoBarras);
        txtScannerInv.setOnTextChanged(new TextBoxScanner.OnTextChangedListener()
        {
            @Override
            public void OnTextChanged(CharSequence s)
            {
                if (bClaveManual)
                    return;

                txtCantidad.setText("");
                txtInventario.setText("");
                lblProDescripcion.setText("");
                lblProUnidad.setText("");

                oProducto = null;
            }
        });
        //boton.setOnClickListener(mContinuar);

        lista = (ListView) findViewById(R.id.lsInventarioMercadeoDetalle);
        lista.setItemsCanFocus(false);
        registerForContextMenu(lista);
        lista.setOnItemLongClickListener(menu);

        if (bModificando){
            refrescarProductos();
        }

    }

    @Override
    public void iniciar()
    {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 3)
        {
            if (respuesta == Enumeradores.RespuestaMsg.Si)
            {
                regresar();
            }
        }else if (tipoMensaje == 2){
                if (respuesta == Enumeradores.RespuestaMsg.Si)
                {
                    try {
                        Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());

                        for (InventarioMercadeoDetalle imd : oInventarioMercadeo.InventarioMercadeoDetalle) {
                            if (imd.ProductoClave.equals(producto.getString(producto.getColumnIndex("ProductoClave")))) {
                                BDVend.eliminar(imd);
                                oInventarioMercadeo.InventarioMercadeoDetalle.remove(imd);
                                blnHuboCambios = true;
                                refrescarProductos();
                                break;
                            }
                        }
                    }catch (Exception ex){
                        if (ex != null)
                            mostrarError(ex.getMessage());
                        else
                            mostrarError("Error al eliminar detalle");
                    }

                    //eliminarDetalle(producto.getString(producto.getColumnIndex("TransProdID")), producto.getString(producto.getColumnIndex("TransProdDetalleID")), producto.getString(producto.getColumnIndex("SubEmpresaId")), producto.getString(producto.getColumnIndex("ProductoClave")), producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
                    limpiarProducto();
                }
        }else if (tipoMensaje == 8) {
            if (respuesta.equals(Enumeradores.RespuestaMsg.Si)) { // imprimir recibo
                // Imprimir ticket
                imprimiendo = true;
                try {
                    if (!bluetoothEncendido()) {
                        encenderBluetooth();
                    } else {
                        imprimirTicket();
                    }
                } catch (ControlError e) {
                    e.Mostrar(this);
                } catch (Exception e) {
                    mostrarError(e.getMessage());
                }
            } else {
                Sesion.set(Sesion.Campo.ResultadoActividad, seleccionTPD);
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN, oInventarioMercadeo.InventarioID);
                finalizar();
            }
        }
    }

    private void regresar()
    {
        try
        {
            if (!bModificando) {
                BDVend.eliminar(oInventarioMercadeo);
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }else{
                if(blnHuboCambios){
                    ArrayList<InventarioMercadeoDetalle> eliminar = new ArrayList<>();
                    for (InventarioMercadeoDetalle imd : oInventarioMercadeo.InventarioMercadeoDetalle){
                        if (imdOrig.containsKey(imd.ProductoClave)){
                            if (imd.Inventario != imdOrig.get(imd.ProductoClave).Inventario || imd.PEntregado != imdOrig.get(imd.ProductoClave).PEntregado){
                                imd.Inventario = imdOrig.get(imd.ProductoClave).Inventario;
                                imd.PEntregado =imdOrig.get(imd.ProductoClave).PEntregado;
                                BDVend.guardarInsertar(imd);
                            }
                        }else{
                            BDVend.eliminar(imd);
                            eliminar.add(imd);
                        }
                    }

                    for (InventarioMercadeoDetalle imdIni : imdOrig.values() ){
                        boolean capturado = false;
                        for (InventarioMercadeoDetalle imd : oInventarioMercadeo.InventarioMercadeoDetalle ){
                            if (imdIni.ProductoClave.equals(imd.ProductoClave)){
                                capturado = true;
                            }
                        }
                        if (!capturado){
                            //registro nuevo
                            InventarioMercadeoDetalle oInvMercadeoDet = new InventarioMercadeoDetalle();
                            oInvMercadeoDet.InventarioID = oInventarioMercadeo.InventarioID;
                            oInvMercadeoDet.ProductoClave = imdIni.ProductoClave;
                            oInvMercadeoDet.TipoUnidad = imdIni.TipoUnidad;
                            oInvMercadeoDet.Inventario = imdIni.Inventario;
                            oInvMercadeoDet.PEntregado = imdIni.PEntregado;
                            oInvMercadeoDet.MFechaHora = Generales.getFechaHoraActual();
                            oInvMercadeoDet.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                            oInvMercadeoDet.Enviado = false;
                            oInventarioMercadeo.InventarioMercadeoDetalle.add(oInvMercadeoDet);
                            BDVend.guardarInsertar(oInvMercadeoDet);
                        }
                    }

                    for(InventarioMercadeoDetalle imd : eliminar){
                        oInventarioMercadeo.InventarioMercadeoDetalle.remove(imd);
                    }
                }
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }
    @SuppressWarnings("unchecked")
    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS)
        {
            // si esta regresándo de la busqueda de productos
            bMostrandoBusqueda = false;
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
            {
                if (data != null)
                {
                    txtScanner.setTexto(data.getStringExtra("mensajeIniciar"));
                    if (txtScannerInv.getTexto().length()>0) {
                        buscarProducto(txtScannerInv.getTexto(), false);
                        txtInventario.requestFocus();
                        txtInventario.requestFocusFromTouch();
                    }
                }
            }
            else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
            {
                if (data != null)
                {
                    String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                    if (!mensajeError.equals(""))
                    { // cuando se presiona back se manda el mensaje vacio
                        mostrarError(mensajeError);
                    }
                }
            }else if (requestCode == REQUEST_ENABLE_BT) {
                if (resultCode == RESULT_OK) {
                    try {
                        imprimiendo = true;
                        imprimirTicket();
                    } catch (ControlError e) {
                        e.Mostrar(this);
                    } catch (Exception e) {
                        mostrarError(e.getMessage());
                    }
                } else {
                    mostrarError("No se pudo encender el BT");
                }

                return;
            }
        }
    }

    // ***************************** listener para buscar producto
    // ***************************************
    public interface onProductoNoEncontradoListener
    {
        void onProductoNoEncontrado();
    }

    private onProductoNoEncontradoListener buscarListener = null;

    public void setOnProductoNoEncontradoListener(onProductoNoEncontradoListener l)
    {
        buscarListener = l;
    }

    private android.view.View.OnClickListener mBuscarProducto = new android.view.View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            buscarProducto(txtScannerInv.getTexto(), false);
        }
    };

    private TextBoxScanner.OnCodigoIngresadoListener mCodigoBarras = new TextBoxScanner.OnCodigoIngresadoListener()
    {
        public void OnCodigoIngresado(String Codigo, int codigoLeido)
        {
            if (bClaveManual)
                return;
            if (Codigo.length() == 0)
                return;
            buscarProducto(Codigo, codigoLeido == 1 ? true : false);
        }
    };

    private void buscarProducto(String cadenaBusqueda, boolean codigoLeido)
    {

        try
        {
            if (bClaveManual)
                return;

            if (cadenaBusqueda.equals(""))
            {
                if (bMostrandoBusqueda)
                    return;
                if (buscarListener != null)
                {
                    buscarListener.onProductoNoEncontrado();
                }

               final HashMap<String, Object> parametros = new HashMap<String, Object>();
                parametros.put("Esquema", "Todos");
                parametros.put("Cadena", cadenaBusqueda);
                parametros.put("ListaPrecios", "");
                parametros.put("TransProd", "");
                parametros.put("TipoValidarExistencia", com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.NoValidar);
                parametros.put("TipoMovimiento", 0);
                parametros.put("TipoTransProd", 1);
                parametros.put("ModuloEsquemas", "");
                bMostrandoBusqueda = true;
                iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);

            }
            else
            {
                oProducto = null;
                if (!codigoLeido)
                {
                    oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(cadenaBusqueda);
                    if (oProducto == null)
                    {
                        // El producto debe mostrarse aunque no tenga precio
                        ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, "");
                        if (unidades != null && unidades.getCount() > 0)
                        {
                            if (unidades.moveToFirst())
                            {
                                bClaveManual = true;
                                txtScannerInv.setTexto(unidades.getString("ProductoClave"));
                                txtCantidad.requestFocus();
                                bClaveManual = false;
                                oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
                                if (oProducto != null)
                                {
                                    /*
                                    * TODO: Revisar si hay que hacer algo para validad el esquema y el envase
                                    */
                                    obtenerDetallesProducto(oProducto);
                                    //mostrarUnidades(unidades);
                                    //cboUnidad.setEnabled(false);
                                    getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                                    unidades.close();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (bMostrandoBusqueda)
                                return;
                            if (buscarListener != null)
                            {
                                buscarListener.onProductoNoEncontrado();
                            }
                            final HashMap<String, Object> parametros = new HashMap<String, Object>();
                            parametros.put("Esquema", "Todos");
                            parametros.put("Cadena", cadenaBusqueda);
                            parametros.put("ListaPrecios", "");
                            parametros.put("TransProd", "");
                            parametros.put("TipoValidarExistencia", com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.NoValidar);
                            parametros.put("TipoMovimiento", 0);
                            parametros.put("TipoTransProd", 1);
                            parametros.put("ModuloEsquemas", "");
                            bMostrandoBusqueda = true;
                            iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);
                        }
                        unidades.close();
                    }
                    else
                    {
						/*
						 * TODO: Revisar si hay que hacer algo para validad el esquema y el envase
						 */
                        obtenerDetallesProducto(oProducto);
                    }
                }
                else
                {
                    ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, "");
                    if (unidades != null)
                    {
                        if (unidades.moveToFirst())
                        {
                            bClaveManual = true;
                            txtScannerInv.setTexto(unidades.getString("ProductoClave"));
                            txtCantidad.requestFocus();
                            bClaveManual = false;
                            oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
                            if (oProducto != null)
                            {
                                /*
						        * TODO: Revisar si hay que hacer algo para validad el esquema y el envase
						        */
                                obtenerDetallesProducto(oProducto);
                                //mostrarUnidades(unidades);
                                //cboUnidad.setEnabled(false);
                                getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                                unidades.close();
                                return;
                            }
                        }
                    }
                    unidades.close();
                    mostrarError(Mensajes.get("E0863"));
                    txtScannerInv.BorrarTexto();

                }
            }
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
    }

    public void obtenerDetallesProducto(Producto producto)
    {
        try
        {
            validarProductoContenido(producto);

            int unidadMinima = Consultas.ConsultasProducto.obtenerUnidadMinima(oProducto.ProductoClave);
            if (unidadMinima <=0 )
            {
                mostrarError("El producto no tiene unidades definidas");
                producto = null;
                return;
            }
            lblProUnidad.setText(String.valueOf(unidadMinima));
            lblProDescripcion.setText(producto.Nombre);

            if (producto.DecimalProducto == 0){
                txtCantidad.setInputType(InputType.TYPE_CLASS_NUMBER);
                txtInventario.setInputType(InputType.TYPE_CLASS_NUMBER);
            }else{
                txtCantidad.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
                txtInventario.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
            }

            txtInventario.requestFocus();
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
        }
    }
    public boolean validarProductoContenido(Producto producto) throws Exception
    {
        if (producto.Contenido && !producto.Venta)
        {
            throw new ControlError("E0725");
        }
        return true;
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        switch (keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                if (!getImprimiendo())
                    salir();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    private void salir()
    {
            if (lista.getCount() >0)
            {
                if (!bModificando)
                    mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
                else
                    if (blnHuboCambios)
                        mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
            }
            else
            { // no hay productos
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
    }

    private View.OnClickListener mAgregarProducto = new View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            //if (agregarListener == null)
            //    return;

            if (validarCaptura())
            {
                if (Float.parseFloat(txtInventario.getText().toString()) >= 0 )
                {
                    //ajustar la cantidad capturada al numero de decimales configurados para el producto
                    float inventario = Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat((txtInventario.getText().toString().equals("") ? "0" : txtInventario.getText().toString())), oProducto.DecimalProducto));
                    float cantidad = Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat((txtCantidad.getText().toString().equals("") ? "0" : txtCantidad.getText().toString())), oProducto.DecimalProducto));
                    agregarProductoInventario(oProducto, Short.parseShort(String.valueOf((lblProUnidad.getText().equals("") ? 0 : lblProUnidad.getText()))), inventario, cantidad);
                }
                //else
                //{
                //    mostrarError(Mensajes.get("E0012"));
                //}
            }
        }
    };

    public void agregarProductoInventario(Producto producto, short tipoUnidad, float inventario, float cantidad)
    {
        try
        {
            if (oInventarioMercadeo == null){
                oInventarioMercadeo = new InventarioMercadeo();
                oInventarioMercadeo.InventarioID =  KeyGen.getId();
                oInventarioMercadeo.VisitaClave = ((Visita) Sesion.get(Sesion.Campo.VisitaActual)).VisitaClave;
                oInventarioMercadeo.DiaClave = ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave;
                oInventarioMercadeo.ClienteClave = ((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave;
                oInventarioMercadeo.MFechaHora =  Generales.getFechaHoraActual();
                oInventarioMercadeo.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                oInventarioMercadeo.Enviado = false;
                BDVend.guardarInsertar(oInventarioMercadeo);
            }

            InventarioMercadeoDetalle oInvMercadeoDet = null;
            if (oInventarioMercadeo.InventarioMercadeoDetalle != null && oInventarioMercadeo.InventarioMercadeoDetalle.size()>0){
                for (InventarioMercadeoDetalle imd : oInventarioMercadeo.InventarioMercadeoDetalle){
                    if (imd.ProductoClave.equals(producto.ProductoClave)){
                        oInvMercadeoDet = imd;
                    }
                }
            }
            if (oInvMercadeoDet != null)
            { // registro existente
                if (oInvMercadeoDet.Inventario != inventario || oInvMercadeoDet.PEntregado  != cantidad)
                {
                    AtomicReference<Float> existencia = new AtomicReference<Float>();
                    StringBuilder error = new StringBuilder();
                    if (oInvMercadeoDet.PEntregado != cantidad) {
                        if (tipoValidarExistencia != com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.NoValidar) {
                            if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad,oInvMercadeoDet.PEntregado, moduloMovDetalle, false, existencia, error)) {
                                if(error.toString().length()>0)
                                    mostrarError(error.toString());
                                if (tipoValidarExistencia== com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.ValidacionRestrictiva) {
                                    //if (!validarVenderApartado(producto, tipoUnidad, cantidad, Float.parseFloat(aTransProdDetalle[2].toString()), aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString()))
                                    //    return;
                                    if (existencia.get() != null && existencia.get() > 0) {
                                        txtCantidad.setText( Generales.getFormatoDecimal(oInvMercadeoDet.PEntregado  + existencia.get(), oProducto.DecimalProducto));
                                    } else {
                                        txtCantidad.setText(Generales.getFormatoDecimal(cantidad, oProducto.DecimalProducto));
                                    }
                                    return;
                                }
                            } else {
                                if(error.toString().length()>0)
                                    mostrarAdvertencia(error.toString());
                            }
                        }
                    }

                        BDVend.eliminar(oInvMercadeoDet);
                        oInventarioMercadeo.InventarioMercadeoDetalle.remove(oInvMercadeoDet);
                        //registro nuevo
                        oInvMercadeoDet = new InventarioMercadeoDetalle();
                        oInvMercadeoDet.InventarioID = oInventarioMercadeo.InventarioID;
                        oInvMercadeoDet.ProductoClave = producto.ProductoClave;
                        oInvMercadeoDet.TipoUnidad = tipoUnidad;
                        oInvMercadeoDet.Inventario = inventario;
                        oInvMercadeoDet.PEntregado = cantidad;
                        oInvMercadeoDet.MFechaHora = Generales.getFechaHoraActual();
                        oInvMercadeoDet.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                        oInvMercadeoDet.Enviado = false;
                        oInventarioMercadeo.InventarioMercadeoDetalle.add(oInvMercadeoDet);
                        BDVend.guardarInsertar(oInvMercadeoDet);
                }
            }
            else {
                //registro nuevo
                oInvMercadeoDet = new InventarioMercadeoDetalle();
                oInvMercadeoDet.InventarioID = oInventarioMercadeo.InventarioID;
                oInvMercadeoDet.ProductoClave = producto.ProductoClave;
                oInvMercadeoDet.TipoUnidad = tipoUnidad;
                oInvMercadeoDet.Inventario = inventario;
                oInvMercadeoDet.PEntregado = cantidad;
                oInvMercadeoDet.MFechaHora = Generales.getFechaHoraActual();
                oInvMercadeoDet.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                oInvMercadeoDet.Enviado = false;
                oInventarioMercadeo.InventarioMercadeoDetalle.add(oInvMercadeoDet);
                BDVend.guardarInsertar(oInvMercadeoDet);
            }

            limpiarProducto();
            blnHuboCambios = true;
            refrescarProductos();
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }
    }

    public void limpiarProducto()
    {
        try
        {
            txtScanner.BorrarTexto();
            txtCantidad.setText("");
            txtInventario.setText("");
            lblProDescripcion.setText("");
            lblProUnidad.setText("");
            oProducto = null;
            txtScanner.requestFocus();
        }
        catch (Exception e)
        {
            Log.e("", "" + e);

        }

    }

    public boolean validarCaptura()
    {
        if (oProducto == null)
        {
            mostrarError(Mensajes.get("BE0001", Mensajes.get("XProducto")));
            txtScanner.requestFocus();
            return false;
        }
        /*if (cboUnidad.getSelectedItemPosition() < 0)
        {
            mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XUnidad")));
            cboUnidad.requestFocus();
            return false;
        }*/
        if (txtInventario.getText().toString().trim().equals(""))
        {
            txtInventario.setText("0");
            //mostrarError(Mensajes.get("BE0001", Mensajes.get("XInventario")));
            //txtCantidad.requestFocus();
            //return false;
        }

        if (!txtCantidad.getText().toString().trim().equals("") && ( Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto))) >0 )
        {

            StringBuilder sbPrecio = new StringBuilder();
            Float precio = ListaPrecio.BuscarPrecio(oProducto.ProductoClave, Short.parseShort(lblProUnidad.getText().toString()),  listasPrecio, sbPrecio, (Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto))));
            if (precio <0) {
                mostrarError("No puede capturar cantidad de Pedido debido a que " + Mensajes.get("MDB042302"));
                return false;
            }

            if (preciosProductos == null)  {
                preciosProductos = new HashMap<String, LinkedHashMap<String, Float>>();
            }

            if (!preciosProductos.containsKey(oProducto.ProductoClave)){
                LinkedHashMap<String, Float> hmPrecio = new LinkedHashMap<String, Float>();
                hmPrecio.put(sbPrecio.toString(), precio);
                preciosProductos.put(oProducto.ProductoClave, hmPrecio);
            }

            AtomicReference<Float> existencia = new AtomicReference<Float>();
            StringBuilder error = new StringBuilder();

            if (tipoValidarExistencia != com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.NoValidar)
            {
                Float cantidadPedido = (txtCantidad.getText().toString().equals("") ? 0 : Float.parseFloat(txtCantidad.getText().toString()));
                if (!Inventario.ValidarExistencia(oProducto.ProductoClave, Short.parseShort(lblProUnidad.getText().toString()), cantidadPedido, moduloMovDetalle, existencia, error))
                {
                    if(error.toString().length()>0)
                        mostrarAdvertencia(error.toString());
                    if (tipoValidarExistencia == com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario.ValidacionRestrictiva)
                    {
                        //if(!validarVenderApartado(producto, tipoUnidad, cantidad))
                        //    return;
                        if (existencia.get() != null && existencia.get() > 0)
                        {
                            txtCantidad.setText(Generales.getFormatoDecimal(existencia.get(),oProducto.DecimalProducto));
                        }
                        else
                        {
                            txtCantidad.setText(Generales.getFormatoDecimal(0, oProducto.DecimalProducto));
                        }
                    }
                }
                else
                {
                    if(error.toString().length()>0)
                        mostrarAdvertencia(error.toString());
                }
            }

            //Aqui van las validaciones del pedido
            if (moduloMovDetalle.TipoTransProd == Enumeradores.TiposTransProd.PEDIDO || moduloMovDetalle.TipoTransProd == Enumeradores.TiposTransProd.MOV_SIN_INV_EV) {
                try{
                    if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("ValidarVtaMultiplo").length() > 0) {
                        if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("ValidarVtaMultiplo").equals("1")) {
                            if (oProducto.CantidadProduccion > 0) {
                                if (( Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto)) % oProducto.CantidadProduccion) != 0) {
                                    mostrarError(Mensajes.get("E0935", String.valueOf(oProducto.CantidadProduccion)));
                                    txtCantidad.requestFocus();
                                    return false;
                                }
                            }
                        }
                    }
                }catch (Exception ex){
                    mostrarError(ex.getMessage());
                    return false;
                }
            }

        }
        return true;
    }

    public void refrescarProductos()
    {
        try
        {
            //boolean existe = false;
            if (lista.getAdapter() != null){
                stopManagingCursor(((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())));
                ((Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor())).close();
               // existe = true;
            }
            ISetDatos stInventarioMercadeoDet = Consultas.ConsultasInventarioMercadeo.obtenerDetalle(oInventarioMercadeo.InventarioID);

            Cursor cProductos = (Cursor) stInventarioMercadeoDet.getOriginal();
            startManagingCursor(cProductos);
            try
            {
                //obtenerTotales(TransProdId);
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_producto, cProductos, new String[]
                        { "TipoUnidad", "ProductoClave", "Descripcion",  "Inventario",  "PEntregado", "Precio", "PEntregado", "PEntregado" }, new int[]
                        { R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblCantidad, R.id.lblExistencia, R.id.lblPU, R.id.lblTotal, R.id.lblCantidadOriginal });
                adapter.setViewBinder(new vista());
                lista.setAdapter(adapter);

                lista.setOnItemClickListener(new AdapterView.OnItemClickListener()
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
                );

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

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
    {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_transaccion_detalle, menu);

        menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
        menu.getItem(1).setVisible(false);
    }

    public AdapterView.OnItemLongClickListener menu = new AdapterView.OnItemLongClickListener()
    {

        @Override
        public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
        {
            openContextMenu(lista);
            return true;
        }
    };

    @Override
    public boolean onContextItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
            case R.id.eliminar:
                mostrarPreguntaSiNo(Mensajes.get("P0233"), 2);
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    public void llenarProductoUnidad(Producto producto, int tipoUnidad, Float inventario, Float cantidad)
    {

        txtScanner.setTexto(producto.ProductoClave);
        oProducto = producto;
        try
        {
            if (oProducto.isRecuperado() == false){
                BDVend.recuperar(producto);
            }

            obtenerDetallesProducto(oProducto);
            lblProUnidad.setText(String.valueOf(tipoUnidad));

            txtCantidad.setText(Generales.getFormatoDecimal(cantidad, producto.DecimalProducto ) );

            txtInventario.setText(Generales.getFormatoDecimal(inventario, producto.DecimalProducto ) );
            txtInventario.requestFocus();
            txtInventario.selectAll();
            txtInventario.setSelectAllOnFocus(true);

            if (oProducto.DecimalProducto == 0){
                txtCantidad.setInputType(InputType.TYPE_CLASS_NUMBER);
                txtInventario.setInputType(InputType.TYPE_CLASS_NUMBER);
            }else{
                txtCantidad.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
                txtInventario.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
            }
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }
    }
    // viewbinder para la lista de productos
    private class vista implements SimpleCursorAdapter.ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            try {
                int viewId = view.getId();
                switch (viewId) {
                    case android.R.id.text1: // para llenar el combo
                        TextView combo = (TextView) view;
                        combo.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));
                        break;
                    case R.id.lblUnidadProductoClave:
                        TextView unidadproducto = (TextView) view;
                        if (cursor.getColumnName(columnIndex).equalsIgnoreCase("TipoUnidad")) { // tipo unidad
                            unidadproducto.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
                        } else if (cursor.getColumnName(columnIndex).equalsIgnoreCase("ProductoClave")) { // producto clave
                            unidadproducto.setText(unidadproducto.getText() + " - " + cursor.getString(columnIndex));
                        }
                        break;
                    case R.id.lblCantidad:
                        TextView cantidad = (TextView) view;
                        cantidad.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));
                        break;
                    case R.id.lblExistencia:
                        TextView cant = (TextView) view;
                        cant.setText(Mensajes.get("XPedido") + ": " + Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));
                        break;
                    case R.id.lblDescripcion:
                        TextView lblDescripcion = (TextView) view;
                        lblDescripcion.setText(cursor.getString(columnIndex));
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
            Button boton = (Button) findViewById(R.id.btnContinuar);
            boton.setEnabled(false);
            if (oInventarioMercadeo == null || oInventarioMercadeo.InventarioMercadeoDetalle == null || oInventarioMercadeo.InventarioMercadeoDetalle.size()<=0 )
            {
                mostrarError(Mensajes.get("MDBAsignarProducto"));
                boton.setEnabled(true);
            }
            else
            {
                seleccionTPD = generarSeleccionados();
                terminar();
            }
        }
    };

    private void terminar(){
        String motConfig = (String) ((MOTConfiguracion) Sesion.get(Sesion.Campo.MOTConfiguracion)).get("MensajeImpresion");
        if (motConfig.equals("0")) {
            // si no esta configurada la pregunta salir
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        } else if (motConfig.equals("1")) {
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        }/* else if (motConfig.equals("2")) {
            mostrarPreguntaSiNo(Mensajes.get("P0246"), 9);
        }*/
    }
    private HashMap<String, TransProdDetalle> generarSeleccionados(){

        HashMap<String, TransProdDetalle> seleccionTPD = new HashMap<String, TransProdDetalle>();
        try
        {
            for (InventarioMercadeoDetalle imd : oInventarioMercadeo.InventarioMercadeoDetalle) {
                if (imd.PEntregado >0) {
                    if (preciosProductos != null && preciosProductos.containsKey(imd.ProductoClave)) {
                        String precioClave = preciosProductos.get(imd.ProductoClave).keySet().toString().replace("[","").replace("]", "");
                        seleccionTPD.put(imd.ProductoClave, TransaccionesDetalle.GenerarDetalleBusqueda(imd.ProductoClave, imd.TipoUnidad, imd.PEntregado,preciosProductos.get(imd.ProductoClave).get(precioClave),precioClave ));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
        }
       return  seleccionTPD;
    }

    public void imprimirTicket() throws Exception
    {
        Recibos recibo = new Recibos();

        short numImpresiones = 0;
        try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }

        recibo.imprimirRecibos(generarDocsAImprimir(), false, this, numImpresiones);

    }

    public List<Map<String, String>> generarDocsAImprimir()
    {
        List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
        Map<String, String> registro;
        registro = new HashMap<String, String>();
        registro.put("_Id", oInventarioMercadeo.InventarioID );
        registro.put("TipoRecibo", Recibos.TRECIBO.TOMA_DE_INVENTARIO);
        registro.put("Tipo", Recibos.TRECIBO.TOMA_DE_INVENTARIO);
        tabla.add(registro);
        return tabla;
    }
    @Override
    public void impresionFinalizada(boolean impresionExitosa, String mensajeError) {
        if (!mensajeError.equals(""))
            Toast.makeText(getApplicationContext(), mensajeError, Toast.LENGTH_LONG).show();

        setResult(Enumeradores.Resultados.RESULTADO_BIEN);

        quitarProgreso();

        try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
                } else {
                    finalizar();
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        }

    }
}
