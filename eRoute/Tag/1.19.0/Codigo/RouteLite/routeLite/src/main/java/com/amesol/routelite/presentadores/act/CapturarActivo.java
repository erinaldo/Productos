package com.amesol.routelite.presentadores.act;

import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Activo;
import com.amesol.routelite.datos.ActivoClienteHist;
import com.amesol.routelite.datos.ActivoDetalle;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.MERDetalle;
import com.amesol.routelite.datos.MercadeoMarca;
import com.amesol.routelite.datos.MercadeoProducto;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaActivo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActivo;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.Vista;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.SortedMap;
import java.util.TreeMap;

public class CapturarActivo  extends Presentador {
    ICapturaActivo mVista;
    String mAccion;
    String clienteClave;
    String diaClave;
    String visitaClave;
    String activoDetalleID = "";
    String idElectronico = "";
    short tipoActivo = -1;
    String activoDetalleIDNuevo = "";

    ActivoDetalle activoDetalle = null;
    Activo activo = null;

    public CapturarActivo(ICapturaActivo vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }

    public void setActivoDetalleID(String sActivoDetalleID){
        activoDetalleID = sActivoDetalleID;
    }

    public void setIdElectronico(String sIdElectronico){
        idElectronico = sIdElectronico;
    }

    public void setTipoActivo(short nTipoActivo){
        tipoActivo = nTipoActivo;
        activo = null;
    }

    public String getActivoDetalleID(){
        if (activoDetalle == null)
            return activoDetalleIDNuevo;
        else
            return activoDetalle.ActivoDetalleID;
    }

    @Override
    public void iniciar()
    {
        try
        {
            if (mAccion.equals(Enumeradores.Acciones.ACCION_MODIFICAR_ACTIVO)){
                activoDetalle = new ActivoDetalle();
                activoDetalle.ActivoDetalleID = activoDetalleID;
                BDVend.recuperar(activoDetalle);

                if (activoDetalle.isRecuperado()){
                    activo = new Activo();
                    activo.ActivoClave = activoDetalle.ActivoClave;
                    BDVend.recuperar(activo);

                    mVista.setIdElectronico(activoDetalle.IdElectronico);
                    mVista.setAltura(activo.Altura);
                    mVista.setAncho(activo.Ancho);
                    mVista.setProfundidad(activo.Profundidad);
                    mVista.setComentario(activoDetalle.Comentario);
                    if (activoDetalle.Imagen != null && !activoDetalle.Imagen.equals(""))
                        mVista.setImagen(activoDetalle.Imagen);

                    if (activoDetalle.ClienteClave != null && !activoDetalle.ClienteClave.equals(((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave)){
                        Cliente oCte = new Cliente();
                        oCte.ClienteClave = activoDetalle.ClienteClave;
                        BDVend.recuperar(oCte);
                        mVista.setNotaAsignacion(oCte.Clave + " " + oCte.RazonSocial);
                    }
                    else
                        mVista.setNotaAsignacion("");
                }
            }else {
                activoDetalleIDNuevo = KeyGen.getId();
                mVista.setIdElectronico(idElectronico);
                mVista.setNotaAsignacion("");
            }

        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }

    }

    public void initSpinner(Spinner spinner)
    {
        try
        {
            LinkedList<VistaSpinner> oValores;
            ArrayAdapter<VistaSpinner> vAdapter;
            String mensaje = "";
            if (activo == null)
                mensaje =  Mensajes.get("XSeleccionarOpcion");
            switch (spinner.getId())
            {
                case R.id.spnTipo:
                    oValores = obtenerValores("ACITIPO", null, mensaje);
                    vAdapter = new ArrayAdapter<VistaSpinner>((Vista) mVista, android.R.layout.simple_spinner_item, oValores);
                    vAdapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
                    spinner.setAdapter(vAdapter);
                    if (activo != null) {
                        for (int i = 0; i < spinner.getCount(); i++) {
                            if (((VistaSpinner) spinner.getItemAtPosition(i)).id.equals(String.valueOf(activo.Tipo))) {
                                spinner.setSelection(i);
                                break;
                            }
                        }
                       spinner.setEnabled(false);
                    }
                    break;
                case R.id.spnNombre:
                    //spinner.setAdapter(null);
                    LinkedList<VistaSpinner> oActivos;
                    if (activo != null)
                        oActivos = obtenerActivos(activo.Tipo, activo.ActivoClave);
                    else
                        oActivos = obtenerActivos(tipoActivo, "");

                    vAdapter = new ArrayAdapter<VistaSpinner>((Vista) mVista, android.R.layout.simple_spinner_item, oActivos);
                    vAdapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
                    spinner.setAdapter(vAdapter);

                    if (activo != null)
                        spinner.setEnabled(false);

                    break;
                case R.id.spnEstado:
                    oValores = obtenerValores("ACIFASE", null, mensaje);
                    vAdapter = new ArrayAdapter<VistaSpinner>((Vista) mVista, android.R.layout.simple_spinner_item, oValores);
                    vAdapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
                    spinner.setAdapter(vAdapter);
                    if (activoDetalle != null) {
                        for (int i = 0; i < spinner.getCount(); i++) {
                            if (((VistaSpinner) spinner.getItemAtPosition(i)).id.equals(String.valueOf(activoDetalle.TipoFase))) {
                                spinner.setSelection(i);
                                break;
                            }
                        }
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void obtenerDatosActivo(String activoClave){
        try {
            activo = new Activo();
            activo.ActivoClave = activoClave;
            BDVend.recuperar(activo);
            if (activo.isRecuperado()){
                mVista.setAltura(activo.Altura);
                mVista.setAncho(activo.Ancho);
                mVista.setProfundidad(activo.Profundidad);
            }
        }catch(Exception e){}
    }

    public boolean validarCaptura(){
        if (mVista.getTipo() == -1){
            mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("ACITipo")));
            mVista.setFocus("TIPO");
            return false;
        }

        if (mVista.getClave().equals("")){
            mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("ACINombre")));
            mVista.setFocus("NOMBRE");
            return false;
        }

        if (mVista.getTipoFase() == -1){
            mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("ACITipoFase")));
            mVista.setFocus("TIPOFASE");
            return false;
        }

        return true;
    }

    public boolean huboCambios(){
        try {
            if (activoDetalle != null) {
                if (mVista.getTipoFase() != activoDetalle.TipoFase)
                    return true;
                if (!mVista.getComentario().equals(activoDetalle.Comentario))
                    return true;
                if (mVista.getTomoFoto())
                    return true;
            } else {
                if (mVista.getTipo() != -1 || mVista.getTipoFase() != -1)
                    return true;
                if (!mVista.getComentario().equals(""))
                    return true;
                if (mVista.getTomoFoto())
                    return true;

            }
        }catch(Exception ex){
            return false;
        }

        return false;
    }

    public boolean grabar(){
        try {
            boolean bAsignacion = false;
            boolean bCrearHistoricoAnt = false;
            String sClienteClaveAnt = "";
            if (!huboCambios()){
                if (activoDetalle != null && (activoDetalle.ClienteClave != null && activoDetalle.ClienteClave.equals(((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave)))
                    return true;
            }

            if (activoDetalle == null){
                activoDetalle = new ActivoDetalle();
                activoDetalle.ActivoDetalleID = activoDetalleIDNuevo;
                activoDetalle.ActivoClave = activo.ActivoClave;
                activoDetalle.IdElectronico = idElectronico;
                activoDetalle.TipoEstado = 1;
                bAsignacion = true;
            }
            else{
                if (activoDetalle.ClienteClave == null)
                    bAsignacion = true;
                if (activoDetalle.ClienteClave != null && !activoDetalle.ClienteClave.equals(((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave)){
                    bAsignacion = true;
                    bCrearHistoricoAnt = true;
                    sClienteClaveAnt = activoDetalle.ClienteClave;
                }
            }
            activoDetalle.ClienteClave = ((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave;
            activoDetalle.TipoFase = mVista.getTipoFase();
            activoDetalle.Comentario = mVista.getComentario();
            if (mVista.getTomoFoto())
                activoDetalle.Imagen = activoDetalle.ActivoDetalleID; // + ".jpg";
            activoDetalle.Enviado = false;
            activoDetalle.MFechaHora = Generales.getFechaHoraActual();
            activoDetalle.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
            BDVend.guardarInsertar(activoDetalle);

            if (bCrearHistoricoAnt){
                ActivoClienteHist ach1 = new ActivoClienteHist();
                ach1.ActivoClienteHistID = KeyGen.getId();
                ach1.ActivoDetalleID = activoDetalle.ActivoDetalleID;
                ach1.ClienteClave = sClienteClaveAnt;
                ach1.Fecha = Generales.getFechaHoraActual();
                ach1.TipoMotivo = 2; //Desasignacion
                ach1.Comentario = Mensajes.get("I0330").replace("$0$", ((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).Clave);
                ach1.VisitaClave = ((Visita)Sesion.get(Sesion.Campo.VisitaActual)).VisitaClave;
                ach1.DiaClave = ((Visita)Sesion.get(Sesion.Campo.VisitaActual)).DiaClave;
                ach1.Enviado = false;
                ach1.MFechaHora = Generales.getFechaHoraActual();
                ach1.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(ach1);
            }

            //if (bCrearHistorico){
            ActivoClienteHist activoClienteHist = new ActivoClienteHist();
            activoClienteHist.ActivoClienteHistID = KeyGen.getId();
            activoClienteHist.ActivoDetalleID = activoDetalle.ActivoDetalleID;
            activoClienteHist.ClienteClave = ((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave;
            activoClienteHist.Fecha = Generales.getFechaHoraActual();
            activoClienteHist.TipoMotivo = (short)(bAsignacion ? 1 : 3); //Asignación o Actualizacion(cambio de fase, comentario o imagen)
            activoClienteHist.Comentario =  mVista.getComentario();
            activoClienteHist.VisitaClave = ((Visita)Sesion.get(Sesion.Campo.VisitaActual)).VisitaClave;
            activoClienteHist.DiaClave = ((Visita)Sesion.get(Sesion.Campo.VisitaActual)).DiaClave;
            activoClienteHist.Enviado = false;
            activoClienteHist.MFechaHora = Generales.getFechaHoraActual();
            activoClienteHist.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
            BDVend.guardarInsertar(activoClienteHist);
            //}
            return true;

        }catch(Exception ex){
            mVista.mostrarError(ex.getMessage());
        }
        return false;
    }

    public static LinkedList<VistaSpinner> obtenerValores(String varCodigo, String vavClave, String sMensaje)
    {
        try {
            LinkedList<VistaSpinner> valores = new LinkedList<VistaSpinner>();

            ValorReferencia[] var;
            var = ValoresReferencia.getValores(varCodigo);

            SortedMap<Integer, ValorReferencia> sm = new TreeMap<Integer, ValorReferencia>();
            if (!sMensaje.equals(""))
                valores.add(new VistaSpinner("-1", sMensaje));

            if (var != null && var.length > 0) {
                for (ValorReferencia v : var) {
                    if (vavClave == null || v.getVavclave().equals(vavClave))
                        sm.put(Integer.valueOf(v.getVavclave()), v);
                }
                for (ValorReferencia v : sm.values()) {
                    valores.add(new VistaSpinner(v.getVavclave(), v.getDescripcion()));
                }
            }

            return valores;
        }catch (Exception e){
            return null;
        }
    }

    public static LinkedList<VistaSpinner> obtenerActivos(short tipo, String activoClave){
        try{
            LinkedList<VistaSpinner> valores = new LinkedList<VistaSpinner>();
            ISetDatos activos = Consultas2.ConsultasActivos.obtenerActivos(tipo, activoClave);
            while (activos.moveToNext()) {
                valores.add(new VistaSpinner(activos.getString("ActivoClave"), activos.getString("Descripcion")));
            }
            return valores;
        }catch (Exception e){
            return null;
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
