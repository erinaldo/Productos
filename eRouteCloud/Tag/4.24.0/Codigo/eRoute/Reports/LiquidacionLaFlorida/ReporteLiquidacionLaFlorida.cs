using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class ReporteLiquidacionLaFlorida : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private PageHeaderBand PageHeader;
    public XRLabel HeaderVendedor;
    private XRLabel xrLabel24;
    private XRLabel xrLabel20;
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
    public XRLabel TKilos;
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
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteLiquidacionLaFlorida()
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
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.TKilos = new DevExpress.XtraReports.UI.XRLabel();
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
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
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
            this.logo,
            this.reporte,
            this.empresa,
            this.HeaderVendedor,
            this.xrLabel24,
            this.xrLabel20,
            this.HeaderFecha,
            this.HeaderDireccion,
            this.xrLabel1,
            this.HeaderTelefono,
            this.xrLabel3});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 205.6667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // HeaderVendedor
            // 
            this.HeaderVendedor.Dpi = 100F;
            this.HeaderVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderVendedor.LocationFloat = new DevExpress.Utils.PointFloat(92.45831F, 189.6667F);
            this.HeaderVendedor.Name = "HeaderVendedor";
            this.HeaderVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderVendedor.SizeF = new System.Drawing.SizeF(650F, 16F);
            this.HeaderVendedor.StylePriority.UseFont = false;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(1.624997F, 189.6667F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor:";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(1.624997F, 172.6667F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Fecha:";
            // 
            // HeaderFecha
            // 
            this.HeaderFecha.Dpi = 100F;
            this.HeaderFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderFecha.LocationFloat = new DevExpress.Utils.PointFloat(92.45831F, 172.6667F);
            this.HeaderFecha.Name = "HeaderFecha";
            this.HeaderFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderFecha.SizeF = new System.Drawing.SizeF(650F, 16F);
            this.HeaderFecha.StylePriority.UseFont = false;
            // 
            // HeaderDireccion
            // 
            this.HeaderDireccion.Dpi = 100F;
            this.HeaderDireccion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderDireccion.LocationFloat = new DevExpress.Utils.PointFloat(519.9584F, 122.6667F);
            this.HeaderDireccion.Name = "HeaderDireccion";
            this.HeaderDireccion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderDireccion.SizeF = new System.Drawing.SizeF(540F, 16F);
            this.HeaderDireccion.StylePriority.UseFont = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(418.9583F, 122.6667F);
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
            this.HeaderTelefono.LocationFloat = new DevExpress.Utils.PointFloat(519.9584F, 139.6667F);
            this.HeaderTelefono.Name = "HeaderTelefono";
            this.HeaderTelefono.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HeaderTelefono.SizeF = new System.Drawing.SizeF(400F, 16F);
            this.HeaderTelefono.StylePriority.UseFont = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(418.9583F, 139.6667F);
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
            this.BImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
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
            this.BCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
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
            this.TKilos,
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
            this.ReportFooter.HeightF = 372.9167F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // TKilos
            // 
            this.TKilos.Dpi = 100F;
            this.TKilos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TKilos.LocationFloat = new DevExpress.Utils.PointFloat(217.13F, 341.2917F);
            this.TKilos.Name = "TKilos";
            this.TKilos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TKilos.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.TKilos.StylePriority.UseFont = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(200.4632F, 341.2917F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.xrLabel15.StylePriority.UseFont = false;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 341.2917F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "TOTAL DE KILOS VENDIDOS:";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(573.4999F, 213.54F);
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
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(250F, 213.54F);
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
            this.xrLabel8.SizeF = new System.Drawing.SizeF(200.4583F, 16F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Total a Liquidar";
            // 
            // LiqSimbolo
            // 
            this.LiqSimbolo.Dpi = 100F;
            this.LiqSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(200.4583F, 138F);
            this.LiqSimbolo.Name = "LiqSimbolo";
            this.LiqSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.LiqSimbolo.StylePriority.UseFont = false;
            // 
            // LiqTotal
            // 
            this.LiqTotal.Dpi = 100F;
            this.LiqTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiqTotal.LocationFloat = new DevExpress.Utils.PointFloat(217.125F, 138F);
            this.LiqTotal.Name = "LiqTotal";
            this.LiqTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LiqTotal.SizeF = new System.Drawing.SizeF(133.3332F, 16F);
            this.LiqTotal.StylePriority.UseFont = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116F);
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
            this.CobSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(200.4583F, 116F);
            this.CobSimbolo.Name = "CobSimbolo";
            this.CobSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CobSimbolo.SizeF = new System.Drawing.SizeF(16.66675F, 16F);
            this.CobSimbolo.StylePriority.UseFont = false;
            // 
            // CobTotal
            // 
            this.CobTotal.Dpi = 100F;
            this.CobTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CobTotal.LocationFloat = new DevExpress.Utils.PointFloat(217.125F, 116F);
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
            this.GroupHeader3.HeightF = 55F;
            this.GroupHeader3.Level = 2;
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
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportProducto});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 55F;
            this.GroupHeader5.Level = 4;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(100F, 10.00002F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(355.875F, 70.00002F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(355.875F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReporteLiquidacionLaFlorida
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
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 6, 46);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
