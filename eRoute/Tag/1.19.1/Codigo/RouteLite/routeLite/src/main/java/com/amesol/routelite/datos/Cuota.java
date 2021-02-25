package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class Cuota extends Entidad{

	@Llave
	public String CUOClave;
	
	@Campo
	public Date FechaInicio;
	
	@Campo
	public Date FechaFin;
	
	@Campo
	public String Descripcion;

	@Campo
	public int TipoReinicio;

	@Campo
	public int UnidadReinicio;

	@Campo
	public int ReinicioAplicado;
	
	@Campo
	public short Estado;
	
	@Campo
	public boolean Baja;
	
	@Hijos(tablaHijos = CUOCliente.class)
	public List<CUOCliente> CUOCliente;
	
	@Hijos(tablaHijos = CUOEsquema.class)
	public List<CUOEsquema> CUOEsquema;
	
	@Hijos(tablaHijos = CUOProducto.class)
	public List<CUOProducto> CUOProducto;
	
	@Hijos(tablaHijos = CUOVendedor.class)
	public List<CUOVendedor> CUOVendedor;
	
	public Cuota(){
		CUOCliente = new ArrayList<CUOCliente>();
		CUOEsquema = new ArrayList<CUOEsquema>();
		CUOProducto = new ArrayList<CUOProducto>();
		CUOVendedor = new ArrayList<CUOVendedor>();
	}
}
