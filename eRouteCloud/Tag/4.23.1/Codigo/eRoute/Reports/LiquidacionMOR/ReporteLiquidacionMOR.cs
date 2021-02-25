using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class ReporteLiquidacionMOR : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel20;
    private XRLabel xrLabel24;
    public XRLabel headerFecha;
    public XRLabel headerVendedor;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    public GroupHeaderBand groupHeaderVendedor;
    public XRSubreport SubVentasPorProducto;
    public GroupHeaderBand groupHeaderVentasProducto;
    public GroupHeaderBand groupHeaderVentasContado;
    public GroupHeaderBand groupHeaderVentasCredito;
    public GroupHeaderBand groupHeaderCobranzaContado;
    public GroupHeaderBand groupHeaderCobranzaCredito;
    public GroupHeaderBand GroupHeader1;
    public XRSubreport SubVentasContado;
    private XRSubreport SubVentasCredito;
    private XRSubreport SubCobranzaContado;
    private XRSubreport SubCobranzaCredito;
    public XRLabel telefonoCedis;
    public XRLabel direccionCedis;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteLiquidacionMOR()
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.groupHeaderVendedor = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.telefonoCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.direccionCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderVentasProducto = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.SubVentasPorProducto = new DevExpress.XtraReports.UI.XRSubreport();
            this.groupHeaderVentasContado = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.SubVentasContado = new DevExpress.XtraReports.UI.XRSubreport();
            this.groupHeaderVentasCredito = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.SubVentasCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.groupHeaderCobranzaContado = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.SubCobranzaContado = new DevExpress.XtraReports.UI.XRSubreport();
            this.groupHeaderCobranzaCredito = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.SubCobranzaCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 59.375F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 5.583318F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0.9165605F, 172.7085F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(136.7034F, 23.00001F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Fecha";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0.9165605F, 195.7084F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(136.7034F, 23F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor";
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(137.1616F, 172.7085F);
            this.headerFecha.Name = "headerFecha";
            this.headerFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerFecha.SizeF = new System.Drawing.SizeF(674.8384F, 23.00001F);
            this.headerFecha.StylePriority.UseFont = false;
            // 
            // headerVendedor
            // 
            this.headerVendedor.Dpi = 100F;
            this.headerVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(137.1616F, 195.7084F);
            this.headerVendedor.Name = "headerVendedor";
            this.headerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerVendedor.SizeF = new System.Drawing.SizeF(674.3751F, 23F);
            this.headerVendedor.StylePriority.UseFont = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(92F, 38.5F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(417F, 38.5F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // groupHeaderVendedor
            // 
            this.groupHeaderVendedor.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.telefonoCedis,
            this.direccionCedis,
            this.headerFecha,
            this.xrLabel20,
            this.xrLabel24,
            this.headerVendedor});
            this.groupHeaderVendedor.Dpi = 100F;
            this.groupHeaderVendedor.HeightF = 218.7084F;
            this.groupHeaderVendedor.Level = 6;
            this.groupHeaderVendedor.Name = "groupHeaderVendedor";
            // 
            // telefonoCedis
            // 
            this.telefonoCedis.Dpi = 100F;
            this.telefonoCedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoCedis.LocationFloat = new DevExpress.Utils.PointFloat(240.4168F, 143.0833F);
            this.telefonoCedis.Name = "telefonoCedis";
            this.telefonoCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.telefonoCedis.SizeF = new System.Drawing.SizeF(407.13F, 16.75001F);
            this.telefonoCedis.StylePriority.UseFont = false;
            this.telefonoCedis.StylePriority.UseTextAlignment = false;
            this.telefonoCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // direccionCedis
            // 
            this.direccionCedis.Dpi = 100F;
            this.direccionCedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionCedis.LocationFloat = new DevExpress.Utils.PointFloat(172.2503F, 126.3334F);
            this.direccionCedis.Name = "direccionCedis";
            this.direccionCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.direccionCedis.SizeF = new System.Drawing.SizeF(557.2914F, 16.75001F);
            this.direccionCedis.StylePriority.UseFont = false;
            this.direccionCedis.StylePriority.UseTextAlignment = false;
            this.direccionCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // groupHeaderVentasProducto
            // 
            this.groupHeaderVentasProducto.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SubVentasPorProducto});
            this.groupHeaderVentasProducto.Dpi = 100F;
            this.groupHeaderVentasProducto.HeightF = 30.20834F;
            this.groupHeaderVentasProducto.Level = 5;
            this.groupHeaderVentasProducto.Name = "groupHeaderVentasProducto";
            // 
            // SubVentasPorProducto
            // 
            this.SubVentasPorProducto.Dpi = 100F;
            this.SubVentasPorProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.2083461F);
            this.SubVentasPorProducto.Name = "SubVentasPorProducto";
            this.SubVentasPorProducto.SizeF = new System.Drawing.SizeF(230.9949F, 29.99999F);
            // 
            // groupHeaderVentasContado
            // 
            this.groupHeaderVentasContado.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SubVentasContado});
            this.groupHeaderVentasContado.Dpi = 100F;
            this.groupHeaderVentasContado.HeightF = 31.25F;
            this.groupHeaderVentasContado.Level = 4;
            this.groupHeaderVentasContado.Name = "groupHeaderVentasContado";
            // 
            // SubVentasContado
            // 
            this.SubVentasContado.Dpi = 100F;
            this.SubVentasContado.LocationFloat = new DevExpress.Utils.PointFloat(2.583313F, 0F);
            this.SubVentasContado.Name = "SubVentasContado";
            this.SubVentasContado.SizeF = new System.Drawing.SizeF(230.9949F, 29.99999F);
            // 
            // groupHeaderVentasCredito
            // 
            this.groupHeaderVentasCredito.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SubVentasCredito});
            this.groupHeaderVentasCredito.Dpi = 100F;
            this.groupHeaderVentasCredito.HeightF = 31.25F;
            this.groupHeaderVentasCredito.Level = 3;
            this.groupHeaderVentasCredito.Name = "groupHeaderVentasCredito";
            // 
            // SubVentasCredito
            // 
            this.SubVentasCredito.Dpi = 100F;
            this.SubVentasCredito.LocationFloat = new DevExpress.Utils.PointFloat(2.583313F, 0F);
            this.SubVentasCredito.Name = "SubVentasCredito";
            this.SubVentasCredito.SizeF = new System.Drawing.SizeF(230.9949F, 29.99999F);
            // 
            // groupHeaderCobranzaContado
            // 
            this.groupHeaderCobranzaContado.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SubCobranzaContado});
            this.groupHeaderCobranzaContado.Dpi = 100F;
            this.groupHeaderCobranzaContado.HeightF = 29.99999F;
            this.groupHeaderCobranzaContado.Level = 2;
            this.groupHeaderCobranzaContado.Name = "groupHeaderCobranzaContado";
            // 
            // SubCobranzaContado
            // 
            this.SubCobranzaContado.Dpi = 100F;
            this.SubCobranzaContado.LocationFloat = new DevExpress.Utils.PointFloat(1.666768F, 0F);
            this.SubCobranzaContado.Name = "SubCobranzaContado";
            this.SubCobranzaContado.SizeF = new System.Drawing.SizeF(231.9115F, 29.99999F);
            // 
            // groupHeaderCobranzaCredito
            // 
            this.groupHeaderCobranzaCredito.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SubCobranzaCredito});
            this.groupHeaderCobranzaCredito.Dpi = 100F;
            this.groupHeaderCobranzaCredito.HeightF = 31.25001F;
            this.groupHeaderCobranzaCredito.Level = 1;
            this.groupHeaderCobranzaCredito.Name = "groupHeaderCobranzaCredito";
            // 
            // SubCobranzaCredito
            // 
            this.SubCobranzaCredito.Dpi = 100F;
            this.SubCobranzaCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.250013F);
            this.SubCobranzaCredito.Name = "SubCobranzaCredito";
            this.SubCobranzaCredito.SizeF = new System.Drawing.SizeF(231.9115F, 29.99999F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 34.375F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(53.33333F, 5.000019F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(229.8333F, 70.00002F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(229.8333F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReporteLiquidacionMOR
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderVendedor,
            this.groupHeaderVentasProducto,
            this.groupHeaderVentasContado,
            this.groupHeaderVentasCredito,
            this.groupHeaderCobranzaContado,
            this.groupHeaderCobranzaCredito,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 6, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
