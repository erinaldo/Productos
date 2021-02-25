package com.selling.movil.modelos;

import io.realm.RealmObject;

/**
 * Created by Eduardo on 18/07/16.
 */
public class PedidoDetalle extends RealmObject {

    private String DOCClave;
    private String AREClave;
    private String Area;
    private String PROClave;
    private String Producto;
    private String productoCompara;
    private String NumParte;
    private String Alterno1;
    private String Alterno2;
    private String Alterno3;
    private String GTIN;
    private Double Cantidad;
    private Double Surtido;
    private Double Transito;
    private String UBCClave;
    private String Ubicacion;
    private String ubicacionCompara;
    private Integer Tiporechazo;
    private boolean activo;


    public String getDOCClave() {
        return DOCClave;
    }

    public void setDOCClave(String DOCClave) {
        this.DOCClave = DOCClave;
    }

    public String getAREClave() {
        return AREClave;
    }

    public void setAREClave(String AREClave) {
        this.AREClave = AREClave;
    }

    public String getArea() {
        return Area;
    }

    public void setArea(String area) {
        Area = area;
    }

    public String getPROClave() {
        return PROClave;
    }

    public void setPROClave(String PROClave) {
        this.PROClave = PROClave;
    }

    public String getProducto() {
        return Producto;
    }

    public void setProducto(String producto) {
        Producto = producto;
    }

    public String getProductoCompara() {
        return productoCompara;
    }

    public void setProductoCompara(String productoCompara) {
        this.productoCompara = productoCompara;
    }

    public String getNumParte() {
        return NumParte;
    }

    public void setNumParte(String numParte) {
        NumParte = numParte;
    }

    public String getAlterno1() {
        return Alterno1;
    }

    public void setAlterno1(String alterno1) {
        Alterno1 = alterno1;
    }

    public String getAlterno2() {
        return Alterno2;
    }

    public void setAlterno2(String alterno2) {
        Alterno2 = alterno2;
    }

    public String getAlterno3() {
        return Alterno3;
    }

    public void setAlterno3(String alterno3) {
        Alterno3 = alterno3;
    }

    public String getGTIN() {
        return GTIN;
    }

    public void setGTIN(String GTIN) {
        this.GTIN = GTIN;
    }

    public Double getCantidad() {
        return Cantidad;
    }

    public void setCantidad(Double cantidad) {
        Cantidad = cantidad;
    }

    public Double getSurtido() {
        return Surtido;
    }

    public void setSurtido(Double surtido) {
        Surtido = surtido;
    }

    public Double getTransito() {
        return Transito;
    }

    public void setTransito(Double transito) {
        Transito = transito;
    }

    public String getUBCClave() {
        return UBCClave;
    }

    public void setUBCClave(String UBCClave) {
        this.UBCClave = UBCClave;
    }

    public String getUbicacion() {
        return Ubicacion;
    }

    public void setUbicacion(String ubicacion) {
        Ubicacion = ubicacion;
    }

    public String getUbicacionCompara() {
        return ubicacionCompara;
    }

    public void setUbicacionCompara(String ubicacionCompara) {
        this.ubicacionCompara = ubicacionCompara;
    }

    public Integer getTiporechazo() {
        return Tiporechazo;
    }

    public void setTiporechazo(Integer tiporechazo) {
        Tiporechazo = tiporechazo;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }
}
