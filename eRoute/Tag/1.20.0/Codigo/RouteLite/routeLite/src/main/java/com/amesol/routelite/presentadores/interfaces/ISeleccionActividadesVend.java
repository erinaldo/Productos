package com.amesol.routelite.presentadores.interfaces;

import android.content.Context;

import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.presentadores.IVista;

public interface ISeleccionActividadesVend extends IVista {
	
	void mostrarActividades(ValorReferencia[] valores,String grupo);
	Context getContext();
}
