package com.elephantworks.movilvennda.Adaptadores;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.R;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 14/07/2017.
 */
public class CambiarClienteAdapter extends ArrayAdapter<Clientes> {

    private Realm realm;

    public CambiarClienteAdapter(Context context, RealmResults<Clientes> objects) {
        super(context, 0, objects);
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Obtener inflater.
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        // ¿Existe el view actual?
        if (null == convertView) {
            convertView = inflater.inflate(
                    R.layout.row_cliente_cambio,
                    parent,
                    false);
        }

        TextView txtCliente = (TextView) convertView.findViewById(R.id.txtCliente);

        // Lead actual.
        Clientes cliente = getItem(position);

        // Setup.
        txtCliente.setText(cliente.getRazonSocial());

        return convertView;
    }
}
