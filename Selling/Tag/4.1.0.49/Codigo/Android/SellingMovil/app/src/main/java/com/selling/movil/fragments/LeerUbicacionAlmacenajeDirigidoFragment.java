package com.selling.movil.fragments;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerUbicacionAlmacenajeDirigidoFragment extends Fragment implements View.OnClickListener{

    private final String TAG = LeerUbicacionAlmacenajeDirigidoFragment.class.getName();

    private EditText codigoUbicacionEt;
    private Button aceptarBtn;
    private OnLeerCodigoUbicacionListener listener;
    private JSONObject detalleUbicacionJson;

    private TextView ubicacionTv;
    private TextView areaTv;

    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        codigoUbicacionEt.setText(parametros[0]);
                        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString().replaceFirst("\r",""), "dirigido", detalleUbicacionJson.getString("Ubicacion"));
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });


    public LeerUbicacionAlmacenajeDirigidoFragment() {
    }

    public static LeerUbicacionAlmacenajeDirigidoFragment newInstance(String detalleProductoString,String hint){
        LeerUbicacionAlmacenajeDirigidoFragment fragment = new LeerUbicacionAlmacenajeDirigidoFragment();
        Bundle arguments = new Bundle();
        arguments.putString("detalleUbicacion", detalleProductoString);
        arguments.putString("hintUbicacion", hint);
        fragment.setArguments(arguments);
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_ubicacion_almacenaje_dirigido,container,false);

        ubicacionTv = (TextView) rootView.findViewById(R.id.ubicacion);
        areaTv = (TextView) rootView.findViewById(R.id.area);


        codigoUbicacionEt = (EditText) rootView.findViewById(R.id.codigoUbicacionEt);
        codigoUbicacionEt.setHint(getArguments().getString("hintUbicacion"));
        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        codigoUbicacionEt.requestFocus();

        codigoUbicacionEt.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                // If the event is a key-down event on the "enter" button
                if ((event.getAction() == KeyEvent.ACTION_DOWN) &&
                        (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    // Perform action on key press
                    try {
                        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString().replaceFirst("\r",""),"dirigido",detalleUbicacionJson.getString("Ubicacion"));
                    } catch (Exception e){
                        Log.e(TAG,e.getMessage(),e);
                    }
                    return true;
                }
                return false;
            }
        });

        llenarDatos();

        return rootView;
    }

    private void llenarDatos(){

        try{
            if(getArguments() != null) {
                detalleUbicacionJson = new JSONObject(getArguments().getString("detalleUbicacion"));
                ubicacionTv.setText(detalleUbicacionJson.getString("Ubicacion"));
                areaTv.setText(detalleUbicacionJson.getString("Area"));

            }
        }
        catch (JSONException e){
            Log.e(TAG, e.getMessage(), e);
        } catch (Exception e){
            Log.e(TAG, e.getMessage(), e);
        }


    }

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
            listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString().replaceFirst("\r",""),"dirigido",detalleUbicacionJson.getString("Ubicacion"));
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
