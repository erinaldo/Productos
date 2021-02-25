package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class ClienteVentaMensual extends Entidad
{
	@Campo
	public String MCNClave;
	
	@Campo
	public String ClienteClave;
	
	@Campo
	public String Fecha;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public float MontoMensual;
	
	@Campo
	public Date MFechaHora;
	
}
