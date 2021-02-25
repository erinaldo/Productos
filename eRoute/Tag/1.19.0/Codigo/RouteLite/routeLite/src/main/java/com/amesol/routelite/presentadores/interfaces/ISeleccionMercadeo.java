package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

import java.util.ArrayList;

public interface ISeleccionMercadeo  extends IVista {
    void mostrarMercadeoCliente(ISetDatos sdMERDetalle);
    void setCliente(String cliente);
    void setRuta(String ruta);
    void setDia(String dia);
}
