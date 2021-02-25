package com.selling.movil.utilerias;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.util.TypedValue;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.intermec.aidc.BarcodeReadEvent;
import com.intermec.aidc.BarcodeReadListener;
import com.intermec.aidc.BarcodeReader;
import com.selling.movil.Aplicacion;
import com.selling.movil.R;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.Map;


/**
 * Created by Eduardo on 02/10/15.
 */
public class MetodosEstaticos {

    public static String getStringFromInputStream(InputStream is) {

        BufferedReader br = null;
        StringBuilder sb = new StringBuilder();

        String line;
        try {

            br = new BufferedReader(new InputStreamReader(is));
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }

        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

        return sb.toString();

    }

    public static String getEncodedData(Map<String,String> data) {
        StringBuilder sb = new StringBuilder();
        for(String key : data.keySet()) {
            String value = null;
            try {
                value = data.get(key);
            } catch (Exception e) {
                e.printStackTrace();
            }

            if(sb.length()>0)
                sb.append("&");

            sb.append(key + "=" + value);
        }
        return sb.toString();
    }

    public static String getEncodedData(String data) throws Exception{
        
        return URLEncoder.encode(data,"UTF-8").replaceAll("\\+", "%20");
    }

    public static String checkToken(Context context){
        return context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).getString(ValoresEstaticos.PREFERENCES_TOKEN, null);
    }

    public static String obtenerToken(Context context){
        return "Token "+ context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).getString(ValoresEstaticos.PREFERENCES_TOKEN,null);
    }

    public static String obtenerUsername(Context context){
        return context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).getString(ValoresEstaticos.PREFERENCES_USERNAME,null);
    }
    public static void limpiarSesion(Context context){
        context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).edit().remove(ValoresEstaticos.PREFERENCES_ALMACEN_CLAVE).commit();
        context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).edit().remove(ValoresEstaticos.PREFERENCES_ALMACEN_NOMBRE).commit();
        context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).edit().remove(ValoresEstaticos.PREFERENCES_SUCURSAL_CLAVE).commit();
        context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).edit().remove(ValoresEstaticos.PREFERENCES_SUCURSAL_NOMBRE).commit();
        context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE).edit().remove(ValoresEstaticos.PREFERENCES_TOKEN).commit();
        Intent i = context.getPackageManager()
                .getLaunchIntentForPackage( context.getPackageName() );
        i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
        context.startActivity(i);
    }

    public static void guardarCompaniaClave(Context context,String companiaClave){
        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putString(ValoresEstaticos.PREFERENCES_COMPANIA_CLAVE,companiaClave)
                .commit();
    }

    public static String obtenerCompaniaClave(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getString(ValoresEstaticos.PREFERENCES_COMPANIA_CLAVE,null);
    }

    public static void guardarSucursal(Context context,String sucursalClave,String sucursalNombre, boolean ubicacionRecibo){
        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putString(ValoresEstaticos.PREFERENCES_SUCURSAL_CLAVE,sucursalClave)
                .commit();
        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putString(ValoresEstaticos.PREFERENCES_SUCURSAL_NOMBRE,sucursalNombre)
                .commit();

        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putBoolean(ValoresEstaticos.PREFERENCES_SUCURSAL_UBICACION_RECIBO,ubicacionRecibo)
                .commit();
    }

    public static String obtenerSucursalClave(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getString(ValoresEstaticos.PREFERENCES_SUCURSAL_CLAVE,null);
    }

    public static String obtenerSucursalNombre(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getString(ValoresEstaticos.PREFERENCES_SUCURSAL_NOMBRE,null);
    }

    public static boolean obtenerSucursalUbicacionRecibo(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getBoolean(ValoresEstaticos.PREFERENCES_SUCURSAL_UBICACION_RECIBO,false);
    }

    public static void guardarAlmacen(Context context, String almacenClave,String almacenNombre){
        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putString(ValoresEstaticos.PREFERENCES_ALMACEN_CLAVE,almacenClave)
                .commit();

        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putString(ValoresEstaticos.PREFERENCES_ALMACEN_NOMBRE,almacenNombre)
                .commit();
    }

    public static String obtenerAlmacenClave(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getString(ValoresEstaticos.PREFERENCES_ALMACEN_CLAVE,null);
    }

    public static String obtenerAlmacenNombre(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getString(ValoresEstaticos.PREFERENCES_ALMACEN_NOMBRE,null);
    }

    public static void guardarIP(final Context context){

        LayoutInflater layoutInflater = LayoutInflater.from(context);
        View promptView = layoutInflater.inflate(R.layout.dialog_ip, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(context);
        alertDialogBuilder.setView(promptView);
        final EditText ip = (EditText) promptView.findViewById(R.id.userInput);
        alertDialogBuilder
                .setCancelable(false)
                .setPositiveButton(context.getString(R.string.dialog_guardar_lbl), new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        if( !ip.getText().toString().equalsIgnoreCase(""))  {
                            context.getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME, Context.MODE_PRIVATE)
                                    .edit()
                                    .putString(ValoresEstaticos.PREFERENCES_IP, ValoresEstaticos.PROTOCOLO + ip.getText().toString() + "/api/")
                                    .commit();
                            ValoresEstaticos.ACTUAL_SERVIDOR = obtenerIP(context);
                        } else {
                            existeIP(context);
                            Toast.makeText(context,context.getString(R.string.error_ip_lbl),Toast.LENGTH_SHORT).show();
                        }
                    }
                });

        AlertDialog alertD = alertDialogBuilder.create();

        alertD.show();


    }

    public static String obtenerIP(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getString(ValoresEstaticos.PREFERENCES_IP,null);
    }

    public static void existeIP(Context context){
        if(obtenerIP(context) == null)
            guardarIP(context);
        else
            ValoresEstaticos.ACTUAL_SERVIDOR = obtenerIP(context);
    }

    public static void cambiarTitulo(Context context,String titulo) {
        TextView title = (TextView) ((Activity) context).findViewById(R.id.title);
        title.setText(titulo);
    }


    public static void mostrarDialogoNoEncontrado(Context context){
        // get prompts.xml view
        LayoutInflater layoutInflater = LayoutInflater.from(context);

        View promptView = layoutInflater.inflate(R.layout.dialog_no_encontrado, null);

        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(context);

        // set prompts.xml to be the layout file of the alertdialog builder
        alertDialogBuilder.setView(promptView);

        final Spinner input = (Spinner) promptView.findViewById(R.id.userInput);

        input.setAdapter(new ArrayAdapter<String>(context, android.R.layout.simple_spinner_item, new String[]{"No esta en la ubicacion", "Esta dañado"}));
        // setup a dialog window
        alertDialogBuilder
                .setCancelable(false)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        // get user input and set it to result

                    }
                })
                .setNegativeButton("Cancel",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

        // create an alert dialog
        AlertDialog alertD = alertDialogBuilder.create();

        alertD.show();
    }

    public static void setBarcodeListener(final Context context,BarcodeReadListener listener){
        try{

            BarcodeReader barcodeReader = ((Aplicacion)context.getApplicationContext()).getBarcodeReader();
            if(barcodeReader != null){
                barcodeReader.addBarcodeReadListener(listener);
            } else {
                Log.i("MetodosEstaticos", "NULO");
            }

        } catch (Exception e){
            Log.e("MetodosEstaticos",e.getMessage(),e);
        }

    }

    public static void removeBarcodeListener(final Context context,BarcodeReadListener listener){
        try{

            BarcodeReader barcodeReader = ((Aplicacion)context.getApplicationContext()).getBarcodeReader();
            if(barcodeReader != null){
                barcodeReader.removeBarcodeReadListener(listener);
            } else {
                Log.i("MetodosEstaticos", "NULO");
            }

        } catch (Exception e){
            Log.e("MetodosEstaticos",e.getMessage(),e);
        }

    }

    public static void guardarTerminal(Context context,String terminal){
        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putString(ValoresEstaticos.PREFERENCES_TERMINAL,terminal)
                .commit();

    }

    public static String obtenerTerminal(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getString(ValoresEstaticos.PREFERENCES_TERMINAL,null);
    }

    public static void guardarTipoSurtido(Context context, boolean mostrador){
        context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .edit()
                .putBoolean(ValoresEstaticos.PREFERENCES_MOSTRADOR,mostrador)
                .commit();
    }

    public static boolean obtenerTipoSurtido(Context context){
        return context
                .getSharedPreferences(ValoresEstaticos.PREFERENCES_NAME,Context.MODE_PRIVATE)
                .getBoolean(ValoresEstaticos.PREFERENCES_MOSTRADOR,false);
    }

    public static String obtenerEstadoSurtido(Context ctx, int valor){
        String estado = "";
        switch (valor){
            case 1: estado = ctx.getString(R.string.surtido_estado_disponible); break;
            case 2: estado = ctx.getString(R.string.surtido_estado_asignado); break;
            case 3: estado = ctx.getString(R.string.surtido_estado_terminado); break;
            default: estado = "N/A"; break;
        }
        return estado;
    }
}
