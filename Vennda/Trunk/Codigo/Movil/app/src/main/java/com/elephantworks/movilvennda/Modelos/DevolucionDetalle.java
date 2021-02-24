package com.elephantworks.movilvennda.Modelos;

import java.util.Date;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by elephantworkss.adec.v on 09/12/17.
 */
@RealmClass
public class DevolucionDetalle extends RealmObject implements RealmModel {
    @PrimaryKey
    private int idDevolucionDetalle;
    private String listaPrecio;
    private Double cantidadProducto;
    private Double precioUnitario;
    private Double impuestoUnitario;
    private Double impuestoTotal;
    private Double subtotal;
    private Double total;
    private Double descuento;
    private int partida;
    private Date mFechaHora;
    private String mUsuario;

    private Devolucion devolucion;
    private Productos producto;
    private int envio;

    public DevolucionDetalle(){super();}

    public DevolucionDetalle(int idDevolucionDetalle, String listaPrecio, Double cantidadProducto, Double precioUnitario, Double impuestoUnitario, Double impuestoTotal, Double subtotal, Double total, Double descuento, int partida, Date mFechaHora, String mUsuario, Devolucion devolucion, Productos producto, int envio) {
        this.idDevolucionDetalle = idDevolucionDetalle;
        this.listaPrecio = listaPrecio;
        this.cantidadProducto = cantidadProducto;
        this.precioUnitario = precioUnitario;
        this.impuestoUnitario = impuestoUnitario;
        this.impuestoTotal = impuestoTotal;
        this.subtotal = subtotal;
        this.total = total;
        this.descuento = descuento;
        this.partida = partida;
        this.mFechaHora = mFechaHora;
        this.mUsuario = mUsuario;
        this.devolucion = devolucion;
        this.producto = producto;
        this.envio = envio;
    }

    public int getIdDevolucionDetalle() {
        return idDevolucionDetalle;
    }

    public void setIdDevolucionDetalle(int idDevolucionDetalle) {
        this.idDevolucionDetalle = idDevolucionDetalle;
    }

    public String getListaPrecio() {
        return listaPrecio;
    }

    public void setListaPrecio(String listaPrecio) {
        this.listaPrecio = listaPrecio;
    }

    public Double getCantidadProducto() {
        return cantidadProducto;
    }

    public void setCantidadProducto(Double cantidadProducto) {
        this.cantidadProducto = cantidadProducto;
    }

    public Double getPrecioUnitario() {
        return precioUnitario;
    }

    public void setPrecioUnitario(Double precioUnitario) {
        this.precioUnitario = precioUnitario;
    }

    public Double getImpuestoUnitario() {
        return impuestoUnitario;
    }

    public void setImpuestoUnitario(Double impuestoUnitario) {
        this.impuestoUnitario = impuestoUnitario;
    }

    public Double getImpuestoTotal() {
        return impuestoTotal;
    }

    public void setImpuestoTotal(Double impuestoTotal) {
        this.impuestoTotal = impuestoTotal;
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

    public Double getDescuento() {
        return descuento;
    }

    public void setDescuento(Double descuento) {
        this.descuento = descuento;
    }

    public int getPartida() {
        return partida;
    }

    public void setPartida(int partida) {
        this.partida = partida;
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

    public Devolucion getDevolucion() {
        return devolucion;
    }

    public void setDevolucion(Devolucion devolucion) {
        this.devolucion = devolucion;
    }

    public Productos getProducto() {
        return producto;
    }

    public void setProducto(Productos producto) {
        this.producto = producto;
    }

    public int getEnvio() {
        return envio;
    }

    public void setEnvio(int envio) {
        this.envio = envio;
    }
}
