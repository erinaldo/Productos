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
    public class CargasDEL
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        CargasDELReport report = new CargasDELReport();
        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string FechaInicial, string FechaFinal, string Cedis, string pvCondicionCEDI, string Lote)
        {
            try
            {
                #region reporte
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas ");
                sConsulta.AppendLine("SELECT CEDI = CASE WHEN TipoFase = 1 THEN (SELECT TOP 1 ClaveCEDI FROM AgendaVendedor AGV (NOLOCK) WHERE AGV.DiaClave = TRP.DiaClave AND VEN.USUId = TRP.MUsuarioID) ELSE TRP.Notas END, TRP.Folio, TipoFase, VAD.Descripcion AS DescripcionFase, ");
                //sConsulta.AppendLine("CONVERT(DATETIME, CONVERT(VARCHAR(20), d.FechaCaptura, 112)) AS FechaHoraAlta, TPD.ProductoClave, TPD.TipoUnidad, VAD2.Descripcion AS TipoUnidadDes, TPD.Cantidad, USU.Clave + ' ' + VEN.Nombre AS Vendedor, LC.Lote, LC.Caducidad INTO #TmpCargas ");
                sConsulta.AppendLine("convert(datetime,TRP.DiaClave, 103) AS FechaHoraAlta, TPD.ProductoClave, TPD.TipoUnidad, VAD2.Descripcion AS TipoUnidadDes, TPD.Cantidad, USU.Clave + ' ' + VEN.Nombre AS Vendedor, LC.Lote, LC.Caducidad INTO #TmpCargas ");
                sConsulta.AppendLine("FROM (SELECT DiaClave, TransProdID, TipoFase, Folio, Tipo, Notas, MUsuarioID, FechaHoraAlta FROM TransProd (NOLOCK) WHERE Tipo = 2) TRP ");
                sConsulta.AppendLine("INNER JOIN (SELECT TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Cantidad FROM TransProdDetalle (NOLOCK)) TPD ON TPD.TransProdID = TRP.TransProdID ");
                sConsulta.AppendLine(" INNER JOIN TPDDatosExtra(NOLOCK)TPE on TPD.TransProdID = TPE.TransProdID and TPE.TransProdDetalleID = TPD.TransProdDetalleID and TPE.Lote = '" +Lote+ "'");
                sConsulta.AppendLine(" INNER JOIN LoteCaducidad(NOLOCK)LC on LC.Lote = TPE.Lote ");
                sConsulta.AppendLine("INNER JOIN (SELECT VAVClave, Descripcion FROM VAVDescripcion (NOLOCK) WHERE VARCodigo = 'TRPFASE' AND VADTipoLenguaje = 'EM' ) VAD ON VAD.VAVClave = TRP.TipoFase ");
                sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD2 (NOLOCK) ON VAD2.VARCodigo = 'UNIDADV' AND VAD2.VAVClave = TPD.TipoUnidad AND VAD2.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("INNER JOIN (SELECT VendedorID, Nombre, UsuId FROM Vendedor (NOLOCK)) VEN ON VEN.UsuID = TRP.MUsuarioID ");
                sConsulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON USU.UsuID = TRP.MUsuarioID ");
                //sConsulta.AppendLine("INNER JOIN Dia d (NOLOCK) ON TRP.DiaClave = d.DiaClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("SELECT ALN.Clave + ' ' + ALN.Nombre AS CEDI, TPD.FechaHoraAlta AS Fecha, TPD.ProductoClave AS Clave, PRO.Nombre AS Producto, ");
                sConsulta.AppendLine("TPD.TipoUnidadDes AS Unidad, TPD.Cantidad, PRD.Factor AS Piezas, TPD.Vendedor, TPD.Folio, TPD.TipoFase, TPD.DescripcionFase, TPD.Lote, convert(varchar,TPD.Caducidad,103) as Caducidad  ");
                sConsulta.AppendLine("FROM #TmpCargas TPD ");
                sConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, Nombre FROM Producto (NOLOCK)) PRO ON TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, PRUTipoUnidad, ProductoDetClave, Factor FROM ProductoDetalle (NOLOCK)) PRD ON PRD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoDetClave = PRO.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = CEDI ");
                sConsulta.AppendLine(pvCondicionCEDI);
                sConsulta.AppendLine("ORDER BY CEDI, Fecha, Vendedor, Folio, TPD.ProductoClave, TipoUnidad ");
                sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas SET NOCOUNT OFF ");

                QueryString = "";

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<CargasDELModel> User = Connection.Query<CargasDELModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();
                if (User.Count() <= 0)
                {
                    return null;
                }

                #region subreporte
                StringBuilder fechaConsulta = new StringBuilder();
                fechaConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                fechaConsulta.AppendLine("SET NOCOUNT ON IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas ");
                //fechaConsulta.AppendLine("SELECT CEDI = CASE WHEN TipoFase = 1 THEN (SELECT TOP 1 ClaveCEDI FROM AgendaVendedor AGV (NOLOCK) WHERE AGV.DiaClave = TRP.DiaClave AND VEN.USUId = TRP.MUsuarioID) ELSE TRP.Notas END, CONVERT(DATETIME, CONVERT(VARCHAR(20), d.FechaCaptura, 112)) AS FechaHoraAlta, TRP.Folio, VAD.Descripcion AS TipoFase, ");
                fechaConsulta.AppendLine("SELECT CEDI = CASE WHEN TipoFase = 1 THEN (SELECT TOP 1 ClaveCEDI FROM AgendaVendedor AGV (NOLOCK) WHERE AGV.DiaClave = TRP.DiaClave AND VEN.USUId = TRP.MUsuarioID) ELSE TRP.Notas END, convert(datetime,TRP.DiaClave, 103) AS FechaHoraAlta, TRP.Folio, VAD.Descripcion AS TipoFase, ");
                fechaConsulta.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, VAD2.Descripcion AS TipoUnidadDes, TPD.Cantidad, LC.Lote, LC.Caducidad INTO #TmpCargas ");
                fechaConsulta.AppendLine("FROM (SELECT DiaClave, TransProdID, TipoFase, Folio, Tipo, Notas, MUsuarioID, FechaHoraAlta FROM TransProd (NOLOCK) WHERE Tipo = 2) TRP ");
                fechaConsulta.AppendLine("INNER JOIN (SELECT TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Cantidad FROM TransProdDetalle (NOLOCK)) TPD ON TPD.TransProdID = TRP.TransProdID ");
                fechaConsulta.AppendLine(" INNER JOIN (SELECT TransProdID, TransProdDetalleID, Lote from TPDDatosExtra (NOLOCK)) TPE ON TPE.TransProdID = TPD.TransProdID AND TPE.TransProdDetalleID = TPD.TransProdDetalleID and TPE.Lote = '" + Lote + "'");
                fechaConsulta.AppendLine(" INNER JOIN (SELECT Lote, Caducidad FROM LoteCaducidad (NOLOCK)) LC ON TPE.Lote = LC.Lote ");
                fechaConsulta.AppendLine("INNER JOIN (SELECT VAVClave, Descripcion FROM VAVDescripcion (NOLOCK) WHERE VARCodigo = 'TRPFASE' AND VADTipoLenguaje = 'EM') VAD ON VAD.VAVClave = TRP.TipoFase ");
                fechaConsulta.AppendLine("INNER JOIN VAVDescripcion VAD2 (NOLOCK) ON VAD2.VARCodigo = 'UNIDADV' AND VAD2.VAVClave = TPD.TipoUnidad AND VAD2.VADTipoLenguaje = 'EM' ");
                fechaConsulta.AppendLine("INNER JOIN (SELECT VendedorID, Nombre, UsuId FROM Vendedor (NOLOCK)) VEN ON VEN.UsuID = TRP.MUsuarioID ");
                //fechaConsulta.AppendLine("INNER JOIN Dia d (NOLOCK) ON TRP.DiaClave = d.DiaClave ");
                fechaConsulta.AppendLine(pvCondicion);
                fechaConsulta.AppendLine("AND TipoFase <> 0 ");

                fechaConsulta.AppendLine("SELECT ALN.Clave + ' ' + ALN.Nombre AS CEDI, TPD.FechaHoraAlta AS Fecha, TPD.ProductoClave AS Clave, PRO.Nombre AS Producto, TPD.TipoUnidadDes AS Unidad, SUM(TPD.Cantidad) AS Cantidad, PRD.Factor AS Piezas, TPD.Lote, convert(varchar,TPD.Caducidad,103)  as Caducidad ");
                fechaConsulta.AppendLine("FROM #TmpCargas TPD ");
                fechaConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, Nombre FROM Producto (NOLOCK)) PRO ON TPD.ProductoClave = PRO.ProductoClave ");
                fechaConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, PRUTipoUnidad, ProductoDetClave, Factor FROM ProductoDetalle (NOLOCK)) PRD ON PRD.ProductoClave = PRO.ProductoClave ");
                fechaConsulta.AppendLine("AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoDetClave = PRO.ProductoClave ");
                fechaConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = CEDI ");
                fechaConsulta.AppendLine(pvCondicionCEDI);
                fechaConsulta.AppendLine("GROUP BY ALN.Clave + ' ' + ALN.Nombre, TPD.FechaHoraAlta, TPD.ProductoClave, PRO.Nombre, TPD.TipoUnidadDes, PRD.Factor, TPD.Lote, TPD.Caducidad ");
                fechaConsulta.AppendLine("ORDER BY CEDI, Fecha, TPD.ProductoClave, Unidad ");
                fechaConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";

                QueryString = fechaConsulta.ToString();

                Connection.Open();
                List<SubCargasDELModel> subConsulta = Connection.Query<SubCargasDELModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                var subLista = (from c in subConsulta
                                select c).ToList();

                var sub = (from gr in subLista group gr by new { gr.CEDI, gr.Fecha } into grupo select grupo);
                List<SubCargasDELModel> subformatlist = new List<SubCargasDELModel>();
                foreach (var grupo in sub)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        subformatlist.Add(new SubCargasDELModel
                        {
                            CEDI = objetoAgrupado.CEDI,
                            Fecha = objetoAgrupado.Fecha,
                            Clave = objetoAgrupado.Clave,
                            Producto = objetoAgrupado.Producto,
                            Unidad = objetoAgrupado.Unidad,
                            Cantidad = objetoAgrupado.Cantidad,
                            Piezas = objetoAgrupado.Piezas * objetoAgrupado.Cantidad,
                            Caducidad = objetoAgrupado.Caducidad,
                            Lote = objetoAgrupado.Lote
                        });
                    }
                    subformatlist.Last().PiezasFecha = grupo.Sum(c => c.Piezas * c.Cantidad);
                }

                TotalFechaDEL subreport = new TotalFechaDEL();

                subreport.DataSource = subformatlist;

                //Parametros
                subreport.FilterString = "[Fecha] = [Parameters.Fecha]";
                ParameterBinding ParameterBinding1 = new ParameterBinding("Fecha", report.DataSource, "Fecha");
                report.xrSubreport1.ParameterBindings.Add(ParameterBinding1);

                //grouheader2
                GroupField groupCedis = new GroupField("Cedi");
                subreport.GroupHeader2.GroupFields.Add(groupCedis);
                //groupheader1
                GroupField groupFechas = new GroupField("Fecha");
                subreport.GroupHeader1.GroupFields.Add(groupFechas);

                //Datos del detail
                subreport.dClave.DataBindings.Add("Text", null, "Clave");
                subreport.dProducto.DataBindings.Add("Text", null, "Producto");
                subreport.dUnidades.DataBindings.Add("Text", null, "Unidad");
                subreport.dCantidad.DataBindings.Add("Text", null, "Cantidad");
                subreport.dLote.DataBindings.Add("Text", null, "Lote");
                subreport.dCaducidad.DataBindings.Add("Text", null, "Caducidad");

                //Datos del groupfooter1
                subreport.fPiezas.DataBindings.Add("Text", null, "PiezasFecha");

                #endregion

                #region ResumenLotes
                StringBuilder consultaResumen = new StringBuilder();


                consultaResumen.AppendLine("SET ANSI_WARNINGS OFF ");
                consultaResumen.AppendLine("SET NOCOUNT ON IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas ");
                consultaResumen.AppendLine("SELECT CEDI = CASE WHEN TipoFase = 1 THEN (SELECT TOP 1 ClaveCEDI FROM AgendaVendedor AGV (NOLOCK) WHERE AGV.DiaClave = TRP.DiaClave AND VEN.USUId = TRP.MUsuarioID) ELSE TRP.Notas END, convert(datetime,TRP.DiaClave, 103) AS FechaHoraAlta, TRP.Folio, VAD.Descripcion AS TipoFase, ");
                consultaResumen.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, VAD2.Descripcion AS TipoUnidadDes, TPD.Cantidad, LC.Lote, LC.Caducidad INTO #TmpCargas ");
                consultaResumen.AppendLine("FROM (SELECT DiaClave, TransProdID, TipoFase, Folio, Tipo, Notas, MUsuarioID, FechaHoraAlta FROM TransProd (NOLOCK) WHERE Tipo = 2) TRP ");
                consultaResumen.AppendLine("INNER JOIN (SELECT TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Cantidad FROM TransProdDetalle (NOLOCK)) TPD ON TPD.TransProdID = TRP.TransProdID ");
                consultaResumen.AppendLine(" INNER JOIN (SELECT TransProdID, TransProdDetalleID, Lote from TPDDatosExtra (NOLOCK)) TPE ON TPE.TransProdID = TPD.TransProdID AND TPE.TransProdDetalleID = TPD.TransProdDetalleID  and TPE.Lote = '" + Lote + "'");
                consultaResumen.AppendLine(" INNER JOIN (SELECT Lote, Caducidad FROM LoteCaducidad (NOLOCK)) LC ON TPE.Lote = LC.Lote ");
                consultaResumen.AppendLine("INNER JOIN (SELECT VAVClave, Descripcion FROM VAVDescripcion (NOLOCK) WHERE VARCodigo = 'TRPFASE' AND VADTipoLenguaje = 'EM') VAD ON VAD.VAVClave = TRP.TipoFase ");
                consultaResumen.AppendLine("INNER JOIN VAVDescripcion VAD2 (NOLOCK) ON VAD2.VARCodigo = 'UNIDADV' AND VAD2.VAVClave = TPD.TipoUnidad AND VAD2.VADTipoLenguaje = 'EM' ");
                consultaResumen.AppendLine("INNER JOIN (SELECT VendedorID, Nombre, UsuId FROM Vendedor (NOLOCK)) VEN ON VEN.UsuID = TRP.MUsuarioID ");
                //consultaResumen.AppendLine("INNER JOIN Dia d (NOLOCK) ON TRP.DiaClave = d.DiaClave ");
                consultaResumen.AppendLine(pvCondicion);
                consultaResumen.AppendLine("AND TipoFase <> 0 ");
                consultaResumen.AppendLine("SELECT TPD.ProductoClave AS Clave, PRO.Nombre AS Producto, ");
                consultaResumen.AppendLine("SUM(TPD.Cantidad) AS Cantidad, TPD.Lote, convert(varchar, TPD.Caducidad, 103) as Caducidad ");
                consultaResumen.AppendLine("FROM #TmpCargas TPD ");
                consultaResumen.AppendLine("INNER JOIN(SELECT ProductoClave, Nombre FROM Producto(NOLOCK)) PRO ON TPD.ProductoClave = PRO.ProductoClave ");
                consultaResumen.AppendLine("GROUP BY TPD.ProductoClave, PRO.Nombre, TPD.Lote, TPD.Caducidad ");
                consultaResumen.AppendLine("ORDER BY TPD.ProductoClave ");
                consultaResumen.AppendLine("IF(SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas SET NOCOUNT OFF ");
                QueryString = "";

                QueryString = consultaResumen.ToString();

                Connection.Open();
                List<ResumenLotesDEL> resumenLotes = Connection.Query<ResumenLotesDEL>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                var subListaResumen = (from c in resumenLotes
                                select c).ToList();
                var res = (from gr in subListaResumen group gr by new { gr.Clave, gr.Lote, gr.Caducidad, gr.Producto } into grupo select grupo);
                List<ResumenLotesDEL> subformatlistResumen = new List<ResumenLotesDEL>();
                foreach (var grupo in res)
                {
                    foreach(var grupo1 in grupo)
                    { 
                        subformatlistResumen.Add(new ResumenLotesDEL
                        {
                            Clave = grupo1.Clave,
                            Producto = grupo1.Producto,
                            Cantidad = grupo1.Cantidad,
                            Caducidad = grupo1.Caducidad,
                            Lote = grupo1.Lote
                        });
                    }
                }

                ResumenLotes subreportResumen = new ResumenLotes();

                subreportResumen.DataSource = subformatlistResumen;


                subreportResumen.dClave.DataBindings.Add("Text", null, "Clave");
                subreportResumen.dProducto.DataBindings.Add("Text", null, "Producto");
                subreportResumen.dCantidad.DataBindings.Add("Text", null, "Cantidad");
                subreportResumen.dLote.DataBindings.Add("Text", null, "Lote");
                subreportResumen.dCaducidad.DataBindings.Add("Text", null, "Caducidad");

                #endregion

                var lista = (from c in User
                             select c).ToList();

                var s = (from gr in lista group gr by new { gr.CEDI, gr.Fecha, gr.DescripcionFase, gr.Vendedor, gr.Folio } into grupo select grupo);
                List<CargasDELModel> formatlist = new List<CargasDELModel>();
                foreach (var grupo in s)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        formatlist.Add(new CargasDELModel
                        {
                            CEDI = objetoAgrupado.CEDI,
                            Fecha = objetoAgrupado.Fecha,
                            Clave = objetoAgrupado.Clave,
                            Producto = objetoAgrupado.Producto,
                            Unidad = objetoAgrupado.Unidad,
                            Cantidad = objetoAgrupado.Cantidad,
                            Piezas = objetoAgrupado.Piezas * objetoAgrupado.Cantidad,
                            Vendedor = objetoAgrupado.Vendedor,
                            Folio = objetoAgrupado.Folio,
                            TipoFase = objetoAgrupado.Folio,
                            DescripcionFase = objetoAgrupado.DescripcionFase,
                            Lote = objetoAgrupado.Lote,
                            Caducidad = objetoAgrupado.Caducidad 
                        });
                    }
                    formatlist.Last().PiezasFolio = grupo.Sum(c => c.Piezas * c.Cantidad);
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
                
                Connection.Open();
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;


                report.DataSource = formatlist;

                //ReportHeader
                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;
                report.headerlabelcedis.Text = Cedis;
                report.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.labelvendedorheader.DataBindings.Add("Text", report.DataSource, "Vendedor");

                //grouheader5
                GroupField groupCedi = new GroupField("CEDI");
                report.GroupHeader5.GroupFields.Add(groupCedi);
                report.cediClave.DataBindings.Add("Text", report.DataSource, "CEDI");
                //grouheader4
                GroupField groupFecha = new GroupField("Fecha");
                report.GroupHeader4.GroupFields.Add(groupFecha);
                report.Fecha.DataBindings.Add("Text", report.DataSource, "Fecha", "{0:dd/MM/yyyy}");
                //grouheader3
                GroupField groupFase = new GroupField("DescripcionFase");
                report.GroupHeader3.GroupFields.Add(groupFase);
                report.Fase.DataBindings.Add("Text", report.DataSource, "DescripcionFase");
                //grouheader2
                GroupField groupVendedor = new GroupField("Vendedor");
                report.GroupHeader2.GroupFields.Add(groupVendedor);
                report.Vendedor.DataBindings.Add("Text", report.DataSource, "Vendedor");
                //groupheader1
                GroupField groupFolio = new GroupField("Folio");
                report.GroupHeader1.GroupFields.Add(groupFolio);
                report.Folio.DataBindings.Add("Text", report.DataSource, "Folio");
                //groupheader6
                GroupField groupLote = new GroupField("Lote");
                report.GroupHeader6.GroupFields.Add(groupLote);
                report.gLote.DataBindings.Add("Text", report.DataSource, "Lote");

                //Datos del detail
                report.dClave.DataBindings.Add("Text", null, "Clave");
                report.dProducto.DataBindings.Add("Text", null, "Producto");
                report.dUnidades.DataBindings.Add("Text", null, "Unidad");
                report.dCantidad.DataBindings.Add("Text", null, "Cantidad");
                report.dLote.DataBindings.Add("Text", null, "Lote");
                report.dCaducidad.DataBindings.Add("Text", null, "Caducidad");

                //Datos del groupfooter1
                report.fPiezas.DataBindings.Add("Text", null, "PiezasFolio");

                if (subLista.Count() > 0)
                {
                    report.xrSubreport1.ReportSource = subreport;
                }
                else
                {
                    report.xrSubreport1.Visible = false;
                }

                report.xrSubreport2.ReportSource = subreportResumen;
                #endregion
                return report;
            }
            catch (Exception ex)
            {
                return new TiemposRutaReport();
            }
        }
    }

    class CargasDELModel
    {
        public String CEDI { get; set; }
        public DateTime Fecha { get; set; }
        public String Clave { get; set; }
        public String Producto { get; set; }
        public String Unidad { get; set; }
        public long Cantidad { get; set; }
        public long Piezas { get; set; }
        public String Vendedor { get; set; }
        public String Folio { get; set; }
        public String TipoFase { get; set; }
        public String DescripcionFase { get; set; }
        public String Lote { get; set; }
        public String Caducidad { get; set; }
        public long PiezasFolio { get; set; }
    }

    class SubCargasDELModel
    {
        public String CEDI { get; set; }
        public DateTime Fecha { get; set; }
        public String Clave { get; set; }
        public String Producto { get; set; }
        public String Unidad { get; set; }
        public long Cantidad { get; set; }
        public long Piezas { get; set; }
        public long PiezasFecha { get; set; }
        public String Lote { get; set; }
        public String Caducidad { get; set; }
    }

    class ResumenLotesDEL
    {
        public String Lote { get; set; }
        public String Caducidad { get; set; }
        public long  Cantidad { get; set; }
        public String Clave { get; set; }
        public String Producto { get; set; }
    }
}