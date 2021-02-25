using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado14
/// </summary>
public class efectividadPorRutaSubDetallado14 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ProductoPromocionalNoEntregado;
    private XRLabel xrLabel98;
    private XRLabel xrLabel96;
    public XRLabel lb2TotalProductoPromocionalNoEntregado;
    private XRLabel xrLabel94;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado14()
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
            this.lb2ProductoPromocionalNoEntregado = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel98 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel96 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalProductoPromocionalNoEntregado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel94 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ProductoPromocionalNoEntregado});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23.95833F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ProductoPromocionalNoEntregado
            // 
            this.lb2ProductoPromocionalNoEntregado.Dpi = 100F;
            this.lb2ProductoPromocionalNoEntregado.LocationFloat = new DevExpress.Utils.PointFloat(24.94862F, 0F);
            this.lb2ProductoPromocionalNoEntregado.Name = "lb2ProductoPromocionalNoEntregado";
            this.lb2ProductoPromocionalNoEntregado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ProductoPromocionalNoEntregado.SizeF = new System.Drawing.SizeF(775.0195F, 23F);
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
            // xrLabel98
            // 
            this.xrLabel98.Dpi = 100F;
            this.xrLabel98.LocationFloat = new DevExpress.Utils.PointFloat(24.94862F, 0F);
            this.xrLabel98.Name = "xrLabel98";
            this.xrLabel98.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel98.SizeF = new System.Drawing.SizeF(309.759F, 23F);
            this.xrLabel98.Text = "PRODUCTO PROMOCIONAL NO ENTREGADO";
            // 
            // xrLabel96
            // 
            this.xrLabel96.Dpi = 100F;
            this.xrLabel96.LocationFloat = new DevExpress.Utils.PointFloat(72.78202F, 0F);
            this.xrLabel96.Name = "xrLabel96";
            this.xrLabel96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel96.SizeF = new System.Drawing.SizeF(276.3111F, 23.00012F);
            this.xrLabel96.Text = "Total Producto promocional no entregado";
            // 
            // lb2TotalProductoPromocionalNoEntregado
            // 
            this.lb2TotalProductoPromocionalNoEntregado.Dpi = 100F;
            this.lb2TotalProductoPromocionalNoEntregado.LocationFloat = new DevExpress.Utils.PointFloat(454.0633F, 2.000014F);
            this.lb2TotalProductoPromocionalNoEntregado.Name = "lb2TotalProductoPromocionalNoEntregado";
            this.lb2TotalProductoPromocionalNoEntregado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalProductoPromocionalNoEntregado.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel94
            // 
            this.xrLabel94.Dpi = 100F;
            this.xrLabel94.LocationFloat = new DevExpress.Utils.PointFloat(554.1935F, 2.000014F);
            this.xrLabel94.Name = "xrLabel94";
            this.xrLabel94.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel94.SizeF = new System.Drawing.SizeF(99.17569F, 23F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel98});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23.95833F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel96,
            this.lb2TotalProductoPromocionalNoEntregado,
            this.xrLabel94});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 25.00001F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // efectividadPorRutaSubDetallado14
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(14, 12, 100, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
