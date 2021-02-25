package com.amesol.pruebaandroid.ele;

import com.amesol.pruebaandroid.enu.Actividad;

public class ItemMenu {
	private String descripcion;
	private int imagen;
	private Actividad indice;
	
	public ItemMenu(String descripcion, int imagen, Actividad indice){
		this.descripcion= descripcion;
		this.imagen = imagen;
		this.indice = indice;
	}
	
	public String getDescripcion(){
		return descripcion;	
	}
	public int getImagen(){
		return imagen;	
	}
	public Actividad getIndice(){
		return indice;
	}
}
