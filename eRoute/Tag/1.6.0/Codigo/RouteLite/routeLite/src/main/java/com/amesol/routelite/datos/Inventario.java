package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class Inventario extends Entidad{
	@Llave
	public String ProductoClave;
	
	@Llave
	public String AlmacenID;
		
	@Campo
	public float Disponible;

	@Campo
	public float NoDisponible;
	
	@Campo
	public float Apartado;

	@Campo
	public float Contenido;

	@Campo
	public float Pedido;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
}

