package com.duxstar.dacza.presentadores.act;

import com.duxstar.dacza.actividades.OrdenesTrabajo;
import com.duxstar.dacza.actividades.Recargas;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.Recarga;
import com.duxstar.dacza.datos.Traspaso;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.basedatos.SetDatos;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IConsultaOrden;
import com.duxstar.dacza.presentadores.interfaces.IConsultaTraspaso;
import com.duxstar.dacza.vistas.ConsultaTraspaso;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Adriana on 09/06/2016.
 */
public class ConsultarTraspaso extends Presentador {

    public static class VistaTraspasos
    {
        private String TraspasoId;
        private String Folio;
        private Date Fecha;

        public VistaTraspasos(){}

        public VistaTraspasos(String traspasoId, String folio, Date fecha)
        {
            TraspasoId = traspasoId;
            Folio = folio;
            Fecha = fecha;
        }

        public String getTraspasoId()
        {
            return TraspasoId;
        }

        public void setTraspasoId(String traspasoId) { TraspasoId = traspasoId; }

        public String getFolio()
        {
            return Folio;
        }

        public void setFolio(String folio)
        {
            Folio = folio;
        }

        public Date getFecha()
        {
            return Fecha;
        }

        public void setFecha(Date fecha)
        {
            Fecha = fecha;
        }
    }

    public static class VistaDetalles
    {

    }

    IConsultaTraspaso mVista;
    String mAccion;
    String sRecargaId;

    public ConsultarTraspaso(IConsultaTraspaso vista)
    {
        mVista = vista;
    }

    public ConsultarTraspaso(IConsultaTraspaso vista, String accion)
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

            ConsultarTraspaso.VistaTraspasos[] traspasos = Recargas.obtenerTraspasos(sRecargaId);
            String folios = "";
            String fechas = "";
            String ids = "";

            for (VistaTraspasos vistaTraspasos : traspasos) {
                folios = folios.concat(vistaTraspasos.getFolio() + "\n");
                fechas = fechas.concat(new SimpleDateFormat("dd/MM/yyyy").format(vistaTraspasos.getFecha()) + "\n");
                ids = ids.concat("'" + vistaTraspasos.getTraspasoId() + "',");
            }

            if (folios.length() > 0)
                folios = folios.substring(0, folios.length()-1);
            if (fechas.length() > 0)
                fechas = fechas.substring(0, fechas.length()-1);
            if (ids.length() > 0)
                ids = ids.substring(0, ids.length()-1);

            Recarga recarga = new Recarga();
            recarga.RecargaId = sRecargaId;
            BDTerm.recuperar(recarga);

            ConsultaTraspaso.ListaTRPDetalle[] detalles = Consultas.ConsultasRecarga.obtenerTRPDetalle(ids);

            mVista.setFolio(folios);
            mVista.setFecha(fechas);
            mVista.setFolioRecarga(recarga.Folio);


            mVista.refrescarProductos(detalles);
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void setRecargaId(String recargaId){
        sRecargaId = recargaId;
    }
}
