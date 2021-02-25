package com.amesol.routelite.presentadores.interfaces;

import android.database.Cursor;

import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.presentadores.IVista;

public interface  ICapturaPedido extends IVista {
	//public void presentarProductos(String accion,Cursor datosProductos) throws Exception;
	
	void setListaPrecios(String valor);
	void setHuboCambios(boolean cambio);
	
	void refrescarProductos(String TransProdId);
	//void mostrarUnidades(ISetDatos unidades);
	//void seleccionarProducto(String ProductoClave, String TipoUnidad);
	
	public void setProductoActual(Producto oProducto);
	public boolean getSurtir();
	public boolean getReparto();
    public boolean getModificandoPedidoReparto();
	public boolean getModificandoPedidoNoReparto();
    public boolean getSoloLectura();
	void ocultarPedidoSugerido();
	
	public void setSurtir(boolean surtir);
	public void setSoloLectura(boolean soloLectura); 
	public void setEsNuevo(boolean esNuevo);
	public void setCapturaEnabled(boolean enabled);
	public void setCapturaCantidad(float cantidad);

	public void setMensajeLimiteCredito(boolean mensaje, boolean error);
	public void setMensajeLimiteEnvase(boolean mostrandoMensaje, boolean error);
	//public void salir();
}
