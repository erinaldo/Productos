package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;


@TablaDef(orden=2)
public class ConteoInventarioDet extends Entidad{

    @Campo
    @Requerido
    public String ContDEId;

    @Llave()
    @Requerido
    public String ContId;

    @Llave()
    @Requerido
    public String ProductoClave;

    @Llave()
    @Requerido
    public Short TipoUnidad;

    @Campo
    @Requerido
    public Float BuenEstadoL;

    @Campo
    @Requerido
    public Float MalEstadoL;

    @Campo
    @Requerido
    public Float BuenEstadoF;

    @Campo
    @Requerido
    public Float MalEstadoF;

    @Campo
    @Requerido
    public Date MFechaHora;

    @Campo
    @Requerido
    public String MUsuarioID;

    @Campo
    public boolean Enviado;

}
