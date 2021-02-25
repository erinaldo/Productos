package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface IServidorComunicaciones extends IVista {

	void setMaxPasos(int valorMaximo);
	void setMaxDetallePasos(int valorMaximo);
	void setProgresoPasos(int valor);
	void setProgresoDetallePasos(int valor);
	void setTextoPasos(String texto);
	void setTextoProgreso(String texto);
}
