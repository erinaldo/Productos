package com.amesol.routelite.presentadores.act;


import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;

public class BuscarProducto extends Presentador {

	IBuscaProducto mVista;
	String mAccion;
	//HashMap<String, Object> oParametros;
	
	public BuscarProducto(IBuscaProducto vista, String accion){
		mVista = vista;
		mAccion = accion;
		//oParametros = new HashMap<String, Object>();
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

/*	public void setParametros(	HashMap<String, Object> parametros)
	{
		oParametros=parametros;
	}
*/
}
