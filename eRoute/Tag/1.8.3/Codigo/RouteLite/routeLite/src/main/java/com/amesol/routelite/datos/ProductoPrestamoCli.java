package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=10)
public class ProductoPrestamoCli extends Entidad
{
	@Llave
	public String ClienteClave;
	@Llave
	public String ProductoClave;
	@Campo
	public int Cargo;
	@Campo
	public int Abono;
	@Campo
	public int Venta;
	@Campo
	public int Saldo;
	@Campo
	public int SaldoCarga;
	@Campo
	public Date MFechaHora;
	@Campo
	public String MUsuarioID;
	@Campo
	public boolean Enviado;
}
