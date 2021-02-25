package com.selling.movil.adapters;

import android.content.Context;
import android.content.DialogInterface;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.selling.movil.Aplicacion;
import com.selling.movil.R;
import com.selling.movil.interfaces.AsyncTaskInterface;
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

import io.realm.Realm;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 24/03/2017.
 */
public class PagePedidoDetalleAdapter extends PagerAdapter {
    //private String[] datos = {};
    private Context ctx;
    private LayoutInflater layoutInflater;
    private RealmResults<PedidoDetalle> datos;
    private Realm realm;
    private String DOCClave;
    private ViewPager viewPager;
    private int pos;

    public PagePedidoDetalleAdapter(Context ctx, RealmResults<PedidoDetalle> results, String DOCClave, ViewPager viewPager){
        this.ctx = ctx;
        this.datos = results;
        this.DOCClave = DOCClave;
        this.viewPager = viewPager;
        realm = ((Aplicacion) ctx.getApplicationContext()).getRealmInstance();
    }

    @Override
    public int getCount() {
        return datos.size();
    }

    @Override
    public int getItemPosition(Object object) {
        return pos;
    }

    @Override
    public boolean isViewFromObject(View view, Object object) {
        return (view == (LinearLayout) object);
    }

    @Override
    public Object instantiateItem(ViewGroup container, final int position) {
        layoutInflater = (LayoutInflater) ctx.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View item_view = layoutInflater.inflate(R.layout.page_pedidos_detalle, container, false);

        TextView textPaginasTotal = (TextView) item_view.findViewById(R.id.numeroPaginaTotal);
        TextView textProducto = (TextView) item_view.findViewById(R.id.productoPage);
        TextView textUbicacion = (TextView) item_view.findViewById(R.id.ubicacionPage);
        TextView textCantidad = (TextView) item_view.findViewById(R.id.cantidadPage);
        final TextView textLeidos = (TextView) item_view.findViewById(R.id.surtidosPage);
        final TextView textRechazo = (TextView) item_view.findViewById(R.id.motRechazoPage);
        Button opc1 = (Button) item_view.findViewById(R.id.opciones1Btn);
        Button opc2 = (Button) item_view.findViewById(R.id.opciones2Btn);

        final PedidoDetalle pedidoDetalle = datos.get(position);
        String tipoRechazo = pedidoDetalle.getTiporechazo()!=0?
                realm.where(ValorReferencia.class).equalTo("tabla","Surtido").equalTo("campo", "TipoRechazo").equalTo("valor",pedidoDetalle.getTiporechazo()).findFirst().getDescripcion()
                :"";

        textPaginasTotal.setText((position + 1) + "/"+datos.size());
        textProducto.setText(pedidoDetalle.getProducto());
        textUbicacion.setText(pedidoDetalle.getUbicacion());
        textCantidad.setText(Double.toString(pedidoDetalle.getCantidad()));
        textLeidos.setText(pedidoDetalle.getTransito()!= null?Double.toString(pedidoDetalle.getTransito()):"0");
        textRechazo.setText(tipoRechazo);

        opc1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(pedidoDetalle.getTransito().compareTo(pedidoDetalle.getCantidad()) >= 0)
                    Toast.makeText(ctx,ctx.getString(R.string.surtido_error_rechazo_terminado), Toast.LENGTH_SHORT).show();
                else
                    showOptionsDialog(position,textRechazo);
            }
        });

        opc2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                reiniciarSurtido(position,textRechazo,textLeidos);
            }
        });

        container.addView(item_view);

        pos = position;
       /* if(!tipoRechazo.equals("Ninguna")){
             int mover = position + 1;
            viewPager.setCurrentItem(mover);
        }*/

        return item_view;
    }

    @Override
    public void destroyItem(ViewGroup container, int position, Object object) {
        container.removeView((LinearLayout) object);
    }

    /*Metodos generales*/

    private void showOptionsDialog(final int realmPosition, final TextView rechazo){

        try {
            final RealmResults<ValorReferencia> tiposRechazo = realm.where(ValorReferencia.class).equalTo("tabla","Surtido").equalTo("campo", "TipoRechazo").findAll();

            final ArrayList<String> opciones = new ArrayList<>();

            for(ValorReferencia valorReferencia : tiposRechazo)
                opciones.add(valorReferencia.getDescripcion());

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(ctx);
            LayoutInflater inflater = (LayoutInflater) ctx.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            View convertView = inflater.inflate(R.layout.dialog_list, null);
            alertDialog.setView(convertView);
            alertDialog.setTitle(ctx.getString(R.string.dialog_list_title));
            ListView opcionesList = (ListView) convertView.findViewById(R.id.optionsList);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(ctx,android.R.layout.simple_list_item_1,opciones);
            opcionesList.setAdapter(adapter);
            final AlertDialog dialog = alertDialog.create();

            opcionesList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                    try{
                        realm.beginTransaction();
                        PedidoDetalle pedidoDetalle = datos.get(realmPosition);
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

                        rechazo.setText(tiposRechazo(pedidoDetalle));

                        aumentarTransitoArray.put(pedidoJson);

                        actualizaDetalle(aumentarTransitoArray.toString(),false, "1");
                        dialog.dismiss();

                        viewPager.setCurrentItem(realmPosition + 1);
                    } catch (Exception e) {
                        //Log.e(TAG,e.getMessage(),e);
                    }

                }
            });

            dialog.show();
        } catch (Exception e) {
            //Log.e(TAG,e.getMessage(),e);
        }

    }

    private void actualizaDetalle(final String actualizar,final boolean esDeposito, final String rechazoRF){

        new Conexion(ctx, new AsyncTaskInterface() {
            boolean errorToken = false;
            boolean success = false;
            @Override
            public void before() {

            }

            @Override
            public String toDo() {
                try {



                    URL url = new URL(ValoresEstaticos.ACTUAL_SERVIDOR + "Surtido/"+(esDeposito?"depositar":"actualizaDetalle")+"?"
                            +ValoresEstaticos.PARAMETRO_ALMACEN+"="+ MetodosEstaticos.obtenerAlmacenClave(ctx)+
                            "&SUCClave="+MetodosEstaticos.obtenerSucursalClave(ctx)+
                            "&COMClave="+MetodosEstaticos.obtenerCompaniaClave(ctx)+
                            "&RechazoRF="+rechazoRF);

                    URLConnection urlConnection = url.openConnection();
                    String result = null;

                    HttpURLConnection httpUrlConn = (HttpURLConnection) urlConnection;
                    httpUrlConn.setRequestProperty("Authorization", MetodosEstaticos.obtenerToken(ctx));
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

                    //Log.i(TAG, httpUrlConn.getURL().toString());
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
                   // String error = R.string.error_servidor_lbl;
                    return ctx.getString(R.string.error_servidor_lbl);
                } catch (Exception e) {
                    //Log.e(TAG,e.getMessage(),e);
                    return null;
                }
            }

            @Override
            public void after(String result) {

                if(errorToken){
                    Toast.makeText(ctx,ctx.getString(R.string.token_error_lbl),Toast.LENGTH_SHORT).show();
                    MetodosEstaticos.limpiarSesion(ctx);
                } else {

                    if(result != null){
                        try{

                            if(success) {
                                if(esDeposito) {
                                    realm.beginTransaction();
                                    realm.where(PedidoDetalle.class).equalTo("DOCClave", DOCClave).equalTo("activo", false).findAll().deleteAllFromRealm();
                                    realm.commitTransaction();
                                    if (realm.where(PedidoDetalle.class).equalTo("DOCClave", DOCClave).count() <= 0) {
                                        //listener.onDocumentoTerminado();
                                    }
                                }
                            } else {
                                try {
                                    Toast.makeText(ctx, new JSONObject(result).getString("Message"), Toast.LENGTH_SHORT).show();
                                } catch (Exception ex){
                                    //Log.e(TAG,ex.getMessage(),ex);
                                }
                            }

                        } catch (Exception e){
                            //Log.e(TAG,e.getMessage(),e);
                        }
                    } else {
                        Toast.makeText(ctx,ctx.getString(R.string.error_lbl),Toast.LENGTH_SHORT).show();
                    }
                }
            }
        }).execute();
    }

    private void reiniciarSurtido(final int position, final TextView reiniciar, final TextView leidos){
        Dialogs.confirmDialog(ctx, ctx.getString(R.string.surtido_confirm_clean),
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        try {
                            realm.beginTransaction();
                            PedidoDetalle pedidoDetalle = datos.get(position);
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

                            reiniciar.setText(tiposRechazo(pedidoDetalle));
                            leidos.setText("0.0");
                            aumentarTransitoArray.put(pedidoJson);

                            actualizaDetalle(aumentarTransitoArray.toString(), false, "0");

                } catch (Exception e) {
            //Log.e(TAG,e.getMessage(),e);
        }
    }
},
        new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                    }
                });
    }

    private String tiposRechazo(PedidoDetalle pedidoDetalle){

        String tipoRechazo = pedidoDetalle.getTiporechazo()!=null?
                realm.where(ValorReferencia.class).equalTo("tabla","Surtido").equalTo("campo", "TipoRechazo").equalTo("valor",pedidoDetalle.getTiporechazo()).findFirst().getDescripcion()
                :"";

        return tipoRechazo;
    }
}
