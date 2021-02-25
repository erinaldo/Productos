using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class LiquidacionUNI
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        public int cont = 1;

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string pvCondicion2, string pvCondicion3, string pvCondicion4, string pvCondicion5, string pvCondicion6, string RutasSplit, string FechaInicial, string FechaFinal, string nombreCedis, string Presupuesto)
        {

            //VendedorJornada

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("Select VEJ.VEJFechaInicial as InicioJornada , VEJ.FechaFinal as FinJornada");
            sConsulta.AppendLine("from VendedorJornada VEJ (NOLOCK) ");
            sConsulta.AppendLine("inner join VenRut VER  (NOLOCK) on VEJ.VendedorId = VER.VendedorID");
            sConsulta.AppendLine("inner join Dia (NOLOCK)  on Dia.DiaClave = VEJ.DiaClave");
            sConsulta.AppendLine(pvCondicion2);


            QueryString = "";

            QueryString = sConsulta.ToString();


            List<liquidacionJornada> uno = Connection.Query<liquidacionJornada>(QueryString, null, null, true, 600).ToList();


            //***DOS
            sConsulta = new StringBuilder();
            sConsulta.AppendLine("select ");
            sConsulta.AppendLine("TRP.Folio,tpd.Subtotal as SubTotal, TRP.TipoFase");
            sConsulta.AppendLine("into #VentasSurtidas");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS  (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID and TRP.Tipo = 1 and TRP.TipoFase in (0,2)");
            sConsulta.AppendLine(pvCondicion1);
            //sConsulta.AppendLine("where 1 = 1  and VIS.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-28T00:00:00' and '2018-02-28T23:00:00'");
            sConsulta.AppendLine("DECLARE @SubTotalVentas float");
            sConsulta.AppendLine("Select distinct @SubTotalVentas = sum(SubTotal) from #VentasSurtidas where TipoFase = 2 ");

            sConsulta.AppendLine("select distinct TRI.TipoTripulacion, VAD.Descripcion as DescTripulacion, USU.Nombre,");
            sConsulta.AppendLine("CASE WHEN TRI.TipoTripulacion = 1 THEN CASE WHEN RUT.Tipo = 3 THEN COM.Comision WHEN RUT.Tipo = 1 THEN (@SubTotalVentas * (COM.ComisionChoferAutoventa / 100)) ELSE 0 END ");
            sConsulta.AppendLine("WHEN TRI.TipoTripulacion <>1 THEN CASE WHEN RUT.Tipo = 3 THEN  (COM.Comision * (COM.ComisionAyudanteReparto/100)) WHEN RUT.Tipo = 1 THEN (((@SubTotalVentas * (COM.ComisionChoferAutoventa / 100))) * (COM.ComisionAyudanteAutoventa/ 100)) ELSE 0  END ELSE 0 END as Comision");
            sConsulta.AppendLine("from VendedorJornada VEJ (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on VEJ.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join Tripulacion TRI (NOLOCK)  on VEJ.VEJFechaInicial = TRI.VEJFechaInicial and VEJ.VendedorId = TRI.VendedorId");
            sConsulta.AppendLine("inner join Usuario USU (NOLOCK)  on TRI.USUId = USU.USUId");
            sConsulta.AppendLine("inner join VenRut VER (NOLOCK)  on VEJ.VendedorId = VER.VendedorID");
            sConsulta.AppendLine("inner join VAVDescripcion VAD (NOLOCK)  on VAD.VARCodigo = 'TIPOTRI' and VAD.VAVClave = TRI.TipoTripulacion and VAD.VADTipoLenguaje = 'EM'");
            sConsulta.AppendLine("left join tmp_CalculoComision COM (NOLOCK)  on @SubTotalVentas between  VentaMin and VentaMax");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VER.RUTClave = RUT.RUTClave");
            sConsulta.AppendLine(pvCondicion2);
            //sConsulta.AppendLine("where 1 = 1  and VER.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-28T00:00:00' and '2018-02-28T23:00:00'");
            sConsulta.AppendLine("DROP TABLE #VentasSurtidas");


            QueryString = "";

            QueryString = sConsulta.ToString();


            List<liquidacionTripulacion> dos = Connection.Query<liquidacionTripulacion>(QueryString, null, null, true, 600).ToList();


            //TRESS
            sConsulta = new StringBuilder();
            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, TPD.CantidadOriginal, TPD.Precio, TPD.Promocion, ");
            sConsulta.AppendLine("CASE WHEN isnull(IMP.Abreviatura,'') = 'IEPS' THEN TDI.ImpuestoImp ELSE 0 END as IEPS, TRP.TipoFase, VIS.VendedorID,");
            sConsulta.AppendLine("TRP.Folio, TRP.Total, CLI.Clave, CLI.RazonSocial , TRP.FechaHoraAlta,");
            sConsulta.AppendLine("CASE WHEN not TRP.VisitaClave1 is null THEN isnull(TPD.CantidadOriginal,TPD.Cantidad ) * Precio ELSE null END as ImportePedido,");
            sConsulta.AppendLine("VIS.ClienteClave, VIS.RUTClave ");
            sConsulta.AppendLine("into #VentasSurtidas");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS  (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("                     isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join Cliente CLI  (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("left join TPDImpuesto TDI (NOLOCK)  on TPD.TransProdID = TDI.TransProdID and TPD.TransProdDetalleID = TDI.TransProdDetalleID ");
            sConsulta.AppendLine("left join Impuesto IMP (NOLOCK)  on TDI.ImpuestoClave = IMP.ImpuestoClave ");
            sConsulta.AppendLine("inner join Producto PRO  (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and TRP.Tipo = 1 and TRP.TipoFase in (0, 2)");
            sConsulta.AppendLine(pvCondicion1);
            sConsulta.AppendLine("Select sum(IEPS) as CalculoIEPS  from #VentasSurtidas where TipoFase = 2");
            sConsulta.AppendLine("DROP TABLE #VentasSurtidas");
            QueryString = "";

            QueryString = sConsulta.ToString();


            List<liquidacionCalculo> tres = Connection.Query<liquidacionCalculo>(QueryString, null, null, true, 600).ToList();


            ///cUATRO
            sConsulta = new StringBuilder();
            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, VEN.VendedorID, TPD.Cantidad into #InventarioInicial");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on TRP.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK)  on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK)  on VEN.USUId = TRP.MUsuarioID");
            sConsulta.AppendLine("inner join VenRut VNR  (NOLOCK) on VNR.VendedorID = VEN.VendedorID");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VNR.RUTClave = RUT.RUTClave and TRP.Tipo = 2 and TRP.TipoFase <> 0");
            sConsulta.AppendLine(pvCondicion);
            sConsulta.AppendLine("Select  'J000321' as CodigoReja, isnull(sum(Cantidad),0) as SaldoReja");
            sConsulta.AppendLine("from #InventarioInicial  (NOLOCK)  where ProductoClave = 'J000321'");
            sConsulta.AppendLine("DROP TABLE #InventarioInicial");
            QueryString = "";

            QueryString = sConsulta.ToString();


            List<liquidacionReja> cuatro = Connection.Query<liquidacionReja>(QueryString, null, null, true, 600).ToList();







            ///***Cinco
            sConsulta = new StringBuilder();

            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, TPD.CantidadOriginal, TPD.Precio, TPD.Promocion, ");
            sConsulta.AppendLine("TDI.ImpDesGlb as Impuestos, TRP.TipoFase, VIS.VendedorID,");
            sConsulta.AppendLine("TRP.Folio, TRP.Total, CLI.Clave, CLI.RazonSocial , TRP.FechaHoraAlta,");
            sConsulta.AppendLine("CASE WHEN not TRP.VisitaClave1 is null THEN isnull(TPD.CantidadOriginal,TPD.Cantidad ) * Precio ELSE null END as ImportePedido,");
            sConsulta.AppendLine("VIS.ClienteClave, VIS.RUTClave, ");
            sConsulta.AppendLine("TPD.DescuentoImp as DescuentoPromo, (isnull((select sum(DesImporte) from TpdDes DES (NOLOCK) where DES.TransProdId = TPD.TransProdId and DES.TransProdDetalleId = TPD.TransProdDetalleId  ), 0) ");
            sConsulta.AppendLine(" + isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV (NOLOCK) where DESV.TransProdId = TPD.TransProdId and DESV.TransProdDetalleId = TPD.TransProdDetalleId ), 0)) as DescuentoGlb,");
            sConsulta.AppendLine(" TPD.Subtotal as SubTotalDet");
            sConsulta.AppendLine("into #VentasSurtidas");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS  (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("                     isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join Cliente CLI  (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("left join TPDImpuesto TDI  (NOLOCK) on TPD.TransProdID = TDI.TransProdID and TPD.TransProdDetalleID = TDI.TransProdDetalleID ");
            sConsulta.AppendLine("left join Impuesto IMP  (NOLOCK) on TDI.ImpuestoClave = IMP.ImpuestoClave ");
            sConsulta.AppendLine("inner join Producto PRO  (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and TRP.Tipo = 1 and TRP.TipoFase = 2 and TPD.ProductoClave like 'T%' or  TPD.ProductoClave like 'J%'");
            //sConsulta.AppendLine("where 1 = 1  and VIS.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion1);

            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, VEN.VendedorID, TPD.Cantidad into #InventarioInicial");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on TRP.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK)  on VEN.USUId = TRP.MUsuarioID");
            sConsulta.AppendLine("inner join VenRut VNR  (NOLOCK) on VNR.VendedorID = VEN.VendedorID and TPD.ProductoClave like 'T%' or  TPD.ProductoClave like 'J%'");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VNR.RUTClave = RUT.RUTClave and TRP.Tipo = 2 and TRP.TipoFase <> 0");
            //sConsulta.AppendLine("where 1 = 1  and RUT.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion);

            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, VIS.VendedorID, TPD.Cantidad, TPD.TipoMotivo, VIS.ClienteClave into #Cambios");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK)  on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("                     isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID and TRP.Tipo = 9 and TRP.TipoFase = 1 and TRP.TipoMovimiento = 1 and TPD.TipoMotivo in(50,52) and TPD.ProductoClave like 'T%' or  TPD.ProductoClave like 'J%'");
            //sConsulta.AppendLine("where 1 = 1  and VIS.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion1);

            sConsulta.AppendLine("SELECT");
            sConsulta.AppendLine("PRO.ProductoClave as Codigo,");
            sConsulta.AppendLine("PRO.Nombre as Descripcion,");
            sConsulta.AppendLine("isnull(InventarioInicial,0) as InventarioInicial,");
            sConsulta.AppendLine("isnull(BuenEstado,0) as BuenEstado,");
            sConsulta.AppendLine("isnull(MermaCaducidad,0) as MermaCaducidad,");
            sConsulta.AppendLine("isnull(Bonificacion ,0) as Bonificacion,");
            sConsulta.AppendLine("isnull(FallaCalidad,0) as FallaCalidad,");
            sConsulta.AppendLine("isnull(MermaMaltrato ,0) as MermaMaltrato,");
            sConsulta.AppendLine("isnull(BuenEstado,0) + isnull(MermaCaducidad,0) + isnull(FallaCalidad,0) + isnull(MermaMaltrato ,0) as TotalEntrada,");
            sConsulta.AppendLine("isnull(Ventas,0) as Ventas,");
            sConsulta.AppendLine("isnull(PPV.Precio,0) as PrecioLista,");
            sConsulta.AppendLine("isnull(Bonificacion,0) * isnull(PPV.Precio,0) as PromocionPzas, ");
            sConsulta.AppendLine("isnull(DescuentoPromo,0)  + isnull(DescuentoGlb,0) as PromocionDesc, ");
            sConsulta.AppendLine("(isnull(SubTotalDet,0) - isnull(DescuentoGlb,0)) as ImporteVentasSinImp,");
            sConsulta.AppendLine("isnull(Impuestos,0) as Impuestos, ");
            sConsulta.AppendLine("(isnull(SubTotalDet,0) - isnull(DescuentoGlb,0)) + isnull(Impuestos,0) as ImporteVentasTotal");
            sConsulta.AppendLine("FROM");
            sConsulta.AppendLine("(");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, 'InventarioInicial' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#InventarioInicial ");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("select  TPD.ProductoClave, TPD.TipoUnidad, VEN.VendedorID, TPD.Cantidad, 'BuenEstado' as TipoMovimiento");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on TRP.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("inner join Vendedor VEN  (NOLOCK) on VEN.USUId = TRP.MUsuarioID ");
            sConsulta.AppendLine("inner join VenRut VNR  (NOLOCK) on VNR.VendedorID = VEN.VendedorID");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VNR.RUTClave = RUT.RUTClave and TRP.Tipo = 7 and TRP.TipoFase = 1 and TPD.ProductoClave like 'T%' or  TPD.ProductoClave like 'J%'");
            //sConsulta.AppendLine("where 1 = 1  and RUT.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion);

            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, CASE WHEN TipoMotivo = 50 THEN 'MermaCaducidad' ELSE 'FallaCalidad' END as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#Cambios  ");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, 'Bonificacion' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) = 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("select INV.ProductoClave, INV.TipoUnidad, VEN.VendedorID, INV.Cantidad, 'MermaMaltrato' as TipoMovimiento ");
            sConsulta.AppendLine("from InventarioTraspaso INV (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia (NOLOCK)  on INV.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK)  on VEN.USUId = INV.MUsuarioID ");
            sConsulta.AppendLine("inner join VenRut VNR (NOLOCK)  on VNR.VendedorID = VEN.VendedorID");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VNR.RUTClave = RUT.RUTClave and INV.TipoMotivo = 53 and Origen = 1 and Destino = 1 and INV.ProductoClave like 'T%' or  INV.ProductoClave like 'J%'");
            //sConsulta.AppendLine("where 1 = 1  and RUT.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion);

            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, 'Ventas' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, DescuentoPromo as Cantidad, 'DescuentoPromo' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, DescuentoGlb as Cantidad, 'DescuentoGlb' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Impuestos as Cantidad, 'Impuestos' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, SubTotalDet as Cantidad, 'SubtotalDet' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine(") pvt");
            sConsulta.AppendLine("PIVOT");
            sConsulta.AppendLine("(");
            sConsulta.AppendLine("sum(Cantidad) FOR TipoMovimiento IN   ([InventarioInicial],[BuenEstado],[MermaCaducidad], [Bonificacion],[FallaCalidad], [MermaMaltrato],[Ventas],[DescuentoPromo], [DescuentoGlb], [Impuestos],[SubTotalDet])");
            sConsulta.AppendLine(") AS Movimientos");
            sConsulta.AppendLine("inner join Producto PRO  (NOLOCK) on Movimientos.ProductoClave = PRO.ProductoClave");
            sConsulta.AppendLine("inner join Vendedor VEN  (NOLOCK) on VEN.VendedorID = Movimientos.VendedorID");
            sConsulta.AppendLine("left join PrecioProductoVig PPV  (NOLOCK) on PPV.PrecioClave = VEN.ListaPrecioBase  and PPV.ProductoClave = PRO.ProductoClave");
            sConsulta.AppendLine("and PPV.PRUTipoUnidad = Movimientos.TipoUnidad");
            sConsulta.AppendLine("and '" + FechaInicial + "' between PPV.PPVFechaInicio and PPV.FechaFin");
            sConsulta.AppendLine("DROP TABLE #VentasSurtidas");
            sConsulta.AppendLine("DROP TABLE #InventarioInicial");
            sConsulta.AppendLine("DROP TABLE #Cambios");

            QueryString = "";

            QueryString = sConsulta.ToString();


            List<liquidacionUniModel> cinco = Connection.Query<liquidacionUniModel>(QueryString, null, null, true, 600).ToList();

            if (cinco.Count != 0)
            {
                cinco.LastOrDefault().tInventarioInicial = cinco.Sum(c => c.InventarioInicial);
                cinco.LastOrDefault().tBuenEstado = cinco.Sum(c => c.BuenEstado);
                cinco.LastOrDefault().tMermaCaducidad = cinco.Sum(c => c.MermaCaducidad);
                cinco.LastOrDefault().tBonificacion = cinco.Sum(c => c.Bonificacion);
                cinco.LastOrDefault().tFallaCalidad = cinco.Sum(c => c.FallaCalidad);
                cinco.LastOrDefault().tMermaMaltrato = cinco.Sum(c => c.MermaMaltrato);
                cinco.LastOrDefault().tTotalEntrada = cinco.Sum(c => c.TotalEntrada);
                cinco.LastOrDefault().tVentas = cinco.Sum(c => c.Ventas);
                cinco.LastOrDefault().tPrecioLista = cinco.Sum(c => c.PrecioLista);
                cinco.LastOrDefault().tPromocionPzas = cinco.Sum(c => c.PromocionPzas);
                cinco.LastOrDefault().tPromocionDesc = cinco.Sum(c => c.PromocionDesc);
                cinco.LastOrDefault().tImporteVentasSinImp = cinco.Sum(c => c.ImporteVentasSinImp);
                cinco.LastOrDefault().tImpuestos = cinco.Sum(c => c.Impuestos);
                cinco.LastOrDefault().tImporteVentasTotal = cinco.Sum(c => c.ImporteVentasTotal);

            }





            DateTime fInicio = DateTime.Parse(FechaInicial);
            DateTime fFin = DateTime.Now;
            if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
            {
                FechaFinal = "";
            }
            else
            {
                fFin = DateTime.Parse(FechaFinal);
                FechaFinal = " - " + fFin.Date.ToShortDateString();

            }


            ReporteHojaDeLiquidacion report = new ReporteHojaDeLiquidacion();

            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            report.logo.Image = Image.FromStream(mStream);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;

            report.centro.Text = nombreCedis;
            report.ruta.Text = RutasSplit;
            DateTime dt = Convert.ToDateTime(FechaInicial);
            report.fentrega.Text = dt.ToString("dd/MM/yyyy");
            report.freporte.Text = DateTime.Now.ToString();


            //uno
            if (uno.Count != 0)
            {
                report.finicio.Text = uno.FirstOrDefault().InicioJornada.ToString();
                report.ffin.Text = uno.FirstOrDefault().FinJornada.ToString();
            }
            else
            {
                report.finicio.Text = "";
                report.ffin.Text = "";
            }


            //dos,
            //report.cofer.Text = dos.LastOrDefault().Nombre;
            //report.ayudante.Text = dos.FirstOrDefault().Nombre;

            Ayudante ayu = new Ayudante();
            ayu.DataSource = dos;




            ayu.empleado.DataBindings.Add("Text", null, "Nombre");
            ayu.rol.DataBindings.Add("Text", null, "DescTripulacion");
            ayu.comision.DataBindings.Add("Text", null, "Comision", "{0:$#,##0.00}");

            report.subayudante.ReportSource = ayu;





            //cuatro

            if (cuatro.Count != 0)
            {
                report.codigo.Text = cuatro.FirstOrDefault().CodigoReja.ToString();
                report.saldo.Text = cuatro.FirstOrDefault().SaldoReja.ToString();
            }
            else
            {
                report.codigo.Text = "";
                report.saldo.Text = "";
            }

            if (cinco.Count != 0)
            {


                SubLiquidacionPorCodigoUnifoods subReport1 = new SubLiquidacionPorCodigoUnifoods();
                subReport1.DataSource = cinco;

                report.imp.Text = cinco.Sum(c => c.Impuestos).ToString("$#,##0.00");
                subReport1.s1.DataBindings.Add("Text", null, "Codigo");
                subReport1.s2.DataBindings.Add("Text", null, "Descripcion");
                subReport1.s3.DataBindings.Add("Text", null, "InventarioInicial");
                subReport1.s4.DataBindings.Add("Text", null, "BuenEstado");
                subReport1.s5.DataBindings.Add("Text", null, "MermaCaducidad");
                subReport1.s6.DataBindings.Add("Text", null, "Bonificacion");
                subReport1.s7.DataBindings.Add("Text", null, "FallaCalidad");
                subReport1.s8.DataBindings.Add("Text", null, "MermaMaltrato");
                subReport1.s9.DataBindings.Add("Text", null, "TotalEntrada");
                subReport1.s10.DataBindings.Add("Text", null, "Ventas");
                subReport1.s11.DataBindings.Add("Text", null, "PrecioLista", "{0:$#,##0.00}");
                subReport1.s12.DataBindings.Add("Text", null, "PromocionPzas", "{0:$#,##0.00}");
                subReport1.s13.DataBindings.Add("Text", null, "PromocionDesc", "{0:$#,##0.00}");
                subReport1.s14.DataBindings.Add("Text", null, "ImporteVentasSinImp", "{0:$#,##0.00}");
                subReport1.s15.DataBindings.Add("Text", null, "Impuestos", "{0:$#,##0.00}");
                subReport1.s16.DataBindings.Add("Text", null, "ImporteVentasTotal", "{0:$#,##0.00}");

                subReport1.t1.DataBindings.Add("Text", null, "tInventarioInicial");
                subReport1.t2.DataBindings.Add("Text", null, "tBuenEstado");
                subReport1.t3.DataBindings.Add("Text", null, "tMermaCaducidad");
                subReport1.t4.DataBindings.Add("Text", null, "tBonificacion");
                subReport1.t5.DataBindings.Add("Text", null, "tFallaCalidad");
                subReport1.t6.DataBindings.Add("Text", null, "tMermaMaltrato");
                subReport1.t7.DataBindings.Add("Text", null, "tTotalEntrada");
                subReport1.t8.DataBindings.Add("Text", null, "tVentas");
                subReport1.t9.DataBindings.Add("Text", null, "tPrecioLista", "{0:$#,##0.00}");
                subReport1.t10.DataBindings.Add("Text", null, "tPromocionPzas", "{0:$#,##0.00}");
                subReport1.t11.DataBindings.Add("Text", null, "tPromocionDesc", "{0:$#,##0.00}");
                subReport1.t12.DataBindings.Add("Text", null, "tImporteVentasSinImp", "{0:$#,##0.00}");
                subReport1.t13.DataBindings.Add("Text", null, "tImpuestos", "{0:$#,##0.00}");
                subReport1.t14.DataBindings.Add("Text", null, "tImporteVentasTotal", "{0:$#,##0.00}");

                report.sub1.ReportSource = subReport1;

            }
            else
            {

                report.ti1.Text = "";
            }

            ////*****CincoDOS
            sConsulta = new StringBuilder();
            //Ventas
            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, TPD.CantidadOriginal, TPD.Precio, TPD.Promocion, ");
            sConsulta.AppendLine("TDI.ImpDesGlb as Impuestos, TRP.TipoFase, VIS.VendedorID,");
            sConsulta.AppendLine("TRP.Folio, TRP.Total, CLI.Clave, CLI.RazonSocial , TRP.FechaHoraAlta,");
            sConsulta.AppendLine("CASE WHEN not TRP.VisitaClave1 is null THEN isnull(TPD.CantidadOriginal,TPD.Cantidad ) * Precio ELSE null END as ImportePedido,");
            sConsulta.AppendLine("VIS.ClienteClave, VIS.RUTClave, ");
            sConsulta.AppendLine("TPD.DescuentoImp as DescuentoPromo, (isnull((select sum(DesImporte) from TpdDes DES (NOLOCK) where DES.TransProdId = TPD.TransProdId and DES.TransProdDetalleId = TPD.TransProdDetalleId  ), 0) ");
            sConsulta.AppendLine(" + isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV (NOLOCK) where DESV.TransProdId = TPD.TransProdId and DESV.TransProdDetalleId = TPD.TransProdDetalleId ), 0)) as DescuentoGlb,");
            sConsulta.AppendLine(" TPD.Subtotal as SubTotalDet");
            sConsulta.AppendLine("into #VentasSurtidas");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS  (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("                     isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join Cliente CLI  (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("left join TPDImpuesto TDI  (NOLOCK) on TPD.TransProdID = TDI.TransProdID and TPD.TransProdDetalleID = TDI.TransProdDetalleID ");
            sConsulta.AppendLine("left join Impuesto IMP  (NOLOCK) on TDI.ImpuestoClave = IMP.ImpuestoClave ");
            sConsulta.AppendLine("inner join Producto PRO  (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and TRP.Tipo = 1 and TRP.TipoFase = 2 and TPD.ProductoClave like 'V%'");
            //sConsulta.AppendLine("where 1 = 1  and VIS.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion1);

            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, VEN.VendedorID, TPD.Cantidad into #InventarioInicial");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on TRP.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK)  on VEN.USUId = TRP.MUsuarioID");
            sConsulta.AppendLine("inner join VenRut VNR  (NOLOCK) on VNR.VendedorID = VEN.VendedorID and TPD.ProductoClave like 'V%'");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VNR.RUTClave = RUT.RUTClave and TRP.Tipo = 2 and TRP.TipoFase <> 0");
            //sConsulta.AppendLine("where 1 = 1  and RUT.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion);

            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, VIS.VendedorID, TPD.Cantidad, TPD.TipoMotivo, VIS.ClienteClave into #Cambios");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK)  on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("                     isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID and TRP.Tipo = 9 and TRP.TipoFase = 1 and TRP.TipoMovimiento = 1 and TPD.TipoMotivo in(50,52) and TPD.ProductoClave like 'V%'");
            //sConsulta.AppendLine("where 1 = 1  and VIS.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion1);

            sConsulta.AppendLine("SELECT");
            sConsulta.AppendLine("PRO.ProductoClave as Codigo,");
            sConsulta.AppendLine("PRO.Nombre as Descripcion,");
            sConsulta.AppendLine("isnull(InventarioInicial,0) as InventarioInicial,");
            sConsulta.AppendLine("isnull(BuenEstado,0) as BuenEstado,");
            sConsulta.AppendLine("isnull(MermaCaducidad,0) as MermaCaducidad,");
            sConsulta.AppendLine("isnull(Bonificacion ,0) as Bonificacion,");
            sConsulta.AppendLine("isnull(FallaCalidad,0) as FallaCalidad,");
            sConsulta.AppendLine("isnull(MermaMaltrato ,0) as MermaMaltrato,");
            sConsulta.AppendLine("isnull(BuenEstado,0) + isnull(MermaCaducidad,0) + isnull(FallaCalidad,0) + isnull(MermaMaltrato ,0) as TotalEntrada,");
            sConsulta.AppendLine("isnull(Ventas,0) as Ventas,");
            sConsulta.AppendLine("isnull(PPV.Precio,0) as PrecioLista,");
            sConsulta.AppendLine("isnull(Bonificacion,0) * isnull(PPV.Precio,0) as PromocionPzas, ");
            sConsulta.AppendLine("isnull(DescuentoPromo,0)  + isnull(DescuentoGlb,0) as PromocionDesc, ");
            sConsulta.AppendLine("(isnull(SubTotalDet,0) - isnull(DescuentoGlb,0)) as ImporteVentasSinImp,");
            sConsulta.AppendLine("isnull(Impuestos,0) as Impuestos, ");
            sConsulta.AppendLine("(isnull(SubTotalDet,0) - isnull(DescuentoGlb,0)) + isnull(Impuestos,0) as ImporteVentasTotal");
            sConsulta.AppendLine("FROM");
            sConsulta.AppendLine("(");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, 'InventarioInicial' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#InventarioInicial ");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("select  TPD.ProductoClave, TPD.TipoUnidad, VEN.VendedorID, TPD.Cantidad, 'BuenEstado' as TipoMovimiento");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia  (NOLOCK) on TRP.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("inner join Vendedor VEN  (NOLOCK) on VEN.USUId = TRP.MUsuarioID ");
            sConsulta.AppendLine("inner join VenRut VNR  (NOLOCK) on VNR.VendedorID = VEN.VendedorID");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VNR.RUTClave = RUT.RUTClave and TRP.Tipo = 7 and TRP.TipoFase = 1 and TPD.ProductoClave like 'V%'");
            //sConsulta.AppendLine("where 1 = 1  and RUT.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion);

            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, CASE WHEN TipoMotivo = 50 THEN 'MermaCaducidad' ELSE 'FallaCalidad' END as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#Cambios  ");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, 'Bonificacion' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) = 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("select INV.ProductoClave, INV.TipoUnidad, VEN.VendedorID, INV.Cantidad, 'MermaMaltrato' as TipoMovimiento ");
            sConsulta.AppendLine("from InventarioTraspaso INV (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia (NOLOCK)  on INV.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK)  on VEN.USUId = INV.MUsuarioID ");
            sConsulta.AppendLine("inner join VenRut VNR (NOLOCK)  on VNR.VendedorID = VEN.VendedorID");
            sConsulta.AppendLine("inner join Ruta RUT  (NOLOCK) on VNR.RUTClave = RUT.RUTClave and INV.TipoMotivo = 53 and Origen = 1 and Destino = 1 and INV.ProductoClave like 'V%'");
            //sConsulta.AppendLine("where 1 = 1  and RUT.RUTClave in ('AA1426') and Dia.FechaCaptura between '2018-02-27T00:00:00' and '2018-02-27T23:00:00'");
            sConsulta.AppendLine(pvCondicion);


            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Cantidad, 'Ventas' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, DescuentoPromo as Cantidad, 'DescuentoPromo' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, DescuentoGlb as Cantidad, 'DescuentoGlb' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, Impuestos as Cantidad, 'Impuestos' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select ProductoClave, TipoUnidad, VendedorID, SubTotalDet as Cantidad, 'SubtotalDet' as TipoMovimiento");
            sConsulta.AppendLine("from ");
            sConsulta.AppendLine("#VentasSurtidas");
            sConsulta.AppendLine("where isnull(Promocion,0) <> 2 and TipoFase = 2");
            sConsulta.AppendLine(") pvt");
            sConsulta.AppendLine("PIVOT");
            sConsulta.AppendLine("(");
            sConsulta.AppendLine("sum(Cantidad) FOR TipoMovimiento IN   ([InventarioInicial],[BuenEstado],[MermaCaducidad], [Bonificacion],[FallaCalidad], [MermaMaltrato],[Ventas],[DescuentoPromo], [DescuentoGlb], [Impuestos],[SubTotalDet])");
            sConsulta.AppendLine(") AS Movimientos");
            sConsulta.AppendLine("inner join Producto PRO  (NOLOCK) on Movimientos.ProductoClave = PRO.ProductoClave");
            sConsulta.AppendLine("inner join Vendedor VEN  (NOLOCK) on VEN.VendedorID = Movimientos.VendedorID");
            sConsulta.AppendLine("left join PrecioProductoVig PPV  (NOLOCK) on PPV.PrecioClave = VEN.ListaPrecioBase  and PPV.ProductoClave = PRO.ProductoClave");
            sConsulta.AppendLine("and PPV.PRUTipoUnidad = Movimientos.TipoUnidad");
            sConsulta.AppendLine("and '" + FechaInicial + "' between PPV.PPVFechaInicio and PPV.FechaFin");
            sConsulta.AppendLine("DROP TABLE #VentasSurtidas");
            sConsulta.AppendLine("DROP TABLE #InventarioInicial");
            sConsulta.AppendLine("DROP TABLE #Cambios");



            QueryString = "";

            QueryString = sConsulta.ToString();


            List<liquidacionUniModel> cinco2 = Connection.Query<liquidacionUniModel>(QueryString, null, null, true, 600).ToList();

            if (cinco2.Count != 0)
            {
                cinco2.LastOrDefault().t2InventarioInicial = cinco2.Sum(c => c.InventarioInicial);
                cinco2.LastOrDefault().t2BuenEstado = cinco2.Sum(c => c.BuenEstado);
                cinco2.LastOrDefault().t2MermaCaducidad = cinco2.Sum(c => c.MermaCaducidad);
                cinco2.LastOrDefault().t2Bonificacion = cinco2.Sum(c => c.Bonificacion);
                cinco2.LastOrDefault().t2FallaCalidad = cinco2.Sum(c => c.FallaCalidad);
                cinco2.LastOrDefault().t2MermaMaltrato = cinco2.Sum(c => c.MermaMaltrato);
                cinco2.LastOrDefault().t2TotalEntrada = cinco2.Sum(c => c.TotalEntrada);
                cinco2.LastOrDefault().t2Ventas = cinco2.Sum(c => c.Ventas);
                cinco2.LastOrDefault().t2PrecioLista = cinco2.Sum(c => c.PrecioLista);
                cinco2.LastOrDefault().t2PromocionPzas = cinco.Sum(c => c.PromocionPzas);
                cinco2.LastOrDefault().t2PromocionDesc = cinco.Sum(c => c.PromocionDesc);
                cinco2.LastOrDefault().t2ImporteVentasSinImp = cinco.Sum(c => c.ImporteVentasSinImp);
                cinco2.LastOrDefault().t2Impuestos = cinco.Sum(c => c.Impuestos);
                cinco2.LastOrDefault().t2ImporteVentasTotal = cinco.Sum(c => c.ImporteVentasTotal);

                var a1 = cinco2.Sum(c => c.InventarioInicial) + cinco.Sum(c => c.InventarioInicial);
                var a2 = cinco2.Sum(c => c.BuenEstado) + cinco.Sum(c => c.BuenEstado);
                var a3 = cinco2.Sum(c => c.MermaCaducidad) + cinco.Sum(c => c.MermaCaducidad);
                var a4 = cinco2.Sum(c => c.Bonificacion) + cinco.Sum(c => c.Bonificacion);
                var a5 = cinco2.Sum(c => c.FallaCalidad) + cinco.Sum(c => c.FallaCalidad);
                var a6 = cinco2.Sum(c => c.MermaMaltrato) + cinco.Sum(c => c.MermaMaltrato);
                var a7 = cinco2.Sum(c => c.TotalEntrada) + cinco.Sum(c => c.TotalEntrada);
                var a8 = cinco2.Sum(c => c.Ventas) + cinco.Sum(c => c.Ventas);
                var a9 = cinco2.Sum(c => c.PrecioLista) + cinco.Sum(c => c.PrecioLista);
                var a10 = cinco2.Sum(c => c.PromocionPzas) + cinco.Sum(c => c.PromocionPzas);
                var a11 = cinco2.Sum(c => c.PromocionDesc) + cinco.Sum(c => c.PromocionDesc);
                var a12 = cinco2.Sum(c => c.ImporteVentasSinImp) + cinco.Sum(c => c.ImporteVentasSinImp);
                var a13 = cinco2.Sum(c => c.Impuestos) + cinco.Sum(c => c.Impuestos);
                var a14 = cinco2.Sum(c => c.ImporteVentasTotal) + cinco.Sum(c => c.ImporteVentasTotal);

                report.gt1.Text = a1.ToString();
                report.gt2.Text = a2.ToString();
                report.gt3.Text = a3.ToString();
                report.gt4.Text = a4.ToString();
                report.gt5.Text = a5.ToString();
                report.gt6.Text = a6.ToString();
                report.gt7.Text = a7.ToString();
                report.gt8.Text = a8.ToString();
                report.gt9.Text = a9.ToString("$#,##0.00");
                report.gt10.Text = a10.ToString("$#,##0.00");
                report.gt11.Text = a11.ToString("$#,##0.00");
                report.gt12.Text = a12.ToString("$#,##0.00");
                report.gt13.Text = a13.ToString("$#,##0.00");
                report.gt14.Text = a14.ToString("$#,##0.00");

                SubLiquidacionPorCodigoConsignacion subReport2 = new SubLiquidacionPorCodigoConsignacion();
                subReport2.DataSource = cinco2;

                subReport2.s21.DataBindings.Add("Text", null, "Codigo");
                subReport2.s22.DataBindings.Add("Text", null, "Descripcion");
                subReport2.s23.DataBindings.Add("Text", null, "InventarioInicial");
                subReport2.s24.DataBindings.Add("Text", null, "BuenEstado");
                subReport2.s25.DataBindings.Add("Text", null, "MermaCaducidad");
                subReport2.s26.DataBindings.Add("Text", null, "Bonificacion");
                subReport2.s27.DataBindings.Add("Text", null, "FallaCalidad");
                subReport2.s28.DataBindings.Add("Text", null, "MermaMaltrato");
                subReport2.s29.DataBindings.Add("Text", null, "TotalEntrada");
                subReport2.s210.DataBindings.Add("Text", null, "Ventas");
                subReport2.s211.DataBindings.Add("Text", null, "PrecioLista", "{0:$#,##0.00}");
                subReport2.s212.DataBindings.Add("Text", null, "PromocionPzas", "{0:$#,##0.00}");
                subReport2.s213.DataBindings.Add("Text", null, "PromocionDesc", "{0:$#,##0.00}");
                subReport2.s214.DataBindings.Add("Text", null, "ImporteVentasSinImp", "{0:$#,##0.00}");
                subReport2.s215.DataBindings.Add("Text", null, "Impuestos", "{0:$#,##0.00}");
                subReport2.s216.DataBindings.Add("Text", null, "ImporteVentasTotal", "{0:$#,##0.00}");

                var x1 = cinco2.Sum(c => c.InventarioInicial);
                var x2 = cinco2.Sum(c => c.BuenEstado);
                var x3 = cinco2.Sum(c => c.MermaCaducidad);
                var x4 = cinco2.Sum(c => c.Bonificacion);
                var x5 = cinco2.Sum(c => c.FallaCalidad);
                var x6 = cinco2.Sum(c => c.MermaMaltrato);
                var x7 = cinco2.Sum(c => c.TotalEntrada);
                var x8 = cinco2.Sum(c => c.Ventas);
                var x9 = cinco2.Sum(c => c.PrecioLista);
                var x10 = cinco2.Sum(c => c.PromocionPzas);
                var x11 = cinco2.Sum(c => c.PromocionDesc);
                var x12 = cinco2.Sum(c => c.ImporteVentasSinImp);
                var x13 = cinco2.Sum(c => c.Impuestos);
                var x14 = cinco2.Sum(c => c.ImporteVentasTotal);

                subReport2.x1.Text = x1.ToString();
                subReport2.x2.Text = x2.ToString();
                subReport2.x3.Text = x3.ToString();
                subReport2.x4.Text = x4.ToString();
                subReport2.x5.Text = x5.ToString();
                subReport2.x6.Text = x6.ToString();
                subReport2.x7.Text = x7.ToString();
                subReport2.x8.Text = x8.ToString();
                subReport2.x9.Text = x9.ToString("$#,##0.00");
                subReport2.x10.Text = x10.ToString("$#,##0.00");
                subReport2.x11.Text = x11.ToString("$#,##0.00");
                subReport2.x12.Text = x12.ToString("$#,##0.00");
                subReport2.x13.Text = x13.ToString("$#,##0.00");
                subReport2.x14.Text = x14.ToString("$#,##0.00");



                report.sub2.ReportSource = subReport2;


            }
            else
            {
                report.ti2.Text = "";

                var a1 = cinco.Sum(c => c.InventarioInicial);
                var a2 = cinco.Sum(c => c.BuenEstado);
                var a3 = cinco.Sum(c => c.MermaCaducidad);
                var a4 = cinco.Sum(c => c.Bonificacion);
                var a5 = cinco.Sum(c => c.FallaCalidad);
                var a6 = cinco.Sum(c => c.MermaMaltrato);
                var a7 = cinco.Sum(c => c.TotalEntrada);
                var a8 = cinco.Sum(c => c.Ventas);
                var a9 = cinco.Sum(c => c.PrecioLista);
                var a10 = cinco.Sum(c => c.PromocionPzas);
                var a11 = cinco.Sum(c => c.PromocionDesc);
                var a12 = cinco.Sum(c => c.ImporteVentasSinImp);
                var a13 = cinco.Sum(c => c.Impuestos);
                var a14 = cinco.Sum(c => c.ImporteVentasTotal);

                report.gt1.Text = a1.ToString();
                report.gt2.Text = a2.ToString();
                report.gt3.Text = a3.ToString();
                report.gt4.Text = a4.ToString();
                report.gt5.Text = a5.ToString();
                report.gt6.Text = a6.ToString();
                report.gt7.Text = a7.ToString();
                report.gt8.Text = a8.ToString();
                report.gt9.Text = a9.ToString("$#,##0.00");
                report.gt10.Text = a10.ToString("$#,##0.00");
                report.gt11.Text = a11.ToString("$#,##0.00");
                report.gt12.Text = a12.ToString("$#,##0.00");
                report.gt13.Text = a13.ToString("$#,##0.00");
                report.gt14.Text = a14.ToString("$#,##0.00");




            }
            ////Reporte 3




            //*************SEIS
            sConsulta = new StringBuilder();
            //Ventas
            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad, TPD.CantidadOriginal, TPD.Precio, ");
            sConsulta.AppendLine("TRP.Impuesto as Impuesto, TRP.TipoFase, VIS.VendedorID,");
            sConsulta.AppendLine("TRP.Folio, TRP.Total, CLI.Clave, CLI.RazonSocial , TRP.FechaHoraAlta,");
            sConsulta.AppendLine("CASE WHEN not TRP.VisitaClave1 is null THEN isnull(TPD.CantidadOriginal,TPD.Cantidad ) * TPD.Precio ELSE null END as ImportePedido,");
            sConsulta.AppendLine("CASE WHEN isnull(TPD.Promocion,0) = 2 THEN TPD.Cantidad * isnull(PPV.Precio,0)  ELSE 0 END as PromocionA,");
            sConsulta.AppendLine("VIS.ClienteClave, VIS.RUTClave,");
            sConsulta.AppendLine("TPD.DescuentoImp  + (isnull((select sum(DesImporte) from TpdDes DES (NOLOCK) where DES.TransProdId = TPD.TransProdId and DES.TransProdDetalleId = TPD.TransProdDetalleId  ), 0) ");
            sConsulta.AppendLine(" + isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV (NOLOCK) where DESV.TransProdId = TPD.TransProdId and DESV.TransProdDetalleId = TPD.TransProdDetalleId ), 0)) as Descuentos, ");
            sConsulta.AppendLine(" TRP.Subtotal");
            sConsulta.AppendLine("into #VentasSurtidas");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
            sConsulta.AppendLine("left join TPDImpuesto TDI (NOLOCK) on TPD.TransProdID = TDI.TransProdID and TPD.TransProdDetalleID = TDI.TransProdDetalleID ");
            sConsulta.AppendLine("left join Impuesto IMP (NOLOCK) on TDI.ImpuestoClave = IMP.ImpuestoClave ");
            sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and TRP.Tipo = 1 and TRP.TipoFase in(0,2)");
            sConsulta.AppendLine("inner join Vendedor VEN  (NOLOCK) on VEN.VendedorID = VIS.VendedorID");
            sConsulta.AppendLine("left join PrecioProductoVig PPV  (NOLOCK) on PPV.PrecioClave = VEN.ListaPrecioBase  and PPV.ProductoClave = TPD.ProductoClave");
            sConsulta.AppendLine("and PPV.PRUTipoUnidad = TPD.TipoUnidad");
            sConsulta.AppendLine("and '" + FechaInicial + "' between PPV.PPVFechaInicio and PPV.FechaFin");
            sConsulta.AppendLine(pvCondicion1);


            sConsulta.AppendLine("Declare @RutaPrev1 as varchar(10), @RutaPrev2 as varchar(10)");
            sConsulta.AppendLine("Select TOP 1 @RutaPrev1 = RutaPreventa1, @RutaPrev2 = RutaPreventa2");
            sConsulta.AppendLine("from tmp_RutaPreventaReparto (NOLOCK) ");
            sConsulta.AppendLine(pvCondicion4);



            sConsulta.AppendLine("select TRP.Folio, CLI.Clave, VIS.ClienteClave, TRP.FechaHoraAlta, CLI.RazonSocial, VIS.RUTClave, TRP.TipoFase, TRP.Tipo, TRP.Subtotal as ImportePedido  into #CanceladosInt");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on  TRP.VisitaClave = VIS.VisitaClave and");
            sConsulta.AppendLine("TRP.DiaClave = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
            sConsulta.AppendLine("where 1 = 1  and TRP.Tipo =1 and TRP.TipoFase = 16 and VIS.RUTClave in (@RutaPrev1, @RutaPrev2) and TRP.FechaCancelacion  between '" + FechaInicial + "' and '" + FechaFinal + "'");

            sConsulta.AppendLine("select TPD.ProductoClave, TPD.TipoUnidad, VIS.VendedorID, TPD.Cantidad, TPD.TipoMotivo, VIS.ClienteClave into #Cambios");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine("isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID and TRP.Tipo = 9 and TRP.TipoFase = 1 and TRP.TipoMovimiento = 1 and TPD.TipoMotivo in(50,52)");
            sConsulta.AppendLine(pvCondicion1);


            sConsulta.AppendLine(" Select Folio, Estatus, FechaHoraAlta, CLIClave, RazonSocial, sum(ImportePedido) as ImportePedido,  sum(PromocionA) as PromocionA, sum(PromocionB) as PromocionB,");
            sConsulta.AppendLine(" (Select sum(Cantidad) from #Cambios CAM where CAM.ClienteClave = ventas.ClienteClave  ) as Cambios, SubTotal, Impuesto, Importe");
            sConsulta.AppendLine(" from(");
            sConsulta.AppendLine(" Select VES.Folio, 'Surtido' as Estatus,TipoFase,  FechaHoraAlta,");
            sConsulta.AppendLine(" Clave as CLIClave, ClienteClave,RazonSocial, ImportePedido, CASE WHEN TipoFase = 2 THEN Total ELSE 0 END  as Importe, ");
            sConsulta.AppendLine("PromocionA, Descuentos as PromocionB, SubTotal, Impuesto");
            sConsulta.AppendLine(" from #VentasSurtidas VES where TipoFase = 2) as ventas");
            sConsulta.AppendLine(" group by  Folio, Estatus, TipoFase, FechaHoraAlta, CLIClave, RazonSocial, SubTotal, Impuesto, Importe,ventas.ClienteClave");
            sConsulta.AppendLine(" UNION ");
            sConsulta.AppendLine(" Select Folio, Estatus, FechaHoraAlta, CLIClave, RazonSocial, sum(ImportePedido) as ImportePedido,  0 as PromocionA, 0 as PromocionB,");
            sConsulta.AppendLine(" 0 as Cambios, 0 as SubTotal, 0 as Impuesto, 0 as Importe");
            sConsulta.AppendLine(" from(");
            sConsulta.AppendLine(" Select VES.Folio, 'No surtido' as Estatus,TipoFase,  FechaHoraAlta,");
            sConsulta.AppendLine(" Clave as CLIClave, ClienteClave,RazonSocial, ImportePedido");
            sConsulta.AppendLine(" from #VentasSurtidas VES where TipoFase = 0");
            sConsulta.AppendLine(" UNION ");
            sConsulta.AppendLine(" Select Folio, 'No surtido' as Estatus, TipoFase, FechaHoraAlta, Clave as CLIClave, ClienteClave, RazonSocial, ImportePedido  ");
            sConsulta.AppendLine(" from #CanceladosInt");
            sConsulta.AppendLine(" ) as ventas");
            sConsulta.AppendLine(" group by  Folio, Estatus, TipoFase, FechaHoraAlta, CLIClave, RazonSocial, ventas.ClienteClave");
            sConsulta.AppendLine(" order by  Estatus desc ,  Folio");

            sConsulta.AppendLine("DROP TABLE #VentasSurtidas");
            sConsulta.AppendLine("DROP TABLE #Cambios");
            sConsulta.AppendLine("DROP TABLE #CanceladosInt");




            QueryString = "";

            QueryString = sConsulta.ToString();


            List<liquidacionUniSurtidos> seis = Connection.Query<liquidacionUniSurtidos>(QueryString, QueryString, null, true, 600).ToList();

            if (seis.Count != 0)
            {



                seis.LastOrDefault().tPromocionA = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.PromocionA);
                seis.LastOrDefault().tPromocionB = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.PromocionB);
                seis.LastOrDefault().tImportePedido = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.ImportePedido);
                seis.LastOrDefault().tCambios = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.Cambios);
                seis.LastOrDefault().tSubTotal = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.SubTotal);
                seis.LastOrDefault().tImpuesto = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.Impuesto);
                seis.LastOrDefault().tImporte = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.Importe);

                //clientesS.gt23.Text = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.Promocion).ToString();



                SubClientesSurtidos clientesS = new SubClientesSurtidos();
                clientesS.DataSource = seis;//.Where(c => c.Estatus == "Surtido");



                //Clientes Surtidos
                clientesS.s31.DataBindings.Add("Text", null, "Folio");
                clientesS.s32.DataBindings.Add("Text", null, "Estatus");
                clientesS.s33.DataBindings.Add("Text", null, "FechaHoraAlta", "{0:HH:mm}");
                clientesS.s34.DataBindings.Add("Text", null, "CLIClave");
                clientesS.s35.DataBindings.Add("Text", null, "RazonSocial");
                clientesS.s36.DataBindings.Add("Text", null, "PromocionA");
                clientesS.s37.DataBindings.Add("Text", null, "PromocionB");
                clientesS.s38.DataBindings.Add("Text", null, "Cambios");
                clientesS.s39.DataBindings.Add("Text", null, "ImportePedido", "{0:$#,##0.00}");
                clientesS.s310.DataBindings.Add("Text", null, "SubTotal", "{0:$#,##0.00}");
                clientesS.s311.DataBindings.Add("Text", null, "Impuesto", "{0:$#,##0.00}");
                clientesS.s312.DataBindings.Add("Text", null, "Importe", "{0:$#,##0.00}");


                clientesS.gt21.DataBindings.Add("Text", null, "tPromocionA");
                clientesS.gt22.DataBindings.Add("Text", null, "tPromocionB");
                clientesS.gt23.DataBindings.Add("Text", null, "tCambios");
                clientesS.gt24.DataBindings.Add("Text", null, "tImportePedido", "{0:$#,##0.00}");
                clientesS.gt25.DataBindings.Add("Text", null, "tSubTotal", "{0:$#,##0.00}");
                clientesS.gt26.DataBindings.Add("Text", null, "tImpuesto", "{0:$#,##0.00}");
                clientesS.gt27.DataBindings.Add("Text", null, "tImporte", "{0:$#,##0.00}");
                //clientesS.gt23.Text = seis.Where(c => c.Estatus == "Surtido").Sum(c => c.Promocion).ToString();


                report.sub3.ReportSource = clientesS;


                //ClientesNoSurtidos
                //SubClientesNoSurtidos clientesNS = new SubClientesNoSurtidos();
                //clientesNS.DataSource = seis.Where(c => c.Estatus != "Surtido");


                //clientesNS.s231.DataBindings.Add("Text", null, "Folio");
                //clientesNS.s232.DataBindings.Add("Text", null, "Estatus");
                //clientesNS.s233.DataBindings.Add("Text", null, "FechaHoraAlta", "{0:HH:mm}");
                //clientesNS.s234.DataBindings.Add("Text", null, "CLIClave");
                //clientesNS.s235.DataBindings.Add("Text", null, "RazonSocial");
                //clientesNS.s236.DataBindings.Add("Text", null, "PromocionA");
                //clientesNS.s237.DataBindings.Add("Text", null, "PromocionB");
                //clientesNS.s238.DataBindings.Add("Text", null, "Cambios");
                //clientesNS.s239.DataBindings.Add("Text", null, "ImportePedido", "{0:$#,##0.00}"); 
                //clientesNS.s2310.DataBindings.Add("Text", null, "SubTotal", "{0:$#,##0.00}"); 
                //clientesNS.s2311.DataBindings.Add("Text", null, "Impuesto", "{0:$#,##0.00}");
                //clientesNS.s2312.DataBindings.Add("Text", null, "Importe", "{0:$#,##0.00}");



                //report.sub32.ReportSource = clientesNS;
            }
            else
            {
                report.ti3.Text = "";
            }


            //Siete
            sConsulta = new StringBuilder();
            //Ventas
            sConsulta.AppendLine("Declare @RutaPrev1 as varchar(10), @RutaPrev2 as varchar(10)");
            sConsulta.AppendLine("Select TOP 1 @RutaPrev1 = RutaPreventa1, @RutaPrev2 = RutaPreventa2");
            sConsulta.AppendLine("from tmp_RutaPreventaReparto (NOLOCK) ");
            sConsulta.AppendLine(pvCondicion4);

            sConsulta.AppendLine("Select * into #Ventas from (");
            sConsulta.AppendLine("select TRP.Folio, VIS.ClienteClave, VIS.RUTClave, TRP.TipoFase, TRP.Tipo ");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave) = VIS.VisitaClave and");
            sConsulta.AppendLine(" isnull(TRP.DiaClave1 ,TRP.DiaClave) = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine(pvCondicion1 + " and TRP.Tipo =1 and TRP.TipoFase in (0, 2)");

            sConsulta.AppendLine("UNION");
            sConsulta.AppendLine("select TRP.Folio, VIS.ClienteClave, VIS.RUTClave, TRP.TipoFase, TRP.Tipo  ");
            sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on  TRP.VisitaClave = VIS.VisitaClave and");
            sConsulta.AppendLine(" TRP.DiaClave = VIS.DiaClave ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
            sConsulta.AppendLine(pvCondicion5 + " and TRP.Tipo in( 1,9) and TRP.TipoFase = 16 and VIS.RUTClave in (@RutaPrev1, @RutaPrev2) ");

            sConsulta.AppendLine(") as tmp");

            sConsulta.AppendLine("SELECT");
            sConsulta.AppendLine("isnull(ClientesProgramados,0) as ClientesProgramados,");
            sConsulta.AppendLine("isnull(ClientesVisitados,0) as ClientesVisitados,");
            sConsulta.AppendLine("isnull(PedidosPorEntregar,0) as PedidosPorEntregar,");
            sConsulta.AppendLine("isnull(PedidosEntregados,0) as PedidosEntregados,");
            sConsulta.AppendLine("isnull(CtePedidoEntregado,0) as CtePedidoEntregado,");
            sConsulta.AppendLine("isnull(CtePedidoNoEntregado ,0) as CtePedidoNoEntregado,");
            sConsulta.AppendLine("Round(((cast(isnull(ClientesVisitados,0)as decimal)/cast(isnull(ClientesProgramados,0) as decimal))*100),2) as EfectividadVisita,");
            sConsulta.AppendLine("Round(((cast(isnull(PedidosEntregados,0) as decimal)/cast(isnull(PedidosPorEntregar ,0)as decimal))*100),2) as EfectividadEntrega");
            sConsulta.AppendLine("from(");
            sConsulta.AppendLine("Select AGV.RUTClave,count(Distinct AGV.ClienteClave ) as Cantidad, 'ClientesProgramados' as Valor");
            sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = AGV.DiaClave");
            sConsulta.AppendLine(pvCondicion3);

            sConsulta.AppendLine("and AGV.ClienteClave in(Select distinct ClienteClave from #Ventas )");
            sConsulta.AppendLine("group by AGV.RUTClave ");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select VIS.RUTClave, count(Distinct VIS.ClienteClave ) as Cantidad, 'ClientesVisitados' as Valor");
            sConsulta.AppendLine("from Visita VIS (NOLOCK) ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = VIS.DiaClave ");
            sConsulta.AppendLine(pvCondicion1);

            sConsulta.AppendLine("group by VIS.RUTClave");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select VEN.RUTClave, count(Distinct VEN.Folio), 'PedidosPorEntregar'");
            sConsulta.AppendLine("from #Ventas VEN");
            sConsulta.AppendLine("where VEN.Tipo = 1");
            sConsulta.AppendLine("group by VEN.RUTClave ");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select VEN.RUTClave, count(Distinct VEN.Folio), 'PedidosEntregados'");
            sConsulta.AppendLine("from #Ventas VEN");
            sConsulta.AppendLine("where VEN.TipoFase = 2 and VEN.tipo = 1");
            sConsulta.AppendLine("group by VEN.RUTClave ");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select VEN.RUTClave, count(Distinct VEN.ClienteClave), 'CtePedidoEntregado'");
            sConsulta.AppendLine("from #Ventas VEN");
            sConsulta.AppendLine("where VEN.TipoFase = 2 and VEN.Tipo = 1");
            sConsulta.AppendLine("group by VEN.RUTClave");
            sConsulta.AppendLine("UNION ALL");
            sConsulta.AppendLine("Select VEN.RUTClave, count(Distinct VEN.ClienteClave), 'CtePedidoNoEntregado'");
            sConsulta.AppendLine("from #Ventas VEN");
            sConsulta.AppendLine("where VEN.TipoFase in( 0,16) and VEN.Tipo = 1");
            sConsulta.AppendLine("group by VEN.RUTClave");
            sConsulta.AppendLine(") Valores");
            sConsulta.AppendLine("PIVOT");
            sConsulta.AppendLine("(");
            sConsulta.AppendLine("sum(Cantidad) FOR Valor IN ([ClientesProgramados],[ClientesVisitados],[PedidosPorEntregar], [PedidosEntregados],[CtePedidoEntregado], [CtePedidoNoEntregado])");
            sConsulta.AppendLine(") AS Contadores ");
            sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on RUT.RUTClave = Contadores.RUTClave");
            sConsulta.AppendLine("where RUT.Tipo = 3");
            sConsulta.AppendLine("");
            sConsulta.AppendLine("Select Count(CLI.ClienteClave )  as ClientesNuevos");
            sConsulta.AppendLine("from Cliente CLI (NOLOCK) ");
            sConsulta.AppendLine(pvCondicion6);

            //sConsulta.AppendLine("where 1 = 1  and Clave in ('AA1428') and convert(datetime,Convert(varchar(20),CLI.FechaRegistroSistema,112))='2018-02-20T00:00:00'");

            sConsulta.AppendLine("DROP TABLE #Ventas");


            QueryString = "";

            QueryString = sConsulta.ToString();

            List<liquidacionUnitotal> siete = Connection.Query<liquidacionUnitotal>(QueryString, null, null, true, 600).ToList();
            if (siete.Count != 0)
            {




                siete.LastOrDefault().gtImporte = seis.Sum(c => c.Importe);
                siete.LastOrDefault().tPre = ((seis.Sum(c => c.Importe) / int.Parse(Presupuesto)) * 100);



                ///*SEGUNDOS VISITAA**///

                ///
                sConsulta = new StringBuilder();

                sConsulta.AppendLine("Select  avg(DATEDIFF(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) as SegundosVisitaAux");
                sConsulta.AppendLine("from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine(pvCondicion1);

                QueryString = "";

                QueryString = sConsulta.ToString();

                List<SegundosVisita> segundos = Connection.Query<SegundosVisita>(QueryString, null, null, true, 600).ToList();

                //**------------------*//
                long seg = 0;
                foreach (var e in segundos)
                {
                    seg = e.SegundosVisitaAux;
                }




                SubResumenGeneral general = new SubResumenGeneral();
                general.DataSource = siete;

                //Grantotala liquidar

                general.gtl.DataBindings.Add("Text", null, "gtImporte", "{0:$#,##0.00}");
                general.rg12.DataBindings.Add("Text", null, "tPre", "{0:#0.00}%");


                general.rg1.DataBindings.Add("Text", null, "ClientesProgramados");
                general.rg2.DataBindings.Add("Text", null, "ClientesVisitados");
                general.rg3.DataBindings.Add("Text", null, "PedidosPorEntregar");
                general.rg4.DataBindings.Add("Text", null, "PedidosEntregados");
                general.rg5.DataBindings.Add("Text", null, "CtePedidoEntregado");
                general.rg6.DataBindings.Add("Text", null, "CtePedidoNoEntregado");
                general.rg7.DataBindings.Add("Text", null, "EfectividadVisita", "{0:#0.00}%");
                general.rg8.DataBindings.Add("Text", null, "EfectividadEntrega", "{0:#0.00}%");
                // general.rg9.DataBindings.Add("Text", null, "SegundosVisita");

                Int32 tsegundos = Convert.ToInt32(seg);

                Int32 horas = (tsegundos / 3600);
                Int32 minutos = ((tsegundos - horas * 3600) / 60);
                Int32 segundos2 = tsegundos - (horas * 3600 + minutos * 60);


                DateTime da = new DateTime(1, 1, 1, horas, minutos, segundos2, 0);
                var s = String.Format("{0:HH:mm:ss}", da);
                general.rg9.Text = s;

                general.rg10.DataBindings.Add("Text", null, "ClientesNuevos");


                int p = Int32.Parse(Presupuesto);


                var p1 = String.Format("{0:$#,##0.00}", p);
                general.rg11.Text = p1;
                report.sub4.ReportSource = general;
            }
            else
            {
                report.ti4.Text = "";
            }

            if (cinco.Count == 0 && cinco2.Count == 0 && seis.Count == 0 && siete.Count == 0)
            {
                return null;
            }


            return report;
        }
    }

    class liquidacionJornada
    {

        public DateTime InicioJornada { get; set; }
        public DateTime FinJornada { get; set; }


    }
    class liquidacionTripulacion
    {


        public String Nombre { get; set; }
        public String DescTripulacion { get; set; }
        public int TipoTripulacion { get; set; }
        public Decimal Comision { get; set; }



    }
    class liquidacionCalculo
    {

        public Decimal CalculoIEPS { get; set; }

    }
    class liquidacionReja
    {

        public string CodigoReja { get; set; }
        public int SaldoReja { get; set; }

    }

    class uniontd
    {
        public DateTime InicioJornada { get; set; }
        public DateTime FinJornada { get; set; }
        public String Nombre { get; set; }
        public String DescTripulacion { get; set; }
        public int TipoTripulacion { get; set; }
        public Decimal Comision { get; set; }
        public Decimal CalculoIEPS { get; set; }
        public string CodigoReja { get; set; }
        public int SaldoReja { get; set; }
    }

    class liquidacionUniModel
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int InventarioInicial { get; set; }
        public int BuenEstado { get; set; }
        public int MermaCaducidad { get; set; }
        public int Bonificacion { get; set; }
        public int FallaCalidad { get; set; }
        public int MermaMaltrato { get; set; }
        public int TotalEntrada { get; set; }
        public int Ventas { get; set; }
        public Decimal PrecioLista { get; set; }
        public Decimal PromocionPzas { get; set; }
        public Decimal PromocionDesc { get; set; }
        public Decimal ImporteVentasSinImp { get; set; }
        public Decimal Impuestos { get; set; }
        public Decimal ImporteVentasTotal { get; set; }


        public int tInventarioInicial { get; set; }
        public int tBuenEstado { get; set; }
        public int tMermaCaducidad { get; set; }
        public int tBonificacion { get; set; }
        public int tFallaCalidad { get; set; }
        public int tMermaMaltrato { get; set; }
        public int tTotalEntrada { get; set; }
        public int tVentas { get; set; }
        public Decimal tPrecioLista { get; set; }
        public Decimal tPromocionPzas { get; set; }
        public Decimal tPromocionDesc { get; set; }
        public Decimal tImporteVentasSinImp { get; set; }
        public Decimal tImpuestos { get; set; }
        public Decimal tImporteVentasTotal { get; set; }


        public int t2InventarioInicial { get; set; }
        public int t2BuenEstado { get; set; }
        public int t2MermaCaducidad { get; set; }
        public int t2Bonificacion { get; set; }
        public int t2FallaCalidad { get; set; }
        public int t2MermaMaltrato { get; set; }
        public int t2TotalEntrada { get; set; }
        public int t2Ventas { get; set; }
        public Decimal t2PrecioLista { get; set; }
        public Decimal t2PromocionPzas { get; set; }
        public Decimal t2PromocionDesc { get; set; }
        public Decimal t2ImporteVentasSinImp { get; set; }
        public Decimal t2Impuestos { get; set; }
        public Decimal t2ImporteVentasTotal { get; set; }




    }


    class liquidacionUniSurtidos
    {
        public string Folio { get; set; }
        public string Estatus { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public string CLIClave { get; set; }
        public string RazonSocial { get; set; }
        public Decimal ImportePedido { get; set; }
        public int PromocionA { get; set; }
        public int PromocionB { get; set; }
        public int Cambios { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Impuesto { get; set; }
        public Decimal Importe { get; set; }



        public int tPromocionA { get; set; }
        public int tPromocionB { get; set; }
        public int tCambios { get; set; }
        public Decimal tImportePedido { get; set; }
        public Decimal tSubTotal { get; set; }
        public Decimal tImpuesto { get; set; }
        public Decimal tImporte { get; set; }
    }

    class liquidacionUnitotal
    {

        public Decimal gtImporte { get; set; }
        public int ClientesProgramados { get; set; }
        public int ClientesVisitados { get; set; }
        public int PedidosPorEntregar { get; set; }
        public int PedidosEntregados { get; set; }
        public int CtePedidoEntregado { get; set; }
        public int CtePedidoNoEntregado { get; set; }
        public int EfectividadVisita { get; set; }
        public int EfectividadEntrega { get; set; }
        public int SegundosVisita { get; set; }
        public int ClientesNuevos { get; set; }
        public Decimal tPre { get; set; }




    }
    public class SegundosVisita
    {
        public long SegundosVisitaAux { get; set; }
    }


}