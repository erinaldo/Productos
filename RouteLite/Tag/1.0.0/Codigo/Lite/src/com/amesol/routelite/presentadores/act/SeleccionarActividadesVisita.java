package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IImpresionTicket;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionCobranza;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;

public class SeleccionarActividadesVisita extends Presentador
{

	ISeleccionActividadesVisita mVista;
	String mAccion;

	public SeleccionarActividadesVisita(ISeleccionActividadesVisita vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();
			// mVista.mostrarActividades(Consultas.ConsultasActividades.obtenerModulos((Vendedor)Sesion.get(Campo.VendedorActual),mVista.getActivity()));
			mVista.mostrarActividades(Consultas.ConsultasActividades.obtenerActividadesVisita((Vendedor) Sesion.get(Campo.VendedorActual)));
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void seleccionar()
	{
		// TODO: iniciar la actividad correspondiente a la seleccion
		Sesion.set(Campo.ModuloMovDetalleClave, mVista.getActividad().getModuloMovDetalleClave());
		Sesion.set(Campo.TipoIndiceModuloMovDetalleClave, mVista.getActividad().getTipoIndice());

		// int i = mVista.getActividad().getTipoIndice(); // elopez add this
		// line to debug, i found a fail on this section

		switch (mVista.getActividad().getTipoIndice())
		{
			case TiposModuloMovDetalle.PEDIDO: // pedidos
				if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
					mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR);
				}else{
					mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS);
				}
				break;
			case TiposModuloMovDetalle.CAMBIOS: // cambios
				mVista.iniciarActividadConResultado(ISeleccionPedido.class, Enumeradores.Solicitudes.SOLICITUD_CAMBIOS_PRODUCTO_ENTRADA, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_CAMBIOS);
				break;
			case TiposModuloMovDetalle.IMPRESION:
				mVista.iniciarActividad(IImpresionTicket.class, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA, null, false);
				break;
			/*
			 * case 27: HashMap<String, String> parametros = new HashMap<String,
			 * String>(); parametros.put("Esquema", Mensajes.get("XTodos"));
			 * parametros.put("Producto", ""); //pasarle el producto que se va a
			 * buscar mVista.iniciarActividadConResultado(IBuscaProducto.class,
			 * 0, "", parametros); break;
			 */
			case TiposModuloMovDetalle.COBRANZAMULTIPLE:
				mVista.iniciarActividadConResultado(ISeleccionCobranza.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_SELECCIONAR_COBRANZA);
				break;
			case TiposModuloMovDetalle.DEVOLUCIONCLIENTES:
				mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_DEVOLUCIONES);
				break;
			case TiposModuloMovDetalle.NO_VENTA:
				mVista.iniciarActividad(INoVisitaCliente.class, Enumeradores.Acciones.ACCION_NO_VENTA, null, false);
				break;	
		}

		// mVista.mostrarAdvertencia(mVista.getActividad().getNombre()
		// +"Lista Precio " + oPrecio.PrecioClave +" " +oPrecio.Nombre) ;
		// mVista.iniciarActividad(IConsultaPromociones.class);
		//
		// Impuestos Imp = new Impuestos();
		// Impuesto[] imps = Imp.Buscar("01", (short) 1);
		// double res =Imp.Calcular(imps, 10, 11);
		//
		// for (int i =0;i<imps.length;i++)
		// {
		// mVista.mostrarAdvertencia(imps[i].ImpuestoClave);
		// }
		// mVista.mostrarAdvertencia("Producto 1 " + lista.BuscarPrecio("01",
		// (short) 2, oPrecio.PrecioClave)) ;
	}
}
