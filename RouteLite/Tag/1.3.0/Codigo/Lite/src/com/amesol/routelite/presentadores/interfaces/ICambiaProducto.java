package com.amesol.routelite.presentadores.interfaces;

import java.util.ArrayList;

import com.amesol.routelite.datos.SaldoCambiosVendedor;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.presentadores.act.CambiarProducto;

public interface ICambiaProducto extends IVista {
	public void setFolio(String folio);
	public void setFecha(String fecha);
	//public void mostrarUnidades(ISetDatos unidades);
	public void refrescarProductos(String TransProdId);
	public void setHuboCambios(boolean cambio);
	public short getTipoMotivo();
	public boolean getCambioAutomatico();
	public int getTipoValidacionInventario();
	public void setParametrosCaptura(String listaPrecios, String transProdIds);
	public boolean getEsNuevo();
	public void setTipoMotivo(short motivo);
	public boolean getHuboCambios(); 
	public void setCantidadCaptura(Float cantidad);
	public SaldoCambiosVendedor getSaldoCambiosVendedor();	
}
