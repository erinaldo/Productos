package com.selling.movil.fragments;

import android.app.Activity;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;
import com.selling.movil.Aplicacion;
import com.selling.movil.R;
import com.selling.movil.adapters.PedidosAdapter;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnSurtidoListener;
import com.selling.movil.modelos.Pedido;
import com.selling.movil.modelos.PedidoDetalle;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.sql.Time;
import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.Executor;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

import io.realm.Realm;
import io.realm.RealmResults;

/**
 * Created by Eduardo on 18/12/15.
 */
public class PedidosFragment extends Fragment{

    private final String TAG = PedidosFragment.class.getName();
    private final static int INTERVAL = 1000 * 60 * 1;

    private String areas;
    private String DOCClave;

    private RealmResults<Pedido> pedidosRealm;
    private ListView pedidosList;
    private PedidosAdapter pedidosAdapter;

    private Handler handler = new Handler();
    private final Runnable sendData = new Runnable(){
        public void run(){
            try {
                listener.onRefrescarPedidos(areas);
                handler.postDelayed(this, 1000*60);
            }
            catch (Exception e) {
                e.printStackTrace();
            }
        }
    };

    private OnSurtidoListener listener;

    public PedidosFragment() {
    }

    public static PedidosFragment newInstance(String areas){
        PedidosFragment fragment = new PedidosFragment();
        Bundle arguments = new Bundle();
        arguments.putString("areas",areas);
        fragment.setArguments(arguments);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(getArguments() != null){
            areas = getArguments().getString("areas",null);
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        handler.post(sendData);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_pedidos,container,false);

        pedidosList = (ListView) rootView.findViewById(R.id.pedidosList);
        pedidosList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                DOCClave = pedidosRealm.get(position).getDOCClave();
                asignarSurtidoDestalleUsuario();


            }
        });

        rootView.findViewById(R.id.syncBtn).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                listener.onRefrescarPedidos(areas);
            }
        });
        rootView.findViewById(R.id.homeBtn).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getActivity().finish();
            }
        });

        return rootView;
    }

    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        try {
            listener = (OnSurtidoListener) activity;
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
    public void onPause() {
        super.onPause();
        handler.removeCallbacks(sendData);
    }

    public void llenarListadoPedidos(String result, boolean solicitado){

        Realm realm = null;
        try{

            realm = ((Aplicacion) getActivity().getApplicationContext()).getRealmInstance();
            realm.beginTransaction();

            realm.where(Pedido.class).findAll().deleteAllFromRealm();
            realm.where(PedidoDetalle.class).findAll().deleteAllFromRealm();

            JSONArray pedidosJSON;
            JSONObject pedidoJSON;
            if(solicitado){
                pedidoJSON = new JSONObject(result);
                realm.createObjectFromJson(Pedido.class,pedidoJSON);
            } else {
                pedidosJSON = new JSONArray(result);
                realm.createAllFromJson(Pedido.class,pedidosJSON);
            }

            RealmResults<PedidoDetalle> pedidosDetalle = realm.where(PedidoDetalle.class).findAll();
            for(PedidoDetalle pedidoDetalle: pedidosDetalle) {
                pedidoDetalle.setProductoCompara(pedidoDetalle.getProducto().replace("-","").toUpperCase());
                pedidoDetalle.setUbicacionCompara(pedidoDetalle.getUbicacion().replace("-","").toUpperCase());
                pedidoDetalle.setNumParte(pedidoDetalle.getNumParte().replace("-","").toUpperCase());
                pedidoDetalle.setAlterno1(pedidoDetalle.getAlterno1().replace("-","").toUpperCase());
                pedidoDetalle.setAlterno2(pedidoDetalle.getAlterno2().replace("-","").toUpperCase());
                pedidoDetalle.setAlterno3(pedidoDetalle.getAlterno3().replace("-","").toUpperCase());
                pedidoDetalle.setGTIN(pedidoDetalle.getGTIN().replace("-","").toUpperCase());
                if(pedidoDetalle.getCantidad().compareTo(pedidoDetalle.getTransito()!=null?pedidoDetalle.getTransito():0) == 0 || (pedidoDetalle.getTiporechazo() != null && pedidoDetalle.getTiporechazo().compareTo(0) != 0))
                    pedidoDetalle.setActivo(false);
                else
                    pedidoDetalle.setActivo(true);
            }

            pedidosRealm = realm.where(Pedido.class).findAll();

            for(Pedido pedido : pedidosRealm)
                pedido.setStageComparar(pedido.getStage().replace("-","").toUpperCase());

            pedidosAdapter = new PedidosAdapter(getActivity(),pedidosRealm,R.layout.row_pedido);
            pedidosList.setAdapter(pedidosAdapter);

            realm.commitTransaction();

            if(!solicitado && pedidosRealm.size() <= 0)
                listener.onSolicitarPedido(areas);
            else if(pedidosRealm.size() <= 0) {
                Toast.makeText(getActivity(), getActivity().getString(R.string.existencia_no_informacion_lbl), Toast.LENGTH_SHORT).show();
            }


        } catch (JSONException e){
            Log.e(TAG,e.getMessage(),e);
            realm.cancelTransaction();
        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
            realm.cancelTransaction();
        }

    }

    private void asignarSurtidoDestalleUsuario(){

        new Conexion(getActivity(), new AsyncTaskInterface() {
            boolean errorToken = false;
            boolean esValido = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    JSONArray areasJsonArray = new JSONArray(areas);
                    StringBuilder areClaves = new StringBuilder();

                    for(int contadorAreas = 0; contadorAreas < areasJsonArray.length(); contadorAreas++)
                        areClaves.append("&AREClaves=" + MetodosEstaticos.getEncodedData(areasJsonArray.getJSONObject(contadorAreas).getString("AREClave")));

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/asignarDocUsu?DOCClave="+DOCClave
                            +areClaves
                    );
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(getActivity()));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(true);
                    httpUrlConn.setDoInput(true);
                    httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

                   /* Map<String, String> parameters = new HashMap<>();
                    parameters.put("", DOCClave);
                    parameters.put("",areClaves);

                    String parameterString = MetodosEstaticos.getEncodedData(parameters);

                    OutputStream os = httpUrlConn.getOutputStream();
                    BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));
                    writer.write(parameterString);
                    writer.flush();
                    writer.close();
                    os.close();*/

                    Log.i(TAG, httpUrlConn.getURL().toString());
                    httpUrlConn.connect();
                    if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getInputStream());
                    } else if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_FORBIDDEN){
                        errorToken = true;
                    }  else if(httpUrlConn.getErrorStream() != null){
                        result = MetodosEstaticos.getStringFromInputStream(httpUrlConn.getErrorStream());
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
                            if(result.equals("")){
                                listener.onItemListClick(areas,DOCClave);
                            }else{
                                Toast.makeText(getActivity(), new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                            }
                        } catch (Exception e){
                            Log.e(TAG, e.getMessage(), e);
                        }
                    } else {
                        Toast.makeText(getActivity(),getActivity().getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }

            }
        }).execute();
    }

}
