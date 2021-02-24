package com.duxstar.dacza.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.KeyEvent;
import android.widget.ListView;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.ConsultarOrden;
import com.duxstar.dacza.presentadores.interfaces.IConsultaOrden;
import com.duxstar.dacza.vistas.generico.ODTDetalleAdapter;

import java.util.Collections;
import java.util.HashMap;

public class ConsultaOrden extends Vista implements IConsultaOrden {

    ConsultarOrden mPresenta;

    String mAccion;
    HashMap<String, String> oParametros = null;

	Handler handler;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.consulta_orden);
			deshabilitarBarra(true);

            setTitulo("Orden de Trabajo");
			mPresenta = new ConsultarOrden(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (!oParametros.get("OrdenId").trim().equals("")))
			{
                mPresenta.setOrdenId(oParametros.get("OrdenId"));
			}

			mPresenta.iniciar();

		}
		catch (Exception ex)
		{
			ex.printStackTrace();
		}

    }

    public void setFolio(String folio)
    {
        TextView texto = (TextView) findViewById(R.id.lblFolio);
        texto.setText("Folio: " + folio);
    }

    public void setFecha(String fecha)
    {
        TextView texto = (TextView) findViewById(R.id.lblFecha);
        texto.setText("Fecha: " + fecha);
    }

    public void setCliente(Cliente cliente)
    {
        TextView texto = (TextView) findViewById(R.id.lblCliente);
        texto.setText("Cliente: " + cliente.Clave + " - "  + cliente.RazonSocial);
    }

    public void setAgente(Usuario agente)
    {
        TextView texto = (TextView) findViewById(R.id.lblAgente);
        texto.setText("Agente: " + agente.Clave + " - " + agente.Nombre);
    }

    public void setVin(Vin vin, Articulo articulo)
    {
        TextView texto = (TextView) findViewById(R.id.lblVin);
        texto.setText("Vin: " + vin.Clave + " - " + articulo.Descripcion);
    }

    public void setObservacion(String observacion){
        TextView texto = (TextView) findViewById(R.id.lblObservacion);
        texto.setText("Observaciones: " + observacion);
    }

    public void refrescarProductos()
    {
        try
        {
            ListView lista = (ListView) findViewById(R.id.lstDetalle);
            if (mPresenta.getOrdenTrabajo().ODTDetalle.size() > 0)
            {
                Collections.sort(mPresenta.getOrdenTrabajo().ODTDetalle, new ODTDetalle.comparator());
                ODTDetalleAdapter adapter = new ODTDetalleAdapter(this, R.layout.elemento_articulo_orden, mPresenta.getOrdenTrabajo().ODTDetalle.toArray(new ODTDetalle[mPresenta.getOrdenTrabajo().ODTDetalle.size()]));
                adapter.setSoloLectura(true);
                lista.setAdapter(adapter);
            }
            else
            {
                lista.setAdapter(null);
            }
        }
        catch (Exception e)
        {
            mostrarError(e.getMessage());
        }
    }

	public void onWindowFocusChanged(boolean hasFocus)
	{

		super.onWindowFocusChanged(hasFocus);

		if (hasFocus)
		{

		}
		// Toast.makeText(context, text, duration).show();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
				return true;
		}

        return true;
		//return super.onKeyDown(keyCode, event);
	}

	@Override
	public void iniciar()
	{

	}

    @SuppressWarnings("unchecked")
    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {

    }

    @Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
    {

    }
}
