package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.act.SeleccionarActividadesVisita;

public class ModuloGridAdapter extends BaseAdapter
{
	int textViewResourceId;
	SeleccionarActividadesVisita mPresenta;
	Context context;
	ModuloMovDetalle[] modMovDetail;
	Integer[] imageVisit;

	public ModuloGridAdapter(Context context, int textViewResourceId, ModuloMovDetalle[] objects)
	{
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		this.modMovDetail = objects;
		ObteinIconsVisits();
	}

	@Override
	public int getCount()
	{
		// TODO Auto-generated method stub
		return modMovDetail.length;
	}

	@Override
	public Object getItem(int position)
	{
		return modMovDetail[position];
	}

	@Override
	public long getItemId(int position)
	{
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		// TODO Auto-generated method stub
		View iconSection = convertView;

		try
		{
			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				iconSection = inflater.inflate(textViewResourceId, null);
			}
			ModuloMovDetalle mmdVr = modMovDetail[position];

			TextView texto = (TextView) iconSection.findViewById(R.id.lblAct);
			if (texto != null)
				texto.setText(mmdVr.getNombre());

			ImageView getIcon = (ImageView) iconSection.findViewById(R.id.imgAct);

			getIcon.setImageResource(imageVisit[position]);
		}
		catch (Exception ex)
		{

		}

		/*
		 * try { HorizontalListView lista = (HorizontalListView)
		 * fila.findViewById(R.id.actividades); ModulosDetalleAdapter adapter =
		 * new ModulosDetalleAdapter(context, R.layout.lista_act_visita,
		 * Consultas
		 * .ConsultasActividades.obtenerActividadesPorModulo(vr.getModuloMovClave
		 * (), (Vendedor) Sesion.get(Campo.VendedorActual)));
		 * lista.setAdapter(adapter);
		 * lista.setOnItemClickListener(horizontallistener); } catch (Exception
		 * e) { e.printStackTrace(); }
		 */

		return iconSection;
	}

	public Integer[] ObteinIconsVisits()
	{
		try
		{
			ModuloMovDetalle[] mmdArray = Consultas.ConsultasActividades.obtenerActividadesVisita((Vendedor) Sesion.get(Campo.VendedorActual));
			imageVisit = new Integer[mmdArray.length];
			for (int i = 0; i < mmdArray.length; i++)
			{
				if (mmdArray[i].getTipoIndice() == 30)
					imageVisit[i] = R.drawable.mmd30;
				if (mmdArray[i].getTipoIndice() == 28)
					imageVisit[i] = R.drawable.mmd28;
				if (mmdArray[i].getTipoIndice() == 13)
					imageVisit[i] = R.drawable.mmd13;
				if (mmdArray[i].getTipoIndice() == 9)
					imageVisit[i] = R.drawable.mmd9;
				if (mmdArray[i].getTipoIndice() == 14)
					imageVisit[i] = R.drawable.mmd14;
				if (mmdArray[i].getTipoIndice() == 1)
					imageVisit[i] = R.drawable.mmd1;
				if (mmdArray[i].getTipoIndice() == 26)
					imageVisit[i] = R.drawable.mmd26;
				if (mmdArray[i].getTipoIndice() == 22)
					imageVisit[i] = R.drawable.mmd22;
				if (mmdArray[i].getTipoIndice() == 25)
					imageVisit[i] = R.drawable.mmd25;				
				if(mmdArray[i].getTipoIndice() == 27)
					imageVisit[i] = R.drawable.mmd27;
                if(mmdArray[i].getTipoIndice() == 19)
                    imageVisit[i] = R.drawable.mmd19;
                if(mmdArray[i].getTipoIndice() == 2)
                    imageVisit[i] = R.drawable.mmd2;
                if(mmdArray[i].getTipoIndice() == 12)
                    imageVisit[i] = R.drawable.mmd12;
				if(mmdArray[i].getTipoIndice() == 33)
					imageVisit[i] = R.drawable.mmd33;
                if(mmdArray[i].getTipoIndice() == 16)
                    imageVisit[i] = R.drawable.mmd16;
                if(mmdArray[i].getTipoIndice() == 4)
                    imageVisit[i] = R.drawable.mmd4;
			}
			return imageVisit;
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}
	/*
	 * private Integer[] obtenerImagen(ModuloMovDetalle actividad) {
	 * 
	 * return null; }
	 */
}
