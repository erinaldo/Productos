using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesNoVisitados
/// </summary>
public class ReporteClientesNoVisitados : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel fecha;
    private XRLabel xrLabel2;
    private XRLabel xrLabel8;
    public XRLabel fechaActual1;
    private GroupFooterBand GroupFooter1;
    public XRLabel xl1;
    public XRLabel xl2;
    public XRLabel xl3;
    public XRLabel xl4;
    public XRLabel xl5;
    public XRLabel xl6;
    public XRLabel xl7;
    public XRLabel xl8;
    public XRLabel xl9;
    public XRLabel xl10;
    public XRLabel xl11;
    public XRLabel xl13;
    public XRLabel xl14;
    public XRLabel xl15;
    public XRLabel xl16;
    public XRLabel xl17;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel17;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private XRLabel xrLabel3;
    private XRLabel xrLabel18;
    private XRLabel xrLabel15;
    private XRLabel xrLabel19;
    public XRLabel xl12;
    private XRLabel xrLabel20;
    private XRLine xrLine1;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteClientesNoVisitados()
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
            this.xl12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xl16 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.fechaActual1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xl12,
            this.xl15,
            this.xl1,
            this.xl2,
            this.xl3,
            this.xl4,
            this.xl5,
            this.xl6,
            this.xl7,
            this.xl8,
            this.xl9,
            this.xl10,
            this.xl11,
            this.xl13,
            this.xl14,
            this.xl17,
            this.xl16});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13.74695F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xl12
            // 
            this.xl12.Dpi = 100F;
            this.xl12.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl12.LocationFloat = new DevExpress.Utils.PointFloat(733.0421F, 0F);
            this.xl12.Name = "xl12";
            this.xl12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl12.SizeF = new System.Drawing.SizeF(76.05591F, 13.20074F);
            this.xl12.StylePriority.UseFont = false;
            this.xl12.Text = "xl12";
            // 
            // xl15
            // 
            this.xl15.Dpi = 100F;
            this.xl15.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl15.LocationFloat = new DevExpress.Utils.PointFloat(950.5901F, 0F);
            this.xl15.Name = "xl15";
            this.xl15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl15.SizeF = new System.Drawing.SizeF(42.52118F, 13.20073F);
            this.xl15.StylePriority.UseFont = false;
            this.xl15.Text = "xl15";
            // 
            // xl1
            // 
            this.xl1.Dpi = 100F;
            this.xl1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl1.LocationFloat = new DevExpress.Utils.PointFloat(0.5775023F, 0F);
            this.xl1.Name = "xl1";
            this.xl1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl1.SizeF = new System.Drawing.SizeF(90.48482F, 13.20073F);
            this.xl1.StylePriority.UseFont = false;
            this.xl1.Text = "xl1";
            // 
            // xl2
            // 
            this.xl2.Dpi = 100F;
            this.xl2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl2.LocationFloat = new DevExpress.Utils.PointFloat(91.31997F, 0F);
            this.xl2.Name = "xl2";
            this.xl2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl2.SizeF = new System.Drawing.SizeF(83.18011F, 13.20074F);
            this.xl2.StylePriority.UseFont = false;
            this.xl2.Text = "xl2";
            // 
            // xl3
            // 
            this.xl3.Dpi = 100F;
            this.xl3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl3.LocationFloat = new DevExpress.Utils.PointFloat(174.5001F, 0F);
            this.xl3.Name = "xl3";
            this.xl3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl3.SizeF = new System.Drawing.SizeF(59.13913F, 13.20074F);
            this.xl3.StylePriority.UseFont = false;
            this.xl3.Text = "xl3";
            // 
            // xl4
            // 
            this.xl4.Dpi = 100F;
            this.xl4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl4.LocationFloat = new DevExpress.Utils.PointFloat(233.6667F, 0F);
            this.xl4.Name = "xl4";
            this.xl4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl4.SizeF = new System.Drawing.SizeF(54.36185F, 13.20074F);
            this.xl4.StylePriority.UseFont = false;
            this.xl4.Text = "xl4";
            // 
            // xl5
            // 
            this.xl5.Dpi = 100F;
            this.xl5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl5.LocationFloat = new DevExpress.Utils.PointFloat(289.7084F, 0F);
            this.xl5.Name = "xl5";
            this.xl5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl5.SizeF = new System.Drawing.SizeF(73.51422F, 13.20074F);
            this.xl5.StylePriority.UseFont = false;
            this.xl5.Text = "xl5";
            // 
            // xl6
            // 
            this.xl6.Dpi = 100F;
            this.xl6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl6.LocationFloat = new DevExpress.Utils.PointFloat(365.5143F, 0F);
            this.xl6.Name = "xl6";
            this.xl6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl6.SizeF = new System.Drawing.SizeF(85.2084F, 13.20074F);
            this.xl6.StylePriority.UseFont = false;
            this.xl6.Text = "xl6";
            // 
            // xl7
            // 
            this.xl7.Dpi = 100F;
            this.xl7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl7.LocationFloat = new DevExpress.Utils.PointFloat(450.7227F, 0F);
            this.xl7.Name = "xl7";
            this.xl7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl7.SizeF = new System.Drawing.SizeF(49.81918F, 13.20074F);
            this.xl7.StylePriority.UseFont = false;
            this.xl7.Text = "xl7";
            // 
            // xl8
            // 
            this.xl8.Dpi = 100F;
            this.xl8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl8.LocationFloat = new DevExpress.Utils.PointFloat(500.5419F, 0F);
            this.xl8.Name = "xl8";
            this.xl8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl8.SizeF = new System.Drawing.SizeF(54.97241F, 13.20074F);
            this.xl8.StylePriority.UseFont = false;
            this.xl8.Text = "xl8";
            // 
            // xl9
            // 
            this.xl9.Dpi = 100F;
            this.xl9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl9.LocationFloat = new DevExpress.Utils.PointFloat(555.5419F, 0F);
            this.xl9.Name = "xl9";
            this.xl9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl9.SizeF = new System.Drawing.SizeF(57.08331F, 13.20074F);
            this.xl9.StylePriority.UseFont = false;
            this.xl9.Text = "xl9";
            // 
            // xl10
            // 
            this.xl10.Dpi = 100F;
            this.xl10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl10.LocationFloat = new DevExpress.Utils.PointFloat(612.6252F, 0F);
            this.xl10.Name = "xl10";
            this.xl10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl10.SizeF = new System.Drawing.SizeF(52.88922F, 13.20074F);
            this.xl10.StylePriority.UseFont = false;
            this.xl10.Text = "xl10";
            // 
            // xl11
            // 
            this.xl11.Dpi = 100F;
            this.xl11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl11.LocationFloat = new DevExpress.Utils.PointFloat(665.5145F, 0F);
            this.xl11.Name = "xl11";
            this.xl11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl11.SizeF = new System.Drawing.SizeF(67.52759F, 13.20074F);
            this.xl11.StylePriority.UseFont = false;
            this.xl11.Text = "xl11";
            // 
            // xl13
            // 
            this.xl13.Dpi = 100F;
            this.xl13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl13.LocationFloat = new DevExpress.Utils.PointFloat(809.3483F, 0F);
            this.xl13.Name = "xl13";
            this.xl13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl13.SizeF = new System.Drawing.SizeF(62.89966F, 13.20074F);
            this.xl13.StylePriority.UseFont = false;
            this.xl13.Text = "xl13";
            // 
            // xl14
            // 
            this.xl14.Dpi = 100F;
            this.xl14.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl14.LocationFloat = new DevExpress.Utils.PointFloat(872.2756F, 0F);
            this.xl14.Name = "xl14";
            this.xl14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl14.SizeF = new System.Drawing.SizeF(78.28699F, 13.20074F);
            this.xl14.StylePriority.UseFont = false;
            this.xl14.Text = "xl14";
            // 
            // xl17
            // 
            this.xl17.Dpi = 100F;
            this.xl17.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl17.LocationFloat = new DevExpress.Utils.PointFloat(1036.09F, 0F);
            this.xl17.Name = "xl17";
            this.xl17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl17.SizeF = new System.Drawing.SizeF(48.60486F, 13.20074F);
            this.xl17.StylePriority.UseFont = false;
            this.xl17.Text = "xl17";
            // 
            // xl16
            // 
            this.xl16.Dpi = 100F;
            this.xl16.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xl16.LocationFloat = new DevExpress.Utils.PointFloat(993.4233F, 0F);
            this.xl16.Name = "xl16";
            this.xl16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xl16.SizeF = new System.Drawing.SizeF(42.35461F, 13.20074F);
            this.xl16.StylePriority.UseFont = false;
            this.xl16.Text = "xl16";
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.fecha,
            this.xrLabel2,
            this.xrLabel8,
            this.fechaActual1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 181.2916F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fecha
            // 
            this.fecha.Dpi = 100F;
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(536.931F, 146.7917F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(196.875F, 23F);
            this.fecha.Text = "paramFecha";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(426.5142F, 146.7917F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(110.4167F, 26.29163F);
            this.xrLabel2.Text = "Rango de Fecha";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(460.8892F, 120.5001F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(76.04172F, 26.29163F);
            this.xrLabel8.Text = "Fecha Actual";
            // 
            // fechaActual1
            // 
            this.fechaActual1.Dpi = 100F;
            this.fechaActual1.LocationFloat = new DevExpress.Utils.PointFloat(536.931F, 120.5001F);
            this.fechaActual1.Name = "fechaActual1";
            this.fechaActual1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechaActual1.SizeF = new System.Drawing.SizeF(196.875F, 23F);
            this.fechaActual1.Text = "fechaActual";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 18.75F;
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
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel20,
            this.xrLabel17,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel16,
            this.xrLabel3,
            this.xrLabel18,
            this.xrLabel15,
            this.xrLabel19});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 37.70588F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.6050463F, 32.18867F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1084.09F, 2.000019F);
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(733.0421F, 9.188677F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(76.08344F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Municipio";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(950.7778F, 9.188684F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(42.50006F, 23F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Referencia Domicilio";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(91.37507F, 9.188677F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(83.12501F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Deposito";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(174.5001F, 9.188677F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(59.16669F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Ruta";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(233.6667F, 9.188677F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(56.04167F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Clave";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(289.7084F, 9.188677F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(75.83337F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Razon Social";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(365.5419F, 9.188677F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(85.20831F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Id Electronico";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(450.7502F, 9.188677F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(49.79166F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Calle";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(500.5419F, 9.188677F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(54.99994F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Numero";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(555.5419F, 9.188677F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(57.08337F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Num Int";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(612.6252F, 9.188677F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(52.91675F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Colonia";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(665.542F, 9.188677F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(67.50006F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Localidad";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(872.2756F, 9.18866F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(77.70941F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Codigo Postal";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.188664F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(91.37505F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Fecha de Captura";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(993.2779F, 9.18866F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(42.5F, 23F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "CoordenadaX";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(809.3483F, 9.188677F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(62.92725F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Entidad";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(1035.778F, 9.188684F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(48.75031F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "CoordenadaY";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(189.0143F, 5.000003F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(365.5143F, 70.00002F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(365.5143F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReporteClientesNoVisitados
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(4, 7, 181, 19);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
