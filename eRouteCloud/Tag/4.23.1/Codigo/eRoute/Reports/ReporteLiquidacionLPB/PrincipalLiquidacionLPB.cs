using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for PrincipalLiquidacionBRA
/// </summary>
public class PrincipalLiquidacionLPB : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    private PageHeaderBand PageHeader;
    public XRSubreport subre6;
    private GroupHeaderBand GroupHeader2;
    public XRSubreport subre5;
    private GroupHeaderBand GroupHeader3;
    public XRSubreport subre4;
    private GroupHeaderBand GroupHeader4;
    public XRSubreport subre3;
    private GroupHeaderBand GroupHeader5;
    public XRSubreport subre2;
    private GroupHeaderBand GroupHeader6;
    public XRSubreport subre1;
    private GroupHeaderBand GroupHeader8;
    public XRSubreport subre7;
    public XRLabel empresa;
    public XRLabel vendedor;
    public XRLabel fecha;
    public XRLabel centro;
    public XRLabel xrLabel71;
    public XRLabel xrLabel70;
    public XRLabel xrLabel69;
    public XRLabel reporte;
    public XRPictureBox logo;
    public XRLabel xrLabel14;
    public XRLabel xrLabel17;
    public XRLabel domicilio;
    public XRLabel telefono;
    public XRLabel ruta;
    public XRLabel xrLabel19;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PrincipalLiquidacionLPB()
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
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subre6 = new DevExpress.XtraReports.UI.XRSubreport();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subre5 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subre4 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subre3 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subre2 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader6 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subre1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader8 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subre7 = new DevExpress.XtraReports.UI.XRSubreport();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.domicilio = new DevExpress.XtraReports.UI.XRLabel();
            this.telefono = new DevExpress.XtraReports.UI.XRLabel();
            this.ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 20.83333F;
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
            this.BottomMargin.HeightF = 17F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subre6});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 28.125F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // subre6
            // 
            this.subre6.Dpi = 100F;
            this.subre6.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.subre6.Name = "subre6";
            this.subre6.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.empresa,
            this.vendedor,
            this.fecha,
            this.centro,
            this.xrLabel71,
            this.xrLabel70,
            this.xrLabel69,
            this.reporte,
            this.logo,
            this.xrLabel14,
            this.xrLabel17,
            this.domicilio,
            this.telefono,
            this.ruta,
            this.xrLabel19});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 185F;
            this.PageHeader.Name = "PageHeader";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subre5});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 28.125F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // subre5
            // 
            this.subre5.Dpi = 100F;
            this.subre5.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.subre5.Name = "subre5";
            this.subre5.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subre4});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 23F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // subre4
            // 
            this.subre4.Dpi = 100F;
            this.subre4.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.subre4.Name = "subre4";
            this.subre4.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subre3});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 23F;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // subre3
            // 
            this.subre3.Dpi = 100F;
            this.subre3.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.subre3.Name = "subre3";
            this.subre3.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subre2});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 27.08333F;
            this.GroupHeader5.Level = 5;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // subre2
            // 
            this.subre2.Dpi = 100F;
            this.subre2.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.subre2.Name = "subre2";
            this.subre2.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupHeader6
            // 
            this.GroupHeader6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subre1});
            this.GroupHeader6.Dpi = 100F;
            this.GroupHeader6.HeightF = 27.16665F;
            this.GroupHeader6.Level = 6;
            this.GroupHeader6.Name = "GroupHeader6";
            // 
            // subre1
            // 
            this.subre1.Dpi = 100F;
            this.subre1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.subre1.Name = "subre1";
            this.subre1.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // GroupHeader8
            // 
            this.GroupHeader8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subre7});
            this.GroupHeader8.Dpi = 100F;
            this.GroupHeader8.HeightF = 24.43182F;
            this.GroupHeader8.Level = 4;
            this.GroupHeader8.Name = "GroupHeader8";
            // 
            // subre7
            // 
            this.subre7.Dpi = 100F;
            this.subre7.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.subre7.Name = "subre7";
            this.subre7.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(175F, 15F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // vendedor
            // 
            this.vendedor.Dpi = 100F;
            this.vendedor.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.vendedor.LocationFloat = new DevExpress.Utils.PointFloat(155F, 155F);
            this.vendedor.Name = "vendedor";
            this.vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vendedor.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.vendedor.StylePriority.UseFont = false;
            this.vendedor.StylePriority.UseTextAlignment = false;
            this.vendedor.Text = "vendedor";
            this.vendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fecha
            // 
            this.fecha.Dpi = 100F;
            this.fecha.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(155F, 140F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.fecha.StylePriority.UseFont = false;
            this.fecha.StylePriority.UseTextAlignment = false;
            this.fecha.Text = "fecha";
            this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // centro
            // 
            this.centro.Dpi = 100F;
            this.centro.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(405F, 95F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.centro.StylePriority.UseFont = false;
            this.centro.StylePriority.UseTextAlignment = false;
            this.centro.Text = "centro";
            this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel71
            // 
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(5F, 155F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.StylePriority.UseTextAlignment = false;
            this.xrLabel71.Text = "Vendedor:";
            this.xrLabel71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel70
            // 
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(5F, 140F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.Text = "Fecha:";
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel69
            // 
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(255F, 95F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "Centro De Distribución:";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(175F, 55F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(20F, 15F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(255F, 110F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "Domicilio:";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(255F, 125F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "Telefono:";
            // 
            // domicilio
            // 
            this.domicilio.Dpi = 100F;
            this.domicilio.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.domicilio.LocationFloat = new DevExpress.Utils.PointFloat(405F, 110F);
            this.domicilio.Name = "domicilio";
            this.domicilio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.domicilio.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.domicilio.StylePriority.UseFont = false;
            this.domicilio.Text = "domicilio";
            // 
            // telefono
            // 
            this.telefono.Dpi = 100F;
            this.telefono.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.telefono.LocationFloat = new DevExpress.Utils.PointFloat(405F, 125F);
            this.telefono.Name = "telefono";
            this.telefono.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.telefono.SizeF = new System.Drawing.SizeF(200F, 15F);
            this.telefono.StylePriority.UseFont = false;
            this.telefono.Text = "telefono";
            // 
            // ruta
            // 
            this.ruta.Dpi = 100F;
            this.ruta.LocationFloat = new DevExpress.Utils.PointFloat(155F, 170F);
            this.ruta.Name = "ruta";
            this.ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ruta.SizeF = new System.Drawing.SizeF(680F, 15F);
            this.ruta.Text = "ruta";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(5F, 170F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Ruta:";
            // 
            // PrincipalLiquidacionLPB
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.PageHeader,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.GroupHeader5,
            this.GroupHeader6,
            this.GroupHeader8});
            this.Margins = new System.Drawing.Printing.Margins(3, 7, 4, 17);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
