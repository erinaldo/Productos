package com.elephantworks.movilvennda.Interfaces;

import com.elephantworks.movilvennda.Adaptadores.CategoriaAdapter;

/**
 * Created by ldelatorre on 02/07/2017.
 */
public interface IListadoCategorias {

    void llenarLista(CategoriaAdapter adapter);

    void error(String mensaje);
}
