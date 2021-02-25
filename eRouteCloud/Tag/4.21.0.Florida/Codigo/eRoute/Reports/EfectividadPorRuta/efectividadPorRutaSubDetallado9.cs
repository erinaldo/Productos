using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado9
/// </summary>
public class efectividadPorRutaSubDetallado9 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2CodigoBarrasLeidos;
    private XRLabel xrLabel69;
    private XRLabel xrLabel71;
    public XRLabel lb2TotalClientesCodigosBarrasLeidos;
    private XRLabel xrLabel73;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado9()
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
            this.lb2CodigoBarrasLeidos = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesCodigosBarrasLeidos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2CodigoBarrasLeidos});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25.08411F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2CodigoBarrasLeidos
            // 
            this.lb2CodigoBarrasLeidos.Dpi = 100F;
            this.lb2CodigoBarrasLeidos.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lb2CodigoBarrasLeidos.Name = "lb2CodigoBarrasLeidos";
            this.lb2CodigoBarrasLeidos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2CodigoBarrasLeidos.SizeF = new System.Drawing.SizeF(775.8437F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 39F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel69
            // 
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(279.078F, 23F);
            this.xrLabel69.Text = "CODIGO BARRAS LEIDOS";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 28.04089F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel71
            // 
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(277.4633F, 23F);
            this.xrLabel71.Text = "Total Clientes con Codigos de Barras Leidos";
            // 
            // lb2TotalClientesCodigosBarrasLeidos
            // 
            this.lb2TotalClientesCodigosBarrasLeidos.Dpi = 100F;
            this.lb2TotalClientesCodigosBarrasLeidos.LocationFloat = new DevExpress.Utils.PointFloat(450.1248F, 0F);
            this.lb2TotalClientesCodigosBarrasLeidos.Name = "lb2TotalClientesCodigosBarrasLeidos";
            this.lb2TotalClientesCodigosBarrasLeidos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesCodigosBarrasLeidos.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // xrLabel73
            // 
            this.xrLabel73.Dpi = 100F;
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(550.2551F, 0F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel69});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel71,
            this.lb2TotalClientesCodigosBarrasLeidos,
            this.xrLabel73});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 23F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // efectividadPorRutaSubDetallado9
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(15, 12, 39, 28);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
