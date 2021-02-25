package com.amesol.routelite.presentadores.act;

import android.content.ComponentName;
import android.content.Intent;
import android.sax.StartElementListener;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAccesoSistema;
import com.amesol.routelite.presentadores.interfaces.IConfiguracionTerminal;
import com.amesol.routelite.presentadores.interfaces.IRecepcionInformacion;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;
import com.amesol.routelite.utilerias.EncriptaDesencripta;

public class AccederSistema extends Presentador
{

	IAccesoSistema mVista;

	public AccederSistema(IAccesoSistema vista)
	{
		this.mVista = vista;
	}

	@Override
	public void iniciar()
	{
		mVista.iniciar();
		mVista.setTitulo(Mensajes.get("MDB0501"));
		ConfiguracionLocal confLocal = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		mVista.setUsuario(confLocal.get(ArchivoConfiguracion.CampoConfiguracion.USUARIO).toString());
		mVista.setPassword("");

	}

	public void intentarSalir()
	{
		String clave = mVista.getUsuario();
		String password = mVista.getPassword();

		Usuario usuario = null;
		try
		{
			usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.mostrarError(e.getMessage());
			return;
		}
		if ((usuario == null) || (!EncriptaDesencripta.encripta(password).equals(usuario.ClaveAcceso)))
		{
			mVista.mostrarAdvertencia(Mensajes.get("MDB050601"));
			return;
		}
		if (!usuario.PERClave.toUpperCase().equals("ADMIN"))
		{
			mVista.mostrarAdvertencia(Mensajes.get("MI0222"));
			return;
		}
		mVista.mostrarPreguntaSiNo(Mensajes.get("MDB050602"), 1);
	}

	public void salir()
	{
		//mVista.iniciarSelector();
		mVista.finalizar();
		System.exit(0);
	}

	public void configuracion()
	{
		mVista.iniciarActividadConResultado(IConfiguracionTerminal.class, Enumeradores.Solicitudes.SOLICITUD_CONFIGURACION, Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS);
	}

	public void acceder()
	{
		if ((validarDatosUsuario()) && (validarUsuarioConfigurado()))
		{
			try
			{
				BDVend.cerrar();
				BDVend.Iniciar();
			}
			catch (Exception e)
			{
				e.printStackTrace();
				mVista.mostrarError(e.getMessage());
				return;
			}
			if (!BDVend.estaAbierta())
			{
				try
				{
					mVista.iniciarActividadConResultado(ISolicitudAgendaVendedor.class, Enumeradores.Solicitudes.SOLICITUD_AGENDA, Enumeradores.Acciones.ACCION_AGENDA_VENDEDOR);
				}
				catch (Exception e)
				{
					e.printStackTrace();
					mVista.mostrarError(e.getMessage());
					return;
				}
			}
			if (BDVend.estaAbierta())
			{
				mVista.iniciarActividad(ISeleccionActividadesVend.class, false);
			}
		}
	}

	public void cambiarUsuario()
	{
		String clave = mVista.getUsuario();
		String password = mVista.getPassword();
		ArchivoConfiguracion conf = new ArchivoConfiguracion(mVista);
		conf.iniciarEdicion();
		conf.setValor(CampoConfiguracion.USUARIO, clave);
		conf.setValor(CampoConfiguracion.PASSWORD, password);
		conf.commit();
		acceder();
	}

	private boolean validarDatosUsuario()
	{
		String clave = mVista.getUsuario();
		String password = mVista.getPassword();

		Usuario usuario = null;
		try
		{
			usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mVista.mostrarError(e.getMessage());
			return false;
		}

		if ((usuario == null) || (!EncriptaDesencripta.encripta(password).equals(usuario.ClaveAcceso)))
		{
			mVista.mostrarAdvertencia(Mensajes.get("MDB050601"));
			return false;
		}
		Sesion.set(Campo.UsuarioActual, usuario);

		return true;
	}

	private boolean validarUsuarioConfigurado()
	{
		String clave = mVista.getUsuario();
		ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		if (!conf.get(CampoConfiguracion.USUARIO).toString().toUpperCase().equals(clave.toUpperCase()))
		{
			mVista.mostrarPreguntaSiNo(Mensajes.get("P0108"), 0);
			return false;
		}
		return true;
	}

	public void recibir()
	{
		mVista.iniciarActividadConResultado(IRecepcionInformacion.class, Enumeradores.Solicitudes.SOLICITUD_RECIBIR, Enumeradores.Acciones.ACCION_RECIBIR_INFO_TERMINAL);
	}
}
