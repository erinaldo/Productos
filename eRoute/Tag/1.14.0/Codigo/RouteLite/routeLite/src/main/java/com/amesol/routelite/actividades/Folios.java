package com.amesol.routelite.actividades;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Formatter;

import com.amesol.routelite.datos.FolioReservacion;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.Generales;

public class Folios {
	
	public static String Obtener(String moduloMovDetClave, final StringBuilder byRefMensaje ) throws Exception{		
		FolioReservacion folioReservacion = Consultas.ConsultasFolios.obtenerPropiedadesFolio(true, moduloMovDetClave);
		return Obtener(folioReservacion, byRefMensaje);
	}
	
	public static String Obtener(int tipoModulo , final StringBuilder byRefMensaje) throws Exception{
		FolioReservacion folioReservacion = Consultas.ConsultasFolios.obtenerPropiedadesFolio(true, tipoModulo);
		return Obtener(folioReservacion, byRefMensaje);
	}

	private static String Obtener(FolioReservacion folioReservacion, final StringBuilder byRefMensaje) throws Exception{
		int iConsecutivo = 1;
		String sFolio = "";
				
		if (folioReservacion != null){
			iConsecutivo = folioReservacion.Inicio + folioReservacion.Usados;
			ISetDatos folioDetalle = Consultas.ConsultasFolios.obtenerFolioDetalle(folioReservacion.FolioId);
			
			if(folioDetalle != null){
				int iTipoContenido = 0;
				String sContenido = "";
				while(folioDetalle.moveToNext()){
					iTipoContenido = folioDetalle.getInt("TipoContenido");
					sContenido = folioDetalle.getString("Formato");
					switch(iTipoContenido){
					case Enumeradores.Folio.TiposContenidoFolio.Constante :
						sFolio += sContenido;
						break;
					case Enumeradores.Folio.TiposContenidoFolio.Incremental:
						Formatter fmt = new Formatter();
						sFolio += fmt.format("%0" +  sContenido.length() + "d" , iConsecutivo);
						break;
					}
				}
				folioDetalle.close();			
			} else{
				throw new Exception(Mensajes.get("E0207"));
			}
			
			if (sFolio.length()<=0){
				byRefMensaje.append(Mensajes.get("I0033")) ;
				
				SimpleDateFormat sdf = new SimpleDateFormat("HHmmss");    
				String currentDateTimeString = sdf.format(new Date());
				
				sFolio = currentDateTimeString;
			}				
		}
		return sFolio;		
	}
	
	public static ArrayList<String> ObtenerVarios(String moduloMovDetClave, int cantidad, String byRefMensaje) throws Exception{
		
		int iConsecutivo = 1;
		String sFolio = "";
		ArrayList<String> sFolios = new ArrayList<String>();
		
		FolioReservacion folioReservacion = Consultas.ConsultasFolios.obtenerPropiedadesFolio(true, moduloMovDetClave);
		if (folioReservacion != null){
			iConsecutivo = folioReservacion.Inicio + folioReservacion.Usados;
			ISetDatos folioDetalle = Consultas.ConsultasFolios.obtenerFolioDetalle(folioReservacion.FolioId);
			
			if(folioDetalle != null){
				for(int i = 0; i < cantidad; i++){
					iConsecutivo = -1;
					sFolio = "";
					folioDetalle.moveToFirst();
					if(folioReservacion.Inicio + folioReservacion.Usados <= folioReservacion.Fin){
						iConsecutivo = folioReservacion.Inicio + folioReservacion.Usados;
					}else{
						if(folioReservacion.Usados < ((folioReservacion.Fin - folioReservacion.Inicio) + 1)){
							iConsecutivo = folioReservacion.Inicio + folioReservacion.Usados;
						}
					}
					if(iConsecutivo >= 0){
						int iTipoContenido = 0;
						String sContenido = "";
						do{
							iTipoContenido = folioDetalle.getInt("TipoContenido");
							sContenido = folioDetalle.getString("Formato");
							switch(iTipoContenido){
							case Enumeradores.Folio.TiposContenidoFolio.Constante :
								sFolio += sContenido;
								break;
							case Enumeradores.Folio.TiposContenidoFolio.Incremental:
								Formatter fmt = new Formatter();
								sFolio += fmt.format("%0" +  sContenido.length() + "d" , iConsecutivo);
								break;
							}
						}while(folioDetalle.moveToNext());
					}
					if(sFolio != ""){
						folioReservacion.Usados += 1;
					}else{
						byRefMensaje = Mensajes.get("I0033");
						SimpleDateFormat sdf = new SimpleDateFormat("HHmmss");    
						String currentDateTimeString = sdf.format(new Date());
						sFolio = currentDateTimeString;
					}
					sFolios.add(sFolio);
					//sFolios[i] = sFolio;
				}
				folioDetalle.close();
			}else{
				throw new Exception(Mensajes.get("E0207"));
			}
		}
		
		return sFolios;
	}
	
	public static void confirmar(String moduloMovDetClave) throws Exception{
		FolioReservacion folioReservacion = Consultas.ConsultasFolios.obtenerPropiedadesFolio(true, moduloMovDetClave);
		BDVend.recuperar(folioReservacion); //recuperar para poder modificarlo y guardarlo
		folioReservacion.Usados++;
		if((folioReservacion.Fin - folioReservacion.Inicio) + 1 == folioReservacion.Usados)
			folioReservacion.TipoEstado = 0;
		folioReservacion.MFechaHora = Generales.getFechaHoraActual();
		folioReservacion.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		folioReservacion.Enviado = false;
		BDVend.guardarInsertar(folioReservacion);
	}

	public static void confirmar(int tipoModulo) throws Exception{
		FolioReservacion folioReservacion = Consultas.ConsultasFolios.obtenerPropiedadesFolio(true, tipoModulo);
		BDVend.recuperar(folioReservacion); //recuperar para poder modificarlo y guardarlo
		folioReservacion.Usados++;
		if((folioReservacion.Fin - folioReservacion.Inicio) + 1 == folioReservacion.Usados)
			folioReservacion.TipoEstado = 0;
		folioReservacion.MFechaHora = Generales.getFechaHoraActual();
		folioReservacion.MUsuarioID = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		folioReservacion.Enviado = false;
		BDVend.guardarInsertar(folioReservacion);
	}

}
