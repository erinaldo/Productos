package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class UsuarioSustituto extends Entidad
{
	@Llave
	public String SustitucionId;
	
	@LlaveForanea(nombreCampoForaneo = "DiaClave", tablaPadre = Dia.class)
	public String DiaClave;
	
	@LlaveForanea(nombreCampoForaneo = "VendedorId", tablaPadre = Vendedor.class)
	public String VendedorId;
	
	@Campo
	public String USUIdTitular;
	
	@Campo
	public String USUIdSustituto;
	
	@Campo
	public Date FechaHoraInicio;
	
	@Campo
	public Date FechaHoraFin;
	
	@Campo
	public boolean Enviado;
	
	public String Clave;
	
}
