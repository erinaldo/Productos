package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden = 3)
public class MovimVisita extends Entidad
{

	@Campo
	@LlaveForanea(nombreCampoForaneo = "DiaClave", tablaPadre = Dia.class)
	public String DiaClave;

	@Campo
	@LlaveForanea(nombreCampoForaneo = "VendedorId", tablaPadre = Vendedor.class)
	public String VendedorId;

	@Campo
	@LlaveForanea(nombreCampoForaneo = "RUTClave", tablaPadre = Ruta.class)
	public String RUTClave;
	@Campo
	public int ACTId;
	@Campo
	public String ModuloMovDetalleClave;

	@Campo
	public String TipoIndiceModuloMovDetClave;
	@Campo
	public String MUsuarioID;
	@Campo
	public String USUId;
	@Campo
	public boolean Enviado;
	@Campo
	public String AlmacenID;

	@Hijos(tablaHijos = TransProd.class)
	public ArrayList<TransProd> mTransPord;

	public MovimVisita()
	{
		mTransPord = new ArrayList<TransProd>();
	}

}
