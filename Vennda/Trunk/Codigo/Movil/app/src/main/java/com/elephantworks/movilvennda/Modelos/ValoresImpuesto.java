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
public class ValoresImpuesto  extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idValoresImpuesto;
    private Double tasa;
    private Date inicio;
    private Date fin;
    private boolean activo = true;

    public ValoresImpuesto(){super();}

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public Date getFin() {
        return fin;
    }

    public void setFin(Date fin) {
        this.fin = fin;
    }

    public int getIdValoresImpuesto() {
        return idValoresImpuesto;
    }

    public void setIdValoresImpuesto(int idValoresImpuesto) {
        this.idValoresImpuesto = idValoresImpuesto;
    }

    public Date getInicio() {
        return inicio;
    }

    public void setInicio(Date inicio) {
        this.inicio = inicio;
    }

    public Double getTasa() {
        return tasa;
    }

    public void setTasa(Double tasa) {
        this.tasa = tasa;
    }
}
