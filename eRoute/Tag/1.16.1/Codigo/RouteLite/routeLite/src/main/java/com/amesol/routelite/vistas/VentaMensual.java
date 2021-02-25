package com.amesol.routelite.vistas;

import java.util.List;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.ClienteVentaMensual;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.Log;

import android.app.Fragment;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class VentaMensual extends Fragment
{

	private String clienteClave;
	
	public static VentaMensual newInstance(String clienteClave){
		VentaMensual vm = new VentaMensual();
		vm.clienteClave = clienteClave;
		return vm;
	}
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
	}
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		View view = inflater.inflate(R.layout.dialog_venta_mensual, container, false);
		setEtiquetas(view);
		view.findViewById(R.id.btnContinuar).setOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				close();
			}
		});
		cargaLista(view.findViewById(R.id.listVentaMensual));
		return view;
	}
	
	public void close(){
		getFragmentManager().beginTransaction().
			setCustomAnimations(android.R.animator.fade_in, android.R.animator.fade_out).
			remove(this).commit();
	}
	
	private void setEtiquetas(View v){
		TextView lbl = (TextView) v.findViewById(R.id.textView1);
		lbl.setText(Mensajes.get("XAcMenVen"));
		
		lbl = (TextView) v.findViewById(R.id.textView2);
		lbl.setText(Mensajes.get("XMes"));
		
		lbl = (TextView) v.findViewById(R.id.textView3);
		lbl.setText(Mensajes.get("XTotalVentaImporte"));
		
		((Button)v.findViewById(R.id.btnContinuar)).setText(Mensajes.get("XContinuar"));
	}
	
	private void cargaLista(View view){
		try{
			VentaMensualAdapter adapter = new VentaMensualAdapter(getActivity(), R.layout.elemento_venta_mensual, 
					Consultas.ConsultasClienteVentaMensual.obtieneVentaMensual(clienteClave));
			((ListView)view).setAdapter(adapter);
		}catch(Exception ex){
			Toast.makeText(getActivity(), ex.toString(), Toast.LENGTH_SHORT).show();
		}
	}
	
	private class VentaMensualAdapter extends ArrayAdapter<ClienteVentaMensual> {
		
		public VentaMensualAdapter(Context context, int resourceId, List<ClienteVentaMensual> elements){
			super(context, resourceId, elements);
		}
		
		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			ViewHolder holder;
			if(view == null){
				view = ((LayoutInflater) getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE)).inflate(R.layout.elemento_venta_mensual, null);
				holder = new ViewHolder();
				holder.txtMes = (TextView) view.findViewById(R.id.txtMes);
				holder.txtMonto = (TextView) view.findViewById(R.id.txtImporteVentas);
				view.setTag(holder);
			} else 
				holder = (ViewHolder) view.getTag();
			
			ClienteVentaMensual element = getItem(position);
			holder.txtMes.setText(element.Fecha);
			holder.txtMonto.setText("$ ".concat(Generales.getFormatoDecimal(element.MontoMensual, "#,##0.00")));
			
			return view;
		}
		
		private class ViewHolder {
			public TextView txtMes;
			public TextView txtMonto;
		}
	}
}
