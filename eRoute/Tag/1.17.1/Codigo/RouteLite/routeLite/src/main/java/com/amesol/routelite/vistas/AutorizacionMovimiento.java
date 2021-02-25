package com.amesol.routelite.vistas;

import java.util.Random;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.AseguramientoVisita;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.AutorizarMovimiento;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.ISeleccionAgenda;
import com.amesol.routelite.utilerias.Token;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class AutorizacionMovimiento extends Vista implements IAutorizaMovimiento
{

	AutorizarMovimiento mPresenta;
	String mAccion;
	private static final Random generator = new Random();
	private String numero;
    private String token;
	private boolean salir;
	private AseguramientoVisita aseguramientoVisita;

	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.aurotizar_movimiento);
			deshabilitarBarra(true);

			Vendedor vendedor = (Vendedor) Sesion.get(Sesion.Campo.VendedorActual);
			aseguramientoVisita =  Consultas.ConsultarAseguramientoVisita.obtenerAseguramientoPorVendedor(vendedor);

			setTitulo(Mensajes.get("XAutorizacionMov"));

			TextView texto = (TextView) findViewById(R.id.lblToken);
			texto.setText(Mensajes.get("XToken"));

			EditText edit = (EditText) findViewById(R.id.txtToken);
			edit.setEnabled(false);
			edit = (EditText) findViewById(R.id.txtContrasena);

			texto = (TextView) findViewById(R.id.lblContrasena);
			if (mAccion != null && mAccion.equals(Enumeradores.Acciones.ACCION_FINALIZAR_CLIENTE_VISITA))
				texto.setText(Mensajes.get("XContrasenaFinVisita"));
			else
				texto.setText(Mensajes.get("XContrasenaVisita"));

			texto = (TextView) findViewById(R.id.lblToken);
			texto.setText(Mensajes.get("XIngresarContrasena") + "  ");

			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("BtContinuar"));
			btn.setOnClickListener(mContinuar);

			texto = (TextView) findViewById(R.id.lblClaveCliente);
			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

            if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)){
                texto.setText(vendedor.Nombre);
            }else{
                texto.setText(cliente.Clave + " - " + cliente.RazonSocial);
            }

			salir = false;

			mPresenta = new AutorizarMovimiento(this, mAccion);
			mPresenta.iniciar();

			if(aseguramientoVisita.EdoContraFija && (aseguramientoVisita.TipoContrasena == 1 || aseguramientoVisita.TipoContrasena == 0)){
				TextView tokenlbl = (TextView) findViewById(R.id.lblToken);
				tokenlbl.setVisibility(View.GONE);

				EditText tokentxt = (EditText) findViewById(R.id.txtToken);
				tokentxt.setVisibility(View.GONE);
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				mostrarPregunta();
				//this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}
   
	private OnClickListener mContinuar = new OnClickListener()
	{
		public void onClick(View v)
		{
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA) || mAccion.equals(Enumeradores.Acciones.ACCION_FINALIZAR_CLIENTE_VISITA)))
			{
				boolean valido = false;
				if(aseguramientoVisita.EdoContraFija && (aseguramientoVisita.TipoContrasena == 1 || aseguramientoVisita.TipoContrasena == 0)){
					valido = validarContrasenaFija();
				}else{
					valido = validarContrasena();
				}
				if (valido)
				{
                    Sesion.set(Campo.ResultadoActividad, token);
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN, null);
					finalizar();
					//iniciarActividad(ISeleccionVisita.class, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false);
				}
				else
					mostrarError(Mensajes.get("E0210"));
			}else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS))){
                if (validarContrasena()){
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN, null);
                    finalizar();
                }
                else
                    mostrarError(Mensajes.get("E0210"));
            }
		}
	};

	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if ((respuesta.equals(RespuestaMsg.Si)) && salir)
		{
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, null);
			this.finish();

            if (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)){
                iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_RUTA, null, false);
            }else if (!mAccion.equals(Enumeradores.Acciones.ACCION_FINALIZAR_CLIENTE_VISITA)){
                iniciarActividad(IAtencionClientes.class, false);
            }
		}
	}

	private boolean validarContrasena()
	{
		EditText edit = (EditText) findViewById(R.id.txtContrasena);
		if (edit.getText().toString().equals(numero))
		{
			AtencionClientes.token_valido = true;
			return true;
		}
		else
			return false;
	}

	private boolean validarContrasenaFija(){
		EditText edit = (EditText) findViewById(R.id.txtContrasena);
		if (edit.getText().toString().equals(aseguramientoVisita.ContrasenaFija))
		{
			return true;
		}
		else{
			return false;
		}
	}

	private void mostrarPregunta()
	{
		salir = true;
		mostrarPreguntaSiNo(Mensajes.get("BP0002"), 0);
	}

	public void setToken(String token)
	{
		EditText edit = (EditText) findViewById(R.id.txtToken);
		edit.setText(token);
	}

	public String obtenerToken()
	{
		Cliente Clave = (Cliente) Sesion.get(Campo.ClienteActual);
		if(mAccion.equals(Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA) || mAccion.equals(Enumeradores.Acciones.ACCION_FINALIZAR_CLIENTE_VISITA)) {
			while (Clave.Clave.length() < 5) {
				Clave.Clave = '0' + Clave.Clave;
			}

			Date date = Calendar.getInstance().getTime();
			DateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
			String today = formatter.format(date);

			int aux = Integer.parseInt(today.substring(0, 2)) + Integer.parseInt(today.substring(3, 5)) + Integer.parseInt(today.substring(6, 10));
//		String b = Clave.Clave.charAt(Clave.Clave.length()-1) + "";
//		String c = (int)Clave.Clave.charAt(Clave.Clave.length()-1)+"";
//		String aux1 = (int)Clave.Clave.charAt(Clave.Clave.length()-1)*900 + "";
//		String aux2 = (int)Clave.Clave.charAt(Clave.Clave.length()-2)*800 + "";
//		String aux3 = (int)Clave.Clave.charAt(Clave.Clave.length()-3)*700 + "";
//		String aux4 = (int)Clave.Clave.charAt(Clave.Clave.length()-4)*90 + "";
//		String aux5 = (int)Clave.Clave.charAt(Clave.Clave.length()-5)*80 + "";
			aux = aux + (int) Clave.Clave.charAt(Clave.Clave.length() - 1) * 900 + (int) Clave.Clave.charAt(Clave.Clave.length() - 2) * 800 + (int) Clave.Clave.charAt(Clave.Clave.length() - 3) * 700;
			aux = aux + (int) Clave.Clave.charAt(Clave.Clave.length() - 4) * 90 + (int) Clave.Clave.charAt(Clave.Clave.length() - 5) * 80;


			int num = generator.nextInt(900000) + 100000;
			int num2 = aux;
			String num3;
			numero = String.valueOf(num + num2);
			num3 = String.valueOf(num);
			token = Token.conceal(num3, Token.llaveCodifica);
			if (numero.length() > 6)
				numero = numero.substring(numero.length() - 6, numero.length());
		}else{
			numero = String.valueOf(generator.nextInt(900000) + 100000);
			token = Token.conceal(numero, Token.llaveCodifica);
		}
		return token;
	}
}
