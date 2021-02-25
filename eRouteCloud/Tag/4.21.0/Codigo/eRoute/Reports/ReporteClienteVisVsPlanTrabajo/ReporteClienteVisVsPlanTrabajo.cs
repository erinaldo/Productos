using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class ReporteClienteVisVsPlanTrabajo : DevExpress.XtraReports.UI.XtraReport
{
    public DetailBand DetailReportClientes;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel23;
    private XRLabel xrLabel25;
    public XRLabel labelFechaReporteHeader;
    public XRLabel labelCEDIHeader;
    public XRPictureBox xrPictureBox1;
    private XRLabel xrLabel27;
    private XRLabel xrLabel234;
    public XRLabel labelFechaHeader;
    public XRPictureBox xrPictureBox2;
    public XRLabel labelEmpresa;
    private XRLabel xrLabel2;
    public XRLabel labelRutaHeader;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel1;
    public GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    public XRLabel LabelEFrecuencia;
    public XRLabel LabelFFrecuencia;
    public XRLabel LabelClientesV;
    public XRLabel LabelVisitas;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    public XRLabel LabelVendedor;
    private XRLabel xrLabel13;
    public XRLabel LabelRuta;
    private XRLabel xrLabel11;
    public GroupHeaderBand GroupHeader2;
    public XRLabel LabelSupervisor;
    private XRLabel xrLabel16;
    public XRLabel LabelNO;
    public XRLabel LabelOVisita;
    public XRLabel LabelFHInicial;
    public XRLabel LabelFHFinal;
    public XRLabel LabelDVisita;
    public XRLabel LabelCodigo;
    public XRLabel LabelNombre;
    public XRLabel LabelDireccion;
    public XRLabel LabelFrecuencia;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteClienteVisVsPlanTrabajo()
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
            this.DetailReportClientes = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelRutaHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelEmpresa = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFechaReporteHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCEDIHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel234 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFechaHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelEFrecuencia = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelFFrecuencia = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelClientesV = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelVisitas = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.LabelSupervisor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelNO = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelOVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelFHInicial = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelFHFinal = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelDVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelCodigo = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelDireccion = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelFrecuencia = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // DetailReportClientes
            // 
            this.DetailReportClientes.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LabelNO,
            this.LabelOVisita,
            this.LabelFHInicial,
            this.LabelFHFinal,
            this.LabelDVisita,
            this.LabelCodigo,
            this.LabelNombre,
            this.LabelDireccion,
            this.LabelFrecuencia});
            this.DetailReportClientes.Dpi = 100F;
            this.DetailReportClientes.HeightF = 16F;
            this.DetailReportClientes.Name = "DetailReportClientes";
            this.DetailReportClientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailReportClientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 70F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 38.50002F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(751F, 38.50002F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.labelRutaHeader,
            this.labelEmpresa,
            this.xrLabel23,
            this.xrLabel25,
            this.labelFechaReporteHeader,
            this.labelCEDIHeader,
            this.xrPictureBox1,
            this.xrLabel27,
            this.xrLabel234,
            this.labelFechaHeader,
            this.xrPictureBox2});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 219.7917F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0.1F, 191F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(140.62F, 27F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Ruta(s)";
            // 
            // labelRutaHeader
            // 
            this.labelRutaHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelRutaHeader.Dpi = 100F;
            this.labelRutaHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRutaHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.1F, 191F);
            this.labelRutaHeader.Name = "labelRutaHeader";
            this.labelRutaHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelRutaHeader.SizeF = new System.Drawing.SizeF(928.8F, 27F);
            this.labelRutaHeader.StylePriority.UseBorders = false;
            this.labelRutaHeader.StylePriority.UseFont = false;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelEmpresa.Dpi = 100F;
            this.labelEmpresa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpresa.LocationFloat = new DevExpress.Utils.PointFloat(351.2767F, 24.60416F);
            this.labelEmpresa.Multiline = true;
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelEmpresa.SizeF = new System.Drawing.SizeF(401.14F, 23F);
            this.labelEmpresa.StylePriority.UseBorders = false;
            this.labelEmpresa.StylePriority.UseFont = false;
            this.labelEmpresa.StylePriority.UseTextAlignment = false;
            this.labelEmpresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0.1F, 119F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Fecha/Hora Reporte";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(0.1F, 143F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel25.StylePriority.UseBorders = false;
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Centro de Distribución";
            // 
            // labelFechaReporteHeader
            // 
            this.labelFechaReporteHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelFechaReporteHeader.Dpi = 100F;
            this.labelFechaReporteHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaReporteHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.1F, 119F);
            this.labelFechaReporteHeader.Name = "labelFechaReporteHeader";
            this.labelFechaReporteHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFechaReporteHeader.SizeF = new System.Drawing.SizeF(928.8F, 23F);
            this.labelFechaReporteHeader.StylePriority.UseBorders = false;
            this.labelFechaReporteHeader.StylePriority.UseFont = false;
            // 
            // labelCEDIHeader
            // 
            this.labelCEDIHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelCEDIHeader.Dpi = 100F;
            this.labelCEDIHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCEDIHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.1F, 143F);
            this.labelCEDIHeader.Name = "labelCEDIHeader";
            this.labelCEDIHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCEDIHeader.SizeF = new System.Drawing.SizeF(928.801F, 23.00002F);
            this.labelCEDIHeader.StylePriority.UseBorders = false;
            this.labelCEDIHeader.StylePriority.UseFont = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 10.00001F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(152F, 95F);
            // 
            // xrLabel27
            // 
            this.xrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(351.2798F, 65.33334F);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(401.1369F, 23F);
            this.xrLabel27.StylePriority.UseBorders = false;
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Reporte de Clientes Visitados Vs Plan de Trabajo";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel234
            // 
            this.xrLabel234.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel234.Dpi = 100F;
            this.xrLabel234.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel234.LocationFloat = new DevExpress.Utils.PointFloat(0.1F, 167F);
            this.xrLabel234.Name = "xrLabel234";
            this.xrLabel234.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel234.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel234.StylePriority.UseBorders = false;
            this.xrLabel234.StylePriority.UseFont = false;
            this.xrLabel234.Text = "Rango de Fecha";
            // 
            // labelFechaHeader
            // 
            this.labelFechaHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelFechaHeader.Dpi = 100F;
            this.labelFechaHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.1F, 167F);
            this.labelFechaHeader.Name = "labelFechaHeader";
            this.labelFechaHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFechaHeader.SizeF = new System.Drawing.SizeF(928.8013F, 23F);
            this.labelFechaHeader.StylePriority.UseBorders = false;
            this.labelFechaHeader.StylePriority.UseFont = false;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Dpi = 100F;
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(911.4999F, 12.10416F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(152F, 95F);
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
            this.xrLabel3,
            this.xrLabel1});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 57.29167F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(1021.5F, 17.62F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(52.5F, 23F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "En Frec.";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(791.5F, 17.62499F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(230F, 23F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Direccion";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(490.6F, 17.62499F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(300.9F, 23F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Nombre";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(420.6F, 17.62499F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Código";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(350.6F, 17.62499F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "Día Visita";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(225.6F, 17.62499F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(125F, 23F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Fecha y Hora Final";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(100.6F, 17.62499F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(125F, 23F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Fecha y Hora Inicial";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(25.1F, 17.62499F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(75.5F, 23F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Orden Visita";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.1F, 17.625F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(25F, 23F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "No.";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel22,
            this.LabelEFrecuencia,
            this.LabelFFrecuencia,
            this.LabelClientesV,
            this.LabelVisitas,
            this.xrLabel18,
            this.xrLabel17,
            this.LabelVendedor,
            this.xrLabel13,
            this.LabelRuta,
            this.xrLabel11});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 47.54168F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(776.2749F, 6.250015F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(119.1251F, 17F);
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "En Frecuencia";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(776.2749F, 23.25002F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(119.1251F, 17F);
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.Text = "Fuera de Frecuencia";
            // 
            // LabelEFrecuencia
            // 
            this.LabelEFrecuencia.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelEFrecuencia.Dpi = 100F;
            this.LabelEFrecuencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEFrecuencia.LocationFloat = new DevExpress.Utils.PointFloat(895.4F, 6.250015F);
            this.LabelEFrecuencia.Name = "LabelEFrecuencia";
            this.LabelEFrecuencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelEFrecuencia.SizeF = new System.Drawing.SizeF(178.0001F, 17F);
            this.LabelEFrecuencia.StylePriority.UseBorders = false;
            this.LabelEFrecuencia.StylePriority.UseFont = false;
            // 
            // LabelFFrecuencia
            // 
            this.LabelFFrecuencia.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelFFrecuencia.Dpi = 100F;
            this.LabelFFrecuencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFFrecuencia.LocationFloat = new DevExpress.Utils.PointFloat(895.4F, 23.25002F);
            this.LabelFFrecuencia.Name = "LabelFFrecuencia";
            this.LabelFFrecuencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelFFrecuencia.SizeF = new System.Drawing.SizeF(178.0001F, 17F);
            this.LabelFFrecuencia.StylePriority.UseBorders = false;
            this.LabelFFrecuencia.StylePriority.UseFont = false;
            // 
            // LabelClientesV
            // 
            this.LabelClientesV.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelClientesV.Dpi = 100F;
            this.LabelClientesV.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelClientesV.LocationFloat = new DevExpress.Utils.PointFloat(587.1708F, 23.25002F);
            this.LabelClientesV.Name = "LabelClientesV";
            this.LabelClientesV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelClientesV.SizeF = new System.Drawing.SizeF(187.375F, 17F);
            this.LabelClientesV.StylePriority.UseBorders = false;
            this.LabelClientesV.StylePriority.UseFont = false;
            // 
            // LabelVisitas
            // 
            this.LabelVisitas.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelVisitas.Dpi = 100F;
            this.LabelVisitas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVisitas.LocationFloat = new DevExpress.Utils.PointFloat(587.1708F, 6.250015F);
            this.LabelVisitas.Name = "LabelVisitas";
            this.LabelVisitas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelVisitas.SizeF = new System.Drawing.SizeF(187.375F, 17F);
            this.LabelVisitas.StylePriority.UseBorders = false;
            this.LabelVisitas.StylePriority.UseFont = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(477.4207F, 23.25002F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(109.2501F, 17F);
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "Clientes Visitados";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(477.4207F, 6.250015F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(109.2501F, 17F);
            this.xrLabel17.StylePriority.UseBorders = false;
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "Visitas";
            // 
            // LabelVendedor
            // 
            this.LabelVendedor.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelVendedor.Dpi = 100F;
            this.LabelVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVendedor.LocationFloat = new DevExpress.Utils.PointFloat(92.1F, 6.250015F);
            this.LabelVendedor.Name = "LabelVendedor";
            this.LabelVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelVendedor.SizeF = new System.Drawing.SizeF(380.9583F, 17F);
            this.LabelVendedor.StylePriority.UseBorders = false;
            this.LabelVendedor.StylePriority.UseFont = false;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0.1000366F, 6.250015F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(90.5F, 17F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "Vendedor";
            // 
            // LabelRuta
            // 
            this.LabelRuta.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelRuta.Dpi = 100F;
            this.LabelRuta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRuta.LocationFloat = new DevExpress.Utils.PointFloat(92.10003F, 23.25002F);
            this.LabelRuta.Name = "LabelRuta";
            this.LabelRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelRuta.SizeF = new System.Drawing.SizeF(380.9583F, 17F);
            this.LabelRuta.StylePriority.UseBorders = false;
            this.LabelRuta.StylePriority.UseFont = false;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(0.1F, 23.25002F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(90.5F, 17F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "Ruta";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LabelSupervisor,
            this.xrLabel16});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 17.70833F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // LabelSupervisor
            // 
            this.LabelSupervisor.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelSupervisor.Dpi = 100F;
            this.LabelSupervisor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSupervisor.LocationFloat = new DevExpress.Utils.PointFloat(91.99995F, 0F);
            this.LabelSupervisor.Name = "LabelSupervisor";
            this.LabelSupervisor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelSupervisor.SizeF = new System.Drawing.SizeF(380.9583F, 17F);
            this.LabelSupervisor.StylePriority.UseBorders = false;
            this.LabelSupervisor.StylePriority.UseFont = false;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(90.5F, 17F);
            this.xrLabel16.StylePriority.UseBorders = false;
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "Supervisor";
            // 
            // LabelNO
            // 
            this.LabelNO.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelNO.Dpi = 100F;
            this.LabelNO.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNO.LocationFloat = new DevExpress.Utils.PointFloat(0.04998779F, 0F);
            this.LabelNO.Name = "LabelNO";
            this.LabelNO.NullValueText = "-";
            this.LabelNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelNO.SizeF = new System.Drawing.SizeF(25F, 16F);
            this.LabelNO.StylePriority.UseBorders = false;
            this.LabelNO.StylePriority.UseFont = false;
            // 
            // LabelOVisita
            // 
            this.LabelOVisita.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelOVisita.Dpi = 100F;
            this.LabelOVisita.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOVisita.LocationFloat = new DevExpress.Utils.PointFloat(25.04999F, 0F);
            this.LabelOVisita.Name = "LabelOVisita";
            this.LabelOVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelOVisita.SizeF = new System.Drawing.SizeF(75.5F, 16F);
            this.LabelOVisita.StylePriority.UseBorders = false;
            this.LabelOVisita.StylePriority.UseFont = false;
            // 
            // LabelFHInicial
            // 
            this.LabelFHInicial.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelFHInicial.Dpi = 100F;
            this.LabelFHInicial.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFHInicial.LocationFloat = new DevExpress.Utils.PointFloat(100.5499F, 0F);
            this.LabelFHInicial.Name = "LabelFHInicial";
            this.LabelFHInicial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelFHInicial.SizeF = new System.Drawing.SizeF(125F, 16F);
            this.LabelFHInicial.StylePriority.UseBorders = false;
            this.LabelFHInicial.StylePriority.UseFont = false;
            // 
            // LabelFHFinal
            // 
            this.LabelFHFinal.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelFHFinal.Dpi = 100F;
            this.LabelFHFinal.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFHFinal.LocationFloat = new DevExpress.Utils.PointFloat(225.55F, 0F);
            this.LabelFHFinal.Name = "LabelFHFinal";
            this.LabelFHFinal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelFHFinal.SizeF = new System.Drawing.SizeF(125F, 16F);
            this.LabelFHFinal.StylePriority.UseBorders = false;
            this.LabelFHFinal.StylePriority.UseFont = false;
            // 
            // LabelDVisita
            // 
            this.LabelDVisita.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelDVisita.Dpi = 100F;
            this.LabelDVisita.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDVisita.LocationFloat = new DevExpress.Utils.PointFloat(350.55F, 0F);
            this.LabelDVisita.Name = "LabelDVisita";
            this.LabelDVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelDVisita.SizeF = new System.Drawing.SizeF(70.00003F, 16F);
            this.LabelDVisita.StylePriority.UseBorders = false;
            this.LabelDVisita.StylePriority.UseFont = false;
            // 
            // LabelCodigo
            // 
            this.LabelCodigo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelCodigo.Dpi = 100F;
            this.LabelCodigo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCodigo.LocationFloat = new DevExpress.Utils.PointFloat(420.55F, 0F);
            this.LabelCodigo.Name = "LabelCodigo";
            this.LabelCodigo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelCodigo.SizeF = new System.Drawing.SizeF(70.00003F, 16F);
            this.LabelCodigo.StylePriority.UseBorders = false;
            this.LabelCodigo.StylePriority.UseFont = false;
            // 
            // LabelNombre
            // 
            this.LabelNombre.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelNombre.Dpi = 100F;
            this.LabelNombre.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNombre.LocationFloat = new DevExpress.Utils.PointFloat(490.55F, 0F);
            this.LabelNombre.Name = "LabelNombre";
            this.LabelNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelNombre.SizeF = new System.Drawing.SizeF(300.9F, 16F);
            this.LabelNombre.StylePriority.UseBorders = false;
            this.LabelNombre.StylePriority.UseFont = false;
            // 
            // LabelDireccion
            // 
            this.LabelDireccion.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelDireccion.Dpi = 100F;
            this.LabelDireccion.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDireccion.LocationFloat = new DevExpress.Utils.PointFloat(791.45F, 0F);
            this.LabelDireccion.Name = "LabelDireccion";
            this.LabelDireccion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelDireccion.SizeF = new System.Drawing.SizeF(230F, 16F);
            this.LabelDireccion.StylePriority.UseBorders = false;
            this.LabelDireccion.StylePriority.UseFont = false;
            // 
            // LabelFrecuencia
            // 
            this.LabelFrecuencia.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LabelFrecuencia.Dpi = 100F;
            this.LabelFrecuencia.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrecuencia.LocationFloat = new DevExpress.Utils.PointFloat(1021.45F, 0F);
            this.LabelFrecuencia.Name = "LabelFrecuencia";
            this.LabelFrecuencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LabelFrecuencia.SizeF = new System.Drawing.SizeF(52.5F, 16F);
            this.LabelFrecuencia.StylePriority.UseBorders = false;
            this.LabelFrecuencia.StylePriority.UseFont = false;
            // 
            // ReporteClienteVisVsPlanTrabajo
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailReportClientes,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupHeader2});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 0, 70);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
