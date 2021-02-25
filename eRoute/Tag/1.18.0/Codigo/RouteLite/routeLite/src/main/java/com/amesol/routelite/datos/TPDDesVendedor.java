package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=13)
public class TPDDesVendedor extends Entidad{

	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProdDetalle.class)
	public String TransProdID;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdDetalleID", tablaPadre = TransProdDetalle.class)
	public String TransProdDetalleID;
	
	@Campo
	public float DesPor;
	
	@Campo
	public float DesImporte;
	
	@Campo
	public float DesImpuesto;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
