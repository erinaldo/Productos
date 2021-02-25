package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface ICapturaMovConInventario extends IVista
{
	public void refrescarProductos(String TransProdId);

	public void setFolio(String folio);

	public void setFecha(String fecha);
	
	public void setMotivo(Short tipo);
	
	public Short getMotivo();

    public String getDestino();

	public boolean getManejarConfirmarCarga();

	public boolean getConfirmando();

    public boolean esTraspasoRuta();

	/*public void setLimpiarMotivo();*/
    public void guardar(String sNombre, String sNombreArchivo);

}
