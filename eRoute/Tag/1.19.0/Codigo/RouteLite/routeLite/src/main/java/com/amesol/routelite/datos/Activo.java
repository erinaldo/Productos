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
public class Activo extends Entidad {
	
	@Llave()
	@Requerido
	public String ActivoClave;
	
	@Campo
	@Requerido
	public String Nombre;
	
	@Campo
    @Requerido
    public short Tipo;

    @Campo
    public float Altura;

    @Campo
    public float Ancho;

    @Campo
    public float Profundidad;

    @Campo
    public String DatosExtra;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
}
