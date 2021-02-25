package com.amesol.routelite.presentadores.act;

import java.io.File;
import java.security.spec.ECField;

import android.app.Activity;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.basedatos.BDTerm;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAccesoSistema;
import com.amesol.routelite.presentadores.interfaces.IConfiguracionTerminal;
import com.amesol.routelite.presentadores.interfaces.IInicioRouteLite;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;

public class IniciarRouteLite extends Presentador
{
	private IInicioRouteLite mVista;

	public IniciarRouteLite(IInicioRouteLite vista)
	{
		mVista = vista;
	}

	@Override
	public void iniciar()
	{
		mVista.iniciar();
		ArchivoConfiguracion conf = new ArchivoConfiguracion(mVista);
		if (!conf.existe())
		{
			mVista.iniciarActividad(IConfiguracionTerminal.class);
			return;
		}
		else
		{
			File archivo = new File(conf.getValor(CampoConfiguracion.DIRECTORIO_TRABAJO).toString());
			archivo = new File(archivo, "bd");
			archivo = new File(archivo, conf.getValor(CampoConfiguracion.NUMERO_SERIE).toString() + ".db");
			if (!archivo.exists())
			{
				if (conf.getValor(CampoConfiguracion.VERSION) == null || (conf.getValor(CampoConfiguracion.VERSION) != null && conf.getValor(CampoConfiguracion.VERSION).toString().equals(""))){
					try {
						conf.iniciarEdicion();
						conf.setValor(CampoConfiguracion.VERSION, (((Activity) mVista).getPackageManager().getPackageInfo(((Activity) mVista).getPackageName(), 0)).versionCode);
						conf.commit();
					}catch(Exception e){}
				}
				mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_OBTENER_BD_TERMINAL);
				return;
			}else{			
					boolean borrarArchivos = false;
					try{
						if (conf.getValor(CampoConfiguracion.VERSION) != null && !conf.getValor(CampoConfiguracion.VERSION).toString().equals("")){
							if (Integer.parseInt((conf.getValor(CampoConfiguracion.VERSION).toString())) !=  (((Activity)mVista).getPackageManager().getPackageInfo(((Activity)mVista).getPackageName(), 0)).versionCode){
								borrarArchivos = true;
							}
						}else{
							borrarArchivos = true;
						}							
						conf.iniciarEdicion();
						conf.setValor(CampoConfiguracion.VERSION,  (((Activity)mVista).getPackageManager().getPackageInfo(((Activity)mVista).getPackageName(), 0)).versionCode);
						conf.commit();						
					}catch(Exception ex){
						borrarArchivos = false;
					}
					if (borrarArchivos){
						File archivosBD = new File(conf.getValor(CampoConfiguracion.DIRECTORIO_TRABAJO).toString(), "bd");
						if (archivosBD.exists()){							 
							File[] ficheros = archivosBD.listFiles();
							for (int x=0;x<ficheros.length;x++){
								ficheros[x].delete();
							}
						}
						mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_OBTENER_BD_TERMINAL);
						return;
					}					
				}				
			}
		cargarDatos();
	}

	private void cargarDatos()
	{
		mVista.mostrarProgreso("loading..", 3);
		Runnable accion = new Runnable()
		{
			public void run()
			{
				try
				{
					BDTerm.Iniciar();
				}
				catch (Exception e)
				{
					mVista.mostrarError(e.getMessage());
					mVista.finalizar();
					System.exit(0);
				}
				mVista.actualizarProgreso(1);
				Mensajes.get("");
				mVista.actualizarProgreso(2);
				mVista.quitarProgreso();
				ValoresReferencia.getValores("TRPMOT");
				mVista.iniciarActividad(IAccesoSistema.class);
			}
		};
		new Thread(accion).start();
	}
}
