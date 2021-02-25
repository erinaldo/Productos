package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

/*Se usa cuando se recibe actualizacion en XML*/

@TablaDef
public class VARValor extends Entidad {
    @Llave
    public String VARCodigo;

    @Llave
    public String VAVClave;

    @Campo
    public String ClaveSAT;

    @Campo
    public String Grupo;

    @Campo
    public short Estado;


}
