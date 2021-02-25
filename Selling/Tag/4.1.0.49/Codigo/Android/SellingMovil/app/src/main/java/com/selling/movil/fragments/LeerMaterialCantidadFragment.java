package com.selling.movil.fragments;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.adapters.ReubicacionAdapter;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.modelos.Reubicacion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import java.util.ArrayList;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerMaterialCantidadFragment extends Fragment implements View.OnClickListener {

    private final String TAG = LeerMaterialCantidadFragment.class.getName();
    private EditText codigoMaterialEt;
    private EditText cantidadMaterialEt;
    private Button aceptarBtn;
    private OnLeerCodigoMaterialListener listener;
    private ListView list;
    private ArrayList<Reubicacion> reubicacionArray;
    private ReubicacionAdapter reubicacionAdapter;

    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        codigoMaterialEt.setText(parametros[0]);
                        codigoLeido("0");
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    public LeerMaterialCantidadFragment() {
    }

    public static LeerMaterialCantidadFragment newInstance() {
        LeerMaterialCantidadFragment fragment = new LeerMaterialCantidadFragment();
        return fragment;
    }

    public void restart() {
        codigoMaterialEt.setText(R.string.leer_codigo_material_lbl);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_material_cantidad, container, false);
        final View aux = rootView;
        codigoMaterialEt = (EditText) rootView.findViewById(R.id.codigoMaterialEt);
        cantidadMaterialEt = (EditText) rootView.findViewById(R.id.cantidadMaterialEt);

        list = (ListView) rootView.findViewById(R.id.listCodigos);
        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        codigoMaterialEt.requestFocus();

        codigoMaterialEt.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                // If the event is a key-down event on the "enter" button
                if ((event.getAction() == KeyEvent.ACTION_DOWN) &&
                        (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    // Perform action on key press
                    codigoLeido("0");

                    if (listener.getArrayReubicacion() != null)
                    {
                        reubicacionAdapter = new ReubicacionAdapter(getActivity(), R.layout.row_reubicacion, listener.getArrayReubicacion());

                        list.setAdapter(reubicacionAdapter);
                    }
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
        codigoLeido("1");
    }

    @Override
    public void onPause() {
        super.onPause();
        try {
            if (MetodosEstaticos.obtenerTerminal(getActivity()).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                MetodosEstaticos.removeBarcodeListener(getActivity(), barcodeListener);
        } catch (Exception e) {
            Log.e(TAG, e.getMessage(), e);
        }
    }

    @Override
    public void onResume() {
        super.onResume();
        try {
            if (MetodosEstaticos.obtenerTerminal(getActivity()).equalsIgnoreCase(ValoresEstaticos.PREFERENCES_TERMINAL_INT_CN51))
                MetodosEstaticos.setBarcodeListener(getActivity(), barcodeListener);

            if (listener.getArrayReubicacion() != null)
            {
                String prueba = getActivity().toString();
                reubicacionAdapter = new ReubicacionAdapter(getActivity(), R.layout.row_reubicacion, listener.getArrayReubicacion());
                list.setAdapter(reubicacionAdapter);
            }
        } catch (Exception e) {
            Log.e(TAG, e.getMessage(), e);
        }
    }

    private void codigoLeido(String avanza){
        String material = codigoMaterialEt.getText().toString().replaceFirst("\r","");
        material = material.trim();
        codigoMaterialEt.setText(material.substring((material.length() == 10? 1:0)));
        listener.setMaterialAnt(codigoMaterialEt.getText().toString().replaceFirst("\r",""));
        codigoMaterialEt.setText(listener.getMaterialAnt());
        listener.onCodigoMaterialLeido(codigoMaterialEt.getText().toString().replaceFirst("\r",""), cantidadMaterialEt.getText().toString().replaceFirst("\r",""), avanza);
    }

}