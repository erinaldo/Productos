using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for Sub7BRA
/// </summary>
public class Sub7LPB : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    private XRLabel xrLabel1;
    public XRLabel vcre6;
    public XRLabel vcre5;
    public XRLabel vcre4;
    public XRLabel vcre3;
    public XRLabel vcre2;
    public XRLabel vcre1;
    private XRLabel xrLabel34;
    public XRLabel vcretimporte;
    public XRLabel vcretkilos;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Sub7LPB()
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
            this.vcre6 = new DevExpress.XtraReports.UI.XRLabel();
            this.vcre5 = new DevExpress.XtraReports.UI.XRLabel();
            this.vcre4 = new DevExpress.XtraReports.UI.XRLabel();
            this.vcre3 = new DevExpress.XtraReports.UI.XRLabel();
            this.vcre2 = new DevExpress.XtraReports.UI.XRLabel();
            this.vcre1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.vcretimporte = new DevExpress.XtraReports.UI.XRLabel();
            this.vcretkilos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vcre6,
            this.vcre5,
            this.vcre4,
            this.vcre3,
            this.vcre2,
            this.vcre1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vcre6
            // 
            this.vcre6.Dpi = 100F;
            this.vcre6.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcre6.LocationFloat = new DevExpress.Utils.PointFloat(708.1249F, 0F);
            this.vcre6.Name = "vcre6";
            this.vcre6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcre6.SizeF = new System.Drawing.SizeF(103.6459F, 13F);
            this.vcre6.StylePriority.UseFont = false;
            this.vcre6.StylePriority.UseTextAlignment = false;
            this.vcre6.Text = "vcre6";
            this.vcre6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // vcre5
            // 
            this.vcre5.Dpi = 100F;
            this.vcre5.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcre5.LocationFloat = new DevExpress.Utils.PointFloat(586.4791F, 0F);
            this.vcre5.Name = "vcre5";
            this.vcre5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcre5.SizeF = new System.Drawing.SizeF(105.7291F, 13F);
            this.vcre5.StylePriority.UseFont = false;
            this.vcre5.StylePriority.UseTextAlignment = false;
            this.vcre5.Text = "vcre5";
            this.vcre5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // vcre4
            // 
            this.vcre4.Dpi = 100F;
            this.vcre4.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcre4.LocationFloat = new DevExpress.Utils.PointFloat(346.8126F, 0F);
            this.vcre4.Name = "vcre4";
            this.vcre4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcre4.SizeF = new System.Drawing.SizeF(239.2916F, 13F);
            this.vcre4.StylePriority.UseFont = false;
            this.vcre4.StylePriority.UseTextAlignment = false;
            this.vcre4.Text = "vcre4";
            this.vcre4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vcre3
            // 
            this.vcre3.Dpi = 100F;
            this.vcre3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcre3.LocationFloat = new DevExpress.Utils.PointFloat(223.1458F, 0F);
            this.vcre3.Name = "vcre3";
            this.vcre3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcre3.SizeF = new System.Drawing.SizeF(111.9792F, 13F);
            this.vcre3.StylePriority.UseFont = false;
            this.vcre3.StylePriority.UseTextAlignment = false;
            this.vcre3.Text = "vcre3";
            this.vcre3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // vcre2
            // 
            this.vcre2.Dpi = 100F;
            this.vcre2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcre2.LocationFloat = new DevExpress.Utils.PointFloat(125.8958F, 0F);
            this.vcre2.Name = "vcre2";
            this.vcre2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcre2.SizeF = new System.Drawing.SizeF(81.77087F, 13F);
            this.vcre2.StylePriority.UseFont = false;
            this.vcre2.StylePriority.UseTextAlignment = false;
            this.vcre2.Text = "vcre2";
            this.vcre2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vcre1
            // 
            this.vcre1.Dpi = 100F;
            this.vcre1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcre1.LocationFloat = new DevExpress.Utils.PointFloat(25.14585F, 0F);
            this.vcre1.Name = "vcre1";
            this.vcre1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcre1.SizeF = new System.Drawing.SizeF(81.77087F, 13F);
            this.vcre1.StylePriority.UseFont = false;
            this.vcre1.StylePriority.UseTextAlignment = false;
            this.vcre1.Text = "vcre1";
            this.vcre1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 11F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 7F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLine1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel1});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 87.70834F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.85416F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(216.6667F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Ventas Crédito";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel34,
            this.vcretimporte,
            this.vcretkilos});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 23.95833F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(411.5414F, 0F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(150.3125F, 12.58333F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.Text = "Total de Ventas de Crédito";
            // 
            // vcretimporte
            // 
            this.vcretimporte.Dpi = 100F;
            this.vcretimporte.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcretimporte.LocationFloat = new DevExpress.Utils.PointFloat(707.7499F, 0F);
            this.vcretimporte.Name = "vcretimporte";
            this.vcretimporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcretimporte.SizeF = new System.Drawing.SizeF(103.6459F, 23F);
            this.vcretimporte.StylePriority.UseFont = false;
            this.vcretimporte.StylePriority.UseTextAlignment = false;
            this.vcretimporte.Text = "vcretimporte";
            this.vcretimporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // vcretkilos
            // 
            this.vcretkilos.Dpi = 100F;
            this.vcretkilos.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.vcretkilos.LocationFloat = new DevExpress.Utils.PointFloat(586.1041F, 0F);
            this.vcretkilos.Name = "vcretkilos";
            this.vcretkilos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vcretkilos.SizeF = new System.Drawing.SizeF(105.7291F, 23F);
            this.vcretkilos.StylePriority.UseFont = false;
            this.vcretkilos.StylePriority.UseTextAlignment = false;
            this.vcretkilos.Text = "vcretkilos";
            this.vcretkilos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 41.45832F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(819.7917F, 10.41666F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 77.29168F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(819.7917F, 10.41666F);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(24.77082F, 51.87499F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(81.77087F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Venta";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(125.5208F, 51.87499F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(81.77087F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Factura";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(222.7708F, 51.87499F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(111.9792F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Fecha";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(346.8124F, 51.87499F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(239.2916F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Cliente";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(586.1041F, 51.87499F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(105.7291F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Kilos";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(707.7499F, 51.87499F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(103.6459F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Importe";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Sub7LPB
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(9, 19, 11, 7);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
