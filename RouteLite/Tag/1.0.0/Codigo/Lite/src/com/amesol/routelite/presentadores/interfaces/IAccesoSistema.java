package com.amesol.routelite.presentadores.interfaces;
import android.app.Activity;

import com.amesol.routelite.presentadores.IVista;

public interface IAccesoSistema extends IVista
{
	void setPassword(String valor);
	
	void setUsuario(String valor);
	
	void iniciarSelector();
	
	String getUsuario();
	
	String getPassword();
	
	Activity getActivity();
}
