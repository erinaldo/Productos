package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;

public class RevisarPendientes extends Presentador
{

	IRevisionPendientes mVista;

	public RevisarPendientes(IRevisionPendientes vista)
	{
		mVista = vista;
	}

	@Override
	public void iniciar()
	{

	}
	
	public void toActividadesVed()
	{
		try
		{
			BDVend.cerrar();
			BDVend.Iniciar();
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.mostrarError(e.getMessage());
			return;
		}
		if (!BDVend.estaAbierta())
		{
			try
			{
				mVista.iniciarActividadConResultado(ISolicitudAgendaVendedor.class, Enumeradores.Solicitudes.SOLICITUD_AGENDA, Enumeradores.Acciones.ACCION_AGENDA_VENDEDOR);
			}
			catch (Exception e)
			{
				e.printStackTrace();
				mVista.mostrarError(e.getMessage());
				return;
			}
		}
		if (BDVend.estaAbierta())
		{
			mVista.iniciarActividad(ISeleccionActividadesVend.class, false);
		}
	}
}
