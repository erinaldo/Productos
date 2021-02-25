package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=7)
public class PuntoGPS extends Entidad{

	@Llave
	public String PuntoGPSId;
	
	@Campo
	public float CoordenadaX;
	
	@Campo
	public float CoordenadaY;
	
	@Campo
	@LlaveForanea(nombreCampoForaneo = "RUTClave", tablaPadre = Ruta.class)
	public String RUTClave;
	
	@Campo
	@LlaveForanea(nombreCampoForaneo = "DiaClave", tablaPadre = Dia.class)
	public String DiaClave;
	
	@Campo
	@LlaveForanea(nombreCampoForaneo = "VisitaClave", tablaPadre = Visita.class)
	public String VisitaClave;
	

	
	@Campo
	@LlaveForanea(nombreCampoForaneo = "DiaClave1", tablaPadre = Dia.class)
	public String DiaClave1;
	
	

	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	
}