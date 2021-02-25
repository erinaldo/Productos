using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosGPS
/// </summary>
public class ReporteEfectividadVisitaRIP : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRPictureBox xrPictureBox1;
    private XRLabel xrLabel27;
    private XRLine xrLine1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    public XRLabel labelfechaheader;
    public XRLabel headerlabelcedis;
    private XRLabel xrLabel23;
    private XRLabel xrLabel20;
    public XRLabel detalleRuta;
    public XRLabel detalleVisitaProgramada;
    public XRLabel detalleVisitasEfectuadas;
    public XRLabel detalleEfectividadVisitas;
    public XRLabel detalleFueraRuta;
    public XRLabel detalleEfectividadTotal;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private XRLine xrLine2;
    public ReportHeaderBand ReportHeader;
    public XRLabel headerCedi;
    public XRLabel headerVisitaProgramada;
    public XRLabel headerVisitaEfectuada;
    public XRLabel headerEfectividadVisitas;
    public XRLabel headerFueraRuta;
    public XRLabel headerEfectividadTotal;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteEfectividadVisitaRIP()
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
            this.detalleRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleVisitaProgramada = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleVisitasEfectuadas = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleEfectividadVisitas = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleFueraRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleEfectividadTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelfechaheader = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelcedis = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.headerCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVisitaProgramada = new DevExpress.XtraReports.UI.XRLabel();
            this.headerVisitaEfectuada = new DevExpress.XtraReports.UI.XRLabel();
            this.headerEfectividadVisitas = new DevExpress.XtraReports.UI.XRLabel();
            this.headerFueraRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.headerEfectividadTotal = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.detalleRuta,
            this.detalleVisitaProgramada,
            this.detalleVisitasEfectuadas,
            this.detalleEfectividadVisitas,
            this.detalleFueraRuta,
            this.detalleEfectividadTotal});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 13.58337F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // detalleRuta
            // 
            this.detalleRuta.Dpi = 100F;
            this.detalleRuta.LocationFloat = new DevExpress.Utils.PointFloat(1.729202F, 0F);
            this.detalleRuta.Name = "detalleRuta";
            this.detalleRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleRuta.SizeF = new System.Drawing.SizeF(306.7288F, 12.87501F);
            this.detalleRuta.StylePriority.UseFont = false;
            this.detalleRuta.StylePriority.UseForeColor = false;
            this.detalleRuta.Text = "Ruta";
            // 
            // detalleVisitaProgramada
            // 
            this.detalleVisitaProgramada.Dpi = 100F;
            this.detalleVisitaProgramada.LocationFloat = new DevExpress.Utils.PointFloat(308.4579F, 0F);
            this.detalleVisitaProgramada.Name = "detalleVisitaProgramada";
            this.detalleVisitaProgramada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleVisitaProgramada.SizeF = new System.Drawing.SizeF(93.45844F, 12.87501F);
            this.detalleVisitaProgramada.StylePriority.UseFont = false;
            this.detalleVisitaProgramada.StylePriority.UseTextAlignment = false;
            this.detalleVisitaProgramada.Text = "Programada";
            this.detalleVisitaProgramada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleVisitasEfectuadas
            // 
            this.detalleVisitasEfectuadas.Dpi = 100F;
            this.detalleVisitasEfectuadas.LocationFloat = new DevExpress.Utils.PointFloat(433.4844F, 0F);
            this.detalleVisitasEfectuadas.Multiline = true;
            this.detalleVisitasEfectuadas.Name = "detalleVisitasEfectuadas";
            this.detalleVisitasEfectuadas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleVisitasEfectuadas.SizeF = new System.Drawing.SizeF(76.45377F, 12.87501F);
            this.detalleVisitasEfectuadas.StylePriority.UseFont = false;
            this.detalleVisitasEfectuadas.StylePriority.UseTextAlignment = false;
            this.detalleVisitasEfectuadas.Text = "Efectuadas";
            this.detalleVisitasEfectuadas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleEfectividadVisitas
            // 
            this.detalleEfectividadVisitas.Dpi = 100F;
            this.detalleEfectividadVisitas.LocationFloat = new DevExpress.Utils.PointFloat(539.5719F, 0F);
            this.detalleEfectividadVisitas.Multiline = true;
            this.detalleEfectividadVisitas.Name = "detalleEfectividadVisitas";
            this.detalleEfectividadVisitas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleEfectividadVisitas.SizeF = new System.Drawing.SizeF(80.0838F, 12.87501F);
            this.detalleEfectividadVisitas.StylePriority.UseFont = false;
            this.detalleEfectividadVisitas.StylePriority.UseTextAlignment = false;
            this.detalleEfectividadVisitas.Text = "EfeVisitas";
            this.detalleEfectividadVisitas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleFueraRuta
            // 
            this.detalleFueraRuta.Dpi = 100F;
            this.detalleFueraRuta.LocationFloat = new DevExpress.Utils.PointFloat(644.2714F, 0F);
            this.detalleFueraRuta.Multiline = true;
            this.detalleFueraRuta.Name = "detalleFueraRuta";
            this.detalleFueraRuta.NullValueText = " ";
            this.detalleFueraRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleFueraRuta.SizeF = new System.Drawing.SizeF(68.33301F, 12.87501F);
            this.detalleFueraRuta.StylePriority.UseTextAlignment = false;
            this.detalleFueraRuta.Text = "FueraRuta";
            this.detalleFueraRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // detalleEfectividadTotal
            // 
            this.detalleEfectividadTotal.Dpi = 100F;
            this.detalleEfectividadTotal.LocationFloat = new DevExpress.Utils.PointFloat(742.7501F, 0F);
            this.detalleEfectividadTotal.Multiline = true;
            this.detalleEfectividadTotal.Name = "detalleEfectividadTotal";
            this.detalleEfectividadTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleEfectividadTotal.SizeF = new System.Drawing.SizeF(80.24994F, 12.87501F);
            this.detalleEfectividadTotal.StylePriority.UseTextAlignment = false;
            this.detalleEfectividadTotal.Text = "EfectividadTotal";
            this.detalleEfectividadTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrPictureBox1,
            this.xrLabel27,
            this.xrLine1,
            this.xrLabel14,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.labelfechaheader,
            this.headerlabelcedis,
            this.xrLabel23,
            this.xrLabel20});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 226.4583F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0.4999796F, 169.7917F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(822.5F, 10.5F);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 9.500008F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(152F, 95F);
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(249.6923F, 10.00001F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(369.4634F, 23F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.Text = "REPORTE DE EFECTIVIDAD DE VISITA (RIP)";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(1.766205F, 213.9585F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(821.2338F, 10.5F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(2.266185F, 180.2917F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(306.1918F, 21.41684F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "DECI/Ruta";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(308.4579F, 180.2917F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(92.95844F, 31.83353F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Visitas Programada";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(433.4844F, 180.2917F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(75.9538F, 31.83344F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Visitas Efectuadas";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(743.25F, 180.2917F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(79.74988F, 33.66672F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Efectividad Total";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(644.7713F, 180.2917F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(67.83307F, 31.83345F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Fuera de Ruta";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(539.5718F, 180.2917F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(79.5838F, 31.83344F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Efectividad de Visitas";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelfechaheader
            // 
            this.labelfechaheader.Dpi = 100F;
            this.labelfechaheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfechaheader.LocationFloat = new DevExpress.Utils.PointFloat(153.1873F, 135.9165F);
            this.labelfechaheader.Name = "labelfechaheader";
            this.labelfechaheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelfechaheader.SizeF = new System.Drawing.SizeF(248.2291F, 23F);
            this.labelfechaheader.StylePriority.UseFont = false;
            // 
            // headerlabelcedis
            // 
            this.headerlabelcedis.Dpi = 100F;
            this.headerlabelcedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelcedis.LocationFloat = new DevExpress.Utils.PointFloat(153.6505F, 112.9165F);
            this.headerlabelcedis.Name = "headerlabelcedis";
            this.headerlabelcedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelcedis.SizeF = new System.Drawing.SizeF(247.7659F, 23.00002F);
            this.headerlabelcedis.StylePriority.UseFont = false;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(11.56226F, 135.9165F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Periodo";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(11.56226F, 112.9165F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Centro de Distribución";
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(49.41661F, 38.50002F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(277.7758F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(459.5261F, 38.50002F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.headerCedi,
            this.headerVisitaProgramada,
            this.headerVisitaEfectuada,
            this.headerEfectividadVisitas,
            this.headerFueraRuta,
            this.headerEfectividadTotal});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 15.625F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // headerCedi
            // 
            this.headerCedi.Dpi = 100F;
            this.headerCedi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerCedi.LocationFloat = new DevExpress.Utils.PointFloat(0.8645935F, 0F);
            this.headerCedi.Name = "headerCedi";
            this.headerCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerCedi.SizeF = new System.Drawing.SizeF(306.7288F, 12.87501F);
            this.headerCedi.StylePriority.UseFont = false;
            this.headerCedi.Text = "Deci/Ruta";
            // 
            // headerVisitaProgramada
            // 
            this.headerVisitaProgramada.Dpi = 100F;
            this.headerVisitaProgramada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerVisitaProgramada.LocationFloat = new DevExpress.Utils.PointFloat(307.5933F, 0F);
            this.headerVisitaProgramada.Name = "headerVisitaProgramada";
            this.headerVisitaProgramada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerVisitaProgramada.SizeF = new System.Drawing.SizeF(93.45844F, 12.87501F);
            this.headerVisitaProgramada.StylePriority.UseFont = false;
            this.headerVisitaProgramada.StylePriority.UseTextAlignment = false;
            this.headerVisitaProgramada.Text = "Programada";
            this.headerVisitaProgramada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // headerVisitaEfectuada
            // 
            this.headerVisitaEfectuada.Dpi = 100F;
            this.headerVisitaEfectuada.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerVisitaEfectuada.LocationFloat = new DevExpress.Utils.PointFloat(432.6198F, 0F);
            this.headerVisitaEfectuada.Multiline = true;
            this.headerVisitaEfectuada.Name = "headerVisitaEfectuada";
            this.headerVisitaEfectuada.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerVisitaEfectuada.SizeF = new System.Drawing.SizeF(76.45377F, 12.87501F);
            this.headerVisitaEfectuada.StylePriority.UseFont = false;
            this.headerVisitaEfectuada.StylePriority.UseTextAlignment = false;
            this.headerVisitaEfectuada.Text = "Efectuadas";
            this.headerVisitaEfectuada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // headerEfectividadVisitas
            // 
            this.headerEfectividadVisitas.Dpi = 100F;
            this.headerEfectividadVisitas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerEfectividadVisitas.LocationFloat = new DevExpress.Utils.PointFloat(538.7073F, 0F);
            this.headerEfectividadVisitas.Multiline = true;
            this.headerEfectividadVisitas.Name = "headerEfectividadVisitas";
            this.headerEfectividadVisitas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerEfectividadVisitas.SizeF = new System.Drawing.SizeF(80.0838F, 12.87501F);
            this.headerEfectividadVisitas.StylePriority.UseFont = false;
            this.headerEfectividadVisitas.StylePriority.UseTextAlignment = false;
            this.headerEfectividadVisitas.Text = "EfeVisitas";
            this.headerEfectividadVisitas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // headerFueraRuta
            // 
            this.headerFueraRuta.Dpi = 100F;
            this.headerFueraRuta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFueraRuta.LocationFloat = new DevExpress.Utils.PointFloat(643.4067F, 0F);
            this.headerFueraRuta.Multiline = true;
            this.headerFueraRuta.Name = "headerFueraRuta";
            this.headerFueraRuta.NullValueText = " ";
            this.headerFueraRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerFueraRuta.SizeF = new System.Drawing.SizeF(68.33301F, 12.87501F);
            this.headerFueraRuta.StylePriority.UseFont = false;
            this.headerFueraRuta.StylePriority.UseTextAlignment = false;
            this.headerFueraRuta.Text = "FueraRuta";
            this.headerFueraRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // headerEfectividadTotal
            // 
            this.headerEfectividadTotal.Dpi = 100F;
            this.headerEfectividadTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerEfectividadTotal.LocationFloat = new DevExpress.Utils.PointFloat(741.8854F, 0F);
            this.headerEfectividadTotal.Multiline = true;
            this.headerEfectividadTotal.Name = "headerEfectividadTotal";
            this.headerEfectividadTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerEfectividadTotal.SizeF = new System.Drawing.SizeF(80.24994F, 12.87501F);
            this.headerEfectividadTotal.StylePriority.UseFont = false;
            this.headerEfectividadTotal.StylePriority.UseTextAlignment = false;
            this.headerEfectividadTotal.Text = "EfectividadTotal";
            this.headerEfectividadTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReporteEfectividadVisitaRIP
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 226, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        // Create a new rule and add it to a report.
        FormattingRule rule3 = new FormattingRule();
        this.FormattingRuleSheet.Add(rule3);

        // Specify the rule's properties.
        rule3.DataSource = this.DataSource;
        rule3.DataMember = this.DataMember;
        rule3.Condition = "[EfectividadTotal] < [EfectividadTotalMayor] && [EfectividadTotal] > [EfectividadTotalMenor]";
        rule3.Formatting.ForeColor = Color.Black;
        rule3.Formatting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


        // Apply this rule to the detail band.
        this.Detail.FormattingRules.Add(rule3);



        // Create a new rule and add it to a report.
        FormattingRule rule = new FormattingRule();
        this.FormattingRuleSheet.Add(rule);

        // Specify the rule's properties.
        rule.DataSource = this.DataSource;
        rule.DataMember = this.DataMember;
        rule.Condition = "[EfectividadTotal] >= [EfectividadTotalMayor]";
        rule.Formatting.ForeColor = Color.Green;
        rule.Formatting.Font = new Font("Arial", 8.25F, FontStyle.Bold);

        // Apply this rule to the detail band.
        this.Detail.FormattingRules.Add(rule);

        // Create a new rule and add it to a report.
        FormattingRule rule2 = new FormattingRule();
        this.FormattingRuleSheet.Add(rule2);

        // Specify the rule's properties.
        rule2.DataSource = this.DataSource;
        rule2.DataMember = this.DataMember;
        rule2.Condition = "[EfectividadTotal] <= [EfectividadTotalMenor]";
        rule2.Formatting.ForeColor = Color.Red;
        rule2.Formatting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //rule2.Formatting.Font = new Font("Arial", 10, FontStyle.Bold);


        // Apply this rule to the detail band.
        this.Detail.FormattingRules.Add(rule2);


        

    }

}
