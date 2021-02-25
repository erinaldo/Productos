using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class MFacturaGlobalPDR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string FechaIni, string FechaFin, string Vendedores)
        {
            try
            {
                if (FechaFin == "")
                    FechaFin = FechaIni;

                DateTime dFechaIni;
                DateTime.TryParse(FechaIni, out dFechaIni);
                DateTime dFechaFin;                
                DateTime.TryParse(FechaFin, out dFechaFin);             
                dFechaFin = dFechaFin.Date.AddSeconds(86399);                

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("select trp.Folio, trp.FechaCaptura, cli.NombreCorto, cli.RazonSocial, trp.Total ");
                sConsulta.AppendLine("from TransProd trp ");
                sConsulta.AppendLine("inner join Visita vis on isnull(trp.VisitaClave1, trp.VisitaClave) = vis.VisitaClave and isnull(trp.DiaClave1, trp.DiaClave) = vis.DiaClave ");
                sConsulta.AppendLine("inner join Dia on vis.DiaClave = Dia.DiaClave "); 
                sConsulta.AppendLine("inner join Cliente cli on vis.ClienteClave = cli.ClienteClave ");
                sConsulta.AppendLine("where trp.Tipo = 1 and trp.TipoFase = 2 and trp.CFVTipo = 1 and cli.IdFiscal = 'XAXX010101000' ");
                sConsulta.AppendLine("and Dia.FechaCaptura between  '" + dFechaIni.ToString("s") + "' AND '" + dFechaFin.ToString("s") + "' ");
                sConsulta.AppendLine("and vis.VendedorID in (" + Vendedores + ") ");
                sConsulta.AppendLine("order by trp.Folio, trp.FechaCaptura ");               
                string sVentas = sConsulta.ToString();

                sConsulta.Clear();
                sConsulta.AppendLine("select trp.Folio, abn.FechaAbono, cli.NombreCorto, cli.RazonSocial, abt.Importe ");
                sConsulta.AppendLine("from Abono abn ");
                sConsulta.AppendLine("inner join Visita vis on abn.VisitaClave = vis.VisitaClave and abn.DiaClave = vis.DiaClave ");
                sConsulta.AppendLine("inner join Dia on vis.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Cliente cli on vis.ClienteClave = cli.ClienteClave ");
                sConsulta.AppendLine("inner join AbnTrp abt on abn.ABNId = abt.ABNId ");
                sConsulta.AppendLine("inner join TransProd trp on abt.TransProdID = trp.TransProdID ");
                sConsulta.AppendLine("where trp.CFVTipo = 2 and cli.IdFiscal = 'XAXX010101000' ");
                sConsulta.AppendLine("and Dia.FechaCaptura between  '" + dFechaIni.ToString("s") + "' AND '" + dFechaFin.ToString("s") + "' ");
                sConsulta.AppendLine("and vis.VendedorID in (" + Vendedores + ") ");
                sConsulta.AppendLine("order by trp.Folio, abn.FechaAbono ");
                string sCobranza = sConsulta.ToString();

                FacturaGlobalPDR rptPDR = new FacturaGlobalPDR(sVentas, sCobranza);
                rptPDR.lbNombreReporte.Text = ValorReferencia.ObtenerDescripcion("REPORTEW", "257", "EM").ToUpper();
                rptPDR.lbTituloVentas.Text = Mensaje.ObtenerDescripcion("XVentaGlobalPDR", "EM").ToUpper();
                rptPDR.lbFolio.Text = Mensaje.ObtenerDescripcion("XFolio", "EM").ToUpper();
                rptPDR.lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM").ToUpper();
                rptPDR.lbNombre.Text = Mensaje.ObtenerDescripcion("XNombreComercial", "EM").ToUpper();
                rptPDR.lbRazon.Text = Mensaje.ObtenerDescripcion("XRazonSocial", "EM").ToUpper();
                rptPDR.lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM").ToUpper();
                rptPDR.lbTotalVentas.Text = Mensaje.ObtenerDescripcion("XTotalVentaGlobalPDR", "EM").ToUpper();

                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbTituloCobranza.Text = Mensaje.ObtenerDescripcion("XCobranzaGlobalPDR", "EM").ToUpper();
                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbFolio.Text = Mensaje.ObtenerDescripcion("XFolio", "EM").ToUpper();
                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM").ToUpper();
                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbNombre.Text = Mensaje.ObtenerDescripcion("XNombreComercial", "EM").ToUpper();
                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbRazon.Text = Mensaje.ObtenerDescripcion("XRazonSocial", "EM").ToUpper();
                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM").ToUpper();
                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbTotalCobranza.Text = Mensaje.ObtenerDescripcion("XTotalCobranzaGlobalPDR", "EM").ToUpper();
                ((CobranzaFacturaGlobalPDR)rptPDR.rptCobranza.ReportSource).lbTotal.Text = Mensaje.ObtenerDescripcion("XTotal", "EM").ToUpper();

                rptPDR.Name = "FacturaGlobalPDR" + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss") + ".xlsx";
                return rptPDR;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

     

    }
      

}
