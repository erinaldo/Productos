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

namespace eRoute.Models.ReportesModels
{
    public class ResumenTiempoMovimientos
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        
        public XtraReport GetReport(string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal, string nombreCedis, string pvCondicion1)
        {
            try
            {
                DateTime fInicio = DateTime.Parse(FechaInicial);
                DateTime fFin = DateTime.Now;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    FechaFinal = "";
                }
                else
                {
                    fFin = DateTime.Parse(FechaFinal);
                    //FechaFinal = " - " + fFin.Date.ToShortDateString();
                }
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK)";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);

                #region consulta
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT * ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT USU2.Clave AS ClaveSupervisor, USU2.Nombre AS NombreSupervisor, v.VendedorID, u.Nombre, v.RUTClave,  ");
                sConsulta.AppendLine("(CASE WHEN (t.Tipo = 1 AND (t.TipoFase = 1 OR t.tipofase = 13)) then 'Pedido' when (t.Tipo = 1 AND t.TipoFase = 2 ) then 'Nota de Venta' when (t.Tipo = 9) then 'Cambio de Producto' else 'Otro' end) AS Actividad, ");
                sConsulta.AppendLine("d.FechaCaptura AS Fecha, ");
                sConsulta.AppendLine("CONVERT(char(8), v.FechaHoraInicial, 114) AS HoraInicial, ");
                sConsulta.AppendLine("CONVERT(char(8), v.FechaHoraFinal, 114) AS HoraFinal, ");
                sConsulta.AppendLine("(ISNULL(CONVERT(char(8), dateadd(ss, datediff(second, v.FechaHoraInicial, v.FechaHoraFinal), '19000101'), 114), '')) AS TiempoFinal, ");
                sConsulta.AppendLine("c.Clave AS Cliente, ");
                sConsulta.AppendLine("c.RazonSocial AS NombreCliente, ");
                sConsulta.AppendLine("ISNULL(cd.Calle, '') + ' ' + ISNULL(cd.Numero, '') + ' ' + ISNULL(cd.NumInt, '') + ' ' + ISNULL(cd.ReferenciaDom, '') + ' ' + ISNULL(cd.Colonia, '') AS Direccion, ");
                sConsulta.AppendLine("t.Folio AS Documento, ");
                sConsulta.AppendLine("t.Total AS Total, ");
                sConsulta.AppendLine("v.Numero ");
                sConsulta.AppendLine("FROM TransProd t (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita v (NOLOCK) ON v.DiaClave = ISNULL(t.DiaClave1, t.DiaClave) AND v.VisitaClave = ISNULL(t.VisitaClave1, t.VisitaClave) ");
                sConsulta.AppendLine("INNER JOIN Cliente c (NOLOCK) ON v.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN ClienteDomicilio cd (NOLOCK) ON c.ClienteClave = cd.ClienteClave AND cd.Tipo = 2 ");
                sConsulta.AppendLine("INNER JOIN Dia d (NOLOCK) ON d.DiaClave = ISNULL(t.DiaClave1, t.DiaClave) ");
                sConsulta.AppendLine("INNER JOIN Vendedor ve (NOLOCK) ON v.VendedorID = ve.VendedorID ");
                sConsulta.AppendLine("INNER JOIN Usuario u (NOLOCK) ON ve.USUId = u.USUId ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist vch (NOLOCK) ON ve.VendedorID = vch.VendedorId AND CONVERT(datetime, left(VCHFechaInicial, 11), 112)< = d.FechaCaptura AND FechaFinal> = d.FechaCaptura --and vch.FechaFinal = '9999-12-31T00:00:00.000' ");
                sConsulta.AppendLine("INNER JOIN Almacen a (NOLOCK) ON vch.AlmacenId = a.AlmacenID ");
                sConsulta.AppendLine("INNER JOIN SupervisorRuta SR (NOLOCK) ON v.RUTClave = SR.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Usuario USU2 (NOLOCK) ON SR.USUIdSupervisor = USU2.USUId ");
                sConsulta.AppendLine("WHERE ((t.Tipo = 1 AND t.TipoFase <> 0) OR (t.Tipo = 9 AND t.TipoFase <> 0 AND t.TipoMovimiento = 1))" + pvCondicion1);
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT USU2.Clave AS ClaveSupervisor, USU2.Nombre AS NombreSupervisor, v.VendedorID, u.Nombre, v.RUTClave, ");
                sConsulta.AppendLine("'Visita sin Resultado' AS Actividad, ");
                sConsulta.AppendLine("d.FechaCaptura AS Fecha, ");
                sConsulta.AppendLine("CONVERT(char(8), v.FechaHoraInicial, 114) AS HoraInicial, ");
                sConsulta.AppendLine("CONVERT(char(8), v.FechaHoraFinal, 114) AS HoraFinal, ");
                sConsulta.AppendLine("(ISNULL(CONVERT(char(8), dateadd(ss, datediff(second, v.FechaHoraInicial, v.FechaHoraFinal), '19000101'), 114), '')) AS TimepoFinal, ");
                sConsulta.AppendLine("c.Clave AS Cliente, ");
                sConsulta.AppendLine("c.RazonSocial AS NombreCliente, ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("ISNULL(cd.Calle, '') + ' ' + ISNULL(cd.Numero, '') + ' ' + ISNULL(cd.NumInt, '') + ' ' + ISNULL(cd.ReferenciaDom, '') + ' ' + ISNULL(cd.Colonia, '') AS Direccion, ");
                sConsulta.AppendLine("'' AS Documento, ");
                sConsulta.AppendLine("'0.00' AS Total, ");
                sConsulta.AppendLine("v.Numero ");
                sConsulta.AppendLine("FROM ImproductividadVenta iv (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia d (NOLOCK) ON d.DiaClave = iv.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Visita v (NOLOCK) ON iv.VisitaClave = v.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Cliente c (NOLOCK) ON v.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN ClienteDomicilio cd (NOLOCK) ON c.ClienteClave = cd.ClienteClave AND cd.Tipo = 2 ");
                sConsulta.AppendLine("INNER JOIN Vendedor ve (NOLOCK) ON v.VendedorID = ve.VendedorID ");
                sConsulta.AppendLine("INNER JOIN Usuario u (NOLOCK) ON ve.USUId = u.USUId ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist vch (NOLOCK) ON ve.VendedorID = vch.VendedorId AND CONVERT(datetime, left(VCHFechaInicial, 11), 112)< = d.FechaCaptura AND FechaFinal> = d.FechaCaptura --and vch.FechaFinal = '9999-12-31T00:00:00.000' ");
                sConsulta.AppendLine("INNER JOIN Almacen a (NOLOCK) ON vch.AlmacenId = a.AlmacenID ");
                sConsulta.AppendLine("INNER JOIN SupervisorRuta SR (NOLOCK) ON v.RUTClave = SR.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN Usuario USU2 (NOLOCK) ON SR.USUIdSupervisor = USU2.USUId ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("ORDER BY T.Fecha, T.Numero");
                QueryString = sConsulta.ToString();
                #endregion
                Report_ResActividades report = new Report_ResActividades(QueryString);

                //ReportHeader
                report.Logo.Image = Image.FromStream(mStream);
                report.Logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.L_fechaEncabezado.Text = DateTime.Now.ToString();
                report.L_FechaRango.Text = fInicio.Date.ToShortDateString() + " - " + fFin.Date.ToShortDateString();
                report.L_CEDI.Text = nombreCedis;
                report.L_Ruta.Text = RutasSplit;

                return report;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}