package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class REODetalle extends Entidad{
	@Llave
	public String RECId;
	
	@Llave
	public String REDId;
	
	@Campo
	public String CORId;
	
	@Campo 
	public String COTId;
	
	@Campo
	public String COCId;
	
	@Campo
	public int OrdenX;
	
	@Campo
	public int OrdenY;
	
	@Campo
	public short TipoEtiqueta;
	
	@Campo 
	public short TipoAlineacion;
	
	@Campo
	public short TipoSeparador;
	
	@Campo
	public short TipoFormato;
	
	@Campo
	public short Tamanio;
	
	@Campo
	public short CantidadEspacio;
	
	@Campo
	public short TipoEspacio;
	
	@Campo
	public short TipoLetra;


}
