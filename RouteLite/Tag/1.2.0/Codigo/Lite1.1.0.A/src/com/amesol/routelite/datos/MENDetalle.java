package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class MENDetalle extends Entidad {

	@Llave
	public String MENClave;
	
	@Campo
	public String Descripcion;
}
