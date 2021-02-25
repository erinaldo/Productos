using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for Rpt_Liquidacion
/// </summary>
public class Rpt_Liquidacion : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    public XRLabel L_FechaRango;
    public XRLabel L_CEDI;
    public XRLabel L_VendedorClave;
    private XRLabel xrLabel48;
    private XRLabel xrLabel46;
    private XRLabel xrLabel45;
    public XRLabel xrLabel13;
    public XRLabel xrLabel12;
    public XRLabel xrLabel11;
    public XRLabel xrLabel10;
    public XRLabel xrLabel9;
    public XRLabel xrLabel8;
    public XRLabel xrLabel7;
    public XRLabel xrLabel6;
    public XRLabel xrLabel5;
    public XRLabel xrLabel4;
    public XRLabel xrLabel3;
    private XRLine xrLine3;
    private XRLine xrLine4;
    public XRLabel xrLabel2;
    public XRLabel xrLabel14;
    public DetailReportBand MovimientosProductos;
    private DetailBand Detail1;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel15;
    public XRLabel L_Inv_Final;
    public XRLabel L_Importe;
    public XRLabel L_Promo;
    public XRLabel L_Descripcion;
    public XRLabel L_Recargas;
    public XRLabel L_Descargas;
    public XRLabel L_Inv_Inicial;
    public XRLabel L_Devoluciones;
    public XRLabel L_CambiosEnt;
    public XRLabel L_Unidad;
    public XRLabel L_Clave;
    public XRLabel L_Ventas;
    public XRLabel L_Merma;
    private ReportFooterBand ReportFooter;
    public XRLabel L_TotalMerma;
    public XRLabel L_TotalVentas;
    public XRLabel L_TotalCambioEnt;
    public XRLabel L_TotalDevoluciones;
    public XRLabel L_TotalInv_Inicial;
    public XRLabel L_TotalDescargas;
    public XRLabel L_TotalRecargas;
    public XRLabel L_TotalPromo;
    public XRLabel L_TotalImporte;
    public XRLabel L_TotalInv_Final;
    public DetailReportBand VentasContado;
    private DetailBand Detail2;
    public XRLabel L_Venta1;
    public XRLabel L_Cliente1;
    public XRLabel L_Promo1;
    public XRLabel L_Importe1;
    public XRLabel L_Fecha1;
    private ReportHeaderBand ReportHeader1;
    public XRLabel xrLabel29;
    private XRLine xrLine1;
    public XRLabel xrLabel34;
    public XRLabel xrLabel35;
    public XRLabel xrLabel37;
    private XRLine xrLine2;
    public XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private ReportFooterBand ReportFooter1;
    public XRLabel xrLabel25;
    public XRLabel L_TotalContado1;
    public DetailReportBand VentasCredito;
    private DetailBand Detail3;
    public XRLabel L_Fecha2;
    public XRLabel L_Importe2;
    public XRLabel L_Promo2;
    public XRLabel L_Cliente2;
    public XRLabel L_Venta2;
    private ReportHeaderBand ReportHeader2;
    private XRLabel xrLabel16;
    public XRLabel xrLabel17;
    private XRLine xrLine5;
    public XRLabel xrLabel18;
    public XRLabel xrLabel19;
    public XRLabel xrLabel20;
    private XRLine xrLine6;
    public XRLabel xrLabel21;
    private ReportFooterBand ReportFooter2;
    public XRLabel L_TotalCredito2;
    public XRLabel xrLabel24;
    public DetailReportBand Cobranza;
    private DetailBand Detail4;
    public XRLabel L_ClienteCobranza;
    public XRLabel L_FechaCobranza;
    public XRLabel L_FormaPagoCobranza;
    public XRLabel L_ReferenciaCobranza;
    public XRLabel L_ImporteVtaCobranza;
    public XRLabel L_SaldoCobranza;
    public XRLabel L_VentaCobranza;
    public XRLabel L_ImporteCobranza;
    private ReportHeaderBand ReportHeader3;
    public XRLabel xrLabel23;
    private XRLine xrLine7;
    public XRLabel xrLabel30;
    public XRLabel xrLabel31;
    public XRLabel xrLabel32;
    public XRLabel xrLabel33;
    public XRLabel xrLabel36;
    public XRLabel xrLabel40;
    private XRLine xrLine8;
    public XRLabel xrLabel42;
    private XRLabel xrLabel43;
    private ReportFooterBand ReportFooter3;
    public XRLabel xrLabel22;
    public DetailReportBand PreLiquidacion;
    private DetailBand Detail5;
    private XRLabel xrLabel26;
    public XRLabel xrLabel27;
    public XRLabel xrLabel28;
    public XRLabel xrLabel41;
    public XRLabel xrLabel47;
    public XRLabel xrLabel49;
    public XRLabel xrLabel50;
    public XRLabel xrLabel51;
    public XRLabel xrLabel52;
    public XRLabel xrLabel53;
    public XRLabel xrLabel54;
    public XRLabel xrLabel55;
    public XRLabel L_VtaTotalPre;
    public XRLabel L_VtaCreditoPre;
    public XRLabel L_PromocionPre;
    public XRLabel L_DevolucionesPre;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRLabel xrLabel56;
    private XRPageInfo xrPageInfo1;
    public GroupHeaderBand GroupHeaderVendedor;
    public XRLabel L_TotalCobranza3;
    private XRLabel xrLabel1;
    public XRLabel L_VtaContadoPre;
    public XRLabel L_CobranzaPre;
    public XRLabel L_LiquidarPre;
    private XRLine xrLine16;
    private XRLine xrLine17;
    public XRLabel footerVendedor;
    public XRLabel footerCedi;
    public XRLabel L_Gpo_VendedorNom;
    public XRLabel L_Gpo_VendedorID;
    public XRLabel reporte;
    public XRPictureBox logo;
    public XRLabel L_CambiosSal;
    public XRLabel xrLabel44;
    public XRLabel L_TotalCambioSal;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Rpt_Liquidacion()
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
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.L_FechaRango = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VendedorClave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.MovimientosProductos = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_Inv_Final = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Importe = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Promo = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Descripcion = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Recargas = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Descargas = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Inv_Inicial = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Devoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CambiosEnt = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Unidad = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Clave = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Ventas = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Merma = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.L_TotalMerma = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalVentas = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalCambioEnt = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalDevoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalInv_Inicial = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalDescargas = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalRecargas = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalPromo = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalInv_Final = new DevExpress.XtraReports.UI.XRLabel();
            this.VentasContado = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_Venta1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Cliente1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Promo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Importe1 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Fecha1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalContado1 = new DevExpress.XtraReports.UI.XRLabel();
            this.VentasCredito = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail3 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_Fecha2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Importe2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Promo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Cliente2 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Venta2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader2 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter2 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.L_TotalCredito2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.Cobranza = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail4 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_ClienteCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FechaCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FormaPagoCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ReferenciaCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ImporteVtaCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.L_SaldoCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VentaCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.L_ImporteCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader3 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine8 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter3 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalCobranza3 = new DevExpress.XtraReports.UI.XRLabel();
            this.PreLiquidacion = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail5 = new DevExpress.XtraReports.UI.DetailBand();
            this.L_LiquidarPre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CobranzaPre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VtaContadoPre = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine16 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine17 = new DevExpress.XtraReports.UI.XRLine();
            this.footerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.footerCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VtaTotalPre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VtaCreditoPre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_PromocionPre = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DevolucionesPre = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeaderVendedor = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.L_Gpo_VendedorID = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Gpo_VendedorNom = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_CambiosSal = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalCambioSal = new DevExpress.XtraReports.UI.XRLabel();
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
            this.TopMargin.HeightF = 25F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 25F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.reporte,
            this.logo,
            this.L_FechaRango,
            this.L_CEDI,
            this.L_VendedorClave,
            this.xrLabel48,
            this.xrLabel46,
            this.xrLabel45});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 124.738F;
            this.PageHeader.Name = "PageHeader";
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(196.4506F, 0F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(791.1539F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(10.41667F, 10.00001F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(166.0408F, 105.5F);
            // 
            // L_FechaRango
            // 
            this.L_FechaRango.Dpi = 100F;
            this.L_FechaRango.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaRango.LocationFloat = new DevExpress.Utils.PointFloat(402.437F, 74.87503F);
            this.L_FechaRango.Name = "L_FechaRango";
            this.L_FechaRango.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_FechaRango.SizeF = new System.Drawing.SizeF(299.5219F, 12.99999F);
            this.L_FechaRango.StylePriority.UseFont = false;
            this.L_FechaRango.StylePriority.UsePadding = false;
            this.L_FechaRango.StylePriority.UseTextAlignment = false;
            this.L_FechaRango.Text = "Rango de Fechas";
            this.L_FechaRango.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_CEDI
            // 
            this.L_CEDI.Dpi = 100F;
            this.L_CEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CEDI.LocationFloat = new DevExpress.Utils.PointFloat(402.437F, 59.29166F);
            this.L_CEDI.Name = "L_CEDI";
            this.L_CEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_CEDI.SizeF = new System.Drawing.SizeF(299.8937F, 13F);
            this.L_CEDI.StylePriority.UseFont = false;
            this.L_CEDI.StylePriority.UsePadding = false;
            this.L_CEDI.StylePriority.UseTextAlignment = false;
            this.L_CEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_VendedorClave
            // 
            this.L_VendedorClave.Dpi = 100F;
            this.L_VendedorClave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VendedorClave.LocationFloat = new DevExpress.Utils.PointFloat(402.437F, 87.87506F);
            this.L_VendedorClave.Name = "L_VendedorClave";
            this.L_VendedorClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.L_VendedorClave.SizeF = new System.Drawing.SizeF(300.2653F, 13F);
            this.L_VendedorClave.StylePriority.UseFont = false;
            this.L_VendedorClave.StylePriority.UsePadding = false;
            this.L_VendedorClave.StylePriority.UseTextAlignment = false;
            this.L_VendedorClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel48
            // 
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(198.5981F, 87.87506F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(188.3619F, 13F);
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UsePadding = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            this.xrLabel48.Text = "Vendedor";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(198.9696F, 59.29166F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(187.9904F, 13F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UsePadding = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "Centro de Distribución";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel45
            // 
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(198.5981F, 74.87503F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(188.3619F, 13F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UsePadding = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            this.xrLabel45.Text = "Fecha";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(1.50528F, 19.3319F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine3.StylePriority.UseBorderWidth = false;
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(1.50528F, 57.24398F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1.755341F, 25.24404F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(60.20466F, 32F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Clave";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(61.95996F, 25.24187F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(210F, 32F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Descripción";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(271.96F, 25.24404F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(55F, 32F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Unidad";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(326.96F, 25.24404F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(60F, 32F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Invetario\r\nInicial";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(386.96F, 25.24404F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(58F, 32F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Recargas";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(444.96F, 25.24187F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(50F, 32F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "CE";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(545.21F, 25.24404F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(79.19495F, 32F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Devoluciones";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(624.405F, 25.24187F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(62F, 32F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Merma";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(686.405F, 25.24405F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(68F, 32F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Descargas";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(754.4053F, 25.24405F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(71F, 32F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Ventas";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(825.7177F, 25.24404F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(42.79523F, 32F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Promo";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.CanGrow = false;
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(868.8253F, 25.24187F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(94.57971F, 32F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UsePadding = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Importe";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.CanGrow = false;
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(963.405F, 25.24405F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(65F, 32F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Invetario\r\nFinal";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // MovimientosProductos
            // 
            this.MovimientosProductos.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.ReportHeader,
            this.ReportFooter});
            this.MovimientosProductos.Dpi = 100F;
            this.MovimientosProductos.Level = 0;
            this.MovimientosProductos.Name = "MovimientosProductos";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_CambiosSal,
            this.L_Inv_Final,
            this.L_Importe,
            this.L_Promo,
            this.L_Descripcion,
            this.L_Recargas,
            this.L_Descargas,
            this.L_Inv_Inicial,
            this.L_Devoluciones,
            this.L_CambiosEnt,
            this.L_Unidad,
            this.L_Clave,
            this.L_Ventas,
            this.L_Merma});
            this.Detail1.Dpi = 100F;
            this.Detail1.HeightF = 14.5F;
            this.Detail1.Name = "Detail1";
            // 
            // L_Inv_Final
            // 
            this.L_Inv_Final.Dpi = 100F;
            this.L_Inv_Final.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Inv_Final.LocationFloat = new DevExpress.Utils.PointFloat(963.405F, 0F);
            this.L_Inv_Final.Name = "L_Inv_Final";
            this.L_Inv_Final.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Inv_Final.SizeF = new System.Drawing.SizeF(63.9635F, 14.5F);
            this.L_Inv_Final.StylePriority.UseFont = false;
            this.L_Inv_Final.StylePriority.UseTextAlignment = false;
            this.L_Inv_Final.Text = "Inv_Final";
            this.L_Inv_Final.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Importe
            // 
            this.L_Importe.Dpi = 100F;
            this.L_Importe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Importe.LocationFloat = new DevExpress.Utils.PointFloat(869.1378F, 0F);
            this.L_Importe.Name = "L_Importe";
            this.L_Importe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 3, 0, 0, 100F);
            this.L_Importe.SizeF = new System.Drawing.SizeF(94.26721F, 14.5F);
            this.L_Importe.StylePriority.UseFont = false;
            this.L_Importe.StylePriority.UsePadding = false;
            this.L_Importe.StylePriority.UseTextAlignment = false;
            this.L_Importe.Text = "Importe";
            this.L_Importe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Promo
            // 
            this.L_Promo.Dpi = 100F;
            this.L_Promo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Promo.LocationFloat = new DevExpress.Utils.PointFloat(824.3685F, 0F);
            this.L_Promo.Name = "L_Promo";
            this.L_Promo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Promo.SizeF = new System.Drawing.SizeF(44.14435F, 14.5F);
            this.L_Promo.StylePriority.UseFont = false;
            this.L_Promo.StylePriority.UseTextAlignment = false;
            this.L_Promo.Text = "Promo";
            this.L_Promo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Descripcion
            // 
            this.L_Descripcion.CanGrow = false;
            this.L_Descripcion.Dpi = 100F;
            this.L_Descripcion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Descripcion.LocationFloat = new DevExpress.Utils.PointFloat(62.21F, 0F);
            this.L_Descripcion.Name = "L_Descripcion";
            this.L_Descripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Descripcion.SizeF = new System.Drawing.SizeF(209.75F, 14.5F);
            this.L_Descripcion.StylePriority.UseFont = false;
            this.L_Descripcion.StylePriority.UseTextAlignment = false;
            this.L_Descripcion.Text = "Descripcion";
            this.L_Descripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Recargas
            // 
            this.L_Recargas.Dpi = 100F;
            this.L_Recargas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Recargas.LocationFloat = new DevExpress.Utils.PointFloat(387.21F, 0F);
            this.L_Recargas.Name = "L_Recargas";
            this.L_Recargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Recargas.SizeF = new System.Drawing.SizeF(57.74997F, 14.5F);
            this.L_Recargas.StylePriority.UseFont = false;
            this.L_Recargas.StylePriority.UseTextAlignment = false;
            this.L_Recargas.Text = "Recargas";
            this.L_Recargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Descargas
            // 
            this.L_Descargas.Dpi = 100F;
            this.L_Descargas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Descargas.LocationFloat = new DevExpress.Utils.PointFloat(686.655F, 0F);
            this.L_Descargas.Name = "L_Descargas";
            this.L_Descargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Descargas.SizeF = new System.Drawing.SizeF(67.75006F, 14.5F);
            this.L_Descargas.StylePriority.UseFont = false;
            this.L_Descargas.StylePriority.UseTextAlignment = false;
            this.L_Descargas.Text = "Descargas";
            this.L_Descargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Inv_Inicial
            // 
            this.L_Inv_Inicial.Dpi = 100F;
            this.L_Inv_Inicial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Inv_Inicial.LocationFloat = new DevExpress.Utils.PointFloat(327.21F, 0F);
            this.L_Inv_Inicial.Name = "L_Inv_Inicial";
            this.L_Inv_Inicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Inv_Inicial.SizeF = new System.Drawing.SizeF(59.74997F, 14.5F);
            this.L_Inv_Inicial.StylePriority.UseFont = false;
            this.L_Inv_Inicial.StylePriority.UseTextAlignment = false;
            this.L_Inv_Inicial.Text = "Inv_Inicial";
            this.L_Inv_Inicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Devoluciones
            // 
            this.L_Devoluciones.CanGrow = false;
            this.L_Devoluciones.Dpi = 100F;
            this.L_Devoluciones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Devoluciones.LocationFloat = new DevExpress.Utils.PointFloat(545.4601F, 0F);
            this.L_Devoluciones.Name = "L_Devoluciones";
            this.L_Devoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Devoluciones.SizeF = new System.Drawing.SizeF(78.94482F, 14.5F);
            this.L_Devoluciones.StylePriority.UseFont = false;
            this.L_Devoluciones.StylePriority.UseTextAlignment = false;
            this.L_Devoluciones.Text = "Devoluciones";
            this.L_Devoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_CambiosEnt
            // 
            this.L_CambiosEnt.CanGrow = false;
            this.L_CambiosEnt.Dpi = 100F;
            this.L_CambiosEnt.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CambiosEnt.LocationFloat = new DevExpress.Utils.PointFloat(445.2099F, 0F);
            this.L_CambiosEnt.Name = "L_CambiosEnt";
            this.L_CambiosEnt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_CambiosEnt.SizeF = new System.Drawing.SizeF(49.75006F, 14.5F);
            this.L_CambiosEnt.StylePriority.UseFont = false;
            this.L_CambiosEnt.StylePriority.UseTextAlignment = false;
            this.L_CambiosEnt.Text = "Cambios";
            this.L_CambiosEnt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Unidad
            // 
            this.L_Unidad.Dpi = 100F;
            this.L_Unidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Unidad.LocationFloat = new DevExpress.Utils.PointFloat(275.4977F, 0F);
            this.L_Unidad.Name = "L_Unidad";
            this.L_Unidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Unidad.SizeF = new System.Drawing.SizeF(51.46222F, 14.5F);
            this.L_Unidad.StylePriority.UseFont = false;
            this.L_Unidad.StylePriority.UseTextAlignment = false;
            this.L_Unidad.Text = "Unidad";
            this.L_Unidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Clave
            // 
            this.L_Clave.Dpi = 100F;
            this.L_Clave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Clave.LocationFloat = new DevExpress.Utils.PointFloat(0.4063111F, 0F);
            this.L_Clave.Name = "L_Clave";
            this.L_Clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.L_Clave.SizeF = new System.Drawing.SizeF(61.55369F, 14.5F);
            this.L_Clave.StylePriority.UseFont = false;
            this.L_Clave.StylePriority.UsePadding = false;
            this.L_Clave.StylePriority.UseTextAlignment = false;
            this.L_Clave.Text = "Clave";
            this.L_Clave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Ventas
            // 
            this.L_Ventas.Dpi = 100F;
            this.L_Ventas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Ventas.LocationFloat = new DevExpress.Utils.PointFloat(754.4053F, 0F);
            this.L_Ventas.Name = "L_Ventas";
            this.L_Ventas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_Ventas.SizeF = new System.Drawing.SizeF(69.90082F, 14.5F);
            this.L_Ventas.StylePriority.UseFont = false;
            this.L_Ventas.StylePriority.UsePadding = false;
            this.L_Ventas.StylePriority.UseTextAlignment = false;
            this.L_Ventas.Text = "Ventas";
            this.L_Ventas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Merma
            // 
            this.L_Merma.Dpi = 100F;
            this.L_Merma.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Merma.LocationFloat = new DevExpress.Utils.PointFloat(624.6551F, 0F);
            this.L_Merma.Name = "L_Merma";
            this.L_Merma.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Merma.SizeF = new System.Drawing.SizeF(61.74988F, 14.5F);
            this.L_Merma.StylePriority.UseFont = false;
            this.L_Merma.StylePriority.UseTextAlignment = false;
            this.L_Merma.Text = "Merma";
            this.L_Merma.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel44,
            this.xrLabel15,
            this.xrLabel4,
            this.xrLine3,
            this.xrLabel5,
            this.xrLabel8,
            this.xrLabel2,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel13,
            this.xrLabel9,
            this.xrLabel12,
            this.xrLine4,
            this.xrLabel3,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel14});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 63.15398F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(1.509094F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(188.3307F, 13F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Movimientos de Productos";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_TotalCambioSal,
            this.L_TotalMerma,
            this.L_TotalVentas,
            this.L_TotalCambioEnt,
            this.L_TotalDevoluciones,
            this.L_TotalInv_Inicial,
            this.L_TotalDescargas,
            this.L_TotalRecargas,
            this.L_TotalPromo,
            this.L_TotalImporte,
            this.L_TotalInv_Final});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 33.43028F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // L_TotalMerma
            // 
            this.L_TotalMerma.Dpi = 100F;
            this.L_TotalMerma.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalMerma.LocationFloat = new DevExpress.Utils.PointFloat(624.6551F, 0F);
            this.L_TotalMerma.Name = "L_TotalMerma";
            this.L_TotalMerma.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalMerma.SizeF = new System.Drawing.SizeF(61.74988F, 14.5F);
            this.L_TotalMerma.StylePriority.UseFont = false;
            this.L_TotalMerma.StylePriority.UseTextAlignment = false;
            this.L_TotalMerma.Text = "Merma";
            this.L_TotalMerma.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalVentas
            // 
            this.L_TotalVentas.Dpi = 100F;
            this.L_TotalVentas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalVentas.LocationFloat = new DevExpress.Utils.PointFloat(754.4053F, 0F);
            this.L_TotalVentas.Name = "L_TotalVentas";
            this.L_TotalVentas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_TotalVentas.SizeF = new System.Drawing.SizeF(69.9007F, 14.5F);
            this.L_TotalVentas.StylePriority.UseFont = false;
            this.L_TotalVentas.StylePriority.UsePadding = false;
            this.L_TotalVentas.StylePriority.UseTextAlignment = false;
            this.L_TotalVentas.Text = "Ventas";
            this.L_TotalVentas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_TotalCambioEnt
            // 
            this.L_TotalCambioEnt.CanGrow = false;
            this.L_TotalCambioEnt.Dpi = 100F;
            this.L_TotalCambioEnt.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalCambioEnt.LocationFloat = new DevExpress.Utils.PointFloat(445.2099F, 0F);
            this.L_TotalCambioEnt.Name = "L_TotalCambioEnt";
            this.L_TotalCambioEnt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalCambioEnt.SizeF = new System.Drawing.SizeF(49.75006F, 14.5F);
            this.L_TotalCambioEnt.StylePriority.UseFont = false;
            this.L_TotalCambioEnt.StylePriority.UseTextAlignment = false;
            this.L_TotalCambioEnt.Text = "Cambios";
            this.L_TotalCambioEnt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalDevoluciones
            // 
            this.L_TotalDevoluciones.CanGrow = false;
            this.L_TotalDevoluciones.Dpi = 100F;
            this.L_TotalDevoluciones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalDevoluciones.LocationFloat = new DevExpress.Utils.PointFloat(545.4601F, 0F);
            this.L_TotalDevoluciones.Name = "L_TotalDevoluciones";
            this.L_TotalDevoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalDevoluciones.SizeF = new System.Drawing.SizeF(78.94482F, 14.5F);
            this.L_TotalDevoluciones.StylePriority.UseFont = false;
            this.L_TotalDevoluciones.StylePriority.UseTextAlignment = false;
            this.L_TotalDevoluciones.Text = "Devoluciones";
            this.L_TotalDevoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalInv_Inicial
            // 
            this.L_TotalInv_Inicial.Dpi = 100F;
            this.L_TotalInv_Inicial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalInv_Inicial.LocationFloat = new DevExpress.Utils.PointFloat(320.2259F, 0F);
            this.L_TotalInv_Inicial.Name = "L_TotalInv_Inicial";
            this.L_TotalInv_Inicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalInv_Inicial.SizeF = new System.Drawing.SizeF(66.73407F, 14.5F);
            this.L_TotalInv_Inicial.StylePriority.UseFont = false;
            this.L_TotalInv_Inicial.StylePriority.UseTextAlignment = false;
            this.L_TotalInv_Inicial.Text = "Inv_Inicial";
            this.L_TotalInv_Inicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalDescargas
            // 
            this.L_TotalDescargas.Dpi = 100F;
            this.L_TotalDescargas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalDescargas.LocationFloat = new DevExpress.Utils.PointFloat(686.655F, 0F);
            this.L_TotalDescargas.Name = "L_TotalDescargas";
            this.L_TotalDescargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalDescargas.SizeF = new System.Drawing.SizeF(67.75006F, 14.5F);
            this.L_TotalDescargas.StylePriority.UseFont = false;
            this.L_TotalDescargas.StylePriority.UseTextAlignment = false;
            this.L_TotalDescargas.Text = "Descargas";
            this.L_TotalDescargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalRecargas
            // 
            this.L_TotalRecargas.Dpi = 100F;
            this.L_TotalRecargas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalRecargas.LocationFloat = new DevExpress.Utils.PointFloat(386.96F, 0F);
            this.L_TotalRecargas.Name = "L_TotalRecargas";
            this.L_TotalRecargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalRecargas.SizeF = new System.Drawing.SizeF(58.25003F, 14.5F);
            this.L_TotalRecargas.StylePriority.UseFont = false;
            this.L_TotalRecargas.StylePriority.UseTextAlignment = false;
            this.L_TotalRecargas.Text = "Recargas";
            this.L_TotalRecargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalPromo
            // 
            this.L_TotalPromo.Dpi = 100F;
            this.L_TotalPromo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalPromo.LocationFloat = new DevExpress.Utils.PointFloat(824.3685F, 0F);
            this.L_TotalPromo.Name = "L_TotalPromo";
            this.L_TotalPromo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalPromo.SizeF = new System.Drawing.SizeF(44.14435F, 14.5F);
            this.L_TotalPromo.StylePriority.UseFont = false;
            this.L_TotalPromo.StylePriority.UseTextAlignment = false;
            this.L_TotalPromo.Text = "Promo";
            this.L_TotalPromo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalImporte
            // 
            this.L_TotalImporte.Dpi = 100F;
            this.L_TotalImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalImporte.LocationFloat = new DevExpress.Utils.PointFloat(868.8253F, 0F);
            this.L_TotalImporte.Name = "L_TotalImporte";
            this.L_TotalImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 3, 0, 0, 100F);
            this.L_TotalImporte.SizeF = new System.Drawing.SizeF(94.57971F, 14.5F);
            this.L_TotalImporte.StylePriority.UseFont = false;
            this.L_TotalImporte.StylePriority.UsePadding = false;
            this.L_TotalImporte.StylePriority.UseTextAlignment = false;
            this.L_TotalImporte.Text = "Importe";
            this.L_TotalImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_TotalInv_Final
            // 
            this.L_TotalInv_Final.Dpi = 100F;
            this.L_TotalInv_Final.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalInv_Final.LocationFloat = new DevExpress.Utils.PointFloat(963.405F, 0F);
            this.L_TotalInv_Final.Name = "L_TotalInv_Final";
            this.L_TotalInv_Final.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalInv_Final.SizeF = new System.Drawing.SizeF(63.96338F, 14.5F);
            this.L_TotalInv_Final.StylePriority.UseFont = false;
            this.L_TotalInv_Final.StylePriority.UseTextAlignment = false;
            this.L_TotalInv_Final.Text = "Inv_Final";
            this.L_TotalInv_Final.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // VentasContado
            // 
            this.VentasContado.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2,
            this.ReportHeader1,
            this.ReportFooter1});
            this.VentasContado.Dpi = 100F;
            this.VentasContado.Level = 1;
            this.VentasContado.Name = "VentasContado";
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_Venta1,
            this.L_Cliente1,
            this.L_Promo1,
            this.L_Importe1,
            this.L_Fecha1});
            this.Detail2.Dpi = 100F;
            this.Detail2.HeightF = 14.5F;
            this.Detail2.Name = "Detail2";
            // 
            // L_Venta1
            // 
            this.L_Venta1.Dpi = 100F;
            this.L_Venta1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Venta1.LocationFloat = new DevExpress.Utils.PointFloat(0.556579F, 0F);
            this.L_Venta1.Name = "L_Venta1";
            this.L_Venta1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Venta1.SizeF = new System.Drawing.SizeF(110.4984F, 14.5F);
            this.L_Venta1.StylePriority.UseFont = false;
            this.L_Venta1.StylePriority.UseTextAlignment = false;
            this.L_Venta1.Text = "Venta";
            this.L_Venta1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Cliente1
            // 
            this.L_Cliente1.CanGrow = false;
            this.L_Cliente1.Dpi = 100F;
            this.L_Cliente1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Cliente1.LocationFloat = new DevExpress.Utils.PointFloat(266.2112F, 0F);
            this.L_Cliente1.Name = "L_Cliente1";
            this.L_Cliente1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Cliente1.SizeF = new System.Drawing.SizeF(478.4845F, 14.5F);
            this.L_Cliente1.StylePriority.UseFont = false;
            this.L_Cliente1.StylePriority.UseTextAlignment = false;
            this.L_Cliente1.Text = "Cliente";
            this.L_Cliente1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Promo1
            // 
            this.L_Promo1.Dpi = 100F;
            this.L_Promo1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Promo1.LocationFloat = new DevExpress.Utils.PointFloat(744.6957F, 0F);
            this.L_Promo1.Name = "L_Promo1";
            this.L_Promo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Promo1.SizeF = new System.Drawing.SizeF(97.54541F, 14.5F);
            this.L_Promo1.StylePriority.UseFont = false;
            this.L_Promo1.StylePriority.UseTextAlignment = false;
            this.L_Promo1.Text = "Promo";
            this.L_Promo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Importe1
            // 
            this.L_Importe1.Dpi = 100F;
            this.L_Importe1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Importe1.LocationFloat = new DevExpress.Utils.PointFloat(842.2411F, 0F);
            this.L_Importe1.Name = "L_Importe1";
            this.L_Importe1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_Importe1.SizeF = new System.Drawing.SizeF(112.1099F, 14.5F);
            this.L_Importe1.StylePriority.UseFont = false;
            this.L_Importe1.StylePriority.UsePadding = false;
            this.L_Importe1.StylePriority.UseTextAlignment = false;
            this.L_Importe1.Text = "Importe";
            this.L_Importe1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Fecha1
            // 
            this.L_Fecha1.Dpi = 100F;
            this.L_Fecha1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Fecha1.LocationFloat = new DevExpress.Utils.PointFloat(111.2113F, 0F);
            this.L_Fecha1.Name = "L_Fecha1";
            this.L_Fecha1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Fecha1.SizeF = new System.Drawing.SizeF(154.8437F, 14.5F);
            this.L_Fecha1.StylePriority.UseFont = false;
            this.L_Fecha1.StylePriority.UseTextAlignment = false;
            this.L_Fecha1.Text = "Fecha";
            this.L_Fecha1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportHeader1
            // 
            this.ReportHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.xrLine1,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel37,
            this.xrLine2,
            this.xrLabel38,
            this.xrLabel39});
            this.ReportHeader1.Dpi = 100F;
            this.ReportHeader1.HeightF = 68.79843F;
            this.ReportHeader1.Name = "ReportHeader1";
            // 
            // xrLabel29
            // 
            this.xrLabel29.CanGrow = false;
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(0.556469F, 30.88848F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(110.4985F, 32.00001F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UsePadding = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "Venta";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.1563357F, 62.88843F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine1.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel34
            // 
            this.xrLabel34.CanGrow = false;
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(744.5394F, 30.88848F);
            this.xrLabel34.Multiline = true;
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(97.70166F, 32F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UsePadding = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "Promo";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel35
            // 
            this.xrLabel35.CanGrow = false;
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(842.2411F, 30.88848F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(111.9536F, 32F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UsePadding = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "Importe";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel37
            // 
            this.xrLabel37.CanGrow = false;
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(266.2112F, 30.88848F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(478.3282F, 32.00001F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UsePadding = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "Cliente";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0.1563357F, 24.97636F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine2.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel38
            // 
            this.xrLabel38.CanGrow = false;
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(111.055F, 30.88848F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(155F, 32F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UsePadding = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "Fecha";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(0.1563357F, 0.4997923F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(188.3307F, 13F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UsePadding = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "Ventas Contado";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter1
            // 
            this.ReportFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel25,
            this.L_TotalContado1});
            this.ReportFooter1.Dpi = 100F;
            this.ReportFooter1.HeightF = 24.41586F;
            this.ReportFooter1.Name = "ReportFooter1";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(402.971F, 0F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(341.5684F, 14.5F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UsePadding = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Total de Ventas de Contado";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_TotalContado1
            // 
            this.L_TotalContado1.Dpi = 100F;
            this.L_TotalContado1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalContado1.LocationFloat = new DevExpress.Utils.PointFloat(842.2411F, 0F);
            this.L_TotalContado1.Name = "L_TotalContado1";
            this.L_TotalContado1.NullValueText = "0";
            this.L_TotalContado1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_TotalContado1.SizeF = new System.Drawing.SizeF(111.9536F, 14.5F);
            this.L_TotalContado1.StylePriority.UseFont = false;
            this.L_TotalContado1.StylePriority.UsePadding = false;
            this.L_TotalContado1.StylePriority.UseTextAlignment = false;
            this.L_TotalContado1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // VentasCredito
            // 
            this.VentasCredito.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail3,
            this.ReportHeader2,
            this.ReportFooter2});
            this.VentasCredito.Dpi = 100F;
            this.VentasCredito.Level = 2;
            this.VentasCredito.Name = "VentasCredito";
            // 
            // Detail3
            // 
            this.Detail3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_Fecha2,
            this.L_Importe2,
            this.L_Promo2,
            this.L_Cliente2,
            this.L_Venta2});
            this.Detail3.Dpi = 100F;
            this.Detail3.HeightF = 14.5F;
            this.Detail3.Name = "Detail3";
            // 
            // L_Fecha2
            // 
            this.L_Fecha2.Dpi = 100F;
            this.L_Fecha2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Fecha2.LocationFloat = new DevExpress.Utils.PointFloat(111.3675F, 0F);
            this.L_Fecha2.Name = "L_Fecha2";
            this.L_Fecha2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Fecha2.SizeF = new System.Drawing.SizeF(154.6875F, 14.5F);
            this.L_Fecha2.StylePriority.UseFont = false;
            this.L_Fecha2.StylePriority.UseTextAlignment = false;
            this.L_Fecha2.Text = "Fecha";
            this.L_Fecha2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Importe2
            // 
            this.L_Importe2.Dpi = 100F;
            this.L_Importe2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Importe2.LocationFloat = new DevExpress.Utils.PointFloat(842.2411F, 0F);
            this.L_Importe2.Name = "L_Importe2";
            this.L_Importe2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_Importe2.SizeF = new System.Drawing.SizeF(112.2662F, 14.5F);
            this.L_Importe2.StylePriority.UseFont = false;
            this.L_Importe2.StylePriority.UsePadding = false;
            this.L_Importe2.StylePriority.UseTextAlignment = false;
            this.L_Importe2.Text = "Importe";
            this.L_Importe2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Promo2
            // 
            this.L_Promo2.Dpi = 100F;
            this.L_Promo2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Promo2.LocationFloat = new DevExpress.Utils.PointFloat(744.8519F, 0F);
            this.L_Promo2.Name = "L_Promo2";
            this.L_Promo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Promo2.SizeF = new System.Drawing.SizeF(97.38922F, 14.5F);
            this.L_Promo2.StylePriority.UseFont = false;
            this.L_Promo2.StylePriority.UseTextAlignment = false;
            this.L_Promo2.Text = "Promo";
            this.L_Promo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Cliente2
            // 
            this.L_Cliente2.CanGrow = false;
            this.L_Cliente2.Dpi = 100F;
            this.L_Cliente2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Cliente2.LocationFloat = new DevExpress.Utils.PointFloat(266.5238F, 0F);
            this.L_Cliente2.Name = "L_Cliente2";
            this.L_Cliente2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Cliente2.SizeF = new System.Drawing.SizeF(478.0157F, 14.5F);
            this.L_Cliente2.StylePriority.UseFont = false;
            this.L_Cliente2.StylePriority.UseTextAlignment = false;
            this.L_Cliente2.Text = "Cliente";
            this.L_Cliente2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.L_Cliente2.WordWrap = false;
            // 
            // L_Venta2
            // 
            this.L_Venta2.Dpi = 100F;
            this.L_Venta2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Venta2.LocationFloat = new DevExpress.Utils.PointFloat(0.4003231F, 0F);
            this.L_Venta2.Name = "L_Venta2";
            this.L_Venta2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Venta2.SizeF = new System.Drawing.SizeF(110.6547F, 14.5F);
            this.L_Venta2.StylePriority.UseFont = false;
            this.L_Venta2.StylePriority.UseTextAlignment = false;
            this.L_Venta2.Text = "Venta";
            this.L_Venta2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeader2
            // 
            this.ReportHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel17,
            this.xrLine5,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLine6,
            this.xrLabel21});
            this.ReportHeader2.Dpi = 100F;
            this.ReportHeader2.HeightF = 69.34669F;
            this.ReportHeader2.Name = "ReportHeader2";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.048038F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(188.3307F, 13F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UsePadding = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Ventas Crédito";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.CanGrow = false;
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(111.2113F, 31.4367F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(154.8437F, 31.99999F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UsePadding = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Fecha";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.52461F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine5.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.CanGrow = false;
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(266.3675F, 31.4367F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(478.1719F, 32F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UsePadding = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Cliente";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.CanGrow = false;
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(842.2411F, 31.4367F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(112.1098F, 32F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UsePadding = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Importe";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.CanGrow = false;
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(744.6957F, 31.43461F);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(97.54541F, 32F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UsePadding = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Promo";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine6
            // 
            this.xrLine6.Dpi = 100F;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 63.43668F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine6.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel21
            // 
            this.xrLabel21.CanGrow = false;
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(0.4002131F, 31.4367F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(110.6548F, 32F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Venta";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter2
            // 
            this.ReportFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_TotalCredito2,
            this.xrLabel24});
            this.ReportFooter2.Dpi = 100F;
            this.ReportFooter2.HeightF = 23.51442F;
            this.ReportFooter2.Name = "ReportFooter2";
            // 
            // L_TotalCredito2
            // 
            this.L_TotalCredito2.Dpi = 100F;
            this.L_TotalCredito2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalCredito2.LocationFloat = new DevExpress.Utils.PointFloat(842.2411F, 0F);
            this.L_TotalCredito2.Name = "L_TotalCredito2";
            this.L_TotalCredito2.NullValueText = "0";
            this.L_TotalCredito2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_TotalCredito2.SizeF = new System.Drawing.SizeF(111.9536F, 14.5F);
            this.L_TotalCredito2.StylePriority.UseFont = false;
            this.L_TotalCredito2.StylePriority.UsePadding = false;
            this.L_TotalCredito2.StylePriority.UseTextAlignment = false;
            this.L_TotalCredito2.Text = "Importe";
            this.L_TotalCredito2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(402.971F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(341.5684F, 14.5F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UsePadding = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Total de Ventas de Crédito";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Cobranza
            // 
            this.Cobranza.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail4,
            this.ReportHeader3,
            this.ReportFooter3});
            this.Cobranza.Dpi = 100F;
            this.Cobranza.Level = 3;
            this.Cobranza.Name = "Cobranza";
            this.Cobranza.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // Detail4
            // 
            this.Detail4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_ClienteCobranza,
            this.L_FechaCobranza,
            this.L_FormaPagoCobranza,
            this.L_ReferenciaCobranza,
            this.L_ImporteVtaCobranza,
            this.L_SaldoCobranza,
            this.L_VentaCobranza,
            this.L_ImporteCobranza});
            this.Detail4.Dpi = 100F;
            this.Detail4.HeightF = 14.94847F;
            this.Detail4.Name = "Detail4";
            // 
            // L_ClienteCobranza
            // 
            this.L_ClienteCobranza.Dpi = 100F;
            this.L_ClienteCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ClienteCobranza.LocationFloat = new DevExpress.Utils.PointFloat(0.9047435F, 0F);
            this.L_ClienteCobranza.Name = "L_ClienteCobranza";
            this.L_ClienteCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_ClienteCobranza.SizeF = new System.Drawing.SizeF(319.0712F, 14.5F);
            this.L_ClienteCobranza.StylePriority.UseFont = false;
            this.L_ClienteCobranza.StylePriority.UseTextAlignment = false;
            this.L_ClienteCobranza.Text = "Cliente";
            this.L_ClienteCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_FechaCobranza
            // 
            this.L_FechaCobranza.Dpi = 100F;
            this.L_FechaCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FechaCobranza.LocationFloat = new DevExpress.Utils.PointFloat(410.1321F, 0F);
            this.L_FechaCobranza.Name = "L_FechaCobranza";
            this.L_FechaCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_FechaCobranza.SizeF = new System.Drawing.SizeF(149.8438F, 14.5F);
            this.L_FechaCobranza.StylePriority.UseFont = false;
            this.L_FechaCobranza.StylePriority.UseTextAlignment = false;
            this.L_FechaCobranza.Text = "Fecha";
            this.L_FechaCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_FormaPagoCobranza
            // 
            this.L_FormaPagoCobranza.CanGrow = false;
            this.L_FormaPagoCobranza.Dpi = 100F;
            this.L_FormaPagoCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FormaPagoCobranza.LocationFloat = new DevExpress.Utils.PointFloat(734.9759F, 0.4484653F);
            this.L_FormaPagoCobranza.Name = "L_FormaPagoCobranza";
            this.L_FormaPagoCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_FormaPagoCobranza.SizeF = new System.Drawing.SizeF(83.15631F, 14.5F);
            this.L_FormaPagoCobranza.StylePriority.UseFont = false;
            this.L_FormaPagoCobranza.StylePriority.UseTextAlignment = false;
            this.L_FormaPagoCobranza.Text = "Forma Pago";
            this.L_FormaPagoCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_ReferenciaCobranza
            // 
            this.L_ReferenciaCobranza.CanGrow = false;
            this.L_ReferenciaCobranza.Dpi = 100F;
            this.L_ReferenciaCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ReferenciaCobranza.LocationFloat = new DevExpress.Utils.PointFloat(818.1322F, 0F);
            this.L_ReferenciaCobranza.Name = "L_ReferenciaCobranza";
            this.L_ReferenciaCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_ReferenciaCobranza.SizeF = new System.Drawing.SizeF(99.84363F, 14.5F);
            this.L_ReferenciaCobranza.StylePriority.UseFont = false;
            this.L_ReferenciaCobranza.StylePriority.UseTextAlignment = false;
            this.L_ReferenciaCobranza.Text = "Referencia";
            this.L_ReferenciaCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_ImporteVtaCobranza
            // 
            this.L_ImporteVtaCobranza.Dpi = 100F;
            this.L_ImporteVtaCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ImporteVtaCobranza.LocationFloat = new DevExpress.Utils.PointFloat(559.9759F, 0F);
            this.L_ImporteVtaCobranza.Name = "L_ImporteVtaCobranza";
            this.L_ImporteVtaCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_ImporteVtaCobranza.SizeF = new System.Drawing.SizeF(90.15625F, 14.5F);
            this.L_ImporteVtaCobranza.StylePriority.UseFont = false;
            this.L_ImporteVtaCobranza.StylePriority.UsePadding = false;
            this.L_ImporteVtaCobranza.StylePriority.UseTextAlignment = false;
            this.L_ImporteVtaCobranza.Text = "Importe Venta";
            this.L_ImporteVtaCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_SaldoCobranza
            // 
            this.L_SaldoCobranza.Dpi = 100F;
            this.L_SaldoCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SaldoCobranza.LocationFloat = new DevExpress.Utils.PointFloat(650.1323F, 0F);
            this.L_SaldoCobranza.Name = "L_SaldoCobranza";
            this.L_SaldoCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.L_SaldoCobranza.SizeF = new System.Drawing.SizeF(84.84363F, 14.5F);
            this.L_SaldoCobranza.StylePriority.UseFont = false;
            this.L_SaldoCobranza.StylePriority.UsePadding = false;
            this.L_SaldoCobranza.StylePriority.UseTextAlignment = false;
            this.L_SaldoCobranza.Text = "Saldo";
            this.L_SaldoCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_VentaCobranza
            // 
            this.L_VentaCobranza.Dpi = 100F;
            this.L_VentaCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VentaCobranza.LocationFloat = new DevExpress.Utils.PointFloat(320.1322F, 0F);
            this.L_VentaCobranza.Name = "L_VentaCobranza";
            this.L_VentaCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VentaCobranza.SizeF = new System.Drawing.SizeF(89.84375F, 14.5F);
            this.L_VentaCobranza.StylePriority.UseFont = false;
            this.L_VentaCobranza.StylePriority.UseTextAlignment = false;
            this.L_VentaCobranza.Text = "Venta";
            this.L_VentaCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_ImporteCobranza
            // 
            this.L_ImporteCobranza.Dpi = 100F;
            this.L_ImporteCobranza.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ImporteCobranza.LocationFloat = new DevExpress.Utils.PointFloat(917.976F, 0F);
            this.L_ImporteCobranza.Name = "L_ImporteCobranza";
            this.L_ImporteCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 3, 0, 0, 100F);
            this.L_ImporteCobranza.SizeF = new System.Drawing.SizeF(70.31256F, 14.5F);
            this.L_ImporteCobranza.StylePriority.UseFont = false;
            this.L_ImporteCobranza.StylePriority.UsePadding = false;
            this.L_ImporteCobranza.StylePriority.UseTextAlignment = false;
            this.L_ImporteCobranza.Text = "Importe";
            this.L_ImporteCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader3
            // 
            this.ReportHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel23,
            this.xrLine7,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel36,
            this.xrLabel40,
            this.xrLine8,
            this.xrLabel42,
            this.xrLabel43});
            this.ReportHeader3.Dpi = 100F;
            this.ReportHeader3.HeightF = 63.13167F;
            this.ReportHeader3.Name = "ReportHeader3";
            // 
            // xrLabel23
            // 
            this.xrLabel23.CanGrow = false;
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(319.9759F, 25.22168F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(90F, 32F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UsePadding = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Venta";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine7
            // 
            this.xrLine7.Dpi = 100F;
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(0.1563688F, 57.22167F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine7.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel30
            // 
            this.xrLabel30.CanGrow = false;
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(817.9759F, 25.22168F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(100F, 32F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UsePadding = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "Referencia";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.CanGrow = false;
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(917.976F, 25.22168F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(70F, 32F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UsePadding = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Importe";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.CanGrow = false;
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(649.976F, 25.22168F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(85F, 32F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UsePadding = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Saldo";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel33
            // 
            this.xrLabel33.CanGrow = false;
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(409.9759F, 25.22168F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(150F, 32F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UsePadding = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Fecha";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel36
            // 
            this.xrLabel36.CanGrow = false;
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(559.9759F, 25.22168F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(90F, 32F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UsePadding = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "Importe Venta";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel40
            // 
            this.xrLabel40.CanGrow = false;
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(734.9759F, 25.22168F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(83F, 32F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UsePadding = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "Forma Pago";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine8
            // 
            this.xrLine8.Dpi = 100F;
            this.xrLine8.LocationFloat = new DevExpress.Utils.PointFloat(0.1562338F, 19.30952F);
            this.xrLine8.Name = "xrLine8";
            this.xrLine8.SizeF = new System.Drawing.SizeF(1025F, 5.91F);
            this.xrLine8.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel42
            // 
            this.xrLabel42.CanGrow = false;
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(1.505228F, 25.22168F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(318.4707F, 31.99999F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UsePadding = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "Cliente";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(0.1562338F, 0F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(188.3307F, 13F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UsePadding = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "Cobranza";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter3
            // 
            this.ReportFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22,
            this.L_TotalCobranza3});
            this.ReportFooter3.Dpi = 100F;
            this.ReportFooter3.HeightF = 23.51442F;
            this.ReportFooter3.Name = "ReportFooter3";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(402.971F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 15, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(341.5684F, 14.5F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UsePadding = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Total de Cobranza";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_TotalCobranza3
            // 
            this.L_TotalCobranza3.Dpi = 100F;
            this.L_TotalCobranza3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalCobranza3.LocationFloat = new DevExpress.Utils.PointFloat(917.976F, 0F);
            this.L_TotalCobranza3.Name = "L_TotalCobranza3";
            this.L_TotalCobranza3.NullValueText = "0";
            this.L_TotalCobranza3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalCobranza3.SizeF = new System.Drawing.SizeF(70.15631F, 14.5F);
            this.L_TotalCobranza3.StylePriority.UseFont = false;
            this.L_TotalCobranza3.StylePriority.UseTextAlignment = false;
            this.L_TotalCobranza3.Text = "Importe";
            this.L_TotalCobranza3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PreLiquidacion
            // 
            this.PreLiquidacion.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail5});
            this.PreLiquidacion.Dpi = 100F;
            this.PreLiquidacion.Level = 4;
            this.PreLiquidacion.Name = "PreLiquidacion";
            // 
            // Detail5
            // 
            this.Detail5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_LiquidarPre,
            this.L_CobranzaPre,
            this.L_VtaContadoPre,
            this.xrLine16,
            this.xrLine17,
            this.footerVendedor,
            this.footerCedi,
            this.xrLabel26,
            this.xrLabel27,
            this.xrLabel28,
            this.xrLabel41,
            this.xrLabel47,
            this.xrLabel49,
            this.xrLabel50,
            this.xrLabel51,
            this.xrLabel52,
            this.xrLabel53,
            this.xrLabel54,
            this.xrLabel55,
            this.L_VtaTotalPre,
            this.L_VtaCreditoPre,
            this.L_PromocionPre,
            this.L_DevolucionesPre});
            this.Detail5.Dpi = 100F;
            this.Detail5.HeightF = 402.832F;
            this.Detail5.Name = "Detail5";
            // 
            // L_LiquidarPre
            // 
            this.L_LiquidarPre.Dpi = 100F;
            this.L_LiquidarPre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_LiquidarPre.LocationFloat = new DevExpress.Utils.PointFloat(204.5638F, 138.2094F);
            this.L_LiquidarPre.Name = "L_LiquidarPre";
            this.L_LiquidarPre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_LiquidarPre.SizeF = new System.Drawing.SizeF(85F, 14.5F);
            this.L_LiquidarPre.StylePriority.UseFont = false;
            this.L_LiquidarPre.StylePriority.UseTextAlignment = false;
            this.L_LiquidarPre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_CobranzaPre
            // 
            this.L_CobranzaPre.Dpi = 100F;
            this.L_CobranzaPre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CobranzaPre.LocationFloat = new DevExpress.Utils.PointFloat(204.5638F, 94.70932F);
            this.L_CobranzaPre.Name = "L_CobranzaPre";
            this.L_CobranzaPre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_CobranzaPre.SizeF = new System.Drawing.SizeF(85F, 14.5F);
            this.L_CobranzaPre.StylePriority.UseFont = false;
            this.L_CobranzaPre.StylePriority.UseTextAlignment = false;
            this.L_CobranzaPre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_VtaContadoPre
            // 
            this.L_VtaContadoPre.Dpi = 100F;
            this.L_VtaContadoPre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VtaContadoPre.LocationFloat = new DevExpress.Utils.PointFloat(204.5638F, 80.20933F);
            this.L_VtaContadoPre.Name = "L_VtaContadoPre";
            this.L_VtaContadoPre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VtaContadoPre.SizeF = new System.Drawing.SizeF(85F, 14.5F);
            this.L_VtaContadoPre.StylePriority.UseFont = false;
            this.L_VtaContadoPre.StylePriority.UseTextAlignment = false;
            this.L_VtaContadoPre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine16
            // 
            this.xrLine16.Dpi = 100F;
            this.xrLine16.LocationFloat = new DevExpress.Utils.PointFloat(176.916F, 371.4988F);
            this.xrLine16.Name = "xrLine16";
            this.xrLine16.SizeF = new System.Drawing.SizeF(305.875F, 6.33334F);
            // 
            // xrLine17
            // 
            this.xrLine17.Dpi = 100F;
            this.xrLine17.LocationFloat = new DevExpress.Utils.PointFloat(583.983F, 371.4988F);
            this.xrLine17.Name = "xrLine17";
            this.xrLine17.SizeF = new System.Drawing.SizeF(305.875F, 6.33334F);
            // 
            // footerVendedor
            // 
            this.footerVendedor.Dpi = 100F;
            this.footerVendedor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(176.4576F, 377.832F);
            this.footerVendedor.Name = "footerVendedor";
            this.footerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.footerVendedor.SizeF = new System.Drawing.SizeF(306.3333F, 15.00009F);
            this.footerVendedor.StylePriority.UseFont = false;
            this.footerVendedor.StylePriority.UseTextAlignment = false;
            this.footerVendedor.Text = "Vendedor";
            this.footerVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // footerCedi
            // 
            this.footerCedi.Dpi = 100F;
            this.footerCedi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footerCedi.LocationFloat = new DevExpress.Utils.PointFloat(583.5248F, 377.832F);
            this.footerCedi.Name = "footerCedi";
            this.footerCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.footerCedi.SizeF = new System.Drawing.SizeF(306.3333F, 15.00009F);
            this.footerCedi.StylePriority.UseFont = false;
            this.footerCedi.StylePriority.UseTextAlignment = false;
            this.footerCedi.Text = "Recibió";
            this.footerCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(0F, 21.63461F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(188.3307F, 13F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UsePadding = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "Pre-Liquidación";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(31.18669F, 51.20934F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(145.2708F, 14.5F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Venta Total";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(31.18669F, 65.70934F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(145.2708F, 14.5F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Ventas Crédito";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(31.18669F, 80.20933F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(145.2708F, 14.5F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "Ventas Contado";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel47
            // 
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(31.18669F, 94.70932F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(145.2708F, 14.5F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "Cobranza Crédito";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Dpi = 100F;
            this.xrLabel49.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(31.18669F, 109.2094F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(145.2708F, 14.5F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "PROMOCIÓN";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel50
            // 
            this.xrLabel50.Dpi = 100F;
            this.xrLabel50.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(31.18669F, 123.7094F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(145.2708F, 14.5F);
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            this.xrLabel50.Text = "Devoluciones y Cambios";
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Dpi = 100F;
            this.xrLabel51.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(31.18669F, 138.2094F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(145.2708F, 14.49999F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "Total a Liquidar";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(176.4576F, 51.20934F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(17.69348F, 14.5F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "+";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Dpi = 100F;
            this.xrLabel53.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(176.4576F, 65.70934F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(17.69348F, 14.5F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "-";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel54
            // 
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(176.4576F, 80.20933F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(17.69348F, 14.5F);
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.Text = "=";
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel55
            // 
            this.xrLabel55.Dpi = 100F;
            this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(176.4576F, 94.70932F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(17.69348F, 14.5F);
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = "+";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_VtaTotalPre
            // 
            this.L_VtaTotalPre.Dpi = 100F;
            this.L_VtaTotalPre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VtaTotalPre.LocationFloat = new DevExpress.Utils.PointFloat(204.5636F, 51.20934F);
            this.L_VtaTotalPre.Name = "L_VtaTotalPre";
            this.L_VtaTotalPre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VtaTotalPre.SizeF = new System.Drawing.SizeF(85F, 14.5F);
            this.L_VtaTotalPre.StylePriority.UseFont = false;
            this.L_VtaTotalPre.StylePriority.UseTextAlignment = false;
            this.L_VtaTotalPre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_VtaCreditoPre
            // 
            this.L_VtaCreditoPre.Dpi = 100F;
            this.L_VtaCreditoPre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VtaCreditoPre.LocationFloat = new DevExpress.Utils.PointFloat(204.5636F, 65.70934F);
            this.L_VtaCreditoPre.Name = "L_VtaCreditoPre";
            this.L_VtaCreditoPre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VtaCreditoPre.SizeF = new System.Drawing.SizeF(85F, 14.5F);
            this.L_VtaCreditoPre.StylePriority.UseFont = false;
            this.L_VtaCreditoPre.StylePriority.UseTextAlignment = false;
            this.L_VtaCreditoPre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_PromocionPre
            // 
            this.L_PromocionPre.Dpi = 100F;
            this.L_PromocionPre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_PromocionPre.LocationFloat = new DevExpress.Utils.PointFloat(204.5636F, 109.2094F);
            this.L_PromocionPre.Name = "L_PromocionPre";
            this.L_PromocionPre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_PromocionPre.SizeF = new System.Drawing.SizeF(85F, 14.5F);
            this.L_PromocionPre.StylePriority.UseFont = false;
            this.L_PromocionPre.StylePriority.UseTextAlignment = false;
            this.L_PromocionPre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_DevolucionesPre
            // 
            this.L_DevolucionesPre.Dpi = 100F;
            this.L_DevolucionesPre.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DevolucionesPre.LocationFloat = new DevExpress.Utils.PointFloat(204.5636F, 123.7094F);
            this.L_DevolucionesPre.Name = "L_DevolucionesPre";
            this.L_DevolucionesPre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_DevolucionesPre.SizeF = new System.Drawing.SizeF(85F, 14.5F);
            this.L_DevolucionesPre.StylePriority.UseFont = false;
            this.L_DevolucionesPre.StylePriority.UseTextAlignment = false;
            this.L_DevolucionesPre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrLabel56,
            this.xrPageInfo1});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 17.58333F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} / {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(707F, 5F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(312.9999F, 12.58333F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UsePadding = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel56
            // 
            this.xrLabel56.Dpi = 100F;
            this.xrLabel56.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(1.19F, 5F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(109.8623F, 12.58333F);
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.StylePriority.UsePadding = false;
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            this.xrLabel56.Text = "Fecha Hora Impresión";
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "{0:dddd, d\' de \'MMMM\' de \'yyyy hh:mm:ss tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(114.83F, 5F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(238.1063F, 12.58333F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeaderVendedor
            // 
            this.GroupHeaderVendedor.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_Gpo_VendedorID,
            this.L_Gpo_VendedorNom,
            this.xrLabel1});
            this.GroupHeaderVendedor.Dpi = 100F;
            this.GroupHeaderVendedor.HeightF = 31.74998F;
            this.GroupHeaderVendedor.Name = "GroupHeaderVendedor";
            // 
            // L_Gpo_VendedorID
            // 
            this.L_Gpo_VendedorID.Dpi = 100F;
            this.L_Gpo_VendedorID.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Gpo_VendedorID.LocationFloat = new DevExpress.Utils.PointFloat(71.79693F, 0F);
            this.L_Gpo_VendedorID.Name = "L_Gpo_VendedorID";
            this.L_Gpo_VendedorID.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.L_Gpo_VendedorID.SizeF = new System.Drawing.SizeF(86.91797F, 13F);
            this.L_Gpo_VendedorID.StylePriority.UseFont = false;
            this.L_Gpo_VendedorID.StylePriority.UsePadding = false;
            this.L_Gpo_VendedorID.StylePriority.UseTextAlignment = false;
            this.L_Gpo_VendedorID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Gpo_VendedorNom
            // 
            this.L_Gpo_VendedorNom.Dpi = 100F;
            this.L_Gpo_VendedorNom.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Gpo_VendedorNom.LocationFloat = new DevExpress.Utils.PointFloat(158.7149F, 0F);
            this.L_Gpo_VendedorNom.Name = "L_Gpo_VendedorNom";
            this.L_Gpo_VendedorNom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.L_Gpo_VendedorNom.SizeF = new System.Drawing.SizeF(471.8339F, 13F);
            this.L_Gpo_VendedorNom.StylePriority.UseFont = false;
            this.L_Gpo_VendedorNom.StylePriority.UsePadding = false;
            this.L_Gpo_VendedorNom.StylePriority.UseTextAlignment = false;
            this.L_Gpo_VendedorNom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1.058833F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(62.40644F, 13F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Vendedor";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel44
            // 
            this.xrLabel44.CanGrow = false;
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(494.96F, 25.24404F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(50F, 32F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UsePadding = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.Text = "CS";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_CambiosSal
            // 
            this.L_CambiosSal.CanGrow = false;
            this.L_CambiosSal.Dpi = 100F;
            this.L_CambiosSal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CambiosSal.LocationFloat = new DevExpress.Utils.PointFloat(495.4599F, 0F);
            this.L_CambiosSal.Name = "L_CambiosSal";
            this.L_CambiosSal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_CambiosSal.SizeF = new System.Drawing.SizeF(49.50012F, 14.5F);
            this.L_CambiosSal.StylePriority.UseFont = false;
            this.L_CambiosSal.StylePriority.UseTextAlignment = false;
            this.L_CambiosSal.Text = "Cambios";
            this.L_CambiosSal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalCambioSal
            // 
            this.L_TotalCambioSal.CanGrow = false;
            this.L_TotalCambioSal.Dpi = 100F;
            this.L_TotalCambioSal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalCambioSal.LocationFloat = new DevExpress.Utils.PointFloat(494.96F, 0F);
            this.L_TotalCambioSal.Name = "L_TotalCambioSal";
            this.L_TotalCambioSal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalCambioSal.SizeF = new System.Drawing.SizeF(49.75006F, 14.5F);
            this.L_TotalCambioSal.StylePriority.UseFont = false;
            this.L_TotalCambioSal.StylePriority.UseTextAlignment = false;
            this.L_TotalCambioSal.Text = "Cambios";
            this.L_TotalCambioSal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Rpt_Liquidacion
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.MovimientosProductos,
            this.VentasContado,
            this.VentasCredito,
            this.Cobranza,
            this.PreLiquidacion,
            this.PageFooter,
            this.GroupHeaderVendedor});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(35, 35, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
