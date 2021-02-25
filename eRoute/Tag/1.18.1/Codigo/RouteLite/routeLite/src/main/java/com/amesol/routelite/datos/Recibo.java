package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef
public class Recibo extends Entidad{

	@Llave 
	public String RECId;
	
	@Campo 
	public short Tipo;
	
	@Campo
	public boolean Predeterminado;
	
	@Campo 
	public short TipoEstado;
	
	@Campo
	public short TipoPapel;
	
	@Campo
	public boolean AgruparPorPrecio;
	
	@Campo
	public boolean MostrarLogo;
	
	@Campo
	public boolean MostrarEquivalencia;
	
	@Campo
	public boolean AgruparPorSubem;
	
	@Campo
	public String CORId;
	
	@Campo
	public String COTId;
	
	@Campo
	public String COCId;
	
	@Campo
	public boolean IncluirImpuestos;

    @Campo
    public boolean MostrarCodBarras;

    @Campo
    public boolean SeccionProdPromo;

    @Campo
    public boolean MostrarTotalUnidades;

	@Campo
	public boolean LeyendaFacturar;

}
