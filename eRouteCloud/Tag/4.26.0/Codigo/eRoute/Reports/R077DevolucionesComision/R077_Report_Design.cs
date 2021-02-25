using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for R077_Report_Design
/// </summary>
public class R077_Report_Design : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel4;
    private GroupHeaderBand groupHeaderBand3;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private GroupFooterBand groupFooterBand1;
    private GroupFooterBand groupFooterBand2;
    private GroupFooterBand groupFooterBand3;
    private ReportFooterBand reportFooterBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    public XRPictureBox logo;
    public XRLabel headerFecha;
    public XRLabel headerCEDI;
    public XRLabel headerVendedor;
    public XRLabel L_VendedorNombre;
    public XRLabel L_CEDI;
    public XRLabel L_FechaRango;
    public XRLabel report_Name;
    public XRLabel report_Company;
    private PageHeaderBand PageHeader;
    private XRLine xrLine3;
    public XRLabel Lb_Producto;
    public XRLabel Lb_Sabado;
    public XRLabel Lb_Viernes;
    public XRLabel Lb_Jueves;
    public XRLabel Lb_Miercoles;
    public XRLabel Lb_Martes;
    public XRLabel Lb_Lunes;
    public XRLabel Lb_Diferencia;
    public XRLabel Lb_Totales;
    public XRLabel Lb_DiferenciaCosto;
    public XRLabel Lb_Vta1;
    public XRLabel Lb_Dev1;
    public XRLabel Lb_Vta7;
    public XRLabel Lb_Dev7;
    public XRLabel Lb_Vta6;
    public XRLabel Lb_Dev6;
    public XRLabel Lb_Vta5;
    public XRLabel Lb_Dev5;
    public XRLabel Lb_Vta4;
    public XRLabel Lb_Dev4;
    public XRLabel Lb_Vta3;
    public XRLabel Lb_Dev3;
    public XRLabel Lb_Vta2;
    public XRLabel Lb_Dev2;
    public XRLabel Lb_Exe;
    public XRLabel Lb_Top;
    public XRLabel Lb_Pu;
    public XRLabel Lb_TotalPagar;
    private XRLine xrLine4;
    private XRLabel xrLabel1;
    private CalculatedField TotalDevolucion;
    private XRLabel xrLabel3;
    private CalculatedField TotalVenta;
    private XRLabel xrLabel39;
    private CalculatedField Tope;
    private XRLabel xrLabel91;
    private CalculatedField Excedente;
    private XRLabel xrLabel92;
    private CalculatedField TotalAPagar;
    private XRLabel xrLabel22;
    private CalculatedField VentaxPU;
    private XRLabel xrLabel29;
    private XRLabel xrLabel5;
    private CalculatedField ComisionParcial;
    private XRLabel xrLabel6;
    private CalculatedField ComisionFinal;
    private XRPageInfo xrPageInfo3;
    public XRLabel Lb_FechaImpresion;
    private XRPageInfo xrPageInfo4;
    public XRLabel Lb_TotalVenta;
    public XRLabel Lb_TotalDevolucion;
    public XRLabel Lb_ComisionFinal;
    public XRLabel Lb_ComisionParcial;
    private DevExpress.XtraReports.Parameters.Parameter parameterCedi;
    private DevExpress.XtraReports.Parameters.Parameter parameterSeller;
    private DevExpress.XtraReports.Parameters.Parameter parameterDateIni;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public R077_Report_Design()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R077_Report_Design));
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel92 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel91 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.headerCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VendedorNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.report_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupFooterBand3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.Lb_TotalPagar = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Pu = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Exe = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Top = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Vta7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Dev7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Vta6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Dev6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Vta5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Dev5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Vta4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Dev4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Vta3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Dev3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Vta2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Dev2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Vta1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Dev1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_DiferenciaCosto = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Diferencia = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Totales = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Viernes = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Jueves = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Miercoles = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Martes = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Lunes = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Sabado = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_Producto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.TotalDevolucion = new DevExpress.XtraReports.UI.CalculatedField();
            this.TotalVenta = new DevExpress.XtraReports.UI.CalculatedField();
            this.Tope = new DevExpress.XtraReports.UI.CalculatedField();
            this.Excedente = new DevExpress.XtraReports.UI.CalculatedField();
            this.TotalAPagar = new DevExpress.XtraReports.UI.CalculatedField();
            this.VentaxPU = new DevExpress.XtraReports.UI.CalculatedField();
            this.ComisionParcial = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.ComisionFinal = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Lb_FechaImpresion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Lb_TotalVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_ComisionParcial = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_ComisionFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.Lb_TotalDevolucion = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterCedi = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterSeller = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterDateIni = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel92,
            this.xrLabel91,
            this.xrLabel39,
            this.xrLabel3,
            this.xrLabel1,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel27,
            this.xrLabel28,
            this.xrLabel31,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel92
            // 
            this.xrLabel92.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.TotalAPagar", "{0:n}")});
            this.xrLabel92.Dpi = 100F;
            this.xrLabel92.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel92.LocationFloat = new DevExpress.Utils.PointFloat(1001.25F, 0F);
            this.xrLabel92.Name = "xrLabel92";
            this.xrLabel92.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel92.SizeF = new System.Drawing.SizeF(73.75018F, 13F);
            this.xrLabel92.StylePriority.UseFont = false;
            this.xrLabel92.StylePriority.UseTextAlignment = false;
            this.xrLabel92.Text = "xrLabel92";
            this.xrLabel92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel91
            // 
            this.xrLabel91.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.Excedente")});
            this.xrLabel91.Dpi = 100F;
            this.xrLabel91.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel91.LocationFloat = new DevExpress.Utils.PointFloat(905.417F, 0F);
            this.xrLabel91.Name = "xrLabel91";
            this.xrLabel91.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel91.SizeF = new System.Drawing.SizeF(44.58319F, 13F);
            this.xrLabel91.StylePriority.UseFont = false;
            this.xrLabel91.StylePriority.UseTextAlignment = false;
            this.xrLabel91.Text = "xrLabel91";
            this.xrLabel91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel39
            // 
            this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.Tope")});
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(860.4168F, 0F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(44.58344F, 13F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "xrLabel39";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.TotalVenta")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(815.4171F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(44.58319F, 13F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.TotalDevolucion")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(770.4169F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(44.58319F, 13F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.DevolucionJueves")});
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(590.4167F, 0F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(44.58325F, 13F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.DevolucionLunes")});
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(320.4168F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(44.58328F, 13F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "xrLabel24";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.DevolucionMartes")});
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(410.4167F, 0F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(44.58331F, 13F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "xrLabel25";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.DevolucionMiercoles")});
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(500.4166F, 0F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(44.58331F, 13F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "xrLabel26";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.DevolucionSabado")});
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(230.4167F, 0F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(44.58331F, 13F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "xrLabel27";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.DevolucionViernes")});
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(680.4165F, 0F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(42.99542F, 13F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "xrLabel28";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel31
            // 
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.PrecioUnitario", "{0:n}")});
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(950.8333F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(49.58344F, 13F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "xrLabel31";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.Producto")});
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(0.8333842F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(229.1666F, 13F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "xrLabel32";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel33
            // 
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.VentaJueves")});
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(635.4168F, 0F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(44.58319F, 13F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "xrLabel33";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel34
            // 
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.VentaLunes")});
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(365.4167F, 0F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(42.99368F, 13F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "xrLabel34";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel35
            // 
            this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.VentaMartes")});
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(455.4166F, 0F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(44.58337F, 13F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "xrLabel35";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel36
            // 
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.VentaMiercoles")});
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(545.4165F, 0F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(44.58356F, 13F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "xrLabel36";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel37
            // 
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.VentaSabado")});
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(275.4168F, 0F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(44.58319F, 13F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "xrLabel37";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel38
            // 
            this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.VentaViernes")});
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(725.4172F, 0F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(44.58319F, 13F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "xrLabel38";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            storedProcQuery1.Name = "stpr_R077DevolucionesComision";
            queryParameter1.Name = "@filterCedi";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCedi]", typeof(string));
            queryParameter2.Name = "@filterSeller";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterSeller]", typeof(string));
            queryParameter3.Name = "@filterDateIni";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterDateIni]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "stpr_R077DevolucionesComision";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CEDI", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 20F;
            this.groupHeaderBand1.Level = 2;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.CEDI")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(220F, 14.55F);
            this.xrLabel2.StyleName = "DataField";
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4});
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand2.HeightF = 15F;
            this.groupHeaderBand2.Level = 1;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.Vendedor")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(15F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(500F, 14.55F);
            this.xrLabel4.StyleName = "DataField";
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "xrLabel4";
            // 
            // groupHeaderBand3
            // 
            this.groupHeaderBand3.Dpi = 100F;
            this.groupHeaderBand3.HeightF = 27F;
            this.groupHeaderBand3.Name = "groupHeaderBand3";
            this.groupHeaderBand3.StyleName = "FieldCaption";
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo3,
            this.Lb_FechaImpresion,
            this.xrPageInfo4});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.HeightF = 29F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.headerFecha,
            this.headerCEDI,
            this.headerVendedor,
            this.L_VendedorNombre,
            this.L_CEDI,
            this.L_FechaRango,
            this.report_Name,
            this.report_Company});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 120F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(15F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(120F, 100F);
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(220.05F, 83.27F);
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
            this.headerCEDI.LocationFloat = new DevExpress.Utils.PointFloat(220.42F, 67.69F);
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
            this.headerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(220.05F, 96.27F);
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
            this.L_VendedorNombre.CanGrow = false;
            this.L_VendedorNombre.Dpi = 100F;
            this.L_VendedorNombre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VendedorNombre.LocationFloat = new DevExpress.Utils.PointFloat(424.3067F, 96.26999F);
            this.L_VendedorNombre.Name = "L_VendedorNombre";
            this.L_VendedorNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_VendedorNombre.SizeF = new System.Drawing.SizeF(636.1991F, 13F);
            this.L_VendedorNombre.StylePriority.UseFont = false;
            this.L_VendedorNombre.StylePriority.UsePadding = false;
            this.L_VendedorNombre.StylePriority.UseTextAlignment = false;
            this.L_VendedorNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // groupFooterBand1
            // 
            this.groupFooterBand1.Dpi = 100F;
            this.groupFooterBand1.HeightF = 1F;
            this.groupFooterBand1.Name = "groupFooterBand1";
            // 
            // groupFooterBand2
            // 
            this.groupFooterBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Lb_TotalDevolucion,
            this.Lb_ComisionFinal,
            this.Lb_ComisionParcial,
            this.Lb_TotalVenta,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel29,
            this.xrLabel22});
            this.groupFooterBand2.Dpi = 100F;
            this.groupFooterBand2.HeightF = 62.00001F;
            this.groupFooterBand2.Level = 1;
            this.groupFooterBand2.Name = "groupFooterBand2";
            // 
            // xrLabel29
            // 
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.TotalAPagar")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(951.2501F, 36F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(124.1667F, 13F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:n}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel29.Summary = xrSummary3;
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.VentaxPU")});
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(951.2498F, 10.00001F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(123.7502F, 13F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:n}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel22.Summary = xrSummary4;
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // groupFooterBand3
            // 
            this.groupFooterBand3.Dpi = 100F;
            this.groupFooterBand3.HeightF = 30F;
            this.groupFooterBand3.Level = 2;
            this.groupFooterBand3.Name = "groupFooterBand3";
            // 
            // reportFooterBand1
            // 
            this.reportFooterBand1.Dpi = 100F;
            this.reportFooterBand1.HeightF = 30F;
            this.reportFooterBand1.Name = "reportFooterBand1";
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.Lb_TotalPagar,
            this.Lb_Pu,
            this.Lb_Exe,
            this.Lb_Top,
            this.Lb_Vta7,
            this.Lb_Dev7,
            this.Lb_Vta6,
            this.Lb_Dev6,
            this.Lb_Vta5,
            this.Lb_Dev5,
            this.Lb_Vta4,
            this.Lb_Dev4,
            this.Lb_Vta3,
            this.Lb_Dev3,
            this.Lb_Vta2,
            this.Lb_Dev2,
            this.Lb_Vta1,
            this.Lb_Dev1,
            this.Lb_DiferenciaCosto,
            this.Lb_Diferencia,
            this.Lb_Totales,
            this.Lb_Viernes,
            this.Lb_Jueves,
            this.Lb_Miercoles,
            this.Lb_Martes,
            this.Lb_Lunes,
            this.Lb_Sabado,
            this.Lb_Producto,
            this.xrLine3});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 55F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // Lb_TotalPagar
            // 
            this.Lb_TotalPagar.CanGrow = false;
            this.Lb_TotalPagar.Dpi = 100F;
            this.Lb_TotalPagar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TotalPagar.LocationFloat = new DevExpress.Utils.PointFloat(996F, 25F);
            this.Lb_TotalPagar.Multiline = true;
            this.Lb_TotalPagar.Name = "Lb_TotalPagar";
            this.Lb_TotalPagar.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_TotalPagar.SizeF = new System.Drawing.SizeF(79F, 20F);
            this.Lb_TotalPagar.StylePriority.UseFont = false;
            this.Lb_TotalPagar.StylePriority.UsePadding = false;
            this.Lb_TotalPagar.StylePriority.UseTextAlignment = false;
            this.Lb_TotalPagar.Text = "TotalPagar";
            this.Lb_TotalPagar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Lb_Pu
            // 
            this.Lb_Pu.CanGrow = false;
            this.Lb_Pu.Dpi = 100F;
            this.Lb_Pu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Pu.LocationFloat = new DevExpress.Utils.PointFloat(950.4167F, 25F);
            this.Lb_Pu.Multiline = true;
            this.Lb_Pu.Name = "Lb_Pu";
            this.Lb_Pu.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Pu.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Pu.StylePriority.UseFont = false;
            this.Lb_Pu.StylePriority.UsePadding = false;
            this.Lb_Pu.StylePriority.UseTextAlignment = false;
            this.Lb_Pu.Text = "PU";
            this.Lb_Pu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Exe
            // 
            this.Lb_Exe.CanGrow = false;
            this.Lb_Exe.Dpi = 100F;
            this.Lb_Exe.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Exe.LocationFloat = new DevExpress.Utils.PointFloat(905.0002F, 25F);
            this.Lb_Exe.Multiline = true;
            this.Lb_Exe.Name = "Lb_Exe";
            this.Lb_Exe.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Exe.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Exe.StylePriority.UseFont = false;
            this.Lb_Exe.StylePriority.UsePadding = false;
            this.Lb_Exe.StylePriority.UseTextAlignment = false;
            this.Lb_Exe.Text = "Exe";
            this.Lb_Exe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Top
            // 
            this.Lb_Top.CanGrow = false;
            this.Lb_Top.Dpi = 100F;
            this.Lb_Top.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Top.LocationFloat = new DevExpress.Utils.PointFloat(860.0002F, 25F);
            this.Lb_Top.Multiline = true;
            this.Lb_Top.Name = "Lb_Top";
            this.Lb_Top.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Top.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Top.StylePriority.UseFont = false;
            this.Lb_Top.StylePriority.UsePadding = false;
            this.Lb_Top.StylePriority.UseTextAlignment = false;
            this.Lb_Top.Text = "Top";
            this.Lb_Top.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Vta7
            // 
            this.Lb_Vta7.CanGrow = false;
            this.Lb_Vta7.Dpi = 100F;
            this.Lb_Vta7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vta7.LocationFloat = new DevExpress.Utils.PointFloat(815.0003F, 25F);
            this.Lb_Vta7.Multiline = true;
            this.Lb_Vta7.Name = "Lb_Vta7";
            this.Lb_Vta7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Vta7.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Vta7.StylePriority.UseFont = false;
            this.Lb_Vta7.StylePriority.UsePadding = false;
            this.Lb_Vta7.StylePriority.UseTextAlignment = false;
            this.Lb_Vta7.Text = "Vta";
            this.Lb_Vta7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Dev7
            // 
            this.Lb_Dev7.CanGrow = false;
            this.Lb_Dev7.Dpi = 100F;
            this.Lb_Dev7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Dev7.LocationFloat = new DevExpress.Utils.PointFloat(770.0001F, 25F);
            this.Lb_Dev7.Multiline = true;
            this.Lb_Dev7.Name = "Lb_Dev7";
            this.Lb_Dev7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Dev7.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Dev7.StylePriority.UseFont = false;
            this.Lb_Dev7.StylePriority.UsePadding = false;
            this.Lb_Dev7.StylePriority.UseTextAlignment = false;
            this.Lb_Dev7.Text = "Dev";
            this.Lb_Dev7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Vta6
            // 
            this.Lb_Vta6.CanGrow = false;
            this.Lb_Vta6.Dpi = 100F;
            this.Lb_Vta6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vta6.LocationFloat = new DevExpress.Utils.PointFloat(725.0004F, 25F);
            this.Lb_Vta6.Multiline = true;
            this.Lb_Vta6.Name = "Lb_Vta6";
            this.Lb_Vta6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Vta6.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Vta6.StylePriority.UseFont = false;
            this.Lb_Vta6.StylePriority.UsePadding = false;
            this.Lb_Vta6.StylePriority.UseTextAlignment = false;
            this.Lb_Vta6.Text = "Vta";
            this.Lb_Vta6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Dev6
            // 
            this.Lb_Dev6.CanGrow = false;
            this.Lb_Dev6.Dpi = 100F;
            this.Lb_Dev6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Dev6.LocationFloat = new DevExpress.Utils.PointFloat(679.9999F, 25F);
            this.Lb_Dev6.Multiline = true;
            this.Lb_Dev6.Name = "Lb_Dev6";
            this.Lb_Dev6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Dev6.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Dev6.StylePriority.UseFont = false;
            this.Lb_Dev6.StylePriority.UsePadding = false;
            this.Lb_Dev6.StylePriority.UseTextAlignment = false;
            this.Lb_Dev6.Text = "Dev";
            this.Lb_Dev6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Vta5
            // 
            this.Lb_Vta5.CanGrow = false;
            this.Lb_Vta5.Dpi = 100F;
            this.Lb_Vta5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vta5.LocationFloat = new DevExpress.Utils.PointFloat(635F, 25F);
            this.Lb_Vta5.Multiline = true;
            this.Lb_Vta5.Name = "Lb_Vta5";
            this.Lb_Vta5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Vta5.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Vta5.StylePriority.UseFont = false;
            this.Lb_Vta5.StylePriority.UsePadding = false;
            this.Lb_Vta5.StylePriority.UseTextAlignment = false;
            this.Lb_Vta5.Text = "Vta";
            this.Lb_Vta5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Dev5
            // 
            this.Lb_Dev5.CanGrow = false;
            this.Lb_Dev5.Dpi = 100F;
            this.Lb_Dev5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Dev5.LocationFloat = new DevExpress.Utils.PointFloat(590F, 25F);
            this.Lb_Dev5.Multiline = true;
            this.Lb_Dev5.Name = "Lb_Dev5";
            this.Lb_Dev5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Dev5.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Dev5.StylePriority.UseFont = false;
            this.Lb_Dev5.StylePriority.UsePadding = false;
            this.Lb_Dev5.StylePriority.UseTextAlignment = false;
            this.Lb_Dev5.Text = "Dev";
            this.Lb_Dev5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Vta4
            // 
            this.Lb_Vta4.CanGrow = false;
            this.Lb_Vta4.Dpi = 100F;
            this.Lb_Vta4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vta4.LocationFloat = new DevExpress.Utils.PointFloat(545.0001F, 25F);
            this.Lb_Vta4.Multiline = true;
            this.Lb_Vta4.Name = "Lb_Vta4";
            this.Lb_Vta4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Vta4.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Vta4.StylePriority.UseFont = false;
            this.Lb_Vta4.StylePriority.UsePadding = false;
            this.Lb_Vta4.StylePriority.UseTextAlignment = false;
            this.Lb_Vta4.Text = "Vta";
            this.Lb_Vta4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Dev4
            // 
            this.Lb_Dev4.CanGrow = false;
            this.Lb_Dev4.Dpi = 100F;
            this.Lb_Dev4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Dev4.LocationFloat = new DevExpress.Utils.PointFloat(499.9999F, 25F);
            this.Lb_Dev4.Multiline = true;
            this.Lb_Dev4.Name = "Lb_Dev4";
            this.Lb_Dev4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Dev4.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Dev4.StylePriority.UseFont = false;
            this.Lb_Dev4.StylePriority.UsePadding = false;
            this.Lb_Dev4.StylePriority.UseTextAlignment = false;
            this.Lb_Dev4.Text = "Dev";
            this.Lb_Dev4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Vta3
            // 
            this.Lb_Vta3.CanGrow = false;
            this.Lb_Vta3.Dpi = 100F;
            this.Lb_Vta3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vta3.LocationFloat = new DevExpress.Utils.PointFloat(454.9999F, 25F);
            this.Lb_Vta3.Multiline = true;
            this.Lb_Vta3.Name = "Lb_Vta3";
            this.Lb_Vta3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Vta3.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Vta3.StylePriority.UseFont = false;
            this.Lb_Vta3.StylePriority.UsePadding = false;
            this.Lb_Vta3.StylePriority.UseTextAlignment = false;
            this.Lb_Vta3.Text = "Vta";
            this.Lb_Vta3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Dev3
            // 
            this.Lb_Dev3.CanGrow = false;
            this.Lb_Dev3.Dpi = 100F;
            this.Lb_Dev3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Dev3.LocationFloat = new DevExpress.Utils.PointFloat(410F, 25F);
            this.Lb_Dev3.Multiline = true;
            this.Lb_Dev3.Name = "Lb_Dev3";
            this.Lb_Dev3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Dev3.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Dev3.StylePriority.UseFont = false;
            this.Lb_Dev3.StylePriority.UsePadding = false;
            this.Lb_Dev3.StylePriority.UseTextAlignment = false;
            this.Lb_Dev3.Text = "Dev";
            this.Lb_Dev3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Vta2
            // 
            this.Lb_Vta2.CanGrow = false;
            this.Lb_Vta2.Dpi = 100F;
            this.Lb_Vta2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vta2.LocationFloat = new DevExpress.Utils.PointFloat(365F, 25F);
            this.Lb_Vta2.Multiline = true;
            this.Lb_Vta2.Name = "Lb_Vta2";
            this.Lb_Vta2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Vta2.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Vta2.StylePriority.UseFont = false;
            this.Lb_Vta2.StylePriority.UsePadding = false;
            this.Lb_Vta2.StylePriority.UseTextAlignment = false;
            this.Lb_Vta2.Text = "Vta";
            this.Lb_Vta2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Dev2
            // 
            this.Lb_Dev2.CanGrow = false;
            this.Lb_Dev2.Dpi = 100F;
            this.Lb_Dev2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Dev2.LocationFloat = new DevExpress.Utils.PointFloat(320.0001F, 25F);
            this.Lb_Dev2.Multiline = true;
            this.Lb_Dev2.Name = "Lb_Dev2";
            this.Lb_Dev2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Dev2.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Dev2.StylePriority.UseFont = false;
            this.Lb_Dev2.StylePriority.UsePadding = false;
            this.Lb_Dev2.StylePriority.UseTextAlignment = false;
            this.Lb_Dev2.Text = "Dev";
            this.Lb_Dev2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Vta1
            // 
            this.Lb_Vta1.CanGrow = false;
            this.Lb_Vta1.Dpi = 100F;
            this.Lb_Vta1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Vta1.LocationFloat = new DevExpress.Utils.PointFloat(275.0001F, 25F);
            this.Lb_Vta1.Multiline = true;
            this.Lb_Vta1.Name = "Lb_Vta1";
            this.Lb_Vta1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Vta1.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Vta1.StylePriority.UseFont = false;
            this.Lb_Vta1.StylePriority.UsePadding = false;
            this.Lb_Vta1.StylePriority.UseTextAlignment = false;
            this.Lb_Vta1.Text = "Vta";
            this.Lb_Vta1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_Dev1
            // 
            this.Lb_Dev1.CanGrow = false;
            this.Lb_Dev1.Dpi = 100F;
            this.Lb_Dev1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Dev1.LocationFloat = new DevExpress.Utils.PointFloat(230F, 25F);
            this.Lb_Dev1.Multiline = true;
            this.Lb_Dev1.Name = "Lb_Dev1";
            this.Lb_Dev1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Dev1.SizeF = new System.Drawing.SizeF(45F, 20F);
            this.Lb_Dev1.StylePriority.UseFont = false;
            this.Lb_Dev1.StylePriority.UsePadding = false;
            this.Lb_Dev1.StylePriority.UseTextAlignment = false;
            this.Lb_Dev1.Text = "Dev";
            this.Lb_Dev1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Lb_DiferenciaCosto
            // 
            this.Lb_DiferenciaCosto.CanGrow = false;
            this.Lb_DiferenciaCosto.Dpi = 100F;
            this.Lb_DiferenciaCosto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_DiferenciaCosto.LocationFloat = new DevExpress.Utils.PointFloat(950.4167F, 5.000003F);
            this.Lb_DiferenciaCosto.Multiline = true;
            this.Lb_DiferenciaCosto.Name = "Lb_DiferenciaCosto";
            this.Lb_DiferenciaCosto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_DiferenciaCosto.SizeF = new System.Drawing.SizeF(124.5833F, 20F);
            this.Lb_DiferenciaCosto.StylePriority.UseFont = false;
            this.Lb_DiferenciaCosto.StylePriority.UsePadding = false;
            this.Lb_DiferenciaCosto.StylePriority.UseTextAlignment = false;
            this.Lb_DiferenciaCosto.Text = "Lb_DiferenciaCosto";
            this.Lb_DiferenciaCosto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Diferencia
            // 
            this.Lb_Diferencia.CanGrow = false;
            this.Lb_Diferencia.Dpi = 100F;
            this.Lb_Diferencia.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Diferencia.LocationFloat = new DevExpress.Utils.PointFloat(860.0002F, 5.000003F);
            this.Lb_Diferencia.Multiline = true;
            this.Lb_Diferencia.Name = "Lb_Diferencia";
            this.Lb_Diferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Diferencia.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Diferencia.StylePriority.UseFont = false;
            this.Lb_Diferencia.StylePriority.UsePadding = false;
            this.Lb_Diferencia.StylePriority.UseTextAlignment = false;
            this.Lb_Diferencia.Text = "Lb_Diferencia";
            this.Lb_Diferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Totales
            // 
            this.Lb_Totales.CanGrow = false;
            this.Lb_Totales.Dpi = 100F;
            this.Lb_Totales.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Totales.LocationFloat = new DevExpress.Utils.PointFloat(770.0003F, 5.000003F);
            this.Lb_Totales.Multiline = true;
            this.Lb_Totales.Name = "Lb_Totales";
            this.Lb_Totales.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Totales.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Totales.StylePriority.UseFont = false;
            this.Lb_Totales.StylePriority.UsePadding = false;
            this.Lb_Totales.StylePriority.UseTextAlignment = false;
            this.Lb_Totales.Text = "Lb_Totales";
            this.Lb_Totales.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Viernes
            // 
            this.Lb_Viernes.CanGrow = false;
            this.Lb_Viernes.Dpi = 100F;
            this.Lb_Viernes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Viernes.LocationFloat = new DevExpress.Utils.PointFloat(680F, 5F);
            this.Lb_Viernes.Multiline = true;
            this.Lb_Viernes.Name = "Lb_Viernes";
            this.Lb_Viernes.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Viernes.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Viernes.StylePriority.UseFont = false;
            this.Lb_Viernes.StylePriority.UsePadding = false;
            this.Lb_Viernes.StylePriority.UseTextAlignment = false;
            this.Lb_Viernes.Text = "Lb_Viernes";
            this.Lb_Viernes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Jueves
            // 
            this.Lb_Jueves.CanGrow = false;
            this.Lb_Jueves.Dpi = 100F;
            this.Lb_Jueves.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Jueves.LocationFloat = new DevExpress.Utils.PointFloat(590F, 5F);
            this.Lb_Jueves.Multiline = true;
            this.Lb_Jueves.Name = "Lb_Jueves";
            this.Lb_Jueves.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Jueves.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Jueves.StylePriority.UseFont = false;
            this.Lb_Jueves.StylePriority.UsePadding = false;
            this.Lb_Jueves.StylePriority.UseTextAlignment = false;
            this.Lb_Jueves.Text = "Lb_Jueves";
            this.Lb_Jueves.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Miercoles
            // 
            this.Lb_Miercoles.CanGrow = false;
            this.Lb_Miercoles.Dpi = 100F;
            this.Lb_Miercoles.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Miercoles.LocationFloat = new DevExpress.Utils.PointFloat(500F, 5F);
            this.Lb_Miercoles.Multiline = true;
            this.Lb_Miercoles.Name = "Lb_Miercoles";
            this.Lb_Miercoles.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Miercoles.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Miercoles.StylePriority.UseFont = false;
            this.Lb_Miercoles.StylePriority.UsePadding = false;
            this.Lb_Miercoles.StylePriority.UseTextAlignment = false;
            this.Lb_Miercoles.Text = "Lb_Miercoles";
            this.Lb_Miercoles.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Martes
            // 
            this.Lb_Martes.CanGrow = false;
            this.Lb_Martes.Dpi = 100F;
            this.Lb_Martes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Martes.LocationFloat = new DevExpress.Utils.PointFloat(410F, 5F);
            this.Lb_Martes.Multiline = true;
            this.Lb_Martes.Name = "Lb_Martes";
            this.Lb_Martes.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Martes.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Martes.StylePriority.UseFont = false;
            this.Lb_Martes.StylePriority.UsePadding = false;
            this.Lb_Martes.StylePriority.UseTextAlignment = false;
            this.Lb_Martes.Text = "Lb_Martes";
            this.Lb_Martes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Lunes
            // 
            this.Lb_Lunes.CanGrow = false;
            this.Lb_Lunes.Dpi = 100F;
            this.Lb_Lunes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Lunes.LocationFloat = new DevExpress.Utils.PointFloat(320F, 5F);
            this.Lb_Lunes.Multiline = true;
            this.Lb_Lunes.Name = "Lb_Lunes";
            this.Lb_Lunes.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Lunes.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Lunes.StylePriority.UseFont = false;
            this.Lb_Lunes.StylePriority.UsePadding = false;
            this.Lb_Lunes.StylePriority.UseTextAlignment = false;
            this.Lb_Lunes.Text = "Lb_Lunes";
            this.Lb_Lunes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Sabado
            // 
            this.Lb_Sabado.CanGrow = false;
            this.Lb_Sabado.Dpi = 100F;
            this.Lb_Sabado.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Sabado.LocationFloat = new DevExpress.Utils.PointFloat(230F, 5F);
            this.Lb_Sabado.Multiline = true;
            this.Lb_Sabado.Name = "Lb_Sabado";
            this.Lb_Sabado.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Sabado.SizeF = new System.Drawing.SizeF(90F, 20F);
            this.Lb_Sabado.StylePriority.UseFont = false;
            this.Lb_Sabado.StylePriority.UsePadding = false;
            this.Lb_Sabado.StylePriority.UseTextAlignment = false;
            this.Lb_Sabado.Text = "Lb_Sabado";
            this.Lb_Sabado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Lb_Producto
            // 
            this.Lb_Producto.CanGrow = false;
            this.Lb_Producto.Dpi = 100F;
            this.Lb_Producto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Producto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5F);
            this.Lb_Producto.Name = "Lb_Producto";
            this.Lb_Producto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_Producto.SizeF = new System.Drawing.SizeF(230F, 40F);
            this.Lb_Producto.StylePriority.UseFont = false;
            this.Lb_Producto.StylePriority.UsePadding = false;
            this.Lb_Producto.StylePriority.UseTextAlignment = false;
            this.Lb_Producto.Text = "Lb_Producto";
            this.Lb_Producto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(1075F, 2F);
            // 
            // TotalDevolucion
            // 
            this.TotalDevolucion.DataMember = "stpr_R077DevolucionesComision";
            this.TotalDevolucion.DisplayName = "TotalDevolucion";
            this.TotalDevolucion.Expression = "[DevolucionSabado] + [DevolucionLunes] + [DevolucionMartes] + [DevolucionMiercole" +
    "s] + [DevolucionJueves] + [DevolucionViernes]";
            this.TotalDevolucion.Name = "TotalDevolucion";
            // 
            // TotalVenta
            // 
            this.TotalVenta.DataMember = "stpr_R077DevolucionesComision";
            this.TotalVenta.DisplayName = "TotalVenta";
            this.TotalVenta.Expression = "[VentaSabado] + [VentaLunes] + [VentaMartes] + [VentaMiercoles] + [VentaJueves] +" +
    " [VentaViernes]";
            this.TotalVenta.Name = "TotalVenta";
            // 
            // Tope
            // 
            this.Tope.DataMember = "stpr_R077DevolucionesComision";
            this.Tope.DisplayName = "Tope";
            this.Tope.Expression = "Round((([CaducoPermitido] * [TotalVenta]) / 100),0 )";
            this.Tope.Name = "Tope";
            // 
            // Excedente
            // 
            this.Excedente.DataMember = "stpr_R077DevolucionesComision";
            this.Excedente.DisplayName = "Excedente";
            this.Excedente.Expression = "Iif(([TotalDevolucion] - [Tope]) < 0, 0 , ([TotalDevolucion] - [Tope]))";
            this.Excedente.Name = "Excedente";
            // 
            // TotalAPagar
            // 
            this.TotalAPagar.DataMember = "stpr_R077DevolucionesComision";
            this.TotalAPagar.DisplayName = "TotalAPagar";
            this.TotalAPagar.Expression = "Round([Excedente] * [PrecioUnitario], 2)";
            this.TotalAPagar.Name = "TotalAPagar";
            // 
            // VentaxPU
            // 
            this.VentaxPU.DataMember = "stpr_R077DevolucionesComision";
            this.VentaxPU.DisplayName = "VentaxPU";
            this.VentaxPU.Expression = "[TotalVenta] * [PrecioUnitario]";
            this.VentaxPU.Name = "VentaxPU";
            // 
            // ComisionParcial
            // 
            this.ComisionParcial.DataMember = "stpr_R077DevolucionesComision";
            this.ComisionParcial.DisplayName = "ComisionParcial";
            this.ComisionParcial.Expression = "[VentaxPU] * 4 / 100";
            this.ComisionParcial.Name = "ComisionParcial";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.ComisionParcial")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(951.6664F, 23.00002F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(123.3334F, 13F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel5.Summary = xrSummary2;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ComisionFinal
            // 
            this.ComisionFinal.DataMember = "stpr_R077DevolucionesComision";
            this.ComisionFinal.DisplayName = "ComisionFinal";
            this.ComisionFinal.Expression = "[VentaxPU] * 4 / 100 - [TotalAPagar]";
            this.ComisionFinal.Name = "ComisionFinal";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_R077DevolucionesComision.ComisionFinal")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(951.2498F, 49.00001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(123.7499F, 13F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel6.Summary = xrSummary1;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // Lb_FechaImpresion
            // 
            this.Lb_FechaImpresion.Dpi = 100F;
            this.Lb_FechaImpresion.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_FechaImpresion.LocationFloat = new DevExpress.Utils.PointFloat(786.27F, 5F);
            this.Lb_FechaImpresion.Name = "Lb_FechaImpresion";
            this.Lb_FechaImpresion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Lb_FechaImpresion.SizeF = new System.Drawing.SizeF(150F, 14F);
            this.Lb_FechaImpresion.StylePriority.UseFont = false;
            this.Lb_FechaImpresion.StylePriority.UsePadding = false;
            this.Lb_FechaImpresion.StylePriority.UseTextAlignment = false;
            this.Lb_FechaImpresion.Text = "Fecha Hora Impresión";
            this.Lb_FechaImpresion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // Lb_TotalVenta
            // 
            this.Lb_TotalVenta.CanGrow = false;
            this.Lb_TotalVenta.Dpi = 100F;
            this.Lb_TotalVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TotalVenta.LocationFloat = new DevExpress.Utils.PointFloat(736.27F, 10.00001F);
            this.Lb_TotalVenta.Name = "Lb_TotalVenta";
            this.Lb_TotalVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TotalVenta.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TotalVenta.StylePriority.UseFont = false;
            this.Lb_TotalVenta.StylePriority.UsePadding = false;
            this.Lb_TotalVenta.StylePriority.UseTextAlignment = false;
            this.Lb_TotalVenta.Text = "Lb_TotalVenta";
            this.Lb_TotalVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Lb_ComisionParcial
            // 
            this.Lb_ComisionParcial.CanGrow = false;
            this.Lb_ComisionParcial.Dpi = 100F;
            this.Lb_ComisionParcial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_ComisionParcial.LocationFloat = new DevExpress.Utils.PointFloat(736.27F, 23.00002F);
            this.Lb_ComisionParcial.Name = "Lb_ComisionParcial";
            this.Lb_ComisionParcial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_ComisionParcial.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_ComisionParcial.StylePriority.UseFont = false;
            this.Lb_ComisionParcial.StylePriority.UsePadding = false;
            this.Lb_ComisionParcial.StylePriority.UseTextAlignment = false;
            this.Lb_ComisionParcial.Text = "Lb_ComisionParcial";
            this.Lb_ComisionParcial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Lb_ComisionFinal
            // 
            this.Lb_ComisionFinal.CanGrow = false;
            this.Lb_ComisionFinal.Dpi = 100F;
            this.Lb_ComisionFinal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_ComisionFinal.LocationFloat = new DevExpress.Utils.PointFloat(736.27F, 49.00001F);
            this.Lb_ComisionFinal.Name = "Lb_ComisionFinal";
            this.Lb_ComisionFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_ComisionFinal.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_ComisionFinal.StylePriority.UseFont = false;
            this.Lb_ComisionFinal.StylePriority.UsePadding = false;
            this.Lb_ComisionFinal.StylePriority.UseTextAlignment = false;
            this.Lb_ComisionFinal.Text = "Lb_ComisionFinal";
            this.Lb_ComisionFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Lb_TotalDevolucion
            // 
            this.Lb_TotalDevolucion.CanGrow = false;
            this.Lb_TotalDevolucion.Dpi = 100F;
            this.Lb_TotalDevolucion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TotalDevolucion.LocationFloat = new DevExpress.Utils.PointFloat(736.27F, 36F);
            this.Lb_TotalDevolucion.Name = "Lb_TotalDevolucion";
            this.Lb_TotalDevolucion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Lb_TotalDevolucion.SizeF = new System.Drawing.SizeF(200F, 13F);
            this.Lb_TotalDevolucion.StylePriority.UseFont = false;
            this.Lb_TotalDevolucion.StylePriority.UsePadding = false;
            this.Lb_TotalDevolucion.StylePriority.UseTextAlignment = false;
            this.Lb_TotalDevolucion.Text = "Lb_TotalDevolucion";
            this.Lb_TotalDevolucion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // parameterCedi
            // 
            this.parameterCedi.Description = "parameterCedi";
            this.parameterCedi.Name = "parameterCedi";
            this.parameterCedi.Visible = false;
            // 
            // parameterSeller
            // 
            this.parameterSeller.Description = "parameterSeller";
            this.parameterSeller.Name = "parameterSeller";
            this.parameterSeller.Visible = false;
            // 
            // parameterDateIni
            // 
            this.parameterDateIni.Description = "parameterDateIni";
            this.parameterDateIni.Name = "parameterDateIni";
            this.parameterDateIni.Visible = false;
            // 
            // R077_Report_Design
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.groupHeaderBand3,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.groupFooterBand2,
            this.groupFooterBand3,
            this.reportFooterBand1,
            this.PageHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.TotalDevolucion,
            this.TotalVenta,
            this.Tope,
            this.Excedente,
            this.TotalAPagar,
            this.VentaxPU,
            this.ComisionParcial,
            this.ComisionFinal});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_R077DevolucionesComision";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedi,
            this.parameterSeller,
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
