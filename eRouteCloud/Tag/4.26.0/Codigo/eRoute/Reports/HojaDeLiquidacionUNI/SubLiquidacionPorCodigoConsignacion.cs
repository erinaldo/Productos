using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for SubliquidacionPorCodigo
/// </summary>
public class SubLiquidacionPorCodigoConsignacion : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel14;
    private XRLine xrLine1;
    private ReportHeaderBand ReportHeader;
    public XRLabel s22;
    public XRLabel s211;
    public XRLabel s23;
    public XRLabel s24;
    public XRLabel s26;
    public XRLabel s25;
    public XRLabel s28;
    public XRLabel s27;
    public XRLabel s210;
    public XRLabel s29;
    public XRLabel s212;
    public XRLabel s213;
    public XRLabel s21;
    public XRLabel s214;
    public XRLabel s215;
    public XRLabel s216;
    public XRLabel x14;
    public XRLabel x13;
    public XRLabel x12;
    public XRLabel x11;
    public XRLabel x10;
    public XRLabel x7;
    public XRLabel x8;
    public XRLabel x5;
    public XRLabel x6;
    public XRLabel x3;
    public XRLabel x4;
    public XRLabel x2;
    public XRLabel x1;
    public XRLabel x9;
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

    public SubLiquidacionPorCodigoConsignacion()
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
            this.s22 = new DevExpress.XtraReports.UI.XRLabel();
            this.s211 = new DevExpress.XtraReports.UI.XRLabel();
            this.s23 = new DevExpress.XtraReports.UI.XRLabel();
            this.s24 = new DevExpress.XtraReports.UI.XRLabel();
            this.s26 = new DevExpress.XtraReports.UI.XRLabel();
            this.s25 = new DevExpress.XtraReports.UI.XRLabel();
            this.s28 = new DevExpress.XtraReports.UI.XRLabel();
            this.s27 = new DevExpress.XtraReports.UI.XRLabel();
            this.s210 = new DevExpress.XtraReports.UI.XRLabel();
            this.s29 = new DevExpress.XtraReports.UI.XRLabel();
            this.s212 = new DevExpress.XtraReports.UI.XRLabel();
            this.s213 = new DevExpress.XtraReports.UI.XRLabel();
            this.s21 = new DevExpress.XtraReports.UI.XRLabel();
            this.s214 = new DevExpress.XtraReports.UI.XRLabel();
            this.s215 = new DevExpress.XtraReports.UI.XRLabel();
            this.s216 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.x14 = new DevExpress.XtraReports.UI.XRLabel();
            this.x13 = new DevExpress.XtraReports.UI.XRLabel();
            this.x12 = new DevExpress.XtraReports.UI.XRLabel();
            this.x11 = new DevExpress.XtraReports.UI.XRLabel();
            this.x10 = new DevExpress.XtraReports.UI.XRLabel();
            this.x7 = new DevExpress.XtraReports.UI.XRLabel();
            this.x8 = new DevExpress.XtraReports.UI.XRLabel();
            this.x5 = new DevExpress.XtraReports.UI.XRLabel();
            this.x6 = new DevExpress.XtraReports.UI.XRLabel();
            this.x3 = new DevExpress.XtraReports.UI.XRLabel();
            this.x4 = new DevExpress.XtraReports.UI.XRLabel();
            this.x2 = new DevExpress.XtraReports.UI.XRLabel();
            this.x1 = new DevExpress.XtraReports.UI.XRLabel();
            this.x9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.s22,
            this.s211,
            this.s23,
            this.s24,
            this.s26,
            this.s25,
            this.s28,
            this.s27,
            this.s210,
            this.s29,
            this.s212,
            this.s213,
            this.s21,
            this.s214,
            this.s215,
            this.s216});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 32.98615F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // s22
            // 
            this.s22.Dpi = 100F;
            this.s22.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s22.LocationFloat = new DevExpress.Utils.PointFloat(63.32838F, 0F);
            this.s22.Name = "s22";
            this.s22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s22.SizeF = new System.Drawing.SizeF(139.7738F, 28.20832F);
            this.s22.StylePriority.UseFont = false;
            this.s22.Text = "s22";
            // 
            // s211
            // 
            this.s211.Dpi = 100F;
            this.s211.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s211.LocationFloat = new DevExpress.Utils.PointFloat(471.0542F, 0F);
            this.s211.Name = "s211";
            this.s211.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s211.SizeF = new System.Drawing.SizeF(51.73825F, 28.20833F);
            this.s211.StylePriority.UseFont = false;
            this.s211.StylePriority.UseTextAlignment = false;
            this.s211.Text = "s211";
            this.s211.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s23
            // 
            this.s23.Dpi = 100F;
            this.s23.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s23.LocationFloat = new DevExpress.Utils.PointFloat(203.1022F, 0F);
            this.s23.Name = "s23";
            this.s23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s23.SizeF = new System.Drawing.SizeF(34.86848F, 28.20833F);
            this.s23.StylePriority.UseFont = false;
            this.s23.StylePriority.UseTextAlignment = false;
            this.s23.Text = "s23";
            this.s23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s24
            // 
            this.s24.Dpi = 100F;
            this.s24.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s24.LocationFloat = new DevExpress.Utils.PointFloat(237.9707F, 0F);
            this.s24.Name = "s24";
            this.s24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s24.SizeF = new System.Drawing.SizeF(32.33746F, 28.20833F);
            this.s24.StylePriority.UseFont = false;
            this.s24.StylePriority.UseTextAlignment = false;
            this.s24.Text = "s24";
            this.s24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s26
            // 
            this.s26.Dpi = 100F;
            this.s26.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s26.LocationFloat = new DevExpress.Utils.PointFloat(295.2534F, 0F);
            this.s26.Name = "s26";
            this.s26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s26.SizeF = new System.Drawing.SizeF(26.65332F, 28.20833F);
            this.s26.StylePriority.UseFont = false;
            this.s26.StylePriority.UseTextAlignment = false;
            this.s26.Text = "s26";
            this.s26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s25
            // 
            this.s25.Dpi = 100F;
            this.s25.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s25.LocationFloat = new DevExpress.Utils.PointFloat(270.3082F, 0F);
            this.s25.Name = "s25";
            this.s25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s25.SizeF = new System.Drawing.SizeF(24.94519F, 28.20833F);
            this.s25.StylePriority.UseFont = false;
            this.s25.StylePriority.UseTextAlignment = false;
            this.s25.Text = "s25";
            this.s25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s28
            // 
            this.s28.Dpi = 100F;
            this.s28.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s28.LocationFloat = new DevExpress.Utils.PointFloat(350.6619F, 0F);
            this.s28.Name = "s28";
            this.s28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s28.SizeF = new System.Drawing.SizeF(28.69525F, 28.20833F);
            this.s28.StylePriority.UseFont = false;
            this.s28.StylePriority.UseTextAlignment = false;
            this.s28.Text = "s28";
            this.s28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s27
            // 
            this.s27.Dpi = 100F;
            this.s27.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s27.LocationFloat = new DevExpress.Utils.PointFloat(321.9067F, 0F);
            this.s27.Name = "s27";
            this.s27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s27.SizeF = new System.Drawing.SizeF(28.75525F, 28.20833F);
            this.s27.StylePriority.UseFont = false;
            this.s27.StylePriority.UseTextAlignment = false;
            this.s27.Text = "s27";
            this.s27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s210
            // 
            this.s210.Dpi = 100F;
            this.s210.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s210.LocationFloat = new DevExpress.Utils.PointFloat(426.6077F, 0F);
            this.s210.Name = "s210";
            this.s210.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s210.SizeF = new System.Drawing.SizeF(44.44644F, 28.20833F);
            this.s210.StylePriority.UseFont = false;
            this.s210.StylePriority.UseTextAlignment = false;
            this.s210.Text = "s210";
            this.s210.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s29
            // 
            this.s29.Dpi = 100F;
            this.s29.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s29.LocationFloat = new DevExpress.Utils.PointFloat(379.3572F, 0F);
            this.s29.Multiline = true;
            this.s29.Name = "s29";
            this.s29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s29.SizeF = new System.Drawing.SizeF(47.25055F, 28.20833F);
            this.s29.StylePriority.UseFont = false;
            this.s29.StylePriority.UseTextAlignment = false;
            this.s29.Text = "s29";
            this.s29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s212
            // 
            this.s212.Dpi = 100F;
            this.s212.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s212.LocationFloat = new DevExpress.Utils.PointFloat(522.7924F, 0F);
            this.s212.Name = "s212";
            this.s212.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s212.SizeF = new System.Drawing.SizeF(56.41956F, 28.20833F);
            this.s212.StylePriority.UseFont = false;
            this.s212.StylePriority.UseTextAlignment = false;
            this.s212.Text = "s212";
            this.s212.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s213
            // 
            this.s213.Dpi = 100F;
            this.s213.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s213.LocationFloat = new DevExpress.Utils.PointFloat(579.212F, 0F);
            this.s213.Name = "s213";
            this.s213.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s213.SizeF = new System.Drawing.SizeF(57.16016F, 28.20833F);
            this.s213.StylePriority.UseFont = false;
            this.s213.StylePriority.UseTextAlignment = false;
            this.s213.Text = "s213";
            this.s213.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s21
            // 
            this.s21.Dpi = 100F;
            this.s21.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s21.LocationFloat = new DevExpress.Utils.PointFloat(1.030699F, 0F);
            this.s21.Name = "s21";
            this.s21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s21.SizeF = new System.Drawing.SizeF(62.29767F, 28.20833F);
            this.s21.StylePriority.UseFont = false;
            this.s21.Text = "s21";
            // 
            // s214
            // 
            this.s214.Dpi = 100F;
            this.s214.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s214.LocationFloat = new DevExpress.Utils.PointFloat(636.3721F, 0F);
            this.s214.Name = "s214";
            this.s214.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s214.SizeF = new System.Drawing.SizeF(62.49121F, 28.20833F);
            this.s214.StylePriority.UseFont = false;
            this.s214.StylePriority.UseTextAlignment = false;
            this.s214.Text = "s214";
            this.s214.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s215
            // 
            this.s215.Dpi = 100F;
            this.s215.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s215.LocationFloat = new DevExpress.Utils.PointFloat(698.8633F, 0F);
            this.s215.Name = "s215";
            this.s215.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s215.SizeF = new System.Drawing.SizeF(57.43829F, 28.20833F);
            this.s215.StylePriority.UseFont = false;
            this.s215.StylePriority.UseTextAlignment = false;
            this.s215.Text = "s215";
            this.s215.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s216
            // 
            this.s216.Dpi = 100F;
            this.s216.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.s216.LocationFloat = new DevExpress.Utils.PointFloat(756.3016F, 0F);
            this.s216.Name = "s216";
            this.s216.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s216.SizeF = new System.Drawing.SizeF(68.69843F, 28.20832F);
            this.s216.StylePriority.UseFont = false;
            this.s216.StylePriority.UseTextAlignment = false;
            this.s216.Text = "s216";
            this.s216.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 9F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.x14,
            this.x13,
            this.x12,
            this.x11,
            this.x10,
            this.x7,
            this.x8,
            this.x5,
            this.x6,
            this.x3,
            this.x4,
            this.x2,
            this.x1,
            this.x9,
            this.xrLine1,
            this.xrLabel14});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 56.85041F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // x14
            // 
            this.x14.Dpi = 100F;
            this.x14.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x14.LocationFloat = new DevExpress.Utils.PointFloat(756.3016F, 5.642073F);
            this.x14.Name = "x14";
            this.x14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x14.SizeF = new System.Drawing.SizeF(68.69843F, 28.20832F);
            this.x14.StylePriority.UseFont = false;
            this.x14.StylePriority.UseTextAlignment = false;
            this.x14.Text = "x14";
            this.x14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x13
            // 
            this.x13.Dpi = 100F;
            this.x13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x13.LocationFloat = new DevExpress.Utils.PointFloat(698.8633F, 5.642073F);
            this.x13.Name = "x13";
            this.x13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x13.SizeF = new System.Drawing.SizeF(57.43835F, 28.20833F);
            this.x13.StylePriority.UseFont = false;
            this.x13.StylePriority.UseTextAlignment = false;
            this.x13.Text = "x13";
            this.x13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x12
            // 
            this.x12.Dpi = 100F;
            this.x12.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x12.LocationFloat = new DevExpress.Utils.PointFloat(636.3721F, 5.64205F);
            this.x12.Name = "x12";
            this.x12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x12.SizeF = new System.Drawing.SizeF(62.49121F, 28.20833F);
            this.x12.StylePriority.UseFont = false;
            this.x12.StylePriority.UseTextAlignment = false;
            this.x12.Text = "x12";
            this.x12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x11
            // 
            this.x11.Dpi = 100F;
            this.x11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x11.LocationFloat = new DevExpress.Utils.PointFloat(579.212F, 5.642073F);
            this.x11.Name = "x11";
            this.x11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x11.SizeF = new System.Drawing.SizeF(57.16016F, 28.20833F);
            this.x11.StylePriority.UseFont = false;
            this.x11.StylePriority.UseTextAlignment = false;
            this.x11.Text = "x11";
            this.x11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x10
            // 
            this.x10.Dpi = 100F;
            this.x10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x10.LocationFloat = new DevExpress.Utils.PointFloat(522.7925F, 5.642073F);
            this.x10.Name = "x10";
            this.x10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x10.SizeF = new System.Drawing.SizeF(56.41949F, 28.20833F);
            this.x10.StylePriority.UseFont = false;
            this.x10.StylePriority.UseTextAlignment = false;
            this.x10.Text = "x10";
            this.x10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x7
            // 
            this.x7.Dpi = 100F;
            this.x7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x7.LocationFloat = new DevExpress.Utils.PointFloat(379.3572F, 5.642064F);
            this.x7.Multiline = true;
            this.x7.Name = "x7";
            this.x7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x7.SizeF = new System.Drawing.SizeF(47.25055F, 28.20833F);
            this.x7.StylePriority.UseFont = false;
            this.x7.StylePriority.UseTextAlignment = false;
            this.x7.Text = "x7";
            this.x7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x8
            // 
            this.x8.Dpi = 100F;
            this.x8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x8.LocationFloat = new DevExpress.Utils.PointFloat(426.6077F, 5.642073F);
            this.x8.Name = "x8";
            this.x8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x8.SizeF = new System.Drawing.SizeF(44.44644F, 28.20833F);
            this.x8.StylePriority.UseFont = false;
            this.x8.StylePriority.UseTextAlignment = false;
            this.x8.Text = "x8";
            this.x8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x5
            // 
            this.x5.Dpi = 100F;
            this.x5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x5.LocationFloat = new DevExpress.Utils.PointFloat(321.9067F, 5.642064F);
            this.x5.Name = "x5";
            this.x5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x5.SizeF = new System.Drawing.SizeF(28.75525F, 28.20833F);
            this.x5.StylePriority.UseFont = false;
            this.x5.StylePriority.UseTextAlignment = false;
            this.x5.Text = "x5";
            this.x5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x6
            // 
            this.x6.Dpi = 100F;
            this.x6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x6.LocationFloat = new DevExpress.Utils.PointFloat(350.6619F, 5.642064F);
            this.x6.Name = "x6";
            this.x6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x6.SizeF = new System.Drawing.SizeF(28.69525F, 28.20833F);
            this.x6.StylePriority.UseFont = false;
            this.x6.StylePriority.UseTextAlignment = false;
            this.x6.Text = "x6";
            this.x6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x3
            // 
            this.x3.Dpi = 100F;
            this.x3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x3.LocationFloat = new DevExpress.Utils.PointFloat(270.3082F, 5.642064F);
            this.x3.Name = "x3";
            this.x3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x3.SizeF = new System.Drawing.SizeF(24.94519F, 28.20833F);
            this.x3.StylePriority.UseFont = false;
            this.x3.StylePriority.UseTextAlignment = false;
            this.x3.Text = "x3";
            this.x3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x4
            // 
            this.x4.Dpi = 100F;
            this.x4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x4.LocationFloat = new DevExpress.Utils.PointFloat(295.2534F, 5.642064F);
            this.x4.Name = "x4";
            this.x4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x4.SizeF = new System.Drawing.SizeF(26.65332F, 28.20833F);
            this.x4.StylePriority.UseFont = false;
            this.x4.StylePriority.UseTextAlignment = false;
            this.x4.Text = "x4";
            this.x4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x2
            // 
            this.x2.Dpi = 100F;
            this.x2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x2.LocationFloat = new DevExpress.Utils.PointFloat(237.9707F, 5.642064F);
            this.x2.Name = "x2";
            this.x2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x2.SizeF = new System.Drawing.SizeF(32.33746F, 28.20833F);
            this.x2.StylePriority.UseFont = false;
            this.x2.StylePriority.UseTextAlignment = false;
            this.x2.Text = "x2";
            this.x2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x1
            // 
            this.x1.Dpi = 100F;
            this.x1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x1.LocationFloat = new DevExpress.Utils.PointFloat(203.1022F, 5.642064F);
            this.x1.Name = "x1";
            this.x1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x1.SizeF = new System.Drawing.SizeF(34.86848F, 28.20833F);
            this.x1.StylePriority.UseFont = false;
            this.x1.StylePriority.UseTextAlignment = false;
            this.x1.Text = "x1";
            this.x1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x9
            // 
            this.x9.Dpi = 100F;
            this.x9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x9.LocationFloat = new DevExpress.Utils.PointFloat(471.0541F, 5.64205F);
            this.x9.Name = "x9";
            this.x9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x9.SizeF = new System.Drawing.SizeF(51.73828F, 28.20833F);
            this.x9.StylePriority.UseFont = false;
            this.x9.StylePriority.UseTextAlignment = false;
            this.x9.Text = "x9";
            this.x9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 33.85039F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(827.9999F, 23.00002F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00002F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(203.1022F, 24.6186F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "SUBTOTAL POR CODIGOS CONSIGNACION";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 67.34597F;
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
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 7.051851F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(827.9999F, 54.58334F);
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
            // SubLiquidacionPorCodigoConsignacion
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(0, 15, 9, 0);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
