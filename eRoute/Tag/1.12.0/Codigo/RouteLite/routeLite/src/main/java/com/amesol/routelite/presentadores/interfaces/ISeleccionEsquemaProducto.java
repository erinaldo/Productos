package com.amesol.routelite.presentadores.interfaces;

import java.util.SortedMap;
import java.util.TreeMap;

import android.database.Cursor;

import com.amesol.routelite.datos.Esquema;
import com.amesol.routelite.presentadores.IVista;

public interface ISeleccionEsquemaProducto extends IVista
{
	void mostrarEsquemas(SortedMap<String, Esquema> esquemas);
	SortedMap<String, Esquema> obtenerEsquemas();
}
