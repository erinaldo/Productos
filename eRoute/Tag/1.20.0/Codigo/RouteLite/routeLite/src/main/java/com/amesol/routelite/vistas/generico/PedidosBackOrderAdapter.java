package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.support.v4.app.NotificationCompatSideChannelService;
import android.support.v4.content.ContextCompat;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarPedidoBackOrder;

import static android.support.v4.content.ContextCompat.*;

public class PedidosBackOrderAdapter extends ArrayAdapter<SeleccionarPedidoBackOrder.VistaPedidos>
{

	int textViewResourceId;
	Context context;
	int pos;

	public PedidosBackOrderAdapter(Context context, int textViewResourceId, SeleccionarPedidoBackOrder.VistaPedidos[] objects, int Opcion)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		this.pos = Opcion;
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
		SeleccionarPedidoBackOrder.VistaPedidos pedido = getItem(position);

		TextView texto = (TextView) fila.findViewById(R.id.texto1);
		if (texto != null){
			if(pos == 1)
				texto.setText(pedido.getFolio());
			else
				texto.setText(pedido.getFolio() + " - " + pedido.getDescripcion());
		}

		texto = (TextView) fila.findViewById(R.id.texto2);
		if (texto != null)
			if(pos == 1)
				texto.setText(Mensajes.get("XFase") + ": " + pedido.getFase());
			else
				texto.setText(Mensajes.get("PRACantidad") + ": " + pedido.getCantidad());

		texto = (TextView) fila.findViewById(R.id.texto3);
		if (texto != null)
			if(pos == 1 && pedido.getTipoPedido() == Enumeradores.TipoPedido.NORMAL)
				texto.setText(Mensajes.get("XFolio") + ": " + pedido.getFolioConfirmado());
		    else
				texto.setVisibility(View.GONE);

		texto = (TextView) fila.findViewById(R.id.texto4);
		if (texto != null)
			if(pos == 1)
				texto.setText(Mensajes.get("XFecha") + ": " + pedido.getFecha());
			else
				texto.setText(Mensajes.get("CUVTipoUnidad") + ": " + pedido.getFase());

		texto = (TextView) fila.findViewById(R.id.texto5);
		texto.setVisibility(View.GONE);

		return fila;
	}
}
