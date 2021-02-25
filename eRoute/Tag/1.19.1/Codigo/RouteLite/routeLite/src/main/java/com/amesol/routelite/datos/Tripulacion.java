package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden = 2)
public class Tripulacion extends Entidad{

	@Llave
    public String TripId;

    @Llave
    @LlaveForanea(tablaPadre = VendedorJornada.class, nombreCampoForaneo = "VendedorId")
	public String VendedorId;
	
	@Llave
    @LlaveForanea(tablaPadre = VendedorJornada.class, nombreCampoForaneo = "VEJFechaInicial")
	public Date VEJFechaInicial;
	
	@Campo
	public Short TipoTripulacion;
	
	@Campo
	public String USUId;

	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
