package com.amesol.routelite.presentadores.interfaces;

import android.database.Cursor;

import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.generales.ISetDatos;

public interface IConsultaPromociones {

	void mostrarProductos(Producto[] obtenerProductosConPromocion,Promocion[] Promociones,ISetDatos Reglas, ISetDatos Aplicaciones);
	void manejarCursor(Cursor c);
}
