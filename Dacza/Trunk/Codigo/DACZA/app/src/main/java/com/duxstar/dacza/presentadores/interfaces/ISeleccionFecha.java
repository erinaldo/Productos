package com.duxstar.dacza.presentadores.interfaces;

import com.duxstar.dacza.presentadores.IVista;

import java.util.Date;

public interface ISeleccionFecha extends IVista {
    void setFecha(String valor);
    String getFecha();
}
