package com.amesol.routelite.datos;

import java.util.Date;
import java.util.Formatter;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.utilerias.Generales;

/**
 * Clase de mapeo para las operaciones a la tabla FolioFiscal
 * @author agonzalez bioxor
 *
 */
@TablaDef(orden=5, nombreTabla="FolioFiscal")
public class FolioFiscal extends Entidad
{
	private String FolioFiscalID;
	
	public String getFolioFiscalID()
	{
		return FolioId.concat("|").concat(FOSId);
	}
	
	@Llave
	public String FolioId;
	
	@Llave
	public String FOSId;
	
	@Campo
	@Requerido
	public int Inicio;
	
	@Campo
	@Requerido
	public String ModuloMovDetalleClave;
	
	@Campo
	public String VendedorId;
	
	@Campo
	public String TerminalClave;
	
	@Campo
	@Requerido
	public String NumCertificado;
	
	@Campo
	@Requerido
	public String CentroExpID;
	
	@Campo
	@Requerido
	public String Formato;
	
	@Campo
	public String Serie;
	
	@Campo
	@Requerido
	public int Aprobacion;
	
	@Campo
	@Requerido
	public int AnioAprobacion;
	
	@Campo
	@Requerido
	public int Usados;
	
	@Campo
	@Requerido
	public int Fin;
	
	@Campo
	@Requerido
	public Date FSHFechaInicio;
	
	@Campo
	@Requerido
	public Date FechaFinal;
	
	@Campo
	@Requerido
	public boolean Enviado;
	
	private String Folio;
	
	public void setFolio(String folio)
	{
		Folio = folio;
	}
	
	@SuppressWarnings("resource")
	public String getDescripcionFormato(){
		return Folio != null ? Folio : Serie + new Formatter().format("%0" + Formato.length() + "d" , Usados+Inicio);
	}
	
	@Override
	public String toString()
	{
		return getDescripcionFormato();
	}
	
}
