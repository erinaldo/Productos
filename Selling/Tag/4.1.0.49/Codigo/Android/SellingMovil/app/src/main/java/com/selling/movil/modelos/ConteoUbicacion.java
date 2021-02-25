package com.selling.movil.modelos;

import org.json.JSONException;
import org.json.JSONObject;

public class ConteoUbicacion {

    private String USRClave;
    private String CONClave;
    private String ALMClave;
    private String Almacen;
    private String Area;
    private String Estructura;
    private String Nivel;
    private int Columna;
    private String UBCClave;
    private String Ubicacion;
    private int Estado;

    public ConteoUbicacion(String USRClave, String CONClave, String ALMClave, String Almacen, String Area, String Estructura, String Nivel, int Columna, String UBCClave, String Ubicacion, int Estado) {
        this.USRClave = USRClave;
        this.CONClave = CONClave;
        this.ALMClave = ALMClave;
        this.Almacen = Almacen;
        this.Area = Area;
        this.Estructura = Estructura;
        this.Nivel = Nivel;
        this.Columna = Columna;
        this.UBCClave = UBCClave;
        this.Ubicacion = Ubicacion;
        this.Estado = Estado;
    }

    public String getUSRClave() {
        return USRClave;
    }
    public void setUSRClave(String USRClave) {
        this.USRClave = USRClave;
    }

    public String getCONClave() {
        return CONClave;
    }
    public void setCONClave(String CONClave) {
        this.CONClave = CONClave;
    }

    public String getALMClave() {
        return ALMClave;
    }
    public void setALMClave(String ALMClave) {
        this.ALMClave = ALMClave;
    }

    public String getAlmacen() {
        return Almacen;
    }
    public void setAlmacen(String Almacen) {
        this.Almacen = Almacen;
    }

    public String getArea() {
        return Area;
    }
    public void setArea(String Area) {
        this.Area = Area;
    }

    public String getEstructura() {
        return Estructura;
    }
    public void setEstructura(String Estructura) {
        this.Estructura = Estructura;
    }

    public String getNivel() {
        return Nivel;
    }
    public void setNivel(String Nivel) {
        this.Nivel = Nivel;
    }

    public int getColumna() {
        return Columna;
    }
    public void setColumna(int Columna) {
        this.Columna = Columna;
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
    public void setUbicacion(String Ubicacion) {
        this.Ubicacion = Ubicacion;
    }

    public int getEstado() {
        return Estado;
    }
    public void setEstado(int Estado) {
        this.Estado = Estado;
    }

    public String toJSON(){
        JSONObject jsonObject= new JSONObject();
        try {
            jsonObject.put("USRClave", getUSRClave());
            jsonObject.put("CONClave", getCONClave());
            jsonObject.put("ALMClave", getALMClave());
            jsonObject.put("Almacen", getAlmacen());
            jsonObject.put("Area", getArea());
            jsonObject.put("Estructura", getEstructura());
            jsonObject.put("Nivel", getNivel());
            jsonObject.put("Columna", getColumna());
            jsonObject.put("UBCClave", getUBCClave());
            jsonObject.put("Ubicacion", getUbicacion());
            jsonObject.put("Estado", getEstado());
            return jsonObject.toString();
        } catch (JSONException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
            return "";
        }

    }
}
