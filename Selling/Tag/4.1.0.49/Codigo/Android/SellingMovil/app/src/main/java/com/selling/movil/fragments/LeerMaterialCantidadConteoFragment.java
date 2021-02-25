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
import android.widget.ListView;

import com.selling.movil.R;
import com.selling.movil.adapters.ReubicacionAdapter;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnSiguienteListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.modelos.Reubicacion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerMaterialCantidadConteoFragment extends Fragment implements View.OnClickListener{

    private final String TAG = LeerMaterialCantidadConteoFragment.class.getName();
    private EditText codigoMaterialEt;
    private EditText cantidadMaterialEt;
    private Button aceptarBtn;
    private OnLeerCodigoMaterialListener listener;
    private Button siguienteBtn;
    private OnSiguienteListener siguienteListener;
    private ListView list;
    private ReubicacionAdapter reubicacionAdapter;

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
                        codigoMaterialEt.setText(listener.getMaterialAnt());
                        listener.onCodigoMaterialLeido(codigoMaterialEt.getText().toString().replaceFirst("\r",""), cantidadMaterialEt.getText().toString().replaceFirst("\r",""));
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    public LeerMaterialCantidadConteoFragment() {
    }

    public static LeerMaterialCantidadConteoFragment newInstance(){
        LeerMaterialCantidadConteoFragment fragment = new LeerMaterialCantidadConteoFragment();
        return fragment;
    }

    public void restart(){
        codigoMaterialEt.setText(R.string.leer_codigo_material_lbl);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_material_cantidad_conteo,container,false);
        codigoMaterialEt = (EditText) rootView.findViewById(R.id.codigoMaterialEt);
        cantidadMaterialEt = (EditText) rootView.findViewById(R.id.cantidadMaterialEt);
        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        siguienteBtn = (Button) rootView.findViewById(R.id.siguienteBtn);
        siguienteBtn.setOnClickListener(this);
        siguienteBtn.setText((MetodosEstaticos.obtenerConteoNormal(getActivity()) ? R.string.conteo_siguiente_ubicacion : R.string.finalizar_conteo));
        codigoMaterialEt.requestFocus();
        list = (ListView) rootView.findViewById(R.id.listCodigos);
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
                    listener.onCodigoMaterialLeido(codigoMaterialEt.getText().toString().replaceFirst("\r",""), cantidadMaterialEt.getText().toString().replaceFirst("\r",""));

                    if (listener.getArrayReubicacion() != null || listener.getArrayReubicacion().size() > 0)
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
        }else if (v.getId() == R.id.siguienteBtn){
            siguienteListener.onSiguienteUbicacion();
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

            if (listener.getArrayReubicacion() != null)
            {
                reubicacionAdapter = new ReubicacionAdapter(getActivity(), R.layout.row_reubicacion, listener.getArrayReubicacion());
                list.setAdapter(reubicacionAdapter);
            }
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

}
