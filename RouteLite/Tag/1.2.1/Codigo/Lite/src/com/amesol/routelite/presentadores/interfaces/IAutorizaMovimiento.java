package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.presentadores.IVista;

public interface IAutorizaMovimiento extends IVista {
	void setToken(String token);
	String obtenerToken();
}
