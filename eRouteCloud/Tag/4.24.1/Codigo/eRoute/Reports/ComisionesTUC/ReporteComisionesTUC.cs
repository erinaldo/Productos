using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

/// <summary>
/// Summary description for ComisionesTUC
/// </summary>
public class ReporteComisionesTUC : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand GroupHeader1;
    public XRLabel lbProdPromocion;
    public XRLabel lbTotalComision;
    public XRLabel lbComision;
    public XRLabel lbTotal;
    public XRLabel lbDevolucion;
    public XRLabel lbCantidad;
    public XRLabel lbUnidad;
    public XRLabel lbProducto;
    public XRLabel lbClave;
    public XRLabel lbFechaGr;
    public XRLabel lbVendedorGr;
    private GroupFooterBand GroupFooter1;
    private XRLabel xrLabel12;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    public XRLabel lbTotales;
    private CalculatedField calculatedField1;
    private CalculatedField TotalComision;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    public XRSubreport rptEsquemas;
    public XRLabel lbCEDI;
    public XRLabel lbFecha;
    public XRLabel lbVendedor;
    private ReportHeaderBand ReportHeader;
    public XRLabel lbFechaFiltroGr;
    public XRLabel lbCEDIFiltro;
    public XRLabel lbFechaFiltro;
    public XRLabel lbVendedorFiltro;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;
    private XRLabel xrLabel1;
    private CalculatedField Comision;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteComisionesTUC()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public ReporteComisionesTUC(string sComisiones, string sEsquemas)
    {
        InitializeComponent();
        //DataSourceDemanded += ClientesSinVenta_DataSourceDemanded(null, null, cons);
        sqlDataSource1.Queries.RemoveAt(0);
        CustomSqlQuery query = new CustomSqlQuery("Query", sComisiones);
        sqlDataSource1.Queries.Add(query);
        sqlDataSource1.RebuildResultSchema();

        ((ReporteEsquemasComisionesTUC)rptEsquemas.ReportSource).SetDataSource(sEsquemas);
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteComisionesTUC));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.lbFechaFiltroGr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbProdPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalComision = new DevExpress.XtraReports.UI.XRLabel();
            this.lbComision = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDevolucion = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.lbUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.lbProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClave = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFechaGr = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVendedorGr = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotales = new DevExpress.XtraReports.UI.XRLabel();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.TotalComision = new DevExpress.XtraReports.UI.CalculatedField();
            this.lbCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCEDIFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFechaFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVendedorFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.Comision = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.rptEsquemas = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalComision")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calculatedField1")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(512.5F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(62.16663F, 13F);
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "xrLabel20";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CantidadPromocion")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(88F, 13F);
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "xrLabel19";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CantidadDevolucion")});
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(462.5F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(49.83011F, 13F);
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CantidadVenta")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(375F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(87.5F, 13F);
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TipoUnidad")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(300F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(75F, 13F);
            this.xrLabel15.Text = "xrLabel15";
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ProductoNombre")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(249.8265F, 13F);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ProductoClave")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(50F, 13F);
            this.xrLabel13.Text = "xrLabel13";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 49F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 40F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbFechaFiltroGr,
            this.xrLabel12,
            this.lbProdPromocion,
            this.lbTotalComision,
            this.lbComision,
            this.lbTotal,
            this.lbDevolucion,
            this.lbCantidad,
            this.lbUnidad,
            this.lbProducto,
            this.lbClave,
            this.lbFechaGr,
            this.lbVendedorGr});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("VendedorID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 95F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // lbFechaFiltroGr
            // 
            this.lbFechaFiltroGr.Dpi = 100F;
            this.lbFechaFiltroGr.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbFechaFiltroGr.LocationFloat = new DevExpress.Utils.PointFloat(87.5F, 25.5F);
            this.lbFechaFiltroGr.Name = "lbFechaFiltroGr";
            this.lbFechaFiltroGr.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbFechaFiltroGr.SizeF = new System.Drawing.SizeF(750.5F, 13F);
            this.lbFechaFiltroGr.StylePriority.UseFont = false;
            this.lbFechaFiltroGr.StylePriority.UsePadding = false;
            this.lbFechaFiltroGr.StylePriority.UseTextAlignment = false;
            this.lbFechaFiltroGr.Text = "Fecha";
            this.lbFechaFiltroGr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VendedorNombre")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(87.5F, 12.5F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(750.5F, 13F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "xrLabel12";
            // 
            // lbProdPromocion
            // 
            this.lbProdPromocion.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbProdPromocion.Dpi = 100F;
            this.lbProdPromocion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbProdPromocion.LocationFloat = new DevExpress.Utils.PointFloat(750F, 38.5F);
            this.lbProdPromocion.Name = "lbProdPromocion";
            this.lbProdPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbProdPromocion.SizeF = new System.Drawing.SizeF(88F, 56.5F);
            this.lbProdPromocion.StylePriority.UseBorders = false;
            this.lbProdPromocion.StylePriority.UseFont = false;
            this.lbProdPromocion.StylePriority.UsePadding = false;
            this.lbProdPromocion.StylePriority.UseTextAlignment = false;
            this.lbProdPromocion.Text = "PRODUCTO PROMOCIÓN";
            this.lbProdPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbTotalComision
            // 
            this.lbTotalComision.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbTotalComision.Dpi = 100F;
            this.lbTotalComision.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalComision.LocationFloat = new DevExpress.Utils.PointFloat(650F, 38.5F);
            this.lbTotalComision.Multiline = true;
            this.lbTotalComision.Name = "lbTotalComision";
            this.lbTotalComision.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbTotalComision.SizeF = new System.Drawing.SizeF(100F, 56.5F);
            this.lbTotalComision.StylePriority.UseBorders = false;
            this.lbTotalComision.StylePriority.UseFont = false;
            this.lbTotalComision.StylePriority.UsePadding = false;
            this.lbTotalComision.StylePriority.UseTextAlignment = false;
            this.lbTotalComision.Text = "TOTAL DE COMISIÓN POR PRODUCTO";
            this.lbTotalComision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbComision
            // 
            this.lbComision.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbComision.Dpi = 100F;
            this.lbComision.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbComision.LocationFloat = new DevExpress.Utils.PointFloat(574.6666F, 38.5F);
            this.lbComision.Name = "lbComision";
            this.lbComision.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbComision.SizeF = new System.Drawing.SizeF(75.33337F, 56.5F);
            this.lbComision.StylePriority.UseBorders = false;
            this.lbComision.StylePriority.UseFont = false;
            this.lbComision.StylePriority.UsePadding = false;
            this.lbComision.StylePriority.UseTextAlignment = false;
            this.lbComision.Text = "COMISIÓN POR PRODUCTO";
            this.lbComision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbTotal
            // 
            this.lbTotal.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbTotal.Dpi = 100F;
            this.lbTotal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotal.LocationFloat = new DevExpress.Utils.PointFloat(512.5F, 38.5F);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbTotal.SizeF = new System.Drawing.SizeF(62.16663F, 56.5F);
            this.lbTotal.StylePriority.UseBorders = false;
            this.lbTotal.StylePriority.UseFont = false;
            this.lbTotal.StylePriority.UsePadding = false;
            this.lbTotal.StylePriority.UseTextAlignment = false;
            this.lbTotal.Text = "TOTAL";
            this.lbTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbDevolucion
            // 
            this.lbDevolucion.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbDevolucion.Dpi = 100F;
            this.lbDevolucion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbDevolucion.LocationFloat = new DevExpress.Utils.PointFloat(462.5F, 38.5F);
            this.lbDevolucion.Name = "lbDevolucion";
            this.lbDevolucion.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbDevolucion.SizeF = new System.Drawing.SizeF(49.83011F, 56.5F);
            this.lbDevolucion.StylePriority.UseBorders = false;
            this.lbDevolucion.StylePriority.UseFont = false;
            this.lbDevolucion.StylePriority.UsePadding = false;
            this.lbDevolucion.StylePriority.UseTextAlignment = false;
            this.lbDevolucion.Text = "DEV";
            this.lbDevolucion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbCantidad
            // 
            this.lbCantidad.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbCantidad.Dpi = 100F;
            this.lbCantidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbCantidad.LocationFloat = new DevExpress.Utils.PointFloat(375F, 38.5F);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbCantidad.SizeF = new System.Drawing.SizeF(87.5F, 56.5F);
            this.lbCantidad.StylePriority.UseBorders = false;
            this.lbCantidad.StylePriority.UseFont = false;
            this.lbCantidad.StylePriority.UsePadding = false;
            this.lbCantidad.StylePriority.UseTextAlignment = false;
            this.lbCantidad.Text = "CANTIDAD";
            this.lbCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbUnidad
            // 
            this.lbUnidad.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbUnidad.Dpi = 100F;
            this.lbUnidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbUnidad.LocationFloat = new DevExpress.Utils.PointFloat(300F, 38.5F);
            this.lbUnidad.Name = "lbUnidad";
            this.lbUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbUnidad.SizeF = new System.Drawing.SizeF(75F, 56.5F);
            this.lbUnidad.StylePriority.UseBorders = false;
            this.lbUnidad.StylePriority.UseFont = false;
            this.lbUnidad.StylePriority.UsePadding = false;
            this.lbUnidad.StylePriority.UseTextAlignment = false;
            this.lbUnidad.Text = "UNIDAD";
            this.lbUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbProducto
            // 
            this.lbProducto.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbProducto.Dpi = 100F;
            this.lbProducto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbProducto.LocationFloat = new DevExpress.Utils.PointFloat(50F, 38.5F);
            this.lbProducto.Name = "lbProducto";
            this.lbProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbProducto.SizeF = new System.Drawing.SizeF(249.8265F, 56.5F);
            this.lbProducto.StylePriority.UseBorders = false;
            this.lbProducto.StylePriority.UseFont = false;
            this.lbProducto.StylePriority.UsePadding = false;
            this.lbProducto.StylePriority.UseTextAlignment = false;
            this.lbProducto.Text = "PRODUCTO";
            this.lbProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbClave
            // 
            this.lbClave.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbClave.Dpi = 100F;
            this.lbClave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbClave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.5F);
            this.lbClave.Name = "lbClave";
            this.lbClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbClave.SizeF = new System.Drawing.SizeF(50F, 56.5F);
            this.lbClave.StylePriority.UseBorders = false;
            this.lbClave.StylePriority.UseFont = false;
            this.lbClave.StylePriority.UsePadding = false;
            this.lbClave.StylePriority.UseTextAlignment = false;
            this.lbClave.Text = "CLAVE";
            this.lbClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbFechaGr
            // 
            this.lbFechaGr.Dpi = 100F;
            this.lbFechaGr.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbFechaGr.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.5F);
            this.lbFechaGr.Name = "lbFechaGr";
            this.lbFechaGr.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbFechaGr.SizeF = new System.Drawing.SizeF(87.5F, 13F);
            this.lbFechaGr.StylePriority.UseFont = false;
            this.lbFechaGr.StylePriority.UsePadding = false;
            this.lbFechaGr.StylePriority.UseTextAlignment = false;
            this.lbFechaGr.Text = "Fecha";
            this.lbFechaGr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbVendedorGr
            // 
            this.lbVendedorGr.Dpi = 100F;
            this.lbVendedorGr.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbVendedorGr.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.5F);
            this.lbVendedorGr.Name = "lbVendedorGr";
            this.lbVendedorGr.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbVendedorGr.SizeF = new System.Drawing.SizeF(87.5F, 13F);
            this.lbVendedorGr.StylePriority.UseFont = false;
            this.lbVendedorGr.StylePriority.UsePadding = false;
            this.lbVendedorGr.StylePriority.UseTextAlignment = false;
            this.lbVendedorGr.Text = "Vendedor";
            this.lbVendedorGr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.rptEsquemas,
            this.xrLabel24,
            this.xrLabel23,
            this.lbTotales});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 60F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalComision")});
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel24.Summary = xrSummary1;
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calculatedField1")});
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(512.5F, 0F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(62.16663F, 13F);
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel23.Summary = xrSummary2;
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbTotales
            // 
            this.lbTotales.Dpi = 100F;
            this.lbTotales.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lbTotales.LocationFloat = new DevExpress.Utils.PointFloat(375F, 0F);
            this.lbTotales.Name = "lbTotales";
            this.lbTotales.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbTotales.SizeF = new System.Drawing.SizeF(87.5F, 13F);
            this.lbTotales.StylePriority.UseFont = false;
            this.lbTotales.StylePriority.UsePadding = false;
            this.lbTotales.StylePriority.UseTextAlignment = false;
            this.lbTotales.Text = "Totales";
            this.lbTotales.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "Query";
            this.calculatedField1.DisplayName = "Total";
            this.calculatedField1.Expression = "[TotalVenta] - [TotalDevolucion]";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // TotalComision
            // 
            this.TotalComision.DataMember = "Query";
            this.TotalComision.Expression = "Iif([TipoComision] == 1, ([TotalVenta]-[TotalDevolucion]) * ([CantidadComision]/1" +
    "00) , [CantidadComision] * ([CantidadVenta] - [CantidadDevolucion]))";
            this.TotalComision.Name = "TotalComision";
            // 
            // lbCEDI
            // 
            this.lbCEDI.Dpi = 100F;
            this.lbCEDI.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbCEDI.LocationFloat = new DevExpress.Utils.PointFloat(0F, 123.3333F);
            this.lbCEDI.Name = "lbCEDI";
            this.lbCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbCEDI.SizeF = new System.Drawing.SizeF(87.5F, 13F);
            this.lbCEDI.StylePriority.UseFont = false;
            this.lbCEDI.StylePriority.UsePadding = false;
            this.lbCEDI.StylePriority.UseTextAlignment = false;
            this.lbCEDI.Text = "CEDI";
            this.lbCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbFecha
            // 
            this.lbFecha.Dpi = 100F;
            this.lbFecha.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 149.3333F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(87.5F, 13F);
            this.lbFecha.StylePriority.UseFont = false;
            this.lbFecha.StylePriority.UsePadding = false;
            this.lbFecha.StylePriority.UseTextAlignment = false;
            this.lbFecha.Text = "Fecha";
            this.lbFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbVendedor
            // 
            this.lbVendedor.Dpi = 100F;
            this.lbVendedor.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 136.3333F);
            this.lbVendedor.Name = "lbVendedor";
            this.lbVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbVendedor.SizeF = new System.Drawing.SizeF(87.5F, 13F);
            this.lbVendedor.StylePriority.UseFont = false;
            this.lbVendedor.StylePriority.UsePadding = false;
            this.lbVendedor.StylePriority.UseTextAlignment = false;
            this.lbVendedor.Text = "Vendedor";
            this.lbVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.lbCEDIFiltro,
            this.lbFechaFiltro,
            this.lbVendedorFiltro,
            this.lbVendedor,
            this.lbFecha,
            this.lbCEDI});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 162.3333F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(226.5F, 75F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(226.5F, 15F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbCEDIFiltro
            // 
            this.lbCEDIFiltro.Dpi = 100F;
            this.lbCEDIFiltro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbCEDIFiltro.LocationFloat = new DevExpress.Utils.PointFloat(87.5F, 123.3333F);
            this.lbCEDIFiltro.Name = "lbCEDIFiltro";
            this.lbCEDIFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbCEDIFiltro.SizeF = new System.Drawing.SizeF(750.5F, 13F);
            this.lbCEDIFiltro.StylePriority.UseFont = false;
            this.lbCEDIFiltro.StylePriority.UsePadding = false;
            this.lbCEDIFiltro.StylePriority.UseTextAlignment = false;
            this.lbCEDIFiltro.Text = "CEDI";
            this.lbCEDIFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbFechaFiltro
            // 
            this.lbFechaFiltro.Dpi = 100F;
            this.lbFechaFiltro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbFechaFiltro.LocationFloat = new DevExpress.Utils.PointFloat(87.5F, 149.3333F);
            this.lbFechaFiltro.Name = "lbFechaFiltro";
            this.lbFechaFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbFechaFiltro.SizeF = new System.Drawing.SizeF(750.5F, 13F);
            this.lbFechaFiltro.StylePriority.UseFont = false;
            this.lbFechaFiltro.StylePriority.UsePadding = false;
            this.lbFechaFiltro.StylePriority.UseTextAlignment = false;
            this.lbFechaFiltro.Text = "Fecha";
            this.lbFechaFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbVendedorFiltro
            // 
            this.lbVendedorFiltro.Dpi = 100F;
            this.lbVendedorFiltro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbVendedorFiltro.LocationFloat = new DevExpress.Utils.PointFloat(87.5F, 136.3333F);
            this.lbVendedorFiltro.Name = "lbVendedorFiltro";
            this.lbVendedorFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbVendedorFiltro.SizeF = new System.Drawing.SizeF(750.5F, 13F);
            this.lbVendedorFiltro.StylePriority.UseFont = false;
            this.lbVendedorFiltro.StylePriority.UsePadding = false;
            this.lbVendedorFiltro.StylePriority.UseTextAlignment = false;
            this.lbVendedorFiltro.Text = "Vendedor";
            this.lbVendedorFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Comision
            // 
            this.Comision.DataMember = "Query";
            this.Comision.Expression = "Iif([TipoComision] == 1, Concat([CantidadComision], \'%\'),  [CantidadComision])";
            this.Comision.Name = "Comision";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Comision")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(574.6666F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(75.33337F, 13F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // rptEsquemas
            // 
            this.rptEsquemas.Dpi = 100F;
            this.rptEsquemas.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.rptEsquemas.Name = "rptEsquemas";
            this.rptEsquemas.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VendedorId", null, "Query.VendedorID"));
            this.rptEsquemas.ReportSource = new ReporteEsquemasComisionesTUC();
            this.rptEsquemas.SizeF = new System.Drawing.SizeF(826.3333F, 24.99999F);
            // 
            // ReporteComisionesTUC
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1,
            this.ReportHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calculatedField1,
            this.TotalComision,
            this.Comision});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(12, 0, 49, 40);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
