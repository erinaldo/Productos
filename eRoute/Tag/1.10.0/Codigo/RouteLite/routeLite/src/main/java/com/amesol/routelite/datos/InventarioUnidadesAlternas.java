package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.Date;

/**
 * 11/11/2016.
 * Entidad que se utiliza para validar inventario con el manejo de unidades alternas
 */
@TablaDef(orden=1)
public class InventarioUnidadesAlternas extends Entidad {

    @Llave
    public String ProductoClave;

    @Llave
    public Short PRUTipoUnidad;

    @Campo
    public float Disponible;

    @Campo
    public float NoDisponible;

    @Campo
    public float Apartado;

    @Campo
    public float Contenido;

    @Campo
    public float Pedido;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;
}