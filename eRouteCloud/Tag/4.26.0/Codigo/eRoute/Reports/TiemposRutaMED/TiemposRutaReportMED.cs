using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

/// <summary>
/// Summary description for TiemposRutaReportMED
/// </summary>
public class TiemposRutaReportMED : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel l13;
    public XRLabel l12;
    public XRLabel l11;
    public XRLabel l10;
    public XRLabel l9;
    public XRLabel l8;
    public XRLabel l7;
    public XRLabel l6;
    public XRLabel l5;
    public XRLabel l4;
    public XRLabel l3;
    public XRLabel l2;
    public XRLabel l1;
    public GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel21;
    public XRLabel fechalabel;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    public GroupHeaderBand GroupHeader4;
    private GroupFooterBand GroupFooter1;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private GroupFooterBand GroupFooter2;
    private GroupFooterBand GroupFooter3;
    public XRLabel rutalabel;
    private XRLabel xrLabel4;
    private XRLabel xrLabel19;
    public XRLabel labelVen;
    private XRLabel xrLabel18;
    public XRLabel CediLabel;
    private XRLabel xrLabel26;
    public XRLabel labelfooter1finrecorrido;
    private GroupFooterBand GroupFooter5;
    public GroupHeaderBand GroupHeader5;
    private XRLabel xrLabel1;
    public XRLabel labeliniciorecorrido;
    public XRLabel labelfooter1VentaTotal;
    private ReportFooterBand ReportFooter;
    public XRLabel xrLabel3;
    public XRSubreport xrSubreport1;
    private GroupFooterBand GroupFooter4;
    public XRLabel totalventasgeneral;
    public XRLabel totalcodigosnoleidos;
    public XRLabel tiempopromedio;
    public XRLabel tiempotransito;
    public XRLabel tiempovisita;
    public XRLabel tiemporecorrido;
    private XRLabel xrLabel2;
    private XRLabel xrLabel36;
    private XRLabel xrLabel35;
    private XRLabel xrLabel28;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    public XRLabel labelca6;
    private XRLabel xrLabel42;
    public XRLabel labelca5;
    private XRLabel xrLabel41;
    public XRLabel labelca4;
    private XRLabel xrLabel40;
    public XRLabel labelca3;
    private XRLabel xrLabel39;
    private XRLabel xrLabel38;
    public XRLabel labelca2;
    public XRLabel labelca1;
    private XRLabel xrLabel37;
    private XRLabel xrLabel30;
    private XRLabel xrLabel46;
    private XRLabel xrLabel52;
    public XRLabel VisitadosSVFP;
    public XRLabel VisitadosFP;
    private XRLabel xrLabel51;
    public XRLabel EfectividadCompraFP;
    private XRLabel xrLabel50;
    private XRLabel xrLabel43;
    public XRLabel EfectividadCompraFNP;
    private XRLabel xrLabel31;
    public XRLabel VisitadosFNP;
    public XRLabel VisitadosSVFNP;
    private XRLabel xrLabel24;
    private XRLabel xrLabel22;
    private XRLabel xrLabel45;
    private XRLabel xrLabel44;
    public XRLabel PresencialesT;
    private XRLabel xrLabel29;
    public XRLabel NoPresencialesT;
    private XRLabel xrLabel12;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    public XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel13;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLine xrLine1;
    private XRLine xrLine2;
    private ReportHeaderBand ReportHeader;
    public XRLabel labelrutasheader;
    public XRLabel labelfechaheader;
    public XRLabel headerlabelcedis;
    public XRLabel xrLabel25;
    private XRLabel xrLabel23;
    private XRLabel xrLabel20;
    public XRLabel empresa;
    public XRLabel reporte;
    public XRPictureBox logo;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public TiemposRutaReportMED()
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
            this.l13 = new DevExpress.XtraReports.UI.XRLabel();
            this.l11 = new DevExpress.XtraReports.UI.XRLabel();
            this.l10 = new DevExpress.XtraReports.UI.XRLabel();
            this.l9 = new DevExpress.XtraReports.UI.XRLabel();
            this.l8 = new DevExpress.XtraReports.UI.XRLabel();
            this.l7 = new DevExpress.XtraReports.UI.XRLabel();
            this.l6 = new DevExpress.XtraReports.UI.XRLabel();
            this.l5 = new DevExpress.XtraReports.UI.XRLabel();
            this.l4 = new DevExpress.XtraReports.UI.XRLabel();
            this.l3 = new DevExpress.XtraReports.UI.XRLabel();
            this.l2 = new DevExpress.XtraReports.UI.XRLabel();
            this.l1 = new DevExpress.XtraReports.UI.XRLabel();
            this.l12 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labeliniciorecorrido = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.fechalabel = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.labelVen = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.rutalabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.CediLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelfooter1VentaTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelfooter1finrecorrido = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.labelca6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelca1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.VisitadosSVFP = new DevExpress.XtraReports.UI.XRLabel();
            this.VisitadosFP = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.EfectividadCompraFP = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.EfectividadCompraFNP = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.VisitadosFNP = new DevExpress.XtraReports.UI.XRLabel();
            this.VisitadosSVFNP = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.PresencialesT = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.NoPresencialesT = new DevExpress.XtraReports.UI.XRLabel();
            this.totalventasgeneral = new DevExpress.XtraReports.UI.XRLabel();
            this.totalcodigosnoleidos = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempopromedio = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempotransito = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempovisita = new DevExpress.XtraReports.UI.XRLabel();
            this.tiemporecorrido = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.labelrutasheader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelfechaheader = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelcedis = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.l13,
            this.l11,
            this.l10,
            this.l9,
            this.l8,
            this.l7,
            this.l6,
            this.l5,
            this.l4,
            this.l3,
            this.l2,
            this.l1,
            this.l12});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 23.29165F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // l13
            // 
            this.l13.Dpi = 100F;
            this.l13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l13.LocationFloat = new DevExpress.Utils.PointFloat(1015.5F, 0F);
            this.l13.Multiline = true;
            this.l13.Name = "l13";
            this.l13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l13.SizeF = new System.Drawing.SizeF(66F, 23F);
            this.l13.StylePriority.UseFont = false;
            this.l13.StylePriority.UseTextAlignment = false;
            this.l13.Text = "Venta\r\nTotal";
            this.l13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // l11
            // 
            this.l11.Dpi = 100F;
            this.l11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l11.LocationFloat = new DevExpress.Utils.PointFloat(895F, 0F);
            this.l11.Multiline = true;
            this.l11.Name = "l11";
            this.l11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l11.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.l11.StylePriority.UseFont = false;
            this.l11.StylePriority.UseTextAlignment = false;
            this.l11.Text = "Surtido";
            this.l11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // l10
            // 
            this.l10.Dpi = 100F;
            this.l10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l10.LocationFloat = new DevExpress.Utils.PointFloat(840F, 0F);
            this.l10.Multiline = true;
            this.l10.Name = "l10";
            this.l10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l10.SizeF = new System.Drawing.SizeF(55F, 23F);
            this.l10.StylePriority.UseFont = false;
            this.l10.StylePriority.UseTextAlignment = false;
            this.l10.Text = "Venta";
            this.l10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // l9
            // 
            this.l9.Dpi = 100F;
            this.l9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l9.LocationFloat = new DevExpress.Utils.PointFloat(785F, 0F);
            this.l9.Multiline = true;
            this.l9.Name = "l9";
            this.l9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l9.SizeF = new System.Drawing.SizeF(55F, 23F);
            this.l9.StylePriority.UseFont = false;
            this.l9.StylePriority.UseTextAlignment = false;
            this.l9.Text = "Tiempo\r\nVisita";
            this.l9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // l8
            // 
            this.l8.Dpi = 100F;
            this.l8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l8.LocationFloat = new DevExpress.Utils.PointFloat(730F, 0F);
            this.l8.Multiline = true;
            this.l8.Name = "l8";
            this.l8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l8.SizeF = new System.Drawing.SizeF(55F, 23F);
            this.l8.StylePriority.UseFont = false;
            this.l8.StylePriority.UseTextAlignment = false;
            this.l8.Text = "Hora\r\nFinal";
            this.l8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // l7
            // 
            this.l7.Dpi = 100F;
            this.l7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l7.LocationFloat = new DevExpress.Utils.PointFloat(680F, 0F);
            this.l7.Multiline = true;
            this.l7.Name = "l7";
            this.l7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l7.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.l7.StylePriority.UseFont = false;
            this.l7.StylePriority.UseTextAlignment = false;
            this.l7.Text = "Hora\r\nInicial";
            this.l7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // l6
            // 
            this.l6.Dpi = 100F;
            this.l6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l6.LocationFloat = new DevExpress.Utils.PointFloat(615F, 0F);
            this.l6.Multiline = true;
            this.l6.Name = "l6";
            this.l6.NullValueText = " ";
            this.l6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l6.SizeF = new System.Drawing.SizeF(65F, 23F);
            this.l6.StylePriority.UseFont = false;
            this.l6.Text = "Tiempo\r\nTransito";
            // 
            // l5
            // 
            this.l5.Dpi = 100F;
            this.l5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l5.LocationFloat = new DevExpress.Utils.PointFloat(555F, 0F);
            this.l5.Multiline = true;
            this.l5.Name = "l5";
            this.l5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l5.SizeF = new System.Drawing.SizeF(60F, 23F);
            this.l5.StylePriority.UseFont = false;
            this.l5.StylePriority.UseTextAlignment = false;
            this.l5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // l4
            // 
            this.l4.Dpi = 100F;
            this.l4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l4.LocationFloat = new DevExpress.Utils.PointFloat(360F, 0F);
            this.l4.Multiline = true;
            this.l4.Name = "l4";
            this.l4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l4.SizeF = new System.Drawing.SizeF(195F, 23F);
            this.l4.StylePriority.UseFont = false;
            this.l4.Text = "Localidad y población";
            // 
            // l3
            // 
            this.l3.Dpi = 100F;
            this.l3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l3.LocationFloat = new DevExpress.Utils.PointFloat(115F, 0F);
            this.l3.Name = "l3";
            this.l3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l3.SizeF = new System.Drawing.SizeF(245F, 23F);
            this.l3.StylePriority.UseFont = false;
            this.l3.Text = "Cliente";
            // 
            // l2
            // 
            this.l2.Dpi = 100F;
            this.l2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l2.LocationFloat = new DevExpress.Utils.PointFloat(60F, 0F);
            this.l2.Name = "l2";
            this.l2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l2.SizeF = new System.Drawing.SizeF(55F, 23F);
            this.l2.StylePriority.UseFont = false;
            this.l2.StylePriority.UseTextAlignment = false;
            this.l2.Text = "Clave";
            this.l2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // l1
            // 
            this.l1.Dpi = 100F;
            this.l1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.l1.Name = "l1";
            this.l1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l1.SizeF = new System.Drawing.SizeF(60F, 23F);
            this.l1.StylePriority.UseFont = false;
            this.l1.Text = "Secuencia";
            // 
            // l12
            // 
            this.l12.Dpi = 100F;
            this.l12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l12.LocationFloat = new DevExpress.Utils.PointFloat(945F, 0F);
            this.l12.Multiline = true;
            this.l12.Name = "l12";
            this.l12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.l12.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.l12.StylePriority.UseFont = false;
            this.l12.StylePriority.UseTextAlignment = false;
            this.l12.Text = "Concepto";
            this.l12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(93.50003F, 38.5F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(695.9999F, 38.50002F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.labeliniciorecorrido,
            this.xrLabel21,
            this.fechalabel});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 47.66668F;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(2.416642F, 24.66666F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(158.3333F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Inicio de recorrido";
            // 
            // labeliniciorecorrido
            // 
            this.labeliniciorecorrido.Dpi = 100F;
            this.labeliniciorecorrido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeliniciorecorrido.LocationFloat = new DevExpress.Utils.PointFloat(160.7499F, 24.66666F);
            this.labeliniciorecorrido.Multiline = true;
            this.labeliniciorecorrido.Name = "labeliniciorecorrido";
            this.labeliniciorecorrido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labeliniciorecorrido.SizeF = new System.Drawing.SizeF(158.3333F, 23F);
            this.labeliniciorecorrido.StylePriority.UseFont = false;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(46.1264F, 1.666673F);
            this.xrLabel21.Multiline = true;
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(138.4166F, 23F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "Fecha";
            // 
            // fechalabel
            // 
            this.fechalabel.Dpi = 100F;
            this.fechalabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechalabel.LocationFloat = new DevExpress.Utils.PointFloat(203.7305F, 1.666673F);
            this.fechalabel.Multiline = true;
            this.fechalabel.Name = "fechalabel";
            this.fechalabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechalabel.SizeF = new System.Drawing.SizeF(580.9794F, 23F);
            this.fechalabel.StylePriority.UseFont = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelVen,
            this.xrLabel19});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 23F;
            this.GroupHeader2.Level = 3;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // labelVen
            // 
            this.labelVen.Dpi = 100F;
            this.labelVen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVen.LocationFloat = new DevExpress.Utils.PointFloat(234.9375F, 0F);
            this.labelVen.Multiline = true;
            this.labelVen.Name = "labelVen";
            this.labelVen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelVen.SizeF = new System.Drawing.SizeF(580.9792F, 23F);
            this.labelVen.StylePriority.UseFont = false;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(30.4999F, 0F);
            this.xrLabel19.Multiline = true;
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(158.3333F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Vendedor";
            // 
            // rutalabel
            // 
            this.rutalabel.Dpi = 100F;
            this.rutalabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutalabel.LocationFloat = new DevExpress.Utils.PointFloat(214.9804F, 0F);
            this.rutalabel.Multiline = true;
            this.rutalabel.Name = "rutalabel";
            this.rutalabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rutalabel.SizeF = new System.Drawing.SizeF(580.9794F, 23F);
            this.rutalabel.StylePriority.UseFont = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(37.45963F, 0F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(158.3333F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Ruta";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CediLabel,
            this.xrLabel18});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 23F;
            this.GroupHeader3.Level = 4;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // CediLabel
            // 
            this.CediLabel.Dpi = 100F;
            this.CediLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CediLabel.LocationFloat = new DevExpress.Utils.PointFloat(234.9375F, 0F);
            this.CediLabel.Name = "CediLabel";
            this.CediLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CediLabel.SizeF = new System.Drawing.SizeF(580.9792F, 23F);
            this.CediLabel.StylePriority.UseFont = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(4.916573F, 0F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(158.3333F, 23F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "Centro de distribución";
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.rutalabel,
            this.xrLabel4});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 23F;
            this.GroupHeader4.Level = 2;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelfooter1VentaTotal,
            this.xrLabel26,
            this.labelfooter1finrecorrido});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 37.58335F;
            this.GroupFooter1.Level = 1;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // labelfooter1VentaTotal
            // 
            this.labelfooter1VentaTotal.Dpi = 100F;
            this.labelfooter1VentaTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfooter1VentaTotal.LocationFloat = new DevExpress.Utils.PointFloat(996.8751F, 0F);
            this.labelfooter1VentaTotal.Multiline = true;
            this.labelfooter1VentaTotal.Name = "labelfooter1VentaTotal";
            this.labelfooter1VentaTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelfooter1VentaTotal.SizeF = new System.Drawing.SizeF(84.62494F, 23F);
            this.labelfooter1VentaTotal.StylePriority.UseFont = false;
            this.labelfooter1VentaTotal.StylePriority.UseTextAlignment = false;
            this.labelfooter1VentaTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel26.Multiline = true;
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(158.3333F, 23F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.Text = "Fin de Recorrido";
            // 
            // labelfooter1finrecorrido
            // 
            this.labelfooter1finrecorrido.Dpi = 100F;
            this.labelfooter1finrecorrido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfooter1finrecorrido.LocationFloat = new DevExpress.Utils.PointFloat(721.1249F, 0F);
            this.labelfooter1finrecorrido.Multiline = true;
            this.labelfooter1finrecorrido.Name = "labelfooter1finrecorrido";
            this.labelfooter1finrecorrido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelfooter1finrecorrido.SizeF = new System.Drawing.SizeF(63.87506F, 23F);
            this.labelfooter1finrecorrido.StylePriority.UseFont = false;
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.CanShrink = true;
            this.xrSubreport1.Dpi = 100F;
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0.9997686F, 51.54177F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(371.2659F, 83.33333F);
            this.xrSubreport1.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 0F;
            this.GroupFooter2.Level = 3;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.HeightF = 0F;
            this.GroupFooter3.Level = 4;
            this.GroupFooter3.Name = "GroupFooter3";
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Dpi = 100F;
            this.GroupFooter5.HeightF = 0F;
            this.GroupFooter5.Name = "GroupFooter5";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel13,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLine1,
            this.xrLine2});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 86.00004F;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrSubreport1});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 147.9167F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0.9997686F, 9.999974F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(196.2513F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "REPORTE DE KILOMETRAJE";
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelca6,
            this.xrLabel42,
            this.labelca5,
            this.xrLabel41,
            this.labelca4,
            this.xrLabel40,
            this.labelca3,
            this.xrLabel39,
            this.xrLabel38,
            this.labelca2,
            this.labelca1,
            this.xrLabel37,
            this.xrLabel30,
            this.xrLabel46,
            this.xrLabel52,
            this.VisitadosSVFP,
            this.VisitadosFP,
            this.xrLabel51,
            this.EfectividadCompraFP,
            this.xrLabel50,
            this.xrLabel43,
            this.EfectividadCompraFNP,
            this.xrLabel31,
            this.VisitadosFNP,
            this.VisitadosSVFNP,
            this.xrLabel24,
            this.xrLabel22,
            this.xrLabel45,
            this.xrLabel44,
            this.PresencialesT,
            this.xrLabel29,
            this.NoPresencialesT,
            this.totalventasgeneral,
            this.totalcodigosnoleidos,
            this.tiempopromedio,
            this.tiempotransito,
            this.tiempovisita,
            this.tiemporecorrido,
            this.xrLabel2,
            this.xrLabel36,
            this.xrLabel35,
            this.xrLabel28,
            this.xrLabel33,
            this.xrLabel34});
            this.GroupFooter4.Dpi = 100F;
            this.GroupFooter4.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter4.HeightF = 222.3335F;
            this.GroupFooter4.Level = 2;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // labelca6
            // 
            this.labelca6.Dpi = 100F;
            this.labelca6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca6.LocationFloat = new DevExpress.Utils.PointFloat(297.9999F, 133.375F);
            this.labelca6.Multiline = true;
            this.labelca6.Name = "labelca6";
            this.labelca6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca6.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.labelca6.StylePriority.UseFont = false;
            // 
            // xrLabel42
            // 
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(186F, 133.375F);
            this.xrLabel42.Multiline = true;
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.Text = "Efectividad Compra";
            // 
            // labelca5
            // 
            this.labelca5.Dpi = 100F;
            this.labelca5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca5.LocationFloat = new DevExpress.Utils.PointFloat(297.9999F, 110.375F);
            this.labelca5.Multiline = true;
            this.labelca5.Name = "labelca5";
            this.labelca5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca5.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.labelca5.StylePriority.UseFont = false;
            // 
            // xrLabel41
            // 
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(186F, 110.375F);
            this.xrLabel41.Multiline = true;
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.Text = "Visitas sin Venta";
            // 
            // labelca4
            // 
            this.labelca4.Dpi = 100F;
            this.labelca4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca4.LocationFloat = new DevExpress.Utils.PointFloat(297.9999F, 87.37501F);
            this.labelca4.Multiline = true;
            this.labelca4.Name = "labelca4";
            this.labelca4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca4.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.labelca4.StylePriority.UseFont = false;
            // 
            // xrLabel40
            // 
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(186F, 87.37501F);
            this.xrLabel40.Multiline = true;
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.Text = "Visita Efectiva";
            // 
            // labelca3
            // 
            this.labelca3.Dpi = 100F;
            this.labelca3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca3.LocationFloat = new DevExpress.Utils.PointFloat(108F, 133.375F);
            this.labelca3.Multiline = true;
            this.labelca3.Name = "labelca3";
            this.labelca3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca3.SizeF = new System.Drawing.SizeF(67F, 23F);
            this.labelca3.StylePriority.UseFont = false;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(0F, 133.375F);
            this.xrLabel39.Multiline = true;
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(108F, 23F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.Text = "Total Clientes";
            // 
            // xrLabel38
            // 
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110.375F);
            this.xrLabel38.Multiline = true;
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(108F, 23F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.Text = "No Visitados";
            // 
            // labelca2
            // 
            this.labelca2.Dpi = 100F;
            this.labelca2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca2.LocationFloat = new DevExpress.Utils.PointFloat(108F, 110.375F);
            this.labelca2.Multiline = true;
            this.labelca2.Name = "labelca2";
            this.labelca2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca2.SizeF = new System.Drawing.SizeF(67F, 23F);
            this.labelca2.StylePriority.UseFont = false;
            // 
            // labelca1
            // 
            this.labelca1.Dpi = 100F;
            this.labelca1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelca1.LocationFloat = new DevExpress.Utils.PointFloat(108F, 87.37501F);
            this.labelca1.Multiline = true;
            this.labelca1.Name = "labelca1";
            this.labelca1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelca1.SizeF = new System.Drawing.SizeF(67F, 23F);
            this.labelca1.StylePriority.UseFont = false;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.37501F);
            this.xrLabel37.Multiline = true;
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(108F, 23F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.Text = "Visitados";
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.375F);
            this.xrLabel30.Multiline = true;
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(410F, 25F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.Text = "Clientes en Agenda";
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(469.9998F, 62.375F);
            this.xrLabel46.Multiline = true;
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(250F, 25F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.Text = "Clientes Fuera de la Frecuencia Presencial";
            // 
            // xrLabel52
            // 
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(469.9998F, 110.375F);
            this.xrLabel52.Multiline = true;
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.Text = "Visitados sin Venta";
            // 
            // VisitadosSVFP
            // 
            this.VisitadosSVFP.Dpi = 100F;
            this.VisitadosSVFP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitadosSVFP.LocationFloat = new DevExpress.Utils.PointFloat(581.9998F, 110.375F);
            this.VisitadosSVFP.Multiline = true;
            this.VisitadosSVFP.Name = "VisitadosSVFP";
            this.VisitadosSVFP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VisitadosSVFP.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.VisitadosSVFP.StylePriority.UseFont = false;
            // 
            // VisitadosFP
            // 
            this.VisitadosFP.Dpi = 100F;
            this.VisitadosFP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitadosFP.LocationFloat = new DevExpress.Utils.PointFloat(581.9998F, 87.37501F);
            this.VisitadosFP.Multiline = true;
            this.VisitadosFP.Name = "VisitadosFP";
            this.VisitadosFP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VisitadosFP.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.VisitadosFP.StylePriority.UseFont = false;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Dpi = 100F;
            this.xrLabel51.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(469.9998F, 133.375F);
            this.xrLabel51.Multiline = true;
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.Text = "Efectividad Compra";
            // 
            // EfectividadCompraFP
            // 
            this.EfectividadCompraFP.Dpi = 100F;
            this.EfectividadCompraFP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EfectividadCompraFP.LocationFloat = new DevExpress.Utils.PointFloat(581.9998F, 133.375F);
            this.EfectividadCompraFP.Multiline = true;
            this.EfectividadCompraFP.Name = "EfectividadCompraFP";
            this.EfectividadCompraFP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EfectividadCompraFP.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.EfectividadCompraFP.StylePriority.UseFont = false;
            // 
            // xrLabel50
            // 
            this.xrLabel50.Dpi = 100F;
            this.xrLabel50.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(469.9998F, 87.37501F);
            this.xrLabel50.Multiline = true;
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.Text = "Visitados";
            // 
            // xrLabel43
            // 
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(784.9999F, 87.37501F);
            this.xrLabel43.Multiline = true;
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.Text = "Visitados";
            // 
            // EfectividadCompraFNP
            // 
            this.EfectividadCompraFNP.Dpi = 100F;
            this.EfectividadCompraFNP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EfectividadCompraFNP.LocationFloat = new DevExpress.Utils.PointFloat(896.9999F, 133.375F);
            this.EfectividadCompraFNP.Multiline = true;
            this.EfectividadCompraFNP.Name = "EfectividadCompraFNP";
            this.EfectividadCompraFNP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EfectividadCompraFNP.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.EfectividadCompraFNP.StylePriority.UseFont = false;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(784.9999F, 133.375F);
            this.xrLabel31.Multiline = true;
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.Text = "Efectividad Compra";
            // 
            // VisitadosFNP
            // 
            this.VisitadosFNP.Dpi = 100F;
            this.VisitadosFNP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitadosFNP.LocationFloat = new DevExpress.Utils.PointFloat(896.9999F, 87.37501F);
            this.VisitadosFNP.Multiline = true;
            this.VisitadosFNP.Name = "VisitadosFNP";
            this.VisitadosFNP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VisitadosFNP.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.VisitadosFNP.StylePriority.UseFont = false;
            // 
            // VisitadosSVFNP
            // 
            this.VisitadosSVFNP.Dpi = 100F;
            this.VisitadosSVFNP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitadosSVFNP.LocationFloat = new DevExpress.Utils.PointFloat(896.9999F, 110.375F);
            this.VisitadosSVFNP.Multiline = true;
            this.VisitadosSVFNP.Name = "VisitadosSVFNP";
            this.VisitadosSVFNP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VisitadosSVFNP.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.VisitadosSVFNP.StylePriority.UseFont = false;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(784.9999F, 110.375F);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Visitados sin Venta";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(784.9999F, 62.375F);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(260F, 25F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.Text = "Clientes Fuera de la Frecuencia No Presencial";
            // 
            // xrLabel45
            // 
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(0F, 174.3335F);
            this.xrLabel45.Multiline = true;
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(410F, 25F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.Text = "Transfer";
            // 
            // xrLabel44
            // 
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(0F, 199.3335F);
            this.xrLabel44.Multiline = true;
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(108F, 23F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.Text = "Presenciales";
            // 
            // PresencialesT
            // 
            this.PresencialesT.Dpi = 100F;
            this.PresencialesT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresencialesT.LocationFloat = new DevExpress.Utils.PointFloat(107.9999F, 199.3335F);
            this.PresencialesT.Multiline = true;
            this.PresencialesT.Name = "PresencialesT";
            this.PresencialesT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PresencialesT.SizeF = new System.Drawing.SizeF(67F, 23F);
            this.PresencialesT.StylePriority.UseFont = false;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(185.9999F, 199.3335F);
            this.xrLabel29.Multiline = true;
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.Text = "No Presenciales";
            // 
            // NoPresencialesT
            // 
            this.NoPresencialesT.Dpi = 100F;
            this.NoPresencialesT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoPresencialesT.LocationFloat = new DevExpress.Utils.PointFloat(297.9998F, 199.3335F);
            this.NoPresencialesT.Multiline = true;
            this.NoPresencialesT.Name = "NoPresencialesT";
            this.NoPresencialesT.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NoPresencialesT.SizeF = new System.Drawing.SizeF(112F, 23F);
            this.NoPresencialesT.StylePriority.UseFont = false;
            // 
            // totalventasgeneral
            // 
            this.totalventasgeneral.Dpi = 100F;
            this.totalventasgeneral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalventasgeneral.LocationFloat = new DevExpress.Utils.PointFloat(635F, 22.99999F);
            this.totalventasgeneral.Multiline = true;
            this.totalventasgeneral.Name = "totalventasgeneral";
            this.totalventasgeneral.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalventasgeneral.SizeF = new System.Drawing.SizeF(98F, 23F);
            this.totalventasgeneral.StylePriority.UseFont = false;
            // 
            // totalcodigosnoleidos
            // 
            this.totalcodigosnoleidos.Dpi = 100F;
            this.totalcodigosnoleidos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalcodigosnoleidos.LocationFloat = new DevExpress.Utils.PointFloat(635F, 0F);
            this.totalcodigosnoleidos.Multiline = true;
            this.totalcodigosnoleidos.Name = "totalcodigosnoleidos";
            this.totalcodigosnoleidos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalcodigosnoleidos.SizeF = new System.Drawing.SizeF(98F, 23F);
            this.totalcodigosnoleidos.StylePriority.UseFont = false;
            // 
            // tiempopromedio
            // 
            this.tiempopromedio.Dpi = 100F;
            this.tiempopromedio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempopromedio.LocationFloat = new DevExpress.Utils.PointFloat(352F, 22.99999F);
            this.tiempopromedio.Multiline = true;
            this.tiempopromedio.Name = "tiempopromedio";
            this.tiempopromedio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempopromedio.SizeF = new System.Drawing.SizeF(98F, 23F);
            this.tiempopromedio.StylePriority.UseFont = false;
            // 
            // tiempotransito
            // 
            this.tiempotransito.Dpi = 100F;
            this.tiempotransito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempotransito.LocationFloat = new DevExpress.Utils.PointFloat(352F, 0F);
            this.tiempotransito.Multiline = true;
            this.tiempotransito.Name = "tiempotransito";
            this.tiempotransito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempotransito.SizeF = new System.Drawing.SizeF(98F, 23F);
            this.tiempotransito.StylePriority.UseFont = false;
            // 
            // tiempovisita
            // 
            this.tiempovisita.Dpi = 100F;
            this.tiempovisita.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempovisita.LocationFloat = new DevExpress.Utils.PointFloat(140F, 22.99999F);
            this.tiempovisita.Multiline = true;
            this.tiempovisita.Name = "tiempovisita";
            this.tiempovisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempovisita.SizeF = new System.Drawing.SizeF(98F, 23F);
            this.tiempovisita.StylePriority.UseFont = false;
            // 
            // tiemporecorrido
            // 
            this.tiemporecorrido.Dpi = 100F;
            this.tiemporecorrido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiemporecorrido.LocationFloat = new DevExpress.Utils.PointFloat(140F, 0F);
            this.tiemporecorrido.Multiline = true;
            this.tiemporecorrido.Name = "tiemporecorrido";
            this.tiemporecorrido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiemporecorrido.SizeF = new System.Drawing.SizeF(98F, 23F);
            this.tiemporecorrido.StylePriority.UseFont = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "TIempo Recorrido";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(495F, 23F);
            this.xrLabel36.Multiline = true;
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.Text = "Total de Ventas General";
            // 
            // xrLabel35
            // 
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(495F, 0F);
            this.xrLabel35.Multiline = true;
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel35.StylePriority.UseFont = false;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
            this.xrLabel28.Multiline = true;
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(140F, 23F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.Text = "Tiempo Visita";
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(257F, 0F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(95F, 23F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.Text = "Tiempo Transito";
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(257F, 23F);
            this.xrLabel34.Multiline = true;
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(95F, 23F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.Text = "Tiempo Promedio";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelrutasheader,
            this.labelfechaheader,
            this.headerlabelcedis,
            this.xrLabel25,
            this.xrLabel23,
            this.xrLabel20,
            this.empresa,
            this.reporte,
            this.logo});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 194F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // labelrutasheader
            // 
            this.labelrutasheader.CanGrow = false;
            this.labelrutasheader.Dpi = 100F;
            this.labelrutasheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrutasheader.LocationFloat = new DevExpress.Utils.PointFloat(150.25F, 171F);
            this.labelrutasheader.Name = "labelrutasheader";
            this.labelrutasheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelrutasheader.SizeF = new System.Drawing.SizeF(931.5F, 23F);
            this.labelrutasheader.StylePriority.UseFont = false;
            // 
            // labelfechaheader
            // 
            this.labelfechaheader.Dpi = 100F;
            this.labelfechaheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfechaheader.LocationFloat = new DevExpress.Utils.PointFloat(150.25F, 148F);
            this.labelfechaheader.Name = "labelfechaheader";
            this.labelfechaheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelfechaheader.SizeF = new System.Drawing.SizeF(931.5F, 23F);
            this.labelfechaheader.StylePriority.UseFont = false;
            // 
            // headerlabelcedis
            // 
            this.headerlabelcedis.Dpi = 100F;
            this.headerlabelcedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelcedis.LocationFloat = new DevExpress.Utils.PointFloat(150.25F, 125F);
            this.headerlabelcedis.Name = "headerlabelcedis";
            this.headerlabelcedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelcedis.SizeF = new System.Drawing.SizeF(931.5F, 23F);
            this.headerlabelcedis.StylePriority.UseFont = false;
            // 
            // xrLabel25
            // 
            this.xrLabel25.CanGrow = false;
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(0.25F, 171F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Rutas";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0.25F, 148F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Fecha";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0.25F, 125F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Centro de Distribución";
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(257.25F, 10F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(573F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(257.25F, 55F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(573F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(0.25F, 0F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(1016.5F, 22.99999F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(65.00031F, 40F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Venta\r\nTotal";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(555.9997F, 23F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(60F, 40F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Presencial";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(615.9997F, 23F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(65F, 40F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Tiempo\r\nTransito";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(680.9997F, 23F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(50F, 40F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Hora\r\nInicial";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(785.9997F, 23F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(55F, 40F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Tiempo\r\nVisita";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(840.9997F, 23F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(55F, 40F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Venta";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(895.9997F, 23F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(50F, 40F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Surtido";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(945.9997F, 23F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(70F, 40F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Concepto";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(730.9997F, 23F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(55F, 40F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Hora\r\nFinal";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(360.9997F, 23F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(195F, 40F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Localidad y población";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(115.9997F, 23F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(245F, 40F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Cliente";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(60.99963F, 23F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(55F, 40F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Clave";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0.9996225F, 23F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(60F, 40F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Secuencia";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.4998779F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1081F, 23F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0.4998779F, 63F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1081F, 23.00004F);
            // 
            // TiemposRutaReportMED
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.GroupFooter1,
            this.GroupFooter2,
            this.GroupFooter3,
            this.GroupFooter4,
            this.GroupFooter5,
            this.GroupHeader5,
            this.ReportFooter,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 6, 20, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.ReportPrintOptions.PrintOnEmptyDataSource = false;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void xrLabel22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }

    private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }

    private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }

    private void xrLabel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
