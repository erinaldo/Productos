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
import com.duxstar.dacza.presentadores.act.SeleccionarOrden;

import java.text.SimpleDateFormat;

public class OrdenesAdapter extends ArrayAdapter<SeleccionarOrden.VistaOrdenes>
{

	int textViewResourceId;
	Context context;

	public OrdenesAdapter(Context context, int textViewResourceId, SeleccionarOrden.VistaOrdenes[] objects)
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
		SeleccionarOrden.VistaOrdenes orden = getItem(position);
//        boolean bMostrarCte = true;
//        if (position > 0) {
//            SeleccionarOrden.VistaOrdenes ordenAnt = getItem(position - 1);
//            if (ordenAnt.getCliente().equals(orden.getCliente()))
//            {
//                bMostrarCte = false;
//            }
//        }

        TextView texto; // = (TextView) fila.findViewById(R.id.lblGroup);
        /*if (texto != null)
        {
            texto.setText(orden.getCliente());
            if (bMostrarCte)
                texto.setText(orden.getCliente());
            else
                texto.setVisibility(View.GONE);
        }*/

        texto = (TextView) fila.findViewById(R.id.textoGreen);

        if (texto != null) {
            if (orden.getTipoFase() == Enumeradores.TiposFasesDocto.CAPTURA)
                texto.setTextColor(ColorStateList.valueOf(Color.BLUE));
            else if (orden.getTipoFase() == Enumeradores.TiposFasesDocto.CANCELADO)
                texto.setTextColor(ColorStateList.valueOf(Color.RED));
            else //CERRADO
                texto.setTextColor(Color.rgb(255, 102, 0)); //ORANGE
                //texto.setTextColor(Color.rgb(0,128,0)); //GREEN
            texto.setText(orden.getFolio());
        }

        texto = (TextView) fila.findViewById(R.id.texto1);
        if (texto != null)
            texto.setText("Cliente: " + orden.getCliente());

        texto = (TextView) fila.findViewById(R.id.texto2);
        if (texto != null)
            texto.setText("Agente: " + orden.getAgente());

        texto = (TextView) fila.findViewById(R.id.texto3);
        if (texto != null)
            texto.setText("VIN: " + orden.getVin());

		texto = (TextView) fila.findViewById(R.id.texto4);
		if (texto != null)
			texto.setText("Fase: " + orden.getFase());

		texto = (TextView) fila.findViewById(R.id.texto5);
		if (texto != null)
			texto.setText("Fecha: " + orden.getFechaIni());

		return fila;
	}
}
