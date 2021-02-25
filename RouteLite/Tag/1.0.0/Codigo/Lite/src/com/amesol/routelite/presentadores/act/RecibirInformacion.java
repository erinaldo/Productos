package com.amesol.routelite.presentadores.act;

import java.util.HashMap;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IRecepcionInformacion;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;

public class RecibirInformacion extends Presentador {

IRecepcionInformacion mVista;
private String mAccion; 
	
	public RecibirInformacion(IRecepcionInformacion vista, String accion){
		mVista = vista;
		mAccion = accion;
	}
	@Override
	public void iniciar() {
		if((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL))){
			mVista.presentarOpciones(ValoresReferencia.getValores("ACTROL","RecTerminal"),"RecTerminal");
		}else if((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_VENDEDOR))){
			mVista.presentarOpciones(ValoresReferencia.getValores("ACTROL","RecVendedor"),"RecVendedor");
		}
	}
	
	public void recibirInformacion(){
		HashMap<String, String> parametros = new HashMap<String,String>();
		String tablasActualizar = mVista.obtenerTablas();
		if (tablasActualizar.equals("")){
			mVista.mostrarAdvertencia(Mensajes.get("E0161", Mensajes.get("XOpcion")));
			return;
		}
		parametros.put("Tablas", tablasActualizar );
		if((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL))){
			mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL,parametros);		
		}else if((mAccion!= null)&&(mAccion.equals(Enumeradores.Acciones.ACCION_RECIBIR_INFO_VENDEDOR))){
			mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_VENDEDOR, parametros);		
		}
			
	}	

/*
	public void atras(String grupo) {
		if(grupo.equals("Principales")){
			mVista.finalizar();
		}else if(grupo.equals("Actualizar")){
			mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL","Principales"),"Principales");
		}
	}
*/
}
