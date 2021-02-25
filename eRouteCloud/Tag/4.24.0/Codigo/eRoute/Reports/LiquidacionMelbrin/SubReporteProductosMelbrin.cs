using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class SubReporteProductosMelbrin : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    private GroupFooterBand GroupFooter1;
    public GroupFooterBand GroupFooter2;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel20;
    public XRLabel SubProducto;
    public XRLabel PSimbolo;
    public XRLabel PClave;
    public XRLabel PDescripcion;
    public XRLabel PInicial;
    public XRLabel PRecarga;
    public XRLabel PDevolucion;
    public XRLabel PPromocion;
    public XRLabel PDescarga;
    public XRLabel PVentas;
    public XRLabel PFinal;
    public XRLabel PImporte;
    private XRLabel xrLabel9;
    private XRLabel xrLabel22;
    public XRLabel TPSimbolo;
    public XRLabel TPImporte;
    public XRLabel PConsignacion;
    private XRLabel xrLabel10;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteProductosMelbrin()
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
        this.PSimbolo = new DevExpress.XtraReports.UI.XRLabel();
        this.PClave = new DevExpress.XtraReports.UI.XRLabel();
        this.PDescripcion = new DevExpress.XtraReports.UI.XRLabel();
        this.PInicial = new DevExpress.XtraReports.UI.XRLabel();
        this.PRecarga = new DevExpress.XtraReports.UI.XRLabel();
        this.PDevolucion = new DevExpress.XtraReports.UI.XRLabel();
        this.PPromocion = new DevExpress.XtraReports.UI.XRLabel();
        this.PDescarga = new DevExpress.XtraReports.UI.XRLabel();
        this.PVentas = new DevExpress.XtraReports.UI.XRLabel();
        this.PFinal = new DevExpress.XtraReports.UI.XRLabel();
        this.PImporte = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.SubProducto = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.TPSimbolo = new DevExpress.XtraReports.UI.XRLabel();
        this.TPImporte = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.PConsignacion = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PConsignacion,
            this.PSimbolo,
            this.PClave,
            this.PDescripcion,
            this.PInicial,
            this.PRecarga,
            this.PDevolucion,
            this.PPromocion,
            this.PDescarga,
            this.PVentas,
            this.PFinal,
            this.PImporte});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 16.66667F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // PSimbolo
        // 
        this.PSimbolo.Dpi = 100F;
        this.PSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(947.4584F, 0F);
        this.PSimbolo.Name = "PSimbolo";
        this.PSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PSimbolo.SizeF = new System.Drawing.SizeF(36.00006F, 16F);
        this.PSimbolo.StylePriority.UseFont = false;
        this.PSimbolo.StylePriority.UseTextAlignment = false;
        this.PSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PClave
        // 
        this.PClave.Dpi = 100F;
        this.PClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PClave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.PClave.Name = "PClave";
        this.PClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PClave.SizeF = new System.Drawing.SizeF(50F, 16F);
        this.PClave.StylePriority.UseFont = false;
        this.PClave.StylePriority.UseTextAlignment = false;
        this.PClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // PDescripcion
        // 
        this.PDescripcion.Dpi = 100F;
        this.PDescripcion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(50.45842F, 0F);
        this.PDescripcion.Name = "PDescripcion";
        this.PDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PDescripcion.SizeF = new System.Drawing.SizeF(228.25F, 16F);
        this.PDescripcion.StylePriority.UseFont = false;
        this.PDescripcion.StylePriority.UseTextAlignment = false;
        this.PDescripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // PInicial
        // 
        this.PInicial.Dpi = 100F;
        this.PInicial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PInicial.LocationFloat = new DevExpress.Utils.PointFloat(278.7083F, 0F);
        this.PInicial.Name = "PInicial";
        this.PInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PInicial.SizeF = new System.Drawing.SizeF(100F, 16F);
        this.PInicial.StylePriority.UseFont = false;
        this.PInicial.StylePriority.UseTextAlignment = false;
        this.PInicial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PRecarga
        // 
        this.PRecarga.Dpi = 100F;
        this.PRecarga.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PRecarga.LocationFloat = new DevExpress.Utils.PointFloat(378.7083F, 0F);
        this.PRecarga.Name = "PRecarga";
        this.PRecarga.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PRecarga.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.PRecarga.StylePriority.UseFont = false;
        this.PRecarga.StylePriority.UseTextAlignment = false;
        this.PRecarga.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PDevolucion
        // 
        this.PDevolucion.Dpi = 100F;
        this.PDevolucion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PDevolucion.LocationFloat = new DevExpress.Utils.PointFloat(453.7083F, 0F);
        this.PDevolucion.Name = "PDevolucion";
        this.PDevolucion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PDevolucion.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.PDevolucion.StylePriority.UseFont = false;
        this.PDevolucion.StylePriority.UseTextAlignment = false;
        this.PDevolucion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PPromocion
        // 
        this.PPromocion.Dpi = 100F;
        this.PPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PPromocion.LocationFloat = new DevExpress.Utils.PointFloat(528.7083F, 0F);
        this.PPromocion.Name = "PPromocion";
        this.PPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PPromocion.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.PPromocion.StylePriority.UseFont = false;
        this.PPromocion.StylePriority.UseTextAlignment = false;
        this.PPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PDescarga
        // 
        this.PDescarga.Dpi = 100F;
        this.PDescarga.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PDescarga.LocationFloat = new DevExpress.Utils.PointFloat(603.7083F, 0F);
        this.PDescarga.Name = "PDescarga";
        this.PDescarga.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PDescarga.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.PDescarga.StylePriority.UseFont = false;
        this.PDescarga.StylePriority.UseTextAlignment = false;
        this.PDescarga.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PVentas
        // 
        this.PVentas.Dpi = 100F;
        this.PVentas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PVentas.LocationFloat = new DevExpress.Utils.PointFloat(678.7083F, 0F);
        this.PVentas.Name = "PVentas";
        this.PVentas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PVentas.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.PVentas.StylePriority.UseFont = false;
        this.PVentas.StylePriority.UseTextAlignment = false;
        this.PVentas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PFinal
        // 
        this.PFinal.Dpi = 100F;
        this.PFinal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PFinal.LocationFloat = new DevExpress.Utils.PointFloat(847.4584F, 0F);
        this.PFinal.Name = "PFinal";
        this.PFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PFinal.SizeF = new System.Drawing.SizeF(100F, 16F);
        this.PFinal.StylePriority.UseFont = false;
        this.PFinal.StylePriority.UseTextAlignment = false;
        this.PFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PImporte
        // 
        this.PImporte.Dpi = 100F;
        this.PImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PImporte.LocationFloat = new DevExpress.Utils.PointFloat(983.9167F, 0F);
        this.PImporte.Name = "PImporte";
        this.PImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PImporte.SizeF = new System.Drawing.SizeF(87.62488F, 16F);
        this.PImporte.StylePriority.UseFont = false;
        this.PImporte.StylePriority.UseTextAlignment = false;
        this.PImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
        this.BottomMargin.HeightF = 0F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel20});
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.HeightF = 16.66667F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrLabel9
        // 
        this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(947.4584F, 0F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(124.0833F, 16F);
        this.xrLabel9.StylePriority.UseBorders = false;
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Importe";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel8.Dpi = 100F;
        this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(852.0833F, 0F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(95.37506F, 16F);
        this.xrLabel8.StylePriority.UseBorders = false;
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Inventario Final";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(678.7083F, 0F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.xrLabel7.StylePriority.UseBorders = false;
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Ventas";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(603.7083F, 0F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.xrLabel6.StylePriority.UseBorders = false;
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Descarga";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel5.Dpi = 100F;
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(528.7083F, 0F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.xrLabel5.StylePriority.UseBorders = false;
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Promocion";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(453.7083F, 0F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.xrLabel4.StylePriority.UseBorders = false;
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Devolucion";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(378.7083F, 0F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(75F, 16F);
        this.xrLabel3.StylePriority.UseBorders = false;
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Recarga";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(278.7083F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 16F);
        this.xrLabel2.StylePriority.UseBorders = false;
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Inventario Inicial";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(50.4584F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(228.25F, 16F);
        this.xrLabel1.StylePriority.UseBorders = false;
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "Descripcion";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel20.Dpi = 100F;
        this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(50F, 16F);
        this.xrLabel20.StylePriority.UseBorders = false;
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "Clave";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // GroupHeader2
        // 
        this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SubProducto});
        this.GroupHeader2.Dpi = 100F;
        this.GroupHeader2.HeightF = 16.66667F;
        this.GroupHeader2.Level = 1;
        this.GroupHeader2.Name = "GroupHeader2";
        // 
        // SubProducto
        // 
        this.SubProducto.Dpi = 100F;
        this.SubProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SubProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.SubProducto.Name = "SubProducto";
        this.SubProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.SubProducto.SizeF = new System.Drawing.SizeF(200F, 16F);
        this.SubProducto.StylePriority.UseFont = false;
        this.SubProducto.Text = "VENTAS POR PRODUCTO";
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Dpi = 100F;
        this.GroupFooter1.HeightF = 0F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // GroupFooter2
        // 
        this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TPSimbolo,
            this.TPImporte,
            this.xrLabel22});
        this.GroupFooter2.Dpi = 100F;
        this.GroupFooter2.HeightF = 16.66667F;
        this.GroupFooter2.Level = 1;
        this.GroupFooter2.Name = "GroupFooter2";
        // 
        // TPSimbolo
        // 
        this.TPSimbolo.Dpi = 100F;
        this.TPSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TPSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(947.4584F, 0F);
        this.TPSimbolo.Name = "TPSimbolo";
        this.TPSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.TPSimbolo.SizeF = new System.Drawing.SizeF(36.00006F, 16F);
        this.TPSimbolo.StylePriority.UseFont = false;
        this.TPSimbolo.StylePriority.UseTextAlignment = false;
        this.TPSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // TPImporte
        // 
        this.TPImporte.Dpi = 100F;
        this.TPImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TPImporte.LocationFloat = new DevExpress.Utils.PointFloat(983.9167F, 0F);
        this.TPImporte.Name = "TPImporte";
        this.TPImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.TPImporte.SizeF = new System.Drawing.SizeF(87.62488F, 16F);
        this.TPImporte.StylePriority.UseFont = false;
        this.TPImporte.StylePriority.UseTextAlignment = false;
        this.TPImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel22
        // 
        this.xrLabel22.Dpi = 100F;
        this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(747.4584F, 0F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(200F, 16F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "Total de Ventas de Productos";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(753.7083F, 0F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(97.91669F, 16F);
        this.xrLabel10.StylePriority.UseBorders = false;
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Consignacion";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
        // 
        // PConsignacion
        // 
        this.PConsignacion.Dpi = 100F;
        this.PConsignacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.PConsignacion.LocationFloat = new DevExpress.Utils.PointFloat(753.7083F, 0F);
        this.PConsignacion.Name = "PConsignacion";
        this.PConsignacion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.PConsignacion.SizeF = new System.Drawing.SizeF(93.29175F, 16F);
        this.PConsignacion.StylePriority.UseFont = false;
        this.PConsignacion.StylePriority.UseTextAlignment = false;
        this.PConsignacion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // SubReporteProductosMelbrin
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupFooter1,
            this.GroupFooter2});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(14, 14, 0, 0);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Version = "16.1";
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
