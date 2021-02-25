package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.content.DialogInterface;
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
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
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
    private OnCodigoIngresadoListener mValidar = new OnCodigoIngresadoListener() {
        public void OnCodigoIngresado(String Codigo, int codigoLeido) {
            huboCambios = true;

            String codigo = Codigo.trim();

            registrarInicioFinJornada(codigo);

        }
    };
    private boolean finJornada = false;
    private StringBuilder sDiaClaveJornada = new StringBuilder("");
    private OnClickListener mContinuar = new OnClickListener() {

        @Override
        public void onClick(View v) {
            registrarInicioFinJornada(txtScanner.getTexto());
        }

    };

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.captura_iniciofinjornada);

        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        mPresenta = new CapturarInicioFinJornada(this, mAccion);
        mPresenta.iniciar();

        Usuario mUsuario = new Usuario();
        Vendedor mVendedor;
        try {
            ConfiguracionLocal confLocal = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
            mUsuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(confLocal.get(ArchivoConfiguracion.CampoConfiguracion.USUARIO).toString());

            mVendedor = Consultas.ConsultasVendedor.obtenerVendedorPorUsuario(mUsuario);

            TextView mFecha = (TextView) findViewById(R.id.lblFechaHoraInicio);

            lblTitle.setText(Mensajes.get("VENJornadaTrabajo"));

            mAccion = getIntent().getAction();
            if (!Consultas.ConsultaRegistroInicioFin.obtenerVendedorJornada(mVendedor.VendedorId, sDiaClaveJornada)) {
                //lblTitle.setText("Registrar Inicio de Jornada");
                mFecha.setText("");
                txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScannerInicio);
                txtScanner.setOnCodigoIngresado(mValidar);
                txtScanner.requestFocus();

                deshabilitarFin();
            } else {
                //lblTitle.setText("Registrar Fin de Jornada");
                finJornada = true;
                mFecha.setText(mPresenta.getFechaInicial(mVendedor));
                txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScannerFin);
                txtScanner.setOnCodigoIngresado(mValidar);
                deshabilitarInicio();
            }
        } catch (Exception e) {
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

        if (mPresenta.getJornadaFinalizada()) {
            deshabilitarInicio();
            deshabilitarFin();
            boton.setEnabled(false);
        }

        if (finJornada == true) {
            MOTConfiguracion oMotConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
            if (oMotConf.get("ForzarCapturaImpro").equals("1")) {
                if (sDiaClaveJornada.length() > 0) {
                    if (!mPresenta.validaImproductividad(sDiaClaveJornada.toString())) {
                        mensajeTerminar();
                    }
                }
            }

            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarAbnVinDep")){
                try{
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ValidarAbnVinDep").equals("1")) {
                        if (!Consultas.ConsultaRegistroInicioFin.ValidarAbonosVinculados()){
                            mensajeTerminar("I0312");
                        }
                    }
                }catch(Exception ex){
                }
            }

            if (Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("ValidaInv").toString()) == 1 && Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("Inventario").toString()) == 0)
                try{
                    if (Consultas.ConsultaRegistroInicioFin.UltimoDiaDeTrabajo()) {
                        if (Consultas.ConsultaRegistroInicioFin.ValidarInventarioABordo()) {
                            mensajeTerminar("E0686");
                        }
                    }
                }catch(Exception ex){
                }

            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ValidaInvNoDisp", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString())){
                try{
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ValidaInvNoDisp", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).equals("1")){
                        if (Consultas.ConsultaRegistroInicioFin.ValidarInventarioABordoNosDisp()) {
                            mensajeTerminar("E0971");
                        }
                    }
                }catch(Exception ex){
                }
            }
        }
	}

    private void deshabilitarInicio() {
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
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                salir();
                return true;
        }
        return super.onKeyDown(keyCode, event);
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

	private void salir() {

        if (huboCambios)
            mostrarPreguntaSiNo(Mensajes.get("BP0002"), 3);
        else {
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }

	}

	@Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {

	}

    @Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {

        if (tipoMensaje == 3) {
            if (respuesta == RespuestaMsg.Si) {
                regresar();
            }
        }

    }

    @Override
    public void iniciar() {

    }

    public void mensajeTerminar()
	{
		AlertDialog.Builder dialog = new AlertDialog.Builder(this);

		dialog.setMessage(Mensajes.get("I0270"));
		dialog.setCancelable(false);
		dialog.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener()
		{

			@Override
			public void onClick(DialogInterface dialog, int which)
			{
				
				
				CapturaInicioFinJornada.this.finish();
				dialog.cancel();
			}
		});
		dialog.show();
	}

    public void mensajeTerminar(String MenClave){
        AlertDialog.Builder dialog = new AlertDialog.Builder(this);

        dialog.setMessage(Mensajes.get(MenClave));
        dialog.setCancelable(false);
        dialog.setPositiveButton(Mensajes.get("XAceptar"), new DialogInterface.OnClickListener(){

            @Override
            public void onClick(DialogInterface dialog, int which){
                CapturaInicioFinJornada.this.finish();
                dialog.cancel();
            }
        });
        dialog.show();
    }

    public void registrarInicioFinJornada(String codigo) {
        if (codigo.equals("")) {
            mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Código Barras CEDI"));
            return;
        }

        if (!codigo.equals(((Vendedor) Sesion.get(Campo.VendedorActual)).CodigoBarras)) {
            mostrarAdvertencia(Mensajes.get("E0489").replace("$0$", Mensajes.get("XCentrodistribucion")));
            txtScanner.setTexto("");
            txtScanner.requestFocus();
            return;
        }

        if (finJornada) {

            if (mPresenta.validaVentaSinSurtir()) {
                mPresenta.registrarValores();
                finalizar();

            }
        } else {
            mPresenta.registrarValores();
            finalizar();
        }
    }

}
