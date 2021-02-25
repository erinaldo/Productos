package com.amesol.routelite.presentadores.act;


import java.util.Date;
import java.util.HashMap;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;
import com.amesol.routelite.vistas.RecepcionInformacion;

public class SolicitarAgendaVendedor extends Presentador {

	ISolicitudAgendaVendedor mVista;
	
	public SolicitarAgendaVendedor(ISolicitudAgendaVendedor vista){
		mVista = vista;
		
	}
	
	@Override
	public void iniciar() {
		
	}

	public void solicitarAgenda() {		
		if (validarFechas()){
			HashMap<String,Date> parametros = new HashMap();
			parametros.put("FechaIni", mVista.getFechaInicial());
			parametros.put("FechaFin",mVista.getFechaFinal());
			mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_OBTENER_BD_VENDEDOR,parametros);
		}
	}
	
	private boolean  validarFechas(){
		if (mVista.getFechaInicial().after(mVista.getFechaFinal())){
			mVista.mostrarAdvertencia(Mensajes.get("E0377"));
			return false;
		}		
		return true;	
	}

}
