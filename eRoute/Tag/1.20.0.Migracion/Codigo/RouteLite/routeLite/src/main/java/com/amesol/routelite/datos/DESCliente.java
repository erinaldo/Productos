package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;


@TablaDef
public class DESCliente extends Entidad {
	public DESCliente(String descuentoClave, String clienteClave,
			short tipoEstado, int jerarquia) {

		DescuentoClave = descuentoClave;
		ClienteClave = clienteClave;
		TipoEstado = tipoEstado;
		Jerarquia = jerarquia;
	}
	
	public DESCliente(){	}
	
	
	@Llave
	@LlaveForanea( nombreCampoForaneo="DescuentoClave", tablaPadre=Descuento.class)
	public String DescuentoClave;
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ClienteClave", tablaPadre=Cliente.class)
	public String ClienteClave;
	@Campo
	public short TipoEstado;
	

	
	@Campo
	public int Jerarquia;
}
