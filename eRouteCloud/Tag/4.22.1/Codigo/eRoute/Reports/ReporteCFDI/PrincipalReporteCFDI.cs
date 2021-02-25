using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class PrincipalReporteCFDI : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel x12;
    public XRLabel x13;
    public XRLabel x11;
    public XRLabel x10;
    public XRLabel x9;
    public XRLabel x8;
    public XRLabel x7;
    public XRLabel x6;
    public XRLabel x5;
    public XRLabel x4;
    public XRLabel x3;
    public XRLabel x2;
    public XRLabel x1;
    private GroupHeaderBand GroupHeader2;
    private XRLabel xrLabel9;
    private XRLabel xrLabel21;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel10;
    private XRLabel xrLabel15;
    private ReportHeaderBand ReportHeader;
    public XRPictureBox logo;
    public XRLabel agencia;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    public XRLabel tipo;
    public XRLabel periodo;
    public XRLabel estatus;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PrincipalReporteCFDI()
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
            this.x12 = new DevExpress.XtraReports.UI.XRLabel();
            this.x13 = new DevExpress.XtraReports.UI.XRLabel();
            this.x11 = new DevExpress.XtraReports.UI.XRLabel();
            this.x10 = new DevExpress.XtraReports.UI.XRLabel();
            this.x9 = new DevExpress.XtraReports.UI.XRLabel();
            this.x8 = new DevExpress.XtraReports.UI.XRLabel();
            this.x7 = new DevExpress.XtraReports.UI.XRLabel();
            this.x6 = new DevExpress.XtraReports.UI.XRLabel();
            this.x5 = new DevExpress.XtraReports.UI.XRLabel();
            this.x4 = new DevExpress.XtraReports.UI.XRLabel();
            this.x3 = new DevExpress.XtraReports.UI.XRLabel();
            this.x2 = new DevExpress.XtraReports.UI.XRLabel();
            this.x1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.agencia = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.tipo = new DevExpress.XtraReports.UI.XRLabel();
            this.periodo = new DevExpress.XtraReports.UI.XRLabel();
            this.estatus = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.x12,
            this.x13,
            this.x11,
            this.x10,
            this.x9,
            this.x8,
            this.x7,
            this.x6,
            this.x5,
            this.x4,
            this.x3,
            this.x2,
            this.x1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23.00001F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // x12
            // 
            this.x12.Dpi = 100F;
            this.x12.LocationFloat = new DevExpress.Utils.PointFloat(712.5F, 0F);
            this.x12.Name = "x12";
            this.x12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x12.SizeF = new System.Drawing.SizeF(74.4165F, 23F);
            this.x12.StylePriority.UseTextAlignment = false;
            this.x12.Text = "Total";
            this.x12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x13
            // 
            this.x13.Dpi = 100F;
            this.x13.LocationFloat = new DevExpress.Utils.PointFloat(787.5F, 0F);
            this.x13.Name = "x13";
            this.x13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x13.SizeF = new System.Drawing.SizeF(47.0835F, 23F);
            this.x13.Text = "Estatus";
            // 
            // x11
            // 
            this.x11.Dpi = 100F;
            this.x11.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.x11.Name = "x11";
            this.x11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x11.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.x11.StylePriority.UseTextAlignment = false;
            this.x11.Text = "IVA";
            this.x11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x10
            // 
            this.x10.Dpi = 100F;
            this.x10.LocationFloat = new DevExpress.Utils.PointFloat(587.5F, 0F);
            this.x10.Name = "x10";
            this.x10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x10.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.x10.StylePriority.UseTextAlignment = false;
            this.x10.Text = "IEPS";
            this.x10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x9
            // 
            this.x9.Dpi = 100F;
            this.x9.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.x9.Name = "x9";
            this.x9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x9.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.x9.StylePriority.UseTextAlignment = false;
            this.x9.Text = "Sub";
            this.x9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x8
            // 
            this.x8.Dpi = 100F;
            this.x8.LocationFloat = new DevExpress.Utils.PointFloat(462.5F, 0F);
            this.x8.Name = "x8";
            this.x8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x8.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.x8.StylePriority.UseTextAlignment = false;
            this.x8.Text = "Descuento";
            this.x8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x7
            // 
            this.x7.Dpi = 100F;
            this.x7.LocationFloat = new DevExpress.Utils.PointFloat(400F, 0F);
            this.x7.Name = "x7";
            this.x7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x7.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.x7.StylePriority.UseTextAlignment = false;
            this.x7.Text = "Importe";
            this.x7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // x6
            // 
            this.x6.Dpi = 100F;
            this.x6.LocationFloat = new DevExpress.Utils.PointFloat(325F, 0F);
            this.x6.Name = "x6";
            this.x6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x6.SizeF = new System.Drawing.SizeF(75F, 23.00001F);
            this.x6.Text = "Fecha";
            // 
            // x5
            // 
            this.x5.Dpi = 100F;
            this.x5.LocationFloat = new DevExpress.Utils.PointFloat(275F, 0F);
            this.x5.Name = "x5";
            this.x5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x5.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.x5.Text = "Folio";
            // 
            // x4
            // 
            this.x4.Dpi = 100F;
            this.x4.LocationFloat = new DevExpress.Utils.PointFloat(237.5F, 0F);
            this.x4.Name = "x4";
            this.x4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x4.SizeF = new System.Drawing.SizeF(37.34727F, 23F);
            this.x4.Text = "Serie";
            // 
            // x3
            // 
            this.x3.Dpi = 100F;
            this.x3.LocationFloat = new DevExpress.Utils.PointFloat(187.5F, 0F);
            this.x3.Name = "x3";
            this.x3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x3.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.x3.Text = "TipoDocumento";
            // 
            // x2
            // 
            this.x2.Dpi = 100F;
            this.x2.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.x2.Name = "x2";
            this.x2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x2.SizeF = new System.Drawing.SizeF(137.5F, 23F);
            this.x2.Text = "Nombre";
            // 
            // x1
            // 
            this.x1.Dpi = 100F;
            this.x1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.x1.Name = "x1";
            this.x1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x1.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.x1.Text = "Cliente";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 13F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.TopMargin.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TopMargin_BeforePrint);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 11.33342F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel21,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel10,
            this.xrLabel15});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 23F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.xrLabel9.Text = "Cliente";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(137.5F, 23F);
            this.xrLabel21.Text = "Nombre";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(187.5F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.xrLabel11.Text = "Tipo";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(237.5F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(37.34727F, 23F);
            this.xrLabel12.Text = "Serie";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(275F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.xrLabel13.Text = "Folio";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(325F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.xrLabel14.Text = "Fecha";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(400F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel16.Text = "Importe";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(462.5F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel17.Text = "Descuento";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel18.Text = "Sub";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(587.5F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel19.Text = "IEPS";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel20.Text = "IVA";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(712.5F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(74.4165F, 23F);
            this.xrLabel10.Text = "Total";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(787.5F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(47.0835F, 23F);
            this.xrLabel15.Text = "Estatus";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.agencia,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.tipo,
            this.periodo,
            this.estatus});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 225.1111F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(127.5F, 75F);
            // 
            // agencia
            // 
            this.agencia.Dpi = 100F;
            this.agencia.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agencia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.agencia.Name = "agencia";
            this.agencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.agencia.SizeF = new System.Drawing.SizeF(462.5F, 23F);
            this.agencia.StylePriority.UseFont = false;
            this.agencia.Text = "Agencia";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(187.5F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Reporte CFDI";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 137.5F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(187.5F, 23.00002F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Tipo de Documento:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 162.5F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(187.5F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Periodo";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 187.5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(187.5F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Estatus:";
            // 
            // tipo
            // 
            this.tipo.Dpi = 100F;
            this.tipo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipo.LocationFloat = new DevExpress.Utils.PointFloat(187.5F, 137.5F);
            this.tipo.Name = "tipo";
            this.tipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tipo.SizeF = new System.Drawing.SizeF(275F, 23.00001F);
            this.tipo.StylePriority.UseFont = false;
            this.tipo.Text = "tipo";
            // 
            // periodo
            // 
            this.periodo.Dpi = 100F;
            this.periodo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodo.LocationFloat = new DevExpress.Utils.PointFloat(187.5F, 162.5F);
            this.periodo.Name = "periodo";
            this.periodo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.periodo.SizeF = new System.Drawing.SizeF(275F, 23F);
            this.periodo.StylePriority.UseFont = false;
            this.periodo.Text = "periodo";
            // 
            // estatus
            // 
            this.estatus.Dpi = 100F;
            this.estatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estatus.LocationFloat = new DevExpress.Utils.PointFloat(187.5F, 187.5F);
            this.estatus.Name = "estatus";
            this.estatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.estatus.SizeF = new System.Drawing.SizeF(275F, 23F);
            this.estatus.StylePriority.UseFont = false;
            this.estatus.Text = "estatus";
            // 
            // PrincipalReporteCFDI
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader2,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(12, 3, 13, 11);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
