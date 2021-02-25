package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=11)
public class TPDDatosExtra extends Entidad {
    @Llave
    @LlaveForanea(nombreCampoForaneo = "TransProdID", tablaPadre = TransProdDetalle.class)
    public String TransProdID;

    @Llave
    @LlaveForanea(nombreCampoForaneo = "TransProdDetalleID", tablaPadre = TransProdDetalle.class)
    public String TransProdDetalleID;

    @LlaveForanea(nombreCampoForaneo = "PrecioClave", tablaPadre = Precio.class)
    public String PrecioClave;

    @Campo
    public Short UnidadAlterna;

    @Campo
    public Float CantidadAlterna;

    @Campo
    public Float CantidadAlternaOriginal;

    @Campo
    public String Lote;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;


}