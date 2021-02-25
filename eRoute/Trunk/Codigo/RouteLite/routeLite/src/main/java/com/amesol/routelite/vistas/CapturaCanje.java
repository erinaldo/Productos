package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnKeyListener;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoUnidad;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.act.CapturarCanje;
import com.amesol.routelite.presentadores.interfaces.ICapturaCanje;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.EncriptaDesencripta;
import com.amesol.routelite.utilerias.Generales;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.atomic.AtomicReference;

public class CapturaCanje extends Vista implements ICapturaCanje
{
	private CapturarCanje mPresenta;
	private ListView lista;
	private CapturaProducto captura;
	private String mAccion;
	private HashMap<String, String> oParametros = null;
	private boolean esNuevo = true;
	private boolean soloLectura = false;
	private Cursor producto;
	private boolean imprimiendo;
	private boolean hayProductos = false;
	private boolean eliminar = false;
	private boolean huboCambios = false;
	
	private boolean vali = false; // esta variable se utiliza para regresar el booleano desde el dialogo para validar los permisos
	private int solicitarContrasena;
	LinearLayout destinoLayout;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		try 
		{
			/*if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
				manejoDobleUnidad = true;
			}*/

			setContentView(R.layout.captura_canje);
			deshabilitarBarra(true);

			imprimiendo = false;
			mAccion = getIntent().getAction();

            lblTitle.setText(Mensajes.get("XCanjes"));
            TextView texto = (TextView) findViewById(R.id.lblDisponible);
            texto.setText(Mensajes.get("XPuntosDisponibles") + ": ");
            texto = (TextView) findViewById(R.id.lblAcumulado);
            texto.setText(Mensajes.get("XPuntosAcumulados") + ": ");
		    texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));
			texto = (TextView) findViewById(R.id.lblUnidad);
			texto.setText(Mensajes.get("XUnidad"));

			Button boton = (Button) findViewById(R.id.btnContinuar);
			boton.setText(Mensajes.get("XContinuar"));
			boton.setOnClickListener(mContinuar);
			
			lista = (ListView) findViewById(R.id.lsTransProdDetalle);
			lista.setItemsCanFocus(false);
			
			captura = (CapturaProducto) findViewById(R.id.capturaProducto);

			/*if (((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase != null && ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase.length()>0){
				captura.setCadenaListasPrecios("'" + ((Vendedor)Sesion.get(Campo.VendedorActual)).ListaPrecioBase + "'");
				//manejarPrecios = true;
			}*/
			/*if (manejoDobleUnidad){
				captura.setOnAgregarProdDobleUnidadListener(mAgregarProductoDobleUnidad);
			}else {*/
            captura.setOnAgregarProductoListener(new CapturaProducto.onAgregarProductoListener() {
                @Override
                public void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad) {
                    Object aTransProdDetalle[] = null;
                    huboCambios = true;
                    try {

                        aTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(producto.ProductoClave, String.valueOf(tipoUnidad), "'" + mPresenta.getTransaccionId() + "'");
                        ProductoUnidad oPU = new ProductoUnidad();
                        oPU.ProductoClave = producto.ProductoClave;
                        oPU.PRUTipoUnidad = (short)tipoUnidad;
                        BDVend.recuperar(oPU);

                        if (aTransProdDetalle != null) { // si ya existe, seleccionarlo de la lista
                            if (Float.parseFloat(aTransProdDetalle[2].toString()) != cantidad) {
                                AtomicReference<Float> existencia = new AtomicReference<Float>();
                                StringBuilder error = new StringBuilder();

                                if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar) {

                                    if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad, Float.parseFloat(aTransProdDetalle[2].toString()), mPresenta.getModuloMovDetalle(), false, existencia, error)) {
                                        captura.setError(error.toString());
                                        if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva) {
                                            if (existencia.get() != null && existencia.get() > 0) {
                                                if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))
                                                    captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) - existencia.get());
                                                else
                                                    captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) + existencia.get());
                                            } else {
                                                captura.setCantidad(cantidad);
                                            }
                                            return;

                                        } else {
                                            captura.setAdvertencia(error.toString());
                                        }
                                    }
                                }
                                soloLectura = false;
                                mPresenta.eliminarDetalle(aTransProdDetalle[0].toString(), tipoUnidad, aTransProdDetalle[1].toString(), producto.ProductoClave, Float.parseFloat(aTransProdDetalle[2].toString()));
                                mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, oPU.ValorPuntos);

                            }
                        } else {

                            AtomicReference<Float> existencia = new AtomicReference<Float>();
                            StringBuilder error = new StringBuilder();
                            if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar) {

                                if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad, mPresenta.getModuloMovDetalle(), existencia, error)) {
                                    captura.setError(error.toString());
                                    if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva) {
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
                            soloLectura = false;
                            mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, oPU.ValorPuntos);
                        }
                    } catch (Exception e) {
                        mostrarError(e.getMessage());
                    }
                }
            });
			captura.setOnProductoNoEncontradoListener(new CapturaProducto.onProductoNoEncontradoListener()
			{

				@Override
				public void onProductoNoEncontrado()
				{
					captura.setTransProdIds("'" + mPresenta.getTransaccionId() + "'");
				}
			});

			mPresenta = new CapturarCanje(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				mPresenta.agregarTransaccion(oParametros.get("TransProdId"));
			}

			// si se paso como parametro el TransProdId, cargar el detalle del
			// pedido
			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				esNuevo = false;
				if (!oParametros.containsKey("Modificar")){
					soloLectura = true;				
					//Log.i(null, "modifica");
				}else{
					if (!Boolean.parseBoolean(oParametros.get("Modificar"))){
						soloLectura = true;	
						//Log.i(null, "modifica");
						this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.MODIFICAR);
					}
				}
					
				if(oParametros.get("Eliminar") != null && !oParametros.get("Eliminar").trim().equals("")){
					if(Boolean.parseBoolean(oParametros.get("Eliminar"))){
						soloLectura = true;
						eliminar = true;
						//captura.setVisibility(View.GONE);
						captura.setEnabled(false);
					}
				}
			}

            mPresenta.iniciar();
            if (!esNuevo){
                refrescarProductos(mPresenta.getTransaccionId());
            }

			captura.setTipoValidacionExistencia(mPresenta.getTipoValidacionExistencia());
            captura.setTipoMovimiento(mPresenta.getModuloMovDetalle().TipoMovimiento);
            captura.setTipoTransProd(mPresenta.getModuloMovDetalle().TipoTransProd);
            captura.setCadenaListasPrecios(mPresenta.getListasPrecios());
            captura.setTransProdIds("'" + mPresenta.getTransaccionId() + "'");
			
			if(!soloLectura){
				registerForContextMenu(lista);
			}

		}
		catch (Exception ex)
		{
			//			mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
		}
		final EditText txtScaner = (EditText) findViewById(R.id.txtScanner);
		final EditText txtCantidad = (EditText) findViewById(R.id.txtCantidad);

		final Spinner spinUnit = (Spinner) findViewById(R.id.cboUnidad);
		if (!(spinUnit.getCount() > 1))
			spinUnit.setEnabled(false);

		final InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);

		txtCantidad.setOnFocusChangeListener(new View.OnFocusChangeListener()
		{
			@Override
			public void onFocusChange(View v, boolean hasFocus)
			{
				if (hasFocus)
				{
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);

					txtScaner.clearFocus();
					imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);
					if (!(spinUnit.getCount() > 1))
						spinUnit.setEnabled(false);

					String mCantidad = mPresenta.consultarUnidadProductoExistente(mPresenta.getTransaccionId(), txtScaner.getText().toString());
					if (!mCantidad.equals("0"))
					{
						txtCantidad.setText(mCantidad);
						txtCantidad.requestFocus();
						txtCantidad.selectAll();
						txtCantidad.setSelectAllOnFocus(true);
					}

				}
			}
		});

		txtScaner.setOnFocusChangeListener(new View.OnFocusChangeListener()
		{
			@Override
			public void onFocusChange(View v, boolean hasFocus)
			{

				if (hasFocus)
				{
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
					txtCantidad.clearFocus();
				}
			}
		});
		
		
		if(esNuevo)
		{
			this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.CREAR);
		}
		
		if(eliminar)
		{
			this.validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.ELIMINAR);
		}
	
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			Button boton = (Button) findViewById(R.id.btnContinuar);
			try
			{
                if (!soloLectura)
                {
                    if (mPresenta.getPuntosTransaccion() > 0) {
                        if (mPresenta.validarPuntosDisponibles()) {
                            boton.setEnabled(false);
                            mPresenta.canjearPuntos();
                            mPresenta.solicitarFirma();
                        } else {
                            mostrarError(Mensajes.get("E0980"));
                        }
                    }
                    else
                        mostrarError(Mensajes.get("E0044").replace("$0$", Mensajes.get("XCanjes")));
                }
                else
                { // si es solo lectura, salir
                    if(eliminar){
                        mostrarPreguntaSiNo(Mensajes.get("P0001"), 99);
                    }else{
                        setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        finalizar();
                    }
                }

                /*MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                if (motConfig.get("MensajeImpresion").equals("0"))
                {
                    // si no esta configurada la pregunta salir
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }else if (motConfig.get("MensajeImpresion").equals("2")){
                    mostrarToast(Mensajes.get("E0934"));
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                    finalizar();
                }*/
			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
				boton.setEnabled(true);
			}
		}
	};

    public void guardar(String sNombre, String sNombreArchivo){
        Button boton = (Button) findViewById(R.id.btnContinuar);
        try
        {
            mPresenta.asignarGuardarValores(sNombre, sNombreArchivo);

            MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
            if (motConfig.get("MensajeImpresion").equals("0"))
            {
                // si no esta configurada la pregunta salir
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }else if (motConfig.get("MensajeImpresion").equals("2")){
                mostrarToast(Mensajes.get("E0934"));
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
        catch (Exception ex)
        {
            mostrarError(ex.getMessage());
            boton.setEnabled(true);
        }
    }

	@SuppressWarnings("unchecked")
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS)
		{
			// si esta regresándo de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				// si selecciono Agregar en la busqueda de productos, obtener la
				// seleccion y agregarlos al pedido
				// DatosProductos productosSeleccionados;
				// productosSeleccionados = (DatosProductos)
				// data.getExtras().getParcelable("Objeto");
				if (Sesion.get(Campo.ResultadoActividad) != null)
				{
					insertarSeleccion((HashMap<String, TransProdDetalle>) Sesion.get(Campo.ResultadoActividad));
					Sesion.remove(Campo.ResultadoActividad);
                    captura.setFinBusqueda();
				}else{
					//TODO: Checar el mensaje que trae ya que en ciertos escenario regresa null y manda un mensaje error nullPointer
                    //
					if (data != null &&  data.getStringExtra("mensajeIniciar") != null){
						txtScanner.setTexto(data.getStringExtra("mensajeIniciar"));
						captura.IngresaProductoBusquedaSimple(data.getStringExtra("mensajeIniciar"));
					}
                    //txtScanner.setTexto("");
                  //
                    //captura.IngresaProductoBusquedaSimple("");
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
                captura.setFinBusqueda();
			}
			//captura.setFinBusqueda();
		}else if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
				try
				{
					imprimiendo = true;
					mPresenta.imprimirTicket();
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}
			}
			else
			{
				mostrarError("No se pudo encender el BT");
			}

			return;
		}
        else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA)
        {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                String sNombre = "";
                String sNombreArchivo = "";
                if (data != null){
                    sNombre = (String) data.getExtras().getString("Nombre");
                    sNombreArchivo = (String) data.getExtras().getString("NombreArchivo");
                }
                guardar(sNombre, sNombreArchivo);
            }else
            {
                Button boton = (Button) findViewById(R.id.btnContinuar);
                boton.setEnabled(true);
            }
        }

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 2) //Eliminar producto
		{
			if (respuesta == RespuestaMsg.Si)
			{
				AtomicReference<Float> existencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());

                if (!Inventario.ValidarExistencia(producto.getString(producto.getColumnIndex("ProductoClave")), producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")), 0.0f, mPresenta.getModuloMovDetalle(), true, existencia, error)) {
                    mostrarError(Mensajes.get("E0714", producto.getString(producto.getColumnIndex("ProductoClave"))));
                    captura.setError(error.toString());

                    return;
                } else {
                    captura.setAdvertencia(error.toString());
                }

                soloLectura = false;
                huboCambios = true;
                mPresenta.eliminarDetalle(producto.getString(producto.getColumnIndex("mTransProdID")), producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getString(producto.getColumnIndex("_id")), producto.getString(producto.getColumnIndex("ProductoClave")), producto.getFloat(producto.getColumnIndex("Cantidad")));

			}
		}
		else if (tipoMensaje == 3) //Regresar
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 8) // Imprimir recibo
		{
			if (respuesta.equals(RespuestaMsg.Si))
			{
				// Imprimir ticket
				imprimiendo = true;
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						mPresenta.imprimirTicket();
					}

				}
				catch (ControlError e)
				{
					e.Mostrar(getVista());
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}
			}
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
		else if (tipoMensaje == 0 && imprimiendo)
		{

			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
        else if(tipoMensaje == 99) //Cancelar transaccion
        {
			try{
				if(respuesta == RespuestaMsg.Si){
					huboCambios = true;
                    mPresenta.canjearPuntos();
					TransaccionesDetalle.Pedidos.EliminarDetalleAjustesInventario(mPresenta.getTransaccionId(), false);
					BDVend.commit();
					setResultado(Resultados.RESULTADO_BIEN);
					finalizar();
				}else if(respuesta == RespuestaMsg.No){
					setResultado(Resultados.RESULTADO_MAL);
					finalizar();
				}
			}catch(Exception e){
				mostrarError(e.getMessage());
				e.printStackTrace();
			}
		}

	}

	@SuppressWarnings("deprecation")
	@Override
	public void refrescarProductos(String TransProdId)
	{
		try
		{
			/*if(manejoDobleUnidad){
				refrescarProductosDobleUnidad(TransProdId);
				return;
			}*/
			hayProductos = true;
			//obtenerTotales(TransProdId);
			ISetDatos stTransProdDetalle; //= Consultas.ConsultasTransProdDetalle.obtenerDetalle_Mov(TransProdId);

			stTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetalleCanje(TransProdId);
			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				SimpleCursorAdapter adapter;

                adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_canje, cProductos, new String[]
                        { "Cantidad", "TipoUnidad", "ProductoClave", "Descripcion", "ValorPuntos", "TotalPuntos" }, new int[]
                        { R.id.lblCantidad, R.id.lblUnidad, R.id.lblDescripcion, R.id.lblDescripcion, R.id.lblValorPuntos, R.id.lblTotalPuntos  });
				
				adapter.setViewBinder(new vista());
				lista.setAdapter(adapter);

                lista.setOnItemClickListener(new OnItemClickListener()
                {
                    public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
                    {
                        if (eliminar)
                        {

                        }
                        else
                        {
                            if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")) && (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 2))
                            {
                                // si recibio el transprodid como parametro y esta
                                // cancelado o surtido, mostrar cantidad de solo
                                // lectura
                                return;
                            }
                            producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());

                            Log.d("CapturaPedido", "Producto Seleccionado: " + producto.getString(producto.getColumnIndex("ProductoClave")));
                            lista.requestFocusFromTouch();
                            lista.setSelection(pos);
                            // Se crea el objeto producto con lo que se trae en la
                            // consulta para eficientar tiempos.
                            Producto oProducto = new Producto();
                            oProducto.ProductoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
                            oProducto.Nombre = producto.getString(producto.getColumnIndex("Descripcion"));
                            captura.llenarProductoUnidad(oProducto, producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
                        }

                    }
                });

			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}

            setPorCanjear(mPresenta.getPuntosTransaccion());
			txtScanner.requestFocus();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}

	}

    public boolean getEliminar(){
        return eliminar;
    }

	public void setFolio(String folio)
	{
		TextView texto = (TextView) findViewById(R.id.lblFolio);
		texto.setText(Mensajes.get("XFolio") + ": " + folio);
	}

	public void setFecha(String fecha)
	{
		TextView texto = (TextView) findViewById(R.id.lblFecha);
		texto.setText(Mensajes.get("XFecha") + ": " + fecha);
	}

    public void setDisponibles(float puntos)
    {
        TextView texto = (TextView) findViewById(R.id.txtDisponible);
        texto.setText(String.valueOf((int)puntos));
    }

    public void setAcumulados(float puntos)
    {
        TextView texto = (TextView) findViewById(R.id.txtAcumulado);
        texto.setText(String.valueOf((int)puntos));
    }

    public void setPorCanjear(float puntos)
    {
        TextView texto = (TextView) findViewById(R.id.lblTotalPuntos);
        if (eliminar)
            texto.setText(Mensajes.get("XTotalPuntosCanjeados") + ": " + String.valueOf((int)puntos));
        else
            texto.setText(Mensajes.get("XTotalPuntosCanjear") + ": " + String.valueOf((int)puntos));
        texto.refreshDrawableState();
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

	/*public OnItemLongClickListener menu = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			openContextMenu(lista);
			return true;
		}
	};*/

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_transaccion_detalle, menu);
        menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		mostrarPreguntaSiNo(Mensajes.get("P0233"), 2);
		return true;
	}

	@Override
	public void iniciar()
	{
	}

	private void salir()
	{
		if (!esNuevo)
		{
			if (!soloLectura)
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
		else
		{
			if (huboCambios)
			{
				if (!soloLectura)
					mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
				else
				{
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
			}
			else
			{ // no hay productos
				regresar();
			}
		}
	}

	private void regresar()
	{
		try
		{
			BDVend.rollback();
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private class vista implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
            try {
                switch (viewId) {
                    case R.id.lblCantidad:
                        TextView cantidad = (TextView) view;
                        cantidad.setText(String.valueOf(cursor.getFloat(columnIndex)));
                        break;
                    case R.id.lblUnidad:
                        TextView unidadproducto = (TextView) view;
                        unidadproducto.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
                        break;
                    case R.id.lblDescripcion:
                        TextView lblDescripcion = (TextView) view;
                        lblDescripcion.setText(cursor.getString(cursor.getColumnIndex("ProductoClave")) + " - " + cursor.getString(cursor.getColumnIndex("Descripcion")));
                        break;
					case R.id.lblValorPuntos:
                    case R.id.lblTotalPuntos:
						TextView txtTotal = (TextView) view;
						txtTotal.setText(String.valueOf(cursor.getInt(columnIndex)) + " pts");
						break;
                    default:
                        TextView texto = (TextView) view;
                        texto.setText(cursor.getString(columnIndex));
                        break;
                }
            }catch(Exception ex){
                mostrarError(ex.getMessage());
            }
			return true;
		}
	}

	private class vistaDobleUnidad implements ViewBinder
	{
		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			try {
				switch (viewId) {
					case R.id.lblUnidadProductoClave_Mov: //Cantidad2
						TextView unidadproducto = (TextView) view;
						if (cursor.getShort(cursor.getColumnIndex("UnidadAlterna"))>0 ){
							unidadproducto.setText(Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("CantidadAlterna")),cursor.getInt(cursor.getColumnIndex("DecimalProductoAlterna")) ) + " " +  ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("UnidadAlterna"))));
						}else{
							unidadproducto.setText("");
						}
						break;
					case R.id.lblCantidad_Mov: //Cantidad1
						TextView cantidad1 = (TextView) view;
						cantidad1.setText(Generales.getFormatoDecimal(cursor.getFloat(cursor.getColumnIndex("Cantidad")),cursor.getInt(cursor.getColumnIndex("DecimalProducto"))) + " " +  ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
						break;
					case R.id.lblDescripcion_Mov:
						TextView lblDescripcion = (TextView) view;
						lblDescripcion.setText(cursor.getString(cursor.getColumnIndex("ProductoClave")) + " - " + cursor.getString(cursor.getColumnIndex("Descripcion")));
						break;
					case R.id.lblTotal:
						TextView txtTotal = (TextView) view;
						if (mPresenta.getPCEPrecioClave()!= null && mPresenta.getPCEPrecioClave().length()>0){
							txtTotal.setVisibility(View.VISIBLE);
							txtTotal.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex),"#,##0.00"));
						}
						break;
					default:
						TextView texto = (TextView) view;
						texto.setText(cursor.getString(columnIndex));
						break;
				}
			}catch(Exception ex){
				mostrarError(ex.getMessage());
			}
			return true;
		}
	}

	/*public void setLimpiarMotivo()
	{
		if (spinMotivo.getAdapter() != null)
		{
			((SimpleCursorAdapter) spinMotivo.getAdapter()).getCursor().close();
		}
		spinMotivo.setEnabled(false);
	}*/
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa, String mensajeError)
	{
		if (mensajeError.equals(""))
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		else			
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);

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

	@SuppressWarnings("rawtypes")
	public void insertarSeleccion(HashMap<String, TransProdDetalle> transProdDetalles)
	{
		try
		{
			Iterator<Entry<String, TransProdDetalle>> it = transProdDetalles.entrySet().iterator();
			boolean bHuboInserciones = false;
            huboCambios = true;
			while (it.hasNext())
			{ // recorrer los productos
				Map.Entry producto = (Map.Entry) it.next();
				try
				{
					bHuboInserciones = true;
                    mPresenta.agregarProductoUnidad(((TransProdDetalle) producto.getValue()), false);
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
				}
			}

			if (bHuboInserciones)
			{
                refrescarProductos(mPresenta.getTransaccionId());
			}
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private Vista getVista()
	{
		return this;
	}

	private boolean validarInformacion(String id, String pass)
	{
		if (id.length() == 0)
		{
			mostrarAdvertencia(Mensajes.get("BE0001", Mensajes.get("XUsuario")));
			return false;
		}
		if (pass.length() == 0)
		{
			mostrarAdvertencia(Mensajes.get("BE0001", Mensajes.get("XContraseña")));
			return false;
		}
		return true;
	}
	
    public void validarPermisos(String tipoIndice, int tipoPermiso) //Metodo que valida permisos ldelatorre
    {
    	boolean validar = false;
		try
		{

			String id = "TINDMMD" + tipoIndice;
			String permiso = Consultas.ConsultasPermisos.validarPermisos(id);
			String contrasenaPara = ValoresReferencia.getDescripcion("TINDMMD", String.valueOf(tipoIndice));
            Log.i(null,"Chequeo de variables id:"+id+" permiso: "+permiso);

			if (permiso.equals("1"))
			{
				validar = true;
			}
			else
			{

				switch(tipoPermiso)
				{
					case Enumeradores.TipoPermiso.ACCESAR:
						if(permiso.equals("") && solicitarContrasena == 1)
						{

							showAlertDialog(contrasenaPara);
							solicitarContrasena = 0;
						}
						break;

					case Enumeradores.TipoPermiso.CREAR:
						if(!lineaPermiso('C',permiso) && solicitarContrasena == 1)
						{

							showAlertDialog(contrasenaPara);
						}
						break;

					case Enumeradores.TipoPermiso.MODIFICAR:
						if(!lineaPermiso('U',permiso) && solicitarContrasena == 1)
						{

							showAlertDialog(contrasenaPara);
						}
						break;

					case Enumeradores.TipoPermiso.ELIMINAR:
						if(!lineaPermiso('D',permiso) && solicitarContrasena == 1)
						{

							showAlertDialog(contrasenaPara);
						}
						break;
				}

				validar = vali;

			}

			if(Integer.parseInt(tipoIndice) == 8)
			{
				Log.i(null,"pasa contrasena: "+solicitarContrasena+" tipo indice"+tipoIndice);
				Sesion.set(Campo.SolicitarContrasenaDevolucionAlmacen, solicitarContrasena);
			}
			if(Integer.parseInt(tipoIndice) == 15 )
			{
				Log.i(null,"pasa contrasena: "+solicitarContrasena+" tipo indice"+tipoIndice);
				Sesion.set(Campo.SolicitarContrasenaDescarga, solicitarContrasena);
			}
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		//return validar;
    }

    public void showAlertDialog(String contrasenaPara)//Metodo que valida permisos ldelatorre
	{


		LayoutInflater factory = LayoutInflater.from(this);

		// text_entry is an Layout XML file containing two text field to display
		// in alert dialog


		final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);

		final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
		lblLogin.setText(Mensajes.get("XUsuario"));

		final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
		lblPass.setText(Mensajes.get("XContraseña"));

		final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
		final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);

		final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
		alert.setTitle(contrasenaPara).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
				String clave = txtUser.getText().toString();
				String pass = txtPass.getText().toString();
				if (validarInformacion(clave, pass))
				{
					Usuario usuario = null;
					try
					{
						usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
					}
					catch (Exception e)
					{
						e.printStackTrace();
						mostrarError(e.getMessage());
					}

					if ((usuario == null) || (!EncriptaDesencripta.encripta(pass).equals(usuario.ClaveAcceso)))
					{
						dialogoRegresar();

					}
					else
					{
						if (!usuario.PERClave.equals("Admin"))
							mostrarAdvertencia(Mensajes.get("I0271"));
						else
						 vali = true;
					}
				}
			}
		}).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
                 regresar();
			}
		}).setOnKeyListener(new OnKeyListener()
		{

			@Override
			public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event)
			{
				switch (keyCode)
				{
					case KeyEvent.KEYCODE_BACK:
						regresar();
						break;
				}
				return false;
			}
		});
		alert.show();

		//return vali;
	}

    private void dialogoRegresar()//Metodo que valida permisos ldelatorre
    {
    	AlertDialog.Builder dialog = new AlertDialog.Builder(this);

		dialog.setMessage(Mensajes.get("MDB050601"));
		dialog.setCancelable(false);
		dialog.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener() {

			@Override
			public void onClick(DialogInterface dialog, int which) {
				regresar();
			}
		});
		dialog.show();
    }

    private boolean lineaPermiso(char per, String permisos)//Metodo que valida permisos ldelatorre
    {
    	for(int x = 0; x < permisos.length(); x++)
    	{
    		char caracter = permisos.charAt(x);

    		if(caracter == per)
    		{
    			return true;
    		}
    	}
    	return false;
    }

}
