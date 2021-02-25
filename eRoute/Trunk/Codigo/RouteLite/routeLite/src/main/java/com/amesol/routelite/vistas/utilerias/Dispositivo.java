package com.amesol.routelite.vistas.utilerias;

import java.util.Formatter;
import java.util.UUID;

import com.amesol.routelite.presentadores.IVista;

import android.content.Context;
import android.content.pm.PackageManager.NameNotFoundException;
import android.net.wifi.WifiConfiguration;
import android.net.ConnectivityManager;
import android.net.wifi.SupplicantState;
import android.net.wifi.WifiManager;
import android.os.Build;
import android.provider.Settings;
import android.provider.Settings.Secure;
import android.telephony.TelephonyManager;


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
        String androidId;

        Context contexto = (Context)vista;
        TelephonyManager telephonyManager = (TelephonyManager)contexto.getSystemService(Context.TELEPHONY_SERVICE);
        androidId = telephonyManager.getDeviceId();
        if (androidId == null || androidId.length()>25) {
            androidId = Secure.getString(contexto.getContentResolver(), Secure.ANDROID_ID);

            if (androidId.length() < 16) {
                androidId = String.format("%16s", androidId).replace(' ', '0');
            }
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
		EncenderApagarWiFi((Context) vista, enabled, intentos);
	}

	public static void EncenderApagarWiFi(Context contexto, boolean enabled, int intentos) throws Exception{

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
						Thread.sleep(5000);
					}catch(Exception ex){
					
					}
				}
				
				try{
					ConnectivityManager manager = (ConnectivityManager) contexto.getSystemService(Context.CONNECTIVITY_SERVICE);

					for (int i = 0; i<=intentos; i++) {	
	
							boolean isWifi = manager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).isConnected();
							if (isWifi){
								break;
							}
							//Toast.makeText(contexto, "El Wifi aun no esta listo" , Toast.LENGTH_LONG ).show();
							Thread.sleep(10000);
	
					}
				}catch(Exception ex){
					
				}
				
			}
		  }		  
	}

		
}
