using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class ReporteVentasBYD : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    public XRLabel labelProducto;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    public GroupHeaderBand GroupHeader1;
    public XRLabel labelFolioDetalle;
    public GroupHeaderBand GroupHeader2;
    public XRLabel labelClienteDetalle;
    public GroupFooterBand GroupFooter1;
    public ReportFooterBand ReportFooter;
    public XRLabel labelNeto;
    public XRLabel labelIVA;
    public XRLabel labelSubtotal;
    public XRLabel labelDescuento;
    public XRLabel labelMonto;
    public XRLabel labelCantidad;
    public XRLabel labelS;
    public XRLabel labelSCantidad;
    public XRLabel labelSMonto;
    public XRLabel labelSDescuento;
    public XRLabel labelSSubtotal;
    public XRLabel labelSIVA;
    public XRLabel labelSNeto;
    public XRLabel labelTNeto;
    public XRLabel labelTIVA;
    public XRLabel labelTSubtotal;
    public XRLabel labelTDescuento;
    public XRLabel labelTMonto;
    public XRLabel labelTCantidad;
    public XRLabel labelT;
    public XRLabel labelF;
    public XRLabel labelIEPS;
    private XRLabel xrLabel10;
    public XRLabel labelSIEPS;
    public XRLabel labelTIEPS;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel xrLabel69;
    public XRLabel nameFechas;
    public XRLabel nameFiltro;
    public XRLabel centro;
    public XRLabel fecha;
    public XRLabel filtro;
    public XRLabel empresa;
    public XRLabel xrLabel1;
    public XRLabel cliente;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteVentasBYD()
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
            this.labelIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelNeto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescuento = new DevExpress.XtraReports.UI.XRLabel();
            this.labelMonto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.cliente = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.nameFechas = new DevExpress.XtraReports.UI.XRLabel();
            this.nameFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.filtro = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelF = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFolioDetalle = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelClienteDetalle = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelSIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSMonto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSDescuento = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSNeto = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.labelTIEPS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTNeto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTIVA = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTDescuento = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTMonto = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.labelT = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelIEPS,
            this.labelNeto,
            this.labelIVA,
            this.labelSubtotal,
            this.labelDescuento,
            this.labelMonto,
            this.labelCantidad,
            this.labelProducto});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 18F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelIEPS
            // 
            this.labelIEPS.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelIEPS.Dpi = 100F;
            this.labelIEPS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIEPS.LocationFloat = new DevExpress.Utils.PointFloat(605F, 0F);
            this.labelIEPS.Name = "labelIEPS";
            this.labelIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelIEPS.SizeF = new System.Drawing.SizeF(69F, 18F);
            this.labelIEPS.StylePriority.UseBorders = false;
            this.labelIEPS.StylePriority.UseFont = false;
            this.labelIEPS.StylePriority.UseTextAlignment = false;
            this.labelIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelNeto
            // 
            this.labelNeto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelNeto.Dpi = 100F;
            this.labelNeto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNeto.LocationFloat = new DevExpress.Utils.PointFloat(739F, 0F);
            this.labelNeto.Name = "labelNeto";
            this.labelNeto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelNeto.SizeF = new System.Drawing.SizeF(85F, 18F);
            this.labelNeto.StylePriority.UseBorders = false;
            this.labelNeto.StylePriority.UseFont = false;
            this.labelNeto.StylePriority.UseTextAlignment = false;
            this.labelNeto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelIVA
            // 
            this.labelIVA.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelIVA.Dpi = 100F;
            this.labelIVA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIVA.LocationFloat = new DevExpress.Utils.PointFloat(674F, 0F);
            this.labelIVA.Name = "labelIVA";
            this.labelIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelIVA.SizeF = new System.Drawing.SizeF(65F, 18F);
            this.labelIVA.StylePriority.UseBorders = false;
            this.labelIVA.StylePriority.UseFont = false;
            this.labelIVA.StylePriority.UseTextAlignment = false;
            this.labelIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelSubtotal.Dpi = 100F;
            this.labelSubtotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(528F, 0F);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSubtotal.SizeF = new System.Drawing.SizeF(77F, 18F);
            this.labelSubtotal.StylePriority.UseBorders = false;
            this.labelSubtotal.StylePriority.UseFont = false;
            this.labelSubtotal.StylePriority.UseTextAlignment = false;
            this.labelSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelDescuento
            // 
            this.labelDescuento.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelDescuento.Dpi = 100F;
            this.labelDescuento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescuento.LocationFloat = new DevExpress.Utils.PointFloat(454F, 0F);
            this.labelDescuento.Name = "labelDescuento";
            this.labelDescuento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescuento.SizeF = new System.Drawing.SizeF(74F, 18F);
            this.labelDescuento.StylePriority.UseBorders = false;
            this.labelDescuento.StylePriority.UseFont = false;
            this.labelDescuento.StylePriority.UseTextAlignment = false;
            this.labelDescuento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelMonto
            // 
            this.labelMonto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelMonto.Dpi = 100F;
            this.labelMonto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonto.LocationFloat = new DevExpress.Utils.PointFloat(378F, 0F);
            this.labelMonto.Name = "labelMonto";
            this.labelMonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelMonto.SizeF = new System.Drawing.SizeF(76F, 18F);
            this.labelMonto.StylePriority.UseBorders = false;
            this.labelMonto.StylePriority.UseFont = false;
            this.labelMonto.StylePriority.UseTextAlignment = false;
            this.labelMonto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCantidad
            // 
            this.labelCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCantidad.Dpi = 100F;
            this.labelCantidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidad.LocationFloat = new DevExpress.Utils.PointFloat(315F, 0F);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCantidad.SizeF = new System.Drawing.SizeF(63F, 18F);
            this.labelCantidad.StylePriority.UseBorders = false;
            this.labelCantidad.StylePriority.UseFont = false;
            this.labelCantidad.StylePriority.UseTextAlignment = false;
            this.labelCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelProducto
            // 
            this.labelProducto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelProducto.Dpi = 100F;
            this.labelProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducto.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto.SizeF = new System.Drawing.SizeF(315F, 18F);
            this.labelProducto.StylePriority.UseBorders = false;
            this.labelProducto.StylePriority.UseFont = false;
            this.labelProducto.StylePriority.UseTextAlignment = false;
            this.labelProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.cliente,
            this.logo,
            this.reporte,
            this.xrLabel69,
            this.nameFechas,
            this.nameFiltro,
            this.centro,
            this.fecha,
            this.filtro,
            this.empresa});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 155F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 140F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Cliente(s):";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // cliente
            // 
            this.cliente.CanGrow = false;
            this.cliente.Dpi = 100F;
            this.cliente.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.cliente.LocationFloat = new DevExpress.Utils.PointFloat(150F, 140F);
            this.cliente.Name = "cliente";
            this.cliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cliente.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.cliente.StylePriority.UseFont = false;
            this.cliente.StylePriority.UseTextAlignment = false;
            this.cliente.Text = "cliente";
            this.cliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(10F, 10F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(170F, 55F);
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
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "Centro De Distribución:";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // nameFechas
            // 
            this.nameFechas.CanGrow = false;
            this.nameFechas.Dpi = 100F;
            this.nameFechas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.nameFechas.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110F);
            this.nameFechas.Name = "nameFechas";
            this.nameFechas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nameFechas.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.nameFechas.StylePriority.UseFont = false;
            this.nameFechas.StylePriority.UseTextAlignment = false;
            this.nameFechas.Text = "nameFechas";
            this.nameFechas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // nameFiltro
            // 
            this.nameFiltro.CanGrow = false;
            this.nameFiltro.Dpi = 100F;
            this.nameFiltro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.nameFiltro.LocationFloat = new DevExpress.Utils.PointFloat(0F, 125F);
            this.nameFiltro.Name = "nameFiltro";
            this.nameFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nameFiltro.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.nameFiltro.StylePriority.UseFont = false;
            this.nameFiltro.StylePriority.UseTextAlignment = false;
            this.nameFiltro.Text = "nameFiltro";
            this.nameFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // centro
            // 
            this.centro.CanGrow = false;
            this.centro.Dpi = 100F;
            this.centro.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 95F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(680F, 15F);
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
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(150F, 110F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(680F, 15F);
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
            this.filtro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 125F);
            this.filtro.Name = "filtro";
            this.filtro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.filtro.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.filtro.StylePriority.UseFont = false;
            this.filtro.StylePriority.UseTextAlignment = false;
            this.filtro.Text = "filtro";
            this.filtro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(170F, 15F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(10.00002F, 27.45832F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(501F, 25.95831F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 29.17F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(605F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(69F, 29.17F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "IEPS";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(315F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(63F, 29.17F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Cantidad";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(378F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(76F, 29.17F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Monto";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(454F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(74F, 29.17F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Descuento";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(528F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(77F, 29.17F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Subtotal";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(674F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(65F, 29.17F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "IVA";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(739F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(85F, 29.17F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Valor Neto";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(315F, 29.17F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Prducto";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelF,
            this.labelFolioDetalle});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 18.75F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // labelF
            // 
            this.labelF.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelF.Dpi = 100F;
            this.labelF.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelF.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.labelF.Name = "labelF";
            this.labelF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelF.SizeF = new System.Drawing.SizeF(50F, 18F);
            this.labelF.StylePriority.UseBorders = false;
            this.labelF.StylePriority.UseFont = false;
            this.labelF.StylePriority.UseTextAlignment = false;
            this.labelF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelFolioDetalle
            // 
            this.labelFolioDetalle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelFolioDetalle.Dpi = 100F;
            this.labelFolioDetalle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolioDetalle.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.labelFolioDetalle.Name = "labelFolioDetalle";
            this.labelFolioDetalle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFolioDetalle.SizeF = new System.Drawing.SizeF(265F, 18F);
            this.labelFolioDetalle.StylePriority.UseBorders = false;
            this.labelFolioDetalle.StylePriority.UseFont = false;
            this.labelFolioDetalle.StylePriority.UseTextAlignment = false;
            this.labelFolioDetalle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelClienteDetalle});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 18.75F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // labelClienteDetalle
            // 
            this.labelClienteDetalle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelClienteDetalle.Dpi = 100F;
            this.labelClienteDetalle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteDetalle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.labelClienteDetalle.Name = "labelClienteDetalle";
            this.labelClienteDetalle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelClienteDetalle.SizeF = new System.Drawing.SizeF(315F, 18F);
            this.labelClienteDetalle.StylePriority.UseBorders = false;
            this.labelClienteDetalle.StylePriority.UseFont = false;
            this.labelClienteDetalle.StylePriority.UseTextAlignment = false;
            this.labelClienteDetalle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelSIEPS,
            this.labelS,
            this.labelSCantidad,
            this.labelSMonto,
            this.labelSDescuento,
            this.labelSSubtotal,
            this.labelSIVA,
            this.labelSNeto});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 34.375F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // labelSIEPS
            // 
            this.labelSIEPS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSIEPS.Dpi = 100F;
            this.labelSIEPS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSIEPS.LocationFloat = new DevExpress.Utils.PointFloat(605F, 0F);
            this.labelSIEPS.Name = "labelSIEPS";
            this.labelSIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSIEPS.SizeF = new System.Drawing.SizeF(69F, 18F);
            this.labelSIEPS.StylePriority.UseBorders = false;
            this.labelSIEPS.StylePriority.UseFont = false;
            this.labelSIEPS.StylePriority.UseTextAlignment = false;
            this.labelSIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelS
            // 
            this.labelS.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelS.Dpi = 100F;
            this.labelS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS.LocationFloat = new DevExpress.Utils.PointFloat(90F, 0F);
            this.labelS.Name = "labelS";
            this.labelS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelS.SizeF = new System.Drawing.SizeF(225F, 18F);
            this.labelS.StylePriority.UseBorders = false;
            this.labelS.StylePriority.UseFont = false;
            this.labelS.StylePriority.UseTextAlignment = false;
            this.labelS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSCantidad
            // 
            this.labelSCantidad.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSCantidad.Dpi = 100F;
            this.labelSCantidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSCantidad.LocationFloat = new DevExpress.Utils.PointFloat(315F, 0F);
            this.labelSCantidad.Name = "labelSCantidad";
            this.labelSCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSCantidad.SizeF = new System.Drawing.SizeF(63F, 18F);
            this.labelSCantidad.StylePriority.UseBorders = false;
            this.labelSCantidad.StylePriority.UseFont = false;
            this.labelSCantidad.StylePriority.UseTextAlignment = false;
            this.labelSCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSMonto
            // 
            this.labelSMonto.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSMonto.Dpi = 100F;
            this.labelSMonto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSMonto.LocationFloat = new DevExpress.Utils.PointFloat(378F, 0F);
            this.labelSMonto.Name = "labelSMonto";
            this.labelSMonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSMonto.SizeF = new System.Drawing.SizeF(76F, 18F);
            this.labelSMonto.StylePriority.UseBorders = false;
            this.labelSMonto.StylePriority.UseFont = false;
            this.labelSMonto.StylePriority.UseTextAlignment = false;
            this.labelSMonto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSDescuento
            // 
            this.labelSDescuento.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSDescuento.Dpi = 100F;
            this.labelSDescuento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSDescuento.LocationFloat = new DevExpress.Utils.PointFloat(454F, 0F);
            this.labelSDescuento.Name = "labelSDescuento";
            this.labelSDescuento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSDescuento.SizeF = new System.Drawing.SizeF(74F, 18F);
            this.labelSDescuento.StylePriority.UseBorders = false;
            this.labelSDescuento.StylePriority.UseFont = false;
            this.labelSDescuento.StylePriority.UseTextAlignment = false;
            this.labelSDescuento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSSubtotal
            // 
            this.labelSSubtotal.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSSubtotal.Dpi = 100F;
            this.labelSSubtotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(528F, 0F);
            this.labelSSubtotal.Name = "labelSSubtotal";
            this.labelSSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSSubtotal.SizeF = new System.Drawing.SizeF(77F, 18F);
            this.labelSSubtotal.StylePriority.UseBorders = false;
            this.labelSSubtotal.StylePriority.UseFont = false;
            this.labelSSubtotal.StylePriority.UseTextAlignment = false;
            this.labelSSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSIVA
            // 
            this.labelSIVA.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSIVA.Dpi = 100F;
            this.labelSIVA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSIVA.LocationFloat = new DevExpress.Utils.PointFloat(674F, 0F);
            this.labelSIVA.Name = "labelSIVA";
            this.labelSIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSIVA.SizeF = new System.Drawing.SizeF(65F, 18F);
            this.labelSIVA.StylePriority.UseBorders = false;
            this.labelSIVA.StylePriority.UseFont = false;
            this.labelSIVA.StylePriority.UseTextAlignment = false;
            this.labelSIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelSNeto
            // 
            this.labelSNeto.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.labelSNeto.Dpi = 100F;
            this.labelSNeto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSNeto.LocationFloat = new DevExpress.Utils.PointFloat(739F, 0F);
            this.labelSNeto.Name = "labelSNeto";
            this.labelSNeto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSNeto.SizeF = new System.Drawing.SizeF(85F, 18F);
            this.labelSNeto.StylePriority.UseBorders = false;
            this.labelSNeto.StylePriority.UseFont = false;
            this.labelSNeto.StylePriority.UseTextAlignment = false;
            this.labelSNeto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelTIEPS,
            this.labelTNeto,
            this.labelTIVA,
            this.labelTSubtotal,
            this.labelTDescuento,
            this.labelTMonto,
            this.labelTCantidad,
            this.labelT,
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 50.45832F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // labelTIEPS
            // 
            this.labelTIEPS.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelTIEPS.Dpi = 100F;
            this.labelTIEPS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTIEPS.LocationFloat = new DevExpress.Utils.PointFloat(605F, 0F);
            this.labelTIEPS.Name = "labelTIEPS";
            this.labelTIEPS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTIEPS.SizeF = new System.Drawing.SizeF(69F, 18F);
            this.labelTIEPS.StylePriority.UseBorders = false;
            this.labelTIEPS.StylePriority.UseFont = false;
            this.labelTIEPS.StylePriority.UseTextAlignment = false;
            this.labelTIEPS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTNeto
            // 
            this.labelTNeto.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelTNeto.Dpi = 100F;
            this.labelTNeto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTNeto.LocationFloat = new DevExpress.Utils.PointFloat(739F, 0F);
            this.labelTNeto.Name = "labelTNeto";
            this.labelTNeto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTNeto.SizeF = new System.Drawing.SizeF(85F, 18F);
            this.labelTNeto.StylePriority.UseBorders = false;
            this.labelTNeto.StylePriority.UseFont = false;
            this.labelTNeto.StylePriority.UseTextAlignment = false;
            this.labelTNeto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTIVA
            // 
            this.labelTIVA.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelTIVA.Dpi = 100F;
            this.labelTIVA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTIVA.LocationFloat = new DevExpress.Utils.PointFloat(674F, 0F);
            this.labelTIVA.Name = "labelTIVA";
            this.labelTIVA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTIVA.SizeF = new System.Drawing.SizeF(65F, 18F);
            this.labelTIVA.StylePriority.UseBorders = false;
            this.labelTIVA.StylePriority.UseFont = false;
            this.labelTIVA.StylePriority.UseTextAlignment = false;
            this.labelTIVA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTSubtotal
            // 
            this.labelTSubtotal.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelTSubtotal.Dpi = 100F;
            this.labelTSubtotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(528F, 0F);
            this.labelTSubtotal.Name = "labelTSubtotal";
            this.labelTSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTSubtotal.SizeF = new System.Drawing.SizeF(77F, 18F);
            this.labelTSubtotal.StylePriority.UseBorders = false;
            this.labelTSubtotal.StylePriority.UseFont = false;
            this.labelTSubtotal.StylePriority.UseTextAlignment = false;
            this.labelTSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTDescuento
            // 
            this.labelTDescuento.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelTDescuento.Dpi = 100F;
            this.labelTDescuento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTDescuento.LocationFloat = new DevExpress.Utils.PointFloat(454F, 0F);
            this.labelTDescuento.Name = "labelTDescuento";
            this.labelTDescuento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTDescuento.SizeF = new System.Drawing.SizeF(74F, 18F);
            this.labelTDescuento.StylePriority.UseBorders = false;
            this.labelTDescuento.StylePriority.UseFont = false;
            this.labelTDescuento.StylePriority.UseTextAlignment = false;
            this.labelTDescuento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTMonto
            // 
            this.labelTMonto.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelTMonto.Dpi = 100F;
            this.labelTMonto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTMonto.LocationFloat = new DevExpress.Utils.PointFloat(378F, 0F);
            this.labelTMonto.Name = "labelTMonto";
            this.labelTMonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTMonto.SizeF = new System.Drawing.SizeF(76F, 18F);
            this.labelTMonto.StylePriority.UseBorders = false;
            this.labelTMonto.StylePriority.UseFont = false;
            this.labelTMonto.StylePriority.UseTextAlignment = false;
            this.labelTMonto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelTCantidad
            // 
            this.labelTCantidad.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelTCantidad.Dpi = 100F;
            this.labelTCantidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTCantidad.LocationFloat = new DevExpress.Utils.PointFloat(315F, 0F);
            this.labelTCantidad.Name = "labelTCantidad";
            this.labelTCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTCantidad.SizeF = new System.Drawing.SizeF(63F, 18F);
            this.labelTCantidad.StylePriority.UseBorders = false;
            this.labelTCantidad.StylePriority.UseFont = false;
            this.labelTCantidad.StylePriority.UseTextAlignment = false;
            this.labelTCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelT
            // 
            this.labelT.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelT.Dpi = 100F;
            this.labelT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelT.LocationFloat = new DevExpress.Utils.PointFloat(90F, 0F);
            this.labelT.Name = "labelT";
            this.labelT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelT.SizeF = new System.Drawing.SizeF(225F, 18F);
            this.labelT.StylePriority.UseBorders = false;
            this.labelT.StylePriority.UseFont = false;
            this.labelT.StylePriority.UseTextAlignment = false;
            this.labelT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReporteVentasBYD
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupFooter1,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 155, 10);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
