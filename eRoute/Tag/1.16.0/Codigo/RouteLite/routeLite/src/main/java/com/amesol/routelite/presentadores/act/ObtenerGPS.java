package com.amesol.routelite.presentadores.act;

import java.util.HashMap;

import android.app.Activity;
import android.content.Context;
import android.location.Location;
import android.location.LocationManager;
import android.os.CountDownTimer;
import android.os.Parcel;
import android.os.Parcelable;
import android.util.Log;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IObtencionGPS;
import com.amesol.routelite.presentadores.parcelables.DatosGPS;
import com.amesol.routelite.utilerias.RouteLocation;
import com.amesol.routelite.utilerias.RouteLocationListener;
import com.amesol.routelite.vistas.utilerias.Dispositivo;
import com.amesol.routelite.vistas.utilerias.mylocationlistenerGPS;

public class ObtenerGPS extends Presentador
{

	IObtencionGPS mVista;
    RouteLocation routeLocation;

    public ObtenerGPS(IObtencionGPS vista){
        try {
            mVista = vista;
            routeLocation = new RouteLocation(mVista.getVista(), locationListener);
            //routeLocation.startSingleUpdate(true);
        }catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

	/*public ObtenerGPS(IObtencionGPS vista, LocationManager locmanager)
	{
		mVista = vista;
		lm = locmanager;

	}*/

    private boolean open = true;

    private RouteLocationListener locationListener = new RouteLocationListener() {
        @Override
        public void updateLocation(Location location) throws InterruptedException {
            if(open) {
                //quitProgress();
                mVista.SetProgreso(150);
                //Validacion temporal, ya que en algunos escenarios el objeta llena null.
                //Se tendrá que revisar a detalle porque en Atencioncliente.resultadoActividad cuando
                //el resultado es = MAL, la aplicacion continua sin considerar el aseguramiento.
                if (location != null) {
                    mVista.SetDatos(location.getAccuracy() + "\n" + location.getLatitude() + "\n" + location.getLongitude());
                    Thread.sleep(2000);
                    DatosGPS datosGPS = new DatosGPS();
                    datosGPS.setFechaHora(location.getTime());
                    datosGPS.setLatitud(location.getLatitude());
                    datosGPS.setLongitud(location.getLongitude());
                    datosGPS.setPresicion(location.getAccuracy());
                    //mVista.HabilitarWiFi(false);
                    mVista.setResultadoParcelable(Enumeradores.Resultados.RESULTADO_BIEN, null, datosGPS);
                    mVista.finalizar();
                }else{
                   mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL,"No se pudo leer el punto GPS");
                    mVista.finalizar();
                }

                //return;
                //mVista.mostrarProgreso("");
                //Bundle params = ((VisitController) controller).createVisit(location);
                //startActivityForResult(TransactionActivity.class, false, Constants.REQUEST_CODE.TRANSACTION.val, params);
                open = false;
            }
        }

        @Override
        public void begingLocation(boolean bDisponible) {
            if (!bDisponible) {
                mVista.SetProgreso(0);
                mVista.SetDatos("Servicios de ubicación no disponibles");
            }
            else {
                mVista.SetProgreso(50);
                mVista.SetDatos(Mensajes.get("XConectado"));
            }
            //showProgress(R.string.getting_location);
        }
    };

	//LocationManager lm;
	//mylocationlistenerGPS ll;
	//CountDownTimer c;

	@Override
	public void iniciar()
	{
		mVista.iniciar();

		/*
		 * if(!lm.isProviderEnabled(LocationManager.GPS_PROVIDER)){
		 * mVista.mostrarConfiguracionGPS(); }else{ //IniciarGPS();
		 * //IniciarTimer(); IniciarTodo(); }
		 */

		IniciarTodo();
	}

	public void IniciarTodo()
	{
        try{
            routeLocation.startSingleUpdate(true);
        }
        catch(Exception e){

        }
		/*if (!lm.isProviderEnabled(LocationManager.GPS_PROVIDER))
		{
			mVista.mostrarConfiguracionGPS();
		}
		else
		{
			IniciarGPS();
			IniciarTimer();
		}*/
	}

	/*public void IniciarGPS()
	{
		Log.d("GPS", "Estado del GPS: " + lm.isProviderEnabled(LocationManager.GPS_PROVIDER));

		ll = new mylocationlistenerGPS();

		lm.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, ll);

		//lm.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, 0, 0, ll);

		ll.setOnGPSLocationChangedListener(new mylocationlistenerGPS.OnGPSLocationChangedListener()
		{

			@Override
			public void onLocationChanged(Location location)
			{

				if (location != null)
				{

					float Acc = location.getAccuracy();

					if (Acc > 16)
					{
						mVista.SetProgreso((int) Acc);

					}
					else
					{
						mVista.SetDatos(location.getAccuracy() + "\n" + location.getLatitude() + "\n" + location.getLongitude());
						ll.setOnGPSLocationChangedListener(null);
						lm.removeUpdates(ll);
						if (c != null)
						{

							c.cancel();
							c = null;
						}

						DatosGPS datosGPS = new DatosGPS();
						datosGPS.setFechaHora(location.getTime());
						datosGPS.setLatitud(location.getLatitude());
						datosGPS.setLongitud(location.getLongitude());
						datosGPS.setPresicion(location.getAccuracy());
						//mVista.HabilitarWiFi(false);
						mVista.setResultadoParcelable(Enumeradores.Resultados.RESULTADO_BIEN, null, datosGPS);
						mVista.finalizar();
						return;

					}
				}

			}

		}
				);

	}

	public void IniciarTimer()
	{
		if (c != null)
		{
			c.cancel();
			c = null;
		}
		c = new CountDownTimer(30000, 1000)
		{

			public void onTick(long millisUntilFinished)
			{

			}

			public void onFinish()
			{
				ll.setOnGPSLocationChangedListener(null);
				lm.removeUpdates(ll);

				mVista.mostrarPreguntaSiNo(Mensajes.get("P0206"), 1);

				ll.setOnGPSLocationChangedListener(null);
				lm.removeUpdates(ll);

			}
		}.start();

	}*/

	public void RegresarTimeOut()
	{
		mVista.setResultado(Enumeradores.Resultados.RESULTADO_MAL);
		mVista.finalizar();
	}

}
