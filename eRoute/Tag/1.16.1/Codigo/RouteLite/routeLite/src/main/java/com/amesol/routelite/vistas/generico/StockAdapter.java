package com.amesol.routelite.vistas.generico;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.vistas.CapturaPedido;

import java.util.ArrayList;

/**
 * Created by aperez on 11/07/2018.
 */
public class StockAdapter extends BaseAdapter{
    Context context;
    protected ArrayList<CapturaPedido.ListaStock> items;

    public StockAdapter(Context context, ArrayList<CapturaPedido.ListaStock> items) {
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

        if (convertView == null) {
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = inflater.inflate(R.layout.lista_simple_hor6_wrap, null);
        }

        CapturaPedido.ListaStock item = items.get(position);


       TextView col1 = (TextView) view.findViewById(R.id.txtCol1);
        col1.setText(item.getClaveProducto());

        TextView col2 = (TextView) view.findViewById(R.id.txtCol2);
        col2.setText(item.getNombre());

       TextView col3 = (TextView) view.findViewById(R.id.txtCol3);
        col3.setText(item.getUnidad());

        TextView col4 = (TextView) view.findViewById(R.id.txtCol4);
        col4.setText(item.getCantidad());


        // TODO Auto-generated method stub
        return view;
    }
}
