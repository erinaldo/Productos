package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class PromocionAplicacion extends Entidad {

	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionClave", tablaPadre=PromocionRegla.class)
	public String PromocionClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionReglaID", tablaPadre=PromocionRegla.class)
	public String PromocionReglaID;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ProductoClave", tablaPadre=ProductoUnidad.class)
	public String ProductoClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="PRUTipoUnidad", tablaPadre=ProductoUnidad.class)
	public short PRUTipoUnidad;
	
	@Campo
	public int Cantidad;
	
	@Campo
	public short TipoEstado;
}
