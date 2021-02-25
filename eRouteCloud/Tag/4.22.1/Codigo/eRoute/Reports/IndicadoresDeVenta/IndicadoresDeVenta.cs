using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class IndicadoresDeVenta : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRPictureBox pbLogo;
    public XRLabel lbNombre;
    public XRLabel lbFecha;
    public XRLabel lbFechaFiltro;
    public XRLabel lbVenRuta;
    public XRLabel lbVenRutaFiltro;
    public XRLabel lbCEDI;
    public XRLabel lbCEDIFiltro;
    public XRLabel lbFueraFrecV;
    public XRLabel lbFueraFrec;
    public XRLabel lbTotalVenta;
    public XRLabel lbNoVisitados;
    public XRLabel lbEfectividad;
    public XRLabel lbVisVenta;
    public XRLabel lbEficiencia;
    public XRLabel lbVisitados;
    public XRLabel lbItinerario;
    public XRLabel lbFechaG;
    public XRLabel lbRutaG;
    private XRLabel lbItinerarioTG;
    private XRLabel lbVisitadosTG;
    private XRLabel lbVisVentaTG;
    private XRLabel lbNoVisitadosTG;
    private XRLabel lbTotalVentaTG;
    private XRLabel lbFueraFrecTG;
    private XRLabel lbFueraFrecVTG;
    public XRLabel lbAcumulado;
    private ReportFooterBand ReportFooter;
    public XRLabel lbTotalRuta;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel1;
    public SqlDataSource sqlDataSource1;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private ReportHeaderBand ReportHeader;
    private FormattingRule formattingRule1;
    private CalculatedField calcEficienciaRuta;
    private XRLabel xrLabel2;
    private CalculatedField calcItinerarioRuta;
    private CalculatedField calcVisitaRuta;
    private CalculatedField calcVisitVentaRuta;
    private CalculatedField calcEfectividadRuta;
    private XRLabel xrLabel22;
    private XRLabel xrLabel17;
    private XRLabel xrLabel15;
    private CalculatedField calcEficienciaTotal;
    private CalculatedField calcItinerarioTotal;
    private CalculatedField calcVisitaTotal;
    private CalculatedField calcEfectividadTotal;
    private CalculatedField calcVisitVentaTotal;
    public XRLabel lbNombreReporte;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public IndicadoresDeVenta()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }
    public IndicadoresDeVenta(string cons)
    {
        InitializeComponent();
        //DataSourceDemanded += ClientesSinVenta_DataSourceDemanded(null, null, cons);
        sqlDataSource1.Queries.RemoveAt(0);
        CustomSqlQuery query = new CustomSqlQuery("Query", cons);
        sqlDataSource1.Queries.Add(query);
        sqlDataSource1.RebuildResultSchema();
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndicadoresDeVenta));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lbVenRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVenRutaFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCEDIFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.pbLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.lbNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFechaFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lbFueraFrecV = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFueraFrec = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNoVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEfectividad = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVisVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEficiencia = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.lbItinerario = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFechaG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRutaG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbItinerarioTG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVisitadosTG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVisVentaTG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNoVisitadosTG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalVentaTG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFueraFrecTG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFueraFrecVTG = new DevExpress.XtraReports.UI.XRLabel();
            this.lbAcumulado = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbNombreReporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.calcEficienciaRuta = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcItinerarioRuta = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcVisitaRuta = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcVisitVentaRuta = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcEfectividadRuta = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcEficienciaTotal = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcItinerarioTotal = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcVisitaTotal = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcEfectividadTotal = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcVisitVentaTotal = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel11,
            this.xrLabel10});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FueraFrecuenciaV")});
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(633.1666F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(66.83325F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FueraFrecuencia")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(575.5F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalVenta", "{0:$0.00}")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(487.8334F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(87.66663F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.NoVisitados", "{0:0}")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(426.8331F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(61.00037F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Efectividad", "{0:0.00}%")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(352.4998F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(74.33328F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VisitadosVenta")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(278.9999F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(73.49997F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Eficiencia", "{0:0.00}%")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(204.6666F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(74.3333F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Visitados")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(135.3333F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(69.33333F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Itinerario")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(77.66663F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Fecha")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(77.66663F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 67F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbVenRuta
            // 
            this.lbVenRuta.Dpi = 100F;
            this.lbVenRuta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbVenRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130.1667F);
            this.lbVenRuta.Name = "lbVenRuta";
            this.lbVenRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVenRuta.SizeF = new System.Drawing.SizeF(152F, 23.00002F);
            this.lbVenRuta.StylePriority.UseFont = false;
            this.lbVenRuta.Text = "lbVenRuta";
            // 
            // lbVenRutaFiltro
            // 
            this.lbVenRutaFiltro.Dpi = 100F;
            this.lbVenRutaFiltro.Font = new System.Drawing.Font("Arial", 9F);
            this.lbVenRutaFiltro.LocationFloat = new DevExpress.Utils.PointFloat(152F, 130.1667F);
            this.lbVenRutaFiltro.Name = "lbVenRutaFiltro";
            this.lbVenRutaFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVenRutaFiltro.SizeF = new System.Drawing.SizeF(548F, 23.00001F);
            this.lbVenRutaFiltro.StylePriority.UseFont = false;
            // 
            // lbCEDI
            // 
            this.lbCEDI.Dpi = 100F;
            this.lbCEDI.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbCEDI.LocationFloat = new DevExpress.Utils.PointFloat(0F, 107.1666F);
            this.lbCEDI.Name = "lbCEDI";
            this.lbCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCEDI.SizeF = new System.Drawing.SizeF(152F, 23F);
            this.lbCEDI.StylePriority.UseFont = false;
            this.lbCEDI.Text = "lbCEDI";
            // 
            // lbCEDIFiltro
            // 
            this.lbCEDIFiltro.Dpi = 100F;
            this.lbCEDIFiltro.Font = new System.Drawing.Font("Arial", 9F);
            this.lbCEDIFiltro.LocationFloat = new DevExpress.Utils.PointFloat(152F, 107.1666F);
            this.lbCEDIFiltro.Name = "lbCEDIFiltro";
            this.lbCEDIFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCEDIFiltro.SizeF = new System.Drawing.SizeF(548F, 23F);
            this.lbCEDIFiltro.StylePriority.UseFont = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Dpi = 100F;
            this.pbLogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.SizeF = new System.Drawing.SizeF(151.8333F, 95F);
            // 
            // lbNombre
            // 
            this.lbNombre.Dpi = 100F;
            this.lbNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbNombre.LocationFloat = new DevExpress.Utils.PointFloat(151.8333F, 0F);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNombre.SizeF = new System.Drawing.SizeF(548.1666F, 23.00001F);
            this.lbNombre.StylePriority.UseFont = false;
            this.lbNombre.StylePriority.UseTextAlignment = false;
            this.lbNombre.Text = "lbNombre";
            this.lbNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbFecha
            // 
            this.lbFecha.Dpi = 100F;
            this.lbFecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 153.1667F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(152F, 23.00002F);
            this.lbFecha.StylePriority.UseFont = false;
            this.lbFecha.Text = "lbFecha";
            // 
            // lbFechaFiltro
            // 
            this.lbFechaFiltro.Dpi = 100F;
            this.lbFechaFiltro.Font = new System.Drawing.Font("Arial", 9F);
            this.lbFechaFiltro.LocationFloat = new DevExpress.Utils.PointFloat(152F, 153.1667F);
            this.lbFechaFiltro.Name = "lbFechaFiltro";
            this.lbFechaFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFechaFiltro.SizeF = new System.Drawing.SizeF(548F, 23.00001F);
            this.lbFechaFiltro.StylePriority.UseFont = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 88F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(387F, 10F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // lbFueraFrecV
            // 
            this.lbFueraFrecV.Dpi = 100F;
            this.lbFueraFrecV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbFueraFrecV.LocationFloat = new DevExpress.Utils.PointFloat(633.1666F, 32.99998F);
            this.lbFueraFrecV.Name = "lbFueraFrecV";
            this.lbFueraFrecV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFueraFrecV.SizeF = new System.Drawing.SizeF(66.83325F, 23F);
            this.lbFueraFrecV.StylePriority.UseFont = false;
            this.lbFueraFrecV.StylePriority.UseTextAlignment = false;
            this.lbFueraFrecV.Text = "lbFueraFrecV";
            this.lbFueraFrecV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbFueraFrec
            // 
            this.lbFueraFrec.Dpi = 100F;
            this.lbFueraFrec.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbFueraFrec.LocationFloat = new DevExpress.Utils.PointFloat(575.5F, 32.99998F);
            this.lbFueraFrec.Name = "lbFueraFrec";
            this.lbFueraFrec.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFueraFrec.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.lbFueraFrec.StylePriority.UseFont = false;
            this.lbFueraFrec.StylePriority.UseTextAlignment = false;
            this.lbFueraFrec.Text = "lbFueraFrec";
            this.lbFueraFrec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalVenta
            // 
            this.lbTotalVenta.Dpi = 100F;
            this.lbTotalVenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalVenta.LocationFloat = new DevExpress.Utils.PointFloat(487.8334F, 32.99998F);
            this.lbTotalVenta.Name = "lbTotalVenta";
            this.lbTotalVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalVenta.SizeF = new System.Drawing.SizeF(87.66663F, 23F);
            this.lbTotalVenta.StylePriority.UseFont = false;
            this.lbTotalVenta.StylePriority.UseTextAlignment = false;
            this.lbTotalVenta.Text = "lbTotalVenta";
            this.lbTotalVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbNoVisitados
            // 
            this.lbNoVisitados.Dpi = 100F;
            this.lbNoVisitados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbNoVisitados.LocationFloat = new DevExpress.Utils.PointFloat(426.8331F, 32.99998F);
            this.lbNoVisitados.Name = "lbNoVisitados";
            this.lbNoVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNoVisitados.SizeF = new System.Drawing.SizeF(61.00037F, 23F);
            this.lbNoVisitados.StylePriority.UseFont = false;
            this.lbNoVisitados.StylePriority.UseTextAlignment = false;
            this.lbNoVisitados.Text = "lbNoVisitados";
            this.lbNoVisitados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEfectividad
            // 
            this.lbEfectividad.Dpi = 100F;
            this.lbEfectividad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbEfectividad.LocationFloat = new DevExpress.Utils.PointFloat(352.4998F, 32.99998F);
            this.lbEfectividad.Name = "lbEfectividad";
            this.lbEfectividad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEfectividad.SizeF = new System.Drawing.SizeF(74.33328F, 23F);
            this.lbEfectividad.StylePriority.UseFont = false;
            this.lbEfectividad.StylePriority.UseTextAlignment = false;
            this.lbEfectividad.Text = "lbEfectividad";
            this.lbEfectividad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbVisVenta
            // 
            this.lbVisVenta.Dpi = 100F;
            this.lbVisVenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbVisVenta.LocationFloat = new DevExpress.Utils.PointFloat(278.9999F, 32.99998F);
            this.lbVisVenta.Name = "lbVisVenta";
            this.lbVisVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVisVenta.SizeF = new System.Drawing.SizeF(73.49997F, 23F);
            this.lbVisVenta.StylePriority.UseFont = false;
            this.lbVisVenta.StylePriority.UseTextAlignment = false;
            this.lbVisVenta.Text = "lbVisVenta";
            this.lbVisVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEficiencia
            // 
            this.lbEficiencia.Dpi = 100F;
            this.lbEficiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbEficiencia.LocationFloat = new DevExpress.Utils.PointFloat(204.6666F, 32.99998F);
            this.lbEficiencia.Name = "lbEficiencia";
            this.lbEficiencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEficiencia.SizeF = new System.Drawing.SizeF(74.3333F, 23F);
            this.lbEficiencia.StylePriority.UseFont = false;
            this.lbEficiencia.StylePriority.UseTextAlignment = false;
            this.lbEficiencia.Text = "lbEficiencia";
            this.lbEficiencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbVisitados
            // 
            this.lbVisitados.Dpi = 100F;
            this.lbVisitados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbVisitados.LocationFloat = new DevExpress.Utils.PointFloat(135.3333F, 32.99998F);
            this.lbVisitados.Name = "lbVisitados";
            this.lbVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVisitados.SizeF = new System.Drawing.SizeF(69.33333F, 23F);
            this.lbVisitados.StylePriority.UseFont = false;
            this.lbVisitados.StylePriority.UseTextAlignment = false;
            this.lbVisitados.Text = "lbVisitados";
            this.lbVisitados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbItinerario
            // 
            this.lbItinerario.Dpi = 100F;
            this.lbItinerario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbItinerario.LocationFloat = new DevExpress.Utils.PointFloat(77.66663F, 32.99998F);
            this.lbItinerario.Name = "lbItinerario";
            this.lbItinerario.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbItinerario.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.lbItinerario.StylePriority.UseFont = false;
            this.lbItinerario.StylePriority.UseTextAlignment = false;
            this.lbItinerario.Text = "lbItinerario";
            this.lbItinerario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbFechaG
            // 
            this.lbFechaG.Dpi = 100F;
            this.lbFechaG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbFechaG.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32.99998F);
            this.lbFechaG.Name = "lbFechaG";
            this.lbFechaG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFechaG.SizeF = new System.Drawing.SizeF(77.66663F, 23F);
            this.lbFechaG.StylePriority.UseFont = false;
            this.lbFechaG.StylePriority.UseTextAlignment = false;
            this.lbFechaG.Text = "lbFechaG";
            this.lbFechaG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbRutaG
            // 
            this.lbRutaG.Dpi = 100F;
            this.lbRutaG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbRutaG.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.lbRutaG.Name = "lbRutaG";
            this.lbRutaG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbRutaG.SizeF = new System.Drawing.SizeF(77.66663F, 23F);
            this.lbRutaG.StylePriority.UseFont = false;
            this.lbRutaG.Text = "lbRutaG";
            // 
            // lbItinerarioTG
            // 
            this.lbItinerarioTG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Itinerario")});
            this.lbItinerarioTG.Dpi = 100F;
            this.lbItinerarioTG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbItinerarioTG.LocationFloat = new DevExpress.Utils.PointFloat(77.66663F, 0F);
            this.lbItinerarioTG.Name = "lbItinerarioTG";
            this.lbItinerarioTG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbItinerarioTG.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.lbItinerarioTG.StylePriority.UseFont = false;
            this.lbItinerarioTG.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lbItinerarioTG.Summary = xrSummary1;
            this.lbItinerarioTG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbVisitadosTG
            // 
            this.lbVisitadosTG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Visitados")});
            this.lbVisitadosTG.Dpi = 100F;
            this.lbVisitadosTG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbVisitadosTG.LocationFloat = new DevExpress.Utils.PointFloat(135.3333F, 0F);
            this.lbVisitadosTG.Name = "lbVisitadosTG";
            this.lbVisitadosTG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVisitadosTG.SizeF = new System.Drawing.SizeF(69.33333F, 23F);
            this.lbVisitadosTG.StylePriority.UseFont = false;
            this.lbVisitadosTG.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lbVisitadosTG.Summary = xrSummary2;
            this.lbVisitadosTG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbVisVentaTG
            // 
            this.lbVisVentaTG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VisitadosVenta")});
            this.lbVisVentaTG.Dpi = 100F;
            this.lbVisVentaTG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbVisVentaTG.LocationFloat = new DevExpress.Utils.PointFloat(278.9999F, 0F);
            this.lbVisVentaTG.Name = "lbVisVentaTG";
            this.lbVisVentaTG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVisVentaTG.SizeF = new System.Drawing.SizeF(73.49997F, 23F);
            this.lbVisVentaTG.StylePriority.UseFont = false;
            this.lbVisVentaTG.StylePriority.UseTextAlignment = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lbVisVentaTG.Summary = xrSummary3;
            this.lbVisVentaTG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbNoVisitadosTG
            // 
            this.lbNoVisitadosTG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.NoVisitados")});
            this.lbNoVisitadosTG.Dpi = 100F;
            this.lbNoVisitadosTG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbNoVisitadosTG.LocationFloat = new DevExpress.Utils.PointFloat(426.8331F, 0F);
            this.lbNoVisitadosTG.Name = "lbNoVisitadosTG";
            this.lbNoVisitadosTG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNoVisitadosTG.SizeF = new System.Drawing.SizeF(61.00037F, 23F);
            this.lbNoVisitadosTG.StylePriority.UseFont = false;
            this.lbNoVisitadosTG.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:0}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lbNoVisitadosTG.Summary = xrSummary4;
            this.lbNoVisitadosTG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbTotalVentaTG
            // 
            this.lbTotalVentaTG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalVenta")});
            this.lbTotalVentaTG.Dpi = 100F;
            this.lbTotalVentaTG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalVentaTG.LocationFloat = new DevExpress.Utils.PointFloat(487.8334F, 0F);
            this.lbTotalVentaTG.Name = "lbTotalVentaTG";
            this.lbTotalVentaTG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalVentaTG.SizeF = new System.Drawing.SizeF(87.66663F, 23F);
            this.lbTotalVentaTG.StylePriority.UseFont = false;
            this.lbTotalVentaTG.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:$0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lbTotalVentaTG.Summary = xrSummary5;
            this.lbTotalVentaTG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbFueraFrecTG
            // 
            this.lbFueraFrecTG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FueraFrecuencia")});
            this.lbFueraFrecTG.Dpi = 100F;
            this.lbFueraFrecTG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbFueraFrecTG.LocationFloat = new DevExpress.Utils.PointFloat(575.5F, 0F);
            this.lbFueraFrecTG.Name = "lbFueraFrecTG";
            this.lbFueraFrecTG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFueraFrecTG.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.lbFueraFrecTG.StylePriority.UseFont = false;
            this.lbFueraFrecTG.StylePriority.UseTextAlignment = false;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lbFueraFrecTG.Summary = xrSummary6;
            this.lbFueraFrecTG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbFueraFrecVTG
            // 
            this.lbFueraFrecVTG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FueraFrecuenciaV")});
            this.lbFueraFrecVTG.Dpi = 100F;
            this.lbFueraFrecVTG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbFueraFrecVTG.LocationFloat = new DevExpress.Utils.PointFloat(633.1666F, 0F);
            this.lbFueraFrecVTG.Name = "lbFueraFrecVTG";
            this.lbFueraFrecVTG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFueraFrecVTG.SizeF = new System.Drawing.SizeF(66.83325F, 23F);
            this.lbFueraFrecVTG.StylePriority.UseFont = false;
            this.lbFueraFrecVTG.StylePriority.UseTextAlignment = false;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lbFueraFrecVTG.Summary = xrSummary7;
            this.lbFueraFrecVTG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbAcumulado
            // 
            this.lbAcumulado.Dpi = 100F;
            this.lbAcumulado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbAcumulado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.lbAcumulado.Name = "lbAcumulado";
            this.lbAcumulado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbAcumulado.SizeF = new System.Drawing.SizeF(77.66663F, 23F);
            this.lbAcumulado.StylePriority.UseFont = false;
            this.lbAcumulado.Text = "lbAcumulado";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22,
            this.xrLabel17,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel16,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21,
            this.lbAcumulado});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 41.66669F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calcEfectividadTotal", "{0:0.00%}")});
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(352.4998F, 10F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(74.33328F, 23F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calcEficienciaTotal", "{0:0.00%}")});
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(204.6666F, 10F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(74.3333F, 23F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Itinerario")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(77.66663F, 10F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel13.Summary = xrSummary8;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Visitados")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(135.3333F, 10F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(69.33333F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel14.Summary = xrSummary9;
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VisitadosVenta")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(278.9999F, 10F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(73.49997F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel16.Summary = xrSummary10;
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.NoVisitados")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(426.8331F, 10F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(61.00037F, 23F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            xrSummary11.FormatString = "{0:#,#}";
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel18.Summary = xrSummary11;
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalVenta", "{0:$0.00}")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(487.8335F, 10F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(87.66663F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            xrSummary12.FormatString = "{0:$0.00}";
            xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel19.Summary = xrSummary12;
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FueraFrecuencia")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(575.5001F, 10F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(57.66663F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel20.Summary = xrSummary13;
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FueraFrecuenciaV")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(633.1667F, 10F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(66.83325F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel21.Summary = xrSummary14;
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbTotalRuta
            // 
            this.lbTotalRuta.Dpi = 100F;
            this.lbTotalRuta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalRuta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbTotalRuta.Name = "lbTotalRuta";
            this.lbTotalRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalRuta.SizeF = new System.Drawing.SizeF(77.66663F, 23F);
            this.lbTotalRuta.StylePriority.UseFont = false;
            this.lbTotalRuta.Text = "lbTotalRuta";
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
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Ruta")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(77.66663F, 10F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(572.3334F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "xrLabel12";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbNombreReporte,
            this.lbCEDIFiltro,
            this.lbNombre,
            this.lbCEDI,
            this.lbFechaFiltro,
            this.lbVenRuta,
            this.lbVenRutaFiltro,
            this.lbFecha,
            this.pbLogo});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 192.5F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbNombreReporte
            // 
            this.lbNombreReporte.Dpi = 100F;
            this.lbNombreReporte.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbNombreReporte.LocationFloat = new DevExpress.Utils.PointFloat(151.8333F, 23.00001F);
            this.lbNombreReporte.Name = "lbNombreReporte";
            this.lbNombreReporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNombreReporte.SizeF = new System.Drawing.SizeF(548.1667F, 23.00001F);
            this.lbNombreReporte.StylePriority.UseFont = false;
            this.lbNombreReporte.StylePriority.UseTextAlignment = false;
            this.lbNombreReporte.Text = "lbNombreReporte";
            this.lbNombreReporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calcEfectividadRuta", "{0:0.00%}")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(352.4998F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(74.33328F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.calcEficienciaRuta", "{0:0.00%}")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(204.6666F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(74.3333F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // calcEficienciaRuta
            // 
            this.calcEficienciaRuta.DataMember = "Query";
            this.calcEficienciaRuta.Expression = "Iif([calcItinerarioRuta]>0,[calcVisitaRuta] / [calcItinerarioRuta],0)";
            this.calcEficienciaRuta.FieldType = DevExpress.XtraReports.UI.FieldType.Double;
            this.calcEficienciaRuta.Name = "calcEficienciaRuta";
            // 
            // calcItinerarioRuta
            // 
            this.calcItinerarioRuta.DataMember = "Query";
            this.calcItinerarioRuta.Expression = "[][[Ruta] ==  [^.Ruta]].Sum([Itinerario])";
            this.calcItinerarioRuta.Name = "calcItinerarioRuta";
            // 
            // calcVisitaRuta
            // 
            this.calcVisitaRuta.DataMember = "Query";
            this.calcVisitaRuta.Expression = "[][[Ruta] ==  [^.Ruta]].Sum([Visitados])";
            this.calcVisitaRuta.Name = "calcVisitaRuta";
            // 
            // calcVisitVentaRuta
            // 
            this.calcVisitVentaRuta.DataMember = "Query";
            this.calcVisitVentaRuta.Expression = "[][[Ruta] ==  [^.Ruta]].Sum([VisitadosVenta])";
            this.calcVisitVentaRuta.Name = "calcVisitVentaRuta";
            // 
            // calcEfectividadRuta
            // 
            this.calcEfectividadRuta.DataMember = "Query";
            this.calcEfectividadRuta.Expression = "Iif([calcItinerarioRuta]>0,[calcVisitVentaRuta] / [calcItinerarioRuta],0)";
            this.calcEfectividadRuta.FieldType = DevExpress.XtraReports.UI.FieldType.Double;
            this.calcEfectividadRuta.Name = "calcEfectividadRuta";
            // 
            // calcEficienciaTotal
            // 
            this.calcEficienciaTotal.DataMember = "Query";
            this.calcEficienciaTotal.Expression = "Iif([calcItinerarioTotal]>0,[calcVisitaTotal] / [calcItinerarioTotal],0)";
            this.calcEficienciaTotal.FieldType = DevExpress.XtraReports.UI.FieldType.Double;
            this.calcEficienciaTotal.Name = "calcEficienciaTotal";
            // 
            // calcItinerarioTotal
            // 
            this.calcItinerarioTotal.DataMember = "Query";
            this.calcItinerarioTotal.Expression = "[].Sum([Itinerario])";
            this.calcItinerarioTotal.Name = "calcItinerarioTotal";
            // 
            // calcVisitaTotal
            // 
            this.calcVisitaTotal.DataMember = "Query";
            this.calcVisitaTotal.Expression = "[].Sum([Visitados])";
            this.calcVisitaTotal.Name = "calcVisitaTotal";
            // 
            // calcEfectividadTotal
            // 
            this.calcEfectividadTotal.DataMember = "Query";
            this.calcEfectividadTotal.Expression = "Iif([calcItinerarioTotal]>0,[calcVisitVentaTotal] / [calcItinerarioTotal],0)";
            this.calcEfectividadTotal.FieldType = DevExpress.XtraReports.UI.FieldType.Double;
            this.calcEfectividadTotal.Name = "calcEfectividadTotal";
            // 
            // calcVisitVentaTotal
            // 
            this.calcVisitVentaTotal.DataMember = "Query";
            this.calcVisitVentaTotal.Expression = "[].Sum([VisitadosVenta])";
            this.calcVisitVentaTotal.Name = "calcVisitVentaTotal";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbRutaG,
            this.lbFueraFrecV,
            this.lbFueraFrec,
            this.lbTotalVenta,
            this.lbNoVisitados,
            this.lbEfectividad,
            this.lbVisVenta,
            this.lbEficiencia,
            this.lbVisitados,
            this.lbItinerario,
            this.lbFechaG,
            this.xrLabel12});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Ruta", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 55.99998F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbTotalRuta,
            this.lbFueraFrecVTG,
            this.lbItinerarioTG,
            this.lbVisitadosTG,
            this.lbVisVentaTG,
            this.lbNoVisitadosTG,
            this.lbTotalVentaTG,
            this.lbFueraFrecTG,
            this.xrLabel2,
            this.xrLabel15});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 36.66667F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // IndicadoresDeVenta
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calcEficienciaRuta,
            this.calcItinerarioRuta,
            this.calcVisitaRuta,
            this.calcVisitVentaRuta,
            this.calcEfectividadRuta,
            this.calcEficienciaTotal,
            this.calcItinerarioTotal,
            this.calcVisitaTotal,
            this.calcEfectividadTotal,
            this.calcVisitVentaTotal});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Margins = new System.Drawing.Printing.Margins(76, 74, 67, 88);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
