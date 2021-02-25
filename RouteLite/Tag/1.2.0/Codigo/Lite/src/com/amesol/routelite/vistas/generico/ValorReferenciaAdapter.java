package com.amesol.routelite.vistas.generico;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.vistas.RevisionPendientes.pendientes;

public class ValorReferenciaAdapter extends ArrayAdapter<ValorReferencia>
{

	int textViewResourceId;
	boolean flagMessage = false;
	Context context;
	ArrayList<Boolean> checkedStates = new ArrayList<Boolean>();

	public ValorReferenciaAdapter(Context context, int textViewResourceId, ArrayList<ValorReferencia> objects)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;

		if (isInteger(objects.get(0).getDescripcion().substring(0, 1)))
		{
			Collections.sort(objects, new CustomComparatorNumber());
		}
		else
			Collections.sort(objects, new CustomComparator());

		for (int i = 0; i < objects.size(); i++)
		{
			checkedStates.add(i, false);
		}
	}

	public boolean isInteger(String str)
	{
		try
		{
			Integer.parseInt(str);
			return true;
		}
		catch (NumberFormatException nfe)
		{
		}
		return false;
	}

	public class CustomComparatorNumber implements Comparator<ValorReferencia>
	{
		@Override
		public int compare(ValorReferencia o1, ValorReferencia o2)
		{
			if (o1.getDescripcion().substring(0, 2) == o2.getDescripcion().substring(0, 2))
			{
				return 0;
			}
			else if (Integer.parseInt(o1.getDescripcion().substring(0, 2)) < Integer.parseInt(o2.getDescripcion().substring(0, 2)))
			{
				return -1;
			}
			return 1;
		}
	}

	public class CustomComparator implements Comparator<ValorReferencia>
	{
		@Override
		public int compare(ValorReferencia o1, ValorReferencia o2)
		{
			if (o1.getVavclave() == o2.getVavclave())
			{
				return 0;
			}
			else if (Integer.parseInt(o1.getVavclave()) < Integer.parseInt(o2.getVavclave()))
			{
				return -1;
			}
			return 1;
		}
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
		ValorReferencia vr = getItem(position);
		//		if (!vr.getVavclave().equals("22"))
		//		if (!((Vendedor) Sesion.get(Campo.VendedorActual)).JornadaTrabajo && !vr.getVavclave().equals("28"))
		//		{
		if (this.textViewResourceId == R.layout.elemento_checkbox)
		{
			CheckBox chkbox = (CheckBox) fila.findViewById(android.R.id.text1);
			if (chkbox != null)
			{
				chkbox.setClickable(false);
				chkbox.setFocusable(false);
				chkbox.setText(vr.getDescripcion());
				chkbox.setTag(vr.getVavclave());
			}
		}
		else
		{
			// red title
			TextView texto = (TextView) fila.findViewById(android.R.id.text1);
			if (texto != null)
			{
				if (isInteger(vr.getDescripcion().substring(0, 1)))
				{
					texto.setText(vr.getDescripcion().substring(2));
				}
				else
					texto.setText(vr.getDescripcion());
			}

			// description
			// Log.i(vr.getVarcodigo() + " " + vr.getVavclave(), Mensajes.get(vr.getVarcodigo() + vr.getVavclave()));
			// Log.i("elopez DEBUG",vr.getVarcodigo() + vr.getVavclave());
			texto = (TextView) fila.findViewById(R.id.txtItemDesc);
			texto.setText(Mensajes.get(vr.getVarcodigo() + vr.getVavclave()));

			// image
			ImageView imagen = (ImageView) fila.findViewById(android.R.id.icon);
			if (imagen != null)
			{
				Integer intImagen = obtenerImagen(vr);
				if (intImagen != null)
					imagen.setImageResource(intImagen);
			}
			if (vr.getVavclave().equals("3"))
			{
				try
				{
					pendientes[] pendientesMessage = Consultas.ConsultasVendedorMensaje.obtenerListaMensajes();
					int NumberOfUnread = 0;
					if (pendientesMessage != null)
					{
						for (int i = 0; i < pendientesMessage.length; i++)
						{
							if ((pendientesMessage[i].Posponer) != 2)
							{
								NumberOfUnread += 1;
							}
						}
						TextView lblNoPending = (TextView) fila.findViewById(R.id.txtNoPending);
						if (lblNoPending != null)
							lblNoPending.setText(Integer.toString(NumberOfUnread));
					}
					else
					{
						TextView lblNoPending = (TextView) fila.findViewById(R.id.txtNoPending);
						if (lblNoPending != null)
							lblNoPending.setText(Integer.toString(0));
					}
				}
				catch (Exception e)
				{
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
			else
			{
				TextView lblNoPending = (TextView) fila.findViewById(R.id.txtNoPending);
				if (lblNoPending != null)
					lblNoPending.setText("");
			}

			//			}

		}

		return fila;
	}

	private Integer obtenerImagen(ValorReferencia valorReferencia)
	{
		if (valorReferencia.getVarcodigo().equals("ACTROL"))
		{
			if (valorReferencia.getVavclave().equals("1"))
				return R.drawable.actrol1;
			else if (valorReferencia.getVavclave().equals("2"))
				return R.drawable.actrol2;
			else if (valorReferencia.getVavclave().equals("3"))
				return R.drawable.actrol3sr;
			else if (valorReferencia.getVavclave().equals("4"))
				return R.drawable.actrol4;
			else if (valorReferencia.getVavclave().equals("5"))
				return R.drawable.actrol5;
			else if (valorReferencia.getVavclave().equals("6"))
				return R.drawable.actrol6;
			else if (valorReferencia.getVavclave().equals("7"))
				return R.drawable.actrol7;
			else if (valorReferencia.getVavclave().equals("13"))
				return R.drawable.actrol13;
			else if (valorReferencia.getVavclave().equals("14"))
				return R.drawable.actrol14;
			else if (valorReferencia.getVavclave().equals("15"))
				return R.drawable.actrol15;
			else if (valorReferencia.getVavclave().equals("16"))
				return R.drawable.actrol16;
			else if (valorReferencia.getVavclave().equals("17"))
				return R.drawable.actrol17;
			else if (valorReferencia.getVavclave().equals("22"))
				return R.drawable.actrol22;
			else if (valorReferencia.getVavclave().equals("23"))
				return R.drawable.actrol23;
			else if (valorReferencia.getVavclave().equals("24"))
				return R.drawable.actrol24;
			else if (valorReferencia.getVavclave().equals("25"))
				return R.drawable.actrol25;
			else if (valorReferencia.getVavclave().equals("26"))
				return R.drawable.actrol26;
			else if (valorReferencia.getVavclave().equals("27"))
				return R.drawable.actrol27;
			else if (valorReferencia.getVavclave().equals("28"))
				return R.drawable.actrol28;
			else if (valorReferencia.getVavclave().equals("29"))
				return R.drawable.actrol29;
		}
		return null;
	}

	public boolean isChecked(int posicion)
	{
		return checkedStates.get(posicion);
	}

	public void setChecked(View v, int posicion)
	{
		// checkedStates
		CheckBox chkbox = (CheckBox) v.findViewById(android.R.id.text1);
		chkbox.setChecked(!checkedStates.get(posicion));
		checkedStates.set(posicion, !checkedStates.get(posicion));
	}
}
