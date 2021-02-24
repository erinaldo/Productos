package com.elephantworks.movilvennda.Interfaces;

import com.elephantworks.movilvennda.Adaptadores.ConsultaDevolucionAdapter;
import com.elephantworks.movilvennda.Adaptadores.ConsultaVentaAdapter;
import com.elephantworks.movilvennda.Adaptadores.VentasAdapter;

/**
 * Created by ldelatorre on 16/07/2017.
 */
public interface IConsultarVentas {

    void cargarLista(ConsultaVentaAdapter adapter);

    void cargarListaDevolucion(ConsultaDevolucionAdapter adapter);

    void error(String mensaje);
}
