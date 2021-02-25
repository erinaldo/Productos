package com.amesol.pruebaandroid.prov;

import java.util.HashMap;

public class Sesion {

	private static Sesion instancia = null;
	private HashMap<ValoresSesion, Object> m = new HashMap<ValoresSesion, Object>();
	public enum ValoresSesion{
		DIACLAVE,
		RUTCLAVE,
		CLIENTECLAVE,
		NOMBRECLIENTE,
		CLAVECLIENTE,
		RELOJARENA
	}
	public Sesion(){
		
	}
	private static synchronized Sesion crearSesion(){
		if(instancia == null)
			instancia = new Sesion();
		return instancia;
	}
	
	public static void setElemento(ValoresSesion llave, Object valor){
		if(instancia == null)crearSesion();
		instancia.m.put(llave, valor);		
	}
	
	public static Object getElemento(ValoresSesion llave){
		if(instancia == null)crearSesion();
		return instancia.m.get(llave);
	}
}
