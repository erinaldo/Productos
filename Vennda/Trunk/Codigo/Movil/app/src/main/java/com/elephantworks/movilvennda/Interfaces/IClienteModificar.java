package com.elephantworks.movilvennda.Interfaces;

import android.widget.ArrayAdapter;

/**
 * Created by ldelatorre on 01/07/2017.
 */
public interface IClienteModificar {

    void error(String mensaje);

    void cargarSpinnerListaPrecios(ArrayAdapter adapter);

    void salir();
}
