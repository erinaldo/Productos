using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class SubVendedor : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    private GroupFooterBand GroupFooter1;
    private GroupFooterBand GroupFooter2;
    private GroupFooterBand GroupFooter3;
    public XRLabel Envase;
    public XRLabel VenNombre;
    public XRLabel Credito;
    public XRLabel Consignacion;
    public XRLabel Total;
    public XRLabel RutClave;
    public XRLabel xrLabel1;
    public XRLabel CreditoCedi;
    public XRLabel ConsignacionCedi;
    public XRLabel TotalCedi;
    public XRLabel EnvaseCedi;
    private PageFooterBand PageFooter;
    public XRLabel xrLabel2;
    public XRLabel CreditoGTotal;
    public XRLabel ConsignacionGTotal;
    public XRLabel TotalGTotal;
    public XRLabel EnvaseGTotal;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubVendedor()
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
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.VenNombre = new DevExpress.XtraReports.UI.XRLabel();
            this.RutClave = new DevExpress.XtraReports.UI.XRLabel();
            this.Credito = new DevExpress.XtraReports.UI.XRLabel();
            this.Consignacion = new DevExpress.XtraReports.UI.XRLabel();
            this.Total = new DevExpress.XtraReports.UI.XRLabel();
            this.Envase = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CreditoCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.ConsignacionCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.EnvaseCedi = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.CreditoGTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.ConsignacionGTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalGTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.EnvaseGTotal = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.BottomMargin.HeightF = 3.125F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 0F;
            this.GroupHeader1.Level = 2;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 0F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 0F;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.VenNombre,
            this.RutClave,
            this.Credito,
            this.Consignacion,
            this.Total,
            this.Envase});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 25.41666F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // VenNombre
            // 
            this.VenNombre.Dpi = 100F;
            this.VenNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VenNombre.LocationFloat = new DevExpress.Utils.PointFloat(92.16663F, 0.9583791F);
            this.VenNombre.Multiline = true;
            this.VenNombre.Name = "VenNombre";
            this.VenNombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VenNombre.SizeF = new System.Drawing.SizeF(243.7501F, 22.99996F);
            this.VenNombre.StylePriority.UseFont = false;
            this.VenNombre.StylePriority.UseTextAlignment = false;
            this.VenNombre.Text = "VENNombre";
            this.VenNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // RutClave
            // 
            this.RutClave.Dpi = 100F;
            this.RutClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RutClave.LocationFloat = new DevExpress.Utils.PointFloat(6.333312F, 0.9583791F);
            this.RutClave.Multiline = true;
            this.RutClave.Name = "RutClave";
            this.RutClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RutClave.SizeF = new System.Drawing.SizeF(72.91667F, 22.99996F);
            this.RutClave.StylePriority.UseFont = false;
            this.RutClave.StylePriority.UseTextAlignment = false;
            this.RutClave.Text = "RUTClave";
            this.RutClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Credito
            // 
            this.Credito.Dpi = 100F;
            this.Credito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Credito.LocationFloat = new DevExpress.Utils.PointFloat(366.1559F, 0.9583791F);
            this.Credito.Multiline = true;
            this.Credito.Name = "Credito";
            this.Credito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Credito.SizeF = new System.Drawing.SizeF(89.78113F, 22.99996F);
            this.Credito.StylePriority.UseFont = false;
            this.Credito.StylePriority.UseTextAlignment = false;
            this.Credito.Text = "Credito";
            this.Credito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Consignacion
            // 
            this.Consignacion.Dpi = 100F;
            this.Consignacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consignacion.LocationFloat = new DevExpress.Utils.PointFloat(455.9373F, 0F);
            this.Consignacion.Multiline = true;
            this.Consignacion.Name = "Consignacion";
            this.Consignacion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Consignacion.SizeF = new System.Drawing.SizeF(84.03107F, 22.99996F);
            this.Consignacion.StylePriority.UseFont = false;
            this.Consignacion.StylePriority.UseTextAlignment = false;
            this.Consignacion.Text = "Consignacion";
            this.Consignacion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Total
            // 
            this.Total.Dpi = 100F;
            this.Total.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.LocationFloat = new DevExpress.Utils.PointFloat(540.4684F, 0F);
            this.Total.Multiline = true;
            this.Total.Name = "Total";
            this.Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Total.SizeF = new System.Drawing.SizeF(72.91667F, 22.99996F);
            this.Total.StylePriority.UseFont = false;
            this.Total.StylePriority.UseTextAlignment = false;
            this.Total.Text = "Total";
            this.Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Envase
            // 
            this.Envase.Dpi = 100F;
            this.Envase.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Envase.LocationFloat = new DevExpress.Utils.PointFloat(615.5832F, 0.9583791F);
            this.Envase.Multiline = true;
            this.Envase.Name = "Envase";
            this.Envase.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Envase.SizeF = new System.Drawing.SizeF(62.19794F, 22.99996F);
            this.Envase.StylePriority.UseFont = false;
            this.Envase.StylePriority.UseTextAlignment = false;
            this.Envase.Text = "Envase";
            this.Envase.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.CreditoCedi,
            this.ConsignacionCedi,
            this.TotalCedi,
            this.EnvaseCedi,
            this.xrLabel2,
            this.CreditoGTotal,
            this.ConsignacionGTotal,
            this.TotalGTotal,
            this.EnvaseGTotal});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 62.5F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(92.16663F, 3.041713F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(243.7501F, 22.99996F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Total por Centro de Distribución";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CreditoCedi
            // 
            this.CreditoCedi.Dpi = 100F;
            this.CreditoCedi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditoCedi.LocationFloat = new DevExpress.Utils.PointFloat(366.1559F, 0F);
            this.CreditoCedi.Multiline = true;
            this.CreditoCedi.Name = "CreditoCedi";
            this.CreditoCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreditoCedi.SizeF = new System.Drawing.SizeF(89.78113F, 22.99996F);
            this.CreditoCedi.StylePriority.UseFont = false;
            this.CreditoCedi.StylePriority.UseTextAlignment = false;
            this.CreditoCedi.Text = "Credito";
            this.CreditoCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ConsignacionCedi
            // 
            this.ConsignacionCedi.Dpi = 100F;
            this.ConsignacionCedi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsignacionCedi.LocationFloat = new DevExpress.Utils.PointFloat(455.9373F, 0F);
            this.ConsignacionCedi.Multiline = true;
            this.ConsignacionCedi.Name = "ConsignacionCedi";
            this.ConsignacionCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConsignacionCedi.SizeF = new System.Drawing.SizeF(84.03119F, 22.99996F);
            this.ConsignacionCedi.StylePriority.UseFont = false;
            this.ConsignacionCedi.StylePriority.UseTextAlignment = false;
            this.ConsignacionCedi.Text = "Consignacion";
            this.ConsignacionCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalCedi
            // 
            this.TotalCedi.Dpi = 100F;
            this.TotalCedi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCedi.LocationFloat = new DevExpress.Utils.PointFloat(540.9684F, 0F);
            this.TotalCedi.Multiline = true;
            this.TotalCedi.Name = "TotalCedi";
            this.TotalCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCedi.SizeF = new System.Drawing.SizeF(72.41669F, 22.99996F);
            this.TotalCedi.StylePriority.UseFont = false;
            this.TotalCedi.StylePriority.UseTextAlignment = false;
            this.TotalCedi.Text = "Total";
            this.TotalCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // EnvaseCedi
            // 
            this.EnvaseCedi.Dpi = 100F;
            this.EnvaseCedi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvaseCedi.LocationFloat = new DevExpress.Utils.PointFloat(615.5831F, 0F);
            this.EnvaseCedi.Multiline = true;
            this.EnvaseCedi.Name = "EnvaseCedi";
            this.EnvaseCedi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EnvaseCedi.SizeF = new System.Drawing.SizeF(62.198F, 22.99996F);
            this.EnvaseCedi.StylePriority.UseFont = false;
            this.EnvaseCedi.StylePriority.UseTextAlignment = false;
            this.EnvaseCedi.Text = "Envase";
            this.EnvaseCedi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.HeightF = 0F;
            this.GroupFooter3.Level = 2;
            this.GroupFooter3.Name = "GroupFooter3";
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 1.041667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(92.16666F, 34.70837F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(243.7501F, 22.99996F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "GRAN TOTAL";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CreditoGTotal
            // 
            this.CreditoGTotal.Dpi = 100F;
            this.CreditoGTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditoGTotal.LocationFloat = new DevExpress.Utils.PointFloat(366.1559F, 34.70837F);
            this.CreditoGTotal.Multiline = true;
            this.CreditoGTotal.Name = "CreditoGTotal";
            this.CreditoGTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreditoGTotal.SizeF = new System.Drawing.SizeF(89.78113F, 22.99996F);
            this.CreditoGTotal.StylePriority.UseFont = false;
            this.CreditoGTotal.StylePriority.UseTextAlignment = false;
            this.CreditoGTotal.Text = "Credito";
            this.CreditoGTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ConsignacionGTotal
            // 
            this.ConsignacionGTotal.Dpi = 100F;
            this.ConsignacionGTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsignacionGTotal.LocationFloat = new DevExpress.Utils.PointFloat(455.9373F, 34.70837F);
            this.ConsignacionGTotal.Multiline = true;
            this.ConsignacionGTotal.Name = "ConsignacionGTotal";
            this.ConsignacionGTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ConsignacionGTotal.SizeF = new System.Drawing.SizeF(84.03107F, 22.99996F);
            this.ConsignacionGTotal.StylePriority.UseFont = false;
            this.ConsignacionGTotal.StylePriority.UseTextAlignment = false;
            this.ConsignacionGTotal.Text = "Consignacion";
            this.ConsignacionGTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalGTotal
            // 
            this.TotalGTotal.Dpi = 100F;
            this.TotalGTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalGTotal.LocationFloat = new DevExpress.Utils.PointFloat(540.4684F, 34.70837F);
            this.TotalGTotal.Multiline = true;
            this.TotalGTotal.Name = "TotalGTotal";
            this.TotalGTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalGTotal.SizeF = new System.Drawing.SizeF(72.91667F, 22.99996F);
            this.TotalGTotal.StylePriority.UseFont = false;
            this.TotalGTotal.StylePriority.UseTextAlignment = false;
            this.TotalGTotal.Text = "Total";
            this.TotalGTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // EnvaseGTotal
            // 
            this.EnvaseGTotal.Dpi = 100F;
            this.EnvaseGTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvaseGTotal.LocationFloat = new DevExpress.Utils.PointFloat(615.5832F, 34.70837F);
            this.EnvaseGTotal.Multiline = true;
            this.EnvaseGTotal.Name = "EnvaseGTotal";
            this.EnvaseGTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EnvaseGTotal.SizeF = new System.Drawing.SizeF(62.19794F, 22.99996F);
            this.EnvaseGTotal.StylePriority.UseFont = false;
            this.EnvaseGTotal.StylePriority.UseTextAlignment = false;
            this.EnvaseGTotal.Text = "Envase";
            this.EnvaseGTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // SubVendedor
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
            this.PageFooter});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 0, 3);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
