package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

public class AddendaDetalle{
	//TipoDato, LongMin, LongMax, Etiqueta, Valor, Requerido
	public String ADDId;
	public String ADDDId;
	public int TipoDato;
	public int LongMin;
	public int LongMax;
    public String Etiqueta;
	public String Valor;
	public boolean Requerido;
	public String Respuesta;
}
