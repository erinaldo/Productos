using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaSubDetallado17
/// </summary>
public class efectividadPorRutaSubDetallado17 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    public XRLabel lb2ClientesConProductoPromocionNoEntregado;
    private XRLabel xrLabel113;
    private XRLabel xrLabel112;
    public XRLabel lb2TotalClientesProductoPromocionalNoEntregado;
    private XRLabel xrLabel115;
    private XRLabel xrLabel117;
    public XRLabel lb2TotalProductoPromocionalNoEntregado;
    private XRLabel xrLabel110;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaSubDetallado17()
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
            this.lb2ClientesConProductoPromocionNoEntregado = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel113 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel112 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalClientesProductoPromocionalNoEntregado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel115 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel117 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2TotalProductoPromocionalNoEntregado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel110 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb2ClientesConProductoPromocionNoEntregado});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lb2ClientesConProductoPromocionNoEntregado
            // 
            this.lb2ClientesConProductoPromocionNoEntregado.Dpi = 100F;
            this.lb2ClientesConProductoPromocionNoEntregado.LocationFloat = new DevExpress.Utils.PointFloat(24.26111F, 0F);
            this.lb2ClientesConProductoPromocionNoEntregado.Name = "lb2ClientesConProductoPromocionNoEntregado";
            this.lb2ClientesConProductoPromocionNoEntregado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2ClientesConProductoPromocionNoEntregado.SizeF = new System.Drawing.SizeF(775.0195F, 23F);
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
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel113});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 23.95833F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel113
            // 
            this.xrLabel113.Dpi = 100F;
            this.xrLabel113.LocationFloat = new DevExpress.Utils.PointFloat(24.26111F, 0F);
            this.xrLabel113.Name = "xrLabel113";
            this.xrLabel113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel113.SizeF = new System.Drawing.SizeF(402.0195F, 23F);
            this.xrLabel113.Text = "CLIENTES CON PRODUCTO DE PROMOCION NO ENTREGADO";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel112,
            this.lb2TotalClientesProductoPromocionalNoEntregado,
            this.xrLabel115,
            this.xrLabel117,
            this.lb2TotalProductoPromocionalNoEntregado,
            this.xrLabel110});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 47.91667F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel112
            // 
            this.xrLabel112.Dpi = 100F;
            this.xrLabel112.LocationFloat = new DevExpress.Utils.PointFloat(88.51142F, 0F);
            this.xrLabel112.Name = "xrLabel112";
            this.xrLabel112.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel112.SizeF = new System.Drawing.SizeF(245.639F, 23.00024F);
            this.xrLabel112.Text = "Total Producto Promocional no Entregado";
            // 
            // lb2TotalClientesProductoPromocionalNoEntregado
            // 
            this.lb2TotalClientesProductoPromocionalNoEntregado.Dpi = 100F;
            this.lb2TotalClientesProductoPromocionalNoEntregado.LocationFloat = new DevExpress.Utils.PointFloat(452.0789F, 22.99989F);
            this.lb2TotalClientesProductoPromocionalNoEntregado.Name = "lb2TotalClientesProductoPromocionalNoEntregado";
            this.lb2TotalClientesProductoPromocionalNoEntregado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalClientesProductoPromocionalNoEntregado.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel115
            // 
            this.xrLabel115.Dpi = 100F;
            this.xrLabel115.LocationFloat = new DevExpress.Utils.PointFloat(23.80277F, 22.99989F);
            this.xrLabel115.Name = "xrLabel115";
            this.xrLabel115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel115.SizeF = new System.Drawing.SizeF(312.7698F, 23F);
            this.xrLabel115.Text = "Total Clientes con Producto Promocional no Entregado";
            // 
            // xrLabel117
            // 
            this.xrLabel117.Dpi = 100F;
            this.xrLabel117.LocationFloat = new DevExpress.Utils.PointFloat(552.2089F, 22.99989F);
            this.xrLabel117.Name = "xrLabel117";
            this.xrLabel117.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel117.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // lb2TotalProductoPromocionalNoEntregado
            // 
            this.lb2TotalProductoPromocionalNoEntregado.Dpi = 100F;
            this.lb2TotalProductoPromocionalNoEntregado.LocationFloat = new DevExpress.Utils.PointFloat(452.0788F, 0F);
            this.lb2TotalProductoPromocionalNoEntregado.Name = "lb2TotalProductoPromocionalNoEntregado";
            this.lb2TotalProductoPromocionalNoEntregado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2TotalProductoPromocionalNoEntregado.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // xrLabel110
            // 
            this.xrLabel110.Dpi = 100F;
            this.xrLabel110.LocationFloat = new DevExpress.Utils.PointFloat(552.0788F, 0F);
            this.xrLabel110.Name = "xrLabel110";
            this.xrLabel110.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel110.SizeF = new System.Drawing.SizeF(99.17572F, 23F);
            // 
            // efectividadPorRutaSubDetallado17
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
