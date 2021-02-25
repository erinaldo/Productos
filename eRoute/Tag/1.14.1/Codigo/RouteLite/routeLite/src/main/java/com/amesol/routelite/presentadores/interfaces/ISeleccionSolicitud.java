package com.amesol.routelite.presentadores.interfaces;

import android.database.Cursor;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

/**
 * Created by Adriana on 26/12/2016.
 */
public interface ISeleccionSolicitud extends IVista {

    void mostrarSolicitudes(ISetDatos solicitudes);

    //ISetDatos obtenerSolicitudes();

    //boolean existenSolicitudes();
}
