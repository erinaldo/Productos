package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.Requerido;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

import java.util.Comparator;
import java.util.Date;

@TablaDef (orden = 9)
public class DEVDetalle extends Entidad {
    @Llave
    @LlaveForanea(nombreCampoForaneo="DevolucionId", tablaPadre=Devolucion.class)
    public String DevolucionId;

    @Llave
    @LlaveForanea(nombreCampoForaneo="ArticuloId", tablaPadre=Articulo.class)
    @Requerido
    public String ArticuloId;

    @Campo
    @Requerido
    public float Cantidad;

    @Campo
    public int Partida;

    @Campo
    public Date MFechaHora;

    @Campo
    @LlaveForanea(nombreCampoForaneo="UsuarioId", tablaPadre=Usuario.class)
    public String MUsuarioId;

    @Campo
    public boolean Enviado;

    public Articulo articulo;
    public boolean recienAgregado;
    public boolean cantidadModificada;
    public boolean modificado;

    public static class comparator implements Comparator<DEVDetalle> {
        @Override
        public int compare(DEVDetalle arg0, DEVDetalle arg1) {
            return arg0.Partida - arg1.Partida;
        }
    }
}
