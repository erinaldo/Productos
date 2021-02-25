using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for SubliquidacionPorCodigo
/// </summary>
public class SubLiquidacionPorCodigoUnifoods : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel s1;
    public XRLabel s13;
    public XRLabel s12;
    public XRLabel s9;
    public XRLabel s10;
    public XRLabel s7;
    public XRLabel s8;
    public XRLabel s5;
    public XRLabel s6;
    public XRLabel s4;
    public XRLabel s3;
    public XRLabel s11;
    public XRLabel s2;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel14;
    public XRLabel t9;
    public XRLabel t1;
    public XRLabel t2;
    public XRLabel t4;
    public XRLabel t3;
    public XRLabel t6;
    public XRLabel t5;
    public XRLabel t8;
    public XRLabel t7;
    public XRLabel t10;
    public XRLabel t11;
    private XRLine xrLine1;
    private ReportHeaderBand ReportHeader;
    public XRLabel s16;
    public XRLabel s15;
    public XRLabel s14;
    public XRLabel t14;
    public XRLabel t13;
    public XRLabel t12;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell10;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubLiquidacionPorCodigoUnifoods()
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
            this.s16 = new DevExpress.XtraReports.UI.XRLabel();
            this.s15 = new DevExpress.XtraReports.UI.XRLabel();
            this.s14 = new DevExpress.XtraReports.UI.XRLabel();
            this.s1 = new DevExpress.XtraReports.UI.XRLabel();
            this.s13 = new DevExpress.XtraReports.UI.XRLabel();
            this.s12 = new DevExpress.XtraReports.UI.XRLabel();
            this.s9 = new DevExpress.XtraReports.UI.XRLabel();
            this.s10 = new DevExpress.XtraReports.UI.XRLabel();
            this.s7 = new DevExpress.XtraReports.UI.XRLabel();
            this.s8 = new DevExpress.XtraReports.UI.XRLabel();
            this.s5 = new DevExpress.XtraReports.UI.XRLabel();
            this.s6 = new DevExpress.XtraReports.UI.XRLabel();
            this.s4 = new DevExpress.XtraReports.UI.XRLabel();
            this.s3 = new DevExpress.XtraReports.UI.XRLabel();
            this.s11 = new DevExpress.XtraReports.UI.XRLabel();
            this.s2 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.t14 = new DevExpress.XtraReports.UI.XRLabel();
            this.t13 = new DevExpress.XtraReports.UI.XRLabel();
            this.t12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.t9 = new DevExpress.XtraReports.UI.XRLabel();
            this.t1 = new DevExpress.XtraReports.UI.XRLabel();
            this.t2 = new DevExpress.XtraReports.UI.XRLabel();
            this.t4 = new DevExpress.XtraReports.UI.XRLabel();
            this.t3 = new DevExpress.XtraReports.UI.XRLabel();
            this.t6 = new DevExpress.XtraReports.UI.XRLabel();
            this.t5 = new DevExpress.XtraReports.UI.XRLabel();
            this.t8 = new DevExpress.XtraReports.UI.XRLabel();
            this.t7 = new DevExpress.XtraReports.UI.XRLabel();
            this.t10 = new DevExpress.XtraReports.UI.XRLabel();
            this.t11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.s16,
            this.s15,
            this.s14,
            this.s1,
            this.s13,
            this.s12,
            this.s9,
            this.s10,
            this.s7,
            this.s8,
            this.s5,
            this.s6,
            this.s4,
            this.s3,
            this.s11,
            this.s2});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 37.45915F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // s16
            // 
            this.s16.Dpi = 100F;
            this.s16.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s16.LocationFloat = new DevExpress.Utils.PointFloat(756.3018F, 1.027775F);
            this.s16.Name = "s16";
            this.s16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s16.SizeF = new System.Drawing.SizeF(71.69818F, 28.20833F);
            this.s16.StylePriority.UseFont = false;
            this.s16.StylePriority.UseTextAlignment = false;
            this.s16.Text = "s16";
            this.s16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s15
            // 
            this.s15.Dpi = 100F;
            this.s15.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s15.LocationFloat = new DevExpress.Utils.PointFloat(698.8633F, 0F);
            this.s15.Name = "s15";
            this.s15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s15.SizeF = new System.Drawing.SizeF(57.43829F, 28.20833F);
            this.s15.StylePriority.UseFont = false;
            this.s15.StylePriority.UseTextAlignment = false;
            this.s15.Text = "s15";
            this.s15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s14
            // 
            this.s14.Dpi = 100F;
            this.s14.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s14.LocationFloat = new DevExpress.Utils.PointFloat(636.3721F, 0F);
            this.s14.Name = "s14";
            this.s14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s14.SizeF = new System.Drawing.SizeF(62.49121F, 28.20833F);
            this.s14.StylePriority.UseFont = false;
            this.s14.StylePriority.UseTextAlignment = false;
            this.s14.Text = "s14";
            this.s14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s1
            // 
            this.s1.Dpi = 100F;
            this.s1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.s1.Name = "s1";
            this.s1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s1.SizeF = new System.Drawing.SizeF(63.32837F, 28.20833F);
            this.s1.StylePriority.UseFont = false;
            this.s1.Text = "s1";
            // 
            // s13
            // 
            this.s13.Dpi = 100F;
            this.s13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s13.LocationFloat = new DevExpress.Utils.PointFloat(579.212F, 0F);
            this.s13.Name = "s13";
            this.s13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s13.SizeF = new System.Drawing.SizeF(57.1601F, 28.20833F);
            this.s13.StylePriority.UseFont = false;
            this.s13.StylePriority.UseTextAlignment = false;
            this.s13.Text = "s13";
            this.s13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s12
            // 
            this.s12.Dpi = 100F;
            this.s12.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s12.LocationFloat = new DevExpress.Utils.PointFloat(522.7924F, 0F);
            this.s12.Name = "s12";
            this.s12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s12.SizeF = new System.Drawing.SizeF(56.41956F, 28.20833F);
            this.s12.StylePriority.UseFont = false;
            this.s12.StylePriority.UseTextAlignment = false;
            this.s12.Text = "s12";
            this.s12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s9
            // 
            this.s9.Dpi = 100F;
            this.s9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s9.LocationFloat = new DevExpress.Utils.PointFloat(379.3572F, 0F);
            this.s9.Multiline = true;
            this.s9.Name = "s9";
            this.s9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s9.SizeF = new System.Drawing.SizeF(47.25052F, 28.20833F);
            this.s9.StylePriority.UseFont = false;
            this.s9.StylePriority.UseTextAlignment = false;
            this.s9.Text = "s9";
            this.s9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s10
            // 
            this.s10.Dpi = 100F;
            this.s10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s10.LocationFloat = new DevExpress.Utils.PointFloat(426.6077F, 0F);
            this.s10.Name = "s10";
            this.s10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s10.SizeF = new System.Drawing.SizeF(44.44647F, 28.20833F);
            this.s10.StylePriority.UseFont = false;
            this.s10.StylePriority.UseTextAlignment = false;
            this.s10.Text = "s10";
            this.s10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s7
            // 
            this.s7.Dpi = 100F;
            this.s7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s7.LocationFloat = new DevExpress.Utils.PointFloat(321.9067F, 0F);
            this.s7.Name = "s7";
            this.s7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s7.SizeF = new System.Drawing.SizeF(28.75522F, 28.20833F);
            this.s7.StylePriority.UseFont = false;
            this.s7.StylePriority.UseTextAlignment = false;
            this.s7.Text = "s7";
            this.s7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s8
            // 
            this.s8.Dpi = 100F;
            this.s8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s8.LocationFloat = new DevExpress.Utils.PointFloat(350.662F, 0F);
            this.s8.Name = "s8";
            this.s8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s8.SizeF = new System.Drawing.SizeF(28.69522F, 28.20833F);
            this.s8.StylePriority.UseFont = false;
            this.s8.StylePriority.UseTextAlignment = false;
            this.s8.Text = "s8";
            this.s8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s5
            // 
            this.s5.Dpi = 100F;
            this.s5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s5.LocationFloat = new DevExpress.Utils.PointFloat(270.3082F, 1.02778F);
            this.s5.Name = "s5";
            this.s5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s5.SizeF = new System.Drawing.SizeF(24.94516F, 28.20833F);
            this.s5.StylePriority.UseFont = false;
            this.s5.StylePriority.UseTextAlignment = false;
            this.s5.Text = "s5";
            this.s5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s6
            // 
            this.s6.Dpi = 100F;
            this.s6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s6.LocationFloat = new DevExpress.Utils.PointFloat(295.2534F, 0F);
            this.s6.Name = "s6";
            this.s6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s6.SizeF = new System.Drawing.SizeF(26.65332F, 28.20833F);
            this.s6.StylePriority.UseFont = false;
            this.s6.StylePriority.UseTextAlignment = false;
            this.s6.Text = "s6";
            this.s6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s4
            // 
            this.s4.Dpi = 100F;
            this.s4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s4.LocationFloat = new DevExpress.Utils.PointFloat(237.9707F, 0F);
            this.s4.Name = "s4";
            this.s4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s4.SizeF = new System.Drawing.SizeF(32.33743F, 28.20833F);
            this.s4.StylePriority.UseFont = false;
            this.s4.StylePriority.UseTextAlignment = false;
            this.s4.Text = "s4";
            this.s4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s3
            // 
            this.s3.Dpi = 100F;
            this.s3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s3.LocationFloat = new DevExpress.Utils.PointFloat(203.1022F, 0F);
            this.s3.Name = "s3";
            this.s3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s3.SizeF = new System.Drawing.SizeF(34.8685F, 28.20833F);
            this.s3.StylePriority.UseFont = false;
            this.s3.StylePriority.UseTextAlignment = false;
            this.s3.Text = "s3";
            this.s3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s11
            // 
            this.s11.Dpi = 100F;
            this.s11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s11.LocationFloat = new DevExpress.Utils.PointFloat(471.0542F, 0F);
            this.s11.Name = "s11";
            this.s11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s11.SizeF = new System.Drawing.SizeF(51.73825F, 28.20833F);
            this.s11.StylePriority.UseFont = false;
            this.s11.StylePriority.UseTextAlignment = false;
            this.s11.Text = "s11";
            this.s11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s2
            // 
            this.s2.Dpi = 100F;
            this.s2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s2.LocationFloat = new DevExpress.Utils.PointFloat(63.32837F, 0F);
            this.s2.Name = "s2";
            this.s2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s2.SizeF = new System.Drawing.SizeF(139.7739F, 28.20833F);
            this.s2.StylePriority.UseFont = false;
            this.s2.Text = "s2";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 3F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 6F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.t14,
            this.t13,
            this.t12,
            this.xrLabel14,
            this.t9,
            this.t1,
            this.t2,
            this.t4,
            this.t3,
            this.t6,
            this.t5,
            this.t8,
            this.t7,
            this.t10,
            this.t11,
            this.xrLine1});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 42.0972F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // t14
            // 
            this.t14.Dpi = 100F;
            this.t14.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t14.LocationFloat = new DevExpress.Utils.PointFloat(756.3017F, 0F);
            this.t14.Name = "t14";
            this.t14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t14.SizeF = new System.Drawing.SizeF(71.69818F, 28.20833F);
            this.t14.StylePriority.UseFont = false;
            this.t14.StylePriority.UseTextAlignment = false;
            this.t14.Text = "t14";
            this.t14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t13
            // 
            this.t13.Dpi = 100F;
            this.t13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t13.LocationFloat = new DevExpress.Utils.PointFloat(698.8634F, 0F);
            this.t13.Name = "t13";
            this.t13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t13.SizeF = new System.Drawing.SizeF(57.43823F, 28.20833F);
            this.t13.StylePriority.UseFont = false;
            this.t13.StylePriority.UseTextAlignment = false;
            this.t13.Text = "t13";
            this.t13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t12
            // 
            this.t12.Dpi = 100F;
            this.t12.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t12.LocationFloat = new DevExpress.Utils.PointFloat(636.3721F, 0F);
            this.t12.Name = "t12";
            this.t12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t12.SizeF = new System.Drawing.SizeF(62.49121F, 28.20833F);
            this.t12.StylePriority.UseFont = false;
            this.t12.StylePriority.UseTextAlignment = false;
            this.t12.Text = "t12";
            this.t12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(203.1022F, 28.20833F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "SUBTOTAL POR CODIGOS UNIFOODS";
            // 
            // t9
            // 
            this.t9.Dpi = 100F;
            this.t9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t9.LocationFloat = new DevExpress.Utils.PointFloat(471.0542F, 0F);
            this.t9.Name = "t9";
            this.t9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t9.SizeF = new System.Drawing.SizeF(51.73825F, 28.20833F);
            this.t9.StylePriority.UseFont = false;
            this.t9.StylePriority.UseTextAlignment = false;
            this.t9.Text = "t9";
            this.t9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t1
            // 
            this.t1.Dpi = 100F;
            this.t1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t1.LocationFloat = new DevExpress.Utils.PointFloat(203.1022F, 0F);
            this.t1.Name = "t1";
            this.t1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t1.SizeF = new System.Drawing.SizeF(34.8685F, 28.20833F);
            this.t1.StylePriority.UseFont = false;
            this.t1.StylePriority.UseTextAlignment = false;
            this.t1.Text = "t1";
            this.t1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t2
            // 
            this.t2.Dpi = 100F;
            this.t2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t2.LocationFloat = new DevExpress.Utils.PointFloat(237.9707F, 0F);
            this.t2.Name = "t2";
            this.t2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t2.SizeF = new System.Drawing.SizeF(32.33743F, 28.20833F);
            this.t2.StylePriority.UseFont = false;
            this.t2.StylePriority.UseTextAlignment = false;
            this.t2.Text = "t2";
            this.t2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t4
            // 
            this.t4.Dpi = 100F;
            this.t4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t4.LocationFloat = new DevExpress.Utils.PointFloat(295.2534F, 0F);
            this.t4.Name = "t4";
            this.t4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t4.SizeF = new System.Drawing.SizeF(26.65332F, 28.20833F);
            this.t4.StylePriority.UseFont = false;
            this.t4.StylePriority.UseTextAlignment = false;
            this.t4.Text = "t4";
            this.t4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t3
            // 
            this.t3.Dpi = 100F;
            this.t3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t3.LocationFloat = new DevExpress.Utils.PointFloat(270.3082F, 0F);
            this.t3.Name = "t3";
            this.t3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t3.SizeF = new System.Drawing.SizeF(24.94513F, 28.20833F);
            this.t3.StylePriority.UseFont = false;
            this.t3.StylePriority.UseTextAlignment = false;
            this.t3.Text = "t3";
            this.t3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t6
            // 
            this.t6.Dpi = 100F;
            this.t6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t6.LocationFloat = new DevExpress.Utils.PointFloat(350.662F, 0F);
            this.t6.Name = "t6";
            this.t6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t6.SizeF = new System.Drawing.SizeF(28.69522F, 28.20833F);
            this.t6.StylePriority.UseFont = false;
            this.t6.StylePriority.UseTextAlignment = false;
            this.t6.Text = "t6";
            this.t6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t5
            // 
            this.t5.Dpi = 100F;
            this.t5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t5.LocationFloat = new DevExpress.Utils.PointFloat(321.9067F, 0F);
            this.t5.Name = "t5";
            this.t5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t5.SizeF = new System.Drawing.SizeF(28.75522F, 28.20833F);
            this.t5.StylePriority.UseFont = false;
            this.t5.StylePriority.UseTextAlignment = false;
            this.t5.Text = "t5";
            this.t5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t8
            // 
            this.t8.Dpi = 100F;
            this.t8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t8.LocationFloat = new DevExpress.Utils.PointFloat(426.6078F, 0F);
            this.t8.Name = "t8";
            this.t8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t8.SizeF = new System.Drawing.SizeF(44.44641F, 28.20833F);
            this.t8.StylePriority.UseFont = false;
            this.t8.StylePriority.UseTextAlignment = false;
            this.t8.Text = "t8";
            this.t8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t7
            // 
            this.t7.Dpi = 100F;
            this.t7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t7.LocationFloat = new DevExpress.Utils.PointFloat(379.3572F, 0F);
            this.t7.Multiline = true;
            this.t7.Name = "t7";
            this.t7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t7.SizeF = new System.Drawing.SizeF(47.25061F, 28.20833F);
            this.t7.StylePriority.UseFont = false;
            this.t7.StylePriority.UseTextAlignment = false;
            this.t7.Text = "t7";
            this.t7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t10
            // 
            this.t10.Dpi = 100F;
            this.t10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t10.LocationFloat = new DevExpress.Utils.PointFloat(522.7924F, 0F);
            this.t10.Name = "t10";
            this.t10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t10.SizeF = new System.Drawing.SizeF(56.41956F, 28.20833F);
            this.t10.StylePriority.UseFont = false;
            this.t10.StylePriority.UseTextAlignment = false;
            this.t10.Text = "t10";
            this.t10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // t11
            // 
            this.t11.Dpi = 100F;
            this.t11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.t11.LocationFloat = new DevExpress.Utils.PointFloat(579.212F, 0F);
            this.t11.Name = "t11";
            this.t11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.t11.SizeF = new System.Drawing.SizeF(57.16016F, 28.20833F);
            this.t11.StylePriority.UseFont = false;
            this.t11.StylePriority.UseTextAlignment = false;
            this.t11.Text = "t11";
            this.t11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28.20832F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(822.2917F, 13.88888F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 61.62734F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Bookmark = "9";
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 100F;
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0.0001344925F, 5.95237F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(827.9999F, 49.68138F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell15,
            this.xrTableCell14,
            this.xrTableCell12,
            this.xrTableCell16,
            this.xrTableCell10});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "\r\n\r\nCodigo";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 0.58890208486831D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "\r\n\r\nDescripción";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 1.29978247123672D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "\r\n\r\nInv.";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell3.Weight = 0.324248517855211D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "\r\n\r\nA";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell4.Weight = 0.3007116823354638D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "\r\n\r\nB";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell5.Weight = 0.23196973654653635D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "\r\n\r\nC";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell6.Weight = 0.24785408542620285D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "\r\n\r\nD";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell7.Weight = 0.26740038990448112D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "\r\n\r\nE";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell8.Weight = 0.26684237638405128D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "\r\nTotal\r\nEntrada";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell9.Weight = 0.43939173815598648D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 100F;
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "\r\n\r\nVentas";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell11.Weight = 0.413315548152845D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Dpi = 100F;
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "\r\nPrecio de lista";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell13.Weight = 0.48112342151867094D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Dpi = 100F;
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "\r\nPromición Pzas.";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell15.Weight = 0.52465572894408219D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Dpi = 100F;
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            this.xrTableCell14.Text = "\r\nPromoción\r\nDesc.";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell14.Weight = 0.53154270861185982D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "\r\nImporte de Ventas sin Impuestos";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell12.Weight = 0.5811171518184971D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Dpi = 100F;
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseTextAlignment = false;
            this.xrTableCell16.Text = "\r\n\r\nImpuestos";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell16.Weight = 0.53412915172186948D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "\r\nImporte de Ventas Total";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell10.Weight = 0.66673490143513348D;
            // 
            // SubLiquidacionPorCodigoUnifoods
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(0, 12, 3, 6);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
