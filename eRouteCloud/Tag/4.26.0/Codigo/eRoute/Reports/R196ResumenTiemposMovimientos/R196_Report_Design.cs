using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R196_Report_Design
/// </summary>
public class R196_Report_Design : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private TopMarginBand topMarginBand1;
    private BottomMarginBand bottomMarginBand1;
    public XRLabel XCedi;
    public XRLabel XRuta;
    public XRLabel XUsuario;
    public XRLabel XFechaAgenda;
    public XRLabel XPrimeraVenta;
    public XRLabel XUltimaVenta;
    public XRLabel XDifIniJorPrimVenta;
    public XRLabel XFechaFinJornada;
    public XRLabel XDifUltVentaFinJor;
    private XRPageInfo xrPageInfo3;
    private XRPageInfo xrPageInfo4;
    public XRLabel XFechaHoraImpresion;
    public XRPictureBox logo;
    public XRLabel report_Company;
    public XRLabel report_Name;
    public XRLabel L_FechaRango;
    public XRLabel L_CEDI;
    public XRLabel XCentro;
    public XRLabel XFecha;
    private DevExpress.XtraReports.Parameters.Parameter parameterCedis;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R196_Report_Design()
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
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R196_Report_Design));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.XDifUltVentaFinJor = new DevExpress.XtraReports.UI.XRLabel();
            this.XFechaFinJornada = new DevExpress.XtraReports.UI.XRLabel();
            this.XDifIniJorPrimVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.XUltimaVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.XPrimeraVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.XFechaAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.XUsuario = new DevExpress.XtraReports.UI.XRLabel();
            this.XRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.XCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XFechaHoraImpresion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.report_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.XCentro = new DevExpress.XtraReports.UI.XRLabel();
            this.XFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.Dif_min_Agenda", "{0:#,#}")});
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(580.0002F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100.4167F, 13F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.Dif_min_Sinc", "{0:#,#}")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(979.9999F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(99.16693F, 13F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.FecAgenda", "{0:dd-MMM-yyyy HH:mm:ss}")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(280.4167F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(149.5833F, 13F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.FecPriVent", "{0:dd-MMM-yyyy HH:mm:ss}")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(430.0001F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(149.5833F, 13F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "xrLabel14";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.FecUltVent", "{0:dd-MMM-yyyy HH:mm:ss}")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(680.417F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(149.5832F, 13F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.FFinJor", "{0:dd-MMM-yyyy HH:mm:ss}")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(830.417F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(149.583F, 13F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.RUTA")});
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(1.666768F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(138.3332F, 13F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.USUARIO")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(139.5833F, 13F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R196ResumenTiempoMovimiento";
            queryParameter1.Name = "@filterCedi";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCedis]", typeof(string));
            queryParameter2.Name = "@filterDateIni";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.StoredProcName = "stpr_R196ResumenTiempoMovimiento";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XDifUltVentaFinJor,
            this.XFechaFinJornada,
            this.XDifIniJorPrimVenta,
            this.XUltimaVenta,
            this.XPrimeraVenta,
            this.XFechaAgenda,
            this.XUsuario,
            this.XRuta,
            this.XCedi,
            this.xrLabel2});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CEDIS", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 61F;
            this.groupHeaderBand1.Level = 1;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // XDifUltVentaFinJor
            // 
            this.XDifUltVentaFinJor.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XDifUltVentaFinJor.Dpi = 100F;
            this.XDifUltVentaFinJor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XDifUltVentaFinJor.LocationFloat = new DevExpress.Utils.PointFloat(979.9999F, 25.99999F);
            this.XDifUltVentaFinJor.Name = "XDifUltVentaFinJor";
            this.XDifUltVentaFinJor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XDifUltVentaFinJor.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.XDifUltVentaFinJor.StylePriority.UseBorders = false;
            this.XDifUltVentaFinJor.StylePriority.UseFont = false;
            this.XDifUltVentaFinJor.StylePriority.UsePadding = false;
            this.XDifUltVentaFinJor.StylePriority.UseTextAlignment = false;
            this.XDifUltVentaFinJor.Text = "XDifUltVentaFinJor";
            this.XDifUltVentaFinJor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XFechaFinJornada
            // 
            this.XFechaFinJornada.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XFechaFinJornada.Dpi = 100F;
            this.XFechaFinJornada.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XFechaFinJornada.LocationFloat = new DevExpress.Utils.PointFloat(830F, 26F);
            this.XFechaFinJornada.Name = "XFechaFinJornada";
            this.XFechaFinJornada.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XFechaFinJornada.SizeF = new System.Drawing.SizeF(150F, 35F);
            this.XFechaFinJornada.StylePriority.UseBorders = false;
            this.XFechaFinJornada.StylePriority.UseFont = false;
            this.XFechaFinJornada.StylePriority.UsePadding = false;
            this.XFechaFinJornada.StylePriority.UseTextAlignment = false;
            this.XFechaFinJornada.Text = "XFechaFinJornada";
            this.XFechaFinJornada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XDifIniJorPrimVenta
            // 
            this.XDifIniJorPrimVenta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XDifIniJorPrimVenta.Dpi = 100F;
            this.XDifIniJorPrimVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XDifIniJorPrimVenta.LocationFloat = new DevExpress.Utils.PointFloat(580.0002F, 25.99999F);
            this.XDifIniJorPrimVenta.Name = "XDifIniJorPrimVenta";
            this.XDifIniJorPrimVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XDifIniJorPrimVenta.SizeF = new System.Drawing.SizeF(100F, 35F);
            this.XDifIniJorPrimVenta.StylePriority.UseBorders = false;
            this.XDifIniJorPrimVenta.StylePriority.UseFont = false;
            this.XDifIniJorPrimVenta.StylePriority.UsePadding = false;
            this.XDifIniJorPrimVenta.StylePriority.UseTextAlignment = false;
            this.XDifIniJorPrimVenta.Text = "XDifIniJorPrimVenta";
            this.XDifIniJorPrimVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XUltimaVenta
            // 
            this.XUltimaVenta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XUltimaVenta.Dpi = 100F;
            this.XUltimaVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XUltimaVenta.LocationFloat = new DevExpress.Utils.PointFloat(680.0002F, 25.99999F);
            this.XUltimaVenta.Name = "XUltimaVenta";
            this.XUltimaVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XUltimaVenta.SizeF = new System.Drawing.SizeF(150F, 35F);
            this.XUltimaVenta.StylePriority.UseBorders = false;
            this.XUltimaVenta.StylePriority.UseFont = false;
            this.XUltimaVenta.StylePriority.UsePadding = false;
            this.XUltimaVenta.StylePriority.UseTextAlignment = false;
            this.XUltimaVenta.Text = "XUltimaVenta";
            this.XUltimaVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XPrimeraVenta
            // 
            this.XPrimeraVenta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XPrimeraVenta.Dpi = 100F;
            this.XPrimeraVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XPrimeraVenta.LocationFloat = new DevExpress.Utils.PointFloat(430.0001F, 25.99999F);
            this.XPrimeraVenta.Name = "XPrimeraVenta";
            this.XPrimeraVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XPrimeraVenta.SizeF = new System.Drawing.SizeF(150F, 35F);
            this.XPrimeraVenta.StylePriority.UseBorders = false;
            this.XPrimeraVenta.StylePriority.UseFont = false;
            this.XPrimeraVenta.StylePriority.UsePadding = false;
            this.XPrimeraVenta.StylePriority.UseTextAlignment = false;
            this.XPrimeraVenta.Text = "XPrimeraVenta";
            this.XPrimeraVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XFechaAgenda
            // 
            this.XFechaAgenda.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XFechaAgenda.Dpi = 100F;
            this.XFechaAgenda.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XFechaAgenda.LocationFloat = new DevExpress.Utils.PointFloat(280.0001F, 25.99999F);
            this.XFechaAgenda.Name = "XFechaAgenda";
            this.XFechaAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XFechaAgenda.SizeF = new System.Drawing.SizeF(150F, 35F);
            this.XFechaAgenda.StylePriority.UseBorders = false;
            this.XFechaAgenda.StylePriority.UseFont = false;
            this.XFechaAgenda.StylePriority.UsePadding = false;
            this.XFechaAgenda.StylePriority.UseTextAlignment = false;
            this.XFechaAgenda.Text = "XFechaAgenda";
            this.XFechaAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XUsuario
            // 
            this.XUsuario.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XUsuario.Dpi = 100F;
            this.XUsuario.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XUsuario.LocationFloat = new DevExpress.Utils.PointFloat(140F, 25.99999F);
            this.XUsuario.Name = "XUsuario";
            this.XUsuario.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XUsuario.SizeF = new System.Drawing.SizeF(140F, 35F);
            this.XUsuario.StylePriority.UseBorders = false;
            this.XUsuario.StylePriority.UseFont = false;
            this.XUsuario.StylePriority.UsePadding = false;
            this.XUsuario.StylePriority.UseTextAlignment = false;
            this.XUsuario.Text = "XUsuario";
            this.XUsuario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XRuta
            // 
            this.XRuta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XRuta.Dpi = 100F;
            this.XRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26F);
            this.XRuta.Name = "XRuta";
            this.XRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XRuta.SizeF = new System.Drawing.SizeF(140F, 35F);
            this.XRuta.StylePriority.UseBorders = false;
            this.XRuta.StylePriority.UseFont = false;
            this.XRuta.StylePriority.UsePadding = false;
            this.XRuta.StylePriority.UseTextAlignment = false;
            this.XRuta.Text = "XRuta";
            this.XRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XCedi
            // 
            this.XCedi.CanGrow = false;
            this.XCedi.Dpi = 100F;
            this.XCedi.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XCedi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.XCedi.Name = "XCedi";
            this.XCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XCedi.SizeF = new System.Drawing.SizeF(100F, 14.55F);
            this.XCedi.StylePriority.UseFont = false;
            this.XCedi.StylePriority.UseTextAlignment = false;
            this.XCedi.Text = "XCedi";
            this.XCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R196ResumenTiempoMovimiento.CEDIS")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(110F, 10F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(150F, 14.55F);
            this.xrLabel2.StyleName = "DataField";
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.HeightF = 10F;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            this.groupHeaderBand2.StyleName = "FieldCaption";
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo4,
            this.XFechaHoraImpresion,
            this.xrPageInfo3});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.HeightF = 29F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Dpi = 100F;
            this.xrPageInfo4.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo4.Format = "{0:dd/MM/yyyy hh:mm:ss tt}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(936.27F, 5F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(123.81F, 14F);
            this.xrPageInfo4.StylePriority.UseFont = false;
            this.xrPageInfo4.StylePriority.UsePadding = false;
            this.xrPageInfo4.StylePriority.UseTextAlignment = false;
            this.xrPageInfo4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // XFechaHoraImpresion
            // 
            this.XFechaHoraImpresion.Dpi = 100F;
            this.XFechaHoraImpresion.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XFechaHoraImpresion.LocationFloat = new DevExpress.Utils.PointFloat(786.27F, 5F);
            this.XFechaHoraImpresion.Name = "XFechaHoraImpresion";
            this.XFechaHoraImpresion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XFechaHoraImpresion.SizeF = new System.Drawing.SizeF(150F, 14F);
            this.XFechaHoraImpresion.StylePriority.UseFont = false;
            this.XFechaHoraImpresion.StylePriority.UsePadding = false;
            this.XFechaHoraImpresion.StylePriority.UseTextAlignment = false;
            this.XFechaHoraImpresion.Text = "XFechaHoraImpresion";
            this.XFechaHoraImpresion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo3.Format = "{0} / {1}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(242F, 5F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(313F, 14F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.StylePriority.UsePadding = false;
            this.xrPageInfo3.StylePriority.UseTextAlignment = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.report_Company,
            this.report_Name,
            this.L_FechaRango,
            this.L_CEDI,
            this.XCentro,
            this.XFecha});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 115F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(6.42F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(100F, 100F);
            // 
            // report_Company
            // 
            this.report_Company.Dpi = 100F;
            this.report_Company.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_Company.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 0F);
            this.report_Company.Name = "report_Company";
            this.report_Company.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report_Company.SizeF = new System.Drawing.SizeF(839.666F, 25F);
            this.report_Company.StylePriority.UseFont = false;
            this.report_Company.StylePriority.UseTextAlignment = false;
            this.report_Company.Text = "COMPANY";
            this.report_Company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // report_Name
            // 
            this.report_Name.Dpi = 100F;
            this.report_Name.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_Name.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 25F);
            this.report_Name.Name = "report_Name";
            this.report_Name.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.report_Name.SizeF = new System.Drawing.SizeF(840.0859F, 25F);
            this.report_Name.StylePriority.UseFont = false;
            this.report_Name.StylePriority.UseTextAlignment = false;
            this.report_Name.Text = "NAME REPORT";
            this.report_Name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(423.89F, 83.27F);
            this.L_FechaRango.Name = "L_FechaRango";
            this.L_FechaRango.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_FechaRango.SizeF = new System.Drawing.SizeF(299.5219F, 12.99999F);
            this.L_FechaRango.StylePriority.UseFont = false;
            this.L_FechaRango.StylePriority.UsePadding = false;
            this.L_FechaRango.StylePriority.UseTextAlignment = false;
            this.L_FechaRango.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_CEDI
            // 
            this.L_CEDI.Dpi = 100F;
            this.L_CEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CEDI.LocationFloat = new DevExpress.Utils.PointFloat(423.89F, 67.69F);
            this.L_CEDI.Name = "L_CEDI";
            this.L_CEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_CEDI.SizeF = new System.Drawing.SizeF(299.8937F, 13F);
            this.L_CEDI.StylePriority.UseFont = false;
            this.L_CEDI.StylePriority.UsePadding = false;
            this.L_CEDI.StylePriority.UseTextAlignment = false;
            this.L_CEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XCentro
            // 
            this.XCentro.Dpi = 100F;
            this.XCentro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XCentro.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 67.69F);
            this.XCentro.Name = "XCentro";
            this.XCentro.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XCentro.SizeF = new System.Drawing.SizeF(187.9904F, 13F);
            this.XCentro.StylePriority.UseFont = false;
            this.XCentro.StylePriority.UsePadding = false;
            this.XCentro.StylePriority.UseTextAlignment = false;
            this.XCentro.Text = "XCentro";
            this.XCentro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XFecha
            // 
            this.XFecha.Dpi = 100F;
            this.XFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XFecha.LocationFloat = new DevExpress.Utils.PointFloat(220.05F, 83.27F);
            this.XFecha.Name = "XFecha";
            this.XFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XFecha.SizeF = new System.Drawing.SizeF(188.3619F, 13F);
            this.XFecha.StylePriority.UseFont = false;
            this.XFecha.StylePriority.UsePadding = false;
            this.XFecha.StylePriority.UseTextAlignment = false;
            this.XFecha.Text = "XFecha";
            this.XFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 21F);
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8F);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Arial", 9F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Dpi = 100F;
            this.topMarginBand1.HeightF = 10F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Dpi = 100F;
            this.bottomMarginBand1.HeightF = 10F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // parameterCedis
            // 
            this.parameterCedis.Description = "parameterCedis";
            this.parameterCedis.Name = "parameterCedis";
            this.parameterCedis.ValueInfo = "1";
            this.parameterCedis.Visible = false;
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.ValueInfo = "20/01/15";
            this.parameterDateIni.Visible = false;
            // 
            // R196_Report_Design
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R196ResumenTiempoMovimiento";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedis,
            this.parameterDateIni});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
