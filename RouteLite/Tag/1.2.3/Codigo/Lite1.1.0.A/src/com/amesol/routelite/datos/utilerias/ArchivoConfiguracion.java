package com.amesol.routelite.datos.utilerias;

import java.io.File;
import java.util.Iterator;
import java.util.Map;

import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.IVista;
import com.amesol.routelite.vistas.Vista;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Environment;

public class ArchivoConfiguracion
{
	private static final String ARCHIVO_CONFIGURACION = "confRouteLite";
	private SharedPreferences mPref;
	private SharedPreferences.Editor mEditor;

	public enum CampoConfiguracion
	{
		URL,
		USUARIO,
		PASSWORD,
		DIRECTORIO_TRABAJO,
		NUMERO_SERIE,
		PUERTO,
		WIFI,
		BLUETOOTH,
		TIMEOUT,
		VERSION
	}

	public ArchivoConfiguracion(IVista vista)
	{
		Context contexto = ((Vista) vista);
		mPref = contexto.getSharedPreferences(ARCHIVO_CONFIGURACION, Context.MODE_MULTI_PROCESS);

		if (mPref.getAll().size() > 0)
		{
			if (Sesion.get(Campo.ConfiguracionLocal) == null)
			{
				Sesion.set(Campo.ConfiguracionLocal, new ConfiguracionLocal());
			}
			ConfiguracionLocal config = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);

			Iterator it = mPref.getAll().entrySet().iterator();
			Sesion.set(Campo.ExistenPuertosConfigurados, false);
			while (it.hasNext())
			{
				Map.Entry ent = (Map.Entry) it.next();
				config.set(ent.getKey().toString(), ent.getValue());
				if (ent.getKey().toString().contains("PUERTO"))
				{
					Sesion.set(Campo.ExistenPuertosConfigurados, true);
				}
			}
		}
	}

	public boolean existe()
	{
		return mPref.getAll().size() > 0;
	}

	public void iniciarEdicion()
	{
		mEditor = mPref.edit();
	}

	public boolean setValor(CampoConfiguracion campo, String valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString(), (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, long valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString(), (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, float valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString(), (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, boolean valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString(), (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, int valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString(), (Object) valor);
	}

	private boolean setValor(String campo, Object valor)
	{
		if (mEditor == null)
			new Exception("Es necesario iniciar la edicion");
		if (valor == null)
			mEditor.remove(campo);
		else if (valor.getClass().equals(Integer.class))
			mEditor.putInt(campo, (Integer) valor);
		else if (valor.getClass().equals(int.class))
			mEditor.putInt(campo, (Integer) valor);
		else if (valor.getClass().equals(Boolean.class))
			mEditor.putBoolean(campo, (Boolean) valor);
		else if (valor.getClass().equals(boolean.class))
			mEditor.putBoolean(campo, (Boolean) valor);
		else if (valor.getClass().equals(Float.class))
			mEditor.putFloat(campo, (Float) valor);
		else if (valor.getClass().equals(float.class))
			mEditor.putFloat(campo, (Float) valor);
		else if (valor.getClass().equals(Long.class))
			mEditor.putLong(campo, (Long) valor);
		else if (valor.getClass().equals(long.class))
			mEditor.putLong(campo, (Long) valor);
		else if (valor.getClass().equals(String.class))
			mEditor.putString(campo, (String) valor);
		else if (valor != null)
			mEditor.putString(campo, valor.toString());
		return mEditor.commit();
	}

	public boolean setValor(CampoConfiguracion campo, String llave, String valor)
	{
		ConfiguracionLocal configLocal = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		configLocal.set(campo.toString() + "_" + llave, valor);
		return setValor(campo.toString() + "_" + llave, (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, String llave, long valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString() + "_" + llave, (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, String llave, float valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString() + "_" + llave, (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, String llave, boolean valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString() + "_" + llave, (Object) valor);
	}

	public boolean setValor(CampoConfiguracion campo, String llave, int valor)
	{
		actualizarSesion(campo, (Object) valor);
		return setValor(campo.toString() + "_" + llave, (Object) valor);
	}

	public Object getValor(CampoConfiguracion campo)
	{
		Object resultado = mPref.getAll().get(campo.toString());
		if (resultado == null)
			return getDefault(campo);

		return resultado;
	}

	public Object getValor(CampoConfiguracion campo, String llave)
	{
		Object resultado = mPref.getAll().get(campo.toString() + "_" + llave);
		return resultado;
	}

	public Object getDefault(CampoConfiguracion campo)
	{
		switch (campo)
		{
			case URL:
				return "http://192.168.0.1/ServicesCentral2005";
			case DIRECTORIO_TRABAJO:
				File ruta = Environment.getExternalStorageDirectory();
				ruta = new File(ruta, "routelite");
				return ruta.getAbsolutePath();
			case WIFI:
				return true;
			case BLUETOOTH:
				return true;
			case TIMEOUT:
				return (60000 * 1); //en minutos
		}

		return "";
	}

	public boolean commit()
	{
		return mEditor.commit();
	}

	private void actualizarSesion(CampoConfiguracion campo, Object valor)
	{
		if (Sesion.get(Campo.ConfiguracionLocal) == null)
		{
			Sesion.set(Campo.ConfiguracionLocal, new ConfiguracionLocal());
		}

		ConfiguracionLocal configLocal = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
		configLocal.set(campo.toString(), valor);
	}

	public void remove(CampoConfiguracion campo, String llave)
	{
		mEditor.remove(campo.toString() + "_" + llave);
		

	}
}
