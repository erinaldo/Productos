package com.amesol.routelite.utilerias;

/**
 * Created by Adriana on 05/06/2017.
 */
import android.content.Context;
import android.content.Intent;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.provider.Settings;
import android.util.Log;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.vistas.Vista;
//import com.amesol.routelite.VisitActivity;
//import com.amesol.routelite.util.Constants;

import java.util.List;

/**
 * Created by alex.jmnz on 02/02/15.
 */
public class RouteLocation{

    private static final long MIN_TIME = 40000;
    private static final float MIN_DISTANCE = 20f;
    private LocationManager locationManager;
    private Location location;
    private Vista activity;

    //private ConfirmationListener mListener;
    private RouteLocationListener locationListener;

    private List<String> ALL_PROVIDERS;

    private boolean request;

    private int NOT_SUPPORTED_PROVIDER = 0;
    private int PROVIDER_EXISTS = 1;
    private int PROVIDER_ENABLED = 4;
    private long TIME_OUT_GPS = 10000L;

    public RouteLocation(Vista activity){
        this.activity = activity;
        //this.mListener = this;
        locationManager = (LocationManager) activity.getSystemService(Context.LOCATION_SERVICE);
        ALL_PROVIDERS = locationManager.getAllProviders();
    }

    public RouteLocation(Vista activity, RouteLocationListener listener){
        this.activity = activity;
        //this.mListener = activity;
        this.locationListener = listener;
        locationManager = (LocationManager) activity.getSystemService(Context.LOCATION_SERVICE);
        ALL_PROVIDERS = locationManager.getAllProviders();
    }

    public void startLocation(){
        if(!request) {
            int result = isProviderReady(LocationManager.GPS_PROVIDER) + isProviderReady(LocationManager.NETWORK_PROVIDER);
            if (result == 0) {
                activity.mostrarMensaje("Servicios de ubicación no disponibles", 0, 1);
            } else if (result < 4) {
                activity.mostrarPreguntaSiNo("Para mejorar el desempeño de la aplicación te sugerimos activar Servicios de Ubicación ¿Deseas habilitarlos ahora?", 99);
            }

            /* Check if the providers are enabled */
            try {
                locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, MIN_TIME, MIN_DISTANCE, lListener);
                locationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, MIN_TIME, MIN_DISTANCE, lListener);
            } catch (SecurityException e) {
            }
            request = true;
        }
    }

    public void startSingleUpdate(boolean newVisit) throws InterruptedException {
        int result = isProviderReady(LocationManager.GPS_PROVIDER) + isProviderReady(LocationManager.NETWORK_PROVIDER);
        if (result == 0) {
            activity.mostrarMensaje("Servicios de ubicación no disponibles", 0, 0);
            locationListener.updateLocation(null);
        } else if (isProviderReady(LocationManager.GPS_PROVIDER) != PROVIDER_ENABLED) {
            locationListener.begingLocation(false);
            if(newVisit)
                activity.mostrarPreguntaSiNo(Mensajes.get("P0236"), 99);
        }else {
            locationListener.begingLocation(true);
            /* Check if the providers are enabled */
            Looper looper = Looper.myLooper();
            Handler handler = new Handler(looper);
            handler.postDelayed(new Runnable() {
                @Override
                public void run() {
                    if(location == null) {
                        try {
                            locationManager.removeUpdates(lListener);
                            locationListener.updateLocation(null);
                        } catch (InterruptedException e) {
                        } catch (SecurityException e) {
                        }
                    }
                }
            }, TIME_OUT_GPS);
            try {
                locationManager.requestSingleUpdate(LocationManager.GPS_PROVIDER, lListener, looper);
                locationManager.requestSingleUpdate(LocationManager.NETWORK_PROVIDER, lListener, looper);
            } catch (SecurityException e) {
            }
        }
    }

    private int isProviderReady(String provider){
        if(ALL_PROVIDERS.contains(provider)){
            return locationManager.isProviderEnabled(provider) ? PROVIDER_ENABLED : PROVIDER_EXISTS;
        }
        return NOT_SUPPORTED_PROVIDER;
    }

    public void stopLocation(){
        if(request)
            try{
                locationManager.removeUpdates(lListener);
            }
            catch (SecurityException ex){
            }
        request = false;
    }

    public Location getLocation(){
        if(location != null) {
            return location;
        }else{
            try{
                return locationManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);
            }
            catch (SecurityException ex){
                return location;
            }
        }
    }

    private LocationListener lListener = new LocationListener() {
        @Override
        public void onLocationChanged(Location location) {
            RouteLocation.this.location = location;
            Log.i("LOCATION_ENABLED", location.toString());
            if(locationListener != null){
                try {
                    locationListener.updateLocation(location);
                    locationManager.removeUpdates(lListener);
                } catch (InterruptedException e) {
                } catch (SecurityException e) {
                }
            }
        }

        @Override
        public void onStatusChanged(String s, int i, Bundle bundle) {
            Log.i("LOCATION_STATUS_CHANGE", s);
        }

        @Override
        public void onProviderEnabled(String s) {
            Log.i("LOCATION_ENABLED", s);
        }

        @Override
        public void onProviderDisabled(String s) {
            Log.i("LOCATION_DISABLED", s);
        }
    };
}
