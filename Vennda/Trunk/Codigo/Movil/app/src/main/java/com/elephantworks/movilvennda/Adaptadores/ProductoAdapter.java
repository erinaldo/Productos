package com.elephantworks.movilvennda.Adaptadores;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.elephantworks.movilvennda.Aplicacion;
import com.elephantworks.movilvennda.Modelos.Clientes;
import com.elephantworks.movilvennda.Modelos.Inventario;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.R;
import com.elephantworks.movilvennda.Utilerias.MetodosEstaticos;
import com.elephantworks.movilvennda.Utilerias.Session;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.InputStream;

import io.realm.Realm;
import io.realm.RealmQuery;
import io.realm.RealmResults;

/**
 * Created by ldelatorre on 02/07/2017.
 */
public class ProductoAdapter extends ArrayAdapter<Productos> {
    private Realm realm;
    private Session session;

    public ProductoAdapter(Context context, RealmResults<Productos> objects) {
        super(context, 0, objects);
        realm = ((Aplicacion) context.getApplicationContext()).getRealmInstance();
        session = new Session(context);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Obtener inflater.
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        // ¿Existe el view actual?
        if (null == convertView) {
            convertView = inflater.inflate(
                    R.layout.row_productos,
                    parent,
                    false);
        }

        TextView txtProducto = (TextView) convertView.findViewById(R.id.txtProducto);
        TextView txtPrecio = (TextView) convertView.findViewById(R.id.txtPrecio);
        TextView txtCantidaPro = (TextView) convertView.findViewById(R.id.txtCantidadProducto);
        ImageView imageView = (ImageView) convertView.findViewById(R.id.ivImagenProducto);

        // Lead actual.
        Productos producto = getItem(position);
        RealmQuery<Inventario> query = realm.where(Inventario.class);
        Inventario inventario = query.equalTo("productos.idProducto", producto.getIdProducto()).findFirst();

        //*****CODIGO PARA CARGAR IMAGENES_INICIO******//
        //Variable para traer la imagen por nombre
        String imgBuscar = producto.getImagen();
        if(imgBuscar != null) {
            if(!imgBuscar.equals("")) {
                //Buscar imagen entre las almacenadas y mostrar en ImageView
                File file = new File(getContext().getFilesDir(), imgBuscar);
                if (file.exists()) {
                    InputStream in = null;
                    try {
                        in = new BufferedInputStream(new FileInputStream(file));
                        Drawable d = Drawable.createFromStream(in, null);
                        imageView.setImageDrawable(d);
                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    }
                } else {
                    imageView.setImageResource(R.drawable.default_producto);
                }
            }else {
                imageView.setImageResource(R.drawable.default_producto);
            }
        }else{
            imageView.setImageResource(R.drawable.default_producto);
        }
        //*****CODIGO PARA CARGAR IMAGENES_FIN******//

        Clientes cliente = MetodosEstaticos.getClienteSesion(getContext(), session.getIdClienteVentas());


        // Setup.
        //asignamos el precio de la lista que tiene configurado el cliente
        double precio = MetodosEstaticos.getListaPrecio(producto,cliente.getListaPrecios());
        txtProducto.setText(producto.getNombre());
        txtPrecio.setText(convertView.getResources().getString(R.string.txtTituloPrecio)+" $ "+MetodosEstaticos.getFormatoDecimal(precio,"###0.00"));
        txtCantidaPro.setText(convertView.getResources().getString(R.string.txtTituloExistencia)+" "+ MetodosEstaticos.getFormatoDecimal(inventario.getCantidad(),"###0.00"));
        return convertView;
    }

}
