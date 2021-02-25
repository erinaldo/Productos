package com.amesol.routelite.datos.basedatos;

import android.app.SearchManager;

import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ProductoDetalle;
import com.amesol.routelite.datos.ProductoPrestamoCli;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

public final class Consultas2
{
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
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and CLI.Clave not like '" + organizacionVentas + "%' and VIS.FueraFrecuencia = 0 and VIS.RUTClave in ("+rutas+")");
			consulta.append("group by TRP.Tipo ");
			return BDVend.consultar(consulta.toString());
		}
		
		public static ISetDatos obtenerVentasOp(String rutas) throws Exception{
            String organizacionVentas = "MX";
            if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OrganizacionVentas")) {
                organizacionVentas = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OrganizacionVentas");
            }
			StringBuilder consulta = new StringBuilder();
			consulta.append("select SUM(TRP.Total) as Total, COUNT(*) as TotalPedidos ");
			consulta.append("from TransProd TRP ");
			consulta.append("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave or TRP.VisitaClave1 = VIS.VisitaClave ");
			consulta.append("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
			consulta.append("where TRP.Tipo = 1 and TRP.TipoFase = 2 and CLI.Clave like '" + organizacionVentas + "%' and VIS.RUTClave in ("+rutas+")");
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

        public static ISetDatos obtenerEncabezadoTicketPDF (String transprodId) throws Exception{
            String consulta = "SELECT Ve.Nombre, C.RazonSocial, C.TelefonoContacto, CD.Calle as CalleCliente, CD.Numero as NumeroCliente, CD.NumInt as NumIntCliente, CD.CodigoPostal as CPCliente, CD.Colonia as ColoniaCliente, CD.Localidad as LocalidadCliente, CD.Entidad as EntidadCliente, SE.NombreEmpresa, SE.Region, SE.Localidad as LocalidadEmp, SE.Colonia as ColoniaEmp, SE.Calle as CalleEmp, SE.Numero as NumeroEmp, SE.NumeroInterior as NumIntEmp, SE.CodigoPostal as CPEmp, SE.Telefono, TP.FechaCaptura, TP.Total, TP.FechaCobranza, TP.Subtotal, TP.Folio FROM TransProd as TP inner join Visita as V on V.VisitaClave = TP.VisitaClave " +
                    "inner join Vendedor as Ve on Ve.VendedorId = V.VendedorId " +
                    "inner join Cliente as C on C.ClienteClave = TP.ClienteClave " +
                    "left join ClienteDomicilio as CD on CD.ClienteClave = C.ClienteClave AND CD.Tipo = 1 " +
                    "inner join SubEmpresa as SE on SE.SubEmpresaId = TP.SubEmpresaId WHERE TP.TransProdId ='".concat(transprodId).concat("'");
            return BDVend.consultar(consulta);
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

        public static ISetDatos obtenerDetallesTicketPedidoPDF (String transprodId) throws Exception {
			String query = "SELECT TPD.Cantidad, TPD.TipoUnidad, P.NombreLargo, " +
					"CASE WHEN TPD.PrecioBase is null Then TPD.Precio else TPD.PrecioBase END as PrecioBase,  "+
					"CASE WHEN TPD.PrecioBase IS NULL THEN (TPD.Precio * TPD.Cantidad) ELSE (TPD.PrecioBase * TPD.Cantidad) END AS Subtotal, " +
					"CASE WHEN TPD.PrecioBase IS NULL THEN 0 ELSE (TPD.Cantidad * (TPD.PrecioBase - TPD.Precio))  END AS Descuento, "+
					"TPD.Total "+
					"FROM TransProdDetalle as TPD "+
					"inner join Producto as P on P.ProductoClave = TPD.ProductoClave "+
					"WHERE TPD.TransProdId = '".concat(transprodId).concat("'");
            return BDVend.consultar(query);
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
	
	public static class ConsultasEncuestas
	{
		public static ISetDatos[] obtenerEncuestasHibrido (String clave, String visitaClave) throws Exception
		{
		
		/* ISetDatos encuestas = BDVend.consultar("Select DISTINCT ce.CENClave, ce.Descripcion, ce.Icono, e.Fase,e.HoraFin from ConfigEncuesta ce inner join CenCli cc on ce.CENClave = cc.CENClave left join Encuesta e on ce.CENClave = e.CENClave where (cc.ClienteClave = '"+clave+"' and e.VisitaClave = '"+visitaClave+"') or (cc.ClienteClave = '"+clave+"' and e.ENCId is null)");
		 return encuestas;*/
			String query1 = "";
			String query2 = "";


			ISetDatos encuestasAsignadas = BDVend.consultar("Select * From CenCli where ClienteClave = '"+clave+"'");
			ISetDatos [] encuestasTotales = new ISetDatos[encuestasAsignadas.getCount()];
			for(int x = 0; x <= encuestasAsignadas.getCount()-1; x++)
			{
				encuestasAsignadas.moveToNext();
				
				query1 = "Select ce.CENClave, ce.Descripcion, ce.Icono, e.Fase,e.HoraFin from ConfigEncuesta  ce left join Encuesta e on ce.CENClave = e.CENClave where e.VisitaClave ='"+visitaClave+"' and e.CENClave = '"+encuestasAsignadas.getString("CENClave")+"'";
				
				ISetDatos encuestasContestadas = BDVend.consultar(query1);
				if(encuestasContestadas.getCount() > 0)
				{
					
					encuestasTotales[x] = encuestasContestadas;
				}
				else
				{
                 query2 = "Select ce.CENClave, ce.Descripcion, ce.Icono from CenCli cc left join ConfigEncuesta ce on cc.CENClave = ce.CENClave where cc.ClienteClave = '"+clave+"' and ce.CENClave = '"+encuestasAsignadas.getString("CENClave")+"'";
              
				 ISetDatos encuestasAsignadas2 = BDVend.consultar(query2);	
				 encuestasTotales[x] = encuestasAsignadas2;
				}

				
				
			}
			
			return encuestasTotales;

		}
		
		public static boolean verificarContestarEncuesta (String diaClave, String visitaClave) throws Exception
		{
			boolean hayRegistros = false;
			
			ISetDatos chequeo = BDVend.consultar("Select * from Encuesta where VisitaClave = '"+visitaClave+"' and DiaClave = '"+diaClave+"' ");
			
			if(chequeo.getCount() > 0)
			{
				hayRegistros = true;
			}
			
			return hayRegistros;
		}
		
		public static ISetDatos obtenerEncuestaContestada(String CENClave, String visitaClave , String diaClave) throws Exception
		{
			ISetDatos encuesta = null;
			ISetDatos checarEncuesta = BDVend.consultar("Select * from Encuesta where CENClave = '"+CENClave+"' and VisitaClave = '"+visitaClave+"' and DiaClave = '"+diaClave+"'");

			if(checarEncuesta.getCount() != 0)
			{

				checarEncuesta.moveToNext();
				encuesta = BDVend.consultar("Select * from ENCPregunta where ENCId = '"+checarEncuesta.getString("ENCId")+"' order by OrdenAplicacion");
			}

			return encuesta;
		}
		
		public static ISetDatos obtenerPreguntas(String clave, boolean encuestaContestada, String ENCId) throws Exception
		{
			ISetDatos preguntas = null; 
            
			if (!encuestaContestada)
			{
                //preguntas = BDVend.consultar("select * from CENPregunta where CENClave = '" + clave + "' and TipoRespuesta != 7 order by Orden");
                preguntas = BDVend.consultar("select * from CENPregunta where CENClave = '" + clave + "' order by Orden");
            }
			else
			{
				preguntas = BDVend.consultar("Select CP.*  from CENPregunta CP join  ENCPregunta EP on CP.CEPNumero = EP.CEPNumero where CP.CENClave = '" + clave + "' and EP.ENCId = '"+ENCId+"' order by Orden");
			}

			return preguntas;
			
		}
		
		public static ISetDatos obtenerConfiguraciones(String consulta) throws Exception
		{
			ISetDatos configuracion = BDVend.consultar(consulta);
			
			return configuracion;
			
		}
		
		public static int obtenerTotalCompMatricial(String CENClave, int CEPNumero, int tipo ) throws Exception
		{
			ISetDatos totalCount = BDVend.consultar("Select COUNT(CENClave) * (Select COUNT(CENClave) from CEPPregMatricial where CENClave = '"+CENClave+"' and CEPNumero = "+CEPNumero+")AS 'Total'  from CEPRespMatricial where CENClave = '"+CENClave+"' and CEPNumero = "+CEPNumero+" and TipoValor= "+tipo);
			totalCount.moveToNext();
			
			return totalCount.getInt("Total");
		}
		
		public static String obtenerIdRespuesta(String tabla, String id, String ENPId) throws Exception
		{
			String resultado = "";
			String consulta = "Select "+id+" from "+tabla+" where ENPId = '"+ENPId+"'";
			//Log.i(null, consulta);
			ISetDatos idRespuesta = BDVend.consultar(consulta);
			idRespuesta.moveToNext();
			if(idRespuesta.getCount() > 0)
			{	
			//Log.i(null, idRespuesta.getString(id));
			resultado = idRespuesta.getString(id);
			}
			idRespuesta.close();
			return resultado;

			
		}
		
		public static int obtenerHabilitarSalir(String clave)throws Exception
		{
			int habilitarSalir = 0;
			ISetDatos config = BDVend.consultar("Select HabilitarSalir from ConfigEncuesta where CENClave = '"+clave+"'");
			config.moveToFirst();
			habilitarSalir = config.getInt("HabilitarSalir");
			config.close();
			return habilitarSalir;
		}

        public static int obtenerOrdenSalto(int CEPNumero, String CENClave) throws Exception {
            int ordenSalto = 0;
            ISetDatos config = BDVend.consultar("Select * from CENPregunta where CEPNumero = " + CEPNumero + " and CENClave = '" + CENClave + "'");
            config.moveToFirst();
            ordenSalto = config.getInt("Orden");
            config.close();
            return ordenSalto;
        }
    }

    public static final class ConsultasProductoPrestamoCli{

        public static ArrayList<ProductoPrestamoCli> recuperarProductoPrestamoCli(String ClienteClave) throws Exception {
            ISetDatos prestamo = BDVend.consultar("SELECT * FROM ProductoPrestamoCli WHERE ClienteClave = '" + ClienteClave + "'");
            ArrayList<ProductoPrestamoCli> prestamoCli = new ArrayList<>();
            while(prestamo.moveToNext()){
                prestamoCli.add((ProductoPrestamoCli) BDVend.instanciar(ProductoPrestamoCli.class, prestamo));
            }
            prestamo.close();
            return  prestamoCli;
        }

        public static float obtenerSaldoGeneralEnvase(String ClienteClave) throws  Exception {
            float res = 0;
            ISetDatos saldo = BDVend.consultar("SELECT IFNULL(SUM(Saldo),0) Saldo FROM ProductoPrestamoCli WHERE ClienteClave = '" + ClienteClave + "'");
			if(saldo.moveToNext())
            	res = saldo.getFloat("Saldo");
            saldo.close();
            return res;
        }

    }

    public static class ConsultasPerfil{

        public static boolean validarPermisoFirma(int tipoIndice)
        {
            try
            {
                ISetDatos datos = BDVend.consultar("select Permiso from IntPer where ACTId = 'TINDMMD"  + String.valueOf(tipoIndice) + "'");
                String res = "";
                if (datos.moveToNext())
                {
                    res = datos.getString(0);
                }
                datos.close();
                return res.contains("S");
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }

    public static class ConsultasSolicitud {

        public static boolean existenSolicitudes()throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select SOLId ");
            sConsulta.append("from Solicitud ");
            sConsulta.append("where TipoEstado = 1 ");

            return BDVend.consultar(sConsulta.toString()).getCount() > 0;
        }

        public static ISetDatos obtenerSolicitudes()throws Exception
        {
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.append("select SOLId as _id, Folio  AS " + SearchManager.SUGGEST_COLUMN_INTENT_DATA + ",   Folio || ' - ' || Concepto AS " + SearchManager.SUGGEST_COLUMN_TEXT_1 + " ");
            sConsulta.append("from Solicitud ");
            sConsulta.append("where TipoEstado = 1 ");

            return BDVend.consultar(sConsulta.toString());
        }
    }

    public static class ConsultasEnvioPendientePDF {

        public static String obtenerIdEnvioPendiente(String sClienteClave, String sTransaccionID, String sTipo)
        {
            try
            {
                String sConsulta = "";
                if (sTipo == "10")
                    sConsulta = "select EnvioID from EnvioPendientePDF where ClienteClave = '" + sClienteClave + "' and ABNId = '" + sTransaccionID + "'";
                else
                    sConsulta = "select EnvioID from EnvioPendientePDF where ClienteClave = '" + sClienteClave + "' and TransProdId = '" + sTransaccionID + "'";

                ISetDatos datos = BDVend.consultar(sConsulta);
                String res = "";
                if (datos.moveToNext())
                {
                    res = datos.getString(0);
                }
                datos.close();
                return res;
            }
            catch (Exception e)
            {
                return "";
            }

        }
    }

	public static class ConsultarGastos {

		public static ISetDatos obtenerGastos () throws Exception
		{
			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select Fecha, TipoConcepto, Total from Gasto");

			return BDVend.consultar(sConsulta.toString());

		}

		public  static ISetDatos buscarGasto(Date fecha)throws Exception{
			SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
			String strFecha = format.format(fecha);

			StringBuilder sConsulta = new StringBuilder();
			sConsulta.append("select * from Gasto where fecha = '"+strFecha+"'");

			return BDVend.consultar(sConsulta.toString());
		}
	}
}
