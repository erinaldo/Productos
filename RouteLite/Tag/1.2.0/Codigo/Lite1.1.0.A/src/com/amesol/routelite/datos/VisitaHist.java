package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 4)
public class VisitaHist extends Entidad{
	
	@Llave
	public String VisitaHistId;
	
	@Campo
	public String VisitaClave;
	
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
