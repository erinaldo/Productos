package com.amesol.routelite.presentadores.interfaces;

import android.database.Cursor;

import com.amesol.routelite.actividades.Productos;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface IBuscaProducto extends IVista{
	//void mostrarProductos(Productos.vistaProductos[] productos);
	//Productos.vistaProductos[] obtenerProductos();
	//void mostrarProductos(ISetDatos productos);
	ISetDatos obtenerProducts();
	
	void mostrarProductos(Cursor productos);
	Cursor obtenerProductos();
}
