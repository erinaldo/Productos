package com.amesol.routelite.actividades;

import java.util.ArrayList;
import java.util.List;
import java.util.ListIterator;
import java.util.concurrent.atomic.AtomicReference;

import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TpdPun;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpPrp;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class TransaccionesDetalle
{

	//Generar un detalle para que la busqueda de producto la regrese
	public static TransProdDetalle GenerarDetalleBusqueda(String ProductoClave, int TipoUnidad, float Cantidad, float Precio)
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

		TransProdDetalle transProdDetalle = new TransProdDetalle();
		transProdDetalle.TransProdDetalleID = KeyGen.getId();
		transProdDetalle.ProductoClave = ProductoClave;
		transProdDetalle.TipoUnidad = TipoUnidad;
		transProdDetalle.Cantidad = Cantidad;
		transProdDetalle.Precio = Precio;
		transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
		transProdDetalle.MUsuarioID = sUsuarioID;

		return transProdDetalle;
	}

	public static TransProdDetalle ObtenerDetalle(String TransProdId, String TransProdDetalleId) throws Exception
	{
		TransProdDetalle transProdDetalle = new TransProdDetalle();
		transProdDetalle.TransProdID = TransProdId;
		transProdDetalle.TransProdDetalleID = TransProdDetalleId;
		BDVend.recuperar(transProdDetalle);
		//BDVend.recuperar(transProdDetalle, TPDImpuesto.class);
		return transProdDetalle;
	}

	public static void EliminarDetalle(String TransProdId) throws Exception
	{
		Consultas.ConsultasTransProdDetalle.eliminarDetalle(TransProdId);
	}

	/*
	 * public static TransProdDetalle ActualizarTipoMotivoTransaccion(String
	 * transProdId, String transProdDetalleId, short tipoMotivo, short
	 * tipoMovimiento) throws Exception{ TransProdDetalle tpd =
	 * ObtenerDetalle(transProdId, transProdDetalleId); tpd.TipoMotivo =
	 * tipoMotivo; String moduloMovDetClave =
	 * Sesion.get(Campo.ModuloMovDetalleClave).toString(); ModuloMovDetalle
	 * modulo = new ModuloMovDetalle(); modulo.ModuloMovDetalleClave =
	 * moduloMovDetClave; BDVend.recuperar(modulo); Vendedor vendedor =
	 * (Vendedor) Sesion.get(Campo.VendedorActual); // actualizar inventario
	 * return tpd; }
	 */

	public static TransProdDetalle ActualizarTipoMotivoTransaccion(TransProdDetalle transprodDetalle, Short tipoMotivo, short tipoTransprod, Float cantidad, boolean cancelar) throws Exception
	{
		TransProdDetalle tpd = transprodDetalle;
		tpd.TipoMotivo = tipoMotivo;
		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
		String grupoMotivo = ValoresReferencia.getValor("TRPMOT", tpd.TipoMotivo.toString()).getGrupo();
		if (cancelar && tpd.TipoMotivo != 0)
		{
			if (tpd.Cantidad > cantidad)
			{
				AtomicReference<Float> refExistencia = new AtomicReference<Float>();
				StringBuilder error = new StringBuilder();
				if (!Inventario.ValidarExistencia(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad - cantidad, tipoTransprod, grupoMotivo, refExistencia, error))
				{
					throw new Exception(error.toString());
				}
			}
		}
		//TODO: actualizar inventario
		if (tpd.TipoMotivo != 0)
		{
			Inventario.ActualizarInventario(transprodDetalle.ProductoClave, transprodDetalle.TipoUnidad, transprodDetalle.Cantidad, tipoTransprod, TiposMovimientos.ENTRADA, vendedor.AlmacenID, grupoMotivo, cancelar);
		}
		return tpd;
	}

	public static class Pedidos
	{

		/*
		 * public static TransProdDetalle GenerarDetallePedido(String
		 * TransProdId, String ProductoClave, int TipoUnidad){ String sUsuarioID
		 * = ((Usuario)Sesion.get(Campo.UsuarioActual)).USUId;
		 * 
		 * TransProdDetalle transProdDetalle = new TransProdDetalle();
		 * transProdDetalle.TransProdDetalleID = KeyGen.getId();
		 * transProdDetalle.TransProdID = TransProdId;
		 * transProdDetalle.ProductoClave = ProductoClave;
		 * transProdDetalle.TipoUnidad = TipoUnidad; transProdDetalle.Cantidad =
		 * 0; transProdDetalle.Precio = 0; transProdDetalle.Subtotal = 0;
		 * transProdDetalle.Total = 0; transProdDetalle.MFechaHora =
		 * Generales.getFechaHoraActual(); transProdDetalle.MUsuarioID =
		 * sUsuarioID;
		 * 
		 * return transProdDetalle;
		 * 
		 * }
		 */

		public static void CalcularTotalesDetallePedido(TransProdDetalle transProdDetalle) throws Exception
		{

			if (transProdDetalle.Precio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

				//Descuentos
				Descuento oDescto = new Descuento();
				oDescto = Descuentos.BuscarDescuentosProductos(transProdDetalle.ProductoClave);

				transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				if (oDescto != null)
					transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);
			}

		}

		public static TransProdDetalle GenerarDetallePedido(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, float CantidadOriginal, String PrecioClave, float PrecioEspecial, String TransProdDetalleID) throws Exception
		{		
			float nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(TipoUnidad)), PrecioClave);
			if (nPrecio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

				//Descuentos
				Descuento oDescto = new Descuento();
				oDescto = Descuentos.BuscarDescuentosProductos(ProductoClave);

				TransProdDetalle transProdDetalle = new TransProdDetalle();
				if(TransProdDetalleID != null)
					transProdDetalle.TransProdDetalleID = TransProdDetalleID;
				else
					transProdDetalle.TransProdDetalleID = KeyGen.getId();
				transProdDetalle.TransProdID = TransProdId;
				transProdDetalle.ProductoClave = ProductoClave;
				transProdDetalle.TipoUnidad = TipoUnidad;
				transProdDetalle.Cantidad = Cantidad;
				if (CantidadOriginal != 0)
					transProdDetalle.CantidadOriginal = CantidadOriginal;
				else
					transProdDetalle.CantidadOriginal = (Float) null;
				if (PrecioEspecial != -1 && nPrecio != PrecioEspecial){
					transProdDetalle.PrecioBase = nPrecio;
					transProdDetalle.Precio = PrecioEspecial;
				}else{
					transProdDetalle.Precio = nPrecio;
				}

				transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				if (oDescto != null)
					transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}

		}

		public static TransProdDetalle GenerarDetallePedido(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, Short Motivo) throws Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

			TransProdDetalle transProdDetalle = new TransProdDetalle();
			transProdDetalle.TransProdDetalleID = KeyGen.getId();
			transProdDetalle.TransProdID = TransProdId;
			transProdDetalle.ProductoClave = ProductoClave;
			transProdDetalle.TipoUnidad = TipoUnidad;
			transProdDetalle.Cantidad = Cantidad;
			if (Motivo != null && Motivo != 0)
			{
				transProdDetalle.TipoMotivo = (short) Motivo;
			}
			transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
			transProdDetalle.Precio = 0;
			transProdDetalle.Subtotal = 0;
			transProdDetalle.Impuesto = 0f;
			transProdDetalle.Total = 0;

			transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
			transProdDetalle.MUsuarioID = sUsuarioID;

			return transProdDetalle;

		}

		public static TransProdDetalle GenerarDetallePedido(TransProdDetalle transProdDetalle) throws Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			transProdDetalle.TransProdDetalleID = KeyGen.getId();
			transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
			transProdDetalle.Precio = 0;
			transProdDetalle.Subtotal = 0;
			transProdDetalle.Impuesto = 0f;
			transProdDetalle.Total = 0;
			transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
			transProdDetalle.MUsuarioID = sUsuarioID;

			return transProdDetalle;

		}

		public static TransProdDetalle ActualizarDetallePedido(String TransProdId, String TransProdDetalleId, float Cantidad) throws Exception
		{
			TransProdDetalle transProdDetalle = ObtenerDetallePedido(TransProdId, TransProdDetalleId);

			//Impuestos
			Impuesto[] listaImpuestos = new Impuesto[] {};
			Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
			listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

			//Descuentos
			Descuento oDescto = new Descuento();
			oDescto = Descuentos.BuscarDescuentosProductos(transProdDetalle.ProductoClave);

			transProdDetalle.Cantidad = Cantidad;

			transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
			transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;
			transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

			transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

			transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;

			Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

			return transProdDetalle;
		}

		public static TransProdDetalle EliminarDetalle(String TransProdId, String TransProdDetalleId) throws Exception
		{			
			Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(TransProdId, TransProdDetalleId);
			Consultas.ConsultasTrpPrp.eliminarPorDetalle(TransProdId, TransProdDetalleId);
			Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(TransProdId, TransProdDetalleId);
			Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(TransProdId, TransProdDetalleId);

			float nPuntos = Consultas.ConsultasTpdPun.obtenerPuntos(TransProdId);
			if (nPuntos > 0)
			{
				nPuntos = Math.round(nPuntos);
				Consultas.ConsultasTpdPun.actualizarSaldo(nPuntos);
			}
			Consultas.ConsultasTpdPun.eliminarPorDetalle(TransProdId, TransProdDetalleId);

			TransProdDetalle transProdDetalle = ObtenerDetallePedido(TransProdId, TransProdDetalleId);
			BDVend.eliminar(transProdDetalle);
			
			
			
			return transProdDetalle;
		}

		public static TransProdDetalle EliminarDetalleSinMov(String TransProdId, String TransProdDetalleId) throws Exception
		{
			//			Consultas.ConsultasTrpPrp.eliminarPorDetalle(TransProdId, TransProdDetalleId);
			TransProdDetalle transProdDetalle = ObtenerDetallePedido(TransProdId, TransProdDetalleId);
			BDVend.eliminar(transProdDetalle);
			return transProdDetalle;
		}

		public static TransProdDetalle EliminarDetalleSinMovPedido(String TransProdId) throws Exception
		{
			ArrayList<String> mTransProdDetalle = ObtenerTransProdDetalleId(TransProdId);
			TransProdDetalle transProdDetalle = null;
			for (int a = 0; a < mTransProdDetalle.size(); a++)
			{
				transProdDetalle = ObtenerDetallePedido(TransProdId, mTransProdDetalle.get(a));
				BDVend.eliminar(transProdDetalle);

				TransProd trp = Transacciones.Pedidos.ObtenerPedido(TransProdId);

				BDVend.eliminar(trp);
			}

			return transProdDetalle;
		}

		public static boolean EliminarDetalleAjustesInventario(String TransProdId, boolean Carga) throws Exception
		{

			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			int tipoValidacionExistencia = TiposValidacionInventario.ValidacionRestrictiva;
			String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
			ModuloMovDetalle moduloMovDetalle = new ModuloMovDetalle();
			moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
			BDVend.recuperar(moduloMovDetalle);

			ArrayList<String> mTransProdDetalle = ObtenerTransProdDetalleId(TransProdId);
			TransProdDetalle transProdDetalle = null;
			for (int a = 0; a < mTransProdDetalle.size(); a++)
			{
				transProdDetalle = ObtenerDetallePedido(TransProdId, mTransProdDetalle.get(a));
				if (Carga)
				{
					AtomicReference<Float> existencia = new AtomicReference<Float>();
					StringBuilder error = new StringBuilder();
					if (!Inventario.ValidarExistencia(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, 0.0f, moduloMovDetalle, true, existencia, error))
					{
						return false;
					}

					if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar)
						Inventario.ActualizarInventario(transProdDetalle.ProductoClave, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, moduloMovDetalle.TipoTransProd, moduloMovDetalle.TipoMovimiento, vendedor.AlmacenID, true);
					BDVend.eliminar(transProdDetalle);
				}

			}
			TransProd trp = Transacciones.Pedidos.ObtenerPedido(TransProdId);
			BDVend.eliminar(trp);

			return true;
		}

		public static TransProdDetalle EliminarDetalleCarga(String TransProdId, List<TransProdDetalle> transProdDetalleCarga, int tipoTransProd, int tipoMovimiento, String almacenID, boolean cancelar) throws Exception
		{

			ArrayList<String> mTransProdDetalle = ObtenerTransProdDetalleId(TransProdId);
			TransProdDetalle transProdDetalle = null;
			for (int a = 0; a < mTransProdDetalle.size(); a++)
			{
				transProdDetalle = ObtenerDetallePedido(TransProdId, mTransProdDetalle.get(a));
				Inventario.ActualizarInventario(transProdDetalleCarga.get(a).ProductoClave, transProdDetalleCarga.get(a).TipoUnidad, transProdDetalleCarga.get(a).Cantidad, tipoTransProd, tipoMovimiento, almacenID, cancelar);
				BDVend.eliminar(transProdDetalle);
			}

			return transProdDetalle;
		}

		public static TransProdDetalle ObtenerDetallePedido(String TransProdId, String TransProdDetalleId) throws Exception
		{
			TransProdDetalle transProdDetalle = new TransProdDetalle();
			transProdDetalle.TransProdID = TransProdId;
			transProdDetalle.TransProdDetalleID = TransProdDetalleId;
			BDVend.recuperar(transProdDetalle);
			BDVend.recuperar(transProdDetalle, TPDImpuesto.class);
			return transProdDetalle;
		}

		public static ArrayList<String> ObtenerTransProdDetalleId(String TransProdId) throws Exception
		{
			ArrayList<String> mDatos = new ArrayList<String>();
			ISetDatos mTransProd = Consultas.ConsultasProducto.obtenerTransDetalleid(TransProdId);
			while (mTransProd.moveToNext())
			{
				mDatos.add(mTransProd.getString(0));

			}
			mTransProd.close();
			return mDatos;
		}

		//Generar un detalle para que los productosRegalados
		public static TransProdDetalle GuardarDetalleRegalados(TransProd oTransProd, String ProductoClave, int TipoUnidad, float Cantidad, String PromocionClave, int TipoValidacionInventario) throws Exception
		{
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

			TransProdDetalle transProdDetalle = new TransProdDetalle();
			transProdDetalle.TransProdID = oTransProd.TransProdID;
			transProdDetalle.TransProdDetalleID = KeyGen.getId();
			transProdDetalle.ProductoClave = ProductoClave;
			transProdDetalle.TipoUnidad = TipoUnidad;
			transProdDetalle.Cantidad = Cantidad;
			transProdDetalle.Precio = 0;
			transProdDetalle.Total = 0;
			transProdDetalle.Promocion = 2;
			transProdDetalle.PromocionClave = PromocionClave;
			//transProdDetalle.DescuentoPor = 0;
			//transProdDetalle.DescuentoImp = 0;
			transProdDetalle.Subtotal = 0;

				/*
			 * sComandoSQL.Append("2,") ' Promocion 'Select Case pariTipoRegla '
			 * Case 1 sComandoSQL.Append(dr("Cantidad") & ",") ' Cantidad 'Case
			 * 2 'sComandoSQL.Append(dr("Cantidad") * vCantidadGrupo & ",") '
			 * Cantidad 'End Select sComandoSQL.Append("0,") ' Precio
			 * sComandoSQL.Append("0,") ' DescuentoPor sComandoSQL.Append("0,")
			 * ' DescuentoImp sComandoSQL.Append("0,") ' Impuesto
			 * sComandoSQL.Append("0,") ' Subtotal
			 */
			transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(oTransProd.TransProdID) + 1;
			transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
			transProdDetalle.MUsuarioID = sUsuarioID;

			BDVend.guardarInsertar(transProdDetalle);

			Inventario.ActualizarInventario(ProductoClave, TipoUnidad, Cantidad, oTransProd.Tipo, TiposMovimientos.SALIDA,((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID);

			//oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',null,getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' AND Subtotal>0 ")

			return transProdDetalle;
		}

	}

	public static class Cambios
	{

		public static TransProdDetalle GenerarDetalleCambio(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, float CantidadOriginal, String PrecioClave) throws Exception
		{

			float nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(TipoUnidad)), PrecioClave);
			if (nPrecio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

				TransProdDetalle transProdDetalle = new TransProdDetalle();
				transProdDetalle.TransProdDetalleID = KeyGen.getId();
				transProdDetalle.TransProdID = TransProdId;
				transProdDetalle.ProductoClave = ProductoClave;
				transProdDetalle.TipoUnidad = TipoUnidad;
				transProdDetalle.Cantidad = Cantidad;
				if (CantidadOriginal != 0)
					transProdDetalle.CantidadOriginal = CantidadOriginal;
				else
					transProdDetalle.CantidadOriginal = (Float) null;
				transProdDetalle.Precio = nPrecio;

				transProdDetalle.DescuentoImp = (Float) null;
				transProdDetalle.DescuentoPor = (Float) null;
				transProdDetalle.Impuesto = (Float) null;
				transProdDetalle.Promocion = (Integer) null;
				transProdDetalle.PrestamoVendido = (Float) null;

				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = (transProdDetalle.getSubTotal() + transProdDetalle.Impuesto);
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}

		public static TransProdDetalle CalcularTotales(TransProdDetalle transProdDetalle) throws Exception
		{

			if (transProdDetalle.Precio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

				/*
				 * transProdDetalle.DescuentoImp = (Float) null;
				 * transProdDetalle.DescuentoPor = (Float) null;
				 * transProdDetalle.Impuesto = (Float) null;
				 * transProdDetalle.Promocion = (Integer) null;
				 * transProdDetalle.PrestamoVendido = (Float) null;
				 */

				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio));

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = (transProdDetalle.getSubTotal() + transProdDetalle.Impuesto); //+ transProdDetalle.Impuesto;
				//transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(transProdDetalle.TransProdID, transProdDetalle.TransProdDetalleID);
				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}
	}

	public static class DevolucionesCliente
	{
		public static TransProdDetalle GenerarDetalleDevolucion(String TransProdId, String ProductoClave, int TipoUnidad, float Cantidad, float CantidadOriginal, String PrecioClave, boolean ValidarPrecio) throws Exception
		{

			float nPrecio = ListaPrecio.BuscarPrecio(ProductoClave, Short.parseShort(String.valueOf(TipoUnidad)), PrecioClave);
			if (!ValidarPrecio && nPrecio < 0)
			{
				nPrecio = 0;
			}
			if (nPrecio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(ProductoClave, oCliente.TipoImpuesto);

				TransProdDetalle transProdDetalle = new TransProdDetalle();
				transProdDetalle.TransProdDetalleID = KeyGen.getId();
				transProdDetalle.TransProdID = TransProdId;
				transProdDetalle.ProductoClave = ProductoClave;
				transProdDetalle.TipoUnidad = TipoUnidad;
				transProdDetalle.Cantidad = Cantidad;
				if (CantidadOriginal != 0)
					transProdDetalle.CantidadOriginal = CantidadOriginal;
				else
					transProdDetalle.CantidadOriginal = (Float) null;
				transProdDetalle.Precio = nPrecio;

				//transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				//transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				transProdDetalle.DescuentoImp = (float) 0;
				transProdDetalle.DescuentoPor = (float) 0;
				/*
				 * if(oDescto != null) transProdDetalle.DescuentoClave =
				 * oDescto.DescuentoClave;
				 */
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}

		public static TransProdDetalle calcularTotales(TransProdDetalle transProdDetalle) throws Exception
		{
			if (transProdDetalle.Precio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(transProdDetalle.ProductoClave, oCliente.TipoImpuesto);

				//Descuentos
				/*
				 * Descuento oDescto = new Descuento(); oDescto =
				 * Descuentos.BuscarDescuentosProductos(ProductoClave);
				 */

				//TransProdDetalle transProdDetalle = new TransProdDetalle();
				/*
				 * transProdDetalle.TransProdDetalleID = KeyGen.getId();
				 * transProdDetalle.TransProdID = TransProdId;
				 * transProdDetalle.ProductoClave = ProductoClave;
				 * transProdDetalle.TipoUnidad = TipoUnidad;
				 * transProdDetalle.Cantidad = Cantidad;
				 */
				/*
				 * if (CantidadOriginal != 0) transProdDetalle.CantidadOriginal
				 * = CantidadOriginal; else transProdDetalle.CantidadOriginal =
				 * (Float) null; transProdDetalle.Precio = nPrecio;
				 */

				//transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				//transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				/*
				 * transProdDetalle.DescuentoImp = (float) 0;
				 * transProdDetalle.DescuentoPor = (float) 0;
				 */
				/*
				 * if(oDescto != null) transProdDetalle.DescuentoClave =
				 * oDescto.DescuentoClave;
				 */
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(transProdDetalle.TransProdID) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(transProdDetalle.TransProdID, transProdDetalle.TransProdDetalleID);
				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);

				return transProdDetalle;
			}
			else
			{
				return null;
			}
		}
	}
	
	public static class Reparto{
		public static TransProdDetalle GenerarDetalleReparto(TransProdDetalle Detalle,String PrecioClave) throws Exception
		{		
			float nPrecio = ListaPrecio.BuscarPrecio(Detalle.ProductoClave, Short.parseShort(String.valueOf(Detalle.TipoUnidad)), PrecioClave);
			if (nPrecio >= 0)
			{
				String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

				//Impuestos
				Impuesto[] listaImpuestos = new Impuesto[] {};
				Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);

				listaImpuestos = Impuestos.Buscar(Detalle.ProductoClave, oCliente.TipoImpuesto);

				//Descuentos
				Descuento oDescto = new Descuento();
				oDescto = Descuentos.BuscarDescuentosProductos(Detalle.ProductoClave);

				TransProdDetalle transProdDetalle = Detalle; //new TransProdDetalle();
				//transProdDetalle.TransProdDetalleID = KeyGen.getId();
				//transProdDetalle.TransProdID = TransProdId;
				//transProdDetalle.ProductoClave = ProductoClave;
				//transProdDetalle.TipoUnidad = TipoUnidad;
				//transProdDetalle.Cantidad = Cantidad;
				/*if (CantidadOriginal != 0)
					transProdDetalle.CantidadOriginal = CantidadOriginal;
				else
					transProdDetalle.CantidadOriginal = (Float) null;
				if (PrecioEspecial != -1 && nPrecio != PrecioEspecial){
					transProdDetalle.PrecioBase = nPrecio;
					transProdDetalle.Precio = PrecioEspecial;
				}else{
					transProdDetalle.Precio = nPrecio;
				}*/

				transProdDetalle.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescto, transProdDetalle.Cantidad * transProdDetalle.Precio, transProdDetalle.Cantidad);
				transProdDetalle.DescuentoPor = transProdDetalle.DescuentoImp;//oDescto == null ? 0 : oDescto.PorcentajeCalculado;
				if (oDescto != null)
					transProdDetalle.DescuentoClave = oDescto.DescuentoClave;
				transProdDetalle.setSubTotal((transProdDetalle.Cantidad * transProdDetalle.Precio) - transProdDetalle.DescuentoImp);

				transProdDetalle.Impuesto = Impuestos.Calcular(listaImpuestos, transProdDetalle.getSubTotal(), transProdDetalle.Precio, transProdDetalle.getCantidad());

				transProdDetalle.Total = transProdDetalle.getSubTotal() + transProdDetalle.Impuesto;
				//transProdDetalle.Partida = Consultas.ConsultasTransProdDetalle.obtenerPartida(TransProdId) + 1;
				transProdDetalle.MFechaHora = Generales.getFechaHoraActual();
				transProdDetalle.MUsuarioID = sUsuarioID;

				Impuestos.GuardarDetalle(transProdDetalle, listaImpuestos);
				BDVend.guardarInsertar(transProdDetalle);

				return transProdDetalle;
			}
			else
			{
				return null;
			}

		}
		
		public static void Actualizar(TransProdDetalle oTransProdDetalle, String PCEPrecioClave) throws Exception{
			//ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
			Descuento oDescuento = new Descuento();
			Impuesto[] oImpuestos;
			//ArrayList<TransProdDetalle> tpdEliminados = new ArrayList<TransProdDetalle>();
			//while (oDetalles.hasNext())
			//{
				TransProdDetalle oTPD = oTransProdDetalle; //oDetalles.next();
				/*if (oTPD.Promocion == 1 && oTPD.Total != 0)
				{*/
					//bHuboPromociones = true;
					float nPrecio = ListaPrecio.BuscarPrecio(oTPD.ProductoClave, (short) oTPD.TipoUnidad, PCEPrecioClave);
					if (nPrecio >= 0)
					{
						oTPD.Precio = nPrecio;
						if (oTPD.Cantidad == 0)
						{
							Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
							Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
							Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
							Consultas.ConsultasTrpPrp.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);

							//limpiar los arrays por que se eliminan todos los registros
							oTPD.TPDImpuesto = new ArrayList<TPDImpuesto>();
							oTPD.TrpPrp = new ArrayList<TrpPrp>();
							//oTPD.TpdPun = new ArrayList<TpdPun>();		
							oTPD.TpdDes = new ArrayList<TpdDes>();

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
							oImpuestos = Impuestos.Buscar(oTPD.ProductoClave, ((Cliente)Sesion.get(Campo.ClienteActual)).TipoImpuesto);
							oDescuento = Descuentos.BuscarDescuentosProductos(oTPD.ProductoClave);

							oTPD.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescuento, oTPD.Cantidad * oTPD.Precio, oTPD.Cantidad);
							oTPD.DescuentoPor = oTPD.DescuentoImp;
							oTPD.setSubTotal(((oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp) < 0 ? 0 : (oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp);
							oTPD.Impuesto = Impuestos.Calcular(oImpuestos, oTPD.getSubTotal(), oTPD.Precio, oTPD.getCantidad());
							oTPD.Total = oTPD.getSubTotal() + oTPD.Impuesto;
							Impuestos.GuardarDetalle(oTPD, oImpuestos);
						}
						BDVend.guardarInsertar(oTPD);
					}
				/*}
				else if (oTPD.Promocion == 2)
				{
					bHuboPromociones = true;
					bHuboRegalados = true;
					tpdEliminados.add(oTPD);
				}*/
			//}
		}
	}
}
