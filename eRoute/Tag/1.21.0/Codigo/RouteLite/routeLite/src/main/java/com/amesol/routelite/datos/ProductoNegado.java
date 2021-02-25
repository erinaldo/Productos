package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

@TablaDef(orden=14)
public class ProductoNegado  extends Entidad {
    @Llave()
    public String PRGId;

    @Campo
    public String TransProdID;

    @Campo
    public String ProductoClave;

    @Campo
    public String PromocionClave;

    @Campo
    public String ProductoClave1;

    @Campo()
    public short TipoUnidad;

    @Campo()
    public float Cantidad;

    @Campo()
    public float Saldo;

    @Campo()
    public short TipoFasePRP;

    @Campo()
    public Date FechaFase;

    @Campo()
    public String Cliente;

    @Campo()
    public String FolioPedido;

    @Campo()
    public boolean PendienteEntrega;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
