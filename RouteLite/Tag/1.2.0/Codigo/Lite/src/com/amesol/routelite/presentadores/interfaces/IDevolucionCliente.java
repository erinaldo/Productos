package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface IDevolucionCliente extends IVista {
	public void setFolio(String folio);
	public void setFecha(String fecha);
	public void setListaPrecio(String lista);
	public void setParametrosCaptura(String precioClave, String transProdIds);
	public void setHuboCambios(boolean cambios);
	public void setTotal(String total);
	public void setProductosDev(String productos);
	public void setTipoMotivo(short motivo);
	public boolean getEsNuevo();
	public void setFactura(String factura);
	public void refrescarProductos(String TransProdId);
}
