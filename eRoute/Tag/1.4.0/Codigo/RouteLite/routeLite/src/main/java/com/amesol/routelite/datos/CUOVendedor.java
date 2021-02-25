package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class CUOVendedor extends Entidad{

	@Llave
	@LlaveForanea(nombreCampoForaneo = "CUOClave", tablaPadre = Cuota.class)
	public String CUOClave;
	
	@Llave
	public short Tipo;
	
	@Campo
	public float Minimo;
	
	@Campo
	public short Estado;
	
	public String DescripcionCuota;
	public String ClaveVendedor;
	public String NombreVendedor;
}
