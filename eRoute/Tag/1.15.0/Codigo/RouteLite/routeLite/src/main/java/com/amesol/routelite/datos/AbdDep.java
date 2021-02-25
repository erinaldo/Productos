package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden = 3)
public class AbdDep  extends Entidad {

    @Llave
    @LlaveForanea(nombreCampoForaneo = "DEPId", tablaPadre = Deposito.class)
    public String DEPId;

    @Llave
    public String ABNId;

    @Llave
    public String ABDId;

    @Campo
    public float Importe;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;

}
