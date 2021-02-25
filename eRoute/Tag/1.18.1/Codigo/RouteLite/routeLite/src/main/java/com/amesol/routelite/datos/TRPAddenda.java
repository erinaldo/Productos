package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden=1)
public class TRPAddenda extends Entidad {

	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProd.class)
	public String TransProdID;

	@Llave
	@LlaveForanea(nombreCampoForaneo = "ADDID", tablaPadre = AddendaDetalle.class)
	public String ADDId;
	
	@Campo
	@Requerido
	public String Valor;

	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
