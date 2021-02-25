package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.datos.Agenda;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ImproductividadVenta;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.utilerias.Generales;

public class NoVisitarCliente extends Presentador
{

	INoVisitaCliente mVista;
	String mAccion;

	public NoVisitarCliente(INoVisitaCliente vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)))
			mVista.mostrarMotivosNoVisita("'Terminar Visita'");
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VENTA)))
			mVista.mostrarMotivosNoVisita("'Venta'");
		mVista.iniciar();
	}

	private void guardarAgenda(Agenda agenda)
	{
		try
		{
			agenda.TipoMotivo = mVista.getMotivoNoVisita();
			agenda.Comentario = mVista.getComentario();
			agenda.Visitado = 4;
			agenda.Enviado = false;
			BDVend.guardarInsertar(agenda);
			BDVend.commit();
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getCause().toString() + ". " + e.getMessage());
			e.printStackTrace();
		}
	}

	public void mContinuar()
	{

		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE)))
			if (validar())
			{
				guardarAgenda(obtenerAgenda());
				mVista.finalizar();
				mVista.iniciarActividad(IAtencionClientes.class, false);
			}
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VENTA)))
			if (validar())
			{
				guardarInproductividad();
				mVista.finalizar();
			}
	}

	private void guardarInproductividad()
	{
		try
		{
			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			ImproductividadVenta mImproductividadVenta = new ImproductividadVenta();
			mImproductividadVenta.VisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
			mImproductividadVenta.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			mImproductividadVenta.MUsuarioID = vendedor.USUId;
			mImproductividadVenta.MFechaHora = Generales.getFechaHoraActual();
			mImproductividadVenta.Comentario = mVista.getComentario();
			mImproductividadVenta.TipoMotivo = mVista.getMotivoNoVisita();
			mImproductividadVenta.Enviado = false;
			BDVend.guardarInsertar(mImproductividadVenta);
			BDVend.commit();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

	}

	private boolean validar()
	{
		if (mVista.getMotivoNoVisita() == -1)
		{
			mVista.mostrarMensajeRequerido();
			return false;
		}
		return true;
	}

	private Agenda obtenerAgenda()
	{
		try
		{
			Dia dia = (Dia) Sesion.get(Campo.DiaActual);
			Ruta ruta = (Ruta) Sesion.get(Campo.RutaActual);
			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			return Consultas.ConsultasAgenda.obtenerAgendaPorDiaClienteRutaVendedor(dia, ruta, vendedor, cliente);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			e.printStackTrace();
			return null;
		}
	}
}
