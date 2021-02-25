using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class VentasProductoKg : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private ReportHeaderBand ReportHeader;
    public GroupHeaderBand GroupHeader1;
    public XRLabel labelCediTotal;
    public XRLabel labelClave;
    public XRLabel labelProducto;
    public XRLabel labelUnidad;
    public XRLabel labelCantidad;
    public XRLabel labelKgLts;
    public XRLabel labelTotal;
    private XRLabel xrLabel27;
    public XRLabel labelProductoCantidad;
    public XRLabel labelProductoKgLts;
    public XRLabel labelProductoTotal;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public VentasProductoKg()
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
            this.labelClave = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProductoCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProductoKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProductoTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.labelCediTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelClave,
            this.labelProducto,
            this.labelUnidad,
            this.labelCantidad,
            this.labelKgLts,
            this.labelTotal});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 24.45865F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelClave
            // 
            this.labelClave.Dpi = 100F;
            this.labelClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.LocationFloat = new DevExpress.Utils.PointFloat(0.9999593F, 0F);
            this.labelClave.Multiline = true;
            this.labelClave.Name = "labelClave";
            this.labelClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClave.SizeF = new System.Drawing.SizeF(76.45836F, 24.45865F);
            this.labelClave.StylePriority.UseFont = false;
            this.labelClave.StylePriority.UseTextAlignment = false;
            this.labelClave.Text = "Clave";
            this.labelClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelProducto
            // 
            this.labelProducto.Dpi = 100F;
            this.labelProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducto.LocationFloat = new DevExpress.Utils.PointFloat(77.95817F, 0F);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto.SizeF = new System.Drawing.SizeF(125.3173F, 24.45865F);
            this.labelProducto.StylePriority.UseFont = false;
            this.labelProducto.StylePriority.UseTextAlignment = false;
            this.labelProducto.Text = "Producto";
            this.labelProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelUnidad
            // 
            this.labelUnidad.Dpi = 100F;
            this.labelUnidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnidad.LocationFloat = new DevExpress.Utils.PointFloat(203.2756F, 0.001811981F);
            this.labelUnidad.Name = "labelUnidad";
            this.labelUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelUnidad.SizeF = new System.Drawing.SizeF(88.50002F, 24.45684F);
            this.labelUnidad.StylePriority.UseFont = false;
            this.labelUnidad.StylePriority.UseTextAlignment = false;
            this.labelUnidad.Text = "Unidad";
            this.labelUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCantidad
            // 
            this.labelCantidad.Dpi = 100F;
            this.labelCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidad.LocationFloat = new DevExpress.Utils.PointFloat(292.2755F, 0.001811981F);
            this.labelCantidad.Multiline = true;
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelCantidad.StylePriority.UseFont = false;
            this.labelCantidad.StylePriority.UseTextAlignment = false;
            this.labelCantidad.Text = "Cantidad";
            this.labelCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelKgLts
            // 
            this.labelKgLts.Dpi = 100F;
            this.labelKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKgLts.LocationFloat = new DevExpress.Utils.PointFloat(381.5397F, 0F);
            this.labelKgLts.Multiline = true;
            this.labelKgLts.Name = "labelKgLts";
            this.labelKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelKgLts.StylePriority.UseFont = false;
            this.labelKgLts.StylePriority.UseTextAlignment = false;
            this.labelKgLts.Text = "Kilo/Litros";
            this.labelKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTotal
            // 
            this.labelTotal.Dpi = 100F;
            this.labelTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.LocationFloat = new DevExpress.Utils.PointFloat(456.7378F, 0F);
            this.labelTotal.Multiline = true;
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTotal.SizeF = new System.Drawing.SizeF(78.86499F, 24.45674F);
            this.labelTotal.StylePriority.UseFont = false;
            this.labelTotal.StylePriority.UseTextAlignment = false;
            this.labelTotal.Text = "Total";
            this.labelTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 2.249384F;
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
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.labelProductoCantidad,
            this.labelProductoKgLts,
            this.labelProductoTotal});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 24.46153F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(207.0226F, 0.003306071F);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(84.75256F, 24.45823F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Total";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelProductoCantidad
            // 
            this.labelProductoCantidad.Dpi = 100F;
            this.labelProductoCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductoCantidad.LocationFloat = new DevExpress.Utils.PointFloat(292.2752F, 0.003306071F);
            this.labelProductoCantidad.Multiline = true;
            this.labelProductoCantidad.Name = "labelProductoCantidad";
            this.labelProductoCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProductoCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelProductoCantidad.StylePriority.UseFont = false;
            this.labelProductoCantidad.StylePriority.UseTextAlignment = false;
            this.labelProductoCantidad.Text = "Cantidad";
            this.labelProductoCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelProductoKgLts
            // 
            this.labelProductoKgLts.Dpi = 100F;
            this.labelProductoKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductoKgLts.LocationFloat = new DevExpress.Utils.PointFloat(381.5397F, 0.003306071F);
            this.labelProductoKgLts.Multiline = true;
            this.labelProductoKgLts.Name = "labelProductoKgLts";
            this.labelProductoKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProductoKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelProductoKgLts.StylePriority.UseFont = false;
            this.labelProductoKgLts.StylePriority.UseTextAlignment = false;
            this.labelProductoKgLts.Text = "Kilo/Litros";
            this.labelProductoKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelProductoTotal
            // 
            this.labelProductoTotal.Dpi = 100F;
            this.labelProductoTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductoTotal.LocationFloat = new DevExpress.Utils.PointFloat(456.7378F, 0.003306071F);
            this.labelProductoTotal.Multiline = true;
            this.labelProductoTotal.Name = "labelProductoTotal";
            this.labelProductoTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProductoTotal.SizeF = new System.Drawing.SizeF(78.86499F, 24.45674F);
            this.labelProductoTotal.StylePriority.UseFont = false;
            this.labelProductoTotal.StylePriority.UseTextAlignment = false;
            this.labelProductoTotal.Text = "Total";
            this.labelProductoTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 1.041667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCediTotal});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 17.2266F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // labelCediTotal
            // 
            this.labelCediTotal.Dpi = 100F;
            this.labelCediTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediTotal.LocationFloat = new DevExpress.Utils.PointFloat(1.000023F, 0F);
            this.labelCediTotal.Multiline = true;
            this.labelCediTotal.Name = "labelCediTotal";
            this.labelCediTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediTotal.SizeF = new System.Drawing.SizeF(164.2816F, 14.04007F);
            this.labelCediTotal.StylePriority.UseFont = false;
            this.labelCediTotal.StylePriority.UseTextAlignment = false;
            this.labelCediTotal.Text = "RESUMEN POR PRODUCTO";
            this.labelCediTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // VentasProductoKg
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 2, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
