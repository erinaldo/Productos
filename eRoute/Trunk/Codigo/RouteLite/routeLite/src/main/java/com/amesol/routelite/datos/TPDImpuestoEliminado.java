package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden=10)
public class TPDImpuestoEliminado extends Entidad {
	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProdDetalle.class)
	public String TransProdID;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdDetalleID", tablaPadre = TransProdDetalle.class)
	public String TransProdDetalleID;

	@Llave
	public String TPDImpuestoID;

	@LlaveForanea(nombreCampoForaneo = "ImpuestoClave", tablaPadre = Impuesto.class)
	public String ImpuestoClave;
	
	@Campo
	public Double ImpuestoPor;
	
	@Campo
	public Float ImpuestoImp;
	
	@Campo
	public Float ImpuestoPU;
	
	@Campo
	public Float ImpDesGlb;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	
}
