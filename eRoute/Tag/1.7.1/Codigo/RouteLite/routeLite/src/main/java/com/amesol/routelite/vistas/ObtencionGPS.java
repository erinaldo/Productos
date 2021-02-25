package com.amesol.routelite.vistas;

import android.content.Context;
import android.content.Intent;
import android.location.LocationManager;
import android.os.Bundle;
import android.provider.Settings;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.AccederSistema;
import com.amesol.routelite.presentadores.act.ObtenerGPS;
import com.amesol.routelite.presentadores.interfaces.IAccesoSistema;
import com.amesol.routelite.presentadores.interfaces.IInicioRouteLite;
import com.amesol.routelite.presentadores.interfaces.IObtencionGPS;
import com.amesol.routelite.vistas.utilerias.mylocationlistenerGPS;

public class ObtencionGPS extends Vista implements IObtencionGPS  {

	ObtenerGPS mPresenta;
	ProgressBar pbGPS ;
	TextView lblStatusGPS;
	 LocationManager lm ;
	 mylocationlistenerGPS ll;
	
		@Override 
		public void onCreate(Bundle savedInstanceState){
			super.onCreate(savedInstanceState);

			setContentView(R.layout.gps);
			deshabilitarBarra(true);
			 pbGPS = (ProgressBar)findViewById(R.id.pbGPS);
			 lblStatusGPS = (TextView)findViewById(R.id.lblStatusGPS);
			 lblStatusGPS.setText(Mensajes.get("XConectado"));
			 pbGPS.setMax(100);
			 LocationManager lm = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
			  
			mPresenta = new ObtenerGPS(ObtencionGPS.this,lm);
			mPresenta.iniciar();
		}
		
	 
	
	public void iniciar() {
			

	}
	
	/* 	NO FUNCIONA, SOLO MUESTRA EL ICONO PERO NO SE ENCIENDE
	 * public void EncenderGPS(){
		Intent intent = new Intent("android.location.GPS_ENABLED_CHANGE");
        intent.putExtra("enabled", true);
        sendBroadcast(intent);
	}
	
	public void ApagarGPS(){
		Intent intent = new Intent("android.location.GPS_ENABLED_CHANGE");
        intent.putExtra("enabled", false);
        sendBroadcast(intent);
	}*/
	
	/*public void HabilitarWiFi(boolean habilitado){
		try {
			Dispositivo.EncenderApagarWiFi(this, habilitado, 4);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}*/
	
	public void mostrarConfiguracionGPS(){
		//startActivity(new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS));
		
		/*Object service  = getSystemService("statusbar");
        Class<?> statusbarManager = Class.forName("android.app.StatusBarManager");
        Method collapse = statusbarManager.getMethod("collapse");
        collapse.setAccessible(true);
        collapse.invoke(service);*/
		
		/*try
        {			
			Object service  = getSystemService("location");
	        Class<?> statusbarManager = Class.forName("android.location.LocationManager");
	        //Class<?> gpsProvider = Class.forName("com.android.internal.location.GpsLocationProvider");
	        Class<?> gpsProvider = Class.forName("com.android.server.location.GpsLocationProvider");
	        Method collapse = statusbarManager.getMethod("enable");
	        collapse.setAccessible(true);
	        collapse.invoke(service);
        }catch(Exception e){
        	e.printStackTrace();
        }*/
		
		mostrarPreguntaSiNo(Mensajes.get("P0236"), 99);
	}
	

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data) {
		// TODO Auto-generated method stub
		if(requestCode == 99){
			mPresenta.IniciarTodo();
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
	
		if(tipoMensaje==1)
		{
			if(respuesta==RespuestaMsg.Si)
			{
				mPresenta.IniciarGPS();
				mPresenta.IniciarTimer();
				pbGPS.setProgress(0);
				
			}
			else
			{
				//HabilitarWiFi(false);
				mPresenta.RegresarTimeOut();

			}
		}else if(tipoMensaje == 99){
			if(respuesta == RespuestaMsg.Si){
				startActivityForResult(new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS), 99);
			}else{
				//HabilitarWiFi(true);
				//mPresenta.RegresarTimeOut();
                iniciarActividad(IAccesoSistema.class,true);
			}
		}
	}


	@Override
	public void SetProgreso(Integer Pro) {
	
		pbGPS.setProgress(100-Pro);
	}


	@Override
	public void SetDatos(String Datos) {
		lblStatusGPS.setText(Datos);
		
	}

}
