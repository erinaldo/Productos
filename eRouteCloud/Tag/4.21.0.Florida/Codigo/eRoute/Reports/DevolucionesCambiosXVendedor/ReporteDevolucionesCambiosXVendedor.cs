using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class ReporteDevolucionesCambiosXVendedor : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    public GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    public GroupHeaderBand GroupHeader4;
    private PageHeaderBand PageHeader;
    private GroupFooterBand GroupFooter2;
    public XRSubreport xrSubReporte;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel labelCedis;
    public XRLabel labelFecha;
    public XRLabel labelVendedor;
    public XRLabel cedis;
    public XRLabel fechas;
    public XRLabel vendedor;
    public XRLabel empresa;
    public XRLabel clientes;
    public XRLabel labelCliente;
    private XRLabel xrLabel2;
    private XRLabel xrLabel23;
    public XRLabel ldKg;
    private XRLabel xrLabel25;
    private XRLabel xrLabel27;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLine xrLine1;
    private XRLine xrLine2;
    public XRLabel lCedi;
    private XRLabel xrLabel83;
    public XRLabel lFecha;
    private XRLabel xrLabel85;
    public XRLabel lVendedor;
    private XRLabel xrLabel86;
    public XRLabel lCliente;
    public XRLabel dcMotivo;
    public XRLabel dcImporte;
    public XRLabel dcCambio;
    public XRLabel dcCantidad;
    public XRLabel ddMotivo;
    public XRLabel ddImporte;
    public XRLabel ddCantidad;
    public XRLabel dPrecio;
    public XRLabel dUnidad;
    public XRLabel dProducto;
    public XRLabel dClave;
    private XRLabel xrLabel1;
    public XRLabel lctCambio;
    public XRLabel lctCantidad;
    public XRLabel ldtImporte;
    public XRLabel ldtCantidad;
    private XRLine xrLine3;
    public XRLabel lctImporte;
    public XRLabel lctCImporte;
    public XRLabel dcCImporte;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteDevolucionesCambiosXVendedor()
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
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrSubReporte = new DevExpress.XtraReports.UI.XRSubreport();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.cedis = new DevExpress.XtraReports.UI.XRLabel();
            this.fechas = new DevExpress.XtraReports.UI.XRLabel();
            this.vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.clientes = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.ldKg = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.lCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.lFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.lVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            this.lCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.dcMotivo = new DevExpress.XtraReports.UI.XRLabel();
            this.dcImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dcCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.dcCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.ddMotivo = new DevExpress.XtraReports.UI.XRLabel();
            this.ddImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.ddCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dPrecio = new DevExpress.XtraReports.UI.XRLabel();
            this.dUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.dClave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lctCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.lctCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.ldtImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.ldtCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.lctImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.lctCImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dcCImporte = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.dcCImporte,
            this.dcMotivo,
            this.dcImporte,
            this.dcCambio,
            this.dcCantidad,
            this.ddMotivo,
            this.ddImporte,
            this.ddCantidad,
            this.dPrecio,
            this.dUnidad,
            this.dProducto,
            this.dClave});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 38.95836F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.labelCedis,
            this.labelFecha,
            this.labelVendedor,
            this.cedis,
            this.fechas,
            this.vendedor,
            this.empresa,
            this.clientes,
            this.labelCliente});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 170F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lCliente});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 15F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lctImporte,
            this.lctCImporte,
            this.xrLabel1,
            this.lctCambio,
            this.lctCantidad,
            this.ldtImporte,
            this.ldtCantidad,
            this.xrLine3});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 17F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lVendedor,
            this.xrLabel86});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 15F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lFecha,
            this.xrLabel85});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 15F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lCedi,
            this.xrLabel83});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 15F;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel23,
            this.ldKg,
            this.xrLabel25,
            this.xrLabel27,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39,
            this.xrLine1,
            this.xrLine2});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 35F;
            this.PageHeader.Name = "PageHeader";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubReporte});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 30F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // xrSubReporte
            // 
            this.xrSubReporte.CanShrink = true;
            this.xrSubReporte.Dpi = 100F;
            this.xrSubReporte.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubReporte.Name = "xrSubReporte";
            this.xrSubReporte.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding(null, null, null));
            this.xrSubReporte.SizeF = new System.Drawing.SizeF(1080F, 30F);
            this.xrSubReporte.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // reporte
            // 
            this.reporte.CanGrow = false;
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(295F, 50F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelCedis
            // 
            this.labelCedis.CanGrow = false;
            this.labelCedis.Dpi = 100F;
            this.labelCedis.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelCedis.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.labelCedis.Name = "labelCedis";
            this.labelCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCedis.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelCedis.StylePriority.UseFont = false;
            this.labelCedis.StylePriority.UseTextAlignment = false;
            this.labelCedis.Text = "Centro De Distribución:";
            this.labelCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelFecha
            // 
            this.labelFecha.CanGrow = false;
            this.labelFecha.Dpi = 100F;
            this.labelFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelFecha.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFecha.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelFecha.StylePriority.UseFont = false;
            this.labelFecha.StylePriority.UseTextAlignment = false;
            this.labelFecha.Text = "Fecha(s):";
            this.labelFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelVendedor
            // 
            this.labelVendedor.CanGrow = false;
            this.labelVendedor.Dpi = 100F;
            this.labelVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
            this.labelVendedor.Name = "labelVendedor";
            this.labelVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedor.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelVendedor.StylePriority.UseFont = false;
            this.labelVendedor.StylePriority.UseTextAlignment = false;
            this.labelVendedor.Text = "Vendedor:";
            this.labelVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // cedis
            // 
            this.cedis.CanGrow = false;
            this.cedis.Dpi = 100F;
            this.cedis.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.cedis.LocationFloat = new DevExpress.Utils.PointFloat(150F, 100F);
            this.cedis.Name = "cedis";
            this.cedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cedis.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.cedis.StylePriority.UseFont = false;
            this.cedis.StylePriority.UseTextAlignment = false;
            this.cedis.Text = "cedis";
            this.cedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fechas
            // 
            this.fechas.CanGrow = false;
            this.fechas.Dpi = 100F;
            this.fechas.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.fechas.LocationFloat = new DevExpress.Utils.PointFloat(150F, 115F);
            this.fechas.Name = "fechas";
            this.fechas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechas.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.fechas.StylePriority.UseFont = false;
            this.fechas.StylePriority.UseTextAlignment = false;
            this.fechas.Text = "fechas";
            this.fechas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vendedor
            // 
            this.vendedor.CanGrow = false;
            this.vendedor.Dpi = 100F;
            this.vendedor.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.vendedor.LocationFloat = new DevExpress.Utils.PointFloat(150F, 130F);
            this.vendedor.Name = "vendedor";
            this.vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vendedor.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.vendedor.StylePriority.UseFont = false;
            this.vendedor.StylePriority.UseTextAlignment = false;
            this.vendedor.Text = "vendedor";
            this.vendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // empresa
            // 
            this.empresa.CanGrow = false;
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(295F, 10F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // clientes
            // 
            this.clientes.CanGrow = false;
            this.clientes.Dpi = 100F;
            this.clientes.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.clientes.LocationFloat = new DevExpress.Utils.PointFloat(150F, 145F);
            this.clientes.Name = "clientes";
            this.clientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clientes.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.clientes.StylePriority.UseFont = false;
            this.clientes.StylePriority.UseTextAlignment = false;
            this.clientes.Text = "clientes";
            this.clientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCliente
            // 
            this.labelCliente.CanGrow = false;
            this.labelCliente.Dpi = 100F;
            this.labelCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.labelCliente.LocationFloat = new DevExpress.Utils.PointFloat(0F, 145F);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCliente.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.labelCliente.StylePriority.UseFont = false;
            this.labelCliente.StylePriority.UseTextAlignment = false;
            this.labelCliente.Text = "Cliente(s):";
            this.labelCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(950F, 17.00002F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(130F, 15F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Motivo";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(860F, 17F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Importe";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ldKg
            // 
            this.ldKg.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldKg.Dpi = 100F;
            this.ldKg.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldKg.LocationFloat = new DevExpress.Utils.PointFloat(770F, 17.00002F);
            this.ldKg.Name = "ldKg";
            this.ldKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldKg.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.ldKg.StylePriority.UseBorders = false;
            this.ldKg.StylePriority.UseFont = false;
            this.ldKg.StylePriority.UseTextAlignment = false;
            this.ldKg.Text = "Cambio Por";
            this.ldKg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(680F, 17.00002F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel25.StylePriority.UseBorders = false;
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Cantidad";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(560F, 17F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(120F, 15F);
            this.xrLabel27.StylePriority.UseBorders = false;
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Motivo";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(380F, 17.00002F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel32.StylePriority.UseBorders = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Cantidad";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(470F, 17.00002F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Importe";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(680F, 2.000015F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(400F, 15F);
            this.xrLabel34.StylePriority.UseBorders = false;
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "Cambio";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel35
            // 
            this.xrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(380F, 2F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(300F, 15F);
            this.xrLabel35.StylePriority.UseBorders = false;
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "Devolucion";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(330F, 2.000015F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(50F, 30F);
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "Precio";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(280F, 2.000015F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(50F, 30F);
            this.xrLabel37.StylePriority.UseBorders = false;
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "Unidad";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(80F, 2F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(200F, 30F);
            this.xrLabel38.StylePriority.UseBorders = false;
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "Producto";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(80F, 30F);
            this.xrLabel39.StylePriority.UseBorders = false;
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "Clave";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1080F, 2F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1080F, 2F);
            // 
            // lCedi
            // 
            this.lCedi.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lCedi.Dpi = 100F;
            this.lCedi.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lCedi.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lCedi.Name = "lCedi";
            this.lCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lCedi.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.lCedi.StylePriority.UseBorders = false;
            this.lCedi.StylePriority.UseFont = false;
            this.lCedi.StylePriority.UseTextAlignment = false;
            this.lCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel83
            // 
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.Text = "Centro De Distribución:";
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lFecha
            // 
            this.lFecha.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lFecha.Dpi = 100F;
            this.lFecha.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lFecha.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lFecha.Name = "lFecha";
            this.lFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lFecha.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.lFecha.StylePriority.UseBorders = false;
            this.lFecha.StylePriority.UseFont = false;
            this.lFecha.StylePriority.UseTextAlignment = false;
            this.lFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel85
            // 
            this.xrLabel85.Dpi = 100F;
            this.xrLabel85.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(20F, 0F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(45F, 15F);
            this.xrLabel85.StylePriority.UseFont = false;
            this.xrLabel85.StylePriority.UseTextAlignment = false;
            this.xrLabel85.Text = "Fecha:";
            this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lVendedor
            // 
            this.lVendedor.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lVendedor.Dpi = 100F;
            this.lVendedor.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lVendedor.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lVendedor.Name = "lVendedor";
            this.lVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lVendedor.SizeF = new System.Drawing.SizeF(930F, 15F);
            this.lVendedor.StylePriority.UseBorders = false;
            this.lVendedor.StylePriority.UseFont = false;
            this.lVendedor.StylePriority.UseTextAlignment = false;
            this.lVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel86
            // 
            this.xrLabel86.Dpi = 100F;
            this.xrLabel86.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(40F, 0F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel86.StylePriority.UseFont = false;
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            this.xrLabel86.Text = "Vendedor:";
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lCliente
            // 
            this.lCliente.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lCliente.Dpi = 100F;
            this.lCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lCliente.LocationFloat = new DevExpress.Utils.PointFloat(60F, 0F);
            this.lCliente.Name = "lCliente";
            this.lCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lCliente.SizeF = new System.Drawing.SizeF(1020F, 15F);
            this.lCliente.StylePriority.UseBorders = false;
            this.lCliente.StylePriority.UseFont = false;
            this.lCliente.StylePriority.UseTextAlignment = false;
            this.lCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dcMotivo
            // 
            this.dcMotivo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcMotivo.Dpi = 100F;
            this.dcMotivo.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcMotivo.LocationFloat = new DevExpress.Utils.PointFloat(949.9999F, 0F);
            this.dcMotivo.Name = "dcMotivo";
            this.dcMotivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcMotivo.SizeF = new System.Drawing.SizeF(130F, 15F);
            this.dcMotivo.StylePriority.UseBorders = false;
            this.dcMotivo.StylePriority.UseFont = false;
            this.dcMotivo.StylePriority.UseTextAlignment = false;
            this.dcMotivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dcImporte
            // 
            this.dcImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcImporte.Dpi = 100F;
            this.dcImporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcImporte.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
            this.dcImporte.Name = "dcImporte";
            this.dcImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcImporte.StylePriority.UseBorders = false;
            this.dcImporte.StylePriority.UseFont = false;
            this.dcImporte.StylePriority.UseTextAlignment = false;
            this.dcImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcCambio
            // 
            this.dcCambio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcCambio.Dpi = 100F;
            this.dcCambio.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcCambio.LocationFloat = new DevExpress.Utils.PointFloat(770F, 0F);
            this.dcCambio.Name = "dcCambio";
            this.dcCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcCambio.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcCambio.StylePriority.UseBorders = false;
            this.dcCambio.StylePriority.UseFont = false;
            this.dcCambio.StylePriority.UseTextAlignment = false;
            this.dcCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcCantidad
            // 
            this.dcCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcCantidad.Dpi = 100F;
            this.dcCantidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcCantidad.LocationFloat = new DevExpress.Utils.PointFloat(680F, 0F);
            this.dcCantidad.Name = "dcCantidad";
            this.dcCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcCantidad.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcCantidad.StylePriority.UseBorders = false;
            this.dcCantidad.StylePriority.UseFont = false;
            this.dcCantidad.StylePriority.UseTextAlignment = false;
            this.dcCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ddMotivo
            // 
            this.ddMotivo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddMotivo.Dpi = 100F;
            this.ddMotivo.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddMotivo.LocationFloat = new DevExpress.Utils.PointFloat(560F, 0F);
            this.ddMotivo.Name = "ddMotivo";
            this.ddMotivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddMotivo.SizeF = new System.Drawing.SizeF(120F, 15F);
            this.ddMotivo.StylePriority.UseBorders = false;
            this.ddMotivo.StylePriority.UseFont = false;
            this.ddMotivo.StylePriority.UseTextAlignment = false;
            this.ddMotivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ddImporte
            // 
            this.ddImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddImporte.Dpi = 100F;
            this.ddImporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddImporte.LocationFloat = new DevExpress.Utils.PointFloat(470F, 0F);
            this.ddImporte.Name = "ddImporte";
            this.ddImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.ddImporte.StylePriority.UseBorders = false;
            this.ddImporte.StylePriority.UseFont = false;
            this.ddImporte.StylePriority.UseTextAlignment = false;
            this.ddImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ddCantidad
            // 
            this.ddCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddCantidad.Dpi = 100F;
            this.ddCantidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddCantidad.LocationFloat = new DevExpress.Utils.PointFloat(380.0002F, 0F);
            this.ddCantidad.Name = "ddCantidad";
            this.ddCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddCantidad.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.ddCantidad.StylePriority.UseBorders = false;
            this.ddCantidad.StylePriority.UseFont = false;
            this.ddCantidad.StylePriority.UseTextAlignment = false;
            this.ddCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dPrecio
            // 
            this.dPrecio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dPrecio.Dpi = 100F;
            this.dPrecio.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dPrecio.LocationFloat = new DevExpress.Utils.PointFloat(330.0001F, 0F);
            this.dPrecio.Name = "dPrecio";
            this.dPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPrecio.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.dPrecio.StylePriority.UseBorders = false;
            this.dPrecio.StylePriority.UseFont = false;
            this.dPrecio.StylePriority.UseTextAlignment = false;
            this.dPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dUnidad
            // 
            this.dUnidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dUnidad.Dpi = 100F;
            this.dUnidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dUnidad.LocationFloat = new DevExpress.Utils.PointFloat(280.0001F, 0F);
            this.dUnidad.Name = "dUnidad";
            this.dUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dUnidad.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.dUnidad.StylePriority.UseBorders = false;
            this.dUnidad.StylePriority.UseFont = false;
            this.dUnidad.StylePriority.UseTextAlignment = false;
            this.dUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dProducto
            // 
            this.dProducto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dProducto.Dpi = 100F;
            this.dProducto.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dProducto.LocationFloat = new DevExpress.Utils.PointFloat(80.00006F, 0F);
            this.dProducto.Name = "dProducto";
            this.dProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dProducto.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.dProducto.StylePriority.UseBorders = false;
            this.dProducto.StylePriority.UseFont = false;
            this.dProducto.StylePriority.UseTextAlignment = false;
            this.dProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dClave
            // 
            this.dClave.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dClave.Dpi = 100F;
            this.dClave.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dClave.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 0F);
            this.dClave.Name = "dClave";
            this.dClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dClave.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.dClave.StylePriority.UseBorders = false;
            this.dClave.StylePriority.UseFont = false;
            this.dClave.StylePriority.UseTextAlignment = false;
            this.dClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(260.0002F, 2F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(120F, 15F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Total De Unidades:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lctCambio
            // 
            this.lctCambio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lctCambio.Dpi = 100F;
            this.lctCambio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lctCambio.LocationFloat = new DevExpress.Utils.PointFloat(860F, 2F);
            this.lctCambio.Name = "lctCambio";
            this.lctCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lctCambio.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.lctCambio.StylePriority.UseBorders = false;
            this.lctCambio.StylePriority.UseFont = false;
            this.lctCambio.StylePriority.UseTextAlignment = false;
            this.lctCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lctCantidad
            // 
            this.lctCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lctCantidad.Dpi = 100F;
            this.lctCantidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lctCantidad.LocationFloat = new DevExpress.Utils.PointFloat(680F, 2F);
            this.lctCantidad.Name = "lctCantidad";
            this.lctCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lctCantidad.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.lctCantidad.StylePriority.UseBorders = false;
            this.lctCantidad.StylePriority.UseFont = false;
            this.lctCantidad.StylePriority.UseTextAlignment = false;
            this.lctCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ldtImporte
            // 
            this.ldtImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldtImporte.Dpi = 100F;
            this.ldtImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldtImporte.LocationFloat = new DevExpress.Utils.PointFloat(470F, 2F);
            this.ldtImporte.Name = "ldtImporte";
            this.ldtImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldtImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.ldtImporte.StylePriority.UseBorders = false;
            this.ldtImporte.StylePriority.UseFont = false;
            this.ldtImporte.StylePriority.UseTextAlignment = false;
            this.ldtImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ldtCantidad
            // 
            this.ldtCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ldtCantidad.Dpi = 100F;
            this.ldtCantidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.ldtCantidad.LocationFloat = new DevExpress.Utils.PointFloat(380F, 2F);
            this.ldtCantidad.Name = "ldtCantidad";
            this.ldtCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldtCantidad.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.ldtCantidad.StylePriority.UseBorders = false;
            this.ldtCantidad.StylePriority.UseFont = false;
            this.ldtCantidad.StylePriority.UseTextAlignment = false;
            this.ldtCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(380.0002F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(700F, 2F);
            // 
            // lctImporte
            // 
            this.lctImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lctImporte.Dpi = 100F;
            this.lctImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lctImporte.LocationFloat = new DevExpress.Utils.PointFloat(770F, 2F);
            this.lctImporte.Name = "lctImporte";
            this.lctImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lctImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.lctImporte.StylePriority.UseBorders = false;
            this.lctImporte.StylePriority.UseFont = false;
            this.lctImporte.StylePriority.UseTextAlignment = false;
            this.lctImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lctCImporte
            // 
            this.lctCImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lctCImporte.Dpi = 100F;
            this.lctCImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lctCImporte.LocationFloat = new DevExpress.Utils.PointFloat(950F, 2F);
            this.lctCImporte.Name = "lctCImporte";
            this.lctCImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lctCImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.lctCImporte.StylePriority.UseBorders = false;
            this.lctCImporte.StylePriority.UseFont = false;
            this.lctCImporte.StylePriority.UseTextAlignment = false;
            this.lctCImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcCImporte
            // 
            this.dcCImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcCImporte.Dpi = 100F;
            this.dcCImporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcCImporte.LocationFloat = new DevExpress.Utils.PointFloat(860F, 15.00003F);
            this.dcCImporte.Name = "dcCImporte";
            this.dcCImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcCImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcCImporte.StylePriority.UseBorders = false;
            this.dcCImporte.StylePriority.UseFont = false;
            this.dcCImporte.StylePriority.UseTextAlignment = false;
            this.dcCImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReporteDevolucionesCambiosXVendedor
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.PageHeader,
            this.GroupFooter2});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
