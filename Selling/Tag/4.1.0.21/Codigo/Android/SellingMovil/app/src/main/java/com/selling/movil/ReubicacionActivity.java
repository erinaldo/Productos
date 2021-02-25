package com.selling.movil;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.widget.Toast;

import com.selling.movil.fragments.LeerMaterialCantidadFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.apache.commons.lang3.math.NumberUtils;
import org.json.JSONObject;

import java.io.BufferedWriter;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.HashMap;
import java.util.Map;


public class ReubicacionActivity extends FragmentActivity implements OnLeerCodigoUbicacionListener,
                                                                        OnLeerCodigoMaterialListener{

    private final String TAG = ReubicacionActivity.class.getName();
    private Context context = ReubicacionActivity.this;

    private LeerUbicacionFragment leerUbicacionOrigenFragment;
    private LeerUbicacionFragment leerUbicacionDestinoFragment;
    private LeerMaterialCantidadFragment leerMaterialCantidadFragment;

    private String codigoUbicacionOrigen;
    private String codigoMaterial;
    private String cantidadMaterial;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reubicacion);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_reubicacion));
        setInitFragment();
    }

    private void setInitFragment(){

        leerUbicacionOrigenFragment = LeerUbicacionFragment.newInstance(true,context.getString(R.string.ubicacion_leer_origen_lbl));


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

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/ValidarOrigenReubicacion?id=" + codigoUbicacion+
                                                                        "&"+ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context));
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

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/VerificaReubicacion?"+ValoresEstaticos.PARAMETRO_UBICACION+"=" + codigoUbicacionOrigen+
                                                                        "&"+ValoresEstaticos.PARAMETRO_PRODUCTO+"="+codigoMaterial+
                                                                        "&"+ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context));
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
                            Boolean materialValido = Boolean.valueOf(result);
                            if(materialValido != null && materialValido){
                                ReubicacionActivity.this.codigoMaterial = codigoMaterial;
                                ReubicacionActivity.this.cantidadMaterial = cantidadMaterial;
                                leerUbicacionDestinoFragment = LeerUbicacionFragment.newInstance(false,context.getString(R.string.ubicacion_leer_destino_lbl));

                                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                                fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionDestinoFragment);
                                fragmentTransaction.addToBackStack(null);
                                fragmentTransaction.commit();
                            } else
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                        } catch (Exception e){
                            Log.e(TAG, e.getMessage(), e);
                        }
                    } else {
                        Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();




    }

    private void validaUbicacionDestino(final String codigoUbicacionDestino){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/MoverProductoReubicacion");
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(context));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(true);
                    httpUrlConn.setDoInput(true);
                    httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

                    Map<String, String> parameters = new HashMap<>();
                    parameters.put("origenUBCClave", codigoUbicacionOrigen);
                    parameters.put("destinoUBCClave", codigoUbicacionDestino);
                    parameters.put("PROClave", codigoMaterial);
                    parameters.put("ALMClave", MetodosEstaticos.obtenerAlmacenClave(context));
                    parameters.put("cantidad", cantidadMaterial);
                    parameters.put("SUCClave", MetodosEstaticos.obtenerSucursalClave(context));
                    parameters.put("COMClave", MetodosEstaticos.obtenerCompaniaClave(context));

                    String parameterString = MetodosEstaticos.getEncodedData(parameters);

                    OutputStream os = httpUrlConn.getOutputStream();
                    BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));
                    writer.write(parameterString);
                    writer.flush();
                    writer.close();
                    os.close();

                    Log.i(TAG, httpUrlConn.getURL().toString());
                    httpUrlConn.connect();
                    if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        InputStream is = httpUrlConn.getInputStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        Log.i(TAG, result);
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

                            if(NumberUtils.isNumber(result)){

                                Double afectados = Double.valueOf(result);
                                Toast.makeText(context, Double.toString(afectados)+" "+context.getString(R.string.productos_afectados_lbl), Toast.LENGTH_SHORT).show();
                                finish();
                            } else {
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                            }


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

    @Override
    public void onCodigoUbicacionLeido(String... parametros) {
        String codigoUbicacion = parametros[0];
        Boolean ubicacionOrigen = Boolean.valueOf(parametros[1]);

        if (codigoUbicacion.length() > 0) {

            try {

                codigoUbicacion = MetodosEstaticos.getEncodedData(codigoUbicacion);

                if(ubicacionOrigen)
                    validaUbicacionOrigen(codigoUbicacion);
                else
                    validaUbicacionDestino(codigoUbicacion);

            } catch (Exception e) {
                Log.e(TAG,e.getMessage(),e);
            }



        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onCodigoMaterialLeido(String... parametros) {
        String codigoMaterial = parametros[0];
        String cantidadMaterial = parametros[1];

        if (codigoMaterial.length() > 0) {

            try {

                codigoMaterial = MetodosEstaticos.getEncodedData(codigoMaterial);
                cantidadMaterial = MetodosEstaticos.getEncodedData(cantidadMaterial);

                validaMaterial(codigoMaterial,cantidadMaterial);

            } catch (Exception e) {
                Log.e(TAG, e.getMessage(), e);
            }


        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }

}
