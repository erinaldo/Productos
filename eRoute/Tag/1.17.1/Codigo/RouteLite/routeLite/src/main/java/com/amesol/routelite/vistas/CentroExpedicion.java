package com.amesol.routelite.vistas;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(nombreTabla="CentroExpedicion" , orden=4)
public class CentroExpedicion extends Entidad
{
	@Llave
	public String CentroExpID;
	
	@Campo
	public String CentroExpPadreID;
	
	@Campo
	public String Nombre;

	@Campo
	public short Tipo;

	@Campo
	public String SubEmpresaId;

	@Campo
	public String NumCertificado;

	@Campo
	public String RFC;

	@Campo
	public String Calle;

	@Campo
	public String NumExt;

	@Campo
	public String NumInt;

	@Campo
	public String Colonia;
	
	@Campo
	public String CodigoPostal;
	
	@Campo
	public String ReferenciaDom;
	
	@Campo
	public String Localidad;
	
	@Campo
	public String Municipio;
	
	@Campo
	public String Entidad;
	
	@Campo
	public String Pais;
	
}
