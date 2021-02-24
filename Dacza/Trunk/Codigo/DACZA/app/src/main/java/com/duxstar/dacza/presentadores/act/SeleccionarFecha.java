package com.duxstar.dacza.presentadores.act;

import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionActividades;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionFecha;

import java.util.Calendar;
import java.util.Date;

public class SeleccionarFecha extends Presentador {
    private ISeleccionFecha mVista;
    private ArchivoConfiguracion configuracion;
    private String mAccion;

    public SeleccionarFecha(ISeleccionFecha vista, String accion)
    {
        mVista = vista;
        this.mAccion = accion;
    }

    @Override
    public void iniciar() {
        try {
            mVista.iniciar();
            configuracion = new ArchivoConfiguracion(mVista);
            mVista.setFecha(configuracion.getValor(CampoConfiguracion.FECHA).toString());
        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void Continuar(){
        configuracion.iniciarEdicion();
        configuracion.setValor(CampoConfiguracion.FECHA, mVista.getFecha());
        configuracion.commit();
        mVista.iniciarActividad(ISeleccionActividades.class, false);
        mVista.finalizar();
    }
}
