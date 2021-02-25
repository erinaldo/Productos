using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class ProductoPorPrecioKg : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private ReportHeaderBand ReportHeader;
    public GroupHeaderBand GroupHeader1;
    public XRLabel labelCediTotal;
    public XRLabel labelClave;
    public XRLabel labelProducto;
    public XRLabel labelUnidad;
    public XRLabel labelCantidad;
    public XRLabel labelKgLts;
    public XRLabel labelTotal;
    private XRLabel xrLabel27;
    public XRLabel labelPrecioCantidad;
    public XRLabel labelPrecioKgLts;
    public XRLabel labelPrecioTotal;
    public XRLabel labelPrecioU;
    public XRLabel labelSubtotal;
    public XRLabel labelDescProducto;
    public XRLabel labelDescCliente;
    public XRLabel labelDescVendedor;
    public XRLabel labelIVA;
    public XRLabel labelIEPS;
    public XRLabel labelPrecioSubtotal;
    public XRLabel labelPrecioDescProducto;
    public XRLabel labelPrecioDescCliente;
    public XRLabel labelPrecioDescVendedor;
    public XRLabel labelPrecioIVA;
    public XRLabel labelPrecioIEPS;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ProductoPorPrecioKg()
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
            this.labelClave = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioU = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.labelIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioDescProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioDescCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioDescVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.labelCediTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelClave,
            this.labelProducto,
            this.labelUnidad,
            this.labelPrecioU,
            this.labelCantidad,
            this.labelKgLts,
            this.labelSubtotal,
            this.labelDescProducto,
            this.labelDescCliente,
            this.labelDescVendedor,
            this.labelIVA,
            this.labelIEPS,
            this.labelTotal});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 24.45865F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelClave
            // 
            this.labelClave.Dpi = 100F;
            this.labelClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.LocationFloat = new DevExpress.Utils.PointFloat(0.25F, 0F);
            this.labelClave.Multiline = true;
            this.labelClave.Name = "labelClave";
            this.labelClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClave.SizeF = new System.Drawing.SizeF(76.45836F, 24.45865F);
            this.labelClave.StylePriority.UseFont = false;
            this.labelClave.StylePriority.UseTextAlignment = false;
            this.labelClave.Text = "Clave";
            this.labelClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelProducto
            // 
            this.labelProducto.Dpi = 100F;
            this.labelProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducto.LocationFloat = new DevExpress.Utils.PointFloat(77.20834F, 0F);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto.SizeF = new System.Drawing.SizeF(125.3173F, 24.45865F);
            this.labelProducto.StylePriority.UseFont = false;
            this.labelProducto.StylePriority.UseTextAlignment = false;
            this.labelProducto.Text = "Producto";
            this.labelProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelUnidad
            // 
            this.labelUnidad.Dpi = 100F;
            this.labelUnidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnidad.LocationFloat = new DevExpress.Utils.PointFloat(203.0256F, 0.001811981F);
            this.labelUnidad.Name = "labelUnidad";
            this.labelUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelUnidad.SizeF = new System.Drawing.SizeF(78.08336F, 24.45684F);
            this.labelUnidad.StylePriority.UseFont = false;
            this.labelUnidad.StylePriority.UseTextAlignment = false;
            this.labelUnidad.Text = "Unidad";
            this.labelUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelPrecioU
            // 
            this.labelPrecioU.Dpi = 100F;
            this.labelPrecioU.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioU.LocationFloat = new DevExpress.Utils.PointFloat(281.1089F, 0.0004132589F);
            this.labelPrecioU.Multiline = true;
            this.labelPrecioU.Name = "labelPrecioU";
            this.labelPrecioU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioU.SizeF = new System.Drawing.SizeF(84.75256F, 24.45823F);
            this.labelPrecioU.StylePriority.UseFont = false;
            this.labelPrecioU.StylePriority.UseTextAlignment = false;
            this.labelPrecioU.Text = "PrecioU";
            this.labelPrecioU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCantidad
            // 
            this.labelCantidad.Dpi = 100F;
            this.labelCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidad.LocationFloat = new DevExpress.Utils.PointFloat(366.3615F, 0.001811981F);
            this.labelCantidad.Multiline = true;
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelCantidad.StylePriority.UseFont = false;
            this.labelCantidad.StylePriority.UseTextAlignment = false;
            this.labelCantidad.Text = "Cantidad";
            this.labelCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelKgLts
            // 
            this.labelKgLts.Dpi = 100F;
            this.labelKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKgLts.LocationFloat = new DevExpress.Utils.PointFloat(455.6259F, 0.0009218852F);
            this.labelKgLts.Multiline = true;
            this.labelKgLts.Name = "labelKgLts";
            this.labelKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelKgLts.StylePriority.UseFont = false;
            this.labelKgLts.StylePriority.UseTextAlignment = false;
            this.labelKgLts.Text = "Kilo/Litros";
            this.labelKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.Dpi = 100F;
            this.labelSubtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(530.824F, 0F);
            this.labelSubtotal.Multiline = true;
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubtotal.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelSubtotal.StylePriority.UseFont = false;
            this.labelSubtotal.StylePriority.UseTextAlignment = false;
            this.labelSubtotal.Text = "Subtotal";
            this.labelSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelDescProducto
            // 
            this.labelDescProducto.Dpi = 100F;
            this.labelDescProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescProducto.LocationFloat = new DevExpress.Utils.PointFloat(614.3552F, 0F);
            this.labelDescProducto.Multiline = true;
            this.labelDescProducto.Name = "labelDescProducto";
            this.labelDescProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescProducto.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelDescProducto.StylePriority.UseFont = false;
            this.labelDescProducto.StylePriority.UseTextAlignment = false;
            this.labelDescProducto.Text = "Desc. Producto";
            this.labelDescProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelDescCliente
            // 
            this.labelDescCliente.Dpi = 100F;
            this.labelDescCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescCliente.LocationFloat = new DevExpress.Utils.PointFloat(697.8864F, 0.0009218852F);
            this.labelDescCliente.Multiline = true;
            this.labelDescCliente.Name = "labelDescCliente";
            this.labelDescCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescCliente.SizeF = new System.Drawing.SizeF(71.03119F, 24.45773F);
            this.labelDescCliente.StylePriority.UseFont = false;
            this.labelDescCliente.StylePriority.UseTextAlignment = false;
            this.labelDescCliente.Text = "Desc. Cliente";
            this.labelDescCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelDescVendedor
            // 
            this.labelDescVendedor.Dpi = 100F;
            this.labelDescVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescVendedor.LocationFloat = new DevExpress.Utils.PointFloat(768.9176F, 0.0009218852F);
            this.labelDescVendedor.Multiline = true;
            this.labelDescVendedor.Name = "labelDescVendedor";
            this.labelDescVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescVendedor.SizeF = new System.Drawing.SizeF(83.53119F, 24.45773F);
            this.labelDescVendedor.StylePriority.UseFont = false;
            this.labelDescVendedor.StylePriority.UseTextAlignment = false;
            this.labelDescVendedor.Text = "Desc. Vendedor";
            this.labelDescVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelIVA
            // 
            this.labelIVA.Dpi = 100F;
            this.labelIVA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIVA.LocationFloat = new DevExpress.Utils.PointFloat(853.4487F, 0.001811981F);
            this.labelIVA.Multiline = true;
            this.labelIVA.Name = "labelIVA";
            this.labelIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelIVA.SizeF = new System.Drawing.SizeF(71.0719F, 24.45684F);
            this.labelIVA.StylePriority.UseFont = false;
            this.labelIVA.StylePriority.UseTextAlignment = false;
            this.labelIVA.Text = "IVA";
            this.labelIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelIEPS
            // 
            this.labelIEPS.Dpi = 100F;
            this.labelIEPS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIEPS.LocationFloat = new DevExpress.Utils.PointFloat(925.0206F, 0.001811981F);
            this.labelIEPS.Multiline = true;
            this.labelIEPS.Name = "labelIEPS";
            this.labelIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelIEPS.SizeF = new System.Drawing.SizeF(68.86444F, 24.45684F);
            this.labelIEPS.StylePriority.UseFont = false;
            this.labelIEPS.StylePriority.UseTextAlignment = false;
            this.labelIEPS.Text = "IEPS";
            this.labelIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTotal
            // 
            this.labelTotal.Dpi = 100F;
            this.labelTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.LocationFloat = new DevExpress.Utils.PointFloat(993.885F, 0.001907349F);
            this.labelTotal.Multiline = true;
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTotal.SizeF = new System.Drawing.SizeF(78.86499F, 24.45674F);
            this.labelTotal.StylePriority.UseFont = false;
            this.labelTotal.StylePriority.UseTextAlignment = false;
            this.labelTotal.Text = "Total";
            this.labelTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 2.249384F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.labelPrecioCantidad,
            this.labelPrecioKgLts,
            this.labelPrecioSubtotal,
            this.labelPrecioDescProducto,
            this.labelPrecioDescCliente,
            this.labelPrecioDescVendedor,
            this.labelPrecioIVA,
            this.labelPrecioIEPS,
            this.labelPrecioTotal});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 24.45906F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(281.1089F, 0.0004132589F);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(84.75256F, 24.45823F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Total";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioCantidad
            // 
            this.labelPrecioCantidad.Dpi = 100F;
            this.labelPrecioCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioCantidad.LocationFloat = new DevExpress.Utils.PointFloat(366.3615F, 0.0004132589F);
            this.labelPrecioCantidad.Multiline = true;
            this.labelPrecioCantidad.Name = "labelPrecioCantidad";
            this.labelPrecioCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelPrecioCantidad.StylePriority.UseFont = false;
            this.labelPrecioCantidad.StylePriority.UseTextAlignment = false;
            this.labelPrecioCantidad.Text = "Cantidad";
            this.labelPrecioCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioKgLts
            // 
            this.labelPrecioKgLts.Dpi = 100F;
            this.labelPrecioKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioKgLts.LocationFloat = new DevExpress.Utils.PointFloat(455.6259F, 0.0004132589F);
            this.labelPrecioKgLts.Multiline = true;
            this.labelPrecioKgLts.Name = "labelPrecioKgLts";
            this.labelPrecioKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelPrecioKgLts.StylePriority.UseFont = false;
            this.labelPrecioKgLts.StylePriority.UseTextAlignment = false;
            this.labelPrecioKgLts.Text = "Kilo/Litros";
            this.labelPrecioKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioSubtotal
            // 
            this.labelPrecioSubtotal.Dpi = 100F;
            this.labelPrecioSubtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(530.824F, 0.0004132589F);
            this.labelPrecioSubtotal.Multiline = true;
            this.labelPrecioSubtotal.Name = "labelPrecioSubtotal";
            this.labelPrecioSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioSubtotal.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelPrecioSubtotal.StylePriority.UseFont = false;
            this.labelPrecioSubtotal.StylePriority.UseTextAlignment = false;
            this.labelPrecioSubtotal.Text = "Subtotal";
            this.labelPrecioSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioDescProducto
            // 
            this.labelPrecioDescProducto.Dpi = 100F;
            this.labelPrecioDescProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioDescProducto.LocationFloat = new DevExpress.Utils.PointFloat(614.3552F, 0.0004132589F);
            this.labelPrecioDescProducto.Multiline = true;
            this.labelPrecioDescProducto.Name = "labelPrecioDescProducto";
            this.labelPrecioDescProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioDescProducto.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelPrecioDescProducto.StylePriority.UseFont = false;
            this.labelPrecioDescProducto.StylePriority.UseTextAlignment = false;
            this.labelPrecioDescProducto.Text = "Desc. Producto";
            this.labelPrecioDescProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioDescCliente
            // 
            this.labelPrecioDescCliente.Dpi = 100F;
            this.labelPrecioDescCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioDescCliente.LocationFloat = new DevExpress.Utils.PointFloat(697.8864F, 0.0004132589F);
            this.labelPrecioDescCliente.Multiline = true;
            this.labelPrecioDescCliente.Name = "labelPrecioDescCliente";
            this.labelPrecioDescCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioDescCliente.SizeF = new System.Drawing.SizeF(71.03119F, 24.45773F);
            this.labelPrecioDescCliente.StylePriority.UseFont = false;
            this.labelPrecioDescCliente.StylePriority.UseTextAlignment = false;
            this.labelPrecioDescCliente.Text = "Desc. Cliente";
            this.labelPrecioDescCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioDescVendedor
            // 
            this.labelPrecioDescVendedor.Dpi = 100F;
            this.labelPrecioDescVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioDescVendedor.LocationFloat = new DevExpress.Utils.PointFloat(768.9176F, 0.0004132589F);
            this.labelPrecioDescVendedor.Multiline = true;
            this.labelPrecioDescVendedor.Name = "labelPrecioDescVendedor";
            this.labelPrecioDescVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioDescVendedor.SizeF = new System.Drawing.SizeF(83.53119F, 24.45773F);
            this.labelPrecioDescVendedor.StylePriority.UseFont = false;
            this.labelPrecioDescVendedor.StylePriority.UseTextAlignment = false;
            this.labelPrecioDescVendedor.Text = "Desc. Vendedor";
            this.labelPrecioDescVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioIVA
            // 
            this.labelPrecioIVA.Dpi = 100F;
            this.labelPrecioIVA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioIVA.LocationFloat = new DevExpress.Utils.PointFloat(853.4487F, 0.0004132589F);
            this.labelPrecioIVA.Multiline = true;
            this.labelPrecioIVA.Name = "labelPrecioIVA";
            this.labelPrecioIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioIVA.SizeF = new System.Drawing.SizeF(71.0719F, 24.45684F);
            this.labelPrecioIVA.StylePriority.UseFont = false;
            this.labelPrecioIVA.StylePriority.UseTextAlignment = false;
            this.labelPrecioIVA.Text = "IVA";
            this.labelPrecioIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioIEPS
            // 
            this.labelPrecioIEPS.Dpi = 100F;
            this.labelPrecioIEPS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioIEPS.LocationFloat = new DevExpress.Utils.PointFloat(925.0206F, 0F);
            this.labelPrecioIEPS.Multiline = true;
            this.labelPrecioIEPS.Name = "labelPrecioIEPS";
            this.labelPrecioIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioIEPS.SizeF = new System.Drawing.SizeF(68.86444F, 24.45684F);
            this.labelPrecioIEPS.StylePriority.UseFont = false;
            this.labelPrecioIEPS.StylePriority.UseTextAlignment = false;
            this.labelPrecioIEPS.Text = "IEPS";
            this.labelPrecioIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioTotal
            // 
            this.labelPrecioTotal.Dpi = 100F;
            this.labelPrecioTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioTotal.LocationFloat = new DevExpress.Utils.PointFloat(993.8851F, 0F);
            this.labelPrecioTotal.Multiline = true;
            this.labelPrecioTotal.Name = "labelPrecioTotal";
            this.labelPrecioTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioTotal.SizeF = new System.Drawing.SizeF(78.86499F, 24.45674F);
            this.labelPrecioTotal.StylePriority.UseFont = false;
            this.labelPrecioTotal.StylePriority.UseTextAlignment = false;
            this.labelPrecioTotal.Text = "Total";
            this.labelPrecioTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 1.041667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCediTotal});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 16.18493F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // labelCediTotal
            // 
            this.labelCediTotal.Dpi = 100F;
            this.labelCediTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediTotal.LocationFloat = new DevExpress.Utils.PointFloat(1.500034F, 0F);
            this.labelCediTotal.Multiline = true;
            this.labelCediTotal.Name = "labelCediTotal";
            this.labelCediTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediTotal.SizeF = new System.Drawing.SizeF(139.2817F, 14.04007F);
            this.labelCediTotal.StylePriority.UseFont = false;
            this.labelCediTotal.StylePriority.UseTextAlignment = false;
            this.labelCediTotal.Text = "RESUMEN POR PRECIO";
            this.labelCediTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // ProductoPorPrecioKg
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 2, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
