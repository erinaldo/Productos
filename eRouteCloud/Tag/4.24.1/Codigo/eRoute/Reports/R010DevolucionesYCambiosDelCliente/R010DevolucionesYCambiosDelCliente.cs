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
/// Summary description for R010DevolucionesYCambiosDelCliente
/// </summary>
public class R010DevolucionesYCambiosDelCliente : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabelCantCD;
    private XRLabel xrLabelCantDD;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabelKiloCD;
    private XRLabel xrLabelKiloDD;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand2;
    private GroupHeaderBand groupHeaderBand3;
    private GroupHeaderBand groupHeaderBand4;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private XRLabel xrLabelCantCS;
    private XRLabel xrLabelCantDS;
    private XRLabel xrLabel45;
    private XRLabel xrLabel46;
    private XRLabel xrLabelKiloCS;
    private XRLabel xrLabelKiloDS;
    private XRLabel xrLabel52;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.XtraReports.Parameters.Parameter parameterCEDIS;
    private DevExpress.XtraReports.Parameters.Parameter parameterRutas;
    private DevExpress.XtraReports.Parameters.Parameter parameterProductos;
    private DevExpress.XtraReports.Parameters.Parameter parameterProductosEsquemas;
    private DevExpress.XtraReports.Parameters.Parameter parameterClientes;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicial;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaFinal;
    private XRPictureBox logo;
    private XRLabel reporte;
    private XRLabel labelCedis;
    private XRLabel labelFecha;
    private XRLabel labelRuta;
    private XRLabel cedis;
    private XRLabel fechas;
    private XRLabel rutas;
    private XRLabel empresa;
    private XRLabel clientes;
    private XRLabel productos;
    private XRLabel segmentos;
    private XRLabel labelCliente;
    private XRLabel labelProducto;
    private XRLabel labelSegmento;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel41;
    private XRLabel xrLabel97;
    private XRLabel xrLabelKiloCE;
    private XRLabel xrLabelCantCE;
    private XRLabel xrLabel99;
    private XRLabel xrLabelCantDE;
    private XRLabel xrLabel101;
    private XRLabel xrLabel102;
    private XRLabel xrLabel103;
    private XRLabel xrLabel104;
    private XRLabel xrLabel105;
    private XRLabel xrLabel106;
    private XRLabel xrLabel107;
    private XRLabel xrLabel3;
    private XRLabel xrLabel6;
    private XRLabel xrLabel4;
    private XRLabel xrLabel8;
    private XRLabel xrLabel12;
    private XRLabel xrLabel10;
    private XRLabel xrLabelKiloDE;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;

    private string CEDIS;
    private string Rutas;
    private string Productos;
    private string ProductosEsquemas;
    private string Clientes;
    private string NombreCEDIS;
    private string NombreReporte;
    private string NombreEmpresa;
    private string QueryString;
    private MemoryStream LogoEmpresa;
    private DateTime fInicio;
    private DateTime fFin;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

    public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string CEDIS, string FechaInicial, string FechaFinal, string Rutas, string Productos, string ProductosEsquemas, string Clientes)
    {
        this.fInicio = DateTime.Parse(FechaInicial);
        this.fFin = DateTime.Parse(FechaFinal);
        this.CEDIS = CEDIS;
        this.Rutas = Rutas;
        this.Productos = Productos;
        this.ProductosEsquemas = ProductosEsquemas;
        this.Clientes = Clientes;
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
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R010DevolucionesYCambiosDelCliente));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabelCantCD = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelCantDD = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelKiloCD = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelKiloDD = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.labelRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.cedis = new DevExpress.XtraReports.UI.XRLabel();
            this.fechas = new DevExpress.XtraReports.UI.XRLabel();
            this.rutas = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.clientes = new DevExpress.XtraReports.UI.XRLabel();
            this.productos = new DevExpress.XtraReports.UI.XRLabel();
            this.segmentos = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSegmento = new DevExpress.XtraReports.UI.XRLabel();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabelCantCS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelCantDS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelKiloCS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelKiloDS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.parameterCEDIS = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRutas = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterProductos = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterProductosEsquemas = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterClientes = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterFechaInicial = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterFechaFinal = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabelKiloDE = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel97 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelKiloCE = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelCantCE = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel99 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelCantDE = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel101 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel102 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel103 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel104 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel105 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel106 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel107 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelCantCD,
            this.xrLabelCantDD,
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabelKiloCD,
            this.xrLabelKiloDD,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 15F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelCantCD
            // 
            this.xrLabelCantCD.CanGrow = false;
            this.xrLabelCantCD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.CambioCantidad", "{0:n}")});
            this.xrLabelCantCD.Dpi = 100F;
            this.xrLabelCantCD.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabelCantCD.LocationFloat = new DevExpress.Utils.PointFloat(770F, 0F);
            this.xrLabelCantCD.Name = "xrLabelCantCD";
            this.xrLabelCantCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelCantCD.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelCantCD.StylePriority.UseFont = false;
            this.xrLabelCantCD.StylePriority.UseTextAlignment = false;
            this.xrLabelCantCD.Text = "xrLabelCantCD";
            this.xrLabelCantCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabelCantDD
            // 
            this.xrLabelCantDD.CanGrow = false;
            this.xrLabelCantDD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.DevolucionCantidad", "{0:n}")});
            this.xrLabelCantDD.Dpi = 100F;
            this.xrLabelCantDD.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabelCantDD.LocationFloat = new DevExpress.Utils.PointFloat(460F, 0F);
            this.xrLabelCantDD.Name = "xrLabelCantDD";
            this.xrLabelCantDD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelCantDD.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelCantDD.StylePriority.UseFont = false;
            this.xrLabelCantDD.StylePriority.UseTextAlignment = false;
            this.xrLabelCantDD.Text = "xrLabelCantDD";
            this.xrLabelCantDD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel29
            // 
            this.xrLabel29.CanGrow = false;
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.CambioImporte", "{0:$#,##0.00}")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(910F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "xrLabel29";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel30
            // 
            this.xrLabel30.CanGrow = false;
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.DevolucionImporte", "{0:$#,##0.00}")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "xrLabel30";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabelKiloCD
            // 
            this.xrLabelKiloCD.CanGrow = false;
            this.xrLabelKiloCD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.CambioKgLtsCantidad", "{0:n}")});
            this.xrLabelKiloCD.Dpi = 100F;
            this.xrLabelKiloCD.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabelKiloCD.LocationFloat = new DevExpress.Utils.PointFloat(840F, 0F);
            this.xrLabelKiloCD.Name = "xrLabelKiloCD";
            this.xrLabelKiloCD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKiloCD.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelKiloCD.StylePriority.UseFont = false;
            this.xrLabelKiloCD.StylePriority.UseTextAlignment = false;
            this.xrLabelKiloCD.Text = "xrLabelKiloCD";
            this.xrLabelKiloCD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabelKiloDD
            // 
            this.xrLabelKiloDD.CanGrow = false;
            this.xrLabelKiloDD.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.DevolucionKgLtsCantidad", "{0:n}")});
            this.xrLabelKiloDD.Dpi = 100F;
            this.xrLabelKiloDD.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabelKiloDD.LocationFloat = new DevExpress.Utils.PointFloat(530F, 0F);
            this.xrLabelKiloDD.Name = "xrLabelKiloDD";
            this.xrLabelKiloDD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKiloDD.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelKiloDD.StylePriority.UseFont = false;
            this.xrLabelKiloDD.StylePriority.UseTextAlignment = false;
            this.xrLabelKiloDD.Text = "xrLabelKiloDD";
            this.xrLabelKiloDD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel33
            // 
            this.xrLabel33.CanGrow = false;
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.CambioMotivo")});
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(980F, 0F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "xrLabel33";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.CanGrow = false;
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.DevolucionMotivo")});
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(670F, 0F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "xrLabel34";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel35
            // 
            this.xrLabel35.CanGrow = false;
            this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.Precio", "{0:$#,##0.00}")});
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(410F, 0F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "xrLabel35";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel36
            // 
            this.xrLabel36.CanGrow = false;
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.ClaveProducto")});
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "xrLabel36";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel37
            // 
            this.xrLabel37.CanGrow = false;
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.NombreProducto")});
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(280F, 15F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "xrLabel37";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel38
            // 
            this.xrLabel38.CanGrow = false;
            this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.Unidad")});
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(360F, 0F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "xrLabel38";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 5000;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_RW010DevolucionesYCambiosDelCliente";
            queryParameter1.Name = "@filtroCEDIS";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCEDIS]", typeof(string));
            queryParameter2.Name = "@filtroRutas";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRutas]", typeof(string));
            queryParameter3.Name = "@filtroProductos";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterProductos]", typeof(string));
            queryParameter4.Name = "@filtroProductosEsquemas";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterProductosEsquemas]", typeof(string));
            queryParameter5.Name = "@filtroClientes";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterClientes]", typeof(string));
            queryParameter6.Name = "@filtroFechaInicio";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaInicial]", typeof(string));
            queryParameter7.Name = "@filtroFechaFin";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaFinal]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.Parameters.Add(queryParameter7);
            storedProcQuery1.StoredProcName = "stpr_RW010DevolucionesYCambiosDelCliente";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel6});
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Fecha", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand2.HeightF = 15F;
            this.groupHeaderBand2.Level = 3;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            // 
            // xrLabel3
            // 
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel3.StyleName = "FieldCaption";
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Fecha:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.Fecha", "{0:dd/MM/yyyy}")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(90F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(990F, 15F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand3
            // 
            this.groupHeaderBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel8});
            this.groupHeaderBand3.Dpi = 100F;
            this.groupHeaderBand3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Ruta", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand3.HeightF = 15F;
            this.groupHeaderBand3.Level = 2;
            this.groupHeaderBand3.Name = "groupHeaderBand3";
            // 
            // xrLabel4
            // 
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(20F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel4.StyleName = "FieldCaption";
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Ruta:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.Ruta")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(90F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(990F, 15F);
            this.xrLabel8.StyleName = "DataField";
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand4
            // 
            this.groupHeaderBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel10});
            this.groupHeaderBand4.Dpi = 100F;
            this.groupHeaderBand4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Cliente", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("RazonSocial", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand4.HeightF = 15F;
            this.groupHeaderBand4.Level = 1;
            this.groupHeaderBand4.Name = "groupHeaderBand4";
            // 
            // xrLabel12
            // 
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.Cliente")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(90F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(990F, 15F);
            this.xrLabel12.StyleName = "DataField";
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(40F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel10.StyleName = "FieldCaption";
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Cliente:";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(980F, 0F);
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
            this.labelCedis,
            this.labelFecha,
            this.labelRuta,
            this.cedis,
            this.fechas,
            this.rutas,
            this.empresa,
            this.clientes,
            this.productos,
            this.segmentos,
            this.labelCliente,
            this.labelProducto,
            this.labelSegmento});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 190F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // reporte
            // 
            this.reporte.CanGrow = false;
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(295F, 50F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelCedis
            // 
            this.labelCedis.CanGrow = false;
            this.labelCedis.Dpi = 100F;
            this.labelCedis.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelCedis.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.labelCedis.Name = "labelCedis";
            this.labelCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCedis.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelCedis.StylePriority.UseFont = false;
            this.labelCedis.StylePriority.UseTextAlignment = false;
            this.labelCedis.Text = "Centro De Distribución:";
            this.labelCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelFecha
            // 
            this.labelFecha.CanGrow = false;
            this.labelFecha.Dpi = 100F;
            this.labelFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFecha.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelFecha.StylePriority.UseFont = false;
            this.labelFecha.StylePriority.UseTextAlignment = false;
            this.labelFecha.Text = "Fecha(s):";
            this.labelFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelRuta
            // 
            this.labelRuta.CanGrow = false;
            this.labelRuta.Dpi = 100F;
            this.labelRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelRuta.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelRuta.StylePriority.UseFont = false;
            this.labelRuta.StylePriority.UseTextAlignment = false;
            this.labelRuta.Text = "Ruta(s):";
            this.labelRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // cedis
            // 
            this.cedis.CanGrow = false;
            this.cedis.Dpi = 100F;
            this.cedis.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.cedis.LocationFloat = new DevExpress.Utils.PointFloat(150F, 100F);
            this.cedis.Name = "cedis";
            this.cedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cedis.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.cedis.StylePriority.UseFont = false;
            this.cedis.StylePriority.UseTextAlignment = false;
            this.cedis.Text = "cedis";
            this.cedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fechas
            // 
            this.fechas.CanGrow = false;
            this.fechas.Dpi = 100F;
            this.fechas.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.fechas.LocationFloat = new DevExpress.Utils.PointFloat(150F, 115F);
            this.fechas.Name = "fechas";
            this.fechas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechas.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.fechas.StylePriority.UseFont = false;
            this.fechas.StylePriority.UseTextAlignment = false;
            this.fechas.Text = "fechas";
            this.fechas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // rutas
            // 
            this.rutas.CanGrow = false;
            this.rutas.Dpi = 100F;
            this.rutas.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.rutas.LocationFloat = new DevExpress.Utils.PointFloat(150F, 130F);
            this.rutas.Name = "rutas";
            this.rutas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rutas.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.rutas.StylePriority.UseFont = false;
            this.rutas.StylePriority.UseTextAlignment = false;
            this.rutas.Text = "rutas";
            this.rutas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // empresa
            // 
            this.empresa.CanGrow = false;
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(295F, 10F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // clientes
            // 
            this.clientes.CanGrow = false;
            this.clientes.Dpi = 100F;
            this.clientes.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.clientes.LocationFloat = new DevExpress.Utils.PointFloat(150F, 175F);
            this.clientes.Name = "clientes";
            this.clientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientes.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.clientes.StylePriority.UseFont = false;
            this.clientes.StylePriority.UseTextAlignment = false;
            this.clientes.Text = "clientes";
            this.clientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // productos
            // 
            this.productos.CanGrow = false;
            this.productos.Dpi = 100F;
            this.productos.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.productos.LocationFloat = new DevExpress.Utils.PointFloat(150F, 160F);
            this.productos.Name = "productos";
            this.productos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.productos.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.productos.StylePriority.UseFont = false;
            this.productos.StylePriority.UseTextAlignment = false;
            this.productos.Text = "productos";
            this.productos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // segmentos
            // 
            this.segmentos.CanGrow = false;
            this.segmentos.Dpi = 100F;
            this.segmentos.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.segmentos.LocationFloat = new DevExpress.Utils.PointFloat(150F, 145F);
            this.segmentos.Name = "segmentos";
            this.segmentos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.segmentos.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.segmentos.StylePriority.UseFont = false;
            this.segmentos.StylePriority.UseTextAlignment = false;
            this.segmentos.Text = "segmentos";
            this.segmentos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCliente
            // 
            this.labelCliente.CanGrow = false;
            this.labelCliente.Dpi = 100F;
            this.labelCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelCliente.LocationFloat = new DevExpress.Utils.PointFloat(0F, 175F);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCliente.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelCliente.StylePriority.UseFont = false;
            this.labelCliente.StylePriority.UseTextAlignment = false;
            this.labelCliente.Text = "Cliente(s):";
            this.labelCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelProducto
            // 
            this.labelProducto.CanGrow = false;
            this.labelProducto.Dpi = 100F;
            this.labelProducto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160F);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelProducto.StylePriority.UseFont = false;
            this.labelProducto.StylePriority.UseTextAlignment = false;
            this.labelProducto.Text = "Producto(s):";
            this.labelProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelSegmento
            // 
            this.labelSegmento.CanGrow = false;
            this.labelSegmento.Dpi = 100F;
            this.labelSegmento.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelSegmento.LocationFloat = new DevExpress.Utils.PointFloat(0F, 145F);
            this.labelSegmento.Name = "labelSegmento";
            this.labelSegmento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSegmento.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelSegmento.StylePriority.UseFont = false;
            this.labelSegmento.StylePriority.UseTextAlignment = false;
            this.labelSegmento.Text = "Segmento(s):";
            this.labelSegmento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.xrLabelCantCS,
            this.xrLabelCantDS,
            this.xrLabel45,
            this.xrLabel46,
            this.xrLabelKiloCS,
            this.xrLabelKiloDS,
            this.xrLabel52});
            this.groupFooterBand2.Dpi = 100F;
            this.groupFooterBand2.HeightF = 15F;
            this.groupFooterBand2.Name = "groupFooterBand2";
            // 
            // xrLabelCantCS
            // 
            this.xrLabelCantCS.CanGrow = false;
            this.xrLabelCantCS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.CambioCantidad")});
            this.xrLabelCantCS.Dpi = 100F;
            this.xrLabelCantCS.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelCantCS.LocationFloat = new DevExpress.Utils.PointFloat(770F, 0F);
            this.xrLabelCantCS.Name = "xrLabelCantCS";
            this.xrLabelCantCS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelCantCS.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelCantCS.StyleName = "FieldCaption";
            this.xrLabelCantCS.StylePriority.UseFont = false;
            this.xrLabelCantCS.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabelCantCS.Summary = xrSummary1;
            this.xrLabelCantCS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabelCantDS
            // 
            this.xrLabelCantDS.CanGrow = false;
            this.xrLabelCantDS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.DevolucionCantidad")});
            this.xrLabelCantDS.Dpi = 100F;
            this.xrLabelCantDS.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelCantDS.LocationFloat = new DevExpress.Utils.PointFloat(460F, 0F);
            this.xrLabelCantDS.Name = "xrLabelCantDS";
            this.xrLabelCantDS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelCantDS.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelCantDS.StyleName = "FieldCaption";
            this.xrLabelCantDS.StylePriority.UseFont = false;
            this.xrLabelCantDS.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabelCantDS.Summary = xrSummary2;
            this.xrLabelCantDS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel45
            // 
            this.xrLabel45.CanGrow = false;
            this.xrLabel45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.CambioImporte")});
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(910F, 0F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel45.StyleName = "FieldCaption";
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:$#,##0.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel45.Summary = xrSummary3;
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel46
            // 
            this.xrLabel46.CanGrow = false;
            this.xrLabel46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.DevolucionImporte")});
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel46.StyleName = "FieldCaption";
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:$#,##0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel46.Summary = xrSummary4;
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabelKiloCS
            // 
            this.xrLabelKiloCS.CanGrow = false;
            this.xrLabelKiloCS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.CambioKgLtsCantidad")});
            this.xrLabelKiloCS.Dpi = 100F;
            this.xrLabelKiloCS.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelKiloCS.LocationFloat = new DevExpress.Utils.PointFloat(840F, 0F);
            this.xrLabelKiloCS.Name = "xrLabelKiloCS";
            this.xrLabelKiloCS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKiloCS.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelKiloCS.StyleName = "FieldCaption";
            this.xrLabelKiloCS.StylePriority.UseFont = false;
            this.xrLabelKiloCS.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:n}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabelKiloCS.Summary = xrSummary5;
            this.xrLabelKiloCS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabelKiloDS
            // 
            this.xrLabelKiloDS.CanGrow = false;
            this.xrLabelKiloDS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_RW010DevolucionesYCambiosDelCliente.DevolucionKgLtsCantidad")});
            this.xrLabelKiloDS.Dpi = 100F;
            this.xrLabelKiloDS.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelKiloDS.LocationFloat = new DevExpress.Utils.PointFloat(530F, 0F);
            this.xrLabelKiloDS.Name = "xrLabelKiloDS";
            this.xrLabelKiloDS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKiloDS.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabelKiloDS.StyleName = "FieldCaption";
            this.xrLabelKiloDS.StylePriority.UseFont = false;
            this.xrLabelKiloDS.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:n}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabelKiloDS.Summary = xrSummary6;
            this.xrLabelKiloDS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel52
            // 
            this.xrLabel52.CanGrow = false;
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(360F, 0F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel52.StyleName = "FieldCaption";
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "Total:";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // parameterCEDIS
            // 
            this.parameterCEDIS.Name = "parameterCEDIS";
            this.parameterCEDIS.ValueInfo = "Alm01";
            this.parameterCEDIS.Visible = false;
            // 
            // parameterRutas
            // 
            this.parameterRutas.Name = "parameterRutas";
            this.parameterRutas.Visible = false;
            // 
            // parameterProductos
            // 
            this.parameterProductos.Name = "parameterProductos";
            this.parameterProductos.Visible = false;
            // 
            // parameterProductosEsquemas
            // 
            this.parameterProductosEsquemas.Name = "parameterProductosEsquemas";
            this.parameterProductosEsquemas.Visible = false;
            // 
            // parameterClientes
            // 
            this.parameterClientes.Name = "parameterClientes";
            this.parameterClientes.Visible = false;
            // 
            // parameterFechaInicial
            // 
            this.parameterFechaInicial.Name = "parameterFechaInicial";
            this.parameterFechaInicial.ValueInfo = "2019-01-01";
            this.parameterFechaInicial.Visible = false;
            // 
            // parameterFechaFinal
            // 
            this.parameterFechaFinal.Name = "parameterFechaFinal";
            this.parameterFechaFinal.ValueInfo = "2020-01-01";
            this.parameterFechaFinal.Visible = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelKiloDE,
            this.xrLabel41,
            this.xrLabel97,
            this.xrLabelKiloCE,
            this.xrLabelCantCE,
            this.xrLabel99,
            this.xrLabelCantDE,
            this.xrLabel101,
            this.xrLabel102,
            this.xrLabel103,
            this.xrLabel104,
            this.xrLabel105,
            this.xrLabel106,
            this.xrLabel107});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 30F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabelKiloDE
            // 
            this.xrLabelKiloDE.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabelKiloDE.BorderWidth = 1F;
            this.xrLabelKiloDE.CanGrow = false;
            this.xrLabelKiloDE.Dpi = 100F;
            this.xrLabelKiloDE.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelKiloDE.LocationFloat = new DevExpress.Utils.PointFloat(530F, 15F);
            this.xrLabelKiloDE.Name = "xrLabelKiloDE";
            this.xrLabelKiloDE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKiloDE.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabelKiloDE.StylePriority.UseBorders = false;
            this.xrLabelKiloDE.StylePriority.UseBorderWidth = false;
            this.xrLabelKiloDE.StylePriority.UseFont = false;
            this.xrLabelKiloDE.StylePriority.UseTextAlignment = false;
            this.xrLabelKiloDE.Text = "Kg/Lt";
            this.xrLabelKiloDE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel41
            // 
            this.xrLabel41.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel41.BorderWidth = 1F;
            this.xrLabel41.CanGrow = false;
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(980F, 15F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel41.StylePriority.UseBorders = false;
            this.xrLabel41.StylePriority.UseBorderWidth = false;
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "Motivo";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel97
            // 
            this.xrLabel97.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel97.BorderWidth = 1F;
            this.xrLabel97.CanGrow = false;
            this.xrLabel97.Dpi = 100F;
            this.xrLabel97.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel97.LocationFloat = new DevExpress.Utils.PointFloat(910F, 15F);
            this.xrLabel97.Name = "xrLabel97";
            this.xrLabel97.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel97.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel97.StylePriority.UseBorders = false;
            this.xrLabel97.StylePriority.UseBorderWidth = false;
            this.xrLabel97.StylePriority.UseFont = false;
            this.xrLabel97.StylePriority.UseTextAlignment = false;
            this.xrLabel97.Text = "Importe";
            this.xrLabel97.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelKiloCE
            // 
            this.xrLabelKiloCE.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabelKiloCE.BorderWidth = 1F;
            this.xrLabelKiloCE.CanGrow = false;
            this.xrLabelKiloCE.Dpi = 100F;
            this.xrLabelKiloCE.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelKiloCE.LocationFloat = new DevExpress.Utils.PointFloat(840F, 15F);
            this.xrLabelKiloCE.Name = "xrLabelKiloCE";
            this.xrLabelKiloCE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKiloCE.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabelKiloCE.StylePriority.UseBorders = false;
            this.xrLabelKiloCE.StylePriority.UseBorderWidth = false;
            this.xrLabelKiloCE.StylePriority.UseFont = false;
            this.xrLabelKiloCE.StylePriority.UseTextAlignment = false;
            this.xrLabelKiloCE.Text = "Kg/Lt";
            this.xrLabelKiloCE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelCantCE
            // 
            this.xrLabelCantCE.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabelCantCE.BorderWidth = 1F;
            this.xrLabelCantCE.CanGrow = false;
            this.xrLabelCantCE.Dpi = 100F;
            this.xrLabelCantCE.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelCantCE.LocationFloat = new DevExpress.Utils.PointFloat(770F, 15F);
            this.xrLabelCantCE.Name = "xrLabelCantCE";
            this.xrLabelCantCE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelCantCE.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabelCantCE.StylePriority.UseBorders = false;
            this.xrLabelCantCE.StylePriority.UseBorderWidth = false;
            this.xrLabelCantCE.StylePriority.UseFont = false;
            this.xrLabelCantCE.StylePriority.UseTextAlignment = false;
            this.xrLabelCantCE.Text = "Cantidad";
            this.xrLabelCantCE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel99
            // 
            this.xrLabel99.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel99.BorderWidth = 1F;
            this.xrLabel99.CanGrow = false;
            this.xrLabel99.Dpi = 100F;
            this.xrLabel99.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel99.LocationFloat = new DevExpress.Utils.PointFloat(670F, 15F);
            this.xrLabel99.Name = "xrLabel99";
            this.xrLabel99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel99.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel99.StylePriority.UseBorders = false;
            this.xrLabel99.StylePriority.UseBorderWidth = false;
            this.xrLabel99.StylePriority.UseFont = false;
            this.xrLabel99.StylePriority.UseTextAlignment = false;
            this.xrLabel99.Text = "Motivo";
            this.xrLabel99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelCantDE
            // 
            this.xrLabelCantDE.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabelCantDE.BorderWidth = 1F;
            this.xrLabelCantDE.CanGrow = false;
            this.xrLabelCantDE.Dpi = 100F;
            this.xrLabelCantDE.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabelCantDE.LocationFloat = new DevExpress.Utils.PointFloat(460F, 15F);
            this.xrLabelCantDE.Name = "xrLabelCantDE";
            this.xrLabelCantDE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelCantDE.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabelCantDE.StylePriority.UseBorders = false;
            this.xrLabelCantDE.StylePriority.UseBorderWidth = false;
            this.xrLabelCantDE.StylePriority.UseFont = false;
            this.xrLabelCantDE.StylePriority.UseTextAlignment = false;
            this.xrLabelCantDE.Text = "Cantidad";
            this.xrLabelCantDE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel101
            // 
            this.xrLabel101.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel101.BorderWidth = 1F;
            this.xrLabel101.CanGrow = false;
            this.xrLabel101.Dpi = 100F;
            this.xrLabel101.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel101.LocationFloat = new DevExpress.Utils.PointFloat(600F, 15F);
            this.xrLabel101.Name = "xrLabel101";
            this.xrLabel101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel101.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel101.StylePriority.UseBorders = false;
            this.xrLabel101.StylePriority.UseBorderWidth = false;
            this.xrLabel101.StylePriority.UseFont = false;
            this.xrLabel101.StylePriority.UseTextAlignment = false;
            this.xrLabel101.Text = "Importe";
            this.xrLabel101.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel102
            // 
            this.xrLabel102.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel102.BorderWidth = 1F;
            this.xrLabel102.CanGrow = false;
            this.xrLabel102.Dpi = 100F;
            this.xrLabel102.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel102.LocationFloat = new DevExpress.Utils.PointFloat(770F, 0F);
            this.xrLabel102.Name = "xrLabel102";
            this.xrLabel102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel102.SizeF = new System.Drawing.SizeF(310F, 15F);
            this.xrLabel102.StylePriority.UseBorders = false;
            this.xrLabel102.StylePriority.UseBorderWidth = false;
            this.xrLabel102.StylePriority.UseFont = false;
            this.xrLabel102.StylePriority.UseTextAlignment = false;
            this.xrLabel102.Text = "Cambio";
            this.xrLabel102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel103
            // 
            this.xrLabel103.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel103.BorderWidth = 1F;
            this.xrLabel103.CanGrow = false;
            this.xrLabel103.Dpi = 100F;
            this.xrLabel103.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel103.LocationFloat = new DevExpress.Utils.PointFloat(460F, 0F);
            this.xrLabel103.Name = "xrLabel103";
            this.xrLabel103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel103.SizeF = new System.Drawing.SizeF(310F, 15F);
            this.xrLabel103.StylePriority.UseBorders = false;
            this.xrLabel103.StylePriority.UseBorderWidth = false;
            this.xrLabel103.StylePriority.UseFont = false;
            this.xrLabel103.StylePriority.UseTextAlignment = false;
            this.xrLabel103.Text = "Devolucion";
            this.xrLabel103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel104
            // 
            this.xrLabel104.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel104.BorderWidth = 1F;
            this.xrLabel104.CanGrow = false;
            this.xrLabel104.Dpi = 100F;
            this.xrLabel104.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel104.LocationFloat = new DevExpress.Utils.PointFloat(410F, 0F);
            this.xrLabel104.Name = "xrLabel104";
            this.xrLabel104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel104.SizeF = new System.Drawing.SizeF(50F, 30F);
            this.xrLabel104.StylePriority.UseBorders = false;
            this.xrLabel104.StylePriority.UseBorderWidth = false;
            this.xrLabel104.StylePriority.UseFont = false;
            this.xrLabel104.StylePriority.UseTextAlignment = false;
            this.xrLabel104.Text = "Precio";
            this.xrLabel104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel105
            // 
            this.xrLabel105.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel105.BorderWidth = 1F;
            this.xrLabel105.CanGrow = false;
            this.xrLabel105.Dpi = 100F;
            this.xrLabel105.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel105.LocationFloat = new DevExpress.Utils.PointFloat(360F, 0F);
            this.xrLabel105.Name = "xrLabel105";
            this.xrLabel105.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel105.SizeF = new System.Drawing.SizeF(50F, 30F);
            this.xrLabel105.StylePriority.UseBorders = false;
            this.xrLabel105.StylePriority.UseBorderWidth = false;
            this.xrLabel105.StylePriority.UseFont = false;
            this.xrLabel105.StylePriority.UseTextAlignment = false;
            this.xrLabel105.Text = "Unidad";
            this.xrLabel105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel106
            // 
            this.xrLabel106.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel106.BorderWidth = 1F;
            this.xrLabel106.CanGrow = false;
            this.xrLabel106.Dpi = 100F;
            this.xrLabel106.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel106.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel106.Name = "xrLabel106";
            this.xrLabel106.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel106.SizeF = new System.Drawing.SizeF(80F, 30F);
            this.xrLabel106.StylePriority.UseBorders = false;
            this.xrLabel106.StylePriority.UseBorderWidth = false;
            this.xrLabel106.StylePriority.UseFont = false;
            this.xrLabel106.StylePriority.UseTextAlignment = false;
            this.xrLabel106.Text = "Clave";
            this.xrLabel106.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel107
            // 
            this.xrLabel107.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel107.BorderWidth = 1F;
            this.xrLabel107.CanGrow = false;
            this.xrLabel107.Dpi = 100F;
            this.xrLabel107.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel107.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
            this.xrLabel107.Name = "xrLabel107";
            this.xrLabel107.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel107.SizeF = new System.Drawing.SizeF(280F, 30F);
            this.xrLabel107.StylePriority.UseBorders = false;
            this.xrLabel107.StylePriority.UseBorderWidth = false;
            this.xrLabel107.StylePriority.UseFont = false;
            this.xrLabel107.StylePriority.UseTextAlignment = false;
            this.xrLabel107.Text = "Producto";
            this.xrLabel107.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // R010DevolucionesYCambiosDelCliente
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.groupHeaderBand4,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand2,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_RW010DevolucionesYCambiosDelCliente";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCEDIS,
            this.parameterRutas,
            this.parameterProductos,
            this.parameterProductosEsquemas,
            this.parameterClientes,
            this.parameterFechaInicial,
            this.parameterFechaFinal});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "16.1";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.R10DevolucionesyCambiosPorCliente_DataSourceDemanded);
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R10DevolucionesyCambiosPorCliente_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private int CountRows()
    {
        StringBuilder sConsulta = new StringBuilder();
        sConsulta.AppendLine("EXEC [dbo].[stpr_RW010DevolucionesYCambiosDelCliente] ");
        sConsulta.AppendLine("@filtroCEDIS = '" + this.CEDIS + "', ");
        sConsulta.AppendLine("@filtroRutas = '" + this.Rutas + "', ");
        sConsulta.AppendLine("@filtroProductos = '" + this.Productos + "', ");
        sConsulta.AppendLine("@filtroProductosEsquemas = '" + this.ProductosEsquemas + "', ");
        sConsulta.AppendLine("@filtroClientes = '" + this.Clientes + "', ");
        sConsulta.AppendLine("@filtroFechaInicio = '" + this.fInicio.Date.ToString("yyyy-MM-dd") + "', ");
        sConsulta.AppendLine("@filtroFechaFin = '" + this.fFin.Date.ToString("yyyy-MM-dd") + "'");
        QueryString = sConsulta.ToString();
        List<ObjectModel> objectData = Connection.Query<ObjectModel>(QueryString, null, null, true, 9000).ToList();
        return objectData.Count;
    }

    private class ObjectModel
    {
        public string CEDI { get; set; }
    }

    private void R10DevolucionesyCambiosPorCliente_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        bool pvConversionKG = Connection.Query<int>("SELECT TOP 1 ConversionKg FROM ConHist (NOLOCK) ORDER BY MFechaHora DESC", null, null, true, 600).FirstOrDefault() == 0;
        if (pvConversionKG)
        {
            xrLabelKiloDE.Visible = false;
            xrLabelKiloDD.Visible = false;
            xrLabelKiloDS.Visible = false;
            xrLabelKiloCE.Visible = false;
            xrLabelKiloCD.Visible = false;
            xrLabelKiloCS.Visible = false;
            xrLabelCantDE.SizeF = new System.Drawing.SizeF(140F, 15F);
            xrLabelCantDD.SizeF = new System.Drawing.SizeF(100F, 15F);
            xrLabelCantDS.SizeF = new System.Drawing.SizeF(100F, 15F);
            xrLabelCantCE.SizeF = new System.Drawing.SizeF(140F, 15F);
            xrLabelCantCD.SizeF = new System.Drawing.SizeF(100F, 15F);
            xrLabelCantCS.SizeF = new System.Drawing.SizeF(100F, 15F);
        }
        string FechaInicial = this.fInicio.Date.ToShortDateString();
        string FechaFinal = this.fFin.Date.ToShortDateString();
        this.empresa.Text = this.NombreEmpresa;
        this.logo.Image = Image.FromStream(this.LogoEmpresa);
        this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        this.fechas.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);
        this.cedis.Text = this.NombreCEDIS;
        this.reporte.Text = this.NombreReporte;
        this.rutas.Text = (this.Rutas == "" ? "Todas las Rutas" : this.Rutas);
        this.segmentos.Text = (this.ProductosEsquemas == "" ? "Todos los Esquemas de Productos" : this.ProductosEsquemas);
        this.productos.Text = (this.Productos == "" ? "Todas los Productos" : this.Productos);
        this.clientes.Text = (this.Clientes == "" ? "Todas los Clientes" : this.Clientes);
    }

    private void R10DevolucionesyCambiosPorCliente_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterCEDIS"].Value = this.CEDIS;
        this.Parameters["parameterRutas"].Value = this.Rutas;
        this.Parameters["parameterProductos"].Value = this.Productos;
        this.Parameters["parameterProductosEsquemas"].Value = this.ProductosEsquemas;
        this.Parameters["parameterClientes"].Value = this.Clientes;
        this.Parameters["parameterFechaInicial"].Value = this.fInicio.Date.ToString("yyyy-MM-dd");
        this.Parameters["parameterFechaFinal"].Value = this.fFin.Date.ToString("yyyy-MM-dd");
    }
}
