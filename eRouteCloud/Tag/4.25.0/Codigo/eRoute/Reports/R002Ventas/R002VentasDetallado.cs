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

/// <summary>
/// Summary description for R002VentasDetallado
/// </summary>
public class R002VentasDetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private GroupHeaderBand groupHeaderBand2;
    private GroupHeaderBand groupHeaderBand3;
    private GroupHeaderBand groupHeaderBand4;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private XRLabel xrLabel46;
    private XRLabel xrLabel47;
    private GroupFooterBand groupFooterBand5;
    private XRLabel xrLabel61;
    private XRLabel xrLabel62;
    private ReportFooterBand reportFooterBand1;
    private XRLabel xrLabel66;
    private XRLabel xrLabel67;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.XtraReports.Parameters.Parameter parameterCEDIS;
    private DevExpress.XtraReports.Parameters.Parameter parameterRutas;
    private DevExpress.XtraReports.Parameters.Parameter parameterVendedores;
    private DevExpress.XtraReports.Parameters.Parameter parameterClientes;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicial;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaFinal;
    private XRLabel empresa;
    private XRLabel filtro;
    private XRLabel fecha;
    private XRLabel centro;
    private XRLabel nameFiltro;
    private XRLabel xrLabel70;
    private XRLabel xrLabel69;
    private XRLabel reporte;
    private XRPictureBox logo;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel75;
    private XRLabel xrLabel68;
    private XRLabel xrLabelSubE;
    private XRLabel xrLabel74;
    private XRLabel xrLabel44;
    private XRLabel xrLabel77;
    private XRLabel xrLabel78;
    private XRLabel xrLabel79;
    private XRLabel xrLabel80;
    private XRLabel xrLabel81;
    private XRLabel xrLabel82;
    private XRLabel xrLabelKiloE;
    private XRLabel xrLabel2;
    private XRLabel xrLabel83;
    private XRLabel xrLabel4;
    private XRLabel xrLabel84;
    private XRLabel xrLabel6;
    private XRLabel xrLabel85;
    private XRLabel xrLabel8;
    private XRLabel xrLabel86;
    private XRLabel xrLabel42;
    private XRLabel xrLabel40;
    private XRLabel xrLabelSubD;
    private XRLabel xrLabel38;
    private XRLabel xrLabel37;
    private XRLabel xrLabelKiloD;
    private XRLabel xrLabel35;
    private XRLabel xrLabel32;
    private XRLabel xrLabel31;
    private XRLabel xrLabel30;
    private XRLabel xrLabel29;
    private XRLabel xrLabel28;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private GroupHeaderBand groupHeaderBand5;
    private GroupFooterBand groupFooterBand0;
    private XRLabel xrLabel10;
    private XRLabel xrLabel87;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel7;
    private XRLabel xrLabel5;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel9;
    private CalculatedField XTotalContado;
    private CalculatedField XTotalCredito;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel18;

    private string CEDIS;
    private string Rutas;
    private string Vendedores;
    private string Clientes;
    private string NombreCEDIS;
    private string NombreVendedor;
    private string NombreReporte;
    private string NombreEmpresa;
    private string QueryString;
    private MemoryStream LogoEmpresa;
    private bool FiltroReporte;
    private DateTime fInicio;
    private DateTime fFin;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private XRSubreport R002VentasPedidosPorProducto;
    private XRLabel xrLabel19;
    private XRLabel xrLabel15;
    private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

    public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreVendedor, string NombreCEDIS, string CEDIS, string Rutas, string Vendedores, string Clientes, string FechaInicial, string FechaFinal, bool FiltroReporte)
    {
        this.fInicio = DateTime.Parse(FechaInicial);
        this.fFin = DateTime.Parse(FechaFinal);
        this.CEDIS = CEDIS;
        this.Rutas = Rutas;
        this.Vendedores = Vendedores;
        this.Clientes = Clientes;
        this.NombreCEDIS = NombreCEDIS;
        this.NombreVendedor = NombreVendedor;
        this.NombreReporte = NombreReporte;
        this.NombreEmpresa = NombreEmpresa;
        this.LogoEmpresa = LogoEmpresa;
        this.FiltroReporte = FiltroReporte;
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
        DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R002VentasDetallado));
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelSubD = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelKiloD = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupHeaderBand4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
        this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.empresa = new DevExpress.XtraReports.UI.XRLabel();
        this.filtro = new DevExpress.XtraReports.UI.XRLabel();
        this.fecha = new DevExpress.XtraReports.UI.XRLabel();
        this.centro = new DevExpress.XtraReports.UI.XRLabel();
        this.nameFiltro = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
        this.reporte = new DevExpress.XtraReports.UI.XRLabel();
        this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
        this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
        this.parameterCEDIS = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterRutas = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterVendedores = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterClientes = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterFechaInicial = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterFechaFinal = new DevExpress.XtraReports.Parameters.Parameter();
        this.groupFooterBand5 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
        this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelSubE = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel77 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel80 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelKiloE = new DevExpress.XtraReports.UI.XRLabel();
        this.groupHeaderBand5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupFooterBand0 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.XTotalContado = new DevExpress.XtraReports.UI.CalculatedField();
        this.XTotalCredito = new DevExpress.XtraReports.UI.CalculatedField();
        this.R002VentasPedidosPorProducto = new DevExpress.XtraReports.UI.XRSubreport();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel42,
            this.xrLabel40,
            this.xrLabelSubD,
            this.xrLabel38,
            this.xrLabel37,
            this.xrLabelKiloD,
            this.xrLabel35,
            this.xrLabel32,
            this.xrLabel31,
            this.xrLabel30,
            this.xrLabel29,
            this.xrLabel28});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 17.91668F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.StyleName = "DataField";
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel3
        // 
        this.xrLabel3.CanGrow = false;
        this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.FormaVenta")});
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(890.0002F, 0F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "xrLabel3";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel42
        // 
        this.xrLabel42.CanGrow = false;
        this.xrLabel42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Unidad")});
        this.xrLabel42.Dpi = 100F;
        this.xrLabel42.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(290F, 0F);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.StylePriority.UseTextAlignment = false;
        this.xrLabel42.Text = "xrLabel42";
        this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel40
        // 
        this.xrLabel40.CanGrow = false;
        this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Total", "{0:$#,##0.00}")});
        this.xrLabel40.Dpi = 100F;
        this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(970.0004F, 0F);
        this.xrLabel40.Name = "xrLabel40";
        this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel40.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel40.StylePriority.UseFont = false;
        this.xrLabel40.StylePriority.UseTextAlignment = false;
        this.xrLabel40.Text = "xrLabel40";
        this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabelSubD
        // 
        this.xrLabelSubD.CanGrow = false;
        this.xrLabelSubD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.SubTotal", "{0:$#,##0.00}")});
        this.xrLabelSubD.Dpi = 100F;
        this.xrLabelSubD.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabelSubD.LocationFloat = new DevExpress.Utils.PointFloat(530F, 0F);
        this.xrLabelSubD.Name = "xrLabelSubD";
        this.xrLabelSubD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelSubD.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabelSubD.StylePriority.UseFont = false;
        this.xrLabelSubD.StylePriority.UseTextAlignment = false;
        this.xrLabelSubD.Text = "xrLabelSubD";
        this.xrLabelSubD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel38
        // 
        this.xrLabel38.CanGrow = false;
        this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Producto")});
        this.xrLabel38.Dpi = 100F;
        this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(70F, 0F);
        this.xrLabel38.Name = "xrLabel38";
        this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel38.SizeF = new System.Drawing.SizeF(220F, 15F);
        this.xrLabel38.StylePriority.UseFont = false;
        this.xrLabel38.StylePriority.UseTextAlignment = false;
        this.xrLabel38.Text = "xrLabel38";
        this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel37
        // 
        this.xrLabel37.CanGrow = false;
        this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.PrecioU", "{0:$#,##0.00}")});
        this.xrLabel37.Dpi = 100F;
        this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(350F, 0F);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        this.xrLabel37.Text = "xrLabel37";
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabelKiloD
        // 
        this.xrLabelKiloD.CanGrow = false;
        this.xrLabelKiloD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Kglts", "{0:n}")});
        this.xrLabelKiloD.Dpi = 100F;
        this.xrLabelKiloD.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabelKiloD.LocationFloat = new DevExpress.Utils.PointFloat(470F, 0F);
        this.xrLabelKiloD.Name = "xrLabelKiloD";
        this.xrLabelKiloD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelKiloD.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabelKiloD.StylePriority.UseFont = false;
        this.xrLabelKiloD.StylePriority.UseTextAlignment = false;
        this.xrLabelKiloD.Text = "xrLabelKiloD";
        this.xrLabelKiloD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel35
        // 
        this.xrLabel35.CanGrow = false;
        this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Impuesto", "{0:n}")});
        this.xrLabel35.Dpi = 100F;
        this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(830.0002F, 0F);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel35.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel35.StylePriority.UseFont = false;
        this.xrLabel35.StylePriority.UseTextAlignment = false;
        this.xrLabel35.Text = "xrLabel35";
        this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel32
        // 
        this.xrLabel32.CanGrow = false;
        this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.DescVend", "{0:n}")});
        this.xrLabel32.Dpi = 100F;
        this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(750.0002F, 0F);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel32.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.StylePriority.UseTextAlignment = false;
        this.xrLabel32.Text = "xrLabel32";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel31
        // 
        this.xrLabel31.CanGrow = false;
        this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.DescuentoCliente", "{0:n}")});
        this.xrLabel31.Dpi = 100F;
        this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(679.7918F, 0F);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel31.SizeF = new System.Drawing.SizeF(70.20837F, 15F);
        this.xrLabel31.StylePriority.UseFont = false;
        this.xrLabel31.StylePriority.UseTextAlignment = false;
        this.xrLabel31.Text = "xrLabel31";
        this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel30
        // 
        this.xrLabel30.CanGrow = false;
        this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.DescProducto", "{0:n}")});
        this.xrLabel30.Dpi = 100F;
        this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(599.7917F, 0F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(75.625F, 15F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = "xrLabel30";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel29
        // 
        this.xrLabel29.CanGrow = false;
        this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Clave")});
        this.xrLabel29.Dpi = 100F;
        this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(70F, 15F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = "xrLabel29";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel28
        // 
        this.xrLabel28.CanGrow = false;
        this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Cant", "{0:#,#}")});
        this.xrLabel28.Dpi = 100F;
        this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(410F, 0F);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.Text = "xrLabel28";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
        this.sqlDataSource1.ConnectionOptions.CommandTimeout = 5000;
        this.sqlDataSource1.Name = "sqlDataSource1";
        storedProcQuery1.Name = "stpr_RW002Ventas";
        queryParameter1.Name = "@filtroCEDIS";
        queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCEDIS]", typeof(string));
        queryParameter2.Name = "@filtroRutas";
        queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRutas]", typeof(string));
        queryParameter3.Name = "@filtroVendedores";
        queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterVendedores]", typeof(string));
        queryParameter4.Name = "@filtroClientes";
        queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterClientes]", typeof(string));
        queryParameter5.Name = "@filtroFechaInicio";
        queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaInicial]", typeof(string));
        queryParameter6.Name = "@filtroFechaFin";
        queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaFinal]", typeof(string));
        queryParameter7.Name = "@filtroConsulta";
        queryParameter7.Type = typeof(int);
        queryParameter7.ValueInfo = "1";
        storedProcQuery1.Parameters.Add(queryParameter1);
        storedProcQuery1.Parameters.Add(queryParameter2);
        storedProcQuery1.Parameters.Add(queryParameter3);
        storedProcQuery1.Parameters.Add(queryParameter4);
        storedProcQuery1.Parameters.Add(queryParameter5);
        storedProcQuery1.Parameters.Add(queryParameter6);
        storedProcQuery1.Parameters.Add(queryParameter7);
        storedProcQuery1.StoredProcName = "stpr_RW002Ventas";
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
        // 
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel83});
        this.groupHeaderBand1.Dpi = 100F;
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CEDI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.HeightF = 15F;
        this.groupHeaderBand1.Level = 4;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        // 
        // xrLabel2
        // 
        this.xrLabel2.CanGrow = false;
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.CEDI")});
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(150.0833F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(904.9166F, 15F);
        this.xrLabel2.StyleName = "DataField";
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "xrLabel2";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel83
        // 
        this.xrLabel83.CanGrow = false;
        this.xrLabel83.Dpi = 100F;
        this.xrLabel83.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel83.Name = "xrLabel83";
        this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel83.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel83.StyleName = "FieldCaption";
        this.xrLabel83.StylePriority.UseFont = false;
        this.xrLabel83.StylePriority.UseTextAlignment = false;
        this.xrLabel83.Text = "Centro De Distribución:";
        this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // groupHeaderBand2
        // 
        this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel84});
        this.groupHeaderBand2.Dpi = 100F;
        this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand2.HeightF = 15F;
        this.groupHeaderBand2.Level = 2;
        this.groupHeaderBand2.Name = "groupHeaderBand2";
        // 
        // xrLabel4
        // 
        this.xrLabel4.CanGrow = false;
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Vendedor")});
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(150.0833F, 0F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(904.9172F, 15F);
        this.xrLabel4.StyleName = "DataField";
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "xrLabel4";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel84
        // 
        this.xrLabel84.CanGrow = false;
        this.xrLabel84.Dpi = 100F;
        this.xrLabel84.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(40F, 0F);
        this.xrLabel84.Name = "xrLabel84";
        this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel84.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel84.StyleName = "FieldCaption";
        this.xrLabel84.StylePriority.UseFont = false;
        this.xrLabel84.StylePriority.UseTextAlignment = false;
        this.xrLabel84.Text = "Vendedor:";
        this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // groupHeaderBand3
        // 
        this.groupHeaderBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel85});
        this.groupHeaderBand3.Dpi = 100F;
        this.groupHeaderBand3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Fecha", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand3.HeightF = 15F;
        this.groupHeaderBand3.Level = 3;
        this.groupHeaderBand3.Name = "groupHeaderBand3";
        // 
        // xrLabel6
        // 
        this.xrLabel6.CanGrow = false;
        this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Fecha", "{0:dd/MM/yyyy}")});
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(150.0833F, 0F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(904.9172F, 15F);
        this.xrLabel6.StyleName = "DataField";
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "xrLabel6";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel85
        // 
        this.xrLabel85.CanGrow = false;
        this.xrLabel85.Dpi = 100F;
        this.xrLabel85.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(20F, 0F);
        this.xrLabel85.Name = "xrLabel85";
        this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel85.SizeF = new System.Drawing.SizeF(45F, 15F);
        this.xrLabel85.StyleName = "FieldCaption";
        this.xrLabel85.StylePriority.UseFont = false;
        this.xrLabel85.StylePriority.UseTextAlignment = false;
        this.xrLabel85.Text = "Fecha:";
        this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // groupHeaderBand4
        // 
        this.groupHeaderBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel86});
        this.groupHeaderBand4.Dpi = 100F;
        this.groupHeaderBand4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Ruta", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand4.HeightF = 15F;
        this.groupHeaderBand4.Level = 1;
        this.groupHeaderBand4.Name = "groupHeaderBand4";
        // 
        // xrLabel8
        // 
        this.xrLabel8.CanGrow = false;
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Ruta")});
        this.xrLabel8.Dpi = 100F;
        this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(150.0833F, 0F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(904.9172F, 15F);
        this.xrLabel8.StyleName = "DataField";
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "xrLabel8";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel86
        // 
        this.xrLabel86.CanGrow = false;
        this.xrLabel86.Dpi = 100F;
        this.xrLabel86.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(60F, 0F);
        this.xrLabel86.Name = "xrLabel86";
        this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel86.SizeF = new System.Drawing.SizeF(40F, 15F);
        this.xrLabel86.StyleName = "FieldCaption";
        this.xrLabel86.StylePriority.UseFont = false;
        this.xrLabel86.StylePriority.UseTextAlignment = false;
        this.xrLabel86.Text = "Ruta:";
        this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // pageFooterBand1
        // 
        this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
        this.pageFooterBand1.Dpi = 100F;
        this.pageFooterBand1.HeightF = 15F;
        this.pageFooterBand1.Name = "pageFooterBand1";
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
        // xrPageInfo2
        // 
        this.xrPageInfo2.Dpi = 100F;
        this.xrPageInfo2.Format = "Página {0} de {1}";
        this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(950.0002F, 0F);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.StylePriority.UseTextAlignment = false;
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.empresa,
            this.filtro,
            this.fecha,
            this.centro,
            this.nameFiltro,
            this.xrLabel70,
            this.xrLabel69,
            this.reporte,
            this.logo});
        this.reportHeaderBand1.Dpi = 100F;
        this.reportHeaderBand1.HeightF = 145F;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        // 
        // empresa
        // 
        this.empresa.CanGrow = false;
        this.empresa.Dpi = 100F;
        this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
        this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(300F, 14.99998F);
        this.empresa.Name = "empresa";
        this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
        this.empresa.StylePriority.UseFont = false;
        this.empresa.StylePriority.UseTextAlignment = false;
        this.empresa.Text = "empresa";
        this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // filtro
        // 
        this.filtro.CanGrow = false;
        this.filtro.Dpi = 100F;
        this.filtro.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.filtro.LocationFloat = new DevExpress.Utils.PointFloat(150.7087F, 130F);
        this.filtro.Name = "filtro";
        this.filtro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.filtro.SizeF = new System.Drawing.SizeF(904.2913F, 15F);
        this.filtro.StylePriority.UseFont = false;
        this.filtro.StylePriority.UseTextAlignment = false;
        this.filtro.Text = "filtro";
        this.filtro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // fecha
        // 
        this.fecha.CanGrow = false;
        this.fecha.Dpi = 100F;
        this.fecha.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(150.5837F, 115F);
        this.fecha.Name = "fecha";
        this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.fecha.SizeF = new System.Drawing.SizeF(904.4163F, 15.00001F);
        this.fecha.StylePriority.UseFont = false;
        this.fecha.StylePriority.UseTextAlignment = false;
        this.fecha.Text = "fecha";
        this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // centro
        // 
        this.centro.CanGrow = false;
        this.centro.Dpi = 100F;
        this.centro.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.centro.LocationFloat = new DevExpress.Utils.PointFloat(150.7087F, 99.99997F);
        this.centro.Name = "centro";
        this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.centro.SizeF = new System.Drawing.SizeF(904.2913F, 15F);
        this.centro.StylePriority.UseFont = false;
        this.centro.StylePriority.UseTextAlignment = false;
        this.centro.Text = "centro";
        this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // nameFiltro
        // 
        this.nameFiltro.CanGrow = false;
        this.nameFiltro.Dpi = 100F;
        this.nameFiltro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.nameFiltro.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
        this.nameFiltro.Name = "nameFiltro";
        this.nameFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.nameFiltro.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.nameFiltro.StylePriority.UseFont = false;
        this.nameFiltro.StylePriority.UseTextAlignment = false;
        this.nameFiltro.Text = "nameFiltro";
        this.nameFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel70
        // 
        this.xrLabel70.CanGrow = false;
        this.xrLabel70.Dpi = 100F;
        this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
        this.xrLabel70.Name = "xrLabel70";
        this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel70.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel70.StylePriority.UseFont = false;
        this.xrLabel70.StylePriority.UseTextAlignment = false;
        this.xrLabel70.Text = "Fecha:";
        this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel69
        // 
        this.xrLabel69.CanGrow = false;
        this.xrLabel69.Dpi = 100F;
        this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(0F, 99.99997F);
        this.xrLabel69.Name = "xrLabel69";
        this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel69.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel69.StylePriority.UseFont = false;
        this.xrLabel69.StylePriority.UseTextAlignment = false;
        this.xrLabel69.Text = "Centro De Distribución:";
        this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // reporte
        // 
        this.reporte.CanGrow = false;
        this.reporte.Dpi = 100F;
        this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
        this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(300F, 54.99998F);
        this.reporte.Name = "reporte";
        this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
        this.reporte.StyleName = "Title";
        this.reporte.StylePriority.UseFont = false;
        this.reporte.StylePriority.UseTextAlignment = false;
        this.reporte.Text = "reporte";
        this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // logo
        // 
        this.logo.Dpi = 100F;
        this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 14.99998F);
        this.logo.Name = "logo";
        this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
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
            this.xrLabel46,
            this.xrLabel47});
        this.groupFooterBand2.Dpi = 100F;
        this.groupFooterBand2.HeightF = 15F;
        this.groupFooterBand2.Level = 1;
        this.groupFooterBand2.Name = "groupFooterBand2";
        // 
        // xrLabel46
        // 
        this.xrLabel46.CanGrow = false;
        this.xrLabel46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Total")});
        this.xrLabel46.Dpi = 100F;
        this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(970.0002F, 0F);
        this.xrLabel46.Name = "xrLabel46";
        this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel46.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel46.StyleName = "FieldCaption";
        this.xrLabel46.StylePriority.UseFont = false;
        this.xrLabel46.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:$#,##0.00}";
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel46.Summary = xrSummary1;
        this.xrLabel46.Text = "xrLabel46";
        this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel47
        // 
        this.xrLabel47.CanGrow = false;
        this.xrLabel47.Dpi = 100F;
        this.xrLabel47.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(870.0002F, 0F);
        this.xrLabel47.Name = "xrLabel47";
        this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel47.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel47.StyleName = "FieldCaption";
        this.xrLabel47.StylePriority.UseFont = false;
        this.xrLabel47.StylePriority.UseTextAlignment = false;
        this.xrLabel47.Text = "GRAN TOTAL:";
        this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // parameterCEDIS
        // 
        this.parameterCEDIS.Name = "parameterCEDIS";
        this.parameterCEDIS.ValueInfo = "44H5SO2UWRTK6+1";
        this.parameterCEDIS.Visible = false;
        // 
        // parameterRutas
        // 
        this.parameterRutas.Name = "parameterRutas";
        this.parameterRutas.Visible = false;
        // 
        // parameterVendedores
        // 
        this.parameterVendedores.Name = "parameterVendedores";
        this.parameterVendedores.ValueInfo = "R-CACH";
        this.parameterVendedores.Visible = false;
        // 
        // parameterClientes
        // 
        this.parameterClientes.Name = "parameterClientes";
        this.parameterClientes.Visible = false;
        // 
        // parameterFechaInicial
        // 
        this.parameterFechaInicial.Name = "parameterFechaInicial";
        this.parameterFechaInicial.Visible = false;
        // 
        // parameterFechaFinal
        // 
        this.parameterFechaFinal.Name = "parameterFechaFinal";
        this.parameterFechaFinal.Visible = false;
        // 
        // groupFooterBand5
        // 
        this.groupFooterBand5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel9,
            this.xrLabel61,
            this.xrLabel62,
            this.R002VentasPedidosPorProducto});
        this.groupFooterBand5.Dpi = 100F;
        this.groupFooterBand5.HeightF = 90F;
        this.groupFooterBand5.Level = 4;
        this.groupFooterBand5.Name = "groupFooterBand5";
        this.groupFooterBand5.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
        // 
        // xrLabel18
        // 
        this.xrLabel18.CanGrow = false;
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.TransProdID")});
        this.xrLabel18.Dpi = 100F;
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(950.0002F, 30F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:#,#}";
        xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.DCount;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel18.Summary = xrSummary2;
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel17
        // 
        this.xrLabel17.CanGrow = false;
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.XTotalCredito", "{0:$#,##0.00}")});
        this.xrLabel17.Dpi = 100F;
        this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(950.0002F, 75F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "xrLabel17";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel16
        // 
        this.xrLabel16.CanGrow = false;
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.XTotalContado", "{0:$#,##0.00}")});
        this.xrLabel16.Dpi = 100F;
        this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(955F, 60F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "xrLabel16";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel14
        // 
        this.xrLabel14.CanGrow = false;
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(850.0002F, 45F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel14.StyleName = "FieldCaption";
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Total Vendido:";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel13
        // 
        this.xrLabel13.CanGrow = false;
        this.xrLabel13.Dpi = 100F;
        this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(850.0002F, 75F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel13.StyleName = "FieldCaption";
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Total Credito:";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel9
        // 
        this.xrLabel9.CanGrow = false;
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(850.0002F, 60F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel9.StyleName = "FieldCaption";
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Total Contado:";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel61
        // 
        this.xrLabel61.CanGrow = false;
        this.xrLabel61.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Total")});
        this.xrLabel61.Dpi = 100F;
        this.xrLabel61.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(950.0002F, 45F);
        this.xrLabel61.Name = "xrLabel61";
        this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel61.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel61.StyleName = "FieldCaption";
        this.xrLabel61.StylePriority.UseFont = false;
        this.xrLabel61.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:$#,##0.00}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel61.Summary = xrSummary3;
        this.xrLabel61.Text = "xrLabel61";
        this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel62
        // 
        this.xrLabel62.CanGrow = false;
        this.xrLabel62.Dpi = 100F;
        this.xrLabel62.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(850.0002F, 30F);
        this.xrLabel62.Name = "xrLabel62";
        this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel62.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel62.StyleName = "FieldCaption";
        this.xrLabel62.StylePriority.UseFont = false;
        this.xrLabel62.StylePriority.UseTextAlignment = false;
        this.xrLabel62.Text = "Total Folios:";
        this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // reportFooterBand1
        // 
        this.reportFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel66,
            this.xrLabel67});
        this.reportFooterBand1.Dpi = 100F;
        this.reportFooterBand1.HeightF = 15F;
        this.reportFooterBand1.Name = "reportFooterBand1";
        // 
        // xrLabel66
        // 
        this.xrLabel66.CanGrow = false;
        this.xrLabel66.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Total")});
        this.xrLabel66.Dpi = 100F;
        this.xrLabel66.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(950.0002F, 0F);
        this.xrLabel66.Name = "xrLabel66";
        this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel66.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel66.StyleName = "FieldCaption";
        this.xrLabel66.StylePriority.UseFont = false;
        this.xrLabel66.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:$#,##0.00}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel66.Summary = xrSummary4;
        this.xrLabel66.Text = "xrLabel66";
        this.xrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel67
        // 
        this.xrLabel67.CanGrow = false;
        this.xrLabel67.Dpi = 100F;
        this.xrLabel67.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(750.0002F, 0F);
        this.xrLabel67.Name = "xrLabel67";
        this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel67.SizeF = new System.Drawing.SizeF(200F, 15F);
        this.xrLabel67.StyleName = "FieldCaption";
        this.xrLabel67.StylePriority.UseFont = false;
        this.xrLabel67.StylePriority.UseTextAlignment = false;
        this.xrLabel67.Text = "Gran Total Centro de Distribucion:";
        this.xrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel75,
            this.xrLabel68,
            this.xrLabelSubE,
            this.xrLabel74,
            this.xrLabel44,
            this.xrLabel77,
            this.xrLabel78,
            this.xrLabel79,
            this.xrLabel80,
            this.xrLabel81,
            this.xrLabel82,
            this.xrLabelKiloE});
        this.PageHeader.Dpi = 100F;
        this.PageHeader.HeightF = 42.91666F;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.PrintOn = DevExpress.XtraReports.UI.PrintOnPages.NotWithReportFooter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel1.BorderWidth = 2F;
        this.xrLabel1.CanGrow = false;
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(890.0001F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(80F, 42.91666F);
        this.xrLabel1.StylePriority.UseBorders = false;
        this.xrLabel1.StylePriority.UseBorderWidth = false;
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "Forma Venta";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel75
        // 
        this.xrLabel75.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel75.BorderWidth = 2F;
        this.xrLabel75.CanGrow = false;
        this.xrLabel75.Dpi = 100F;
        this.xrLabel75.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(350F, 0F);
        this.xrLabel75.Name = "xrLabel75";
        this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel75.SizeF = new System.Drawing.SizeF(60F, 42.91666F);
        this.xrLabel75.StylePriority.UseBorders = false;
        this.xrLabel75.StylePriority.UseBorderWidth = false;
        this.xrLabel75.StylePriority.UseFont = false;
        this.xrLabel75.StylePriority.UseTextAlignment = false;
        this.xrLabel75.Text = "P.U.";
        this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel68
        // 
        this.xrLabel68.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel68.BorderWidth = 2F;
        this.xrLabel68.CanGrow = false;
        this.xrLabel68.Dpi = 100F;
        this.xrLabel68.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(970.0001F, 0F);
        this.xrLabel68.Name = "xrLabel68";
        this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel68.SizeF = new System.Drawing.SizeF(80F, 42.91666F);
        this.xrLabel68.StylePriority.UseBorders = false;
        this.xrLabel68.StylePriority.UseBorderWidth = false;
        this.xrLabel68.StylePriority.UseFont = false;
        this.xrLabel68.StylePriority.UseTextAlignment = false;
        this.xrLabel68.Text = "Total";
        this.xrLabel68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabelSubE
        // 
        this.xrLabelSubE.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabelSubE.BorderWidth = 2F;
        this.xrLabelSubE.CanGrow = false;
        this.xrLabelSubE.Dpi = 100F;
        this.xrLabelSubE.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabelSubE.LocationFloat = new DevExpress.Utils.PointFloat(530F, 0F);
        this.xrLabelSubE.Name = "xrLabelSubE";
        this.xrLabelSubE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelSubE.SizeF = new System.Drawing.SizeF(70F, 42.91666F);
        this.xrLabelSubE.StylePriority.UseBorders = false;
        this.xrLabelSubE.StylePriority.UseBorderWidth = false;
        this.xrLabelSubE.StylePriority.UseFont = false;
        this.xrLabelSubE.StylePriority.UseTextAlignment = false;
        this.xrLabelSubE.Text = "Subtotal";
        this.xrLabelSubE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel74
        // 
        this.xrLabel74.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel74.BorderWidth = 2F;
        this.xrLabel74.CanGrow = false;
        this.xrLabel74.Dpi = 100F;
        this.xrLabel74.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(70F, 0F);
        this.xrLabel74.Name = "xrLabel74";
        this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel74.SizeF = new System.Drawing.SizeF(220F, 42.91666F);
        this.xrLabel74.StylePriority.UseBorders = false;
        this.xrLabel74.StylePriority.UseBorderWidth = false;
        this.xrLabel74.StylePriority.UseFont = false;
        this.xrLabel74.StylePriority.UseTextAlignment = false;
        this.xrLabel74.Text = "Producto";
        this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel44
        // 
        this.xrLabel44.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel44.BorderWidth = 2F;
        this.xrLabel44.CanGrow = false;
        this.xrLabel44.Dpi = 100F;
        this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(410F, 0F);
        this.xrLabel44.Name = "xrLabel44";
        this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel44.SizeF = new System.Drawing.SizeF(60F, 42.91666F);
        this.xrLabel44.StylePriority.UseBorders = false;
        this.xrLabel44.StylePriority.UseBorderWidth = false;
        this.xrLabel44.StylePriority.UseFont = false;
        this.xrLabel44.StylePriority.UseTextAlignment = false;
        this.xrLabel44.Text = "Cantidad";
        this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel77
        // 
        this.xrLabel77.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel77.BorderWidth = 2F;
        this.xrLabel77.CanGrow = false;
        this.xrLabel77.Dpi = 100F;
        this.xrLabel77.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(820F, 0F);
        this.xrLabel77.Name = "xrLabel77";
        this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel77.SizeF = new System.Drawing.SizeF(70F, 42.91666F);
        this.xrLabel77.StylePriority.UseBorders = false;
        this.xrLabel77.StylePriority.UseBorderWidth = false;
        this.xrLabel77.StylePriority.UseFont = false;
        this.xrLabel77.StylePriority.UseTextAlignment = false;
        this.xrLabel77.Text = "Impuesto";
        this.xrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel78
        // 
        this.xrLabel78.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel78.BorderWidth = 2F;
        this.xrLabel78.CanGrow = false;
        this.xrLabel78.Dpi = 100F;
        this.xrLabel78.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(749.7917F, 0F);
        this.xrLabel78.Multiline = true;
        this.xrLabel78.Name = "xrLabel78";
        this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel78.SizeF = new System.Drawing.SizeF(70.20831F, 42.91666F);
        this.xrLabel78.StylePriority.UseBorders = false;
        this.xrLabel78.StylePriority.UseBorderWidth = false;
        this.xrLabel78.StylePriority.UseFont = false;
        this.xrLabel78.StylePriority.UseTextAlignment = false;
        this.xrLabel78.Text = "Desc. \r\nVendedor";
        this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel79
        // 
        this.xrLabel79.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel79.BorderWidth = 2F;
        this.xrLabel79.CanGrow = false;
        this.xrLabel79.Dpi = 100F;
        this.xrLabel79.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(675.4166F, 0F);
        this.xrLabel79.Multiline = true;
        this.xrLabel79.Name = "xrLabel79";
        this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel79.SizeF = new System.Drawing.SizeF(74.58344F, 42.91666F);
        this.xrLabel79.StylePriority.UseBorders = false;
        this.xrLabel79.StylePriority.UseBorderWidth = false;
        this.xrLabel79.StylePriority.UseFont = false;
        this.xrLabel79.StylePriority.UseTextAlignment = false;
        this.xrLabel79.Text = "Desc. \r\nCliente";
        this.xrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel80
        // 
        this.xrLabel80.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel80.BorderWidth = 2F;
        this.xrLabel80.CanGrow = false;
        this.xrLabel80.Dpi = 100F;
        this.xrLabel80.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel80.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
        this.xrLabel80.Multiline = true;
        this.xrLabel80.Name = "xrLabel80";
        this.xrLabel80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel80.SizeF = new System.Drawing.SizeF(75.41663F, 42.91666F);
        this.xrLabel80.StylePriority.UseBorders = false;
        this.xrLabel80.StylePriority.UseBorderWidth = false;
        this.xrLabel80.StylePriority.UseFont = false;
        this.xrLabel80.StylePriority.UseTextAlignment = false;
        this.xrLabel80.Text = "Desc. \r\nProducto";
        this.xrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel81
        // 
        this.xrLabel81.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel81.BorderWidth = 2F;
        this.xrLabel81.CanGrow = false;
        this.xrLabel81.Dpi = 100F;
        this.xrLabel81.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel81.Name = "xrLabel81";
        this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel81.SizeF = new System.Drawing.SizeF(70F, 42.91666F);
        this.xrLabel81.StylePriority.UseBorders = false;
        this.xrLabel81.StylePriority.UseBorderWidth = false;
        this.xrLabel81.StylePriority.UseFont = false;
        this.xrLabel81.StylePriority.UseTextAlignment = false;
        this.xrLabel81.Text = "Clave";
        this.xrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel82
        // 
        this.xrLabel82.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel82.BorderWidth = 2F;
        this.xrLabel82.CanGrow = false;
        this.xrLabel82.Dpi = 100F;
        this.xrLabel82.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(290F, 0F);
        this.xrLabel82.Name = "xrLabel82";
        this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel82.SizeF = new System.Drawing.SizeF(60F, 42.91666F);
        this.xrLabel82.StylePriority.UseBorders = false;
        this.xrLabel82.StylePriority.UseBorderWidth = false;
        this.xrLabel82.StylePriority.UseFont = false;
        this.xrLabel82.StylePriority.UseTextAlignment = false;
        this.xrLabel82.Text = "Unidad";
        this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabelKiloE
        // 
        this.xrLabelKiloE.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabelKiloE.BorderWidth = 2F;
        this.xrLabelKiloE.CanGrow = false;
        this.xrLabelKiloE.Dpi = 100F;
        this.xrLabelKiloE.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabelKiloE.LocationFloat = new DevExpress.Utils.PointFloat(470F, 0F);
        this.xrLabelKiloE.Name = "xrLabelKiloE";
        this.xrLabelKiloE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelKiloE.SizeF = new System.Drawing.SizeF(60F, 42.91666F);
        this.xrLabelKiloE.StylePriority.UseBorders = false;
        this.xrLabelKiloE.StylePriority.UseBorderWidth = false;
        this.xrLabelKiloE.StylePriority.UseFont = false;
        this.xrLabelKiloE.StylePriority.UseTextAlignment = false;
        this.xrLabelKiloE.Text = "Kilo/Litro";
        this.xrLabelKiloE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // groupHeaderBand5
        // 
        this.groupHeaderBand5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLabel87,
            this.xrLabel11,
            this.xrLabel12});
        this.groupHeaderBand5.Dpi = 100F;
        this.groupHeaderBand5.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Folio", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Cliente", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand5.HeightF = 15F;
        this.groupHeaderBand5.Name = "groupHeaderBand5";
        // 
        // xrLabel10
        // 
        this.xrLabel10.CanGrow = false;
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(240F, 3.814697E-06F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel10.StyleName = "FieldCaption";
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Cliente:";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel87
        // 
        this.xrLabel87.CanGrow = false;
        this.xrLabel87.Dpi = 100F;
        this.xrLabel87.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
        this.xrLabel87.Name = "xrLabel87";
        this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel87.SizeF = new System.Drawing.SizeF(40F, 15F);
        this.xrLabel87.StyleName = "FieldCaption";
        this.xrLabel87.StylePriority.UseFont = false;
        this.xrLabel87.StylePriority.UseTextAlignment = false;
        this.xrLabel87.Text = "Folio:";
        this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel11
        // 
        this.xrLabel11.CanGrow = false;
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Folio")});
        this.xrLabel11.Dpi = 100F;
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(120F, 0F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel11.StyleName = "DataField";
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "xrLabel11";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel12
        // 
        this.xrLabel12.CanGrow = false;
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Cliente")});
        this.xrLabel12.Dpi = 100F;
        this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(290.0833F, 0F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(764.9169F, 15F);
        this.xrLabel12.StyleName = "DataField";
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "xrLabel12";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // groupFooterBand0
        // 
        this.groupFooterBand0.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.xrLabel15,
            this.xrLabel7,
            this.xrLabel5});
        this.groupFooterBand0.Dpi = 100F;
        this.groupFooterBand0.HeightF = 15F;
        this.groupFooterBand0.Name = "groupFooterBand0";
        // 
        // xrLabel19
        // 
        this.xrLabel19.CanGrow = false;
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.SubTotal")});
        this.xrLabel19.Dpi = 100F;
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(510F, 0F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel19.StyleName = "FieldCaption";
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:$#,##0.00}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel19.Summary = xrSummary5;
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel15
        // 
        this.xrLabel15.CanGrow = false;
        this.xrLabel15.Dpi = 100F;
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(410F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel15.StyleName = "FieldCaption";
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "Subtotal:";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel7
        // 
        this.xrLabel7.CanGrow = false;
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(870.0002F, 0F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrLabel7.StyleName = "FieldCaption";
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Total:";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel5
        // 
        this.xrLabel5.CanGrow = false;
        this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW002Ventas.Total")});
        this.xrLabel5.Dpi = 100F;
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(970.0002F, 0F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel5.StyleName = "FieldCaption";
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:$#,##0.00}";
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel5.Summary = xrSummary6;
        this.xrLabel5.Text = "xrLabel46";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // XTotalContado
        // 
        this.XTotalContado.DataMember = "stpr_RW002Ventas";
        this.XTotalContado.Expression = "[].Sum(Iif([FormaVenta] == \'Contado\' , [Total], 0))";
        this.XTotalContado.Name = "XTotalContado";
        // 
        // XTotalCredito
        // 
        this.XTotalCredito.DataMember = "stpr_RW002Ventas";
        this.XTotalCredito.Expression = "[].Sum(Iif(([FormaVenta] == \'Credito\') Or ([FormaVenta] == \'Crédito\') , [Total], " +
"0))";
        this.XTotalCredito.Name = "XTotalCredito";
        // 
        // R002VentasPedidosPorProducto
        // 
        this.R002VentasPedidosPorProducto.Dpi = 100F;
        this.R002VentasPedidosPorProducto.LocationFloat = new DevExpress.Utils.PointFloat(108.2083F, 0F);
        this.R002VentasPedidosPorProducto.Name = "R002VentasPedidosPorProducto";
        this.R002VentasPedidosPorProducto.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterCEDIS", this.parameterCEDIS));
        this.R002VentasPedidosPorProducto.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterRutas", this.parameterRutas));
        this.R002VentasPedidosPorProducto.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
        this.R002VentasPedidosPorProducto.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterClientes", this.parameterClientes));
        this.R002VentasPedidosPorProducto.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaInicial", this.parameterFechaInicial));
        this.R002VentasPedidosPorProducto.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFechaFinal", this.parameterFechaFinal));
        this.R002VentasPedidosPorProducto.ReportSource = new R002VentasPedidosPorProducto();
        this.R002VentasPedidosPorProducto.SizeF = new System.Drawing.SizeF(830F, 30F);
        // 
        // R002VentasDetallado
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.groupHeaderBand4,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand2,
            this.groupFooterBand5,
            this.reportFooterBand1,
            this.PageHeader,
            this.groupHeaderBand5,
            this.groupFooterBand0});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.XTotalContado,
            this.XTotalCredito});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
        this.DataMember = "stpr_RW002Ventas";
        this.DataSource = this.sqlDataSource1;
        this.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(22, 23, 5, 5);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCEDIS,
            this.parameterRutas,
            this.parameterVendedores,
            this.parameterClientes,
            this.parameterFechaInicial,
            this.parameterFechaFinal});
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "16.1";
        this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.VentasDetallado02_DataSourceDemanded);
        this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.VentasDetallado02_BeforePrint);
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }


    #endregion

    private int CountRows()
    {
        StringBuilder sConsulta = new StringBuilder();
        sConsulta.AppendLine("EXEC [dbo].[stpr_RW002Ventas] ");
        sConsulta.AppendLine("@filtroCEDIS = '" + this.CEDIS + "', ");
        sConsulta.AppendLine("@filtroRutas = '" + this.Rutas + "', ");
        sConsulta.AppendLine("@filtroVendedores = '" + this.Vendedores + "', ");
        sConsulta.AppendLine("@filtroClientes = '" + this.Clientes + "', ");
        sConsulta.AppendLine("@filtroFechaInicio = '" + this.fInicio.Date.ToString("yyyy-MM-dd") + "', ");
        sConsulta.AppendLine("@filtroFechaFin = '" + this.fFin.Date.ToString("yyyy-MM-dd") + "', ");
        sConsulta.AppendLine("@filtroConsulta = 1");
        QueryString = sConsulta.ToString();
        List<ObjectModel> objectData = Connection.Query<ObjectModel>(QueryString, null, null, true, 9000).ToList();
        return objectData.Count;
    }

    private class ObjectModel
    {
        public string CEDI { get; set; }
    }
    private void VentasDetallado02_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterCEDIS"].Value = this.CEDIS;
        this.Parameters["parameterRutas"].Value = this.Rutas;
        this.Parameters["parameterVendedores"].Value = this.Vendedores;
        this.Parameters["parameterClientes"].Value = this.Clientes;
        this.Parameters["parameterFechaInicial"].Value = this.fInicio.Date.ToString("yyyy-MM-dd");
        this.Parameters["parameterFechaFinal"].Value = this.fFin.Date.ToString("yyyy-MM-dd");
    }

    private void VentasDetallado02_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        bool pvConversionKG = Connection.Query<int>("SELECT TOP 1 ConversionKg FROM ConHist (NOLOCK) ORDER BY MFechaHora DESC", null, null, true, 600).FirstOrDefault() == 0;
        if (pvConversionKG)
        {
            xrLabelKiloE.Visible = false;
            xrLabelKiloD.Visible = false;
            xrLabelSubE.SizeF = new System.Drawing.SizeF(130F, 42.91666F);
            xrLabelSubE.LocationFloat = new DevExpress.Utils.PointFloat(470F, 0F);
            xrLabelSubD.SizeF = new System.Drawing.SizeF(90F, 20F);
            xrLabelSubD.LocationFloat = new DevExpress.Utils.PointFloat(470F, 0F);
        }
        string FechaInicial = this.fInicio.Date.ToShortDateString();
        string FechaFinal = this.fFin.Date.ToShortDateString();
        this.empresa.Text = this.NombreEmpresa;
        this.logo.Image = Image.FromStream(this.LogoEmpresa);
        this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        this.fecha.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);
        this.centro.Text = this.NombreCEDIS;
        this.reporte.Text = this.NombreReporte;
        if (FiltroReporte)
        {
            this.nameFiltro.Text = "Vendedor: ";
            this.filtro.Text = this.NombreVendedor;
        }
        else
        {
            this.nameFiltro.Text = "Ruta(s): ";
            this.filtro.Text = (this.Rutas == "" ? "Todas las Rutas" : this.Rutas);
        }
    }
}
