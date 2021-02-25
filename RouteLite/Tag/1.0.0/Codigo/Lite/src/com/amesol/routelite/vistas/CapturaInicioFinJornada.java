package com.amesol.routelite.vistas;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarInicioFinJornada;
import com.amesol.routelite.presentadores.interfaces.ICapturaInicioFinJornada;

public class CapturaInicioFinJornada extends Vista implements ICapturaInicioFinJornada
{

	private CapturarInicioFinJornada mPresenta;
	private String mAccion;
	private boolean huboCambios = false;
	private boolean finJornada = false;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.captura_iniciofinjornada);

		getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
		mPresenta = new CapturarInicioFinJornada(this, mAccion);
		mPresenta.iniciar();
		Usuario mUsuario = new Usuario();
		mUsuario.USUId = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		Vendedor mVendedor;
		try
		{
			mVendedor = Consultas.ConsultasVendedor.obtenerVendedorPorUsuario(mUsuario);

			TextView mFecha = (TextView) findViewById(R.id.lblFechaHoraInicio);
			
			lblTitle.setText(Mensajes.get("VENJornadaTrabajo"));
			
			mAccion = getIntent().getAction();
			if (!Consultas.ConsultaRegistroInicioFin.obtenerVendedorJornada(mVendedor.VendedorId)){
				//lblTitle.setText("Registrar Inicio de Jornada");
				mFecha.setText("");
				txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScannerInicio);
				txtScanner.setOnCodigoIngresado(mValidar);
				deshabilitarFin();
			}
			else{
				//lblTitle.setText("Registrar Fin de Jornada");
				finJornada = true;
				mFecha.setText(mPresenta.getFechaInicial(mVendedor));
				txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScannerFin);
				txtScanner.setOnCodigoIngresado(mValidar);
				deshabilitarInicio();
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
		
		TextView mText = (TextView) findViewById(R.id.lblInicio);
		mText.setText(Mensajes.get("MDBIniciarJornada"));
		
		mText = (TextView) findViewById(R.id.lblCodigoBarras);
		mText.setText(Mensajes.get("XCodigodeBarras") + " " + Mensajes.get("XCEDI"));
		
		mText = (TextView) findViewById(R.id.lblFin);
		mText.setText(Mensajes.get("MDBFinalizarJornada"));
		
		mText = (TextView) findViewById(R.id.lblCodigoBarrasCedi);
		mText.setText(Mensajes.get("XCodigodeBarras") + " " + Mensajes.get("XCEDI"));

		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setText(Mensajes.get("XContinuar"));
		boton.setOnClickListener(mContinuar);

		/*if (!((Vendedor) Sesion.get(Campo.VendedorActual)).JornadaTrabajo)
			txtScanner.setEnabled(false);*/

		if(mPresenta.getJornadaFinalizada()){
			deshabilitarInicio();
			deshabilitarFin();
			boton.setEnabled(false);
		}
	}
	
	private void deshabilitarInicio(){
		TextBoxScanner txtScannerInicio = (TextBoxScanner) findViewById(R.id.textBoxScannerInicio);
		txtScannerInicio.setEnabled(false);
		txtScannerInicio.habilitarBotonScanner(false);
		
		TextView mText = (TextView) findViewById(R.id.lblInicio);
		mText.setTextColor(Color.GRAY);
		
		mText = (TextView) findViewById(R.id.lblCodigoBarras);
		mText.setTextColor(Color.GRAY);
	}
	
	private void deshabilitarFin(){
		TextBoxScanner txtScannerFin = (TextBoxScanner) findViewById(R.id.textBoxScannerFin);
		txtScannerFin.setEnabled(false);
		txtScannerFin.habilitarBotonScanner(false);
		
		TextView mText = (TextView) findViewById(R.id.lblFin);
		mText.setTextColor(Color.GRAY);
		
		mText = (TextView) findViewById(R.id.lblCodigoBarrasCedi);
		mText.setTextColor(Color.GRAY);
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
	public void iniciar()
	{

	}

	private OnCodigoIngresadoListener mValidar = new OnCodigoIngresadoListener()
	{
		public void OnCodigoIngresado(String Codigo, int codigoLeido)
		{
			huboCambios = true;

		}
	};

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{

			if (txtScanner.getTexto().equals(""))
			{
				mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Código Barras CEDI"));
				return;
			}

			if (!txtScanner.getTexto().equals(((Vendedor) Sesion.get(Campo.VendedorActual)).CodigoBarras))
			{
				mostrarAdvertencia(Mensajes.get("E0489"));
				return;
			}
			if(finJornada){
				if(mPresenta.validaVentaSinSurtir()){
					mPresenta.registrarValores();
					finalizar();
				}
			}else{
				mPresenta.registrarValores();
				finalizar();	
			}
		}

	};

}
