package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef
public class Articulo extends Entidad {
    @Llave
    public String ArticuloId;

    @Campo
    public String Clave;

    @Campo
    public String Descripcion;

    @Campo
    public String Grupo;

    @Campo
    public String Unidad;

    @Campo
    public int Tipo;
}
