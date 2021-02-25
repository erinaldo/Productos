package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

/*Se usa cuando se recibe actualizacion en XML*/
@TablaDef
public class VAVDescripcion extends Entidad {
    @Llave
    @LlaveForanea( nombreCampoForaneo="VARCodigo", tablaPadre= VARValor.class)
    public String VARCodigo;

    @Llave
    @LlaveForanea( nombreCampoForaneo="VAVClave", tablaPadre= VARValor.class)
    public String VAVClave;

    @Campo
    public String Descripcion;

    @Campo
    public String DescripcionSAT;
}
