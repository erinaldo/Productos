package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class Esquema extends Entidad {
	@Llave()
	public String EsquemaId;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="EsquemaId", tablaPadre=Esquema.class)
	public String EsquemaIdPadre;
	
	@Campo
	public String Nombre;
	
	@Campo
	public String Clave;
	
	@Campo
	public int Tipo;
}
