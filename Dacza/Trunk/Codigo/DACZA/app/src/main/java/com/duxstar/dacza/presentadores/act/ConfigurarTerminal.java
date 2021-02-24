package com.duxstar.dacza.presentadores.act;

import android.content.pm.PackageManager;
import android.support.v4.content.ContextCompat;

import java.util.Date;
import java.util.HashMap;
import java.util.Map.Entry;

//import com.amesol.routelite.actividades.ValorReferencia;
//import com.amesol.routelite.actividades.ValoresReferencia;
import com.duxstar.dacza.Manifest;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.IConfiguracionTerminal;
import com.duxstar.dacza.presentadores.interfaces.IInicioDacza;
import com.duxstar.dacza.vistas.utilerias.Dispositivo;

public class ConfigurarTerminal extends Presentador
{

	private IConfiguracionTerminal mVista;
	private ArchivoConfiguracion configuracion;
	private String mAccion;

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

		mVista.setServicio(configuracion.getValor(CampoConfiguracion.URL).toString());
		mVista.setDirectorio(configuracion.getValor(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
        //mVista.setFecha((Date)configuracion.getValor(CampoConfiguracion.FECHA));
		mVista.setAlmacen(configuracion.getValor(CampoConfiguracion.ALMACEN).toString());
		mVista.setAgente(configuracion.getValor(CampoConfiguracion.AGENTE).toString());
        mVista.setPassword(configuracion.getValor(CampoConfiguracion.PASSWORD).toString());
        mVista.setEnvioIndividual((Boolean) configuracion.getValor(CampoConfiguracion.ENVIO_INDIVIDUAL));
		mVista.setWireless((Boolean) configuracion.getValor(CampoConfiguracion.WIFI));
		mVista.setTimeOut((Integer) configuracion.getValor(CampoConfiguracion.TIMEOUT));
	}

	public void anterior()
	{
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CONFIGURAR)))
			mVista.finalizar();
	}

	public void continuar()
	{
		configuracion = new ArchivoConfiguracion(mVista);
		configuracion.iniciarEdicion();
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.URL, mVista.getServicio());
        //configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.FECHA, mVista.getFecha());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.ALMACEN, mVista.getAlmacen());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.AGENTE, mVista.getAgente());
        configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.PASSWORD, mVista.getPassword());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.DIRECTORIO_TRABAJO, mVista.getDirectorio());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.NUMERO_SERIE, Dispositivo.obtenerNumeroSerie(mVista));
        configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.ENVIO_INDIVIDUAL, mVista.isEnvioIndividual());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.WIFI, mVista.isWireless());
		configuracion.setValor(ArchivoConfiguracion.CampoConfiguracion.TIMEOUT, mVista.getTimeOut());

		configuracion.commit();
		mVista.iniciarActividad(IInicioDacza.class);
	}

	public void deFabrica()
	{
		mVista.setServicio(configuracion.getDefault(CampoConfiguracion.URL).toString());
		mVista.setDirectorio(configuracion.getDefault(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
		mVista.setEnvioIndividual((Boolean)configuracion.getDefault(CampoConfiguracion.ENVIO_INDIVIDUAL));
		mVista.setWireless((Boolean)configuracion.getDefault(CampoConfiguracion.WIFI));
		mVista.setTimeOut((Integer) configuracion.getDefault(CampoConfiguracion.TIMEOUT));
	}

    public void intentarSalir()
    {
        mVista.mostrarPreguntaSiNo("¿Está seguro?", 1);
    }

    public void salir()
    {
        mVista.finalizar();
        System.exit(0);
    }

}
