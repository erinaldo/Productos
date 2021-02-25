package com.selling.movil.modelos;

import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;

/**
 * Created by Eduardo on 17/11/15.
 */
public class ValorReferencia extends RealmObject {

    private String tabla;
    private String campo;
    private int valor;
    private String descripcion;
    private int grupo;

    public String getTabla() {
        return tabla;
    }

    public void setTabla(String tabla) {
        this.tabla = tabla;
    }

    public String getCampo() {
        return campo;
    }

    public void setCampo(String campo) {
        this.campo = campo;
    }

    public int getValor() {
        return valor;
    }

    public void setValor(int valor) {
        this.valor = valor;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getGrupo(){return grupo;}

    public void setGrupo(int grupo){this.grupo = grupo;}
}
