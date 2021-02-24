package com.duxstar.dacza.presentadores.interfaces;
import android.app.Activity;

//import com.amesol.routelite.datos.Usuario;
import com.duxstar.dacza.presentadores.IVista;

import java.util.Date;

public interface IAccesoSistema extends IVista
{
    //void setFecha(Date valor);

	void setAlmacen(String valor);
	
	void setAgente(String valor);

    void setPassword(String valor);
	
	void iniciarSelector();

    //Date getFecha();
	
	String getAlmacen();
	
	String getAgente();

    String getPassword();
	
	Activity getActivity();
}
