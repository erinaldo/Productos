package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmList;
import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 12/06/2017.
 */
@RealmClass
public class Impuesto  extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idImpuesto;
    private String identificador;
    private int jerarquia;
    private boolean despuesDeImpuesto = true;
    private int tipoAplicacion;
    private RealmList<ValoresImpuesto> valoresImpuestos;
    private boolean activo = true;

    public Impuesto(){super();}

    public Impuesto(boolean activo, boolean despuesDeImpuesto, String identificador, int idImpuesto, int jerarquia, int tipoAplicacion, RealmList<ValoresImpuesto> valoresImpuestos) {
        this.activo = activo;
        this.despuesDeImpuesto = despuesDeImpuesto;
        this.identificador = identificador;
        this.idImpuesto = idImpuesto;
        this.jerarquia = jerarquia;
        this.tipoAplicacion = tipoAplicacion;
        this.valoresImpuestos = valoresImpuestos;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public boolean isDespuesDeImpuesto() {
        return despuesDeImpuesto;
    }

    public void setDespuesDeImpuesto(boolean despuesDeImpuesto) {
        this.despuesDeImpuesto = despuesDeImpuesto;
    }

    public String getIdentificador() {
        return identificador;
    }

    public void setIdentificador(String identificador) {
        this.identificador = identificador;
    }

    public int getIdImpuesto() {
        return idImpuesto;
    }

    public void setIdImpuesto(int idImpuesto) {
        this.idImpuesto = idImpuesto;
    }

    public int getJerarquia() {
        return jerarquia;
    }

    public void setJerarquia(int jerarquia) {
        this.jerarquia = jerarquia;
    }

    public int getTipoAplicacion() {
        return tipoAplicacion;
    }

    public void setTipoAplicacion(int tipoAplicacion) {
        this.tipoAplicacion = tipoAplicacion;
    }

    public RealmList<ValoresImpuesto> getValoresImpuestos() {
        return valoresImpuestos;
    }

    public void setValoresImpuestos(RealmList<ValoresImpuesto> valoresImpuestos) {
        this.valoresImpuestos = valoresImpuestos;
    }
}
