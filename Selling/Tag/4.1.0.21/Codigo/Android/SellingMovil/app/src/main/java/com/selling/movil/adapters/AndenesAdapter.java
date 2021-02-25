package com.selling.movil.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.modelos.Anden;

import java.util.ArrayList;


/**
 * Created by Eduardo on 13/11/15.
 */
public class AndenesAdapter extends ArrayAdapter<Anden> {

    Context context;
    int layoutResourceId;
    ArrayList<Anden> data;
    AndenHolder holder;


    public AndenesAdapter(Context context, int layoutResourceId, ArrayList<Anden> data) {
        super(context, layoutResourceId, data);
        this.layoutResourceId = layoutResourceId;
        this.context = context;
        this.data = data;
    }

    @Override
    public int getCount() {

        return data!=null?data.size():0;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View row = convertView;
        holder = null;

        if(row == null)
        {
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            row = inflater.inflate(layoutResourceId, parent, false);

            holder = new AndenHolder();


            row.setTag(holder);
        }
        else
        {
            holder = (AndenHolder)row.getTag();
        }

        holder.folio = (TextView) row.findViewById(R.id.folio);
        holder.anden = (TextView) row.findViewById(R.id.anden);
        holder.porcentajeRecibo = (TextView) row.findViewById(R.id.porcentajeRecibo);
        holder.numPiezas = (TextView) row.findViewById(R.id.numPiezas);

        holder.folio.setText(data.get(position).getFolio());
        holder.anden.setText(data.get(position).getAnden());
        holder.porcentajeRecibo.setText(String.format("%.2f", Double.parseDouble(data.get(position).getPorcentajeRecibo())));
        holder.numPiezas.setText(data.get(position).getNumPiezas());

        return row;
    }


    static class AndenHolder
    {

        TextView folio;
        TextView anden;
        TextView porcentajeRecibo;
        TextView numPiezas;
    }
}

