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
public class Devolucion extends RealmObject implements RealmModel {
    @PrimaryKey
    private int idDevolucion;
    // 1 = Contado y 2 = Credito
    private int tipo;
    // 1 = Efectico y 2 = tarjeta
    private int formaPago;
    private Date fechaCreacion;
    private String folio;
    private Double subtotal;
    private Double impuestos;
    private Double descuento;
    private Double total;
    private Double saldo;
    private String motivo;

    private Staff staff;
    private Staff staffDevolucion;
    private Clientes cliente;
    private PuntoVenta puntoVenta;
    private Venta venta;
    private int envio;

    public Devolucion(){super();}

    public Devolucion(int idDevolucion, int tipo, int formaPago, Date fechaCreacion, String folio, Double subtotal, Double impuestos, Double descuento, Double total, Double saldo, String motivo, Staff staff, Staff staffDevolucion, Clientes cliente, PuntoVenta puntoVenta, Venta venta, int envio) {
        this.idDevolucion = idDevolucion;
        this.tipo = tipo;
        this.formaPago = formaPago;
        this.fechaCreacion = fechaCreacion;
        this.folio = folio;
        this.subtotal = subtotal;
        this.impuestos = impuestos;
        this.descuento = descuento;
        this.total = total;
        this.saldo = saldo;
        this.staff = staff;
        this.staffDevolucion = staffDevolucion;
        this.cliente = cliente;
        this.puntoVenta = puntoVenta;
        this.venta = venta;
        this.envio = envio;
        this.motivo = motivo;
    }

    public int getIdDevolucion() {
        return idDevolucion;
    }

    public void setIdDevolucion(int idDevolucion) {
        this.idDevolucion = idDevolucion;
    }

    public int getTipo() {
        return tipo;
    }

    public void setTipo(int tipo) {
        this.tipo = tipo;
    }

    public int getFormaPago() {
        return formaPago;
    }

    public void setFormaPago(int formaPago) {
        this.formaPago = formaPago;
    }

    public Date getFechaCreacion() {
        return fechaCreacion;
    }

    public void setFechaCreacion(Date fechaCreacion) {
        this.fechaCreacion = fechaCreacion;
    }

    public String getFolio() {
        return folio;
    }

    public void setFolio(String folio) {
        this.folio = folio;
    }

    public Double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(Double subtotal) {
        this.subtotal = subtotal;
    }

    public Double getImpuestos() {
        return impuestos;
    }

    public void setImpuestos(Double impuestos) {
        this.impuestos = impuestos;
    }

    public Double getDescuento() {
        return descuento;
    }

    public void setDescuento(Double descuento) {
        this.descuento = descuento;
    }

    public Double getTotal() {
        return total;
    }

    public void setTotal(Double total) {
        this.total = total;
    }

    public Double getSaldo() {
        return saldo;
    }

    public void setSaldo(Double saldo) {
        this.saldo = saldo;
    }

    public Staff getStaff() {
        return staff;
    }

    public void setStaff(Staff staff) {
        this.staff = staff;
    }

    public Staff getStaffDevolucion() {
        return staffDevolucion;
    }

    public void setStaffDevolucion(Staff staffDevolucion) {
        this.staffDevolucion = staffDevolucion;
    }

    public Clientes getCliente() {
        return cliente;
    }

    public void setCliente(Clientes cliente) {
        this.cliente = cliente;
    }

    public PuntoVenta getPuntoVenta() {
        return puntoVenta;
    }

    public void setPuntoVenta(PuntoVenta puntoVenta) {
        this.puntoVenta = puntoVenta;
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

    public String getMotivo() {
        return motivo;
    }

    public void setMotivo(String motivo) {
        this.motivo = motivo;
    }
}
