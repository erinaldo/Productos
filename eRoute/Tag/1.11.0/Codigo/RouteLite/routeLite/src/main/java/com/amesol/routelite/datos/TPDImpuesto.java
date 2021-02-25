package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=10)
public class TPDImpuesto extends Entidad {
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
	public Double ImpuestoImp;
	
	@Campo
	public Double ImpuestoPU;
	
	@Campo
	public Double ImpDesGlb;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	
}
