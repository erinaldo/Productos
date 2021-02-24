package com.duxstar.dacza.presentadores.interfaces;

import android.database.Cursor;

//import com.duxstar.dacza.actividades.Articulos;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.IVista;

public interface IBuscaArticulo extends IVista{

	void mostrarArticulos(Cursor articulos);
	Cursor obtenerArticulos();
}
