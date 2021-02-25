package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.HashMap;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.act.CapturarCobranzaDocs;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDet;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.vistas.generico.CobranzaDocsAdapter;

public class CapturaCobranzaDocs extends Vista implements ICapturaCobranzaDocs
{

	String mAccion;
	CapturarCobranzaDocs mPresenta;
	Cobranza.VistaDocumentos[] oDocumentos;
	HashMap<String, Cobranza.VistaCobranza> oParametros = null;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			setContentView(R.layout.seleccion_transaccion);
			deshabilitarBarra(true);

			setTitulo(Mensajes.get("XCobranza"));

			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("XContinuar"));
			btn.setOnClickListener(mContinuar);

			mPresenta = new CapturarCobranzaDocs(this, mAccion);
			if (getIntent().getSerializableExtra("parametros") != null)
				oParametros = (HashMap<String, Cobranza.VistaCobranza>) getIntent().getSerializableExtra("parametros");

			if (oParametros != null && (!((Cobranza.VistaCobranza) oParametros.get("Abono")).getABNId().trim().equals("")))
				mPresenta.setABNId(((Cobranza.VistaCobranza) oParametros.get("Abono")).getABNId());
			mPresenta.iniciar();

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				setResult(Resultados.RESULTADO_TERMINAR);
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		public void onClick(View v)
		{
			if (mAccion.equals(Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA))
				consultarDetalleCobranza();
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA))
				capturarDetalleCobranza();
		}
	};

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
		{
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			//si selecciono terminar, finalizar la captura del abono
			finalizar();
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void mostrarCobranzaDocs(Cobranza.VistaDocumentos[] oDocumentos)
	{
		try
		{
			//if (oDocumentos.length > 0){
			ListView lista = (ListView) findViewById(R.id.lstTransaccion);
			boolean habilitar = (mAccion.equals(Enumeradores.Acciones.ACCION_GENERAR_COBRANZA) ? true : false);
			CobranzaDocsAdapter adapter = new CobranzaDocsAdapter(this, R.layout.lista_div2_check, oDocumentos, habilitar, mSeleccion);
			lista.setAdapter(adapter);
			/*
			 * }else{ setResultado(Resultados.RESULTADO_MAL); //,
			 * Mensajes.get("E0558").replace("$0$",
			 * (((String)oConHist.get("CobrarVentas")).equals("1") ?
			 * Mensajes.get("XVenta") : Mensajes.get("XFactura"))))
			 * //mostrarError("No hay documentos por cobrar"); //); finalizar();
			 * }
			 */

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public void setCliente(String cliente)
	{
		TextView texto = (TextView) findViewById(R.id.lblCliente);
		texto.setText(cliente);
	}

	@Override
	public void setRuta(String ruta)
	{
		TextView texto = (TextView) findViewById(R.id.lblRuta);
		texto.setText(Mensajes.get("XRuta") + ": " + ruta);
	}

	@Override
	public void setDia(String dia)
	{
		TextView texto = (TextView) findViewById(R.id.lblDia);
		texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia);
	}

	private void consultarDetalleCobranza()
	{
		iniciarActividadConResultado(ICapturaCobranzaDet.class, 0, Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA, oParametros);
	}

	private void capturarDetalleCobranza()
	{
		HashMap<String, ArrayList<String>> oParam = new HashMap<String, ArrayList<String>>();
		ArrayList<String> trpIds = mPresenta.getTransProdIds();

		if (trpIds == null)
		{
			mostrarError(Mensajes.get("E0039"));
			return;
		}

		oParam.put("TransProdIds", trpIds);
		iniciarActividadConResultado(ICapturaCobranzaDet.class, 0, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA, oParam);
	}

	public OnCheckedChangeListener mSeleccion = new OnCheckedChangeListener()
	{

		@Override
		public void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
		{

			if (isChecked)
				mPresenta.insertTransProdId((String) buttonView.getTag());
			else
				mPresenta.removeTransProdId((String) buttonView.getTag());

		}
	};

}
