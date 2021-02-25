package com.amesol.routelite.presentadores.act;

import android.util.Log;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IDisComportamientoCompra;
import com.amesol.routelite.presentadores.interfaces.IDisInformacionGeneralDatos;
import com.amesol.routelite.presentadores.interfaces.IDisInventarioMaterialesCliente;
import com.amesol.routelite.presentadores.interfaces.IDisObjetivoMensual;
import com.amesol.routelite.presentadores.interfaces.IDisPoliticaTradeComercial;
import com.amesol.routelite.presentadores.interfaces.IDisPortafolioRecomendado;
import com.amesol.routelite.presentadores.interfaces.IDisUltimoPedido;
import com.amesol.routelite.presentadores.interfaces.IHistoricoVentas;
import com.amesol.routelite.presentadores.interfaces.IImpresionTicket;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActivo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionCobranza;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConsignacion;
import com.amesol.routelite.presentadores.interfaces.ISeleccionEncuestas;
import com.amesol.routelite.presentadores.interfaces.ISeleccionFacturacion;
import com.amesol.routelite.presentadores.interfaces.ISeleccionMercadeo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionSolicitud;
import com.amesol.routelite.utilerias.Generales;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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

                        boolean bValidar = true;
                        if (mVista.getActividad().getTipoIndice() == TiposModuloMovDetalle.MOV_SIN_INV_CON_VISITA){
                            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ImproductividadVentas")) {
                                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ImproductividadVentas").equalsIgnoreCase("1")) {
                                    bValidar = false;
                                }
                            }
                        }

                        if (bValidar) {
                            if (Consultas.ConsultasImproductividades.existeImproductividadEnVisita(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Visita) Sesion.get(Campo.VisitaActual)).DiaClave)) {
                                mVista.mostrarPreguntaSiNo(Mensajes.get("P0258").replace("$0$", mVista.getActividad().getNombre()), 100);
                                return;
                            }
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
            case TiposModuloMovDetalle.COBRANZASIMPLE:
				mVista.iniciarActividadConResultado(ISeleccionCobranza.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_SELECCIONAR_COBRANZA_SIMPLE);
				break;
			case TiposModuloMovDetalle.DEVOLUCIONCLIENTES:
				mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_DEVOLUCIONES);
				break;
			case TiposModuloMovDetalle.NO_VENTA:
				try{
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ImproductividadVentas")){
						if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ImproductividadVentas").equalsIgnoreCase("1")) {
							if (Consultas.ConsultasTransProd.existenSoloVentas(((Dia)Sesion.get(Campo.DiaActual)).DiaClave, ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave)){
								mVista.mostrarError(Mensajes.get("I0285"));
								break;
							}
						}
					}else {
						if (Consultas.ConsultasTransProd.existenVentas(((Dia)Sesion.get(Campo.DiaActual)).DiaClave, ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave)){
							mVista.mostrarError(Mensajes.get("I0285"));
							break;
						}
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

            case TiposModuloMovDetalle.SOLICITUDES:
                mVista.iniciarActividadConResultado(ISeleccionSolicitud.class, 0, Enumeradores.Acciones.ACCION_MOSTRAR_SOLICITUDES);
		        break;
            case TiposModuloMovDetalle.HISTORICOVENTAS:
                mVista.iniciarActividadConResultado(IHistoricoVentas.class, 0, Enumeradores.Acciones.ACCION_MOSTRAR_HISTORICOVENTAS);
                break;
			case TiposModuloMovDetalle.CANCELACION_MOV_ENVIADOS:
				mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_CANCELAR_MOVS_ENVIADOS);
				break;
            case TiposModuloMovDetalle.CANJES:
                mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURA_CANJE);
                break;
            case TiposModuloMovDetalle.ACTIVOS:
                mVista.iniciarActividadConResultado(ISeleccionActivo.class, 0, Enumeradores.Acciones.ACCION_MOSTRAR_ACTIVOS);
                break;
			case TiposModuloMovDetalle.DIS_INFORMACION_GENERAL:
				mVista.iniciarActividadConResultado(IDisInformacionGeneralDatos.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
				break;
			case TiposModuloMovDetalle.DIS_OBJETIVO_MENSUAL_RUTA:
				mVista.iniciarActividadConResultado(IDisObjetivoMensual.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
				break;
			case TiposModuloMovDetalle.DIS_COMPORTAMIENTO_COMPRA:
				mVista.iniciarActividadConResultado(IDisComportamientoCompra.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
				break;
			case TiposModuloMovDetalle.DIS_ULTIMOS_PEDIDOS:
				mVista.iniciarActividadConResultado(IDisUltimoPedido.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
				break;
			case TiposModuloMovDetalle.DIS_PORTAFOLIO_RECOMENDADO:
				mVista.iniciarActividadConResultado(IDisPortafolioRecomendado.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
				break;
			case TiposModuloMovDetalle.DIS_INVENTARIO_MATERIALES:
				mVista.iniciarActividadConResultado(IDisInventarioMaterialesCliente.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
				break;
			case TiposModuloMovDetalle.DIS_POLITICA_TRADE_COMERCIAL:
				mVista.iniciarActividadConResultado(IDisPoliticaTradeComercial.class, 0, Enumeradores.Acciones.ACCION_NO_VENTA);
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
							saldoCliente =Consultas.ConsultasTransProd.obtenerSaldoCliente(visita.ClienteClave) + cli.SaldoEfectivo;
							
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

    public boolean validarEncuestasAplicadas(Visita visita){
        try{

            if (Consultas.ConsultasVisita.existenEncuestasSinAplicar(visita.DiaClave, visita.ClienteClave)){
                mVista.mostrarAdvertencia(Mensajes.get("E0983"));
                return false;
            }
            return true;
        }catch (Exception e){
            return true;
        }
    }

    public String obtenerConsignasConSaldo(){
        try {
            ISetDatos datos = Consultas.ConsultasTransProd.obtenerConsignasLiquidadasConSaldo(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
            String folios = "";
            while (datos.moveToNext()) {
                folios += datos.getString("Folio") + ", ";
            }
            if (folios.length() > 0)
                folios = folios.substring(0, folios.length() - 2);
            return folios;
        }catch (Exception e){
            return "";
        }

    }

	public boolean validaVentasContado(Visita visita){
		try {
			Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
			boolean validaPago = Consultas.ConsultasCliFormaVenta.obtenerValidaPagoContado(oCliente.ClienteClave);
			if (validaPago)
			{
				int tipoTRP;
				CONHist conh = (CONHist) Sesion.get(Campo.CONHist);
				if (conh.get("TipoCobranza").toString().equals("1") || (conh.get("TipoCobranza").toString().equals("2") && oCliente.TipoFiscal == 1)){
					tipoTRP = 1;
				}
				else{
					tipoTRP = 8;
				}
				if (Consultas.ConsultasTransProd.obtenerSaldoVentasContado(visita, oCliente, tipoTRP) > 0){
					return false;
				}
				return true;
			}
			return true;
		}catch (Exception e){
			return true;
		}
	}

	public boolean validaVentasFacturadas(){
		try {
			String folios = Consultas.ConsultasTransProd.obtenerFoliosPorFacturarVisita();
			if(folios.length() >0){
				mVista.mostrarError(Mensajes.get("I0265",folios));
				return false;
			}
			return true;
		}catch (Exception e){
			return false;
		}
	}

	public void imprimirListaPrecios() throws Exception{
		Recibos recibo = new Recibos();
		short numeroImpresiones = 0;
		recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista, numeroImpresiones);
	}

	public List<Map<String, String>> generarDocsAImprimir()
	{
		List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
		Map<String, String> registro;
		registro = new HashMap<String, String>();
		registro.put("TipoRecibo", "1");
		registro.put("Tipo", "ListaPrecios");
		registro.put("_Id", "ListaPrecios");
		tabla.add(registro);
		return tabla;
	}

	public float limiteCredito = 0;
	public int diasCredito = 0;
	public float saldoDocumentos = 0;
	public float saldoVencido = 0;
	public float creditoDisponible = 0;

	public void obtenerInformacionDeCredito(Visita visita){
		try {
			CONHist conh = (CONHist) Sesion.get(Campo.CONHist);
			Cliente cli = (Cliente) Sesion.get(Campo.ClienteActual);
			BDVend.recuperar(cli, CLIFormaVenta.class);
			for(CLIFormaVenta cfv : cli.CLIFormaVenta){
				if(cfv.CFVTipo == 2) {
					limiteCredito = cfv.LimiteCredito;
					diasCredito = cfv.DiasCredito;

					//float saldoCliente = 0;
					//if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO) {
						if (conh.get("TipoCobranza").toString().equals("1") || (conh.get("TipoCobranza").toString().equals("2") && cli.TipoFiscal == 1)) {
							if (cli.ActualizaSaldoCheque) {
								saldoDocumentos = Consultas2.ConsultasTransProd.obtenerSaldoVentas(visita);
								saldoVencido = Consultas2.ConsultasTransProd.obtenerSaldoVentasVencidas(visita);
							} else {
								saldoDocumentos = Consultas2.ConsultasTransProd.obtenerSaldoVentasNoCheque(visita);
								saldoVencido = Consultas2.ConsultasTransProd.obtenerSaldoVentasVencidasNoCheque(visita);
							}
						} else if (conh.get("TipoCobranza").toString().equals("0") || (conh.get("TipoCobranza").toString().equals("2") && cli.TipoFiscal == 2)) {
							if (cli.ActualizaSaldoCheque) {
								if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA){
									saldoDocumentos = Consultas2.ConsultasTransProd.obtenerSaldoFacturas(visita);
									saldoVencido = Consultas2.ConsultasTransProd.obtenerSaldoFacturasVencidas(visita);
								}else {
									saldoDocumentos = Consultas2.ConsultasTransProd.obtenerSaldoFacturas(visita) + Consultas2.ConsultasTransProd.obtenerSaldoVtasNoFact(visita);
									saldoVencido = Consultas2.ConsultasTransProd.obtenerSaldoFacturasVencidas(visita) + Consultas2.ConsultasTransProd.obtenerSaldoVtasVencidasNoFact(visita);
								}
							} else {
								if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA) {
									saldoDocumentos = Consultas2.ConsultasTransProd.obtenerSaldoFacturasNoCheque(visita);
									saldoVencido = Consultas2.ConsultasTransProd.obtenerSaldoFacturasVencidasNoCheque(visita);
								}else {
									saldoDocumentos = Consultas2.ConsultasTransProd.obtenerSaldoFacturasNoCheque(visita) + Consultas2.ConsultasTransProd.obtenerSaldoVtasNoFact(visita);
									saldoVencido = Consultas2.ConsultasTransProd.obtenerSaldoFacturasVencidasNoCheque(visita) + Consultas2.ConsultasTransProd.obtenerSaldoVtasVencidasNoFact(visita);
								}
							}
						}
					//} else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA) {
						//saldoDocumentos = Consultas.ConsultasTransProd.obtenerSaldoCliente(visita.ClienteClave) + cli.SaldoEfectivo;
						//saldoVencido = Consultas.ConsultasTransProd.obtenerSaldoVencidoCliente(visita.ClienteClave);
					//}

					creditoDisponible = cfv.LimiteCredito - saldoDocumentos;
					return;
				}
			}
		}catch (Exception ex){

		}
	}

}
