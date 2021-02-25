using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for SubliquidacionPorCodigo
/// </summary>
public class Ayudante : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel ayunombre;
    public XRLabel comision;
    public XRLabel chofenombre;
    public XRLabel empleado;
    private GroupHeaderBand GroupHeader1;
    public XRLabel rol;
    public XRLabel xrLabel1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Ayudante()
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
            this.comision = new DevExpress.XtraReports.UI.XRLabel();
            this.empleado = new DevExpress.XtraReports.UI.XRLabel();
            this.rol = new DevExpress.XtraReports.UI.XRLabel();
            this.chofenombre = new DevExpress.XtraReports.UI.XRLabel();
            this.ayunombre = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.comision,
            this.empleado,
            this.rol});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // comision
            // 
            this.comision.Dpi = 100F;
            this.comision.LocationFloat = new DevExpress.Utils.PointFloat(581.7875F, 0F);
            this.comision.Name = "comision";
            this.comision.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.comision.SizeF = new System.Drawing.SizeF(107.8486F, 23F);
            this.comision.StylePriority.UseTextAlignment = false;
            this.comision.Text = "comision";
            this.comision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // empleado
            // 
            this.empleado.Dpi = 100F;
            this.empleado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.empleado.Name = "empleado";
            this.empleado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empleado.SizeF = new System.Drawing.SizeF(250.5569F, 23F);
            this.empleado.Text = "empleado";
            // 
            // rol
            // 
            this.rol.Dpi = 100F;
            this.rol.LocationFloat = new DevExpress.Utils.PointFloat(335.3973F, 0F);
            this.rol.Name = "rol";
            this.rol.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rol.SizeF = new System.Drawing.SizeF(155.7653F, 23F);
            this.rol.Text = "rol";
            // 
            // chofenombre
            // 
            this.chofenombre.Dpi = 100F;
            this.chofenombre.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.chofenombre.Name = "chofenombre";
            this.chofenombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.chofenombre.SizeF = new System.Drawing.SizeF(250.5569F, 23F);
            this.chofenombre.Text = "Empleado";
            // 
            // ayunombre
            // 
            this.ayunombre.Dpi = 100F;
            this.ayunombre.LocationFloat = new DevExpress.Utils.PointFloat(581.7875F, 0F);
            this.ayunombre.Name = "ayunombre";
            this.ayunombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ayunombre.SizeF = new System.Drawing.SizeF(107.8486F, 23F);
            this.ayunombre.StylePriority.UseTextAlignment = false;
            this.ayunombre.Text = "Comisión";
            this.ayunombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.BottomMargin.HeightF = 0.541687F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.chofenombre,
            this.ayunombre,
            this.xrLabel1});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 26.04167F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(335.3973F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(155.7652F, 23F);
            this.xrLabel1.Text = "Rol";
            // 
            // Ayudante
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(0, 24, 0, 1);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
