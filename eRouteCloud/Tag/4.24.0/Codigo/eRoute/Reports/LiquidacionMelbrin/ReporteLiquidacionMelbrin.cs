using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class ReporteLiquidacionMelbrin : DevExpress.XtraReports.UI.XtraReport
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
    public XRSubreport xrSubreportCredito;
    private GroupHeaderBand GroupHeader2;
    public XRSubreport xrSubreportContado;
    private XRLabel xrLabel4;
    public XRLabel CoSimbolo;
    public XRLabel CoTotal;
    public XRLabel CrTotal;
    public XRLabel CrSimbolo;
    private XRLabel xrLabel7;
    private GroupHeaderBand GroupHeader3;
    public XRSubreport xrSubreportProducto;
    public XRSubreport xrSubreportCobranza;
    private GroupHeaderBand GroupHeader4;
    private GroupHeaderBand GroupHeader5;
    public XRSubreport xrSubreportMonedas;
    public XRLabel xrLabel6;
    private XRLabel xrLabel5;
    public XRLabel CobSimbolo;
    public XRLabel CobTotal;
    public XRSubreport xrSubreportBilletes;
    private XRLabel xrLabel8;
    public XRLabel LiqSimbolo;
    public XRLabel LiqTotal;
    public XRLabel TKilosCon;
    public XRLabel xrLabel15;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    public XRLabel BImporte;
    public XRLabel BCantidad;
    public XRLabel BBillete;
    public XRLabel DSimbolo;
    private XRLabel xrLabel19;
    public XRLabel xrLabel14;
    public XRLabel GDSimbolo;
    public XRLabel xrLabel18;
    public XRLabel xrLabel10;
    public XRLabel TDSimbolo;
    public XRLabel xrLabel16;
    private XRLabel xrLabel9;
    public XRSubreport xrSubreportDesglose;
    private XRLabel xrLabel17;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    public XRLabel xrLabel28;
    public XRLabel xrLabel29;
    private XRLabel xrLabel31;
    public XRLabel xrLabel32;
    public XRLabel TKilos;
    private XRLabel xrLabel30;
    public XRLabel conSimbolo;
    public XRLabel ConTotal;
    private GroupHeaderBand GroupHeader6;
    public XRSubreport xrSubreportConsigna;
    public XRLabel xrLabel26;
    public XRLabel xrLabel25;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteLiquidacionMelbrin()
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
            this.xrSubreportDesglose = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.GDSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.TDSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.BImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.BCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.BBillete = new DevExpress.XtraReports.UI.XRLabel();
            this.DSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreportBilletes = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreportMonedas = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrSubreportCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.TKilos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.conSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.ConTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.TKilosCon = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrSubreportCobranza = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrSubreportContado = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrSubreportProducto = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader6 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrSubreportConsigna = new DevExpress.XtraReports.UI.XRSubreport();
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
            this.BottomMargin.HeightF = 45.83333F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(50F, 15F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(725F, 15F);
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
            this.PageHeader.HeightF = 154.625F;
            this.PageHeader.Name = "PageHeader";
            // 
            // HeaderVendedor
            // 
            this.HeaderVendedor.Dpi = 100F;
            this.HeaderVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderVendedor.LocationFloat = new DevExpress.Utils.PointFloat(102.75F, 123F);
            this.HeaderVendedor.Name = "HeaderVendedor";
            this.HeaderVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderVendedor.SizeF = new System.Drawing.SizeF(650F, 16F);
            this.HeaderVendedor.StylePriority.UseFont = false;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 123F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor:";
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
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 106F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Fecha:";
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(349.25F, 16F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(400F, 25F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Reporte de Liquidación (MELBRIN)";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // HeaderFecha
            // 
            this.HeaderFecha.Dpi = 100F;
            this.HeaderFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderFecha.LocationFloat = new DevExpress.Utils.PointFloat(102.75F, 106F);
            this.HeaderFecha.Name = "HeaderFecha";
            this.HeaderFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderFecha.SizeF = new System.Drawing.SizeF(650F, 16F);
            this.HeaderFecha.StylePriority.UseFont = false;
            // 
            // HeaderDireccion
            // 
            this.HeaderDireccion.Dpi = 100F;
            this.HeaderDireccion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderDireccion.LocationFloat = new DevExpress.Utils.PointFloat(530.25F, 56F);
            this.HeaderDireccion.Name = "HeaderDireccion";
            this.HeaderDireccion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderDireccion.SizeF = new System.Drawing.SizeF(540F, 16F);
            this.HeaderDireccion.StylePriority.UseFont = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(429.25F, 56F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Dieccion:";
            // 
            // HeaderTelefono
            // 
            this.HeaderTelefono.Dpi = 100F;
            this.HeaderTelefono.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderTelefono.LocationFloat = new DevExpress.Utils.PointFloat(530.25F, 73F);
            this.HeaderTelefono.Name = "HeaderTelefono";
            this.HeaderTelefono.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderTelefono.SizeF = new System.Drawing.SizeF(400F, 16F);
            this.HeaderTelefono.StylePriority.UseFont = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(429.25F, 73F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Telefono:";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportDesglose,
            this.xrLabel19,
            this.xrLabel14,
            this.GDSimbolo,
            this.xrLabel18,
            this.xrLabel10,
            this.TDSimbolo,
            this.xrLabel16,
            this.xrLabel9,
            this.BImporte,
            this.BCantidad,
            this.BBillete,
            this.DSimbolo,
            this.xrSubreportBilletes,
            this.xrLabel6,
            this.xrSubreportMonedas});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 233.8317F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrSubreportDesglose
            // 
            this.xrSubreportDesglose.CanShrink = true;
            this.xrSubreportDesglose.Dpi = 100F;
            this.xrSubreportDesglose.LocationFloat = new DevExpress.Utils.PointFloat(324.5417F, 14.95997F);
            this.xrSubreportDesglose.Name = "xrSubreportDesglose";
            this.xrSubreportDesglose.SizeF = new System.Drawing.SizeF(746.5417F, 82.04003F);
            this.xrSubreportDesglose.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // xrLabel19
            // 
            this.xrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel19.BorderWidth = 2F;
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(570F, 207.83F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(350F, 16F);
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseBorderWidth = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Recibí valores para su resguardo (Nombre, Firma y Puesto)";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(982F, 118F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(90F, 16F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "_____________";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // GDSimbolo
            // 
            this.GDSimbolo.Dpi = 100F;
            this.GDSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GDSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(927F, 118F);
            this.GDSimbolo.Name = "GDSimbolo";
            this.GDSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GDSimbolo.SizeF = new System.Drawing.SizeF(55F, 16F);
            this.GDSimbolo.StylePriority.UseFont = false;
            this.GDSimbolo.StylePriority.UseTextAlignment = false;
            this.GDSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(821.33F, 118F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(105.2083F, 16F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Gran Total";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(821.33F, 98F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(105.2083F, 16F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Total Documentos";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TDSimbolo
            // 
            this.TDSimbolo.Dpi = 100F;
            this.TDSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TDSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(927F, 98F);
            this.TDSimbolo.Name = "TDSimbolo";
            this.TDSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TDSimbolo.SizeF = new System.Drawing.SizeF(55F, 16F);
            this.TDSimbolo.StylePriority.UseFont = false;
            this.TDSimbolo.StylePriority.UseTextAlignment = false;
            this.TDSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(982F, 98F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(90F, 16F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "_____________";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel9.BorderWidth = 2F;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(150F, 207.83F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(350F, 16F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseBorderWidth = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Revisó Documentos (Nombre, Firma y Puesto)";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BImporte
            // 
            this.BImporte.Dpi = 100F;
            this.BImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BImporte.LocationFloat = new DevExpress.Utils.PointFloat(210F, 98.04001F);
            this.BImporte.Name = "BImporte";
            this.BImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BImporte.SizeF = new System.Drawing.SizeF(90F, 16F);
            this.BImporte.StylePriority.UseFont = false;
            this.BImporte.StylePriority.UseTextAlignment = false;
            this.BImporte.Text = "_____________";
            this.BImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BCantidad
            // 
            this.BCantidad.Dpi = 100F;
            this.BCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCantidad.LocationFloat = new DevExpress.Utils.PointFloat(100F, 98.04001F);
            this.BCantidad.Name = "BCantidad";
            this.BCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BCantidad.SizeF = new System.Drawing.SizeF(55F, 16F);
            this.BCantidad.StylePriority.UseFont = false;
            this.BCantidad.StylePriority.UseTextAlignment = false;
            this.BCantidad.Text = "________";
            this.BCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BBillete
            // 
            this.BBillete.Dpi = 100F;
            this.BBillete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBillete.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 98.04001F);
            this.BBillete.Name = "BBillete";
            this.BBillete.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BBillete.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.BBillete.StylePriority.UseFont = false;
            this.BBillete.StylePriority.UseTextAlignment = false;
            this.BBillete.Text = "Total Efectivo";
            this.BBillete.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DSimbolo
            // 
            this.DSimbolo.Dpi = 100F;
            this.DSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(155F, 98.04001F);
            this.DSimbolo.Name = "DSimbolo";
            this.DSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DSimbolo.SizeF = new System.Drawing.SizeF(55F, 16F);
            this.DSimbolo.StylePriority.UseFont = false;
            this.DSimbolo.StylePriority.UseTextAlignment = false;
            this.DSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrSubreportBilletes
            // 
            this.xrSubreportBilletes.CanShrink = true;
            this.xrSubreportBilletes.Dpi = 100F;
            this.xrSubreportBilletes.LocationFloat = new DevExpress.Utils.PointFloat(0F, 57F);
            this.xrSubreportBilletes.Name = "xrSubreportBilletes";
            this.xrSubreportBilletes.SizeF = new System.Drawing.SizeF(300F, 40.04F);
            this.xrSubreportBilletes.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
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
            // xrSubreportMonedas
            // 
            this.xrSubreportMonedas.CanShrink = true;
            this.xrSubreportMonedas.Dpi = 100F;
            this.xrSubreportMonedas.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 14.96F);
            this.xrSubreportMonedas.Name = "xrSubreportMonedas";
            this.xrSubreportMonedas.SizeF = new System.Drawing.SizeF(300F, 40.04F);
            this.xrSubreportMonedas.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // xrSubreportCredito
            // 
            this.xrSubreportCredito.CanShrink = true;
            this.xrSubreportCredito.Dpi = 100F;
            this.xrSubreportCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreportCredito.Name = "xrSubreportCredito";
            this.xrSubreportCredito.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportCredito.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel26,
            this.xrLabel25,
            this.xrLabel31,
            this.xrLabel32,
            this.TKilos,
            this.xrLabel30,
            this.conSimbolo,
            this.ConTotal,
            this.xrLabel17,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel28,
            this.xrLabel29,
            this.TKilosCon,
            this.xrLabel15,
            this.xrLabel13,
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
            this.ReportFooter.HeightF = 508.4201F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(216.6717F, 228.9384F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(133.7965F, 16F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "__________________";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(215.745F, 206.9384F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(133.7965F, 16F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "__________________";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(0F, 470.42F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.Text = "TOTAL DE KILOS VENDIDOS:";
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(213.5466F, 470.42F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.xrLabel32.StylePriority.UseFont = false;
            // 
            // TKilos
            // 
            this.TKilos.Dpi = 100F;
            this.TKilos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TKilos.LocationFloat = new DevExpress.Utils.PointFloat(230.2134F, 470.42F);
            this.TKilos.Name = "TKilos";
            this.TKilos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TKilos.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.TKilos.StylePriority.UseFont = false;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.Text = "Total de Ventas de Consignacion";
            // 
            // conSimbolo
            // 
            this.conSimbolo.Dpi = 100F;
            this.conSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(200.4583F, 116F);
            this.conSimbolo.Name = "conSimbolo";
            this.conSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.conSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.conSimbolo.StylePriority.UseFont = false;
            // 
            // ConTotal
            // 
            this.ConTotal.Dpi = 100F;
            this.ConTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConTotal.LocationFloat = new DevExpress.Utils.PointFloat(218.51F, 116F);
            this.ConTotal.Name = "ConTotal";
            this.ConTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConTotal.SizeF = new System.Drawing.SizeF(132.4165F, 16F);
            this.ConTotal.StylePriority.UseFont = false;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(0F, 206.9384F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "Comisión Pagada:";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(0F, 228.9384F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "Comisión Retenida:";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 250.9384F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.Text = "Comisión Global del día:";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0F, 272.9383F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Recibió Efectivo";
            // 
            // xrLabel28
            // 
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(216.6717F, 250.9384F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(133.7965F, 16F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "__________________";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(216.2083F, 272.9383F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(133.7965F, 16F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "__________________";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TKilosCon
            // 
            this.TKilosCon.Dpi = 100F;
            this.TKilosCon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TKilosCon.LocationFloat = new DevExpress.Utils.PointFloat(230.2134F, 492.4201F);
            this.TKilosCon.Name = "TKilosCon";
            this.TKilosCon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TKilosCon.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.TKilosCon.StylePriority.UseFont = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(213.5466F, 492.4201F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.xrLabel15.StylePriority.UseFont = false;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 492.4201F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(214.005F, 16F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "TOTAL DE KILOS EN CONSGINACION:";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(570F, 338.6267F);
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
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(246.5001F, 338.6267F);
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
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Total a Liquidar";
            // 
            // LiqSimbolo
            // 
            this.LiqSimbolo.Dpi = 100F;
            this.LiqSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(199.9999F, 160F);
            this.LiqSimbolo.Name = "LiqSimbolo";
            this.LiqSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.LiqSimbolo.StylePriority.UseFont = false;
            // 
            // LiqTotal
            // 
            this.LiqTotal.Dpi = 100F;
            this.LiqTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqTotal.LocationFloat = new DevExpress.Utils.PointFloat(216.2083F, 160F);
            this.LiqTotal.Name = "LiqTotal";
            this.LiqTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqTotal.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.LiqTotal.StylePriority.UseFont = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 138F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Total de Cobranza";
            // 
            // CobSimbolo
            // 
            this.CobSimbolo.Dpi = 100F;
            this.CobSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CobSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(200F, 138F);
            this.CobSimbolo.Name = "CobSimbolo";
            this.CobSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CobSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.CobSimbolo.StylePriority.UseFont = false;
            // 
            // CobTotal
            // 
            this.CobTotal.Dpi = 100F;
            this.CobTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CobTotal.LocationFloat = new DevExpress.Utils.PointFloat(216.2083F, 138F);
            this.CobTotal.Name = "CobTotal";
            this.CobTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CobTotal.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.CobTotal.StylePriority.UseFont = false;
            // 
            // CrTotal
            // 
            this.CrTotal.Dpi = 100F;
            this.CrTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrTotal.LocationFloat = new DevExpress.Utils.PointFloat(217.13F, 94F);
            this.CrTotal.Name = "CrTotal";
            this.CrTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrTotal.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.CrTotal.StylePriority.UseFont = false;
            // 
            // CrSimbolo
            // 
            this.CrSimbolo.Dpi = 100F;
            this.CrSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(200.46F, 94F);
            this.CrSimbolo.Name = "CrSimbolo";
            this.CrSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.CrSimbolo.StylePriority.UseFont = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 94F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
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
            this.xrLabel4.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Total de Ventas de Contado";
            // 
            // CoSimbolo
            // 
            this.CoSimbolo.Dpi = 100F;
            this.CoSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(200.46F, 72F);
            this.CoSimbolo.Name = "CoSimbolo";
            this.CoSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CoSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.CoSimbolo.StylePriority.UseFont = false;
            // 
            // CoTotal
            // 
            this.CoTotal.Dpi = 100F;
            this.CoTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoTotal.LocationFloat = new DevExpress.Utils.PointFloat(217.13F, 72F);
            this.CoTotal.Name = "CoTotal";
            this.CoTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CoTotal.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.CoTotal.StylePriority.UseFont = false;
            // 
            // PTotal
            // 
            this.PTotal.Dpi = 100F;
            this.PTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PTotal.LocationFloat = new DevExpress.Utils.PointFloat(217.13F, 50F);
            this.PTotal.Name = "PTotal";
            this.PTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PTotal.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.PTotal.StylePriority.UseFont = false;
            // 
            // PSimbolo
            // 
            this.PSimbolo.Dpi = 100F;
            this.PSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(200.46F, 50F);
            this.PSimbolo.Name = "PSimbolo";
            this.PSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.PSimbolo.StylePriority.UseFont = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
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
            this.xrSubreportCobranza});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 55F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrSubreportCobranza
            // 
            this.xrSubreportCobranza.CanShrink = true;
            this.xrSubreportCobranza.Dpi = 100F;
            this.xrSubreportCobranza.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreportCobranza.Name = "xrSubreportCobranza";
            this.xrSubreportCobranza.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportCobranza.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // xrSubreportContado
            // 
            this.xrSubreportContado.CanShrink = true;
            this.xrSubreportContado.Dpi = 100F;
            this.xrSubreportContado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreportContado.Name = "xrSubreportContado";
            this.xrSubreportContado.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportContado.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportCredito});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 54.99999F;
            this.GroupHeader3.Level = 3;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // xrSubreportProducto
            // 
            this.xrSubreportProducto.CanShrink = true;
            this.xrSubreportProducto.Dpi = 100F;
            this.xrSubreportProducto.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 0F);
            this.xrSubreportProducto.Name = "xrSubreportProducto";
            this.xrSubreportProducto.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportProducto.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportContado});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 55F;
            this.GroupHeader4.Level = 4;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportProducto});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 55F;
            this.GroupHeader5.Level = 5;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // GroupHeader6
            // 
            this.GroupHeader6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportConsigna});
            this.GroupHeader6.Dpi = 100F;
            this.GroupHeader6.HeightF = 70.83334F;
            this.GroupHeader6.Level = 2;
            this.GroupHeader6.Name = "GroupHeader6";
            // 
            // xrSubreportConsigna
            // 
            this.xrSubreportConsigna.CanShrink = true;
            this.xrSubreportConsigna.Dpi = 100F;
            this.xrSubreportConsigna.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 0F);
            this.xrSubreportConsigna.Name = "xrSubreportConsigna";
            this.xrSubreportConsigna.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportConsigna.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // ReporteLiquidacionMelbrin
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
            this.GroupHeader5,
            this.GroupHeader6});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 6, 46);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
