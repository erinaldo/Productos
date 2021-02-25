package com.amesol.routelite.vistas;

import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.HashMap;

import android.annotation.SuppressLint;
import android.app.ActionBar;
import android.bluetooth.BluetoothAdapter;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.os.Parcelable;
import android.support.v4.app.FragmentActivity;
import android.util.DisplayMetrics;
import android.view.KeyEvent;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.controles.CargasTextBoxScanner;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.interfaces.IAccesoSistema;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
import com.amesol.routelite.presentadores.interfaces.ICancelaPedido;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.presentadores.interfaces.ICapturaDeposito;
import com.amesol.routelite.presentadores.interfaces.ICapturaInicioFinJornada;
import com.amesol.routelite.presentadores.interfaces.ICapturaKilometraje;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovSinInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedidoSugerido;
import com.amesol.routelite.presentadores.interfaces.ICapturaPreLiquidacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotales;
import com.amesol.routelite.presentadores.interfaces.IConfiguracionTerminal;
import com.amesol.routelite.presentadores.interfaces.IConsultaCliente;
import com.amesol.routelite.presentadores.interfaces.IConsultaIndicadores;
import com.amesol.routelite.presentadores.interfaces.IConsultaInvenario;
import com.amesol.routelite.presentadores.interfaces.IConsultaPromociones;
import com.amesol.routelite.presentadores.interfaces.IConsultaUltimaVenta;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.presentadores.interfaces.IElementoCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.IImpresionTicket;
import com.amesol.routelite.presentadores.interfaces.IInicioRouteLite;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.presentadores.interfaces.INuevoCliente;
import com.amesol.routelite.presentadores.interfaces.IObtencionGPS;
import com.amesol.routelite.presentadores.interfaces.IRecepcionInformacion;
import com.amesol.routelite.presentadores.interfaces.IRegistroTiemposMuertos;
import com.amesol.routelite.presentadores.interfaces.IResumenMovVisita;
import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionAgenda;
import com.amesol.routelite.presentadores.interfaces.ISeleccionCobranza;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionVisita;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;
import com.amesol.routelite.vistas.generico.DialogoAlerta;
import com.amesol.routelite.vistas.generico.DialogoProgreso;

@SuppressLint("SimpleDateFormat")
public abstract class Vista extends FragmentActivity
{
	private DialogoProgreso mProgreso = null;
	// private static final int REQUEST_ENABLE_BT = 0;
	public static final int REQUEST_ENABLE_BT = 0;
	private BluetoothAdapter mbtAdapter = null;
	private boolean barraDeshabilitada = false;
	TextView lblTitle = null;

	// Toast exeptionMessage = new Toast(this);

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		String mensajeError = (String) getIntent().getCharSequenceExtra("error");
		if (mensajeError != null)
		{
			mostrarError(mensajeError);
			getIntent().removeExtra("mensajeIniciar");
		}

		ActionBar actionBar = getActionBar();

		actionBar.setDisplayOptions(ActionBar.DISPLAY_SHOW_CUSTOM);
		actionBar.setCustomView(R.layout.action_bar);
		lblTitle = (TextView) findViewById(R.id.lblTitle);
		lblTitle.setText("Route");
		SimpleDateFormat formato = new SimpleDateFormat("dd MMMM, yyyy");
		// String strgDate = formato.toString().substring(0, 1);
		TextView lblBottomDate = (TextView) findViewById(R.id.lblDateBottom);
		lblBottomDate.setText(formato.format(Calendar.getInstance().getTime()));
		/*
		 * Si se requiere un titulo especial en caso de bloquear la barra de
		 * notificaciones final boolean customTitleSupported =
		 * requestWindowFeature(Window.FEATURE_CUSTOM_TITLE);
		 * 
		 * if ( customTitleSupported ) {
		 * getWindow().setFeatureInt(Window.FEATURE_CUSTOM_TITLE,
		 * R.layout.titlebar); }
		 */
	}

	@Override
	public void onConfigurationChanged(Configuration newConfig)
	{
		super.onConfigurationChanged(newConfig);
		// setContentView(iLayout);
	}

	@Override
	public void onWindowFocusChanged(boolean hasFocus) // bloquear barra del
														// sistema
	{
		try
		{
			if (!hasFocus & barraDeshabilitada)
			{
				Object service = getSystemService("statusbar");
				Class<?> statusbarManager = Class.forName("android.app.StatusBarManager");
				Method collapse = statusbarManager.getMethod("collapse");
				collapse.setAccessible(true);
				collapse.invoke(service);
				/*
				 * Method collapse = statusbarManager.getMethod("disable",
				 * Integer.TYPE); collapse .setAccessible(true);
				 * collapse.invoke(service, new Integer(0x00010000));
				 */
			}
		}
		catch (Exception ex)
		{
			//			mostrarError(ex.getMessage());
		}
	}

	// display usage functions
	@SuppressWarnings("deprecation")
	public int getDisplayWidth()
	{
		return getWindowManager().getDefaultDisplay().getWidth();
	}

	@SuppressWarnings("deprecation")
	public int getDisplayHeight()
	{
		return getWindowManager().getDefaultDisplay().getWidth();
	}

	public DisplayMetrics getMetrics()
	{
		return getApplicationContext().getResources().getDisplayMetrics();
	}

	// display functions

	public void deshabilitarBarra(boolean deshabilitada)
	{
		barraDeshabilitada = deshabilitada;
	}

	public enum Accion
	{
	}

	public void setResultado(int resultado)
	{
		setResultado(resultado, null);
	}

	public void setResultado(int resultado, String mensajeIniciar)
	{
		Intent data = null;
		if (mensajeIniciar != null)
		{
			data = new Intent();
			data.putExtra("mensajeIniciar", mensajeIniciar);
		}
		int res = 0;
		switch (resultado)
		{
			case Enumeradores.Resultados.RESULTADO_BIEN:
			case Enumeradores.Resultados.RESULTADO_MAL:
			case Enumeradores.Resultados.RESULTADO_TERMINAR:
				res = resultado;
				break;
		}
		if (data != null)
			setResult(res, data);
		else
			setResult(res);
	}

	public void setResultadoParcelable(int resultado, String mensajeIniciar, Parcelable objeto)
	{
		Intent data = null;
		data = new Intent();
		if (mensajeIniciar != null)
		{
			data.putExtra("mensajeIniciar", mensajeIniciar);
		}
		data.putExtra("Objeto", objeto);
		setResult(resultado, data);
	}

	public void setTitulo(String texto)
	{
		lblTitle.setText(texto);
	}

	public void finalizar()
	{
		this.finish();
	}

	public void iniciarActividad(Class<?> vista)
	{
		iniciarActividad(vista, true);
	}

	private Intent getActividad(Class<?> vista)
	{
		Intent intent = null;
		if (vista.equals(IInicioRouteLite.class))
		{
			intent = new Intent(this, InicioRouteLite.class);
		}
		else if (vista.equals(IConfiguracionTerminal.class))
		{
			intent = new Intent(this, ConfiguracionTerminal.class);
		}
		else if (vista.equals(IAccesoSistema.class))
		{
			intent = new Intent(this, AccesoSistema.class);
		}
		else if (vista.equals(IServidorComunicaciones.class))
		{
			intent = new Intent(this, ServidorComunicaciones.class);
		}
		else if (vista.equals(ISeleccionActividadesVend.class))
		{
			intent = new Intent(this, SeleccionActividadesVend.class);
		}
		else if (vista.equals(ISolicitudAgendaVendedor.class))
		{
			intent = new Intent(this, SolicitudAgendaVendedor.class);
		}
		else if (vista.equals(IRecepcionInformacion.class))
		{
			intent = new Intent(this, RecepcionInformacion.class);
		}
		else if (vista.equals(ISeleccionAgenda.class))
		{
			intent = new Intent(this, SeleccionAgenda.class);
		}
		else if (vista.equals(IAtencionClientes.class))
		{
			intent = new Intent(this, AtencionClientes.class);
		}
		else if (vista.equals(IConsultaCliente.class))
		{
			intent = new Intent(this, ConsultaCliente.class);
		}
		else if (vista.equals(INuevoCliente.class))
		{
			intent = new Intent(this, NuevoCliente.class);
		}
		else if (vista.equals(IImpresionTicket.class))
		{
			intent = new Intent(this, ImpresionTicket.class);
		}/*
		 * else if (vista.equals(IVisitaCliente.class)){ intent = new
		 * Intent(this, VisitaCliente.class); }
		 */
		else if (vista.equals(ISeleccionVisita.class))
		{
			intent = new Intent(this, SeleccionVisita.class);
		}
		else if (vista.equals(IAutorizaMovimiento.class))
		{
			intent = new Intent(this, AutorizacionMovimiento.class);
		}
		else if (vista.equals(INoVisitaCliente.class))
		{
			intent = new Intent(this, NoVisitaCliente.class);
		}
		else if (vista.equals(ISeleccionActividadesVisita.class))
		{
			intent = new Intent(this, SeleccionActividadesVisita.class);
		}
		else if (vista.equals(IObtencionGPS.class))
		{
			intent = new Intent(this, ObtencionGPS.class);
		}
		else if (vista.equals(IResumenMovVisita.class))
		{
			intent = new Intent(this, ResumenMovVisita.class);
		}
		else if (vista.equals(IRegistroTiemposMuertos.class))
		{
			intent = new Intent(this, RegistroTiemposMuertos.class);
		}
		else if (vista.equals(IConsultaPromociones.class))
		{
			intent = new Intent(this, ConsultaPromociones.class);
		}
		else if (vista.equals(IBuscaProducto.class))
		{
			intent = new Intent(this, BuscaProducto.class);
		}
		else if (vista.equals(ISeleccionPedido.class))
		{
			intent = new Intent(this, SeleccionPedido.class);
		}
		else if (vista.equals(IAplicacionPromocion.class))
		{
			intent = new Intent(this, AplicacionPromocion.class);
		}
		else if (vista.equals(ICapturaPedido.class))
		{
			intent = new Intent(this, CapturaPedido.class);
		}
		else if (vista.equals(ICapturaTotales.class))
		{
			intent = new Intent(this, CapturaTotales.class);
		}
		else if (vista.equals(ISeleccionCobranza.class))
		{
			intent = new Intent(this, SeleccionCobranza.class);
		}
		else if (vista.equals(ICapturaCobranzaDocs.class))
		{
			intent = new Intent(this, CapturaCobranzaDocs.class);
		}
		else if (vista.equals(ICapturaCobranzaDet.class))
		{
			intent = new Intent(this, CapturaCobranzaDet.class);
		}
		else if (vista.equals(ICancelaPedido.class))
		{
			intent = new Intent(this, CancelaPedido.class);
		}
		else if (vista.equals(IConsultaIndicadores.class))
		{
			intent = new Intent(this, ConsultaIndicadores.class);
		}
		else if (vista.equals(IRevisionPendientes.class))
		{
			intent = new Intent(this, RevisionPendientes.class);
		}
		else if (vista.equals(IElementoCobranzaDet.class))
		{
			intent = new Intent(this, ElementoCobranzaDet.class);
		}
		else if (vista.equals(ICambiaProducto.class))
		{
			intent = new Intent(this, CambiaProducto.class);
		}
		else if (vista.equals(IDevolucionCliente.class))
		{
			intent = new Intent(this, DevolucionCliente.class);
		}
		else if (vista.equals(ICapturaPedidoSugerido.class))
		{
			intent = new Intent(this, CapturaPedidoSugerido.class);
		}
		else if (vista.equals(IConsultaInvenario.class))
		{
			intent = new Intent(this, ConsultaInventario.class);
		}
		else if (vista.equals(ICapturaMovSinInventario.class))
		{
			intent = new Intent(this, CapturaMovSinInventario.class);
		}
		else if (vista.equals(ICapturaPreLiquidacion.class))
		{
			intent = new Intent(this, CapturaPreLiquidacion.class);
		}
		else if (vista.equals(ICapturaMovConInventario.class))
		{
			intent = new Intent(this, CapturaMovConInventario.class);
		}
		else if (vista.equals(ICapturaDeposito.class))
		{
			intent = new Intent(this, CapturaDeposito.class);
		}
		else if (vista.equals(ICapturaKilometraje.class))
		{
			intent = new Intent(this, CapturaKilometraje.class);
		}
		else if (vista.equals(ICapturaInicioFinJornada.class))
		{
			intent = new Intent(this, CapturaInicioFinJornada.class);
		}else if(vista.equals(IConsultaUltimaVenta.class)){
			intent = new Intent(this,ConsultaUltimaVenta.class);
		}
		return intent;
	}

	public void iniciarActividad(Class<?> vista, boolean finalizar)
	{
		iniciarActividad(vista, finalizar, null);
	}

	public void iniciarActividad(Class<?> vista, String mensajeError)
	{
		iniciarActividad(vista, true, mensajeError);
	}

	public void iniciarActividad(Class<?> vista, boolean finalizar, String mensajeError)
	{
		Intent intent = getActividad(vista);
		if (mensajeError != null)
		{
			intent.putExtra("error", mensajeError);
		}
		startActivity(intent);
		if (finalizar)
		{
			finish();
		}
	}

	public void iniciarActividad(Class<?> vista, String accion, String mensajeError, boolean finalizar)
	{
		Intent intent = getActividad(vista);
		intent.setAction(accion);
		if (mensajeError != null)
		{
			intent.putExtra("error", mensajeError);
		}
		startActivity(intent);
		if (finalizar)
		{
			finish();
		}
	}

	public void iniciarActividad(Class<?> vista, String accion, String mensajeError, boolean finalizar, HashMap<?, ?> parametros)
	{
		Intent intent = getActividad(vista);
		intent.setAction(accion);
		if (mensajeError != null)
		{
			intent.putExtra("error", mensajeError);
		}
		intent.putExtra("parametros", parametros);
		startActivity(intent);
		if (finalizar)
		{
			finish();
		}
	}

	public void iniciarActividadConResultado(Class<?> vista, int codigoSolicitud, String accion)
	{
		Intent intent = getActividad(vista);
		intent.setAction(accion);
		startActivityForResult(intent, codigoSolicitud);
	}

	public void iniciarActividadConResultado(Class<?> vista, int codigoSolicitud, String accion, HashMap<?, ?> parametros)
	{
		Intent intent = getActividad(vista);
		intent.setAction(accion);
		intent.putExtra("parametros", parametros);
		startActivityForResult(intent, codigoSolicitud);
	}

	public boolean bluetoothEncendido()
	{
		mbtAdapter = null;
		mbtAdapter = BluetoothAdapter.getDefaultAdapter();
		if (mbtAdapter == null)
		{
			mostrarError("Bluetooth no soportado");
			return false;
		}
		if (!mbtAdapter.isEnabled())
		{
			return false;
		}
		return true;
	}

	public void encenderBluetooth() throws Exception
	{
		if (!(Boolean) Sesion.get(Campo.ExistenPuertosConfigurados))
		{
			throw new Exception(Mensajes.get("E0708"));
		}

		if (!bluetoothEncendido())
		{
			Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
			startActivityForResult(enableBtIntent, REQUEST_ENABLE_BT);
		}
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data)
	{
		if (txtScanner != null)
		{
			txtScanner.onActivityResult(requestCode, resultCode, data);
		}

		if (Cargastxtscanner != null)
		{
			Cargastxtscanner.onActivityResult(requestCode, resultCode, data);
		}
		resultadoActividad(requestCode, resultCode, data);
	}

	TextBoxScanner txtScanner;
	CargasTextBoxScanner Cargastxtscanner;

	public void setControlScanner(TextBoxScanner txtscanner)
	{
		txtScanner = txtscanner;
	}

	public void setControlScanner(CargasTextBoxScanner txtscanner)
	{
		Cargastxtscanner = txtscanner;

	}

	public abstract void resultadoActividad(int requestCode, int resultCode, Intent data);

	public void mostrarError(String mensaje)
	{
		mostrarMensaje(mensaje, null);
	}

	public void mostrarAdvertencia(String mensaje)
	{
		mostrarMensaje(mensaje, null);
	}

	@SuppressWarnings("deprecation")
	private void mostrarMensaje(final String mensaje, final Integer icono)
	{
		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage(mensaje);
		String msgSi = "Si";
		if (Mensajes.existe())
		{
			msgSi = Mensajes.get("XAceptar");
		}
		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.OK, 0);
				dialog.dismiss();
			}
		});
		if (icono != null)
			dialogo.setIcon(icono);

		dialogo.setCancelable(false);
		dialogo.setCanceledOnTouchOutside(false);
		dialogo.show();
	}

	@SuppressWarnings("deprecation")
	public void mostrarPreguntaSiNo(String mensaje, final int tipoMensaje)
	{
		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage(mensaje);
		dialogo.setCancelable(false);
		String msgSi = "Si";
		String msgNo = "No";
		if (Mensajes.existe())
		{
			msgSi = Mensajes.get("XSi");
			msgNo = Mensajes.get("XNo");
		}
		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.Si, tipoMensaje);
				dialog.dismiss();
			}
		});
		dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.No, tipoMensaje);
				dialog.cancel();
			}
		});
		dialogo.show();
	}

	public abstract void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje);

	public void mostrarProgreso(String mensaje)
	{
		mostrarProgreso(mensaje, "", null, null);
	}

	public void mostrarProgreso(String mensaje, Boolean cancelar)
	{
		mostrarProgreso(mensaje, "", null, cancelar);
	}

	public void mostrarProgreso(String mensaje, String titulo)
	{
		mostrarProgreso(mensaje, titulo, null, null);
	}

	public void mostrarProgreso(String mensaje, String titulo, Boolean cancelar)
	{
		mostrarProgreso(mensaje, titulo, null, cancelar);
	}

	public void mostrarProgreso(String mensaje, Integer avanceTotal)
	{
		mostrarProgreso(mensaje, "", avanceTotal, null);
	}

	public void mostrarProgreso(String mensaje, Integer avanceTotal, Boolean cancelar)
	{
		mostrarProgreso(mensaje, "", avanceTotal, cancelar);
	}

	public void mostrarProgreso(final String mensaje, String titulo, Integer avanceTotal)
	{
		mostrarProgreso(mensaje, titulo, avanceTotal, null);
	}

	public void mostrarProgreso(final String mensaje, String titulo, Integer avanceTotal, Boolean cancelar)
	{
		if (mProgreso != null)
		{
			if (mProgreso.isShowing())
				mProgreso.dismiss();
			mProgreso = null;
		}
		mProgreso = new DialogoProgreso(Vista.this);
		mProgreso.setTitle(titulo);
		mProgreso.setMessage(mensaje);
		if (cancelar != null)
			mProgreso.setCancelable(cancelar);
		else
			mProgreso.setCancelable(false);
		if (avanceTotal == null)
			mProgreso.setIndeterminate(true);
		else
		{
			mProgreso.setIndeterminate(false);
			mProgreso.setProgressStyle(DialogoProgreso.STYLE_HORIZONTAL);
			mProgreso.setMax(avanceTotal);
		}
		try
		{
			mProgreso.show();
		}
		catch (Throwable e)
		{

		}

	}

	public void actualizarProgreso(String mensaje)
	{
		actualizarProgreso(mensaje, null);
	}

	public void actualizarProgreso(Integer avance)
	{
		actualizarProgreso(null, avance);
	}

	public void actualizarProgreso(final String mensaje, final Integer avance)
	{
		runOnUiThread(new Runnable()
		{
			public void run()
			{
				if (mProgreso != null)
				{
					if (mensaje != null)
						mProgreso.setMessage(mensaje);
					if (avance != null)
						mProgreso.setProgress(avance);
				}
			}
		});
	}

	public void quitarProgreso()
	{
		if (mProgreso != null)
		{
			if (mProgreso.isShowing())
				mProgreso.dismiss();
			mProgreso = null;
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_HOME:
			case KeyEvent.KEYCODE_BACK:
			case KeyEvent.KEYCODE_CALL:
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public void doevents()
	{
	}

	@Override
	public void onDestroy()
	{
		if (mbtAdapter != null)
		{
			if (mbtAdapter.isDiscovering())
				mbtAdapter.cancelDiscovery();
			if (mbtAdapter.isEnabled())
				mbtAdapter.disable();
		}
		super.onDestroy();
	}

}
