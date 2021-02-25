package com.amesol.routelite.presentadores.act;

import android.annotation.SuppressLint;
import android.database.Cursor;

import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Folios;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.InventarioTraspaso;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoUnidad;
import com.amesol.routelite.datos.Punto;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaCanje;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

public class CapturarCanje extends Presentador
{

	private ICapturaCanje mVista;
	String mAccion;
	String sClienteClave;
	TransProd transProd;
	ModuloMovDetalle moduloMovDetalle;
	Producto oProducto;
	boolean bEsNuevo;
	Vendedor vendedor;
	boolean validarExistencia = true;
	int tipoValidacionExistencia = 0;
    float puntosTransaccion = 0;
    Punto oPunto;

	public CapturarCanje(ICapturaCanje vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@SuppressLint("SimpleDateFormat")
	@Override
	public void iniciar()
	{
		try
		{
			mVista.iniciar();

			vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

			String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
			moduloMovDetalle = new ModuloMovDetalle();
			moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
			BDVend.recuperar(moduloMovDetalle);
			tipoValidacionExistencia = TiposValidacionInventario.ValidacionRestrictiva;
            oPunto = new Punto();
            oPunto.ClienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
            BDVend.recuperar(oPunto);
            puntosTransaccion = 0;

			if (transProd != null)
			{ //se paso como parametro un TransProdId, cargar el pedido
				bEsNuevo = false;
                mVista.setFolio(transProd.Folio);
                obtenerPuntosTransaccion();
                if (oPunto.isRecuperado() && !mVista.getEliminar()){
                    oPunto.Canjeados -= puntosTransaccion;
                }
			}
			else
			{ //generar uno nuevo
				bEsNuevo = true;
				StringBuilder byRefMensaje = new StringBuilder();
				transProd = Transacciones.generarTransaccionSinPrecio(moduloMovDetalle, byRefMensaje);
				if (byRefMensaje.length() >0){
					mVista.mostrarAdvertencia(byRefMensaje.toString());
				}
				byRefMensaje = null;
                BDVend.guardarInsertar(transProd);

                mVista.setFolio(transProd.Folio);
                //mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProd.FechaCaptura));
			}

            mVista.setDisponibles(oPunto.Otorgados - oPunto.Canjeados);
            mVista.setAcumulados(oPunto.Otorgados - oPunto.OtorgadosCarga);
            mVista.setPorCanjear(puntosTransaccion);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public void obtenerPuntosTransaccion(){
        puntosTransaccion = Consultas.ConsultasTransProd.obtenerPuntosPorCanjear(transProd.TransProdID);
    }

    public float getPuntosTransaccion(){
        obtenerPuntosTransaccion();
        return puntosTransaccion;
    }

    public boolean validarPuntosDisponibles(){
        return ((oPunto.Otorgados - oPunto.Canjeados) >= puntosTransaccion);
    }

    public void canjearPuntos(){
        try {
            if (mVista.getEliminar())
                oPunto.Canjeados -= puntosTransaccion;
            else
                oPunto.Canjeados += puntosTransaccion;
            oPunto.MFechaHora = Generales.getFechaHoraActual();
            oPunto.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			oPunto.Enviado = false;
            BDVend.guardarInsertar(oPunto);
        }catch (Exception e){}
    }

	public String consultarUnidadProductoExistente(String TransProdID, String ProductoClave)
	{
		String Cantidad = "0";
		String[] transProdID = TransProdID.split(",");
		try
		{
			for (int a = 0; a < transProdID.length; a++)
			{
				ISetDatos mManejo = ConsultasCantidad.OptenerCantidad(transProdID[a], ProductoClave);
				if (mManejo.getCount() != 0)
				{
					mManejo.moveToFirst();
					Cantidad = mManejo.getString(0);
				}
			}

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return Cantidad;
	}

	public String getTransaccionId()
	{
		return transProd.TransProdID;
	}

	public short getTipoFase()
	{
		return transProd.TipoFase;
	}

	public String getPCEPrecioClave()
	{
		return transProd.PCEPrecioClave;
	}

    public String getListasPrecios(){
        return transProd.CadenaListasPrecios;
    }

	public int getTipoValidacionExistencia()
	{
		return tipoValidacionExistencia;
	}

	public ModuloMovDetalle getModuloMovDetalle()
	{
		return moduloMovDetalle;
	}

	public void agregarProductoUnidad(String productoClave, int TipoUnidad, Float Cantidad, int Puntos)
	{
		generarDetalle(productoClave, TipoUnidad, Cantidad, Puntos);
	}

	public void agregarProductoDobleUnidad(String productoClave, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades, String Motivo)
	{
		//generarDetalleDobleUnidad(productoClave, hmDetalleUnidades, Motivo);
	}

	public void agregarProductoUnidad(TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
		generarDetalle(transProdDetalle, refrescarListado);
	}

	public void agregarTransaccion(String transProdId) throws Exception
	{
		transProd = Transacciones.Pedidos.ObtenerPedido(transProdId);
	}

	private void generarDetalle(String productoClave, int TipoUnidad, Float Cantidad, int Puntos)
	{

		String byRefMensaje = "";
		try
		{
			transProd = Transacciones.Pedidos.ActualizarMovimientoInventario(getTransaccionId(), moduloMovDetalle, byRefMensaje, 0, transProd);
			BDVend.guardarInsertar(transProd);
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

		try
		{
			StringBuilder byRefError = new StringBuilder();
			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetalleCanjes(transProd.TransProdID, productoClave, TipoUnidad, Cantidad, Puntos, byRefError);
			if ( byRefError.length()>0){
				mVista.mostrarAdvertencia(byRefError.toString());
			}
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
			}
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");
			else
			{
				BDVend.guardarInsertar(transProdDetalle);
                mVista.refrescarProductos(getTransaccionId());
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

		//validar si se genero un nuevo encabezado para agregar al array

	}

	private void generarDetalle(TransProdDetalle transProdDetalle, boolean refrescarListado)
	{
		try
		{
			String byRefMensaje = "";

            transProd = Transacciones.Pedidos.ActualizarMovimientoInventario(getTransaccionId(), moduloMovDetalle, byRefMensaje, 0, transProd);

			BDVend.guardarInsertar(transProd);

			transProdDetalle.TransProdID = transProd.TransProdID;
			ProductoUnidad oPU = new ProductoUnidad();
			oPU.ProductoClave = transProdDetalle.ProductoClave;
			oPU.PRUTipoUnidad = (short)transProdDetalle.TipoUnidad;
			BDVend.recuperar(oPU);

			transProdDetalle.Precio = oPU.ValorPuntos;
			transProdDetalle.Subtotal = oPU.ValorPuntos * transProdDetalle.Cantidad;
			transProdDetalle.Total = transProdDetalle.Subtotal;

			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID);
			}

			if (transProdDetalle == null)
				throw new ControlError("MDB042302");

			BDVend.guardarInsertar(transProdDetalle);
			mVista.refrescarProductos(getTransaccionId());

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
		}

	}

	public void eliminarDetalle(String transProdId, int TipoUnidad, String transProdDetalleId, String productoClave, float Cantidad)
	{
		try
		{
			TransaccionesDetalle.Pedidos.EliminarDetalleSinMov(transProdId, transProdDetalleId);
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				Inventario.ActualizarInventario(productoClave, TipoUnidad, Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
			}
			mVista.refrescarProductos(getTransaccionId());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void eliminarDetalleDobleUnidad(String transProdId, String transProdDetalleId, String productoClave, HashMap<Short,InventarioDobleUnidad.DetalleProductoDobleUnidad>hmDetalleUnidades)
	{
		try
		{
			TransaccionesDetalle.Pedidos.EliminarDetalleSinMovDobleUnidad(transProdId, transProdDetalleId);
			if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
			{
				InventarioDobleUnidad.ActualizarInventario(productoClave, hmDetalleUnidades, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, true);
			}
			mVista.refrescarProductos(getTransaccionId());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void asignarGuardarValores(String sNombre, String sNombreArchivo) throws Exception
	{
        if (transProd != null) {
            transProd.Subtotal = puntosTransaccion;
            transProd.Total = puntosTransaccion;
            BDVend.guardarInsertar(transProd);
        }

        MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        Folios.confirmar(Sesion.get(Campo.ModuloMovDetalleClave).toString());

        if (!sNombre.equals("") && !sNombreArchivo.equals("")) {
            TRPVtaAcreditada firmaDigital = new TRPVtaAcreditada();
            firmaDigital.TransProdID = transProd.TransProdID;
            BDVend.recuperar(firmaDigital);
            firmaDigital.NombreFirma = sNombre;
            firmaDigital.IdImagenFirma = sNombreArchivo;
            firmaDigital.MFechaHora = Generales.getFechaHoraActual();
            firmaDigital.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            firmaDigital.Enviado = false;
            BDVend.guardarInsertar(firmaDigital);
        }

        BDVend.commit();

        if (motConfig.get("MensajeImpresion").equals("1"))
        {
            mVista.mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
        }else if (motConfig.get("MensajeImpresion").equals("2")){
            mVista.mostrarToast(Mensajes.get("E0934"));
            mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            mVista.finalizar();
        }
	}

	public void imprimirTicket() throws Exception
	{
		Recibos recibo = new Recibos();

        short numImpresiones = 0;
        try {
            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
            }
        }catch (Exception ex){
            mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
            numImpresiones = 0;
        }
		recibo.imprimirRecibos(generarDocsAImprimir(), true, mVista, numImpresiones);

	}

    public List<Map<String, String>> generarDocsAImprimir()
    {
        ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir("'" + transProd.TransProdID + "'");
        Cursor c = (Cursor) datos.getOriginal();

        List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
        Map<String, String> registro;
        String descValor = "";
        while (c.moveToNext())
        {
            registro = new HashMap<String, String>();
            for (int i = 0; i < c.getColumnCount(); i++)
            {
                registro.put(c.getColumnName(i), c.getString(i));
            }
            NumberFormat numberFormat = new DecimalFormat("$#,##0.00");
            registro.put("Total", numberFormat.format(c.getDouble(c.getColumnIndex("Total"))));
            descValor = ValoresReferencia.getDescripcion(c.getString(c.getColumnIndex("VARCodigo")), c.getString(c.getColumnIndex("Tipo")));
            registro.put("DescTipo", descValor);
            registro.put("TipoRecibo", "30");
            tabla.add(registro);
        }

        datos.close();

        // aTransProdIds.toString().replace("[", "'").replace("]",
        // "'").replace(", ", "','")
        return tabla;
    }

    public void solicitarFirma()
    {
        if (Consultas2.ConsultasPerfil.validarPermisoFirma(moduloMovDetalle.TipoIndice)) {
            HashMap<String, Object> oParametros = new HashMap<String, Object>();
            oParametros.put("TransProdID", transProd.TransProdID);
            mVista.iniciarActividadConResultado(ICapturaFirma.class, Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA, Enumeradores.Acciones.ACCION_CAPTURAR_FIRMA, oParametros);
        }else{
            mVista.guardar("", "");
        }
    }

}
