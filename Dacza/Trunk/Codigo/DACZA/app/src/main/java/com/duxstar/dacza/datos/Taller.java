package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.Requerido;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef (orden = 1)
public class Taller extends Entidad {
    @Llave
    public String TallerId;

    @Campo
    public String Clave;

    @Campo
    public String Descripcion;
}
