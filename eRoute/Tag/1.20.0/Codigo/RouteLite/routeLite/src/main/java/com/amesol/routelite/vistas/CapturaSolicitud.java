package com.amesol.routelite.vistas;

import android.app.SearchManager;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.CapturarSolicitud;
import com.amesol.routelite.presentadores.interfaces.ICapturaSolicitud;
import com.amesol.routelite.utilerias.Generales;

import org.w3c.dom.Text;

import java.util.HashMap;
import java.util.LinkedList;

/**
 * Created by Adriana on 27/12/2016.
 */
public class CapturaSolicitud extends Vista implements ICapturaSolicitud {

    CapturarSolicitud mPresenta;
    String mAccion;
    Cliente oCliente;
    Vendedor oVendedor;
    private boolean huboCambios = false;
    HashMap<String, String> oParametros = null;
    private boolean bEsNuevo = true;

    private EditText txtFolio;
    private Spinner cmbPeticion;
    private Spinner cmbArea;
    private EditText txtConcepto;
    private EditText txtComentario;

    short nPeticionIni;
    short nAreaIni;
    String sConceptoIni;
    String sComentarioIni;

    @SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.captura_solicitud);
            deshabilitarBarra(true);
            setTitulo(Mensajes.get("XSolicitudes"));

            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText(Mensajes.get("XContinuar"));
            btn.setOnClickListener(mContinuar);

            TextView mTexto;
            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);
            oCliente = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);
            mTexto.setVisibility(View.VISIBLE);
            mTexto.setText(oCliente.Clave + " - " + oCliente.RazonSocial);

            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);

            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            mTexto = (TextView) findViewById(R.id.lblFolio);
            mTexto.setText(Mensajes.get("XFolio"));
            txtFolio = (EditText) findViewById(R.id.txtFolio);
            txtFolio.setEnabled(false);

            mTexto = (TextView) findViewById(R.id.lblTipoPeticion);
            mTexto.setText(Mensajes.get("XPeticion"));
            cmbPeticion = (Spinner) findViewById(R.id.cboTipoPeticion);

            mTexto = (TextView) findViewById(R.id.lblTipoArea);
            mTexto.setText(Mensajes.get("XArea"));
            cmbArea = (Spinner) findViewById(R.id.cboTipoArea);

            mTexto = (TextView) findViewById(R.id.lblConcepto);
            mTexto.setText(Mensajes.get("XConcepto"));
            txtConcepto = (EditText) findViewById(R.id.txtConcepto);

            mTexto = (TextView) findViewById(R.id.lblComentario);
            mTexto.setText(Mensajes.get("XComentario"));
            txtComentario = (EditText) findViewById(R.id.txtComentario);

            oVendedor = (Vendedor) Sesion.get(Sesion.Campo.VendedorActual);

            mPresenta = new CapturarSolicitud(this, mAccion);
            if (getIntent().getSerializableExtra("parametros") != null) {
                oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
            }

            if (oParametros != null && (!oParametros.get("SOLId").trim().equals(""))) {
                bEsNuevo = false;
                mPresenta.setSOLId(oParametros.get("SOLId").trim());
            }

            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public void iniciar() {
        nPeticionIni = getTipoPeticion();
        nAreaIni = getTipoArea();
        sConceptoIni = getConcepto();
        sComentarioIni = getComentario();
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 3) {
            if (respuesta == Enumeradores.RespuestaMsg.Si) {
                regresar();
            }
        }
    }

    private void regresar() {
        try {

            if (huboCambios)
                BDVend.rollback();

            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        } catch (Exception ex) {
            mostrarError(ex.getMessage());
        }
    }

    private void validarCambios(){
        if( (getTipoPeticion() != nPeticionIni)
                || (getTipoArea() != nAreaIni)
                || (!getConcepto().equals(sConceptoIni))
                || (!getComentario().equals(sComentarioIni)))
            huboCambios = true;
        else
            huboCambios = false;
    }

    private void salir() {

        if (huboCambios)
            mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
        else {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }

    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                validarCambios();
                salir();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    @Override
    public void setFolio(String sFolio) {
        txtFolio.setText(sFolio);
    }

    @Override
    public void setTipoPeticion(short nTipoPeticion){
        //Generales.SelectSpinnerItemByValue( cmbPeticion, nTipoPeticion );

        for (int i = 0; i < cmbPeticion.getCount(); i++)
        {
            if (String.valueOf(nTipoPeticion).equals (((CapturarSolicitud.VistaSpinner) cmbPeticion.getItemAtPosition(i)).getId()))
            {
                cmbPeticion.setSelection(i);
                break;
            }
        }
    }

    @Override
    public void setTipoArea(short nTipoArea){
        //Generales.SelectSpinnerItemByValue( cmbArea, nTipoArea);
        for (int i = 0; i < cmbArea.getCount(); i++)
        {
            if (String.valueOf(nTipoArea).equals (((CapturarSolicitud.VistaSpinner) cmbArea.getItemAtPosition(i)).getId()))
            {
                cmbArea.setSelection(i);
                break;
            }
        }
    }

    @Override
    public void setConcepto(String sConcepto){ txtConcepto.setText(sConcepto); }

    @Override
    public void setComentario(String sComentario){ txtComentario.setText(sComentario); }

    @Override
    public void setTiposPeticion(LinkedList<CapturarSolicitud.VistaSpinner> oValores) {
        poblarSpinner((Spinner) findViewById(R.id.cboTipoPeticion), oValores);
    }

    @Override
    public void setTiposArea(LinkedList<CapturarSolicitud.VistaSpinner> oValores) {
        poblarSpinner((Spinner) findViewById(R.id.cboTipoArea), oValores);
    }

    @Override
    public boolean getEsNuevo() {
        return bEsNuevo;
    }

    @Override
    public String getFolio(){
        return txtFolio.getText().toString();
    }

    @Override
    public short getTipoPeticion(){
        return Short.valueOf (((CapturarSolicitud.VistaSpinner) cmbPeticion.getItemAtPosition(cmbPeticion.getSelectedItemPosition())).getId());
    }

    @Override
    public short getTipoArea(){
        return Short.valueOf (((CapturarSolicitud.VistaSpinner) cmbArea.getItemAtPosition(cmbArea.getSelectedItemPosition())).getId());
    }

    @Override
    public String getConcepto(){
        return txtConcepto.getText().toString();
    }

    @Override
    public String getComentario(){
        return txtComentario.getText().toString();
    }

    private void poblarSpinner(Spinner control, LinkedList<CapturarSolicitud.VistaSpinner> oValores)
    {
        ArrayAdapter<CapturarSolicitud.VistaSpinner> adapter = new ArrayAdapter<CapturarSolicitud.VistaSpinner>(this, android.R.layout.simple_spinner_item, oValores);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
        control.setAdapter(adapter);
    }


    private View.OnClickListener mContinuar = new View.OnClickListener() {

        @Override
        public void onClick(View v) {
            Button boton = (Button) findViewById(R.id.btnContinuar);
            huboCambios = true;
            try {
                if (txtFolio.getText().toString().equals("")) {
                    mostrarError(Mensajes.get("BE0001").replace("$0$", "Folio"));
                    return;
                }
                if (cmbPeticion.getSelectedItem() == null){
                    mostrarError(Mensajes.get("BE0001").replace("$0$", "Peticion"));
                    return;
                }
                if (cmbArea.getSelectedItem() == null){
                    mostrarError(Mensajes.get("BE0001").replace("$0$", "Área"));
                    return;
                }
                if (txtConcepto.getText().toString().equals("")) {
                    mostrarError(Mensajes.get("BE0001").replace("$0$", "Concepto"));
                    return;
                }

                mPresenta.guardar();
            } catch (Exception ex) {
                mostrarError(ex.getMessage());
                boton.setEnabled(true);
            }
        }

    };
}
