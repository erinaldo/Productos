using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class SubReporteVentasCodigo : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private ReportFooterBand ReportFooter;
    public XRLabel labelGranTotalC;
    public XRLabel labelGranVentaC;
    public XRLabel labelGranCambioC;
    public XRLabel labelGranPromocionC;
    public XRLabel labelGranImporteC;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    public GroupHeaderBand GroupHeader1;
    public XRLabel labelImporteC;
    public XRLabel labelPiezasPC;
    public XRLabel labelPiezasCC;
    public XRLabel labelPiezasVC;
    public XRLabel labelDescripcionC;
    public XRLabel labelCodigoC;
    public XRLabel labelCobertura;
    public XRLabel labelClienteCE;
    public XRLabel labelClienteC;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteVentasCodigo()
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.labelGranTotalC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranVentaC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranCambioC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranPromocionC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranImporteC = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelImporteC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasPC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasCC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasVC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescripcionC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCodigoC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCobertura = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteCE = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteC = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 50F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(999.8337F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(73.66632F, 47.91667F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "% Cobertura";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(918.8001F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(81.03345F, 47.91667F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Clientes con Compra Efectiva";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(838.2668F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(80.53333F, 47.91667F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Clientes con Compra";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(757.2332F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(81.03345F, 47.91666F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Importe (Venta)";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(663.0334F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(94.19989F, 47.91666F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Piezas (Promoción";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(581.3334F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(81.70001F, 47.91666F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Piezas (Cambio)";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(500.6751F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(80.65836F, 47.91666F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Piezas (Venta)";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(190.8501F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(309.825F, 47.91666F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Descripción";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(1.499987F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(189.3501F, 47.91667F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Código";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelGranTotalC,
            this.labelGranVentaC,
            this.labelGranCambioC,
            this.labelGranPromocionC,
            this.labelGranImporteC});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 16.66667F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // labelGranTotalC
            // 
            this.labelGranTotalC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranTotalC.Dpi = 100F;
            this.labelGranTotalC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranTotalC.LocationFloat = new DevExpress.Utils.PointFloat(189.8503F, 0F);
            this.labelGranTotalC.Name = "labelGranTotalC";
            this.labelGranTotalC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranTotalC.SizeF = new System.Drawing.SizeF(309.82F, 16F);
            this.labelGranTotalC.StylePriority.UseBorders = false;
            this.labelGranTotalC.StylePriority.UseFont = false;
            this.labelGranTotalC.StylePriority.UseTextAlignment = false;
            this.labelGranTotalC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelGranVentaC
            // 
            this.labelGranVentaC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranVentaC.Dpi = 100F;
            this.labelGranVentaC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranVentaC.LocationFloat = new DevExpress.Utils.PointFloat(499.675F, 0F);
            this.labelGranVentaC.Name = "labelGranVentaC";
            this.labelGranVentaC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranVentaC.SizeF = new System.Drawing.SizeF(80.66F, 16F);
            this.labelGranVentaC.StylePriority.UseBorders = false;
            this.labelGranVentaC.StylePriority.UseFont = false;
            this.labelGranVentaC.StylePriority.UseTextAlignment = false;
            this.labelGranVentaC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelGranCambioC
            // 
            this.labelGranCambioC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranCambioC.Dpi = 100F;
            this.labelGranCambioC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranCambioC.LocationFloat = new DevExpress.Utils.PointFloat(580.335F, 0F);
            this.labelGranCambioC.Name = "labelGranCambioC";
            this.labelGranCambioC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranCambioC.SizeF = new System.Drawing.SizeF(81.2F, 16F);
            this.labelGranCambioC.StylePriority.UseBorders = false;
            this.labelGranCambioC.StylePriority.UseFont = false;
            this.labelGranCambioC.StylePriority.UseTextAlignment = false;
            this.labelGranCambioC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelGranPromocionC
            // 
            this.labelGranPromocionC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranPromocionC.Dpi = 100F;
            this.labelGranPromocionC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranPromocionC.LocationFloat = new DevExpress.Utils.PointFloat(661.535F, 0F);
            this.labelGranPromocionC.Name = "labelGranPromocionC";
            this.labelGranPromocionC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranPromocionC.SizeF = new System.Drawing.SizeF(94.2F, 16F);
            this.labelGranPromocionC.StylePriority.UseBorders = false;
            this.labelGranPromocionC.StylePriority.UseFont = false;
            this.labelGranPromocionC.StylePriority.UseTextAlignment = false;
            this.labelGranPromocionC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelGranImporteC
            // 
            this.labelGranImporteC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranImporteC.Dpi = 100F;
            this.labelGranImporteC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranImporteC.LocationFloat = new DevExpress.Utils.PointFloat(755.735F, 0F);
            this.labelGranImporteC.Name = "labelGranImporteC";
            this.labelGranImporteC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranImporteC.SizeF = new System.Drawing.SizeF(81.03F, 16F);
            this.labelGranImporteC.StylePriority.UseBorders = false;
            this.labelGranImporteC.StylePriority.UseFont = false;
            this.labelGranImporteC.StylePriority.UseTextAlignment = false;
            this.labelGranImporteC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 19.75001F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1.000015F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1073F, 16F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "III - Resumen por Código";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelImporteC,
            this.labelPiezasPC,
            this.labelPiezasCC,
            this.labelPiezasVC,
            this.labelDescripcionC,
            this.labelCodigoC,
            this.labelCobertura,
            this.labelClienteCE,
            this.labelClienteC});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 17.66669F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // labelImporteC
            // 
            this.labelImporteC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelImporteC.Dpi = 100F;
            this.labelImporteC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteC.LocationFloat = new DevExpress.Utils.PointFloat(755.7349F, 1.666689F);
            this.labelImporteC.Name = "labelImporteC";
            this.labelImporteC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteC.SizeF = new System.Drawing.SizeF(81.03F, 16F);
            this.labelImporteC.StylePriority.UseBorders = false;
            this.labelImporteC.StylePriority.UseFont = false;
            this.labelImporteC.StylePriority.UseTextAlignment = false;
            this.labelImporteC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPiezasPC
            // 
            this.labelPiezasPC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasPC.Dpi = 100F;
            this.labelPiezasPC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasPC.LocationFloat = new DevExpress.Utils.PointFloat(661.535F, 1.666689F);
            this.labelPiezasPC.Name = "labelPiezasPC";
            this.labelPiezasPC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasPC.SizeF = new System.Drawing.SizeF(94.2F, 16F);
            this.labelPiezasPC.StylePriority.UseBorders = false;
            this.labelPiezasPC.StylePriority.UseFont = false;
            this.labelPiezasPC.StylePriority.UseTextAlignment = false;
            this.labelPiezasPC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPiezasCC
            // 
            this.labelPiezasCC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasCC.Dpi = 100F;
            this.labelPiezasCC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasCC.LocationFloat = new DevExpress.Utils.PointFloat(580.3349F, 1.666689F);
            this.labelPiezasCC.Name = "labelPiezasCC";
            this.labelPiezasCC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasCC.SizeF = new System.Drawing.SizeF(81.2F, 16F);
            this.labelPiezasCC.StylePriority.UseBorders = false;
            this.labelPiezasCC.StylePriority.UseFont = false;
            this.labelPiezasCC.StylePriority.UseTextAlignment = false;
            this.labelPiezasCC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPiezasVC
            // 
            this.labelPiezasVC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasVC.Dpi = 100F;
            this.labelPiezasVC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasVC.LocationFloat = new DevExpress.Utils.PointFloat(499.6749F, 1.666689F);
            this.labelPiezasVC.Name = "labelPiezasVC";
            this.labelPiezasVC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasVC.SizeF = new System.Drawing.SizeF(80.66F, 16F);
            this.labelPiezasVC.StylePriority.UseBorders = false;
            this.labelPiezasVC.StylePriority.UseFont = false;
            this.labelPiezasVC.StylePriority.UseTextAlignment = false;
            this.labelPiezasVC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelDescripcionC
            // 
            this.labelDescripcionC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelDescripcionC.Dpi = 100F;
            this.labelDescripcionC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcionC.LocationFloat = new DevExpress.Utils.PointFloat(189.8501F, 1.666689F);
            this.labelDescripcionC.Name = "labelDescripcionC";
            this.labelDescripcionC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescripcionC.SizeF = new System.Drawing.SizeF(309.82F, 16F);
            this.labelDescripcionC.StylePriority.UseBorders = false;
            this.labelDescripcionC.StylePriority.UseFont = false;
            this.labelDescripcionC.StylePriority.UseTextAlignment = false;
            this.labelDescripcionC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCodigoC
            // 
            this.labelCodigoC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCodigoC.Dpi = 100F;
            this.labelCodigoC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigoC.LocationFloat = new DevExpress.Utils.PointFloat(0.499932F, 1.666689F);
            this.labelCodigoC.Name = "labelCodigoC";
            this.labelCodigoC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCodigoC.SizeF = new System.Drawing.SizeF(189.35F, 16F);
            this.labelCodigoC.StylePriority.UseBorders = false;
            this.labelCodigoC.StylePriority.UseFont = false;
            this.labelCodigoC.StylePriority.UseTextAlignment = false;
            this.labelCodigoC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCobertura
            // 
            this.labelCobertura.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCobertura.Dpi = 100F;
            this.labelCobertura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCobertura.LocationFloat = new DevExpress.Utils.PointFloat(998.8335F, 1.666689F);
            this.labelCobertura.Name = "labelCobertura";
            this.labelCobertura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCobertura.SizeF = new System.Drawing.SizeF(73.67F, 16F);
            this.labelCobertura.StylePriority.UseBorders = false;
            this.labelCobertura.StylePriority.UseFont = false;
            this.labelCobertura.StylePriority.UseTextAlignment = false;
            this.labelCobertura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelClienteCE
            // 
            this.labelClienteCE.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelClienteCE.Dpi = 100F;
            this.labelClienteCE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteCE.LocationFloat = new DevExpress.Utils.PointFloat(917.8002F, 1.666689F);
            this.labelClienteCE.Name = "labelClienteCE";
            this.labelClienteCE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteCE.SizeF = new System.Drawing.SizeF(81.03F, 16F);
            this.labelClienteCE.StylePriority.UseBorders = false;
            this.labelClienteCE.StylePriority.UseFont = false;
            this.labelClienteCE.StylePriority.UseTextAlignment = false;
            this.labelClienteCE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelClienteC
            // 
            this.labelClienteC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelClienteC.Dpi = 100F;
            this.labelClienteC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteC.LocationFloat = new DevExpress.Utils.PointFloat(836.7649F, 1.666689F);
            this.labelClienteC.Name = "labelClienteC";
            this.labelClienteC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteC.SizeF = new System.Drawing.SizeF(80.53F, 16F);
            this.labelClienteC.StylePriority.UseBorders = false;
            this.labelClienteC.StylePriority.UseFont = false;
            this.labelClienteC.StylePriority.UseTextAlignment = false;
            this.labelClienteC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // SubReporteVentasCodigo
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter,
            this.ReportHeader,
            this.GroupHeader1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 0, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
