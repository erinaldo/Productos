package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

import java.util.Date;

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
    public boolean getbValidarFactura();
	public void setFactura(String factura);
    public void setComentarios(String comentarios);
    public void setbCargandoComentarios(boolean valor);
	public void refrescarProductos(String TransProdId);
    public void setMensajeLimiteEnvase(boolean mostrandoMensaje);
    public boolean getMensajeLimiteEnvase();
    /*inicio codigo ldelatorre*/
    public void setVolumen(String volumen);
    public void setTelefono(String telefono);
    public void setDireccion(String direccion);
    public void setMotivos(String grupo);
    public void setRecoleccion(boolean recoleccion);
    public void setFechaRecoleccion(Date fechaRecoleccion);
    public void ocultarRecoleccion();
    public void habilitarRecoleccion(boolean habilitar);
    public short getTipoMotivoCancelacion();
	/*inicio codigo ldelatorre*/
    public void guardar(String sNombre, String sNombreArchivo);
}
