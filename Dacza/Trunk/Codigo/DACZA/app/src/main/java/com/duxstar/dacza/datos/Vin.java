package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.Requerido;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef
public class Vin extends Entidad{
    @Llave
    public String VinId;

    @Campo
    @LlaveForanea(nombreCampoForaneo = "ArticuloId", tablaPadre = Articulo.class)
    public String ArticuloId;

    @Campo
    @LlaveForanea(nombreCampoForaneo = "ClienteId", tablaPadre = Cliente.class)
    public String ClienteId;

    @Campo
    public String Clave;

    @Campo
    public String Placas;

    @Campo
    public Float Kilometraje;
}
