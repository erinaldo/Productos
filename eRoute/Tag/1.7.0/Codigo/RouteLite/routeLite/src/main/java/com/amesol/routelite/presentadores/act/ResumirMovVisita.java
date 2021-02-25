package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IResumenMovVisita;

public class ResumirMovVisita extends Presentador {

	IResumenMovVisita mVista;
	String mAccion;
	
	public ResumirMovVisita(IResumenMovVisita vista, String accion){
		mVista = vista;
		mAccion = accion;
	}
	
	@Override
	public void iniciar() {
		// TODO Auto-generated method stub
		mVista.iniciar();
		mVista.mostrarTransacciones();
	}

}
