package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

/**
 * Clase de mapeo para la tabla SEMHist
 * @author agonzalez bioxor
 *
 */
@TablaDef(orden=5, nombreTabla="SEMHist")
public class SEMHist extends Entidad
{
	@Llave
	public String SubEmpresaId;
	
	@Llave
	public Date SEMHistFechaInicio;
	
	@Campo
	public boolean ComprobanteDig;
	
	@Campo
	public boolean FoliosTerminal;
	
	@Campo
	public String ArchivoPEM;
	
	@Campo
	public short VersionCFD;
	
	public String NombreCorto;
	
	public String Telefono;
	
	@Override
	public String toString()
	{
		if(NombreCorto == null)
			return super.toString()	;
		return NombreCorto;
	}

	public String getVersionCFD()
	{
		return String.valueOf(VersionCFD);
	}
}
