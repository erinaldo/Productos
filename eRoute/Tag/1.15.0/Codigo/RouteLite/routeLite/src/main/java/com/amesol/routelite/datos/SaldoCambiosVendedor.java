package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden=3)
public class SaldoCambiosVendedor extends Entidad {

	@Llave
	public String VendedorID;

	@Llave
	public short Mes;

    @Llave
    public String EsquemaID;
	
	@Campo
	public float SaldoDisponible;
	
	@Campo
	public float SaldoUsado;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
	
}
