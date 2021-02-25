package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef
public class PromocionAplicacion extends Entidad {

	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionClave", tablaPadre=PromocionRegla.class)
	public String PromocionClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionReglaID", tablaPadre=PromocionRegla.class)
	public String PromocionReglaID;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ProductoClave", tablaPadre=ProductoUnidad.class)
	public String ProductoClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="PRUTipoUnidad", tablaPadre=ProductoUnidad.class)
	public short PRUTipoUnidad;
	
	@Campo
	public int Cantidad;

	@Campo
	public int SaldoProducto;

	@Campo
	public short TipoEstado;

	@Campo
	public Date MFechaHora;

	@Campo
	public String MUsuarioID;

	@Campo
	public boolean Enviado;

	@Campo
	public int SaldoCarga;
}
