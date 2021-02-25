using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class SubReporteVentasClienteDetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public PageHeaderBand PageHeader;
    private XRLabel xrLabel5;
    public GroupHeaderBand GroupHeader1;
    public XRLabel labelFechaC;
    public XRLabel labelPiezasVC;
    public XRLabel labelPiezasCC;
    public XRLabel labelPiezasPC;
    public XRLabel labelImporteC;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel6;
    public XRLabel labelCliente;
    private ReportFooterBand ReportFooter;
    public XRLabel labelGranTotalC;
    public XRLabel labelGranVentaC;
    public XRLabel labelGranCambioC;
    public XRLabel labelGranPromocionC;
    public XRLabel labelGranImporteC;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel3;
    public XRLabel labelTiempoT;
    public XRLabel labelHInicio;
    public XRLabel labelHFinal;
    public XRLabel labelTiempoVisita;
    private XRLabel xrLabel7;
    private XRLabel xrLabel4;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    public GroupHeaderBand GroupHeader2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteVentasClienteDetallado()
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
            this.labelTiempoT = new DevExpress.XtraReports.UI.XRLabel();
            this.labelHInicio = new DevExpress.XtraReports.UI.XRLabel();
            this.labelHFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTiempoVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFechaC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasVC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasCC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPiezasPC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelImporteC = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.labelGranTotalC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranVentaC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranCambioC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranPromocionC = new DevExpress.XtraReports.UI.XRLabel();
            this.labelGranImporteC = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelTiempoT
            // 
            this.labelTiempoT.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelTiempoT.Dpi = 100F;
            this.labelTiempoT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempoT.LocationFloat = new DevExpress.Utils.PointFloat(410.0999F, 0F);
            this.labelTiempoT.Name = "labelTiempoT";
            this.labelTiempoT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTiempoT.SizeF = new System.Drawing.SizeF(103.5836F, 16F);
            this.labelTiempoT.StylePriority.UseBorders = false;
            this.labelTiempoT.StylePriority.UseFont = false;
            this.labelTiempoT.StylePriority.UseTextAlignment = false;
            this.labelTiempoT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelHInicio
            // 
            this.labelHInicio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelHInicio.Dpi = 100F;
            this.labelHInicio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHInicio.LocationFloat = new DevExpress.Utils.PointFloat(513.6835F, 0F);
            this.labelHInicio.Name = "labelHInicio";
            this.labelHInicio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelHInicio.SizeF = new System.Drawing.SizeF(88.9498F, 16F);
            this.labelHInicio.StylePriority.UseBorders = false;
            this.labelHInicio.StylePriority.UseFont = false;
            this.labelHInicio.StylePriority.UseTextAlignment = false;
            this.labelHInicio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelHFinal
            // 
            this.labelHFinal.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelHFinal.Dpi = 100F;
            this.labelHFinal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHFinal.LocationFloat = new DevExpress.Utils.PointFloat(602.6333F, 0F);
            this.labelHFinal.Name = "labelHFinal";
            this.labelHFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelHFinal.SizeF = new System.Drawing.SizeF(84.36688F, 16F);
            this.labelHFinal.StylePriority.UseBorders = false;
            this.labelHFinal.StylePriority.UseFont = false;
            this.labelHFinal.StylePriority.UseTextAlignment = false;
            this.labelHFinal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelTiempoVisita
            // 
            this.labelTiempoVisita.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelTiempoVisita.Dpi = 100F;
            this.labelTiempoVisita.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempoVisita.LocationFloat = new DevExpress.Utils.PointFloat(687.0002F, 0F);
            this.labelTiempoVisita.Name = "labelTiempoVisita";
            this.labelTiempoVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTiempoVisita.SizeF = new System.Drawing.SizeF(96.82501F, 16F);
            this.labelTiempoVisita.StylePriority.UseBorders = false;
            this.labelTiempoVisita.StylePriority.UseFont = false;
            this.labelTiempoVisita.StylePriority.UseTextAlignment = false;
            this.labelTiempoVisita.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelFechaC
            // 
            this.labelFechaC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelFechaC.Dpi = 100F;
            this.labelFechaC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaC.LocationFloat = new DevExpress.Utils.PointFloat(290.3583F, 0F);
            this.labelFechaC.Name = "labelFechaC";
            this.labelFechaC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFechaC.SizeF = new System.Drawing.SizeF(119.7416F, 16F);
            this.labelFechaC.StylePriority.UseBorders = false;
            this.labelFechaC.StylePriority.UseFont = false;
            this.labelFechaC.StylePriority.UseTextAlignment = false;
            this.labelFechaC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelPiezasVC
            // 
            this.labelPiezasVC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasVC.Dpi = 100F;
            this.labelPiezasVC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasVC.LocationFloat = new DevExpress.Utils.PointFloat(783.8252F, 0F);
            this.labelPiezasVC.Name = "labelPiezasVC";
            this.labelPiezasVC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasVC.SizeF = new System.Drawing.SizeF(64.53339F, 16F);
            this.labelPiezasVC.StylePriority.UseBorders = false;
            this.labelPiezasVC.StylePriority.UseFont = false;
            this.labelPiezasVC.StylePriority.UseTextAlignment = false;
            this.labelPiezasVC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPiezasCC
            // 
            this.labelPiezasCC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasCC.Dpi = 100F;
            this.labelPiezasCC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasCC.LocationFloat = new DevExpress.Utils.PointFloat(848.3586F, 0F);
            this.labelPiezasCC.Name = "labelPiezasCC";
            this.labelPiezasCC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasCC.SizeF = new System.Drawing.SizeF(66.07483F, 16F);
            this.labelPiezasCC.StylePriority.UseBorders = false;
            this.labelPiezasCC.StylePriority.UseFont = false;
            this.labelPiezasCC.StylePriority.UseTextAlignment = false;
            this.labelPiezasCC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPiezasPC
            // 
            this.labelPiezasPC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPiezasPC.Dpi = 100F;
            this.labelPiezasPC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPiezasPC.LocationFloat = new DevExpress.Utils.PointFloat(914.4334F, 0F);
            this.labelPiezasPC.Name = "labelPiezasPC";
            this.labelPiezasPC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPiezasPC.SizeF = new System.Drawing.SizeF(77.03339F, 16F);
            this.labelPiezasPC.StylePriority.UseBorders = false;
            this.labelPiezasPC.StylePriority.UseFont = false;
            this.labelPiezasPC.StylePriority.UseTextAlignment = false;
            this.labelPiezasPC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelImporteC
            // 
            this.labelImporteC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelImporteC.Dpi = 100F;
            this.labelImporteC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImporteC.LocationFloat = new DevExpress.Utils.PointFloat(991.4668F, 0F);
            this.labelImporteC.Name = "labelImporteC";
            this.labelImporteC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelImporteC.SizeF = new System.Drawing.SizeF(81.53F, 16F);
            this.labelImporteC.StylePriority.UseBorders = false;
            this.labelImporteC.StylePriority.UseFont = false;
            this.labelImporteC.StylePriority.UseTextAlignment = false;
            this.labelImporteC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel6,
            this.xrLabel5});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 42.70833F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(687.5001F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(96.82501F, 42.08333F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Tiempo Visita";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(602.6333F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(84.36688F, 42.08333F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Hora Fin";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(514.1835F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(88.4498F, 42.08333F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Hora Inicial";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(410.0999F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(104.0836F, 42.08333F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Tiempo en Transito";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(992.4666F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(81.53339F, 42.08333F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Importe (Venta)";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(914.9334F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(77.5332F, 42.08333F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Piezas (Promoción)";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(848.8586F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(66.07483F, 42.08333F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Piezas (Cambio)";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(784.3251F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(64.53345F, 42.08333F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Piezas (Venta)";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(289.8583F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(120.2416F, 42.08333F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Fecha de Entrega";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(2.499969F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(287.3583F, 42.08333F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Folio";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelCliente,
            this.labelFechaC,
            this.labelTiempoT,
            this.labelHInicio,
            this.labelHFinal,
            this.labelTiempoVisita,
            this.labelPiezasVC,
            this.labelPiezasCC,
            this.labelPiezasPC,
            this.labelImporteC});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 16F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // labelCliente
            // 
            this.labelCliente.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCliente.Dpi = 100F;
            this.labelCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.LocationFloat = new DevExpress.Utils.PointFloat(2.499939F, 0F);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCliente.SizeF = new System.Drawing.SizeF(287.8583F, 16F);
            this.labelCliente.StylePriority.UseBorders = false;
            this.labelCliente.StylePriority.UseFont = false;
            this.labelCliente.StylePriority.UseTextAlignment = false;
            this.labelCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelGranTotalC,
            this.labelGranVentaC,
            this.labelGranCambioC,
            this.labelGranPromocionC,
            this.labelGranImporteC});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 16.66667F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // labelGranTotalC
            // 
            this.labelGranTotalC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranTotalC.Dpi = 100F;
            this.labelGranTotalC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranTotalC.LocationFloat = new DevExpress.Utils.PointFloat(474.0052F, 0F);
            this.labelGranTotalC.Name = "labelGranTotalC";
            this.labelGranTotalC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranTotalC.SizeF = new System.Drawing.SizeF(309.82F, 16F);
            this.labelGranTotalC.StylePriority.UseBorders = false;
            this.labelGranTotalC.StylePriority.UseFont = false;
            this.labelGranTotalC.StylePriority.UseTextAlignment = false;
            this.labelGranTotalC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelGranVentaC
            // 
            this.labelGranVentaC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranVentaC.Dpi = 100F;
            this.labelGranVentaC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranVentaC.LocationFloat = new DevExpress.Utils.PointFloat(783.8252F, 0F);
            this.labelGranVentaC.Name = "labelGranVentaC";
            this.labelGranVentaC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranVentaC.SizeF = new System.Drawing.SizeF(64.53351F, 16F);
            this.labelGranVentaC.StylePriority.UseBorders = false;
            this.labelGranVentaC.StylePriority.UseFont = false;
            this.labelGranVentaC.StylePriority.UseTextAlignment = false;
            this.labelGranVentaC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelGranCambioC
            // 
            this.labelGranCambioC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranCambioC.Dpi = 100F;
            this.labelGranCambioC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranCambioC.LocationFloat = new DevExpress.Utils.PointFloat(848.3586F, 0F);
            this.labelGranCambioC.Name = "labelGranCambioC";
            this.labelGranCambioC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranCambioC.SizeF = new System.Drawing.SizeF(66.07483F, 16F);
            this.labelGranCambioC.StylePriority.UseBorders = false;
            this.labelGranCambioC.StylePriority.UseFont = false;
            this.labelGranCambioC.StylePriority.UseTextAlignment = false;
            this.labelGranCambioC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelGranPromocionC
            // 
            this.labelGranPromocionC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranPromocionC.Dpi = 100F;
            this.labelGranPromocionC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranPromocionC.LocationFloat = new DevExpress.Utils.PointFloat(914.4334F, 0F);
            this.labelGranPromocionC.Name = "labelGranPromocionC";
            this.labelGranPromocionC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranPromocionC.SizeF = new System.Drawing.SizeF(78.03333F, 16F);
            this.labelGranPromocionC.StylePriority.UseBorders = false;
            this.labelGranPromocionC.StylePriority.UseFont = false;
            this.labelGranPromocionC.StylePriority.UseTextAlignment = false;
            this.labelGranPromocionC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelGranImporteC
            // 
            this.labelGranImporteC.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelGranImporteC.Dpi = 100F;
            this.labelGranImporteC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGranImporteC.LocationFloat = new DevExpress.Utils.PointFloat(992.4666F, 0F);
            this.labelGranImporteC.Name = "labelGranImporteC";
            this.labelGranImporteC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelGranImporteC.SizeF = new System.Drawing.SizeF(81.03F, 16F);
            this.labelGranImporteC.StylePriority.UseBorders = false;
            this.labelGranImporteC.StylePriority.UseFont = false;
            this.labelGranImporteC.StylePriority.UseTextAlignment = false;
            this.labelGranImporteC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 16F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0.4999956F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(1071.5F, 16F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "II - Venta por Cliente";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 0F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // SubReporteVentasClienteDetallado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportFooter,
            this.ReportHeader,
            this.GroupHeader2});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 0, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
