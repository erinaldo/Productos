package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 09/08/2017.
 */
@RealmClass
public class CarritoImpuesto extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idCarritoImpuesto;
    private double precioBase;
    private double tasa;
    private double importe;
    private CarritoVentas carrito;

    public CarritoImpuesto(){super();}

    public CarritoImpuesto(CarritoVentas carrito, int idCarritoImpuesto, double importe, double precioBase, double tasa) {
        this.carrito = carrito;
        this.idCarritoImpuesto = idCarritoImpuesto;
        this.importe = importe;
        this.precioBase = precioBase;
        this.tasa = tasa;
    }

    public CarritoVentas getCarrito() {
        return carrito;
    }

    public void setCarrito(CarritoVentas carrito) {
        this.carrito = carrito;
    }

    public int getIdCarritoImpuesto() {
        return idCarritoImpuesto;
    }

    public void setIdCarritoImpuesto(int idCarritoImpuesto) {
        this.idCarritoImpuesto = idCarritoImpuesto;
    }

    public double getImporte() {
        return importe;
    }

    public void setImporte(double importe) {
        this.importe = importe;
    }

    public double getPrecioBase() {
        return precioBase;
    }

    public void setPrecioBase(double precioBase) {
        this.precioBase = precioBase;
    }

    public double getTasa() {
        return tasa;
    }

    public void setTasa(double tasa) {
        this.tasa = tasa;
    }
}
