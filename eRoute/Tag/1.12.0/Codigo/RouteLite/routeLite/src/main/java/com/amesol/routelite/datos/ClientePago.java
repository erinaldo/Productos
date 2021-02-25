package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=8, nombreTabla="ClientePago")
public class ClientePago extends Entidad
{
	
	@Llave
	public String ClientePagoId;

	@LlaveForanea(nombreCampoForaneo = "ClienteClave", tablaPadre = Cliente.class)
	public String ClienteClave;
	
	@Campo
	public short Tipo;
	
	@Campo
	public short TipoBanco;
	
	@Campo
	public String Cuenta;
	
	@Campo
	public short TipoEstado;
	
	public String Descripcion;
	
	public String Banco;
}
