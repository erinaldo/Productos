package com.selling.movil.modelos;

/**
 * Created by Eduardo on 17/12/15.
 */
public class Existencia {

    private String clave;
    private String existencia;
    private String apartado;
    private String bloqueado;

    public Existencia(String clave, String existencia, String apartado, String bloqueado) {
        this.clave = clave;
        this.existencia = existencia;
        this.apartado = apartado;
        this.bloqueado = bloqueado;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public String getExistencia() {
        return existencia;
    }

    public void setExistencia(String existencia) {
        this.existencia = existencia;
    }

    public String getApartado() {
        return apartado;
    }

    public void setApartado(String apartado) {
        this.apartado = apartado;
    }

    public String getBloqueado() {
        return bloqueado;
    }

    public void setBloqueado(String bloqueado) {
        this.bloqueado = bloqueado;
    }
}
