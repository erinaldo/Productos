package com.amesol.routelite.presentadores.act;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import android.annotation.SuppressLint;
import android.widget.Toast;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.FrecuenciaExcep;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TipoFecha;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.ICapturaDeposito;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.presentadores.interfaces.ISeleccionAgenda;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;
import com.amesol.routelite.utilerias.Generales;

public class SeleccionarAgenda extends Presentador
{

	ISeleccionAgenda mVista;
	String mAccion;

	public SeleccionarAgenda(ISeleccionAgenda vista, String accion)
	{
		this.mVista = vista;
		this.mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub
		try
		{
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA))
					|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
					|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES))
					|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA))
					|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO))
					|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION))
					|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS))
					|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
			{
				ISetDatos dias = Consultas.ConsultasDia.obtenerDiasAgenda();

				if (validarMostrarDias(dias))
				{
					mVista.mostrarDiasTrabajo(dias);
				}
				else
				{
					if (mVista.validarJornadaTrabajo())
					{
						if (validarKilometraje()){
							if (!mVista.getValidando())
								if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA, null, false);
								else if ((mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA, null, false);
								else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES_RUTA, null, false);
								else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA_RUTA, null, false);
								else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_RUTA, null, false);
								else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION_RUTA, null, false);
								else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_RUTA, null, false);
								else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
									mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO_RUTA, null, false);
							mVista.finalizar();
						}
					}
				}
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividad(IAtencionClientes.class, false);
				}
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO);
				}
			}

			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES);
				}
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA);
				}
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividadConResultado(ICapturaDeposito.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO);
				}
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION);
				}
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS);
				}
			}else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO_RUTA)))
			{
				ISetDatos rutas = Consultas.ConsultasRuta.obtenerRutas();
				if (validarMostrarRutas(rutas))
				{
					mVista.mostrarRutasTrabajo(rutas);
				}
				else
				{
					mVista.finalizar();
					mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO);
				}
			}

		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	private boolean validarMostrarDias(ISetDatos dias)
	{
		boolean bMostrar = true;
		if (dias.getCount() == 1)
		{
			dias.moveToFirst();

			Date dFechaCaptura = dias.getDate(2);

			Calendar c = Calendar.getInstance();
			int mYear = c.get(Calendar.YEAR);
			int mMonth = c.get(Calendar.MONTH);
			int mDay = c.get(Calendar.DAY_OF_MONTH);

			@SuppressWarnings("deprecation")
			Date dFechaActual = new Date(mYear - 1900, mMonth, mDay);

			if (dFechaCaptura.compareTo(dFechaActual) == 0)
			{
				asignarDiaActual(dias.getString(1));
				bMostrar = false;
				dias.close();
			}

		}
		return bMostrar;
	}

	private boolean validarMostrarRutas(ISetDatos rutas)
	{
		boolean bMostrar = true;
		if (rutas.getCount() == 1)
		{
			rutas.moveToFirst();
			asignarRutaActual(rutas.getString(1));
			bMostrar = false;
			rutas.close();
		}
		return bMostrar;
	}

	private void asignarDiaActual(String diaClave)
	{
		Dia diaActual = new Dia();
		diaActual.DiaClave = diaClave;
		try
		{
			BDVend.recuperar(diaActual);
			Sesion.set(Campo.DiaActual, diaActual);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
		obtenerDatosSesionPreventaAsync();
	}

	private void asignarDiaSeleccionado(String diaClave)
	{
		Dia diaSelect = new Dia();
		diaSelect.DiaClave = diaClave;
		try
		{
			BDVend.recuperar(diaSelect);
			Sesion.set(Campo.DiaActual, diaSelect);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
		obtenerDatosSesionPreventaAsync();
	}

	private void asignarRutaActual(String rutaClave)
	{
		Ruta rutaActual = new Ruta();
		rutaActual.RUTClave = rutaClave;
		try
		{
			BDVend.recuperar(rutaActual);
			Sesion.set(Campo.RutaActual, rutaActual);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
	
	private void obtenerDatosSesionPreventaAsync(){
		//se ejecuta en un hilo para no detener la interfaz de usuario mientras se hacen todos los calculos
		Runnable accion = new Runnable()
		{
			@Override
			public void run(){
				obtenerDatosSesionPreventa();
			}
		};
		final Thread hilo = new Thread(accion);
		hilo.start();
	}
	
	private void obtenerDatosSesionPreventa(){
		try{
			//TODO: CHECAR ESTO, CAI 3307
			MOTConfiguracion motConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA || motConf.get("MSIEVPreventa").toString().equals("1")){
				CONHist conhist = (CONHist) Sesion.get(Campo.CONHist);
				//Dia dia = (Dia) Sesion.get(Campo.DiaActual);
				//obtener excepciones de frecuencia
				ArrayList<FrecuenciaExcep> excepciones = new ArrayList<FrecuenciaExcep>();
				excepciones = Consultas.ConsultasFrecuenciaExcep.obtenerTodasFrecuenciaExcep();
				Sesion.set(Campo.ExcepcionFreq, excepciones);
				
				//calcular fecha minima entrega
				if(Integer.parseInt(conhist.get("DiasMaxSurtido").toString()) < 0){
					/*Calendar cal = Calendar.getInstance();
					cal.setTime(dia.FechaCaptura);
					cal.add(Calendar.DATE, Integer.parseInt(conhist.get("DiasSurtido").toString()));
					Date fechaMinEntrega = cal.getTime();
					fechaMinEntrega = validarExcepcionesFrecuenciaFechasEntrega(fechaMinEntrega);*/
					Date fechaMinEntrega = sumarDias(Integer.parseInt(conhist.get("DiasSurtido").toString()));
					Sesion.set(Campo.FechaMinimaEntrega, fechaMinEntrega);
				}else if(Integer.parseInt(conhist.get("DiasMaxSurtido").toString()) > 0){
					/*Calendar cal = Calendar.getInstance();
					cal.setTime(dia.FechaCaptura);
					cal.add(Calendar.DATE, Integer.parseInt(conhist.get("DiasSurtido").toString()));
					Date fechaMinEntrega = cal.getTime();
					fechaMinEntrega = validarExcepcionesFrecuenciaFechasEntrega(fechaMinEntrega);*/
					Date fechaMinEntrega = sumarDias(Integer.parseInt(conhist.get("DiasSurtido").toString()));
					Sesion.set(Campo.FechaMinimaEntrega, fechaMinEntrega);
				}else{
					Date fechaMinEntrega = sumarDias(Integer.parseInt(conhist.get("DiasSurtido").toString()));
					Sesion.set(Campo.FechaMinimaEntrega, fechaMinEntrega);
				}
				
				//calcular fecha maxima entrega
				/*Calendar cal = Calendar.getInstance();
				cal.setTime(dia.FechaCaptura);
				cal.add(Calendar.DATE, Integer.parseInt(conhist.get("DiasMaxSurtido").toString()));
				Date fechaMaxEntrega = cal.getTime();
				fechaMaxEntrega = validarExcepcionesFrecuenciaFechasEntrega(fechaMaxEntrega);*/
				Date fechaMaxEntrega = sumarDias(Integer.parseInt(conhist.get("DiasMaxSurtido").toString()));
				Sesion.set(Campo.FechaMaximaEntrega, fechaMaxEntrega);
			}
		}
		catch (Exception e){
			e.printStackTrace();
		}
	}
	
	private Date sumarDias(int dias){
		Dia dia = (Dia) Sesion.get(Campo.DiaActual);
		Date resFecha = dia.FechaCaptura;
		for(int i = 1; i <= dias; i++){ //sumar los dias uno por uno y validar excepciones de frecuencia
			Calendar cal = Calendar.getInstance();
			cal.setTime(resFecha);
			cal.add(Calendar.DATE, 1);
			resFecha = cal.getTime();
			resFecha = validarExcepcionesFrecuenciaFechasEntrega(resFecha);
		}
		return resFecha;
	}
	
	@SuppressWarnings({ "unchecked", "deprecation" })
	private Date validarExcepcionesFrecuenciaFechasEntrega(Date fecha){
		ArrayList<FrecuenciaExcep> excepciones = (ArrayList<FrecuenciaExcep>) Sesion.get(Campo.ExcepcionFreq);
		Date resFecha = fecha;
		if(excepciones.size() > 0){
			int dia = fecha.getDate();
			int mes = fecha.getMonth() + 1;
			int year = fecha.getYear() + 1900;
			int diaSemana = fecha.getDay();
			Calendar cal = Calendar.getInstance();
			cal.setTime(fecha);
			cal.add(Calendar.DATE, 1);
			for(FrecuenciaExcep excepcion : excepciones){
				switch(excepcion.TipoFecha){
					case TipoFecha.DIA_EXACTO:
						if(excepcion.Dia == dia && excepcion.Mes == mes && excepcion.Anio == year){
							return validarExcepcionesFrecuenciaFechasEntrega(cal.getTime());
						}
						break;
					case TipoFecha.DIA_DE_LA_SEMANA:
						try
						{
							Calendar tmp = Calendar.getInstance();
							tmp.setTime((new SimpleDateFormat("dd/MM/yyyy")).parse(excepcion.Dia+"/"+excepcion.Mes+"/"+excepcion.Anio));
							if(tmp.getTime().getDay() == diaSemana){
								return validarExcepcionesFrecuenciaFechasEntrega(cal.getTime());
							}
						}
						catch (ParseException e)
						{
							mVista.mostrarAdvertencia(e.getMessage());
						}
						break;
					case TipoFecha.DIA_MES:
						if(excepcion.Dia == dia && excepcion.Mes == mes){
							return validarExcepcionesFrecuenciaFechasEntrega(cal.getTime());
						}
						break;
				}
			}
		}
		return resFecha;
	}

	@SuppressLint("SimpleDateFormat")
	public void seleccionar()
	{
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
		{
			// TODO: Descomentar esta validación
			try
			{
				ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
				String claveTitular = conf.get(CampoConfiguracion.USUARIO).toString();
				String claveActual = ((Usuario)Sesion.get(Campo.UsuarioActual)).Clave;
				
				boolean existeSustituto = !claveTitular.equals(claveActual);
				
				Date seleccion = new Date();
				SimpleDateFormat x = new SimpleDateFormat("dd/MM/yyyy");
				seleccion = x.parse(mVista.getDia());
				if (Generales.getFechaActual().compareTo(seleccion) != 0)
				{
					if(existeSustituto){
						 mVista.mostrarAdvertencia(Mensajes.get("E0919"));
					}else{
						mVista.showAlertDialog();
					}
					return;
				}
			}
			catch (ParseException e)
			{
				e.printStackTrace();
			}

			asignarDiaActual(mVista.getDia());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA);

			if (mVista.validarJornadaTrabajo())
			{
				if (validarKilometraje()){
					if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA, null, false);
					else if ((mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA, null, false);
					else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES_RUTA, null, false);
					else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA_RUTA, null, false);
					else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_RUTA, null, false);
					else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION_RUTA, null, false);
					else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_RUTA, null, false);
					else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
						mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO_RUTA, null, false);
					mVista.finalizar();
				}
			}
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
			mVista.finalizar();
			mVista.iniciarActividad(IAtencionClientes.class, false);
		}

		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO);

		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES);

		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA);

		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ICapturaDeposito.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO);

		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION);

		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			// mVista.iniciarActividadConResultado(IAtencionClientes.class,
			// Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES,
			// Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ISeleccionPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS);

		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO_RUTA)))
		{
			asignarRutaActual(mVista.getRuta());
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO);
		}

	}

	private boolean validarKilometraje(){
		mVista.setValidando(false);
		if (((Vendedor)Sesion.get(Campo.VendedorActual)).Kilometraje){
			try{
				if (Consultas.ConsultasKilometraje.existeKilometrajeCapturado()){
					return true;
				}				
			}catch(Exception ex){
				mVista.setValidando(true);
				mVista.mostrarError(ex.getMessage());
				return false;
			}
			
		}else{
			return true;
		}
		
		mVista.setValidando(true);
		mVista.mostrarError(Mensajes.get("E0721"));
		return false;
	}
	public void Acceder()
	{
		asignarDiaSeleccionado(mVista.getsDiaClave());
		if (mVista.validarJornadaTrabajo())
		{
			if (validarKilometraje()){
				if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA, null, false);
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA, null, false);
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES_RUTA, null, false);
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA_RUTA, null, false);
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_RUTA, null, false);
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION_RUTA, null, false);
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_RUTA, null, false);
				else if ((mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
					mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO_RUTA, null, false);
				mVista.finalizar();
			}
		}
	}

	public void toActividadesVed()
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
				mVista.finalizar();
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
			mVista.finalizar();
		}
	}

}
