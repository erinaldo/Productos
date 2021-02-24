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
import com.duxstar.dacza.presentadores.act.BuscarAgente;
import com.duxstar.dacza.presentadores.interfaces.IBuscaAgente;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;

public class BuscaAgente extends Vista implements IBuscaAgente
{

	private BuscarAgente mPresenta;
	private String mAccion;
    String sAgenteClave;

    private AdapterView.OnItemClickListener mSeleccion = new AdapterView.OnItemClickListener() {

        public void onItemClick(AdapterView<?> parent, View v, int position, long id) {

            //HabilitarPantalla(false);
            Cursor agente = (Cursor) parent.getItemAtPosition(position);
            agente.moveToPosition(position);
            sAgenteClave = agente.getString(1);

            mPresenta.seleccionar();
            //HabilitarPantalla(true);
        }
    };

    int tipoVista;
    boolean iniciarActividad;
    Class<?> actvdd;
    Boolean optionsFlag = false;
    Boolean optionPlusFlag = false;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        setContentView(R.layout.buscar_agente);
        deshabilitarBarra(true);

        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        lblTitle.setText("Seleccionar Agente");

        Sesion.set(Campo.TipoCodigoActual, Enumeradores.TIPOCODIGO.AGENTE);

        // Get the intent, verify the action and get the query
        Intent intent = getIntent();
        mAccion = intent.getAction();

        String filtro = null;
        if (intent.getAction() != null && Intent.ACTION_SEARCH.equals(intent.getAction())) {
            filtro = intent.getStringExtra(SearchManager.USER_QUERY);
            mPresenta = new BuscarAgente(this, Intent.ACTION_SEARCH, filtro);
        } else
            mPresenta = new BuscarAgente(this, null, null);

        //ListView lista_1 = (ListView) findViewById(R.id.lstAgentes);
        //registerForContextMenu(lista_1);

        HabilitarPantalla(true);

        iniciarActividad = false;
        mPresenta.iniciar();
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
            if (newIntent.getData() != null) {
                sAgenteClave = newIntent.getData().toString();
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

        //inflater.inflate(R.menu.context_atencion_clientes, menu);
        //menu.getItem(0).setTitle(Mensajes.get("XConsultar"));
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterContextMenuInfo info = null;
        Cursor agente = null;
        if (item.getMenuInfo() != null) {
            info = (AdapterContextMenuInfo) item.getMenuInfo();
            ListView lista_3 = (ListView) findViewById(R.id.lstAgentes);
            agente = (Cursor) lista_3.getItemAtPosition((int) info.position);
            sAgenteClave = agente.getString(1);
        }

        switch (item.getItemId()) {
            //case R.id.consultar:
                //mPresenta.consultarCliente();
                //return true;
            default:
                return super.onOptionsItemSelected(item);
        }

    }

    @SuppressWarnings("deprecation")
    public void mostrarAgentes(ISetDatos agentes) {

        ListView lista_4 = (ListView) findViewById(R.id.lstAgentes);

        try{
            Cursor cAgentes = (Cursor) agentes.getOriginal();
            startManagingCursor(cAgentes);
            SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple, cAgentes, new String[]
                    {SearchManager.SUGGEST_COLUMN_TEXT_1}, new int[]
                    {R.id.texto});
            lista_4.setAdapter(adapter);
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
        lista_4.setOnItemClickListener(mSeleccion);

    }

    public String getAgente() {
        // TODO Auto-generated method stub
        return sAgenteClave;
    }

    public void HabilitarPantalla(Boolean Habilitado) {
        ListView lista_5 = (ListView) findViewById(R.id.lstAgentes);
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

