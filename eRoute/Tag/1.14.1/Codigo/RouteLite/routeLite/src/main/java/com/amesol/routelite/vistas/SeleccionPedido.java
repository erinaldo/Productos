package com.amesol.routelite.vistas;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.Point;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.Display;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.controles.CargasTextBoxScanner;
import com.amesol.routelite.controles.CargasTextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.MovimVisita;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.Acciones;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.Enumeradores.Solicitudes;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
import com.amesol.routelite.presentadores.interfaces.ICancelaPedido;
import com.amesol.routelite.presentadores.interfaces.ICapturaCanje;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaMovSinInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.presentadores.interfaces.ISeleccionPedido;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.vistas.generico.PedidosAdapter;

import java.util.HashMap;
import java.util.List;

public class SeleccionPedido extends Vista implements ISeleccionPedido
{
	SeleccionarPedido mPresenta;
	String mAccion;
	Vendedor oVendedor;
	SeleccionarPedido.VistaPedidos[] pedidos;
	ISetDatos fases;
	SeleccionarPedido.VistaPedidos pedidoACancelar;
	boolean iniciarActividad;
	Class<?> actvdd;
	String codigoSolicita;
    String sTransProdIdSeleccionado;
	Cliente cliente;
    private boolean resultadoActividad = false;
	private TextView mTexto;
	private TransProd mTransProd;
	private String Cadena1 = "";
	private String Cadena2 = "";
	private int NumElemento = 0;
    private boolean bBuscandoFolio = false;
    private String sFacturaDev;
    private OnItemClickListener mSeleccion = new OnItemClickListener() {
        public void onItemClick(AdapterView<?> parent, View v, int position, long id) {

            if (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)) {
                SeleccionarPedido.VistaPedidos pedido = (SeleccionarPedido.VistaPedidos) parent.getItemAtPosition(position);
                if (pedido.getTipoFase() == TiposFasesDocto.SURTIDO && !pedido.getExtras().equals("")) { //Si es un pedido surtido de reparto
                    mPresenta.abrirPedidoConsulta(pedido);
                } else if (pedido.getTipoFase() == TiposFasesDocto.SURTIDO && pedido.getExtras().equals("")) { //Si es un pedido surtido de venta a bordo en reparto
                    if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ModificarVenta").toString().equals("0"))
                        mostrarAdvertencia(Mensajes.get("I0164"));
                    else
                        mPresenta.modificar(pedido);
                } else { //Si es un pedido en fase captura, es decir, por surtir
                    mPresenta.surtirPedido(pedido);
                }
            }

        }
    };
    private OnClickListener mContinuar = new OnClickListener() {
        public void onClick(View v) {
            Boolean solicitarFactura = false;
            if (mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS) && ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("BloquearCargaM").toString().equals("1")) {
                mostrarMensaje(Mensajes.get("E0947"), null, 30);
            } else {
                try {
                    if (mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES)) {
                        if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarFacturaDevolucion") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarFacturaDevolucion").equals("1")) {
                            solicitarFactura = true;
                        }
                    }
                }catch (Exception ex){
                    if (ex !=null && ex.getMessage() != null) {
                        mostrarError("Error al recuperar parámetro: " + ex.getMessage());
                    }else{
                        mostrarError("Error al recuperar el parámetro ValidarFacturaDevolucion ");
                    }
                    return;
                }
                if (!solicitarFactura & !mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS)) {
                    setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                   // finalizar();
                }
            }

            //mostrar captura de pedido con nueva transaccion
            if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS) || mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR))
                iniciarActividadConResultado(ICapturaPedido.class, 0, null);
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA))
                iniciarActividadConResultado(ICapturaPedido.class, 0, Acciones.ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA);
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_CAMBIOS))
                iniciarActividadConResultado(ICambiaProducto.class, 0, Acciones.ACCION_CAMBIOS_PRODUCTO_ENTRADA);
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES)){
                try {
                    if (solicitarFactura) {
                        mostrarDialogoFactura();
                        return;
                    }
                } catch (Exception ex) {
                    mostrarError("Error al solicitar factura");
                    return;
                }
                iniciarActividadConResultado(IDevolucionCliente.class, 0, null);
            }
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
                iniciarActividadConResultado(ICapturaMovSinInventario.class, 0, null);
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_AJUSTES))
                iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_AJUSTES);
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DESCARGA))
                iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_DESCARGA);
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DEVOLUCION))
                iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_DEVOLUCION);
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS) && ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("BloquearCargaM").toString().equals("0"))
                try {
                    if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ContrCapturaCargaM", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString())){
                            if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ContrCapturaCargaM", ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("MCNClave").toString()).equals("1")){
                                mPresenta.AutorizaMovimiento();
                            }else{
                                iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS);
                            }
                    }else{
                        iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS);
                    }
                }catch (Exception ex){
                    if (ex !=null && ex.getMessage() != null) {
                        mostrarError("Error al recuperar parámetro: " + ex.getMessage());
                    }else{
                        mostrarError("Error al recuperar el parámetro ContrCapturaCargaM ");
                    }
                    return;
                }
            else if (mAccion.equals(Acciones.ACCION_CAPTURA_CANJE))
                iniciarActividadConResultado(ICapturaCanje.class, 0, Acciones.ACCION_CAPTURA_CANJE);
		}
	};
    private OnCodigoIngresadoListener mCodigoBarras = new OnCodigoIngresadoListener() {
        public void OnCodigoIngresado(String Codigo, int codigoLeido) {
            try {
                if (Codigo.length() == 0)
                    return;

                cargarCargaConCodigoBarras(Codigo);
                return;
            } catch (Exception e) {
                return;
            }
        }
    };

    private OnClickListener mActualizarCargas = new OnClickListener() {

        @Override
        public void onClick(View v) {
            //llamar envio parcial antes de sincronizar inventario
            HashMap<String, Object> parametros = new HashMap<String, Object>();
            parametros.put("Tablas", "''TransProd'',''TransProdDetalle'',''Producto'',''PrecioProductoVig'',''ProductoDetalle'', ''ProductoEsquema'', ''ProductoImpuesto'', ''ProductoUnidad''");
            parametros.put("Recargas", true);
            iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_VENDEDOR, parametros);
        }

    };

	@SuppressWarnings("deprecation")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            mAccion = getIntent().getAction();

            setContentView(R.layout.seleccion_pedido);
            deshabilitarBarra(true);
            if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS))
                setTitulo(Mensajes.get("XVentas"));
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)) {
                setTitulo(Mensajes.get("XReparto"));
                ListView lista = (ListView) findViewById(R.id.lstPedidos);
                lista.setOnItemClickListener(mSeleccion);
            } else if (mAccion.equals(Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA)) {
                setTitulo(Consultas.ConsultasModuloMovDetalle.obtenerTitulo());
            } else if (mAccion.equals(Acciones.ACCION_MOSTRAR_CAMBIOS))
                setTitulo(Mensajes.get("XCambios"));
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES))
                setTitulo(Mensajes.get("XDevolucionCliente"));
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO)) {
                setTitulo("Movimiento Sin Inventario");
                crearMovimientosSinInventario();
            } else if (mAccion.equals(Acciones.ACCION_CAPTURAR_AJUSTES)) {
                setTitulo("Ajustes");
                crearMovimientosConInventario();
            } else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DESCARGA)) {
                setTitulo("Descargas");
                crearMovimientosConInventario();
            } else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DEVOLUCION)) {
                setTitulo("Devoluciones de Almacen");
                crearDevoluciones();
            } else if (mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS)) {

                CargasTextBoxScanner txtScanner = (CargasTextBoxScanner) findViewById(R.id.textBoxScanner);
                txtScanner.setVisibility(View.VISIBLE);
                txtScanner.setOnCodigoIngresado(mCodigoBarras);
                setTitulo("Cargas");
                ImageView actualizarCargas = (ImageView) findViewById(R.id.actualizar_Cargas);
                actualizarCargas.setVisibility(View.VISIBLE);
                actualizarCargas.setOnClickListener(mActualizarCargas);
                crearDevoluciones();
            } else if (mAccion.equals(Acciones.ACCION_CAPTURA_CANJE)){
                setTitulo(Mensajes.get("XCanjes"));
            }

            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setText(Mensajes.get("XContinuar"));
            btn.setOnClickListener(mContinuar);
            if (mAccion.equals(Acciones.ACCION_CANCELAR_MOVS_ENVIADOS)){
                btn.setVisibility(View.INVISIBLE);
            }else if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)) {
                MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
                if (m.get("VentaReparto").toString().equals("0"))
                    btn.setVisibility(View.INVISIBLE);
            }

            mTexto = (TextView) findViewById(R.id.lblCliente);
            mTexto.setVisibility(View.GONE);
            if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS) || mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES) || mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_CAMBIOS) || mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR) || mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA) || mAccion.equals(Acciones.ACCION_CAPTURA_CANJE)) {
                cliente = (Cliente) Sesion.get(Campo.ClienteActual);
                mTexto.setVisibility(View.VISIBLE);
                mTexto.setText(cliente.Clave + " - " + cliente.RazonSocial);
            }

            mTexto = (TextView) findViewById(R.id.lblRuta);
            mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
            mTexto = (TextView) findViewById(R.id.lblDia);
            mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
            ListView lista = (ListView) findViewById(R.id.lstPedidos);
            //if(!mAccion.equals(Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA)){
            registerForContextMenu(lista);
            //}

            oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
            iniciarActividad = false;

            //Cliente cliente = new Cliente();
            //cliente.Clave = Sesion.get(Campo.ClienteActual).toString();
            /*
			 * Dia dia = (Dia) Sesion.get(Campo.DiaActual); Visita visita =
			 * (Visita)Sesion.get(Campo.VisitaActual); pedidos =
			 * Consultas.ConsultasTransProd.obtenerPedidosPorVisita(dia,
			 * cliente, visita);
			 */
            actualizarVista();

            fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
            startManagingCursor((Cursor) fases.getOriginal());

            mPresenta = new SeleccionarPedido(this, mAccion);
            mPresenta.iniciar();
        } catch (Exception e) {
            mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
            e.printStackTrace();
        }
	}

    public void actualizarVista() {
        try {
            Dia dia = (Dia) Sesion.get(Campo.DiaActual);
            Visita visita = (Visita) Sesion.get(Campo.VisitaActual);
            if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS))
                pedidos = Consultas.ConsultasTransProd.obtenerPedidosPorVisita(dia, cliente, visita);
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR))
                pedidos = Consultas2.ConsultarTransProd.obtenerPedidosPorSurtirPorVisita(dia, cliente, visita);
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA))
                pedidos = Consultas.ConsultasTransProd.obtenerMovSinInvPorVisita(dia, cliente, visita);
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_CAMBIOS))
                pedidos = Consultas.ConsultasTransProd.obtenerCambiosPorVisita(dia, cliente, visita);
            else if (mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES))
                pedidos = Consultas.ConsultasTransProd.obtenerDevolucionesPorVisita(dia, cliente, visita);
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
                pedidos = Consultas.ConsultasTransProd.obtenerMovimientoInventario(dia, "19");
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_AJUSTES))
                pedidos = Consultas.ConsultasTransProd.obtenerMovimientoInventario(dia, "6", mAccion);
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DESCARGA))
                pedidos = Consultas.ConsultasTransProd.obtenerMovimientoInventario(dia, "7");
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_DEVOLUCION))
                pedidos = Consultas.ConsultasTransProd.obtenerMovimientoInventario(dia, "4");
            else if (mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS))
                pedidos = Consultas.ConsultasTransProd.obtenerMovimientoInventario(dia, "2");
            else if (mAccion.equals(Acciones.ACCION_CANCELAR_MOVS_ENVIADOS))
                pedidos = Consultas.ConsultasTransProd.obtenerPedidosEnviados(dia);
            else if (mAccion.equals(Acciones.ACCION_CAPTURA_CANJE))
                pedidos = Consultas.ConsultasTransProd.obtenerCanjesPorVisita(dia, cliente, visita);

            mostrarVentasCliente(pedidos);
        } catch (Exception e) {
            mostrarError(e.getMessage());
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        AdapterContextMenuInfo info = (AdapterContextMenuInfo) menuInfo;
        ListView lista = (ListView) findViewById(R.id.lstPedidos);
        SeleccionarPedido.VistaPedidos pedido = (SeleccionarPedido.VistaPedidos) lista.getItemAtPosition((int) info.position);
        menu.setHeaderTitle(pedido.getFolio());
        menu.setHeaderIcon(android.R.drawable.ic_menu_agenda);

        inflater.inflate(R.menu.context_manto_pedidos, menu);

        boolean traspasoRuta = false;
        if(pedido.getExtras() != ""){
            //validar grupo motivo guardado en extras
            if (pedido.getExtras().equalsIgnoreCase("TraspasoRutas")){
                traspasoRuta = true;
            }
        }

        menu.getItem(3).setTitle(Mensajes.get("XMostrarQR"));
        menu.getItem(3).setVisible(traspasoRuta);

        menu.getItem(0).setTitle(Mensajes.get("XModificar"));
        //Todos los movimientos, si estan cancelados, no permitir el modificar
        if (pedido.getTipoFase() == TiposFasesDocto.CANCELADO || traspasoRuta)
            menu.getItem(0).setVisible(false);
        else
            menu.getItem(0).setVisible(true);

        if(mAccion.equals(Acciones.ACCION_CANCELAR_MOVS_ENVIADOS))
            menu.getItem(0).setVisible(false);

        //si es reparto, ocultar la opcion de modificar
        if (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)) {
            if (pedido.getExtras().equals("") && pedido.getTipoFase() == TiposFasesDocto.SURTIDO) {
                menu.getItem(0).setVisible(true);
            } else {
                menu.getItem(0).setVisible(false);
            }
            menu.getItem(2).setTitle(Mensajes.get("XSurtir"));
            if (pedido.getTipoFase() == TiposFasesDocto.CANCELADO)
                menu.getItem(2).setVisible(false);
        } else {
            //ocultar la opcion de surtir para todos los demas modulos
            menu.getItem(2).setVisible(false);
        }

        if (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS) || mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR) || mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA))
            if (mPresenta.HabilitarCancelarVenta(pedido))
                menu.getItem(1).setTitle(Mensajes.get("XCancelar"));
            else
                menu.getItem(1).setVisible(false);
        else if (mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_CAMBIOS) || mAccion.equals(Acciones.ACCION_MOSTRAR_DEVOLUCIONES) || mAccion.equals(Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO) || mAccion.equals(Acciones.ACCION_CAPTURAR_AJUSTES) || mAccion.equals(Acciones.ACCION_CAPTURAR_DESCARGA) || mAccion.equals(Acciones.ACCION_CAPTURAR_DEVOLUCION) || mAccion.equals(Acciones.ACCION_CAPTURAR_CARGAS) || mAccion.equals(Acciones.ACCION_CAPTURA_CANJE))
            menu.getItem(1).setTitle(Mensajes.get("XEliminar"));
        else if (mAccion.equals(Acciones.ACCION_CANCELAR_MOVS_ENVIADOS)) {
            menu.getItem(1).setVisible(true);
            menu.getItem(1).setTitle(Mensajes.get("XCancelar"));
        }

        if (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR) && pedido.getTipoFase() == TiposFasesDocto.SURTIDO) {
            //menu.getItem(1).setEnabled(false);
            menu.getItem(2).setVisible(false);
        }

        if (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA) && pedido.getTipoFase() == TiposFasesDocto.CANCELADO) {
            menu.getItem(1).setVisible(false);
        }

        if(mAccion.equals(Enumeradores.Acciones.ACCION_MOSTRAR_CAMBIOS)){
            try {
                if(pedido.getTipoFase() == TiposFasesDocto.CANCELADO ){
                    menu.getItem(0).setVisible(false);
                }else if(pedido.getTipoFase() == TiposFasesDocto.CAPTURA){
                    if(Consultas.ConsutasNotaVentaUNI.ValidaPendienteConfirmar(pedido.getFolio())){
                        menu.getItem(0).setVisible(false);
                        menu.getItem(1).setVisible(false);
                    }
                }
            } catch (Exception e) {
               mostrarError(e.getMessage());
            }
        }

		/*
         * if
		 * (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones
		 * .ACCION_MOSTRAR_PEDIDOS)){ MOTConfiguracion m = (MOTConfiguracion)
		 * Sesion.get(Campo.MOTConfiguracion);
		 * if(m.get("ModificarVenta").toString().equals("0"))
		 * menu.getItem(0).setEnabled(false);
		 *
		 * if(m.get("CancelarVenta").toString().equals("0"))
		 * menu.getItem(1).setEnabled(false); }
		 */
	}

	@Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
        ListView lista = (ListView) findViewById(R.id.lstPedidos);
        SeleccionarPedido.VistaPedidos pedido = (SeleccionarPedido.VistaPedidos) lista.getItemAtPosition((int) info.position);
        sTransProdIdSeleccionado = pedido.getTransprodID();
        MOTConfiguracion m = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        switch (item.getItemId()) {
            case R.id.modificar:

                if (mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS) || mAccion.equals(Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)) {
                    if (m.get("ModificarVenta").toString().equals("0")) {
                        mostrarAdvertencia(Mensajes.get("I0164"));
                    } else //PublicoGeneral
                        mPresenta.modificar(pedido);
                } else {
                    mPresenta.modificar(pedido);
                }
                return true;
            case R.id.cancelar:
                /*if (mAccion.equals(com.amesol.routelite.presentadores.Enumeradores.Acciones.ACCION_MOSTRAR_PEDIDOS_POR_SURTIR)){
					//TODO: cancelar pedido por surtir
					pedidoACancelar = pedido;
					if (mPresenta.HabilitarCancelarVenta(pedido))
						mPresenta.cancelar(pedido);
				}else{*/
                pedidoACancelar = pedido;
                if (mPresenta.HabilitarCancelarVenta(pedido))
                    mPresenta.cancelar(pedido);
                //}
                return true;
            //default:
            //return super.onOptionsItemSelected(item);
            case R.id.surtir:
                //TODO: surtir pedido reparto
                mPresenta.surtirPedido(pedido);
                return true;
            case R.id.mostrarqr:
                try{
                    WindowManager manager = (WindowManager) getSystemService(WINDOW_SERVICE);
                    Display display = manager.getDefaultDisplay();
                    Point point = new Point();
                    display.getSize(point);
                    int width = point.x;
                    int tamanio = width * 3/4; //generar el codigo 3/4 del ancho de pantalla
                    Bitmap bmp = mPresenta.generarCodigoQR(pedido.getTransprodID(), tamanio);
                    LayoutInflater inflater = (LayoutInflater) SeleccionPedido.this
                            .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                    View dialogView = inflater.inflate(R.layout.dialog_codigoqr, null);
                    TextView titulo = (TextView) dialogView.findViewById(R.id.lblTituloDialogoQR);
                    titulo.setText(Mensajes.get("XCodQRCarga"));
                    ImageView codigo = (ImageView) dialogView.findViewById(R.id.codigoQR);
                    codigo.setImageBitmap(bmp);
                    AlertDialog.Builder builder = new AlertDialog.Builder(lista.getContext());
                    builder.setPositiveButton(Mensajes.get("XContinuar"), new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int id) {
                            dialog.dismiss();
                        }
                    });
                    builder.setView(dialogView);
                    final Dialog dialog = builder.create();
                    dialog.show();
                }catch(Exception e){
                    mostrarError(e.getMessage());
                    e.printStackTrace();
                }
                return true;
            /*case R.id.reimprimir:
                    try{
                        if (!bluetoothEncendido()){
                            encenderBluetooth();
                        }
                        else{
                            mPresenta.imprimirTicket();
                        }
                    }
                    catch (ControlError e){
                        e.Mostrar(this);
                    }
                    catch (Exception e){
                        mostrarError(e.getMessage());
                    }*/
		}

        return true;
    }

    public String getDescripcionFase(int TipoFase) {
        fases.moveToPosition(TipoFase);
        return fases.getString(2);
    }

    public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad) {
        iniciarActividad = true;
        actvdd = actividad;
        mostrarAdvertencia(mensaje);
    }

	/*
	 * private OnItemClickListener mSeleccion = new OnItemClickListener() {
	 * //listener para la lista public void onItemClick(AdapterView<?> parent,
	 * View v, int position, long id){
	 * 
	 * VistaPedidos pedido = (VistaPedidos) parent.getItemAtPosition(position);
	 * mPresenta.modificarPedido(pedido);
	 * 
	 * } };
	 */

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

	public void mostrarVentasCliente(SeleccionarPedido.VistaPedidos[] pedidos) {
        ListView lista = (ListView) findViewById(R.id.lstPedidos);
        PedidosAdapter adapter = new PedidosAdapter(this, R.layout.lista_simple3_icono, pedidos);
        lista.setAdapter(adapter);

        if(resultadoActividad){
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }
        //lista.setOnItemClickListener(mSeleccion);
    }

	public SeleccionarPedido.VistaPedidos[] obtenerPedidos() {
        return pedidos;
    }

	@Override
    public void iniciar() {

	}

	@Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data) {
        resultadoActividad = true;
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_CANCELAR_PEDIDO) {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                actualizarVista();
            } else {

            }
		} else if (requestCode == Solicitudes.SOLICITUD_CAMBIOS_PRODUCTO_ENTRADA) {
            if (resultCode == Resultados.RESULTADO_BIEN || resultCode == Resultados.RESULTADO_TERMINAR)
                actualizarVista();
        } else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO) {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                iniciarActividadConResultado(ICapturaMovConInventario.class, 0, Acciones.ACCION_CAPTURAR_CARGAS);
            }
        }else if (resultCode == Resultados.RESULTADO_BIEN && !bBuscandoFolio) {
            actualizarVista();
        } else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) {
            if (resultCode == Resultados.RESULTADO_MAL) {
                if (bBuscandoFolio){
                    bBuscandoFolio = false;
                    setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("ME0390", Mensajes.get("XFactura")));
                    finalizar();
                }else{
                    if (data != null) {
                        String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
                        if (mensajeError != null) {
                            mostrarError(mensajeError);
                            return;
                        }
                    }
                }
            }else{
                if (bBuscandoFolio) {
                    try {
                        bBuscandoFolio = false;
                        HashMap<String, HashMap<Integer,Float>> hmDetalles = new HashMap<String, HashMap<Integer,Float>>();
                        StringBuilder transProdIdFac = new StringBuilder();
                        if (buscarFactura(sFacturaDev, false,hmDetalles, transProdIdFac)) {
                            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                            HashMap<String, Object> parametros = new HashMap<String, Object>();
                            parametros.put("DetallesFactura", hmDetalles);
                            parametros.put("FolioFactura", sFacturaDev);
                            parametros.put("TransProdIDFac", transProdIdFac.toString());
                            iniciarActividadConResultado(IDevolucionCliente.class, 0, null, parametros);
                            finalizar();
                        }else{
                            setResultado(Enumeradores.Resultados.RESULTADO_MAL,Mensajes.get("ME0390", Mensajes.get("XFactura")));
                            finalizar();
                        }
                    }catch(Exception ex){
                        if(ex != null && ex.getMessage() != null) {
                            setResultado(Enumeradores.Resultados.RESULTADO_MAL, ex.getMessage());
                        }else{
                            setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error al buscar la factura");
                        }
                        finalizar();
                    }
                }else
                    actualizarVista();
            }
        } else if (requestCode == Solicitudes.SOLICITUD_ELIMINAR_AJUSTE_INV) {
            if (resultCode == Resultados.RESULTADO_BIEN) {
                actualizarVista();
            }
        }else if (requestCode == REQUEST_ENABLE_BT){
            if (resultCode == RESULT_OK){
                try{
                    mPresenta.imprimirTicket();
                }
                catch (Exception e){
                    mostrarError(e.getMessage());
                }
            }
            else{
                mostrarError("No se pudo encender el BT");
            }
            return;
        }
	}

	@Override
    public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje) {
        try {
            if (tipoMensaje == 5 && respuesta == RespuestaMsg.Si) { //cancelar el pedido

                HashMap<String, String> oParametros = new HashMap<String, String>();
                oParametros.put("TransProdId", pedidoACancelar.getTransprodID());
                iniciarActividadConResultado(ICancelaPedido.class, Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_CANCELAR_PEDIDO, Enumeradores.Acciones.ACCION_CANCELAR_PEDIDO, oParametros);

				/*
                 * TransProd oTrp =
				 * Transacciones.Pedidos.ObtenerPedido(pedidoACancelar
				 * .getTransprodID()); oTrp.TipoFase = 0; oTrp.FechaCancelacion
				 * = Generales.getFechaHoraActual(); oTrp.MFechaHora =
				 * Generales.getFechaHoraActual(); oTrp.MUsuarioID =
				 * ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
				 * BDVend.guardarInsertar(oTrp);
				 *
				 * Cliente cliente = new Cliente();
				 * cliente.RecuperarClienteActual(); Dia dia = (Dia)
				 * Sesion.get(Campo.DiaActual); Visita visita =
				 * (Visita)Sesion.get(Campo.VisitaActual); pedidos =
				 * Consultas.ConsultasTransProd.obtenerPedidosPorVisita(dia,
				 * cliente, visita); mostrarVentasCliente(pedidos);
				 */
            } else if (respuesta == RespuestaMsg.OK && iniciarActividad) { //mostrar pedido solo lectura
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
                HashMap<String, String> oParam = new HashMap<String, String>();
                oParam.put("TransProdId", sTransProdIdSeleccionado);
                iniciarActividadConResultado(actvdd, Enumeradores.Solicitudes.SOLICITUD_MOSTRAR_CAPTURA_PEDIDO, codigoSolicita, oParam);
            } else if (tipoMensaje == 10 && respuesta == RespuestaMsg.Si) {

                TransProd mTransProdOriginal = new TransProd();
                mTransProdOriginal=Consultas.ConsultasTransProd.obtenerTransProdObj(mTransProd.TransProdID);
                TransaccionesDetalle.Pedidos.EliminarDetalleCarga(mTransProdOriginal.TransProdID, mTransProdOriginal.TransProdDetalle, 2, 1, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);
                BDVend.commit();
                ActualizarCarga(true);

            }/*else if(tipoMensaje == 20 && respuesta == RespuestaMsg.No){
				//no hay pedidos por surtir y contesto NO, salir
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}else if (tipoMensaje == 20 && respuesta == RespuestaMsg.Si){
				//no hay pedidos por surtir y contesto SI, ir a captura de pedido
				iniciarActividadConResultado(ICapturaPedido.class, 0, null);
			}*/
            else if (tipoMensaje == 30){ // Salir de la Actividad
                setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                finalizar();
            }
		}
		catch (Exception e)
		{
			e.printStackTrace();
            //			mostrarError(e.getMessage());
        }
	}

	public void ActualizarCarga(boolean ActualizarCarga) throws Exception {

        NumElemento = 0;
        List<TransProdDetalle> mTransProdDetalle = mTransProd.TransProdDetalle;
        mTransProd.TransProdDetalle = null;
        for (int a = 0; a < mTransProdDetalle.size(); a++) {
            if (!mTransProdDetalle.get(a).ProductoClave.equals(Consultas.ConsultasProducto.obtenerProducto(mTransProdDetalle.get(a).ProductoClave).ProductoClave)) {
                Cadena1 += NumElemento + " ,";
                Cadena2 += "Producto " + mTransProdDetalle.get(a).ProductoClave + " ,";
            }
            ISetDatos unidades = Consultas.ConsultasProducto.obtenerUnidadesProductoDifen(mTransProdDetalle.get(a).ProductoClave, mTransProdDetalle.get(a).TipoUnidad);

            if (!unidades.moveToNext()) {
                Cadena1 += NumElemento + " ,";
                Cadena2 += "Unidad  " + mTransProdDetalle.get(a).TipoUnidad + " ,";
            }
            NumElemento++;
        }
        if (!Cadena1.equals("") && !Cadena2.equals("")) {
            mostrarError(Mensajes.get("E0668").replace("$0$", Cadena1) + " " + Mensajes.get("BE0003").replace("$0$", Cadena2));
            return;
        }
        if (!Cadena1.equals("")) {
            mostrarError(Mensajes.get("E0668").replace("$0$", Cadena1));
            return;
        }
        if (!Cadena2.equals("")) {
            mostrarError(Mensajes.get("BE0003").replace("$0$", Cadena2));
            return;
        }
        if (ActualizarCarga) {
            BDVend.recuperar(mTransProd);
            mTransProd.MFechaHora = Generales.getFechaHoraActual();
            mTransProd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            BDVend.guardarInsertar(mTransProd);
        } else {
            mTransProd.PCEModuloMovDetClave = Sesion.get(Campo.ModuloMovDetalleClave).toString();
            mTransProd.Tipo = 2;
            mTransProd.TipoFase = 1;
            mTransProd.TipoMovimiento = 1;
            mTransProd.Total = 0;
            mTransProd.Saldo = 0;
            mTransProd.MFechaHora = Generales.getFechaActual();
            mTransProd.FechaHoraAlta = Generales.getFechaActual();
            mTransProd.Escritorio = true;
            mTransProd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            mTransProd.FechaCaptura = Generales.getFechaActual();
            BDVend.guardarInsertar(mTransProd);
        }
        for (int a = 0; a < mTransProdDetalle.size(); a++) {
            mTransProdDetalle.get(a).TransProdID = mTransProd.TransProdID;
            mTransProdDetalle.get(a).TransProdDetalleID = KeyGen.getId();
            mTransProdDetalle.get(a).Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(mTransProd.TransProdID) + 1;
            mTransProdDetalle.get(a).Precio = 0;
            mTransProdDetalle.get(a).Subtotal = 0;
            mTransProdDetalle.get(a).Total = 0;
            mTransProdDetalle.get(a).Enviado = false;
            mTransProdDetalle.get(a).MFechaHora = Generales.getFechaHoraActual();
            mTransProdDetalle.get(a).MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            BDVend.guardarInsertar(mTransProdDetalle.get(a));
            Inventario.ActualizarInventario(mTransProdDetalle.get(a).ProductoClave, mTransProdDetalle.get(a).TipoUnidad, mTransProdDetalle.get(a).Cantidad, 2, 1, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);
        }
        BDVend.commit();

        mostrarAdvertencia(Mensajes.get("I0181"));
        actualizarVista();

	}

	private void crearMovimientosSinInventario() {
        try {
            MovimVisita mMovSinVisita = new MovimVisita();

            mMovSinVisita.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
            mMovSinVisita.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            mMovSinVisita.VendedorId = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
            mMovSinVisita.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
            mMovSinVisita.ModuloMovDetalleClave = Sesion.get(Campo.ModuloMovDetalleClave).toString();
            mMovSinVisita.TipoIndiceModuloMovDetClave = Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString();
            mMovSinVisita.ACTId = 0;

            Sesion.set(Campo.MovSinVisita, mMovSinVisita);

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

    private void crearMovimientosConInventario() {
        try {
            MovimVisita mMovConVisita = new MovimVisita();

            mMovConVisita.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
            mMovConVisita.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            mMovConVisita.VendedorId = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
            mMovConVisita.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
            mMovConVisita.ModuloMovDetalleClave = Sesion.get(Campo.ModuloMovDetalleClave).toString();
            mMovConVisita.TipoIndiceModuloMovDetClave = Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString();
            mMovConVisita.ACTId = 0;
            mMovConVisita.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;

            Sesion.set(Campo.MovConVisita, mMovConVisita);

		} catch (Exception e) {
            mostrarError(e.getMessage());
            e.printStackTrace();
        }
    }

    private void crearDevoluciones() {
        try {
            MovimVisita mDevoluciones = new MovimVisita();

            mDevoluciones.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
            mDevoluciones.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            mDevoluciones.VendedorId = ((Vendedor) Sesion.get(Campo.VendedorActual)).VendedorId;
            mDevoluciones.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
            mDevoluciones.ModuloMovDetalleClave = Sesion.get(Campo.ModuloMovDetalleClave).toString();
            mDevoluciones.TipoIndiceModuloMovDetClave = Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString();
            mDevoluciones.USUId = ((Vendedor) Sesion.get(Campo.VendedorActual)).USUId;
            mDevoluciones.AlmacenID = ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID;
            Sesion.set(Campo.Devoluciones, mDevoluciones);

        } catch (Exception e) {
            mostrarError(e.getMessage());
            e.printStackTrace();
        }
    }

    private void cargarCargaConCodigoBarras(String Codigo){
        try{
            String[] arrayCarga = Codigo.split("\\|");

            if(arrayCarga.length >= 4) {
                mTransProd = new TransProd();
                String primerCaracter = String.valueOf(Codigo.charAt(0));
                if (primerCaracter.equals("|")){
                    mTransProd.TransProdID = arrayCarga[1].trim();
                    mTransProd.MUsuarioID = arrayCarga[2].trim();
                }else{//Codigo generado RouteADM
                    mTransProd.TransProdID = KeyGen.getId();
                    mTransProd.MUsuarioID = arrayCarga[0].trim();
                }

                if (arrayCarga[3].trim().equals("TR001")) { //folio generico traspaso rutas
                    //generar un folio
                    try {
                        StringBuilder byRefMensaje = new StringBuilder();
                        mTransProd.Folio = Folios.Obtener(Sesion.get(Campo.ModuloMovDetalleClave).toString(), byRefMensaje);
                        if (byRefMensaje.toString().trim() != "") {
                            mostrarError(byRefMensaje.toString());
                            return;
                        }
                    } catch (ControlError e) {
                        e.Mostrar(this);
                        return;
                    } catch (Exception ex) {
                        mostrarError(ex.getMessage());
                        ex.printStackTrace();
                        return;
                    }
                } else {
                    if (primerCaracter.equals("|")){
                        mTransProd.Folio = arrayCarga[3].trim();
                    }else{//Codigo generado RouteADM
                        mTransProd.Folio = arrayCarga[1].trim();
                    }
                }

                if (primerCaracter.equals("|")){
                    mTransProd.DiaClave = arrayCarga[4];
                }else{//Codigo generado RouteADM
                    mTransProd.DiaClave = arrayCarga[2];
                }

                int a=0;
                if (primerCaracter.equals("|")){
                    a = 5;
                }else{//Codigo generado RouteADM
                    a = 3;
                }
                while (a < arrayCarga.length) {
                    TransProdDetalle mTransProdDetalle = new TransProdDetalle();
                    String[] arrayDetalle = arrayCarga[a].split(",");
                    mTransProdDetalle.ProductoClave = arrayDetalle[0];
                    mTransProdDetalle.TipoUnidad = Integer.parseInt(arrayDetalle[1]);
                    mTransProdDetalle.Cantidad = Float.parseFloat(arrayDetalle[2]); //Integer.parseInt(arrayDetalle[2]);
                    mTransProd.TransProdDetalle.add(mTransProdDetalle);

                    a++;
                }

                if (!mTransProd.MUsuarioID.equals(((Usuario) Sesion.get(Campo.UsuarioActual)).Clave)) {
                    mostrarError(Mensajes.get("E0667"));
                    return;
                }

                if (!Generales.validarFecha(mTransProd.DiaClave)) {
                    mostrarError(Mensajes.get("E0623").replace("$0$", "Fecha").replace("$1$", "dd/mm/yyyy"));
                    return;
                }

                if (!((Dia) Sesion.get(Campo.DiaActual)).DiaClave.equals(mTransProd.DiaClave)){
                    mostrarError(Mensajes.get("E0670"));
                    return;
                }

                if (mTransProd.TransProdDetalle.isEmpty()) {
                    mostrarError(Mensajes.get("E0608").replace("$0$", "Folio"));
                    return;
                }

                if (Consultas.ConsultasFolios.obtenerFolioTransProd(mTransProd.Folio)) {
                    if (Consultas.ConsultasFolios.obtenerTransProdRelacionados(mTransProd.Folio, mTransProd.DiaClave)) {
                        mostrarError(Mensajes.get("E0079"));
                        return;
                    } else {
                        mostrarPreguntaSiNo(Mensajes.get("P0200"), 10);

                    }
                } else
                    ActualizarCarga(false);
            }else{
                mostrarError(Mensajes.get("E0671"));
            }
        }catch (Exception e){
            mostrarError(e.getMessage());
        }

    }

    public String getsTransProdIdSeleccionado() {
        return sTransProdIdSeleccionado;
    }

    @Override
    public void impresionFinalizada(boolean impresionExitosa, String mensajeError)
    {
        if (mensajeError.equals(""))
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
        else
            setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
        quitarProgreso();
        /*try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).equals("0")) {
                    mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
                } else {
                    finalizar();
                }
            } else {
                mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
            }
        }catch(Exception ex){
            mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        }*/
    }

    public void mostrarDialogoFactura()  {
        final AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle(Mensajes.get("XFactura"));

        // Set up the input
        final EditText input = new EditText(this);
        // Specify the type of input expected; this, for example, sets the input as a password, and will mask the text
        //input.setInputType(InputType.TYPE_CLASS_TEXT | InputType.TYPE_TEXT_VARIATION_PASSWORD);
        builder.setView(input);

        // Set up the buttons
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                HashMap<String,HashMap<Integer,Float>> hmDetalles = new HashMap<String, HashMap<Integer,Float>>();
                StringBuilder transProdIdFAC = new StringBuilder();
                sFacturaDev = input.getText().toString();
                try {
                    if (sFacturaDev.length() <= 0) {
                        throw new Exception(Mensajes.get("BE0001", Mensajes.get("XFactura")));
                    } else if (buscarFactura(sFacturaDev, true, hmDetalles, transProdIdFAC)) {
                        setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                        HashMap<String, Object> parametros = new HashMap<String, Object>();
                        parametros.put("DetallesFactura", hmDetalles);
                        parametros.put("FolioFactura", input.getText().toString());
                        parametros.put("TransProdIDFac", transProdIdFAC.toString());
                        iniciarActividadConResultado(IDevolucionCliente.class, 0, null, parametros);
                        finalizar();
                    }
                }catch (Exception ex){
                    if(ex != null && ex.getMessage() != null) {
                        setResultado(Enumeradores.Resultados.RESULTADO_MAL, ex.getMessage());
                    }else{
                        setResultado(Enumeradores.Resultados.RESULTADO_MAL, "Error al buscar la factura");
                    }
                    finalizar();
                }
            }
        });
        builder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                setResultado(Enumeradores.Resultados.RESULTADO_MAL, Mensajes.get("BE0001", Mensajes.get("XFactura")));
                finalizar();
            }
        });

        builder.show();
    }

    private boolean buscarFactura(String folioFactura, boolean buscarEnServer, HashMap<String, HashMap<Integer,Float>> hmDetalles, StringBuilder transProdIDFac) throws Exception {
            if(((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("ValidarFacturaDevolucion") && ((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("ValidarFacturaDevolucion").equals("1")) {
                com.amesol.routelite.datos.basedatos.Consultas.ConsultasTransProdDetalle.obtenerDetallesFactura(folioFactura, hmDetalles , "");

                if (hmDetalles != null && hmDetalles.size()>0){
                    transProdIDFac.append( Consultas.ConsultasTransProd.obtenerTransProdIdXFolio(folioFactura));
                    return true;
                }else{
                    if(buscarEnServer) {
                        bBuscandoFolio = true;
                        HashMap<String, String> parametros = new HashMap<String, String>();
                        parametros.put("FolioDocto", folioFactura);
                        iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Acciones.ACCION_RECIBIR_INFO_DOCUMENTO, parametros);
                    }else{
                        throw new Exception(Mensajes.get("ME0390", Mensajes.get("XFactura")));
                    }

                }
            }else{
                return true;
            }

        return false;
    }

}
