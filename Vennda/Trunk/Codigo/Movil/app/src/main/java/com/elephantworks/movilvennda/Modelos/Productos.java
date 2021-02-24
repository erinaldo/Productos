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
public class Productos extends RealmObject implements RealmModel {


    @PrimaryKey
    private int idProducto;
    private String clave;
    private String nombre;
    private String descripcion;
    private String codigoBarras;
    private String imagen;
    private Double precio;
    private Double precio2;
    private Double precio3;
    private Double precio4;
    private Double precio5;
    private boolean activo;
    private Categorias categorias;
    private RealmList<Impuesto> impuestos;

    public Productos(){super();}

    public Productos(boolean activo, String clave, String codigoBarras, String descripcion, int idProducto, String imagen, String nombre, Double precio2, Double precio3, Double precio4, Double precio5, Double precio, Categorias categorias, RealmList<Impuesto> impuestos) {
        this.activo = activo;
        this.clave = clave;
        this.codigoBarras = codigoBarras;
        this.descripcion = descripcion;
        this.idProducto = idProducto;
        this.imagen = imagen;
        this.nombre = nombre;
        this.precio2 = precio2;
        this.precio3 = precio3;
        this.precio4 = precio4;
        this.precio5 = precio5;
        this.precio = precio;
        this.categorias = categorias;
        this.impuestos = impuestos;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public String getCodigoBarras() {
        return codigoBarras;
    }

    public void setCodigoBarras(String codigoBarras) {
        this.codigoBarras = codigoBarras;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getIdProducto() {
        return idProducto;
    }

    public void setIdProducto(int idProducto) {
        this.idProducto = idProducto;
    }

    public String getImagen() {
        return imagen;
    }

    public void setImagen(String imagen) {
        this.imagen = imagen;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public Double getPrecio2() {
        return precio2;
    }

    public void setPrecio2(Double precio2) {
        this.precio2 = precio2;
    }

    public Double getPrecio3() {
        return precio3;
    }

    public void setPrecio3(Double precio3) {
        this.precio3 = precio3;
    }

    public Double getPrecio4() {
        return precio4;
    }

    public void setPrecio4(Double precio4) {
        this.precio4 = precio4;
    }

    public Double getPrecio5() {
        return precio5;
    }

    public void setPrecio5(Double precio5) {
        this.precio5 = precio5;
    }

    public Double getPrecio() {
        return precio;
    }

    public void setPrecio(Double precio) {
        this.precio = precio;
    }

    public Categorias getCategorias() {
        return categorias;
    }

    public void setCategorias(Categorias categorias) {
        this.categorias = categorias;
    }

    public RealmList<Impuesto> getImpuestos() {
        return impuestos;
    }

    public void setImpuestos(RealmList<Impuesto> impuestos) {
        this.impuestos = impuestos;
    }
}
