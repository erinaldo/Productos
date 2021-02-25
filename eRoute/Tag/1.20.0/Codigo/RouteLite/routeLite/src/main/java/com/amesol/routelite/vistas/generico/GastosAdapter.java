package com.amesol.routelite.vistas.generico;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.datos.ItemEncuesta;
import com.amesol.routelite.vistas.SeleccionGastos.ListaGastos;
import com.amesol.routelite.vistas.ConsultaInventario;

import java.util.ArrayList;


/**
 * Created by ldelatorre on 01/06/2017.
 */
public class GastosAdapter extends BaseAdapter {

    Context context;
    protected ArrayList<ListaGastos> items;

    public GastosAdapter(Context context, ArrayList<ListaGastos> items) {
        this.context = context;
        this.items = items;
    }

    @Override
    public int getCount() {
        return items.size();
    }

    @Override
    public Object getItem(int position) {
        return items.get(position);
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View view = convertView;

        if (convertView == null)
        {

            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = inflater.inflate(R.layout.lista_gastos, null);
        }

        ListaGastos item = items.get(position);


        TextView fecha = (TextView) view.findViewById(R.id.lblFecha);
        fecha.setText(item.getFecha());

        TextView concepto = (TextView) view.findViewById(R.id.lblConcepto);
        concepto.setText(item.getConcepto());

        TextView total = (TextView) view.findViewById(R.id.lblTotal);
        total.setText(item.getTotal());

        // TODO Auto-generated method stub
        return view;
    }
}
