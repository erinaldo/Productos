package com.selling.movil.modelos;

/**
 * Created by Eduardo on 23/12/15.
 */
public class Anden {

    private String idRecibo;
    private String folio;
    private String anden;
    private String porcentajeRecibo;
    private String numPiezas;

    public Anden(String idRecibo, String folio, String anden, String porcentajeRecibo, String numPiezas) {
        this.idRecibo = idRecibo;
        this.folio = folio;
        this.anden = anden;
        this.porcentajeRecibo = porcentajeRecibo;
        this.numPiezas = numPiezas;
    }

    public String getIdRecibo() {
        return idRecibo;
    }

    public void setIdRecibo(String idRecibo) {
        this.idRecibo = idRecibo;
    }

    public String getFolio() {
        return folio;
    }

    public void setFolio(String folio) {
        this.folio = folio;
    }

    public String getAnden() {
        return anden;
    }

    public void setAnden(String anden) {
        this.anden = anden;
    }

    public String getPorcentajeRecibo() {
        return porcentajeRecibo;
    }

    public void setPorcentajeRecibo(String porcentajeRecibo) {
        this.porcentajeRecibo = porcentajeRecibo;
    }

    public String getNumPiezas() {
        return numPiezas;
    }

    public void setNumPiezas(String numPiezas) {
        this.numPiezas = numPiezas;
    }
}
