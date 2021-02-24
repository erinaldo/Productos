package com.duxstar.dacza.vistas.generico;

import android.app.Activity;
import android.app.SearchManager;
import android.content.Context;
import android.database.Cursor;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.vistas.CapturaRecarga;

/**
 * Created by Adriana on 19/05/2016.
 */


public class RECDetalleAdapter extends ArrayAdapter<RECDetalle>
{
    int textViewResourceId;
    Context context;
    RECDetalle objetos[];
    boolean soloLectura;

    public RECDetalleAdapter(Context context, int textViewResourceId,
                          RECDetalle[] objects)
    {
        super(context, textViewResourceId, objects);
        this.textViewResourceId = textViewResourceId;
        this.context = context;
        objetos = objects;
    }

    public void setSoloLectura(boolean bSoloLectura){ soloLectura = bSoloLectura; }


    @Override
    public int getViewTypeCount()
    {
        return objetos.length;
    }

    @Override
    public int getItemViewType(int position)
    {
        return position;
    }

    @SuppressWarnings("deprecation")
    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        View fila = convertView;
        Holder holder = null;
        if (convertView == null) {
            LayoutInflater inflater = ((Activity) context).getLayoutInflater();
            fila = inflater.inflate(textViewResourceId, null);
            fila.setOnClickListener(new View.OnClickListener() {

                public void onClick(View v) {
                    if (!soloLectura) {
                        if (((Holder)v.getTag()).Clave.getTag().toString() != "")
                            ((CapturaRecarga)context).modificarProducto(((Holder)v.getTag()).Clave.getTag().toString(), (Float)((Holder)v.getTag()).Cantidad.getTag(), false);
                        else
                            ((CapturaRecarga)context).modificarProducto(((Holder)v.getTag()).Descripcion.getTag().toString(), (Float)((Holder)v.getTag()).Cantidad.getTag(), true);
                        Log.d("Item", "Click");
                        return;
                    }
                    return;
                }

            });


            holder = new Holder();
            holder.Clave = (TextView) fila.findViewById(R.id.lblClave);
            holder.Descripcion = (TextView) fila.findViewById(R.id.lblDescripcion);
            holder.Cantidad = (TextView) fila.findViewById(R.id.lblCantidad);
            holder.Imagen = (ImageButton) fila.findViewById(R.id.btnCamera);


            //asignar el listener solo si no es solo lectura
            if (!soloLectura) {
                fila.setOnLongClickListener(new View.OnLongClickListener() {

                    @Override
                    public boolean onLongClick(View v) {
                        Log.d("Item", "LongClick");
                        return false;
                    }
                });
            }

            fila.setTag(holder);
        } else {
            holder = (Holder) fila.getTag();
        }

        RECDetalle detalle = getItem(position);

        if (detalle.articulo != null) {
            holder.Clave.setText(detalle.articulo.Clave + " - ");
            holder.Clave.setTag(detalle.articulo.Clave);
            holder.Descripcion.setText(detalle.articulo.Descripcion);
            holder.Imagen.setVisibility(View.GONE);
        }
        else{
            holder.Clave.setText("NA - ");
            holder.Clave.setTag("");
            holder.Descripcion.setText(detalle.ArticuloDesc);
            holder.Descripcion.setTag(detalle.ArticuloDesc);
            if (detalle.Imagen != null) {
                if (detalle.Imagen.equals(""))
                    holder.Imagen.setVisibility(View.GONE);
            }else
                holder.Imagen.setVisibility(View.GONE);
        }
        holder.Cantidad.setText(Generales.getFormatoDecimal(detalle.Cantidad, 2));
        holder.Cantidad.setTag(detalle.Cantidad);

        return fila;
    }

    static class Holder
    {
        TextView Clave;
        TextView Descripcion;
        TextView Cantidad;
        ImageButton Imagen;
    }

}


