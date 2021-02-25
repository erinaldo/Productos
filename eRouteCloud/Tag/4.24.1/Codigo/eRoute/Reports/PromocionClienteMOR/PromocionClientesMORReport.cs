using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class PromocionClientesMORReport : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel20;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    public XRLabel ReporteAgencia;
    public XRLabel ReporteRuta;
    public XRLabel ReportePeriodo;
    public XRLabel ReportePromociones;
    public GroupHeaderBand GHeaderRuta;
    public GroupHeaderBand GHeaderAgencia;
    private XRLabel xrLabel19;
    public XRLabel labelRuta;
    private XRLabel xrLabel18;
    public XRLabel CediLabel;
    public XRLabel detalleClaveCliente;
    public XRLabel detalleNombreCliente;
    public XRLabel detalleClavePromocion;
    public XRLabel detalleClaveProducto;
    public XRLabel detalleNombreProducto;
    public XRLabel detalleCantidad;
    public XRLabel detallePrecioPromocion;
    public XRLabel detallePrecioDeListas;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel13;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel5;
    public XRLabel detalleNombrePromocion;
    private XRLine xrLine3;
    private XRPageInfo xrPageInfo3;
    private XRPageInfo xrPageInfo4;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PromocionClientesMORReport()
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
            this.detalleClaveCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleNombreCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleClavePromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleNombrePromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleClaveProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleNombreProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.detallePrecioPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.detallePrecioDeListas = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReporteAgencia = new DevExpress.XtraReports.UI.XRLabel();
            this.ReporteRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportePeriodo = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportePromociones = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GHeaderRuta = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.GHeaderAgencia = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.CediLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.detalleClaveCliente,
            this.detalleNombreCliente,
            this.detalleClavePromocion,
            this.detalleNombrePromocion,
            this.detalleClaveProducto,
            this.detalleNombreProducto,
            this.detalleCantidad,
            this.detallePrecioPromocion,
            this.detallePrecioDeListas});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 26.41668F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // detalleClaveCliente
            // 
            this.detalleClaveCliente.Dpi = 100F;
            this.detalleClaveCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleClaveCliente.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.5000114F);
            this.detalleClaveCliente.Name = "detalleClaveCliente";
            this.detalleClaveCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleClaveCliente.SizeF = new System.Drawing.SizeF(79.16835F, 18F);
            this.detalleClaveCliente.StylePriority.UseFont = false;
            this.detalleClaveCliente.StylePriority.UseTextAlignment = false;
            this.detalleClaveCliente.Text = "Clave del Cliente";
            this.detalleClaveCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // detalleNombreCliente
            // 
            this.detalleNombreCliente.CanGrow = false;
            this.detalleNombreCliente.Dpi = 100F;
            this.detalleNombreCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleNombreCliente.LocationFloat = new DevExpress.Utils.PointFloat(79.16835F, 0.5000114F);
            this.detalleNombreCliente.Name = "detalleNombreCliente";
            this.detalleNombreCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleNombreCliente.SizeF = new System.Drawing.SizeF(153.2483F, 18F);
            this.detalleNombreCliente.StylePriority.UseFont = false;
            this.detalleNombreCliente.StylePriority.UseTextAlignment = false;
            this.detalleNombreCliente.Text = "Nombre Cliente";
            this.detalleNombreCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detalleClavePromocion
            // 
            this.detalleClavePromocion.Dpi = 100F;
            this.detalleClavePromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleClavePromocion.LocationFloat = new DevExpress.Utils.PointFloat(232.875F, 0.5000114F);
            this.detalleClavePromocion.Multiline = true;
            this.detalleClavePromocion.Name = "detalleClavePromocion";
            this.detalleClavePromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleClavePromocion.SizeF = new System.Drawing.SizeF(87.79327F, 18F);
            this.detalleClavePromocion.StylePriority.UseFont = false;
            this.detalleClavePromocion.StylePriority.UseTextAlignment = false;
            this.detalleClavePromocion.Text = "Clave Promoción";
            this.detalleClavePromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detalleNombrePromocion
            // 
            this.detalleNombrePromocion.CanGrow = false;
            this.detalleNombrePromocion.Dpi = 100F;
            this.detalleNombrePromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleNombrePromocion.LocationFloat = new DevExpress.Utils.PointFloat(320.6682F, 0F);
            this.detalleNombrePromocion.Name = "detalleNombrePromocion";
            this.detalleNombrePromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleNombrePromocion.SizeF = new System.Drawing.SizeF(128.8512F, 18F);
            this.detalleNombrePromocion.StylePriority.UseFont = false;
            this.detalleNombrePromocion.StylePriority.UseTextAlignment = false;
            this.detalleNombrePromocion.Text = "Nombre Promocion";
            this.detalleNombrePromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detalleClaveProducto
            // 
            this.detalleClaveProducto.Dpi = 100F;
            this.detalleClaveProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleClaveProducto.LocationFloat = new DevExpress.Utils.PointFloat(449.9778F, 0F);
            this.detalleClaveProducto.Multiline = true;
            this.detalleClaveProducto.Name = "detalleClaveProducto";
            this.detalleClaveProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleClaveProducto.SizeF = new System.Drawing.SizeF(60.48517F, 18F);
            this.detalleClaveProducto.StylePriority.UseFont = false;
            this.detalleClaveProducto.StylePriority.UseTextAlignment = false;
            this.detalleClaveProducto.Text = "Clave Producto";
            this.detalleClaveProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detalleNombreProducto
            // 
            this.detalleNombreProducto.CanGrow = false;
            this.detalleNombreProducto.Dpi = 100F;
            this.detalleNombreProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleNombreProducto.LocationFloat = new DevExpress.Utils.PointFloat(510.4629F, 0F);
            this.detalleNombreProducto.Name = "detalleNombreProducto";
            this.detalleNombreProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleNombreProducto.SizeF = new System.Drawing.SizeF(124.9974F, 18F);
            this.detalleNombreProducto.StylePriority.UseFont = false;
            this.detalleNombreProducto.StylePriority.UseTextAlignment = false;
            this.detalleNombreProducto.Text = "Nombre Producto";
            this.detalleNombreProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // detalleCantidad
            // 
            this.detalleCantidad.Dpi = 100F;
            this.detalleCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleCantidad.LocationFloat = new DevExpress.Utils.PointFloat(636.8352F, 0F);
            this.detalleCantidad.Multiline = true;
            this.detalleCantidad.Name = "detalleCantidad";
            this.detalleCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleCantidad.SizeF = new System.Drawing.SizeF(54.00006F, 18F);
            this.detalleCantidad.StylePriority.UseFont = false;
            this.detalleCantidad.StylePriority.UseTextAlignment = false;
            this.detalleCantidad.Text = "Cantidad";
            this.detalleCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // detallePrecioPromocion
            // 
            this.detallePrecioPromocion.Dpi = 100F;
            this.detallePrecioPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detallePrecioPromocion.LocationFloat = new DevExpress.Utils.PointFloat(690.8353F, 0F);
            this.detallePrecioPromocion.Multiline = true;
            this.detallePrecioPromocion.Name = "detallePrecioPromocion";
            this.detallePrecioPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detallePrecioPromocion.SizeF = new System.Drawing.SizeF(69.78992F, 18F);
            this.detallePrecioPromocion.StylePriority.UseFont = false;
            this.detallePrecioPromocion.StylePriority.UseTextAlignment = false;
            this.detallePrecioPromocion.Text = "Precio Promoción";
            this.detallePrecioPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detallePrecioDeListas
            // 
            this.detallePrecioDeListas.Dpi = 100F;
            this.detallePrecioDeListas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detallePrecioDeListas.LocationFloat = new DevExpress.Utils.PointFloat(762.7517F, 0.5000114F);
            this.detallePrecioDeListas.Multiline = true;
            this.detallePrecioDeListas.Name = "detallePrecioDeListas";
            this.detallePrecioDeListas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detallePrecioDeListas.SizeF = new System.Drawing.SizeF(69.78998F, 18F);
            this.detallePrecioDeListas.StylePriority.UseFont = false;
            this.detallePrecioDeListas.StylePriority.UseTextAlignment = false;
            this.detallePrecioDeListas.Text = "Precio de Listas";
            this.detallePrecioDeListas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.xrLabel20,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.ReporteAgencia,
            this.ReporteRuta,
            this.ReportePeriodo,
            this.ReportePromociones});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 180.4167F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(136.812F, 122.7084F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(56.24997F, 15.70832F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Agencia:";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(136.812F, 138.4167F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(37.49498F, 14F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Ruta:";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(136.812F, 152.4167F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(56.70323F, 14F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Periodo:";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(138.1038F, 166.4167F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(82.08322F, 14F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Promociones:";
            // 
            // ReporteAgencia
            // 
            this.ReporteAgencia.Dpi = 100F;
            this.ReporteAgencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteAgencia.LocationFloat = new DevExpress.Utils.PointFloat(205.6248F, 122.7084F);
            this.ReporteAgencia.Name = "ReporteAgencia";
            this.ReporteAgencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReporteAgencia.SizeF = new System.Drawing.SizeF(316.3732F, 15.70832F);
            this.ReporteAgencia.StylePriority.UseFont = false;
            // 
            // ReporteRuta
            // 
            this.ReporteRuta.Dpi = 100F;
            this.ReporteRuta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporteRuta.LocationFloat = new DevExpress.Utils.PointFloat(205.6248F, 138.4167F);
            this.ReporteRuta.Name = "ReporteRuta";
            this.ReporteRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReporteRuta.SizeF = new System.Drawing.SizeF(591.9169F, 14F);
            this.ReporteRuta.StylePriority.UseFont = false;
            // 
            // ReportePeriodo
            // 
            this.ReportePeriodo.Dpi = 100F;
            this.ReportePeriodo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportePeriodo.LocationFloat = new DevExpress.Utils.PointFloat(206.0831F, 152.4167F);
            this.ReportePeriodo.Name = "ReportePeriodo";
            this.ReportePeriodo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReportePeriodo.SizeF = new System.Drawing.SizeF(219.6233F, 14F);
            this.ReportePeriodo.StylePriority.UseFont = false;
            // 
            // ReportePromociones
            // 
            this.ReportePromociones.Dpi = 100F;
            this.ReportePromociones.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportePromociones.LocationFloat = new DevExpress.Utils.PointFloat(220.187F, 166.4167F);
            this.ReportePromociones.Name = "ReportePromociones";
            this.ReportePromociones.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReportePromociones.SizeF = new System.Drawing.SizeF(315.9149F, 14F);
            this.ReportePromociones.StylePriority.UseFont = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine3,
            this.xrPageInfo3,
            this.xrPageInfo4});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 72.16666F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(831.9166F, 10.5F);
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo3.Format = "{0} / {1}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(347.6344F, 20.49999F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(101.885F, 23F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.StylePriority.UseTextAlignment = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Dpi = 100F;
            this.xrPageInfo4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo4.Format = "Fecha Hora Impresión: {0}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(528.7501F, 20.49999F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(294.25F, 23F);
            this.xrPageInfo4.StylePriority.UseFont = false;
            this.xrPageInfo4.StylePriority.UseTextAlignment = false;
            this.xrPageInfo4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GHeaderRuta
            // 
            this.GHeaderRuta.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.labelRuta});
            this.GHeaderRuta.Dpi = 100F;
            this.GHeaderRuta.HeightF = 17.08333F;
            this.GHeaderRuta.Name = "GHeaderRuta";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel19.Multiline = true;
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(63.12167F, 17.08333F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Ruta: ";
            // 
            // labelRuta
            // 
            this.labelRuta.Dpi = 100F;
            this.labelRuta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRuta.LocationFloat = new DevExpress.Utils.PointFloat(63.12167F, 0F);
            this.labelRuta.Multiline = true;
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelRuta.SizeF = new System.Drawing.SizeF(125.7708F, 17.08333F);
            this.labelRuta.StylePriority.UseFont = false;
            // 
            // GHeaderAgencia
            // 
            this.GHeaderAgencia.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.CediLabel});
            this.GHeaderAgencia.Dpi = 100F;
            this.GHeaderAgencia.HeightF = 17.70833F;
            this.GHeaderAgencia.Level = 1;
            this.GHeaderAgencia.Name = "GHeaderAgencia";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(1.208623F, 0F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(61.45478F, 16.04167F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "Agencia:";
            // 
            // CediLabel
            // 
            this.CediLabel.Dpi = 100F;
            this.CediLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CediLabel.LocationFloat = new DevExpress.Utils.PointFloat(62.66339F, 0F);
            this.CediLabel.Name = "CediLabel";
            this.CediLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CediLabel.SizeF = new System.Drawing.SizeF(367.9981F, 16.04167F);
            this.CediLabel.StylePriority.UseFont = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.xrLine2,
            this.xrLine1,
            this.xrLabel14,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel13,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel5});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 51.04167F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(763.21F, 11F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(69.79F, 28F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Precio de Listas";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(691.2936F, 10.49999F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(69.79F, 28F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Precio Promoción";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(1.083374F, 39.00001F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(831.9166F, 10.5F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(831.4583F, 10.5F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 11F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(79.16834F, 28F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Clave del Cliente";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(79.16834F, 11F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(154.165F, 28F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Nombre Cliente";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(233.3333F, 11F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(87.7933F, 28F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Clave Promoción";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(510.4629F, 10.49999F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(125.9139F, 28F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Nombre Producto";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(637.2936F, 10.49999F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(54F, 28F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Cantidad";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(450.4361F, 10.49999F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(60.02682F, 28F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Clave Producto";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(321.1266F, 10.49999F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(129.3095F, 28F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Nombre Promoción";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(56.37501F, 5.000003F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(232.875F, 69.99998F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(232.875F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PromocionClientesMORReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GHeaderRuta,
            this.GHeaderAgencia,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(14, 3, 180, 72);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
