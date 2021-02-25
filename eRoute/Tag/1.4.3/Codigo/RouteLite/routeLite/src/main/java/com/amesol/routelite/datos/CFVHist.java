package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=3)
public class CFVHist extends Entidad {
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ClienteClave", tablaPadre=CLIFormaVenta.class)
	@Requerido
	public String ClienteClave;
	
	@Llave()	
	@LlaveForanea( nombreCampoForaneo="CFVTipo", tablaPadre=CLIFormaVenta.class)
	@Requerido
	public int CFVTipo;
	
	@Llave()	
	@Requerido
	public Date CFHFechaInicio;
	
	@Campo
	public float LimiteCredito;
	
	@Campo
	public int DiasCredito;
	
	@Campo 
	public boolean CapturaDias;
	
	@Campo
	@Requerido
	public boolean ValidaLimite;
	
	@Campo
	@Requerido
	public boolean ValidaPago;
	
	@Campo
	public boolean Enviado;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
}
