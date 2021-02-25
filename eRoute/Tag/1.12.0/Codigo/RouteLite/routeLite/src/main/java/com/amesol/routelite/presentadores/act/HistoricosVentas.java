package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Solicitud;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IHistoricoVentas;

import java.util.LinkedList;
import java.util.SortedMap;
import java.util.TreeMap;

public class HistoricosVentas extends Presentador {

    IHistoricoVentas mVista;
    String mAccion;
    boolean iniciarActividad;

    public HistoricosVentas(IHistoricoVentas vista, String accion){
        try {
            mVista = vista;
            mAccion = accion;
        }catch (Exception e){
            mVista.mostrarError(e.getMessage());
        }
    }

    @Override
    public void iniciar(){
        try {
            mVista.ActualizaLVVentas();
            mVista.iniciar();
        } catch (Exception e) {
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
