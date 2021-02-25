package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.selling.movil.fragments.DetalleProductoCambioEstadoFragment;
import com.selling.movil.fragments.DetalleProductoHuellaFragment;
import com.selling.movil.fragments.LeerMaterialCantidadFragment;
import com.selling.movil.fragments.LeerUbicacionAlmacenajeDirigidoFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
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

public class AlmacenajeActivity extends FragmentActivity implements OnLeerCodigoUbicacionListener,
                                                                        OnLeerCodigoMaterialListener,
                                                                    OnAceptarListener{

    private final String TAG = AlmacenajeActivity.class.getName();
    private Context context = AlmacenajeActivity.this;
    private String TIPO_ALMACENAJE;

    private LeerUbicacionFragment leerUbicacionOrigenFragment;
    private LeerUbicacionFragment leerUbicacionDestinoFragment;
    private LeerMaterialCantidadFragment leerMaterialCantidadFragment;
    private DetalleProductoHuellaFragment detalleProductoHuellaFragment;
    private LeerUbicacionAlmacenajeDirigidoFragment leerUbicacionAlmacenajeDirigidoFragment;

    private String codigoUbicacionOrigen;
    private String codigoMaterial;
    private String cantidadMaterial;
    private String lecturaAnt = "";
    private String MaterialAnt = "";

    private int opcionUbicacion;
    private String claveUbicacionFija;
    private String detalleProductoJson;
    private boolean procesando = false;

    private void removeFragmentUbicacionDestino(){

        getSupportFragmentManager().popBackStackImmediate();
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
        fragmentTransaction.remove(leerUbicacionDestinoFragment);
        fragmentTransaction.commit();
    }

    private void removeFragmentMaterialCantidad(){

        getSupportFragmentManager().popBackStackImmediate();
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
        fragmentTransaction.remove(leerMaterialCantidadFragment);
        fragmentTransaction.commit();
    }

    private void showFragmentMaterialCantidad() {
        leerMaterialCantidadFragment = LeerMaterialCantidadFragment.newInstance();

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialCantidadFragment);
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_almacenaje);
        TIPO_ALMACENAJE = getIntent().getExtras().getString("tipoAlmacenaje",null);
        opcionUbicacion = getIntent().getExtras().getInt("tipoUbicacion", 0);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_almacenaje) + " - " + TIPO_ALMACENAJE);
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

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/ValidarUbicacionAlmacenaje?id=" + codigoUbicacion+
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

                                //if (opcionUbicacion == ValoresEstaticos.OPCION_UBICACION_FIJA)
                                    //removeFragmentUbicacionOrigen();
                                showFragmentMaterialCantidad();

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
                    detalleProductoJson = "";
                    MaterialAnt = lecturaAnt;
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/VerificaOrigenAlmacenaje?"+ValoresEstaticos.PARAMETRO_UBICACION+"=" + codigoUbicacionOrigen+
                                                                        "&"+ValoresEstaticos.PARAMETRO_PRODUCTO+"="+codigoMaterial+"&cantidad="+cantidadMaterial+
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
                                detalleProductoJson = result;
                                AlmacenajeActivity.this.codigoMaterial = codigoMaterial;
                                AlmacenajeActivity.this.cantidadMaterial = cantidadMaterial;

                                if(TIPO_ALMACENAJE.equals(ValoresEstaticos.ALMACENAJE_DIRIGIDO)){
                                    obtenerUbicacionesDirigido();
                                } else {
                                    detalleProductoHuellaFragment = DetalleProductoHuellaFragment.newInstance(result, null, context.getString(R.string.leer_codigo_ubicacion_lbl));
                                    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                    fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                                    fragmentTransaction.replace(R.id.layoutCambioEstado, detalleProductoHuellaFragment);
                                    fragmentTransaction.addToBackStack(null);
                                    fragmentTransaction.commit();
                                }
                            } else {
                                Toast.makeText(context, aux.getString("Message"), Toast.LENGTH_SHORT).show();
                            }

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

    private void validaUbicacionDestino(final String codigoUbicacionDestino){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/MoverAlmacenajeNoDirigido?"
                            +ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context)+
                            "&UbicacionTransito="+codigoUbicacionOrigen+
                            "&UbicacionAlmacenaje="+codigoUbicacionDestino+
                            "&Producto="+codigoMaterial+
                            "&cantidad="+cantidadMaterial+
                            "&SUCClave="+MetodosEstaticos.obtenerSucursalClave(context)+
                            "&COMClave="+MetodosEstaticos.obtenerCompaniaClave(context)

                            );
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

                            if(NumberUtils.isNumber(result)){

                                Double afectados = Double.valueOf(result);
                                Toast.makeText(context, Double.toString(afectados)+" "+context.getString(R.string.productos_afectados_lbl), Toast.LENGTH_SHORT).show();
                                //finish();
                                if (opcionUbicacion == ValoresEstaticos.OPCION_UBICACION_FIJA)
                                {
                                    //removeFragmentUbicacionDestino();
                                    lecturaAnt = MaterialAnt;
                                    returnToMaterialFragment();
                                    /*leerMaterialCantidadFragment = LeerMaterialCantidadFragment.newInstance();
                                    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                    fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                                    fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialCantidadFragment);
                                    fragmentTransaction.addToBackStack(null);
                                    fragmentTransaction.commit();*/
                                }
                                else {
                                    returnFirstFragment();
                                }
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

    private void obtenerUbicacionesDirigido(){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/AlmacenajeDirigido?"+
                            "Producto="+codigoMaterial+
                            "&cantidad="+cantidadMaterial+
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

                                if(!aux.has("encontrado")){

                                    detalleProductoHuellaFragment = DetalleProductoHuellaFragment.newInstance(detalleProductoJson, result, context.getString(R.string.almacenaje_confirmar_ubicacion_lbl));
                                    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                    fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                                    fragmentTransaction.replace(R.id.layoutCambioEstado, detalleProductoHuellaFragment);
                                    fragmentTransaction.addToBackStack(null);
                                    fragmentTransaction.commit();

                                    //leerUbicacionAlmacenajeDirigidoFragment = LeerUbicacionAlmacenajeDirigidoFragment.newInstance(result,context.getString(R.string.almacenaje_confirmar_ubicacion_lbl));

                                    //FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                    //fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
                                    //fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionAlmacenajeDirigidoFragment);
                                    //fragmentTransaction.addToBackStack(null);
                                    //fragmentTransaction.commit();
                                } else {
                                    Toast.makeText(context, context.getString(R.string.almacenaje_dirigido_no_espacio_msg), Toast.LENGTH_SHORT).show();
                                    getSupportFragmentManager().popBackStackImmediate();
                                    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                                    fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
                                    fragmentTransaction.remove(detalleProductoHuellaFragment);
                                    fragmentTransaction.commit();
                                }


                            } else {
                                Toast.makeText(context, aux.getString("Message"), Toast.LENGTH_SHORT).show();
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

    private void returnFirstFragment(){

        getSupportFragmentManager().popBackStack(getSupportFragmentManager().getBackStackEntryAt(0).getId(), getSupportFragmentManager().POP_BACK_STACK_INCLUSIVE);
    }

    private void returnToMaterialFragment(){
        getSupportFragmentManager().popBackStack(getSupportFragmentManager().getBackStackEntryAt(1).getId(), getSupportFragmentManager().POP_BACK_STACK_INCLUSIVE);
        leerMaterialCantidadFragment.restart();
    }

    @Override
    public void onCodigoUbicacionLeido(String... parametros) {

        try {

            final String codigoUbicacion = MetodosEstaticos.getEncodedData(parametros[0].replaceAll("\\-","").trim());
            Boolean ubicacionOrigen = Boolean.valueOf(parametros[1]);

            if (codigoUbicacion.length() > 0) {
                if(ubicacionOrigen) {
                    validaUbicacionOrigen(codigoUbicacion);
                }
                else
                {
                    if(Boolean.valueOf(parametros[2])) //Dirigido
                    {
                        if(codigoUbicacion.equalsIgnoreCase( MetodosEstaticos.getEncodedData(parametros[3].replaceAll("\\-","").trim()) )){
                            validaUbicacionDestino(codigoUbicacion);
                        } else {
                            Dialogs.confirmDialog(context, context.getString(R.string.almacenaje_confirmar_ubicacion_diferente_lbl), new DialogInterface.OnClickListener() {
                                        @Override
                                        public void onClick(DialogInterface dialog, int which) {
                                            validaUbicacionDestino(codigoUbicacion);
                                        }
                                    },
                                    new DialogInterface.OnClickListener() {
                                        @Override
                                        public void onClick(DialogInterface dialog, int which) {
                                            dialog.dismiss();
                                        }
                                    });
                        }
                    } else {
                       validaUbicacionDestino(codigoUbicacion);
                    }
                }

            } else {
                Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
            }

        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
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
    public void onAceptar(String... parametros) {

        boolean huellaCompleta = Boolean.parseBoolean(parametros[0]);
        if(huellaCompleta){
            if(TIPO_ALMACENAJE.equals(ValoresEstaticos.ALMACENAJE_DIRIGIDO)){
                obtenerUbicacionesDirigido();
            } else {
                leerUbicacionDestinoFragment = LeerUbicacionFragment.newInstance(false,context.getString(R.string.ubicacion_leer_destino_lbl));

                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionDestinoFragment);
                fragmentTransaction.addToBackStack(null);
                fragmentTransaction.commit();
            }
        } else {
            getSupportFragmentManager().popBackStackImmediate();
            FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
            fragmentTransaction.remove(detalleProductoHuellaFragment);
            fragmentTransaction.commit();
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
