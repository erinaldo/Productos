using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class dImporte : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel folioCliente;
    public XRLabel dFolio;
    public XRLabel dFechaEntrega;
    public XRLabel dDescripcion;
    public XRLabel dPiezasVenta;
    public XRLabel dPiezasCambio;
    private ReportFooterBand ReportFooter;
    public XRLabel total;
    private XRLabel xrLabel16;
    public XRLabel detImporte;
    public XRLabel dPiezasPromocion;
    public XRLabel dCodigo;
    private GroupFooterBand GroupFooter1;
    public GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel4;
    public XRLabel totalPiezasPromocion;
    public XRLabel totalPiezasCambio;
    public XRLabel totalPiezas;
    public XRLabel subtotalImporte;
    public XRLabel subtotalPiezasPromocion;
    public XRLabel subtotalPiezasCambio;
    public XRLabel subtotalPiezas;
    private XRLabel xrLabel11;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLine xrLine1;
    private XRLine xrLine2;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel36;
    private XRLabel xrLabel8;
    private XRLabel xrLabel3;
    private XRLabel xrLabel1;
    private ReportHeaderBand ReportHeader;
    private XRLine xrLine4;
    private XRLine xrLine3;
    private XRLine xrLine6;
    private XRLine xrLine5;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public dImporte()
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
            this.detImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.dDescripcion = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.dCodigo = new DevExpress.XtraReports.UI.XRLabel();
            this.dFechaEntrega = new DevExpress.XtraReports.UI.XRLabel();
            this.dFolio = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.folioCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.totalPiezasPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.totalPiezasCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.totalPiezas = new DevExpress.XtraReports.UI.XRLabel();
            this.total = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.subtotalImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.subtotalPiezasPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.subtotalPiezasCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.subtotalPiezas = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.detImporte,
            this.dPiezasPromocion,
            this.dDescripcion,
            this.dPiezasVenta,
            this.dPiezasCambio,
            this.dCodigo,
            this.dFechaEntrega,
            this.dFolio});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 38.71526F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // detImporte
            // 
            this.detImporte.Dpi = 100F;
            this.detImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detImporte.LocationFloat = new DevExpress.Utils.PointFloat(969.9833F, 9.999764F);
            this.detImporte.Multiline = true;
            this.detImporte.Name = "detImporte";
            this.detImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detImporte.SizeF = new System.Drawing.SizeF(102.8264F, 23.00015F);
            this.detImporte.StylePriority.UseFont = false;
            this.detImporte.StylePriority.UseTextAlignment = false;
            this.detImporte.Text = "Importe (Venta)";
            this.detImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dPiezasPromocion
            // 
            this.dPiezasPromocion.Dpi = 100F;
            this.dPiezasPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasPromocion.LocationFloat = new DevExpress.Utils.PointFloat(851.73F, 10.00047F);
            this.dPiezasPromocion.Multiline = true;
            this.dPiezasPromocion.Name = "dPiezasPromocion";
            this.dPiezasPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasPromocion.SizeF = new System.Drawing.SizeF(118.1583F, 23.00015F);
            this.dPiezasPromocion.StylePriority.UseFont = false;
            this.dPiezasPromocion.StylePriority.UseTextAlignment = false;
            this.dPiezasPromocion.Text = "Piezas (Promoción)";
            this.dPiezasPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dDescripcion
            // 
            this.dDescripcion.Dpi = 100F;
            this.dDescripcion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(380.4561F, 10.00072F);
            this.dDescripcion.Multiline = true;
            this.dDescripcion.Name = "dDescripcion";
            this.dDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dDescripcion.SizeF = new System.Drawing.SizeF(271.5717F, 22.99991F);
            this.dDescripcion.StylePriority.UseFont = false;
            this.dDescripcion.StylePriority.UseTextAlignment = false;
            this.dDescripcion.Text = "Descripción";
            this.dDescripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dPiezasVenta
            // 
            this.dPiezasVenta.Dpi = 100F;
            this.dPiezasVenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasVenta.LocationFloat = new DevExpress.Utils.PointFloat(652.3133F, 10.0006F);
            this.dPiezasVenta.Multiline = true;
            this.dPiezasVenta.Name = "dPiezasVenta";
            this.dPiezasVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasVenta.SizeF = new System.Drawing.SizeF(95.26196F, 23.00003F);
            this.dPiezasVenta.StylePriority.UseFont = false;
            this.dPiezasVenta.StylePriority.UseTextAlignment = false;
            this.dPiezasVenta.Text = "Piezas (Venta)";
            this.dPiezasVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dPiezasCambio
            // 
            this.dPiezasCambio.Dpi = 100F;
            this.dPiezasCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasCambio.LocationFloat = new DevExpress.Utils.PointFloat(747.7656F, 10.00047F);
            this.dPiezasCambio.Multiline = true;
            this.dPiezasCambio.Name = "dPiezasCambio";
            this.dPiezasCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasCambio.SizeF = new System.Drawing.SizeF(103.8688F, 23.00015F);
            this.dPiezasCambio.StylePriority.UseFont = false;
            this.dPiezasCambio.StylePriority.UseTextAlignment = false;
            this.dPiezasCambio.Text = "Piezas (Cambio)";
            this.dPiezasCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dCodigo
            // 
            this.dCodigo.Dpi = 100F;
            this.dCodigo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dCodigo.LocationFloat = new DevExpress.Utils.PointFloat(268.9997F, 9.999764F);
            this.dCodigo.Name = "dCodigo";
            this.dCodigo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dCodigo.SizeF = new System.Drawing.SizeF(111.3612F, 23F);
            this.dCodigo.StylePriority.UseFont = false;
            this.dCodigo.Text = "Código";
            // 
            // dFechaEntrega
            // 
            this.dFechaEntrega.Dpi = 100F;
            this.dFechaEntrega.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFechaEntrega.LocationFloat = new DevExpress.Utils.PointFloat(120.1768F, 9.999887F);
            this.dFechaEntrega.Name = "dFechaEntrega";
            this.dFechaEntrega.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dFechaEntrega.SizeF = new System.Drawing.SizeF(148.7276F, 23F);
            this.dFechaEntrega.StylePriority.UseFont = false;
            this.dFechaEntrega.Text = "Fecha de entrega";
            // 
            // dFolio
            // 
            this.dFolio.Dpi = 100F;
            this.dFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFolio.LocationFloat = new DevExpress.Utils.PointFloat(2.399738F, 10.00001F);
            this.dFolio.Multiline = true;
            this.dFolio.Name = "dFolio";
            this.dFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dFolio.SizeF = new System.Drawing.SizeF(117.7772F, 22.99996F);
            this.dFolio.StylePriority.UseFont = false;
            this.dFolio.StylePriority.UseTextAlignment = false;
            this.dFolio.Text = "Folio";
            this.dFolio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 14.42308F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 1F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // folioCliente
            // 
            this.folioCliente.Dpi = 100F;
            this.folioCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folioCliente.LocationFloat = new DevExpress.Utils.PointFloat(0.8096939F, 10.00001F);
            this.folioCliente.Name = "folioCliente";
            this.folioCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.folioCliente.SizeF = new System.Drawing.SizeF(546.9925F, 23F);
            this.folioCliente.StylePriority.UseFont = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.xrLine3,
            this.totalPiezasPromocion,
            this.totalPiezasCambio,
            this.totalPiezas,
            this.total,
            this.xrLabel16});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 43.75003F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // totalPiezasPromocion
            // 
            this.totalPiezasPromocion.Dpi = 100F;
            this.totalPiezasPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezasPromocion.LocationFloat = new DevExpress.Utils.PointFloat(852.2832F, 10.00002F);
            this.totalPiezasPromocion.Multiline = true;
            this.totalPiezasPromocion.Name = "totalPiezasPromocion";
            this.totalPiezasPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezasPromocion.SizeF = new System.Drawing.SizeF(118.1583F, 23.00015F);
            this.totalPiezasPromocion.StylePriority.UseFont = false;
            this.totalPiezasPromocion.StylePriority.UseTextAlignment = false;
            this.totalPiezasPromocion.Text = "Piezas (Promoción)";
            this.totalPiezasPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // totalPiezasCambio
            // 
            this.totalPiezasCambio.Dpi = 100F;
            this.totalPiezasCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezasCambio.LocationFloat = new DevExpress.Utils.PointFloat(748.0911F, 9.999884F);
            this.totalPiezasCambio.Multiline = true;
            this.totalPiezasCambio.Name = "totalPiezasCambio";
            this.totalPiezasCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezasCambio.SizeF = new System.Drawing.SizeF(103.8688F, 23.00015F);
            this.totalPiezasCambio.StylePriority.UseFont = false;
            this.totalPiezasCambio.StylePriority.UseTextAlignment = false;
            this.totalPiezasCambio.Text = "Piezas (Cambio)";
            this.totalPiezasCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // totalPiezas
            // 
            this.totalPiezas.Dpi = 100F;
            this.totalPiezas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezas.LocationFloat = new DevExpress.Utils.PointFloat(652.8292F, 9.99999F);
            this.totalPiezas.Multiline = true;
            this.totalPiezas.Name = "totalPiezas";
            this.totalPiezas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezas.SizeF = new System.Drawing.SizeF(95.26196F, 23.00003F);
            this.totalPiezas.StylePriority.UseFont = false;
            this.totalPiezas.StylePriority.UseTextAlignment = false;
            this.totalPiezas.Text = "Piezas (Venta)";
            this.totalPiezas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // total
            // 
            this.total.Dpi = 100F;
            this.total.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.LocationFloat = new DevExpress.Utils.PointFloat(970.4416F, 10.00002F);
            this.total.Multiline = true;
            this.total.Name = "total";
            this.total.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.total.SizeF = new System.Drawing.SizeF(101.5584F, 23.00012F);
            this.total.StylePriority.UseFont = false;
            this.total.StylePriority.UseTextAlignment = false;
            this.total.Text = "Total";
            this.total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(503.4641F, 10.00002F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(149.3652F, 23.00003F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "GRAN TOTAL DE VENTAS";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine6,
            this.xrLine5,
            this.subtotalImporte,
            this.subtotalPiezasPromocion,
            this.subtotalPiezasCambio,
            this.subtotalPiezas,
            this.xrLabel4});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 41.28787F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // subtotalImporte
            // 
            this.subtotalImporte.Dpi = 100F;
            this.subtotalImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalImporte.LocationFloat = new DevExpress.Utils.PointFloat(970.1735F, 9.999752F);
            this.subtotalImporte.Multiline = true;
            this.subtotalImporte.Name = "subtotalImporte";
            this.subtotalImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subtotalImporte.SizeF = new System.Drawing.SizeF(102.8264F, 23.00015F);
            this.subtotalImporte.StylePriority.UseFont = false;
            this.subtotalImporte.StylePriority.UseTextAlignment = false;
            this.subtotalImporte.Text = "Importe (Venta)";
            this.subtotalImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // subtotalPiezasPromocion
            // 
            this.subtotalPiezasPromocion.Dpi = 100F;
            this.subtotalPiezasPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalPiezasPromocion.LocationFloat = new DevExpress.Utils.PointFloat(851.8248F, 9.999752F);
            this.subtotalPiezasPromocion.Multiline = true;
            this.subtotalPiezasPromocion.Name = "subtotalPiezasPromocion";
            this.subtotalPiezasPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subtotalPiezasPromocion.SizeF = new System.Drawing.SizeF(118.1583F, 23.00015F);
            this.subtotalPiezasPromocion.StylePriority.UseFont = false;
            this.subtotalPiezasPromocion.StylePriority.UseTextAlignment = false;
            this.subtotalPiezasPromocion.Text = "Piezas (Promoción)";
            this.subtotalPiezasPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // subtotalPiezasCambio
            // 
            this.subtotalPiezasCambio.Dpi = 100F;
            this.subtotalPiezasCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalPiezasCambio.LocationFloat = new DevExpress.Utils.PointFloat(747.861F, 10.00002F);
            this.subtotalPiezasCambio.Multiline = true;
            this.subtotalPiezasCambio.Name = "subtotalPiezasCambio";
            this.subtotalPiezasCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subtotalPiezasCambio.SizeF = new System.Drawing.SizeF(103.8688F, 23.00015F);
            this.subtotalPiezasCambio.StylePriority.UseFont = false;
            this.subtotalPiezasCambio.StylePriority.UseTextAlignment = false;
            this.subtotalPiezasCambio.Text = "Piezas (Cambio)";
            this.subtotalPiezasCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // subtotalPiezas
            // 
            this.subtotalPiezas.Dpi = 100F;
            this.subtotalPiezas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalPiezas.LocationFloat = new DevExpress.Utils.PointFloat(652.4086F, 9.99991F);
            this.subtotalPiezas.Multiline = true;
            this.subtotalPiezas.Name = "subtotalPiezas";
            this.subtotalPiezas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subtotalPiezas.SizeF = new System.Drawing.SizeF(95.26196F, 23.00003F);
            this.subtotalPiezas.StylePriority.UseFont = false;
            this.subtotalPiezas.StylePriority.UseTextAlignment = false;
            this.subtotalPiezas.Text = "Piezas (Venta)";
            this.subtotalPiezas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(534.2557F, 10.00002F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(117.9625F, 22.99991F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "SubTotal";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.folioCliente});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 44.39936F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(851.73F, 55.40554F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(118.2534F, 23.00018F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Piezas (Promoción)";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(747.7661F, 55.40554F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(103.964F, 23.00015F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Piezas (Cambio)";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.8096939F, 42.82133F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1072F, 12.58331F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 78.40587F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1072.5F, 16.05554F);
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(2.214481F, 55.40479F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(117.9625F, 22.99991F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Folio";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(120.1769F, 55.40586F);
            this.xrLabel34.Multiline = true;
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(148.8228F, 23F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.Text = "Fecha de entrega\r\n";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(268.9997F, 55.40465F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(111.4564F, 23F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.Text = "Código";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(380.456F, 55.40479F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(271.7621F, 22.99991F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Descripción";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(652.3133F, 55.4058F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(95.35724F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Piezas (Venta)";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(969.9833F, 55.40554F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(102.9216F, 23.00012F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Importe (Venta)";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999984F, 9.999996F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(403.07F, 21.95834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "II - VENTA POR CLIENTES";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel11,
            this.xrLine2,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel3,
            this.xrLabel8,
            this.xrLabel36,
            this.xrLabel1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 98.88451F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(212.4631F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(860.5369F, 7.62817F);
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(212.4631F, 33.00018F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(860.5369F, 7.62817F);
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(492.9643F, 0F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(570.0358F, 7.62817F);
            // 
            // xrLine6
            // 
            this.xrLine6.Dpi = 100F;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(492.9643F, 32.9999F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(570.5357F, 7.62817F);
            // 
            // dImporte
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.GroupFooter1,
            this.GroupHeader1,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 14, 1);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
