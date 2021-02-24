package com.elephantworks.movilvennda.Modelos;

import java.math.BigDecimal;

import io.realm.RealmModel;
import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;
import io.realm.annotations.RealmClass;

/**
 * Created by ldelatorre on 04/06/2017.
 */
@RealmClass
public class Staff extends RealmObject implements RealmModel {
    @PrimaryKey
    private int idStaff;
    private String numEmpleado;
    private String nombre;
    private String apellidos;
    private String pin;
    private String email;
    private boolean activo;
    private boolean autorizaCancelacion;
    private Double porcentajeDescuento;

    public Staff(){super();}

    public Staff(boolean activo, String apellidos, boolean autorizaCancelacion, String email, int idStaff, String nombre, String numEmpleado, String pin, Double porcentajeDescuento) {
        this.activo = activo;
        this.apellidos = apellidos;
        this.autorizaCancelacion = autorizaCancelacion;
        this.email = email;
        this.idStaff = idStaff;
        this.nombre = nombre;
        this.numEmpleado = numEmpleado;
        this.pin = pin;
        this.porcentajeDescuento = porcentajeDescuento;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public boolean getAutorizaCancelacion() {
        return autorizaCancelacion;
    }

    public void setAutorizaCancelacion(boolean autorizaCancelacion) {
        this.autorizaCancelacion = autorizaCancelacion;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getIdStaff() {
        return idStaff;
    }

    public void setIdStaff(int idStaff) {
        this.idStaff = idStaff;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getNumEmpleado() {
        return numEmpleado;
    }

    public void setNumEmpleado(String numEmpleado) {
        this.numEmpleado = numEmpleado;
    }

    public String getPin() {
        return pin;
    }

    public void setPin(String pin) {
        this.pin = pin;
    }

    public Double getPorcentajeDescuento() {
        return porcentajeDescuento;
    }

    public void setPorcentajeDescuento(Double porcentajeDescuento) {
        this.porcentajeDescuento = porcentajeDescuento;
    }


}
