using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado7
/// </summary>
public class efectividadPorRutaSubDetallado7 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lb2ClientesEncuestados;
    private XRLabel xrLabel58;
    public XRLabel lb2TotalClientesEncuestados;
    private XRLabel xrLabel54;
    private XRLabel xrLabel56;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado7()
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
            this.lb2ClientesEncuestados = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.lb2TotalClientesEncuestados = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ClientesEncuestados});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25.08411F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ClientesEncuestados
            // 
            this.lb2ClientesEncuestados.Dpi = 100F;
            this.lb2ClientesEncuestados.LocationFloat = new DevExpress.Utils.PointFloat(25.80732F, 0F);
            this.lb2ClientesEncuestados.Name = "lb2ClientesEncuestados";
            this.lb2ClientesEncuestados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ClientesEncuestados.SizeF = new System.Drawing.SizeF(775.8437F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 36.45833F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel58
            // 
            this.xrLabel58.Dpi = 100F;
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 0F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(279.078F, 23F);
            this.xrLabel58.Text = "CLIENTES ENCUESTADOS";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 29.08255F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2TotalClientesEncuestados
            // 
            this.lb2TotalClientesEncuestados.Dpi = 100F;
            this.lb2TotalClientesEncuestados.LocationFloat = new DevExpress.Utils.PointFloat(449.4164F, 4.083315F);
            this.lb2TotalClientesEncuestados.Name = "lb2TotalClientesEncuestados";
            this.lb2TotalClientesEncuestados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesEncuestados.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // xrLabel54
            // 
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(549.5468F, 4.083315F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // xrLabel56
            // 
            this.xrLabel56.Dpi = 100F;
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(160.5574F, 0F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(193.005F, 23F);
            this.xrLabel56.Text = "Total Clientes Encuestados";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel58});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel56,
            this.xrLabel54,
            this.lb2TotalClientesEncuestados});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 27.08333F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // efectividadPorRutaSubDetallado7
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(12, 12, 36, 29);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
