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
		HashMap<String, Object> parametros = new HashMap<String,Object>();
		boolean bRecargas[] = new boolean[1];
		bRecargas[0] = false;
        boolean bPrecios[] = new boolean[1];
        bPrecios[0] = false;
        boolean bCobranza[] = new boolean[1];
        bCobranza[0] = false;
		String tablasActualizar = mVista.obtenerTablas(bRecargas, bPrecios, bCobranza);
		if (tablasActualizar.equals("")){
			mVista.mostrarAdvertencia(Mensajes.get("E0161", Mensajes.get("XOpcion")));
			return;
		}
		parametros.put("Tablas", tablasActualizar );
		parametros.put("Recargas", bRecargas[0]);
        parametros.put("Precios", bPrecios[0]);
        parametros.put("Cobranza", bCobranza[0]);
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
