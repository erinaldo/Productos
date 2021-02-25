package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=2)
public class ABNDetalle extends Entidad {
	@Llave()
	@LlaveForanea(nombreCampoForaneo="ABNId", tablaPadre=Abono.class)
	@Requerido
	public String ABNId;
	
	@Llave
	@Requerido
	public String ABDId;
	
	@Campo
	@Requerido
	public int TipoPago;
		
	@Campo
	@Requerido
	public float Importe;
	
	@Campo
	public float SaldoDeposito;
	
	@Campo	
	public String MonedaID;
	
	@Campo
	public int TipoBanco;
	
	@Campo	
	public String Referencia;
	
	@Campo	
	public Date FechaCheque;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public float SaldoCarga;
		
	@Campo
	public boolean Enviado;
}
