package com.duxstar.dacza.presentadores.act;


import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IBuscaArticulo;
import com.duxstar.dacza.utilerias.Generales;

public class BuscarArticulo extends Presentador {

    IBuscaArticulo mVista;
    String mAccion;
    //HashMap<String, Object> oParametros;

    public BuscarArticulo(IBuscaArticulo vista, String accion) {
        mVista = vista;
        mAccion = accion;
    }

    @Override
    public void iniciar() {
        try {
            mVista.iniciar();
            if (mVista.obtenerArticulos() != null) {
                mVista.mostrarArticulos(mVista.obtenerArticulos());
            }
        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }
    }
}
