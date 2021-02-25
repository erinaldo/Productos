package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;

public interface ISeleccionConteoInventario extends IVista {
    void mostrarConteosInventario (ISetDatos conteos);
}
