package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;

public class AutorizarMovimiento extends Presentador{

	IAutorizaMovimiento mVista;
	String mAccion;
	
	public AutorizarMovimiento(IAutorizaMovimiento vista, String accion){
		mVista = vista;
		mAccion = accion;
	}
	
	@Override
	public void iniciar() {
		try{
			mVista.iniciar();
			
			if((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA))){
				mVista.setToken(mVista.obtenerToken());
			}
			
		}catch (Exception ex){
			ex.printStackTrace();
		}
	}

}
