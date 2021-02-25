using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class VentasKg : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public GroupHeaderBand GroupHeader1;
    private GroupFooterBand GroupFooter1;
    private PageFooterBand PageFooter;
    private XRLabel xrLabel21;
    private XRLabel xrLabel4;
    public GroupHeaderBand GroupHeader5;
    public GroupHeaderBand GroupHeader4;
    public XRLabel labelCantidad;
    public XRLabel labelDescCliente;
    public XRLabel labelDescProducto;
    public XRLabel labelSubtotal;
    public XRLabel labelClave;
    public XRLabel labelUnidad;
    public XRLabel labelKgLts;
    public XRLabel labelProducto;
    public XRLabel labelDescVendedor;
    public XRLabel labelPrecioU;
    public XRLabel labelIVA;
    public XRLabel labelIEPS;
    public XRLabel labelTotal;
    private GroupFooterBand GroupFooter4;
    private GroupFooterBand GroupFooter5;
    public XRLabel labelClienteTotal;
    public XRLabel labelClienteIEPS;
    public XRLabel labelClienteIVA;
    public XRLabel labelClienteDescVendedor;
    public XRLabel labelClienteDescCliente;
    public XRLabel labelClienteDescProducto;
    public XRLabel labelClienteSubtotal;
    public XRLabel labelClienteKgLts;
    public XRLabel labelClienteCantidad;
    private XRLabel xrLabel27;
    public XRLabel labelFolioCliente;
    public XRLabel labelClienteCliente;
    private XRLabel xrLabel7;
    public XRLabel cediNombre;
    private XRLabel xrLabel9;
    public XRLabel rutaDescripcion;
    private XRLabel xrLabel1;
    public XRLabel labelVendedorCantidad;
    public XRLabel labelVendedorKgLts;
    public XRLabel labelVendedorSubtotal;
    public XRLabel labelVendedorDescProducto;
    public XRLabel labelVendedorDescCliente;
    public XRLabel labelVendedorDescVendedor;
    public XRLabel labelVendedorIVA;
    public XRLabel labelVendedorIEPS;
    public XRLabel labelVendedorTotal;
    public XRLabel labelCediTotal;
    private XRLabel xrLabel14;
    public XRLabel labelCediCantidad;
    public XRLabel labelCediKgLts;
    public XRLabel labelCediSubtotal;
    public XRLabel labelCediDescProducto;
    public XRLabel labelCediDescCliente;
    public XRLabel labelCediDescVendedor;
    public XRLabel labelCediIVA;
    public XRLabel labelCediIEPS;
    private ReportHeaderBand ReportHeader;
    private XRLine xrLine2;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel36;
    private XRLabel xrLabel8;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel2;
    private XRLine xrLine1;
    private XRLabel xrLabel11;
    public XRLabel xrLabel22;
    private XRLabel xrLabel10;
    public XRLabel vendedorNombre;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public VentasKg()
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
            this.labelCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClave = new DevExpress.XtraReports.UI.XRLabel();
            this.labelUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPrecioU = new DevExpress.XtraReports.UI.XRLabel();
            this.labelIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelFolioCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelClienteTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteDescVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteDescCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteDescProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelClienteCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.cediNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.vendedorNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.rutaDescripcion = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorDescProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorDescCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorDescVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelVendedorTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelCediTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediKgLts = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediDescProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediDescCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediDescVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCediIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCantidad,
            this.labelDescCliente,
            this.labelDescProducto,
            this.labelSubtotal,
            this.labelClave,
            this.labelUnidad,
            this.labelKgLts,
            this.labelProducto,
            this.labelDescVendedor,
            this.labelPrecioU,
            this.labelIVA,
            this.labelIEPS,
            this.labelTotal});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 27.16697F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelCantidad
            // 
            this.labelCantidad.Dpi = 100F;
            this.labelCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidad.LocationFloat = new DevExpress.Utils.PointFloat(362.9865F, 0.001811981F);
            this.labelCantidad.Multiline = true;
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelCantidad.StylePriority.UseFont = false;
            this.labelCantidad.StylePriority.UseTextAlignment = false;
            this.labelCantidad.Text = "Cantidad";
            this.labelCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelDescCliente
            // 
            this.labelDescCliente.Dpi = 100F;
            this.labelDescCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescCliente.LocationFloat = new DevExpress.Utils.PointFloat(694.5112F, 0.0009218852F);
            this.labelDescCliente.Multiline = true;
            this.labelDescCliente.Name = "labelDescCliente";
            this.labelDescCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescCliente.SizeF = new System.Drawing.SizeF(71.03119F, 24.45773F);
            this.labelDescCliente.StylePriority.UseFont = false;
            this.labelDescCliente.StylePriority.UseTextAlignment = false;
            this.labelDescCliente.Text = "Desc. Cliente";
            this.labelDescCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelDescProducto
            // 
            this.labelDescProducto.Dpi = 100F;
            this.labelDescProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescProducto.LocationFloat = new DevExpress.Utils.PointFloat(610.98F, 0F);
            this.labelDescProducto.Multiline = true;
            this.labelDescProducto.Name = "labelDescProducto";
            this.labelDescProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescProducto.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelDescProducto.StylePriority.UseFont = false;
            this.labelDescProducto.StylePriority.UseTextAlignment = false;
            this.labelDescProducto.Text = "Desc. Producto";
            this.labelDescProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.Dpi = 100F;
            this.labelSubtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(527.4489F, 0F);
            this.labelSubtotal.Multiline = true;
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubtotal.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelSubtotal.StylePriority.UseFont = false;
            this.labelSubtotal.StylePriority.UseTextAlignment = false;
            this.labelSubtotal.Text = "Subtotal";
            this.labelSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClave
            // 
            this.labelClave.Dpi = 100F;
            this.labelClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.LocationFloat = new DevExpress.Utils.PointFloat(0.4999796F, 0F);
            this.labelClave.Multiline = true;
            this.labelClave.Name = "labelClave";
            this.labelClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClave.SizeF = new System.Drawing.SizeF(76.45836F, 24.45865F);
            this.labelClave.StylePriority.UseFont = false;
            this.labelClave.StylePriority.UseTextAlignment = false;
            this.labelClave.Text = "Clave";
            this.labelClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelUnidad
            // 
            this.labelUnidad.Dpi = 100F;
            this.labelUnidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnidad.LocationFloat = new DevExpress.Utils.PointFloat(203.2756F, 0.001811981F);
            this.labelUnidad.Name = "labelUnidad";
            this.labelUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelUnidad.SizeF = new System.Drawing.SizeF(74.95836F, 24.45684F);
            this.labelUnidad.StylePriority.UseFont = false;
            this.labelUnidad.StylePriority.UseTextAlignment = false;
            this.labelUnidad.Text = "Unidad";
            this.labelUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelKgLts
            // 
            this.labelKgLts.Dpi = 100F;
            this.labelKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKgLts.LocationFloat = new DevExpress.Utils.PointFloat(452.2509F, 0.0009218852F);
            this.labelKgLts.Multiline = true;
            this.labelKgLts.Name = "labelKgLts";
            this.labelKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelKgLts.StylePriority.UseFont = false;
            this.labelKgLts.StylePriority.UseTextAlignment = false;
            this.labelKgLts.Text = "Kilo/Litros";
            this.labelKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelProducto
            // 
            this.labelProducto.Dpi = 100F;
            this.labelProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducto.LocationFloat = new DevExpress.Utils.PointFloat(77.45832F, 0F);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto.SizeF = new System.Drawing.SizeF(125.3173F, 24.45865F);
            this.labelProducto.StylePriority.UseFont = false;
            this.labelProducto.StylePriority.UseTextAlignment = false;
            this.labelProducto.Text = "Producto";
            this.labelProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelDescVendedor
            // 
            this.labelDescVendedor.Dpi = 100F;
            this.labelDescVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescVendedor.LocationFloat = new DevExpress.Utils.PointFloat(765.5424F, 0.0009218852F);
            this.labelDescVendedor.Multiline = true;
            this.labelDescVendedor.Name = "labelDescVendedor";
            this.labelDescVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescVendedor.SizeF = new System.Drawing.SizeF(83.53119F, 24.45773F);
            this.labelDescVendedor.StylePriority.UseFont = false;
            this.labelDescVendedor.StylePriority.UseTextAlignment = false;
            this.labelDescVendedor.Text = "Desc. Vendedor";
            this.labelDescVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPrecioU
            // 
            this.labelPrecioU.Dpi = 100F;
            this.labelPrecioU.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioU.LocationFloat = new DevExpress.Utils.PointFloat(278.2339F, 0.0004132589F);
            this.labelPrecioU.Multiline = true;
            this.labelPrecioU.Name = "labelPrecioU";
            this.labelPrecioU.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPrecioU.SizeF = new System.Drawing.SizeF(84.75256F, 24.45823F);
            this.labelPrecioU.StylePriority.UseFont = false;
            this.labelPrecioU.StylePriority.UseTextAlignment = false;
            this.labelPrecioU.Text = "PrecioU";
            this.labelPrecioU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelIVA
            // 
            this.labelIVA.Dpi = 100F;
            this.labelIVA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIVA.LocationFloat = new DevExpress.Utils.PointFloat(849.0736F, 0.001811981F);
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
            this.labelIEPS.LocationFloat = new DevExpress.Utils.PointFloat(920.6456F, 0F);
            this.labelIEPS.Multiline = true;
            this.labelIEPS.Name = "labelIEPS";
            this.labelIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelIEPS.SizeF = new System.Drawing.SizeF(73.48938F, 24.45684F);
            this.labelIEPS.StylePriority.UseFont = false;
            this.labelIEPS.StylePriority.UseTextAlignment = false;
            this.labelIEPS.Text = "IEPS";
            this.labelIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTotal
            // 
            this.labelTotal.Dpi = 100F;
            this.labelTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.LocationFloat = new DevExpress.Utils.PointFloat(994.135F, 0.001907349F);
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
            this.TopMargin.HeightF = 57.45772F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(934.6873F, 32.77068F);
            this.xrLabel21.Multiline = true;
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(56.44788F, 34.45584F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "IEPS";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(992.1351F, 32.77079F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(79.86493F, 34.45581F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Total";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 3F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelFolioCliente,
            this.labelClienteCliente});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 17.08336F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // labelFolioCliente
            // 
            this.labelFolioCliente.Dpi = 100F;
            this.labelFolioCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolioCliente.LocationFloat = new DevExpress.Utils.PointFloat(4.041664F, 1.000035F);
            this.labelFolioCliente.Multiline = true;
            this.labelFolioCliente.Name = "labelFolioCliente";
            this.labelFolioCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFolioCliente.SizeF = new System.Drawing.SizeF(72.91667F, 12.99996F);
            this.labelFolioCliente.StylePriority.UseFont = false;
            this.labelFolioCliente.StylePriority.UseTextAlignment = false;
            this.labelFolioCliente.Text = "Folio";
            this.labelFolioCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelClienteCliente
            // 
            this.labelClienteCliente.Dpi = 100F;
            this.labelClienteCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteCliente.LocationFloat = new DevExpress.Utils.PointFloat(96.07722F, 1.000023F);
            this.labelClienteCliente.Multiline = true;
            this.labelClienteCliente.Name = "labelClienteCliente";
            this.labelClienteCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteCliente.SizeF = new System.Drawing.SizeF(695.0195F, 12.99996F);
            this.labelClienteCliente.StylePriority.UseFont = false;
            this.labelClienteCliente.StylePriority.UseTextAlignment = false;
            this.labelClienteCliente.Text = "Cliente";
            this.labelClienteCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelClienteTotal,
            this.labelClienteIEPS,
            this.labelClienteIVA,
            this.labelClienteDescVendedor,
            this.labelClienteDescCliente,
            this.labelClienteDescProducto,
            this.labelClienteSubtotal,
            this.labelClienteKgLts,
            this.labelClienteCantidad,
            this.xrLabel27});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 24.45906F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // labelClienteTotal
            // 
            this.labelClienteTotal.Dpi = 100F;
            this.labelClienteTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteTotal.LocationFloat = new DevExpress.Utils.PointFloat(993.635F, 0.001907349F);
            this.labelClienteTotal.Multiline = true;
            this.labelClienteTotal.Name = "labelClienteTotal";
            this.labelClienteTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteTotal.SizeF = new System.Drawing.SizeF(78.86499F, 24.45674F);
            this.labelClienteTotal.StylePriority.UseFont = false;
            this.labelClienteTotal.StylePriority.UseTextAlignment = false;
            this.labelClienteTotal.Text = "Total";
            this.labelClienteTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteIEPS
            // 
            this.labelClienteIEPS.Dpi = 100F;
            this.labelClienteIEPS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteIEPS.LocationFloat = new DevExpress.Utils.PointFloat(922.6456F, 0.001811981F);
            this.labelClienteIEPS.Multiline = true;
            this.labelClienteIEPS.Name = "labelClienteIEPS";
            this.labelClienteIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteIEPS.SizeF = new System.Drawing.SizeF(70.98944F, 24.45684F);
            this.labelClienteIEPS.StylePriority.UseFont = false;
            this.labelClienteIEPS.StylePriority.UseTextAlignment = false;
            this.labelClienteIEPS.Text = "IEPS";
            this.labelClienteIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteIVA
            // 
            this.labelClienteIVA.Dpi = 100F;
            this.labelClienteIVA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteIVA.LocationFloat = new DevExpress.Utils.PointFloat(850.5737F, 0.001811981F);
            this.labelClienteIVA.Multiline = true;
            this.labelClienteIVA.Name = "labelClienteIVA";
            this.labelClienteIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteIVA.SizeF = new System.Drawing.SizeF(71.0719F, 24.45684F);
            this.labelClienteIVA.StylePriority.UseFont = false;
            this.labelClienteIVA.StylePriority.UseTextAlignment = false;
            this.labelClienteIVA.Text = "IVA";
            this.labelClienteIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteDescVendedor
            // 
            this.labelClienteDescVendedor.Dpi = 100F;
            this.labelClienteDescVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteDescVendedor.LocationFloat = new DevExpress.Utils.PointFloat(766.0426F, 0.0009218852F);
            this.labelClienteDescVendedor.Multiline = true;
            this.labelClienteDescVendedor.Name = "labelClienteDescVendedor";
            this.labelClienteDescVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteDescVendedor.SizeF = new System.Drawing.SizeF(83.53119F, 24.45773F);
            this.labelClienteDescVendedor.StylePriority.UseFont = false;
            this.labelClienteDescVendedor.StylePriority.UseTextAlignment = false;
            this.labelClienteDescVendedor.Text = "Desc. Vendedor";
            this.labelClienteDescVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteDescCliente
            // 
            this.labelClienteDescCliente.Dpi = 100F;
            this.labelClienteDescCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteDescCliente.LocationFloat = new DevExpress.Utils.PointFloat(695.0114F, 0.0009218852F);
            this.labelClienteDescCliente.Multiline = true;
            this.labelClienteDescCliente.Name = "labelClienteDescCliente";
            this.labelClienteDescCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteDescCliente.SizeF = new System.Drawing.SizeF(71.03119F, 24.45773F);
            this.labelClienteDescCliente.StylePriority.UseFont = false;
            this.labelClienteDescCliente.StylePriority.UseTextAlignment = false;
            this.labelClienteDescCliente.Text = "Desc. Cliente";
            this.labelClienteDescCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteDescProducto
            // 
            this.labelClienteDescProducto.Dpi = 100F;
            this.labelClienteDescProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteDescProducto.LocationFloat = new DevExpress.Utils.PointFloat(611.4802F, 0.0004132589F);
            this.labelClienteDescProducto.Multiline = true;
            this.labelClienteDescProducto.Name = "labelClienteDescProducto";
            this.labelClienteDescProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteDescProducto.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelClienteDescProducto.StylePriority.UseFont = false;
            this.labelClienteDescProducto.StylePriority.UseTextAlignment = false;
            this.labelClienteDescProducto.Text = "Desc. Producto";
            this.labelClienteDescProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteSubtotal
            // 
            this.labelClienteSubtotal.Dpi = 100F;
            this.labelClienteSubtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(527.949F, 0.0004132589F);
            this.labelClienteSubtotal.Multiline = true;
            this.labelClienteSubtotal.Name = "labelClienteSubtotal";
            this.labelClienteSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteSubtotal.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelClienteSubtotal.StylePriority.UseFont = false;
            this.labelClienteSubtotal.StylePriority.UseTextAlignment = false;
            this.labelClienteSubtotal.Text = "Subtotal";
            this.labelClienteSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteKgLts
            // 
            this.labelClienteKgLts.Dpi = 100F;
            this.labelClienteKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteKgLts.LocationFloat = new DevExpress.Utils.PointFloat(452.7509F, 0.0009218852F);
            this.labelClienteKgLts.Multiline = true;
            this.labelClienteKgLts.Name = "labelClienteKgLts";
            this.labelClienteKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelClienteKgLts.StylePriority.UseFont = false;
            this.labelClienteKgLts.StylePriority.UseTextAlignment = false;
            this.labelClienteKgLts.Text = "Kilo/Litros";
            this.labelClienteKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelClienteCantidad
            // 
            this.labelClienteCantidad.Dpi = 100F;
            this.labelClienteCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteCantidad.LocationFloat = new DevExpress.Utils.PointFloat(363.4865F, 0.001811981F);
            this.labelClienteCantidad.Multiline = true;
            this.labelClienteCantidad.Name = "labelClienteCantidad";
            this.labelClienteCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelClienteCantidad.StylePriority.UseFont = false;
            this.labelClienteCantidad.StylePriority.UseTextAlignment = false;
            this.labelClienteCantidad.Text = "Cantidad";
            this.labelClienteCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(278.2339F, 0.0004132589F);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(84.75256F, 24.45823F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Total";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 1.041667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.cediNombre});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 18.58333F;
            this.GroupHeader5.Level = 2;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(137.477F, 16.04167F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Centro de Distribución:";
            // 
            // cediNombre
            // 
            this.cediNombre.Dpi = 100F;
            this.cediNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cediNombre.LocationFloat = new DevExpress.Utils.PointFloat(170.0446F, 0F);
            this.cediNombre.Name = "cediNombre";
            this.cediNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cediNombre.SizeF = new System.Drawing.SizeF(404.0001F, 16.04167F);
            this.cediNombre.StylePriority.UseFont = false;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrLabel22,
            this.xrLabel10,
            this.vendedorNombre,
            this.xrLabel9,
            this.rutaDescripcion});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 51.54165F;
            this.GroupHeader4.Level = 1;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(50.76243F, 31.04167F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(39.81479F, 13.00001F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "Ruta:";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(161.4042F, 31.04165F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(87.3334F, 15.00001F);
            this.xrLabel22.StylePriority.UseFont = false;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(34.38288F, 16.04165F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(75.75999F, 15.00003F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Fecha:";
            // 
            // vendedorNombre
            // 
            this.vendedorNombre.Dpi = 100F;
            this.vendedorNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendedorNombre.LocationFloat = new DevExpress.Utils.PointFloat(162.4041F, 16.04165F);
            this.vendedorNombre.Name = "vendedorNombre";
            this.vendedorNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vendedorNombre.SizeF = new System.Drawing.SizeF(86.8334F, 15.00001F);
            this.vendedorNombre.StylePriority.UseFont = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(23.51875F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(99.99998F, 16.04165F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Vendedor:";
            // 
            // rutaDescripcion
            // 
            this.rutaDescripcion.Dpi = 100F;
            this.rutaDescripcion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutaDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(162.9041F, 0F);
            this.rutaDescripcion.Name = "rutaDescripcion";
            this.rutaDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rutaDescripcion.SizeF = new System.Drawing.SizeF(85.83347F, 16.04165F);
            this.rutaDescripcion.StylePriority.UseFont = false;
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.labelVendedorCantidad,
            this.labelVendedorKgLts,
            this.labelVendedorSubtotal,
            this.labelVendedorDescProducto,
            this.labelVendedorDescCliente,
            this.labelVendedorDescVendedor,
            this.labelVendedorIVA,
            this.labelVendedorIEPS,
            this.labelVendedorTotal});
            this.GroupFooter4.Dpi = 100F;
            this.GroupFooter4.HeightF = 24.45865F;
            this.GroupFooter4.Level = 1;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(250.1088F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(112.8776F, 24.45823F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Total Vendedor";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorCantidad
            // 
            this.labelVendedorCantidad.Dpi = 100F;
            this.labelVendedorCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorCantidad.LocationFloat = new DevExpress.Utils.PointFloat(362.9865F, 0F);
            this.labelVendedorCantidad.Multiline = true;
            this.labelVendedorCantidad.Name = "labelVendedorCantidad";
            this.labelVendedorCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelVendedorCantidad.StylePriority.UseFont = false;
            this.labelVendedorCantidad.StylePriority.UseTextAlignment = false;
            this.labelVendedorCantidad.Text = "Cantidad";
            this.labelVendedorCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorKgLts
            // 
            this.labelVendedorKgLts.Dpi = 100F;
            this.labelVendedorKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorKgLts.LocationFloat = new DevExpress.Utils.PointFloat(452.2509F, 0F);
            this.labelVendedorKgLts.Multiline = true;
            this.labelVendedorKgLts.Name = "labelVendedorKgLts";
            this.labelVendedorKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelVendedorKgLts.StylePriority.UseFont = false;
            this.labelVendedorKgLts.StylePriority.UseTextAlignment = false;
            this.labelVendedorKgLts.Text = "Kilo/Litros";
            this.labelVendedorKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorSubtotal
            // 
            this.labelVendedorSubtotal.Dpi = 100F;
            this.labelVendedorSubtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(527.449F, 0F);
            this.labelVendedorSubtotal.Multiline = true;
            this.labelVendedorSubtotal.Name = "labelVendedorSubtotal";
            this.labelVendedorSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorSubtotal.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelVendedorSubtotal.StylePriority.UseFont = false;
            this.labelVendedorSubtotal.StylePriority.UseTextAlignment = false;
            this.labelVendedorSubtotal.Text = "Subtotal";
            this.labelVendedorSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorDescProducto
            // 
            this.labelVendedorDescProducto.Dpi = 100F;
            this.labelVendedorDescProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorDescProducto.LocationFloat = new DevExpress.Utils.PointFloat(610.9802F, 0F);
            this.labelVendedorDescProducto.Multiline = true;
            this.labelVendedorDescProducto.Name = "labelVendedorDescProducto";
            this.labelVendedorDescProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorDescProducto.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelVendedorDescProducto.StylePriority.UseFont = false;
            this.labelVendedorDescProducto.StylePriority.UseTextAlignment = false;
            this.labelVendedorDescProducto.Text = "Desc. Producto";
            this.labelVendedorDescProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorDescCliente
            // 
            this.labelVendedorDescCliente.Dpi = 100F;
            this.labelVendedorDescCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorDescCliente.LocationFloat = new DevExpress.Utils.PointFloat(694.5114F, 0F);
            this.labelVendedorDescCliente.Multiline = true;
            this.labelVendedorDescCliente.Name = "labelVendedorDescCliente";
            this.labelVendedorDescCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorDescCliente.SizeF = new System.Drawing.SizeF(71.03119F, 24.45773F);
            this.labelVendedorDescCliente.StylePriority.UseFont = false;
            this.labelVendedorDescCliente.StylePriority.UseTextAlignment = false;
            this.labelVendedorDescCliente.Text = "Desc. Cliente";
            this.labelVendedorDescCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorDescVendedor
            // 
            this.labelVendedorDescVendedor.Dpi = 100F;
            this.labelVendedorDescVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorDescVendedor.LocationFloat = new DevExpress.Utils.PointFloat(765.5426F, 0F);
            this.labelVendedorDescVendedor.Multiline = true;
            this.labelVendedorDescVendedor.Name = "labelVendedorDescVendedor";
            this.labelVendedorDescVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorDescVendedor.SizeF = new System.Drawing.SizeF(83.53119F, 24.45773F);
            this.labelVendedorDescVendedor.StylePriority.UseFont = false;
            this.labelVendedorDescVendedor.StylePriority.UseTextAlignment = false;
            this.labelVendedorDescVendedor.Text = "Desc. Vendedor";
            this.labelVendedorDescVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorIVA
            // 
            this.labelVendedorIVA.Dpi = 100F;
            this.labelVendedorIVA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorIVA.LocationFloat = new DevExpress.Utils.PointFloat(850.0737F, 0F);
            this.labelVendedorIVA.Multiline = true;
            this.labelVendedorIVA.Name = "labelVendedorIVA";
            this.labelVendedorIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorIVA.SizeF = new System.Drawing.SizeF(71.0719F, 24.45684F);
            this.labelVendedorIVA.StylePriority.UseFont = false;
            this.labelVendedorIVA.StylePriority.UseTextAlignment = false;
            this.labelVendedorIVA.Text = "IVA";
            this.labelVendedorIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorIEPS
            // 
            this.labelVendedorIEPS.Dpi = 100F;
            this.labelVendedorIEPS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorIEPS.LocationFloat = new DevExpress.Utils.PointFloat(922.6456F, 0F);
            this.labelVendedorIEPS.Multiline = true;
            this.labelVendedorIEPS.Name = "labelVendedorIEPS";
            this.labelVendedorIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorIEPS.SizeF = new System.Drawing.SizeF(70.98944F, 24.45684F);
            this.labelVendedorIEPS.StylePriority.UseFont = false;
            this.labelVendedorIEPS.StylePriority.UseTextAlignment = false;
            this.labelVendedorIEPS.Text = "IEPS";
            this.labelVendedorIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelVendedorTotal
            // 
            this.labelVendedorTotal.Dpi = 100F;
            this.labelVendedorTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendedorTotal.LocationFloat = new DevExpress.Utils.PointFloat(994.135F, 0F);
            this.labelVendedorTotal.Multiline = true;
            this.labelVendedorTotal.Name = "labelVendedorTotal";
            this.labelVendedorTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVendedorTotal.SizeF = new System.Drawing.SizeF(78.86499F, 24.45674F);
            this.labelVendedorTotal.StylePriority.UseFont = false;
            this.labelVendedorTotal.StylePriority.UseTextAlignment = false;
            this.labelVendedorTotal.Text = "Total";
            this.labelVendedorTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCediTotal,
            this.xrLabel14,
            this.labelCediCantidad,
            this.labelCediKgLts,
            this.labelCediSubtotal,
            this.labelCediDescProducto,
            this.labelCediDescCliente,
            this.labelCediDescVendedor,
            this.labelCediIVA,
            this.labelCediIEPS});
            this.GroupFooter5.Dpi = 100F;
            this.GroupFooter5.HeightF = 24.46088F;
            this.GroupFooter5.Level = 2;
            this.GroupFooter5.Name = "GroupFooter5";
            // 
            // labelCediTotal
            // 
            this.labelCediTotal.Dpi = 100F;
            this.labelCediTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediTotal.LocationFloat = new DevExpress.Utils.PointFloat(994.135F, 0.003687541F);
            this.labelCediTotal.Multiline = true;
            this.labelCediTotal.Name = "labelCediTotal";
            this.labelCediTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediTotal.SizeF = new System.Drawing.SizeF(78.86499F, 24.45674F);
            this.labelCediTotal.StylePriority.UseFont = false;
            this.labelCediTotal.StylePriority.UseTextAlignment = false;
            this.labelCediTotal.Text = "Total";
            this.labelCediTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(157.503F, 0.00222524F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(205.4835F, 24.45823F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Total Centro de Distribución";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediCantidad
            // 
            this.labelCediCantidad.Dpi = 100F;
            this.labelCediCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediCantidad.LocationFloat = new DevExpress.Utils.PointFloat(363.4867F, 0.00222524F);
            this.labelCediCantidad.Multiline = true;
            this.labelCediCantidad.Name = "labelCediCantidad";
            this.labelCediCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediCantidad.SizeF = new System.Drawing.SizeF(89.26437F, 24.45684F);
            this.labelCediCantidad.StylePriority.UseFont = false;
            this.labelCediCantidad.StylePriority.UseTextAlignment = false;
            this.labelCediCantidad.Text = "Cantidad";
            this.labelCediCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediKgLts
            // 
            this.labelCediKgLts.Dpi = 100F;
            this.labelCediKgLts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediKgLts.LocationFloat = new DevExpress.Utils.PointFloat(452.7512F, 0.00222524F);
            this.labelCediKgLts.Multiline = true;
            this.labelCediKgLts.Name = "labelCediKgLts";
            this.labelCediKgLts.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediKgLts.SizeF = new System.Drawing.SizeF(75.19797F, 24.45773F);
            this.labelCediKgLts.StylePriority.UseFont = false;
            this.labelCediKgLts.StylePriority.UseTextAlignment = false;
            this.labelCediKgLts.Text = "Kilo/Litros";
            this.labelCediKgLts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediSubtotal
            // 
            this.labelCediSubtotal.Dpi = 100F;
            this.labelCediSubtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(527.949F, 0.00222524F);
            this.labelCediSubtotal.Multiline = true;
            this.labelCediSubtotal.Name = "labelCediSubtotal";
            this.labelCediSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediSubtotal.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelCediSubtotal.StylePriority.UseFont = false;
            this.labelCediSubtotal.StylePriority.UseTextAlignment = false;
            this.labelCediSubtotal.Text = "Subtotal";
            this.labelCediSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediDescProducto
            // 
            this.labelCediDescProducto.Dpi = 100F;
            this.labelCediDescProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediDescProducto.LocationFloat = new DevExpress.Utils.PointFloat(611.4802F, 0.00222524F);
            this.labelCediDescProducto.Multiline = true;
            this.labelCediDescProducto.Name = "labelCediDescProducto";
            this.labelCediDescProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediDescProducto.SizeF = new System.Drawing.SizeF(83.53119F, 24.45865F);
            this.labelCediDescProducto.StylePriority.UseFont = false;
            this.labelCediDescProducto.StylePriority.UseTextAlignment = false;
            this.labelCediDescProducto.Text = "Desc. Producto";
            this.labelCediDescProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediDescCliente
            // 
            this.labelCediDescCliente.Dpi = 100F;
            this.labelCediDescCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediDescCliente.LocationFloat = new DevExpress.Utils.PointFloat(695.0114F, 0.00222524F);
            this.labelCediDescCliente.Multiline = true;
            this.labelCediDescCliente.Name = "labelCediDescCliente";
            this.labelCediDescCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediDescCliente.SizeF = new System.Drawing.SizeF(71.03119F, 24.45773F);
            this.labelCediDescCliente.StylePriority.UseFont = false;
            this.labelCediDescCliente.StylePriority.UseTextAlignment = false;
            this.labelCediDescCliente.Text = "Desc. Cliente";
            this.labelCediDescCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediDescVendedor
            // 
            this.labelCediDescVendedor.Dpi = 100F;
            this.labelCediDescVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediDescVendedor.LocationFloat = new DevExpress.Utils.PointFloat(766.0426F, 0.00222524F);
            this.labelCediDescVendedor.Multiline = true;
            this.labelCediDescVendedor.Name = "labelCediDescVendedor";
            this.labelCediDescVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediDescVendedor.SizeF = new System.Drawing.SizeF(83.53119F, 24.45773F);
            this.labelCediDescVendedor.StylePriority.UseFont = false;
            this.labelCediDescVendedor.StylePriority.UseTextAlignment = false;
            this.labelCediDescVendedor.Text = "Desc. Vendedor";
            this.labelCediDescVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediIVA
            // 
            this.labelCediIVA.Dpi = 100F;
            this.labelCediIVA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediIVA.LocationFloat = new DevExpress.Utils.PointFloat(850.5737F, 0.00222524F);
            this.labelCediIVA.Multiline = true;
            this.labelCediIVA.Name = "labelCediIVA";
            this.labelCediIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediIVA.SizeF = new System.Drawing.SizeF(71.0719F, 24.45684F);
            this.labelCediIVA.StylePriority.UseFont = false;
            this.labelCediIVA.StylePriority.UseTextAlignment = false;
            this.labelCediIVA.Text = "IVA";
            this.labelCediIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCediIEPS
            // 
            this.labelCediIEPS.Dpi = 100F;
            this.labelCediIEPS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCediIEPS.LocationFloat = new DevExpress.Utils.PointFloat(922.6456F, 0.001780192F);
            this.labelCediIEPS.Multiline = true;
            this.labelCediIEPS.Name = "labelCediIEPS";
            this.labelCediIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCediIEPS.SizeF = new System.Drawing.SizeF(70.98944F, 24.45684F);
            this.labelCediIEPS.StylePriority.UseFont = false;
            this.labelCediIEPS.StylePriority.UseTextAlignment = false;
            this.labelCediIEPS.Text = "IEPS";
            this.labelCediIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel36,
            this.xrLabel8,
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel2,
            this.xrLine1,
            this.xrLabel21,
            this.xrLabel4});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 90.22929F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 67.22929F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1072.5F, 23F);
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(0F, 32.77068F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(76.45836F, 34.45865F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Clave";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(76.95834F, 32.77069F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(126.3172F, 34.45859F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "Producto";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(203.2756F, 32.77261F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(88.00005F, 34.45682F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "Unidad";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(291.2755F, 32.77111F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(84.75256F, 34.45816F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "P.U.";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(376.5282F, 32.77249F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(89.26437F, 34.45584F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Cantidad";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(465.7926F, 32.7716F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(75.198F, 34.45773F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Kilo/Litros";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(540.9907F, 32.77068F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(83.53119F, 34.45773F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Subtotal";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(624.5219F, 32.77068F);
            this.xrLabel19.Multiline = true;
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(83.53119F, 34.45773F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Desc. Producto";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(708.0531F, 32.7716F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(71.03119F, 34.45773F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Desc. Cliente";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(779.0843F, 32.7716F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(83.53119F, 34.45773F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Desc. Vendedor";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(863.6154F, 32.77249F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(71.07196F, 34.45587F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "IVA";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.9999911F, 9.770699F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1072F, 22.99998F);
            // 
            // VentasKg
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter,
            this.GroupHeader5,
            this.GroupHeader4,
            this.GroupFooter4,
            this.GroupFooter5,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 57, 3);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
