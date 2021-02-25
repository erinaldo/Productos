package com.selling.movil.fragments;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.selling.movil.Aplicacion;
import com.selling.movil.R;
import com.selling.movil.adapters.PagePedidoDetalleAdapter;
import com.selling.movil.adapters.PedidosDetalleAdapter;
import com.selling.movil.interfaces.AsyncTaskInterface;
import com.selling.movil.interfaces.OnBarcodeReadListener;
import com.selling.movil.interfaces.OnLeerCodigoMaterialListener;
import com.selling.movil.interfaces.OnSurtidoListener;
import com.selling.movil.listeners.BarcodeListener;
import com.selling.movil.modelos.Existencia;
import com.selling.movil.modelos.Pedido;
import com.selling.movil.modelos.PedidoDetalle;
import com.selling.movil.modelos.ValorReferencia;
import com.selling.movil.tasks.Conexion;
import com.selling.movil.utilerias.Dialogs;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedWriter;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;
import io.realm.Sort;

/**
 * Created by Eduardo on 18/12/15.
 */
//public class PedidosDetalleFragment extends Fragment implements AdapterView.OnItemSelectedListener{
public class PedidosDetalleFragment extends Fragment{

    private final String TAG = PedidosDetalleFragment.class.getName();
    /*private final String FILTRO_OPCION_TODOS = "Todos";
    private final String FILTRO_OPCION_ACTIVOS = "Activos";
    private final String FILTRO_OPCION_TERMINADOS = "Terminados";*/

    private OnSurtidoListener listener;

    private String areas;
    private JSONArray areasJSON;
    JSONArray opcionesJSON;
    private String DOCClave;

    private RealmResults<PedidoDetalle> pedidosDetalleRealm;
   // private ListView pedidosDetalleList;
    //private PedidosDetalleAdapter pedidosDetalleAdapter;
   // private Spinner filtrosActivosSp;
   // private Spinner filtrosAreasSp;

    private Realm realm;

    private TextView ubcTv;
    //private TextView prdTv;
    private EditText cantEt;
    private EditText codEt;
    private EditText stage;
    private AlertDialog stageAlert;

    private ViewPager pagePedidosDetalle;
    private PagePedidoDetalleAdapter adapter;
    private int posicionPager;


    private BarcodeListener barcodeListener = new BarcodeListener(new OnBarcodeReadListener() {
        @Override
        public void onBarcodeReaded(final String... parametros) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    try {
                        if(stageAlert != null && stageAlert.isShowing()){
                            validaStage();
                        } else {
                            codEt.setText(parametros[0]);
                            surtir();
                        }
                    } catch (Exception e) {
                        Log.e(TAG, e.getMessage(), e);
                    }
                }
            });
        }
    });

    public PedidosDetalleFragment() {
    }

    public static PedidosDetalleFragment newInstance(String areas,String DOCClave){
        PedidosDetalleFragment fragment = new PedidosDetalleFragment();
        Bundle arguments = new Bundle();
        arguments.putString("areas",areas);
        arguments.putString("DOCClave",DOCClave);
        fragment.setArguments(arguments);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        try {
            if (getArguments() != null) {
                areas = getArguments().getString("areas", null);
                areasJSON = new JSONArray(areas);
                DOCClave = getArguments().getString("DOCClave", null);
            }
            realm = ((Aplicacion) getActivity().getApplicationContext()).getRealmInstance();
        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        final View rootView = inflater.inflate(R.layout.fragment_pedidos_detalle,container,false);

       /* pedidosDetalleList = (ListView) rootView.findViewById(R.id.pedidosList);

        pedidosDetalleList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(pedidosDetalleRealm.get(position).getTransito().compareTo(pedidosDetalleRealm.get(position).getCantidad()) >= 0)
                    Toast.makeText(getActivity(),getActivity().getString(R.string.surtido_error_rechazo_terminado), Toast.LENGTH_SHORT).show();
                else
                    showOptionsDialog(position);
            }
        });
        pedidosDetalleList.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, final int position, long id) {
                Dialogs.confirmDialog(getActivity(), getActivity().getString(R.string.surtido_confirm_clean),
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                try {
                                    realm.beginTransaction();
                                    PedidoDetalle pedidoDetalle = pedidosDetalleRealm.get(position);
                                    pedidoDetalle.setTransito(0d);
                                    pedidoDetalle.setTiporechazo(0);
                                    pedidoDetalle.setActivo(true);
                                    realm.commitTransaction();

                                    Pedido pedido = realm.where(Pedido.class).equalTo("DOCClave", DOCClave).findFirst();
                                    JSONArray aumentarTransitoArray = new JSONArray();
                                    JSONArray detallesArrayJson = new JSONArray();

                                    JSONObject pedidoDetalleJson = new JSONObject();
                                    pedidoDetalleJson.put("AREClave", pedidoDetalle.getAREClave());
                                    pedidoDetalleJson.put("PROClave", pedidoDetalle.getPROClave());
                                    pedidoDetalleJson.put("UBCClave", pedidoDetalle.getUBCClave());
                                    pedidoDetalleJson.put("Transito", pedidoDetalle.getTransito());
                                    pedidoDetalleJson.put("TipoRechazo", pedidoDetalle.getTiporechazo());
                                    detallesArrayJson.put(pedidoDetalleJson);

                                    JSONObject pedidoJson = new JSONObject();
                                    pedidoJson.put("DOCClave", DOCClave);
                                    pedidoJson.put("TipoDocumento", pedido.getTipoDocumento());
                                    pedidoJson.put("detalles", detallesArrayJson);

                                    aumentarTransitoArray.put(pedidoJson);

                                    actualizaDetalle(aumentarTransitoArray.toString(), false);
                                } catch (Exception e) {
                                    Log.e(TAG,e.getMessage(),e);
                                }
                            }
                        },
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {

                            }
                        });

                return true;
            }
        });*/
        pagePedidosDetalle = (ViewPager) rootView.findViewById(R.id.pedidosDetallesPage);
        pagePedidosDetalle.setOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

            }

            @Override
            public void onPageSelected(int position) {
                posicionPager = position;
            }

            @Override
            public void onPageScrollStateChanged(int state) {

            }
        });

        rootView.findViewById(R.id.stbyBtn).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                standBy();
            }
        });
        rootView.findViewById(R.id.depositarBtn).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(realm.where(PedidoDetalle.class).equalTo("DOCClave",DOCClave).equalTo("activo",false).count() > 0)
                    validaStageDialog();
                else
                    Toast.makeText(getActivity(), getActivity().getString(R.string.surtido_no_disponible_stage_deposito), Toast.LENGTH_SHORT).show();
            }
        });
        rootView.findViewById(R.id.surtirBtn).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               surtir();
            }
        });
        rootView.findViewById(R.id.limpiar_campos).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ubcTv.setText("");
                //prdTv.setText("");
                cantEt.setText("1");
                codEt.setText("");
            }
        });

        ubcTv = (TextView) rootView.findViewById(R.id.ubicacion);
        //prdTv = (TextView) rootView.findViewById(R.id.producto);
        cantEt = (EditText) rootView.findViewById(R.id.cantidad);
        codEt = (EditText) rootView.findViewById(R.id.codigo);

        codEt.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event) {

                if (event.getAction() == KeyEvent.ACTION_DOWN)
                {
                    switch (keyCode)
                    {
                        case KeyEvent.KEYCODE_ENTER:
                            surtir();
                            return true;
                        default:
                            break;
                    }
                }
                return false;
            }
        });

       // filtrosActivosSp = (Spinner) rootView.findViewById(R.id.filtroActivosSp);
       // filtrosAreasSp = (Spinner) rootView.findViewById(R.id.filtroAreasSp);

        //initFiltersSpinner();
        llenarListadoPedidosDetalle("");

        return rootView;
    }

   /* private void initFiltersSpinner (){
        try {

            ArrayList<String> areasList = new ArrayList<>();
            opcionesJSON = new JSONArray();

            opcionesJSON.put(new JSONObject().put("AREClave","").put("clave",getActivity().getString(R.string.surtido_filtro_todas)));

            for(int contadorAreas = 0;contadorAreas < areasJSON.length();contadorAreas++) {
                if(realm.where(PedidoDetalle.class).equalTo("DOCClave",DOCClave).equalTo("AREClave",areasJSON.getJSONObject(contadorAreas).getString("AREClave")).count() > 0)
                    opcionesJSON.put(new JSONObject().put("AREClave", areasJSON.getJSONObject(contadorAreas).getString("AREClave")).put("clave", areasJSON.getJSONObject(contadorAreas).getString("clave")));
            }

            for(int contadorAreas = 0;contadorAreas < opcionesJSON.length();contadorAreas++)
                areasList.add(opcionesJSON.getJSONObject(contadorAreas).getString("clave"));

            ArrayAdapter<String> areasAdapter = new ArrayAdapter<String>(
                    getActivity(), android.R.layout.simple_spinner_item, areasList);

            areasAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

            filtrosAreasSp.setAdapter(areasAdapter);
            filtrosAreasSp.setOnItemSelectedListener(this);

            ArrayList<String> activosList = new ArrayList<>();
            activosList.add(FILTRO_OPCION_TODOS);
            activosList.add(FILTRO_OPCION_ACTIVOS);
            activosList.add(FILTRO_OPCION_TERMINADOS);

            ArrayAdapter<String> activosAdapter = new ArrayAdapter<String>(
                    getActivity(), android.R.layout.simple_spinner_item, activosList);

            activosAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

            filtrosActivosSp.setAdapter(activosAdapter);
            filtrosActivosSp.setOnItemSelectedListener(this);

        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }
    }*/

    private void actualizaDetalle(final String actualizar,final boolean esDeposito){

        new Conexion(getActivity(), new AsyncTaskInterface() {
            boolean errorToken = false;
            boolean success = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {



                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/"+(esDeposito?"depositar":"actualizaDetalle")+"?"
                            +ValoresEstaticos.PARAMETRO_ALMACEN+"="+MetodosEstaticos.obtenerAlmacenClave(getActivity())+
                            "&SUCClave="+MetodosEstaticos.obtenerSucursalClave(getActivity())+
                            "&COMClave="+MetodosEstaticos.obtenerCompaniaClave(getActivity())+
                            "&RechazoRF=0");

                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(getActivity()));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(true);
                    httpUrlConn.setDoInput(true);
                    httpUrlConn.setRequestProperty("Content-Type","application/json");

                    OutputStream os = httpUrlConn.getOutputStream();
                    BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));
                    writer.write(actualizar);
                    writer.flush();
                    writer.close();
                    os.close();

                    Log.i(TAG, httpUrlConn.getURL().toString());
                    httpUrlConn.connect();
                    if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        InputStream is = httpUrlConn.getInputStream();
                        result = MetodosEstaticos.getStringFromInputStream(is);
                        success = true;
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

                            if(success) {
                                if(esDeposito) {
                                    realm.beginTransaction();
                                    realm.where(PedidoDetalle.class).equalTo("DOCClave", DOCClave).equalTo("activo", false).findAll().deleteAllFromRealm();
                                    realm.commitTransaction();
                                    if (realm.where(PedidoDetalle.class).equalTo("DOCClave", DOCClave).count() <= 0) {
                                        listener.onDocumentoTerminado();
                                    }
                                }
                            } else {
                                try {
                                    Toast.makeText(getActivity(), new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                                } catch (Exception ex){
                                    Log.e(TAG,ex.getMessage(),ex);
                                }
                            }

                        } catch (Exception e){
                            Log.e(TAG,e.getMessage(),e);
                        }
                    } else {
                        Toast.makeText(getActivity(),getActivity().getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();
    }

    private void standBy(){

        new Conexion(getActivity(), new AsyncTaskInterface() {
            boolean errorToken = false;
            boolean success = false;

            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/ponerEnStandby");
                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(getActivity()));
                    httpUrlConn.setConnectTimeout(ValoresEstaticos.CONNECTION_TIMEOUT);
                    httpUrlConn.setDoOutput(true);
                    httpUrlConn.setDoInput(true);
                    httpUrlConn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

                    Map<String, String> parameters = new HashMap<>();
                    parameters.put("", DOCClave);

                    String parameterString = MetodosEstaticos.getEncodedData(parameters);

                    OutputStream os = httpUrlConn.getOutputStream();
                    BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));
                    writer.write(parameterString);
                    writer.flush();
                    writer.close();
                    os.close();

                    Log.i(TAG, httpUrlConn.getURL().toString());
                    httpUrlConn.connect();
                    Log.i("HTTP RESULT",Integer.toString(httpUrlConn.getResponseCode()));
                    if(httpUrlConn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        success = true;
                        result = "";
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

                            if(success) {
                                listener.onStandBySuccess(areas);
                            } else {
                                JSONObject aux = new JSONObject(result);
                                if(aux != null && aux.has("Message"))
                                    Toast.makeText(getActivity(), new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();

                            }


                        } catch (Exception e){
                            Log.e(TAG,e.getMessage(),e);
                        }
                    } else {
                        Toast.makeText(getActivity(),getActivity().getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();
    }

    private void validaProducto(final String codigoMaterial,final String cantidadMaterial){

        new Conexion(getActivity(), new AsyncTaskInterface() {
            boolean errorToken = false;
            boolean esValido = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {

                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/validarProducto?"+ValoresEstaticos.PARAMETRO_PRODUCTO+"="+codigoMaterial+
                            "&cantidad="+cantidadMaterial);
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
                            Boolean aux = Boolean.valueOf(result);
                            if(aux != null && aux){
                                surtirProcesando();
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

    private void llenarListadoPedidosDetalle(String filtro){

        try{

            RealmQuery<PedidoDetalle> pedidosDetalle = realm.where(PedidoDetalle.class).equalTo("DOCClave",DOCClave);

            if(!filtro.isEmpty())
                pedidosDetalle.equalTo("AREClave",filtro);

          /*  if (filtrosActivosSp.getSelectedItem().toString().equals(FILTRO_OPCION_ACTIVOS))
                pedidosDetalle.equalTo("activo",true);
            else if (filtrosActivosSp.getSelectedItem().toString().equals(FILTRO_OPCION_TERMINADOS))
                pedidosDetalle.equalTo("activo",false);*/

            //pedidosDetalleRealm = pedidosDetalle.findAll();
            pedidosDetalleRealm = pedidosDetalle.findAllSorted("Ubicacion", Sort.ASCENDING);

            //pedidosDetalleAdapter = new PedidosDetalleAdapter(getActivity(), pedidosDetalleRealm, R.layout.row_pedido_detalle);
            //pedidosDetalleList.setAdapter(pedidosDetalleAdapter);
            adapter = new PagePedidoDetalleAdapter(getActivity(),pedidosDetalleRealm,DOCClave, pagePedidosDetalle);
            pagePedidosDetalle.setAdapter(adapter);

            if(pedidosDetalleRealm.size() <= 0)
                Toast.makeText(getActivity(),getActivity().getString(R.string.existencia_no_informacion_lbl), Toast.LENGTH_SHORT).show();


        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }

  /*  @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

        try {
            llenarListadoPedidosDetalle(opcionesJSON.getJSONObject(filtrosAreasSp.getSelectedItemPosition()).getString("AREClave"));
        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }
    }*/

  /*  @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }*/

    private void showOptionsDialog(final int realmPosition){

        try {
            final RealmResults<ValorReferencia> tiposRechazo = realm.where(ValorReferencia.class).equalTo("tabla","Surtido").equalTo("campo", "TipoRechazo").findAll();

            final ArrayList<String> opciones = new ArrayList<>();

            for(ValorReferencia valorReferencia : tiposRechazo)
                opciones.add(valorReferencia.getDescripcion());

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(getActivity());
            LayoutInflater inflater = (getActivity()).getLayoutInflater();
            View convertView = inflater.inflate(R.layout.dialog_list, null);
            alertDialog.setView(convertView);
            alertDialog.setTitle(getActivity().getString(R.string.dialog_list_title));
            ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(getActivity(),android.R.layout.simple_list_item_1,opciones);
            opcionesList.setAdapter(adapter);
            final AlertDialog dialog = alertDialog.create();

            opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                    try{
                        realm.beginTransaction();
                        PedidoDetalle pedidoDetalle = pedidosDetalleRealm.get(realmPosition);
                        pedidoDetalle.setTiporechazo(tiposRechazo.get(position).getValor());
                        if(pedidoDetalle.getTiporechazo() == 0)
                            pedidoDetalle.setActivo(true);
                        else
                            pedidoDetalle.setActivo(false);
                        realm.commitTransaction();

                        Pedido pedido = realm.where(Pedido.class).equalTo("DOCClave",DOCClave).findFirst();
                        JSONArray aumentarTransitoArray = new JSONArray();
                        JSONArray detallesArrayJson = new JSONArray();

                        JSONObject pedidoDetalleJson = new JSONObject();
                        pedidoDetalleJson.put("AREClave",pedidoDetalle.getAREClave());
                        pedidoDetalleJson.put("PROClave",pedidoDetalle.getPROClave());
                        pedidoDetalleJson.put("UBCClave",pedidoDetalle.getUBCClave());
                        pedidoDetalleJson.put("Transito",pedidoDetalle.getTransito());
                        pedidoDetalleJson.put("TipoRechazo",pedidoDetalle.getTiporechazo());
                        detallesArrayJson.put(pedidoDetalleJson);

                        JSONObject pedidoJson = new JSONObject();
                        pedidoJson.put("DOCClave",DOCClave);
                        pedidoJson.put("TipoDocumento",pedido.getTipoDocumento());
                        pedidoJson.put("detalles",detallesArrayJson);

                        aumentarTransitoArray.put(pedidoJson);

                        actualizaDetalle(aumentarTransitoArray.toString(),false);
                        dialog.dismiss();
                    } catch (Exception e) {
                        Log.e(TAG,e.getMessage(),e);
                    }

                }
            });

            dialog.show();
        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }

    }

    private void surtir(){
        try {
            if(!codEt.getText().toString().isEmpty()) {
                if(ubcTv.getText().toString().isEmpty()) {

                    if(existeUbicacion(codEt.getText().toString().replace("-","").toUpperCase())) {
                        ubcTv.setText(codEt.getText());
                        codEt.setText("");
                        codEt.setHint("Producto");


                    } else {
                        Toast.makeText(getActivity(),getActivity().getString(R.string.surtido_error_ubicacion), Toast.LENGTH_SHORT).show();
                    }
                } else {

                    String cantidadLeido = cantEt.getText().toString();
                    String producto = codEt.getText().toString();
                    //Se separo la funcionalidad en los metodos surtido/surtidoProcesando para que se pudiera realizar correctamente la validacion de decimales
                    validaProducto(producto, cantidadLeido);

                }
            } else {
                Toast.makeText(getActivity(), getActivity().getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
            }

        } catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }
    }

    private boolean existeUbicacion(String ubicacion) {

        return pedidosDetalleRealm.where().equalTo("ubicacionCompara",ubicacion).count() > 0;
    }

    private boolean existeProducto(String producto,String ubicacion) {

        return pedidosDetalleRealm.where().equalTo("ubicacionCompara",ubicacion).equalTo("productoCompara",producto).or()
                .equalTo("NumParte",producto).or()
                .equalTo("Alterno1",producto).or()
                .equalTo("Alterno2",producto).or()
                .equalTo("Alterno3",producto).or()
                .equalTo("GTIN",producto).count() > 0;
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
    public void onAttach(Context context) {
        super.onAttach(context);
        try {
            listener = (OnSurtidoListener) context;
        } catch (ClassCastException e) {
            throw new ClassCastException(context.toString()
                    + " must implement OnSurtidoListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        listener = null;
    }

    private void validaStageDialog(){

        LayoutInflater layoutInflater = LayoutInflater.from(getActivity());
        View promptView = layoutInflater.inflate(R.layout.dialog_surtido_stage, null);
        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(getActivity());
        alertDialogBuilder.setView(promptView);
        stage = (EditText) promptView.findViewById(R.id.userInput);
        ((TextView) promptView.findViewById(R.id.message)).setText(
                getActivity().getString(R.string.surtido_leer_stage_msg) + " " + realm.where(Pedido.class).equalTo("DOCClave",DOCClave).findFirst().getStage());
        alertDialogBuilder
                .setCancelable(true)
                .setNegativeButton(getActivity().getString(R.string.dialog_cancelar_lbl), new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        stageAlert.dismiss();
                        stageAlert = null;
                    }
                })
                .setPositiveButton(getActivity().getString(R.string.leer_codigo_enviar_lbl), new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        validaStage();
                    }
                });

        stageAlert= alertDialogBuilder.create();

        stageAlert.show();


    }

    private void validaStage(){

        try {

            String stageString = stage.getText().toString().replace("-","").toUpperCase();
            Pedido pedido = realm.where(Pedido.class).equalTo("DOCClave",DOCClave).findFirst();

            if(!stageString.isEmpty()) {
                if(stageString.equals(pedido.getStageComparar())){

                    RealmResults<PedidoDetalle> pedidosDetalles = realm.where(PedidoDetalle.class).equalTo("DOCClave",DOCClave).equalTo("activo",false).findAll();

                    JSONArray depositarArray = new JSONArray();
                    JSONArray detallesArrayJson = new JSONArray();

                    JSONObject pedidoDetalleJson;

                    for(PedidoDetalle pedidoDetalle : pedidosDetalles) {
                        pedidoDetalleJson = new JSONObject();

                        pedidoDetalleJson.put("AREClave",pedidoDetalle.getAREClave());
                        pedidoDetalleJson.put("PROClave",pedidoDetalle.getPROClave());
                        pedidoDetalleJson.put("UBCClave",pedidoDetalle.getUBCClave());
                        pedidoDetalleJson.put("Transito",pedidoDetalle.getTransito());
                        pedidoDetalleJson.put("TipoRechazo",pedidoDetalle.getTiporechazo());

                        detallesArrayJson.put(pedidoDetalleJson);
                    }

                    JSONObject pedidoJson = new JSONObject();
                    pedidoJson.put("DOCClave",DOCClave);
                    pedidoJson.put("TipoDocumento",pedido.getTipoDocumento());
                    pedidoJson.put("detalles",detallesArrayJson);

                    depositarArray.put(pedidoJson);

                    actualizaDetalle(depositarArray.toString(),true);


                } else {
                    Toast.makeText(getActivity(), getActivity().getString(R.string.surtido_error_stage_deposito), Toast.LENGTH_SHORT).show();
                    validaStageDialog();
                }
            } else {
                Toast.makeText(getActivity(), getActivity().getString(R.string.leer_codigo_vacio_lbl), Toast.LENGTH_SHORT).show();
                validaStageDialog();
            }

        } catch (Exception e) {
            Log.e(TAG,e.getMessage(),e);
        }

    }

    private void surtirProcesando(){
        try {
            boolean ultimo = false;
            String ubicacion = ubcTv.getText().toString();
            String producto = codEt.getText().toString();

            if(existeProducto(producto.replace("-","").toUpperCase(),ubicacion.replace("-","").toUpperCase())) {
                //prdTv.setText(producto);
                PedidoDetalle pedidoDetalleLeido =  pedidosDetalleRealm.where().equalTo("ubicacionCompara",ubicacion.replace("-","").toUpperCase()).equalTo("productoCompara",producto.replace("-","").toUpperCase()).or()
                        .equalTo("NumParte",producto.replace("-","").toUpperCase()).or()
                        .equalTo("Alterno1",producto.replace("-","").toUpperCase()).or()
                        .equalTo("Alterno2",producto.replace("-","").toUpperCase()).or()
                        .equalTo("Alterno3",producto.replace("-","").toUpperCase()).or()
                        .equalTo("GTIN",producto.replace("-","").toUpperCase()).findFirst();

                double cantidadTotal = pedidoDetalleLeido.getCantidad();
                double cantidadLeido = Double.parseDouble(cantEt.getText().toString());
                double transito = pedidoDetalleLeido.getTransito()==null?0:pedidoDetalleLeido.getTransito();
                double transitoActualizado = transito + cantidadLeido;

                if( (pedidoDetalleLeido.getTiporechazo() == null || pedidoDetalleLeido.getTiporechazo() == 0) &&  transitoActualizado  <= cantidadTotal) {

                    realm.beginTransaction();
                    pedidoDetalleLeido.setTransito(transitoActualizado);
                    if(pedidoDetalleLeido.getCantidad() == transitoActualizado)
                        pedidoDetalleLeido.setActivo(false);
                    realm.commitTransaction();

                    Pedido pedido = realm.where(Pedido.class).equalTo("DOCClave",DOCClave).findFirst();
                    JSONArray aumentarTransitoArray = new JSONArray();
                    JSONArray detallesArrayJson = new JSONArray();

                    JSONObject pedidoDetalleJson = new JSONObject();
                    pedidoDetalleJson.put("AREClave",pedidoDetalleLeido.getAREClave());
                    pedidoDetalleJson.put("PROClave",pedidoDetalleLeido.getPROClave());
                    pedidoDetalleJson.put("UBCClave",pedidoDetalleLeido.getUBCClave());
                    pedidoDetalleJson.put("Transito",pedidoDetalleLeido.getTransito());
                    pedidoDetalleJson.put("TipoRechazo",pedidoDetalleLeido.getTiporechazo());
                    detallesArrayJson.put(pedidoDetalleJson);

                    JSONObject pedidoJson = new JSONObject();
                    pedidoJson.put("DOCClave",DOCClave);
                    pedidoJson.put("TipoDocumento",pedido.getTipoDocumento());
                    pedidoJson.put("detalles",detallesArrayJson);

                    aumentarTransitoArray.put(pedidoJson);

                    actualizaDetalle(aumentarTransitoArray.toString(),false);


                    if(posicionPager + 1 == adapter.getCount()){
                        ultimo = true;
                    }

                    pagePedidosDetalle.setAdapter(adapter);

/*                    if(ultimo){
                        pagePedidosDetalle.setCurrentItem(adapter.getCount());
                    }*/

                } else {
                    if(transitoActualizado > cantidadTotal)
                        Toast.makeText(getActivity(),getActivity().getString(R.string.surtido_error_cantidad), Toast.LENGTH_SHORT).show();
                    else if(pedidoDetalleLeido.getTiporechazo() != 0)
                        Toast.makeText(getActivity(),getActivity().getString(R.string.surtido_error_rechazado), Toast.LENGTH_SHORT).show();
                }

                if(cantidadTotal == transitoActualizado){
                    int posicionCambiar;
                    if(!ultimo){
                        posicionCambiar = posicionPager +1;
                    }else{
                        posicionCambiar = posicionPager;
                    }

                    pagePedidosDetalle.setCurrentItem(posicionCambiar);
                }else{
                    pagePedidosDetalle.setCurrentItem(posicionPager);
                }

                codEt.setText("");
                codEt.setHint("Ubicación");
                ubcTv.setText("");
                //prdTv.setText("");

            } else {
                Toast.makeText(getActivity(),getActivity().getString(R.string.surtido_error_ubicacionproducto), Toast.LENGTH_SHORT).show();
            }
        }catch (Exception e){
            Log.e(TAG,e.getMessage(),e);
        }

    }


}
