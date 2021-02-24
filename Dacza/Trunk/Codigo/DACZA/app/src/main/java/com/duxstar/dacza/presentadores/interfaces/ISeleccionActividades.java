package com.duxstar.dacza.presentadores.interfaces;

import android.content.Context;

import com.duxstar.dacza.actividades.ValorReferencia;
import com.duxstar.dacza.presentadores.IVista;

public interface ISeleccionActividades extends IVista {
	
	void mostrarActividades(ValorReferencia[] valores, String grupo);
	Context getContext();
}
