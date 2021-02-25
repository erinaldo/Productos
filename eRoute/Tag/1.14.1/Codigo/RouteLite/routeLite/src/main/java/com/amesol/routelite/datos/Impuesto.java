package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class Impuesto extends Entidad{
	@Llave
	public String ImpuestoClave;
	@Campo
	public String Abreviatura;
	@Campo
	public Short TipoAplicacion;
	@Campo
	public Short Jerarquia;
	@Campo
	public Short TipoValor;
	@Campo
	public Short TipoEstado;
	@Campo
	public boolean ValidaRFC;
	
	public double Valor;

	public Short RedondeoDecimales;

	 public double Importe;
	 public double ImportePU ;
}
