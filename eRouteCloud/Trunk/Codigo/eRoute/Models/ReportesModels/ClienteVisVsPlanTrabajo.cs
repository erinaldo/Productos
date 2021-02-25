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
    public class ClienteVisVsPlanTrabajo
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        ReporteClienteVisVsPlanTrabajo report = new ReporteClienteVisVsPlanTrabajo();
        ReporteClienteVisVsPlanTrabajo subreport = new ReporteClienteVisVsPlanTrabajo();
        List<int> CabeceraVV = new List<int>();
        List<int> CabeceraEF = new List<int>();
        List<int> CabeceraFF = new List<int>();
        List<int> CabeceraVP = new List<int>();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, int VAVClave, string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis, string unidadMedida)
        {
            //Logo Empresa
            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            report.logo.Image = Image.FromStream(mStream);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;

            //Fecha de generación del Reporte
            DateTime fReporte = DateTime.Now;
            report.labelFechaReporteHeader.Text = fReporte.ToLocalTime() + "";

            //Almacen
            report.labelCEDIHeader.Text = nombreCedis;

            //Fecha de Carga
            DateTime fInicio = DateTime.Parse(FechaInicial);
            string FCapturaR = fInicio.Date.ToShortDateString();
            string FCaptura = fInicio.Date.ToString("yyyyMMdd");
            if (FechaFinal != null && FechaFinal != "" && FechaFinal != "null")
            {
                FCapturaR = FCapturaR + " - " + DateTime.Parse(FechaFinal).ToShortDateString();
            }
            report.labelFechaHeader.Text = FCapturaR;

            //Rutas
            RutasSplit = RutasSplit.Replace(",", ", ");
            report.labelRutaHeader.Text = RutasSplit;

            ////Header responsivo
            //float aux1 = Convert.ToInt32(report.TopMargin.HeightF);
            //int contador = RutasSplit.Length / 430;
            //if (RutasSplit.Length % 430 != 0)
            //    contador += 1;
            //for (int i = 1; i < contador; i++)
            //{
            //    aux1 += 20;
            //}
            //report.TopMargin.HeightF = (aux1);

            //Filtro
            string Filtro = FechaInicial.Substring(0, 4) + FechaInicial.Substring(5, 2) + FechaInicial.Substring(8, 2);
            string FiltroFin;
            if (FechaFinal != "" || FechaFinal != "null" || FechaFinal != null)
            {
                FiltroFin = FechaFinal.Substring(0, 4) + FechaFinal.Substring(5, 2) + FechaFinal.Substring(8, 2);
            }
            else
            {
                FiltroFin = FechaInicial.Substring(0, 4) + FechaInicial.Substring(5, 2) + FechaInicial.Substring(8, 2);
            }

            //Filtro de Rutas
            StringBuilder CDetalle = new StringBuilder();
            CDetalle.AppendLine("SET ANSI_WARNINGS OFF ");
            CDetalle.AppendLine("SET NOCOUNT ON ");
            CDetalle.AppendLine("SELECT Clave + ' ' + Descripcion AS RutaDetalle, Clave AS ClaveR FROM ");
            CDetalle.AppendLine("(");
            CDetalle.AppendLine("SELECT Ruta.RUTClave AS Clave, Descripcion ");
            CDetalle.AppendLine("FROM Ruta (NOLOCK) ");
            CDetalle.AppendLine(") AS Detalle ");
            CDetalle.AppendLine(pvCondicion);

            QueryString = "";
            QueryString = CDetalle.ToString();

            List<Detalle> DetalleCV = Connection.Query<Detalle>(QueryString, null, null, true, 600).ToList();

            var Det = (from D in DetalleCV select D).ToList().GroupBy(DD => new { DD.RutaDetalle })
                    .SelectMany(DL => DL.Select(DS => new Detalle
                    {
                        RutaDetalle = DS.RutaDetalle,
                        ClaveR = DS.ClaveR
                    })).ToList();
            string RutaFiltro = "";
            foreach (var item in Det)
            {
                if (item == Det.Last())
                {
                    RutaFiltro += "'" + item.ClaveR + "'";
                }
                else
                {
                    RutaFiltro += "'" + item.ClaveR + "',";
                }
            }

            //Obtiene Clientes
            StringBuilder Consulta = new StringBuilder();
            Consulta.AppendLine("SET ANSI_WARNINGS OFF ");
            Consulta.AppendLine("SET NOCOUNT ON ");
            Consulta.AppendLine("SET LANGUAGE Spanish ");
            Consulta.AppendLine("SELECT ");
            Consulta.AppendLine("DISTINCT USU2.Clave AS SUPClave, USU2.Nombre AS SUPNombre, ISNULL(Vis.Numero , 5000) AS Numero, ");
            Consulta.AppendLine("AV.orden AS Ordenvisita, ");
            Consulta.AppendLine("Vis.fechahorainicial AS FechaHoraInicial, ");
            Consulta.AppendLine("Vis.FechaHoraFinal AS FechaHoraFinal, ");
            Consulta.AppendLine("datename(dw,D.FechaCaptura) AS DiaVisita, ");
            Consulta.AppendLine("Clie.clienteclave AS Codigo, ");
            Consulta.AppendLine("Clie.razonsocial AS NombreCliente, ");
            Consulta.AppendLine("ClieDom.calle AS Direccion, ");
            Consulta.AppendLine("CASE WHEN Vis.fuerafrecuencia IS NULL THEN 'SIN VISITA' WHEN Vis.fuerafrecuencia = 0 THEN 'SI' WHEN Vis.fuerafrecuencia = 1 THEN 'NO' END AS Frecuencia, ");
            Consulta.AppendLine("AV.RUTClave AS Ruta, ");
            Consulta.AppendLine("VEN.VendedorID AS IdVendedor, ");
            Consulta.AppendLine("USU.Nombre AS UsuVenNom, ");
            Consulta.AppendLine("ALM.Nombre AS AlmacenNom, ");
            Consulta.AppendLine("1 AS Planeados, ");
            Consulta.AppendLine("CASE WHEN Vis.fuerafrecuencia IS NULL THEN 0 WHEN Vis.fuerafrecuencia = 0 THEN 1 WHEN Vis.fuerafrecuencia = 1 THEN 1 END AS Visitados, ");
            Consulta.AppendLine("CASE WHEN Vis.fuerafrecuencia IS NULL THEN 0 WHEN Vis.fuerafrecuencia = 0 THEN 1 WHEN Vis.fuerafrecuencia = 1 THEN 0 END AS EnFrecuencia, ");
            Consulta.AppendLine("CASE WHEN Vis.fuerafrecuencia IS NULL THEN 0 WHEN Vis.fuerafrecuencia = 0 THEN 0 WHEN Vis.fuerafrecuencia = 1 THEN 1 END AS FueraFrecuencia ");
            Consulta.AppendLine("FROM AgendaVendedor AV (NOLOCK) ");
            Consulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = AV.DiaClave ");
            Consulta.AppendLine("LEFT JOIN Visita Vis (NOLOCK) ON Vis.DiaClave = AV.DiaClave AND Vis.ClienteClave = AV.ClienteClave AND Vis.VendedorID = AV.VendedorId AND Vis.RUTClave = AV.RUTClave ");
            Consulta.AppendLine("INNER JOIN Cliente Clie (NOLOCK) ON Clie.ClienteClave = AV.ClienteClave ");
            Consulta.AppendLine("INNER JOIN ClienteDomicilio ClieDom (NOLOCK) ON ClieDom.ClienteClave = Clie.ClienteClave AND ClieDom.Tipo = 2 ");
            Consulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = AV.VendedorId ");
            Consulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON USU.USUId = VEN.USUId ");
            Consulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.Clave = AV.ClaveCEDI ");
            Consulta.AppendLine("INNER JOIN SupervisorRuta SUR (NOLOCK) ON SUR.RUTClave = AV.RUTClave ");
            Consulta.AppendLine("INNER JOIN Usuario USU2 (NOLOCK) ON USU2.USUId = SUR.USUIdSupervisor ");
            Consulta.AppendLine("WHERE 1 = 1 AND CONVERT(datetime,CONVERT(varchar(20),D.FechaCaptura,112)) BETWEEN '" + Filtro + "' AND '" + FiltroFin + "' AND AV.RUTClave in (" + RutaFiltro + ")");
            Consulta.AppendLine("UNION ");
            Consulta.AppendLine("SELECT DISTINCT USU2.Clave AS SUPClave, USU2.Nombre AS SUPNombre, Vis.Numero, ");
            Consulta.AppendLine("'-' AS Ordenvisita, ");
            Consulta.AppendLine("Vis.fechahorainicial AS FechaHoraInicial, ");
            Consulta.AppendLine("Vis.FechaHoraFinal AS FechaHoraFinal, ");
            Consulta.AppendLine("datename(dw,D.FechaCaptura) AS DiaVisita, ");
            Consulta.AppendLine("Clie.clienteclave AS Codigo, ");
            Consulta.AppendLine("Clie.razonsocial AS NombreCliente,ClieDom.calle AS Direccion,'NO' AS Frecuencia, ");
            Consulta.AppendLine("Vis.RUTClave AS Ruta ,VEN.VendedorID AS IdVendedor, ");
            Consulta.AppendLine("USU.Nombre AS UsuVenNom, ALM.Nombre AS AlmacenNom,0 AS Planeados, ");
            Consulta.AppendLine("0 AS Visitados, 0 AS EnFrecuencia, 1 AS FueraFrecuencia ");
            Consulta.AppendLine("FROM Visita VIS (NOLOCK) ");
            Consulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = Vis.DiaClave ");
            Consulta.AppendLine("INNER JOIN Cliente Clie (NOLOCK) ON Clie.ClienteClave = Vis.ClienteClave ");
            Consulta.AppendLine("INNER JOIN ClienteDomicilio ClieDom (NOLOCK) ON ClieDom.ClienteClave = Clie.ClienteClave AND ClieDom.Tipo = 2 ");
            Consulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = Vis.VendedorId ");
            Consulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON USU.USUId = VEN.USUId ");
            Consulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND D.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
            Consulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.AlmacenID = VCH.AlmacenId ");
            Consulta.AppendLine("INNER JOIN SupervisorRuta SUR (NOLOCK) ON SUR.RUTClave = VIS.RUTClave ");
            Consulta.AppendLine("INNER JOIN Usuario USU2 (NOLOCK) ON USU2.USUId = SUR.USUIdSupervisor ");
            Consulta.AppendLine("WHERE Vis.FueraFrecuencia = 1 AND CONVERT(datetime,CONVERT(varchar(20),D.FechaCaptura,112)) BETWEEN '" + Filtro + "' AND '" + FiltroFin + "' AND VIS.RUTClave in (" + RutaFiltro + ")");
            Consulta.AppendLine("ORDER BY SUPClave, Ruta, Numero ");

            QueryString = "";
            QueryString = Consulta.ToString();

            List<ReporteClienteVisVsPlanTrabajoModel> Clientes = Connection.Query<ReporteClienteVisVsPlanTrabajoModel>(QueryString, null, null, true, 600).ToList();

            var SubClientes = (from c in Clientes
                               select c).ToList();
            var CabeceraCli = (from c in Clientes
                               select new { c.SUPClave, c.NombreCliente, c.Codigo, c.Direccion, c.Frecuencia, c.Ruta, c.IdVendedor, c.UsuVenNom, c.AlmacenNom, c.Planeados, c.Visitados, c.EnFrecuencia, c.FueraFrecuencia }).Distinct().ToList();
            List<ReporteClienteVisVsPlanTrabajoModel> Cli = new List<ReporteClienteVisVsPlanTrabajoModel>();

            var SC = (from gr in SubClientes group gr by new { gr.Ruta } into grupo select grupo);
            var CC = (from gr in CabeceraCli group gr by new { gr.Ruta } into grupo select grupo);

            foreach (var grupo in CC)
            {
                List<String> Existe = new List<String>();
                var aux = "";
                var Planeados = 0;
                var Visitados = 0;
                var EFrecuencia = 0;
                var FFrecuencia = 0;
                foreach (var objetoAgrupado in grupo)
                {
                    if (objetoAgrupado.Codigo != aux && !Existe.Contains(objetoAgrupado.Codigo))
                    {
                        Planeados += 1;
                        aux = objetoAgrupado.Codigo;
                        Existe.Add(aux);
                    }
                    if (objetoAgrupado.Visitados == 1)
                    {
                        Visitados += 1;
                    }
                    if (objetoAgrupado.EnFrecuencia == 1)
                    {
                        EFrecuencia += 1;
                    }
                    if (objetoAgrupado.FueraFrecuencia == 1)
                    {
                        FFrecuencia += 1;
                    }
                }
                CabeceraVP.Add(Planeados);
                CabeceraVV.Add(Visitados);
                CabeceraEF.Add(EFrecuencia);
                CabeceraFF.Add(FFrecuencia);
            }

            var contenido = 0;
            foreach (var grupo in SC)
            {
                foreach (var objetoAgrupado in grupo)
                {
                    Cli.Add(new ReporteClienteVisVsPlanTrabajoModel
                    {
                        SUPClave = objetoAgrupado.SUPClave,
                        Numero = objetoAgrupado.Numero.Replace("5000", "-"),
                        Ordenvisita = objetoAgrupado.Ordenvisita,
                        FechaHoraInicial = objetoAgrupado.FechaHoraInicial,
                        FechaHoraFinal = objetoAgrupado.FechaHoraFinal,
                        DiaVisita = objetoAgrupado.DiaVisita,
                        Codigo = objetoAgrupado.Codigo,
                        NombreCliente = objetoAgrupado.NombreCliente,
                        Direccion = objetoAgrupado.Direccion,
                        Frecuencia = objetoAgrupado.Frecuencia,
                        Ruta = objetoAgrupado.Ruta,
                        IdVendedor = objetoAgrupado.IdVendedor,
                        UsuVenNom = objetoAgrupado.UsuVenNom,
                        AlmacenNom = objetoAgrupado.AlmacenNom,
                        Planeados = objetoAgrupado.Planeados,
                        Visitados = objetoAgrupado.Visitados,
                        EnFrecuencia = objetoAgrupado.EnFrecuencia,
                        FueraFrecuencia = objetoAgrupado.FueraFrecuencia,
                        VDetalle = objetoAgrupado.IdVendedor + " - " + objetoAgrupado.UsuVenNom
                    });
                    Cli.Last().T_Planeados = CabeceraVP[contenido];
                    Cli.Last().T_Visitados = CabeceraVV[contenido];
                    Cli.Last().T_EnFrecuencia = CabeceraEF[contenido];
                    Cli.Last().T_FFrecuencia = CabeceraFF[contenido];
                }
                contenido += 1;
            }

            report.DataSource = Cli;

            //grouheader2
            GroupField groupSupervisor = new GroupField("SUPClave");
            report.GroupHeader2.GroupFields.Add(groupSupervisor);
            report.LabelSupervisor.DataBindings.Add("Text", report.DataSource, "SUPClave");

            //grouheader1
            GroupField groupFolio = new GroupField("Ruta");
            report.GroupHeader1.GroupFields.Add(groupFolio);
            report.LabelVendedor.DataBindings.Add("Text", report.DataSource, "VDetalle");
            report.LabelRuta.DataBindings.Add("Text", report.DataSource, "Ruta");
            report.LabelVisitas.DataBindings.Add("Text", report.DataSource, "T_Planeados");
            report.LabelClientesV.DataBindings.Add("Text", report.DataSource, "T_Visitados");
            report.LabelEFrecuencia.DataBindings.Add("Text", report.DataSource, "T_EnFrecuencia");
            report.LabelFFrecuencia.DataBindings.Add("Text", report.DataSource, "T_FFrecuencia");

            //Datos Generales
            report.LabelNO.DataBindings.Add("Text", null, "Numero");
            report.LabelOVisita.DataBindings.Add("Text", null, "Ordenvisita");
            report.LabelFHInicial.DataBindings.Add("Text", null, "FechaHoraInicial");
            report.LabelFHFinal.DataBindings.Add("Text", null, "FechaHoraFinal");
            report.LabelDVisita.DataBindings.Add("Text", null, "DiaVisita");
            report.LabelCodigo.DataBindings.Add("Text", null, "Codigo");
            report.LabelNombre.DataBindings.Add("Text", null, "NombreCliente");
            report.LabelDireccion.DataBindings.Add("Text", null, "Direccion");
            report.LabelFrecuencia.DataBindings.Add("Text", null, "Frecuencia");

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
    }

    class ReporteClienteVisVsPlanTrabajoModel
    {
        public string SUPClave { get; set; }
        public string Numero { get; set; }
        public long Ordenvisita { get; set; }
        public string FechaHoraInicial { get; set; }
        public string FechaHoraFinal { get; set; }
        public string DiaVisita { get; set; }
        public string Codigo { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string Frecuencia { get; set; }
        public string Ruta { get; set; }
        public string IdVendedor { get; set; }
        public string UsuVenNom { get; set; }
        public string AlmacenNom { get; set; }
        public long Planeados { get; set; }
        public long Visitados { get; set; }
        public long EnFrecuencia { get; set; }
        public long FueraFrecuencia { get; set; }
        public string VDetalle { get; set; }
        public long T_Planeados { get; set; }
        public long T_Visitados { get; set; }
        public long T_EnFrecuencia { get; set; }
        public long T_FFrecuencia { get; set; }
    }
}