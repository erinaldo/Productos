package com.amesol.routelite.vistas;

import java.io.File;
import java.lang.reflect.Method;
import java.util.Enumeration;
import java.util.Hashtable;

import android.bluetooth.BluetoothAdapter;
import android.content.BroadcastReceiver;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Impresion;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Recibos.PrintException;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.vistas.generico.DialogoAlerta;
import com.amesol.routelite.vistas.generico.DialogoProgreso;

public class PDFViewer extends cx.hell.android.pdfview.OpenFileActivity{	 
	
	private MenuItem mnuImprimir;
	private Hashtable<String,ContentValues> archivosGenerados = new Hashtable<String,ContentValues>();
	private Vista vista;
	private int idReporte;

	
	@Override
    public void onCreate(Bundle savedInstanceState) {
		idReporte = getIntent().getIntExtra("idReporte", 0);
		switch (idReporte)
		{
			case 5:
			case Enumeradores.REPORTEA.COBRANZA_GONAC:
                int orientacion  = getIntent().getIntExtra("orientacion", 0);
				setRequestedOrientation(orientacion);
				break;

			default:
				setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
		}
		super.onCreate(savedInstanceState);
		//this.setResources(zoomAnimations, pageNumberAnimations, zoomUpId, zoomDownId, zoomWidthId);
		
		//recuperar el hashmap de los archivos generados para poder imprimir
		//Intent intent = getIntent();
		//archivosGenerados = (Hashtable<String, ContentValues>) intent.getSerializableExtra("archivos");
		archivosGenerados = (Hashtable<String, ContentValues>) Sesion.get(Campo.ArchivosGenerados);
		
		if(getIntent().hasExtra("titulo"))
		{
			getActionBar().setTitle(getIntent().getStringExtra("titulo"));
		}
	}
	
	@Override
	public void onDestroy()
	{
		if (mbtAdapter != null)
		{
			if (mbtAdapter.isDiscovering())
				mbtAdapter.cancelDiscovery();
			if (Boolean.parseBoolean( ((ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal)).get(CampoConfiguracion.BLUETOOTH).toString())){
				if (mbtAdapter.isEnabled())
					mbtAdapter.disable();
			}
		}
		super.onDestroy();
	}

	@Override
    public boolean onCreateOptionsMenu(Menu menu) {
		super.onCreateOptionsMenu(menu);
    	if(idReporte == -1 || idReporte == 6) return false;
		if(idReporte != 5)
			this.mnuImprimir = menu.add(Mensajes.get("XImprimir"));
		
		if(idReporte == 2 || idReporte == 5){
			menu.add(/*Mensajes.get("XImprimirCarta")*/ "Imprimir Carta" );
		}
		
    	/*this.gotoPageMenuItem = menu.add(R.string.goto_page);
    	this.rotateRightMenuItem = menu.add(R.string.rotate_page_left);
    	this.rotateLeftMenuItem = menu.add(R.string.rotate_page_right);
    	this.clearFindTextMenuItem = menu.add(R.string.clear_find_text);
    	this.chooseFileMenuItem = menu.add(R.string.choose_file);
    	this.optionsMenuItem = menu.add(R.string.options);		
    	this.findTextMenuItem = menu.add(R.string.find_text);
    	this.aboutMenuItem = menu.add(R.string.about);*/
    	
    	return true;
	}
	
	@Override
    public boolean onOptionsItemSelected(MenuItem menuItem) {
		/*if (menuItem == this.aboutMenuItem) {
			Intent intent = new Intent();
			intent.setClass(this, AboutPDFViewActivity.class);
			this.startActivity(intent);
    		return true;
    	} else if (menuItem == this.gotoPageMenuItem) {
    		this.showGotoPageDialog();
    	} else if (menuItem == this.rotateLeftMenuItem) {
    		this.pagesView.rotate(-1);
    	} else if (menuItem == this.rotateRightMenuItem) {
    		this.pagesView.rotate(1);
    	} else if (menuItem == this.findTextMenuItem) {
    		this.showFindDialog();
    	} else if (menuItem == this.clearFindTextMenuItem) {
    		this.clearFind();
    	} else if (menuItem == this.chooseFileMenuItem) {
    		startActivity(new Intent(this, ChooseFileActivity.class));
    	} else if (menuItem == this.optionsMenuItem) {
    		startActivity(new Intent(this, Options.class));
		}*/
		if(menuItem == this.mnuImprimir){
			try{
				imprimir();
			}catch(Exception e){
				mostrarMensaje(e.getMessage());
				e.printStackTrace();
			}
		}else{
			try{
				ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
				String puerto = (String) config.get(CampoConfiguracion.PUERTO + "_12");

				if (puerto == null)
				{
					throw new Exception(Mensajes.get("E0708"));
				}
				imprimirCarta(puerto);
			}catch(Exception e){
				mostrarMensaje(e.getMessage());
			}
		}
    	return false;
	}
	
	private void imprimir() throws PrintException, Exception{
		if (!bluetoothEncendido())
			encenderBluetooth();
		else
			imprimirTicket();
	}
	
	private void imprimirCarta(String puerto) throws Exception{
		StringBuilder byRefMsgError = new StringBuilder();
		//String archivo = Recibos.ImprimirReporteCosteña(byRefMsgError, 1);
		Impresion impresion = new Impresion(puerto);
		
		impresion.imprimirArchivos(idReporte, this, (short)1);
	}
	
	private void imprimirTicket() throws Exception{
		StringBuilder byRefMsgError = new StringBuilder();
		//String archivo = Recibos.ImprimirReporteCosteña(byRefMsgError, 1);
		Recibos recibos = new Recibos(this);
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		impresion = new File(impresion, "impresion");
		/*ContentValues valoresRecibo = new ContentValues();
		valoresRecibo.put("TipoPapel", ((Vendedor)Sesion.get(Campo.VendedorActual)).TipoModImp);
		valoresRecibo.put("MostrarLogo", false);
		Hashtable<String,ContentValues> archivos = new Hashtable<String, ContentValues>();
		archivos.put(archivo, valoresRecibo);
		recibos.imprimirArchivos(archivos, impresion, null, (short)1);*/
		
		recibos.imprimirArchivos(archivosGenerados, impresion, null, (short)1);
	}
	
	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK){
				try{
					imprimirTicket();
				}
				catch (PrintException e){
					mostrarMensaje(e.getMessage());
					e.printStackTrace();
				}
				catch (Exception e){
					mostrarMensaje(e.getMessage());
					e.printStackTrace();
				}
			}	
		}
	}
	
	@SuppressWarnings("deprecation")
	public void mostrarMensaje(final String mensaje)
	{
		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage(mensaje);
		String msgSi = "Si";
		if (Mensajes.existe())
			msgSi = Mensajes.get("XAceptar");

		dialogo.setButton(msgSi, new DialogInterface.OnClickListener(){
			public void onClick(DialogInterface dialog, int id){
				dialog.dismiss();
			}
		});

		dialogo.setCancelable(false);
		dialogo.setCanceledOnTouchOutside(false);
		dialogo.show();
	}
	
	@Override
	public void onWindowFocusChanged(boolean hasFocus) // bloquear barra del sistema
	{
		try{
			if (!hasFocus){
				Object service = getSystemService("statusbar");
				Class<?> statusbarManager = Class.forName("android.app.StatusBarManager");
				Method collapse = statusbarManager.getMethod("collapse");
				collapse.setAccessible(true);
				collapse.invoke(service);
			}
		}
		catch (Exception ex){ }
	}
	
	//******************************* BT ***************************************
	private BluetoothAdapter mbtAdapter = null;
	public static final int REQUEST_ENABLE_BT = 500;
	
	public boolean bluetoothEncendido()
	{
		mbtAdapter = null;
		mbtAdapter = BluetoothAdapter.getDefaultAdapter();
		if (mbtAdapter == null)
		{
			mostrarMensaje("Bluetooth no soportado");
			return false;
		}
		if (!mbtAdapter.isEnabled())
			return false;

		return true;
	}
	
	public boolean encenderBluetooth() throws Exception
	{
		if (!(Boolean) Sesion.get(Campo.ExistenPuertosConfigurados))
		{
			throw new Exception(Mensajes.get("E0708"));
		}
		boolean enable = true;
		if (!bluetoothEncendido())
		{
			
			enable = mbtAdapter.enable();
			if(enable){
				IntentFilter filter = new IntentFilter(BluetoothAdapter.ACTION_STATE_CHANGED);
				registerReceiver(mReceiverBT, filter);
			}
		}
		return enable;
	}
	
	private DialogoProgreso mProgreso = null;
	
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
		            	onActivityResult(REQUEST_ENABLE_BT, RESULT_OK, null);
		                break;
		            case BluetoothAdapter.STATE_TURNING_ON:
		                mostrarProgreso("Activando Bluetooth...");
		                break;
	                default:
	                	unregisterReceiver(mReceiverBT);
	                	quitarProgreso();
	                	onActivityResult(REQUEST_ENABLE_BT, RESULT_CANCELED, null);
		                	
	            }
	        }
	    }
	};
	
	public void mostrarProgreso(String mensaje)
	{
		mostrarProgreso(mensaje, "", null, null);
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
	
	public void mostrarProgreso(final String mensaje, String titulo, Integer avanceTotal, Boolean cancelar)
	{
		if (mProgreso != null)
		{
			if (mProgreso.isShowing())
				mProgreso.dismiss();
			mProgreso = null;
		}
		mProgreso = new DialogoProgreso(this);
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
}
