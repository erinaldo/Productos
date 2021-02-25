using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaGeneral
/// </summary>
public class efectividadPorRutaGeneral : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    public XRPictureBox logo1;
    public XRLabel Ruta;
    public XRLabel Vendedor;
    public XRLabel Fecha;
    public XRLabel CEDIS;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    public XRLabel tiempoTransito;
    public XRLabel tiempoVisita;
    public XRLabel tiempoRecorrido;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    public XRLabel lbRuta;
    public XRLabel lbVendedor;
    public XRLabel lbFecha;
    public XRLabel lbCEDIS;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLine xrLine1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    public XRLabel visitadosEnAgenda;
    public XRLabel lbEnAgendaVisitadosPorcent;
    public XRLabel xrLabel30;
    public XRLabel lbVisitadosFueraAgenda;
    public XRLabel lbNoVisitadosFueraAgenda;
    public XRLabel xrLabel25;
    public XRLabel lbEnAgendaNoVisitadosPorcent;
    public XRLabel noVisitadosEnAgenda;
    private XRLabel xrLabel17;
    public XRLabel lbTotalClientes;
    private XRLabel xrLabel15;
    private PageHeaderBand PageHeader;
    public XRLabel xrLabel21;
    public XRLabel xrLabel22;
    public XRLabel xrLabel23;
    public XRLabel xrLabel20;
    public XRLabel xrLabel19;
    public XRLabel xrLabel18;
    private XRLine xrLine3;
    private XRLine xrLine2;
    private XRLabel xrLabel16;
    private XRLabel xrLabel24;
    private XRLabel xrLabel27;
    public XRLabel lbTotalClientesVisitados;
    private XRLabel xrLabel31;
    public XRLabel lbClientesVisitadosSinVentaEnAgenda;
    public XRLabel lbClientesSinVentaEnAgendaPorcent;
    public XRLabel lbClientesSinVentaFueraAgendaPorcent;
    public XRLabel lbClientesVisitadosSinVentaFueraAgenta;
    public XRLabel lbClientesVisitadosConVentaFueraAgenta;
    public XRLabel lbClientesConVentaFueraAgendaPorcent;
    public XRLabel lbClientesConVentaEnAgendaPorcent;
    public XRLabel lbClientesVisitadosConVentaEnAgenda;
    public XRLabel lbClientesImproductivoEnAgenda;
    public XRLabel xrLabel36;
    public XRLabel xrLabel39;
    public XRLabel lbClientesImproductivoFueraAgenda;
    private XRLabel xrLabel26;
    private XRLabel xrLabel54;
    public XRLabel lbTotalEncuestas;
    public XRLabel lbEncuestasAplicadasFueraAgenda;
    public XRLabel TotalAplicadasFueraAgendaPorcent;
    public XRLabel TotalNoAplicadasFueraAgendaPorcent;
    public XRLabel lbEncuestasNoAplicadasFueraAgenda;
    public XRLabel lbEncuestasNoAplicadasEnAgenda;
    public XRLabel TotalNoAplicadasEnAgendaPorcent;
    public XRLabel TotalAplicadasEnAgendaPorcent;
    public XRLabel lbEncuestasAplicadasEnAgenda;
    private XRLabel xrLabel29;
    private XRLabel xrLabel37;
    private XRLabel xrLabel40;
    private XRLabel xrLabel28;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    public XRLabel lbClientesEncuestadosEnAgenda;
    public XRLabel xrLabel35;
    public XRLabel xrLabel42;
    public XRLabel lbClientesNoEncuestadosEnAgenda;
    public XRLabel lbClientesNoEncuestadosFueraAgenda;
    public XRLabel xrLabel46;
    public XRLabel xrLabel47;
    public XRLabel lbClientesEncuestadosFueraAgenda;
    public XRLabel lbTotalClientesEncuestados;
    private XRLabel xrLabel53;
    private XRLabel xrLabel34;
    public XRLabel lbTotalCodigoBarras;
    public XRLabel lbCodigoBarrasLeidosFueraAgenda;
    public XRLabel xrLabel49;
    public XRLabel xrLabel52;
    public XRLabel lbCodigoBarrasNoLeidosFueraAgenda;
    public XRLabel lbCodigoBarrasNoLeidosEnAgenda;
    public XRLabel xrLabel57;
    public XRLabel xrLabel58;
    public XRLabel lbCodigoBarrasLeidosEnAgenda;
    private XRLabel xrLabel60;
    private XRLabel xrLabel61;
    private XRLabel xrLabel62;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel xrLabel55;
    public XRLabel lbProductosNoEntregadosEnAgenda;
    public XRLabel xrLabel59;
    public XRLabel xrLabel63;
    public XRLabel lbImproductividadProductoEnAgenda;
    public XRLabel lbImproductividadProductoFueraAgenda;
    public XRLabel xrLabel66;
    public XRLabel xrLabel67;
    public XRLabel lbProductosNoEntregadosFueraAgenda;
    public XRLabel lbTotalProductoNoVendido;
    private XRLabel xrLabel70;
    private XRLabel xrLabel71;
    public XRLabel lbTotalProductosImproductividad;
    public XRLabel lbClientesProductoNegadoFueraAgenda;
    public XRLabel xrLabel74;
    public XRLabel xrLabel75;
    public XRLabel lbClientesImproductividadProductoFueraAgenda;
    public XRLabel lbClientesImproductividadProductoEnAgenda;
    public XRLabel xrLabel78;
    public XRLabel xrLabel79;
    public XRLabel lbClientesProductoNegadoEnAgenda;
    private XRLabel xrLabel81;
    private XRLabel xrLabel82;
    private XRLabel xrLabel83;
    private XRLabel xrLabel84;
    public XRLabel lbClientesProductoPromocionNoEntregado;
    public XRLabel xrLabel86;
    public XRLabel xrLabel87;
    public XRLabel xrLabel88;
    public XRLabel lbProductoPromocionalNoEntregadoFueraAgenda;
    public XRLabel xrLabel64;
    public XRLabel xrLabel65;
    public XRLabel lbProductoPromocionalNoEntregadoEnAgenda;
    private XRLabel xrLabel69;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaGeneral()
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
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalProductosImproductividad = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesProductoNegadoFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel75 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesImproductividadProductoFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesImproductividadProductoEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel78 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel79 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesProductoNegadoEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel81 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel82 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel83 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel84 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesProductoPromocionNoEntregado = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel86 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel87 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbProductoPromocionalNoEntregadoFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbProductoPromocionalNoEntregadoEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbProductosNoEntregadosEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbImproductividadProductoEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbImproductividadProductoFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbProductosNoEntregadosFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalProductoNoVendido = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalCodigoBarras = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCodigoBarrasLeidosFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCodigoBarrasNoLeidosFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCodigoBarrasNoLeidosEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCodigoBarrasLeidosEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesEncuestadosEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesNoEncuestadosEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesNoEncuestadosFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesEncuestadosFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalClientesEncuestados = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalEncuestas = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEncuestasAplicadasFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalAplicadasFueraAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalNoAplicadasFueraAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEncuestasNoAplicadasFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEncuestasNoAplicadasEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalNoAplicadasEnAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalAplicadasEnAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEncuestasAplicadasEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesImproductivoEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesImproductivoFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalClientesVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesVisitadosSinVentaEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesSinVentaEnAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesSinVentaFueraAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesVisitadosSinVentaFueraAgenta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesVisitadosConVentaFueraAgenta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesConVentaFueraAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesConVentaEnAgendaPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClientesVisitadosConVentaEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.visitadosEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEnAgendaVisitadosPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVisitadosFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNoVisitadosFueraAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEnAgendaNoVisitadosPorcent = new DevExpress.XtraReports.UI.XRLabel();
            this.noVisitadosEnAgenda = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalClientes = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempoTransito = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempoVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempoRecorrido = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCEDIS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.Ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.Vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.Fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.CEDIS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel71,
            this.lbTotalProductosImproductividad,
            this.lbClientesProductoNegadoFueraAgenda,
            this.xrLabel74,
            this.xrLabel75,
            this.lbClientesImproductividadProductoFueraAgenda,
            this.lbClientesImproductividadProductoEnAgenda,
            this.xrLabel78,
            this.xrLabel79,
            this.lbClientesProductoNegadoEnAgenda,
            this.xrLabel81,
            this.xrLabel82,
            this.xrLabel83,
            this.xrLabel84,
            this.lbClientesProductoPromocionNoEntregado,
            this.xrLabel86,
            this.xrLabel87,
            this.xrLabel88,
            this.lbProductoPromocionalNoEntregadoFueraAgenda,
            this.xrLabel64,
            this.xrLabel65,
            this.lbProductoPromocionalNoEntregadoEnAgenda,
            this.xrLabel69,
            this.xrLabel44,
            this.xrLabel45,
            this.xrLabel55,
            this.lbProductosNoEntregadosEnAgenda,
            this.xrLabel59,
            this.xrLabel63,
            this.lbImproductividadProductoEnAgenda,
            this.lbImproductividadProductoFueraAgenda,
            this.xrLabel66,
            this.xrLabel67,
            this.lbProductosNoEntregadosFueraAgenda,
            this.lbTotalProductoNoVendido,
            this.xrLabel70,
            this.xrLabel34,
            this.lbTotalCodigoBarras,
            this.lbCodigoBarrasLeidosFueraAgenda,
            this.xrLabel49,
            this.xrLabel52,
            this.lbCodigoBarrasNoLeidosFueraAgenda,
            this.lbCodigoBarrasNoLeidosEnAgenda,
            this.xrLabel57,
            this.xrLabel58,
            this.lbCodigoBarrasLeidosEnAgenda,
            this.xrLabel60,
            this.xrLabel61,
            this.xrLabel62,
            this.xrLabel28,
            this.xrLabel32,
            this.xrLabel33,
            this.lbClientesEncuestadosEnAgenda,
            this.xrLabel35,
            this.xrLabel42,
            this.lbClientesNoEncuestadosEnAgenda,
            this.lbClientesNoEncuestadosFueraAgenda,
            this.xrLabel46,
            this.xrLabel47,
            this.lbClientesEncuestadosFueraAgenda,
            this.lbTotalClientesEncuestados,
            this.xrLabel53,
            this.xrLabel54,
            this.lbTotalEncuestas,
            this.lbEncuestasAplicadasFueraAgenda,
            this.TotalAplicadasFueraAgendaPorcent,
            this.TotalNoAplicadasFueraAgendaPorcent,
            this.lbEncuestasNoAplicadasFueraAgenda,
            this.lbEncuestasNoAplicadasEnAgenda,
            this.TotalNoAplicadasEnAgendaPorcent,
            this.TotalAplicadasEnAgendaPorcent,
            this.lbEncuestasAplicadasEnAgenda,
            this.xrLabel29,
            this.xrLabel37,
            this.xrLabel40,
            this.lbClientesImproductivoEnAgenda,
            this.xrLabel36,
            this.xrLabel39,
            this.lbClientesImproductivoFueraAgenda,
            this.xrLabel26,
            this.xrLabel16,
            this.xrLabel24,
            this.xrLabel27,
            this.lbTotalClientesVisitados,
            this.xrLabel31,
            this.lbClientesVisitadosSinVentaEnAgenda,
            this.lbClientesSinVentaEnAgendaPorcent,
            this.lbClientesSinVentaFueraAgendaPorcent,
            this.lbClientesVisitadosSinVentaFueraAgenta,
            this.lbClientesVisitadosConVentaFueraAgenta,
            this.lbClientesConVentaFueraAgendaPorcent,
            this.lbClientesConVentaEnAgendaPorcent,
            this.lbClientesVisitadosConVentaEnAgenda,
            this.visitadosEnAgenda,
            this.lbEnAgendaVisitadosPorcent,
            this.xrLabel30,
            this.lbVisitadosFueraAgenda,
            this.lbNoVisitadosFueraAgenda,
            this.xrLabel25,
            this.lbEnAgendaNoVisitadosPorcent,
            this.noVisitadosEnAgenda,
            this.xrLabel17,
            this.lbTotalClientes,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.tiempoTransito,
            this.tiempoVisita,
            this.tiempoRecorrido,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.lbRuta,
            this.lbVendedor,
            this.lbFecha,
            this.lbCEDIS,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6});
            this.Detail.Dpi = 100F;
            this.Detail.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Detail.HeightF = 1029.729F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel71
            // 
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(497.1455F, 942.4272F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(100.4583F, 23.00003F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalProductosImproductividad
            // 
            this.lbTotalProductosImproductividad.Dpi = 100F;
            this.lbTotalProductosImproductividad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalProductosImproductividad.LocationFloat = new DevExpress.Utils.PointFloat(397.1456F, 942.4272F);
            this.lbTotalProductosImproductividad.Name = "lbTotalProductosImproductividad";
            this.lbTotalProductosImproductividad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalProductosImproductividad.SizeF = new System.Drawing.SizeF(99.99994F, 23.00009F);
            this.lbTotalProductosImproductividad.StylePriority.UseFont = false;
            this.lbTotalProductosImproductividad.StylePriority.UseTextAlignment = false;
            this.lbTotalProductosImproductividad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesProductoNegadoFueraAgenda
            // 
            this.lbClientesProductoNegadoFueraAgenda.Dpi = 100F;
            this.lbClientesProductoNegadoFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(599.8333F, 886.1769F);
            this.lbClientesProductoNegadoFueraAgenda.Name = "lbClientesProductoNegadoFueraAgenda";
            this.lbClientesProductoNegadoFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesProductoNegadoFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesProductoNegadoFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesProductoNegadoFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel74
            // 
            this.xrLabel74.Dpi = 100F;
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(699.8333F, 886.1769F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel74.StylePriority.UseTextAlignment = false;
            this.xrLabel74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel75
            // 
            this.xrLabel75.Dpi = 100F;
            this.xrLabel75.LocationFloat = new DevExpress.Utils.PointFloat(699.8333F, 909.1768F);
            this.xrLabel75.Name = "xrLabel75";
            this.xrLabel75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel75.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel75.StylePriority.UseTextAlignment = false;
            this.xrLabel75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesImproductividadProductoFueraAgenda
            // 
            this.lbClientesImproductividadProductoFueraAgenda.Dpi = 100F;
            this.lbClientesImproductividadProductoFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(599.8333F, 909.1768F);
            this.lbClientesImproductividadProductoFueraAgenda.Name = "lbClientesImproductividadProductoFueraAgenda";
            this.lbClientesImproductividadProductoFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesImproductividadProductoFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesImproductividadProductoFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesImproductividadProductoFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesImproductividadProductoEnAgenda
            // 
            this.lbClientesImproductividadProductoEnAgenda.Dpi = 100F;
            this.lbClientesImproductividadProductoEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(397.1454F, 909.1768F);
            this.lbClientesImproductividadProductoEnAgenda.Name = "lbClientesImproductividadProductoEnAgenda";
            this.lbClientesImproductividadProductoEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesImproductividadProductoEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesImproductividadProductoEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesImproductividadProductoEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel78
            // 
            this.xrLabel78.Dpi = 100F;
            this.xrLabel78.LocationFloat = new DevExpress.Utils.PointFloat(497.1454F, 909.1768F);
            this.xrLabel78.Name = "xrLabel78";
            this.xrLabel78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel78.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel78.StylePriority.UseTextAlignment = false;
            this.xrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel79
            // 
            this.xrLabel79.Dpi = 100F;
            this.xrLabel79.LocationFloat = new DevExpress.Utils.PointFloat(497.1454F, 886.1769F);
            this.xrLabel79.Name = "xrLabel79";
            this.xrLabel79.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel79.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel79.StylePriority.UseTextAlignment = false;
            this.xrLabel79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesProductoNegadoEnAgenda
            // 
            this.lbClientesProductoNegadoEnAgenda.Dpi = 100F;
            this.lbClientesProductoNegadoEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(397.1454F, 886.1769F);
            this.lbClientesProductoNegadoEnAgenda.Name = "lbClientesProductoNegadoEnAgenda";
            this.lbClientesProductoNegadoEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesProductoNegadoEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesProductoNegadoEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesProductoNegadoEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel81
            // 
            this.xrLabel81.Dpi = 100F;
            this.xrLabel81.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel81.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 886.1771F);
            this.xrLabel81.Name = "xrLabel81";
            this.xrLabel81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel81.SizeF = new System.Drawing.SizeF(324.75F, 23F);
            this.xrLabel81.StylePriority.UseFont = false;
            this.xrLabel81.StylePriority.UseTextAlignment = false;
            this.xrLabel81.Text = "CLIENTES CON PRODUCTO NEGADO";
            this.xrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel82
            // 
            this.xrLabel82.Dpi = 100F;
            this.xrLabel82.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel82.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 909.1769F);
            this.xrLabel82.Name = "xrLabel82";
            this.xrLabel82.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel82.SizeF = new System.Drawing.SizeF(328.7813F, 23F);
            this.xrLabel82.StylePriority.UseFont = false;
            this.xrLabel82.StylePriority.UseTextAlignment = false;
            this.xrLabel82.Text = "CLIENTES CON IMPRODUCTIVIDAD DE PRODUCTO";
            this.xrLabel82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel83
            // 
            this.xrLabel83.Dpi = 100F;
            this.xrLabel83.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel83.LocationFloat = new DevExpress.Utils.PointFloat(9.541638F, 942.4273F);
            this.xrLabel83.Name = "xrLabel83";
            this.xrLabel83.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel83.SizeF = new System.Drawing.SizeF(329.2396F, 23F);
            this.xrLabel83.StylePriority.UseFont = false;
            this.xrLabel83.StylePriority.UseTextAlignment = false;
            this.xrLabel83.Text = "TOTAL DE PRODUCTOS CON IMPRODUCTIVIDAD";
            this.xrLabel83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel84
            // 
            this.xrLabel84.Dpi = 100F;
            this.xrLabel84.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel84.LocationFloat = new DevExpress.Utils.PointFloat(9.541638F, 997.7184F);
            this.xrLabel84.Name = "xrLabel84";
            this.xrLabel84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel84.SizeF = new System.Drawing.SizeF(391.1769F, 23.00012F);
            this.xrLabel84.StylePriority.UseFont = false;
            this.xrLabel84.StylePriority.UseTextAlignment = false;
            this.xrLabel84.Text = "CLIENTES CON PRODUCTO DE PROMOCION NO ENTREGADO";
            this.xrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesProductoPromocionNoEntregado
            // 
            this.lbClientesProductoPromocionNoEntregado.Dpi = 100F;
            this.lbClientesProductoPromocionNoEntregado.LocationFloat = new DevExpress.Utils.PointFloat(401.6352F, 997.7184F);
            this.lbClientesProductoPromocionNoEntregado.Name = "lbClientesProductoPromocionNoEntregado";
            this.lbClientesProductoPromocionNoEntregado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesProductoPromocionNoEntregado.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesProductoPromocionNoEntregado.StylePriority.UseTextAlignment = false;
            this.lbClientesProductoPromocionNoEntregado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel86
            // 
            this.xrLabel86.Dpi = 100F;
            this.xrLabel86.LocationFloat = new DevExpress.Utils.PointFloat(501.6352F, 997.7184F);
            this.xrLabel86.Name = "xrLabel86";
            this.xrLabel86.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel86.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel86.StylePriority.UseTextAlignment = false;
            this.xrLabel86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel87
            // 
            this.xrLabel87.Dpi = 100F;
            this.xrLabel87.LocationFloat = new DevExpress.Utils.PointFloat(704.3229F, 997.7184F);
            this.xrLabel87.Name = "xrLabel87";
            this.xrLabel87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel87.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel87.StylePriority.UseTextAlignment = false;
            this.xrLabel87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel88
            // 
            this.xrLabel88.Dpi = 100F;
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(604.3229F, 997.7184F);
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbProductoPromocionalNoEntregadoFueraAgenda
            // 
            this.lbProductoPromocionalNoEntregadoFueraAgenda.Dpi = 100F;
            this.lbProductoPromocionalNoEntregadoFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(600.2917F, 843.5518F);
            this.lbProductoPromocionalNoEntregadoFueraAgenda.Name = "lbProductoPromocionalNoEntregadoFueraAgenda";
            this.lbProductoPromocionalNoEntregadoFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbProductoPromocionalNoEntregadoFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbProductoPromocionalNoEntregadoFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbProductoPromocionalNoEntregadoFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel64
            // 
            this.xrLabel64.Dpi = 100F;
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(700.2917F, 843.5518F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel64.StylePriority.UseTextAlignment = false;
            this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel65
            // 
            this.xrLabel65.Dpi = 100F;
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(497.6039F, 843.5518F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel65.StylePriority.UseTextAlignment = false;
            this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbProductoPromocionalNoEntregadoEnAgenda
            // 
            this.lbProductoPromocionalNoEntregadoEnAgenda.Dpi = 100F;
            this.lbProductoPromocionalNoEntregadoEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(397.6039F, 843.5518F);
            this.lbProductoPromocionalNoEntregadoEnAgenda.Name = "lbProductoPromocionalNoEntregadoEnAgenda";
            this.lbProductoPromocionalNoEntregadoEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbProductoPromocionalNoEntregadoEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbProductoPromocionalNoEntregadoEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbProductoPromocionalNoEntregadoEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel69
            // 
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(18.54146F, 843.5519F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(316.6668F, 23.00012F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "PRODUCTO PROMOCIONAL NO ENTREGADO";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel44
            // 
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(43.99986F, 785.1355F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(243.5001F, 23F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.Text = "TOTAL PRODUCTO NO VENDIDO";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel45
            // 
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(43.54153F, 751.8851F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(243.9585F, 23F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            this.xrLabel45.Text = "IMPRODUCTIVIDAD DE PRODUCTO";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel55
            // 
            this.xrLabel55.Dpi = 100F;
            this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(43.99986F, 728.8853F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(243.5001F, 23F);
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = "PRODUCTOS NO ENTREGADOS";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbProductosNoEntregadosEnAgenda
            // 
            this.lbProductosNoEntregadosEnAgenda.Dpi = 100F;
            this.lbProductosNoEntregadosEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(397.6039F, 728.8851F);
            this.lbProductosNoEntregadosEnAgenda.Name = "lbProductosNoEntregadosEnAgenda";
            this.lbProductosNoEntregadosEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbProductosNoEntregadosEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbProductosNoEntregadosEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbProductosNoEntregadosEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel59
            // 
            this.xrLabel59.Dpi = 100F;
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(497.6039F, 728.8851F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel59.StylePriority.UseTextAlignment = false;
            this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel63
            // 
            this.xrLabel63.Dpi = 100F;
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(497.6039F, 751.885F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel63.StylePriority.UseTextAlignment = false;
            this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbImproductividadProductoEnAgenda
            // 
            this.lbImproductividadProductoEnAgenda.Dpi = 100F;
            this.lbImproductividadProductoEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(397.6039F, 751.885F);
            this.lbImproductividadProductoEnAgenda.Name = "lbImproductividadProductoEnAgenda";
            this.lbImproductividadProductoEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbImproductividadProductoEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbImproductividadProductoEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbImproductividadProductoEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbImproductividadProductoFueraAgenda
            // 
            this.lbImproductividadProductoFueraAgenda.Dpi = 100F;
            this.lbImproductividadProductoFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(600.2917F, 751.885F);
            this.lbImproductividadProductoFueraAgenda.Name = "lbImproductividadProductoFueraAgenda";
            this.lbImproductividadProductoFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbImproductividadProductoFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbImproductividadProductoFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbImproductividadProductoFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel66
            // 
            this.xrLabel66.Dpi = 100F;
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(700.2917F, 751.885F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel66.StylePriority.UseTextAlignment = false;
            this.xrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel67
            // 
            this.xrLabel67.Dpi = 100F;
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(700.2917F, 728.8851F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel67.StylePriority.UseTextAlignment = false;
            this.xrLabel67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbProductosNoEntregadosFueraAgenda
            // 
            this.lbProductosNoEntregadosFueraAgenda.Dpi = 100F;
            this.lbProductosNoEntregadosFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(600.2917F, 728.8851F);
            this.lbProductosNoEntregadosFueraAgenda.Name = "lbProductosNoEntregadosFueraAgenda";
            this.lbProductosNoEntregadosFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbProductosNoEntregadosFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbProductosNoEntregadosFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbProductosNoEntregadosFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalProductoNoVendido
            // 
            this.lbTotalProductoNoVendido.Dpi = 100F;
            this.lbTotalProductoNoVendido.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalProductoNoVendido.LocationFloat = new DevExpress.Utils.PointFloat(397.1455F, 785.1351F);
            this.lbTotalProductoNoVendido.Name = "lbTotalProductoNoVendido";
            this.lbTotalProductoNoVendido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalProductoNoVendido.SizeF = new System.Drawing.SizeF(99.99994F, 23.00009F);
            this.lbTotalProductoNoVendido.StylePriority.UseFont = false;
            this.lbTotalProductoNoVendido.StylePriority.UseTextAlignment = false;
            this.lbTotalProductoNoVendido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel70
            // 
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(497.1454F, 785.1351F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(100.4583F, 23.00003F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(497.6039F, 690.3436F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(100.4583F, 23.00003F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalCodigoBarras
            // 
            this.lbTotalCodigoBarras.Dpi = 100F;
            this.lbTotalCodigoBarras.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalCodigoBarras.LocationFloat = new DevExpress.Utils.PointFloat(397.604F, 690.3436F);
            this.lbTotalCodigoBarras.Name = "lbTotalCodigoBarras";
            this.lbTotalCodigoBarras.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalCodigoBarras.SizeF = new System.Drawing.SizeF(99.99994F, 23.00009F);
            this.lbTotalCodigoBarras.StylePriority.UseFont = false;
            this.lbTotalCodigoBarras.StylePriority.UseTextAlignment = false;
            this.lbTotalCodigoBarras.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbCodigoBarrasLeidosFueraAgenda
            // 
            this.lbCodigoBarrasLeidosFueraAgenda.Dpi = 100F;
            this.lbCodigoBarrasLeidosFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(600.7502F, 634.0936F);
            this.lbCodigoBarrasLeidosFueraAgenda.Name = "lbCodigoBarrasLeidosFueraAgenda";
            this.lbCodigoBarrasLeidosFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCodigoBarrasLeidosFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbCodigoBarrasLeidosFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbCodigoBarrasLeidosFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Dpi = 100F;
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(700.7502F, 634.0936F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(700.7502F, 657.0935F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbCodigoBarrasNoLeidosFueraAgenda
            // 
            this.lbCodigoBarrasNoLeidosFueraAgenda.Dpi = 100F;
            this.lbCodigoBarrasNoLeidosFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(600.7502F, 657.0935F);
            this.lbCodigoBarrasNoLeidosFueraAgenda.Name = "lbCodigoBarrasNoLeidosFueraAgenda";
            this.lbCodigoBarrasNoLeidosFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCodigoBarrasNoLeidosFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbCodigoBarrasNoLeidosFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbCodigoBarrasNoLeidosFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbCodigoBarrasNoLeidosEnAgenda
            // 
            this.lbCodigoBarrasNoLeidosEnAgenda.Dpi = 100F;
            this.lbCodigoBarrasNoLeidosEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(398.0624F, 657.0935F);
            this.lbCodigoBarrasNoLeidosEnAgenda.Name = "lbCodigoBarrasNoLeidosEnAgenda";
            this.lbCodigoBarrasNoLeidosEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCodigoBarrasNoLeidosEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbCodigoBarrasNoLeidosEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbCodigoBarrasNoLeidosEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel57
            // 
            this.xrLabel57.Dpi = 100F;
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(498.0624F, 657.0935F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel58
            // 
            this.xrLabel58.Dpi = 100F;
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(498.0624F, 634.0936F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel58.StylePriority.UseTextAlignment = false;
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbCodigoBarrasLeidosEnAgenda
            // 
            this.lbCodigoBarrasLeidosEnAgenda.Dpi = 100F;
            this.lbCodigoBarrasLeidosEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(398.0624F, 634.0936F);
            this.lbCodigoBarrasLeidosEnAgenda.Name = "lbCodigoBarrasLeidosEnAgenda";
            this.lbCodigoBarrasLeidosEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCodigoBarrasLeidosEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbCodigoBarrasLeidosEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbCodigoBarrasLeidosEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel60
            // 
            this.xrLabel60.Dpi = 100F;
            this.xrLabel60.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(44.45834F, 634.0936F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(243.5001F, 23F);
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.StylePriority.UseTextAlignment = false;
            this.xrLabel60.Text = "CODIGO BARRAS LEIDOS";
            this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel61
            // 
            this.xrLabel61.Dpi = 100F;
            this.xrLabel61.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(44.00001F, 657.0935F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(243.9585F, 23F);
            this.xrLabel61.StylePriority.UseFont = false;
            this.xrLabel61.StylePriority.UseTextAlignment = false;
            this.xrLabel61.Text = "CODIGO BARRAS NO LEIDOS";
            this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel62
            // 
            this.xrLabel62.Dpi = 100F;
            this.xrLabel62.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(44.45834F, 690.3439F);
            this.xrLabel62.Name = "xrLabel62";
            this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel62.SizeF = new System.Drawing.SizeF(243.5001F, 23F);
            this.xrLabel62.StylePriority.UseFont = false;
            this.xrLabel62.StylePriority.UseTextAlignment = false;
            this.xrLabel62.Text = "TOTAL CODIGO BARRAS";
            this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(44.91666F, 593.4689F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(243.5001F, 23F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "TOTAL CLIENTES ENCUESTADOS";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(44.91666F, 560.2186F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(211.9063F, 23F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "CLIENTES NO ENCUESTADOS";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(45.375F, 537.2187F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(171.1771F, 23F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "CLIENTES ENCUESTADOS";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesEncuestadosEnAgenda
            // 
            this.lbClientesEncuestadosEnAgenda.Dpi = 100F;
            this.lbClientesEncuestadosEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(399.3437F, 537.2186F);
            this.lbClientesEncuestadosEnAgenda.Name = "lbClientesEncuestadosEnAgenda";
            this.lbClientesEncuestadosEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesEncuestadosEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesEncuestadosEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesEncuestadosEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel35
            // 
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(499.3436F, 537.2186F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel42
            // 
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(498.5206F, 560.2186F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesNoEncuestadosEnAgenda
            // 
            this.lbClientesNoEncuestadosEnAgenda.Dpi = 100F;
            this.lbClientesNoEncuestadosEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(398.5207F, 560.2186F);
            this.lbClientesNoEncuestadosEnAgenda.Name = "lbClientesNoEncuestadosEnAgenda";
            this.lbClientesNoEncuestadosEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesNoEncuestadosEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesNoEncuestadosEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesNoEncuestadosEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesNoEncuestadosFueraAgenda
            // 
            this.lbClientesNoEncuestadosFueraAgenda.Dpi = 100F;
            this.lbClientesNoEncuestadosFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(601.2085F, 560.2186F);
            this.lbClientesNoEncuestadosFueraAgenda.Name = "lbClientesNoEncuestadosFueraAgenda";
            this.lbClientesNoEncuestadosFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesNoEncuestadosFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesNoEncuestadosFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesNoEncuestadosFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(701.2085F, 560.2186F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel47
            // 
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(702.0315F, 537.2186F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesEncuestadosFueraAgenda
            // 
            this.lbClientesEncuestadosFueraAgenda.Dpi = 100F;
            this.lbClientesEncuestadosFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(602.0315F, 537.2186F);
            this.lbClientesEncuestadosFueraAgenda.Name = "lbClientesEncuestadosFueraAgenda";
            this.lbClientesEncuestadosFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesEncuestadosFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesEncuestadosFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesEncuestadosFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalClientesEncuestados
            // 
            this.lbTotalClientesEncuestados.Dpi = 100F;
            this.lbTotalClientesEncuestados.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalClientesEncuestados.LocationFloat = new DevExpress.Utils.PointFloat(398.0624F, 593.4686F);
            this.lbTotalClientesEncuestados.Name = "lbTotalClientesEncuestados";
            this.lbTotalClientesEncuestados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalClientesEncuestados.SizeF = new System.Drawing.SizeF(99.99994F, 23.00009F);
            this.lbTotalClientesEncuestados.StylePriority.UseFont = false;
            this.lbTotalClientesEncuestados.StylePriority.UseTextAlignment = false;
            this.lbTotalClientesEncuestados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Dpi = 100F;
            this.xrLabel53.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(498.0622F, 593.4686F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(100.4583F, 23.00003F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel54
            // 
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(498.8853F, 497.6353F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(100.4583F, 23.00003F);
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalEncuestas
            // 
            this.lbTotalEncuestas.Dpi = 100F;
            this.lbTotalEncuestas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbTotalEncuestas.LocationFloat = new DevExpress.Utils.PointFloat(398.8854F, 497.6353F);
            this.lbTotalEncuestas.Name = "lbTotalEncuestas";
            this.lbTotalEncuestas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalEncuestas.SizeF = new System.Drawing.SizeF(99.99994F, 23.00009F);
            this.lbTotalEncuestas.StylePriority.UseFont = false;
            this.lbTotalEncuestas.StylePriority.UseTextAlignment = false;
            this.lbTotalEncuestas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEncuestasAplicadasFueraAgenda
            // 
            this.lbEncuestasAplicadasFueraAgenda.Dpi = 100F;
            this.lbEncuestasAplicadasFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(602.0315F, 441.3854F);
            this.lbEncuestasAplicadasFueraAgenda.Name = "lbEncuestasAplicadasFueraAgenda";
            this.lbEncuestasAplicadasFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEncuestasAplicadasFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbEncuestasAplicadasFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbEncuestasAplicadasFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalAplicadasFueraAgendaPorcent
            // 
            this.TotalAplicadasFueraAgendaPorcent.Dpi = 100F;
            this.TotalAplicadasFueraAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(702.0314F, 441.3854F);
            this.TotalAplicadasFueraAgendaPorcent.Name = "TotalAplicadasFueraAgendaPorcent";
            this.TotalAplicadasFueraAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalAplicadasFueraAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.TotalAplicadasFueraAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.TotalAplicadasFueraAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalNoAplicadasFueraAgendaPorcent
            // 
            this.TotalNoAplicadasFueraAgendaPorcent.Dpi = 100F;
            this.TotalNoAplicadasFueraAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(702.0314F, 464.3853F);
            this.TotalNoAplicadasFueraAgendaPorcent.Name = "TotalNoAplicadasFueraAgendaPorcent";
            this.TotalNoAplicadasFueraAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalNoAplicadasFueraAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.TotalNoAplicadasFueraAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.TotalNoAplicadasFueraAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEncuestasNoAplicadasFueraAgenda
            // 
            this.lbEncuestasNoAplicadasFueraAgenda.Dpi = 100F;
            this.lbEncuestasNoAplicadasFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(602.0315F, 464.3853F);
            this.lbEncuestasNoAplicadasFueraAgenda.Name = "lbEncuestasNoAplicadasFueraAgenda";
            this.lbEncuestasNoAplicadasFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEncuestasNoAplicadasFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbEncuestasNoAplicadasFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbEncuestasNoAplicadasFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEncuestasNoAplicadasEnAgenda
            // 
            this.lbEncuestasNoAplicadasEnAgenda.Dpi = 100F;
            this.lbEncuestasNoAplicadasEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(399.3437F, 464.3853F);
            this.lbEncuestasNoAplicadasEnAgenda.Name = "lbEncuestasNoAplicadasEnAgenda";
            this.lbEncuestasNoAplicadasEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEncuestasNoAplicadasEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbEncuestasNoAplicadasEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbEncuestasNoAplicadasEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalNoAplicadasEnAgendaPorcent
            // 
            this.TotalNoAplicadasEnAgendaPorcent.Dpi = 100F;
            this.TotalNoAplicadasEnAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(499.3436F, 464.3853F);
            this.TotalNoAplicadasEnAgendaPorcent.Name = "TotalNoAplicadasEnAgendaPorcent";
            this.TotalNoAplicadasEnAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalNoAplicadasEnAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.TotalNoAplicadasEnAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.TotalNoAplicadasEnAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalAplicadasEnAgendaPorcent
            // 
            this.TotalAplicadasEnAgendaPorcent.Dpi = 100F;
            this.TotalAplicadasEnAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(499.3436F, 441.3854F);
            this.TotalAplicadasEnAgendaPorcent.Name = "TotalAplicadasEnAgendaPorcent";
            this.TotalAplicadasEnAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalAplicadasEnAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.TotalAplicadasEnAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.TotalAplicadasEnAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEncuestasAplicadasEnAgenda
            // 
            this.lbEncuestasAplicadasEnAgenda.Dpi = 100F;
            this.lbEncuestasAplicadasEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(399.3437F, 441.3854F);
            this.lbEncuestasAplicadasEnAgenda.Name = "lbEncuestasAplicadasEnAgenda";
            this.lbEncuestasAplicadasEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEncuestasAplicadasEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbEncuestasAplicadasEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbEncuestasAplicadasEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(45.37503F, 441.3854F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(171.1771F, 23F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "ENCUESTAS APLICADAS";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(44.91669F, 464.3853F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(211.9063F, 23F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "ENCUESTAS NO APLICADAS";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(94.11464F, 497.6356F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(195.2188F, 22.99997F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "TOTAL DE ENCUESTAS";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesImproductivoEnAgenda
            // 
            this.lbClientesImproductivoEnAgenda.Dpi = 100F;
            this.lbClientesImproductivoEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(399.3437F, 398.9583F);
            this.lbClientesImproductivoEnAgenda.Name = "lbClientesImproductivoEnAgenda";
            this.lbClientesImproductivoEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesImproductivoEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesImproductivoEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesImproductivoEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(499.3436F, 398.9583F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(700.7502F, 398.9583F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesImproductivoFueraAgenda
            // 
            this.lbClientesImproductivoFueraAgenda.Dpi = 100F;
            this.lbClientesImproductivoFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(600.7501F, 398.9583F);
            this.lbClientesImproductivoFueraAgenda.Name = "lbClientesImproductivoFueraAgenda";
            this.lbClientesImproductivoFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesImproductivoFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesImproductivoFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesImproductivoFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(45.37502F, 398.9583F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(243.9584F, 22.99997F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "IMPRODUCTIVIDAD DE LA VENTA";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(45.37502F, 302.5625F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(226.3854F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "CLIENTES VISITADOS CON VENTA";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(45.37502F, 325.5625F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(226.3854F, 23F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "CLIENTES VISITADOS SIN VENTA";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(94.11464F, 358.8125F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(196.0417F, 22.99997F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "TOTAL CLIENTES VISITADOS";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalClientesVisitados
            // 
            this.lbTotalClientesVisitados.Dpi = 100F;
            this.lbTotalClientesVisitados.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTotalClientesVisitados.LocationFloat = new DevExpress.Utils.PointFloat(400.625F, 358.8125F);
            this.lbTotalClientesVisitados.Name = "lbTotalClientesVisitados";
            this.lbTotalClientesVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalClientesVisitados.SizeF = new System.Drawing.SizeF(99.54172F, 22.99994F);
            this.lbTotalClientesVisitados.StylePriority.UseFont = false;
            this.lbTotalClientesVisitados.StylePriority.UseTextAlignment = false;
            this.lbTotalClientesVisitados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(500.1667F, 358.8125F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(99.63531F, 22.99994F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesVisitadosSinVentaEnAgenda
            // 
            this.lbClientesVisitadosSinVentaEnAgenda.Dpi = 100F;
            this.lbClientesVisitadosSinVentaEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(399.802F, 325.5625F);
            this.lbClientesVisitadosSinVentaEnAgenda.Name = "lbClientesVisitadosSinVentaEnAgenda";
            this.lbClientesVisitadosSinVentaEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesVisitadosSinVentaEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesVisitadosSinVentaEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesVisitadosSinVentaEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesSinVentaEnAgendaPorcent
            // 
            this.lbClientesSinVentaEnAgendaPorcent.Dpi = 100F;
            this.lbClientesSinVentaEnAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(499.802F, 325.5625F);
            this.lbClientesSinVentaEnAgendaPorcent.Name = "lbClientesSinVentaEnAgendaPorcent";
            this.lbClientesSinVentaEnAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesSinVentaEnAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesSinVentaEnAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.lbClientesSinVentaEnAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesSinVentaFueraAgendaPorcent
            // 
            this.lbClientesSinVentaFueraAgendaPorcent.Dpi = 100F;
            this.lbClientesSinVentaFueraAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(701.2086F, 325.5625F);
            this.lbClientesSinVentaFueraAgendaPorcent.Name = "lbClientesSinVentaFueraAgendaPorcent";
            this.lbClientesSinVentaFueraAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesSinVentaFueraAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesSinVentaFueraAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.lbClientesSinVentaFueraAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesVisitadosSinVentaFueraAgenta
            // 
            this.lbClientesVisitadosSinVentaFueraAgenta.Dpi = 100F;
            this.lbClientesVisitadosSinVentaFueraAgenta.LocationFloat = new DevExpress.Utils.PointFloat(601.2085F, 325.5625F);
            this.lbClientesVisitadosSinVentaFueraAgenta.Name = "lbClientesVisitadosSinVentaFueraAgenta";
            this.lbClientesVisitadosSinVentaFueraAgenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesVisitadosSinVentaFueraAgenta.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesVisitadosSinVentaFueraAgenta.StylePriority.UseTextAlignment = false;
            this.lbClientesVisitadosSinVentaFueraAgenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesVisitadosConVentaFueraAgenta
            // 
            this.lbClientesVisitadosConVentaFueraAgenta.Dpi = 100F;
            this.lbClientesVisitadosConVentaFueraAgenta.LocationFloat = new DevExpress.Utils.PointFloat(601.2086F, 302.5624F);
            this.lbClientesVisitadosConVentaFueraAgenta.Name = "lbClientesVisitadosConVentaFueraAgenta";
            this.lbClientesVisitadosConVentaFueraAgenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesVisitadosConVentaFueraAgenta.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesVisitadosConVentaFueraAgenta.StylePriority.UseTextAlignment = false;
            this.lbClientesVisitadosConVentaFueraAgenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesConVentaFueraAgendaPorcent
            // 
            this.lbClientesConVentaFueraAgendaPorcent.Dpi = 100F;
            this.lbClientesConVentaFueraAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(701.2086F, 302.5624F);
            this.lbClientesConVentaFueraAgendaPorcent.Name = "lbClientesConVentaFueraAgendaPorcent";
            this.lbClientesConVentaFueraAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesConVentaFueraAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesConVentaFueraAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.lbClientesConVentaFueraAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesConVentaEnAgendaPorcent
            // 
            this.lbClientesConVentaEnAgendaPorcent.Dpi = 100F;
            this.lbClientesConVentaEnAgendaPorcent.LocationFloat = new DevExpress.Utils.PointFloat(499.802F, 302.5624F);
            this.lbClientesConVentaEnAgendaPorcent.Name = "lbClientesConVentaEnAgendaPorcent";
            this.lbClientesConVentaEnAgendaPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesConVentaEnAgendaPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesConVentaEnAgendaPorcent.StylePriority.UseTextAlignment = false;
            this.lbClientesConVentaEnAgendaPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbClientesVisitadosConVentaEnAgenda
            // 
            this.lbClientesVisitadosConVentaEnAgenda.Dpi = 100F;
            this.lbClientesVisitadosConVentaEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(399.802F, 302.5624F);
            this.lbClientesVisitadosConVentaEnAgenda.Name = "lbClientesVisitadosConVentaEnAgenda";
            this.lbClientesVisitadosConVentaEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClientesVisitadosConVentaEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbClientesVisitadosConVentaEnAgenda.StylePriority.UseTextAlignment = false;
            this.lbClientesVisitadosConVentaEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // visitadosEnAgenda
            // 
            this.visitadosEnAgenda.Dpi = 100F;
            this.visitadosEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(400.6249F, 204.125F);
            this.visitadosEnAgenda.Name = "visitadosEnAgenda";
            this.visitadosEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.visitadosEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.visitadosEnAgenda.StylePriority.UseTextAlignment = false;
            this.visitadosEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEnAgendaVisitadosPorcent
            // 
            this.lbEnAgendaVisitadosPorcent.Dpi = 100F;
            this.lbEnAgendaVisitadosPorcent.LocationFloat = new DevExpress.Utils.PointFloat(500.6249F, 204.125F);
            this.lbEnAgendaVisitadosPorcent.Name = "lbEnAgendaVisitadosPorcent";
            this.lbEnAgendaVisitadosPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEnAgendaVisitadosPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbEnAgendaVisitadosPorcent.StylePriority.UseTextAlignment = false;
            this.lbEnAgendaVisitadosPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(702.0315F, 204.125F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbVisitadosFueraAgenda
            // 
            this.lbVisitadosFueraAgenda.Dpi = 100F;
            this.lbVisitadosFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(602.0314F, 204.125F);
            this.lbVisitadosFueraAgenda.Name = "lbVisitadosFueraAgenda";
            this.lbVisitadosFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVisitadosFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbVisitadosFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbVisitadosFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbNoVisitadosFueraAgenda
            // 
            this.lbNoVisitadosFueraAgenda.Dpi = 100F;
            this.lbNoVisitadosFueraAgenda.LocationFloat = new DevExpress.Utils.PointFloat(602.0313F, 227.125F);
            this.lbNoVisitadosFueraAgenda.Name = "lbNoVisitadosFueraAgenda";
            this.lbNoVisitadosFueraAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNoVisitadosFueraAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbNoVisitadosFueraAgenda.StylePriority.UseTextAlignment = false;
            this.lbNoVisitadosFueraAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(702.0314F, 227.125F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbEnAgendaNoVisitadosPorcent
            // 
            this.lbEnAgendaNoVisitadosPorcent.Dpi = 100F;
            this.lbEnAgendaNoVisitadosPorcent.LocationFloat = new DevExpress.Utils.PointFloat(500.6249F, 227.125F);
            this.lbEnAgendaNoVisitadosPorcent.Name = "lbEnAgendaNoVisitadosPorcent";
            this.lbEnAgendaNoVisitadosPorcent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEnAgendaNoVisitadosPorcent.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lbEnAgendaNoVisitadosPorcent.StylePriority.UseTextAlignment = false;
            this.lbEnAgendaNoVisitadosPorcent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // noVisitadosEnAgenda
            // 
            this.noVisitadosEnAgenda.Dpi = 100F;
            this.noVisitadosEnAgenda.LocationFloat = new DevExpress.Utils.PointFloat(400.6249F, 227.125F);
            this.noVisitadosEnAgenda.Name = "noVisitadosEnAgenda";
            this.noVisitadosEnAgenda.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.noVisitadosEnAgenda.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.noVisitadosEnAgenda.StylePriority.UseTextAlignment = false;
            this.noVisitadosEnAgenda.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(498.8852F, 260.375F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(101.5207F, 22.99994F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbTotalClientes
            // 
            this.lbTotalClientes.Dpi = 100F;
            this.lbTotalClientes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTotalClientes.LocationFloat = new DevExpress.Utils.PointFloat(400.6249F, 260.375F);
            this.lbTotalClientes.Name = "lbTotalClientes";
            this.lbTotalClientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalClientes.SizeF = new System.Drawing.SizeF(98.26031F, 22.99994F);
            this.lbTotalClientes.StylePriority.UseFont = false;
            this.lbTotalClientes.StylePriority.UseTextAlignment = false;
            this.lbTotalClientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(166.1981F, 260.375F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(123.9583F, 22.99997F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "TOTAL CLIENTES";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(46.65623F, 227.125F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(171.1771F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "CLIENTES NO VISITADOS";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(46.65623F, 204.125F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(171.1771F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "CLIENTES VISITADOS";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // tiempoTransito
            // 
            this.tiempoTransito.Dpi = 100F;
            this.tiempoTransito.LocationFloat = new DevExpress.Utils.PointFloat(156.3646F, 159.5416F);
            this.tiempoTransito.Name = "tiempoTransito";
            this.tiempoTransito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoTransito.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // tiempoVisita
            // 
            this.tiempoVisita.Dpi = 100F;
            this.tiempoVisita.LocationFloat = new DevExpress.Utils.PointFloat(156.3646F, 136.5416F);
            this.tiempoVisita.Name = "tiempoVisita";
            this.tiempoVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoVisita.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // tiempoRecorrido
            // 
            this.tiempoRecorrido.Dpi = 100F;
            this.tiempoRecorrido.LocationFloat = new DevExpress.Utils.PointFloat(156.3646F, 113.5416F);
            this.tiempoRecorrido.Name = "tiempoRecorrido";
            this.tiempoRecorrido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoRecorrido.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(45.37502F, 159.5416F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "Tiempo Transito";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(45.37502F, 136.5416F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "Tiempo Visita";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(44.45834F, 113.5416F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(111.9062F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Tiempo Recorrido";
            // 
            // lbRuta
            // 
            this.lbRuta.Dpi = 100F;
            this.lbRuta.LocationFloat = new DevExpress.Utils.PointFloat(206.9583F, 79.00003F);
            this.lbRuta.Name = "lbRuta";
            this.lbRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbRuta.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // lbVendedor
            // 
            this.lbVendedor.Dpi = 100F;
            this.lbVendedor.LocationFloat = new DevExpress.Utils.PointFloat(206.9583F, 56.00001F);
            this.lbVendedor.Name = "lbVendedor";
            this.lbVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVendedor.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // lbFecha
            // 
            this.lbFecha.Dpi = 100F;
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(206.9583F, 33.00002F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // lbCEDIS
            // 
            this.lbCEDIS.Dpi = 100F;
            this.lbCEDIS.LocationFloat = new DevExpress.Utils.PointFloat(206.9583F, 10.00001F);
            this.lbCEDIS.Name = "lbCEDIS";
            this.lbCEDIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCEDIS.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(97.45833F, 79.00003F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Ruta";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(70.375F, 56.00001F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Vendedor";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(45.375F, 33.00002F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Fecha";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(23.03127F, 10.00001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(147.3437F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "Centro de Distribucion";
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.Ruta,
            this.Vendedor,
            this.Fecha,
            this.CEDIS,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.logo1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 201.8334F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(23.03124F, 188.8334F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(776.7604F, 13F);
            // 
            // Ruta
            // 
            this.Ruta.Dpi = 100F;
            this.Ruta.LocationFloat = new DevExpress.Utils.PointFloat(156.3646F, 165.8333F);
            this.Ruta.Name = "Ruta";
            this.Ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Ruta.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // Vendedor
            // 
            this.Vendedor.Dpi = 100F;
            this.Vendedor.LocationFloat = new DevExpress.Utils.PointFloat(156.3646F, 142.8333F);
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Vendedor.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // Fecha
            // 
            this.Fecha.Dpi = 100F;
            this.Fecha.LocationFloat = new DevExpress.Utils.PointFloat(156.3646F, 119.8333F);
            this.Fecha.Name = "Fecha";
            this.Fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Fecha.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // CEDIS
            // 
            this.CEDIS.Dpi = 100F;
            this.CEDIS.LocationFloat = new DevExpress.Utils.PointFloat(156.3645F, 96.83333F);
            this.CEDIS.Name = "CEDIS";
            this.CEDIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CEDIS.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(24.40627F, 165.8333F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Ruta";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(24.40627F, 142.8333F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Vendedor";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(24.40627F, 119.8333F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Fecha";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(23.03124F, 96.83333F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(133.3333F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Centro de Distribucion";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(156.2397F, 23F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(473.3124F, 48.25001F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "CONSERVAS LA COSTEÑA S.A. DE C.V.\r\nEfectividad Por Ruta (General)\r\n";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // logo1
            // 
            this.logo1.Dpi = 100F;
            this.logo1.LocationFloat = new DevExpress.Utils.PointFloat(24.40627F, 10.00001F);
            this.logo1.Name = "logo1";
            this.logo1.SizeF = new System.Drawing.SizeF(99.99998F, 61.25001F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLine3,
            this.xrLine2});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 67.70834F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(448.1249F, 10.49999F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "En Agenda";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(397.7291F, 33.49998F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Cantidad";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(497.7291F, 33.49998F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Porcentaje";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(699.1356F, 33.49998F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Porcentaje";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(599.1355F, 33.49998F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Cantidad";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(649.5313F, 10.49999F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Fuera de Agenda";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(24.40627F, 56.49999F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(725.1251F, 10.5F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(23.94791F, 0F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(725.1251F, 10.5F);
            // 
            // efectividadPorRutaGeneral
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(14, 12, 202, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
