package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class Configuracion extends Entidad {
	@Llave
	public String ConfiguracionID;
	
	@Campo
	public String NombreEmpresa;
	
	@Campo
	public String RFC;
	
	@Campo
	public String Pais;

	@Campo
	public String Region;
	
	@Campo
	public String Ciudad;

	@Campo
	public String Colonia;

	@Campo
	public String Calle;

	@Campo
	public String Numero;
	
	@Campo
	public String Telefono;

}
