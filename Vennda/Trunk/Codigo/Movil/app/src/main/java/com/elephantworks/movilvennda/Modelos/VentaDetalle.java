package com.elephantworks.movilvennda.Modelos;

import java.util.Date;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 16/07/2017.
 */
@RealmClass
public class VentaDetalle extends RealmObject implements RealmModel {
    @PrimaryKey
    private int idVentaDetalle;
    private String listaPrecio;
    private Double cantidadProducto;
    private Double precioUnitario;
    private Double impuestoUnitario;
    private Double impuestoTotal;
    private Double subtotal;
    private Double total;
    private Double descuento;
    private Double cantidadDevuelta; // este campo sirve para guardar la cantidad devuelta de un producto de una venta
    private int partida;
    private Date mFechaHora;
    private String mUsuario;

    private Venta venta;
    private Productos producto;
    private int envio;

    public VentaDetalle(){super();}

    public VentaDetalle(Double cantidadProducto, Double descuento, int idVentaDetalle, Double impuestoTotal, Double impuestoUnitario, String listaPrecio, Date mFechaHora, String mUsuario, int partida, Double precioUnitario, Productos producto, Double subtotal, Double total, Double cantidadDevuelta, Venta venta, int envio) {
        this.cantidadProducto = cantidadProducto;
        this.descuento = descuento;
        this.idVentaDetalle = idVentaDetalle;
        this.impuestoTotal = impuestoTotal;
        this.impuestoUnitario = impuestoUnitario;
        this.listaPrecio = listaPrecio;
        this.mFechaHora = mFechaHora;
        this.mUsuario = mUsuario;
        this.partida = partida;
        this.precioUnitario = precioUnitario;
        this.producto = producto;
        this.subtotal = subtotal;
        this.total = total;
        this.cantidadDevuelta = cantidadDevuelta;
        this.venta = venta;
        this.envio = envio;
    }

    public Double getCantidadProducto() {
        return cantidadProducto;
    }

    public void setCantidadProducto(Double cantidadProducto) {
        this.cantidadProducto = cantidadProducto;
    }

    public Double getDescuento() {
        return descuento;
    }

    public void setDescuento(Double descuento) {
        this.descuento = descuento;
    }

    public int getIdVentaDetalle() {
        return idVentaDetalle;
    }

    public void setIdVentaDetalle(int idVentaDetalle) {
        this.idVentaDetalle = idVentaDetalle;
    }

    public Double getImpuestoTotal() {
        return impuestoTotal;
    }

    public void setImpuestoTotal(Double impuestoTotal) {
        this.impuestoTotal = impuestoTotal;
    }

    public Double getImpuestoUnitario() {
        return impuestoUnitario;
    }

    public void setImpuestoUnitario(Double impuestoUnitario) {
        this.impuestoUnitario = impuestoUnitario;
    }

    public String getListaPrecio() {
        return listaPrecio;
    }

    public void setListaPrecio(String listaPrecio) {
        this.listaPrecio = listaPrecio;
    }

    public Date getmFechaHora() {
        return mFechaHora;
    }

    public void setmFechaHora(Date mFechaHora) {
        this.mFechaHora = mFechaHora;
    }

    public String getmUsuario() {
        return mUsuario;
    }

    public void setmUsuario(String mUsuario) {
        this.mUsuario = mUsuario;
    }

    public int getPartida() {
        return partida;
    }

    public void setPartida(int partida) {
        this.partida = partida;
    }

    public Double getPrecioUnitario() {
        return precioUnitario;
    }

    public void setPrecioUnitario(Double precioUnitario) {
        this.precioUnitario = precioUnitario;
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

    public Venta getVenta() {
        return venta;
    }

    public void setVenta(Venta venta) {
        this.venta = venta;
    }

    public int getEnvio() {
        return envio;
    }

    public void setEnvio(int envio) {
        this.envio = envio;
    }

    public Double getCantidadDevuelta() {
        return cantidadDevuelta;
    }

    public void setCantidadDevuelta(Double cantidadDevuelta) {
        this.cantidadDevuelta = cantidadDevuelta;
    }
}
