package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class DESDetalle extends Entidad {
	@Llave
	@LlaveForanea( nombreCampoForaneo="DescuentoClave", tablaPadre=Descuento.class)
	public String DescuentoClave;
	@Llave
	@LlaveForanea( nombreCampoForaneo="EsquemaId", tablaPadre=Esquema.class)
	public String EsquemaId;
	@Campo
	public int Jerarquia;
}
