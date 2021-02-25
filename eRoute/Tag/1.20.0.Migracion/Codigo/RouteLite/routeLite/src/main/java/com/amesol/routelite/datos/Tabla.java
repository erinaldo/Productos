package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;

@TablaDef
public class Tabla {

	@Llave
	public String TablaId;
	
	@Campo
	public String Nombre;
	
	@Campo
	public short TipoBase;
	
	@Campo
	public short Grupo;
	
	
}
