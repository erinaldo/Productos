package com.duxstar.dacza.vistas;

import android.content.Intent;
import android.database.Cursor;
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
//import com.amesol.routelite.actividades.Inventario;
//import com.amesol.routelite.actividades.Mensajes;
//import com.amesol.routelite.actividades.TransaccionesDetalle;
//import com.amesol.routelite.controles.CargasTextBoxScanner;
//import com.amesol.routelite.controles.CargasTextBoxScanner.OnCodigoIngresadoListener;
//import com.amesol.routelite.datos.Cliente;
//import com.amesol.routelite.datos.Dia;
//import com.amesol.routelite.datos.MovimVisita;
//import com.amesol.routelite.datos.Ruta;
//import com.amesol.routelite.datos.TransProd;
//import com.amesol.routelite.datos.TransProdDetalle;
//import com.amesol.routelite.datos.Usuario;
//import com.amesol.routelite.datos.Vendedor;
//import com.amesol.routelite.datos.Visita;
//import com.amesol.routelite.datos.basedatos.BDVend;
import com.duxstar.dacza.datos.basedatos.Consultas;
//import com.amesol.routelite.datos.basedatos.Consultas2;
//import com.amesol.routelite.datos.generales.ISetDatos;
//import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
//import com.amesol.routelite.datos.utilerias.Sesion;
//import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.utilerias.ArchivoConfiguracion;
import com.duxstar.dacza.datos.utilerias.ConfiguracionLocal;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
//import com.amesol.routelite.presentadores.Enumeradores.Acciones;
import com.duxstar.dacza.presentadores.Enumeradores.RespuestaMsg;
//import com.amesol.routelite.presentadores.Enumeradores.Resultados;
//import com.amesol.routelite.presentadores.Enumeradores.Solicitudes;
import com.duxstar.dacza.presentadores.Enumeradores.TiposFasesDocto;
//import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.duxstar.dacza.presentadores.act.SeleccionarOrden;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionOrden;
import com.duxstar.dacza.presentadores.interfaces.ICapturaOrden;
//import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
//import com.amesol.routelite.utilerias.Generales;
//import com.amesol.routelite.utilerias.KeyGen;
import com.duxstar.dacza.presentadores.interfaces.IServidorComunicaciones;
import com.duxstar.dacza.vistas.generico.OrdenesAdapter;

import java.util.HashMap;

public class SeleccionOrden extends Vista implements ISeleccionOrden
{
	SeleccionarOrden mPresenta;
	String mAccion;
	//SeleccionarOrden.VistaOrdenes[] ordenes;
	SeleccionarOrden.VistaOrdenes ordenACancelar;
	boolean iniciarActividad;
	Class<?> actvdd;
	String sOrdenIdSeleccionado;
    Boolean optionsFlag = false;
    Boolean optionPlusFlag = false;
    String vieneDe = "";

    private OnItemClickListener mSeleccion = new OnItemClickListener() {
        public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
            SeleccionarOrden.VistaOrdenes orden = (SeleccionarOrden.VistaOrdenes) parent.getItemAtPosition(position);
            if (orden.getTipoFase() == TiposFasesDocto.CAPTURA) {
                mPresenta.capturarArticulos(orden);
                vieneDe = "capturarArticulos";
            }
            else
                mPresenta.consultar(orden);
        }
    };

    private OnClickListener mContinuar = new OnClickListener() {
        public void onClick(View v) {
            //setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            //finalizar();
            vieneDe = "capturarOrden";
            iniciarActividadConResultado(ICapturaOrden.class, 0, null);

		}
	};

	@SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_orden);
            deshabilitarBarra(true);
            setTitulo("Órdenes de Trabajo");

            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText("Continuar");
            btn.setOnClickListener(mContinuar);

            ListView lista = (ListView) findViewById(R.id.lstOrdenes);
            registerForContextMenu(lista);
            lista.setOnItemClickListener(mSeleccion);

            //oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            iniciarActividad = false;
            //actualizarVista();

            //fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
            //startManagingCursor((Cursor) fases.getOriginal());

            mPresenta = new SeleccionarOrden(this, mAccion);
            mPresenta.iniciar();
            //mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_CAPTURA);
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
	}

    /*public void actualizarVista() {
        try {
            ordenes = Consultas.ConsultasOrdenTrabajo.obtenerOrdenesCliente();
            mostrarOrdenesCliente(ordenes);
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
                ListView lista_2 = (ListView) findViewById(R.id.lstOrdenes);
                optionPlusFlag = true;
                registerForContextMenu(lista_2);
                openContextMenu(lista_2);
                return true;
            case Enumeradores.ACTMENU.ENVIO_PARCIAL:
                HashMap<String, String> oParametros = new HashMap<String, String>();
                oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_ORDENES));
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
            ListView lista = (ListView) findViewById(R.id.lstOrdenes);
            SeleccionarOrden.VistaOrdenes orden = (SeleccionarOrden.VistaOrdenes) lista.getItemAtPosition((int) info.position);

            if (orden.getTipoFase() == TiposFasesDocto.CAPTURA)
            {
                menu.setHeaderTitle(orden.getFolio());
                menu.setHeaderIcon(android.R.drawable.ic_menu_agenda);

                inflater.inflate(R.menu.context_manto_ordenes, menu);

                menu.getItem(0).setTitle("Editar");
                menu.getItem(1).setTitle("Capturar Artículos");
                if (orden.tieneDetalle())
                    menu.getItem(2).setTitle("Cerrar");
                else
                    menu.getItem(2).setVisible(false);
                menu.getItem(3).setTitle("Cancelar");
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
        SeleccionarOrden.VistaOrdenes orden = null;

        if (item.getMenuInfo() != null) {
            AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
            ListView lista = (ListView) findViewById(R.id.lstOrdenes);

            if (lista.getCount() > 0) {
                orden = (SeleccionarOrden.VistaOrdenes) lista.getItemAtPosition((int) info.position);
                sOrdenIdSeleccionado = orden.getOrdenId();
            }
        }

        switch (item.getItemId()) {
            case R.id.editar:
                vieneDe = "capturarOrden";
                mPresenta.modificar(orden);
                return true;
            case R.id.capturarArticulos:
                vieneDe = "capturarArticulos";
                mPresenta.capturarArticulos(orden);
                return true;
            case R.id.cerrar:
                ordenACancelar = orden;
                mPresenta.confirmarCerrar(orden);
                return true;
            case R.id.cancelar:
                ordenACancelar = orden;
                mPresenta.confirmarCancelar(orden);
                return true;
            case R.id.todas:
                mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_TODAS);
                return true;
            case R.id.captura:
                mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_CAPTURA);
                return true;
            case R.id.canceladas:
                mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_CANCELADAS);
                return true;
            case R.id.cerradas:
                mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_CERRADAS);
                return true;
            case R.id.enviadas:
                mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_NO_ENVIADAS);
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

	public void mostrarOrdenesCliente(SeleccionarOrden.VistaOrdenes[] ordenes) {
        ListView lista = (ListView) findViewById(R.id.lstOrdenes);
        OrdenesAdapter adapter = new OrdenesAdapter(this, R.layout.lista_color_grp, ordenes);
        lista.setAdapter(adapter);
    }

    public void actualizarTitulo(){
        int vista = (int)Sesion.get(Sesion.Campo.VistaOrdenesActual);
        TextView text = (TextView) findViewById(R.id.txtTitulo);
        String texto = "";
        switch (vista)
        {
            case Enumeradores.Vista.VISTA_TODAS:
                texto = "Todas las Órdenes ";
                break;
            case Enumeradores.Vista.VISTA_CAPTURA:
                texto = "Órdenes en Captura";
                break;
            case Enumeradores.Vista.VISTA_CANCELADAS:
                texto = "Órdenes canceladas";
                break;
            case Enumeradores.Vista.VISTA_CERRADAS:
                texto = "Órdenes cerradas";
                break;
            case Enumeradores.Vista.VISTA_NO_ENVIADAS:
                texto = "Órdenes no enviadas";
                break;
        }
        text.setText(texto);
    }

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

        if (Sesion.get(Sesion.Campo.VistaOrdenesActual) != null) {
            int vista = (int) Sesion.get(Sesion.Campo.VistaOrdenesActual);
            mPresenta.mostrarOrdenes(vista);
        }
        else
            mPresenta.mostrarOrdenes(Enumeradores.Vista.VISTA_CAPTURA);
	}

	@Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
        try {
            if (tipoMensaje == 1 && respuesta == RespuestaMsg.Si) { //cancelar la orden
                mPresenta.cancelar(ordenACancelar);
                vieneDe = "cancelarOrden";
                enviar(ordenACancelar.getOrdenId());
            }
            else if (tipoMensaje == 2 && respuesta == RespuestaMsg.Si){
                mPresenta.cerrar(ordenACancelar);
                vieneDe = "cerrarOrden";
                enviar(ordenACancelar.getOrdenId());
            }
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
            if (vieneDe.equals("capturarOrden"))
                oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_ORDEN));
            else
                oParametros.put("TipoEnvioInfo", String.valueOf(Enumeradores.TipoEnvioInfo.ENVIO_ORDEN_DETALLE));
            oParametros.put("IdDocumento", idDocumento);
            iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_TERMINAL, oParametros);
        }
    }

}
