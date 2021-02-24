package com.elephantworks.movilvennda.Adaptadores;

import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.Devolucion;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

import io.realm.Realm;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 09/06/2019.
 */
public class ConsultaDevolucionAdapter extends ArrayAdapter<Devolucion> {

    private Realm realm;

    public ConsultaDevolucionAdapter(Context context, RealmResults<Devolucion> objects) {
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
                    R.layout.row_consultar_ventas,
                    parent,
                    false);
        }

        TextView fecha = (TextView) convertView.findViewById(R.id.txtFechaConsultaVenta);
        TextView cliente = (TextView) convertView.findViewById(R.id.txtClienteConsultaVenta);
        TextView tipo = (TextView) convertView.findViewById(R.id.txtTipoConsultaVenta);
        TextView total = (TextView) convertView.findViewById(R.id.txtTotalConsultaVenta);
        TextView saldo = (TextView) convertView.findViewById(R.id.txtSaldoConsultaVenta);


        // Lead actual.
        Devolucion devolucion = getItem(position);

        // Setup.
        String clienteNombre = devolucion.getCliente().getClave()+ " - " + devolucion.getCliente().getRazonSocial();
        fecha.setText(MetodosEstaticos.getFechaStr(devolucion.getFechaCreacion()));
        cliente.setText(clienteNombre);
        tipo.setText("");
        total.setText(MetodosEstaticos.getFormatoDecimal(devolucion.getTotal(),"###0.00"));
        saldo.setText(MetodosEstaticos.getFormatoDecimal(devolucion.getSaldo(),"###0.00"));

        return convertView;
    }

}
