using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for SubliquidacionPorCodigo
/// </summary>
public class SubClientesSurtidos : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel s39;
    public XRLabel s38;
    public XRLabel s37;
    public XRLabel s36;
    public XRLabel s35;
    public XRLabel s34;
    public XRLabel s33;
    public XRLabel s32;
    public XRLabel s31;
    private ReportFooterBand ReportFooter;
    private XRLine xrLine2;
    private XRLine xrLine3;
    private XRLine xrLine4;
    private XRLabel xrLabel10;
    public XRLabel gt21;
    public XRLabel gt22;
    public XRLabel gt23;
    public XRLabel gt24;
    private ReportHeaderBand ReportHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell5;
    public XRLabel s312;
    public XRLabel s311;
    public XRLabel s310;
    public XRLabel gt27;
    public XRLabel gt26;
    public XRLabel gt25;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubClientesSurtidos()
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
            this.s312 = new DevExpress.XtraReports.UI.XRLabel();
            this.s311 = new DevExpress.XtraReports.UI.XRLabel();
            this.s310 = new DevExpress.XtraReports.UI.XRLabel();
            this.s39 = new DevExpress.XtraReports.UI.XRLabel();
            this.s38 = new DevExpress.XtraReports.UI.XRLabel();
            this.s37 = new DevExpress.XtraReports.UI.XRLabel();
            this.s36 = new DevExpress.XtraReports.UI.XRLabel();
            this.s35 = new DevExpress.XtraReports.UI.XRLabel();
            this.s34 = new DevExpress.XtraReports.UI.XRLabel();
            this.s33 = new DevExpress.XtraReports.UI.XRLabel();
            this.s32 = new DevExpress.XtraReports.UI.XRLabel();
            this.s31 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.gt27 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt26 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt25 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt21 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt22 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt23 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.s312,
            this.s311,
            this.s310,
            this.s39,
            this.s38,
            this.s37,
            this.s36,
            this.s35,
            this.s34,
            this.s33,
            this.s32,
            this.s31});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 26.04167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // s312
            // 
            this.s312.Dpi = 100F;
            this.s312.LocationFloat = new DevExpress.Utils.PointFloat(746.1623F, 0F);
            this.s312.Name = "s312";
            this.s312.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s312.SizeF = new System.Drawing.SizeF(86.83777F, 23F);
            this.s312.StylePriority.UseTextAlignment = false;
            this.s312.Text = "s312";
            this.s312.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s311
            // 
            this.s311.Dpi = 100F;
            this.s311.LocationFloat = new DevExpress.Utils.PointFloat(685.5117F, 0F);
            this.s311.Name = "s311";
            this.s311.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s311.SizeF = new System.Drawing.SizeF(60.65051F, 23F);
            this.s311.StylePriority.UseTextAlignment = false;
            this.s311.Text = "s311";
            this.s311.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s310
            // 
            this.s310.Dpi = 100F;
            this.s310.LocationFloat = new DevExpress.Utils.PointFloat(616.3752F, 0F);
            this.s310.Name = "s310";
            this.s310.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s310.SizeF = new System.Drawing.SizeF(69.13647F, 23F);
            this.s310.StylePriority.UseTextAlignment = false;
            this.s310.Text = "s310";
            this.s310.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s39
            // 
            this.s39.Dpi = 100F;
            this.s39.LocationFloat = new DevExpress.Utils.PointFloat(534.0619F, 0F);
            this.s39.Name = "s39";
            this.s39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s39.SizeF = new System.Drawing.SizeF(82.31329F, 23F);
            this.s39.StylePriority.UseTextAlignment = false;
            this.s39.Text = "s39";
            this.s39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s38
            // 
            this.s38.Dpi = 100F;
            this.s38.LocationFloat = new DevExpress.Utils.PointFloat(487.187F, 0F);
            this.s38.Name = "s38";
            this.s38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s38.SizeF = new System.Drawing.SizeF(46.87494F, 23F);
            this.s38.StylePriority.UseTextAlignment = false;
            this.s38.Text = "s38";
            this.s38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s37
            // 
            this.s37.Dpi = 100F;
            this.s37.LocationFloat = new DevExpress.Utils.PointFloat(420.2865F, 0F);
            this.s37.Name = "s37";
            this.s37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s37.SizeF = new System.Drawing.SizeF(66.90045F, 23F);
            this.s37.StylePriority.UseTextAlignment = false;
            this.s37.Text = "s37";
            this.s37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s36
            // 
            this.s36.Dpi = 100F;
            this.s36.LocationFloat = new DevExpress.Utils.PointFloat(355.9528F, 0F);
            this.s36.Name = "s36";
            this.s36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s36.SizeF = new System.Drawing.SizeF(64.33371F, 23F);
            this.s36.StylePriority.UseTextAlignment = false;
            this.s36.Text = "s36";
            this.s36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // s35
            // 
            this.s35.Dpi = 100F;
            this.s35.LocationFloat = new DevExpress.Utils.PointFloat(229.7119F, 0F);
            this.s35.Name = "s35";
            this.s35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s35.SizeF = new System.Drawing.SizeF(126.2409F, 23F);
            this.s35.Text = "s35";
            // 
            // s34
            // 
            this.s34.Dpi = 100F;
            this.s34.LocationFloat = new DevExpress.Utils.PointFloat(160.0915F, 0F);
            this.s34.Name = "s34";
            this.s34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s34.SizeF = new System.Drawing.SizeF(69.62038F, 23F);
            this.s34.Text = "s34";
            // 
            // s33
            // 
            this.s33.Dpi = 100F;
            this.s33.LocationFloat = new DevExpress.Utils.PointFloat(120.6712F, 0F);
            this.s33.Name = "s33";
            this.s33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s33.SizeF = new System.Drawing.SizeF(39.42028F, 23F);
            this.s33.Text = "s33";
            // 
            // s32
            // 
            this.s32.Dpi = 100F;
            this.s32.LocationFloat = new DevExpress.Utils.PointFloat(75.70575F, 0F);
            this.s32.Name = "s32";
            this.s32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s32.SizeF = new System.Drawing.SizeF(44.9655F, 23F);
            this.s32.Text = "s32";
            // 
            // s31
            // 
            this.s31.Dpi = 100F;
            this.s31.LocationFloat = new DevExpress.Utils.PointFloat(3.405979E-05F, 0F);
            this.s31.Name = "s31";
            this.s31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.s31.SizeF = new System.Drawing.SizeF(75.70571F, 23F);
            this.s31.Text = "s31";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 2.277756F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.gt27,
            this.gt26,
            this.gt25,
            this.gt21,
            this.gt22,
            this.gt23,
            this.gt24,
            this.xrLine2,
            this.xrLine3,
            this.xrLine4,
            this.xrLabel10});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 65.97223F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // gt27
            // 
            this.gt27.Dpi = 100F;
            this.gt27.LocationFloat = new DevExpress.Utils.PointFloat(746.1622F, 28.55557F);
            this.gt27.Name = "gt27";
            this.gt27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt27.SizeF = new System.Drawing.SizeF(86.83789F, 23F);
            this.gt27.StylePriority.UseTextAlignment = false;
            this.gt27.Text = "gt27";
            this.gt27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // gt26
            // 
            this.gt26.Dpi = 100F;
            this.gt26.LocationFloat = new DevExpress.Utils.PointFloat(685.5117F, 27.06943F);
            this.gt26.Name = "gt26";
            this.gt26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt26.SizeF = new System.Drawing.SizeF(60.65045F, 23F);
            this.gt26.StylePriority.UseTextAlignment = false;
            this.gt26.Text = "gt26";
            this.gt26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // gt25
            // 
            this.gt25.Dpi = 100F;
            this.gt25.LocationFloat = new DevExpress.Utils.PointFloat(616.3752F, 28.55557F);
            this.gt25.Name = "gt25";
            this.gt25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt25.SizeF = new System.Drawing.SizeF(69.13647F, 23F);
            this.gt25.StylePriority.UseTextAlignment = false;
            this.gt25.Text = "gt25";
            this.gt25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // gt21
            // 
            this.gt21.Dpi = 100F;
            this.gt21.LocationFloat = new DevExpress.Utils.PointFloat(355.9528F, 27.06943F);
            this.gt21.Name = "gt21";
            this.gt21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt21.SizeF = new System.Drawing.SizeF(64.33371F, 22.99999F);
            this.gt21.StylePriority.UseTextAlignment = false;
            this.gt21.Text = "gt21";
            this.gt21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // gt22
            // 
            this.gt22.Dpi = 100F;
            this.gt22.LocationFloat = new DevExpress.Utils.PointFloat(420.2865F, 27.06943F);
            this.gt22.Name = "gt22";
            this.gt22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt22.SizeF = new System.Drawing.SizeF(66.90045F, 22.99999F);
            this.gt22.StylePriority.UseTextAlignment = false;
            this.gt22.Text = "gt22";
            this.gt22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // gt23
            // 
            this.gt23.Dpi = 100F;
            this.gt23.LocationFloat = new DevExpress.Utils.PointFloat(487.187F, 27.06943F);
            this.gt23.Name = "gt23";
            this.gt23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt23.SizeF = new System.Drawing.SizeF(46.87494F, 23F);
            this.gt23.StylePriority.UseTextAlignment = false;
            this.gt23.Text = "gt23";
            this.gt23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // gt24
            // 
            this.gt24.Dpi = 100F;
            this.gt24.LocationFloat = new DevExpress.Utils.PointFloat(534.062F, 28.55557F);
            this.gt24.Name = "gt24";
            this.gt24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt24.SizeF = new System.Drawing.SizeF(82.31323F, 23F);
            this.gt24.StylePriority.UseTextAlignment = false;
            this.gt24.Text = "gt24";
            this.gt24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(76.70317F, 14.66668F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(756.2968F, 13.88888F);
            // 
            // xrLine3
            // 
            this.xrLine3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLine3.BorderWidth = 3F;
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(76.70317F, 50.06943F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(756.2968F, 13.8889F);
            this.xrLine3.StylePriority.UseBackColor = false;
            this.xrLine3.StylePriority.UseBorderDashStyle = false;
            this.xrLine3.StylePriority.UseBorders = false;
            this.xrLine3.StylePriority.UseBorderWidth = false;
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(76.70317F, 40.95834F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(756.2969F, 23.00001F);
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(76.70317F, 27.06944F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(109.0746F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "GRAN TOTAL ";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 65.625F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 100F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(3.973643E-05F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(832.9999F, 63.95834F);
            this.xrTable1.StylePriority.UseBorders = false;
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
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell5,
            this.xrTableCell12});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "\r\n\r\nRemisión";
            this.xrTableCell1.Weight = 0.84968496761333012D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "\r\n\r\nEstatus";
            this.xrTableCell2.Weight = 0.5046716121801671D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "\r\n\r\nHora";
            this.xrTableCell3.Weight = 0.44243446147935289D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "\r\n\r\nNo Cliente";
            this.xrTableCell4.Weight = 0.78138610214411841D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "\r\n\r\nNombre del Cliente";
            this.xrTableCell6.Weight = 1.4168680023339697D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "\r\nPromoción Pzas.";
            this.xrTableCell7.Weight = 0.72205113967687284D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "\r\nPromoción Desc.";
            this.xrTableCell10.Weight = 0.75085868901703934D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 100F;
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "\r\nCambio\r\n(Pzas)";
            this.xrTableCell11.Weight = 0.52610209112453465D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "\r\nImporte\r\nPedido";
            this.xrTableCell8.Weight = 0.92384470322073431D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "\r\nImporte de\r\nVentas sin\r\nImpuestos";
            this.xrTableCell9.Weight = 0.77595587294575286D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "\r\n\r\nImpuestos";
            this.xrTableCell5.Weight = 0.68071294743856647D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "\r\nImporte\r\nVentas\r\nTotal";
            this.xrTableCell12.Weight = 0.97462594351886545D;
            // 
            // SubClientesSurtidos
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(0, 7, 0, 2);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
