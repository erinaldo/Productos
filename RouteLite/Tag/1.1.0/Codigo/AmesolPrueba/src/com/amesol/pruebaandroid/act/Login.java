package com.amesol.pruebaandroid.act;

import com.amesol.pruebaandroid.R;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Login extends Activity {

	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);		
		setContentView(R.layout.act_login);
		
		Button btnIngresar = (Button) findViewById(R.id.ingresar);
		btnIngresar.setOnClickListener(mIngresar);
	}
	
	@Override
	public boolean onKeyDown(int keyCode,KeyEvent event){
		if(keyCode == KeyEvent.KEYCODE_SEARCH)
			return true;
		if(keyCode == KeyEvent.KEYCODE_BACK){
			salir();
			return true;
		}
		if(keyCode == KeyEvent.KEYCODE_HOME)
			return true;

		return super.onKeyDown(keyCode, event);
	}
	
	
	private OnClickListener mIngresar = new OnClickListener() {
		
		public void onClick(View v) {
			String usuario = ((EditText)findViewById(R.id.txtLogin)).getText().toString();
			String password = ((EditText)findViewById(R.id.txtPassword)).getText().toString();
			if((usuario.toUpperCase().compareTo("ADMIN")==0)&&(password.compareTo("password")==0)){
				Intent intent = new Intent(Login.this, MenuGeneral.class);
				startActivity(intent);
			}else{
				Toast toast = Toast.makeText(v.getContext(), "Usuario o password incorrecto", Toast.LENGTH_SHORT);
				toast.show();
			}
		}
	};
	
	private void salir() {
		String usuario = ((EditText)findViewById(R.id.txtLogin)).getText().toString();
		String password = ((EditText)findViewById(R.id.txtPassword)).getText().toString();
		if((usuario.toUpperCase().compareTo("ADMIN")==0)&&(password.compareTo("password")==0)){
			System.runFinalizersOnExit(true);
			System.exit(0);
		}else{
			Toast toast = Toast.makeText(this, "El usuario no tiene permisos para salir", Toast.LENGTH_SHORT);
			toast.show();
		}
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
	    MenuInflater inflater = getMenuInflater();
	    inflater.inflate(R.menu.menu_login, menu);	    
	    return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
	    // Handle item selection
	    switch (item.getItemId()) {
	    case R.id.menu_salir:
	    	salir();
	        return true;
	    default:
	        return super.onOptionsItemSelected(item);
	    }
	}
}
