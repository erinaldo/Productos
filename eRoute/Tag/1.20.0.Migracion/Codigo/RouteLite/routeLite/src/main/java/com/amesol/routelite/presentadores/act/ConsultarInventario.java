package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaInvenario;

public class ConsultarInventario extends Presentador
{

	IConsultaInvenario mVista;
	
	public ConsultarInventario(IConsultaInvenario vista)
	{
		mVista = vista;		
	}
	
	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub
		
	}
	
	//public void obtenerInventario
}
