package com.amesol.routelite.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarKilometraje;
import com.amesol.routelite.presentadores.interfaces.ICapturaKilometraje;

public class CapturaKilometraje extends Vista implements ICapturaKilometraje
{
	CapturarKilometraje mPresenta;
	private String mAccion;
	private boolean huboCambios = false;
	private boolean isTrue = false;
	private EditText txtPlacas;
	private EditText txtKmInicial;
	private EditText txtKmFinal;
	private EditText txtLitrosGas;
	private EditText txtCostoGas;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.captura_kilometraje);

		getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
		mAccion = getIntent().getAction();
		lblTitle.setText("Registrar Kilometraje");
		mPresenta = new CapturarKilometraje(this, mAccion);
		mPresenta.iniciar();
		TextView texto = (TextView) findViewById(R.id.lblPlaca);
		texto.setText(Mensajes.get("XPlaca"));
		texto = (TextView) findViewById(R.id.lblClave);
		texto.setText(Mensajes.get("XClave"));
		texto = (TextView) findViewById(R.id.lblKmInicial);
		texto.setText(Mensajes.get("KilometrajeInicial"));
		texto = (TextView) findViewById(R.id.lblKmFinal);
		texto.setText(Mensajes.get("KilometrajeFinal"));

		texto = (TextView) findViewById(R.id.lblLtGasCons);
		texto.setText(Mensajes.get("LitrosGasConsumidos"));

		texto = (TextView) findViewById(R.id.lblLtGasConsumida);
		texto.setText(Mensajes.get("CostosGasConsumidas"));

		txtPlacas = (EditText) findViewById(R.id.txtScanner);
		txtKmInicial = (EditText) findViewById(R.id.txtKmInicial);
		txtKmFinal = (EditText) findViewById(R.id.txtKmFinal);
		txtKmFinal.setEnabled(isTrue);
		txtKmFinal.setOnFocusChangeListener(new OnFocusChangeListener()
		{
			@Override
			public void onFocusChange(View v, boolean hasFocus)
			{
				huboCambios = true;
				if (!txtKmFinal.getText().toString().equals(""))
				{
					if (Float.parseFloat(txtKmFinal.getText().toString()) <= 0)
					{
						txtKmFinal.setText("");
						mostrarError(Mensajes.get("E0012"));
						return;
					}

					if (Float.parseFloat(txtKmFinal.getText().toString()) <= Float.parseFloat(txtKmInicial.getText().toString()))
					{
						txtKmFinal.setText("");
						mostrarError(Mensajes.get("E0716").replace("$0$", "Kilometraje Final").replace("$1$", "Kilometraje Inicial"));
						return;
					}
				}

			}
		});
		txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);
		txtScanner.setOnCodigoIngresado(mValidar);
		txtLitrosGas = (EditText) findViewById(R.id.txtLtGasCons);
		txtLitrosGas.setEnabled(isTrue);
		txtCostoGas = (EditText) findViewById(R.id.txtLtGasConsumida);
		txtCostoGas.setEnabled(isTrue);

		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setText(Mensajes.get("XContinuar"));
		boton.setOnClickListener(mContinuar);

	}

	private OnCodigoIngresadoListener mValidar = new OnCodigoIngresadoListener()
	{
		public void OnCodigoIngresado(String Codigo, int codigoLeido)
		{
			if (mPresenta.validarPlacas(txtPlacas.getText().toString()))
			{
				huboCambios = true;
			}
			else
			{
				mostrarAdvertencia(Mensajes.get("E0722"));
			}
		}
	};

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			Button boton = (Button) findViewById(R.id.btnContinuar);
			huboCambios = true;
			try
			{
				if (txtPlacas.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Placa"));
					return;
				}
				if (txtKmInicial.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Kilometraje Inicial"));
					return;
				}
				if (isTrue && txtKmFinal.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Kilometraje Final"));
					return;
				}
				if (isTrue && txtCostoGas.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Litros Consumidos"));
					return;
				}
				if (isTrue && txtLitrosGas.getText().toString().equals(""))
				{
					mostrarError(Mensajes.get("BE0001").replace("$0$", "Importe Gasolina"));
					return;
				}
				mPresenta.asignarValoresCamion(txtPlacas.getText().toString(), txtKmInicial.getText().toString(), txtKmFinal.getText().toString(), txtLitrosGas.getText().toString(), txtCostoGas.getText().toString());
			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
				boton.setEnabled(true);
			}
		}

	};

	@Override
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

		if (tipoMensaje == 3)
		{
			if (respuesta == RespuestaMsg.Si)
			{
				regresar();
			}
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				salir();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private void regresar()
	{
		try
		{

			if (huboCambios)
				BDVend.rollback();

			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private void salir()
	{

		if (huboCambios)
			mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
		else
		{
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}

	}

	@Override
	public void setCapturaInicial(boolean isTrue)
	{
		this.isTrue = isTrue;

	}

	@Override
	public void setPlacaClave(String Placa, String Clave)
	{
		EditText EdiTexto = (EditText) findViewById(R.id.txtScanner);
		EdiTexto.setText(Placa);
		EdiTexto = (EditText) findViewById(R.id.txtClave);
		EdiTexto.setText(Clave);

	}

	@Override
	public void setValores(String Placa, String Clave, String KMInicial)
	{
		EditText EdiTexto = (EditText) findViewById(R.id.txtScanner);
		EdiTexto.setText(Placa);
		EdiTexto = (EditText) findViewById(R.id.txtClave);
		EdiTexto.setText(Clave);
		EdiTexto = (EditText) findViewById(R.id.txtKmInicial);
		EdiTexto.setText(KMInicial);

	}

}
