package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.Requerido;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef
public class TRPDetalle extends Entidad {
    @Llave
    @LlaveForanea(nombreCampoForaneo="TraspasoId", tablaPadre=Traspaso.class)
    public String TraspasoId;

    @Llave
    @LlaveForanea(nombreCampoForaneo="ArticuloId", tablaPadre=Articulo.class)
    public String ArticuloId;

    @Campo
    public float Cantidad;

    @Campo
    public int Partida;
}
