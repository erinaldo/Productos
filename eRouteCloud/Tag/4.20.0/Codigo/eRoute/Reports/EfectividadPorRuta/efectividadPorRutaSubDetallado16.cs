using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado16
/// </summary>
public class efectividadPorRutaSubDetallado16 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ClientesConImproductividadProducto;
    private XRLabel xrLabel109;
    public XRLabel lb2TotalImproductividadProducto;
    private XRLabel xrLabel107;
    private XRLabel xrLabel106;
    private XRLabel xrLabel104;
    public XRLabel lb2TotalClientesConImproductividadProducto;
    private XRLabel xrLabel102;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado16()
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
            this.lb2ClientesConImproductividadProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel109 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalImproductividadProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel107 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel106 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel104 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesConImproductividadProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel102 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ClientesConImproductividadProducto});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 24.04226F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ClientesConImproductividadProducto
            // 
            this.lb2ClientesConImproductividadProducto.Dpi = 100F;
            this.lb2ClientesConImproductividadProducto.LocationFloat = new DevExpress.Utils.PointFloat(24.71941F, 0F);
            this.lb2ClientesConImproductividadProducto.Name = "lb2ClientesConImproductividadProducto";
            this.lb2ClientesConImproductividadProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ClientesConImproductividadProducto.SizeF = new System.Drawing.SizeF(775.0195F, 23F);
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
            // xrLabel109
            // 
            this.xrLabel109.Dpi = 100F;
            this.xrLabel109.LocationFloat = new DevExpress.Utils.PointFloat(549.084F, 0F);
            this.xrLabel109.Name = "xrLabel109";
            this.xrLabel109.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel109.SizeF = new System.Drawing.SizeF(99.17569F, 23F);
            // 
            // lb2TotalImproductividadProducto
            // 
            this.lb2TotalImproductividadProducto.Dpi = 100F;
            this.lb2TotalImproductividadProducto.LocationFloat = new DevExpress.Utils.PointFloat(448.9538F, 0F);
            this.lb2TotalImproductividadProducto.Name = "lb2TotalImproductividadProducto";
            this.lb2TotalImproductividadProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalImproductividadProducto.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel107
            // 
            this.xrLabel107.Dpi = 100F;
            this.xrLabel107.LocationFloat = new DevExpress.Utils.PointFloat(160.7357F, 0F);
            this.xrLabel107.Name = "xrLabel107";
            this.xrLabel107.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel107.SizeF = new System.Drawing.SizeF(176.8785F, 23.00024F);
            this.xrLabel107.Text = "Total Improductividad Producto";
            // 
            // xrLabel106
            // 
            this.xrLabel106.Dpi = 100F;
            this.xrLabel106.LocationFloat = new DevExpress.Utils.PointFloat(24.71941F, 0F);
            this.xrLabel106.Name = "xrLabel106";
            this.xrLabel106.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel106.SizeF = new System.Drawing.SizeF(325.9779F, 23F);
            this.xrLabel106.Text = "CLIENTES CON IMPRODUCTIVIDAD PRODUCTO";
            // 
            // xrLabel104
            // 
            this.xrLabel104.Dpi = 100F;
            this.xrLabel104.LocationFloat = new DevExpress.Utils.PointFloat(59.79768F, 23.0011F);
            this.xrLabel104.Name = "xrLabel104";
            this.xrLabel104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel104.SizeF = new System.Drawing.SizeF(276.3111F, 23.00012F);
            this.xrLabel104.Text = "Total Clientes con Improductividad Producto";
            // 
            // lb2TotalClientesConImproductividadProducto
            // 
            this.lb2TotalClientesConImproductividadProducto.Dpi = 100F;
            this.lb2TotalClientesConImproductividadProducto.LocationFloat = new DevExpress.Utils.PointFloat(448.9538F, 23.00005F);
            this.lb2TotalClientesConImproductividadProducto.Name = "lb2TotalClientesConImproductividadProducto";
            this.lb2TotalClientesConImproductividadProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesConImproductividadProducto.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel102
            // 
            this.xrLabel102.Dpi = 100F;
            this.xrLabel102.LocationFloat = new DevExpress.Utils.PointFloat(549.0838F, 23.00005F);
            this.xrLabel102.Name = "xrLabel102";
            this.xrLabel102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel102.SizeF = new System.Drawing.SizeF(99.17569F, 23F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel106});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel107,
            this.lb2TotalClientesConImproductividadProducto,
            this.xrLabel104,
            this.xrLabel102,
            this.lb2TotalImproductividadProducto,
            this.xrLabel109});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 51.04167F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // efectividadPorRutaSubDetallado16
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
