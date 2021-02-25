package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.ListPopupWindow;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.selling.movil.fragments.LeerMaterialCantidadFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.modelos.Reubicacion;
import com.selling.movil.modelos.ValorReferencia;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.Dialogs;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.apache.commons.lang3.ClassUtils;
import org.apache.commons.lang3.math.NumberUtils;
import org.json.JSONArray;
import org.json.JSONException;
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
import java.util.concurrent.ExecutionException;

import io.realm.RealmResults;
import io.realm.Realm;


/**
 * Created by aperez on 10/09/2019.
 */
public class DefectoActivity extends FragmentActivity implements OnLeerCodigoUbicacionListener,
                                                                    OnLeerCodigoMaterialListener{
    private final String TAG = DefectoActivity.class.getName();
    private Context context = DefectoActivity.this;

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
    private Realm realm;
    private int motivoDev;
    private String motivoDesc;
    private boolean fijarMotivo = false;
    private JSONArray respuestaJSON;
    private JSONObject PrvProd;
    private String productoNombre;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reubicacion);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_defecto));
        MetodosEstaticos.guardarConteoNormal(context, true);
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        setInitFragment();
        list = (ListView)findViewById(R.id.listCodigos);
    }

    private void setInitFragment(){
        leerUbicacionOrigenFragment = LeerUbicacionFragment.newInstance(true,context.getString(R.string.ubicacion_leer_lbl));

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionOrigenFragment);
        fragmentTransaction.commit();
    }


    @Override
    public void onCodigoUbicacionLeido(String... parametros) {
        String codigoUbicacion = parametros[0];
        Boolean ubicacionOrigen = Boolean.valueOf(parametros[1]);

        if (codigoUbicacion.length() > 0) {
            try {
                codigoUbicacion = MetodosEstaticos.getEncodedData(codigoUbicacion);

                if(ubicacionOrigen)
                    validaUbicacion(codigoUbicacion);
                else {
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


    private void validaUbicacionDestino(final String codigoUbicacion){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/ValidaDestinoDefecto?origenUBCClave=" + codigoUbicacionOrigen+
                            "&destinoUBCClave=" +codigoUbicacion+ "&SUCClave=" +MetodosEstaticos.obtenerSucursalClave(context)+ "&datos=" +codigoMaterial+
                            "&cantidades="+ cantMaterialString+"&"+ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context));
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
                        Toast.makeText(context,context.getString(R.string.recibo_exito_lbl),Toast.LENGTH_SHORT).show();
                        finish();
                    } else {
                        Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }

            }
        }).execute();


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


    @Override
    public void onCodigoMaterialLeido(String... parametros) {
        if(!procesando)
        {
            procesando = true;
            codigoMaterial = parametros[0].replaceFirst("\r","");
            cantidadMaterial = parametros[1];
            String aceptar = parametros[2];
            if (aceptar == "0") {
                if (codigoMaterial.length() > 0) {

                    try {

                        codigoMaterial = MetodosEstaticos.getEncodedData(codigoMaterial);
                        cantidadMaterial = MetodosEstaticos.getEncodedData(cantidadMaterial);

                        validaMaterial();

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

                leerUbicacionDestinoFragment = LeerUbicacionFragment.newInstance(false,context.getString(R.string.ubicacion_leer_destino_lbl));

                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
                fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionDestinoFragment);
                fragmentTransaction.addToBackStack(null);
                fragmentTransaction.commit();

            }
        }
        procesando = false;

        //Toast.makeText(context,context.getString(R.string.mensaje_modulo_proceso_lbl),Toast.LENGTH_SHORT).show();
    }

    private void showMotivosDevolucionDialog(){
        try{
            final RealmResults<ValorReferencia> valores = realm.where(ValorReferencia.class).equalTo("tabla","Devolucion").equalTo("campo", "Motivo").equalTo("grupo",1).findAll();
            final ArrayList<String> opciones = new ArrayList<>();

            for(ValorReferencia valorReferencia : valores)
                opciones.add(valorReferencia.getDescripcion());

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            View convertView = inflater.inflate(R.layout.dialog_list, null);
            alertDialog.setView(convertView);
            alertDialog.setCancelable(false);
            alertDialog.setTitle(context.getString(R.string.dialog_list_motivo));
            ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(context,android.R.layout.simple_list_item_1,opciones);
            opcionesList.setAdapter(adapter);
            final AlertDialog dialog = alertDialog.create();

            opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                    motivoDev = valores.get(position).getValor();
                    motivoDesc = valores.get(position).getDescripcion();
                    dialog.dismiss();
                    showFijarMotivoDialog();
                }
            });

            dialog.show();

        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }
    }

    private void showFijarMotivoDialog(){
        try{
            final ArrayList<String> opciones = new ArrayList<>();

            opciones.add("SI");
            opciones.add("NO");

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            View convertView = inflater.inflate(R.layout.dialog_list, null);
            alertDialog.setView(convertView);
            alertDialog.setCancelable(false);
            alertDialog.setTitle(context.getString(R.string.fijar_motivo));
            ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(context,android.R.layout.simple_list_item_1,opciones);
            opcionesList.setAdapter(adapter);
            final AlertDialog dialog = alertDialog.create();

            opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                    fijarMotivo = (position==0?true:false);
                    showMuestraProveedor();
                    dialog.dismiss();
                }
            });

            dialog.show();


        }catch (Exception e){
            Log.e(TAG, e.getMessage(),e);
        }
    }


    private void showMuestraProveedor(){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/ProveedorProducto?PROClave="+ MetodosEstaticos.getEncodedData(codigoMaterial));
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
                        try{
                        InputStream is = httpUrlConn.getInputStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        }catch(Exception e){
                            result = e.getMessage();
                        }
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
                            final JSONArray respuestaJSON = new JSONArray(result);
                            int indexSel;
                            if(respuestaJSON != null ){
                                final ArrayList<String> opciones = new ArrayList<>();
                                    for (int i = 0; i < respuestaJSON.length(); i++) {
                                        PrvProd = respuestaJSON.getJSONObject(i);
                                        opciones.add(PrvProd.getString("Clave") + "-" + PrvProd.getString("RazonSocial"));
                                    }
                                if(respuestaJSON.length() > 1) {
                                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
                                    LayoutInflater inflater =((Activity)context).getLayoutInflater();
                                    View convertView = inflater.inflate(R.layout.dialog_list,null);
                                    alertDialog.setView(convertView);
                                    alertDialog.setCancelable(false);
                                    alertDialog.setTitle(context.getString(R.string.selecciona_prv));
                                    ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
                                    ArrayAdapter<String> adapter = new ArrayAdapter<String>(context,android.R.layout.simple_list_item_1,opciones);
                                    opcionesList.setAdapter(adapter);
                                    final AlertDialog dialog = alertDialog.create();

                                    opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                                        @Override
                                        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                                            try {
                                                PrvProd = respuestaJSON.getJSONObject(position);
                                                agregarPrvProd();
                                            }catch (JSONException e){
                                                Log.e(TAG, e.getMessage(),e);
                                            }
                                            dialog.dismiss();
                                        }
                                    });

                                    dialog.show();
                                }else{
                                    agregarPrvProd();
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

    private void validaMaterial(){

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

                            if(aux != null && !aux.has("Message")){
                                double existencia = aux.getDouble("Existencia") - aux.getDouble("Apartado") - aux.getDouble("Bloqueado");
                                if(validaCantidad(codigoMaterial) >= existencia){
                                    Toast.makeText(context, context.getString(R.string.existencia_menor),Toast.LENGTH_SHORT).show();
                                } else {
                                    int tamanio = aux.getString("Nombre").length();
                                    productoNombre = aux.getString("Nombre").substring(0, (tamanio >= 12 ? 12 : tamanio)) + " " + aux.getString("Talla");
                                    if (!fijarMotivo)
                                        showMotivosDevolucionDialog();
                                    else
                                        showMuestraProveedor();
                                }
                                //leerMaterialCantidadFragment.onResume();
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

    private void agregarPrvProd()
    {
        try
        {
            int busqueda = buscarCodigo(codigoMaterial+","+PrvProd.getString("PRVClave")+","+motivoDev);
            if(busqueda < 0)
                codigoMat.add(new Reubicacion(codigoMaterial+","+PrvProd.getString("PRVClave")+","+motivoDev, cantidadMaterial, false, productoNombre +"    "+ PrvProd.getString("Clave"),ValoresEstaticos.ACTIVITY_DEFECTO));
            else
                codigoMat.set(busqueda, new Reubicacion(codigoMaterial+","+PrvProd.getString("PRVClave")+","+motivoDev, String.valueOf(Integer.parseInt(codigoMat.get(busqueda).getCantidad()) + Integer.parseInt(cantidadMaterial)), codigoMat.get(busqueda).isSeleccionado()
                        , productoNombre +"    "+ PrvProd.getString("Clave"),ValoresEstaticos.ACTIVITY_DEFECTO));

            leerMaterialCantidadFragment.onResume();
        }catch (JSONException e)
        {
            Log.e(TAG, e.getMessage(),e);
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
        return codigoMat;
    }

    @Override
    public String getLecturaAnt() {
        return lecturaAnt;
    }

    @Override
    public void setLecturaAnt(String... parametros) {
        lecturaAnt = (lecturaAnt.equals(parametros[0]) ? parametros[0] : parametros[0].replaceFirst(lecturaAnt,""));
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

    private int validaCantidad(String codigo){
        int aux = 0;
        for(Reubicacion reu:codigoMat){
            if(reu.getCodigo().contains(codigo))
                aux += Integer.parseInt(reu.getCantidad());
        }
        return aux;
    }
}
