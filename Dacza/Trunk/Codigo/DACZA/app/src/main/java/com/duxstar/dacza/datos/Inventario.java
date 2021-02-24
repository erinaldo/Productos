package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

import java.util.Date;

@TablaDef (orden = 3)
public class Inventario extends Entidad {
    @Llave
    @LlaveForanea(nombreCampoForaneo = "ArticuloId", tablaPadre = Articulo.class )
    public String ArticuloId;

    @Campo
    public float Existencia;

    @Campo
    public float Apartado;

    @Campo
    public Date MFechaHora;

    @Campo
    @LlaveForanea(nombreCampoForaneo="UsuarioId", tablaPadre=Usuario.class)
    public String MUsuarioId;

    @Campo
    public boolean Enviado;
}
