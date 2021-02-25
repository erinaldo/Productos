using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;


/// <summary>
/// Summary description for LiquidacionPDR
/// </summary>
public class LiquidacionPDR : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private DevExpress.DataAccess.Sql.SqlDataSource dsProductos;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    private XRLabel xrLabel7;
    public XRSubreport srptVentasContado;
    private SubBand SubBand1;
    private SubBand SubBand2;
    public XRLabel lbClave;
    public XRLabel lbDescripcion;
    public XRLabel lbInvInicial;
    public XRLabel lbRecargas;
    public XRLabel lbDevolucionesCte;
    public XRLabel lbDescargasAlm;
    public XRLabel lbMermas;
    public XRLabel lbVentas;
    public XRLabel lbInvFinal;
    public XRLabel lbImporte;
    public XRLabel lbCambios;
    public XRLabel lbUnidad;
    private XRLabel xrLabel25;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    private XRLabel xrLabel22;
    private XRLabel xrLabel21;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel32;
    private XRLabel xrLabel31;
    private XRLabel xrLabel30;
    private XRLabel xrLabel29;
    private XRLabel xrLabel28;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private CalculatedField InventarioFinal;
    public XRSubreport srptVentasCredito;
    private SubBand SubBand3;
    public XRSubreport srptPreliquidacion;
    private CalculatedField VentaTotalVendedor;
    private CalculatedField calculatedField1;
    private CalculatedField VentaCreditoVendedor;
    public XRSubreport srptCobranza;
    private SubBand SubBand4;
    private SubBand SubBand5;
    public XRSubreport srptDesglose;
    public XRSubreport srptDepositos;
    public XRLabel lbDesglose;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel xrLabel69;
    public XRLabel xrLabel70;
    public XRLabel nameFiltro;
    public XRLabel centro;
    public XRLabel fecha;
    public XRLabel filtro;
    public XRLabel empresa;
    private XRLabel xrLabel2;
    public XRLabel lbVendedorGrupo;
    public XRLabel lbMovimientosProd;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public LiquidacionPDR()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    public LiquidacionPDR(string sProductos, string sVentasContado, string sVentasCredito, string sPreliquidacion, string sCobranza, string sDesglose, string sDepositos)
    {
        InitializeComponent();
        //DataSourceDemanded += ClientesSinVenta_DataSourceDemanded(null, null, cons);
        dsProductos.Queries.RemoveAt(0);
        CustomSqlQuery query = new CustomSqlQuery("Query", sProductos);
        dsProductos.Queries.Add(query);
        dsProductos.RebuildResultSchema();

        ((VentasContadoPDR)srptVentasContado.ReportSource).SetDataSource(sVentasContado);
        ((VentasCreditoPDR)srptVentasCredito.ReportSource).SetDataSource(sVentasCredito);
        ((PreliquidacionPDR)srptPreliquidacion.ReportSource).SetDataSource(sPreliquidacion);
        ((CobranzaPDR)srptCobranza.ReportSource).SetDataSource(sCobranza);
        ((DesgloseEfectivo)srptDesglose.ReportSource).SetDataSource(sDesglose);
        ((DesglosePDR)srptDepositos.ReportSource).SetDataSource(sDepositos);
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
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiquidacionPDR));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.nameFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.filtro = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.dsProductos = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVendedorGrupo = new DevExpress.XtraReports.UI.XRLabel();
            this.lbMovimientosProd = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCambios = new DevExpress.XtraReports.UI.XRLabel();
            this.lbUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.lbClave = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDescripcion = new DevExpress.XtraReports.UI.XRLabel();
            this.lbInvInicial = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRecargas = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDevolucionesCte = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDescargasAlm = new DevExpress.XtraReports.UI.XRLabel();
            this.lbMermas = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVentas = new DevExpress.XtraReports.UI.XRLabel();
            this.lbInvFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.lbImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.SubBand1 = new DevExpress.XtraReports.UI.SubBand();
            this.srptVentasContado = new DevExpress.XtraReports.UI.XRSubreport();
            this.SubBand2 = new DevExpress.XtraReports.UI.SubBand();
            this.srptVentasCredito = new DevExpress.XtraReports.UI.XRSubreport();
            this.SubBand3 = new DevExpress.XtraReports.UI.SubBand();
            this.srptCobranza = new DevExpress.XtraReports.UI.XRSubreport();
            this.SubBand4 = new DevExpress.XtraReports.UI.SubBand();
            this.srptPreliquidacion = new DevExpress.XtraReports.UI.XRSubreport();
            this.SubBand5 = new DevExpress.XtraReports.UI.SubBand();
            this.srptDepositos = new DevExpress.XtraReports.UI.XRSubreport();
            this.lbDesglose = new DevExpress.XtraReports.UI.XRLabel();
            this.srptDesglose = new DevExpress.XtraReports.UI.XRSubreport();
            this.InventarioFinal = new DevExpress.XtraReports.UI.CalculatedField();
            this.VentaTotalVendedor = new DevExpress.XtraReports.UI.CalculatedField();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.VentaCreditoVendedor = new DevExpress.XtraReports.UI.CalculatedField();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel33,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel4,
            this.xrLabel3});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 15F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel33
            // 
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.InventarioFinal")});
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(1010F, 0F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "xrLabel33";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Importe", "{0:$#,##0.00}")});
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(930F, 0F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Venta")});
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "xrLabel24";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Descarga")});
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(790F, 0F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Merma")});
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(720F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "xrLabel22";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.DevolucionCli")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(640F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CambioEnt")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(570F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "xrLabel19";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Recarga")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TipoUnidad")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(350F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.InvInicial")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(420F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRONombre")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(300F, 15F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ProductoClave")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 5F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 5F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.xrLabel69,
            this.xrLabel70,
            this.nameFiltro,
            this.centro,
            this.fecha,
            this.filtro,
            this.empresa});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 145F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 15F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(300F, 55F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel69
            // 
            this.xrLabel69.CanGrow = false;
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "Centro De Distribución:";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel70
            // 
            this.xrLabel70.CanGrow = false;
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.Text = "Fecha:";
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // nameFiltro
            // 
            this.nameFiltro.CanGrow = false;
            this.nameFiltro.Dpi = 100F;
            this.nameFiltro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.nameFiltro.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
            this.nameFiltro.Name = "nameFiltro";
            this.nameFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nameFiltro.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.nameFiltro.StylePriority.UseFont = false;
            this.nameFiltro.StylePriority.UseTextAlignment = false;
            this.nameFiltro.Text = "Vendedor:";
            this.nameFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // centro
            // 
            this.centro.CanGrow = false;
            this.centro.Dpi = 100F;
            this.centro.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 100F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(940F, 15F);
            this.centro.StylePriority.UseFont = false;
            this.centro.StylePriority.UseTextAlignment = false;
            this.centro.Text = "centro";
            this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fecha
            // 
            this.fecha.CanGrow = false;
            this.fecha.Dpi = 100F;
            this.fecha.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(150F, 115F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(940F, 15F);
            this.fecha.StylePriority.UseFont = false;
            this.fecha.StylePriority.UseTextAlignment = false;
            this.fecha.Text = "fecha";
            this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // filtro
            // 
            this.filtro.CanGrow = false;
            this.filtro.Dpi = 100F;
            this.filtro.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.filtro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 130F);
            this.filtro.Name = "filtro";
            this.filtro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.filtro.SizeF = new System.Drawing.SizeF(940F, 15F);
            this.filtro.StylePriority.UseFont = false;
            this.filtro.StylePriority.UseTextAlignment = false;
            this.filtro.Text = "vendedor";
            this.filtro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(300F, 15F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // dsProductos
            // 
            this.dsProductos.ConnectionName = "eRouteConnection";
            this.dsProductos.Name = "dsProductos";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.dsProductos.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.dsProductos.ResultSchemaSerializable = resources.GetString("dsProductos.ResultSchemaSerializable");
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.lbVendedorGrupo,
            this.lbMovimientosProd,
            this.lbCambios,
            this.lbUnidad,
            this.lbClave,
            this.lbDescripcion,
            this.lbInvInicial,
            this.lbRecargas,
            this.lbDevolucionesCte,
            this.lbDescargasAlm,
            this.lbMermas,
            this.lbVentas,
            this.lbInvFinal,
            this.lbImporte});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("VendedorId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 65F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry;
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VENNombre")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(940F, 15F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbVendedorGrupo
            // 
            this.lbVendedorGrupo.CanGrow = false;
            this.lbVendedorGrupo.Dpi = 100F;
            this.lbVendedorGrupo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbVendedorGrupo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbVendedorGrupo.Name = "lbVendedorGrupo";
            this.lbVendedorGrupo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVendedorGrupo.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbVendedorGrupo.StylePriority.UseFont = false;
            this.lbVendedorGrupo.StylePriority.UseTextAlignment = false;
            this.lbVendedorGrupo.Text = "lbVendedor";
            this.lbVendedorGrupo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lbMovimientosProd
            // 
            this.lbMovimientosProd.CanGrow = false;
            this.lbMovimientosProd.Dpi = 100F;
            this.lbMovimientosProd.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbMovimientosProd.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15F);
            this.lbMovimientosProd.Name = "lbMovimientosProd";
            this.lbMovimientosProd.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbMovimientosProd.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbMovimientosProd.StylePriority.UseFont = false;
            this.lbMovimientosProd.StylePriority.UseTextAlignment = false;
            this.lbMovimientosProd.Text = "lbMovimientosProd";
            this.lbMovimientosProd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbCambios
            // 
            this.lbCambios.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbCambios.BorderWidth = 2F;
            this.lbCambios.CanGrow = false;
            this.lbCambios.Dpi = 100F;
            this.lbCambios.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbCambios.LocationFloat = new DevExpress.Utils.PointFloat(570F, 30F);
            this.lbCambios.Name = "lbCambios";
            this.lbCambios.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCambios.SizeF = new System.Drawing.SizeF(70F, 35F);
            this.lbCambios.StylePriority.UseBorders = false;
            this.lbCambios.StylePriority.UseBorderWidth = false;
            this.lbCambios.StylePriority.UseFont = false;
            this.lbCambios.StylePriority.UseTextAlignment = false;
            this.lbCambios.Text = "Cambios";
            this.lbCambios.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbUnidad
            // 
            this.lbUnidad.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbUnidad.BorderWidth = 2F;
            this.lbUnidad.CanGrow = false;
            this.lbUnidad.Dpi = 100F;
            this.lbUnidad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbUnidad.LocationFloat = new DevExpress.Utils.PointFloat(350F, 30F);
            this.lbUnidad.Name = "lbUnidad";
            this.lbUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbUnidad.SizeF = new System.Drawing.SizeF(70F, 35F);
            this.lbUnidad.StylePriority.UseBorders = false;
            this.lbUnidad.StylePriority.UseBorderWidth = false;
            this.lbUnidad.StylePriority.UseFont = false;
            this.lbUnidad.StylePriority.UseTextAlignment = false;
            this.lbUnidad.Text = "Unidad";
            this.lbUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbClave
            // 
            this.lbClave.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbClave.BorderWidth = 2F;
            this.lbClave.CanGrow = false;
            this.lbClave.Dpi = 100F;
            this.lbClave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbClave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30F);
            this.lbClave.Name = "lbClave";
            this.lbClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClave.SizeF = new System.Drawing.SizeF(50F, 35F);
            this.lbClave.StylePriority.UseBorders = false;
            this.lbClave.StylePriority.UseBorderWidth = false;
            this.lbClave.StylePriority.UseFont = false;
            this.lbClave.StylePriority.UseTextAlignment = false;
            this.lbClave.Text = "Clave";
            this.lbClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbDescripcion.BorderWidth = 2F;
            this.lbDescripcion.CanGrow = false;
            this.lbDescripcion.Dpi = 100F;
            this.lbDescripcion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(50F, 30F);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDescripcion.SizeF = new System.Drawing.SizeF(300F, 35F);
            this.lbDescripcion.StylePriority.UseBorders = false;
            this.lbDescripcion.StylePriority.UseBorderWidth = false;
            this.lbDescripcion.StylePriority.UseFont = false;
            this.lbDescripcion.StylePriority.UseTextAlignment = false;
            this.lbDescripcion.Text = "Descripcion";
            this.lbDescripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbInvInicial
            // 
            this.lbInvInicial.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbInvInicial.BorderWidth = 2F;
            this.lbInvInicial.CanGrow = false;
            this.lbInvInicial.Dpi = 100F;
            this.lbInvInicial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbInvInicial.LocationFloat = new DevExpress.Utils.PointFloat(420F, 30F);
            this.lbInvInicial.Name = "lbInvInicial";
            this.lbInvInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbInvInicial.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.lbInvInicial.StylePriority.UseBorders = false;
            this.lbInvInicial.StylePriority.UseBorderWidth = false;
            this.lbInvInicial.StylePriority.UseFont = false;
            this.lbInvInicial.StylePriority.UseTextAlignment = false;
            this.lbInvInicial.Text = "Inventario Inicial";
            this.lbInvInicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbRecargas
            // 
            this.lbRecargas.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbRecargas.BorderWidth = 2F;
            this.lbRecargas.CanGrow = false;
            this.lbRecargas.Dpi = 100F;
            this.lbRecargas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbRecargas.LocationFloat = new DevExpress.Utils.PointFloat(500F, 30F);
            this.lbRecargas.Name = "lbRecargas";
            this.lbRecargas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbRecargas.SizeF = new System.Drawing.SizeF(70F, 35F);
            this.lbRecargas.StylePriority.UseBorders = false;
            this.lbRecargas.StylePriority.UseBorderWidth = false;
            this.lbRecargas.StylePriority.UseFont = false;
            this.lbRecargas.StylePriority.UseTextAlignment = false;
            this.lbRecargas.Text = "Recarga";
            this.lbRecargas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbDevolucionesCte
            // 
            this.lbDevolucionesCte.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbDevolucionesCte.BorderWidth = 2F;
            this.lbDevolucionesCte.CanGrow = false;
            this.lbDevolucionesCte.Dpi = 100F;
            this.lbDevolucionesCte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbDevolucionesCte.LocationFloat = new DevExpress.Utils.PointFloat(640F, 30F);
            this.lbDevolucionesCte.Name = "lbDevolucionesCte";
            this.lbDevolucionesCte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDevolucionesCte.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.lbDevolucionesCte.StylePriority.UseBorders = false;
            this.lbDevolucionesCte.StylePriority.UseBorderWidth = false;
            this.lbDevolucionesCte.StylePriority.UseFont = false;
            this.lbDevolucionesCte.StylePriority.UseTextAlignment = false;
            this.lbDevolucionesCte.Text = "Devoluciones Cliente";
            this.lbDevolucionesCte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbDescargasAlm
            // 
            this.lbDescargasAlm.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbDescargasAlm.BorderWidth = 2F;
            this.lbDescargasAlm.CanGrow = false;
            this.lbDescargasAlm.Dpi = 100F;
            this.lbDescargasAlm.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbDescargasAlm.LocationFloat = new DevExpress.Utils.PointFloat(790F, 30F);
            this.lbDescargasAlm.Name = "lbDescargasAlm";
            this.lbDescargasAlm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDescargasAlm.SizeF = new System.Drawing.SizeF(70F, 35F);
            this.lbDescargasAlm.StylePriority.UseBorders = false;
            this.lbDescargasAlm.StylePriority.UseBorderWidth = false;
            this.lbDescargasAlm.StylePriority.UseFont = false;
            this.lbDescargasAlm.StylePriority.UseTextAlignment = false;
            this.lbDescargasAlm.Text = "Descarga Almacen";
            this.lbDescargasAlm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbMermas
            // 
            this.lbMermas.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbMermas.BorderWidth = 2F;
            this.lbMermas.CanGrow = false;
            this.lbMermas.Dpi = 100F;
            this.lbMermas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbMermas.LocationFloat = new DevExpress.Utils.PointFloat(720F, 30F);
            this.lbMermas.Name = "lbMermas";
            this.lbMermas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbMermas.SizeF = new System.Drawing.SizeF(70F, 35F);
            this.lbMermas.StylePriority.UseBorders = false;
            this.lbMermas.StylePriority.UseBorderWidth = false;
            this.lbMermas.StylePriority.UseFont = false;
            this.lbMermas.StylePriority.UseTextAlignment = false;
            this.lbMermas.Text = "Merma";
            this.lbMermas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbVentas
            // 
            this.lbVentas.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbVentas.BorderWidth = 2F;
            this.lbVentas.CanGrow = false;
            this.lbVentas.Dpi = 100F;
            this.lbVentas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbVentas.LocationFloat = new DevExpress.Utils.PointFloat(860F, 30F);
            this.lbVentas.Name = "lbVentas";
            this.lbVentas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVentas.SizeF = new System.Drawing.SizeF(70F, 35F);
            this.lbVentas.StylePriority.UseBorders = false;
            this.lbVentas.StylePriority.UseBorderWidth = false;
            this.lbVentas.StylePriority.UseFont = false;
            this.lbVentas.StylePriority.UseTextAlignment = false;
            this.lbVentas.Text = "Ventas";
            this.lbVentas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbInvFinal
            // 
            this.lbInvFinal.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbInvFinal.BorderWidth = 2F;
            this.lbInvFinal.CanGrow = false;
            this.lbInvFinal.Dpi = 100F;
            this.lbInvFinal.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbInvFinal.LocationFloat = new DevExpress.Utils.PointFloat(1010F, 30F);
            this.lbInvFinal.Name = "lbInvFinal";
            this.lbInvFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbInvFinal.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.lbInvFinal.StylePriority.UseBorders = false;
            this.lbInvFinal.StylePriority.UseBorderWidth = false;
            this.lbInvFinal.StylePriority.UseFont = false;
            this.lbInvFinal.StylePriority.UseTextAlignment = false;
            this.lbInvFinal.Text = "Inventario Final";
            this.lbInvFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbImporte
            // 
            this.lbImporte.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbImporte.BorderWidth = 2F;
            this.lbImporte.CanGrow = false;
            this.lbImporte.Dpi = 100F;
            this.lbImporte.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbImporte.LocationFloat = new DevExpress.Utils.PointFloat(930F, 30F);
            this.lbImporte.Name = "lbImporte";
            this.lbImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbImporte.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.lbImporte.StylePriority.UseBorders = false;
            this.lbImporte.StylePriority.UseBorderWidth = false;
            this.lbImporte.StylePriority.UseFont = false;
            this.lbImporte.StylePriority.UseTextAlignment = false;
            this.lbImporte.Text = "Importe";
            this.lbImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel34,
            this.xrLabel32,
            this.xrLabel31,
            this.xrLabel30,
            this.xrLabel29,
            this.xrLabel28,
            this.xrLabel27,
            this.xrLabel26,
            this.xrLabel7});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 15F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.SubBand1,
            this.SubBand2,
            this.SubBand3,
            this.SubBand4,
            this.SubBand5});
            // 
            // xrLabel34
            // 
            this.xrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel34.BorderWidth = 2F;
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.InventarioFinal")});
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(1010F, 0F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel34.StylePriority.UseBorders = false;
            this.xrLabel34.StylePriority.UseBorderWidth = false;
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel34.Summary = xrSummary1;
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel32.BorderWidth = 2F;
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Importe")});
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(930F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel32.StylePriority.UseBorders = false;
            this.xrLabel32.StylePriority.UseBorderWidth = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:$#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel32.Summary = xrSummary2;
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel31.BorderWidth = 2F;
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Venta")});
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.StylePriority.UseBorderWidth = false;
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel31.Summary = xrSummary3;
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel30.BorderWidth = 2F;
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Descarga")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(790F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.StylePriority.UseBorderWidth = false;
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel30.Summary = xrSummary4;
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel29.BorderWidth = 2F;
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Merma")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(720F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.StylePriority.UseBorderWidth = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel29.Summary = xrSummary5;
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel28.BorderWidth = 2F;
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.DevolucionCli")});
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(640F, 0F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel28.StylePriority.UseBorders = false;
            this.xrLabel28.StylePriority.UseBorderWidth = false;
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel28.Summary = xrSummary6;
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel27.BorderWidth = 2F;
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CambioEnt")});
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(570F, 0F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel27.StylePriority.UseBorders = false;
            this.xrLabel27.StylePriority.UseBorderWidth = false;
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel27.Summary = xrSummary7;
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel26.BorderWidth = 2F;
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Recarga")});
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(70F, 15F);
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseBorderWidth = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel26.Summary = xrSummary8;
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel7.BorderWidth = 2F;
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.InvInicial")});
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(420F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseBorderWidth = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            xrSummary9.FormatString = "{0:#,#}";
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel7.Summary = xrSummary9;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // SubBand1
            // 
            this.SubBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.srptVentasContado});
            this.SubBand1.Dpi = 100F;
            this.SubBand1.HeightF = 25F;
            this.SubBand1.Name = "SubBand1";
            // 
            // srptVentasContado
            // 
            this.srptVentasContado.Dpi = 100F;
            this.srptVentasContado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.srptVentasContado.Name = "srptVentasContado";
            this.srptVentasContado.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VendedorId", null, "Query.VendedorId"));
            this.srptVentasContado.ReportSource = new VentasContadoPDR();
            this.srptVentasContado.SizeF = new System.Drawing.SizeF(1090F, 20F);
            // 
            // SubBand2
            // 
            this.SubBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.srptVentasCredito});
            this.SubBand2.Dpi = 100F;
            this.SubBand2.HeightF = 25F;
            this.SubBand2.Name = "SubBand2";
            // 
            // srptVentasCredito
            // 
            this.srptVentasCredito.Dpi = 100F;
            this.srptVentasCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.srptVentasCredito.Name = "srptVentasCredito";
            this.srptVentasCredito.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VendedorId", null, "Query.VendedorId"));
            this.srptVentasCredito.ReportSource = new VentasCreditoPDR();
            this.srptVentasCredito.SizeF = new System.Drawing.SizeF(1090F, 20F);
            // 
            // SubBand3
            // 
            this.SubBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.srptCobranza});
            this.SubBand3.Dpi = 100F;
            this.SubBand3.HeightF = 25F;
            this.SubBand3.Name = "SubBand3";
            // 
            // srptCobranza
            // 
            this.srptCobranza.Dpi = 100F;
            this.srptCobranza.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.srptCobranza.Name = "srptCobranza";
            this.srptCobranza.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VendedorID", null, "Query.VendedorID"));
            this.srptCobranza.ReportSource = new CobranzaPDR();
            this.srptCobranza.SizeF = new System.Drawing.SizeF(1090F, 20F);
            // 
            // SubBand4
            // 
            this.SubBand4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.srptPreliquidacion});
            this.SubBand4.Dpi = 100F;
            this.SubBand4.HeightF = 25F;
            this.SubBand4.Name = "SubBand4";
            // 
            // srptPreliquidacion
            // 
            this.srptPreliquidacion.Dpi = 100F;
            this.srptPreliquidacion.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.srptPreliquidacion.Name = "srptPreliquidacion";
            this.srptPreliquidacion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VendedorId", null, "Query.VendedorId"));
            this.srptPreliquidacion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VentaCredito", null, "Query.VentaCreditoVendedor"));
            this.srptPreliquidacion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VentaTotal", null, "Query.VentaTotalVendedor"));
            this.srptPreliquidacion.ReportSource = new PreliquidacionPDR();
            this.srptPreliquidacion.SizeF = new System.Drawing.SizeF(1090F, 20F);
            // 
            // SubBand5
            // 
            this.SubBand5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.srptDepositos,
            this.lbDesglose,
            this.srptDesglose});
            this.SubBand5.Dpi = 100F;
            this.SubBand5.HeightF = 35F;
            this.SubBand5.Name = "SubBand5";
            // 
            // srptDepositos
            // 
            this.srptDepositos.Dpi = 100F;
            this.srptDepositos.LocationFloat = new DevExpress.Utils.PointFloat(590F, 15F);
            this.srptDepositos.Name = "srptDepositos";
            this.srptDepositos.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VendedorID", null, "Query.VendedorId"));
            this.srptDepositos.ReportSource = new DesglosePDR();
            this.srptDepositos.SizeF = new System.Drawing.SizeF(500F, 20F);
            // 
            // lbDesglose
            // 
            this.lbDesglose.Dpi = 100F;
            this.lbDesglose.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lbDesglose.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lbDesglose.Name = "lbDesglose";
            this.lbDesglose.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDesglose.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.lbDesglose.StylePriority.UseFont = false;
            this.lbDesglose.Text = "Desglose";
            // 
            // srptDesglose
            // 
            this.srptDesglose.Dpi = 100F;
            this.srptDesglose.LocationFloat = new DevExpress.Utils.PointFloat(0F, 15F);
            this.srptDesglose.Name = "srptDesglose";
            this.srptDesglose.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("VendedorID", null, "Query.VendedorId"));
            this.srptDesglose.ReportSource = new DesgloseEfectivo();
            this.srptDesglose.SizeF = new System.Drawing.SizeF(500F, 20F);
            // 
            // InventarioFinal
            // 
            this.InventarioFinal.DataMember = "Query";
            this.InventarioFinal.Expression = "[InvInicial]+[Recarga]-[Merma]-[Descarga]-[Venta]+[DevolucionCli]";
            this.InventarioFinal.Name = "InventarioFinal";
            // 
            // VentaTotalVendedor
            // 
            this.VentaTotalVendedor.DataMember = "Query";
            this.VentaTotalVendedor.Expression = "[][[VendedorId] ==  [^.VendedorId]].Sum([Importe])";
            this.VentaTotalVendedor.FieldType = DevExpress.XtraReports.UI.FieldType.Double;
            this.VentaTotalVendedor.Name = "VentaTotalVendedor";
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "Query";
            this.calculatedField1.Expression = "[][[VendedorId] ==  [^.VendedorId]].Sum([TotalCredito])";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // VentaCreditoVendedor
            // 
            this.VentaCreditoVendedor.DataMember = "Query";
            this.VentaCreditoVendedor.Expression = "[][[VendedorId] ==  [^.VendedorId]].Sum([ImporteCredito])";
            this.VentaCreditoVendedor.Name = "VentaCreditoVendedor";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 15F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(990F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // LiquidacionPDR
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.InventarioFinal,
            this.VentaTotalVendedor,
            this.calculatedField1,
            this.VentaCreditoVendedor});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsProductos});
            this.DataMember = "Query";
            this.DataSource = this.dsProductos;
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
