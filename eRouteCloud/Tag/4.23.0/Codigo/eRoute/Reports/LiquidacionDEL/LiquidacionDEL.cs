using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using eRoute.Controllers.API;

/// <summary>
/// Summary description for LiquidacionDEL
/// </summary>
public class LiquidacionDEL : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private PageFooterBand pageFooterBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.XtraReports.Parameters.Parameter parameterVendedores;
    private DevExpress.XtraReports.Parameters.Parameter parameterFecha;
    private PageHeaderBand PageHeader;
    private XRPictureBox logo;
    private XRLabel reporte;
    private XRLabel xrLabel69;
    private XRLabel xrLabel70;
    private XRLabel xrLabel71;
    private XRLabel centro;
    private XRLabel fecha;
    private XRLabel vendedor;
    private XRLabel empresa;
    private GroupHeaderBand GroupHeader1;
    private XRLine xrLine2;
    private XRLine xrLine5;
    private XRLabel xrLabel6;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private GroupFooterBand GroupFooter1;
    private XRSubreport VentasContado;
    private GroupFooterBand GroupFooter2;
    private XRSubreport VentasCredito;
    private GroupFooterBand GroupFooter3;
    private XRSubreport Cobranza;
    private string CEDIS;
    private string Vendedores;
    DateTime fInicio;
    private string NombreCEDIS;
    private string NombreVendedor;
    private string NombreReporte;
    private string NombreEmpresa;
    private string Domicilio;
    private string Telefono;
    private int count;
    private string QueryString;
    private MemoryStream LogoEmpresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private GroupFooterBand GroupFooter4;
    private XRSubreport DesgloseDocumentos;
    private XRSubreport DesgloseEfectivo;
    private GroupFooterBand GroupFooter5;
    private GroupFooterBand GroupFooter6;
    private XRSubreport Kilometros;
    private XRSubreport Totales;
    private GroupFooterBand GroupFooter7;
    private XRSubreport TiemposVisita;
    private XRSubreport VisitasFueraRuta;
    private XRSubreport TotalGeneralVisitas;
    private ReportFooterBand ReportFooter;
    public XRLabel footerCedi;
    public XRLabel footerVendedor;
    private XRLine xrLine17;
    private XRLine xrLine16;
    private XRLabel telefono;
    private XRLabel domicilio;
    private XRLabel xrLabel17;
    private XRLabel xrLabel14;
    private XRLabel xrLabel19;
    private XRLabel ruta;
    private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

    public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreVendedor, string NombreCEDIS, string DateStatus, string CEDIS, string Vendedores, string FechaInicial)
    {
        this.fInicio = DateTime.Parse(FechaInicial);
        this.CEDIS = CEDIS;
        this.NombreCEDIS = NombreCEDIS;
        this.Vendedores = Vendedores;
        this.NombreVendedor = NombreVendedor;
        this.NombreReporte = NombreReporte;
        this.NombreEmpresa = NombreEmpresa;
        this.LogoEmpresa = LogoEmpresa;
        this.count = CountRows();

        if (this.count > 0)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiquidacionDEL));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.parameterVendedores = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterFecha = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.telefono = new DevExpress.XtraReports.UI.XRLabel();
            this.domicilio = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter6 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter7 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.footerCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.footerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine17 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine16 = new DevExpress.XtraReports.UI.XRLine();
            this.VentasContado = new DevExpress.XtraReports.UI.XRSubreport();
            this.VentasCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.Cobranza = new DevExpress.XtraReports.UI.XRSubreport();
            this.DesgloseDocumentos = new DevExpress.XtraReports.UI.XRSubreport();
            this.DesgloseEfectivo = new DevExpress.XtraReports.UI.XRSubreport();
            this.Totales = new DevExpress.XtraReports.UI.XRSubreport();
            this.Kilometros = new DevExpress.XtraReports.UI.XRSubreport();
            this.TiemposVisita = new DevExpress.XtraReports.UI.XRSubreport();
            this.VisitasFueraRuta = new DevExpress.XtraReports.UI.XRSubreport();
            this.TotalGeneralVisitas = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel15,
            this.xrLabel16});
            this.Detail.Dpi = 100F;
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionDEL.Devolucion", "{0:n}")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(570F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.xrLabel9.StyleName = "DataField";
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionDEL.EntradasCambioFisico")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(370F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.xrLabel10.StyleName = "DataField";
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionDEL.InventarioFinal", "{0:n}")});
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(730F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.xrLabel11.StyleName = "DataField";
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionDEL.InventarioInicial", "{0:n}")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(290F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.xrLabel12.StyleName = "DataField";
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionDEL.Nombre")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.xrLabel13.StyleName = "DataField";
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionDEL.SalidasCambioFisico")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(470F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(100F, 20F);
            this.xrLabel15.StyleName = "DataField";
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteLiquidacionDEL.Ventas", "{0:n}")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.xrLabel16.StyleName = "DataField";
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_ReporteLiquidacionDEL";
            queryParameter1.Name = "@filtroVendedores";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterVendedores]", typeof(string));
            queryParameter2.Name = "@filtroFechaInicio";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFecha]", typeof(string));
            queryParameter3.Name = "@noConsulta";
            queryParameter3.Type = typeof(int);
            queryParameter3.ValueInfo = "1";
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "stpr_ReporteLiquidacionDEL";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(570F, 22F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.xrLabel1.StyleName = "FieldCaption";
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Devolucion";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(370F, 21.99997F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.xrLabel2.StyleName = "FieldCaption";
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Entradas Cambio Fisico";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(730F, 21.99997F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.xrLabel3.StyleName = "FieldCaption";
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Inventario Final";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(290F, 22F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.xrLabel4.StyleName = "FieldCaption";
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Inventario Inicial";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(290F, 35F);
            this.xrLabel5.StyleName = "FieldCaption";
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Producto\r\n";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(470F, 22F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.xrLabel7.StyleName = "FieldCaption";
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Salidas\r\nCambio Fisico";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(650F, 21.99997F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.xrLabel8.StyleName = "FieldCaption";
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Ventas";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(730F, 0F);
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
            this.parameterVendedores.Visible = false;
            // 
            // parameterFecha
            // 
            this.parameterFecha.Name = "parameterFecha";
            this.parameterFecha.Visible = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.ruta,
            this.telefono,
            this.domicilio,
            this.xrLabel17,
            this.xrLabel14,
            this.logo,
            this.reporte,
            this.xrLabel69,
            this.xrLabel70,
            this.xrLabel71,
            this.centro,
            this.fecha,
            this.vendedor,
            this.empresa});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.PageHeader.HeightF = 185F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseFont = false;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(0F, 170F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Ruta:";
            // 
            // ruta
            // 
            this.ruta.Dpi = 100F;
            this.ruta.LocationFloat = new DevExpress.Utils.PointFloat(150F, 170F);
            this.ruta.Name = "ruta";
            this.ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ruta.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.ruta.Text = "ruta";
            // 
            // telefono
            // 
            this.telefono.Dpi = 100F;
            this.telefono.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.telefono.LocationFloat = new DevExpress.Utils.PointFloat(400F, 125F);
            this.telefono.Name = "telefono";
            this.telefono.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.telefono.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.telefono.StylePriority.UseFont = false;
            this.telefono.Text = "telefono";
            // 
            // domicilio
            // 
            this.domicilio.Dpi = 100F;
            this.domicilio.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.domicilio.LocationFloat = new DevExpress.Utils.PointFloat(400F, 110F);
            this.domicilio.Name = "domicilio";
            this.domicilio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.domicilio.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.domicilio.StylePriority.UseFont = false;
            this.domicilio.Text = "domicilio";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(250F, 125F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "Telefono:";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(250F, 110F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "Domicilio:";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(15F, 15F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(170F, 55F);
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
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(250F, 95F);
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
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(0F, 140F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.Text = "Fecha:";
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel71
            // 
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(0F, 155F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            this.xrLabel71.Text = "Vendedor:";
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // centro
            // 
            this.centro.Dpi = 100F;
            this.centro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(400F, 95F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.centro.StylePriority.UseFont = false;
            this.centro.StylePriority.UseTextAlignment = false;
            this.centro.Text = "centro";
            this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fecha
            // 
            this.fecha.Dpi = 100F;
            this.fecha.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(150F, 140F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.fecha.StylePriority.UseFont = false;
            this.fecha.StylePriority.UseTextAlignment = false;
            this.fecha.Text = "fecha";
            this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vendedor
            // 
            this.vendedor.Dpi = 100F;
            this.vendedor.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.vendedor.LocationFloat = new DevExpress.Utils.PointFloat(150F, 155F);
            this.vendedor.Name = "vendedor";
            this.vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vendedor.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.vendedor.StylePriority.UseFont = false;
            this.vendedor.StylePriority.UseTextAlignment = false;
            this.vendedor.Text = "vendedor";
            this.vendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(170F, 15F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLine2,
            this.xrLine5,
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel7,
            this.xrLabel1,
            this.xrLabel8});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 60F;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(830F, 20F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Ventas Por Producto";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 56.99997F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(830F, 2F);
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 20F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(830F, 2F);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.VentasContado});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.GroupFooter1.HeightF = 30F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.StylePriority.UseFont = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.VentasCredito});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.GroupFooter2.HeightF = 30F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.StylePriority.UseFont = false;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Cobranza});
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.GroupFooter3.HeightF = 30F;
            this.GroupFooter3.Level = 2;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.StylePriority.UseFont = false;
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DesgloseDocumentos,
            this.DesgloseEfectivo});
            this.GroupFooter4.Dpi = 100F;
            this.GroupFooter4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.GroupFooter4.HeightF = 30F;
            this.GroupFooter4.Level = 3;
            this.GroupFooter4.Name = "GroupFooter4";
            this.GroupFooter4.StylePriority.UseFont = false;
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Totales});
            this.GroupFooter5.Dpi = 100F;
            this.GroupFooter5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.GroupFooter5.HeightF = 30F;
            this.GroupFooter5.Level = 4;
            this.GroupFooter5.Name = "GroupFooter5";
            this.GroupFooter5.StylePriority.UseFont = false;
            // 
            // GroupFooter6
            // 
            this.GroupFooter6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Kilometros});
            this.GroupFooter6.Dpi = 100F;
            this.GroupFooter6.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.GroupFooter6.HeightF = 30F;
            this.GroupFooter6.Level = 5;
            this.GroupFooter6.Name = "GroupFooter6";
            this.GroupFooter6.StylePriority.UseFont = false;
            // 
            // GroupFooter7
            // 
            this.GroupFooter7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TiemposVisita,
            this.VisitasFueraRuta,
            this.TotalGeneralVisitas});
            this.GroupFooter7.Dpi = 100F;
            this.GroupFooter7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.GroupFooter7.HeightF = 60F;
            this.GroupFooter7.Level = 6;
            this.GroupFooter7.Name = "GroupFooter7";
            this.GroupFooter7.StylePriority.UseFont = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.footerCedi,
            this.footerVendedor,
            this.xrLine17,
            this.xrLine16});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.ReportFooter.HeightF = 200F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StylePriority.UseFont = false;
            // 
            // footerCedi
            // 
            this.footerCedi.Dpi = 100F;
            this.footerCedi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.footerCedi.LocationFloat = new DevExpress.Utils.PointFloat(430F, 180F);
            this.footerCedi.Name = "footerCedi";
            this.footerCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.footerCedi.SizeF = new System.Drawing.SizeF(350F, 20F);
            this.footerCedi.StylePriority.UseFont = false;
            this.footerCedi.StylePriority.UseTextAlignment = false;
            this.footerCedi.Text = "Recibió";
            this.footerCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // footerVendedor
            // 
            this.footerVendedor.Dpi = 100F;
            this.footerVendedor.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.footerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(50F, 180F);
            this.footerVendedor.Name = "footerVendedor";
            this.footerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.footerVendedor.SizeF = new System.Drawing.SizeF(350F, 20F);
            this.footerVendedor.StylePriority.UseFont = false;
            this.footerVendedor.StylePriority.UseTextAlignment = false;
            this.footerVendedor.Text = "Vendedor";
            this.footerVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine17
            // 
            this.xrLine17.Dpi = 100F;
            this.xrLine17.LocationFloat = new DevExpress.Utils.PointFloat(430F, 178F);
            this.xrLine17.Name = "xrLine17";
            this.xrLine17.SizeF = new System.Drawing.SizeF(350F, 2F);
            // 
            // xrLine16
            // 
            this.xrLine16.Dpi = 100F;
            this.xrLine16.LocationFloat = new DevExpress.Utils.PointFloat(50F, 178F);
            this.xrLine16.Name = "xrLine16";
            this.xrLine16.SizeF = new System.Drawing.SizeF(350F, 2F);
            // 
            // VentasContado
            // 
            this.VentasContado.Dpi = 100F;
            this.VentasContado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.VentasContado.Name = "VentasContado";
            this.VentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.VentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.VentasContado.ReportSource = new LiquidacionDELVentasContado();
            this.VentasContado.SizeF = new System.Drawing.SizeF(830F, 20F);
            // 
            // VentasCredito
            // 
            this.VentasCredito.Dpi = 100F;
            this.VentasCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.VentasCredito.Name = "VentasCredito";
            this.VentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.VentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.VentasCredito.ReportSource = new LiquidacionDELVentasCredito();
            this.VentasCredito.SizeF = new System.Drawing.SizeF(830F, 20F);
            // 
            // Cobranza
            // 
            this.Cobranza.Dpi = 100F;
            this.Cobranza.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.Cobranza.Name = "Cobranza";
            this.Cobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.Cobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.Cobranza.ReportSource = new LiquidacionDELCobranza();
            this.Cobranza.SizeF = new System.Drawing.SizeF(830F, 20F);
            // 
            // DesgloseDocumentos
            // 
            this.DesgloseDocumentos.Dpi = 100F;
            this.DesgloseDocumentos.LocationFloat = new DevExpress.Utils.PointFloat(380F, 10F);
            this.DesgloseDocumentos.Name = "DesgloseDocumentos";
            this.DesgloseDocumentos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.DesgloseDocumentos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.DesgloseDocumentos.ReportSource = new LiquidacionDELDesgloseDocumentos();
            this.DesgloseDocumentos.SizeF = new System.Drawing.SizeF(450F, 20F);
            // 
            // DesgloseEfectivo
            // 
            this.DesgloseEfectivo.Dpi = 100F;
            this.DesgloseEfectivo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.DesgloseEfectivo.Name = "DesgloseEfectivo";
            this.DesgloseEfectivo.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.DesgloseEfectivo.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.DesgloseEfectivo.ReportSource = new LiquidacionDELDesgloseEfectivo();
            this.DesgloseEfectivo.SizeF = new System.Drawing.SizeF(330F, 20F);
            // 
            // Totales
            // 
            this.Totales.Dpi = 100F;
            this.Totales.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.Totales.Name = "Totales";
            this.Totales.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.Totales.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.Totales.ReportSource = new LiquidacionDELTotales();
            this.Totales.SizeF = new System.Drawing.SizeF(330F, 20F);
            // 
            // Kilometros
            // 
            this.Kilometros.Dpi = 100F;
            this.Kilometros.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.Kilometros.Name = "Kilometros";
            this.Kilometros.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.Kilometros.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.Kilometros.ReportSource = new LiquidacionDELKilometros();
            this.Kilometros.SizeF = new System.Drawing.SizeF(500F, 20F);
            // 
            // TiemposVisita
            // 
            this.TiemposVisita.Dpi = 100F;
            this.TiemposVisita.LocationFloat = new DevExpress.Utils.PointFloat(415F, 40F);
            this.TiemposVisita.Name = "TiemposVisita";
            this.TiemposVisita.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.TiemposVisita.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.TiemposVisita.ReportSource = new LiquidacionDELTiemposVisitas();
            this.TiemposVisita.SizeF = new System.Drawing.SizeF(415F, 20F);
            // 
            // VisitasFueraRuta
            // 
            this.VisitasFueraRuta.Dpi = 100F;
            this.VisitasFueraRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40F);
            this.VisitasFueraRuta.Name = "VisitasFueraRuta";
            this.VisitasFueraRuta.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.VisitasFueraRuta.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.VisitasFueraRuta.ReportSource = new LiquidacionDELVisitasFueraRuta();
            this.VisitasFueraRuta.SizeF = new System.Drawing.SizeF(415F, 20F);
            // 
            // TotalGeneralVisitas
            // 
            this.TotalGeneralVisitas.Dpi = 100F;
            this.TotalGeneralVisitas.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.TotalGeneralVisitas.Name = "TotalGeneralVisitas";
            this.TotalGeneralVisitas.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterVendedores", this.parameterVendedores));
            this.TotalGeneralVisitas.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameterFecha", this.parameterFecha));
            this.TotalGeneralVisitas.ReportSource = new LiquidacionDELTotalGeneralVisitas();
            this.TotalGeneralVisitas.SizeF = new System.Drawing.SizeF(830F, 20F);
            // 
            // LiquidacionDEL
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageFooterBand1,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter1,
            this.GroupFooter2,
            this.GroupFooter3,
            this.GroupFooter4,
            this.GroupFooter5,
            this.GroupFooter6,
            this.GroupFooter7,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_ReporteLiquidacionDEL";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterVendedores,
            this.parameterFecha});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "16.1";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.LiquidacionDEL_DataSourceDemanded);
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.LiquidacionDEL_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    public int CountRows()
    {
        StringBuilder sConsulta = new StringBuilder();
        sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteLiquidacionDEL] ");
        sConsulta.AppendLine("@filtroVendedores = '" + this.Vendedores + "', ");
        sConsulta.AppendLine("@filtroFechaInicio = '" + this.fInicio.Date.ToString("yyyy-MM-dd") + "', ");
        sConsulta.AppendLine("@noConsulta = 1");
        QueryString = sConsulta.ToString();
        List<LiquidacionDELModel> Liquidacion = Connection.Query<LiquidacionDELModel>(QueryString, null, null, true, 9000).ToList();
        return Liquidacion.Count;
    }
    private class LiquidacionDELModel
    {
        public string ProductoClave { get; set; }
    }

    private void LiquidacionDEL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        this.Telefono = "SELECT DISTINCT A.Telefono FROM UsuarioAlmacen UA (NOLOCK) INNER JOIN Almacen A (NOLOCK) ON A.AlmacenID = UA.AlmacenId AND A.AlmacenID = '" + this.CEDIS + "'";
        this.Telefono = Connection.Query<string>(this.Telefono, null, null, true, 9000).FirstOrDefault();
        this.Domicilio = "SELECT DISTINCT A.Domicilio FROM UsuarioAlmacen UA (NOLOCK) INNER JOIN Almacen A (NOLOCK) ON A.AlmacenID = UA.AlmacenId AND A.AlmacenID = '" + this.CEDIS + "'";
        this.Domicilio = Connection.Query<string>(this.Domicilio, null, null, true, 9000).FirstOrDefault();

        string FechaInicial = this.fInicio.Date.ToShortDateString();
        this.empresa.Text = this.NombreEmpresa;
        this.logo.Image = Image.FromStream(this.LogoEmpresa);
        this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        this.fecha.Text = FechaInicial;
        this.centro.Text = this.NombreCEDIS;
        this.vendedor.Text = this.NombreVendedor;
        this.reporte.Text = this.NombreReporte;
        this.telefono.Text = this.Telefono;
        this.domicilio.Text = this.Domicilio;
        this.ruta.Text = this.Vendedores;
    }

    private void LiquidacionDEL_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterVendedores"].Value = this.Vendedores;
        this.Parameters["parameterFecha"].Value = this.fInicio.Date.ToString("yyyy-MM-dd"); ;
    }
}
