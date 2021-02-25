package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.generales.Entidad;

public class Descuento extends Entidad {
	@Llave
	public String DescuentoClave;
	@Campo
	public String Nombre;
	@Campo
	public short Tipo;
	@Campo
	public int PermiteCascada;
	@Campo
	public short TipoAplicacion;
	@Campo
	public float ValorAplicacion;
	@Campo
	public short TipoValor;
	@Campo
	public short TipoEstado;
	@Campo
	public Boolean Baja;
	
	
	public int Jerarquia;
	public float PorcentajeCalculado;
	public float ImporteCalculado;
}
