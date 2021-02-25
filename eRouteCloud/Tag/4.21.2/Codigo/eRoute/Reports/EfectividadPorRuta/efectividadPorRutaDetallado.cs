using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for efectividadPorRutaDetallado
/// </summary>
public class efectividadPorRutaDetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRPictureBox logo1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    public XRLabel CEDIS;
    public XRLabel Fecha;
    public XRLabel Vendedor;
    public XRLabel Ruta;
    private XRLine xrLine1;
    private PageHeaderBand PageHeader;
    private XRLine xrLine2;
    private XRLine xrLine3;
    public XRLabel xrLabel18;
    public XRLabel xrLabel19;
    public XRLabel xrLabel20;
    public XRLabel xrLabel23;
    public XRLabel xrLabel22;
    public XRLabel xrLabel21;
    private GroupHeaderBand GroupHeader1;
    public XRLabel tiempoTransito;
    public XRLabel tiempoVisita;
    public XRLabel tiempoRecorrido;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    public XRLabel lbRuta;
    public XRLabel lbVendedor;
    public XRLabel lbFecha;
    public XRLabel lbCEDIS;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    public XRSubreport sub17;
    private PageFooterBand PageFooter;
    private GroupHeaderBand GroupHeader2;
    private GroupHeaderBand GroupHeader3;
    private GroupHeaderBand GroupHeader4;
    private GroupHeaderBand GroupHeader5;
    private GroupHeaderBand GroupHeader6;
    private GroupHeaderBand GroupHeader7;
    private GroupHeaderBand GroupHeader8;
    private GroupHeaderBand GroupHeader9;
    private GroupHeaderBand GroupHeader10;
    private GroupHeaderBand GroupHeader11;
    private GroupHeaderBand GroupHeader12;
    private GroupHeaderBand GroupHeader13;
    private GroupHeaderBand GroupHeader14;
    private GroupHeaderBand GroupHeader15;
    private GroupHeaderBand GroupHeader16;
    public XRSubreport sub14;
    public XRSubreport sub13;
    public XRSubreport sub12;
    public XRSubreport sub11;
    public XRSubreport sub10;
    public XRSubreport sub9;
    public XRSubreport sub8;
    public XRSubreport sub7;
    public XRSubreport sub6;
    public XRSubreport sub5;
    public XRSubreport sub4;
    public XRSubreport sub3;
    public XRSubreport sub2;
    public XRSubreport sub1;
    private GroupHeaderBand GroupHeader17;
    public XRSubreport sub16;
    private GroupHeaderBand GroupHeader18;
    public XRSubreport sub15;
    private XRLabel xrLabel13;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public efectividadPorRutaDetallado()
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
            this.logo1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.CEDIS = new DevExpress.XtraReports.UI.XRLabel();
            this.Fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.Vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.Ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.sub17 = new DevExpress.XtraReports.UI.XRSubreport();
            this.tiempoTransito = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempoVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.tiempoRecorrido = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.lbVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCEDIS = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader6 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader7 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader8 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader9 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader10 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader11 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader12 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader13 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader14 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader15 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader16 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.sub1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub2 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub3 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub4 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub5 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub6 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub7 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub8 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub9 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub10 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub11 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub12 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub13 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub14 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader17 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader18 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.sub15 = new DevExpress.XtraReports.UI.XRSubreport();
            this.sub16 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 2.848707F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo1,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.CEDIS,
            this.Fecha,
            this.Vendedor,
            this.Ruta,
            this.xrLine1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 198.9583F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // logo1
            // 
            this.logo1.Dpi = 100F;
            this.logo1.LocationFloat = new DevExpress.Utils.PointFloat(22.99484F, 3.562469F);
            this.logo1.Name = "logo1";
            this.logo1.SizeF = new System.Drawing.SizeF(99.99998F, 61.25001F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(154.8283F, 16.56246F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(473.3124F, 48.25001F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "CONSERVAS LA COSTEÑA S.A. DE C.V.\r\nEfectividad Por Ruta (Detallado)\r\n";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(21.61981F, 90.39579F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(133.3333F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Centro de Distribucion";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(22.99484F, 113.3958F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Fecha";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(22.99484F, 136.3958F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Vendedor";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(22.99484F, 159.3958F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Ruta";
            // 
            // CEDIS
            // 
            this.CEDIS.Dpi = 100F;
            this.CEDIS.LocationFloat = new DevExpress.Utils.PointFloat(154.9531F, 90.39579F);
            this.CEDIS.Name = "CEDIS";
            this.CEDIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CEDIS.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // Fecha
            // 
            this.Fecha.Dpi = 100F;
            this.Fecha.LocationFloat = new DevExpress.Utils.PointFloat(154.9532F, 113.3958F);
            this.Fecha.Name = "Fecha";
            this.Fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Fecha.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // Vendedor
            // 
            this.Vendedor.Dpi = 100F;
            this.Vendedor.LocationFloat = new DevExpress.Utils.PointFloat(154.9532F, 136.3958F);
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Vendedor.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // Ruta
            // 
            this.Ruta.Dpi = 100F;
            this.Ruta.LocationFloat = new DevExpress.Utils.PointFloat(154.9532F, 159.3958F);
            this.Ruta.Name = "Ruta";
            this.Ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Ruta.SizeF = new System.Drawing.SizeF(592.7084F, 23F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(21.61981F, 182.3959F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(776.7604F, 13F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLine3,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel21});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 100F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(22.40616F, 16.50001F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(725.1251F, 10.5F);
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(22.86452F, 73F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(725.1251F, 10.5F);
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(647.9896F, 27F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Fuera de Agenda";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(597.5938F, 49.99999F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Cantidad";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(697.5939F, 49.99999F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Porcentaje";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(496.1873F, 49.99999F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Porcentaje";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(396.1873F, 49.99999F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Cantidad";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(446.5832F, 27F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "En Agenda";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub17});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 35.93481F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // sub17
            // 
            this.sub17.Dpi = 100F;
            this.sub17.LocationFloat = new DevExpress.Utils.PointFloat(45.96849F, 0F);
            this.sub17.Name = "sub17";
            this.sub17.SizeF = new System.Drawing.SizeF(355.5638F, 35.93481F);
            // 
            // tiempoTransito
            // 
            this.tiempoTransito.Dpi = 100F;
            this.tiempoTransito.LocationFloat = new DevExpress.Utils.PointFloat(198.7307F, 154.8987F);
            this.tiempoTransito.Name = "tiempoTransito";
            this.tiempoTransito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoTransito.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // tiempoVisita
            // 
            this.tiempoVisita.Dpi = 100F;
            this.tiempoVisita.LocationFloat = new DevExpress.Utils.PointFloat(198.7307F, 131.8987F);
            this.tiempoVisita.Name = "tiempoVisita";
            this.tiempoVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoVisita.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // tiempoRecorrido
            // 
            this.tiempoRecorrido.Dpi = 100F;
            this.tiempoRecorrido.LocationFloat = new DevExpress.Utils.PointFloat(198.7307F, 108.8988F);
            this.tiempoRecorrido.Name = "tiempoRecorrido";
            this.tiempoRecorrido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tiempoRecorrido.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(87.74109F, 154.8987F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "Tiempo Transito";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(87.74109F, 131.8987F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "Tiempo Visita";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(86.82439F, 108.8988F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(111.9062F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Tiempo Recorrido";
            // 
            // lbRuta
            // 
            this.lbRuta.Dpi = 100F;
            this.lbRuta.LocationFloat = new DevExpress.Utils.PointFloat(249.3244F, 74.35717F);
            this.lbRuta.Name = "lbRuta";
            this.lbRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbRuta.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // lbVendedor
            // 
            this.lbVendedor.Dpi = 100F;
            this.lbVendedor.LocationFloat = new DevExpress.Utils.PointFloat(249.3244F, 51.35716F);
            this.lbVendedor.Name = "lbVendedor";
            this.lbVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbVendedor.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // lbFecha
            // 
            this.lbFecha.Dpi = 100F;
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(249.3244F, 28.35715F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // lbCEDIS
            // 
            this.lbCEDIS.Dpi = 100F;
            this.lbCEDIS.LocationFloat = new DevExpress.Utils.PointFloat(249.3244F, 5.357143F);
            this.lbCEDIS.Name = "lbCEDIS";
            this.lbCEDIS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCEDIS.SizeF = new System.Drawing.SizeF(542.1146F, 23F);
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(139.8244F, 74.35717F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Ruta";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(112.7411F, 51.35716F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Vendedor";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(65.39733F, 5.357143F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(147.3437F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "Centro de Distribucion";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(87.74106F, 28.35715F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Fecha";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 34.96726F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel8,
            this.xrLabel9,
            this.lbCEDIS,
            this.lbFecha,
            this.lbVendedor,
            this.lbRuta,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel12,
            this.tiempoRecorrido,
            this.tiempoVisita,
            this.tiempoTransito});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 177.8987F;
            this.GroupHeader2.Level = 17;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub14});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 53.57143F;
            this.GroupHeader3.Level = 3;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub13});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 48.24048F;
            this.GroupHeader4.Level = 4;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub12});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 46.42861F;
            this.GroupHeader5.Level = 5;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // GroupHeader6
            // 
            this.GroupHeader6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub11});
            this.GroupHeader6.Dpi = 100F;
            this.GroupHeader6.HeightF = 39.28571F;
            this.GroupHeader6.Level = 6;
            this.GroupHeader6.Name = "GroupHeader6";
            // 
            // GroupHeader7
            // 
            this.GroupHeader7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub10});
            this.GroupHeader7.Dpi = 100F;
            this.GroupHeader7.HeightF = 39.28575F;
            this.GroupHeader7.Level = 7;
            this.GroupHeader7.Name = "GroupHeader7";
            // 
            // GroupHeader8
            // 
            this.GroupHeader8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub9});
            this.GroupHeader8.Dpi = 100F;
            this.GroupHeader8.HeightF = 39.28572F;
            this.GroupHeader8.Level = 8;
            this.GroupHeader8.Name = "GroupHeader8";
            // 
            // GroupHeader9
            // 
            this.GroupHeader9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub8});
            this.GroupHeader9.Dpi = 100F;
            this.GroupHeader9.HeightF = 42.85714F;
            this.GroupHeader9.Level = 9;
            this.GroupHeader9.Name = "GroupHeader9";
            // 
            // GroupHeader10
            // 
            this.GroupHeader10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub7});
            this.GroupHeader10.Dpi = 100F;
            this.GroupHeader10.HeightF = 40.58636F;
            this.GroupHeader10.Level = 10;
            this.GroupHeader10.Name = "GroupHeader10";
            // 
            // GroupHeader11
            // 
            this.GroupHeader11.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub6});
            this.GroupHeader11.Dpi = 100F;
            this.GroupHeader11.HeightF = 29.71686F;
            this.GroupHeader11.Level = 11;
            this.GroupHeader11.Name = "GroupHeader11";
            // 
            // GroupHeader12
            // 
            this.GroupHeader12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub5});
            this.GroupHeader12.Dpi = 100F;
            this.GroupHeader12.HeightF = 35.71429F;
            this.GroupHeader12.Level = 12;
            this.GroupHeader12.Name = "GroupHeader12";
            // 
            // GroupHeader13
            // 
            this.GroupHeader13.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub4});
            this.GroupHeader13.Dpi = 100F;
            this.GroupHeader13.HeightF = 36.47742F;
            this.GroupHeader13.Level = 13;
            this.GroupHeader13.Name = "GroupHeader13";
            // 
            // GroupHeader14
            // 
            this.GroupHeader14.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub3});
            this.GroupHeader14.Dpi = 100F;
            this.GroupHeader14.HeightF = 34.28204F;
            this.GroupHeader14.Level = 14;
            this.GroupHeader14.Name = "GroupHeader14";
            // 
            // GroupHeader15
            // 
            this.GroupHeader15.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub2});
            this.GroupHeader15.Dpi = 100F;
            this.GroupHeader15.HeightF = 32.14286F;
            this.GroupHeader15.Level = 15;
            this.GroupHeader15.Name = "GroupHeader15";
            // 
            // GroupHeader16
            // 
            this.GroupHeader16.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub1});
            this.GroupHeader16.Dpi = 100F;
            this.GroupHeader16.HeightF = 28.57143F;
            this.GroupHeader16.Level = 16;
            this.GroupHeader16.Name = "GroupHeader16";
            // 
            // sub1
            // 
            this.sub1.Dpi = 100F;
            this.sub1.LocationFloat = new DevExpress.Utils.PointFloat(52.47309F, 0.9661136F);
            this.sub1.Name = "sub1";
            this.sub1.SizeF = new System.Drawing.SizeF(364.6578F, 27.60532F);
            // 
            // sub2
            // 
            this.sub2.Dpi = 100F;
            this.sub2.LocationFloat = new DevExpress.Utils.PointFloat(51.70998F, 0.7529881F);
            this.sub2.Name = "sub2";
            this.sub2.SizeF = new System.Drawing.SizeF(365.4209F, 31.38983F);
            // 
            // sub3
            // 
            this.sub3.Dpi = 100F;
            this.sub3.LocationFloat = new DevExpress.Utils.PointFloat(51.27129F, 0F);
            this.sub3.Name = "sub3";
            this.sub3.SizeF = new System.Drawing.SizeF(365.8596F, 34.28204F);
            // 
            // sub4
            // 
            this.sub4.Dpi = 100F;
            this.sub4.LocationFloat = new DevExpress.Utils.PointFloat(52.47309F, 0F);
            this.sub4.Name = "sub4";
            this.sub4.SizeF = new System.Drawing.SizeF(365.1513F, 36.47742F);
            // 
            // sub5
            // 
            this.sub5.Dpi = 100F;
            this.sub5.LocationFloat = new DevExpress.Utils.PointFloat(51.27129F, 1.700775F);
            this.sub5.Name = "sub5";
            this.sub5.SizeF = new System.Drawing.SizeF(363.0368F, 34.01352F);
            // 
            // sub6
            // 
            this.sub6.Dpi = 100F;
            this.sub6.LocationFloat = new DevExpress.Utils.PointFloat(50.1623F, 0F);
            this.sub6.Name = "sub6";
            this.sub6.SizeF = new System.Drawing.SizeF(364.1458F, 29.71686F);
            // 
            // sub7
            // 
            this.sub7.Dpi = 100F;
            this.sub7.LocationFloat = new DevExpress.Utils.PointFloat(50.1623F, 0F);
            this.sub7.Name = "sub7";
            this.sub7.SizeF = new System.Drawing.SizeF(362.1458F, 40.58636F);
            // 
            // sub8
            // 
            this.sub8.Dpi = 100F;
            this.sub8.LocationFloat = new DevExpress.Utils.PointFloat(53.1463F, 1.183883F);
            this.sub8.Name = "sub8";
            this.sub8.SizeF = new System.Drawing.SizeF(361.1618F, 41.67322F);
            // 
            // sub9
            // 
            this.sub9.Dpi = 100F;
            this.sub9.LocationFloat = new DevExpress.Utils.PointFloat(53.1463F, 0F);
            this.sub9.Name = "sub9";
            this.sub9.SizeF = new System.Drawing.SizeF(361.2923F, 38.41248F);
            // 
            // sub10
            // 
            this.sub10.Dpi = 100F;
            this.sub10.LocationFloat = new DevExpress.Utils.PointFloat(50.1623F, 0.8731511F);
            this.sub10.Name = "sub10";
            this.sub10.SizeF = new System.Drawing.SizeF(361.0314F, 38.4126F);
            // 
            // sub11
            // 
            this.sub11.Dpi = 100F;
            this.sub11.LocationFloat = new DevExpress.Utils.PointFloat(50.1623F, 0.4201972F);
            this.sub11.Name = "sub11";
            this.sub11.SizeF = new System.Drawing.SizeF(359.2922F, 38.86548F);
            // 
            // sub12
            // 
            this.sub12.Dpi = 100F;
            this.sub12.LocationFloat = new DevExpress.Utils.PointFloat(46.46471F, 0.2715069F);
            this.sub12.Name = "sub12";
            this.sub12.SizeF = new System.Drawing.SizeF(362.9898F, 46.1571F);
            // 
            // sub13
            // 
            this.sub13.Dpi = 100F;
            this.sub13.LocationFloat = new DevExpress.Utils.PointFloat(46.16792F, 0F);
            this.sub13.Name = "sub13";
            this.sub13.SizeF = new System.Drawing.SizeF(363.2866F, 48.24048F);
            // 
            // sub14
            // 
            this.sub14.Dpi = 100F;
            this.sub14.LocationFloat = new DevExpress.Utils.PointFloat(45.96849F, 3.664349F);
            this.sub14.Name = "sub14";
            this.sub14.SizeF = new System.Drawing.SizeF(363.486F, 39.9071F);
            // 
            // GroupHeader17
            // 
            this.GroupHeader17.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub16});
            this.GroupHeader17.Dpi = 100F;
            this.GroupHeader17.HeightF = 41.07145F;
            this.GroupHeader17.Level = 1;
            this.GroupHeader17.Name = "GroupHeader17";
            // 
            // GroupHeader18
            // 
            this.GroupHeader18.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sub15});
            this.GroupHeader18.Dpi = 100F;
            this.GroupHeader18.HeightF = 42.85716F;
            this.GroupHeader18.Level = 2;
            this.GroupHeader18.Name = "GroupHeader18";
            // 
            // sub15
            // 
            this.sub15.Dpi = 100F;
            this.sub15.LocationFloat = new DevExpress.Utils.PointFloat(45.96849F, 0.8207404F);
            this.sub15.Name = "sub15";
            this.sub15.SizeF = new System.Drawing.SizeF(358.328F, 42.0364F);
            // 
            // sub16
            // 
            this.sub16.Dpi = 100F;
            this.sub16.LocationFloat = new DevExpress.Utils.PointFloat(45.96849F, 1.564855F);
            this.sub16.Name = "sub16";
            this.sub16.SizeF = new System.Drawing.SizeF(358.328F, 39.50659F);
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(249.3244F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // efectividadPorRutaDetallado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.PageFooter,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.GroupHeader5,
            this.GroupHeader6,
            this.GroupHeader7,
            this.GroupHeader8,
            this.GroupHeader9,
            this.GroupHeader10,
            this.GroupHeader11,
            this.GroupHeader12,
            this.GroupHeader13,
            this.GroupHeader14,
            this.GroupHeader15,
            this.GroupHeader16,
            this.GroupHeader17,
            this.GroupHeader18});
            this.Margins = new System.Drawing.Printing.Margins(14, 16, 199, 0);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
