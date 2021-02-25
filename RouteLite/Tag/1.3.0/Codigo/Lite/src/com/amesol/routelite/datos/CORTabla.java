package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class CORTabla extends Entidad{
	@Llave
	public String CORId;
	
	@Llave
	public String COTId;
	
	@Campo 
	public String Nombre;
}
