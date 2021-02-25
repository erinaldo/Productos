package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;

import java.util.Date;

@TablaDef(orden=1)
public class ConteoInventario {
    @Llave()
    @Requerido
    public String ContId;

    @Campo
    @Requerido
    public Date FechaHoraAlta;

    @Campo
    @Requerido
    public String AlmacenID;

    @Campo
    @Requerido
    public Short TipoFase;

    @Campo
    @Requerido
    public String UsuarioId;

    @Campo
    @Requerido
    public Date MFechaHora;

    @Campo
    @Requerido
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}
