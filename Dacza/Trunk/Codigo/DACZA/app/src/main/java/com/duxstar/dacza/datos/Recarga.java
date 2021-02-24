package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Hijos;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.Requerido;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

import java.util.Date;
import java.util.List;

@TablaDef (orden = 6)
public class Recarga extends Entidad {
    @Llave
    public String RecargaId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="UsuarioId", tablaPadre=Usuario.class)
    @Requerido
    public String AgenteId;

    @Campo
    public String Folio;

    @Campo
    public Date FechaSolicitud;

    @Campo
    public Date FechaSurtido;

    @Campo
    public int Fase;

    @Campo
    public Date MFechaHora;

    @Campo
    @LlaveForanea(nombreCampoForaneo="UsuarioId", tablaPadre=Usuario.class)
    public String MUsuarioId;

    @Campo
    public boolean Enviado;


    @Hijos(tablaHijos=RECDetalle.class)
    public List<RECDetalle> RECDetalle;

}
