using System;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Diagnostics;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class R262Ventas : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand ReportHeader;
    public XRLabel lblEtiqueta;
    public XRLabel lblRuta;
    public XRLabel lblPrecio;
    public XRLabel lblCantidadEntregada;
    public XRLabel lblCantidadPedida;
    public XRLabel lblDescripcion;
    public XRLabel lblProducto;
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
    private CalculatedField calculatedCantidad;
    private FormattingRule OcultarCantidadesDevoluciones;
    private XRLabel xrLabel3;
    private XRLabel xrLabel1;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel lblDReferencia;
    private XRLabel lblDEquipo;
    private XRLabel lblDListaPrecio;
    private XRLabel lblDAlmacen;
    private XRLabel lblDFecha;
    private XRLabel lblDVendedor;
    private XRLabel lblDCliente;
    private XRLabel lblDCuenta;
    private GroupHeaderBand GroupHeader1;
    private FormattingRule MostrarCantidadesDevoluciones;

    public R262Ventas()
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
        DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R262Ventas));
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDReferencia = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDEquipo = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDListaPrecio = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDAlmacen = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDFecha = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDVendedor = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDCliente = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDCuenta = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.lblEtiqueta = new DevExpress.XtraReports.UI.XRLabel();
        this.lblRuta = new DevExpress.XtraReports.UI.XRLabel();
        this.lblPrecio = new DevExpress.XtraReports.UI.XRLabel();
        this.lblCantidadEntregada = new DevExpress.XtraReports.UI.XRLabel();
        this.lblCantidadPedida = new DevExpress.XtraReports.UI.XRLabel();
        this.lblDescripcion = new DevExpress.XtraReports.UI.XRLabel();
        this.lblProducto = new DevExpress.XtraReports.UI.XRLabel();
        this.lblCuenta = new DevExpress.XtraReports.UI.XRLabel();
        this.lblEquipo = new DevExpress.XtraReports.UI.XRLabel();
        this.lblListaPrecio = new DevExpress.XtraReports.UI.XRLabel();
        this.lblAlmacen = new DevExpress.XtraReports.UI.XRLabel();
        this.lblFecha = new DevExpress.XtraReports.UI.XRLabel();
        this.lblVendedor = new DevExpress.XtraReports.UI.XRLabel();
        this.lblCliente = new DevExpress.XtraReports.UI.XRLabel();
        this.lblReferencia = new DevExpress.XtraReports.UI.XRLabel();
        this.parameterCedis = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterRutas = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterVendedores = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterFechaInicio = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterFechaFin = new DevExpress.XtraReports.Parameters.Parameter();
        this.calculatedCantidad = new DevExpress.XtraReports.UI.CalculatedField();
        this.OcultarCantidadesDevoluciones = new DevExpress.XtraReports.UI.FormattingRule();
        this.MostrarCantidadesDevoluciones = new DevExpress.XtraReports.UI.FormattingRule();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel1,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel10,
            this.xrLabel9,
            this.lblDReferencia,
            this.lblDEquipo,
            this.lblDListaPrecio,
            this.lblDAlmacen,
            this.lblDFecha,
            this.lblDVendedor,
            this.lblDCliente,
            this.lblDCuenta});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 15F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel3
        // 
        this.xrLabel3.CanGrow = false;
        this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.calculatedCantidad")});
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1090F, 0F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "xrLabel1";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabel3.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDevoluciones_BeforePrint);
        // 
        // xrLabel1
        // 
        this.xrLabel1.CanGrow = false;
        this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.calculatedCantidad")});
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1170F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "xrLabel1";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabel1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDevoluciones_BeforePrint);
        // 
        // xrLabel15
        // 
        this.xrLabel15.AutoWidth = true;
        this.xrLabel15.CanGrow = false;
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Zona")});
        this.xrLabel15.Dpi = 100F;
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(1410F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrLabel15.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDevoluciones_BeforePrint);
        // 
        // xrLabel14
        // 
        this.xrLabel14.AutoWidth = true;
        this.xrLabel14.CanGrow = false;
        this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Ruta")});
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(1330F, 0F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrLabel14.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDevoluciones_BeforePrint);
        // 
        // xrLabel13
        // 
        this.xrLabel13.AutoWidth = true;
        this.xrLabel13.CanGrow = false;
        this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Precio")});
        this.xrLabel13.Dpi = 100F;
        this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(1250F, 0F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabel13.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDevoluciones_BeforePrint);
        // 
        // xrLabel10
        // 
        this.xrLabel10.AutoWidth = true;
        this.xrLabel10.CanGrow = false;
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Folio")});
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(940F, 0F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrLabel10.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDevoluciones_BeforePrint);
        // 
        // xrLabel9
        // 
        this.xrLabel9.AutoWidth = true;
        this.xrLabel9.CanGrow = false;
        this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.ProductoClave")});
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrLabel9.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDevoluciones_BeforePrint);
        // 
        // lblDReferencia
        // 
        this.lblDReferencia.AutoWidth = true;
        this.lblDReferencia.CanGrow = false;
        this.lblDReferencia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Referencia")});
        this.lblDReferencia.Dpi = 100F;
        this.lblDReferencia.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDReferencia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.lblDReferencia.Name = "lblDReferencia";
        this.lblDReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDReferencia.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.lblDReferencia.StylePriority.UseFont = false;
        this.lblDReferencia.StylePriority.UseTextAlignment = false;
        this.lblDReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDReferencia.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
        // 
        // lblDEquipo
        // 
        this.lblDEquipo.AutoWidth = true;
        this.lblDEquipo.CanGrow = false;
        this.lblDEquipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Zona")});
        this.lblDEquipo.Dpi = 100F;
        this.lblDEquipo.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDEquipo.LocationFloat = new DevExpress.Utils.PointFloat(660F, 0F);
        this.lblDEquipo.Name = "lblDEquipo";
        this.lblDEquipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDEquipo.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.lblDEquipo.StylePriority.UseFont = false;
        this.lblDEquipo.StylePriority.UseTextAlignment = false;
        this.lblDEquipo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDEquipo.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
        // 
        // lblDListaPrecio
        // 
        this.lblDListaPrecio.AutoWidth = true;
        this.lblDListaPrecio.CanGrow = false;
        this.lblDListaPrecio.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.PrecioClave")});
        this.lblDListaPrecio.Dpi = 100F;
        this.lblDListaPrecio.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDListaPrecio.LocationFloat = new DevExpress.Utils.PointFloat(590F, 0F);
        this.lblDListaPrecio.Name = "lblDListaPrecio";
        this.lblDListaPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDListaPrecio.SizeF = new System.Drawing.SizeF(70F, 15F);
        this.lblDListaPrecio.StylePriority.UseFont = false;
        this.lblDListaPrecio.StylePriority.UseTextAlignment = false;
        this.lblDListaPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDListaPrecio.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
        // 
        // lblDAlmacen
        // 
        this.lblDAlmacen.AutoWidth = true;
        this.lblDAlmacen.CanGrow = false;
        this.lblDAlmacen.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Almacen")});
        this.lblDAlmacen.Dpi = 100F;
        this.lblDAlmacen.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDAlmacen.LocationFloat = new DevExpress.Utils.PointFloat(520F, 0F);
        this.lblDAlmacen.Name = "lblDAlmacen";
        this.lblDAlmacen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDAlmacen.SizeF = new System.Drawing.SizeF(70F, 15F);
        this.lblDAlmacen.StylePriority.UseFont = false;
        this.lblDAlmacen.StylePriority.UseTextAlignment = false;
        this.lblDAlmacen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDAlmacen.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
        // 
        // lblDFecha
        // 
        this.lblDFecha.AutoWidth = true;
        this.lblDFecha.CanGrow = false;
        this.lblDFecha.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.FechaCaptura", "{0:dd/MM/yyyy}")});
        this.lblDFecha.Dpi = 100F;
        this.lblDFecha.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDFecha.LocationFloat = new DevExpress.Utils.PointFloat(450F, 0F);
        this.lblDFecha.Name = "lblDFecha";
        this.lblDFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDFecha.SizeF = new System.Drawing.SizeF(70F, 15F);
        this.lblDFecha.StylePriority.UseFont = false;
        this.lblDFecha.StylePriority.UseTextAlignment = false;
        this.lblDFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDFecha.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
        // 
        // lblDVendedor
        // 
        this.lblDVendedor.AutoWidth = true;
        this.lblDVendedor.CanGrow = false;
        this.lblDVendedor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Vendedor")});
        this.lblDVendedor.Dpi = 100F;
        this.lblDVendedor.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDVendedor.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
        this.lblDVendedor.Name = "lblDVendedor";
        this.lblDVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDVendedor.SizeF = new System.Drawing.SizeF(300F, 15F);
        this.lblDVendedor.StylePriority.UseFont = false;
        this.lblDVendedor.StylePriority.UseTextAlignment = false;
        this.lblDVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDVendedor.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
        // 
        // lblDCliente
        // 
        this.lblDCliente.AutoWidth = true;
        this.lblDCliente.CanGrow = false;
        this.lblDCliente.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Cliente")});
        this.lblDCliente.Dpi = 100F;
        this.lblDCliente.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDCliente.LocationFloat = new DevExpress.Utils.PointFloat(90F, 0F);
        this.lblDCliente.Name = "lblDCliente";
        this.lblDCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDCliente.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.lblDCliente.StylePriority.UseFont = false;
        this.lblDCliente.StylePriority.UseTextAlignment = false;
        this.lblDCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDCliente.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
        // 
        // lblDCuenta
        // 
        this.lblDCuenta.AutoWidth = true;
        this.lblDCuenta.CanGrow = false;
        this.lblDCuenta.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.CuentaAnalitica")});
        this.lblDCuenta.Dpi = 100F;
        this.lblDCuenta.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.lblDCuenta.LocationFloat = new DevExpress.Utils.PointFloat(760F, 0F);
        this.lblDCuenta.Name = "lblDCuenta";
        this.lblDCuenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDCuenta.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.lblDCuenta.StylePriority.UseFont = false;
        this.lblDCuenta.StylePriority.UseTextAlignment = false;
        this.lblDCuenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.lblDCuenta.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
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
        // sqlDataSource1
        // 
        this.sqlDataSource1.ConnectionName = "eRouteConnection";
        this.sqlDataSource1.ConnectionOptions.CommandTimeout = 5000;
        this.sqlDataSource1.Name = "sqlDataSource1";
        storedProcQuery1.Name = "stpr_Reporte262Ventas";
        queryParameter1.Name = "@filtroCEDIS";
        queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCedis]", typeof(string));
        queryParameter2.Name = "@filtroRutas";
        queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterRutas]", typeof(string));
        queryParameter3.Name = "@filtroVendedores";
        queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterVendedores]", typeof(string));
        queryParameter4.Name = "@filtroFechaInicio";
        queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaInicio]", typeof(string));
        queryParameter5.Name = "@filtroFechaFin";
        queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaFin]", typeof(string));
        storedProcQuery1.Parameters.Add(queryParameter1);
        storedProcQuery1.Parameters.Add(queryParameter2);
        storedProcQuery1.Parameters.Add(queryParameter3);
        storedProcQuery1.Parameters.Add(queryParameter4);
        storedProcQuery1.Parameters.Add(queryParameter5);
        storedProcQuery1.StoredProcName = "stpr_Reporte262Ventas";
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblEtiqueta,
            this.lblRuta,
            this.lblPrecio,
            this.lblCantidadEntregada,
            this.lblCantidadPedida,
            this.lblDescripcion,
            this.lblProducto,
            this.lblCuenta,
            this.lblEquipo,
            this.lblListaPrecio,
            this.lblAlmacen,
            this.lblFecha,
            this.lblVendedor,
            this.lblCliente,
            this.lblReferencia});
        this.ReportHeader.Dpi = 100F;
        this.ReportHeader.HeightF = 50F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // lblEtiqueta
        // 
        this.lblEtiqueta.AutoWidth = true;
        this.lblEtiqueta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblEtiqueta.CanGrow = false;
        this.lblEtiqueta.Dpi = 100F;
        this.lblEtiqueta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblEtiqueta.LocationFloat = new DevExpress.Utils.PointFloat(1410F, 0F);
        this.lblEtiqueta.Name = "lblEtiqueta";
        this.lblEtiqueta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblEtiqueta.SizeF = new System.Drawing.SizeF(80F, 50F);
        this.lblEtiqueta.StylePriority.UseBorders = false;
        this.lblEtiqueta.StylePriority.UseFont = false;
        this.lblEtiqueta.StylePriority.UseTextAlignment = false;
        this.lblEtiqueta.Text = "Líneas del pedido/Etiquetas analíticas";
        this.lblEtiqueta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblRuta
        // 
        this.lblRuta.AutoWidth = true;
        this.lblRuta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblRuta.CanGrow = false;
        this.lblRuta.Dpi = 100F;
        this.lblRuta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblRuta.LocationFloat = new DevExpress.Utils.PointFloat(1330F, 0F);
        this.lblRuta.Name = "lblRuta";
        this.lblRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblRuta.SizeF = new System.Drawing.SizeF(80F, 50F);
        this.lblRuta.StylePriority.UseBorders = false;
        this.lblRuta.StylePriority.UseFont = false;
        this.lblRuta.StylePriority.UseTextAlignment = false;
        this.lblRuta.Text = "Líneas del pedido/Ruta";
        this.lblRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblPrecio
        // 
        this.lblPrecio.AutoWidth = true;
        this.lblPrecio.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblPrecio.CanGrow = false;
        this.lblPrecio.Dpi = 100F;
        this.lblPrecio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblPrecio.LocationFloat = new DevExpress.Utils.PointFloat(1250F, 0F);
        this.lblPrecio.Name = "lblPrecio";
        this.lblPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblPrecio.SizeF = new System.Drawing.SizeF(80F, 50F);
        this.lblPrecio.StylePriority.UseBorders = false;
        this.lblPrecio.StylePriority.UseFont = false;
        this.lblPrecio.StylePriority.UseTextAlignment = false;
        this.lblPrecio.Text = "Líneas del pedido/Precio unitario";
        this.lblPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblCantidadEntregada
        // 
        this.lblCantidadEntregada.AutoWidth = true;
        this.lblCantidadEntregada.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblCantidadEntregada.CanGrow = false;
        this.lblCantidadEntregada.Dpi = 100F;
        this.lblCantidadEntregada.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblCantidadEntregada.LocationFloat = new DevExpress.Utils.PointFloat(1170F, 0F);
        this.lblCantidadEntregada.Name = "lblCantidadEntregada";
        this.lblCantidadEntregada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblCantidadEntregada.SizeF = new System.Drawing.SizeF(80F, 50F);
        this.lblCantidadEntregada.StylePriority.UseBorders = false;
        this.lblCantidadEntregada.StylePriority.UseFont = false;
        this.lblCantidadEntregada.StylePriority.UseTextAlignment = false;
        this.lblCantidadEntregada.Text = "Líneas del pedido/Cantidad Entregada";
        this.lblCantidadEntregada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblCantidadPedida
        // 
        this.lblCantidadPedida.AutoWidth = true;
        this.lblCantidadPedida.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblCantidadPedida.CanGrow = false;
        this.lblCantidadPedida.Dpi = 100F;
        this.lblCantidadPedida.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblCantidadPedida.LocationFloat = new DevExpress.Utils.PointFloat(1090F, 0F);
        this.lblCantidadPedida.Name = "lblCantidadPedida";
        this.lblCantidadPedida.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblCantidadPedida.SizeF = new System.Drawing.SizeF(80F, 50F);
        this.lblCantidadPedida.StylePriority.UseBorders = false;
        this.lblCantidadPedida.StylePriority.UseFont = false;
        this.lblCantidadPedida.StylePriority.UseTextAlignment = false;
        this.lblCantidadPedida.Text = "Líneas del pedido/Cantidad Pedida";
        this.lblCantidadPedida.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblDescripcion
        // 
        this.lblDescripcion.AutoWidth = true;
        this.lblDescripcion.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblDescripcion.CanGrow = false;
        this.lblDescripcion.Dpi = 100F;
        this.lblDescripcion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(940F, 0F);
        this.lblDescripcion.Name = "lblDescripcion";
        this.lblDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblDescripcion.SizeF = new System.Drawing.SizeF(150F, 50F);
        this.lblDescripcion.StylePriority.UseBorders = false;
        this.lblDescripcion.StylePriority.UseFont = false;
        this.lblDescripcion.StylePriority.UseTextAlignment = false;
        this.lblDescripcion.Text = "Líneas del pedido/Descripción";
        this.lblDescripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblProducto
        // 
        this.lblProducto.AutoWidth = true;
        this.lblProducto.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblProducto.CanGrow = false;
        this.lblProducto.Dpi = 100F;
        this.lblProducto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblProducto.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
        this.lblProducto.Name = "lblProducto";
        this.lblProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblProducto.SizeF = new System.Drawing.SizeF(80F, 50F);
        this.lblProducto.StylePriority.UseBorders = false;
        this.lblProducto.StylePriority.UseFont = false;
        this.lblProducto.StylePriority.UseTextAlignment = false;
        this.lblProducto.Text = "Líneas del pedido/Producto";
        this.lblProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblCuenta
        // 
        this.lblCuenta.AutoWidth = true;
        this.lblCuenta.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblCuenta.CanGrow = false;
        this.lblCuenta.Dpi = 100F;
        this.lblCuenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblCuenta.LocationFloat = new DevExpress.Utils.PointFloat(760F, 0F);
        this.lblCuenta.Name = "lblCuenta";
        this.lblCuenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblCuenta.SizeF = new System.Drawing.SizeF(100F, 50F);
        this.lblCuenta.StylePriority.UseBorders = false;
        this.lblCuenta.StylePriority.UseFont = false;
        this.lblCuenta.StylePriority.UseTextAlignment = false;
        this.lblCuenta.Text = "Referencia Cliente";
        this.lblCuenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblEquipo
        // 
        this.lblEquipo.AutoWidth = true;
        this.lblEquipo.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblEquipo.CanGrow = false;
        this.lblEquipo.Dpi = 100F;
        this.lblEquipo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblEquipo.LocationFloat = new DevExpress.Utils.PointFloat(660F, 0F);
        this.lblEquipo.Name = "lblEquipo";
        this.lblEquipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblEquipo.SizeF = new System.Drawing.SizeF(100F, 50F);
        this.lblEquipo.StylePriority.UseBorders = false;
        this.lblEquipo.StylePriority.UseFont = false;
        this.lblEquipo.StylePriority.UseTextAlignment = false;
        this.lblEquipo.Text = "Equipo De Ventas";
        this.lblEquipo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblListaPrecio
        // 
        this.lblListaPrecio.AutoWidth = true;
        this.lblListaPrecio.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblListaPrecio.CanGrow = false;
        this.lblListaPrecio.Dpi = 100F;
        this.lblListaPrecio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblListaPrecio.LocationFloat = new DevExpress.Utils.PointFloat(590F, 0F);
        this.lblListaPrecio.Name = "lblListaPrecio";
        this.lblListaPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblListaPrecio.SizeF = new System.Drawing.SizeF(70F, 50F);
        this.lblListaPrecio.StylePriority.UseBorders = false;
        this.lblListaPrecio.StylePriority.UseFont = false;
        this.lblListaPrecio.StylePriority.UseTextAlignment = false;
        this.lblListaPrecio.Text = "Tarifa / ID Externo";
        this.lblListaPrecio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblAlmacen
        // 
        this.lblAlmacen.AutoWidth = true;
        this.lblAlmacen.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblAlmacen.CanGrow = false;
        this.lblAlmacen.Dpi = 100F;
        this.lblAlmacen.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblAlmacen.LocationFloat = new DevExpress.Utils.PointFloat(520F, 0F);
        this.lblAlmacen.Name = "lblAlmacen";
        this.lblAlmacen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblAlmacen.SizeF = new System.Drawing.SizeF(70F, 50F);
        this.lblAlmacen.StylePriority.UseBorders = false;
        this.lblAlmacen.StylePriority.UseFont = false;
        this.lblAlmacen.StylePriority.UseTextAlignment = false;
        this.lblAlmacen.Text = "Almacén";
        this.lblAlmacen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblFecha
        // 
        this.lblFecha.AutoWidth = true;
        this.lblFecha.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblFecha.CanGrow = false;
        this.lblFecha.Dpi = 100F;
        this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblFecha.LocationFloat = new DevExpress.Utils.PointFloat(450F, 0F);
        this.lblFecha.Name = "lblFecha";
        this.lblFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblFecha.SizeF = new System.Drawing.SizeF(70F, 50F);
        this.lblFecha.StylePriority.UseBorders = false;
        this.lblFecha.StylePriority.UseFont = false;
        this.lblFecha.StylePriority.UseTextAlignment = false;
        this.lblFecha.Text = "Fecha De Pedido";
        this.lblFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblVendedor
        // 
        this.lblVendedor.AutoWidth = true;
        this.lblVendedor.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblVendedor.CanGrow = false;
        this.lblVendedor.Dpi = 100F;
        this.lblVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblVendedor.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
        this.lblVendedor.Name = "lblVendedor";
        this.lblVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblVendedor.SizeF = new System.Drawing.SizeF(300F, 50F);
        this.lblVendedor.StylePriority.UseBorders = false;
        this.lblVendedor.StylePriority.UseFont = false;
        this.lblVendedor.StylePriority.UseTextAlignment = false;
        this.lblVendedor.Text = "Salesman";
        this.lblVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblCliente
        // 
        this.lblCliente.AutoWidth = true;
        this.lblCliente.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblCliente.CanGrow = false;
        this.lblCliente.Dpi = 100F;
        this.lblCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblCliente.LocationFloat = new DevExpress.Utils.PointFloat(90F, 0F);
        this.lblCliente.Name = "lblCliente";
        this.lblCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblCliente.SizeF = new System.Drawing.SizeF(60F, 50F);
        this.lblCliente.StylePriority.UseBorders = false;
        this.lblCliente.StylePriority.UseFont = false;
        this.lblCliente.StylePriority.UseTextAlignment = false;
        this.lblCliente.Text = "Cliente";
        this.lblCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lblReferencia
        // 
        this.lblReferencia.AutoWidth = true;
        this.lblReferencia.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.lblReferencia.CanGrow = false;
        this.lblReferencia.Dpi = 100F;
        this.lblReferencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.lblReferencia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.lblReferencia.Name = "lblReferencia";
        this.lblReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lblReferencia.SizeF = new System.Drawing.SizeF(90F, 50F);
        this.lblReferencia.StylePriority.UseBorders = false;
        this.lblReferencia.StylePriority.UseFont = false;
        this.lblReferencia.StylePriority.UseTextAlignment = false;
        this.lblReferencia.Text = "Referencia Del Pedido";
        this.lblReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
        // parameterFechaInicio
        // 
        this.parameterFechaInicio.Description = "parameterFechaInicio";
        this.parameterFechaInicio.Name = "parameterFechaInicio";
        this.parameterFechaInicio.ValueInfo = "2020-05-16";
        this.parameterFechaInicio.Visible = false;
        // 
        // parameterFechaFin
        // 
        this.parameterFechaFin.Description = "parameterFechaFin";
        this.parameterFechaFin.Name = "parameterFechaFin";
        this.parameterFechaFin.ValueInfo = "2020-05-18";
        this.parameterFechaFin.Visible = false;
        // 
        // calculatedCantidad
        // 
        this.calculatedCantidad.DataMember = "stpr_Reporte262Ventas";
        this.calculatedCantidad.Expression = "Iif(EndsWith(ToStr([Referencia]), \'D\'), [][[^.Vendedor] == [Vendedor] && [^.Produ" +
"ctoClave] == [ProductoClave] && EndsWith(ToStr([Referencia]), \'D\')].Sum([Cantida" +
"d]) , [Cantidad])";
        this.calculatedCantidad.Name = "calculatedCantidad";
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
        // GroupHeader1
        // 
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Vendedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.GroupHeader1.HeightF = 0F;
        this.GroupHeader1.Name = "GroupHeader1";
        this.GroupHeader1.Visible = false;
        // 
        // R262Ventas
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calculatedCantidad});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
        this.DataMember = "stpr_Reporte262Ventas";
        this.DataSource = this.sqlDataSource1;
        this.Font = new System.Drawing.Font("Times New Roman", 9F);
        this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.OcultarCantidadesDevoluciones,
            this.MostrarCantidadesDevoluciones});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
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
        this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.R262Ventas_DataSourceDemanded);
        this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.R262Ventas_BeforePrint);
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void R262Ventas_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (((DevExpress.DataAccess.Native.Sql.ResultSet)((DevExpress.DataAccess.Sql.SqlDataSource)DataSource).Result).Tables.ToList()[0].Count == 0)
        {
            e.Cancel = true;
            throw new Exception("No tiene datos");
        }
    }

    public XtraReport GetReport(string Cedis, string TipoFecha, string FechaInicial, string FechaFinal, string Rutas, string Vendedores)
    {
        this.Cedis = Cedis;
        this.FechaInicial = DateTime.Parse(FechaInicial);
        if (TipoFecha.Equals("Igual"))
            this.FechaFinal = DateTime.Parse(FechaInicial);
        else
            this.FechaFinal = DateTime.Parse(FechaFinal);
        this.Rutas = Rutas;
        this.Vendedores = Vendedores;
        Name = string.Format("Ventas{0:yyyy'-'MM'-'dd'T'HH':'mm':'ss}.xlsx", DateTime.Now);

        InitializeComponent();
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

    private void R262Ventas_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterCedis"].Value = this.Cedis;
        this.Parameters["parameterRutas"].Value = this.Rutas;
        this.Parameters["parameterVendedores"].Value = this.Vendedores;
        this.Parameters["parameterFechaInicio"].Value = this.FechaInicial.Date.ToString("s");
        this.Parameters["parameterFechaFin"].Value = this.FechaFinal.Date.ToString("s");
    }

}
