package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class ModuloMov extends Entidad {
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ModuloClave", tablaPadre=ModuloTerm.class)
	public String ModuloClave;
	
	@Llave()
	public String ModuloMovClave;
	
	@Campo
	public String Nombre;
	
	@Campo
	public short TipoIndice;
	
	@Campo
	public int Orden;
	
	@Campo
	public short TipoEstado;
	
	@Campo
	public boolean Baja; 

}
