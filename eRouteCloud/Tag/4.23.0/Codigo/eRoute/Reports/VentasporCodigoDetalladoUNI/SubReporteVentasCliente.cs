using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class SubReporteVentasCliente : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public PageHeaderBand PageHeader;
    private XRLabel xrLabel5;
    public GroupHeaderBand GroupHeader1;
    public XRLabel labelFolioC;
    public XRLabel labelFechaC;
    public XRLabel labelCodigoC;
    public XRLabel labelDescripcionC;
    public XRLabel labelPiezasVC;
    public XRLabel labelPiezasCC;
    public XRLabel labelPiezasPC;
    public XRLabel labelImporteC;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    public XRLabel labelCliente;
    private GroupFooterBand GroupFooter1;
    public XRLabel labelSubTotalC;
    public XRLabel labelSubVentaC;
    public XRLabel labelSubCambioC;
    public XRLabel labelSubPromocionC;
    public XRLabel labelSubImporteC;
    private ReportFooterBand ReportFooter;
    public XRLabel labelGranTotalC;
    public XRLabel labelGranVentaC;
    public XRLabel labelGranCambioC;
    public XRLabel labelGranPromocionC;
    public XRLabel labelGranImporteC;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel3;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteVentasCliente()
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
            this.labelFolioC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFechaC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCodigoC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescripcionC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasVC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasCC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasPC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteC = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelSubTotalC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSubVentaC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSubCambioC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSubPromocionC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSubImporteC = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.labelGranTotalC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranVentaC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranCambioC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranPromocionC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranImporteC = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelFolioC,
            this.labelFechaC,
            this.labelCodigoC,
            this.labelDescripcionC,
            this.labelPiezasVC,
            this.labelPiezasCC,
            this.labelPiezasPC,
            this.labelImporteC});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 16F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelFolioC
            // 
            this.labelFolioC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelFolioC.Dpi = 100F;
            this.labelFolioC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolioC.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.labelFolioC.Name = "labelFolioC";
            this.labelFolioC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFolioC.SizeF = new System.Drawing.SizeF(143.03F, 16F);
            this.labelFolioC.StylePriority.UseBorders = false;
            this.labelFolioC.StylePriority.UseFont = false;
            this.labelFolioC.StylePriority.UseTextAlignment = false;
            this.labelFolioC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelFechaC
            // 
            this.labelFechaC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelFechaC.Dpi = 100F;
            this.labelFechaC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaC.LocationFloat = new DevExpress.Utils.PointFloat(143.0332F, 0F);
            this.labelFechaC.Name = "labelFechaC";
            this.labelFechaC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFechaC.SizeF = new System.Drawing.SizeF(201.49F, 16F);
            this.labelFechaC.StylePriority.UseBorders = false;
            this.labelFechaC.StylePriority.UseFont = false;
            this.labelFechaC.StylePriority.UseTextAlignment = false;
            this.labelFechaC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelCodigoC
            // 
            this.labelCodigoC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCodigoC.Dpi = 100F;
            this.labelCodigoC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigoC.LocationFloat = new DevExpress.Utils.PointFloat(344.5234F, 0F);
            this.labelCodigoC.Name = "labelCodigoC";
            this.labelCodigoC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCodigoC.SizeF = new System.Drawing.SizeF(82.06F, 16F);
            this.labelCodigoC.StylePriority.UseBorders = false;
            this.labelCodigoC.StylePriority.UseFont = false;
            this.labelCodigoC.StylePriority.UseTextAlignment = false;
            this.labelCodigoC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelDescripcionC
            // 
            this.labelDescripcionC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelDescripcionC.Dpi = 100F;
            this.labelDescripcionC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcionC.LocationFloat = new DevExpress.Utils.PointFloat(426.5833F, 0F);
            this.labelDescripcionC.Name = "labelDescripcionC";
            this.labelDescripcionC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescripcionC.SizeF = new System.Drawing.SizeF(309.82F, 16F);
            this.labelDescripcionC.StylePriority.UseBorders = false;
            this.labelDescripcionC.StylePriority.UseFont = false;
            this.labelDescripcionC.StylePriority.UseTextAlignment = false;
            this.labelDescripcionC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelPiezasVC
            // 
            this.labelPiezasVC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasVC.Dpi = 100F;
            this.labelPiezasVC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasVC.LocationFloat = new DevExpress.Utils.PointFloat(736.4067F, 0F);
            this.labelPiezasVC.Name = "labelPiezasVC";
            this.labelPiezasVC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasVC.SizeF = new System.Drawing.SizeF(80.66F, 16F);
            this.labelPiezasVC.StylePriority.UseBorders = false;
            this.labelPiezasVC.StylePriority.UseFont = false;
            this.labelPiezasVC.StylePriority.UseTextAlignment = false;
            this.labelPiezasVC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPiezasCC
            // 
            this.labelPiezasCC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasCC.Dpi = 100F;
            this.labelPiezasCC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasCC.LocationFloat = new DevExpress.Utils.PointFloat(817.0666F, 0F);
            this.labelPiezasCC.Name = "labelPiezasCC";
            this.labelPiezasCC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasCC.SizeF = new System.Drawing.SizeF(81.7F, 16F);
            this.labelPiezasCC.StylePriority.UseBorders = false;
            this.labelPiezasCC.StylePriority.UseFont = false;
            this.labelPiezasCC.StylePriority.UseTextAlignment = false;
            this.labelPiezasCC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPiezasPC
            // 
            this.labelPiezasPC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasPC.Dpi = 100F;
            this.labelPiezasPC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasPC.LocationFloat = new DevExpress.Utils.PointFloat(898.7666F, 0F);
            this.labelPiezasPC.Name = "labelPiezasPC";
            this.labelPiezasPC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasPC.SizeF = new System.Drawing.SizeF(93.7F, 16F);
            this.labelPiezasPC.StylePriority.UseBorders = false;
            this.labelPiezasPC.StylePriority.UseFont = false;
            this.labelPiezasPC.StylePriority.UseTextAlignment = false;
            this.labelPiezasPC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelImporteC
            // 
            this.labelImporteC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelImporteC.Dpi = 100F;
            this.labelImporteC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteC.LocationFloat = new DevExpress.Utils.PointFloat(992.4666F, 0F);
            this.labelImporteC.Name = "labelImporteC";
            this.labelImporteC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteC.SizeF = new System.Drawing.SizeF(81.53F, 16F);
            this.labelImporteC.StylePriority.UseBorders = false;
            this.labelImporteC.StylePriority.UseFont = false;
            this.labelImporteC.StylePriority.UseTextAlignment = false;
            this.labelImporteC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.BottomMargin.HeightF = 2.083333F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 43.75F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(992.9666F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(81.03345F, 42.08333F);
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
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(898.7666F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(94.19995F, 42.08333F);
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
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(817.0667F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(81.70001F, 42.08333F);
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
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(736.4084F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(80.65833F, 42.08333F);
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
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(426.5834F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(309.825F, 42.08333F);
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
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(344.5249F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(82.0585F, 42.08333F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Código";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(143.0334F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(201.4915F, 42.08333F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Fecha de Entrega";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0.0001525879F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(143.0332F, 42.08333F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Folio";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCliente});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 16.66667F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // labelCliente
            // 
            this.labelCliente.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCliente.Dpi = 100F;
            this.labelCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.LocationFloat = new DevExpress.Utils.PointFloat(0.4999956F, 0F);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCliente.SizeF = new System.Drawing.SizeF(344.02F, 16F);
            this.labelCliente.StylePriority.UseBorders = false;
            this.labelCliente.StylePriority.UseFont = false;
            this.labelCliente.StylePriority.UseTextAlignment = false;
            this.labelCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelSubTotalC,
            this.labelSubVentaC,
            this.labelSubCambioC,
            this.labelSubPromocionC,
            this.labelSubImporteC});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 16.66667F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // labelSubTotalC
            // 
            this.labelSubTotalC.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSubTotalC.Dpi = 100F;
            this.labelSubTotalC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubTotalC.LocationFloat = new DevExpress.Utils.PointFloat(426.5833F, 0F);
            this.labelSubTotalC.Name = "labelSubTotalC";
            this.labelSubTotalC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubTotalC.SizeF = new System.Drawing.SizeF(309.82F, 16F);
            this.labelSubTotalC.StylePriority.UseBorders = false;
            this.labelSubTotalC.StylePriority.UseFont = false;
            this.labelSubTotalC.StylePriority.UseTextAlignment = false;
            this.labelSubTotalC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelSubVentaC
            // 
            this.labelSubVentaC.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSubVentaC.Dpi = 100F;
            this.labelSubVentaC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubVentaC.LocationFloat = new DevExpress.Utils.PointFloat(736.4067F, 0F);
            this.labelSubVentaC.Name = "labelSubVentaC";
            this.labelSubVentaC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubVentaC.SizeF = new System.Drawing.SizeF(80.66F, 16F);
            this.labelSubVentaC.StylePriority.UseBorders = false;
            this.labelSubVentaC.StylePriority.UseFont = false;
            this.labelSubVentaC.StylePriority.UseTextAlignment = false;
            this.labelSubVentaC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSubCambioC
            // 
            this.labelSubCambioC.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSubCambioC.Dpi = 100F;
            this.labelSubCambioC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubCambioC.LocationFloat = new DevExpress.Utils.PointFloat(817.0666F, 0F);
            this.labelSubCambioC.Name = "labelSubCambioC";
            this.labelSubCambioC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubCambioC.SizeF = new System.Drawing.SizeF(81.7F, 16F);
            this.labelSubCambioC.StylePriority.UseBorders = false;
            this.labelSubCambioC.StylePriority.UseFont = false;
            this.labelSubCambioC.StylePriority.UseTextAlignment = false;
            this.labelSubCambioC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSubPromocionC
            // 
            this.labelSubPromocionC.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSubPromocionC.Dpi = 100F;
            this.labelSubPromocionC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubPromocionC.LocationFloat = new DevExpress.Utils.PointFloat(898.7666F, 0F);
            this.labelSubPromocionC.Name = "labelSubPromocionC";
            this.labelSubPromocionC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubPromocionC.SizeF = new System.Drawing.SizeF(93.7F, 16F);
            this.labelSubPromocionC.StylePriority.UseBorders = false;
            this.labelSubPromocionC.StylePriority.UseFont = false;
            this.labelSubPromocionC.StylePriority.UseTextAlignment = false;
            this.labelSubPromocionC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSubImporteC
            // 
            this.labelSubImporteC.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSubImporteC.Dpi = 100F;
            this.labelSubImporteC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubImporteC.LocationFloat = new DevExpress.Utils.PointFloat(992.4666F, 0F);
            this.labelSubImporteC.Name = "labelSubImporteC";
            this.labelSubImporteC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubImporteC.SizeF = new System.Drawing.SizeF(81.03F, 16F);
            this.labelSubImporteC.StylePriority.UseBorders = false;
            this.labelSubImporteC.StylePriority.UseFont = false;
            this.labelSubImporteC.StylePriority.UseTextAlignment = false;
            this.labelSubImporteC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.ReportFooter.HeightF = 16F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // labelGranTotalC
            // 
            this.labelGranTotalC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranTotalC.Dpi = 100F;
            this.labelGranTotalC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranTotalC.LocationFloat = new DevExpress.Utils.PointFloat(426.5833F, 0F);
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
            this.labelGranVentaC.LocationFloat = new DevExpress.Utils.PointFloat(736.4067F, 0F);
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
            this.labelGranCambioC.LocationFloat = new DevExpress.Utils.PointFloat(817.0667F, 0F);
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
            this.labelGranPromocionC.LocationFloat = new DevExpress.Utils.PointFloat(898.2667F, 0F);
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
            this.labelGranImporteC.LocationFloat = new DevExpress.Utils.PointFloat(992.4666F, 0F);
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
            this.ReportHeader.HeightF = 16F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0.4999956F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1071.5F, 16F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "II - Venta por Cliente";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // SubReporteVentasCliente
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter1,
            this.ReportFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 0, 2);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
