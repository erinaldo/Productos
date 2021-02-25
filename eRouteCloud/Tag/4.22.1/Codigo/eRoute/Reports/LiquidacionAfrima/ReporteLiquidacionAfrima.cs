using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class ReporteLiquidacionAfrima : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private PageHeaderBand PageHeader;
    public XRLabel HeaderVendedor;
    private XRLabel xrLabel24;
    public XRPictureBox xrPictureBox1;
    private XRLabel xrLabel20;
    public XRLabel xrLabel27;
    public XRLabel HeaderFecha;
    public XRLabel HeaderDireccion;
    private XRLabel xrLabel1;
    public XRLabel HeaderTelefono;
    private XRLabel xrLabel3;
    private GroupHeaderBand GroupHeader1;
    private ReportFooterBand ReportFooter;
    public XRLabel PTotal;
    public XRLabel PSimbolo;
    private XRLabel xrLabel2;
    public XRLabel SubProducto;
    private GroupHeaderBand GroupHeader2;
    private XRLabel xrLabel4;
    public XRLabel CoSimbolo;
    public XRLabel CoTotal;
    public XRLabel CrTotal;
    public XRLabel CrSimbolo;
    private XRLabel xrLabel7;
    private GroupHeaderBand GroupHeader3;
    public XRSubreport xrSubreportProducto;
    private GroupHeaderBand GroupHeader4;
    private GroupHeaderBand GroupHeader5;
    private XRLabel xrLabel5;
    public XRLabel CobSimbolo;
    public XRLabel CobTotal;
    private XRLabel xrLabel8;
    public XRLabel LiqSimbolo;
    public XRLabel LiqTotal;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    public XRSubreport xrSubreportCobranza;
    public XRSubreport xrSubreportCredito;
    public XRSubreport xrSubreportContado;
    private XRLabel xrLabel14;
    public XRLabel PPSimbolo;
    public XRLabel PPTotal;
    public XRLabel ConnTotal;
    public XRLabel ConnSimbolo;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    public XRLabel CreeSimbolo;
    public XRLabel CreeTotal;
    public XRLabel CobbTotal;
    public XRLabel CobbSimbolo;
    private XRLabel xrLabel29;
    public XRLabel LiqqTotal;
    public XRLabel LiqqSimbolo;
    private XRLabel xrLabel32;
    private XRLabel xrLabel13;
    private XRLabel xrLabel10;
    public XRSubreport xrSubreportBilletes;
    public XRSubreport xrSubreportMonedas;
    public XRLabel xrLabel6;
    private XRLabel xrLabel9;
    private FormattingRule formattingRule1;
    private FormattingRule formattingRule2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteLiquidacionAfrima()
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
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.HeaderVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.HeaderFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.HeaderDireccion = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.HeaderTelefono = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrSubreportCobranza = new DevExpress.XtraReports.UI.XRSubreport();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.LiqSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.LiqTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.CobSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.CobTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.CrTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.CrSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.CoSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.CoTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.PTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.PSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.SubProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrSubreportCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrSubreportContado = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrSubreportProducto = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreportBilletes = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrSubreportMonedas = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.PPSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.PPTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.ConnTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.ConnSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.CreeSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.CreeTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.CobbTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.CobbSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.LiqqTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.LiqqSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule2 = new DevExpress.XtraReports.UI.FormattingRule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
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
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 47.91667F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(80F, 15F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(300F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(660F, 15F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(300F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.HeaderVendedor,
            this.xrLabel24,
            this.xrPictureBox1,
            this.xrLabel20,
            this.xrLabel27,
            this.HeaderFecha,
            this.HeaderDireccion,
            this.xrLabel1,
            this.HeaderTelefono,
            this.xrLabel3});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 147.3333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // HeaderVendedor
            // 
            this.HeaderVendedor.Dpi = 100F;
            this.HeaderVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderVendedor.KeepTogether = true;
            this.HeaderVendedor.LocationFloat = new DevExpress.Utils.PointFloat(80F, 123F);
            this.HeaderVendedor.Name = "HeaderVendedor";
            this.HeaderVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderVendedor.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.HeaderVendedor.SizeF = new System.Drawing.SizeF(650F, 16F);
            this.HeaderVendedor.StylePriority.UseFont = false;
            this.HeaderVendedor.WordWrap = false;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.KeepTogether = true;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 123F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel24.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor:";
            this.xrLabel24.WordWrap = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(150F, 95F);
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.KeepTogether = true;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 106F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel20.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Fecha:";
            this.xrLabel20.WordWrap = false;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.KeepTogether = true;
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(370F, 16F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel27.SizeF = new System.Drawing.SizeF(360F, 25F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Reporte de Liquidación (AFR)";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel27.WordWrap = false;
            // 
            // HeaderFecha
            // 
            this.HeaderFecha.Dpi = 100F;
            this.HeaderFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderFecha.KeepTogether = true;
            this.HeaderFecha.LocationFloat = new DevExpress.Utils.PointFloat(80F, 106F);
            this.HeaderFecha.Name = "HeaderFecha";
            this.HeaderFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderFecha.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.HeaderFecha.SizeF = new System.Drawing.SizeF(650F, 16F);
            this.HeaderFecha.StylePriority.UseFont = false;
            this.HeaderFecha.WordWrap = false;
            // 
            // HeaderDireccion
            // 
            this.HeaderDireccion.Dpi = 100F;
            this.HeaderDireccion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderDireccion.KeepTogether = true;
            this.HeaderDireccion.LocationFloat = new DevExpress.Utils.PointFloat(520F, 56F);
            this.HeaderDireccion.Name = "HeaderDireccion";
            this.HeaderDireccion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderDireccion.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.HeaderDireccion.SizeF = new System.Drawing.SizeF(540F, 16F);
            this.HeaderDireccion.StylePriority.UseFont = false;
            this.HeaderDireccion.WordWrap = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.KeepTogether = true;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(445F, 56F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Dieccion:";
            this.xrLabel1.WordWrap = false;
            // 
            // HeaderTelefono
            // 
            this.HeaderTelefono.Dpi = 100F;
            this.HeaderTelefono.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderTelefono.KeepTogether = true;
            this.HeaderTelefono.LocationFloat = new DevExpress.Utils.PointFloat(520F, 73F);
            this.HeaderTelefono.Name = "HeaderTelefono";
            this.HeaderTelefono.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderTelefono.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.HeaderTelefono.SizeF = new System.Drawing.SizeF(400F, 16F);
            this.HeaderTelefono.StylePriority.UseFont = false;
            this.HeaderTelefono.WordWrap = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.KeepTogether = true;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(445F, 73F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Telefono:";
            this.xrLabel3.WordWrap = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportCobranza});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 40.04166F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // xrSubreportCobranza
            // 
            this.xrSubreportCobranza.CanShrink = true;
            this.xrSubreportCobranza.Dpi = 100F;
            this.xrSubreportCobranza.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 0F);
            this.xrSubreportCobranza.Name = "xrSubreportCobranza";
            this.xrSubreportCobranza.SizeF = new System.Drawing.SizeF(1070F, 40.04F);
            this.xrSubreportCobranza.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel8,
            this.LiqSimbolo,
            this.LiqTotal,
            this.xrLabel5,
            this.CobSimbolo,
            this.CobTotal,
            this.CrTotal,
            this.CrSimbolo,
            this.xrLabel7,
            this.xrLabel4,
            this.CoSimbolo,
            this.CoTotal,
            this.PTotal,
            this.PSimbolo,
            this.xrLabel2,
            this.SubProducto});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 323.9584F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(595F, 213.54F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(250F, 98.29166F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Recibe\r\n\r\n\r\n\r\n______________________________________\r\nNombe y Firma";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(270F, 213.54F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(250F, 98.29166F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Liquida\r\n\r\n\r\n\r\n______________________________________\r\nNombe y Firma";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 138F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(270F, 16F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Total a Liquidar";
            // 
            // LiqSimbolo
            // 
            this.LiqSimbolo.Dpi = 100F;
            this.LiqSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(270F, 138F);
            this.LiqSimbolo.Name = "LiqSimbolo";
            this.LiqSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqSimbolo.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.LiqSimbolo.StylePriority.UseFont = false;
            this.LiqSimbolo.StylePriority.UseTextAlignment = false;
            this.LiqSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // LiqTotal
            // 
            this.LiqTotal.Dpi = 100F;
            this.LiqTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqTotal.LocationFloat = new DevExpress.Utils.PointFloat(370F, 138F);
            this.LiqTotal.Name = "LiqTotal";
            this.LiqTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqTotal.SizeF = new System.Drawing.SizeF(105F, 16F);
            this.LiqTotal.StylePriority.UseFont = false;
            this.LiqTotal.StylePriority.UseTextAlignment = false;
            this.LiqTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(270F, 16F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Total de Cobranza";
            // 
            // CobSimbolo
            // 
            this.CobSimbolo.Dpi = 100F;
            this.CobSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CobSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(270F, 116F);
            this.CobSimbolo.Name = "CobSimbolo";
            this.CobSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CobSimbolo.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.CobSimbolo.StylePriority.UseFont = false;
            this.CobSimbolo.StylePriority.UseTextAlignment = false;
            this.CobSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CobTotal
            // 
            this.CobTotal.Dpi = 100F;
            this.CobTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CobTotal.LocationFloat = new DevExpress.Utils.PointFloat(370F, 116F);
            this.CobTotal.Name = "CobTotal";
            this.CobTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CobTotal.SizeF = new System.Drawing.SizeF(105F, 16F);
            this.CobTotal.StylePriority.UseFont = false;
            this.CobTotal.StylePriority.UseTextAlignment = false;
            this.CobTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CrTotal
            // 
            this.CrTotal.Dpi = 100F;
            this.CrTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrTotal.LocationFloat = new DevExpress.Utils.PointFloat(370F, 93.99999F);
            this.CrTotal.Name = "CrTotal";
            this.CrTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrTotal.SizeF = new System.Drawing.SizeF(105F, 16F);
            this.CrTotal.StylePriority.UseFont = false;
            this.CrTotal.StylePriority.UseTextAlignment = false;
            this.CrTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CrSimbolo
            // 
            this.CrSimbolo.Dpi = 100F;
            this.CrSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(270F, 94F);
            this.CrSimbolo.Name = "CrSimbolo";
            this.CrSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrSimbolo.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.CrSimbolo.StylePriority.UseFont = false;
            this.CrSimbolo.StylePriority.UseTextAlignment = false;
            this.CrSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 94F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(270F, 16F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Total de Ventas de Credito";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(270F, 16F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Total de Ventas de Contado";
            // 
            // CoSimbolo
            // 
            this.CoSimbolo.Dpi = 100F;
            this.CoSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(270F, 72F);
            this.CoSimbolo.Name = "CoSimbolo";
            this.CoSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CoSimbolo.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.CoSimbolo.StylePriority.UseFont = false;
            this.CoSimbolo.StylePriority.UseTextAlignment = false;
            this.CoSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CoTotal
            // 
            this.CoTotal.Dpi = 100F;
            this.CoTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoTotal.LocationFloat = new DevExpress.Utils.PointFloat(370F, 72F);
            this.CoTotal.Name = "CoTotal";
            this.CoTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CoTotal.SizeF = new System.Drawing.SizeF(105F, 16F);
            this.CoTotal.StylePriority.UseFont = false;
            this.CoTotal.StylePriority.UseTextAlignment = false;
            this.CoTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PTotal
            // 
            this.PTotal.Dpi = 100F;
            this.PTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PTotal.LocationFloat = new DevExpress.Utils.PointFloat(370F, 50F);
            this.PTotal.Name = "PTotal";
            this.PTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PTotal.SizeF = new System.Drawing.SizeF(105F, 16F);
            this.PTotal.StylePriority.UseFont = false;
            this.PTotal.StylePriority.UseTextAlignment = false;
            this.PTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PSimbolo
            // 
            this.PSimbolo.Dpi = 100F;
            this.PSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(270F, 50F);
            this.PSimbolo.Name = "PSimbolo";
            this.PSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PSimbolo.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.PSimbolo.StylePriority.UseFont = false;
            this.PSimbolo.StylePriority.UseTextAlignment = false;
            this.PSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(270F, 16F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Total de Ventas de Productos";
            // 
            // SubProducto
            // 
            this.SubProducto.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SubProducto.Dpi = 100F;
            this.SubProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.SubProducto.Name = "SubProducto";
            this.SubProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SubProducto.SizeF = new System.Drawing.SizeF(1072F, 16F);
            this.SubProducto.StylePriority.UseBorders = false;
            this.SubProducto.StylePriority.UseFont = false;
            this.SubProducto.Text = "LIQUIDACION";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportCredito});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 55.04166F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrSubreportCredito
            // 
            this.xrSubreportCredito.CanShrink = true;
            this.xrSubreportCredito.Dpi = 100F;
            this.xrSubreportCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreportCredito.Name = "xrSubreportCredito";
            this.xrSubreportCredito.SizeF = new System.Drawing.SizeF(1070F, 40.04F);
            this.xrSubreportCredito.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportContado});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 55.04166F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // xrSubreportContado
            // 
            this.xrSubreportContado.CanShrink = true;
            this.xrSubreportContado.Dpi = 100F;
            this.xrSubreportContado.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 0F);
            this.xrSubreportContado.Name = "xrSubreportContado";
            this.xrSubreportContado.SizeF = new System.Drawing.SizeF(1070F, 40.04F);
            this.xrSubreportContado.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // xrSubreportProducto
            // 
            this.xrSubreportProducto.CanShrink = true;
            this.xrSubreportProducto.Dpi = 100F;
            this.xrSubreportProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreportProducto.Name = "xrSubreportProducto";
            this.xrSubreportProducto.SizeF = new System.Drawing.SizeF(1070F, 40.04F);
            this.xrSubreportProducto.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabel10,
            this.xrSubreportBilletes,
            this.xrSubreportMonedas,
            this.xrLabel6,
            this.xrLabel9});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 132.0801F;
            this.GroupHeader4.KeepTogether = true;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            this.GroupHeader4.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15.99998F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(1070.708F, 16F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "EFECTIVO";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(520F, 32F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(230F, 98.29F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Liquida\r\n\r\n\r\n\r\n___________________________________\r\nNombe y Firma";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrSubreportBilletes
            // 
            this.xrSubreportBilletes.CanShrink = true;
            this.xrSubreportBilletes.Dpi = 100F;
            this.xrSubreportBilletes.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.21148F);
            this.xrSubreportBilletes.Name = "xrSubreportBilletes";
            this.xrSubreportBilletes.SizeF = new System.Drawing.SizeF(270F, 40.04F);
            this.xrSubreportBilletes.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // xrSubreportMonedas
            // 
            this.xrSubreportMonedas.CanShrink = true;
            this.xrSubreportMonedas.Dpi = 100F;
            this.xrSubreportMonedas.LocationFloat = new DevExpress.Utils.PointFloat(270F, 31.21F);
            this.xrSubreportMonedas.Name = "xrSubreportMonedas";
            this.xrSubreportMonedas.SizeF = new System.Drawing.SizeF(250F, 40.04F);
            this.xrSubreportMonedas.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.KeepTogether = true;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(200F, 16F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "DESGLOSE";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(760F, 31.99998F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(230F, 98.29F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Recibe\r\n\r\n\r\n\r\n___________________________________\r\nNombe y Firma";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel14,
            this.PPSimbolo,
            this.PPTotal,
            this.ConnTotal,
            this.ConnSimbolo,
            this.xrLabel21,
            this.xrLabel22,
            this.CreeSimbolo,
            this.CreeTotal,
            this.CobbTotal,
            this.CobbSimbolo,
            this.xrLabel29,
            this.LiqqTotal,
            this.LiqqSimbolo,
            this.xrLabel32,
            this.xrSubreportProducto});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 126.3333F;
            this.GroupHeader5.Level = 4;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(760F, 46.33F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel14.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Total de Ventas de Productos";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel14.WordWrap = false;
            // 
            // PPSimbolo
            // 
            this.PPSimbolo.Dpi = 100F;
            this.PPSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(965F, 46.33F);
            this.PPSimbolo.Name = "PPSimbolo";
            this.PPSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PPSimbolo.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.PPSimbolo.SizeF = new System.Drawing.SizeF(26F, 16F);
            this.PPSimbolo.StylePriority.UseFont = false;
            this.PPSimbolo.StylePriority.UseTextAlignment = false;
            this.PPSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.PPSimbolo.WordWrap = false;
            // 
            // PPTotal
            // 
            this.PPTotal.Dpi = 100F;
            this.PPTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPTotal.LocationFloat = new DevExpress.Utils.PointFloat(991.46F, 46.33F);
            this.PPTotal.Name = "PPTotal";
            this.PPTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PPTotal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.PPTotal.SizeF = new System.Drawing.SizeF(80.54F, 16F);
            this.PPTotal.StylePriority.UseFont = false;
            this.PPTotal.StylePriority.UseTextAlignment = false;
            this.PPTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.PPTotal.WordWrap = false;
            // 
            // ConnTotal
            // 
            this.ConnTotal.Dpi = 100F;
            this.ConnTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnTotal.LocationFloat = new DevExpress.Utils.PointFloat(991.46F, 62.33F);
            this.ConnTotal.Name = "ConnTotal";
            this.ConnTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConnTotal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.ConnTotal.SizeF = new System.Drawing.SizeF(80.54F, 16F);
            this.ConnTotal.StylePriority.UseFont = false;
            this.ConnTotal.StylePriority.UseTextAlignment = false;
            this.ConnTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.ConnTotal.WordWrap = false;
            // 
            // ConnSimbolo
            // 
            this.ConnSimbolo.Dpi = 100F;
            this.ConnSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(965F, 62.33F);
            this.ConnSimbolo.Name = "ConnSimbolo";
            this.ConnSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConnSimbolo.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.ConnSimbolo.SizeF = new System.Drawing.SizeF(26F, 16F);
            this.ConnSimbolo.StylePriority.UseFont = false;
            this.ConnSimbolo.StylePriority.UseTextAlignment = false;
            this.ConnSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.ConnSimbolo.WordWrap = false;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(760F, 62.33F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel21.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Total de Ventas de Contado";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel21.WordWrap = false;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(760F, 78.33F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel22.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Total de Ventas de Credito";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel22.WordWrap = false;
            // 
            // CreeSimbolo
            // 
            this.CreeSimbolo.Dpi = 100F;
            this.CreeSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreeSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(965F, 78.33F);
            this.CreeSimbolo.Name = "CreeSimbolo";
            this.CreeSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreeSimbolo.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.CreeSimbolo.SizeF = new System.Drawing.SizeF(26F, 16F);
            this.CreeSimbolo.StylePriority.UseFont = false;
            this.CreeSimbolo.StylePriority.UseTextAlignment = false;
            this.CreeSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.CreeSimbolo.WordWrap = false;
            // 
            // CreeTotal
            // 
            this.CreeTotal.Dpi = 100F;
            this.CreeTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreeTotal.LocationFloat = new DevExpress.Utils.PointFloat(991.46F, 78.33F);
            this.CreeTotal.Name = "CreeTotal";
            this.CreeTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreeTotal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.CreeTotal.SizeF = new System.Drawing.SizeF(80.54F, 16F);
            this.CreeTotal.StylePriority.UseFont = false;
            this.CreeTotal.StylePriority.UseTextAlignment = false;
            this.CreeTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.CreeTotal.WordWrap = false;
            // 
            // CobbTotal
            // 
            this.CobbTotal.Dpi = 100F;
            this.CobbTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CobbTotal.LocationFloat = new DevExpress.Utils.PointFloat(991.46F, 94.33F);
            this.CobbTotal.Name = "CobbTotal";
            this.CobbTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CobbTotal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.CobbTotal.SizeF = new System.Drawing.SizeF(80.54F, 16F);
            this.CobbTotal.StylePriority.UseFont = false;
            this.CobbTotal.StylePriority.UseTextAlignment = false;
            this.CobbTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.CobbTotal.WordWrap = false;
            // 
            // CobbSimbolo
            // 
            this.CobbSimbolo.Dpi = 100F;
            this.CobbSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CobbSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(965F, 94.33F);
            this.CobbSimbolo.Name = "CobbSimbolo";
            this.CobbSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CobbSimbolo.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.CobbSimbolo.SizeF = new System.Drawing.SizeF(26F, 16F);
            this.CobbSimbolo.StylePriority.UseFont = false;
            this.CobbSimbolo.StylePriority.UseTextAlignment = false;
            this.CobbSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.CobbSimbolo.WordWrap = false;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(760F, 94.33F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel29.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "Total de Cobranza";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel29.WordWrap = false;
            // 
            // LiqqTotal
            // 
            this.LiqqTotal.Dpi = 100F;
            this.LiqqTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqqTotal.LocationFloat = new DevExpress.Utils.PointFloat(991.46F, 110.33F);
            this.LiqqTotal.Name = "LiqqTotal";
            this.LiqqTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqqTotal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.LiqqTotal.SizeF = new System.Drawing.SizeF(80.54F, 16F);
            this.LiqqTotal.StylePriority.UseFont = false;
            this.LiqqTotal.StylePriority.UseTextAlignment = false;
            this.LiqqTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.LiqqTotal.WordWrap = false;
            // 
            // LiqqSimbolo
            // 
            this.LiqqSimbolo.Dpi = 100F;
            this.LiqqSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqqSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(965F, 110.33F);
            this.LiqqSimbolo.Name = "LiqqSimbolo";
            this.LiqqSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqqSimbolo.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.LiqqSimbolo.SizeF = new System.Drawing.SizeF(26F, 16F);
            this.LiqqSimbolo.StylePriority.UseFont = false;
            this.LiqqSimbolo.StylePriority.UseTextAlignment = false;
            this.LiqqSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.LiqqSimbolo.WordWrap = false;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(760F, 110.33F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel32.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Total a Liquidar";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel32.WordWrap = false;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // formattingRule2
            // 
            this.formattingRule2.Name = "formattingRule2";
            // 
            // ReporteLiquidacionAfrima
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportFooter,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.GroupHeader5});
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1,
            this.formattingRule2});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 6, 48);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
