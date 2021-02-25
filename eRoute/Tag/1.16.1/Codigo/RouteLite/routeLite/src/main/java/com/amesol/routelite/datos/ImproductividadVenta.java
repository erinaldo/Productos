package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 3)
public class ImproductividadVenta extends Entidad
{
	@Llave
	public String VisitaClave;

	@Campo
	public String DiaClave;

	@Campo
	public short TipoMotivo;

	@Campo
	public String Comentario;

    @Campo
    public String IdImagenEvidencia;

	@Campo
	public Date MFechaHora;

	@Campo
	public String MUsuarioID;

	@Campo
	public boolean Enviado;
}
