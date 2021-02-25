package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=4)
public class InventarioTraspaso extends Entidad
{
	@Llave
	public String InventarioTraspasoId;
	
	@Campo
	public String DiaClave;
	
	@Campo
	public String VendedorId;
	
	@Campo
	public String ProductoClave;
	
	@Campo
	public int TipoUnidad;
	
	@Campo
	public float Cantidad;
	
	@Campo
	public int TipoMotivo;
	
	@Campo
	public int Origen;
	
	@Campo
	public int Destino;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
