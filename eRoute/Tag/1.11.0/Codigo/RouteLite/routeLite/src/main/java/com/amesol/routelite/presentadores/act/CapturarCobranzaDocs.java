package com.amesol.routelite.presentadores.act;

import android.database.Cursor;
import android.support.annotation.NonNull;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import java.util.Map;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.CapturaCobranzaDocs;

public class CapturarCobranzaDocs extends Presentador
{

	ICapturaCobranzaDocs mVista;
	String mAccion;
	String sABNId;
	ArrayList<String> aTransProdId;
	List<Abono> abonosAsociados;

	public CapturarCobranzaDocs(CapturaCobranzaDocs capturaCobranzaDocs, String accion)
	{
		mVista = capturaCobranzaDocs;
		mAccion = accion;
	}

	public void setABNId(String abnid)
	{
		sABNId = abnid;
	}

	public String getABNId()
	{
		return sABNId;
	}

	public void insertTransProdId(String sTransProdId)
	{
		if (aTransProdId == null)
			aTransProdId = new ArrayList<String>();

		aTransProdId.add(sTransProdId);
	}

	public void removeTransProdId(String sTransProdId)
	{
		if (aTransProdId != null)
			if (aTransProdId.contains(sTransProdId))
				aTransProdId.remove(sTransProdId);
	}

	public ArrayList<String> getTransProdIds()
	{
		return aTransProdId;
	}

	@Override
	public void iniciar()
	{
		try
		{
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			mVista.setCliente(cliente.Clave + " - " + cliente.RazonSocial);
			mVista.setRuta(((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
			mVista.setDia(((Dia) Sesion.get(Campo.DiaActual)).DiaClave);

			Cobranza.VistaDocumentos[] oDocumentos;
			if (mAccion.equals(Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA))
			{
				oDocumentos = Consultas.ConsultasAbono.obtenerDocumentosEnCobranza(sABNId);
				mVista.mostrarCobranzaDocs(oDocumentos);
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
			{
				CONHist oConHist = (CONHist) Sesion.get(Campo.CONHist);
				oDocumentos = Consultas.ConsultasAbono.obtenerDocumentosPorCobrar(cliente.ClienteClave, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")), "Folio, Fecha");
				if (oDocumentos.length > 0)
					mVista.mostrarCobranzaDocs(oDocumentos);
				else
				{
					// Mistake = CobrarVentas
					short trueType;
					if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
						trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
					else
						trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));
					mVista.setResultado(Resultados.RESULTADO_MAL, Mensajes.get("E0558").replace("$0$", (trueType == 1 ? Mensajes.get("XVenta") : Mensajes.get("XFactura"))));
					mVista.finalizar();
				}
			}

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void asociarCobranza(List<Abono> seleccionados) throws Exception
	{
		abonosAsociados = new ArrayList<>();
		if (Cobranza.asociarAbonosDisponibles (seleccionados, getTransProdIds(),abonosAsociados)){
			mVista.mostrarError("Los abonos se asociaron exitosamente", 1);
			//Desea imprimir???
		}
	}

	public List<Abono> getAbonosAsociados(){
		return abonosAsociados;
	}
	public boolean imprimir()
	{
		MOTConfiguracion motConfiguracion = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfiguracion.get("MensajeImpresion").equals("1"))
		{
			mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 2);
			return true;
		}else if (motConfiguracion.get("MensajeImpresion").equals("2") || motConfiguracion.get("MensajeImpresion").equals("3")){
			mVista.imprimirPDF(Short.valueOf(motConfiguracion.get("MensajeImpresion").toString()));
			return true;
		}
		else
			return false;

	}

	public void imprimirTicket(List<Abono> aAbonos) throws Exception
	{
		Map<String, String> documento;
		List<Map<String, String>> documentos;

		Recibos recibos = new Recibos();

		documentos = new ArrayList<Map<String, String>>();

		for (Abono oAbono: aAbonos) {

			documento = recibos.getDocumentoImpresion(oAbono.ABNId, String.valueOf(10), "TRECIBO", "ABN", oAbono.Folio, "", Generales.getFormatoFecha(oAbono.FechaAbono, "dd/MM/yyyy"), Generales.getFormatoDecimal(oAbono.Total, "$#,##0.00"), "0", ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, oAbono.DiaClave, "", "0");
			// Abono.ABNId as _Id, 10 as Tipo, 'TRECIBO' as VARCodigo, 'ABN' as
			// TipoRecibo, Abono.Folio as Folio ,'' as DescTipo, strftime(
			// '%d/%m/%Y',FechaAbono) as Fecha, Abono.Total as Total, null as
			// TipoFase, Visita.ClienteClave as ClienteClave, Visita.DiaClave as
			// DiaClave, '' as SubEmpresaID , 0 as FacElec
			documentos.add(documento);
		}

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


}
