package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.vistas.generico.GastosAdapter;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public interface ISeleccionGastos  extends IVista {

    void llenarListaGastos(GastosAdapter adapter);

    void refrescarLista();
}
