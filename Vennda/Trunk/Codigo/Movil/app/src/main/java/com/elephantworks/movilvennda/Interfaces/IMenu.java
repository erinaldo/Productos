package com.elephantworks.movilvennda.Interfaces;

/**
 * Created by ldelatorre on 04/06/2017.
 */
public interface IMenu {

    void llenarTextosVista(String nombre, String correo);
    void mostrarProgreso(String mensaje);
    void cambiarMensajeProgreso(String mensaje);
    void cerrarProgeso();
    void mostrarError(String error);
}
