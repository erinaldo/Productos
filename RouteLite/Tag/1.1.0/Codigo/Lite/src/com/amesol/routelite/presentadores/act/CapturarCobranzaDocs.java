package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;

import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.vistas.CapturaCobranzaDocs;

public class CapturarCobranzaDocs extends Presentador
{

	ICapturaCobranzaDocs mVista;
	String mAccion;
	String sABNId;
	ArrayList<String> aTransProdId;

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
				oDocumentos = Consultas.ConsultasAbono.obtenerDocumentosPorCobrar(cliente.ClienteClave, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));
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

}
