package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class CLIFormaVenta extends Entidad {
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ClienteClave", tablaPadre=Cliente.class)
	@Requerido
	public String ClienteClave;
	
	@Llave()
	@Requerido
	public int CFVTipo;
	
	@Campo
	public float LimiteCredito;
	
	@Campo
	public int DiasCredito;
	
	@Campo
	@Requerido
	public boolean Inicial;
	
	@Campo
	public boolean CapturaDias;
	
	@Campo
	@Requerido
	public boolean ValidaLimite;
	
	@Campo
	@Requerido
	public boolean ValidaPago;
	
	@Campo
	@Requerido
	public int Estado;
	
	@Campo
	public boolean Enviado;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Hijos(tablaHijos=CFVHist.class)
	public List<CFVHist> CFVHist;
	
	public CLIFormaVenta(){
		CFVHist = new ArrayList<CFVHist>();
	}
	
	private String Descripcion;
	
	public void setDescripcion(String descripcion)
	{
		Descripcion = descripcion;
	}
	
	@Override
	public String toString()
	{
		if(Descripcion == null)
			return super.toString();
		else return Descripcion;
	}
}
