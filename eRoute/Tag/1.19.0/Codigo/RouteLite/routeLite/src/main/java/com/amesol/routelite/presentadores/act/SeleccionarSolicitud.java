package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.Solicitud;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaSolicitud;
import com.amesol.routelite.presentadores.interfaces.ISeleccionSolicitud;

import java.util.HashMap;

/**
 * Created by Adriana on 26/12/2016.
 */
public class SeleccionarSolicitud extends Presentador {

    ISeleccionSolicitud mVista;
    String mAccion;
    boolean iniciarActividad;

    public SeleccionarSolicitud(ISeleccionSolicitud vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }

    @Override
    public void iniciar()
    {
        try
        {
            mVista.iniciar();
            //mVista.mostrarSolicitudes(obtenerSolicitudes());

            if (existenSolicitudes())
            {
                iniciarActividad = false;
                mVista.mostrarSolicitudes(obtenerSolicitudes());
            }
            else
            {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                mVista.finalizar();
                mVista.iniciarActividadConResultado(ICapturaSolicitud.class, 0, null);
            }
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    private boolean existenSolicitudes(){
        try {
            return Consultas2.ConsultasSolicitud.existenSolicitudes();
        }catch(Exception e){
            return false;
        }
    }

    private ISetDatos obtenerSolicitudes(){
        try {
            return Consultas2.ConsultasSolicitud.obtenerSolicitudes();
        }
        catch(Exception e){
            return null;
        }
    }

    public boolean validarEliminar(String sSOLId){
        return !Transacciones.Solicitudes.validarEnviado(sSOLId);
    }

    public void eliminar(String sSOLId){
        Transacciones.Solicitudes.eliminarSolicitud(sSOLId);
    }

    public void actualizarLista(){
        mVista.mostrarSolicitudes(obtenerSolicitudes());
    }

    public void modificar(String sSOLId){
        mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        mVista.finalizar();
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("SOLId", sSOLId);
        mVista.iniciarActividadConResultado(ICapturaSolicitud.class, 0, null, oParametros);
        mVista.finalizar();
    }
}
