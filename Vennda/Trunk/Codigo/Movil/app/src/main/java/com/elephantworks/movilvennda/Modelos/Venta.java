package com.elephantworks.movilvennda.Modelos;

import java.sql.SQLOutput;
import java.util.Date;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 16/07/2017.
 */
@RealmClass
public class Venta extends RealmObject implements RealmModel {
    @PrimaryKey
    private int idVenta;
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
    private Double recibido;
    private Double cambio;
    private Date fechaCancelacion;
    private String motivoCancelacion;
    private Date fechaVencimiento;

    private Staff staff;
    private Staff staffCancelacion;
    private Clientes cliente;
    private PuntoVenta puntoVenta;
    private int envio;

    public Venta(){super();}

    public Venta(Clientes cliente, Date fechaCancelacion, Date fechaCreacion, String folio, int idVenta, Double impuestos, String motivoCancelacion, PuntoVenta puntoVenta, Staff staff, Staff staffCancelacion, Double subtotal, int tipo, Double total, Double descuento, Double saldo, int envio, int formaPago, Date fechaVencimiento, Double recibido, Double cambio) {
        this.cliente = cliente;
        this.fechaCancelacion = fechaCancelacion;
        this.fechaCreacion = fechaCreacion;
        this.folio = folio;
        this.idVenta = idVenta;
        this.impuestos = impuestos;
        this.motivoCancelacion = motivoCancelacion;
        this.puntoVenta = puntoVenta;
        this.staff = staff;
        this.staffCancelacion = staffCancelacion;
        this.subtotal = subtotal;
        this.tipo = tipo;
        this.total = total;
        this.descuento = descuento;
        this.saldo = saldo;
        this.envio = envio;
        this.formaPago = formaPago;
        this.fechaVencimiento = fechaVencimiento;
        this.recibido = recibido;
        this.cambio = cambio;
    }

    public Clientes getCliente() {
        return cliente;
    }

    public void setCliente(Clientes cliente) {
        this.cliente = cliente;
    }

    public Date getFechaCancelacion() {
        return fechaCancelacion;
    }

    public void setFechaCancelacion(Date fechaCancelacion) {
        this.fechaCancelacion = fechaCancelacion;
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

    public int getIdVenta() {
        return idVenta;
    }

    public void setIdVenta(int idVenta) {
        this.idVenta = idVenta;
    }

    public Double getImpuestos() {
        return impuestos;
    }

    public void setImpuestos(Double impuestos) {
        this.impuestos = impuestos;
    }

    public String getMotivoCancelacion() {
        return motivoCancelacion;
    }

    public void setMotivoCancelacion(String motivoCancelacion) {
        this.motivoCancelacion = motivoCancelacion;
    }

    public PuntoVenta getPuntoVenta() {
        return puntoVenta;
    }

    public void setPuntoVenta(PuntoVenta puntoVenta) {
        this.puntoVenta = puntoVenta;
    }

    public Staff getStaff() {
        return staff;
    }

    public void setStaff(Staff staff) {
        this.staff = staff;
    }

    public Staff getStaffCancelacion() {
        return staffCancelacion;
    }

    public void setStaffCancelacion(Staff staffCancelacion) {
        this.staffCancelacion = staffCancelacion;
    }

    public Double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(Double subtotal) {
        this.subtotal = subtotal;
    }

    public int getTipo() {
        return tipo;
    }

    public void setTipo(int tipo) {
        this.tipo = tipo;
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

    public Double getSaldo() {
        return saldo;
    }

    public void setSaldo(Double saldo) {
        this.saldo = saldo;
    }

    public int getEnvio() {
        return envio;
    }

    public void setEnvio(int envio) {
        this.envio = envio;
    }

    public int getFormaPago() {
        return formaPago;
    }

    public void setFormaPago(int formaPago) {
        this.formaPago = formaPago;
    }

    public Date getFechaVencimiento() {
        return fechaVencimiento;
    }

    public void setFechaVencimiento(Date fechaVencimiento) {
        this.fechaVencimiento = fechaVencimiento;
    }

    public Double getRecibido() {
        return recibido;
    }

    public void setRecibido(Double recibido) {
        this.recibido = recibido;
    }

    public Double getCambio() {
        return cambio;
    }

    public void setCambio(Double cambio) {
        this.cambio = cambio;
    }
}
