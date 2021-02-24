package com.duxstar.dacza.datos;

import com.duxstar.dacza.datos.annotations.Campo;
import com.duxstar.dacza.datos.annotations.Llave;
import com.duxstar.dacza.datos.annotations.LlaveForanea;
import com.duxstar.dacza.datos.annotations.TablaDef;
import com.duxstar.dacza.datos.generales.Entidad;

@TablaDef
public class FolioDetalle extends Entidad {
    @Llave
    public String DetalleId;

    @Campo
    @LlaveForanea(nombreCampoForaneo="FolioId", tablaPadre=Folio.class)
    public String FolioId;

    @Campo
    public int TipoContenido;

    @Campo
    public String Formato;
}
