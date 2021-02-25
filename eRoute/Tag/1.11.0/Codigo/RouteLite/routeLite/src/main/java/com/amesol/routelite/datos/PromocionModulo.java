package com.amesol.routelite.datos;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=3)
public class PromocionModulo extends Entidad {
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="PromocionClave", tablaPadre=Promocion.class)
	public String PromocionClave;
	
	@Llave()
	@LlaveForanea( nombreCampoForaneo="ModuloMovDetalleClave", tablaPadre=ModuloMovDetalle.class)
	public String ModuloMovDetalleClave;
	
	@Campo
	public boolean AplicaDescuento;
	
	@Campo
	public short TipoEstado;

}
