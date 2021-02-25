package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=3)
public class SaldoCambiosVendedor extends Entidad {

	@Llave
	public String VendedorID;

	@Llave
	public short Frecuencia;

    @Llave
    public short Clasificacion;
	
	@Campo
	public float SaldoDisponible;
	
	@Campo
	public float SaldoUsado;
	
}
