package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;

public class PedidosAdapter extends ArrayAdapter<SeleccionarPedido.VistaPedidos>
{

	int textViewResourceId;
	Context context;

	public PedidosAdapter(Context context, int textViewResourceId, SeleccionarPedido.VistaPedidos[] objects)
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
		SeleccionarPedido.VistaPedidos pedido = getItem(position);

		TextView texto = (TextView) fila.findViewById(R.id.texto1);
		if (texto != null)
			texto.setText(pedido.getFolio());

		texto = (TextView) fila.findViewById(R.id.texto2);
		if (texto != null)
			texto.setText(Mensajes.get("XFase") + ": " + pedido.getFase());

		texto = (TextView) fila.findViewById(R.id.texto3);
		if (texto != null)
			texto.setText(Mensajes.get("XFecha") + ": " + DateFormat.format("dd/MM/yyyy", pedido.getFecha()));

		return fila;
	}
}
