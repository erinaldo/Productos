package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Productos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;

public class BusquedaProductosAdapter extends ArrayAdapter<Productos.vistaProductos> {

	int textViewResourceId; 
	Context context;
	
	public BusquedaProductosAdapter(Context context, int textViewResourceId,
			Productos.vistaProductos[] objects) {		
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
	}
	
	@Override
    public View getView(int position, View convertView, ViewGroup parent) {		
		View fila = convertView;
		
		CheckBox checkBox ;
		TextView txtUnidad ;
		TextView txtClave ;
		TextView txtDescripcion ;
		TextView txtExistencia ;
		TextView txtPrecio ;
		
		if(convertView == null){
			LayoutInflater inflater = ((Activity)context).getLayoutInflater();
			fila = 	inflater.inflate(textViewResourceId, null);
			
			checkBox = (CheckBox) fila.findViewById(R.id.CheckBox);
			txtUnidad = (TextView) fila.findViewById(R.id.txtUnidad);
			txtClave = (TextView) fila.findViewById(R.id.txtClave);
			txtDescripcion = (TextView) fila.findViewById(R.id.txtDescripcion);
			txtExistencia = (TextView) fila.findViewById(R.id.txtExistencia);
			txtPrecio = (TextView) fila.findViewById(R.id.txtPrecio);
			
			fila.setTag(new Productos.vistaProductos.ProductoViewHolder(checkBox, txtUnidad, txtClave, txtDescripcion, txtExistencia, txtPrecio));
			
			new Productos.vistaProductos.ProductoViewHolder(checkBox, txtUnidad, txtClave, txtDescripcion, txtExistencia, txtPrecio);
			
			checkBox.setOnClickListener( new View.OnClickListener() {
		          public void onClick(View v) {
		            CheckBox cb = (CheckBox) v ;
		            Productos.vistaProductos producto = (Productos.vistaProductos) cb.getTag();
		            producto.setChecked( cb.isChecked() );
		          }
		        });
		}else{
			Productos.vistaProductos.ProductoViewHolder viewHolder = (Productos.vistaProductos.ProductoViewHolder) convertView.getTag();
			checkBox = viewHolder.getCheckBox();
			txtUnidad = viewHolder.gettxtUnidad();
			txtClave = viewHolder.gettxtClave();
			txtDescripcion = viewHolder.gettxtDescripcion();
			txtExistencia = viewHolder.gettxtExistencia();
			txtPrecio = viewHolder.gettxtPrecio();
		}
		Productos.vistaProductos producto = (Productos.vistaProductos) getItem(position);
		checkBox.setTag(producto);
		checkBox.setChecked(producto.isChecked());
		txtUnidad.setText(producto.getUnidad());
		if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
			txtExistencia.setVisibility(View.GONE);
		
		txtClave.setText(producto.getProductoClave());
		txtDescripcion.setText(producto.getNombreLargo()); //cambiar por nombre si no se ve bien
		txtExistencia.setText(String.format("%." + String.valueOf(producto.getDecimalProducto()) + "f",producto.getExistencia()));
		txtPrecio.setText(String.format("$ %.2f",producto.getPrecio()));
		
		return fila;
	}
}
