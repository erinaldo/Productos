using System;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Drawing;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class ReporteLiquidacionEfectivoDIV : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private DevExpress.XtraReports.Parameters.Parameter parameterCedis;
    private DevExpress.XtraReports.Parameters.Parameter parameterRutas;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicio;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaFin;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private string Cedis;
    private DateTime FechaInicial;
    private DateTime FechaFinal;
    private string Rutas;
    private string Vendedores;
    private FormattingRule OcultarCantidadesDevoluciones;
    private GroupFooterBand GroupFooter1;
    private SubBand SubBand1;
    private SubBand SubBand2;
    private FormattingRule MostrarCantidadesDevoluciones;

    private string NombreCEDIS;
    private string NombreReporte;
    private string NombreEmpresa;
    private XRLabel Reporte;
    private GroupFooterBand GroupFooter2;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource3;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel2;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel1;
    public XRLabel xrLabel19;
    public XRLabel lblReferencia;
    public XRLabel lblEquipo;
    public XRLabel lblListaPrecio;
    public XRLabel lblAlmacen;
    public XRLabel lblFecha;
    public XRLabel lblVendedor;
    public XRLabel lblCliente;
    public XRLabel lblCuenta;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel16;
    private XRLabel xrLabel13;
    private XRLabel xrLabel10;
    private XRLabel xrLabel5;
    public XRLabel xrLabel4;
    private XRLabel xrLabel3;
    public XRLabel xrLabel23;
    private XRLabel xrLabel27;
    private XRLabel xrLabel29;
    private MemoryStream LogoEmpresa;

    public ReporteLiquidacionEfectivoDIV()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteLiquidacionEfectivoDIV));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.SubBand1 = new DevExpress.XtraReports.UI.SubBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterFechaInicio = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.SubBand2 = new DevExpress.XtraReports.UI.SubBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblReferencia = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEquipo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblListaPrecio = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAlmacen = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lblVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCuenta = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterRutas = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
            this.OcultarCantidadesDevoluciones = new DevExpress.XtraReports.UI.FormattingRule();
            this.MostrarCantidadesDevoluciones = new DevExpress.XtraReports.UI.FormattingRule();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlDataSource3 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel2,
            this.xrLabel8});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Devoluciones", "{0:$0.00}")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(990.2084F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Tickets")});
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(850.2084F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.TotalEfectivo")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(640.6251F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.TotalVenta")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(500.6251F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Cobranza", "{0:$0.00}")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(360.2083F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Credito", "{0:$0.00}")});
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(220.2083F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Contado", "{0:$0.00}")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(70.20833F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.RUTClave")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0.2083302F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Reporte});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 50.00001F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.SubBand1,
            this.SubBand2});
            // 
            // Reporte
            // 
            this.Reporte.Dpi = 100F;
            this.Reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.Reporte.LocationFloat = new DevExpress.Utils.PointFloat(360.2083F, 0F);
            this.Reporte.Name = "Reporte";
            this.Reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Reporte.SizeF = new System.Drawing.SizeF(500F, 40F);
            this.Reporte.StylePriority.UseFont = false;
            this.Reporte.StylePriority.UseTextAlignment = false;
            this.Reporte.Text = "Reporte de Liquidación en Efectivo";
            this.Reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // SubBand1
            // 
            this.SubBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel1});
            this.SubBand1.Dpi = 100F;
            this.SubBand1.HeightF = 30F;
            this.SubBand1.Name = "SubBand1";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.parameterFechaFin, "Text", "{0:dd/MM/yyyy}")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(220F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // parameterFechaFin
            // 
            this.parameterFechaFin.Description = "parameterFechaFin";
            this.parameterFechaFin.Name = "parameterFechaFin";
            this.parameterFechaFin.ValueInfo = "2020-05-18";
            this.parameterFechaFin.Visible = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(210F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(10F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "-";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.parameterFechaInicio, "Text", "{0:dd/MM/yyyy}")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(70F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // parameterFechaInicio
            // 
            this.parameterFechaInicio.Description = "parameterFechaInicio";
            this.parameterFechaInicio.Name = "parameterFechaInicio";
            this.parameterFechaInicio.ValueInfo = "2020-05-16";
            this.parameterFechaInicio.Visible = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.xrLabel1.StylePriority.UseBorderColor = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Fecha: ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // SubBand2
            // 
            this.SubBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.lblReferencia,
            this.lblEquipo,
            this.lblListaPrecio,
            this.lblAlmacen,
            this.lblFecha,
            this.lblVendedor,
            this.lblCliente,
            this.lblCuenta});
            this.SubBand2.Dpi = 100F;
            this.SubBand2.HeightF = 30F;
            this.SubBand2.Name = "SubBand2";
            // 
            // xrLabel19
            // 
            this.xrLabel19.AutoWidth = true;
            this.xrLabel19.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel19.CanGrow = false;
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(990.2084F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(140F, 30F);
            this.xrLabel19.StylePriority.UseBorderColor = false;
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Devoluciones Generales en $";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoWidth = true;
            this.lblReferencia.BorderColor = System.Drawing.Color.Transparent;
            this.lblReferencia.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblReferencia.CanGrow = false;
            this.lblReferencia.Dpi = 100F;
            this.lblReferencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblReferencia.LocationFloat = new DevExpress.Utils.PointFloat(0.2083302F, 0F);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReferencia.SizeF = new System.Drawing.SizeF(70F, 30F);
            this.lblReferencia.StylePriority.UseBorderColor = false;
            this.lblReferencia.StylePriority.UseBorders = false;
            this.lblReferencia.StylePriority.UseFont = false;
            this.lblReferencia.StylePriority.UseTextAlignment = false;
            this.lblReferencia.Text = "Ruta";
            this.lblReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoWidth = true;
            this.lblEquipo.BorderColor = System.Drawing.Color.Transparent;
            this.lblEquipo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblEquipo.CanGrow = false;
            this.lblEquipo.Dpi = 100F;
            this.lblEquipo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblEquipo.LocationFloat = new DevExpress.Utils.PointFloat(780.2084F, 0F);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEquipo.SizeF = new System.Drawing.SizeF(70F, 30F);
            this.lblEquipo.StylePriority.UseBorderColor = false;
            this.lblEquipo.StylePriority.UseBorders = false;
            this.lblEquipo.StylePriority.UseFont = false;
            this.lblEquipo.StylePriority.UseTextAlignment = false;
            this.lblEquipo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblListaPrecio
            // 
            this.lblListaPrecio.AutoWidth = true;
            this.lblListaPrecio.BorderColor = System.Drawing.Color.Transparent;
            this.lblListaPrecio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblListaPrecio.CanGrow = false;
            this.lblListaPrecio.Dpi = 100F;
            this.lblListaPrecio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblListaPrecio.LocationFloat = new DevExpress.Utils.PointFloat(640.2084F, 0F);
            this.lblListaPrecio.Name = "lblListaPrecio";
            this.lblListaPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblListaPrecio.SizeF = new System.Drawing.SizeF(140F, 30F);
            this.lblListaPrecio.StylePriority.UseBorderColor = false;
            this.lblListaPrecio.StylePriority.UseBorders = false;
            this.lblListaPrecio.StylePriority.UseFont = false;
            this.lblListaPrecio.StylePriority.UseTextAlignment = false;
            this.lblListaPrecio.Text = "Total Efectivo";
            this.lblListaPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoWidth = true;
            this.lblAlmacen.BorderColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblAlmacen.CanGrow = false;
            this.lblAlmacen.Dpi = 100F;
            this.lblAlmacen.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlmacen.LocationFloat = new DevExpress.Utils.PointFloat(500.2083F, 0F);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAlmacen.SizeF = new System.Drawing.SizeF(140F, 30F);
            this.lblAlmacen.StylePriority.UseBorderColor = false;
            this.lblAlmacen.StylePriority.UseBorders = false;
            this.lblAlmacen.StylePriority.UseFont = false;
            this.lblAlmacen.StylePriority.UseTextAlignment = false;
            this.lblAlmacen.Text = "Total Venta";
            this.lblAlmacen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoWidth = true;
            this.lblFecha.BorderColor = System.Drawing.Color.Transparent;
            this.lblFecha.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblFecha.CanGrow = false;
            this.lblFecha.Dpi = 100F;
            this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.LocationFloat = new DevExpress.Utils.PointFloat(360.2083F, 0F);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFecha.SizeF = new System.Drawing.SizeF(140F, 30F);
            this.lblFecha.StylePriority.UseBorderColor = false;
            this.lblFecha.StylePriority.UseBorders = false;
            this.lblFecha.StylePriority.UseFont = false;
            this.lblFecha.StylePriority.UseTextAlignment = false;
            this.lblFecha.Text = "Cobranza";
            this.lblFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoWidth = true;
            this.lblVendedor.BorderColor = System.Drawing.Color.Transparent;
            this.lblVendedor.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblVendedor.CanGrow = false;
            this.lblVendedor.Dpi = 100F;
            this.lblVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblVendedor.LocationFloat = new DevExpress.Utils.PointFloat(220.2083F, 0F);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblVendedor.SizeF = new System.Drawing.SizeF(140F, 30F);
            this.lblVendedor.StylePriority.UseBorderColor = false;
            this.lblVendedor.StylePriority.UseBorders = false;
            this.lblVendedor.StylePriority.UseFont = false;
            this.lblVendedor.StylePriority.UseTextAlignment = false;
            this.lblVendedor.Text = "Credito";
            this.lblVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoWidth = true;
            this.lblCliente.BorderColor = System.Drawing.Color.Transparent;
            this.lblCliente.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCliente.CanGrow = false;
            this.lblCliente.Dpi = 100F;
            this.lblCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.LocationFloat = new DevExpress.Utils.PointFloat(70.20833F, 0F);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCliente.SizeF = new System.Drawing.SizeF(150F, 30F);
            this.lblCliente.StylePriority.UseBorderColor = false;
            this.lblCliente.StylePriority.UseBorders = false;
            this.lblCliente.StylePriority.UseFont = false;
            this.lblCliente.StylePriority.UseTextAlignment = false;
            this.lblCliente.Text = "Contado";
            this.lblCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoWidth = true;
            this.lblCuenta.BorderColor = System.Drawing.Color.Transparent;
            this.lblCuenta.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCuenta.CanGrow = false;
            this.lblCuenta.Dpi = 100F;
            this.lblCuenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblCuenta.LocationFloat = new DevExpress.Utils.PointFloat(850.2084F, 0F);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCuenta.SizeF = new System.Drawing.SizeF(140F, 30F);
            this.lblCuenta.StylePriority.UseBorderColor = false;
            this.lblCuenta.StylePriority.UseBorders = false;
            this.lblCuenta.StylePriority.UseFont = false;
            this.lblCuenta.StylePriority.UseTextAlignment = false;
            this.lblCuenta.Text = "Numero de Tickets de Venta";
            this.lblCuenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // parameterRutas
            // 
            this.parameterRutas.Description = "parameterRutas";
            this.parameterRutas.Name = "parameterRutas";
            this.parameterRutas.ValueInfo = "SUR09";
            this.parameterRutas.Visible = false;
            // 
            // parameterCedis
            // 
            this.parameterCedis.Description = "parameterCedis";
            this.parameterCedis.Name = "parameterCedis";
            this.parameterCedis.ValueInfo = "20";
            this.parameterCedis.Visible = false;
            // 
            // OcultarCantidadesDevoluciones
            // 
            this.OcultarCantidadesDevoluciones.Condition = "EndsWith(ToStr([Referencia]), \'D\')";
            // 
            // 
            // 
            this.OcultarCantidadesDevoluciones.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.OcultarCantidadesDevoluciones.Name = "OcultarCantidadesDevoluciones";
            // 
            // MostrarCantidadesDevoluciones
            // 
            this.MostrarCantidadesDevoluciones.Condition = "EndsWith(ToStr([Referencia]), \'D\')";
            // 
            // 
            // 
            this.MostrarCantidadesDevoluciones.Formatting.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.MostrarCantidadesDevoluciones.Name = "MostrarCantidadesDevoluciones";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel16,
            this.xrLabel13,
            this.xrLabel10,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter1.HeightF = 35.00002F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Devoluciones")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(990.2084F, 12.00002F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:$0.00}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel21.Summary = xrSummary1;
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Tickets")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(850.2084F, 12.00002F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel20.Summary = xrSummary2;
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.TotalEfectivo")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(640.6251F, 12.00002F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:$#,##0.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel16.Summary = xrSummary3;
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.TotalVenta")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(500.6252F, 12.00002F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:$0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel13.Summary = xrSummary4;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Cobranza")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(360.2083F, 12.00002F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:$#,##0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel10.Summary = xrSummary5;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Credito")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(220.2083F, 12.00002F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:$#,##0.00}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel5.Summary = xrSummary6;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.AutoWidth = true;
            this.xrLabel4.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.00002F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Subtotal";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Contado")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(70.20834F, 12.00002F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            xrSummary7.FormatString = "{0:$#,##0.00}";
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel3.Summary = xrSummary7;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel23,
            this.xrLabel27,
            this.xrLabel29});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 33.00001F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // xrLabel23
            // 
            this.xrLabel23.AutoWidth = true;
            this.xrLabel23.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel23.CanGrow = false;
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(500.6251F, 10.00001F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel23.StylePriority.UseBorderColor = false;
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Total CEDIS";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.TotalEfectivo")});
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(640.6251F, 10.00001F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            xrSummary8.FormatString = "{0:$0.00}";
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel27.Summary = xrSummary8;
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel29
            // 
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionEfectivoDIV.Devoluciones")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(990.4168F, 10.00001F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            xrSummary9.FormatString = "{0:$0.00}";
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel29.Summary = xrSummary9;
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 33.00001F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(990.4168F, 10.00001F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(139.9999F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(187.5F, 23F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // sqlDataSource3
            // 
            this.sqlDataSource3.ConnectionName = "eRouteConnection";
            this.sqlDataSource3.Name = "sqlDataSource3";
            storedProcQuery1.Name = "stpr_ReporteLiquidacionEfectivoDIV";
            queryParameter1.Name = "@filtroCEDIS";
            queryParameter1.Type = typeof(string);
            queryParameter2.Name = "@filtroRutas";
            queryParameter2.Type = typeof(string);
            queryParameter3.Name = "@filtroFechaInicio";
            queryParameter3.Type = typeof(string);
            queryParameter4.Name = "@filtroFechaFin";
            queryParameter4.Type = typeof(string);
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.StoredProcName = "stpr_ReporteLiquidacionEfectivoDIV";
            this.sqlDataSource3.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource3.ResultSchemaSerializable = resources.GetString("sqlDataSource3.ResultSchemaSerializable");
            // 
            // ReporteLiquidacionEfectivoDIV
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupFooter1,
            this.GroupFooter2,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource3});
            this.DataSource = this.sqlDataSource3;
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.OcultarCantidadesDevoluciones,
            this.MostrarCantidadesDevoluciones});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(5, 357, 0, 0);
            this.PageHeight = 1500;
            this.PageWidth = 1500;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedis,
            this.parameterRutas,
            this.parameterFechaInicio,
            this.parameterFechaFin});
            this.Version = "16.1";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.ReporteLiquidacionEfectivoDIV_DataSourceDemanded);
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReporteLiquidacionEfectivoDIV_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void ReporteLiquidacionEfectivoDIV_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        
        if (((DevExpress.DataAccess.Native.Sql.ResultSet)((DevExpress.DataAccess.Sql.SqlDataSource)DataSource).Result).Tables.ToList()[0].Count == 0)
        {
            e.Cancel = true;
            throw new Exception("No tiene datos");
        }
    }

    public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string Cedis, string TipoFecha, string FechaInicial, string FechaFinal, string Rutas)
    {
        //this.NombreReporte = NombreReporte;
        //this.NombreEmpresa = NombreEmpresa;
        //this.LogoEmpresa = LogoEmpresa;
        this.Cedis = Cedis;
        this.FechaInicial = DateTime.Parse(FechaInicial);
        if (TipoFecha.Equals("Igual"))
            this.FechaFinal = DateTime.Parse(FechaInicial);
        else
            this.FechaFinal = DateTime.Parse(FechaFinal);

        this.Rutas = Rutas;
        Name = string.Format("LiquidacionEfectivo{0:yyyy'-'MM'-'dd'T'HH':'mm':'ss}.xlsx", DateTime.Now);

        InitializeComponent();

        this.Reporte.Text = this.NombreReporte;

        return this;
    }

    private void lblDetalle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
    }


    private void ReporteLiquidacionEfectivoDIV_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterCedis"].Value = this.Cedis;
        this.Parameters["parameterRutas"].Value = this.Rutas;
        this.Parameters["parameterFechaInicio"].Value = this.FechaInicial.Date.ToString("s");
        this.Parameters["parameterFechaFin"].Value = this.FechaFinal.Date.ToString("s");
    }

}
