using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class ResumenPorCodigo : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLine xrLine1;
    private XRLine xrLine2;
    protected XRLabel xrLabel8;
    protected XRLabel xrLabel3;
    protected XRLabel xrLabel6;
    protected XRLabel xrLabel5;
    public XRLabel dDescripcion;
    public XRLabel dPiezasVenta;
    public XRLabel dPiezasCambio;
    protected XRLabel xrLabel11;
    private ReportFooterBand ReportFooter;
    public XRLabel total;
    private XRLabel xrLabel16;
    public XRLabel detImporte;
    public XRLabel dPiezasPromocion;
    public XRLabel dCodigo;
    protected XRLabel xrLabel36;
    public XRLabel totalPiezasPromocion;
    public XRLabel totalPiezasCambio;
    public XRLabel totalPiezas;
    protected XRLabel xrLabel7;
    protected XRLabel xrLabel4;
    protected XRLabel xrLabel2;
    public XRLabel Cobertura;
    public XRLabel detClienteConcompraEfectiva;
    public XRLabel detClienteConcompra;
    private XRLine xrLine4;
    private XRLine xrLine3;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ResumenPorCodigo()
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
            this.Cobertura = new DevExpress.XtraReports.UI.XRLabel();
            this.detClienteConcompraEfectiva = new DevExpress.XtraReports.UI.XRLabel();
            this.detClienteConcompra = new DevExpress.XtraReports.UI.XRLabel();
            this.detImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.dDescripcion = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezasCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.dCodigo = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Cobertura,
            this.detClienteConcompraEfectiva,
            this.detClienteConcompra,
            this.detImporte,
            this.dPiezasPromocion,
            this.dDescripcion,
            this.dPiezasVenta,
            this.dPiezasCambio,
            this.dCodigo});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 37.5935F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Cobertura
            // 
            this.Cobertura.Dpi = 100F;
            this.Cobertura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cobertura.LocationFloat = new DevExpress.Utils.PointFloat(976.545F, 4.592291F);
            this.Cobertura.Multiline = true;
            this.Cobertura.Name = "Cobertura";
            this.Cobertura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Cobertura.SizeF = new System.Drawing.SizeF(93.45502F, 23.00015F);
            this.Cobertura.StylePriority.UseFont = false;
            this.Cobertura.StylePriority.UseTextAlignment = false;
            this.Cobertura.Text = "Cobertura";
            this.Cobertura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // detClienteConcompraEfectiva
            // 
            this.detClienteConcompraEfectiva.Dpi = 100F;
            this.detClienteConcompraEfectiva.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detClienteConcompraEfectiva.LocationFloat = new DevExpress.Utils.PointFloat(873.1557F, 4.592284F);
            this.detClienteConcompraEfectiva.Multiline = true;
            this.detClienteConcompraEfectiva.Name = "detClienteConcompraEfectiva";
            this.detClienteConcompraEfectiva.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detClienteConcompraEfectiva.SizeF = new System.Drawing.SizeF(102.8264F, 23.00015F);
            this.detClienteConcompraEfectiva.StylePriority.UseFont = false;
            this.detClienteConcompraEfectiva.StylePriority.UseTextAlignment = false;
            this.detClienteConcompraEfectiva.Text = "Clientes con compra Efectiva";
            this.detClienteConcompraEfectiva.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // detClienteConcompra
            // 
            this.detClienteConcompra.Dpi = 100F;
            this.detClienteConcompra.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detClienteConcompra.LocationFloat = new DevExpress.Utils.PointFloat(783.1852F, 4.592284F);
            this.detClienteConcompra.Multiline = true;
            this.detClienteConcompra.Name = "detClienteConcompra";
            this.detClienteConcompra.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detClienteConcompra.SizeF = new System.Drawing.SizeF(89.20453F, 23.00015F);
            this.detClienteConcompra.StylePriority.UseFont = false;
            this.detClienteConcompra.StylePriority.UseTextAlignment = false;
            this.detClienteConcompra.Text = "Clientes con compra";
            this.detClienteConcompra.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // detImporte
            // 
            this.detImporte.Dpi = 100F;
            this.detImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detImporte.LocationFloat = new DevExpress.Utils.PointFloat(691.4623F, 4.592259F);
            this.detImporte.Multiline = true;
            this.detImporte.Name = "detImporte";
            this.detImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detImporte.SizeF = new System.Drawing.SizeF(91.72272F, 23.00015F);
            this.detImporte.StylePriority.UseFont = false;
            this.detImporte.StylePriority.UseTextAlignment = false;
            this.detImporte.Text = "Importe (Venta)";
            this.detImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dPiezasPromocion
            // 
            this.dPiezasPromocion.Dpi = 100F;
            this.dPiezasPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasPromocion.LocationFloat = new DevExpress.Utils.PointFloat(573.2282F, 4.592259F);
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
            this.dDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(121.3613F, 4.592504F);
            this.dDescripcion.Multiline = true;
            this.dDescripcion.Name = "dDescripcion";
            this.dDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dDescripcion.SizeF = new System.Drawing.SizeF(266.2686F, 22.99991F);
            this.dDescripcion.StylePriority.UseFont = false;
            this.dDescripcion.StylePriority.UseTextAlignment = false;
            this.dDescripcion.Text = "Descripción";
            this.dDescripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dPiezasVenta
            // 
            this.dPiezasVenta.Dpi = 100F;
            this.dPiezasVenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasVenta.LocationFloat = new DevExpress.Utils.PointFloat(387.6715F, 4.592259F);
            this.dPiezasVenta.Multiline = true;
            this.dPiezasVenta.Name = "dPiezasVenta";
            this.dPiezasVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasVenta.SizeF = new System.Drawing.SizeF(87.82156F, 23.00003F);
            this.dPiezasVenta.StylePriority.UseFont = false;
            this.dPiezasVenta.StylePriority.UseTextAlignment = false;
            this.dPiezasVenta.Text = "Piezas (Venta)";
            this.dPiezasVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dPiezasCambio
            // 
            this.dPiezasCambio.Dpi = 100F;
            this.dPiezasCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezasCambio.LocationFloat = new DevExpress.Utils.PointFloat(475.5882F, 4.592259F);
            this.dPiezasCambio.Multiline = true;
            this.dPiezasCambio.Name = "dPiezasCambio";
            this.dPiezasCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezasCambio.SizeF = new System.Drawing.SizeF(96.95364F, 23.00015F);
            this.dPiezasCambio.StylePriority.UseFont = false;
            this.dPiezasCambio.StylePriority.UseTextAlignment = false;
            this.dPiezasCambio.Text = "Piezas (Cambio)";
            this.dPiezasCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dCodigo
            // 
            this.dCodigo.Dpi = 100F;
            this.dCodigo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dCodigo.LocationFloat = new DevExpress.Utils.PointFloat(9.999984F, 4.593507F);
            this.dCodigo.Name = "dCodigo";
            this.dCodigo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dCodigo.SizeF = new System.Drawing.SizeF(111.3612F, 23F);
            this.dCodigo.StylePriority.UseFont = false;
            this.dCodigo.Text = "Código";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 15F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(976.0657F, 48.11472F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(93.83917F, 34.45389F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "%Cobertura";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(873.0609F, 48.11456F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(102.9217F, 34.45406F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Clientes con compra Efectiva";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(783.1852F, 48.11306F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(89.2998F, 34.45554F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Clientes con compra";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(691.4813F, 48.11306F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(91.70367F, 34.45554F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Importe (Venta)";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(573.1138F, 48.11306F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(118.2728F, 34.45555F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Piezas (Promoción)";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(475.5883F, 48.11308F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(97.04886F, 34.45702F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Piezas (Cambio)";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 39.24998F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1069.917F, 8.863075F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 82.57175F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1059.917F, 8.459412F);
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(10.28606F, 48.1134F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(111.0751F, 34.45834F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "Código";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(121.6234F, 48.11472F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(266.0065F, 34.45702F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Descripción";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(388.2249F, 48.11472F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(86.93506F, 34.45702F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Piezas (Venta)";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 10F;
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
            this.ReportFooter.HeightF = 46.15387F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(199.3608F, 33.75015F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(860.5562F, 7.62817F);
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(199.3801F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(860.5369F, 7.62817F);
            // 
            // totalPiezasPromocion
            // 
            this.totalPiezasPromocion.Dpi = 100F;
            this.totalPiezasPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezasPromocion.LocationFloat = new DevExpress.Utils.PointFloat(573.4759F, 10.00002F);
            this.totalPiezasPromocion.Multiline = true;
            this.totalPiezasPromocion.Name = "totalPiezasPromocion";
            this.totalPiezasPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezasPromocion.SizeF = new System.Drawing.SizeF(118.0056F, 23.00015F);
            this.totalPiezasPromocion.StylePriority.UseFont = false;
            this.totalPiezasPromocion.StylePriority.UseTextAlignment = false;
            this.totalPiezasPromocion.Text = "Piezas (Promoción)";
            this.totalPiezasPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // totalPiezasCambio
            // 
            this.totalPiezasCambio.Dpi = 100F;
            this.totalPiezasCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezasCambio.LocationFloat = new DevExpress.Utils.PointFloat(475.989F, 10.00002F);
            this.totalPiezasCambio.Multiline = true;
            this.totalPiezasCambio.Name = "totalPiezasCambio";
            this.totalPiezasCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezasCambio.SizeF = new System.Drawing.SizeF(96.6481F, 23.00015F);
            this.totalPiezasCambio.StylePriority.UseFont = false;
            this.totalPiezasCambio.StylePriority.UseTextAlignment = false;
            this.totalPiezasCambio.Text = "Piezas (Cambio)";
            this.totalPiezasCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // totalPiezas
            // 
            this.totalPiezas.Dpi = 100F;
            this.totalPiezas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPiezas.LocationFloat = new DevExpress.Utils.PointFloat(388.2249F, 9.999943F);
            this.totalPiezas.Multiline = true;
            this.totalPiezas.Name = "totalPiezas";
            this.totalPiezas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPiezas.SizeF = new System.Drawing.SizeF(87.26807F, 23.00003F);
            this.totalPiezas.StylePriority.UseFont = false;
            this.totalPiezas.StylePriority.UseTextAlignment = false;
            this.totalPiezas.Text = "Piezas (Venta)";
            this.totalPiezas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // total
            // 
            this.total.Dpi = 100F;
            this.total.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.LocationFloat = new DevExpress.Utils.PointFloat(691.5765F, 10.00004F);
            this.total.Multiline = true;
            this.total.Name = "total";
            this.total.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.total.SizeF = new System.Drawing.SizeF(91.8725F, 23.00012F);
            this.total.StylePriority.UseFont = false;
            this.total.StylePriority.UseTextAlignment = false;
            this.total.Text = "Total";
            this.total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(238.3598F, 10.00001F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(149.3652F, 23.00003F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "GRAN TOTAL DE VENTAS";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel11,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLine1,
            this.xrLine2,
            this.xrLabel36,
            this.xrLabel8,
            this.xrLabel3,
            this.xrLabel7});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 93.35199F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999984F, 9.999996F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(324.9449F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "III - RESUMEN POR CÓDIGO";
            // 
            // ResumenPorCodigo
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(15, 15, 15, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
