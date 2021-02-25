package com.amesol.routelite.vistas.generico;

import java.util.ArrayList;

import com.amesol.routelite.R;
import com.amesol.routelite.datos.ItemEncuesta;

import android.app.Activity;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class ItemEncuestaAdaptador extends BaseAdapter
{
	protected Activity activity;
	protected ArrayList<ItemEncuesta> items;

	public ItemEncuestaAdaptador(Activity activity, ArrayList<ItemEncuesta> items)
	{
		this.activity = activity;
		this.items = items;
	}

	@Override
	public int getCount()
	{
		// TODO Auto-generated method stub
		return items.size();
	}

	@Override
	public Object getItem(int position)
	{
		// TODO Auto-generated method stub
		return items.get(position);
	}

	@Override
	public long getItemId(int position)
	{
		// TODO Auto-generated method stub
	   return items.get(position).getId();
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		View view = convertView;

		if (convertView == null)
		{

			LayoutInflater inflater = (LayoutInflater) activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			view = inflater.inflate(R.layout.lista_encuestas, null);
		}

		ItemEncuesta item = items.get(position);

		ImageView image = (ImageView) view.findViewById(R.id.ivIconoEncuesta);
		Bitmap imag = BitmapFactory.decodeByteArray(item.getRutaImagen(), 0, item.getRutaImagen().length); //tomamos el valor de item (ItemEncuesta) y pasamos los parametros al metodo para que pueda transformarlo en bitmap
		image.setImageBitmap(imag);//añadimos img al lector imagBitmap del imageview

		TextView titulo = (TextView) view.findViewById(R.id.tvTitulo);
		titulo.setText(item.getTitulo());

		TextView estatus = (TextView) view.findViewById(R.id.tvEstatus);
		estatus.setText(item.getEstatus());

		TextView fecha = (TextView) view.findViewById(R.id.tvFecha);
		fecha.setText(item.getFecha());

		// TODO Auto-generated method stub
		return view;
	}

}
