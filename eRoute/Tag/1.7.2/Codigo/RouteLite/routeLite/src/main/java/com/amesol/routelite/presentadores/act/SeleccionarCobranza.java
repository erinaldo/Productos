package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.presentadores.interfaces.ISeleccionCobranza;

//import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;

public class SeleccionarCobranza extends Presentador
{

	ISeleccionCobranza mVista;
	String mAccion;
	Vendedor oVendedor;
	ArrayList<Cobranza.VistaCobranza> oAbonos;
	String clienteClave;
	String diaClave;
	String visitaClave;

	public SeleccionarCobranza(ISeleccionCobranza vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		try
		{
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			Dia dia = (Dia) Sesion.get(Campo.DiaActual);
			Visita visita = (Visita) Sesion.get(Campo.VisitaActual);

			mVista.setCliente(cliente.Clave + " - " + cliente.RazonSocial);
			mVista.setRuta(((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
			mVista.setDia(((Dia) Sesion.get(Campo.DiaActual)).DiaClave);

			diaClave = dia.DiaClave;
			clienteClave = cliente.ClienteClave;
			visitaClave = visita.VisitaClave;

			actualizarCobranza();
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}

	}

	public void actualizarCobranza()
	{
		try
		{
			oAbonos = Consultas.ConsultasAbono.obtenerCobranzaPorVisita(diaClave, clienteClave, visitaClave);
			if (oAbonos.toArray().length > 0)
				mVista.mostrarCobranzaCliente(oAbonos);
			else
			{
				// mVista.finalizar();
				generarCobranza();
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private void generarCobranza()
	{
		try
		{
			mVista.iniciarActividadConResultado(ICapturaCobranzaDocs.class, 0, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}

	};

	public boolean eliminarCobranza(String abnid)
	{
		try
		{
			Cobranza.eliminarCobranza(abnid);
			return true;
		}

		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			e.printStackTrace();
			return false;
		}

	}

	public boolean existenAbonos()
	{
		if (oAbonos != null && oAbonos.toArray().length > 0)
			return true;
		return false;
	}

}
