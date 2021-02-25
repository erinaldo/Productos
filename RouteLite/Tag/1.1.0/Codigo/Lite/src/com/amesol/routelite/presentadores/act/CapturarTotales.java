package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import android.database.Cursor;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Cuotas;
import com.amesol.routelite.actividades.Descuentos;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.TRPCheque;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
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
import com.amesol.routelite.presentadores.Enumeradores.TipoPedido;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotales;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CapturaTotales.vistaDesgloseImp;
import com.amesol.routelite.vistas.CapturaTotales.vistaDesgloseProm;
 
public class CapturarTotales extends Presentador
{

	ICapturaTotales mVista;
	String mAccion;
	ArrayList<String> aTransProdIds;
	ArrayList<TransProd> transacciones;
	short trueType;

	// sumatoria de los totales de todas las transacciones
	float subTProducto = 0;
	float descYBonif = 0;
	float subTotal = 0;
	float impuesto = 0;
	float total = 0;
	float descuentoImpVendedor = 0;
	float descuentoImpCliente = 0;
	Vendedor vendedor;
	float totalInicialCredito = 0;
	int tipo;
	//String mensajeValidaCredito = "";

	public CapturarTotales(ICapturaTotales vista, String accion, ArrayList<String> transacciones)
	{
		mVista = vista;
		mAccion = accion;
		this.aTransProdIds = transacciones;
	}

	@SuppressWarnings(
	{ "unchecked", "rawtypes" })
	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();

			descuentoImpCliente = 0;
			descuentoImpVendedor = 0;
			subTProducto = 0;
			descYBonif = 0;
			subTotal = 0;
			impuesto = 0;
			total = 0;
			float porDescVendedor = 0;
			float subTDetalle = 0;
			float descCliente = 0;
			// float descVendedor = 0;

			ArrayList<String> folios = new ArrayList<String>();
			if (mVista.getEsNuevo() && !mVista.getModificando())
			{ // si es nuevo obtener folios
				String mensaje = "";
				folios = Folios.ObtenerVarios(Sesion.get(Campo.ModuloMovDetalleClave).toString(), aTransProdIds.size(), mensaje);
				mVista.setFolio(folios.toString().replace(", ", "/").replace("[", "").replace("]", ""));
			}

			vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			transacciones = new ArrayList<TransProd>();
			boolean primero = true;

			HashMap<String, TransProd> arrayTransProd = (HashMap<String, TransProd>) Sesion.get(Campo.ArrayTransProd);
			Iterator it = arrayTransProd.entrySet().iterator();

			while (it.hasNext())
			{ // recorrer todas las transacciones generadas para calcular
				// totales, impuestos, descuentos, etc ...
				Map.Entry e = (Map.Entry) it.next();

				TransProd oTrp = (TransProd) e.getValue();
				/*
				 * Precio oPrecio = new Precio(); oPrecio.PrecioClave =
				 * oTrp.PCEPrecioClave; BDVend.recuperar(oPrecio);
				 * oTrp.ListaPrecios = oPrecio;
				 */
				if (primero)
				{ // si es el primero asignar todos los valores a los campos

					/*
					 * mVista.setTipoFase(oTrp.TipoFase);
					 * mVista.setTipoMoneda(oTrp);
					 * mVista.setListaPrecio(oTrp.ListaPrecios.PrecioClave);
					 * mVista.SeleccionaMoneda(oTrp.TransProdID);
					 */
					tipo = oTrp.Tipo;

					if (!mVista.getEsNuevo())
					{ // si no es nuevo, cargar los datos del transprod
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && oTrp.Tipo == TiposTransProd.PEDIDO){
							oTrp.TipoPedido = TipoPedido.NORMAL;
						}
						mVista.setFolio(oTrp.Folio);
						mVista.setTipoPedido(oTrp.TipoPedido);
						mVista.setFormaVenta(oTrp.CFVTipo);
						mVista.setFormaPago(oTrp.ClientePagoId);
						//mVista.setTipoTurno(oTrp.TipoTurno);
						mVista.setFechaEntrega(oTrp.FechaEntrega);
						mVista.setFechaCobranza(oTrp.FechaCobranza);

						TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
						pedidoAdicional.TransProdID = oTrp.TransProdID;
						BDVend.recuperar(pedidoAdicional);
						mVista.setPedidoAdicional(pedidoAdicional.PedidoAdicional);
						if (oTrp.ClienteDomicilioIdPE != null && oTrp.ClienteDomicilioIdPE != "")
							mVista.setPuntoEntrega(oTrp.ClienteDomicilioIdPE);

					}
					else
					{ // si es nuevo, asignar valores por default
						//mVista.setTipoPedido(1); // seleccionar por default
													// 'normal'
						mVista.setTipoPedido(oTrp.TipoPedido);
						mVista.setFormaVenta(mVista.getFormaVentaInicial()); // seleccionar
																				// la
																				// forma
																				// de
																				// venta
																				// inicial
																				// si
																				// tiene
																				// configurada
																				// una
						//mVista.setTipoTurno(0); // seleccionar por default 'no
						// definido'
						mVista.setFechaEntregaDefault(); // calcular la fecha de
															// entrega
						mVista.setFechaCobranza(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
					}

					if(oTrp.Tipo == TiposTransProd.PEDIDO || (oTrp.Tipo == TiposTransProd.MOV_SIN_INV_EV && ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MSIEVPreventa").equals("1"))){ 
						//no habilitar el tipo pedido para los pedidos y msiev cuando se usa como preventa
						mVista.enableTipoPedido(false);
					}else{
						mVista.enableTipoPedido(true);
					}
					
					primero = false;
				}
				Transacciones.Pedidos.CalcularTotalesPedido(oTrp);

				if (mVista.getEsNuevo()){ // si es nuevo, asignar los folios al
											// transprod
					if (mVista.getModificando()){ //Si es una modificacion de un pedido por surtir, el folio se conserva
						mVista.setFolio(oTrp.Folio );
					}else{
						oTrp.Folio = folios.get(transacciones.size());	
					}									
				}

				if (oTrp.TipoFase != 0 && oTrp.TipoFase != 3 &&  !(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && oTrp.TipoFase == 2 && oTrp.DiaClave1 !=null) )
				{ // solo calcular descuentos cuando es nuevo o se esta
					// modificando
					mVista.setSoloLectura(false);
					// obtener y calcular descuentos del cliente
					Descuento[] oDescto;
					Cliente oCliente = ((Cliente) Sesion.get(Campo.ClienteActual));
					oDescto = Descuentos.BuscarDescuentosClientes(oCliente);
					BDVend.recuperar(oTrp, TransProdDetalle.class);
					for (int i = 0; i < oTrp.TransProdDetalle.size(); i++)
					{
						BDVend.recuperar(oTrp.TransProdDetalle.get(i), TpdDes.class);
					}
					Descuentos.setEsNuevo(mVista.getEsNuevo());
					Descuentos.CalcularDescuentosClientes(oDescto, oTrp.Impuesto == null ? 0 : oTrp.Impuesto, oTrp.SubTDetalle  == null ? 0 : oTrp.SubTDetalle, oTrp, oCliente);

					mVista.recalcularTotales(oTrp);
				}

				for (int i = 0; i < oTrp.TransProdDetalle.size(); i++)
				{
					subTProducto += oTrp.TransProdDetalle.get(i).Cantidad * oTrp.TransProdDetalle.get(i).Precio;
					descYBonif += oTrp.TransProdDetalle.get(i).DescuentoImp;
				}
				descuentoImpCliente += oTrp.DescuentoImpuestoCliente;
				descuentoImpVendedor += oTrp.DescuentoImpuestoVendedor;
				porDescVendedor = oTrp.DescVendPor == null ? 0 : oTrp.DescVendPor;
				// descVendedor += (porDescVendedor * 100) / (oTrp.SubTDetalle -
				// oTrp.DescuentoImp);

				subTDetalle += oTrp.SubTDetalle == null ? 0 : oTrp.SubTDetalle;
				descCliente += oTrp.DescuentoImp == null ? 0 : oTrp.DescuentoImp;
				descYBonif += oTrp.DescuentoImp == null ? 0 : oTrp.DescuentoImp;
				subTotal += oTrp.Subtotal == null ? 0 : oTrp.Subtotal;
				impuesto += oTrp.Impuesto == null ? 0 : oTrp.Impuesto;
				total += oTrp.Total;

				transacciones.add(oTrp);

			}

			mVista.setSubTProducto(subTProducto);
			mVista.setDescYBonif(descYBonif);
			mVista.setSubTotal(subTotal);
			mVista.setImpuesto(impuesto - descuentoImpCliente - descuentoImpVendedor);
			mVista.setTotal(total);

			mVista.validarDesctoVendedor(subTDetalle, descCliente);
			mVista.setPorDescVendedor(porDescVendedor);
			calcularDescVendedor(porDescVendedor);

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}

	public String getTransProdid()
	{
		return aTransProdIds.get(0);
	}
	
	public int getTipo(){
		return tipo;
	}

	public void asignarGuardarValores() throws Exception
	{

		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

		// ************** validar campos ***********
		/*
		 * if(mVista.getDiasCredito() == 0 && mVista.getFormaVenta() ==
		 * Enumeradores.FormasDeVenta.CREDITO){ mVista.setFocus("dias credito");
		 * throw new ControlError("E0007"); }
		 */
		if(mVista.getFormaVenta() == Enumeradores.FormasDeVenta.CREDITO){
			Cliente cli = (Cliente) Sesion.get(Campo.ClienteActual);
			BDVend.recuperar(cli, CLIFormaVenta.class);
			for(CLIFormaVenta cfv : cli.CLIFormaVenta){
				if(cfv.CFVTipo == mVista.getFormaVenta()){
					if(cfv.CapturaDias){
						//si permite capturar los dias, validar la fecha
						if (mVista.getFechaCobranza().compareTo(mVista.getFechaEntrega()) < 0 )
						{
							mVista.setFocus("fecha cobranza");
							throw new ControlError("E0254");
						}
						
						if (mVista.getFechaCobranza().compareTo(((Dia)Sesion.get(Campo.DiaActual)).FechaCaptura) <= 0 )
						{
							mVista.setFocus("fecha cobranza");
							throw new ControlError("E0388");
						}
					}
				}
			}
		}
		

		if (motConfig.get("NotasReqCredito").toString().equals("1") && mVista.getFormaVenta() == Enumeradores.FormasDeVenta.CREDITO)
		{
			mVista.setFocus("notas");
			throw new ControlError("BE0001");
		}

		Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

		if (cliente.ExigirPedidoAdicional)
		{
			if (!cliente.validarFormatoPedidoAdicional(mVista.getPedidoAdicional()))
			{
				mVista.setFocus("pedido adicional");
				throw new ControlError("E0593", new String[]
				{ Mensajes.get("XPedidoAdicional"), cliente.FormatoPedidoAdicional });
			}
		}

		if (mVista.getPuntoEntrega() == null)
		{
			mVista.setFocus("punto entrega");
			throw new ControlError("BE0001", new String[]
			{ Mensajes.get("XDomPuntoEnt") });
		}

		// ********************************************

		CONHist oConHis = (CONHist) Sesion.get(Campo.CONHist);
		Iterator<TransProd> it = transacciones.iterator();
		boolean primero = true;
		while (it.hasNext())
		{
			TransProd oTrp = it.next();
			oTrp.Impuesto = oTrp.Impuesto - oTrp.DescuentoImpuestoCliente - oTrp.DescuentoImpuestoVendedor;
			oTrp.TipoPedido = mVista.getTipoPedido();
			oTrp.CFVTipo = mVista.getFormaVenta();
			oTrp.ClientePagoId = mVista.getFormaPago();
			//oTrp.TipoTurno = mVista.getTipoTurno();
			oTrp.Notas = mVista.getNotas();
			oTrp.FechaCobranza = mVista.getFechaCobranza();
			oTrp.FechaEntrega = mVista.getFechaEntrega();
			oTrp.ClienteClavePE = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
			oTrp.ClienteDomicilioIdPE = mVista.getPuntoEntrega();
			
			//TODO: surtir pedido
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (mVista.getSurtir() || mVista.getModificando())){
				//TODO: validar inventario a surtir?
				
				for(TransProdDetalle oTpd : oTrp.TransProdDetalle){
					if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo){
						Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTrp.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID,"",false,((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave,oTpd.PrestamoVendido,mVista.getSurtir() || mVista.getModificando());
					}else{
						Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTrp.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID,"",false,"",0,mVista.getSurtir() || mVista.getModificando());
					}
				}
				
				if(mVista.getSurtir() || mVista.getModificando()){
					oTrp.VisitaClave1 = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave ;
					oTrp.DiaClave1 =  ((Dia) Sesion.get(Campo.DiaActual)).DiaClave; 
					//oTrp.FechaSurtido = Generales.getFechaHoraActual();
					oTrp.TipoMovimiento = TiposMovimientos.SALIDA;
					//oTrp.TipoFase = TiposFasesDocto.SURTIDO;
					CONHist oConhist = (CONHist) Sesion.get(Campo.CONHist);
					if(oConHis.get("TipoCobranza").equals("1") || (oConHis.get("TipoCobranza").equals("2") && ((Cliente) Sesion.get(Campo.ClienteActual)).TipoFiscal == 1)){
						oTrp.Saldo = oTrp.Total;
					}
				}
				oTrp.MFechaHora = Generales.getFechaHoraActual();
				oTrp.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				oTrp.Enviado = false;
			}

			// validar limite de credito
			if (primero)
			{
				ValidarLimiteCredito(oTrp);
				primero = false;
			}

			// calcular cuotas
			Cuotas.CalcularCuotasXEfectivo(oTrp, false);
			Iterator<TransProdDetalle> oTpdIt = oTrp.TransProdDetalle.iterator();
			while (oTpdIt.hasNext())
			{
				TransProdDetalle detalle = oTpdIt.next();
				actualizarCuotas(detalle, false);
			}

			/*
			 * oTrp.Impuesto = oTrp.Impuesto - oTrp.DescuentoImpuestoCliente -
			 * oTrp.DescuentoImpuestoVendedor; oTrp.TipoPedido =
			 * mVista.getTipoPedido(); oTrp.CFVTipo = mVista.getFormaVenta();
			 * oTrp.ClientePagoId = mVista.getFormaPago(); oTrp.TipoTurno =
			 * mVista.getTipoTurno(); oTrp.Notas = mVista.getNotas();
			 * oTrp.FechaCobranza = mVista.getFechaCobranza(); oTrp.FechaEntrega
			 * = mVista.getFechaEntrega();
			 */

			// insertar el descuento del vendedor
			Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(oTrp.TransProdID);
			Consultas.ConsultasTPDDesVendedor.obtenerDescuentoVendedor(oTrp.TransProdID);

			if (mVista.getEsNuevo())
				Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());
			// guardar pedido adicional
			if (!mVista.getPedidoAdicional().trim().equals("") && mVista.getEsNuevo())
			{
				TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
				pedidoAdicional.TransProdID = oTrp.TransProdID;
				pedidoAdicional.PedidoAdicional = mVista.getPedidoAdicional();
				pedidoAdicional.MFechaHora = Generales.getFechaHoraActual();
				pedidoAdicional.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				pedidoAdicional.Enviado = false;
				BDVend.guardarInsertar(pedidoAdicional);
			}
			else if (!mVista.getPedidoAdicional().trim().equals("") && !mVista.getEsNuevo())
			{
				TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
				pedidoAdicional.TransProdID = oTrp.TransProdID;
				BDVend.recuperar(pedidoAdicional);
				pedidoAdicional.PedidoAdicional = mVista.getPedidoAdicional();
				pedidoAdicional.MFechaHora = Generales.getFechaHoraActual();
				pedidoAdicional.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				pedidoAdicional.Enviado = false;
				BDVend.guardarInsertar(pedidoAdicional);
			}

			// Surtir Pedido
			if (oTrp.Tipo == TiposTransProd.PEDIDO && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO))
			{
				// Surtir el documento
				oTrp.FechaSurtido = Generales.getFechaHoraActual();
				oTrp.TipoFase = Enumeradores.TiposFasesDocto.SURTIDO;
				
				//sumar el saldo al cliente si corresponde
				if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
					trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
				else
					trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));
				if (trueType == 1)
				{
					//Se suma o resta la diferencia de saldo al cliente
					oTrp.Saldo = oTrp.Total;
					Clientes.actualizarSaldoCteActual(oTrp.Total - mVista.getTotalInicial());
				}
				
				//Pago automático y preliquidación
				//if(mAccion == null){
				if(mAccion == Acciones.ACCION_APLICAR_TOTALES){
					if (AplicarPagoAutomatico(oTrp)){
						if (oConHis.get("Preliquidacion").equals("1"))
						{
							if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO)
									&& (Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString())) == 9 && oTrp.CFVTipo == Enumeradores.FormasDeVenta.CONTADO && oTrp.ClientePagoId.equals("1"))
							{
								ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
								PreLiquidacion mPreLiquidacion = new PreLiquidacion();
								if (mObtenerPreliquidacion.getCount() == 0)
								{
									mPreLiquidacion.MontoTotal = Consultas.ConsultasTransProd.obtenerEfectivo();
									mPreLiquidacion.FechaPreLiquidacion = Generales.getFechaHoraActual(); 
									mPreLiquidacion.PLIId = KeyGen.getId();
									mPreLiquidacion.Enviado = false;
									mPreLiquidacion.MontoTotal = oTrp.Total;
									BDVend.guardarInsertar(mPreLiquidacion);
								}
								else
								{
									mObtenerPreliquidacion.moveToFirst();
									String PLIId = mObtenerPreliquidacion.getString(0);
									mPreLiquidacion.PLIId = PLIId;
									BDVend.recuperar(mPreLiquidacion);
									mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) + oTrp.Total;
									BDVend.guardarInsertar(mPreLiquidacion);
								}
								oTrp.PLIId = mPreLiquidacion.PLIId;
							}
						}
					}	
				}
				


				// TODO: Administrar puntos: calcular puntos
				
			}

			BDVend.guardarInsertar(oTrp);

		}
		BDVend.commit();
		
		/*Runnable accion = new Runnable()
		{
			
			@Override
			public void run()
			{
				while(mVista.getMensajeLimiteCredito()){
					//esperar hasta que se quite el mensaje de validacion de credito para continuar
				}
				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MensajeImpresion").equals("1"))
				{
					mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
				}
			}
		};
		final Thread hilo = new Thread(accion);
		hilo.start();*/

		/*if (motConfig.get("MensajeImpresion").equals("1"))
		{
			mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
		}*/
		
	}

	private boolean AplicarPagoAutomatico(TransProd oTransProd) throws Exception{
			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
			else
				trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

			if (trueType == 1 && ((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1"))
			{
				ISetDatos abonos = Consultas.ConsultasAbnTrp.obtenerAbonos(oTransProd.TransProdID);
				if (oTransProd.CFVTipo == Enumeradores.FormasDeVenta.CONTADO && Integer.parseInt(oTransProd.ClientePagoId) == Enumeradores.FormasDePago.EFECTIVO){ 
					if (abonos.getCount() > 0){
						//Modificar el abono automático
						abonos.moveToFirst(); 
						Abono oAbn = new Abono();
						oAbn.ABNId = abonos.getString("ABNId");
						BDVend.recuperar(oAbn);
						BDVend.recuperar(oAbn, ABNDetalle.class);
						BDVend.recuperar(oAbn, AbnTrp.class);
						
						if (oAbn.ABNDetalle.get(0).Importe != oAbn.ABNDetalle.get(0).SaldoDeposito){
							abonos.close();
							throw new Exception(Mensajes.get("E0548"));
						}
						//Modificar el pago automatico si ya existe.
						oAbn.Total = oTransProd.Total;
						oAbn.Saldo = 0;
						oAbn.MFechaHora =Generales.getFechaHoraActual();
						oAbn.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						oAbn.Enviado = false;
						
						oAbn.ABNDetalle.get(0).Importe = oTransProd.Total;
						oAbn.ABNDetalle.get(0).SaldoDeposito = oTransProd.Total;
						oAbn.ABNDetalle.get(0).MFechaHora = Generales.getFechaHoraActual();
						oAbn.ABNDetalle.get(0).MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						oAbn.ABNDetalle.get(0).Enviado = false;
	
						oAbn.AbnTrp.get(0).Importe = oTransProd.Total;
						oAbn.AbnTrp.get(0).MFechaHora = Generales.getFechaHoraActual();
						oAbn.AbnTrp.get(0).MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						oAbn.AbnTrp.get(0).Enviado = false;	
						
						BDVend.guardarInsertar(oAbn);
					}else{
						//Crear el abono automático
						StringBuilder byRefError = new StringBuilder();
						String Folio = Folios.Obtener(TiposModuloMovDetalle.PAGOS, byRefError);
						if (byRefError.length()>0){
							mVista.mostrarAdvertencia(byRefError.toString());
						}
						byRefError = null;
						Abono oAbn = Cobranza.generarCobranza();
						oAbn.ABNId = KeyGen.getId();
						oAbn.Folio = Folio;
						oAbn.Total = oTransProd.Total;
						oAbn.Saldo = 0;

						ABNDetalle oAbd = new ABNDetalle();
						String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

						oAbd.ABNId = oAbn.ABNId;
						oAbd.ABDId = KeyGen.getId();
						oAbd.TipoPago = Enumeradores.FormasDePago.EFECTIVO;
						oAbd.Importe = oTransProd.Total;
						oAbd.SaldoDeposito = oTransProd.Total;
						oAbd.MonedaID = ((CONHist)Sesion.get(Campo.CONHist)).get("MonedaID").toString();
						oAbd.SaldoCarga = 0;
						oAbd.MFechaHora = Generales.getFechaHoraActual();
						oAbd.MUsuarioID = sUsuarioID;
						oAbd.Enviado = false;
						oAbn.ABNDetalle.add(oAbd);

						
						AbnTrp oAbt = new AbnTrp();
						oAbt.ABNId = oAbn.ABNId;
						oAbt.TransProdID = oTransProd.TransProdID;
						oAbt.FechaHora = Generales.getFechaHoraActual();
						oAbt.Importe = oTransProd.Total;
						oAbt.MFechaHora = Generales.getFechaHoraActual();
						oAbt.MUsuarioID = sUsuarioID;
						oAbt.Enviado = false;
						oAbn.AbnTrp.add(oAbt);
						
						Folios.confirmar(TiposModuloMovDetalle.PAGOS);

						BDVend.guardarInsertar(oAbn);
					}
					
					
					Clientes.actualizarSaldoCteActual((oTransProd.Total - mVista.getTotalInicial()) * -1);
					oTransProd.Saldo = 0;			
					
				}else{
					//Si le cambiaron las condiciones de contado y efectivo, eliminar el abono automático
					if (abonos.getCount() > 0){
						abonos.moveToFirst(); 
						Abono oAbn = new Abono();
						oAbn.ABNId = abonos.getString("ABNId");
						BDVend.recuperar(oAbn);
						BDVend.recuperar(oAbn, ABNDetalle.class);
						BDVend.recuperar(oAbn, AbnTrp.class);
						
						Iterator<ABNDetalle> itABD = oAbn.ABNDetalle.iterator();
						while (itABD.hasNext())
						{
							BDVend.eliminar(itABD.next());
						}

						Iterator<AbnTrp> itABT = oAbn.AbnTrp.iterator();
						while (itABT.hasNext())
						{
							BDVend.eliminar(itABT.next());
						}

						BDVend.eliminar(oAbn);
						Clientes.actualizarSaldoCteActual((mVista.getTotalInicial()));
					}
				}				
				abonos.close();				
			}else{
				return false;
			}
			
		return true;		
	}
	/*
	 * 
	 *     Private Function AplicarPagoAutomatico(ByRef refparoTransProd As TransProd, Optional ByVal bReparto As Boolean = False) As Boolean
        Try
            If oConHist.Campos("PagoAutomatico") And (oConHist.Campos("TipoCobranza") = 1 OrElse (oConHist.Campos("TipoCobranza") = 2 And dtTipoFiscal.Rows(0)("TipoFiscal") = 1)) Then
                Dim dtAbono As DataTable
                Dim sABNId As String = ""
                Dim dFechaHora As DateTime
                dtAbono = oDBVen.RealizarConsultaSQL("SELECT ABNId, FechaHora FROM AbnTrp WHERE TransProdId = '" & refparoTransProd.TransProdId & "'", "AbnTrp")
                'Forma de venta contado, forma de pago efectivo
                If refparoTransProd.CFVTipo = 1 And refparoTransProd.ClientePagoId = "1" Then
                    'Dim bExistePago As Boolean
                    Dim sFolio As String
                    Dim refMoneda As Resco.Controls.DetailView.ItemComboBox = DetailViewTotales.Items("MonedaId")
                    Dim sMonedaId As String = refMoneda.Value
                    If dtAbono.Rows.Count > 0 Then

                    Else
                        sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Pagos)
                        If sFolio = "" Then
                            dtAbono.Dispose()
                            Return False
                        End If
                        If bReparto Or (bModificandoPedido And Not bPedidoSugerido) Then
                            sABNId = FormasPago.GuardarAbono(0, sFolio, refparoTransProd.VisitaClave1, oDia.DiaActual, Now.Date, refparoTransProd.Total, 0, ServicesCentral.TiposModulosMovDet.Pagos)
                        Else
                            sABNId = FormasPago.GuardarAbono(0, sFolio, refparoTransProd.VisitaActual, oDia.DiaActual, Now.Date, refparoTransProd.Total, 0, ServicesCentral.TiposModulosMovDet.Pagos)
                        End If

                        If sABNId <> "" Then
                            'If FormasPago.GuardarABNDetalle(sABNId, oApp.KEYGEN(1), refparoTransProd.ClientePagoId, refparoTransProd.Total, 0, -1, "", Nothing, sMonedaId) Then
                            If FormasPago.GuardarABNDetalle(sABNId, oApp.KEYGEN(1), refparoTransProd.ClientePagoId, refparoTransProd.Total, refparoTransProd.Total, -1, "", Nothing, sMonedaId) Then
                                FormasPago.GuardarABNTrp(sABNId, refparoTransProd.TransProdId, refparoTransProd.Total, "", "")
                            End If
                        End If
                    End If

                    'refparoTransProd.ClienteActual.ActualizarSaldo(Decimal.Negate(refparoTransProd.Total - nTotalInicial))
                    If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) And oTransProdGenerico.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV And oVendedor.motconfiguracion.AgruparTransacciones = 1 Then
                        refparoTransProd.ClienteActual.ActualizarSaldo(Decimal.Negate(refparoTransProd.Total - nTotalInicialSubEmpresa(refparoTransProd.SubEmpresaID)))
                    Else
                        refparoTransProd.ClienteActual.ActualizarSaldo(Decimal.Negate(refparoTransProd.Total - nTotalInicial))
                    End If

                    refparoTransProd.ActualizarSaldo(Decimal.Negate(refparoTransProd.Total))
                Else
                    If dtAbono.Rows.Count > 0 Then
                        sABNId = dtAbono.Rows(0)("ABNId")
                        dFechaHora = DateTime.Parse(dtAbono.Rows(0)("FechaHora"))
                        FormasPago.EliminarABNTrp(sABNId, refparoTransProd.TransProdId, dFechaHora)
                        Dim sABDId As String
                        sABDId = oDBVen.RealizarScalarSQL("SELECT ABDId FROM ABNDetalle WHERE ABNId = '" & sABNId & "'")
                        FormasPago.EliminarABNDetalle(sABNId, sABDId, False)
                        FormasPago.EliminarAbono(sABNId)
                    End If
                    'refparoTransProd.ClienteActual.ActualizarSaldo(nTotalInicial)
                    If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) And oTransProdGenerico.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV And oVendedor.motconfiguracion.AgruparTransacciones = 1 Then
                        refparoTransProd.ClienteActual.ActualizarSaldo(nTotalInicialSubEmpresa(refparoTransProd.SubEmpresaID))
                    Else
                        refparoTransProd.ClienteActual.ActualizarSaldo(nTotalInicial)
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
	 */
	private void actualizarCuotas(TransProdDetalle oTpd, boolean restar) throws Exception
	{
		float factor = Consultas.ConsultasProducto.obtenerFactor(oTpd.ProductoClave, oTpd.TipoUnidad);
		float cantidadUnitaria = oTpd.Cantidad * factor;
		if (restar)
		{
			Cuotas.VerificarCuotas(vendedor.VendedorId, 1, cantidadUnitaria * -1, oTpd.ProductoClave);
			Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria * -1, oTpd.ProductoClave);
		}
		else
		{
			Cuotas.VerificarCuotas(vendedor.VendedorId, 1, cantidadUnitaria, oTpd.ProductoClave);
			Cuotas.VerificarCuotas(vendedor.VendedorId, 3, cantidadUnitaria, oTpd.ProductoClave);
		}

	}

	public void calcularDescVendedor(float descto)
	{
		try
		{
			// subTDetalle = 0;
			// descCliente = 0;
			subTotal = 0;
			impuesto = 0;
			total = 0;
			float descuentoImpuestoCliente = 0;
			float descuentoImpuestoVendedor = 0;

			float descVendedor = 0;

			Iterator<TransProd> it = transacciones.iterator();
			while (it.hasNext())
			{ // recorrer todas las transaccion
				TransProd oTrp = it.next();
				oTrp.DescVendPor = descto;

				mVista.recalcularTotales(oTrp);

				descVendedor += oTrp.DescuentoVendedor;

				// subTDetalle += oTrp.SubTDetalle;
				// descCliente += oTrp.DescuentoImp;
				descuentoImpuestoCliente += oTrp.DescuentoImpuestoCliente;
				descuentoImpuestoVendedor += oTrp.DescuentoImpuestoVendedor;
				subTotal += oTrp.Subtotal;
				impuesto += oTrp.Impuesto;
				total += oTrp.Total;

				// oTrp.Impuesto = oTrp.Impuesto - oTrp.DescuentoImpuestoCliente
				// - oTrp.DescuentoImpuestoVendedor;

				BDVend.guardarInsertar(oTrp);
			}

			mVista.setImpDescVendedor(Generales.getRound(descVendedor, 2));

			impuesto = impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor <= 0 ? 0 : impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor;

			// mVista.setSubTDetalle(subTDetalle);
			// mVista.setDescCliente(descCliente);
			mVista.setSubTotal(subTotal);
			mVista.setImpuesto(impuesto);
			mVista.setTotal(total);
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}

	}

	public void calcularImpDescVendedor(float descto)
	{
		try
		{
			// subTDetalle = 0;
			// descCliente = 0;
			subTotal = 0;
			impuesto = 0;
			total = 0;
			float descuentoImpuestoCliente = 0;
			float descuentoImpuestoVendedor = 0;

			float porVendedor = 0;

			float subTDetalle = 0;
			float descCliente = 0;
			Iterator<TransProd> it2 = transacciones.iterator();
			while (it2.hasNext())
			{
				TransProd trp = it2.next();
				subTDetalle += trp.SubTDetalle;
				descCliente += trp.DescuentoImp;
			}

			Iterator<TransProd> it = transacciones.iterator();
			while (it.hasNext())
			{ // recorrer todas las transaccion

				TransProd oTrp = it.next();
				oTrp.DescVendPor = (descto * 100) / (subTDetalle - descCliente);

				mVista.recalcularTotales(oTrp);

				porVendedor = oTrp.DescVendPor;

				// subTDetalle += oTrp.SubTDetalle;
				// descCliente += oTrp.DescuentoImp;
				descuentoImpuestoCliente += oTrp.DescuentoImpuestoCliente;
				descuentoImpuestoVendedor += oTrp.DescuentoImpuestoVendedor;
				subTotal += oTrp.Subtotal;
				impuesto += oTrp.Impuesto;
				total += oTrp.Total;

				// oTrp.Impuesto = oTrp.Impuesto - oTrp.DescuentoImpuestoCliente
				// - oTrp.DescuentoImpuestoVendedor;

				BDVend.guardarInsertar(oTrp);
			}

			mVista.setPorDescVendedor(Generales.getRound(porVendedor, 4));

			impuesto = impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor <= 0 ? 0 : impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor;

			mVista.setSubTProducto(subTProducto);
			mVista.setDescYBonif(descYBonif);
			mVista.setSubTotal(subTotal);
			mVista.setImpuesto(impuesto);
			mVista.setTotal(total);
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}

	public vistaDesgloseImp[] obtenerDesgloseImpuestos(float descuentoVendedor) throws Exception
	{

		ISetDatos impuestos = Consultas.ConsultasTPDImpuesto.obtenerDesgloseImpuestos(aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
		if (impuestos.getCount() <= 0)
		{
			impuestos.close();
			return null;
		}

		ISetDatos descCliente = Consultas.ConsultasDescuentos.obtenerDescuentosAplicados(aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
		float descVendPor = descuentoVendedor;
		float subTotConDesc = Consultas.ConsultasTransProdDetalle.obtenerSubtotalConDescto(aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
		subTotConDesc -= subTotConDesc * descVendPor / 100;
		ISetDatos detalles = Consultas.ConsultasTransProdDetalle.obtenerTodos(aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));

		vistaDesgloseImp[] desgloseImpuestos = new vistaDesgloseImp[impuestos.getCount()];

		while (detalles.moveToNext())
		{
			impuestos.moveToFirst();
			do
			{
				float totImp = Consultas.ConsultasTPDImpuesto.obtenerImpuestoImp(detalles.getString("TransProdID"), detalles.getString("TransProdDetalleID"), impuestos.getString("ImpuestoClave"));
				float impActual = totImp;
				if (totImp > 0)
				{
					if (impuestos.getInt("TipoValor") == 1)
					{
						if (descCliente.getCount() > 0)
						{
							descCliente.moveToFirst();
							do
							{
								if (descCliente.getBoolean("TipoCascada"))
								{
									impActual -= impActual * descCliente.getFloat("DesPor") / 100;
								}
								else
								{
									impActual -= totImp * descCliente.getFloat("DesPor") / 100;
								}
							}
							while (descCliente.moveToNext());
						}
						impActual -= impActual * descVendPor / 100;
					}
					
					// agregar al array
					if (desgloseImpuestos[impuestos.getPosition()] == null)
					{
						desgloseImpuestos[impuestos.getPosition()] = new vistaDesgloseImp(impuestos.getString("Abreviatura"), impuestos.getFloat("ImpuestoPor"), impActual);
					}
					else
					{
						desgloseImpuestos[impuestos.getPosition()].setImporte(desgloseImpuestos[impuestos.getPosition()].getImporte() + impActual);
					}
				}
			}
			while (impuestos.moveToNext());
		}

		impuestos.close();
		detalles.close();
		descCliente.close();

		if(desgloseImpuestos.length == 1)
			if(desgloseImpuestos[0] == null)
				return null;
		
		return desgloseImpuestos;

	}

	public ArrayList<vistaDesgloseProm> obtenerDesglosePromocion(ArrayList<String> ProdIds, String ClaveProdcuto) throws Exception
	{
		ISetDatos promociones = Consultas.ConsultasPromocion.obtenerDesglosePromociones(ProdIds.get(0), ClaveProdcuto);

		if (promociones.getCount() <= 0)
		{
			promociones.close();
			return null;
		}
		ArrayList<vistaDesgloseProm> desglosePromociones = new ArrayList<vistaDesgloseProm>();

		while (promociones.moveToNext())
		{
			if (promociones.getInt(4) == 1)
			{

				//				ISetDatos obtenerDescuento = Consultas.ConsultasPromocion.obtenerDescuento(promociones.getString(2));
				//				Log.e("", obtenerDescuento.getString(0));
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, promociones.getString(5), null, null, null, null, null, false, null));
			}
			else if (promociones.getInt(4) == 2)
			{
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, promociones.getString(5), null, null, null, null, false, null));

			}
			else if (promociones.getInt(4) == 3)
			{
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, null, null, null, promociones.getString(6), false, null));
			}
			else if (promociones.getInt(4) == 4)
			{
				ArrayList<vistaDesgloseProm> mvistaDesgloseProm = new ArrayList<vistaDesgloseProm>();
				ISetDatos obtenerRegalo = Consultas.ConsultasPromocion.obtenerRegalo(ProdIds.get(0), promociones.getString("TransProdDetalleID"));
				while (obtenerRegalo.moveToNext())
				{
					mvistaDesgloseProm.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, obtenerRegalo.getString("ProductoClave").concat(" " + obtenerRegalo.getString("Nombre")), obtenerRegalo.getString("Cantidad").concat( " " +  ValoresReferencia.getDescripcion("UNIDADV", obtenerRegalo.getString("TipoUnidad"))), null, null, true, null));
				}
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, null, null, null, null, false, mvistaDesgloseProm));
				obtenerRegalo.close();
			}
			else if (promociones.getInt(4) == 5)
			{
				ISetDatos obtenerPuntos = Consultas.ConsultasPromocion.obtenerPuntos(ProdIds.get(0));
				obtenerPuntos.moveToFirst();
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, null, null, obtenerPuntos.getString(0), null, false, null));
			}

		}
		return desglosePromociones;

	}

	public ArrayList<vistaDesgloseProm> obtenerDesglosePromociones(ArrayList<String> ProdIds) throws Exception
	{
		//		ISetDatos promociones = Consultas.ConsultasPromocion.obtenerDesglosePromociones(ProdIds.get(0));
		ISetDatos promocionesClave = Consultas.ConsultasPromocion.obtenerDesglosePromocionesClave(ProdIds.get(0));
		if (promocionesClave.getCount() <= 0)
		{
			promocionesClave.close();
			return null;
		}
		ArrayList<vistaDesgloseProm> desglosePromociones = new ArrayList<vistaDesgloseProm>();
		while (promocionesClave.moveToNext())
		{
			desglosePromociones.add(new vistaDesgloseProm(promocionesClave.getString(0), promocionesClave.getString(0).concat(" " + promocionesClave.getString(1)), null, null, null, null, null, null, null, null, null, false, null));
		}
		return desglosePromociones;

	}

	public boolean ValidarLimiteCredito(TransProd oTransprod) throws Exception
	{
		boolean resultado = true;
		Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
		// try {
		if (((CONHist) Sesion.get(Campo.CONHist)).get("TipoLimiteCredito").toString().equals("2") || ((CONHist) Sesion.get(Campo.CONHist)).get("TipoLimiteCredito").toString().equals("4"))
		{
			if (oTransprod.CFVTipo == Enumeradores.FormasDeVenta.CREDITO)
			{

				BDVend.recuperar(oCliente, CLIFormaVenta.class);
				Iterator<CLIFormaVenta> it = oCliente.CLIFormaVenta.iterator();
				while (it.hasNext())
				{
					CLIFormaVenta clifv = it.next();
					if (clifv.CFVTipo == 2)
					{
						float limite = clifv.LimiteCredito;
						float valor = 0;
						if (clifv.ValidaLimite)
						{

							Iterator<TransProd> itt = transacciones.iterator();
							while (itt.hasNext())
							{
								TransProd oTrp = itt.next();
								if (oTrp.ClientePagoId == "1" && oTrp.CFVTipo == Enumeradores.FormasDeVenta.CREDITO)
								{
									totalInicialCredito += oTrp.Total;
								}
							}
							if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
							{
								// TODO: AUN NO ESTA PROBADA ESTA PARTE

								/*
								 * Change in folio 2803
								 */

								if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
									trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
								else
									trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

								if (trueType == 1)
								{
									valor = Consultas.ConsultasTransProd.obtenerSaldoCobrarVentas(oCliente);
									valor += total - totalInicialCredito;
								}
								else
								{
									valor = Consultas.ConsultasTransProd.obtenerSaldoNoCobrarVentas(oCliente);
									valor += total - totalInicialCredito;
								}
							}
							else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
							{
								if (trueType == 1)
								{
									valor = Consultas.ConsultasTransProd.obtenerSaldoCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
									valor += Consultas.ConsultasCliente.obtenerSaldoEfectivo(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
									valor += total - totalInicialCredito;
								}
							}
							valor = limite - valor;
							if (valor < 0)
							{
								float porRiesgo = Float.parseFloat(((CONHist) Sesion.get(Campo.CONHist)).get("PorcentajeRiesgo").toString());
								float riesgo = (limite * porRiesgo) / 100;
								if (Math.abs(valor) > riesgo)
								{
									if(((CONHist) Sesion.get(Campo.CONHist)).get("TipoLimiteCredito").toString().equals("2")){
										throw new ControlError("E0599", String.valueOf(Math.abs(valor)));	
									}else if(((CONHist) Sesion.get(Campo.CONHist)).get("TipoLimiteCredito").toString().equals("4")){
										mVista.setMensajeLimiteCredito(true);
										mVista.mostrarAdvertencia(Mensajes.get("I0266").replace("$0$", String.valueOf(Math.abs(valor))));
										//mensajeValidaCredito = Mensajes.get("I0266").replace("$0$", String.valueOf(Math.abs(valor)));
									}
								}
							}
						}
						break;
					}
				}

			}
		}

		/*
		 * } catch (Exception e) { e.printStackTrace(); return false; }
		 */

		return resultado;
	}

	public List<Map<String, String>> generarDocsAImprimir()
	{
		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir( aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
		Cursor c = (Cursor) datos.getOriginal();

		List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
		Map<String, String> registro;
		String descValor = "";
		while (c.moveToNext())
		{
			registro = new HashMap<String, String>();
			for (int i = 0; i < c.getColumnCount(); i++)
			{
				registro.put(c.getColumnName(i), c.getString(i));
			}
			NumberFormat numberFormat = new DecimalFormat("$#,##0.00");
			registro.put("Total", numberFormat.format(c.getDouble(c.getColumnIndex("Total"))));
			descValor = ValoresReferencia.getDescripcion(c.getString(c.getColumnIndex("VARCodigo")), c.getString(c.getColumnIndex("Tipo")));
			registro.put("DescTipo", descValor);
			registro.put("TipoRecibo", obtenerTipoRecibo(registro));
			tabla.add(registro);
		}

		datos.close();

		// aTransProdIds.toString().replace("[", "'").replace("]",
		// "'").replace(", ", "','")
		return tabla;
	}

	public String obtenerTipoRecibo(Map<String, String> registro)
	{
		String tipoRecibo = "0";

		int tipo = Integer.parseInt(registro.get("Tipo"));
		if (registro.get("TipoRecibo").equals("TRP"))
		{
			if ((tipo == 3 && !registro.get("TipoFase").equals(3)) || (tipo != 3))
			{
				switch (tipo)
				{
					case 8:
						if (registro.get("FacElec").equals(1))
						{
							return "24"; // Facturacion Electronica
						}
						else
						{
							return "8"; // Facturacion
						}
					case 24:
						if (registro.get("TipoFase").equals(6))
						{
							return "26"; // Liquidacion
						}
						else
						{
							return "25"; // Consignación
						}
					case 1:
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
						{
							return "1";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
						{
							return "27";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
						{
							return "28";
						}
					default:
						return registro.get("Tipo");
				}
			}
		}
		else if (registro.get("TipoRecibo").equals("ABN"))
		{
			return "10"; // Recibo de cobranza
		}
		return tipoRecibo;
	}

	public void imprimirTicket() throws Exception
	{
		Recibos recibo = new Recibos();

		recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista);

	}
}
