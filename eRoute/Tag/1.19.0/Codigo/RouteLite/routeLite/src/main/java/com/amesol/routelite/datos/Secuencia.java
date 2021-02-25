package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden=5, nombreTabla="Secuencia")
public class Secuencia extends Entidad {
    @Llave
    public String SECId;

    @Campo
    public String ClienteClave;

    @Campo
    public String ClienteDomicilioID;

    @Campo
    public String RUTClave;

    @Campo
    public String FrecuenciaClave;

    @Campo
    public Integer Orden;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
