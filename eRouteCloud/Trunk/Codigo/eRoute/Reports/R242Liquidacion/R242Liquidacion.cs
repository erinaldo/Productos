using System;
using System.Drawing;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using DevExpress.Xpo;

/// <summary>
/// Summary description for R242Liquidacion
/// </summary>
public class R242Liquidacion : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.XtraReports.Parameters.Parameter parameterVendedores;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicial;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private XRPictureBox logo;
    private XRLabel reporte;
    private XRLabel xrLabel69;
    private XRLabel xrLabel70;
    private XRLabel nameFiltro;
    private XRLabel centro;
    private XRLabel fecha;
    private XRLabel filtro;
    private XRLabel empresa;
    private XRLabel xrLabel84;
    private XRLabel xrLabel1;
    private XRSubreport R242LiquidacionDepositosChequesYOtrosConceptos;
    private XRSubreport R242LiquidacionDesglose;
    private XRSubreport R242LiquidacionPreLiquidacion;
    private XRSubreport R242LiquidacionCobranza;
    private XRSubreport R242LiquidacionVentasCredito;
    private XRSubreport R242LiquidacionVentasContado;
    private XRLabel xrLabel2;
    private XRLabel xrLabel21;
    private CalculatedField InventarioFinal;
    private XRLabel xrLabel27;
    private CalculatedField VentasCreditoVendedor;
    private CalculatedField VentaTotalVendedor;
    
    private string Vendedores;
    private string NombreCEDIS;
    private string NombreReporte;
    private string NombreEmpresa;
    private string QueryString;
    private MemoryStream LogoEmpresa;
    private DateTime fInicio;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

    public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string FechaInicial, string Vendedores)
    {
        this.fInicio = DateTime.Parse(FechaInicial);
        this.Vendedores = Vendedores;
        this.NombreCEDIS = NombreCEDIS;
        this.NombreReporte = NombreReporte;
        this.NombreEmpresa = NombreEmpresa;
        this.LogoEmpresa = LogoEmpresa;
        if (CountRows() > 0)
        {
            InitializeComponent();
            return this;
        }
        else
        {
            return null;
        }
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
        DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R242Liquidacion));
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
        this.reporte = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
        this.nameFiltro = new DevExpress.XtraReports.UI.XRLabel();
        this.centro = new DevExpress.XtraReports.UI.XRLabel();
        this.fecha = new DevExpress.XtraReports.UI.XRLabel();
        this.filtro = new DevExpress.XtraReports.UI.XRLabel();
        this.empresa = new DevExpress.XtraReports.UI.XRLabel();
        this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.R242LiquidacionDepositosChequesYOtrosConceptos = new DevExpress.XtraReports.UI.XRSubreport();
        this.parameterFechaInicial = new DevExpress.XtraReports.Parameters.Parameter();
        this.R242LiquidacionDesglose = new DevExpress.XtraReports.UI.XRSubreport();
        this.R242LiquidacionPreLiquidacion = new DevExpress.XtraReports.UI.XRSubreport();
        this.R242LiquidacionCobranza = new DevExpress.XtraReports.UI.XRSubreport();
        this.R242LiquidacionVentasCredito = new DevExpress.XtraReports.UI.XRSubreport();
        this.R242LiquidacionVentasContado = new DevExpress.XtraReports.UI.XRSubreport();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.parameterVendedores = new DevExpress.XtraReports.Parameters.Parameter();
        this.InventarioFinal = new DevExpress.XtraReports.UI.CalculatedField();
        this.VentasCreditoVendedor = new DevExpress.XtraReports.UI.CalculatedField();
        this.VentaTotalVendedor = new DevExpress.XtraReports.UI.CalculatedField();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel21});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 15F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.StyleName = "DataField";
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel15
        // 
        this.xrLabel15.CanGrow = false;
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Cambios", "{0:n}")});
        this.xrLabel15.Dpi = 100F;
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(625F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "xrLabel15";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel16
        // 
        this.xrLabel16.CanGrow = false;
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Clave")});
        this.xrLabel16.Dpi = 100F;
        this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(65F, 15F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "xrLabel16";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel17
        // 
        this.xrLabel17.CanGrow = false;
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Descargas", "{0:n}")});
        this.xrLabel17.Dpi = 100F;
        this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(830F, 0F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "xrLabel17";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel18
        // 
        this.xrLabel18.CanGrow = false;
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Descripcion")});
        this.xrLabel18.Dpi = 100F;
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(65F, 0F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(330F, 15F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "xrLabel18";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel19
        // 
        this.xrLabel19.CanGrow = false;
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Devoluciones", "{0:n}")});
        this.xrLabel19.Dpi = 100F;
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(690F, 0F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "xrLabel19";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel20
        // 
        this.xrLabel20.CanGrow = false;
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Importe", "{0:$#,##0.00}")});
        this.xrLabel20.Dpi = 100F;
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(960F, 0F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(65F, 15F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "xrLabel20";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel22
        // 
        this.xrLabel22.CanGrow = false;
        this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.InventarioInicial", "{0:n}")});
        this.xrLabel22.Dpi = 100F;
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(495F, 0F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "xrLabel22";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel23
        // 
        this.xrLabel23.CanGrow = false;
        this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Merma", "{0:n}")});
        this.xrLabel23.Dpi = 100F;
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(765F, 0F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "xrLabel23";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel24
        // 
        this.xrLabel24.CanGrow = false;
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Recargas", "{0:n}")});
        this.xrLabel24.Dpi = 100F;
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(560F, 0F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "xrLabel24";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel25
        // 
        this.xrLabel25.CanGrow = false;
        this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Unidad")});
        this.xrLabel25.Dpi = 100F;
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(395F, 0F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "xrLabel25";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel26
        // 
        this.xrLabel26.CanGrow = false;
        this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Ventas", "{0:n}")});
        this.xrLabel26.Dpi = 100F;
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(895F, 0F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "xrLabel26";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.InventarioFinal", "{0:n}")});
        this.xrLabel21.Dpi = 100F;
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(1025F, 0F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(65F, 15F);
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "xrLabel21";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 100F;
        this.TopMargin.HeightF = 5F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 100F;
        this.BottomMargin.HeightF = 5F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // sqlDataSource1
        // 
        this.sqlDataSource1.ConnectionName = "eRouteConnection";
        this.sqlDataSource1.Name = "sqlDataSource1";
        storedProcQuery1.Name = "stpr_RW242Liquidacion";
        queryParameter1.Name = "@filtroVendedores";
        queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterVendedores]", typeof(string));
        queryParameter2.Name = "@filtroFechaInicio";
        queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaInicial]", typeof(string));
        queryParameter3.Name = "@filtroConsulta";
        queryParameter3.Type = typeof(int);
        queryParameter3.ValueInfo = "1";
        storedProcQuery1.Parameters.Add(queryParameter1);
        storedProcQuery1.Parameters.Add(queryParameter2);
        storedProcQuery1.Parameters.Add(queryParameter3);
        storedProcQuery1.StoredProcName = "stpr_RW242Liquidacion";
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
        // 
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel84,
            this.xrLabel1,
            this.xrLabel4,
            this.xrLabel9,
            this.xrLabel14,
            this.xrLabel5,
            this.xrLabel11,
            this.xrLabel7,
            this.xrLabel3,
            this.xrLabel12,
            this.xrLabel10,
            this.xrLabel13,
            this.xrLabel6,
            this.xrLabel8});
        this.groupHeaderBand1.Dpi = 100F;
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.HeightF = 60F;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(1090F, 15F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Movimientos de Productos";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel84
        // 
        this.xrLabel84.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrLabel84.BorderWidth = 2F;
        this.xrLabel84.CanGrow = false;
        this.xrLabel84.Dpi = 100F;
        this.xrLabel84.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel84.Name = "xrLabel84";
        this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel84.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel84.StyleName = "FieldCaption";
        this.xrLabel84.StylePriority.UseBorders = false;
        this.xrLabel84.StylePriority.UseBorderWidth = false;
        this.xrLabel84.StylePriority.UseFont = false;
        this.xrLabel84.StylePriority.UseTextAlignment = false;
        this.xrLabel84.Text = "Vendedor:";
        this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrLabel1.BorderWidth = 2F;
        this.xrLabel1.CanGrow = false;
        this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Vendedor")});
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(60F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(1030F, 15F);
        this.xrLabel1.StyleName = "DataField";
        this.xrLabel1.StylePriority.UseBorders = false;
        this.xrLabel1.StylePriority.UseBorderWidth = false;
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "xrLabel4";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel4.BorderWidth = 2F;
        this.xrLabel4.CanGrow = false;
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel4.StylePriority.UseBorders = false;
        this.xrLabel4.StylePriority.UseBorderWidth = false;
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Clave";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel9.BorderWidth = 2F;
        this.xrLabel9.CanGrow = false;
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(1025F, 30F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel9.StylePriority.UseBorders = false;
        this.xrLabel9.StylePriority.UseBorderWidth = false;
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Inventario Final";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel14.BorderWidth = 2F;
        this.xrLabel14.CanGrow = false;
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(895F, 30F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel14.StylePriority.UseBorders = false;
        this.xrLabel14.StylePriority.UseBorderWidth = false;
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Ventas";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel5.BorderWidth = 2F;
        this.xrLabel5.CanGrow = false;
        this.xrLabel5.Dpi = 100F;
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(830F, 30F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel5.StylePriority.UseBorders = false;
        this.xrLabel5.StylePriority.UseBorderWidth = false;
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Descargas";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel11.BorderWidth = 2F;
        this.xrLabel11.CanGrow = false;
        this.xrLabel11.Dpi = 100F;
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(765F, 30F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel11.StylePriority.UseBorders = false;
        this.xrLabel11.StylePriority.UseBorderWidth = false;
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "Merma";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel7.BorderWidth = 2F;
        this.xrLabel7.CanGrow = false;
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(690F, 30F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(75F, 30F);
        this.xrLabel7.StylePriority.UseBorders = false;
        this.xrLabel7.StylePriority.UseBorderWidth = false;
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Devoluciones";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel3.BorderWidth = 2F;
        this.xrLabel3.CanGrow = false;
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(625F, 30F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel3.StylePriority.UseBorders = false;
        this.xrLabel3.StylePriority.UseBorderWidth = false;
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Cambios";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel12
        // 
        this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel12.BorderWidth = 2F;
        this.xrLabel12.CanGrow = false;
        this.xrLabel12.Dpi = 100F;
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(560F, 30F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel12.StylePriority.UseBorders = false;
        this.xrLabel12.StylePriority.UseBorderWidth = false;
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "Recargas";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel10.BorderWidth = 2F;
        this.xrLabel10.CanGrow = false;
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(494.9999F, 30F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel10.StylePriority.UseBorders = false;
        this.xrLabel10.StylePriority.UseBorderWidth = false;
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Inventario Inicial";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel13.BorderWidth = 2F;
        this.xrLabel13.CanGrow = false;
        this.xrLabel13.Dpi = 100F;
        this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(395F, 30F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(100F, 30F);
        this.xrLabel13.StylePriority.UseBorders = false;
        this.xrLabel13.StylePriority.UseBorderWidth = false;
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Unidad";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel6.BorderWidth = 2F;
        this.xrLabel6.CanGrow = false;
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(65.00002F, 30F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(330F, 30F);
        this.xrLabel6.StylePriority.UseBorders = false;
        this.xrLabel6.StylePriority.UseBorderWidth = false;
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Descripcion";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel8.BorderWidth = 2F;
        this.xrLabel8.CanGrow = false;
        this.xrLabel8.Dpi = 100F;
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(960F, 30F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(65F, 30F);
        this.xrLabel8.StylePriority.UseBorders = false;
        this.xrLabel8.StylePriority.UseBorderWidth = false;
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Importe";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // pageFooterBand1
        // 
        this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
        this.pageFooterBand1.Dpi = 100F;
        this.pageFooterBand1.HeightF = 15F;
        this.pageFooterBand1.Name = "pageFooterBand1";
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Dpi = 100F;
        this.xrPageInfo2.Format = "Página {0} de {1}";
        this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(990F, 0F);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.StylePriority.UseTextAlignment = false;
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Dpi = 100F;
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(200F, 15F);
        this.xrPageInfo1.StyleName = "PageInfo";
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.xrLabel69,
            this.xrLabel70,
            this.nameFiltro,
            this.centro,
            this.fecha,
            this.filtro,
            this.empresa});
        this.reportHeaderBand1.Dpi = 100F;
        this.reportHeaderBand1.HeightF = 145F;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        // 
        // logo
        // 
        this.logo.Dpi = 100F;
        this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 7.499985F);
        this.logo.Name = "logo";
        this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
        // 
        // reporte
        // 
        this.reporte.CanGrow = false;
        this.reporte.Dpi = 100F;
        this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
        this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(300F, 47.49998F);
        this.reporte.Name = "reporte";
        this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
        this.reporte.StyleName = "Title";
        this.reporte.StylePriority.UseFont = false;
        this.reporte.StylePriority.UseTextAlignment = false;
        this.reporte.Text = "reporte";
        this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel69
        // 
        this.xrLabel69.CanGrow = false;
        this.xrLabel69.Dpi = 100F;
        this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(0F, 92.49998F);
        this.xrLabel69.Name = "xrLabel69";
        this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel69.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel69.StylePriority.UseFont = false;
        this.xrLabel69.StylePriority.UseTextAlignment = false;
        this.xrLabel69.Text = "Centro De Distribución:";
        this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel70
        // 
        this.xrLabel70.CanGrow = false;
        this.xrLabel70.Dpi = 100F;
        this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(0F, 107.5F);
        this.xrLabel70.Name = "xrLabel70";
        this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel70.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel70.StylePriority.UseFont = false;
        this.xrLabel70.StylePriority.UseTextAlignment = false;
        this.xrLabel70.Text = "Fecha:";
        this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // nameFiltro
        // 
        this.nameFiltro.CanGrow = false;
        this.nameFiltro.Dpi = 100F;
        this.nameFiltro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.nameFiltro.LocationFloat = new DevExpress.Utils.PointFloat(0F, 122.5F);
        this.nameFiltro.Name = "nameFiltro";
        this.nameFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.nameFiltro.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.nameFiltro.StylePriority.UseFont = false;
        this.nameFiltro.StylePriority.UseTextAlignment = false;
        this.nameFiltro.Text = "nameFiltro";
        this.nameFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // centro
        // 
        this.centro.CanGrow = false;
        this.centro.Dpi = 100F;
        this.centro.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.centro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 92.49998F);
        this.centro.Name = "centro";
        this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.centro.SizeF = new System.Drawing.SizeF(940F, 15F);
        this.centro.StylePriority.UseFont = false;
        this.centro.StylePriority.UseTextAlignment = false;
        this.centro.Text = "centro";
        this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // fecha
        // 
        this.fecha.CanGrow = false;
        this.fecha.Dpi = 100F;
        this.fecha.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(150F, 107.5F);
        this.fecha.Name = "fecha";
        this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.fecha.SizeF = new System.Drawing.SizeF(940F, 15F);
        this.fecha.StylePriority.UseFont = false;
        this.fecha.StylePriority.UseTextAlignment = false;
        this.fecha.Text = "fecha";
        this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // filtro
        // 
        this.filtro.CanGrow = false;
        this.filtro.Dpi = 100F;
        this.filtro.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.filtro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 122.5F);
        this.filtro.Name = "filtro";
        this.filtro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.filtro.SizeF = new System.Drawing.SizeF(940F, 15F);
        this.filtro.StylePriority.UseFont = false;
        this.filtro.StylePriority.UseTextAlignment = false;
        this.filtro.Text = "filtro";
        this.filtro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // empresa
        // 
        this.empresa.CanGrow = false;
        this.empresa.Dpi = 100F;
        this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
        this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(300F, 7.499985F);
        this.empresa.Name = "empresa";
        this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
        this.empresa.StylePriority.UseFont = false;
        this.empresa.StylePriority.UseTextAlignment = false;
        this.empresa.Text = "empresa";
        this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // groupFooterBand1
        // 
        this.groupFooterBand1.Dpi = 100F;
        this.groupFooterBand1.HeightF = 1F;
        this.groupFooterBand1.Name = "groupFooterBand1";
        // 
        // groupFooterBand2
        // 
        this.groupFooterBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.R242LiquidacionDepositosChequesYOtrosConceptos,
            this.R242LiquidacionDesglose,
            this.R242LiquidacionPreLiquidacion,
            this.R242LiquidacionCobranza,
            this.R242LiquidacionVentasCredito,
            this.R242LiquidacionVentasContado,
            this.xrLabel28,
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37});
        this.groupFooterBand2.Dpi = 100F;
        this.groupFooterBand2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.groupFooterBand2.HeightF = 135F;
        this.groupFooterBand2.Name = "groupFooterBand2";
        this.groupFooterBand2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
        this.groupFooterBand2.StylePriority.UseFont = false;
        // 
        // xrLabel27
        // 
        this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.InventarioFinal")});
        this.xrLabel27.Dpi = 100F;
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(1025F, 0F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(65F, 15F);
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:n}";
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel27.Summary = xrSummary1;
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // R242LiquidacionDepositosChequesYOtrosConceptos
        // 
        this.R242LiquidacionDepositosChequesYOtrosConceptos.Dpi = 100F;
        this.R242LiquidacionDepositosChequesYOtrosConceptos.LocationFloat = new DevExpress.Utils.PointFloat(645F, 105F);
        this.R242LiquidacionDepositosChequesYOtrosConceptos.Name = "R242LiquidacionDepositosChequesYOtrosConceptos";
        this.R242LiquidacionDepositosChequesYOtrosConceptos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", null, "stpr_RW242Liquidacion.VendedorID"));
        this.R242LiquidacionDepositosChequesYOtrosConceptos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicial", this.parameterFechaInicial));
        this.R242LiquidacionDepositosChequesYOtrosConceptos.ReportSource = new R242LiquidacionDepositosChequesYOtrosConceptos();
        this.R242LiquidacionDepositosChequesYOtrosConceptos.SizeF = new System.Drawing.SizeF(445F, 30F);
        // 
        // parameterFechaInicial
        // 
        this.parameterFechaInicial.Name = "parameterFechaInicial";
        this.parameterFechaInicial.ValueInfo = "2020-02-06";
        this.parameterFechaInicial.Visible = false;
        // 
        // R242LiquidacionDesglose
        // 
        this.R242LiquidacionDesglose.Dpi = 100F;
        this.R242LiquidacionDesglose.LocationFloat = new DevExpress.Utils.PointFloat(250F, 105F);
        this.R242LiquidacionDesglose.Name = "R242LiquidacionDesglose";
        this.R242LiquidacionDesglose.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", null, "stpr_RW242Liquidacion.VendedorID"));
        this.R242LiquidacionDesglose.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicial", this.parameterFechaInicial));
        this.R242LiquidacionDesglose.ReportSource = new R242LiquidacionDesglose();
        this.R242LiquidacionDesglose.SizeF = new System.Drawing.SizeF(395F, 30F);
        // 
        // R242LiquidacionPreLiquidacion
        // 
        this.R242LiquidacionPreLiquidacion.Dpi = 100F;
        this.R242LiquidacionPreLiquidacion.LocationFloat = new DevExpress.Utils.PointFloat(0F, 105F);
        this.R242LiquidacionPreLiquidacion.Name = "R242LiquidacionPreLiquidacion";
        this.R242LiquidacionPreLiquidacion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", null, "stpr_RW242Liquidacion.VendedorID"));
        this.R242LiquidacionPreLiquidacion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicial", this.parameterFechaInicial));
        this.R242LiquidacionPreLiquidacion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVentaTotal", null, "stpr_RW242Liquidacion.VentaTotalVendedor"));
        this.R242LiquidacionPreLiquidacion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVentasCredito", null, "stpr_RW242Liquidacion.VentasCreditoVendedor"));
        this.R242LiquidacionPreLiquidacion.ReportSource = new R242LiquidacionPreLiquidacion();
        this.R242LiquidacionPreLiquidacion.SizeF = new System.Drawing.SizeF(250F, 30F);
        // 
        // R242LiquidacionCobranza
        // 
        this.R242LiquidacionCobranza.Dpi = 100F;
        this.R242LiquidacionCobranza.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
        this.R242LiquidacionCobranza.Name = "R242LiquidacionCobranza";
        this.R242LiquidacionCobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", null, "stpr_RW242Liquidacion.VendedorID"));
        this.R242LiquidacionCobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicial", this.parameterFechaInicial));
        this.R242LiquidacionCobranza.ReportSource = new R242LiquidacionCobranza();
        this.R242LiquidacionCobranza.SizeF = new System.Drawing.SizeF(1090F, 30F);
        // 
        // R242LiquidacionVentasCredito
        // 
        this.R242LiquidacionVentasCredito.Dpi = 100F;
        this.R242LiquidacionVentasCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45F);
        this.R242LiquidacionVentasCredito.Name = "R242LiquidacionVentasCredito";
        this.R242LiquidacionVentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", null, "stpr_RW242Liquidacion.VendedorID"));
        this.R242LiquidacionVentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicial", this.parameterFechaInicial));
        this.R242LiquidacionVentasCredito.ReportSource = new R242LiquidacionVentasCredito();
        this.R242LiquidacionVentasCredito.SizeF = new System.Drawing.SizeF(1090F, 30F);
        // 
        // R242LiquidacionVentasContado
        // 
        this.R242LiquidacionVentasContado.Dpi = 100F;
        this.R242LiquidacionVentasContado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15F);
        this.R242LiquidacionVentasContado.Name = "R242LiquidacionVentasContado";
        this.R242LiquidacionVentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", null, "stpr_RW242Liquidacion.VendedorID"));
        this.R242LiquidacionVentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicial", this.parameterFechaInicial));
        this.R242LiquidacionVentasContado.ReportSource = new R242LiquidacionVentasContado();
        this.R242LiquidacionVentasContado.SizeF = new System.Drawing.SizeF(1090F, 30F);
        // 
        // xrLabel28
        // 
        this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel28.BorderWidth = 2F;
        this.xrLabel28.CanGrow = false;
        this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Cambios")});
        this.xrLabel28.Dpi = 100F;
        this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(625F, 0F);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel28.StyleName = "FieldCaption";
        this.xrLabel28.StylePriority.UseBorders = false;
        this.xrLabel28.StylePriority.UseBorderWidth = false;
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:n}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel28.Summary = xrSummary2;
        this.xrLabel28.Text = "xrLabel28";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel29
        // 
        this.xrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel29.BorderWidth = 2F;
        this.xrLabel29.CanGrow = false;
        this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Descargas")});
        this.xrLabel29.Dpi = 100F;
        this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(830F, 0F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel29.StyleName = "FieldCaption";
        this.xrLabel29.StylePriority.UseBorders = false;
        this.xrLabel29.StylePriority.UseBorderWidth = false;
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:n}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel29.Summary = xrSummary3;
        this.xrLabel29.Text = "xrLabel29";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel30.BorderWidth = 2F;
        this.xrLabel30.CanGrow = false;
        this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Devoluciones")});
        this.xrLabel30.Dpi = 100F;
        this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(690F, 0F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel30.StyleName = "FieldCaption";
        this.xrLabel30.StylePriority.UseBorders = false;
        this.xrLabel30.StylePriority.UseBorderWidth = false;
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:n}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel30.Summary = xrSummary4;
        this.xrLabel30.Text = "xrLabel30";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel31
        // 
        this.xrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel31.BorderWidth = 2F;
        this.xrLabel31.CanGrow = false;
        this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Importe")});
        this.xrLabel31.Dpi = 100F;
        this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(960.0001F, 0F);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel31.SizeF = new System.Drawing.SizeF(65F, 15F);
        this.xrLabel31.StyleName = "FieldCaption";
        this.xrLabel31.StylePriority.UseBorders = false;
        this.xrLabel31.StylePriority.UseBorderWidth = false;
        this.xrLabel31.StylePriority.UseFont = false;
        this.xrLabel31.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:$#,##0.00}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel31.Summary = xrSummary5;
        this.xrLabel31.Text = "xrLabel31";
        this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel33
        // 
        this.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel33.BorderWidth = 2F;
        this.xrLabel33.CanGrow = false;
        this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.InventarioInicial")});
        this.xrLabel33.Dpi = 100F;
        this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(495F, 0F);
        this.xrLabel33.Name = "xrLabel33";
        this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel33.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel33.StyleName = "FieldCaption";
        this.xrLabel33.StylePriority.UseBorders = false;
        this.xrLabel33.StylePriority.UseBorderWidth = false;
        this.xrLabel33.StylePriority.UseFont = false;
        this.xrLabel33.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:n}";
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel33.Summary = xrSummary6;
        this.xrLabel33.Text = "xrLabel33";
        this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel34
        // 
        this.xrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel34.BorderWidth = 2F;
        this.xrLabel34.CanGrow = false;
        this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Merma")});
        this.xrLabel34.Dpi = 100F;
        this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(764.9999F, 0F);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel34.StyleName = "FieldCaption";
        this.xrLabel34.StylePriority.UseBorders = false;
        this.xrLabel34.StylePriority.UseBorderWidth = false;
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:n}";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel34.Summary = xrSummary7;
        this.xrLabel34.Text = "xrLabel34";
        this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel35
        // 
        this.xrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel35.BorderWidth = 2F;
        this.xrLabel35.CanGrow = false;
        this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Recargas")});
        this.xrLabel35.Dpi = 100F;
        this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(560F, 0F);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel35.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel35.StyleName = "FieldCaption";
        this.xrLabel35.StylePriority.UseBorders = false;
        this.xrLabel35.StylePriority.UseBorderWidth = false;
        this.xrLabel35.StylePriority.UseFont = false;
        this.xrLabel35.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:n}";
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel35.Summary = xrSummary8;
        this.xrLabel35.Text = "xrLabel35";
        this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel36
        // 
        this.xrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel36.BorderWidth = 2F;
        this.xrLabel36.CanGrow = false;
        this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW242Liquidacion.Ventas")});
        this.xrLabel36.Dpi = 100F;
        this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(895F, 0F);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel36.StyleName = "FieldCaption";
        this.xrLabel36.StylePriority.UseBorders = false;
        this.xrLabel36.StylePriority.UseBorderWidth = false;
        this.xrLabel36.StylePriority.UseFont = false;
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        xrSummary9.FormatString = "{0:n}";
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel36.Summary = xrSummary9;
        this.xrLabel36.Text = "xrLabel36";
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel37
        // 
        this.xrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel37.BorderWidth = 2F;
        this.xrLabel37.CanGrow = false;
        this.xrLabel37.Dpi = 100F;
        this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(395F, 0F);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel37.StyleName = "FieldCaption";
        this.xrLabel37.StylePriority.UseBorders = false;
        this.xrLabel37.StylePriority.UseBorderWidth = false;
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        this.xrLabel37.Text = "Total:";
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // Title
        // 
        this.Title.BackColor = System.Drawing.Color.Transparent;
        this.Title.BorderColor = System.Drawing.Color.Black;
        this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.Title.BorderWidth = 1F;
        this.Title.Font = new System.Drawing.Font("Times New Roman", 24F);
        this.Title.ForeColor = System.Drawing.Color.Black;
        this.Title.Name = "Title";
        // 
        // FieldCaption
        // 
        this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
        this.FieldCaption.BorderColor = System.Drawing.Color.Black;
        this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.FieldCaption.BorderWidth = 1F;
        this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.FieldCaption.ForeColor = System.Drawing.Color.Black;
        this.FieldCaption.Name = "FieldCaption";
        // 
        // PageInfo
        // 
        this.PageInfo.BackColor = System.Drawing.Color.Transparent;
        this.PageInfo.BorderColor = System.Drawing.Color.Black;
        this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.PageInfo.BorderWidth = 1F;
        this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.PageInfo.ForeColor = System.Drawing.Color.Black;
        this.PageInfo.Name = "PageInfo";
        // 
        // DataField
        // 
        this.DataField.BackColor = System.Drawing.Color.Transparent;
        this.DataField.BorderColor = System.Drawing.Color.Black;
        this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.DataField.BorderWidth = 1F;
        this.DataField.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.DataField.ForeColor = System.Drawing.Color.Black;
        this.DataField.Name = "DataField";
        this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        // 
        // parameterVendedores
        // 
        this.parameterVendedores.Name = "parameterVendedores";
        this.parameterVendedores.ValueInfo = "VENMOS,R-PIN";
        this.parameterVendedores.Visible = false;
        // 
        // InventarioFinal
        // 
        this.InventarioFinal.DataMember = "stpr_RW242Liquidacion";
        this.InventarioFinal.Expression = "[InventarioInicial] + [Recargas] - [Merma] - [Descargas] - [Ventas] + [Devolucion" +
"es]";
        this.InventarioFinal.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
        this.InventarioFinal.Name = "InventarioFinal";
        // 
        // VentasCreditoVendedor
        // 
        this.VentasCreditoVendedor.DataMember = "stpr_RW242Liquidacion";
        this.VentasCreditoVendedor.Expression = "[][[VendedorID] ==  [^.VendedorID]].Sum([ImporteCredito])";
        this.VentasCreditoVendedor.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
        this.VentasCreditoVendedor.Name = "VentasCreditoVendedor";
        // 
        // VentaTotalVendedor
        // 
        this.VentaTotalVendedor.DataMember = "stpr_RW242Liquidacion";
        this.VentaTotalVendedor.Expression = "[][[VendedorID] ==  [^.VendedorID]].Sum([Importe])";
        this.VentaTotalVendedor.FieldType = DevExpress.XtraReports.UI.FieldType.Decimal;
        this.VentaTotalVendedor.Name = "VentaTotalVendedor";
        // 
        // R242Liquidacion
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand2});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.InventarioFinal,
            this.VentasCreditoVendedor,
            this.VentaTotalVendedor});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
        this.DataMember = "stpr_RW242Liquidacion";
        this.DataSource = this.sqlDataSource1;
        this.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterVendedores,
            this.parameterFechaInicial});
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "16.1";
        this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.R242Liquidacion_DataSourceDemanded);
        this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R242Liquidacion_BeforePrint);
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private int CountRows()
    {
        StringBuilder sConsulta = new StringBuilder();
        sConsulta.AppendLine("EXEC [dbo].[stpr_RW242Liquidacion] ");
        sConsulta.AppendLine("@filtroVendedores = '" + this.Vendedores + "', ");
        sConsulta.AppendLine("@filtroFechaInicio = '" + this.fInicio.Date.ToString("yyyy-MM-dd") + "', ");
        sConsulta.AppendLine("@filtroConsulta = 1");
        QueryString = sConsulta.ToString();
        List<ObjectModel> objectData = Connection.Query<ObjectModel>(QueryString, null, null, true, 9000).ToList();
        return 1;
    }

    private class ObjectModel
    {
        public string CEDI { get; set; }
    }

    private void R242Liquidacion_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterVendedores"].Value = this.Vendedores;
        this.Parameters["parameterFechaInicial"].Value = this.fInicio.Date.ToString("yyyy-MM-dd");
    }

    private void R242Liquidacion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        string FechaInicial = this.fInicio.Date.ToShortDateString();
        this.empresa.Text = this.NombreEmpresa;
        this.logo.Image = Image.FromStream(this.LogoEmpresa);
        this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        this.fecha.Text = FechaInicial;
        this.centro.Text = this.NombreCEDIS;
        this.reporte.Text = this.NombreReporte;
        this.nameFiltro.Text = "Vendedor(es): ";
        this.filtro.Text = (this.Vendedores == "" ? "Todos los Vendedores" : this.Vendedores);
    }
}
