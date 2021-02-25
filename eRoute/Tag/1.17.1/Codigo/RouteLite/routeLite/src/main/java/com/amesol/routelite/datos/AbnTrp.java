package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class AbnTrp extends Entidad {
	
	@Llave()
	@LlaveForanea(nombreCampoForaneo="ABNId", tablaPadre=Abono.class)
	@Requerido
	public String ABNId;
	
	@Llave
	@Requerido
	public String TransProdID;
	
	@Campo
	@Requerido
	public Date FechaHora;
		
	@Campo
	@Requerido
	public float Importe;

    @Campo
    public float SaldoInsoluto;

	@Campo
	public String Serie;
	
	@Campo
	public String Corecibo;

	@Campo
	public String VisitaClave;

	@Campo
	public String DiaClave;

	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
		
	@Campo
	public boolean Enviado;
}
