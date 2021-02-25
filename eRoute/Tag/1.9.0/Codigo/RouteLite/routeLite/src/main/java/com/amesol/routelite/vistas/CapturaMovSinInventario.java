package com.amesol.routelite.vistas;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.atomic.AtomicReference;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemLongClickListener;
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
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.act.CapturarMovSinInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovSinInventario;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class CapturaMovSinInventario extends Vista implements ICapturaMovSinInventario
{
	private CapturarMovSinInventario mPresenta;
	private ListView lista;
	private CapturaProducto captura;
	private String mAccion;
	private HashMap<String, String> oParametros = null;
	private boolean esNuevo = true;
	private boolean soloLectura = false;
	private boolean huboCambios = false;
	private Cursor producto;
	private Spinner spinMotivo;
	private boolean imprimiendo;
	private boolean hayProductos = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		try
		{
			setContentView(R.layout.capturar_movsininvent);
			deshabilitarBarra(true);

			imprimiendo = false;

			mAccion = getIntent().getAction();
			ModuloMovDetalle mmd = new ModuloMovDetalle();
			mmd.ModuloMovDetalleClave = Sesion.get(Campo.ModuloMovDetalleClave).toString();
			BDVend.recuperar(mmd);
			lblTitle.setText(mmd.Nombre);

			TextView texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));
			texto = (TextView) findViewById(R.id.lblUnidad);
			texto.setText(Mensajes.get("XUnidad"));
			texto = (TextView) findViewById(R.id.lblMotivo);
			texto.setText(Mensajes.get("XMotivo"));
			Button boton = (Button) findViewById(R.id.btnContinuar);
			boton.setText(Mensajes.get("XContinuar"));
			boton.setOnClickListener(mContinuar);
			lista = (ListView) findViewById(R.id.lsTransProdDetalle);
			lista.setItemsCanFocus(false);
            //ocultar el campo destino para todas las acciones, se muestra u oculta dependiendo del motivo y solo para los ajustes
          LinearLayout lyoDestino;
            lyoDestino = (LinearLayout) findViewById(R.id.lyoDestino);
            lyoDestino.setVisibility(View.GONE);

			try
			{
				spinMotivo = (Spinner) findViewById(R.id.cboMotivo);
				spinMotivo.setEnabled(false);
				
				ISetDatos valores = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'MovSinInv'", "", false);
				llenarSpiner(spinMotivo, valores);
				if (!(spinMotivo.getCount() > 1))
					spinMotivo.setEnabled(false);
				else
					spinMotivo.setEnabled(true);

			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			captura = (CapturaProducto) findViewById(R.id.capturaProducto);
			
			captura.setOnAgregarProductoListener(new CapturaProducto.onAgregarProductoListener()
			{
				@Override
				public void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad)
				{
					try
					{

						Object aTransProdDetalle[] = Consultas.ConsultasTransProdDetalle.obtenerDetallePorProductoClaveUnidad(producto.ProductoClave, String.valueOf(tipoUnidad), "'" + mPresenta.getTransaccionesIds() + "'");
						if (aTransProdDetalle != null)
						{ // si ya existe, seleccionarlo de la lista
							if (Float.parseFloat(aTransProdDetalle[2].toString()) != cantidad)
							{
								AtomicReference<Float> existencia = new AtomicReference<Float>();
								StringBuilder error = new StringBuilder();
								if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar)
								{
									if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad, Float.parseFloat(aTransProdDetalle[2].toString()), mPresenta.getModuloMovDetalle(), false, existencia, error))
									{
										captura.setAdvertencia(error.toString());
										if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva)
										{
											if (existencia.get() != null && existencia.get() > 0)
											{
												captura.setCantidad(Float.parseFloat(aTransProdDetalle[2].toString()) + existencia.get());
											}
											else
											{
												captura.setCantidad(cantidad);
											}
											return;
										}
									}
								}
								soloLectura = false;
								mPresenta.eliminarDetalle(aTransProdDetalle[0].toString(), aTransProdDetalle[1].toString(), producto.ProductoClave, Float.parseFloat(aTransProdDetalle[2].toString()));
								if (spinMotivo.getCount() <=0  || spinMotivo.getSelectedItem() == null){
									mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad,null);

								}else{
									mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, Short.parseShort(String.valueOf (spinMotivo.getSelectedItemId())));
								}
							}
						}
						else
						{

							AtomicReference<Float> existencia = new AtomicReference<Float>();
							StringBuilder error = new StringBuilder();
							if (mPresenta.getTipoValidacionExistencia() != TiposValidacionInventario.NoValidar)
							{
								if (!Inventario.ValidarExistencia(producto.ProductoClave, tipoUnidad, cantidad, mPresenta.getModuloMovDetalle(), existencia, error))
								{
									captura.setAdvertencia(error.toString());
									if (mPresenta.getTipoValidacionExistencia() == TiposValidacionInventario.ValidacionRestrictiva)
									{
										if (existencia.get() != null && existencia.get() > 0)
										{
											captura.setCantidad(existencia.get());
										}
										else
										{
											captura.setCantidad(Float.valueOf(0));
										}
										return;
									}
								}
							}
							soloLectura = false;
							if (spinMotivo.getCount() <=0  || spinMotivo.getSelectedItem() == null){
								mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad, null);								
							}else{
								mPresenta.agregarProductoUnidad(producto.ProductoClave, tipoUnidad, cantidad,  Short.parseShort(String.valueOf (spinMotivo.getSelectedItemId())));								
							}
						}

					}
					catch (Exception e)
					{
						mostrarError(e.getMessage());
					}
				}
			});

			captura.setOnProductoNoEncontradoListener(new CapturaProducto.onProductoNoEncontradoListener()
			{

				@Override
				public void onProductoNoEncontrado()
				{
					captura.setTransProdIds(mPresenta.getTransProdIds());
				}
			});

			mPresenta = new CapturarMovSinInventario(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				mPresenta.agregarTransaccion(oParametros.get("TransProdId"));
			}

			mPresenta.iniciar();

			// si se paso como parametro el TransProdId, cargar el detalle del
			// pedido
			if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")))
			{
				esNuevo = false;
				refrescarProductos(mPresenta.getTransaccionesIds());
				
				if (!oParametros.containsKey("Modificar")){
					soloLectura = true;					
				}else{
					if (!Boolean.parseBoolean(oParametros.get("Modificar"))){
						soloLectura = true;	
					}
				}
				
			}

			captura.setTipoValidacionExistencia(mPresenta.getTipoValidacionExistencia());

			captura.setCadenaListasPrecios(mPresenta.getListasPrecios());
			captura.setTipoMovimiento(mPresenta.getModuloMovDetalle().TipoMovimiento);
			captura.setTipoTransProd(mPresenta.getModuloMovDetalle().TipoTransProd);

			
			if (soloLectura){
				captura.setVisibility(View.GONE);
			}else
			{
				registerForContextMenu(lista);
				lista.setOnItemLongClickListener(menu);
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

					String mCantidad = mPresenta.consultarUnidadProductoExistente(mPresenta.getTransaccionesIds(), txtScaner.getText().toString());

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
		
		//ocultar los spinners de la actividad de traspasos
		Spinner spDe = (Spinner) findViewById(R.id.spDe);
		Spinner spA = (Spinner) findViewById(R.id.spA);
		spinMotivo = (Spinner) findViewById(R.id.cboMotivo);
		
		spDe = (Spinner) findViewById(R.id.spDe);
		spDe.setVisibility(View.GONE);
		spA = (Spinner) findViewById(R.id.spA);
		spA.setVisibility(View.GONE);
		TextView text = (TextView) findViewById(R.id.lblDe);
		text.setVisibility(View.GONE);
		text = (TextView) findViewById(R.id.lblA);
		text.setVisibility(View.GONE);
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			Button boton = (Button) findViewById(R.id.btnContinuar);

			try
			{
				if (!hayProductos)
				{
					mostrarError(Mensajes.get("MDBAsignarProducto"));
				}
				else
				{
					if (!soloLectura)
					{ // no modificar si esta solo lectura
						boton.setEnabled(false);
                        mPresenta.solicitarFirma();
                        return;
						//mPresenta.asignarGuardarValores();
					}
					else
					{ // si es solo lectura, se quiere eliminar
						mostrarPreguntaSiNo(Mensajes.get("P0001"), 10);
						return;
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
                    txtScanner.setTexto(data.getStringExtra("mensajeIniciar"));
                    captura.IngresaProductoBusquedaSimple(data.getStringExtra("mensajeIniciar"));
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
		if (tipoMensaje == 2)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
				mPresenta.eliminarDetalle(producto.getString(producto.getColumnIndex("mTransProdID")), producto.getString(producto.getColumnIndex("_id")), producto.getString(producto.getColumnIndex("ProductoClave")), producto.getFloat(producto.getColumnIndex("Cantidad")));

			}
			//			mostrandoPregunta = false;
		}
		else if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 8)
		{ // imprimir recibo
			if (respuesta.equals(RespuestaMsg.Si))
			{
				// Imprimir ticket ME0838
				imprimiendo = true;
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}else{
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
		}else if (tipoMensaje == 10 && respuesta == RespuestaMsg.Si){
			mPresenta.eliminarMovimiento();						
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
	}

	@Override
	public void setHuboCambios(boolean cambio)
	{
		huboCambios = cambio;
	}

	@SuppressWarnings("deprecation")
	@Override
	public void refrescarProductos(String TransProdId)
	{
		try
		{

			// limpiarProducto();
			// ocultarTeclado();
			ISetDatos stTransProdDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetalle_Mov(TransProdId);
			hayProductos = true;
			Cursor cProductos = (Cursor) stTransProdDetalle.getOriginal();
			startManagingCursor(cProductos);
			try
			{
				//				obtenerTotales(TransProdId);
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_movimiento, cProductos, new String[]
				{ "ProductoClave", "Cantidad", "Descripcion" }, new int[]
				{ R.id.lblUnidadProductoClave_Mov, R.id.lblCantidad_Mov, R.id.lblDescripcion_Mov });
				adapter.setViewBinder(new vista());
				lista.setAdapter(adapter);

				lista.setOnItemClickListener(new OnItemClickListener()
				{

					public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
					{
						if (oParametros != null && (!oParametros.get("TransProdId").trim().equals("")) && (mPresenta.getTipoFase() == 0 || mPresenta.getTipoFase() == 2))
						{
							// si recibio el transprodid como parametro y esta
							// cancelado o surtido, mostrar cantidad de solo
							// lectura
							return;
						}
						// calculando = true;
						producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
						Log.d("CapturaPedido", "Producto Seleccionado: " + producto.getString(producto.getColumnIndex("ProductoClave")));
						//						final String TransProdId = producto.getString(producto.getColumnIndex("mTransProdID"));
						//						final String TransProdDetalleId = producto.getString(producto.getColumnIndex("_id"));
						lista.requestFocusFromTouch();
						lista.setSelection(pos);
						// Se crea el objeto producto con lo que se trae en la
						// consulta para eficientar tiempos.
						Producto oProducto = new Producto();
						oProducto.ProductoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
						oProducto.Nombre = producto.getString(producto.getColumnIndex("Descripcion"));
						//int Tipo = producto.getInt(producto.getColumnIndex("TipoMotivo"));
						captura.llenarProductoUnidad(oProducto, producto.getInt(producto.getColumnIndex("TipoUnidad")), producto.getFloat(producto.getColumnIndex("Cantidad")));
						//Generales.SelectSpinnerItemByValue(spinMotivo, Tipo);

					}
				}
						);

			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}

			txtScanner.requestFocus();
			//			calculando = false;

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}

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

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				salir();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public OnItemLongClickListener menu = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			openContextMenu(lista);
			return true;
		}
	};

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
		//		mostrandoPregunta = true;
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
			if (hayProductos)
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
			if (esNuevo)
			{
				BDVend.rollback();
			}
			else
			{
				if (huboCambios)
					BDVend.rollback();
			}
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
			switch (viewId)
			{
				case R.id.lblUnidadProductoClave_Mov:
					TextView unidadproducto = (TextView) view;
					unidadproducto.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));

					break;
				case R.id.lblCantidad_Mov:
					TextView cantidad = (TextView) view;
					cantidad.setText(String.valueOf(cursor.getFloat(columnIndex)));
					break;
				case R.id.lblDescripcion_Mov:
					TextView lblDescripcion = (TextView) view;
					lblDescripcion.setText(cursor.getString(cursor.getColumnIndex("ProductoClave")) + " - " + cursor.getString(columnIndex));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

/*	public void setLimpiarMotivo()
	{
		if (spinMotivo.getAdapter() != null)
		{
			((SimpleCursorAdapter) spinMotivo.getAdapter()).getCursor().close();
		}
		spinMotivo.setEnabled(false);
	}*/

	@SuppressWarnings("rawtypes")
	public void insertarSeleccion(HashMap<String, TransProdDetalle> transProdDetalles)
	{
		try
		{
			Iterator<Entry<String, TransProdDetalle>> it = transProdDetalles.entrySet().iterator();
			boolean bHuboInserciones = false;
			while (it.hasNext())
			{ // recorrer los productos
				Map.Entry producto = (Map.Entry) it.next();
				String productoClave = producto.getKey().toString();
				boolean validar = false;
				Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(productoClave);
				try
				{
					validar = mPresenta.validarProductoContenido(oProducto);
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
				}
				if(validar){
					try
					{
						bHuboInserciones = true;
						if (spinMotivo.getCount() <=0  || spinMotivo.getSelectedItem() == null){
							mPresenta.agregarProductoUnidad(((TransProdDetalle) producto.getValue()), false,null);					
						}else{
							mPresenta.agregarProductoUnidad(((TransProdDetalle) producto.getValue()), false, Short.parseShort(String.valueOf (spinMotivo.getSelectedItemId())));
						}
					}
					catch (Exception ex)
					{
						mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
					}	
				}

			}

			if (bHuboInserciones)
			{
				refrescarProductos(mPresenta.getTransaccionesIds());
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
	
	public void setTipoMotivo(Short tipoMotivo){
		Generales.SelectSpinnerItemByValue(spinMotivo, tipoMotivo);

	}

	public Short getTipoMotivo(){
		if (spinMotivo.getCount() <=0  || spinMotivo.getSelectedItem() == null){
			return null;
		}else{
			return  Short.parseShort(String.valueOf (spinMotivo.getSelectedItemId()));			
		}
	}
	private class llenarSpinner implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo de la unidad
					TextView combo = (TextView) view;
					Log.e("", ValoresReferencia.getDescripcion("TRPMOT", cursor.getString(cursor.getColumnIndex("suggest_intent_data"))));
					combo.setText(ValoresReferencia.getDescripcion("TRPMOT", cursor.getString(cursor.getColumnIndex("suggest_intent_data"))));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

	@SuppressWarnings("deprecation")
	public void llenarSpiner(Spinner control, ISetDatos valores)
	{

		try
		{

			Cursor unidad = (Cursor) valores.getOriginal();
			startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(CapturaMovSinInventario.this, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "suggest_intent_data" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new llenarSpinner());
			control.setAdapter(adapter);
		}
		catch (Exception e)
		{

			e.printStackTrace();
		}

	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa,String mensajeError)
	{
		if (mensajeError.equals(""))
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		else			
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
		
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
