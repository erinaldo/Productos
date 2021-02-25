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
import android.widget.ListView;
import android.widget.Toast;

import com.selling.movil.fragments.AndenesFragment;
import com.selling.movil.fragments.LeerMaterialCantidadFragment;
import com.selling.movil.fragments.LeerUbicacionDetalleProductoFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.modelos.ValorReferencia;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.Dialogs;
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
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import io.realm.Realm;
import io.realm.RealmResults;


public class ReciboActivity extends FragmentActivity implements OnAceptarListener,
                                                                OnLeerCodigoMaterialListener,
                                                                OnLeerCodigoUbicacionListener{

    private final String TAG = ReciboActivity.class.getName();
    private Context context = ReciboActivity.this;

    private String idRecibo;
    private String codigoMaterial;
    private String cantidadMaterial;

    private AndenesFragment andenesFragment;
    private LeerMaterialCantidadFragment leerMaterialCantidadFragment;
    private LeerUbicacionDetalleProductoFragment leerUbicacionDetalleProductoFragment;

    private Realm realm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reubicacion);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_recibo));
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        setInitFragment();
    }

    private void setInitFragment(){

        andenesFragment = AndenesFragment.newInstance();


        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, andenesFragment);
        fragmentTransaction.commit();

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

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/VerificaRecibo?IdRecibo="+ idRecibo +
                            "&"+ValoresEstaticos.PARAMETRO_PRODUCTO+"="+codigoMaterial+
                            "&cantidad="+cantidadMaterial);
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

                                if(aux.has("enProceso")){
                                    Toast.makeText(context,context.getString(R.string.recibo_finalizado_lbl),Toast.LENGTH_SHORT).show();
                                    finish();
                                } else {
                                    ReciboActivity.this.codigoMaterial = codigoMaterial;
                                    ReciboActivity.this.cantidadMaterial = cantidadMaterial;
                                    showFragmentUbicacion(result);
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
            }
        }).execute();
    }

    private void showFragmentUbicacion(String result){
        leerUbicacionDetalleProductoFragment = LeerUbicacionDetalleProductoFragment.newInstance(result,context.getString(R.string.ubicacion_leer_lbl));

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionDetalleProductoFragment);
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    private void removeFragmentUbicacion(){

        getSupportFragmentManager().popBackStackImmediate();
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
        fragmentTransaction.remove(leerUbicacionDetalleProductoFragment);
        fragmentTransaction.commit();
    }

    private void obtenerMotivoError(JSONObject result){
        showMotivoSobranteDialog(result);
    }

    private void showMotivoSobranteDialog(final JSONObject result){
        try{
            final RealmResults<ValorReferencia> valores = realm.where(ValorReferencia.class).equalTo("tabla","Recibo").equalTo("campo", "MotivoSobrante").findAll();
            final ArrayList<String> opciones = new ArrayList<>();

            for(ValorReferencia valorReferencia : valores)
                opciones.add(valorReferencia.getDescripcion());


            AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            View convertView = inflater.inflate(R.layout.dialog_list, null);
            alertDialog.setView(convertView);
            alertDialog.setCancelable(false);
            alertDialog.setTitle(result.get("mensaje").toString() +"\n"+context.getString(R.string.dialog_list_title));
            ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(context,android.R.layout.simple_list_item_1,opciones);
            opcionesList.setAdapter(adapter);
            final AlertDialog dialog = alertDialog.create();

            opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {


                    enviarMotivoSobrante(result, valores.get(position).getValor());
                    dialog.dismiss();
                }
            });

            dialog.show();

        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }

    }

    private void enviarMotivoSobrante(final JSONObject detalleProducto, final int motivoSobrante){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/MotivoSobrante?idReciboSobrante="+ detalleProducto.get("idReciboSobrante") +
                            "&MotivoSobrante="+Integer.toString(motivoSobrante));
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
                            Boolean envio = Boolean.valueOf(result);
                            if(envio != null && envio){
                                Toast.makeText(context,context.getString(R.string.recibo_exito_lbl),Toast.LENGTH_SHORT).show();
                                removeFragmentUbicacion();
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

    private void validaUbicacion(final String codigoUbicacion, final boolean crearUbicacion){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/Recibo?IdRecibo="+ idRecibo +
                            "&"+ValoresEstaticos.PARAMETRO_PRODUCTO+"="+codigoMaterial+
                            "&cantidad="+cantidadMaterial+
                            "&"+ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context)+
                            "&"+ValoresEstaticos.PARAMETRO_UBICACION+"="+codigoUbicacion+
                            "&crearUBC="+Boolean.toString(crearUbicacion));
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

                                if(aux.has("enProceso")){
                                    Toast.makeText(context,context.getString(R.string.recibo_finalizado_lbl),Toast.LENGTH_SHORT).show();
                                    finish();
                                } else if(aux.has("idReciboSobrante")){
                                    obtenerMotivoError(aux);
                                } else if(aux.has("ubicacionNoExiste")){
                                    if(codigoUbicacion.startsWith("T")){
                                        if(MetodosEstaticos.obtenerSucursalUbicacionRecibo(context)){
                                            Dialogs.confirmDialog(context,context.getString(R.string.recibo_crear_ubicacion_lbl), new DialogInterface.OnClickListener() {
                                                        @Override
                                                        public void onClick(DialogInterface dialog, int which) {
                                                            validaUbicacion(codigoUbicacion, true);
                                                        }
                                                    },
                                                    new DialogInterface.OnClickListener() {
                                                        @Override
                                                        public void onClick(DialogInterface dialog, int which) {
                                                            dialog.dismiss();
                                                        }
                                                    });
                                        }else{
                                            Toast.makeText(context,context.getString(R.string.recibo_sucursal_ubicacion_recibo_error), Toast.LENGTH_LONG ).show();
                                        }

                                    }else{
                                        Toast.makeText(context,context.getString(R.string.recibo_ubicacion_no_existe), Toast.LENGTH_LONG ).show();
                                    }


                                } else {
                                    Toast.makeText(context,context.getString(R.string.recibo_exito_lbl),Toast.LENGTH_SHORT).show();
                                    removeFragmentUbicacion();
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

            }
        }).execute();
    }


    @Override
    public void onAceptar(String... parametros) {
        idRecibo = parametros[0];

        leerMaterialCantidadFragment = LeerMaterialCantidadFragment.newInstance();

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialCantidadFragment);
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
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
                Log.e(TAG,e.getMessage(),e);
            }




        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onCodigoUbicacionLeido(String... parametros) {
        String codigoUbicacion = parametros[0];

        if (codigoUbicacion.length() > 0) {

            try {
                codigoUbicacion = MetodosEstaticos.getEncodedData(codigoUbicacion);
                validaUbicacion(codigoUbicacion, false);
            } catch (Exception e) {

                Log.e(TAG,e.getMessage(),e);
            }

        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }
}
