package com.amesol.routelite.vistas.utilerias;

import java.util.Formatter;
import java.util.UUID;

import com.amesol.routelite.presentadores.IVista;

import android.content.Context;
import android.content.pm.PackageManager.NameNotFoundException;
import android.net.wifi.WifiConfiguration;
import android.net.wifi.WifiManager;
import android.os.Build;
import android.provider.Settings;
import android.provider.Settings.Secure;


public class Dispositivo {

	public static String obtenerNombreVersion(IVista vista){
		String version = "";
		Context contexto = (Context)vista;
		try {
			version = contexto.getPackageManager().getPackageInfo(contexto.getPackageName(), 0 ).versionName;
		} catch (NameNotFoundException e) {
			e.printStackTrace();
		}
		return version;
	}
	
	public static String obtenerNumeroSerie(IVista vista){
		Context contexto = (Context)vista;
		 String androidId = Secure.getString(contexto.getContentResolver(), Secure.ANDROID_ID);

		if (androidId.length() <20){
			androidId = String.format("%20s", androidId).replace(' ', '0');
		}	
		return androidId;
	}
	
	public static String obtenerNombre(){
		final String deviceName =android.os.Build.ID;
		return deviceName;
	}
	
	public static UUID obtenerUUID(IVista vista){
		String id = obtenerNumeroSerie(vista);
		/*String uuid = "";
		for(Byte b:id.getBytes()){
			uuid += b.toString();
		}*/
		return UUID.nameUUIDFromBytes(id.getBytes());
	}
	

	public static void EncenderApagarWiFi(IVista vista, boolean enabled, int intentos) throws Exception{
		Context contexto = (Context) vista;

		WifiManager wifiManager = (WifiManager) contexto.getSystemService(Context.WIFI_SERVICE);   
		  if(wifiManager.isWifiEnabled() ){   
			  if (!enabled)
				  wifiManager.setWifiEnabled(false);
		  }else{ 
			if (enabled){  
				wifiManager.setWifiEnabled(true);
				for (int i = 0; i<=intentos; i++) {	
					try{
						if (wifiManager.isWifiEnabled())
							break;
						Thread.sleep(10000);
					}catch(Exception ex){
					
					}
				}
				
				
			}
		  }		  
	}

		
}
