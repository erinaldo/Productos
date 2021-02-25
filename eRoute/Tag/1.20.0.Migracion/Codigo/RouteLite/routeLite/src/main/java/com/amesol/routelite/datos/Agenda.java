package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=5)
public class Agenda extends Entidad {

	@Llave()
	public String DiaClave;
	
	@Llave()
	public String VendedorId;
	
	@Llave()
	public String FrecuenciaClave;
	
	@Llave()
	public String RUTClave;
	
	@Llave()
	public int Orden;
	
	@Llave()
	public String ClienteClave;

	@Campo
	public boolean Cumpleaños;
	
	@Campo
	public short Visitado;
	
	@Campo
	public Short TipoMotivo;
	
	@Campo
	public String Comentario;
	
	@Campo
	public boolean Enviado;
}
