package com.selling.movil.interfaces;

import com.selling.movil.modelos.Reubicacion;

import java.util.ArrayList;

/**
 * Created by Eduardo on 02/10/15.
 */
public interface OnLeerCodigoMaterialListener {

    public void onCodigoMaterialLeido(String ...parametros);
    public void setMaterialAnt(String... parametros);
    public String getMaterialAnt();
    public ArrayList<Reubicacion> getArrayReubicacion();
}
