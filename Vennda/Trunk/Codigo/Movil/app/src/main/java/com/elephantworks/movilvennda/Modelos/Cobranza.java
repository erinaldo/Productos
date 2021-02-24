package com.elephantworks.movilvennda.Modelos;

import java.util.Date;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 18/07/2017.
 */
@RealmClass
public class Cobranza extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idCobranza;
    private Venta venta;
    private Abono abono;
    private Date fecha;
    private double saldo;
    private double saldoAbono;
    private int envio;

    public Cobranza(){super();}

    public Cobranza(Abono abono, Date fecha, int idCobranza, double saldo, double saldoAbono, Venta venta, int envio) {
        this.abono = abono;
        this.fecha = fecha;
        this.idCobranza = idCobranza;
        this.saldo = saldo;
        this.saldoAbono = saldoAbono;
        this.venta = venta;
        this.envio = envio;
    }

    public Abono getAbono() {
        return abono;
    }

    public void setAbono(Abono abono) {
        this.abono = abono;
    }

    public Date getFecha() {
        return fecha;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    public int getIdCobranza() {
        return idCobranza;
    }

    public void setIdCobranza(int idCobranza) {
        this.idCobranza = idCobranza;
    }

    public double getSaldo() {
        return saldo;
    }

    public void setSaldo(double saldo) {
        this.saldo = saldo;
    }

    public double getSaldoAbono() {
        return saldoAbono;
    }

    public void setSaldoAbono(double saldoAbono) {
        this.saldoAbono = saldoAbono;
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
}
