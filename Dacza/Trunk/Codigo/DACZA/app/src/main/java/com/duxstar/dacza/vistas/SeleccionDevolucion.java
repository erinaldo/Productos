package com.duxstar.dacza.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.Enumeradores.TiposFasesDocto;
import com.duxstar.dacza.presentadores.act.SeleccionarDevolucion;
import com.duxstar.dacza.presentadores.act.SeleccionarRecarga;
import com.duxstar.dacza.presentadores.interfaces.ICapturaDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionRecarga;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.vistas.Vista;
import com.duxstar.dacza.vistas.generico.DevolucionesAdapter;
import com.duxstar.dacza.vistas.generico.RecargasAdapter;

import java.util.HashMap;

public class SeleccionDevolucion extends Vista implements ISeleccionDevolucion
{
	SeleccionarDevolucion mPresenta;
	String mAccion;
	SeleccionarDevolucion.VistaDevoluciones devolucionACancelar;
	boolean iniciarActividad;
	Class<?> actvdd;
	String sDevolucionIdSel;
    Boolean optionsFlag = false;
    Boolean optionPlusFlag = false;

    private OnItemClickListener mSeleccion = new OnItemClickListener() {
        public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
            SeleccionarDevolucion.VistaDevoluciones devolucion = (SeleccionarDevolucion.VistaDevoluciones) parent.getItemAtPosition(position);
            if (devolucion.getTipoFase() == TiposFasesDocto.CAPTURA)
                mPresenta.modificar(devolucion);
            else
                mPresenta.consultar(devolucion);

        }
    };
    private OnClickListener mContinuar = new OnClickListener() {
        public void onClick(View v) {
            iniciarActividadConResultado(ICapturaDevolucion.class, 0, null);
		}
	};

	@SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_devolucion);
            deshabilitarBarra(true);
            setTitulo("Devoluciones");

            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText("Continuar");
            btn.setOnClickListener(mContinuar);

            ListView lista = (ListView) findViewById(R.id.lstDevoluciones);
            registerForContextMenu(lista);
            lista.setOnItemClickListener(mSeleccion);

            //oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            iniciarActividad = false;
            //actualizarVista();

            //fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
            //startManagingCursor((Cursor) fases.getOriginal());

            mPresenta = new SeleccionarDevolucion(this, mAccion);
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
	}

    /*public void actualizarVista() {
        try {
            recargas = Consultas.ConsultasRecarga.obtenerRecargas();
            mostrarRecargas(recargas);
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
    }*/

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        try{
            menu.add(0, Enumeradores.ACTMENU.VISTAS, Enumeradores.ACTMENU.VISTAS, "Vistas");
            menu.add(1, Enumeradores.ACTMENU.ENVIO_PARCIAL, Enumeradores.ACTMENU.ENVIO_PARCIAL, "Envío Parcial");
        }
        catch (Exception e){
            mostrarError(e.getMessage());
        }

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId()) {
            case Enumeradores.ACTMENU.VISTAS:
                ListView lista_2 = (ListView) findViewById(R.id.lstDevoluciones);
                optionPlusFlag = true;
                registerForContextMenu(lista_2);
                openContextMenu(lista_2);
                return true;
            case Enumeradores.ACTMENU.ENVIO_PARCIAL:
                HashMap<String, String> oParametros = new HashMap<String, String>();
                oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_DEVOLUCIONES));
                iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_TERMINAL, oParametros);
                return true;
            default:
                optionPlusFlag = true;
                return super.onOptionsItemSelected(item);
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();

        optionsFlag = optionPlusFlag;

        if (v instanceof ListView && !optionsFlag) {
            AdapterContextMenuInfo info = (AdapterContextMenuInfo) menuInfo;
            ListView lista = (ListView) findViewById(R.id.lstDevoluciones);
            SeleccionarDevolucion.VistaDevoluciones devolucion = (SeleccionarDevolucion.VistaDevoluciones) lista.getItemAtPosition((int) info.position);

            if (devolucion.getTipoFase() == TiposFasesDocto.CAPTURA)
            {
                menu.setHeaderTitle(devolucion.getFolio());
                menu.setHeaderIcon(android.R.drawable.ic_menu_agenda);

                inflater.inflate(R.menu.context_manto_devoluciones, menu);

                menu.getItem(0).setTitle("Editar");
                menu.getItem(1).setTitle("Cerrar");
                menu.getItem(2).setTitle("Cancelar");
            }
        } else {
            inflater.inflate(R.menu.context_vistas, menu);

            menu.setHeaderTitle("Vistas");
            menu.getItem(0).setTitle("Todas");
            menu.getItem(1).setTitle("Captura");
            menu.getItem(2).setTitle("Canceladas");
            menu.getItem(3).setTitle("Cerradas");
            menu.getItem(4).setTitle("No Enviadas");
            menu.getItem(5).setVisible(false);
            optionPlusFlag = false;
        }

	}

	@Override
    public boolean onContextItemSelected(MenuItem item) {
        SeleccionarDevolucion.VistaDevoluciones devolucion = null;
        if (item.getMenuInfo() != null) {
            AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
            ListView lista = (ListView) findViewById(R.id.lstDevoluciones);;

            if (lista.getCount() > 0)            {
                devolucion = (SeleccionarDevolucion.VistaDevoluciones) lista.getItemAtPosition((int) info.position);
                sDevolucionIdSel = devolucion.getDevolucionId();
            }
        }

        switch (item.getItemId()) {
            case R.id.editar:
                mPresenta.modificar(devolucion);
                return true;
            case R.id.cerrar:
                devolucionACancelar = devolucion;
                mPresenta.confirmarCerrar(devolucion);
                return true;
            case R.id.cancelar:
                devolucionACancelar = devolucion;
                mPresenta.confirmarCancelar(devolucion);
                return true;
            case R.id.todas:
                mPresenta.mostrarDevoluciones(Enumeradores.Vista.VISTA_TODAS);
                return true;
            case R.id.captura:
                mPresenta.mostrarDevoluciones(Enumeradores.Vista.VISTA_CAPTURA);
                return true;
            case R.id.canceladas:
                mPresenta.mostrarDevoluciones(Enumeradores.Vista.VISTA_CANCELADAS);
                return true;
            case R.id.cerradas:
                mPresenta.mostrarDevoluciones(Enumeradores.Vista.VISTA_CERRADAS);
                return true;
            case R.id.enviadas:
                mPresenta.mostrarDevoluciones(Enumeradores.Vista.VISTA_NO_ENVIADAS);
                return true;
        }

        return true;
    }

    /*public String getDescripcionFase(int TipoFase) {
        fases.moveToPosition(TipoFase);
        return fases.getString(2);
    }*/

    public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad) {
        iniciarActividad = true;
        actvdd = actividad;
        mostrarAdvertencia(mensaje);
    }

	@Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        switch (keyCode) {
            case KeyEvent.KEYCODE_BACK:
                this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                this.finalizar();
                return true;
        }
        return super.onKeyDown(keyCode, event);
    }

	public void mostrarDevoluciones(SeleccionarDevolucion.VistaDevoluciones[] devoluciones) {
        ListView lista = (ListView) findViewById(R.id.lstDevoluciones);
        DevolucionesAdapter adapter = new DevolucionesAdapter(this, R.layout.lista_color, devoluciones);
        lista.setAdapter(adapter);
    }

    public void actualizarTitulo(){
        int vista = (int)Sesion.get(Sesion.Campo.VistaDevolucionesActual);
        TextView text = (TextView) findViewById(R.id.txtTitulo);
        String texto = "";
        switch (vista)
        {
            case Enumeradores.Vista.VISTA_TODAS:
                texto = "Todas las Devoluciones";
                break;
            case Enumeradores.Vista.VISTA_CAPTURA:
                texto = "Devoluciones en Captura";
                break;
            case Enumeradores.Vista.VISTA_CANCELADAS:
                texto = "Devoluciones Canceladas";
                break;
            case Enumeradores.Vista.VISTA_CERRADAS:
                texto = "Devoluciones Cerradas";
                break;
            case Enumeradores.Vista.VISTA_NO_ENVIADAS:
                texto = "Devoluciones No Enviadas";
                break;
        }
        text.setText(texto);
    }

	/*public SeleccionarRecarga.VistaRecargas[] obtenerRecargas() {
        return recargas;
    }*/

	@Override
    public void iniciar() {

	}

	@Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
        {
            String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
            mostrarAdvertencia(mensajeError);
        }
        else if (resultCode == Enumeradores.Resultados.RESULTADO_ENVIAR)
        {
            enviar(String.valueOf(Sesion.get(Sesion.Campo.IdDocumentoEnviar)));
        }
        if(Sesion.get(Sesion.Campo.VistaDevolucionesActual)!=null)
        {
            int vista = (int)Sesion.get(Sesion.Campo.VistaDevolucionesActual);
            mPresenta.mostrarDevoluciones(vista);
        }
        else
            mPresenta.mostrarDevoluciones(Enumeradores.Vista.VISTA_CAPTURA);
    }

	@Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
        try {
            if (tipoMensaje == 1 && respuesta == RespuestaMsg.Si) { //cancelar la orden
                mPresenta.cancelar(devolucionACancelar);
            }
            else if (tipoMensaje == 2 && respuesta == RespuestaMsg.Si){
                mPresenta.cerrar(devolucionACancelar);
            }
            enviar(devolucionACancelar.getDevolucionId());
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
	}

    public void enviar(String idDocumento)
    {
        ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Sesion.Campo.ConfiguracionLocal);
        if ((boolean)conf.get(ArchivoConfiguracion.CampoConfiguracion.ENVIO_INDIVIDUAL)) {
            HashMap<String, String> oParametros = new HashMap<String, String>();
            oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_DEVOLUCION));
            oParametros.put("IdDocumento", idDocumento);
            iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_TERMINAL, oParametros);
        }
    }

}
