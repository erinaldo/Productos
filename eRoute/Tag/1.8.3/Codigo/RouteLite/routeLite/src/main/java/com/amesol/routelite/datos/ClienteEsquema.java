package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class ClienteEsquema extends Entidad {
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ClienteClave", tablaPadre=Cliente.class)
	@Requerido
	public String ClienteClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="EsquemaId", tablaPadre=Esquema.class)
	@Requerido
	public String EsquemaId;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public boolean Baja;
	
	@Campo
	public boolean Enviado;
}
