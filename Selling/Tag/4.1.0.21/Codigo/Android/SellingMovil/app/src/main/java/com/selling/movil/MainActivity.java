package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.selling.movil.interfaces.AsyncTaskInterface;
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
import java.util.ArrayList;


public class MainActivity extends Activity {

    private final String TAG = MainActivity.class.getName();

    private Context context = MainActivity.this;
    private AlertDialog dialog;
    private ArrayList<String> opciones;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }


    public void surtido(View v){
        rfActivado();
    }

    public void recibo(View v){
        Intent reciboIntent = new Intent(context,ReciboActivity.class);
        startActivity(reciboIntent);
    }

    public void reubicacion(View v){
        Intent reubicacionIntent = new Intent(context,ReubicacionActivity.class);
        startActivity(reubicacionIntent);
    }

    public void almacenaje(View v){

        showOptionsDialog(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent almacenajeIntent = new Intent(context, AlmacenajeActivity.class);
                almacenajeIntent.putExtra("tipoAlmacenaje", opciones.get(position));
                startActivity(almacenajeIntent);
                dialog.dismiss();
            }
        },ValoresEstaticos.DIALOG_OPTION_ALMACENAJE);
    }

    public void cambioEstado(View v){
        Intent cambioEstadoIntent = new Intent(context,CambioEstadoActivity.class);
        startActivity(cambioEstadoIntent);
    }

    public void existencia(View v){
        Intent existenciaIntent = new Intent(context,ExistenciaActivity.class);
        startActivity(existenciaIntent);
    }

    public void conteo(View v){
        Toast.makeText(context,context.getString(R.string.mensaje_modulo_proceso_lbl),Toast.LENGTH_SHORT).show();
    }

    public void ajusteInventario(View v) {
        Intent ajusteInventarioIntent = new Intent(context,AjusteInventarioActivity.class);
        startActivity(ajusteInventarioIntent);
    }
    public void preferencias(View v){
        Intent preferenciasIntent = new Intent(context,PreferenciasActivity.class);
        startActivity(preferenciasIntent);
    }

    private void showOptionsDialog(AdapterView.OnItemClickListener listener, int opcion){
        opciones = new ArrayList<>();

        switch (opcion){
            case ValoresEstaticos.DIALOG_OPTION_ALMACENAJE:
                opciones.add(ValoresEstaticos.ALMACENAJE_DIRIGIDO);
                opciones.add(ValoresEstaticos.ALMACENAJE_NO_DIRIGIDO);
            break;
            case ValoresEstaticos.DIALOG_OPTION_SURTIDO:
                opciones.add(getString(R.string.surtido_tipo_mostrador_lbl));
                opciones.add(getString(R.string.surtido_tipo_ruta_lbl));
            break;
        }

        AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
        LayoutInflater inflater = ((Activity)context).getLayoutInflater();
        View convertView = inflater.inflate(R.layout.dialog_list, null);
        alertDialog.setView(convertView);
        alertDialog.setTitle(context.getString(R.string.dialog_list_title));
        ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(context,android.R.layout.simple_list_item_1,opciones);
        opcionesList.setAdapter(adapter);
        dialog = alertDialog.create();

        opcionesList.setOnItemClickListener(listener);

        dialog.show();
    }

    private void rfActivado(){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;

            boolean surtidoRf = false;
            boolean surtidoRfMostrador = false;

            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {


                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/rfActivo?"
                            +"SUCClave="+MetodosEstaticos.obtenerSucursalClave(context)
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
                        InputStream is = httpUrlConn.getErrorStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        Log.i(TAG, result);
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
                            JSONObject rfJson = new JSONObject(result);
                            if(rfJson.has("SurtidoRF")) {

                                surtidoRf = !rfJson.getString("SurtidoRF").equalsIgnoreCase("null")?rfJson.getBoolean("SurtidoRF"):false;
                                surtidoRfMostrador = !rfJson.getString("SurtidoRFMostrador").equalsIgnoreCase("null")?rfJson.getBoolean("SurtidoRFMostrador"):false;

                                if(surtidoRf && surtidoRfMostrador){
                                    showOptionsDialog(new AdapterView.OnItemClickListener() {
                                        @Override
                                        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                                            MetodosEstaticos.guardarTipoSurtido(context,position==0);
                                            Intent surtidoIntent = new Intent(context, SurtidoActivity.class);
                                            startActivity(surtidoIntent);
                                            dialog.dismiss();
                                        }
                                    },ValoresEstaticos.DIALOG_OPTION_SURTIDO);
                                } else if(!surtidoRf && !surtidoRfMostrador){
                                    Toast.makeText(context, context.getString(R.string.surtido_inactive_msg), Toast.LENGTH_SHORT).show();
                                } else {
                                    MetodosEstaticos.guardarTipoSurtido(context,surtidoRfMostrador);
                                    Intent surtidoIntent = new Intent(context, SurtidoActivity.class);
                                    startActivity(surtidoIntent);
                                }
                            } else
                                Toast.makeText(context, rfJson.getString("Message"), Toast.LENGTH_SHORT).show();

                        } catch (Exception e){
                            Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                        }
                    } else {
                        Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();

    }
}
