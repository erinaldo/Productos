package com.duxstar.dacza.presentadores.interfaces;

/**
 * Created by Adriana on 23/06/2016.
 */
import com.duxstar.dacza.presentadores.IVista;

public interface IServidorComunicaciones extends IVista {

    void setMaxPasos(int valorMaximo);
    void setMaxDetallePasos(int valorMaximo);
    void setProgresoPasos(int valor);
    void setProgresoDetallePasos(int valor);
    void setTextoPasos(String texto);
    void setTextoProgreso(String texto);
}
