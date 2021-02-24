package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 12/06/2017.
 */
@RealmClass
public class Inventario extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idInventario;
    Double cantidad;
    boolean activo;
    Productos productos;

    public Inventario(){super();}

    public Inventario(boolean activo, Double cantidad, int idInventario, Productos productos) {
        this.activo = activo;
        this.cantidad = cantidad;
        this.idInventario = idInventario;
        this.productos = productos;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public Double getCantidad() {
        return cantidad;
    }

    public void setCantidad(Double cantidad) {
        this.cantidad = cantidad;
    }

    public int getIdInventario() {
        return idInventario;
    }

    public void setIdInventario(int idInventario) {
        this.idInventario = idInventario;
    }

    public Productos getProductos() {
        return productos;
    }

    public void setProductos(Productos productos) {
        this.productos = productos;
    }
}
