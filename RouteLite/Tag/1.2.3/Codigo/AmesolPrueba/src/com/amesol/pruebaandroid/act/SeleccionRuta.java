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
import android.app.ProgressDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ListView;
import android.widget.SimpleAdapter;

public class SeleccionRuta extends ListActivity {
	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.act_lista_simple);
		
		List<Map<String,String>> lista = new ArrayList<Map<String,String>>();
		Map<String,String> m =  new HashMap<String, String>();
		m.put("descripcion", "011 - Ruta Preventa 11");
		m.put("valor", "011");
		lista.add(m);
		m =  new HashMap<String, String>();
		m.put("descripcion", "002 - Ruta Preventa 2");
		m.put("valor", "002");
		lista.add(m);
		
		setListAdapter(new SimpleAdapter(this, lista, 
				R.layout.simple_list_item_1,
				new String[] { "descripcion" },
				new int[] { android.R.id.text1 }));
		
        //SharedPreferences sesion = getSharedPreferences(Entorno.trabajo.toString(), this.MODE_PRIVATE);

        this.setTitle("Selecciona una ruta para el dia " + Sesion.getElemento(ValoresSesion.DIACLAVE).toString());
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
		ProgressDialog dialog =ProgressDialog.show(SeleccionRuta.this, "", 
                "Listando clientes a visitar", true);
		Sesion.setElemento(ValoresSesion.RELOJARENA, dialog);
        Map map = (Map) l.getItemAtPosition(position);
        /*SharedPreferences sesion = getSharedPreferences(Entorno.trabajo.toString(), this.MODE_PRIVATE);
        SharedPreferences.Editor editor = sesion.edit();
        editor.putString("rutClave", map.get("valor").toString());
        editor.commit();*/
        Sesion.setElemento(ValoresSesion.RUTCLAVE, map.get("valor").toString());
        Intent intent = new Intent(SeleccionRuta.this, SeleccionCliente.class);
		startActivity(intent);
    }
}
