package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@TablaDef(orden=1)
public class ConteoInventario extends Entidad{
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

    @Hijos(tablaHijos = ConteoInventarioDet.class)
    public List<ConteoInventarioDet> ConteoInventarioDet;

    public ConteoInventario()
    {
        ConteoInventarioDet = new ArrayList<ConteoInventarioDet>();
    };
}
