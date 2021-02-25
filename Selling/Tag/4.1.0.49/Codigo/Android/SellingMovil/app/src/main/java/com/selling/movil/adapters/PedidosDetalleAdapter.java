package com.selling.movil.adapters;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListAdapter;
import android.widget.TextView;

import com.selling.movil.Aplicacion;
import com.selling.movil.R;
import com.selling.movil.modelos.Pedido;
import com.selling.movil.modelos.PedidoDetalle;
import com.selling.movil.modelos.ValorReferencia;

import io.realm.Realm;
import io.realm.RealmBaseAdapter;
import io.realm.RealmResults;


/**
 * Created by Eduardo on 13/11/15.
 */
public class PedidosDetalleAdapter extends RealmBaseAdapter<PedidoDetalle> implements ListAdapter {

    private Context context;
    private int layoutResourceId;
    private PedidoHolder holder;
    private Realm realm;


    public PedidosDetalleAdapter(Context context, RealmResults<PedidoDetalle> results, int layoutResourceId) {
        super(context, results);
        this.layoutResourceId = layoutResourceId;
        this.context = context;
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
    }



    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View row = convertView;
        holder = null;

        if(row == null)
        {
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            row = inflater.inflate(layoutResourceId, parent, false);

            holder = new PedidoHolder();


            row.setTag(holder);
        }
        else
        {
            holder = (PedidoHolder)row.getTag();
        }

        holder.producto = (TextView) row.findViewById(R.id.producto);
        holder.ubicacion = (TextView) row.findViewById(R.id.ubicacion);
        holder.cantidad = (TextView) row.findViewById(R.id.cantidad);
        holder.surtido = (TextView) row.findViewById(R.id.surtidos);
        holder.motivoRechazo = (TextView) row.findViewById(R.id.motRechazo);

        PedidoDetalle item = adapterData.get(position);
        String tipoRechazo = item.getTiporechazo()!=null?
                realm.where(ValorReferencia.class).equalTo("tabla","Surtido").equalTo("campo", "TipoRechazo").equalTo("valor",item.getTiporechazo()).findFirst().getDescripcion()
                :"";

        holder.producto.setText(item.getProducto());
        holder.ubicacion.setText(item.getUbicacion());
        holder.cantidad.setText(Double.toString(item.getCantidad()));
        holder.surtido.setText(item.getTransito()!= null?Double.toString(item.getTransito()):"0");
        holder.motivoRechazo.setText(tipoRechazo);

        return row;
    }


    static class PedidoHolder
    {
        TextView producto;
        TextView ubicacion;
        TextView cantidad;
        TextView surtido;
        TextView motivoRechazo;
    }
}

