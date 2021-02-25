using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for InformeCuadreVentas
/// </summary>
public class InformeCuadreVentas : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel2;
    public XRLabel fecha;
    public XRLabel xLalmacen;
    private GroupFooterBand GroupFooter1;
    public XRLabel x5;
    public XRLabel x4;
    public XRLabel x3;
    public XRLabel x2;
    public XRLabel x1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private GroupHeaderBand GroupHeader1;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private ReportFooterBand ReportFooter;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRLabel y1;
    public XRLabel y2;
    public XRLabel y3;
    public XRLabel y4;
    public XRLabel y5;
    private XRLine xrLine4;
    private XRLine xrLine3;
    public XRLabel fechaActual1;
    private XRLabel xrLabel8;
    public XRLabel fechaActual2;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public InformeCuadreVentas()
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.x1 = new DevExpress.XtraReports.UI.XRLabel();
            this.x2 = new DevExpress.XtraReports.UI.XRLabel();
            this.x3 = new DevExpress.XtraReports.UI.XRLabel();
            this.x4 = new DevExpress.XtraReports.UI.XRLabel();
            this.x5 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.fechaActual1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xLalmacen = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.fechaActual2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.y1 = new DevExpress.XtraReports.UI.XRLabel();
            this.y2 = new DevExpress.XtraReports.UI.XRLabel();
            this.y3 = new DevExpress.XtraReports.UI.XRLabel();
            this.y4 = new DevExpress.XtraReports.UI.XRLabel();
            this.y5 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.x1,
            this.x2,
            this.x3,
            this.x4,
            this.x5});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 14.58334F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // x1
            // 
            this.x1.Dpi = 100F;
            this.x1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.x1.LocationFloat = new DevExpress.Utils.PointFloat(137.7707F, 0.6250064F);
            this.x1.Name = "x1";
            this.x1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x1.SizeF = new System.Drawing.SizeF(100F, 13.95833F);
            this.x1.StylePriority.UseFont = false;
            this.x1.StylePriority.UseTextAlignment = false;
            this.x1.Text = "Ruta";
            this.x1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // x2
            // 
            this.x2.Dpi = 100F;
            this.x2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.x2.LocationFloat = new DevExpress.Utils.PointFloat(238.2706F, 0.6250064F);
            this.x2.Name = "x2";
            this.x2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x2.SizeF = new System.Drawing.SizeF(121.875F, 13.95833F);
            this.x2.StylePriority.UseFont = false;
            this.x2.StylePriority.UseTextAlignment = false;
            this.x2.Text = "Ventas Sin Impuestos";
            this.x2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x3
            // 
            this.x3.Dpi = 100F;
            this.x3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.x3.LocationFloat = new DevExpress.Utils.PointFloat(360.1456F, 0.6250064F);
            this.x3.Name = "x3";
            this.x3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x3.SizeF = new System.Drawing.SizeF(100F, 13.95833F);
            this.x3.StylePriority.UseFont = false;
            this.x3.StylePriority.UseTextAlignment = false;
            this.x3.Text = "IVA";
            this.x3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // x4
            // 
            this.x4.Dpi = 100F;
            this.x4.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.x4.LocationFloat = new DevExpress.Utils.PointFloat(460.1455F, 0.6250064F);
            this.x4.Name = "x4";
            this.x4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x4.SizeF = new System.Drawing.SizeF(100F, 13.95833F);
            this.x4.StylePriority.UseFont = false;
            this.x4.StylePriority.UseTextAlignment = false;
            this.x4.Text = "IEPS";
            this.x4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x5
            // 
            this.x5.Dpi = 100F;
            this.x5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.x5.LocationFloat = new DevExpress.Utils.PointFloat(561.1453F, 0.6250064F);
            this.x5.Name = "x5";
            this.x5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x5.SizeF = new System.Drawing.SizeF(141.7084F, 13.95833F);
            this.x5.StylePriority.UseFont = false;
            this.x5.StylePriority.UseTextAlignment = false;
            this.x5.Text = "Venta Total";
            this.x5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.fechaActual1,
            this.xrLabel8,
            this.xrLabel2,
            this.fecha,
            this.xLalmacen});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 199.625F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fechaActual1
            // 
            this.fechaActual1.Dpi = 100F;
            this.fechaActual1.LocationFloat = new DevExpress.Utils.PointFloat(393.5205F, 124.0417F);
            this.fechaActual1.Name = "fechaActual1";
            this.fechaActual1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechaActual1.SizeF = new System.Drawing.SizeF(196.875F, 23F);
            this.fechaActual1.Text = "fechaActual";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(317.4788F, 124.0417F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(76.04172F, 26.29163F);
            this.xrLabel8.Text = "Fecha Actual";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(283.1037F, 150.3333F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(110.4167F, 26.29163F);
            this.xrLabel2.Text = "Rango de Fecha";
            // 
            // fecha
            // 
            this.fecha.Dpi = 100F;
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(393.5205F, 150.3333F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(196.875F, 23F);
            this.fecha.Text = "paramFecha";
            // 
            // xLalmacen
            // 
            this.xLalmacen.Dpi = 100F;
            this.xLalmacen.LocationFloat = new DevExpress.Utils.PointFloat(62.33325F, 176.625F);
            this.xLalmacen.Name = "xLalmacen";
            this.xLalmacen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xLalmacen.SizeF = new System.Drawing.SizeF(696.2708F, 23F);
            this.xLalmacen.StylePriority.UseTextAlignment = false;
            this.xLalmacen.Text = "xLalmacen";
            this.xLalmacen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 22.91667F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(136.2707F, 10.00001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Ruta";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(236.2707F, 10.00001F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(121.8751F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Ventas Sin Impuestos";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(358.6457F, 10.00001F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "IVA";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(458.6456F, 10.00001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "IEPS";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(559.6454F, 10.00001F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(142.7084F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Venta Total";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.xrLine3,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 50F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(137.7707F, 32.99999F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(564.5831F, 10.00001F);
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(137.7707F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(564.5831F, 10.00001F);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fechaActual2,
            this.xrPageInfo1});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 47.91667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // fechaActual2
            // 
            this.fechaActual2.Dpi = 100F;
            this.fechaActual2.LocationFloat = new DevExpress.Utils.PointFloat(469.6038F, 0F);
            this.fechaActual2.Name = "fechaActual2";
            this.fechaActual2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechaActual2.SizeF = new System.Drawing.SizeF(253.3961F, 23F);
            this.fechaActual2.StylePriority.UseTextAlignment = false;
            this.fechaActual2.Text = "fechaActual";
            this.fechaActual2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(722.9999F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLine1,
            this.y1,
            this.y2,
            this.y3,
            this.y4,
            this.y5});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 33.33333F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(138.7707F, 0F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(564.0831F, 4.000014F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(138.7707F, 4.000028F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(564.0831F, 2F);
            // 
            // y1
            // 
            this.y1.Dpi = 100F;
            this.y1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.y1.LocationFloat = new DevExpress.Utils.PointFloat(137.7707F, 10.00001F);
            this.y1.Name = "y1";
            this.y1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.y1.SizeF = new System.Drawing.SizeF(100F, 13.95833F);
            this.y1.StylePriority.UseFont = false;
            this.y1.StylePriority.UseTextAlignment = false;
            this.y1.Text = "Total";
            this.y1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // y2
            // 
            this.y2.Dpi = 100F;
            this.y2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.y2.LocationFloat = new DevExpress.Utils.PointFloat(238.2706F, 10.00001F);
            this.y2.Name = "y2";
            this.y2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.y2.SizeF = new System.Drawing.SizeF(121.875F, 13.95833F);
            this.y2.StylePriority.UseFont = false;
            this.y2.StylePriority.UseTextAlignment = false;
            this.y2.Text = "Ventas Sin Impuestos TOTAL";
            this.y2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // y3
            // 
            this.y3.Dpi = 100F;
            this.y3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.y3.LocationFloat = new DevExpress.Utils.PointFloat(360.1456F, 10.00001F);
            this.y3.Name = "y3";
            this.y3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.y3.SizeF = new System.Drawing.SizeF(100F, 13.95833F);
            this.y3.StylePriority.UseFont = false;
            this.y3.StylePriority.UseTextAlignment = false;
            this.y3.Text = "IVA";
            this.y3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // y4
            // 
            this.y4.Dpi = 100F;
            this.y4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.y4.LocationFloat = new DevExpress.Utils.PointFloat(460.1456F, 10.00001F);
            this.y4.Name = "y4";
            this.y4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.y4.SizeF = new System.Drawing.SizeF(100F, 13.95833F);
            this.y4.StylePriority.UseFont = false;
            this.y4.StylePriority.UseTextAlignment = false;
            this.y4.Text = "IEPS";
            this.y4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // y5
            // 
            this.y5.Dpi = 100F;
            this.y5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.y5.LocationFloat = new DevExpress.Utils.PointFloat(561.6454F, 10.00001F);
            this.y5.Name = "y5";
            this.y5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.y5.SizeF = new System.Drawing.SizeF(141.2084F, 13.95833F);
            this.y5.StylePriority.UseFont = false;
            this.y5.StylePriority.UseTextAlignment = false;
            this.y5.Text = "Venta Total";
            this.y5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(62.87492F, 10.00001F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(238.2706F, 70.00002F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(238.2706F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // InformeCuadreVentas
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1,
            this.PageFooter,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 200, 23);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
