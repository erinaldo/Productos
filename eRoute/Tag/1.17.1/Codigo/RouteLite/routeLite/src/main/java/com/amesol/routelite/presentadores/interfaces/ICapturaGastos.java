package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.vistas.generico.GastosAdapter;

import java.util.HashMap;

/**
 * Created by ldelatorre on 30/05/2017.
 */
public interface ICapturaGastos {

    void guardadoExito();

    void llenarCampos(String fecha, int concepto, String folio, int formaPago, String comentarios, double importe, double impuesto, double totalImpuesto, double total);

    void mostrarError(String error);
}
