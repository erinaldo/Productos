package com.amesol.routelite.actividades;

import android.text.TextUtils;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.PromocionRegla;
import com.amesol.routelite.datos.Punto;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TPDDesProntoPago;
import com.amesol.routelite.datos.TpdPun;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpPrp;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.Vista;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.ListIterator;
import java.util.Set;

public class Promociones2
{
	private TransProd oTransProd;
	//private String sPrecioClave;
	private ArrayList<ProductoPRM> dsProductosTRP;
	private ISetDatos dsPromocion;
	private HashMap<String, ArrayList<PromocionProducto>> dsProductoPromocion;
	private ArrayList<PromocionProducto> aPromocionProducto;
	private Hashtable<String, Promocion> oPromociones;
	private Cliente oCliente;
	private boolean AfectoImpuestos;
	private String sUsuarioId;
	public Hashtable<String, Promocion> PRMProductoApp;
	public Promocion promocionActual;

	private int indiceProductosTRP = 0;
	private int indiceAPromocionProducto = 0;

	public Regla reglaActual;
	public ReglaAcumulado reglaAcumActual;

	private Vista mVista;
    private boolean bJerarquiaPorTipoAplicacion = false;

    private boolean bModificandoReparto = false;

    private String sEsquemasCte = "";
    private boolean bProntoPagoAplicada = false;
    //private boolean bSoloSobreprecio = false;

	private boolean bAplicarUnaPromoPorProducto = false;
	private ArrayList<String> sProductosAplicados;
	private Hashtable<String, String> htProductosAplicados;
	private boolean bAplicarSiemprePromoEsqProd = false;

	public Promociones2(TransProd oTransProd , boolean modificandoReparto) throws Exception
	{
		this.oTransProd = oTransProd;

		this.AfectoImpuestos = false;
		this.PRMProductoApp = new Hashtable<String, Promocion>();
		Usuario oUsuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		sUsuarioId = oUsuario.USUId;

		oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
        bModificandoReparto = modificandoReparto;
	}

	public Promociones2(TransProd oTransProd, Vista vista) throws Exception
	{
		this.oTransProd = oTransProd;

		this.AfectoImpuestos = false;
		this.PRMProductoApp = new Hashtable<String, Promocion>();
		Usuario oUsuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		sUsuarioId = oUsuario.USUId;

		oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

		mVista = vista;
	}

    public Promociones2(TransProd oTransProd, Vista vista, Boolean modificandoReparto) throws Exception
    {
        this.oTransProd = oTransProd;

        this.AfectoImpuestos = false;
        this.PRMProductoApp = new Hashtable<String, Promocion>();
        Usuario oUsuario = (Usuario) Sesion.get(Campo.UsuarioActual);
        sUsuarioId = oUsuario.USUId;

        oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
        mVista = vista;
        bModificandoReparto = modificandoReparto;
    }

	public Promociones2()
	{

	}

	//Regresa false si no se cambio nada, porque no habia promociones
	public boolean Preparar() throws Exception
	{
		boolean bHuboPromociones = false;
		boolean bHuboRegalados = false;
        oTransProd.AplicaSobreprecio = false;
		//Recuperar productos que otorgaron una promocion
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
		//ListaPrecio oPrecio = new ListaPrecio();
		//Impuestos oImpuesto = new Impuestos();
		Descuento oDescuento = new Descuento();
		Impuesto[] oImpuestos;
		//String sTransProdID = null;
		//String sTransProdIDFondoCristal = null;
		ArrayList<TransProdDetalle> tpdEliminados = new ArrayList<TransProdDetalle>();
		sProductosAplicados = new ArrayList<>();
		htProductosAplicados = new Hashtable<>();

		while (oDetalles.hasNext())
		{
			TransProdDetalle oTPD = oDetalles.next();
			if (oTPD.Promocion == 1 && oTPD.Total != 0)
			{
				bHuboPromociones = true;
                //No se recaptura el TPDDatosExtra ya que no cambia la lista de Precios aplicada
                StringBuilder sPrecioClave = new StringBuilder();
				float nPrecio = ListaPrecio.BuscarPrecio(oTPD.ProductoClave, (short) oTPD.TipoUnidad, oTransProd.CadenaListasPrecios, sPrecioClave,oTPD.Cantidad);

				if (nPrecio >= 0)
				{
					oTPD.Precio = nPrecio;
					if (oTPD.Cantidad == 0)
					{
						Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTrpPrp.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                        Consultas.ConsultasTPDDatosExtra.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
                        Consultas.ConsultasTPDDesProntoPago.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						//if eliminarcero then
						//BDVend.eliminar(oTPD);
						//else
						oTPD.DescuentoClave = null;
						oTPD.Promocion = 0;
						oTPD.Cantidad = 0;
						oTPD.DescuentoPor = (float) 0;
						oTPD.DescuentoImp = (float) 0;
						oTPD.Impuesto = (float) 0;
						oTPD.Subtotal = 0;
						oTPD.Total = 0;
						oTPD.Enviado = false;
						oTPD.MFechaHora = Generales.getFechaActual();
						oTPD.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

					}
					else
					{
						oImpuestos = Impuestos.Buscar(oTPD.ProductoClave, oCliente.TipoImpuesto);
						oDescuento = Descuentos.BuscarDescuentosProductos(oTPD.ProductoClave);

						oTPD.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescuento, oTPD.Cantidad * oTPD.Precio, oTPD.Cantidad);
						oTPD.DescuentoPor = oTPD.DescuentoImp;
						oTPD.setSubTotal(((oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp) < 0 ? 0 : (oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp);
						oTPD.Impuesto = Impuestos.Calcular(oImpuestos, oTPD.getSubTotal(), oTPD.Precio, oTPD.Cantidad);
						oTPD.Total = oTPD.getSubTotal() + oTPD.Impuesto;
						if ( oTPD.TPDDatosExtra == null || oTPD.TPDDatosExtra.size()<=0) {
							BDVend.recuperar(oTPD, TPDDatosExtra.class);
						}

						if (oTPD.TPDDatosExtra != null && oTPD.TPDDatosExtra.size()>0) {
							oTPD.TPDDatosExtra.get(0).PrecioClave = sPrecioClave.toString();
						}else{
							TPDDatosExtra tde = new TPDDatosExtra();
							tde.TransProdID = oTPD.TransProdID;
							tde.TransProdDetalleID = oTPD.TransProdDetalleID;
							tde.PrecioClave = sPrecioClave.toString();
							tde.MUsuarioID = oTPD.MUsuarioID;
							tde.MFechaHora = Generales.getFechaHoraActual();
							tde.Enviado = false;
							oTPD.TPDDatosExtra.add(tde);
						}
						Impuestos.GuardarDetalle(oTPD, oImpuestos);
						BDVend.guardarInsertar(oTPD);
					}
				}else{
					if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("PrecioSegunCFVTipo").equals("1")){
						//No se encontro precio en la nueva lista de precios
						Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTrpPrp.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTPDDatosExtra.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						Consultas.ConsultasTPDDesProntoPago.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
						//if eliminarcero then
						//BDVend.eliminar(oTPD);
						//else
						oTPD.DescuentoClave = null;
						oTPD.Promocion = 0;
						oTPD.Cantidad = 0;
						oTPD.DescuentoPor = (float) 0;
						oTPD.DescuentoImp = (float) 0;
						oTPD.Impuesto = (float) 0;
						oTPD.Subtotal = 0;
						oTPD.Total = 0;
						oTPD.Enviado = false;
						oTPD.MFechaHora = Generales.getFechaActual();
						oTPD.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
					}
				}
			}
			else if (oTPD.Promocion == 2 || oTPD.Promocion == 3)
			{
				bHuboPromociones = true;
				bHuboRegalados = true;
				tpdEliminados.add(oTPD);
			}
		}
		boolean inventarioPorLotes = false;
		try {
			inventarioPorLotes = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("InventarioPorLotes") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("InventarioPorLotes").equals("1"));
		}catch(Exception e){}
		if (bHuboRegalados) {
            if (bModificandoReparto) {
                ListIterator<TransProdDetalle> quitarCantidad = tpdEliminados.listIterator();
                while (quitarCantidad.hasNext()) {
                    TransProdDetalle oTPD = quitarCantidad.next();
                    if (oTPD.Cantidad > 0) {
                        //Dar salida del inventario de productos de regalo

						if(inventarioPorLotes)
						{
							TPDDatosExtra tpe = new TPDDatosExtra();
							tpe.TransProdID = oTPD.TransProdID;
							tpe.TransProdDetalleID = oTPD.TransProdDetalleID;
							BDVend.recuperar(tpe);
							if(tpe.isRecuperado())
								InventarioLotes.ActualizarInventario(oTPD.ProductoClave, oTPD.TipoUnidad, tpe.Lote, oTPD.Cantidad, oTransProd.Tipo, TiposMovimientos.SALIDA, true);
						}else
							Inventario.ActualizarInventario(oTPD.ProductoClave, oTPD.TipoUnidad, oTPD.Cantidad, oTransProd.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);

						Inventario.ActualizarInventario(oTPD.ProductoClave, oTPD.TipoUnidad, oTPD.Cantidad, oTransProd.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);
                        if (oTPD.CantidadOriginal == null || oTPD.CantidadOriginal > 0) {//Solo sustituir la cantidad original la primera vez
                            oTPD.CantidadOriginal = oTPD.Cantidad;
                        }
                        oTPD.Cantidad = 0;
                        if (oTPD.Promocion == 3) {
                            oTPD.Subtotal = 0f;
                            oTPD.Impuesto = 0f;
                            oTPD.Total = 0f;
                        }
                        BDVend.guardarInsertar(oTPD);
                    }

                }
                Consultas.ConsultasTPDImpuesto.eliminarImpuestosPromocion(oTransProd.TransProdID);
            } else {
                //eliminar los detalles del objeto
                ListIterator<TransProdDetalle> eliminar = tpdEliminados.listIterator();
                while (eliminar.hasNext()) {
                    TransProdDetalle oTPD = eliminar.next();
                    oTransProd.TransProdDetalle.remove(oTPD);

                    //Dar salida del inventario de productos de regalo
					if(inventarioPorLotes)
					{
						TPDDatosExtra tpe = new TPDDatosExtra();
						tpe.TransProdID = oTPD.TransProdID;
						tpe.TransProdDetalleID = oTPD.TransProdDetalleID;
						BDVend.recuperar(tpe);
						if(tpe.isRecuperado())
							InventarioLotes.ActualizarInventario(oTPD.ProductoClave, oTPD.TipoUnidad, tpe.Lote, oTPD.Cantidad, oTransProd.Tipo, TiposMovimientos.SALIDA, true);
					}else
                    	Inventario.ActualizarInventario(oTPD.ProductoClave, oTPD.TipoUnidad, oTPD.Cantidad, oTransProd.Tipo, TiposMovimientos.SALIDA, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);

                    //eliminar manejo envase
                    Cliente cli = ((Cliente) Sesion.get(Campo.ClienteActual));
                    if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO) &&
                            cli.Prestamo && (oTransProd.Tipo == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.PEDIDO || oTransProd.Tipo == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.VENTA_CONSIGNACION)) {
                        Producto producto = new Producto();
                        producto.ProductoClave = oTPD.ProductoClave;
                        BDVend.recuperar(producto);
                        ManejoEnvase.manejoEnvaseEliminar(producto, oTPD.TipoUnidad, oTPD.Cantidad, oTPD, oTransProd);
                    }
                }
                //Borrar los registros creados con los productos regalados
                Consultas.ConsultasTPDImpuesto.eliminarImpuestosPromocion(oTransProd.TransProdID);
                Consultas.ConsultasTransProdDetalle.eliminarRegaladosYCanjes(oTransProd.TransProdID);
            }
        }

		if (bHuboPromociones)
		{
			//Quitar la marca de promoción a los demas productos
			Consultas.ConsultasTransProdDetalle.actualizarMarcaPromocion(oTransProd.TransProdID);
		}
		//Borrar productosNegados por promociones
		Consultas.ConsultasProductoNegado.eliminarProductosNegadosXPromocion(oTransProd.TransProdID);

		//Borrar los registros creados con promociones de tipo aplicacion Puntos
		if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO)
		{
			float nPuntos = Consultas.ConsultasTpdPun.obtenerPuntos(oTransProd.TransProdID);
			if (nPuntos > 0)
			{
				bHuboPromociones = true;
				//nPuntos = Math.round(nPuntos);
				//Consultas.ConsultasTpdPun.actualizarSaldo(nPuntos);

                Punto oPunto = new Punto();
                oPunto.ClienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
                BDVend.recuperar(oPunto);
                if (oPunto.isRecuperado()){
                    oPunto.Otorgados -= nPuntos;
                    oPunto.MFechaHora = Generales.getFechaHoraActual();
                    oPunto.MUsuarioID = sUsuarioId;
                    oPunto.Enviado = false;
                    BDVend.guardarInsertar(oPunto);
                }
			}
        }
		if (bHuboPromociones)
		{
			Consultas.ConsultasTpdPun.eliminar(oTransProd.TransProdID);
			BDVend.guardarInsertar(oTransProd);
		}

		return bHuboPromociones;
	}

	public void Aplicar() throws Exception
	{

        if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("JerarquiaPorTipoApl")){
			try{
				bJerarquiaPorTipoAplicacion = (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("JerarquiaPorTipoApl").equalsIgnoreCase("1") ? true : false);
			}catch(Exception ex){
				bJerarquiaPorTipoAplicacion = false;
				mVista.mostrarError("Error al obtener parámetro JerarquiaPorTipoApl ");
			}
		}

		if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarUnaPromoPorProducto")){
			try{
				bAplicarUnaPromoPorProducto = (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("AplicarUnaPromoPorProducto").equalsIgnoreCase("1") ? true : false);
			}catch(Exception ex){
				bAplicarUnaPromoPorProducto = false;
				mVista.mostrarError("Error al obtener parámetro AplicarUnaPromoPorProducto ");
			}
		}

		if (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).existeParametro("AplicarSiemprePromoEsqProd")){
			try{
				bAplicarSiemprePromoEsqProd = (((ConfigParametro)Sesion.get(Campo.ConfigParametro)).get("AplicarSiemprePromoEsqProd").equalsIgnoreCase("1") ? true : false);
			}catch(Exception ex){
				bAplicarSiemprePromoEsqProd = false;
				mVista.mostrarError("Error al obtener parámetro AplicarSiemprePromoEsqProd ");
			}
		}

		//Eliminar los registros de TrpPrp asociados al pedido		 
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
		while (oDetalles.hasNext())
		{
			TransProdDetalle oTPD = oDetalles.next();
            BDVend.recuperar(oTPD, TrpPrp.class);
			ListIterator<TrpPrp> oTrpPrp = oTPD.TrpPrp.listIterator();
			while (oTrpPrp.hasNext())
			{
				TrpPrp oTPP = oTrpPrp.next();
				BDVend.eliminar(oTPP);
			}
			oTPD.TrpPrp.clear();
		}

		//Seleccionar los productos que no se otorgaron por una promoción		
		dsProductosTRP = Consultas.ConsultasTransProd.obtenerProductosSinPromocion(oTransProd.TransProdID);
		if (dsProductosTRP.size() == 0)
		{
			terminarAplicacionListener.onTerminarAplicacion();
			return;
		}

		//Obtener los esquemas del cliente
		String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave.toString();
		sEsquemasCte = Esquemas.ObtenerEsquemas(sClienteClave, com.amesol.routelite.actividades.Enumeradores.Esquema.TipoEsquema.Cliente);

		//Obtener las promociones que aplican para la actividad y esquema del cliente
		dsPromocion = Consultas.ConsultasPromocion.obtenerAplicables(Sesion.get(Campo.ModuloMovDetalleClave).toString(), sEsquemasCte, false);
		if (dsPromocion.getCount() == 0)
		{
			//terminarAplicacionListener.onTerminarAplicacion();
            AplicarPromocionesProntoPago();
			return;
		}


		String sPromociones = "";
		ArrayList<String> aPromosEsquema = new ArrayList<String>();
		while (dsPromocion.moveToNext())
		{
			if (dsPromocion.getShort("Tipo") == 6){
				aPromosEsquema.add(dsPromocion.getString("PromocionClave"));
			}else{
				sPromociones += "'" + dsPromocion.getString("PromocionClave") + "',";
			}
		}
        if (sPromociones.length() > 0)
		    sPromociones = sPromociones.substring(0, sPromociones.length() - 1);

		//Obtener los productos para los que aplican las promociones y que se encuentran en la transaccion
		HashMap<String, ArrayList<PromocionProducto>> dsPromocionProducto = new HashMap<String, ArrayList<PromocionProducto>>();
		dsProductoPromocion = Consultas.ConsultasPromocion.obtenerProductosTrans(sPromociones,aPromosEsquema, oTransProd.TransProdID, dsPromocionProducto);
		//DatabaseUtils.dumpCursor((Cursor) dsPromocionProducto.getOriginal());
		if (dsProductoPromocion.size() == 0)
		{
			//terminarAplicacionListener.onTerminarAplicacion();
            AplicarPromocionesProntoPago();
			return;
		}

		//Recuperar las promociones aplicables		
		oPromociones = new Hashtable<String, Promocion>();
		dsPromocion.moveToFirst();
		//while (dsPromocion.moveToNext()){
		do
		{
			Promocion oPromocion = new Promocion();
			oPromocion.PromocionClave = dsPromocion.getString("PromocionClave");
			BDVend.recuperar(oPromocion);
			BDVend.recuperar(oPromocion, PromocionRegla.class);
			oPromociones.put(oPromocion.PromocionClave, oPromocion);
		}
		while (dsPromocion.moveToNext());

		try
		{
			Enumeration<String> oProms = oPromociones.keys();
			//boolean bPrimeraPromocion = true;

			//Acumular por promocion las cantidades, importes y claves de los productos que aplican para esta (Producto Acumulado)
			while (oProms.hasMoreElements())
			{
				Promocion oProm = (Promocion) oPromociones.get(oProms.nextElement());
                Hashtable<String, Integer> htProductosKit = new Hashtable<>();
                oProm.CantidadKit = 0;
                oProm.AcumuladoKit = 0;
				oProm.ProductosConCantidadkit = 0;

				int indice = 0;
				if (dsPromocionProducto.containsKey(oProm.PromocionClave))
				{
					do
					{
						ISetDatos dsCantProd = Consultas.ConsultasTransProd.obtenerCantidadesPorProducto(oTransProd.TransProdID, dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave);
						dsCantProd.moveToFirst();
						//En este codigo estan mezcladas las cantidades de acumulado y lo de kits. Al corregir algo de una
						//se debe revisar que tambien las otras queden bien.
						if (!oProm.AplicarKit && dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad > 0) {
							oProm.AplicarKit = true;
						}
                        if (dsCantProd.getFloat("Cantidad") > 0) {
                            if (oProm.AplicarKit) {
                                int nCantKit;
                                if (oProm.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad) {
									if (dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad>0) {
										nCantKit = (int) (dsCantProd.getFloat("Cantidad") / dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad);
										if(nCantKit == 0)
										{
											//oProm.ProductosConCantidadkit +=1;
											oProm.CantidadKit = 0;
										}
									}else{
										nCantKit = 0;
									}
									if (oProm.CantidadKit == 0 || (oProm.CantidadKit > nCantKit  && nCantKit>0))
                                        oProm.CantidadKit = nCantKit;
									if (nCantKit>0){ //Registra cuantos productos estan quedando registrados en el kit
										oProm.ProductosConCantidadkit +=1;
									}
                                } else {
									if (dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad>0) {
										nCantKit = (int) (dsCantProd.getFloat("Subtotal") / dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad);
									}else{
										nCantKit = 0;
									}
									if (oProm.CantidadKit == 0 || (oProm.CantidadKit > nCantKit   && nCantKit>0))
                                        oProm.CantidadKit = nCantKit;
									if (nCantKit>0){ //Registra cuantos productos estan quedando registrados en el kit
										oProm.ProductosConCantidadkit +=1;
									}
                                }

                                //if (oProm.CantidadKit > 0)
                                //{
                                    if (!htProductosKit.containsKey(dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave)){
                                        htProductosKit.put(dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave, dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad);
                                    }
                                //}
                            }
                            oProm.CantidadAcumulado += dsCantProd.getFloat("Cantidad");
                            oProm.ImporteAcumulado += dsCantProd.getFloat("Subtotal");

                            oProm.ListadoProductosAcumulados += dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave + ",";
                        }
                        else{
                            oProm.CantidadKit = 0;
							if (oProm.AplicarKit && dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad>0 ){
								if (!htProductosKit.containsKey(dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave)){
									htProductosKit.put(dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave, dsPromocionProducto.get(oProm.PromocionClave).get(indice).Cantidad);
								}
							}
                        }
						dsCantProd.close();
						indice += 1;
					}
					while (indice < dsPromocionProducto.get(oProm.PromocionClave).size());
				}

                if (oProm.ListadoProductosAcumulados.length() > 0)
                    oProm.ListadoProductosAcumulados = oProm.ListadoProductosAcumulados.substring(0, oProm.ListadoProductosAcumulados.length()-1);

                if (oProm.AplicarKit && oProm.CantidadKit > 0) {
                    Set<String> keys = htProductosKit.keySet();
					//Si no todos los productos configurados en el kit tuvieron cantidad, no aplica
					if (keys != null && oProm.ProductosConCantidadkit!= keys.size()){
						oProm.CantidadKit = 0;
					}else {
						for (String key : keys) {
							htProductosKit.put(key, htProductosKit.get(key) * oProm.CantidadKit);
							oProm.AcumuladoKit += htProductosKit.get(key);
						}
						oProm.ProductosKit = htProductosKit;
					}
                }
			}

			// Para cada producto en la transaccion
			indiceProductosTRP = 0;
			do
			{
				if (dsProductoPromocion.containsKey(dsProductosTRP.get(indiceProductosTRP).ProductoClave))
				{
					aPromocionProducto = dsProductoPromocion.get(dsProductosTRP.get(indiceProductosTRP).ProductoClave);
					break;
				}
				indiceProductosTRP += 1;
			}
			while (indiceProductosTRP < dsProductosTRP.size());

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}

		ObtenerPromocionesAAplicar();

		/*
		 * if (AfectoImpuestos){ Impuestos.Recalcular(oTransProd); }
		 * 
		 * PRMProductoApp.clear(); oPromociones.clear(); dsProductosTRP.close();
		 * dsPromocion.close(); dsPromocionProducto.close();
		 */
		return;

	}

	private void ObtenerPromocionesAAplicar() throws Exception
	{

		try
		{
			if (dsProductosTRP == null || indiceProductosTRP >= dsProductosTRP.size()) {
                if (!bProntoPagoAplicada)
                    AplicarPromocionesProntoPago();
                return;
            }

			if (aPromocionProducto != null && indiceAPromocionProducto < aPromocionProducto.size())
			{
                if (!aPromocionProducto.get(indiceAPromocionProducto).Aplicar){
                    SiguientePromocion();
                    return;
                }

				promocionActual = (Promocion) oPromociones.get(aPromocionProducto.get(indiceAPromocionProducto).PromocionClave);

				if ((promocionActual.Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado || (promocionActual.Tipo == Enumeradores.Promocion.Tipo.EsquemaProducto && !promocionActual.AplicaReglaPorProducto)) &&
                        (promocionActual.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Producto || promocionActual.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Canje) &&
						PRMProductoApp.containsKey(promocionActual.PromocionClave))
				{
					SiguientePromocion();
					return;
				}

				//ISetDatos dsCantProd = Consultas.ConsultasTransProd.obtenerCantidadesPorProducto(oTransProd.TransProdID, dsProductosTRP.get(indiceProductosTRP).ProductoClave);
				//dsCantProd.moveToFirst();
				ProductoPRM oProducto = dsProductosTRP.get(indiceProductosTRP);
				if (!promocionActual.Obligatoria) {
					if (ContieneProductosAplicados(oProducto.ProductoClave)) {
						SiguientePromocion();
						return;
					}
				}

				//dsCantProd.close();
				if (promocionActual.Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado || (promocionActual.Tipo == Enumeradores.Promocion.Tipo.EsquemaProducto && !promocionActual.AplicaReglaPorProducto) )
				{
					reglaActual = null;
					reglaAcumActual = new ReglaAcumulado(oTransProd, oProducto, promocionActual);
					reglaAcumActual.ObtenerAplicarRango();

				}
				else
				{
					reglaAcumActual = null;
					reglaActual = new Regla(oTransProd, oProducto, promocionActual);
					reglaActual.ObtenerAplicarRango();
				}
			}
			else
			{
				SiguientePromocion();
				return;
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}

	}

    private void AplicarPromocionesProntoPago() throws Exception{
        indiceAPromocionProducto = 0;
        bProntoPagoAplicada = true;

        //Seleccionar los productos que no se otorgaron por una promoción
        dsProductosTRP = Consultas.ConsultasTransProd.obtenerProductosSinPromocion(oTransProd.TransProdID);
        if (dsProductosTRP.size() == 0)
        {
			TerminarAplicacion();
            return;
        }

        //Obtener los esquemas del cliente
        //String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave.toString();
        //String sEsquemasCte = Esquemas.ObtenerEsquemas(sClienteClave, com.amesol.routelite.actividades.Enumeradores.Esquema.TipoEsquema.Cliente);

        //Obtener las promociones que aplican para la actividad y esquema del cliente
        dsPromocion = Consultas.ConsultasPromocion.obtenerAplicables(Sesion.get(Campo.ModuloMovDetalleClave).toString(), sEsquemasCte, true);
        if (dsPromocion.getCount() == 0)
        {
			TerminarAplicacion();
            return;
        }

        String sPromociones = "";
        ArrayList<String> aPromosEsquema = new ArrayList<String>();
        while (dsPromocion.moveToNext())
        {
            if (dsPromocion.getShort("Tipo") == 6){
                aPromosEsquema.add(dsPromocion.getString("PromocionClave"));
            }else{
                sPromociones += "'" + dsPromocion.getString("PromocionClave") + "',";
            }
        }
        if (sPromociones.length() > 0)
            sPromociones = sPromociones.substring(0, sPromociones.length() - 1);

        //Obtener los productos para los que aplican las promociones y que se encuentran en la transaccion
        HashMap<String, ArrayList<PromocionProducto>> dsPromocionProducto = new HashMap<String, ArrayList<PromocionProducto>>();
        dsProductoPromocion = Consultas.ConsultasPromocion.obtenerProductosTrans(sPromociones, aPromosEsquema, oTransProd.TransProdID, dsPromocionProducto);
        //DatabaseUtils.dumpCursor((Cursor) dsPromocionProducto.getOriginal());
        if (dsProductoPromocion.size() == 0)
        {
			TerminarAplicacion();
            return;
        }

        //Recuperar las promociones aplicables
        oPromociones = new Hashtable<String, Promocion>();
        dsPromocion.moveToFirst();
        //while (dsPromocion.moveToNext()){
        do
        {
            Promocion oPromocion = new Promocion();
            oPromocion.PromocionClave = dsPromocion.getString("PromocionClave");
            BDVend.recuperar(oPromocion);
            BDVend.recuperar(oPromocion, PromocionRegla.class);
            oPromociones.put(oPromocion.PromocionClave, oPromocion);
        }
        while (dsPromocion.moveToNext());

        try
        {
            Enumeration<String> oProms = oPromociones.keys();
            //boolean bPrimeraPromocion = true;

            //Acumular por promocion las cantidades, importes y claves de los productos que aplican para esta (Producto Acumulado)
            while (oProms.hasMoreElements())
            {
                Promocion oProm = (Promocion) oPromociones.get(oProms.nextElement());

                int indice = 0;
                if (dsPromocionProducto.containsKey(oProm.PromocionClave))
                {
                    do
                    {
                        ISetDatos dsCantProd = Consultas.ConsultasTransProd.obtenerCantidadesPorProducto(oTransProd.TransProdID, dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave);
                        dsCantProd.moveToFirst();

                        oProm.CantidadAcumulado += dsCantProd.getFloat("Cantidad");
                        oProm.ImporteAcumulado += dsCantProd.getFloat("Subtotal");

                        oProm.ListadoProductosAcumulados += "'" + dsPromocionProducto.get(oProm.PromocionClave).get(indice).ProductoClave + "',";

                        dsCantProd.close();
                        indice += 1;
                    }
                    while (indice < dsPromocionProducto.get(oProm.PromocionClave).size());

                    if (oProm.ListadoProductosAcumulados.length() > 0)
                        oProm.ListadoProductosAcumulados = oProm.ListadoProductosAcumulados.substring(0, oProm.ListadoProductosAcumulados.length()-1);


                    ArrayList<String> aEsquemas = new ArrayList<String>();
                    ISetDatos dsPorcentajeExcep = Consultas.ConsultasPromocion.obtenerPorcentajesExcep(oProm.PromocionClave);
                    if (dsPorcentajeExcep.getCount() > 0) {
                        dsPorcentajeExcep.moveToFirst();
                        do {
                            Productos.obtenerEsquemasHijos(dsPorcentajeExcep.getString("EsquemaId"), aEsquemas);
                            String sEsquemasProd = "";

                            if (aEsquemas.size()>0){
                                sEsquemasProd = TextUtils.join(",", aEsquemas);

                                ISetDatos dsProductosExcep = Consultas.ConsultasPromocion.obtenerProductosExcep(sEsquemasProd, oProm.ListadoProductosAcumulados);
                                String sProductoClave;
                                if (dsProductosExcep.getCount() > 0){
                                    dsProductosExcep.moveToFirst();
                                    oProm.ProductosExcepProntoPago = new Hashtable<>();
                                    do {
                                        sProductoClave = dsProductosExcep.getString("ProductoClave");
                                        if (oProm.ProductosExcepProntoPago.containsKey(sProductoClave)){
                                            float nPorcentaje = oProm.ProductosExcepProntoPago.get(sProductoClave);
                                            if (nPorcentaje < dsPorcentajeExcep.getFloat("Porcentaje")){
                                                oProm.ProductosExcepProntoPago.put(sProductoClave, dsPorcentajeExcep.getFloat("Porcentaje"));
                                            }
                                        }
                                        else{
                                            oProm.ProductosExcepProntoPago.put(sProductoClave, dsPorcentajeExcep.getFloat("Porcentaje"));
                                        }
                                    }
                                    while (dsProductosExcep.moveToNext());
                                }
                                dsProductosExcep.close();
                            }

                            aEsquemas.clear();
                        }
                        while (dsPorcentajeExcep.moveToNext());
                    }
                    dsPorcentajeExcep.close();

                    oProm.ListadoProductosAcumulados = oProm.ListadoProductosAcumulados.replace("'", "");
                    /*String[] lstProductos = oProm.ListadoProductosAcumulados.replace("'", "").split(",");
                    oProm.ListadoProductosAcumulados = "";

                    for (String sProductoClave: lstProductos){
                        if (!oProm.ProductosExcepProntoPago.containsKey(sProductoClave))
                        {
                            oProm.ListadoProductosAcumulados += "" + sProductoClave + ",";
                        }
                    }
                    if (oProm.ListadoProductosAcumulados.length() > 0)
                        oProm.ListadoProductosAcumulados = oProm.ListadoProductosAcumulados.substring(0, oProm.ListadoProductosAcumulados.length()-1);*/
                }

            }

            // Para cada producto en la transaccion
            indiceProductosTRP = 0;
            do
            {
                if (dsProductoPromocion.containsKey(dsProductosTRP.get(indiceProductosTRP).ProductoClave))
                {
                    aPromocionProducto = dsProductoPromocion.get(dsProductosTRP.get(indiceProductosTRP).ProductoClave);
                    break;
                }
                indiceProductosTRP += 1;
            }
            while (indiceProductosTRP < dsProductosTRP.size());

        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }

        ObtenerPromocionesAAplicar();

        return;
    }

    public void SiguientePromocion() throws Exception
	{
        if (aPromocionProducto != null  && indiceAPromocionProducto < aPromocionProducto.size()){
           if (!aPromocionProducto.get(indiceAPromocionProducto).Aplicar){
               indiceAPromocionProducto += 1;
               ObtenerPromocionesAAplicar();
               return;
           }
        }

        boolean bSoloSobreprecio = false;
		indiceAPromocionProducto += 1;
		if (aPromocionProducto == null || indiceAPromocionProducto >= aPromocionProducto.size())
		{
			indiceProductosTRP += 1;
			if (indiceProductosTRP >= dsProductosTRP.size())
			{
                if (!bProntoPagoAplicada)
                    AplicarPromocionesProntoPago();
                else
				    TerminarAplicacion();
				return;
			}
			else
			{
				promocionActual = null;
				aPromocionProducto = null;
				do
				{
					if (dsProductoPromocion.containsKey(dsProductosTRP.get(indiceProductosTRP).ProductoClave))
					{
						aPromocionProducto = dsProductoPromocion.get(dsProductosTRP.get(indiceProductosTRP).ProductoClave);
						indiceAPromocionProducto = 0;
						break;
					}
					indiceProductosTRP += 1;
				}
				while (indiceProductosTRP < dsProductosTRP.size());
				if (indiceProductosTRP >= dsProductosTRP.size())
				{
                    if (!bProntoPagoAplicada)
                        AplicarPromocionesProntoPago();
                    else
                        TerminarAplicacion();
                    return;
				}
			}
		}
		if (promocionActual != null && promocionActual.Tipo != Enumeradores.Promocion.Tipo.ProductoAcumulado && (promocionActual.Tipo != Enumeradores.Promocion.Tipo.EsquemaProducto && !promocionActual.AplicaReglaPorProducto))
		{

			if (!promocionActual.PermiteCascada) {
                boolean bAplicaSigTipoAplicacion = false;

                if (bJerarquiaPorTipoAplicacion) {
                    if (aPromocionProducto != null &&  indiceAPromocionProducto < aPromocionProducto.size()){
                        do {
                            if (promocionActual.TipoAplicacion != oPromociones.get(aPromocionProducto.get(indiceAPromocionProducto).PromocionClave).TipoAplicacion) {
                                //Si encuentra una promocion con un tipoAplicacion distinto, lo toma valido aunque
                                //no se PermitaCascada, debido al parámetro bAplicaSigTipoAplicacion
                                bAplicaSigTipoAplicacion = true;
                                break;
                            }
                            indiceAPromocionProducto += 1;
                        }
                        while (indiceAPromocionProducto < aPromocionProducto.size());
                    }
                    //En este escenario se busca la siguiente promocion del producto con un diferente tipo Aplicacion
                    //Las promociones deben estar por jerarquia y en orden de Tipo Aplicacion para que este codigo funcione
                    //Se deja asi el codigo por falta de tiempo para el desarrollo
                }
				else {
                    int nIndiceTemp = indiceAPromocionProducto;
                    bSoloSobreprecio = true;
                    if (aPromocionProducto != null &&  nIndiceTemp < aPromocionProducto.size()){
                        do {
							if (oPromociones.get(aPromocionProducto.get(nIndiceTemp).PromocionClave).Tipo == Enumeradores.Promocion.Tipo.EsquemaProducto){
								if (!bAplicarSiemprePromoEsqProd)
									aPromocionProducto.get(nIndiceTemp).Aplicar = false;
							}else if (oPromociones.get(aPromocionProducto.get(nIndiceTemp).PromocionClave).Tipo != Enumeradores.Promocion.Tipo.Sobreprecio)
                                aPromocionProducto.get(nIndiceTemp).Aplicar = false;
                            nIndiceTemp += 1;
                        }
                        while (nIndiceTemp < aPromocionProducto.size());
                    }
                }

                //Si no siguio una TipoAplicacion distinto para el mismo producto
                if (!bAplicaSigTipoAplicacion && !bSoloSobreprecio) {

                    indiceProductosTRP += 1;
                    if (indiceProductosTRP >= dsProductosTRP.size()) {
                        if (!bProntoPagoAplicada)
                            AplicarPromocionesProntoPago();
                        else
                            TerminarAplicacion();
                        return;
                    } else {
                        promocionActual = null;
                        aPromocionProducto = null;
                        do {
                            if (dsProductoPromocion.containsKey(dsProductosTRP.get(indiceProductosTRP).ProductoClave)) {
                                aPromocionProducto = dsProductoPromocion.get(dsProductosTRP.get(indiceProductosTRP).ProductoClave);
                                indiceAPromocionProducto = 0;
                                break;
                            }
                            indiceProductosTRP += 1;
                        }
                        while (indiceProductosTRP < dsProductosTRP.size());
                        if (indiceProductosTRP >= dsProductosTRP.size()) {
                            if (!bProntoPagoAplicada)
                                AplicarPromocionesProntoPago();
                            else
                                TerminarAplicacion();
                            return;
                        }
                    }
                }
            }
		}
		ObtenerPromocionesAAplicar();
	}

	public void TerminoPromocionRegalo() throws Exception
	{
		if (reglaActual != null)
		{
			ActualizaProducto(reglaActual.oProducto.ProductoClave, reglaActual.oPromocion.PromocionClave, reglaActual.oReglaApp.PromocionReglaID);

		}
		else if (reglaAcumActual != null)
		{
			ActualizaProducto(reglaAcumActual.oProducto.ProductoClave, reglaAcumActual.oPromocion.PromocionClave, reglaAcumActual.oReglaApp.PromocionReglaID);
		}
		SiguientePromocion();
	}

	private void TerminarAplicacion() throws Exception
	{
		if (AfectoImpuestos)
		{
			Impuestos.RecalcularPromocionales(oTransProd);
		}

		if (PRMProductoApp != null)
			PRMProductoApp.clear();
		if (oPromociones != null)
			oPromociones.clear();
		if (dsProductosTRP != null)
			dsProductosTRP = null;
		if (dsPromocion != null)
			dsPromocion.close();
		if (dsProductoPromocion != null)
			dsProductoPromocion = null;

        terminarAplicacionListener.onTerminarAplicacion();
	}

    public void TerminarAplicacionSinCalculos() throws Exception
    {
        terminarAplicacionListener.onTerminarAplicacion();
    }

	private void ActualizarDescBonif(String PromocionClave, String ProductoClave, float Porcentaje, String PromocionReglaID) throws Exception
	{
		int redondeo = 2;

		if (oPromociones.containsKey(PromocionClave) && oPromociones.get(PromocionClave).TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Bonificacion){
			redondeo = 4;
            if (oPromociones.get(PromocionClave).Tipo == Enumeradores.Promocion.Tipo.Sobreprecio ) {
                oTransProd.AplicaSobreprecio = true;
                short nCFVTipo = 0;
                if (oTransProd.CFVTipo == null || oTransProd.CFVTipo == 0)
                     nCFVTipo = Consultas.ConsultasCliFormaVenta.obtenerFormaVentaInicial(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave);
                else
                    nCFVTipo = oTransProd.CFVTipo;
                if (nCFVTipo == 1)
                    return;
                Porcentaje *= -1;
            }
		}

		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
		while (oDetalles.hasNext())
		{
			TransProdDetalle oTPD = oDetalles.next();
			if (ProductoClave.equals(oTPD.ProductoClave) && (oTPD.Promocion != 2 && oTPD.Promocion != 3) && oTPD.getSubTotal() > 0)
			{
				float nSubtotal = oTPD.getSubTotal();

				oTransProd.Promocion = true;
				oTPD.Promocion = 1;
				if (oPromociones.containsKey(PromocionClave) && oPromociones.get(PromocionClave).TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Bonificacion && (oPromociones.get(PromocionClave).Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado || oPromociones.get(PromocionClave).Tipo == Enumeradores.Promocion.Tipo.Sobreprecio)){
					oTPD.DescuentoImp = Generales.getRound(oTPD.DescuentoImp + ((oTPD.Precio * oTPD.Cantidad) * Porcentaje), redondeo);
					oTPD.Subtotal = Generales.getRound(oTPD.Subtotal - ((oTPD.Precio * oTPD.Cantidad) * Porcentaje), redondeo);
				}else {
					oTPD.DescuentoImp = Generales.getRound(oTPD.DescuentoImp + (oTPD.Subtotal * Porcentaje), redondeo);
					oTPD.Subtotal = Generales.getRound(oTPD.Subtotal - (oTPD.Subtotal * Porcentaje), redondeo);
				}
				oTPD.MFechaHora = Generales.getFechaHoraActual();
				oTPD.MUsuarioID = sUsuarioId;
				oTPD.Enviado = false;
				//BDVend.guardarInsertar(oTPD);

				TrpPrp oTPP = new TrpPrp();
				oTPP.TransProdID = oTPD.TransProdID;
				oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
				oTPP.PromocionClave = PromocionClave;
				oTPP.PromocionReglaID = PromocionReglaID; //TODO: promocionreglaid
				if (oPromociones.containsKey(PromocionClave) && oPromociones.get(PromocionClave).TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Bonificacion && (oPromociones.get(PromocionClave).Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado || oPromociones.get(PromocionClave).Tipo == Enumeradores.Promocion.Tipo.Sobreprecio)) {
					oTPP.PromocionImp = Generales.getRound((oTPD.Precio * oTPD.Cantidad) * Porcentaje, redondeo);
				}else{
					oTPP.PromocionImp = Generales.getRound(nSubtotal * Porcentaje, redondeo);
				}
				oTPP.MFechaHora = Generales.getFechaHoraActual();
				oTPP.MUsuarioID = sUsuarioId;
				oTPP.Enviado = false;
				oTPD.TrpPrp.add(oTPP);

				BDVend.guardarInsertar(oTPD);
			}
		}
	}

	private void ActualizaPuntos(String PromocionClave, int TipoRango, String ProductoClave, float Porcentaje) throws Exception
	{
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
        float nPuntos = 0;
		while (oDetalles.hasNext())
		{
			TransProdDetalle oTPD = oDetalles.next();
			if (ProductoClave.equals(oTPD.ProductoClave) && (oTPD.Promocion != 2 && oTPD.Promocion != 3)  && oTPD.getSubTotal() > 0)
			{

				oTPD.Promocion = 1;
				oTransProd.Promocion = true;
				oTPD.MFechaHora = Generales.getFechaHoraActual();
				oTPD.MUsuarioID = sUsuarioId;
				oTPD.Enviado = false;

				ProductoDetalle oPRD = new ProductoDetalle();
				oPRD.ProductoClave = oTPD.ProductoClave;
				oPRD.PRUTipoUnidad = (short) oTPD.TipoUnidad;
				oPRD.ProductoDetClave = oTPD.ProductoClave;
				BDVend.recuperar(oPRD);

				TpdPun oTPP = new TpdPun();
				oTPP.TransProdID = oTPD.TransProdID;
				oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
				oTPP.PromocionClave = PromocionClave;
				if (TipoRango == Enumeradores.Promocion.TipoRango.Cantidad)
					oTPP.Puntos = (oTPD.Cantidad * oPRD.Factor) * Porcentaje;
				else if (TipoRango == Enumeradores.Promocion.TipoRango.Importe)
					oTPP.Puntos = (oTPD.getSubTotal() * Porcentaje);
				oTPP.MFechaHora = Generales.getFechaHoraActual();
				oTPP.MUsuarioID = sUsuarioId;
				oTPP.Enviado = false;
				oTPD.TpdPun.add(oTPP);

				BDVend.guardarInsertar(oTPD);

                nPuntos += oTPP.Puntos;
			}
		}

        if (nPuntos > 0) {
            Punto oPunto = new Punto();
            oPunto.ClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
            BDVend.recuperar(oPunto);
            if (oPunto.isRecuperado()) {
                oPunto.Otorgados += nPuntos;
            } else {
                oPunto.Otorgados = nPuntos;
                oPunto.Canjeados = 0;
                oPunto.OtorgadosCarga = 0;
            }
            oPunto.MFechaHora = Generales.getFechaHoraActual();
            oPunto.MUsuarioID = sUsuarioId;
            oPunto.Enviado = false;
            BDVend.guardarInsertar(oPunto);
        }
	}

	private void ActualizaProducto(String productoClave, String promocionClave, String PromocionReglaID) throws Exception
	{
		ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();

		while (oDetalles.hasNext())
		{
			TransProdDetalle oTPD = oDetalles.next();
			if (productoClave.equals(oTPD.ProductoClave) && (oTPD.Promocion != 2 && oTPD.Promocion != 3) && oTPD.getSubTotal() > 0)
			{
				oTPD.Promocion = 1;
				oTransProd.Promocion = true;
				oTPD.MFechaHora = Generales.getFechaHoraActual();
				oTPD.MUsuarioID = sUsuarioId;
				oTPD.Enviado = false;

				TrpPrp oTPP = new TrpPrp();
				oTPP.TransProdID = oTPD.TransProdID;
				oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
				oTPP.PromocionClave = promocionClave;
				oTPP.PromocionReglaID = PromocionReglaID; //TODO: promocionreglaid
				//oTPP.PromocionImp = Generales.getRound(nSubtotal * Porcentaje, 2) ;
				oTPP.MFechaHora = Generales.getFechaHoraActual();
				oTPP.MUsuarioID = sUsuarioId;
				oTPP.Enviado = false;
				oTPD.TrpPrp.add(oTPP);

				BDVend.guardarInsertar(oTPD);
			}
		}
	}

    private void ActualizarDescProntoPago(String PromocionClave, String ProductoClave, float Porcentaje) throws Exception
    {
        ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
        while (oDetalles.hasNext())
        {
            TransProdDetalle oTPD = oDetalles.next();
            if (ProductoClave.equals(oTPD.ProductoClave) && (oTPD.Promocion != 2 && oTPD.Promocion != 3) && oTPD.getSubTotal() > 0)
            {
                boolean bActualizar = true;
                boolean bNuevo = true;

                BDVend.recuperar(oTPD, TPDDesProntoPago.class);

                for (int i = 0; i < oTPD.TPDDesProntoPago.size(); i++){
                    if(oTPD.TPDDesProntoPago.get(i).TransProdID.equals(oTPD.TransProdID) && oTPD.TPDDesProntoPago.get(i).TransProdDetalleID.equals(oTPD.TransProdDetalleID)) {
                        bNuevo = false;
                        if (oTPD.TPDDesProntoPago.get(i).Porcentaje < Porcentaje) {
                            oTPD.TPDDesProntoPago.get(i).PromocionClave = PromocionClave;
                            oTPD.TPDDesProntoPago.get(i).Porcentaje = Porcentaje;
                            oTPD.TPDDesProntoPago.get(i).MFechaHora = Generales.getFechaHoraActual();
                            oTPD.TPDDesProntoPago.get(i).MUsuarioID = sUsuarioId;
                            oTPD.TPDDesProntoPago.get(i).Enviado = false;
                        }
                        else
                            bActualizar = false;
                        continue;
                    }
                }

                /*for(TPDDesProntoPago tpp : oTPD.TPDDesProntoPago){
                    if(tpp.TransProdID.equals(oTPD.TransProdID) && tpp.TransProdDetalleID.equals(oTPD.TransProdDetalleID))
                    {
                        bNuevo = false;
                        if (tpp.Porcentaje < Porcentaje) {
                            BDVend.recuperar(tpp);
                            tpp.PromocionClave = PromocionClave;
                            tpp.Porcentaje = Porcentaje;
                            tpp.MFechaHora = Generales.getFechaHoraActual();
                            tpp.MUsuarioID = sUsuarioId;
                            tpp.Enviado = false;
                            //BDVend.guardarInsertar(tpp);
                        }
                        else
                            bActualizar = false;

                        continue;
                    }
                }*/

                if (bActualizar) {
                    oTransProd.Promocion = true;
                    oTPD.Promocion = 1;
                    oTPD.MFechaHora = Generales.getFechaHoraActual();
                    oTPD.MUsuarioID = sUsuarioId;
                    oTPD.Enviado = false;

                    if (bNuevo) {
                        TPDDesProntoPago oTPP = new TPDDesProntoPago();
                        oTPP.TransProdID = oTPD.TransProdID;
                        oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
                        oTPP.PromocionClave = PromocionClave;
                        oTPP.Porcentaje = Porcentaje;
                        oTPP.MFechaHora = Generales.getFechaHoraActual();
                        oTPP.MUsuarioID = sUsuarioId;
                        oTPP.Enviado = false;
                        oTPD.TPDDesProntoPago.add(oTPP);
                    }

                    BDVend.guardarInsertar(oTPD);
                }
            }
        }
    }

	public Regla getReglaActual()
	{
		return reglaActual;
	}

	public ReglaAcumulado getReglaAcumActual()
	{
		return reglaAcumActual;
	}

	private void ActualizarProductosAplicados (String productoClave){
		if (bAplicarUnaPromoPorProducto) {
			if (promocionActual.Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado) {
				if (promocionActual.ListadoProductosAcumulados.length() > 0) {
					String[] aProductos = promocionActual.ListadoProductosAcumulados.split(",");
					if (aProductos != null && aProductos.length > 0) {
						for (String sProd : aProductos) {
							if (!sProductosAplicados.contains(sProd)) {
								sProductosAplicados.add(sProd);
								htProductosAplicados.put(sProd, promocionActual.PromocionClave);
							}
						}
					}
				}
			}else{
				if (!sProductosAplicados.contains(productoClave)) {
					sProductosAplicados.add(productoClave);
				}
			}
		}
	}

	private boolean ContieneProductosAplicados (String productoClave) {
		if (bAplicarUnaPromoPorProducto){
			if (promocionActual.Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado){
				if (promocionActual.ListadoProductosAcumulados.length() > 0) {
					String[] aProductos = promocionActual.ListadoProductosAcumulados.split(",");
					if (aProductos != null && aProductos.length > 0) {
						for (String sProd : aProductos) {
							if (sProductosAplicados.contains(sProd)) {
								if (htProductosAplicados.containsKey(sProd)) {
									if (htProductosAplicados.get(sProd) == promocionActual.PromocionClave)
										return false;
									else
										return true;
								}
								else
									return true;
							}
						}
					}
				}
			}else{
				if (sProductosAplicados.contains(productoClave)) {
					return true;
				}
			}
		}
		return false;
	}

	public void EliminarProductosAplicados(){
		if (bAplicarUnaPromoPorProducto) {
			Promocion oPromocion = null;
			String sProducto= "";
			if (reglaActual != null) {
				oPromocion = reglaActual.oPromocion;
				sProducto = reglaActual.oProducto.ProductoClave;
			}else if (reglaAcumActual != null)
				oPromocion = reglaAcumActual.oPromocion;

			if (oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Producto) {
				if (oPromocion.Tipo == Enumeradores.Promocion.Tipo.ProductoAcumulado) {
					if (oPromocion.ListadoProductosAcumulados.length() > 0) {
						String[] aProductos = oPromocion.ListadoProductosAcumulados.split(",");
						if (aProductos != null && aProductos.length > 0) {
							for (String sProd : aProductos) {
								if (sProductosAplicados.contains(sProd)) {
									if (htProductosAplicados.containsKey(sProd))
										htProductosAplicados.remove(sProd);
									sProductosAplicados.remove(sProd);
								}
							}
						}
					}
				} else {
					if (sProductosAplicados.contains(sProducto)) {
						sProductosAplicados.remove(sProducto);
					}
				}
			}
		}
	}

	public class Regla
	{
		TransProd oTransProd;
		ProductoPRM oProducto;
		Promocion oPromocion;
		PromocionRegla oReglaApp;
		int nCantidadGrupo;

		public Regla(TransProd oTransProd, ProductoPRM oProducto, Promocion oPromocion)
		{
			this.oTransProd = oTransProd;
			this.oProducto = oProducto;
			this.oPromocion = oPromocion;
		}

		public void ObtenerAplicarRango() throws Exception
		{
			//Si el subtotal del producto es 0 y el tipo de aplicacion es descuento, bonificacion o puntos no aplicar la promocion
			if (oProducto.Subtotal == 0 &&
					(oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Descuento ||
							oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Bonificacion ||
					oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Puntos))
			{
				SiguientePromocion();
				return;
			}

			if (ObtenerRango())
			{

				/*
				 * if(!oPromoAplicadas.containsKey(oPromocion.PromocionClave)){
				 * ArrayList<Promocion> promo = new ArrayList<Promocion>();
				 * promo.add(oPromocion);
				 * oPromoAplicadas.put(oPromocion.PromocionClave, promo); }else{
				 * ArrayList<Promocion> promo =
				 * oPromoAplicadas.get(oPromocion.PromocionClave);
				 * promo.add(oPromocion); }
				 */

				//TODO: Validacion de promocion obligatoria, preguntar al vendedor
				if (!oPromocion.Obligatoria && (promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto  && promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Canje ))
				{
					String titulo = Mensajes.get("XPromociones").concat(" - ").concat(Consultas.ConsultasValorReferencia.obtenerDescripcion("TRPTIPO", String.valueOf(oTransProd.Tipo)));
					mVista.mostrarObligatorio(Mensajes.get("P0104", oPromocion.PromocionClave + " - " + oPromocion.Nombre + "\n", oProducto.ProductoClave + "\n", (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? Mensajes.get("XCantidad") : Mensajes.get("XSubTotal")), (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? String.valueOf(oProducto.Cantidad) : String.valueOf(oProducto.Subtotal))), 99, titulo);
					return;
				}
				else
				{
					Aplicar();
					if (promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto  && promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Canje)
					{
						SiguientePromocion();
					}
					return;
				}
			}

			SiguientePromocion();
		}

		public void Aplicar() throws Exception
		{
			ActualizarProductosAplicados(oProducto.ProductoClave);
			switch (oPromocion.TipoAplicacion)
			{
				case Enumeradores.Promocion.TipoAplicacion.Descuento:
					OtorgarDescuento();
					break;
				case Enumeradores.Promocion.TipoAplicacion.Bonificacion:
					OtorgarBonificacion();
					break;
				case Enumeradores.Promocion.TipoAplicacion.Precio:
					OtorgarPrecio();
					break;
				case Enumeradores.Promocion.TipoAplicacion.Producto:
					OtorgarProducto();
					break;
				case Enumeradores.Promocion.TipoAplicacion.Puntos:
					OtorgarPuntos();
					break;
                case Enumeradores.Promocion.TipoAplicacion.Canje:
                    OtorgarCanje();
                    break;
                case Enumeradores.Promocion.TipoAplicacion.DescProntoPago:
                    OtorgarDescuentoProntoPago();
                    break;
			}

		}

		private boolean ObtenerRango()
		{

			//Recupera los rangos que aplican para la promocion (ordenados por el Minimo)
			ReglaComparator oComp = new ReglaComparator();
			Collections.sort(oPromocion.PromocionRegla, oComp);
            if (oPromocion.TipoRegla == Enumeradores.Promocion.TipoRegla.Escala)
                Collections.reverse(oPromocion.PromocionRegla);

			boolean bTerminar = false;
			float nCantidad = 0;
			nCantidadGrupo = 0;

			//Determinar el rango en que entra la cantidad o subtotal del producto, y el numero de veces que se aplicara la promocion
			ListIterator<PromocionRegla> oReglas = oPromocion.PromocionRegla.listIterator();
			while (oReglas.hasNext() && !bTerminar)
			{
				PromocionRegla oRegla = oReglas.next();

				switch (oPromocion.TipoRango)
				{
					case Enumeradores.Promocion.TipoRango.Cantidad:
						nCantidad = oProducto.Cantidad;
						break;
					case Enumeradores.Promocion.TipoRango.Importe:
						nCantidad = oProducto.Subtotal;
						break;
				}

				switch (oPromocion.TipoRegla)
				{
					case Enumeradores.Promocion.TipoRegla.Rango:
						if (nCantidad >= oRegla.Minimo && nCantidad <= oRegla.Maximo)
							nCantidadGrupo = 1;
						break;
					case Enumeradores.Promocion.TipoRegla.Grupo:
                       if (nCantidad>= oRegla.AplicacionMinima) {
                           nCantidadGrupo = (int) (nCantidad / oRegla.Minimo);
                       }
                        break;
                    case Enumeradores.Promocion.TipoRegla.Escala:
                        if (nCantidad >= oRegla.Minimo) {
                            nCantidadGrupo = (int) (nCantidad / oRegla.Maximo);
                        }
                        break;
				}

				bTerminar = (nCantidadGrupo != 0);
				if (bTerminar)
					oReglaApp = oRegla;
			}

			return (nCantidadGrupo != 0);
		}

		private boolean OtorgarDescuento() throws Exception
		{
			float nPorcentaje = 0;
			float nImpPorProducto = 0;

			switch (oPromocion.TipoRegla)
			{
				case Enumeradores.Promocion.TipoRegla.Rango:
					nPorcentaje = Generales.getRound(oReglaApp.Porcentaje / 100, 8);
					break;
				case Enumeradores.Promocion.TipoRegla.Grupo:
					float nPorc = 0;
					switch (oPromocion.TipoRango)
					{
						case Enumeradores.Promocion.TipoRango.Cantidad:
							nImpPorProducto = oProducto.Subtotal / oProducto.Cantidad;
							nPorc = (nImpPorProducto * oReglaApp.Minimo) * (oReglaApp.Porcentaje / 100);
							break;
						case Enumeradores.Promocion.TipoRango.Importe:
							nPorc = oReglaApp.Minimo * (oReglaApp.Porcentaje / 100);
							break;
					}
					nPorcentaje = nPorc * nCantidadGrupo;
					nPorcentaje = Generales.getRound(Generales.getRound(((nPorcentaje * 100) / oProducto.Subtotal), 4) / 100, 4);
					break;
			}

			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje, oReglaApp.PromocionReglaID);

			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			return true;
		}

		private boolean OtorgarBonificacion() throws Exception
		{
			float nPorcentaje = 0;
			float nImpPorProducto = 0;
			float nPorc = 0;
			float nImporteDesc = 0;
			switch (oPromocion.TipoRegla)
			{
				case Enumeradores.Promocion.TipoRegla.Rango:
					nPorcentaje = ((oReglaApp.Importe * 100) / oProducto.Subtotal) / 100;
					break;
				case Enumeradores.Promocion.TipoRegla.Grupo:
					switch (oPromocion.TipoRango)
					{
						case Enumeradores.Promocion.TipoRango.Cantidad:
							nImpPorProducto = oProducto.Subtotal / oProducto.Cantidad;
							nPorc = (oReglaApp.Importe * 100) / (nImpPorProducto * oReglaApp.Minimo);
							nImporteDesc = (nImpPorProducto * oReglaApp.Minimo) * (nPorc / 100);
							break;
						case Enumeradores.Promocion.TipoRango.Importe:
							nPorc = (oReglaApp.Importe * 100) / oReglaApp.Minimo;
							nImporteDesc = oReglaApp.Minimo * (nPorc / 100);
							break;
					}
					nPorcentaje = nImporteDesc * nCantidadGrupo;
					nPorcentaje = ((nPorcentaje * 100) / oProducto.Subtotal) / 100;
					break;
			}

			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje, oReglaApp.PromocionReglaID);

			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			return true;
		}

		private boolean OtorgarPrecio() throws Exception
		{
			//ListaPrecio oListaPrecio = new ListaPrecio();
			float nPrecio = 0;
			ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
			while (oDetalles.hasNext())
			{
				TransProdDetalle oTPD = oDetalles.next();
				if (oProducto.ProductoClave.equals(oTPD.ProductoClave) && (oTPD.Promocion != 2 && oTPD.Promocion != 3) && oTPD.getSubTotal() > 0)
				{
                    //En esta parte no es necesario hacer algo con la lista de Precios asignada
                    StringBuilder sPrecioClave = new StringBuilder();
					nPrecio = ListaPrecio.BuscarPrecio(oProducto.ProductoClave, (short) oTPD.TipoUnidad,"'" +  oReglaApp.PrecioClave + "'", sPrecioClave,oTPD.Cantidad);
					if (nPrecio >= 0)
					{
						oTPD.Promocion = 1;
						oTransProd.Promocion = true;
						oTPD.DescuentoImp = (nPrecio * oTPD.DescuentoImp) / oTPD.Precio;
						oTPD.setSubTotal((oTPD.Cantidad * nPrecio) - ((nPrecio * oTPD.DescuentoImp) / oTPD.Precio));
						oTPD.Precio = nPrecio;
						oTPD.MFechaHora = Generales.getFechaHoraActual();
						oTPD.MUsuarioID = sUsuarioId;
						oTPD.Enviado = false;

						TrpPrp oTPP = new TrpPrp();
						oTPP.TransProdID = oTPD.TransProdID;
						oTPP.TransProdDetalleID = oTPD.TransProdDetalleID;
						oTPP.PromocionClave = oPromocion.PromocionClave;
						oTPP.PromocionReglaID = oReglaApp.PromocionReglaID; //TODO: promocionreglaid
						oTPP.MFechaHora = Generales.getFechaHoraActual();
						oTPP.MUsuarioID = sUsuarioId;
						oTPP.Enviado = false;
						oTPD.TrpPrp.add(oTPP);

						BDVend.guardarInsertar(oTPD);
					}
				}
			}

			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;
			return true;
		}

		private boolean OtorgarProducto() throws Exception
		{
			oPromocion.PromocionReglaIdApp = oReglaApp.PromocionReglaID;
			oPromocion.CantidadGrupoApp = nCantidadGrupo;

			PRMProductoApp.put(oPromocion.PromocionClave, oPromocion);

			mVista.mostrarPromocionProducto(oPromocion.PromocionClave, oReglaApp.PromocionReglaID, oPromocion.CantidadGrupoApp, oTransProd.SubEmpresaId, oReglaApp.Cantidad, oProducto.ProductoClave,oTransProd.CadenaListasPrecios);

			return true;
		}

		/*
		 * public boolean GuardarProductoRegalado(){ return false; }
		 */

		private boolean OtorgarPuntos() throws Exception
		{
			float nPorcentaje = 0;
			switch (oPromocion.TipoRango)
			{
				case Enumeradores.Promocion.TipoRango.Cantidad:
					nPorcentaje = (oReglaApp.Cantidad * nCantidadGrupo) / oProducto.Cantidad;
					break;
				case Enumeradores.Promocion.TipoRango.Importe:
					nPorcentaje = (oReglaApp.Cantidad * nCantidadGrupo) / oProducto.Subtotal;
					break;
			}

			ActualizaPuntos(oPromocion.PromocionClave, oPromocion.TipoRango, oProducto.ProductoClave, nPorcentaje);

			return true;
		}
        private boolean OtorgarCanje() throws Exception
        {
            oPromocion.PromocionReglaIdApp = oReglaApp.PromocionReglaID;
            oPromocion.CantidadGrupoApp = nCantidadGrupo;

            PRMProductoApp.put(oPromocion.PromocionClave, oPromocion);

            mVista.mostrarPromocionProducto(oPromocion.PromocionClave, oReglaApp.PromocionReglaID, oPromocion.CantidadGrupoApp, oTransProd.SubEmpresaId, oReglaApp.Cantidad, oProducto.ProductoClave, oTransProd.CadenaListasPrecios);

            return true;
        }

        private boolean OtorgarDescuentoProntoPago() throws Exception
        {
            float nPorcentaje;
            if (oPromocion.ProductosExcepProntoPago != null) {
                if (oPromocion.ProductosExcepProntoPago.containsKey(oProducto.ProductoClave))
                    nPorcentaje = oPromocion.ProductosExcepProntoPago.get(oProducto.ProductoClave);
                else
                    nPorcentaje = oReglaApp.Porcentaje;
            }
            else
                nPorcentaje = oReglaApp.Porcentaje;

            ActualizarDescProntoPago(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje);
            return true;
        }
	}

	public class ReglaAcumulado
	{
		TransProd oTransProd;
		ProductoPRM oProducto;
		Promocion oPromocion;
		PromocionRegla oReglaApp;
		int nCantidadGrupo;

		public ReglaAcumulado(TransProd oTransProd, ProductoPRM oProducto, Promocion oPromocion)
		{
			this.oTransProd = oTransProd;
			this.oProducto = oProducto;
			this.oPromocion = oPromocion;
		}

		public void ObtenerAplicarRango() throws Exception
		{

			//Si el subtotal del producto es 0 y el tipo de aplicacion es descuento, bonificacion o puntos no aplicar la promocion
			if (oPromocion.ImporteAcumulado == 0 &&
					(oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Descuento ||
						oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Bonificacion ||
					    oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.Puntos ||
                        oPromocion.TipoAplicacion == Enumeradores.Promocion.TipoAplicacion.DescProntoPago) ||
                    (oPromocion.AplicarKit && oPromocion.CantidadKit == 0))
			{
				SiguientePromocion();
				return;
			}

			if (ObtenerRango())
			{
				if (!oPromocion.Obligatoria && (promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto && promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Canje))
				{
					if (oPromocion.MostrarPregunta)
					{
						String titulo = Mensajes.get("XPromociones").concat(" - ").concat(Consultas.ConsultasValorReferencia.obtenerDescripcion("TRPTIPO", String.valueOf(oTransProd.Tipo)));
						//Replace("$0$", Me.PromocionClave & "-" & Me.Nombre & vbCrLf).Replace("$1$", parsListadoProductosAcumulados & vbCrLf).Replace("$2$", IIf(TipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, "Cantidad", "Importe")).Replace("$3$", IIf(TipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, Me.Cantidad, Me.Importe)), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        //if(promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.DescProntoPago)
						mVista.mostrarObligatorio(Mensajes.get("P0104", oPromocion.PromocionClave + " - " + oPromocion.Nombre + "\n", oPromocion.ListadoProductosAcumulados + "\n", (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? Mensajes.get("XCantidad") : Mensajes.get("XSubTotal")),(oPromocion.AplicarKit ? String.valueOf(oPromocion.AcumuladoKit) : (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad ? String.valueOf(oPromocion.CantidadAcumulado) : String.valueOf(oPromocion.ImporteAcumulado)))), 99, titulo);

						//mostrarObligatorio("Aplicar?", 99);

						oPromocion.MostrarPregunta = false;
						return;
					}
					else
					{

							if (oPromocion.SeAcepto)
						{
							Aplicar();
							SiguientePromocion();
							return;
						}
					}
				}
				else
				{
					Aplicar();
					if (promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Producto  && promocionActual.TipoAplicacion != Enumeradores.Promocion.TipoAplicacion.Canje)
					{
						SiguientePromocion();
					}
					return;
				}
			}
			SiguientePromocion();
		}

		public void Aplicar() throws Exception
		{
			ActualizarProductosAplicados("");
			switch (oPromocion.TipoAplicacion)
			{
				case Enumeradores.Promocion.TipoAplicacion.Descuento:
					OtorgarDescuento();
					break;
				case Enumeradores.Promocion.TipoAplicacion.Bonificacion:
					OtorgarBonificacion();
					break;
				case Enumeradores.Promocion.TipoAplicacion.Producto:
					OtorgarProducto();
					break;
				case Enumeradores.Promocion.TipoAplicacion.Puntos:
					OtorgarPuntos();
					break;
                case Enumeradores.Promocion.TipoAplicacion.Canje:
                    OtorgarCanje();
                    break;
                case Enumeradores.Promocion.TipoAplicacion.DescProntoPago:
                    OtorgarDescuentoProntoPago();
                    break;
			}
		}

		private boolean ObtenerRango()
		{
			//Recupera los rangos que aplican para la promocion (ordenados por el Minimo)
			ReglaComparator oComp = new ReglaComparator();
			Collections.sort(oPromocion.PromocionRegla, oComp);

            if (oPromocion.TipoRegla == Enumeradores.Promocion.TipoRegla.Escala)
                Collections.reverse(oPromocion.PromocionRegla);

			boolean bTerminar = false;
			float nCantidad = 0;
			nCantidadGrupo = 0;

			//Determinar el rango en que entra la cantidad o subtotal del producto, y el numero de veces que se aplicara la promocion
			ListIterator<PromocionRegla> oReglas = oPromocion.PromocionRegla.listIterator();
			while (oReglas.hasNext() && !bTerminar)
			{
				PromocionRegla oRegla = oReglas.next();


				switch (oPromocion.TipoRango)
				{
					case Enumeradores.Promocion.TipoRango.Cantidad:
						nCantidad = oPromocion.CantidadAcumulado;
						break;
					case Enumeradores.Promocion.TipoRango.Importe:
						nCantidad = oPromocion.ImporteAcumulado;
						break;
					case Enumeradores.Promocion.TipoRango.Ambos:
						nCantidad = oPromocion.ImporteAcumulado;
				}

				switch (oPromocion.TipoRegla)
				{
					case Enumeradores.Promocion.TipoRegla.Rango:
						if (nCantidad >= oRegla.Minimo && nCantidad <= oRegla.Maximo){
							if (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Ambos){
								if (oPromocion.ListadoProductosAcumulados.length()>0){
									String[] aProductos = oPromocion.ListadoProductosAcumulados.split(",");
									if (aProductos != null && aProductos.length>0){
										if (aProductos.length>=oRegla.AplicacionMinima){
											nCantidadGrupo = 1;
										}
									}
								}
							}else{
								nCantidadGrupo = 1;
							}
						}
						break;
					case Enumeradores.Promocion.TipoRegla.Grupo:
                        //Se aplica solo si la regla dice que la aplicacion minima es menor o igual a la cantidad de la transaccion
						if (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Ambos){
							if (oPromocion.ListadoProductosAcumulados.length()>0){
								String[] aProductos = oPromocion.ListadoProductosAcumulados.split(",");
								if (aProductos != null && aProductos.length>0){
									if (aProductos.length>=oRegla.AplicacionMinima){
										nCantidadGrupo = (int) (nCantidad / oRegla.Minimo);
									}
								}
							}
						}else{
                            if (oPromocion.AplicarKit){
                                nCantidadGrupo = oPromocion.CantidadKit;
                            }
                            else {
                                if (nCantidad >= oRegla.AplicacionMinima) {
                                    nCantidadGrupo = (int) (nCantidad / oRegla.Minimo);
                                }
                            }
						}
						break;
                    case Enumeradores.Promocion.TipoRegla.Escala:
                        if (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Ambos){
                            if (oPromocion.ListadoProductosAcumulados.length()>0){
                                String[] aProductos = oPromocion.ListadoProductosAcumulados.split(",");
                                if (aProductos != null && aProductos.length>0){
                                    if (nCantidad >= oRegla.Minimo) {
                                        nCantidadGrupo = (int) (nCantidad / oRegla.Maximo);
                                    }
                                }
                            }
                        }else {
                            if (nCantidad >= oRegla.Minimo) {
                                    nCantidadGrupo = (int) (nCantidad / oRegla.Maximo);
                            }
                        }
                        break;
				}

				bTerminar = (nCantidadGrupo != 0);
				if (bTerminar)
					oReglaApp = oRegla;
			}

			return (nCantidadGrupo != 0);
		}

		private boolean OtorgarDescuento() throws Exception
		{
			float nPorcentaje = 0;
			float nImpPorProducto = 0;

			if (oPromocion.PrimeraVez)
			{
                if (oPromocion.AplicarKit){
                    oPromocion.RestoAcumulado = oPromocion.AcumuladoKit;
                }
                else {
                    oPromocion.RestoAcumulado = oReglaApp.Minimo * nCantidadGrupo;
                }
				oPromocion.PrimeraVez = false;
			}

			switch (oPromocion.TipoRegla)
			{
				case Enumeradores.Promocion.TipoRegla.Rango:
					nPorcentaje = Generales.getRound(oReglaApp.Porcentaje / 100, 4);
					break;
				case Enumeradores.Promocion.TipoRegla.Grupo:
					float nCantidad = 0;

                    if (oPromocion.AplicarKit) {
						//Se verifica que no se regrese un null antes de hacer la asignacion
						if(oPromocion.ProductosKit.get(oProducto.ProductoClave)!=null)
						{
							nCantidad = oPromocion.ProductosKit.get(oProducto.ProductoClave);
						}
						//
//                        nCantidad = oPromocion.ProductosKit.get(oProducto.ProductoClave);
                    }
                    else {
                        if (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad)
                            nCantidad = oProducto.Cantidad;
                        else
                            //Enumeradores.Promocion.TipoRango.Importe
                            nCantidad = oProducto.Subtotal;
                    }

					if (nCantidad > oPromocion.RestoAcumulado)
						nCantidad = oPromocion.RestoAcumulado;

					oPromocion.RestoAcumulado -= nCantidad;

					switch (oPromocion.TipoRango)
					{
						case Enumeradores.Promocion.TipoRango.Cantidad:
							nImpPorProducto = oProducto.Subtotal / oProducto.Cantidad;
							nPorcentaje = (nImpPorProducto * nCantidad) * (oReglaApp.Porcentaje / 100);
							break;
						case Enumeradores.Promocion.TipoRango.Importe:
							nPorcentaje = nCantidad * (oReglaApp.Porcentaje / 100);
							break;
						case Enumeradores.Promocion.TipoRango.Ambos:
							nPorcentaje = nCantidad * (oReglaApp.Porcentaje / 100);
							break;
					}
					nPorcentaje = Generales.getRound(Generales.getRound(((nPorcentaje * 100) / oProducto.Subtotal), 8) / 100, 8);
					break;
			}

			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje, oReglaApp.PromocionReglaID);

			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;

			return true;
		}

		private boolean OtorgarBonificacion() throws Exception
		{
			float nPorcentaje = 0;

			switch (oPromocion.TipoRegla)
			{
				case Enumeradores.Promocion.TipoRegla.Rango:
					//nPorcentaje = (oReglaApp.Importe * nCantidadGrupo) / oPromocion.CantidadAcumulado;
					nPorcentaje = ((oReglaApp.Importe * 100) / oPromocion.ImporteAcumulado) / 100;
					break;
				case Enumeradores.Promocion.TipoRegla.Grupo:
					nPorcentaje = (((oReglaApp.Importe * nCantidadGrupo) * 100) / oPromocion.ImporteAcumulado) / 100;
					break;
			}


			ActualizarDescBonif(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje, oReglaApp.PromocionReglaID);

			//Asignar a la variable AfectoImpuestos el valor True, para que al finalizar la aplicación de la promocion se haga el recalculo de los impuestos
			AfectoImpuestos = true;

			return true;
		}

		private boolean OtorgarProducto() throws Exception
		{
			oPromocion.PromocionReglaIdApp = oReglaApp.PromocionReglaID;
			oPromocion.CantidadGrupoApp = nCantidadGrupo;

			PRMProductoApp.put(oPromocion.PromocionClave, oPromocion);

			mVista.mostrarPromocionProducto(oPromocion.PromocionClave, oReglaApp.PromocionReglaID, oPromocion.CantidadGrupoApp, oTransProd.SubEmpresaId, oReglaApp.Cantidad, oProducto.ProductoClave, oTransProd.CadenaListasPrecios);

			return true;
		}

		private boolean OtorgarPuntos() throws Exception
		{
			float nCantidad = 0;
			float nCantidadProd = 0;
			float nPuntos = 0;
			float nPuntosAplicar = 0;
			float nPorcentaje = 0;

			if (oPromocion.PrimeraVez)
			{
				oPromocion.RestoAcumulado = oReglaApp.Minimo * nCantidadGrupo;
				oPromocion.PrimeraVez = false;
			}

			if (oPromocion.TipoRango == Enumeradores.Promocion.TipoRango.Cantidad)
				nCantidad = oProducto.Cantidad;
			else
				//Enumeradores.Promocion.TipoRango.Importe
				nCantidad = oProducto.Subtotal;

			if (nCantidad > oPromocion.RestoAcumulado)
				nCantidadProd = oPromocion.RestoAcumulado;
			else
				nCantidadProd = nCantidad;

			nPuntos = (oReglaApp.Cantidad * nCantidadGrupo) - oPromocion.PuntosAcumulado;
			nPuntosAplicar = (nCantidadProd * nPuntos) / oPromocion.RestoAcumulado;
			nPorcentaje = nPuntosAplicar / nCantidad;

			if (nPuntosAplicar > 0)
			{
				ActualizaPuntos(oPromocion.PromocionClave, oPromocion.TipoRango, oProducto.ProductoClave, nPorcentaje);
			}

			oPromocion.RestoAcumulado -= nCantidadProd;

			return true;
		}

        private boolean OtorgarCanje() throws Exception
        {
            oPromocion.PromocionReglaIdApp = oReglaApp.PromocionReglaID;
            oPromocion.CantidadGrupoApp = nCantidadGrupo;

            PRMProductoApp.put(oPromocion.PromocionClave, oPromocion);

            mVista.mostrarPromocionProducto(oPromocion.PromocionClave, oReglaApp.PromocionReglaID, oPromocion.CantidadGrupoApp, oTransProd.SubEmpresaId, oReglaApp.Cantidad, oProducto.ProductoClave, oTransProd.CadenaListasPrecios);
            return true;
        }

        private boolean OtorgarDescuentoProntoPago() throws Exception
        {
            float nPorcentaje;
            if (oPromocion.ProductosExcepProntoPago != null) {
                if (oPromocion.ProductosExcepProntoPago.containsKey(oProducto.ProductoClave))
                    nPorcentaje = oPromocion.ProductosExcepProntoPago.get(oProducto.ProductoClave);
                else
                    nPorcentaje = oReglaApp.Porcentaje;
            }
            else
                nPorcentaje = oReglaApp.Porcentaje;

            ActualizarDescProntoPago(oPromocion.PromocionClave, oProducto.ProductoClave, nPorcentaje);
            return true;
        }
	}

	public static class ProductoPRM
	{
		public String ProductoClave;
		public float Cantidad;
		public float Subtotal;

		public ProductoPRM(String sProductoClave, float nCantidad, float nSubtotal)
		{
			this.ProductoClave = sProductoClave;
			this.Cantidad = nCantidad;
			this.Subtotal = nSubtotal;
		}
	}

	public static class PromocionProducto
	{
		public String ProductoClave;
		public String PromocionClave;
		public int Jerarquia;
        public int Cantidad;
        public boolean Aplicar;

		public PromocionProducto(String sProductoClave, String sPromocionClave, int nJerarquia, int nCantidad)
		{
			this.ProductoClave = sProductoClave;
			this.PromocionClave = sPromocionClave;
			this.Jerarquia = nJerarquia;
            this.Cantidad = nCantidad;
            this.Aplicar = true;
            //this.Sobreprecio = bSobreprecio;
		}
	}

    /*public static class ProductoPromocionProntoPago{
        public String ProductoClave;
        public String PromocionClave;
        public float Porcentaje;

        public ProductoPromocionProntoPago(String sProductoClave, String sPromocionClave, float nPorcentaje){
            this.ProductoClave = sProductoClave;
            this.PromocionClave = sPromocionClave;
            this.Porcentaje = nPorcentaje;
        }
    }*/

	public static class ReglaComparator implements Comparator<PromocionRegla>
	{
		@Override
		public int compare(PromocionRegla a, PromocionRegla b)
		{
			return (int) (a.Minimo - b.Minimo);
		}
	}

	/**************** Eventos ****************************************/
	public interface onTerminarAplicacionListener
	{
		void onTerminarAplicacion();
	}

	private onTerminarAplicacionListener terminarAplicacionListener = null;

	public void setOnTerminarAplicacionListener(onTerminarAplicacionListener l)
	{
		terminarAplicacionListener = l;
	}
}
