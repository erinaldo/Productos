package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 2)
public class VendedorJornada  extends Entidad{

	@Llave
	@LlaveForanea(tablaPadre = Vendedor.class, nombreCampoForaneo = "VendedorId")
	public String VendedorId;
	
	@Llave
	public Date VEJFechaInicial;
	
	@Campo
	public String DiaClave;
	
	@Campo
	public Date FechaFinal;
	
	@Campo
	public boolean Enviado;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
}
