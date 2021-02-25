using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class SubReporteDevCam : DevExpress.XtraReports.UI.XtraReport
{
    public DetailBand DetailReportClientes;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private DevExpress.XtraReports.Parameters.Parameter VendedorId;
    private DevExpress.XtraReports.Parameters.Parameter FechaHoraAlta;
    private GroupFooterBand GroupFooter2;
    private GroupFooterBand GroupFooter1;
    private XRLabel xrLabel25;
    private XRLabel xrLabel30;
    public XRLabel xrLabel29;
    private XRLabel xrLabel28;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private XRLabel xrLabel31;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    private XRLine xrLine5;
    private XRLabel xrLabel22;
    private XRLine xrLine4;
    private XRLabel xrLabel21;
    public XRLabel xrLabel44;
    public XRLabel xrLabel66;
    private XRLabel xrLabel14;
    public XRLabel xrLabel55;
    public XRLabel xrLabel33;
    public XRLabel xrLabe22;
    public XRLabel xrLabel11;
    private XRLine xrLine1;
    public XRLabel dClave;
    public XRLabel dcCambio;
    public XRLabel dcImporte;
    public XRLabel dcCantidad;
    public XRLabel ddImporte;
    public XRLabel ddCantidad;
    public XRLabel dUnidad;
    public XRLabel dProducto;
    public XRLabel dcMotivo;
    public GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteDevCam()
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
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.VendedorId = new DevExpress.XtraReports.Parameters.Parameter();
            this.FechaHoraAlta = new DevExpress.XtraReports.Parameters.Parameter();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabe22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.dcMotivo = new DevExpress.XtraReports.UI.XRLabel();
            this.dProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.dUnidad = new DevExpress.XtraReports.UI.XRLabel();
            this.ddCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.ddImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dcCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dcImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.dcCambio = new DevExpress.XtraReports.UI.XRLabel();
            this.dClave = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // DetailReportClientes
            // 
            this.DetailReportClientes.Dpi = 100F;
            this.DetailReportClientes.HeightF = 0F;
            this.DetailReportClientes.Name = "DetailReportClientes";
            this.DetailReportClientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailReportClientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel25,
            this.xrLabel30,
            this.xrLabel29,
            this.xrLabel28,
            this.xrLabel27,
            this.xrLabel26,
            this.xrLabel31,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLine5,
            this.xrLabel22,
            this.xrLine4,
            this.xrLabel21});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 33.99999F;
            this.PageHeader.Name = "PageHeader";
            // 
            // VendedorId
            // 
            this.VendedorId.Description = "VendedorID";
            this.VendedorId.Name = "VendedorId";
            // 
            // FechaHoraAlta
            // 
            this.FechaHoraAlta.Description = "FechaHoraAlta";
            this.FechaHoraAlta.Name = "FechaHoraAlta";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel44,
            this.xrLabel66,
            this.xrLabel14,
            this.xrLabel55,
            this.xrLabel33,
            this.xrLabe22,
            this.xrLabel11,
            this.xrLine1});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 20F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.dClave,
            this.dcCambio,
            this.dcImporte,
            this.dcCantidad,
            this.ddImporte,
            this.ddCantidad,
            this.dUnidad,
            this.dProducto,
            this.dcMotivo});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 15F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 0F;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 0F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(80F, 2F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(410F, 30F);
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Producto";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1080F, 2F);
            // 
            // xrLabel22
            // 
            this.xrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(80F, 30F);
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Clave";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.99999F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(1080F, 2F);
            // 
            // xrLabel23
            // 
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(490F, 2F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(50F, 30F);
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Unidad";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(540F, 2F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(180F, 15F);
            this.xrLabel24.StylePriority.UseBorders = false;
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Devolucion";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(720F, 2F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(360F, 15F);
            this.xrLabel25.StylePriority.UseBorders = false;
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Cambio";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(630F, 17.00002F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "Importe";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(540F, 17.00002F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel27.StylePriority.UseBorders = false;
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Cantidad";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(720F, 17.00002F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel28.StylePriority.UseBorders = false;
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Cantidad";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(810F, 17.00002F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "Importe";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(900F, 16.99999F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "Cambio Por";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(990F, 17.00002F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Importe";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel44
            // 
            this.xrLabel44.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(810F, 2F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel44.StylePriority.UseBorders = false;
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel66
            // 
            this.xrLabel66.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel66.Dpi = 100F;
            this.xrLabel66.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(990F, 2F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel66.StylePriority.UseBorders = false;
            this.xrLabel66.StylePriority.UseFont = false;
            this.xrLabel66.StylePriority.UseTextAlignment = false;
            this.xrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(420.0002F, 2F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(120F, 15F);
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Total De Unidades:";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel55
            // 
            this.xrLabel55.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel55.Dpi = 100F;
            this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(900F, 2F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel55.StylePriority.UseBorders = false;
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(720.0001F, 2F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel33.StylePriority.UseBorders = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabe22
            // 
            this.xrLabe22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabe22.Dpi = 100F;
            this.xrLabe22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabe22.LocationFloat = new DevExpress.Utils.PointFloat(630.0001F, 2F);
            this.xrLabe22.Name = "xrLabe22";
            this.xrLabe22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabe22.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabe22.StylePriority.UseBorders = false;
            this.xrLabe22.StylePriority.UseFont = false;
            this.xrLabe22.StylePriority.UseTextAlignment = false;
            this.xrLabe22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(540.0001F, 2F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(540.0001F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(540F, 2F);
            // 
            // dcMotivo
            // 
            this.dcMotivo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcMotivo.Dpi = 100F;
            this.dcMotivo.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcMotivo.LocationFloat = new DevExpress.Utils.PointFloat(989.9998F, 0F);
            this.dcMotivo.Name = "dcMotivo";
            this.dcMotivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcMotivo.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcMotivo.StylePriority.UseBorders = false;
            this.dcMotivo.StylePriority.UseFont = false;
            this.dcMotivo.StylePriority.UseTextAlignment = false;
            this.dcMotivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dProducto
            // 
            this.dProducto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dProducto.Dpi = 100F;
            this.dProducto.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dProducto.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
            this.dProducto.Name = "dProducto";
            this.dProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dProducto.SizeF = new System.Drawing.SizeF(410F, 15F);
            this.dProducto.StylePriority.UseBorders = false;
            this.dProducto.StylePriority.UseFont = false;
            this.dProducto.StylePriority.UseTextAlignment = false;
            this.dProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dUnidad
            // 
            this.dUnidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dUnidad.Dpi = 100F;
            this.dUnidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dUnidad.LocationFloat = new DevExpress.Utils.PointFloat(489.9999F, 0F);
            this.dUnidad.Name = "dUnidad";
            this.dUnidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dUnidad.SizeF = new System.Drawing.SizeF(50F, 15F);
            this.dUnidad.StylePriority.UseBorders = false;
            this.dUnidad.StylePriority.UseFont = false;
            this.dUnidad.StylePriority.UseTextAlignment = false;
            this.dUnidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ddCantidad
            // 
            this.ddCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddCantidad.Dpi = 100F;
            this.ddCantidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddCantidad.LocationFloat = new DevExpress.Utils.PointFloat(539.9998F, 0F);
            this.ddCantidad.Name = "ddCantidad";
            this.ddCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddCantidad.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.ddCantidad.StylePriority.UseBorders = false;
            this.ddCantidad.StylePriority.UseFont = false;
            this.ddCantidad.StylePriority.UseTextAlignment = false;
            this.ddCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ddImporte
            // 
            this.ddImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ddImporte.Dpi = 100F;
            this.ddImporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ddImporte.LocationFloat = new DevExpress.Utils.PointFloat(629.9998F, 0F);
            this.ddImporte.Name = "ddImporte";
            this.ddImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.ddImporte.StylePriority.UseBorders = false;
            this.ddImporte.StylePriority.UseFont = false;
            this.ddImporte.StylePriority.UseTextAlignment = false;
            this.ddImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // dcCantidad
            // 
            this.dcCantidad.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcCantidad.Dpi = 100F;
            this.dcCantidad.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcCantidad.LocationFloat = new DevExpress.Utils.PointFloat(719.9998F, 0F);
            this.dcCantidad.Name = "dcCantidad";
            this.dcCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcCantidad.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcCantidad.StylePriority.UseBorders = false;
            this.dcCantidad.StylePriority.UseFont = false;
            this.dcCantidad.StylePriority.UseTextAlignment = false;
            this.dcCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcImporte
            // 
            this.dcImporte.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcImporte.Dpi = 100F;
            this.dcImporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcImporte.LocationFloat = new DevExpress.Utils.PointFloat(809.9998F, 0F);
            this.dcImporte.Name = "dcImporte";
            this.dcImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcImporte.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcImporte.StylePriority.UseBorders = false;
            this.dcImporte.StylePriority.UseFont = false;
            this.dcImporte.StylePriority.UseTextAlignment = false;
            this.dcImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dcCambio
            // 
            this.dcCambio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dcCambio.Dpi = 100F;
            this.dcCambio.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dcCambio.LocationFloat = new DevExpress.Utils.PointFloat(899.9998F, 0F);
            this.dcCambio.Name = "dcCambio";
            this.dcCambio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dcCambio.SizeF = new System.Drawing.SizeF(90F, 15F);
            this.dcCambio.StylePriority.UseBorders = false;
            this.dcCambio.StylePriority.UseFont = false;
            this.dcCambio.StylePriority.UseTextAlignment = false;
            this.dcCambio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // dClave
            // 
            this.dClave.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.dClave.Dpi = 100F;
            this.dClave.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dClave.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.dClave.Name = "dClave";
            this.dClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dClave.SizeF = new System.Drawing.SizeF(80F, 15F);
            this.dClave.StylePriority.UseBorders = false;
            this.dClave.StylePriority.UseFont = false;
            this.dClave.StylePriority.UseTextAlignment = false;
            this.dClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // SubReporteDevCam
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailReportClientes,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupFooter1,
            this.GroupHeader1,
            this.GroupFooter2,
            this.GroupHeader2});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.VendedorId,
            this.FechaHoraAlta});
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
