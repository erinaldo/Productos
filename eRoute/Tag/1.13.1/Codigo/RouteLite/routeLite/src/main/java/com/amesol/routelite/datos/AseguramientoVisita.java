package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class AseguramientoVisita extends Entidad {

	@Llave
	public String MCNClave;
	
	@Campo
	public int TipoAseguramiento;
	
	@Campo
	public int TipoContrasena;
	
	@Campo
	public String ContrasenaFija;
	
	@Campo
	public float LimiteGPS;
	
	@Campo
	public boolean EdoContraFija;
}
