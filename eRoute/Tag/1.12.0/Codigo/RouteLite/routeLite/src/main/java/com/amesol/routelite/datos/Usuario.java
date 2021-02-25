package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class Usuario extends Entidad  {

	@Llave
	public String USUId;
	
	@Campo
	public String PERClave;
	
	@Campo
	public String Clave;
	
	@Campo
	public String Nombre;
	
	@Campo
	public String ClaveAcceso;

    @Campo
    public boolean Activo;
}
