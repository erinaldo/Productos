package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.text.Html;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion.VistaConsignacion;
import com.amesol.routelite.utilerias.Generales;

public class ConsignacionAdapter extends ArrayAdapter<VistaConsignacion>
{

	int textViewResourceId;
	Context context;
	VistaConsignacion[] consignaciones;
	
	public ConsignacionAdapter(Context context, int textViewResourceId, VistaConsignacion[] objects)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		consignaciones = objects;
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
		SeleccionarConsignacion.VistaConsignacion consignacion = getItem(position);

		TextView texto = (TextView) fila.findViewById(R.id.texto1);
		if (texto != null)
			texto.setText(consignacion.Folio);

		texto = (TextView) fila.findViewById(R.id.texto2);
		if (texto != null)
			texto.setText(Html.fromHtml(Mensajes.get("XFase") + ": <b>" + consignacion.Fase + "</b>"));
		
		texto = (TextView) fila.findViewById(R.id.texto3);
		if (texto != null)
			texto.setText(Html.fromHtml(Mensajes.get("XSaldo") + ": <b>" + Generales.getFormatoDecimal(consignacion.Saldo, "$ #,##0.00")+ "</b>"));
		
		texto = (TextView) fila.findViewById(R.id.texto4);
		if (texto != null)
			texto.setText(Html.fromHtml(Mensajes.get("XTotal") + ": <b>" + Generales.getFormatoDecimal(consignacion.Total, "$ #,##0.00")+ "</b>"));

		texto = (TextView) fila.findViewById(R.id.texto5);
		if (texto != null)
			texto.setText(Html.fromHtml(Mensajes.get("XFechaAlta") + ": <b>" + DateFormat.format("dd/MM/yyyy", consignacion.FechaCreacion)+ "</b>"));

		return fila;
	}
	
}
