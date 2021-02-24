package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef
public class Usuario extends Entidad  {
	@Llave
	public String UsuarioId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="TallerId", tablaPadre=Cliente.class)
    public String TallerId;

    @Campo
    public String Clave;

    @Campo
    public String ClaveAcceso;
	
	@Campo
	public String Nombre;
	
	@Campo
	public String Tipo;
}
