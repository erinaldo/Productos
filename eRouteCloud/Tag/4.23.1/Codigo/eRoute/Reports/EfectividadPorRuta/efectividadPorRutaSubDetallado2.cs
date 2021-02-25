using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado2
/// </summary>
public class efectividadPorRutaSubDetallado2 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ClientesVisitados;
    private XRLabel xrLabel24;
    public XRLabel lb2TotalClientesVisitadosPorcent;
    public XRLabel lb2TotalClientesVisitados;
    private XRLabel xrLabel26;
    private GroupFooterBand GroupFooter1;
    private GroupHeaderBand GroupHeader1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado2()
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
            this.lb2ClientesVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.lb2TotalClientesVisitadosPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ClientesVisitados});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 24.04165F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ClientesVisitados
            // 
            this.lb2ClientesVisitados.Dpi = 100F;
            this.lb2ClientesVisitados.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lb2ClientesVisitados.Name = "lb2ClientesVisitados";
            this.lb2ClientesVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ClientesVisitados.SizeF = new System.Drawing.SizeF(775.8437F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 35.41665F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(198.8697F, 23F);
            this.xrLabel24.Text = "CLIENTES VISITADOS";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2TotalClientesVisitadosPorcent
            // 
            this.lb2TotalClientesVisitadosPorcent.Dpi = 100F;
            this.lb2TotalClientesVisitadosPorcent.LocationFloat = new DevExpress.Utils.PointFloat(551.1457F, 0F);
            this.lb2TotalClientesVisitadosPorcent.Name = "lb2TotalClientesVisitadosPorcent";
            this.lb2TotalClientesVisitadosPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesVisitadosPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // lb2TotalClientesVisitados
            // 
            this.lb2TotalClientesVisitados.Dpi = 100F;
            this.lb2TotalClientesVisitados.LocationFloat = new DevExpress.Utils.PointFloat(451.1456F, 0F);
            this.lb2TotalClientesVisitados.Name = "lb2TotalClientesVisitados";
            this.lb2TotalClientesVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesVisitados.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(119.4166F, 0F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel26.Text = "Total Clientes visitados";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel26,
            this.lb2TotalClientesVisitados,
            this.lb2TotalClientesVisitadosPorcent});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 29.16667F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel24});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // efectividadPorRutaSubDetallado2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(35, 36, 35, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
