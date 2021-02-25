using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class SubreporteGral : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public GroupFooterBand GroupFooter1;
    public XRLabel labelSKUResumido;
    public XRLabel labelProductoResumido;
    public XRLabel labelUMResumido;
    public XRLabel labelVentaResumido;
    public XRLabel labelCambiosResumido;
    public XRLabel labelPromocionesResumido;
    public XRLabel labelCantidadPResumido;
    public XRLabel labelImportePResumido;
    public XRLabel labelPiezasResumido;
    public XRLabel labelImporteRCResumido;
    public XRLabel labelFaltantesResumido;
    public XRLabel labelImporteFResumido;
    public XRLabel labelCumplimientoResumido;
    public XRLabel labelCumplimientoT;
    public XRLabel labelImporteFT;
    public XRLabel labelFaltantesT;
    public XRLabel labelImporteRCT;
    public XRLabel labelPiezasT;
    public XRLabel labelImportePT;
    public XRLabel labelCantidadPT;
    public XRLabel labelPromocionesT;
    public XRLabel labelCambiosT;
    public XRLabel labelVentaT;
    private XRLabel xrLabel33;
    private PageHeaderBand PageHeader;
    public XRLabel xrLabel16;
    private XRLabel xrLabel26;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel22;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel24;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubreporteGral()
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
            this.labelSKUResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProductoResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelUMResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVentaResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCambiosResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPromocionesResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCantidadPResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImportePResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteRCResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFaltantesResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteFResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCumplimientoResumido = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelCumplimientoT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteFT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFaltantesT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteRCT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImportePT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCantidadPT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPromocionesT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCambiosT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVentaT = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelSKUResumido,
            this.labelProductoResumido,
            this.labelUMResumido,
            this.labelVentaResumido,
            this.labelCambiosResumido,
            this.labelPromocionesResumido,
            this.labelCantidadPResumido,
            this.labelImportePResumido,
            this.labelPiezasResumido,
            this.labelImporteRCResumido,
            this.labelFaltantesResumido,
            this.labelImporteFResumido,
            this.labelCumplimientoResumido});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 15.625F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelSKUResumido
            // 
            this.labelSKUResumido.Dpi = 100F;
            this.labelSKUResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSKUResumido.LocationFloat = new DevExpress.Utils.PointFloat(1.24987F, 0F);
            this.labelSKUResumido.Name = "labelSKUResumido";
            this.labelSKUResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSKUResumido.SizeF = new System.Drawing.SizeF(97.37498F, 13.95833F);
            this.labelSKUResumido.StylePriority.UseFont = false;
            this.labelSKUResumido.StylePriority.UseTextAlignment = false;
            this.labelSKUResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelProductoResumido
            // 
            this.labelProductoResumido.Dpi = 100F;
            this.labelProductoResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductoResumido.LocationFloat = new DevExpress.Utils.PointFloat(98.62485F, 0F);
            this.labelProductoResumido.Name = "labelProductoResumido";
            this.labelProductoResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProductoResumido.SizeF = new System.Drawing.SizeF(217.7083F, 13.95833F);
            this.labelProductoResumido.StylePriority.UseFont = false;
            this.labelProductoResumido.StylePriority.UseTextAlignment = false;
            this.labelProductoResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelUMResumido
            // 
            this.labelUMResumido.Dpi = 100F;
            this.labelUMResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUMResumido.LocationFloat = new DevExpress.Utils.PointFloat(316.3333F, 0F);
            this.labelUMResumido.Multiline = true;
            this.labelUMResumido.Name = "labelUMResumido";
            this.labelUMResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelUMResumido.SizeF = new System.Drawing.SizeF(64.45847F, 13.95833F);
            this.labelUMResumido.StylePriority.UseFont = false;
            this.labelUMResumido.StylePriority.UseTextAlignment = false;
            this.labelUMResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelVentaResumido
            // 
            this.labelVentaResumido.Dpi = 100F;
            this.labelVentaResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentaResumido.LocationFloat = new DevExpress.Utils.PointFloat(380.7918F, 0F);
            this.labelVentaResumido.Name = "labelVentaResumido";
            this.labelVentaResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVentaResumido.SizeF = new System.Drawing.SizeF(60.4166F, 13.95833F);
            this.labelVentaResumido.StylePriority.UseFont = false;
            this.labelVentaResumido.StylePriority.UseTextAlignment = false;
            this.labelVentaResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCambiosResumido
            // 
            this.labelCambiosResumido.Dpi = 100F;
            this.labelCambiosResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCambiosResumido.LocationFloat = new DevExpress.Utils.PointFloat(441.2084F, 0F);
            this.labelCambiosResumido.Name = "labelCambiosResumido";
            this.labelCambiosResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCambiosResumido.SizeF = new System.Drawing.SizeF(54.66675F, 13.95833F);
            this.labelCambiosResumido.StylePriority.UseFont = false;
            this.labelCambiosResumido.StylePriority.UseTextAlignment = false;
            this.labelCambiosResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelPromocionesResumido
            // 
            this.labelPromocionesResumido.Dpi = 100F;
            this.labelPromocionesResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromocionesResumido.LocationFloat = new DevExpress.Utils.PointFloat(495.8751F, 0F);
            this.labelPromocionesResumido.Name = "labelPromocionesResumido";
            this.labelPromocionesResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPromocionesResumido.SizeF = new System.Drawing.SizeF(78.95837F, 13.95833F);
            this.labelPromocionesResumido.StylePriority.UseFont = false;
            this.labelPromocionesResumido.StylePriority.UseTextAlignment = false;
            this.labelPromocionesResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCantidadPResumido
            // 
            this.labelCantidadPResumido.Dpi = 100F;
            this.labelCantidadPResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidadPResumido.LocationFloat = new DevExpress.Utils.PointFloat(574.8335F, 0F);
            this.labelCantidadPResumido.Name = "labelCantidadPResumido";
            this.labelCantidadPResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidadPResumido.SizeF = new System.Drawing.SizeF(59.87494F, 13.95833F);
            this.labelCantidadPResumido.StylePriority.UseFont = false;
            this.labelCantidadPResumido.StylePriority.UseTextAlignment = false;
            this.labelCantidadPResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImportePResumido
            // 
            this.labelImportePResumido.Dpi = 100F;
            this.labelImportePResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImportePResumido.LocationFloat = new DevExpress.Utils.PointFloat(634.7084F, 0F);
            this.labelImportePResumido.Name = "labelImportePResumido";
            this.labelImportePResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImportePResumido.SizeF = new System.Drawing.SizeF(70.17596F, 13.95833F);
            this.labelImportePResumido.StylePriority.UseFont = false;
            this.labelImportePResumido.StylePriority.UseTextAlignment = false;
            this.labelImportePResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelPiezasResumido
            // 
            this.labelPiezasResumido.Dpi = 100F;
            this.labelPiezasResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasResumido.LocationFloat = new DevExpress.Utils.PointFloat(704.8844F, 0F);
            this.labelPiezasResumido.Name = "labelPiezasResumido";
            this.labelPiezasResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasResumido.SizeF = new System.Drawing.SizeF(71.33325F, 13.95833F);
            this.labelPiezasResumido.StylePriority.UseFont = false;
            this.labelPiezasResumido.StylePriority.UseTextAlignment = false;
            this.labelPiezasResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteRCResumido
            // 
            this.labelImporteRCResumido.Dpi = 100F;
            this.labelImporteRCResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteRCResumido.LocationFloat = new DevExpress.Utils.PointFloat(776.2177F, 0F);
            this.labelImporteRCResumido.Name = "labelImporteRCResumido";
            this.labelImporteRCResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteRCResumido.SizeF = new System.Drawing.SizeF(70.60175F, 13.95833F);
            this.labelImporteRCResumido.StylePriority.UseFont = false;
            this.labelImporteRCResumido.StylePriority.UseTextAlignment = false;
            this.labelImporteRCResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelFaltantesResumido
            // 
            this.labelFaltantesResumido.Dpi = 100F;
            this.labelFaltantesResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaltantesResumido.LocationFloat = new DevExpress.Utils.PointFloat(846.8192F, 0F);
            this.labelFaltantesResumido.Name = "labelFaltantesResumido";
            this.labelFaltantesResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFaltantesResumido.SizeF = new System.Drawing.SizeF(67.28247F, 13.95833F);
            this.labelFaltantesResumido.StylePriority.UseFont = false;
            this.labelFaltantesResumido.StylePriority.UseTextAlignment = false;
            this.labelFaltantesResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteFResumido
            // 
            this.labelImporteFResumido.Dpi = 100F;
            this.labelImporteFResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteFResumido.LocationFloat = new DevExpress.Utils.PointFloat(914.1017F, 0F);
            this.labelImporteFResumido.Name = "labelImporteFResumido";
            this.labelImporteFResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteFResumido.SizeF = new System.Drawing.SizeF(70.10181F, 13.95833F);
            this.labelImporteFResumido.StylePriority.UseFont = false;
            this.labelImporteFResumido.StylePriority.UseTextAlignment = false;
            this.labelImporteFResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCumplimientoResumido
            // 
            this.labelCumplimientoResumido.Dpi = 100F;
            this.labelCumplimientoResumido.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCumplimientoResumido.LocationFloat = new DevExpress.Utils.PointFloat(984.7036F, 0F);
            this.labelCumplimientoResumido.Name = "labelCumplimientoResumido";
            this.labelCumplimientoResumido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCumplimientoResumido.SizeF = new System.Drawing.SizeF(89.29645F, 13.95833F);
            this.labelCumplimientoResumido.StylePriority.UseFont = false;
            this.labelCumplimientoResumido.StylePriority.UseTextAlignment = false;
            this.labelCumplimientoResumido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.BottomMargin.HeightF = 0.5681356F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCumplimientoT,
            this.labelImporteFT,
            this.labelFaltantesT,
            this.labelImporteRCT,
            this.labelPiezasT,
            this.labelImportePT,
            this.labelCantidadPT,
            this.labelPromocionesT,
            this.labelCambiosT,
            this.labelVentaT,
            this.xrLabel33});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 18.75F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.StylePriority.UseBorders = false;
            // 
            // labelCumplimientoT
            // 
            this.labelCumplimientoT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelCumplimientoT.Dpi = 100F;
            this.labelCumplimientoT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCumplimientoT.LocationFloat = new DevExpress.Utils.PointFloat(983.9539F, 0F);
            this.labelCumplimientoT.Name = "labelCumplimientoT";
            this.labelCumplimientoT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCumplimientoT.SizeF = new System.Drawing.SizeF(90.04614F, 15F);
            this.labelCumplimientoT.StylePriority.UseBorders = false;
            this.labelCumplimientoT.StylePriority.UseFont = false;
            this.labelCumplimientoT.StylePriority.UseTextAlignment = false;
            this.labelCumplimientoT.Text = "0";
            this.labelCumplimientoT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteFT
            // 
            this.labelImporteFT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelImporteFT.Dpi = 100F;
            this.labelImporteFT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteFT.LocationFloat = new DevExpress.Utils.PointFloat(913.8521F, 0F);
            this.labelImporteFT.Name = "labelImporteFT";
            this.labelImporteFT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteFT.SizeF = new System.Drawing.SizeF(70.10181F, 15F);
            this.labelImporteFT.StylePriority.UseBorders = false;
            this.labelImporteFT.StylePriority.UseFont = false;
            this.labelImporteFT.StylePriority.UseTextAlignment = false;
            this.labelImporteFT.Text = "0";
            this.labelImporteFT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelFaltantesT
            // 
            this.labelFaltantesT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelFaltantesT.Dpi = 100F;
            this.labelFaltantesT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaltantesT.LocationFloat = new DevExpress.Utils.PointFloat(846.5696F, 0F);
            this.labelFaltantesT.Name = "labelFaltantesT";
            this.labelFaltantesT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFaltantesT.SizeF = new System.Drawing.SizeF(67.28247F, 15F);
            this.labelFaltantesT.StylePriority.UseBorders = false;
            this.labelFaltantesT.StylePriority.UseFont = false;
            this.labelFaltantesT.StylePriority.UseTextAlignment = false;
            this.labelFaltantesT.Text = "0";
            this.labelFaltantesT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteRCT
            // 
            this.labelImporteRCT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelImporteRCT.Dpi = 100F;
            this.labelImporteRCT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteRCT.LocationFloat = new DevExpress.Utils.PointFloat(775.9678F, 0F);
            this.labelImporteRCT.Name = "labelImporteRCT";
            this.labelImporteRCT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteRCT.SizeF = new System.Drawing.SizeF(70.60175F, 15F);
            this.labelImporteRCT.StylePriority.UseBorders = false;
            this.labelImporteRCT.StylePriority.UseFont = false;
            this.labelImporteRCT.StylePriority.UseTextAlignment = false;
            this.labelImporteRCT.Text = "0";
            this.labelImporteRCT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelPiezasT
            // 
            this.labelPiezasT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelPiezasT.Dpi = 100F;
            this.labelPiezasT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasT.LocationFloat = new DevExpress.Utils.PointFloat(704.6346F, 0F);
            this.labelPiezasT.Name = "labelPiezasT";
            this.labelPiezasT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasT.SizeF = new System.Drawing.SizeF(71.33325F, 15F);
            this.labelPiezasT.StylePriority.UseBorders = false;
            this.labelPiezasT.StylePriority.UseFont = false;
            this.labelPiezasT.StylePriority.UseTextAlignment = false;
            this.labelPiezasT.Text = "0";
            this.labelPiezasT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImportePT
            // 
            this.labelImportePT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelImportePT.Dpi = 100F;
            this.labelImportePT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImportePT.LocationFloat = new DevExpress.Utils.PointFloat(634.4586F, 0F);
            this.labelImportePT.Name = "labelImportePT";
            this.labelImportePT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImportePT.SizeF = new System.Drawing.SizeF(70.17596F, 15F);
            this.labelImportePT.StylePriority.UseBorders = false;
            this.labelImportePT.StylePriority.UseFont = false;
            this.labelImportePT.StylePriority.UseTextAlignment = false;
            this.labelImportePT.Text = "0";
            this.labelImportePT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCantidadPT
            // 
            this.labelCantidadPT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelCantidadPT.Dpi = 100F;
            this.labelCantidadPT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidadPT.LocationFloat = new DevExpress.Utils.PointFloat(574.5837F, 0F);
            this.labelCantidadPT.Name = "labelCantidadPT";
            this.labelCantidadPT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidadPT.SizeF = new System.Drawing.SizeF(59.87494F, 15F);
            this.labelCantidadPT.StylePriority.UseBorders = false;
            this.labelCantidadPT.StylePriority.UseFont = false;
            this.labelCantidadPT.StylePriority.UseTextAlignment = false;
            this.labelCantidadPT.Text = "0";
            this.labelCantidadPT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelPromocionesT
            // 
            this.labelPromocionesT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelPromocionesT.Dpi = 100F;
            this.labelPromocionesT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromocionesT.LocationFloat = new DevExpress.Utils.PointFloat(495.6253F, 0F);
            this.labelPromocionesT.Name = "labelPromocionesT";
            this.labelPromocionesT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPromocionesT.SizeF = new System.Drawing.SizeF(78.95837F, 15F);
            this.labelPromocionesT.StylePriority.UseBorders = false;
            this.labelPromocionesT.StylePriority.UseFont = false;
            this.labelPromocionesT.StylePriority.UseTextAlignment = false;
            this.labelPromocionesT.Text = "0";
            this.labelPromocionesT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCambiosT
            // 
            this.labelCambiosT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelCambiosT.Dpi = 100F;
            this.labelCambiosT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCambiosT.LocationFloat = new DevExpress.Utils.PointFloat(440.9586F, 0F);
            this.labelCambiosT.Name = "labelCambiosT";
            this.labelCambiosT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCambiosT.SizeF = new System.Drawing.SizeF(54.66675F, 15F);
            this.labelCambiosT.StylePriority.UseBorders = false;
            this.labelCambiosT.StylePriority.UseFont = false;
            this.labelCambiosT.StylePriority.UseTextAlignment = false;
            this.labelCambiosT.Text = "0";
            this.labelCambiosT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelVentaT
            // 
            this.labelVentaT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelVentaT.Dpi = 100F;
            this.labelVentaT.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentaT.LocationFloat = new DevExpress.Utils.PointFloat(380.542F, 0F);
            this.labelVentaT.Name = "labelVentaT";
            this.labelVentaT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVentaT.SizeF = new System.Drawing.SizeF(60.4166F, 15F);
            this.labelVentaT.StylePriority.UseBorders = false;
            this.labelVentaT.StylePriority.UseFont = false;
            this.labelVentaT.StylePriority.UseTextAlignment = false;
            this.labelVentaT.Text = "0";
            this.labelVentaT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(300.8841F, 0F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(79.65784F, 15F);
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "GRAN TOTAL";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel26,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel22,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel24,
            this.xrLabel28,
            this.xrLabel29,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel32});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 100F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(0.75F, 6.078056F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(1072.5F, 23F);
            this.xrLabel16.StylePriority.UseBorders = false;
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Resumen Cargas Reales\r\n";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(0.999926F, 42.53636F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(97.37496F, 51.38556F);
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "SKU";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(98.37489F, 42.53636F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(217.2083F, 51.38556F);
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Producto";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(315.5832F, 42.53636F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(64.45847F, 51.38556F);
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Unidad de Medida\r\n";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(380.0417F, 42.53636F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(60.41663F, 51.38556F);
            this.xrLabel17.StylePriority.UseBorders = false;
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Venta (Pedidos)";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(440.4583F, 42.53636F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(54.66675F, 51.38556F);
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Cambios";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(495.125F, 42.53636F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(78.95828F, 51.38556F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Promociones";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(574.0833F, 42.53638F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(59.87506F, 51.38556F);
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Cantidad Pedido (Piezas)";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(633.9583F, 42.53636F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(70.1759F, 51.38556F);
            this.xrLabel24.StylePriority.UseBorders = false;
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Importe Pedido";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(704.1342F, 42.53636F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(71.33319F, 51.38556F);
            this.xrLabel28.StylePriority.UseBorders = false;
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Piezas Real Cargado";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(775.4675F, 42.53636F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(70.60187F, 51.38556F);
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "Importe Real Cargado";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(846.0692F, 42.53636F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(67.28241F, 51.38556F);
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "Faltantes";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(913.3517F, 42.53636F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(70.10187F, 51.38556F);
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Importe Faltante";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(983.4536F, 42.53636F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(89.54608F, 51.38556F);
            this.xrLabel32.StylePriority.UseBorders = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Cumplimiento";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // SubreporteGral
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.PageHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 0, 1);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
