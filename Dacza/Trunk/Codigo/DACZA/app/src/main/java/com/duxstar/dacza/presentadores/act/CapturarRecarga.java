package com.duxstar.dacza.presentadores.act;

import java.io.File;
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
import android.os.Environment;
import android.util.Log;

import com.duxstar.dacza.actividades.Folios;
import com.duxstar.dacza.actividades.Recargas;
import com.duxstar.dacza.datos.Articulo;
import com.duxstar.dacza.datos.RECDetalle;
import com.duxstar.dacza.datos.Recarga;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.presentadores.Enumeradores.TiposMovimientos;
import com.duxstar.dacza.presentadores.Presentador;
import com.duxstar.dacza.presentadores.interfaces.ICapturaRecarga;
import com.duxstar.dacza.presentadores.interfaces.IConsultaTraspaso;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.utilerias.KeyGen;

public class CapturarRecarga extends Presentador
{

    ICapturaRecarga mVista;
	String mAccion;
	Recarga recarga;
    String sRecargaId;
    boolean bEsNuevo = true;
    public boolean errorFinalizar = false;

	public CapturarRecarga(ICapturaRecarga vista, String accion)
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

            if (bEsNuevo) {
                StringBuilder byRefMensaje = new StringBuilder();
                recarga = Recargas.generarRecarga(byRefMensaje);
                Sesion.set(Sesion.Campo.SiguientePartida, 1);
                Sesion.set(Campo.RecargaActual, recarga.RecargaId);
                if (byRefMensaje.length() > 0) {
                    mVista.mostrarAdvertencia(byRefMensaje.toString());
                }
                BDTerm.guardarInsertar(recarga);
            }
            else {
                recarga = Recargas.recuperarRecarga(sRecargaId);
            }

            mVista.setFolio(recarga.Folio);
            mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(recarga.FechaSolicitud));
        }
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public Recarga getRecarga()
    {
        return recarga;
    }

    public void setRecargaId(String recargaId){
        bEsNuevo = false;
        sRecargaId = recargaId;
    }

    public void guardar(boolean cerrar)
    {
        try
        {
            if(bEsNuevo)
                Folios.confirmar(TiposMovimientos.RECARGA_INVENTARIO);
            if(cerrar)
                recarga.Fase = Enumeradores.TiposFasesDocto.CERRADO;

            BDTerm.guardarInsertar(recarga);
            BDTerm.commit();
        }
        catch (Exception e)
        {
            errorFinalizar = true;
            mVista.mostrarError(e.getMessage());
        }
    }

	public boolean agregarArticulo(Articulo articulo, String articuloDesc, Float cantidad, String tituloFoto, final StringBuilder refError)
	{
		try
		{
			RECDetalle detalle = null;
					
		    detalle = generarDetalle(articulo, articuloDesc, cantidad, tituloFoto);

            if (detalle == null)
                return false;

			BDTerm.guardarInsertar(detalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(recarga.RecargaId);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	public boolean actualizarDetalle(RECDetalle detalle, Float cantidad, String tituloFoto, final StringBuilder refError)
	{
		try
		{
			detalle.cantidadModificada = true;
            detalle.Cantidad = cantidad;
            if (!tituloFoto.equals(""))
                detalle.Imagen = tituloFoto;
            BDTerm.guardarInsertar(detalle);

			mVista.setHuboCambios(true);
			mVista.refrescarProductos(recarga.RecargaId);
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
            RECDetalle detalle;
            if (Sesion.get(Campo.ArticuloDescActual) != null)
            {
                String descripcion = (String)Sesion.get(Campo.ArticuloDescActual);
                detalle = existe(descripcion);
            }
                else {
                Articulo articulo = (Articulo) Sesion.get(Campo.ArticuloActual);
                detalle = existe(articulo);
            }
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

	public RECDetalle existe(Articulo articulo)
	{
		for (RECDetalle detalle : recarga.RECDetalle)
		{
            if (detalle.ArticuloId != null) {
                if (detalle.ArticuloId.equals(articulo.ArticuloId))
                    return detalle;
            }
		}
		return null;
	}

    public RECDetalle existe(String articuloDesc)
    {
        for (RECDetalle detalle : recarga.RECDetalle)
        {
            if (detalle.ArticuloDesc != null) {
                if (detalle.ArticuloDesc.equals(articuloDesc))
                    return detalle;
            }
        }
        return null;
    }

	public void eliminarDetalle(RECDetalle detalle)
	{
		try
		{
			//Se elimina el movimiento seleccionado
            if (detalle.Imagen != null)
                if (!detalle.equals("")){
                    String ruta_fotos = Environment.getExternalStoragePublicDirectory("dacza") + "/Imagenes/";
                    File oFile = new File(ruta_fotos + detalle.Imagen + ".jpg");
                    if (oFile.exists())
                        oFile.delete();
                }

			recarga.RECDetalle.remove(detalle);
			BDTerm.eliminar(detalle);

			mVista.setHuboCambios(true);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private RECDetalle generarDetalle(Articulo articulo, String articuloDesc, Float cantidad, String tituloFoto)
	{
		try
		{
			RECDetalle detalle = new RECDetalle();
            detalle.DetalleId = KeyGen.getId();
            detalle.RecargaId = recarga.RecargaId;
            if (articulo != null) {
                detalle.ArticuloId = articulo.ArticuloId;
                detalle.articulo = articulo;
            }
            else {
                detalle.ArticuloDesc = articuloDesc;
                if (!tituloFoto.equals(""))
                    detalle.Imagen = tituloFoto;
            }
            detalle.Cantidad = cantidad;
            detalle.Partida = (int)Sesion.get(Sesion.Campo.SiguientePartida);
            Sesion.set(Sesion.Campo.SiguientePartida, detalle.Partida + 1);

            detalle.MFechaHora = Generales.getFechaHoraActual();
            detalle.MUsuarioId = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).UsuarioId;

            detalle.recienAgregado = true;

		    recarga.RECDetalle.add(detalle);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(recarga.RecargaId);

			return detalle;

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
			return null;
		}
	}

    @SuppressWarnings("rawtypes")
    public void insertarSeleccion(HashMap<String, RECDetalle> detalles)
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
                    agregarArticulo(oArticulo, "", ((RECDetalle) articulo.getValue()).Cantidad, "", error);
                }
                catch (Exception ex)
                {
                    mVista.mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
                }
            }
            mVista.refrescarProductos(recarga.RecargaId);
        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }
    }

    public void consultarTraspasos() {
        HashMap<String, String> oParametros = new HashMap<String, String>();
        oParametros.put("RecargaId", recarga.RecargaId);
        mVista.iniciarActividadConResultado(IConsultaTraspaso.class, 0, null, oParametros);
        //mVista.finalizar();
    }

}
