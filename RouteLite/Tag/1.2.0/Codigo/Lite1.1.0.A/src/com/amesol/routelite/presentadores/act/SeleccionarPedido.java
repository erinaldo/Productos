package com.amesol.routelite.presentadores.act;

import java.util.Date;
import java.util.HashMap;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.Acciones;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.Enumeradores.Solicitudes;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovSinInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;
import com.amesol.routelite.utilerias.ControlError;

public class SeleccionarPedido extends Presentador
{

	public static class VistaPedidos
	{
		private String TransprodID;
		private String Folio;
		private int TipoFase;
		private String Fase;
		private Date Fecha;
 
		public VistaPedidos(String transprodid, String folio, int tipofase, String fase, Date fecha)
		{
			TransprodID = transprodid;
			Folio = folio;
			TipoFase = tipofase;
			Fase = fase;
			Fecha = fecha;
		}

		public String getTransprodID()
		{
			return TransprodID;
		}

		public void setTransprodID(String transprodID)
		{
			TransprodID = transprodID;
		}

		public String getFolio()
		{
			return Folio;
		}

		public void setFolio(String folio)
		{
			Folio = folio;
		}

		public int getTipoFase()
		{
			return TipoFase;
		}

		public void setTipoFase(int tipoFase)
		{
			TipoFase = tipoFase;
		}

		public String getFase()
		{
			return Fase;
		}

		public void setFase(String fase)
		{
			Fase = fase;
		}

		public Date getFecha()
		{
			return Fecha;
		}

		public void setFecha(Date fecha)
		{
			Fecha = fecha;
		}
	}

	ISeleccionPedido mVista;
	String mAccion;

	boolean iniciarActividad;
	Class<?> actvdd;
	String sTransProdIdSeleccionado;

	public SeleccionarPedido(ISeleccionPedido vista, String accion)
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

			try
			{
				// TODO: Validar vencimiento de ventas
				if (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS))
					ValidarVencimientoVenta();
			}
			catch (ControlError ex)
			{
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL, ex.getMessage());
				mVista.finalizar();
				return;
			}

			if (mVista.obtenerPedidos().length > 0)
			{
				iniciarActividad = false;
				mVista.mostrarVentasCliente(mVista.obtenerPedidos());
			}
			else
			{

				if (mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS))
				{
					return;
				}
				if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)){
					MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
					String clientesPedido = oConf.get("ClientesPedido").toString();
					String ventaReparto = oConf.get("VentaReparto").toString();
					if(clientesPedido.equals("0") && ventaReparto.equals("1")){
						mVista.setResultado(Resultados.RESULTADO_MAL, Mensajes.get("P0086"));
						mVista.finalizar();
					}else if(ventaReparto.equals("0")){
						mVista.setResultado(Resultados.RESULTADO_MAL, Mensajes.get("I0187"));
						mVista.finalizar();
					}
				}
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				mVista.finalizar();
				if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS) || mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR))
					mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, null);
				else if (mAccion.equals(Acciones.ACCION_MOSTRAR_CAMBIOS))
					mVista.iniciarActividadConResultado(ICambiaProducto.class, 0, Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA);
				else if (mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES))
					mVista.iniciarActividadConResultado(IDevolucionCliente.class, 0, null);
				else if (mAccion.equals(Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
					mVista.iniciarActividad(ICapturaMovSinInventario.class);
				else if (mAccion.equals(Acciones.ACCION_CAPTURAR_AJUSTES))
					mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_AJUSTES);
				else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DESCARGA))
					mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_DESCARGA);
				else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DEVOLUCION))
					mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_DEVOLUCION);
				else if(mAccion.equals(Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA))
					mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, Acciones.ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA);

				//				mVista.iniciarActividadConResultado(ICapturaMovimientosConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS);

			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private boolean existenAbonosAplicados(String TransProdId) throws Exception
	{
		boolean hayAbonos = false;
		ISetDatos abonos = Consultas.ConsultasAbnTrp.obtenerAbonos(TransProdId);
		if (abonos.getCount() > 0)
			hayAbonos = true;
		abonos.close();
		return hayAbonos;
	}
	
	private void abrirSoloLecturaReparto(SeleccionarPedido.VistaPedidos pedido, String surtir){
		mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		mVista.finalizar();
		HashMap<String, String> oParametros = new HashMap<String, String>();
		oParametros.put("TransProdId", pedido.getTransprodID());
		oParametros.put("Reparto", "true");
		oParametros.put("Surtir", surtir);
		mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, null, oParametros);
		mVista.finalizar();
	}
	
	public void surtirPedido(SeleccionarPedido.VistaPedidos pedido){
		abrirSoloLecturaReparto(pedido, "true");
	}
	
	public void abrirPedidoConsulta(SeleccionarPedido.VistaPedidos pedido){
		//abrirSoloLecturaReparto(pedido, "false");
		mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		mVista.finalizar();
		HashMap<String, String> oParametros = new HashMap<String, String>();
		oParametros.put("TransProdId", pedido.getTransprodID());
		oParametros.put("Reparto", "true");
		oParametros.put("Consultar", "true");
		mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, null, oParametros);
		mVista.finalizar();
	}

	public void modificar(SeleccionarPedido.VistaPedidos pedido)
	{
		if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS))
		{
			MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

				
				/*if (((Cliente) Sesion.get(Campo.ClienteActual)).){
					
				}*/
		        /*If Not oTransProd.ClienteActual.ExisteFormaVenta Then
		            MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0358"))
		            Exit Sub
	        	End If*/
				 if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO){
						if (!Boolean.parseBoolean(m.get("ModificarVenta").toString().equals("0") ? "false" : "true"))
						{
							mVista.mostrarError(Mensajes.get("I0164", mVista.getDescripcionFase(pedido.getTipoFase())));
							return;
						}
				 }

				/* if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO){		            
					 if (Me.TransProd.PendientesSurtidos) {
			                MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0598"), MsgBoxStyle.Exclamation)				 
					 }
				 }*/

		        

				if((pedido.getTipoFase() == 1 || pedido.getTipoFase() == 7 ) || (pedido.getTipoFase() == 2 && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA ))){
					
					/*
					 *            If Me.TransProd.VentaCobrada Then
                MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0496"), MsgBoxStyle.Exclamation)
                Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageGeneral
                Me.TabControlMovProducto.Refresh()
                Exit Sub
            End If

            If Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.CapturaEscritorio Then
                If Not ValidarVencimientoVenta() Then
                    Exit Sub
                End If
            End If

            If Not ValidarFechaEntregar() Then
                Exit Sub
            End If
            If Not Me.ValidarCamposRequeridos() Then
                Exit Sub
            End If
            'Validar Inventario Recoleccion Automatica de Envases
            If Me.TransProd.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso Me.TransProd.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then
                If oVendedor.motconfiguracion.RecAutoEnvVenta Then
                    Try
                        Inventario.ValidarInventarioRecoleccionAutomatica(Me.TransProd)
                    Catch ex As Exception
                        MsgBox(refaVista.BuscarMensaje("MsgBoxGeneral", "E0789").Replace("$0$", ex.Message), MsgBoxStyle.Exclamation)
                        Exit Sub
                    End Try
                End If
            End If
					 */
					mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					mVista.finalizar();
					HashMap<String, String> oParametros = new HashMap<String, String>();
					oParametros.put("TransProdId", pedido.getTransprodID());
					mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, null, oParametros);
					mVista.finalizar();
				}
				else
				{ // mostrar captura de pedido con el pedido seleccionado
					iniciarActividad = true;
					sTransProdIdSeleccionado = pedido.getTransprodID();
					mVista.mostrarMensajeEiniciarActividad(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())), ICapturaPedido.class); 
				 }
					 
		}
		else if (mAccion.equals(Acciones.ACCION_MOSTRAR_CAMBIOS))
		{
			HashMap<String, String> oParametros = new HashMap<String, String>();
			oParametros.put("TransProdId", pedido.getTransprodID());
			mVista.iniciarActividadConResultado(ICambiaProducto.class, Enumeradores.Solicitudes.SOLICITUD_CAMBIOS_PRODUCTO_ENTRADA, Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA, oParametros);
			mVista.finalizar();
		}
		else if (mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES))
		{
			// modificar dev
			HashMap<String, String> oParametros = new HashMap<String, String>();
			oParametros.put("TransProdId", pedido.getTransprodID());
			mVista.iniciarActividadConResultado(IDevolucionCliente.class, 0, null, oParametros);
			mVista.finalizar();	
		}
		else if (mAccion.equals(Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
		{
				try{
					TransProd oTpd = new TransProd();
					oTpd.TransProdID = pedido.getTransprodID();
					BDVend.recuperar(oTpd);	
					if (oTpd.Enviado){
						mVista.mostrarError(Mensajes.get("E0596", Mensajes.get("XModificar")));
						
					}else{
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						mVista.finalizar();
						HashMap<String, String> oParametros = new HashMap<String, String>();
						oParametros.put("TransProdId", pedido.getTransprodID());
						oParametros.put("Modificar", "true");
						mVista.iniciarActividadConResultado(ICapturaMovSinInventario.class, 0, null, oParametros);
						mVista.finalizar();				
					}

					
				}catch (Exception ex){
					mVista.mostrarError(ex.getMessage());
				}
							

		}
		else if (mAccion.equals(Acciones.ACCION_CAPTURAR_AJUSTES))
		{
			/*MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			if (Boolean.parseBoolean(m.get("ModificarVenta").toString().equals("0") ? "false" : "true"))
			{
				if (pedido.getTipoFase() == 0 || pedido.getTipoFase() == 2)
				{ // si esta cancelado o surtido, mostrar mensaje e iniciar
					// actividad
					iniciarActividad = true;
					sTransProdIdSeleccionado = pedido.getTransprodID();
					mVista.mostrarMensajeEiniciarActividad(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())), ICapturaPedido.class);
					// mVista.mostrarError(Mensajes.get("E0030",
					// mVista.getDescripcionFase(pedido.getTipoFase())));
				}
				else
				{ // mostrar captura de pedido con el pedido seleccionado*/
			
			if(!registroTransferido(pedido.getTransprodID(),false)){
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				mVista.finalizar();
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TransProdId", pedido.getTransprodID());
				oParametros.put("Modificar", "true");
				mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_AJUSTES, oParametros);
				mVista.finalizar();	
			}
				/*}
			}
			else
			{
				mVista.mostrarError(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())));
			}*/
		}
		else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DESCARGA))
		{
			/*MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			if (Boolean.parseBoolean(m.get("ModificarVenta").toString().equals("0") ? "false" : "true"))
			{
				if (pedido.getTipoFase() == 0 || pedido.getTipoFase() == 2)
				{ // si esta cancelado o surtido, mostrar mensaje e iniciar
					// actividad
					iniciarActividad = true;
					sTransProdIdSeleccionado = pedido.getTransprodID();
					mVista.mostrarMensajeEiniciarActividad(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())), ICapturaPedido.class);
					// mVista.mostrarError(Mensajes.get("E0030",
					// mVista.getDescripcionFase(pedido.getTipoFase())));
				}
				else
				{ // mostrar captura de pedido con el pedido seleccionado*/
			if(!registroTransferido(pedido.getTransprodID(),false)){
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				mVista.finalizar();
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TransProdId", pedido.getTransprodID());
				oParametros.put("Modificar", "true");
				mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_DESCARGA, oParametros);
				mVista.finalizar();	
			}
				/*}
			}
			else
			{
				mVista.mostrarError(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())));
			}*/
		}
		else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DEVOLUCION))
		{
			/*MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			if (Boolean.parseBoolean(m.get("ModificarVenta").toString().equals("0") ? "false" : "true"))
			{
				if (pedido.getTipoFase() == 0 || pedido.getTipoFase() == 2)
				{ // si esta cancelado o surtido, mostrar mensaje e iniciar
					// actividad
					iniciarActividad = true;
					sTransProdIdSeleccionado = pedido.getTransprodID();
					mVista.mostrarMensajeEiniciarActividad(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())), ICapturaPedido.class);
					// mVista.mostrarError(Mensajes.get("E0030",
					// mVista.getDescripcionFase(pedido.getTipoFase())));
				}
				else
				{ // mostrar captura de pedido con el pedido seleccionado*/
			if(!registroTransferido(pedido.getTransprodID(),false)){
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				mVista.finalizar();
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TransProdId", pedido.getTransprodID());
				oParametros.put("Modificar", "true");
				mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_DEVOLUCION, oParametros);
				mVista.finalizar();	
			}
				/*}
			}
			else
			{
				mVista.mostrarError(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())));
			}*/
		}
		else if (mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS))
		{
			try
			{
				if(!registroTransferido(pedido.getTransprodID(),false)){
					int Escri = 0;
					ISetDatos mTran = Consultas.ConsultasTransProd.obtenerTransProd(pedido.getTransprodID());
					while (mTran.moveToNext())
					{
						Escri = mTran.getInt(mTran.getColumnIndex("Escritorio"));

					}
					/*MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
					if (Boolean.parseBoolean(m.get("ModificarVenta").toString().equals("0") ? "false" : "true"))
					{
						if (pedido.getTipoFase() == 0 || pedido.getTipoFase() == 2)
						{ // si esta cancelado o surtido, mostrar mensaje e iniciar
							// actividad
							iniciarActividad = true;
							sTransProdIdSeleccionado = pedido.getTransprodID();
							mVista.mostrarMensajeEiniciarActividad(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())), ICapturaPedido.class);
							// mVista.mostrarError(Mensajes.get("E0030",
							// mVista.getDescripcionFase(pedido.getTipoFase())));
						}
						else
						{ // mostrar captura de pedido con el pedido seleccionado*/
							mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
							mVista.finalizar();
							HashMap<String, String> oParametros = new HashMap<String, String>();
							oParametros.put("TransProdId", pedido.getTransprodID());
							oParametros.put("Modificar", "true");
							if (Escri == 1)
							{
								mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS_NO_MODIFICAR, oParametros);
							}
							else
							{
								mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS, oParametros);
							}

							mVista.finalizar();
						/*}
					}
					else
					{
						mVista.mostrarError(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())));
					}*/	
				}
			}
			catch (Exception e)
			{

			}

		}
	}

	public void cancelar(SeleccionarPedido.VistaPedidos pedido)
	{
		try
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS) || mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR))
			{
				MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

				if (pedido.getTipoFase() == 0 || pedido.getTipoFase() == 3)
				{ // pedido cancelado, o facturado
					mVista.mostrarError(Mensajes.get("E0032", mVista.getDescripcionFase(pedido.getTipoFase())));
				}
				else
				{ // si se permite cancelar, validar si tiene abonos
					CONHist c = (CONHist) Sesion.get(Campo.CONHist);
					TransProd oTpd = new TransProd();
					oTpd.TransProdID = pedido.getTransprodID();
					BDVend.recuperar(oTpd);
					// tiene abonos aplicados y no permite pago automatico,
					// mostrar mensaje E0496
					if (existenAbonosAplicados(pedido.getTransprodID()) && !Boolean.parseBoolean(c.get("PagoAutomatico").toString().equals(0) ? "false" : "true"))
					{
						mVista.mostrarError(Mensajes.get("E0496"));
					}
					else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && pedido.getTipoFase() == 2 && !oTpd.VisitaClave.equals(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave))
					{
						mVista.mostrarError(Mensajes.get("E0717", ValoresReferencia.getDescripcion("TRPFASE", String.valueOf(pedido.getTipoFase()))));
					}
					else
					{ // mostrar actividad para cancelar el pedido
						mVista.mostrarPreguntaSiNo(Mensajes.get("P0212"), 5);
						/*
						 * HashMap<String, VistaPedidos> oParametros = new
						 * HashMap<String,
						 * Transacciones.Pedidos.VistaPedidos>();
						 * oParametros.put("pedido", pedido);
						 * mVista.iniciarActividadConResultado
						 * (ICancelaPedido.class, 0, null, oParametros);
						 */
					}
				}
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_CAMBIOS))
			{
				// mVista.mostrarAdvertencia("cancelar cambio");
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TransProdId", pedido.getTransprodID());
				oParametros.put("Eliminar", "true");
				mVista.iniciarActividadConResultado(ICambiaProducto.class, Enumeradores.Solicitudes.SOLICITUD_CAMBIOS_PRODUCTO_ENTRADA, Enumeradores.Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA, oParametros);
			}
			else if (mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES))
			{
				// cancelar dev
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TransProdId", pedido.getTransprodID());
				oParametros.put("Eliminar", "true");
				mVista.iniciarActividadConResultado(IDevolucionCliente.class, 0, null, oParametros);
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
			{
				try{
					TransProd oTpd = new TransProd();
					oTpd.TransProdID = pedido.getTransprodID();
					BDVend.recuperar(oTpd);	
					if (oTpd.Enviado){
						mVista.mostrarError(Mensajes.get("E0596", Mensajes.get("XEliminar")));
						
					}else{
						mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						mVista.finalizar();
						HashMap<String, String> oParametros = new HashMap<String, String>();
						oParametros.put("TransProdId", pedido.getTransprodID());
						oParametros.put("Eliminar", "true");
						mVista.iniciarActividadConResultado(ICapturaMovSinInventario.class, 0, null, oParametros);
						mVista.finalizar();				
					}					
				}catch (Exception ex){
					mVista.mostrarError(ex.getMessage());
				}

			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES))
			{
				if(!registroTransferido(pedido.getTransprodID(),true)){
					HashMap<String, String> oParametros = new HashMap<String, String>();
					oParametros.put("TransProdId", pedido.getTransprodID());
					oParametros.put("Eliminar", "true");
					mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, Solicitudes.SOLICITUD_ELIMINAR_AJUSTE_INV, Acciones.ACCION_CAPTURAR_AJUSTES, oParametros);	
				}
				
				/*TransaccionesDetalle.Pedidos.EliminarDetalleAjustesInventario(pedido.getTransprodID(), false);
				mVista.actualizarVista();
				BDVend.commit();*/

			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA))
			{
				if(!registroTransferido(pedido.getTransprodID(),true)){
					HashMap<String, String> oParametros = new HashMap<String, String>();
					oParametros.put("TransProdId", pedido.getTransprodID());
					oParametros.put("Eliminar", "true");
					mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, Solicitudes.SOLICITUD_ELIMINAR_DESCARGA_INV, Acciones.ACCION_CAPTURAR_DESCARGA, oParametros);	
				}
				
				/*TransaccionesDetalle.Pedidos.EliminarDetalleAjustesInventario(pedido.getTransprodID(), false);
				mVista.actualizarVista();
				BDVend.commit();*/

			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION))
			{
				if(!registroTransferido(pedido.getTransprodID(),true)){
					HashMap<String, String> oParametros = new HashMap<String, String>();
					oParametros.put("TransProdId", pedido.getTransprodID());
					oParametros.put("Eliminar", "true");
					mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, Solicitudes.SOLICITUD_ELIMINAR_DEV_ALMACEN, Acciones.ACCION_CAPTURAR_DEVOLUCION, oParametros);	
				}
				
				/*TransaccionesDetalle.Pedidos.EliminarDetalleAjustesInventario(pedido.getTransprodID(), false);
				mVista.actualizarVista();
				BDVend.commit();*/

			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS))
			{
				if(!registroTransferido(pedido.getTransprodID(),true)){
					int Escri = 0;
					ISetDatos mTran = Consultas.ConsultasTransProd.obtenerTransProd(pedido.getTransprodID());
					while (mTran.moveToNext())
					{
						Escri = mTran.getInt(mTran.getColumnIndex("Escritorio"));

					}
					/*MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
					if (Boolean.parseBoolean(m.get("ModificarVenta").toString().equals("0") ? "false" : "true"))
					{
						if (pedido.getTipoFase() == 0 || pedido.getTipoFase() == 2)
						{ // si esta cancelado o surtido, mostrar mensaje e iniciar
							// actividad
							iniciarActividad = true;
							sTransProdIdSeleccionado = pedido.getTransprodID();
							mVista.mostrarMensajeEiniciarActividad(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())), ICapturaPedido.class);
							// mVista.mostrarError(Mensajes.get("E0030",
							// mVista.getDescripcionFase(pedido.getTipoFase())));
						}
						else
						{ // mostrar captura de pedido con el pedido seleccionado*/
							mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
							mVista.finalizar();
							HashMap<String, String> oParametros = new HashMap<String, String>();
							oParametros.put("TransProdId", pedido.getTransprodID());
							if (Escri == 1)
							{
								mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS_NO_MODIFICAR, oParametros);
							}
							else
							{
								mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS_ELIMINAR, oParametros);
							}

							mVista.finalizar();
						/*}
					}
					else
					{
						mVista.mostrarError(Mensajes.get("E0030", mVista.getDescripcionFase(pedido.getTipoFase())));
					}*/
				}
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}

	}
	
	private boolean registroTransferido(String transProdID, boolean eliminar){
		try{
			TransProd otrp = new TransProd();
			otrp.TransProdID = transProdID;
			BDVend.recuperar(otrp);
			if(otrp.Enviado){
				if(eliminar)
					mVista.mostrarAdvertencia(Mensajes.get("E0596",Mensajes.get("XEliminar")));
				else
					mVista.mostrarAdvertencia(Mensajes.get("E0596",Mensajes.get("XModificar")));
			}
			return otrp.Enviado;	
		}catch(Exception e){
			mVista.mostrarError(e.getMessage());
			e.printStackTrace();
			return false;
		}
	}

	public boolean ValidarVencimientoVenta() throws Exception
	{
		boolean resultado = true;
		Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

		// try {
		if (((CONHist) Sesion.get(Campo.CONHist)).get("TipoLimiteCredito").toString().equals("2"))
		{
			// TODO: validar tipo indice modulo sea igual a 9
			if (oCliente.VencimientoVenta)
			{
				float valor = 0;
				// String tipoMov =
				// ((CONHist)Sesion.get(Campo.CONHist)).get("TipoCobranza").toString().equals("1")
				// ? "1" : "8";
				valor = Consultas.ConsultasTransProd.obtenerVentasVencidas(oCliente, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));

				if (valor > 0)
				{
					throw new ControlError("E0631");
				}
				else if (((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza").toString().equals("0"))
				{
					valor = Consultas.ConsultasCliente.obtenerSumFechaFacturaCliente(oCliente);
					if (valor > 0)
					{
						throw new ControlError("E0631");
					}
				}
			}
		}
		/*
		 * } catch (Exception e) { e.printStackTrace(); return false; }
		 */
		return resultado;
	}

	public boolean HabilitarCancelarVenta(SeleccionarPedido.VistaPedidos pedido)
	{
		if ((mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS) || mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)) && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO))
		{

			// Si la fase es Captura o CapturaEscritorio
			if (pedido.getTipoFase() == TiposFasesDocto.CAPTURA || pedido.getTipoFase() == TiposFasesDocto.CAPTURA_ESCRITORIO)
			{
				return true;
			}else
			{
				return ((MOTConfiguracion)Sesion.get(com.amesol.routelite.datos.utilerias.Sesion.Campo.MOTConfiguracion )).get("CancelarVenta").toString() == "0" ? false : true;
			}
		}

		/*
		 * if (Me.TransProd.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV
		 * And (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or
		 * oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion)){
		 * if (Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
		 * Or Me.TransProd.TipoFase =
		 * ServicesCentral.TiposFasesPedidos.CapturaEscritorio ) return true;
		 * else return oVendedor.motconfiguracion.CancelarVenta
		 * 'oConHist.Campos("CancelarVenta") End If End If
		 */
		return true;
	}

}
