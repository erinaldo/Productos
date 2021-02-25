package com.amesol.routelite.actividades;


import java.util.ArrayList;

import com.amesol.routelite.actividades.Enumeradores.Esquema.TipoEsquema;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;

public class Esquemas {
	
	public static String ObtenerEsquemas(String sClave, int Tipo){
		String sEsquemas[] = new String[1];
		sEsquemas[0] = "";
		String sEsquemaIdPadre = "";
		ISetDatos dsEsquemas = null;
		if(Tipo==TipoEsquema.Cliente)
		{
		 dsEsquemas = Consultas.ConsultasClienteEsquema.obtenerIdEsquemaCte(sClave);
		}
		else if(Tipo==TipoEsquema.Producto)
		{
			dsEsquemas = Consultas.ConsultasProductoEsquema.obtenerIdEsquemaProducto(sClave);	
		}
			
		while(dsEsquemas.moveToNext()){
			sEsquemas[0] += "'" + dsEsquemas.getString("EsquemaId") + "',";			
			sEsquemaIdPadre = Consultas.ConsultasEsquema.obtenerIdEsquemaPadre(dsEsquemas.getString("EsquemaId"));
			ObtenerEsquemasPadre(sEsquemas, sEsquemaIdPadre);
		}
		if (sEsquemas[0].length() > 0)
			sEsquemas[0] = sEsquemas[0].substring(0, sEsquemas[0].length()-1);
		dsEsquemas.close();
		return sEsquemas[0];
	}
	
	public static void ObtenerEsquemasPadre(String sEsquemasId[], String sEsquemaId){
		String sEsquemaIdPadre = "";
		if (sEsquemaId != ""){
			sEsquemasId[0] += "'" + sEsquemaId + "',";
			sEsquemaIdPadre = Consultas.ConsultasEsquema.obtenerIdEsquemaPadre(sEsquemaId);
			ObtenerEsquemasPadre(sEsquemasId, sEsquemaIdPadre);
		}
	} 
	
	public static void ObtenerEsquemasPadre(String sEsquemasId, String sEsquemaId){
		String sEsquemaIdPadre = "";
		if (sEsquemaId != ""){
			sEsquemasId += "'" + sEsquemaId + "',";
			sEsquemaIdPadre = Consultas.ConsultasEsquema.obtenerIdEsquemaPadre(sEsquemaId);
			ObtenerEsquemasPadre(sEsquemasId, sEsquemaIdPadre);
		}
	} 

}
