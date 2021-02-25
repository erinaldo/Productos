package com.selling.movil.fragments;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

/**
 * Created by Eduardo on 18/12/15.
 */
public class DetalleProductoCambioEstadoFragment extends Fragment implements View.OnClickListener{

    private final String TAG = DetalleProductoCambioEstadoFragment.class.getName();

    private Spinner cambioEstadoSpinner;
    private Button aceptarBtn;

    private TextView claveTv;
    private TextView nombreTv;
    private TextView existenciaTv;
    private TextView apartadoTv;
    private TextView bloqueadoTv;

    private JSONObject detalleProductoJson;
    private String codigoUbicacion;

    private OnAceptarListener listener;

    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        listener.onAceptar(parametros[0], detalleProductoJson.getString("PROClave"), cambioEstadoSpinner.getSelectedItem().toString().equals(ValoresEstaticos.ESTADO_BLOQUEADO) ? "true" : "false");
                    } catch (Exception e){
                        Log.e(TAG,e.getMessage(),e);
                    }
                }
            });
        }
    });

    public DetalleProductoCambioEstadoFragment() {
    }

    public static DetalleProductoCambioEstadoFragment newInstance(String detalleProductoJson, String codigoUbicacion){
        DetalleProductoCambioEstadoFragment fragment = new DetalleProductoCambioEstadoFragment();
        Bundle arguments = new Bundle();
        arguments.putString("detalleProducto", detalleProductoJson);
        arguments.putString("codigoUbicacion", codigoUbicacion);
        fragment.setArguments(arguments);
        return fragment;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_detalle_producto_estado,container,false);

        claveTv = (TextView) rootView.findViewById(R.id.clave);
        nombreTv = (TextView) rootView.findViewById(R.id.nombre);
        existenciaTv = (TextView) rootView.findViewById(R.id.existencia);
        apartadoTv = (TextView) rootView.findViewById(R.id.apartado);
        bloqueadoTv = (TextView) rootView.findViewById(R.id.bloqueado);

        cambioEstadoSpinner = (Spinner) rootView.findViewById(R.id.cambioEstadoSpinner);
        aceptarBtn = (Button) rootView.findViewById(R.id.aceptarBtn);
        aceptarBtn.setOnClickListener(this);
        llenarDatos();
        llenarSpinner();
        return rootView;
    }

    private void llenarSpinner(){

        try {
            ArrayList<String> opciones = new ArrayList<>();
            opciones.add(ValoresEstaticos.ESTADO_BLOQUEADO);
            if (detalleProductoJson.getDouble("Bloqueado") > 0)
                opciones.add(ValoresEstaticos.ESTADO_DESBLOQUEADO);

            ArrayAdapter<String> estadosAdapter = new ArrayAdapter<String>(
                    getActivity(), android.R.layout.simple_spinner_item, opciones);

            estadosAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

            cambioEstadoSpinner.setAdapter(estadosAdapter);
        } catch (JSONException e){
            Log.e(TAG,e.getMessage(),e);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }


    }

    private void llenarDatos(){

        try{
            if(getArguments() != null) {
                codigoUbicacion = getArguments().getString("codigoUbicacion");
                detalleProductoJson = new JSONObject(getArguments().getString("detalleProducto"));
                claveTv.setText(detalleProductoJson.getString("PROClave"));
                nombreTv.setText(detalleProductoJson.getString("Nombre"));
                existenciaTv.setText(detalleProductoJson.getString("Existencia"));
                apartadoTv.setText(detalleProductoJson.getString("Apartado"));
                bloqueadoTv.setText(detalleProductoJson.getString("Bloqueado"));
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
            listener = (OnAceptarListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnAceptarListener");
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
            listener.onAceptar(codigoUbicacion, detalleProductoJson.getString("PROClave"),cambioEstadoSpinner.getSelectedItem().toString().equals(ValoresEstaticos.ESTADO_BLOQUEADO)?"true":"false");
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
