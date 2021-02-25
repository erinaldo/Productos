package com.amesol.routelite.vistas.generico;

import java.util.Iterator;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.MeasureSpec;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.PromocionAplicacion;
import com.amesol.routelite.datos.PromocionRegla;
import com.amesol.routelite.datos.TransProd;

public class AplicaPromocionesAdapter extends ArrayAdapter<Promocion>{

	static class viewHolder{
		ListView listaDetalle;
		TextView nombrePromocion;
		TextView total;
		TextView max;
		TextView numTotal;
		TextView numMax;
		ImageButton btn;
		int position;
	}
	
	int textViewResourceId; 
	Context context;
	LayoutInflater inflater;
	
	float max = 0;
	boolean MaxCalculado = false;
	View fila;
	Promocion[] objetos;
	TransProd oTRP;
	
	public AplicaPromocionesAdapter(Context context, int textViewResourceId,
			Promocion[] objects, TransProd transprod) {		
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		objetos = objects;
		inflater = LayoutInflater.from(context);
		oTRP = transprod;
	}
	
	@Override
	public int getViewTypeCount() {
	    return objetos.length ;
	}

	@Override
	public int getItemViewType(int position) {
	    return position;
	}
	
	@Override
    public View getView(int position, View convertView, ViewGroup parent) {		
		try{
			fila = convertView;
			viewHolder holder;
			
			if(convertView == null){
				//inflater = ((Activity)context).getLayoutInflater();
				fila = 	inflater.inflate(textViewResourceId, null);
				
				holder = new viewHolder();
				
				holder.nombrePromocion = (TextView) fila.findViewById(R.id.lblNombrePromocion);
				holder.listaDetalle = (ListView) fila.findViewById(R.id.lstPromoDetalle);
				holder.listaDetalle.setDescendantFocusability(ViewGroup.FOCUS_AFTER_DESCENDANTS);
				holder.listaDetalle.setChoiceMode(1);
				holder.listaDetalle.setItemsCanFocus(true);
				holder.listaDetalle.setClickable(false);
				holder.btn = (ImageButton) fila.findViewById(R.id.btnMasMenos);
				holder.total = (TextView) fila.findViewById(R.id.lblTotal);
				holder.max = (TextView) fila.findViewById(R.id.lblMax);
				holder.numMax = (TextView) fila.findViewById(R.id.lblNumMax);
				holder.numTotal = (TextView) fila.findViewById(R.id.lblNumTotal);
				holder.total.setText("TOTAL");
				holder.max.setText("MAX");
				fila.setTag(holder);
				holder.max.setFocusable(false);
				holder.numMax.setFocusable(false);
				holder.numTotal.setFocusable(false);
				holder.total.setFocusable(false);
				holder.nombrePromocion.setFocusable(false);
				holder.btn.setFocusable(false);
				
				Promocion promocion = (Promocion) getItem(position);
				holder.nombrePromocion.setText(promocion.Nombre);
				
				max = calcularMaximo(promocion);
				holder.numMax.setText(String.valueOf(max));
				
				holder.numTotal.setText("0.0");
				
				holder.btn.setOnClickListener(new OnClickListener() {
					@Override
					public void onClick(View v) {
						View parent = (View) v.getParent().getParent();
						ListView lst = (ListView) parent.findViewById(R.id.lstPromoDetalle);
						LinearLayout lay = (LinearLayout) parent.findViewById(R.id.layDetalle);
						
						if (lay.getVisibility() == View.GONE) {
							//lst.setVisibility(View.VISIBLE);
							lay.setVisibility(View.VISIBLE);
							((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
						if(lay.getTag()==null)
							setListViewHeightBasedOnChildren(lst);
						} else {
							//lst.setVisibility(View.GONE);
							lay.setVisibility(View.GONE);
							((ImageButton) v).setImageResource(android.R.drawable.ic_menu_more);
			
						}
					}
				});
				
			//	if(promocion.TipoAplicacion != 4){
					holder.total.setVisibility(View.GONE);
					holder.numTotal.setVisibility(View.GONE);
					holder.max.setVisibility(View.GONE);
					holder.numMax.setVisibility(View.GONE);
		/*		}else{
					if(promocion.CapturaCantidad){
						holder.total.setVisibility(View.VISIBLE);
						holder.numTotal.setVisibility(View.VISIBLE);
						holder.max.setVisibility(View.VISIBLE);
						holder.numMax.setVisibility(View.VISIBLE);	
					}
				}*/
				
				//AplicaPromoDetalleAdapter adapter = new AplicaPromoDetalleAdapter(this.getContext(), R.layout.elemento_promocion_detalle, Consultas.ConsultasPromocion.obtenerVistaDetalle(promocion, oTRP),this,fila);
				//holder.listaDetalle.setAdapter(adapter);
				
				setListViewHeightBasedOnChildren(holder.listaDetalle);
			
				//holder.listaDetalle.requestFocus();
			}//else
				//holder = (viewHolder) fila.getTag();			
			
			return fila;
		}catch(Exception ex){
			return null;
		}
	}
	
	private float calcularMaximo(Promocion promocion){
		float acumulado = 0;
		Iterator<PromocionRegla> it = promocion.PromocionRegla.iterator();
		while(it.hasNext()){
			Iterator<PromocionAplicacion> it2 = it.next().PromocionAplicacion.iterator();
			while(it2.hasNext()){
				PromocionAplicacion apl = it2.next(); //it.next().PromocionAplicacion.get(x);
				acumulado += apl.Cantidad;
			}
		}
		MaxCalculado = true;
		return acumulado;
	}
	
	public void acumular(float cantidad, View vista){
		//TextView text = (TextView) vista.findViewById(R.id.lblNumTotal);
		viewHolder holder = (viewHolder) vista.getTag();
		float acumulado = 0;
		acumulado = Float.parseFloat(holder.numTotal.getText().toString());
		acumulado += cantidad;
		holder.numTotal.setText(String.valueOf(acumulado));
	}
	
	public void setTotal(String total, View vista){
		viewHolder holder = (viewHolder) vista.getTag();
		holder.numTotal.setText(total);
	}
	
	public static void setListViewHeightBasedOnChildren(ListView listView) {
        ListAdapter listAdapter = listView.getAdapter();
        if (listAdapter == null) {
            // pre-condition
            return;
        }

       int totalHeight = 0;
        int desiredWidth = MeasureSpec.makeMeasureSpec(listView.getWidth(), MeasureSpec.UNSPECIFIED);
        for (int i = 0; i < listAdapter.getCount(); i++) {
            View listItem = listAdapter.getView(i, null, listView);
            listItem.measure(desiredWidth, MeasureSpec.UNSPECIFIED);
            totalHeight += listItem.getMeasuredHeight();
        }

        ViewGroup.LayoutParams params = listView.getLayoutParams();
        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
      
        //listView.setLayoutParams(params);
        listView.requestLayout();
        listView.setTag(true);
    }
}
