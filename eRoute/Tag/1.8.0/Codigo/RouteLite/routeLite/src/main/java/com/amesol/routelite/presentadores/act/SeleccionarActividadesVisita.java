package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.IImpresionTicket;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionCobranza;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConsignacion;
import com.amesol.routelite.presentadores.interfaces.ISeleccionEncuestas;
import com.amesol.routelite.presentadores.interfaces.ISeleccionFacturacion;
import com.amesol.routelite.presentadores.interfaces.ISeleccionMercadeo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;
import com.amesol.routelite.utilerias.Generales;

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

        if (mVista.getActividad().getTipoIndice() == TiposModuloMovDetalle.MOV_SIN_INV_CON_VISITA ||
            mVista.getActividad().getTipoIndice() == TiposModuloMovDetalle.PEDIDO ||
            mVista.getActividad().getTipoIndice() == TiposModuloMovDetalle.CONSIGNACION){
            try {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarImprodEnVisita")) {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarImprodEnVisita").equalsIgnoreCase("1")) {
                        if (Consultas.ConsultasImproductividades.existeImproductividadEnVisita(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Visita) Sesion.get(Campo.VisitaActual)).DiaClave)) {
                            mVista.mostrarPreguntaSiNo(Mensajes.get("P0258").replace("$0$", mVista.getActividad().getNombre()), 100);
                            return;
                        }
                    }
                }
            }catch(Exception ex){}
        }

		switch (mVista.getActividad().getTipoIndice())
		{
			case TiposModuloMovDetalle.MOV_SIN_INV_CON_VISITA:
				mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA);
				//mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA);
				break;
			case TiposModuloMovDetalle.PEDIDO: // pedidos
                if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
                {
                    mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR);
                }
                else
                {
                    mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS);
                }
				break;
			case TiposModuloMovDetalle.CAMBIOS: // cambios
				mVista.iniciarActividadConResultado(ISeleccionPedido.class, Enumeradores.Solicitudes.SOLICITUD_CAMBIOS_PRODUCTO_ENTRADA, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_CAMBIOS);
				break;
			case TiposModuloMovDetalle.IMPRESION:
				mVista.iniciarActividad(IImpresionTicket.class, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA, null, false);
				break;
			case TiposModuloMovDetalle.COBRANZAMULTIPLE:
				mVista.iniciarActividadConResultado(ISeleccionCobranza.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_SELECCIONAR_COBRANZA);
				break;
			case TiposModuloMovDetalle.DEVOLUCIONCLIENTES:
				mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_DEVOLUCIONES);
				break;
			case TiposModuloMovDetalle.NO_VENTA:
				try{
					if (Consultas.ConsultasTransProd.existenVentas(((Dia)Sesion.get(Campo.DiaActual)).DiaClave, ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave)){
						mVista.mostrarError(Mensajes.get("I0285"));
						break;
					}
				}catch(Exception ex){
					mVista.mostrarError(ex.getMessage());
				}
				mVista.iniciarActividad(INoVisitaCliente.class, Enumeradores.Acciones.ACCION_NO_VENTA, null, false);
				break;
			case TiposModuloMovDetalle.CONSIGNACION:
				mVista.iniciarActividadConResultado(ISeleccionConsignacion.class, 0, Enumeradores.Acciones.ACCION_MOSTRAR_CONSIGNACIONES);
				break;
			case TiposModuloMovDetalle.FACTURACION:
				mVista.iniciarActividadConResultado(ISeleccionFacturacion.class, 0, Enumeradores.Acciones.ACCION_MOSTRAR_FACTURAS);
				break;	
				
			case TiposModuloMovDetalle.ENCUESTAS:
				
				mVista.iniciarActividadConResultado(ISeleccionEncuestas.class,0,Enumeradores.Acciones.ACCION_MOSTRAR_ENCUESTAS);
				
				break;/*88*/
            case TiposModuloMovDetalle.MERCADEO:
                mVista.iniciarActividadConResultado(ISeleccionMercadeo.class, 0 , Enumeradores.Acciones.ACCION_MOSTRAR_MERCADEO);
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

    public void borrarImproductividad(){
        Consultas.ConsultasImproductividades.borrarImproductividadEnVisita(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Visita) Sesion.get(Campo.VisitaActual)).DiaClave);
    }

	public boolean validarLimiteCreditoCliente(Visita visita)
	{
		try
		{
			CONHist conh = (CONHist) Sesion.get(Campo.CONHist);
			if (conh.get("TipoLimiteCredito").toString().equals("1") || conh.get("TipoLimiteCredito").toString().equals("3"))
			{
				Cliente cli = (Cliente) Sesion.get(Campo.ClienteActual);
				BDVend.recuperar(cli, CLIFormaVenta.class);
				for(CLIFormaVenta cfv : cli.CLIFormaVenta){
					if(cfv.CFVTipo == 2 && cfv.ValidaLimite){
						float saldoCliente = 0;
						//String tipoTRP = "";
						if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO){
							if((conh.get("TipoCobranza").toString().equals("1") || conh.get("TipoCobranza").toString().equals("2")) && cli.TipoFiscal == 1){
								if(cli.ActualizaSaldoCheque)
									saldoCliente = Consultas2.ConsultasTransProd.obtenerSaldoVentas(visita);
								else
									saldoCliente = Consultas2.ConsultasTransProd.obtenerSaldoVentasNoCheque(visita);
									//tipoTRP = "1";
							}else if((conh.get("TipoCobranza").toString().equals("0") || conh.get("TipoCobranza").toString().equals("2")) && cli.TipoFiscal == 2){
								if(cli.ActualizaSaldoCheque)
									saldoCliente = Consultas2.ConsultasTransProd.obtenerSaldoFacturas(visita) + Consultas2.ConsultasTransProd.obtenerSaldoVtasNoFact(visita);
								else
									saldoCliente = Consultas2.ConsultasTransProd.obtenerSaldoFacturasNoCheque(visita) + Consultas2.ConsultasTransProd.obtenerSaldoVtasNoFact(visita);
									//tipoTRP = "8";
							}
						}else if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA){
							saldoCliente = Consultas2.ConsultasTransProd.obtenerSaldoVentasPreventa(visita) + cli.SaldoEfectivo;
							
							/*if((conh.get("TipoCobranza").toString().equals("1") || conh.get("TipoCobranza").toString().equals("2")) && cli.TipoFiscal == 1){
								saldoCliente = Consultas2.ConsultasTransProd.obtenerSaldoVentas(visita) + cli.SaldoEfectivo;
								if(!cli.ActualizaSaldoCheque)
									tipoTRP = "1";
							}else if((conh.get("TipoCobranza").toString().equals("0") || conh.get("TipoCobranza").toString().equals("2")) && cli.TipoFiscal == 2){
								if(!cli.ActualizaSaldoCheque)
									tipoTRP = "8";
							}*/
						}
						/*if(!cli.ActualizaSaldoCheque){
							saldoCliente += Consultas2.ConsultasTransProd.obtenerAbonosCheques(visita, tipoTRP);
							saldoCliente -= Consultas2.ConsultasTransProd.obtenerSaldoAbonosNoCheque(visita);
						}else{
							saldoCliente -= Consultas2.ConsultasTransProd.obtenerSaldoAbonos(visita);
						}*/
						saldoCliente = cfv.LimiteCredito - saldoCliente;
						if(saldoCliente < 0){
							float riesgo = (cfv.LimiteCredito * Float.parseFloat(conh.get("PorcentajeRiesgo").toString())) / 100;
							if(Math.abs(saldoCliente) > riesgo){
								if(conh.get("TipoLimiteCredito").toString().equals("1")){
									mVista.mostrarAdvertencia(Mensajes.get("E0530").replace("$0$", Float.toString(Generales.getRound(Math.abs(saldoCliente), 2))));
									return false;
								}else if(conh.get("TipoLimiteCredito").toString().equals("3")){
									mVista.setMostrandoMensajeLimiteCredito(true);
									mVista.mostrarAdvertencia(Mensajes.get("I0267").replace("$0$", Float.toString(Generales.getRound(Math.abs(saldoCliente), 2))));
									return true;
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.mostrarError(e.getMessage());
			return false;
		}
		return true;
	}
}
