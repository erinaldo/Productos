package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

/**
 * Created by aperez on 26/02/2019.
 */
@TablaDef(orden=10)
public class LoteCaducidad extends Entidad{
    @Llave
    public String Lote;

    @Campo
    public Date Caducidad;

    @Campo
    public String ProductoClave;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
