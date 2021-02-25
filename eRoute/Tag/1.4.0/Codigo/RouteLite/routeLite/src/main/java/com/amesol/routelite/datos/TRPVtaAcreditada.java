package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=11)
public class TRPVtaAcreditada extends Entidad {

	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProd.class)
	public String TransProdID;
	
	@Campo
	public String FolioEntrega;
	
	@Campo
	public String FolioCliente;
	
	@Campo
	public String Remision;
	
	@Campo
	public String PedidoAdicional;
	
	@Campo
	public String Observaciones;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
