package com.selling.movil;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.widget.Toast;

import com.selling.movil.fragments.AreasTrabajoFragment;
import com.selling.movil.fragments.PedidosDetalleFragment;
import com.selling.movil.fragments.PedidosFragment;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnSurtidoListener;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;


public class SurtidoActivity extends FragmentActivity implements OnAceptarListener,OnSurtidoListener {

    private final String TAG = SurtidoActivity.class.getName();
    private Context context = SurtidoActivity.this;
    private Conexion conexion;
    private boolean isTipoSurtidoMostrador;

    private AreasTrabajoFragment areasTrabajoFragment;
    private PedidosFragment pedidosFragment;
    private PedidosDetalleFragment pedidosDetalleFragment;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_almacenaje);
        isTipoSurtidoMostrador = MetodosEstaticos.obtenerTipoSurtido(context);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.menu_surtido));
        setInitFragment();
    }

    private void setInitFragment(){

        areasTrabajoFragment = AreasTrabajoFragment.newInstance();


        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, areasTrabajoFragment);
        fragmentTransaction.commit();

    }

    @Override
    public void onAceptar(String... parametros) {

        pedidosFragment = PedidosFragment.newInstance(parametros[0]);

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, pedidosFragment);
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();


    }

    @Override
    public void onItemListClick(String...parametros) {

        pedidosDetalleFragment = PedidosDetalleFragment.newInstance(parametros[0],parametros[1]);

        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_right, R.anim.exit_to_left, R.anim.enter_from_left, R.anim.exit_to_right);
        fragmentTransaction.replace(R.id.layoutCambioEstado, pedidosDetalleFragment);
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    @Override
    public void onStandBySuccess(String...parametros) {

        solicitarPedido(parametros[0],true);

    }

    @Override
    public void onSolicitarPedido(String...parametros) {
        solicitarPedido(parametros[0],false);
    }

    @Override
    public void onDocumentoTerminado() {
        removeFragment(pedidosDetalleFragment);
    }

    @Override
    public void onRefrescarPedidos(String... parametros) {
        cargarPedidosAsignados(parametros[0]);
    }


    private void cargarPedidosAsignados(final String areas){

        if(conexion == null || conexion.getStatus() != AsyncTask.Status.RUNNING) {
            conexion =  new Conexion(context, new AsyncTaskInterface() {
                boolean errorToken = false;
                @Override
                public void before() {

                }

                @Override
                public String toDo() {
                    try {

                        JSONArray areasJsonArray = new JSONArray(areas);
                        StringBuilder areClaves = new StringBuilder();

                        for(int contadorAreas = 0; contadorAreas < areasJsonArray.length(); contadorAreas++)
                            areClaves.append("&AREClaves=" + MetodosEstaticos.getEncodedData(areasJsonArray.getJSONObject(contadorAreas).getString("AREClave")));

                        URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/asignados?mostrador="+Boolean.toString(MetodosEstaticos.obtenerTipoSurtido(context))
                                +areClaves
                        );
                        URLConnection urlConnection = url.openConnection();
                        String result = null;

                        HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                        httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(context));
                        httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                        httpUrlConn.setDoOutput(true);
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
                                JSONArray aux = new JSONArray(result);
                                pedidosFragment.llenarListadoPedidos(result,false);

                            } catch (Exception e){
                                try {
                                    Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                                } catch (Exception ex){
                                    Log.e(TAG,ex.getMessage(),ex);
                                }
                            }
                        } else {
                            Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                        }
                    }
                }
            });
            conexion.execute();
        }

    }

    private void solicitarPedido(final String areas, final boolean standBy){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    JSONArray areasJsonArray = new JSONArray(areas);
                    StringBuilder areClaves = new StringBuilder();

                    for(int contadorAreas = 0; contadorAreas < areasJsonArray.length(); contadorAreas++)
                        areClaves.append("&AREClaves=" + MetodosEstaticos.getEncodedData(areasJsonArray.getJSONObject(contadorAreas).getString("AREClave")));

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/asignacion?mostrador="+Boolean.toString(MetodosEstaticos.obtenerTipoSurtido(context))
                            +areClaves.toString()
                    );
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(context));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(true);
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

                            if(result.equalsIgnoreCase("null")) {
                                Toast.makeText(context,context.getString(R.string.surtido_area_sin_pedidos_msg),Toast.LENGTH_SHORT).show();
                            } else {
                                JSONObject aux = new JSONObject(result);
                                if(aux != null && aux.has("Message"))
                                    Toast.makeText(context, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                                else {
                                    if(standBy) {
                                        removeFragment(pedidosDetalleFragment);
                                    } else
                                        pedidosFragment.llenarListadoPedidos(result, true);

                                }
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

    private void removeFragment(Fragment fragment) {
        getSupportFragmentManager().popBackStackImmediate();
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.setCustomAnimations(R.anim.enter_from_left, R.anim.exit_to_right,R.anim.enter_from_right, R.anim.exit_to_left);
        fragmentTransaction.remove(fragment);
        fragmentTransaction.commit();
    }


}
