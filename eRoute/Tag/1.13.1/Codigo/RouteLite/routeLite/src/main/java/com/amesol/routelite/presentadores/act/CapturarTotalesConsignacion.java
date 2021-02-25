package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

import android.content.ContentValues;
import android.database.Cursor;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasTransProd;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasTransProdDetalle;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TipoPedido;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion.VistaConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotalesConsignacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CapturaTotalesConsignacion.vistaDesgloseImp;
import com.amesol.routelite.vistas.CapturaTotalesConsignacion.vistaDesgloseProm;
import com.amesol.routelite.vistas.Vista;
 
public class CapturarTotalesConsignacion extends Presentador
{

	ICapturaTotalesConsignacion mVista;
	String mAccion;
	ArrayList<String> aTransProdIds;
	ArrayList<TransProd> transacciones;
	short trueType;
	private Promociones2 promociones;

	// sumatoria de los totales de todas las transacciones
	float subTotal;
	float impuesto;
	float total;
	float totalInicialCredito;
	float abonosAnteriores;

    String transProdIdFirma = "";

	public CapturarTotalesConsignacion(ICapturaTotalesConsignacion vista, String accion, ArrayList<String> transacciones, float abonosAnteriores)
	{
		mVista = vista;
		mAccion = accion;
		this.aTransProdIds = transacciones;
		this.abonosAnteriores = abonosAnteriores;
	}

	@SuppressWarnings(
	{ "unchecked", "rawtypes" })
	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();

			subTotal = 0;
			impuesto = 0;
			total = 0;

			ArrayList<String> folios = new ArrayList<String>();
			if (mVista.getEsNuevo())
			{ // si es nuevo obtener folios
				String mensaje = "";
				folios = Folios.ObtenerVarios(Sesion.get(Campo.ModuloMovDetalleClave).toString(), aTransProdIds.size(), mensaje);
				mVista.setFolio(folios.toString().replace(", ", "/").replace("[", "").replace("]", ""));
			}

			transacciones = new ArrayList<TransProd>();
			boolean primero = true;

			HashMap<String, TransProd> arrayTransProd = (HashMap<String, TransProd>) Sesion.get(Campo.ArrayTransProd);
			Iterator it = arrayTransProd.entrySet().iterator();

			while (it.hasNext())
			{ // recorrer todas las transacciones generadas para calcular
				// totales, impuestos, descuentos, etc ...
				Map.Entry e = (Map.Entry) it.next();

				TransProd oTrp = (TransProd) e.getValue();
                if (transProdIdFirma == "")
                    transProdIdFirma = oTrp.TransProdID;
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
					mVista.setListaPrecios(oTrp.PCEPrecioClave);
					if (!mVista.getEsNuevo())
					{ // si no es nuevo, cargar los datos del transprod
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO && oTrp.Tipo == TiposTransProd.PEDIDO){
							oTrp.TipoPedido = TipoPedido.NORMAL;
						}
						mVista.setSoloLectura(false);
						mVista.setFolio(oTrp.Folio);
						mVista.setTipoFase(oTrp.TipoFase);
						mVista.setFechaEntrega(oTrp.FechaCaptura);
						mVista.setComentarios(oTrp.Notas);
					}
					else
					{ // si es nuevo, asignar valores por default
						mVista.setSoloLectura(false);
						mVista.setTipoFase(oTrp.TipoFase);
						mVista.setFechaEntrega(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura); // calcular la fecha de
															// entrega
					}
					
					primero = false;
				}
				Transacciones.Pedidos.CalcularTotalesPedido(oTrp);

				if (mVista.getEsNuevo()) // si es nuevo, asignar los folios al
											// transprod
					oTrp.Folio = folios.get(transacciones.size());

				subTotal += oTrp.SubTDetalle == null ? 0 : oTrp.SubTDetalle;
				impuesto += oTrp.Impuesto == null ? 0 : oTrp.Impuesto;
				total += oTrp.Total;

                BDVend.guardarInsertar(oTrp);

				transacciones.add(oTrp);

			}

			mVista.setSubTotal(subTotal);
			mVista.setImpuesto(impuesto);
			mVista.setTotal(total);

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}
	
	/**
	 * Realiza la eliminacion de la consignacion
	 */
	public void eliminarConsignacion() throws Exception{
		VistaConsignacion vistaConsig = (VistaConsignacion) Sesion.get(Campo.VistaConsignacion);
		TransProd oTrp = new TransProd();
		oTrp.TransProdID = vistaConsig.TransProdId;
		BDVend.recuperar(oTrp);
		BDVend.recuperar(oTrp, TransProdDetalle.class);
		boolean actualiza;
		//Actualizar inventario
		for (TransProdDetalle transProdDetalle : oTrp.TransProdDetalle)
		{
            if (transProdDetalle.PrestamoVendido == null)
                transProdDetalle.PrestamoVendido = (float)0;
            actualiza = Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, oTrp.Tipo, oTrp.TipoMovimiento,
                    ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true, transProdDetalle.PrestamoVendido);
            ManejoEnvase.manejoEnvaseEliminar(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, transProdDetalle, oTrp);
		}
		//Eliminar detalles
		ConsultasTransProdDetalle.eliminarDetalle(oTrp.TransProdID);
		//Eliminar transaccion
		BDVend.eliminar(oTrp);
		BDVend.commit();
	}

	public String getTransProdid()
	{
		return aTransProdIds.get(0);
	}

    private void validarLimitePrestamoEnvase() throws Exception{
        if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
                Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)){
            AtomicReference<String> mensaje = new AtomicReference<>();
            ManejoEnvase.validarLimitePrestamoEnvase(mensaje, getTransProdid(), false);
            if(mensaje.get() != null){
                mVista.setMensajeLimiteEnvase(true);
                mVista.mostrarError(mensaje.get());
            }
        }
    }

	public void asignarGuardarValores() throws Exception
	{
        if( (mVista.getEsNuevo() || mVista.getModificando()) ){  //&& getTipo() == TiposTransProd.PEDIDO){
            //validacion limite prestamo envase
            validarLimitePrestamoEnvase();
        }

		float saldoCliente = 0f;
		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		CONHist oConHis = (CONHist) Sesion.get(Campo.CONHist);
		Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
		CLIFormaVenta cfv = null;
		int tipoLimiteCredito = Integer.parseInt(((String)oConHis.get("TipoLimiteCredito")));
		int tipoCobranza = Integer.parseInt(((String)oConHis.get("TipoCobranza")));
		int tipoTrp = 1;
		BDVend.recuperar(cliente, CLIFormaVenta.class);
		for(CLIFormaVenta cfvTemp : cliente.CLIFormaVenta){
			if(cfvTemp.CFVTipo == 2){
				cfv = cfvTemp;
				break;
			}
		}
		Iterator<TransProd> it = transacciones.iterator();
		boolean primero = true;
		while (it.hasNext())
		{
			TransProd oTrp = it.next();
			if(cfv != null && cfv.CFVTipo == 2){
				oTrp.DiasCredito = (short) cfv.DiasCredito;
			}
			oTrp.Notas = mVista.getNotas();
			oTrp.Saldo = oTrp.Total;
			oTrp.MFechaHora = Generales.getFechaHoraActual();
			oTrp.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			oTrp.Enviado = false;
			if (primero)
			{
				if((tipoLimiteCredito == 2 || tipoLimiteCredito == 4) && cfv != null && cfv.ValidaLimite){
					float valor, saldoAbonos;
					int tipoModulo = Integer.parseInt(Sesion.get(Campo.TipoModulo).toString());
					boolean isPreventa = !(tipoModulo == Enumeradores.TiposModulos.VENTA || tipoModulo == Enumeradores.TiposModulos.REPARTO);
					if((tipoCobranza == 1 || tipoCobranza == 2) && cliente.TipoFiscal == 1){
						tipoTrp = 1;
						if(isPreventa){
							saldoCliente = Consultas.ConsultasTransProd.obtenerSaldoCliente(cliente.ClienteClave);
							saldoCliente+= Consultas.ConsultasCliente.obtenerSaldoEfectivo(cliente.ClienteClave) + oTrp.Total - totalInicialCredito;
						}else{
							saldoCliente = Consultas.ConsultasTransProd.obtenerSaldoPedidosConsignaciones(cliente, "'" + oTrp.TransProdID + "'") + oTrp.Total - totalInicialCredito;
						}
					}else if((tipoCobranza == 0 || tipoCobranza == 2) && cliente.TipoFiscal == 2){
						if(!isPreventa){
							saldoCliente = Consultas.ConsultasTransProd.obtenerSaldoConsignasLiquidadas(cliente);
							saldoCliente+= oTrp.Total - totalInicialCredito;
						}
						tipoTrp = 8;
					}
					
					if(cliente.ActualizaSaldoCheque){
						saldoAbonos = Consultas.ConsultasAbono.obtenerSaldoAbonos(cliente, true);
					}else{
						saldoCliente+= Consultas.ConsultasAbono.obtenerAbonosCheque(cliente, String.valueOf(tipoTrp));
						saldoAbonos = Consultas.ConsultasAbono.obtenerSaldoAbonos(cliente, false, Enumeradores.FormasDePago.CHEQUE);
					}
					saldoCliente = saldoCliente - saldoAbonos;
					valor = cfv.LimiteCredito - saldoCliente;
					if(valor < 0)
					{
						float riesgo = cfv.LimiteCredito * Float.parseFloat((String)oConHis.get("PorcentajeRiesgo"))/100;
						if(Math.abs(valor) > riesgo){
							if(tipoLimiteCredito == 2){
								throw new ControlError("E0737", String.valueOf(Math.abs(valor)));
							}else{
								mVista.setMensajeLimiteCredito(true);
								mVista.mostrarAdvertencia(Mensajes.get("I0266", String.valueOf(Math.abs(valor))));
							}
						}
					}
				}		
				primero = false;
			}

			if (mVista.getEsNuevo())
				Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());

			Clientes.actualizarSaldoCteActual(oTrp.Total);
			
			BDVend.guardarInsertar(oTrp);

			BDVend.commit();
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
									valor = Consultas.ConsultasTransProd.obtenerSaldoCobrarVentas(oCliente, "");
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
		//String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");

		//ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(lstTrpTipo, Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()), ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Visita) Sesion.get(Campo.VisitaActual)).DiaClave, aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
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


	
	public void recalcular() throws Exception{
		final TransProd transProdVta = transacciones.get(0);
		promociones = new Promociones2(transProdVta, (Vista) mVista);
		if(promociones.Preparar()){
			try
			{
				BDVend.recuperar(transProdVta);
				BDVend.recuperar(transProdVta, TransProdDetalle.class);
				// obtener todos los impuestos para que se recalculen
				// correctamente
				for (TransProdDetalle oTpd : (transProdVta).TransProdDetalle)
				{
					BDVend.recuperar(oTpd, TPDImpuesto.class);
				}
			}
			catch (Exception e)
			{
				e.printStackTrace();
			}
		}
		promociones.setOnTerminarAplicacionListener(new Promociones2.onTerminarAplicacionListener()
		{
			
			@Override
			public void onTerminarAplicacion()
			{
				try{
					Transacciones.calcularTotalesTransaccion(transProdVta);
					iniciar();
				}catch(Exception ex)
				{
					mVista.mostrarError(ex.getMessage());
				}
			}
		});
		promociones.Aplicar();
	}
	
	public void validarVenta() throws Exception, ControlError{
		CONHist oConHis = (CONHist) Sesion.get(Campo.CONHist);
		TransProd transProdVta = transacciones.get(0);
		float saldoFinal = transProdVta.Total - abonosAnteriores;
		if(saldoFinal < 0)
		{
			throw new ControlError("E0697");
		}
		transProdVta.Saldo = saldoFinal;
		if (AplicarPagoAutomatico(transProdVta)){
			if (oConHis.get("Preliquidacion").equals("1"))
			{
				ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
				PreLiquidacion mPreLiquidacion = new PreLiquidacion();
				if (mObtenerPreliquidacion.getCount() == 0)
				{
					mPreLiquidacion.MontoTotal = Consultas.ConsultasTransProd.obtenerEfectivo();
					mPreLiquidacion.FechaPreLiquidacion = Generales.getFechaHoraActual(); 
					mPreLiquidacion.PLIId = KeyGen.getId();
					mPreLiquidacion.Enviado = false;
					mPreLiquidacion.MontoTotal = transProdVta.Total;
					BDVend.guardarInsertar(mPreLiquidacion);
				}
				else
				{
					mObtenerPreliquidacion.moveToFirst();
					String PLIId = mObtenerPreliquidacion.getString(0);
					mPreLiquidacion.PLIId = PLIId;
					BDVend.recuperar(mPreLiquidacion);
					mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) + transProdVta.Total;
					BDVend.guardarInsertar(mPreLiquidacion);
				}
				transProdVta.PLIId = mPreLiquidacion.PLIId;
				transProdVta.Notas = mVista.getNotas();
				transProdVta.MFechaHora = Generales.getFechaHoraActual();
				transProdVta.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(transProdVta);
				Clientes.actualizarSaldoCteActual(transProdVta.Saldo);
				ISetDatos abonos = Consultas.ConsultasAbnTrp.obtenerAbonos(transacciones.get(0).TransProdID);
				while(abonos != null && abonos.getCount() > 0 && abonos.moveToNext()){
					AbnTrp abono = new AbnTrp();
					abono.ABNId = abonos.getString(0);
					BDVend.recuperar(abono);
					abono.TransProdID = transProdVta.TransProdID;
					BDVend.guardarInsertar(abono);
				}
			}
		}
	}
	
	private boolean AplicarPagoAutomatico(TransProd oTransProd) throws Exception{
			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
			else
				trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

			if (trueType == 1 && ((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1"))
			{
				oTransProd.FechaCobranza = Generales.getFechaHoraActual();
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
				oTransProd.Saldo = 0;							
			}else{
				return false;
			}
			
		return true;		
	}

    public void solicitarFirma()
    {
        if (Consultas2.ConsultasPerfil.validarPermisoFirma((int)Sesion.get(Campo.TipoIndiceModuloMovDetalleClave))) {
            HashMap<String, Object> oParametros = new HashMap<String, Object>();
            oParametros.put("TransProdID", transProdIdFirma);
            mVista.iniciarActividadConResultado(ICapturaFirma.class, Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA, Enumeradores.Acciones.ACCION_CAPTURAR_FIRMA, oParametros);
        }else{
            mVista.solicitarImprimirTicket();
        }
    }

    public void guardarFirmaDigital(String sNombre, String sNombreArchivo)throws Exception
    {
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

	public Promociones2 getPromociones()
	{
		return promociones;
	}
}
