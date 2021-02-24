package com.elephantworks.movilvennda.Interfaces;

import android.widget.ArrayAdapter;

import com.elephantworks.movilvennda.Adaptadores.DineroAdapter;

/**
 * Created by ldelatorre on 17/06/2017.
 */
public interface IAperturaCierre {
    void cargarSpinnerDenominacion(ArrayAdapter adaptador);

    void cargarLista(DineroAdapter dineroAdapter);

    void cargarTotal(String total);

    void error(String mensaje);

    void salir(String mensaje);
}
