package com.amesol.routelite.presentadores.interfaces;

import java.util.Date;

import com.amesol.routelite.presentadores.IVista;

public interface ISolicitudAgendaVendedor extends IVista {
	
	Date getFechaInicial();
	Date getFechaFinal();
	void setFechaInicial(Date fecha);
	void setFechaFinal(Date fecha);
    boolean getNoFechaFinAgenda();
    boolean getFechaInicialAgendaNoMenor();

}
