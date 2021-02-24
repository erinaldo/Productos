package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

import java.util.Date;

@TablaDef (orden = 2)
public class Folio extends Entidad {
    @Llave
    public String FolioId;

    @Campo
    public int TipoMovimiento;

    @Campo
    public int ValorInicial;

    @Campo
    public int Usados;

    @Campo
    public Date MFechaHora;

    @Campo
    @LlaveForanea(nombreCampoForaneo="UsuarioId", tablaPadre=Usuario.class)
    public String MUsuarioId;

    @Campo
    public boolean Enviado;

}
