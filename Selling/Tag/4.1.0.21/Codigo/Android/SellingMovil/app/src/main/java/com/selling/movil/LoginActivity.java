package com.selling.movil;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import org.json.JSONObject;

import java.io.BufferedWriter;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.HashMap;
import java.util.Map;


import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;


public class LoginActivity extends Activity implements AsyncTaskInterface{

    final String TAG = LoginActivity.class.getName();
    Context context = LoginActivity.this;
    private EditText usuarioET;
    private EditText contraseniaET;
    private String usuario;
    private String contrasenia;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        usuarioET = (EditText) findViewById(R.id.usuarioET);
        contraseniaET = (EditText) findViewById(R.id.contraseniaET);


        findViewById(R.id.main_page_layout).post(new Runnable() {
            public void run() {

                MetodosEstaticos.existeIP(context);
            }
        });

    }

    public void checkUsuario(View v) {

        /*Intent login2Intent = new Intent(context,MainActivity.class);
        //login2Intent.putExtra("sucursales",jsonResult.getJSONArray("Sucursales").toString());
        finish();
        startActivity(login2Intent);*/

        Log.i(TAG,"Density: " + getResources().getDisplayMetrics().density);
        usuario = usuarioET.getText().toString();
        contrasenia = contraseniaET.getText().toString();

        if(!usuario.equalsIgnoreCase("") && !contrasenia.equalsIgnoreCase("")) {

            new Conexion(context,this).execute();

        } else {
            Toast.makeText(context,context.getString(R.string.campos_vacios_lbl),Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void before() {

    }

    @Override
    public String toDo() {
        try {
            URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Tokens/Login");
            URLConnection urlConnection = url.openConnection();
            String result = null;

            HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
            httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
            httpUrlConn.setDoOutput(true);
            httpUrlConn.setDoInput(true);
            httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

            Map<String, String> parameters = new HashMap<>();
            parameters.put("usuario", usuario);
            parameters.put("contrasenia", contrasenia);
            parameters.put("versionRF", context.getString(R.string.version_app));

            String parameterString = MetodosEstaticos.getEncodedData(parameters);

            OutputStream os = httpUrlConn.getOutputStream();
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));
            writer.write(parameterString);
            writer.flush();
            writer.close();
            os.close();

            Log.i(TAG, httpUrlConn.getURL().toString());
            httpUrlConn.connect();
            if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_CREATED) {
                InputStream is = httpUrlConn.getInputStream();
                result = MetodosEstaticos.getStringFromInputStream(is);
                Log.i(TAG, result);
            }
            else if(httpUrlConn.getErrorStream() != null){
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

        if(result != null){
            try{

                JSONObject jsonResult = new JSONObject(result);
                if(jsonResult != null && !jsonResult.has("Message")) {
                    SharedPreferences pref = context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME, Context.MODE_PRIVATE);
                    SharedPreferences.Editor prefEdit = pref.edit();

                    prefEdit.putString(ValoresEstaticos.PREFERENCES_TOKEN, jsonResult.getString("Token"));
                    prefEdit.putString(ValoresEstaticos.PREFERENCES_USERNAME, usuario);
                    prefEdit.commit();

                    finish();
                    Intent login2Intent = new Intent(context, Login2Activity.class);
                    login2Intent.putExtra("sucursales", jsonResult.getJSONArray("Sucursales").toString());
                    startActivity(login2Intent);
                } else {
                    Toast.makeText(context, jsonResult.getString("Message"), Toast.LENGTH_SHORT).show();
                }

            } catch (Exception e){
                Log.e(TAG, e.getMessage(), e);
            }
        } else {
            Toast.makeText(context,context.getString(R.string.error_inicio_sesion_lbl),Toast.LENGTH_SHORT).show();
        }


    }
}
