package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class ProductoUnidad extends Entidad {

	@Llave()
	@LlaveForanea( nombreCampoForaneo="ProductoClave", tablaPadre=Producto.class)
	public String ProductoClave;
	
	@Llave()
	public short PRUTipoUnidad;
	
	@Campo
	public String CodigoBarras;
	
	@Campo
	public short TipoEstado;
	
	@Campo
	public float KgLts;
	
	@Campo
	public float Volumen;
}
