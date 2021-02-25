package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden = 1)
public class MercadeoMarca extends Entidad {

    @Llave
    public String MEMId;

    @Campo
    public String Marca;

    @Campo
    public Short Estado;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
