package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.CapturarLiquidacionConsignacion.VistaConsignacionLiquidacion;

public interface ICapturaLiquidacionConsignacion extends IVista
{
	public String getAccion();
	public void setFolio(String folio);
	public void setFecha(String fecha);
	public void cargaDetalle(VistaConsignacionLiquidacion[] detalle);
	public void setTotales(float importeLiquidar, float devoluciones, Float saldo);
	public void preguntarSiGeneraConsignacion();
}
