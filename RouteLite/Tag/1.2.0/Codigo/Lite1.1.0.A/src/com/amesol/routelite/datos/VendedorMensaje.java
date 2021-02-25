package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=15)
public class VendedorMensaje extends Entidad{

	@Llave
	public String VendedorMensajeId;
	
	@Campo
	public String VendedorId;
	
	@Campo
	public String MDBMensajeID;
	
	@Campo
	public int TipoEstado;
	
	@Campo
	public int Posponer;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
