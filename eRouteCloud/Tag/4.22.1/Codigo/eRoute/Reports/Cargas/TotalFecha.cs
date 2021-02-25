using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class TotalFecha : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    public XRLabel dClave;
    public XRLabel dProducto;
    public XRLabel dUnidades;
    public XRLabel dCantidad;
    public XRLabel dPiezas;
    public XRLabel xrLabel1;
    private GroupFooterBand GroupFooter1;
    private GroupFooterBand GroupFooter2;
    public XRLabel xrLabel2;
    public XRLabel fPiezas;
    private ReportHeaderBand ReportHeader;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public TotalFecha()
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
            this.dClave = new DevExpress.XtraReports.UI.XRLabel();
            this.dProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.dUnidades = new DevExpress.XtraReports.UI.XRLabel();
            this.dCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dPiezas = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.fPiezas = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.dClave,
            this.dProducto,
            this.dUnidades,
            this.dCantidad,
            this.dPiezas});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 18.75F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dClave
            // 
            this.dClave.Dpi = 100F;
            this.dClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dClave.LocationFloat = new DevExpress.Utils.PointFloat(85.41668F, 2.000046F);
            this.dClave.Multiline = true;
            this.dClave.Name = "dClave";
            this.dClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dClave.SizeF = new System.Drawing.SizeF(65.62502F, 12.99996F);
            this.dClave.StylePriority.UseFont = false;
            this.dClave.StylePriority.UseTextAlignment = false;
            this.dClave.Text = "Clave";
            this.dClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dProducto
            // 
            this.dProducto.Dpi = 100F;
            this.dProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dProducto.LocationFloat = new DevExpress.Utils.PointFloat(211.3333F, 2.000046F);
            this.dProducto.Multiline = true;
            this.dProducto.Name = "dProducto";
            this.dProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dProducto.SizeF = new System.Drawing.SizeF(324.9006F, 12.99996F);
            this.dProducto.StylePriority.UseFont = false;
            this.dProducto.StylePriority.UseTextAlignment = false;
            this.dProducto.Text = "Producto";
            this.dProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dUnidades
            // 
            this.dUnidades.Dpi = 100F;
            this.dUnidades.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dUnidades.LocationFloat = new DevExpress.Utils.PointFloat(570.7499F, 2.000046F);
            this.dUnidades.Multiline = true;
            this.dUnidades.Name = "dUnidades";
            this.dUnidades.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dUnidades.SizeF = new System.Drawing.SizeF(64.12512F, 12.99996F);
            this.dUnidades.StylePriority.UseFont = false;
            this.dUnidades.StylePriority.UseTextAlignment = false;
            this.dUnidades.Text = "Unidades";
            this.dUnidades.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dCantidad
            // 
            this.dCantidad.Dpi = 100F;
            this.dCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dCantidad.LocationFloat = new DevExpress.Utils.PointFloat(654.4166F, 2.000046F);
            this.dCantidad.Multiline = true;
            this.dCantidad.Name = "dCantidad";
            this.dCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dCantidad.SizeF = new System.Drawing.SizeF(75.5835F, 12.99996F);
            this.dCantidad.StylePriority.UseFont = false;
            this.dCantidad.StylePriority.UseTextAlignment = false;
            this.dCantidad.Text = "Cantidad";
            this.dCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // dPiezas
            // 
            this.dPiezas.Dpi = 100F;
            this.dPiezas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dPiezas.LocationFloat = new DevExpress.Utils.PointFloat(748.3749F, 2.000046F);
            this.dPiezas.Multiline = true;
            this.dPiezas.Name = "dPiezas";
            this.dPiezas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dPiezas.SizeF = new System.Drawing.SizeF(64.12506F, 12.99996F);
            this.dPiezas.StylePriority.UseFont = false;
            this.dPiezas.StylePriority.UseTextAlignment = false;
            this.dPiezas.Text = "Piezas";
            this.dPiezas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(331.5832F, 0.9583791F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(98.85886F, 22.99995F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Total por Fecha";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 0F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Level = 1;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fPiezas,
            this.xrLabel2});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 25F;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // fPiezas
            // 
            this.fPiezas.Dpi = 100F;
            this.fPiezas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fPiezas.LocationFloat = new DevExpress.Utils.PointFloat(703.2243F, 0F);
            this.fPiezas.Multiline = true;
            this.fPiezas.Name = "fPiezas";
            this.fPiezas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fPiezas.SizeF = new System.Drawing.SizeF(109.2756F, 12.99996F);
            this.fPiezas.StylePriority.UseFont = false;
            this.fPiezas.StylePriority.UseTextAlignment = false;
            this.fPiezas.Text = "TOTAL PIEZAS";
            this.fPiezas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(542.6666F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(109.2756F, 12.99996F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "TOTAL PIEZAS";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 23.95833F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // TotalFecha
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupFooter1,
            this.GroupFooter2,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 0, 0);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
