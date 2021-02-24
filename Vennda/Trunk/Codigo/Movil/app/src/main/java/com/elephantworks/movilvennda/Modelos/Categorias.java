package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 12/06/2017.
 */
@RealmClass
public class Categorias extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idCategoria;
    private String identificador;
    private String nombre;
    private boolean activo = true;
    private String imagen;

    public Categorias(){super();}

    public Categorias(boolean activo, int idCategoria, String identificador, String nombre,String imagen) {
        this.activo = activo;
        this.idCategoria = idCategoria;
        this.identificador = identificador;
        this.nombre = nombre;
        this.imagen = imagen;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public int getIdCategoria() {
        return idCategoria;
    }

    public void setIdCategoria(int idCategoria) {
        this.idCategoria = idCategoria;
    }

    public String getIdentificador() {
        return identificador;
    }

    public void setIdentificador(String identificador) {
        this.identificador = identificador;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getImagen() {
        return imagen;
    }

    public void setImagen(String imagen) {
        this.imagen = imagen;
    }
}
