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
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerMaterialDetalleProductoFragment extends Fragment implements View.OnClickListener{

    private final String TAG = LeerMaterialDetalleProductoFragment.class.getName();

    private EditText codigoMaterialEt;
    private EditText cantidadMaterialEt;
    private Button aceptarBtn;
    private OnLeerCodigoMaterialListener listener;
    private JSONObject detalleProductoJson;

    private TextView claveTv;
    private TextView descripcionTv;
    private TextView areaTv;
    private TextView ubicacionTv;
    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        codigoMaterialEt.setText(parametros[0]);
                        String material = codigoMaterialEt.getText().toString().replaceFirst("\r","");
                        material = material.trim();
                        codigoMaterialEt.setText(material.substring((material.length() == 10? 1:0)));
                        listener.setMaterialAnt(codigoMaterialEt.getText().toString().replaceFirst("\r",""));
                        codigoMaterialEt.setText(listener.getMaterialAnt());
                        listener.onCodigoMaterialLeido(material.substring((material.length() == 10? 1:0)), cantidadMaterialEt.getText().toString().replaceFirst("\r",""));
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    public LeerMaterialDetalleProductoFragment() {
    }

    public static LeerMaterialDetalleProductoFragment newInstance(String detalleProductoString,String hint){
        LeerMaterialDetalleProductoFragment fragment = new LeerMaterialDetalleProductoFragment();
        Bundle arguments = new Bundle();
        arguments.putString("detalleProducto", detalleProductoString);
        arguments.putString("hintMaterial", hint);
        fragment.setArguments(arguments);
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_material_detalle_producto,container,false);

        claveTv = (TextView) rootView.findViewById(R.id.clave);
        descripcionTv = (TextView) rootView.findViewById(R.id.descripcion);
        areaTv = (TextView) rootView.findViewById(R.id.area);
        ubicacionTv = (TextView) rootView.findViewById(R.id.ubicacion);

        codigoMaterialEt = (EditText) rootView.findViewById(R.id.codigoMaterialEt);
        codigoMaterialEt.setHint(getArguments().getString("hintMaterial"));

        cantidadMaterialEt = (EditText) rootView.findViewById(R.id.cantidadMaterialEt);

        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        codigoMaterialEt.requestFocus();

        codigoMaterialEt.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                // If the event is a key-down event on the "enter" button
                if ((event.getAction() == KeyEvent.ACTION_DOWN) &&
                        (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    // Perform action on key press
                    String material = codigoMaterialEt.getText().toString().replaceFirst("\r","");
                    material = material.trim();
                    codigoMaterialEt.setText(material.substring((material.length() == 10? 1:0)));
                    listener.setMaterialAnt(codigoMaterialEt.getText().toString().replaceFirst("\r",""));
                    codigoMaterialEt.setText(listener.getMaterialAnt());
                    listener.onCodigoMaterialLeido(material.substring((material.length() == 10? 1:0)), cantidadMaterialEt.getText().toString().replaceFirst("\r",""));
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
                detalleProductoJson = new JSONObject(getArguments().getString("detalleProducto"));
                claveTv.setText(detalleProductoJson.getString("PROClave"));
                descripcionTv.setText(detalleProductoJson.getString("Nombre")); //Se cambio descripción por nombre
                areaTv.setText(detalleProductoJson.getString("AreaPicking"));
                ubicacionTv.setText(detalleProductoJson.getString("UbicacionPicking"));
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
            listener = (OnLeerCodigoMaterialListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnLeerCodigoMaterialListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        listener = null;
    }

    @Override
    public void onClick(View v) {
        String material = codigoMaterialEt.getText().toString().replaceFirst("\r","");
        material = material.trim();
        codigoMaterialEt.setText(material.substring((material.length() == 10? 1:0)));
        listener.setMaterialAnt(codigoMaterialEt.getText().toString().replaceFirst("\r",""));
        codigoMaterialEt.setText(listener.getMaterialAnt());
        listener.onCodigoMaterialLeido(material.substring((material.length() == 10? 1:0)), cantidadMaterialEt.getText().toString().replaceFirst("\r",""));
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
