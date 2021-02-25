package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 3)
public class PLBPLE extends Entidad
{

	@LlaveForanea(nombreCampoForaneo = "PLIId", tablaPadre = PreLiquidacion.class)
	public String PLIId;

	@Llave
	public String PBEId;

	@Campo
	public Date FechaDeposito;

	@Campo
	public String TipoBanco;

	@Campo
	public String Referencia;

	@Campo
	public float Total;

	@Campo
	public String Ficha;

	@Campo
	public String TipoEfectivo;

	@Campo
	public Date MFechaHora;

	@Campo
	public boolean Enviado;
}
