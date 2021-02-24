package com.elephantworks.movilvennda.Utilerias;

import android.content.Context;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;

import com.elephantworks.movilvennda.Modelos.Venta;

/**
 * Created by ldelatorre on 04/06/2017.
 */
public class Session {

    private SharedPreferences prefs;

    public Session(Context cntx) {
        // TODO Auto-generated constructor stub
        prefs = PreferenceManager.getDefaultSharedPreferences(cntx);
    }

    public void setUsuario(String usename) {
        prefs.edit().putString("usuario", usename).commit();
        //prefsCommit();
    }

    public String getUsuario() {
        String usename = prefs.getString("usuario","");
        return usename;
    }

    public void setNombreUsuario(String nombre) {
        prefs.edit().putString("nombreUsuario", nombre).commit();
        //prefsCommit();
    }

    public String getNombreUsuario() {
        String usename = prefs.getString("nombreUsuario","");
        return usename;
    }

    public void setCorreoElectronicoStaff(String correo) {
        prefs.edit().putString("correoElectronicoStaff", correo).commit();
        //prefsCommit();
    }

    public String getCorreoElectronicoStaff() {
        String usename = prefs.getString("correoElectronicoStaff","");
        return usename;
    }

    public void setPuntoVenta(int puntoVenta) {
        prefs.edit().putInt("puntoVentaSeleccinado", puntoVenta).commit();
        //prefsCommit();
    }

    public int getPuntoVenta() {
        int usename = prefs.getInt("puntoVentaSeleccinado",0);
        return usename;
    }

    public void setIdAperturaCierre(int puntoVenta) {
        prefs.edit().putInt("idAperturaCierre", puntoVenta).commit();
        //prefsCommit();
    }

    public int getIdAperturaCierre() {
        return prefs.getInt("idAperturaCierre",0);
    }

    public void setIdClienteVentas(int cliente) {
        prefs.edit().putInt("idCliente", cliente).commit();
        //prefsCommit();
    }

    public int getIdClienteVentas() {
        int usename = prefs.getInt("idCliente",0);
        return usename;
    }

    public void setIdEmpresa(int idEmpresa) {
        prefs.edit().putInt("idEmpresa", idEmpresa).commit();
        //prefsCommit();
    }

    public int getIdEmpresa() {
        int usename = prefs.getInt("idEmpresa",0);
        return usename;
    }

    public void setDevolucion(String folio){
        prefs.edit().putString("devolucion", folio).commit();
    }

    public String getDevolucion(){
        return prefs.getString("devolucion","0");
    }


}
