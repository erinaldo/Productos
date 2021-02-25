package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=12)
public class TpdDes extends Entidad {
	
	public TpdDes()
	{
		super();
	}
	
	
	
	public TpdDes(String transProdID, String transProdDetalleID,
			String descuentoClave, float desPor, float desImporte,
			float desImpuesto, short jerarquia, short tipoCascada,
			Date mFechaHora, String mUsuarioID, boolean enviado) {
		super();
		TransProdID = transProdID;
		TransProdDetalleID = transProdDetalleID;
		DescuentoClave = descuentoClave;
		DesPor = desPor;
		DesImporte = desImporte;
		DesImpuesto = desImpuesto;
		Jerarquia = jerarquia;
		TipoCascada = tipoCascada;
		MFechaHora = mFechaHora;
		MUsuarioID = mUsuarioID;
		Enviado = enviado;
	}

	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProdDetalle.class)
	public String TransProdID;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "TransProdDetalleID", tablaPadre = TransProdDetalle.class)
	public String TransProdDetalleID;

	@Llave
	@LlaveForanea(nombreCampoForaneo = "Descuento", tablaPadre = Descuento.class)
	public String  DescuentoClave;
	
	@Campo
	public float  DesPor;
	@Campo
	public float  DesImporte;
	@Campo
	public float  DesImpuesto;
	@Campo
	public short  Jerarquia;
	@Campo
	public short  TipoCascada;

	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
	
}
