package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.ModuloMovDetalle;

public class ModulosDetalleAdapter  extends ArrayAdapter<ModuloMovDetalle> {

	int textViewResourceId; 
	Context context;
	
	public ModulosDetalleAdapter(Context context, int textViewResourceId,
			ModuloMovDetalle[] objects) {		
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
	}
	
	@Override
	public View getView(int position, View convertView,ViewGroup parent){
		View fila = convertView;

		if(convertView == null){
			LayoutInflater inflater = ((Activity)context).getLayoutInflater();
			fila = 	inflater.inflate(textViewResourceId, null);
		}
		
		ModuloMovDetalle vr = getItem(position);
		TextView texto = (TextView) fila.findViewById(R.id.text1);		
		if(texto != null) texto.setText(vr.getNombre());
		
		ImageView imagen = (ImageView) fila.findViewById(R.id.icon);
		if(imagen != null){
			Integer intImagen = obtenerImagen(vr);
			if(intImagen != null) imagen.setImageResource(intImagen);
		}	
		return fila;
	}
	
	private Integer obtenerImagen(ModuloMovDetalle actividad){
		//TODO: Agregar aqui todos los iconos de las actividades
		if(String.valueOf(actividad.getTipoIndice()).equals("0")) return R.drawable.actrol1;
		else if(String.valueOf(actividad.getTipoIndice()).equals("1")) return R.drawable.actrol2;
		else if(String.valueOf(actividad.getTipoIndice()).equals("2")) return R.drawable.actrol3r;
		else if(String.valueOf(actividad.getTipoIndice()).equals("3")) return R.drawable.actrol4;
		else if(String.valueOf(actividad.getTipoIndice()).equals("4")) return R.drawable.actrol13;
		else if(String.valueOf(actividad.getTipoIndice()).equals("5")) return R.drawable.actrol13;
		else if(String.valueOf(actividad.getTipoIndice()).equals("6")) return R.drawable.actrol6;
		else if(String.valueOf(actividad.getTipoIndice()).equals("7")) return R.drawable.actrol7;
		else if(String.valueOf(actividad.getTipoIndice()).equals("8")) return R.drawable.actrol1;
		else if(String.valueOf(actividad.getTipoIndice()).equals("9")) return R.drawable.actrol2;
		else if(String.valueOf(actividad.getTipoIndice()).equals("10")) return R.drawable.actrol3sr;
		else if(String.valueOf(actividad.getTipoIndice()).equals("11")) return R.drawable.actrol4;
		else if(String.valueOf(actividad.getTipoIndice()).equals("12")) return R.drawable.actrol5;
		else if(String.valueOf(actividad.getTipoIndice()).equals("13")) return R.drawable.actrol13;
		else if(String.valueOf(actividad.getTipoIndice()).equals("14")) return R.drawable.actrol7;
		else if(String.valueOf(actividad.getTipoIndice()).equals("15")) return R.drawable.actrol1;
		else if(String.valueOf(actividad.getTipoIndice()).equals("16")) return R.drawable.actrol2;
		else if(String.valueOf(actividad.getTipoIndice()).equals("17")) return R.drawable.actrol3r;
		else if(String.valueOf(actividad.getTipoIndice()).equals("18")) return R.drawable.actrol4;
		else if(String.valueOf(actividad.getTipoIndice()).equals("19")) return R.drawable.actrol5;
		else if(String.valueOf(actividad.getTipoIndice()).equals("20")) return R.drawable.actrol6;
		else if(String.valueOf(actividad.getTipoIndice()).equals("21")) return R.drawable.actrol7;
		else if(String.valueOf(actividad.getTipoIndice()).equals("22")) return R.drawable.actrol1;
		else if(String.valueOf(actividad.getTipoIndice()).equals("23")) return R.drawable.actrol2;
		else if(String.valueOf(actividad.getTipoIndice()).equals("24")) return R.drawable.actrol3sr;
		else if(String.valueOf(actividad.getTipoIndice()).equals("25")) return R.drawable.actrol4;
		else if(String.valueOf(actividad.getTipoIndice()).equals("26")) return R.drawable.actrol5;
		else if(String.valueOf(actividad.getTipoIndice()).equals("27")) return R.drawable.actrol6;
		else if(String.valueOf(actividad.getTipoIndice()).equals("28")) return R.drawable.actrol7;
		else if(String.valueOf(actividad.getTipoIndice()).equals("29")) return R.drawable.actrol1;
		else if(String.valueOf(actividad.getTipoIndice()).equals("30")) return R.drawable.actrol2;
		else if(String.valueOf(actividad.getTipoIndice()).equals("31")) return R.drawable.actrol3r;
		return null;
	}
}
