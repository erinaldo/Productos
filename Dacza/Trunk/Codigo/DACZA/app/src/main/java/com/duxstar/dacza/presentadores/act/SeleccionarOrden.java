package com.duxstar.dacza.presentadores.act;

import java.util.Date;
import java.util.HashMap;
import com.duxstar.dacza.actividades.OrdenesTrabajo;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.ICapturaArticuloOrden;
import com.duxstar.dacza.presentadores.interfaces.ICapturaOrden;
import com.duxstar.dacza.presentadores.interfaces.IConsultaOrden;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionOrden;
import com.duxstar.dacza.vistas.Vista;

public class SeleccionarOrden extends Presentador {

    public static class VistaOrdenes {
        private String OrdenId;
        private String Folio;
        private String Cliente;
        private String Agente;
        private String Vin;
        private int TipoFase;
        private String Fase;
        private String FechaIni;
        private String FechaFin;
        //private String Extras;

        public VistaOrdenes() {
        }

        public VistaOrdenes(String ordenId, String folio, String cliente, String agente, String vin, int tipofase, String fase, String fechaIni, String fechaFin) {
            OrdenId = ordenId;
            Folio = folio;
            Cliente = cliente;
            Agente = agente;
            Vin = vin;
            TipoFase = tipofase;
            Fase = fase;
            FechaIni = fechaIni;
            FechaFin = fechaFin;
        }

        public String getOrdenId() {
            return OrdenId;
        }

        public void setOrdenId(String ordenId) {
            OrdenId = ordenId;
        }

        public String getFolio() {
            return Folio;
        }

        public void setFolio(String folio) {
            Folio = folio;
        }

        public String getCliente() {
            return Cliente;
        }

        public void setCliente(String cliente) {
            Cliente = cliente;
        }

        public String getAgente() {
            return Agente;
        }

        public void setAgente(String agente) {
            Agente = agente;
        }

        public String getVin() {
            return Vin;
        }

        public void setVin(String vin) {
            Vin = vin;
        }

        public int getTipoFase() {
            return TipoFase;
        }

        public void setTipoFase(int tipoFase) {
            TipoFase = tipoFase;
        }

        public String getFase() {
            return Fase;
        }

        public void setFase(String fase) {
            Fase = fase;
        }

        public String getFechaIni() {
            return FechaIni;
        }

        public void setFechaIni(String fechaIni) {
            FechaIni = fechaIni;
        }

        public String getFechaFin() {
            return FechaFin;
        }

        public void setFechaFin(String fechaFin) {
            FechaFin = fechaFin;
        }

        public boolean tieneDetalle (){
            try {
                OrdenTrabajo orden = new OrdenTrabajo();
                orden.OrdenId = OrdenId;
                BDTerm.recuperar(orden);
                BDTerm.recuperar(orden, ODTDetalle.class);

                if (!orden.ODTDetalle.isEmpty())
                    return true;

            }catch (Exception e){
                e.printStackTrace();
            }
            return false;
        }
    }

    ISeleccionOrden mVista;
    String mAccion;

    boolean iniciarActividad;
    Class<?> actvdd;
    String sOrdenIdSel;

    public SeleccionarOrden(ISeleccionOrden vista, String accion) {
        mVista = vista;
        mAccion = accion;
    }

    @Override
    public void iniciar() {
        try {
            mVista.iniciar();
            Sesion.remove(Campo.OrdenTrabajoActual);
            Sesion.remove(Campo.RecargaActual);
            Sesion.remove(Campo.DevolucionActual);

            if(Sesion.get(Campo.VistaOrdenesActual)!=null)
            {
                int vista = (int)Sesion.get(Campo.VistaOrdenesActual);
                mostrarOrdenes(vista);
            }
            else
                mostrarOrdenes(Enumeradores.Vista.VISTA_CAPTURA);
            /*if (mVista.obtenerOrdenes().length > 0) {
                iniciarActividad = false;
                mVista.mostrarOrdenesCliente(mVista.obtenerOrdenes());
            } else {
                mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
                mVista.finalizar();
                //mVista.iniciarActividadConResultado(ICapturaOrden.class, 0, null);
            }*/
        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }
    }
	
	/*public void abrirPedidoConsulta(SeleccionarPedido.VistaPedidos pedido){
		//abrirSoloLecturaReparto(pedido, "false");
		mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		mVista.finalizar();
		HashMap<String, String> oParametros = new HashMap<String, String>();
		oParametros.put("TransProdId", pedido.getTransprodID());
		oParametros.put("Reparto", "true");
		oParametros.put("Consultar", "true");
		mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, null, oParametros);
		mVista.finalizar();
	}*/

    public void modificar(VistaOrdenes orden) {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("OrdenId", orden.getOrdenId());
        mVista.iniciarActividadConResultado(ICapturaOrden.class, 0, null, oParametros);
        //mVista.finalizar();
    }

    public void consultar(VistaOrdenes orden) {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("OrdenId", orden.getOrdenId());
        mVista.iniciarActividadConResultado(IConsultaOrden.class, 0, null, oParametros);
        //mVista.finalizar();
    }

    public void capturarArticulos(VistaOrdenes orden) {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("OrdenId", orden.getOrdenId());
        mVista.iniciarActividadConResultado(ICapturaArticuloOrden.class, 0, null, oParametros);
        //mVista.finalizar();
    }

    public void confirmarCancelar(VistaOrdenes orden) {
        mVista.mostrarPreguntaSiNo("¿Desea cancelar la orden de trabajo " + orden.Folio + "?", 1);
    }

    public void cancelar(VistaOrdenes orden){
        try {
            OrdenesTrabajo.cancelarOrden(orden.OrdenId);
            int vista = (int)Sesion.get(Campo.VistaOrdenesActual);
            mostrarOrdenes(vista);
        } catch (Exception ex) {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void confirmarCerrar(VistaOrdenes orden){
        mVista.mostrarPreguntaSiNo("¿Desea cerrar la orden de trabajo " + orden.Folio + "?", 2);
    }

    public void cerrar(VistaOrdenes orden){
        try {
            OrdenesTrabajo.cerrarOrden(orden.OrdenId);
            int vista = (int)Sesion.get(Campo.VistaOrdenesActual);
            mostrarOrdenes(vista);
        } catch (Exception ex) {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void mostrarOrdenes(int vista){
        try {
            Sesion.set(Campo.VistaOrdenesActual, vista);
            SeleccionarOrden.VistaOrdenes[] ordenes;
            ordenes = Consultas.ConsultasOrdenTrabajo.obtenerOrdenesCliente(vista);
            mVista.mostrarOrdenesCliente(ordenes);
            mVista.actualizarTitulo();
        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }
    }
	
	/*private boolean registroTransferido(String transProdID, boolean eliminar){
		try{
			TransProd otrp = new TransProd();
			otrp.TransProdID = transProdID;
			BDVend.recuperar(otrp);
			if(otrp.Enviado){
				if(eliminar)
					mVista.mostrarAdvertencia(Mensajes.get("E0596",Mensajes.get("XEliminar")));
				else
					mVista.mostrarAdvertencia(Mensajes.get("E0596",Mensajes.get("XModificar")));
			}
			return otrp.Enviado;	
		}catch(Exception e){
			mVista.mostrarError(e.getMessage());
			e.printStackTrace();
			return false;
		}
	}*/



}
