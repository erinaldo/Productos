using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado11
/// </summary>
public class efectividadPorRutaSubDetallado11 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ProductosNoEntregados;
    private XRLabel xrLabel74;
    private XRLabel xrLabel78;
    public XRLabel lb2TotalProductoNoEntregado;
    private XRLabel xrLabel76;
    private GroupFooterBand GroupFooter1;
    private GroupHeaderBand GroupHeader1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado11()
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
            this.lb2ProductosNoEntregados = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalProductoNoEntregado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ProductosNoEntregados});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25.08421F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ProductosNoEntregados
            // 
            this.lb2ProductosNoEntregados.Dpi = 100F;
            this.lb2ProductosNoEntregados.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lb2ProductosNoEntregados.Name = "lb2ProductosNoEntregados";
            this.lb2ProductosNoEntregados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ProductosNoEntregados.SizeF = new System.Drawing.SizeF(775.0194F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 36.45833F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel74
            // 
            this.xrLabel74.Dpi = 100F;
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(1.942627F, 0F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(278.2538F, 23F);
            this.xrLabel74.Text = "PRODUCTOS NO ENTREGADOS";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel78
            // 
            this.xrLabel78.Dpi = 100F;
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(550.3859F, 0F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // lb2TotalProductoNoEntregado
            // 
            this.lb2TotalProductoNoEntregado.Dpi = 100F;
            this.lb2TotalProductoNoEntregado.LocationFloat = new DevExpress.Utils.PointFloat(450.2557F, 0F);
            this.lb2TotalProductoNoEntregado.Name = "lb2TotalProductoNoEntregado";
            this.lb2TotalProductoNoEntregado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalProductoNoEntregado.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel76
            // 
            this.xrLabel76.Dpi = 100F;
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(1.942627F, 0F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(276.3111F, 23.00012F);
            this.xrLabel76.Text = "Total Producto no Entregado";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel76,
            this.lb2TotalProductoNoEntregado,
            this.xrLabel78});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 27.08333F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel74});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23.95833F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // efectividadPorRutaSubDetallado11
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(17, 15, 36, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
