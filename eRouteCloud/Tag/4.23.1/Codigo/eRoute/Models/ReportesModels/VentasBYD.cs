using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class VentasBYD
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private DateTime fInicio;
        private DateTime fFin;
        ReporteVentasBYD report = new ReporteVentasBYD();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string CEDIS, string FechaInicial, string FechaFinal, string Objeto, string NombreObjeto, string Clientes, bool FiltroReporte)
        {
            try
            {
                report.cliente.Text = (Clientes == "" ? "Todos los Clientes" : Clientes);
                report.filtro.Text = Objeto;

                //Parameters
                Objeto = (Objeto == "" ? "null" : "'" + Objeto + "'");
                Clientes = (Clientes == "" ? "null" : "'" + Clientes + "'");
                CEDIS = (CEDIS == "" ? "null" : "'" + CEDIS + "'");
                fInicio = DateTime.Parse(FechaInicial);
                FechaInicial = fInicio.Date.ToString("yyyyMMdd");
                FechaInicial = (FechaInicial == "" ? "null" : "'" + FechaInicial + "'");
                fFin = DateTime.Parse(FechaFinal);
                FechaFinal = fFin.Date.ToString("yyyyMMdd");

                //ReportHeader
                report.nameFechas.Text = (FechaFinal == FechaInicial ? "Fecha:" : "Rango de Fechas:");
                FechaInicial = this.fInicio.Date.ToShortDateString();
                FechaFinal = this.fFin.Date.ToShortDateString();
                report.fecha.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);
                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;
                report.centro.Text = NombreCEDIS;
                report.nameFiltro.Text = (FiltroReporte ? "Vendedor:" : "Ruta:");
                
                StringBuilder Consulta = new StringBuilder();
                Consulta.AppendLine("SET ANSI_WARNINGS OFF ");
                Consulta.AppendLine("SET NOCOUNT ON ");
                Consulta.AppendLine("SELECT Dia.FechaCaptura, VIS.VendedorID, VIS.RUTClave, CLI.Clave + ' - ' + CLI.RazonSocial AS ClienteDetalle, TRP.Folio AS Folio, TPD.ProductoClave + ' - ' + PRO.NombreLargo AS ProductoDetalle, TPD.Cantidad AS Cantidad, (TPD.Precio * TPD.Cantidad) AS Monto, ");
                Consulta.AppendLine("TPD.DescuentoImp AS Descuento, TPD.Subtotal AS SubTotal, ");
                Consulta.AppendLine("ISNULL((SELECT SUM(ImpuestoImp) FROM TPDImpuesto TPI (NOLOCK) INNER JOIN Impuesto IMP (NOLOCK) ON TPI.ImpuestoClave = IMP.ImpuestoClave AND IMP.Abreviatura = 'IEPS' WHERE TPI.TransProdID = TPD.TransProdID AND TPI.TransProdDetalleID = TPD.TransProdDetalleID ), 0) AS IEPS, ");
                Consulta.AppendLine("ISNULL((SELECT SUM(ImpuestoImp) FROM TPDImpuesto TPI (NOLOCK) INNER JOIN Impuesto IMP (NOLOCK) ON TPI.ImpuestoClave = IMP.ImpuestoClave AND IMP.Abreviatura = 'IVA' WHERE TPI.TransProdID = TPD.TransProdID AND TPI.TransProdDetalleID = TPD.TransProdDetalleID ), 0) AS IVA, ");
                Consulta.AppendLine("TPD.Total AS Total ");
                Consulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                Consulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID AND TRP.Tipo = 1 AND TRP.TipoFase IN (2, 3) ");
                Consulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRO.ProductoClave = TPD.ProductoClave ");
                Consulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                Consulta.AppendLine(FiltroReporte ? "AND ((VIS.VendedorId IN (SELECT Datos FROM FNSplit((" + Objeto + "), ','))) OR " + Objeto + " IS NULL) " : "AND ((VIS.RUTClave IN (SELECT Datos FROM FNSplit((" + Objeto + "), ','))) OR " + Objeto + " IS NULL) ");
                Consulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                Consulta.AppendLine("AND ((Dia.FechaCaptura BETWEEN '" + FechaInicial + "' AND '" + FechaFinal + "') OR " + FechaInicial + " IS NULL) ");
                Consulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave ");
                Consulta.AppendLine("AND ((CLI.ClienteClave IN (SELECT Datos FROM FNSplit((" + Clientes + "), ','))) OR " + Clientes + " IS NULL) ");
                Consulta.AppendLine("ORDER BY CLI.Clave, TRP.Folio, TPD.ProductoClave ");

                QueryString = "";
                QueryString = Consulta.ToString();

                List<VentasBYDModel> Cliente = Connection.Query<VentasBYDModel>(QueryString, null, null, true, 600).ToList();
                var Ventas = (from c in Cliente
                              select c).ToList();
                List<VentasBYDModel> Cli = new List<VentasBYDModel>();
                var SV = (from gr in Ventas group gr by new { gr.Folio } into grupo select grupo);

                string Total = "Gran Total";
                long TotalCantidad = 0;
                Decimal TotalMonto = 0;
                Decimal TotalDescuento = 0;
                Decimal TotalSubTotal = 0;
                Decimal TotalIEPS = 0;
                Decimal TotalIVA = 0;
                Decimal TotalTotal = 0;

                foreach (var grupo in SV)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Cli.Add(new VentasBYDModel
                        {
                            ClienteDetalle = objetoAgrupado.ClienteDetalle,
                            Folio = objetoAgrupado.Folio,
                            ProductoDetalle = objetoAgrupado.ProductoDetalle,
                            Cantidad = objetoAgrupado.Cantidad,
                            Monto = objetoAgrupado.Monto,
                            Descuento = objetoAgrupado.Descuento,
                            SubTotal = objetoAgrupado.SubTotal,
                            IEPS = objetoAgrupado.IEPS,
                            IVA = objetoAgrupado.IVA,
                            Total = objetoAgrupado.Total
                        });
                        Cli.Last().SubTF = "Folio:";
                        Cli.Last().SubT = "Subtotal";
                        Cli.Last().SubTCantidad = grupo.Sum(c => c.Cantidad);
                        Cli.Last().SubTMonto = grupo.Sum(c => c.Monto);
                        Cli.Last().SubTDescuento = grupo.Sum(c => c.Descuento);
                        Cli.Last().SubTSubTotal = grupo.Sum(c => c.SubTotal);
                        Cli.Last().SubTIEPS = grupo.Sum(c => c.IEPS);
                        Cli.Last().SubTIVA = grupo.Sum(c => c.IVA);
                        Cli.Last().SubTTotal = grupo.Sum(c => c.Total);

                        TotalCantidad += objetoAgrupado.Cantidad;
                        TotalMonto += objetoAgrupado.Monto;
                        TotalDescuento += objetoAgrupado.Descuento;
                        TotalSubTotal += objetoAgrupado.SubTotal;
                        TotalIEPS += objetoAgrupado.IEPS;
                        TotalIVA += objetoAgrupado.IVA;
                        TotalTotal += objetoAgrupado.Total;
                    }
                }

                report.DataSource = Cli;

                //grouheader2
                GroupField groupCliente = new GroupField("ClienteDetalle");
                report.GroupHeader2.GroupFields.Add(groupCliente);
                report.labelClienteDetalle.DataBindings.Add("Text", report.DataSource, "ClienteDetalle");

                //grouheader1
                GroupField groupFolio = new GroupField("Folio");
                report.GroupHeader1.GroupFields.Add(groupFolio);
                report.labelF.DataBindings.Add("Text", report.DataSource, "SubTF");
                report.labelFolioDetalle.DataBindings.Add("Text", report.DataSource, "Folio");

                ////Datos Generales
                report.labelProducto.DataBindings.Add("Text", report.DataSource, "ProductoDetalle");
                report.labelCantidad.DataBindings.Add("Text", null, "Cantidad");
                report.labelMonto.DataBindings.Add("Text", null, "Monto", "{0:$0.00}");
                report.labelDescuento.DataBindings.Add("Text", null, "Descuento", "{0:$0.00}");
                report.labelSubtotal.DataBindings.Add("Text", null, "SubTotal", "{0:$0.00}");
                report.labelIEPS.DataBindings.Add("Text", null, "IEPS", "{0:$0.00}");
                report.labelIVA.DataBindings.Add("Text", null, "IVA", "{0:$0.00}");
                report.labelNeto.DataBindings.Add("Text", null, "Total", "{0:$0.00}");

                //GroupFooter1
                report.labelS.DataBindings.Add("Text", report.DataSource, "SubT");
                report.labelSCantidad.DataBindings.Add("Text", null, "SubTCantidad");
                report.labelSMonto.DataBindings.Add("Text", null, "SubTMonto", "{0:$0.00}");
                report.labelSDescuento.DataBindings.Add("Text", null, "SubTDescuento", "{0:$0.00}");
                report.labelSSubtotal.DataBindings.Add("Text", null, "SubTSubTotal", "{0:$0.00}");
                report.labelSIEPS.DataBindings.Add("Text", null, "SubTIEPS", "{0:$0.00}");
                report.labelSIVA.DataBindings.Add("Text", null, "SubTIVA", "{0:$0.00}");
                report.labelSNeto.DataBindings.Add("Text", null, "SubTTotal", "{0:$0.00}");

                //ReportFooter
                report.labelT.Text = Total;
                report.labelTCantidad.Text = TotalCantidad + "";
                report.labelTMonto.Text = TotalMonto.ToString("$0.00");
                report.labelTDescuento.Text = TotalDescuento.ToString("$0.00");
                report.labelTSubtotal.Text = TotalSubTotal.ToString("$0.00");
                report.labelTIEPS.Text = TotalIEPS.ToString("$0.00");
                report.labelTIVA.Text = TotalIVA.ToString("$0.00");
                report.labelTNeto.Text = TotalTotal.ToString("$0.00");

                //Regresa el reporte completo
                if (Cli.Count == 0)
                {
                    return null;
                }
                else
                {
                    return report;
                }
            }
            catch (Exception ex)
            {
                return new ReporteVentasBYD();
            }
        }

    }

    class VentasBYDModel
    {
        public string ClienteDetalle { get; set; }
        public string Folio { get; set; }
        public string ProductoDetalle { get; set; }
        public long Cantidad { get; set; }
        public Decimal Monto { get; set; }
        public Decimal Descuento { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal IEPS { get; set; }
        public Decimal IVA { get; set; }
        public Decimal Total { get; set; }

        public string SubT { get; set; }
        public string SubTF { get; set; }
        public long SubTCantidad { get; set; }
        public Decimal SubTMonto { get; set; }
        public Decimal SubTDescuento { get; set; }
        public Decimal SubTSubTotal { get; set; }
        public Decimal SubTIEPS { get; set; }
        public Decimal SubTIVA { get; set; }
        public Decimal SubTTotal { get; set; }
    }
}