package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;

import com.amesol.routelite.R;
import com.amesol.routelite.R.drawable;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.model.CameraPosition;
import com.google.android.gms.maps.model.LatLng;

public class SeleccionCoordenadas extends FragmentActivity implements OnClickListener, LocationListener, OnMapReadyCallback
{

	public static int ID_REFRESCAR = R.id.btRefrescar; //1045569;
    //creamos una ruta para guardar las fotos

    //SeleccionarCoordenadas mPresenta;
    LinearLayout llRespuestaMapa;
	MapFragment mapaFragmento;
	Button btnAceptar;
	double longitudGps;//solo se utiliza en tipo GPS
	double latitudGps;//solo se utiliza en tipo GPS
	Location loc;//solo se utiliza en tipo GPS
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.seleccion_coordenadas);
		setTitle(Mensajes.get("XCoordenadasGPS"));

        btnAceptar = (Button) findViewById(R.id.btnAceptar);
        llRespuestaMapa = (LinearLayout) findViewById(R.id.llRespuestaMapa);
        //marker = (ImageView)findViewById(R.id.marker);

        btnAceptar.setText(Mensajes.get("BTAceptar"));
        btnAceptar.setOnClickListener(mAceptar);

        configGPS();

        if (getIntent().getExtras() != null){
            latitudGps = Double.valueOf(getIntent().getExtras().get("Latitud").toString());
            longitudGps = Double.valueOf(getIntent().getExtras().get("Longitud").toString());
            mapaFragmento.getMapAsync(this);
        }

        //mPresenta = new SeleccionarCoordenadas(this);
        //mPresenta.iniciar();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) //atrapar el evento de retroceso
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK: //cacho el valor del "regreso"

				setResult(Enumeradores.Resultados.RESULTADO_MAL);
                finish();
				return false;

		}
		// TODO Auto-generated method stub
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void onClick(View v) //Este metodo lo uitlizo para identificar el id de todos los botones
	{
		if (v.getId() == ID_REFRESCAR)
		{
            obtenerCordenadas();
            mapaFragmento.getMapAsync(this);
		}

	}

    private OnClickListener mAceptar = new OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            Intent intent = new Intent();
            intent.putExtra("Latitud", latitudGps);
            intent.putExtra("Longitud", longitudGps);
            setResult(Enumeradores.Resultados.RESULTADO_BIEN, intent);
            finish();
        }
    };

    public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{
	}

	@Override
	public void onLocationChanged(Location location)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onStatusChanged(String provider, int status, Bundle extras)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onProviderEnabled(String provider)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onProviderDisabled(String provider)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onMapReady(GoogleMap mapa)
	{
		// TODO Auto-generated method stub
		mapa.clear();
		LatLng posicion = new LatLng(latitudGps, longitudGps);

		//mapa.setMyLocationEnabled(true);
		if (latitudGps != 0 && longitudGps != 0)
		{ 
			mapa.moveCamera(CameraUpdateFactory.newLatLngZoom(posicion, 15));
            ImageView marker = (ImageView)findViewById(R.id.marker);
            marker.bringToFront();
            //mapa.addMarker(new MarkerOptions().position(posicion).title("Ubicación").snippet("Lat: " + latitudGps + " \nLng: " + longitudGps));
		}

        mapa.setOnCameraChangeListener(new GoogleMap.OnCameraChangeListener() {
            @Override
            public void onCameraChange(CameraPosition cameraPosition) {
                latitudGps = cameraPosition.target.latitude;
                longitudGps = cameraPosition.target.longitude;
            }

        });

	}

    public void mensajeDialogo(String mensaje)
    {
        AlertDialog.Builder dialog = new AlertDialog.Builder(this);

        dialog.setMessage(mensaje);
        dialog.setCancelable(false);
        dialog.setPositiveButton(Mensajes.get("XSi"), new DialogInterface.OnClickListener()
        {

            @Override
            public void onClick(DialogInterface dialog, int which)
            {
            startActivity(new Intent(android.provider.Settings.ACTION_LOCATION_SOURCE_SETTINGS));
            }
        });
        dialog.setNegativeButton(Mensajes.get("XNo"), new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialog, int which)
            {
                dialog.cancel();

            }
        });
        dialog.show();
    }

	public void mensajeSimple(String mensaje)
	{
		AlertDialog.Builder dialog = new AlertDialog.Builder(this);

		dialog.setMessage(mensaje);
		dialog.setCancelable(false);
		dialog.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener()
		{

			@Override
			public void onClick(DialogInterface dialog, int which)
			{
				dialog.cancel();
			}
		});
		dialog.show();

	}

	public void configGPS()
	{
        llRespuestaMapa.setOrientation(LinearLayout.VERTICAL);
		//Codigo para crear un mapa dinamicamente
        //RelativeLayout layMapa = (RelativeLayout)findViewById(R.id.layMapa);
        mapaFragmento = MapFragment.newInstance(); //Inicializamos el fragmento para reutilizarlo
		FragmentTransaction transacion = getFragmentManager().beginTransaction();
		transacion.add(R.id.layMapa, mapaFragmento);
		transacion.commit();
		mapaFragmento.getMapAsync(this);

        ImageView marker = (ImageView)findViewById(R.id.marker);
        marker.bringToFront();

		Button btRefrescar = (Button)findViewById(R.id.btRefrescar); // new Button(llRespuestaMapa.getContext());
		btRefrescar.setText("Actualizar posición");
		btRefrescar.setOnClickListener(this);

		LocationManager locali;
		String provider;

		locali = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		Criteria c = new Criteria();
		c.setAccuracy(Criteria.ACCURACY_FINE);
		provider = locali.getBestProvider(c, true);

		locali.requestLocationUpdates(provider, 10000, 1, (LocationListener) llRespuestaMapa.getContext());
		loc = locali.getLastKnownLocation(provider);

		latitudGps = 0;
		longitudGps = 0;

		if (locali.isProviderEnabled(LocationManager.GPS_PROVIDER))
		{
			if (loc != null)
			{
				int mapaChequeo = 0;


					//tvLongitud.setText("Longitud: " + String.valueOf(loc.getLongitude()));
					longitudGps = loc.getLongitude();
					mapaChequeo++;

					//tvLatitud.setText("Latitud: " + String.valueOf(loc.getLatitude()));
					latitudGps = loc.getLatitude();
					mapaChequeo++;


				if (mapaChequeo == 2)
				{
					//btMapa.setEnabled(true);
				}
				if (mapaChequeo < 2)
				{
					btRefrescar.setEnabled(false);
				}
			}

		}
		else
		{
			mensajeDialogo(Mensajes.get("P0236"));
		}



	}
	
	public void obtenerCordenadas()
	{
		LocationManager locali;
		String provider;

		locali = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		Criteria c = new Criteria();
		c.setAccuracy(Criteria.ACCURACY_FINE);
		provider = locali.getBestProvider(c, true);

		locali.requestLocationUpdates(provider, 10000, 1, (LocationListener) llRespuestaMapa.getContext());
		loc = locali.getLastKnownLocation(provider);

		if (locali.isProviderEnabled(LocationManager.GPS_PROVIDER))
		{
			if (loc != null)
			{
				if (latitudGps != loc.getLatitude() || longitudGps != loc.getLongitude())
				{
					latitudGps = loc.getLatitude();
					longitudGps = loc.getLongitude();

				}
			}
			else
			{
				mensajeSimple(Mensajes.get("I0292"));
			}
		}
		else
		{
			mensajeDialogo(Mensajes.get("P0236"));
		}
	}

}
