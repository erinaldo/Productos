package com.duxstar.dacza.presentadores.act;

//import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.widget.Toast;

////import com.duxstar.dacza.actividades.Mensajes;
//import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.duxstar.dacza.actividades.ValorReferencia;
import com.duxstar.dacza.actividades.ValoresReferencia;
//import com.amesol.routelite.datos.Vendedor;
//import com.amesol.routelite.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.ACTIVIDADES;
import com.duxstar.dacza.presentadores.Presentador;
//import com.amesol.routelite.presentadores.interfaces.ICapturaDeposito;
//import com.amesol.routelite.presentadores.interfaces.ICapturaInicioFinJornada;
//import com.amesol.routelite.presentadores.interfaces.ICapturaKilometraje;
//import com.amesol.routelite.presentadores.interfaces.ICapturaPreLiquidacion;
//import com.amesol.routelite.presentadores.interfaces.IConsultaIndicadores;
import com.duxstar.dacza.presentadores.interfaces.IConsultaInvenario;
//import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;
//import com.amesol.routelite.presentadores.interfaces.IRecepcionInformacion;
//import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionActividades;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionOrden;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionRecarga;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
//import com.amesol.routelite.presentadores.interfaces.ISeleccionAgenda;
//import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
//import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;

public class SeleccionarActividades extends Presentador
{
	ISeleccionActividades mVista;

	public SeleccionarActividades(ISeleccionActividades vista)
	{
		mVista = vista;
	}

	@Override
	public void iniciar()
	{
		mVista.mostrarActividades(ValoresReferencia.getValores("ACTAGENTE"), "Agente");
	}

	public void seleccionar(ValorReferencia valorReferencia)
	{
        if (valorReferencia.getVarcodigo().equals("ACTAGENTE") && valorReferencia.getVavclave().equals("1")) {
            mVista.iniciarActividad(ISeleccionOrden.class, false);
        }
		else if (valorReferencia.getVarcodigo().equals("ACTAGENTE") && valorReferencia.getVavclave().equals("2")) {
            mVista.mostrarActividades(ValoresReferencia.getValores("ACTINVENT"), "Inventario");
        }
        else if (valorReferencia.getVarcodigo().equals("ACTAGENTE") && valorReferencia.getVavclave().equals("3")) {
            HashMap<String, String> oParametros = new HashMap<String, String>();
            oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_AGENTE));
            mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_TERMINAL, oParametros);
        }
        else if (valorReferencia.getVarcodigo().equals("ACTINVENT") && valorReferencia.getVavclave().equals("1")) {
            mVista.iniciarActividad(IConsultaInvenario.class, false);
        }
        else if (valorReferencia.getVarcodigo().equals("ACTINVENT") && valorReferencia.getVavclave().equals("2")) {
            mVista.iniciarActividad(ISeleccionRecarga.class, false);
        }
        else if (valorReferencia.getVarcodigo().equals("ACTINVENT") && valorReferencia.getVavclave().equals("3")) {
            mVista.iniciarActividad(ISeleccionDevolucion.class, false);
        }
        else if (valorReferencia.getVarcodigo().equals("ACTINVENT") && valorReferencia.getVavclave().equals("4")) {
            HashMap<String, String> oParametros = new HashMap<String, String>();
            oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_INVENTARIO));
            mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_TERMINAL, oParametros);
        }
	}

	/*public void obtenerInventarioEnLinea()
	{
		HashMap<String, String> parametros = new HashMap<String, String>();
		String tablasActualizar = "''Inventario''";
		parametros.put("Tablas", tablasActualizar);
		mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO, parametros);
	}*/

	/*
	 * // mVista.iniciarActividad(IImpresionTicket.class, //
	 * Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA, null, // false);
	 * try { // here is the comment at the end of this class String valor =
	 * Envio.getDatosEnviar
	 * ("paroDataSet",Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR
	 * ,Cliente.class); Envio.enviarTodo(valor); } catch (Exception e) { // TODO
	 * Auto-generated catch block e.printStackTrace(); }
	 */
	public void atras(String grupo)
	{
		if (grupo.equals("Agente"))
			mVista.finalizar();
		else if (grupo.equals("Inventario"))
            mVista.mostrarActividades(ValoresReferencia.getValores("ACTAGENTE"), "Agente");
	}

	public void mostrarMensaje(String mensaje)
	{
		mVista.mostrarError(mensaje);
	}

}
