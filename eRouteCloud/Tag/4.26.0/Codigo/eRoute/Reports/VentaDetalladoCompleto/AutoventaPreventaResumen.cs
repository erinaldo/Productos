using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class AutoVentaResumen : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    private XRLine xrLine1;
    private XRLine xrLine2;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel3;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    public XRLabel dFolio;
    public XRLabel dFechaEntrega;
    public XRLabel dPiezasVenta;
    public XRLabel dPiezasCambio;
    private XRLabel xrLabel11;
    private ReportFooterBand ReportFooter;
    public XRLabel total;
    private XRLabel xrLabel16;
    public XRLabel detImporte;
    public XRLabel dPiezasPromocion;
    public XRLabel totalPiezasPromocion;
    public XRLabel totalPiezasCambio;
    public XRLabel totalPiezas;
    private XRLine xrLine3;
    private XRLine xrLine4;
    private ReportHeaderBand ReportHeader;
    public XRLabel TiempoTransito;
    public XRLabel HoraInicial;
    public XRLabel TiempoVisita;
    public XRLabel HoraFin;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel4;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public AutoVentaResumen()
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
            this.TiempoTransito = new DevExpress.XtraReports.UI.XRLabel();
            this.HoraInicial = new DevExpress.XtraReports.UI.XRLabel();
            this.TiempoVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.detImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.dFechaEntrega = new DevExpress.XtraReports.UI.XRLabel();
            this.dFolio = new DevExpress.XtraReports.UI.XRLabel();
            this.HoraFin = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.totalPiezasPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.totalPiezasCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.totalPiezas = new DevExpress.XtraReports.UI.XRLabel();
            this.total = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TiempoTransito,
            this.HoraInicial,
            this.TiempoVisita,
            this.detImporte,
            this.dPiezasPromocion,
            this.dPiezasVenta,
            this.dPiezasCambio,
            this.dFechaEntrega,
            this.dFolio,
            this.HoraFin});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 26.30933F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TiempoTransito
            // 
            this.TiempoTransito.Dpi = 100F;
            this.TiempoTransito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiempoTransito.LocationFloat = new DevExpress.Utils.PointFloat(291.1058F, 2.562841F);
            this.TiempoTransito.Name = "TiempoTransito";
            this.TiempoTransito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TiempoTransito.SizeF = new System.Drawing.SizeF(99.24283F, 23F);
            this.TiempoTransito.StylePriority.UseFont = false;
            this.TiempoTransito.StylePriority.UseTextAlignment = false;
            this.TiempoTransito.Text = "Tiempo Transito";
            this.TiempoTransito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // HoraInicial
            // 
            this.HoraInicial.Dpi = 100F;
            this.HoraInicial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraInicial.LocationFloat = new DevExpress.Utils.PointFloat(390.3486F, 2.561796F);
            this.HoraInicial.Name = "HoraInicial";
            this.HoraInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HoraInicial.SizeF = new System.Drawing.SizeF(84.48346F, 23F);
            this.HoraInicial.StylePriority.UseFont = false;
            this.HoraInicial.StylePriority.UseTextAlignment = false;
            this.HoraInicial.Text = "Hora Incial";
            this.HoraInicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TiempoVisita
            // 
            this.TiempoVisita.Dpi = 100F;
            this.TiempoVisita.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiempoVisita.LocationFloat = new DevExpress.Utils.PointFloat(560.7924F, 2.562841F);
            this.TiempoVisita.Name = "TiempoVisita";
            this.TiempoVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TiempoVisita.SizeF = new System.Drawing.SizeF(85.96045F, 23F);
            this.TiempoVisita.StylePriority.UseFont = false;
            this.TiempoVisita.StylePriority.UseTextAlignment = false;
            this.TiempoVisita.Text = "Tiempo Visita";
            this.TiempoVisita.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // detImporte
            // 
            this.detImporte.Dpi = 100F;
            this.detImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detImporte.LocationFloat = new DevExpress.Utils.PointFloat(942.87F, 2.561813F);
            this.detImporte.Multiline = true;
            this.detImporte.Name = "detImporte";
            this.detImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detImporte.SizeF = new System.Drawing.SizeF(120.1495F, 23.00015F);
            this.detImporte.StylePriority.UseFont = false;
            this.detImporte.StylePriority.UseTextAlignment = false;
            this.detImporte.Text = "Importe (Venta)";
            this.detImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dPiezasPromocion
            // 
            this.dPiezasPromocion.Dpi = 100F;
            this.dPiezasPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasPromocion.LocationFloat = new DevExpress.Utils.PointFloat(829.3248F, 2.562691F);
            this.dPiezasPromocion.Multiline = true;
            this.dPiezasPromocion.Name = "dPiezasPromocion";
            this.dPiezasPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasPromocion.SizeF = new System.Drawing.SizeF(113.5452F, 23.00015F);
            this.dPiezasPromocion.StylePriority.UseFont = false;
            this.dPiezasPromocion.StylePriority.UseTextAlignment = false;
            this.dPiezasPromocion.Text = "Piezas (Promoción)";
            this.dPiezasPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dPiezasVenta
            // 
            this.dPiezasVenta.Dpi = 100F;
            this.dPiezasVenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasVenta.LocationFloat = new DevExpress.Utils.PointFloat(647.0005F, 2.561807F);
            this.dPiezasVenta.Multiline = true;
            this.dPiezasVenta.Name = "dPiezasVenta";
            this.dPiezasVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasVenta.SizeF = new System.Drawing.SizeF(89.42969F, 23.00003F);
            this.dPiezasVenta.StylePriority.UseFont = false;
            this.dPiezasVenta.StylePriority.UseTextAlignment = false;
            this.dPiezasVenta.Text = "Piezas (Venta)";
            this.dPiezasVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dPiezasCambio
            // 
            this.dPiezasCambio.Dpi = 100F;
            this.dPiezasCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasCambio.LocationFloat = new DevExpress.Utils.PointFloat(736.6248F, 2.561823F);
            this.dPiezasCambio.Multiline = true;
            this.dPiezasCambio.Name = "dPiezasCambio";
            this.dPiezasCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasCambio.SizeF = new System.Drawing.SizeF(92.50555F, 23.00015F);
            this.dPiezasCambio.StylePriority.UseFont = false;
            this.dPiezasCambio.StylePriority.UseTextAlignment = false;
            this.dPiezasCambio.Text = "Piezas (Cambio)";
            this.dPiezasCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dFechaEntrega
            // 
            this.dFechaEntrega.Dpi = 100F;
            this.dFechaEntrega.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFechaEntrega.LocationFloat = new DevExpress.Utils.PointFloat(191.863F, 2.562841F);
            this.dFechaEntrega.Name = "dFechaEntrega";
            this.dFechaEntrega.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dFechaEntrega.SizeF = new System.Drawing.SizeF(99.24283F, 23F);
            this.dFechaEntrega.StylePriority.UseFont = false;
            this.dFechaEntrega.Text = "Fecha de entrega";
            // 
            // dFolio
            // 
            this.dFolio.Dpi = 100F;
            this.dFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFolio.LocationFloat = new DevExpress.Utils.PointFloat(2.752007F, 2.562014F);
            this.dFolio.Multiline = true;
            this.dFolio.Name = "dFolio";
            this.dFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dFolio.SizeF = new System.Drawing.SizeF(189.111F, 22.99996F);
            this.dFolio.StylePriority.UseFont = false;
            this.dFolio.StylePriority.UseTextAlignment = false;
            this.dFolio.Text = "Folio";
            this.dFolio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // HoraFin
            // 
            this.HoraFin.Dpi = 100F;
            this.HoraFin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraFin.LocationFloat = new DevExpress.Utils.PointFloat(474.832F, 2.561796F);
            this.HoraFin.Name = "HoraFin";
            this.HoraFin.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HoraFin.SizeF = new System.Drawing.SizeF(85.77002F, 23F);
            this.HoraFin.StylePriority.UseFont = false;
            this.HoraFin.StylePriority.UseTextAlignment = false;
            this.HoraFin.Text = "Hora Fin";
            this.HoraFin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(942.3701F, 70.95804F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(120.6302F, 23.00012F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Importe (Venta)";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(829.3248F, 70.95804F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(113.0452F, 23.00018F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Piezas (Promoción)";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(736.2774F, 70.95951F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(92.85297F, 23.00017F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Piezas (Cambio)";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 47.95834F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1072F, 22.99998F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 93.95951F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1072.5F, 2F);
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(1.724836F, 70.95834F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(190.1382F, 22.9999F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Folio";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(191.863F, 70.95786F);
            this.xrLabel34.Multiline = true;
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(99.14755F, 22.99999F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "Fecha de entrega\r\n";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(647.0005F, 70.95786F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(89.27686F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Piezas (Venta)";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.999996F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(403.07F, 21.95834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "II - VENTA POR CLIENTES";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 1.243024F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.ReportFooter.HeightF = 42.75809F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(441.6524F, 33.00011F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(604.7899F, 8.11903F);
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(441.9337F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(604.5087F, 8.119029F);
            // 
            // totalPiezasPromocion
            // 
            this.totalPiezasPromocion.Dpi = 100F;
            this.totalPiezasPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezasPromocion.LocationFloat = new DevExpress.Utils.PointFloat(828.8246F, 9.757932F);
            this.totalPiezasPromocion.Multiline = true;
            this.totalPiezasPromocion.Name = "totalPiezasPromocion";
            this.totalPiezasPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezasPromocion.SizeF = new System.Drawing.SizeF(113.5453F, 23.00015F);
            this.totalPiezasPromocion.StylePriority.UseFont = false;
            this.totalPiezasPromocion.StylePriority.UseTextAlignment = false;
            this.totalPiezasPromocion.Text = "Piezas (Promoción)";
            this.totalPiezasPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // totalPiezasCambio
            // 
            this.totalPiezasCambio.Dpi = 100F;
            this.totalPiezasCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezasCambio.LocationFloat = new DevExpress.Utils.PointFloat(735.7773F, 10.00013F);
            this.totalPiezasCambio.Multiline = true;
            this.totalPiezasCambio.Name = "totalPiezasCambio";
            this.totalPiezasCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezasCambio.SizeF = new System.Drawing.SizeF(93.0473F, 23.00015F);
            this.totalPiezasCambio.StylePriority.UseFont = false;
            this.totalPiezasCambio.StylePriority.UseTextAlignment = false;
            this.totalPiezasCambio.Text = "Piezas (Cambio)";
            this.totalPiezasCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // totalPiezas
            // 
            this.totalPiezas.Dpi = 100F;
            this.totalPiezas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezas.LocationFloat = new DevExpress.Utils.PointFloat(646.5004F, 10.00026F);
            this.totalPiezas.Multiline = true;
            this.totalPiezas.Name = "totalPiezas";
            this.totalPiezas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezas.SizeF = new System.Drawing.SizeF(89.27679F, 23.00003F);
            this.totalPiezas.StylePriority.UseFont = false;
            this.totalPiezas.StylePriority.UseTextAlignment = false;
            this.totalPiezas.Text = "Piezas (Venta)";
            this.totalPiezas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // total
            // 
            this.total.Dpi = 100F;
            this.total.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.LocationFloat = new DevExpress.Utils.PointFloat(942.8701F, 10.00001F);
            this.total.Multiline = true;
            this.total.Name = "total";
            this.total.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.total.SizeF = new System.Drawing.SizeF(120.1495F, 23.00012F);
            this.total.StylePriority.UseFont = false;
            this.total.StylePriority.UseTextAlignment = false;
            this.total.Text = "Total";
            this.total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(496.957F, 10.00026F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(149.5433F, 23.00003F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "GRAN TOTAL DE VENTAS";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel4,
            this.xrLabel1,
            this.xrLabel11,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLine1,
            this.xrLine2,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel3});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 96.52818F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(560.7923F, 70.95788F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(86.05557F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Tiempo Visita";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(474.7367F, 70.95951F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(86.05557F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Hora Fin";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(388.6812F, 70.95788F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(86.05557F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Hora Inicial";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(291.0106F, 70.95786F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(97.57532F, 22.99999F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Tiempo Transito";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // AutoVentaResumen
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 0, 1);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
