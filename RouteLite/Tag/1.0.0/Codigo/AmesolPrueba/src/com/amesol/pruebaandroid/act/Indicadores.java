package com.amesol.pruebaandroid.act;


import com.amesol.pruebaandroid.R;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ProgressBar;

public class Indicadores extends Activity {
	
	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.act_indicadores);
		
		ProgressBar pb = (ProgressBar)findViewById(R.id.clientes);
		pb.setProgress(20);
		
		pb = (ProgressBar)findViewById(R.id.productos);
		pb.setProgress(50);
		
		pb = (ProgressBar)findViewById(R.id.vendedor);
		pb.setProgress(80);
	}
}
