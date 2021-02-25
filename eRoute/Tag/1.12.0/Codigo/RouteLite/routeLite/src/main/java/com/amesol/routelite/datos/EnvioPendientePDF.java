package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden=1)
public class EnvioPendientePDF extends Entidad {
    @Llave
    @Requerido
    public String EnvioID;

    @Campo
    @Requerido
    public String ClienteClave;

    @Campo
    public String Archivo;

    @Campo
    public String TransProdID;

    @Campo
    public String ABNId;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioId;

    @Campo
    public boolean Enviado;
}
