package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

/**
 * Created by ldelatorre on 04/03/2018.
 */
@TablaDef(orden=1)
public class DIS_Alarmas extends Entidad {

    @Llave
    @Campo
    public String ClienteClave;

    @Llave
    @Campo
    public String TiempoAlarma;

    @Llave
    @Campo
    public int Prioridad;

    @Campo
    public int Valor;
}
