package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

/**
 * Created by ldelatorre on 31/05/2017.
 */
@TablaDef(orden=1)
public class Gasto extends Entidad {

    @Llave
    @Campo
    public Date fecha;

    @Campo
    public String vendedorID;

    @Campo
    public String diaClave;

    @Campo
    public int tipoConcepto;

    @Campo
    public int formaPago;

    @Campo
    public String folio;

    @Campo
    public Float total;

    @Campo
    public String comentario;

    @Campo
    public Float porcentaje;

    @Campo
    public Float importe;

    @Campo
    public Float impuesto;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioId;

    @Campo
    public boolean Enviado;

}
