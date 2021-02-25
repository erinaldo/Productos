package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class Precio  extends Entidad{
	@Llave
	public String PrecioClave;
	@Campo
	public short Jerarquia;
	@Campo
	public String Nombre;
	@Campo
	public short TipoEstado;
}
