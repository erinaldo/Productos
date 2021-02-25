using System;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Drawing;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class ReporteMovimientosProducto : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    public XRLabel lblCuenta;
    public XRLabel lblEquipo;
    public XRLabel lblListaPrecio;
    public XRLabel lblAlmacen;
    public XRLabel lblFecha;
    public XRLabel lblVendedor;
    public XRLabel lblCliente;
    public XRLabel lblReferencia;
    private DevExpress.XtraReports.Parameters.Parameter parameterCedis;
    private DevExpress.XtraReports.Parameters.Parameter parameterRutas;
    private DevExpress.XtraReports.Parameters.Parameter parameterVendedores;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicio;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaFin;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private string Cedis;
    private DateTime FechaInicial;
    private DateTime FechaFinal;
    private string Rutas;
    private string Vendedores;
    private FormattingRule OcultarCantidadesDevoluciones;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource2;
    private GroupHeaderBand GroupHeader2;
    private GroupFooterBand GroupFooter1;
    private SubBand SubBand1;
    private XRLabel xrLabel1;
    private SubBand SubBand2;
    private XRLabel xrLabel8;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private CalculatedField Cliente;
    private CalculatedField TExistencia;
    private XRLabel xrLabel3;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel9;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel13;
    private XRLabel xrLabel10;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private FormattingRule MostrarCantidadesDevoluciones;

    private string NombreCEDIS;
    private string NombreReporte;
    private string NombreEmpresa;
    private XRPictureBox logo;
    private XRLabel Reporte;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    private CalculatedField CEDI;
    private MemoryStream LogoEmpresa;

    public ReporteMovimientosProducto()
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
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery2 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteMovimientosProducto));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.SubBand1 = new DevExpress.XtraReports.UI.SubBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterFechaInicio = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.SubBand2 = new DevExpress.XtraReports.UI.SubBand();
            this.lblReferencia = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEquipo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblListaPrecio = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAlmacen = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lblVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCuenta = new DevExpress.XtraReports.UI.XRLabel();
            this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterRutas = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameterVendedores = new DevExpress.XtraReports.Parameters.Parameter();
            this.OcultarCantidadesDevoluciones = new DevExpress.XtraReports.UI.FormattingRule();
            this.MostrarCantidadesDevoluciones = new DevExpress.XtraReports.UI.FormattingRule();
            this.sqlDataSource2 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Cliente = new DevExpress.XtraReports.UI.CalculatedField();
            this.TExistencia = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.CEDI = new DevExpress.XtraReports.UI.CalculatedField();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel2,
            this.xrLabel8});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.MotivoNoCompra")});
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(860.2083F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(179.7917F, 23F);
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.MotivoDevolucion")});
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(680.2083F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(179.7917F, 23F);
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Rotacion")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(589.9999F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.MotivoDevolucion")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(410.2084F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(179.7916F, 23F);
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "xrLabel14";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Devolucion")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(320F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Venta")});
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(230F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrLabel10";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Existencia")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.ProductoClave")});
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 8F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.Reporte,
            this.logo});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 198.9584F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.SubBand1,
            this.SubBand2});
            // 
            // Reporte
            // 
            this.Reporte.Dpi = 100F;
            this.Reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.Reporte.LocationFloat = new DevExpress.Utils.PointFloat(270F, 10F);
            this.Reporte.Name = "Reporte";
            this.Reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Reporte.SizeF = new System.Drawing.SizeF(500F, 40F);
            this.Reporte.StylePriority.UseFont = false;
            this.Reporte.StylePriority.UseTextAlignment = false;
            this.Reporte.Text = "MOVIMIENTOS DE PRODUCTO (NOR)";
            this.Reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 10.00001F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // SubBand1
            // 
            this.SubBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel1});
            this.SubBand1.Dpi = 100F;
            this.SubBand1.HeightF = 23F;
            this.SubBand1.Name = "SubBand1";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.parameterFechaFin, "Text", "{0:dd/MM/yyyy}")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(210F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel9.Text = "xrLabel9";
            // 
            // parameterFechaFin
            // 
            this.parameterFechaFin.Description = "parameterFechaFin";
            this.parameterFechaFin.Name = "parameterFechaFin";
            this.parameterFechaFin.ValueInfo = "2020-05-18";
            this.parameterFechaFin.Visible = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(10F, 23F);
            this.xrLabel7.Text = "-";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.parameterFechaInicio, "Text", "{0:dd/MM/yyyy}")});
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // parameterFechaInicio
            // 
            this.parameterFechaInicio.Description = "parameterFechaInicio";
            this.parameterFechaInicio.Name = "parameterFechaInicio";
            this.parameterFechaInicio.ValueInfo = "2020-05-16";
            this.parameterFechaInicio.Visible = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.xrLabel1.StylePriority.UseBorderColor = false;
            this.xrLabel1.Text = "Fecha: ";
            // 
            // SubBand2
            // 
            this.SubBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblReferencia,
            this.lblEquipo,
            this.lblListaPrecio,
            this.lblAlmacen,
            this.lblFecha,
            this.lblVendedor,
            this.lblCliente,
            this.lblCuenta});
            this.SubBand2.Dpi = 100F;
            this.SubBand2.HeightF = 30F;
            this.SubBand2.Name = "SubBand2";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoWidth = true;
            this.lblReferencia.BorderColor = System.Drawing.Color.Transparent;
            this.lblReferencia.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblReferencia.CanGrow = false;
            this.lblReferencia.Dpi = 100F;
            this.lblReferencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblReferencia.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReferencia.SizeF = new System.Drawing.SizeF(90F, 30F);
            this.lblReferencia.StylePriority.UseBorderColor = false;
            this.lblReferencia.StylePriority.UseBorders = false;
            this.lblReferencia.StylePriority.UseFont = false;
            this.lblReferencia.StylePriority.UseTextAlignment = false;
            this.lblReferencia.Text = "Producto";
            this.lblReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoWidth = true;
            this.lblEquipo.BorderColor = System.Drawing.Color.Transparent;
            this.lblEquipo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblEquipo.CanGrow = false;
            this.lblEquipo.Dpi = 100F;
            this.lblEquipo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblEquipo.LocationFloat = new DevExpress.Utils.PointFloat(680F, 0F);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEquipo.SizeF = new System.Drawing.SizeF(180F, 30F);
            this.lblEquipo.StylePriority.UseBorderColor = false;
            this.lblEquipo.StylePriority.UseBorders = false;
            this.lblEquipo.StylePriority.UseFont = false;
            this.lblEquipo.StylePriority.UseTextAlignment = false;
            this.lblEquipo.Text = "Motivo Rotación";
            this.lblEquipo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblListaPrecio
            // 
            this.lblListaPrecio.AutoWidth = true;
            this.lblListaPrecio.BorderColor = System.Drawing.Color.Transparent;
            this.lblListaPrecio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblListaPrecio.CanGrow = false;
            this.lblListaPrecio.Dpi = 100F;
            this.lblListaPrecio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblListaPrecio.LocationFloat = new DevExpress.Utils.PointFloat(590F, 0F);
            this.lblListaPrecio.Name = "lblListaPrecio";
            this.lblListaPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblListaPrecio.SizeF = new System.Drawing.SizeF(90F, 30F);
            this.lblListaPrecio.StylePriority.UseBorderColor = false;
            this.lblListaPrecio.StylePriority.UseBorders = false;
            this.lblListaPrecio.StylePriority.UseFont = false;
            this.lblListaPrecio.StylePriority.UseTextAlignment = false;
            this.lblListaPrecio.Text = "Rotación";
            this.lblListaPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoWidth = true;
            this.lblAlmacen.BorderColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblAlmacen.CanGrow = false;
            this.lblAlmacen.Dpi = 100F;
            this.lblAlmacen.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlmacen.LocationFloat = new DevExpress.Utils.PointFloat(410F, 0F);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAlmacen.SizeF = new System.Drawing.SizeF(180F, 30F);
            this.lblAlmacen.StylePriority.UseBorderColor = false;
            this.lblAlmacen.StylePriority.UseBorders = false;
            this.lblAlmacen.StylePriority.UseFont = false;
            this.lblAlmacen.StylePriority.UseTextAlignment = false;
            this.lblAlmacen.Text = "Motivo Devolución";
            this.lblAlmacen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoWidth = true;
            this.lblFecha.BorderColor = System.Drawing.Color.Transparent;
            this.lblFecha.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblFecha.CanGrow = false;
            this.lblFecha.Dpi = 100F;
            this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.LocationFloat = new DevExpress.Utils.PointFloat(320F, 0F);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFecha.SizeF = new System.Drawing.SizeF(90F, 30F);
            this.lblFecha.StylePriority.UseBorderColor = false;
            this.lblFecha.StylePriority.UseBorders = false;
            this.lblFecha.StylePriority.UseFont = false;
            this.lblFecha.StylePriority.UseTextAlignment = false;
            this.lblFecha.Text = "Devolución";
            this.lblFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoWidth = true;
            this.lblVendedor.BorderColor = System.Drawing.Color.Transparent;
            this.lblVendedor.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblVendedor.CanGrow = false;
            this.lblVendedor.Dpi = 100F;
            this.lblVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblVendedor.LocationFloat = new DevExpress.Utils.PointFloat(230F, 0F);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblVendedor.SizeF = new System.Drawing.SizeF(90F, 30F);
            this.lblVendedor.StylePriority.UseBorderColor = false;
            this.lblVendedor.StylePriority.UseBorders = false;
            this.lblVendedor.StylePriority.UseFont = false;
            this.lblVendedor.StylePriority.UseTextAlignment = false;
            this.lblVendedor.Text = "Venta";
            this.lblVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoWidth = true;
            this.lblCliente.BorderColor = System.Drawing.Color.Transparent;
            this.lblCliente.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCliente.CanGrow = false;
            this.lblCliente.Dpi = 100F;
            this.lblCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCliente.SizeF = new System.Drawing.SizeF(90F, 30F);
            this.lblCliente.StylePriority.UseBorderColor = false;
            this.lblCliente.StylePriority.UseBorders = false;
            this.lblCliente.StylePriority.UseFont = false;
            this.lblCliente.StylePriority.UseTextAlignment = false;
            this.lblCliente.Text = "Existencia";
            this.lblCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoWidth = true;
            this.lblCuenta.BorderColor = System.Drawing.Color.Transparent;
            this.lblCuenta.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCuenta.CanGrow = false;
            this.lblCuenta.Dpi = 100F;
            this.lblCuenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lblCuenta.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCuenta.SizeF = new System.Drawing.SizeF(180F, 30F);
            this.lblCuenta.StylePriority.UseBorderColor = false;
            this.lblCuenta.StylePriority.UseBorders = false;
            this.lblCuenta.StylePriority.UseFont = false;
            this.lblCuenta.StylePriority.UseTextAlignment = false;
            this.lblCuenta.Text = "Motivo No Compra";
            this.lblCuenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // parameterCedis
            // 
            this.parameterCedis.Description = "parameterCedis";
            this.parameterCedis.Name = "parameterCedis";
            this.parameterCedis.ValueInfo = "20";
            this.parameterCedis.Visible = false;
            // 
            // parameterRutas
            // 
            this.parameterRutas.Description = "parameterRutas";
            this.parameterRutas.Name = "parameterRutas";
            this.parameterRutas.ValueInfo = "SUR09";
            this.parameterRutas.Visible = false;
            // 
            // parameterVendedores
            // 
            this.parameterVendedores.Description = "parameterVendedores";
            this.parameterVendedores.Name = "parameterVendedores";
            this.parameterVendedores.Visible = false;
            // 
            // OcultarCantidadesDevoluciones
            // 
            this.OcultarCantidadesDevoluciones.Condition = "EndsWith(ToStr([Referencia]), \'D\')";
            // 
            // 
            // 
            this.OcultarCantidadesDevoluciones.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.OcultarCantidadesDevoluciones.Name = "OcultarCantidadesDevoluciones";
            // 
            // MostrarCantidadesDevoluciones
            // 
            this.MostrarCantidadesDevoluciones.Condition = "EndsWith(ToStr([Referencia]), \'D\')";
            // 
            // 
            // 
            this.MostrarCantidadesDevoluciones.Formatting.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.MostrarCantidadesDevoluciones.Name = "MostrarCantidadesDevoluciones";
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionName = "RouteEntities (eRoute)";
            this.sqlDataSource2.Name = "sqlDataSource2";
            storedProcQuery2.Name = "stpr_ReporteMovimientosProducto";
            queryParameter2.Name = "@filtroCEDIS";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCedis]", typeof(string));
            queryParameter3.Name = "@filtroClientes";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRutas]", typeof(string));
            queryParameter4.Name = "@filtroVendedores";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterVendedores]", typeof(string));
            queryParameter5.Name = "@filtroFechaInicio";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaInicio]", typeof(string));
            queryParameter6.Name = "@filtroFechaFin";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaFin]", typeof(string));
            storedProcQuery2.Parameters.Add(queryParameter2);
            storedProcQuery2.Parameters.Add(queryParameter3);
            storedProcQuery2.Parameters.Add(queryParameter4);
            storedProcQuery2.Parameters.Add(queryParameter5);
            storedProcQuery2.Parameters.Add(queryParameter6);
            storedProcQuery2.StoredProcName = "stpr_ReporteMovimientosProducto";
            this.sqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery2});
            this.sqlDataSource2.ResultSchemaSerializable = resources.GetString("sqlDataSource2.ResultSchemaSerializable");
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Clave", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.HeightF = 23.00003F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Cliente")});
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0.2083302F, 3.178914E-05F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(1039.792F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel13,
            this.xrLabel3,
            this.xrLabel10});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter1.HeightF = 40F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Rotacion")});
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(590F, 12.00002F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel16.Summary = xrSummary1;
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Devolucion")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(320F, 12.00002F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel13.Summary = xrSummary2;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Existencia")});
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(140F, 12.00002F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel3.Summary = xrSummary3;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.Venta")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(230F, 12.00002F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(90F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel10.Summary = xrSummary4;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Cliente
            // 
            this.Cliente.DataMember = "stpr_ReporteMovimientosProducto";
            this.Cliente.DisplayName = "Cliente";
            this.Cliente.Expression = "Concat([Clave],\' - \' +  Concat(Concat([RazonSocial], \',\'),[Domicilio] ))";
            this.Cliente.Name = "Cliente";
            // 
            // TExistencia
            // 
            this.TExistencia.DataMember = "stpr_ReporteMovimientosProducto";
            this.TExistencia.DisplayName = "TExistencia";
            this.TExistencia.Expression = "[Clave].Sum([Existencia])";
            this.TExistencia.Name = "TExistencia";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("FechaCaptura", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 23F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteMovimientosProducto.FechaCaptura", "{0:dd/MM/yyyy}")});
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(25.41668F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "xrLabel5";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "RouteEntities (eRoute)";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "stpr_ObtenerDatosCedis";
            queryParameter1.Name = "@filtroVendedores";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterVendedores]", typeof(string));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.StoredProcName = "stpr_ObtenerDatosCedis";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // CEDI
            // 
            this.CEDI.DataMember = "stpr_ObtenerDatosCedis";
            this.CEDI.DataSource = this.sqlDataSource1;
            this.CEDI.DisplayName = "CEDI";
            this.CEDI.Expression = "[Clave] + \' - \' + [Nombre]";
            this.CEDI.Name = "CEDI";
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "stpr_ObtenerDatosCedis.CEDI")});
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 109.3333F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(249.7917F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "xrLabel19";
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "stpr_ObtenerDatosCedis.Domicilio")});
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(10.20833F, 132.3333F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(249.5833F, 22.99999F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "xrLabel20";
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "stpr_ObtenerDatosCedis.Telefono")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(10.41666F, 155.3333F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(249.375F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "xrLabel21";
            // 
            // ReporteMovimientosProducto
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader2,
            this.GroupFooter1,
            this.GroupHeader1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.Cliente,
            this.TExistencia,
            this.CEDI});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource2,
            this.sqlDataSource1});
            this.DataMember = "stpr_ReporteMovimientosProducto";
            this.DataSource = this.sqlDataSource2;
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.OcultarCantidadesDevoluciones,
            this.MostrarCantidadesDevoluciones});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(5, 5, 0, 8);
            this.PageHeight = 1500;
            this.PageWidth = 1500;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCedis,
            this.parameterRutas,
            this.parameterVendedores,
            this.parameterFechaInicio,
            this.parameterFechaFin});
            this.Version = "16.1";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.ReporteMovimientosProducto_DataSourceDemanded);
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReporteMovimientosProducto_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void ReporteMovimientosProducto_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        
        if (((DevExpress.DataAccess.Native.Sql.ResultSet)((DevExpress.DataAccess.Sql.SqlDataSource)DataSource).Result).Tables.ToList()[0].Count == 0)
        {
            e.Cancel = true;
            throw new Exception("No tiene datos");
        }
    }

    public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string Cedis, string TipoFecha, string FechaInicial, string FechaFinal, string Rutas, string Vendedores)
    {
        this.NombreReporte = NombreReporte;
        this.NombreEmpresa = NombreEmpresa;
        this.LogoEmpresa = LogoEmpresa;
        this.Cedis = Cedis;
        this.FechaInicial = DateTime.Parse(FechaInicial);
        if (TipoFecha.Equals("Igual"))
            this.FechaFinal = DateTime.Parse(FechaInicial);
        else
            this.FechaFinal = DateTime.Parse(FechaFinal);
        if (Rutas.Equals(""))
            this.Rutas = null;
        this.Vendedores = Vendedores;
        Name = string.Format("Ventas{0:yyyy'-'MM'-'dd'T'HH':'mm':'ss}.xlsx", DateTime.Now);

        InitializeComponent();

        try
        {
            this.logo.Image = Image.FromStream(this.LogoEmpresa);
            this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        }
        catch (Exception ex)
        {

        }

        this.Reporte.Text = this.NombreReporte;

        return this;
    }

    private void lblDetalle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (((DevExpress.DataAccess.Native.Sql.ResultRow)GetCurrentRow()).Index > 0)
        {
            if ((!GetCurrentColumnValue("Referencia").ToString().Equals(GetPreviousColumnValue("Referencia").ToString())))
                ((XRLabel)sender).Visible = true;
            else
                ((XRLabel)sender).Visible = false;
        }
    }

    private void lblDevoluciones_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (((DevExpress.DataAccess.Native.Sql.ResultRow)GetCurrentRow()).Index > 0)
        {
            if ((GetCurrentColumnValue("Referencia").ToString().Equals(GetPreviousColumnValue("Referencia").ToString())))
            {
                if (GetCurrentColumnValue("Referencia").ToString().Contains("D"))
                {
                    Debug.WriteLine(GetCurrentColumnValue("ProductoClave") + " - " + GetPreviousColumnValue("ProductoClave") + " SEPARANDO " + GetCurrentColumnValue("Referencia") + " - " + GetPreviousColumnValue("Referencia"));
                    if ((!GetCurrentColumnValue("ProductoClave").ToString().Equals(GetPreviousColumnValue("ProductoClave").ToString())))
                    {
                        ((XRLabel)sender).Visible = true;
                    }
                    else
                    {
                        ((XRLabel)sender).Visible = false;
                    }
                }
            }

        }
    }

    private void ReporteMovimientosProducto_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterCedis"].Value = this.Cedis;
        this.Parameters["parameterRutas"].Value = this.Rutas;
        this.Parameters["parameterVendedores"].Value = this.Vendedores;
        this.Parameters["parameterFechaInicio"].Value = this.FechaInicial.Date.ToString("s");
        this.Parameters["parameterFechaFin"].Value = this.FechaFinal.Date.ToString("s");
    }

}
