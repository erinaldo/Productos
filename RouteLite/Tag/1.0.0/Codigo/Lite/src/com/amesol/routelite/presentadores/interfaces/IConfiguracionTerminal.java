package com.amesol.routelite.presentadores.interfaces;

import java.util.Map;

import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.presentadores.IVista;

public interface IConfiguracionTerminal extends IVista {
		
	void setServicio(String valor);
	void setUsuario(String valor);
	void setContrasenia(String valor);
	void setDirectorio(String valor);
	void setWireless(Boolean valor);
	void setTimeOut(int valor);
	void presentarTiposPapel(ValorReferencia[] papeles);
	void setConfiguracionPuerto(Map<String,String> configuracion);
	String getServicio();
	String getUsuario();
	String getContrasenia();
	String getDirectorio();
	Boolean isWireless();
	int getTimeOut();
	
	void mostrarOpcionesPuerto();
	void setAseguramientoVisita(boolean valor);
	boolean obtenerAseguramientoVisita();
	boolean existeBDVendedor();
	void guardarAseguramiento();
}
