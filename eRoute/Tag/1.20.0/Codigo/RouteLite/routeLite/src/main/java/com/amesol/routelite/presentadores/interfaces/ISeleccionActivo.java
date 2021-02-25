package com.amesol.routelite.presentadores.interfaces;

import android.database.Cursor;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.vistas.SeleccionActivo;

/**
 * Created by Adriana on 26/12/2016.
 */
public interface ISeleccionActivo extends IVista {

    void mostrarActivos(SeleccionActivo.VistaActivos[] activos);

    void habilitarCrear(boolean habilitar);

    //ISetDatos obtenerSolicitudes();

    //boolean existenSolicitudes();
}
