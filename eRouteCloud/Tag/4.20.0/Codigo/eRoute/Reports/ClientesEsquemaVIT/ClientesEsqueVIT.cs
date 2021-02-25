using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for PlanTrabajoSemanal
/// </summary>
public class ClientesEsqueVIT : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel lbClave;
    public XRLabel lbRazonSocial;
    public XRLabel lbNombre;
    public XRLabel lbDomicilio;
    public XRLabel lbColonia;
    public XRLabel lbMunicipio;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel7;
    private XRLine xrLine2;
    private XRLine xrLine1;
    public GroupHeaderBand GroupHeader1;
    public XRLabel lbEsquemas;
    private XRLabel xrLabel2;
    private XRLabel xrLabel6;
    public XRLabel lbEsquema;
    public XRPictureBox logo1;
    private ReportHeaderBand ReportHeader;
    private PageFooterBand PageFooter;
    private XRLabel xrLabel29;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ClientesEsqueVIT()
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
            this.lbClave = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRazonSocial = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDomicilio = new DevExpress.XtraReports.UI.XRLabel();
            this.lbColonia = new DevExpress.XtraReports.UI.XRLabel();
            this.lbMunicipio = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.lbEsquemas = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEsquema = new DevExpress.XtraReports.UI.XRLabel();
            this.logo1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbClave,
            this.lbRazonSocial,
            this.lbNombre,
            this.lbDomicilio,
            this.lbColonia,
            this.lbMunicipio});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 24.13195F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbClave
            // 
            this.lbClave.Dpi = 100F;
            this.lbClave.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lbClave.LocationFloat = new DevExpress.Utils.PointFloat(6.781276F, 1.131948F);
            this.lbClave.Name = "lbClave";
            this.lbClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbClave.SizeF = new System.Drawing.SizeF(71.6424F, 23F);
            this.lbClave.StylePriority.UseFont = false;
            this.lbClave.Text = "Clave";
            // 
            // lbRazonSocial
            // 
            this.lbRazonSocial.Dpi = 100F;
            this.lbRazonSocial.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lbRazonSocial.LocationFloat = new DevExpress.Utils.PointFloat(79.17364F, 1.131948F);
            this.lbRazonSocial.Name = "lbRazonSocial";
            this.lbRazonSocial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbRazonSocial.SizeF = new System.Drawing.SizeF(212.9951F, 23F);
            this.lbRazonSocial.StylePriority.UseFont = false;
            this.lbRazonSocial.Text = "Razon Social";
            // 
            // lbNombre
            // 
            this.lbNombre.Dpi = 100F;
            this.lbNombre.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lbNombre.LocationFloat = new DevExpress.Utils.PointFloat(292.1688F, 1.131948F);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNombre.SizeF = new System.Drawing.SizeF(212.8409F, 23F);
            this.lbNombre.StylePriority.UseFont = false;
            this.lbNombre.Text = "Nombre";
            // 
            // lbDomicilio
            // 
            this.lbDomicilio.Dpi = 100F;
            this.lbDomicilio.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lbDomicilio.LocationFloat = new DevExpress.Utils.PointFloat(505.0096F, 1.131948F);
            this.lbDomicilio.Name = "lbDomicilio";
            this.lbDomicilio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDomicilio.SizeF = new System.Drawing.SizeF(219.6874F, 23F);
            this.lbDomicilio.StylePriority.UseFont = false;
            this.lbDomicilio.Text = "Domicilio";
            // 
            // lbColonia
            // 
            this.lbColonia.Dpi = 100F;
            this.lbColonia.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lbColonia.LocationFloat = new DevExpress.Utils.PointFloat(724.697F, 1.131948F);
            this.lbColonia.Name = "lbColonia";
            this.lbColonia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbColonia.SizeF = new System.Drawing.SizeF(201.9375F, 23F);
            this.lbColonia.StylePriority.UseFont = false;
            this.lbColonia.Text = "Colonia";
            // 
            // lbMunicipio
            // 
            this.lbMunicipio.Dpi = 100F;
            this.lbMunicipio.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lbMunicipio.LocationFloat = new DevExpress.Utils.PointFloat(926.6345F, 1.131948F);
            this.lbMunicipio.Name = "lbMunicipio";
            this.lbMunicipio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbMunicipio.SizeF = new System.Drawing.SizeF(166.3653F, 23F);
            this.lbMunicipio.StylePriority.UseFont = false;
            this.lbMunicipio.Text = "Municipio";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 7F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 4F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel7,
            this.xrLine2,
            this.xrLine1,
            this.xrLabel14});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 46.53413F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(724.4471F, 10.41667F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(202.1875F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "Colonia";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(504.7597F, 10.41667F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(219.6874F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "Domicilio";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(291.9188F, 10.41667F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(212.5909F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Nombre Corto";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(78.92365F, 10.41667F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(212.9952F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Razon Social";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(7.531253F, 10.41667F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(71.3924F, 22.99999F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Clave";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(3.080447F, 33.41668F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1089.945F, 10.41667F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(3.080447F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1086.682F, 10.41667F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(926.8846F, 10.41667F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(162.8778F, 23F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "Municipio";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbEsquemas});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 26.86237F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // lbEsquemas
            // 
            this.lbEsquemas.Dpi = 100F;
            this.lbEsquemas.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbEsquemas.LocationFloat = new DevExpress.Utils.PointFloat(7.031274F, 0F);
            this.lbEsquemas.Name = "lbEsquemas";
            this.lbEsquemas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEsquemas.SizeF = new System.Drawing.SizeF(470.8227F, 23F);
            this.lbEsquemas.StylePriority.UseFont = false;
            this.lbEsquemas.Text = "Esquema";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(201.7187F, 44.80207F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(648.9583F, 48.95835F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Clientes Por Esquema (VITERE)";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(6.781276F, 114.7604F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "Esquema:";
            // 
            // lbEsquema
            // 
            this.lbEsquema.Dpi = 100F;
            this.lbEsquema.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lbEsquema.LocationFloat = new DevExpress.Utils.PointFloat(110.2604F, 114.7604F);
            this.lbEsquema.Name = "lbEsquema";
            this.lbEsquema.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEsquema.SizeF = new System.Drawing.SizeF(476.6949F, 23F);
            this.lbEsquema.StylePriority.UseFont = false;
            // 
            // logo1
            // 
            this.logo1.Dpi = 100F;
            this.logo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 14.32292F);
            this.logo1.Name = "logo1";
            this.logo1.SizeF = new System.Drawing.SizeF(175.5208F, 85.58336F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo1,
            this.xrLabel2,
            this.xrLabel6,
            this.lbEsquema});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 147.1354F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 49.26039F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(746.5933F, 26.26038F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(131.7814F, 23F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.Text = "Fecha Hora Impresión:";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "{0:d/MM/yy hh:mm:ss tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(903.3748F, 23.65621F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(140.1044F, 23.00001F);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(433.8436F, 26.26038F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(44.01041F, 23.00001F);
            // 
            // ClientesEsqueVIT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.ReportHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(6, 1, 7, 4);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
