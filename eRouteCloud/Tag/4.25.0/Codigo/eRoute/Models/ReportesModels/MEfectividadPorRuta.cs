using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class MEfectividadPorRuta
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string VendedoresSplit, string ClientesSplit, string FechaInicial, string FechaFinal, string Cedis, string NombreCedis, bool detallado)
        {
            StringBuilder sConsulta = new StringBuilder();
            if (detallado)
            {
                #region reporte detallado
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
                FechaInicial = fInicio.ToShortDateString();
                efectividadPorRutaDetallado report = new efectividadPorRutaDetallado();
                report.Ruta.Text = RutasSplit;
                report.CEDIS.Text = NombreCedis;
                report.Fecha.Text = FechaInicial + FechaFinal;
                if (String.IsNullOrEmpty(VendedoresSplit))
                {
                    report.Vendedor.Text = "";
                }
                else
                {
                    report.Vendedor.Text = VendedoresSplit;
                }
                string queryPrincipal, Tiempos, TotalClientes, ClientesNoVisitados, ClientesVisitados, ClientesVisitadosFA, TotalVisitados, ClientesVisitadosConVenta,
                ClientesVisitadosConVentaFA, ClientesVisitadosSinVenta, ClientesVisitadosSinVentaFA, TotalVisitadosSinVenta, ImproductividadVenta,
                ImproductividadVentaFA, TotalEncuestas, EncuestasAplicadas, EncuestasAplicadasFA, EncuestasNoAplicadas, EncuestasNoAplicadasFA,
                TotalVisitadosEncuestar, ClientesEncuestados, ClientesEncuestadosFA, ClientesNoEncuestados, ClientesNoEncuestadosFA, CodigosLeidos,
                CodigosLeidosFA, CodigosNoLeidos, CodigosNoLeidosFA, ProductoNegado, ProductoNegadoFA, ImproductividadProducto,
                ImproductividadProductoFA, MotivosImproductividad, MotivosImproductividadFA, ProductoPromoNoEntregado, ProductoPromoNoEntregadoFA,
                TotalProductosPromocional, TotalProductoPromocionalFA, ClientesProductoNegado, ClientesProductoNegadoFA, ClientesImproductividadProducto,
                ClientesImproductividadProductoFA, ClientesProductoPromoNoEntregadoEnAgenda, ClienteProductoPromoNoEntregadoFA;

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT ALN.Nombre AS Almacen, DIA.FechaCaptura, VEN.VendedorId, VEN.Nombre AS Vendedor, RUT.RUTClave, RUT.Descripcion AS Ruta, ALN.Clave AS AlmacenId, Dia.DiaClave ");
                sConsulta.AppendLine("FROM (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave "); //WHERE 1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                queryPrincipal = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI AS AlmacenId, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, MIN(VIS.FechaHoraInicial) AS HoraInicial, MAX(VIS.FechaHoraFinal) AS HoraFinal, DATEDIFF(second, MIN(VIS.FechaHoraInicial), MAX(VIS.FechaHoraFinal)) AS TiempoRecorrido, SUM(DATEDIFF(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) AS TiempoVisita ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClienteClave, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ON VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorId AND VIS.RUTClave = AGV.RUTClave AND VIS.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ");
                Tiempos = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalCliente ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ");
                TotalClientes = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave AND CLI.ClienteClave NOT IN (SELECT ClienteClave FROM Visita VIS (NOLOCK) WHERE VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorId AND VIS.RUTClave = AGV.RUTClave) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesNoVisitados = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RutClave = VIS.RutClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesVisitados = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RutClave = VIS.RutClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesVisitadosFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ISNULL(COUNT(DISTINCT VIS.ClienteClave), 0) AS TotalCliente ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND AGV.DiaClave = VIS.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RutClave = VIS.RutClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ");
                TotalVisitados = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente Cli (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesVisitadosConVenta = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' -' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente Cli (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesVisitadosConVentaFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, Ult.Fecha ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave AND NOT VIS.VisitaClave IN (SELECT TRP.VisitaClave FROM TransProd TRP (NOLOCK) WHERE TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("LEFT JOIN (SELECT v.clienteclave, MAX(fechahoraalta) AS Fecha FROM transprod t (NOLOCK) INNER JOIN visita v (NOLOCK) ON v.visitaclave = t.visitaclave AND v.visitaclave = t.visitaclave WHERE (tipo = 1 AND tipofase <> 0) GROUP BY v.clienteclave) Ult ON Cli.clienteclave = Ult.clienteclave ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesVisitadosSinVenta = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' -' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, Ult.Fecha ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave AND NOT VIS.VisitaClave IN (SELECT TRP.VisitaClave FROM TransProd TRP (NOLOCK) WHERE TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("LEFT JOIN (SELECT v.clienteclave, MAX(fechahoraalta) AS Fecha FROM transprod t (NOLOCK) INNER JOIN visita v (NOLOCK) ON v.visitaclave = t.visitaclave AND v.visitaclave = t.visitaclave WHERE (tipo = 1 AND tipofase <> 0) GROUP BY v.clienteclave) Ult ON Cli.clienteclave = Ult.clienteclave ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesVisitadosSinVentaFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) - ISNULL(COUNT(DISTINCT(CASE WHEN TRP.VisitaClave IS NULL THEN NULL ELSE VIS.ClienteClave END)), 0) AS TotalCliente ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND VIS.ClienteClave = AGV.ClienteClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("LEFT JOIN ImproductividadVenta IMV (NOLOCK) ON IMV.VisitaClave = VIS.VisitaClave AND IMV.DiaClave = VIS.DiaClave AND NOT VIS.VisitaClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                TotalVisitadosSinVenta = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) (NOLOCK) WHERE VarCodigo = 'Motimpro' AND VAVClave = IMV.TipoMotivo AND VADTipoLenguaje = 'EM') AS Motivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadVenta IMV (NOLOCK) ON IMV.VisitaClave = VIS.VisitaClave AND IMV.DiaClave = VIS.DiaClave AND NOT VIS.VisitaClave IN (SELECT VIS1.VisitaClave FROM Visita VIS1 (NOLOCK) ON INNER JOIN TransProd TRP (NOLOCK) ON VIS1.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE 1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                QueryString = "";
                QueryString = sConsulta.ToString();
                List<ImproductividadVentaDet> ImproductividadVentas = Connection.Query<ImproductividadVentaDet>(QueryString, null, null, true, 600).ToList();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) (NOLOCK) WHERE VarCodigo = 'Motimpro' AND VAVClave = IMV.TipoMotivo AND VADTipoLenguaje = 'EM') AS Motivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadVenta IMV (NOLOCK) ON IMV.VisitaClave = VIS.VisitaClave AND IMV.DiaClave = VIS.DiaClave AND NOT VIS.VisitaClave IN (SELECT VIS1.VisitaClave FROM Visita VIS1 (NOLOCK) INNER JOIN TransProd TRP (NOLOCK) ON VIS1.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ImproductividadVentaFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ISNULL(COUNT(DISTINCT CEC.CENClave), 0) AS TotalEncuesta ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON CEC.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                TotalEncuestas = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CEN.Descripcion AS Encuesta, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS.VisitaClave AND Enc.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ConfigEncuesta CEN (NOLOCK) ON CEN.CENClave = ENC.CENClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                EncuestasAplicadas = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CEN.Descripcion AS Encuesta, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS.VisitaClave AND Enc.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ConfigEncuesta CEN (NOLOCK) ON CEN.CENClave = ENC.CENClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave "); //WHERE 1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                EncuestasAplicadasFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CEN.Descripcion AS Encuesta, AGV.RUTClave, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON CEC.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN ConfigEncuesta CEN (NOLOCK) ON CEN.CenClave = CEC.CenClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion + " AND CEC.CENClave NOT IN (SELECT DISTINCT CEN.CENClave FROM AgendaVendedor AGV1 (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV1.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV1.DiaClave AND VIS.VendedorId = AGV1.VendedorID AND VIS.RUTClave = AGV1.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS.VisitaClave AND Enc.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ConfigEncuesta CEN (NOLOCK) ON CEN.CENClave = ENC.CENClave ");
                sConsulta.AppendLine("WHERE AGV.DiaClave = AGV1.DiaClave AND AGV.VendedorId = AGV1.VendedorId AND AGV.RutClave = AGV1.RutClave) ");
                EncuestasNoAplicadas = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CEN.Descripcion AS Encuesta, AGV.RUTClave, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON CEC.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN ConfigEncuesta CEN (NOLOCK) ON CEN.CenClave = CEC.CenClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion + " AND CEC.CENClave NOT IN (SELECT DISTINCT CEN.CENClave FROM AgendaVendedor AGV1 (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV1.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV1.DiaClave AND VIS.VendedorId = AGV1.VendedorID AND VIS.RUTClave = AGV1.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS.VisitaClave AND Enc.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ConfigEncuesta CEN (NOLOCK) ON CEN.CENClave = ENC.CENClave ");
                sConsulta.AppendLine("WHERE AGV.DiaClave = AGV1.DiaClave AND AGV.VendedorId = AGV1.VendedorId AND AGV.RutClave = AGV1.RutClave) ");
                EncuestasNoAplicadasFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, ISNULL(COUNT(DISTINCT VIS.ClienteClave), 0) AS TotalCliente ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN CenCli CEC (NOLOCK) ON AGV.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND AGV.DiaClave = VIS.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RutClave = VIS.RutClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ");
                TotalVisitadosEncuestar = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS.VisitaClave AND Enc.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesEncuestados = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS.VisitaClave AND Enc.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesEncuestadosFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN CenCli CEC (NOLOCK) ON CLI.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("AND CLI.ClienteClave NOT IN (SELECT DISTINCT CLI1.ClienteClave FROM AgendaVendedor AGV1 (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI1 ON AGV1.ClienteClave = CLI1.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS1 (NOLOCK) ON CLI1.ClienteClave = VIS1.ClienteClave AND VIS1.DiaClave = AGV1.DiaClave AND VIS1.VendedorId = AGV1.VendedorID AND VIS1.RUTClave = AGV1.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS1.VisitaClave AND Enc.DiaClave = VIS1.DiaClave ");
                sConsulta.AppendLine("WHERE AGV.DiaClave = AGV1.DiaClave AND AGV.VendedorId = AGV1.VendedorId AND AGV.RutClave = AGV1.RutClave) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesNoEncuestados = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN CenCli CEC (NOLOCK) ON CLI.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("AND CLI.ClienteClave NOT IN (SELECT DISTINCT CLI1.ClienteClave FROM AgendaVendedor AGV1 (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI1 ON AGV1.ClienteClave = CLI1.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS1 (NOLOCK) ON CLI1.ClienteClave = VIS1.ClienteClave AND VIS1.DiaClave = AGV1.DiaClave AND VIS1.VendedorId = AGV1.VendedorID AND VIS1.RUTClave = AGV1.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Encuesta ENC (NOLOCK) ON Enc.VisitaClave = VIS1.VisitaClave AND Enc.DiaClave = VIS1.DiaClave ");
                sConsulta.AppendLine("WHERE AGV.DiaClave = AGV1.DiaClave AND AGV.VendedorId = AGV1.VendedorId AND AGV.RutClave = AGV1.RutClave) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                ClientesNoEncuestadosFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave AND VIS.CodigoLeido = 1 ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                CodigosLeidos = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave AND VIS.CodigoLeido = 1 ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                CodigosLeidosFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave AND VIS.CodigoLeido = 0 ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                CodigosNoLeidos = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT CLI.ClienteClave, CLI.Clave + ' - ' + CLI.NombreCorto AS Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave AND VIS.CodigoLeido = 0 ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ORDER BY Nombre ");
                CodigosNoLeidosFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT PRO.Nombre, SUM(PRD.Factor * PRG.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ProductoNegado = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT PRO.Nombre, SUM(PRD.Factor * PRG.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ProductoNegadoFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT PRO.Nombre, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'Motimpro' AND VAVClave = IMR.TipoMotivo AND VADTipoLenguaje = 'EM') AS Motivo, SUM(IMR.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON IMR.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY PRO.Nombre, IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ImproductividadProducto = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT PRO.Nombre, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'Motimpro' AND VAVClave = IMR.TipoMotivo AND VADTipoLenguaje = 'EM') AS Motivo, SUM(IMR.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON IMR.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY PRO.Nombre, IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ImproductividadProductoFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'Motimpro' AND VAVClave = IMR.TipoMotivo AND VADTipoLenguaje = 'EM') AS Motivo, SUM(IMR.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                MotivosImproductividad = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT DISTINCT (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'Motimpro' AND VAVClave = IMR.TipoMotivo AND VADTipoLenguaje = 'EM') AS Motivo, SUM(IMR.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY IMR.TipoMotivo, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                MotivosImproductividadFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT PRO.Nombre, SUM(PRD.Factor * PRG.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ProductoPromoNoEntregado = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT PRO.Nombre, SUM(PRD.Factor * PRG.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ProductoPromoNoEntregadoFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, SUM(PRD.Factor * TPD.Cantidad) AS TotalCliente ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <>0 ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TPD.TransProdId = TRP.TransProdId AND TPD.Promocion = 2 ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                TotalProductosPromocional = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, SUM(PRD.Factor * TPD.Cantidad) AS TotalCliente ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <>0 ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TPD.TransProdId = TRP.TransProdId AND TPD.Promocion = 2 ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                TotalProductoPromocionalFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT CLI.Clave + ' - ' + CLI.NombreCorto AS Cliente, PRO.Nombre AS Producto, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'UNIDADV' AND VAVClave = PRG.TipoUnidad AND VADTipoLenguaje = 'EM') AS Unidad, SUM(PRG.Cantidad) AS Cantidad, SUM(PRD.Factor * PRG.Cantidad) AS CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY CLI.Clave, CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("ORDER BY CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad ");
                ClientesProductoNegado = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT CLI.Clave + ' - ' + CLI.NombreCorto AS Cliente, PRO.Nombre AS Producto, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'UNIDADV' AND VAVClave = PRG.TipoUnidad AND VADTipoLenguaje = 'EM') AS Unidad, SUM(PRG.Cantidad) AS Cantidad, SUM(PRD.Factor * PRG.Cantidad) AS CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY CLI.Clave, CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("ORDER BY CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad ");
                ClientesProductoNegadoFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT CLI.Clave + ' - ' + CLI.NombreCorto AS Cliente, PRO.Nombre AS Producto, SUM(IMR.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON IMR.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY CLI.Clave, CLI.NombreCorto, PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ClientesImproductividadProducto = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT CLI.Clave + ' - ' + CLI.NombreCorto AS Cliente, PRO.Nombre AS Producto, SUM(IMR.Cantidad) AS Cantidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON IMR.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY CLI.Clave, CLI.NombreCorto, PRO.Nombre, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                ClientesImproductividadProductoFA = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT CLI.Clave + ' - ' + CLI.NombreCorto AS Cliente, PRO.Nombre AS Producto, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'UNIDADV' AND VAVClave = PRG.TipoUnidad AND VADTipoLenguaje = 'EM') AS Unidad, SUM(PRG.Cantidad) AS Cantidad, SUM(PRD.Factor * PRG.Cantidad) AS CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY CLI.Clave, CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("ORDER BY CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad ");
                ClientesProductoPromoNoEntregadoEnAgenda = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT CLI.Clave + ' - ' + CLI.NombreCorto AS Cliente, PRO.Nombre AS Producto, (SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VarCodigo = 'UNIDADV' AND VAVClave = PRG.TipoUnidad AND VADTipoLenguaje = 'EM') AS Unidad, SUM(PRG.Cantidad) AS Cantidad, SUM(PRD.Factor * PRG.Cantidad) AS CantidadUnitaria, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRG.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave AND VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY CLI.Clave, CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad, AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("ORDER BY CLI.NombreCorto, PRO.Nombre, PRG.TipoUnidad ");
                ClienteProductoPromoNoEntregadoFA = sConsulta.ToString();

                sConsulta = new StringBuilder();

                List<QP> qp = Connection.Query<QP>(queryPrincipal, null, null, true, 600).ToList();
                List<TiemposDet> time = Connection.Query<TiemposDet>(Tiempos, null, null, true, 600).ToList();
                List<TotalClientes> totalclientes = Connection.Query<TotalClientes>(TotalClientes, null, null, true, 600).ToList();
                List<TotalClientes> totalVisitadosEncuestar = Connection.Query<TotalClientes>(TotalVisitadosEncuestar, null, null, true, 600).ToList();
                List<TotalClientes> totalProductosPromocional = Connection.Query<TotalClientes>(TotalProductosPromocional, null, null, true, 600).ToList();
                List<TotalClientes> totalProductosPromocionalFA = Connection.Query<TotalClientes>(TotalProductoPromocionalFA, null, null, true, 600).ToList();

                List<ClientesNoVisitados> clientesNoVisitados = Connection.Query<ClientesNoVisitados>(ClientesNoVisitados, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesVisitados = Connection.Query<ClientesNoVisitados>(ClientesVisitados, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesVisitadosFA = Connection.Query<ClientesNoVisitados>(ClientesVisitadosFA, null, null, true, 600).ToList();
                List<ClientesNoVisitados> totalVisitados = Connection.Query<ClientesNoVisitados>(TotalVisitados, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesVisitadosConVenta = Connection.Query<ClientesNoVisitados>(ClientesVisitadosConVenta, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesVisitadosConVentaFA = Connection.Query<ClientesNoVisitados>(ClientesVisitadosConVentaFA, null, null, true, 600).ToList();
                List<ClientesNoVisitados> totalVisitadosSinVenta = Connection.Query<ClientesNoVisitados>(TotalVisitadosSinVenta, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesEncuestados = Connection.Query<ClientesNoVisitados>(ClientesEncuestados, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesEncuestadosFA = Connection.Query<ClientesNoVisitados>(ClientesEncuestadosFA, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesNoEncuestados = Connection.Query<ClientesNoVisitados>(ClientesNoEncuestados, null, null, true, 600).ToList();
                List<ClientesNoVisitados> clientesNoEncuestadosFA = Connection.Query<ClientesNoVisitados>(ClientesNoEncuestadosFA, null, null, true, 600).ToList();
                List<ClientesNoVisitados> codigosLeidos = Connection.Query<ClientesNoVisitados>(CodigosLeidos, null, null, true, 600).ToList();
                List<ClientesNoVisitados> codigosLeidosFA = Connection.Query<ClientesNoVisitados>(CodigosLeidosFA, null, null, true, 600).ToList();
                List<ClientesNoVisitados> codigosNoLeidos = Connection.Query<ClientesNoVisitados>(CodigosNoLeidos, null, null, true, 600).ToList();
                List<ClientesNoVisitados> codigosNoLeidosFA = Connection.Query<ClientesNoVisitados>(CodigosNoLeidosFA, null, null, true, 600).ToList();
                List<ClientesNoVisitados> productoNegado = Connection.Query<ClientesNoVisitados>(ProductoNegado, null, null, true, 600).ToList();
                List<ClientesNoVisitados> productoNegadoFA = Connection.Query<ClientesNoVisitados>(ProductoNegadoFA, null, null, true, 600).ToList();

                List<ClientesVisitadosSinVenta> clientesVisitadosSinVenta = Connection.Query<ClientesVisitadosSinVenta>(ClientesVisitadosSinVenta, null, null, true, 600).ToList();
                List<ClientesVisitadosSinVenta> clientesVisitadosSinVentaFA = Connection.Query<ClientesVisitadosSinVenta>(ClientesVisitadosSinVentaFA, null, null, true, 600).ToList();

                List<ImproductividadVentaDet> improductividadVentaFA = Connection.Query<ImproductividadVentaDet>(ImproductividadVentaFA, null, null, true, 600).ToList();

                List<TotalEncuestas> totalEncuestas = Connection.Query<TotalEncuestas>(TotalEncuestas, null, null, true, 600).ToList();

                List<EncuestasAplicadas> encuestasAplicadas = Connection.Query<EncuestasAplicadas>(EncuestasAplicadas, null, null, true, 600).ToList();
                List<EncuestasAplicadas> encuestasAplicadasFA = Connection.Query<EncuestasAplicadas>(EncuestasAplicadasFA, null, null, true, 600).ToList();

                List<EncuestasAplicadas> encuestasNoAplicadas = Connection.Query<EncuestasAplicadas>(EncuestasNoAplicadas, null, null, true, 600).ToList();
                List<EncuestasAplicadas> encuestasNoAplicadasFA = Connection.Query<EncuestasAplicadas>(EncuestasNoAplicadasFA, null, null, true, 600).ToList();

                List<ImproductividadProductoDet> improductividadProducto = Connection.Query<ImproductividadProductoDet>(ImproductividadProducto, null, null, true, 600).ToList();
                List<ImproductividadProductoDet> improductividadProductoFA = Connection.Query<ImproductividadProductoDet>(ImproductividadProductoFA, null, null, true, 600).ToList();

                List<MotivosImproductividad> motivosImproductividad = Connection.Query<MotivosImproductividad>(MotivosImproductividad, null, null, true, 600).ToList();
                List<MotivosImproductividad> motivosImproductividadFA = Connection.Query<MotivosImproductividad>(MotivosImproductividadFA, null, null, true, 600).ToList();

                List<ProductoPromoNoEntregadoDet> productoPromoNoEntregado = Connection.Query<ProductoPromoNoEntregadoDet>(ProductoPromoNoEntregado, null, null, true, 600).ToList();
                List<ProductoPromoNoEntregadoDet> productoPromoNoEntregadoFA = Connection.Query<ProductoPromoNoEntregadoDet>(ProductoPromoNoEntregadoFA, null, null, true, 600).ToList();

                List<ClientesProductoNegadoDet> clientesProductoNegado = Connection.Query<ClientesProductoNegadoDet>(ClientesProductoNegado, null, null, true, 600).ToList();
                List<ClientesProductoNegadoDet> clientesProductoNegadoFA = Connection.Query<ClientesProductoNegadoDet>(ClientesProductoNegadoFA, null, null, true, 600).ToList();

                List<ClientesImproductividadProducto> clientesImproductividadProducto = Connection.Query<ClientesImproductividadProducto>(ClientesImproductividadProducto, null, null, true, 600).ToList();
                List<ClientesImproductividadProducto> clientesImproductividadProductoFA = Connection.Query<ClientesImproductividadProducto>(ClientesImproductividadProductoFA, null, null, true, 600).ToList();

                List<ClienteProductoPromoNoEntregado> clienteProductoPromoNoEntregado = Connection.Query<ClienteProductoPromoNoEntregado>(ClientesProductoPromoNoEntregadoEnAgenda, null, null, true, 600).ToList();
                List<ClienteProductoPromoNoEntregado> clienteProductoPromoNoEntregadoFA = Connection.Query<ClienteProductoPromoNoEntregado>(ClienteProductoPromoNoEntregadoFA, null, null, true, 600).ToList();

                var data = from quP in qp
                           join tiempo in time
                           on quP.AlmacenId equals tiempo.AlmacenId
                           join tC in totalclientes
                           on tiempo.RUTClave equals tC.RUTClave
                           join cNV in clientesNoVisitados
                           on tC.ClaveCEDI equals cNV.ClaveCEDI
                           join cV in clientesVisitados
                           on cNV.ClaveCEDI equals cV.ClaveCEDI
                           from cVFA in clientesVisitadosFA
                           .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           .DefaultIfEmpty()
                           join tV in totalVisitados
                           on quP.RUTClave equals tV.RUTClave
                           join cVCV in clientesVisitadosConVenta
                           on quP.RUTClave equals cVCV.RUTClave
                           //from cVVFA in clientesVisitadosConVentaFA
                           // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           // .DefaultIfEmpty()
                           join cVSV in clientesVisitadosSinVenta
                           on quP.RUTClave equals cVSV.RUTClave
                           //from cVSVFA in clientesVisitadosSinVentaFA
                           // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           // .DefaultIfEmpty()
                           //join tVsV in totalVisitadosSinVenta
                           //on quP.RUTClave equals tVsV.RUTClave
                           //from iV in improductividadVentas
                           // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           // .DefaultIfEmpty()
                           //from iVFA in improductividadVentaFA
                           //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           //.DefaultIfEmpty()
                           //from tE in totalEncuestas
                           // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           // .DefaultIfEmpty()
                           //from eA in encuestasAplicadas
                           //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           //.DefaultIfEmpty()
                           //from eAFA in encuestasAplicadasFA
                           // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           // .DefaultIfEmpty()
                           from eNA in encuestasNoAplicadas
                           .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                           .DefaultIfEmpty()
                               //from eNAFA in encuestasNoAplicadasFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from tVE in totalVisitadosEncuestar
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from cE in clientesEncuestados
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from cEFA in clientesEncuestadosFA
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from cNE in clientesNoEncuestados
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from cNEFA in clientesNoEncuestadosFA
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from cL in codigosLeidos
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from cLFA in codigosLeidosFA
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //join cNL in codigosNoLeidos
                               //on quP.RUTClave equals cNL.RUTClave
                               //from cNLFA in codigosNoLeidosFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from pN in productoNegado
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from pNFA in productoNegadoFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from iP in improductividadProducto
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from iPFA in improductividadProductoFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from mI in motivosImproductividad
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from mIFA in motivosImproductividadFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from pPNE in productoPromoNoEntregado
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from pPNEFA in productoPromoNoEntregadoFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from tPP in totalProductosPromocional
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from tPPFA in totalProductosPromocionalFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from cPN in clientesProductoNegado
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from cPNFA in clientesProductoNegadoFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from cIP in clientesImproductividadProducto
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from cIPFA in clientesImproductividadProductoFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                               //from cPPNEA in clienteProductoPromoNoEntregado
                               //.Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               //.DefaultIfEmpty()
                               //from cPPNEFA in clienteProductoPromoNoEntregadoFA
                               // .Where(a => a.RUTClave.Equals(cV.RUTClave) && a.ClaveCEDI.Equals(cV.ClaveCEDI) && a.DiaClave.Equals(cV.VendedorId))
                               // .DefaultIfEmpty()
                           where
                           quP.RUTClave == tiempo.RUTClave
                           && quP.DiaClave == tiempo.DiaClave
                           && quP.AlmacenId == tiempo.AlmacenId
                           && quP.VendedorId == tiempo.VendedorId
                           && quP.RUTClave == tC.RUTClave
                           && quP.DiaClave == tC.DiaClave
                           && quP.VendedorId == tC.VendedorId
                           && quP.RUTClave == cNV.RUTClave
                           && quP.DiaClave == cNV.DiaClave
                           && quP.VendedorId == cNV.VendedorId
                           && quP.RUTClave == cV.RUTClave
                           && quP.DiaClave == cV.DiaClave
                           && quP.VendedorId == cV.VendedorId
                           && quP.RUTClave == tV.RUTClave
                           && quP.DiaClave == tV.DiaClave
                           && quP.VendedorId == tV.VendedorId
                           && quP.RUTClave == cVCV.RUTClave
                           && quP.DiaClave == cVCV.DiaClave
                           && quP.VendedorId == cVCV.VendedorId
                           && quP.RUTClave == cVSV.RUTClave
                           && quP.DiaClave == cVSV.DiaClave
                           && quP.VendedorId == cVSV.VendedorId
                           select new
                           {
                               RUTClave = quP.RUTClave,
                               Almacen = quP.Almacen,
                               AlmacenId = quP.AlmacenId,
                               DiaClave = quP.DiaClave,
                               Ruta = quP.Ruta,
                               Vendedor = quP.Vendedor,
                               VendedorId = quP.VendedorId,
                               FechaCaptura = quP.FechaCaptura,
                               HoraFinal = tiempo.HoraFinal,
                               HoraInicial = tiempo.HoraInicial,
                               TiempoRecorrido = CalcularTiempo(tiempo.TiempoRecorrido),
                               TiempoVisita = CalcularTiempo(tiempo.TiempoVisita),
                               TiempoTransito = CalcularTiempo(tiempo.TiempoRecorrido - tiempo.TiempoVisita),
                               TotalClienteCNV = tC.TotalCliente,
                               ClienteClaveCNV = cNV.ClienteClave,
                               NombreCNV = cNV.Nombre,
                               ClienteClaveCV = cV.ClienteClave,
                               NombreCV = cV.Nombre,
                               ClienteClaveCVFA = cVFA != null ? cVFA.ClienteClave : "",
                               NombreCVFA = cVFA != null ? cVFA.Nombre : "",
                               //NombreCVV = cVCV.Nombre, 
                               //ClienteClaveCVV = cVCV.ClienteClave, 
                               //NombreTV = tV.Nombre, 
                               //ClienteClaveTV = tV.ClienteClave, 
                               //NombreCVVFA = cVVFA.Nombre, 
                               //ClienteClaveCVVFA = cVVFA.ClienteClave, 
                               //NombreCVCV = cVSV.Nombre, 
                               //ClienteClaveCVSV = cVSV.ClienteClave, 
                               //NombreCVSVFA = cVSVFA.Nombre, 
                               //ClienteClaveCVSVFA = cVSVFA.ClienteClave, 
                               //NombreTVSV = tVsV.Nombre, 
                               //ClienteClaveTVSV = tVsV.ClienteClave, 
                               //NombreIV = iV!= null ? iV.Nombre : "", 
                               //ClienteClaveIV = iV!= null ?iV.ClienteClave:"", 
                               //NombreIVFA = iVFA.Nombre, 
                               //ClienteClaveIVFA = iVFA.ClienteClave, 
                               //TotalEncuestaTE = tE.TotalEncuesta, 
                               //TotalAplicadasEnAgendaEA = eA.TotalAplicadasEnAgenda, 
                               //TotalAplicadasFueraAgendaEA = eA.TotalAplicadasFueraAgenda, 
                               //TotalEncuestasEA = eA.TotalEncuestas, 
                               //TotalEncuestasEnAgendaEA = eA.TotalEncuestasEnAgenda, 
                               //TotalEncuestasFueraAgendaEA = eA.TotalEncuestasFueraAgenda, 
                               //TotalAplicadasEnAgendaEAFA = eAFA.TotalAplicadasEnAgenda, 
                               //TotalAplicadasFueraAgendaEAFA = eAFA.TotalAplicadasFueraAgenda, 
                               //TotalEncuestasEAFA = eAFA.TotalEncuestas, 
                               //TotalEncuestasEnAgendaEAFA = eAFA.TotalEncuestasEnAgenda, 
                               //TotalEncuestasFueraAgendaEAFA = eAFA.TotalEncuestasFueraAgenda, 
                               TotalAplicadasEnAgendaENA = eNA != null ? eNA.TotalAplicadasEnAgenda : 0,
                               TotalAplicadasFueraAgendaENA = eNA != null ? eNA.TotalAplicadasFueraAgenda : 0,
                               TotalEncuestasENA = eNA != null ? eNA.TotalEncuestas : 0,
                               TotalEncuestasEnAgendaENA = eNA != null ? eNA.TotalEncuestasEnAgenda : 0,
                               TotalEncuestasFueraAgendaENA = eNA != null ? eNA.TotalEncuestasFueraAgenda : 0,
                               //TotalAplicadasEnAgendaENAFA = eNAFA.TotalAplicadasEnAgenda, 
                               //TotalAplicadasFueraAgendaENAFA = eNAFA.TotalAplicadasFueraAgenda, 
                               //TotalEncuestasENAFA = eNAFA.TotalEncuestas, 
                               //TotalEncuestasEnAgendaENAFA = eNAFA.TotalEncuestasEnAgenda, 
                               //TotalEncuestasFueraAgendaENAFA = eNAFA.TotalEncuestasFueraAgenda, 
                               //TotalClienteTVE = tVE.TotalCliente, 
                               //NombreCE = cE.Nombre, 
                               //ClienteClaveCE = cE.ClienteClave, 
                               //NombreCEFA = cEFA.Nombre, 
                               //ClienteClaveCEFA = cEFA.ClienteClave, 
                               //NombreCNE = cNE.Nombre, 
                               //ClienteClaveCNE = cNE.ClienteClave, 
                               //NombreCNEFA = cNEFA.Nombre, 
                               //ClienteClaveCNEFA = cNEFA.ClienteClave, 
                               //NombreCL = cL.Nombre, 
                               //ClienteClaveCL = cL.ClienteClave, 
                               //NombreCLFA = cLFA.Nombre, 
                               //ClienteClaveCLFA = cLFA.ClienteClave, 
                               //NombreCNL = cNL.Nombre, 
                               //ClienteClaveCNL = cNL.ClienteClave, 
                               //NombreCNLFA = cNLFA.Nombre, 
                               //ClienteClaveCNLFA = cNLFA.ClienteClave, 
                               //NombrePN = pN.Nombre, 
                               //ClienteClavePN = pN.ClienteClave, 
                               //NombrePNFA = pNFA.Nombre, 
                               //ClienteClavePNFA = pNFA.ClienteClave, 
                               //NombreIP = iP.Nombre, 
                               //MotivoIP = iP.Motivo, 
                               //CantidadIP = iP.Cantidad, 
                               //NombreIPFA = iPFA.Nombre, 
                               //MotivoIPFA = iPFA.Motivo, 
                               //CantidadIPFA = iPFA.Cantidad, 
                               //MotivoMI = mI.Motivo, 
                               //CantidadMI = mI.Cantidad, 
                               //MotivoMIFA = mIFA.Motivo, 
                               //CantidadMIFA = mIFA.Cantidad, 
                               //NombrePPNE = pPNE.Nombre, 
                               //CantidadPPNE = pPNE.Cantidad, 
                               //NombrePPNEFA = pPNEFA.Nombre, 
                               //CantidadPPNEFA = pPNEFA.Cantidad, 
                               //TotalClienteTPP = tPP.TotalCliente, 
                               //TotalClienteTPPFA = tPPFA.TotalCliente, 
                               //ClienteCPN = cPN.Cliente, 
                               //ProductoCPN = cPN.Producto, 
                               //CantidadCPN = cPN.Cantidad, 
                               //CantidadUnitariaCPN = cPN.CantidadUnitaria, 
                               //UnidadCPN = cPN.Unidad, 
                               //ClienteCPNFA = cPNFA.Cliente, 
                               //ProductoCPNFA = cPNFA.Producto, 
                               //CantidadCPNFA = cPNFA.Cantidad, 
                               //CantidadUnitariaCPNFA = cPNFA.CantidadUnitaria, 
                               //UnidadCPNFA = cPNFA.Unidad, 
                               //ClienteCIP = cIP.Cliente, 
                               //CantidadCIP = cIP.Cantidad, 
                               //ProductoCIP = cIP.Producto, 
                               //ClienteCIPFA = cIPFA.Cliente, 
                               //CantidadCIPFA = cIPFA.Cantidad, 
                               //ProductoCIPFA = cIPFA.Producto, 
                               //ClienteCPPNEA = cPPNEA.Cliente, 
                               //CantidadCPPNEA = cPPNEA.Cantidad, 
                               //CantidadUnitariaCPPNEA = cPPNEA.CantidadUnitaria, 
                               //ProductoCPPNEA = cPPNEA.Producto, 
                               //UnidadCPPNEA = cPPNEA.Unidad, 
                               //ClienteCPPNEFA = cPPNEFA.Cliente, 
                               //CantidadCPPNEFA = cPPNEFA.Cantidad, 
                               //CantidadUnitariaCPPNEFA = cPPNEFA.CantidadUnitaria, 
                               //ProductoCPPNEFA = cPPNEFA.Producto, 
                               //UnidadCPPNEFA = cPPNEFA.Unidad
                           };

                int contClientesNoVisitados = 0;
                foreach (var a in clientesNoVisitados)
                {
                    contClientesNoVisitados++;
                }

                int contClientesVisitados = 0;
                foreach (var a in clientesVisitados)
                {
                    contClientesVisitados++;
                }

                float contTotalClientesParaVisitar = contClientesVisitados + contClientesNoVisitados;

                float porcentClientesVisitados = (contClientesVisitados) / contTotalClientesParaVisitar;
                float porcentClientesNoVisitados = (contClientesNoVisitados) / contTotalClientesParaVisitar;

                int contClientesVisitadosConVenta = 0;
                foreach (var a in clientesVisitadosConVenta)
                {
                    contClientesVisitadosConVenta++;
                }

                int contClientesVisitadosSinVenta = 0;
                foreach (var a in clientesVisitadosSinVenta)
                {
                    contClientesVisitadosSinVenta++;
                }

                float contTotalClientesConSinVenta = contClientesVisitadosConVenta + contClientesVisitadosSinVenta;

                float porcentClientesVisitadosConVenta = (contClientesVisitadosConVenta) / contTotalClientesConSinVenta;
                float porcentClientesVisitadosSinVenta = (contClientesVisitadosSinVenta) / contTotalClientesConSinVenta;

                int contImproductividadVenta = 0;
                foreach (var a in ImproductividadVentas)
                {
                    contImproductividadVenta++;
                }

                int contEncuestasAplicadas = 0;
                foreach (var a in encuestasAplicadas)
                {
                    contEncuestasAplicadas++;
                }

                int contClientesEncuestados = 0;
                foreach (var a in clientesEncuestados)
                {
                    contClientesEncuestados++;
                }

                int contClientesNoEncuestados = 0;
                foreach (var a in clientesNoEncuestados)
                {
                    contClientesNoEncuestados++;
                }

                int contCodigosBarrasLeidos = 0;
                foreach (var a in codigosLeidos)
                {
                    contCodigosBarrasLeidos++;
                }

                int contCodigosBarrasNoLeidos = 0;
                foreach (var a in codigosNoLeidos)
                {
                    contCodigosBarrasNoLeidos++;
                }

                int contProductoNoEntregado = 0;
                foreach (var a in productoNegado)
                {
                    contProductoNoEntregado++;
                }

                int contImproductividadProducto = 0;
                foreach (var a in improductividadProducto)
                {
                    contImproductividadProducto++;
                }

                int contMotivosImproductividad = 0;
                foreach (var a in motivosImproductividad)
                {
                    contMotivosImproductividad++;
                }

                int contProductoPromoNoEntregado = 0;
                foreach (var a in productoPromoNoEntregado)
                {
                    contProductoPromoNoEntregado++;
                }

                int contClientesProductoNegado = 0;
                int contTotalClienteProductoNegado = 0;
                foreach (var a in clientesProductoNegado)
                {
                    contTotalClienteProductoNegado += a.Cantidad;
                    contClientesProductoNegado++;
                }

                int contClientesImproductividadProducto = 0;
                int contTotalClientesImproductividadProducto = 0;
                foreach (var a in clientesImproductividadProducto)
                {
                    contTotalClientesImproductividadProducto += a.Cantidad;
                    contClientesImproductividadProducto++;
                }

                int contClientesProductoPromoNoEntregado = 0;
                int contTotalClientesProductoPromoNoEntregado = 0;
                foreach (var a in clienteProductoPromoNoEntregado)
                {
                    contTotalClientesProductoPromoNoEntregado += a.Cantidad;
                    contClientesProductoPromoNoEntregado++;
                }

                report.DataSource = data;
                efectividadPorRutaSubDetallado1 sub1 = new efectividadPorRutaSubDetallado1();
                efectividadPorRutaSubDetallado2 sub2 = new efectividadPorRutaSubDetallado2();
                efectividadPorRutaSubDetallado3 sub3 = new efectividadPorRutaSubDetallado3();
                efectividadPorRutaSubDetallado4 sub4 = new efectividadPorRutaSubDetallado4();
                efectividadPorRutaSubDetallado5 sub5 = new efectividadPorRutaSubDetallado5();
                efectividadPorRutaSubDetallado6 sub6 = new efectividadPorRutaSubDetallado6();
                efectividadPorRutaSubDetallado7 sub7 = new efectividadPorRutaSubDetallado7();
                efectividadPorRutaSubDetallado8 sub8 = new efectividadPorRutaSubDetallado8();
                efectividadPorRutaSubDetallado9 sub9 = new efectividadPorRutaSubDetallado9();
                efectividadPorRutaSubDetallado10 sub10 = new efectividadPorRutaSubDetallado10();
                efectividadPorRutaSubDetallado11 sub11 = new efectividadPorRutaSubDetallado11();
                efectividadPorRutaSubDetallado12 sub12 = new efectividadPorRutaSubDetallado12();
                efectividadPorRutaSubDetallado13 sub13 = new efectividadPorRutaSubDetallado13();
                efectividadPorRutaSubDetallado14 sub14 = new efectividadPorRutaSubDetallado14();
                efectividadPorRutaSubDetallado15 sub15 = new efectividadPorRutaSubDetallado15();
                efectividadPorRutaSubDetallado16 sub16 = new efectividadPorRutaSubDetallado16();
                efectividadPorRutaSubDetallado17 sub17 = new efectividadPorRutaSubDetallado17();

                sub1.DataSource = clientesNoVisitados;
                sub2.DataSource = clientesVisitados;
                sub3.DataSource = clientesVisitadosConVenta;
                sub4.DataSource = clientesVisitadosSinVenta;
                sub5.DataSource = ImproductividadVentas;
                sub6.DataSource = encuestasNoAplicadas;
                sub7.DataSource = clientesEncuestados;
                sub8.DataSource = clientesNoEncuestados;
                sub9.DataSource = codigosLeidos;
                sub10.DataSource = codigosNoLeidos;
                sub11.DataSource = productoNegado;
                sub12.DataSource = improductividadProducto;
                sub13.DataSource = motivosImproductividad;
                sub14.DataSource = productoPromoNoEntregado;
                sub15.DataSource = clientesProductoNegado;
                sub16.DataSource = clientesImproductividadProducto;
                sub17.DataSource = clienteProductoPromoNoEntregado;

                report.lbCEDIS.DataBindings.Add("Text", null, "Almacen");
                report.lbFecha.DataBindings.Add("Text", null, "DiaClave");
                report.lbRuta.DataBindings.Add("Text", null, "Ruta");
                report.lbVendedor.DataBindings.Add("Text", null, "Vendedor");

                report.tiempoRecorrido.DataBindings.Add("Text", null, "TiempoRecorrido");
                report.tiempoVisita.DataBindings.Add("Text", null, "TiempoVisita");
                report.tiempoTransito.DataBindings.Add("Text", null, "TiempoTransito");

                sub1.lb2ClientesNoVisitados.DataBindings.Add("Text", null, "Nombre");
                sub1.lb2TotalClientesNoVisitados.Text = contClientesNoVisitados.ToString();
                sub1.lb2TotalClientesNoVisitadosPorcent.Text = porcentClientesNoVisitados.ToString("#0.00%");

                report.sub1.ReportSource = sub1;
                report.sub2.ReportSource = sub2;
                report.sub3.ReportSource = sub3;
                report.sub4.ReportSource = sub4;
                report.sub5.ReportSource = sub5;
                report.sub6.ReportSource = sub6;
                report.sub7.ReportSource = sub7;
                report.sub8.ReportSource = sub8;
                report.sub9.ReportSource = sub9;
                report.sub10.ReportSource = sub10;
                report.sub11.ReportSource = sub11;
                report.sub12.ReportSource = sub12;
                report.sub13.ReportSource = sub13;
                report.sub14.ReportSource = sub14;
                report.sub15.ReportSource = sub15;
                report.sub16.ReportSource = sub16;
                report.sub17.ReportSource = sub17;

                sub2.lb2ClientesVisitados.DataBindings.Add("Text", null, "Nombre");
                sub2.lb2TotalClientesVisitados.Text = contClientesVisitados.ToString();
                sub2.lb2TotalClientesVisitadosPorcent.Text = porcentClientesVisitados.ToString("#0.00%");

                sub3.lb2ClientesVisitadosConVenta.DataBindings.Add("Text", null, "Nombre");
                sub3.lb2TotalClientesVisitadosConVenta.Text = contClientesVisitadosConVenta.ToString();
                sub3.lb2TotalClientesVisitadosConVentaPorcent.Text = porcentClientesVisitadosConVenta.ToString("#0.00%");

                sub4.lb2ClientesVisitadosSinVenta.DataBindings.Add("Text", null, "Nombre");
                sub4.lb2TotalClientesVisitadosSinVenta.Text = contClientesVisitadosSinVenta.ToString();
                sub4.lb2TotalClientesVisitadosSinVentaPorcent.Text = porcentClientesVisitadosSinVenta.ToString("#0.00%");

                sub5.lb2ImproductividadVenta.DataBindings.Add("Text", null, "Nombre");
                sub5.lb2TotalImproductividadVenta.Text = contImproductividadVenta.ToString();

                sub6.lb2EncuestasAplicadas.DataBindings.Add("Text", null, "TotalAplicadasEnAgenda");
                sub6.lb2TotalEncuestasAplicadas.Text = contEncuestasAplicadas.ToString();

                sub7.lb2ClientesEncuestados.DataBindings.Add("Text", null, "Nombre");
                sub7.lb2TotalClientesEncuestados.Text = contClientesEncuestados.ToString();

                sub8.lb2ClientesNoEncuestados.DataBindings.Add("Text", null, "Nombre");
                sub8.lb2TotalClientesNoEncuestados.Text = contClientesNoEncuestados.ToString();

                sub9.lb2CodigoBarrasLeidos.DataBindings.Add("Text", null, "Nombre");
                sub9.lb2TotalClientesCodigosBarrasLeidos.Text = contCodigosBarrasLeidos.ToString();

                sub10.lb2CodigoBarrasNoLeidos.DataBindings.Add("Text", null, "Nombre");
                sub10.lb2TotalClientesCodigosBarrasNoLeidos.Text = contCodigosBarrasNoLeidos.ToString();

                sub11.lb2ProductosNoEntregados.DataBindings.Add("Text", null, "Nombre");
                sub11.lb2TotalProductoNoEntregado.Text = contProductoNoEntregado.ToString();

                sub12.lb2ImproductividadProducto.DataBindings.Add("Text", null, "Nombre");
                sub12.lb2TotalImproductividadProducto.Text = contImproductividadProducto.ToString();

                sub13.lb2MotivosImproductividad.DataBindings.Add("Text", null, "Motivo");
                sub13.lb2TotalMotivosImproductividad.Text = contMotivosImproductividad.ToString();

                sub14.lb2ProductoPromocionalNoEntregado.DataBindings.Add("Text", null, "Nombre");
                sub14.lb2TotalProductoPromocionalNoEntregado.Text = contProductoPromoNoEntregado.ToString();

                sub15.lb2ClientesConProductoNegado.DataBindings.Add("Text", null, "Cliente");
                sub15.lb2TotalClientesProductoNegado.Text = contClientesProductoNegado.ToString();
                sub15.lb2TotalProductoNegado.Text = contTotalClienteProductoNegado.ToString();

                sub16.lb2ClientesConImproductividadProducto.DataBindings.Add("Text", null, "Cliente");
                sub16.lb2TotalImproductividadProducto.Text = contImproductividadProducto.ToString();
                sub16.lb2TotalClientesConImproductividadProducto.Text = contTotalClientesImproductividadProducto.ToString();

                sub17.lb2ClientesConProductoPromocionNoEntregado.DataBindings.Add("Text", null, "Cliente");
                sub17.lb2TotalClientesProductoPromocionalNoEntregado.Text = contClientesProductoPromoNoEntregado.ToString();
                sub17.lb2TotalProductoPromocionalNoEntregado.Text = contTotalClientesProductoPromoNoEntregado.ToString();

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte + " Detallado";

                #endregion
                return report;
            }
            else
            {
                #region reporte general
                string Datos, Tiempos, ClientesVisitados, ClientesVisitadosConVenta, ImproductividadVenta, EncuestasAplicadas, ClientesEncuestados, CodigosLeidos, ProductoNegado, ProductoPromoNoEntregado, ClientesProductoNegado, ClientesProductoPromoNoEntregado;

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, DATEDIFF(second, MIN(VIS.FechaHoraInicial), MAX(VIS.FechaHoraFinal)) AS TiempoRecorrido, SUM(DATEDIFF(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) AS TiempoVisita ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorId AND VIS.RUTClave = AGV.RUTClave AND Vis.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ");
                Datos = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT DISTINCT ALN.Clave + ' ' + ALN.Nombre AS Almacen, DIA.FechaCaptura, VEN.Nombre AS Vendedor, RUT.Rutclave + ' ' + RUT.Descripcion AS Ruta, ALN.Clave AS ClaveCEDI, Dia.DiaClave, VEN.VendedorId, RUT.RUTClave ");
                sConsulta.AppendLine("FROM (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");// AND ALN.Clave = 'MX00' AND RUT.RUTClave = '006' AND Dia.FechaCaptura between '01/01/2018' AND '01/03/2018' ");
                sConsulta.AppendLine(pvCondicion);
                Tiempos = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RutClave, SUM(TotalClientes) AS TotalClientes, SUM(EnAgendaVisitados) AS EnAgendaVisitados, SUM(FueraAgendaVisitados) AS FueraAgendaVisitados ");
                sConsulta.AppendLine("FROM (SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalClientes, EnAgendaVisitados = 0, FueraAgendaVisitados = 0 FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion + " AND AGV.ClienteClave NOT IN ( SELECT ClienteClave FROM Visita VIS (NOLOCK) WHERE VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorId AND VIS.RUTClave = AGV.RUTClave) ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RutClave, TotalClientes = 0, SUM(EnAgendaVisitados) AS EnAgendaVisitados, SUM(FueraAgendaVisitados) AS FueraAgendaVisitados ");
                sConsulta.AppendLine("FROM (SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, (SELECT COUNT(DISTINCT VIS.ClienteClave) FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("WHERE (AGV.ClienteClave = VIS.ClienteClave AND AGV.DiaClave = VIS.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RutClave = VIS.RutClave) ");
                sConsulta.AppendLine(") AS EnAgendaVisitados, ");
                sConsulta.AppendLine("(SELECT COUNT(DISTINCT VIS.ClienteClave) FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("WHERE (AGV.ClienteClave = VIS.ClienteClave AND AGV.DiaClave = VIS.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RutClave = VIS.RutClave) ");
                sConsulta.AppendLine(") AS FueraAgendaVisitados ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RutClave, AGV.ClienteClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RutClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RutClave ");
                ClientesVisitados = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, SUM(ClientesVisitados) AS ClientesVisitados, ");
                sConsulta.AppendLine("SUM(ClientesVisitadosEnAgenda) AS ClientesVisitadosEnAgenda, SUM(ClientesConVentaEnAgenda) AS ClientesConVentaEnAgenda, ");
                sConsulta.AppendLine("SUM(ClientesSinVentaEnAgenda) AS ClientesSinVentaEnAgenda, SUM(ClientesVisitadosFueraAgenda) AS ClientesVisitadosFueraAgenda, ");
                sConsulta.AppendLine("SUM(ClientesConVentaFueraAgenda) AS ClientesConVentaFueraAgenda, SUM(ClientesSinVentaFueraAgenda) AS ClientesSinVentaFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CLI.ClienteClave), 0) AS ClientesVisitados, ");
                sConsulta.AppendLine("ClientesVisitadosEnAgenda = 0, ClientesConVentaEnAgenda = 0, ClientesSinVentaEnAgenda = 0, ClientesVisitadosFueraAgenda = 0, ClientesConVentaFueraAgenda = 0, ClientesSinVentaFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesVisitados = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CLI.ClienteClave), 0) AS ClientesVisitadosEnAgenda, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN TRP.VisitaClave IS NULL THEN NULL ELSE VIS.ClienteClave END)), 0) AS ClientesConVentaEnAgenda, ");
                sConsulta.AppendLine("ClientesSinVentaEnAgenda = 0, ClientesVisitadosFueraAgenda = 0, ClientesConVentaFueraAgenda = 0, ClientesSinVentaFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ClientesVisitados = 0, ClientesVisitadosEnAgenda = 0, ClientesConVentaEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CLI.ClienteClave), 0) AS ClientesSinVentaEnAgenda, ");
                sConsulta.AppendLine("ClientesVisitadosFueraAgenda = 0, ClientesConVentaFueraAgenda = 0, ClientesSinVentaFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" AND NOT VIS.VisitaClave IN (SELECT VIS1.VisitaClave FROM Visita VIS1 (NOLOCK) INNER JOIN TransProd TRP (NOLOCK) ON VIS1.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("AND NOT VIS.ClienteClave IN (SELECT DISTINCT(VIS1.ClienteClave) FROM Visita VIS1 (NOLOCK) INNER JOIN TransProd TRP (NOLOCK) ON VIS1.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ClientesVisitados = 0, ClientesVisitadosEnAgenda = 0, ClientesConVentaEnAgenda = 0, ClientesSinVentaEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CLI.ClienteClave), 0) AS ClientesVisitadosFueraAgenda, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN TRP.VisitaClave IS NULL THEN NULL ELSE VIS.ClienteClave END)), 0) AS ClientesConVentaFueraAgenda, ");
                sConsulta.AppendLine("ClientesSinVentaFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ClientesVisitados = 0, ClientesVisitadosEnAgenda = 0, ClientesConVentaEnAgenda = 0, ClientesSinVentaEnAgenda = 0, ClientesVisitadosFueraAgenda = 0, ClientesConVentaFueraAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CLI.ClienteClave), 0) AS ClientesSinVentaFueraAgenda ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" AND NOT VIS.VisitaClave IN (SELECT VIS1.VisitaClave FROM Visita VIS1 (NOLOCK) INNER JOIN TransProd TRP (NOLOCK) ON VIS1.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("AND NOT VIS.ClienteClave IN (SELECT DISTINCT(VIS1.ClienteClave) FROM Visita VIS1 (NOLOCK) INNER JOIN TransProd TRP (NOLOCK) ON VIS1.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                ClientesVisitadosConVenta = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, SUM(ClientesNoVenta) AS ClientesNoVenta, ");
                sConsulta.AppendLine("SUM(ClientesImproductivoEnAgenda) AS ClientesImproductivoEnAgenda, SUM(ClientesImproductivoFueraAgenda) AS ClientesImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS ClientesNoVenta, ");
                sConsulta.AppendLine("ClientesImproductivoEnAgenda = 0, ClientesImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine("AND NOT VIS.VisitaClave IN (SELECT VIS1.VisitaClave FROM Visita VIS1 (NOLOCK) INNER JOIN TransProd TRP (NOLOCK) ON VIS1.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0) ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesNoVenta = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN (TRP.VisitaClave IS NULL AND NOT IMV.VisitaClave IS NULL) THEN VIS.ClienteClave else null END)), 0) AS ClientesImproductivoEnAgenda, ");
                sConsulta.AppendLine("ClientesImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND VIS.ClienteClave = AGV.ClienteClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("LEFT JOIN ImproductividadVenta IMV ON IMV.VisitaClave = VIS.VisitaClave AND IMV.DiaClave = VIS.DiaClave AND NOT VIS.VisitaClave IS NULL ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesNoVenta = 0, ClientesImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN (TRP.VisitaClave IS NULL AND NOT IMV.VisitaClave IS NULL) THEN VIS.ClienteClave else null END)), 0) AS ClientesImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND VIS.ClienteClave = AGV.ClienteClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("LEFT JOIN ImproductividadVenta IMV ON IMV.VisitaClave = VIS.VisitaClave AND IMV.DiaClave = VIS.DiaClave AND NOT VIS.VisitaClave IS NULL ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                ImproductividadVenta = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, SUM(TotalEncuestas) AS TotalEncuestas, ");
                sConsulta.AppendLine("SUM(TotalEncuestasEnAgenda) AS TotalEncuestasEnAgenda, SUM(TotalAplicadasEnAgenda) AS TotalAplicadasEnAgenda, ");
                sConsulta.AppendLine("SUM(TotalEncuestasFueraAgenda) AS TotalEncuestasFueraAgenda, SUM(TotalAplicadasFueraAgenda) AS TotalAplicadasFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CEC.CENClave), 0) AS TotalEncuestas, ");
                sConsulta.AppendLine("TotalEncuestasEnAgenda = 0, TotalEncuestasFueraAgenda = 0, TotalAplicadasEnAgenda = 0, TotalAplicadasFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON AGV.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.ClienteClave = CEC.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalEncuestas = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CEC.CENClave), 0) AS TotalEncuestasEnAgenda, TotalEncuestasFueraAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT ENC.CENClave), 0) AS TotalAplicadasEnAgenda, TotalAplicadasFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON AGV.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN (SELECT VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("GROUP BY VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ");
                sConsulta.AppendLine(") AS VIS ON CEC.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Encuesta ENC (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalEncuestas = 0, ");
                sConsulta.AppendLine("TotalEncuestasEnAgenda = 0, ISNULL(COUNT(DISTINCT CEC.CENClave), 0) AS TotalEncuestasFueraAgenda, ");
                sConsulta.AppendLine("TotalAplicadasEnAgenda = 0, ISNULL(COUNT(DISTINCT ENC.CENClave), 0) AS TotalAplicadasFueraAgenda ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON AGV.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN (SELECT VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("GROUP BY VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave ");
                sConsulta.AppendLine(") AS VIS ON CEC.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Encuesta ENC (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DIAClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                EncuestasAplicadas = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, SUM(TotalClientes) AS TotalClientes, ");
                sConsulta.AppendLine("SUM(TotalClientesEnAgenda) AS TotalClientesEnAgenda, SUM(TotalEncuestadosEnAgenda) AS TotalEncuestadosEnAgenda, ");
                sConsulta.AppendLine("SUM(TotalClientesFueraAgenda) AS TotalClientesFueraAgenda, SUM(TotalEncuestadosFueraAgenda) AS TotalEncuestadosFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CEC.ClienteClave), 0) AS TotalClientes, ");
                sConsulta.AppendLine("TotalClientesEnAgenda = 0, TotalEncuestadosEnAgenda = 0, TotalClientesFueraAgenda = 0, TotalEncuestadosFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON AGV.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CEC.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Encuesta ENC (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalClientes = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CEC.ClienteClave), 0) AS TotalClientesEnAgenda, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN ENC.ENCId IS NULL THEN NULL ELSE VIS.ClienteClave END)), 0) AS TotalEncuestadosEnAgenda, ");
                sConsulta.AppendLine("TotalClientesFueraAgenda = 0, TotalEncuestadosFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON AGV.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CEC.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Encuesta ENC (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave WHERE 1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalClientes = 0, ");
                sConsulta.AppendLine("TotalClientesEnAgenda = 0, TotalEncuestadosEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT CEC.ClienteClave), 0) AS TotalClientesFueraAgenda, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN ENC.ENCId IS NULL THEN NULL ELSE VIS.ClienteClave END)), 0) AS TotalEncuestadosFueraAgenda ");
                sConsulta.AppendLine("FROM CenCli CEC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON AGV.ClienteClave = CEC.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON CEC.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Encuesta ENC (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                ClientesEncuestados = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, SUM(ClientesVisitados) AS ClientesVisitados, ");
                sConsulta.AppendLine("SUM(ClientesVisitadosEnAgenda) AS ClientesVisitadosEnAgenda, SUM(ClientesLeidosEnAgenda) AS ClientesLeidosEnAgenda, ");
                sConsulta.AppendLine("SUM(ClientesVisitadosFueraAgenda) AS ClientesVisitadosFueraAgenda, SUM(ClientesLeidosFueraAgenda) AS ClientesLeidosFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT VIS.ClienteClave), 0) AS ClientesVisitados, ");
                sConsulta.AppendLine("ClientesVisitadosEnAgenda = 0, ClientesLeidosEnAgenda = 0, ClientesVisitadosFueraAgenda = 0, ClientesLeidosFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesVisitados = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT VIS.ClienteClave), 0) AS ClientesVisitadosEnAgenda, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN VIS.CodigoLeido = 1 THEN VIS.ClienteClave else null END)), 0) AS ClientesLeidosEnAgenda, ");
                sConsulta.AppendLine("ClientesVisitadosFueraAgenda = 0, ClientesLeidosFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ClientesVisitados = 0, ");
                sConsulta.AppendLine("ClientesVisitadosEnAgenda = 0, ClientesLeidosEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT VIS.ClienteClave), 0) AS ClientesVisitadosFueraAgenda, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN VIS.CodigoLeido = 1 THEN VIS.ClienteClave else null END)), 0) AS ClientesLeidosFueraAgenda ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                CodigosLeidos = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, SUM(TotalNegado) AS TotalNegado, SUM(TotalNegadoEnAgenda) AS TotalNegadoEnAgenda, ");
                sConsulta.AppendLine("SUM(TotalImproductivoEnAgenda) AS TotalImproductivoEnAgenda, SUM(TotalNegadoFueraAgenda) AS TotalNegadoFueraAgenda, ");
                sConsulta.AppendLine("SUM(TotalImproductivoFueraAgenda) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(SUM(PRD.Factor * PRG.Cantidad), 0) AS TotalNegado, TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRG.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, ");
                sConsulta.AppendLine("ISNULL(SUM(PRD.Factor * PRG.Cantidad), 0) AS TotalNegadoEnAgenda, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRG.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, TotalNegadoEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(SUM(IMR.Cantidad), 0) AS TotalImproductivoEnAgenda, TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(SUM(PRD.Factor * PRG.Cantidad), 0) AS TotalNegadoFueraAgenda, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRG.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, TotalNegadoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalImproductivoEnAgenda = 0, TotalNegadoFueraAgenda = 0, ISNULL(SUM(IMR.Cantidad), 0) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = VIS.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                ProductoNegado = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, SUM(TotalNegado) AS TotalNegado, SUM(TotalNegadoEnAgenda) AS TotalNegadoEnAgenda, ");
                sConsulta.AppendLine("SUM(TotalImproductivoEnAgenda) AS TotalImproductivoEnAgenda, SUM(TotalNegadoFueraAgenda) AS TotalNegadoFueraAgenda, ");
                sConsulta.AppendLine("SUM(TotalImproductivoFueraAgenda) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM( ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(SUM(PRD.Factor * PRG.Cantidad), 0) AS TotalNegado, TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRG.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, ");
                sConsulta.AppendLine("ISNULL(SUM(PRD.Factor * PRG.Cantidad), 0) AS TotalNegadoEnAgenda, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRG.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(SUM(PRD.Factor * PRG.Cantidad), 0) AS TotalNegadoFueraAgenda, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRG.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = PRG.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, ISNULL(SUM(PRD.Factor * TPD.Cantidad), 0) AS TotalImproductivoEnAgenda, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.tipo = 1 AND TRP.TipoFase <>0 ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdId = TPD.TransProdId AND TPD.Promocion = 2 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON TPD.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, TotalNegado = 0, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, ISNULL(SUM(PRD.Factor * TPD.Cantidad), 0) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.tipo = 1 AND TRP.TipoFase <>0 ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdId = TPD.TransProdId AND TPD.Promocion = 2 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON TPD.ProductoClave = PRD.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                ProductoPromoNoEntregado = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("IF (SELECT object_id('tempdb..#Tmp1')) IS NOT NULL DROP TABLE #Tmp1 ");
                sConsulta.AppendLine("SELECT * INTO #Tmp1 FROM ( ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, VIS.FechaHoraInicial ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ) AS Resultado ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, ");
                sConsulta.AppendLine("SUM(TotalNegadoEnAgenda) AS TotalNegadoEnAgenda, SUM(TotalImproductivoEnAgenda) AS TotalImproductivoEnAgenda, ");
                sConsulta.AppendLine("SUM(TotalNegadoFueraAgenda) AS TotalNegadoFueraAgenda, SUM(TotalImproductivoFueraAgenda) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalNegadoEnAgenda, ");
                sConsulta.AppendLine("TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON AGV.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN IMR.VisitaClave IS NULL THEN NULL ELSE AGV.ClienteClave END)), 0) AS TotalImproductivoEnAgenda, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = AGV.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalNegadoFueraAgenda, ");
                sConsulta.AppendLine("TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON AGV.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT(CASE WHEN IMR.VisitaClave IS NULL THEN NULL ELSE AGV.ClienteClave END)), 0) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN ImproductividadProd IMR (NOLOCK) ON IMR.VisitaClave = AGV.VisitaClave AND IMR.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                sConsulta.AppendLine("DROP TABLE #Tmp1 ");
                sConsulta.AppendLine("SET NOCOUNT OFF ");
                ClientesProductoNegado = sConsulta.ToString();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("IF (SELECT object_id('tempdb..#Tmp1')) IS NOT NULL DROP TABLE #Tmp1 ");
                sConsulta.AppendLine("SELECT * INTO #Tmp1 FROM ( ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, VIS.VisitaClave, VIS.ClienteClave, VIS.DiaClave, VIS.VendedorId, VIS.RUTClave, VIS.FechaHoraInicial ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON AGV.ClienteClave = VIS.ClienteClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorID AND VIS.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");//WHERE1 = 1 AND CONVERT(datetime, CONVERT(VARCHAR(20), Dia.FechaCaptura, 112)) between '2018-01-01T00:00:00' AND '2018-01-02T00:00:00' AND RUT.RUTClave IN ('006') AND ALN.Clave = 'MX00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ) AS Resultado ");
                sConsulta.AppendLine("SELECT ClaveCEDI, DiaClave, VendedorId, RUTClave, ");
                sConsulta.AppendLine("SUM(TotalNegadoEnAgenda) AS TotalNegadoEnAgenda, SUM(TotalImproductivoEnAgenda) AS TotalImproductivoEnAgenda, ");
                sConsulta.AppendLine("SUM(TotalNegadoFueraAgenda) AS TotalNegadoFueraAgenda, SUM(TotalImproductivoFueraAgenda) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("(SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalNegadoEnAgenda, ");
                sConsulta.AppendLine("TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON AGV.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalNegadoFueraAgenda, ");
                sConsulta.AppendLine("TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON AGV.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ProductoNegado PRG (NOLOCK) ON TRP.TransProdId = PRG.TransProdId AND NOT PRG.PromocionClave IS NULL ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalImproductivoEnAgenda, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, ");
                sConsulta.AppendLine("TotalImproductivoFueraAgenda = 0 ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) = CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON AGV.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdId = TPD.TransProdId AND TPD.Promocion = 2 ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave, ");
                sConsulta.AppendLine("TotalNegadoEnAgenda = 0, TotalImproductivoEnAgenda = 0, ");
                sConsulta.AppendLine("TotalNegadoFueraAgenda = 0, ");
                sConsulta.AppendLine("ISNULL(COUNT(DISTINCT AGV.ClienteClave), 0) AS TotalImproductivoFueraAgenda ");
                sConsulta.AppendLine("FROM #Tmp1 AS AGV ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON AGV.DiaClave = DIA.DiaClave AND CONVERT(VARCHAR(20), DIA.FechaCaptura, 103) <> CONVERT(VARCHAR(20), AGV.FechaHoraInicial, 103) ");
                sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON AGV.VisitaClave = TRP.VisitaClave AND AGV.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdId = TPD.TransProdId AND TPD.Promocion = 2 ");
                sConsulta.AppendLine("GROUP BY AGV.ClaveCEDI, AGV.DiaClave, AGV.VendedorId, AGV.RUTClave ");
                sConsulta.AppendLine(") AS Resultado ");
                sConsulta.AppendLine("GROUP BY ClaveCEDI, DiaClave, VendedorId, RUTClave ");
                sConsulta.AppendLine("DROP TABLE #Tmp1 ");
                sConsulta.AppendLine("SET NOCOUNT OFF ");

                ClientesProductoPromoNoEntregado = sConsulta.ToString();
                sConsulta = new StringBuilder();

                List<final> datos = Connection.Query<final>(Datos, null, null, true, 600).ToList();
                List<final> tiempos = Connection.Query<final>(Tiempos, null, null, true, 600).ToList();
                List<final> clientesVisitados = Connection.Query<final>(ClientesVisitados, null, null, true, 600).ToList();

                List<ClientesVisitadosConVenta> clientesVisitadosConVenta = Connection.Query<ClientesVisitadosConVenta>(ClientesVisitadosConVenta, null, null, true, 600).ToList();
                List<ImproductividadVenta> improductividadVenta = Connection.Query<ImproductividadVenta>(ImproductividadVenta, null, null, true, 600).ToList();

                List<ClientesEncuestados> clientesEncuestados = Connection.Query<ClientesEncuestados>(ClientesEncuestados, null, null, true, 600).ToList();
                List<CodigosLeidos> codigosLeidos = Connection.Query<CodigosLeidos>(CodigosLeidos, null, null, true, 600).ToList();
                List<EncuestasAplicadas> encuestasAplicadas = Connection.Query<EncuestasAplicadas>(EncuestasAplicadas, null, null, true, 600).ToList();

                List<ProductoNegado> productoNegado = Connection.Query<ProductoNegado>(ProductoNegado, null, null, true, 600).ToList();
                List<ProductoPromoNoEntregado> productoPromoNoEntregado = Connection.Query<ProductoPromoNoEntregado>(ProductoPromoNoEntregado, null, null, true, 600).ToList();
                List<ClientesProductoNegado> clientesProductoNegado = Connection.Query<ClientesProductoNegado>(ClientesProductoNegado, null, null, true, 600).ToList();
                List<ClientesProductoPromoNoEntregado> clientesProductoPromoNoEntregado = Connection.Query<ClientesProductoPromoNoEntregado>(ClientesProductoPromoNoEntregado, null, null, true, 600).ToList();
                List<final> final = new List<final>();

                var dataSource = from dato in datos
                                 join tiempo in tiempos
                                 on dato.RUTClave equals tiempo.RUTClave
                                 join cVCV in clientesVisitadosConVenta
                                 on tiempo.RUTClave equals cVCV.RUTClave
                                 join clienteVisitado in clientesVisitados
                                 on cVCV.RUTClave equals clienteVisitado.RUTClave
                                 join IV in improductividadVenta
                                 on clienteVisitado.RUTClave equals IV.RUTClave
                                 from eA in encuestasAplicadas
                                 .Where(a => a.RUTClave.Equals(IV.RUTClave) && a.ClaveCEDI.Equals(IV.ClaveCEDI) && a.DiaClave.Equals(IV.VendedorId))
                                 .DefaultIfEmpty()
                                 from cE in clientesEncuestados
                                 .Where(a => a.RUTClave.Equals(IV.RUTClave) && a.ClaveCEDI.Equals(IV.ClaveCEDI) && a.DiaClave.Equals(IV.VendedorId))
                                 .DefaultIfEmpty()
                                 from cL in codigosLeidos
                                 .Where(a => a.RUTClave.Equals(IV.RUTClave) && a.ClaveCEDI.Equals(IV.ClaveCEDI) && a.DiaClave.Equals(IV.VendedorId))
                                 .DefaultIfEmpty()
                                 from pN in productoNegado
                                 .Where(a => a.RUTClave.Equals(IV.RUTClave) && a.ClaveCEDI.Equals(IV.ClaveCEDI) && a.DiaClave.Equals(IV.VendedorId))
                                 .DefaultIfEmpty()
                                 from pPNE in productoPromoNoEntregado
                                 .Where(a => a.RUTClave.Equals(IV.RUTClave) && a.ClaveCEDI.Equals(IV.ClaveCEDI) && a.DiaClave.Equals(IV.VendedorId))
                                 .DefaultIfEmpty()
                                 from cPN in clientesProductoNegado
                                 .Where(a => a.RUTClave.Equals(IV.RUTClave) && a.ClaveCEDI.Equals(IV.ClaveCEDI) && a.DiaClave.Equals(IV.VendedorId))
                                 .DefaultIfEmpty()
                                 from cPPNE in clientesProductoPromoNoEntregado
                                 .Where(a => a.RUTClave.Equals(IV.RUTClave) && a.ClaveCEDI.Equals(IV.ClaveCEDI) && a.DiaClave.Equals(IV.VendedorId))
                                 .DefaultIfEmpty()
                                 where dato.DiaClave == tiempo.DiaClave
                                 && dato.RUTClave == tiempo.RUTClave
                                 && dato.ClaveCEDI == tiempo.ClaveCEDI
                                 && tiempo.DiaClave == cVCV.DiaClave
                                 && tiempo.RUTClave == cVCV.RUTClave
                                 && tiempo.ClaveCEDI == cVCV.ClaveCEDI
                                 && cVCV.DiaClave == clienteVisitado.DiaClave
                                 && cVCV.RUTClave == clienteVisitado.RUTClave
                                 && cVCV.ClaveCEDI == clienteVisitado.ClaveCEDI
                                 && clienteVisitado.DiaClave == IV.DiaClave
                                 && clienteVisitado.RUTClave == IV.RUTClave
                                 && clienteVisitado.ClaveCEDI == IV.ClaveCEDI
                                 select new
                                 {
                                     Almacen = tiempo.Almacen,
                                     FechaCaptura = tiempo.FechaCaptura,
                                     Vendedor = tiempo.Vendedor,
                                     Ruta = tiempo.Ruta,
                                     ClaveCEDI = tiempo.ClaveCEDI,
                                     DiaClave = tiempo.DiaClave,
                                     VendedorId = tiempo.VendedorId,
                                     RUTClave = tiempo.RUTClave,
                                     TiempoRecorrido = CalcularTiempo(dato.TiempoRecorrido),
                                     TiempoVisita = CalcularTiempo(dato.TiempoVisita),
                                     TiempoTransito = CalcularTiempo(dato.TiempoRecorrido - dato.TiempoVisita),
                                     TotalClientes = clienteVisitado.TotalClientes,
                                     EnAgendaVisitados = clienteVisitado.EnAgendaVisitados,
                                     FueraAgendaVisitados = clienteVisitado.FueraAgendaVisitados,
                                     EnAgendaNoVisitados = Convert.ToInt32(clienteVisitado.TotalClientes) - Convert.ToInt32(clienteVisitado.EnAgendaVisitados),
                                     EnAgendaVisitadosPorcent = (Convert.ToDouble(clienteVisitado.EnAgendaVisitados) * 100) / Convert.ToDouble(clienteVisitado.TotalClientes),
                                     EnAgendaNoVisitadosPorcent = ((Convert.ToDouble(clienteVisitado.TotalClientes) - Convert.ToDouble(clienteVisitado.EnAgendaVisitados)) * 100) / Convert.ToDouble(clienteVisitado.TotalClientes),
                                     ClientesVisitadosDTCV = cVCV.ClientesVisitados,
                                     ClientesVisitadosEnAgenda = cVCV.ClientesVisitadosEnAgenda,
                                     ClientesConVentaEnAgenda = cVCV.ClientesConVentaEnAgenda,
                                     ClientesConVentaEnAgendaPorcent = cVCV != null && cVCV.ClientesConVentaEnAgenda != 0 && cVCV.ClientesVisitadosEnAgenda != 0 ? (cVCV.ClientesConVentaEnAgenda * 100) / cVCV.ClientesVisitadosEnAgenda : 0,
                                     ClientesSinVentaEnAgenda = cVCV.ClientesSinVentaEnAgenda,
                                     ClientesSinVentaEnAgendaPorcent = cVCV != null && cVCV.ClientesSinVentaEnAgenda != 0 && cVCV.ClientesVisitadosEnAgenda != 0 ? (cVCV.ClientesSinVentaEnAgenda * 100) / cVCV.ClientesVisitadosEnAgenda : 0,
                                     ClientesVisitadosFueraAgenda = cVCV.ClientesVisitadosFueraAgenda,
                                     ClientesConVentaFueraAgenda = cVCV.ClientesConVentaFueraAgenda,
                                     ClientesConVentaFueraAgendaPorcent = cVCV != null && cVCV.ClientesConVentaFueraAgenda != 0 && cVCV.ClientesVisitadosFueraAgenda != 0 ? (cVCV.ClientesConVentaFueraAgenda * 100) / cVCV.ClientesVisitadosFueraAgenda : 0,
                                     ClientesSinVentaFueraAgenda = cVCV.ClientesSinVentaFueraAgenda,
                                     ClientesSinVentaFueraAgendaPorcent = cVCV != null && cVCV.ClientesSinVentaFueraAgenda != 0 && cVCV.ClientesVisitadosFueraAgenda != 0 ? (cVCV.ClientesSinVentaFueraAgenda * 100) / cVCV.ClientesVisitadosFueraAgenda : 0,
                                     ClientesNoVenta = IV.ClientesNoVenta,
                                     ClientesImproductivoEnAgenda = IV.ClientesImproductivoEnAgenda,
                                     ClientesImproductivoFueraAgenda = IV.ClientesImproductivoFueraAgenda,
                                     TotalEncuestas = (eA != null ? eA.TotalEncuestas : 0),
                                     TotalEncuestasEnAgenda = (eA != null ? eA.TotalEncuestasEnAgenda : 0),
                                     TotalAplicadasEnAgenda = (eA != null ? eA.TotalAplicadasEnAgenda : 0),
                                     TotalAplicadasEnAgendaPorcent = eA != null && eA.TotalAplicadasEnAgenda != 0 && eA.TotalEncuestasEnAgenda != 0 ? (eA.TotalAplicadasEnAgenda * 100) / eA.TotalEncuestasEnAgenda : 0,
                                     TotalNoAplicadasEnAgenda = (eA != null ? (Convert.ToInt32(eA.TotalEncuestasEnAgenda) - Convert.ToInt32(eA.TotalAplicadasEnAgenda)) : 0),
                                     TotalEncuestasFueraAgenda = (eA != null ? eA.TotalEncuestasFueraAgenda : 0),
                                     TotalAplicadasFueraAgenda = (eA != null ? eA.TotalAplicadasFueraAgenda : 0),
                                     TotalNoAplicadasFueraAgenda = (eA != null ? Convert.ToInt32(eA.TotalEncuestasFueraAgenda) - Convert.ToInt32(eA.TotalAplicadasFueraAgenda) : 0),
                                     TotalClientesEncuestados = (cE != null ? cE.TotalClientes : 0),
                                     TotalClientesConEncuestaEnAgenda = (cE != null ? cE.TotalClientesEnAgenda : 0),
                                     TotalClientesEncuestadosEnAgenda = (cE != null ? cE.TotalEncuestadosEnAgenda : 0),
                                     TotalClientesNoEncuestadosEnAgenda = (cE != null ? Convert.ToInt32(cE.TotalClientesEnAgenda) - Convert.ToInt32(cE.TotalEncuestadosEnAgenda) : 0),
                                     TotalClientesConEncuestaFueraAgenda = (cE != null ? cE.TotalClientesFueraAgenda : 0),
                                     TotalClientesEncuestadosFueraAgenda = (cE != null ? cE.TotalEncuestadosFueraAgenda : 0),
                                     TotalClientesNoEncuestadosFueraAgenda = (cE != null ? Convert.ToInt32(cE.TotalClientesFueraAgenda) - Convert.ToInt32(cE.TotalEncuestadosFueraAgenda) : 0),
                                     ClientesVisitadosCL = (cL != null ? cL.ClientesVisitados : 0),
                                     ClientesVisitadosEnAgendaCL = (cL != null ? cL.ClientesLeidosEnAgenda : 0),
                                     ClientesLeidosEnAgendaCL = (cL != null ? cL.ClientesLeidosEnAgenda : 0),
                                     ClientesVisitadosFueraAgendaCL = (cL != null ? cL.ClientesVisitadosFueraAgenda : 0),
                                     ClientesLeidosFueraAgendaCL = (cL != null ? cL.ClientesVisitadosFueraAgenda : 0),
                                     TotalNegadoPN = (pN != null ? pN.TotalNegado : 0),
                                     TotalNegadoEnAgendaPN = (pN != null ? pN.TotalNegadoEnAgenda : 0),
                                     TotalImproductivoEnAgendaPN = (pN != null ? pN.TotalImproductivoEnAgenda : 0),
                                     TotalNegadoFueraAgendaPN = (pN != null ? pN.TotalNegadoFueraAgenda : 0),
                                     TotalImproductivoFueraAgendaPN = (pN != null ? pN.TotalImproductivoFueraAgenda : 0),
                                     TotalNegadoPPNE = (pPNE != null ? pPNE.TotalNegado : 0),
                                     TotalNegadoEnAgendaPPNE = (pPNE != null ? pPNE.TotalNegadoEnAgenda : 0),
                                     TotalImproductivoEnAgendaPPNE = (pPNE != null ? pPNE.TotalImproductivoEnAgenda : 0),
                                     TotalNegadoFueraAgendaPPNE = (pPNE != null ? pPNE.TotalNegadoFueraAgenda : 0),
                                     TotalImproductivoFueraAgendaPPNE = (pPNE != null ? pPNE.TotalImproductivoEnAgenda : 0),
                                     TotalNegadoEnAgendaCPN = (cPN != null ? cPN.TotalNegadoEnAgenda : 0),
                                     TotalImproductivoEnAgendaCPN = (cPN != null ? cPN.TotalImproductivoEnAgenda : 0),
                                     TotalNegadoFueraAgendaCPN = (cPN != null ? cPN.TotalNegadoFueraAgenda : 0),
                                     TotalImproductivoFueraAgendaCPN = (cPN != null ? cPN.TotalImproductivoFueraAgenda : 0),
                                     TotalNegadoEnAgendaCPPNE = (cPPNE != null ? cPPNE.TotalNegadoEnAgenda : 0),
                                     TotalImproductivoEnAgendaCPPNE = (cPPNE != null ? cPPNE.TotalImproductivoEnAgenda : 0),
                                     TotalNegadoFueraAgendaCPPNE = (cPPNE != null ? cPPNE.TotalNegadoFueraAgenda : 0),
                                     TotalImproductivoFueraAgendaCPPNE = (cPPNE != null ? cPPNE.TotalImproductivoFueraAgenda : 0),
                                     TotalProductosImproductividad = (pN != null && pPNE != null && cPN != null ? Convert.ToInt32(pN.TotalImproductivoEnAgenda) + Convert.ToInt32(pN.TotalImproductivoFueraAgenda) + Convert.ToInt32(pPNE.TotalImproductivoEnAgenda) + Convert.ToInt32(pPNE.TotalImproductivoFueraAgenda) + Convert.ToInt32(cPN.TotalImproductivoEnAgenda) + Convert.ToInt32(cPN.TotalImproductivoFueraAgenda) + Convert.ToInt32(cPPNE.TotalImproductivoEnAgenda) + Convert.ToInt32(cPPNE.TotalImproductivoFueraAgenda) : 0)
                                 };

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
                FechaInicial = fInicio.ToShortDateString();
                efectividadPorRutaGeneral report = new efectividadPorRutaGeneral();
                report.Ruta.Text = RutasSplit;
                report.CEDIS.Text = NombreCedis;
                report.Fecha.Text = FechaInicial + FechaFinal;
                if (String.IsNullOrEmpty(VendedoresSplit))
                {
                    report.Vendedor.Text = "";
                }
                else
                {
                    report.Vendedor.Text = VendedoresSplit;
                }
                report.DataSource = dataSource;

                report.lbCEDIS.DataBindings.Add("Text", null, "Almacen");
                report.lbFecha.DataBindings.Add("Text", null, "DiaClave");
                report.lbRuta.DataBindings.Add("Text", null, "Ruta");
                report.lbVendedor.DataBindings.Add("Text", null, "Vendedor");

                report.tiempoRecorrido.DataBindings.Add("Text", null, "TiempoRecorrido");
                report.tiempoVisita.DataBindings.Add("Text", null, "TiempoVisita");
                report.tiempoTransito.DataBindings.Add("Text", null, "TiempoTransito");

                report.visitadosEnAgenda.DataBindings.Add("Text", null, "EnAgendaVisitados");
                report.noVisitadosEnAgenda.DataBindings.Add("Text", null, "EnAgendaNoVisitados");
                report.lbNoVisitadosFueraAgenda.DataBindings.Add("Text", null, "FueraAgendaVisitados");
                report.lbTotalClientes.DataBindings.Add("Text", null, "TotalClientes");
                report.lbEnAgendaVisitadosPorcent.DataBindings.Add("Text", null, "EnAgendaVisitadosPorcent", "{0:0.00}");
                report.lbEnAgendaNoVisitadosPorcent.DataBindings.Add("Text", null, "EnAgendaNoVisitadosPorcent", "{0:0.00}");

                report.lbTotalClientesVisitados.DataBindings.Add("Text", null, "ClientesVisitadosDTCV");
                report.lbClientesVisitadosConVentaEnAgenda.DataBindings.Add("Text", null, "ClientesConVentaEnAgenda");
                report.lbClientesVisitadosSinVentaEnAgenda.DataBindings.Add("Text", null, "ClientesSinVentaEnAgenda");
                report.lbClientesVisitadosConVentaFueraAgenta.DataBindings.Add("Text", null, "ClientesConVentaFueraAgenda");
                report.lbClientesVisitadosSinVentaFueraAgenta.DataBindings.Add("Text", null, "ClientesSinVentaFueraAgenda");
                report.lbClientesSinVentaEnAgendaPorcent.DataBindings.Add("Text", null, "ClientesSinVentaEnAgendaPorcent", "{0:0.00}");
                report.lbClientesConVentaEnAgendaPorcent.DataBindings.Add("Text", null, "ClientesConVentaEnAgendaPorcent", "{0:0.00}");

                report.lbClientesImproductivoFueraAgenda.DataBindings.Add("Text", null, "ClientesImproductivoFueraAgenda");
                report.lbClientesImproductivoEnAgenda.DataBindings.Add("Text", null, "ClientesImproductivoEnAgenda");

                report.lbEncuestasAplicadasEnAgenda.DataBindings.Add("Text", null, "TotalAplicadasEnAgenda");
                report.lbEncuestasAplicadasFueraAgenda.DataBindings.Add("Text", null, "TotalAplicadasFueraAgenda");
                report.lbEncuestasNoAplicadasEnAgenda.DataBindings.Add("Text", null, "TotalAplicadasEnAgenda");
                report.lbEncuestasNoAplicadasFueraAgenda.DataBindings.Add("Text", null, "TotalAplicadasFueraAgenda");
                report.lbTotalEncuestas.DataBindings.Add("Text", null, "TotalEncuestas");

                report.lbTotalClientesEncuestados.DataBindings.Add("Text", null, "TotalClientesEncuestados");
                report.lbClientesEncuestadosEnAgenda.DataBindings.Add("Text", null, "TotalClientesEncuestadosEnAgenda");
                report.lbClientesNoEncuestadosEnAgenda.DataBindings.Add("Text", null, "TotalClientesNoEncuestadosEnAgenda");
                report.lbClientesEncuestadosFueraAgenda.DataBindings.Add("Text", null, "TotalClientesEncuestadosFueraAgenda");
                report.lbClientesNoEncuestadosFueraAgenda.DataBindings.Add("Text", null, "TotalClientesNoEncuestadosFueraAgenda");

                report.lbCodigoBarrasLeidosEnAgenda.DataBindings.Add("Text", null, "ClientesVisitadosEnAgendaCL");
                report.lbCodigoBarrasNoLeidosEnAgenda.DataBindings.Add("Text", null, "ClientesLeidosEnAgendaCL");
                report.lbCodigoBarrasLeidosFueraAgenda.DataBindings.Add("Text", null, "ClientesVisitadosFueraAgendaCL");
                report.lbCodigoBarrasNoLeidosFueraAgenda.DataBindings.Add("Text", null, "ClientesLeidosFueraAgendaCL");

                report.lbProductosNoEntregadosEnAgenda.DataBindings.Add("Text", null, "TotalNegadoEnAgendaPN");
                report.lbProductosNoEntregadosFueraAgenda.DataBindings.Add("Text", null, "TotalNegadoFueraAgendaPN");
                report.lbImproductividadProductoEnAgenda.DataBindings.Add("Text", null, "TotalImproductivoEnAgendaPN");
                report.lbImproductividadProductoFueraAgenda.DataBindings.Add("Text", null, "TotalImproductivoFueraAgendaPN");
                report.lbTotalProductoNoVendido.DataBindings.Add("Text", null, "TotalNegadoPN");

                report.lbProductoPromocionalNoEntregadoEnAgenda.DataBindings.Add("Text", null, "TotalNegadoPPNE");
                report.lbProductoPromocionalNoEntregadoFueraAgenda.DataBindings.Add("Text", null, "");

                report.lbClientesProductoNegadoEnAgenda.DataBindings.Add("Text", null, "TotalNegadoEnAgendaPPNE");
                report.lbClientesProductoNegadoFueraAgenda.DataBindings.Add("Text", null, "TotalNegadoFueraAgendaPPNE");
                report.lbClientesImproductividadProductoEnAgenda.DataBindings.Add("Text", null, "TotalImproductivoEnAgendaPPNE");
                report.lbClientesImproductividadProductoFueraAgenda.DataBindings.Add("Text", null, "TotalImproductivoFueraAgendaPPNE");
                report.lbTotalProductosImproductividad.DataBindings.Add("Text", null, "TotalProductosImproductividad");

                report.lbClientesProductoPromocionNoEntregado.DataBindings.Add("Text", null, "TotalProductosImproductividad");
                report.lbClientesProductoPromocionNoEntregado.DataBindings.Add("Text", null, "TotalImproductivoEnAgendaCPN");

                report.lbClientesConVentaEnAgendaPorcent.DataBindings.Add("Text", null, "ClientesConVentaEnAgendaPorcent");
                report.lbClientesSinVentaEnAgendaPorcent.DataBindings.Add("Text", null, "ClientesSinVentaEnAgendaPorcent");
                report.lbClientesConVentaFueraAgendaPorcent.DataBindings.Add("Text", null, "ClientesConVentaFueraAgendaPorcent");
                report.lbClientesSinVentaFueraAgendaPorcent.DataBindings.Add("Text", null, "ClientesSinVentaFueraAgendaPorcent");

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte + " General";

                return report;
                #endregion
            }
        }

        private String CalcularTiempo(Int32 tsegundos)
        {
            Int32 horas = (tsegundos / 3600);
            Int32 minutos = ((tsegundos - horas * 3600) / 60);
            Int32 segundos = tsegundos - (horas * 3600 + minutos * 60);
            string sHoras;
            string sMinutos;
            string sSegundos;
            if (horas < 10)
            {
                sHoras = "0" + horas;
            }
            else
            {
                sHoras = horas.ToString();
            }
            if (minutos < 10)
            {
                sMinutos = "0" + minutos;
            }
            else
            {
                sMinutos = minutos.ToString();
            }
            if (segundos < 10)
            {
                sSegundos = "0" + segundos;
            }
            else
            {
                sSegundos = segundos.ToString();
            }

            return sHoras + ":" + sMinutos + ":" + sSegundos;
        }


        //class GranTotal
        //{
        // public double GranTotal { get; set; }
        //}


        class Tiempos
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TiempoRecorrido { get; set; }
            public int TiempoVisita { get; set; }
        }

        class Datos
        {
            public string Almacen { get; set; }
            public DateTime FechaCaptura { get; set; }
            public string Vendedor { get; set; }
            public string Ruta { get; set; }
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
        }

        class ClientesVisitados
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RutClave { get; set; }
            public string TotalClientes { get; set; }
            public int EnAgendaVisitados { get; set; }
            public int FueraAgendaVisitados { get; set; }
        }
        class ClientesVisitadosConVenta
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int ClientesVisitados { get; set; }
            public int ClientesVisitadosEnAgenda { get; set; }
            public int ClientesConVentaEnAgenda { get; set; }
            public int ClientesSinVentaEnAgenda { get; set; }
            public int ClientesVisitadosFueraAgenda { get; set; }
            public int ClientesConVentaFueraAgenda { get; set; }
            public int ClientesSinVentaFueraAgenda { get; set; }
        }

        class ImproductividadVenta
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int ClientesNoVenta { get; set; }
            public int ClientesImproductivoEnAgenda { get; set; }
            public int ClientesImproductivoFueraAgenda { get; set; }
        }

        class EncuestasAplicadas
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalEncuestas { get; set; }
            public int TotalEncuestasEnAgenda { get; set; }
            public int TotalAplicadasEnAgenda { get; set; }
            public int TotalEncuestasFueraAgenda { get; set; }
            public int TotalAplicadasFueraAgenda { get; set; }
        }

        class ClientesEncuestados
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalClientes { get; set; }
            public int TotalClientesEnAgenda { get; set; }
            public int TotalEncuestadosEnAgenda { get; set; }
            public int TotalClientesFueraAgenda { get; set; }
            public int TotalEncuestadosFueraAgenda { get; set; }
        }

        class CodigosLeidos
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int ClientesVisitados { get; set; }
            public int ClientesVisitadosEnAgenda { get; set; }
            public int ClientesLeidosEnAgenda { get; set; }
            public int ClientesVisitadosFueraAgenda { get; set; }
            public int ClientesLeidosFueraAgenda { get; set; }
        }

        class ProductoNegado
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalNegado { get; set; }
            public int TotalNegadoEnAgenda { get; set; }
            public int TotalImproductivoEnAgenda { get; set; }
            public int TotalNegadoFueraAgenda { get; set; }
            public int TotalImproductivoFueraAgenda { get; set; }
        }

        class ProductoPromoNoEntregado
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalNegado { get; set; }
            public int TotalNegadoEnAgenda { get; set; }
            public int TotalImproductivoEnAgenda { get; set; }
            public int TotalNegadoFueraAgenda { get; set; }
            public int TotalImproductivoFueraAgenda { get; set; }
        }
        class ClientesProductoNegado
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalNegadoEnAgenda { get; set; }
            public int TotalImproductivoEnAgenda { get; set; }
            public int TotalNegadoFueraAgenda { get; set; }
            public int TotalImproductivoFueraAgenda { get; set; }
        }

        class ClientesProductoPromoNoEntregado
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalNegadoEnAgenda { get; set; }
            public int TotalImproductivoEnAgenda { get; set; }
            public int TotalNegadoFueraAgenda { get; set; }
            public int TotalImproductivoFueraAgenda { get; set; }
        }

        class final
        {
            public string Almacen { get; set; }
            public DateTime FechaCaptura { get; set; }
            public string Vendedor { get; set; }
            public string Ruta { get; set; }
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TiempoRecorrido { get; set; }
            public int TiempoVisita { get; set; }
            public string TotalClientes { get; set; }
            public int EnAgendaVisitados { get; set; }
            public int FueraAgendaVisitados { get; set; }
        }

        class QP
        {
            public string Almacen { get; set; }
            public DateTime FechaCaptura { get; set; }
            public string VendedorId { get; set; }
            public string Vendedor { get; set; }
            public string RUTClave { get; set; }
            public string Ruta { get; set; }
            public string AlmacenId { get; set; }
            public string DiaClave { get; set; }
        }
        class TiemposDet
        {
            public string AlmacenId { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public DateTime HoraInicial { get; set; }
            public DateTime HoraFinal { get; set; }
            public int TiempoRecorrido { get; set; }
            public int TiempoVisita { get; set; }
        }

        //CLASE PARA LAS SIGUIENTES CONSULTAS:
        //TotalClientes, totalVisitadosEncuestar, TotalProductosPromocional
        //TotalProductoPromocionalFA
        class TotalClientes
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalCliente { get; set; }
        }

        //CLASE PARA LAS SIGUIENTES CONSULTAS:
        //ClientesNoVisitados, clientesVisitados, ClientesVisitadosFA
        //totalvisitados, clientesVisitadosConVenta, clientesVisitadosConVentaFA
        //totalVisitadosSinVenta, ClientesEncuestados, ClientesEncuestadosFA, 
        //clientesNoEncuestados, ClientesNoEncuestadosFA, codigosLeidos, codigosLeidosFA
        //CodigosNoLeidos, CodigosNoLeidosFA, ProductoNegado, ProductoNegadoFA

        class ClientesNoVisitados
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string ClienteClave { get; set; }
            public string Nombre { get; set; }
        }

        //EN ESTA TMB SE PUEDE USAR LAS SIGUEINTES:
        //clientesVisitadosSinVentaFA, 
        class ClientesVisitadosSinVenta
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string ClienteClave { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
        }

        //Las siguientes consultan caben en la siguiente clase:
        //ImproductividadVentaFA
        class ImproductividadVentaDet
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string ClienteClave { get; set; }
            public string Nombre { get; set; }
            public string Motivo { get; set; }
        }
        class TotalEncuestas
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int TotalEncuesta { get; set; }
        }


        //EncuestasAplicadasFA, encuestasNoAplicadas, encuestasNoAplicadasFA, 
        //
        class EncuestasAplicadasDet
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public int Encuesta { get; set; }
        }

        //improductividadProductoFA
        class ImproductividadProductoDet
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string ClienteClave { get; set; }
            public string Nombre { get; set; }
            public string Motivo { get; set; }
            public int Cantidad { get; set; }
        }


        //motivosImproductividadFA
        class MotivosImproductividad
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string Motivo { get; set; }
            public int Cantidad { get; set; }
        }

        //ProductoPromoNoEntregadoFA
        class ProductoPromoNoEntregadoDet
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
        }

        //ClientesProductoNegadoFA
        class ClientesProductoNegadoDet
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string Cliente { get; set; }
            public string Producto { get; set; }
            public string Unidad { get; set; }
            public int Cantidad { get; set; }
            public int CantidadUnitaria { get; set; }
        }

        //ClientesImproductividadProductoFA
        class ClientesImproductividadProducto
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string Cliente { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
        }

        //ClienteProductoPromoNoEntregadoFA
        class ClienteProductoPromoNoEntregado
        {
            public string ClaveCEDI { get; set; }
            public string DiaClave { get; set; }
            public string VendedorId { get; set; }
            public string RUTClave { get; set; }
            public string Cliente { get; set; }
            public string Producto { get; set; }
            public string Unidad { get; set; }
            public int Cantidad { get; set; }
            public int CantidadUnitaria { get; set; }
        }
    }
}


