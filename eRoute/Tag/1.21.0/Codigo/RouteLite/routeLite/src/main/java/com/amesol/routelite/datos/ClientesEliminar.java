package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=5)
public class ClientesEliminar extends Entidad {
	
	@Campo
	public String ClienteClave;
	
	@Campo
	public String FrecuenciaClave;
}
