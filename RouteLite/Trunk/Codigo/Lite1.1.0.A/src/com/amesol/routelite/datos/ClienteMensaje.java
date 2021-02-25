package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class ClienteMensaje extends Entidad {
	
	@Llave()
	@Requerido
	public String ClienteMensajeId;
	
	@Campo
	@LlaveForanea( nombreCampoForaneo="ClienteClave", tablaPadre=Cliente.class)
	@Requerido
	public String ClienteClave;
	
	@Campo
	@LlaveForanea( nombreCampoForaneo="MDBMensajeID", tablaPadre=MDBMensaje.class)
	@Requerido
	public String MDBMensajeID;
	
	@Campo
	@Requerido
	public int TipoEstado;
	
	@Campo
	public int Posponer;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
