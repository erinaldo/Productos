using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for PlanTrabajoSemanal
/// </summary>
public class PlanTrabajoSemanal : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel x1;
    public XRLabel x2;
    public XRLabel x3;
    public XRLabel x4;
    public XRLabel x5;
    public XRLabel x6;
    public XRLabel x7;
    public XRLabel x8;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private GroupHeaderBand GroupHeader1;
    public XRLabel ven;
    private XRLabel xrLabel26;
    public XRLabel nombre;
    private XRLabel xrLabel25;
    public XRLabel clave;
    private XRLabel xrLabel23;
    public XRLabel empresa;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    public XRLabel fechaa;
    public XRLabel centro;
    public XRLabel ruta;
    public XRLabel visita;
    public XRPictureBox logo1;
    public XRPictureBox logo2;
    private ReportHeaderBand ReportHeader;
    private PageFooterBand PageFooter;
    private XRLabel xrLabel29;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    public XRLabel ru;
    private XRLabel xrLabel1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PlanTrabajoSemanal()
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.fechaa = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.visita = new DevExpress.XtraReports.UI.XRLabel();
            this.logo1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.logo2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.x1 = new DevExpress.XtraReports.UI.XRLabel();
            this.x2 = new DevExpress.XtraReports.UI.XRLabel();
            this.x3 = new DevExpress.XtraReports.UI.XRLabel();
            this.x4 = new DevExpress.XtraReports.UI.XRLabel();
            this.x5 = new DevExpress.XtraReports.UI.XRLabel();
            this.x6 = new DevExpress.XtraReports.UI.XRLabel();
            this.x7 = new DevExpress.XtraReports.UI.XRLabel();
            this.x8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.clave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.nombre = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.ven = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ru = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.x1,
            this.x2,
            this.x3,
            this.x4,
            this.x5,
            this.x6,
            this.x7,
            this.x8});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 24.13195F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 7F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 4F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLine2,
            this.xrLine1,
            this.xrLabel14});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 63.82578F;
            this.PageHeader.Name = "PageHeader";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ru,
            this.xrLabel1,
            this.ven,
            this.xrLabel26,
            this.nombre,
            this.xrLabel25,
            this.clave,
            this.xrLabel23});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 52.90404F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(201.7187F, 13.46874F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(494.7916F, 31.33333F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.Text = "empresa\t";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(201.7187F, 44.80207F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(648.9583F, 48.95835F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "PLAN DE TRABAJO SEMANAL (LA COSTEÑA) ";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(276.7187F, 100.0104F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.Text = "Fecha Actual";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(276.7187F, 123.0104F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel4.Text = "CEDI";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(276.7187F, 149.0521F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.Text = "Ruta (s)";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(276.7187F, 172.0521F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel6.Text = "Dia de Visita";
            // 
            // fechaa
            // 
            this.fechaa.Dpi = 100F;
            this.fechaa.LocationFloat = new DevExpress.Utils.PointFloat(392.0831F, 100.0104F);
            this.fechaa.Name = "fechaa";
            this.fechaa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechaa.SizeF = new System.Drawing.SizeF(214.5833F, 23F);
            this.fechaa.Text = "fechaa";
            // 
            // centro
            // 
            this.centro.Dpi = 100F;
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(391.8228F, 123.0104F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(214.8437F, 22.99999F);
            this.centro.Text = "centro";
            // 
            // ruta
            // 
            this.ruta.Dpi = 100F;
            this.ruta.LocationFloat = new DevExpress.Utils.PointFloat(391.5623F, 149.0521F);
            this.ruta.Name = "ruta";
            this.ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ruta.SizeF = new System.Drawing.SizeF(410.1563F, 23F);
            this.ruta.Text = "ruta";
            // 
            // visita
            // 
            this.visita.Dpi = 100F;
            this.visita.LocationFloat = new DevExpress.Utils.PointFloat(392.3436F, 172.0521F);
            this.visita.Name = "visita";
            this.visita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.visita.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.visita.Text = "visita";
            // 
            // logo1
            // 
            this.logo1.Dpi = 100F;
            this.logo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 14.32292F);
            this.logo1.Name = "logo1";
            this.logo1.SizeF = new System.Drawing.SizeF(175.5208F, 85.58336F);
            // 
            // logo2
            // 
            this.logo2.Dpi = 100F;
            this.logo2.LocationFloat = new DevExpress.Utils.PointFloat(868.7395F, 14.32292F);
            this.logo2.Name = "logo2";
            this.logo2.SizeF = new System.Drawing.SizeF(175.5208F, 85.58336F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.visita,
            this.ruta,
            this.centro,
            this.fechaa,
            this.empresa,
            this.logo2});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 201.5625F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(3.080447F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1086.682F, 10.41667F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(3.054932F, 43.40911F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1089.945F, 10.41667F);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(7.03126F, 10.41667F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(54.72573F, 32.99245F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Orden de \r\n   Visita";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(61.757F, 10.41667F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(86.18749F, 32.99245F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Código del\r\n   Cliente";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(161.2257F, 10.41666F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(153.2811F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Razon Social";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(374.3644F, 10.41667F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Cliente";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(474.3644F, 10.41667F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(112.8409F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "RFC";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(587.3644F, 10.41666F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(185.3124F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "Dirección";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(772.6768F, 10.41667F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(202.1875F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "Colonia";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(974.8643F, 10.41667F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(116.2127F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "Telefono";
            // 
            // x1
            // 
            this.x1.Dpi = 100F;
            this.x1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x1.LocationFloat = new DevExpress.Utils.PointFloat(23.91379F, 0F);
            this.x1.Name = "x1";
            this.x1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x1.SizeF = new System.Drawing.SizeF(37.8432F, 23F);
            this.x1.StylePriority.UseFont = false;
            this.x1.Text = "x1";
            // 
            // x2
            // 
            this.x2.Dpi = 100F;
            this.x2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x2.LocationFloat = new DevExpress.Utils.PointFloat(61.757F, 0F);
            this.x2.Name = "x2";
            this.x2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x2.SizeF = new System.Drawing.SizeF(99.46873F, 23F);
            this.x2.StylePriority.UseFont = false;
            this.x2.Text = "x2";
            // 
            // x3
            // 
            this.x3.Dpi = 100F;
            this.x3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x3.LocationFloat = new DevExpress.Utils.PointFloat(161.2257F, 0F);
            this.x3.Name = "x3";
            this.x3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x3.SizeF = new System.Drawing.SizeF(213.2452F, 23F);
            this.x3.StylePriority.UseFont = false;
            this.x3.Text = "x3";
            // 
            // x4
            // 
            this.x4.Dpi = 100F;
            this.x4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x4.LocationFloat = new DevExpress.Utils.PointFloat(374.4709F, 0F);
            this.x4.Name = "x4";
            this.x4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x4.SizeF = new System.Drawing.SizeF(99.68073F, 23F);
            this.x4.StylePriority.UseFont = false;
            this.x4.Text = "x4";
            // 
            // x5
            // 
            this.x5.Dpi = 100F;
            this.x5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x5.LocationFloat = new DevExpress.Utils.PointFloat(474.2053F, 0F);
            this.x5.Name = "x5";
            this.x5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x5.SizeF = new System.Drawing.SizeF(113.1591F, 23F);
            this.x5.StylePriority.UseFont = false;
            this.x5.Text = "x5";
            // 
            // x6
            // 
            this.x6.Dpi = 100F;
            this.x6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x6.LocationFloat = new DevExpress.Utils.PointFloat(587.3644F, 0F);
            this.x6.Name = "x6";
            this.x6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x6.SizeF = new System.Drawing.SizeF(185.3124F, 23F);
            this.x6.StylePriority.UseFont = false;
            this.x6.Text = "x6";
            // 
            // x7
            // 
            this.x7.Dpi = 100F;
            this.x7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x7.LocationFloat = new DevExpress.Utils.PointFloat(772.6768F, 0F);
            this.x7.Name = "x7";
            this.x7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x7.SizeF = new System.Drawing.SizeF(202.1875F, 23F);
            this.x7.StylePriority.UseFont = false;
            this.x7.Text = "x7";
            // 
            // x8
            // 
            this.x8.Dpi = 100F;
            this.x8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.x8.LocationFloat = new DevExpress.Utils.PointFloat(974.8643F, 0F);
            this.x8.Name = "x8";
            this.x8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x8.SizeF = new System.Drawing.SizeF(116.5308F, 23F);
            this.x8.StylePriority.UseFont = false;
            this.x8.Text = "x8";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(100.2604F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Supervisor: ";
            // 
            // clave
            // 
            this.clave.Dpi = 100F;
            this.clave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.clave.LocationFloat = new DevExpress.Utils.PointFloat(110.2604F, 0F);
            this.clave.Name = "clave";
            this.clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.clave.SizeF = new System.Drawing.SizeF(100.2604F, 23F);
            this.clave.StylePriority.UseFont = false;
            this.clave.Text = "clave";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(210.5208F, 0F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(21.50002F, 23F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "-";
            // 
            // nombre
            // 
            this.nombre.Dpi = 100F;
            this.nombre.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.nombre.LocationFloat = new DevExpress.Utils.PointFloat(231.7604F, 0F);
            this.nombre.Name = "nombre";
            this.nombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nombre.SizeF = new System.Drawing.SizeF(100.2604F, 23F);
            this.nombre.StylePriority.UseFont = false;
            this.nombre.Text = "nombre";
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(59.62632F, 24.6389F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(70.31248F, 23F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.Text = "Vendedor: ";
            // 
            // ven
            // 
            this.ven.Dpi = 100F;
            this.ven.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.ven.LocationFloat = new DevExpress.Utils.PointFloat(161.2257F, 23F);
            this.ven.Name = "ven";
            this.ven.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ven.SizeF = new System.Drawing.SizeF(153.6458F, 23F);
            this.ven.StylePriority.UseFont = false;
            this.ven.Text = "ven";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 49.26039F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(433.8436F, 26.26038F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(44.01041F, 23.00001F);
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "{0:d/MM/yy hh:mm:ss tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(903.3748F, 23.65621F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(140.1044F, 23.00001F);
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(746.5933F, 26.26038F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(131.7814F, 23F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.Text = "Fecha Hora Impresión:";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(407.5415F, 22.99999F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(70.31248F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Ruta:";
            // 
            // ru
            // 
            this.ru.Dpi = 100F;
            this.ru.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.ru.LocationFloat = new DevExpress.Utils.PointFloat(495.4984F, 24.6389F);
            this.ru.Name = "ru";
            this.ru.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ru.SizeF = new System.Drawing.SizeF(111.168F, 23F);
            this.ru.StylePriority.UseFont = false;
            this.ru.Text = "ru";
            // 
            // PlanTrabajoSemanal
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(6, 1, 7, 4);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
