package com.amesol.routelite.datos.utilerias;

import java.util.Hashtable;

import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;

public class CONHist
{
	private Hashtable<String, Object> datos = new Hashtable<String, Object>();

	public CONHist()
	{
		try
		{
			ISetDatos sdDatos = Consultas.ConsultasCONHist.obtenerCONHist();
			if (sdDatos.getCount() > 0)
			{
				sdDatos.moveToFirst();
				for (int i = 0; i < sdDatos.getColumnCount(); i++)
				{
					set(sdDatos.getColumnName(i), sdDatos.getString(i));
				}
			}
			sdDatos.close();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	public Object get(String campo)
	{
		return datos.get(campo);
	}

	private void set(String campo, Object valor)
	{
		datos.put(campo.toString(), valor);
	}

}
