package com.elephantworks.movilvennda.Adaptadores;

import android.content.ClipData;
import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.TextView;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.CarritoVentas;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.Presentadora.PresentadorAperturaCierre;
import com.elephantworks.movilvennda.Presentadora.PresentadorListaVentas;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

import io.realm.OrderedRealmCollection;
import io.realm.Realm;
import io.realm.RealmBaseAdapter;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 10/07/2017.
 */
public class VentasAdapter extends RealmBaseAdapter<CarritoVentas> implements ListAdapter {

    private static class ViewHolder {
        TextView producto;
        TextView cantidad;
        TextView precio;
        TextView subtotal;
        TextView descuento;
        TextView impuesto;
        TextView total;
    }

    public VentasAdapter(Context context, OrderedRealmCollection<CarritoVentas> realmResults) {
        super(context, realmResults);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder viewHolder;
        if(convertView == null){
            convertView = LayoutInflater.from(parent.getContext())
                    .inflate(R.layout.row_ventas, parent, false);
            viewHolder = new ViewHolder();
            viewHolder.producto = (TextView) convertView.findViewById(R.id.txtProductoVenta);
            viewHolder.cantidad = (TextView) convertView.findViewById(R.id.txtCantidadVenta);
            viewHolder.precio = (TextView) convertView.findViewById(R.id.txtPrecioVenta);
            viewHolder.subtotal = (TextView) convertView.findViewById(R.id.txtSubtotalVenta);
            viewHolder.descuento = (TextView) convertView.findViewById(R.id.txtDescuentoVenta);
            viewHolder.impuesto = (TextView) convertView.findViewById(R.id.txtImpuesto);
            viewHolder.total = (TextView) convertView.findViewById(R.id.txtTotalVenta);
            convertView.setTag(viewHolder);
        } else {
            viewHolder = (ViewHolder) convertView.getTag();
        }

        if(adapterData != null){
            final CarritoVentas carritoVentas = adapterData.get(position);
            String productoNombre = carritoVentas.getProducto().getClave() + " - " + carritoVentas.getProducto().getNombre();
            viewHolder.producto.setText(productoNombre);
            viewHolder.cantidad.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getCantidad(),"###0.00"));
            viewHolder.precio.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getPrecio(),"###0.00"));
            viewHolder.subtotal.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getSubtotal(),"###0.00"));
            if(carritoVentas.getDescuento() > 0.0){
                viewHolder.descuento.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getDescuentoVendedor(),"###0.00") + " %");
            }
            viewHolder.impuesto.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getImpuestos(),"###0.00"));
            viewHolder.total.setText(MetodosEstaticos.getFormatoDecimal(carritoVentas.getTotal(),"###0.00"));
        }

        return convertView;
    }
}
