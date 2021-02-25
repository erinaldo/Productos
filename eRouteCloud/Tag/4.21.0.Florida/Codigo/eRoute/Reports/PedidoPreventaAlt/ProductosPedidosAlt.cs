using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ProductosPedidos
/// </summary>
public class ProductosPedidosAlt : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    public XRLabel subClave;
    public XRLabel subProducto;
    public XRLabel subUnidad;
    public XRLabel subCantidad;
    public XRLabel subTotal;
    private XRLabel xrLabel6;
    private XRLine xrLine2;
    private XRLabel xrLabel5;
    public XRLabel xrLabelKg;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLine xrLine1;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel12;
    private ReportHeaderBand ReportHeader;
    public XRLabel lbTotalPro;
    public XRLabel totprod;
    public XRLabel grantotal;
    public XRLabel subKilos;
    private XRLabel xrLabel8;
    public XRLabel xrLabelKgTot;
    public XRLabel totKilos;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ProductosPedidosAlt()
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
            this.subKilos = new DevExpress.XtraReports.UI.XRLabel();
            this.subClave = new DevExpress.XtraReports.UI.XRLabel();
            this.subProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.subUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.subCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.subTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelKg = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.totKilos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelKgTot = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotalPro = new DevExpress.XtraReports.UI.XRLabel();
            this.totprod = new DevExpress.XtraReports.UI.XRLabel();
            this.grantotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subKilos,
            this.subClave,
            this.subProducto,
            this.subUnidad,
            this.subCantidad,
            this.subTotal});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // subKilos
            // 
            this.subKilos.Dpi = 100F;
            this.subKilos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subKilos.LocationFloat = new DevExpress.Utils.PointFloat(594.4583F, 0F);
            this.subKilos.Name = "subKilos";
            this.subKilos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subKilos.SizeF = new System.Drawing.SizeF(79.16669F, 23F);
            this.subKilos.StylePriority.UseFont = false;
            this.subKilos.Text = "Kilos";
            // 
            // subClave
            // 
            this.subClave.Dpi = 100F;
            this.subClave.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subClave.LocationFloat = new DevExpress.Utils.PointFloat(39.62507F, 0F);
            this.subClave.Name = "subClave";
            this.subClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subClave.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.subClave.StylePriority.UseFont = false;
            this.subClave.Text = "Clave";
            // 
            // subProducto
            // 
            this.subProducto.Dpi = 100F;
            this.subProducto.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subProducto.LocationFloat = new DevExpress.Utils.PointFloat(141.8749F, 0F);
            this.subProducto.Name = "subProducto";
            this.subProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subProducto.SizeF = new System.Drawing.SizeF(252.5833F, 23F);
            this.subProducto.StylePriority.UseFont = false;
            this.subProducto.Text = "Producto";
            // 
            // subUnidad
            // 
            this.subUnidad.Dpi = 100F;
            this.subUnidad.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subUnidad.LocationFloat = new DevExpress.Utils.PointFloat(394.4582F, 0F);
            this.subUnidad.Name = "subUnidad";
            this.subUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subUnidad.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.subUnidad.StylePriority.UseFont = false;
            this.subUnidad.Text = "Unidad";
            // 
            // subCantidad
            // 
            this.subCantidad.Dpi = 100F;
            this.subCantidad.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subCantidad.LocationFloat = new DevExpress.Utils.PointFloat(494.4582F, 0F);
            this.subCantidad.Name = "subCantidad";
            this.subCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subCantidad.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.subCantidad.StylePriority.UseFont = false;
            this.subCantidad.Text = "Cantidad";
            // 
            // subTotal
            // 
            this.subTotal.Dpi = 100F;
            this.subTotal.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotal.LocationFloat = new DevExpress.Utils.PointFloat(673.6249F, 0F);
            this.subTotal.Name = "subTotal";
            this.subTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subTotal.SizeF = new System.Drawing.SizeF(117.7083F, 23F);
            this.subTotal.StylePriority.UseFont = false;
            this.subTotal.StylePriority.UseTextAlignment = false;
            this.subTotal.Text = "Total";
            this.subTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 87.5F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 79F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(198.8333F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "PEDIDOS POR PRODUCTO";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(802.2916F, 23F);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(673.6249F, 33.00002F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(117.7083F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Total";
            // 
            // xrLabelKg
            // 
            this.xrLabelKg.Dpi = 100F;
            this.xrLabelKg.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelKg.LocationFloat = new DevExpress.Utils.PointFloat(594.4583F, 32.99999F);
            this.xrLabelKg.Name = "xrLabelKg";
            this.xrLabelKg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKg.SizeF = new System.Drawing.SizeF(79.16669F, 23F);
            this.xrLabelKg.StylePriority.UseFont = false;
            this.xrLabelKg.Text = "Kilo/Litros";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(394.4582F, 33.00002F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Unidad";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(141.8749F, 32.99999F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(252.5833F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Producto";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 56.00004F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(802.2916F, 23F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(39.62507F, 33.00004F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Clave";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totKilos,
            this.xrLabelKgTot,
            this.lbTotalPro,
            this.totprod,
            this.grantotal,
            this.xrLabel12});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 96.875F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // totKilos
            // 
            this.totKilos.Dpi = 100F;
            this.totKilos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totKilos.LocationFloat = new DevExpress.Utils.PointFloat(674.4999F, 46F);
            this.totKilos.Name = "totKilos";
            this.totKilos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totKilos.SizeF = new System.Drawing.SizeF(137.5F, 23F);
            this.totKilos.StylePriority.UseFont = false;
            this.totKilos.StylePriority.UseTextAlignment = false;
            this.totKilos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabelKgTot
            // 
            this.xrLabelKgTot.Dpi = 100F;
            this.xrLabelKgTot.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelKgTot.LocationFloat = new DevExpress.Utils.PointFloat(526.7499F, 46F);
            this.xrLabelKgTot.Name = "xrLabelKgTot";
            this.xrLabelKgTot.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelKgTot.SizeF = new System.Drawing.SizeF(126.0417F, 23F);
            this.xrLabelKgTot.StylePriority.UseFont = false;
            this.xrLabelKgTot.StylePriority.UseTextAlignment = false;
            this.xrLabelKgTot.Text = "Total de Kilo/Litros";
            this.xrLabelKgTot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lbTotalPro
            // 
            this.lbTotalPro.Dpi = 100F;
            this.lbTotalPro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPro.LocationFloat = new DevExpress.Utils.PointFloat(526.7499F, 22.99999F);
            this.lbTotalPro.Name = "lbTotalPro";
            this.lbTotalPro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotalPro.SizeF = new System.Drawing.SizeF(126.0417F, 23F);
            this.lbTotalPro.StylePriority.UseFont = false;
            this.lbTotalPro.StylePriority.UseTextAlignment = false;
            this.lbTotalPro.Text = "Total de Productos";
            this.lbTotalPro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // totprod
            // 
            this.totprod.Dpi = 100F;
            this.totprod.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totprod.LocationFloat = new DevExpress.Utils.PointFloat(674.5F, 22.99999F);
            this.totprod.Name = "totprod";
            this.totprod.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totprod.SizeF = new System.Drawing.SizeF(137.5F, 23F);
            this.totprod.StylePriority.UseFont = false;
            this.totprod.StylePriority.UseTextAlignment = false;
            this.totprod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // grantotal
            // 
            this.grantotal.Dpi = 100F;
            this.grantotal.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grantotal.LocationFloat = new DevExpress.Utils.PointFloat(674.2083F, 0F);
            this.grantotal.Name = "grantotal";
            this.grantotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.grantotal.SizeF = new System.Drawing.SizeF(137.7916F, 23F);
            this.grantotal.StylePriority.UseFont = false;
            this.grantotal.StylePriority.UseTextAlignment = false;
            this.grantotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(552.7916F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "GRAN TOTAL";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLine2,
            this.xrLine1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabelKg,
            this.xrLabel5,
            this.xrLabel1,
            this.xrLabel6});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 102F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(494.4582F, 32.99999F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Cantidad";
            // 
            // ProductosPedidosAlt
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(18, 20, 88, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
