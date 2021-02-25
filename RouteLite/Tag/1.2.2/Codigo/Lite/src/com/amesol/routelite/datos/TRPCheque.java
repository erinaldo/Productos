package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class TRPCheque extends Entidad {

	@Llave
	@Requerido
	public String TransProdID;
	
	@Llave()
	@LlaveForanea(nombreCampoForaneo="ABNId", tablaPadre=Abono.class)
	@Requerido
	public String ABNId;
	
	@Campo
	@Requerido
	public float AbnCheque;
	
	@Campo
	@Requerido
	public float AbnChequePosfechado;
		
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
		
	@Campo
	public boolean Enviado;
}
