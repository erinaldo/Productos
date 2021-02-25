using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.DataAccess.Sql;
using Microsoft.Ajax.Utilities;

namespace eRoute.Models.ReportesModels
{
    public class LibroRutaVitere
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string RutasSplit, string FechaInicial, string FechaFinal, string NomCEDI)
        {
            try
            {
                //LIBRODERUTAS
                #region consultaPrincipal
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.AppendLine("SELECT SEC.RUTClave, RUTR.Descripcion AS RUTDescripcion, CLI.Clave AS CLIClave, CLI.RazonSocial AS CLIRazonSocial, ISNULL( CLI.NombreCorto, '') AS CLINombreCorto, ");
                sConsulta.AppendLine("CLD.Calle + CASE WHEN CLD.Numero IS NULL THEN '' ELSE ' ' + CLD.Numero END + CASE WHEN CLD.NumInt IS NULL THEN '' ELSE ' ' + CLD.NumInt END AS Calle, CLD.Numero, ISNULL(CLD.NumInt, '') AS NumInt, ");
                sConsulta.AppendLine("ISNULL(CLD.ReferenciaDom, '') AS Referencia, CLD.Localidad, CLD.Poblacion, CLD.Colonia, TRP.Folio, TPD.ProductoClave, PRO.Nombre AS PRONombre, TPD.Cantidad, CASE WHEN trp.tipo = 3 THEN '0' WHEN trp.tipo = 1 THEN TPD.Precio END AS Precio, CASE WHEN trp.tipo = 3 THEN '0' WHEN trp.tipo = 1 THEN (TPD.Cantidad * TPD.Precio) END AS Total, ");
                sConsulta.AppendLine("CASE WHEN TRP.Tipo = 1 THEN 'Pedidos' WHEN TRP.Tipo = 3 THEN 'Devoluciones' END AS TipoMovimiento ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("LEFT JOIN (SELECT DISTINCT Ruta.RUTClave, Secuencia.ClienteClave FROM Secuencia INNER JOIN Ruta (NOLOCK) ON Secuencia.RUTClave = Ruta.RUTClave WHERE Ruta.Tipo = 3 AND TipoEstado = 1) AS SEC on VIS.ClienteClave = SEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Ruta RUTP (NOLOCK) ON VIS.RUTClave = RUTP.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Ruta RUTR (NOLOCK) ON SEC.RUTClave = RUTR.RUTClave ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorID = VIS.VendedorID AND TRP.FechaHoraAlta BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.AlmacenID = VCH.AlmacenID ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN ClienteDomicilio CLD (NOLOCK) ON CLI.ClienteClave = CLD.ClienteClave AND CLD.Tipo = 2 ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("WHERE TRP.Tipo IN (1, 3) AND TRP.TipoFase IN (1, 7) ");
                sConsulta.AppendLine(pvCondicion + pvCondicion1);
                sConsulta.AppendLine("ORDER BY VIS.Numero, SEC.RUTClave, TRP.Folio desc, CLI.Clave, TRP.Tipo, PRO.Id");

                QueryString = "";
                QueryString = sConsulta.ToString();
                #endregion

                List<LibroRuta> Principal = Connection.Query<LibroRuta>(QueryString, null, null, true, 600).ToList();

                var SubUno = (from A in Principal
                              select A).ToList();

                var Pedidos = (from P in Principal
                               where P.TipoMovimiento.Equals("Pedidos")
                               select P).ToList();

                var totalPedidos = Pedidos.Sum(c => c.Total);

                var Devoluciones = (from P in Principal
                                    where P.TipoMovimiento.Equals("Devoluciones")
                                    select P).ToList();

                var totalDevoluciones = Devoluciones.Sum(c => c.Total);

                if (Principal.Count != 0)
                {
                    rep_LibroRutaVitere reportDis = new rep_LibroRutaVitere();

                    DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
                    customSqlQuery1.Name = "Query";
                    customSqlQuery1.Sql = QueryString;

                    reportDis.sqlDataSource1.Queries[0] = customSqlQuery1;

                    //ReportHeader
                    #region reporteLibroRutaVitere
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

                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    reportDis.logo.Image = Image.FromStream(mStream);
                    reportDis.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    reportDis.empresa.Text = NombreEmpresa;
                    reportDis.reporte.Text = NombreReporte;

                    reportDis.L_FechaRango.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                    reportDis.L_CEDI.Text = NomCEDI.ToString();
                    reportDis.L_Ruta.Text = RutasSplit;

                    reportDis.L_TotalPed.Text = totalPedidos.ToString("##,##0.00");
                    reportDis.L_TotalDev.Text = totalDevoluciones.ToString("##,##0.00");

                    reportDis.Name = NombreReporte + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");

                    #endregion

                    return reportDis;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    class LibroRuta
    {
        //PRINCIPAL
        public string RUTClave { get; set; }
        public string RUTDescripcion { get; set; }
        public string CLIClave { get; set; }
        public string CLIRazonSocial { get; set; }
        public string CLINombreCorto { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string NumInt { get; set; }
        public string Referencia { get; set; }
        public string Colonia { get; set; }
        public string Folio { get; set; }
        public string ProductoClave { get; set; }
        public string PRONombre { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Total { get; set; }
        public string TipoMovimiento { get; set; }

        //PRINCIPAL_subtotales
        public Decimal tTotal { get; set; }
    }
}