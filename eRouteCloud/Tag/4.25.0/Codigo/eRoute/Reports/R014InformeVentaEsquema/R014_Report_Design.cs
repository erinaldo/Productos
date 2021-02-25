using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R014_Report_Design
/// </summary>
public class R014_Report_Design : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel30;
    private XRLabel xrLabel32;
    public XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel37;
    public XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLabel xrLabel41;
    private XRLabel xrLabel43;
    public XRLabel xrLabel44;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel4;
    private GroupHeaderBand groupHeaderBand3;
    private XRLabel xrLabel6;
    private GroupHeaderBand groupHeaderBand4;
    private GroupHeaderBand groupHeaderBand5;
    private XRLabel xrLabel12;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand6;
    private XRLabel xrLabel150;
    private XRLabel xrLabel152;
    public XRLabel xrLabel153;
    private XRLabel xrLabel154;
    private XRLabel xrLabel156;
    public XRLabel xrLabel157;
    private XRLabel xrLabel158;
    private XRLabel xrLabel160;
    public XRLabel xrLabel161;
    private ReportFooterBand reportFooterBand1;
    private XRLabel xrLabel177;
    private XRLabel xrLabel178;
    public XRLabel xrLabel179;
    private XRLabel xrLabel181;
    private XRLabel xrLabel182;
    public XRLabel xrLabel183;
    private XRLabel xrLabel185;
    private XRLabel xrLabel186;
    public XRLabel xrLabel187;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    public XRPictureBox logo;
    public XRLabel report_Company;
    public XRLabel report_Name;
    public XRLabel headerFecha;
    public XRLabel headerCEDI;
    public XRLabel headerVendedor;
    public XRLabel L_VendedorNombre;
    public XRLabel L_CEDI;
    public XRLabel L_FechaRango;
    public XRLabel groupCEDI;
    public XRLabel groupFecha;
    public XRLabel groupVendedor;
    public XRLabel groupHeaderRuta;
    private XRLabel xrLabel192;
    private CalculatedField GroupRuta;
    private PageHeaderBand PageHeader;
    private XRLine xrLine4;
    private XRLine xrLine3;
    public XRLabel Lb_Clave;
    public XRLabel Lb_Moneda3;
    public XRLabel Lb_KgLts3;
    public XRLabel Lb_Cantidad3;
    public XRLabel Lb_Moneda2;
    public XRLabel Lb_KgLts2;
    public XRLabel Lb_Cantidad2;
    public XRLabel Lb_Moneda;
    public XRLabel Lb_KgLts;
    public XRLabel Lb_Cantidad;
    public XRLabel Lb_Cambio;
    public XRLabel Lb_Devolucion;
    public XRLabel Lb_Venta;
    public XRLabel Lb_Unidad;
    public XRLabel Lb_Producto;
    private XRLabel xrLabel14;
    public XRLabel Lb_Total;
    public XRLabel Cambios3;
    public XRLabel Devoluciones3;
    public XRLabel Ventas3;
    public XRLabel Lb_ResumenKgLts;
    public XRLabel Cambios2;
    public XRLabel Devoluciones2;
    public XRLabel Ventas2;
    public XRLabel Lb_ResumenImportes;
    public XRLabel Cambios1;
    public XRLabel Devoluciones1;
    public XRLabel Ventas1;
    public XRLabel Lb_ResumenUnidades;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRPageInfo xrPageInfo3;
    private XRPageInfo xrPageInfo4;
    private XRLabel xrLabel36;
    private DevExpress.XtraReports.Parameters.Parameter parameterCEDI;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterRoutes;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateEnd;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R014_Report_Design()
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
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R014_Report_Design));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary15 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary16 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary17 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary18 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.groupCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.groupFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.groupVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel192 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.headerCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VendedorNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand6 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.Lb_Total = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel150 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel152 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel153 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel154 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel156 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel157 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel158 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel160 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel161 = new DevExpress.XtraReports.UI.XRLabel();
            this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.Cambios3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Devoluciones3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Ventas3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_ResumenKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.Cambios2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Devoluciones2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Ventas2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_ResumenImportes = new DevExpress.XtraReports.UI.XRLabel();
            this.Cambios1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Devoluciones1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Ventas1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_ResumenUnidades = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel177 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel178 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel179 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel181 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel182 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel183 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel185 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel186 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel187 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupRuta = new DevExpress.XtraReports.UI.CalculatedField();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Lb_Moneda3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_KgLts3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Cantidad3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Moneda2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_KgLts2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Cantidad2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Moneda = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_KgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Cantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Cambio = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Devolucion = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Venta = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Unidad = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Producto = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Clave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.parameterCEDI = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRoutes = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateEnd = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel30,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39,
            this.xrLabel41,
            this.xrLabel43,
            this.xrLabel44,
            this.xrLabel14});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Clave", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel30
            // 
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioCant")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(835.4168F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(79.58319F, 13F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UsePadding = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "xrLabel30";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioDinero", "{0:n}")});
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(995.4169F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(79.58313F, 13F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UsePadding = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "xrLabel32";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel33
            // 
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioKg", "{0:n}")});
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(915.4166F, 0F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(79.58344F, 13F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UsePadding = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "xrLabel33";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel34
            // 
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.Clave")});
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 0F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(79.58331F, 13F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "xrLabel34";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel35
            // 
            this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionCant")});
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(595.4166F, 0F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(79.58344F, 13F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UsePadding = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "xrLabel35";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel37
            // 
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionDinero", "{0:n}")});
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(755.4165F, 0F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(79.58344F, 13F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UsePadding = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "xrLabel37";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel38
            // 
            this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionKg", "{0:n}")});
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(675.4167F, 0F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(79.58344F, 13F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UsePadding = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "xrLabel38";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel39
            // 
            this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.Producto")});
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(83.8225F, 0F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(181.1775F, 13F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "xrLabel39";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaCant")});
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(355.4167F, 0F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(79.58331F, 13F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UsePadding = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "xrLabel41";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel43
            // 
            this.xrLabel43.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaDinero", "{0:n}")});
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(515.4167F, 0F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(79.58319F, 13F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UsePadding = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "xrLabel43";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel44
            // 
            this.xrLabel44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaKg", "{0:n}")});
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(435.4168F, 0F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(79.58319F, 13F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UsePadding = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.Text = "xrLabel44";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.CanGrow = false;
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(265.4167F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Unidades";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.sqlDataSource1.ConnectionOptions.CommandTimeout = 300;
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_R014InformeVentaEsquema";
            queryParameter1.Name = "@FILTROCEDI";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCEDI]", typeof(string));
            queryParameter2.Name = "@FILTROVENDEDOR";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterSeller]", typeof(string));
            queryParameter3.Name = "@FILTRORUTAS";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRoutes]", typeof(string));
            queryParameter4.Name = "@FILTROFECHAINI";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            queryParameter5.Name = "@FILTROFECHAFIN";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateEnd]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.StoredProcName = "stpr_R014InformeVentaEsquema";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.groupCEDI,
            this.xrLabel2});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CEDI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 20F;
            this.groupHeaderBand1.Level = 4;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // groupCEDI
            // 
            this.groupCEDI.CanGrow = false;
            this.groupCEDI.Dpi = 100F;
            this.groupCEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCEDI.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupCEDI.Name = "groupCEDI";
            this.groupCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.groupCEDI.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupCEDI.StylePriority.UseFont = false;
            this.groupCEDI.StylePriority.UseTextAlignment = false;
            this.groupCEDI.Text = "Centro de Distribución:";
            this.groupCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CEDI")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(180F, 14.55F);
            this.xrLabel2.StyleName = "DataField";
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.groupFecha,
            this.xrLabel4});
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Fecha", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand2.HeightF = 20F;
            this.groupHeaderBand2.Level = 3;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            // 
            // groupFecha
            // 
            this.groupFecha.CanGrow = false;
            this.groupFecha.Dpi = 100F;
            this.groupFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupFecha.Name = "groupFecha";
            this.groupFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(12, 2, 0, 0, 100F);
            this.groupFecha.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupFecha.StylePriority.UseFont = false;
            this.groupFecha.StylePriority.UsePadding = false;
            this.groupFecha.StylePriority.UseTextAlignment = false;
            this.groupFecha.Text = "Fecha";
            this.groupFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.Fecha", "{0:dd/MM/yyyy}")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(180F, 14.55F);
            this.xrLabel4.StyleName = "DataField";
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "xrLabel4";
            // 
            // groupHeaderBand3
            // 
            this.groupHeaderBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.groupVendedor,
            this.xrLabel6});
            this.groupHeaderBand3.Dpi = 100F;
            this.groupHeaderBand3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand3.HeightF = 20F;
            this.groupHeaderBand3.Level = 2;
            this.groupHeaderBand3.Name = "groupHeaderBand3";
            // 
            // groupVendedor
            // 
            this.groupVendedor.CanGrow = false;
            this.groupVendedor.Dpi = 100F;
            this.groupVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupVendedor.Name = "groupVendedor";
            this.groupVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(24, 2, 0, 0, 100F);
            this.groupVendedor.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupVendedor.StylePriority.UseFont = false;
            this.groupVendedor.StylePriority.UsePadding = false;
            this.groupVendedor.StylePriority.UseTextAlignment = false;
            this.groupVendedor.Text = "Vendedor";
            this.groupVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.Vendedor")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(180F, 14.55F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "xrLabel6";
            // 
            // groupHeaderBand4
            // 
            this.groupHeaderBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel192,
            this.groupHeaderRuta});
            this.groupHeaderBand4.Dpi = 100F;
            this.groupHeaderBand4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Ruta", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("RutaNombre", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand4.HeightF = 20F;
            this.groupHeaderBand4.Level = 1;
            this.groupHeaderBand4.Name = "groupHeaderBand4";
            // 
            // xrLabel192
            // 
            this.xrLabel192.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.GroupRuta")});
            this.xrLabel192.Dpi = 100F;
            this.xrLabel192.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel192.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel192.Name = "xrLabel192";
            this.xrLabel192.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel192.SizeF = new System.Drawing.SizeF(180F, 14.55F);
            this.xrLabel192.StylePriority.UseFont = false;
            this.xrLabel192.Text = "xrLabel192";
            // 
            // groupHeaderRuta
            // 
            this.groupHeaderRuta.CanGrow = false;
            this.groupHeaderRuta.Dpi = 100F;
            this.groupHeaderRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupHeaderRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.groupHeaderRuta.Name = "groupHeaderRuta";
            this.groupHeaderRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(36, 2, 0, 0, 100F);
            this.groupHeaderRuta.SizeF = new System.Drawing.SizeF(130F, 14.55F);
            this.groupHeaderRuta.StylePriority.UseFont = false;
            this.groupHeaderRuta.StylePriority.UsePadding = false;
            this.groupHeaderRuta.StylePriority.UseTextAlignment = false;
            this.groupHeaderRuta.Text = "Ruta";
            this.groupHeaderRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderBand5
            // 
            this.groupHeaderBand5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12});
            this.groupHeaderBand5.Dpi = 100F;
            this.groupHeaderBand5.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Esquema", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand5.HeightF = 20F;
            this.groupHeaderBand5.Name = "groupHeaderBand5";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.Esquema")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(48, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(300F, 14.55F);
            this.xrLabel12.StyleName = "DataField";
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.Text = "xrLabel12";
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo4,
            this.xrLabel36,
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
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(786.27F, 5F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(150F, 14F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UsePadding = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "Fecha Hora Impresión";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.headerFecha,
            this.headerCEDI,
            this.headerVendedor,
            this.L_VendedorNombre,
            this.L_CEDI,
            this.L_FechaRango,
            this.report_Name,
            this.report_Company,
            this.logo});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 115F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(220.0484F, 83.27084F);
            this.headerFecha.Name = "headerFecha";
            this.headerFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerFecha.SizeF = new System.Drawing.SizeF(188.3619F, 13F);
            this.headerFecha.StylePriority.UseFont = false;
            this.headerFecha.StylePriority.UsePadding = false;
            this.headerFecha.StylePriority.UseTextAlignment = false;
            this.headerFecha.Text = "Fecha";
            this.headerFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerCEDI
            // 
            this.headerCEDI.Dpi = 100F;
            this.headerCEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerCEDI.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 67.68748F);
            this.headerCEDI.Name = "headerCEDI";
            this.headerCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerCEDI.SizeF = new System.Drawing.SizeF(187.9904F, 13F);
            this.headerCEDI.StylePriority.UseFont = false;
            this.headerCEDI.StylePriority.UsePadding = false;
            this.headerCEDI.StylePriority.UseTextAlignment = false;
            this.headerCEDI.Text = "Centro de Distribución";
            this.headerCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerVendedor
            // 
            this.headerVendedor.Dpi = 100F;
            this.headerVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(220.0484F, 96.27088F);
            this.headerVendedor.Name = "headerVendedor";
            this.headerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.headerVendedor.SizeF = new System.Drawing.SizeF(188.3619F, 13F);
            this.headerVendedor.StylePriority.UseFont = false;
            this.headerVendedor.StylePriority.UsePadding = false;
            this.headerVendedor.StylePriority.UseTextAlignment = false;
            this.headerVendedor.Text = "Vendedor";
            this.headerVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_VendedorNombre
            // 
            this.L_VendedorNombre.Dpi = 100F;
            this.L_VendedorNombre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VendedorNombre.LocationFloat = new DevExpress.Utils.PointFloat(423.8874F, 96.27088F);
            this.L_VendedorNombre.Name = "L_VendedorNombre";
            this.L_VendedorNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_VendedorNombre.SizeF = new System.Drawing.SizeF(300.2653F, 13F);
            this.L_VendedorNombre.StylePriority.UseFont = false;
            this.L_VendedorNombre.StylePriority.UsePadding = false;
            this.L_VendedorNombre.StylePriority.UseTextAlignment = false;
            this.L_VendedorNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_CEDI
            // 
            this.L_CEDI.Dpi = 100F;
            this.L_CEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CEDI.LocationFloat = new DevExpress.Utils.PointFloat(423.8874F, 67.68748F);
            this.L_CEDI.Name = "L_CEDI";
            this.L_CEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_CEDI.SizeF = new System.Drawing.SizeF(299.8937F, 13F);
            this.L_CEDI.StylePriority.UseFont = false;
            this.L_CEDI.StylePriority.UsePadding = false;
            this.L_CEDI.StylePriority.UseTextAlignment = false;
            this.L_CEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(423.8874F, 83.27084F);
            this.L_FechaRango.Name = "L_FechaRango";
            this.L_FechaRango.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_FechaRango.SizeF = new System.Drawing.SizeF(299.5219F, 12.99999F);
            this.L_FechaRango.StylePriority.UseFont = false;
            this.L_FechaRango.StylePriority.UsePadding = false;
            this.L_FechaRango.StylePriority.UseTextAlignment = false;
            this.L_FechaRango.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(6.42F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(100F, 100F);
            // 
            // groupFooterBand1
            // 
            this.groupFooterBand1.Dpi = 100F;
            this.groupFooterBand1.HeightF = 1F;
            this.groupFooterBand1.Name = "groupFooterBand1";
            // 
            // groupFooterBand6
            // 
            this.groupFooterBand6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_Total,
            this.xrLabel150,
            this.xrLabel152,
            this.xrLabel153,
            this.xrLabel154,
            this.xrLabel156,
            this.xrLabel157,
            this.xrLabel158,
            this.xrLabel160,
            this.xrLabel161});
            this.groupFooterBand6.Dpi = 100F;
            this.groupFooterBand6.HeightF = 50F;
            this.groupFooterBand6.Name = "groupFooterBand6";
            // 
            // Lb_Total
            // 
            this.Lb_Total.CanGrow = false;
            this.Lb_Total.Dpi = 100F;
            this.Lb_Total.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Total.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 10.00001F);
            this.Lb_Total.Name = "Lb_Total";
            this.Lb_Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_Total.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Lb_Total.StylePriority.UseFont = false;
            this.Lb_Total.StylePriority.UsePadding = false;
            this.Lb_Total.StylePriority.UseTextAlignment = false;
            this.Lb_Total.Text = "Lb_Total";
            this.Lb_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel150
            // 
            this.xrLabel150.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioCant")});
            this.xrLabel150.Dpi = 100F;
            this.xrLabel150.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel150.LocationFloat = new DevExpress.Utils.PointFloat(835.42F, 10F);
            this.xrLabel150.Name = "xrLabel150";
            this.xrLabel150.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel150.SizeF = new System.Drawing.SizeF(79.58319F, 13F);
            this.xrLabel150.StyleName = "FieldCaption";
            this.xrLabel150.StylePriority.UseFont = false;
            this.xrLabel150.StylePriority.UsePadding = false;
            this.xrLabel150.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel150.Summary = xrSummary1;
            this.xrLabel150.Text = "xrLabel150";
            this.xrLabel150.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel152
            // 
            this.xrLabel152.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioDinero")});
            this.xrLabel152.Dpi = 100F;
            this.xrLabel152.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel152.LocationFloat = new DevExpress.Utils.PointFloat(995.42F, 10F);
            this.xrLabel152.Name = "xrLabel152";
            this.xrLabel152.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel152.SizeF = new System.Drawing.SizeF(79.58313F, 13F);
            this.xrLabel152.StyleName = "FieldCaption";
            this.xrLabel152.StylePriority.UseFont = false;
            this.xrLabel152.StylePriority.UsePadding = false;
            this.xrLabel152.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel152.Summary = xrSummary2;
            this.xrLabel152.Text = "xrLabel152";
            this.xrLabel152.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel153
            // 
            this.xrLabel153.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioKg")});
            this.xrLabel153.Dpi = 100F;
            this.xrLabel153.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel153.LocationFloat = new DevExpress.Utils.PointFloat(915.83F, 10F);
            this.xrLabel153.Name = "xrLabel153";
            this.xrLabel153.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel153.SizeF = new System.Drawing.SizeF(79.16687F, 13F);
            this.xrLabel153.StyleName = "FieldCaption";
            this.xrLabel153.StylePriority.UseFont = false;
            this.xrLabel153.StylePriority.UsePadding = false;
            this.xrLabel153.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel153.Summary = xrSummary3;
            this.xrLabel153.Text = "xrLabel153";
            this.xrLabel153.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel154
            // 
            this.xrLabel154.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionCant")});
            this.xrLabel154.Dpi = 100F;
            this.xrLabel154.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel154.LocationFloat = new DevExpress.Utils.PointFloat(595.42F, 10F);
            this.xrLabel154.Name = "xrLabel154";
            this.xrLabel154.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel154.SizeF = new System.Drawing.SizeF(79.58344F, 13F);
            this.xrLabel154.StyleName = "FieldCaption";
            this.xrLabel154.StylePriority.UseFont = false;
            this.xrLabel154.StylePriority.UsePadding = false;
            this.xrLabel154.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel154.Summary = xrSummary4;
            this.xrLabel154.Text = "xrLabel154";
            this.xrLabel154.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel156
            // 
            this.xrLabel156.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionDinero")});
            this.xrLabel156.Dpi = 100F;
            this.xrLabel156.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel156.LocationFloat = new DevExpress.Utils.PointFloat(755.83F, 10F);
            this.xrLabel156.Name = "xrLabel156";
            this.xrLabel156.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel156.SizeF = new System.Drawing.SizeF(79.16687F, 13F);
            this.xrLabel156.StyleName = "FieldCaption";
            this.xrLabel156.StylePriority.UseFont = false;
            this.xrLabel156.StylePriority.UsePadding = false;
            this.xrLabel156.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:n}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel156.Summary = xrSummary5;
            this.xrLabel156.Text = "xrLabel156";
            this.xrLabel156.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel157
            // 
            this.xrLabel157.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionKg")});
            this.xrLabel157.Dpi = 100F;
            this.xrLabel157.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel157.LocationFloat = new DevExpress.Utils.PointFloat(675.42F, 10F);
            this.xrLabel157.Name = "xrLabel157";
            this.xrLabel157.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel157.SizeF = new System.Drawing.SizeF(79.58344F, 13F);
            this.xrLabel157.StyleName = "FieldCaption";
            this.xrLabel157.StylePriority.UseFont = false;
            this.xrLabel157.StylePriority.UsePadding = false;
            this.xrLabel157.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:n}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel157.Summary = xrSummary6;
            this.xrLabel157.Text = "xrLabel157";
            this.xrLabel157.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel158
            // 
            this.xrLabel158.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaCant")});
            this.xrLabel158.Dpi = 100F;
            this.xrLabel158.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel158.LocationFloat = new DevExpress.Utils.PointFloat(355.83F, 10F);
            this.xrLabel158.Name = "xrLabel158";
            this.xrLabel158.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel158.SizeF = new System.Drawing.SizeF(79.16663F, 13F);
            this.xrLabel158.StyleName = "FieldCaption";
            this.xrLabel158.StylePriority.UseFont = false;
            this.xrLabel158.StylePriority.UsePadding = false;
            this.xrLabel158.StylePriority.UseTextAlignment = false;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel158.Summary = xrSummary7;
            this.xrLabel158.Text = "xrLabel158";
            this.xrLabel158.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel160
            // 
            this.xrLabel160.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaDinero")});
            this.xrLabel160.Dpi = 100F;
            this.xrLabel160.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel160.LocationFloat = new DevExpress.Utils.PointFloat(515.83F, 10F);
            this.xrLabel160.Name = "xrLabel160";
            this.xrLabel160.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel160.SizeF = new System.Drawing.SizeF(79.1665F, 13F);
            this.xrLabel160.StyleName = "FieldCaption";
            this.xrLabel160.StylePriority.UseFont = false;
            this.xrLabel160.StylePriority.UsePadding = false;
            this.xrLabel160.StylePriority.UseTextAlignment = false;
            xrSummary8.FormatString = "{0:n}";
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel160.Summary = xrSummary8;
            this.xrLabel160.Text = "xrLabel160";
            this.xrLabel160.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel161
            // 
            this.xrLabel161.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaKg")});
            this.xrLabel161.Dpi = 100F;
            this.xrLabel161.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel161.LocationFloat = new DevExpress.Utils.PointFloat(435.83F, 10F);
            this.xrLabel161.Name = "xrLabel161";
            this.xrLabel161.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel161.SizeF = new System.Drawing.SizeF(79.1665F, 13F);
            this.xrLabel161.StyleName = "FieldCaption";
            this.xrLabel161.StylePriority.UseFont = false;
            this.xrLabel161.StylePriority.UsePadding = false;
            this.xrLabel161.StylePriority.UseTextAlignment = false;
            xrSummary9.FormatString = "{0:n}";
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel161.Summary = xrSummary9;
            this.xrLabel161.Text = "xrLabel161";
            this.xrLabel161.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // reportFooterBand1
            // 
            this.reportFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLine1,
            this.Cambios3,
            this.Devoluciones3,
            this.Ventas3,
            this.Lb_ResumenKgLts,
            this.Cambios2,
            this.Devoluciones2,
            this.Ventas2,
            this.Lb_ResumenImportes,
            this.Cambios1,
            this.Devoluciones1,
            this.Ventas1,
            this.Lb_ResumenUnidades,
            this.xrLabel177,
            this.xrLabel178,
            this.xrLabel179,
            this.xrLabel181,
            this.xrLabel182,
            this.xrLabel183,
            this.xrLabel185,
            this.xrLabel186,
            this.xrLabel187});
            this.reportFooterBand1.Dpi = 100F;
            this.reportFooterBand1.HeightF = 275.9583F;
            this.reportFooterBand1.Name = "reportFooterBand1";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0.003178914F, 273.9583F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // Cambios3
            // 
            this.Cambios3.CanGrow = false;
            this.Cambios3.Dpi = 100F;
            this.Cambios3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cambios3.LocationFloat = new DevExpress.Utils.PointFloat(220.0484F, 222.6249F);
            this.Cambios3.Name = "Cambios3";
            this.Cambios3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Cambios3.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Cambios3.StylePriority.UseFont = false;
            this.Cambios3.StylePriority.UsePadding = false;
            this.Cambios3.StylePriority.UseTextAlignment = false;
            this.Cambios3.Text = "Cambios";
            this.Cambios3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Devoluciones3
            // 
            this.Devoluciones3.CanGrow = false;
            this.Devoluciones3.Dpi = 100F;
            this.Devoluciones3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Devoluciones3.LocationFloat = new DevExpress.Utils.PointFloat(109.6734F, 222.6249F);
            this.Devoluciones3.Name = "Devoluciones3";
            this.Devoluciones3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Devoluciones3.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Devoluciones3.StylePriority.UseFont = false;
            this.Devoluciones3.StylePriority.UsePadding = false;
            this.Devoluciones3.StylePriority.UseTextAlignment = false;
            this.Devoluciones3.Text = "Devoluciones";
            this.Devoluciones3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Ventas3
            // 
            this.Ventas3.CanGrow = false;
            this.Ventas3.Dpi = 100F;
            this.Ventas3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ventas3.LocationFloat = new DevExpress.Utils.PointFloat(0.8333842F, 222.6249F);
            this.Ventas3.Name = "Ventas3";
            this.Ventas3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Ventas3.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Ventas3.StylePriority.UseFont = false;
            this.Ventas3.StylePriority.UsePadding = false;
            this.Ventas3.StylePriority.UseTextAlignment = false;
            this.Ventas3.Text = "Ventas";
            this.Ventas3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_ResumenKgLts
            // 
            this.Lb_ResumenKgLts.CanGrow = false;
            this.Lb_ResumenKgLts.Dpi = 100F;
            this.Lb_ResumenKgLts.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_ResumenKgLts.LocationFloat = new DevExpress.Utils.PointFloat(0F, 190.3332F);
            this.Lb_ResumenKgLts.Multiline = true;
            this.Lb_ResumenKgLts.Name = "Lb_ResumenKgLts";
            this.Lb_ResumenKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_ResumenKgLts.SizeF = new System.Drawing.SizeF(300F, 20F);
            this.Lb_ResumenKgLts.StylePriority.UseFont = false;
            this.Lb_ResumenKgLts.StylePriority.UsePadding = false;
            this.Lb_ResumenKgLts.StylePriority.UseTextAlignment = false;
            this.Lb_ResumenKgLts.Text = "Lb_ResumenKgLts";
            this.Lb_ResumenKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Cambios2
            // 
            this.Cambios2.CanGrow = false;
            this.Cambios2.Dpi = 100F;
            this.Cambios2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cambios2.LocationFloat = new DevExpress.Utils.PointFloat(220.0484F, 135.1249F);
            this.Cambios2.Name = "Cambios2";
            this.Cambios2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Cambios2.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Cambios2.StylePriority.UseFont = false;
            this.Cambios2.StylePriority.UsePadding = false;
            this.Cambios2.StylePriority.UseTextAlignment = false;
            this.Cambios2.Text = "Cambios";
            this.Cambios2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Devoluciones2
            // 
            this.Devoluciones2.CanGrow = false;
            this.Devoluciones2.Dpi = 100F;
            this.Devoluciones2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Devoluciones2.LocationFloat = new DevExpress.Utils.PointFloat(109.6734F, 135.1248F);
            this.Devoluciones2.Name = "Devoluciones2";
            this.Devoluciones2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Devoluciones2.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Devoluciones2.StylePriority.UseFont = false;
            this.Devoluciones2.StylePriority.UsePadding = false;
            this.Devoluciones2.StylePriority.UseTextAlignment = false;
            this.Devoluciones2.Text = "Devoluciones";
            this.Devoluciones2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Ventas2
            // 
            this.Ventas2.CanGrow = false;
            this.Ventas2.Dpi = 100F;
            this.Ventas2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ventas2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 135.1249F);
            this.Ventas2.Name = "Ventas2";
            this.Ventas2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Ventas2.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Ventas2.StylePriority.UseFont = false;
            this.Ventas2.StylePriority.UsePadding = false;
            this.Ventas2.StylePriority.UseTextAlignment = false;
            this.Ventas2.Text = "Ventas";
            this.Ventas2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_ResumenImportes
            // 
            this.Lb_ResumenImportes.CanGrow = false;
            this.Lb_ResumenImportes.Dpi = 100F;
            this.Lb_ResumenImportes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_ResumenImportes.LocationFloat = new DevExpress.Utils.PointFloat(0F, 101.7916F);
            this.Lb_ResumenImportes.Multiline = true;
            this.Lb_ResumenImportes.Name = "Lb_ResumenImportes";
            this.Lb_ResumenImportes.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_ResumenImportes.SizeF = new System.Drawing.SizeF(300F, 20F);
            this.Lb_ResumenImportes.StylePriority.UseFont = false;
            this.Lb_ResumenImportes.StylePriority.UsePadding = false;
            this.Lb_ResumenImportes.StylePriority.UseTextAlignment = false;
            this.Lb_ResumenImportes.Text = "Lb_ResumenImportes";
            this.Lb_ResumenImportes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Cambios1
            // 
            this.Cambios1.CanGrow = false;
            this.Cambios1.Dpi = 100F;
            this.Cambios1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cambios1.LocationFloat = new DevExpress.Utils.PointFloat(220.0484F, 43.45822F);
            this.Cambios1.Name = "Cambios1";
            this.Cambios1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Cambios1.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Cambios1.StylePriority.UseFont = false;
            this.Cambios1.StylePriority.UsePadding = false;
            this.Cambios1.StylePriority.UseTextAlignment = false;
            this.Cambios1.Text = "Cambios";
            this.Cambios1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Devoluciones1
            // 
            this.Devoluciones1.CanGrow = false;
            this.Devoluciones1.Dpi = 100F;
            this.Devoluciones1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Devoluciones1.LocationFloat = new DevExpress.Utils.PointFloat(109.6734F, 43.45822F);
            this.Devoluciones1.Name = "Devoluciones1";
            this.Devoluciones1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Devoluciones1.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Devoluciones1.StylePriority.UseFont = false;
            this.Devoluciones1.StylePriority.UsePadding = false;
            this.Devoluciones1.StylePriority.UseTextAlignment = false;
            this.Devoluciones1.Text = "Devoluciones";
            this.Devoluciones1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Ventas1
            // 
            this.Ventas1.CanGrow = false;
            this.Ventas1.Dpi = 100F;
            this.Ventas1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ventas1.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 43.45822F);
            this.Ventas1.Name = "Ventas1";
            this.Ventas1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Ventas1.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.Ventas1.StylePriority.UseFont = false;
            this.Ventas1.StylePriority.UsePadding = false;
            this.Ventas1.StylePriority.UseTextAlignment = false;
            this.Ventas1.Text = "Ventas";
            this.Ventas1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_ResumenUnidades
            // 
            this.Lb_ResumenUnidades.CanGrow = false;
            this.Lb_ResumenUnidades.Dpi = 100F;
            this.Lb_ResumenUnidades.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_ResumenUnidades.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.20822F);
            this.Lb_ResumenUnidades.Multiline = true;
            this.Lb_ResumenUnidades.Name = "Lb_ResumenUnidades";
            this.Lb_ResumenUnidades.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_ResumenUnidades.SizeF = new System.Drawing.SizeF(300F, 20F);
            this.Lb_ResumenUnidades.StylePriority.UseFont = false;
            this.Lb_ResumenUnidades.StylePriority.UsePadding = false;
            this.Lb_ResumenUnidades.StylePriority.UseTextAlignment = false;
            this.Lb_ResumenUnidades.Text = "Lb_ResumenUnidades";
            this.Lb_ResumenUnidades.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel177
            // 
            this.xrLabel177.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioCantUnit")});
            this.xrLabel177.Dpi = 100F;
            this.xrLabel177.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel177.LocationFloat = new DevExpress.Utils.PointFloat(220.8366F, 67.45827F);
            this.xrLabel177.Name = "xrLabel177";
            this.xrLabel177.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel177.SizeF = new System.Drawing.SizeF(88.79507F, 13F);
            this.xrLabel177.StyleName = "FieldCaption";
            this.xrLabel177.StylePriority.UseFont = false;
            this.xrLabel177.StylePriority.UseTextAlignment = false;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel177.Summary = xrSummary10;
            this.xrLabel177.Text = "xrLabel177";
            this.xrLabel177.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel178
            // 
            this.xrLabel178.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioDinero")});
            this.xrLabel178.Dpi = 100F;
            this.xrLabel178.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel178.LocationFloat = new DevExpress.Utils.PointFloat(221.2533F, 161.5F);
            this.xrLabel178.Name = "xrLabel178";
            this.xrLabel178.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel178.SizeF = new System.Drawing.SizeF(88.74997F, 13F);
            this.xrLabel178.StyleName = "FieldCaption";
            this.xrLabel178.StylePriority.UseFont = false;
            this.xrLabel178.StylePriority.UseTextAlignment = false;
            xrSummary11.FormatString = "{0:n}";
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel178.Summary = xrSummary11;
            this.xrLabel178.Text = "xrLabel178";
            this.xrLabel178.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel179
            // 
            this.xrLabel179.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.CambioKg")});
            this.xrLabel179.Dpi = 100F;
            this.xrLabel179.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel179.LocationFloat = new DevExpress.Utils.PointFloat(221.67F, 249.2917F);
            this.xrLabel179.Name = "xrLabel179";
            this.xrLabel179.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel179.SizeF = new System.Drawing.SizeF(88.33327F, 13F);
            this.xrLabel179.StyleName = "FieldCaption";
            this.xrLabel179.StylePriority.UseFont = false;
            this.xrLabel179.StylePriority.UseTextAlignment = false;
            xrSummary12.FormatString = "{0:n}";
            xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel179.Summary = xrSummary12;
            this.xrLabel179.Text = "xrLabel179";
            this.xrLabel179.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel181
            // 
            this.xrLabel181.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionCantUnit")});
            this.xrLabel181.Dpi = 100F;
            this.xrLabel181.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel181.LocationFloat = new DevExpress.Utils.PointFloat(110.0901F, 67.45827F);
            this.xrLabel181.Name = "xrLabel181";
            this.xrLabel181.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel181.SizeF = new System.Drawing.SizeF(89.16662F, 13F);
            this.xrLabel181.StyleName = "FieldCaption";
            this.xrLabel181.StylePriority.UseFont = false;
            this.xrLabel181.StylePriority.UseTextAlignment = false;
            xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel181.Summary = xrSummary13;
            this.xrLabel181.Text = "xrLabel181";
            this.xrLabel181.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel182
            // 
            this.xrLabel182.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionDinero")});
            this.xrLabel182.Dpi = 100F;
            this.xrLabel182.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel182.LocationFloat = new DevExpress.Utils.PointFloat(110.0901F, 161.5F);
            this.xrLabel182.Name = "xrLabel182";
            this.xrLabel182.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel182.SizeF = new System.Drawing.SizeF(89.16662F, 13F);
            this.xrLabel182.StyleName = "FieldCaption";
            this.xrLabel182.StylePriority.UseFont = false;
            this.xrLabel182.StylePriority.UseTextAlignment = false;
            xrSummary14.FormatString = "{0:n}";
            xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel182.Summary = xrSummary14;
            this.xrLabel182.Text = "xrLabel182";
            this.xrLabel182.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel183
            // 
            this.xrLabel183.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.DevolucionKg")});
            this.xrLabel183.Dpi = 100F;
            this.xrLabel183.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel183.LocationFloat = new DevExpress.Utils.PointFloat(110.5068F, 249.2917F);
            this.xrLabel183.Name = "xrLabel183";
            this.xrLabel183.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel183.SizeF = new System.Drawing.SizeF(88.74992F, 13F);
            this.xrLabel183.StyleName = "FieldCaption";
            this.xrLabel183.StylePriority.UseFont = false;
            this.xrLabel183.StylePriority.UseTextAlignment = false;
            xrSummary15.FormatString = "{0:n}";
            xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel183.Summary = xrSummary15;
            this.xrLabel183.Text = "xrLabel183";
            this.xrLabel183.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel185
            // 
            this.xrLabel185.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaCantUnit")});
            this.xrLabel185.Dpi = 100F;
            this.xrLabel185.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel185.LocationFloat = new DevExpress.Utils.PointFloat(0.8333842F, 67.45827F);
            this.xrLabel185.Name = "xrLabel185";
            this.xrLabel185.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel185.SizeF = new System.Drawing.SizeF(89.16663F, 13F);
            this.xrLabel185.StyleName = "FieldCaption";
            this.xrLabel185.StylePriority.UseFont = false;
            this.xrLabel185.StylePriority.UseTextAlignment = false;
            xrSummary16.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel185.Summary = xrSummary16;
            this.xrLabel185.Text = "xrLabel185";
            this.xrLabel185.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel186
            // 
            this.xrLabel186.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaDinero")});
            this.xrLabel186.Dpi = 100F;
            this.xrLabel186.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel186.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 161.5F);
            this.xrLabel186.Name = "xrLabel186";
            this.xrLabel186.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel186.SizeF = new System.Drawing.SizeF(89.58331F, 13F);
            this.xrLabel186.StyleName = "FieldCaption";
            this.xrLabel186.StylePriority.UseFont = false;
            this.xrLabel186.StylePriority.UseTextAlignment = false;
            xrSummary17.FormatString = "{0:n}";
            xrSummary17.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel186.Summary = xrSummary17;
            this.xrLabel186.Text = "xrLabel186";
            this.xrLabel186.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel187
            // 
            this.xrLabel187.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R014InformeVentaEsquema.VentaKg")});
            this.xrLabel187.Dpi = 100F;
            this.xrLabel187.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel187.LocationFloat = new DevExpress.Utils.PointFloat(0.4166921F, 249.2917F);
            this.xrLabel187.Name = "xrLabel187";
            this.xrLabel187.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel187.SizeF = new System.Drawing.SizeF(90F, 13F);
            this.xrLabel187.StyleName = "FieldCaption";
            this.xrLabel187.StylePriority.UseFont = false;
            this.xrLabel187.StylePriority.UseTextAlignment = false;
            xrSummary18.FormatString = "{0:n}";
            xrSummary18.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel187.Summary = xrSummary18;
            this.xrLabel187.Text = "xrLabel187";
            this.xrLabel187.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // GroupRuta
            // 
            this.GroupRuta.DataMember = "stpr_R014InformeVentaEsquema";
            this.GroupRuta.DisplayName = "GroupRuta";
            this.GroupRuta.Expression = "[Ruta] + \' \' + [RutaNombre]";
            this.GroupRuta.Name = "GroupRuta";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_Moneda3,
            this.Lb_KgLts3,
            this.Lb_Cantidad3,
            this.Lb_Moneda2,
            this.Lb_KgLts2,
            this.Lb_Cantidad2,
            this.Lb_Moneda,
            this.Lb_KgLts,
            this.Lb_Cantidad,
            this.Lb_Cambio,
            this.Lb_Devolucion,
            this.Lb_Venta,
            this.Lb_Unidad,
            this.Lb_Producto,
            this.Lb_Clave,
            this.xrLine4,
            this.xrLine3});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 47F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Lb_Moneda3
            // 
            this.Lb_Moneda3.CanGrow = false;
            this.Lb_Moneda3.Dpi = 100F;
            this.Lb_Moneda3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Moneda3.LocationFloat = new DevExpress.Utils.PointFloat(995.0001F, 25F);
            this.Lb_Moneda3.Name = "Lb_Moneda3";
            this.Lb_Moneda3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Moneda3.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_Moneda3.StylePriority.UseFont = false;
            this.Lb_Moneda3.StylePriority.UsePadding = false;
            this.Lb_Moneda3.StylePriority.UseTextAlignment = false;
            this.Lb_Moneda3.Text = "Lb_Moneda";
            this.Lb_Moneda3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_KgLts3
            // 
            this.Lb_KgLts3.CanGrow = false;
            this.Lb_KgLts3.Dpi = 100F;
            this.Lb_KgLts3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_KgLts3.LocationFloat = new DevExpress.Utils.PointFloat(915F, 25F);
            this.Lb_KgLts3.Name = "Lb_KgLts3";
            this.Lb_KgLts3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_KgLts3.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_KgLts3.StylePriority.UseFont = false;
            this.Lb_KgLts3.StylePriority.UsePadding = false;
            this.Lb_KgLts3.StylePriority.UseTextAlignment = false;
            this.Lb_KgLts3.Text = "Lb_KgLts";
            this.Lb_KgLts3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Cantidad3
            // 
            this.Lb_Cantidad3.CanGrow = false;
            this.Lb_Cantidad3.Dpi = 100F;
            this.Lb_Cantidad3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Cantidad3.LocationFloat = new DevExpress.Utils.PointFloat(835F, 25F);
            this.Lb_Cantidad3.Name = "Lb_Cantidad3";
            this.Lb_Cantidad3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Cantidad3.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_Cantidad3.StylePriority.UseFont = false;
            this.Lb_Cantidad3.StylePriority.UsePadding = false;
            this.Lb_Cantidad3.StylePriority.UseTextAlignment = false;
            this.Lb_Cantidad3.Text = "Lb_Cantidad";
            this.Lb_Cantidad3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Moneda2
            // 
            this.Lb_Moneda2.CanGrow = false;
            this.Lb_Moneda2.Dpi = 100F;
            this.Lb_Moneda2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Moneda2.LocationFloat = new DevExpress.Utils.PointFloat(754.9999F, 25F);
            this.Lb_Moneda2.Name = "Lb_Moneda2";
            this.Lb_Moneda2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Moneda2.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_Moneda2.StylePriority.UseFont = false;
            this.Lb_Moneda2.StylePriority.UsePadding = false;
            this.Lb_Moneda2.StylePriority.UseTextAlignment = false;
            this.Lb_Moneda2.Text = "Lb_Moneda";
            this.Lb_Moneda2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_KgLts2
            // 
            this.Lb_KgLts2.CanGrow = false;
            this.Lb_KgLts2.Dpi = 100F;
            this.Lb_KgLts2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_KgLts2.LocationFloat = new DevExpress.Utils.PointFloat(675.0001F, 25F);
            this.Lb_KgLts2.Name = "Lb_KgLts2";
            this.Lb_KgLts2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_KgLts2.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_KgLts2.StylePriority.UseFont = false;
            this.Lb_KgLts2.StylePriority.UsePadding = false;
            this.Lb_KgLts2.StylePriority.UseTextAlignment = false;
            this.Lb_KgLts2.Text = "Lb_KgLts";
            this.Lb_KgLts2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Cantidad2
            // 
            this.Lb_Cantidad2.CanGrow = false;
            this.Lb_Cantidad2.Dpi = 100F;
            this.Lb_Cantidad2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Cantidad2.LocationFloat = new DevExpress.Utils.PointFloat(595.0001F, 25F);
            this.Lb_Cantidad2.Name = "Lb_Cantidad2";
            this.Lb_Cantidad2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Cantidad2.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_Cantidad2.StylePriority.UseFont = false;
            this.Lb_Cantidad2.StylePriority.UsePadding = false;
            this.Lb_Cantidad2.StylePriority.UseTextAlignment = false;
            this.Lb_Cantidad2.Text = "Lb_Cantidad";
            this.Lb_Cantidad2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Moneda
            // 
            this.Lb_Moneda.CanGrow = false;
            this.Lb_Moneda.Dpi = 100F;
            this.Lb_Moneda.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Moneda.LocationFloat = new DevExpress.Utils.PointFloat(515F, 25F);
            this.Lb_Moneda.Name = "Lb_Moneda";
            this.Lb_Moneda.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Moneda.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_Moneda.StylePriority.UseFont = false;
            this.Lb_Moneda.StylePriority.UsePadding = false;
            this.Lb_Moneda.StylePriority.UseTextAlignment = false;
            this.Lb_Moneda.Text = "Lb_Moneda";
            this.Lb_Moneda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_KgLts
            // 
            this.Lb_KgLts.CanGrow = false;
            this.Lb_KgLts.Dpi = 100F;
            this.Lb_KgLts.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_KgLts.LocationFloat = new DevExpress.Utils.PointFloat(435F, 25F);
            this.Lb_KgLts.Name = "Lb_KgLts";
            this.Lb_KgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_KgLts.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_KgLts.StylePriority.UseFont = false;
            this.Lb_KgLts.StylePriority.UsePadding = false;
            this.Lb_KgLts.StylePriority.UseTextAlignment = false;
            this.Lb_KgLts.Text = "Lb_KgLts";
            this.Lb_KgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Cantidad
            // 
            this.Lb_Cantidad.CanGrow = false;
            this.Lb_Cantidad.Dpi = 100F;
            this.Lb_Cantidad.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Cantidad.LocationFloat = new DevExpress.Utils.PointFloat(355.0001F, 25F);
            this.Lb_Cantidad.Name = "Lb_Cantidad";
            this.Lb_Cantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Cantidad.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_Cantidad.StylePriority.UseFont = false;
            this.Lb_Cantidad.StylePriority.UsePadding = false;
            this.Lb_Cantidad.StylePriority.UseTextAlignment = false;
            this.Lb_Cantidad.Text = "Lb_Cantidad";
            this.Lb_Cantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Cambio
            // 
            this.Lb_Cambio.CanGrow = false;
            this.Lb_Cambio.Dpi = 100F;
            this.Lb_Cambio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Cambio.LocationFloat = new DevExpress.Utils.PointFloat(835F, 4.999987F);
            this.Lb_Cambio.Name = "Lb_Cambio";
            this.Lb_Cambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Cambio.SizeF = new System.Drawing.SizeF(240F, 20F);
            this.Lb_Cambio.StylePriority.UseFont = false;
            this.Lb_Cambio.StylePriority.UsePadding = false;
            this.Lb_Cambio.StylePriority.UseTextAlignment = false;
            this.Lb_Cambio.Text = "Lb_Cambio";
            this.Lb_Cambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Devolucion
            // 
            this.Lb_Devolucion.CanGrow = false;
            this.Lb_Devolucion.Dpi = 100F;
            this.Lb_Devolucion.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Devolucion.LocationFloat = new DevExpress.Utils.PointFloat(595.0001F, 4.999987F);
            this.Lb_Devolucion.Name = "Lb_Devolucion";
            this.Lb_Devolucion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Devolucion.SizeF = new System.Drawing.SizeF(240F, 20F);
            this.Lb_Devolucion.StylePriority.UseFont = false;
            this.Lb_Devolucion.StylePriority.UsePadding = false;
            this.Lb_Devolucion.StylePriority.UseTextAlignment = false;
            this.Lb_Devolucion.Text = "Lb_Devolucion";
            this.Lb_Devolucion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Venta
            // 
            this.Lb_Venta.CanGrow = false;
            this.Lb_Venta.Dpi = 100F;
            this.Lb_Venta.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Venta.LocationFloat = new DevExpress.Utils.PointFloat(355.0001F, 4.999987F);
            this.Lb_Venta.Name = "Lb_Venta";
            this.Lb_Venta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Venta.SizeF = new System.Drawing.SizeF(240F, 20F);
            this.Lb_Venta.StylePriority.UseFont = false;
            this.Lb_Venta.StylePriority.UsePadding = false;
            this.Lb_Venta.StylePriority.UseTextAlignment = false;
            this.Lb_Venta.Text = "Lb_Venta";
            this.Lb_Venta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Unidad
            // 
            this.Lb_Unidad.CanGrow = false;
            this.Lb_Unidad.Dpi = 100F;
            this.Lb_Unidad.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Unidad.LocationFloat = new DevExpress.Utils.PointFloat(265F, 4.999987F);
            this.Lb_Unidad.Name = "Lb_Unidad";
            this.Lb_Unidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Unidad.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Unidad.StylePriority.UseFont = false;
            this.Lb_Unidad.StylePriority.UsePadding = false;
            this.Lb_Unidad.StylePriority.UseTextAlignment = false;
            this.Lb_Unidad.Text = "Lb_Unidad";
            this.Lb_Unidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Producto
            // 
            this.Lb_Producto.CanGrow = false;
            this.Lb_Producto.Dpi = 100F;
            this.Lb_Producto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Producto.LocationFloat = new DevExpress.Utils.PointFloat(80.41674F, 4.999987F);
            this.Lb_Producto.Name = "Lb_Producto";
            this.Lb_Producto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Producto.SizeF = new System.Drawing.SizeF(184.5833F, 20F);
            this.Lb_Producto.StylePriority.UseFont = false;
            this.Lb_Producto.StylePriority.UsePadding = false;
            this.Lb_Producto.StylePriority.UseTextAlignment = false;
            this.Lb_Producto.Text = "Lb_Producto";
            this.Lb_Producto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Clave
            // 
            this.Lb_Clave.CanGrow = false;
            this.Lb_Clave.Dpi = 100F;
            this.Lb_Clave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Clave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5F);
            this.Lb_Clave.Multiline = true;
            this.Lb_Clave.Name = "Lb_Clave";
            this.Lb_Clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Clave.SizeF = new System.Drawing.SizeF(80F, 20F);
            this.Lb_Clave.StylePriority.UseFont = false;
            this.Lb_Clave.StylePriority.UsePadding = false;
            this.Lb_Clave.StylePriority.UseTextAlignment = false;
            this.Lb_Clave.Text = "Lb_Clave\r\n";
            this.Lb_Clave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // parameterCEDI
            // 
            this.parameterCEDI.Description = "parameterCEDI";
            this.parameterCEDI.Name = "parameterCEDI";
            this.parameterCEDI.Visible = false;
            // 
            // parameterSeller
            // 
            this.parameterSeller.Description = "parameterSeller";
            this.parameterSeller.Name = "parameterSeller";
            this.parameterSeller.Visible = false;
            // 
            // parameterRoutes
            // 
            this.parameterRoutes.Description = "parameterRoutes";
            this.parameterRoutes.Name = "parameterRoutes";
            this.parameterRoutes.Visible = false;
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.Visible = false;
            // 
            // parameterDateEnd
            // 
            this.parameterDateEnd.Description = "parameterDateEnd";
            this.parameterDateEnd.Name = "parameterDateEnd";
            this.parameterDateEnd.Visible = false;
            // 
            // R014_Report_Design
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.groupHeaderBand4,
            this.groupHeaderBand5,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand6,
            this.reportFooterBand1,
            this.PageHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.GroupRuta});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R014InformeVentaEsquema";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCEDI,
            this.parameterSeller,
            this.parameterRoutes,
            this.parameterDateIni,
            this.parameterDateEnd});
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
