package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Solicitud;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaSolicitud;
import com.amesol.routelite.utilerias.Generales;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.SortedMap;
import java.util.TreeMap;

/**
 * Created by Adriana on 26/12/2016.
 */
public class CapturarSolicitud extends Presentador {

    ICapturaSolicitud mVista;
    String mAccion;
    boolean iniciarActividad;
    Solicitud oSolicitud;
    ModuloMovDetalle moduloMovDetalle;
    String sSOLId;

    public CapturarSolicitud(ICapturaSolicitud vista, String accion)
    {
        try {
            mVista = vista;
            mAccion = accion;
        }
        catch (Exception e)
        {
            //errorFinalizar = true;
            //mVista.mostrarError(e);
            mVista.mostrarError(e.getMessage());
        }

    }

    @Override
    public void iniciar()
    {
        try
        {
            if (mVista.getEsNuevo()) {
                String sModuloMovDetalleClave = (String) Sesion.get(Sesion.Campo.ModuloMovDetalleClave);
                moduloMovDetalle = new ModuloMovDetalle();
                moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
                BDVend.recuperar(moduloMovDetalle);

                StringBuilder byRefMensaje = new StringBuilder();
                oSolicitud = Transacciones.Solicitudes.generarSolicitud(moduloMovDetalle, byRefMensaje);
                if (byRefMensaje.length() > 0) {
                    mVista.mostrarAdvertencia(byRefMensaje.toString());
                    //return;
                }
                byRefMensaje = null;

                mVista.setFolio(oSolicitud.Folio);
                mVista.setTiposPeticion(obtenerValores("SOLPETIC", ""));
                mVista.setTiposArea(obtenerValores("SOLTAREA", ""));
            }
            else{
                oSolicitud = new Solicitud();
                oSolicitud.SOLId = sSOLId;
                BDVend.recuperar(oSolicitud);

                mVista.setTiposPeticion(obtenerValores("SOLPETIC", ""));
                mVista.setTiposArea(obtenerValores("SOLTAREA", ""));
                mVista.setFolio(oSolicitud.Folio);
                mVista.setTipoPeticion(oSolicitud.TipoPeticion);
                mVista.setTipoArea(oSolicitud.TipoArea);
                mVista.setConcepto(oSolicitud.Concepto);
                mVista.setComentario(oSolicitud.Comentario);
            }


            mVista.iniciar();

        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void setSOLId(String sSOLId){
        this.sSOLId = sSOLId;
    }

    private LinkedList<VistaSpinner> obtenerValores(String varCodigo, String gruposExcepcion) throws Exception
    {
        LinkedList<VistaSpinner> valores = new LinkedList<VistaSpinner>();

        ValorReferencia[] var;

        //Obtener todos los valores excepto
        if (gruposExcepcion == null || gruposExcepcion.length()<=0 ){
            var = ValoresReferencia.getValores(varCodigo);
        }else{
            var = ValoresReferencia.getValores(varCodigo, null,gruposExcepcion);
        }

        SortedMap<Integer, ValorReferencia> sm = new TreeMap<Integer,ValorReferencia>();
        if (var != null && var.length >0) {
            for (ValorReferencia v: var) {
                sm.put(Integer.valueOf(v.getVavclave()), v);
            }
            for (ValorReferencia v: sm.values()){
                valores.add(new VistaSpinner(v.getVavclave() , v.getDescripcion()));
            }
        }

        return valores;
    }

    public void guardar()
    {
        try
        {
            oSolicitud.TipoPeticion = (short)mVista.getTipoPeticion();
            oSolicitud.TipoArea = (short)mVista.getTipoArea();
            oSolicitud.Concepto = mVista.getConcepto();
            oSolicitud.Comentario = mVista.getComentario();
            oSolicitud.Enviado = false;

            BDVend.guardarInsertar(oSolicitud);

            if (mVista.getEsNuevo()) {
                String sModuloMovDetalleClave = (String) Sesion.get(Sesion.Campo.ModuloMovDetalleClave);
                Folios.confirmar(sModuloMovDetalleClave);
            }
            BDVend.commit();

            mVista.finalizar();
        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

    }

    public static class VistaSpinner
    {
        String id;
        String nombre;

        // Constructor
        public VistaSpinner(String id, String nombre)
        {
            super();
            this.id = id;
            this.nombre = nombre;
        }

        @Override
        public String toString()
        {
            return nombre;
        }

        public String getId()
        {
            return id;
        }
    }

}
