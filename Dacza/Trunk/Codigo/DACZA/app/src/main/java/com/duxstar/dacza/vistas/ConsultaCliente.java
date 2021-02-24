package com.duxstar.dacza.vistas;

import java.util.List;
import java.util.Map;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;

import com.duxstar.dacza.R;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.ConsultarCliente;
import com.duxstar.dacza.presentadores.interfaces.IConsultaCliente;

public class ConsultaCliente extends Vista implements IConsultaCliente
{

	ConsultarCliente mPresenta;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		setContentView(R.layout.consulta_cliente);
		deshabilitarBarra(true);
		lblTitle.setText("Datos Generales del Cliente");

		mPresenta = new ConsultarCliente(this);
		mPresenta.iniciar();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public void iniciar()
	{

		// TODO Auto-generated method stub

	}

	public void mostrarDatosCliente(List<Map<String, String>> datosCliente)
	{
        //Datos del cliente
        ListView lstCliente = (ListView) findViewById(R.id.lstCliente);

        ListAdapter adapter = new SimpleAdapter(this, datosCliente, R.layout.lista_simple2,
                new String[]
                        { "descripcion", "valor" },
                new int[]
                        { R.id.texto1, R.id.texto2 });

        lstCliente.setAdapter(adapter);

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

}
