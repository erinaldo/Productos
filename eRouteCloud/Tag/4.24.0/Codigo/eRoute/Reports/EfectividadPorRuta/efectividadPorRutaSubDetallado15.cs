using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado15
/// </summary>
public class efectividadPorRutaSubDetallado15 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ClientesConProductoNegado;
    private XRLabel xrLabel93;
    public XRLabel lb2TotalClientesProductoNegado;
    private XRLabel xrLabel91;
    private XRLabel xrLabel89;
    private XRLabel xrLabel101;
    public XRLabel lb2TotalProductoNegado;
    private XRLabel xrLabel99;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado15()
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
            this.lb2ClientesConProductoNegado = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel93 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesProductoNegado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel91 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel89 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel101 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalProductoNegado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel99 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ClientesConProductoNegado});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 24.04146F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ClientesConProductoNegado
            // 
            this.lb2ClientesConProductoNegado.Dpi = 100F;
            this.lb2ClientesConProductoNegado.LocationFloat = new DevExpress.Utils.PointFloat(23.99026F, 0F);
            this.lb2ClientesConProductoNegado.Name = "lb2ClientesConProductoNegado";
            this.lb2ClientesConProductoNegado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ClientesConProductoNegado.SizeF = new System.Drawing.SizeF(775.0195F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 100F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel93
            // 
            this.xrLabel93.Dpi = 100F;
            this.xrLabel93.LocationFloat = new DevExpress.Utils.PointFloat(550.5215F, 23.0003F);
            this.xrLabel93.Name = "xrLabel93";
            this.xrLabel93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel93.SizeF = new System.Drawing.SizeF(99.17569F, 23F);
            // 
            // lb2TotalClientesProductoNegado
            // 
            this.lb2TotalClientesProductoNegado.Dpi = 100F;
            this.lb2TotalClientesProductoNegado.LocationFloat = new DevExpress.Utils.PointFloat(450.3914F, 23.0003F);
            this.lb2TotalClientesProductoNegado.Name = "lb2TotalClientesProductoNegado";
            this.lb2TotalClientesProductoNegado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesProductoNegado.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel91
            // 
            this.xrLabel91.Dpi = 100F;
            this.xrLabel91.LocationFloat = new DevExpress.Utils.PointFloat(60.15189F, 23.0003F);
            this.xrLabel91.Name = "xrLabel91";
            this.xrLabel91.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel91.SizeF = new System.Drawing.SizeF(276.3111F, 23.00012F);
            this.xrLabel91.Text = "Total Clientes con Producto Negado";
            // 
            // xrLabel89
            // 
            this.xrLabel89.Dpi = 100F;
            this.xrLabel89.LocationFloat = new DevExpress.Utils.PointFloat(23.99026F, 0F);
            this.xrLabel89.Name = "xrLabel89";
            this.xrLabel89.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel89.SizeF = new System.Drawing.SizeF(278.2537F, 23F);
            this.xrLabel89.Text = "CLIENTES CON PRODUCTO NEGADO";
            // 
            // xrLabel101
            // 
            this.xrLabel101.Dpi = 100F;
            this.xrLabel101.LocationFloat = new DevExpress.Utils.PointFloat(161.0899F, 0F);
            this.xrLabel101.Name = "xrLabel101";
            this.xrLabel101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel101.SizeF = new System.Drawing.SizeF(174.9148F, 23.00024F);
            this.xrLabel101.Text = "Total Producto Negado";
            // 
            // lb2TotalProductoNegado
            // 
            this.lb2TotalProductoNegado.Dpi = 100F;
            this.lb2TotalProductoNegado.LocationFloat = new DevExpress.Utils.PointFloat(450.3914F, 0F);
            this.lb2TotalProductoNegado.Name = "lb2TotalProductoNegado";
            this.lb2TotalProductoNegado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalProductoNegado.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel99
            // 
            this.xrLabel99.Dpi = 100F;
            this.xrLabel99.LocationFloat = new DevExpress.Utils.PointFloat(550.5216F, 0F);
            this.xrLabel99.Name = "xrLabel99";
            this.xrLabel99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel99.SizeF = new System.Drawing.SizeF(99.17569F, 23F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel89});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 26.04167F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel101,
            this.lb2TotalProductoNegado,
            this.xrLabel99,
            this.xrLabel91,
            this.lb2TotalClientesProductoNegado,
            this.xrLabel93});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 52.08333F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // efectividadPorRutaSubDetallado15
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(15, 12, 100, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
