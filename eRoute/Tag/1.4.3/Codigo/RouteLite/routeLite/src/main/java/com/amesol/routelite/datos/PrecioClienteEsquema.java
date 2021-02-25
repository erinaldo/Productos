package com.amesol.routelite.datos;


import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class PrecioClienteEsquema  extends Entidad{
	@Llave
	public String PrecioClave;
	@Llave
	public String EsquemaId;
	@Llave 
	public String ModuloMovDetalleClave;
}
