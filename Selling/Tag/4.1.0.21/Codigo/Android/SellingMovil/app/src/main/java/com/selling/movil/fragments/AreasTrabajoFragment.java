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
import android.widget.ListView;
import android.widget.Toast;

import com.selling.movil.R;
import com.selling.movil.adapters.AndenesAdapter;
import com.selling.movil.adapters.AreasAdapter;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnAceptarListener;
import com.selling.movil.modelos.Anden;
import com.selling.movil.modelos.AreaTrabajo;
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
public class AreasTrabajoFragment extends Fragment{

    private final String TAG = AreasTrabajoFragment.class.getName();

    private ListView areasList;
    private ArrayList<AreaTrabajo> areasArray;
    private AreasAdapter areasAdapter;
    private JSONArray areasJSON;

    private OnAceptarListener listener;

    public AreasTrabajoFragment() {
    }

    public static AreasTrabajoFragment newInstance(){
        AreasTrabajoFragment fragment = new AreasTrabajoFragment();
        return fragment;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, final ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_areas_trabajo,container,false);
        areasList = (ListView) rootView.findViewById(R.id.areasList);
        areasList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(!areasArray.get(position).isAsignado()) {
                    areasArray.get(position).setSeleccionado(!areasArray.get(position).isSeleccionado());
                    areasAdapter.notifyDataSetChanged();
                } else {
                    Toast.makeText(getActivity(),getActivity().getString(R.string.surtido_area_asignada_lbl),Toast.LENGTH_SHORT).show();
                }
            }
        });

        rootView.findViewById(R.id.aceptarBtn).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                try {

                    JSONArray areasSeleccionadasJson = new JSONArray();
                    for(AreaTrabajo area : areasArray){
                        if(area.isSeleccionado()) {
                            areasSeleccionadasJson.put(new JSONObject().put("AREClave",area.getAREClave()).put("clave",area.getClave()));
                        }

                    }

                    if(areasSeleccionadasJson.length() > 0)
                        listener.onAceptar(areasSeleccionadasJson.toString());
                    else
                        Toast.makeText(getActivity(),getActivity().getString(R.string.surtido_area_no_seleccionada_lbl),Toast.LENGTH_SHORT).show();
                } catch (Exception e) {
                    Log.e(TAG,e.getMessage(),e);
                }
            }
        });
        cargarAreas();

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


    private void cargarAreas(){

        new Conexion(getActivity(), new AsyncTaskInterface() {
            boolean errorToken = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {


                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/areas?"
                            +ValoresEstaticos.PARAMETRO_ALMACEN+"="+ MetodosEstaticos.obtenerAlmacenClave(getActivity()) +
                            "&mostrador="+Boolean.toString(MetodosEstaticos.obtenerTipoSurtido(getActivity())));
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
                            llenarListadoAreas(result);

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

    private void llenarListadoAreas(String result){

        try{

            areasArray = new ArrayList<>();
            areasJSON = new JSONArray(result);

            JSONObject area;
            for(int contadorArea = 0; contadorArea < areasJSON.length(); contadorArea++){
                area = areasJSON.getJSONObject(contadorArea);
                areasArray.add(
                        new AreaTrabajo(
                                area.getString("AREClave"),
                                area.getString("Clave"),
                                area.getBoolean("asignado"),
                                area.getBoolean("asignado")
                        )
                );
            }
            areasAdapter = new AreasAdapter(getActivity(),R.layout.row_area, areasArray);
            areasList.setAdapter(areasAdapter);

            if(areasArray != null && areasArray.size() <= 0)
                Toast.makeText(getActivity(),getActivity().getString(R.string.existencia_no_informacion_lbl),Toast.LENGTH_SHORT).show();


        } catch (JSONException e){
            Log.e(TAG,e.getMessage(),e);
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }
}
