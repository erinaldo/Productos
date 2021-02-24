package com.elephantworks.movilvennda.Modelos;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 23/07/2017.
 */
@RealmClass
public class Abono extends RealmObject implements RealmModel {
    @PrimaryKey
    private int idAbono;
    // 1 = Contado y 2 = Credito
    private int metodoPago;
    private String referencia;
    private Double monto;
    private int envio;

    public Abono(){super();}

    public Abono(int idAbono, int metodoPago, Double monto, String referencia, int envio) {
        this.idAbono = idAbono;
        this.metodoPago = metodoPago;
        this.monto = monto;
        this.referencia = referencia;
        this.envio = envio;
    }

    public int getIdAbono() {
        return idAbono;
    }

    public void setIdAbono(int idAbono) {
        this.idAbono = idAbono;
    }

    public int getMetodoPago() {
        return metodoPago;
    }

    public void setMetodoPago(int metodoPago) {
        this.metodoPago = metodoPago;
    }

    public Double getMonto() {
        return monto;
    }

    public void setMonto(Double monto) {
        this.monto = monto;
    }

    public String getReferencia() {
        return referencia;
    }

    public void setReferencia(String referencia) {
        this.referencia = referencia;
    }

    public int getEnvio() {
        return envio;
    }

    public void setEnvio(int envio) {
        this.envio = envio;
    }
}
