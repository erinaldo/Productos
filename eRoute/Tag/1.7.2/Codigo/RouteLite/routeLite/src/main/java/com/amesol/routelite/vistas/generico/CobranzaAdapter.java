package com.amesol.routelite.vistas.generico;

import java.util.ArrayList;

import android.app.Activity;
import android.content.Context;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;

public class CobranzaAdapter extends ArrayAdapter<Cobranza.VistaCobranza>
{

	int textViewResourceId;
	Context context;

	public CobranzaAdapter(Context context, int textViewResourceId, ArrayList<Cobranza.VistaCobranza> objects)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		View fila = convertView;

		if (convertView == null)
		{
			LayoutInflater inflater = ((Activity) context).getLayoutInflater();
			fila = inflater.inflate(textViewResourceId, null);
		}
		Cobranza.VistaCobranza abono = getItem(position);

		TextView texto = (TextView) fila.findViewById(R.id.texto1);
		if (texto != null)
			texto.setText(abono.getFolio());

		texto = (TextView) fila.findViewById(R.id.texto2);
		if (texto != null)
			texto.setText(Mensajes.get("XFecha") + ": " + DateFormat.format("dd/MM/yyyy", abono.getFecha()));

		texto = (TextView) fila.findViewById(R.id.texto3);
		if (texto != null)
			texto.setText(Mensajes.get("ABNTotal") + ": " + String.format("$ %.2f", abono.getTotal()));

		return fila;
	}

}
