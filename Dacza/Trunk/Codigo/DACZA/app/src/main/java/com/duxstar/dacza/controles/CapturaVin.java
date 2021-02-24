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
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.controles.VinTextBoxScanner.OnVinCodigoIngresadoListener;
import com.duxstar.dacza.controles.VinTextBoxScanner.OnVinTextChangedListener;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.Vin;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.interfaces.IBuscaVin;
import com.duxstar.dacza.vistas.CapturaOrden;

public class CapturaVin extends LinearLayout {

    // controles
    VinTextBoxScanner txtScannerVin;
    ImageButton btnBuscar;
    TextView lblDescripcion;
    EditText txtKilometraje;

    // variables
    Vin oVin = null;
    CapturaOrden mVista = null;

    String nombreModulo = "Orden de Trabajo";
    Context context;

    boolean bClaveManual = false;
    boolean bMostrandoBusqueda = false;
    boolean bAdvertencia = false;
    String error = "";

    // ************************************************ constructores
    // ************************************************
    public CapturaVin(Context context, AttributeSet attrs) {
        super(context, attrs);
        inicializar();
    }

    public CapturaVin(Context context) {
        super(context);
        inicializar();
    }

    // ***************************************************************************************************************

    // ****************************************** funciones generales
    // ************************************************
    private void inicializar() {
        // Utilizamos el layout como interfaz del control
        String infService = Context.LAYOUT_INFLATER_SERVICE;
        LayoutInflater li = (LayoutInflater) getContext().getSystemService(infService);
        li.inflate(R.layout.captura_vin, this, true);

        if (this.isInEditMode()) // para que no truene cuando se agrega al
            // layout en vista de diseño
            return;

        TextView label = (TextView) findViewById(R.id.lblVin);
        label.setText("Vin");

        label = (TextView) findViewById(R.id.lblKilometraje);
        label.setText("Kilometraje");

        // Obtenemos las referencias a los distintos controles
        txtScannerVin = (VinTextBoxScanner) findViewById(R.id.textBoxScannerVin);
        txtScannerVin.tipoCodigo = Enumeradores.TIPOCODIGO.VIN;
        txtScannerVin.setOnVinCodigoIngresado(mCodigoBarrasVin);
        txtScannerVin.setOnVinTextChanged(new OnVinTextChangedListener() {
            @Override
            public void OnVinTextChanged(CharSequence s) {
                if (bClaveManual)
                    return;
                lblDescripcion.setText("");
                txtKilometraje.setText("");
                oVin = null;
            }
        });

        btnBuscar = (ImageButton) findViewById(R.id.btnBuscarVin);
        btnBuscar.setOnClickListener(mBuscarVin);

        lblDescripcion = (TextView) findViewById(R.id.lblDescripcion);

        txtKilometraje = (EditText) findViewById(R.id.txtKilometraje);

        Activity act = (Activity) li.getContext();
        mVista = (CapturaOrden) act;

    }

    public void limpiarVin() {
        try {
            txtScannerVin.BorrarTexto();
            lblDescripcion.setText("");
            txtKilometraje.setText("");
            oVin = null;
            txtScannerVin.requestFocus();
        } catch (Exception e) {
            Log.e("", "" + e);

        }

    }

    public void setVin(Vin vin)
    {
        oVin = vin;
    }

    public void setClaveManual(boolean manual)
    {
        bClaveManual = manual;
    }

    public float getKilometraje(){
        if (!txtKilometraje.getText().toString().equals(""))
            return Float.valueOf(txtKilometraje.getText().toString());
        return 0;
    }

    public void setFocus()
    {
        txtScannerVin.setFocusable(true);
        //txtScannerVin.setFocusableInTouchMode(true);
        txtScannerVin.requestFocus();
    }

    public void leaveFocus()
    {
        txtScannerVin.clearFocus();
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
        txtScannerVin.setEnabled(habilitar);
		btnBuscar.setEnabled(habilitar);
        txtKilometraje.setEnabled(habilitar);
        txtScannerVin.habilitarBotonScanner(habilitar);
	}

	public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{
		// pasar a la vista el manejo
		mVista.resultadoActividad(requestCode, resultCode, intent);

	}

	public void setFinBusqueda()
	{
		//limpiarVin();
		bMostrandoBusqueda = false;
	}

	private android.view.View.OnClickListener mBuscarVin = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			buscarVin(txtScannerVin.getTexto(), false);
		}
	};

	private OnVinCodigoIngresadoListener mCodigoBarrasVin = new OnVinCodigoIngresadoListener()
	{
		public void OnVinCodigoIngresado(String Codigo, int codigoLeido)
		{
			if (bClaveManual)
				return;
			if (Codigo.length() == 0)
				return;
				buscarVin(Codigo, codigoLeido == 1 ? true : false);
		}
	};

	private void buscarVin(String cadenaBusqueda, boolean codigoLeido)
	{
        try
        {
            if (bClaveManual)
                return;

            Cliente cliente = (Cliente)Sesion.get(Campo.ClienteActual);

            if (cadenaBusqueda.equals(""))
            {
                if (bMostrandoBusqueda)
                    return;
                if (buscarListener != null)
                {
                    buscarListener.onVinNoEncontrado();
                }

                bMostrandoBusqueda = true;
                mVista.iniciarActividadConResultado(IBuscaVin.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_VINS, Enumeradores.Acciones.ACCION_OBTENER_VIN_SELECCIONADO);
            }
            else
            {
                oVin = null;
                if (!codigoLeido)
                {
                    oVin = Consultas.ConsultasVin.obtenerVinIdentico(cadenaBusqueda, cliente.ClienteId);
                    if (oVin == null)
                    {
                        // Buscar codigo barras
                        oVin = Consultas.ConsultasVin.obtenerVin(cadenaBusqueda, cliente.ClienteId);
                        if (oVin != null)
                        {
                            bClaveManual = true;
                            txtScannerVin.txtScanner.setText(oVin.Clave);
                            txtScannerVin.requestFocus();
                            bClaveManual = false;

                            obtenerDetallesVin();
                            mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                            return;
                        }
                        else
                        {
                            if (bMostrandoBusqueda)
                                return;
                            if (buscarListener != null)
                            {
                                buscarListener.onVinNoEncontrado();
                            }
                            final HashMap<String, Object> parametros = new HashMap<String, Object>();
                            parametros.put("Cadena", cadenaBusqueda);
                            parametros.put("ClienteId", cliente.ClienteId);
                            bMostrandoBusqueda = true;
                            mVista.iniciarActividadConResultado(IBuscaVin.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_VINS, Enumeradores.Acciones.ACCION_OBTENER_VIN_SELECCIONADO, parametros);
                        }
                    }
                    else
                    {
                        obtenerDetallesVin();
                    }
                }
                else
                {
                    oVin = Consultas.ConsultasVin.obtenerVin(cadenaBusqueda, cliente.ClienteId);
                    if (oVin != null)
                    {
                        bClaveManual = true;
                        txtScannerVin.txtScanner.setText(oVin.Clave);
                        bClaveManual = false;

                        obtenerDetallesVin();
                        mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                        return;
                    }

                    Sesion.remove(Campo.VinActual);
                    mVista.mostrarError("El código no corresponde a un vin existente");
                    //txtScannerVin.BorrarTexto();
                    limpiarVin();
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
					buscarListener.onVinNoEncontrado();
				}
//					final HashMap<String, Object> parametros = new HashMap<String, Object>();
//					parametros.put("Esquema", "Todos");
					bMostrandoBusqueda = true;
                    Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.VIN);
					mVista.iniciarActividadConResultado(IBuscaVin.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_VINS, Enumeradores.Acciones.ACCION_OBTENER_VIN_SELECCIONADO);
			}
			else
			{
				oVin = null;
				if (!codigoLeido)
					oVin = Consultas.ConsultasVin.obtenerVinIdentico(cadenaBusqueda);
				else
					oVin = Consultas.ConsultasVin.obtenerVin(cadenaBusqueda);

                if (oVin == null)
                {
                    Sesion.remove(Campo.VinActual);
                    mVista.mostrarError("El Código de Barras no corresponde a un vin existente");
                    //txtScannerVin.BorrarTexto();
                    limpiarVin();
                }
                else
                {
                    Articulo oArticulo = Consultas.ConsultasArticulo.obtenerArticulo(oVin.ArticuloId);
                    lblDescripcion.setText(oArticulo.Descripcion);
                    Sesion.set(Campo.VinActual, oVin);
                    Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.VIN);
                    mVista.setFocus();
                }
			}

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}*/
	}

    private void obtenerDetallesVin()throws Exception
    {
        Articulo oArticulo = Consultas.ConsultasArticulo.obtenerVinPorId(oVin.ArticuloId);
        lblDescripcion.setText(oArticulo.Descripcion);
        txtKilometraje.setText(oVin.Kilometraje.toString());
        Sesion.set(Campo.VinActual, oVin);
        Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.VIN);
        mVista.setFocus();
    }

	public boolean validarCaptura()
	{
		if (oVin == null)
		{
			mVista.mostrarError("El campo Vin es requerido");
            txtScannerVin.requestFocus();
			return false;
		}
        if (txtKilometraje.getText().toString().equals("")){
            mVista.mostrarError("El campo Kilometraje es requerido");
            txtKilometraje.requestFocus();
            return false;
        }
        if (Float.valueOf(txtKilometraje.getText().toString()) < oVin.Kilometraje)
        {
            mVista.mostrarError("El kilometraje debe ser mayor o igual a " + oVin.Kilometraje.toString());
            txtKilometraje.setText(oVin.Kilometraje.toString());
            txtKilometraje.requestFocus();
            return false;
        }

        Sesion.set(Campo.Kilometraje, Float.valueOf(txtKilometraje.getText().toString()));

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
	public interface onVinNoEncontradoListener
	{
		void onVinNoEncontrado();
	}

	private onVinNoEncontradoListener buscarListener = null;

	public void setOnVinNoEncontradoListener(onVinNoEncontradoListener l)
	{
		buscarListener = l;
	}

}
