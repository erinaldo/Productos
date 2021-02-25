package com.selling.movil.fragments;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import com.selling.movil.R;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerMaterialFragment extends Fragment implements View.OnClickListener{

    private final String TAG = LeerMaterialFragment.class.getName();
    private EditText codigoMaterialEt;
    private Button aceptarBtn;
    private OnLeerCodigoMaterialListener listener;
    private String codigoUbicacion;

    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        codigoMaterialEt.setText(parametros[0]);
                        listener.onCodigoMaterialLeido(codigoUbicacion,codigoMaterialEt.getText().toString());
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    public LeerMaterialFragment() {
    }

    public static LeerMaterialFragment newInstance(String codigoUbicacion){
        LeerMaterialFragment fragment = new LeerMaterialFragment();
        Bundle arguments = new Bundle();
        arguments.putString("codigoUbicacion",codigoUbicacion);
        fragment.setArguments(arguments);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(getArguments() != null){
            codigoUbicacion = getArguments().getString("codigoUbicacion",null);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_material,container,false);
        codigoMaterialEt = (EditText) rootView.findViewById(R.id.codigoMaterialEt);
        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        return rootView;
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
        listener.onCodigoMaterialLeido(codigoUbicacion, codigoMaterialEt.getText().toString());
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
