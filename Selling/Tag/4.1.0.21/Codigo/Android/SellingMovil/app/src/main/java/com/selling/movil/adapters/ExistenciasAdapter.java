package com.selling.movil.adapters;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

import com.selling.movil.R;
import com.selling.movil.modelos.Existencia;

import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;


/**
 * Created by Eduardo on 13/11/15.
 */
public class ExistenciasAdapter extends ArrayAdapter<Existencia> {

    Context context;
    int layoutResourceId;
    ArrayList<Existencia> data;
    ExistenciaHolder holder;


    public ExistenciasAdapter(Context context, int layoutResourceId, ArrayList<Existencia> data) {
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

            holder = new ExistenciaHolder();


            row.setTag(holder);
        }
        else
        {
            holder = (ExistenciaHolder)row.getTag();
        }

        holder.clave = (TextView) row.findViewById(R.id.clave);
        holder.existencia = (TextView) row.findViewById(R.id.existencia);
        holder.apartado = (TextView) row.findViewById(R.id.apartado);
        holder.bloqueado = (TextView) row.findViewById(R.id.bloqueado);

        holder.clave.setText(StringUtils.rightPad(data.get(position).getClave(), 13, " "));
        holder.existencia.setText(StringUtils.leftPad(data.get(position).getExistencia(), 7, " "));
        holder.apartado.setText(StringUtils.leftPad(data.get(position).getApartado(), 5, " "));
        holder.bloqueado.setText(StringUtils.leftPad(data.get(position).getBloqueado(), 5, " "));

        return row;
    }


    static class ExistenciaHolder
    {

        TextView clave;
        TextView existencia;
        TextView apartado;
        TextView bloqueado;
    }
}

