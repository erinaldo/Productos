package com.amesol.routelite.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Comparator;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.concurrent.Semaphore;

import android.database.Cursor;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.SimpleAdapter;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.FoliosFiscales;
import com.amesol.routelite.actividades.FoliosFiscales.FoliosFiscalesException;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ClientePago;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.FolioFiscal;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.SEMHist;
import com.amesol.routelite.datos.SaldoCambiosVendedor;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.interfaces.ISeleccionFacturacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CentroExpedicion;
import com.amesol.routelite.vistas.SeleccionFacturacion;
import com.amesol.routelite.vistas.SeleccionFacturacion.AdapterGenerico;
import com.amesol.routelite.vistas.TRPDatoFiscal;
import com.amesol.routelite.vistas.Vista;

public class SeleccionarFacturacion extends Presentador
{
	private ISeleccionFacturacion mVista;
	
	private List<TransProd> pedidosFacturados;

	private static final String CADENA_VACIA = "";
	public static final String TAG = "FacturacionElectronica";

	private TransProdFactura facturaSeleccionada;
	private TransProd factura;
	private TRPDatoFiscal datoFiscal;
	
	private boolean cancelar;
	
	public SeleccionarFacturacion(ISeleccionFacturacion vista)
	{
		mVista = vista;
	}

	/**
	 * Obtiene las facturas para el cliente actual y las muestra en pantalla.
	 */
	@Override
	public void iniciar()
	{
		try
		{
			cargarFacturas();
			mVista.initSpinners();
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
			/* Iniciar los métodos de pago del cliente */
			ISetDatos pagos = Consultas.ConsultasClientePago.obtenerFormasPago(cliente.ClienteClave);
			List<Entidad> listPagos = new ArrayList<Entidad>();
			while (pagos.moveToNext())
			{
				ClientePago cliPago = new ClientePago();
				cliPago.ClienteClave = cliente.ClienteClave;
				cliPago.Tipo = pagos.getShort(0);
				cliPago.TipoBanco = pagos.getShort(1);
				cliPago.Cuenta = pagos.getString(2);
				listPagos.add(cliPago);
			}
			pagos.close();
			mVista.initAdapterView(((SeleccionFacturacion) mVista).new AdapterGenerico(R.layout.lista_metodo_pago_facturacion, listPagos), R.id.lstMetodosPago);
			mVista.setSoloLectura(false);
			cancelar = false;
			cargaDatosFiscales(cliente, true);
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}
	
	public void cargarFacturas() throws Exception{
		Visita visita = (Visita) Sesion.get(Campo.VisitaActual);
		List<TransProdFactura> facturas = Consultas.ConsultasTransProd.obtenerFacturasPorVisita(visita);
		mVista.mostrarFacturas(facturas);
	}
	
	public SEMHist getSubEmpresa(){
		try{
			return Consultas.ConsultasSEMHist.obtenerSubEmpresa(factura.SubEmpresaId);
		}catch(Exception ex)
		{
			SEMHist semHist = new SEMHist();
			semHist.NombreCorto = "SubEmpresa no encontrada";
			return semHist;
		}
	}
	
	public CLIFormaVenta getFormaVenta(){
		CLIFormaVenta cfv = new CLIFormaVenta();
		cfv.setDescripcion(ValoresReferencia.getDescripcion("FVENTA", String.valueOf(factura.CFVTipo)));
		return cfv;
	}
	
	/**
	 * Realiza las validaciones correspondientes para comprobar que la
	 * configuracion es correcta para poder crear facturas.
	 * 
	 * @throws ControlError
	 */
	public void validarInicioFacturacion() throws ControlError
	{
		try
		{
			if (Consultas.ConsultasSEMHist.obtenerSubEmpresasPuedanEmitirFacturas().isEmpty())
			{
				throw new ControlError("I0178");
			}
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
			if (cliente.IdFiscal == null || cliente.IdFiscal.trim().isEmpty())
			{
				throw new ControlError("E0665");
			}
			BDVend.recuperar(cliente, ClienteDomicilio.class);
			boolean tieneDomicilio = false;
			for (ClienteDomicilio dom : cliente.ClienteDomicilio)
				if (dom.Tipo == 1)
					tieneDomicilio = true;
			if (!tieneDomicilio)
			{
				throw new ControlError("E0664");
			}
			ISetDatos pagos = Consultas.ConsultasClientePago.obtenerFormasPago(cliente.ClienteClave);
			if (pagos == null || pagos.getCount() == 0)
			{
				throw new ControlError("E0867", "Método de Pago para el Cliente");
			}
			pagos.close();
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.toString());
		}
	}

	private void cargaDatosFiscales(Cliente cliente, boolean recuperar)
	{
		mVista.cargaDatosDeFacturacion(cliente, getDomicilioFiscal(cliente, true));
	}
	
	public void setFacturaSeleccionada(TransProdFactura facturaSeleccionada)
	{
		this.facturaSeleccionada = facturaSeleccionada;
	}
	
	public TransProdFactura getFacturaSeleccionada()
	{
		return facturaSeleccionada;
	}

	private ClienteDomicilio getDomicilioFiscal(Cliente cliente, boolean recuperar)
	{
		ClienteDomicilio domicilioFiscal = null;
		try
		{
			if (recuperar)
				BDVend.recuperar(cliente, ClienteDomicilio.class);
			for (ClienteDomicilio domicilio : cliente.ClienteDomicilio)
			{
				if (domicilio.Tipo == 1)
				{
					domicilioFiscal = domicilio;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarAdvertencia(ex.getMessage());
		}
		return domicilioFiscal;
	}

	public boolean crearFactura(Cliente cliente, boolean guardaCliente)
	{
		pedidosFacturados = (List<TransProd>) mVista.getPedidosParaFactura();
		try
		{
			if(guardaCliente)
				BDVend.guardarInsertar(cliente);
			TransProd tpFactura = crearTransProdFactura();
			BDVend.guardarInsertar(tpFactura);
			TRPDatoFiscal trpFiscal = crearTRPDatoFiscal(tpFactura, cliente);
			BDVend.guardarInsertar(trpFiscal);
			boolean pagoAutomatico = true;
			/* Actualizar los pedidos */
			for(TransProd tpPedido:pedidosFacturados)
			{
				BDVend.recuperar(tpPedido);
				tpPedido.TipoFase = 3;
				tpPedido.FacturaID = tpFactura.TransProdID;
				tpPedido.FechaFacturacion = tpFactura.FechaFacturacion;
				tpPedido.Enviado = false;
				tpPedido.MFechaHora = Generales.getFechaHoraActual();
				tpPedido.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(tpPedido);
				if(pagoAutomatico) 
					pagoAutomatico = tpPedido.CFVTipo == 1 && Integer.parseInt(tpPedido.ClientePagoId) == Enumeradores.FormasDePago.EFECTIVO;
			}
			/* Actualizar el folio fiscal */
			
			FoliosFiscales.actualizarFolioFiscal(trpFiscal.FolioId, trpFiscal.FOSId);
			/* Verificar Tipo Cobranza */
			CONHist conHist = (CONHist) Sesion.get(Campo.CONHist);
			if("0".equals(conHist.get("TipoCobranza")) || ("2".equals(conHist.get("TipoCobranza")) && cliente.TipoFiscal == 2))
			{
				if(!Clientes.actualizarSaldoCteActual(tpFactura.Total))
				{
					throw new Exception("Error al actualizar el saldo al cliente");
				}
				if(pagoAutomatico && "1".equals(conHist.get("PagoAutomatico")))
				{
					aplicarPagoAutomatico(tpFactura, false);
					if("1".equals(conHist.get("Preliquidacion")))
					{
						ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
						PreLiquidacion mPreLiquidacion = new PreLiquidacion();
						if (mObtenerPreliquidacion.getCount() == 0)
						{
							mPreLiquidacion.FechaPreLiquidacion = Generales.getFechaHoraActual(); 
							mPreLiquidacion.PLIId = KeyGen.getId();
							mPreLiquidacion.Enviado = false;
							mPreLiquidacion.MontoTotal = tpFactura.Total;
							BDVend.guardarInsertar(mPreLiquidacion);
						}
						else
						{
							mObtenerPreliquidacion.moveToFirst();
							String PLIId = mObtenerPreliquidacion.getString(0);
							mPreLiquidacion.PLIId = PLIId;
							BDVend.recuperar(mPreLiquidacion);
							mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) + tpFactura.Total;
							BDVend.guardarInsertar(mPreLiquidacion);
						}
						tpFactura.PLIId = mPreLiquidacion.PLIId;
						BDVend.guardarInsertar(tpFactura);
					}
				}
			}
			
			BDVend.commit();
			factura = tpFactura;
			return true;
		}
		catch (Exception ex)
		{
			try
			{
				BDVend.rollback();
			}
			catch (Exception rbe)
			{
				Log.e("EROUTE_BDVEND", "Error en el rollback: " + rbe.getMessage());
			}
			mVista.mostrarError(ex.getMessage());
			return false;
		}
	}

	private TransProd crearTransProdFactura() throws Exception
	{
		TransProd tp = new TransProd();
		Dia dia = (Dia) Sesion.get(Campo.DiaActual);
		tp.TransProdID = KeyGen.getId();
		tp.VisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
		tp.DiaClave = dia.DiaClave;
		tp.PCEModuloMovDetClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
		tp.SubEmpresaId = mVista.getSubEmpresaSeleccionada().SubEmpresaId;
		tp.CFVTipo = (short) mVista.getFormaDeVentaSeleccionada();
		tp.Folio = mVista.getFolio().toString();
		tp.Tipo = 8; // Tipo Factura
		tp.TipoFase = 1;
		tp.FechaHoraAlta = Generales.getFechaHoraActual();
		tp.FechaCaptura = tp.FechaFacturacion = dia.FechaCaptura;
		String pedidosIds = getPedidosIds();
        tp.Subtotal = Transacciones.Factura.obtenerSubtotal(((Visita) Sesion.get(Campo.VisitaActual)).ClienteClave, pedidosIds);
        tp.Impuesto = Transacciones.Factura.obtenerImpuesto(((Visita) Sesion.get(Campo.VisitaActual)).ClienteClave,pedidosIds);
		tp.Total = tp.Saldo = mVista.getSubEmpresaSeleccionada().VersionCFD == 5 ? mVista.getTotalFactura() : Generales.getRound(mVista.getTotalFactura(), 2);
		/* Ordenar por fecha de cobranza */
		Collections.sort(pedidosFacturados, comparador);
		tp.FechaCobranza = pedidosFacturados.get(0).FechaCobranza;
		tp.Notas = mVista.getOrdenCompra();
		tp.Enviado = false;
		tp.MFechaHora = tp.FechaHoraAlta;
		tp.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		return tp;
	}

	private TRPDatoFiscal crearTRPDatoFiscal(TransProd factura, Cliente cliente) throws Exception
	{
		TRPDatoFiscal trpFiscal = new TRPDatoFiscal();
		ClienteDomicilio dom = getDomicilioFiscal(cliente, false);
		boolean existeSucursal = false;
		CentroExpedicion ceSucursal = Consultas.ConsultasCentroExpedicion.obtenerCentroExpedicion(mVista.getSubEmpresaSeleccionada().SubEmpresaId);
		CentroExpedicion cePadre;
		if (ceSucursal.Tipo == 0)
		{
			cePadre = ceSucursal;
		}
		else
		{
			existeSucursal = true;
			String ceId = ceSucursal.CentroExpPadreID;
			do
			{
				cePadre = new CentroExpedicion();
				cePadre.CentroExpID = ceId;
				BDVend.recuperar(cePadre);
				ceId = cePadre.CentroExpPadreID;
			}
			while (cePadre.Tipo != 0);
		}

		trpFiscal.TransProdID = factura.TransProdID;
		trpFiscal.FolioId = mVista.getFolio().FolioId;
		trpFiscal.FOSId = mVista.getFolio().FOSId;
		trpFiscal.RazonSocial = remplazaComilla(cliente.RazonSocial);
		trpFiscal.RFC = remplazaComilla(cliente.IdFiscal.replace("-", ""));
		trpFiscal.TelefonoContacto = remplazaComilla(cliente.TelefonoContacto);
		trpFiscal.Calle = remplazaComilla(dom.Calle);
		trpFiscal.NumInt = remplazaComilla(dom.NumInt);
		trpFiscal.NumExt = remplazaComilla(dom.Numero);
		trpFiscal.Colonia = remplazaComilla(dom.Colonia);
		trpFiscal.CodigoPostal = remplazaComilla(dom.CodigoPostal);
		trpFiscal.ReferenciaDom = remplazaComilla(dom.ReferenciaDom);
		trpFiscal.Localidad = remplazaComilla(dom.Localidad);
		trpFiscal.Municipio = remplazaComilla(dom.Poblacion);
		trpFiscal.Entidad = remplazaComilla(dom.Entidad);
		trpFiscal.Pais = remplazaComilla(dom.Pais);

		trpFiscal.CadenaOriginal = "";
		trpFiscal.SelloDigital = "";

		trpFiscal.TelefonoEm = mVista.getSubEmpresaSeleccionada().Telefono;
		trpFiscal.RFCEm = remplazaComilla(cePadre.RFC);
		trpFiscal.NombreEm = remplazaComilla(cePadre.Nombre);
		trpFiscal.CalleEm = remplazaComilla(cePadre.Calle);
		trpFiscal.NumExtEm = remplazaComilla(cePadre.NumExt);
		trpFiscal.NumIntEm = remplazaComilla(cePadre.NumInt);
		trpFiscal.ColoniaEm = remplazaComilla(cePadre.Colonia);
		trpFiscal.LocalidadEm = remplazaComilla(cePadre.Localidad);
		trpFiscal.ReferenciaDomEm = remplazaComilla(cePadre.ReferenciaDom);
		trpFiscal.MunicipioEm = remplazaComilla(cePadre.Municipio);
		trpFiscal.RegionEm = remplazaComilla(cePadre.Entidad);
		trpFiscal.PaisEm = trpFiscal.PaisEx = remplazaComilla(cePadre.Pais);
		trpFiscal.CodigoPostalEm = remplazaComilla(cePadre.CodigoPostal);

//		if (existeSucursal)
//		{
			trpFiscal.CalleEx = remplazaComilla(ceSucursal.Calle);
			trpFiscal.NumExtEx = remplazaComilla(ceSucursal.NumExt);
			trpFiscal.NumIntEx = remplazaComilla(ceSucursal.NumInt);
			trpFiscal.ColoniaEx = remplazaComilla(ceSucursal.Colonia);
			trpFiscal.LocalidadEx = remplazaComilla(ceSucursal.Localidad);
			trpFiscal.ReferenciaDomEx = remplazaComilla(ceSucursal.ReferenciaDom);
			trpFiscal.MunicipioEx = remplazaComilla(ceSucursal.Municipio);
			trpFiscal.EntidadEx = remplazaComilla(ceSucursal.Entidad);
			trpFiscal.PaisEx = remplazaComilla(ceSucursal.Pais);
			trpFiscal.CodigoPostalEx = remplazaComilla(ceSucursal.CodigoPostal);
//		}
//		else
//		{
//			trpFiscal.CalleEx = CADENA_VACIA;
//			trpFiscal.NumExtEx = CADENA_VACIA;
//			trpFiscal.NumIntEx = CADENA_VACIA;
//			trpFiscal.ColoniaEx = CADENA_VACIA;
//			trpFiscal.LocalidadEx = CADENA_VACIA;
//			trpFiscal.ReferenciaDomEx = CADENA_VACIA;
//			trpFiscal.MunicipioEx = CADENA_VACIA;
//			trpFiscal.EntidadEx = CADENA_VACIA;
//			trpFiscal.CodigoPostalEx = CADENA_VACIA;
//		}

		trpFiscal.TipoVersion = ValoresReferencia.getDescripcion("VERFACTE", mVista.getSubEmpresaSeleccionada().getVersionCFD());
		String[] metodosPago = mVista.getMetodosPagoSeleccionados();
		trpFiscal.MetodoPago = remplazaComilla(metodosPago[0]);
		trpFiscal.NumCtaPago = remplazaComilla(metodosPago[1]);
		trpFiscal.Banco = remplazaComilla(metodosPago[2]);
		trpFiscal.Enviado = false;
		trpFiscal.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		trpFiscal.MFechaHora = Generales.getFechaHoraActual();

		return trpFiscal;
	}

	private String getPedidosIds()
	{
		StringBuilder pedidos = new StringBuilder();
		Iterator<TransProd> iterator = pedidosFacturados.iterator();
		while (iterator.hasNext())
		{
			pedidos.append("'").append(iterator.next().TransProdID).append(iterator.hasNext() ? "'," : "'");
		}
		return pedidos.toString();
	}
	
	private void aplicarPagoAutomatico(TransProd factura, boolean cancelar) throws Exception{
		/* Es cancelacion */
		if(cancelar){
			ISetDatos abonos = Consultas.ConsultasAbnTrp.obtenerAbonos(factura.TransProdID);
			if(abonos.moveToFirst()){
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
				Clientes.actualizarSaldoCteActual(factura.Total);
				factura.Saldo = factura.Saldo + factura.Total;
			}
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
			oAbn.Total = factura.Total;
			oAbn.Saldo = 0;
	
			ABNDetalle oAbd = new ABNDetalle();
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
	
			oAbd.ABNId = oAbn.ABNId;
			oAbd.ABDId = KeyGen.getId();
			oAbd.TipoPago = Enumeradores.FormasDePago.EFECTIVO;
			oAbd.Importe = factura.Total;
			oAbd.SaldoDeposito = factura.Total;
			oAbd.MonedaID = ((CONHist)Sesion.get(Campo.CONHist)).get("MonedaID").toString();
			oAbd.SaldoCarga = 0;
			oAbd.MFechaHora = Generales.getFechaHoraActual();
			oAbd.MUsuarioID = sUsuarioID;
			oAbd.Enviado = false;
			oAbn.ABNDetalle.add(oAbd);
	
			
			AbnTrp oAbt = new AbnTrp();
			oAbt.ABNId = oAbn.ABNId;
			oAbt.TransProdID = factura.TransProdID;
			oAbt.FechaHora = Generales.getFechaHoraActual();
			oAbt.Importe = factura.Total;
			oAbt.MFechaHora = Generales.getFechaHoraActual();
			oAbt.MUsuarioID = sUsuarioID;
			oAbt.Enviado = false;
			oAbn.AbnTrp.add(oAbt);
			
			Folios.confirmar(TiposModuloMovDetalle.PAGOS);
	
			BDVend.guardarInsertar(oAbn);
			factura.Saldo = 0;
			BDVend.guardarInsertar(factura);
			
			if(!Clientes.actualizarSaldoCteActual(factura.Total*-1))
			{
				throw new Exception("Error al actualizar el saldo al cliente");
			}
		}
	}

	/**
	 * Valida si se puede ejecutar una accion sobre la factura seleccionada
	 * 
	 * @param itemId
	 *        - especifica la accion a validar
	 * @throws Exception 
	 */
	public void validarAccion(int itemId) throws Exception
	{
		TRPDatoFiscal datoFiscal = new TRPDatoFiscal();
		datoFiscal.TransProdID = facturaSeleccionada.TransProdId;
		switch(itemId)
		{
			case R.id.cancelar:
				if(facturaSeleccionada.Enviado)
				{
					throw new ControlError("E0927");
				}
				if(facturaSeleccionada.TipoFase != 1){
					BDVend.recuperar(datoFiscal);
					throw new ControlError("1.0".equals(datoFiscal.TipoVersion)?"E0247":"E0043", Mensajes.get("XCancelada"));
				}
				CONHist conHist = (CONHist) Sesion.get(Campo.CONHist);
				Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
				if("0".equals(conHist.get("TipoCobranza")) || ("2".equals(conHist.get("TipoCobranza")) && cliente.TipoFiscal == 2))
				{
					ISetDatos abonos = Consultas.ConsultasAbnTrp.obtenerAbonos(facturaSeleccionada.TransProdId);
					final boolean existenAbonos = abonos.getCount() > 0;
					abonos.close();
					if("0".equals(conHist.get("PagoAutomatico")))
					{
						if(existenAbonos){
							throw new ControlError("E0762");
						}
					}
					if("1".equals(conHist.get("PagoAutomatico")))
					{
						List<Entidad> pedidosFacturados = Consultas.ConsultasTransProd.obtenerPedidosDeFactura(facturaSeleccionada.TransProdId);
						TransProd pedido;
						for(Entidad entidad : pedidosFacturados){
							pedido = (TransProd) entidad;
							if(pedido.CFVTipo == 2 || (pedido.CFVTipo == 1 && !"1".equals(pedido.ClientePagoId)))
							{
								if(existenAbonos)
									throw new ControlError("E0762");
								break;
							}
						}
						if("1".equals("Preliquidacion"))
						{
							boolean contadoEfectivo = true;
							for(Entidad entidad : pedidosFacturados){
								pedido = (TransProd) entidad;
								if(pedido.CFVTipo != 1 || !"1".equals(pedido.ClientePagoId))
								{
									contadoEfectivo = false;
									break;
								}
							}
							if(contadoEfectivo)
							{
								ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
								float monto = mObtenerPreliquidacion.moveToNext() ? mObtenerPreliquidacion.getFloat(2) : -1;
								mObtenerPreliquidacion.close();
								if (monto != -1 && facturaSeleccionada.Total > monto)
								{
									throw new ControlError("E0590");
								}
								
							}
						}
					}
				}
				cancelar = true;
			default: consultarFactura();
		}
	}
	
	public boolean isCancelar()
	{
		return cancelar;
	}
	
	/**
	 * Una vez se valida la acción de cancelar, en este metodo se procede a
	 * realizar las operaciones de actualizacion, para modificar el estado a
	 * cancelado.
	 */
	private void consultarFactura() throws Exception
	{
		mVista.setSoloLectura(true);
		factura = new TransProd();
		factura.TransProdID = facturaSeleccionada.TransProdId;
		BDVend.recuperar(factura);
		datoFiscal = new TRPDatoFiscal();
		datoFiscal.TransProdID = factura.TransProdID;
		BDVend.recuperar(datoFiscal);
		
		mVista.cargarDetalleFactura(
				factura, datoFiscal);
	}
	
	/**
	 * Muestra los detalles de la factura seleccionada
	 */
	public void cancelarFactura()
	{
		Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
		factura.TipoFase = 0;
		factura.FechaCancelacion = factura.MFechaHora = Generales.getFechaHoraActual();
		factura.Enviado = false;
		factura.MUsuarioID = usuario.USUId;
		try
		{
			BDVend.guardarInsertar(factura);
			pedidosFacturados = (List<TransProd>) mVista.getPedidosDeFactura();
			boolean pagoAutomatico = true;
			/* Actualizar los pedidos */
			for(TransProd tpPedido:pedidosFacturados)
			{
				BDVend.recuperar(tpPedido);
				tpPedido.TipoFase = 2;
				tpPedido.FacturaID = "";
				tpPedido.FechaFacturacion = null;
				tpPedido.Enviado = false;
				tpPedido.MFechaHora = Generales.getFechaHoraActual();
				tpPedido.MUsuarioID = usuario.USUId;
				BDVend.guardarInsertar(tpPedido);
				if(pagoAutomatico) 
					pagoAutomatico = tpPedido.CFVTipo == 1 && Integer.parseInt(tpPedido.ClientePagoId) == Enumeradores.FormasDePago.EFECTIVO;
			}
			/* Verificar Tipo Cobranza */
			CONHist conHist = (CONHist) Sesion.get(Campo.CONHist);
			if("0".equals(conHist.get("TipoCobranza")) || ("2".equals(conHist.get("TipoCobranza")) && cliente.TipoFiscal == 2))
			{
				if(!Clientes.actualizarSaldoCteActual(factura.Total*-1))
				{
					throw new Exception("Error al actualizar el saldo al cliente");
				}
				if(pagoAutomatico && "1".equals(conHist.get("PagoAutomatico")))
				{
					aplicarPagoAutomatico(factura, true);
					if("1".equals(conHist.get("Preliquidacion")))
					{
						ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();
						PreLiquidacion mPreLiquidacion = new PreLiquidacion();
						if (mObtenerPreliquidacion.getCount() > 0)
						{
							mObtenerPreliquidacion.moveToFirst();
							String PLIId = mObtenerPreliquidacion.getString(0);
							mPreLiquidacion.PLIId = PLIId;
							BDVend.recuperar(mPreLiquidacion);
							mPreLiquidacion.MontoTotal = mObtenerPreliquidacion.getFloat(2) - factura.Total;
							if(mPreLiquidacion.MontoTotal == 0){
								BDVend.eliminar(mPreLiquidacion);
							}else
								BDVend.guardarInsertar(mPreLiquidacion);
						}
						factura.PLIId = "";
						BDVend.guardarInsertar(factura);
					}
				}
			}
			BDVend.commit();
		}catch(Exception ex)
		{
			ex.printStackTrace();
			try{
				BDVend.rollback();
			}catch(Exception e){
				Log.e("CANCELAR_FACTURA_RLLBCK", e.getMessage());
			}
			mVista.mostrarError(ex.getMessage());
		}
	}

	/**
	 * Agrega el adapter correspondiente al spinner recibido.
	 * 
	 * @param spinner
	 *        Spinner widget que se desea inicializar
	 * @param subEmpresaId
	 *        parametro opcional para el caso de inicializar el spinner folios
	 *        fiscales.
	 */
	public void initSpinner(Spinner spinner, String... subEmpresaId)
	{
		try
		{
			SpinnerAdapter adapter;
			switch (spinner.getId())
			{
				case R.id.spnSubEmpresa:
					adapter = new ArrayAdapter<SEMHist>((Vista) mVista, android.R.layout.simple_spinner_item, Consultas.ConsultasSEMHist.obtenerSubEmpresasPuedanEmitirFacturas());
					spinner.setAdapter(adapter);
					if (spinner.getOnItemSelectedListener() == null)
					{
						spinner.setOnItemSelectedListener(mVista.getListenerSpinners());
					}
					break;
				case R.id.spnFormaPago:
					Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
					BDVend.recuperar(cliente, CLIFormaVenta.class);
					List<CLIFormaVenta> formasDeVenta = new ArrayList<CLIFormaVenta>();
					for (CLIFormaVenta formaVenta : cliente.CLIFormaVenta)
					{
						if (formaVenta.Estado == 1)
						{
							formaVenta.setDescripcion(ValoresReferencia.getDescripcion("FVENTA", String.valueOf(formaVenta.CFVTipo)));
							formasDeVenta.add(formaVenta);
						}
					}
					adapter = new ArrayAdapter<CLIFormaVenta>((Vista) mVista, android.R.layout.simple_spinner_item, formasDeVenta);
					spinner.setAdapter(adapter);
					break;
				default:
					adapter = new ArrayAdapter<FolioFiscal>((Vista) mVista, android.R.layout.simple_spinner_item, FoliosFiscales.obtenerFolioFiscal(subEmpresaId[0]));
					spinner.setAdapter(adapter);
					if (spinner.getOnItemSelectedListener() == null)
					{
						spinner.setOnItemSelectedListener(mVista.getListenerSpinners());
					}
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}
	
	public List<Map<String, String>> generarDocsAImprimir()
	{
		//String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");

		//ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(lstTrpTipo, Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()), ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave, ((Visita) Sesion.get(Campo.VisitaActual)).DiaClave, aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir("'"+factura.TransProdID+"'");
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
			registro.put("TipoRecibo", "8");
			tabla.add(registro);
		}

		datos.close();

		return tabla;
	}
	
	public void imprimirTicket() throws ControlError, Exception
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

	public void cargaPedidos(boolean soloLectura)
	{
		List<Entidad> pedidos = null;
		try
		{
			pedidos = soloLectura ? Consultas.ConsultasTransProd.obtenerPedidosDeFactura(factura.TransProdID) : 
				
				Consultas.ConsultasTransProd.obtenerPedidosPorFacturar(
					(Visita) Sesion.get(Campo.VisitaActual),
					(Dia) Sesion.get(Campo.DiaActual),
					(Cliente) Sesion.get(Campo.ClienteActual),
					mVista.getFormaDeVentaSeleccionada(),
					mVista.getSubEmpresaSeleccionada().SubEmpresaId);
			
			mVista.initAdapterView(((SeleccionFacturacion) mVista).new AdapterGenerico(R.layout.lista_pedidos_facturacion, pedidos), R.id.lstPedidos);
		}
		catch (Exception e)
		{
			Log.e(TAG, "Error", e);
			mVista.mostrarError(e.getMessage());
		}
	}

	private static String remplazaComilla(String cadena)
	{
		return cadena == null ? "" : cadena.replace("'", "''");
	}

	public static final class TransProdFactura
	{
		public String TransProdId;
		public String SubEmpresaID;
		public String NombreCorto;
		public String Folio;
		public int Tipo;
		public int TipoFase;
		public String Fase;
		public Date FechaCaptura;
		public boolean Enviado;
		public float Total;
	}

	private Comparator<TransProd> comparador = new Comparator<TransProd>()
	{

		@Override
		public int compare(TransProd lhs, TransProd rhs)
		{
			if (lhs.FechaCobranza == null && rhs.FechaCobranza == null)
				return 0;
			else if (lhs.FechaCobranza == null)
				return 1;
			else if (rhs.FechaCobranza == null)
				return -1;
			return lhs.FechaCobranza.compareTo(rhs.FechaCobranza);
		}
	};

}
