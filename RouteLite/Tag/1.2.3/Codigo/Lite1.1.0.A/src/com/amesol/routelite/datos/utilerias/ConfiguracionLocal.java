package com.amesol.routelite.datos.utilerias;

import java.util.Hashtable;

import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;

public class ConfiguracionLocal {
private Hashtable<String, Object> datos = new Hashtable<String, Object>();
	
	public ConfiguracionLocal(){
		try{
			
			for (CampoConfiguracion campo:  ArchivoConfiguracion.CampoConfiguracion.values()){
				set(campo.toString(), null);
			}
		}
		catch(Exception e){
			e.printStackTrace();
		}
	}
	
	public Object get(String campo){
		return datos.get(campo);
	}

	public Object get(CampoConfiguracion campo){
		return datos.get(campo.toString());
	}
	
	public void set(String campo, Object valor){
		datos.put(campo.toString(), valor);
	}
	
	public void set(CampoConfiguracion campo, Object valor){
		datos.put(campo.toString(), valor);
	}
	
}
