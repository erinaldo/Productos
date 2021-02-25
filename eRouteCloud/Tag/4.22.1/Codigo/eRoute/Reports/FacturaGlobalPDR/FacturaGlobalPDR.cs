using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

/// <summary>
/// Summary description for FacturaGlobalPDR
/// </summary>
public class FacturaGlobalPDR : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    public XRLabel lbNombreReporte;
    public XRLabel lbTituloVentas;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    public XRLabel lbFolio;
    public XRLabel lbRazon;
    public XRLabel lbFecha;
    public XRLabel lbImporte;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportFooterBand ReportFooter;
    public XRLabel lbTotalVentas;
    private XRLabel xrLabel6;
    private CalculatedField TotalVenta;
    public XRSubreport rptCobranza;
    private XRControlStyle xrControlStyle1;
    public XRLabel lbNombre;
    private XRLabel xrLabel7;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public FacturaGlobalPDR()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public FacturaGlobalPDR(string sVentas, string sCobranza)
    {
        InitializeComponent();
        //DataSourceDemanded += ClientesSinVenta_DataSourceDemanded(null, null, cons);
        sqlDataSource1.Queries.RemoveAt(0);
        CustomSqlQuery query = new CustomSqlQuery("Query", sVentas);
        sqlDataSource1.Queries.Add(query);
        sqlDataSource1.RebuildResultSchema();

        ((CobranzaFacturaGlobalPDR)rptCobranza.ReportSource).SetDataSource(sCobranza);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturaGlobalPDR));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFolio = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRazon = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTituloVentas = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNombreReporte = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalVentas = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalVenta = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.rptCobranza = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 19F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.NombreCorto")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(170.6717F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(207.6665F, 19F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Total", "{0:$0.00}")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(99F, 19F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RazonSocial")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(378.4217F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(271.5783F, 19F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Folio")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0.04170736F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(84.12829F, 19F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FechaCaptura", "{0:dd/MM/yyyy}")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(84.21173F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(86.41829F, 19F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 47.5F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 48.49998F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbNombre,
            this.lbFolio,
            this.lbRazon,
            this.lbFecha,
            this.lbImporte,
            this.lbTituloVentas,
            this.lbNombreReporte});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 69F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbNombre
            // 
            this.lbNombre.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbNombre.Dpi = 100F;
            this.lbNombre.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbNombre.LocationFloat = new DevExpress.Utils.PointFloat(170.63F, 50F);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbNombre.SizeF = new System.Drawing.SizeF(207.7082F, 19F);
            this.lbNombre.StylePriority.UseBorders = false;
            this.lbNombre.StylePriority.UseFont = false;
            this.lbNombre.StylePriority.UsePadding = false;
            this.lbNombre.StylePriority.UseTextAlignment = false;
            this.lbNombre.Text = "NOMBRE COMERCIAL";
            this.lbNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbFolio
            // 
            this.lbFolio.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbFolio.Dpi = 100F;
            this.lbFolio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbFolio.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.lbFolio.Name = "lbFolio";
            this.lbFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbFolio.SizeF = new System.Drawing.SizeF(84.17F, 19F);
            this.lbFolio.StylePriority.UseBorders = false;
            this.lbFolio.StylePriority.UseFont = false;
            this.lbFolio.StylePriority.UsePadding = false;
            this.lbFolio.StylePriority.UseTextAlignment = false;
            this.lbFolio.Text = "FOLIO";
            this.lbFolio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbRazon
            // 
            this.lbRazon.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbRazon.Dpi = 100F;
            this.lbRazon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbRazon.LocationFloat = new DevExpress.Utils.PointFloat(378.3799F, 50F);
            this.lbRazon.Name = "lbRazon";
            this.lbRazon.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbRazon.SizeF = new System.Drawing.SizeF(271.6201F, 19F);
            this.lbRazon.StylePriority.UseBorders = false;
            this.lbRazon.StylePriority.UseFont = false;
            this.lbRazon.StylePriority.UsePadding = false;
            this.lbRazon.StylePriority.UseTextAlignment = false;
            this.lbRazon.Text = "RAZON SOCIAL";
            this.lbRazon.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbFecha
            // 
            this.lbFecha.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbFecha.Dpi = 100F;
            this.lbFecha.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(84.17002F, 50F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(86.46F, 19F);
            this.lbFecha.StylePriority.UseBorders = false;
            this.lbFecha.StylePriority.UseFont = false;
            this.lbFecha.StylePriority.UsePadding = false;
            this.lbFecha.StylePriority.UseTextAlignment = false;
            this.lbFecha.Text = "FECHA";
            this.lbFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbImporte
            // 
            this.lbImporte.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbImporte.Dpi = 100F;
            this.lbImporte.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbImporte.LocationFloat = new DevExpress.Utils.PointFloat(650F, 50F);
            this.lbImporte.Name = "lbImporte";
            this.lbImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbImporte.SizeF = new System.Drawing.SizeF(99F, 19F);
            this.lbImporte.StylePriority.UseBorders = false;
            this.lbImporte.StylePriority.UseFont = false;
            this.lbImporte.StylePriority.UsePadding = false;
            this.lbImporte.StylePriority.UseTextAlignment = false;
            this.lbImporte.Text = "IMPORTE";
            this.lbImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbTituloVentas
            // 
            this.lbTituloVentas.BackColor = System.Drawing.Color.LightGray;
            this.lbTituloVentas.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbTituloVentas.Dpi = 100F;
            this.lbTituloVentas.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lbTituloVentas.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.lbTituloVentas.Name = "lbTituloVentas";
            this.lbTituloVentas.Padding = new DevExpress.XtraPrinting.PaddingInfo(50, 2, 0, 0, 100F);
            this.lbTituloVentas.SizeF = new System.Drawing.SizeF(749F, 25F);
            this.lbTituloVentas.StylePriority.UseBackColor = false;
            this.lbTituloVentas.StylePriority.UseBorders = false;
            this.lbTituloVentas.StylePriority.UseFont = false;
            this.lbTituloVentas.StylePriority.UsePadding = false;
            this.lbTituloVentas.StylePriority.UseTextAlignment = false;
            this.lbTituloVentas.Text = "VENTAS CONTADO PUBLICO GENERAL";
            this.lbTituloVentas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbNombreReporte
            // 
            this.lbNombreReporte.BackColor = System.Drawing.Color.DarkGray;
            this.lbNombreReporte.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbNombreReporte.Dpi = 100F;
            this.lbNombreReporte.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lbNombreReporte.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbNombreReporte.Name = "lbNombreReporte";
            this.lbNombreReporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(50, 2, 0, 0, 100F);
            this.lbNombreReporte.SizeF = new System.Drawing.SizeF(749F, 25F);
            this.lbNombreReporte.StylePriority.UseBackColor = false;
            this.lbNombreReporte.StylePriority.UseBorders = false;
            this.lbNombreReporte.StylePriority.UseFont = false;
            this.lbNombreReporte.StylePriority.UsePadding = false;
            this.lbNombreReporte.StylePriority.UseTextAlignment = false;
            this.lbNombreReporte.Text = "REPORTE FACTURA GLOBAL";
            this.lbNombreReporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.rptCobranza,
            this.xrLabel6,
            this.lbTotalVentas});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 60.5F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalVenta", "{0:$0.00}")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(649.9999F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(98.83331F, 25F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lbTotalVentas
            // 
            this.lbTotalVentas.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbTotalVentas.Dpi = 100F;
            this.lbTotalVentas.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTotalVentas.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.lbTotalVentas.Name = "lbTotalVentas";
            this.lbTotalVentas.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbTotalVentas.SizeF = new System.Drawing.SizeF(400F, 25F);
            this.lbTotalVentas.StylePriority.UseBorders = false;
            this.lbTotalVentas.StylePriority.UseFont = false;
            this.lbTotalVentas.StylePriority.UsePadding = false;
            this.lbTotalVentas.StylePriority.UseTextAlignment = false;
            this.lbTotalVentas.Text = "SUBTOTAL VENTAS CONTADO PUBLICO GENERAL";
            this.lbTotalVentas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TotalVenta
            // 
            this.TotalVenta.DataMember = "Query";
            this.TotalVenta.Expression = "[].Sum([Total])";
            this.TotalVenta.Name = "TotalVenta";
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // rptCobranza
            // 
            this.rptCobranza.Dpi = 100F;
            this.rptCobranza.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.5F);
            this.rptCobranza.Name = "rptCobranza";
            this.rptCobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("TotalVenta", null, "Query.TotalVenta"));
            this.rptCobranza.ReportSource = new CobranzaFacturaGlobalPDR();
            this.rptCobranza.SizeF = new System.Drawing.SizeF(749F, 23F);
            // 
            // FacturaGlobalPDR
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.TotalVenta});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(51, 50, 48, 48);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
