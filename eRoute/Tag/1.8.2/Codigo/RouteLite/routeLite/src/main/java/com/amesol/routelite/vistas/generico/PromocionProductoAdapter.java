package com.amesol.routelite.vistas.generico;

import java.util.ArrayList;
import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.MeasureSpec;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.generales.ISetDatos;



public class PromocionProductoAdapter extends ArrayAdapter<Producto> {

	static class ViewHolder {
		  ListView lista ;
		  TextView textoclave;
		  TextView textoDes;
		  ImageButton iButton;
TextView txtClavepromocion;
TextView txtNombrePromocion;
TextView txtTipoPromocion;
TextView txtRangoPromocion;

		  int position;
	}
	
	int textViewResourceId;
	Context context;

	LayoutInflater inflater ;
	
	
	@Override
	public int getViewTypeCount() {
	    return objectos.length ;
	}

	@Override
	public int getItemViewType(int position) {
	    return position;
	}
	Producto[] objectos;
	Promocion[] aPromocion;
	ISetDatos Reglas; 
	ISetDatos Aplicaciones;
	public PromocionProductoAdapter(Context context, int textViewResourceId,
			Producto[] objects,Promocion[] ObjetosHijos,ISetDatos Reglas, ISetDatos Aplicaciones) {
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		 inflater = LayoutInflater.from(context);
		 objectos=objects;
		 aPromocion=ObjetosHijos;
		 this.Reglas=Reglas;
		 this.Aplicaciones=Aplicaciones;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		View fila = convertView;
		ViewHolder holder;
		if (convertView == null) {
		
			fila = inflater.inflate(textViewResourceId, null);
			 holder = new ViewHolder();
			 holder.textoclave =  (TextView) fila.findViewById(R.id.txtProductoClave);
			 holder.textoDes =  (TextView) fila.findViewById(R.id.txtProductoDescripcion);
			 holder.lista =  (ListView) fila.findViewById(R.id.lstPromociones);
			 holder.iButton= (ImageButton) fila.findViewById(R.id.btnVerMas);
			 
			 holder.txtClavepromocion =  (TextView) fila.findViewById(R.id.lblClavepromocion);
			 holder.txtNombrePromocion =  (TextView) fila.findViewById(R.id.lblNombrePromocion);
			 holder.txtTipoPromocion =  (TextView) fila.findViewById(R.id.lblTipoPromocion);
			 holder.txtRangoPromocion= (TextView) fila.findViewById(R.id.lblRangoPromocion);
			 
			 holder.txtClavepromocion.setText(Mensajes.get("XClave"));
			  holder.txtNombrePromocion.setText(Mensajes.get("XPromocion"));
			  holder.txtTipoPromocion.setText(Mensajes.get("XTipo"));
			   holder.txtRangoPromocion.setText(Mensajes.get("PRMTipoRango"));
			   
			 fila.setTag(holder);
			 
				Producto vr = getItem(position);

				holder.textoclave.setText(vr.ProductoClave);

				holder.textoDes.setText(vr.Nombre);

				 holder.iButton.setOnClickListener(new View.OnClickListener() {

					@Override
					public void onClick(View v) {
						View parent = (View) v.getParent().getParent();
						ListView lst = (ListView) parent.findViewById(R.id.lstPromociones);
						
						LinearLayout lay = (LinearLayout) parent.findViewById(R.id.layoutEncabezados);
						
						if (lst.getVisibility() == View.GONE) {
							lst.setVisibility(View.VISIBLE);
							lay.setVisibility(View.VISIBLE);
							((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
						if(lst.getTag()==null)
							setListViewHeightBasedOnChildren(lst);
						} else {
							lst.setVisibility(View.GONE);
							lay.setVisibility(View.GONE);
							((ImageButton) v).setImageResource(android.R.drawable.ic_menu_more);

						}

					}
				});

				try {
					
					
					List<Promocion> t = new ArrayList<Promocion>();
					for(int i=0;i<aPromocion.length;i++)
					{
						
						if(aPromocion[i].ProductoClave.equals(vr.getProductoClave()))
						{
							t.add(aPromocion[i]);
						}
					}
					PromocionesAdapter adapter = new PromocionesAdapter(context,
							R.layout.lista_promocion,
							t,aPromocion,Reglas,Aplicaciones );
					holder.lista.setAdapter(adapter);

				} catch (Exception e) {
					e.printStackTrace();
				}

				
		}
		else
		{
			 holder = (ViewHolder)fila.getTag();
		}
		
	
		return fila;
	}
	
	 public static void setListViewHeightBasedOnChildren(ListView listView) {
	        ListAdapter listAdapter = listView.getAdapter();
	        if (listAdapter == null) {
	            // pre-condition
	            return;
	        }

	        int totalHeight = 0;
	        int desiredWidth = MeasureSpec.makeMeasureSpec(listView.getWidth(), MeasureSpec.AT_MOST);
	        for (int i = 0; i < listAdapter.getCount(); i++) {
	            View listItem = listAdapter.getView(i, null, listView);
	            listItem.measure(desiredWidth, MeasureSpec.UNSPECIFIED);
	            totalHeight += listItem.getMeasuredHeight();
	        }

	        ViewGroup.LayoutParams params = listView.getLayoutParams();
	        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
	      
	        listView.setLayoutParams(params);
	        listView.requestLayout();
	        listView.setTag(true);
	    }

}
