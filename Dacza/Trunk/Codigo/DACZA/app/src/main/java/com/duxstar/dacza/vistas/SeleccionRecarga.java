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
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
import com.duxstar.dacza.presentadores.Enumeradores.TiposFasesDocto;
import com.duxstar.dacza.presentadores.act.SeleccionarRecarga;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionRecarga;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.vistas.generico.RecargasAdapter;

import java.util.HashMap;

public class SeleccionRecarga extends Vista implements ISeleccionRecarga
{
	SeleccionarRecarga mPresenta;
	String mAccion;
	//SeleccionarRecarga.VistaRecargas[] recargas;
	SeleccionarRecarga.VistaRecargas recargaACancelar;
	boolean iniciarActividad;
	Class<?> actvdd;
	String sRecargaIdSel;
    Boolean optionsFlag = false;
    Boolean optionPlusFlag = false;
    Boolean bSincronizar = false;

    private OnItemClickListener mSeleccion = new OnItemClickListener() {
        public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
            SeleccionarRecarga.VistaRecargas recarga = (SeleccionarRecarga.VistaRecargas) parent.getItemAtPosition(position);
            if (recarga.getTipoFase() == TiposFasesDocto.CAPTURA)
                mPresenta.modificar(recarga);
            else
                mPresenta.consultar(recarga);

        }
    };
    private OnClickListener mContinuar = new OnClickListener() {
        public void onClick(View v) {
            iniciarActividadConResultado(ICapturaRecarga.class, 0, null);
		}
	};

	@SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_recarga);
            deshabilitarBarra(true);
            setTitulo("Solicitudes de Traspaso");

            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText("Continuar");
            btn.setOnClickListener(mContinuar);

            ListView lista = (ListView) findViewById(R.id.lstRecargas);
            registerForContextMenu(lista);
            lista.setOnItemClickListener(mSeleccion);

            //oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            iniciarActividad = false;
            //actualizarVista();

            //fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
            //startManagingCursor((Cursor) fases.getOriginal());

            mPresenta = new SeleccionarRecarga(this, mAccion);
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
            menu.add(1, Enumeradores.ACTMENU.SINCRONIZAR, Enumeradores.ACTMENU.SINCRONIZAR, "Sincronizar");
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
                ListView lista_2 = (ListView) findViewById(R.id.lstRecargas);
                optionPlusFlag = true;
                registerForContextMenu(lista_2);
                openContextMenu(lista_2);
                return true;
            case Enumeradores.ACTMENU.SINCRONIZAR:
                bSincronizar = true;
                HashMap<String, String> oParametros = new HashMap<String, String>();
                oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_RECARGAS));
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
            ListView lista = (ListView) findViewById(R.id.lstRecargas);
            SeleccionarRecarga.VistaRecargas recarga = (SeleccionarRecarga.VistaRecargas) lista.getItemAtPosition((int) info.position);

            if (recarga.getTipoFase() == TiposFasesDocto.CAPTURA)
            {
                menu.setHeaderTitle(recarga.getFolio());
                menu.setHeaderIcon(android.R.drawable.ic_menu_agenda);

                inflater.inflate(R.menu.context_manto_recargas, menu);

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
        SeleccionarRecarga.VistaRecargas recarga = null;
        if (item.getMenuInfo() != null) {
            AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
            ListView lista = (ListView) findViewById(R.id.lstRecargas);;

            if (lista.getCount() > 0) {
                recarga = (SeleccionarRecarga.VistaRecargas) lista.getItemAtPosition((int) info.position);
                sRecargaIdSel = recarga.getRecargaId();
            }
        }

        switch (item.getItemId()) {
            case R.id.editar:
                mPresenta.modificar(recarga);
                return true;
            case R.id.cerrar:
                recargaACancelar = recarga;
                mPresenta.confirmarCerrar(recarga);
                return true;
            case R.id.cancelar:
                recargaACancelar = recarga;
                mPresenta.confirmarCancelar(recarga);
                return true;
            case R.id.todas:
                mPresenta.mostrarRecargas(Enumeradores.Vista.VISTA_TODAS);
                return true;
            case R.id.captura:
                mPresenta.mostrarRecargas(Enumeradores.Vista.VISTA_CAPTURA);
                return true;
            case R.id.canceladas:
                mPresenta.mostrarRecargas(Enumeradores.Vista.VISTA_CANCELADAS);
                return true;
            case R.id.cerradas:
                mPresenta.mostrarRecargas(Enumeradores.Vista.VISTA_CERRADAS);
                return true;
            case R.id.enviadas:
                mPresenta.mostrarRecargas(Enumeradores.Vista.VISTA_NO_ENVIADAS);
                return true;
            case R.id.surtidas:
                mPresenta.mostrarRecargas(Enumeradores.Vista.VISTA_SURTIDAS);
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

	public void mostrarRecargas(SeleccionarRecarga.VistaRecargas[] recargas) {
        ListView lista = (ListView) findViewById(R.id.lstRecargas);
        RecargasAdapter adapter = new RecargasAdapter(this, R.layout.lista_color, recargas);
        lista.setAdapter(adapter);
    }

    public void actualizarTitulo(){
        int vista = (int)Sesion.get(Sesion.Campo.VistaRecargasActual);
        TextView text = (TextView) findViewById(R.id.txtTitulo);
        String texto = "";
        switch (vista)
        {
            case Enumeradores.Vista.VISTA_TODAS:
                texto = "Todas las Solicitudes";
                break;
            case Enumeradores.Vista.VISTA_CAPTURA:
                texto = "Solicitudes en Captura";
                break;
            case Enumeradores.Vista.VISTA_CANCELADAS:
                texto = "Solicitudes canceladas";
                break;
            case Enumeradores.Vista.VISTA_CERRADAS:
                texto = "Solicitudes cerradas";
                break;
            case Enumeradores.Vista.VISTA_NO_ENVIADAS:
                texto = "Solicitudes no enviadas";
                break;
            case Enumeradores.Vista.VISTA_SURTIDAS:
                texto = "Solicitudes surtidas";
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
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES)
        {
            if (resultCode == Enumeradores.Resultados.RESULTADO_MAL) {
                String mensajeError = (String) data.getExtras().getString("mensajeIniciar");

                mostrarAdvertencia(mensajeError);
            }
        }
        else if (resultCode == Enumeradores.Resultados.RESULTADO_ENVIAR)
        {
            bSincronizar = false;
            enviar(String.valueOf(Sesion.get(Sesion.Campo.IdDocumentoEnviar)));
        }

        if(Sesion.get(Sesion.Campo.VistaRecargasActual)!=null)
        {
            int vista = (int)Sesion.get(Sesion.Campo.VistaRecargasActual);
            mPresenta.mostrarRecargas(vista);
        }
        else
            mPresenta.mostrarRecargas(Enumeradores.Vista.VISTA_CAPTURA);
    }

	@Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
        try {
            if (tipoMensaje == 1 && respuesta == RespuestaMsg.Si) { //cancelar la orden
                mPresenta.cancelar(recargaACancelar);
            }
            else if (tipoMensaje == 2 && respuesta == RespuestaMsg.Si){
                mPresenta.cerrar(recargaACancelar);
            }
            else {
                if (bSincronizar && (boolean)Sesion.get(Sesion.Campo.PermitirRecibir))
                    iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_TRASPASOS);
            }
            bSincronizar = false;
            enviar(recargaACancelar.getRecargaId());
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
            oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_RECARGA));
            oParametros.put("IdDocumento", idDocumento);
            iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_TERMINAL, oParametros);
        }
    }

}
