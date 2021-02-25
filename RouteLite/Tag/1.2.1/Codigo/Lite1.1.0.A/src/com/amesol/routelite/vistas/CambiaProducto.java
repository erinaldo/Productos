package com.amesol.routelite.vistas;

import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

import android.app.Activity;
import android.app.SearchManager;
import android.content.Context;
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
import android.view.View.OnLongClickListener;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.act.CambiarProducto;
import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class CambiaProducto extends Vista implements ICambiaProducto
{

	//*********************************************************************************************
	//
	//	CAMBIO AUTOMATICO OK
	//	Crear cambio producto con cambio automatico ya esta OK
	//	Modificar cambio producto con cambio automatico ya esta OK
	//	Eliminar cambio producto con cambio automatico ya esta OK
	//
	//	SIN CAMBIO AUTOMATICO OK
	//	Crear cambio producto sin cambio automatico ya esta OK
	//	Modificar cambio producto sin cambio automatico ya esta OK
	//	Eliminar cambio producto sin cambio automatico ya esta OK
	//
	//*********************************************************************************************

	CambiarProducto mPresenta;
	String mAccion;
	HashMap<String, String> oParametros = null;
	CapturaProducto captura;
	ListView lista;
	boolean huboCambios = false;
	boolean esNuevo = true;
	boolean soloLectura = false;
	boolean cambioAutomatico;
	Short tipoMotivo;
	Cursor motivos;
	boolean confirmarFolio = false;
	Button btnContinuar;
	float importe;
	int tipoValidacionInventario;

	TransProdDetalle productoEliminar;

	@SuppressWarnings(
	{ "unchecked", "deprecation" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.cambio_producto);
			deshabilitarBarra(true);
			setTitulo(Mensajes.get("XCambios"));

			TextView texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));

			texto = (TextView) findViewById(R.id.lblUnidad);
			texto.setText(Mensajes.get("XUnidad"));

			texto = (TextView) findViewById(R.id.lblTotalProductos);
			texto.setText(Mensajes.get("XImporteT"));

			texto = (TextView) findViewById(R.id.txtTotalProductos);
			texto.setText(Generales.getFormatoDecimal(0, "$ #,##0.00"));

			btnContinuar = (Button) findViewById(R.id.btnContinuar);
			btnContinuar.setText(Mensajes.get("XContinuar"));
			btnContinuar.setOnClickListener(mContinuar);

			lista = (ListView) findViewById(R.id.lstTransProdDetalle);
			registerForContextMenu(lista);

			captura = (CapturaProducto) findViewById(R.id.capturaProducto);
			captura.setOnAgregarProductoListener(new CapturaProducto.onAgregarProductoListener()
			{
				@Override
				public void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad)
				{
					try
					{
						TransProdDetalle trp = mPresenta.existe(producto, tipoUnidad);
						if (trp != null)
						{ //si ya existe
							if (trp.Cantidad != cantidad)
							{
								StringBuilder error = new StringBuilder();
								//actualizar la cantidad
								if (mPresenta.actualizarCantidad(trp, cantidad, error))
								{
									captura.setAdvertencia("");
								}
								else
								{
									captura.setError(error.toString());
								}
							}
						}
						else
						{
							//si no existe agregarlo con el ultimo motivo seleccionado
							StringBuilder error = new StringBuilder();
							if (mPresenta.agregarProductoUnidad(producto, tipoUnidad, cantidad, tipoMotivo, false, error))
							{
								captura.setAdvertencia("");
							}
							else
							{
								captura.setError(error.toString());
							}
						}
						btnContinuar.setEnabled(true);
					}
					catch (Exception e)
					{
						mostrarError(e.getMessage());
					}
				}
			});

			MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			cambioAutomatico = Boolean.parseBoolean(m.get("CambioAutomatico").toString().equals("0") ? "false" : "true");

			if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
			{
				texto = (TextView) findViewById(R.id.lblFolio);
				texto.setVisibility(View.GONE);
				texto = (TextView) findViewById(R.id.lblFecha);
				texto.setVisibility(View.GONE);
				captura.setTipoMovimiento((short) TiposMovimientos.SALIDA);
				if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
				{
					tipoValidacionInventario = TiposValidacionInventario.NoValidar;
					captura.setTipoValidacionExistencia(TiposValidacionInventario.NoValidar);
				}
				else
				{
					tipoValidacionInventario = TiposValidacionInventario.ValidacionRestrictiva;
					captura.setTipoValidacionExistencia(TiposValidacionInventario.ValidacionRestrictiva);
				}

			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
			{
				if (cambioAutomatico)
				{
					//Se pone salida para que valide inventario
					captura.setTipoMovimiento((short) TiposMovimientos.SALIDA);
					if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
					{
						tipoValidacionInventario = TiposValidacionInventario.NoValidar;
						captura.setTipoValidacionExistencia(TiposValidacionInventario.NoValidar);
					}
					else
					{
						tipoValidacionInventario = TiposValidacionInventario.ValidacionRestrictiva;
						captura.setTipoValidacionExistencia(TiposValidacionInventario.ValidacionRestrictiva);
					}
				}
				else
				{
					captura.setTipoMovimiento((short) TiposMovimientos.ENTRADA);
					tipoValidacionInventario = TiposValidacionInventario.NoValidar;
					captura.setTipoValidacionExistencia(TiposValidacionInventario.NoValidar);
				}
			}

			tipoMotivo = 0;

			/*
			 * String moduloMovDetClave =
			 * Sesion.get(Campo.ModuloMovDetalleClave).toString();
			 * ModuloMovDetalle modulo = new ModuloMovDetalle();
			 * modulo.ModuloMovDetalleClave = moduloMovDetClave;
			 * BDVend.recuperar(modulo);
			 */

			ISetDatos mots = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'No Venta','Caducidad','Venta'", "", true);
			motivos = (Cursor) mots.getOriginal();
			startManagingCursor(motivos);

			mPresenta = new CambiarProducto(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (oParametros.get("Eliminar") != null))
			{
				soloLectura = Boolean.parseBoolean(oParametros.get("Eliminar").toString());
			}

			//si se paso como parametro el TransProdId, cargar el detalle
			if (oParametros != null && (oParametros.get("TransProdId") != null))
			{
				if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
				{
					esNuevo = Boolean.parseBoolean(oParametros.get("esNuevo").toString());
					importe = Float.parseFloat(oParametros.get("Importe").toString());
					huboCambios = Boolean.parseBoolean(oParametros.get("Cambios").toString());
				}
				else
				{
					esNuevo = false;
					huboCambios = false;
				}
				confirmarFolio = false;
				mPresenta.recuperarTransProd(oParametros.get("TransProdId"));
				refrescarProductos(mPresenta.getTransaccionesIds());
				if (cambioAutomatico) //recuperar el transprod de salida si es cambio automatico y no es nuevo
					mPresenta.recuperarTransProdIdSalida();
			}
			else
			{
				esNuevo = true;
				confirmarFolio = true;
				huboCambios = false;
				mPresenta.crearTransProd();
			}

			captura.setTipoTransProd(mPresenta.getTransProd().Tipo);
			if (!esNuevo && !soloLectura && cambioAutomatico)
				btnContinuar.setEnabled(false);

			if (soloLectura)
				captura.setVisibility(View.GONE);

			mPresenta.iniciar();

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
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
				// TODO Auto-generated method stub
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
	}

	@Override
	public void onDestroy()
	{
		super.onDestroy();
		Sesion.remove(Campo.ArrayTransProd);
	}

	@Override
	public void iniciar()
	{
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
				{
					salir();
				}
				else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
				{
					//setResultado(Enumeradores.Resultados.RESULTADO_MAL);
					Intent data = new Intent();
					data.putExtra("Cambios", huboCambios);
					setResult(Resultados.RESULTADO_MAL, data);
					finalizar();
				}
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public boolean getEsNuevo()
	{
		return esNuevo;
	}

	private void salir()
	{
		if (!esNuevo)
		{
			if (!soloLectura && huboCambios)
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
		else
		{
			if (hayProductos())
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
			{ //no hay productos
				regresar();
			}
		}
	}

	private void terminar()
	{
		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfig.get("MensajeImpresion").equals("1"))
		{
			mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
		}
		else
		{
			finalizar();
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

	public void setParametrosCaptura(String precioClave, String transProdIds)
	{
		//asignar la lista de precios y los ids al control de captura
		captura.setPCEPrecioClave(precioClave);
		captura.setTransProdIds(transProdIds);
	}

	private boolean hayProductos()
	{
		TextView totalProductos = (TextView) findViewById(R.id.txtTotalProductos);
		if (totalProductos.getText().toString().trim().equals("") || Float.parseFloat(totalProductos.getText().toString().replace(",", "").replace(",", ".").replace("$", "")) == 0)
			return false;
		else
			return true;
	}

	@SuppressWarnings("unchecked")
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		//try{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_CAMBIAR_PRODUCTO_SALIDA)
		{
			//si esta regresando de la captura de salida
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN && !soloLectura) //nuevo y modificar, si dio click en 'continuar'
				finalizar();
			else if (resultCode == Resultados.RESULTADO_BIEN && soloLectura)
			{ //eliminar si respondio 'si'
				try
				{
					if (mPresenta.eliminarMovimiento())
					{
						BDVend.commit();
						setResultado(Resultados.RESULTADO_BIEN);
						finalizar();
					}
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
			}
			else if (resultCode == Resultados.RESULTADO_TERMINAR && soloLectura) //salir si respondio 'no' al eliminar
				finalizar();
			else if (resultCode == Resultados.RESULTADO_MAL) //presiono regresar
				huboCambios = data.getBooleanExtra("Cambios", huboCambios);
			else if (resultCode == Resultados.RESULTADO_TERMINAR && !soloLectura)
			{ //imprimir recibo					
				if (!bluetoothEncendido())
				{
					try
					{
						encenderBluetooth();
					}
					catch (Exception e)
					{
						mostrarError(e.getMessage());
					}
				}
				else
				{
					mPresenta.imprimirTicket();
				}
			}
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS)
		{
			//si esta regresando de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				//si selecciono Agregar en la busqueda de productos, obtener la seleccion y agregarlos al pedido
				if (Sesion.get(Campo.ResultadoActividad) != null)
				{
					insertarSeleccion((HashMap<String, TransProdDetalle>) Sesion.get(Campo.ResultadoActividad));
					Sesion.remove(Campo.ResultadoActividad);
				}
			}
			captura.setFinBusqueda();
		}
		else if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
				//imprimiendo = true;
				mPresenta.imprimirTicket();
				setResultado(Enumeradores.Resultados.RESULTADO_TERMINAR);
				//finalizar();
			}
			else
			{
				mostrarError("No se pudo encender el BT");
				finalizar();
			}
		}
		/*
		 * }catch(Exception e){ mostrarError(e.getMessage()); }
		 */
	}

	@SuppressWarnings("rawtypes")
	public void insertarSeleccion(HashMap<String, TransProdDetalle> transProdDetalles)
	{
		try
		{
			Iterator it = transProdDetalles.entrySet().iterator();
			while (it.hasNext())
			{ //recorrer los productos
				Map.Entry producto = (Map.Entry) it.next();
				String productoClave = producto.getKey().toString();
				boolean validar = false;
				Producto oProducto = Consultas.ConsultasProducto.obtenerProducto(productoClave); // mPresenta.obtenerProducto(productoClave);
				try
				{
					validar = mPresenta.validarProductoContenido(oProducto);
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
				}
				if (validar)
				{ //agregarlo solo si no existe
					try
					{
						//En caso de venir de la busqueda no hay errores por devolver, por eso se omite el error
						mPresenta.agregarProductoUnidad(oProducto, ((TransProdDetalle) producto.getValue()), tipoMotivo, true);
					}
					catch (Exception ex)
					{
						mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
					}
				}
			}
			refrescarProductos(mPresenta.getTransaccionesIds());
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 8)
		{ //imprimir recibo
			if (respuesta.equals(RespuestaMsg.Si))
			{
				//Imprimir ticket
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						//mandar la impresion desde la pantalla del producto de entrada
						if (cambioAutomatico)
						{
							mPresenta.imprimirTicket();
						}
						else
						{
							setResultado(Resultados.RESULTADO_TERMINAR);
							finalizar();
						}
					}
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
			}
			else
			{
				finalizar();
			}
		}
		else if (tipoMensaje == 10)
		{ //eliminar movimiento
			if (respuesta.equals(RespuestaMsg.Si))
			{
				try
				{
					if (cambioAutomatico)
					{
						if (!mPresenta.eliminarMovimiento())
							return;

						BDVend.commit();

					}
					setResultado(Resultados.RESULTADO_BIEN);
					finalizar();
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
			}
			else
			{
				setResultado(Resultados.RESULTADO_TERMINAR);
				finalizar();
			}
		}
		else if (tipoMensaje == 5)
		{ //eliminar producto
			if (respuesta.equals(RespuestaMsg.Si))
			{
				mPresenta.eliminarDetalle(productoEliminar);
				refrescarProductos(mPresenta.getTransaccionesIds());
				huboCambios = true;
			}
		}
	}

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
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
		productoEliminar = (TransProdDetalle) lista.getItemAtPosition(info.position);
		switch (item.getItemId())
		{
			case R.id.eliminar:
				try
				{
					mostrarPreguntaSiNo(Mensajes.get("P0233"), 5);
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
				return true;
		}
		return false;
	}

	public void clickHandler(View v)
	{
		int viewId = v.getId();
		if (viewId != R.id.cboMotivo)
		{
			if (!soloLectura)
			{
				Spinner s = (Spinner) v.findViewById(R.id.cboMotivo);
				TransProdDetalle producto = (TransProdDetalle) lista.getItemAtPosition((Integer) s.getTag());
				captura.llenarProductoUnidad(producto.producto, producto.TipoUnidad, producto.Cantidad);
			}
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

	public void setHuboCambios(boolean cambio)
	{
		huboCambios = cambio;
	}

	public boolean getHuboCambios()
	{
		return huboCambios;
	}

	public void setTipoMotivo(short motivo)
	{
		tipoMotivo = motivo;
	}

	public short getTipoMotivo()
	{
		return tipoMotivo;
	}

	public int getTipoValidacionInventario()
	{
		return tipoValidacionInventario;
	}

	public boolean getCambioAutomatico()
	{
		return cambioAutomatico;
	}

	public void setCantidadCaptura(Float cantidad)
	{
		captura.setCantidad(cantidad);
	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			try
			{
				if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
				{
					if (!soloLectura)
					{ //nuevo y modificar
						if (mPresenta.getTransProd().TransProdDetalle.size() <= 0)
							throw new ControlError("E0044", Mensajes.get("XCambios"));

						CambiosAdapter cur = (CambiosAdapter) lista.getAdapter();
						for (int indice = 0; indice < cur.getCount(); indice = indice + 1)
						{
							if (cur.getItem(indice).TipoMotivo == 0)
							{
								throw new ControlError("E0161", Mensajes.get("XMotivo"));
							}
						}

						if (mPresenta.getTransProd() != null)
						{
							Transacciones.calcularTotalesTransaccion(mPresenta.getTransProd());
							BDVend.guardarInsertar(mPresenta.getTransProd());
						}

						if (!cambioAutomatico)
						{
							//mostrar la pantalla para capturar los productos de salida
							mPresenta.guardarEntradaYMostrarSalida(esNuevo, confirmarFolio, soloLectura);
							confirmarFolio = false;
						}
						else
						{
							if (mPresenta.getSalida() != null)
							{
								Transacciones.calcularTotalesTransaccion(mPresenta.getSalida());
								BDVend.guardarInsertar(mPresenta.getSalida());
							}
							BDVend.commit();
							terminar();
						}
					}
					else
					{ //eliminar
						if (cambioAutomatico)
							mostrarPreguntaSiNo(Mensajes.get("P0001"), 10);
						else
							mPresenta.guardarEntradaYMostrarSalida(false, false, soloLectura);
					}
				}
				else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
				{
					if (!soloLectura)
					{ //nuevo y modificar
						if (mPresenta.getTransProd().TransProdDetalle.size() <= 0)
							throw new ControlError("E0044", Mensajes.get("XCambios"));
						validarImportes();
						//guardar el movimiento y terminar
						//mPresenta.darSalida();
						if (esNuevo)
							Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());

						if (mPresenta.getTransProd() != null)
						{
							Transacciones.calcularTotalesTransaccion(mPresenta.getTransProd());
							BDVend.guardarInsertar(mPresenta.getTransProd());
						}

						setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						BDVend.commit();
						terminar();
					}
					else
					{ //eliminar
						mostrarPreguntaSiNo(Mensajes.get("P0001"), 10);
					}
				}
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

	private void validarImportes() throws ControlError
	{
		float importeSalida = Float.parseFloat(mPresenta.obtenerTotales(mPresenta.getTransaccionesIds()));
		if (importe != importeSalida)
		{
			throw new ControlError("E0045");
		}
	}

	public void refrescarProductos(String TransProdId)
	{
		try
		{
			try
			{
				obtenerTotales(TransProdId);
				if (mPresenta.getTransProd().TransProdDetalle.size() > 0)
				{
					Collections.sort(mPresenta.getTransProd().TransProdDetalle, new TransProdDetalle.comparator());
					CambiosAdapter adapter = new CambiosAdapter(this, R.layout.elemento_cambio_producto, mPresenta.getTransProd().TransProdDetalle.toArray(new TransProdDetalle[mPresenta.getTransProd().TransProdDetalle.size()]));
					lista.setAdapter(adapter);
				}
				else
				{
					lista.setAdapter(null);
				}
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
			txtScanner.requestFocus();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private void obtenerTotales(String TransProdID)
	{
		try
		{
			TextView texto = (TextView) findViewById(R.id.txtTotalProductos);
			texto.setText(Generales.getFormatoDecimal(Float.parseFloat(mPresenta.obtenerTotales(TransProdID)), "$ #,##0.00"));
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
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
		
    	finalizar();
	}

	public class CambiosAdapter extends ArrayAdapter<TransProdDetalle>
	{
		int textViewResourceId;
		Context context;
		TransProdDetalle objetos[];

		public CambiosAdapter(Context context, int textViewResourceId,
				TransProdDetalle[] objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
			objetos = objects;
		}

		@Override
		public int getViewTypeCount()
		{
			return objetos.length;
		}

		@Override
		public int getItemViewType(int position)
		{
			return position;
		}

		@SuppressWarnings("deprecation")
		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{

			View fila = convertView;
			Holder holder = null;
			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				fila = inflater.inflate(textViewResourceId, null);

				holder = new Holder();
				holder.ClaveProducto = (TextView) fila.findViewById(R.id.lblClave);
				holder.NombreProducto = (TextView) fila.findViewById(R.id.lblNombre);
				holder.Cantidad = (TextView) fila.findViewById(R.id.lblCantidad);
				holder.Unidad = (TextView) fila.findViewById(R.id.lblUnidad);
				holder.Total = (TextView) fila.findViewById(R.id.lblTotal);
				holder.Motivo = (TextView) fila.findViewById(R.id.lblMotivo);
				holder.TipoMotivo = (Spinner) fila.findViewById(R.id.cboMotivo);

				if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
				{
					if (motivos.getCount() > 0)
					{
						SimpleCursorAdapter adapter = new SimpleCursorAdapter(fila.getContext(), android.R.layout.simple_spinner_item, motivos,
								new String[]
								{ SearchManager.SUGGEST_COLUMN_TEXT_1 },
								new int[]
								{ android.R.id.text1 });
						adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
						holder.TipoMotivo.setAdapter(adapter);
						holder.TipoMotivo.setOnItemSelectedListener(new OnItemSelectedListener()
						{
							@Override
							public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
							{
								try
								{
									if (arg1 == null)
										return;
									Spinner s = (Spinner) arg1.getParent();
									CambiosAdapter ladapter = (CambiosAdapter) lista.getAdapter();
									TransProdDetalle detalle = ladapter.getItem((Integer) s.getTag());
									Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
									//actualizar solo si el motivo es diferente del que tenia
									if (detalle.TipoMotivo != item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA)))
									{
										mPresenta.actualizarMotivo(detalle, item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA)));
										btnContinuar.setEnabled(true);
									}
								}
								catch (Exception e)
								{
									mostrarError(e.getMessage());
								}
							}

							@Override
							public void onNothingSelected(AdapterView<?> arg0)
							{
							}
						});
					}

					if (soloLectura) //deshabilitar el spinner
						holder.TipoMotivo.setEnabled(false);
				}
				else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIAR_PRODUCTO_SALIDA))
				{
					holder.Motivo.setVisibility(View.GONE);
					holder.TipoMotivo.setVisibility(View.GONE);
				}
				holder.TipoMotivo.setTag(position);

				//asignar el listener solo si no es solo lectura
				if (!soloLectura)
				{
					fila.setOnLongClickListener(new OnLongClickListener()
					{

						@Override
						public boolean onLongClick(View v)
						{
							Log.d("Item", "LongClick");
							return false;
						}
					});
				}

				fila.setTag(holder);
			}
			else
			{
				holder = (Holder) fila.getTag();
			}

			TransProdDetalle producto = getItem(position);
			holder.ClaveProducto.setText(producto.ProductoClave + " - ");
			holder.NombreProducto.setText(producto.producto.Nombre);
			holder.Cantidad.setText(Generales.getFormatoDecimal(producto.Cantidad, producto.producto.DecimalProducto));
			holder.Unidad.setText(ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(producto.TipoUnidad)));
			holder.Total.setText(Generales.getFormatoDecimal(producto.Total, "$ #,##0.00"));
			if (mAccion.equals(Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA))
			{
				holder.Motivo.setText(Mensajes.get("XMotivo"));
				//if(motivos.getCount() > 0 && tipoMotivo != 0)
				Generales.SelectSpinnerItemByValue(holder.TipoMotivo, producto.TipoMotivo);
			}

			return fila;
		}

	}

	static class Holder
	{
		TextView ClaveProducto;
		TextView NombreProducto;
		TextView Cantidad;
		TextView Unidad;
		TextView Total;
		TextView Motivo;
		Spinner TipoMotivo;
	}
}
