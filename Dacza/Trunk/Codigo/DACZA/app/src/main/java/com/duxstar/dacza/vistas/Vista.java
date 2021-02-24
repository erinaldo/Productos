package com.duxstar.dacza.vistas;

import java.io.File;
import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Hashtable;

import android.annotation.SuppressLint;
import android.app.ActionBar;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.BroadcastReceiver;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.res.Configuration;
import android.os.Bundle;
import android.os.Parcelable;
import android.support.v4.app.FragmentActivity;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.KeyEvent;
import android.widget.TextView;
import android.widget.Toast;

import com.duxstar.dacza.R;
import com.duxstar.dacza.controles.AgenteTextBoxScanner;
import com.duxstar.dacza.controles.TextBoxScanner;
import com.duxstar.dacza.controles.VinTextBoxScanner;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.IVista;
import com.duxstar.dacza.presentadores.interfaces.IAccesoSistema;
import com.duxstar.dacza.presentadores.interfaces.IBuscaAgente;
import com.duxstar.dacza.presentadores.interfaces.IBuscaArticulo;
import com.duxstar.dacza.presentadores.interfaces.IBuscaCliente;
import com.duxstar.dacza.presentadores.interfaces.IBuscaVin;
import com.duxstar.dacza.presentadores.interfaces.ICapturaArticuloOrden;
import com.duxstar.dacza.presentadores.interfaces.ICapturaDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ICapturaOrden;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.presentadores.interfaces.IConfiguracionTerminal;
import com.duxstar.dacza.presentadores.interfaces.IConsultaCliente;
import com.duxstar.dacza.presentadores.interfaces.IConsultaInvenario;
import com.duxstar.dacza.presentadores.interfaces.IConsultaOrden;
import com.duxstar.dacza.presentadores.interfaces.IConsultaTraspaso;
import com.duxstar.dacza.presentadores.interfaces.IInicioDacza;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionActividades;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionFecha;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionOrden;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionRecarga;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.vistas.generico.DialogoAlerta;
import com.duxstar.dacza.vistas.generico.DialogoProgreso;

@SuppressLint("SimpleDateFormat")
public abstract class Vista extends FragmentActivity
{
	private DialogoProgreso mProgreso = null;
	// private static final int REQUEST_ENABLE_BT = 0;
	public static final int REQUEST_ENABLE_BT = 500;
	private BluetoothAdapter mbtAdapter = null;
	private boolean barraDeshabilitada = false;
	TextView lblTitle = null;
    //protected EnvioEmail envioEmail;

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
		lblTitle.setText("DACZA");
		SimpleDateFormat formato = new SimpleDateFormat("dd MMMM, yyyy");
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
            case Enumeradores.Resultados.RESULTADO_ENVIAR:
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
		if (vista.equals(IInicioDacza.class))
			intent = new Intent(this, InicioDacza.class);
		else if (vista.equals(IConfiguracionTerminal.class))
		    intent = new Intent(this, ConfiguracionTerminal.class);
		else if (vista.equals(IAccesoSistema.class))
			intent = new Intent(this, AccesoSistema.class).addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
//		else if (vista.equals(IServidorComunicaciones.class))
//			intent = new Intent(this, ServidorComunicaciones.class);
		else if (vista.equals(ISeleccionActividades.class))
			intent = new Intent(this, SeleccionActividades.class);
		else if (vista.equals(ISeleccionOrden.class))
			intent = new Intent(this, SeleccionOrden.class);
		else if (vista.equals(IConsultaInvenario.class))
			intent = new Intent(this, ConsultaInventario.class);
        else if (vista.equals(ICapturaOrden.class))
            intent = new Intent(this, CapturaOrden.class);
        else if (vista.equals(ISeleccionRecarga.class))
            intent = new Intent(this, SeleccionRecarga.class);
        else if (vista.equals(IBuscaCliente.class))
            intent = new Intent(this, BuscaCliente.class);
        else if (vista.equals(IBuscaAgente.class))
            intent = new Intent(this, BuscaAgente.class);
        else if (vista.equals(IBuscaVin.class))
            intent = new Intent(this, BuscaVin.class);
        else if (vista.equals(IConsultaCliente.class))
            intent = new Intent(this, ConsultaCliente.class);
        else if (vista.equals(ICapturaArticuloOrden.class))
            intent = new Intent(this, CapturaArticuloOrden.class);
        else if (vista.equals(IBuscaArticulo.class))
            intent = new Intent(this, BuscaArticulo.class);
        else if (vista.equals(ICapturaRecarga.class))
            intent = new Intent(this, CapturaRecarga.class);
        else if (vista.equals(IConsultaOrden.class))
            intent = new Intent(this, ConsultaOrden.class);
        else if (vista.equals(IConsultaTraspaso.class))
            intent = new Intent(this, ConsultaTraspaso.class);
        else if (vista.equals(ISeleccionDevolucion.class))
            intent = new Intent(this, SeleccionDevolucion.class);
        else if (vista.equals(ICapturaDevolucion.class))
            intent = new Intent(this, CapturaDevolucion.class);
        else if (vista.equals(IServidorComunicaciones.class))
            intent = new Intent(this, ServidorComunicaciones.class);
        else if (vista.equals(ISeleccionFecha.class))
            intent = new Intent(this, SeleccionFecha.class);

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

//	public boolean encenderBluetooth() throws Exception
//	{
//		if (!(Boolean) Sesion.get(Campo.ExistenPuertosConfigurados))
//		{
//			throw new Exception(Mensajes.get("E0708"));
//		}
//		boolean enable = true;
//		if (!bluetoothEncendido())
//		{
//
//			enable = mbtAdapter.enable();
//			if(enable){
//				IntentFilter filter = new IntentFilter(BluetoothAdapter.ACTION_STATE_CHANGED);
//				registerReceiver(mReceiverBT, filter);
//			}
//		}
//		return enable;
//	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data)
	{
        if (Sesion.get(Sesion.Campo.TipoCodigoActual) != null) {
            int tipoCodigo = (int) Sesion.get(Sesion.Campo.TipoCodigoActual);
            if (txtScanner != null && (tipoCodigo == Enumeradores.TIPOCODIGO.CLIENTE || tipoCodigo == Enumeradores.TIPOCODIGO.ARTICULO)) {
                txtScanner.onActivityResult(requestCode, resultCode, data);
            }

            if (txtScannerAgente != null && tipoCodigo == Enumeradores.TIPOCODIGO.AGENTE) {
                txtScannerAgente.onActivityResult(requestCode, resultCode, data);
            }

            if (txtScannerVin != null && tipoCodigo == Enumeradores.TIPOCODIGO.VIN) {
                txtScannerVin.onActivityResult(requestCode, resultCode, data);
            }
        }

        resultadoActividad(requestCode, resultCode, data);
	}

	TextBoxScanner txtScanner;
	AgenteTextBoxScanner txtScannerAgente;
    VinTextBoxScanner txtScannerVin;

	public void setControlScanner(TextBoxScanner txtscanner)
	{
		txtScanner = txtscanner;
	}

    public void setControlScanner(AgenteTextBoxScanner txtscanner)
    {
        txtScannerAgente = txtscanner;
    }

    public void setControlScanner(VinTextBoxScanner txtscanner)
    {
        txtScannerVin = txtscanner;
    }

    public abstract void resultadoActividad(int requestCode, int resultCode, Intent data);

	public void mostrarError(String mensaje)
	{
		mostrarMensaje(mensaje, null,0);
	}

    public void mostrarError(String mensaje, Integer tipoMensaje)
    {
        mostrarMensaje(mensaje, null,tipoMensaje);
    }

	public void mostrarAdvertencia(String mensaje)
	{
		mostrarMensaje(mensaje, null,0);
	}

	public void mostrarToast(String mensaje){
		Toast.makeText(this, mensaje, Toast.LENGTH_LONG).show();
	}

	@SuppressWarnings("deprecation")
	private void mostrarMensaje(final String mensaje, final Integer icono, final Integer tipoMensaje)
	{
		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage(mensaje);
		String msgSi = "Aceptar";
//		if (Mensajes.existe())
//		{
//			msgSi = Mensajes.get("XAceptar");
//		}
		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.OK, tipoMensaje);
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
//		if (Mensajes.existe())
//		{
//			msgSi = Mensajes.get("XSi");
//			msgNo = Mensajes.get("XNo");
//		}
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
	
//	@SuppressWarnings("deprecation")
//	public void mostrarPreguntaReintentarImpresion(String mensaje, final Hashtable<String, ContentValues> archivosAImprimir, final File impresion, final int numeroCopias){
//		DialogoAlerta dialogo = new DialogoAlerta(this);
//		dialogo.setMessage(mensaje);
//		dialogo.setCancelable(false);
//		String msgSi = "Si";
//		String msgNo = "No";
//		if (Mensajes.existe())
//		{
//			msgSi = Mensajes.get("XSi");
//			msgNo = Mensajes.get("XNo");
//		}
//		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
//		{
//			public void onClick(DialogInterface dialog, int id)
//			{
//				dialog.dismiss();
//				reintentaImpresion(archivosAImprimir, impresion, numeroCopias);
//			}
//		});
//		dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
//		{
//			public void onClick(DialogInterface dialog, int id)
//			{
//				dialog.cancel();
//				impresionFinalizada(false,"");
//			}
//		});
//		dialogo.show();
//	}
//
//	@SuppressWarnings("deprecation")
//	public void mostrarPreguntaReintentarConexionImpresora(String mensaje, final btPrintFile btPrintService, final BluetoothDevice device, final boolean[]intentosConexion){
//		DialogoAlerta dialogo = new DialogoAlerta(this);
//		dialogo.setMessage(mensaje);
//		dialogo.setCancelable(false);
//		String msgSi = "Si";
//		String msgNo = "No";
//		if (Mensajes.existe())
//		{
//			msgSi = Mensajes.get("XSi");
//			msgNo = Mensajes.get("XNo");
//		}
//		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
//		{
//			public void onClick(DialogInterface dialog, int id)
//			{
//				dialog.dismiss();
//				if (device != null){
//		        	if (device.getBondState() != BluetoothDevice.BOND_BONDED)
//		  	        {
//		        		try{
//			  				 Method m = device.getClass()
//			  					        .getMethod("createBond", (Class[]) null);
//			  					    m.invoke(device, (Object[]) null);
//
//			  	           Thread.sleep(3000);
//		        		}catch(Exception ex){
//		        			Toast.makeText(getApplicationContext(), ex.getMessage(), Toast.LENGTH_LONG).show();
//		        		}
//		  	        }
//				}
//				intentosConexion[0] = true;
//				btPrintService.connect(device);
//			}
//		});
//		dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
//		{
//			public void onClick(DialogInterface dialog, int id)
//			{
//				dialog.cancel();
//				if (btPrintService != null){
//					btPrintService.stop();
//				}
//
//				impresionFinalizada(false,"");
//			}
//		});
//		dialogo.show();
//	}
//
//	public void vincularImpresora(String MACAdress, final Hashtable<String, ContentValues> archivosAImprimir, final File impresion) throws Exception{
//
//		/*if (mbtAdapter == null){
//			mbtAdapter = BluetoothAdapter.getDefaultAdapter();
//		}
//		BluetoothDevice dispositivo = mbtAdapter.getRemoteDevice(MACAdress);
//		//BluetoothSocket mmSocket = dispositivo.createRfcommSocketToServiceRecord(BluetoothChatService.MY_UUID);
//		Method m = dispositivo.getClass().getMethod("createRfcommSocket", new Class[]
//				{ int.class });
//				BluetoothSocket mmSocket = (BluetoothSocket) m.invoke(dispositivo, 1);
//		try
//		{
//			// Connect the device through the socket. This will block
//			// until it succeeds or throws an exception
//			mmSocket.connect();
//		}
//		catch (Exception connectException)
//		{
//			throw connectException;
//
//		}
//		finally
//		{
//			try
//			{
//				mmSocket.close();
//			}
//			catch (Exception closeException)
//			{
//				throw closeException;
//			}
//		}
//		if(dispositivo.getBondState() != BluetoothDevice.BOND_BONDED){
//			reintentaImpresion(archivosAImprimir, impresion);
//		}else{
//			mostrarPreguntaReintentarImpresion("\n¿Deseas intentar de nuevo?", archivosAImprimir, impresion);
//		}*/
//	}
	
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
	
//	protected void reintentaImpresion(Hashtable<String, ContentValues> archivosAImprimir, File impresion, int numeroCopias){
//		try{
//			new Recibos().imprimirArchivos(archivosAImprimir, impresion, (IVista) this, (short)numeroCopias);
//		}catch(Exception ex){
//			mostrarError(ex.getMessage());
//			impresionFinalizada(false,"");
//		}
//	}
	
//	/**
//	 * Este método será ejecutado al finalizar la impresion, las actividades que esten
//	 * relacionadas con una acción de impresion deberán sobre escribir este método.
//	 * Se deja la definicion del método para no agregarla a todas las actividades ya
//	 * que no todas requieren impresion.
//	 * @param impresionExitosa true en caso que se hayan impreso todos los documentos,
//	 * false en caso contrario
//	 * @exception La excepcion será lanzada si ejecutaste un impresion desde la
//	 * actividad y no sobre escribiste.
//	 */
//	public void impresionFinalizada(boolean impresionExitosa,String mensajeError){
//		throw new UnsupportedOperationException("Este método se debe sobre escribir en las actividades que imprimen");
//	}
//
//	public void mostrarPromocionProducto(String promocionClave, String promocionReglaID, int CantidadGrupoApp, String SubEmpresaId, int cantidad){
//
//	}
//
//	public void mostrarObligatorio(String mensaje, final int tipoMensaje, String...titulo){
//
//	}

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
//			if (Boolean.parseBoolean( ((ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal)).get(CampoConfiguracion.BLUETOOTH).toString())){
//				if (mbtAdapter.isEnabled())
//					mbtAdapter.disable();
//			}
		}
		super.onDestroy();
	}
	
	protected final BroadcastReceiver mReceiverBT = new BroadcastReceiver() {
	    @Override
	    public void onReceive(Context context, Intent intent) {
	        final String action = intent.getAction();

	        if (action.equals(BluetoothAdapter.ACTION_STATE_CHANGED)) {
	            final int state = intent.getIntExtra(BluetoothAdapter.EXTRA_STATE,
	                                                 BluetoothAdapter.ERROR);
	            switch (state) {
		            case BluetoothAdapter.STATE_ON:
		            	unregisterReceiver(mReceiverBT);
		            	quitarProgreso();
		                resultadoActividad(REQUEST_ENABLE_BT, RESULT_OK, null);
		                break;
		            case BluetoothAdapter.STATE_TURNING_ON:
		                mostrarProgreso("Activando Bluetooth...");
		                break;
	                default:
	                	unregisterReceiver(mReceiverBT);
	                	quitarProgreso();
	                	resultadoActividad(REQUEST_ENABLE_BT, RESULT_CANCELED, null);
		                	
	            }
	        }
	    }
	};
	
}
