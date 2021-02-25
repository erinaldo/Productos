package com.selling.movil.tasks;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;

import com.selling.movil.Aplicacion;
import com.selling.movil.interfaces.AsyncTaskInterface;

import com.selling.movil.utilerias.Dialogs;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

/**
 * Created by Eduardo on 02/10/15.
 */
public class Conexion extends AsyncTask<Void,Void,String> {

    Context context;
    private AsyncTaskInterface listener;

    public Conexion(Context context,AsyncTaskInterface listener){
        this.context = context;
        this.listener = listener;

    }
    @Override
    protected void onPreExecute() {
        try {
            if(MetodosEstaticos.obtenerTerminal(context).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                ((Aplicacion) context.getApplicationContext()).getBarcodeReader().setScannerEnable(false);
        } catch (Exception e){
            Log.e("Conexion",e.getMessage(),e);
        }
        Dialogs.cargando(context);
        listener.before();
        super.onPreExecute();
    }

    @Override
    protected String doInBackground(Void... params) {

        return listener.toDo();
    }

    @Override
    protected void onPostExecute(String result) {
        Dialogs.dismiss();
        listener.after(result);
        try {
            if(MetodosEstaticos.obtenerTerminal(context).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                ((Aplicacion) context.getApplicationContext()).getBarcodeReader().setScannerEnable(true);
        } catch (Exception e){
            Log.e("Conexion",e.getMessage(),e);
        }
        super.onPostExecute(result);
    }
}
