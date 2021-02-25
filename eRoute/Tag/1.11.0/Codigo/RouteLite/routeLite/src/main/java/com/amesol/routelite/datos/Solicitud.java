package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

/**
 * Created by Adriana on 26/12/2016.
 */

@TablaDef(orden = 1)
public class Solicitud extends Entidad {

    @Llave
    public String SOLId;
    @Campo
    public String Folio;
    @Campo
    public String VisitaClave;
    @Campo
    public String DiaClave;
    @Campo
    public short TipoArea;
    @Campo
    public Short TipoPeticion;
    @Campo
    public Date FechaHora;
    @Campo
    public String Concepto;
    @Campo
    public Short TipoEstado;
    @Campo
    public Date MFechaHora;
    @Campo
    public String MUsuarioID;
    @Campo
    public String Comentario;
    @Campo
    public boolean Enviado;
}
