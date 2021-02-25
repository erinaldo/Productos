package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class Ruta extends Entidad {

	@Llave
	public String RUTClave;

	@Campo
	public String Descripcion;
	
	@Campo
	public boolean Inventario;
	
	@Campo
	public short FolioClienteNvo;
	
	@Campo
	public boolean Enviado;	
}
