using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado1
/// </summary>
public class efectividadPorRutaSubDetallado1 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ClientesNoVisitados;
    private XRLabel xrLabel13;
    private GroupFooterBand GroupFooter1;
    private XRLabel xrLabel15;
    public XRLabel lb2TotalClientesNoVisitados;
    public XRLabel lb2TotalClientesNoVisitadosPorcent;
    private GroupHeaderBand GroupHeader1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado1()
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
            this.lb2ClientesNoVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesNoVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesNoVisitadosPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ClientesNoVisitados});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23.95833F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ClientesNoVisitados
            // 
            this.lb2ClientesNoVisitados.Dpi = 100F;
            this.lb2ClientesNoVisitados.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lb2ClientesNoVisitados.Name = "lb2ClientesNoVisitados";
            this.lb2ClientesNoVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ClientesNoVisitados.SizeF = new System.Drawing.SizeF(775.8437F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 100F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(198.8697F, 23F);
            this.xrLabel13.Text = "CLIENTES NO VISITADOS";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.lb2TotalClientesNoVisitados,
            this.lb2TotalClientesNoVisitadosPorcent});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 25.00001F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(200.1147F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel15.Text = "Total Clientes no visitados";
            // 
            // lb2TotalClientesNoVisitados
            // 
            this.lb2TotalClientesNoVisitados.Dpi = 100F;
            this.lb2TotalClientesNoVisitados.LocationFloat = new DevExpress.Utils.PointFloat(451.7603F, 2.000014F);
            this.lb2TotalClientesNoVisitados.Name = "lb2TotalClientesNoVisitados";
            this.lb2TotalClientesNoVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesNoVisitados.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // lb2TotalClientesNoVisitadosPorcent
            // 
            this.lb2TotalClientesNoVisitadosPorcent.Dpi = 100F;
            this.lb2TotalClientesNoVisitadosPorcent.LocationFloat = new DevExpress.Utils.PointFloat(551.7603F, 2.000014F);
            this.lb2TotalClientesNoVisitadosPorcent.Name = "lb2TotalClientesNoVisitadosPorcent";
            this.lb2TotalClientesNoVisitadosPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesNoVisitadosPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23.95833F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // efectividadPorRutaSubDetallado1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(23, 28, 100, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
