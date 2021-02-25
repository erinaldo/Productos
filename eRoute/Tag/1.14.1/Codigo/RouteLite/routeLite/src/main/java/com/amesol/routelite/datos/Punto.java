package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

/**
 * Created by Adriana on 12/10/2017.
 */
@TablaDef(orden=10)
public class Punto extends Entidad {

    @Llave
    @LlaveForanea( nombreCampoForaneo="ClienteClave", tablaPadre=Cliente.class)
    @Requerido
    public String ClienteClave;

    @Campo
    public float Otorgados;

    @Campo
    public float Canjeados;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;

    @Campo
    public float OtorgadosCarga;

}
