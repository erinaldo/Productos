package com.amesol.routelite.presentadores.act;

import android.content.ContentValues;
import android.database.Cursor;
import android.util.Log;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Cuotas;
import com.amesol.routelite.actividades.Descuentos;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Impresion;
import com.amesol.routelite.actividades.Impuestos;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TRPDescCalculadora;
import com.amesol.routelite.datos.TRPGrupo;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.Acciones;
import com.amesol.routelite.presentadores.Enumeradores.TipoPedido;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotales;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CapturaTotales;
import com.amesol.routelite.vistas.CapturaTotales.vistaDesgloseImp;
import com.amesol.routelite.vistas.CapturaTotales.vistaDesgloseProm;
import com.amesol.routelite.vistas.CapturaTotales.vistaDesgloseProntoPago;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.File;
import java.io.FileOutputStream;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

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
	float totalAnterior = 0;
    HashMap<String, Float> totalesAnteriores;
	int tipo;
    String transProdIdFirma = "";
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
        BDVend.setOrigenLog("CapturarTotales:iniciar");
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
				//mVista.setFolio(folios.toString().replace(", ", "/").replace("[", "").replace("]", ""));
			}

			vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			transacciones = new ArrayList<TransProd>();
			boolean primero = true;

			HashMap<String, TransProd> arrayTransProd = (HashMap<String, TransProd>) Sesion.get(Campo.ArrayTransProd);
			Iterator it = arrayTransProd.entrySet().iterator();
            String foliosTran = "";
            if (mVista.getSepararTotalesSubEmpresa()){
                totalesAnteriores = new HashMap<String, Float>();
            }
			while (it.hasNext())
			{ // recorrer todas las transacciones generadas para calcular
				// totales, impuestos, descuentos, etc ...
				Map.Entry e = (Map.Entry) it.next();

				TransProd oTrp = (TransProd) e.getValue();
                if (transProdIdFirma == "")
                    transProdIdFirma = oTrp.TransProdID;

				totalAnterior = Consultas.ConsultasValidacionPreliquidacion.totalTransportModificar(oTrp.TransProdID);
                if (mVista.getSepararTotalesSubEmpresa()){
                    totalesAnteriores.put(oTrp.TransProdID, oTrp.Total);
                }

				//foliosTran += oTrp.Folio + "/";

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
						//mVista.setFolio(oTrp.Folio);
						mVista.setTipoPedido(oTrp.TipoPedido);
						mVista.setFormaVenta(oTrp.CFVTipo);
						mVista.setFormaPago(oTrp.ClientePagoId);
						mVista.setTipoTurno(oTrp.TipoTurno);
						mVista.setFechaEntrega(oTrp.FechaEntrega);
						mVista.setFechaCobranza(oTrp.FechaCobranza);
						mVista.setNotas(oTrp.Notas);
						TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
						pedidoAdicional.TransProdID = oTrp.TransProdID;
						BDVend.recuperar(pedidoAdicional);
						mVista.setPedidoAdicional(pedidoAdicional.PedidoAdicional);
						mVista.setObservaciones(pedidoAdicional.Observaciones);
                        mVista.setObservaciones2(pedidoAdicional.Observaciones2);
                        mVista.setFolioNegociacion(pedidoAdicional.FolioNegociacion);
						if (oTrp.ClienteDomicilioIdPE != null && oTrp.ClienteDomicilioIdPE != "")
							mVista.setPuntoEntrega(oTrp.ClienteDomicilioIdPE);

					}
					else
					{ // si es nuevo, asignar valores por default
						//mVista.setTipoPedido(1); // seleccionar por default
													// 'normal'
						mVista.setTipoPedido(oTrp.TipoPedido);
						//Cuando se tiene listas de precios por forma de venta, obtener el CFVTipo Seleccionado anteriormente
						if ((((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("PrecioSegunCFVTipo").equals("1") || oTrp.AplicaSobreprecio) && oTrp.CFVTipo != null && oTrp.CFVTipo>0 ){
							mVista.setFormaVenta(oTrp.CFVTipo);
						}else {
							mVista.setFormaVenta(mVista.getFormaVentaInicial());
						}
						//mVista.setTipoTurno(0); // seleccionar por default 'no
						// definido'
						mVista.setFechaEntregaDefault(); // calcular la fecha de
															// entrega
						mVista.setFechaCobranza(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
					}

                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("TipoPedido")) {
                        if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TipoPedido", Sesion.get(Campo.ModuloMovDetalleClave).toString()) != "" && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("TipoPedido", Sesion.get(Campo.ModuloMovDetalleClave).toString()) != null) {
                            mVista.enableTipoPedido(true);
                        }else{
                            if(oTrp.Tipo == TiposTransProd.PEDIDO || (oTrp.Tipo == TiposTransProd.MOV_SIN_INV_EV && ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MSIEVPreventa").equals("1"))){
                                //no habilitar el tipo pedido para los pedidos y msiev cuando se usa como preventa
                                mVista.enableTipoPedido(false);
                            }else{
                                mVista.enableTipoPedido(true);
                            }
                        }
                    }else{
                        if(oTrp.Tipo == TiposTransProd.PEDIDO || (oTrp.Tipo == TiposTransProd.MOV_SIN_INV_EV && ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MSIEVPreventa").equals("1"))){
                            //no habilitar el tipo pedido para los pedidos y msiev cuando se usa como preventa
                            mVista.enableTipoPedido(false);
                        }else{
                            mVista.enableTipoPedido(true);
                        }
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
                        //llenar con los datos default
                        if (mVista.getSepararTotalesSubEmpresa()) {
                            oTrp.CFVTipo = mVista.getFormaVenta();
                            oTrp.ClientePagoId = mVista.getFormaPago();
                            oTrp.FechaEntrega = mVista.getFechaEntrega();
                            oTrp.FechaCobranza = mVista.getFechaCobranza();
                        }
                    }
				}
                foliosTran += oTrp.Folio + "/";
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
			foliosTran = foliosTran.substring(0, foliosTran.length() - 1);
			mVista.setFolio(foliosTran);

			mVista.setSubTProducto(subTProducto);
			mVista.setDescYBonif(descYBonif);
			mVista.setSubTotal(subTotal);
			mVista.setImpuesto(impuesto - descuentoImpCliente - descuentoImpVendedor);
			mVista.setTotal(total);

			mVista.validarDesctoVendedor(subTDetalle, descCliente);
			mVista.setPorDescVendedor(porDescVendedor);
            if(!mVista.getSepararTotalesSubEmpresa()) {
                calcularDescVendedor(porDescVendedor);
            }
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

    public ArrayList<TransProd> getTransacciones()
    {
        return transacciones;
    }

	public int getTipo(){
		return tipo;
	}

    private void validarLimitePrestamoEnvase() throws Exception{
        BDVend.setOrigenLog("CapturarTotales:validarLimitePrestamoEnvase");
        if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
                Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)){
            AtomicReference<String> mensaje = new AtomicReference<>();
            ManejoEnvase.validarLimitePrestamoEnvase(mensaje, getTransProdid(), mVista.getSurtir());
            if(mensaje.get() != null){
                mVista.setMensajeLimiteEnvase(true);
                mVista.mostrarError(mensaje.get());
            }
        }
        else{ //PREVENTA
            AtomicReference<String> mensaje = new AtomicReference<>();
            ManejoEnvase.validarLimitePrestamoEnvasePreventa(mensaje, getTransProdid());
            if(mensaje.get() != null){
                mVista.setMensajeLimiteEnvase(true);
                mVista.mostrarError(mensaje.get());
            }
        }
    }

	public void asignarGuardarValores() throws Exception
	{
        BDVend.setOrigenLog("CapturarTotales:asignarGuardarValores_1");
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

		if (mVista.getFormaPago().equals("0")){
			mVista.setFocus("forma pago");
			throw new ControlError("E0936", Mensajes.get("XFormaPago"));
		}

		if (motConfig.get("NotasReqCredito").toString().equals("1") && mVista.getFormaVenta() == Enumeradores.FormasDeVenta.CREDITO)
		{
            if (mVista.getNotas() == null || mVista.getNotas().equals("")){
                mVista.setFocus("notas");
                throw new ControlError("BE0001", new String[]
                        { Mensajes.get("XNotas") });
            }
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

        //folio negociacion requerido, validar
        if(cliente.ValidaFolNeg){
            if(mVista.getFolioNegociacion().trim().equals("")){
                mVista.setFocus("folio negociacion");
                throw new ControlError("BE0001", new String[] { Mensajes.get("XFolioNegociacion") });
            }
        }

        if (mVista.getFormaPago().equals("-1")){
            mVista.setFocus("forma pago");
            throw new ControlError("BE0001", new String[]
                    { Mensajes.get("XFormaPago") });
        }

        if( (mVista.getEsNuevo() || mVista.getModificandoAutoventa() || mVista.getSurtir()) && getTipo() == TiposTransProd.PEDIDO){
            //validacion limite prestamo envase
			validarLimitePrestamoEnvase();
        }

		// ********************************************

		CONHist oConHis = (CONHist) Sesion.get(Campo.CONHist);
		Iterator<TransProd> it = transacciones.iterator();
		boolean primero = true;
        String grupoID = "";
		while (it.hasNext())
		{
			TransProd oTrp = it.next();
			if (!oTrp.AplicoRedondeoImpuestos) {
				oTrp.Impuesto = oTrp.Impuesto - oTrp.DescuentoImpuestoCliente - oTrp.DescuentoImpuestoVendedor;
			}
			oTrp.TipoPedido = mVista.getTipoPedido();
			oTrp.CFVTipo = mVista.getFormaVenta();
			oTrp.ClientePagoId = mVista.getFormaPago();
			oTrp.TipoTurno = mVista.getTipoTurno();
			oTrp.Notas = mVista.getNotas();
			oTrp.FechaCobranza = mVista.getFechaCobranza();
			oTrp.FechaEntrega = mVista.getFechaEntrega();
			oTrp.ClienteClavePE = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
			oTrp.ClienteDomicilioIdPE = mVista.getPuntoEntrega();

            //agrupar transacciones
            if(transacciones.size() > 1 && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO)
                    && (oTrp.Tipo == TiposTransProd.PEDIDO || oTrp.Tipo == TiposTransProd.MOV_SIN_INV_EV) &&
                    motConfig.get("AgruparTransacciones").toString().equals("1")){
                if(primero){
                    grupoID = KeyGen.getId();
                }
                TRPGrupo grupo = new TRPGrupo();
                grupo.GrupoID = grupoID;
                grupo.TransProdID = oTrp.TransProdID;
                grupo.MFechaHora = Generales.getFechaHoraActual();
                grupo.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(grupo);
            }

			if((oTrp.DevolucionID != null) && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO)
					&& oTrp.Tipo == TiposTransProd.PEDIDO && cliente.Prestamo && cliente.LimiteEnvase == 0){
				//si se genero una recoleccion automatica de envase, agregar al array para que se imprima tambien el ticket
				aTransProdIds.add(oTrp.DevolucionID);
			}

            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA ){
                if(oTrp.Tipo == TiposTransProd.PEDIDO || oTrp.Tipo == TiposTransProd.MOV_SIN_INV_EV){
                    if(ValoresReferencia.getValor("PEDTipo",oTrp.TipoPedido.toString()).getGrupo().equalsIgnoreCase("PAGOANTICIPADO") ){
                        oTrp.Saldo = oTrp.Total;
                    }
                }

            }
			//TODO: surtir pedido
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (mVista.getSurtir() || mVista.getModificando())){
				//TODO: validar inventario a surtir?
				
				for(TransProdDetalle oTpd : oTrp.TransProdDetalle){
					if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
						BDVend.recuperar(oTpd, TPDDatosExtra.class);
						HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
						hmDetalleUnidades.put(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), null,oTpd.Cantidad, null, null,null,null));
						if(oTpd.TPDDatosExtra.size() >0 && oTpd.TPDDatosExtra.get(0).UnidadAlterna != null && oTpd.TPDDatosExtra.get(0).UnidadAlterna>0){
							hmDetalleUnidades.put(oTpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(oTpd.TPDDatosExtra.get(0).UnidadAlterna,null,oTpd.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
						}
						InventarioDobleUnidad.ActualizarInventario(oTpd.ProductoClave, hmDetalleUnidades, TiposTransProd.PEDIDO, TiposMovimientos.SALIDA, "",false,"",mVista.getSurtir() || mVista.getModificando());
					}else{
						if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo){
							Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTrp.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID,"",false,((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave,oTpd.PrestamoVendido,mVista.getSurtir() || mVista.getModificando());
						}else{
							Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTrp.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID,"",false,"",0,mVista.getSurtir() || mVista.getModificando());
						}
					}

					if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo && oTrp.Tipo == TiposTransProd.PEDIDO && mVista.getSurtir() && !mVista.getModificando()){
						//solo se aplica el manejo de envase cuando se surte el pedido como se subio, si se modifica no se aplica aqui
						Producto producto = new Producto();
						producto.ProductoClave = oTpd.ProductoClave;
						BDVend.recuperar(producto);
						ManejoEnvase.manejoEnvase(producto, oTpd.TipoUnidad, oTpd.Cantidad, oTpd, oTrp);
					}
				}
				
				if(mVista.getSurtir() || mVista.getModificando()){
					oTrp.VisitaClave1 = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
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
            //Se movio al final porque cuando se cumplia la condicion throw new ControlError("E0590") no se hacía reversa
			/*Cuotas.CalcularCuotasXEfectivo(oTrp, false);
			Iterator<TransProdDetalle> oTpdIt = oTrp.TransProdDetalle.iterator();
			while (oTpdIt.hasNext())
			{
				TransProdDetalle detalle = oTpdIt.next();
				actualizarCuotas(detalle, false);
			}*/

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
			if ((!mVista.getPedidoAdicional().trim().equals("")||!mVista.getObservaciones().trim().equals("") ||!mVista.getObservaciones2().trim().equals("") || !mVista.getFolioNegociacion().trim().equals("")) && mVista.getEsNuevo())
			{
				TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
				pedidoAdicional.TransProdID = oTrp.TransProdID;
				pedidoAdicional.PedidoAdicional = mVista.getPedidoAdicional();
				pedidoAdicional.Observaciones = mVista.getObservaciones();
                pedidoAdicional.Observaciones2 = mVista.getObservaciones2();
                pedidoAdicional.FolioNegociacion = mVista.getFolioNegociacion();
				pedidoAdicional.MFechaHora = Generales.getFechaHoraActual();
				pedidoAdicional.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				pedidoAdicional.Enviado = false;
				BDVend.guardarInsertar(pedidoAdicional);
			}
			else if (!mVista.getEsNuevo())
			{
				TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
				pedidoAdicional.TransProdID = oTrp.TransProdID;
				BDVend.recuperar(pedidoAdicional);
                if (pedidoAdicional.isRecuperado()){
                    pedidoAdicional.PedidoAdicional = mVista.getPedidoAdicional();
                    pedidoAdicional.Observaciones = mVista.getObservaciones();
                    pedidoAdicional.Observaciones2 = mVista.getObservaciones2();
                    pedidoAdicional.FolioNegociacion = mVista.getFolioNegociacion();
                    pedidoAdicional.MFechaHora = Generales.getFechaHoraActual();
                    pedidoAdicional.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    pedidoAdicional.Enviado = false;
                    BDVend.guardarInsertar(pedidoAdicional);
                }else {
                    if ((!mVista.getPedidoAdicional().trim().equals("") || !mVista.getObservaciones().trim().equals("") || !mVista.getObservaciones2().trim().equals("") || !mVista.getFolioNegociacion().trim().equals(""))) {
                        pedidoAdicional.PedidoAdicional = mVista.getPedidoAdicional();
                        pedidoAdicional.Observaciones = mVista.getObservaciones();
                        pedidoAdicional.Observaciones2 = mVista.getObservaciones2();
                        pedidoAdicional.FolioNegociacion = mVista.getFolioNegociacion();
                        pedidoAdicional.MFechaHora = Generales.getFechaHoraActual();
                        pedidoAdicional.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                        pedidoAdicional.Enviado = false;
                        BDVend.guardarInsertar(pedidoAdicional);
                    }
                }
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
					if (mVista.getSurtir()||mVista.getModificando()){
						Clientes.actualizarSaldoCteActual(oTrp.Total);
					}else{
						Clientes.actualizarSaldoCteActual(oTrp.Total - mVista.getTotalInicial());
					}
				}
				
				//Pago automático y preliquidación
				//if(mAccion == null){
				if(mAccion == Acciones.ACCION_APLICAR_TOTALES){
					if (AplicarPagoAutomatico(oTrp)){
						if (oConHis.get("Preliquidacion").equals("1"))
						{
//							if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO)
//									&& (Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString())) == 9 && oTrp.CFVTipo == Enumeradores.FormasDeVenta.CONTADO && oTrp.ClientePagoId.equals("1"))
                            if (((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO))
                                && (Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString())) == 9 && (oTrp.CFVTipo == Enumeradores.FormasDeVenta.CONTADO && oTrp.ClientePagoId.equals("1")))
							{
                                boolean bEliminarPLIId = false;
								ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
								PreLiquidacion mPreLiquidacion = new PreLiquidacion();
								if (mObtenerPreliquidacion.getCount() == 0)
								{
                                    if (oTrp.Total > 0) {
                                        mPreLiquidacion.MontoTotal = Consultas.ConsultasTransProd.obtenerEfectivo();
                                        mPreLiquidacion.FechaPreLiquidacion = Generales.getFechaHoraActual();
                                        mPreLiquidacion.PLIId = KeyGen.getId();
                                        mPreLiquidacion.Enviado = false;
                                        mPreLiquidacion.MontoTotal = oTrp.Total;
                                        BDVend.guardarInsertar(mPreLiquidacion);
                                    }
								}
								else {
                                    mObtenerPreliquidacion.moveToFirst();
                                    String PLIId = mObtenerPreliquidacion.getString(0);
                                    mPreLiquidacion.PLIId = PLIId;
                                    BDVend.recuperar(mPreLiquidacion);

                                    //Log.d(null,totalAnterior+" >= "+total);
                                    if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (mVista.getSurtir() || mVista.getModificando())) {
                                        if (oTrp.Total > 0)
                                            mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) + oTrp.Total;
                                    }else {
                                        if (totalAnterior > total) {// se resta

                                            if (total <= mObtenerPreliquidacion.getFloat(2)) {
                                                float loQueSeResta = totalAnterior - total;
                                                Log.d(null, "Lo que se resta: " + loQueSeResta + " monto total: " + mObtenerPreliquidacion.getFloat(2));
                                                mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) - loQueSeResta;
                                                Log.d(null, "total de resa: " + (mObtenerPreliquidacion.getFloat(2) - loQueSeResta));

                                                if ((mObtenerPreliquidacion.getFloat(2) - loQueSeResta) == 0) {
                                                    Consultas.ConsultasValidacionPreliquidacion.eliminarPreliquidacion(PLIId, ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
                                                    bEliminarPLIId = true;
                                                }
                                            } else {
                                                throw new ControlError("E0590");
                                                //mVista.mostrarAdvertencia(Mensajes.get("E0590"));
                                                //break;
                                            }
                                        } else {// se suma
                                            float loQueSeSuma = total - totalAnterior;
                                            mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) + loQueSeSuma;
                                        }
                                    }
									
									BDVend.guardarInsertar(mPreLiquidacion);
								}
                                if (bEliminarPLIId)
                                    oTrp.PLIId = null;
                                else {
                                    if (oTrp.Total > 0)
                                        oTrp.PLIId = mPreLiquidacion.PLIId;
                                }
							}
						}
					}	
				}

				// TODO: Administrar puntos: calcular puntos
				
			}

            // calcular cuotas
            Cuotas.CalcularCuotasXEfectivo(oTrp, false);
            Iterator<TransProdDetalle> oTpdIt = oTrp.TransProdDetalle.iterator();
            while (oTpdIt.hasNext())
            {
                TransProdDetalle detalle = oTpdIt.next();
                actualizarCuotas(detalle, false);
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

    public void asignarGuardarValores(TransProd oTrp) throws Exception
    {
        BDVend.setOrigenLog("CapturarTotales:asignarGuardarValores_2");
        if (mVista.getTransProdTotalizados() != null){
            if (mVista.getTransProdTotalizados().containsKey(oTrp.Folio)){
                mVista.getTransProdTotalizados().put(oTrp.Folio,true);
            }
        }
        MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

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
            if (mVista.getNotas() == null || mVista.getNotas().equals("")){
                mVista.setFocus("notas");
                throw new ControlError("BE0001", new String[]
                        { Mensajes.get("XNotas") });
            }
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

        if (mVista.getFormaPago().equals("-1")){
            mVista.setFocus("forma pago");
            throw new ControlError("BE0001", new String[]
                    { Mensajes.get("XFormaPago") });
        }

        if( (mVista.getEsNuevo() || mVista.getModificando()) && getTipo() == TiposTransProd.PEDIDO){
            //validacion limite prestamo envase
            validarLimitePrestamoEnvase();
        }

        // ********************************************


        boolean primero = true;
        String grupoID = "";

        //TransProd oTrp = it.next();
        oTrp.Impuesto = oTrp.Impuesto - oTrp.DescuentoImpuestoCliente - oTrp.DescuentoImpuestoVendedor;
        oTrp.TipoPedido = mVista.getTipoPedido();
        oTrp.CFVTipo = mVista.getFormaVenta();
        oTrp.ClientePagoId = mVista.getFormaPago();
        oTrp.TipoTurno = mVista.getTipoTurno();
        oTrp.Notas = mVista.getNotas();
        oTrp.FechaCobranza = mVista.getFechaCobranza();
        oTrp.FechaEntrega = mVista.getFechaEntrega();
        oTrp.ClienteClavePE = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
        oTrp.ClienteDomicilioIdPE = mVista.getPuntoEntrega();

        // insertar el descuento del vendedor
        Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(oTrp.TransProdID);
        Consultas.ConsultasTPDDesVendedor.obtenerDescuentoVendedor(oTrp.TransProdID);

        // guardar pedido adicional
        if ((!mVista.getPedidoAdicional().trim().equals("")||!mVista.getObservaciones().trim().equals("")||!mVista.getObservaciones2().trim().equals("")))
        {
            TRPVtaAcreditada pedidoAdicional = new TRPVtaAcreditada();
            pedidoAdicional.TransProdID = oTrp.TransProdID;
            BDVend.recuperar(pedidoAdicional);
            if (pedidoAdicional == null){
                pedidoAdicional = new TRPVtaAcreditada();
                pedidoAdicional.TransProdID = oTrp.TransProdID;
            }
            pedidoAdicional.PedidoAdicional = mVista.getPedidoAdicional();
            pedidoAdicional.Observaciones = mVista.getObservaciones();
            pedidoAdicional.Observaciones2 = mVista.getObservaciones2();
            pedidoAdicional.MFechaHora = Generales.getFechaHoraActual();
            pedidoAdicional.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            pedidoAdicional.Enviado = false;
            BDVend.guardarInsertar(pedidoAdicional);
        }

        BDVend.guardarInsertar(oTrp);
    }

    public void terminarPedidosMultiTotales() throws Exception
    {
        BDVend.setOrigenLog("CapturarTotales:terminarPedidosMultiTotales");
        MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);

        Iterator<TransProd> it = transacciones.iterator();
        boolean primero = true;
        String grupoID = "";
        CONHist oConHis = (CONHist) Sesion.get(Campo.CONHist);
        while (it.hasNext())
        {
            TransProd oTrp = it.next();
            //agrupar transacciones
            //Implementar esto en otro punto, al finalizar, pedido por pedido
            if(transacciones.size() > 1 && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO)
                    && (oTrp.Tipo == TiposTransProd.PEDIDO || oTrp.Tipo == TiposTransProd.MOV_SIN_INV_EV)
                    && motConfig.get("AgruparTransacciones").toString().equals("1")){
                if(primero){
                    grupoID = KeyGen.getId();
                }
                TRPGrupo grupo = new TRPGrupo();
                grupo.GrupoID = grupoID;
                grupo.TransProdID = oTrp.TransProdID;
                grupo.MFechaHora = Generales.getFechaHoraActual();
                grupo.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                BDVend.guardarInsertar(grupo);
            }

            if((oTrp.DevolucionID != null) && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO)
                    && oTrp.Tipo == TiposTransProd.PEDIDO && ((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo && ((Cliente) Sesion.get(Campo.ClienteActual)).LimiteEnvase == 0){
                //si se genero una recoleccion automatica de envase, agregar al array para que se imprima tambien el ticket
                aTransProdIds.add(oTrp.DevolucionID);
            }

            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA ){
                if(oTrp.Tipo == TiposTransProd.PEDIDO || oTrp.Tipo == TiposTransProd.MOV_SIN_INV_EV){
                    if(ValoresReferencia.getValor("PEDTipo",oTrp.TipoPedido.toString()).getGrupo().equalsIgnoreCase("PAGOANTICIPADO") ){
                        oTrp.Saldo = oTrp.Total;
                    }
                }

            }

            //TODO: surtir pedido
            if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (mVista.getSurtir() || mVista.getModificando())){
                //TODO: validar inventario a surtir?

                for(TransProdDetalle oTpd : oTrp.TransProdDetalle){
					if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
						BDVend.recuperar(oTpd, TPDDatosExtra.class);
						HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
						hmDetalleUnidades.put(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), null,oTpd.Cantidad, null, null,null,null));
						if(oTpd.TPDDatosExtra.size() >0 && oTpd.TPDDatosExtra.get(0).UnidadAlterna != null && oTpd.TPDDatosExtra.get(0).UnidadAlterna>0){
							hmDetalleUnidades.put(oTpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(oTpd.TPDDatosExtra.get(0).UnidadAlterna,null,oTpd.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
						}
						InventarioDobleUnidad.ActualizarInventario(oTpd.ProductoClave, hmDetalleUnidades, TiposTransProd.PEDIDO, TiposMovimientos.SALIDA, "",false,"",mVista.getSurtir() || mVista.getModificando());
					}else{
						if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo){
							Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTrp.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID,"",false,((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave,oTpd.PrestamoVendido,mVista.getSurtir() || mVista.getModificando());
						}else{
							Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, oTrp.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID,"",false,"",0,mVista.getSurtir() || mVista.getModificando());
						}
					}

                    if(((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo && oTrp.Tipo == TiposTransProd.PEDIDO && mVista.getSurtir() && !mVista.getModificando()){
                        //solo se aplica el manejo de envase cuando se surte el pedido como se subio, si se modifica no se aplica aqui
                        Producto producto = new Producto();
                        producto.ProductoClave = oTpd.ProductoClave;
                        BDVend.recuperar(producto);
                        ManejoEnvase.manejoEnvase(producto, oTpd.TipoUnidad, oTpd.Cantidad, oTpd, oTrp);
                    }
                }

                if(mVista.getSurtir() || mVista.getModificando()){
                    oTrp.VisitaClave1 = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
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
            //Se movio al final porque cuando se cumplia la condicion throw new ControlError("E0590") no se hacía reversa
            /*Cuotas.CalcularCuotasXEfectivo(oTrp, false);
            Iterator<TransProdDetalle> oTpdIt = oTrp.TransProdDetalle.iterator();
            while (oTpdIt.hasNext())
            {
                TransProdDetalle detalle = oTpdIt.next();
                actualizarCuotas(detalle, false);
            }*/

            //Implementar al finalizar Pedido
            if (mVista.getEsNuevo())
                Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());

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
                if(mAccion == Acciones.ACCION_APLICAR_TOTALES)
                {
                    if (AplicarPagoAutomatico(oTrp))
                    {
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

                                    if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (mVista.getSurtir() || mVista.getModificando())) {
                                        mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) + oTrp.Total;
                                    }else {
                                        if (totalesAnteriores.get(oTrp.TransProdID) > oTrp.Total) {// se resta
                                            if (oTrp.Total <= mObtenerPreliquidacion.getFloat(2)) {
                                                float loQueSeResta = totalesAnteriores.get(oTrp.TransProdID) - oTrp.Total;
                                                Log.d(null, "Lo que se resta: " + loQueSeResta + " monto total: " + mObtenerPreliquidacion.getFloat(2));
                                                mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) - loQueSeResta;
                                                Log.d(null, "total de resa: " + (mObtenerPreliquidacion.getFloat(2) - loQueSeResta));

                                                if ((mObtenerPreliquidacion.getFloat(2) - loQueSeResta) == 0) {
                                                    Consultas.ConsultasValidacionPreliquidacion.eliminarPreliquidacion(PLIId, ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
                                                }
                                            } else {
                                                throw new ControlError("E0590");
                                                //esta validacion debe ir mas arriba, porque se afectan cosas que al llegar aqui, no se da reversa.
                                                //ademas el error se muestra y aun asi la imprime como si hubiera sido correcta.
                                                //mVista.mostrarAdvertencia(Mensajes.get("E0590"));
                                                //break;
                                            }
                                        } else {// se suma
                                            float loQueSeSuma = total - totalAnterior;
                                            mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) + loQueSeSuma;
                                        }
                                    }
                                    BDVend.guardarInsertar(mPreLiquidacion);
                                }
                                oTrp.PLIId = mPreLiquidacion.PLIId;
                            }
                        }
                    }
                }
            }

            // calcular cuotas
            Cuotas.CalcularCuotasXEfectivo(oTrp, false);
            Iterator<TransProdDetalle> oTpdIt = oTrp.TransProdDetalle.iterator();
            while (oTpdIt.hasNext())
            {
                TransProdDetalle detalle = oTpdIt.next();
                actualizarCuotas(detalle, false);
            }

            BDVend.guardarInsertar(oTrp);
        }
        BDVend.commit();
    }

    public void guardarFirmaDigital(String sNombre, String sNombreArchivo)throws Exception
    {
        BDVend.setOrigenLog("CapturarTotales:guardarFirmaDigital");
        Iterator<TransProd> it = transacciones.iterator();
        while (it.hasNext()) {
            TransProd oTrp = it.next();

            TRPVtaAcreditada firmaDigital = new TRPVtaAcreditada();
            firmaDigital.TransProdID = oTrp.TransProdID;
            BDVend.recuperar(firmaDigital);
            firmaDigital.NombreFirma = sNombre;
            firmaDigital.IdImagenFirma = sNombreArchivo;
            firmaDigital.MFechaHora = Generales.getFechaHoraActual();
            firmaDigital.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            firmaDigital.Enviado = false;
            BDVend.guardarInsertar(firmaDigital);

        }
        BDVend.commit();
    }

    private boolean AplicarPagoAutomatico(TransProd oTransProd) throws Exception{
        BDVend.setOrigenLog("CapturarTotales:AplicarPagoAutomatico");
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
                        oAbn.SubEmpresaId = oTransProd.SubEmpresaId;
						oAbn.MFechaHora =Generales.getFechaHoraActual();
						oAbn.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						oAbn.Enviado = false;
						
						oAbn.ABNDetalle.get(0).Importe = oTransProd.Total;
						oAbn.ABNDetalle.get(0).SaldoDeposito = oTransProd.Total;
						oAbn.ABNDetalle.get(0).MFechaHora = Generales.getFechaHoraActual();
						oAbn.ABNDetalle.get(0).MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						oAbn.ABNDetalle.get(0).Enviado = false;
	
						oAbn.AbnTrp.get(0).Importe = oTransProd.Total;
                        oAbn.AbnTrp.get(0).SaldoInsoluto = Generales.getRound(oTransProd.Saldo - oTransProd.Total,2);
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
                        oAbn.SubEmpresaId = oTransProd.SubEmpresaId;

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
                        oAbt.SaldoInsoluto = Generales.getRound(oTransProd.Saldo - oTransProd.Total,2);
						oAbt.MFechaHora = Generales.getFechaHoraActual();
						oAbt.MUsuarioID = sUsuarioID;
						oAbt.Enviado = false;
						oAbn.AbnTrp.add(oAbt);
						
						Folios.confirmar(TiposModuloMovDetalle.PAGOS);

						BDVend.guardarInsertar(oAbn);
					}

					if (mVista.getSurtir()||mVista.getModificando()){
						Clientes.actualizarSaldoCteActual(oTransProd.Total * -1);
					}else{
						Clientes.actualizarSaldoCteActual((oTransProd.Total - mVista.getTotalInicial()) * -1);
					}
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
        BDVend.setOrigenLog("CapturarTotales:actualizarCuotas");
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
        BDVend.setOrigenLog("CapturarTotales:calcularDescVendedor_1");
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
			boolean bAplicoRedondeo=false;
			while (it.hasNext())
			{ // recorrer todas las transaccion
				TransProd oTrp = it.next();
				oTrp.DescVendPor = descto;

				mVista.recalcularTotales(oTrp);
				Boolean[] redondeo = new Boolean[1];
				redondeo[0]=false;
                Impuestos.RecalcularGlobal(oTrp, redondeo);

				if (redondeo[0]){
					bAplicoRedondeo = true;
				}
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
                CalcularImpDesGlb(oTrp.TransProdID, oTrp.DescVendPor);
			}

			mVista.setImpDescVendedor(Generales.getRound(descVendedor, 2));

			if (!bAplicoRedondeo ) {
				impuesto = impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor <= 0 ? 0 : impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor;
			}

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

    public void calcularDescVendedor(TransProd oTrp, float descto)
    {
        BDVend.setOrigenLog("CapturarTotales:calcularDescVendedor_2");
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

            oTrp.DescVendPor = descto;

            mVista.recalcularTotales(oTrp);
			Boolean[] redondeo = new Boolean[1];
			redondeo[0]=false;
            Impuestos.RecalcularGlobal(oTrp, redondeo);

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

            mVista.setImpDescVendedor(Generales.getRound(descVendedor, 2));

			if (!redondeo[0]) {
				impuesto = impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor <= 0 ? 0 : impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor;
			}
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
        BDVend.setOrigenLog("CapturarTotales:calcularImpDescVendedor_1");
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

			boolean bAplicoRedondeo = false;
			Iterator<TransProd> it = transacciones.iterator();
			while (it.hasNext())
			{ // recorrer todas las transaccion

				TransProd oTrp = it.next();
				oTrp.DescVendPor = (descto * 100) / (subTDetalle - descCliente);

				mVista.recalcularTotales(oTrp);
				Boolean[] redondeo = new Boolean[1];
				redondeo[0]=false;
                Impuestos.RecalcularGlobal(oTrp,redondeo);
				if (redondeo[0]){
					bAplicoRedondeo = true;
				}
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
                CalcularImpDesGlb(oTrp.TransProdID, oTrp.DescVendPor);
			}

			mVista.setPorDescVendedor(Generales.getRound(porVendedor, 4));

			if (!bAplicoRedondeo) {
				impuesto = impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor <= 0 ? 0 : impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor;
			}
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

    public void calcularImpDescVendedor(TransProd oTrp, float descto)
    {
        BDVend.setOrigenLog("CapturarTotales:calcularImpDescVendedor_2");
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
            //Iterator<TransProd> it2 = transacciones.iterator();
            //while (it2.hasNext())
            //{
            //TransProd trp = it2.next();
            subTDetalle += oTrp.SubTDetalle;
            descCliente += oTrp.DescuentoImp;
            //}

           /* Iterator<TransProd> it = transacciones.iterator();
            while (it.hasNext())
            { // recorrer todas las transaccion

                TransProd oTrp = it.next();
                */
            oTrp.DescVendPor = (descto * 100) / (subTDetalle - descCliente);

            mVista.recalcularTotales(oTrp);
			Boolean[] redondeo = new Boolean[1];
			redondeo[0]=false;
            Impuestos.RecalcularGlobal(oTrp,redondeo);

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
            //}

            mVista.setPorDescVendedor(Generales.getRound(porVendedor, 4));
			if (!redondeo[0]) {
				impuesto = impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor <= 0 ? 0 : impuesto - descuentoImpuestoCliente - descuentoImpuestoVendedor;
			}
            //mVista.setSubTProducto(subTProducto);
            // mVista.setDescYBonif(descYBonif);
            mVista.setSubTotal(subTotal);
            mVista.setImpuesto(impuesto);
            mVista.setTotal(total);
        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void CalcularImpDesGlb(String sTranprodid, float sDescVendPor){
        BDVend.setOrigenLog("CapturarTotales:CalcularImpDesGlb");
        try{
            Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
            ISetDatos TransprodDetalle = Consultas.ConsultasTransProdDetalle.obtenerDetallesDesctosVendedorCliente(sTranprodid);

            while (TransprodDetalle.moveToNext()){
                Impuesto[] arrayImpuestos = Impuestos.BuscarPorProducto(TransprodDetalle.getString("ProductoClave"), oCliente.TipoImpuesto);
                float SubTotalConDesc = (TransprodDetalle.getFloat("Subtotal")-TransprodDetalle.getFloat("DesImporteT"));

                Impuesto[] arrayImpuestosCalculados = CalcularImp(arrayImpuestos,(SubTotalConDesc - (SubTotalConDesc * (sDescVendPor / 100))),TransprodDetalle.getFloat("Precio"),TransprodDetalle.getFloat("Cantidad"));

                for (int i = 0; i < arrayImpuestosCalculados.length; i++){
                    Consultas.ConsultasImpuesto.ActualizaImpDesGlb(TransprodDetalle.getString("TransProdID"), TransprodDetalle.getString("TransProdDetalleID"),arrayImpuestosCalculados[i].ImpuestoClave, arrayImpuestosCalculados[i].Importe,  arrayImpuestosCalculados[i].RedondeoDecimales);
                }
            }
        }
        catch (Exception ex){
            mVista.mostrarError(ex.getMessage());
        }
    }

    public Impuesto[] CalcularImp(Impuesto[] Impuestos, float pvBase, float pvPU, float pvCantidadUnitaria){
        BDVend.setOrigenLog("CapturarTotales:CalcularImp");
        float nTotalImpuesto=0;
        float nTotalImpuestoPU=0;

        for (int i = 0; i < Impuestos.length; i++){
            if (Impuestos[i].TipoValor == ServicesCentral.TiposValoresAplicacionImpuestos.Porcentaje.value){
                if(Impuestos[i].TipoAplicacion == ServicesCentral.TiposAplicacionImpuestos.SubtotalConImpuestos.value){
					if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
						Impuestos[i].Importe = Generales.getRound((pvBase + nTotalImpuesto) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales ) ;
						Impuestos[i].ImportePU = Generales.getRound((pvPU + nTotalImpuestoPU) * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales) ;
					}else{
						Impuestos[i].Importe = (float)((pvBase + nTotalImpuesto) * (Impuestos[i].Valor / 100));
						Impuestos[i].ImportePU = (float)((pvPU + nTotalImpuestoPU) * (Impuestos[i].Valor / 100));
					}

                }else if(Impuestos[i].TipoAplicacion == ServicesCentral.TiposAplicacionImpuestos.SubtotalSinImpuestos.value){
					if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
						Impuestos[i].Importe = Generales.getRound(pvBase * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales );
						Impuestos[i].ImportePU = Generales.getRound(pvPU * (Impuestos[i].Valor / 100),Impuestos[i].RedondeoDecimales);
					}else{
						Impuestos[i].Importe = (float)(pvBase * (Impuestos[i].Valor / 100));
						Impuestos[i].ImportePU = (float)(pvPU * (Impuestos[i].Valor / 100));
					}
                }
            }else if (Impuestos[i].TipoValor == ServicesCentral.TiposValoresAplicacionImpuestos.Importe.value){
				if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
					Impuestos[i].Importe = Generales.getRound((Impuestos[i].Valor * pvCantidadUnitaria), Impuestos[i].RedondeoDecimales);
					Impuestos[i].ImportePU = Generales.getRound ((Impuestos[i].Valor), Impuestos[i].RedondeoDecimales) ;
				}else{
					Impuestos[i].Importe = (float)((Impuestos[i].Valor * pvCantidadUnitaria));
					Impuestos[i].ImportePU = (float)((Impuestos[i].Valor));
				}
            }
			if (Impuestos[i].RedondeoDecimales != null &&  Impuestos[i].RedondeoDecimales >0) {
				nTotalImpuesto += Generales.getRound(Impuestos[i].Importe, Impuestos[i].RedondeoDecimales);
				nTotalImpuestoPU += Generales.getRound(Impuestos[i].ImportePU, Impuestos[i].RedondeoDecimales);
			}else{
				nTotalImpuesto += Impuestos[i].Importe;
				nTotalImpuestoPU += Impuestos[i].ImportePU;
			}

        }

        return Impuestos;
    }

    public vistaDesgloseImp[] obtenerDesgloseImpuestos(float descuentoVendedor) throws Exception
	{
        BDVend.setOrigenLog("CapturarTotales:obtenerDesgloseImpuestos");
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
				if (totImp >= 0)
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
						desgloseImpuestos[impuestos.getPosition()] = new vistaDesgloseImp(impuestos.getString("Abreviatura"), impuestos.getFloat("ImpuestoPor"), impActual, impuestos.getInt("TipoValor"));
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
        BDVend.setOrigenLog("CapturarTotales:obtenerDesglosePromocion");
		ISetDatos promociones = Consultas.ConsultasPromocion.obtenerDesglosePromociones(ProdIds.get(0), ClaveProdcuto);

		if (promociones.getCount() <= 0)
		{
			promociones.close();
			return null;
		}
		ArrayList<vistaDesgloseProm> desglosePromociones = new ArrayList<vistaDesgloseProm>();

		while (promociones.moveToNext())
		{
			if (promociones.getInt("TipoAplicacion") == 1)
			{

				//				ISetDatos obtenerDescuento = Consultas.ConsultasPromocion.obtenerDescuento(promociones.getString(2));
				//				Log.e("", obtenerDescuento.getString(0));
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, promociones.getString(5), null, null, null, null, null, false, null));
			}
			else if (promociones.getInt("TipoAplicacion") == 2)
			{
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, promociones.getString(5), null, null, null, null, false, null));

			}
			else if (promociones.getInt("TipoAplicacion") == 3)
			{
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, null, null, null, promociones.getString(6), false, null));
			}
			/*else if (promociones.getInt("TipoAplicacion") == 4)
			{
				ArrayList<vistaDesgloseProm> mvistaDesgloseProm = new ArrayList<vistaDesgloseProm>();
				ISetDatos obtenerRegalo = Consultas.ConsultasPromocion.obtenerRegalo(ProdIds.get(0), promociones.getString("TransProdDetalleID"));
				while (obtenerRegalo.moveToNext())
				{
					mvistaDesgloseProm.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, obtenerRegalo.getString("ProductoClave").concat(" " + obtenerRegalo.getString("Nombre")), obtenerRegalo.getString("Cantidad").concat( " " +  ValoresReferencia.getDescripcion("UNIDADV", obtenerRegalo.getString("TipoUnidad"))), null, null, true, null));
				}
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, null, null, null, null, false, mvistaDesgloseProm));
				obtenerRegalo.close();
			}else if (promociones.getInt("TipoAplicacion") == 6 )
            {
                ArrayList<vistaDesgloseProm> mvistaDesgloseProm = new ArrayList<vistaDesgloseProm>();
                ISetDatos obtenerCanjes = Consultas.ConsultasPromocion.obtenerCanjes(ProdIds.get(0), promociones.getString("TransProdDetalleID"));
                while (obtenerCanjes.moveToNext())
                {
                    mvistaDesgloseProm.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, obtenerCanjes.getString("ProductoClave").concat(" " + obtenerCanjes.getString("Nombre")), obtenerCanjes.getString("Cantidad").concat( " " +  ValoresReferencia.getDescripcion("UNIDADV", obtenerCanjes.getString("TipoUnidad"))), Generales.getFormatoDecimal(obtenerCanjes.getFloat("Total"), "$#,##0.00"), Generales.getFormatoDecimal(obtenerCanjes.getFloat("Precio"), "$#,##0.00"), true, null));
                }
                desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, null, null, null, null, false, mvistaDesgloseProm));
                obtenerCanjes.close();
            }*/
			else if (promociones.getInt("TipoAplicacion") == 5)
			{
				ISetDatos obtenerPuntos = Consultas.ConsultasPromocion.obtenerPuntos(ProdIds.get(0), promociones.getString(0));
				obtenerPuntos.moveToFirst();
				desglosePromociones.add(new vistaDesgloseProm(promociones.getString(0), promociones.getString(0).concat(" " + promociones.getString(1)), promociones.getString(2), promociones.getString(3), null, null, null, null, null, obtenerPuntos.getString(0), null, false, null));
			}

		}
		return desglosePromociones;

	}

	public void obtenerDesglosePromocionRegaloCanje(String TransProdIds, CapturaTotales.vistaPromoRegaloCanje vistaPromoRegaloCanje) throws Exception
	{
        BDVend.setOrigenLog("CapturarTotales:obtenerDesglosePromocionRegaloCanje_1");
		if (vistaPromoRegaloCanje.getMvistaDetallePromRegalo().size()<=0) {
			ISetDatos obtenerRegalo = Consultas.ConsultasPromocion.obtenerRegaloCanjes(TransProdIds, vistaPromoRegaloCanje.getClavePromocion());
			while (obtenerRegalo.moveToNext()) {
				vistaPromoRegaloCanje.getMvistaDetallePromRegalo().add(new CapturaTotales.vistaDetalleRegalosCanjes(obtenerRegalo.getString("ProductoClave").concat(" - ").concat(obtenerRegalo.getString("Nombre")), obtenerRegalo.getFloat("Cantidad"), (vistaPromoRegaloCanje.getTipoAplicacion()==6 ? obtenerRegalo.getFloat("Precio"):null), (vistaPromoRegaloCanje.getTipoAplicacion()==6 ? obtenerRegalo.getFloat("Total"):null)));
			}
			obtenerRegalo.close();
		}
	}

	public ArrayList<vistaDesgloseProm> obtenerDesglosePromociones(ArrayList<String> ProdIds) throws Exception
	{
        BDVend.setOrigenLog("CapturarTotales:obtenerDesglosePromociones");
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

	public ArrayList<CapturaTotales.vistaPromoRegaloCanje> obtenerDesglosePromocionesRegaloCanje(ArrayList<String> ProdIds) throws Exception
	{
        BDVend.setOrigenLog("CapturarTotales:obtenerDesglosePromocionRegaloCanje_2");
		ISetDatos promocionesClave = Consultas.ConsultasPromocion.obtenerDesglosePromocionesRegaloClave(ProdIds.get(0));
		if (promocionesClave.getCount() <= 0)
		{
			promocionesClave.close();
			return null;
		}
		ArrayList<CapturaTotales.vistaPromoRegaloCanje> desglosePromociones = new ArrayList<CapturaTotales.vistaPromoRegaloCanje>();
		String promocionClave ="";
		String promocionNombre="";
		String productos="";
		Integer tipoAplicacion = 0;
		while (promocionesClave.moveToNext())
		{
			if(!promocionesClave.getString("PromocionClave").equals(promocionClave)){
				if (promocionClave.length()>0){
					productos = productos.substring(0,productos.length() - 2);
					desglosePromociones.add(new CapturaTotales.vistaPromoRegaloCanje(promocionClave, promocionNombre, productos, tipoAplicacion));
				}
				promocionClave = promocionesClave.getString("PromocionClave");
				promocionNombre = promocionesClave.getString("PromocionNombre");
				tipoAplicacion = promocionesClave.getInt("TipoAplicacion");
				productos = "";
			}
			productos += promocionesClave.getString("ProductoClave") + "-" + promocionesClave.getString("ProductoNombre") + ", " ;
		}
		if (promocionClave.length()>0){
			desglosePromociones.add(new CapturaTotales.vistaPromoRegaloCanje(promocionClave, promocionNombre, productos, tipoAplicacion));
		}
		promocionesClave.close();
		return desglosePromociones;

	}


	public ArrayList<vistaDesgloseProntoPago> obtenerDesglosePromoProntoPago(ArrayList<String> ProdIds) throws Exception
    {
        BDVend.setOrigenLog("CapturarTotales:obtenerDesglosePromoProntoPago");
        ISetDatos dsPromociones = Consultas.ConsultasPromocion.obtenerDesglosePromocionesProntoPago(ProdIds.get(0));
        if (dsPromociones.getCount() <= 0)
        {
            dsPromociones.close();
            return null;
        }

        ArrayList<vistaDesgloseProntoPago> desglosePromociones = new ArrayList<vistaDesgloseProntoPago>();
        String sPromocionClave = "";
        String sPromocionNombre = "";
        String sProductos = "";
        float nImporte = 0;
        float nPorcentaje = 0;
        while (dsPromociones.moveToNext())
        {
            if (sPromocionClave.equals("")){
                sPromocionClave = dsPromociones.getString("PromocionClave");
                sPromocionNombre = dsPromociones.getString("Nombre");
                nPorcentaje = dsPromociones.getFloat("Porcentaje");
            }
            else if (!sPromocionClave.equals(dsPromociones.getString("PromocionClave")) || nPorcentaje != dsPromociones.getFloat("Porcentaje")){

                if (sProductos.length() > 0) {
                    sProductos = sProductos.substring(0, sProductos.length() - 1);
                    desglosePromociones.add(new vistaDesgloseProntoPago(sPromocionClave, sPromocionNombre, sProductos, Generales.getFormatoDecimal(nImporte, "$#,##0.00"), String.valueOf(nPorcentaje) + "%"));
                }

                sPromocionClave = dsPromociones.getString("PromocionClave");
                sPromocionNombre = dsPromociones.getString("Nombre");
                nPorcentaje = dsPromociones.getFloat("Porcentaje");
                sProductos = "";
                nImporte = 0;
            }
            sProductos += dsPromociones.getString("ProductoClave") + ",";
            nImporte += dsPromociones.getFloat("Total");
        }
        if (sProductos.length() > 0) {
            sProductos = sProductos.substring(0, sProductos.length() - 1);
            desglosePromociones.add(new vistaDesgloseProntoPago(sPromocionClave, sPromocionNombre, sProductos, Generales.getFormatoDecimal(nImporte, "$#,##0.00"), String.valueOf(nPorcentaje) + "%"));
        }

        return desglosePromociones;

    }

	public boolean ValidarLimiteCredito(TransProd oTransprod) throws Exception
	{
        BDVend.setOrigenLog("CapturarTotales:ValidarLimiteCredito");
		boolean resultado = true;
		Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
		Float totalInicialCredito = 0f;
        String transProdExcep = "";
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
                            totalInicialCredito = 0f;
                            if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) {
                                if ((mVista.getModificandoAutoventa() || mVista.getModificando()) && !mVista.getSurtir()) {
                                    Iterator<TransProd> itt = transacciones.iterator();
                                    while (itt.hasNext()) {
                                        TransProd oTrp = itt.next();
                                        if (mVista.getModificando())
                                            transProdExcep += "'" + oTrp.TransProdID + "',";
                                        else{
                                            if (oTrp.ClientePagoId.equals("1") && oTrp.CFVTipo == Enumeradores.FormasDeVenta.CREDITO) {
                                                totalInicialCredito += oTrp.TotalInicial;
                                            }
                                        }
                                    }
                                    if (transProdExcep.length() > 0)
                                        transProdExcep = transProdExcep.substring(0, transProdExcep.length()-1);
                                }
                            }

							if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
								trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
							else
								trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

							if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
							{
								// TODO: AUN NO ESTA PROBADA ESTA PARTE

								/*
								 * Change in folio 2803
								 */

								if (trueType == 1)
								{
									valor = Consultas.ConsultasTransProd.obtenerSaldoCobrarVentas(oCliente, transProdExcep);
									valor += total - totalInicialCredito;
								}
								else
								{
									valor = Consultas.ConsultasTransProd.obtenerSaldoNoCobrarVentas(oCliente);
									valor += total -  totalInicialCredito;
								}
							}
							else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
							{
								if (trueType == 1)
								{
									//Se quita el total de la preventaActual para que se valide con el nuevo total recien calculado.
									valor = Consultas.ConsultasTransProd.obtenerSaldoCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
									valor += Consultas.ConsultasCliente.obtenerSaldoEfectivo(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
									valor += total;
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
        BDVend.setOrigenLog("CapturarTotales:generarDocsAImprimir");
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
        BDVend.setOrigenLog("CapturarTotales:imprimirTicket");
		Recibos recibo = new Recibos();

        short numImpresiones = 0;
        try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }

		recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista, numImpresiones);

	}

    public File generarPDFConsolidacionPedidoCOS() throws Exception{
        BDVend.setOrigenLog("CapturarTotales:generarPDFConsolidacionPedidoCOS");
        String nombreArchivo = "";
        Hashtable<String, ContentValues> archivosGenerados = new Hashtable<String, ContentValues>();

        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
        File impresion = new File(conf.get(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
        impresion = new File(impresion, "impresion");
        if (!impresion.exists())
        {
            if (!impresion.mkdirs())
            {
                throw new ControlError("E0690", impresion.getAbsolutePath());
            }
        }

        //Limpiar el directorio de impresion
        if (impresion.isDirectory())
        {
            File[] files = impresion.listFiles();
            if (files != null)
            {
                for (File f : files)
                {
                    f.delete();
                }
            }
        }

        try
        {
            //Se tiene la premisa de manejar un solo transprod para este reporte
            //para el manejo de subempresas tendria que modificarse
            nombreArchivo = "Consolida-" + getTransProdid();

            Document document = new Document();
            PdfWriter.getInstance(document, new FileOutputStream(impresion.getAbsolutePath() + "/" + nombreArchivo + ".pdf"));
            document.open();

            String aux = null;
            Paragraph reportePDF = new Paragraph();
            Paragraph vacio = new Paragraph(" ");

            Font font = new Font(Font.FontFamily.COURIER, 26, Font.BOLD, BaseColor.BLUE);

            Cliente cliente = ((Cliente)Sesion.get(Campo.ClienteActual));

            Paragraph paragraph = new Paragraph(cliente.RazonSocial, font);
            paragraph.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(paragraph);

            font = new Font(Font.FontFamily.COURIER, 20, Font.BOLD, BaseColor.BLACK);

            paragraph = new Paragraph(cliente.IdFiscal, font);
            paragraph.setAlignment(Element.ALIGN_CENTER);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);

            reportePDF.add(new Paragraph(Mensajes.get("XCliente") + ": " + cliente.Clave + "-" + cliente.NombreCorto , font));

            if (cliente.ClienteDomicilio.size()<=0){
                BDVend.recuperar(cliente, ClienteDomicilio.class);
            }
            aux = "";
            for(ClienteDomicilio dom : cliente.ClienteDomicilio){
                if(dom.Tipo == 2){
                    aux =  dom.Calle + (dom.Numero !=null && !dom.Numero.isEmpty() ? " " + dom.Numero : "") + (dom.NumInt != null && !dom.NumInt.isEmpty() ? " INT " + dom.NumInt: " ") +
                            (dom.Colonia != null && !dom.Colonia.isEmpty() ? ", " + dom.Colonia: "")  +
                            (dom.Localidad != null && !dom.Localidad.isEmpty() ?  ", " + dom.Localidad : "") +
                            (dom.CodigoPostal != null && !dom.CodigoPostal.isEmpty() ? ", " + Mensajes.get("XCPostal") + " " + dom.CodigoPostal : "")  + " ";
                    reportePDF.add(new Paragraph(Mensajes.get("XDomicilio") + ": " + aux , font));
                    break;
                }
            }

            /*for (int i = 0; i < cliente.ClienteDomicilio.size(); i++){
                if (cliente.ClienteDomicilio.get(i).Tipo == 2){ //Si es el domicilio de visita
                   String dom = cliente.ClienteDomicilio.get(i).Calle + " " + cliente.ClienteDomicilio.get(i).Numero + cliente.ClienteDomicilio.get(i).NumInt;
                   dom += "," + cliente.ClienteDomicilio.get(i).Colonia + "," + cliente.ClienteDomicilio.get(i).Localidad + "," + Mensajes.get("XCPostal") + cliente.ClienteDomicilio.get(i).CodigoPostal;
                    reportePDF.add(new Paragraph(Mensajes.get("XDomicilio") + ": " + dom , font));
                   break;
                }
            }*/

            if (transacciones.size()>0) {
                reportePDF.add(new Paragraph(Mensajes.get("TRPFechaCaptura") + ": " + Generales.getFormatoFecha(transacciones.get(0).FechaCaptura, "dd/MMMM/yyyy"), font));
                reportePDF.add(new Paragraph(Mensajes.get("XFechaEntrega") + ": " + Generales.getFormatoFecha(mVista.getFechaEntrega(), "dd/MMMM/yyyy") , font));
                reportePDF.add(new Paragraph(Mensajes.get("XFolio") + ": " + transacciones.get(0).Folio , font));
                reportePDF.add(" ");
            }

            Font textoNegrita = new Font(Font.FontFamily.COURIER, 17, Font.BOLD);

            aux = Impresion.completaHasta(Mensajes.get("XTarimas"), 16, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(Mensajes.get("XCtdPedida"), 12, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(Mensajes.get("XPeso"), 11, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(Mensajes.get("XVol"), 11, Impresion.TipoAlineacion.DERECHA, true);

            paragraph = new Paragraph(aux, textoNegrita);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            font = new Font(Font.FontFamily.COURIER, 17, Font.NORMAL);

            //float volumen = 0, peso = 0, subtotal;
            ISetDatos datos = Consultas.ConsultasConversionProducto.obtenerConsolidacionPedido(transacciones.get(0).TransProdID);
            HashMap<Integer,HashMap<String, Float>> hmSumClasif = new HashMap<Integer,HashMap<String, Float>>();
            while(datos.moveToNext()) {
                HashMap<String, Float> hmSumatorias;
                if (!hmSumClasif.containsKey(datos.getInt("Clasificacion"))) {
                    hmSumatorias = new HashMap<String, Float>();
                    hmSumClasif.put(datos.getInt("Clasificacion"), hmSumatorias);
                }else{
                    hmSumatorias =  hmSumClasif.get(datos.getInt("Clasificacion"));
                }

                if (!hmSumatorias.containsKey("Tarimas")) {
                    hmSumatorias.put("Tarimas", 0f);
                }
                if (!hmSumatorias.containsKey("Pedida")) {
                    hmSumatorias.put("Pedida", 0f);
                }
                if (!hmSumatorias.containsKey("Peso")) {
                    hmSumatorias.put("Peso", 0f);
                }
                if (!hmSumatorias.containsKey("Volumen")) {
                    hmSumatorias.put("Volumen", 0f);
                }

                hmSumatorias.put("Tarimas", hmSumatorias.get("Tarimas") + datos.getFloat("Tarimas"));
                hmSumatorias.put("Pedida", hmSumatorias.get("Pedida") + datos.getFloat("CtdPedidos"));
                hmSumatorias.put("Peso", hmSumatorias.get("Peso") + datos.getFloat("Peso"));
                hmSumatorias.put("Volumen", hmSumatorias.get("Volumen") + datos.getFloat("Volumen"));
            }
            float totalTarimas = 0;
            float totalPedida = 0;
            float totalPeso = 0;
            float totalVol = 0;

            if (hmSumClasif.containsKey(4)){ //Si contiene la clasificación TOTIS
                try{
                    totalTarimas += Math.ceil(hmSumClasif.get(4).get("Tarimas"));
                    totalPedida +=  hmSumClasif.get(4).get("Pedida");
                    totalPeso +=  Generales.getRound(hmSumClasif.get(4).get("Peso") + (Math.ceil(hmSumClasif.get(4).get("Tarimas")) * Float.parseFloat(((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))),0);
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("VolumenTarima")) {
                        totalVol += Generales.getRound(hmSumClasif.get(4).get("Volumen") + (Math.ceil(hmSumClasif.get(4).get("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), 2);
                    }
                    aux = Impresion.completaHasta(ValoresReferencia.getDescripcion("CESQUEMA", "4").replace("Productos La", "").trim().toUpperCase(),8,Impresion.TipoAlineacion.IZQUIERDA,false);
                    aux+= Impresion.completaHasta(Generales.getFormatoDecimal(Math.ceil(hmSumClasif.get(4).get("Tarimas")),"#,##0"), 8, Impresion.TipoAlineacion.DERECHA, false);
                    aux+= Impresion.completaHasta(Generales.getFormatoDecimal(hmSumClasif.get(4).get("Pedida"),"0.##" ), 12, Impresion.TipoAlineacion.DERECHA, false);
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("PesoTarima")) {
                        aux += Impresion.completaHasta(Generales.getFormatoDecimal(hmSumClasif.get(4).get("Peso") + (Math.ceil(hmSumClasif.get(4).get("Tarimas")) * Float.parseFloat (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))),"#,##0"), 11, Impresion.TipoAlineacion.DERECHA, false);
                    }
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("VolumenTarima")) {
                        aux += Impresion.completaHasta(Generales.getFormatoDecimal(hmSumClasif.get(4).get("Volumen") + (Math.ceil(hmSumClasif.get(4).get("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), "#,##0.00"), 11, Impresion.TipoAlineacion.DERECHA, true);
                    }

                    paragraph = new Paragraph(aux, textoNegrita);
                    paragraph.setAlignment(Element.ALIGN_LEFT);
                    reportePDF.add(paragraph);
                }catch (Exception ex){
                    mVista.mostrarError("Error al obtener totales");
                }
            }
            if (hmSumClasif.containsKey(5)){ //Si contiene la clasificación Costeña
                try{
                    totalTarimas += Math.ceil(hmSumClasif.get(5).get("Tarimas"));
                    totalPedida +=  hmSumClasif.get(5).get("Pedida");
                    totalPeso +=  Generales.getRound(hmSumClasif.get(5).get("Peso") + (Math.ceil(hmSumClasif.get(5).get("Tarimas")) * Float.parseFloat (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))),0);
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("VolumenTarima")) {
                        totalVol += Generales.getRound(hmSumClasif.get(5).get("Volumen") + (Math.ceil(hmSumClasif.get(5).get("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), 2);
                    }
                    aux = Impresion.completaHasta(ValoresReferencia.getDescripcion("CESQUEMA", "5").replace("Productos", "").trim().toUpperCase(),8,Impresion.TipoAlineacion.IZQUIERDA,false);
                    aux+= Impresion.completaHasta(Generales.getFormatoDecimal(Math.ceil(hmSumClasif.get(5).get("Tarimas")),"##0.##"), 8, Impresion.TipoAlineacion.DERECHA, false);
                    aux+= Impresion.completaHasta(Generales.getFormatoDecimal(hmSumClasif.get(5).get("Pedida"),"0.##" ), 12, Impresion.TipoAlineacion.DERECHA, false);
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("PesoTarima")) {
                        aux += Impresion.completaHasta(Generales.getFormatoDecimal(hmSumClasif.get(5).get("Peso") + (Math.ceil(hmSumClasif.get(5).get("Tarimas")) * Float.parseFloat (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("PesoTarima"))),"#,##0"), 11, Impresion.TipoAlineacion.DERECHA, false);
                    }
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("VolumenTarima")) {
                        aux += Impresion.completaHasta(Generales.getFormatoDecimal(hmSumClasif.get(5).get("Volumen") + (Math.ceil(hmSumClasif.get(5).get("Tarimas")) * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), "#,##0.00"), 11, Impresion.TipoAlineacion.DERECHA, true);
                    }

                    paragraph = new Paragraph(aux, textoNegrita);
                    paragraph.setAlignment(Element.ALIGN_LEFT);
                    reportePDF.add(paragraph);
                }catch (Exception ex){
                    mVista.mostrarError("Error al obtener totales");
                }
            }

            aux = Impresion.completaHasta(Mensajes.get("XTotal"),8,Impresion.TipoAlineacion.IZQUIERDA,false);
            aux+= Impresion.completaHasta(Generales.getFormatoDecimal(totalTarimas, "#,##0.##"), 8, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(Generales.getFormatoDecimal(totalPedida,"0.##" ), 12, Impresion.TipoAlineacion.DERECHA, false);
            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("PesoTarima")) {
                aux += Impresion.completaHasta(Generales.getFormatoDecimal(totalPeso,"#,##0"), 11, Impresion.TipoAlineacion.DERECHA, false);
            }
            aux+= Impresion.completaHasta(Generales.getFormatoDecimal(totalVol, "#,##0.00"), 11, Impresion.TipoAlineacion.DERECHA, true);

            paragraph = new Paragraph(aux, textoNegrita);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);
            reportePDF.add(" ");

            textoNegrita = new Font(Font.FontFamily.COURIER, 17, Font.BOLD);

            reportePDF.add(new Paragraph(Mensajes.get("XProducto"),textoNegrita));

            aux= Impresion.completaHasta(Mensajes.get("XCtdPedida"), 11, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "6"), 7, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "4"), 7, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(ValoresReferencia.getDescripcion("UNIDADV", "3"), 7, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(Mensajes.get("XPeso"), 9, Impresion.TipoAlineacion.DERECHA, false);
            aux+= Impresion.completaHasta(Mensajes.get("XVol"), 9, Impresion.TipoAlineacion.DERECHA, true);

            reportePDF.add(new Paragraph(aux, textoNegrita));

            datos.moveToFirst();
            int clasificacionActual = 0;
            do {
                if (datos.getInt("Clasificacion") != clasificacionActual){
                    if (datos.getInt("Clasificacion") == 4) {
                        reportePDF.add(new Paragraph(ValoresReferencia.getDescripcion("CESQUEMA", "4").replace("Productos La", "").trim().toUpperCase(), textoNegrita));
                    }else{
                        reportePDF.add(new Paragraph(ValoresReferencia.getDescripcion("CESQUEMA", "5").replace("Productos", "").trim().toUpperCase(), textoNegrita));
                    }
                    clasificacionActual = datos.getInt("Clasificacion");
                }
                reportePDF.add(new Paragraph(datos.getString("ProductoClave") + "-" + datos.getString("Nombre"), textoNegrita));

                aux= Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("CtdPedidos"),"#,##0.##"), 11, Impresion.TipoAlineacion.DERECHA, false);
                aux+= Impresion.completaHasta((datos.getFloat("Pallets") <0 ?  " " : Generales.getFormatoDecimal(datos.getFloat("Pallets"),"##0")), 7, Impresion.TipoAlineacion.DERECHA, false);
                aux+= Impresion.completaHasta((datos.getFloat("Camas")<0 ? " " :Generales.getFormatoDecimal(datos.getFloat("Camas"),"##0")), 7, Impresion.TipoAlineacion.DERECHA, false);
                aux+= Impresion.completaHasta((datos.getFloat("CajasSueltas")<0? " " :Generales.getFormatoDecimal(datos.getFloat("CajasSueltas"),"##0.##")), 7, Impresion.TipoAlineacion.DERECHA, false);
                aux+= Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Peso"), "#,##0"), 9, Impresion.TipoAlineacion.DERECHA, false);
                aux+= Impresion.completaHasta(Generales.getFormatoDecimal(datos.getFloat("Volumen") + (datos.getFloat("Pallets")  * Float.parseFloat(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("VolumenTarima"))), "#,##0.00"), 9, Impresion.TipoAlineacion.DERECHA, true);

                reportePDF.add(new Paragraph(aux, textoNegrita));

            }while(datos.moveToNext());
            datos.close();

            reportePDF.add(vacio);
            reportePDF.add(vacio);

            /*
            font = new Font(FontFamily.COURIER, 22, Font.BOLD);

            aux = Mensajes.get("XVolumen")+":  " + Generales.getFormatoDecimal(volumen, 2);

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            aux = Mensajes.get("XKgLts")+":  " + Generales.getFormatoDecimal(peso, 2);

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);

            aux = Mensajes.get("XSubtotal")+":  " + ((TextView)findViewById(R.id.txtSubtotal)).getText();

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_RIGHT);
            reportePDF.add(paragraph);

            datos = Consultas.ConsultasImpuesto.obtenerDetalleImpuestos(mPresenta.getTransProdid());
            if(datos.getCount() > 0)
                while(datos.moveToNext()){
                    paragraph = new Paragraph(datos.getString("Abreviatura")+": " + Generales.getFormatoDecimal(datos.getFloat("ImpuestoImp"), "$  #,##0.00") , font);
                    paragraph.setAlignment(Element.ALIGN_RIGHT);
                    reportePDF.add(paragraph);
                }
            else{
                paragraph = new Paragraph(Mensajes.get("XImpuestos")+": " + "$ 0.00", font);
                paragraph.setAlignment(Element.ALIGN_RIGHT);
                reportePDF.add(paragraph);
            }
            datos.close();

            aux = Mensajes.get("XTotal")+":  " + ((TextView)findViewById(R.id.txtTotal)).getText();

            paragraph = new Paragraph(aux, font);
            paragraph.setAlignment(Element.ALIGN_RIGHT);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);
            reportePDF.add(vacio);

            font = new Font(FontFamily.COURIER, 20, Font.NORMAL);

            aux = ((TextView)findViewById(R.id.txtNotas)).getText().toString();

            paragraph = new Paragraph(Mensajes.get("XNotas")+": " + aux, font);
            paragraph.setAlignment(Element.ALIGN_LEFT);
            reportePDF.add(paragraph);
            reportePDF.add(vacio);
*/
            document.add(reportePDF);

            document.close();

        }
        catch (Exception ex)
        {
            throw new Exception("Error al generar ticket:" + ex.getMessage());
        }

        if (!archivosGenerados.containsKey(nombreArchivo) && !nombreArchivo.equals(""))
        {
            ContentValues valoresRecibo = new ContentValues();
            archivosGenerados.put(nombreArchivo, valoresRecibo);
        }
        Sesion.set(Campo.ArchivosGenerados, archivosGenerados);
        return new File(impresion.getAbsolutePath() + "/" + nombreArchivo + ".pdf");
    }

	public void CapturarDescuento(float desc1, float desc2) {
        BDVend.setOrigenLog("CapturarTotales:CapturarDescuento");
		try {
			for(String trpId : aTransProdIds)
			{
				TRPDescCalculadora descCalculadora;
				if(desc1 != 0) {
					descCalculadora = new TRPDescCalculadora();

					descCalculadora.TransProdID = trpId;
					descCalculadora.Orden = 1;
					if (Consultas.ConsultasTRPDescCalculadora.existeDescuento(trpId,1)) {
						BDVend.recuperar(descCalculadora);
					}
					descCalculadora.Porcentaje = desc1;
					descCalculadora.MFechaHora = new Date();
					descCalculadora.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(descCalculadora);

					Log.d(CapturaTotales.class.getName(), "TransProd ID: " + trpId + " Total: " + desc1);
				}

				if(desc2 != 0) {
					descCalculadora = new TRPDescCalculadora();

					descCalculadora.TransProdID = trpId;
					descCalculadora.Orden = 2;
					if (Consultas.ConsultasTRPDescCalculadora.existeDescuento(trpId,2)) {
						BDVend.recuperar(descCalculadora);
					}
					descCalculadora.Porcentaje = desc2;
					descCalculadora.MFechaHora = new Date();
					descCalculadora.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					BDVend.guardarInsertar(descCalculadora);

					Log.d(CapturaTotales.class.getName(), "TransProd ID: " + trpId + " Total: " + desc2);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

    public void solicitarFirma()
    {
        BDVend.setOrigenLog("CapturarTotales:solicitarFirma");
        if (Consultas2.ConsultasPerfil.validarPermisoFirma((int)Sesion.get(Campo.TipoIndiceModuloMovDetalleClave))) {
            HashMap<String, Object> oParametros = new HashMap<String, Object>();
            oParametros.put("TransProdID", transProdIdFirma);
            mVista.iniciarActividadConResultado(ICapturaFirma.class, Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA, Enumeradores.Acciones.ACCION_CAPTURAR_FIRMA, oParametros);
        }else{
            mVista.solicitarImprimirTicket();
        }
    }
}
