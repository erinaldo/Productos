package com.amesol.routelite.vistas;

import java.util.AbstractMap;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.SortedMap;
import java.util.TreeMap;

import javax.xml.datatype.Duration;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.CursorAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Productos;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.datos.ClienteVentaMensual;
import com.amesol.routelite.datos.Esquema;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.BuscarProducto;
import com.amesol.routelite.presentadores.act.SeleccionarEsquemaProducto;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.presentadores.interfaces.ISeleccionEsquemaProducto;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.utilerias.ServicesCentral.TiposEsquemas;

public class SeleccionEsquemaProducto extends Vista implements ISeleccionEsquemaProducto
{

	private String mAccion;
	private SeleccionarEsquemaProducto mPresenta;
	private ListView listEsquemas;
	private SortedMap<String, Esquema> esquemas;
	boolean esquemaSeleccionado = false;
	//HashMap<String, Object> oParametros = null;
	
	
	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try{		
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			
			setContentView(R.layout.seleccion_esquema_producto);
			deshabilitarBarra(true);
			lblTitle.setText(Mensajes.get("ERMESQESC_IGeneral"));
			
			listEsquemas = (ListView) findViewById(R.id.lstEsquemas);
			
			
/*			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
		
			}*/
			
			esquemas = Consultas.ConsultasEsquema.obtenerEsquemasJerarquia(TiposEsquemas.Productos);
	        		
			if (esquemas == null)
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);			
				finalizar();
				return;
			}
			
			mPresenta = new SeleccionarEsquemaProducto(this, mAccion);
			mPresenta.iniciar();
		}catch (Exception e)
		{
			Toast.makeText(this, e.getMessage(), Toast.LENGTH_LONG ).show();
			finalizar();
		}
		
	}
	
	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub
		
	}
	
	@SuppressWarnings("deprecation")
	public void mostrarEsquemas(SortedMap<String,Esquema> esquemas)
	{

		if (esquemas == null)
		{ //da problemas cuando el cursor es null, por eso solo se oculta la lista para no mostrar ningun resultado
			listEsquemas.setVisibility(View.INVISIBLE);
			return;
		}
		else
		{
			listEsquemas.setVisibility(View.VISIBLE);
		}
		
		try
		{
			EsquemasAdapter adapter = new EsquemasAdapter(esquemas);
			listEsquemas.setAdapter(adapter);						

			listEsquemas.setOnItemClickListener(new OnItemClickListener()
			{
				public void onItemClick(AdapterView<?> arg0, View v, int pos, long arg3)
				{
					if (esquemaSeleccionado)  return;
					esquemaSeleccionado = true;
					Esquema esq = (Esquema) arg0.getItemAtPosition(pos);
					ArrayList<String> refaArreglo = new ArrayList<String>();
					String esquemaSeleccionado = "";
					if (Productos.obtenerEsquemasHijos(esq.EsquemaId, refaArreglo)){
						if (refaArreglo.size()>0){
							esquemaSeleccionado = TextUtils.join(",", refaArreglo);
						}
					}	
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN, esquemaSeleccionado);			
					finalizar();
				}
			});
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}
	
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub
		
	}
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public SortedMap<String,Esquema> obtenerEsquemas()
	{
		// TODO Auto-generated method stub
		
		return esquemas;
	}


	
	public class EsquemasAdapter extends BaseAdapter {

	    private SortedMap<String, Esquema> mData = new TreeMap<String, Esquema>();
	    private String[] mKeys;
	    public EsquemasAdapter(SortedMap<String, Esquema> data){
	        mData  = data;
	        mKeys = mData.keySet().toArray(new String[data.size()]);
	    }

	    @Override
	    public int getCount() {
	        return mData.size();
	    }

	    @Override
	    public Object getItem(int position) {
	        return mData.get(mKeys[position]);
	    }

	    @Override
	    public long getItemId(int arg0) {
	        return arg0;
	    }

	    @Override
	    public View getView(int pos, View convertView, ViewGroup parent) {
	        String key = mKeys[pos];
	        Esquema Value = (Esquema) getItem(pos);

			View view = convertView;
			ViewHolder holder;
			if(view == null){
				view = ((LayoutInflater) getBaseContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE)).inflate(R.layout.elemento_listado_esquemas, null);
				holder = new ViewHolder();
				holder.txtClave = (TextView) view.findViewById(R.id.txtClave);
				holder.txtNombre = (TextView) view.findViewById(R.id.txtNombre);
				view.setTag(holder);
			} else 
				holder = (ViewHolder) view.getTag();
			
			Esquema element = (Esquema) getItem(pos);
			holder.txtClave.setText(element.Clave );
			holder.txtNombre.setText(element.Nombre );
			
			return view;

	    }
	    
		private class ViewHolder {
			public TextView txtClave;
			public TextView txtNombre;
		}
	}

}
