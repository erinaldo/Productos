package com.amesol.routelite.vistas;

import java.io.File;
import java.lang.reflect.Method;
import java.util.Enumeration;
import java.util.Hashtable;

import android.bluetooth.BluetoothAdapter;
import android.content.ContentValues;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Recibos.PrintException;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.vistas.generico.DialogoAlerta;

public class PDFViewer extends cx.hell.android.pdfview.OpenFileActivity{	 
	
	private MenuItem mnuImprimir;
	private Hashtable<String,ContentValues> archivosGenerados = new Hashtable<String,ContentValues>();
	private Vista vista;
	
	@Override
    public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		//this.setResources(zoomAnimations, pageNumberAnimations, zoomUpId, zoomDownId, zoomWidthId);
		
		//recuperar el hashmap de los archivos generados para poder imprimir
		//Intent intent = getIntent();
		//archivosGenerados = (Hashtable<String, ContentValues>) intent.getSerializableExtra("archivos");
		archivosGenerados = (Hashtable<String, ContentValues>) Sesion.get(Campo.ArchivosGenerados);
	}

	@Override
    public boolean onCreateOptionsMenu(Menu menu) {
		super.onCreateOptionsMenu(menu);
    	
		this.mnuImprimir = menu.add(Mensajes.get("XImprimir"));
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
		}
    	return false;
	}
	
	private void imprimir() throws PrintException, Exception{
		if (!bluetoothEncendido())
			encenderBluetooth();
		else
			imprimirTicket();
	}
	
	private void imprimirTicket() throws Exception{
		StringBuilder byRefMsgError = new StringBuilder();
		String archivo = Recibos.ImprimirReporteCosteña(byRefMsgError, 1);
		Recibos recibos = new Recibos();
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		File impresion = new File(conf.get(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		impresion = new File(impresion, "impresion");
		ContentValues valoresRecibo = new ContentValues();
		valoresRecibo.put("TipoPapel", ((Vendedor)Sesion.get(Campo.VendedorActual)).TipoModImp);
		valoresRecibo.put("MostrarLogo", false);
		Hashtable<String,ContentValues> archivos = new Hashtable<String, ContentValues>();
		archivos.put(archivo, valoresRecibo);
		recibos.imprimirArchivos(archivos, impresion, null, (short)1);
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
	private void mostrarMensaje(final String mensaje)
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
	public static final int REQUEST_ENABLE_BT = 0;
	
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

	public void encenderBluetooth() throws Exception
	{
		if (!(Boolean) Sesion.get(Campo.ExistenPuertosConfigurados))
			throw new Exception(Mensajes.get("E0708"));

		if (!bluetoothEncendido()){
			Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
			startActivityForResult(enableBtIntent, REQUEST_ENABLE_BT);
		}
	}
}
