package com.amesol.pruebaandroid.act;


import com.amesol.pruebaandroid.R;
import com.amesol.pruebaandroid.ele.ItemMenu;
import com.amesol.pruebaandroid.ele.MenuListAdapter;
import com.amesol.pruebaandroid.enu.Actividad;


import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ListView;

public class MenuGeneral extends ListActivity {

	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.act_menu_general);
		
		ItemMenu[] lista = new ItemMenu[]{
				new ItemMenu("Actualizar", android.R.drawable.ic_menu_rotate,Actividad.actualizar),
				new ItemMenu("Mis Pendientes", android.R.drawable.ic_menu_agenda,Actividad.mis_pendientes),
				new ItemMenu("Mis Clientes", android.R.drawable.ic_menu_my_calendar,Actividad.mis_clientes),
				new ItemMenu("Mis Indicadores", android.R.drawable.ic_menu_gallery,Actividad.mis_indicadores)
				};
		
		/*ListView lstControl = (ListView) findViewById(R.id.listView1);
		lstControl.setAdapter(new MenuListAdapter(getApplicationContext(), R.layout.elemento_menu, lista));*/
		setListAdapter(new MenuListAdapter(getApplicationContext(), R.layout.elemento_menu, lista));
	    
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
		ItemMenu i = (ItemMenu) l.getItemAtPosition(position);
		Intent intent = null;
		switch(i.getIndice()){
		case actualizar:
			intent = new Intent(MenuGeneral.this, Actualizar.class);
			break;
		case mis_clientes:
			intent = new Intent(MenuGeneral.this, SeleccionDia.class);
			break;
		case mis_indicadores:
			intent = new Intent(MenuGeneral.this, Indicadores.class);
			break;
		case mis_pendientes:
			intent = new Intent(MenuGeneral.this, Pendientes.class);
			break;

		}
		if(intent != null) startActivity(intent);
	}
}
