package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=3)
public class ProductoDetalle extends Entidad {

	@Llave()
	@LlaveForanea( nombreCampoForaneo="ProductoClave", tablaPadre=ProductoUnidad.class)
	public String ProductoClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="PRUTipoUnidad", tablaPadre=ProductoUnidad.class)
	public short PRUTipoUnidad;
	
	@Llave()
	public String ProductoDetClave;
	
	@Campo
	public boolean Prestamo;
	
	@Campo
	public short Factor;
}
