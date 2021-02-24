package com.elephantworks.movilvennda.Interfaces;

import com.elephantworks.movilvennda.Adaptadores.ProductoAdapter;

/**
 * Created by ldelatorre on 10/06/2017.
 */
public interface IProductos {

    void cargarListaProductos(ProductoAdapter adapter);

    void error(String error);
}
