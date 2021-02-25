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
import com.selling.movil.interfaces.OnLeerCodigoAndenListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by amartinez on 10/08/2018
 */
public class LeerAndenFragment extends Fragment implements View.OnClickListener{

    private final String TAG = LeerAndenFragment.class.getName();

    private EditText txtCodigoAnden;
    private Button btnAceptar;
    private OnLeerCodigoAndenListener listener;
    //private JSONObject detalleAndenJson;

    private TextView txtFolio;
    private TextView txtAnden;

    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        txtCodigoAnden.setText(parametros[0]);
                        listener.onCodigoAndenLeido(txtCodigoAnden.getText().toString().replaceFirst("\r",""), getArguments().getString("anden"));
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });


    public LeerAndenFragment() {
    }

    public static LeerAndenFragment newInstance(String folio, String anden, String hint){
        LeerAndenFragment fragment = new LeerAndenFragment();
        Bundle arguments = new Bundle();
        arguments.putString("folio", folio);
        arguments.putString("anden", anden);
        arguments.putString("hintAnden", hint);
        fragment.setArguments(arguments);
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_anden, container, false);

        txtFolio = (TextView) rootView.findViewById(R.id.folio);
        txtAnden = (TextView) rootView.findViewById(R.id.anden);


        txtCodigoAnden = (EditText) rootView.findViewById(R.id.codigoAnden);
        txtCodigoAnden.setHint(getArguments().getString("hintAnden"));
        btnAceptar = (Button) rootView.findViewById(R.id.aceptarBtn);
        btnAceptar.setOnClickListener(this);
        txtCodigoAnden.requestFocus();

        txtCodigoAnden.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                // If the event is a key-down event on the "enter" button
                if ((event.getAction() == KeyEvent.ACTION_DOWN) &&
                        (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    // Perform action on key press
                    listener.onCodigoAndenLeido(txtCodigoAnden.getText().toString().replaceFirst("\r",""), getArguments().getString("anden"));
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
                //detalleAndenJson = new JSONObject(getArguments().getString("detalleAnden"));
                txtFolio.setText(getArguments().getString("folio"));
                txtAnden.setText(getArguments().getString("anden"));
            }
        //}
        //catch (JSONException e){
        //    Log.e(TAG, e.getMessage(), e);
        } catch (Exception e){
            Log.e(TAG, e.getMessage(), e);
        }


    }

    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        try {
            listener = (OnLeerCodigoAndenListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnLeerCodigoAndenListener");
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
            listener.onCodigoAndenLeido(txtCodigoAnden.getText().toString().replaceFirst("\r",""), getArguments().getString("anden"));
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
