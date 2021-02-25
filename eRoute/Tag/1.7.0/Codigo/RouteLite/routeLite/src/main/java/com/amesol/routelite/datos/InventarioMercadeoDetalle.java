package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden=9)
public class InventarioMercadeoDetalle extends Entidad {
    @Llave
    @LlaveForanea(nombreCampoForaneo = "InventarioID", tablaPadre = InventarioMercadeo.class)
    public String InventarioID;

    @Llave
    public String ProductoClave;

    @Campo
    public short TipoUnidad;

    @Campo
    public float Inventario;

    @Campo
    public float Precio;

    @Campo
    public float InvAnterior;

    @Campo
    public float PEntregado;

    @Campo
    public float Desplazamiento;

    @Campo
    public float PTransito;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
