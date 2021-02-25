package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface IDevolucionCliente extends IVista {
	public void setFolio(String folio);
	public void setFecha(String fecha);
	public void setListaPrecio(String lista);
	public void setParametrosCaptura(String listaPrecios, String transProdIds);
	public void setHuboCambios(boolean cambios);
	public void setTotal(String total);
	public void setProductosDev(String productos);
	public void setTipoMotivo(short motivo);
	public boolean getEsNuevo();
	public void setFactura(String factura);
	public void refrescarProductos(String TransProdId);
    public void setMensajeLimiteEnvase(boolean mostrandoMensaje);
    public boolean getMensajeLimiteEnvase();
    /*inicio codigo ldelatorre*/
    public void setVolumen(String volumen);
    public void setTelefono(String telefono);
    public void setDireccion(String direccion);
	/*inicio codigo ldelatorre*/
    public void guardar(String sNombre, String sNombreArchivo);
}
