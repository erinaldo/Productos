package com.selling.movil.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.TextView;
import android.widget.Toast;

import com.selling.movil.R;
import com.selling.movil.modelos.Anden;
import com.selling.movil.modelos.AreaTrabajo;

import java.util.ArrayList;


/**
 * Created by Eduardo on 13/11/15.
 */
public class AreasAdapter extends ArrayAdapter<AreaTrabajo> {

    Context context;
    int layoutResourceId;
    ArrayList<AreaTrabajo> data;
    AreaHolder holder;


    public AreasAdapter(Context context, int layoutResourceId, ArrayList<AreaTrabajo> data) {
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
    public View getView(final int position, final View convertView, ViewGroup parent) {
        View row = convertView;
        holder = null;

        if(row == null)
        {
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            row = inflater.inflate(layoutResourceId, parent, false);

            holder = new AreaHolder();


            row.setTag(holder);
        }
        else
        {
            holder = (AreaHolder)row.getTag();
        }

        holder.asignado = (CheckBox) row.findViewById(R.id.asignado_cb);
        holder.area = (TextView) row.findViewById(R.id.area_tv);


        holder.asignado.setChecked(data.get(position).isSeleccionado());
        holder.area.setText(data.get(position).getClave());

        holder.asignado.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if(data.get(position).isAsignado()) {
                    data.get(position).setSeleccionado(data.get(position).isAsignado());
                    notifyDataSetChanged();
                    Toast.makeText(context,context.getString(R.string.surtido_area_asignada_lbl),Toast.LENGTH_SHORT).show();
                } else
                    data.get(position).setSeleccionado(isChecked);
            }
        });

        return row;
    }


    static class AreaHolder
    {

        CheckBox asignado;
        TextView area;

    }
}

