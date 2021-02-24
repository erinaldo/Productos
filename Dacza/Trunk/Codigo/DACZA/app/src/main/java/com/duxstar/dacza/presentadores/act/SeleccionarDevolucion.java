package com.duxstar.dacza.presentadores.act;

import com.duxstar.dacza.actividades.Devoluciones;
import com.duxstar.dacza.actividades.Recargas;
import com.duxstar.dacza.datos.Devolucion;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.ICapturaDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ISeleccionRecarga;

import java.util.HashMap;

public class SeleccionarDevolucion extends Presentador
{

	public static class VistaDevoluciones
	{
		private String DevolucionId;
		private String Folio;
		private int TipoFase;
		private String Fase;
		private String Fecha;

        public VistaDevoluciones(){}

		public VistaDevoluciones(String devolucionId, String folio, int tipofase, String fase, String fecha)
		{
			DevolucionId = devolucionId;
            Folio = folio;
			TipoFase = tipofase;
			Fase = fase;
			Fecha = fecha;
		}

		public String getDevolucionId()
		{
			return DevolucionId;
		}

		public void setDevolucionId(String devolucionId) { DevolucionId = devolucionId;	}

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

		public String getFecha()
		{
			return Fecha;
		}

		public void setFecha(String fecha)
		{
			Fecha = fecha;
		}

	}

	ISeleccionDevolucion mVista;
	String mAccion;

	boolean iniciarActividad;

	public SeleccionarDevolucion(ISeleccionDevolucion vista, String accion)
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

            if(Sesion.get(Sesion.Campo.VistaDevolucionesActual)!=null)
            {
                int vista = (int)Sesion.get(Sesion.Campo.VistaDevolucionesActual);
                mostrarDevoluciones(vista);
            }
            else
                mostrarDevoluciones(Enumeradores.Vista.VISTA_CAPTURA);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public void modificar(VistaDevoluciones devolucion) {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("DevolucionId", devolucion.getDevolucionId());
        mVista.iniciarActividadConResultado(ICapturaDevolucion.class, 0, null, oParametros);
        //mVista.finalizar();
    }

    public void consultar(VistaDevoluciones devolucion) {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("DevolucionId", devolucion.getDevolucionId());
        oParametros.put("SoloLectura", "true");
        mVista.iniciarActividadConResultado(ICapturaDevolucion.class, 0, null, oParametros);
    }

    public void confirmarCancelar(VistaDevoluciones devolucion) {
        mVista.mostrarPreguntaSiNo("¿Desea cancelar la devolución " + devolucion.Folio + "?", 1);
    }

    public void cancelar(VistaDevoluciones devolucion){
        try {
            Devoluciones.cancelarDevolucion(devolucion.DevolucionId);
            int vista = (int)Sesion.get(Sesion.Campo.VistaDevolucionesActual);
            mostrarDevoluciones(vista);
        } catch (Exception ex) {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void confirmarCerrar(VistaDevoluciones devolucion){
        mVista.mostrarPreguntaSiNo("¿Desea cerrar la devolución " + devolucion.Folio + "?", 2);
    }

    public void cerrar(VistaDevoluciones devolucion){
        try {
            Devoluciones.cerrarDevolucion(devolucion.DevolucionId);
            int vista = (int)Sesion.get(Sesion.Campo.VistaDevolucionesActual);
            mostrarDevoluciones(vista);
        } catch (Exception ex) {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void mostrarDevoluciones(int vista){
        try {
            Sesion.set(Sesion.Campo.VistaDevolucionesActual, vista);
            VistaDevoluciones[] devolucioneses;
            devolucioneses = Consultas.ConsultasDevolucion.obtenerDevoluciones(vista);
            mVista.mostrarDevoluciones(devolucioneses);
            mVista.actualizarTitulo();
        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }
    }

}
