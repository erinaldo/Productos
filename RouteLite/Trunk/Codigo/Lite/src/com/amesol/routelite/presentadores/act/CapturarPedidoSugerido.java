package com.amesol.routelite.presentadores.act;

import android.database.Cursor;
import android.database.CursorWrapper;

import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedidoSugerido;


public class CapturarPedidoSugerido extends Presentador {

	ICapturaPedidoSugerido mVista;
	String mAccion;
	
	public CapturarPedidoSugerido(ICapturaPedidoSugerido vista, String accion){
		mVista = vista;
		mAccion = accion;
	}
	
	@Override
	public void iniciar() {
		try {
			mVista.iniciar();
			if(mVista.obtenerProductos() != null){
				mVista.mostrarProductos(mVista.obtenerProductos());
			}
		} catch (Exception e) {
			mVista.mostrarError(e.getMessage());
		}
	}
		
	public void verificarPrecios(Cursor productos){
		CursorWrapper fproductos = new CursorWrapper(productos);
		//fproductos.
	}

}
