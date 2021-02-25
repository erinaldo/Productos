package com.amesol.routelite.vistas.generico;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.vistas.DisConsultaInventarioMaterialesCliente;
import com.amesol.routelite.vistas.DisPortafolioRecomendado;

import java.util.ArrayList;

/**
 * Created by ldelatorre on 11/03/2018.
 */
public class DisPortafolioAdapter extends BaseAdapter {

    Context context;
    protected ArrayList<DisPortafolioRecomendado.ListaPortafolio> items;

    public DisPortafolioAdapter(Context context, ArrayList<DisPortafolioRecomendado.ListaPortafolio> items) {
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
            view = inflater.inflate(R.layout.lista_dis_datos, null);
        }

        DisPortafolioRecomendado.ListaPortafolio item = items.get(position);


        TextView col1 = (TextView) view.findViewById(R.id.txtCol1);
        col1.setText(item.getClave());

        TextView col2 = (TextView) view.findViewById(R.id.txtCol2);
        col2.setText(item.getCategoria());

        TextView col3 = (TextView) view.findViewById(R.id.txtCol3);
        col3.setText(item.getPesos());

        TextView col4 = (TextView) view.findViewById(R.id.txtCol4);
        col4.setText(item.getProm());

        TextView col5 = (TextView) view.findViewById(R.id.txtCol5);
        col5.setVisibility(View.GONE);


        // TODO Auto-generated method stub
        return view;
    }
}

