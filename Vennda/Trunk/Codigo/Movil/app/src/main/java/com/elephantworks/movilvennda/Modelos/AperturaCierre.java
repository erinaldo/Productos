package com.elephantworks.movilvennda.Modelos;

import java.util.Date;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 17/06/2017.
 */
@RealmClass
public class AperturaCierre extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idApertura;
    private Staff usuarioAbre;
    private Date fechaAbre;
    private Double montoAbre;
    private Staff usuarioCierra;
    private Date fechaCierra;
    private Double montoCierra;
    private int envio;

    public AperturaCierre(){super();}

    public AperturaCierre(Date fechaAbre, Date fechaCierra, int idApertura, Double montoAbre, Double montoCierra, Staff usuarioAbre, Staff usuarioCierra, int envio) {
        this.fechaAbre = fechaAbre;
        this.fechaCierra = fechaCierra;
        this.idApertura = idApertura;
        this.montoAbre = montoAbre;
        this.montoCierra = montoCierra;
        this.usuarioAbre = usuarioAbre;
        this.usuarioCierra = usuarioCierra;
        this.envio = envio;
    }

    public int getEnvio() {
        return envio;
    }

    public void setEnvio(int envio) {
        this.envio = envio;
    }

    public Date getFechaAbre() {
        return fechaAbre;
    }

    public void setFechaAbre(Date fechaAbre) {
        this.fechaAbre = fechaAbre;
    }

    public Date getFechaCierra() {
        return fechaCierra;
    }

    public void setFechaCierra(Date fechaCierra) {
        this.fechaCierra = fechaCierra;
    }

    public int getIdApertura() {
        return idApertura;
    }

    public void setIdApertura(int idApertura) {
        this.idApertura = idApertura;
    }

    public Double getMontoAbre() {
        return montoAbre;
    }

    public void setMontoAbre(Double montoAbre) {
        this.montoAbre = montoAbre;
    }

    public Double getMontoCierra() {
        return montoCierra;
    }

    public void setMontoCierra(Double montoCierra) {
        this.montoCierra = montoCierra;
    }

    public Staff getUsuarioAbre() {
        return usuarioAbre;
    }

    public void setUsuarioAbre(Staff usuarioAbre) {
        this.usuarioAbre = usuarioAbre;
    }

    public Staff getUsuarioCierra() {
        return usuarioCierra;
    }

    public void setUsuarioCierra(Staff usuarioCierra) {
        this.usuarioCierra = usuarioCierra;
    }
}
