package com.amesol.routelite.datos;

import java.util.Date;

import android.text.method.DateTimeKeyListener;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class PrecioProductoVig extends Entidad {
	@Llave
	public String PrecioClave;
	@Llave
	public String ProductoClave;
	@Llave
	public short PRUTipoUnidad;
	@Llave
	public Date PPVFechaInicio;
	@Campo
	public float Precio;
	@Campo
	public float PrecioMinimo;
    @Campo
    public float PrecioSugerido;
	@Campo
	public Date FechaFin;
	
}
