using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for report_Principal
/// </summary>
public class PrinSubPrevetaDetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLine xrLine4;
    private XRLabel xrLabel52;
    private XRLabel xrLabel49;
    private XRLabel xrLabel48;
    private XRLabel xrLabel47;
    private XRLabel xrLabel46;
    private XRLabel xrLabel45;
    private XRLine xrLine3;
    private XRLabel xrLabel43;
    public XRLabel folio;
    public XRLabel fechaentrega;
    public XRLabel sku;
    public XRLabel cajas;
    public XRLabel otras;
    public XRLabel estatus;
    public XRLabel productos;
    public GroupHeaderBand GroupHeader1;
    public XRLabel ClienteClave;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PrinSubPrevetaDetallado()
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
            this.folio = new DevExpress.XtraReports.UI.XRLabel();
            this.fechaentrega = new DevExpress.XtraReports.UI.XRLabel();
            this.sku = new DevExpress.XtraReports.UI.XRLabel();
            this.cajas = new DevExpress.XtraReports.UI.XRLabel();
            this.otras = new DevExpress.XtraReports.UI.XRLabel();
            this.estatus = new DevExpress.XtraReports.UI.XRLabel();
            this.productos = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ClienteClave = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.folio,
            this.fechaentrega,
            this.sku,
            this.cajas,
            this.otras,
            this.estatus,
            this.productos});
            this.Detail.Dpi = 100F;
            this.Detail.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.HeightF = 11.58343F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // folio
            // 
            this.folio.Dpi = 100F;
            this.folio.Font = new System.Drawing.Font("Arial", 9F);
            this.folio.LocationFloat = new DevExpress.Utils.PointFloat(3.419749F, 0F);
            this.folio.Name = "folio";
            this.folio.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.folio.SizeF = new System.Drawing.SizeF(93.46466F, 11.58336F);
            this.folio.StylePriority.UseFont = false;
            this.folio.StylePriority.UsePadding = false;
            this.folio.StylePriority.UseTextAlignment = false;
            this.folio.Text = "Folio";
            this.folio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // fechaentrega
            // 
            this.fechaentrega.CanGrow = false;
            this.fechaentrega.Dpi = 100F;
            this.fechaentrega.Font = new System.Drawing.Font("Arial", 9F);
            this.fechaentrega.LocationFloat = new DevExpress.Utils.PointFloat(96.88441F, 3.178914E-05F);
            this.fechaentrega.Name = "fechaentrega";
            this.fechaentrega.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.fechaentrega.SizeF = new System.Drawing.SizeF(117.4442F, 11.58336F);
            this.fechaentrega.StylePriority.UseFont = false;
            this.fechaentrega.StylePriority.UsePadding = false;
            this.fechaentrega.StylePriority.UseTextAlignment = false;
            this.fechaentrega.Text = "Fecha Entrega";
            this.fechaentrega.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // sku
            // 
            this.sku.Dpi = 100F;
            this.sku.Font = new System.Drawing.Font("Arial", 9F);
            this.sku.LocationFloat = new DevExpress.Utils.PointFloat(496.8688F, 3.178914E-05F);
            this.sku.Name = "sku";
            this.sku.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.sku.SizeF = new System.Drawing.SizeF(71.85999F, 11.58336F);
            this.sku.StylePriority.UseFont = false;
            this.sku.StylePriority.UsePadding = false;
            this.sku.StylePriority.UseTextAlignment = false;
            this.sku.Text = "SKU";
            this.sku.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // cajas
            // 
            this.cajas.Dpi = 100F;
            this.cajas.Font = new System.Drawing.Font("Arial", 9F);
            this.cajas.LocationFloat = new DevExpress.Utils.PointFloat(869.7139F, 6.357829E-05F);
            this.cajas.Name = "cajas";
            this.cajas.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.cajas.SizeF = new System.Drawing.SizeF(54.81488F, 11.58336F);
            this.cajas.StylePriority.UseFont = false;
            this.cajas.StylePriority.UsePadding = false;
            this.cajas.StylePriority.UseTextAlignment = false;
            this.cajas.Text = "Cajas";
            this.cajas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // otras
            // 
            this.otras.Dpi = 100F;
            this.otras.Font = new System.Drawing.Font("Arial", 9F);
            this.otras.LocationFloat = new DevExpress.Utils.PointFloat(924.8202F, 3.178914E-05F);
            this.otras.Name = "otras";
            this.otras.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.otras.SizeF = new System.Drawing.SizeF(123.4716F, 11.58336F);
            this.otras.StylePriority.UseFont = false;
            this.otras.StylePriority.UsePadding = false;
            this.otras.StylePriority.UseTextAlignment = false;
            this.otras.Text = "Otras Unidades";
            this.otras.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // estatus
            // 
            this.estatus.Dpi = 100F;
            this.estatus.Font = new System.Drawing.Font("Arial", 9F);
            this.estatus.LocationFloat = new DevExpress.Utils.PointFloat(217.3749F, 3.178914E-05F);
            this.estatus.Name = "estatus";
            this.estatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.estatus.SizeF = new System.Drawing.SizeF(279.3666F, 11.58336F);
            this.estatus.StylePriority.UseFont = false;
            this.estatus.StylePriority.UsePadding = false;
            this.estatus.StylePriority.UseTextAlignment = false;
            this.estatus.Text = "Estatus";
            this.estatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // productos
            // 
            this.productos.Dpi = 100F;
            this.productos.Font = new System.Drawing.Font("Arial", 9F);
            this.productos.LocationFloat = new DevExpress.Utils.PointFloat(569.8853F, 3.178914E-05F);
            this.productos.Name = "productos";
            this.productos.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.productos.SizeF = new System.Drawing.SizeF(295.6043F, 11.58336F);
            this.productos.StylePriority.UseFont = false;
            this.productos.StylePriority.UsePadding = false;
            this.productos.StylePriority.UseTextAlignment = false;
            this.productos.Text = "Producto";
            this.productos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 4F;
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.xrLabel52,
            this.xrLabel49,
            this.xrLabel48,
            this.xrLabel47,
            this.xrLabel46,
            this.xrLabel45,
            this.xrLine3,
            this.xrLabel43});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 47.91221F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LineWidth = 2;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(2.231216F, 42.00004F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1045.769F, 5.91217F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(568.8852F, 10.00001F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(295.6043F, 32F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UsePadding = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "Producto";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Dpi = 100F;
            this.xrLabel49.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(217.6585F, 10.00001F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(279.3666F, 32F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UsePadding = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "Estatus";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel48
            // 
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(924.5283F, 10.00001F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(123.4717F, 32F);
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UsePadding = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            this.xrLabel48.Text = "Otras Unidades";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel47
            // 
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(869.4221F, 10.00001F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(54.815F, 32F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UsePadding = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "Cajas";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(497.025F, 10.00001F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(71.86F, 32F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UsePadding = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "SKU";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel45
            // 
            this.xrLabel45.CanGrow = false;
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(96.59277F, 10.00001F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(117.4442F, 32F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UsePadding = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            this.xrLabel45.Text = "Fecha Entrega";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LineWidth = 2;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(2.231216F, 4.087845F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(1045.769F, 5.912139F);
            this.xrLine3.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(1.939503F, 10.00001F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(94.65327F, 32F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UsePadding = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "Folio";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ClienteClave});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23.95833F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // ClienteClave
            // 
            this.ClienteClave.Dpi = 100F;
            this.ClienteClave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.ClienteClave.LocationFloat = new DevExpress.Utils.PointFloat(0.2916972F, 10.00001F);
            this.ClienteClave.Name = "ClienteClave";
            this.ClienteClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ClienteClave.SizeF = new System.Drawing.SizeF(856.25F, 13F);
            this.ClienteClave.StylePriority.UseFont = false;
            this.ClienteClave.Text = "ClienteClave";
            // 
            // PrinSubPrevetaDetallado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1});
            this.HorizontalContentSplitting = DevExpress.XtraPrinting.HorizontalContentSplitting.Smart;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(7, 42, 4, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
