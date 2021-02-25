package com.amesol.routelite.presentadores.act;

import java.text.SimpleDateFormat;
import java.util.Date;

import com.amesol.routelite.presentadores.Presentador;

public class SeleccionarEncuesta extends Presentador
{

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub
		
	}
	
	public String faseString(int fase){
		String cadenaFase = "";
		
		switch (fase)
		{
			case 0:
				cadenaFase = "Cancelada";
				break;

			case 1:
				cadenaFase = "Aplicada";
				break;
				
			case 2: 
				cadenaFase = "Parcialmente Aplicada";
				break;
		}
		
		return cadenaFase;
	}
	
	public String fechaString(Date fecha)
	{
		SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yy HH:mm:ss");
		String sFecha = sdf.format(fecha);
		return sFecha;
		
	}

}
