package com.duxstar.dacza.actividades;

import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.act.ConsultarTraspaso;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.utilerias.KeyGen;
import com.duxstar.dacza.datos.Recarga;

import java.util.ArrayList;

/**
 * Created by Adriana on 01/06/2016.
 */
public class Recargas {

    public static Recarga generarRecarga(final StringBuilder byRefMensaje) throws ControlError, Exception
    {
        Usuario usuario = (Usuario) Sesion.get(Sesion.Campo.UsuarioActual);
        int tipoMovimiento = Enumeradores.TiposMovimientos.RECARGA_INVENTARIO;

        Recarga recarga = new Recarga();
        recarga.RecargaId = KeyGen.getId();
        recarga.AgenteId = usuario.UsuarioId;
        recarga.Folio = Folios.obtener(tipoMovimiento, byRefMensaje);
        recarga.FechaSolicitud = Generales.getFechaActual();
        recarga.Fase = Enumeradores.TiposFasesDocto.CAPTURA;
        recarga.MUsuarioId = usuario.UsuarioId;
        recarga.MFechaHora = Generales.getFechaHoraActual();
        recarga.Enviado = false;

        BDTerm.recuperar(recarga, RECDetalle.class);
        return recarga;
    }

    public static Recarga recuperarRecarga(String sRecargaId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        Recarga recarga = new Recarga();
        recarga.RecargaId = sRecargaId;
        BDTerm.recuperar(recarga);

        BDTerm.recuperar(recarga, RECDetalle.class);

        int partida = 1;

        for (RECDetalle det : recarga.RECDetalle)
        {
            if (det.ArticuloId != null) {
                Articulo art = new Articulo();
                art.ArticuloId = det.ArticuloId;
                BDTerm.recuperar(art);
                det.articulo = art;
            }
            det.recienAgregado = false;
            det.cantidadModificada = false;
            if (det.Partida > partida)
                partida = det.Partida;
        }

        recarga.MUsuarioId = usuario.UsuarioId;
        recarga.MFechaHora = Generales.getFechaHoraActual();
        recarga.Enviado = false;

        partida += 1;
        Sesion.set(Sesion.Campo.SiguientePartida, partida);

        return recarga;
    }

    public static void cancelarRecarga(String sRecargaId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        Recarga recarga = new Recarga();
        recarga.RecargaId = sRecargaId;
        BDTerm.recuperar(recarga);

        recarga.Fase = Enumeradores.TiposFasesDocto.CANCELADO;
        recarga.MUsuarioId = usuario.UsuarioId;
        recarga.MFechaHora = Generales.getFechaHoraActual();
        recarga.Enviado = false;

        BDTerm.guardarInsertar(recarga);
        BDTerm.commit();
    }

    public static void cerrarRecarga(String sRecargaId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        Recarga recarga = new Recarga();
        recarga.RecargaId = sRecargaId;
        BDTerm.recuperar(recarga);

        recarga.Fase = Enumeradores.TiposFasesDocto.CERRADO;
        recarga.MUsuarioId = usuario.UsuarioId;
        recarga.MFechaHora = Generales.getFechaHoraActual();
        recarga.Enviado = false;

        BDTerm.guardarInsertar(recarga);
        BDTerm.commit();
    }

    public static RECDetalle GenerarDetalleBusqueda(String sArticuloId, float Cantidad)
    {
        String sUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;

        RECDetalle recDetalle = new RECDetalle();
        recDetalle.ArticuloId = sArticuloId;
        recDetalle.Cantidad = Cantidad;
        recDetalle.Partida = (int)Sesion.get(Sesion.Campo.SiguientePartida);
        Sesion.set(Sesion.Campo.SiguientePartida, recDetalle.Partida + 1);
        recDetalle.MFechaHora = Generales.getFechaHoraActual();
        recDetalle.MUsuarioId = sUsuarioID;

        return recDetalle;
    }

    public static ConsultarTraspaso.VistaTraspasos[] obtenerTraspasos(String recargaId)throws Exception
    {
        ISetDatos traspasos = Consultas.ConsultasRecarga.obtenerTraspasos(recargaId);
        ArrayList<ConsultarTraspaso.VistaTraspasos> vTraspasos = new ArrayList<ConsultarTraspaso.VistaTraspasos>();

        if (traspasos != null) {
            while (traspasos.moveToNext()) {
                ConsultarTraspaso.VistaTraspasos traspaso = new ConsultarTraspaso.VistaTraspasos();
                traspaso.setTraspasoId(traspasos.getString("TraspasoId"));
                traspaso.setFolio(traspasos.getString("Folio"));
                traspaso.setFecha(traspasos.getDate("Fecha"));
                vTraspasos.add(traspaso);
            }
        }
        traspasos.close();

        return vTraspasos.toArray(new ConsultarTraspaso.VistaTraspasos[vTraspasos.size()]);
    }
}
