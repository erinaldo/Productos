package com.duxstar.dacza.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.actividades.ValorReferencia;
import com.duxstar.dacza.actividades.ValoresReferencia;
import com.duxstar.dacza.vistas.ConsultaInventario.ListaInventario;

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
		textFiller.setText(actualItem.Clave + " - " + actualItem.Descripcion);

		/*textFiller = (TextView) theRow.findViewById(R.id.lblItemInvenoryUnit);
		textFiller.setText(obtenerUnidades(vrUnits, actualItem));*/

		TextView textExistnce = (TextView) theRow.findViewById(R.id.lblItemInventoryExistence);
		textExistnce.setText(Float.toString(actualItem.Existencia));
		return theRow;
	}

	/*public String obtenerUnidades(ValorReferencia[] vrUnits, ListaInventario itemInventoryPosition){
		for (int i = 0; i < vrUnits.length; i++)
		{
			if (vrUnits[i].getVavclave().equals(Integer.toString(itemInventoryPosition.tipoUnidad)))
				return vrUnits[i].getDescripcion();									
		}
		return null;		
	}*/
}
