package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Hijos;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

import java.util.List;

@TablaDef
public class Cliente extends Entidad {
    @Llave
    public String ClienteId;

    @Campo
    public String Clave;

    @Campo
    public String RFC;

    @Campo
    public String RazonSocial;

    @Campo
    public String Telefono;

    @Campo
    public String Domicilio;

    @Hijos(tablaHijos=ClienteDomicilio.class)
    public List<ClienteDomicilio> ClienteDomicilio;

    @Hijos(tablaHijos=ClienteTelefono.class)
    public List<ClienteTelefono> ClienteTelefono;
}


