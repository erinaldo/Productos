package com.duxstar.dacza.presentadores.act;

import java.util.Date;
import java.util.HashMap;

//import com.amesol.routelite.actividades.Mensajes;
//import com.amesol.routelite.actividades.TransaccionesDetalle;
//import com.amesol.routelite.actividades.ValoresReferencia;
//import com.amesol.routelite.datos.Cliente;
//import com.amesol.routelite.datos.TransProd;
//import com.amesol.routelite.datos.Visita;
//import com.amesol.routelite.datos.basedatos.BDVend;
//import com.amesol.routelite.datos.basedatos.Consultas;
//import com.amesol.routelite.datos.generales.ISetDatos;
//import com.amesol.routelite.datos.utilerias.CONHist;
//import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
//import com.amesol.routelite.datos.utilerias.Sesion;
//import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.actividades.Recargas;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
//import com.amesol.routelite.presentadores.Enumeradores.Acciones;
//import com.amesol.routelite.presentadores.Enumeradores.Resultados;
//import com.amesol.routelite.presentadores.Enumeradores.Solicitudes;
//import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
//import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.duxstar.dacza.presentadores.Presentador;
//import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
//import com.amesol.routelite.presentadores.interfaces.ICapturaMovConInventario;
//import com.amesol.routelite.presentadores.interfaces.ICapturaMovSinInventario;
//import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
//import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionRecarga;
import com.duxstar.dacza.vistas.Vista;
//import com.amesol.routelite.utilerias.ControlError;

public class SeleccionarRecarga extends Presentador
{

	public static class VistaRecargas
	{
		private String RecargaId;
		private String Folio;
		private int TipoFase;
		private String Fase;
		private String FechaSolicitud;
        private String FechaSurtido;

        public VistaRecargas(){}
		
		public VistaRecargas(String recargaId, String folio, int tipofase, String fase, String fechaSolicitud, String fechaSurtido)
		{
			RecargaId = recargaId;
            Folio = folio;
			TipoFase = tipofase;
			Fase = fase;
			FechaSolicitud = fechaSolicitud;
            FechaSurtido = fechaSurtido;
		}
		
		public String getRecargaId()
		{
			return RecargaId;
		}

		public void setRecargaId(String recargaId) { RecargaId = recargaId;	}

		public String getFolio()
		{
			return Folio;
		}

		public void setFolio(String folio)
		{
			Folio = folio;
		}

		public int getTipoFase()
		{
			return TipoFase;
		}

		public void setTipoFase(int tipoFase)
		{
			TipoFase = tipoFase;
		}

		public String getFase()
		{
			return Fase;
		}

		public void setFase(String fase)
		{
			Fase = fase;
		}

		public String getFechaSolicitud()
		{
			return FechaSolicitud;
		}

		public void setFechaSolicitud(String fechaSolicitud)
		{
			FechaSolicitud = fechaSolicitud;
		}

        public String getFechaSurtido() { return FechaSurtido; }

        public void setFechaSurtido(String fechaSurtido)
        {
            FechaSurtido = fechaSurtido;
        }
	}

	ISeleccionRecarga mVista;
	String mAccion;

	boolean iniciarActividad;
	Class<?> actvdd;
	String sOrdenIdSel;

	public SeleccionarRecarga(ISeleccionRecarga vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();
            Sesion.remove(Sesion.Campo.OrdenTrabajoActual);
            Sesion.remove(Sesion.Campo.RecargaActual);
            Sesion.remove(Sesion.Campo.DevolucionActual);

            if(Sesion.get(Sesion.Campo.VistaRecargasActual)!=null)
            {
                int vista = (int)Sesion.get(Sesion.Campo.VistaRecargasActual);
                mostrarRecargas(vista);
            }
            else
                mostrarRecargas(Enumeradores.Vista.VISTA_CAPTURA);
			/*if (mVista.obtenerRecargas().length > 0)
			{
				iniciarActividad = false;
				mVista.mostrarRecargas(mVista.obtenerRecargas());
			}
			else
			{
				mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				mVista.finalizar();
				//mVista.iniciarActividadConResultado(ICapturaOrden.class, 0, null);
			}*/
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public void modificar(VistaRecargas recarga) {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("RecargaId", recarga.getRecargaId());
        mVista.iniciarActividadConResultado(ICapturaRecarga.class, 0, null, oParametros);
        //mVista.finalizar();
    }

    public void consultar(VistaRecargas recarga) {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("RecargaId", recarga.getRecargaId());
        oParametros.put("SoloLectura", "true");
        if (recarga.getTipoFase() == Enumeradores.TiposFasesDocto.SURTIDO)
            oParametros.put("MostrarTransferencia", "true");
        mVista.iniciarActividadConResultado(ICapturaRecarga.class, 0, null, oParametros);
    }

    public void confirmarCancelar(VistaRecargas recarga) {
        mVista.mostrarPreguntaSiNo("¿Desea cancelar la solicitud de traspaso " + recarga.Folio + "?", 1);
    }

    public void cancelar(VistaRecargas recarga){
        try {
            Recargas.cancelarRecarga(recarga.RecargaId);
            int vista = (int)Sesion.get(Sesion.Campo.VistaRecargasActual);
            mostrarRecargas(vista);
        } catch (Exception ex) {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void confirmarCerrar(VistaRecargas recarga){
        mVista.mostrarPreguntaSiNo("¿Desea cerrar la solicitud de traspaso " + recarga.Folio + "?", 2);
    }

    public void cerrar(VistaRecargas recarga){
        try {
            Recargas.cerrarRecarga(recarga.RecargaId);
            int vista = (int)Sesion.get(Sesion.Campo.VistaRecargasActual);
            mostrarRecargas(vista);
        } catch (Exception ex) {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void mostrarRecargas(int vista){
        try {
            Sesion.set(Sesion.Campo.VistaRecargasActual, vista);
            SeleccionarRecarga.VistaRecargas[] recargas;
            recargas = Consultas.ConsultasRecarga.obtenerRecargas(vista);
            mVista.mostrarRecargas(recargas);
            mVista.actualizarTitulo();
        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }
    }

}
