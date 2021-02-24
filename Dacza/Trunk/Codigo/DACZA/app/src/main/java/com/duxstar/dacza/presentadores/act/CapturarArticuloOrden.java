package com.duxstar.dacza.presentadores.act;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

import android.database.Cursor;
import android.util.Log;

import com.duxstar.dacza.actividades.Folios;
//import com.duxstar.dacza.actividades.Inventario;
import com.duxstar.dacza.actividades.Inventario;
import com.duxstar.dacza.actividades.ValoresReferencia;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.OrdenTrabajo;
import com.duxstar.dacza.datos.ODTDetalle;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.TiposMovimientos;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.ICapturaArticuloOrden;
import com.duxstar.dacza.utilerias.ControlError;
import com.duxstar.dacza.utilerias.Generales;

public class CapturarArticuloOrden extends Presentador
{

    ICapturaArticuloOrden mVista;
	String mAccion;
	OrdenTrabajo ordenTrabajo;

	public CapturarArticuloOrden(ICapturaArticuloOrden vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
        //ordenTrabajo = (OrdenTrabajo)Sesion.get(Campo.OrdenTrabajoActual);
	}

	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();
			mVista.setFolio(ordenTrabajo.Folio);
			mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(ordenTrabajo.FechaIni));

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public OrdenTrabajo getOrdenTrabajo()
    {
        return ordenTrabajo;
    }

    public void actualizaObservaciones(String observaciones){
        if (observaciones == "")
            ordenTrabajo.Observacion = null;
        else
            ordenTrabajo.Observacion = observaciones;
    }

    public void actualizarOrdenTrabajo(boolean cerrar)throws Exception
    {
        ordenTrabajo.MFechaHora = Generales.getFechaHoraActual();
        ordenTrabajo.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;
        ordenTrabajo.Enviado = false;
        if (cerrar)
            ordenTrabajo.Fase = Enumeradores.TiposFasesDocto.CERRADO;
        BDTerm.guardarInsertar(ordenTrabajo);
        BDTerm.commit();
    }

	@SuppressWarnings("unchecked")
	public void recuperarDetalle(String ordenId)
	{
		try
		{
            int partida = 0;
            ordenTrabajo = new OrdenTrabajo();
            ordenTrabajo.OrdenId = ordenId;
            BDTerm.recuperar(ordenTrabajo);

            BDTerm.recuperar(ordenTrabajo, ODTDetalle.class);

            for (ODTDetalle det : ordenTrabajo.ODTDetalle)
            {
                Articulo art = new Articulo();
                art.ArticuloId = det.ArticuloId;
                BDTerm.recuperar(art);
                det.articulo = art;
                det.recienAgregado = false;
                det.cantidadModificada = false;
                if (det.Partida > partida)
                    partida = det.Partida;
            }

            partida += 1;
            Sesion.set(Campo.SiguientePartida, partida);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public int getTipoFase()
	{
		return ordenTrabajo.Fase;
	}


	public boolean agregarArticulo(Articulo articulo, Float Cantidad, final StringBuilder refError)
	{
		try
		{
			ODTDetalle detalle = null;
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
			if (detalle == null)
                return false;
            Inventario.ActualizarInventario(articulo.ArticuloId, Cantidad, Enumeradores.TiposMovimientoInv.SALIDA);


			BDTerm.guardarInsertar(detalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(ordenTrabajo.OrdenId);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	/*public boolean agregarProductoUnidad(Producto producto, TransProdDetalle transProdDetalle, short tipoMotivo, boolean busqueda)
	{
		StringBuilder error = new StringBuilder();
		return agregarProductoUnidad(producto, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, tipoMotivo, busqueda, error );
	}*/

	public boolean actualizarCantidad(ODTDetalle detalle, Float cantidad, final StringBuilder refError)
	{
		try
		{
			detalle.cantidadModificada = true;

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
            detalle.Cantidad = cantidad;
            BDTerm.guardarInsertar(detalle);
			//Dar salida a la nueva cantidad
			Inventario.ActualizarInventario(detalle.ArticuloId, detalle.Cantidad, Enumeradores.TiposMovimientoInv.SALIDA);

			mVista.setHuboCambios(true);
			mVista.refrescarProductos(ordenTrabajo.OrdenId);
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
            Articulo articulo = (Articulo)Sesion.get(Campo.ArticuloActual);
            ODTDetalle detalle = existe(articulo);
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

	public ODTDetalle existe(Articulo articulo)
	{
		for (ODTDetalle detalle : ordenTrabajo.ODTDetalle)
		{
			if (detalle.ArticuloId.equals(articulo.ArticuloId))
				return detalle;
			//else if (trp.ProductoClave.compareToIgnoreCase(producto.ProductoClave) > 0) //si la clave es mayor a la que se busca salir para no recorrer todo el array
			//	return null;
		}
		return null;
	}

	public void eliminarDetalle(ODTDetalle detalle)
	{
		try
		{
			Inventario.ActualizarInventario(detalle.ArticuloId, detalle.Cantidad, Enumeradores.TiposMovimientoInv.ENTRADA);
			//Se elimina el movimiento seleccionado
			ordenTrabajo.ODTDetalle.remove(detalle);
			BDTerm.eliminar(detalle);
			mVista.setHuboCambios(true);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private ODTDetalle generarDetalle(Articulo articulo, Float cantidad)
	{
		try
		{
			ODTDetalle detalle = new ODTDetalle();
            detalle.OrdenId = ordenTrabajo.OrdenId;
            detalle.ArticuloId = articulo.ArticuloId;
            detalle.Cantidad = cantidad;
            detalle.Partida = (int)Sesion.get(Sesion.Campo.SiguientePartida);
            Sesion.set(Sesion.Campo.SiguientePartida, detalle.Partida + 1);

            detalle.MFechaHora = Generales.getFechaHoraActual();
            detalle.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;
            detalle.Enviado = false;

            detalle.articulo = articulo;
            detalle.recienAgregado = true;

			ordenTrabajo.ODTDetalle.add(detalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(ordenTrabajo.OrdenId);

			return detalle;

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
			return null;
		}
	}

    @SuppressWarnings("rawtypes")
    public void insertarSeleccion(HashMap<String, ODTDetalle> detalles)
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
                    agregarArticulo(oArticulo, ((ODTDetalle) articulo.getValue()).Cantidad, error);
                }
                catch (Exception ex)
                {
                    mVista.mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
                }
            }
            mVista.refrescarProductos(ordenTrabajo.OrdenId);
        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }
    }

}
