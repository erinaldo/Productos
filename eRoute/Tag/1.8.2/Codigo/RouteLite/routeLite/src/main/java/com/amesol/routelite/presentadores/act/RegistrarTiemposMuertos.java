package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IRegistroTiemposMuertos;

public class RegistrarTiemposMuertos extends Presentador {

	IRegistroTiemposMuertos mVista;
	
	public RegistrarTiemposMuertos(IRegistroTiemposMuertos vista){
		mVista = vista;
	}
	
	@Override
	public void iniciar() {
		mVista.mostrarMotivos();
		mVista.iniciar();
	}

	public void mIniciar(){
		if(validar()){
			mVista.cambiarVista();
			mVista.iniciarCronometro();
		}
	}
	
	public void mTerminar(){
		mVista.mostrarTiempoRegistrado();
	}
	
	private boolean validar(){
		if(mVista.getMotivo() == -1){
			mVista.mostrarMensajeRequerido();
			return false;
		}
		return true;
	}
}
