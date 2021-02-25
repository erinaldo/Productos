package com.amesol.routelite.presentadores.act;

import android.text.format.DateFormat;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Cobranza.VistaDetalle;
import com.amesol.routelite.actividades.EnvioPDF;
import com.amesol.routelite.actividades.Folios;
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
import com.amesol.routelite.datos.utilerias.ConfigParametro;
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
import com.amesol.routelite.vistas.CapturaCobranzaDet.vistaDesgloseProntoPago;

public class CapturarCobranzaDet extends Presentador
{

	ICapturaCobranzaDet mVista;
	// IElementoCobranzaDet mVistaDet;
	String mAccion;
	Cobranza.VistaCobranza oVistaAbono;
	ArrayList<Cobranza.VistaDetalle> oVistaDetalles;
	Cobranza.VistaDetalle[] oDetalles;
	ArrayList<String> aTransProdIds;
	HashMap<String,Float>hmImportexDoc;
	Abono oAbono;
	float saldoInicial;
    float descProntoPago;
	// float saldoResto;
	float totalAbono;
	ArrayList<Integer> tiposCP;
	LinkedList<Cobranza.VistaSpinner> oPagos;
	LinkedList<Cobranza.VistaSpinner> oMonedas;
	LinkedList<Cobranza.VistaSpinner> oBancos;
	short trueType;
	String Folio;
    boolean aplicarDescProntoPago;
    String sFolioAbonoGenerados="";
    ArrayList<String> abnIds;

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

	public void setImportesxDoc(HashMap<String,Float> hmImportes)
	{
		 hmImportexDoc = hmImportes;
	}


	public ArrayList<String> getTransProdIds(){
		return aTransProdIds;
	}

	public Float getTotalAbonos(){
		return totalAbono;
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
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA) || mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA_SIMPLE))
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

        aplicarDescProntoPago = false;
        descProntoPago = 0;

        if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarDescProntoPago"))
            aplicarDescProntoPago =  ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("AplicarDescProntoPago").toString().equals("1");
        if (aplicarDescProntoPago)
            descProntoPago = Consultas.ConsultasAbono.obtenerDescuentoProntoPago(aTransProdIds);

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

        if (aplicarDescProntoPago  && descProntoPago > 0) {
            mVista.mostrarDescuento();
            mVista.setSaldoDescIni(saldoInicial-descProntoPago);
            mVista.setSaldoDescFin(saldoInicial-descProntoPago);
        }

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
        String cuenta = datosABD.getCuenta();
		String referencia = datosABD.getReferencia();
        String observaciones = datosABD.getObservaciones();
		boolean pagoBillpocket = datosABD.getPagoBillpocket();
		Date fechaCheque = null;
		if (datosABD.getFechaCheque() != 0)
			fechaCheque = new Date(datosABD.getFechaCheque());

		if (importe <= 0)
			throw new Exception(Mensajes.get("I0246"));

		if (tipoPago != 1 && tipoBanco < 0)
			throw new Exception(Mensajes.get("I0245"));

		if (tipoPago != 1 && referencia.length() == 0)
			throw new Exception("La referencia es requerido para la forma de pago diferente a efectivo");
		String auxCuenta = Consultas.ConsultasClientePago.obtenerCuentaFormaPago(((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave, Integer.toString(tipoPago));
        if (Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) == Enumeradores.TiposModuloMovDetalle.COBRANZASIMPLE) {
            if (tipoPago != 1) {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MinimoCaracteresNumCuenta", String.valueOf(tipoPago)) && auxCuenta.length() == 0) {
                    int longitud = Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MinimoCaracteresNumCuenta", String.valueOf(tipoPago)).toString());
                    if (cuenta.length() < longitud)
                        throw new Exception(Mensajes.get("E1002").replace("$0$", Mensajes.get("XNoCuenta")).replace("$1$", String.valueOf(longitud)));
                }
            }
        }

		validarDetalleInexistenteErr(tipoPago, monedaId, tipoBanco, referencia); //AGREGAR CUENTA

		if (oVistaDetalles == null)
			oVistaDetalles = new ArrayList<Cobranza.VistaDetalle>();

		String pago = ValoresReferencia.getDescripcion("PAGO", Integer.toString(tipoPago));
		String moneda = Consultas.ConsultasMoneda.obtenerMonedaNombre(monedaId);
		String banco = ValoresReferencia.getDescripcion("TBANCO", Integer.toString(tipoBanco));

		// nABDId += 1; //KeyGen.getId()
		Cobranza.VistaDetalle oVistaDet = new Cobranza.VistaDetalle(KeyGen.getId(), tipoPago, pago, monedaId, moneda, importe, tipoBanco, banco, cuenta, referencia, fechaCheque, observaciones, pagoBillpocket);
		oVistaDetalles.add(oVistaDet);

		// oDetalles = oVistaDetalles.toArray(new
		// Cobranza.VistaDetalle[oVistaDetalles.size()]);

		totalAbono += importe;
		totalAbono = Generales.getRound(totalAbono, 2);
		mVista.setSaldoFin(Generales.getRound(saldoInicial - totalAbono, 2));
        if (aplicarDescProntoPago)
            mVista.setSaldoDescFin(Generales.getRound(saldoInicial - descProntoPago - totalAbono, 2));
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

	public boolean validarDetalleInexistente(int tipoPago, String monedaId, int tipoBanco, String referencia, String observaciones)
	{
		if (oVistaDetalles != null)
		{
			Iterator<Cobranza.VistaDetalle> itDet = oVistaDetalles.iterator();
			while (itDet.hasNext())
			{
				Cobranza.VistaDetalle det = itDet.next();
				if (tipoPago == det.getTipoPago() && monedaId.equals(det.getMonedaId()) && (tipoPago == 1 || (tipoBanco == det.getTipoBanco() && referencia.equals(det.getReferencia()))) && observaciones.equals(det.getObservaciones()))
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
		if (tipoBanco < 1)
		{
			mVista.mostrarError(Mensajes.get("I0245"));
			return false;
		}
		return true;
	}

    public boolean validarCuenta(int tipoPago, String cuenta){
        try {
            if (Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) == Enumeradores.TiposModuloMovDetalle.COBRANZASIMPLE) {
                if (tipoPago != 1) {
					String auxCuenta = Consultas.ConsultasClientePago.obtenerCuentaFormaPago(((Cliente)Sesion.get(Sesion.Campo.ClienteActual)).ClienteClave, Integer.toString(tipoPago));
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("MinimoCaracteresNumCuenta", String.valueOf(tipoPago)) && auxCuenta.length() == 0) {
                        int longitud = Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("MinimoCaracteresNumCuenta", String.valueOf(tipoPago)).toString());
                        if (cuenta.length() < longitud) {
                            mVista.mostrarError(Mensajes.get("E1002").replace("$0$", Mensajes.get("XNoCuenta")).replace("$1$", String.valueOf(longitud)));
                            return false;
                        }
                    }
                }
            }
            return true;
        }catch(Exception e){
            return true;
        }

    }

	public void eliminarDetallePago(float importe)
	{
		totalAbono -= importe;
		mVista.setSaldoFin(Generales.getRound(saldoInicial - totalAbono, 2));
        if (aplicarDescProntoPago)
            mVista.setSaldoDescFin(Generales.getRound(Generales.getRound(saldoInicial - descProntoPago, 2) - totalAbono, 2));
		mVista.setTotal(totalAbono);
	}

	public void actualizarImporte(float importeInicial, float importeFinal)
	{
		totalAbono -= importeInicial;
		totalAbono += importeFinal;
		mVista.setSaldoFin(Generales.getRound(saldoInicial - totalAbono, 2));
        if (aplicarDescProntoPago)
            mVista.setSaldoDescFin(Generales.getRound(Generales.getRound(saldoInicial - descProntoPago, 2) - totalAbono, 2));
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

            sFolioAbonoGenerados="";
            abnIds = new ArrayList<>();
			Iterator<Cobranza.VistaDetalle> itDet = oVistaDetalles.iterator();
			while (itDet.hasNext())
			{
				VistaDetalle det = itDet.next();

				if (!validarImportePago(det.getImporte()))
					return false;
				if (det.getTipoPago() != 1) {
                    if (!validarBancoPago(det.getTipoBanco()))
                        return false;
                    if (!validarCuenta(det.getTipoPago(), det.getCuenta()))
                        return false;
                }

				if (!((CONHist) Sesion.get(Campo.CONHist)).get("ExcederAbono").equals("1"))
				{
					if (totalAbono > Generales.getRound(saldoInicial - descProntoPago, 2))
					{
						mVista.mostrarError(Mensajes.get("E0038"));
						return false;
					}
				}
				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("SaldarVentasCobranza").equals("1") && aTransProdIds.toArray().length > 1)
				{
					if (totalAbono < Generales.getRound(saldoInicial - descProntoPago, 2))
					{
						mVista.mostrarError(Mensajes.get("E0790").replace("$0$", (trueType == 1 ? Mensajes.get("XVenta") : Mensajes.get("XFactura"))));
						return false;
					}
				}

                StringBuilder byRefError = new StringBuilder();
                Folio= Folios.Obtener((String) Sesion.get(Campo.ModuloMovDetalleClave), byRefError);
                sFolioAbonoGenerados += Folio + ", ";
				if (hmImportexDoc != null && hmImportexDoc.size() >0){
					Cobranza.guardarCobranza(oAbono, Folio, aTransProdIds, det, hmImportexDoc);
				}else{
					Cobranza.guardarCobranza(oAbono, Folio, aTransProdIds, det);
				}

                abnIds.add(oAbono.ABNId);

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
        if( aplicarDescProntoPago && descProntoPago > 0) {
            oParam.put("saldoInicialDesc", saldoInicial - descProntoPago);
            oParam.put("saldoRestoDesc", Generales.getRound(saldoInicial - descProntoPago - totalAbono, 2));
        }

		//mVista.iniciarActividadConResultado(IElementoCobranzaDet.class, Enumeradores.Solicitudes.SOLICITUD_ABONO_DETALLE, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA, oParam);
        mVista.iniciarActividadConResultado(IElementoCobranzaDet.class, Enumeradores.Solicitudes.SOLICITUD_ABONO_DETALLE, mAccion, oParam);
	}

	public ICapturaCobranzaDet getIVista()
	{
		return mVista;
	}

	public boolean imprimir()
	{
        sFolioAbonoGenerados = sFolioAbonoGenerados.substring(0,sFolioAbonoGenerados.length()-2);

		MOTConfiguracion motConfiguracion = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfiguracion.get("MensajeImpresion").equals("1"))
		{
			mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
            if (sFolioAbonoGenerados.split(",").length > 1){
                mVista.mostrarAdvertencia(Mensajes.get("I0322").replace("$0$", sFolioAbonoGenerados));
            }
			return true;
		}else if (motConfiguracion.get("MensajeImpresion").equals("2") || motConfiguracion.get("MensajeImpresion").equals("3")){
            if (sFolioAbonoGenerados.split(",").length > 1){
                mVista.mostrarToast(Mensajes.get("I0322").replace("$0$", sFolioAbonoGenerados));
            }
            mVista.imprimirPDF(Short.valueOf(motConfiguracion.get("MensajeImpresion").toString()));
            return true;
        }
		else
            if (sFolioAbonoGenerados.split(",").length > 1){
                mVista.mostrarToast(Mensajes.get("I0322").replace("$0$", sFolioAbonoGenerados));
            }
			return false;

	}

	public void imprimirTicket() throws Exception
	{

		List<Map<String, String>> documentos;

		Recibos recibos = new Recibos();
		documentos = new ArrayList<Map<String, String>>();

        //for (String sId : abnIds){
        Map<String, String> documento;
        documento = recibos.getDocumentoImpresion(oAbono.ABNId, String.valueOf(10), "TRECIBO", "ABN", oAbono.Folio, "", Generales.getFormatoFecha(oAbono.FechaAbono, "dd/MM/yyyy"), Generales.getFormatoDecimal(oAbono.Total, "$#,##0.00"), "0", ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, oAbono.DiaClave, "", "0");
        // Abono.ABNId as _Id, 10 as Tipo, 'TRECIBO' as VARCodigo, 'ABN' as
        // TipoRecibo, Abono.Folio as Folio ,'' as DescTipo, strftime(
        // '%d/%m/%Y',FechaAbono) as Fecha, Abono.Total as Total, null as
        // TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as
        // DiaClave, '' as SubEmpresaID , 0 as FacElec
        documentos.add(documento);
        //}

        short numImpresiones = 0;
        try {
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }
		recibos.imprimirRecibos(documentos, false, mVista, numImpresiones);
	}

    public ArrayList<vistaDesgloseProntoPago> obtenerDesgloseProntoPago() throws Exception
    {
        ISetDatos dsDocumentos = Consultas.ConsultasAbono.obtenerDetalleDescProntoPago(aTransProdIds);
        if (dsDocumentos.getCount() <= 0)
        {
            dsDocumentos.close();
            return null;
        }

        ArrayList<vistaDesgloseProntoPago> desgloseProntoPago = new ArrayList<vistaDesgloseProntoPago>();
        while (dsDocumentos.moveToNext())
        {
            desgloseProntoPago.add(new vistaDesgloseProntoPago(dsDocumentos.getString("Folio"),
                    Generales.getFormatoDecimal(dsDocumentos.getFloat("Total"), "$#,##0.00"),
                    Generales.getFormatoDecimal(dsDocumentos.getFloat("Saldo"), "$#,##0.00"),
                    DateFormat.format("dd/MM/yyyy", dsDocumentos.getDate("FechaCobranza")).toString(),
                    String.valueOf(dsDocumentos.getFloat("Porcentaje")) + "%",
                    Generales.getFormatoDecimal(dsDocumentos.getFloat("Importe"), "$#,##0.00"),
                    Generales.getFormatoDecimal(dsDocumentos.getFloat("Saldo") - dsDocumentos.getFloat("Importe"), "$#,##0.00")));

        }

        return desgloseProntoPago;

    }

}
