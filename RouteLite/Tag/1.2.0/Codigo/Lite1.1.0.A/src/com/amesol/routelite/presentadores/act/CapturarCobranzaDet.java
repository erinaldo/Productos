package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Cobranza.VistaDetalle;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.IElementoCobranzaDet;
import com.amesol.routelite.presentadores.parcelables.DatosAbnDetalle;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.CapturaCobranzaDet;

public class CapturarCobranzaDet extends Presentador
{

	ICapturaCobranzaDet mVista;
	// IElementoCobranzaDet mVistaDet;
	String mAccion;
	Cobranza.VistaCobranza oVistaAbono;
	ArrayList<Cobranza.VistaDetalle> oVistaDetalles;
	Cobranza.VistaDetalle[] oDetalles;
	ArrayList<String> aTransProdIds;
	Abono oAbono;
	float saldoInicial;
	// float saldoResto;
	float totalAbono;
	ArrayList<Integer> tiposCP;
	LinkedList<Cobranza.VistaSpinner> oPagos;
	LinkedList<Cobranza.VistaSpinner> oMonedas;
	LinkedList<Cobranza.VistaSpinner> oBancos;
	short trueType;
	String Folio;

	// int nABDId;

	public CapturarCobranzaDet(CapturaCobranzaDet capturaCobranzaDet, String accion)
	{
		mVista = capturaCobranzaDet;
		mAccion = accion;
	}

	public void setFolio(String folio)
	{
		Folio = folio;
	}

	public void setAbono(Cobranza.VistaCobranza abono)
	{
		oVistaAbono = abono;
	}

	public void setTransProdIds(ArrayList<String> transprodids)
	{
		aTransProdIds = transprodids;
	}

	@Override
	public void iniciar()
	{
		try
		{

			if (mAccion.equals(Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA))
			{
				ArrayList<Cobranza.VistaDetalle> oDetalles = Consultas.ConsultasAbono.obtenerDetallesEnCobranza(oVistaAbono.getABNId());
				mVista.mostrarCobranzaDet(oVistaAbono, oDetalles);
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
			{
				generarCobranza();
			}

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void generarCobranza() throws Exception
	{
		/*
		 * String sModuloMovDetalleClave =
		 * (String)Sesion.get(Campo.ModuloMovDetalleClave); ModuloMovDetalle
		 * moduloMovDetalle = new ModuloMovDetalle();
		 * moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
		 * BDVend.recuperar(moduloMovDetalle);
		 */

		oAbono = Cobranza.generarCobranza();
		saldoInicial = Consultas.ConsultasAbono.obtenerSaldoDocumentos(aTransProdIds);
		// saldoResto = saldoInicial;

		tiposCP = new ArrayList<Integer>();
		ValorReferencia[] valoresCP = ValoresReferencia.getValores("PAGO", "CP");
		for (int i = 0; i < valoresCP.length; i++)
			tiposCP.add(Integer.parseInt(valoresCP[i].getVavclave()));

		String valoresPago = "";
		String valoresBanco = "";

		obtenerFormasPagoConfiguradas(valoresPago, valoresBanco);

		ISetDatos valores;
		if (valoresPago.length() > 0)
			valores = Consultas.ConsultasValorReferencia.obtenerValores("PAGO", valoresPago);
		else
			valores = Consultas.ConsultasValorReferencia.obtenerValoresExcepcion("PAGO", "0");

		oPagos = obtenerValores(valores);
		valores.close();

		oMonedas = obtenerMonedas();

		if (valoresBanco.length() > 0)
			valores = Consultas.ConsultasValorReferencia.obtenerValores("TBANCO", valoresBanco);
		else
			valores = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TBANCO");

		//		Sesion.set(Campo.Folio, Folio);
		oBancos = obtenerValores(valores);
		valores.close();
		mVista.capturarCobranzaDet(tiposCP);
		mVista.setFormasPago(oPagos);
		mVista.setMonedas(oMonedas);
		mVista.setBancos(oBancos);
		mVista.setFecha(oAbono.FechaAbono);
		mVista.setFolio(Folio);
		mVista.setSaldoIni(saldoInicial);
		mVista.setSaldoFin(saldoInicial);

		// nABDId = 0;
		// poblarListas();
	}

	private void obtenerFormasPagoConfiguradas(String valoresPago, String valoresBanco) throws Exception
	{
		valoresPago = "";
		valoresBanco = "";
		ISetDatos formaPago = Consultas.ConsultasClientePago.obtenerFormasPago(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
		if (formaPago.getCount() > 0)
		{ // si tiene formas de pago configuradas, cargar solo esas
			while (formaPago.moveToNext())
			{
				if (!formaPago.getString("Tipo").equals("0"))
				{
					valoresPago += formaPago.getString("Tipo") + ",";
					if (formaPago.getString("TipoBanco") != null)
						valoresBanco += formaPago.getString("TipoBanco") + ",";
				}
			}

			if (valoresPago.length() > 1)
				valoresPago = valoresPago.substring(0, valoresPago.length() - 1);

			if (valoresBanco.length() > 1)
				valoresBanco = valoresBanco.substring(0, valoresBanco.length() - 1);
		}

		formaPago.close();
	}

	private LinkedList<Cobranza.VistaSpinner> obtenerMonedas() throws Exception
	{
		ISetDatos dsMonedas = Consultas.ConsultasMoneda.obtenerMonedas();
		LinkedList<Cobranza.VistaSpinner> monedas = new LinkedList<Cobranza.VistaSpinner>();
		String sNombre = "";
		String sCodigo = "";

		if (dsMonedas.getCount() > 0)
		{
			while (dsMonedas.moveToNext())
			{
				sCodigo = Consultas.ConsultasValorReferencia.obtenerDescripcion("CDGOMON", dsMonedas.getString("TipoCodigo"));
				sNombre = dsMonedas.getString("Nombre") + " " + sCodigo;
				monedas.add(new Cobranza.VistaSpinner(dsMonedas.getString("_id"), sNombre));
			}
		}

		dsMonedas.close();
		return monedas;
	}

	private LinkedList<Cobranza.VistaSpinner> obtenerValores(ISetDatos dsValores) throws Exception
	{
		LinkedList<Cobranza.VistaSpinner> valores = new LinkedList<Cobranza.VistaSpinner>();
		String sNombre = "";
		String sCodigo = "";

		if (dsValores.getCount() > 0)
		{
			while (dsValores.moveToNext())
			{
				valores.add(new Cobranza.VistaSpinner(dsValores.getString("_id"), dsValores.getString("Descripcion")));
			}
		}

		return valores;
	}

	public void guardarDetallePago(DatosAbnDetalle datosABD) throws Exception
	{
		int tipoPago = datosABD.getTipoPago();
		float importe = datosABD.getImporte();
		String monedaId = datosABD.getMonedaId();
		int tipoBanco = datosABD.getTipoBanco();
		String referencia = datosABD.getReferencia();
		Date fechaCheque = null;
		if (datosABD.getFechaCheque() != 0)
			fechaCheque = new Date(datosABD.getFechaCheque());

		if (importe <= 0)
			throw new Exception(Mensajes.get("I0246"));

		if (tipoPago != 1 && tipoBanco == 0)
			throw new Exception(Mensajes.get("I0245"));

		validarDetalleInexistenteErr(tipoPago, monedaId, tipoBanco, referencia);

		if (oVistaDetalles == null)
			oVistaDetalles = new ArrayList<Cobranza.VistaDetalle>();

		String pago = ValoresReferencia.getDescripcion("PAGO", Integer.toString(tipoPago));
		String moneda = Consultas.ConsultasMoneda.obtenerMonedaNombre(monedaId);
		String banco = ValoresReferencia.getDescripcion("TBANCO", Integer.toString(tipoBanco));

		// nABDId += 1; //KeyGen.getId()
		Cobranza.VistaDetalle oVistaDet = new Cobranza.VistaDetalle(KeyGen.getId(), tipoPago, pago, monedaId, moneda, importe, tipoBanco, banco, referencia, fechaCheque);
		oVistaDetalles.add(oVistaDet);

		// oDetalles = oVistaDetalles.toArray(new
		// Cobranza.VistaDetalle[oVistaDetalles.size()]);

		totalAbono += importe;
		totalAbono = Generales.getRound(totalAbono, 2);
		mVista.setSaldoFin(Generales.getRound(saldoInicial - totalAbono, 2));
		mVista.setTotal(totalAbono);
		mVista.actualizarListaDet(oVistaDetalles);

	}

	public void validarDetalleInexistenteErr(int tipoPago, String monedaId, int tipoBanco, String referencia) throws Exception
	{
		if (oVistaDetalles != null)
		{
			Iterator<Cobranza.VistaDetalle> itDet = oVistaDetalles.iterator();
			while (itDet.hasNext())
			{
				Cobranza.VistaDetalle det = itDet.next();
				if (tipoPago == det.getTipoPago() && monedaId.equals(det.getMonedaId()) && (tipoPago == 1 || (tipoBanco == det.getTipoBanco() && referencia.equals(det.getReferencia()))))
				{
					throw new Exception(Mensajes.get("I0247"));
				}
			}
		}
	}

	public boolean validarDetalleInexistente(int tipoPago, String monedaId, int tipoBanco, String referencia)
	{
		if (oVistaDetalles != null)
		{
			Iterator<Cobranza.VistaDetalle> itDet = oVistaDetalles.iterator();
			while (itDet.hasNext())
			{
				Cobranza.VistaDetalle det = itDet.next();
				if (tipoPago == det.getTipoPago() && monedaId.equals(det.getMonedaId()) && (tipoPago == 1 || (tipoBanco == det.getTipoBanco() && referencia.equals(det.getReferencia()))))
				{
					mVista.mostrarError(Mensajes.get("I0247"));
					return false;
				}
			}
		}
		return true;
	}

	public boolean validarImportePago(float importe)
	{
		if (importe <= 0)
		{
			mVista.mostrarError(Mensajes.get("I0246"));
			return false;
		}
		return true;
	}

	public boolean validarBancoPago(int tipoBanco)
	{
		if (tipoBanco == 0)
		{
			mVista.mostrarError(Mensajes.get("I0245"));
			return false;
		}
		return true;
	}

	public void eliminarDetallePago(float importe)
	{
		totalAbono -= importe;
		mVista.setSaldoFin(Generales.getRound(saldoInicial - totalAbono, 2));
		mVista.setTotal(totalAbono);
	}

	public void actualizarImporte(float importeInicial, float importeFinal)
	{
		totalAbono -= importeInicial;
		totalAbono += importeFinal;
		mVista.setSaldoFin(Generales.getRound(saldoInicial - totalAbono, 2));
		mVista.setTotal(totalAbono);
	}

	public boolean guardarAbono()
	{
		try
		{
			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
			else
				trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

			if (oVistaDetalles == null || oVistaDetalles.toArray().length == 0)
			{
				mVista.mostrarError(Mensajes.get("E0053"));
				return false;
			}

			Iterator<Cobranza.VistaDetalle> itDet = oVistaDetalles.iterator();
			while (itDet.hasNext())
			{
				VistaDetalle det = itDet.next();
				if (!validarImportePago(det.getImporte()))
					return false;
				if (det.getTipoPago() != 1)
					if (!validarBancoPago(det.getTipoBanco()))
						return false;

				if (!((CONHist) Sesion.get(Campo.CONHist)).get("ExcederAbono").equals("1"))
				{
					if (totalAbono > saldoInicial)
					{
						mVista.mostrarError(Mensajes.get("E0038"));
						return false;
					}
				}
				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SaldarVentasCobranza").equals("1") && aTransProdIds.toArray().length > 1)
				{
					if (totalAbono < saldoInicial)
					{
						mVista.mostrarError(Mensajes.get("E0790").replace("$0$", (trueType == 1 ? Mensajes.get("XVenta") : Mensajes.get("XFactura"))));
						return false;
					}
				}

				Cobranza.guardarCobranza(oAbono, Folio, aTransProdIds, det);
				
				if (((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion").equals("1"))
				{
					ISetDatos mObtenerPreliquidacion = Consultas.ConsultaPreLiquidacion.obtenerPreLiquidacion();

					if (mObtenerPreliquidacion.getCount() == 0)
					{
						PreLiquidacion mPreLiquidacion = new PreLiquidacion();
						mPreLiquidacion.MontoTotal = Consultas.ConsultasTransProd.obtenerEfectivo(oAbono);
						mPreLiquidacion.FechaPreLiquidacion = Generales.getFechaActual();
						mPreLiquidacion.PLIId = KeyGen.getId();
						mPreLiquidacion.Enviado = false;
						BDVend.guardarInsertar(mPreLiquidacion);

					}
					else
					{
						mObtenerPreliquidacion.moveToFirst();
						String PLIId = mObtenerPreliquidacion.getString(0);
						PreLiquidacion mPreLiquidacion = new PreLiquidacion();
						mPreLiquidacion.PLIId = PLIId;
						BDVend.recuperar(mPreLiquidacion);
						mPreLiquidacion.MontoTotal = mPreLiquidacion.MontoTotal + Consultas.ConsultasTransProd.obtenerEfectivo(oAbono);
						BDVend.guardarInsertar(mPreLiquidacion);
					}
				}

			}

			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return false;
		}
	}

	public boolean terminarCaptura()
	{
		if (mAccion.equals(Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA))
			return true;

		if (oVistaDetalles == null)
			return true;

		if (oVistaDetalles.toArray().length > 0)
		{
			mVista.mostrarPreguntaSiNo(Mensajes.get("BP0002"), 1);
			return false;
		}
		return true;

	}

	public void iniciarCapturaDetalle()
	{
		HashMap<String, Float> oParam = new HashMap<String, Float>();

		oParam.put("saldoInicial", saldoInicial);
		oParam.put("saldoResto", Generales.getRound(saldoInicial - totalAbono, 2));

		mVista.iniciarActividadConResultado(IElementoCobranzaDet.class, Enumeradores.Solicitudes.SOLICITUD_ABONO_DETALLE, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA, oParam);
	}

	public ICapturaCobranzaDet getIVista()
	{
		return mVista;
	}

	public boolean imprimir()
	{
		MOTConfiguracion motConfiguracion = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfiguracion.get("MensajeImpresion").equals("1"))
		{
			mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
			return true;
		}
		else
			return false;

	}

	public void imprimirTicket() throws Exception
	{
		Map<String, String> documento;
		List<Map<String, String>> documentos;

		Recibos recibos = new Recibos();
		documentos = new ArrayList<Map<String, String>>();

		documento = recibos.getDocumentoImpresion(oAbono.ABNId, String.valueOf(10), "TRECIBO", "ABN", oAbono.Folio, "", Generales.getFormatoFecha(oAbono.FechaAbono, "dd/MM/yyyy"), Generales.getFormatoDecimal(oAbono.Total, "$#,##0.00"), "0", ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, oAbono.DiaClave, "", "0");
		// Abono.ABNId as _Id, 10 as Tipo, 'TRECIBO' as VARCodigo, 'ABN' as
		// TipoRecibo, Abono.Folio as Folio ,'' as DescTipo, strftime(
		// '%d/%m/%Y',FechaAbono) as Fecha, Abono.Total as Total, null as
		// TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as
		// DiaClave, '' as SubEmpresaID , 0 as FacElec
		documentos.add(documento);

		recibos.imprimirRecibos(documentos, false, mVista);
	}

}
