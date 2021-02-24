package com.elephantworks.movilvennda.Adaptadores;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.elephantworks.movilvennda.Presentadora.PresentadorAperturaCierre;
import com.elephantworks.movilvennda.R;

import java.util.List;

/**
 * Created by ldelatorre on 17/06/2017.
 */
public class DineroAdapter extends ArrayAdapter<PresentadorAperturaCierre.Dinero> {

    public DineroAdapter(Context context, List<PresentadorAperturaCierre.Dinero> objects) {
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
                    R.layout.row_dinero,
                    parent,
                    false);
        }

        TextView dominacion = (TextView) convertView.findViewById(R.id.txtDenominacion);
        TextView cantidad = (TextView) convertView.findViewById(R.id.txtCantidad);
        TextView importe = (TextView) convertView.findViewById(R.id.txtImporte);

        // Lead actual.
        PresentadorAperturaCierre.Dinero dinero = getItem(position);

        // Setup.
        dominacion.setText(dinero.getDenominacion());
        cantidad.setText(dinero.getCantidad());
        importe.setText(dinero.getImporte());

        return convertView;
    }
}
