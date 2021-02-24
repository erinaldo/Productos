package com.duxstar.dacza.controles;

import java.util.HashMap;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.util.AttributeSet;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.duxstar.dacza.controles.TextBoxScanner.OnTextChangedListener;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.interfaces.IBuscaCliente;
import com.duxstar.dacza.vistas.CapturaOrden;
import com.duxstar.dacza.vistas.Vista;

public class CapturaCliente extends LinearLayout {

    // controles
    TextBoxScanner txtScannerCliente;
    ImageButton btnBuscar;
    TextView lblNombreCliente;

    // variables
    Cliente oCliente = null;
    Vista mVista = null;

    String nombreModulo = "Orden de Trabajo";
	Context context;

	boolean bClaveManual = false;
	boolean bMostrandoBusqueda = false;
	boolean bAdvertencia = false;
	String error = "";

	// ************************************************ constructores
	// ************************************************
	public CapturaCliente(Context context, AttributeSet attrs)
	{
		super(context, attrs);
		inicializar();
	}

	public CapturaCliente(Context context)
	{
		super(context);
		inicializar();
	}

	// ***************************************************************************************************************

	// ****************************************** funciones generales
	// ************************************************
	private void inicializar()
	{
		// Utilizamos el layout como interfaz del control
		String infService = Context.LAYOUT_INFLATER_SERVICE;
		LayoutInflater li = (LayoutInflater) getContext().getSystemService(infService);
		li.inflate(R.layout.captura_cliente, this, true);

		if (this.isInEditMode()) // para que no truene cuando se agrega al
									// layout en vista de diseño
			return;

        TextView label = (TextView) findViewById(R.id.lblCliente);
        label.setText("Cliente");

		// Obtenemos las referencias a los distintos controles
        txtScannerCliente = (TextBoxScanner) findViewById(R.id.textBoxScannerCliente);
        txtScannerCliente.tipoCodigo = Enumeradores.TIPOCODIGO.CLIENTE;
        txtScannerCliente.setOnCodigoIngresado(mCodigoBarrasCliente);
        txtScannerCliente.setOnTextChanged(new OnTextChangedListener()
		{
			@Override
			public void OnTextChanged(CharSequence s)
			{
				if (bClaveManual)
					return;
				lblNombreCliente.setText("");
				oCliente = null;
			}
		});

		btnBuscar = (ImageButton) findViewById(R.id.btnBuscarCliente);
		btnBuscar.setOnClickListener(mBuscarCliente);

		lblNombreCliente = (TextView) findViewById(R.id.lblNombreCliente);

		Activity act = (Activity) li.getContext();
        //((Vista) act).setCapturaCliente(this);
		mVista = (Vista) act;
	}

	public void limpiarCliente()
	{
		try
		{
            txtScannerCliente.BorrarTexto();
			lblNombreCliente.setText("");
			oCliente = null;
            txtScannerCliente.requestFocus();
		}
		catch (Exception e)
		{
			Log.e("", "" + e);

		}

	}

    public void setCliente(Cliente cliente)
    {
        oCliente = cliente;
    }

    public void setFocus()
    {
        txtScannerCliente.setFocusable(true);
        //txtScannerCliente.setFocusableInTouchMode(true);
        txtScannerCliente.requestFocus();
    }

    public void leaveFocus()
    {
        txtScannerCliente.clearFocus();
    }


	// ***************************************************************************************************************

	// ****************************** setters para los parametros de la busqueda
	// *************************************
	public void setError(String Error)
	{
		error = Error;
	}

	public void setAdvertencia(String Advertencia)
	{
		bAdvertencia = true;
		error = Advertencia;
	}

	// *************************************************************************************************
	public void setEnabled(boolean habilitar)
	{
        txtScannerCliente.setEnabled(habilitar);
		btnBuscar.setEnabled(habilitar);
        txtScannerCliente.habilitarBotonScanner(habilitar);
	}

	public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{
		// pasar a la vista el manejo
		mVista.resultadoActividad(requestCode, resultCode, intent);

	}

	public void setFinBusqueda()
	{
		//limpiarCliente();
		bMostrandoBusqueda = false;
	}

	private android.view.View.OnClickListener mBuscarCliente = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			buscarCliente(txtScannerCliente.getTexto(), false);
		}
	};

	private OnCodigoIngresadoListener mCodigoBarrasCliente = new OnCodigoIngresadoListener()
	{
		public void OnCodigoIngresado(String Codigo, int codigoLeido)
		{
			if (bClaveManual)
				return;
			if (Codigo.length() == 0)
				return;
			buscarCliente(Codigo, codigoLeido == 1 ? true : false);
		}
	};

	private void buscarCliente(String cadenaBusqueda, boolean codigoLeido)
	{
        try
        {
            if (bClaveManual)
                return;

            if (cadenaBusqueda.equals(""))
            {
                if (bMostrandoBusqueda)
                    return;
                if (buscarListener != null)
                {
                    buscarListener.onClienteNoEncontrado();
                }

                bMostrandoBusqueda = true;
                mVista.iniciarActividadConResultado(IBuscaCliente.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_CLIENTES, Enumeradores.Acciones.ACCION_OBTENER_CLIENTE_SELECCIONADO);
            }
            else
            {
                oCliente = null;
                if (!codigoLeido)
                {
                    oCliente = Consultas.ConsultasCliente.obtenerClienteIdentico(cadenaBusqueda);
                    if (oCliente == null)
                    {
                        // Buscar codigo barras
                        oCliente = Consultas.ConsultasCliente.obtenerCliente(cadenaBusqueda);
                        if (oCliente != null)
                        {
                            bClaveManual = true;
                            txtScannerCliente.txtScanner.setText(oCliente.Clave);
                            txtScannerCliente.requestFocus();
                            bClaveManual = false;

                            obtenerDetallesCliente();
                            mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                            return;
                        }
                        else
                        {
                            if (bMostrandoBusqueda)
                                return;
                            if (buscarListener != null)
                            {
                                buscarListener.onClienteNoEncontrado();
                            }
                            final HashMap<String, Object> parametros = new HashMap<String, Object>();
                            parametros.put("Cadena", cadenaBusqueda);
                            bMostrandoBusqueda = true;
                            mVista.iniciarActividadConResultado(IBuscaCliente.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_CLIENTES, Enumeradores.Acciones.ACCION_OBTENER_CLIENTE_SELECCIONADO, parametros);
                        }
                    }
                    else
                    {
                        obtenerDetallesCliente();
                    }
                }
                else
                {
                    oCliente = Consultas.ConsultasCliente.obtenerCliente(cadenaBusqueda);
                    if (oCliente != null)
                    {
                        bClaveManual = true;
                        txtScannerCliente.txtScanner.setText(oCliente.Clave);
                        bClaveManual = false;

                        obtenerDetallesCliente();
                        mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                        return;
                    }

                    Sesion.remove(Campo.ClienteActual);
                    mVista.mostrarError("El código no corresponde a un cliente existente");
                    //txtScannerCliente.BorrarTexto();
                    limpiarCliente();
                }
            }
        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }
		/*try
		{
			if (bClaveManual)
				return;

			if (cadenaBusqueda.equals(""))
			{
				if (bMostrandoBusqueda)
					return;
				if (buscarListener != null)
				{
					buscarListener.onClienteNoEncontrado();
				}
//					final HashMap<String, Object> parametros = new HashMap<String, Object>();
//					parametros.put("Esquema", "Todos");
                bMostrandoBusqueda = true;
                Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.CLIENTE);
                mVista.iniciarActividadConResultado(IBuscaCliente.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_CLIENTES, Enumeradores.Acciones.ACCION_OBTENER_CLIENTE_SELECCIONADO);
			}
			else
			{
				oCliente = null;
				if (!codigoLeido)
					oCliente = Consultas.ConsultasCliente.obtenerClienteIdentico(cadenaBusqueda);
				else
					oCliente = Consultas.ConsultasCliente.obtenerCliente(cadenaBusqueda);

                if (oCliente == null)
                {
                    Sesion.remove(Campo.ClienteActual);
                    mVista.mostrarError("El Código de Barras no corresponde a un cliente existente");
                    //txtScannerCliente.BorrarTexto();
                    limpiarCliente();
                }
                else
                {
                    lblNombreCliente.setText(oCliente.RazonSocial);
                    Sesion.set(Campo.ClienteActual, oCliente);
                    Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.CLIENTE);
                    ((CapturaOrden)mVista).setFocus();
                }
			}

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}*/
	}

    private void obtenerDetallesCliente()
    {
        if (Sesion.get(Campo.ClienteActual)!= null)
        {
            if (!((Cliente)Sesion.get(Campo.ClienteActual)).ClienteId.equals(oCliente.ClienteId)) {
                Sesion.remove(Campo.VinActual);
            }
        }
        lblNombreCliente.setText(oCliente.RazonSocial);
        ((CapturaOrden)mVista).habilitaVin();

        Sesion.set(Campo.ClienteActual, oCliente);
        Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.CLIENTE);
    }

	public boolean validarCaptura()
	{
		if (oCliente == null)
		{
			mVista.mostrarError("El campo Cliente es requerido");
            txtScannerCliente.requestFocus();
			return false;
		}

		return true;
	}

	private class vista implements ViewBinder
	{
		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			//int viewId = view.getId();
            TextView texto = (TextView) view;
            texto.setText(cursor.getString(columnIndex));

			return true;
		}
	}

	// ***************************** listener para buscar producto
	// ***************************************
	public interface onClienteNoEncontradoListener
	{
		void onClienteNoEncontrado();
	}

	private onClienteNoEncontradoListener buscarListener = null;

	public void setOnClienteNoEncontradoListener(onClienteNoEncontradoListener l)
	{
		buscarListener = l;
	}

}
