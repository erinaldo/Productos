using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado3
/// </summary>
public class efectividadPorRutaSubDetallado3 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ClientesVisitadosConVenta;
    private XRLabel xrLabel33;
    private XRLabel xrLabel31;
    public XRLabel lb2TotalClientesVisitadosConVenta;
    public XRLabel lb2TotalClientesVisitadosConVentaPorcent;
    private GroupFooterBand GroupFooter1;
    private GroupHeaderBand GroupHeader1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado3()
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
            this.lb2ClientesVisitadosConVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesVisitadosConVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesVisitadosConVentaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ClientesVisitadosConVenta});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ClientesVisitadosConVenta
            // 
            this.lb2ClientesVisitadosConVenta.Dpi = 100F;
            this.lb2ClientesVisitadosConVenta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lb2ClientesVisitadosConVenta.Name = "lb2ClientesVisitadosConVenta";
            this.lb2ClientesVisitadosConVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ClientesVisitadosConVenta.SizeF = new System.Drawing.SizeF(775.8437F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 40F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(279.078F, 23F);
            this.xrLabel33.Text = "CLIENTES VISITADOS CON VENTA";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(71.55747F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(193.005F, 23F);
            this.xrLabel31.Text = "Total Clientes visitados con venta";
            // 
            // lb2TotalClientesVisitadosConVenta
            // 
            this.lb2TotalClientesVisitadosConVenta.Dpi = 100F;
            this.lb2TotalClientesVisitadosConVenta.LocationFloat = new DevExpress.Utils.PointFloat(449.2081F, 0F);
            this.lb2TotalClientesVisitadosConVenta.Name = "lb2TotalClientesVisitadosConVenta";
            this.lb2TotalClientesVisitadosConVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesVisitadosConVenta.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // lb2TotalClientesVisitadosConVentaPorcent
            // 
            this.lb2TotalClientesVisitadosConVentaPorcent.Dpi = 100F;
            this.lb2TotalClientesVisitadosConVentaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(549.2082F, 0F);
            this.lb2TotalClientesVisitadosConVentaPorcent.Name = "lb2TotalClientesVisitadosConVentaPorcent";
            this.lb2TotalClientesVisitadosConVentaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesVisitadosConVentaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel31,
            this.lb2TotalClientesVisitadosConVenta,
            this.lb2TotalClientesVisitadosConVentaPorcent});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 29.16667F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel33});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23.95833F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // efectividadPorRutaSubDetallado3
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(18, 21, 40, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
