using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class SubReporteCreditoA : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    private GroupFooterBand GroupFooter1;
    public GroupFooterBand GroupFooter2;
    public XRLabel SubCredito;
    public XRLabel CrSimbolo;
    public XRLabel CrVenta;
    public XRLabel CrFecha;
    public XRLabel CrCliente;
    public XRLabel CrImporte;
    private XRLabel xrLabel22;
    public XRLabel TCrSimbolo;
    public XRLabel TCrImporte;
    public XRLabel xrLabel6;
    public XRLabel PSimbolo;
    public XRLabel PPromocion;
    public XRLabel PSubtotal;
    public XRLabel SSimbolo;
    private XRLabel xrLabel20;
    private XRLabel xrLabel3;
    private XRLabel xrLabel9;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel4;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteCreditoA()
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
            this.PSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.SSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.PSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.PPromocion = new DevExpress.XtraReports.UI.XRLabel();
            this.CrSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.CrVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.CrFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.CrCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.CrImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.SubCredito = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.TCrSimbolo = new DevExpress.XtraReports.UI.XRLabel();
            this.TCrImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PSubtotal,
            this.SSimbolo,
            this.PSimbolo,
            this.PPromocion,
            this.CrSimbolo,
            this.CrVenta,
            this.CrFecha,
            this.CrCliente,
            this.CrImporte});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 16.66667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PSubtotal
            // 
            this.PSubtotal.Dpi = 100F;
            this.PSubtotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(785F, 0F);
            this.PSubtotal.Name = "PSubtotal";
            this.PSubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PSubtotal.SizeF = new System.Drawing.SizeF(80F, 16F);
            this.PSubtotal.StylePriority.UseFont = false;
            this.PSubtotal.StylePriority.UseTextAlignment = false;
            this.PSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // SSimbolo
            // 
            this.SSimbolo.Dpi = 100F;
            this.SSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(760F, 0F);
            this.SSimbolo.Name = "SSimbolo";
            this.SSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SSimbolo.SizeF = new System.Drawing.SizeF(25F, 16F);
            this.SSimbolo.StylePriority.UseFont = false;
            this.SSimbolo.StylePriority.UseTextAlignment = false;
            this.SSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PSimbolo
            // 
            this.PSimbolo.Dpi = 100F;
            this.PSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(865F, 0F);
            this.PSimbolo.Name = "PSimbolo";
            this.PSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PSimbolo.SizeF = new System.Drawing.SizeF(25F, 16F);
            this.PSimbolo.StylePriority.UseFont = false;
            this.PSimbolo.StylePriority.UseTextAlignment = false;
            this.PSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PPromocion
            // 
            this.PPromocion.Dpi = 100F;
            this.PPromocion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPromocion.LocationFloat = new DevExpress.Utils.PointFloat(890F, 0F);
            this.PPromocion.Name = "PPromocion";
            this.PPromocion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PPromocion.SizeF = new System.Drawing.SizeF(75F, 16F);
            this.PPromocion.StylePriority.UseFont = false;
            this.PPromocion.StylePriority.UseTextAlignment = false;
            this.PPromocion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CrSimbolo
            // 
            this.CrSimbolo.Dpi = 100F;
            this.CrSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(965F, 0F);
            this.CrSimbolo.Name = "CrSimbolo";
            this.CrSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrSimbolo.SizeF = new System.Drawing.SizeF(26F, 16F);
            this.CrSimbolo.StylePriority.UseFont = false;
            this.CrSimbolo.StylePriority.UseTextAlignment = false;
            this.CrSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CrVenta
            // 
            this.CrVenta.Dpi = 100F;
            this.CrVenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrVenta.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.CrVenta.Name = "CrVenta";
            this.CrVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrVenta.SizeF = new System.Drawing.SizeF(80F, 16F);
            this.CrVenta.StylePriority.UseFont = false;
            this.CrVenta.StylePriority.UseTextAlignment = false;
            this.CrVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CrFecha
            // 
            this.CrFecha.Dpi = 100F;
            this.CrFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrFecha.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
            this.CrFecha.Name = "CrFecha";
            this.CrFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrFecha.SizeF = new System.Drawing.SizeF(190F, 16F);
            this.CrFecha.StylePriority.UseFont = false;
            this.CrFecha.StylePriority.UseTextAlignment = false;
            this.CrFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CrCliente
            // 
            this.CrCliente.Dpi = 100F;
            this.CrCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrCliente.LocationFloat = new DevExpress.Utils.PointFloat(270F, 0F);
            this.CrCliente.Name = "CrCliente";
            this.CrCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrCliente.SizeF = new System.Drawing.SizeF(490F, 16F);
            this.CrCliente.StylePriority.UseFont = false;
            this.CrCliente.StylePriority.UseTextAlignment = false;
            this.CrCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CrImporte
            // 
            this.CrImporte.Dpi = 100F;
            this.CrImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrImporte.LocationFloat = new DevExpress.Utils.PointFloat(991.46F, 0F);
            this.CrImporte.Name = "CrImporte";
            this.CrImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CrImporte.SizeF = new System.Drawing.SizeF(80.54F, 16F);
            this.CrImporte.StylePriority.UseFont = false;
            this.CrImporte.StylePriority.UseTextAlignment = false;
            this.CrImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel20,
            this.xrLabel3,
            this.xrLabel9,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel4});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 16.66667F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.SubCredito});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 16.66667F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(200F, 16F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "VENTA CRÉDITO";
            // 
            // SubCredito
            // 
            this.SubCredito.Dpi = 100F;
            this.SubCredito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubCredito.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.SubCredito.Name = "SubCredito";
            this.SubCredito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SubCredito.SizeF = new System.Drawing.SizeF(200F, 16F);
            this.SubCredito.StylePriority.UseFont = false;
            this.SubCredito.Text = "VENTA CRÉDITO";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TCrSimbolo,
            this.TCrImporte,
            this.xrLabel22});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 16.66667F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // TCrSimbolo
            // 
            this.TCrSimbolo.Dpi = 100F;
            this.TCrSimbolo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCrSimbolo.LocationFloat = new DevExpress.Utils.PointFloat(965F, 0F);
            this.TCrSimbolo.Name = "TCrSimbolo";
            this.TCrSimbolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TCrSimbolo.SizeF = new System.Drawing.SizeF(26F, 16F);
            this.TCrSimbolo.StylePriority.UseFont = false;
            this.TCrSimbolo.StylePriority.UseTextAlignment = false;
            this.TCrSimbolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TCrImporte
            // 
            this.TCrImporte.Dpi = 100F;
            this.TCrImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCrImporte.LocationFloat = new DevExpress.Utils.PointFloat(991.46F, 0F);
            this.TCrImporte.Name = "TCrImporte";
            this.TCrImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TCrImporte.SizeF = new System.Drawing.SizeF(80.54F, 16F);
            this.TCrImporte.StylePriority.UseFont = false;
            this.TCrImporte.StylePriority.UseTextAlignment = false;
            this.TCrImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(760F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(205F, 16F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Total de Ventas de Credito";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(80F, 16F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Venta";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(190F, 16F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Fecha";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(965F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(107F, 16F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Importe";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(270F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(490F, 16F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Cliente";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(865F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Promocion";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(760F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(105F, 16F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Subtotal";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // SubReporteCreditoA
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupFooter1,
            this.GroupFooter2});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 0, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
