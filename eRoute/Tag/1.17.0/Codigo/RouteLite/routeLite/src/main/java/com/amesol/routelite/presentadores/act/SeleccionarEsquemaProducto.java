package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.presentadores.interfaces.ISeleccionEsquemaProducto;

public class SeleccionarEsquemaProducto extends Presentador
{

	ISeleccionEsquemaProducto mVista;
	String mAccion;
	
	public SeleccionarEsquemaProducto(ISeleccionEsquemaProducto vista, String accion){
		mVista = vista;
		mAccion = accion;
		//oParametros = new HashMap<String, Object>();
	}
	
	@Override
	public void iniciar()
	{
		try {
			mVista.iniciar();
			mVista.mostrarEsquemas(mVista.obtenerEsquemas());
		} catch (Exception e) {
			mVista.mostrarError(e.getMessage());
		}
		
	}
	
	

}
