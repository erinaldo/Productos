package com.elephantworks.movilvennda.Interfaces;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;
import com.elephantworks.movilvennda.Adaptadores.VentasAdapter;

/**
 * Created by ldelatorre on 10/07/2017.
 */
public interface IListaVentas {

    void cargarLista(VentasAdapter adapter);

    void error(String mensaje);
}
