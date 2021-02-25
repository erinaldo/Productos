package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class ConfigEncuesta extends Entidad {
	@Llave()
	@Requerido
	public String CENClave;
	
	@Campo
	@Requerido
	public short Tipo;
	
	@Campo
	@Requerido
	public String Descripcion;
	
	@Campo
	public short Puntos;
	
	@Campo
	@Requerido
	public short Fase;
	
	@Campo
	public byte[] Icono;
	
	@Campo
	@Requerido
	public boolean HabilitarSalir;
}
