package com.elephantworks.movilvennda.Adaptadores;

import android.content.Context;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.support.annotation.StringDef;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.TextView;

import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.VentaDetalle;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.Constantes;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

import java.util.LinkedHashMap;
import java.util.Map;

import io.realm.RealmResults;

/**
 * Created by elephantworkss.adec.v on 09/12/17.
 */

public class DevolucionProductosAdapter extends ArrayAdapter<VentaDetalle> {

    private Map<Integer, Double> mapDevoluciones = new LinkedHashMap<Integer, Double>();

    public DevolucionProductosAdapter(Context context, RealmResults<VentaDetalle> objects) {
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
                    R.layout.row_devolucion_producto,
                    parent,
                    false);
            mapDevoluciones.clear();
        }

        TextView producto = (TextView) convertView.findViewById(R.id.txtProductoDev);
        TextView ventas = (TextView) convertView.findViewById(R.id.txtVentaDev);
        TextView devoluciones = (TextView) convertView.findViewById(R.id.txtDevueltosDev);
        final EditText editText = (EditText) convertView.findViewById(R.id.etCantidadDevuelta);

        // Lead actual.
        VentaDetalle ventaDetalle = getItem(position);

        // Setup.
        String productoStr = ventaDetalle.getProducto().getClave() + " - " + ventaDetalle.getProducto().getNombre();
        producto.setText(productoStr);
        ventas.setText(String.valueOf(ventaDetalle.getCantidadProducto()));
        String devuelta = "0.0";
        if(ventaDetalle.getCantidadDevuelta() != null){
            devuelta = String.valueOf(ventaDetalle.getCantidadDevuelta());
        }
        devoluciones.setText(devuelta);

        final int posicion = position;

        editText.setTag(posicion);

       editText.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                double devolucion = 0.0;

                if(!charSequence.toString().equals("")){
                    devolucion = Double.parseDouble(charSequence.toString());
                }

                if(((int) editText.getTag()) == posicion) {
                    mapDevoluciones.put(posicion, devolucion);
                }
            }

            @Override
            public void afterTextChanged(Editable editable) {


            }
        });





        return convertView;
    }

    public Map<Integer, Double> obtenerDevolucionesLista(){
        return mapDevoluciones;
    }
}
