package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface ISeleccionAgenda extends IVista {
	void mostrarDiasTrabajo(ISetDatos dias);
	void mostrarRutasTrabajo(ISetDatos rutas);
	void showAlertDialog();
	boolean validarJornadaTrabajo();
	
	String getDia();
	String getRuta();
	String getsDiaClave();
	boolean getValidando();
	
	void setValidando(boolean val);
}
