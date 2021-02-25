using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class InformeClientesVisitaVenta : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel29;
    public XRLabel empresa;
    public XRLabel xrLabel30;
    public XRLabel xrLabel31;
    public XRLabel xrLabel32;
    public XRLabel fecha;
    public XRLabel centro;
    public XRLabel fechaf;
    public XRLabel ruta;
    public XRPictureBox logo1;
    public XRPictureBox logo2;
    public XRLabel xrLabel33;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel21;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel18;
    private XRLabel xrLabel6;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel5;
    private XRLabel xrLabel7;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private GroupHeaderBand GroupHeader1;
    public XRLabel x1;
    public XRLabel x2;
    public XRLabel x3;
    public XRLabel x4;
    public XRLabel x5;
    public XRLabel x6;
    public XRLabel x7;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel38;
    public XRLabel cven;
    public XRLabel cvis;
    public XRLabel rut;
    public XRLabel venom;
    public XRLabel venid;
    public XRLabel subnom;
    public XRLabel subid;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public InformeClientesVisitaVenta()
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
            this.x1 = new DevExpress.XtraReports.UI.XRLabel();
            this.x2 = new DevExpress.XtraReports.UI.XRLabel();
            this.x3 = new DevExpress.XtraReports.UI.XRLabel();
            this.x4 = new DevExpress.XtraReports.UI.XRLabel();
            this.x5 = new DevExpress.XtraReports.UI.XRLabel();
            this.x6 = new DevExpress.XtraReports.UI.XRLabel();
            this.x7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.fechaf = new DevExpress.XtraReports.UI.XRLabel();
            this.ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.logo1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.logo2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cven = new DevExpress.XtraReports.UI.XRLabel();
            this.cvis = new DevExpress.XtraReports.UI.XRLabel();
            this.rut = new DevExpress.XtraReports.UI.XRLabel();
            this.venom = new DevExpress.XtraReports.UI.XRLabel();
            this.venid = new DevExpress.XtraReports.UI.XRLabel();
            this.subnom = new DevExpress.XtraReports.UI.XRLabel();
            this.subid = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.x7});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 14.36297F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // x1
            // 
            this.x1.Dpi = 100F;
            this.x1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1.LocationFloat = new DevExpress.Utils.PointFloat(13.13569F, 0F);
            this.x1.Name = "x1";
            this.x1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x1.SizeF = new System.Drawing.SizeF(68.65277F, 12.5625F);
            this.x1.StylePriority.UseFont = false;
            this.x1.Text = "x1";
            // 
            // x2
            // 
            this.x2.Dpi = 100F;
            this.x2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x2.LocationFloat = new DevExpress.Utils.PointFloat(81.78846F, 0F);
            this.x2.Name = "x2";
            this.x2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x2.SizeF = new System.Drawing.SizeF(70.09072F, 12.5625F);
            this.x2.StylePriority.UseFont = false;
            this.x2.Text = "x2";
            // 
            // x3
            // 
            this.x3.Dpi = 100F;
            this.x3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x3.LocationFloat = new DevExpress.Utils.PointFloat(151.8792F, 0F);
            this.x3.Name = "x3";
            this.x3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x3.SizeF = new System.Drawing.SizeF(92.87741F, 12.5625F);
            this.x3.StylePriority.UseFont = false;
            this.x3.Text = "x3";
            // 
            // x4
            // 
            this.x4.Dpi = 100F;
            this.x4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x4.LocationFloat = new DevExpress.Utils.PointFloat(244.7566F, 0F);
            this.x4.Name = "x4";
            this.x4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x4.SizeF = new System.Drawing.SizeF(120.9738F, 12.5625F);
            this.x4.StylePriority.UseFont = false;
            this.x4.Text = "x4";
            // 
            // x5
            // 
            this.x5.Dpi = 100F;
            this.x5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x5.LocationFloat = new DevExpress.Utils.PointFloat(365.7304F, 0F);
            this.x5.Name = "x5";
            this.x5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x5.SizeF = new System.Drawing.SizeF(302.8382F, 12.5625F);
            this.x5.StylePriority.UseFont = false;
            this.x5.Text = "x5";
            // 
            // x6
            // 
            this.x6.Dpi = 100F;
            this.x6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x6.LocationFloat = new DevExpress.Utils.PointFloat(668.5685F, 0F);
            this.x6.Name = "x6";
            this.x6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x6.SizeF = new System.Drawing.SizeF(335.8167F, 12.5625F);
            this.x6.StylePriority.UseFont = false;
            this.x6.Text = "x6";
            // 
            // x7
            // 
            this.x7.Dpi = 100F;
            this.x7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x7.LocationFloat = new DevExpress.Utils.PointFloat(1004.385F, 0F);
            this.x7.Name = "x7";
            this.x7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.x7.SizeF = new System.Drawing.SizeF(87.61475F, 12.5625F);
            this.x7.StylePriority.UseFont = false;
            this.x7.Text = "x7";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 36F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 5F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.empresa,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel32,
            this.fecha,
            this.centro,
            this.fechaf,
            this.ruta,
            this.logo1,
            this.logo2,
            this.xrLabel33});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 192.8734F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(287.184F, 42.87503F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(568.2083F, 40.99999F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.Text = "Informe de Clientes sin Visita / Sin Venta";
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(288.8299F, 0F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(566.5067F, 42.87501F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.Text = "empresa";
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(393.2007F, 88.77699F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(93.54869F, 23.84722F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.Text = "Fecha Actual";
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(405.4646F, 112.6242F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(69.45139F, 23.84722F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.Text = "CEDI";
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(405.4646F, 136.4714F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(69.45139F, 23.84722F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.Text = "Fecha";
            // 
            // fecha
            // 
            this.fecha.Dpi = 100F;
            this.fecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(486.8049F, 88.77699F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(179.4489F, 23.84722F);
            this.fecha.StylePriority.UseFont = false;
            this.fecha.Text = "fecha";
            // 
            // centro
            // 
            this.centro.Dpi = 100F;
            this.centro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(486.8604F, 112.6242F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(315.8516F, 23.84724F);
            this.centro.StylePriority.UseFont = false;
            this.centro.Text = "centro";
            // 
            // fechaf
            // 
            this.fechaf.Dpi = 100F;
            this.fechaf.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaf.LocationFloat = new DevExpress.Utils.PointFloat(486.8604F, 136.4715F);
            this.fechaf.Name = "fechaf";
            this.fechaf.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechaf.SizeF = new System.Drawing.SizeF(179.3934F, 23.84721F);
            this.fechaf.StylePriority.UseFont = false;
            this.fechaf.Text = "fechaf";
            // 
            // ruta
            // 
            this.ruta.Dpi = 100F;
            this.ruta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruta.LocationFloat = new DevExpress.Utils.PointFloat(486.8049F, 160.3187F);
            this.ruta.Name = "ruta";
            this.ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ruta.SizeF = new System.Drawing.SizeF(341.1527F, 23.84717F);
            this.ruta.StylePriority.UseFont = false;
            this.ruta.Text = "ruta";
            // 
            // logo1
            // 
            this.logo1.Dpi = 100F;
            this.logo1.LocationFloat = new DevExpress.Utils.PointFloat(47.73293F, 0F);
            this.logo1.Name = "logo1";
            this.logo1.SizeF = new System.Drawing.SizeF(159.4739F, 101.9723F);
            // 
            // logo2
            // 
            this.logo2.Dpi = 100F;
            this.logo2.LocationFloat = new DevExpress.Utils.PointFloat(917.6241F, 0F);
            this.logo2.Name = "logo2";
            this.logo2.SizeF = new System.Drawing.SizeF(164.3758F, 101.9723F);
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(405.4646F, 160.3186F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(69.45139F, 23.84722F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.Text = "Ruta";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel21,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel18});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 22.07138F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(81.78846F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(70.09071F, 18.00002F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "Ruta";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(13.13569F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(68.65277F, 18F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "CEDI";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(244.7566F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(120.9738F, 18F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "Cliente";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(365.7304F, 1.015805F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(302.8382F, 18F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "Nombre";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(668.5685F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(335.8167F, 18F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Direccion";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(1004.385F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(87.61475F, 18F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Motivo";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(151.8792F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(92.87741F, 18F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "Dia Visita";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(184.4568F, 15.16663F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(11.2917F, 15.16667F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "-";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(35.24106F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(73.42651F, 15.16667F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Supervisor";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(184.4569F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(11.2917F, 15.16667F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "-";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(35.35215F, 15.16666F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(80F, 15.16664F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Vendedor";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(439.0839F, 15.1667F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(91F, 15.16664F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Clientes Venta";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(35.35215F, 30.3333F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(34F, 14.71529F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "Ruta";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(439.0839F, 31.78002F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(91F, 14.71529F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "Clientes Visita";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cven,
            this.cvis,
            this.rut,
            this.venom,
            this.venid,
            this.subnom,
            this.subid,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel7,
            this.xrLabel5,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel6});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 51.91434F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // cven
            // 
            this.cven.Dpi = 100F;
            this.cven.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.cven.LocationFloat = new DevExpress.Utils.PointFloat(530.0837F, 15.16663F);
            this.cven.Name = "cven";
            this.cven.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cven.SizeF = new System.Drawing.SizeF(91F, 15.16664F);
            this.cven.StylePriority.UseFont = false;
            this.cven.Text = "cven";
            // 
            // cvis
            // 
            this.cvis.Dpi = 100F;
            this.cvis.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.cvis.LocationFloat = new DevExpress.Utils.PointFloat(530.0839F, 31.78002F);
            this.cvis.Name = "cvis";
            this.cvis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cvis.SizeF = new System.Drawing.SizeF(91F, 14.71529F);
            this.cvis.StylePriority.UseFont = false;
            this.cvis.Text = "cvis";
            // 
            // rut
            // 
            this.rut.Dpi = 100F;
            this.rut.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.rut.LocationFloat = new DevExpress.Utils.PointFloat(127.2068F, 30.3333F);
            this.rut.Name = "rut";
            this.rut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rut.SizeF = new System.Drawing.SizeF(34F, 14.71529F);
            this.rut.StylePriority.UseFont = false;
            this.rut.Text = "rut";
            // 
            // venom
            // 
            this.venom.Dpi = 100F;
            this.venom.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.venom.LocationFloat = new DevExpress.Utils.PointFloat(197.1652F, 15.16666F);
            this.venom.Name = "venom";
            this.venom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.venom.SizeF = new System.Drawing.SizeF(161.437F, 15.16664F);
            this.venom.StylePriority.UseFont = false;
            this.venom.Text = "venom";
            // 
            // venid
            // 
            this.venid.Dpi = 100F;
            this.venid.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.venid.LocationFloat = new DevExpress.Utils.PointFloat(127.2068F, 15.16666F);
            this.venid.Name = "venid";
            this.venid.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.venid.SizeF = new System.Drawing.SizeF(68.54173F, 15.16664F);
            this.venid.StylePriority.UseFont = false;
            this.venid.Text = "venid";
            // 
            // subnom
            // 
            this.subnom.Dpi = 100F;
            this.subnom.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.subnom.LocationFloat = new DevExpress.Utils.PointFloat(195.7486F, 0F);
            this.subnom.Name = "subnom";
            this.subnom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subnom.SizeF = new System.Drawing.SizeF(130.7182F, 15.16667F);
            this.subnom.StylePriority.UseFont = false;
            this.subnom.Text = "subnom";
            // 
            // subid
            // 
            this.subid.Dpi = 100F;
            this.subid.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.subid.LocationFloat = new DevExpress.Utils.PointFloat(112.072F, 0F);
            this.subid.Name = "subid";
            this.subid.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subid.SizeF = new System.Drawing.SizeF(83.67654F, 15.16667F);
            this.subid.StylePriority.UseFont = false;
            this.subid.Text = "subid";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1,
            this.xrLabel38});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 29.48722F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "{0} / {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(486.8604F, 6.487186F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(48.05551F, 23F);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Format = "{0:dd/MM/yyyy hh:mm tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(961.0068F, 6.487186F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(120.9931F, 23F);
            // 
            // xrLabel38
            // 
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(775.2197F, 6.487186F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(167.3911F, 23F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "Fecha Hora Impresión:";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // InformeClientesVisitaVenta
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(0, 8, 36, 5);
            this.PageHeight = 850;
            this.PageWidth = 1111;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
