package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.selling.movil.fragments.LeerMaterialCantidadFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.modelos.Reubicacion;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.Dialogs;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.apache.commons.lang3.math.NumberUtils;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedWriter;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class AjusteInventarioActivity extends FragmentActivity implements OnLeerCodigoUbicacionListener,
                                                                        OnLeerCodigoMaterialListener{

    private final String TAG = AjusteInventarioActivity.class.getName();
    private Context context = AjusteInventarioActivity.this;

    private LeerUbicacionFragment leerUbicacionOrigenFragment;
    private LeerMaterialCantidadFragment leerMaterialCantidadFragment;

    private String codigoUbicacionOrigen;
    private String codigoMaterial;
    private String cantidadMaterial;
    private String user="";
    private String pass="";
    private boolean procesando = false;
    private String lecturaAnt="";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ajuste_inventario);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_ajuste_inventario));
        setInitFragment();
    }

    private void setInitFragment(){

        leerUbicacionOrigenFragment = LeerUbicacionFragment.newInstance(true,context.getString(R.string.ubicacion_leer_lbl));


        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionOrigenFragment);
        fragmentTransaction.commit();

    }

    private void validaUbicacionOrigen(final String codigoUbicacion){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;

            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/ValidarAjusteInventario?" +
                                                                ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context)+
                                                                "&Ubicacion="+codigoUbicacion);
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
                        result = "true";
                    } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                        errorToken = true;
                    }  else if(httpUrlConn.getErrorStream() != null){
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getErrorStream());
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
                            Boolean ubicacionValida = Boolean.valueOf(result);
                            if(ubicacionValida != null && ubicacionValida){
                                codigoUbicacionOrigen = codigoUbicacion;
                                leerMaterialCantidadFragment = LeerMaterialCantidadFragment.newInstance();

                                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                                fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialCantidadFragment);
                                fragmentTransaction.addToBackStack(null);
                                fragmentTransaction.commit();
                            } else
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                        } catch (Exception e){
                            Log.e(TAG,e.getMessage(),e);
                        }
                    } else {
                        Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();

    }

    private void validaMaterial(final String codigoMaterial,final String cantidadMaterial){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/AjustarInventario?"+
                                                                        "Ubicacion=" + codigoUbicacionOrigen+
                                                                        "&Producto="+codigoMaterial+
                                                                        "&cantidad="+cantidadMaterial+
                                                                        "&Login="+user+
                                                                        "&Password="+pass+
                                                                        "&"+ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context)+
                                                                        "&SUCClave="+MetodosEstaticos.obtenerSucursalClave(context)+
                                                                        "&COMClave="+MetodosEstaticos.obtenerCompaniaClave(context));
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
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getInputStream());
                    } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                        errorToken = true;
                    } else if(httpUrlConn.getErrorStream() != null){
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getErrorStream());
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
                            JSONObject aux = new JSONObject(result);
                            if(aux != null && !aux.has("Message")){

                                Log.i(TAG, aux.toString());

                                if(aux.has("errorAutenticacion")){

                                    Toast.makeText(context,aux.getString("errorAutenticacion"),Toast.LENGTH_SHORT).show();
                                    obtenerAutorizacion(aux);

                                } else if(aux.has("autorizados")){

                                    AjusteInventarioActivity.this.codigoMaterial = codigoMaterial;
                                    AjusteInventarioActivity.this.cantidadMaterial = cantidadMaterial;
                                    obtenerAutorizacion(aux);

                                } else if(aux.has("Exito")){

                                    Toast.makeText(context,context.getString(R.string.ajuste_inventario_ok_lbl),Toast.LENGTH_SHORT).show();
                                    finish();

                                } else {

                                    Toast.makeText(context,context.getString(R.string.ajuste_inventario_sin_cambios_lbl),Toast.LENGTH_SHORT).show();
                                    finish();

                                }
                            } else
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                        } catch (Exception e){
                            Log.e(TAG, e.getMessage(), e);
                        }
                    } else {
                        Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
                procesando = false;
            }
        }).execute();




    }

    private void obtenerAutorizacion(JSONObject result){
        showAutorizacionDialog(result);
    }

    private void showAutorizacionDialog(final JSONObject result){

        try{

            final ArrayList<String> autorizados = new ArrayList<>();
            JSONArray autorizadosJson = result.getJSONArray("autorizados");

            for(int contadorAutorizado = 0;contadorAutorizado < autorizadosJson.length();contadorAutorizado++ )
                autorizados.add(autorizadosJson.getString(contadorAutorizado));

            ArrayAdapter<String> autorizadosAdapter = new ArrayAdapter<String>(
                    context, android.R.layout.simple_spinner_item, autorizados);
            autorizadosAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

            String mensaje = "Se realizará el ajuste de "+result.getString("diferencia")+" piezas\n" +
                    "Producto: " + result.getString("Clave")+"\n"+
                    "Descripción: " + result.getString("Descripcion")+"\n"+
                    "Ubicación: "+result.getString("Ubicacion");

            LayoutInflater layoutInflater = LayoutInflater.from(context);
            View promptView = layoutInflater.inflate(R.layout.dialog_autorizacion, null);
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(context);
            alertDialogBuilder.setView(promptView);

            final Spinner autorizadosSpinner = (Spinner) promptView.findViewById(R.id.autorizadosSpinner);
            autorizadosSpinner.setAdapter(autorizadosAdapter);
            final TextView mensajeTv = (TextView) promptView.findViewById(R.id.mensajeAutorizar);
            mensajeTv.setText(mensaje);
            final EditText passTv = (EditText) promptView.findViewById(R.id.pass);

            alertDialogBuilder
                    .setCancelable(false)
                    .setNegativeButton(context.getString(R.string.dialog_cancelar_lbl), new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                        }
                    })
                    .setPositiveButton(context.getString(R.string.dialog_guardar_lbl), new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            if(!passTv.getText().toString().equalsIgnoreCase("")) {
                                AjusteInventarioActivity.this.user = autorizadosSpinner.getSelectedItem().toString();
                                AjusteInventarioActivity.this.pass = passTv.getText().toString();
                                validaMaterial(codigoMaterial,cantidadMaterial);
                            }
                            else {
                                Toast.makeText(context, context.getString(R.string.dialog_pass_error_lbl), Toast.LENGTH_SHORT).show();
                                obtenerAutorizacion(result);
                            }
                        }
                    });

            AlertDialog alertD = alertDialogBuilder.create();

            alertD.show();

        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }

    @Override
    public void onCodigoUbicacionLeido(String... parametros) {
        String codigoUbicacion = parametros[0];

        if (codigoUbicacion.length() > 0) {

            try {

                codigoUbicacion = MetodosEstaticos.getEncodedData(codigoUbicacion);
                validaUbicacionOrigen(codigoUbicacion);
            } catch (Exception e){
                Log.e(TAG,e.getMessage(),e);
            }

        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public String getLecturaAnt() {
        return lecturaAnt;
    }

    public void setLecturaAnt(String... parametros){
        lecturaAnt = (lecturaAnt.equals(parametros[0]) ? parametros[0] : parametros[0].replaceFirst(lecturaAnt,""));
    }

    @Override
    public void onCodigoMaterialLeido(String... parametros) {
        if (!procesando) {
            procesando = true;
            String codigoMaterial = parametros[0];
            String cantidadMaterial = parametros[1];

            if (codigoMaterial.length() > 0) {
                try {
                    codigoMaterial = MetodosEstaticos.getEncodedData(codigoMaterial);
                    cantidadMaterial = MetodosEstaticos.getEncodedData(cantidadMaterial);

                    validaMaterial(codigoMaterial, cantidadMaterial);
                } catch (Exception e) {
                    procesando = false;
                    Log.e(TAG, e.getMessage(), e);
                }

            } else {
                procesando = false;
                Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
            }
        }
    }

    @Override
    public void setMaterialAnt(String... parametros) {
        lecturaAnt = (lecturaAnt.equals(parametros[0]) ? parametros[0] : parametros[0].replaceFirst(lecturaAnt,""));
    }

    @Override
    public String getMaterialAnt() {
        return lecturaAnt;
    }

    @Override
    public ArrayList<Reubicacion> getArrayReubicacion() {
        return null;
    }



}
