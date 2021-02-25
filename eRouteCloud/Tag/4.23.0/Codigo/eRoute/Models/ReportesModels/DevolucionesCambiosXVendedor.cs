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
    public class DevolucionesCambiosXVendedor
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private DateTime fInicio;
        private DateTime fFin;
        ReporteDevolucionesCambiosXVendedor report = new ReporteDevolucionesCambiosXVendedor();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string CEDIS, string EstatusFecha, string FechaInicial, string FechaFinal, string Vendedores, string NombreObjeto, string Clientes)
        {
            try
            {
                ReportGetCondition filter = new ReportGetCondition();

                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;

                report.cedis.Text = NombreCEDIS;
                FechaInicial = this.fInicio.Date.ToShortDateString();
                FechaFinal = this.fFin.Date.ToShortDateString();
                report.fechas.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);

                report.vendedor.Text = NombreObjeto;
                report.clientes.Text = (Clientes == "" ? "Todos los Clientes" : Clientes);

                Vendedores = (Vendedores == "" ? "null" : "'" + Vendedores + "'");
                Clientes = (Clientes == "" ? "null" : "'" + Clientes + "'");
                CEDIS = (CEDIS == "" ? "null" : "'" + CEDIS + "'");

                fInicio = DateTime.Parse(FechaInicial);
                FechaInicial = fInicio.Date.ToString("yyyyMMdd");
                FechaInicial = (FechaInicial == "" ? "null" : "'" + FechaInicial + "'");
                fFin = DateTime.Parse(FechaFinal);
                FechaFinal = fFin.Date.ToString("yyyyMMdd");

                StringBuilder Consulta = new StringBuilder();
                Consulta.AppendLine("SET ANSI_WARNINGS OFF ");
                Consulta.AppendLine("SELECT ALN.Clave + ' ' + ALN.Nombre AS CEDI, CONVERT(VARCHAR(10), TRP.FechaHoraAlta, 103) AS FechaHoraAlta, CLI.Clave AS ClienteClave, CLI.RazonSocial + ' - ' + CLI.NombreCorto AS RazonSocial, TPD.ProductoClave,  ");
                Consulta.AppendLine("PRO.Nombre AS ProductoNombre, VAD.Descripcion AS Unidad, PRD.Factor, PPV.Precio, ");
                Consulta.AppendLine("CASE WHEN TRP.Tipo = 9 THEN VAD2.Descripcion ELSE '' END AS MotivoCambio, ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN VAD2.Descripcion ELSE '' END AS MotivoDevolucion, ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN SUM(TPD.Cantidad) ELSE 0 END 'CantidadDevuelta', ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN SUM(TPD.Cantidad * PPV.Precio) ELSE 0 END 'ImporteDevuelto', ");
                Consulta.AppendLine("CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 1 THEN SUM(TPD.Cantidad) ELSE 0 END 'CantidadCambiada', ");
                Consulta.AppendLine("CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 1 THEN SUM(TPD.Cantidad * PPV.Precio) ELSE 0 END 'ImporteCambiado', ");
                Consulta.AppendLine("CASE TRP.Tipo WHEN 3 THEN SUM(TPD.Cantidad * PRD.Factor) ELSE 0 END 'UnidadesDevueltas', ");
                Consulta.AppendLine("CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 1 THEN SUM(TPD.Cantidad * PRD.Factor) ELSE 0 END 'UnidadesCambiadas', ");
                Consulta.AppendLine("CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 2 THEN SUM(TPD.Cantidad) ELSE 0 END 'CantidadCambiadaPor', ");
                Consulta.AppendLine("CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 2 THEN SUM(TPD.Cantidad * PPV.Precio) ELSE 0 END 'ImporteCambiadoPor', ");
                Consulta.AppendLine("CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 2 THEN SUM(TPD.Cantidad * PRD.Factor) ELSE 0 END 'UnidadesCambiadasPor', ");
                Consulta.AppendLine("VEN.VendedorId AS VendedorId, VEN.nombre AS Vendedor ");
                Consulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                Consulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON TRP.DiaClave = D.DiaClave ");
                Consulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
                Consulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave ");
                Consulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TPD.TransProdID = TRP.TransProdID ");
                Consulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRO.ProductoClave = TPD.ProductoClave ");
                Consulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRD.ProductoClave = PRO.ProductoClave AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
                Consulta.AppendLine("INNER JOIN VAVDescripcion VAD (NOLOCK) ON VAD.VAVClave = TPD.TipoUnidad AND VAD.VARCodigo = 'UNIDADV' AND VAD.VADTipoLenguaje = 'EM' ");
                Consulta.AppendLine("INNER JOIN VAVDescripcion VAD2 (NOLOCK) ON VAD2.VAVClave = ISNULL(TPD.TipoMotivo,TRP.TipoMotivo) AND VAD2.VARCodigo = 'TRPMOT' AND VAD2.VADTipoLenguaje = 'EM' ");
                Consulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorID = VEN.VendedorID ");
                Consulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ON TRP.DiaClave = AGV.DiaClave AND VEN.VendedorId = AGV.VendedorId ");
                Consulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                Consulta.AppendLine("INNER JOIN PrecioProductoVig PPV (NOLOCK) ON PPV.ProductoClave = TPD.ProductoClave AND PPV.PRUTipoUnidad = TPD.TipoUnidad AND TRP.FechaHoraAlta >= PPV.PPVFechaInicio AND TRP.FechaHoraAlta <= PPV.FechaFin  ");
                Consulta.AppendLine("AND PPV.PrecioClave = (SELECT TOP 1 PE.PrecioClave  ");
                Consulta.AppendLine("FROM PrecioClienteEsquema PE (NOLOCK)  ");
                Consulta.AppendLine("WHERE PE.EsquemaID IN (SELECT EsquemaID FROM ClienteEsquema (NOLOCK) WHERE ClienteClave = CLI.ClienteClave) ");
                Consulta.AppendLine("AND PE.ModuloMovDetalleClave IN ( ");
                Consulta.AppendLine("SELECT ModuloMovDetalleClave FROM ModuloMovDetalle (NOLOCK) WHERE TipoIndice = 9 AND TipoTransProd = 1 AND TipoEstado = 1)) ");
                Consulta.AppendLine("WHERE ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                Consulta.AppendLine("AND ((D.FechaCaptura BETWEEN " + FechaInicial + " AND '" + FechaFinal + "') OR " + FechaInicial + " IS NULL) ");
                Consulta.AppendLine("AND ((ALN.AlmacenID = (SELECT Datos FROM FNSplit((" + CEDIS + "), ','))) OR " + CEDIS + " IS NULL) ");
                Consulta.AppendLine("AND ((CLI.ClienteClave IN (SELECT Datos FROM FNSplit((" + Clientes + "), ','))) OR " + Clientes + " IS NULL) ");
                Consulta.AppendLine("AND (TRP.Tipo = 3 OR TRP.Tipo = 9) ");
                Consulta.AppendLine("GROUP BY ALN.Clave + ' ' + ALN.Nombre, TRP.FechaHoraAlta, CLI.Clave, CLI.RazonSocial + ' - ' + CLI.NombreCorto, TPD.ProductoClave, PRO.Nombre, VAD.Descripcion, VAD2.Descripcion, PRD.Factor, PPV.Precio, TRP.Tipo, TRP.TipoMovimiento, VEN.VendedorId, VEN.nombre ");
                Consulta.AppendLine("ORDER BY ALN.Clave + ' ' + ALN.Nombre, CLI.Clave, CLI.RazonSocial + ' - ' + CLI.NombreCorto, TipoMovimiento DESC ");

                QueryString = "";
                QueryString = Consulta.ToString();

                List<DevCamVendedor> DevCam = Connection.Query<DevCamVendedor>(QueryString, null, null, true, 600).ToList();

                var SubDevCam = (from d in DevCam
                                 select d).ToList();
                List<DevCamVendedor> DC = new List<DevCamVendedor>();

                var Cediss = (from gr in SubDevCam group gr by new { gr.CEDI } into grupo orderby grupo.FirstOrDefault().CEDI ascending select grupo);
                foreach (var gCedi in Cediss)
                {
                    var Fecha = (from gr in gCedi group gr by new { gr.FechaHoraAlta } into grupo select grupo);
                    foreach (var gFecha in Fecha)
                    {
                        var Vendedor = (from gr in gFecha group gr by new { gr.VendedorId } into grupo orderby grupo.FirstOrDefault().VendedorId ascending select grupo);
                        foreach (var gVendedor in Vendedor)
                        {
                            var Cliente = (from gr in gVendedor group gr by new { gr.ClienteClave } into grupo orderby grupo.FirstOrDefault().ClienteClave ascending select grupo);
                            foreach (var gCliente in Cliente)
                            {
                                foreach (var objetoAgrupado in gCliente)
                                {
                                    DC.Add(new DevCamVendedor
                                    {
                                        CEDI = objetoAgrupado.CEDI,
                                        FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                                        ClienteClave = objetoAgrupado.ClienteClave,
                                        RazonSocial = objetoAgrupado.ClienteClave + " - " + objetoAgrupado.RazonSocial,
                                        Productoclave = objetoAgrupado.Productoclave,
                                        ProductoNombre = objetoAgrupado.ProductoNombre,
                                        ProductoclaveV = objetoAgrupado.Productoclave,
                                        ProductoNombreV = objetoAgrupado.ProductoNombre,
                                        Unidad = objetoAgrupado.Unidad,
                                        Factor = objetoAgrupado.Factor,
                                        Precio = objetoAgrupado.Precio,
                                        MotivoCambio = objetoAgrupado.MotivoCambio,
                                        MotivoDevolucion = objetoAgrupado.MotivoDevolucion,
                                        CantidadDevuelta = objetoAgrupado.CantidadDevuelta,
                                        ImporteDevuelto = objetoAgrupado.ImporteDevuelto,
                                        CantidadCambiada = objetoAgrupado.CantidadCambiada,
                                        ImporteCambiado = objetoAgrupado.ImporteCambiado,
                                        UnidadesDevueltas = objetoAgrupado.UnidadesDevueltas,
                                        UnidadesCambiadas = objetoAgrupado.UnidadesCambiadas,
                                        CantidadCambiadaPor = objetoAgrupado.CantidadCambiadaPor,
                                        ImporteCambiadoPor = objetoAgrupado.ImporteCambiadoPor,
                                        UnidadesCambiadasPor = objetoAgrupado.UnidadesCambiadasPor,
                                        VendedorId = objetoAgrupado.VendedorId,
                                        Vendedor = objetoAgrupado.Vendedor
                                    });
                                }
                                DC.Last().TCantidadDevuelta = gCliente.Sum(c => c.CantidadDevuelta);
                                DC.Last().TCantidadCambiada = gCliente.Sum(c => c.CantidadCambiada);
                                DC.Last().TCantidadCambiadaPor = gCliente.Sum(c => c.CantidadCambiadaPor);
                                DC.Last().TImporteDevuelto = gCliente.Sum(c => c.ImporteDevuelto);
                                DC.Last().TImporteCambiado = gCliente.Sum(c => c.ImporteCambiado);
                                DC.Last().TImporteCambiadoPor = gCliente.Sum(c => c.ImporteCambiadoPor);
                            }
                        }
                    }
                }

                //Subreporte
                List<DevCamVendedor> SC = new List<DevCamVendedor>();

                var SCediss = (from gr in SubDevCam group gr by new { gr.CEDI } into grupo orderby grupo.FirstOrDefault().CEDI ascending select grupo);
                foreach (var gCedi in Cediss)
                {
                    var Fecha = (from gr in gCedi group gr by new { gr.FechaHoraAlta } into grupo select grupo);
                    foreach (var gFecha in Fecha)
                    {
                        var Vendedor = (from gr in gFecha group gr by new { gr.VendedorId } into grupo orderby grupo.FirstOrDefault().VendedorId ascending select grupo);
                        foreach (var gVendedor in Vendedor)
                        {
                            var Producto = (from gr in gVendedor group gr by new { gr.Productoclave } into grupo orderby grupo.FirstOrDefault().Productoclave ascending select grupo);
                            foreach (var gProducto in Producto)
                            {
                                foreach (var objetoAgrupado in gProducto)
                                {
                                    SC.Add(new DevCamVendedor
                                    {
                                        CEDI = objetoAgrupado.CEDI,
                                        FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                                        Productoclave = objetoAgrupado.Productoclave,
                                        ProductoNombre = objetoAgrupado.ProductoNombre,
                                        ProductoclaveV = objetoAgrupado.Productoclave,
                                        ProductoNombreV = objetoAgrupado.ProductoNombre,
                                        Unidad = objetoAgrupado.Unidad,
                                        Factor = objetoAgrupado.Factor,
                                        Precio = objetoAgrupado.Precio,
                                        MotivoCambio = objetoAgrupado.MotivoCambio,
                                        MotivoDevolucion = objetoAgrupado.MotivoDevolucion,
                                        CantidadDevuelta = objetoAgrupado.CantidadDevuelta,
                                        ImporteDevuelto = objetoAgrupado.ImporteDevuelto,
                                        CantidadCambiada = objetoAgrupado.CantidadCambiada,
                                        ImporteCambiado = objetoAgrupado.ImporteCambiado,
                                        UnidadesDevueltas = objetoAgrupado.UnidadesDevueltas,
                                        UnidadesCambiadas = objetoAgrupado.UnidadesCambiadas,
                                        CantidadCambiadaPor = objetoAgrupado.CantidadCambiadaPor,
                                        ImporteCambiadoPor = objetoAgrupado.ImporteCambiadoPor,
                                        UnidadesCambiadasPor = objetoAgrupado.UnidadesCambiadasPor,
                                        VendedorId = objetoAgrupado.VendedorId,
                                        Vendedor = objetoAgrupado.Vendedor
                                    });
                                }
                                SC.Last().PCantidadDevuelta = gProducto.Sum(c => c.CantidadDevuelta);
                                SC.Last().PCantidadCambiada = gProducto.Sum(c => c.CantidadCambiada);
                                SC.Last().PCantidadCambiadaPor = gProducto.Sum(c => c.CantidadCambiadaPor);
                                SC.Last().PImporteDevuelto = gProducto.Sum(c => c.ImporteDevuelto);
                                SC.Last().PImporteCambiado = gProducto.Sum(c => c.ImporteCambiado);
                                SC.Last().PImporteCambiadoPor = gProducto.Sum(c => c.ImporteCambiadoPor);
                            }
                            SC.Last().VCantidadDevuelta = gVendedor.Sum(c => c.CantidadDevuelta);
                            SC.Last().VCantidadCambiada = gVendedor.Sum(c => c.CantidadCambiada);
                            SC.Last().VCantidadCambiadaPor = gVendedor.Sum(c => c.CantidadCambiadaPor);
                            SC.Last().VImporteDevuelto = gVendedor.Sum(c => c.ImporteDevuelto);
                            SC.Last().VImporteCambiado = gVendedor.Sum(c => c.ImporteCambiado);
                            SC.Last().VImporteCambiadoPor = gVendedor.Sum(c => c.ImporteCambiadoPor);
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
                        aux = Item.ProductoclaveV;
                    }
                    else
                    {
                        if (aux != Item.ProductoclaveV)
                        {
                            aux = Item.ProductoclaveV;
                        }
                        else
                        {
                            Item.ProductoclaveV = "";
                            Item.ProductoNombreV = "";
                        }
                    }
                }

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
                    GroupField group2 = new GroupField("VendedorId");
                    report.GroupHeader2.GroupFields.Add(group2);
                    report.lVendedor.DataBindings.Add("Text", report.DataSource, "Vendedor");

                    //GroupHeader 1
                    GroupField group1 = new GroupField("ClienteClave");
                    report.GroupHeader1.GroupFields.Add(group1);
                    report.lCliente.DataBindings.Add("Text", report.DataSource, "RazonSocial");

                    //Detalle
                    report.dClave.DataBindings.Add("Text", null, "ProductoClaveV");
                    report.dProducto.DataBindings.Add("Text", null, "ProductoNombreV");
                    report.dUnidad.DataBindings.Add("Text", null, "Unidad");
                    report.dPrecio.DataBindings.Add("Text", null, "Precio", "{0:$0.00}");
                    report.ddCantidad.DataBindings.Add("Text", null, "CantidadDevuelta", "{0:0.00}");
                    report.ddImporte.DataBindings.Add("Text", null, "ImporteDevuelto", "{0:$0.00}");
                    report.ddMotivo.DataBindings.Add("Text", null, "MotivoDevolucion");
                    report.dcCantidad.DataBindings.Add("Text", null, "CantidadCambiada", "{0:0.00}");
                    report.dcImporte.DataBindings.Add("Text", null, "ImporteCambiado", "{0:$0.00}");
                    report.dcCambio.DataBindings.Add("Text", null, "CantidadCambiadaPor", "{0:0.00}");
                    report.dcCImporte.DataBindings.Add("Text", null, "ImporteCambiadoPor", "{0:$0.00}");
                    report.dcMotivo.DataBindings.Add("Text", null, "MotivoCambio");

                    //GroupFooter
                    report.ldtCantidad.DataBindings.Add("Text", null, "TCantidadDevuelta", "{0:0.00}");
                    report.ldtImporte.DataBindings.Add("Text", null, "TImporteDevuelto", "{0:$0.00}");
                    report.lctCantidad.DataBindings.Add("Text", null, "TCantidadCambiada", "{0:0.00}");
                    report.lctImporte.DataBindings.Add("Text", null, "TImporteCambiado", "{0:$0.00}");
                    report.lctCambio.DataBindings.Add("Text", null, "TCantidadCambiadaPor", "{0:0.00}");
                    report.lctCImporte.DataBindings.Add("Text", null, "TImporteCambiadoPor", "{0:$0.00}");

                    //Consultas Reporte--------------------------------------------------------------------------------------------------------------------------------------------

                    //SubReporte---------------------------------------------------------------------------------------------------------------------------------------------------
                    SubReporteDevCam SubReport = new SubReporteDevCam();
                    SubReport.DataSource = SC;

                    //Parametros
                    SubReport.FilterString = "[FechaHoraAlta] = [Parameters.FechaHoraAlta] && [VendedorId] = [Parameters.VendedorId]";
                    ParameterBinding ParameterBinding1 = new ParameterBinding("FechaHoraAlta", report.DataSource, "FechaHoraAlta");
                    report.xrSubReporte.ParameterBindings.Add(ParameterBinding1);
                    //SubReport.FilterString = "[VendedorId] = [Parameters.VendedorId]";
                    ParameterBinding1 = new ParameterBinding("VendedorId", report.DataSource, "VendedorId");
                    report.xrSubReporte.ParameterBindings.Add(ParameterBinding1);

                    //Detalle
                    //GroupHeader 1
                    GroupField groupV = new GroupField("VendedorId");
                    SubReport.GroupHeader2.GroupFields.Add(groupV);

                    //GroupHeader 1
                    GroupField groupP = new GroupField("VendedorId");
                    SubReport.GroupHeader1.GroupFields.Add(groupP);

                    //GroupFooter
                    SubReport.dClave.DataBindings.Add("Text", null, "ProductoClave");
                    SubReport.dProducto.DataBindings.Add("Text", null, "ProductoNombre");
                    SubReport.dUnidad.DataBindings.Add("Text", null, "Unidad");
                    SubReport.ddCantidad.DataBindings.Add("Text", null, "PCantidadDevuelta", "{0:0.00}");
                    SubReport.ddImporte.DataBindings.Add("Text", null, "PImporteDevuelto", "{0:$0.00}");
                    SubReport.dcCantidad.DataBindings.Add("Text", null, "PCantidadCambiada", "{0:0.00}");
                    SubReport.dcImporte.DataBindings.Add("Text", null, "PImporteCambiado", "{0:$0.00}");
                    SubReport.dcCambio.DataBindings.Add("Text", null, "PCantidadCambiadaPor", "{0:0.00}");
                    SubReport.dcMotivo.DataBindings.Add("Text", null, "PImporteCambiadoPor", "{0:$0.00}");

                    //GroupFooter
                    SubReport.xrLabel11.DataBindings.Add("Text", null, "VCantidadDevuelta", "{0:0.00}");
                    SubReport.xrLabe22.DataBindings.Add("Text", null, "VImporteDevuelto", "{0:$0.00}");
                    SubReport.xrLabel33.DataBindings.Add("Text", null, "VCantidadCambiada", "{0:0.00}");
                    SubReport.xrLabel44.DataBindings.Add("Text", null, "VImporteCambiado", "{0:$0.00}");
                    SubReport.xrLabel55.DataBindings.Add("Text", null, "VCantidadCambiadaPor", "{0:0.00}");
                    SubReport.xrLabel66.DataBindings.Add("Text", null, "VImporteCambiadoPor", "{0:$0.00}");
                    
                    report.xrSubReporte.ReportSource = SubReport;

                    return report;
                }
                else { return null; }
            }
            catch (Exception ex) { return new ReporteDevolucionesCambiosXVendedor(); }
        }
    }

    class DevCamVendedor
    {
        public string CEDI { get; set; }
        public string FechaHoraAlta { get; set; }
        public string ClienteClave { get; set; }
        public string RazonSocial { get; set; }
        public string Productoclave { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoclaveV { get; set; }
        public string ProductoNombreV { get; set; }
        public string Unidad { get; set; }
        public string Factor { get; set; }
        public Decimal Precio { get; set; }
        public string MotivoCambio { get; set; }
        public string MotivoDevolucion { get; set; }
        public Double CantidadDevuelta { get; set; }
        public Decimal ImporteDevuelto { get; set; }
        public Double CantidadCambiada { get; set; }
        public Decimal ImporteCambiado { get; set; }
        public double UnidadesDevueltas { get; set; }
        public double UnidadesCambiadas { get; set; }
        public double CantidadCambiadaPor { get; set; }
        public Decimal ImporteCambiadoPor { get; set; }
        public double UnidadesCambiadasPor { get; set; }
        public string VendedorId { get; set; }
        public string Vendedor { get; set; }

        //Totales Producto
        public double PCantidadDevuelta { get; set; }
        public Decimal PImporteDevuelto { get; set; }
        public double PCantidadCambiada { get; set; }
        public Decimal PImporteCambiado { get; set; }
        public double PCantidadCambiadaPor { get; set; }
        public Decimal PImporteCambiadoPor { get; set; }

        //Totales Cliente
        public double TCantidadDevuelta { get; set; }
        public Decimal TImporteDevuelto { get; set; }
        public double TCantidadCambiada { get; set; }
        public Decimal TImporteCambiado { get; set; }
        public double TCantidadCambiadaPor { get; set; }
        public Decimal TImporteCambiadoPor { get; set; }

        //Totales Vendedor
        public double VCantidadDevuelta { get; set; }
        public Decimal VImporteDevuelto { get; set; }
        public double VCantidadCambiada { get; set; }
        public Decimal VImporteCambiado { get; set; }
        public double VCantidadCambiadaPor { get; set; }
        public Decimal VImporteCambiadoPor { get; set; }
    }
}