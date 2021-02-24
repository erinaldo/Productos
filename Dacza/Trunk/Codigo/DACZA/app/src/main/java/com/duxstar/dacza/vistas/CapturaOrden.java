package com.duxstar.dacza.vistas;


import java.util.HashMap;


import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.controles.AgenteTextBoxScanner;
import com.duxstar.dacza.controles.CapturaCliente;
import com.duxstar.dacza.controles.CapturaAgente;
import com.duxstar.dacza.controles.CapturaVin;
import com.duxstar.dacza.controles.TextBoxScanner;
import com.duxstar.dacza.controles.VinTextBoxScanner;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.Enumeradores.Solicitudes;
import com.duxstar.dacza.presentadores.act.CapturarOrden;
import com.duxstar.dacza.presentadores.interfaces.ICapturaOrden;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.vistas.generico.DialogoAlerta;

public class CapturaOrden extends Vista implements ICapturaOrden {

    CapturarOrden mPresenta;
    CapturaCliente capturaCliente;
    CapturaAgente capturaAgente;
    CapturaVin capturaVin;

    String mAccion;
    HashMap<String, String> oParametros = null;


    boolean siguiente = false;
    Object mPausaCiclo;
    boolean esNuevo = true;
    boolean soloLectura = false;
    boolean huboCambios = false;

	Handler handler;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.captura_orden);
			deshabilitarBarra(true);

            setTitulo("Orden de Trabajo");

            Button boton = (Button) findViewById(R.id.btnContinuar);
			boton.setText("Continuar");
            boton.setOnClickListener(mContinuar);

            TextView label = (TextView) findViewById(R.id.lblCliente);
            label.setText("Cliente");
			
			capturaCliente = (CapturaCliente) findViewById(R.id.capturaCliente);
            capturaAgente = (CapturaAgente) findViewById(R.id.capturaAgente);
            capturaVin = (CapturaVin) findViewById(R.id.capturaVin);

			mPresenta = new CapturarOrden(this, mAccion);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null && (!oParametros.get("OrdenId").trim().equals("")))
			{
                mPresenta.setOrdenId(oParametros.get("OrdenId"));
                esNuevo = false;
			}

			mPresenta.iniciar();
            capturaAgente.leaveFocus();
            capturaVin.leaveFocus();
            capturaCliente.setFocus();

            if (esNuevo)
                if((Cliente)Sesion.get(Campo.ClienteActual) == null)
                    capturaVin.setEnabled(false);

			if (mPresenta.errorFinalizar){
				return;
			}

		}
		catch (Exception ex)
		{
			ex.printStackTrace();
		}

    }

    private OnClickListener mContinuar = new OnClickListener() {
        public void onClick(View v) {
           if (validarCaptura())
           {
               mPresenta.Guardar();
               setResultado(Enumeradores.Resultados.RESULTADO_ENVIAR);
               Sesion.set(Campo.IdDocumentoEnviar, mPresenta.getOrdenId());

               finalizar();
               return;
           }
        }
    };

    public void setFocus()
    {
        /*if (Sesion.get(Campo.TipoCodigoActual) != null)
        {
            if (Sesion.get(Campo.TipoCodigoActual) == Enumeradores.TIPOCODIGO.CLIENTE) {
                capturaCliente.leaveFocus();
                capturaAgente.setFocus();
            }
            else if (Sesion.get(Campo.TipoCodigoActual) == Enumeradores.TIPOCODIGO.AGENTE) {
                capturaAgente.leaveFocus();
                capturaVin.setFocus();
            }
            else if (Sesion.get(Campo.TipoCodigoActual) == Enumeradores.TIPOCODIGO.VIN) {
                View view = this.getCurrentFocus();
                if (view != null) {
                    InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                    imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
                }
            }
        }*/
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
				salir();
				return true;
		}

        return true;
		//return super.onKeyDown(keyCode, event);
	}

	@Override
	public void iniciar()
	{

	}

	@SuppressWarnings("deprecation")
	public void mostrarObligatorio(String mensaje, final int tipoMensaje, String...titulo)
	{

		DialogoAlerta dialogo = new DialogoAlerta(this);
		dialogo.setMessage(mensaje);
		dialogo.setCancelable(false);
		String msgSi = "Si";
		String msgNo = "No";

		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.Si, tipoMensaje);
				dialog.dismiss();
			}
		});
		dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.No, tipoMensaje);
				dialog.cancel();
			}
		});
		dialogo.show();
	}

	//@SuppressWarnings("unchecked")
	@Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {
        //Button boton = (Button) findViewById(R.id.btnContinuar);
        //boton.setEnabled(true);

		if (requestCode == Solicitudes.SOLICITUD_BUSQUEDA_CLIENTES)
		{
			// si esta regresándo de la busqueda de productos
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
                Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);
                setClienteActual(cliente);
                if (Sesion.get(Campo.VinActual)==null)
                    limpiarVin();
			}
			else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				if (data != null)
				{
					String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
					if (!mensajeError.equals(""))
					{ // cuando se presiona back se manda el mensaje vacio
						mostrarError(mensajeError);
					}
				}
			}

			capturaCliente.setFinBusqueda();
		}
        else if (requestCode == Solicitudes.SOLICITUD_BUSQUEDA_AGENTES)
        {
            // si esta regresándo de la busqueda de productos
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
            {
                Usuario agente = (Usuario)Sesion.get(Campo.AgenteActual);
                setAgenteActual(agente);
            }
            else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
            {
                if (data != null)
                {
                    String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                    if (!mensajeError.equals(""))
                    { // cuando se presiona back se manda el mensaje vacio
                        mostrarError(mensajeError);
                    }
                }
            }

            capturaAgente.setFinBusqueda();
        }
        else if (requestCode == Solicitudes.SOLICITUD_BUSQUEDA_VINS)
        {
            // si esta regresándo de la busqueda de productos
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
            {
                Vin vin = (Vin)Sesion.get(Campo.VinActual);
                Articulo articulo = mPresenta.getArticulo(vin.ArticuloId);
                setVinActual(vin, articulo);
            }
            else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
            {
                if (data != null)
                {
                    String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                    if (!mensajeError.equals(""))
                    { // cuando se presiona back se manda el mensaje vacio
                        mostrarError(mensajeError);
                    }
                }
            }

            capturaVin.setFinBusqueda();
        }

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
		}else if(tipoMensaje ==0)
        {
			if(mPresenta.errorFinalizar)
            {
				finalizar();
			}
		}
	}

	private void salir()
	{
        mPresenta.ValidarCambios();
        if (huboCambios)
        {
            if (!soloLectura)
                mostrarPreguntaSiNo("Se perderán los cambios. ¿Está seguro de regresar?", 3);
            else
            {
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
        }
        else
        {
            regresar();
        }
	}

	private void regresar()
	{
		try
		{
			if (esNuevo || huboCambios)
			{
				mPresenta.cancelarCaptura();
			}
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

    public boolean validarCaptura()
    {
        if(capturaAgente.validarCaptura())
            if(capturaCliente.validarCaptura())
                if(capturaVin.validarCaptura())
                    return true;

        return false;
    }

	public void setClienteActual(Cliente cliente)
	{
        TextBoxScanner txtScaner = (TextBoxScanner) findViewById(R.id.textBoxScannerCliente);
        txtScaner.setTexto(cliente.Clave);
        txtScaner.setTag("CLIENTE" + cliente.Clave);
        TextView lblDesc = (TextView) findViewById(R.id.lblNombreCliente);
        lblDesc.setText(cliente.RazonSocial);
        capturaCliente.setCliente(cliente);

        capturaVin.setEnabled(true);
    }

    public void habilitaVin()
    {
        capturaVin.setEnabled(true);

    }

    public void setAgenteActual(Usuario agente)
    {
        AgenteTextBoxScanner txtScaner = (AgenteTextBoxScanner) findViewById(R.id.textBoxScannerAgente);
        txtScaner.setTexto(agente.Clave);
        txtScaner.setTag("AGENTE" + agente.Clave);
        TextView lblDesc = (TextView) findViewById(R.id.lblNombreAgente);
        lblDesc.setText(agente.Nombre);

        capturaAgente.setAgente(agente);
    }

    public void setVinActual(Vin vin, Articulo articulo)
    {
        VinTextBoxScanner txtScaner = (VinTextBoxScanner) findViewById(R.id.textBoxScannerVin);
        txtScaner.setTexto(vin.Clave);
        txtScaner.setTag("VIN" + vin.Clave);
        TextView lblDesc = (TextView) findViewById(R.id.lblDescripcion);
        lblDesc.setText(articulo.Descripcion);
        EditText txtKm = (EditText) findViewById(R.id.txtKilometraje);
        txtKm.setText(vin.Kilometraje.toString());
        capturaVin.setVin(vin);
    }

    public void setVinActual(Vin vin, Articulo articulo, OrdenTrabajo ordenTrabajo)
    {
        VinTextBoxScanner txtScaner = (VinTextBoxScanner) findViewById(R.id.textBoxScannerVin);
        txtScaner.setTexto(vin.Clave);
        txtScaner.setTag("VIN" + vin.Clave);
        TextView lblDesc = (TextView) findViewById(R.id.lblDescripcion);
        lblDesc.setText(articulo.Descripcion);
        EditText txtKm = (EditText) findViewById(R.id.txtKilometraje);
        txtKm.setText(Float.toString(ordenTrabajo.Kilometraje));
        capturaVin.setClaveManual(true);
        capturaVin.setVin(vin);
    }

    public float getKilometrajeActual(){
        return capturaVin.getKilometraje();
    }

    public void limpiarVin()
    {
        VinTextBoxScanner txtScaner = (VinTextBoxScanner) findViewById(R.id.textBoxScannerVin);
        txtScaner.setTexto("");
        txtScaner.setTag("");
        TextView lblDesc = (TextView) findViewById(R.id.lblDescripcion);
        lblDesc.setText("");
        EditText txtKm = (EditText) findViewById(R.id.txtKilometraje);
        txtKm.setText("");
        capturaVin.setVin(null);
    }

	public void setHuboCambios(boolean cambio)
	{
		huboCambios = cambio;
	}

	public Handler getHandler()
	{
		return handler;
	}

	public Object getPausaCiclo()
	{
		return mPausaCiclo;
	}

	/*
	 * public boolean getSiguiente(){ return siguiente; }
	 */

	public void setSiguiente(boolean bsiguiente)
	{
		siguiente = bsiguiente;
	}

	public void setSoloLectura(boolean soloLectura){
		this.soloLectura = soloLectura;
	}
	
	public void setEsNuevo(boolean esNuevo){
		this.esNuevo = esNuevo;
	}
	
	public void setCapturaEnabled(boolean enabled){
        capturaCliente.setEnabled(enabled);
        capturaAgente.setEnabled(enabled);
        capturaVin.setEnabled(enabled);
	}
}
