package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef
public class ClienteTelefono extends Entidad {
    @Llave
    public String TelefonoId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="ClienteId", tablaPadre=Cliente.class)
    public String ClienteId;

    @Campo
    public int Tipo;

    @Campo
    public String Lada;

    @Campo
    public String Numero;
}
