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
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.ConsultarOrden;
import com.duxstar.dacza.presentadores.act.ConsultarTraspaso;
import com.duxstar.dacza.presentadores.interfaces.IConsultaOrden;
import com.duxstar.dacza.presentadores.interfaces.IConsultaTraspaso;
import com.duxstar.dacza.vistas.generico.ListaInventarioAdapter;
import com.duxstar.dacza.vistas.generico.ListaTRPDetalleAdapter;
import com.duxstar.dacza.vistas.generico.ODTDetalleAdapter;

import java.util.Collections;
import java.util.HashMap;

public class ConsultaTraspaso extends Vista implements IConsultaTraspaso {

    ConsultarTraspaso mPresenta;

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
			setContentView(R.layout.consulta_traspaso);
			deshabilitarBarra(true);

            setTitulo("Traspasos");
			mPresenta = new ConsultarTraspaso(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (!oParametros.get("RecargaId").trim().equals("")))
			{
                mPresenta.setRecargaId(oParametros.get("RecargaId"));
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

    public void setFolioRecarga(String folio)
    {
        TextView texto = (TextView) findViewById(R.id.lblFolioRecarga);
        texto.setText("Recarga: " + folio);
    }

    public void refrescarProductos(ListaTRPDetalle[] detalles)
    {
        try
        {
            ListView inventoryList = (ListView) findViewById(R.id.lstDetalle);
            ListaTRPDetalleAdapter inventoryAdapter = new ListaTRPDetalleAdapter(this, R.layout.lista_list_inventario, detalles);
            inventoryList.setAdapter(inventoryAdapter);

            float totalExist = 0;
            for (int i = 0; i < detalles.length; i++)
                totalExist += detalles[i].Cantidad;

            TextView texto = (TextView) findViewById(R.id.txtTotalProductos);
            texto.setText(Float2String2Dec(totalExist));
        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();

            TextView texto = (TextView) findViewById(R.id.txtTotalProductos);
            texto.setText(("0.00"));
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

    public static class ListaTRPDetalle
    {
        public String Clave;
        public String Descripcion;
        public String Unidad;
        public float Cantidad;
    }

    public String Float2String2Dec(float fnumber)
    {
        String currStr = Float.toString(fnumber);
        if (currStr.contains("."))
            currStr = ((currStr.substring(currStr.indexOf(".") + 1, currStr.length()).length()) < 2) ? currStr + "0" : currStr.substring(0, currStr.indexOf(".") + 3);
        else
            currStr = currStr + ".00";
        return currStr;
    }
}
