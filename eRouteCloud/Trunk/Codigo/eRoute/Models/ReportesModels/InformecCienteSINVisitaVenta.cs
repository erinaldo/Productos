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
    public class InformecCienteSINVisitaVenta
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string pvCondicion2, string pvCondicion3, string pvCondicion4, string pvCondicion5, string RutasSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis, string Presupuesto, string promocion)
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
            sConsulta.AppendLine("SET LANGUAGE Spanish ");
            sConsulta.AppendLine("IF (SELECT object_id('tempdb..#Tmp_Trp')) IS NOT NULL DROP TABLE #Tmp_Trp ");
            sConsulta.AppendLine("IF (SELECT object_id('tempdb..#Tmp_AgendaVen')) IS NOT NULL DROP TABLE #Tmp_AgendaVen ");
            sConsulta.AppendLine("IF (SELECT object_id('tempdb..#ImpVISCapturadas')) IS NOT NULL DROP TABLE #ImpVISCapturadas ");
            sConsulta.AppendLine("IF (SELECT object_id('tempdb..#ImpVTACapturadas')) IS NOT NULL DROP TABLE #ImpVTACapturadas ");
            sConsulta.AppendLine("IF (SELECT object_id('tempdb..#ImpVISsinVTA')) IS NOT NULL DROP TABLE #ImpVISsinVTA ");
            sConsulta.AppendLine(" ");
            sConsulta.AppendLine("SELECT USU2.Clave AS SUPClave, USU2.Nombre AS SUPNombre, AV.VendedorId, AV.DiaClave, AV.RUTClave, AV.ClienteClave, AV.ClaveCEDI, AV.TipoMotivo, ");
            sConsulta.AppendLine("D.FechaCaptura, ");
            sConsulta.AppendLine("Clie.Clave, Clie.RazonSocial, ");
            sConsulta.AppendLine("ClieDom.Calle INTO #Tmp_AgendaVen ");
            sConsulta.AppendLine("FROM AgendaVendedor AV (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = AV.DiaClave ");
            sConsulta.AppendLine("INNER JOIN Cliente Clie (NOLOCK) ON Clie.ClienteClave = AV.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN SupervisorRuta SUR (NOLOCK) ON SUR.RUTClave = AV.RUTClave ");
            sConsulta.AppendLine("INNER JOIN Usuario USU2 (NOLOCK) ON USU2.USUId = SUR.USUIdSupervisor ");
            sConsulta.AppendLine("INNER JOIN ClienteDomicilio ClieDom (NOLOCK) ON ClieDom.ClienteClave = Clie.ClienteClave AND ClieDom.Tipo = 2 ");
            sConsulta.AppendLine(pvCondicion);

            //Supervisores
            if (Presupuesto.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion1);
            }
            //Rutas
            if (RutasSplit.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion2);
            }

            sConsulta.AppendLine("SELECT trp.TransProdID, trp.Tipo, trp.TipoFase, ");
            sConsulta.AppendLine("Vis.VisitaClave, Vis.DiaClave, vis.ClienteClave, Vis.RUTClave, ");
            sConsulta.AppendLine("D.FechaCaptura INTO #Tmp_Trp ");
            sConsulta.AppendLine("FROM TransProd Trp (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Visita Vis (NOLOCK) ON Vis.VisitaClave = trp.VisitaClave ");
            sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = vis.DiaClave ");
            sConsulta.AppendLine("INNER JOIN SupervisorRuta SUR (NOLOCK) ON SUR.RUTClave = VIS.RUTClave ");
            sConsulta.AppendLine("INNER JOIN Usuario USU2 (NOLOCK) ON USU2.USUId = SUR.USUIdSupervisor ");
            sConsulta.AppendLine(pvCondicion);

            //Supervisores
            if (Presupuesto.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion1);
            }
            //Rutas
            if (RutasSplit.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion3);
            }

            sConsulta.AppendLine("SELECT USU2.Clave AS SUPClave, USU2.Nombre AS SUPNombre, ");
            sConsulta.AppendLine("AV.ClaveCEDI AS CEDIS, ");
            sConsulta.AppendLine("Rut.RUTClave AS Ruta, ");
            sConsulta.AppendLine("datename(dw, D.FechaCaptura) AS DiaVisita, ");
            sConsulta.AppendLine("clie.Clave AS Cliente, ");
            sConsulta.AppendLine("Clie.RazonSocial AS Nombre, ");
            sConsulta.AppendLine("Cliedom.Calle AS Direccion, ");
            sConsulta.AppendLine("ISNULL(VAVDESC.Descripcion, 'SIN VENTA') AS Motivo, ");
            sConsulta.AppendLine("1 AS ClientesVenta, 0 AS ClientesVisita ");
            sConsulta.AppendLine(", (SELECT DISTINCT Ven.VendedorID FROM Vendedor Ven (NOLOCK) INNER JOIN Usuario Usu (NOLOCK) ON Usu.USUId = Ven.USUId WHERE Ven.VendedorID = AV.VendedorID) AS IdVendedor, ");
            sConsulta.AppendLine("(SELECT DISTINCT Usu.Nombre FROM Vendedor Ven (NOLOCK) INNER JOIN Usuario Usu (NOLOCK) ON Usu.USUId = Ven.USUId WHERE Ven.VendedorID = AV.VendedorID) AS UsuVenNom, ");
            sConsulta.AppendLine("(SELECT DISTINCT Alm.Nombre FROM Almacen Alm (NOLOCK) WHERE Alm.AlmacenID = AV.ClaveCedi) AS AlmacenNom ");
            sConsulta.AppendLine("INTO #ImpVISCapturadas ");
            sConsulta.AppendLine("FROM ImproductividadVenta impvta (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Visita vis (NOLOCK) ON impvta.VisitaClave = vis.VisitaClave AND impvta.DiaClave = vis.DiaClave ");
            sConsulta.AppendLine("INNER JOIN Ruta Rut (NOLOCK) ON Rut.RUTClave = vis.RUTClave ");
            sConsulta.AppendLine("INNER JOIN Cliente Clie (NOLOCK) ON Clie.ClienteClave = vis.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN ClienteDomicilio Cliedom (NOLOCK) ON Cliedom.ClienteClave = clie.ClienteClave AND Cliedom.Tipo = 2 ");
            sConsulta.AppendLine("INNER JOIN VAVDescripcion VAVDesc (NOLOCK) ON VAVDesc.VAVClave = impvta.TipoMotivo AND Vavdesc.VARCodigo = 'MOTIMPRO' AND VAVDesc.VADTipoLenguaje = (SELECT dbo.FNObtenerLenguaje()) ");
            sConsulta.AppendLine("INNER JOIN Dia d ON d.DiaClave (NOLOCK) = vis.DiaClave ");
            sConsulta.AppendLine("INNER JOIN AgendaVendedor AV (NOLOCK) ON AV.DiaClave = VIS.DiaClave AND AV.VendedorId = VIS.VendedorID AND AV.RUTClave = VIS.RUTClave AND AV.ClienteClave = VIS.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN SupervisorRuta SUR (NOLOCK) ON SUR.RUTClave = AV.RUTClave ");
            sConsulta.AppendLine("INNER JOIN Usuario USU2 (NOLOCK) ON USU2.USUId = SUR.USUIdSupervisor ");
            sConsulta.AppendLine(pvCondicion);

            //Supervisores
            if (Presupuesto.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion1);
            }
            //Rutas
            if (RutasSplit.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion4);
            }

            sConsulta.AppendLine("SELECT DISTINCT USU2.Clave AS SUPClave, USU2.Nombre AS SUPNombre, AV.ClaveCEDI AS CEDIS, ");
            sConsulta.AppendLine("Rut.RUTClave AS Ruta, ");
            sConsulta.AppendLine("datename(dw, D.FechaCaptura) AS DiaVisita, ");
            sConsulta.AppendLine("clie.Clave AS Cliente, ");
            sConsulta.AppendLine("Clie.RazonSocial AS Nombre, ");
            sConsulta.AppendLine("Cliedom.Calle AS Direccion, ");
            sConsulta.AppendLine("ISNULL(VAVDESC.Descripcion, 'SIN VISITA') AS Motivo, ");
            sConsulta.AppendLine("0 AS ClientesVenta, 1 AS ClientesVisita ");
            sConsulta.AppendLine(", (SELECT DISTINCT Ven.VendedorID FROM Vendedor Ven (NOLOCK) INNER JOIN Usuario Usu (NOLOCK) ON Usu.USUId = Ven.USUId WHERE Ven.VendedorID = AV.VendedorID) AS IdVendedor, ");
            sConsulta.AppendLine("(SELECT DISTINCT Usu.Nombre FROM Vendedor Ven (NOLOCK) INNER JOIN Usuario Usu (NOLOCK) ON Usu.USUId = Ven.USUId WHERE Ven.VendedorID = AV.VendedorID) AS UsuVenNom, ");
            sConsulta.AppendLine("(SELECT DISTINCT Alm.Nombre FROM Almacen Alm (NOLOCK) WHERE Alm.AlmacenID = AV.ClaveCedi) AS AlmacenNom ");
            sConsulta.AppendLine("INTO #ImpVTACapturadas ");
            sConsulta.AppendLine("FROM AgendaVendedor AV (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = AV.DiaClave ");
            sConsulta.AppendLine("INNER JOIN cliente Clie (NOLOCK) ON Clie.ClienteClave = AV.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN ClienteDomicilio ClieDom (NOLOCK) ON ClieDom.ClienteClave = Clie.ClienteClave AND ClieDom.Tipo = 2 ");
            sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AV.RUTClave = RUT.RUTClave ");
            sConsulta.AppendLine("INNER JOIN SupervisorRuta SUR (NOLOCK) ON SUR.RUTClave = AV.RUTClave ");
            sConsulta.AppendLine("INNER JOIN Usuario USU2 (NOLOCK) ON USU2.USUId = SUR.USUIdSupervisor ");
            sConsulta.AppendLine("LEFT JOIN VAVDescripcion VAVDesc (NOLOCK) ON VAVDesc.VAVClave = AV.TipoMotivo AND Vavdesc.VARCodigo = 'MOTIMPRO' AND VAVDesc.VADTipoLenguaje = (SELECT dbo.FNObtenerLenguaje()) ");
            sConsulta.AppendLine(pvCondicion);

            //Supervisores
            if (Presupuesto.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion1);
            }
            //Rutas
            if (RutasSplit.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion4);
            }

            sConsulta.AppendLine("SELECT DISTINCT USU2.Clave AS SUPClave, USU2.Nombre AS SUPNombre, AV.ClaveCEDI AS CEDIS, ");
            sConsulta.AppendLine("Rut.RUTClave AS Ruta, ");
            sConsulta.AppendLine("datename(dw, D.FechaCaptura) AS DiaVisita, ");
            sConsulta.AppendLine("clie.Clave AS Cliente, ");
            sConsulta.AppendLine("Clie.RazonSocial AS Nombre, ");
            sConsulta.AppendLine("Cliedom.Calle AS Direccion, ");
            sConsulta.AppendLine("ISNULL(VAVDESC.Descripcion, 'SIN VISITA') AS Motivo, ");
            sConsulta.AppendLine("0 AS ClientesVenta, 1 AS ClientesVisita ");
            sConsulta.AppendLine(", (SELECT DISTINCT Ven.VendedorID FROM Vendedor Ven (NOLOCK) INNER JOIN Usuario Usu (NOLOCK) ON Usu.USUId = Ven.USUId WHERE Ven.VendedorID = AV.VendedorID) AS IdVendedor, ");
            sConsulta.AppendLine("(SELECT DISTINCT Usu.Nombre FROM Vendedor Ven (NOLOCK) INNER JOIN Usuario Usu (NOLOCK) ON Usu.USUId = Ven.USUId WHERE Ven.VendedorID = AV.VendedorID) AS UsuVenNom, ");
            sConsulta.AppendLine("(SELECT DISTINCT Alm.Nombre FROM Almacen Alm (NOLOCK) WHERE Alm.AlmacenID = AV.ClaveCedi) AS AlmacenNom ");
            sConsulta.AppendLine("INTO #ImpVISsinVTA ");
            sConsulta.AppendLine("FROM AgendaVendedor AV (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = AV.DiaClave ");
            sConsulta.AppendLine("INNER JOIN cliente Clie (NOLOCK) ON Clie.ClienteClave = AV.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN ClienteDomicilio ClieDom (NOLOCK) ON ClieDom.ClienteClave = Clie.ClienteClave AND ClieDom.Tipo = 2 ");
            sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AV.RUTClave = RUT.RUTClave ");
            sConsulta.AppendLine("INNER JOIN SupervisorRuta SUR (NOLOCK) ON SUR.RUTClave = AV.RUTClave ");
            sConsulta.AppendLine("INNER JOIN Usuario USU2 (NOLOCK) ON USU2.USUId = SUR.USUIdSupervisor ");
            sConsulta.AppendLine("LEFT JOIN VAVDescripcion VAVDesc (NOLOCK) ON VAVDesc.VAVClave = AV.TipoMotivo AND Vavdesc.VARCodigo = 'MOTIMPRO' AND VAVDesc.VADTipoLenguaje = (SELECT dbo.FNObtenerLenguaje()) ");
            sConsulta.AppendLine("WHERE AV.TipoMotivo IS NULL AND ");
            sConsulta.AppendLine("(Clie.ClienteClave IN (SELECT agevt.clienteclave FROM #Tmp_AgendaVen AgevT ");
            sConsulta.AppendLine("LEFT JOIN Visita Vis (NOLOCK) ON Vis.DiaClave = AgevT.DiaClave AND Vis.ClienteClave = AgevT.ClienteClave AND Vis.VendedorID = AgevT.VendedorID AND Vis.RUTClave = AgevT.RUTclave ");
            sConsulta.AppendLine("LEFT JOIN #Tmp_trp trpT ON trpT.VisitaClave = vis.VisitaClave ");
            sConsulta.AppendLine("WHERE trpT.clienteclave IS NULL) ");
            sConsulta.AppendLine("AND (Clie.ClienteClave NOT IN (SELECT ImpViscap.Cliente FROM #ImpVISCapturadas ImpVIScap) AND ");
            sConsulta.AppendLine("Clie.ClienteClave NOT IN (SELECT ImpVTAcap.Cliente FROM #ImpVTACapturadas ImpVTAcap))) ");
            sConsulta.AppendLine(pvCondicion5);

            //Supervisores
            if (Presupuesto.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion1);
            }
            //Rutas
            if (RutasSplit.Count() > 0)
            {
                sConsulta.AppendLine(pvCondicion4);
            }

            sConsulta.AppendLine("SELECT * FROM #ImpVISCapturadas ");
            sConsulta.AppendLine("UNION ");
            sConsulta.AppendLine("SELECT * FROM #ImpVTACapturadas ");
            sConsulta.AppendLine("UNION ");
            sConsulta.AppendLine("SELECT * FROM #ImpVISsinVTA ");
            sConsulta.AppendLine("ORDER BY SUPClave, Ruta, Cliente ");

            QueryString = "";
            QueryString = sConsulta.ToString();

            List<ReclientesVV> clientesVV = Connection.Query<ReclientesVV>(QueryString, null, null, true, 600).ToList();
            if (clientesVV.Count != 0)
            {
                var a1 = clientesVV.Sum(c => c.ClientesVenta);
                var a2 = clientesVV.Sum(c => c.ClientesVisita);
                InformeClientesVisitaVenta report = new InformeClientesVisitaVenta();
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;

                report.fechaf.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.fecha.Text = DateTime.Now.ToString();
                report.ruta.Text = RutasSplit;

                //CEDI
                report.centro.Text = Cedis + '-' + nombreCedis;
                report.cven.Text = a1.ToString();
                report.cvis.Text = a2.ToString();
                report.DataSource = clientesVV;

                report.subid.DataBindings.Add("Text", null, "SUPClave");
                report.subnom.DataBindings.Add("Text", null, "SUPNombre");
                report.venid.DataBindings.Add("Text", null, "IdVendedor");
                report.venom.DataBindings.Add("Text", null, "UsuVenNom");
                report.rut.DataBindings.Add("Text", null, "Ruta");

                report.x1.DataBindings.Add("Text", null, "CEDIS");
                report.x2.DataBindings.Add("Text", null, "Ruta");
                report.x3.DataBindings.Add("Text", null, "DiaVisita");
                report.x4.DataBindings.Add("Text", null, "Cliente");
                report.x5.DataBindings.Add("Text", null, "Nombre");
                report.x6.DataBindings.Add("Text", null, "Direccion");
                report.x7.DataBindings.Add("Text", null, "Motivo");

                return report;
            }
            else
            {
                return null;
            }
        }
    }

    class ReclientesVV
    {
        public String SUPClave { get; set; }
        public String SUPNombre { get; set; }
        public String CEDIS { get; set; }
        public String Ruta { get; set; }
        public String DiaVisita { get; set; }
        public String Cliente { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Motivo { get; set; }
        public int ClientesVenta { get; set; }
        public int ClientesVisita { get; set; }
        public String IdVendedor { get; set; }
        public String UsuVenNom { get; set; }
        public String AlmacenNom { get; set; }
    }
}