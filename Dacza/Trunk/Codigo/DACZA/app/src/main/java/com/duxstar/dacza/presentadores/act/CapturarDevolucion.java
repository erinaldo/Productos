package com.duxstar.dacza.presentadores.act;

import com.duxstar.dacza.actividades.Devoluciones;
import com.duxstar.dacza.actividades.Folios;
import com.duxstar.dacza.actividades.Inventario;
import com.duxstar.dacza.actividades.Recargas;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.DEVDetalle;
import com.duxstar.dacza.datos.Devolucion;
import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.Recarga;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.TiposMovimientos;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.ICapturaDevolucion;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.presentadores.interfaces.IConsultaTraspaso;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.utilerias.KeyGen;

import java.text.SimpleDateFormat;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

//import com.duxstar.dacza.actividades.Inventario;

public class CapturarDevolucion extends Presentador
{

    ICapturaDevolucion mVista;
	String mAccion;
	Devolucion devolucion;
    String sDevolucionId;
    boolean bEsNuevo = true;
    public boolean errorFinalizar = false;

	public CapturarDevolucion(ICapturaDevolucion vista, String accion)
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

            if (bEsNuevo) {
                StringBuilder byRefMensaje = new StringBuilder();
                devolucion = Devoluciones.generarDevolucion(byRefMensaje);
                Sesion.set(Campo.SiguientePartida, 1);
                Sesion.set(Campo.DevolucionActual, devolucion.DevolucionId);
                if (byRefMensaje.length() > 0) {
                    mVista.mostrarAdvertencia(byRefMensaje.toString());
                }
                BDTerm.guardarInsertar(devolucion);
            }
            else {
                devolucion = Devoluciones.recuperarDevolucion(sDevolucionId);
            }

            mVista.setFolio(devolucion.Folio);
            mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(devolucion.Fecha));
        }
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public Devolucion getDevolucion()
    {
        return devolucion;
    }

    public void setDevolucionId(String devolucionId){
        bEsNuevo = false;
        sDevolucionId = devolucionId;
    }

    public void guardar(boolean cerrar)
    {
        try
        {
            if(bEsNuevo)
                Folios.confirmar(TiposMovimientos.DEVOLUCION_INVENTARIO);
            if(cerrar)
                devolucion.Fase = Enumeradores.TiposFasesDocto.CERRADO;

            BDTerm.guardarInsertar(devolucion);
            BDTerm.commit();
        }
        catch (Exception e)
        {
            errorFinalizar = true;
            mVista.mostrarError(e.getMessage());
        }
    }

	public boolean agregarArticulo(Articulo articulo, Float Cantidad, final StringBuilder refError)
	{
		try
		{
			DEVDetalle detalle = null;
            AtomicReference<Float> existencia = new AtomicReference<Float>();

            //Verificar la salida de inventario disponible
            if (!Inventario.ValidarExistencia(articulo.ArticuloId, Cantidad, existencia, refError))
            {
                if (existencia.get() != null && existencia.get() > 0)
                {
                    mVista.setCantidadCaptura(existencia.get());
                }else{
                    mVista.setCantidadCaptura(Cantidad);
                }
                return false;
            }

		    detalle = generarDetalle(articulo, Cantidad);
            Inventario.ActualizarInventario(articulo.ArticuloId, Cantidad, Enumeradores.TiposMovimientoInv.SALIDA);

            if (detalle == null)
                return false;

			BDTerm.guardarInsertar(detalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(devolucion.DevolucionId);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	public boolean actualizarCantidad(DEVDetalle detalle, Float cantidad, final StringBuilder refError)
	{
		try
		{
            AtomicReference<Float> existencia = new AtomicReference<Float>();
            //Verificar la salida de inventario disponible
            if (!Inventario.ValidarExistencia(detalle.ArticuloId, cantidad, detalle.Cantidad, existencia, refError))
            {
                if (existencia.get() != null && existencia.get() > 0)
                {
                    mVista.setCantidadCaptura(detalle.Cantidad +  existencia.get());
                }else{
                    mVista.setCantidadCaptura(detalle.Cantidad);
                }
                return false;
            }

            //Cancelar la salida
            Inventario.ActualizarInventario(detalle.ArticuloId, detalle.Cantidad, Enumeradores.TiposMovimientoInv.ENTRADA);

            detalle.cantidadModificada = true;
            detalle.Cantidad = cantidad;
            BDTerm.guardarInsertar(detalle);
            //Dar salida a la nueva cantidad
            Inventario.ActualizarInventario(detalle.ArticuloId, detalle.Cantidad, Enumeradores.TiposMovimientoInv.SALIDA);

			mVista.setHuboCambios(true);
			mVista.refrescarProductos(devolucion.DevolucionId);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

    public Float consultarArticuloExistente()
    {
        try
        {
            DEVDetalle detalle;

            Articulo articulo = (Articulo) Sesion.get(Campo.ArticuloActual);
            detalle = existe(articulo);

            if (detalle != null)
                return detalle.Cantidad;
        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        return (float)0;
    }

	public DEVDetalle existe(Articulo articulo)
	{
		for (DEVDetalle detalle : devolucion.DEVDetalle)
		{
            if (detalle.ArticuloId != null) {
                if (detalle.ArticuloId.equals(articulo.ArticuloId))
                    return detalle;
            }
		}
		return null;
	}

	public void eliminarDetalle(DEVDetalle detalle)
	{
		try
		{
			//Se elimina el movimiento seleccionado
			devolucion.DEVDetalle.remove(detalle);
			BDTerm.eliminar(detalle);
			mVista.setHuboCambios(true);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private DEVDetalle generarDetalle(Articulo articulo, Float cantidad)
	{
		try
		{
			DEVDetalle detalle = new DEVDetalle();
            detalle.DevolucionId = devolucion.DevolucionId;
            detalle.ArticuloId = articulo.ArticuloId;
            detalle.articulo = articulo;
            detalle.Cantidad = cantidad;
            detalle.Partida = (int)Sesion.get(Campo.SiguientePartida);
            Sesion.set(Campo.SiguientePartida, detalle.Partida + 1);

            detalle.MFechaHora = Generales.getFechaHoraActual();
            detalle.MUsuarioId = ((Usuario) Sesion.get(Campo.UsuarioActual)).UsuarioId;

            detalle.recienAgregado = true;

		    devolucion.DEVDetalle.add(detalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(devolucion.DevolucionId);

			return detalle;

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
			return null;
		}
	}

    @SuppressWarnings("rawtypes")
    public void insertarSeleccion(HashMap<String, DEVDetalle> detalles)
    {
        try
        {
            Iterator it = detalles.entrySet().iterator();
            while (it.hasNext())
            { //recorrer los productos
                Map.Entry articulo = (Map.Entry) it.next();
                String articuloId = articulo.getKey().toString();
                boolean validar = false;
                Articulo oArticulo = new Articulo();
                oArticulo.ArticuloId = articuloId;
                BDTerm.recuperar(oArticulo);

                try
                {
                    StringBuilder error = new StringBuilder();
                    agregarArticulo(oArticulo, ((DEVDetalle) articulo.getValue()).Cantidad, error);
                }
                catch (Exception ex)
                {
                    mVista.mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
                }
            }
            mVista.refrescarProductos(devolucion.DevolucionId);
        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }
    }

}
