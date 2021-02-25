using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class AnalisisSaldosMOODetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRPictureBox xrPictureBox1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel20;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel2;
    public XRLabel labelclienteheader;
    public XRLabel headerlabelcedis;
    public XRLabel labelfechaheader;
    public XRLabel labelvendedorheader;
    public XRLabel labelrutasheader;
    private XRLine xrLine1;
    private XRLine xrLine2;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel36;
    private XRLabel xrLabel8;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    public GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel7;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    public XRLabel cediClave;
    public XRLabel vendedorNombre;
    public XRLabel usuClave;
    public XRLabel rutaDescripcion;
    public XRLabel rutaClave;
    public XRLabel cediNombre;
    public XRLabel vClave;
    public XRLabel vRazonSocial;
    public XRLabel vNombreContacto;
    public XRLabel vFecha;
    public XRLabel vFolio;
    public XRLabel vCredito;
    public XRLabel vConsignacion;
    public XRLabel vTotal;
    private GroupFooterBand GroupFooter1;
    private GroupFooterBand GroupFooter2;
    private GroupFooterBand GroupFooter3;
    public XRLabel vEnvase;
    private XRLabel xrLabel11;
    public GroupHeaderBand GroupHeader4;
    public XRLabel vCreditoTotal;
    private XRLabel xrLabel12;
    private GroupFooterBand GroupFooter4;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    public XRLabel CreditoVen;
    public XRLabel ConsignacionVen;
    public XRLabel TotalVen;
    public XRLabel EnvaseVen;
    public XRLabel CreditoRut;
    public XRLabel ConsignacionRut;
    public XRLabel TotalRut;
    public XRLabel EnvaseRut;
    public XRLabel CreditoCEDI;
    public XRLabel ConsignacionCEDI;
    public XRLabel TotalCEDI;
    public XRLabel EnvaseCEDI;
    private ReportFooterBand ReportFooter;
    public XRLabel CreditoGTotal;
    public XRLabel ConsignacionGtotal;
    public XRLabel GTotal;
    public XRLabel EnvaseGTotal;
    private XRLabel xrLabel16;
    public XRSubreport xrSubreport1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public AnalisisSaldosMOODetallado()
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
            this.vFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.vFolio = new DevExpress.XtraReports.UI.XRLabel();
            this.vCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.vNombreContacto = new DevExpress.XtraReports.UI.XRLabel();
            this.vRazonSocial = new DevExpress.XtraReports.UI.XRLabel();
            this.vClave = new DevExpress.XtraReports.UI.XRLabel();
            this.vConsignacion = new DevExpress.XtraReports.UI.XRLabel();
            this.vTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelclienteheader = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelcedis = new DevExpress.XtraReports.UI.XRLabel();
            this.labelfechaheader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelvendedorheader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.labelrutasheader = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.vendedorNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.usuClave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.rutaDescripcion = new DevExpress.XtraReports.UI.XRLabel();
            this.rutaClave = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cediNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.cediClave = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.vCreditoTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.vEnvase = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.CreditoVen = new DevExpress.XtraReports.UI.XRLabel();
            this.ConsignacionVen = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalVen = new DevExpress.XtraReports.UI.XRLabel();
            this.EnvaseVen = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.CreditoRut = new DevExpress.XtraReports.UI.XRLabel();
            this.ConsignacionRut = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalRut = new DevExpress.XtraReports.UI.XRLabel();
            this.EnvaseRut = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.CreditoCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.ConsignacionCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.EnvaseCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.CreditoGTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.ConsignacionGtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.GTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.EnvaseGTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vFecha,
            this.vFolio,
            this.vCredito,
            this.vNombreContacto,
            this.vRazonSocial,
            this.vClave});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 29.16667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vFecha
            // 
            this.vFecha.Dpi = 100F;
            this.vFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vFecha.LocationFloat = new DevExpress.Utils.PointFloat(573.2338F, 2.562428F);
            this.vFecha.Multiline = true;
            this.vFecha.Name = "vFecha";
            this.vFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vFecha.SizeF = new System.Drawing.SizeF(84.75256F, 22.99991F);
            this.vFecha.StylePriority.UseFont = false;
            this.vFecha.StylePriority.UseTextAlignment = false;
            this.vFecha.Text = "Fecha";
            this.vFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vFolio
            // 
            this.vFolio.Dpi = 100F;
            this.vFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vFolio.LocationFloat = new DevExpress.Utils.PointFloat(671.1107F, 2.562491F);
            this.vFolio.Multiline = true;
            this.vFolio.Name = "vFolio";
            this.vFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vFolio.SizeF = new System.Drawing.SizeF(89.26428F, 23.00003F);
            this.vFolio.StylePriority.UseFont = false;
            this.vFolio.StylePriority.UseTextAlignment = false;
            this.vFolio.Text = "Folio";
            this.vFolio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vCredito
            // 
            this.vCredito.Dpi = 100F;
            this.vCredito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vCredito.LocationFloat = new DevExpress.Utils.PointFloat(760.875F, 2.561824F);
            this.vCredito.Multiline = true;
            this.vCredito.Name = "vCredito";
            this.vCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vCredito.SizeF = new System.Drawing.SizeF(89.78131F, 23.00015F);
            this.vCredito.StylePriority.UseFont = false;
            this.vCredito.StylePriority.UseTextAlignment = false;
            this.vCredito.Text = "Crédito";
            this.vCredito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // vNombreContacto
            // 
            this.vNombreContacto.Dpi = 100F;
            this.vNombreContacto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vNombreContacto.LocationFloat = new DevExpress.Utils.PointFloat(359.4005F, 2.562173F);
            this.vNombreContacto.Name = "vNombreContacto";
            this.vNombreContacto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vNombreContacto.SizeF = new System.Drawing.SizeF(199.75F, 23F);
            this.vNombreContacto.StylePriority.UseFont = false;
            this.vNombreContacto.Text = "Nombre Contacto";
            // 
            // vRazonSocial
            // 
            this.vRazonSocial.Dpi = 100F;
            this.vRazonSocial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vRazonSocial.LocationFloat = new DevExpress.Utils.PointFloat(91.50005F, 2.561982F);
            this.vRazonSocial.Name = "vRazonSocial";
            this.vRazonSocial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vRazonSocial.SizeF = new System.Drawing.SizeF(253.8171F, 23F);
            this.vRazonSocial.StylePriority.UseFont = false;
            this.vRazonSocial.Text = "Razon Social";
            // 
            // vClave
            // 
            this.vClave.Dpi = 100F;
            this.vClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vClave.LocationFloat = new DevExpress.Utils.PointFloat(2.500041F, 2.562046F);
            this.vClave.Multiline = true;
            this.vClave.Name = "vClave";
            this.vClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vClave.SizeF = new System.Drawing.SizeF(65.62501F, 22.99996F);
            this.vClave.StylePriority.UseFont = false;
            this.vClave.StylePriority.UseTextAlignment = false;
            this.vClave.Text = "Clave";
            this.vClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // vConsignacion
            // 
            this.vConsignacion.Dpi = 100F;
            this.vConsignacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vConsignacion.LocationFloat = new DevExpress.Utils.PointFloat(850.6561F, 3.458182F);
            this.vConsignacion.Multiline = true;
            this.vConsignacion.Name = "vConsignacion";
            this.vConsignacion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vConsignacion.SizeF = new System.Drawing.SizeF(83.53119F, 23.00015F);
            this.vConsignacion.StylePriority.UseFont = false;
            this.vConsignacion.StylePriority.UseTextAlignment = false;
            this.vConsignacion.Text = "Consignación";
            this.vConsignacion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // vTotal
            // 
            this.vTotal.Dpi = 100F;
            this.vTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vTotal.LocationFloat = new DevExpress.Utils.PointFloat(935.1873F, 3.458214F);
            this.vTotal.Multiline = true;
            this.vTotal.Name = "vTotal";
            this.vTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vTotal.SizeF = new System.Drawing.SizeF(75.11469F, 23.00012F);
            this.vTotal.StylePriority.UseFont = false;
            this.vTotal.StylePriority.UseTextAlignment = false;
            this.vTotal.Text = "Total";
            this.vTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLine1,
            this.xrLine2,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel36,
            this.xrLabel8,
            this.xrLabel3,
            this.xrLabel4,
            this.labelclienteheader,
            this.headerlabelcedis,
            this.labelfechaheader,
            this.labelvendedorheader,
            this.xrLabel2,
            this.xrLabel20,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel1,
            this.xrPictureBox1,
            this.labelrutasheader});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 318F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1010.302F, 257.0417F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(62.69794F, 23.00012F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Envase";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(850.6563F, 257.0421F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(83.53119F, 23.00015F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Consignación";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(775.4583F, 257.0421F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(75.198F, 23.00015F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Crédito";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0.9999911F, 234.0417F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1072F, 22.99998F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 291.5003F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(1072.5F, 23F);
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(3.99998F, 257.0417F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(65.62501F, 34.45865F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Clave del\r\nCliente";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(93.49999F, 257.0417F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(251.8171F, 23F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.Text = "Razon Social";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(359.4005F, 257.0421F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(199.75F, 23F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.Text = "Nombre Contacto";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(573.2338F, 257.0417F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(84.75256F, 22.99991F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Fecha";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(671.1106F, 257.0421F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(89.26434F, 23.00003F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Folio";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(935.1873F, 257.0421F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(75.11469F, 23.00012F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Total";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // labelclienteheader
            // 
            this.labelclienteheader.Dpi = 100F;
            this.labelclienteheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelclienteheader.LocationFloat = new DevExpress.Utils.PointFloat(142.125F, 211.0417F);
            this.labelclienteheader.Name = "labelclienteheader";
            this.labelclienteheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelclienteheader.SizeF = new System.Drawing.SizeF(930.875F, 23F);
            this.labelclienteheader.StylePriority.UseFont = false;
            // 
            // headerlabelcedis
            // 
            this.headerlabelcedis.Dpi = 100F;
            this.headerlabelcedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelcedis.LocationFloat = new DevExpress.Utils.PointFloat(142.125F, 119.0417F);
            this.headerlabelcedis.Name = "headerlabelcedis";
            this.headerlabelcedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelcedis.SizeF = new System.Drawing.SizeF(930.875F, 22.99999F);
            this.headerlabelcedis.StylePriority.UseFont = false;
            // 
            // labelfechaheader
            // 
            this.labelfechaheader.Dpi = 100F;
            this.labelfechaheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfechaheader.LocationFloat = new DevExpress.Utils.PointFloat(142.125F, 188.0417F);
            this.labelfechaheader.Name = "labelfechaheader";
            this.labelfechaheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelfechaheader.SizeF = new System.Drawing.SizeF(930.875F, 23F);
            this.labelfechaheader.StylePriority.UseFont = false;
            // 
            // labelvendedorheader
            // 
            this.labelvendedorheader.Dpi = 100F;
            this.labelvendedorheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelvendedorheader.LocationFloat = new DevExpress.Utils.PointFloat(142.125F, 142.0417F);
            this.labelvendedorheader.Name = "labelvendedorheader";
            this.labelvendedorheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelvendedorheader.SizeF = new System.Drawing.SizeF(930.875F, 23F);
            this.labelvendedorheader.StylePriority.UseFont = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 211.0417F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Cliente";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 119.0417F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "CEDI";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 188.0417F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Fecha";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(7.947286E-06F, 142.0417F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(7.947286E-06F, 165.0417F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Rutas";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(267.9998F, 25.99999F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(359.375F, 21.95834F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "ANÁLISIS DE SALDOS (MOO) - DETALLADO";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(11.99998F, 10.00001F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(150F, 94.45833F);
            // 
            // labelrutasheader
            // 
            this.labelrutasheader.Dpi = 100F;
            this.labelrutasheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrutasheader.LocationFloat = new DevExpress.Utils.PointFloat(142.125F, 165.0417F);
            this.labelrutasheader.Name = "labelrutasheader";
            this.labelrutasheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelrutasheader.SizeF = new System.Drawing.SizeF(930.875F, 23F);
            this.labelrutasheader.StylePriority.UseFont = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 116F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(417.5F, 46.3125F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(92.5F, 46.3125F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 25.00001F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // vendedorNombre
            // 
            this.vendedorNombre.Dpi = 100F;
            this.vendedorNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendedorNombre.LocationFloat = new DevExpress.Utils.PointFloat(326.4999F, 2.083333F);
            this.vendedorNombre.Name = "vendedorNombre";
            this.vendedorNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vendedorNombre.SizeF = new System.Drawing.SizeF(404.0001F, 23F);
            this.vendedorNombre.StylePriority.UseFont = false;
            // 
            // usuClave
            // 
            this.usuClave.Dpi = 100F;
            this.usuClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuClave.LocationFloat = new DevExpress.Utils.PointFloat(181.7083F, 4.083347F);
            this.usuClave.Name = "usuClave";
            this.usuClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.usuClave.SizeF = new System.Drawing.SizeF(116.6667F, 23F);
            this.usuClave.StylePriority.UseFont = false;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(51.54168F, 2.083333F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "VENDEDOR";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(3.99998F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "CEDI";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.usuClave,
            this.xrLabel10,
            this.vendedorNombre});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 27.08335F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // rutaDescripcion
            // 
            this.rutaDescripcion.Dpi = 100F;
            this.rutaDescripcion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutaDescripcion.LocationFloat = new DevExpress.Utils.PointFloat(326.4999F, 3.041665F);
            this.rutaDescripcion.Name = "rutaDescripcion";
            this.rutaDescripcion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rutaDescripcion.SizeF = new System.Drawing.SizeF(404.0001F, 23F);
            this.rutaDescripcion.StylePriority.UseFont = false;
            // 
            // rutaClave
            // 
            this.rutaClave.Dpi = 100F;
            this.rutaClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutaClave.LocationFloat = new DevExpress.Utils.PointFloat(181.7083F, 3.041665F);
            this.rutaClave.Name = "rutaClave";
            this.rutaClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rutaClave.SizeF = new System.Drawing.SizeF(116.6667F, 23F);
            this.rutaClave.StylePriority.UseFont = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(27.58336F, 3.041665F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "RUTA";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.rutaClave,
            this.rutaDescripcion});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 29.08331F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // cediNombre
            // 
            this.cediNombre.Dpi = 100F;
            this.cediNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cediNombre.LocationFloat = new DevExpress.Utils.PointFloat(326.4999F, 0F);
            this.cediNombre.Name = "cediNombre";
            this.cediNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cediNombre.SizeF = new System.Drawing.SizeF(404.0001F, 23F);
            this.cediNombre.StylePriority.UseFont = false;
            // 
            // cediClave
            // 
            this.cediClave.Dpi = 100F;
            this.cediClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cediClave.LocationFloat = new DevExpress.Utils.PointFloat(181.7083F, 0F);
            this.cediClave.Name = "cediClave";
            this.cediClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cediClave.SizeF = new System.Drawing.SizeF(116.6667F, 23F);
            this.cediClave.StylePriority.UseFont = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vCreditoTotal,
            this.xrLabel12,
            this.vConsignacion,
            this.vTotal,
            this.vEnvase});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 29.16667F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // vCreditoTotal
            // 
            this.vCreditoTotal.Dpi = 100F;
            this.vCreditoTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vCreditoTotal.LocationFloat = new DevExpress.Utils.PointFloat(760.3747F, 3.458055F);
            this.vCreditoTotal.Multiline = true;
            this.vCreditoTotal.Name = "vCreditoTotal";
            this.vCreditoTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vCreditoTotal.SizeF = new System.Drawing.SizeF(89.78119F, 23.00015F);
            this.vCreditoTotal.StylePriority.UseFont = false;
            this.vCreditoTotal.StylePriority.UseTextAlignment = false;
            this.vCreditoTotal.Text = "Crédito total";
            this.vCreditoTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(671.1106F, 3.458182F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(89.26434F, 23.00003F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Total";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vEnvase
            // 
            this.vEnvase.Dpi = 100F;
            this.vEnvase.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vEnvase.LocationFloat = new DevExpress.Utils.PointFloat(1010.302F, 3.458214F);
            this.vEnvase.Multiline = true;
            this.vEnvase.Name = "vEnvase";
            this.vEnvase.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vEnvase.SizeF = new System.Drawing.SizeF(62.69794F, 23.00012F);
            this.vEnvase.StylePriority.UseFont = false;
            this.vEnvase.StylePriority.UseTextAlignment = false;
            this.vEnvase.Text = "Envase";
            this.vEnvase.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CreditoVen,
            this.ConsignacionVen,
            this.TotalVen,
            this.EnvaseVen,
            this.xrLabel13});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 27.08333F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // CreditoVen
            // 
            this.CreditoVen.Dpi = 100F;
            this.CreditoVen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditoVen.LocationFloat = new DevExpress.Utils.PointFloat(760.8749F, 0F);
            this.CreditoVen.Multiline = true;
            this.CreditoVen.Name = "CreditoVen";
            this.CreditoVen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreditoVen.SizeF = new System.Drawing.SizeF(89.78125F, 23.00015F);
            this.CreditoVen.StylePriority.UseFont = false;
            this.CreditoVen.StylePriority.UseTextAlignment = false;
            this.CreditoVen.Text = "CreditoVen";
            this.CreditoVen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ConsignacionVen
            // 
            this.ConsignacionVen.Dpi = 100F;
            this.ConsignacionVen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsignacionVen.LocationFloat = new DevExpress.Utils.PointFloat(850.6561F, 0F);
            this.ConsignacionVen.Multiline = true;
            this.ConsignacionVen.Name = "ConsignacionVen";
            this.ConsignacionVen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConsignacionVen.SizeF = new System.Drawing.SizeF(83.53119F, 23.00015F);
            this.ConsignacionVen.StylePriority.UseFont = false;
            this.ConsignacionVen.StylePriority.UseTextAlignment = false;
            this.ConsignacionVen.Text = "Consignación";
            this.ConsignacionVen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalVen
            // 
            this.TotalVen.Dpi = 100F;
            this.TotalVen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalVen.LocationFloat = new DevExpress.Utils.PointFloat(935.1873F, 0F);
            this.TotalVen.Multiline = true;
            this.TotalVen.Name = "TotalVen";
            this.TotalVen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalVen.SizeF = new System.Drawing.SizeF(75.11469F, 23.00012F);
            this.TotalVen.StylePriority.UseFont = false;
            this.TotalVen.StylePriority.UseTextAlignment = false;
            this.TotalVen.Text = "Total";
            this.TotalVen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // EnvaseVen
            // 
            this.EnvaseVen.Dpi = 100F;
            this.EnvaseVen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvaseVen.LocationFloat = new DevExpress.Utils.PointFloat(1010.302F, 0F);
            this.EnvaseVen.Multiline = true;
            this.EnvaseVen.Name = "EnvaseVen";
            this.EnvaseVen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EnvaseVen.SizeF = new System.Drawing.SizeF(62.69794F, 23.00012F);
            this.EnvaseVen.StylePriority.UseFont = false;
            this.EnvaseVen.StylePriority.UseTextAlignment = false;
            this.EnvaseVen.Text = "Envase";
            this.EnvaseVen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(485.8749F, 0F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(121.1665F, 23.00003F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Total por Vendedor";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CreditoRut,
            this.ConsignacionRut,
            this.TotalRut,
            this.EnvaseRut,
            this.xrLabel14});
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.HeightF = 29.16667F;
            this.GroupFooter3.Level = 2;
            this.GroupFooter3.Name = "GroupFooter3";
            // 
            // CreditoRut
            // 
            this.CreditoRut.Dpi = 100F;
            this.CreditoRut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditoRut.LocationFloat = new DevExpress.Utils.PointFloat(760.8748F, 0F);
            this.CreditoRut.Multiline = true;
            this.CreditoRut.Name = "CreditoRut";
            this.CreditoRut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreditoRut.SizeF = new System.Drawing.SizeF(89.28107F, 23.00015F);
            this.CreditoRut.StylePriority.UseFont = false;
            this.CreditoRut.StylePriority.UseTextAlignment = false;
            this.CreditoRut.Text = "CréditoRut";
            this.CreditoRut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ConsignacionRut
            // 
            this.ConsignacionRut.Dpi = 100F;
            this.ConsignacionRut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsignacionRut.LocationFloat = new DevExpress.Utils.PointFloat(850.6561F, 0F);
            this.ConsignacionRut.Multiline = true;
            this.ConsignacionRut.Name = "ConsignacionRut";
            this.ConsignacionRut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConsignacionRut.SizeF = new System.Drawing.SizeF(83.53119F, 23.00015F);
            this.ConsignacionRut.StylePriority.UseFont = false;
            this.ConsignacionRut.StylePriority.UseTextAlignment = false;
            this.ConsignacionRut.Text = "Consignación";
            this.ConsignacionRut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalRut
            // 
            this.TotalRut.Dpi = 100F;
            this.TotalRut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalRut.LocationFloat = new DevExpress.Utils.PointFloat(935.1873F, 0F);
            this.TotalRut.Multiline = true;
            this.TotalRut.Name = "TotalRut";
            this.TotalRut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalRut.SizeF = new System.Drawing.SizeF(75.11469F, 23.00012F);
            this.TotalRut.StylePriority.UseFont = false;
            this.TotalRut.StylePriority.UseTextAlignment = false;
            this.TotalRut.Text = "Total";
            this.TotalRut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // EnvaseRut
            // 
            this.EnvaseRut.Dpi = 100F;
            this.EnvaseRut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvaseRut.LocationFloat = new DevExpress.Utils.PointFloat(1010.302F, 0F);
            this.EnvaseRut.Multiline = true;
            this.EnvaseRut.Name = "EnvaseRut";
            this.EnvaseRut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EnvaseRut.SizeF = new System.Drawing.SizeF(62.69794F, 23.00012F);
            this.EnvaseRut.StylePriority.UseFont = false;
            this.EnvaseRut.StylePriority.UseTextAlignment = false;
            this.EnvaseRut.Text = "Envase";
            this.EnvaseRut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(485.8749F, 0F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(121.1665F, 23.00003F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Total por Ruta";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.cediClave,
            this.cediNombre});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 26.04167F;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CreditoCEDI,
            this.ConsignacionCEDI,
            this.TotalCEDI,
            this.EnvaseCEDI,
            this.xrLabel15});
            this.GroupFooter4.Dpi = 100F;
            this.GroupFooter4.HeightF = 28.12504F;
            this.GroupFooter4.Level = 3;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // CreditoCEDI
            // 
            this.CreditoCEDI.Dpi = 100F;
            this.CreditoCEDI.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditoCEDI.LocationFloat = new DevExpress.Utils.PointFloat(761.375F, 5.124855F);
            this.CreditoCEDI.Multiline = true;
            this.CreditoCEDI.Name = "CreditoCEDI";
            this.CreditoCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreditoCEDI.SizeF = new System.Drawing.SizeF(89.28113F, 23.00015F);
            this.CreditoCEDI.StylePriority.UseFont = false;
            this.CreditoCEDI.StylePriority.UseTextAlignment = false;
            this.CreditoCEDI.Text = "CreditoCEDI";
            this.CreditoCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ConsignacionCEDI
            // 
            this.ConsignacionCEDI.Dpi = 100F;
            this.ConsignacionCEDI.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsignacionCEDI.LocationFloat = new DevExpress.Utils.PointFloat(850.6561F, 5.124887F);
            this.ConsignacionCEDI.Multiline = true;
            this.ConsignacionCEDI.Name = "ConsignacionCEDI";
            this.ConsignacionCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConsignacionCEDI.SizeF = new System.Drawing.SizeF(83.53119F, 23.00015F);
            this.ConsignacionCEDI.StylePriority.UseFont = false;
            this.ConsignacionCEDI.StylePriority.UseTextAlignment = false;
            this.ConsignacionCEDI.Text = "Consignación";
            this.ConsignacionCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalCEDI
            // 
            this.TotalCEDI.Dpi = 100F;
            this.TotalCEDI.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCEDI.LocationFloat = new DevExpress.Utils.PointFloat(935.1873F, 5.124887F);
            this.TotalCEDI.Multiline = true;
            this.TotalCEDI.Name = "TotalCEDI";
            this.TotalCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCEDI.SizeF = new System.Drawing.SizeF(75.11469F, 23.00012F);
            this.TotalCEDI.StylePriority.UseFont = false;
            this.TotalCEDI.StylePriority.UseTextAlignment = false;
            this.TotalCEDI.Text = "Total";
            this.TotalCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // EnvaseCEDI
            // 
            this.EnvaseCEDI.Dpi = 100F;
            this.EnvaseCEDI.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvaseCEDI.LocationFloat = new DevExpress.Utils.PointFloat(1010.302F, 5.124887F);
            this.EnvaseCEDI.Multiline = true;
            this.EnvaseCEDI.Name = "EnvaseCEDI";
            this.EnvaseCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EnvaseCEDI.SizeF = new System.Drawing.SizeF(62.69794F, 23.00012F);
            this.EnvaseCEDI.StylePriority.UseFont = false;
            this.EnvaseCEDI.StylePriority.UseTextAlignment = false;
            this.EnvaseCEDI.Text = "Envase";
            this.EnvaseCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(485.8749F, 5.124982F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(186.1948F, 23.00003F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Total por Centro de Distribucion";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1,
            this.CreditoGTotal,
            this.ConsignacionGtotal,
            this.GTotal,
            this.EnvaseGTotal,
            this.xrLabel16});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 172.9167F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // CreditoGTotal
            // 
            this.CreditoGTotal.Dpi = 100F;
            this.CreditoGTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditoGTotal.LocationFloat = new DevExpress.Utils.PointFloat(760.8748F, 10.00004F);
            this.CreditoGTotal.Multiline = true;
            this.CreditoGTotal.Name = "CreditoGTotal";
            this.CreditoGTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreditoGTotal.SizeF = new System.Drawing.SizeF(89.28113F, 23.00015F);
            this.CreditoGTotal.StylePriority.UseFont = false;
            this.CreditoGTotal.StylePriority.UseTextAlignment = false;
            this.CreditoGTotal.Text = "CreditoGTotal";
            this.CreditoGTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ConsignacionGtotal
            // 
            this.ConsignacionGtotal.Dpi = 100F;
            this.ConsignacionGtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsignacionGtotal.LocationFloat = new DevExpress.Utils.PointFloat(850.6562F, 9.999943F);
            this.ConsignacionGtotal.Multiline = true;
            this.ConsignacionGtotal.Name = "ConsignacionGtotal";
            this.ConsignacionGtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConsignacionGtotal.SizeF = new System.Drawing.SizeF(83.53119F, 23.00015F);
            this.ConsignacionGtotal.StylePriority.UseFont = false;
            this.ConsignacionGtotal.StylePriority.UseTextAlignment = false;
            this.ConsignacionGtotal.Text = "Consignación";
            this.ConsignacionGtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GTotal
            // 
            this.GTotal.Dpi = 100F;
            this.GTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GTotal.LocationFloat = new DevExpress.Utils.PointFloat(935.1874F, 10.00001F);
            this.GTotal.Multiline = true;
            this.GTotal.Name = "GTotal";
            this.GTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GTotal.SizeF = new System.Drawing.SizeF(75.11469F, 23.00012F);
            this.GTotal.StylePriority.UseFont = false;
            this.GTotal.StylePriority.UseTextAlignment = false;
            this.GTotal.Text = "Total";
            this.GTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // EnvaseGTotal
            // 
            this.EnvaseGTotal.Dpi = 100F;
            this.EnvaseGTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvaseGTotal.LocationFloat = new DevExpress.Utils.PointFloat(1010.302F, 10.00001F);
            this.EnvaseGTotal.Multiline = true;
            this.EnvaseGTotal.Name = "EnvaseGTotal";
            this.EnvaseGTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EnvaseGTotal.SizeF = new System.Drawing.SizeF(62.69794F, 23.00012F);
            this.EnvaseGTotal.StylePriority.UseFont = false;
            this.EnvaseGTotal.StylePriority.UseTextAlignment = false;
            this.EnvaseGTotal.Text = "Envase";
            this.EnvaseGTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(485.8749F, 10.00001F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(93.48648F, 23.00003F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "GRAN TOTAL";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.Dpi = 100F;
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(391.3197F, 53.08329F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(266.6667F, 54.62503F);
            // 
            // AnalisisSaldosMOODetallado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupFooter1,
            this.GroupFooter2,
            this.GroupFooter3,
            this.GroupHeader4,
            this.GroupFooter4,
            this.ReportFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 318, 116);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
