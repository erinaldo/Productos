package com.amesol.routelite.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.IniciarRouteLite;
import com.amesol.routelite.presentadores.interfaces.IConfiguracionTerminal;
import com.amesol.routelite.presentadores.interfaces.IInicioRouteLite;
import com.amesol.routelite.vistas.utilerias.Dispositivo;

public class InicioRouteLite extends Vista implements IInicioRouteLite
{

	IniciarRouteLite mPresenta;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		setContentView(R.layout.inicio_route_lite);
		deshabilitarBarra(true);

		TextView version = (TextView) findViewById(android.R.id.text2);
		String modVersion = String.format("Version: %s", Dispositivo.obtenerNombreVersion(this));
		modVersion = modVersion.substring(0, 12);
		version.setText(modVersion);

		mPresenta = new IniciarRouteLite(InicioRouteLite.this);
		mPresenta.iniciar();
	}

	public void iniciar()
	{

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		{
			if (data != null)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (mensajeError != null)
				{
					iniciarActividad(IConfiguracionTerminal.class, mensajeError);
					return;
				}
			}
			iniciarActividad(IConfiguracionTerminal.class);
		}
		else
			mPresenta.iniciar();
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{

	}

}
