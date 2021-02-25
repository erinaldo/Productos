package com.selling.movil.modelos;

/**
 * Created by aperez on 27/06/2019.
 */
public class Reubicacion {
    private String codigo;
    private String cantidad;
    private boolean seleccionado;
    private String ubicacion;
    private String activity;

    public Reubicacion(String codigo, String cantidad, boolean seleccionado, String ubicacion, String activity){
        this.codigo = codigo;
        this.cantidad = cantidad;
        this.seleccionado = seleccionado;
        this.ubicacion = ubicacion;
        this.activity = activity;
    }

    public void setCodigo(String codigo){this.codigo = codigo;}

    public String getCodigo(){return this.codigo;}

    public void setCantidad(String cantidad){this.cantidad = cantidad;}

    public String getCantidad(){return this.cantidad;}

    public void setSeleccionado(boolean seleccionado){this.seleccionado = seleccionado;}

    public boolean isSeleccionado(){return this.seleccionado;}

    public void setUbicacion(String ubicacion){this.ubicacion = ubicacion;}

    public String getUbicacion(){return ubicacion;}

    public void  setActivity(String activity){this.activity = activity;}

    public String getActivity(){return activity;}
}
