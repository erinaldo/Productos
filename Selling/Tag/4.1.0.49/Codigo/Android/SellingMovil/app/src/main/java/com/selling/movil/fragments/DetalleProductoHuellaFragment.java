package com.selling.movil.fragments;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.selling.movil.R;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.Dialogs;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;

/**
 * Created by Eduardo on 18/12/15.
 */
public class DetalleProductoHuellaFragment extends Fragment implements View.OnClickListener{

    private final String TAG = DetalleProductoHuellaFragment.class.getName();

    private Button aceptarBtn;

    private TextView claveTv;
    private TextView nombreTv;
    private TextView existenciaTv;
    private TextView apartadoTv;
    private TextView bloqueadoTv;
    private TextView ubicacionTv;
    private TextView areaTv;
    private EditText codigoUbicacionEt;
    private LinearLayout layUbicacion;
    private LinearLayout layArea;
    private OnLeerCodigoUbicacionListener listener;

    private JSONObject detalleProductoJson;
    private JSONObject detalleUbicacionJson;
    private boolean dirigido;

    //private OnAceptarListener listener;

    public DetalleProductoHuellaFragment() {
    }

    public static DetalleProductoHuellaFragment newInstance(String detalleProductoJson, String detalleUbicacionJson, String hint){
        DetalleProductoHuellaFragment fragment = new DetalleProductoHuellaFragment();
        Bundle arguments = new Bundle();
        arguments.putString("detalleProducto", detalleProductoJson);
        arguments.putString("detalleUbicacion", detalleUbicacionJson);
        arguments.putString("hintUbicacion", hint);
        fragment.setArguments(arguments);
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_detalle_producto_huella,container,false);

        claveTv = (TextView) rootView.findViewById(R.id.clave);
        nombreTv = (TextView) rootView.findViewById(R.id.nombre);
        existenciaTv = (TextView) rootView.findViewById(R.id.existencia);
        apartadoTv = (TextView) rootView.findViewById(R.id.apartado);
        bloqueadoTv = (TextView) rootView.findViewById(R.id.bloqueado);
        ubicacionTv = (TextView) rootView.findViewById(R.id.ubicacion);
        areaTv = (TextView) rootView.findViewById(R.id.area);
        layUbicacion = (LinearLayout) rootView.findViewById(R.id.layUbicacion);
        layArea = (LinearLayout) rootView.findViewById(R.id.layArea);

        codigoUbicacionEt = (EditText) rootView.findViewById(R.id.codigoUbicacionEt);
        codigoUbicacionEt.setHint(getArguments().getString("hintUbicacion"));
        codigoUbicacionEt.requestFocus();

        codigoUbicacionEt.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                // If the event is a key-down event on the "enter" button
                if ((event.getAction() == KeyEvent.ACTION_DOWN) &&
                        (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    // Perform action on key press
                    try{
                        listener.setLecturaAnt(codigoUbicacionEt.getText().toString().replaceFirst("\r",""));
                        codigoUbicacionEt.setText(listener.getLecturaAnt());
                        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString(), String.valueOf(false), String.valueOf(dirigido), (dirigido ? detalleUbicacionJson.getString("Ubicacion") : null));
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                    return true;
                }
                return false;
            }
        });

        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        llenarDatos();
        validarHuella();
        return rootView;
    }

    private void llenarDatos(){

        try{
            if(getArguments() != null) {

                detalleProductoJson = new JSONObject(getArguments().getString("detalleProducto"));
                claveTv.setText(detalleProductoJson.getString("PROClave"));
                nombreTv.setText(detalleProductoJson.getString("Nombre"));
                existenciaTv.setText(detalleProductoJson.getString("Existencia"));
                apartadoTv.setText(detalleProductoJson.getString("Apartado"));
                bloqueadoTv.setText(detalleProductoJson.getString("Bloqueado"));

                if (getArguments().getString("detalleUbicacion") != null) {
                    dirigido = true;
                    detalleUbicacionJson = new JSONObject(getArguments().getString("detalleUbicacion"));
                    ubicacionTv.setText(detalleUbicacionJson.getString("Ubicacion"));
                    areaTv.setText(detalleUbicacionJson.getString("Area"));
                }
                else {
                    dirigido = false;
                    layUbicacion.setVisibility(View.GONE);
                    layArea.setVisibility(View.GONE);
                }
            }

        }
        catch (JSONException e){
            Log.e(TAG, e.getMessage(), e);
        } catch (Exception e){
            Log.e(TAG, e.getMessage(), e);
        }
    }

    private void validarHuella(){
        try {
            if (!detalleProductoJson.getBoolean("Huella")){
                Dialogs.confirmDialog(getActivity(), getActivity().getString(R.string.almacenaje_crear_huella_msg), new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                completarHuella();
                            }
                        },
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                //listener.onAceptar("false"); //REVISAR QUE DEBO ENVIAR
                            }
                        });
            }
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

    private void completarHuella(){

        LayoutInflater layoutInflater = LayoutInflater.from(getActivity());
        View promptView = layoutInflater.inflate(R.layout.dialog_huella, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(getActivity());
        alertDialogBuilder.setView(promptView);

        final EditText volumen = (EditText) promptView.findViewById(R.id.volumen);
        final EditText largo = (EditText) promptView.findViewById(R.id.largo);
        final EditText alto = (EditText) promptView.findViewById(R.id.alto);
        final EditText ancho = (EditText) promptView.findViewById(R.id.ancho);

        alertDialogBuilder
                .setCancelable(false)
                .setNegativeButton(getActivity().getString(R.string.dialog_cancelar_lbl), new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        //listener.onAceptar("false"); //REVISAR QUE DEBO ENVIAR
                    }
                })
                .setPositiveButton(getActivity().getString(R.string.dialog_guardar_lbl), new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        if(!volumen.getText().toString().equals("") && !volumen.getText().toString().equals("0") && !volumen.getText().toString().equals("0.0")){
                            enviarHuella(volumen.getText().toString(),alto.getText().toString(),largo.getText().toString(),ancho.getText().toString());
                        } else {

                            Toast.makeText(getActivity(),getActivity().getString(R.string.dialog_huella_error_lbl),Toast.LENGTH_SHORT).show();
                            completarHuella();
                        }
                    }
                });

        AlertDialog alertD = alertDialogBuilder.create();

        alertD.show();


    }

    private void enviarHuella(final String volumen, final String alto, final String largo, final String ancho){

        new Conexion(getActivity(), new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Producto/AgregarHuella?" +
                            ValoresEstaticos.PARAMETRO_PRODUCTO + "=" + detalleProductoJson.getString("PROClave")+
                            "&volumen="+volumen+
                            "&alto="+alto+
                            "&largo="+largo+
                            "&ancho="+ancho
                            );
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(getActivity()));
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
                    Toast.makeText(getActivity(),getActivity().getString(R.string.token_error_lbl),Toast.LENGTH_SHORT).show();
                    MetodosEstaticos.limpiarSesion(getActivity());
                } else {

                    if(result != null){
                        try{

                            Boolean huellaGuardada = Boolean.valueOf(result);
                            if(huellaGuardada != null && huellaGuardada){
                                Toast.makeText(getActivity(), getActivity().getString(R.string.dialog_ok_lbl), Toast.LENGTH_SHORT).show();
                            } else {
                                Toast.makeText(getActivity(), new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                                validarHuella();
                            }

                        } catch (Exception e){
                            Log.e(TAG, e.getMessage(), e);
                        }
                    } else {
                        Toast.makeText(getActivity(),getActivity().getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();

    }

    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        codigoUbicacionEt.setText(parametros[0]);
                        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString(), String.valueOf(false), String.valueOf(dirigido), (dirigido ? detalleUbicacionJson.getString("Ubicacion") : null));
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        try {
            listener = (OnLeerCodigoUbicacionListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnLeerCodigoUbicacionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        listener = null;
    }

    @Override
    public void onClick(View v) {
        try {
            //listener.onAceptar("true");
            listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString(), String.valueOf(false), String.valueOf(dirigido), (dirigido ? detalleUbicacionJson.getString("Ubicacion") : null));
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

    @Override
    public void onPause() {
        super.onPause();
        try{
            if(MetodosEstaticos.obtenerTerminal(getActivity()).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                MetodosEstaticos.removeBarcodeListener(getActivity(), barcodeListener);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

    @Override
    public void onResume() {
        super.onResume();
        try{
            if(MetodosEstaticos.obtenerTerminal(getActivity()).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                MetodosEstaticos.setBarcodeListener(getActivity(), barcodeListener);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }
}
