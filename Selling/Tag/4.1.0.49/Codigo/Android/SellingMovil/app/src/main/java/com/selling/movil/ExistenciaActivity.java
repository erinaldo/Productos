package com.selling.movil;

import android.content.Context;
import android.support.v4.app.FragmentActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.selling.movil.adapters.ExistenciasAdapter;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.modelos.Existencia;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.apache.commons.lang3.StringUtils;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;


public class ExistenciaActivity extends FragmentActivity implements AsyncTaskInterface {

    private final String TAG = ExistenciaActivity.class.getName();
    private final String TIPO_MATERIAL = "Material";
    private final String TIPO_UBICACION = "Ubicación";
    private Context context = ExistenciaActivity.this;

    private ListView existenciasList;
    private ArrayList<Existencia> existenciasArray;
    private ExistenciasAdapter existenciasAdapter;
    private JSONArray existenciasJSON;

    private Spinner tipoExistenciaSpinner;
    private EditText codigoET;
    private boolean errorToken;
    private String lecturaAnt="";

    private TextView claveTv;
    private TextView existTv;
    private TextView apTv;
    private TextView bloqTv;

    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    if(parametros[0] != null && !parametros[0].equalsIgnoreCase("")){
                        codigoET.setText(parametros[0]);
                        obtenerExistencia();
                    }
                }
            });
        }
    });

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_existencia);

        MetodosEstaticos.cambiarTitulo(context, context.getString(R.string.title_activity_existencia));
        codigoET = (EditText) findViewById(R.id.codigoET);
        codigoET.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                // If the event is a key-down event on the "enter" button
                if ((event.getAction() == KeyEvent.ACTION_DOWN) &&
                        (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    // Perform action on key press
                    codigoET.setText(codigoET.getText().toString().replaceFirst(lecturaAnt,"").replaceFirst("\r",""));
                    obtenerExistencia();
                    lecturaAnt = codigoET.getText().toString();
                    return true;
                }
                return false;
            }
        });
        tipoExistenciaSpinner = (Spinner) findViewById(R.id.tipoExistenciaSpinner);
        existenciasList = (ListView) findViewById(R.id.existenciasList);
        existenciasArray = new ArrayList<Existencia>();
        existenciasAdapter = new ExistenciasAdapter(context,R.layout.row_existencia,existenciasArray);
        existenciasList.setAdapter(existenciasAdapter);

        claveTv = (TextView) findViewById(R.id.claveLbl);
        existTv = (TextView) findViewById(R.id.exisLbl);
        apTv = (TextView) findViewById(R.id.aptLbl);
        bloqTv = (TextView) findViewById(R.id.bloqLbl);

        claveTv.setText(StringUtils.rightPad(claveTv.getText().toString(), 13, " "));
        existTv.setText(StringUtils.leftPad(existTv.getText().toString(), 7, " "));
        apTv.setText(StringUtils.leftPad(apTv.getText().toString(), 5, " "));
        bloqTv.setText(StringUtils.leftPad(bloqTv.getText().toString(), 5, " "));

        llenarSpinner();
    }

    private void llenarSpinner(){


        ArrayAdapter<String> tipoExistenciaAdapter = new ArrayAdapter<String>(
                context, android.R.layout.simple_spinner_item, new String[]{TIPO_MATERIAL,TIPO_UBICACION});

        tipoExistenciaAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        tipoExistenciaSpinner.setAdapter(tipoExistenciaAdapter);


    }

    public void enviar(View v) {
        if (codigoET.getText().length() > 0) {

            obtenerExistencia();

        } else {
            Toast.makeText(context, context.getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
        }
    }

    private void obtenerExistencia(){
        new Conexion(context,this).execute();
    }

    @Override
    public void before() {

    }

    @Override
    public String toDo() {
        try {

            String urlTipoExistencia = tipoExistenciaSpinner.getSelectedItem().toString().equals(TIPO_MATERIAL)?"Producto/UbicacionesInventario":"Ubicacion/ProductosInventario";

            URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + urlTipoExistencia + "?id=" + MetodosEstaticos.getEncodedData(codigoET.getText().toString())+"&"+ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(context));
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
            }else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                errorToken = true;
            } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_NOT_FOUND){
                InputStream is = httpUrlConn.getErrorStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
                Log.i(TAG, result);
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
                    llenarExistencia(result);

                } catch (Exception e){
                    try {
                        String message = new JSONObject(result).getString("Message");
                        Toast.makeText(context, message, Toast.LENGTH_SHORT).show();
                        existenciasArray.clear();
                        existenciasAdapter.notifyDataSetChanged();
                    } catch (Exception ex){
                        Log.e(TAG,ex.getMessage(),ex);
                    }
                }
            } else {
                Toast.makeText(context,context.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
            }
        }
    }

    private void llenarExistencia(String response){

        Log.i(TAG, response);
        try{

            existenciasArray.clear();
            existenciasJSON = new JSONArray(response);

            JSONObject existencia;
            String id = "";
            String color = "";
            for(int contadorExistencia = 0;contadorExistencia < existenciasJSON.length();contadorExistencia++){
                existencia = existenciasJSON.getJSONObject(contadorExistencia);
                if(tipoExistenciaSpinner.getSelectedItem().toString().equals(TIPO_MATERIAL))
                    id = existencia.getString("Nombre");
                else {
                    color = existencia.getString("Color").toString();
                    id = existencia.getString("PROClave") + "," + color.substring(0, (color.length()>8?8:color.length())) + "," + existencia.getString("Talla").toString();
                }
                existenciasArray.add(
                        new Existencia(
                                id,
                                existencia.getString("Existencia"),
                                existencia.getString("Apartado"),
                                existencia.getString("Bloqueado")

                        )
                );
            }
            existenciasAdapter.notifyDataSetChanged();
            if(existenciasArray != null && existenciasArray.size() <= 0)
                Toast.makeText(context,context.getString(R.string.existencia_no_informacion_lbl),Toast.LENGTH_SHORT).show();


        } catch (JSONException e){
            Log.e(TAG,e.getMessage(),e);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }

    @Override
    protected void onResume() {
        super.onResume();
        try{
            if(MetodosEstaticos.obtenerTerminal(getApplicationContext()).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                MetodosEstaticos.setBarcodeListener(context, barcodeListener);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        try{
            if(MetodosEstaticos.obtenerTerminal(context).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                MetodosEstaticos.removeBarcodeListener(context, barcodeListener);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }
}
