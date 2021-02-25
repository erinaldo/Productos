package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=20)
public class FolioReservacion extends Entidad {

	@Llave()
	public String FolioId;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="VendedorId", tablaPadre=Vendedor.class)
	public String VendedorId;
	
	@Llave
	public String RangoID;
	
	@Campo
	public Date FechaHora;
	
	@Campo
	public int Inicio;
	
	@Campo
	public int Fin;
	
	@Campo 
	public int Usados;
	
	@Campo 
	public short TipoEstado;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
