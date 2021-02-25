using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

/// <summary>
/// Summary description for ClientesSinVenta
/// </summary>
public class ClientesSinVenta : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private PageFooterBand pageFooterBand1;
    private ReportHeaderBand reportHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    public XRLabel XRutas;
    public XRLabel L_Ruta;
    public XRLabel XFecha;
    public XRLabel L_FechaRango;
    private PageHeaderBand PageHeader;
    private XRLine xrLine1;
    public XRLabel XRuta;
    public XRLabel XCliente;
    public XRLabel XInterior;
    public XRLabel XExterior;
    public XRLabel XNombreCorto;
    public XRLabel XImcumplimiento;
    public XRLabel XDiaTrabajo;
    public XRLabel XClaveCliente;
    public XRLabel XCalle;
    private XRLine xrLine2;
    private XRPageInfo xrPageInfo2;
    public XRLabel XFechaHoraImpresion;
    private XRPageInfo xrPageInfo1;
    private ReportFooterBand ReportFooter;
    public XRLabel XClienteVisitadoSinVenta;
    public XRLabel XClienteNoVisitado;
    private DevExpress.XtraReports.Parameters.Parameter filtroRutas;
    private DevExpress.XtraReports.Parameters.Parameter filtroFechaInicio;
    private DevExpress.XtraReports.Parameters.Parameter filtroFechaFin;
    public SqlDataSource sqlDataSource2;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private CalculatedField clientesNoVisitados;
    private CalculatedField ClienteSinVenta;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ClientesSinVenta()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public ClientesSinVenta(string cons)
    {
        //InitializeComponent();
        ////DataSourceDemanded += ClientesSinVenta_DataSourceDemanded(null, null, cons);
        //sqlDataSource1.Queries.RemoveAt(0);
        //CustomSqlQuery query = new CustomSqlQuery("Query", cons);
        //sqlDataSource1.Queries.Add(query);
        //sqlDataSource1.RebuildResultSchema();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesSinVenta));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XFechaHoraImpresion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.XRutas = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.XFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.XRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.XCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.XInterior = new DevExpress.XtraReports.UI.XRLabel();
            this.XExterior = new DevExpress.XtraReports.UI.XRLabel();
            this.XNombreCorto = new DevExpress.XtraReports.UI.XRLabel();
            this.XDiaTrabajo = new DevExpress.XtraReports.UI.XRLabel();
            this.XClaveCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.XCalle = new DevExpress.XtraReports.UI.XRLabel();
            this.XImcumplimiento = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.XClienteVisitadoSinVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.XClienteNoVisitado = new DevExpress.XtraReports.UI.XRLabel();
            this.filtroRutas = new DevExpress.XtraReports.Parameters.Parameter();
            this.filtroFechaInicio = new DevExpress.XtraReports.Parameters.Parameter();
            this.filtroFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource2 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.clientesNoVisitados = new DevExpress.XtraReports.UI.CalculatedField();
            this.ClienteSinVenta = new DevExpress.XtraReports.UI.CalculatedField();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel17});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 12F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("FechaCaptura", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.StyleName = "DataField";
            this.Detail.StylePriority.UsePadding = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.Calle")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(673.4565F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(144.8011F, 11.93243F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.Clave")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(205.9603F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(97.49619F, 11.93243F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UsePadding = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.FechaCaptura")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(74F, 11.93243F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.Improductividad")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(913.3705F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(113.677F, 11.93243F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.CanGrow = false;
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.NombreCorto")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(488.2577F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(185.1989F, 11.93243F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UsePadding = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.NumInt")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(867.1715F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(46.19897F, 11.93243F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UsePadding = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.CanGrow = false;
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.RazonSocial")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(303.4565F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(184.8011F, 11.93243F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UsePadding = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.Ruta")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(74.00001F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(131.9603F, 11.93243F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UsePadding = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.Numero")});
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(818.2578F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(48.19885F, 11.93243F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UsePadding = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 25F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 25F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AgrupadorEncabezado", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 36.77686F;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.AgrupadorEncabezado")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(6.000001F, 17.69423F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(241.4619F, 14.08263F);
            this.xrLabel2.StyleName = "DataField";
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.XFechaHoraImpresion,
            this.xrPageInfo1});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.Expanded = false;
            this.pageFooterBand1.HeightF = 13F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "{0} / {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(160.6593F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(312.9999F, 12.58333F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UsePadding = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XFechaHoraImpresion
            // 
            this.XFechaHoraImpresion.Dpi = 100F;
            this.XFechaHoraImpresion.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XFechaHoraImpresion.LocationFloat = new DevExpress.Utils.PointFloat(756.1892F, 0F);
            this.XFechaHoraImpresion.Name = "XFechaHoraImpresion";
            this.XFechaHoraImpresion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XFechaHoraImpresion.SizeF = new System.Drawing.SizeF(149.9999F, 12.58333F);
            this.XFechaHoraImpresion.StylePriority.UseFont = false;
            this.XFechaHoraImpresion.StylePriority.UsePadding = false;
            this.XFechaHoraImpresion.StylePriority.UseTextAlignment = false;
            this.XFechaHoraImpresion.Text = "XFechaHoraImpresion";
            this.XFechaHoraImpresion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "{0:dd/MM/yyyy hh:mm tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(906.189F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(123.8109F, 12.58333F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.XRutas,
            this.L_Ruta,
            this.XFecha,
            this.L_FechaRango});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 150.9435F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // XRutas
            // 
            this.XRutas.Dpi = 100F;
            this.XRutas.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XRutas.LocationFloat = new DevExpress.Utils.PointFloat(125.8937F, 137.9435F);
            this.XRutas.Name = "XRutas";
            this.XRutas.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XRutas.SizeF = new System.Drawing.SizeF(63.04087F, 13F);
            this.XRutas.StylePriority.UseFont = false;
            this.XRutas.StylePriority.UsePadding = false;
            this.XRutas.StylePriority.UseTextAlignment = false;
            this.XRutas.Text = "XRuta(s)";
            this.XRutas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Ruta
            // 
            this.L_Ruta.CanGrow = false;
            this.L_Ruta.Dpi = 100F;
            this.L_Ruta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Ruta.LocationFloat = new DevExpress.Utils.PointFloat(189.0909F, 137.9435F);
            this.L_Ruta.Name = "L_Ruta";
            this.L_Ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_Ruta.SizeF = new System.Drawing.SizeF(835.5955F, 13F);
            this.L_Ruta.StylePriority.UseFont = false;
            this.L_Ruta.StylePriority.UsePadding = false;
            this.L_Ruta.StylePriority.UseTextAlignment = false;
            this.L_Ruta.Text = "Ruta(s)";
            this.L_Ruta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XFecha
            // 
            this.XFecha.Dpi = 100F;
            this.XFecha.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XFecha.LocationFloat = new DevExpress.Utils.PointFloat(125.8937F, 124.9435F);
            this.XFecha.Name = "XFecha";
            this.XFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XFecha.SizeF = new System.Drawing.SizeF(63.04087F, 13F);
            this.XFecha.StylePriority.UseFont = false;
            this.XFecha.StylePriority.UsePadding = false;
            this.XFecha.StylePriority.UseTextAlignment = false;
            this.XFecha.Text = "XFecha";
            this.XFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(188.9346F, 124.9435F);
            this.L_FechaRango.Name = "L_FechaRango";
            this.L_FechaRango.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_FechaRango.SizeF = new System.Drawing.SizeF(299.5219F, 12.99999F);
            this.L_FechaRango.StylePriority.UseFont = false;
            this.L_FechaRango.StylePriority.UsePadding = false;
            this.L_FechaRango.StylePriority.UseTextAlignment = false;
            this.L_FechaRango.Text = "Rango de Fechas";
            this.L_FechaRango.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.xrLine2,
            this.xrLine1,
            this.XRuta,
            this.XCliente,
            this.XInterior,
            this.XExterior,
            this.XNombreCorto,
            this.XDiaTrabajo,
            this.XClaveCliente,
            this.XCalle,
            this.XImcumplimiento});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 18.62162F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 16.62162F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1020.372F, 2F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1020.372F, 2F);
            // 
            // XRuta
            // 
            this.XRuta.CanGrow = false;
            this.XRuta.Dpi = 100F;
            this.XRuta.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XRuta.LocationFloat = new DevExpress.Utils.PointFloat(74.00001F, 1.999985F);
            this.XRuta.Name = "XRuta";
            this.XRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XRuta.SizeF = new System.Drawing.SizeF(132.1592F, 14.62162F);
            this.XRuta.StylePriority.UseFont = false;
            this.XRuta.StylePriority.UsePadding = false;
            this.XRuta.StylePriority.UseTextAlignment = false;
            this.XRuta.Text = "XRuta";
            this.XRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XCliente
            // 
            this.XCliente.CanGrow = false;
            this.XCliente.Dpi = 100F;
            this.XCliente.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XCliente.LocationFloat = new DevExpress.Utils.PointFloat(303.4565F, 1.999985F);
            this.XCliente.Name = "XCliente";
            this.XCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XCliente.SizeF = new System.Drawing.SizeF(185F, 14.62F);
            this.XCliente.StylePriority.UseFont = false;
            this.XCliente.StylePriority.UsePadding = false;
            this.XCliente.StylePriority.UseTextAlignment = false;
            this.XCliente.Text = "XCliente";
            this.XCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XInterior
            // 
            this.XInterior.CanGrow = false;
            this.XInterior.Dpi = 100F;
            this.XInterior.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XInterior.LocationFloat = new DevExpress.Utils.PointFloat(867.3704F, 2.001632F);
            this.XInterior.Name = "XInterior";
            this.XInterior.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XInterior.SizeF = new System.Drawing.SizeF(46F, 14.62F);
            this.XInterior.StylePriority.UseFont = false;
            this.XInterior.StylePriority.UsePadding = false;
            this.XInterior.StylePriority.UseTextAlignment = false;
            this.XInterior.Text = "XInterior";
            this.XInterior.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XExterior
            // 
            this.XExterior.CanGrow = false;
            this.XExterior.Dpi = 100F;
            this.XExterior.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XExterior.LocationFloat = new DevExpress.Utils.PointFloat(818.4566F, 1.999985F);
            this.XExterior.Name = "XExterior";
            this.XExterior.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XExterior.SizeF = new System.Drawing.SizeF(48F, 14.62F);
            this.XExterior.StylePriority.UseFont = false;
            this.XExterior.StylePriority.UsePadding = false;
            this.XExterior.StylePriority.UseTextAlignment = false;
            this.XExterior.Text = "XExterior";
            this.XExterior.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XNombreCorto
            // 
            this.XNombreCorto.CanGrow = false;
            this.XNombreCorto.Dpi = 100F;
            this.XNombreCorto.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XNombreCorto.LocationFloat = new DevExpress.Utils.PointFloat(488.4565F, 2.001632F);
            this.XNombreCorto.Name = "XNombreCorto";
            this.XNombreCorto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XNombreCorto.SizeF = new System.Drawing.SizeF(185F, 14.62F);
            this.XNombreCorto.StylePriority.UseFont = false;
            this.XNombreCorto.StylePriority.UsePadding = false;
            this.XNombreCorto.StylePriority.UseTextAlignment = false;
            this.XNombreCorto.Text = "XNombreCorto";
            this.XNombreCorto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XDiaTrabajo
            // 
            this.XDiaTrabajo.CanGrow = false;
            this.XDiaTrabajo.Dpi = 100F;
            this.XDiaTrabajo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XDiaTrabajo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2.000007F);
            this.XDiaTrabajo.Name = "XDiaTrabajo";
            this.XDiaTrabajo.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XDiaTrabajo.SizeF = new System.Drawing.SizeF(74F, 14.62F);
            this.XDiaTrabajo.StylePriority.UseFont = false;
            this.XDiaTrabajo.StylePriority.UsePadding = false;
            this.XDiaTrabajo.StylePriority.UseTextAlignment = false;
            this.XDiaTrabajo.Text = "XDiaTrabajo";
            this.XDiaTrabajo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XClaveCliente
            // 
            this.XClaveCliente.CanGrow = false;
            this.XClaveCliente.Dpi = 100F;
            this.XClaveCliente.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XClaveCliente.LocationFloat = new DevExpress.Utils.PointFloat(206.1591F, 1.999985F);
            this.XClaveCliente.Name = "XClaveCliente";
            this.XClaveCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XClaveCliente.SizeF = new System.Drawing.SizeF(97.2973F, 14.62163F);
            this.XClaveCliente.StylePriority.UseFont = false;
            this.XClaveCliente.StylePriority.UsePadding = false;
            this.XClaveCliente.StylePriority.UseTextAlignment = false;
            this.XClaveCliente.Text = "XClaveCliente";
            this.XClaveCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XCalle
            // 
            this.XCalle.CanGrow = false;
            this.XCalle.Dpi = 100F;
            this.XCalle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XCalle.LocationFloat = new DevExpress.Utils.PointFloat(673.4565F, 1.999985F);
            this.XCalle.Name = "XCalle";
            this.XCalle.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XCalle.SizeF = new System.Drawing.SizeF(145F, 14.62F);
            this.XCalle.StylePriority.UseFont = false;
            this.XCalle.StylePriority.UsePadding = false;
            this.XCalle.StylePriority.UseTextAlignment = false;
            this.XCalle.Text = "XCalle";
            this.XCalle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XImcumplimiento
            // 
            this.XImcumplimiento.CanGrow = false;
            this.XImcumplimiento.Dpi = 100F;
            this.XImcumplimiento.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XImcumplimiento.LocationFloat = new DevExpress.Utils.PointFloat(913.3705F, 1.999985F);
            this.XImcumplimiento.Name = "XImcumplimiento";
            this.XImcumplimiento.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XImcumplimiento.SizeF = new System.Drawing.SizeF(113.677F, 14.62F);
            this.XImcumplimiento.StylePriority.UseFont = false;
            this.XImcumplimiento.StylePriority.UsePadding = false;
            this.XImcumplimiento.StylePriority.UseTextAlignment = false;
            this.XImcumplimiento.Text = "XImcumplimiento";
            this.XImcumplimiento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.xrLabel26,
            this.XClienteVisitadoSinVenta,
            this.XClienteNoVisitado});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 52.72522F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.clientesNoVisitados", "{0:#,#}")});
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(360.6939F, 28.10523F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(112.77F, 14.62F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UsePadding = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "xrLabel27";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteClienteSinVenta.ClienteSinVenta")});
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(772.279F, 28.10523F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(112.77F, 14.62F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UsePadding = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "xrLabel26";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XClienteVisitadoSinVenta
            // 
            this.XClienteVisitadoSinVenta.Dpi = 100F;
            this.XClienteVisitadoSinVenta.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XClienteVisitadoSinVenta.LocationFloat = new DevExpress.Utils.PointFloat(579.3173F, 28.10361F);
            this.XClienteVisitadoSinVenta.Multiline = true;
            this.XClienteVisitadoSinVenta.Name = "XClienteVisitadoSinVenta";
            this.XClienteVisitadoSinVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XClienteVisitadoSinVenta.SizeF = new System.Drawing.SizeF(192.9618F, 14.62162F);
            this.XClienteVisitadoSinVenta.StylePriority.UseFont = false;
            this.XClienteVisitadoSinVenta.StylePriority.UsePadding = false;
            this.XClienteVisitadoSinVenta.StylePriority.UseTextAlignment = false;
            this.XClienteVisitadoSinVenta.Text = "XClienteVisitadoSinVenta";
            this.XClienteVisitadoSinVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // XClienteNoVisitado
            // 
            this.XClienteNoVisitado.Dpi = 100F;
            this.XClienteNoVisitado.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XClienteNoVisitado.LocationFloat = new DevExpress.Utils.PointFloat(205.9603F, 28.10361F);
            this.XClienteNoVisitado.Name = "XClienteNoVisitado";
            this.XClienteNoVisitado.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XClienteNoVisitado.SizeF = new System.Drawing.SizeF(154.7335F, 14.62162F);
            this.XClienteNoVisitado.StylePriority.UseFont = false;
            this.XClienteNoVisitado.StylePriority.UsePadding = false;
            this.XClienteNoVisitado.StylePriority.UseTextAlignment = false;
            this.XClienteNoVisitado.Text = "XClienteNoVisitado";
            this.XClienteNoVisitado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // filtroRutas
            // 
            this.filtroRutas.Description = "RoutesFilter";
            this.filtroRutas.Name = "filtroRutas";
            this.filtroRutas.Visible = false;
            // 
            // filtroFechaInicio
            // 
            this.filtroFechaInicio.Description = "InitialDate";
            this.filtroFechaInicio.Name = "filtroFechaInicio";
            this.filtroFechaInicio.Visible = false;
            // 
            // filtroFechaFin
            // 
            this.filtroFechaFin.Description = "FinalDate";
            this.filtroFechaFin.Name = "filtroFechaFin";
            this.filtroFechaFin.Visible = false;
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionName = "eRouteConnection";
            this.sqlDataSource2.Name = "sqlDataSource2";
            storedProcQuery1.Name = "stpr_ReporteClienteSinVenta";
            queryParameter1.Name = "@filtroRutas";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.filtroRutas]", typeof(string));
            queryParameter2.Name = "@filtroFechaInicio";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.filtroFechaInicio]", typeof(string));
            queryParameter3.Name = "@filtroFechaFin";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.filtroFechaFin]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.StoredProcName = "stpr_ReporteClienteSinVenta";
            this.sqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource2.ResultSchemaSerializable = resources.GetString("sqlDataSource2.ResultSchemaSerializable");
            // 
            // clientesNoVisitados
            // 
            this.clientesNoVisitados.DataMember = "stpr_ReporteClienteSinVenta";
            this.clientesNoVisitados.DisplayName = "clientesNoVisitados";
            this.clientesNoVisitados.Expression = "[][[AgrupadorEncabezado] == \'Clientes No Visitados\'].Count()";
            this.clientesNoVisitados.Name = "clientesNoVisitados";
            // 
            // ClienteSinVenta
            // 
            this.ClienteSinVenta.DataMember = "stpr_ReporteClienteSinVenta";
            this.ClienteSinVenta.DisplayName = "ClienteSinVenta";
            this.ClienteSinVenta.Expression = "[][[AgrupadorEncabezado] == \'Clientes Visitados Sin Venta\'].Count()";
            this.ClienteSinVenta.Name = "ClienteSinVenta";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(149.9567F, 4.999987F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(326.4567F, 69.99998F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(326.4567F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ClientesSinVenta
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.PageHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.clientesNoVisitados,
            this.ClienteSinVenta});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource2});
            this.DataMember = "stpr_ReporteClienteSinVenta";
            this.DataSource = this.sqlDataSource2;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(35, 35, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.filtroRutas,
            this.filtroFechaInicio,
            this.filtroFechaFin});
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
