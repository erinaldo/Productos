using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class ReporteVentasporCodigoDetalladoUNI : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel labelFechaHeader;
    public XRLabel labelCEDIHeader;
    private XRLabel xrLabel25;
    private XRLabel xrLabel23;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    public XRLabel labelFamiliaHeader;
    private XRLabel xrLabel234;
    public XRLabel labelRutaHeader;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    public XRLabel labelDescripcionHeader;
    public XRLabel labelCodigoHeader;
    public XRLabel labelTipoHeader;
    public XRLabel xrLabel5;
    public XRSubreport xrSubreportCliente;
    private ReportHeaderBand ReportHeader;
    public XRSubreport xrSubreportResumen;
    public ReportFooterBand ReportFooter;
    public XRSubreport xrSubreportCodigo;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteVentasporCodigoDetalladoUNI()
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
            this.xrSubreportCliente = new DevExpress.XtraReports.UI.XRSubreport();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelDescripcionHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCodigoHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelTipoHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFamiliaHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel234 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelRutaHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFechaHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCEDIHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrSubreportResumen = new DevExpress.XtraReports.UI.XRSubreport();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrSubreportCodigo = new DevExpress.XtraReports.UI.XRSubreport();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportCliente});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 41.66667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrSubreportCliente
            // 
            this.xrSubreportCliente.CanShrink = true;
            this.xrSubreportCliente.Dpi = 100F;
            this.xrSubreportCliente.LocationFloat = new DevExpress.Utils.PointFloat(0.4999956F, 0F);
            this.xrSubreportCliente.Name = "xrSubreportCliente";
            this.xrSubreportCliente.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportCliente.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.xrLabel5,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel4,
            this.labelDescripcionHeader,
            this.labelCodigoHeader,
            this.labelTipoHeader,
            this.labelFamiliaHeader,
            this.xrLabel234,
            this.labelRutaHeader,
            this.xrLabel2,
            this.labelFechaHeader,
            this.labelCEDIHeader,
            this.xrLabel25,
            this.xrLabel23});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 260.125F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(2.5F, 257F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(1071.5F, 2F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 233F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Tipo Reporte";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 185F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Código(s)";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 209F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(140.62F, 23F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Descripción";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelDescripcionHeader
            // 
            this.labelDescripcionHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelDescripcionHeader.Dpi = 100F;
            this.labelDescripcionHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcionHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.7F, 209F);
            this.labelDescripcionHeader.Name = "labelDescripcionHeader";
            this.labelDescripcionHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelDescripcionHeader.SizeF = new System.Drawing.SizeF(928.8F, 23F);
            this.labelDescripcionHeader.StylePriority.UseBorders = false;
            this.labelDescripcionHeader.StylePriority.UseFont = false;
            this.labelDescripcionHeader.StylePriority.UseTextAlignment = false;
            this.labelDescripcionHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCodigoHeader
            // 
            this.labelCodigoHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCodigoHeader.Dpi = 100F;
            this.labelCodigoHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigoHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.7F, 185F);
            this.labelCodigoHeader.Name = "labelCodigoHeader";
            this.labelCodigoHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCodigoHeader.SizeF = new System.Drawing.SizeF(928.801F, 23.00002F);
            this.labelCodigoHeader.StylePriority.UseBorders = false;
            this.labelCodigoHeader.StylePriority.UseFont = false;
            this.labelCodigoHeader.StylePriority.UseTextAlignment = false;
            this.labelCodigoHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelTipoHeader
            // 
            this.labelTipoHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelTipoHeader.Dpi = 100F;
            this.labelTipoHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.699F, 233F);
            this.labelTipoHeader.Name = "labelTipoHeader";
            this.labelTipoHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelTipoHeader.SizeF = new System.Drawing.SizeF(403.3417F, 23F);
            this.labelTipoHeader.StylePriority.UseBorders = false;
            this.labelTipoHeader.StylePriority.UseFont = false;
            this.labelTipoHeader.StylePriority.UseTextAlignment = false;
            this.labelTipoHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelFamiliaHeader
            // 
            this.labelFamiliaHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelFamiliaHeader.Dpi = 100F;
            this.labelFamiliaHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFamiliaHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.7F, 168F);
            this.labelFamiliaHeader.Name = "labelFamiliaHeader";
            this.labelFamiliaHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFamiliaHeader.SizeF = new System.Drawing.SizeF(403.34F, 16F);
            this.labelFamiliaHeader.StylePriority.UseBorders = false;
            this.labelFamiliaHeader.StylePriority.UseFont = false;
            this.labelFamiliaHeader.StylePriority.UseTextAlignment = false;
            this.labelFamiliaHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel234
            // 
            this.xrLabel234.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel234.Dpi = 100F;
            this.xrLabel234.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel234.LocationFloat = new DevExpress.Utils.PointFloat(0F, 168F);
            this.xrLabel234.Name = "xrLabel234";
            this.xrLabel234.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel234.SizeF = new System.Drawing.SizeF(140.62F, 16F);
            this.xrLabel234.StylePriority.UseBorders = false;
            this.xrLabel234.StylePriority.UseFont = false;
            this.xrLabel234.StylePriority.UseTextAlignment = false;
            this.xrLabel234.Text = "Familia";
            this.xrLabel234.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelRutaHeader
            // 
            this.labelRutaHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelRutaHeader.Dpi = 100F;
            this.labelRutaHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRutaHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.7F, 151F);
            this.labelRutaHeader.Name = "labelRutaHeader";
            this.labelRutaHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelRutaHeader.SizeF = new System.Drawing.SizeF(403.84F, 16F);
            this.labelRutaHeader.StylePriority.UseBorders = false;
            this.labelRutaHeader.StylePriority.UseFont = false;
            this.labelRutaHeader.StylePriority.UseTextAlignment = false;
            this.labelRutaHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 151F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(140.62F, 16F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Ruta";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelFechaHeader
            // 
            this.labelFechaHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelFechaHeader.Dpi = 100F;
            this.labelFechaHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.7F, 134F);
            this.labelFechaHeader.Name = "labelFechaHeader";
            this.labelFechaHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFechaHeader.SizeF = new System.Drawing.SizeF(403.84F, 16F);
            this.labelFechaHeader.StylePriority.UseBorders = false;
            this.labelFechaHeader.StylePriority.UseFont = false;
            this.labelFechaHeader.StylePriority.UseTextAlignment = false;
            this.labelFechaHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCEDIHeader
            // 
            this.labelCEDIHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCEDIHeader.Dpi = 100F;
            this.labelCEDIHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCEDIHeader.LocationFloat = new DevExpress.Utils.PointFloat(144.7F, 117F);
            this.labelCEDIHeader.Name = "labelCEDIHeader";
            this.labelCEDIHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCEDIHeader.SizeF = new System.Drawing.SizeF(403.84F, 16F);
            this.labelCEDIHeader.StylePriority.UseBorders = false;
            this.labelCEDIHeader.StylePriority.UseFont = false;
            this.labelCEDIHeader.StylePriority.UseTextAlignment = false;
            this.labelCEDIHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(0F, 134F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(140.62F, 16F);
            this.xrLabel25.StylePriority.UseBorders = false;
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Fecha Pedido";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0F, 117F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(140.62F, 16F);
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Centro de Distribucion";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.xrSubreportResumen});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 41.66667F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrSubreportResumen
            // 
            this.xrSubreportResumen.CanShrink = true;
            this.xrSubreportResumen.Dpi = 100F;
            this.xrSubreportResumen.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreportResumen.Name = "xrSubreportResumen";
            this.xrSubreportResumen.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportResumen.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreportCodigo});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 41.66667F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrSubreportCodigo
            // 
            this.xrSubreportCodigo.CanShrink = true;
            this.xrSubreportCodigo.Dpi = 100F;
            this.xrSubreportCodigo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.625008F);
            this.xrSubreportCodigo.Name = "xrSubreportCodigo";
            this.xrSubreportCodigo.SizeF = new System.Drawing.SizeF(823.5F, 40.04166F);
            this.xrSubreportCodigo.SnapLineMargin = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 1, 1, 100F);
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(179.25F, 4.999987F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(355.75F, 69.99998F);
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
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(355.75F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReporteVentasporCodigoDetalladoUNI
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 260, 70);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
