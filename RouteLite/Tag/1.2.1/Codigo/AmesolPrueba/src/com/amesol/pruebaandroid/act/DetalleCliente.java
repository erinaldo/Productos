package com.amesol.pruebaandroid.act;

import com.amesol.pruebaandroid.R;
import com.amesol.pruebaandroid.ctrl.AdministrarCliente;
import com.amesol.pruebaandroid.ctrl.AdministrarCliente.Cliente;
import com.amesol.pruebaandroid.ctrl.AnimationHelper;
import com.amesol.pruebaandroid.dat.SesionBD;

import android.app.Activity;
import android.os.Bundle;
import android.view.MotionEvent;
import android.widget.TextView;
import android.widget.ViewFlipper;

public class DetalleCliente extends Activity {
	private ViewFlipper flipper= null;
	 private float oldTouchValue;
	
	@Override
	public void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);		
		setContentView(R.layout.act_detalle_cliente);
		SesionBD sesion = new SesionBD(this);
		Cliente cliente = new AdministrarCliente(sesion).obtenerCliente(getIntent().getStringExtra("clienteClave"));
		
		TextView texto = (TextView) findViewById(R.id.nombre_corto);
		texto.setText(cliente.getNombreCorto());
		
		texto = (TextView) findViewById(R.id.clave);
		texto.setText(cliente.getClave());
		
		texto = (TextView) findViewById(R.id.razon_social);
		texto.setText(cliente.getRazonSocial());
		
		texto = (TextView) findViewById(R.id.saldo);
		texto.setText(new java.text.DecimalFormat("$0.00").format(cliente.getSaldoEfectivo()));
		
		texto = (TextView) findViewById(R.id.nombre_contacto);
		texto.setText(cliente.getNombreContacto());
		
		texto = (TextView) findViewById(R.id.domicilio);
		StringBuffer sb = new StringBuffer();
		sb.append(cliente.getCalle());
		sb.append(" ");
		sb.append(cliente.getNumero());
		sb.append(" \n");
		sb.append(cliente.getColonia());
		sb.append(" \n");
		sb.append(cliente.getLocalidad());
		sb.append(", ");
		sb.append(cliente.getEntidad());
		
		texto.setText(sb.toString());
		
		
		flipper = (ViewFlipper) findViewById(R.id.flipper);
		
	}
	
	@Override
    public boolean onTouchEvent(MotionEvent touchevent) {
        switch (touchevent.getAction())
        {
            case MotionEvent.ACTION_DOWN:
            {
                oldTouchValue = touchevent.getX();
                break;
            }
            case MotionEvent.ACTION_UP:
            {
                
                float currentX = touchevent.getX();
                if (oldTouchValue < currentX)
                {
                    flipper.setInAnimation(AnimationHelper.inFromLeftAnimation());
                    flipper.setOutAnimation(AnimationHelper.outToRightAnimation());
                    flipper.showNext();
                }
                if (oldTouchValue > currentX)
                {
                	flipper.setInAnimation(AnimationHelper.inFromRightAnimation());
                	flipper.setOutAnimation(AnimationHelper.outToLeftAnimation());
                	flipper.showPrevious();
                }
            break;
            }
        }
        return false;
    }
	
	
}
