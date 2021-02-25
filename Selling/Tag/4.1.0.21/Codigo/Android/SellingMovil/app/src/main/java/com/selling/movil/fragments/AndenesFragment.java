package com.selling.movil.fragments;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import com.selling.movil.R;
import com.selling.movil.adapters.AndenesAdapter;
import com.selling.movil.adapters.ExistenciasAdapter;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.modelos.Anden;
import com.selling.movil.modelos.Existencia;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;

/**
 * Created by Eduardo on 18/12/15.
 */
public class AndenesFragment extends Fragment{

    private final String TAG = AndenesFragment.class.getName();

    private ListView andenesList;
    private ArrayList<Anden> andenesArray;
    private AndenesAdapter andenesAdapter;
    private JSONArray andenesJSON;

    private OnAceptarListener listener;

    public AndenesFragment() {
    }

    public static AndenesFragment newInstance(){
        AndenesFragment fragment = new AndenesFragment();
        return fragment;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_andenes,container,false);
        andenesList = (ListView) rootView.findViewById(R.id.andenesList);
        andenesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                listener.onAceptar(andenesArray.get(position).getIdRecibo());
            }
        });
        cargarAndenes();

        return rootView;
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


    private void cargarAndenes(){

        new Conexion(getActivity(), new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {


                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Ubicacion/Andenes?"+ValoresEstaticos.PARAMETRO_ALMACEN+"="+ MetodosEstaticos.obtenerAlmacenClave(getActivity()));
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(getActivity()));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(false);
                    httpUrlConn.setDoInput(true);
                    httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

                    Log.i(TAG, httpUrlConn.getURL().toString());
                    httpUrlConn.connect();
                    if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        InputStream is = httpUrlConn.getInputStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        Log.i(TAG, result);
                    } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                        errorToken = true;
                    }  else if(httpUrlConn.getErrorStream() != null){
                        InputStream is = httpUrlConn.getErrorStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        Log.i(TAG, result);
                    } else {
                        result = null;
                    }

                    return result;

                }catch (SocketTimeoutException e){
                    return getString(R.string.error_servidor_lbl);
                } catch (Exception e) {
                    Log.e(TAG,e.getMessage(),e);
                    return null;
                }
            }

            @Override
            public void after(String result) {

                if(errorToken){
                    Toast.makeText(getActivity(),getActivity().getString(R.string.token_error_lbl),Toast.LENGTH_SHORT).show();
                    MetodosEstaticos.limpiarSesion(getActivity());
                } else {

                    if(result != null){
                        try{
                            JSONArray aux = new JSONArray(result);
                            llenarListadoAndenes(result);

                        } catch (Exception e){
                            try {
                                Toast.makeText(getActivity(), new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                            } catch (Exception ex){
                                Log.e(TAG,ex.getMessage(),ex);
                            }
                        }
                    } else {
                        Toast.makeText(getActivity(),getActivity().getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();
    }

    private void llenarListadoAndenes(String result){

        try{

            andenesArray = new ArrayList<>();
            andenesJSON = new JSONArray(result);

            JSONObject anden;
            for(int contadorAnden = 0;contadorAnden < andenesJSON.length();contadorAnden++){
                anden = andenesJSON.getJSONObject(contadorAnden);
                andenesArray.add(
                        new Anden(
                                anden.getString("IdRecibo"),
                                anden.getString("Folio"),
                                anden.getString("Anden"),
                                anden.getString("PorcentajeRecibo"),
                                anden.getString("NumPiezas")

                        )
                );
            }
            andenesAdapter = new AndenesAdapter(getActivity(),R.layout.row_anden,andenesArray);
            andenesList.setAdapter(andenesAdapter);
            if(andenesArray != null && andenesArray.size() <= 0)
                Toast.makeText(getActivity(),getActivity().getString(R.string.existencia_no_informacion_lbl),Toast.LENGTH_SHORT).show();


        } catch (JSONException e){
            Log.e(TAG,e.getMessage(),e);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }
}
