package com.duxstar.dacza.presentadores.interfaces;

import java.util.ArrayList;
import java.util.HashMap;

import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.IVista;
import com.duxstar.dacza.presentadores.act.CapturarArticuloOrden;

public interface ICapturaArticuloOrden extends IVista {
	public void setFolio(String folio);
	public void setFecha(String fecha);
	public void refrescarProductos(String OrdenId);
	public void setHuboCambios(boolean cambio);
	public boolean getHuboCambios();
	public void setCantidadCaptura(Float cantidad);
}
