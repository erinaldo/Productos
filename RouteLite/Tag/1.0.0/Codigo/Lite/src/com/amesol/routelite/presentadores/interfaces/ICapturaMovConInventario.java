package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface ICapturaMovConInventario extends IVista
{
	public void refrescarProductos(String TransProdId);

	public void setFolio(String folio);

	public void setFecha(String fecha);

	public void setLimpiarMotivo();
}
