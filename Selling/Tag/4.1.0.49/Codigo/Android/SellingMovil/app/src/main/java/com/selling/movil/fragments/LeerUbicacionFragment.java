package com.selling.movil.fragments;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnKeyListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import com.selling.movil.R;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerUbicacionFragment extends Fragment implements View.OnClickListener{

    private final String TAG = LeerUbicacionFragment.class.getName();
    private EditText codigoUbicacionEt;
    private Button aceptarBtn;
    private OnLeerCodigoUbicacionListener listener;

    private boolean ubicacionOrigen;
    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        Log.i(TAG,"leerUbicacion");
                        codigoUbicacionEt.setText(parametros[0]);
                        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString().replaceFirst("\r",""),Boolean.toString(ubicacionOrigen));
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    public LeerUbicacionFragment() {
    }

    public static LeerUbicacionFragment newInstance(boolean origen,String hint){
        LeerUbicacionFragment fragment = new LeerUbicacionFragment();
        Bundle arguments = new Bundle();
        arguments.putBoolean("tipoUbicacion", origen);
        arguments.putString("hintUbicacion", hint);
        fragment.setArguments(arguments);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(getArguments()!=null){
            ubicacionOrigen = getArguments().getBoolean("tipoUbicacion");
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_ubicacion,container,false);
        codigoUbicacionEt = (EditText) rootView.findViewById(R.id.codigoUbicacionEt);
        codigoUbicacionEt.setHint(getArguments().getString("hintUbicacion"));
        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        codigoUbicacionEt.requestFocus();

        codigoUbicacionEt.setOnKeyListener(new OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                // If the event is a key-down event on the "enter" button
                if ((event.getAction() == KeyEvent.ACTION_DOWN) &&
                        (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    // Perform action on key press
                    listener.setLecturaAnt(codigoUbicacionEt.getText().toString().replaceFirst("\r",""));
                    codigoUbicacionEt.setText(listener.getLecturaAnt());
                    listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString().replaceFirst("\r",""),Boolean.toString(ubicacionOrigen));
                    return true;
                }
                return false;
            }
        });
        return rootView;
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
        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString().replaceFirst("\r",""), Boolean.toString(ubicacionOrigen));
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
