package com.duxstar.dacza.presentadores.interfaces;

import java.util.Date;
import java.util.Map;

//import com.amesol.routelite.actividades.ValorReferencia;
import com.duxstar.dacza.presentadores.IVista;

public interface IConfiguracionTerminal extends IVista {
		
	void setServicio(String valor);
    //void setFecha(Date valor);
	void setAlmacen(String valor);
	void setAgente(String valor);
    void setPassword(String valor);
	void setDirectorio(String valor);
    void setEnvioIndividual(Boolean valor);
	void setWireless(Boolean valor);
	void setTimeOut(int valor);
	String getServicio();
    //Date getFecha();
	String getAlmacen();
	String getAgente();
    String getPassword();
	String getDirectorio();
    Boolean isEnvioIndividual();
	Boolean isWireless();
	int getTimeOut();
}
