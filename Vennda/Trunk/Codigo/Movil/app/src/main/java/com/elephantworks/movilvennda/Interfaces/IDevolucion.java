package com.elephantworks.movilvennda.Interfaces;

import com.elephantworks.movilvennda.Adaptadores.DevolucionProductosAdapter;

/**
 * Created by elephantworkss.adec.v on 09/12/17.
 */

public interface IDevolucion {

    void llenarTitulos(String cliente, String folio, String fecha, String total);
    void cargarLista(DevolucionProductosAdapter adapter);
    void mostrarError(String error);
}
