package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import android.R;
import android.text.method.DateTimeKeyListener;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.CFVHist;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.CenCli;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ClienteEsquema;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.INuevoCliente;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.utilerias.ParametroMSG;
import com.amesol.routelite.vistas.generico.DialogoAlerta;

public class CrearCliente extends Presentador
{

	INuevoCliente mVista;
	Cliente oCliente;
	ClienteEsquema oCteEsquema;
	ClienteDomicilio oCteDomicilio;
	CLIFormaVenta oCLIFormaVenta;
	CFVHist oCFVHist;
	CenCli oCenCli;
	String clave;
	boolean bErrPuntoEntrega = true;

	public CrearCliente(INuevoCliente vista)
	{
		mVista = vista;
	}

	public boolean getErrPuntoEntrega()
	{
		return bErrPuntoEntrega;
	}

	@Override
	public void iniciar()
	{
		// clave = Consultas.ConsultasCliente.obtenerClaveClienteNuevo();
		try
		{
			String stepClave1 = Generales.getFechaActualStr();
			String stepClave2 = stepClave1.substring(stepClave1.length() - 2, stepClave1.length()) + stepClave1.substring(3, 5);
			// short qqwee = (short)
			// Consultas.ConsultasTransProd.getTipoFiscalCliente();
			clave = stepClave2 + Short.toString((short) (Consultas.ConsultasRuta.getFolioClteNvo() + 1));
		}
		catch (Exception e1)
		{
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}

		// setNewFolioClienteNvo()
		mVista.setClave(clave);
	}

	public void GuardarCliente() throws ControlError
	{
		// try{
		Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		Date fechaActual = Generales.getFechaActual();

		// Datos generales
		oCliente = new Cliente();
		oCliente.ClienteClave = KeyGen.getId();
		oCliente.Clave = clave;
		oCliente.IdElectronico = mVista.getCodigoBarras();
		oCliente.IdFiscal = mVista.getRFC();
		oCliente.RazonSocial = mVista.getRazonSocial();
		oCliente.TipoFiscal = 1;
		oCliente.TipoImpuesto = 1;
		oCliente.NombreContacto = mVista.getContacto();
		oCliente.TelefonoContacto = mVista.getTelefono();
		oCliente.FechaRegistroSistema = mVista.getFechaRegistro();
		oCliente.FechaNacimiento = mVista.getFechaNacimiento();
		oCliente.NombreCorto = mVista.getNombre();
		oCliente.TipoEstado = 1;
		oCliente.Prestamo = mVista.getPrestamoEnvase();
		oCliente.Exclusividad = mVista.getExclusividad();
		oCliente.VigExclusividad = mVista.getVigExclusividad();
		oCliente.ActualizaSaldoCheque = false;
		oCliente.VencimientoVenta = false;
		oCliente.FechaFactura = fechaActual;
		oCliente.DesgloseImpuesto = mVista.getDesglosaImpuestos();
		oCliente.ExigirOrdenCompra = mVista.getExigirOrdenCompra();
		oCliente.MFechaHora = Generales.getFechaHoraActual();
		oCliente.MUsuarioID = usuario.Clave;
		oCliente.Enviado = false;
		oCliente.validar();

		// Esquema de clientes nuevos
		oCteEsquema = new ClienteEsquema();
		oCteEsquema.ClienteClave = oCliente.ClienteClave;
		oCteEsquema.EsquemaId = Consultas.ConsultasEsquema.obtenerIdEsquemaCteNuevo();
		oCteEsquema.Baja = false;
		oCteEsquema.Enviado = false;
		oCteEsquema.MFechaHora = Generales.getFechaHoraActual();
		oCteEsquema.MUsuarioID = usuario.Clave;
		oCliente.ClienteEsquema.add(oCteEsquema);
		oCteEsquema.validar();

		// Punto de Entrega
		if (mVista.getCapturoPuntoEntrega())
		{
			oCteDomicilio = new ClienteDomicilio();
			oCteDomicilio.ClienteClave = oCliente.ClienteClave;
			oCteDomicilio.ClienteDomicilioId = KeyGen.getId();
			oCteDomicilio.Tipo = 2;
			oCteDomicilio.Calle = mVista.getCallePE();
			oCteDomicilio.Numero = mVista.getNumeroExtPE();
			oCteDomicilio.NumInt = mVista.getNumeroIntPE();
			oCteDomicilio.CodigoPostal = mVista.getCodigoPostalPE();
			oCteDomicilio.ReferenciaDom = mVista.getReferenciaPE();
			oCteDomicilio.Colonia = mVista.getColoniaPE();
			oCteDomicilio.Localidad = mVista.getMunicipioPE();
			oCteDomicilio.Poblacion = mVista.getMunicipioPE();
			oCteDomicilio.Entidad = mVista.getEntidadPE();
			oCteDomicilio.Pais = mVista.getPaisPE();
			oCteDomicilio.Enviado = false;
			oCteDomicilio.MFechaHora = Generales.getFechaHoraActual();
			oCteDomicilio.MUsuarioID = usuario.Clave;
			oCliente.ClienteDomicilio.add(oCteDomicilio);
			bErrPuntoEntrega = true;
			oCteDomicilio.validar();
		}
		else
		{
			ArrayList<ParametroMSG> params = new ArrayList<ParametroMSG>();
			params.add(new ParametroMSG("XPuntoEntrega", true));
			throw new ControlError("E0018", params);
		}

		if (mVista.getCapturoDomFiscal())
		{
			// Domicilio Fiscal
			oCteDomicilio = new ClienteDomicilio();
			oCteDomicilio.ClienteClave = oCliente.ClienteClave;
			oCteDomicilio.ClienteDomicilioId = KeyGen.getId();
			oCteDomicilio.Tipo = 1;
			oCteDomicilio.Calle = mVista.getCalleDF();
			oCteDomicilio.Numero = mVista.getNumeroExtDF();
			oCteDomicilio.NumInt = mVista.getNumeroIntDF();
			oCteDomicilio.CodigoPostal = mVista.getCodigoPostalDF();
			oCteDomicilio.ReferenciaDom = mVista.getReferenciaDF();
			oCteDomicilio.Colonia = mVista.getColoniaDF();
			oCteDomicilio.Localidad = mVista.getMunicipioDF();
			oCteDomicilio.Poblacion = mVista.getMunicipioDF();
			oCteDomicilio.Entidad = mVista.getEntidadDF();
			oCteDomicilio.Pais = mVista.getPaisDF();
			oCteDomicilio.Enviado = false;
			oCteDomicilio.MFechaHora = Generales.getFechaHoraActual();
			oCteDomicilio.MUsuarioID = usuario.Clave;
			oCliente.ClienteDomicilio.add(oCteDomicilio);
			bErrPuntoEntrega = false;
			oCteDomicilio.RequeridosFiscal = oCliente.DesgloseImpuesto;
			oCteDomicilio.validar();
		}
		else if (oCliente.DesgloseImpuesto)
		{
			ArrayList<ParametroMSG> params = new ArrayList<ParametroMSG>();
			params.add(new ParametroMSG("XFiscal", true));
			throw new ControlError("E0018", params);
		}

		// Forma de venta Efectivo
		oCLIFormaVenta = new CLIFormaVenta();
		oCLIFormaVenta.ClienteClave = oCliente.ClienteClave;
		oCLIFormaVenta.CFVTipo = 1;
		oCLIFormaVenta.LimiteCredito = 0;
		oCLIFormaVenta.DiasCredito = 0;
		oCLIFormaVenta.Inicial = true;
		oCLIFormaVenta.CapturaDias = false;
		oCLIFormaVenta.ValidaLimite = false;
		oCLIFormaVenta.ValidaPago = false;
		oCLIFormaVenta.Estado = 1;
		oCLIFormaVenta.Enviado = false;
		oCLIFormaVenta.MFechaHora = Generales.getFechaHoraActual();
		oCLIFormaVenta.MUsuarioID = usuario.Clave;
		oCLIFormaVenta.validar();

		// Historico de forma de venta
		oCFVHist = new CFVHist();
		oCFVHist.ClienteClave = oCliente.ClienteClave;
		oCFVHist.CFVTipo = 1;
		oCFVHist.CFHFechaInicio = Generales.getFechaHoraActual();
		oCFVHist.LimiteCredito = 0;
		oCFVHist.DiasCredito = 0;
		oCFVHist.CapturaDias = false;
		oCFVHist.ValidaLimite = false;
		oCFVHist.ValidaPago = false;
		oCFVHist.Enviado = false;
		oCFVHist.MFechaHora = Generales.getFechaHoraActual();
		oCFVHist.MUsuarioID = usuario.Clave;
		oCFVHist.validar();

		oCLIFormaVenta.CFVHist.add(oCFVHist);
		oCliente.CLIFormaVenta.add(oCLIFormaVenta);

		ISetDatos dtEncuestas = null;
		try
		{
			dtEncuestas = Consultas.ConsultasEncuesta.obtenerEncuestasCteNuevo();
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
		if (dtEncuestas != null)
		{
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
				oCenCli.validar();
			}
			dtEncuestas.close();
		}

		try
		{
			BDVend.guardarInsertar(oCliente);
			BDVend.commit();
			Consultas.ConsultasRuta.setNewFolioClienteNvo(((Ruta) Sesion.get(Campo.RutaActual)).RUTClave, (short) (Consultas.ConsultasRuta.getFolioClteNvo() + 1));
			mVista.finalizar();
			// return true;
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
				mVista.mostrarError(ex.getMessage());
			}
			// return false;
		}
	}

}
