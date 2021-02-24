package com.duxstar.dacza.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.media.MediaRecorder;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;


import com.duxstar.dacza.R;
//import com.amesol.routelite.actividades.Mensajes;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.act.SeleccionarRecarga;

import java.text.SimpleDateFormat;

public class RecargasAdapter extends ArrayAdapter<SeleccionarRecarga.VistaRecargas>
{

	int textViewResourceId;
	Context context;

	public RecargasAdapter(Context context, int textViewResourceId, SeleccionarRecarga.VistaRecargas[] objects)
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
		SeleccionarRecarga.VistaRecargas recarga = getItem(position);

        TextView texto =  (TextView) fila.findViewById(R.id.textoGreen);

		if (texto != null) {
            if (recarga.getTipoFase() == Enumeradores.TiposFasesDocto.CAPTURA)
                texto.setTextColor(ColorStateList.valueOf(Color.BLUE));
                //texto.setTextColor(Color.rgb(51, 102, 153)); //AZUL
            else if (recarga.getTipoFase() == Enumeradores.TiposFasesDocto.CANCELADO)
                texto.setTextColor(ColorStateList.valueOf(Color.RED));
                //texto.setTextColor(Color.rgb(255, 51, 51)); //RED
            else if (recarga.getTipoFase() == Enumeradores.TiposFasesDocto.SURTIDO)
                texto.setTextColor(Color.rgb(0, 128, 0)); //GREEN
                //texto.setTextColor(Color.rgb(0, 179, 89)); //GREEN
            else //CERRADO
                texto.setTextColor(Color.rgb(255, 102, 0)); //ORANGE
            texto.setText(recarga.getFolio());
        }

        texto = (TextView) fila.findViewById(R.id.texto2);
		if (texto != null)
			texto.setText("Fase: " + recarga.getFase());

		texto = (TextView) fila.findViewById(R.id.texto3);
		if (texto != null)
			texto.setText("Fecha: " + recarga.getFechaSolicitud());

		return fila;
	}
}
