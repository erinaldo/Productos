package com.amesol.routelite.datos.basedatos;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

import android.database.Cursor;

import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;

public final class Consultas2
{

	public static ArrayList<Promociones2.ProductoPRM> obtenerProductosSinPromocion(String sTransProdId)
	{
		try
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("SELECT TPD.ProductoClave, SUM(TPD.Cantidad * PRD.Factor) AS Cantidad, SUM(TPD.Subtotal) AS Subtotal ");
			sConsulta.append("FROM TransProdDetalle TPD ");
			sConsulta.append("INNER JOIN ProductoDetalle PRD ON TPD.ProductoClave = PRD.ProductoClave AND TPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave ");
			sConsulta.append("WHERE TPD.TransProdId = '" + sTransProdId + "' and  IFNULL(TPD.Promocion, 0) <> 2 ");
			sConsulta.append("GROUP BY TPD.ProductoClave ");
			ISetDatos datos = BDVend.consultar(sConsulta.toString());
			ArrayList<Promociones2.ProductoPRM> res = new ArrayList<Promociones2.ProductoPRM>();
			while (datos.moveToNext())
			{
				res.add(new Promociones2.ProductoPRM(datos.getString("ProductoClave"), datos.getFloat("Cantidad"), datos.getFloat("Subtotal")));
			}

			datos.close();

			return res;
		}
		catch (Exception ex)
		{
			ex.printStackTrace();
			return null;
		}
	}

	public static HashMap<String, ArrayList<Promociones2.PromocionProducto>> obtenerProductosTrans(String sPromocionesClave, String sTransProdId, HashMap<String, ArrayList<Promociones2.PromocionProducto>> promocionProducto) throws Exception
	{
		StringBuilder sConsulta = new StringBuilder();
		sConsulta.append("select distinct PRP.PromocionClave, PRP.ProductoClave, PRP.Jerarquia ");
		sConsulta.append("from Promocion PRM ");
		sConsulta.append("inner join PromocionProducto PRP on PRM.PromocionClave = PRP.PromocionClave ");
		sConsulta.append("inner join TransProdDetalle TPD on PRP.ProductoClave = TPD.ProductoClave ");
		sConsulta.append("where PRM.PromocionClave in (" + sPromocionesClave + ") and TPD.TransProdID = '" + sTransProdId + "' AND IFNULL(TPD.Promocion,0) <> 2 ");
		sConsulta.append("order by PRP.ProductoClave, PRP.Jerarquia, PRP.PromocionClave ");

		ISetDatos datos = BDVend.consultar(sConsulta.toString());
		HashMap<String, ArrayList<Promociones2.PromocionProducto>> res = new HashMap<String, ArrayList<Promociones2.PromocionProducto>>();
		while (datos.moveToNext())
		{
			if (promocionProducto.containsKey(datos.getString("PromocionClave")))
			{
				promocionProducto.get(datos.getString("PromocionClave")).add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia")));
			}
			else
			{
				ArrayList<Promociones2.PromocionProducto> al = new ArrayList<Promociones2.PromocionProducto>();
				al.add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia")));
				promocionProducto.put(datos.getString("PromocionClave"), al);
			}

			if (res.containsKey(datos.getString("ProductoClave")))
			{
				res.get(datos.getString("ProductoClave")).add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia")));
			}
			else
			{
				ArrayList<Promociones2.PromocionProducto> al = new ArrayList<Promociones2.PromocionProducto>();
				al.add(new Promociones2.PromocionProducto(datos.getString("ProductoClave"), datos.getString("PromocionClave"), datos.getInt("Jerarquia")));
				res.put(datos.getString("ProductoClave"), al);
			}
		}

		datos.close();

		return res;
	}
	
	public static class ConsultarTransProd{
		public static SeleccionarPedido.VistaPedidos[] obtenerPedidosPorSurtirPorVisita(Dia dia, Cliente cliente, Visita visita) throws Exception
		{
			ArrayList<SeleccionarPedido.VistaPedidos> pedidos = new ArrayList<SeleccionarPedido.VistaPedidos>();
			StringBuilder consulta = new StringBuilder();
			ISetDatos fases = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
			
			SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
			String fecha = format.format(dia.FechaCaptura);
			
			consulta.append("select TRP.TransProdID,TRP.Folio,TRP.TipoFase, ");
			consulta.append("case when TRP.TipoFase = 1 Then TRP.FechaCaptura  ");
			consulta.append("else case when TRP.TipoFase = 7 Then TRP.FechaEntrega ");
			consulta.append("else case when TRP.TipoFase = 0 Then TRP.FechaCancelacion ");
			consulta.append("else case when TRP.TipoFase = 2 Then TRP.FechaSurtido ");
			consulta.append("else case when TRP.TipoFase = 3 Then TRP.FechaFacturacion end end end end end as Fecha ");
			consulta.append("FROM TransProd TRP inner join visita VIS on VIS.visitaclave=TRP.visitaclave and VIS.diaclave=TRP.diaclave ");
			consulta.append("where TRP.Tipo = 1 "); 
			consulta.append("and VIS.ClienteClave = '" + cliente.ClienteClave + "' and (TRP.TipoFase = 1  OR (TRP.TipoFase = 7 AND TRP.FechaEntrega = '" + fecha + "') ");
			consulta.append("or ((TRP.VisitaClave1 = '" + visita.VisitaClave + "' and TRP.DiaClave1 = '" + dia.DiaClave + "') ");
			consulta.append("or (TRP.VisitaClave = '" + visita.VisitaClave + "' and TRP.DiaClave = '" + dia.DiaClave + "')))");
			consulta.append("ORDER BY TRP.Folio");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), fases.getString(2), datos.getDate(3));// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				pedidos.add(pedido);
			}

			fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}
	}
	
	public static class ConsultasTransProd{
		public static ISetDatos obtenerUltimaVenta() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TRP.TransProdId as _id,TRP.FechaHoraAlta,TRP.Folio,TPD.ProductoClave,PRO.Nombre,TPD.TipoUnidad,TPD.Cantidad,TPD.Precio,TPD.DescuentoImp,TRP.Total,PRO.DecimalProducto,'' as vacio ");
			consulta.append("FROM TransProd TRP INNER JOIN TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave AND CLI.TipoFiscal = 1 ");
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND ");
			consulta.append("TRP.FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND Tipo = 1 AND TipoFase = 2) ");
			consulta.append("ORDER BY TPD.ProductoClave ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerUltimaFactura() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TRP.TransProdId as _id,TRP.FechaHoraAlta,TRP.Folio,TPD.ProductoClave,PRO.Nombre,TPD.TipoUnidad,TPD.Cantidad,TPD.Precio,TPD.DescuentoImp,TRP.Total,PRO.DecimalProducto,'' as vacio ");
			consulta.append("FROM TransProd FAC INNER JOIN TransProd TRP ON TRP.FacturaID = FAC.TransProdID ");
			consulta.append("INNER JOIN TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave AND CLI.TipoFiscal = 2 ");
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 3 AND ");
			consulta.append("TRP.FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND Tipo = 1 AND TipoFase = 3) ");
			consulta.append("ORDER BY TPD.ProductoClave ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerUltimaVentaAmbas() throws Exception{
			StringBuilder consulta = new StringBuilder();
			//consulta.append("SELECT TRP.TransProdId as _id,FechaHoraAlta,Folio,ProductoClave,Nombre,TipoUnidad,Cantidad,Precio,DescuentoImp,Total,DecimalProducto,'' as vacio ");
			//consulta.append("FROM ( ");
			consulta.append("SELECT * FROM ( ");
			consulta.append("SELECT TRP.TransProdId as _id,TRP.FechaHoraAlta,TRP.Folio,TPD.ProductoClave,PRO.Nombre,TPD.TipoUnidad,TPD.Cantidad,TPD.Precio,TPD.DescuentoImp,TRP.Total,PRO.DecimalProducto,'' as vacio ");
			consulta.append("FROM TransProd TRP INNER JOIN TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave AND CLI.TipoFiscal = 1 ");
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND ");
			consulta.append("TRP.FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND Tipo = 1 AND TipoFase = 2) ");
			consulta.append("UNION ");
			consulta.append("SELECT TRP.TransProdId as _id,TRP.FechaHoraAlta,TRP.Folio,TPD.ProductoClave,PRO.Nombre,TPD.TipoUnidad,TPD.Cantidad,TPD.Precio,TPD.DescuentoImp,TRP.Total,PRO.DecimalProducto,'' as vacio ");
			consulta.append("FROM TransProd TRP ");
			consulta.append("INNER JOIN TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave AND CLI.TipoFiscal = 2 ");
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 3 AND ");
			consulta.append("TRP.FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND Tipo = 1 AND TipoFase = 3) ");
			consulta.append(" )");
			//consulta.append(") AS T ");
			//consulta.append("WHERE FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND ((Tipo = 8 AND TipoFase != 0) OR (Tipo = 1 AND TipoFase = 2))) ");
			return BDVend.consultar(consulta.toString());
		}
		
	}
	
	/*public static class ConsultasInventario{
		public static ISetDatos obtenerInventarioPedido(String productoClave, String AlmacenID) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select inventario.Pedido from productodetalle, inventario where inventario.almacenid='" + AlmacenID + "' and '");
			consulta.append(productoClave + "'=inventario.productoclave and inventario.productoclave=productodetalle.productoclave and inventario.productoclave=productodetalle.productodetclave ");
			return BDVend.consultar(consulta.toString());
		}
	}*/

}
