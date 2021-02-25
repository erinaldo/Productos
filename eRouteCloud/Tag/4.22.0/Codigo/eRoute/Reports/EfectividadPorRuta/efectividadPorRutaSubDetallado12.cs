using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado12
/// </summary>
public class efectividadPorRutaSubDetallado12 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ImproductividadProducto;
    private XRLabel xrLabel83;
    public XRLabel lb2TotalImproductividadProducto;
    private XRLabel xrLabel81;
    private XRLabel xrLabel79;
    private GroupFooterBand GroupFooter1;
    private GroupHeaderBand GroupHeader1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado12()
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
            this.lb2ImproductividadProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalImproductividadProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ImproductividadProducto});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ImproductividadProducto
            // 
            this.lb2ImproductividadProducto.Dpi = 100F;
            this.lb2ImproductividadProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lb2ImproductividadProducto.Name = "lb2ImproductividadProducto";
            this.lb2ImproductividadProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ImproductividadProducto.SizeF = new System.Drawing.SizeF(775.0194F, 23F);
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
            // xrLabel83
            // 
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(552.4431F, 9.536743E-05F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(99.17572F, 23.00002F);
            // 
            // lb2TotalImproductividadProducto
            // 
            this.lb2TotalImproductividadProducto.Dpi = 100F;
            this.lb2TotalImproductividadProducto.LocationFloat = new DevExpress.Utils.PointFloat(452.3128F, 9.536743E-05F);
            this.lb2TotalImproductividadProducto.Name = "lb2TotalImproductividadProducto";
            this.lb2TotalImproductividadProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalImproductividadProducto.SizeF = new System.Drawing.SizeF(99.17572F, 23.00002F);
            // 
            // xrLabel81
            // 
            this.xrLabel81.Dpi = 100F;
            this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(1.942603F, 0F);
            this.xrLabel81.Name = "xrLabel81";
            this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel81.SizeF = new System.Drawing.SizeF(276.3111F, 23.00011F);
            this.xrLabel81.Text = "Total Improductividad Producto";
            // 
            // xrLabel79
            // 
            this.xrLabel79.Dpi = 100F;
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(278.2537F, 23F);
            this.xrLabel79.Text = "IMPRODUCTIVIDAD DE PRODUCTO";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel81,
            this.lb2TotalImproductividadProducto,
            this.xrLabel83});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 27.08333F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel79});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 33.00001F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // efectividadPorRutaSubDetallado12
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(11, 18, 100, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
