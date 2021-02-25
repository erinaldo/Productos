package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

/**
 * Created by projas on 19/11/2015.
 */
@TablaDef(orden=1)
public class PoliticaContrasenaHist extends Entidad {
    @Llave
    public String PoliticaHid ;

    @Campo
    public String USUId;

    @Campo
    public Date FechaHoraMod;

    @Campo
    public Date Caducidad;

    @Campo
    public boolean ValidarContAnt;

    @Campo
    public boolean ValidarContBlanco;
}
