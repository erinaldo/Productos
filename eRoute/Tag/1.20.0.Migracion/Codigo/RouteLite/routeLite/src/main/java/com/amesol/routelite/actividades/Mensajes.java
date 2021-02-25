package com.amesol.routelite.actividades;

import java.util.HashMap;

import com.amesol.routelite.datos.MENDetalle;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.generales.ISetDatos;

public class Mensajes {

	private static HashMap<String, String> mensajes = null;
	
	private static synchronized HashMap<String, String> getMensajes(){
		if(mensajes == null || mensajes.isEmpty()){
			mensajes = new HashMap<String, String>();
			try {
				ISetDatos setdatos = BDTerm.consultar(MENDetalle.class);
				while(setdatos.moveToNext()){
					int i = setdatos.getColumnIndex("MENClave");
					String MENClave ="";
					String MENDescripcion ="";
					if(i >=0) {
						MENClave = setdatos.getString(i);
						if(MENClave == null) continue;
						MENClave = MENClave.toUpperCase();
						i = setdatos.getColumnIndex("Descripcion");
						if(i >= 0){
							MENDescripcion = setdatos.getString(i);
							mensajes.put(MENClave, MENDescripcion);
						}
					}
				}
				setdatos.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}		
		return mensajes;
	}
	
	public static synchronized void actualizarMensajes(){
			mensajes = new HashMap<String, String>();
			try {
				ISetDatos setdatos = BDTerm.consultar(MENDetalle.class);
				while(setdatos.moveToNext()){
					int i = setdatos.getColumnIndex("MENClave");
					String MENClave ="";
					String MENDescripcion ="";
					if(i >=0) {
						MENClave = setdatos.getString(i);
						if(MENClave == null) continue;
						MENClave = MENClave.toUpperCase();
						i = setdatos.getColumnIndex("Descripcion");
						if(i >= 0){
							MENDescripcion = setdatos.getString(i);
							mensajes.put(MENClave, MENDescripcion);
						}
					}
				}
				setdatos.close();
			} catch (Exception e) {
				e.printStackTrace();
			}		
	}
	public static boolean existe(){
		return mensajes != null && mensajes.size() > 0;
	}
	
	public static String get(String MENClave){
		MENClave = MENClave.toUpperCase();
		if(!getMensajes().containsKey(MENClave))
			return MENClave + " - NSE";
		return getMensajes().get(MENClave);		
	}
	public static String get(String MENClave, String... parametros){
		String mensaje = get(MENClave);
		Integer i = 0;
		for(String p: parametros){
			mensaje = mensaje.replace("$"+i.toString()+"$", p);
			i++;
		}
		return mensaje;
	}
	
	/*public static int getTipo(String MENClave){
		MENClave = MENClave.toUpperCase();
		if(!getMensajes().containsKey(MENClave))
			return 0;
		return getMensajes().get(key);	
	}*/
}
