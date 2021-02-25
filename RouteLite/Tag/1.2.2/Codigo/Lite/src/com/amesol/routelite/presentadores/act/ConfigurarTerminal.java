package com.amesol.routelite.presentadores.act;

import java.util.HashMap;
import java.util.Map.Entry;

import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConfiguracionTerminal;
import com.amesol.routelite.presentadores.interfaces.IInicioRouteLite;
import com.amesol.routelite.vistas.utilerias.Dispositivo;

public class ConfigurarTerminal extends Presentador
{

	private IConfiguracionTerminal mVista;

	private ArchivoConfiguracion configuracion;
	private String mAccion;
	private HashMap<String, String> mListaPuertos = new HashMap<String, String>();

	public ConfigurarTerminal(IConfiguracionTerminal vista, String accion)
	{
		mVista = vista;
		this.mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		mVista.iniciar();
		configuracion = new ArchivoConfiguracion(mVista);
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS)))
		{
			mVista.mostrarOpcionesPuerto();
			ValorReferencia[] valores = ValoresReferencia.getValores("TPAPEL");
			mVista.presentarTiposPapel(valores);

			for (ValorReferencia v : valores)
			{
				Object c = configuracion.getValor(CampoConfiguracion.PUERTO, v.getVavclave());
				if (c != null)
				{
					mListaPuertos.put(v.getVavclave(), c.toString());
				}
			}
			mVista.setConfiguracionPuerto(mListaPuertos);

		}

		mVista.setServicio(configuracion.getValor(CampoConfiguracion.URL).toString());
		mVista.setDirectorio(configuracion.getValor(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		mVista.setUsuario(configuracion.getValor(CampoConfiguracion.USUARIO).toString());
		mVista.setContrasenia(configuracion.getValor(CampoConfiguracion.PASSWORD).toString());
		mVista.setWireless((Boolean) configuracion.getValor(CampoConfiguracion.WIFI));
		mVista.setBluetooth((Boolean) configuracion.getValor(CampoConfiguracion.BLUETOOTH));
		mVista.setTimeOut((Integer) configuracion.getValor(CampoConfiguracion.TIMEOUT));
		if (mVista.existeBDVendedor())
			mVista.setAseguramientoVisita(mVista.obtenerAseguramientoVisita());
	}

	public void anterior()
	{
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS)))
			mVista.finalizar();
	}

	public void continuar()
	{
		configuracion = new ArchivoConfiguracion(mVista);
		configuracion.iniciarEdicion();
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.URL, mVista.getServicio());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.USUARIO, mVista.getUsuario());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.PASSWORD, mVista.getContrasenia());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO, mVista.getDirectorio());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.NUMERO_SERIE, Dispositivo.obtenerNumeroSerie(mVista));
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.WIFI, mVista.isWireless());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.BLUETOOTH, mVista.isBluetooth());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.TIMEOUT, mVista.getTimeOut());
		for (Entry<String, String> ele : mListaPuertos.entrySet())
		{
			configuracion.setValor(CampoConfiguracion.PUERTO, ele.getKey(), ele.getValue());
			Sesion.set(Campo.ExistenPuertosConfigurados, true);
		}
		configuracion.commit();
		if (mAccion != null)
			mVista.guardarAseguramiento();
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS)))
			mVista.finalizar();
		else
			mVista.iniciarActividad(IInicioRouteLite.class);
	}

	public void agregarPuerto(String vavClave, String puerto)
	{
		mListaPuertos.put(vavClave, puerto);
	}

	public void eliminarPuerto(String vavClave)
	{
		configuracion = new ArchivoConfiguracion(mVista);
		configuracion.iniciarEdicion();
		configuracion.remove(CampoConfiguracion.PUERTO, vavClave);
		configuracion.commit();
		mListaPuertos.remove(vavClave);
		mVista.setConfiguracionPuerto(mListaPuertos);

	}

	public void deFabrica()
	{
		mVista.setServicio(configuracion.getDefault(CampoConfiguracion.URL).toString());
		mVista.setDirectorio(configuracion.getDefault(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		mVista.setUsuario(configuracion.getDefault(CampoConfiguracion.USUARIO).toString());
		mVista.setContrasenia(configuracion.getDefault(CampoConfiguracion.USUARIO).toString());
		mVista.setTimeOut((Integer) configuracion.getDefault(CampoConfiguracion.TIMEOUT));
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR_PUERTOS)))
		{
			for (Entry<String, String> ele : mListaPuertos.entrySet())
			{
				mListaPuertos.put(ele.getKey(), null);
			}
			mVista.setConfiguracionPuerto(mListaPuertos);
		}
	}

	public CharSequence existePuerto(String vAVClave)
	{
		if(mListaPuertos.containsKey(vAVClave))
			return mListaPuertos.get(vAVClave);
		return "";
	}

}
