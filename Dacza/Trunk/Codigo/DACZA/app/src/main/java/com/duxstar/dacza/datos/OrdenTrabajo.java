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

@TablaDef (orden = 4)
public class OrdenTrabajo extends Entidad {
    @Llave
    public String OrdenId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="UsuarioId", nombreCampo = "AgenteId", tablaPadre=Usuario.class)
    @Requerido
    public String AgenteId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="ClienteId", tablaPadre=Cliente.class)
    @Requerido
    public String ClienteId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="VinId", tablaPadre=Vin.class)
    @Requerido
    public String VinId;

    @Campo
    public String Folio;

    @Campo
    public Date FechaIni;

    @Campo
    public Date FechaFin;

    @Campo
    public int Fase;

    @Campo
    public float Kilometraje;

    @Campo
    public String Observacion;

    @Campo
    public Date MFechaHora;

    @Campo
    @LlaveForanea(nombreCampoForaneo="UsuarioId", tablaPadre=Usuario.class)
    public String MUsuarioId;

    @Campo
    public boolean Enviado;

    @Hijos(tablaHijos=ODTDetalle.class)
    public List<ODTDetalle> ODTDetalle;
}
