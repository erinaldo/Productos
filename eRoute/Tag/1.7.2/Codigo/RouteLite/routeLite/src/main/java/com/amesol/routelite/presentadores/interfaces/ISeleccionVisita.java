package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface ISeleccionVisita extends IVista {
	void mostrarVisitasCliente(ISetDatos visitas);
}
