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
    public class LiquidacionTUC
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string Cedis, string NomCEDI, string StatusDate, string FechaInicial, string FechaFinal, bool detallado, string VendedorID)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();

                FechaInicial = DateTime.Parse(FechaInicial).ToString("s");
                FechaFinal = (StatusDate == "Entre" ? DateTime.Parse(FechaFinal).ToString("s") : FechaInicial);

                //  MOVIMIENTOS DE PRODUCTOS

                #region consultaProductos

                sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteLiquidacionTUC] ");
                sConsulta.AppendLine("@filtroVendedor = '" + VendedorID + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
                sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "', ");
                sConsulta.AppendLine("@noConsulta = 2");
                QueryString = sConsulta.ToString();
                #endregion

                List<LiquidacionTUCProductosMov> Productos = Connection.Query<LiquidacionTUCProductosMov>(QueryString, null, null, true, 600).ToList();
                List<LiquidacionVendedoresModel> Vendedores = Connection.Query<LiquidacionVendedoresModel>(QueryString, null, null, true, 600).ToList();

                #region consultaVtaContado

                sConsulta.Clear();
                sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteLiquidacionTUC] ");
                sConsulta.AppendLine("@filtroVendedor = '" + VendedorID + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
                sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "', ");
                sConsulta.AppendLine("@noConsulta = 3");
                QueryString = sConsulta.ToString();

                #endregion

                List<LiquidacionTUCVtaContadoCredito> VentaContado = Connection.Query<LiquidacionTUCVtaContadoCredito>(QueryString, null, null, true, 600).ToList();

                #region consultaVtaCredito

                sConsulta.Clear();
                sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteLiquidacionTUC] ");
                sConsulta.AppendLine("@filtroVendedor = '" + VendedorID + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
                sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "', ");
                sConsulta.AppendLine("@noConsulta = 4");
                QueryString = sConsulta.ToString();

                #endregion

                List<LiquidacionTUCVtaContadoCredito> VentaCredito = Connection.Query<LiquidacionTUCVtaContadoCredito>(QueryString, null, null, true, 600).ToList();

                #region consultaCobranza
                sConsulta.Clear();
                sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteLiquidacionTUC] ");
                sConsulta.AppendLine("@filtroVendedor = '" + VendedorID + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
                sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "', ");
                sConsulta.AppendLine("@noConsulta = 5");
                QueryString = sConsulta.ToString();

                #endregion

                List<LiquidacionTUCCobranza> Cobranza = Connection.Query<LiquidacionTUCCobranza>(QueryString, null, null, true, 600).ToList();

                #region consultaPreLiquidacion

                sConsulta.Clear();
                sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteLiquidacionTUC] ");
                sConsulta.AppendLine("@filtroVendedor = '" + VendedorID + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
                sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "', ");
                sConsulta.AppendLine("@noConsulta = 6");
                QueryString = sConsulta.ToString();

                #endregion

                List<LiquidacionTUCPreLiquidacion> PreLiquidacion = Connection.Query<LiquidacionTUCPreLiquidacion>(QueryString, null, null, true, 600).ToList();

                var vendedorList = (from V in Vendedores select V).DistinctBy(a => a.VendedorId).ToList();

                //List<LiquidacionVendedoresModel> Ven = new List<LiquidacionVendedoresModel>(vendedorList.Count());

                #region detalleVendedor

                foreach (LiquidacionVendedoresModel vendedor in vendedorList)
                {
                    foreach (LiquidacionTUCProductosMov pro in Productos)
                    {
                        if (pro.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.MovimientoProducto.Add(pro);
                        }
                    }

                    foreach (LiquidacionTUCVtaContadoCredito vc in VentaContado)
                    {
                        if (vc.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.VentaContado.Add(vc);
                        }
                    }

                    foreach (LiquidacionTUCVtaContadoCredito vcr in VentaCredito)
                    {
                        if (vcr.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.VentaCredito.Add(vcr);
                        }
                    }

                    foreach (LiquidacionTUCCobranza cob in Cobranza)
                    {
                        if (cob.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.Cobranza.Add(cob);
                        }
                    }

                    foreach (LiquidacionTUCPreLiquidacion pre in PreLiquidacion)
                    {
                        if (pre.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.PreLiquidacion.Add(pre);
                        }
                    }
                }

                //TOTALES
                foreach (LiquidacionVendedoresModel vendedor in vendedorList)
                {
                    //  MOVIMIENTOS POR PRODUCTOS
                    if (vendedor.MovimientoProducto.Count() > 0)
                    {
                        foreach (LiquidacionTUCProductosMov pro in vendedor.MovimientoProducto)
                        {
                            pro.InvFinal = pro.InvInicial + pro.Recarga + pro.CambioEnt + pro.DevolucionCli - (pro.CambioSal + pro.Merma + pro.Descarga + pro.Venta + pro.Promo);
                        }
                        vendedor.MovimientoProducto.Last().TInvInicial = vendedor.MovimientoProducto.Sum(a => a.InvInicial);
                        vendedor.MovimientoProducto.LastOrDefault().TRecarga = vendedor.MovimientoProducto.Sum(a => a.Recarga);
                        vendedor.MovimientoProducto.LastOrDefault().TCambioEnt = vendedor.MovimientoProducto.Sum(a => a.CambioEnt);
                        vendedor.MovimientoProducto.LastOrDefault().TCambioSal = vendedor.MovimientoProducto.Sum(a => a.CambioSal);
                        vendedor.MovimientoProducto.LastOrDefault().TDevolucionCli = vendedor.MovimientoProducto.Sum(a => a.DevolucionCli);
                        vendedor.MovimientoProducto.LastOrDefault().TMerma = vendedor.MovimientoProducto.Sum(a => a.Merma);
                        vendedor.MovimientoProducto.LastOrDefault().TDescarga = vendedor.MovimientoProducto.Sum(a => a.Descarga);
                        vendedor.MovimientoProducto.LastOrDefault().TVenta = vendedor.MovimientoProducto.Sum(a => a.Venta);
                        vendedor.MovimientoProducto.LastOrDefault().TPromo = vendedor.MovimientoProducto.Sum(a => a.Promo);
                        vendedor.MovimientoProducto.LastOrDefault().TImporte = vendedor.MovimientoProducto.Sum(a => a.Importe);
                        vendedor.MovimientoProducto.LastOrDefault().TInvFinal = vendedor.MovimientoProducto.Sum(a => a.InvFinal);
                    }

                    //  VENTAS CONTADO
                    if (vendedor.VentaContado.Count() > 0)
                    {
                        vendedor.VentaContado.LastOrDefault().TotalImp = vendedor.VentaContado.Where(a => a.TipoFase != 0).Sum(b => Double.Parse(b.Importe));
                    }

                    //  VENTAS CREDITO
                    if (vendedor.VentaCredito.Count() > 0)
                    {
                        vendedor.VentaCredito.LastOrDefault().TotalImp = vendedor.VentaCredito.Where(a => a.TipoFase != 0).Sum(b => Double.Parse(b.Importe));
                    }

                    //  COBRANZA
                    if (vendedor.Cobranza.Count() > 0)
                    {
                        vendedor.Cobranza.LastOrDefault().TotalImp = vendedor.Cobranza.Sum(a => a.Importe);
                    }

                    //  COBRANZA
                    if (vendedor.PreLiquidacion.Count() > 0)
                    {
                        vendedor.PreLiquidacion.LastOrDefault().vtaTotal = vendedor.MovimientoProducto.LastOrDefault().TImporte;
                        vendedor.PreLiquidacion.LastOrDefault().vtaCredito = (vendedor.VentaCredito.Count() > 0 ? vendedor.VentaCredito.LastOrDefault().TotalImp : 0);
                        vendedor.PreLiquidacion.LastOrDefault().vtaContado = vendedor.PreLiquidacion.LastOrDefault().vtaTotal - vendedor.PreLiquidacion.LastOrDefault().vtaCredito;
                        vendedor.PreLiquidacion.LastOrDefault().tPromo = vendedor.MovimientoProducto.LastOrDefault().TPromo;
                        vendedor.PreLiquidacion.LastOrDefault().tDevoluciones = (vendedor.MovimientoProducto.LastOrDefault().TCambioEnt != 0 || vendedor.MovimientoProducto.LastOrDefault().TDevolucionCli != 0) ? 1 : 0;
                        vendedor.PreLiquidacion.LastOrDefault().TLiquidar = vendedor.PreLiquidacion.LastOrDefault().vtaTotal - vendedor.PreLiquidacion.LastOrDefault().vtaCredito + vendedor.PreLiquidacion.LastOrDefault().Cobranza;
                    }
                }

                #endregion

                if (detallado)
                {
                    if (Productos.Count() > 0)
                    {
                        Rpt_Liquidacion report = new Rpt_Liquidacion();
                        report.DataSource = vendedorList;

                        report.Name = NombreReporte + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");

                        #region reporteLiquidacionTUC

                        //PageHeader
                        report.reporte.Text = NombreReporte.ToUpper();


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

                        report.logo.Image = Image.FromStream(LogoEmpresa);
                        report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                        report.L_CEDI.Text = NomCEDI.ToString();
                        report.L_FechaRango.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                        report.L_VendedorClave.Text = VendedorID;

                        #endregion

                        //grouHeaderVendedor
                        GroupField gpoVendedor = new GroupField("VendedorId");
                        report.GroupHeaderVendedor.GroupFields.Add(gpoVendedor);
                        report.L_Gpo_VendedorID.DataBindings.Add("Text", report.DataSource, "VendedorId");
                        report.L_Gpo_VendedorNom.DataBindings.Add("Text", report.DataSource, "VENNombre");

                        //  MOVIMIENTOS DE PRODUCTOS
                        report.MovimientosProductos.DataMember = "MovimientoProducto";

                        report.L_Clave.DataBindings.Add("Text", null, "MovimientoProducto.ProductoClave");
                        report.L_Descripcion.DataBindings.Add("Text", null, "MovimientoProducto.PRONombre");
                        report.L_Unidad.DataBindings.Add("Text", null, "MovimientoProducto.TipoUnidad");
                        report.L_Inv_Inicial.DataBindings.Add("Text", null, "MovimientoProducto.InvInicial");
                        report.L_Recargas.DataBindings.Add("Text", null, "MovimientoProducto.Recarga");
                        report.L_CambiosEnt.DataBindings.Add("Text", null, "MovimientoProducto.CambioEnt");
                        report.L_CambiosSal.DataBindings.Add("Text", null, "MovimientoProducto.CambioSal");
                        report.L_Devoluciones.DataBindings.Add("Text", null, "MovimientoProducto.DevolucionCli");
                        report.L_Merma.DataBindings.Add("Text", null, "MovimientoProducto.Merma");
                        report.L_Descargas.DataBindings.Add("Text", null, "MovimientoProducto.Descarga");
                        report.L_Ventas.DataBindings.Add("Text", null, "MovimientoProducto.Venta");
                        report.L_Promo.DataBindings.Add("Text", null, "MovimientoProducto.Promo");
                        report.L_Importe.DataBindings.Add("Text", null, "MovimientoProducto.Importe", "{0:$#, ###, ##0.00}");
                        report.L_Inv_Final.DataBindings.Add("Text", null, "MovimientoProducto.InvFinal");

                        report.L_TotalInv_Inicial.DataBindings.Add("Text", null, "MovimientoProducto.TInvInicial");
                        report.L_TotalRecargas.DataBindings.Add("Text", null, "MovimientoProducto.TRecarga");
                        report.L_TotalCambioEnt.DataBindings.Add("Text", null, "MovimientoProducto.TCambioEnt");
                        report.L_TotalCambioSal.DataBindings.Add("Text", null, "MovimientoProducto.TCambioSal");
                        report.L_TotalDevoluciones.DataBindings.Add("Text", null, "MovimientoProducto.TDevolucionCli");
                        report.L_TotalMerma.DataBindings.Add("Text", null, "MovimientoProducto.TMerma");
                        report.L_TotalDescargas.DataBindings.Add("Text", null, "MovimientoProducto.TDescarga");
                        report.L_TotalVentas.DataBindings.Add("Text", null, "MovimientoProducto.TVenta");
                        report.L_TotalPromo.DataBindings.Add("Text", null, "MovimientoProducto.TPromo");
                        report.L_TotalImporte.DataBindings.Add("Text", null, "MovimientoProducto.TImporte", "{0:$#, ###, ##0.00}");
                        report.L_TotalInv_Final.DataBindings.Add("Text", null, "MovimientoProducto.TInvFinal");

                        //  VENTAS DE CONTADO
                        report.VentasContado.DataMember = "VentaContado";

                        report.L_Venta1.DataBindings.Add("Text", null, "VentaContado.Folio");
                        report.L_Fecha1.DataBindings.Add("Text", null, "VentaContado.FechaHoraAlta");
                        report.L_Cliente1.DataBindings.Add("Text", null, "VentaContado.Cliente");
                        report.L_Promo1.DataBindings.Add("Text", null, "VentaContado.Promo");
                        report.L_Importe1.DataBindings.Add("Text", null, "VentaContado.Importe", "{0:$#, ###, ##0.00}");

                        report.L_TotalContado1.DataBindings.Add("Text", null, "VentaContado.TotalImp", "{0:$#, ###, ##0.00}");

                        //  VENTAS DE CREDITO
                        report.VentasCredito.DataMember = "VentaCredito";

                        report.L_Venta2.DataBindings.Add("Text", null, "VentaCredito.Folio");
                        report.L_Fecha2.DataBindings.Add("Text", null, "VentaCredito.FechaHoraAlta");
                        report.L_Cliente2.DataBindings.Add("Text", null, "VentaCredito.Cliente");
                        report.L_Promo2.DataBindings.Add("Text", null, "VentaCredito.Promo");
                        report.L_Importe2.DataBindings.Add("Text", null, "VentaCredito.Importe", "{0:$#, ###, ##0.00}");

                        report.L_TotalCredito2.DataBindings.Add("Text", null, "VentaCredito.TotalImp", "{0:$#, ###, ##0.00}");

                        //  COBRANZA
                        report.Cobranza.DataMember = "Cobranza";

                        report.L_ClienteCobranza.DataBindings.Add("Text", null, "Cobranza.Cliente");
                        report.L_VentaCobranza.DataBindings.Add("Text", null, "Cobranza.Folio");
                        report.L_FechaCobranza.DataBindings.Add("Text", null, "Cobranza.FechaHora");
                        report.L_ImporteVtaCobranza.DataBindings.Add("Text", null, "Cobranza.Total", "{0:$#, ###, ##0.00}");
                        report.L_SaldoCobranza.DataBindings.Add("Text", null, "Cobranza.Saldo", "{0:$#, ###, ##0.00}");
                        report.L_FormaPagoCobranza.DataBindings.Add("Text", null, "Cobranza.Descripcion");
                        report.L_ReferenciaCobranza.DataBindings.Add("Text", null, "Cobranza.Referencia");
                        report.L_ImporteCobranza.DataBindings.Add("Text", null, "Cobranza.Importe", "{0:$#, ###, ##0.00}");

                        report.L_TotalCobranza3.DataBindings.Add("Text", null, "Cobranza.TotalImp", "{0:$#, ###, ##0.00}");

                        //  PRE-LIQUIDACION
                        report.PreLiquidacion.DataMember = "PreLiquidacion";

                        report.L_VtaTotalPre.DataBindings.Add("Text", null, "PreLiquidacion.vtaTotal", "{0:$#, ###, ##0.00}");
                        report.L_VtaCreditoPre.DataBindings.Add("Text", null, "PreLiquidacion.vtaCredito", "{0:$#, ###, ##0.00}");
                        report.L_VtaContadoPre.DataBindings.Add("Text", null, "PreLiquidacion.vtaContado", "{0:$#, ###, ##0.00}");
                        report.L_CobranzaPre.DataBindings.Add("Text", null, "PreLiquidacion.Cobranza", "{0:$#, ###, ##0.00}");
                        report.L_PromocionPre.DataBindings.Add("Text", null, "PreLiquidacion.tPromo");
                        report.L_DevolucionesPre.DataBindings.Add("Text", null, "PreLiquidacion.tDevoluciones");
                        report.L_LiquidarPre.DataBindings.Add("Text", null, "PreLiquidacion.TLiquidar", "{0:$#, ###, ##0.00}");

                        return report;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    //  GENERAL
                    if (Productos.Count() > 0)
                    {
                        Rpt_Liquidacion report = new Rpt_Liquidacion();
                        report.DataSource = vendedorList;

                        report.Name = NombreReporte + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");

                        #region reporteLiquidacionTUC

                        //PageHeader
                        report.reporte.Text = NombreReporte.ToUpper();

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

                        report.logo.Image = Image.FromStream(LogoEmpresa);
                        report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                        report.L_CEDI.Text = NomCEDI.ToString();
                        report.L_FechaRango.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                        report.L_VendedorClave.Text = VendedorID;

                        #endregion

                        //grouHeaderVendedor
                        GroupField gpoVendedor = new GroupField("VendedorId");
                        report.GroupHeaderVendedor.GroupFields.Add(gpoVendedor);
                        report.L_Gpo_VendedorID.DataBindings.Add("Text", report.DataSource, "VendedorId");
                        report.L_Gpo_VendedorNom.DataBindings.Add("Text", report.DataSource, "VENNombre");

                        report.MovimientosProductos.Visible = false;
                        report.VentasContado.Visible = false;
                        report.VentasCredito.Visible = false;
                        report.Cobranza.Visible = false;

                        //  PRE-LIQUIDACION
                        report.PreLiquidacion.DataMember = "PreLiquidacion";

                        report.L_VtaTotalPre.DataBindings.Add("Text", null, "PreLiquidacion.vtaTotal", "{0:$#, ###, ##0.00}");
                        report.L_VtaCreditoPre.DataBindings.Add("Text", null, "PreLiquidacion.vtaCredito", "{0:$#, ###, ##0.00}");
                        report.L_VtaContadoPre.DataBindings.Add("Text", null, "PreLiquidacion.vtaContado", "{0:$#, ###, ##0.00}");
                        report.L_CobranzaPre.DataBindings.Add("Text", null, "PreLiquidacion.Cobranza", "{0:$#, ###, ##0.00}");
                        report.L_PromocionPre.DataBindings.Add("Text", null, "PreLiquidacion.tPromo");
                        report.L_DevolucionesPre.DataBindings.Add("Text", null, "PreLiquidacion.tDevoluciones");
                        report.L_LiquidarPre.DataBindings.Add("Text", null, "PreLiquidacion.TLiquidar", "{0:$#, ###, ##0.00}");

                        return report;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    class LiquidacionVendedoresModel
    {
        public string VendedorId { get; set; }
        public string VENNombre { get; set; }

        //Agregado para datamembers
        public List<LiquidacionTUCProductosMov> MovimientoProducto { get; set; }
        public List<LiquidacionTUCVtaContadoCredito> VentaContado { get; set; }
        public List<LiquidacionTUCVtaContadoCredito> VentaCredito { get; set; }
        public List<LiquidacionTUCCobranza> Cobranza { get; set; }
        public List<LiquidacionTUCPreLiquidacion> PreLiquidacion { get; set; } 

        public LiquidacionVendedoresModel()
        {
            MovimientoProducto = new List<LiquidacionTUCProductosMov>();
            VentaContado = new List<LiquidacionTUCVtaContadoCredito>();
            VentaCredito = new List<LiquidacionTUCVtaContadoCredito>();
            Cobranza = new List<LiquidacionTUCCobranza>();
            PreLiquidacion = new List<LiquidacionTUCPreLiquidacion>();
        }
    }

    class LiquidacionTUCProductosMov
    {
        public string ClaveCEDI { get; set; }
        public string ALMNombre { get; set; }
        public string VendedorId { get; set; }
        public string VENNombre { get; set; }
        public string ProductoClave { get; set; }
        public string TipoUnidad { get; set; }
        public string PRONombre { get; set; }
        public int InvInicial { get; set; }
        public long Recarga { get; set; }
        public int CambioEnt { get; set; }
        public int CambioSal { get; set; }
        public int DevolucionCli { get; set; }
        public int Merma { get; set; }
        public long Descarga { get; set; }
        public long Venta { get; set; }
        public int Promo { get; set; }
        public double Importe { get; set; }
        public double ImporteCredito { get; set; }
        public long InvFinal { get; set; }

        //  TOTALES
        public int TInvInicial { get; set; }
        public long TRecarga { get; set; }
        public int TCambioEnt { get; set; }
        public int TCambioSal { get; set; }
        public int TDevolucionCli { get; set; }
        public int TMerma { get; set; }
        public long TDescarga { get; set; }
        public long TVenta { get; set; }
        public int TPromo { get; set; }
        public double TImporte { get; set; }
        public double TImporteCredito { get; set; }
        public long TInvFinal { get; set; }
    }

    class LiquidacionTUCVtaContadoCredito
    {
        public string ClaveCEDI { get; set; }
        public string ALMNombre { get; set; }
        public string VendedorId { get; set; }
        public string VENNombre { get; set; }
        public string Folio { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public string Cliente { get; set; }
        public int Promo { get; set; }
        public string Importe { get; set; }
        public int TipoFase { get; set; }
        public double TotalImp { get; set; }
    }

    class LiquidacionTUCCobranza
    {
        public string VendedorId { get; set; }
        public string Cliente { get; set; }
        public string Folio { get; set; }
        public DateTime FechaHora { get; set; }
        public double Total { get; set; }
        public double Saldo { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public double Importe { get; set; }
        //  TOTALES
        public double TotalImp { get; set; }
    }

    class LiquidacionTUCPreLiquidacion
    {
        public string ClaveCEDI { get; set; }
        public string VendedorId { get; set; }
        public double Cobranza { get; set; }
        //  TOTALES
        public double vtaTotal { get; set; }
        public double vtaCredito { get; set; }
        public double vtaContado { get; set; }
        public long tPromo { get; set; }
        public long tDevoluciones { get; set; }
        public double TLiquidar { get; set; }
        public double CobranzaLiq { get; set; }
    }
}