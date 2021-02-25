package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IHistoricoEstadisticas;

public class HistoricosEstadisticas extends Presentador {

    IHistoricoEstadisticas mVista;
    String mAccion;
    boolean iniciarActividad;

    public HistoricosEstadisticas(IHistoricoEstadisticas vista, String accion){
        try {
            mVista = vista;
            mAccion = accion;
        }catch (Exception e){
            mVista.mostrarError(e.getMessage());
        }
    }

    @Override
    public void iniciar(){
        try{
            mVista.actualizarEstadisticas(0);
            mVista.iniciar();
        }catch (Exception e){
            mVista.mostrarError(e.getMessage());
        }
    }

    public void guardar(){
        try{
            mVista.finalizar();
        }catch (Exception e){
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }
}
