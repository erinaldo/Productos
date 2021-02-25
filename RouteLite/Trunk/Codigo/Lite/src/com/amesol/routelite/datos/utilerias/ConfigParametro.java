package com.amesol.routelite.datos.utilerias;

import java.util.Hashtable;

import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;

public class ConfigParametro
{
	private Hashtable<String,Hashtable<String,String>> datos = new Hashtable<String, Hashtable<String,String>>();
	
	public ConfigParametro() throws Exception{
		try{
			ISetDatos sdDatos = Consultas.ConsultasConfigParametro.obtenerConfigParametro();
					
				while (sdDatos.moveToNext())
				{
					set(sdDatos.getString("Parametro"), sdDatos.getString("Valor"), sdDatos.getString("Identificador") );
				}
				sdDatos.close();
		}
		catch (NullPointerException e){
			throw new Exception("Error al crear objeto de parámetros de Configuración");
		}
		catch(Exception e){
			throw new Exception("Error al crear objeto de parámetros de Configuración" + e.getMessage());
		}
	}
	
	//Para obtener los parámetros a nivel general
	public String get(String parametro) throws Exception{
		try{		
			return datos.get(parametro).get("");
		}catch(Exception ex){
			throw new Exception ("Error al recuperar el parámetro " + parametro);
		}
	}

	//Para obtener los parámetros a nivel de algun ID
	public Object get(String parametro, String ID) throws Exception{
		try{	
			return datos.get(parametro).get(ID);
		}catch(Exception ex){
			throw new Exception ("Error al recuperar el parámetro " + parametro + " ID: " + ID);
		}
	}
	
	private void set(String parametro, String valor, String ID){
		if (!datos.containsKey(parametro)){
			Hashtable<String,String> ht = new Hashtable<String,String>();
			if (ID == null)
				ht.put("",valor);
			else
				ht.put(ID,valor);
			
			datos.put(parametro.toString(), ht);
		}else{
			if (ID == null)
				datos.get(parametro).put("", valor);
			else
				datos.get(parametro).put(ID, valor);
		}
	}
}
