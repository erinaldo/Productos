package com.amesol.pruebaandroid.ele;



import com.amesol.pruebaandroid.R;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class MenuListAdapter extends ArrayAdapter<ItemMenu>  {

	//private ItemMenu[] elementos;
	
	public MenuListAdapter(Context context, int textViewResourceId,	ItemMenu[] elementos) {
		super(context, textViewResourceId, elementos);
		//this.elementos = elementos;
		
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		View v = convertView;
		if (v == null) {
			LayoutInflater vi = (LayoutInflater) this.getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			v = vi.inflate(R.layout.elemento_menu, null);
		}
		ItemMenu o = this.getItem(position);
		if (o != null) { 
			//poblamos la lista de elementos 
			TextView tt = (TextView) v.findViewById(R.id.elem_texto);
			ImageView im = (ImageView) v.findViewById(R.id.elem_icono); 
			if (im!= null) {im.setImageResource(o.getImagen());}
			if (tt != null) {tt.setText(o.getDescripcion());}
		}

		return v;
	}


}
