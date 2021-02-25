using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class ReporteHojaDeLiquidacion : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    public XRLabel freporte;
    public XRLabel ffin;
    public XRLabel finicio;
    public XRLabel fentrega;
    public XRLabel ruta;
    public XRLabel centro;
    private XRLabel xrLabel30;
    private XRLine xrLine3;
    private XRLabel xrLabel4;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRLabel xrLabel2;
    private ReportFooterBand ReportFooter;
    private GroupFooterBand GroupFooter1;
    public XRSubreport sub1;
    public XRLabel ti1;
    private GroupFooterBand GroupFooter2;
    public XRLabel ti2;
    public XRSubreport sub2;
    private GroupFooterBand GroupFooter3;
    public XRLabel ti3;
    public XRSubreport sub3;
    private GroupFooterBand GroupFooter4;
    public XRLabel ti4;
    public XRSubreport sub4;
    private XRLine xrLine4;
    private XRLine xrLine5;
    private XRLine xrLine6;
    private XRLabel xrLabel9;
    private GroupFooterBand GroupFooter5;
    private XRLabel xrLabel17;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    public XRLabel gt9;
    public XRLabel gt1;
    public XRLabel gt2;
    public XRLabel gt4;
    public XRLabel gt3;
    public XRLabel gt6;
    public XRLabel gt5;
    public XRLabel gt8;
    public XRLabel gt7;
    public XRLabel gt10;
    public XRLabel gt11;
    public XRLabel gt12;
    public XRLabel gt13;
    public XRLabel gt14;
    public XRLabel xrLabel10;
    public XRLabel codigo;
    public XRLabel saldo;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    public XRSubreport subayudante;
    private XRLabel xrLabel11;
    public XRLabel imp;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteHojaDeLiquidacion()
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.imp = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.freporte = new DevExpress.XtraReports.UI.XRLabel();
            this.ffin = new DevExpress.XtraReports.UI.XRLabel();
            this.finicio = new DevExpress.XtraReports.UI.XRLabel();
            this.fentrega = new DevExpress.XtraReports.UI.XRLabel();
            this.ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.codigo = new DevExpress.XtraReports.UI.XRLabel();
            this.saldo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.subayudante = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.sub1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.ti1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ti2 = new DevExpress.XtraReports.UI.XRLabel();
            this.sub2 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ti3 = new DevExpress.XtraReports.UI.XRLabel();
            this.sub3 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ti4 = new DevExpress.XtraReports.UI.XRLabel();
            this.sub4 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.gt9 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt2 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt4 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt3 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt6 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt5 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt8 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt7 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt10 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt11 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt12 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt13 = new DevExpress.XtraReports.UI.XRLabel();
            this.gt14 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 13F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.TopMargin.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TopMargin_BeforePrint);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 2.923674F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.xrLabel11,
            this.imp,
            this.xrLabel10,
            this.xrLabel17,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.freporte,
            this.ffin,
            this.finicio,
            this.fentrega,
            this.ruta,
            this.centro,
            this.codigo,
            this.saldo,
            this.xrLabel20,
            this.xrLabel19,
            this.subayudante});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 373.2903F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(482.7979F, 205.4976F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(133.8584F, 22.99997F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.Text = "Impuestos: ";
            // 
            // imp
            // 
            this.imp.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.imp.Dpi = 100F;
            this.imp.LocationFloat = new DevExpress.Utils.PointFloat(617.0561F, 205.4977F);
            this.imp.Name = "imp";
            this.imp.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.imp.SizeF = new System.Drawing.SizeF(128.6309F, 23F);
            this.imp.StylePriority.UseBorders = false;
            this.imp.StylePriority.UseTextAlignment = false;
            this.imp.Text = "imp";
            this.imp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.03846486F, 285.8574F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(389.6786F, 19.11456F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Comisión";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(616.9606F, 150.0903F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(133.1437F, 22.99995F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "E - Producto Maltratado";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(617.0558F, 127.0902F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(112.5753F, 22.99998F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "D - Falla de calidad ";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(617.056F, 104.0901F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(112.5753F, 23.00002F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "C - Bonificación";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(617.0751F, 81.09016F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(133.0292F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "B - Producto caducado";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(617.6037F, 58.09004F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(180.1774F, 21.8424F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "A - Producto en buen estado ";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(4.666726F, 116.9698F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(175.1574F, 21.8426F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.Text = "Centro de Distribución";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.666726F, 138.8122F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(175.1574F, 21.84258F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.Text = "Ruta";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(4.666726F, 185.9699F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(175.1574F, 21.84256F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.Text = "Fecha de Entrega";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(4.666726F, 207.8124F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(175.1574F, 21.84256F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.Text = "Fecha/Hora Inicio de Jornada";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(4.666726F, 229.655F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(175.1574F, 21.84254F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.Text = "Fecha/Hora Fin de Jornada";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(4.666726F, 251.4976F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(175.1574F, 21.84253F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.Text = "Fecha/Hora del reporte";
            // 
            // freporte
            // 
            this.freporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.freporte.Dpi = 100F;
            this.freporte.LocationFloat = new DevExpress.Utils.PointFloat(180.1057F, 251.4975F);
            this.freporte.Name = "freporte";
            this.freporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.freporte.SizeF = new System.Drawing.SizeF(194.3669F, 21.84256F);
            this.freporte.StylePriority.UseBorders = false;
            this.freporte.Text = "freporte";
            // 
            // ffin
            // 
            this.ffin.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ffin.Dpi = 100F;
            this.ffin.LocationFloat = new DevExpress.Utils.PointFloat(181.7668F, 229.655F);
            this.ffin.Name = "ffin";
            this.ffin.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ffin.SizeF = new System.Drawing.SizeF(194.3298F, 21.84254F);
            this.ffin.StylePriority.UseBorders = false;
            this.ffin.Text = "ffin";
            // 
            // finicio
            // 
            this.finicio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.finicio.Dpi = 100F;
            this.finicio.LocationFloat = new DevExpress.Utils.PointFloat(180.1427F, 207.8124F);
            this.finicio.Name = "finicio";
            this.finicio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.finicio.SizeF = new System.Drawing.SizeF(194.3298F, 21.84259F);
            this.finicio.StylePriority.UseBorders = false;
            this.finicio.Text = "finicio";
            // 
            // fentrega
            // 
            this.fentrega.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.fentrega.Dpi = 100F;
            this.fentrega.LocationFloat = new DevExpress.Utils.PointFloat(180.1057F, 185.9699F);
            this.fentrega.Name = "fentrega";
            this.fentrega.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fentrega.SizeF = new System.Drawing.SizeF(194.3668F, 21.84261F);
            this.fentrega.StylePriority.UseBorders = false;
            this.fentrega.Text = "fentrega";
            // 
            // ruta
            // 
            this.ruta.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ruta.Dpi = 100F;
            this.ruta.LocationFloat = new DevExpress.Utils.PointFloat(180.0737F, 138.8123F);
            this.ruta.Name = "ruta";
            this.ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ruta.SizeF = new System.Drawing.SizeF(194.3987F, 21.84235F);
            this.ruta.StylePriority.UseBorders = false;
            this.ruta.Text = "ruta";
            // 
            // centro
            // 
            this.centro.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.centro.Dpi = 100F;
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(180.2069F, 116.9698F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(325.8358F, 21.84239F);
            this.centro.StylePriority.UseBorders = false;
            this.centro.Text = "centro";
            // 
            // codigo
            // 
            this.codigo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.codigo.Dpi = 100F;
            this.codigo.LocationFloat = new DevExpress.Utils.PointFloat(617.056F, 228.4977F);
            this.codigo.Name = "codigo";
            this.codigo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.codigo.SizeF = new System.Drawing.SizeF(128.6309F, 23F);
            this.codigo.StylePriority.UseBorders = false;
            this.codigo.StylePriority.UseTextAlignment = false;
            this.codigo.Text = "codigo";
            this.codigo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // saldo
            // 
            this.saldo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.saldo.Dpi = 100F;
            this.saldo.LocationFloat = new DevExpress.Utils.PointFloat(617.056F, 251.4977F);
            this.saldo.Name = "saldo";
            this.saldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.saldo.SizeF = new System.Drawing.SizeF(128.6309F, 22.99997F);
            this.saldo.StylePriority.UseBorders = false;
            this.saldo.StylePriority.UseTextAlignment = false;
            this.saldo.Text = "saldo";
            this.saldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(482.7979F, 251.4976F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(133.8584F, 22.99997F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.Text = "Saldo Reja: ";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(482.7979F, 228.4976F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(133.8584F, 22.99997F);
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.Text = "Codigo Reja: ";
            // 
            // subayudante
            // 
            this.subayudante.Dpi = 100F;
            this.subayudante.LocationFloat = new DevExpress.Utils.PointFloat(0.01923243F, 304.972F);
            this.subayudante.Name = "subayudante";
            this.subayudante.SizeF = new System.Drawing.SizeF(797.7621F, 65.85443F);
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(563.8455F, 26.94445F);
            this.xrLabel30.Multiline = true;
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(238.8889F, 54.66665F);
            this.xrLabel30.Text = "NOMBRE Y FIRMA \r\nREPRESENTANTE DE LIQUIDACION";
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(564.1266F, 25.78701F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(181.713F, 3.472221F);
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(301.0805F, 9.99999F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(216.8982F, 72.76852F);
            this.xrLabel4.Text = "NOMBRE Y FIRMA \r\nREPRESENTANTE DE VENTAS";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(301.0805F, 26.94445F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(181.713F, 3.472221F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(22.57113F, 25.78701F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(181.713F, 3.472221F);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(22.57113F, 9.99999F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(216.8982F, 72.76852F);
            this.xrLabel2.Text = "NOMBRE Y FIRMA \r\nREPRESENTANTE DE ALMACEN";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLine1,
            this.xrLine2,
            this.xrLabel4,
            this.xrLine3,
            this.xrLabel30});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 97.91663F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub1,
            this.ti1});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 96.4881F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // sub1
            // 
            this.sub1.Dpi = 100F;
            this.sub1.LocationFloat = new DevExpress.Utils.PointFloat(0.4999991F, 39.9479F);
            this.sub1.Name = "sub1";
            this.sub1.SizeF = new System.Drawing.SizeF(274.4792F, 50.05208F);
            // 
            // ti1
            // 
            this.ti1.Dpi = 100F;
            this.ti1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ti1.LocationFloat = new DevExpress.Utils.PointFloat(0.01923243F, 0F);
            this.ti1.Name = "ti1";
            this.ti1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ti1.SizeF = new System.Drawing.SizeF(389.6978F, 39.94791F);
            this.ti1.StylePriority.UseFont = false;
            this.ti1.Text = "I - LIQUIDACION POR CÓDIGO UNIFOODS";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ti2,
            this.sub2});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 80.67124F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // ti2
            // 
            this.ti2.Dpi = 100F;
            this.ti2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ti2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.ti2.Name = "ti2";
            this.ti2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ti2.SizeF = new System.Drawing.SizeF(389.6978F, 39.94791F);
            this.ti2.StylePriority.UseFont = false;
            this.ti2.Text = "II - LIQUIDACION POR CÓDIGO CONSIGNACION";
            // 
            // sub2
            // 
            this.sub2.Dpi = 100F;
            this.sub2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 39.94794F);
            this.sub2.Name = "sub2";
            this.sub2.SizeF = new System.Drawing.SizeF(273.4792F, 40.7233F);
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ti3,
            this.sub3});
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.HeightF = 98.18846F;
            this.GroupFooter3.Level = 3;
            this.GroupFooter3.Name = "GroupFooter3";
            // 
            // ti3
            // 
            this.ti3.Dpi = 100F;
            this.ti3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ti3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.ti3.Name = "ti3";
            this.ti3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ti3.SizeF = new System.Drawing.SizeF(389.6978F, 39.94791F);
            this.ti3.StylePriority.UseFont = false;
            this.ti3.Text = "III - CLIENTES SURTIDOS ";
            // 
            // sub3
            // 
            this.sub3.Dpi = 100F;
            this.sub3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 39.94791F);
            this.sub3.Name = "sub3";
            this.sub3.SizeF = new System.Drawing.SizeF(274.4792F, 50.05208F);
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ti4,
            this.sub4});
            this.GroupFooter4.Dpi = 100F;
            this.GroupFooter4.HeightF = 85.41665F;
            this.GroupFooter4.Level = 4;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // ti4
            // 
            this.ti4.Dpi = 100F;
            this.ti4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ti4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.ti4.Name = "ti4";
            this.ti4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ti4.SizeF = new System.Drawing.SizeF(389.6978F, 39.94791F);
            this.ti4.StylePriority.UseFont = false;
            this.ti4.Text = "IV - RESUMEN GENERAL";
            // 
            // sub4
            // 
            this.sub4.Dpi = 100F;
            this.sub4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.36457F);
            this.sub4.Name = "sub4";
            this.sub4.SizeF = new System.Drawing.SizeF(274.4792F, 50.05208F);
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(5.166658F, 5.111122F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(822.8333F, 13.88889F);
            // 
            // xrLine5
            // 
            this.xrLine5.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLine5.BorderWidth = 3F;
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(5.666653F, 51.1111F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(822.3334F, 13.8889F);
            this.xrLine5.StylePriority.UseBackColor = false;
            this.xrLine5.StylePriority.UseBorderDashStyle = false;
            this.xrLine5.StylePriority.UseBorders = false;
            this.xrLine5.StylePriority.UseBorderWidth = false;
            // 
            // xrLine6
            // 
            this.xrLine6.Dpi = 100F;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(5.166658F, 51.1111F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(822.8333F, 23.00001F);
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(4.666726F, 18.99999F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel9.Text = "GRAN TOTAL ";
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.gt9,
            this.gt1,
            this.gt2,
            this.gt4,
            this.gt3,
            this.gt6,
            this.gt5,
            this.gt8,
            this.gt7,
            this.gt10,
            this.gt11,
            this.gt12,
            this.gt13,
            this.gt14,
            this.xrLine5,
            this.xrLine6,
            this.xrLine4,
            this.xrLabel9});
            this.GroupFooter5.Dpi = 100F;
            this.GroupFooter5.HeightF = 76.00679F;
            this.GroupFooter5.Level = 2;
            this.GroupFooter5.Name = "GroupFooter5";
            // 
            // gt9
            // 
            this.gt9.Dpi = 100F;
            this.gt9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt9.LocationFloat = new DevExpress.Utils.PointFloat(471.4488F, 19F);
            this.gt9.Name = "gt9";
            this.gt9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt9.SizeF = new System.Drawing.SizeF(51.34366F, 28.20833F);
            this.gt9.StylePriority.UseFont = false;
            this.gt9.StylePriority.UseTextAlignment = false;
            this.gt9.Text = "gt9";
            this.gt9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt1
            // 
            this.gt1.Dpi = 100F;
            this.gt1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt1.LocationFloat = new DevExpress.Utils.PointFloat(203.1407F, 19.00001F);
            this.gt1.Name = "gt1";
            this.gt1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt1.SizeF = new System.Drawing.SizeF(34.7733F, 28.20833F);
            this.gt1.StylePriority.UseFont = false;
            this.gt1.StylePriority.UseTextAlignment = false;
            this.gt1.Text = "gt1";
            this.gt1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt2
            // 
            this.gt2.Dpi = 100F;
            this.gt2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt2.LocationFloat = new DevExpress.Utils.PointFloat(238.0092F, 19.00001F);
            this.gt2.Name = "gt2";
            this.gt2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt2.SizeF = new System.Drawing.SizeF(32.24222F, 28.20833F);
            this.gt2.StylePriority.UseFont = false;
            this.gt2.StylePriority.UseTextAlignment = false;
            this.gt2.Text = "gt2";
            this.gt2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt4
            // 
            this.gt4.Dpi = 100F;
            this.gt4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt4.LocationFloat = new DevExpress.Utils.PointFloat(295.2918F, 19.00001F);
            this.gt4.Name = "gt4";
            this.gt4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt4.SizeF = new System.Drawing.SizeF(26.55807F, 28.20833F);
            this.gt4.StylePriority.UseFont = false;
            this.gt4.StylePriority.UseTextAlignment = false;
            this.gt4.Text = "gt4";
            this.gt4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt3
            // 
            this.gt3.Dpi = 100F;
            this.gt3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt3.LocationFloat = new DevExpress.Utils.PointFloat(270.3466F, 19.00001F);
            this.gt3.Name = "gt3";
            this.gt3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt3.SizeF = new System.Drawing.SizeF(24.65952F, 28.20833F);
            this.gt3.StylePriority.UseFont = false;
            this.gt3.StylePriority.UseTextAlignment = false;
            this.gt3.Text = "gt3";
            this.gt3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt6
            // 
            this.gt6.Dpi = 100F;
            this.gt6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt6.LocationFloat = new DevExpress.Utils.PointFloat(350.7004F, 19.00001F);
            this.gt6.Name = "gt6";
            this.gt6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt6.SizeF = new System.Drawing.SizeF(28.60004F, 28.20833F);
            this.gt6.StylePriority.UseFont = false;
            this.gt6.StylePriority.UseTextAlignment = false;
            this.gt6.Text = "gt6";
            this.gt6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt5
            // 
            this.gt5.Dpi = 100F;
            this.gt5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt5.LocationFloat = new DevExpress.Utils.PointFloat(321.9451F, 19.00001F);
            this.gt5.Name = "gt5";
            this.gt5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt5.SizeF = new System.Drawing.SizeF(28.66F, 28.20833F);
            this.gt5.StylePriority.UseFont = false;
            this.gt5.StylePriority.UseTextAlignment = false;
            this.gt5.Text = "gt5";
            this.gt5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt8
            // 
            this.gt8.Dpi = 100F;
            this.gt8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt8.LocationFloat = new DevExpress.Utils.PointFloat(426.7605F, 19F);
            this.gt8.Name = "gt8";
            this.gt8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt8.SizeF = new System.Drawing.SizeF(44.29364F, 28.20833F);
            this.gt8.StylePriority.UseFont = false;
            this.gt8.StylePriority.UseTextAlignment = false;
            this.gt8.Text = "gt8";
            this.gt8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt7
            // 
            this.gt7.Dpi = 100F;
            this.gt7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt7.LocationFloat = new DevExpress.Utils.PointFloat(379.3956F, 19.00001F);
            this.gt7.Multiline = true;
            this.gt7.Name = "gt7";
            this.gt7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt7.SizeF = new System.Drawing.SizeF(47.11688F, 28.20833F);
            this.gt7.StylePriority.UseFont = false;
            this.gt7.StylePriority.UseTextAlignment = false;
            this.gt7.Text = "gt7";
            this.gt7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt10
            // 
            this.gt10.Dpi = 100F;
            this.gt10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt10.LocationFloat = new DevExpress.Utils.PointFloat(522.9453F, 19F);
            this.gt10.Name = "gt10";
            this.gt10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt10.SizeF = new System.Drawing.SizeF(56.26672F, 28.20833F);
            this.gt10.StylePriority.UseFont = false;
            this.gt10.StylePriority.UseTextAlignment = false;
            this.gt10.Text = "gt10";
            this.gt10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt11
            // 
            this.gt11.Dpi = 100F;
            this.gt11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt11.LocationFloat = new DevExpress.Utils.PointFloat(579.3647F, 19F);
            this.gt11.Name = "gt11";
            this.gt11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt11.SizeF = new System.Drawing.SizeF(57.00739F, 28.20833F);
            this.gt11.StylePriority.UseFont = false;
            this.gt11.StylePriority.UseTextAlignment = false;
            this.gt11.Text = "gt11";
            this.gt11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt12
            // 
            this.gt12.Dpi = 100F;
            this.gt12.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt12.LocationFloat = new DevExpress.Utils.PointFloat(636.5249F, 19F);
            this.gt12.Name = "gt12";
            this.gt12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt12.SizeF = new System.Drawing.SizeF(62.33844F, 28.20833F);
            this.gt12.StylePriority.UseFont = false;
            this.gt12.StylePriority.UseTextAlignment = false;
            this.gt12.Text = "gt12";
            this.gt12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt13
            // 
            this.gt13.Dpi = 100F;
            this.gt13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt13.LocationFloat = new DevExpress.Utils.PointFloat(698.9019F, 19.00001F);
            this.gt13.Name = "gt13";
            this.gt13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt13.SizeF = new System.Drawing.SizeF(57.34314F, 28.20833F);
            this.gt13.StylePriority.UseFont = false;
            this.gt13.StylePriority.UseTextAlignment = false;
            this.gt13.Text = "gt13";
            this.gt13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // gt14
            // 
            this.gt14.Dpi = 100F;
            this.gt14.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.gt14.LocationFloat = new DevExpress.Utils.PointFloat(756.3402F, 19.00001F);
            this.gt14.Name = "gt14";
            this.gt14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gt14.SizeF = new System.Drawing.SizeF(71.56458F, 28.20832F);
            this.gt14.StylePriority.UseFont = false;
            this.gt14.StylePriority.UseTextAlignment = false;
            this.gt14.Text = "gt14";
            this.gt14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(13.13135F, 5.000019F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(190.1313F, 70.00002F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(406.6667F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(189.6313F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReporteHojaDeLiquidacion
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.GroupFooter1,
            this.GroupFooter2,
            this.GroupFooter3,
            this.GroupFooter4,
            this.GroupFooter5});
            this.Margins = new System.Drawing.Printing.Margins(12, 0, 13, 3);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
