package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 12/06/2017.
 */
@RealmClass
public class ImpresoraHomologada extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idImpresora;
    private String nombreImpresora;
    private String macImpresora;
    private String nombreDispositivo;

    public ImpresoraHomologada(){super();}

    public ImpresoraHomologada(String nombreImpresora, int idImpresora, String macImpresora, String nombreDispositivo) {
        this.nombreImpresora = nombreImpresora;
        this.idImpresora = idImpresora;
        this.macImpresora = macImpresora;
        this.nombreDispositivo = nombreDispositivo;
    }

    public int getIdImpresora() {
        return idImpresora;
    }

    public void setIdImpresora(int idImpresora) {
        this.idImpresora = idImpresora;
    }

    public String getNombreImpresora() {
        return nombreImpresora;
    }

    public void setNombreImpresora(String nombreImpresora) {
        this.nombreImpresora = nombreImpresora;
    }

    public String getMacImpresora() {
        return macImpresora;
    }

    public void setMacImpresora(String macImpresora) {
        this.macImpresora = macImpresora;
    }

    public String getNombreDispositivo() {
        return nombreDispositivo;
    }

    public void setNombreDispositivo(String nombreDispositivo) {
        this.nombreDispositivo = nombreDispositivo;
    }
}
