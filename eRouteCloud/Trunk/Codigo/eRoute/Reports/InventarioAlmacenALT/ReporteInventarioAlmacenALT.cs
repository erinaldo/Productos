using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class ReporteInventarioAlmacenALT : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel20;
    public XRLabel headerFecha;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    public XRLabel cervezaData;
    public XRLabel codigoData;
    public XRLabel tepaData;
    public XRLabel yahualicaData;
    public XRLabel arandasData;
    public XRLabel atotonilcoData;
    public XRLabel totalData;
    private XRLine xrLine2;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel15;
    private ReportFooterBand ReportFooter;
    public XRLabel tepaTotal;
    public XRLabel yahuaTotal;
    public XRLabel aranTotal;
    public XRLabel atotoTotal;
    public XRLabel totalTotal;
    private XRLine xrLine3;
    private XRLine xrLine5;
    private XRLine xrLine1;
    private ReportHeaderBand ReportHeader;
    public GroupHeaderBand GroupHeader1;
    public XRLabel envaseGroup;
    private GroupFooterBand GroupFooter1;
    private XRLine xrLine4;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteInventarioAlmacenALT()
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
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.cervezaData = new DevExpress.XtraReports.UI.XRLabel();
            this.codigoData = new DevExpress.XtraReports.UI.XRLabel();
            this.tepaData = new DevExpress.XtraReports.UI.XRLabel();
            this.yahualicaData = new DevExpress.XtraReports.UI.XRLabel();
            this.arandasData = new DevExpress.XtraReports.UI.XRLabel();
            this.atotonilcoData = new DevExpress.XtraReports.UI.XRLabel();
            this.totalData = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.headerFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.tepaTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.yahuaTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.aranTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.atotoTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.totalTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.envaseGroup = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine3,
            this.cervezaData,
            this.codigoData,
            this.tepaData,
            this.yahualicaData,
            this.arandasData,
            this.atotonilcoData,
            this.totalData});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 22.96028F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(818.4845F, 6.506942F);
            // 
            // cervezaData
            // 
            this.cervezaData.Dpi = 100F;
            this.cervezaData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cervezaData.LocationFloat = new DevExpress.Utils.PointFloat(1.271181F, 6.506974F);
            this.cervezaData.Name = "cervezaData";
            this.cervezaData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cervezaData.SizeF = new System.Drawing.SizeF(258.0789F, 15.82831F);
            this.cervezaData.StylePriority.UseFont = false;
            this.cervezaData.StylePriority.UseTextAlignment = false;
            this.cervezaData.Text = "CERVEZA";
            this.cervezaData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // codigoData
            // 
            this.codigoData.Dpi = 100F;
            this.codigoData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoData.LocationFloat = new DevExpress.Utils.PointFloat(259.3501F, 6.506994F);
            this.codigoData.Multiline = true;
            this.codigoData.Name = "codigoData";
            this.codigoData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.codigoData.SizeF = new System.Drawing.SizeF(73.00186F, 15.82835F);
            this.codigoData.StylePriority.UseFont = false;
            this.codigoData.StylePriority.UseTextAlignment = false;
            this.codigoData.Text = "CODIGO";
            this.codigoData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tepaData
            // 
            this.tepaData.Dpi = 100F;
            this.tepaData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tepaData.LocationFloat = new DevExpress.Utils.PointFloat(332.5501F, 6.506968F);
            this.tepaData.Multiline = true;
            this.tepaData.Name = "tepaData";
            this.tepaData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tepaData.SizeF = new System.Drawing.SizeF(91.65659F, 15.82838F);
            this.tepaData.StylePriority.UseFont = false;
            this.tepaData.StylePriority.UseTextAlignment = false;
            this.tepaData.Text = "TEPATITLAN";
            this.tepaData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // yahualicaData
            // 
            this.yahualicaData.Dpi = 100F;
            this.yahualicaData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yahualicaData.LocationFloat = new DevExpress.Utils.PointFloat(424.2555F, 6.506932F);
            this.yahualicaData.Multiline = true;
            this.yahualicaData.Name = "yahualicaData";
            this.yahualicaData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.yahualicaData.SizeF = new System.Drawing.SizeF(93.17133F, 15.82831F);
            this.yahualicaData.StylePriority.UseFont = false;
            this.yahualicaData.StylePriority.UseTextAlignment = false;
            this.yahualicaData.Text = "YAHUALICA";
            this.yahualicaData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // arandasData
            // 
            this.arandasData.Dpi = 100F;
            this.arandasData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arandasData.LocationFloat = new DevExpress.Utils.PointFloat(517.4269F, 6.506932F);
            this.arandasData.Multiline = true;
            this.arandasData.Name = "arandasData";
            this.arandasData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.arandasData.SizeF = new System.Drawing.SizeF(92.90814F, 15.82831F);
            this.arandasData.StylePriority.UseFont = false;
            this.arandasData.StylePriority.UseTextAlignment = false;
            this.arandasData.Text = "ARANDAS";
            this.arandasData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // atotonilcoData
            // 
            this.atotonilcoData.Dpi = 100F;
            this.atotonilcoData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atotonilcoData.LocationFloat = new DevExpress.Utils.PointFloat(610.335F, 6.507003F);
            this.atotonilcoData.Multiline = true;
            this.atotonilcoData.Name = "atotonilcoData";
            this.atotonilcoData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.atotonilcoData.SizeF = new System.Drawing.SizeF(110.8593F, 15.82831F);
            this.atotonilcoData.StylePriority.UseFont = false;
            this.atotonilcoData.StylePriority.UseTextAlignment = false;
            this.atotonilcoData.Text = "ATOTONILCO";
            this.atotonilcoData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // totalData
            // 
            this.totalData.Dpi = 100F;
            this.totalData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalData.LocationFloat = new DevExpress.Utils.PointFloat(721.2566F, 6.507039F);
            this.totalData.Multiline = true;
            this.totalData.Name = "totalData";
            this.totalData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalData.SizeF = new System.Drawing.SizeF(96.79663F, 15.82831F);
            this.totalData.StylePriority.UseFont = false;
            this.totalData.StylePriority.UseTextAlignment = false;
            this.totalData.Text = "TOTAL";
            this.totalData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 14F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(335.5562F, 121.0417F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(54.97919F, 23.00002F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "FECHA:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // headerFecha
            // 
            this.headerFecha.Dpi = 100F;
            this.headerFecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerFecha.LocationFloat = new DevExpress.Utils.PointFloat(390.5354F, 121.0417F);
            this.headerFecha.Name = "headerFecha";
            this.headerFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerFecha.SizeF = new System.Drawing.SizeF(339.4646F, 23.00002F);
            this.headerFecha.StylePriority.UseFont = false;
            this.headerFecha.StylePriority.UseTextAlignment = false;
            this.headerFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(92F, 38.5F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(417F, 38.5F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(3.006077F, 180.4673F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(817.2917F, 5.708344F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(3.006077F, 154.639F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(259.4857F, 25.82831F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "CERVEZA";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(518.991F, 154.639F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(92.90814F, 25.82825F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "ARANDAS";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(611.8992F, 154.6391F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(110.8593F, 25.82825F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "ATOTONILCO";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(425.8197F, 154.639F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(93.17133F, 25.82826F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "YAHUALICA";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(334.1143F, 154.639F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(91.65659F, 25.82828F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "TEPATITLAN";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(262.4918F, 154.6391F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(71.28885F, 25.82831F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "CODIGO";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(722.8207F, 154.639F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(96.79663F, 25.82826F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "TOTAL";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine5,
            this.tepaTotal,
            this.yahuaTotal,
            this.aranTotal,
            this.atotoTotal,
            this.totalTotal});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 51.38887F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(818.4845F, 6.506942F);
            // 
            // tepaTotal
            // 
            this.tepaTotal.Dpi = 100F;
            this.tepaTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tepaTotal.LocationFloat = new DevExpress.Utils.PointFloat(332.4873F, 6.506953F);
            this.tepaTotal.Multiline = true;
            this.tepaTotal.Name = "tepaTotal";
            this.tepaTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tepaTotal.SizeF = new System.Drawing.SizeF(91.65659F, 36.37517F);
            this.tepaTotal.StylePriority.UseFont = false;
            this.tepaTotal.StylePriority.UseTextAlignment = false;
            this.tepaTotal.Text = "TEPATITLAN";
            this.tepaTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // yahuaTotal
            // 
            this.yahuaTotal.Dpi = 100F;
            this.yahuaTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yahuaTotal.LocationFloat = new DevExpress.Utils.PointFloat(424.2548F, 6.506953F);
            this.yahuaTotal.Multiline = true;
            this.yahuaTotal.Name = "yahuaTotal";
            this.yahuaTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.yahuaTotal.SizeF = new System.Drawing.SizeF(93.1713F, 36.37514F);
            this.yahuaTotal.StylePriority.UseFont = false;
            this.yahuaTotal.StylePriority.UseTextAlignment = false;
            this.yahuaTotal.Text = "YAHUALICA";
            this.yahuaTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // aranTotal
            // 
            this.aranTotal.Dpi = 100F;
            this.aranTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aranTotal.LocationFloat = new DevExpress.Utils.PointFloat(517.4263F, 6.506953F);
            this.aranTotal.Multiline = true;
            this.aranTotal.Name = "aranTotal";
            this.aranTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.aranTotal.SizeF = new System.Drawing.SizeF(92.90814F, 36.37512F);
            this.aranTotal.StylePriority.UseFont = false;
            this.aranTotal.StylePriority.UseTextAlignment = false;
            this.aranTotal.Text = "ARANDAS";
            this.aranTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // atotoTotal
            // 
            this.atotoTotal.Dpi = 100F;
            this.atotoTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atotoTotal.LocationFloat = new DevExpress.Utils.PointFloat(610.3347F, 6.506953F);
            this.atotoTotal.Multiline = true;
            this.atotoTotal.Name = "atotoTotal";
            this.atotoTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.atotoTotal.SizeF = new System.Drawing.SizeF(110.8593F, 36.37512F);
            this.atotoTotal.StylePriority.UseFont = false;
            this.atotoTotal.StylePriority.UseTextAlignment = false;
            this.atotoTotal.Text = "ATOTONILCO";
            this.atotoTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // totalTotal
            // 
            this.totalTotal.Dpi = 100F;
            this.totalTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTotal.LocationFloat = new DevExpress.Utils.PointFloat(721.194F, 6.507017F);
            this.totalTotal.Multiline = true;
            this.totalTotal.Name = "totalTotal";
            this.totalTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalTotal.SizeF = new System.Drawing.SizeF(96.79663F, 36.37511F);
            this.totalTotal.StylePriority.UseFont = false;
            this.totalTotal.StylePriority.UseTextAlignment = false;
            this.totalTotal.Text = "TOTAL";
            this.totalTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(3.006077F, 148.9306F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(817.2917F, 5.708344F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.headerFecha,
            this.xrLabel20,
            this.xrLabel15,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLine2,
            this.xrLine1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 186.1756F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.envaseGroup});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 33.83594F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // envaseGroup
            // 
            this.envaseGroup.Dpi = 100F;
            this.envaseGroup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.envaseGroup.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.envaseGroup.Name = "envaseGroup";
            this.envaseGroup.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.envaseGroup.SizeF = new System.Drawing.SizeF(258.0789F, 15.82831F);
            this.envaseGroup.StylePriority.UseBackColor = false;
            this.envaseGroup.StylePriority.UseBorders = false;
            this.envaseGroup.StylePriority.UseFont = false;
            this.envaseGroup.StylePriority.UseTextAlignment = false;
            this.envaseGroup.Text = "ENVASE";
            this.envaseGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 9.149465F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(818.4845F, 6.506942F);
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(53.33333F, 5.000003F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(229.8333F, 70F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(229.8333F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReporteInventarioAlmacenALT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 14, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
