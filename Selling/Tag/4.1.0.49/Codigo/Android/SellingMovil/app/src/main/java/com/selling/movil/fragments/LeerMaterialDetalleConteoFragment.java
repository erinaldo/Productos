package com.selling.movil.fragments;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.interfaces.OnSiguienteListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerMaterialDetalleConteoFragment extends Fragment implements View.OnClickListener {

    private final String TAG = LeerMaterialDetalleConteoFragment.class.getName();

    private EditText codigoMaterialEt;
    private EditText cantidadMaterialEt;
    private Button aceptarBtn;
    private OnLeerCodigoMaterialListener listener;
    private JSONObject detalleProductoJson;
    private Button siguienteBtn;
    private OnSiguienteListener siguienteListener;


    private TextView ubicacionTv;
    private TextView claveTv;
    private TextView nombreTv;
    private TextView contadorTv;

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

    public LeerMaterialDetalleConteoFragment() {
    }

    public static LeerMaterialDetalleConteoFragment newInstance(String detalleProductoString,String hint){
        LeerMaterialDetalleConteoFragment fragment = new LeerMaterialDetalleConteoFragment();
        Bundle arguments = new Bundle();
        arguments.putString("detalleProducto", detalleProductoString);
        arguments.putString("hintMaterial", hint);
        fragment.setArguments(arguments);


        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        //super.onCreateView(inflater,container,savedInstanceState);


        View rootView = inflater.inflate(R.layout.fragment_leer_material_detalle_conteo, container,false);
        //setHasOptionsMenu(true);
        ubicacionTv = (TextView) rootView.findViewById(R.id.ubicacion);
        claveTv = (TextView) rootView.findViewById(R.id.clave);
        nombreTv = (TextView) rootView.findViewById(R.id.nombre);
        contadorTv = (TextView) rootView.findViewById(R.id.contador);

        codigoMaterialEt = (EditText) rootView.findViewById(R.id.codigoMaterialEt);
        codigoMaterialEt.setHint(getArguments().getString("hintMaterial"));

        cantidadMaterialEt = (EditText) rootView.findViewById(R.id.cantidadMaterialEt);

        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);

        siguienteBtn = (Button) rootView.findViewById(R.id.siguienteBtn);
        siguienteBtn.setOnClickListener(this);
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
                    listener.onCodigoMaterialLeido(codigoMaterialEt.getText().toString().replaceFirst("\r", ""), cantidadMaterialEt.getText().toString().replaceFirst("\r", ""));
                    return true;
                }
                return false;
            }
        });

        llenarDatos();

        return rootView;
    }

    private void llenarDatos(){
        try {
            if(getArguments() != null) {
                detalleProductoJson = new JSONObject(getArguments().getString("detalleProducto"));
                ubicacionTv.setText(detalleProductoJson.getString("Ubicacion"));
                claveTv.setText(detalleProductoJson.getString("PROClave"));
                nombreTv.setText(detalleProductoJson.getString("Nombre"));
                contadorTv.setText(detalleProductoJson.getString("Cantidad"));
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
            siguienteListener = (OnSiguienteListener) activity;
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
        if (v.getId() == R.id.aceptarBtn) {
            String material = codigoMaterialEt.getText().toString().replaceFirst("\r","");
            material = material.trim();
            codigoMaterialEt.setText(material.substring((material.length() == 10? 1:0)));
            listener.setMaterialAnt(codigoMaterialEt.getText().toString().replaceFirst("\r",""));
            codigoMaterialEt.setText(listener.getMaterialAnt());
            listener.onCodigoMaterialLeido(codigoMaterialEt.getText().toString().replaceFirst("\r", ""), cantidadMaterialEt.getText().toString().replaceFirst("\r", ""));
        }else if (v.getId() == R.id.siguienteBtn)
            siguienteListener.onSiguienteUbicacion();
    }

    /*private View.OnClickListener mSiguiente = new View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            siguienteListener.onSiguienteUbicacion();
        }

    };*/

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
