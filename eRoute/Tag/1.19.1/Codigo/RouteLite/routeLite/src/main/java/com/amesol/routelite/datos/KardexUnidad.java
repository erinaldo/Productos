package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class KardexUnidad extends Entidad{
	@Llave
	public String ProductoClave;
	
	@Llave
	public short PRUTipoUnidad;
		
	@Campo
	public float EntradaDisponible;

	@Campo
	public float EntradaNoDisponible;
	
	@Campo
	public float Salida;
}

