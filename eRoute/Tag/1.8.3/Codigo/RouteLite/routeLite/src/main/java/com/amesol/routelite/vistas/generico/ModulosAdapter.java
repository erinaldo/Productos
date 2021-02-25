package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.ModuloMov;
import com.amesol.routelite.controles.HorizontalListView;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;

public class ModulosAdapter extends ArrayAdapter<ModuloMov>
{

	int textViewResourceId;
	Context context;
	OnItemClickListener horizontallistener;

	public ModulosAdapter(Context context, int textViewResourceId, ModuloMov[] objects, OnItemClickListener clicklistener)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		this.horizontallistener = clicklistener;
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
		ModuloMov vr = getItem(position);

		TextView texto = (TextView) fila.findViewById(R.id.text1);
		if (texto != null)
			texto.setText(vr.getNombre());

		try
		{
			HorizontalListView lista = (HorizontalListView) fila.findViewById(R.id.actividades);
			ModulosDetalleAdapter adapter = new ModulosDetalleAdapter(context, R.layout.lista_act_visita, Consultas.ConsultasActividades.obtenerActividadesPorModulo(vr.getModuloMovClave(), (Vendedor) Sesion.get(Campo.VendedorActual)));
			lista.setAdapter(adapter);
			lista.setOnItemClickListener(horizontallistener);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}

		return fila;
	}

}
