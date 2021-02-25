package com.amesol.routelite.actividades;

public class ModuloMov {

	private String ModuloClave;
	private String ModuloMovClave;
	private String Nombre;
	private int TipoIndice;
	private int Orden;
	private int TipoEstado;
	private int Baja;
	
	public ModuloMov(String moduloclave, String modulomovclave, String nombre, int tipoindice,int orden, int tipoestado,int baja){
		setModuloClave(moduloclave);
		setModuloMovClave(modulomovclave);
		setNombre(nombre);
		setTipoIndice(tipoindice);
		setOrden(orden);
		setTipoEstado(tipoestado);
		setBaja(baja);
	}
	
	public String getModuloClave() {
		return ModuloClave;
	}
	public void setModuloClave(String moduloClave) {
		ModuloClave = moduloClave;
	}
	public String getModuloMovClave() {
		return ModuloMovClave;
	}
	public void setModuloMovClave(String moduloMovClave) {
		ModuloMovClave = moduloMovClave;
	}
	public String getNombre() {
		return Nombre;
	}
	public void setNombre(String nombre) {
		Nombre = nombre;
	}
	public int getTipoIndice() {
		return TipoIndice;
	}
	public void setTipoIndice(int tipoIndice) {
		TipoIndice = tipoIndice;
	}
	public int getOrden() {
		return Orden;
	}
	public void setOrden(int orden) {
		Orden = orden;
	}
	public int getTipoEstado() {
		return TipoEstado;
	}
	public void setTipoEstado(int tipoEstado) {
		TipoEstado = tipoEstado;
	}
	public int getBaja() {
		return Baja;
	}
	public void setBaja(int baja) {
		Baja = baja;
	}
}
