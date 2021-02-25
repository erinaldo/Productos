package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface IRegistroTiemposMuertos extends IVista {

	void mostrarMotivos();
	short getMotivo();
	void mostrarMensajeRequerido();
	void cambiarVista();
	void iniciarCronometro();
	void detenerCronometro();
	void mostrarTiempoRegistrado();
}
