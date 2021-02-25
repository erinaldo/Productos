package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef()
public class TRPGrupo extends Entidad {
    @Llave
    public String GrupoID;

    @Llave
    @LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProd.class)
    public String TransProdID;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;
}
