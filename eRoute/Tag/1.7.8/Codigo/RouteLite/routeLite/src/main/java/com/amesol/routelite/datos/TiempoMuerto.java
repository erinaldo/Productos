package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 6)
public class TiempoMuerto extends Entidad{
	@Llave
	public String TIMId;
	
	@Campo
	public int TipoMotivo;
	
	@Campo
	public String DiaClave;
	
	@Campo
	public String RUTClave;
	
	@Campo
	public Date FechaHoraInicial;
	
	@Campo
	public Date FechaHoraFinal;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
