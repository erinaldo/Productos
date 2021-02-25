package com.amesol.routelite.vistas;

import android.app.ActionBar;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.SearchManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.Window;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
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
import com.amesol.routelite.presentadores.interfaces.ICapturaGastos;
import com.amesol.routelite.presentadores.interfaces.ICapturaInicioFinJornada;
import com.amesol.routelite.utilerias.Generales;

import java.util.Date;
import java.util.HashMap;

public class CapturaInicioFinJornada extends Vista implements ICapturaInicioFinJornada
{
    private String sDiaClave;
    private ListView lstUsuariosTrip;
    private Dialog dialogRegistrarTripulacion;
    private View dialogViewRegistrarTripulacion;
    private EditText txtUsuarioBusqueda;
    private Button btCancelarBusquedaUsuario=null;
    private Spinner spTiposRol=null;
	private CapturarInicioFinJornada mPresenta;
	private String mAccion;
	private boolean huboCambios = false;
    private int posSelectTripulacion = 0;
    private String TripIdEliminacion = "";
    private OnCodigoIngresadoListener mValidar = new OnCodigoIngresadoListener() {
        public void OnCodigoIngresado(String Codigo, int codigoLeido) {
            try{
                huboCambios = true;

                String codigo = Codigo.trim();

                registrarInicioFinJornada(codigo);
            }catch(Exception ex){
                if (ex.getMessage()!= null) {
                    BDVend.setOrigenLog("CapturaInicioFinJornada:Error " + ex.getMessage());
                    mostrarError(ex.getMessage());
                }
            }
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
                sDiaClave=mPresenta.getFechaInicialJornada(mVendedor);
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

            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ConfirmarDevAlmacen")){
                try{
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ConfirmarDevAlmacen").equals("1")) {
                        if (Consultas.ConsultaRegistroInicioFin.validarMovimientosPendientes("4")){
                            mensajeTerminarMovimiento("Devolución al Almacén");
                        }
                    }
                }catch(Exception ex){
                }
            }

            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ConfirmarDescarga")){
                try{
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ConfirmarDescarga").equals("1")) {
                        if (Consultas.ConsultaRegistroInicioFin.validarMovimientosPendientes("7")){
                            mensajeTerminarMovimiento("Descarga al Almacén");
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

            try {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarInvFinJornada") && (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarInvFinJornada").toString().equals("1"))){
                    String ProductosFaltantes = Consultas.ConsultaRegistroInicioFin.obtenerDiferenciasInventario();
                    if (!ProductosFaltantes.equals("")){
                        mensajeTerminar(Mensajes.get("I0355").replace("$0$",ProductosFaltantes));
                    }
                }
            } catch (Exception e) {
            }

            if (oMotConf.get("RegistrarTripulacion").equals("1")) {
                try{
                    LayoutInflater inflater = (LayoutInflater) CapturaInicioFinJornada.this
                            .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                    dialogViewRegistrarTripulacion = inflater.inflate(R.layout.dialog_registro_tripulacion, null);

                    AlertDialog.Builder builder = new AlertDialog.Builder(CapturaInicioFinJornada.this);
                    builder.setTitle(Mensajes.get("XRegistrarTripulacion"));

                    builder.setCancelable(false);
                    TextView mTexto;
                    mTexto = (TextView) dialogViewRegistrarTripulacion.findViewById(R.id.lblRol);
                    mTexto.setText(Mensajes.get("XRol"));

                    spTiposRol = (Spinner) dialogViewRegistrarTripulacion.findViewById(R.id.spTipoRol);
                    cargarTipoRol();

                    mTexto = (TextView) dialogViewRegistrarTripulacion.findViewById(R.id.lblUsuario);
                    mTexto.setText(Mensajes.get("XUsuario"));

                    txtUsuarioBusqueda =(EditText) dialogViewRegistrarTripulacion.findViewById(R.id.txtUsuario);

                    ImageButton btnBuscarUsuario = (ImageButton) dialogViewRegistrarTripulacion.findViewById(R.id.btnBuscarUsuario);
                    btnBuscarUsuario.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            try{
                                txtUsuarioBusqueda.setEnabled(true);

                                LayoutInflater inflater = (LayoutInflater) CapturaInicioFinJornada.this
                                        .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

                                View dialogViewUsuarios = inflater.inflate(R.layout.dialog_usuarios, null);

                                AlertDialog.Builder builder = new AlertDialog.Builder(CapturaInicioFinJornada.this);
                                builder.setTitle(Mensajes.get("XBuscar").replace("$0$",Mensajes.get("XUsuario")));

                                TextView mTexto;
                                mTexto = (TextView) dialogViewUsuarios.findViewById(R.id.txtCol1);
                                mTexto.setVisibility(View.GONE);

                                mTexto = (TextView) dialogViewUsuarios.findViewById(R.id.txtCol2);
                                mTexto.setVisibility(View.VISIBLE);
                                mTexto.setText(Mensajes.get("XClave"));
                                mTexto.setGravity(Gravity.CENTER);

                                mTexto = (TextView) dialogViewUsuarios.findViewById(R.id.txtCol3);
                                mTexto.setVisibility(View.VISIBLE);
                                mTexto.setText(Mensajes.get("XNombre"));
                                mTexto.setGravity(Gravity.CENTER);

                                ListView lstUsuarios = (ListView) dialogViewUsuarios.findViewById(R.id.lstUsuarios);
                                ISetDatos isUsuarios = Consultas.ConsultaRegistroInicioFin.obtenerUsuarios();
                                Cursor cUsuarios = (Cursor) isUsuarios.getOriginal();
                                startManagingCursor(cUsuarios);
                                SimpleCursorAdapter adapter = new SimpleCursorAdapter(getApplicationContext(), R.layout.lista_usuario_trip, cUsuarios, new String[] {"_id", "Clave", "Nombre" }, new int[] { R.id.txtCol1, R.id.txtCol2, R.id.txtCol3 });
                                lstUsuarios.setAdapter(adapter);
                                adapter.setViewBinder(new vistaUsuarios());
                                lstUsuarios.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                                        String sClaveUsuario;
                                        Cursor cUsuario = (Cursor) parent.getItemAtPosition(position);
                                        cUsuario.moveToPosition(position);
                                        sClaveUsuario = cUsuario.getString(1);

                                        txtUsuarioBusqueda.setText(sClaveUsuario);
                                        btCancelarBusquedaUsuario.performClick();
                                    }
                                });

                                builder.setNegativeButton(Mensajes.get("XCancelar"),new DialogInterface.OnClickListener()
                                {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which)
                                    {

                                        dialog.dismiss();
                                    }

                                });
                                builder.setView(dialogViewUsuarios);

                                final Dialog dialog = builder.create();
                                dialog.setCanceledOnTouchOutside(false);
                                dialog.setOnShowListener(new DialogInterface.OnShowListener() {
                                    @Override
                                    public void onShow(DialogInterface dialog) {
                                        btCancelarBusquedaUsuario = ((AlertDialog) dialog)
                                                .getButton(AlertDialog.BUTTON_NEGATIVE);
                                    }
                                });

                                dialog.show();
                            }catch (Exception ex){
                                ex.printStackTrace();
                            }
                        }
                    });

                    ImageButton btnAgregar = (ImageButton) dialogViewRegistrarTripulacion.findViewById(R.id.btnAgregar);
                    btnAgregar.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            try{
                                if (!txtUsuarioBusqueda.getText().toString().trim().equals("")){
                                    String sUSUId= Consultas.ConsultaRegistroInicioFin.obtenerUsuarioId(txtUsuarioBusqueda.getText().toString());
                                    if(sUSUId.equals("")){
                                        mostrarAdvertencia(Mensajes.get("MDB050601"));
                                        txtUsuarioBusqueda.selectAll();
                                    }else{
                                        if(Consultas.ConsultaRegistroInicioFin.ExisteRegTripulacionUsuario(txtUsuarioBusqueda.getText().toString().trim(), sDiaClave)){
                                            mPresenta.eliminarTripulacion(txtUsuarioBusqueda.getText().toString().trim(), sDiaClave);
                                            mPresenta.registrarTripulacion(getspTipoRol(),txtUsuarioBusqueda.getText().toString());
                                            LlenaUsuariosTripulacion();
                                            txtUsuarioBusqueda.setText("");
                                        }else{
                                            mPresenta.registrarTripulacion(getspTipoRol(),txtUsuarioBusqueda.getText().toString());
                                            LlenaUsuariosTripulacion();
                                            txtUsuarioBusqueda.setText("");
                                        }
                                        txtUsuarioBusqueda.setEnabled(true);
                                    }
                                }else if (!txtUsuarioBusqueda.hasSelection()){
                                    mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Usuario"));
                                }
                            }catch (Exception ex){
                                ex.printStackTrace();
                            }
                        }
                    });

                    mTexto = (TextView) dialogViewRegistrarTripulacion.findViewById(R.id.txtCol1);
                    mTexto.setVisibility(View.GONE);

                    mTexto = (TextView) dialogViewRegistrarTripulacion.findViewById(R.id.txtCol2);
                    mTexto.setVisibility(View.VISIBLE);
                    mTexto.setText(Mensajes.get("XRol"));
                    mTexto.setGravity(Gravity.CENTER);

                    mTexto = (TextView) dialogViewRegistrarTripulacion.findViewById(R.id.txtCol3);
                    mTexto.setVisibility(View.VISIBLE);
                    mTexto.setText(Mensajes.get("XUsuario"));
                    mTexto.setGravity(Gravity.CENTER);

                    Button btnContinuar = (Button) dialogViewRegistrarTripulacion.findViewById(R.id.btnContinuar);
                    btnContinuar.setText(Mensajes.get("XContinuar"));
                    btnContinuar.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            try{
                                txtUsuarioBusqueda.setEnabled(true);
                                if (Consultas.ConsultaRegistroInicioFin.HayRegistroTripulacion() == 0){
                                    mostrarAdvertencia(Mensajes.get("E0867").replace("$0$","usuario a la tripulación"));
                                }else{
                                    dialogRegistrarTripulacion.dismiss();
                                }
                            }catch (Exception ex){
                                ex.printStackTrace();
                            }
                        }
                    });

                    LlenaUsuariosTripulacion();



                    builder.setView(dialogViewRegistrarTripulacion);

                    dialogRegistrarTripulacion = builder.create();
                    dialogRegistrarTripulacion.setCanceledOnTouchOutside(false);
                    dialogRegistrarTripulacion.setOnShowListener(new DialogInterface.OnShowListener() {
                        @Override
                        public void onShow(DialogInterface dialog) {
                        }
                    });

                    dialogRegistrarTripulacion.setOnKeyListener(new Dialog.OnKeyListener() {
                        @Override
                        public boolean onKey(DialogInterface arg0, int keyCode, KeyEvent event) {
                            if (keyCode == KeyEvent.KEYCODE_BACK) {
                                return true;
                            }else if(keyCode == KeyEvent.KEYCODE_ENTER){
                                try{
                                    if (!txtUsuarioBusqueda.getText().toString().trim().equals("") & !txtUsuarioBusqueda.hasSelection()){
                                        String sUSUId= Consultas.ConsultaRegistroInicioFin.obtenerUsuarioId(txtUsuarioBusqueda.getText().toString());
                                        if(sUSUId.equals("")){
                                            mostrarAdvertencia(Mensajes.get("MDB050601"));
                                            txtUsuarioBusqueda.selectAll();
                                            return true;
                                        }else{
                                            if(Consultas.ConsultaRegistroInicioFin.ExisteRegTripulacionUsuario(txtUsuarioBusqueda.getText().toString().trim(), sDiaClave)){
                                                mPresenta.eliminarTripulacion(txtUsuarioBusqueda.getText().toString().trim(), sDiaClave);
                                                mPresenta.registrarTripulacion(getspTipoRol(),txtUsuarioBusqueda.getText().toString());
                                                LlenaUsuariosTripulacion();
                                                txtUsuarioBusqueda.setText("");
                                                return true;
                                            }else{
                                                mPresenta.registrarTripulacion(getspTipoRol(),txtUsuarioBusqueda.getText().toString());
                                                LlenaUsuariosTripulacion();
                                                txtUsuarioBusqueda.setText("");
                                                return true;
                                            }
                                        }
                                    }else{
                                        return true;
                                    }
                                }catch (Exception ex){
                                    ex.printStackTrace();
                                    return true;
                                }
                            }
                            return false;
                        }
                    });

                    dialogRegistrarTripulacion.show();
                }catch (Exception ex){
                    ex.printStackTrace();
                }
            }
        }
	}



    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo)
    {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_tripulacion, menu);

        posSelectTripulacion = ((AdapterView.AdapterContextMenuInfo) menuInfo).position;

        menu.getItem(0).setTitle(Mensajes.get("BTEliminar"));

        menu.getItem(0).setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener()
        {
            public boolean onMenuItemClick(MenuItem clickedItem)
            {
                try {
                    Cursor cUsuario = (Cursor) lstUsuariosTrip.getItemAtPosition(posSelectTripulacion);
                    cUsuario.moveToPosition(posSelectTripulacion);
                    TripIdEliminacion = cUsuario.getString(cUsuario.getColumnIndex("TripId"));
                    Integer iTipoTripulacion = cUsuario.getInt(cUsuario.getColumnIndex("TipoTripulacion"));
                    String sClaveUsuario = cUsuario.getString(cUsuario.getColumnIndex("USUId"));
                    sClaveUsuario = Consultas.ConsultaRegistroInicioFin.obtenerUsuario(sClaveUsuario);
                    mostrarPreguntaSiNo(Mensajes.get("P0001") + " Usuario:" + sClaveUsuario + " - " + ValoresReferencia.getDescripcion("TIPOTRI", String.valueOf(iTipoTripulacion)), 10);
                }catch (Exception ex){
                    if (ex != null && ex.getMessage() != null) {
                        mostrarError(ex.getMessage());
                    }else{
                        mostrarError("Error al eliminar Tripulación ");
                    }
                }
                return true;
            }
        });
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
        }else if(tipoMensaje == 10){
            if (respuesta == RespuestaMsg.Si) {
                mPresenta.eliminarTripulacion(TripIdEliminacion);
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

    public void mensajeTerminarMovimiento(String movimiento)
    {
        AlertDialog.Builder dialog = new AlertDialog.Builder(this);

        dialog.setMessage(Mensajes.get("E1015").replace("$0$", movimiento));
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

        Button boton = (Button) findViewById(R.id.btnContinuar);
        boton.setText(Mensajes.get("XContinuar"));
        boton.setOnClickListener(mContinuar);
        boton.setEnabled(false);

        if (codigo.equals("")) {
            mostrarAdvertencia(Mensajes.get("BE0001").replace("$0$", "Código Barras CEDI"));
            boton.setEnabled(true);
            return;
        }

        if (!codigo.equals(((Vendedor) Sesion.get(Campo.VendedorActual)).CodigoBarras)) {
            mostrarAdvertencia(Mensajes.get("E0489").replace("$0$", Mensajes.get("XCentrodistribucion")));
            txtScanner.setTexto("");
            txtScanner.requestFocus();
            boton.setEnabled(true);
            return;
        }

        if (finJornada) {

            if (mPresenta.validaVentaSinSurtir() && mPresenta.validaDiferenciaInventario()) {
                mPresenta.registrarValores();
                finalizar();
            }
        } else {
            mPresenta.registrarValores();
            finalizar();
        }
    }

    private void cargarTipoRol() {
        try {
            if (lstUsuariosTrip == null) {
                lstUsuariosTrip = (ListView) dialogViewRegistrarTripulacion.findViewById(R.id.lstUsuariosTripulacion);
            }
            String excepciones = "";
            if (lstUsuariosTrip.getAdapter() != null){
                Cursor usuariosTrip = ((Cursor)((SimpleCursorAdapter)lstUsuariosTrip.getAdapter()).getCursor());
                usuariosTrip.moveToFirst();
                for(usuariosTrip.moveToFirst(); !usuariosTrip.isAfterLast(); usuariosTrip.moveToNext()){
                    excepciones += usuariosTrip.getString(usuariosTrip.getColumnIndex("TipoTripulacion")) + ",";
                }
                if (excepciones.length()>0){
                    excepciones = excepciones.substring(0, excepciones.length()-1);
                }
            }
            ISetDatos TiposRol= Consultas.ConsultasValorReferencia.obtenerValoresExcepcion("TIPOTRI", excepciones);
            if (spTiposRol.getAdapter()!= null){
                spTiposRol.setAdapter(null);
            }
            startManagingCursor((Cursor) TiposRol.getOriginal());
            SimpleCursorAdapter adapterTRol = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, (Cursor) TiposRol.getOriginal(), new String[]
                    {"Descripcion"}, new int[]
                    {android.R.id.text1});
            adapterTRol.setDropDownViewResource(android.R.layout.simple_spinner_item);
            spTiposRol.setAdapter(adapterTRol);

        }catch (Exception ex){
            ex.printStackTrace();
        }
    }

    private class vistaUsuariosTripulacion implements SimpleCursorAdapter.ViewBinder {
        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex){

            int viewId = view.getId();
            TextView texto;
            switch (viewId){
                case R.id.txtCol1:
                    texto = (TextView) view;
                    texto.setVisibility(View.GONE);
                    try{
                        texto.setText(Consultas.ConsultaRegistroInicioFin.obtenerClaveUsuario(cursor.getString(columnIndex)));
                    }catch(Exception ex){
                        ex.printStackTrace();
                    }
                    break;
                case R.id.txtCol2:
                    texto = (TextView) view;
                    texto.setText(ValoresReferencia.getDescripcion("TIPOTRI",cursor.getString(columnIndex)));
                    break;
                case R.id.txtCol3:
                    texto = (TextView) view;
                    try{
                        texto.setText(Consultas.ConsultaRegistroInicioFin.obtenerUsuario(cursor.getString(columnIndex)));
                    }catch(Exception ex){
                        ex.printStackTrace();
                    }
                    break;
                default:
                    texto = (TextView) view;
                    texto.setText(cursor.getString(columnIndex));
                    break;
            }
            return true;
        }
    }

    private class vistaUsuarios implements SimpleCursorAdapter.ViewBinder {
        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex){

            int viewId = view.getId();
            TextView texto;
            switch (viewId){
                case R.id.txtCol1:
                    texto = (TextView) view;
                    texto.setVisibility(View.GONE);
                    texto.setText(cursor.getString(columnIndex));

                    break;
                default:
                    texto = (TextView) view;
                    texto.setText(cursor.getString(columnIndex));
                    break;
            }
            return true;
        }
    }

    public short getspTipoRol() {
        Spinner spin = (Spinner) dialogViewRegistrarTripulacion.findViewById(R.id.spTipoRol);
        return (short) spin.getSelectedItemId();
    }

    public void LlenaUsuariosTripulacion(){
        try{
            lstUsuariosTrip = (ListView) dialogViewRegistrarTripulacion.findViewById(R.id.lstUsuariosTripulacion);
            ISetDatos isUsuarioTrip = Consultas.ConsultaRegistroInicioFin.obtenerUsuariosTripulacion();
            Cursor cUsuariosTrip = (Cursor) isUsuarioTrip.getOriginal();
            startManagingCursor(cUsuariosTrip);
            SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_usuario_trip, cUsuariosTrip, new String[] { "_id", "TipoTripulacion", "USUId", "TripId" }, new int[] { R.id.txtCol1, R.id.txtCol2, R.id.txtCol3 });
            adapter.setViewBinder(new vistaUsuariosTripulacion());
            lstUsuariosTrip.setAdapter(adapter);
            registerForContextMenu(lstUsuariosTrip);
            cargarTipoRol();
        }catch (Exception ex){
            ex.printStackTrace();
        }

    }
}
