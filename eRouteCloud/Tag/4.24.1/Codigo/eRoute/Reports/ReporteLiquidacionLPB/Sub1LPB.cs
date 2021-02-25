using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for Sub1BRA
/// </summary>
public class Sub1LPB : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    private XRLine xrLine1;
    private XRLabel xrLabel1;
    private XRLine xrLine2;
    private XRLabel xrLabel32;
    private XRLabel xrLabel31;
    private XRLabel xrLabel30;
    private XRLabel xrLabel29;
    private XRLabel xrLabel28;
    private XRLabel xrLabel27;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    public XRLabel t1;
    public XRLabel t2;
    public XRLabel t3;
    public XRLabel t4;
    public XRLabel t5;
    public XRLabel t6;
    public XRLabel t7;
    public XRLabel t8;
    public XRLabel t9;
    public XRLabel t10;
    public XRLabel t11;
    public XRLabel t12;
    public XRLabel t13;
    public XRLabel t14;
    public XRLabel t15;
    public XRLabel t16;
    public XRLabel d18;
    public XRLabel d17;
    public XRLabel d16;
    public XRLabel d15;
    public XRLabel d14;
    public XRLabel d13;
    public XRLabel d12;
    public XRLabel d11;
    public XRLabel d10;
    public XRLabel d9;
    public XRLabel d8;
    public XRLabel d7;
    public XRLabel d6;
    public XRLabel d5;
    public XRLabel d4;
    public XRLabel d3;
    public XRLabel d2;
    public XRLabel d1;
    private XRLabel xrLabel34;
    public XRLabel nombrepro;
    private GroupFooterBand GroupFooter1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Sub1LPB()
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
            this.d1 = new DevExpress.XtraReports.UI.XRLabel();
            this.nombrepro = new DevExpress.XtraReports.UI.XRLabel();
            this.d2 = new DevExpress.XtraReports.UI.XRLabel();
            this.d3 = new DevExpress.XtraReports.UI.XRLabel();
            this.d4 = new DevExpress.XtraReports.UI.XRLabel();
            this.d5 = new DevExpress.XtraReports.UI.XRLabel();
            this.d6 = new DevExpress.XtraReports.UI.XRLabel();
            this.d7 = new DevExpress.XtraReports.UI.XRLabel();
            this.d8 = new DevExpress.XtraReports.UI.XRLabel();
            this.d9 = new DevExpress.XtraReports.UI.XRLabel();
            this.d10 = new DevExpress.XtraReports.UI.XRLabel();
            this.d11 = new DevExpress.XtraReports.UI.XRLabel();
            this.d12 = new DevExpress.XtraReports.UI.XRLabel();
            this.d13 = new DevExpress.XtraReports.UI.XRLabel();
            this.d14 = new DevExpress.XtraReports.UI.XRLabel();
            this.d15 = new DevExpress.XtraReports.UI.XRLabel();
            this.d16 = new DevExpress.XtraReports.UI.XRLabel();
            this.d17 = new DevExpress.XtraReports.UI.XRLabel();
            this.d18 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.t1 = new DevExpress.XtraReports.UI.XRLabel();
            this.t2 = new DevExpress.XtraReports.UI.XRLabel();
            this.t3 = new DevExpress.XtraReports.UI.XRLabel();
            this.t4 = new DevExpress.XtraReports.UI.XRLabel();
            this.t5 = new DevExpress.XtraReports.UI.XRLabel();
            this.t6 = new DevExpress.XtraReports.UI.XRLabel();
            this.t7 = new DevExpress.XtraReports.UI.XRLabel();
            this.t8 = new DevExpress.XtraReports.UI.XRLabel();
            this.t9 = new DevExpress.XtraReports.UI.XRLabel();
            this.t10 = new DevExpress.XtraReports.UI.XRLabel();
            this.t11 = new DevExpress.XtraReports.UI.XRLabel();
            this.t12 = new DevExpress.XtraReports.UI.XRLabel();
            this.t13 = new DevExpress.XtraReports.UI.XRLabel();
            this.t14 = new DevExpress.XtraReports.UI.XRLabel();
            this.t15 = new DevExpress.XtraReports.UI.XRLabel();
            this.t16 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.d1,
            this.nombrepro,
            this.d2,
            this.d3,
            this.d4,
            this.d5,
            this.d6,
            this.d7,
            this.d8,
            this.d9,
            this.d10,
            this.d11,
            this.d12,
            this.d13,
            this.d14,
            this.d15,
            this.d16,
            this.d17,
            this.d18});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 22.99999F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // d1
            // 
            this.d1.Dpi = 100F;
            this.d1.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d1.LocationFloat = new DevExpress.Utils.PointFloat(144.218F, 0F);
            this.d1.Name = "d1";
            this.d1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d1.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d1.StylePriority.UseFont = false;
            this.d1.StylePriority.UseTextAlignment = false;
            this.d1.Text = "d1";
            this.d1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // nombrepro
            // 
            this.nombrepro.Dpi = 100F;
            this.nombrepro.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.nombrepro.LocationFloat = new DevExpress.Utils.PointFloat(10.62501F, 0F);
            this.nombrepro.Name = "nombrepro";
            this.nombrepro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nombrepro.SizeF = new System.Drawing.SizeF(122.7778F, 22.99999F);
            this.nombrepro.StylePriority.UseFont = false;
            this.nombrepro.Text = "nombrepro";
            // 
            // d2
            // 
            this.d2.Dpi = 100F;
            this.d2.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d2.LocationFloat = new DevExpress.Utils.PointFloat(185.1451F, 0F);
            this.d2.Name = "d2";
            this.d2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d2.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d2.StylePriority.UseFont = false;
            this.d2.StylePriority.UseTextAlignment = false;
            this.d2.Text = "d2";
            this.d2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d3
            // 
            this.d3.Dpi = 100F;
            this.d3.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d3.LocationFloat = new DevExpress.Utils.PointFloat(211.4584F, 0F);
            this.d3.Name = "d3";
            this.d3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d3.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d3.StylePriority.UseFont = false;
            this.d3.StylePriority.UseTextAlignment = false;
            this.d3.Text = "d3";
            this.d3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d4
            // 
            this.d4.Dpi = 100F;
            this.d4.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d4.LocationFloat = new DevExpress.Utils.PointFloat(264.6042F, 0F);
            this.d4.Name = "d4";
            this.d4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d4.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d4.StylePriority.UseFont = false;
            this.d4.StylePriority.UseTextAlignment = false;
            this.d4.Text = "d4";
            this.d4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d5
            // 
            this.d5.Dpi = 100F;
            this.d5.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d5.LocationFloat = new DevExpress.Utils.PointFloat(289.9479F, 0F);
            this.d5.Name = "d5";
            this.d5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d5.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d5.StylePriority.UseFont = false;
            this.d5.StylePriority.UseTextAlignment = false;
            this.d5.Text = "d5";
            this.d5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d6
            // 
            this.d6.Dpi = 100F;
            this.d6.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d6.LocationFloat = new DevExpress.Utils.PointFloat(336.5833F, 0F);
            this.d6.Name = "d6";
            this.d6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d6.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d6.StylePriority.UseFont = false;
            this.d6.StylePriority.UseTextAlignment = false;
            this.d6.Text = "d6";
            this.d6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d7
            // 
            this.d7.Dpi = 100F;
            this.d7.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d7.LocationFloat = new DevExpress.Utils.PointFloat(361.9791F, 0F);
            this.d7.Name = "d7";
            this.d7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d7.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d7.StylePriority.UseFont = false;
            this.d7.StylePriority.UseTextAlignment = false;
            this.d7.Text = "d7";
            this.d7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d8
            // 
            this.d8.Dpi = 100F;
            this.d8.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d8.LocationFloat = new DevExpress.Utils.PointFloat(400.5102F, 0F);
            this.d8.Name = "d8";
            this.d8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d8.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d8.StylePriority.UseFont = false;
            this.d8.StylePriority.UseTextAlignment = false;
            this.d8.Text = "d8";
            this.d8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d9
            // 
            this.d9.Dpi = 100F;
            this.d9.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d9.LocationFloat = new DevExpress.Utils.PointFloat(441.7483F, 0F);
            this.d9.Name = "d9";
            this.d9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d9.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d9.StylePriority.UseFont = false;
            this.d9.StylePriority.UseTextAlignment = false;
            this.d9.Text = "d9";
            this.d9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d10
            // 
            this.d10.Dpi = 100F;
            this.d10.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d10.LocationFloat = new DevExpress.Utils.PointFloat(494.2431F, 0F);
            this.d10.Name = "d10";
            this.d10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d10.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d10.StylePriority.UseFont = false;
            this.d10.StylePriority.UseTextAlignment = false;
            this.d10.Text = "d10";
            this.d10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d11
            // 
            this.d11.Dpi = 100F;
            this.d11.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d11.LocationFloat = new DevExpress.Utils.PointFloat(530.9107F, 0F);
            this.d11.Name = "d11";
            this.d11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d11.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d11.StylePriority.UseFont = false;
            this.d11.StylePriority.UseTextAlignment = false;
            this.d11.Text = "d11";
            this.d11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d12
            // 
            this.d12.Dpi = 100F;
            this.d12.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d12.LocationFloat = new DevExpress.Utils.PointFloat(578.8481F, 0F);
            this.d12.Name = "d12";
            this.d12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d12.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d12.StylePriority.UseFont = false;
            this.d12.StylePriority.UseTextAlignment = false;
            this.d12.Text = "d12";
            this.d12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d13
            // 
            this.d13.Dpi = 100F;
            this.d13.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d13.LocationFloat = new DevExpress.Utils.PointFloat(613.7242F, 0F);
            this.d13.Name = "d13";
            this.d13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d13.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d13.StylePriority.UseFont = false;
            this.d13.StylePriority.UseTextAlignment = false;
            this.d13.Text = "d13";
            this.d13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d14
            // 
            this.d14.Dpi = 100F;
            this.d14.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d14.LocationFloat = new DevExpress.Utils.PointFloat(647.3387F, 0F);
            this.d14.Name = "d14";
            this.d14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d14.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d14.StylePriority.UseFont = false;
            this.d14.StylePriority.UseTextAlignment = false;
            this.d14.Text = "d14";
            this.d14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d15
            // 
            this.d15.Dpi = 100F;
            this.d15.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d15.LocationFloat = new DevExpress.Utils.PointFloat(688.0905F, 0F);
            this.d15.Name = "d15";
            this.d15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d15.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d15.StylePriority.UseFont = false;
            this.d15.StylePriority.UseTextAlignment = false;
            this.d15.Text = "d15";
            this.d15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d16
            // 
            this.d16.Dpi = 100F;
            this.d16.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d16.LocationFloat = new DevExpress.Utils.PointFloat(721.7051F, 0F);
            this.d16.Name = "d16";
            this.d16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d16.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d16.StylePriority.UseFont = false;
            this.d16.StylePriority.UseTextAlignment = false;
            this.d16.Text = "d16";
            this.d16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d17
            // 
            this.d17.Dpi = 100F;
            this.d17.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d17.LocationFloat = new DevExpress.Utils.PointFloat(761.3276F, 0F);
            this.d17.Name = "d17";
            this.d17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d17.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.d17.StylePriority.UseFont = false;
            this.d17.StylePriority.UseTextAlignment = false;
            this.d17.Text = "d17";
            this.d17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // d18
            // 
            this.d18.Dpi = 100F;
            this.d18.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.d18.LocationFloat = new DevExpress.Utils.PointFloat(805.6979F, 0F);
            this.d18.Name = "d18";
            this.d18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.d18.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.d18.StylePriority.UseFont = false;
            this.d18.StylePriority.UseTextAlignment = false;
            this.d18.Text = "d18";
            this.d18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.BottomMargin.HeightF = 4.830042F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel32,
            this.xrLabel31,
            this.xrLabel30,
            this.xrLabel29,
            this.xrLabel28,
            this.xrLabel27,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLine2,
            this.xrLine1});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 89.35947F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(805.6978F, 66.79688F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(22.21252F, 16.48955F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "KG";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(721.7052F, 66.79683F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "KG";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(759.0991F, 66.79687F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "PZA";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(688.0908F, 66.79683F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "PZA";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(647.3387F, 66.79695F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "KG";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(613.7242F, 66.79695F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "PZA";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(530.9107F, 66.79683F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "PZA";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(578.8481F, 66.79695F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "KG";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(494.2431F, 66.79695F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "KG";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(441.7483F, 66.79692F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "PZA";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(362.0989F, 66.79686F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "PZA";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(400.2707F, 66.79686F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "KG";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(336.7031F, 66.79683F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "KG";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(290.0677F, 66.79683F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "PZA";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(211.5782F, 66.79692F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "PZA";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(264.724F, 66.79692F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "KG";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(185.0253F, 66.79693F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "KG";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(143.9783F, 66.79693F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "PZA";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(759.0991F, 37.08343F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(68.81122F, 29.71357F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Inventario\r\nFinal";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(688.0908F, 37.08329F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(55.72906F, 29.71353F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Venta\r\nCredito";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(613.7242F, 37.08335F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(55.72913F, 29.71357F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Venta\r\nContado";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(530.9107F, 37.08339F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(70.052F, 29.71357F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Devolucion\r\nAlmacen";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(441.7483F, 43.79696F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(74.60938F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Degustacion";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(362.3384F, 37.08343F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(60.28641F, 29.71353F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Cambios\r\nSalida";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(289.9479F, 37.08327F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(68.74997F, 29.71355F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Cambios\r\nEntrada";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(211.4584F, 37.08339F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(75.26039F, 29.71353F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Devolucion\r\nCliente";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(144.2179F, 43.79692F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(63.04173F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Cargas";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(37.39581F, 43.79689F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(81.77087F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Producto";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 3.666674F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(216.6667F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "VENTAS POR PRODUCTO";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(10.01227F, 72.86987F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(817.8981F, 10.41666F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(10.11029F, 26.66667F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(817.8F, 10.41667F);
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(93.50689F, 0F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(39.89588F, 12.58333F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.Text = "Totales";
            // 
            // t1
            // 
            this.t1.Dpi = 100F;
            this.t1.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t1.LocationFloat = new DevExpress.Utils.PointFloat(144.2179F, 0F);
            this.t1.Name = "t1";
            this.t1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t1.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t1.StylePriority.UseFont = false;
            this.t1.StylePriority.UseTextAlignment = false;
            this.t1.Text = "t1";
            this.t1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t2
            // 
            this.t2.Dpi = 100F;
            this.t2.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t2.LocationFloat = new DevExpress.Utils.PointFloat(185.2649F, 0F);
            this.t2.Name = "t2";
            this.t2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t2.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t2.StylePriority.UseFont = false;
            this.t2.StylePriority.UseTextAlignment = false;
            this.t2.Text = "t2";
            this.t2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t3
            // 
            this.t3.Dpi = 100F;
            this.t3.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t3.LocationFloat = new DevExpress.Utils.PointFloat(211.8177F, 0F);
            this.t3.Name = "t3";
            this.t3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t3.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t3.StylePriority.UseFont = false;
            this.t3.StylePriority.UseTextAlignment = false;
            this.t3.Text = "t3";
            this.t3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t4
            // 
            this.t4.Dpi = 100F;
            this.t4.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t4.LocationFloat = new DevExpress.Utils.PointFloat(264.9636F, 0F);
            this.t4.Name = "t4";
            this.t4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t4.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t4.StylePriority.UseFont = false;
            this.t4.StylePriority.UseTextAlignment = false;
            this.t4.Text = "t4";
            this.t4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t5
            // 
            this.t5.Dpi = 100F;
            this.t5.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t5.LocationFloat = new DevExpress.Utils.PointFloat(290.3073F, 0F);
            this.t5.Name = "t5";
            this.t5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t5.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t5.StylePriority.UseFont = false;
            this.t5.StylePriority.UseTextAlignment = false;
            this.t5.Text = "t5";
            this.t5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t6
            // 
            this.t6.Dpi = 100F;
            this.t6.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t6.LocationFloat = new DevExpress.Utils.PointFloat(336.8229F, 0F);
            this.t6.Name = "t6";
            this.t6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t6.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t6.StylePriority.UseFont = false;
            this.t6.StylePriority.UseTextAlignment = false;
            this.t6.Text = "t6";
            this.t6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t7
            // 
            this.t7.Dpi = 100F;
            this.t7.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t7.LocationFloat = new DevExpress.Utils.PointFloat(362.3384F, 0F);
            this.t7.Name = "t7";
            this.t7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t7.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t7.StylePriority.UseFont = false;
            this.t7.StylePriority.UseTextAlignment = false;
            this.t7.Text = "t7";
            this.t7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t8
            // 
            this.t8.Dpi = 100F;
            this.t8.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t8.LocationFloat = new DevExpress.Utils.PointFloat(400.3906F, 0F);
            this.t8.Name = "t8";
            this.t8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t8.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t8.StylePriority.UseFont = false;
            this.t8.StylePriority.UseTextAlignment = false;
            this.t8.Text = "t8";
            this.t8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t9
            // 
            this.t9.Dpi = 100F;
            this.t9.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t9.LocationFloat = new DevExpress.Utils.PointFloat(441.7483F, 0F);
            this.t9.Name = "t9";
            this.t9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t9.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t9.StylePriority.UseFont = false;
            this.t9.StylePriority.UseTextAlignment = false;
            this.t9.Text = "t9";
            this.t9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t10
            // 
            this.t10.Dpi = 100F;
            this.t10.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t10.LocationFloat = new DevExpress.Utils.PointFloat(494.2431F, 0F);
            this.t10.Name = "t10";
            this.t10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t10.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t10.StylePriority.UseFont = false;
            this.t10.StylePriority.UseTextAlignment = false;
            this.t10.Text = "t10";
            this.t10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t11
            // 
            this.t11.Dpi = 100F;
            this.t11.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t11.LocationFloat = new DevExpress.Utils.PointFloat(530.9107F, 0F);
            this.t11.Name = "t11";
            this.t11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t11.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t11.StylePriority.UseFont = false;
            this.t11.StylePriority.UseTextAlignment = false;
            this.t11.Text = "t11";
            this.t11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t12
            // 
            this.t12.Dpi = 100F;
            this.t12.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t12.LocationFloat = new DevExpress.Utils.PointFloat(578.8481F, 0F);
            this.t12.Name = "t12";
            this.t12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t12.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t12.StylePriority.UseFont = false;
            this.t12.StylePriority.UseTextAlignment = false;
            this.t12.Text = "t12";
            this.t12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t13
            // 
            this.t13.Dpi = 100F;
            this.t13.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t13.LocationFloat = new DevExpress.Utils.PointFloat(613.7242F, 0F);
            this.t13.Name = "t13";
            this.t13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t13.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t13.StylePriority.UseFont = false;
            this.t13.StylePriority.UseTextAlignment = false;
            this.t13.Text = "t13";
            this.t13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t14
            // 
            this.t14.Dpi = 100F;
            this.t14.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t14.LocationFloat = new DevExpress.Utils.PointFloat(647.3387F, 0F);
            this.t14.Name = "t14";
            this.t14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t14.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t14.StylePriority.UseFont = false;
            this.t14.StylePriority.UseTextAlignment = false;
            this.t14.Text = "t14";
            this.t14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t15
            // 
            this.t15.Dpi = 100F;
            this.t15.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t15.LocationFloat = new DevExpress.Utils.PointFloat(688.0906F, 0F);
            this.t15.Name = "t15";
            this.t15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t15.SizeF = new System.Drawing.SizeF(27.0833F, 16.48959F);
            this.t15.StylePriority.UseFont = false;
            this.t15.StylePriority.UseTextAlignment = false;
            this.t15.Text = "t15";
            this.t15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // t16
            // 
            this.t16.Dpi = 100F;
            this.t16.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold);
            this.t16.LocationFloat = new DevExpress.Utils.PointFloat(721.7052F, 0F);
            this.t16.Name = "t16";
            this.t16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t16.SizeF = new System.Drawing.SizeF(22.11456F, 16.48959F);
            this.t16.StylePriority.UseFont = false;
            this.t16.StylePriority.UseTextAlignment = false;
            this.t16.Text = "t16";
            this.t16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel34,
            this.t16,
            this.t15,
            this.t14,
            this.t13,
            this.t12,
            this.t11,
            this.t10,
            this.t9,
            this.t8,
            this.t7,
            this.t6,
            this.t5,
            this.t4,
            this.t3,
            this.t2,
            this.t1});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 917.7944F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // Sub1LPB
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(5, 17, 49, 5);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
