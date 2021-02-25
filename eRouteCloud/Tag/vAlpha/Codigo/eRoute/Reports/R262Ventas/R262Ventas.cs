using System;
using System.Drawing;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using Dapper;
using System.Linq;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class R262Ventas: DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel lblDAlmacen;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel lblDCuenta;
    private XRLabel lblDEquipo;
    private XRLabel lblDListaPrecio;
    private XRLabel lblDFecha;
    private XRLabel lblDVendedor;
    private XRLabel lblDCliente;
    private XRLabel lblDReferencia;
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
    private DevExpress.XtraReports.Parameters.Parameter parameterCEDIS;
    private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

    private string Cedis;
    private DateTime FechaInicial;
    private DateTime FechaFinal;
    private string Rutas;
    private string Vendedores;
    private string QueryString;

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
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
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
            this.Detail.HeightF = 16.62499F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.AutoWidth = true;
            this.xrLabel15.CanGrow = false;
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Zona")});
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(962.5F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(124.5F, 16.62499F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.AutoWidth = true;
            this.xrLabel14.CanGrow = false;
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Ruta")});
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(900F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(62.5F, 16.62499F);
            // 
            // xrLabel13
            // 
            this.xrLabel13.AutoWidth = true;
            this.xrLabel13.CanGrow = false;
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Precio")});
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(850F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(50F, 16.62499F);
            // 
            // xrLabel12
            // 
            this.xrLabel12.AutoWidth = true;
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Cantidad")});
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(800F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(50F, 16.62499F);
            // 
            // xrLabel11
            // 
            this.xrLabel11.AutoWidth = true;
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Cantidad")});
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(50F, 16.62499F);
            // 
            // xrLabel10
            // 
            this.xrLabel10.AutoWidth = true;
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Folio")});
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 16.62499F);
            // 
            // xrLabel9
            // 
            this.xrLabel9.AutoWidth = true;
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.ProductoClave")});
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(50F, 16.62499F);
            // 
            // lblDReferencia
            // 
            this.lblDReferencia.AutoWidth = true;
            this.lblDReferencia.CanGrow = false;
            this.lblDReferencia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Referencia")});
            this.lblDReferencia.Dpi = 100F;
            this.lblDReferencia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblDReferencia.Name = "lblDReferencia";
            this.lblDReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDReferencia.SizeF = new System.Drawing.SizeF(99.49997F, 16.62499F);
            this.lblDReferencia.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
            // 
            // lblDEquipo
            // 
            this.lblDEquipo.AutoWidth = true;
            this.lblDEquipo.CanGrow = false;
            this.lblDEquipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Zona")});
            this.lblDEquipo.Dpi = 100F;
            this.lblDEquipo.LocationFloat = new DevExpress.Utils.PointFloat(450F, 0F);
            this.lblDEquipo.Name = "lblDEquipo";
            this.lblDEquipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDEquipo.SizeF = new System.Drawing.SizeF(99.5F, 16.62499F);
            this.lblDEquipo.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
            // 
            // lblDListaPrecio
            // 
            this.lblDListaPrecio.AutoWidth = true;
            this.lblDListaPrecio.CanGrow = false;
            this.lblDListaPrecio.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.PrecioClave")});
            this.lblDListaPrecio.Dpi = 100F;
            this.lblDListaPrecio.LocationFloat = new DevExpress.Utils.PointFloat(375F, 0F);
            this.lblDListaPrecio.Name = "lblDListaPrecio";
            this.lblDListaPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDListaPrecio.SizeF = new System.Drawing.SizeF(75F, 16.62499F);
            this.lblDListaPrecio.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
            // 
            // lblDAlmacen
            // 
            this.lblDAlmacen.AutoWidth = true;
            this.lblDAlmacen.CanGrow = false;
            this.lblDAlmacen.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Almacen")});
            this.lblDAlmacen.Dpi = 100F;
            this.lblDAlmacen.LocationFloat = new DevExpress.Utils.PointFloat(300F, 0F);
            this.lblDAlmacen.Name = "lblDAlmacen";
            this.lblDAlmacen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDAlmacen.SizeF = new System.Drawing.SizeF(75F, 16.62499F);
            this.lblDAlmacen.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
            // 
            // lblDFecha
            // 
            this.lblDFecha.AutoWidth = true;
            this.lblDFecha.CanGrow = false;
            this.lblDFecha.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.FechaCaptura", "{0:dd/MM/yyyy}")});
            this.lblDFecha.Dpi = 100F;
            this.lblDFecha.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.lblDFecha.Name = "lblDFecha";
            this.lblDFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDFecha.SizeF = new System.Drawing.SizeF(50F, 16.62499F);
            this.lblDFecha.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
            // 
            // lblDVendedor
            // 
            this.lblDVendedor.AutoWidth = true;
            this.lblDVendedor.CanGrow = false;
            this.lblDVendedor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Vendedor")});
            this.lblDVendedor.Dpi = 100F;
            this.lblDVendedor.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lblDVendedor.Name = "lblDVendedor";
            this.lblDVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDVendedor.SizeF = new System.Drawing.SizeF(100F, 16.62499F);
            this.lblDVendedor.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
            // 
            // lblDCliente
            // 
            this.lblDCliente.AutoWidth = true;
            this.lblDCliente.CanGrow = false;
            this.lblDCliente.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.Cliente")});
            this.lblDCliente.Dpi = 100F;
            this.lblDCliente.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.lblDCliente.Name = "lblDCliente";
            this.lblDCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDCliente.SizeF = new System.Drawing.SizeF(50F, 16.62499F);
            this.lblDCliente.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
            // 
            // lblDCuenta
            // 
            this.lblDCuenta.AutoWidth = true;
            this.lblDCuenta.CanGrow = false;
            this.lblDCuenta.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_Reporte262Ventas.CuentaAnalitica")});
            this.lblDCuenta.Dpi = 100F;
            this.lblDCuenta.LocationFloat = new DevExpress.Utils.PointFloat(550F, 0F);
            this.lblDCuenta.Name = "lblDCuenta";
            this.lblDCuenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDCuenta.SizeF = new System.Drawing.SizeF(50F, 16.62499F);
            this.lblDCuenta.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblDetalle_BeforePrint);
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
            this.BottomMargin.HeightF = 49.08336F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
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
            this.ReportHeader.HeightF = 16.125F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoWidth = true;
            this.lblEtiqueta.CanGrow = false;
            this.lblEtiqueta.Dpi = 100F;
            this.lblEtiqueta.LocationFloat = new DevExpress.Utils.PointFloat(962.5F, 0F);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEtiqueta.SizeF = new System.Drawing.SizeF(124.5F, 16.125F);
            this.lblEtiqueta.Text = "Líneas del pedido/Etiquetas analíticas";
            // 
            // lblRuta
            // 
            this.lblRuta.AutoWidth = true;
            this.lblRuta.CanGrow = false;
            this.lblRuta.Dpi = 100F;
            this.lblRuta.LocationFloat = new DevExpress.Utils.PointFloat(900F, 0F);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblRuta.SizeF = new System.Drawing.SizeF(62.5F, 16.125F);
            this.lblRuta.Text = "Líneas del pedido/Ruta";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoWidth = true;
            this.lblPrecio.CanGrow = false;
            this.lblPrecio.Dpi = 100F;
            this.lblPrecio.LocationFloat = new DevExpress.Utils.PointFloat(850F, 0F);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrecio.SizeF = new System.Drawing.SizeF(50F, 16.125F);
            this.lblPrecio.Text = "Líneas del pedido/Precio unitario";
            // 
            // lblCantidadEntregada
            // 
            this.lblCantidadEntregada.AutoWidth = true;
            this.lblCantidadEntregada.CanGrow = false;
            this.lblCantidadEntregada.Dpi = 100F;
            this.lblCantidadEntregada.LocationFloat = new DevExpress.Utils.PointFloat(800F, 0F);
            this.lblCantidadEntregada.Name = "lblCantidadEntregada";
            this.lblCantidadEntregada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCantidadEntregada.SizeF = new System.Drawing.SizeF(50F, 16.125F);
            this.lblCantidadEntregada.Text = "Líneas del pedido/Cantidad Entregada";
            // 
            // lblCantidadPedida
            // 
            this.lblCantidadPedida.AutoWidth = true;
            this.lblCantidadPedida.CanGrow = false;
            this.lblCantidadPedida.Dpi = 100F;
            this.lblCantidadPedida.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.lblCantidadPedida.Name = "lblCantidadPedida";
            this.lblCantidadPedida.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCantidadPedida.SizeF = new System.Drawing.SizeF(50F, 16.125F);
            this.lblCantidadPedida.Text = "Líneas del pedido/Cantidad Pedida";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoWidth = true;
            this.lblDescripcion.CanGrow = false;
            this.lblDescripcion.Dpi = 100F;
            this.lblDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(649.5F, 0F);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDescripcion.SizeF = new System.Drawing.SizeF(100.5F, 16.125F);
            this.lblDescripcion.Text = "Líneas del pedido/Descripción";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoWidth = true;
            this.lblProducto.CanGrow = false;
            this.lblProducto.Dpi = 100F;
            this.lblProducto.LocationFloat = new DevExpress.Utils.PointFloat(599.5F, 0F);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblProducto.SizeF = new System.Drawing.SizeF(50F, 16.125F);
            this.lblProducto.Text = "Líneas del pedido/Producto";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoWidth = true;
            this.lblCuenta.CanGrow = false;
            this.lblCuenta.Dpi = 100F;
            this.lblCuenta.LocationFloat = new DevExpress.Utils.PointFloat(549.5F, 0F);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCuenta.SizeF = new System.Drawing.SizeF(50F, 16.125F);
            this.lblCuenta.Text = "Cuenta analítica";
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoWidth = true;
            this.lblEquipo.CanGrow = false;
            this.lblEquipo.Dpi = 100F;
            this.lblEquipo.LocationFloat = new DevExpress.Utils.PointFloat(450F, 0F);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEquipo.SizeF = new System.Drawing.SizeF(99.50003F, 16.125F);
            this.lblEquipo.Text = "Equipo de ventas";
            // 
            // lblListaPrecio
            // 
            this.lblListaPrecio.AutoWidth = true;
            this.lblListaPrecio.CanGrow = false;
            this.lblListaPrecio.Dpi = 100F;
            this.lblListaPrecio.LocationFloat = new DevExpress.Utils.PointFloat(375.5F, 0F);
            this.lblListaPrecio.Name = "lblListaPrecio";
            this.lblListaPrecio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblListaPrecio.SizeF = new System.Drawing.SizeF(74.5F, 16.125F);
            this.lblListaPrecio.Text = "Lista de precio";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoWidth = true;
            this.lblAlmacen.CanGrow = false;
            this.lblAlmacen.Dpi = 100F;
            this.lblAlmacen.LocationFloat = new DevExpress.Utils.PointFloat(300.5F, 0F);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAlmacen.SizeF = new System.Drawing.SizeF(74.5F, 16.125F);
            this.lblAlmacen.Text = "Almacén";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoWidth = true;
            this.lblFecha.CanGrow = false;
            this.lblFecha.Dpi = 100F;
            this.lblFecha.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFecha.SizeF = new System.Drawing.SizeF(50F, 16.125F);
            this.lblFecha.Text = "Fecha de pedido";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoWidth = true;
            this.lblVendedor.CanGrow = false;
            this.lblVendedor.Dpi = 100F;
            this.lblVendedor.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblVendedor.SizeF = new System.Drawing.SizeF(99.99997F, 16.125F);
            this.lblVendedor.Text = "Vendedor";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoWidth = true;
            this.lblCliente.CanGrow = false;
            this.lblCliente.Dpi = 100F;
            this.lblCliente.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCliente.SizeF = new System.Drawing.SizeF(50F, 16.125F);
            this.lblCliente.Text = "Cliente";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoWidth = true;
            this.lblReferencia.CanGrow = false;
            this.lblReferencia.Dpi = 100F;
            this.lblReferencia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReferencia.SizeF = new System.Drawing.SizeF(99.49997F, 16.125F);
            this.lblReferencia.Text = "Referencia del pedido";
            // 
            // parameterCedis
            // 
            this.parameterCedis.Description = "Parameter1";
            this.parameterCedis.Name = "parameterCedis";
            this.parameterCedis.Visible = false;
            // 
            // parameterRutas
            // 
            this.parameterRutas.Description = "parameterRutas";
            this.parameterRutas.Name = "parameterRutas";
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
            this.parameterFechaInicio.Visible = false;
            // 
            // parameterFechaFin
            // 
            this.parameterFechaFin.Description = "parameterFechaFin";
            this.parameterFechaFin.Name = "parameterFechaFin";
            this.parameterFechaFin.Visible = false;
            // 
            // R262Ventas
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "stpr_Reporte262Ventas";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 0, 0, 49);
            this.PageHeight = 850;
            this.PageWidth = 1100;
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

    bool tieneDatos = false;

    private void R262Ventas_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (((DevExpress.DataAccess.Native.Sql.ResultTable)((DevExpress.DataAccess.Native.Sql.ResultSet)((DevExpress.DataAccess.Sql.SqlDataSource)this.DataSource).Result).Tables.ToList()[0]).Count == 0)
        {
            e.Cancel = true;       
            throw new Exception("No tiene datos");
        }
    }

    #endregion

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
        this.Name = "Ventas" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + ".xlsx";

        //CountRows();
        InitializeComponent();
        return this;
    }

    //private int CountRows()
    //{
    //    StringBuilder sConsulta = new StringBuilder();
    //    sConsulta.AppendLine("EXEC [dbo].[stpr_Reporte262Ventas] ");
    //    sConsulta.AppendLine("@filtroCEDIS = '" + this.Cedis + "', ");
    //    sConsulta.AppendLine("@filtroRutas = '" + this.Rutas + "', ");
    //    sConsulta.AppendLine("@filtroVendedores = '" + this.Vendedores + "', ");
    //    sConsulta.AppendLine("@filtroFechaInicio = '" + this.FechaInicial.Date.ToString("yyyy-MM-dd") + "', ");
    //    sConsulta.AppendLine("@filtroFechaFin = '" + this.FechaFinal.Date.ToString("yyyy-MM-dd") + "'");
    //    QueryString = sConsulta.ToString();
    //    List<ObjectModel> objectData = Connection.Query<ObjectModel>(QueryString, null, null, true, 9000).ToList();
    //    return objectData.Count;
    //}

    private class ObjectModel
    {
        public string Referencia { get; set; }
    }

    private void lblDetalle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (((DevExpress.DataAccess.Native.Sql.ResultRow)GetCurrentRow()).Index > 0)
        {
            if (!GetCurrentColumnValue("Referencia").ToString().Equals(GetPreviousColumnValue("Referencia").ToString()))
                ((XRLabel)sender).Visible = true;
            else
                ((XRLabel)sender).Visible = false;
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
