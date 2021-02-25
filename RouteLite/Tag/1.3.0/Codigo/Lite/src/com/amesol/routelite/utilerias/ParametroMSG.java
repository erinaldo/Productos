package com.amesol.routelite.utilerias;

public class ParametroMSG{
	public String cadena;
	public boolean buscar;
	
	public ParametroMSG(String cadena){
		this.cadena = cadena;
		this.buscar = false;
	}
	
	public ParametroMSG(String cadena, boolean buscar){
		this.cadena = cadena;
		this.buscar = buscar;
	}
}	
