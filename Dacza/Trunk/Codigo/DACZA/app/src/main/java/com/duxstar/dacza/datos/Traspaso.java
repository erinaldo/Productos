package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.Requerido;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

import java.util.Date;

@TablaDef
public class Traspaso extends Entidad {
    @Llave
    public String TraspasoId;

    @Campo
    public String Folio;

    @Campo
    public Date Fecha;
}
