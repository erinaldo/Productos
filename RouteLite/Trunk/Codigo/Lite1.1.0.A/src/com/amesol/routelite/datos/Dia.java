package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.*;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class Dia extends Entidad {

	@Llave()
	public String DiaClave;

	@Campo()
	public String Referencia;
	
	@Campo()
	public Date FechaCaptura;

	@Campo()
	public boolean FueraFrecuencia;
	
	@Campo()
	public short Frecuencia;
}
