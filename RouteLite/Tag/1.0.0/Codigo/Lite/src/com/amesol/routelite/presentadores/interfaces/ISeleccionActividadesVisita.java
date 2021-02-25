package com.amesol.routelite.presentadores.interfaces;

import android.app.Activity;

import com.amesol.routelite.actividades.ModuloMov;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.presentadores.IVista;

public interface ISeleccionActividadesVisita extends IVista {

	void mostrarActividades(ModuloMov[] modulos);
	void mostrarActividades(ModuloMovDetalle[] modulosDetalle);
	ModuloMovDetalle getActividad();
	Activity getActivity();
}
