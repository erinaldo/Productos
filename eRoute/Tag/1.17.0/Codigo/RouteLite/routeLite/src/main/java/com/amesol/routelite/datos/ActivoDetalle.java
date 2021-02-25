package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class ActivoDetalle extends Entidad {
	
	@Llave()
	@Requerido
	public String ActivoDetalleID;
	
	@Campo
	@Requerido
	public String ActivoClave;
	
	@Campo
	@Requerido
	public String IdElectronico;
	
	@Campo
	public String ClienteClave;

    @Campo
    @Requerido
    public short TipoEstado;

    @Campo
    @Requerido
    public short TipoFase;

    @Campo
    public String Comentario;

    @Campo
    public String Imagen;

	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
}
