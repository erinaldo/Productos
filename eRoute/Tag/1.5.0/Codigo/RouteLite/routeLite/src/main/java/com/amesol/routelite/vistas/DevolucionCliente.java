package com.amesol.routelite.vistas;

import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
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
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.CapturaProducto;
import com.amesol.routelite.controles.CapturaProducto.onAgregarProductoListener;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ModuloMovDetalle;
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
import com.amesol.routelite.presentadores.act.DevolverCliente;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

public class DevolucionCliente extends Vista implements IDevolucionCliente
{

	private DevolverCliente mPresenta;
	private String mAccion;
	private HashMap<String, String> oParametros = null;
	private boolean huboCambios = false;
	private boolean esNuevo = true;
	private boolean soloLectura = false;
	private CapturaProducto captura;
	private ListView lista;
	private Short tipoMotivo;
	private Cursor motivos;
	private TransProdDetalle productoEliminar;
	private EditText factura;
	private Button btnContinuar;
	private boolean errorFinalizar = false;
	private EditText txtCantidad;
	boolean mensajeLimiteEnvase = false;

	@SuppressWarnings(
	{ "deprecation", "unchecked" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			setContentView(R.layout.devolucion_cliente);
			deshabilitarBarra(true);
			setTitulo(Mensajes.get("XDevolucionCliente"));

			TextView texto = (TextView) findViewById(R.id.lblFactura);
			texto.setText(Mensajes.get("XFactura"));
			factura = (EditText) findViewById(R.id.txtFactura);

			texto = (TextView) findViewById(R.id.lblProducto);
			texto.setText(Mensajes.get("XProducto"));

			texto = (TextView) findViewById(R.id.lblUnidad);
			texto.setText(Mensajes.get("XUnidad"));

			texto = (TextView) findViewById(R.id.lblProductos);
			texto.setText(Mensajes.get("XProductos") + ": ");

			texto = (TextView) findViewById(R.id.txtProductos);
			texto.setText("0");

			texto = (TextView) findViewById(R.id.lblTotal);
			texto.setText(Mensajes.get("XGranTotal") + ": ");

			texto = (TextView) findViewById(R.id.txtTotal);
			texto.setText(Generales.getFormatoDecimal(0, "$ #,##0.00"));

			btnContinuar = (Button) findViewById(R.id.btnContinuar);
			btnContinuar.setText(Mensajes.get("XContinuar"));
			btnContinuar.setOnClickListener(mContinuar);

			captura = (CapturaProducto) findViewById(R.id.capturaProducto);
			String moduloMovDetClave = Sesion.get(Campo.ModuloMovDetalleClave).toString();
			ModuloMovDetalle modulo = new ModuloMovDetalle();
			modulo.ModuloMovDetalleClave = moduloMovDetClave;
			BDVend.recuperar(modulo);
			captura.setTipoMovimiento(modulo.TipoMovimiento);
			captura.setTipoTransProd(modulo.TipoTransProd);
			captura.setTipoValidacionExistencia(TiposValidacionInventario.NoValidar);
			captura.setOnAgregarProductoListener(mAgregar);

			lista = (ListView) findViewById(R.id.lstTransProdDetalle);
			registerForContextMenu(lista);

			ISetDatos mots = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'No Venta','Caducidad','Venta'", "", true);
			motivos = (Cursor) mots.getOriginal();
			startManagingCursor(motivos);

			tipoMotivo = 0;

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			mPresenta = new DevolverCliente(this, mAccion);

			if (oParametros != null && (oParametros.get("Eliminar") != null))
			{
				soloLectura = Boolean.parseBoolean(oParametros.get("Eliminar").toString());
				if (soloLectura)
				{
					captura.setVisibility(View.GONE);
					factura.setEnabled(false);
				}
			}

			// si se paso como parametro el TransProdId, cargar el detalle
			if (oParametros != null && (oParametros.get("TransProdId") != null))
			{
				esNuevo = false;
				mPresenta.recuperarTransProd(oParametros.get("TransProdId"));
				refrescarProductos(mPresenta.getTransaccionesIds());
			}
			else
			{
				esNuevo = true;
				try
				{
					mPresenta.crearTransProd();
				}
				catch (Exception e)
				{
					errorFinalizar = true;
					mostrarError(e.getMessage());
					return;
				}

			}

			if (!esNuevo && !soloLectura)
				btnContinuar.setEnabled(false);

			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}

		final Spinner spinUnit = (Spinner) findViewById(R.id.cboUnidad);
		if (!(spinUnit.getCount() > 1))
			spinUnit.setEnabled(false);

		final EditText txtScaner = (EditText) findViewById(R.id.txtScanner);
		txtCantidad = (EditText) findViewById(R.id.txtCantidad);

		final InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);

		txtCantidad.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				if (hasFocus) {
					txtScaner.clearFocus();
					imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);
					if (!(spinUnit.getCount() > 1))
						spinUnit.setEnabled(false);

					String mCantidad = mPresenta.consultarUnidadProductoExistente(mPresenta.getTransaccionesIds(), txtScaner.getText().toString());
					if (!mCantidad.equals("0")) {
						txtCantidad.setText(mCantidad);
						txtCantidad.requestFocus();
						txtCantidad.selectAll();
						txtCantidad.setSelectAllOnFocus(true);
					}// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);

				}
			}
		});

		txtScaner.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				// TODO Auto-generated method stub
				if (hasFocus) {
					// getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE);
					txtCantidad.clearFocus();
					imm.showSoftInput(txtCantidad, InputMethodManager.SHOW_FORCED);
					if (!(spinUnit.getCount() > 1))
						spinUnit.setEnabled(false);
				}
			}
		});
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
				salir();
				return true;
		}
		return super.onKeyDown(keyCode, event);
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

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_devolucion_cliente, menu);
        menu.getItem(0).setTitle(Mensajes.get("XSaldoEnvases"));
        menu.getItem(0).setVisible(false);
        if ( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && ((Cliente)Sesion.get(Campo.ClienteActual)).Prestamo ) {
            menu.getItem(0).setVisible(true);
        }
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
            case R.id.saldoEnvase:
                mostrarSaldoEnvase();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private void mostrarSaldoEnvase() {
        try{
            LayoutInflater inflater = (LayoutInflater) DevolucionCliente.this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            View dialogView = inflater.inflate(R.layout.dialog_saldoenvase, null);
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            TextView lbl = (TextView) dialogView.findViewById(R.id.lblTituloDialogoSaldoEnvase);
            lbl.setText(Mensajes.get("XSaldoEnvases"));

            lbl = (TextView) dialogView.findViewById(R.id.lblClave);
            lbl.setText(Mensajes.get("XClave"));

            lbl = (TextView) dialogView.findViewById(R.id.lblCargo);
            lbl.setText(Mensajes.get("XCargo"));

            lbl = (TextView) dialogView.findViewById(R.id.lblAbono);
            lbl.setText(Mensajes.get("XAbono"));

            lbl = (TextView) dialogView.findViewById(R.id.lblVenta);
            lbl.setText(Mensajes.get("XVenta"));

            lbl = (TextView) dialogView.findViewById(R.id.lblSaldo);
            lbl.setText(Mensajes.get("XSaldo"));

            ListView modeList = (ListView) dialogView.findViewById(R.id.lstSaldoEnvase);
            modeList.setBackgroundColor(Color.WHITE);

            Cursor cursor = mPresenta.obtenerSaldoEnvase();
            SimpleCursorAdapter adapter = new SimpleCursorAdapter(this,R.layout.lista_simple_hor5,cursor,
                    new String[]{"ProductoClave","Cargo","Abono","Venta","Saldo"},
                    new int[]{R.id.txtCol1,R.id.txtCol2,R.id.txtCol3,R.id.txtCol4,R.id.txtCol5});

            modeList.setAdapter(adapter);

            builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialog, int id) {
                    dialog.dismiss();
                }
            });
            builder.setView(dialogView);
            final Dialog dialog = builder.create();
            dialog.show();
        }catch(Exception e){
            mostrarError(e.getMessage());
            e.printStackTrace();
        }
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

	private void terminar()
	{
		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfig.get("MensajeImpresion").equals("1"))
		{
			mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
		}else if (motConfig.get("MensajeImpresion").equals("2")){
            mostrarToast(Mensajes.get("E0934"));
            finalizar();
        }
		else
		{
			finalizar();
		}
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			try
			{
				if (!soloLectura)
				{
					if (mPresenta.getTransProd().TransProdDetalle.size() <= 0)
						throw new ControlError("E0044", Mensajes.get("XDevoluciones"));

					DevolucionAdapter cur = (DevolucionAdapter) lista.getAdapter();
					for (int indice = 0; indice < cur.getCount(); indice = indice + 1)
					{
						if (cur.getItem(indice).TipoMotivo == 0)
						{
							throw new ControlError("E0161", Mensajes.get("XMotivo"));
						}
					}

                    if(!esNuevo){ //modificando
                        //validacion limite prestamo envase
						mPresenta.validarLimitePrestamoEnvase();
                    }

					if (esNuevo)
						Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());

					mPresenta.guardarNotas(factura.getText().toString());

					if (mPresenta.getTransProd() != null)
					{
						Transacciones.calcularTotalesTransaccion(mPresenta.getTransProd());
						BDVend.guardarInsertar(mPresenta.getTransProd());
					}

					BDVend.commit();
					//terminar();

					Runnable accion = new Runnable()
					{

						@Override
						public void run()
						{
							while(getMensajeLimiteEnvase()){
								//esperar hasta que se quite el mensaje de validacion de credito para continuar
							}
							runOnUiThread(new Runnable()
							{ //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
								@Override
								public void run()
								{
									terminar();
								}
							});
						}
					};
					final Thread hilo = new Thread(accion);
					hilo.start();
				}
				else
				{
					mostrarPreguntaSiNo(Mensajes.get("P0001"), 10);
				}

			}
			catch (ControlError e)
			{
				mostrarError(e.getMessage());
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

	private boolean hayProductos()
	{
		// TextView totalProductos = (TextView)
		// findViewById(R.id.txtTotalProductos);
		// if(totalProductos.getText().toString().trim().equals("") ||
		// Float.parseFloat(totalProductos.getText().toString().replace(",","").replace(",",
		// ".").replace("$","")) == 0)
		if (mPresenta.getTransProd().TransProdDetalle.size() <= 0)
			return false;
		else
			return true;
	}

	@SuppressWarnings("unchecked")
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS)
		{
			// si esta regresando de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				// si selecciono Agregar en la busqueda de productos, obtener la
				// seleccion y agregarlos al pedido
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
				// imprimiendo = true;
				mPresenta.imprimirTicket();
				setResultado(Enumeradores.Resultados.RESULTADO_TERMINAR);
			}
			else
			{
				mostrarError("No se pudo encender el BT");
				finalizar();
			}
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if(mensajeLimiteEnvase)
			mensajeLimiteEnvase = false;

		if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
		else if (tipoMensaje == 5)
		{ // eliminar producto
			if (respuesta.equals(RespuestaMsg.Si))
			{
				mPresenta.eliminarDetalle(productoEliminar);
				refrescarProductos(mPresenta.getTransaccionesIds());
				huboCambios = true;
			}
		}
		else if (tipoMensaje == 8)
		{ // imprimir recibo
			if (respuesta.equals(RespuestaMsg.Si))
			{
				// Imprimir ticket
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
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
				finalizar();
			}
			else
			{
				finalizar();
			}
		}
		else if (tipoMensaje == 10)
		{ // eliminar movimiento
			if (respuesta.equals(RespuestaMsg.Si))
			{
				try
				{


					if (mPresenta.eliminarMovimiento())
					{
						//validacion limite prestamo envase
						mPresenta.validarLimitePrestamoEnvase();
					}

					Runnable accion = new Runnable()
					{

						@Override
						public void run()
						{
							while(getMensajeLimiteEnvase()){
								//esperar hasta que se quite el mensaje de validacion de credito para continuar
							}
							runOnUiThread(new Runnable()
							{ //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
								@Override
								public void run()
								{
									try{
										BDVend.commit();
										setResultado(Resultados.RESULTADO_BIEN);
										finalizar();
									}catch(Exception ex){
										mostrarError(ex.getMessage());
										ex.printStackTrace();
									}
								}
							});
						}
					};
					final Thread hilo = new Thread(accion);
					hilo.start();

				}catch(ControlError ce){
					try{
						if(ce.getMessage().contains("E0917")){
							BDVend.rollback();
						}
						ce.Mostrar(this);
					}catch (Exception e){
						e.printStackTrace();
					}
				}
				catch (Exception e)
				{
					mostrarError(e.getMessage());
				}
			}
			else
			{
				// setResultado(Resultados.RESULTADO_TERMINAR);
				finalizar();
			}
		}
		else if (tipoMensaje == 0)
		{
			if (errorFinalizar)
				finalizar();
		}
	}

	private onAgregarProductoListener mAgregar = new onAgregarProductoListener()
	{
		@Override
		public void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad)
		{
			try
			{
				TransProdDetalle trp = mPresenta.existe(producto, tipoUnidad);
				if (trp != null)
				{ // si ya existe
					if (trp.Cantidad != cantidad)
					{
						// actualizar la cantidad
						mPresenta.actualizarCantidad(trp, cantidad);
					}
				}
				else
				{
					// si no existe agregarlo con el ultimo motivo seleccionado
					trp = mPresenta.agregarProductoUnidad(producto, tipoUnidad, cantidad, tipoMotivo);
				}
				// btnContinuar.setEnabled(true);
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
			}
		}
	};

	@SuppressWarnings("rawtypes")
	public void insertarSeleccion(HashMap<String, TransProdDetalle> transProdDetalles)
	{
		try
		{
			Iterator it = transProdDetalles.entrySet().iterator();
			while (it.hasNext())
			{ // recorrer los productos
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
				{ // agregarlo solo si no existe
					try
					{
						mPresenta.agregarProductoUnidad(oProducto, ((TransProdDetalle) producto.getValue()), tipoMotivo);
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

	public void setFolio(String folio)
	{
		TextView texto = (TextView) findViewById(R.id.txtFolio);
		texto.setText(Mensajes.get("XFolio") + ": " + folio);
	}

	public void setFecha(String fecha)
	{
		TextView texto = (TextView) findViewById(R.id.txtFecha);
		texto.setText(Mensajes.get("XFecha") + ": " + fecha);
	}

	public void setFactura(String factura)
	{
		this.factura.setText(factura);
	}

	public void setListaPrecio(String lista)
	{
		TextView texto = (TextView) findViewById(R.id.txtListaPrecio);
		texto.setText(Mensajes.get("XListaPrecio") + ": " + lista);
	}

	public void setTotal(String total)
	{
		TextView texto = (TextView) findViewById(R.id.txtTotal);
		texto.setText(Generales.getFormatoDecimal(Float.parseFloat(total), "$ #,##0.00"));
	}

	public void setProductosDev(String productos)
	{
		TextView texto = (TextView) findViewById(R.id.txtProductos);
		texto.setText(productos);
	}

	public void setHuboCambios(boolean cambios)
	{
		huboCambios = cambios;
		if (!esNuevo)
			btnContinuar.setEnabled(true);
	}

	public void setTipoMotivo(short motivo)
	{
		tipoMotivo = motivo;
	}

	public void setParametrosCaptura(String listasPrecios, String transProdIds)
	{
		// asignar la lista de precios y los ids al control de captura
		captura.setCadenaListasPrecios(listasPrecios);
		captura.setTransProdIds(transProdIds);
	}

	public boolean getEsNuevo()
	{
		return esNuevo;
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
					DevolucionAdapter adapter = new DevolucionAdapter(this, R.layout.elemento_devolucion_cliente, mPresenta.getTransProd().TransProdDetalle.toArray(new TransProdDetalle[mPresenta.getTransProd().TransProdDetalle.size()]));
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
			// TextView texto = (TextView) findViewById(R.id.txtTotal);
			// texto.setText(Generales.getFormatoDecimal(Float.parseFloat(mPresenta.obtenerTotales(TransProdID)),
			// "$ #,##0.00"));
			mPresenta.obtenerTotales(TransProdID);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
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
				txtCantidad.requestFocus();
				txtCantidad.selectAll();
				txtCantidad.setSelectAllOnFocus(true);

			}
		}
	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa, String mensajeError)
	{
		if (mensajeError.equals(""))
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		else			
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
		
		quitarProgreso();
		finalizar();
	}

	public class DevolucionAdapter extends ArrayAdapter<TransProdDetalle>
	{
		int textViewResourceId;
		Context context;
		TransProdDetalle objetos[];

		public DevolucionAdapter(Context context, int textViewResourceId, TransProdDetalle[] objects)
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
				holder.SubTotal = (TextView) fila.findViewById(R.id.lblSubtotal);
				holder.Impuesto = (TextView) fila.findViewById(R.id.lblImpuesto);
				holder.Total = (TextView) fila.findViewById(R.id.lblTotal);
				holder.Motivo = (TextView) fila.findViewById(R.id.lblMotivo);
				holder.TipoMotivo = (Spinner) fila.findViewById(R.id.cboMotivo);

				if (motivos.getCount() > 0)
				{
					@SuppressWarnings("deprecation")
					SimpleCursorAdapter adapter = new SimpleCursorAdapter(fila.getContext(), android.R.layout.simple_spinner_item, motivos, new String[]
					{ SearchManager.SUGGEST_COLUMN_TEXT_1 }, new int[]
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
								DevolucionAdapter ladapter = (DevolucionAdapter) lista.getAdapter();
								TransProdDetalle detalle = ladapter.getItem((Integer) s.getTag());
								Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
								// actualizar solo si el motivo es diferente del
								// que tenia
								if (detalle.TipoMotivo != item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA)))
								{
									if (!mPresenta.actualizarMotivo(detalle, item.getShort(item.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA))))
									{
										Generales.SelectSpinnerItemByValue(s, detalle.TipoMotivo);
									}
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

				if (soloLectura) // deshabilitar el spinner
					holder.TipoMotivo.setEnabled(false);

				holder.TipoMotivo.setTag(position);

				// asignar el listener solo si no es solo lectura
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
			//holder.SubTotal.setText(Mensajes.get("XSubtotal") + ": " + Generales.getFormatoDecimal(producto.Subtotal, "$ #,##0.00"));
			//holder.Impuesto.setText(Mensajes.get("XImpuesto") + ": " + Generales.getFormatoDecimal(producto.Impuesto, "$ #,##0.00"));
			//holder.Total.setText(Mensajes.get("XTotal") + ": " + Generales.getFormatoDecimal(producto.Total, "$ #,##0.00"));
			holder.SubTotal.setText(Generales.getFormatoDecimal(producto.Subtotal, "$ #,##0.00"));
			holder.Impuesto.setText(Generales.getFormatoDecimal(producto.Impuesto, "$ #,##0.00"));
			holder.Total.setText(Generales.getFormatoDecimal(producto.Total, "$ #,##0.00"));
			holder.Motivo.setText(Mensajes.get("XMotivo"));
			Generales.SelectSpinnerItemByValue(holder.TipoMotivo, producto.TipoMotivo);

			return fila;
		}

	}

	static class Holder
	{
		TextView ClaveProducto;
		TextView NombreProducto;
		TextView Cantidad;
		TextView Unidad;
		TextView SubTotal;
		TextView Impuesto;
		TextView Total;
		TextView Motivo;
		Spinner TipoMotivo;
	}

	public void setMensajeLimiteEnvase(boolean mostrandoMensaje){
		mensajeLimiteEnvase = mostrandoMensaje;
	}

	public boolean getMensajeLimiteEnvase(){
		return mensajeLimiteEnvase;
	}

}
