package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 3)
public class Deposito extends Entidad
{
	@Llave
	public String DEPId;

	@Campo
	public String DiaClave;

	@Campo
	public short TipoBanco;

	@Campo
	public String FechaCreacion;

	@Campo
	public Date FechaDeposito;

	@Campo
	public String Ficha;

	@Campo
	public float Total;

	@Campo
	public Date MFechaHora;

	@Campo
	public String MUsuarioID;

	@Campo
	public boolean Enviado;
}
