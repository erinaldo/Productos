package com.duxstar.dacza.vistas;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.Fragment;
import android.app.SearchManager;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.InputType;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnKeyListener;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.actividades.ValoresReferencia;
import com.duxstar.dacza.datos.Cliente;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.act.BuscarCliente;
import com.duxstar.dacza.presentadores.interfaces.IBuscaCliente;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;

public class BuscaCliente extends Vista implements IBuscaCliente
{

	private BuscarCliente mPresenta;
	private String mAccion;
    String sClienteId;

    private AdapterView.OnItemClickListener mSeleccion = new AdapterView.OnItemClickListener() {

        public void onItemClick(AdapterView<?> parent, View v, int position, long id) {

            //HabilitarPantalla(false);
            Cursor cliente = (Cursor) parent.getItemAtPosition(position);
            cliente.moveToPosition(position);
            sClienteId = cliente.getString(1);

            mPresenta.seleccionar();
            //HabilitarPantalla(true);
        }
    };

    int tipoVista;
    boolean iniciarActividad;
    Class<?> actvdd;
    Boolean optionsFlag = false;
    Boolean optionPlusFlag = false;
    boolean enviando = false;
    boolean actualizandoInventario = false;
    boolean actualizandoConfirmacionPedidos = false;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.buscar_cliente);
        //String accion = getIntent().getAction();
        deshabilitarBarra(true);

        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        lblTitle.setText("Seleccionar Cliente");

        Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.CLIENTE);

        String filtroOrig = null;
        if (getIntent().getSerializableExtra("parametros") != null)
        {
            HashMap<String, Object> oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
            if (oParametros.get("Cadena") != null) {
                filtroOrig = oParametros.get("Cadena").toString();
                Sesion.set(Campo.FiltroCliente, filtroOrig);
            }
        }
        else
        {
            if (Sesion.get(Campo.FiltroCliente) != null)
                Sesion.remove(Campo.FiltroCliente);
        }

        // Get the intent, verify the action and get the query
        Intent intent = getIntent();
        mAccion = intent.getAction();

        String filtro = null;
        if (intent.getAction() != null && Intent.ACTION_SEARCH.equals(intent.getAction())) {
            filtro = intent.getStringExtra(SearchManager.USER_QUERY);
            mPresenta = new BuscarCliente(this, Intent.ACTION_SEARCH, filtroOrig, filtro);
        } else {
            mPresenta = new BuscarCliente(this, mAccion, filtroOrig, null);
        }

        //mPresenta = new ConfigurarTerminal(this, accion);

        ListView lista_1 = (ListView) findViewById(R.id.lstClientes);
        registerForContextMenu(lista_1);

        HabilitarPantalla(true);

        iniciarActividad = false;
        mPresenta.iniciar();
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        super.onActivityResult(requestCode, resultCode, data);
    }

    public void habilitaDeshabilitaCodigoBarras(boolean habilitado) {
        //txtScanner.setEnabled(habilitado);
    }

    public void iniciar() {

    }

    public void reiniciarPantalla() {
    }

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        return;
    }

    @Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                //mPresenta.toActividadesVed();
                this.finish();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        try {
            menu.add(0, 1, 1, "Buscar");

        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case Enumeradores.ACTBUSQ.BUSCAR:
                startSearch(null, false, null, false);
                // onSearchRequested();
                return true;
            default:
                optionPlusFlag = true;
                return super.onOptionsItemSelected(item);
        }
    }

    @Override
    public void onNewIntent(final Intent newIntent) {
        super.onNewIntent(newIntent);

        final String queryAction = newIntent.getAction();
        if (Intent.ACTION_SEARCH.equals(queryAction)) {
            //String sFiltro = newIntent.getStringExtra(SearchManager.QUERY);
            //mPresenta.mostrarClientes(sFiltro);
            if (newIntent.getData() != null) {
                sClienteId = newIntent.getData().toString();
                mPresenta.seleccionar();
            } else {
                //				String s = newIntent.getStringExtra(SearchManager.QUERY);
            }
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();

        inflater.inflate(R.menu.context_consulta_clientes, menu);
        menu.getItem(0).setTitle("Consultar");
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterContextMenuInfo info = null;
        Cursor cliente = null;
        if (item.getMenuInfo() != null) {
            info = (AdapterContextMenuInfo) item.getMenuInfo();
            ListView lista_3 = (ListView) findViewById(R.id.lstClientes);
            cliente = (Cursor) lista_3.getItemAtPosition((int) info.position);
            sClienteId = cliente.getString(1);
        }

        switch (item.getItemId()) {
            case R.id.consultar:
                mPresenta.consultarCliente();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }

    }

    @SuppressWarnings("deprecation")
    public void mostrarClientes(ISetDatos clientes) {

        ListView lista_4 = (ListView) findViewById(R.id.lstClientes);

        try{
            Cursor cClientes = (Cursor) clientes.getOriginal();
            startManagingCursor(cClientes);
            SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple1, cClientes, new String[]
                    {SearchManager.SUGGEST_COLUMN_TEXT_1, SearchManager.SUGGEST_COLUMN_TEXT_2}, new int[]
                    {R.id.textoRed, R.id.texto1});
            lista_4.setAdapter(adapter);
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
        lista_4.setOnItemClickListener(mSeleccion);

    }

    public String getCliente() {
        // TODO Auto-generated method stub
        return sClienteId;
    }

    public void HabilitarPantalla(Boolean Habilitado) {
        ListView lista_5 = (ListView) findViewById(R.id.lstClientes);
        lista_5.setClickable(Habilitado);
        lista_5.setEnabled(Habilitado);
        this.doevents();

    }

    public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad) {
        iniciarActividad = true;
        actvdd = actividad;
        mostrarAdvertencia(mensaje);
    }

    //	private void ocultarTeclado()
    //	{
    //		InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
    //		TextView texto = (TextView) findViewById(R.id.txtScanner);
    //		imm.hideSoftInputFromWindow(texto.getWindowToken(), 0);
    //	}
	
}

