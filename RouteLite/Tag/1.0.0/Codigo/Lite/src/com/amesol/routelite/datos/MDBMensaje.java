package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class MDBMensaje extends Entidad {
	
	@Llave()
	public String MDBMensajeID;
	
	@Campo
	public String MDBMensajeTipo;
	
	@Campo
	public int Numero;
	
	@Campo
	public String Descripcion;
	
}
