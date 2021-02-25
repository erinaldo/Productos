package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.List;


import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.modelos.ValorReferencia;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import io.realm.Realm;


public class Login2Activity extends Activity implements AsyncTaskInterface{

    final String TAG = Login2Activity.class.getName();
    Context context = Login2Activity.this;
    private Spinner sucursales;
    private Spinner almancenes;
    private JSONArray sucursalesJson;
    private JSONArray almacenesJson;
    private boolean errorToken;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login2);

        sucursales = (Spinner) findViewById(R.id.sucursalSpinner);
        almancenes = (Spinner) findViewById(R.id.almacenSpinner);

        sucursales.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                try {
                    new Conexion(context,Login2Activity.this).execute();
                } catch (Exception e) {
                    Log.e(TAG,e.getMessage(),e);
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        llenarSucursales(getIntent().getExtras().getString("sucursales"));

    }

    private void llenarSucursales(String jsonString){
        try{
            List<String> sucursalesArray = new ArrayList<String>();
            sucursalesJson = new JSONArray(jsonString);
            for(int contadorSucursales = 0;contadorSucursales < sucursalesJson.length();contadorSucursales++){
                sucursalesArray.add(sucursalesJson.getJSONObject(contadorSucursales).getString("nombre"));
            }

            ArrayAdapter<String> sucursalesAdapter = new ArrayAdapter<String>(
                    context, android.R.layout.simple_spinner_item, sucursalesArray);

            sucursalesAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            sucursales.setAdapter(sucursalesAdapter);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }


    private void llenarAlmacenes(String result){

        try {

            List<String> almacenesArray = new ArrayList<String>();
            almacenesJson = new JSONArray(result);

            for(int contadorAlmacenes = 0;contadorAlmacenes < almacenesJson.length();contadorAlmacenes++){
                almacenesArray.add(almacenesJson.getJSONObject(contadorAlmacenes).getString("nombre"));
            }

            ArrayAdapter<String> almacenesAdapter = new ArrayAdapter<String>(
                    context, android.R.layout.simple_spinner_item, almacenesArray);

            almacenesAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            almancenes.setAdapter(almacenesAdapter);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }


    }

    public void login(View v){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Utils/ValorRef");
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(context));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(false);
                    httpUrlConn.setDoInput(true);
                    httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

                    Log.i(TAG, httpUrlConn.getURL().toString());
                    httpUrlConn.connect();
                    if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        InputStream is = httpUrlConn.getInputStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        Log.i(TAG, result);
                    } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                        errorToken = true;
                    } else {
                        result = null;
                    }

                    return result;

                }catch (SocketTimeoutException e){
                    return getString(R.string.error_servidor_lbl);
                } catch (Exception e) {
                    Log.e(TAG,e.getMessage(),e);
                    return null;
                }
            }

            @Override
            public void after(String result) {

                Realm realm = null;
                try {

                    JSONArray referencesJson = new JSONArray(result);
                    realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
                    realm.beginTransaction();
                    realm.where(ValorReferencia.class).findAll().deleteAllFromRealm();
                    realm.createAllFromJson(ValorReferencia.class, referencesJson);
                    realm.commitTransaction();

                    MetodosEstaticos.guardarCompaniaClave(context,sucursalesJson.getJSONObject(sucursales.getSelectedItemPosition()).getString("COMClave"));
                    MetodosEstaticos.guardarSucursal(context, sucursalesJson.getJSONObject(sucursales.getSelectedItemPosition()).getString("clave"), sucursalesJson.getJSONObject(sucursales.getSelectedItemPosition()).getString("nombre"), sucursalesJson.getJSONObject(sucursales.getSelectedItemPosition()).getBoolean("ubicacionRecibo"));
                    MetodosEstaticos.guardarAlmacen(context, almacenesJson.getJSONObject(almancenes.getSelectedItemPosition()).getString("clave"), almacenesJson.getJSONObject(almancenes.getSelectedItemPosition()).getString("nombre"));

                    finish();
                    Intent main = new Intent(context,MainActivity.class);
                    startActivity(main);

                } catch (JSONException e) {
                    Toast.makeText(context,e.getMessage(),Toast.LENGTH_LONG).show();
                } catch (Exception e) {
                    Toast.makeText(context,e.getMessage(),Toast.LENGTH_LONG).show();
                    realm.cancelTransaction();
                }


            }
        }).execute();
    }

    @Override
    public void before() {

    }

    @Override
    public String toDo() {
        try {
            URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Sucursal/Almacenes/" + sucursalesJson.getJSONObject(sucursales.getSelectedItemPosition()).getString("clave"));
            URLConnection urlConnection = url.openConnection();
            String result = null;

            HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setRequestProperty("Authorization",MetodosEstaticos.obtenerToken(context));
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(false);
            httpUrlConn.setDoInput(true);
            httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

            Log.i(TAG, httpUrlConn.getURL().toString());
            httpUrlConn.connect();
            if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                InputStream is = httpUrlConn.getInputStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
                Log.i(TAG, result);
            } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                errorToken = true;
            } else {
                result = null;
            }

            return result;

        }catch (SocketTimeoutException e){
            return getString(R.string.error_servidor_lbl);
        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
            return null;
        }
    }

    @Override
    public void after(String result) {

        if(errorToken){
            Toast.makeText(context,context.getString(R.string.token_error_lbl),Toast.LENGTH_SHORT).show();
            MetodosEstaticos.limpiarSesion(context);
        } else {

            if(result != null){
                try{
                    JSONArray aux = new JSONArray(result);
                    llenarAlmacenes(result);

                } catch (Exception e){
                    Toast.makeText(context, result, Toast.LENGTH_SHORT).show();
                }
            } else {
                Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
            }
        }
    }
}
