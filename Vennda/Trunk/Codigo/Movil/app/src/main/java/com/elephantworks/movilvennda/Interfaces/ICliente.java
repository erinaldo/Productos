package com.elephantworks.movilvennda.Interfaces;

import android.database.Cursor;

import com.elephantworks.movilvennda.Adaptadores.ClienteAdapter;

/**
 * Created by ldelatorre on 23/06/2017.
 */
public interface ICliente {

    void cargarLista(ClienteAdapter adapter);

    void error(String mensaje);

    void salir();
}
