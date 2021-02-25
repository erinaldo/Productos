package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.vistas.ConsultaInventario.ListaInventario;

public class ListaInventarioAdapter extends ArrayAdapter<ListaInventario>
{
	int textViewResourceId;
	Context context;
	TextView textFiller;	

	public ListaInventarioAdapter(Context context, int textViewResourceId, ListaInventario[] itemsObjects)
	{
		super(context, textViewResourceId, itemsObjects);
		// TODO Auto-generated constructor stub
		this.textViewResourceId = textViewResourceId;
		this.context = context;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		View theRow = convertView;

		if (convertView == null)
		{
			LayoutInflater inflater = ((Activity) context).getLayoutInflater();
			theRow = inflater.inflate(textViewResourceId, null);
		}
		ListaInventario actualItem = getItem(position);

		textFiller = (TextView) theRow.findViewById(R.id.lblClaveName);
		textFiller.setText(actualItem.productoClave + " - " + actualItem.productoNombre);

		ValorReferencia[] vrUnits = ValoresReferencia.getValores("UNIDADV");	

		textFiller = (TextView) theRow.findViewById(R.id.lblItemInvenoryUnit);
		textFiller.setText(obtenerUnidades(vrUnits, actualItem));

		TextView textExistnce = (TextView) theRow.findViewById(R.id.lblItemInventoryExistence);
		textExistnce.setText(Float.toString(actualItem.existencia));

		textFiller = (TextView) theRow.findViewById(R.id.lblItemInventoryAvalible);
		textFiller.setText(Float.toString(actualItem.disponible ));
		
		textFiller = (TextView) theRow.findViewById(R.id.lblItemInventoryNoAvalible);
		textFiller.setText(Float.toString(actualItem.noDisponible));

		textFiller = (TextView) theRow.findViewById(R.id.lblItemInventoryMalEstado);
		textFiller.setText(Float.toString(actualItem.malEstado ));

		return theRow;
	}

	public String obtenerUnidades(ValorReferencia[] vrUnits, ListaInventario itemInventoryPosition){
		for (int i = 0; i < vrUnits.length; i++)
		{
			if (vrUnits[i].getVavclave().equals(Integer.toString(itemInventoryPosition.tipoUnidad)))
				return vrUnits[i].getDescripcion();									
		}
		return null;		
	}
}
