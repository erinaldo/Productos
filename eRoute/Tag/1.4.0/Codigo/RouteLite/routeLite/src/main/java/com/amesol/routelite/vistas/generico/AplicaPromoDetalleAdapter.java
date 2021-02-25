package com.amesol.routelite.vistas.generico;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

import android.app.Activity;
import android.content.Context;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.PromocionDetalle;
import com.amesol.routelite.actividades.Promociones;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Promociones2.onTerminarAplicacionListener;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.Vista;

public class AplicaPromoDetalleAdapter extends ArrayAdapter<PromocionDetalle> {
	
	static class viewHolder{
		CheckBox check;
		EditText cantidad;
		TextView unidad;
		TextView producto;
		//TextView productoNombre;
		
		int position;
		
		boolean permiteSelProducto;
		boolean permiteCapturaCant;
	}
	
	@Override
	public int getViewTypeCount() {
	    return objetos.length ;
	}
	
	public PromocionDetalle[] getDetalles(){
		return objetos;
	}

	@Override
	public int getItemViewType(int position) {
	    return position;
	}
	
	int textViewResourceId; 
	Context context;
	LayoutInflater inflater;
	
	View fila;
	//AplicaPromocionesAdapter adapter;
	PromocionDetalle detalle;
	PromocionDetalle[] objetos;
	int tipoValidarExistencia;
	int tipoTransProd;
	viewHolder holder;

	
	public AplicaPromoDetalleAdapter(Context context, int textViewResourceId,
			PromocionDetalle[] objects, int TipoValidarExistencia) {		
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		tipoValidarExistencia =   TipoValidarExistencia;
		if (Sesion.get(Campo.ArrayTransProd) != null){
			HashMap<String, TransProd> arrayTransProd = (HashMap<String, TransProd>) Sesion.get(Campo.ArrayTransProd);
			Iterator it = arrayTransProd.entrySet().iterator();

			while (it.hasNext()){
				Map.Entry e = (Map.Entry) it.next();

				TransProd oTrp = (TransProd) e.getValue();
				tipoTransProd = oTrp.Tipo;
				break;
			}
		}
		//adapter = adpt;
		objetos = objects;
		inflater = LayoutInflater.from(context);
	}
	
	@Override
    public View getView(int position, View convertView, ViewGroup parent) {		
		fila = convertView;
        final int posicion = position;
		//final viewHolder holder;
		
		
		if(convertView == null){
			inflater = ((Activity)context).getLayoutInflater();
			fila = 	inflater.inflate(textViewResourceId, null);
			
			holder = new viewHolder();
			
			holder.check = (CheckBox) fila.findViewById(R.id.CheckBox);
			holder.check.setFocusable(true);
			holder.cantidad = (EditText) fila.findViewById(R.id.eCantidad);
			holder.unidad = (TextView) fila.findViewById(R.id.lblPiezas);
			holder.unidad.setFocusable(false);
			holder.producto = (TextView) fila.findViewById(R.id.lblProducto);
			holder.producto.setFocusable(false);
			
			fila.setTag(holder);			
			detalle = (PromocionDetalle) getItem(position);
			
			holder.producto.setText(detalle.getProducto());
			//holder.productoNombre.setText(detalle.getNombre());
			holder.unidad.setText(detalle.getUnidad());
			
			if(detalle.getCantidad() == -1)
				holder.cantidad.setVisibility(View.GONE);
			else{
				holder.cantidad.setFocusableInTouchMode(true);
				holder.cantidad.setTag(detalle);
				holder.cantidad.setSelectAllOnFocus(true);
		        holder.cantidad.setClickable(false);
				holder.cantidad.setFocusable(true);
                holder.cantidad.setOnKeyListener(new EditText.OnKeyListener() {
		        	@Override
		            public boolean onKey(View v, int keyCode, KeyEvent event) {
		                if (event.getAction()!=KeyEvent.ACTION_DOWN)
		                    return true;

		           /* 	switch(keyCode){
		    			case KeyEvent.KEYCODE_ENTER:
		    			    if (v.getParent().getParent().getParent()!= null){
					       int index = 	((ListView)v.getParent().getParent().getParent()).getPositionForView(v);

					       ((ListView)v.getParent().getParent().getParent()).requestFocusFromTouch();
					       ((ListView)v.getParent().getParent().getParent()).setSelection(index);
			    				}
			    				return false;
		            	}*/
		            	return v.onKeyDown(keyCode, event);
	            	}
	            });

		        holder.cantidad.setOnFocusChangeListener(new View.OnFocusChangeListener() {
		            @Override
		            public void onFocusChange(View v, boolean hasFocus) {
		            	if (!hasFocus){
		            		detalle = (PromocionDetalle)v.getTag();
		            		EditText et = (EditText) v;		
		            		if (et.getText().toString().equalsIgnoreCase("")){
		            			et.setText("0");
		            		}
							if (tipoValidarExistencia != TiposValidacionInventario.NoValidar)
							{
								AtomicReference<Float> existencia = new AtomicReference<Float>();
								StringBuilder error = new StringBuilder();
								if (!Inventario.ValidarExistencia(detalle.getProductoClave(),detalle.getPRUTipoUnidad(), Float.parseFloat(((EditText)v).getText().toString()), (short)TiposMovimientos.SALIDA, (short)tipoTransProd, existencia, error))
								{
									if (tipoValidarExistencia == TiposValidacionInventario.ValidacionInformativa)
									{
										((Vista)context).mostrarAdvertencia(error.toString());
									}
									else
									{
										//posicionError = pos;
										((IAplicacionPromocion)context).setErrorInventario(true);
										((Vista)context).mostrarError(error.toString());
										//seleccionTPD.get(productoClave).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
										
										et.setText(Generales.getFormatoDecimal(existencia.get(), detalle.getDecimalProducto()));
					    				detalle.setCantidad(Float.parseFloat(((EditText)v).getText().toString()));
					    				cambioCantidadListener.onCambioCantidad();
										return;
									}
								}
			    				detalle.setCantidad(Float.parseFloat(((EditText)v).getText().toString()));
			    				cambioCantidadListener.onCambioCantidad();
								//seleccionTPD.get(productoClave).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto);
								//et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));

							}
							else
							{
			    				detalle.setCantidad(Float.parseFloat(((EditText)v).getText().toString()));
			    				cambioCantidadListener.onCambioCantidad();
			    			}

		            	}else{
		            		EditText et = (EditText) v;
		            		et.selectAll();		        			
		            	}
		           
		            }
		          } ); 
		        	   
		        holder.cantidad.setOnTouchListener(new View.OnTouchListener() {
					@Override
					public boolean onTouch(View v, MotionEvent event) {
						v.onTouchEvent(event);
						((EditText) v).selectAll();
		                return true;
					}
		    });
		        holder.cantidad.setText(Generales.getFormatoDecimal(detalle.getCantidad(), detalle.getDecimalProducto()));
			}
			
			holder.check.setChecked(detalle.isChecked());
			holder.check.setTag(detalle);
			holder.check.setOnCheckedChangeListener(new OnCheckedChangeListener() {
				@Override
				public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
					detalle = (PromocionDetalle)buttonView.getTag();
					detalle.setChecked(isChecked);
					cambioCantidadListener.onCambioCantidad();
				}
			});	
			
			holder.cantidad.setEnabled(detalle.isSeleccionCantidad());
			holder.check.setEnabled(detalle.isSeleccionProducto());
			
			holder.permiteCapturaCant = detalle.isSeleccionCantidad();
			holder.permiteSelProducto = detalle.isSeleccionProducto();
		
			if ( holder.permiteSelProducto  && holder.permiteCapturaCant && detalle.getCantidad() > 0f){
				holder.check.setChecked(true);
				holder.check.setEnabled(false);
				holder.cantidad.setEnabled(false);
			}else if(!holder.permiteSelProducto){
				holder.check.setChecked(true);
				holder.check.setVisibility(View.GONE);
			}	
			
		}else
			holder = (viewHolder) fila.getTag();
		
		return fila;
	}	
	
	/**************** Eventos ****************************************/
	public interface onCambioCantidadListener
	{
		void onCambioCantidad();
	}

	private onCambioCantidadListener cambioCantidadListener = null;

	public void setOnCambioCantidadListener(onCambioCantidadListener l)
	{
		cambioCantidadListener = l;
	}
}
