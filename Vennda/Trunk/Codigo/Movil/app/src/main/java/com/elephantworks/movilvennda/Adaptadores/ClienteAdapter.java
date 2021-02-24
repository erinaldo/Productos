package com.elephantworks.movilvennda.Adaptadores;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Presentadora.PresentadorAperturaCierre;
import com.elephantworks.movilvennda.Presentadora.PresentadorCliente;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;

import java.util.ArrayList;

import io.realm.RealmResults;

/**
 * Created by ldelatorre on 23/06/2017.
 */
public class ClienteAdapter extends ArrayAdapter<Clientes> {

    public ClienteAdapter(Context context, RealmResults<Clientes> objects) {
        super(context, 0, objects);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Obtener inflater.
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        // ¿Existe el view actual?
        if (null == convertView) {
            convertView = inflater.inflate(
                    R.layout.row_cliente,
                    parent,
                    false);
        }

        TextView nombre = (TextView) convertView.findViewById(R.id.txtNombreCliente);
        TextView alta = (TextView) convertView.findViewById(R.id.txtAltaCliente);

        // Lead actual.
        Clientes cliente = getItem(position);

        // Setup.
        nombre.setText(cliente.getRazonSocial());
        try {
            if (cliente.getAlta() != 0) {
                //alta.setText(Integer.toString(cliente.getAlta()));
                if(cliente.getAlta() == Constantes.TipoCliente.WEB){
                    alta.setText(Constantes.TipoCliente.STRWEB);
                }else if(cliente.getAlta() == Constantes.TipoCliente.MOVIL){
                    alta.setText(Constantes.TipoCliente.STRMOVIL);
                }
            } else {
                alta.setText("Sin registro");
            }
        }catch (Exception ex){

        }




        return convertView;
    }
}
