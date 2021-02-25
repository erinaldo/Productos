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
    public class DevolucionesCambiosXCiente
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private DateTime fInicio;
        private DateTime fFin;
        ReporteDevolucionesCambiosXCliente report = new ReporteDevolucionesCambiosXCliente();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string CEDIS, string EstatusFecha, string FechaInicial, string FechaFinal, string Rutas, string Clientes, string Productos, string EsquemasProductos)
        {
            try
            {
                ReportGetCondition filter = new ReportGetCondition();

                //Repor

                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;
                report.cedis.Text = NombreCEDIS;
                report.rutas.Text = (Rutas == "" ? "Todos las Rutas" : Rutas);
                report.segmentos.Text = (EsquemasProductos == "" ? "Todos los Esquemas de Productos" : EsquemasProductos);
                report.productos.Text = (Productos == "" ? "Todos los Productos" : Productos);
                report.clientes.Text = (Clientes == "" ? "Todos los Clientes" : Clientes);
                FechaInicial = this.fInicio.Date.ToShortDateString();
                FechaFinal = this.fFin.Date.ToShortDateString();
                report.fechas.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);

                
                Rutas = (Rutas == "" ? "null" : "'" + Rutas + "'");
                EsquemasProductos = (EsquemasProductos == "" ? "null" : "'" + EsquemasProductos + "'");
                Productos = (Productos == "" ? "null" : "'" + Productos + "'");
                Clientes = (Clientes == "" ? "null" : "'" + Clientes + "'");
                CEDIS = (CEDIS == "" ? "null" : "'" + CEDIS + "'");
                fInicio = DateTime.Parse(FechaInicial);
                FechaInicial = fInicio.Date.ToString("yyyy-MM-dd");
                FechaInicial = (FechaInicial == "" ? "null" : "'" + FechaInicial + "'");
                fFin = DateTime.Parse(FechaFinal);
                FechaFinal = fFin.Date.ToString("yyyy-MM-dd");
                bool pvConversionKg = Connection.Query<int>("SELECT TOP 1 ConversionKg FROM ConHist (NOLOCK) ORDER BY MFechaHora DESC", null, null, true, 600).FirstOrDefault() == 1;

                StringBuilder Consulta = new StringBuilder();
                Consulta.AppendLine("SET ANSI_WARNINGS OFF ");
                Consulta.AppendLine("SELECT ALN.Clave + ' ' + ALN.Nombre AS CEDI, VIS.RUTClave, CONVERT(VARCHAR(10), TRP.FechaHoraAlta, 103) AS FechaHoraAlta, TRP.FechaHoraAlta AS Orden, CLI.Clave AS ClienteClave, CLI.RazonSocial + ' - ' + CLI.NombreCorto AS RazonSocial, TPD.ProductoClave, ");
                Consulta.AppendLine("PRO.Nombre AS ProductoNombre, VAD.Descripcion AS Unidad, PRD.Factor, PPV.Precio, ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 9 THEN VAD2.Descripcion ELSE '' END AS MotivoCambio, ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN VAD2.Descripcion ELSE '' END AS MotivoDevolucion, ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN SUM(TPD.Cantidad) ELSE 0 END 'CantidadDevuelta', ");
                if (pvConversionKg)
                    Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN SUM(TPD.Cantidad * PRU.KgLts) ELSE 0 END 'KgLtCantidadDevuelta', ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN SUM(TPD.Cantidad * PPV.Precio) ELSE 0 END 'ImporteDevuelto', ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 9 THEN SUM(TPD.Cantidad) ELSE 0 END 'CantidadCambiada', ");
                if (pvConversionKg)
                    Consulta.AppendLine("CASE TRP.Tipo WHEN 9 THEN SUM(TPD.Cantidad * PRU.KgLts) ELSE 0 END 'KgLtCantidadCambiada', ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 9 THEN SUM(TPD.Cantidad * PPV.Precio) ELSE 0 END 'ImporteCambiado', ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN SUM(TPD.Cantidad * PRD.Factor) ELSE 0 END 'UnidadesDevueltas', ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 9 THEN SUM(TPD.Cantidad * PRD.Factor) ELSE 0 END 'UnidadesCambiadas' ");
                Consulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                Consulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON TRP.DiaClave = D.DiaClave ");
                Consulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                Consulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave ");
                Consulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TPD.TransProdID = TRP.TransProdID ");
                Consulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRO.ProductoClave = TPD.ProductoClave ");
                Consulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRD.ProductoClave = PRO.ProductoClave AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                if (pvConversionKg)
                    Consulta.AppendLine("INNER JOIN ProductoUnidad PRU (NOLOCK) ON PRU.ProductoClave = PRD.ProductoClave AND PRU.PRUTipoUnidad = PRD.PRUTipoUnidad ");
                Consulta.AppendLine("INNER JOIN VAVDescripcion VAD (NOLOCK) ON VAD.VAVClave = TPD.TipoUnidad AND VAD.VARCodigo = 'UNIDADV' AND VAD.VADTipoLenguaje = 'EM' ");
                Consulta.AppendLine("INNER JOIN VAVDescripcion VAD2 (NOLOCK) ON VAD2.VAVClave = ISNULL(TPD.TipoMotivo, TRP.TipoMotivo) AND VAD2.VARCodigo = 'TRPMOT' AND VAD2.VADTipoLenguaje = 'EM' ");
                Consulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorID = VEN.VendedorID ");
                Consulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ON TRP.DiaClave = AGV.DiaClave AND VEN.VendedorId = AGV.VendedorId ");
                Consulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                Consulta.AppendLine("INNER JOIN PrecioProductoVig PPV (NOLOCK) ON PPV.ProductoClave = TPD.ProductoClave AND PPV.PRUTipoUnidad = TPD.TipoUnidad AND TRP.FechaHoraAlta >= PPV.PPVFechaInicio AND TRP.FechaHoraAlta <= PPV.FechaFin ");
                Consulta.AppendLine("AND PPV.PrecioClave = (SELECT TOP 1 PE.PrecioClave ");
                Consulta.AppendLine("FROM PrecioClienteEsquema PE (NOLOCK) ");
                Consulta.AppendLine("WHERE PE.Esquemaid IN (SELECT EsquemaId FROM ClienteEsquema (NOLOCK) WHERE ClienteClave = CLI.ClienteClave) ");
                Consulta.AppendLine("AND PE.ModuloMovDetalleClave IN ( ");
                Consulta.AppendLine("SELECT ModuloMovDetalleClave FROM ModuloMovDetalle (NOLOCK) WHERE TipoIndice = 9 AND TipoTransProd = 1 AND TipoEstado = 1)) ");
                Consulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON Vis.RUTClave = RUT.RUTClave ");
                Consulta.AppendLine("INNER JOIN ProductoEsquema PESQ (NOLOCK) ON PRO.ProductoClave = PESQ.ProductoClave ");
                Consulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON PESQ.EsquemaID = ESQ.EsquemaID ");
                Consulta.AppendLine("WHERE (TRP.Tipo = 3 OR (TRP.Tipo = 9 AND TRP.FacturaID IS NOT NULL)) ");
                Consulta.AppendLine("AND ((D.FechaCaptura BETWEEN " + FechaInicial + " AND '" + FechaFinal + "') OR " + FechaInicial + " IS NULL) ");
                Consulta.AppendLine("AND ((ALN.AlmacenID = " + CEDIS + ") OR " + CEDIS + " IS NULL) ");
                Consulta.AppendLine("AND ((CLI.ClienteClave IN (SELECT Datos FROM FNSplit(" + Clientes + ", ','))) OR " + Clientes + " IS NULL) ");
                Consulta.AppendLine("AND ((RUT.RUTClave IN (SELECT Datos FROM FNSplit(" + Rutas + ", ','))) OR " + Rutas + " IS NULL) ");
                Consulta.AppendLine("AND ((PRO.ProductoClave IN (SELECT Datos FROM FNSplit(" + Productos + ", ','))) OR " + Productos + " IS NULL) ");
                Consulta.AppendLine("AND ((PRO.ProductoClave IN (SELECT DISTINCT ESQ.ProductoClave FROM ProductoEsquema ESQ (NOLOCK) WHERE ESQ.EsquemaID IN (SELECT Datos FROM FNSplit(" + EsquemasProductos + ", ',')))) OR " + EsquemasProductos + " IS NULL) ");

                if (pvConversionKg)
                    Consulta.AppendLine("GROUP BY ALN.Clave + ' ' + ALN.Nombre, VIS.RUTClave, TRP.FechaHoraAlta, CLI.Clave, CLI.RazonSocial + ' - ' + CLI.NombreCorto, TPD.ProductoClave, PRO.Nombre, VAD.Descripcion, VAD2.Descripcion, PRD.Factor, PPV.Precio, TRP.Tipo, PRU.KgLts ");
                else
                    Consulta.AppendLine("GROUP BY ALN.Clave + ' ' + ALN.Nombre, VIS.RUTClave, TRP.FechaHoraAlta, CLI.Clave, CLI.RazonSocial + ' - ' + CLI.NombreCorto, TPD.ProductoClave, PRO.Nombre, VAD.Descripcion, VAD2.Descripcion, PRD.Factor, PPV.Precio, TRP.Tipo ");
                Consulta.AppendLine("ORDER BY Orden ASC ");

                QueryString = "";
                QueryString = Consulta.ToString();

                List<DevCamClientes> DevCam = Connection.Query<DevCamClientes>(QueryString, null, null, true, 600).ToList();

                var SubDevCam = (from d in DevCam
                                 select d).ToList();
                List<DevCamClientes> DC = new List<DevCamClientes>();

                var Cediss = (from gr in SubDevCam group gr by new { gr.CEDI } into grupo orderby grupo.FirstOrDefault().CEDI ascending select grupo);
                foreach (var gCedi in Cediss)
                {
                    var Fecha = (from gr in gCedi group gr by new { gr.FechaHoraAlta } into grupo select grupo);
                    foreach (var gFecha in Fecha)
                    {
                        var Ruta = (from gr in gFecha group gr by new { gr.RUTClave } into grupo orderby grupo.FirstOrDefault().RUTClave ascending select grupo);
                        foreach (var gRuta in Ruta)
                        {
                            var Cliente = (from gr in gRuta group gr by new { gr.ClienteClave } into grupo orderby grupo.FirstOrDefault().ClienteClave ascending select grupo);
                            foreach (var gCliente in Cliente)
                            {
                                foreach (var objetoAgrupado in gCliente)
                                {
                                    DC.Add(new DevCamClientes
                                    {
                                        CEDI = objetoAgrupado.CEDI,
                                        RUTClave = objetoAgrupado.RUTClave,
                                        FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                                        Orden = objetoAgrupado.Orden,
                                        ClienteClave = objetoAgrupado.ClienteClave,
                                        RazonSocial = objetoAgrupado.ClienteClave + " - " + objetoAgrupado.RazonSocial,
                                        ProductoClave = objetoAgrupado.ProductoClave,
                                        ProductoNombre = objetoAgrupado.ProductoNombre,
                                        Unidad = objetoAgrupado.Unidad,
                                        Factor = objetoAgrupado.Factor,
                                        Precio = objetoAgrupado.Precio,
                                        MotivoCambio = objetoAgrupado.MotivoCambio,
                                        MotivoDevolucion = objetoAgrupado.MotivoDevolucion,
                                        CantidadDevuelta = objetoAgrupado.CantidadDevuelta,
                                        KgLtCantidadDevuelta = objetoAgrupado.KgLtCantidadDevuelta,
                                        ImporteDevuelto = objetoAgrupado.ImporteDevuelto,
                                        CantidadCambiada = objetoAgrupado.CantidadCambiada,
                                        KgLtCantidadCambiada = objetoAgrupado.KgLtCantidadCambiada,
                                        ImporteCambiado = objetoAgrupado.ImporteCambiado,
                                        UnidadesDevueltas = objetoAgrupado.UnidadesDevueltas,
                                        UnidadesCambiadas = objetoAgrupado.UnidadesCambiadas
                                    });
                                }
                                DC.Last().TCantidadDevuelta = gCliente.Sum(c => c.CantidadDevuelta);
                                DC.Last().TCantidadCambiada = gCliente.Sum(c => c.CantidadCambiada);
                                DC.Last().TKgLtCantidadDevuelta = gCliente.Sum(c => c.KgLtCantidadDevuelta);
                                DC.Last().TKgLtCantidadCambiada = gCliente.Sum(c => c.KgLtCantidadCambiada);
                                DC.Last().TImporteDevuelto = gCliente.Sum(c => c.ImporteDevuelto);
                                DC.Last().TImporteCambiado = gCliente.Sum(c => c.ImporteCambiado);
                            }
                        }

                    }
                }

                string aux = "";
                string auxC = "";
                foreach (var Item in DC)
                {
                    if (auxC != Item.ClienteClave)
                    {
                        auxC = Item.ClienteClave;
                        aux = Item.ProductoClave;
                    }
                    else
                    {
                        if (aux != Item.ProductoClave)
                        {
                            aux = Item.ProductoClave;
                        }
                        else
                        {
                            Item.ProductoClave = "";
                            Item.ProductoNombre = "";
                        }
                    }
                }

                //Consultas Reporte--------------------------------------------------------------------------------------------------------------------------------------------
                if (DC.Count > 0)
                {
                    report.DataSource = DC;

                    //GroupHeader 4
                    GroupField group4 = new GroupField("CEDI");
                    report.GroupHeader4.GroupFields.Add(group4);
                    report.lCedi.DataBindings.Add("Text", report.DataSource, "CEDI");

                    //GroupHeader 3
                    GroupField group3 = new GroupField("FechaHoraAlta");
                    report.GroupHeader3.GroupFields.Add(group3);
                    report.lFecha.DataBindings.Add("Text", report.DataSource, "FechaHoraAlta");

                    //GroupHeader 2
                    GroupField group2 = new GroupField("RUTClave");
                    report.GroupHeader2.GroupFields.Add(group2);
                    report.lRuta.DataBindings.Add("Text", report.DataSource, "RUTClave");

                    //GroupHeader 1
                    GroupField group1 = new GroupField("ClienteClave");
                    report.GroupHeader1.GroupFields.Add(group1);
                    report.lCliente.DataBindings.Add("Text", report.DataSource, "RazonSocial");

                    //Detalle
                    report.dClave.DataBindings.Add("Text", null, "ProductoClave");
                    report.dProducto.DataBindings.Add("Text", null, "ProductoNombre");
                    report.dUnidad.DataBindings.Add("Text", null, "Unidad");
                    report.dPrecio.DataBindings.Add("Text", null, "Precio", "{0:$0.00}");
                    report.ddCantidad.DataBindings.Add("Text", null, "CantidadDevuelta", "{0:0.00}");
                    report.ddKg.DataBindings.Add("Text", null, "KgLtCantidadDevuelta", "{0:0.000}");
                    report.ddImporte.DataBindings.Add("Text", null, "ImporteDevuelto", "{0:$0.00}");
                    report.ddMotivo.DataBindings.Add("Text", null, "MotivoDevolucion");
                    report.dcCantidad.DataBindings.Add("Text", null, "CantidadCambiada", "{0:0.00}");
                    report.dcKg.DataBindings.Add("Text", null, "KgLtCantidadCambiada", "{0:0.000}");
                    report.dcImporte.DataBindings.Add("Text", null, "ImporteCambiado", "{0:$0.00}");
                    report.dcMotivo.DataBindings.Add("Text", null, "MotivoCambio");

                    //GroupFooter
                    report.ldtCantidad.DataBindings.Add("Text", null, "TCantidadDevuelta", "{0:0.00}");
                    report.ldtKg.DataBindings.Add("Text", null, "TKgLtCantidadDevuelta", "{0:0.000}");
                    report.ldtImporte.DataBindings.Add("Text", null, "TImporteDevuelto", "{0:$0.00}");
                    report.lctCantidad.DataBindings.Add("Text", null, "TCantidadCambiada", "{0:0.00}");
                    report.lctKg.DataBindings.Add("Text", null, "TKgLtCantidadCambiada", "{0:0.000}");
                    report.lctImporte.DataBindings.Add("Text", null, "TImporteCambiado", "{0:$0.00}");

                    if (!pvConversionKg)
                    {
                        report.ldtKg.Text = "";
                        report.lctKg.Text = "";
                        report.ddKg.Visible = false;
                        report.dcKg.Visible = false;
                        report.lcKg.Visible = false;
                        report.ldKg.Visible = false;
                        report.lcNKg.Visible = true;
                        report.ldNKg.Visible = true;
                    }
                    
                    return report;
                }
                else { return null; }
            }
            catch (Exception ex) { return new ReporteDevolucionesCambiosXCliente(); }
        }

    }

    class DevCamClientes
    {
        public string CEDI { get; set; }
        public string RUTClave { get; set; }
        public string FechaHoraAlta { get; set; }
        public DateTime Orden { get; set; }
        public string ClienteClave { get; set; }
        public string RazonSocial { get; set; }
        public string ProductoClave { get; set; }
        public string ProductoNombre { get; set; }
        public string Unidad { get; set; }
        public string Factor { get; set; }
        public Decimal Precio { get; set; }
        public string MotivoCambio { get; set; }
        public string MotivoDevolucion { get; set; }
        public Double CantidadDevuelta { get; set; }
        public Double KgLtCantidadDevuelta { get; set; }
        public Decimal ImporteDevuelto { get; set; }
        public Double CantidadCambiada { get; set; }
        public Double KgLtCantidadCambiada { get; set; }
        public Decimal ImporteCambiado { get; set; }
        public Double UnidadesDevueltas { get; set; }
        public Double UnidadesCambiadas { get; set; }


        //Totales
        public Double TCantidadDevuelta { get; set; }
        public Double TKgLtCantidadDevuelta { get; set; }
        public Decimal TImporteDevuelto { get; set; }
        public Double TCantidadCambiada { get; set; }
        public Double TKgLtCantidadCambiada { get; set; }
        public Decimal TImporteCambiado { get; set; }
        public long TUnidadesDevueltas { get; set; }
        public long TUnidadesCambiadas { get; set; }
    }
}