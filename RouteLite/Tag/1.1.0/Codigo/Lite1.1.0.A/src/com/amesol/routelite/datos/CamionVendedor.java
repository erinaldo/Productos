package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 3)
public class CamionVendedor extends Entidad
{

	@Llave
	public String CAMVENId;

	@Campo
	public String Placa;

	@Campo
	public Date FechaHoraInicial;

	@Campo
	public Date FechaHoraFinal;

	@Campo
	public float KmInicial;

	@Campo
	public float KmFinal;

	@Campo
	public float LitrosGasolina;

	@Campo
	public float ImporteGasolina;

	@Campo
	public Date MFechaHora;

	@Campo
	public boolean Enviado;

	public String Clave;
}
