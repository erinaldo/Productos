package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 12/07/2017.
 */
@RealmClass
public class CarritoVentas extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idCarrito;
    private Double cantidad;
    private Double precio;
    private Double subtotal;
    private Double descuentoVendedor;
    private Double descuento;
    private Double impuestos;
    private Double total;
    private Productos producto;

    public CarritoVentas(){super();}

    public CarritoVentas(Double cantidad, Double descuento, Double descuentoVendedor, int idCarrito, Double impuestos, Double precio, Productos producto, Double subtotal, Double total) {
        this.cantidad = cantidad;
        this.descuento = descuento;
        this.descuentoVendedor = descuentoVendedor;
        this.idCarrito = idCarrito;
        this.impuestos = impuestos;
        this.precio = precio;
        this.producto = producto;
        this.subtotal = subtotal;
        this.total = total;
    }

    public Double getCantidad() {
        return cantidad;
    }

    public void setCantidad(Double cantidad) {
        this.cantidad = cantidad;
    }

    public Double getDescuento() {
        return descuento;
    }

    public void setDescuento(Double descuento) {
        this.descuento = descuento;
    }

    public int getIdCarrito() {
        return idCarrito;
    }

    public void setIdCarrito(int idCarrito) {
        this.idCarrito = idCarrito;
    }

    public Double getImpuestos() {
        return impuestos;
    }

    public void setImpuestos(Double impuestos) {
        this.impuestos = impuestos;
    }

    public Double getPrecio() {
        return precio;
    }

    public void setPrecio(Double precio) {
        this.precio = precio;
    }

    public Productos getProducto() {
        return producto;
    }

    public void setProducto(Productos producto) {
        this.producto = producto;
    }

    public Double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(Double subtotal) {
        this.subtotal = subtotal;
    }

    public Double getTotal() {
        return total;
    }

    public void setTotal(Double total) {
        this.total = total;
    }

    public Double getDescuentoVendedor() {
        return descuentoVendedor;
    }

    public void setDescuentoVendedor(Double descuentoVendedor) {
        this.descuentoVendedor = descuentoVendedor;
    }
}
