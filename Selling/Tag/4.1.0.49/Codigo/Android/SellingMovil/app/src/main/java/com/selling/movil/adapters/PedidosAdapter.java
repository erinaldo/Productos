package com.selling.movil.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.modelos.Anden;
import com.selling.movil.modelos.Pedido;
import com.selling.movil.utilerias.MetodosEstaticos;

import java.util.ArrayList;

import io.realm.RealmBaseAdapter;
import io.realm.RealmResults;


/**
 * Created by Eduardo on 13/11/15.
 */
public class PedidosAdapter extends RealmBaseAdapter<Pedido> implements ListAdapter {

    Context context;
    int layoutResourceId;
    PedidoHolder holder;


    public PedidosAdapter(Context context, RealmResults<Pedido> results,int layoutResourceId) {
        super(context, results);
        this.layoutResourceId = layoutResourceId;
        this.context = context;
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

        holder.prioridad = (TextView) row.findViewById(R.id.prioridad);
        holder.folio = (TextView) row.findViewById(R.id.folio);
        holder.cliente = (TextView) row.findViewById(R.id.cliente);
        holder.stage = (TextView) row.findViewById(R.id.stage);
        holder.estado = (TextView) row.findViewById(R.id.estado);

        Pedido item = adapterData.get(position);
        holder.prioridad.setText(Integer.toString(item.getPrioridad()));
        holder.folio.setText(item.getFolio()!=null?item.getFolio():"");
        holder.cliente.setText(item.getCliente());
        holder.stage.setText(item.getStage());
        String estado = MetodosEstaticos.obtenerEstadoSurtido(context,item.getEstado()!=null? Integer.parseInt(item.getEstado()):0);
        holder.estado.setText(estado);

        return row;
    }


    static class PedidoHolder
    {
        TextView prioridad;
        TextView folio;
        TextView cliente;
        TextView stage;
        TextView estado;
    }
}

