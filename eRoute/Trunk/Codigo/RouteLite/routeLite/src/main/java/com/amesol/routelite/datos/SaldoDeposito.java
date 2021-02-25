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

@TablaDef(orden=1)
public class SaldoDeposito extends Entidad {
	
	@Llave()
	@Requerido
	public String SaldoDepositoID;
	
	@Campo
	@Requerido
	public String DiaClave;

    @Campo
    @Requerido
    public String VendedorID;

    @Campo
    public String DepositoCapturaID;

	@Campo
	@Requerido
	public float Saldo;

    @Campo
    public short Aplicado;

    @Campo
    public Date FechaAplicacion;

    @Campo
    public String DepositoAplicadoID;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
