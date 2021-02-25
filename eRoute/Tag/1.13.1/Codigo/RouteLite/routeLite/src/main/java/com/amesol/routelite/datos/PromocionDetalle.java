package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class PromocionDetalle extends Entidad {

	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionClave", tablaPadre=Promocion.class)
	public String PromocionClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="EsquemaID", tablaPadre=Esquema.class)
	public String EsquemaID;
	
	@Campo
	public short TipoEstado;
	
}