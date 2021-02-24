package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 08/08/2017.
 */
@RealmClass
public class FoliosVenta extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idFolio;
    private int empresa;
    private int puntoVenta;
    private String fecha;
    private int consecutivo;

    public FoliosVenta(){super();}

    public FoliosVenta(int consecutivo, int empresa, String fecha, int idFolio, int puntoVenta) {
        this.consecutivo = consecutivo;
        this.empresa = empresa;
        this.fecha = fecha;
        this.idFolio = idFolio;
        this.puntoVenta = puntoVenta;
    }

    public int getConsecutivo() {
        return consecutivo;
    }

    public void setConsecutivo(int consecutivo) {
        this.consecutivo = consecutivo;
    }

    public int getEmpresa() {
        return empresa;
    }

    public void setEmpresa(int empresa) {
        this.empresa = empresa;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public int getIdFolio() {
        return idFolio;
    }

    public void setIdFolio(int idFolio) {
        this.idFolio = idFolio;
    }

    public int getPuntoVenta() {
        return puntoVenta;
    }

    public void setPuntoVenta(int puntoVenta) {
        this.puntoVenta = puntoVenta;
    }
}
