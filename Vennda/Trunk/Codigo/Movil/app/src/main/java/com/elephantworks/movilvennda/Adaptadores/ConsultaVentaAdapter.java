package com.elephantworks.movilvennda.Adaptadores;

import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.CarritoVentas;
import com.elephantworks.movilvennda.Modelos.Venta;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

import io.realm.Realm;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 16/07/2017.
 */
public class ConsultaVentaAdapter extends ArrayAdapter<Venta> {

    private Realm realm;

    public ConsultaVentaAdapter(Context context, RealmResults<Venta> objects) {
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
        Venta venta = getItem(position);

        if (venta.getTipo() == Constantes.TipoVenta.CREDITO) {
            convertView.setBackgroundResource(R.color.colorRojoBajito);
        }else {
            convertView.setBackgroundColor(Color.WHITE);
        }

        // Setup.
        String clienteNombre = venta.getCliente().getClave()+ " - " + venta.getCliente().getRazonSocial();
        fecha.setText(MetodosEstaticos.getFechaStr(venta.getFechaCreacion()));
        cliente.setText(clienteNombre);
        tipo.setText(venta.getTipo() == Constantes.TipoVenta.CONTADO ? getContext().getResources().getString(R.string.txtContado) : getContext().getResources().getString(R.string.txtCredito));
        total.setText(MetodosEstaticos.getFormatoDecimal(venta.getTotal(),"###0.00"));
        saldo.setText(MetodosEstaticos.getFormatoDecimal(venta.getSaldo(),"###0.00"));

        return convertView;
    }
}

