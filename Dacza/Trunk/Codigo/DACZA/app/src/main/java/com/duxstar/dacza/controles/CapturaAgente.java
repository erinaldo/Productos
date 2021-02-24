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
import com.duxstar.dacza.controles.AgenteTextBoxScanner.OnAgenteCodigoIngresadoListener;
import com.duxstar.dacza.controles.AgenteTextBoxScanner.OnAgenteTextChangedListener;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.interfaces.IBuscaAgente;
import com.duxstar.dacza.vistas.CapturaOrden;

public class CapturaAgente extends LinearLayout {

    // controles
    AgenteTextBoxScanner txtScannerAgente;
    ImageButton btnBuscar;
    TextView lblNombreAgente;

    // variables
    Usuario oAgente = null;
    CapturaOrden mVista = null;

    // parametros para la busquedaoParametros
    //String PCEPrecioClave = null;
    /*String CadenaListasPrecios = "";
    String TransProdIds = null;
    String moduloEsquemas = "";
	int tipoValidacionExistencia = TiposValidacionInventario.NoValidar;
	short tipoMovimiento;
	short tipoTransProd;
	//ModuloMovDetalle moduloMovDetalle = null;
	boolean mDevolucionesManuales = false;*/

    String nombreModulo = "Orden de Trabajo";
    Context context;

    boolean bClaveManual = false;
    boolean bMostrandoBusqueda = false;
    boolean bAdvertencia = false;
    String error = "";

    // ************************************************ constructores
    // ************************************************
    public CapturaAgente(Context context, AttributeSet attrs)
    {
        super(context, attrs);
        inicializar();
    }

    public CapturaAgente(Context context)
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
        li.inflate(R.layout.captura_agente, this, true);

        if (this.isInEditMode()) // para que no truene cuando se agrega al
            // layout en vista de diseño
            return;

        TextView label = (TextView) findViewById(R.id.lblAgente);
        label.setText("Agente");

        // Obtenemos las referencias a los distintos controles
        txtScannerAgente = (AgenteTextBoxScanner) findViewById(R.id.textBoxScannerAgente);
        txtScannerAgente.tipoCodigo = Enumeradores.TIPOCODIGO.AGENTE;
        txtScannerAgente.setOnAgenteCodigoIngresado(mCodigoBarrasAgente);
        txtScannerAgente.setOnAgenteTextChanged(new OnAgenteTextChangedListener() {
            @Override
            public void OnAgenteTextChanged(CharSequence s) {
                if (bClaveManual)
                    return;
                lblNombreAgente.setText("");
                oAgente = null;
            }
        });

        btnBuscar = (ImageButton) findViewById(R.id.btnBuscarAgente);
        btnBuscar.setOnClickListener(mBuscarAgente);

        lblNombreAgente = (TextView) findViewById(R.id.lblNombreAgente);

        Activity act = (Activity) li.getContext();
        mVista = (CapturaOrden) act;
    }

    public void limpiarAgente()
    {
        try
        {
            txtScannerAgente.BorrarTexto();
            lblNombreAgente.setText("");
            oAgente = null;
            txtScannerAgente.requestFocus();
        }
        catch (Exception e)
        {
            Log.e("", "" + e);

        }

    }

    public void setAgente(Usuario agente)
    {
        oAgente = agente;
    }

    public void setFocus()
    {
        txtScannerAgente.setFocusable(true);
        //txtScannerAgente.setFocusableInTouchMode(true);
        txtScannerAgente.requestFocus();
    }

    public void leaveFocus()
    {
        txtScannerAgente.clearFocus();
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
        txtScannerAgente.setEnabled(habilitar);
        btnBuscar.setEnabled(habilitar);
        txtScannerAgente.habilitarBotonScanner(habilitar);
    }

    public void onActivityResult(int requestCode, int resultCode, Intent intent)
    {
        // pasar a la vista el manejo
        mVista.resultadoActividad(requestCode, resultCode, intent);

    }

    public void setFinBusqueda()
    {
        //limpiarAgente();
        bMostrandoBusqueda = false;
    }

    private android.view.View.OnClickListener mBuscarAgente = new android.view.View.OnClickListener()
    {
        @Override
        public void onClick(View v)
        {
            buscarAgente(txtScannerAgente.getTexto(), false);
        }
    };

    private OnAgenteCodigoIngresadoListener mCodigoBarrasAgente = new OnAgenteCodigoIngresadoListener()
    {
        public void OnAgenteCodigoIngresado(String Codigo, int codigoLeido)
        {
            if (bClaveManual)
                return;
            if (Codigo.length() == 0)
                return;
            buscarAgente(Codigo, codigoLeido == 1 ? true : false);
        }
    };

    private void buscarAgente(String cadenaBusqueda, boolean codigoLeido)
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
                    buscarListener.onAgenteNoEncontrado();
                }

                bMostrandoBusqueda = true;
                mVista.iniciarActividadConResultado(IBuscaAgente.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_AGENTES, Enumeradores.Acciones.ACCION_OBTENER_AGENTE_SELECCIONADO);
            }
            else
            {
                oAgente = null;
                if (!codigoLeido)
                {
                    oAgente = Consultas.ConsultasUsuario.obtenerUsuarioIdentico(cadenaBusqueda);
                    if (oAgente == null)
                    {
                        // Buscar codigo barras
                        oAgente = Consultas.ConsultasUsuario.obtenerUsuario(cadenaBusqueda);
                        if (oAgente != null)
                        {
                            bClaveManual = true;
                            txtScannerAgente.txtScanner.setText(oAgente.Clave);
                            txtScannerAgente.requestFocus();
                            bClaveManual = false;

                            obtenerDetallesAgente();
                            mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                            return;
                        }
                        else
                        {
                            if (bMostrandoBusqueda)
                                return;
                            if (buscarListener != null)
                            {
                                buscarListener.onAgenteNoEncontrado();
                            }
                            final HashMap<String, Object> parametros = new HashMap<String, Object>();
                            parametros.put("Cadena", cadenaBusqueda);
                            bMostrandoBusqueda = true;
                            mVista.iniciarActividadConResultado(IBuscaAgente.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_AGENTES, Enumeradores.Acciones.ACCION_OBTENER_AGENTE_SELECCIONADO, parametros);
                        }
                    }
                    else
                    {
                        obtenerDetallesAgente();
                    }
                }
                else
                {
                    oAgente = Consultas.ConsultasUsuario.obtenerUsuario(cadenaBusqueda);
                    if (oAgente != null)
                    {
                        bClaveManual = true;
                        txtScannerAgente.txtScanner.setText(oAgente.Clave);
                        bClaveManual = false;

                        obtenerDetallesAgente();
                        mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
                        return;
                    }

                    Sesion.remove(Campo.AgenteActual);
                    mVista.mostrarError("El código no corresponde a un agente existente");
                    //txtScannerAgente.BorrarTexto();
                    limpiarAgente();
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
                    buscarListener.onAgenteNoEncontrado();
                }
//					final HashMap<String, Object> parametros = new HashMap<String, Object>();
//					parametros.put("Esquema", "Todos");
					bMostrandoBusqueda = true;
                    Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.AGENTE);
                    mVista.iniciarActividadConResultado(IBuscaAgente.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_AGENTES, Enumeradores.Acciones.ACCION_OBTENER_AGENTE_SELECCIONADO);
            }
            else
            {
                oAgente = null;
                if (!codigoLeido)
                    oAgente = Consultas.ConsultasUsuario.obtenerUsuarioIdentico(cadenaBusqueda);
                else
                    oAgente = Consultas.ConsultasUsuario.obtenerUsuario(cadenaBusqueda);

                if (oAgente == null)
                {
                    Sesion.remove(Campo.AgenteActual);
                    mVista.mostrarError("El Código de Barras no corresponde a un agente existente");
                    //txtScannerAgente.BorrarTexto();
                    limpiarAgente();
                }
                else
                {
                    lblNombreAgente.setText(oAgente.Nombre);
                    Sesion.set(Campo.AgenteActual, oAgente);
                    Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.AGENTE);
                    //txtScannerAgente.setFocusable(false);

                    mVista.setFocus();
                }
            }

        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }*/
    }

    private void obtenerDetallesAgente(){
        lblNombreAgente.setText(oAgente.Nombre);
        Sesion.set(Campo.AgenteActual, oAgente);
        Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.AGENTE);
    }


    public boolean validarCaptura()
    {
        if (oAgente == null)
        {
            mVista.mostrarError("El campo Agente es requerido");
            txtScannerAgente.requestFocus();
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
    public interface onAgenteNoEncontradoListener
    {
        void onAgenteNoEncontrado();
    }

    private onAgenteNoEncontradoListener buscarListener = null;

    public void setOnAgenteNoEncontradoListener(onAgenteNoEncontradoListener l)
    {
        buscarListener = l;
    }

}
