package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 04/06/2017.
 */
@RealmClass
public class PuntoVenta extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idPuntoVenta;
    private String numeroNegocio;
    private String nombreNegocio;
    private String telefono;
    private String celular;
    private String correoElectronico;

    private String calle;
    private String noExterior;
    private String noInterior;
    private String colonia;
    private String codigoPostal;
    private Float latitud;
    private Float longitud;

    /*Configuracion de Puntos de venta
    * estas configuraciones de subiran al movil*/
    private Boolean cerrado = false;
    private Boolean inventario = false;
    private Boolean impresoraActivo = false;
    private Boolean activo = true;

    public PuntoVenta(){super();}

    public PuntoVenta(Boolean activo, String calle, String celular, Boolean cerrado, String codigoPostal, String colonia, String correoElectronico, int idPuntoVenta, Boolean impresoraActivo, Boolean inventario, Float latitud, Float longitud, String noExterior, String noInterior, String nombreNegocio, String numeroNegocio, String telefono) {
        this.activo = activo;
        this.calle = calle;
        this.celular = celular;
        this.cerrado = cerrado;
        this.codigoPostal = codigoPostal;
        this.colonia = colonia;
        this.correoElectronico = correoElectronico;
        this.idPuntoVenta = idPuntoVenta;
        this.impresoraActivo = impresoraActivo;
        this.inventario = inventario;
        this.latitud = latitud;
        this.longitud = longitud;
        this.noExterior = noExterior;
        this.noInterior = noInterior;
        this.nombreNegocio = nombreNegocio;
        this.numeroNegocio = numeroNegocio;
        this.telefono = telefono;
    }

    public Boolean getActivo() {
        return activo;
    }

    public void setActivo(Boolean activo) {
        this.activo = activo;
    }

    public String getCalle() {
        return calle;
    }

    public void setCalle(String calle) {
        this.calle = calle;
    }

    public String getCelular() {
        return celular;
    }

    public void setCelular(String celular) {
        this.celular = celular;
    }

    public Boolean getCerrado() {
        return cerrado;
    }

    public void setCerrado(Boolean cerrado) {
        this.cerrado = cerrado;
    }

    public String getCodigoPostal() {
        return codigoPostal;
    }

    public void setCodigoPostal(String codigoPostal) {
        this.codigoPostal = codigoPostal;
    }

    public String getColonia() {
        return colonia;
    }

    public void setColonia(String colonia) {
        this.colonia = colonia;
    }

    public String getCorreoElectronico() {
        return correoElectronico;
    }

    public void setCorreoElectronico(String correoElectronico) {
        this.correoElectronico = correoElectronico;
    }

    public int getIdPuntoVenta() {
        return idPuntoVenta;
    }

    public void setIdPuntoVenta(int idPuntoVenta) {
        this.idPuntoVenta = idPuntoVenta;
    }

    public Boolean getImpresoraActivo() {
        return impresoraActivo;
    }

    public void setImpresoraActivo(Boolean impresoraActivo) {
        this.impresoraActivo = impresoraActivo;
    }

    public Boolean getInventario() {
        return inventario;
    }

    public void setInventario(Boolean inventario) {
        this.inventario = inventario;
    }

    public Float getLatitud() {
        return latitud;
    }

    public void setLatitud(Float latitud) {
        this.latitud = latitud;
    }

    public Float getLongitud() {
        return longitud;
    }

    public void setLongitud(Float longitud) {
        this.longitud = longitud;
    }

    public String getNoExterior() {
        return noExterior;
    }

    public void setNoExterior(String noExterior) {
        this.noExterior = noExterior;
    }

    public String getNoInterior() {
        return noInterior;
    }

    public void setNoInterior(String noInterior) {
        this.noInterior = noInterior;
    }

    public String getNombreNegocio() {
        return nombreNegocio;
    }

    public void setNombreNegocio(String nombreNegocio) {
        this.nombreNegocio = nombreNegocio;
    }

    public String getNumeroNegocio() {
        return numeroNegocio;
    }

    public void setNumeroNegocio(String numeroNegocio) {
        this.numeroNegocio = numeroNegocio;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }
}
