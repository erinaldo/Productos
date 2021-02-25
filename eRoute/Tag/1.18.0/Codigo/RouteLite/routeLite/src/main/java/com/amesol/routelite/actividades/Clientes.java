package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import java.util.Map;

import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.CFVHist;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.CenCli;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ClienteEsquema;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.basedatos.SetDatos;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.*;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.utilerias.ServicesCentral.TiposEsquemas;

public class Clientes
{

	public static List<Map<String, String>> generarListaInfo(Cliente oCliente)
	{
		try
		{

			List<Map<String, String>> lista = new ArrayList<Map<String, String>>();
			Map<String, String> m;

			m = new HashMap<String, String>();
			m.put("descripcion", "Clave");
			m.put("valor", oCliente.Clave);
			lista.add(m);

			m = new HashMap<String, String>();
			m.put("descripcion", "Razón Social");
			m.put("valor", oCliente.RazonSocial);
			lista.add(m);

			m = new HashMap<String, String>();
			m.put("descripcion", "Contacto");
			m.put("valor", oCliente.NombreContacto);
			lista.add(m);

			String domPuntoEnt = null;
			String domFiscal = null;

			ListIterator<ClienteDomicilio> domicilios = oCliente.ClienteDomicilio.listIterator();
			while (domicilios.hasNext())
			{
				ClienteDomicilio domicilio = domicilios.next();
				if (domicilio.Tipo == 2)
					domPuntoEnt = domicilio.Calle + (domicilio.Numero == null ? "" : " " + domicilio.Numero) + (domicilio.NumInt == null ? "" : " " + domicilio.NumInt) + ", " + domicilio.Localidad + (domicilio.Poblacion == null ? "" : (domicilio.Localidad.equals(domicilio.Poblacion) ? "" : ", " + domicilio.Poblacion));
					//domPuntoEnt = domicilio.Calle + " " + domicilio.Numero + " " + domicilio.NumInt + " " + domicilio.Localidad;

				if (domicilio.Tipo == 1)
					domFiscal = domicilio.Calle + (domicilio.Numero == null ? "" : " " + domicilio.Numero) + (domicilio.NumInt == null ? "" : " " + domicilio.NumInt) + ", " + domicilio.Localidad + (domicilio.Poblacion == null ? "" : (domicilio.Localidad.equals(domicilio.Poblacion) ? "" : ", " + domicilio.Poblacion));
					//domFiscal = domicilio.Calle + " " + domicilio.Numero + " " + domicilio.NumInt + " " + domicilio.Localidad;
			}

			m = new HashMap<String, String>();
			m.put("descripcion", "Domicilio de Entrega");
			m.put("valor", domPuntoEnt);
			lista.add(m);

			m = new HashMap<String, String>();
			m.put("descripcion", "Domicilio Fiscal");
			m.put("valor", domFiscal);
			lista.add(m);

			m = new HashMap<String, String>();
			m.put("descripcion", "Nombre Corto");
			m.put("valor", oCliente.NombreCorto);
			lista.add(m);

			ISetDatos datos = Consultas.ConsultasCliFormaVenta.obtenerFormaVenta(oCliente.ClienteClave, Enumeradores.FormasDeVenta.CREDITO);
			Double limite = 0d;
			if(datos.moveToFirst())
				limite = datos.getDouble("LimiteCredito");

			m = new HashMap<String, String>();
			m.put("descripcion", "Limite de Crédito");
			m.put("valor", "$ " + Generales.getFormatoDecimal(limite, "#,##0.00"));
			lista.add(m);

			return lista;
		}
		catch (Exception e)
		{
			return null;
		}
	}

	public static void crearNuevo()
	{
		try
		{
			Cliente oCliente;
			ClienteEsquema oCteEsquema;
			ClienteDomicilio oCteDomicilio;
			CLIFormaVenta oCLIFormaVenta;
			CFVHist oCFVHist;
			CenCli oCenCli;

			Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);

			// Datos generales
			oCliente = new Cliente();
			oCliente.ClienteClave = KeyGen.getId();
			oCliente.Clave = Consultas.ConsultasCliente.obtenerClaveClienteNuevo();
			oCliente.IdElectronico = null;
			oCliente.IdFiscal = null;
			oCliente.RazonSocial = "";
			oCliente.TipoFiscal = 1;
			oCliente.TipoImpuesto = 1;
			oCliente.NombreContacto = null;
			oCliente.TelefonoContacto = null;
			oCliente.FechaRegistroSistema = Generales.getFechaHoraActual();
			oCliente.FechaNacimiento = null;
			oCliente.NombreCorto = null;
			oCliente.TipoEstado = 1;
			oCliente.Prestamo = false;
			oCliente.Exclusividad = false;
			oCliente.ActualizaSaldoCheque = false;
			oCliente.VencimientoVenta = false;
			oCliente.FechaFactura = null;
			oCliente.DesgloseImpuesto = false;
			oCliente.ExigirOrdenCompra = false;
			oCliente.SaldoEfectivo = 0;
			oCliente.MFechaHora = Generales.getFechaHoraActual();
			oCliente.MUsuarioID = usuario.Clave;
			oCliente.Enviado = false;

			// Esquema de clientes nuevos
			oCteEsquema = new ClienteEsquema();
			oCteEsquema.ClienteClave = oCliente.ClienteClave;
			oCteEsquema.EsquemaId = Consultas.ConsultasEsquema.obtenerIdEsquemaCteNuevo();
			oCteEsquema.Baja = false;
			oCteEsquema.Enviado = false;
			oCteEsquema.MFechaHora = Generales.getFechaHoraActual();
			oCteEsquema.MUsuarioID = usuario.Clave;
			oCliente.ClienteEsquema.add(oCteEsquema);

			// Punto de Entrega
			oCteDomicilio = new ClienteDomicilio();
			oCteDomicilio.ClienteClave = oCliente.ClienteClave;
			oCteDomicilio.ClienteDomicilioId = KeyGen.getId();
			oCteDomicilio.Tipo = 2;
			oCteDomicilio.Calle = null;
			oCteDomicilio.Numero = null;
			oCteDomicilio.NumInt = null;
			oCteDomicilio.CodigoPostal = null;
			oCteDomicilio.ReferenciaDom = null;
			oCteDomicilio.Colonia = null;
			oCteDomicilio.Localidad = null;
			oCteDomicilio.Poblacion = "";
			oCteDomicilio.Entidad = null;
			oCteDomicilio.Pais = "";
			oCteDomicilio.Enviado = false;
			oCteDomicilio.MFechaHora = Generales.getFechaHoraActual();
			oCteDomicilio.MUsuarioID = usuario.Clave;
			oCliente.ClienteDomicilio.add(oCteDomicilio);

			// Forma de venta Efectivo
			oCLIFormaVenta = new CLIFormaVenta();
			oCLIFormaVenta.ClienteClave = oCliente.ClienteClave;
			oCLIFormaVenta.CFVTipo = 1;
			oCLIFormaVenta.LimiteCredito = 0;
			oCLIFormaVenta.DiasCredito = 0; // Revisar con Nancy (Requerido en
											// CFVHist)
			oCLIFormaVenta.Inicial = true;
			oCLIFormaVenta.CapturaDias = false; // Revisar con Nancy (Requerido
												// en CFVHist)
			oCLIFormaVenta.ValidaLimite = false; // Revisar con Nancy
			oCLIFormaVenta.ValidaPago = false; // Revisar con Nancy
			oCLIFormaVenta.Estado = 1;
			oCLIFormaVenta.Enviado = false;
			oCLIFormaVenta.MFechaHora = Generales.getFechaHoraActual();
			oCLIFormaVenta.MUsuarioID = usuario.Clave;

			// Historico de forma de venta
			oCFVHist = new CFVHist();
			oCFVHist.ClienteClave = oCliente.ClienteClave;
			oCFVHist.CFVTipo = 1;
			oCFVHist.CFHFechaInicio = Generales.getFechaHoraActual();
			oCFVHist.LimiteCredito = 0;
			oCFVHist.DiasCredito = 0; // Revisar con Nancy
			oCFVHist.CapturaDias = false; // Revisar con Nancy
			oCFVHist.ValidaLimite = false; // Revisar con Nancy (Requerido en
											// CFVHist)
			oCFVHist.ValidaPago = false; // Revisar con Nancy (Requerido en
											// CFVHist)
			oCFVHist.Enviado = false;
			oCFVHist.MFechaHora = Generales.getFechaHoraActual();
			oCFVHist.MUsuarioID = usuario.Clave;
			oCLIFormaVenta.CFVHist.add(oCFVHist);

			oCliente.CLIFormaVenta.add(oCLIFormaVenta);

			ISetDatos dtEncuestas = Consultas.ConsultasEncuesta.obtenerEncuestasCteNuevo();
			while (dtEncuestas.moveToNext())
			{
				oCenCli = new CenCli();
				oCenCli.CENClave = dtEncuestas.getString(0);
				oCenCli.ClienteClave = oCliente.ClienteClave;
				oCenCli.Puntos = dtEncuestas.getShort(1);
				oCenCli.IniAplicacion = dtEncuestas.getDate(2);
				oCenCli.FinAplicacion = dtEncuestas.getDate(3);
				oCenCli.Enviado = false;
				oCenCli.MFechaHora = Generales.getFechaHoraActual();
				oCenCli.MUsuarioID = usuario.Clave;
				oCliente.CenCli.add(oCenCli);
			}
			dtEncuestas.close();

			BDVend.guardarInsertar(oCliente);
			BDVend.commit();

		}
		catch (Exception e)
		{
			e.printStackTrace();
			try
			{
				BDVend.rollback();
			}
			catch (Exception ex)
			{
				e.printStackTrace();
			}
		}
	}

	public static boolean validarLimiteCredito(Cliente cliente, Abono abono) throws Exception
	{
		boolean valido = true;
		ISetDatos dsCFV = Consultas.ConsultasCliFormaVenta.obtenerFormaVenta(cliente.ClienteClave, 2);
		if (dsCFV.getCount() > 0)
		{
			dsCFV.moveToFirst();
			if (dsCFV.getBoolean("ValidaLimite"))
			{
				Float limiteCredito = dsCFV.getFloat("LimiteCredito");

				if ((abono.Total + cliente.SaldoEfectivo) > limiteCredito)
					valido = false;
			}
		}

		dsCFV.close();
		return valido;
	}

	public static boolean validarVencimientoVenta(Cliente cliente, Abono abono) throws Exception
	{
		boolean valido = true;
		if (cliente.VencimientoVenta)
		{
			Iterator<AbnTrp> docsAbono = abono.AbnTrp.iterator();
			// the short in CONHist
			// (short) Integer.parseInt((String) ((CONHist)Sesion.get(Campo.CONHist)).get("TipoCobranza"))			

			ISetDatos dsDocsVenc = Consultas.ConsultasTransProd.obtenerVentasVencidas(cliente.ClienteClave, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));
			if (dsDocsVenc.getCount() > 0)
			{
				while (dsDocsVenc.moveToNext() && valido)
				{
					while (docsAbono.hasNext())
					{
						if (dsDocsVenc.getString("TransProdID").equals(docsAbono.next().TransProdID))
						{
							valido = false;
							break;
						}
					}
				}
			}

			dsDocsVenc.close();

			if (valido)
				valido = Consultas.ConsultasTransProd.existenVentasPosteriores(cliente.ClienteClave, abono.ABNId, (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")));
		}
		return valido;
	}

	public static boolean actualizarSaldoCteActual(float importe)
	{
		try
		{
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);
			Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);

			cliente.SaldoEfectivo = Generales.getRound(cliente.SaldoEfectivo + importe, 2);
			cliente.MFechaHora = Generales.getFechaHoraActual();
			cliente.MUsuarioID = usuario.Clave;
			cliente.Enviado = false;

			BDVend.guardarInsertar(cliente);
            ((Cliente)Sesion.get(Campo.ClienteActual)).SaldoEfectivo = cliente.SaldoEfectivo;
			return true;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return false;
		}
	}

	public static ArrayList<String> recuperarEsquemasPPE(String clienteClave)
	{
		ArrayList<String> aEsquemasPPE = new ArrayList<String>();
		try
		{
			ISetDatos dtEsquemasCLI = Consultas.ConsultasClienteEsquema.obtenerIdEsquemaCte(clienteClave);

			ISetDatos dtEsquemas = Consultas.ConsultasEsquema.obtenerEsquemasConPadre(TiposEsquemas.Clientes);
			Hashtable<String, String> aEsquemas = new Hashtable<String, String>();
			while (dtEsquemas.moveToNext())
			{
				aEsquemas.put(dtEsquemas.getString("EsquemaId"), (dtEsquemas.getString("EsquemaIdPadre") == null ? "" : dtEsquemas.getString("EsquemaIdPadre")));
			}
			if (aEsquemas.isEmpty())
			{
				dtEsquemas.close();
				dtEsquemasCLI.close();
				return aEsquemasPPE;
			}

			ISetDatos dtEsquemasPRI = Consultas.ConsultasProductoEsquema.obtenerIdEsquemaProductoPri();
			ArrayList<String> aEsquemasPRI = new ArrayList<String>();
			while (dtEsquemasPRI.moveToNext())
			{
				aEsquemasPRI.add(dtEsquemasPRI.getString("EsquemaId"));
			}
			if (aEsquemasPRI.isEmpty())
			{
				dtEsquemas.close();
				dtEsquemasCLI.close();
				dtEsquemasPRI.close();
				return aEsquemasPPE;
			}

			String sEsquemaId;
			while (dtEsquemasCLI.moveToNext())
			{
				sEsquemaId = dtEsquemasCLI.getString("EsquemaId");
				if (aEsquemasPRI.contains(sEsquemaId))
				{
					aEsquemasPPE.add("'" + sEsquemaId + "'");
				}
				else
				{
					recuperarEsquemasPadrePPE(aEsquemas, aEsquemasPRI, sEsquemaId, aEsquemasPPE);
				}
			}
			dtEsquemas.close();
			dtEsquemasCLI.close();
			dtEsquemasPRI.close();

			return aEsquemasPPE;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return aEsquemasPPE;
		}
	}

	public static void recuperarEsquemasPadrePPE(Hashtable<String, String> aEsquemas, ArrayList<String> aEsquemasPRI, String sEsquemaId, ArrayList<String> aEsquemasPPE)
	{
		try
		{
			if (sEsquemaId == "")
				return;

			String sEsquemaIdPadre = "";
			if (aEsquemas.containsKey(sEsquemaId))
			{
				sEsquemaIdPadre = aEsquemas.get(sEsquemaId);
				if (aEsquemasPRI.contains(sEsquemaIdPadre))
				{
					aEsquemasPPE.add("'" + sEsquemaIdPadre + "'");
				}
				else
				{
					recuperarEsquemasPadrePPE(aEsquemas, aEsquemasPRI, sEsquemaIdPadre, aEsquemasPPE);
				}
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

}
