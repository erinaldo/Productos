package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class ProductoEsquema extends Entidad {

	@Llave()
	@LlaveForanea( nombreCampoForaneo="ProductoClave", tablaPadre=Producto.class)
	public String ProductoClave;
	
	@Llave()
	public String EsquemaId;
	
	
}
