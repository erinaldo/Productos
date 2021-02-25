package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class VARValor extends Entidad {
	
	@Llave
	public String VARCodigo;
	
	@Llave
	public String VAVClave;
	
	@Campo
	public String Grupo;
	
	@Campo
	public short Estado;

}
