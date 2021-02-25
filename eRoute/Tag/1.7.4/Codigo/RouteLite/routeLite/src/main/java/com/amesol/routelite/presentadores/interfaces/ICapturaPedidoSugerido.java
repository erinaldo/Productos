package com.amesol.routelite.presentadores.interfaces;

import android.database.Cursor;

import com.amesol.routelite.presentadores.IVista;

public interface  ICapturaPedidoSugerido extends IVista {
	Cursor obtenerProductos();
	void mostrarProductos(Cursor productos);
	//public void presentarProductos(String accion,Cursor datosProductos) throws Exception;
	

	/*void setListaPrecios(String valor);
	void setHuboCambios(boolean cambio);
	
	
	void refrescarProductos(String TransProdId);*/
	//void mostrarUnidades(ISetDatos unidades);
	//void seleccionarProducto(String ProductoClave, String TipoUnidad);
	
	//public void setProductoActual(Producto oProducto);
}
