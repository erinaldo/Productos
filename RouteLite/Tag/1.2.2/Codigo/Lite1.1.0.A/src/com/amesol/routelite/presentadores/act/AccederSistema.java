package com.amesol.routelite.presentadores.act;

import java.util.Calendar;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.UsuarioSustituto;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
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
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.utilerias.Log;

public class AccederSistema extends Presentador
{

	IAccesoSistema mVista;
	private UsuarioSustituto sustituto;

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
		//cargaSustituto();
	}

	public void intentarSalir(String clave, String password)
	{
		//String clave = mVista.getUsuario();
		//String password = mVista.getPassword();

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

	public void acceder(){
		String usuario = mVista.getUsuario();
		String password = mVista.getPassword();
		this.acceder(usuario, password, false);
	}
	
	public void acceder(String usuario, String password, boolean sustituto)
	{
		if (validarDatosUsuario(usuario, password) && (sustituto || validarUsuarioConfigurado()))
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
				if(sustituto){
					mVista.mostrarAdvertencia(/*Mensajes.get("I0280")*/"No es posible ingresar un usuario sustituto, debido ha que" +
							" no existe agenda para el usuario titular");
				}else
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
			}
			if (BDVend.estaAbierta())
			{
				if(sustituto)
				{
					Dia dia = validarAgenda();
					if(dia != null)
					{
						try{
							ingresarSustituto(dia);
							mVista.iniciarActividad(ISeleccionActividadesVend.class, false);
						}catch(Exception ex){
							Log.e(ex);
							mVista.mostrarError(ex.getMessage());
							return;
						}
					}else
					{
						mVista.mostrarAdvertencia(Mensajes.get("I0280"));
					}
				}else
				{
					mVista.iniciarActividad(ISeleccionActividadesVend.class, false);
				}
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

	private boolean validarDatosUsuario(String clave, String password)
	{
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
	
	public void usuarioSustituto(){
		mVista.mostrarDialogoUsuarioSustituto("", "");
	}
	
	public void cargaSustituto(){
		try{
			BDVend.cerrar();
			BDVend.Iniciar();
			if(BDVend.estaAbierta()){
				UsuarioSustituto ust = Consultas.ConsultasUsuarioSustituto.obtenerUltimoSustituto();
				sustituto = ust;
				if(sustituto != null){
					Usuario usuarioSustituto = new Usuario();
					usuarioSustituto.USUId = ust.USUIdSustituto;
					BDTerm.recuperar(usuarioSustituto);
					sustituto.Clave = usuarioSustituto.Clave;
					mVista.setUsuarioSustituto(usuarioSustituto);
				}
				else
				{
					mVista.setUsuarioSustituto(null);
				}
			}
		}catch(Exception ex){
			sustituto = null;
		}
	}
	
	public boolean existeSustituto(){
		cargaSustituto();
		return sustituto != null;
	}
	
	public UsuarioSustituto getSustituto(){
		return sustituto;
	}
	
	public void quitarSustituto(){
		sustituto = null;
		mVista.borrarSustituto();
	}
	
	private Dia validarAgenda(){
		try{
			return Consultas.ConsultasAgenda.obtenerDiaClaveAgendaFechaCaptura();
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
			return null;
		}
	}
	
	private void ingresarSustituto(Dia dia) throws Exception{
		Usuario usuarioSust = (Usuario) Sesion.get(Campo.UsuarioActual);
		if(existeSustituto())
		{
			if(!usuarioSust.Clave.equals(sustituto.Clave)){
				/* Actualizamos la hora de fin del usuario anterior */
				Calendar cal = Calendar.getInstance();
				cal.setTime(Generales.getFechaHoraActual());
				cal.add(Calendar.MINUTE, -1);
				BDVend.recuperar(sustituto);
				sustituto.FechaHoraFin = cal.getTime();
				BDVend.guardarInsertar(sustituto);
				/* Insertamos el nuevo sustituto */
				insertaNuevoSustituto(usuarioSust, dia);
			}
		}else
		{
			insertaNuevoSustituto(usuarioSust, dia);
		}
	}
	
	private void insertaNuevoSustituto(Usuario usuarioSust, Dia dia) throws Exception{
		UsuarioSustituto ust = new UsuarioSustituto();
		String clave = ((ConfiguracionLocal)Sesion.get(Campo.ConfiguracionLocal)).get(CampoConfiguracion.USUARIO).toString();
		Usuario usuarioTitular = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
		Calendar cal = Calendar.getInstance();
		ust.FechaHoraInicio = Generales.getFechaHoraActual();
		cal.setTime(ust.FechaHoraInicio);
		cal.set(Calendar.HOUR_OF_DAY, 23);
		cal.set(Calendar.MINUTE, 59);
		cal.set(Calendar.SECOND, 59);
		ust.FechaHoraFin = cal.getTime();
		ust.SustitucionId = KeyGen.getId();
		ust.USUIdSustituto = usuarioSust.USUId;
		ust.USUIdTitular = usuarioTitular.USUId;
		ust.VendedorId = Consultas.ConsultasVendedor.obtenerVendedorPorUsuario(usuarioTitular).VendedorId;
		ust.DiaClave = dia.DiaClave;
		ust.Enviado = false;
		BDVend.guardarInsertar(ust);
		BDVend.commit();
		mVista.setUsuarioSustituto(usuarioSust);
		Sesion.set(Campo.UsuarioActual, usuarioSust);
		sustituto = ust;
		sustituto.Clave = usuarioSust.Clave;
	}
}
