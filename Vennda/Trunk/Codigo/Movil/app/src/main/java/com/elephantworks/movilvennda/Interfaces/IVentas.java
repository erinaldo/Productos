package com.elephantworks.movilvennda.Interfaces;

/**
 * Created by ldelatorre on 10/06/2017.
 */
public interface IVentas {

    /*Inicia MenuVentas*/
    void actualizarTotales(String subtotal, String descuento, String impuesto, String Total);

    void llenarTitulosMenuVenta(String puntoVenta, String fecha,String folio, String cliente, String limiteCredito, String saldoCredito);

    void error(String mensaje);

    /*Termina MenuVentas*/
}
