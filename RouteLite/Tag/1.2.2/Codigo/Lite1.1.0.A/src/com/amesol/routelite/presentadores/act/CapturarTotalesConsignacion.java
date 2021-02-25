package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import android.database.Cursor;

import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
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
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TipoPedido;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion.VistaConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotalesConsignacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.CapturaTotalesConsignacion.vistaDesgloseImp;
import com.amesol.routelite.vistas.CapturaTotalesConsignacion.vistaDesgloseProm;
 
public class CapturarTotalesConsignacion extends Presentador
{

	ICapturaTotalesConsignacion mVista;
	String mAccion;
	ArrayList<String> aTransProdIds;
	ArrayList<TransProd> transacciones;
	short trueType;

	// sumatoria de los totales de todas las transacciones
	float subTotal = 0;
	float impuesto = 0;
	float total = 0;
	float totalInicialCredito = 0;

	public CapturarTotalesConsignacion(ICapturaTotalesConsignacion vista, String accion, ArrayList<String> transacciones)
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
			actualiza = Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, oTrp.Tipo, oTrp.TipoMovimiento, 
					((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);
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

	public void asignarGuardarValores() throws Exception
	{
		float saldoCliente = 0f;
		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		CONHist oConHis = (CONHist) Sesion.get(Campo.CONHist);
		Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
		CLIFormaVenta cfv = null;
		int tipoLimiteCredito = Integer.parseInt(((String)oConHis.get("TipoLimiteCredito")));
		int tipoCobranza = Integer.parseInt(((String)oConHis.get("TipoCobranza")));
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
					boolean isPreventa = tipoModulo == Enumeradores.TiposModulos.VENTA || tipoModulo == Enumeradores.TiposModulos.REPARTO;
					if((tipoCobranza == 0 || tipoCobranza == 2) && cliente.TipoFiscal == 1){
						if(isPreventa){
							saldoCliente = Consultas.ConsultasTransProd.obtenerSaldoCliente(cliente.ClienteClave);
							saldoCliente+= Consultas.ConsultasCliente.obtenerSaldoEfectivo(cliente.ClienteClave) + oTrp.Total;
						}
						else
							saldoCliente = Consultas.ConsultasTransProd.obtenerSaldoCobrarVentas(cliente) + oTrp.Total;
					}
					else if((tipoCobranza == 1 || tipoCobranza == 2) && cliente.TipoFiscal == 2){
						if(isPreventa)
							saldoCliente = Consultas.ConsultasTransProd.obtenerSaldoCliente(cliente.ClienteClave);
						else
							saldoCliente = Consultas.ConsultasTransProd.obtenerSaldoNoCobrarVentas(cliente) + oTrp.Total;
					}
					
					if(cliente.ActualizaSaldoCheque){
						saldoAbonos = Consultas.ConsultasAbono.obtenerSaldoAbonos(cliente, true, Enumeradores.FormasDePago.CHEQUE);
					}else{
						saldoAbonos = Consultas.ConsultasAbono.obtenerSaldoAbonos(cliente, true);
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
		String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");

		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(lstTrpTipo, Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()), ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Visita) Sesion.get(Campo.VisitaActual)).DiaClave, aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
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
