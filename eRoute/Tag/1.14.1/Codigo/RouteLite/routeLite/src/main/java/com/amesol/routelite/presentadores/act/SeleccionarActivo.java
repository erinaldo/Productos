package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Solicitud;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActivo;

import java.util.HashMap;

/**
 * Created by Adriana on 26/12/2016.
 */
public class SeleccionarActivo extends Presentador {

    ISeleccionActivo mVista;
    String mAccion;
    boolean iniciarActividad;

    public SeleccionarActivo(ISeleccionActivo vista, String accion)
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

            ISetDatos dsActivos = obtenerActivos();
            if (dsActivos.getCount() > 0)
            {
                iniciarActividad = false;
                mVista.mostrarActivos(dsActivos);
            }
            else
            {
                mVista.mostrarError(Mensajes.get("E0982"));
            }
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }


    private ISetDatos obtenerActivos(){
        try {
            return Consultas2.ConsultasActivos.obtenerActivos(((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave);
        }
        catch(Exception e){
            return null;
        }
    }


}
