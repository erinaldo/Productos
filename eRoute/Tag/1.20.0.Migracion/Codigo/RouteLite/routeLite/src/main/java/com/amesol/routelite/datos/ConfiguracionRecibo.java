package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class ConfiguracionRecibo extends Entidad{
	@Llave
	public String CORId;
	
	@Campo
	public short TipoRecibo;
	
	@Campo
	public short TipoEstado;
}
