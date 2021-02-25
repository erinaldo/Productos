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
import com.selling.movil.modelos.Reubicacion;
import com.selling.movil.utilerias.MetodosEstaticos;
import com.selling.movil.utilerias.ValoresEstaticos;

import java.util.ArrayList;

/**
 * Created by aperez on 27/06/2019.
 */
public class ReubicacionAdapter extends ArrayAdapter<Reubicacion> {

    Context context;
    int layoutResourceId;
    ArrayList<Reubicacion> data;
    ReubicacionHolder holder;


    public ReubicacionAdapter(Context context, int layoutResourceId, ArrayList<Reubicacion> data) {
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

            holder = new ReubicacionHolder();


            row.setTag(holder);
        }
        else
        {
            holder = (ReubicacionHolder) row.getTag();
        }

        holder.seleccionado = (CheckBox) row.findViewById(R.id.seleccionado_cb);
        holder.codigo = (TextView) row.findViewById(R.id.claveProducto);
        holder.cantidad = (TextView) row.findViewById(R.id.cantidadPro);
        holder.ubicacion = (TextView)row.findViewById(R.id.ubicacionNueva);

        holder.seleccionado.setChecked(data.get(position).isSeleccionado());
        holder.codigo.setText(data.get(position).getCodigo());
        holder.cantidad.setText(data.get(position).getCantidad());
        holder.ubicacion.setText(data.get(position).getUbicacion());

        //if(data.get(position).getActivity() != ValoresEstaticos.ACTIVITY_DEFECTO)
        holder.codigo.setVisibility(View.INVISIBLE);
        holder.seleccionado.setVisibility((MetodosEstaticos.obtenerConteoNormal(context) ? View.VISIBLE : View.INVISIBLE));
        holder.seleccionado.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                data.get(position).setSeleccionado(isChecked);
                /*if(data.get(position).isSeleccionado()) {
                    data.get(position).setSeleccionado(data.get(position).isSeleccionado());
                    notifyDataSetChanged();
                    //Toast.makeText(context,context.getString(R.string.surtido_area_asignada_lbl),Toast.LENGTH_SHORT).show();
                } else
                    data.get(position).setSeleccionado(isChecked);*/
            }
        });

        return row;
    }

    static class ReubicacionHolder
    {
        CheckBox seleccionado;
        TextView codigo;
        TextView cantidad;
        TextView ubicacion;
    }
}
