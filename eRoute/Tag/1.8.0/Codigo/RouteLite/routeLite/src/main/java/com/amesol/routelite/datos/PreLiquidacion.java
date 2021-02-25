package com.amesol.routelite.datos;

import java.util.Date;

import android.annotation.SuppressLint;
import android.os.Parcel;
import android.os.Parcelable;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 3)
public class PreLiquidacion extends Entidad
{

	@Llave
	public String PLIId;

	@Campo
	public Date FechaPreLiquidacion;

	@Campo
	public float MontoTotal;

	@Campo
	public boolean Enviado;

}