package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class ValorReferencia extends Entidad{
	@Llave
	public String VARCodigo;
}
