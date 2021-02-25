package com.amesol.routelite.vistas.generico;

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
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
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
    EditText primerEditText;
	
	View fila;
	//AplicaPromocionesAdapter adapter;
	PromocionDetalle detalle;
	PromocionDetalle[] objetos;
	int tipoValidarExistencia;
	int tipoTransProd;
	viewHolder holder;
    boolean modificandoManual = false;
	
	public AplicaPromoDetalleAdapter(Context context, int textViewResourceId,
			PromocionDetalle[] objects, int TipoValidarExistencia) {		
		super(context, textViewResourceId, objects);
        try {
            this.textViewResourceId = textViewResourceId;
            this.context = context;
            tipoValidarExistencia = TipoValidarExistencia;
            if (Sesion.get(Campo.ArrayTransProd) != null) {
                HashMap<String, TransProd> arrayTransProd = (HashMap<String, TransProd>) Sesion.get(Campo.ArrayTransProd);
                Iterator it = arrayTransProd.entrySet().iterator();

                while (it.hasNext()) {
                    Map.Entry e = (Map.Entry) it.next();

                    TransProd oTrp = (TransProd) e.getValue();
                    tipoTransProd = oTrp.Tipo;
                    break;
                }
            }
            //adapter = adpt;
            objetos = objects;
            inflater = LayoutInflater.from(context);
        }catch(Exception ex){
           throw ex;
        }
	}
	public void seleccionarPrimero(){
        if (primerEditText != null){
            primerEditText.requestFocus();
            primerEditText.selectAll();
        }


    }
	@Override
    public View getView(int position, View convertView, ViewGroup parent) {		
		fila = convertView;
		//final viewHolder holder;
		
		try {
            if (convertView == null) {
                inflater = ((Activity) context).getLayoutInflater();
                fila = inflater.inflate(textViewResourceId, null);

                holder = new viewHolder();

                holder.check = (CheckBox) fila.findViewById(R.id.CheckBox);
                holder.check.setFocusable(false);
                holder.cantidad = (EditText) fila.findViewById(R.id.eCantidad);
                holder.unidad = (TextView) fila.findViewById(R.id.lblPiezas);
                holder.unidad.setFocusable(false);
                holder.producto = (TextView) fila.findViewById(R.id.lblProducto);
                holder.producto.setFocusable(false);
                if (position == 0){
                    primerEditText = holder.cantidad;
                }

                fila.setTag(holder);
                detalle = (PromocionDetalle) getItem(position);

                holder.producto.setText(detalle.getProducto());
                //holder.productoNombre.setText(detalle.getNombre());
                holder.unidad.setText(detalle.getUnidad());

                if (detalle.getCantidad() == -1)
                    holder.cantidad.setVisibility(View.GONE);
                else {
                    holder.cantidad.setFocusableInTouchMode(true);
                    holder.cantidad.setTag(detalle);
                    holder.cantidad.setSelectAllOnFocus(true);
                    holder.cantidad.setClickable(false);
                    holder.cantidad.setFocusable(true);
                    /*PAra lograr que se navegue con enter entre las cantidades deberiamos hacer un arreglo de EditText como
                    * el de Busqueda de producto. No se realiza por falta de tiempo, queda pendiente*/
                    /*holder.cantidad.setOnKeyListener(new EditText.OnKeyListener() {
                        @Override
                        public boolean onKey(View v, int keyCode, KeyEvent event) {
                            if (event.getAction() != KeyEvent.ACTION_DOWN)
                                return true;

                            switch (keyCode) {
                                case KeyEvent.KEYCODE_ENTER:
                                    if (v.getParent().getParent().getParent().getParent().getParent() != null  && v.getParent().getParent().getParent().getParent().getParent().getClass() == ListView.class) {
                                        int index = ((ListView) v.getParent().getParent().getParent().getParent().getParent()).getPositionForView(v) + 1;
                                        ((ListView) v.getParent().getParent().getParent().getParent().getParent()).requestFocusFromTouch();
                                        ((ListView)v.getParent().getParent().getParent().getParent().getParent()).setSelection(index);
                                    }
                                    return false;
                            }
                            return v.onKeyDown(keyCode, event);
                        }
                    });*/
                    holder.cantidad.setOnFocusChangeListener(new View.OnFocusChangeListener() {
                        @Override
                        public void onFocusChange(View v, boolean hasFocus) {
                            if (!hasFocus) {
                                if (modificandoManual) return;
                                detalle = (PromocionDetalle) v.getTag();
                                EditText et = (EditText) v;
                                if (et.getText().toString().equalsIgnoreCase("")) {
                                    et.setText("0");
                                }
                                if (tipoValidarExistencia != TiposValidacionInventario.NoValidar) {
                                    AtomicReference<Float> existencia = new AtomicReference<Float>();
                                    StringBuilder error = new StringBuilder();
                                    if (!Inventario.ValidarExistencia(detalle.getProductoClave(), detalle.getPRUTipoUnidad(), Float.parseFloat(((EditText) v).getText().toString()), (short) TiposMovimientos.SALIDA, (short) tipoTransProd, existencia, error)) {
                                        if (tipoValidarExistencia == TiposValidacionInventario.ValidacionInformativa) {
                                                ((Vista) context).mostrarAdvertencia(error.toString());
                                            detalle.setCantidad(Float.parseFloat(((EditText) v).getText().toString()));
                                            cambioCantidadListener.onCambioCantidad();
                                        } else {
                                            //posicionError = pos;
                                            ((IAplicacionPromocion) context).setErrorInventario(true);
                                                ((Vista) context).mostrarError(error.toString());
                                            //seleccionTPD.get(productoClave).Cantidad = Generales.getRound(existencia.get(), decimalProducto);
                                            if (!detalle.isPendienteEntrega()) {
                                                if (existencia.get() != null) {
                                                    et.setText(Generales.getFormatoDecimal(existencia.get(), detalle.getDecimalProducto()));
                                                    detalle.setCantidad(Float.parseFloat(((EditText) v).getText().toString()));
                                                    cambioCantidadListener.onCambioCantidad();
                                                } else {
                                                    et.setText(Generales.getFormatoDecimal(0, detalle.getDecimalProducto()));
                                                    detalle.setCantidad(0);
                                                    cambioCantidadListener.onCambioCantidad();
                                                }
                                            }else{
                                                //Se va a backOrder la cantidad, y se deja capturada
                                                if (detalle.getCantidad() !=  Float.parseFloat(((EditText) v).getText().toString())) {
                                                    detalle.setCantidad(Float.parseFloat(((EditText) v).getText().toString()));
                                                    cambioCantidadListener.onCambioCantidad();
                                                    //et.clearFocus();
                                                }
                                            }
                                            return;
                                        }
                                    }else{
                                        detalle.setCantidad(Float.parseFloat(((EditText) v).getText().toString()));
                                        cambioCantidadListener.onCambioCantidad();
                                    }

                                    //seleccionTPD.get(productoClave).Cantidad = Generales.getRound(Float.parseFloat(et.getText().toString()), decimalProducto);
                                    //et.setText(Generales.getFormatoDecimal(seleccionTPD.get(productoClave).Cantidad, decimalProducto));

                                } else {
                                    detalle.setCantidad(Float.parseFloat(((EditText) v).getText().toString()));
                                    cambioCantidadListener.onCambioCantidad();
                                }

                            } else {
                                EditText et = (EditText) v;
                                et.selectAll();
                            }

                        }
                    });

                    holder.cantidad.setOnTouchListener(new View.OnTouchListener() {
                        @Override
                        public boolean onTouch(View v, MotionEvent event) {
                            v.onTouchEvent(event);
                            //((EditText) v).requestFocus();
                            ((EditText) v).selectAll();
                            return true;
                        }
                    });
                    //holder.cantidad.setText(Generales.getFormatoDecimal(detalle.getCantidad(), detalle.getDecimalProducto()));
                }

                //holder.check.setChecked(detalle.isChecked());
                //holder.check.setTag(detalle);
                holder.check.setOnCheckedChangeListener(new OnCheckedChangeListener() {
                    @Override
                    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                        if (modificandoManual) return;
                        detalle = (PromocionDetalle) buttonView.getTag();
                        detalle.setChecked(isChecked);
                        cambioCantidadListener.onCambioCantidad();
                    }
                });

                holder.cantidad.setEnabled(detalle.isSeleccionCantidad());
                holder.check.setEnabled(detalle.isSeleccionProducto());

                holder.permiteCapturaCant = detalle.isSeleccionCantidad();
                holder.permiteSelProducto = detalle.isSeleccionProducto();

                if (!detalle.isSeleccionProducto()){
                    detalle.setChecked(true);
                }

            } else
                holder = (viewHolder) fila.getTag();
        }catch(Exception ex){
            throw ex;
        }

        modificandoManual = true;
        holder.cantidad.setText(Generales.getFormatoDecimal(objetos[position].getCantidad(), objetos[position].getDecimalProducto()));
        holder.cantidad.clearFocus();
        holder.check.setChecked(objetos[position].isChecked());
        modificandoManual = false;
        holder.check.setTag(objetos[position]);
        if (!holder.permiteSelProducto) {
            modificandoManual = true;
            holder.check.setChecked(true);
            modificandoManual = false;
            holder.check.setEnabled(false);
        }

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
