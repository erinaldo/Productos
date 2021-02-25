package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class CENClienteNuevo extends Entidad {
	@Llave()
	@LlaveForanea( nombreCampoForaneo="CENClave", tablaPadre=ConfigEncuesta.class)
	@Requerido
	public String CENClave;
	
	@Campo
	@Requerido
	public short Puntos;
	
	@Campo
	@Requerido
	public Date IniAplicacion;
	
	@Campo
	@Requerido
	public Date FinAplicacion;
	
}
