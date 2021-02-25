package com.amesol.pruebaandroid.act;



import java.util.Map;

import com.amesol.pruebaandroid.R;
import com.amesol.pruebaandroid.ctrl.AdministrarCliente;
import com.amesol.pruebaandroid.dat.SesionBD;
import com.amesol.pruebaandroid.enu.Entorno;
import com.amesol.pruebaandroid.prov.Sesion;
import com.amesol.pruebaandroid.prov.Sesion.ValoresSesion;

import android.app.Activity;
import android.app.ListActivity;
import android.app.ProgressDialog;
import android.app.SearchManager;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteCursor;
import android.net.Uri;
import android.os.Bundle;
import android.text.Html;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

public class SeleccionCliente extends ListActivity{
	
	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.act_lista_clientes);
		
		
		SesionBD ses = new SesionBD(this);
		AdministrarCliente cli = new AdministrarCliente(ses);
		
		Cursor cur = cli.obtenerClientes(null);
		
		TextView texto = (TextView) findViewById(R.id.avisitar);
		texto.setText(Html.fromHtml("Tienes <b>"+ cur.getCount() + "</b> clientes a visitar"));
		setListAdapter(new SimpleCursorAdapter(this, R.layout.elemento_lista_doble, 
				cur,
				new String[] { SearchManager.SUGGEST_COLUMN_TEXT_1, SearchManager.SUGGEST_COLUMN_TEXT_2 },
				new int[] { android.R.id.text1, android.R.id.text2 }));
		
		
		ImageButton b = (ImageButton) findViewById(R.id.buscar);
		b.setOnClickListener(mEventoBuscar);
		
		Intent intent = getIntent();
		if (Intent.ACTION_SEARCH.equals(intent.getAction())) {
		    String query = intent.getStringExtra(SearchManager.QUERY);
		    
		    //doSearch(query);
		} else if (Intent.ACTION_VIEW.equals(intent.getAction())) {
		    // Handle a suggestions click (because the suggestions all use ACTION_VIEW)
		    Uri data = intent.getData();
		    //showResult(data);
		}
		ProgressDialog dialog = (ProgressDialog) Sesion.getElemento(ValoresSesion.RELOJARENA);
		dialog.dismiss();
	}
	
	private OnClickListener mEventoBuscar = new OnClickListener() {
		public void onClick(View arg0) {
			startSearch(null, false, null, false);			
		}
	}; 
	
	@Override
	public boolean onKeyDown(int keyCode,KeyEvent event){
		if(keyCode == KeyEvent.KEYCODE_HOME)
			return true;
		return super.onKeyDown(keyCode, event);
	}
	
	@Override
	public void onNewIntent(final Intent newIntent) {
		super.onNewIntent(newIntent);

		final String queryAction = newIntent.getAction();
		if (Intent.ACTION_SEARCH.equals(queryAction)) {
			String clienteClave = newIntent.getData().toString();
			if(clienteClave != null){
				Intent intent = new Intent(SeleccionCliente.this,DetalleCliente.class);
				intent.putExtra("clienteClave", clienteClave);
				startActivity(intent);
			}else{
				String s = newIntent.getStringExtra(SearchManager.QUERY);
			}
		}
	}
	
	
    
	@Override
	protected void onListItemClick(ListView l, View v, int position, long id) {
		SQLiteCursor c= (SQLiteCursor) l.getItemAtPosition(position);
		String clienteClave  = c.getString(c.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA));
		
		if(clienteClave != null){
			Intent intent = new Intent(SeleccionCliente.this,DetalleCliente.class);
			intent.putExtra("clienteClave", clienteClave);
			startActivity(intent);			
		}
	}

}
