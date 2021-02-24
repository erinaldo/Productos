package com.duxstar.dacza.presentadores.interfaces;

import com.duxstar.dacza.presentadores.IVista;

public interface ICapturaDevolucion extends IVista {
	public void setFolio(String folio);
	public void setFecha(String fecha);
	public void refrescarProductos(String OrdenId);
	public void setHuboCambios(boolean cambio);
	public boolean getHuboCambios();
	public void setCantidadCaptura(Float cantidad);
}
