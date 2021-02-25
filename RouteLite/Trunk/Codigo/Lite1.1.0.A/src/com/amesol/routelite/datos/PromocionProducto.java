package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class PromocionProducto extends Entidad {

	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionClave", tablaPadre=Promocion.class)
	public String PromocionClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ProductoClave", tablaPadre=Producto.class)
	public String ProductoClave;
	
	@Campo
	public int Jerarquia;
	
	@Campo
	public short TipoEstado;
}
