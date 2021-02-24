package com.duxstar.dacza.presentadores.act;

import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IConsultaInvenario;

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
