package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.ActivoClienteHist;
import com.amesol.routelite.datos.ActivoDetalle;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Solicitud;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaActivo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActivo;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.SeleccionActivo;

import java.util.HashMap;

/**
 * Created by Adriana on 26/12/2016.
 */
public class SeleccionarActivo extends Presentador {

    ISeleccionActivo mVista;
    String mAccion;
    boolean iniciarActividad;
    SeleccionActivo.VistaActivos[] activos;

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
            mostrarActivos();
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void mostrarActivos(){
        try
        {
            activos = Consultas2.ConsultasActivos.obtenerActivos(((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave);
            if (activos.length > 0)
            {
                iniciarActividad = false;
                mVista.mostrarActivos(activos);
            }
            else {
                mVista.habilitarCrear(Consultas2.ConsultasActivos.existenActivos());
            }
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void asignar(String idElectronico){
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("IdElectronico", idElectronico);
        mVista.iniciarActividadConResultado(ICapturaActivo.class, 0, Enumeradores.Acciones.ACCION_ASIGNAR_ACTIVO, oParametros);
        mVista.finalizar();
    }

    public void modificar(String activoDetalleID)
    {
        try {
            //mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            //mVista.finalizar();
            HashMap<String, String> oParametros = new HashMap<String, String>();
            oParametros.put("ActivoDetalleID", activoDetalleID);
            mVista.iniciarActividadConResultado(ICapturaActivo.class, 0, Enumeradores.Acciones.ACCION_MODIFICAR_ACTIVO, oParametros);
            mVista.finalizar();
        }
        catch (Exception e)
        {

        }
    }

    public boolean desasignar(String activoDetalleID, String comentario){
        try {
            ActivoDetalle activoDetalle = new ActivoDetalle();
            activoDetalle.ActivoDetalleID = activoDetalleID;
            BDVend.recuperar(activoDetalle);
            if (activoDetalle.isRecuperado()) {
                ActivoClienteHist activoClienteHist = new ActivoClienteHist();
                activoClienteHist.ActivoClienteHistID = KeyGen.getId();
                activoClienteHist.ActivoDetalleID = activoDetalleID;
                activoClienteHist.ClienteClave = activoDetalle.ClienteClave;
                activoClienteHist.Fecha = Generales.getFechaHoraActual();
                activoClienteHist.TipoMotivo = 2;
                activoClienteHist.Comentario = comentario;
                activoClienteHist.VisitaClave = ((Visita)Sesion.get(Sesion.Campo.VisitaActual)).VisitaClave;
                activoClienteHist.DiaClave = ((Visita)Sesion.get(Sesion.Campo.VisitaActual)).DiaClave;
                activoClienteHist.Enviado = false;
                activoClienteHist.MFechaHora = Generales.getFechaHoraActual();
                activoClienteHist.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(activoClienteHist);

                activoDetalle.ClienteClave = null;
                activoDetalle.Enviado = false;
                activoDetalle.MFechaHora = Generales.getFechaHoraActual();
                activoDetalle.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(activoDetalle);
            }
        }catch (Exception e){
            return false;
        }
        return true;
    }

    /*private ISetDatos obtenerActivos(){
        try {
            return Consultas2.ConsultasActivos.obtenerActivos(((Cliente) Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave);
        }
        catch(Exception e){
            return null;
        }
    }*/


}
