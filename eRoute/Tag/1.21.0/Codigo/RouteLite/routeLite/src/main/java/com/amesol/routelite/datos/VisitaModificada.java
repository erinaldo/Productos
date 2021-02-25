package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden = 7)
public class VisitaModificada extends Entidad {
    @Llave
    public String VisitaClave;

    @Llave
    public String DiaClave;

    @Campo
    public Date FechaHoraFinal;

    @Campo
    public Short TipoEstado;

    @Campo
    public boolean Enviado;
}
