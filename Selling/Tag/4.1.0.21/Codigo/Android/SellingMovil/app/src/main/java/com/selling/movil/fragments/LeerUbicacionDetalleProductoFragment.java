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
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoUbicacionListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by Eduardo on 18/12/15.
 */
public class LeerUbicacionDetalleProductoFragment extends Fragment implements View.OnClickListener{

    private final String TAG = LeerUbicacionDetalleProductoFragment.class.getName();

    private EditText codigoUbicacionEt;
    private Button aceptarBtn;
    private OnLeerCodigoUbicacionListener listener;
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
                        codigoUbicacionEt.setText(parametros[0]);
                        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString());
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    public LeerUbicacionDetalleProductoFragment() {
    }

    public static LeerUbicacionDetalleProductoFragment newInstance(String detalleProductoString,String hint){
        LeerUbicacionDetalleProductoFragment fragment = new LeerUbicacionDetalleProductoFragment();
        Bundle arguments = new Bundle();
        arguments.putString("detalleProducto", detalleProductoString);
        arguments.putString("hintUbicacion", hint);
        fragment.setArguments(arguments);
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_leer_ubicacion_detalle_producto,container,false);

        claveTv = (TextView) rootView.findViewById(R.id.clave);
        descripcionTv = (TextView) rootView.findViewById(R.id.descripcion);
        areaTv = (TextView) rootView.findViewById(R.id.area);
        ubicacionTv = (TextView) rootView.findViewById(R.id.ubicacion);


        codigoUbicacionEt = (EditText) rootView.findViewById(R.id.codigoUbicacionEt);
        codigoUbicacionEt.setHint(getArguments().getString("hintUbicacion"));
        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);

        llenarDatos();

        return rootView;
    }

    private void llenarDatos(){

        try{
            if(getArguments() != null) {
                detalleProductoJson = new JSONObject(getArguments().getString("detalleProducto"));
                claveTv.setText(detalleProductoJson.getString("PROClave"));
                descripcionTv.setText(detalleProductoJson.getString("Descripcion"));
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
        listener.onCodigoUbicacionLeido(codigoUbicacionEt.getText().toString());
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
