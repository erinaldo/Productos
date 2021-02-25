package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
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

import com.selling.movil.fragments.LeerMaterialDetalleConteoFragment;
import com.selling.movil.fragments.LeerUbicacionConteoDirigidoFragment;
import com.selling.movil.fragments.LeerUsuarioFragment;
import com.selling.movil.fragments.LeerMaterialCantidadConteoFragment;
import com.selling.movil.fragments.LeerUbicacionFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnLeerClaveUsuarioListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.interfaces.OnSiguienteListener;
import com.selling.movil.modelos.ConteoUbicacion;
import com.selling.movil.modelos.Reubicacion;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.Dialogs;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.apache.commons.lang3.BooleanUtils;
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
import java.util.Map;

import io.realm.Realm;

public class ConteoActivity extends FragmentActivity implements OnAceptarListener, OnLeerClaveUsuarioListener, OnLeerCodigoUbicacionListener, OnLeerCodigoMaterialListener, OnSiguienteListener {

    private final String TAG = ConteoActivity.class.getName();
    private Context context = ConteoActivity.this;

    //private String conClave;
    private String codigoMaterial;
    private String cantidadMaterial;
    private int posUbicacion = 0;
    private boolean procesando = false;

    private ArrayList<ConteoUbicacion> ubicacionesArray;
    private JSONArray ubicacionesJSON;
    private ConteoUbicacion ubicacionActual;

    private LeerUsuarioFragment leerUsuarioFragment;
    private LeerUbicacionFragment leerUbicacionFragment;
    private LeerUbicacionConteoDirigidoFragment leerUbicacionDirigidoFragment;
    private LeerMaterialCantidadConteoFragment leerMaterialCantidadFragment;
    private LeerMaterialDetalleConteoFragment leerMaterialDetalleConteoFragment;

    private Realm realm;
    private int opcionUbicacion;
    private int opcionConteo;
    private boolean materialDetalle;
    private String lecturaAnt="";
    private ListView list;
    private ArrayList<Reubicacion> codigoMat = new ArrayList<Reubicacion>();
    private String usuario, ubicacion;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reubicacion);

        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_conteo));
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        showOpcionesConteoDialog();
        setInitFragment();
        list = (ListView)findViewById(R.id.listCodigos);
        materialDetalle = false;
    }

    private void setInitFragment(){
        leerUsuarioFragment = LeerUsuarioFragment.newInstance(context.getString(R.string.leer_clave_usuario_lbl));
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerUsuarioFragment);
        fragmentTransaction.commit();
    }

    private void removeFragmentUsuario(){
        getSupportFragmentManager().popBackStackImmediate();
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
        fragmentTransaction.remove(leerUsuarioFragment);
        fragmentTransaction.commit();
    }

    @Override
    public void onClaveUsuarioLeida(String... parametros) {
        String claveUsuario = parametros[0];

        if (claveUsuario.length() > 0) {
            try {
                claveUsuario = MetodosEstaticos.getEncodedData(claveUsuario);
                usuario = claveUsuario;
                validaUsuario(claveUsuario);
            } catch (Exception e) {
                Log.e(TAG,e.getMessage(),e);
            }
        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }

    private void validaUsuario(final String claveUsuario){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;

            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Conteo/ObtenerAsignados?ClaveUsuario=" + claveUsuario);
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
                    if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getInputStream());
                    } else if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN) {
                        errorToken = true;
                    } else if (httpUrlConn.getErrorStream() != null) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getErrorStream());
                    } else {
                        result = null;
                    }
                    return result;
                } catch (SocketTimeoutException e) {
                    return getString(R.string.error_servidor_lbl);
                } catch (Exception e) {
                    Log.e(TAG, e.getMessage(), e);
                    return null;
                }
            }

            @Override
            public void after(String result) {
                if (errorToken) {
                    Toast.makeText(context, context.getString(R.string.token_error_lbl), Toast.LENGTH_SHORT).show();
                    MetodosEstaticos.limpiarSesion(context);
                } else {
                    if (result != null) {
                        try {
                            JSONArray aux = new JSONArray(result);
                            if(opcionConteo == 1){
                                llenarUbicaciones(result);
                                obtenerOpcionesUbicacion();
                            }else
                                showFragmentUbicacion();
                        } catch (Exception e) {
                            try {
                                JSONObject aux = new JSONObject(result);
                                if (aux != null && !aux.has("Message")) {

                                    if (aux.has("usuarioNoExiste")) {
                                        Toast.makeText(context, context.getString(R.string.conteo_usuario_no_existe), Toast.LENGTH_LONG).show();
                                    } else if (aux.has("conteoNoAsignado") && opcionConteo == 1) {
                                        Toast.makeText(context, context.getString(R.string.conteo_usuario_no_asignado), Toast.LENGTH_LONG).show();
                                    } else if(opcionConteo == 0){
                                        showFragmentUbicacion();
                                    }
                                } else
                                    Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                                /*String message = new JSONObject(result).getString("Message");
                                if (message.equals("usuarioNoExiste")) {
                                    Toast.makeText(context, context.getString(R.string.conteo_usuario_no_existe), Toast.LENGTH_LONG).show();
                                } else if (message.equals("conteoNoAsignado")) {
                                    Toast.makeText(context, context.getString(R.string.conteo_usuario_no_asignado), Toast.LENGTH_LONG).show();
                                } else
                                    Toast.makeText(context, message, Toast.LENGTH_SHORT).show();*/
                            } catch (Exception ex) {
                                Log.e(TAG, ex.getMessage(), ex);
                            }
                        }
                    } else {
                        Toast.makeText(context, context.getString(R.string.error_lbl), Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();
    }

    private void llenarUbicaciones(String response){

        Log.i(TAG, response);
        try{
            if (ubicacionesArray == null)
                ubicacionesArray = new ArrayList<>();
            else
                ubicacionesArray.clear();
            ubicacionesJSON = new JSONArray(response);

            JSONObject ubicacion;
            for(int contadorUbicaciones = 0; contadorUbicaciones < ubicacionesJSON.length(); contadorUbicaciones++){
                ubicacion = ubicacionesJSON.getJSONObject(contadorUbicaciones);
                ubicacionesArray.add(
                        new ConteoUbicacion(
                                ubicacion.getString("USRClave"),
                                ubicacion.getString("CONClave"),
                                ubicacion.getString("ALMClave"),
                                ubicacion.getString("Almacen"),
                                ubicacion.getString("Area"),
                                ubicacion.getString("Estructura"),
                                ubicacion.getString("Nivel"),
                                ubicacion.getInt("Columna"),
                                ubicacion.getString("UBCClave"),
                                ubicacion.getString("Ubicacion"),
                                ubicacion.getInt("Estado")
                        )
                );
            }
            posUbicacion = obtenerPosicionSiguiente(0);

        } catch (JSONException e){
            Log.e(TAG,e.getMessage(),e);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

    private int obtenerPosicionSiguiente(int posicionActual){
        int siguiente = -1;
        for (int i = posicionActual; i < ubicacionesArray.size(); i++){
            if (ubicacionesArray.get(i).getEstado() != 3) {
                siguiente = i;
                break;
            }
        }
        return siguiente;
    }

    private void showOpcionesConteoDialog(){
        try{
            final ArrayList<String> opciones = new ArrayList<>();
            opciones.add(getString(R.string.conteo_manual));
            opciones.add(getString(R.string.conteo_normal));

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            View convertView = inflater.inflate(R.layout.dialog_list, null);
            alertDialog.setView(convertView);
            alertDialog.setCancelable(false);
            alertDialog.setTitle(context.getString(R.string.dialog_list_title));
            ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(context,android.R.layout.simple_list_item_1,opciones);
            opcionesList.setAdapter(adapter);
            final AlertDialog dialog = alertDialog.create();

            opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                    opcionConteo = position;
                    MetodosEstaticos.guardarConteoNormal(context, BooleanUtils.toBoolean(opcionConteo));
                    dialog.dismiss();
                }
            });

            dialog.show();


        }catch(Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }
    }

    private void obtenerOpcionesUbicacion(){
        showOpcionesUbicacionDialog();
    }

    private void showOpcionesUbicacionDialog(){
        try{
            //final RealmResults<ValorReferencia> valores = realm.where(ValorReferencia.class).equalTo("tabla","Recibo").equalTo("campo", "MotivoSobrante").findAll();
            final ArrayList<String> opciones = new ArrayList<>();
            opciones.add(getString(R.string.conteo_opc_dirigido));
            opciones.add(getString(R.string.conteo_opc_no_dirigido));

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            View convertView = inflater.inflate(R.layout.dialog_list, null);
            alertDialog.setView(convertView);
            alertDialog.setCancelable(false);
            alertDialog.setTitle(context.getString(R.string.dialog_list_title));
            ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(context,android.R.layout.simple_list_item_1,opciones);
            opcionesList.setAdapter(adapter);
            final AlertDialog dialog = alertDialog.create();

            opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                    opcionUbicacion = position;
                    dialog.dismiss();

                    if (opcionUbicacion == 0 && todasLasUbicacionesContadas()) {
                        Toast.makeText(context, context.getString(R.string.conteo_terminado_dirigido), Toast.LENGTH_LONG).show();
                    }
                    else {
                        showFragmentUbicacion();
                    }
                }
            });

            dialog.show();

        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }
    }

    private void showFragmentUbicacion(){
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        if (opcionUbicacion == 0 && opcionConteo == 1) {
            leerUbicacionDirigidoFragment = LeerUbicacionConteoDirigidoFragment.newInstance(ubicacionesArray.get(posUbicacion), context.getString(R.string.conteo_confirmar_ubicacion_lbl));
            fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionDirigidoFragment);
        }else {
            leerUbicacionFragment = LeerUbicacionFragment.newInstance(true, context.getString(R.string.ubicacion_leer_lbl));
            fragmentTransaction.replace(R.id.layoutCambioEstado, leerUbicacionFragment);
        }
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    private void removeFragmentUbicacion(){
        if (opcionUbicacion == 0)
        {
            getSupportFragmentManager().popBackStackImmediate();
            FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right, R.anim.enter_from_right, R.anim.exit_to_left);
            fragmentTransaction.remove(leerUbicacionDirigidoFragment);
            fragmentTransaction.commit();
        }else {
            getSupportFragmentManager().popBackStackImmediate();
            FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
            fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right, R.anim.enter_from_right, R.anim.exit_to_left);
            fragmentTransaction.remove(leerUbicacionFragment);
            fragmentTransaction.commit();
        }
    }

    @Override
    public void onCodigoUbicacionLeido(String... parametros) {
        String codigoUbicacion = parametros[0];

        if (codigoUbicacion.length() > 0) {

            try {
                codigoUbicacion = MetodosEstaticos.getEncodedData(codigoUbicacion);
                ubicacion = codigoUbicacion;
                validaUbicacion(codigoUbicacion);
            } catch (Exception e) {

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

    private void validaUbicacionConteoManual(final String codigoUbicacion){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Conteo/validaUbicacionConteo" +
                            "?ubicacion="+ codigoUbicacion +
                            "&almclave="+MetodosEstaticos.obtenerAlmacenClave(context));
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
                            if(result.contains("true")){
                                showFragmentMaterial();
                            }else{
                                Toast.makeText(context,context.getString(R.string.conteo_ubicacion_apartado),Toast.LENGTH_SHORT).show();
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

    private void validaUbicacion(String codigoUbicacion){
        boolean ubicacionCorrecta = false;
        try {
            if(opcionConteo == 1){
                if (opcionUbicacion == 0) {
                    if (codigoUbicacion.replaceAll("\\-", "").equalsIgnoreCase(MetodosEstaticos.getEncodedData(ubicacionesArray.get(posUbicacion).getUbicacion().replaceAll("\\-", "").trim()))) {
                        ubicacionActual = ubicacionesArray.get(posUbicacion);
                        ubicacionCorrecta = true;
                    } else {
                        Toast.makeText(context, context.getString(R.string.conteo_confirmar_ubicacion_diferente_lbl), Toast.LENGTH_LONG).show();
                    }
                }else {
                    for (ConteoUbicacion ubc: ubicacionesArray) {
                        if (codigoUbicacion.replaceAll("\\-", "").equalsIgnoreCase(MetodosEstaticos.getEncodedData(ubc.getUbicacion().replaceAll("\\-", "").trim()))){
                            ubicacionActual = ubc;
                            ubicacionCorrecta = true;
                            break;
                        }
                    }
                    if (!ubicacionCorrecta)
                        Toast.makeText(context, context.getString(R.string.conteo_ubicacion_no_asignada), Toast.LENGTH_LONG).show();
                }

                if (ubicacionCorrecta){
                    if (ubicacionActual.getEstado() == 3)
                        validarReinicarConteoUbicacion();
                    else
                        actualizaEstadoUbicacion(2);
                }
            }else{
                validaUbicacionConteoManual(codigoUbicacion);
            }
        }catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

    private void actualizaEstadoUbicacion(final int estado){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Conteo/ActualizarEstadoUbicacion" +
                            "?CONClave="+ ubicacionActual.getCONClave() +
                            "&UBCClave="+ubicacionActual.getUBCClave()+
                            "&Estado="+estado+
                            "&USRClave="+ubicacionActual.getUSRClave());
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
                            if(result == "false"){
                                Toast.makeText(context,context.getString(R.string.conteo_producto_no_existe),Toast.LENGTH_SHORT).show();
                                //finish();
                            }
                            else {
                                ubicacionActual.setEstado(estado);
                                if (estado == 3) {
                                    if (todasLasUbicacionesContadas()) {
                                        Toast.makeText(context,context.getString(R.string.conteo_terminado),Toast.LENGTH_LONG).show();
                                        removeFragmentMaterial();
                                    }
                                    else {
                                        posUbicacion = obtenerPosicionSiguiente(posUbicacion);
                                        removeFragmentMaterial();
                                        showFragmentUbicacion();
                                    }
                                }
                                else{
                                    removeFragmentUbicacion();
                                    showFragmentMaterial();
                                }
                            }
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

    private boolean todasLasUbicacionesContadas(){
        int cont = 0;
        for (ConteoUbicacion ubc:ubicacionesArray) {
            if (ubc.getEstado() == 3)
                cont+=1;
        }
        return (cont == ubicacionesArray.size());
    }

    private void validarReinicarConteoUbicacion(){
        Dialogs.confirmDialog(context, context.getString(R.string.conteo_ubicacion_terminado),
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        try {
                            reiniciarConteoUbicacion();
                        } catch (Exception e) {
                            //Log.e(TAG,e.getMessage(),e);
                        }
                    }
                },
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                    }
                });
    }

    private void reiniciarConteoUbicacion(){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Conteo/ReiniciarConteoUbicacion" +
                            "?CONClave="+ ubicacionActual.getCONClave() +
                            "&UBCClave="+ubicacionActual.getUBCClave()+
                            "&USRClave="+ubicacionActual.getUSRClave());
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
                            if(result == "false"){
                                Toast.makeText(context,context.getString(R.string.conteo_producto_no_existe),Toast.LENGTH_SHORT).show();
                                //finish();
                            }
                            else {
                                ubicacionActual.setEstado(2);
                                removeFragmentUbicacion();
                                showFragmentMaterial();
                            }
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

    private void showFragmentMaterial(){
        materialDetalle = false;
        codigoMat.clear();
        leerMaterialCantidadFragment = LeerMaterialCantidadConteoFragment.newInstance();

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialCantidadFragment);
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    private void showFragmentMaterialDetalle(String result){
        materialDetalle = true;
        leerMaterialDetalleConteoFragment = LeerMaterialDetalleConteoFragment.newInstance(result, context.getString(R.string.producto_leer_lbl));

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left,R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, leerMaterialDetalleConteoFragment);
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    private void removeFragmentMaterial(){
        getSupportFragmentManager().popBackStackImmediate();
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
        if (materialDetalle)
            fragmentTransaction.remove(leerMaterialDetalleConteoFragment);
        else
            fragmentTransaction.remove(leerMaterialCantidadFragment);
        fragmentTransaction.commit();
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
                    if(MetodosEstaticos.obtenerConteoNormal(context))
                        validaMaterial(codigoMaterial, cantidadMaterial);
                    else
                        validaMaterialConteo(codigoMaterial, cantidadMaterial);
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

    private void validaMaterialConteo(final String codigoMaterial, final String cantidadMaterial){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;

            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Conteo/ValidarProducto" +
                            "?PROClave=" + codigoMaterial +
                            "&ALMClave=" + MetodosEstaticos.obtenerAlmacenClave(context));
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
                    if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getInputStream());
                    } else if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN) {
                        errorToken = true;
                    } else if (httpUrlConn.getErrorStream() != null) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getErrorStream());
                    } else {
                        result = null;
                    }

                    return result;

                } catch (SocketTimeoutException e) {
                    return getString(R.string.error_servidor_lbl);
                } catch (Exception e) {
                    Log.e(TAG, e.getMessage(), e);
                    return null;
                }
            }

            @Override
            public void after(String result) {
                if (errorToken) {
                    Toast.makeText(context, context.getString(R.string.token_error_lbl), Toast.LENGTH_SHORT).show();
                    MetodosEstaticos.limpiarSesion(context);
                } else {

                    if (result != null) {
                        try {
                            JSONObject aux = new JSONObject(result);
                            if (aux != null) {

                                int busqueda = buscarCodigo(codigoMaterial);
                                if (busqueda < 0)
                                    ConteoActivity.this.codigoMat.add(new Reubicacion(codigoMaterial,cantidadMaterial,false,"",ValoresEstaticos.ACTIVITY_CONTEO));
                                else
                                    ConteoActivity.this.codigoMat.set(busqueda, new Reubicacion(codigoMaterial,String.valueOf(Integer.parseInt(codigoMat.get(busqueda).getCantidad()) + Integer.parseInt(cantidadMaterial)),codigoMat.get(busqueda).isSeleccionado(),
                                            codigoMat.get(busqueda).getUbicacion(),ValoresEstaticos.ACTIVITY_CONTEO));

                                leerMaterialCantidadFragment.onResume();

                                //if(aux.has())
                                if (aux.has("productoNoExiste")) {
                                    Toast.makeText(context, context.getString(R.string.conteo_producto_no_existe), Toast.LENGTH_SHORT).show();
                                    //finish();
                                } else {

                                }

                            } else
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                        } catch (Exception e) {
                            Log.e(TAG, e.getMessage(), e);
                        }
                    } else {
                        Toast.makeText(context, context.getString(R.string.error_lbl), Toast.LENGTH_SHORT).show();
                    }
                }
                procesando = false;
            }
        }).execute();

    }

    private void conteoManual(final String codigoMaterial, final String cantidadMaterial){
        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;

            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    //ubicacionActual.getUBCClave()
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Conteo/RealizarConteoManual" +
                            "?PROClave=" + codigoMaterial +
                            "&Cantidad=" + cantidadMaterial +
                            "&UBCClave=" + ubicacion +
                            "&ALMClave=" + MetodosEstaticos.obtenerAlmacenClave(context) +
                            "&USRClave=" + usuario);
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
                    if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getInputStream());
                    } else if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN) {
                        errorToken = true;
                    } else if (httpUrlConn.getErrorStream() != null) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getErrorStream());
                    } else {
                        result = null;
                    }

                    return result;

                } catch (SocketTimeoutException e) {
                    return getString(R.string.error_servidor_lbl);
                } catch (Exception e) {
                    Log.e(TAG, e.getMessage(), e);
                    return null;
                }
            }

            @Override
            public void after(String result) {
                if (errorToken) {
                    Toast.makeText(context, context.getString(R.string.token_error_lbl), Toast.LENGTH_SHORT).show();
                    MetodosEstaticos.limpiarSesion(context);
                } else {

                    if (result != null) {
                        try {
                            JSONObject aux = new JSONObject(result);
                            if (aux != null && !aux.has("Message")) {

                                if (aux.has("productoNoExiste")) {
                                    Toast.makeText(context, context.getString(R.string.conteo_producto_no_existe), Toast.LENGTH_SHORT).show();
                                    //finish();
                                } else if (aux.has("StageNoExiste")) {
                                    Toast.makeText(context, context.getString(R.string.stage_no_asignado), Toast.LENGTH_SHORT).show();
                                    //finish();
                                } else {
                                    finish();
                                }

                            } else
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                        } catch (Exception e) {
                            Log.e(TAG, e.getMessage(), e);
                        }
                    } else {
                        Toast.makeText(context, context.getString(R.string.error_lbl), Toast.LENGTH_SHORT).show();
                    }
                }
                procesando = false;
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

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Conteo/ActualizarConteo" +
                            "?CONClave=" + ubicacionActual.getCONClave() +
                            "&UBCClave=" + ubicacionActual.getUBCClave() +
                            "&PROClave=" + codigoMaterial +
                            "&Cantidad=" + cantidadMaterial +
                            "&USRClave=" + ubicacionActual.getUSRClave());
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
                    if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getInputStream());
                    } else if (httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN) {
                        errorToken = true;
                    } else if (httpUrlConn.getErrorStream() != null) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getErrorStream());
                    } else {
                        result = null;
                    }

                    return result;

                } catch (SocketTimeoutException e) {
                    return getString(R.string.error_servidor_lbl);
                } catch (Exception e) {
                    Log.e(TAG, e.getMessage(), e);
                    return null;
                }
            }

            @Override
            public void after(String result) {
                if (errorToken) {
                    Toast.makeText(context, context.getString(R.string.token_error_lbl), Toast.LENGTH_SHORT).show();
                    MetodosEstaticos.limpiarSesion(context);
                } else {

                    if (result != null) {
                        try {
                            JSONObject aux = new JSONObject(result);
                            if (aux != null && !aux.has("Message")) {

                                if (aux.has("productoNoExiste")) {
                                    Toast.makeText(context, context.getString(R.string.conteo_producto_no_existe), Toast.LENGTH_SHORT).show();
                                    //finish();
                                } else if (aux.has("productoNoConfigurado")) {
                                    Toast.makeText(context, context.getString(R.string.conteo_producto_no_asignado), Toast.LENGTH_SHORT).show();
                                    //finish();
                                } else {
                                    removeFragmentMaterial();
                                    showFragmentMaterialDetalle(result);
                                }

                            } else
                                Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                        } catch (Exception e) {
                            Log.e(TAG, e.getMessage(), e);
                        }
                    } else {
                        Toast.makeText(context, context.getString(R.string.error_lbl), Toast.LENGTH_SHORT).show();
                    }
                }
                procesando = false;
            }
        }).execute();

    }

    @Override
    public void onSiguienteUbicacion(String... parametros){
        if(MetodosEstaticos.obtenerConteoNormal(context))
            actualizaEstadoUbicacion(3);
        else
        {
            String codigoMatArray = "";
            String cantMatArray ="";
            for(Reubicacion reu:codigoMat){
                codigoMatArray += reu.getCodigo() + ",";
                cantMatArray += reu.getCantidad() + ",";
            }
            codigoMatArray = codigoMatArray.substring(0,codigoMatArray.length()-1);
            cantMatArray = cantMatArray.substring(0, cantMatArray.length()-1);
            conteoManual(codigoMatArray, cantMatArray);

        }
    }

    @Override
    public void onAceptar(String... parametros) {

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
}
