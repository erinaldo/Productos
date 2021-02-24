package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.Requerido;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

import java.util.Comparator;
import java.util.Date;

@TablaDef (orden = 7)
public class RECDetalle extends Entidad {

    @Llave
    public String DetalleId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="RecargaId", tablaPadre=Recarga.class)
    @Requerido
    public String RecargaId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="ArticuloId", tablaPadre=Articulo.class)
    public String ArticuloId;

    @Campo
    public String ArticuloDesc;

    @Campo
    @Requerido
    public float Cantidad;

    @Campo
    public int Partida;

    @Campo
    public String Imagen;

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

    public static class comparator implements Comparator<RECDetalle> {
        @Override
        public int compare(RECDetalle arg0, RECDetalle arg1) {
            return arg0.Partida - arg1.Partida;
            //if(arg0.ArticuloId != null && arg1.ArticuloId != null)
                //return arg0.ArticuloId.compareToIgnoreCase(arg1.ArticuloId);
            //return 0;
        }
    }
}
