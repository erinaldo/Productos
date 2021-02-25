package com.selling.movil;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ViewAnimator;

import com.selling.movil.fragments.LeerMaterialCantidadFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.modelos.Reubicacion;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.apache.commons.lang3.ClassUtils;
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
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
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
    private ArrayList<Reubicacion> codigoMat = new ArrayList<Reubicacion>();
    private String cantidadMaterial;
    private String cantMaterialString;
    private boolean procesando = false;
    private String lecturaAnt = "";
    private ListView list;
    private int ubicacionLista = -1;
    private String codigoUbicacionDestino;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reubicacion);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_reubicacion));
        MetodosEstaticos.guardarConteoNormal(context, true);
        setInitFragment();
        list = (ListView)findViewById(R.id.listCodigos);
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
                        InputStream is = httpUrlConn.getInputStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        //result = "true";
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
                            //Boolean materialValido = Boolean.valueOf(result);
                            JSONObject aux = new JSONObject(result);

                            //if(materialValido != null && materialValido){
                            if(aux != null && !aux.has("Message")){
                                ReubicacionActivity.this.codigoMaterial = codigoMaterial;
                                ReubicacionActivity.this.cantidadMaterial = cantidadMaterial;

                                int busqueda = buscarCodigo(codigoMaterial);
                                if (busqueda < 0)
                                    ReubicacionActivity.this.codigoMat.add(new Reubicacion(codigoMaterial,cantidadMaterial,false,aux.getString("Nombre") +" "+ aux.getString("Talla"), ValoresEstaticos.ACTIVITY_REUBICACION));
                                else
                                    ReubicacionActivity.this.codigoMat.set(busqueda, new Reubicacion(codigoMaterial,String.valueOf(Integer.parseInt(codigoMat.get(busqueda).getCantidad()) + Integer.parseInt(cantidadMaterial)),codigoMat.get(busqueda).isSeleccionado(),
                                                                                                        codigoMat.get(busqueda).getUbicacion(),ValoresEstaticos.ACTIVITY_REUBICACION));

                                leerMaterialCantidadFragment.onResume();
//                                  leerUbicacionDestinoFragment = LeerUbicacionFragment.newInstance(false,context.getString(R.string.ubicacion_leer_destino_lbl));
//
//                                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
//                                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
//                                fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionDestinoFragment);
//                                fragmentTransaction.addToBackStack(null);
//                                fragmentTransaction.commit();
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
                    parameters.put("cantString", cantMaterialString);

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
                                Iterator itr = codigoMat.iterator();
                                while(itr.hasNext())
                                {
                                    Reubicacion reu = (Reubicacion)itr.next();
                                    if(reu.isSeleccionado())
                                        itr.remove();
                                }

                                if(codigoMat.size() == 0)
                                    finish();
                                else
                                    onBackPressed();
                            } else {
                                String[] respuesta = new JSONObject(result).getString("Message").split("\\(");
                                Toast.makeText(context, respuesta[0], Toast.LENGTH_SHORT).show();
                                Iterator itr = codigoMat.iterator();
                                while(itr.hasNext())
                                {
                                    Reubicacion reu = (Reubicacion)itr.next();
                                    if(reu.getCodigo().contains(respuesta[1]))
                                        break;
                                    if(reu.isSeleccionado())
                                        itr.remove();
                                }

                                if(codigoMat.size() == 0)
                                    finish();
                                else
                                    onBackPressed();

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
                else {
                    codigoUbicacionDestino = codigoUbicacion;
                    /*leerMaterialCantidadFragment = LeerMaterialCantidadFragment.newInstance();

                    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                    fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                    fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialCantidadFragment);
                    fragmentTransaction.addToBackStack(null);
                    fragmentTransaction.commit();*/
                    codigoMaterial = "";
                    cantMaterialString = "";
                    for(Reubicacion reu:codigoMat){
                        if(reu.isSeleccionado())
                        {
                            codigoMaterial += reu.getCodigo() +",";
                            cantidadMaterial = reu.getCantidad();
                            cantMaterialString += reu.getCantidad() +",";
                        }
                    }
                    codigoMaterial = codigoMaterial.substring(0,codigoMaterial.length()-1);
                    cantMaterialString= cantMaterialString.substring(0,cantMaterialString.length()-1);
                    validaUbicacionDestino(codigoUbicacion);
                }

            } catch (Exception e) {
                Log.e(TAG,e.getMessage(),e);
            }

        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }

    private int buscarCodigo(String codigo){
        int aux = 0;
        for(Reubicacion reu:codigoMat){
            if(codigo.equals(reu.getCodigo())){
                return aux;
            }
            aux++;
        }
        return -1;
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
        return codigoMat;
    }

    @Override
    public void onCodigoMaterialLeido(String... parametros) {
        if (!procesando) {
            procesando = true;
            String codigoMaterialInt = parametros[0].replaceFirst("\r","");
            String cantidadMaterialInt = parametros[1];
            String aceptar = parametros[2];
            if (aceptar == "0") {
                if (codigoMaterialInt.length() > 0) {

                    try {

                        codigoMaterialInt = MetodosEstaticos.getEncodedData(codigoMaterialInt);
                        cantidadMaterialInt = MetodosEstaticos.getEncodedData(cantidadMaterialInt);

                        validaMaterial(codigoMaterialInt, cantidadMaterialInt);

                    } catch (Exception e) {
                        procesando = false;
                        Log.e(TAG, e.getMessage(), e);
                    }

                } else {
                    procesando = false;
                    Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
                }
            }else{

                codigoMaterial = "";
                cantMaterialString = "";
                /*for(Reubicacion reu:codigoMat){
                    if(reu.isSeleccionado() && reu.getUbicacion() == "")
                    {
                        codigoMaterial += reu.getCodigo() +",";
                        cantidadMaterial = reu.getCantidad();
                        cantMaterialString += reu.getCantidad() +",";
                    }
                }
                if (codigoMaterial.length() > 0) {
                    codigoMaterial = codigoMaterial.substring(0, codigoMaterial.length() - 1);
                    cantMaterialString = cantMaterialString.substring(0, cantMaterialString.length() - 1);
                }
                validaUbicacionDestino(codigoUbicacionDestino);*/

                leerUbicacionDestinoFragment = LeerUbicacionFragment.newInstance(false,context.getString(R.string.ubicacion_leer_destino_lbl));

                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionDestinoFragment);
                fragmentTransaction.addToBackStack(null);
                fragmentTransaction.commit();
            }
        }
        procesando = false;
    }

}
