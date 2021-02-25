package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=11)
public class TrpPrp extends Entidad {
	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProdDetalle.class)
	public String TransProdID;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdDetalleID", tablaPadre = TransProdDetalle.class)
	public String TransProdDetalleID;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "PromocionClave", tablaPadre = Promocion.class)
	public String PromocionClave;
	
	@LlaveForanea(nombreCampoForaneo = "PromocionReglaID", tablaPadre = PromocionRegla.class)
	public String PromocionReglaID;
	
	@Campo
	public float PromocionImp;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;

}
