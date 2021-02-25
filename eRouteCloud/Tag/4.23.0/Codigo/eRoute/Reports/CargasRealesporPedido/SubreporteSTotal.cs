using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class SubreporteSTotal : DevExpress.XtraReports.UI.XtraReport
{
    public DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public GroupFooterBand GroupFooter1;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel13;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel1;
    private XRLabel xrLabel14;
    public GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    public XRLabel labelRutaDetalle;
    public XRLabel labelPedidoID;
    public XRLabel xrLabel15;
    public XRLabel labelProductoDetallado;
    public XRLabel labelCumplimientoDetallado;
    public XRLabel labelImporteFDetallado;
    public XRLabel labelFaltantesDetallado;
    public XRLabel labelImporteRCDetallado;
    public XRLabel labelPiezasDetalle;
    public XRLabel labelImportePDetallado;
    public XRLabel labelCantidadPDetallado;
    public XRLabel labelPromocionesDetallado;
    public XRLabel labelCambiosDetallado;
    public XRLabel labelVentaDetallado;
    public XRLabel labelUMDetallado;
    public XRLabel labelSKUDetallado;
    public GroupFooterBand GroupFooter2;
    public XRLabel labelCumplimientoS;
    public XRLabel labelImporteFS;
    public XRLabel labelFaltantesS;
    public XRLabel labelImporteRCS;
    public XRLabel labelPiezasS;
    public XRLabel labelImportePS;
    public XRLabel labelCantidadPS;
    public XRLabel xrLabel35;
    public XRLabel labelPromocionesS;
    public XRLabel labelCambiosS;
    public XRLabel labelVentaS;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubreporteSTotal()
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
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelRutaDetalle = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPedidoID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProductoDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCumplimientoDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteFDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFaltantesDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteRCDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasDetalle = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImportePDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCantidadPDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPromocionesDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCambiosDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVentaDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelUMDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSKUDetallado = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelCumplimientoS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteFS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFaltantesS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteRCS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImportePS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCantidadPS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPromocionesS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCambiosS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVentaS = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelProductoDetallado,
            this.labelCumplimientoDetallado,
            this.labelImporteFDetallado,
            this.labelFaltantesDetallado,
            this.labelImporteRCDetallado,
            this.labelPiezasDetalle,
            this.labelImportePDetallado,
            this.labelCantidadPDetallado,
            this.labelPromocionesDetallado,
            this.labelCambiosDetallado,
            this.labelVentaDetallado,
            this.labelUMDetallado,
            this.labelSKUDetallado});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 15.625F;
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
            this.BottomMargin.HeightF = 0.5681356F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCumplimientoS,
            this.labelImporteFS,
            this.labelFaltantesS,
            this.labelImporteRCS,
            this.labelPiezasS,
            this.labelImportePS,
            this.labelCantidadPS,
            this.xrLabel35,
            this.labelPromocionesS,
            this.labelCambiosS,
            this.labelVentaS});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 17.70833F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.StylePriority.UseBorders = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel1,
            this.xrLabel14});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 44.79167F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(982.7036F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(91.04633F, 40.625F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Cumplimiento";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(845.3193F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(67.28247F, 40.625F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Faltantes";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(912.6018F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(70.10187F, 40.625F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Importe Faltante";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(774.7175F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(70.60181F, 40.625F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Importe Real Cargado";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(703.3842F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(71.33325F, 40.625F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Piezas Real Cargado";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(633.2083F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(70.1759F, 40.625F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Importe Pedido";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(573.3333F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(59.875F, 40.625F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Cantidad Pedido (Piezas)";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(494.375F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(78.95831F, 40.625F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Promociones";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(439.7083F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(54.66675F, 40.625F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Cambios";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(379.2917F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(60.41663F, 40.625F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Venta (Pedidos)";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(314.8332F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(64.45847F, 40.625F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Unidad de Medida\r\n";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(97.62496F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(217.2083F, 40.625F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Producto";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0.25F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(97.37497F, 40.625F);
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "SKU";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelPedidoID,
            this.xrLabel15});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 16.66667F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelRutaDetalle});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 17.70833F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // labelRutaDetalle
            // 
            this.labelRutaDetalle.Dpi = 100F;
            this.labelRutaDetalle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRutaDetalle.LocationFloat = new DevExpress.Utils.PointFloat(0.750061F, 0F);
            this.labelRutaDetalle.Name = "labelRutaDetalle";
            this.labelRutaDetalle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelRutaDetalle.SizeF = new System.Drawing.SizeF(314.0832F, 13.95833F);
            this.labelRutaDetalle.StylePriority.UseFont = false;
            this.labelRutaDetalle.StylePriority.UseTextAlignment = false;
            this.labelRutaDetalle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelPedidoID
            // 
            this.labelPedidoID.Dpi = 100F;
            this.labelPedidoID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPedidoID.LocationFloat = new DevExpress.Utils.PointFloat(97.62496F, 0F);
            this.labelPedidoID.Name = "labelPedidoID";
            this.labelPedidoID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPedidoID.SizeF = new System.Drawing.SizeF(217.2083F, 13.95833F);
            this.labelPedidoID.StylePriority.UseFont = false;
            this.labelPedidoID.StylePriority.UseTextAlignment = false;
            this.labelPedidoID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0.2499924F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(97.37497F, 13.95833F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelProductoDetallado
            // 
            this.labelProductoDetallado.Dpi = 100F;
            this.labelProductoDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductoDetallado.LocationFloat = new DevExpress.Utils.PointFloat(97.37501F, 0.8333349F);
            this.labelProductoDetallado.Name = "labelProductoDetallado";
            this.labelProductoDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProductoDetallado.SizeF = new System.Drawing.SizeF(217.7083F, 13.95833F);
            this.labelProductoDetallado.StylePriority.UseFont = false;
            this.labelProductoDetallado.StylePriority.UseTextAlignment = false;
            this.labelProductoDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelCumplimientoDetallado
            // 
            this.labelCumplimientoDetallado.Dpi = 100F;
            this.labelCumplimientoDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCumplimientoDetallado.LocationFloat = new DevExpress.Utils.PointFloat(982.9537F, 0.8333349F);
            this.labelCumplimientoDetallado.Name = "labelCumplimientoDetallado";
            this.labelCumplimientoDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCumplimientoDetallado.SizeF = new System.Drawing.SizeF(91.04639F, 13.95833F);
            this.labelCumplimientoDetallado.StylePriority.UseFont = false;
            this.labelCumplimientoDetallado.StylePriority.UseTextAlignment = false;
            this.labelCumplimientoDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteFDetallado
            // 
            this.labelImporteFDetallado.Dpi = 100F;
            this.labelImporteFDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteFDetallado.LocationFloat = new DevExpress.Utils.PointFloat(912.8519F, 0.8333349F);
            this.labelImporteFDetallado.Name = "labelImporteFDetallado";
            this.labelImporteFDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteFDetallado.SizeF = new System.Drawing.SizeF(70.10181F, 13.95833F);
            this.labelImporteFDetallado.StylePriority.UseFont = false;
            this.labelImporteFDetallado.StylePriority.UseTextAlignment = false;
            this.labelImporteFDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelFaltantesDetallado
            // 
            this.labelFaltantesDetallado.Dpi = 100F;
            this.labelFaltantesDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaltantesDetallado.LocationFloat = new DevExpress.Utils.PointFloat(845.5694F, 0.8333349F);
            this.labelFaltantesDetallado.Name = "labelFaltantesDetallado";
            this.labelFaltantesDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFaltantesDetallado.SizeF = new System.Drawing.SizeF(67.28247F, 13.95833F);
            this.labelFaltantesDetallado.StylePriority.UseFont = false;
            this.labelFaltantesDetallado.StylePriority.UseTextAlignment = false;
            this.labelFaltantesDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteRCDetallado
            // 
            this.labelImporteRCDetallado.Dpi = 100F;
            this.labelImporteRCDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteRCDetallado.LocationFloat = new DevExpress.Utils.PointFloat(774.9677F, 0.8333349F);
            this.labelImporteRCDetallado.Name = "labelImporteRCDetallado";
            this.labelImporteRCDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteRCDetallado.SizeF = new System.Drawing.SizeF(70.60175F, 13.95833F);
            this.labelImporteRCDetallado.StylePriority.UseFont = false;
            this.labelImporteRCDetallado.StylePriority.UseTextAlignment = false;
            this.labelImporteRCDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelPiezasDetalle
            // 
            this.labelPiezasDetalle.Dpi = 100F;
            this.labelPiezasDetalle.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasDetalle.LocationFloat = new DevExpress.Utils.PointFloat(703.6344F, 0.8333349F);
            this.labelPiezasDetalle.Name = "labelPiezasDetalle";
            this.labelPiezasDetalle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasDetalle.SizeF = new System.Drawing.SizeF(71.33325F, 13.95833F);
            this.labelPiezasDetalle.StylePriority.UseFont = false;
            this.labelPiezasDetalle.StylePriority.UseTextAlignment = false;
            this.labelPiezasDetalle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImportePDetallado
            // 
            this.labelImportePDetallado.Dpi = 100F;
            this.labelImportePDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImportePDetallado.LocationFloat = new DevExpress.Utils.PointFloat(633.4584F, 0.8333349F);
            this.labelImportePDetallado.Name = "labelImportePDetallado";
            this.labelImportePDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImportePDetallado.SizeF = new System.Drawing.SizeF(70.17596F, 13.95833F);
            this.labelImportePDetallado.StylePriority.UseFont = false;
            this.labelImportePDetallado.StylePriority.UseTextAlignment = false;
            this.labelImportePDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCantidadPDetallado
            // 
            this.labelCantidadPDetallado.Dpi = 100F;
            this.labelCantidadPDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidadPDetallado.LocationFloat = new DevExpress.Utils.PointFloat(573.5835F, 0.8333349F);
            this.labelCantidadPDetallado.Name = "labelCantidadPDetallado";
            this.labelCantidadPDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidadPDetallado.SizeF = new System.Drawing.SizeF(59.87494F, 13.95833F);
            this.labelCantidadPDetallado.StylePriority.UseFont = false;
            this.labelCantidadPDetallado.StylePriority.UseTextAlignment = false;
            this.labelCantidadPDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelPromocionesDetallado
            // 
            this.labelPromocionesDetallado.Dpi = 100F;
            this.labelPromocionesDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromocionesDetallado.LocationFloat = new DevExpress.Utils.PointFloat(494.6251F, 0.8333349F);
            this.labelPromocionesDetallado.Name = "labelPromocionesDetallado";
            this.labelPromocionesDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPromocionesDetallado.SizeF = new System.Drawing.SizeF(78.95837F, 13.95833F);
            this.labelPromocionesDetallado.StylePriority.UseFont = false;
            this.labelPromocionesDetallado.StylePriority.UseTextAlignment = false;
            this.labelPromocionesDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCambiosDetallado
            // 
            this.labelCambiosDetallado.Dpi = 100F;
            this.labelCambiosDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCambiosDetallado.LocationFloat = new DevExpress.Utils.PointFloat(439.9583F, 0.8333349F);
            this.labelCambiosDetallado.Name = "labelCambiosDetallado";
            this.labelCambiosDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCambiosDetallado.SizeF = new System.Drawing.SizeF(54.66675F, 13.95833F);
            this.labelCambiosDetallado.StylePriority.UseFont = false;
            this.labelCambiosDetallado.StylePriority.UseTextAlignment = false;
            this.labelCambiosDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelVentaDetallado
            // 
            this.labelVentaDetallado.Dpi = 100F;
            this.labelVentaDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentaDetallado.LocationFloat = new DevExpress.Utils.PointFloat(379.5417F, 0.8333349F);
            this.labelVentaDetallado.Name = "labelVentaDetallado";
            this.labelVentaDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVentaDetallado.SizeF = new System.Drawing.SizeF(60.4166F, 13.95833F);
            this.labelVentaDetallado.StylePriority.UseFont = false;
            this.labelVentaDetallado.StylePriority.UseTextAlignment = false;
            this.labelVentaDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelUMDetallado
            // 
            this.labelUMDetallado.Dpi = 100F;
            this.labelUMDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUMDetallado.LocationFloat = new DevExpress.Utils.PointFloat(315.0833F, 0.8333349F);
            this.labelUMDetallado.Multiline = true;
            this.labelUMDetallado.Name = "labelUMDetallado";
            this.labelUMDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelUMDetallado.SizeF = new System.Drawing.SizeF(64.45847F, 13.95833F);
            this.labelUMDetallado.StylePriority.UseFont = false;
            this.labelUMDetallado.StylePriority.UseTextAlignment = false;
            this.labelUMDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelSKUDetallado
            // 
            this.labelSKUDetallado.Dpi = 100F;
            this.labelSKUDetallado.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSKUDetallado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.8333349F);
            this.labelSKUDetallado.Name = "labelSKUDetallado";
            this.labelSKUDetallado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSKUDetallado.SizeF = new System.Drawing.SizeF(97.37498F, 13.95833F);
            this.labelSKUDetallado.StylePriority.UseFont = false;
            this.labelSKUDetallado.StylePriority.UseTextAlignment = false;
            this.labelSKUDetallado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 0F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // labelCumplimientoS
            // 
            this.labelCumplimientoS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelCumplimientoS.Dpi = 100F;
            this.labelCumplimientoS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCumplimientoS.LocationFloat = new DevExpress.Utils.PointFloat(982.9536F, 0F);
            this.labelCumplimientoS.Name = "labelCumplimientoS";
            this.labelCumplimientoS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCumplimientoS.SizeF = new System.Drawing.SizeF(91.04639F, 13.95833F);
            this.labelCumplimientoS.StylePriority.UseBorders = false;
            this.labelCumplimientoS.StylePriority.UseFont = false;
            this.labelCumplimientoS.StylePriority.UseTextAlignment = false;
            this.labelCumplimientoS.Text = "0";
            this.labelCumplimientoS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteFS
            // 
            this.labelImporteFS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelImporteFS.Dpi = 100F;
            this.labelImporteFS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteFS.LocationFloat = new DevExpress.Utils.PointFloat(912.8518F, 0F);
            this.labelImporteFS.Name = "labelImporteFS";
            this.labelImporteFS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteFS.SizeF = new System.Drawing.SizeF(70.10181F, 13.95833F);
            this.labelImporteFS.StylePriority.UseBorders = false;
            this.labelImporteFS.StylePriority.UseFont = false;
            this.labelImporteFS.StylePriority.UseTextAlignment = false;
            this.labelImporteFS.Text = "0";
            this.labelImporteFS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelFaltantesS
            // 
            this.labelFaltantesS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelFaltantesS.Dpi = 100F;
            this.labelFaltantesS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaltantesS.LocationFloat = new DevExpress.Utils.PointFloat(845.5692F, 0F);
            this.labelFaltantesS.Name = "labelFaltantesS";
            this.labelFaltantesS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFaltantesS.SizeF = new System.Drawing.SizeF(67.28247F, 13.95833F);
            this.labelFaltantesS.StylePriority.UseBorders = false;
            this.labelFaltantesS.StylePriority.UseFont = false;
            this.labelFaltantesS.StylePriority.UseTextAlignment = false;
            this.labelFaltantesS.Text = "0";
            this.labelFaltantesS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImporteRCS
            // 
            this.labelImporteRCS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelImporteRCS.Dpi = 100F;
            this.labelImporteRCS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteRCS.LocationFloat = new DevExpress.Utils.PointFloat(774.9677F, 0F);
            this.labelImporteRCS.Name = "labelImporteRCS";
            this.labelImporteRCS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteRCS.SizeF = new System.Drawing.SizeF(70.60175F, 13.95833F);
            this.labelImporteRCS.StylePriority.UseBorders = false;
            this.labelImporteRCS.StylePriority.UseFont = false;
            this.labelImporteRCS.StylePriority.UseTextAlignment = false;
            this.labelImporteRCS.Text = "0";
            this.labelImporteRCS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelPiezasS
            // 
            this.labelPiezasS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelPiezasS.Dpi = 100F;
            this.labelPiezasS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasS.LocationFloat = new DevExpress.Utils.PointFloat(703.6344F, 0F);
            this.labelPiezasS.Name = "labelPiezasS";
            this.labelPiezasS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasS.SizeF = new System.Drawing.SizeF(71.33325F, 13.95833F);
            this.labelPiezasS.StylePriority.UseBorders = false;
            this.labelPiezasS.StylePriority.UseFont = false;
            this.labelPiezasS.StylePriority.UseTextAlignment = false;
            this.labelPiezasS.Text = "0";
            this.labelPiezasS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelImportePS
            // 
            this.labelImportePS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelImportePS.Dpi = 100F;
            this.labelImportePS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImportePS.LocationFloat = new DevExpress.Utils.PointFloat(633.4583F, 0F);
            this.labelImportePS.Name = "labelImportePS";
            this.labelImportePS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImportePS.SizeF = new System.Drawing.SizeF(70.17596F, 13.95833F);
            this.labelImportePS.StylePriority.UseBorders = false;
            this.labelImportePS.StylePriority.UseFont = false;
            this.labelImportePS.StylePriority.UseTextAlignment = false;
            this.labelImportePS.Text = "0";
            this.labelImportePS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCantidadPS
            // 
            this.labelCantidadPS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelCantidadPS.Dpi = 100F;
            this.labelCantidadPS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidadPS.LocationFloat = new DevExpress.Utils.PointFloat(573.5835F, 0F);
            this.labelCantidadPS.Name = "labelCantidadPS";
            this.labelCantidadPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidadPS.SizeF = new System.Drawing.SizeF(59.87494F, 13.95833F);
            this.labelCantidadPS.StylePriority.UseBorders = false;
            this.labelCantidadPS.StylePriority.UseFont = false;
            this.labelCantidadPS.StylePriority.UseTextAlignment = false;
            this.labelCantidadPS.Text = "0";
            this.labelCantidadPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel35
            // 
            this.xrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(300.5201F, 0F);
            this.xrLabel35.Multiline = true;
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(79.02158F, 13.95833F);
            this.xrLabel35.StylePriority.UseBorders = false;
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelPromocionesS
            // 
            this.labelPromocionesS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelPromocionesS.Dpi = 100F;
            this.labelPromocionesS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromocionesS.LocationFloat = new DevExpress.Utils.PointFloat(494.625F, 0F);
            this.labelPromocionesS.Name = "labelPromocionesS";
            this.labelPromocionesS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPromocionesS.SizeF = new System.Drawing.SizeF(78.95837F, 13.95833F);
            this.labelPromocionesS.StylePriority.UseBorders = false;
            this.labelPromocionesS.StylePriority.UseFont = false;
            this.labelPromocionesS.StylePriority.UseTextAlignment = false;
            this.labelPromocionesS.Text = "0";
            this.labelPromocionesS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelCambiosS
            // 
            this.labelCambiosS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelCambiosS.Dpi = 100F;
            this.labelCambiosS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCambiosS.LocationFloat = new DevExpress.Utils.PointFloat(439.9583F, 0F);
            this.labelCambiosS.Name = "labelCambiosS";
            this.labelCambiosS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCambiosS.SizeF = new System.Drawing.SizeF(54.66675F, 13.95833F);
            this.labelCambiosS.StylePriority.UseBorders = false;
            this.labelCambiosS.StylePriority.UseFont = false;
            this.labelCambiosS.StylePriority.UseTextAlignment = false;
            this.labelCambiosS.Text = "0";
            this.labelCambiosS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // labelVentaS
            // 
            this.labelVentaS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelVentaS.Dpi = 100F;
            this.labelVentaS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentaS.LocationFloat = new DevExpress.Utils.PointFloat(379.5417F, 0F);
            this.labelVentaS.Name = "labelVentaS";
            this.labelVentaS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVentaS.SizeF = new System.Drawing.SizeF(60.4166F, 13.95833F);
            this.labelVentaS.StylePriority.UseBorders = false;
            this.labelVentaS.StylePriority.UseFont = false;
            this.labelVentaS.StylePriority.UseTextAlignment = false;
            this.labelVentaS.Text = "0";
            this.labelVentaS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // SubreporteSTotal
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupFooter2});
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
