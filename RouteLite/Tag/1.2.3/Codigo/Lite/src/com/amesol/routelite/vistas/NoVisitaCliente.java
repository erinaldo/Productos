package com.amesol.routelite.vistas;

import android.app.SearchManager;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.NoVisitarCliente;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.INoVisitaCliente;

public class NoVisitaCliente extends Vista implements INoVisitaCliente
{

	private NoVisitarCliente mPresenta;
	private String mAccion;
	private Cliente cliente;
	private Dia dia;
	private Ruta ruta;
	private boolean salir;
	private boolean huboCambios;
	private boolean cargando;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			setContentView(R.layout.no_visitar_cliente);
			deshabilitarBarra(true);
			mAccion = getIntent().getAction();

			cargando = true;

			cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			dia = (Dia) Sesion.get(Campo.DiaActual);
			ruta = (Ruta) Sesion.get(Campo.RutaActual);
			TextView texto = (TextView) findViewById(R.id.lblMotivoNoVisita);
			if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE))
			{
				setTitulo(Mensajes.get("XNoVisitar"));
				texto.setText(Mensajes.get("XMotivoNoVisita"));
			}
			else if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VENTA))
			{
				setTitulo("No Venta");
				texto.setText(Mensajes.get("XMotivosVenta"));
			}

			texto = (TextView) findViewById(R.id.lblComentarios);
			texto.setText(Mensajes.get("XComentarios"));

			texto = (TextView) findViewById(R.id.lblCliente);
			texto.setText(cliente.Clave + " - " + cliente.RazonSocial);
			texto = (TextView) findViewById(R.id.lblRuta);
			texto.setText(Mensajes.get("XRuta") + ": " + ruta.Descripcion);
			texto = (TextView) findViewById(R.id.lblDia);
			texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia.DiaClave);

			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("BTContinuar"));
			btn.setOnClickListener(mContinuar);

			EditText text = (EditText) findViewById(R.id.txtComentarios);
			text.addTextChangedListener(mComentarios);
			Spinner spin = (Spinner) findViewById(R.id.cmbMotivoNoVisita);
			spin.setOnItemSelectedListener(mMotivo);

			salir = false;
			huboCambios = false;

			mPresenta = new NoVisitarCliente(this, mAccion);
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				if (huboCambios)
					mostrarPregunta();
				else
				{
					this.finish();
					if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE))
						iniciarActividad(IAtencionClientes.class, false);
				}
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private OnClickListener mContinuar = new OnClickListener()
	{
		public void onClick(View v)
		{
			try
			{
				if ((mAccion != null))
				{
					mPresenta.mContinuar();
				}
			}
			catch (Exception e)
			{
				mostrarError(e.getMessage());
				e.printStackTrace();
			}
		}
	};

	private TextWatcher mComentarios = new TextWatcher()
	{
		public void afterTextChanged(Editable arg0)
		{
		}

		public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
		{
		}

		public void onTextChanged(CharSequence arg0, int arg1, int arg2, int arg3)
		{
			huboCambios = true;
		}
	};

	private OnItemSelectedListener mMotivo = new OnItemSelectedListener()
	{

		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3)
		{
			if (!cargando && arg3 != -1)
				huboCambios = true;
		}

		public void onNothingSelected(AdapterView<?> arg0)
		{
		}
	};

	private void mostrarPregunta()
	{
		salir = true;
		mostrarPreguntaSiNo(Mensajes.get("BP0002"), 0);
	}

	public void iniciar()
	{
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if ((respuesta.equals(RespuestaMsg.Si)) && salir)
		{
			this.finish();
			if (mAccion.equals(Enumeradores.Acciones.ACCION_NO_VISITAR_CLIENTE))
				iniciarActividad(IAtencionClientes.class, false);
		}
	}

	@SuppressWarnings("deprecation")
	public void mostrarMotivosNoVisita(String Grupo)
	{
		try
		{
			ISetDatos vis = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("MOTIMPRO", Grupo, Mensajes.get("XSeleccionar", new String[]
			{ Mensajes.get("XMotivo") }), false);
			Cursor valores = (Cursor) vis.getOriginal();
			startManagingCursor(valores);
			Spinner s = (Spinner) findViewById(R.id.cmbMotivoNoVisita);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, valores,
					new String[]
					{ SearchManager.SUGGEST_COLUMN_TEXT_1 },
					new int[]
					{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
			s.setAdapter(adapter);
			cargando = false;
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	public short getMotivoNoVisita()
	{
		Spinner spin = (Spinner) findViewById(R.id.cmbMotivoNoVisita);
		return (short) spin.getSelectedItemId();
	}

	public String getComentario()
	{
		EditText texto = (EditText) findViewById(R.id.txtComentarios);
		return texto.getText().toString().trim();
	}

	public void mostrarMensajeRequerido()
	{
		TextView texto = (TextView) findViewById(R.id.lblMotivoNoVisita);
		mostrarError(Mensajes.get("BE0001", new String[]
		{ texto.getText().toString() }));
	}

}
