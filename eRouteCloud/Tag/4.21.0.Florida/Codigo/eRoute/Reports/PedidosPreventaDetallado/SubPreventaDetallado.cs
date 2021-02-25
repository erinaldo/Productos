using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for report_Principal
/// </summary>
public class SubPreventaDetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel sub5;
    public XRLabel sub3;
    public XRLabel sub4;
    public XRLabel sub2;
    public XRLabel sub1;
    private GroupFooterBand GroupFooter1;
    public XRLabel gtupi;
    public XRLabel gtci;
    public XRLabel gtup;
    public XRLabel gtc;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private ReportHeaderBand ReportHeader;
    private XRLine xrLine4;
    private XRLabel xrLabel52;
    private XRLabel xrLabel49;
    private XRLabel xrLabel46;
    private XRLabel xrLabel45;
    private XRLine xrLine3;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubPreventaDetallado()
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
            this.sub5 = new DevExpress.XtraReports.UI.XRLabel();
            this.sub3 = new DevExpress.XtraReports.UI.XRLabel();
            this.sub4 = new DevExpress.XtraReports.UI.XRLabel();
            this.sub2 = new DevExpress.XtraReports.UI.XRLabel();
            this.sub1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.gtupi = new DevExpress.XtraReports.UI.XRLabel();
            this.gtci = new DevExpress.XtraReports.UI.XRLabel();
            this.gtup = new DevExpress.XtraReports.UI.XRLabel();
            this.gtc = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub5,
            this.sub3,
            this.sub4,
            this.sub2,
            this.sub1});
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.HeightF = 30F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.SnapLinePadding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 10, 10, 254F);
            this.Detail.StylePriority.UseBorderDashStyle = false;
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sub5
            // 
            this.sub5.Dpi = 254F;
            this.sub5.Font = new System.Drawing.Font("Arial", 9F);
            this.sub5.LocationFloat = new DevExpress.Utils.PointFloat(2158.443F, 0F);
            this.sub5.Name = "sub5";
            this.sub5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.sub5.SizeF = new System.Drawing.SizeF(449.2104F, 30F);
            this.sub5.StylePriority.UseFont = false;
            this.sub5.StylePriority.UsePadding = false;
            this.sub5.StylePriority.UseTextAlignment = false;
            this.sub5.Text = "Importe";
            this.sub5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // sub3
            // 
            this.sub3.Dpi = 254F;
            this.sub3.Font = new System.Drawing.Font("Arial", 9F);
            this.sub3.LocationFloat = new DevExpress.Utils.PointFloat(1410.372F, 0F);
            this.sub3.Name = "sub3";
            this.sub3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.sub3.SizeF = new System.Drawing.SizeF(370.6542F, 30F);
            this.sub3.StylePriority.UseFont = false;
            this.sub3.StylePriority.UsePadding = false;
            this.sub3.StylePriority.UseTextAlignment = false;
            this.sub3.Text = "Unidad de Medida";
            this.sub3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // sub4
            // 
            this.sub4.Dpi = 254F;
            this.sub4.Font = new System.Drawing.Font("Arial", 9F);
            this.sub4.LocationFloat = new DevExpress.Utils.PointFloat(1781.031F, 0F);
            this.sub4.Name = "sub4";
            this.sub4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.sub4.SizeF = new System.Drawing.SizeF(375.6703F, 30F);
            this.sub4.StylePriority.UseFont = false;
            this.sub4.StylePriority.UsePadding = false;
            this.sub4.StylePriority.UseTextAlignment = false;
            this.sub4.Text = "Total Unidades";
            this.sub4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // sub2
            // 
            this.sub2.CanGrow = false;
            this.sub2.Dpi = 254F;
            this.sub2.Font = new System.Drawing.Font("Arial", 9F);
            this.sub2.LocationFloat = new DevExpress.Utils.PointFloat(196.627F, 0F);
            this.sub2.Name = "sub2";
            this.sub2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.sub2.SizeF = new System.Drawing.SizeF(1213.745F, 30F);
            this.sub2.StylePriority.UseFont = false;
            this.sub2.StylePriority.UsePadding = false;
            this.sub2.StylePriority.UseTextAlignment = false;
            this.sub2.Text = "Producto";
            this.sub2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // sub1
            // 
            this.sub1.Dpi = 254F;
            this.sub1.Font = new System.Drawing.Font("Arial", 9F);
            this.sub1.LocationFloat = new DevExpress.Utils.PointFloat(2.323935F, 0F);
            this.sub1.Name = "sub1";
            this.sub1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.sub1.SizeF = new System.Drawing.SizeF(194.3031F, 30F);
            this.sub1.StylePriority.UseFont = false;
            this.sub1.StylePriority.UsePadding = false;
            this.sub1.StylePriority.UseTextAlignment = false;
            this.sub1.Text = "SKU";
            this.sub1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.gtupi,
            this.gtci,
            this.gtup,
            this.gtc,
            this.xrLabel2,
            this.xrLabel1});
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.HeightF = 187.56F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // gtupi
            // 
            this.gtupi.Dpi = 254F;
            this.gtupi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gtupi.LocationFloat = new DevExpress.Utils.PointFloat(2230.833F, 129.14F);
            this.gtupi.Name = "gtupi";
            this.gtupi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.gtupi.SizeF = new System.Drawing.SizeF(254F, 58.42F);
            this.gtupi.StylePriority.UseFont = false;
            this.gtupi.Text = "gtupi";
            // 
            // gtci
            // 
            this.gtci.Dpi = 254F;
            this.gtci.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gtci.LocationFloat = new DevExpress.Utils.PointFloat(2229.775F, 50.40001F);
            this.gtci.Name = "gtci";
            this.gtci.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.gtci.SizeF = new System.Drawing.SizeF(254F, 58.42F);
            this.gtci.StylePriority.UseFont = false;
            this.gtci.Text = "gtci";
            // 
            // gtup
            // 
            this.gtup.Dpi = 254F;
            this.gtup.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gtup.LocationFloat = new DevExpress.Utils.PointFloat(1845.07F, 129.14F);
            this.gtup.Name = "gtup";
            this.gtup.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.gtup.SizeF = new System.Drawing.SizeF(253.9999F, 58.42F);
            this.gtup.StylePriority.UseFont = false;
            this.gtup.Text = "gtup";
            // 
            // gtc
            // 
            this.gtc.Dpi = 254F;
            this.gtc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gtc.LocationFloat = new DevExpress.Utils.PointFloat(1838.719F, 50.40001F);
            this.gtc.Name = "gtc";
            this.gtc.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.gtc.SizeF = new System.Drawing.SizeF(254F, 58.42F);
            this.gtc.StylePriority.UseFont = false;
            this.gtc.Text = "gtc";
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(597.4267F, 106.28F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(1197.426F, 81.28F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "GRAN TOTAL EN OTRAS UNIDADES POR PRODUCTO";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(597.4267F, 24.99999F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(1197.426F, 81.28F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "GRAN TOTAL EN CAJAS POR PRODUCTO";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.xrLabel52,
            this.xrLabel49,
            this.xrLabel46,
            this.xrLabel45,
            this.xrLine3,
            this.xrLabel43,
            this.xrLabel44});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 182.657F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 254F;
            this.xrLine4.LineWidth = 4;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(8.518977F, 167.64F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(2602.552F, 15.01692F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Dpi = 254F;
            this.xrLabel52.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(2159.501F, 86.35992F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(449.21F, 81.28F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UsePadding = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "Importe";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Dpi = 254F;
            this.xrLabel49.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(1410.368F, 86.3599F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(373.4475F, 81.27999F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UsePadding = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "Unidad de Medida";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 254F;
            this.xrLabel46.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(1783.831F, 86.35992F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(375.6702F, 81.28F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UsePadding = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "Total Unidades";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel45
            // 
            this.xrLabel45.CanGrow = false;
            this.xrLabel45.Dpi = 254F;
            this.xrLabel45.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(196.627F, 86.36001F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(1213.741F, 81.27999F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UsePadding = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            this.xrLabel45.Text = "Producto";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 254F;
            this.xrLine3.LineWidth = 4;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(5.128679F, 71.34307F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(2602.525F, 15.01683F);
            this.xrLine3.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Dpi = 254F;
            this.xrLabel43.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(5.124904F, 86.3599F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(191.5021F, 81.28001F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UsePadding = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "SKU";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel44
            // 
            this.xrLabel44.Dpi = 254F;
            this.xrLabel44.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(770.9959F, 0F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(1108.604F, 58.42F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.Text = "PEDIDOS PREVENTA TOTAL POR PRODUCTO";
            // 
            // SubPreventaDetallado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.ReportHeader});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.HorizontalContentSplitting = DevExpress.XtraPrinting.HorizontalContentSplitting.Smart;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(89, 89, 10, 0);
            this.PageHeight = 2159;
            this.PageWidth = 2794;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "16.1";
            this.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
