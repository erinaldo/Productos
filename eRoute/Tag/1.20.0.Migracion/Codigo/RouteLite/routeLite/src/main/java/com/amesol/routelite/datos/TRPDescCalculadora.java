package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

/**
 * Created by ldelatorre on 02/11/2016.
 */
@TablaDef(orden = 8)
public class TRPDescCalculadora extends Entidad
{
    @Llave
    public String TransProdID;
    @Campo
    public float Porcentaje;
    @Llave
    public int Orden;
    @Campo
    public float Importe;
    @Campo
    public boolean AplicadoCobranza;
    @Campo
    public Date MFechaHora;
    @Campo
    public String MUsuarioID;
    @Campo
    public boolean Enviado;
}