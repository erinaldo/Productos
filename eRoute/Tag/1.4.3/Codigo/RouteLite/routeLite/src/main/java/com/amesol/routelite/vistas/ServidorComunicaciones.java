package com.amesol.routelite.vistas;

import java.util.Date;
import java.util.HashMap;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TipoEnvioInfo;
import com.amesol.routelite.presentadores.act.ServirComunicaciones;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;

@SuppressLint("NewApi")
public class ServidorComunicaciones extends Vista implements IServidorComunicaciones
{

	ServirComunicaciones presenta;
	ProgressBar progresoPasos = null;
	ProgressBar progresoDetalle = null;
	TextView txtPasos = null;
	TextView txtDetalle = null;
	boolean ActiveSendSeller = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.servidor_comunicaciones);
		deshabilitarBarra(true);

		progresoPasos = (ProgressBar) findViewById(R.id.progPasos);
		progresoDetalle = (ProgressBar) findViewById(R.id.progDetalle);
		txtPasos = (TextView) findViewById(android.R.id.text1);
		txtDetalle = (TextView) findViewById(android.R.id.text2);
		String accion = getIntent().getAction();

		if (getIntent().getExtras() != null )
		{
			HashMap<String, Object> hm = (HashMap<String, Object>) getIntent().getExtras().get("parametros");
            if (hm == null){
                presenta = new ServirComunicaciones(this, accion);
            }else if (hm.containsKey("FechaIni"))
			{
				Date fechaIni = null;
				Date fechaFin = null;
				fechaIni = (Date) hm.get("FechaIni");
                if (hm.get("FechaFin") != null) {
                    fechaFin = (Date) hm.get("FechaFin");
                }else{
                    fechaFin =(Date) fechaIni.clone();
                }
				presenta = new ServirComunicaciones(this, accion, fechaIni, fechaFin);
			}
			else if (hm.containsKey("Tablas"))
			{
                boolean recargas = false;
                boolean precios = false;
				if (hm.containsKey("Recargas") ){
					recargas = Boolean.parseBoolean(hm.get("Recargas").toString());
				}
                if (hm.containsKey("Precios") ){
                    precios = Boolean.parseBoolean(hm.get("Precios").toString());
                }
                presenta = new ServirComunicaciones(this, accion, hm.get("Tablas").toString(),recargas, precios);
			}
			else if (hm.containsKey("TipoEnvioInfo"))
			{
				int tipoEnvioInfo = Integer.parseInt(hm.get("TipoEnvioInfo").toString());
				if(hm.containsKey("Continuar")){
					boolean continuar = Boolean.parseBoolean(hm.get("Continuar").toString());
					presenta = new ServirComunicaciones(continuar, this, accion, tipoEnvioInfo);
				}else{
					presenta = new ServirComunicaciones(this, accion, tipoEnvioInfo);	
				}
			}else if(hm.containsKey("ModificacionUsuario")){
                presenta = new ServirComunicaciones(this, accion, hm.get("UsuarioMod").toString(),hm.get("ContrasenaMod").toString());
            }
		}
		else
		{
			presenta = new ServirComunicaciones(this, accion);
		}

		presenta.iniciar();
	}

	public void ActivarEnvio()
	{

	}

	public void iniciar()
	{

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// no hay resultados de alguna actividad hija
	}

	public void setMaxPasos(int valorMaximo)
	{
		progresoPasos.setMax(valorMaximo);

	}

	public void setMaxDetallePasos(int valorMaximo)
	{
		progresoDetalle.setMax(valorMaximo);

	}

	public void setProgresoPasos(final int valor)
	{
		Runnable accion = new Runnable()
		{
			public void run()
			{
				progresoPasos.setProgress(valor);
			}
		};
		runOnUiThread(accion);

	}

	public void setProgresoDetallePasos(final int valor)
	{
		Runnable accion = new Runnable()
		{

			public void run()
			{
				progresoDetalle.setProgress(valor);
			}
		};
		runOnUiThread(accion);

	}

	public void setTextoPasos(final String texto)
	{
		Runnable accion = new Runnable()
		{
			public void run()
			{
				txtPasos.setText(texto);
			}
		};
		runOnUiThread(accion);
	}

	public void setTextoProgreso(final String texto)
	{
		Runnable accion = new Runnable()
		{
			public void run()
			{
				txtDetalle.setText(texto);
			}
		};
		runOnUiThread(accion);
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{

	}

	@Override
	public void actualizarProgreso(Integer avance)
	{
		// TODO Auto-generated method stub
		super.actualizarProgreso(avance);
	}

}
