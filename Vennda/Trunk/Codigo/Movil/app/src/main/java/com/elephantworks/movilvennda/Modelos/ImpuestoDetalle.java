package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 09/08/2017.
 */
@RealmClass
public class ImpuestoDetalle extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idImpuestoDetalle;
    private double precioBase;
    private double tasa;
    private double importe;
    private VentaDetalle ventaDetalle;
    private int envio;

    public ImpuestoDetalle(){super();}

    public ImpuestoDetalle(int idImpuestoDetalle, double importe, double precioBase, double tasa, VentaDetalle ventaDetalle, int envio) {
        this.idImpuestoDetalle = idImpuestoDetalle;
        this.importe = importe;
        this.precioBase = precioBase;
        this.tasa = tasa;
        this.ventaDetalle = ventaDetalle;
        this.envio = envio;
    }

    public int getIdImpuestoDetalle() {
        return idImpuestoDetalle;
    }

    public void setIdImpuestoDetalle(int idImpuestoDetalle) {
        this.idImpuestoDetalle = idImpuestoDetalle;
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

    public VentaDetalle getVentaDetalle() {
        return ventaDetalle;
    }

    public void setVentaDetalle(VentaDetalle ventaDetalle) {
        this.ventaDetalle = ventaDetalle;
    }

    public int getEnvio() {
        return envio;
    }

    public void setEnvio(int envio) {
        this.envio = envio;
    }
}
