package com.amesol.routelite.presentadores.interfaces;

import android.database.Cursor;

import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface  ICapturaCanje extends IVista {
	void refrescarProductos(String TransProdId);
    public void setFolio(String folio);
    public void setFecha(String fecha);
    public void setDisponibles(float puntos);
    public void setAcumulados(float puntos);
    public void setPorCanjear(float puntos);
    public boolean getEliminar();
    public void guardar(String sNombre, String sNombreArchivo);
}
