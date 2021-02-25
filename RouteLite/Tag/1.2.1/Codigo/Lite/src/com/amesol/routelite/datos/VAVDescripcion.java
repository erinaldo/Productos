package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class VAVDescripcion extends Entidad {

	@Llave
	@LlaveForanea( nombreCampoForaneo="VARCodigo", tablaPadre= VARValor.class)
	public String VARCodigo;
	
	@Llave
	@LlaveForanea( nombreCampoForaneo="VAVClave", tablaPadre= VARValor.class)
	public String VAVClave;
	
	@Campo
	public String Descripcion;
	
}
