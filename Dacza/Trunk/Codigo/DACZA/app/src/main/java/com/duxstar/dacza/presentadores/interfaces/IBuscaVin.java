package com.duxstar.dacza.presentadores.interfaces;

import android.database.Cursor;

import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.IVista;

public interface IBuscaVin extends IVista{
    void mostrarVins(ISetDatos vins);
    String getVin();
    void HabilitarPantalla(Boolean Habilitado);
    void mostrarMensajeEiniciarActividad(String mensaje, Class <?> actividad);
    void reiniciarPantalla();
    void habilitaDeshabilitaCodigoBarras(boolean habilitado);
}
