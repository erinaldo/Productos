using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class ReporteLiquidacionMOR2 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    public GroupHeaderBand groupHeaderVendedor;
    public DetailReportBand VentasProducto;
    private DetailBand Detail1;
    private XRLabel xrLabel13;
    private XRLine xrLine1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel2;
    private XRLabel xrLabel8;
    private XRLabel xrLabel15;
    private XRLabel xrLabel12;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLine xrLine2;
    private ReportHeaderBand ReportHeader;
    public XRLabel detalleClave;
    public XRLabel detalleDescripcion;
    public XRLabel detalleInventarioInicial;
    public XRLabel detalleRecargas;
    public XRLabel detalleDevoluciones;
    public XRLabel detallePromocion;
    public XRLabel detalleDescargas;
    public XRLabel detalleInventarioFinal;
    public XRLabel detalleVentas;
    public XRLabel detalleImporte;
    public DetailReportBand VentasContado;
    private DetailBand Detail2;
    public XRPictureBox xrPictureBox1;
    private XRLabel xrLabel27;
    public XRLabel direccionCedis;
    public XRLabel telefonoCedis;
    private XRLabel xrLabel20;
    public XRLabel headerFecha;
    private XRLabel xrLabel24;
    public XRLabel headerVendedor;
    private ReportFooterBand ReportFooter;
    public XRLabel totalInventarioInicial;
    public XRLabel totalRecargas;
    public XRLabel totalDevoluciones;
    public XRLabel totalPromocion;
    public XRLabel totalDescargas;
    public XRLabel totalInventarioFinal;
    public XRLabel totalVentas;
    public XRLabel totalImporte;
    private ReportHeaderBand ReportHeader1;
    private XRLabel xrLabel1;
    private XRLine xrLine3;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel18;
    private XRLine xrLine4;
    public XRLabel VContadoDetalleFactura;
    public XRLabel VContadoDetalleVenta;
    public XRLabel VContadoDetalleCliente;
    public XRLabel VContadoDetalleLitros;
    public XRLabel VContadoDetalleFecha;
    public XRLabel VContadoDetalleImporte;
    private ReportFooterBand ReportFooter1;
    public XRLabel VContadoTotalImporte;
    public DetailReportBand VentasCredito;
    private DetailBand Detail3;
    public XRLabel VCreditoDetalleVenta;
    public XRLabel VCreditoDetalleFactura;
    public XRLabel VCreditoDetalleFecha;
    public XRLabel VCreditoDetalleCliente;
    public XRLabel VCreditoDetalleLitros;
    public XRLabel VCreditoDetalleImporte;
    private ReportHeaderBand ReportHeader2;
    private XRLabel xrLabel19;
    private XRLine xrLine5;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLabel xrLabel28;
    private XRLine xrLine6;
    private ReportFooterBand ReportFooter2;
    public XRLabel VCreditoTotalImporte;
    public DetailReportBand CobranzaContado;
    private DetailBand Detail4;
    public XRLabel CContadoDetalleFolio;
    public XRLabel CContadoDetalleFactura;
    public XRLabel CContadoDetalleFechaFactura;
    public XRLabel CContadoDetalleCliente;
    public XRLabel CContadoDetalleImporte;
    public XRLabel CContadoDetalleFechaPago;
    private ReportHeaderBand ReportHeader3;
    private XRLabel xrLabel36;
    private XRLabel xrLabel29;
    private XRLine xrLine7;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLine xrLine8;
    private ReportFooterBand ReportFooter3;
    public XRLabel CContadoTotalImporte;
    private XRLabel xrLabel43;
    public DetailReportBand CobranzaCredito;
    private DetailBand Detail5;
    public XRLabel CCreditoDetalleFolio;
    public XRLabel CCreditoDetalleFactura;
    public XRLabel CCreditoDetalleFechaFactura;
    public XRLabel CCreditoDetalleCliente;
    public XRLabel CCreditoDetalleImporte;
    public XRLabel CCreditoDetalleFechaPago;
    private ReportHeaderBand ReportHeader4;
    private XRLabel xrLabel45;
    private ReportFooterBand ReportFooter4;
    private XRLabel xrLabel52;
    public XRLabel CCreditoTotalImporte;
    public DetailReportBand DesgloseEfectivoDocumentos;
    private DetailBand Detail6;
    private ReportHeaderBand ReportHeader5;
    private XRLabel xrLabel37;
    public XRLabel xrLabel38;
    public XRLabel xrLabel39;
    public XRLabel xrLabel40;
    public XRLabel DesgloseDetalleBanco;
    public XRLabel DesgloseDetalleReferencia;
    public XRLabel DesgloseDetalleFechaCobro;
    public XRLabel DesgloseDetalleImporte;
    public XRLabel DesgloseDetalleDenominacion;
    public XRLabel DesgloseDetalleCantidad;
    public XRLabel DesgloseDetalleTotal;
    public XRLabel xrLabel48;
    private XRLabel xrLabel41;
    public XRLabel xrLabel42;
    public XRLabel xrLabel46;
    public XRLabel xrLabel47;
    public DetailReportBand Kilometraje;
    private DetailBand Detail7;
    public XRLabel KDetalleRecorrido;
    public XRLabel KDetalleFinal;
    public XRLabel KDetalleInicial;
    private ReportHeaderBand ReportHeader6;
    public XRLabel xrLabel69;
    public XRLabel xrLabel70;
    public XRLabel xrLabel71;
    private XRLabel xrLabel68;
    public DetailReportBand Agendados;
    private DetailBand Detail8;
    private ReportHeaderBand ReportHeader7;
    public XRLabel xrLabel73;
    public XRLabel xrLabel74;
    private XRLine xrLine12;
    private XRLine xrLine13;
    private XRLabel xrLabel72;
    public XRLabel xrLabel83;
    public XRLabel xrLabel84;
    public XRLabel xrLabel85;
    public XRLabel AgendaRutaDetalleEficiencia;
    public XRLabel AgendaDetalleSinVenta;
    public XRLabel AgendaDetalleConVenta;
    public XRLabel AgendaDetalleEficiencia;
    public XRLabel AgendaDetalleNoVisitados;
    public XRLabel AgendaDetalleVisitados;
    public XRLabel AgendaDetalleClientes;
    public XRLabel xrLabel77;
    public XRLabel xrLabel78;
    public XRLabel xrLabel76;
    public XRLabel xrLabel75;
    public DetailReportBand NoAgendadosTiempos;
    private DetailBand Detail9;
    private ReportHeaderBand ReportHeader8;
    private XRLine xrLine14;
    public XRLabel xrLabel79;
    public XRLabel xrLabel80;
    private XRLine xrLine15;
    public XRLabel xrLabel81;
    public XRLabel NoAgendadosDetalleFueraRuta;
    public XRLabel NoAgendadosDetalleFueraRutaVenta;
    public XRLabel xrLabel87;
    public XRLabel xrLabel88;
    public XRLabel NoAgendadosDetalleEficiencia;
    public XRLabel TiemposDetalleTiempoTotal;
    public XRLabel TiemposDetalleTiempoVisita;
    public XRLabel xrLabel92;
    public XRLabel xrLabel93;
    public XRLabel TiemposDetalleTiempoTransito;
    public XRLabel xrLabel95;
    private ReportFooterBand ReportFooter6;
    public XRLabel footerCedi;
    public XRLabel footerVendedor;
    private XRLine xrLine17;
    private XRLine xrLine16;
    public DetailReportBand TotalCobranza;
    private DetailBand Detail10;
    private XRLabel xrLabel54;
    public XRLabel CCreditoTotalCobranza;
    public DetailReportBand TotalDesglose;
    private DetailBand Detail11;
    private XRLine xrLine9;
    public XRLabel xrLabel50;
    public XRLabel TotalImporteDocumentos;
    public XRLabel TotalesTotalCobranza;
    public XRLabel TotalesTotalEfectivo;
    public XRLabel xrLabel63;
    public XRLabel xrLabel60;
    private XRLine xrLine11;
    public XRLabel TotalesTotalDesglose;
    public XRLabel DesgloseEfectivoTotal;
    public XRLabel TotalesTotalDocumentos;
    public XRLabel xrLabel65;
    public XRLabel TotalesTotalContado;
    public XRLabel TotalesTotalCredito;
    private XRLine xrLine10;
    public XRLabel xrLabel67;
    public XRLabel xrLabel57;
    public XRLabel xrLabel56;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteLiquidacionMOR2()
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
            this.groupHeaderVendedor = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.direccionCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.telefonoCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.VentasProducto = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.detalleClave = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleDescripcion = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleInventarioInicial = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleRecargas = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleDevoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.detallePromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleDescargas = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleInventarioFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleVentas = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.totalInventarioInicial = new DevExpress.XtraReports.UI.XRLabel();
            this.totalRecargas = new DevExpress.XtraReports.UI.XRLabel();
            this.totalDevoluciones = new DevExpress.XtraReports.UI.XRLabel();
            this.totalPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.totalDescargas = new DevExpress.XtraReports.UI.XRLabel();
            this.totalInventarioFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.totalVentas = new DevExpress.XtraReports.UI.XRLabel();
            this.totalImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.VentasContado = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.VContadoDetalleFactura = new DevExpress.XtraReports.UI.XRLabel();
            this.VContadoDetalleVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.VContadoDetalleCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.VContadoDetalleLitros = new DevExpress.XtraReports.UI.XRLabel();
            this.VContadoDetalleFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.VContadoDetalleImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.ReportFooter1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.VContadoTotalImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.VentasCredito = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail3 = new DevExpress.XtraReports.UI.DetailBand();
            this.VCreditoDetalleVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.VCreditoDetalleFactura = new DevExpress.XtraReports.UI.XRLabel();
            this.VCreditoDetalleFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.VCreditoDetalleCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.VCreditoDetalleLitros = new DevExpress.XtraReports.UI.XRLabel();
            this.VCreditoDetalleImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader2 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.ReportFooter2 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.VCreditoTotalImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.CobranzaContado = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail4 = new DevExpress.XtraReports.UI.DetailBand();
            this.CContadoDetalleFolio = new DevExpress.XtraReports.UI.XRLabel();
            this.CContadoDetalleFactura = new DevExpress.XtraReports.UI.XRLabel();
            this.CContadoDetalleFechaFactura = new DevExpress.XtraReports.UI.XRLabel();
            this.CContadoDetalleCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.CContadoDetalleImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.CContadoDetalleFechaPago = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader3 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine8 = new DevExpress.XtraReports.UI.XRLine();
            this.ReportFooter3 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.CContadoTotalImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.CobranzaCredito = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail5 = new DevExpress.XtraReports.UI.DetailBand();
            this.CCreditoDetalleFolio = new DevExpress.XtraReports.UI.XRLabel();
            this.CCreditoDetalleFactura = new DevExpress.XtraReports.UI.XRLabel();
            this.CCreditoDetalleFechaFactura = new DevExpress.XtraReports.UI.XRLabel();
            this.CCreditoDetalleCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.CCreditoDetalleImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.CCreditoDetalleFechaPago = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader4 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.CCreditoTotalImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseEfectivoDocumentos = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail6 = new DevExpress.XtraReports.UI.DetailBand();
            this.DesgloseDetalleBanco = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseDetalleReferencia = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseDetalleFechaCobro = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseDetalleImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseDetalleDenominacion = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseDetalleCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseDetalleTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader5 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.Kilometraje = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail7 = new DevExpress.XtraReports.UI.DetailBand();
            this.KDetalleRecorrido = new DevExpress.XtraReports.UI.XRLabel();
            this.KDetalleFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.KDetalleInicial = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader6 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
            this.Agendados = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail8 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel85 = new DevExpress.XtraReports.UI.XRLabel();
            this.AgendaRutaDetalleEficiencia = new DevExpress.XtraReports.UI.XRLabel();
            this.AgendaDetalleSinVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.AgendaDetalleConVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.AgendaDetalleEficiencia = new DevExpress.XtraReports.UI.XRLabel();
            this.AgendaDetalleNoVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.AgendaDetalleVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.AgendaDetalleClientes = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel77 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel76 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader7 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine12 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine13 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
            this.NoAgendadosTiempos = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail9 = new DevExpress.XtraReports.UI.DetailBand();
            this.TiemposDetalleTiempoTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TiemposDetalleTiempoVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel92 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel93 = new DevExpress.XtraReports.UI.XRLabel();
            this.TiemposDetalleTiempoTransito = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel95 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
            this.NoAgendadosDetalleFueraRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.NoAgendadosDetalleFueraRutaVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.NoAgendadosDetalleEficiencia = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader8 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine14 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel80 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine15 = new DevExpress.XtraReports.UI.XRLine();
            this.ReportFooter6 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.footerCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.footerVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine17 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine16 = new DevExpress.XtraReports.UI.XRLine();
            this.TotalCobranza = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail10 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.CCreditoTotalCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalDesglose = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail11 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine9 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalImporteDocumentos = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalesTotalCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalesTotalEfectivo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine11 = new DevExpress.XtraReports.UI.XRLine();
            this.TotalesTotalDesglose = new DevExpress.XtraReports.UI.XRLabel();
            this.DesgloseEfectivoTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalesTotalDocumentos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalesTotalContado = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalesTotalCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine10 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.TopMargin.HeightF = 6F;
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
            this.BottomMargin.HeightF = 112F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "Fecha Hora Impresión: {0}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(516.9579F, 47.87496F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(294.25F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "{0} / {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(334.4846F, 47.87496F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(101.885F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // groupHeaderVendedor
            // 
            this.groupHeaderVendedor.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrLabel27,
            this.direccionCedis,
            this.telefonoCedis,
            this.xrLabel20,
            this.headerFecha,
            this.xrLabel24,
            this.headerVendedor});
            this.groupHeaderVendedor.Dpi = 100F;
            this.groupHeaderVendedor.HeightF = 151.4167F;
            this.groupHeaderVendedor.Name = "groupHeaderVendedor";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(7.812469F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(152F, 95F);
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(285.8129F, 16.24997F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(329.4165F, 23F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "LIQUIDACIÓN (CORONA MOROLEON)";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // direccionCedis
            // 
            this.direccionCedis.Dpi = 100F;
            this.direccionCedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionCedis.LocationFloat = new DevExpress.Utils.PointFloat(177.9377F, 39.24999F);
            this.direccionCedis.Name = "direccionCedis";
            this.direccionCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.direccionCedis.SizeF = new System.Drawing.SizeF(557.2914F, 16.75001F);
            this.direccionCedis.StylePriority.UseFont = false;
            this.direccionCedis.StylePriority.UseTextAlignment = false;
            this.direccionCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // telefonoCedis
            // 
            this.telefonoCedis.Dpi = 100F;
            this.telefonoCedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoCedis.LocationFloat = new DevExpress.Utils.PointFloat(246.1043F, 56.00001F);
            this.telefonoCedis.Name = "telefonoCedis";
            this.telefonoCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.telefonoCedis.SizeF = new System.Drawing.SizeF(407.13F, 16.75001F);
            this.telefonoCedis.StylePriority.UseFont = false;
            this.telefonoCedis.StylePriority.UseTextAlignment = false;
            this.telefonoCedis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(4.169133F, 105.4167F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(136.7034F, 23.00001F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Fecha";
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(141.9325F, 105.4167F);
            this.headerFecha.Name = "headerFecha";
            this.headerFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerFecha.SizeF = new System.Drawing.SizeF(674.8384F, 23.00001F);
            this.headerFecha.StylePriority.UseFont = false;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(4.169133F, 128.4167F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(136.7034F, 23F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor";
            // 
            // headerVendedor
            // 
            this.headerVendedor.Dpi = 100F;
            this.headerVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(141.9325F, 128.4167F);
            this.headerVendedor.Name = "headerVendedor";
            this.headerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerVendedor.SizeF = new System.Drawing.SizeF(674.3751F, 23F);
            this.headerVendedor.StylePriority.UseFont = false;
            // 
            // VentasProducto
            // 
            this.VentasProducto.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.ReportHeader,
            this.ReportFooter});
            this.VentasProducto.Dpi = 100F;
            this.VentasProducto.Level = 0;
            this.VentasProducto.Name = "VentasProducto";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.detalleClave,
            this.detalleDescripcion,
            this.detalleInventarioInicial,
            this.detalleRecargas,
            this.detalleDevoluciones,
            this.detallePromocion,
            this.detalleDescargas,
            this.detalleInventarioFinal,
            this.detalleVentas,
            this.detalleImporte});
            this.Detail1.Dpi = 100F;
            this.Detail1.HeightF = 15.49998F;
            this.Detail1.Name = "Detail1";
            // 
            // detalleClave
            // 
            this.detalleClave.Dpi = 100F;
            this.detalleClave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleClave.LocationFloat = new DevExpress.Utils.PointFloat(1.208369F, 0F);
            this.detalleClave.Name = "detalleClave";
            this.detalleClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleClave.SizeF = new System.Drawing.SizeF(68.16661F, 15.00009F);
            this.detalleClave.StylePriority.UseFont = false;
            this.detalleClave.StylePriority.UseTextAlignment = false;
            this.detalleClave.Text = "Clave";
            this.detalleClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detalleDescripcion
            // 
            this.detalleDescripcion.Dpi = 100F;
            this.detalleDescripcion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(69.37498F, 0F);
            this.detalleDescripcion.Multiline = true;
            this.detalleDescripcion.Name = "detalleDescripcion";
            this.detalleDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleDescripcion.SizeF = new System.Drawing.SizeF(160.0419F, 15.00011F);
            this.detalleDescripcion.StylePriority.UseFont = false;
            this.detalleDescripcion.StylePriority.UseTextAlignment = false;
            this.detalleDescripcion.Text = "Descipción";
            this.detalleDescripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detalleInventarioInicial
            // 
            this.detalleInventarioInicial.Dpi = 100F;
            this.detalleInventarioInicial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleInventarioInicial.LocationFloat = new DevExpress.Utils.PointFloat(229.4169F, 0F);
            this.detalleInventarioInicial.Multiline = true;
            this.detalleInventarioInicial.Name = "detalleInventarioInicial";
            this.detalleInventarioInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleInventarioInicial.SizeF = new System.Drawing.SizeF(57.07753F, 15.00012F);
            this.detalleInventarioInicial.StylePriority.UseFont = false;
            this.detalleInventarioInicial.StylePriority.UseTextAlignment = false;
            this.detalleInventarioInicial.Text = "Inventario Inicial";
            this.detalleInventarioInicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleRecargas
            // 
            this.detalleRecargas.Dpi = 100F;
            this.detalleRecargas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleRecargas.LocationFloat = new DevExpress.Utils.PointFloat(286.9527F, 0F);
            this.detalleRecargas.Multiline = true;
            this.detalleRecargas.Name = "detalleRecargas";
            this.detalleRecargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleRecargas.SizeF = new System.Drawing.SizeF(62.86975F, 15.00012F);
            this.detalleRecargas.StylePriority.UseFont = false;
            this.detalleRecargas.StylePriority.UseTextAlignment = false;
            this.detalleRecargas.Text = "Recargas";
            this.detalleRecargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleDevoluciones
            // 
            this.detalleDevoluciones.Dpi = 100F;
            this.detalleDevoluciones.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleDevoluciones.LocationFloat = new DevExpress.Utils.PointFloat(349.8226F, 0F);
            this.detalleDevoluciones.Multiline = true;
            this.detalleDevoluciones.Name = "detalleDevoluciones";
            this.detalleDevoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleDevoluciones.SizeF = new System.Drawing.SizeF(87.00546F, 15.49998F);
            this.detalleDevoluciones.StylePriority.UseFont = false;
            this.detalleDevoluciones.StylePriority.UseTextAlignment = false;
            this.detalleDevoluciones.Text = "Devoluciones";
            this.detalleDevoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detallePromocion
            // 
            this.detallePromocion.Dpi = 100F;
            this.detallePromocion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detallePromocion.LocationFloat = new DevExpress.Utils.PointFloat(436.8279F, 0F);
            this.detallePromocion.Multiline = true;
            this.detallePromocion.Name = "detallePromocion";
            this.detallePromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detallePromocion.SizeF = new System.Drawing.SizeF(80.12997F, 14.50012F);
            this.detallePromocion.StylePriority.UseFont = false;
            this.detallePromocion.StylePriority.UseTextAlignment = false;
            this.detallePromocion.Text = "Promoción";
            this.detallePromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleDescargas
            // 
            this.detalleDescargas.Dpi = 100F;
            this.detalleDescargas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleDescargas.LocationFloat = new DevExpress.Utils.PointFloat(518.1664F, 0F);
            this.detalleDescargas.Multiline = true;
            this.detalleDescargas.Name = "detalleDescargas";
            this.detalleDescargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleDescargas.SizeF = new System.Drawing.SizeF(78.00482F, 14.50012F);
            this.detalleDescargas.StylePriority.UseFont = false;
            this.detalleDescargas.StylePriority.UseTextAlignment = false;
            this.detalleDescargas.Text = "Descargas";
            this.detalleDescargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleInventarioFinal
            // 
            this.detalleInventarioFinal.Dpi = 100F;
            this.detalleInventarioFinal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleInventarioFinal.LocationFloat = new DevExpress.Utils.PointFloat(597.0877F, 0F);
            this.detalleInventarioFinal.Multiline = true;
            this.detalleInventarioFinal.Name = "detalleInventarioFinal";
            this.detalleInventarioFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleInventarioFinal.SizeF = new System.Drawing.SizeF(79.67169F, 14.50012F);
            this.detalleInventarioFinal.StylePriority.UseFont = false;
            this.detalleInventarioFinal.StylePriority.UseTextAlignment = false;
            this.detalleInventarioFinal.Text = "Inventario Final";
            this.detalleInventarioFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleVentas
            // 
            this.detalleVentas.Dpi = 100F;
            this.detalleVentas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleVentas.LocationFloat = new DevExpress.Utils.PointFloat(676.7593F, 0F);
            this.detalleVentas.Multiline = true;
            this.detalleVentas.Name = "detalleVentas";
            this.detalleVentas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleVentas.SizeF = new System.Drawing.SizeF(73.91626F, 14.50011F);
            this.detalleVentas.StylePriority.UseFont = false;
            this.detalleVentas.StylePriority.UseTextAlignment = false;
            this.detalleVentas.Text = "Ventas";
            this.detalleVentas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleImporte
            // 
            this.detalleImporte.Dpi = 100F;
            this.detalleImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleImporte.LocationFloat = new DevExpress.Utils.PointFloat(750.6756F, 0F);
            this.detalleImporte.Multiline = true;
            this.detalleImporte.Name = "detalleImporte";
            this.detalleImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleImporte.SizeF = new System.Drawing.SizeF(69.19952F, 14.50011F);
            this.detalleImporte.StylePriority.UseFont = false;
            this.detalleImporte.StylePriority.UseTextAlignment = false;
            this.detalleImporte.Text = "Importe";
            this.detalleImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel8,
            this.xrLine1,
            this.xrLabel2,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel5,
            this.xrLine2,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel14});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 111.4583F;
            this.ReportHeader.KeepTogether = true;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(516.9579F, 49.62485F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(79.67151F, 36.37512F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Descargas";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(436.8279F, 50.12489F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(80.13F, 36.37512F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Promoción";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(2.120082F, 26.75002F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(819.8799F, 22.87489F);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(7.416662F, 10F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(140.625F, 16.75F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Ventas por Producto";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(216.3335F, 50.1249F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(70.61922F, 36.87512F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Inventario Inicial";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(286.9527F, 49.62492F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(62.86975F, 36.87512F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Recargas";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(69.37498F, 49.62492F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(146.9585F, 36.8751F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Descipción";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(2.124913F, 87.00005F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(819.4167F, 23F);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(596.6294F, 50.62494F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(80.12994F, 36.37512F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Inventario Final";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(349.8225F, 49.62491F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(87.00543F, 37.37498F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Devoluciones";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(676.7593F, 49.62486F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(73.45789F, 36.37511F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Ventas";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(750.7797F, 49.62486F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(65.99103F, 36.37511F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Importe";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(4.312643F, 50.1249F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(65.06233F, 36.8751F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Clave";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totalInventarioInicial,
            this.totalRecargas,
            this.totalDevoluciones,
            this.totalPromocion,
            this.totalDescargas,
            this.totalInventarioFinal,
            this.totalVentas,
            this.totalImporte});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 17.58331F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // totalInventarioInicial
            // 
            this.totalInventarioInicial.Dpi = 100F;
            this.totalInventarioInicial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalInventarioInicial.LocationFloat = new DevExpress.Utils.PointFloat(229.4169F, 0F);
            this.totalInventarioInicial.Multiline = true;
            this.totalInventarioInicial.Name = "totalInventarioInicial";
            this.totalInventarioInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalInventarioInicial.SizeF = new System.Drawing.SizeF(56.16096F, 15.00012F);
            this.totalInventarioInicial.StylePriority.UseFont = false;
            this.totalInventarioInicial.StylePriority.UseTextAlignment = false;
            this.totalInventarioInicial.Text = "Inventario Inicial";
            this.totalInventarioInicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalRecargas
            // 
            this.totalRecargas.Dpi = 100F;
            this.totalRecargas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRecargas.LocationFloat = new DevExpress.Utils.PointFloat(286.9527F, 0F);
            this.totalRecargas.Multiline = true;
            this.totalRecargas.Name = "totalRecargas";
            this.totalRecargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalRecargas.SizeF = new System.Drawing.SizeF(62.41135F, 15.00012F);
            this.totalRecargas.StylePriority.UseFont = false;
            this.totalRecargas.StylePriority.UseTextAlignment = false;
            this.totalRecargas.Text = "Recargas";
            this.totalRecargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalDevoluciones
            // 
            this.totalDevoluciones.Dpi = 100F;
            this.totalDevoluciones.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDevoluciones.LocationFloat = new DevExpress.Utils.PointFloat(349.8225F, 0F);
            this.totalDevoluciones.Multiline = true;
            this.totalDevoluciones.Name = "totalDevoluciones";
            this.totalDevoluciones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalDevoluciones.SizeF = new System.Drawing.SizeF(86.54715F, 15.49998F);
            this.totalDevoluciones.StylePriority.UseFont = false;
            this.totalDevoluciones.StylePriority.UseTextAlignment = false;
            this.totalDevoluciones.Text = "Devoluciones";
            this.totalDevoluciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalPromocion
            // 
            this.totalPromocion.Dpi = 100F;
            this.totalPromocion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPromocion.LocationFloat = new DevExpress.Utils.PointFloat(436.8279F, 0F);
            this.totalPromocion.Multiline = true;
            this.totalPromocion.Name = "totalPromocion";
            this.totalPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPromocion.SizeF = new System.Drawing.SizeF(79.67178F, 14.50012F);
            this.totalPromocion.StylePriority.UseFont = false;
            this.totalPromocion.StylePriority.UseTextAlignment = false;
            this.totalPromocion.Text = "Promoción";
            this.totalPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalDescargas
            // 
            this.totalDescargas.Dpi = 100F;
            this.totalDescargas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDescargas.LocationFloat = new DevExpress.Utils.PointFloat(516.9579F, 0F);
            this.totalDescargas.Multiline = true;
            this.totalDescargas.Name = "totalDescargas";
            this.totalDescargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalDescargas.SizeF = new System.Drawing.SizeF(78.75507F, 14.50012F);
            this.totalDescargas.StylePriority.UseFont = false;
            this.totalDescargas.StylePriority.UseTextAlignment = false;
            this.totalDescargas.Text = "Descargas";
            this.totalDescargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalInventarioFinal
            // 
            this.totalInventarioFinal.Dpi = 100F;
            this.totalInventarioFinal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalInventarioFinal.LocationFloat = new DevExpress.Utils.PointFloat(596.6295F, 0F);
            this.totalInventarioFinal.Multiline = true;
            this.totalInventarioFinal.Name = "totalInventarioFinal";
            this.totalInventarioFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalInventarioFinal.SizeF = new System.Drawing.SizeF(80.12994F, 14.50012F);
            this.totalInventarioFinal.StylePriority.UseFont = false;
            this.totalInventarioFinal.StylePriority.UseTextAlignment = false;
            this.totalInventarioFinal.Text = "Inventario Final";
            this.totalInventarioFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalVentas
            // 
            this.totalVentas.Dpi = 100F;
            this.totalVentas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVentas.LocationFloat = new DevExpress.Utils.PointFloat(676.7594F, 0F);
            this.totalVentas.Multiline = true;
            this.totalVentas.Name = "totalVentas";
            this.totalVentas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalVentas.SizeF = new System.Drawing.SizeF(74.37512F, 14.50011F);
            this.totalVentas.StylePriority.UseFont = false;
            this.totalVentas.StylePriority.UseTextAlignment = false;
            this.totalVentas.Text = "Ventas";
            this.totalVentas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totalImporte
            // 
            this.totalImporte.Dpi = 100F;
            this.totalImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalImporte.LocationFloat = new DevExpress.Utils.PointFloat(751.1345F, 0F);
            this.totalImporte.Multiline = true;
            this.totalImporte.Name = "totalImporte";
            this.totalImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalImporte.SizeF = new System.Drawing.SizeF(70.19629F, 14.50011F);
            this.totalImporte.StylePriority.UseFont = false;
            this.totalImporte.StylePriority.UseTextAlignment = false;
            this.totalImporte.Text = "Importe";
            this.totalImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.VContadoDetalleFactura,
            this.VContadoDetalleVenta,
            this.VContadoDetalleCliente,
            this.VContadoDetalleLitros,
            this.VContadoDetalleFecha,
            this.VContadoDetalleImporte});
            this.Detail2.Dpi = 100F;
            this.Detail2.HeightF = 18.75F;
            this.Detail2.Name = "Detail2";
            // 
            // VContadoDetalleFactura
            // 
            this.VContadoDetalleFactura.Dpi = 100F;
            this.VContadoDetalleFactura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VContadoDetalleFactura.LocationFloat = new DevExpress.Utils.PointFloat(93.16698F, 0.4999161F);
            this.VContadoDetalleFactura.Multiline = true;
            this.VContadoDetalleFactura.Name = "VContadoDetalleFactura";
            this.VContadoDetalleFactura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VContadoDetalleFactura.SizeF = new System.Drawing.SizeF(118.333F, 16.04178F);
            this.VContadoDetalleFactura.StylePriority.UseFont = false;
            this.VContadoDetalleFactura.StylePriority.UseTextAlignment = false;
            this.VContadoDetalleFactura.Text = "Factura";
            this.VContadoDetalleFactura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VContadoDetalleVenta
            // 
            this.VContadoDetalleVenta.Dpi = 100F;
            this.VContadoDetalleVenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VContadoDetalleVenta.LocationFloat = new DevExpress.Utils.PointFloat(2.58344F, 0F);
            this.VContadoDetalleVenta.Name = "VContadoDetalleVenta";
            this.VContadoDetalleVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VContadoDetalleVenta.SizeF = new System.Drawing.SizeF(88.396F, 16.04177F);
            this.VContadoDetalleVenta.StylePriority.UseFont = false;
            this.VContadoDetalleVenta.StylePriority.UseTextAlignment = false;
            this.VContadoDetalleVenta.Text = "Venta";
            this.VContadoDetalleVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VContadoDetalleCliente
            // 
            this.VContadoDetalleCliente.CanGrow = false;
            this.VContadoDetalleCliente.Dpi = 100F;
            this.VContadoDetalleCliente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VContadoDetalleCliente.LocationFloat = new DevExpress.Utils.PointFloat(373.9346F, 0F);
            this.VContadoDetalleCliente.Multiline = true;
            this.VContadoDetalleCliente.Name = "VContadoDetalleCliente";
            this.VContadoDetalleCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VContadoDetalleCliente.SizeF = new System.Drawing.SizeF(237.0836F, 16.04179F);
            this.VContadoDetalleCliente.StylePriority.UseFont = false;
            this.VContadoDetalleCliente.StylePriority.UseTextAlignment = false;
            this.VContadoDetalleCliente.Text = "Cliente";
            this.VContadoDetalleCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VContadoDetalleLitros
            // 
            this.VContadoDetalleLitros.Dpi = 100F;
            this.VContadoDetalleLitros.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VContadoDetalleLitros.LocationFloat = new DevExpress.Utils.PointFloat(611.4764F, 0F);
            this.VContadoDetalleLitros.Multiline = true;
            this.VContadoDetalleLitros.Name = "VContadoDetalleLitros";
            this.VContadoDetalleLitros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VContadoDetalleLitros.SizeF = new System.Drawing.SizeF(99.49506F, 16.54165F);
            this.VContadoDetalleLitros.StylePriority.UseFont = false;
            this.VContadoDetalleLitros.StylePriority.UseTextAlignment = false;
            this.VContadoDetalleLitros.Text = "Litros";
            this.VContadoDetalleLitros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // VContadoDetalleFecha
            // 
            this.VContadoDetalleFecha.Dpi = 100F;
            this.VContadoDetalleFecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VContadoDetalleFecha.LocationFloat = new DevExpress.Utils.PointFloat(215.8752F, 0F);
            this.VContadoDetalleFecha.Multiline = true;
            this.VContadoDetalleFecha.Name = "VContadoDetalleFecha";
            this.VContadoDetalleFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VContadoDetalleFecha.SizeF = new System.Drawing.SizeF(157.3928F, 16.04179F);
            this.VContadoDetalleFecha.StylePriority.UseFont = false;
            this.VContadoDetalleFecha.StylePriority.UseTextAlignment = false;
            this.VContadoDetalleFecha.Text = "Fecha";
            this.VContadoDetalleFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VContadoDetalleImporte
            // 
            this.VContadoDetalleImporte.Dpi = 100F;
            this.VContadoDetalleImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VContadoDetalleImporte.LocationFloat = new DevExpress.Utils.PointFloat(712.5992F, 0F);
            this.VContadoDetalleImporte.Multiline = true;
            this.VContadoDetalleImporte.Name = "VContadoDetalleImporte";
            this.VContadoDetalleImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VContadoDetalleImporte.SizeF = new System.Drawing.SizeF(108.4843F, 15.54179F);
            this.VContadoDetalleImporte.StylePriority.UseFont = false;
            this.VContadoDetalleImporte.StylePriority.UseTextAlignment = false;
            this.VContadoDetalleImporte.Text = "Importe";
            this.VContadoDetalleImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader1
            // 
            this.ReportHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLine3,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel18,
            this.xrLine4});
            this.ReportHeader1.Dpi = 100F;
            this.ReportHeader1.HeightF = 100.0001F;
            this.ReportHeader1.KeepTogether = true;
            this.ReportHeader1.Name = "ReportHeader1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(6.356608F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(140.625F, 16.75F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Ventas Contado";
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(1.060028F, 16.75002F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(819.8799F, 22.87489F);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.169133F, 40.1249F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(88.39599F, 36.8751F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Venta";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(92.70859F, 39.62491F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(118.7914F, 36.8751F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Factura";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(215.8752F, 40.12489F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(157.3928F, 36.87512F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Fecha";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(373.9346F, 39.62491F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(238.482F, 36.87512F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Cliente";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(612.8749F, 39.62491F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(99.13965F, 37.37497F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Litros";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(712.5992F, 40.12489F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(108.4843F, 36.37512F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Importe";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(1.06486F, 77.00005F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(819.4167F, 23F);
            // 
            // ReportFooter1
            // 
            this.ReportFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.VContadoTotalImporte});
            this.ReportFooter1.Dpi = 100F;
            this.ReportFooter1.HeightF = 15.625F;
            this.ReportFooter1.Name = "ReportFooter1";
            // 
            // VContadoTotalImporte
            // 
            this.VContadoTotalImporte.Dpi = 100F;
            this.VContadoTotalImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VContadoTotalImporte.LocationFloat = new DevExpress.Utils.PointFloat(712.5992F, 0F);
            this.VContadoTotalImporte.Multiline = true;
            this.VContadoTotalImporte.Name = "VContadoTotalImporte";
            this.VContadoTotalImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VContadoTotalImporte.SizeF = new System.Drawing.SizeF(106.8175F, 15.54179F);
            this.VContadoTotalImporte.StylePriority.UseFont = false;
            this.VContadoTotalImporte.StylePriority.UseTextAlignment = false;
            this.VContadoTotalImporte.Text = "Importe";
            this.VContadoTotalImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.VCreditoDetalleVenta,
            this.VCreditoDetalleFactura,
            this.VCreditoDetalleFecha,
            this.VCreditoDetalleCliente,
            this.VCreditoDetalleLitros,
            this.VCreditoDetalleImporte});
            this.Detail3.Dpi = 100F;
            this.Detail3.HeightF = 16.54165F;
            this.Detail3.Name = "Detail3";
            // 
            // VCreditoDetalleVenta
            // 
            this.VCreditoDetalleVenta.Dpi = 100F;
            this.VCreditoDetalleVenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VCreditoDetalleVenta.LocationFloat = new DevExpress.Utils.PointFloat(2.084473F, 0F);
            this.VCreditoDetalleVenta.Name = "VCreditoDetalleVenta";
            this.VCreditoDetalleVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VCreditoDetalleVenta.SizeF = new System.Drawing.SizeF(88.396F, 16.04177F);
            this.VCreditoDetalleVenta.StylePriority.UseFont = false;
            this.VCreditoDetalleVenta.StylePriority.UseTextAlignment = false;
            this.VCreditoDetalleVenta.Text = "Venta";
            this.VCreditoDetalleVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VCreditoDetalleFactura
            // 
            this.VCreditoDetalleFactura.Dpi = 100F;
            this.VCreditoDetalleFactura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VCreditoDetalleFactura.LocationFloat = new DevExpress.Utils.PointFloat(93.62526F, 0F);
            this.VCreditoDetalleFactura.Multiline = true;
            this.VCreditoDetalleFactura.Name = "VCreditoDetalleFactura";
            this.VCreditoDetalleFactura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VCreditoDetalleFactura.SizeF = new System.Drawing.SizeF(117.8747F, 16.04178F);
            this.VCreditoDetalleFactura.StylePriority.UseFont = false;
            this.VCreditoDetalleFactura.StylePriority.UseTextAlignment = false;
            this.VCreditoDetalleFactura.Text = "Factura";
            this.VCreditoDetalleFactura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VCreditoDetalleFecha
            // 
            this.VCreditoDetalleFecha.Dpi = 100F;
            this.VCreditoDetalleFecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VCreditoDetalleFecha.LocationFloat = new DevExpress.Utils.PointFloat(215.8752F, 0F);
            this.VCreditoDetalleFecha.Multiline = true;
            this.VCreditoDetalleFecha.Name = "VCreditoDetalleFecha";
            this.VCreditoDetalleFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VCreditoDetalleFecha.SizeF = new System.Drawing.SizeF(157.3928F, 16.04179F);
            this.VCreditoDetalleFecha.StylePriority.UseFont = false;
            this.VCreditoDetalleFecha.StylePriority.UseTextAlignment = false;
            this.VCreditoDetalleFecha.Text = "Fecha";
            this.VCreditoDetalleFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VCreditoDetalleCliente
            // 
            this.VCreditoDetalleCliente.CanGrow = false;
            this.VCreditoDetalleCliente.Dpi = 100F;
            this.VCreditoDetalleCliente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VCreditoDetalleCliente.LocationFloat = new DevExpress.Utils.PointFloat(373.4763F, 0F);
            this.VCreditoDetalleCliente.Multiline = true;
            this.VCreditoDetalleCliente.Name = "VCreditoDetalleCliente";
            this.VCreditoDetalleCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VCreditoDetalleCliente.SizeF = new System.Drawing.SizeF(237.0835F, 16.04179F);
            this.VCreditoDetalleCliente.StylePriority.UseFont = false;
            this.VCreditoDetalleCliente.StylePriority.UseTextAlignment = false;
            this.VCreditoDetalleCliente.Text = "Cliente";
            this.VCreditoDetalleCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // VCreditoDetalleLitros
            // 
            this.VCreditoDetalleLitros.Dpi = 100F;
            this.VCreditoDetalleLitros.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VCreditoDetalleLitros.LocationFloat = new DevExpress.Utils.PointFloat(611.4764F, 0F);
            this.VCreditoDetalleLitros.Multiline = true;
            this.VCreditoDetalleLitros.Name = "VCreditoDetalleLitros";
            this.VCreditoDetalleLitros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VCreditoDetalleLitros.SizeF = new System.Drawing.SizeF(99.13977F, 16.54165F);
            this.VCreditoDetalleLitros.StylePriority.UseFont = false;
            this.VCreditoDetalleLitros.StylePriority.UseTextAlignment = false;
            this.VCreditoDetalleLitros.Text = "Litros";
            this.VCreditoDetalleLitros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // VCreditoDetalleImporte
            // 
            this.VCreditoDetalleImporte.Dpi = 100F;
            this.VCreditoDetalleImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VCreditoDetalleImporte.LocationFloat = new DevExpress.Utils.PointFloat(712.5992F, 0F);
            this.VCreditoDetalleImporte.Multiline = true;
            this.VCreditoDetalleImporte.Name = "VCreditoDetalleImporte";
            this.VCreditoDetalleImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VCreditoDetalleImporte.SizeF = new System.Drawing.SizeF(106.3997F, 15.54179F);
            this.VCreditoDetalleImporte.StylePriority.UseFont = false;
            this.VCreditoDetalleImporte.StylePriority.UseTextAlignment = false;
            this.VCreditoDetalleImporte.Text = "Importe";
            this.VCreditoDetalleImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader2
            // 
            this.ReportHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.xrLine5,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel28,
            this.xrLine6});
            this.ReportHeader2.Dpi = 100F;
            this.ReportHeader2.HeightF = 100.0001F;
            this.ReportHeader2.KeepTogether = true;
            this.ReportHeader2.Name = "ReportHeader2";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(4.169083F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(140.625F, 16.75F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Ventas Credito";
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 16.75002F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(819.8799F, 22.87489F);
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(1.523336F, 40.12489F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(91.04179F, 36.87509F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Venta";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(93.16686F, 40.12496F);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(118.3331F, 36.87512F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Factura";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(215.417F, 40.12489F);
            this.xrLabel23.Multiline = true;
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(157.8511F, 36.87512F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Fecha";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(373.9346F, 39.62491F);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(236.6252F, 36.87512F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Cliente";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(611.4764F, 39.62504F);
            this.xrLabel26.Multiline = true;
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(99.0368F, 37.37497F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "Litros";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(712.5992F, 40.12489F);
            this.xrLabel28.Multiline = true;
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(107.2133F, 36.37512F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Importe";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine6
            // 
            this.xrLine6.Dpi = 100F;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 77.00005F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(819.4167F, 23F);
            // 
            // ReportFooter2
            // 
            this.ReportFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.VCreditoTotalImporte});
            this.ReportFooter2.Dpi = 100F;
            this.ReportFooter2.HeightF = 16.66667F;
            this.ReportFooter2.Name = "ReportFooter2";
            this.ReportFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // VCreditoTotalImporte
            // 
            this.VCreditoTotalImporte.Dpi = 100F;
            this.VCreditoTotalImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VCreditoTotalImporte.LocationFloat = new DevExpress.Utils.PointFloat(712.5992F, 0F);
            this.VCreditoTotalImporte.Multiline = true;
            this.VCreditoTotalImporte.Name = "VCreditoTotalImporte";
            this.VCreditoTotalImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VCreditoTotalImporte.SizeF = new System.Drawing.SizeF(107.424F, 15.54179F);
            this.VCreditoTotalImporte.StylePriority.UseFont = false;
            this.VCreditoTotalImporte.StylePriority.UseTextAlignment = false;
            this.VCreditoTotalImporte.Text = "Importe";
            this.VCreditoTotalImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CobranzaContado
            // 
            this.CobranzaContado.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail4,
            this.ReportHeader3,
            this.ReportFooter3});
            this.CobranzaContado.Dpi = 100F;
            this.CobranzaContado.Level = 3;
            this.CobranzaContado.Name = "CobranzaContado";
            // 
            // Detail4
            // 
            this.Detail4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CContadoDetalleFolio,
            this.CContadoDetalleFactura,
            this.CContadoDetalleFechaFactura,
            this.CContadoDetalleCliente,
            this.CContadoDetalleImporte,
            this.CContadoDetalleFechaPago});
            this.Detail4.Dpi = 100F;
            this.Detail4.HeightF = 17.58347F;
            this.Detail4.Name = "Detail4";
            // 
            // CContadoDetalleFolio
            // 
            this.CContadoDetalleFolio.Dpi = 100F;
            this.CContadoDetalleFolio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CContadoDetalleFolio.LocationFloat = new DevExpress.Utils.PointFloat(1.397196F, 0.4999796F);
            this.CContadoDetalleFolio.Name = "CContadoDetalleFolio";
            this.CContadoDetalleFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CContadoDetalleFolio.SizeF = new System.Drawing.SizeF(105.0624F, 15.00009F);
            this.CContadoDetalleFolio.StylePriority.UseFont = false;
            this.CContadoDetalleFolio.StylePriority.UseTextAlignment = false;
            this.CContadoDetalleFolio.Text = "Folio Cobranza";
            this.CContadoDetalleFolio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CContadoDetalleFactura
            // 
            this.CContadoDetalleFactura.Dpi = 100F;
            this.CContadoDetalleFactura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CContadoDetalleFactura.LocationFloat = new DevExpress.Utils.PointFloat(106.4596F, 0F);
            this.CContadoDetalleFactura.Multiline = true;
            this.CContadoDetalleFactura.Name = "CContadoDetalleFactura";
            this.CContadoDetalleFactura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CContadoDetalleFactura.SizeF = new System.Drawing.SizeF(110.7904F, 15.00011F);
            this.CContadoDetalleFactura.StylePriority.UseFont = false;
            this.CContadoDetalleFactura.StylePriority.UseTextAlignment = false;
            this.CContadoDetalleFactura.Text = "Factura";
            this.CContadoDetalleFactura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CContadoDetalleFechaFactura
            // 
            this.CContadoDetalleFechaFactura.Dpi = 100F;
            this.CContadoDetalleFechaFactura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CContadoDetalleFechaFactura.LocationFloat = new DevExpress.Utils.PointFloat(217.25F, 0F);
            this.CContadoDetalleFechaFactura.Multiline = true;
            this.CContadoDetalleFechaFactura.Name = "CContadoDetalleFechaFactura";
            this.CContadoDetalleFechaFactura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CContadoDetalleFechaFactura.SizeF = new System.Drawing.SizeF(156.2263F, 15.00012F);
            this.CContadoDetalleFechaFactura.StylePriority.UseFont = false;
            this.CContadoDetalleFechaFactura.StylePriority.UseTextAlignment = false;
            this.CContadoDetalleFechaFactura.Text = "Fecha Factura";
            this.CContadoDetalleFechaFactura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CContadoDetalleCliente
            // 
            this.CContadoDetalleCliente.CanGrow = false;
            this.CContadoDetalleCliente.Dpi = 100F;
            this.CContadoDetalleCliente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CContadoDetalleCliente.LocationFloat = new DevExpress.Utils.PointFloat(373.4763F, 0.4999796F);
            this.CContadoDetalleCliente.Multiline = true;
            this.CContadoDetalleCliente.Name = "CContadoDetalleCliente";
            this.CContadoDetalleCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CContadoDetalleCliente.SizeF = new System.Drawing.SizeF(193.8408F, 15.00012F);
            this.CContadoDetalleCliente.StylePriority.UseFont = false;
            this.CContadoDetalleCliente.StylePriority.UseTextAlignment = false;
            this.CContadoDetalleCliente.Text = "Cliente";
            this.CContadoDetalleCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CContadoDetalleImporte
            // 
            this.CContadoDetalleImporte.Dpi = 100F;
            this.CContadoDetalleImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CContadoDetalleImporte.LocationFloat = new DevExpress.Utils.PointFloat(567.3169F, 0.0001271566F);
            this.CContadoDetalleImporte.Multiline = true;
            this.CContadoDetalleImporte.Name = "CContadoDetalleImporte";
            this.CContadoDetalleImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CContadoDetalleImporte.SizeF = new System.Drawing.SizeF(96.81744F, 15.49998F);
            this.CContadoDetalleImporte.StylePriority.UseFont = false;
            this.CContadoDetalleImporte.StylePriority.UseTextAlignment = false;
            this.CContadoDetalleImporte.Text = "Importe";
            this.CContadoDetalleImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CContadoDetalleFechaPago
            // 
            this.CContadoDetalleFechaPago.Dpi = 100F;
            this.CContadoDetalleFechaPago.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CContadoDetalleFechaPago.LocationFloat = new DevExpress.Utils.PointFloat(664.1341F, 0.4999796F);
            this.CContadoDetalleFechaPago.Multiline = true;
            this.CContadoDetalleFechaPago.Name = "CContadoDetalleFechaPago";
            this.CContadoDetalleFechaPago.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CContadoDetalleFechaPago.SizeF = new System.Drawing.SizeF(155.0939F, 14.50012F);
            this.CContadoDetalleFechaPago.StylePriority.UseFont = false;
            this.CContadoDetalleFechaPago.StylePriority.UseTextAlignment = false;
            this.CContadoDetalleFechaPago.Text = "Fecha Pago";
            this.CContadoDetalleFechaPago.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader3
            // 
            this.ReportHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel36,
            this.xrLabel29,
            this.xrLine7,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLine8});
            this.ReportHeader3.Dpi = 100F;
            this.ReportHeader3.HeightF = 94.79173F;
            this.ReportHeader3.KeepTogether = true;
            this.ReportHeader3.Name = "ReportHeader3";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(7.8125F, 76.04154F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(59.375F, 16.75F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.Text = "Contado";
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(4.770915F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(59.375F, 16.75F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.Text = "Cobranza";
            // 
            // xrLine7
            // 
            this.xrLine7.Dpi = 100F;
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(0.6018321F, 16.75002F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(819.8799F, 11.41656F);
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(2.58344F, 28.16657F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(105.0624F, 36.87509F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "Folio Cobranza";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(107.6458F, 28.16658F);
            this.xrLabel31.Multiline = true;
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(109.1458F, 36.87511F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Factura";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(216.7917F, 28.16658F);
            this.xrLabel32.Multiline = true;
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(156.2263F, 36.87512F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Fecha Factura";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(373.0179F, 28.16658F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(193.8409F, 36.87511F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Cliente";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(566.8586F, 28.16652F);
            this.xrLabel34.Multiline = true;
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(96.81738F, 37.37498F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "Importe";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel35
            // 
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(663.676F, 28.16658F);
            this.xrLabel35.Multiline = true;
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(155.8218F, 36.37511F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "Fecha Pago";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine8
            // 
            this.xrLine8.Dpi = 100F;
            this.xrLine8.LocationFloat = new DevExpress.Utils.PointFloat(1.208369F, 65.54152F);
            this.xrLine8.Name = "xrLine8";
            this.xrLine8.SizeF = new System.Drawing.SizeF(819.4167F, 10.5F);
            // 
            // ReportFooter3
            // 
            this.ReportFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CContadoTotalImporte,
            this.xrLabel43});
            this.ReportFooter3.Dpi = 100F;
            this.ReportFooter3.HeightF = 16.75F;
            this.ReportFooter3.Name = "ReportFooter3";
            // 
            // CContadoTotalImporte
            // 
            this.CContadoTotalImporte.Dpi = 100F;
            this.CContadoTotalImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CContadoTotalImporte.LocationFloat = new DevExpress.Utils.PointFloat(566.8586F, 0F);
            this.CContadoTotalImporte.Name = "CContadoTotalImporte";
            this.CContadoTotalImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CContadoTotalImporte.SizeF = new System.Drawing.SizeF(97.27582F, 16.75F);
            this.CContadoTotalImporte.StylePriority.UseFont = false;
            this.CContadoTotalImporte.StylePriority.UseTextAlignment = false;
            this.CContadoTotalImporte.Text = "Total Importe";
            this.CContadoTotalImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(369.1208F, 0F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(197.738F, 16.75F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.Text = "Total Cobranza de Contado";
            // 
            // CobranzaCredito
            // 
            this.CobranzaCredito.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail5,
            this.ReportHeader4,
            this.ReportFooter4});
            this.CobranzaCredito.Dpi = 100F;
            this.CobranzaCredito.Level = 4;
            this.CobranzaCredito.Name = "CobranzaCredito";
            // 
            // Detail5
            // 
            this.Detail5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CCreditoDetalleFolio,
            this.CCreditoDetalleFactura,
            this.CCreditoDetalleFechaFactura,
            this.CCreditoDetalleCliente,
            this.CCreditoDetalleImporte,
            this.CCreditoDetalleFechaPago});
            this.Detail5.Dpi = 100F;
            this.Detail5.HeightF = 16.6667F;
            this.Detail5.Name = "Detail5";
            // 
            // CCreditoDetalleFolio
            // 
            this.CCreditoDetalleFolio.Dpi = 100F;
            this.CCreditoDetalleFolio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoDetalleFolio.LocationFloat = new DevExpress.Utils.PointFloat(1.855408F, 1.083259F);
            this.CCreditoDetalleFolio.Name = "CCreditoDetalleFolio";
            this.CCreditoDetalleFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoDetalleFolio.SizeF = new System.Drawing.SizeF(105.0624F, 15.00009F);
            this.CCreditoDetalleFolio.StylePriority.UseFont = false;
            this.CCreditoDetalleFolio.StylePriority.UseTextAlignment = false;
            this.CCreditoDetalleFolio.Text = "Folio Cobranza";
            this.CCreditoDetalleFolio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CCreditoDetalleFactura
            // 
            this.CCreditoDetalleFactura.Dpi = 100F;
            this.CCreditoDetalleFactura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoDetalleFactura.LocationFloat = new DevExpress.Utils.PointFloat(106.9178F, 0.5832672F);
            this.CCreditoDetalleFactura.Multiline = true;
            this.CCreditoDetalleFactura.Name = "CCreditoDetalleFactura";
            this.CCreditoDetalleFactura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoDetalleFactura.SizeF = new System.Drawing.SizeF(110.7904F, 15.00011F);
            this.CCreditoDetalleFactura.StylePriority.UseFont = false;
            this.CCreditoDetalleFactura.StylePriority.UseTextAlignment = false;
            this.CCreditoDetalleFactura.Text = "Factura";
            this.CCreditoDetalleFactura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CCreditoDetalleFechaFactura
            // 
            this.CCreditoDetalleFechaFactura.Dpi = 100F;
            this.CCreditoDetalleFechaFactura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoDetalleFechaFactura.LocationFloat = new DevExpress.Utils.PointFloat(217.7082F, 1.083265F);
            this.CCreditoDetalleFechaFactura.Multiline = true;
            this.CCreditoDetalleFechaFactura.Name = "CCreditoDetalleFechaFactura";
            this.CCreditoDetalleFechaFactura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoDetalleFechaFactura.SizeF = new System.Drawing.SizeF(156.2263F, 15.00012F);
            this.CCreditoDetalleFechaFactura.StylePriority.UseFont = false;
            this.CCreditoDetalleFechaFactura.StylePriority.UseTextAlignment = false;
            this.CCreditoDetalleFechaFactura.Text = "Fecha Factura";
            this.CCreditoDetalleFechaFactura.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CCreditoDetalleCliente
            // 
            this.CCreditoDetalleCliente.CanGrow = false;
            this.CCreditoDetalleCliente.Dpi = 100F;
            this.CCreditoDetalleCliente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoDetalleCliente.LocationFloat = new DevExpress.Utils.PointFloat(373.9346F, 0.5832672F);
            this.CCreditoDetalleCliente.Multiline = true;
            this.CCreditoDetalleCliente.Name = "CCreditoDetalleCliente";
            this.CCreditoDetalleCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoDetalleCliente.SizeF = new System.Drawing.SizeF(192.9243F, 15.00012F);
            this.CCreditoDetalleCliente.StylePriority.UseFont = false;
            this.CCreditoDetalleCliente.StylePriority.UseTextAlignment = false;
            this.CCreditoDetalleCliente.Text = "Cliente";
            this.CCreditoDetalleCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CCreditoDetalleImporte
            // 
            this.CCreditoDetalleImporte.Dpi = 100F;
            this.CCreditoDetalleImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoDetalleImporte.LocationFloat = new DevExpress.Utils.PointFloat(566.8586F, 0.5833943F);
            this.CCreditoDetalleImporte.Multiline = true;
            this.CCreditoDetalleImporte.Name = "CCreditoDetalleImporte";
            this.CCreditoDetalleImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoDetalleImporte.SizeF = new System.Drawing.SizeF(97.27582F, 15.49998F);
            this.CCreditoDetalleImporte.StylePriority.UseFont = false;
            this.CCreditoDetalleImporte.StylePriority.UseTextAlignment = false;
            this.CCreditoDetalleImporte.Text = "Importe";
            this.CCreditoDetalleImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CCreditoDetalleFechaPago
            // 
            this.CCreditoDetalleFechaPago.Dpi = 100F;
            this.CCreditoDetalleFechaPago.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoDetalleFechaPago.LocationFloat = new DevExpress.Utils.PointFloat(664.1345F, 1.083247F);
            this.CCreditoDetalleFechaPago.Multiline = true;
            this.CCreditoDetalleFechaPago.Name = "CCreditoDetalleFechaPago";
            this.CCreditoDetalleFechaPago.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoDetalleFechaPago.SizeF = new System.Drawing.SizeF(155.0937F, 14.50012F);
            this.CCreditoDetalleFechaPago.StylePriority.UseFont = false;
            this.CCreditoDetalleFechaPago.StylePriority.UseTextAlignment = false;
            this.CCreditoDetalleFechaPago.Text = "Fecha Pago";
            this.CCreditoDetalleFechaPago.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader4
            // 
            this.ReportHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel45});
            this.ReportHeader4.Dpi = 100F;
            this.ReportHeader4.HeightF = 16.75F;
            this.ReportHeader4.Name = "ReportHeader4";
            // 
            // xrLabel45
            // 
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 0F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(59.375F, 16.75F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.Text = "Crédito";
            // 
            // ReportFooter4
            // 
            this.ReportFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel52,
            this.CCreditoTotalImporte});
            this.ReportFooter4.Dpi = 100F;
            this.ReportFooter4.HeightF = 36.45833F;
            this.ReportFooter4.Name = "ReportFooter4";
            // 
            // xrLabel52
            // 
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(369.1208F, 0F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(197.738F, 16.75F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.Text = "Total Cobranza de Crédito";
            // 
            // CCreditoTotalImporte
            // 
            this.CCreditoTotalImporte.Dpi = 100F;
            this.CCreditoTotalImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoTotalImporte.LocationFloat = new DevExpress.Utils.PointFloat(566.8586F, 0F);
            this.CCreditoTotalImporte.Name = "CCreditoTotalImporte";
            this.CCreditoTotalImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoTotalImporte.SizeF = new System.Drawing.SizeF(96.35901F, 16.75F);
            this.CCreditoTotalImporte.StylePriority.UseFont = false;
            this.CCreditoTotalImporte.StylePriority.UseTextAlignment = false;
            this.CCreditoTotalImporte.Text = "Total Importe";
            this.CCreditoTotalImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseEfectivoDocumentos
            // 
            this.DesgloseEfectivoDocumentos.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail6,
            this.ReportHeader5});
            this.DesgloseEfectivoDocumentos.Dpi = 100F;
            this.DesgloseEfectivoDocumentos.Level = 6;
            this.DesgloseEfectivoDocumentos.Name = "DesgloseEfectivoDocumentos";
            // 
            // Detail6
            // 
            this.Detail6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DesgloseDetalleBanco,
            this.DesgloseDetalleReferencia,
            this.DesgloseDetalleFechaCobro,
            this.DesgloseDetalleImporte,
            this.DesgloseDetalleDenominacion,
            this.DesgloseDetalleCantidad,
            this.DesgloseDetalleTotal});
            this.Detail6.Dpi = 100F;
            this.Detail6.HeightF = 17.70833F;
            this.Detail6.Name = "Detail6";
            // 
            // DesgloseDetalleBanco
            // 
            this.DesgloseDetalleBanco.Dpi = 100F;
            this.DesgloseDetalleBanco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseDetalleBanco.LocationFloat = new DevExpress.Utils.PointFloat(440.8798F, 0F);
            this.DesgloseDetalleBanco.Name = "DesgloseDetalleBanco";
            this.DesgloseDetalleBanco.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseDetalleBanco.SizeF = new System.Drawing.SizeF(86.2085F, 15.00009F);
            this.DesgloseDetalleBanco.StylePriority.UseFont = false;
            this.DesgloseDetalleBanco.StylePriority.UseTextAlignment = false;
            this.DesgloseDetalleBanco.Text = "Banco";
            this.DesgloseDetalleBanco.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseDetalleReferencia
            // 
            this.DesgloseDetalleReferencia.Dpi = 100F;
            this.DesgloseDetalleReferencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseDetalleReferencia.LocationFloat = new DevExpress.Utils.PointFloat(528.2969F, 0F);
            this.DesgloseDetalleReferencia.Multiline = true;
            this.DesgloseDetalleReferencia.Name = "DesgloseDetalleReferencia";
            this.DesgloseDetalleReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseDetalleReferencia.SizeF = new System.Drawing.SizeF(123.1665F, 15.00011F);
            this.DesgloseDetalleReferencia.StylePriority.UseFont = false;
            this.DesgloseDetalleReferencia.StylePriority.UseTextAlignment = false;
            this.DesgloseDetalleReferencia.Text = "Referencia";
            this.DesgloseDetalleReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseDetalleFechaCobro
            // 
            this.DesgloseDetalleFechaCobro.Dpi = 100F;
            this.DesgloseDetalleFechaCobro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseDetalleFechaCobro.LocationFloat = new DevExpress.Utils.PointFloat(651.4633F, 0F);
            this.DesgloseDetalleFechaCobro.Multiline = true;
            this.DesgloseDetalleFechaCobro.Name = "DesgloseDetalleFechaCobro";
            this.DesgloseDetalleFechaCobro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseDetalleFechaCobro.SizeF = new System.Drawing.SizeF(84.224F, 15.00012F);
            this.DesgloseDetalleFechaCobro.StylePriority.UseFont = false;
            this.DesgloseDetalleFechaCobro.StylePriority.UseTextAlignment = false;
            this.DesgloseDetalleFechaCobro.Text = "Fecha Cobro";
            this.DesgloseDetalleFechaCobro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseDetalleImporte
            // 
            this.DesgloseDetalleImporte.Dpi = 100F;
            this.DesgloseDetalleImporte.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseDetalleImporte.LocationFloat = new DevExpress.Utils.PointFloat(741.318F, 0F);
            this.DesgloseDetalleImporte.Multiline = true;
            this.DesgloseDetalleImporte.Name = "DesgloseDetalleImporte";
            this.DesgloseDetalleImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseDetalleImporte.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.DesgloseDetalleImporte.StylePriority.UseFont = false;
            this.DesgloseDetalleImporte.StylePriority.UseTextAlignment = false;
            this.DesgloseDetalleImporte.Text = "Importe";
            this.DesgloseDetalleImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseDetalleDenominacion
            // 
            this.DesgloseDetalleDenominacion.Dpi = 100F;
            this.DesgloseDetalleDenominacion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseDetalleDenominacion.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DesgloseDetalleDenominacion.Name = "DesgloseDetalleDenominacion";
            this.DesgloseDetalleDenominacion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseDetalleDenominacion.SizeF = new System.Drawing.SizeF(86.2085F, 15.00009F);
            this.DesgloseDetalleDenominacion.StylePriority.UseFont = false;
            this.DesgloseDetalleDenominacion.StylePriority.UseTextAlignment = false;
            this.DesgloseDetalleDenominacion.Text = "Denominacion";
            this.DesgloseDetalleDenominacion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseDetalleCantidad
            // 
            this.DesgloseDetalleCantidad.Dpi = 100F;
            this.DesgloseDetalleCantidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseDetalleCantidad.LocationFloat = new DevExpress.Utils.PointFloat(88.33344F, 0F);
            this.DesgloseDetalleCantidad.Multiline = true;
            this.DesgloseDetalleCantidad.Name = "DesgloseDetalleCantidad";
            this.DesgloseDetalleCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseDetalleCantidad.SizeF = new System.Drawing.SizeF(123.1665F, 15.00011F);
            this.DesgloseDetalleCantidad.StylePriority.UseFont = false;
            this.DesgloseDetalleCantidad.StylePriority.UseTextAlignment = false;
            this.DesgloseDetalleCantidad.Text = "Cantidad";
            this.DesgloseDetalleCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseDetalleTotal
            // 
            this.DesgloseDetalleTotal.Dpi = 100F;
            this.DesgloseDetalleTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseDetalleTotal.LocationFloat = new DevExpress.Utils.PointFloat(211.4999F, 0F);
            this.DesgloseDetalleTotal.Multiline = true;
            this.DesgloseDetalleTotal.Name = "DesgloseDetalleTotal";
            this.DesgloseDetalleTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseDetalleTotal.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.DesgloseDetalleTotal.StylePriority.UseFont = false;
            this.DesgloseDetalleTotal.StylePriority.UseTextAlignment = false;
            this.DesgloseDetalleTotal.Text = "Total";
            this.DesgloseDetalleTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader5
            // 
            this.ReportHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel48,
            this.xrLabel41,
            this.xrLabel42,
            this.xrLabel46,
            this.xrLabel47,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39,
            this.xrLabel40});
            this.ReportHeader5.Dpi = 100F;
            this.ReportHeader5.HeightF = 37.50003F;
            this.ReportHeader5.Name = "ReportHeader5";
            // 
            // xrLabel48
            // 
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(743.7751F, 22.49991F);
            this.xrLabel48.Multiline = true;
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            this.xrLabel48.Text = "Importe";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(422.0052F, 0F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(157.5662F, 16.75F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.Text = "Desglose de Documentos";
            // 
            // xrLabel42
            // 
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(440.8799F, 22.49985F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(86.2085F, 15.00009F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "Banco";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(528.297F, 21.99987F);
            this.xrLabel46.Multiline = true;
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(123.1665F, 15.00011F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "Referencia";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel47
            // 
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(651.4633F, 22.49985F);
            this.xrLabel47.Multiline = true;
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(84.68231F, 15.00012F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "Fecha Cobro";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(104.1666F, 16.75F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.Text = "Desglose Efectivo";
            // 
            // xrLabel38
            // 
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(18.58457F, 22.49985F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(68.08233F, 15.00009F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "Importe";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(105.543F, 21.99987F);
            this.xrLabel39.Multiline = true;
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(105.4986F, 15.00011F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "Cantidad";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(211.4999F, 22.49985F);
            this.xrLabel40.Multiline = true;
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "Total";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Kilometraje
            // 
            this.Kilometraje.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail7,
            this.ReportHeader6});
            this.Kilometraje.Dpi = 100F;
            this.Kilometraje.Level = 8;
            this.Kilometraje.Name = "Kilometraje";
            // 
            // Detail7
            // 
            this.Detail7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.KDetalleRecorrido,
            this.KDetalleFinal,
            this.KDetalleInicial});
            this.Detail7.Dpi = 100F;
            this.Detail7.HeightF = 15.50007F;
            this.Detail7.Name = "Detail7";
            // 
            // KDetalleRecorrido
            // 
            this.KDetalleRecorrido.Dpi = 100F;
            this.KDetalleRecorrido.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KDetalleRecorrido.LocationFloat = new DevExpress.Utils.PointFloat(210.5787F, 0F);
            this.KDetalleRecorrido.Multiline = true;
            this.KDetalleRecorrido.Name = "KDetalleRecorrido";
            this.KDetalleRecorrido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.KDetalleRecorrido.SizeF = new System.Drawing.SizeF(87.03633F, 15.00012F);
            this.KDetalleRecorrido.StylePriority.UseFont = false;
            this.KDetalleRecorrido.StylePriority.UseTextAlignment = false;
            this.KDetalleRecorrido.Text = "Km Recorrido";
            this.KDetalleRecorrido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // KDetalleFinal
            // 
            this.KDetalleFinal.Dpi = 100F;
            this.KDetalleFinal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KDetalleFinal.LocationFloat = new DevExpress.Utils.PointFloat(105.543F, 0F);
            this.KDetalleFinal.Multiline = true;
            this.KDetalleFinal.Name = "KDetalleFinal";
            this.KDetalleFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.KDetalleFinal.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.KDetalleFinal.StylePriority.UseFont = false;
            this.KDetalleFinal.StylePriority.UseTextAlignment = false;
            this.KDetalleFinal.Text = "Km Final";
            this.KDetalleFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // KDetalleInicial
            // 
            this.KDetalleInicial.Dpi = 100F;
            this.KDetalleInicial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KDetalleInicial.LocationFloat = new DevExpress.Utils.PointFloat(18.58457F, 0.4999796F);
            this.KDetalleInicial.Name = "KDetalleInicial";
            this.KDetalleInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.KDetalleInicial.SizeF = new System.Drawing.SizeF(75.0406F, 15.00009F);
            this.KDetalleInicial.StylePriority.UseFont = false;
            this.KDetalleInicial.StylePriority.UseTextAlignment = false;
            this.KDetalleInicial.Text = "Km Inicial";
            this.KDetalleInicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader6
            // 
            this.ReportHeader6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel69,
            this.xrLabel70,
            this.xrLabel71,
            this.xrLabel68});
            this.ReportHeader6.Dpi = 100F;
            this.ReportHeader6.HeightF = 45.83333F;
            this.ReportHeader6.Name = "ReportHeader6";
            // 
            // xrLabel69
            // 
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(18.58457F, 28.12487F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(75.0406F, 15.00009F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "Km Inicial";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel70
            // 
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(105.543F, 27.62489F);
            this.xrLabel70.Multiline = true;
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.Text = "Km Final";
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel71
            // 
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(210.5787F, 27.62489F);
            this.xrLabel71.Multiline = true;
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(87.03633F, 15.00012F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            this.xrLabel71.Text = "Km Recorrido";
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel68
            // 
            this.xrLabel68.Dpi = 100F;
            this.xrLabel68.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(0.9166718F, 0F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(104.1666F, 16.75F);
            this.xrLabel68.StylePriority.UseFont = false;
            this.xrLabel68.Text = "Kilómetros";
            // 
            // Agendados
            // 
            this.Agendados.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail8,
            this.ReportHeader7});
            this.Agendados.Dpi = 100F;
            this.Agendados.Level = 9;
            this.Agendados.Name = "Agendados";
            // 
            // Detail8
            // 
            this.Detail8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel83,
            this.xrLabel84,
            this.xrLabel85,
            this.AgendaRutaDetalleEficiencia,
            this.AgendaDetalleSinVenta,
            this.AgendaDetalleConVenta,
            this.AgendaDetalleEficiencia,
            this.AgendaDetalleNoVisitados,
            this.AgendaDetalleVisitados,
            this.AgendaDetalleClientes,
            this.xrLabel77,
            this.xrLabel78,
            this.xrLabel76,
            this.xrLabel75});
            this.Detail8.Dpi = 100F;
            this.Detail8.HeightF = 101.9793F;
            this.Detail8.Name = "Detail8";
            // 
            // xrLabel83
            // 
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(423.204F, 9.999974F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.Text = "Visitados con Venta";
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel84
            // 
            this.xrLabel84.Dpi = 100F;
            this.xrLabel84.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(422.4813F, 35.41667F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel84.StylePriority.UseFont = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            this.xrLabel84.Text = "Visitados sin Venta";
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel85
            // 
            this.xrLabel85.Dpi = 100F;
            this.xrLabel85.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel85.LocationFloat = new DevExpress.Utils.PointFloat(421.0841F, 61.56247F);
            this.xrLabel85.Name = "xrLabel85";
            this.xrLabel85.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel85.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel85.StylePriority.UseFont = false;
            this.xrLabel85.StylePriority.UseTextAlignment = false;
            this.xrLabel85.Text = "Porcentaje Eficiencia";
            this.xrLabel85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AgendaRutaDetalleEficiencia
            // 
            this.AgendaRutaDetalleEficiencia.Dpi = 100F;
            this.AgendaRutaDetalleEficiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaRutaDetalleEficiencia.LocationFloat = new DevExpress.Utils.PointFloat(618.6582F, 61.56247F);
            this.AgendaRutaDetalleEficiencia.Multiline = true;
            this.AgendaRutaDetalleEficiencia.Name = "AgendaRutaDetalleEficiencia";
            this.AgendaRutaDetalleEficiencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgendaRutaDetalleEficiencia.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.AgendaRutaDetalleEficiencia.StylePriority.UseFont = false;
            this.AgendaRutaDetalleEficiencia.StylePriority.UseTextAlignment = false;
            this.AgendaRutaDetalleEficiencia.Text = "Eficiencia";
            this.AgendaRutaDetalleEficiencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // AgendaDetalleSinVenta
            // 
            this.AgendaDetalleSinVenta.Dpi = 100F;
            this.AgendaDetalleSinVenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaDetalleSinVenta.LocationFloat = new DevExpress.Utils.PointFloat(619.5796F, 35.41667F);
            this.AgendaDetalleSinVenta.Multiline = true;
            this.AgendaDetalleSinVenta.Name = "AgendaDetalleSinVenta";
            this.AgendaDetalleSinVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgendaDetalleSinVenta.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.AgendaDetalleSinVenta.StylePriority.UseFont = false;
            this.AgendaDetalleSinVenta.StylePriority.UseTextAlignment = false;
            this.AgendaDetalleSinVenta.Text = "sin venta";
            this.AgendaDetalleSinVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // AgendaDetalleConVenta
            // 
            this.AgendaDetalleConVenta.Dpi = 100F;
            this.AgendaDetalleConVenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaDetalleConVenta.LocationFloat = new DevExpress.Utils.PointFloat(619.5796F, 9.999974F);
            this.AgendaDetalleConVenta.Multiline = true;
            this.AgendaDetalleConVenta.Name = "AgendaDetalleConVenta";
            this.AgendaDetalleConVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgendaDetalleConVenta.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.AgendaDetalleConVenta.StylePriority.UseFont = false;
            this.AgendaDetalleConVenta.StylePriority.UseTextAlignment = false;
            this.AgendaDetalleConVenta.Text = "con venta";
            this.AgendaDetalleConVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // AgendaDetalleEficiencia
            // 
            this.AgendaDetalleEficiencia.Dpi = 100F;
            this.AgendaDetalleEficiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaDetalleEficiencia.LocationFloat = new DevExpress.Utils.PointFloat(197.5744F, 86.97916F);
            this.AgendaDetalleEficiencia.Multiline = true;
            this.AgendaDetalleEficiencia.Name = "AgendaDetalleEficiencia";
            this.AgendaDetalleEficiencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgendaDetalleEficiencia.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.AgendaDetalleEficiencia.StylePriority.UseFont = false;
            this.AgendaDetalleEficiencia.StylePriority.UseTextAlignment = false;
            this.AgendaDetalleEficiencia.Text = "Eficiencia";
            this.AgendaDetalleEficiencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // AgendaDetalleNoVisitados
            // 
            this.AgendaDetalleNoVisitados.Dpi = 100F;
            this.AgendaDetalleNoVisitados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaDetalleNoVisitados.LocationFloat = new DevExpress.Utils.PointFloat(197.5744F, 61.56247F);
            this.AgendaDetalleNoVisitados.Multiline = true;
            this.AgendaDetalleNoVisitados.Name = "AgendaDetalleNoVisitados";
            this.AgendaDetalleNoVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgendaDetalleNoVisitados.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.AgendaDetalleNoVisitados.StylePriority.UseFont = false;
            this.AgendaDetalleNoVisitados.StylePriority.UseTextAlignment = false;
            this.AgendaDetalleNoVisitados.Text = "No Visitados";
            this.AgendaDetalleNoVisitados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // AgendaDetalleVisitados
            // 
            this.AgendaDetalleVisitados.Dpi = 100F;
            this.AgendaDetalleVisitados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaDetalleVisitados.LocationFloat = new DevExpress.Utils.PointFloat(198.4957F, 35.41667F);
            this.AgendaDetalleVisitados.Multiline = true;
            this.AgendaDetalleVisitados.Name = "AgendaDetalleVisitados";
            this.AgendaDetalleVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgendaDetalleVisitados.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.AgendaDetalleVisitados.StylePriority.UseFont = false;
            this.AgendaDetalleVisitados.StylePriority.UseTextAlignment = false;
            this.AgendaDetalleVisitados.Text = "Visitados";
            this.AgendaDetalleVisitados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // AgendaDetalleClientes
            // 
            this.AgendaDetalleClientes.Dpi = 100F;
            this.AgendaDetalleClientes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaDetalleClientes.LocationFloat = new DevExpress.Utils.PointFloat(198.4957F, 9.999974F);
            this.AgendaDetalleClientes.Multiline = true;
            this.AgendaDetalleClientes.Name = "AgendaDetalleClientes";
            this.AgendaDetalleClientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgendaDetalleClientes.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.AgendaDetalleClientes.StylePriority.UseFont = false;
            this.AgendaDetalleClientes.StylePriority.UseTextAlignment = false;
            this.AgendaDetalleClientes.Text = "Clientes";
            this.AgendaDetalleClientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel77
            // 
            this.xrLabel77.Dpi = 100F;
            this.xrLabel77.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel77.LocationFloat = new DevExpress.Utils.PointFloat(0F, 86.97916F);
            this.xrLabel77.Name = "xrLabel77";
            this.xrLabel77.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel77.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel77.StylePriority.UseFont = false;
            this.xrLabel77.StylePriority.UseTextAlignment = false;
            this.xrLabel77.Text = "Porcentaje Eficiencia";
            this.xrLabel77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel78
            // 
            this.xrLabel78.Dpi = 100F;
            this.xrLabel78.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(0F, 61.56247F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel78.StylePriority.UseFont = false;
            this.xrLabel78.StylePriority.UseTextAlignment = false;
            this.xrLabel78.Text = "Clientes No Visitados";
            this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel76
            // 
            this.xrLabel76.Dpi = 100F;
            this.xrLabel76.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel76.LocationFloat = new DevExpress.Utils.PointFloat(1.397196F, 35.41667F);
            this.xrLabel76.Name = "xrLabel76";
            this.xrLabel76.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel76.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel76.StylePriority.UseFont = false;
            this.xrLabel76.StylePriority.UseTextAlignment = false;
            this.xrLabel76.Text = "Clientes Visitados";
            this.xrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel75
            // 
            this.xrLabel75.Dpi = 100F;
            this.xrLabel75.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(2.120082F, 9.999974F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel75.StylePriority.UseFont = false;
            this.xrLabel75.StylePriority.UseTextAlignment = false;
            this.xrLabel75.Text = "Total de Clientes";
            this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportHeader7
            // 
            this.ReportHeader7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel73,
            this.xrLabel74,
            this.xrLine12,
            this.xrLine13,
            this.xrLabel72});
            this.ReportHeader7.Dpi = 100F;
            this.ReportHeader7.HeightF = 50F;
            this.ReportHeader7.KeepTogether = true;
            this.ReportHeader7.Name = "ReportHeader7";
            // 
            // xrLabel73
            // 
            this.xrLabel73.Dpi = 100F;
            this.xrLabel73.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.12493F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(105.6299F, 15.0001F);
            this.xrLabel73.StylePriority.UseFont = false;
            this.xrLabel73.StylePriority.UseTextAlignment = false;
            this.xrLabel73.Text = "Total General";
            this.xrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel74
            // 
            this.xrLabel74.Dpi = 100F;
            this.xrLabel74.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(422.0052F, 25.12493F);
            this.xrLabel74.Multiline = true;
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(93.6655F, 15.00011F);
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.StylePriority.UseTextAlignment = false;
            this.xrLabel74.Text = "Visitas en Ruta";
            this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine12
            // 
            this.xrLine12.Dpi = 100F;
            this.xrLine12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40.12505F);
            this.xrLine12.Name = "xrLine12";
            this.xrLine12.SizeF = new System.Drawing.SizeF(819.4167F, 8.500069F);
            // 
            // xrLine13
            // 
            this.xrLine13.Dpi = 100F;
            this.xrLine13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 16.74999F);
            this.xrLine13.Name = "xrLine13";
            this.xrLine13.SizeF = new System.Drawing.SizeF(819.8799F, 8.374959F);
            // 
            // xrLabel72
            // 
            this.xrLabel72.Dpi = 100F;
            this.xrLabel72.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(54.1666F, 16.75F);
            this.xrLabel72.StylePriority.UseFont = false;
            this.xrLabel72.Text = "Visitas";
            // 
            // NoAgendadosTiempos
            // 
            this.NoAgendadosTiempos.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail9,
            this.ReportHeader8,
            this.ReportFooter6});
            this.NoAgendadosTiempos.Dpi = 100F;
            this.NoAgendadosTiempos.Level = 10;
            this.NoAgendadosTiempos.Name = "NoAgendadosTiempos";
            // 
            // Detail9
            // 
            this.Detail9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TiemposDetalleTiempoTotal,
            this.TiemposDetalleTiempoVisita,
            this.xrLabel92,
            this.xrLabel93,
            this.TiemposDetalleTiempoTransito,
            this.xrLabel95,
            this.xrLabel81,
            this.NoAgendadosDetalleFueraRuta,
            this.NoAgendadosDetalleFueraRutaVenta,
            this.xrLabel87,
            this.xrLabel88,
            this.NoAgendadosDetalleEficiencia});
            this.Detail9.Dpi = 100F;
            this.Detail9.HeightF = 76.56258F;
            this.Detail9.Name = "Detail9";
            // 
            // TiemposDetalleTiempoTotal
            // 
            this.TiemposDetalleTiempoTotal.Dpi = 100F;
            this.TiemposDetalleTiempoTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiemposDetalleTiempoTotal.LocationFloat = new DevExpress.Utils.PointFloat(620.5058F, 0F);
            this.TiemposDetalleTiempoTotal.Multiline = true;
            this.TiemposDetalleTiempoTotal.Name = "TiemposDetalleTiempoTotal";
            this.TiemposDetalleTiempoTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TiemposDetalleTiempoTotal.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.TiemposDetalleTiempoTotal.StylePriority.UseFont = false;
            this.TiemposDetalleTiempoTotal.StylePriority.UseTextAlignment = false;
            this.TiemposDetalleTiempoTotal.Text = "TiempoTotal";
            this.TiemposDetalleTiempoTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TiemposDetalleTiempoVisita
            // 
            this.TiemposDetalleTiempoVisita.Dpi = 100F;
            this.TiemposDetalleTiempoVisita.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiemposDetalleTiempoVisita.LocationFloat = new DevExpress.Utils.PointFloat(620.5058F, 25.41669F);
            this.TiemposDetalleTiempoVisita.Multiline = true;
            this.TiemposDetalleTiempoVisita.Name = "TiemposDetalleTiempoVisita";
            this.TiemposDetalleTiempoVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TiemposDetalleTiempoVisita.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.TiemposDetalleTiempoVisita.StylePriority.UseFont = false;
            this.TiemposDetalleTiempoVisita.StylePriority.UseTextAlignment = false;
            this.TiemposDetalleTiempoVisita.Text = "TiempoVisita";
            this.TiemposDetalleTiempoVisita.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel92
            // 
            this.xrLabel92.Dpi = 100F;
            this.xrLabel92.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel92.LocationFloat = new DevExpress.Utils.PointFloat(424.1302F, 25.41669F);
            this.xrLabel92.Name = "xrLabel92";
            this.xrLabel92.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel92.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel92.StylePriority.UseFont = false;
            this.xrLabel92.StylePriority.UseTextAlignment = false;
            this.xrLabel92.Text = "Tiempos de Visita";
            this.xrLabel92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel93
            // 
            this.xrLabel93.Dpi = 100F;
            this.xrLabel93.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel93.LocationFloat = new DevExpress.Utils.PointFloat(424.1302F, 51.5625F);
            this.xrLabel93.Name = "xrLabel93";
            this.xrLabel93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel93.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel93.StylePriority.UseFont = false;
            this.xrLabel93.StylePriority.UseTextAlignment = false;
            this.xrLabel93.Text = "Tiempo Transito";
            this.xrLabel93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TiemposDetalleTiempoTransito
            // 
            this.TiemposDetalleTiempoTransito.Dpi = 100F;
            this.TiemposDetalleTiempoTransito.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiemposDetalleTiempoTransito.LocationFloat = new DevExpress.Utils.PointFloat(619.5844F, 51.5625F);
            this.TiemposDetalleTiempoTransito.Multiline = true;
            this.TiemposDetalleTiempoTransito.Name = "TiemposDetalleTiempoTransito";
            this.TiemposDetalleTiempoTransito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TiemposDetalleTiempoTransito.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.TiemposDetalleTiempoTransito.StylePriority.UseFont = false;
            this.TiemposDetalleTiempoTransito.StylePriority.UseTextAlignment = false;
            this.TiemposDetalleTiempoTransito.Text = "TiempoTransito";
            this.TiemposDetalleTiempoTransito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel95
            // 
            this.xrLabel95.Dpi = 100F;
            this.xrLabel95.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel95.LocationFloat = new DevExpress.Utils.PointFloat(424.1302F, 0F);
            this.xrLabel95.Name = "xrLabel95";
            this.xrLabel95.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel95.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel95.StylePriority.UseFont = false;
            this.xrLabel95.StylePriority.UseTextAlignment = false;
            this.xrLabel95.Text = "Tiempo Total";
            this.xrLabel95.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel81
            // 
            this.xrLabel81.Dpi = 100F;
            this.xrLabel81.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel81.Name = "xrLabel81";
            this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel81.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel81.StylePriority.UseFont = false;
            this.xrLabel81.StylePriority.UseTextAlignment = false;
            this.xrLabel81.Text = "Fuera de Ruta";
            this.xrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // NoAgendadosDetalleFueraRuta
            // 
            this.NoAgendadosDetalleFueraRuta.Dpi = 100F;
            this.NoAgendadosDetalleFueraRuta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAgendadosDetalleFueraRuta.LocationFloat = new DevExpress.Utils.PointFloat(196.3755F, 0F);
            this.NoAgendadosDetalleFueraRuta.Multiline = true;
            this.NoAgendadosDetalleFueraRuta.Name = "NoAgendadosDetalleFueraRuta";
            this.NoAgendadosDetalleFueraRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NoAgendadosDetalleFueraRuta.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.NoAgendadosDetalleFueraRuta.StylePriority.UseFont = false;
            this.NoAgendadosDetalleFueraRuta.StylePriority.UseTextAlignment = false;
            this.NoAgendadosDetalleFueraRuta.Text = "FueraRuta";
            this.NoAgendadosDetalleFueraRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // NoAgendadosDetalleFueraRutaVenta
            // 
            this.NoAgendadosDetalleFueraRutaVenta.Dpi = 100F;
            this.NoAgendadosDetalleFueraRutaVenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAgendadosDetalleFueraRutaVenta.LocationFloat = new DevExpress.Utils.PointFloat(196.3755F, 25.41669F);
            this.NoAgendadosDetalleFueraRutaVenta.Multiline = true;
            this.NoAgendadosDetalleFueraRutaVenta.Name = "NoAgendadosDetalleFueraRutaVenta";
            this.NoAgendadosDetalleFueraRutaVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NoAgendadosDetalleFueraRutaVenta.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.NoAgendadosDetalleFueraRutaVenta.StylePriority.UseFont = false;
            this.NoAgendadosDetalleFueraRutaVenta.StylePriority.UseTextAlignment = false;
            this.NoAgendadosDetalleFueraRutaVenta.Text = "FueraRutaventa";
            this.NoAgendadosDetalleFueraRutaVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel87
            // 
            this.xrLabel87.Dpi = 100F;
            this.xrLabel87.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.41669F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel87.StylePriority.UseFont = false;
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            this.xrLabel87.Text = "Fuera de Ruta Venta";
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel88
            // 
            this.xrLabel88.Dpi = 100F;
            this.xrLabel88.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(0F, 51.5625F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(158.1456F, 15.00009F);
            this.xrLabel88.StylePriority.UseFont = false;
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            this.xrLabel88.Text = "Porcentaje Eficiencia";
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // NoAgendadosDetalleEficiencia
            // 
            this.NoAgendadosDetalleEficiencia.Dpi = 100F;
            this.NoAgendadosDetalleEficiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAgendadosDetalleEficiencia.LocationFloat = new DevExpress.Utils.PointFloat(195.4541F, 51.5625F);
            this.NoAgendadosDetalleEficiencia.Multiline = true;
            this.NoAgendadosDetalleEficiencia.Name = "NoAgendadosDetalleEficiencia";
            this.NoAgendadosDetalleEficiencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NoAgendadosDetalleEficiencia.SizeF = new System.Drawing.SizeF(88.45713F, 15.00011F);
            this.NoAgendadosDetalleEficiencia.StylePriority.UseFont = false;
            this.NoAgendadosDetalleEficiencia.StylePriority.UseTextAlignment = false;
            this.NoAgendadosDetalleEficiencia.Text = "Eficiencia";
            this.NoAgendadosDetalleEficiencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader8
            // 
            this.ReportHeader8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine14,
            this.xrLabel79,
            this.xrLabel80,
            this.xrLine15});
            this.ReportHeader8.Dpi = 100F;
            this.ReportHeader8.HeightF = 31.87514F;
            this.ReportHeader8.KeepTogether = true;
            this.ReportHeader8.Name = "ReportHeader8";
            // 
            // xrLine14
            // 
            this.xrLine14.Dpi = 100F;
            this.xrLine14.LocationFloat = new DevExpress.Utils.PointFloat(0.6017049F, 0F);
            this.xrLine14.Name = "xrLine14";
            this.xrLine14.SizeF = new System.Drawing.SizeF(819.8799F, 8.374959F);
            // 
            // xrLabel79
            // 
            this.xrLabel79.Dpi = 100F;
            this.xrLabel79.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.374913F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(141.1874F, 15.00009F);
            this.xrLabel79.StylePriority.UseFont = false;
            this.xrLabel79.StylePriority.UseTextAlignment = false;
            this.xrLabel79.Text = "Visitas Fuera de Ruta";
            this.xrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel80
            // 
            this.xrLabel80.Dpi = 100F;
            this.xrLabel80.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel80.LocationFloat = new DevExpress.Utils.PointFloat(421.2321F, 8.374913F);
            this.xrLabel80.Multiline = true;
            this.xrLabel80.Name = "xrLabel80";
            this.xrLabel80.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel80.SizeF = new System.Drawing.SizeF(117.898F, 15.00011F);
            this.xrLabel80.StylePriority.UseFont = false;
            this.xrLabel80.StylePriority.UseTextAlignment = false;
            this.xrLabel80.Text = "Tiempos de Visita";
            this.xrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine15
            // 
            this.xrLine15.Dpi = 100F;
            this.xrLine15.LocationFloat = new DevExpress.Utils.PointFloat(0.6017049F, 23.37507F);
            this.xrLine15.Name = "xrLine15";
            this.xrLine15.SizeF = new System.Drawing.SizeF(819.4167F, 8.500069F);
            // 
            // ReportFooter6
            // 
            this.ReportFooter6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.footerCedi,
            this.footerVendedor,
            this.xrLine17,
            this.xrLine16});
            this.ReportFooter6.Dpi = 100F;
            this.ReportFooter6.HeightF = 100F;
            this.ReportFooter6.KeepTogether = true;
            this.ReportFooter6.Name = "ReportFooter6";
            this.ReportFooter6.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // footerCedi
            // 
            this.footerCedi.Dpi = 100F;
            this.footerCedi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footerCedi.LocationFloat = new DevExpress.Utils.PointFloat(455.3899F, 65.70841F);
            this.footerCedi.Name = "footerCedi";
            this.footerCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.footerCedi.SizeF = new System.Drawing.SizeF(306.3333F, 15.00009F);
            this.footerCedi.StylePriority.UseFont = false;
            this.footerCedi.StylePriority.UseTextAlignment = false;
            this.footerCedi.Text = "Cedi";
            this.footerCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // footerVendedor
            // 
            this.footerVendedor.Dpi = 100F;
            this.footerVendedor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footerVendedor.LocationFloat = new DevExpress.Utils.PointFloat(48.3228F, 65.70841F);
            this.footerVendedor.Name = "footerVendedor";
            this.footerVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.footerVendedor.SizeF = new System.Drawing.SizeF(306.3333F, 15.00009F);
            this.footerVendedor.StylePriority.UseFont = false;
            this.footerVendedor.StylePriority.UseTextAlignment = false;
            this.footerVendedor.Text = "Vendedor";
            this.footerVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine17
            // 
            this.xrLine17.Dpi = 100F;
            this.xrLine17.LocationFloat = new DevExpress.Utils.PointFloat(455.8482F, 59.375F);
            this.xrLine17.Name = "xrLine17";
            this.xrLine17.SizeF = new System.Drawing.SizeF(305.875F, 6.33334F);
            // 
            // xrLine16
            // 
            this.xrLine16.Dpi = 100F;
            this.xrLine16.LocationFloat = new DevExpress.Utils.PointFloat(48.78108F, 59.375F);
            this.xrLine16.Name = "xrLine16";
            this.xrLine16.SizeF = new System.Drawing.SizeF(305.875F, 6.33334F);
            // 
            // TotalCobranza
            // 
            this.TotalCobranza.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail10});
            this.TotalCobranza.Dpi = 100F;
            this.TotalCobranza.Level = 5;
            this.TotalCobranza.Name = "TotalCobranza";
            // 
            // Detail10
            // 
            this.Detail10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel54,
            this.CCreditoTotalCobranza});
            this.Detail10.Dpi = 100F;
            this.Detail10.HeightF = 16.75F;
            this.Detail10.Name = "Detail10";
            // 
            // xrLabel54
            // 
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(373.4763F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(193.3825F, 16.75F);
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.Text = "Total Cobranza";
            // 
            // CCreditoTotalCobranza
            // 
            this.CCreditoTotalCobranza.Dpi = 100F;
            this.CCreditoTotalCobranza.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCreditoTotalCobranza.LocationFloat = new DevExpress.Utils.PointFloat(566.8586F, 0F);
            this.CCreditoTotalCobranza.Name = "CCreditoTotalCobranza";
            this.CCreditoTotalCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CCreditoTotalCobranza.SizeF = new System.Drawing.SizeF(109.9007F, 16.75F);
            this.CCreditoTotalCobranza.StylePriority.UseFont = false;
            this.CCreditoTotalCobranza.StylePriority.UseTextAlignment = false;
            this.CCreditoTotalCobranza.Text = "Total Cobranza";
            this.CCreditoTotalCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TotalDesglose
            // 
            this.TotalDesglose.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail11});
            this.TotalDesglose.Dpi = 100F;
            this.TotalDesglose.Level = 7;
            this.TotalDesglose.Name = "TotalDesglose";
            // 
            // Detail11
            // 
            this.Detail11.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine9,
            this.xrLabel50,
            this.TotalImporteDocumentos,
            this.TotalesTotalCobranza,
            this.TotalesTotalEfectivo,
            this.xrLabel63,
            this.xrLabel60,
            this.xrLine11,
            this.TotalesTotalDesglose,
            this.DesgloseEfectivoTotal,
            this.TotalesTotalDocumentos,
            this.xrLabel65,
            this.TotalesTotalContado,
            this.TotalesTotalCredito,
            this.xrLine10,
            this.xrLabel67,
            this.xrLabel57,
            this.xrLabel56});
            this.Detail11.Dpi = 100F;
            this.Detail11.HeightF = 120.8333F;
            this.Detail11.Name = "Detail11";
            // 
            // xrLine9
            // 
            this.xrLine9.Dpi = 100F;
            this.xrLine9.LocationFloat = new DevExpress.Utils.PointFloat(9.790294F, 0F);
            this.xrLine9.Name = "xrLine9";
            this.xrLine9.SizeF = new System.Drawing.SizeF(305.875F, 6.33334F);
            // 
            // xrLabel50
            // 
            this.xrLabel50.Dpi = 100F;
            this.xrLabel50.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(575.0941F, 0F);
            this.xrLabel50.Multiline = true;
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(136.9204F, 15.00012F);
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            this.xrLabel50.Text = "Total Documentos";
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TotalImporteDocumentos
            // 
            this.TotalImporteDocumentos.Dpi = 100F;
            this.TotalImporteDocumentos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImporteDocumentos.LocationFloat = new DevExpress.Utils.PointFloat(736.7065F, 0F);
            this.TotalImporteDocumentos.Multiline = true;
            this.TotalImporteDocumentos.Name = "TotalImporteDocumentos";
            this.TotalImporteDocumentos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalImporteDocumentos.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.TotalImporteDocumentos.StylePriority.UseFont = false;
            this.TotalImporteDocumentos.StylePriority.UseTextAlignment = false;
            this.TotalImporteDocumentos.Text = "Importe";
            this.TotalImporteDocumentos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TotalesTotalCobranza
            // 
            this.TotalesTotalCobranza.Dpi = 100F;
            this.TotalesTotalCobranza.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalesTotalCobranza.LocationFloat = new DevExpress.Utils.PointFloat(220.369F, 98.54151F);
            this.TotalesTotalCobranza.Multiline = true;
            this.TotalesTotalCobranza.Name = "TotalesTotalCobranza";
            this.TotalesTotalCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalesTotalCobranza.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.TotalesTotalCobranza.StylePriority.UseFont = false;
            this.TotalesTotalCobranza.StylePriority.UseTextAlignment = false;
            this.TotalesTotalCobranza.Text = "Total";
            this.TotalesTotalCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TotalesTotalEfectivo
            // 
            this.TotalesTotalEfectivo.Dpi = 100F;
            this.TotalesTotalEfectivo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalesTotalEfectivo.LocationFloat = new DevExpress.Utils.PointFloat(643.2905F, 62.08305F);
            this.TotalesTotalEfectivo.Multiline = true;
            this.TotalesTotalEfectivo.Name = "TotalesTotalEfectivo";
            this.TotalesTotalEfectivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalesTotalEfectivo.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.TotalesTotalEfectivo.StylePriority.UseFont = false;
            this.TotalesTotalEfectivo.StylePriority.UseTextAlignment = false;
            this.TotalesTotalEfectivo.Text = "TotalContado";
            this.TotalesTotalEfectivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel63
            // 
            this.xrLabel63.Dpi = 100F;
            this.xrLabel63.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(431.7955F, 62.08305F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(160.2707F, 15.00009F);
            this.xrLabel63.StylePriority.UseFont = false;
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.Text = "Total Desglose de Efectivo";
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel60
            // 
            this.xrLabel60.Dpi = 100F;
            this.xrLabel60.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(9.790294F, 98.54151F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(160.2707F, 15.00009F);
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "Total Cobranza";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine11
            // 
            this.xrLine11.Dpi = 100F;
            this.xrLine11.LocationFloat = new DevExpress.Utils.PointFloat(431.7955F, 92.08323F);
            this.xrLine11.Name = "xrLine11";
            this.xrLine11.SizeF = new System.Drawing.SizeF(305.875F, 6.33334F);
            // 
            // TotalesTotalDesglose
            // 
            this.TotalesTotalDesglose.Dpi = 100F;
            this.TotalesTotalDesglose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalesTotalDesglose.LocationFloat = new DevExpress.Utils.PointFloat(642.3741F, 98.54151F);
            this.TotalesTotalDesglose.Multiline = true;
            this.TotalesTotalDesglose.Name = "TotalesTotalDesglose";
            this.TotalesTotalDesglose.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalesTotalDesglose.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.TotalesTotalDesglose.StylePriority.UseFont = false;
            this.TotalesTotalDesglose.StylePriority.UseTextAlignment = false;
            this.TotalesTotalDesglose.Text = "Total";
            this.TotalesTotalDesglose.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // DesgloseEfectivoTotal
            // 
            this.DesgloseEfectivoTotal.Dpi = 100F;
            this.DesgloseEfectivoTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesgloseEfectivoTotal.LocationFloat = new DevExpress.Utils.PointFloat(221.2902F, 6.333288F);
            this.DesgloseEfectivoTotal.Multiline = true;
            this.DesgloseEfectivoTotal.Name = "DesgloseEfectivoTotal";
            this.DesgloseEfectivoTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesgloseEfectivoTotal.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.DesgloseEfectivoTotal.StylePriority.UseFont = false;
            this.DesgloseEfectivoTotal.StylePriority.UseTextAlignment = false;
            this.DesgloseEfectivoTotal.Text = "GTotal";
            this.DesgloseEfectivoTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TotalesTotalDocumentos
            // 
            this.TotalesTotalDocumentos.Dpi = 100F;
            this.TotalesTotalDocumentos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalesTotalDocumentos.LocationFloat = new DevExpress.Utils.PointFloat(642.8325F, 77.08321F);
            this.TotalesTotalDocumentos.Multiline = true;
            this.TotalesTotalDocumentos.Name = "TotalesTotalDocumentos";
            this.TotalesTotalDocumentos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalesTotalDocumentos.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.TotalesTotalDocumentos.StylePriority.UseFont = false;
            this.TotalesTotalDocumentos.StylePriority.UseTextAlignment = false;
            this.TotalesTotalDocumentos.Text = "TotalCredito";
            this.TotalesTotalDocumentos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel65
            // 
            this.xrLabel65.Dpi = 100F;
            this.xrLabel65.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(431.7955F, 77.08321F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(160.2707F, 15.00009F);
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.Text = "Total Documentos";
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TotalesTotalContado
            // 
            this.TotalesTotalContado.Dpi = 100F;
            this.TotalesTotalContado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalesTotalContado.LocationFloat = new DevExpress.Utils.PointFloat(221.2851F, 62.08318F);
            this.TotalesTotalContado.Multiline = true;
            this.TotalesTotalContado.Name = "TotalesTotalContado";
            this.TotalesTotalContado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalesTotalContado.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.TotalesTotalContado.StylePriority.UseFont = false;
            this.TotalesTotalContado.StylePriority.UseTextAlignment = false;
            this.TotalesTotalContado.Text = "TotalContado";
            this.TotalesTotalContado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TotalesTotalCredito
            // 
            this.TotalesTotalCredito.Dpi = 100F;
            this.TotalesTotalCredito.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalesTotalCredito.LocationFloat = new DevExpress.Utils.PointFloat(220.8271F, 77.08321F);
            this.TotalesTotalCredito.Multiline = true;
            this.TotalesTotalCredito.Name = "TotalesTotalCredito";
            this.TotalesTotalCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalesTotalCredito.SizeF = new System.Drawing.SizeF(75.45284F, 15.00012F);
            this.TotalesTotalCredito.StylePriority.UseFont = false;
            this.TotalesTotalCredito.StylePriority.UseTextAlignment = false;
            this.TotalesTotalCredito.Text = "TotalCredito";
            this.TotalesTotalCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine10
            // 
            this.xrLine10.Dpi = 100F;
            this.xrLine10.LocationFloat = new DevExpress.Utils.PointFloat(9.790294F, 92.08336F);
            this.xrLine10.Name = "xrLine10";
            this.xrLine10.SizeF = new System.Drawing.SizeF(305.875F, 6.33334F);
            // 
            // xrLabel67
            // 
            this.xrLabel67.Dpi = 100F;
            this.xrLabel67.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(431.7955F, 98.54151F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(160.2707F, 15.00009F);
            this.xrLabel67.StylePriority.UseFont = false;
            this.xrLabel67.StylePriority.UseTextAlignment = false;
            this.xrLabel67.Text = "Total General / Liquido";
            this.xrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel57
            // 
            this.xrLabel57.Dpi = 100F;
            this.xrLabel57.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(9.790294F, 77.08321F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(160.2707F, 15.00009F);
            this.xrLabel57.StylePriority.UseFont = false;
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            this.xrLabel57.Text = "Cobranza Crédito";
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel56
            // 
            this.xrLabel56.Dpi = 100F;
            this.xrLabel56.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(9.790294F, 62.08318F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(160.2707F, 15.00009F);
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            this.xrLabel56.Text = "Cobranza Contado";
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReporteLiquidacionMOR2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderVendedor,
            this.VentasProducto,
            this.VentasContado,
            this.VentasCredito,
            this.CobranzaContado,
            this.CobranzaCredito,
            this.DesgloseEfectivoDocumentos,
            this.Kilometraje,
            this.Agendados,
            this.NoAgendadosTiempos,
            this.TotalCobranza,
            this.TotalDesglose});
            this.Margins = new System.Drawing.Printing.Margins(14, 12, 6, 112);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
