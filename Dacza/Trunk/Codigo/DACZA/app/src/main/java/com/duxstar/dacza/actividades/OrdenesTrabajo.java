package com.duxstar.dacza.actividades;

import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.utilerias.KeyGen;

/**
 * Created by Adriana on 06/05/2016.
 */
public class OrdenesTrabajo {

    public static OrdenTrabajo generarOrden(final StringBuilder byRefMensaje) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);
        int tipoMovimiento = Enumeradores.TiposMovimientos.ORDEN_TRABAJO;

        OrdenTrabajo ordenTrabajo = new OrdenTrabajo();
        ordenTrabajo.OrdenId = KeyGen.getId();
        ordenTrabajo.Folio = Folios.obtener(tipoMovimiento, byRefMensaje);
        ordenTrabajo.FechaIni = Generales.getFechaActual();
        ordenTrabajo.FechaFin = Generales.getFechaActual();
        ordenTrabajo.Fase = Enumeradores.TiposFasesDocto.CAPTURA;
        ordenTrabajo.MUsuarioId = usuario.UsuarioId;
        ordenTrabajo.MFechaHora = Generales.getFechaHoraActual();
        ordenTrabajo.Enviado = false;

        return ordenTrabajo;
    }

    public static OrdenTrabajo recuperarOrden(String sOrdenId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        OrdenTrabajo ordenTrabajo =  new OrdenTrabajo();
        ordenTrabajo.OrdenId = sOrdenId;
        BDTerm.recuperar(ordenTrabajo);

        ordenTrabajo.MUsuarioId = usuario.UsuarioId;
        ordenTrabajo.MFechaHora = Generales.getFechaHoraActual();
        ordenTrabajo.Enviado = false;

        return ordenTrabajo;
    }

    public static OrdenTrabajo recuperarOrdenConDetalle(String sOrdenId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        OrdenTrabajo ordenTrabajo =  new OrdenTrabajo();
        ordenTrabajo.OrdenId = sOrdenId;
        BDTerm.recuperar(ordenTrabajo);

        BDTerm.recuperar(ordenTrabajo, ODTDetalle.class);
        for (ODTDetalle det : ordenTrabajo.ODTDetalle)
        {
            Articulo art = new Articulo();
            art.ArticuloId = det.ArticuloId;
            BDTerm.recuperar(art);
            det.articulo = art;
            det.recienAgregado = false;
            det.cantidadModificada = false;
        }

        return ordenTrabajo;
    }

    public static void cancelarOrden(String sOrdenId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        OrdenTrabajo ordenTrabajo =  new OrdenTrabajo();
        ordenTrabajo.OrdenId = sOrdenId;
        BDTerm.recuperar(ordenTrabajo);
        BDTerm.recuperar(ordenTrabajo, ODTDetalle.class);

        ordenTrabajo.Fase = Enumeradores.TiposFasesDocto.CANCELADO;
        ordenTrabajo.MUsuarioId = usuario.UsuarioId;
        ordenTrabajo.MFechaHora = Generales.getFechaHoraActual();
        ordenTrabajo.Enviado = false;

        for (ODTDetalle det : ordenTrabajo.ODTDetalle)
        {
            Inventario.ActualizarInventario(det.ArticuloId, det.Cantidad, Enumeradores.TiposMovimientoInv.ENTRADA);
        }

        BDTerm.guardarInsertar(ordenTrabajo);
        BDTerm.commit();
    }

    public static void cerrarOrden(String sOrdenId) throws ControlError, Exception
    {
        Usuario usuario = (Usuario)Sesion.get(Sesion.Campo.UsuarioActual);

        OrdenTrabajo ordenTrabajo =  new OrdenTrabajo();
        ordenTrabajo.OrdenId = sOrdenId;
        BDTerm.recuperar(ordenTrabajo);

        ordenTrabajo.Fase = Enumeradores.TiposFasesDocto.CERRADO;
        ordenTrabajo.MUsuarioId = usuario.UsuarioId;
        ordenTrabajo.MFechaHora = Generales.getFechaHoraActual();
        ordenTrabajo.Enviado = false;

        BDTerm.guardarInsertar(ordenTrabajo);
        BDTerm.commit();
    }

    public static ODTDetalle GenerarDetalleBusqueda(String sArticuloId, float Cantidad)
    {
        String sUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;

        ODTDetalle odtDetalle = new ODTDetalle();
        odtDetalle.ArticuloId = sArticuloId;
        odtDetalle.Cantidad = Cantidad;
        odtDetalle.Partida = (int)Sesion.get(Sesion.Campo.SiguientePartida);
        Sesion.set(Sesion.Campo.SiguientePartida, odtDetalle.Partida + 1);
        odtDetalle.MFechaHora = Generales.getFechaHoraActual();
        odtDetalle.MUsuarioId = sUsuarioID;
        odtDetalle.Enviado = false;

        return odtDetalle;
    }
}
