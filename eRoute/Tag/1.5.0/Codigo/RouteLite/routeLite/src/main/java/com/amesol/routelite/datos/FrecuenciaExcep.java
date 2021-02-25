package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class FrecuenciaExcep extends Entidad{

	@Llave
	public String FrecuenciaExcepID;
	
	@Campo
	public short Dia;
	
	@Campo
	public short Mes;
	
	@Campo
	public short Anio;
	
	@Campo
	public short TipoAplicacion;
	
	@Campo
	public short TipoFecha;
}
