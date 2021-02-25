package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class Vendedor extends Entidad{
	@Llave
	public String VendedorId;
	
	@Campo
	public String Nombre;
	
	@Campo
	public String ModuloClave;
	
	@Campo
	public String AlmacenID;
	
	@Campo
	public String Nivel;
	
	@Campo
	public float LimiteDescuento;
	
	@Campo
	public short TipoEstado;
	
	@Campo
	public String USUId;
	
	@Campo
	public String TerminalClave;
	
	@Campo
	public boolean Baja;
	
	@Campo
	public boolean MostrarEsquema;
	
	@Campo
	public boolean ActualizaEsquema;
	
	@Campo
	public boolean CapturaPrecio;
	
	@Campo
	public boolean CapturaFolioFac;
	
	@Campo
	public boolean JornadaTrabajo;
	
	@Campo
	public Date Fecha;
	
	@Campo
	public String CodigoBarras;
	
	@Campo
	public String ClaveCEDI;
	
	@Campo
	public boolean MostrarCuota;
	
	@Campo
	public boolean MantenerPrm;
	
	@Campo
	public short TipoModImp;
	
	@Campo
	public boolean EditarDatosFiscal;
	
	@Campo
	public String MCNClave;
	
	@Campo
	public boolean GPS;
	
	@Campo
	public boolean Kilometraje;
	
	@Campo
	public boolean TiemposMuertos;
	
	@Campo
	public short ModificarPrecios;
}
