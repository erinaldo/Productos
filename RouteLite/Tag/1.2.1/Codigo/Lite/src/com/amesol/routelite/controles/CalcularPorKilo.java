package com.amesol.routelite.controles;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.utilerias.Generales;

import android.animation.ArgbEvaluator;
import android.app.Activity;
import android.app.Fragment;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.TextView.OnEditorActionListener;

/**
 * Fragment para el calculo por kilos en el buscador de productos
 * @author bioxor
 *
 */
public class CalcularPorKilo extends Fragment
{
	private static final String TAG = "CalcularPorKilo";
	
	private CalcularPorKiloListener mListener;
	
	private ProductoCalculadora producto;

	public static CalcularPorKilo newInstance(String productoClave, int unidad){
		CalcularPorKilo mFragment = new CalcularPorKilo();
		Bundle bundle = new Bundle();
		bundle.putString("productoClave", productoClave);
		bundle.putInt("unidad", unidad);
		mFragment.setArguments(bundle);
		return mFragment;
	}
	
	public CalcularPorKilo(){}
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		if(getArguments() != null){
			try{
				producto = Consultas.ConsultasProducto.obtenerProductoCalculaPorKilo(getArguments().getString("productoClave"), getArguments().getInt("unidad"));
			}catch(Exception ex){
				ex.printStackTrace();
			}
		}
	}
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		View view = inflater.inflate(R.layout.fragment_calculadora, container, false);
		/* Agregar etiquetas */
		TextView lbl = (TextView) view.findViewById(R.id.textView1);
		lbl.setText(Mensajes.get("XCalcularKilos"));
		
		lbl = (TextView) view.findViewById(R.id.textView2);
		lbl.setText(Mensajes.get("XCostoKilo").concat(":"));
		
		lbl = (TextView) view.findViewById(R.id.textView3);
		lbl.setText(Mensajes.get("XKilosVender").concat(":"));
		
		lbl = (TextView) view.findViewById(R.id.textView4);
		String unidad = ValoresReferencia.getDescripcion("UNIDADV", String.valueOf(producto.PRUtipoUnidad));
		lbl.setText(Mensajes.get("XConversionA", unidad).concat(":"));
		
		lbl = (TextView) view.findViewById(R.id.textView5);
		lbl.setText(Mensajes.get("XModificarPrecio").concat(":"));
		
		lbl = (TextView) view.findViewById(R.id.textView6);
		lbl.setText(Mensajes.get("XPrecioFinal", unidad));
		lbl.setText("Precio final X ".concat(unidad).concat(":"));
		
		lbl = (TextView) view.findViewById(R.id.textView7);
		
		lbl.setText("$ ".concat(Generales.getFormatoDecimal(producto.getCostoXKilo(), "#,##0.00")));
		
		EditText txt = (EditText) view.findViewById(R.id.txt_kilos);
		txt.setHint("0");
		txt.setText("0");
		txt.setNextFocusDownId(R.id.txt_precio);
		txt.setNextFocusForwardId(R.id.txt_precio);
		txt.setNextFocusLeftId(R.id.txt_precio);
		txt.setNextFocusRightId(R.id.txt_precio);
		txt.setNextFocusUpId(R.id.txt_precio);
		txt.addTextChangedListener(new Watcher(txt, view));
		txt.requestFocus();
		
		lbl = (TextView) view.findViewById(R.id.txt_cajas);
		txt.setText("0");
		txt.setHint("0");
		
		txt = (EditText) view.findViewById(R.id.txt_precio);
		txt.setHint("0");
		txt.setText(String.valueOf(producto.getCostoXKilo()));
		
		txt.setNextFocusDownId(R.id.txt_cajas);
		txt.setNextFocusForwardId(R.id.txt_cajas);
		txt.setNextFocusLeftId(R.id.txt_cajas);
		txt.setNextFocusRightId(R.id.txt_cajas);
		txt.setNextFocusUpId(R.id.txt_cajas);
		txt.addTextChangedListener(new Watcher(txt, view));
		
		txt.setOnEditorActionListener(new OnEditorActionListener()
		{
			
			@Override
			public boolean onEditorAction(TextView arg0, int arg1, KeyEvent arg2)
			{
				if(arg1 == EditorInfo.IME_ACTION_DONE){
					if(mListener != null){
//						mListener.setCantidad(((TextView) getView().findViewById(R.id.txt_cajas)).getText().toString());
					}
				}
				return false;
			}
		});
		
		
		lbl = (TextView) view.findViewById(R.id.txt_final_cajas);
		lbl.setHint("0");
		lbl.setText("0");
		
		Button btn = (Button) view.findViewById(R.id.btn_calc_aceptar);
		btn.setText(Mensajes.get("XACEPTAR"));
		btn.setOnClickListener(onClick);
		btn = (Button) view.findViewById(R.id.btn_calc_cancelar);
		btn.setText(Mensajes.get("XCANCELAR"));
		btn.setOnClickListener(onClick);
		return view;
	}
	
	private OnClickListener onClick = new OnClickListener()
	{
		
		@Override
		public void onClick(View v)
		{
			if(mListener != null){
				if(v.getId() == R.id.btn_calc_aceptar){
					mListener.setCantidad(((TextView) getView().findViewById(R.id.txt_cajas)).getText().toString());
				}else{
					mListener.cancelar();
				}
			}
		}
	};
	
	@Override
	public void onAttach(Activity activity)
	{
		super.onAttach(activity);
		try{
			mListener = (CalcularPorKiloListener) activity;
		}catch(ClassCastException cce){
			Log.i(TAG, "No se propagaran eventos");
		}
	}
	
	@Override
	public void onDetach()
	{
		super.onDetach();
		mListener = null;
	}
	
	private class Watcher implements TextWatcher{
		
		private EditText txt;
		private View view;
		
		public Watcher(EditText txt, View view){
			this.txt = txt;
			this.view = view;
		}
		
		@Override
		public void onTextChanged(CharSequence s, int start, int before, int count)
		{
		}
		
		@Override
		public void beforeTextChanged(CharSequence s, int start, int count, int after)
		{
		}
		
		@Override
		public void afterTextChanged(Editable s)
		{
			TextView lbl;
			if(txt.getId() == R.id.txt_kilos){
				lbl = (TextView) view.findViewById(R.id.txt_cajas);
				if(producto.kgLitros > 0 && s.length() > 0){
					lbl.setText(Generales.getFormatoDecimal(Float.parseFloat(s.toString())/producto.kgLitros, 2));
				}else{
					lbl.setText("0");
				}
			}else{
				if(s.length()>0){
					producto.precioProductoVig = Float.parseFloat(s.toString());
				}else{
					producto.precioProductoVig = 0;
				}
				lbl = (TextView) view.findViewById(R.id.txt_final_cajas);
				lbl.setText(Generales.getFormatoDecimal(producto.kgLitros*producto.precioProductoVig, 2));
			}
		}
	}
	
	public interface CalcularPorKiloListener{
		public void cancelar();
		public void setCantidad(String cantidad);
	}
	
	public static class ProductoCalculadora{
		public String productoClave;
		public int PRUtipoUnidad;
		public float kgLitros;
		public float precioProductoVig;
		public float getCostoXKilo(){
			return kgLitros > 0 && precioProductoVig > 0 ? precioProductoVig/kgLitros : 0f;
		}
	}
}
