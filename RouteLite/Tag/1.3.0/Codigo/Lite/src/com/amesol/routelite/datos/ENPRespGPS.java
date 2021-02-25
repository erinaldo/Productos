package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 1)
public class ENPRespGPS extends Entidad
{
    @Llave
    @Campo
    public String ENCId;
    
    @Llave
    @Campo
    public String ENPId;
    
    @Llave
    @Campo
    public String ERGId;
    
    @Campo
    public double Altitud;
    
    @Campo
    public double Latitud;
    
    @Campo
    public double Longitud;
    
    @Campo
    public Date Fecha;
    
    @Campo
    public Date Hora;
    
    @Campo
    public Date MFechaHora;
    
    @Campo
    public String MUsuarioId;
    
	@Campo
	public boolean Enviado;
}
