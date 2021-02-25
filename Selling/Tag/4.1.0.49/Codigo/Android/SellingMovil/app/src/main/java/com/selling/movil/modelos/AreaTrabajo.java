package com.selling.movil.modelos;

/**
 * Created by Eduardo on 18/07/16.
 */
public class AreaTrabajo {

    private String AREClave;
    private String clave;
    private boolean asignado;
    private boolean seleccionado;

    public AreaTrabajo(String AREClave, String clave, boolean asignado, boolean seleccionado) {
        this.AREClave = AREClave;
        this.clave = clave;
        this.asignado = asignado;
        this.seleccionado = seleccionado;
    }

    public String getAREClave() {
        return AREClave;
    }

    public void setAREClave(String AREClave) {
        this.AREClave = AREClave;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public boolean isAsignado() {
        return asignado;
    }

    public void setAsignado(boolean asignado) {
        this.asignado = asignado;
    }

    public boolean isSeleccionado() {
        return seleccionado;
    }

    public void setSeleccionado(boolean seleccionado) {
        this.seleccionado = seleccionado;
    }
}
