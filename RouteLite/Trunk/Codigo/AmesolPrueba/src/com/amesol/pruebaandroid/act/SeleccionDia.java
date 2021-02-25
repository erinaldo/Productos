package com.amesol.pruebaandroid.act;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.amesol.pruebaandroid.R;
import com.amesol.pruebaandroid.enu.Entorno;
import com.amesol.pruebaandroid.prov.Sesion;
import com.amesol.pruebaandroid.prov.Sesion.ValoresSesion;

import android.app.ListActivity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ListView;
import android.widget.SimpleAdapter;

public class SeleccionDia extends ListActivity {
	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.act_lista_simple);
		
		List<Map<String,String>> lista = new ArrayList<Map<String,String>>();
		Map<String,String> m =  new HashMap<String, String>();
		m.put("descripcion", "08/12/2011");
		m.put("valor", "2011-12-08");
		lista.add(m);
		m =  new HashMap<String, String>();
		m.put("descripcion", "09/12/2011");
		m.put("valor", "2011-12-09");
		lista.add(m);
		
		setListAdapter(new SimpleAdapter(this, lista, 
				R.layout.simple_list_item_1,
				new String[] { "descripcion" },
				new int[] { android.R.id.text1 })); 
	}
	
	@Override
	public boolean onKeyDown(int keyCode,KeyEvent event){
		if(keyCode == KeyEvent.KEYCODE_SEARCH)
			return true;
		if(keyCode == KeyEvent.KEYCODE_HOME)
			return true;
		return super.onKeyDown(keyCode, event);
	}
	
	 @Override
	    protected void onListItemClick(ListView l, View v, int position, long id) {
	        Map map = (Map) l.getItemAtPosition(position);
	        /*SharedPreferences sesion = getSharedPreferences(Entorno.trabajo.toString(), this.MODE_PRIVATE);
	        SharedPreferences.Editor editor = sesion.edit();
	        editor.putString("diaClave", map.get("valor").toString());
	        editor.commit();*/
	        Sesion.setElemento( ValoresSesion.DIACLAVE,  map.get("valor").toString());
	        
	        Intent intent = new Intent(SeleccionDia.this, SeleccionRuta.class);
			startActivity(intent);
	    }

}
