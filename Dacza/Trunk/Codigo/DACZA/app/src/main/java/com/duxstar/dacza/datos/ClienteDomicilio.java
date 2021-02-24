package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef
public class ClienteDomicilio extends Entidad {
    @Llave
    public String DomicilioId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="ClienteId", tablaPadre=Cliente.class)
    public String ClienteId;

    @Campo
    public int Tipo;

    @Campo
    public String Calle;

    @Campo
    public String NumeroExt;

    @Campo
    public String NumeroInt;

    @Campo
    public String CodigoPostal;

    @Campo
    public String Colonia;

    @Campo
    public String Localidad;

    @Campo
    public String Poblacion;

    @Campo
    public String Entidad;

    @Campo
    public String Pais;
}
