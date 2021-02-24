package com.duxstar.dacza.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.act.SeleccionarDevolucion;
import com.duxstar.dacza.presentadores.act.SeleccionarRecarga;

//import com.amesol.routelite.actividades.Mensajes;

public class DevolucionesAdapter extends ArrayAdapter<SeleccionarDevolucion.VistaDevoluciones>
{

	int textViewResourceId;
	Context context;

	public DevolucionesAdapter(Context context, int textViewResourceId, SeleccionarDevolucion.VistaDevoluciones[] objects)
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
		SeleccionarDevolucion.VistaDevoluciones devolucion = getItem(position);

        TextView texto =  (TextView) fila.findViewById(R.id.textoGreen);

		if (texto != null) {
            if (devolucion.getTipoFase() == Enumeradores.TiposFasesDocto.CAPTURA)
                texto.setTextColor(ColorStateList.valueOf(Color.BLUE));
                //texto.setTextColor(Color.rgb(51, 102, 153)); //AZUL
            else if (devolucion.getTipoFase() == Enumeradores.TiposFasesDocto.CANCELADO)
                texto.setTextColor(ColorStateList.valueOf(Color.RED));
                //texto.setTextColor(Color.rgb(255, 51, 51)); //RED
            else //CERRADO
                texto.setTextColor(Color.rgb(255, 102, 0)); //ORANGE
            texto.setText(devolucion.getFolio());
        }

        texto = (TextView) fila.findViewById(R.id.texto2);
		if (texto != null)
			texto.setText("Fase: " + devolucion.getFase());

		texto = (TextView) fila.findViewById(R.id.texto3);
		if (texto != null)
			texto.setText("Fecha: " + devolucion.getFecha());

		return fila;
	}
}
