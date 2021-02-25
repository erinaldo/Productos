package com.amesol.routelite.datos.basedatos;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import android.database.Cursor;

import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.act.SeleccionarFacturacion.TransProdFactura;

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
		public static ISetDatos obtenerTotalPedidosCostena(String tipoFase) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(ifnull(TPD.Total,0)) as Total, ESQ.Clasificacion ");
			consulta.append("from Esquema ESQ ");
			consulta.append("inner join ProductoEsquema PRE on PRE.EsquemaID = ESQ.EsquemaID ");
			consulta.append("left join TransProdDetalle TPD on TPD.ProductoClave = PRE.ProductoClave ");
			consulta.append("left join TransProd TRP on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("where TRP.TransProdID is null or (TRP.Tipo = 1 and TRP.TipoFase = "+tipoFase+") ");
			consulta.append("group by ESQ.Clasificacion ");
			return BDVend.consultar(consulta.toString());
		}
		
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
			consulta.append("else case when TRP.TipoFase = 3 Then TRP.FechaFacturacion end end end end end as Fecha, ");
			consulta.append("IFNULL(DiaClave1,'') as Extras ");
			consulta.append("FROM TransProd TRP inner join visita VIS on VIS.visitaclave=TRP.visitaclave and VIS.diaclave=TRP.diaclave ");
			consulta.append("where TRP.Tipo = 1 "); 
			consulta.append("and VIS.ClienteClave = '" + cliente.ClienteClave + "' and (((TRP.TipoFase = 1 AND TRP.TipoPedido = 2)  OR (TRP.TipoFase = 7 AND TRP.FechaEntrega = '" + fecha + "')) ");
			consulta.append("or (TRP.TipoFase in(0,2) and ((TRP.VisitaClave1 = '" + visita.VisitaClave + "' and TRP.DiaClave1 = '" + dia.DiaClave + "') ");
			consulta.append("or (TRP.VisitaClave = '" + visita.VisitaClave + "' and TRP.DiaClave = '" + dia.DiaClave + "'))))");
			consulta.append("ORDER BY TRP.Folio");

			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				int fase = datos.getInt(2) + 1;
				fases.moveToPosition(fase - 1);
				SeleccionarPedido.VistaPedidos pedido = new SeleccionarPedido.VistaPedidos(datos.getString(0), datos.getString(1), datos.getInt(2), fases.getString(2), datos.getDate(3), datos.getString(4));// datos.getDate(3)
																																															// Generales.getFechaHoraActual()
				pedidos.add(pedido);
			}

			fases.close();
			datos.close();

			return pedidos.toArray(new SeleccionarPedido.VistaPedidos[pedidos.size()]);
		}
	}
	
	public static class ConsultasTransProd{
		
		/*public static float obtenerAbonosCheques(Visita visita, String trpTipo) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(ABND.Importe) AS Abonos FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.ClienteClave = VIS.ClienteClave");
			consulta.append("INNER JOIN ABNTrp ABN ON TRP.TransProdID = ABN.TransProdID ");
			consulta.append("INNER JOIN ABNDetalle ABND ON ABN.ABNId = ABND.ABNId AND ABND.TipoPago = 2");
			consulta.append("WHERE TRP.CFVTipo = 2 (TRP.Tipo = " + trpTipo + " OR TRP.Tipo = 24) AND TRP.TipoFase != 0 AND VIS.ClienteClave = '" + visita.ClienteClave + "'");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Abonos");
			}
			saldo.close();
			return res;
		}*/
		
		/*public static float obtenerSaldoAbonosNoCheque(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(ABN.Saldo) AS Abonos FROM Abono ABN ");
			consulta.append("INNER JOIN Visita VIS ON ABN.VisitaClave = VIS.VisitaClave AND ABN.DiaClave = VIS.DiaClave AND VIS.ClienteClave = '" + visita.VisitaClave + "' ");
			consulta.append("WHERE ABN.ABNId NOT IN (SELECT ABN.ABNId FROM Abono ABN INNER JOIN ABNDetalle ABND ON ABN.ABNId = ABND.ABNId AND ABND.TipoPago = 2 INNER JOIN Visita VIS ON ABN.VisitaClave = VIS.Visita AND ABN.DiaClave = VIS.DiaClave AND VIS.ClienteClave = '" + visita.ClienteClave + "')");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Abonos");
			}
			saldo.close();
			return res;
		}*/
		
		/*public static float obtenerSaldoAbonos(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(ABN.Saldo) AS Abonos FROM Abono ABN ");
			consulta.append("INNER JOIN Visita VIS ON ABN.VisitaClave = VIS.VisitaClave AND ABN.DiaClave = VIS.DiaClave AND VIS.ClienteClave = '" + visita.VisitaClave + "' ");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Abonos");
			}
			saldo.close();
			return res;
		}*/
		
		public static float obtenerSaldoVentas(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(TRP.Saldo) AS Saldo FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.ClienteClave = VIS.ClienteClave ");
			consulta.append("WHERE ((TRP.Tipo = 1 AND TRP.CFVTipo = 2) OR TRP.Tipo = 24) AND TRP.TipoFase != 0 AND VIS.ClienteClave = '" + visita.ClienteClave + "'");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Saldo");
			}
			saldo.close();
			return res;
		}
		
		public static float obtenerSaldoVentasPreventa(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(TRP.Saldo) AS Saldo FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.ClienteClave = VIS.ClienteClave ");
			consulta.append("inner join ModuloMovDetalle MMD on TRP.PCEModuloMovDetClave = MMD.ModuloMovDetalleClave ");
			consulta.append("WHERE (MMD.TipoIndice = 9 AND TRP.CFVTipo = 2) AND TRP.TipoFase = 1 AND VIS.ClienteClave = '" + visita.ClienteClave + "'");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Saldo");
			}
			saldo.close();
			return res;
		}
		
		public static float obtenerSaldoVentasNoCheque(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT case when sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) is null then 0 else sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) end AS Saldo ");
			consulta.append("FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave ");
			consulta.append("Left Join (Select TRPCheque.TransProdID,sum(AbnCheque) as AbnCheque from TRPCheque  inner join Abono ABN on ABN.ABNId = TRPCheque.ABNId group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
			consulta.append("WHERE v.ClienteClave = '" + visita.ClienteClave + "' AND ((Tipo = 1 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase != 0 ");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Saldo");
			}
			saldo.close();
			return res;
		}
		
		public static final float obtenerSaldoFacturas(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(TRP.Saldo) AS Saldo FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.ClienteClave = VIS.ClienteClave ");
			consulta.append("AND ((TRP.Tipo = 8 AND TRP.CFVTipo = 2) OR TRP.Tipo = 24) AND TRP.TipoFase != 0 AND VIS.ClienteClave = '" + visita.ClienteClave + "'");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Saldo");
			}
			saldo.close();
			return res;
		}
		
		public static float obtenerSaldoFacturasNoCheque(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT case when sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) is null then 0 else sum(saldo+(Case When TRC.AbnCheque is null then 0 Else TRC.AbnCheque END)) end AS Saldo ");
			consulta.append("FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave ");
			consulta.append("Left Join (Select TRPCheque.TransProdID,sum(AbnCheque) as AbnCheque from TRPCheque  inner join Abono ABN on ABN.ABNId = TRPCheque.ABNId group by TRPCheque.TransProdID) TRC on TRC.TransProdID = TRP.TransProdID ");
			consulta.append("WHERE v.ClienteClave = '" + visita.ClienteClave + "' AND ((Tipo = 8 AND CFVTipo = 2) OR Tipo = 24) AND TipoFase != 0 ");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Saldo");
			}
			saldo.close();
			return res;
		}
		
		public static final float obtenerSaldoVtasNoFact(Visita visita) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT SUM(TRP.Saldo) AS Saldo FROM TransProd TRP ");
			consulta.append("INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.ClienteClave = VIS.ClienteClave ");
			consulta.append("AND TRP.Tipo = 1 AND TRP.CFVTipo = 2 AND TRP.TipoFase != 0 AND TRP.FacturaID IS NULL AND VIS.ClienteClave = '" + visita.ClienteClave + "'");
			ISetDatos saldo = BDVend.consultar(consulta.toString());
			float res = 0;
			while(saldo.moveToNext()){
				res += saldo.getFloat("Saldo");
			}
			saldo.close();
			return res;
		}
		
		public static ISetDatos obtenerUltimaVenta() throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TRP.TransProdId as _id,TRP.FechaHoraAlta,TRP.Folio,TPD.ProductoClave,PRO.Nombre,TPD.TipoUnidad,TPD.Cantidad,TPD.Precio,TPD.DescuentoImp,TRP.Total,PRO.DecimalProducto,'' as vacio ");
			consulta.append("FROM TransProd TRP INNER JOIN TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave AND CLI.TipoFiscal = 1 ");
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND TRP.ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND ");
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
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 3 AND TRP.ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND ");
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
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND TRP.ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND ");
			consulta.append("TRP.FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND Tipo = 1 AND TipoFase = 2) ");
			consulta.append("UNION ");
			consulta.append("SELECT TRP.TransProdId as _id,TRP.FechaHoraAlta,TRP.Folio,TPD.ProductoClave,PRO.Nombre,TPD.TipoUnidad,TPD.Cantidad,TPD.Precio,TPD.DescuentoImp,TRP.Total,PRO.DecimalProducto,'' as vacio ");
			consulta.append("FROM TransProd TRP ");
			consulta.append("INNER JOIN TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
			consulta.append("INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave ");
			consulta.append("INNER JOIN Cliente CLI ON TRP.ClienteClave = CLI.ClienteClave AND CLI.TipoFiscal = 2 ");
			consulta.append("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 3 AND TRP.ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND ");
			consulta.append("TRP.FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND Tipo = 1 AND TipoFase = 3) ");
			consulta.append(" )");
			//consulta.append(") AS T "); 
			//consulta.append("WHERE FechaHoraAlta IN (SELECT MAX(FechaHoraAlta) FROM TransProd WHERE ClienteClave = '" + ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave + "' AND ((Tipo = 8 AND TipoFase != 0) OR (Tipo = 1 AND TipoFase = 2))) ");
			return BDVend.consultar(consulta.toString());
		}

		public static float obtenerTotalPedidosPosfechados() throws Exception
		{
			float total = 0;
			StringBuilder consulta = new StringBuilder();
			consulta.append("select ifnull(sum(Total),0) ");
			consulta.append("from TransProd where Tipo = 21 and TipoFase = 1");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			while (datos.moveToNext())
			{
				total = datos.getFloat(0);
			}
			datos.close();
			return total;
		}
		
		public static ISetDatos obtenerTotalVentas(String rutas) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and CLI.Clave not like 'MX%' and VIS.FueraFrecuencia = 0 and VIS.RUTClave in ("+rutas+")");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerVentasOp(String rutas) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and CLI.Clave like 'MX%' and VIS.RUTClave in ("+rutas+")");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerVentasFueraFrecuencia(String rutas) throws Exception{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.FueraFrecuencia = 1 and VIS.RUTClave in ("+rutas+")");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static List<Entidad> obtenerPedidosPorFacturar(Visita visita, Dia dia, Cliente cliente, int CFVTipo, String subEmpresaId) throws Exception{
			List<Entidad> list = new ArrayList<Entidad>();
			TransProd fac = null;
			StringBuilder consulta = new StringBuilder();
			consulta.append("SELECT TransProdID, SubEmpresaId, Folio, Tipo, TipoFase, FechaCaptura, TP.Enviado, CFVTipo, FechaSurtido, ").
			append("Subtotal, Impuesto, Total, Saldo ").
			append("FROM TransProd as TP inner join Visita as V ").
			append("on (V.VisitaClave = TP.VisitaClave) OR (V.VisitaClave = TP.VisitaClave1) WHERE TP.Tipo = 1 AND TP.TipoFase = 2 AND ").
			append("V.DiaClave ='").append(dia.DiaClave).append("' AND V.ClienteClave = '").append(cliente.ClienteClave).append("' AND ").
			append("V.VisitaClave = '").append(visita.VisitaClave).append("' AND TP.CFVTipo = ").
			append(CFVTipo).append(" AND SubEmpresaID = '").append(subEmpresaId).append("'");
			ISetDatos datos = BDVend.consultar(consulta.toString());
			if(datos != null){
				while(datos.moveToNext())
				{
					fac = new TransProd();
					fac.TransProdID = datos.getString("TransProdID");
					fac.SubEmpresaId = datos.getString("SubEmpresaId");
					fac.Folio = datos.getString("Folio");
					fac.Tipo = datos.getShort("Tipo");
					fac.TipoFase = datos.getShort("TipoFase");
					fac.Enviado = datos.getBoolean("Enviado");
					fac.CFVTipo = datos.getShort("CFVTipo");
					fac.FechaSurtido = datos.getDate("FechaSurtido");
					fac.Subtotal = datos.getFloat("Subtotal");
					fac.Impuesto = datos.getFloat("Impuesto");
					fac.Total = datos.getFloat("Total");
					fac.Saldo = datos.getFloat("Saldo");
					list.add(fac);
				}
			}
			datos.close();
			return list;
		}
	}
	
	public static class ConsultasProductoDetalle{
		
		public static ProductoDetalle[] obtenerProductosConPrestamo(String productoClave, int tipoUnidad) throws Exception{
			ArrayList<ProductoDetalle> prods = new ArrayList<ProductoDetalle>();
			ISetDatos productos = BDVend.consultar("SELECT ProductoClave, PRUTipoUnidad, ProductoDetClave FROM ProductoDetalle WHERE ProductoClave = '" + productoClave + "' AND PRUTipoUnidad = " + tipoUnidad + " AND Prestamo = 1");
			while(productos.moveToNext()){
				ProductoDetalle pro = new ProductoDetalle();
				pro.ProductoClave = productos.getString("ProductoClave");
				pro.PRUTipoUnidad = productos.getShort("PRUTipoUnidad");
				pro.ProductoDetClave = productos.getString("ProductoDetClave");
				BDVend.recuperar(pro);
				prods.add(pro);
			}
			productos.close();
			return prods.toArray(new ProductoDetalle[prods.size()]);
		}
		
	}

	public static class ConsultasInventario{
		public static ISetDatos obtenerInventarioPedido(String productoClave, String AlmacenID) throws Exception
		{
			StringBuilder consulta = new StringBuilder();
			consulta.append("select inventario.Pedido from productodetalle, inventario where inventario.almacenid='" + AlmacenID + "' and '");
			consulta.append(productoClave + "'=inventario.productoclave and inventario.productoclave=productodetalle.productoclave and inventario.productoclave=productodetalle.productodetclave ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerInventarioParaReporte() throws Exception{
			StringBuilder query = new StringBuilder();
			query.append("select INV.ProductoClave, p.Nombre, PD.PRUTipoUnidad,");
			query.append("(select ifnull(sum(TPD.Cantidad*PD.Factor),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid ");
			query.append("and PD.ProductoClave = TPD.ProductoClave where INV.ProductoClave = TPD.ProductoClave and TRP.Tipo = 2 and TRP.TipoFase = 1) as II,");
			
			query.append("(select ifnull(sum(TPD.Cantidad*PD.Factor),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid ");
			query.append("and PD.ProductoClave = TPD.ProductoClave where INV.ProductoClave = TPD.ProductoClave and TRP.Tipo = 1 and TRP.TipoFase = 2) as Vta,");
			
			query.append("(INV.disponible - INV.nodisponible - INV.contenido) as IB,");
			
			query.append("(select ifnull(sum(TPD.Cantidad*PD.Factor),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid and TPD.TipoMotivo between 200 and 210 ");
			query.append("and PD.ProductoClave = TPD.ProductoClave where INV.ProductoClave = TPD.ProductoClave and TRP.Tipo = 9 and TRP.TipoFase = 1 and TipoMovimiento = 1)+");
			query.append("(select ifnull(sum(IT.Cantidad * PD.Factor),0) from InventarioTraspaso as IT where IT.ProductoClave = INV.ProductoClave and IT.TipoMotivo between 30 and 34)as IM,");
			
			query.append("(select ifnull(sum(TPD.Cantidad*PD.Factor),0) from transprod TRP ");
			query.append("inner join transproddetalle TPD on TRP.TransProdId = TPD.TransProdid and TPD.TipoMotivo = 211 ");
			query.append("and PD.ProductoClave = TPD.ProductoClave where INV.ProductoClave = TPD.ProductoClave and TRP.Tipo = 9 and TRP.TipoFase = 1 and TipoMovimiento = 1)+");
			query.append("(select ifnull(sum(IT.Cantidad * PD.Factor),0) from InventarioTraspaso as IT where IT.ProductoClave = INV.ProductoClave and IT.TipoMotivo = 35) as IF,");
			
			query.append("ifnull((select TPD.Precio from TransProdDetalle TPD inner join TransProd TRP on TPD.TransProdId = TRP.TransProdId where TRP.Tipo = 1 and TRP.TipoFase = 2 and TPD.ProductoClave = INV.ProductoClave limit 1),0) as Precio,");
			
			query.append("ifnull((select sum(TPD.Impuesto) from TransProdDetalle TPD inner join TransProd TRP on TPD.TransProdId = TRP.TransProdId where TRP.Tipo = 1 and TRP.TipoFase = 2 and TPD.ProductoClave = INV.ProductoClave),0) as Imp ");
			
			query.append("from Inventario INV inner join (select ProductoClave, PRUTipoUnidad, Factor from ProductoDetalle where Factor = 1) as PD on PD.ProductoClave = INV.ProductoClave inner join Producto p on ");
			query.append("INV.ProductoClave = p.ProductoClave order by INV.ProductoClave");
			ISetDatos dataQuery = BDVend.consultar(query.toString());
			return dataQuery;
		}
	}

}
