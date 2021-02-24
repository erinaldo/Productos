package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 17/06/2017.
 */
@RealmClass
public class ValoresReferencia extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idValoreRef;
    private String clave;
    private int valor;
    private String descripcion;

    public ValoresReferencia(){super();}

    public ValoresReferencia(String clave, String descripcion, int idValoreRef, int valor) {
        this.clave = clave;
        this.descripcion = descripcion;
        this.idValoreRef = idValoreRef;
        this.valor = valor;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getIdValoreRef() {
        return idValoreRef;
    }

    public void setIdValoreRef(int idValoreRef) {
        this.idValoreRef = idValoreRef;
    }

    public int getValor() {
        return valor;
    }

    public void setValor(int valor) {
        this.valor = valor;
    }
}
