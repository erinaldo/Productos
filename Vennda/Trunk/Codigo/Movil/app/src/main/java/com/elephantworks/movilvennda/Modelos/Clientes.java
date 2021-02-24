package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 11/06/2017.
 */
@RealmClass
public class Clientes extends RealmObject implements RealmModel {

    @PrimaryKey
    private int idCliente;
    private String clave;
    private String razonSocial;
    private String rfc;
    private String domicilio;
    private String colonia;
    private String cp;
    private int diasCredito;
    private double limiteCredito;
    private double creditoActual;
    private String email;
    private int listaPrecios;
    private String telefonoCelular;
    private int alta;
    private int envio;

    public Clientes(){super();}

    public Clientes(String clave, String colonia, String cp, int diasCredito, String domicilio, String email, int idCliente, int listaPrecios, String razonSocial, String rfc, String telefonoCelular,int alta, double limiteCredito, double creditoActual, int envio) {
        this.clave = clave;
        this.colonia = colonia;
        this.cp = cp;
        this.diasCredito = diasCredito;
        this.domicilio = domicilio;
        this.email = email;
        this.idCliente = idCliente;
        this.listaPrecios = listaPrecios;
        this.razonSocial = razonSocial;
        this.rfc = rfc;
        this.telefonoCelular = telefonoCelular;
        this.limiteCredito = limiteCredito;
        this.creditoActual = creditoActual;
        this.envio = envio;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public String getColonia() {
        return colonia;
    }

    public void setColonia(String colonia) {
        this.colonia = colonia;
    }

    public String getCp() {
        return cp;
    }

    public void setCp(String cp) {
        this.cp = cp;
    }

    public int getDiasCredito() {
        return diasCredito;
    }

    public void setDiasCredito(int diasCredito) {
        this.diasCredito = diasCredito;
    }

    public String getDomicilio() {
        return domicilio;
    }

    public void setDomicilio(String domicilio) {
        this.domicilio = domicilio;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(int idCliente) {
        this.idCliente = idCliente;
    }

    public int getListaPrecios() {
        return listaPrecios;
    }

    public void setListaPrecios(int listaPrecios) {
        this.listaPrecios = listaPrecios;
    }

    public String getRazonSocial() {
        return razonSocial;
    }

    public void setRazonSocial(String razonSocial) {
        this.razonSocial = razonSocial;
    }

    public String getRfc() {
        return rfc;
    }

    public void setRfc(String rfc) {
        this.rfc = rfc;
    }

    public String getTelefonoCelular() {
        return telefonoCelular;
    }

    public void setTelefonoCelular(String telefonoCelular) {
        this.telefonoCelular = telefonoCelular;
    }

    public void setAlta(int alta){this.alta = alta;}

    public int getAlta(){return alta;}

    public double getCreditoActual() {
        return creditoActual;
    }

    public void setCreditoActual(double creditoActual) {
        this.creditoActual = creditoActual;
    }

    public double getLimiteCredito() {
        return limiteCredito;
    }

    public void setLimiteCredito(double limiteCredito) {
        this.limiteCredito = limiteCredito;
    }

    public int getEnvio() {
        return envio;
    }

    public void setEnvio(int envio) {
        this.envio = envio;
    }
}
