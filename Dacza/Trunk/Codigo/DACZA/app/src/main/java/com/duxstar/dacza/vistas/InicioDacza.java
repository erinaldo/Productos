package com.duxstar.dacza.vistas;

import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.widget.TextView;

import com.duxstar.dacza.Manifest;
import com.duxstar.dacza.R;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.IniciarDacza;
//import com.amesol.routelite.presentadores.interfaces.IConfiguracionTerminal;
import com.duxstar.dacza.presentadores.interfaces.IConfiguracionTerminal;
import com.duxstar.dacza.presentadores.interfaces.IInicioDacza;
import com.duxstar.dacza.vistas.utilerias.Dispositivo;

public class InicioDacza extends Vista implements IInicioDacza
{
    public static final int MY_PERMISSIONS_REQUEST_WRITE_EXTERNAL_STORAGE = 1;
	IniciarDacza mPresenta;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		setContentView(R.layout.inicio_dacza);
		deshabilitarBarra(true);

		TextView version = (TextView) findViewById(android.R.id.text2);
		String modVersion = String.format("Version: %s", Dispositivo.obtenerNombreVersion(this));
		modVersion = modVersion.substring(0, 12);
		version.setText(modVersion);

		mPresenta = new IniciarDacza(InicioDacza.this);
		mPresenta.iniciar();
	}

	public void iniciar()
	{

        /*if (ContextCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE)
                != PackageManager.PERMISSION_GRANTED) {

            ActivityCompat.requestPermissions(this,
                    new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                    MY_PERMISSIONS_REQUEST_WRITE_EXTERNAL_STORAGE);
        }*/
	}

    /*@Override
    public void onRequestPermissionsResult(int requestCode,
                                           String permissions[], int[] grantResults) {
        switch (requestCode) {
            case MY_PERMISSIONS_REQUEST_WRITE_EXTERNAL_STORAGE: {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.length > 0
                        && grantResults[0] == PackageManager.PERMISSION_GRANTED) {

                    // permission was granted, yay! Do the
                    // contacts-related task you need to do.

                } else {

                    // permission denied, boo! Disable the
                    // functionality that depends on this permission.
                }
                return;
            }

            // other 'case' lines to check for other
            // permissions this app might request
        }
    }*/

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
