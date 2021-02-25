using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for report_Principal
/// </summary>
public class PrincipalPreventaDetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel36;
    private XRPageInfo xrPageInfo2;
    private GroupFooterBand GroupFooter1;
    private GroupFooterBand GroupFooter2;
    private ReportHeaderBand ReportHeader;
    public XRLabel vendedor;
    private XRLabel xrLabel42;
    private XRLabel xrLabel41;
    private XRLabel xrLabel40;
    private XRLabel xrLabel39;
    public XRLabel ruta;
    public XRLabel centro;
    public XRLabel fentrega;
    public XRSubreport PrinSubPreventa;
    public XRSubreport SubPreventa;
    private GroupFooterBand GroupFooter3;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    public XRLabel lb1;
    public XRLabel lb2;
    public XRLabel lb3;
    public XRLabel lb4;
    public XRLabel lb5;
    public XRLabel lb6;
    public XRLabel lb7;
    public XRLabel lb8;
    public XRLabel lb9;
    public XRLabel lb10;
    public XRLabel lb11;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PrincipalPreventaDetallado()
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
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PrinSubPreventa = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.SubPreventa = new DevExpress.XtraReports.UI.XRSubreport();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.fentrega = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb4 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb6 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb7 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb8 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb9 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb10 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb11 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 21.58339F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 4F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 25F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrLabel36,
            this.xrPageInfo2});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 18.86488F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "{0:dd/MM/yyyy hh:mm:ss tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(900.7427F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(123.8109F, 12.58333F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(740.0233F, 0F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(149.9999F, 12.58333F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UsePadding = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "Fecha Hora Impresión";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "{0} / {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(214.7886F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(312.9999F, 12.58333F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UsePadding = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PrinSubPreventa});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.GroupFooter1.HeightF = 68.83333F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.StylePriority.UseFont = false;
            // 
            // PrinSubPreventa
            // 
            this.PrinSubPreventa.Dpi = 100F;
            this.PrinSubPreventa.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.PrinSubPreventa.Name = "PrinSubPreventa";
            this.PrinSubPreventa.SizeF = new System.Drawing.SizeF(1024.21F, 68.83333F);
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SubPreventa});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.GroupFooter2.HeightF = 70.83334F;
            this.GroupFooter2.Level = 2;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.GroupFooter2.StylePriority.UseFont = false;
            // 
            // SubPreventa
            // 
            this.SubPreventa.Dpi = 100F;
            this.SubPreventa.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.SubPreventa.Name = "SubPreventa";
            this.SubPreventa.SizeF = new System.Drawing.SizeF(1024.21F, 68.83333F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.vendedor,
            this.xrLabel42,
            this.xrLabel41,
            this.xrLabel40,
            this.xrLabel39,
            this.ruta,
            this.centro,
            this.fentrega});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 171.6386F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // vendedor
            // 
            this.vendedor.Dpi = 100F;
            this.vendedor.Font = new System.Drawing.Font("Arial", 9F);
            this.vendedor.LocationFloat = new DevExpress.Utils.PointFloat(164.9447F, 145.6386F);
            this.vendedor.Name = "vendedor";
            this.vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.vendedor.SizeF = new System.Drawing.SizeF(299.5219F, 13F);
            this.vendedor.StylePriority.UseFont = false;
            this.vendedor.StylePriority.UsePadding = false;
            this.vendedor.StylePriority.UseTextAlignment = false;
            this.vendedor.Text = "vendedor";
            this.vendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel42
            // 
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(0F, 132.6386F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UsePadding = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "Fecha";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(0F, 119.6386F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(153.4191F, 13F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UsePadding = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "Centro de Distribución";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(0F, 145.6386F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UsePadding = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "Vendedor";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(0F, 158.6386F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(100F, 13F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UsePadding = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "Ruta";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ruta
            // 
            this.ruta.Dpi = 100F;
            this.ruta.Font = new System.Drawing.Font("Arial", 9F);
            this.ruta.LocationFloat = new DevExpress.Utils.PointFloat(165.1436F, 158.6386F);
            this.ruta.Name = "ruta";
            this.ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ruta.SizeF = new System.Drawing.SizeF(485.4286F, 13F);
            this.ruta.StylePriority.UseFont = false;
            this.ruta.StylePriority.UsePadding = false;
            this.ruta.StylePriority.UseTextAlignment = false;
            this.ruta.Text = "ruta";
            this.ruta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // centro
            // 
            this.centro.Dpi = 100F;
            this.centro.Font = new System.Drawing.Font("Arial", 9F);
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(165.1435F, 119.6386F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(485.4286F, 13F);
            this.centro.StylePriority.UseFont = false;
            this.centro.StylePriority.UsePadding = false;
            this.centro.StylePriority.UseTextAlignment = false;
            this.centro.Text = "centro";
            this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fentrega
            // 
            this.fentrega.Dpi = 100F;
            this.fentrega.Font = new System.Drawing.Font("Arial", 9F);
            this.fentrega.LocationFloat = new DevExpress.Utils.PointFloat(164.9447F, 132.6386F);
            this.fentrega.Name = "fentrega";
            this.fentrega.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.fentrega.SizeF = new System.Drawing.SizeF(299.5219F, 12.99999F);
            this.fentrega.StylePriority.UseFont = false;
            this.fentrega.StylePriority.UsePadding = false;
            this.fentrega.StylePriority.UseTextAlignment = false;
            this.fentrega.Text = "fentrega";
            this.fentrega.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.lb1,
            this.lb2,
            this.lb3,
            this.lb4,
            this.lb5,
            this.lb6,
            this.lb7,
            this.lb8,
            this.lb9,
            this.lb10,
            this.lb11});
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.GroupFooter3.HeightF = 177.0834F;
            this.GroupFooter3.Level = 1;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.StylePriority.UseFont = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(29.57323F, 10.00002F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Clientes Por Frecuencia";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(29.57326F, 32.62502F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Total clientes visitados";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(29.57328F, 55.25002F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Porcentaje de Eficiencia de Visita";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(29.57328F, 77.87502F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Total de Pedidos Efectivos";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(29.57328F, 100.5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Porcentaje de Eficiencia de Ventas vs Visita";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(651.6258F, 10.00002F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Total de Cajas de Preventa del dia";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(651.6258F, 32.62501F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Otras Unidades de Medida";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(651.6257F, 67.2049F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Total de Pedidos Cancelados";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(651.6257F, 89.82989F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Cajas Canceladas";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(651.6258F, 122.9479F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Total de Pedidos Posfechados";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(651.6257F, 145.5729F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(258.5953F, 22.625F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Cajas en Pedidos Posfechados";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lb1
            // 
            this.lb1.Dpi = 100F;
            this.lb1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb1.LocationFloat = new DevExpress.Utils.PointFloat(304.8974F, 8.124986F);
            this.lb1.Name = "lb1";
            this.lb1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb1.StylePriority.UseFont = false;
            this.lb1.Text = "lb1";
            // 
            // lb2
            // 
            this.lb2.Dpi = 100F;
            this.lb2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb2.LocationFloat = new DevExpress.Utils.PointFloat(305.3139F, 31.12499F);
            this.lb2.Name = "lb2";
            this.lb2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb2.StylePriority.UseFont = false;
            this.lb2.Text = "lb2";
            // 
            // lb3
            // 
            this.lb3.Dpi = 100F;
            this.lb3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb3.LocationFloat = new DevExpress.Utils.PointFloat(305.3139F, 54.125F);
            this.lb3.Name = "lb3";
            this.lb3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb3.StylePriority.UseFont = false;
            this.lb3.Text = "lb3";
            // 
            // lb4
            // 
            this.lb4.Dpi = 100F;
            this.lb4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb4.LocationFloat = new DevExpress.Utils.PointFloat(305.3139F, 77.12501F);
            this.lb4.Name = "lb4";
            this.lb4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb4.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb4.StylePriority.UseFont = false;
            this.lb4.Text = "lb4";
            // 
            // lb5
            // 
            this.lb5.Dpi = 100F;
            this.lb5.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb5.LocationFloat = new DevExpress.Utils.PointFloat(305.3139F, 100.125F);
            this.lb5.Name = "lb5";
            this.lb5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb5.StylePriority.UseFont = false;
            this.lb5.Text = "lb5";
            // 
            // lb6
            // 
            this.lb6.Dpi = 100F;
            this.lb6.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb6.LocationFloat = new DevExpress.Utils.PointFloat(920.3157F, 10.00002F);
            this.lb6.Name = "lb6";
            this.lb6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb6.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb6.StylePriority.UseFont = false;
            this.lb6.Text = "lb6";
            // 
            // lb7
            // 
            this.lb7.Dpi = 100F;
            this.lb7.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb7.LocationFloat = new DevExpress.Utils.PointFloat(920.3157F, 33.00002F);
            this.lb7.Name = "lb7";
            this.lb7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb7.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb7.StylePriority.UseFont = false;
            this.lb7.Text = "lb7";
            // 
            // lb8
            // 
            this.lb8.Dpi = 100F;
            this.lb8.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb8.LocationFloat = new DevExpress.Utils.PointFloat(920.3157F, 66.82989F);
            this.lb8.Name = "lb8";
            this.lb8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb8.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb8.StylePriority.UseFont = false;
            this.lb8.Text = "lb8";
            // 
            // lb9
            // 
            this.lb9.Dpi = 100F;
            this.lb9.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb9.LocationFloat = new DevExpress.Utils.PointFloat(920.3157F, 89.82991F);
            this.lb9.Name = "lb9";
            this.lb9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb9.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb9.StylePriority.UseFont = false;
            this.lb9.Text = "lb9";
            // 
            // lb10
            // 
            this.lb10.Dpi = 100F;
            this.lb10.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb10.LocationFloat = new DevExpress.Utils.PointFloat(920.3157F, 122.9479F);
            this.lb10.Name = "lb10";
            this.lb10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb10.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb10.StylePriority.UseFont = false;
            this.lb10.Text = "lb10";
            // 
            // lb11
            // 
            this.lb11.Dpi = 100F;
            this.lb11.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lb11.LocationFloat = new DevExpress.Utils.PointFloat(920.3157F, 145.9479F);
            this.lb11.Name = "lb11";
            this.lb11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lb11.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lb11.StylePriority.UseFont = false;
            this.lb11.Text = "lb11";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(173.5231F, 5.000003F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(350.0231F, 70F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(350.0231F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PrincipalPreventaDetallado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupFooter1,
            this.PageFooter,
            this.GroupFooter2,
            this.ReportHeader,
            this.GroupFooter3});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(35, 8, 4, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
