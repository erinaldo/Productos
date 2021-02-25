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
    public class MPlandeTrebajoSemanal
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string RutasSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis, string Presupuesto, string promocion)
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
                FechaFinal = " - " + fFin.Date.ToShortDateString();
            }

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("SELECT USU2.Clave AS ClaveSupervisor, USU2.Nombre AS NombreSupervisor, s.RUTClave AS Ruta, v.VendedorID + '-' + u.Nombre AS Vendedor, s.Orden AS OrdenVisita, c.Clave AS CodigoCliente, c.NombreContacto AS Cliente, c.RazonSocial, c.IdFiscal AS RFC, ");
            sConsulta.AppendLine("cd.Calle + ' ' + cd.Numero + ' ' + cd.NumInt + ' ' + cd.ReferenciaDom AS Direccion, cd.Colonia, c.TelefonoContacto AS Telefono, datename(dw, '" + FechaInicial + "' ) AS DiaSemana ");
            sConsulta.AppendLine("FROM Secuencia s (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Cliente c (NOLOCK) ON s.ClienteClave = c.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN ClienteDomicilio cd (NOLOCK) ON s.ClienteClave = cd.ClienteClave AND s.ClienteDomicilioID = cd.ClienteDomicilioID ");
            sConsulta.AppendLine("INNER JOIN VenRut vr (NOLOCK) ON s.RUTClave = vr.RUTClave AND vr.TipoEstado = 1 ");
            sConsulta.AppendLine("INNER JOIN Vendedor v (NOLOCK) ON vr.VendedorID = v.VendedorID ");
            sConsulta.AppendLine("INNER JOIN Usuario u (NOLOCK) ON v.USUId = u.USUId ");
            sConsulta.AppendLine("INNER JOIN Frecuencia f (NOLOCK) ON s.FrecuenciaClave = f.FrecuenciaClave ");
            sConsulta.AppendLine("INNER JOIN (SELECT v.VAVClave, vd.Descripcion ");
            sConsulta.AppendLine("FROM VARValor v (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN VAVDescripcion vd (NOLOCK) ON v.VARCodigo = vd.VARCodigo AND v.VAVClave = vd.VAVClave ");
            sConsulta.AppendLine("WHERE v.VARCodigo = 'FREDIA' AND VADTipoLenguaje = 'EM') AS vd (NOLOCK) ON f.UnidadInicio = vd.VAVClave ");
            sConsulta.AppendLine("INNER JOIN SupervisorRuta sr (NOLOCK) ON vr.RUTClave = sr.RUTClave ");
            sConsulta.AppendLine("LEFT JOIN Usuario USU2 (NOLOCK) ON SR.USUIdSupervisor = USU2.USUId ");
            //Rutas
            if (RutasSplit.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion);
            }
            if (Presupuesto.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion1);
            }
            sConsulta.AppendLine("AND datename(dw, '" + FechaInicial + "' ) = vd.Descripcion");
            sConsulta.AppendLine("ORDER BY s.RUTClave, s.FrecuenciaClave, s.Orden ");
            QueryString = "";
            QueryString = sConsulta.ToString();
            List<Rplan> planSemanal = Connection.Query<Rplan>(QueryString, null, null, true, 600).ToList();
            if (planSemanal.Count != 0)
            {
                PlanTrabajoSemanal report = new PlanTrabajoSemanal();
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;

                report.fechaa.Text = DateTime.Now.ToString();
                report.ruta.Text = RutasSplit;
                //CEDI
                report.centro.Text = Cedis + '-' + nombreCedis;
                report.DataSource = planSemanal;
                report.visita.DataBindings.Add("Text", null, "DiaSemana");
                report.clave.DataBindings.Add("Text", null, "ClaveSupervisor");
                report.nombre.DataBindings.Add("Text", null, "NombreSupervisor");
                report.ven.DataBindings.Add("Text", null, "Vendedor");
                report.ru.DataBindings.Add("Text", null, "Ruta");
                report.x1.DataBindings.Add("Text", null, "OrdenVisita");
                report.x2.DataBindings.Add("Text", null, "CodigoCliente");
                report.x3.DataBindings.Add("Text", null, "RazonSocial");
                report.x4.DataBindings.Add("Text", null, "Cliente");
                report.x5.DataBindings.Add("Text", null, "RFC");
                report.x6.DataBindings.Add("Text", null, "Direccion");
                report.x7.DataBindings.Add("Text", null, "Colonia");
                report.x8.DataBindings.Add("Text", null, "Telefono");
                return report;
            }
            else
            {
                return null;
            }
        }
    }
    class Rplan
    {
        public String ClaveSupervisor { get; set; }
        public String NombreSupervisor { get; set; }
        public String Ruta { get; set; }
        public String Vendedor { get; set; }
        public String OrdenVisita { get; set; }
        public String CodigoCliente { get; set; }
        public String Cliente { get; set; }
        public String RazonSocial { get; set; }
        public String RFC { get; set; }
        public String Direccion { get; set; }
        public String Colonia { get; set; }
        public String Telefono { get; set; }
        public String DiaSemana { get; set; }
    }
}