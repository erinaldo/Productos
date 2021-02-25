package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@TablaDef(orden=8)
public class InventarioMercadeo extends Entidad {
    @Llave
    public String InventarioID;

    @Campo
    public String VisitaClave;

    @Campo
    public String DiaClave;

    @Campo
    public String ClienteClave;

    @Campo
    public float Latitud;

    @Campo
    public float Longitud;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;

    @Hijos(tablaHijos = InventarioMercadeoDetalle.class)
    public List<InventarioMercadeoDetalle> InventarioMercadeoDetalle;

    public InventarioMercadeo()
    {
        InventarioMercadeoDetalle = new ArrayList<InventarioMercadeoDetalle>();
    }
}
