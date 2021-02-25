package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class CUOProducto extends Entidad{
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "CUOClave", tablaPadre = Cuota.class)
	public String CUOClave;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "ProductoClave", tablaPadre = Producto.class)
	public String ProductoClave;
	
	@Campo
	public float Minimo;
	
	@Campo
	public short Tipo;
	
	@Campo
	public short Estado;
	
	public String DescripcionCuota;
	public String NombreProducto;
}
