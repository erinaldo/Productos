package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class RECEncabezadoPie extends Entidad{
	
	@Llave
	public String RECId;
	
	@Llave
	public short Tipo;
	
	@Llave
	public int Orden;
	
	@Campo
	public String CORId;
	
	@Campo
	public String COTId;
	
	@Campo
	public String COCId;
	
	@Campo
	public short TipoAlineacion;
	
	@Campo 
	public short TipoEtiqueta;
	
	@Campo
	public short TipoSeparador;
	
	@Campo
	public short TipoFormato;
	
	@Campo
	public short TipoLetra;
}
