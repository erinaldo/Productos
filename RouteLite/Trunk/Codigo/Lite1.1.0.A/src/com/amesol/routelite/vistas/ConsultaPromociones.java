package com.amesol.routelite.vistas;

import java.util.HashMap;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.KeyEvent;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ConsultarPromociones;
import com.amesol.routelite.presentadores.interfaces.IConsultaPromociones;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.vistas.generico.PromocionProductoAdapter;

public class ConsultaPromociones extends Vista implements IConsultaPromociones
{

	ConsultarPromociones mPresenta;

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

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		setContentView(R.layout.consultar_promociones);
		deshabilitarBarra(true);

		TextView InformacionCliente = (TextView) findViewById(R.id.lblInformacionCliente);

		lblTitle.setText(Mensajes.get("btConsultarProm"));
		Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
		try
		{
			BDVend.recuperar(oCliente, ClienteDomicilio.class);
		}
		catch (ControlError e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		catch (Exception ex)
		{
			// TODO Auto-generated catch block
			ex.printStackTrace();
		}

		String infoCliente = "";
		infoCliente = oCliente.Clave + " " + oCliente.RazonSocial + "\n";
		infoCliente += oCliente.NombreCorto + "\n";

		for (int i = 0; i < oCliente.ClienteDomicilio.size(); i++)
		{
			if (oCliente.ClienteDomicilio.get(i).Tipo == 2)
			{
				infoCliente += oCliente.ClienteDomicilio.get(i).Calle + " " + oCliente.ClienteDomicilio.get(i).Numero + " " + oCliente.ClienteDomicilio.get(i).NumInt + " " + oCliente.ClienteDomicilio.get(i).Colonia + " " + oCliente.ClienteDomicilio.get(i).Localidad + " " + oCliente.ClienteDomicilio.get(i).Poblacion + " " + oCliente.ClienteDomicilio.get(i).Entidad + "\n";
				break;
			}
		}

		InformacionCliente.setText(infoCliente);

		TextView TituloProductos = (TextView) findViewById(R.id.lblProductos);
		TituloProductos.setText(Mensajes.get("XProductos"));
		TextView ClaveProducto = (TextView) findViewById(R.id.lblClaveProducto);
		ClaveProducto.setText(Mensajes.get("XClave"));
		TextView NombreProducto = (TextView) findViewById(R.id.lblNombreProducto);
		NombreProducto.setText(Mensajes.get("XNombre"));

		String precioClave = "";
		HashMap<String, String> oParametros;
		if (getIntent().getSerializableExtra("parametros") != null)
		{
			oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			if (oParametros != null)
			{
				precioClave = oParametros.get("PrecioClave");
			}
		}

		mPresenta = new ConsultarPromociones(this, precioClave);
		mPresenta.iniciar();

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
	public void mostrarProductos(Producto[] Productos, Promocion[] Promociones, ISetDatos Reglas, ISetDatos Aplicaciones)
	{
		if (Productos != null && Productos.length > 0)
		{
			ListView lista = (ListView) findViewById(R.id.lstProductos);
			PromocionProductoAdapter adapter = new PromocionProductoAdapter(this, R.layout.lista_promocionproducto, Productos, Promociones, Reglas, Aplicaciones);
			lista.setAdapter(adapter);
		}
	}

	@SuppressWarnings("deprecation")
	public void manejarCursor(Cursor c)
	{
		startManagingCursor(c);
	}

}
