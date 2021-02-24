package com.elephantworks.movilvennda.Modelos;

import java.util.Date;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 12/06/2017.
 */
@RealmClass
public class Plan extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idPlan;
    private String identificador;
    private Boolean cobroTarjeta;
    private Boolean impresionTicket;
    private Boolean inventario;
    private Boolean autoFactura;

    public Plan(){super();}

    public Plan(Boolean autoFactura, Boolean cobroTarjeta, String identificador, int idPlan, Boolean impresionTicket, Boolean inventario) {
        this.autoFactura = autoFactura;
        this.cobroTarjeta = cobroTarjeta;
        this.identificador = identificador;
        this.idPlan = idPlan;
        this.impresionTicket = impresionTicket;
        this.inventario = inventario;
    }

    public Boolean getAutoFactura() {
        return autoFactura;
    }

    public void setAutoFactura(Boolean autoFactura) {
        this.autoFactura = autoFactura;
    }

    public Boolean getCobroTarjeta() {
        return cobroTarjeta;
    }

    public void setCobroTarjeta(Boolean cobroTarjeta) {
        this.cobroTarjeta = cobroTarjeta;
    }

    public String getIdentificador() {
        return identificador;
    }

    public void setIdentificador(String identificador) {
        this.identificador = identificador;
    }

    public int getIdPlan() {
        return idPlan;
    }

    public void setIdPlan(int idPlan) {
        this.idPlan = idPlan;
    }

    public Boolean getImpresionTicket() {
        return impresionTicket;
    }

    public void setImpresionTicket(Boolean impresionTicket) {
        this.impresionTicket = impresionTicket;
    }

    public Boolean getInventario() {
        return inventario;
    }

    public void setInventario(Boolean inventario) {
        this.inventario = inventario;
    }
}
