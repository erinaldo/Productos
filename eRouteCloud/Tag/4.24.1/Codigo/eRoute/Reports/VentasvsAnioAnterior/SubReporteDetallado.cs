using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class SubReporteDetallado : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    public TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    public XRLabel labelPorcentaje2;
    public XRLabel labelCartones2;
    public XRLabel labelProducto2;
    public XRLabel labelProducto1;
    public XRLabel labelCartones1;
    public XRLabel labelPorcentaje1;
    public GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel23;
    private XRLabel xrLabel1;
    public XRLabel labelFecha2;
    public XRLabel labelFecha1;
    public XRLabel xrLabel2;
    public XRLabel xrLabel3;
    public XRLabel xrLabel5;
    public XRLabel xrLabel4;
    public XRLabel xrLabel6;
    public XRLabel xrLabel7;
    public XRLabel labelSeparador;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteDetallado()
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
            this.labelPorcentaje2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCartones2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelProducto1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCartones1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelPorcentaje1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFecha2 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelFecha1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.labelSeparador = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelPorcentaje2,
            this.labelCartones2,
            this.labelProducto2,
            this.labelProducto1,
            this.labelCartones1,
            this.labelPorcentaje1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 27.08333F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelPorcentaje2
            // 
            this.labelPorcentaje2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPorcentaje2.Dpi = 100F;
            this.labelPorcentaje2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPorcentaje2.LocationFloat = new DevExpress.Utils.PointFloat(687.92F, 0F);
            this.labelPorcentaje2.Name = "labelPorcentaje2";
            this.labelPorcentaje2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPorcentaje2.SizeF = new System.Drawing.SizeF(125.08F, 23F);
            this.labelPorcentaje2.StylePriority.UseBorders = false;
            this.labelPorcentaje2.StylePriority.UseFont = false;
            this.labelPorcentaje2.StylePriority.UseTextAlignment = false;
            this.labelPorcentaje2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelCartones2
            // 
            this.labelCartones2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCartones2.Dpi = 100F;
            this.labelCartones2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCartones2.LocationFloat = new DevExpress.Utils.PointFloat(587.3782F, 0F);
            this.labelCartones2.Name = "labelCartones2";
            this.labelCartones2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCartones2.SizeF = new System.Drawing.SizeF(100.5417F, 23F);
            this.labelCartones2.StylePriority.UseBorders = false;
            this.labelCartones2.StylePriority.UseFont = false;
            this.labelCartones2.StylePriority.UseTextAlignment = false;
            this.labelCartones2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelProducto2
            // 
            this.labelProducto2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelProducto2.Dpi = 100F;
            this.labelProducto2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducto2.LocationFloat = new DevExpress.Utils.PointFloat(434F, 0F);
            this.labelProducto2.Name = "labelProducto2";
            this.labelProducto2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto2.SizeF = new System.Drawing.SizeF(153.3733F, 23F);
            this.labelProducto2.StylePriority.UseBorders = false;
            this.labelProducto2.StylePriority.UseFont = false;
            this.labelProducto2.StylePriority.UseTextAlignment = false;
            this.labelProducto2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelProducto1
            // 
            this.labelProducto1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelProducto1.Dpi = 100F;
            this.labelProducto1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducto1.LocationFloat = new DevExpress.Utils.PointFloat(11F, 0F);
            this.labelProducto1.Name = "labelProducto1";
            this.labelProducto1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelProducto1.SizeF = new System.Drawing.SizeF(152.8783F, 23F);
            this.labelProducto1.StylePriority.UseBorders = false;
            this.labelProducto1.StylePriority.UseFont = false;
            this.labelProducto1.StylePriority.UseTextAlignment = false;
            this.labelProducto1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelCartones1
            // 
            this.labelCartones1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelCartones1.Dpi = 100F;
            this.labelCartones1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCartones1.LocationFloat = new DevExpress.Utils.PointFloat(163.8784F, 0F);
            this.labelCartones1.Name = "labelCartones1";
            this.labelCartones1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCartones1.SizeF = new System.Drawing.SizeF(100.5417F, 23F);
            this.labelCartones1.StylePriority.UseBorders = false;
            this.labelCartones1.StylePriority.UseFont = false;
            this.labelCartones1.StylePriority.UseTextAlignment = false;
            this.labelCartones1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // labelPorcentaje1
            // 
            this.labelPorcentaje1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelPorcentaje1.Dpi = 100F;
            this.labelPorcentaje1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPorcentaje1.LocationFloat = new DevExpress.Utils.PointFloat(264.4201F, 0F);
            this.labelPorcentaje1.Name = "labelPorcentaje1";
            this.labelPorcentaje1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelPorcentaje1.SizeF = new System.Drawing.SizeF(125.08F, 23F);
            this.labelPorcentaje1.StylePriority.UseBorders = false;
            this.labelPorcentaje1.StylePriority.UseFont = false;
            this.labelPorcentaje1.StylePriority.UseTextAlignment = false;
            this.labelPorcentaje1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            // PageHeader
            // 
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 0F;
            this.PageHeader.Name = "PageHeader";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel23,
            this.xrLabel1,
            this.labelFecha2,
            this.labelFecha1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel6,
            this.xrLabel7,
            this.labelSeparador});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 117.7083F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(10.5F, 47.04163F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(380F, 23F);
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Anual";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(433F, 47.04163F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(380F, 23F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Mes Actual";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelFecha2
            // 
            this.labelFecha2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelFecha2.Dpi = 100F;
            this.labelFecha2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha2.LocationFloat = new DevExpress.Utils.PointFloat(433F, 70.04163F);
            this.labelFecha2.Name = "labelFecha2";
            this.labelFecha2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFecha2.SizeF = new System.Drawing.SizeF(380F, 23F);
            this.labelFecha2.StylePriority.UseBorders = false;
            this.labelFecha2.StylePriority.UseFont = false;
            this.labelFecha2.StylePriority.UseTextAlignment = false;
            this.labelFecha2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // labelFecha1
            // 
            this.labelFecha1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.labelFecha1.Dpi = 100F;
            this.labelFecha1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha1.LocationFloat = new DevExpress.Utils.PointFloat(10.5F, 70.04163F);
            this.labelFecha1.Name = "labelFecha1";
            this.labelFecha1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelFecha1.SizeF = new System.Drawing.SizeF(380F, 23F);
            this.labelFecha1.StylePriority.UseBorders = false;
            this.labelFecha1.StylePriority.UseFont = false;
            this.labelFecha1.StylePriority.UseTextAlignment = false;
            this.labelFecha1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(163.8784F, 93.04163F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100.5417F, 23F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Cartones";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(264.4201F, 93.04164F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(125.08F, 23F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "% vs Año Anterior";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(587.3783F, 93.04163F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(100.5417F, 23F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Cartones";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(687.92F, 93.04164F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(125.08F, 23F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "% vs Año Anterior";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(433.995F, 93.04164F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(153.3783F, 23F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Vendedor";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(11.00001F, 93.04164F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(152.8784F, 23F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Vendedor";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // labelSeparador
            // 
            this.labelSeparador.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.labelSeparador.Dpi = 100F;
            this.labelSeparador.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeparador.LocationFloat = new DevExpress.Utils.PointFloat(11F, 0F);
            this.labelSeparador.Name = "labelSeparador";
            this.labelSeparador.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelSeparador.SizeF = new System.Drawing.SizeF(802.4999F, 47.04163F);
            this.labelSeparador.StylePriority.UseBorders = false;
            this.labelSeparador.StylePriority.UseFont = false;
            this.labelSeparador.StylePriority.UseTextAlignment = false;
            this.labelSeparador.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // SubReporteDetallado
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(12, 14, 0, 0);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
