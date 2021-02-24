package com.duxstar.dacza.actividades;

import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.DEVDetalle;
import com.duxstar.dacza.datos.Devolucion;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.utilerias.KeyGen;

/**
 * Created by Adriana on 01/06/2016.
 */
public class Devoluciones {

    public static Devolucion generarDevolucion(final StringBuilder byRefMensaje) throws ControlError, Exception
    {
        Usuario usuario = (Usuario) Sesion.get(Sesion.Campo.UsuarioActual);
        int tipoMovimiento = Enumeradores.TiposMovimientos.DEVOLUCION_INVENTARIO;

        Devolucion devolucion = new Devolucion();
        devolucion.DevolucionId = KeyGen.getId();
        devolucion.AgenteId = usuario.UsuarioId;
        devolucion.Folio = Folios.obtener(tipoMovimiento, byRefMensaje);
        devolucion.Fecha = Generales.getFechaActual();
        devolucion.Fase = Enumeradores.TiposFasesDocto.CAPTURA;
        devolucion.MUsuarioId = usuario.UsuarioId;
        devolucion.MFechaHora = Generales.getFechaHoraActual();
        devolucion.Enviado = false;

        BDTerm.recuperar(devolucion, DEVDetalle.class);
        return devolucion;
    }

    public static Devolucion recuperarDevolucion(String sDevolucionId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        Devolucion devolucion = new Devolucion();
        devolucion.DevolucionId = sDevolucionId;
        BDTerm.recuperar(devolucion);

        BDTerm.recuperar(devolucion, DEVDetalle.class);
        int partida = 1;

        for (DEVDetalle det : devolucion.DEVDetalle)
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

        devolucion.MUsuarioId = usuario.UsuarioId;
        devolucion.MFechaHora = Generales.getFechaHoraActual();
        devolucion.Enviado = false;

        partida += 1;
        Sesion.set(Sesion.Campo.SiguientePartida, partida);

        return devolucion;
    }

    public static void cancelarDevolucion(String sDevolucionId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        Devolucion devolucion = new Devolucion();
        devolucion.DevolucionId = sDevolucionId;
        BDTerm.recuperar(devolucion);
        BDTerm.recuperar(devolucion, DEVDetalle.class);

        devolucion.Fase = Enumeradores.TiposFasesDocto.CANCELADO;
        devolucion.MUsuarioId = usuario.UsuarioId;
        devolucion.MFechaHora = Generales.getFechaHoraActual();
        devolucion.Enviado = false;

        for (DEVDetalle det : devolucion.DEVDetalle)
        {
            Inventario.ActualizarInventario(det.ArticuloId, det.Cantidad, Enumeradores.TiposMovimientoInv.ENTRADA);
        }

        BDTerm.guardarInsertar(devolucion);
        BDTerm.commit();
    }

    public static void cerrarDevolucion(String sDevolucionId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        Devolucion devolucion = new Devolucion();
        devolucion.DevolucionId = sDevolucionId;
        BDTerm.recuperar(devolucion);

        devolucion.Fase = Enumeradores.TiposFasesDocto.CERRADO;
        devolucion.MUsuarioId = usuario.UsuarioId;
        devolucion.MFechaHora = Generales.getFechaHoraActual();
        devolucion.Enviado = false;

        BDTerm.guardarInsertar(devolucion);
        BDTerm.commit();
    }

    public static DEVDetalle GenerarDetalleBusqueda(String sArticuloId, float Cantidad)
    {
        String sUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;

        DEVDetalle devDetalle = new DEVDetalle();
        devDetalle.ArticuloId = sArticuloId;
        devDetalle.Cantidad = Cantidad;
        devDetalle.Partida = (int)Sesion.get(Sesion.Campo.SiguientePartida);
        Sesion.set(Sesion.Campo.SiguientePartida, devDetalle.Partida + 1);
        devDetalle.MFechaHora = Generales.getFechaHoraActual();
        devDetalle.MUsuarioId = sUsuarioID;
        devDetalle.Enviado = false;

        return devDetalle;
    }
}
