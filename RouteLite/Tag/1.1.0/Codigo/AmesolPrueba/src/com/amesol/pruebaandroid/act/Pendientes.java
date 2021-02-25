package com.amesol.pruebaandroid.act;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.amesol.pruebaandroid.R;

import android.app.ListActivity;
import android.os.Bundle;
import android.view.KeyEvent;
import android.widget.SimpleAdapter;

public class Pendientes extends ListActivity {

	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.act_lista_simple);
		
		List<Map<String,String>> lista = new ArrayList<Map<String,String>>();
		Map<String,String> m =  new HashMap<String, String>();
		m.put("texto", "Promover la nueva linea de productos");
		lista.add(m);
		m =  new HashMap<String, String>();
		m.put("texto", "Nueva promocion");
		
		lista.add(m);
		
		setListAdapter(new SimpleAdapter(this, lista, 
				R.layout.simple_list_item_1,
				new String[] { "texto" },
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
}
