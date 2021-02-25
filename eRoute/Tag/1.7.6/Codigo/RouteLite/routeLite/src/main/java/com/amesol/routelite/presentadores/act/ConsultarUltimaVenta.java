package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaUltimaVenta;

public class ConsultarUltimaVenta extends Presentador
{

	IConsultaUltimaVenta mVista;
	String mAccion;
	
	public ConsultarUltimaVenta(IConsultaUltimaVenta vista, String accion){
		mVista = vista;
		mAccion = accion;
	}
	
	@Override
	public void iniciar()
	{
		mVista.iniciar();
	}

}
