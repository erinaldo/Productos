package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden = 4)
public class MERDetalle extends Entidad {

    @Llave
    public String MRDId;

    @Campo
    @LlaveForanea(nombreCampoForaneo = "MercadeoProducto", tablaPadre = MercadeoProducto.class)
    public String MEMId;

    @Campo
    @LlaveForanea(nombreCampoForaneo = "MercadeoMarca", tablaPadre = MercadeoMarca.class)
    public String MPRId;

    @Campo
    public String VisitaClave;

    @Campo
    public String DiaClave;

    @Campo
    public String ClienteClave;

    @Campo
    public String Tipo;

    @Campo
    public String Presentacion;

    @Campo
    public Float Precio;

    @Campo
    public Float PrecioOferta;

    @Campo
    public Integer Cantidad;

    @Campo
    public Date FechaVigencia;

    @Campo
    public String Notas;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
