package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.generales.Entidad;

public class DESRegla extends Entidad {
	@Llave
	@LlaveForanea( nombreCampoForaneo="DescuentoClave", tablaPadre=Descuento.class)
	public String DescuentoClave;
	@Llave
	@LlaveForanea( nombreCampoForaneo="ProductoClave", tablaPadre=Producto.class)
	public String ProductoClave;
	@Campo
	public short TipoEstado;
}
