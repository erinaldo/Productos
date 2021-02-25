package com.selling.movil;

import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;


import com.selling.movil.fragments.DetalleProductoCambioEstadoFragment;
import com.selling.movil.fragments.LeerMaterialFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONObject;

import java.io.BufferedWriter;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;


public class CambioEstadoActivity extends FragmentActivity implements OnLeerCodigoUbicacionListener,
                                                                        OnLeerCodigoMaterialListener,
                                                                        OnAceptarListener{

    private final String TAG = CambioEstadoActivity.class.getName();
    private Context context = CambioEstadoActivity.this;

    private LeerUbicacionFragment leerUbicacionFragment;
    private LeerMaterialFragment leerMaterialFragment;
    private DetalleProductoCambioEstadoFragment detalleProductoCambioEstadoFragment;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cambio_estado);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_estado));

        setInitFragment();
    }

    private void setInitFragment(){

        leerUbicacionFragment = LeerUbicacionFragment.newInstance(true,context.getString(R.string.ubicacion_leer_lbl));


        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionFragment);
        fragmentTransaction.commit();

    }


    private void validaUbicacion(final String codigoUbicacion){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/ValidarUbicacionCambioEstado?id=" + codigoUbicacion+
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
                            Boolean ubicacionValida = Boolean.valueOf(result);
                            if(ubicacionValida != null && ubicacionValida){
                                leerMaterialFragment = LeerMaterialFragment.newInstance(codigoUbicacion);

                                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                                fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialFragment);
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

    private void validaMaterial(final String codigoUbicacion,final String codigoMaterial){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/VerificaUbicacionCambioEstado?"+ValoresEstaticos.PARAMETRO_UBICACION+"=" + codigoUbicacion+"&"+ValoresEstaticos.PARAMETRO_PRODUCTO+"="+codigoMaterial+
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
                            JSONObject aux = new JSONObject(result);
                            if(aux != null && !aux.has("Message")){
                                detalleProductoCambioEstadoFragment = DetalleProductoCambioEstadoFragment.newInstance(result, codigoUbicacion);

                                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                                fragmentTransaction.replace(R.id.layoutCambioEstado, detalleProductoCambioEstadoFragment);
                                fragmentTransaction.addToBackStack(null);
                                fragmentTransaction.commit();
                            } else {
                                Toast.makeText(context, aux.getString("Message"), Toast.LENGTH_SHORT).show();
                            }


                        } catch (Exception e){
                            Toast.makeText(context, result, Toast.LENGTH_SHORT).show();
                        }
                    } else {
                        Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();




    }

    private void cambiarEstado(final String codigoUbicacion, final String codigoMaterial, final String bloqueado){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/ModificarProductoEstado");
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(context));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(true);
                    httpUrlConn.setDoInput(true);
                    httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

                    Map<String, String> parameters = new HashMap<>();
                    parameters.put("UBCClave", codigoUbicacion);
                    parameters.put("PROClave", codigoMaterial);
                    parameters.put("ALMClave", MetodosEstaticos.obtenerAlmacenClave(context));
                    parameters.put("Bloquear", bloqueado);
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
                            Double afectados = Double.valueOf(result);
                            if(afectados != null){
                                Toast.makeText(context, Double.toString(afectados)+" "+context.getString(R.string.productos_afectados_lbl), Toast.LENGTH_SHORT).show();
                                finish();
                            } else {
                                Toast.makeText(context, result, Toast.LENGTH_SHORT).show();
                            }


                        } catch (Exception e){
                            try {
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                            } catch (Exception ex){
                                Log.e(TAG,e.getMessage(),e);
                            }
                        }
                    } else {
                        Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }

            }
        }).execute();
    }

    @Override
    public void onCodigoUbicacionLeido(String... parametros){
        try {
            String codigoUbicacion = parametros[0];
            if (codigoUbicacion.length() > 0) {

                codigoUbicacion = MetodosEstaticos.getEncodedData(codigoUbicacion);
                validaUbicacion(codigoUbicacion);

            } else {
                Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
            }
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }

    @Override
    public void onCodigoMaterialLeido(String... parametros) {

        try {

            String codigoUbicacion = parametros[0];
            String codigoMaterial = parametros[1];

            if (codigoMaterial.length() > 0) {

                codigoMaterial = MetodosEstaticos.getEncodedData(codigoMaterial);

                validaMaterial(codigoUbicacion,codigoMaterial);


            } else {
                Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
            }

        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }

    @Override
    public void onAceptar(String... parametros) {

        try {

            String codigoUbicacion = parametros[0];
            String codigoMaterial = parametros[1];
            String bloqueado = parametros[2];

            bloqueado = MetodosEstaticos.getEncodedData(bloqueado);

            cambiarEstado(codigoUbicacion,codigoMaterial,bloqueado);

        } catch (Exception e){
            Log.e(TAG, e.getMessage(), e);
        }

    }
}
