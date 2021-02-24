package com.elephantworks.movilvennda.Interfaces;

import android.widget.ArrayAdapter;

/**
 * Created by Elephant on 04/06/17.
 */

public interface IPuntoVenta {

    void mostrarTitulos(String empresa, String bienvenida);

    void cargarSpinnerPuntoVenta(ArrayAdapter adaptador);

    void ingresarMenu();

    void error(String mensaje);
}
