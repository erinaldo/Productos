package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;


/**
 * Created by Eduardo on 08/10/15.
 */
public class PreferenciasActivity extends Activity implements AdapterView.OnItemClickListener{

    final String TAG = PreferenciasActivity.class.getName();
    Context context = PreferenciasActivity.this;
    private ListView preferenciasList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_preferencias);
        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.preferencias_name));
        preferenciasList = (ListView) findViewById(R.id.preferenciasList);
        preferenciasList.setOnItemClickListener(this);
        cargarPreferencias();
    }

    public void cargarPreferencias(){

        ArrayList<String> preferenciasArray = new ArrayList<String>();
        preferenciasArray.add(context.getString(R.string.preferencias_ip_lbl));
        preferenciasArray.add(context.getString(R.string.preferencias_terminar_lbl));
        preferenciasArray.add(context.getString(R.string.preferencias_fijarUbi_lbl));
        preferenciasArray.add(context.getString(R.string.preferencias_logout_lbl));

        PreferencesAdapter adapter = new PreferencesAdapter(context,preferenciasArray);
        preferenciasList.setAdapter(adapter);
    }

    private void actulizarIP(){

        LayoutInflater layoutInflater = LayoutInflater.from(context);
        View promptView = layoutInflater.inflate(R.layout.dialog_ip, null);
        android.support.v7.app.AlertDialog.Builder alertDialogBuilder = new android.support.v7.app.AlertDialog.Builder(context);
        alertDialogBuilder.setView(promptView);
        final EditText ip = (EditText) promptView.findViewById(R.id.userInput);
        alertDialogBuilder
                .setCancelable(false)
                .setPositiveButton(context.getString(R.string.dialog_guardar_lbl), new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        if (!ip.getText().toString().equalsIgnoreCase("") ) {
                            context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME, Context.MODE_PRIVATE)
                                    .edit()
                                    .putString(ValoresEstaticos.PREFERENCES_IP,ValoresEstaticos.PROTOCOLO+ip.getText().toString()+"/api/")
                                    .commit();
                            cargarPreferencias();
                            ValoresEstaticos.ACTUAL_SERVIDOR = MetodosEstaticos.obtenerIP(context);
                        } else {
                            actulizarIP();
                            Toast.makeText(context, context.getString(R.string.error_ip_lbl), Toast.LENGTH_SHORT).show();
                        }
                    }
                }).setNegativeButton(context.getString(R.string.dialog_cancelar_lbl),
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                    }
                });

        android.support.v7.app.AlertDialog alertD = alertDialogBuilder.create();

        alertD.show();


    }

    private void logout(){

        new Conexion(context, new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {
                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Tokens/Logout");
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
                        result="true";
                    } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                        errorToken = true;
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

                            Boolean logout = Boolean.valueOf(result);
                            if(logout != null && logout){
                                MetodosEstaticos.limpiarSesion(context);

                            } else {
                                Toast.makeText(context, context.getString(R.string.error_lbl), Toast.LENGTH_SHORT).show();
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

    private void seleccionarTerminar(){

        final ArrayList<String> opciones = new ArrayList<>();
        opciones.add(ValoresEstaticos.PREFERENCES_TERMINAL_GENERICA);
        opciones.add(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51);

        AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
        LayoutInflater inflater = ((Activity)context).getLayoutInflater();
        View convertView = inflater.inflate(R.layout.dialog_list, null);
        alertDialog.setView(convertView);
        alertDialog.setTitle(context.getString(R.string.dialog_terminal_title));
        ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(context,android.R.layout.simple_list_item_1,opciones);
        opcionesList.setAdapter(adapter);
        final AlertDialog dialog = alertDialog.create();

        opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {


                MetodosEstaticos.guardarTerminal(context, opciones.get(position));
                cargarPreferencias();
                dialog.dismiss();
            }
        });

        dialog.show();
    }

    private void fijarUbicacion(){
        MetodosEstaticos.guardarFijarUbicacion(context, !MetodosEstaticos.obtenerFijarUbicacion(context));
        cargarPreferencias();
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

        if(position == 0)
            actulizarIP();
        if(position == 1)
            seleccionarTerminar();
        if(position == 2)
            fijarUbicacion();
        if(position == 3)
            logout();

    }

    public class PreferencesAdapter extends ArrayAdapter<String> {

        Context context;
        ArrayList<String> preferencias;

        public PreferencesAdapter(Context context, ArrayList<String> preferencias) {
            super(context, 0, preferencias);
            this.context = context;
            this.preferencias = preferencias;
        }


        @Override
        public int getCount() {
            return preferencias.size();
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            // Get the data item for this position
            String preferencia = preferencias.get(position);
            // Check if an existing view is being reused, otherwise inflate the view
            if (convertView == null) {
                convertView = LayoutInflater.from(getContext()).inflate(R.layout.row_preferencias, parent, false);
            }
            // Lookup view for data population
            TextView preferenciaTv = (TextView) convertView.findViewById(R.id.preferenciaLbl);
            TextView valorTv = (TextView) convertView.findViewById(R.id.valorLbl);
            // Populate the data into the template view using the data object
            preferenciaTv.setText(preferencia);
            if(position == 0){
                valorTv.setText(MetodosEstaticos.obtenerIP(context));
            }
            if(position == 1){
                valorTv.setText(MetodosEstaticos.obtenerTerminal(context));
            }
            if(position == 2){
                valorTv.setText((MetodosEstaticos.obtenerFijarUbicacion(context)?"Fijar":"No fijar"));
            }
            if(position == 3){
                valorTv.setText(MetodosEstaticos.obtenerUsername(context));
            }
            // Return the completed view to render on screen
            return convertView;
        }
    }
}
