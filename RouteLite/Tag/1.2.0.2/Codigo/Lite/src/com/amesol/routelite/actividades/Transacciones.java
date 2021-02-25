package com.amesol.routelite.actividades;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;

import android.annotation.SuppressLint;
import android.net.ParseException;

import com.amesol.routelite.datos.CamionVendedor;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.PLBPLE;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.SetDatos;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TipoPedido;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class Transacciones
{

	public static TransProd generarTransaccion(com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
	{

		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
		String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
		String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

		TransProd transProd = new TransProd();

		transProd.TransProdID = KeyGen.getId();
		transProd.VisitaClave = sVisitaClave;
		transProd.DiaClave = sDiaClave;
		transProd.ClienteClave = sClienteClave;

		Precio oPrecio = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
		transProd.ListaPrecios = oPrecio;
		transProd.PCEPrecioClave = oPrecio.PrecioClave;

		transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;

		transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);

		transProd.Tipo = moduloMovDetalle.TipoTransProd; //moduloMovDetalle.TipoMovimiento;
		transProd.TipoPedido = moduloMovDetalle.TipoPedido;
		transProd.TipoMovimiento = moduloMovDetalle.TipoMovimiento;
		transProd.TipoFase = 1;
		transProd.FechaHoraAlta = Generales.getFechaHoraActual();
		transProd.FechaCaptura = Generales.getFechaActual();
		transProd.Total = 0;
		/*
		 * transProd.FechaEntrega = I0257 transProd.FechaFacturacion =
		 * transProd.FechaSurtido = transProd.FechaCancelacion =
		 */
		transProd.MFechaHora = Generales.getFechaHoraActual();
		transProd.MUsuarioID = sUsuarioID;

		return transProd;

	}

	public static TransProd obtenerTransaccion(String TransProdId) throws Exception
	{
		TransProd transprod = new TransProd();
		transprod.TransProdID = TransProdId;
		BDVend.recuperar(transprod);
		return transprod;
	}

	public static void calcularTotalesTransaccion(TransProd oTransProd) throws Exception
	{
		//TransProd oTrp = ObtenerPedido(TransProdId);
		ISetDatos totales = Consultas.ConsultasTransProdDetalle.obtenerTotalesDetalle(oTransProd.TransProdID);
		while (totales.moveToNext())
		{
			oTransProd.Subtotal = totales.getFloat("SubTDetalle");
			oTransProd.Impuesto = totales.getFloat("Impuesto");
			oTransProd.Total = totales.getFloat("Total");
		}
		totales.close();
	}

	public static void EliminarTransaccion(String TransProdId) throws Exception
	{
		TransProd oTRP = obtenerTransaccion(TransProdId);
		BDVend.eliminar(oTRP);
	}

	public static class Pedidos
	{

		public static TransProd generarPedido(com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

			TransProd transProd = new TransProd();

			transProd.TransProdID = KeyGen.getId();
			transProd.VisitaClave = sVisitaClave;
			transProd.DiaClave = sDiaClave;
			transProd.ClienteClave = sClienteClave;

			Precio oPrecio = ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
			transProd.ListaPrecios = oPrecio;
			transProd.PCEPrecioClave = oPrecio.PrecioClave;

			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);

			transProd.Tipo = moduloMovDetalle.TipoTransProd;
			//transProd.TipoPedido = moduloMovDetalle.TipoPedido;
			if(transProd.Tipo == TiposTransProd.PEDIDO){
				if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA){
					transProd.TipoPedido = TipoPedido.POSFECHADO;
				}else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO){
					transProd.TipoPedido = TipoPedido.NORMAL;
				}
			}
			else if(transProd.Tipo == TiposTransProd.VENTA_CONSIGNACION){
				transProd.TipoPedido = moduloMovDetalle.TipoPedido;
			}else if(transProd.Tipo == TiposTransProd.MOV_SIN_INV_EV)
				if(((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MSIEVPreventa").equals("1"))
					transProd.TipoPedido = TipoPedido.POSFECHADO;
				else
					transProd.TipoPedido = TipoPedido.NORMAL;
			else{
				transProd.TipoPedido = TipoPedido.NORMAL;
			}
			transProd.TipoMovimiento = moduloMovDetalle.TipoMovimiento;
			transProd.TipoFase = (short)(transProd.Tipo == TiposTransProd.VENTA_CONSIGNACION ? 2:1);
			transProd.TipoTurno = 0;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			/*
			 * transProd.FechaEntrega = I0257 transProd.FechaFacturacion =
			 * transProd.FechaSurtido = transProd.FechaCancelacion =
			 */
			transProd.MFechaHora = Generales.getFechaHoraActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;

		}

		public static TransProd ActualizarGenerarPedido(HashMap<String, TransProd> transacciones, String subEmpresaId, ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
		{

			TransProd transprod = null;
			if (transacciones.size() == 1)
			{
				transprod = (TransProd) transacciones.values().toArray()[0];
				if (transprod.SubEmpresaId == null || transprod.SubEmpresaId.equals(""))
				{
					transacciones.clear();
					transprod.SubEmpresaId = subEmpresaId;

					transacciones.put(subEmpresaId, transprod);
				}
				else if (!transprod.SubEmpresaId.equals(subEmpresaId))
				{
					TransProd trp = generarPedido(moduloMovDetalle, byRefMensaje);
					trp.SubEmpresaId = subEmpresaId;
					transprod = trp;
				}
				Precio oPrecio = new Precio();
				oPrecio.PrecioClave = transprod.PCEPrecioClave;
				BDVend.recuperar(oPrecio);
				transprod.ListaPrecios = oPrecio;

			}
			else
			{
				if (transacciones.containsKey(subEmpresaId))
				{
					transprod = transacciones.get(subEmpresaId);
				}
				else
				{
					TransProd trp = generarPedido(moduloMovDetalle, byRefMensaje);
					trp.SubEmpresaId = subEmpresaId;
					transprod = trp;
				}
			}

			return transprod;
		}

		public static TransProd ActualizarMovimientoInventario(String TransProdID, ModuloMovDetalle moduloMovDetalle, String byRefMensaje, int Motivo, TransProd transProdGeneral) throws ControlError, Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = TransProdID;
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Tipo = transProdGeneral.Tipo;
			transProd.TipoMovimiento = transProdGeneral.TipoMovimiento;
			transProd.TipoFase = transProdGeneral.TipoFase;
			transProd.Folio = transProdGeneral.Folio;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Saldo = 0;
			transProd.Enviado = false;
			if (Motivo != 0)
			{
				transProd.TipoMotivo = (short) Motivo;
			}
			transProd.MFechaHora = Generales.getFechaActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;
		}

		public static TransProd ActualizarGenerarPedido(String TransProdID, ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje, Short Motivo) throws ControlError, Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = TransProdID;
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Tipo = 19;
			transProd.TipoFase = 1;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Saldo = 0;
			if (Motivo != null){
				transProd.TipoMotivo = Motivo;	
			}
			
			transProd.MFechaHora = Generales.getFechaActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;
		}

		public static TransProd ObtenerPedido(String TransProdId) throws Exception
		{
			TransProd transprod = new TransProd();
			transprod.TransProdID = TransProdId;
			BDVend.recuperar(transprod);
			return transprod;
		}

		public static boolean EliminarSiNoHayDetalle(String TransProdId) throws Exception
		{
			boolean eliminar = false;
			ISetDatos transprod = Consultas.ConsultasTransProdDetalle.obtenerDetalle("'" + TransProdId + "'");
			if (transprod.getCount() <= 0)
			{
				eliminar = true;
			}
			transprod.close();
			return eliminar;
		}

		public static void EliminarPedido(String TransProdId) throws Exception
		{
			Consultas.ConsultasTPDImpuesto.eliminarImpuestos(TransProdId);
			Consultas.ConsultasTrpPrp.eliminarPorTransProd(TransProdId);
			Consultas.ConsultasDescuentos.eliminarDescuentos(TransProdId);
			Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(TransProdId);

			float nPuntos = Consultas.ConsultasTpdPun.obtenerPuntos(TransProdId);
			if (nPuntos > 0)
			{
				nPuntos = Math.round(nPuntos);
				Consultas.ConsultasTpdPun.actualizarSaldo(nPuntos);
			}
			Consultas.ConsultasTpdPun.eliminar(TransProdId);

			Consultas.ConsultasTransProdDetalle.eliminarDetalle(TransProdId);
			//Consultas.ConsultasTransProd.eliminarPorTransProdId(TransProdId);
			TransProd oTRP = ObtenerPedido(TransProdId);
			BDVend.eliminar(oTRP);
		}

		public static void cancelarPedidoInconsistente(TransProd pedido) throws Exception
		{
				// TODO: falta el manejo de los pedidos agrupados con subempres
				// TODO: falta el manejo de las devoluciones automaticas de envase
				// TODO: falta el manejo correcto de las cuotas y puntos
				CONHist conhist = (CONHist) Sesion.get(Campo.CONHist);

				//Dar reversa al inventario
				//TODO: Falta el manejo de envase en inventario
				/*if (pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO )
				{
					BDVend.recuperar(pedido, TransProdDetalle.class);
					Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
					while (it.hasNext())
					{
						TransProdDetalle oTpd = it.next();
						com.amesol.routelite.actividades.Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, pedido.TipoMovimiento, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
					}
							
				}else*/ if(pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
					
					Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID); 
					//solo se deja este escenario porque es el inconsistente
					//pedido creado en visita
					//actualizar inventario, entrada
					BDVend.recuperar(pedido, TransProdDetalle.class);
					Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
					while (it.hasNext())
					{
						TransProdDetalle oTpd = it.next();
						com.amesol.routelite.actividades.Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.ENTRADA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true, TiposFasesDocto.SURTIDO);
					}
				}

				pedido.TipoFase = 0;
				//pedido.TipoMotivo = mVista.getTipoMotivo();
				pedido.FechaCancelacion = Generales.getFechaHoraActual();
				pedido.Notas = "Cancelado por inconsistencias - Android";
				pedido.MFechaHora = Generales.getFechaHoraActual();
				pedido.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(pedido);

				BDVend.commit();
		}
		public static void CalcularTotalesPedido(TransProd oTransProd) throws Exception
		{
			//TransProd oTrp = ObtenerPedido(TransProdId);
			ISetDatos totales = Consultas.ConsultasTransProdDetalle.obtenerTotalesDetalle(oTransProd.TransProdID);
			while (totales.moveToNext())
			{
				oTransProd.SubTDetalle = totales.getFloat("SubTDetalle");
				oTransProd.Impuesto = totales.getFloat("Impuesto");
				oTransProd.Total = totales.getFloat("Total");
			}
			totales.close();
		}

		public static void ActualizarSaldoCliente(String ClienteClave, float Total) throws Exception
		{
			Consultas.ConsultasCliente.actualizarSaldo(ClienteClave, Total);
		}

		public static void ActualizarSaldo(String transProdId, float importe) throws Exception
		{
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

			TransProd oTRP = new TransProd();
			oTRP.TransProdID = transProdId;
			BDVend.recuperar(oTRP);
			oTRP.Saldo = Generales.getRound((oTRP.Saldo + importe), 2);
			oTRP.MFechaHora = Generales.getFechaHoraActual();
			oTRP.MUsuarioID = sUsuarioID;
			oTRP.Enviado = false;

			BDVend.guardarInsertar(oTRP);
		}

		/*
		 * public static boolean GenerarPedidoSugerido(TransProd
		 * transProdGeneral, HashMap<String, TransProd> transacciones,
		 * ArrayList<Integer> tipoPedido, ModuloMovDetalle moduloMovDetalle){
		 * try{ //boolean bSoloPrioritario = false; boolean bHayPedido = false;
		 * //No hay pedido sugerido String sClienteClave =
		 * ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave; short
		 * nFrecuenciaDia = ((Dia)Sesion.get(Campo.DiaActual)).Frecuencia;
		 * ISetDatos dtProductos =
		 * Consultas.ConsultasTransProd.obtenerPedidoSugerido(sClienteClave,
		 * nFrecuenciaDia, tipoPedido); if (dtProductos.getCount() > 0){
		 * 
		 * while(dtProductos.moveToNext()){ if (GenerarDetalle(moduloMovDetalle,
		 * transProdGeneral, transacciones,
		 * dtProductos.getString("ProductoClave"),
		 * dtProductos.getInt("PRUTipoUnidad"),
		 * dtProductos.getFloat("Cantidad"), dtProductos.getFloat("Cantidad")))
		 * bHayPedido = true; };
		 * 
		 * dtProductos.close(); return bHayPedido; }else{ dtProductos.close();
		 * return false; }
		 * 
		 * }catch(Exception e){ e.printStackTrace(); return false; } }
		 */

		public static String getTransaccionesIds(ArrayList<String> transacciones)
		{
			return transacciones.toString().replace("[", "'").replace("]", "'").replace(", ", "','");
		}

		//Enviar un PrecioEspecial = -1 cuando no se quiera aplicar, solo mandar otro dato cuando se este cambiando
		public static boolean GenerarDetalle(ModuloMovDetalle moduloMovDetalle, TransProd transProdGeneral, HashMap<String, TransProd> transacciones, String ProductoClave, int TipoUnidad, float Cantidad, float CantidadOriginal,float PrecioEspecial) throws Exception
		{

			Producto oProducto = new Producto();
			oProducto.ProductoClave = ProductoClave;
			BDVend.recuperar(oProducto);

			String subEmpresaId = oProducto.SubEmpresaId;

			if (TipoUnidad == 0)
				TipoUnidad = Consultas.ConsultasProducto.obtenerUnidadMinima(oProducto.ProductoClave);

			StringBuilder byRefMensaje = new StringBuilder();

			transProdGeneral = ActualizarGenerarPedido(transacciones, subEmpresaId, moduloMovDetalle, byRefMensaje);

			byRefMensaje = null;
			//validar si se genero un nuevo encabezado para agregar al array
			if (!transacciones.containsKey(subEmpresaId))
			{
				transacciones.put(subEmpresaId, transProdGeneral);
			}

			BDVend.guardarInsertar(transProdGeneral);

			TransProdDetalle transProdDetalle = TransaccionesDetalle.Pedidos.GenerarDetallePedido(transProdGeneral.TransProdID, ProductoClave, TipoUnidad, Cantidad, CantidadOriginal, transProdGeneral.ListaPrecios.PrecioClave, PrecioEspecial, null);

			if (transProdDetalle != null)
			{
				BDVend.guardarInsertar(transProdDetalle);
				return true;
			}
			else
				return false;

		}

		/*
		 * public static boolean ValidarVencimientoVenta(String ClienteClave)
		 * throws Exception{ boolean resultado = true; Cliente oCliente = new
		 * Cliente(); oCliente.ClienteClave = ClienteClave;
		 * BDVend.recuperar(oCliente); //try {
		 * if(((CONHist)Sesion.get(Campo.CONHist
		 * )).get("TipoLimiteCredito").toString().equals("2")){ float valor = 0;
		 * String tipoMov =
		 * ((CONHist)Sesion.get(Campo.CONHist)).get("CobrarVentas"
		 * ).toString().equals("1") ? "1" : "8"; valor =
		 * Consultas2.ConsultasTransProd.obtenerVentasVencidas(oCliente,
		 * tipoMov);
		 * 
		 * if(valor > 0){ //mostrar mensaje E0631?? throw new
		 * ControlError("E0631"); }else if
		 * (((CONHist)Sesion.get(Campo.CONHist)).
		 * get("CobrarVentas").toString().equals("0")){ valor =
		 * Consultas2.ConsultasCliente.obtenerSumFechaFacturaCliente(oCliente);
		 * if(valor > 0){ //mostrar mensaje E0631?? throw new
		 * ControlError("E0631"); } } } /*} catch (Exception e) {
		 * e.printStackTrace(); return false; } return resultado; }
		 */
	}//Fin Pedidos

	public static class Inventario
	{

		public static TransProd generarMovSinVista(ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
		{
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = KeyGen.getId();
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);
			transProd.Tipo = 19;
			transProd.TipoFase = 1;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Saldo = 0;
			transProd.MFechaHora = Generales.getFechaHoraActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;

		}

		public static TransProd generarMovConInventario(ModuloMovDetalle moduloMovDetalle, int Tipo, int TipoMovimiento, final StringBuilder byRefMensaje) throws ControlError, Exception
		{
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = KeyGen.getId();
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);
			transProd.Tipo = (short) Tipo;
			transProd.TipoMovimiento = (short) TipoMovimiento;
			transProd.TipoFase = 1;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Enviado = false;
			transProd.Saldo = 0;
			transProd.Escritorio = false;
			transProd.MFechaHora = Generales.getFechaHoraActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;

		}
	}

	public static class Preliquidacion
	{

		public static PLBPLE generarPreliquidacion(String PLIId) throws ControlError, Exception
		{
			PLBPLE mPLBPLE = new PLBPLE();
			mPLBPLE.PLIId = PLIId;

			return mPLBPLE;

		}

		public static PLBPLE ActualizarPreliquidacionEfectivo(String TipoEfectivo, String PBEId, float Total, PLBPLE PLBPLEGeneral) throws ControlError, Exception
		{

			PLBPLE mPLBPLE = new PLBPLE();
			mPLBPLE.PLIId = PLBPLEGeneral.PLIId;
			mPLBPLE.PBEId = (PBEId.equals("")) ? KeyGen.getId() : PBEId;
			mPLBPLE.TipoBanco = null;
			mPLBPLE.FechaDeposito = null;
			mPLBPLE.Total = Total;
			mPLBPLE.Referencia = null;
			mPLBPLE.Ficha = null;
			mPLBPLE.TipoEfectivo = TipoEfectivo;
			mPLBPLE.MFechaHora = Generales.getFechaHoraActual();
			mPLBPLE.Enviado = false;
			return mPLBPLE;
		}

		@SuppressLint("SimpleDateFormat")
		public static PLBPLE ActualizarPreliquidacionDeposito(String mFecha, String PBEId, String TipoBanco, String referencia, String totalDep, String ficha, PLBPLE PLBPLEGeneral) throws ControlError, Exception
		{
			try
			{
				PLBPLE mPLBPLE = new PLBPLE();
				mPLBPLE.PLIId = PLBPLEGeneral.PLIId;
				mPLBPLE.PBEId = (PBEId.equals("")) ? KeyGen.getId() : PBEId;
				mPLBPLE.TipoBanco = TipoBanco;
				SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
				mPLBPLE.FechaDeposito = format.parse(mFecha);
				mPLBPLE.Total = Float.parseFloat(totalDep);
				mPLBPLE.Referencia = referencia;
				mPLBPLE.Ficha = ficha;
				mPLBPLE.TipoEfectivo = null;
				mPLBPLE.MFechaHora = Generales.getFechaHoraActual();
				mPLBPLE.Enviado = false;

				return mPLBPLE;
			}
			catch (ParseException e)
			{
				e.printStackTrace();
				return null;
			}
		}
	}

	public static class Deposito
	{

		public static com.amesol.routelite.datos.Deposito GenerarDeposito(int TipoBanco, String Ficha, float Deposito) throws ControlError, Exception
		{

			com.amesol.routelite.datos.Deposito mDeposito = new com.amesol.routelite.datos.Deposito();
			mDeposito.DEPId = KeyGen.getId();
			mDeposito.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			mDeposito.TipoBanco = (short) TipoBanco;
			mDeposito.FechaCreacion = Consultas.ConsultaDeposito.obtenerDiaCreacion(mDeposito.DiaClave);
			mDeposito.FechaDeposito = Generales.getFechaHoraActual();
			mDeposito.Ficha = Ficha;
			mDeposito.Total = Deposito;
			mDeposito.MFechaHora = Generales.getFechaHoraActual();
			mDeposito.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			mDeposito.Enviado = false;
			return mDeposito;
		}
	}

	public static class Kilometraje
	{
		public static CamionVendedor GenerarCamionVendedor(String Placa, float KMInicial)
		{
			CamionVendedor mCamionVendedor = new CamionVendedor();
			mCamionVendedor.CAMVENId = KeyGen.getId();
			mCamionVendedor.Placa = Placa;
			mCamionVendedor.FechaHoraInicial = Generales.getFechaHoraActual();
			mCamionVendedor.KmInicial = KMInicial;
			mCamionVendedor.MFechaHora = Generales.getFechaHoraActual();
			mCamionVendedor.Enviado = false;

			return mCamionVendedor;

		}

		public static CamionVendedor GenerarCamionVendedorFinal(CamionVendedor mCamionVendedor, float KMFinal, float LitrosGasolina, float ImporteGasolina)
		{
			mCamionVendedor.FechaHoraFinal = Generales.getFechaHoraActual();
			mCamionVendedor.KmFinal = KMFinal;
			mCamionVendedor.LitrosGasolina = LitrosGasolina;
			mCamionVendedor.ImporteGasolina = ImporteGasolina;
			mCamionVendedor.MFechaHora = Generales.getFechaHoraActual();
			mCamionVendedor.Enviado = false;

			return mCamionVendedor;

		}

	}
	
	public static final class Factura{

		public static Float obtenerSubtotal(String pedidosFacturados) throws Exception
		{
			float subtotal = 0f;
			ISetDatos cursor = Consultas.ConsultasTransProdDetalle.obtenerSubtotalParaFactura(pedidosFacturados);
			if(cursor.moveToNext()){
				subtotal = cursor.getFloat("Subtotal");
			}
			cursor.close();
			return subtotal;
		}
		
		public static Float obtenerImpuesto(String pedidosFacturados) throws Exception
		{
			float impuesto = 0f;
			ISetDatos cursor = Consultas.ConsultasTransProdDetalle.obtenerImpuestoParaFactura(pedidosFacturados);
			if(cursor.moveToNext()){
				impuesto = cursor.getFloat("Impuesto");
			}
			cursor.close();
			return impuesto;
		}
	}

}
