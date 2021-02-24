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
import com.elephantworks.movilvennda.Modelos.Categorias;
import com.elephantworks.movilvennda.Modelos.Productos;
import com.elephantworks.movilvennda.R;

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
public class CategoriaAdapter extends ArrayAdapter<Categorias> {
    private Realm realm;

    public CategoriaAdapter(Context context, RealmResults<Categorias> objects) {
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
            R.layout.row_categorias,
            parent,
            false);
        }
        // Lead actual.
        Categorias categorias = getItem(position);
        TextView txtCategoria = (TextView) convertView.findViewById(R.id.txtCategoria);
        ImageView imageView = (ImageView) convertView.findViewById(R.id.ivImagenCategorias);
        //*****CODIGO PARA CARGAR IMAGENES_INICIO******//
        //Variable para traer la imagen por nombre
        String imgBuscar = categorias.getImagen();
        if(imgBuscar != null) {
            if(!imgBuscar.equals("")) {
                //Buscar imagen entre las almacenadas y mostrar en ImageView
                File f = new File(getContext().getFilesDir().getPath());
                File[] lista = f.listFiles();
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
            }else{
                imageView.setImageResource(R.drawable.default_producto);
            }
        }else{
            imageView.setImageResource(R.drawable.default_producto);
        }
        //*****CODIGO PARA CARGAR IMAGENES_FIN******//



        RealmQuery<Productos> query;
        if(categorias.getIdentificador().equals(convertView.getResources().getString(R.string.valorIdentificardorCategoria))){
           query = realm.where(Productos.class);
        }else{
            query = realm.where(Productos.class).equalTo("categorias.idCategoria", categorias.getIdCategoria());
        }

        RealmResults<Productos> productos = query.findAll();

        // Setup.
        txtCategoria.setText(categorias.getNombre() + " ("+productos.size()+")");

        return convertView;
    }
}
