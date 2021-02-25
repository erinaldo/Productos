using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for report_SubNoVisitados
/// </summary>
public class report_SubNoVisitadosVit : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private ReportHeaderBand reportHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private XRLabel xrLabel15;
    public XRLabel L_Clave;
    public XRLabel L_NombreCliente;
    public GroupHeaderBand GroupHeader1;
    private DevExpress.XtraReports.Parameters.Parameter Fecha;
    public XRLabel L_Secuencia;
    //private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
    private DevExpress.XtraReports.Parameters.Parameter Ruta;
    public XRLabel L_Calle;
    public XRLabel L_Municipio;
    private XRLabel lbCalle;
    private XRLabel lbMunicipio;
    public XRLabel Rutas;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public report_SubNoVisitadosVit()
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
            this.components = new System.ComponentModel.Container();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.L_Calle = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Municipio = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Clave = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NombreCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Secuencia = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbCalle = new DevExpress.XtraReports.UI.XRLabel();
            this.lbMunicipio = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Fecha = new DevExpress.XtraReports.Parameters.Parameter();
            this.Ruta = new DevExpress.XtraReports.Parameters.Parameter();
            this.Rutas = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_Calle,
            this.L_Municipio,
            this.L_Clave,
            this.L_NombreCliente,
            this.L_Secuencia});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 14.5F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // L_Calle
            // 
            this.L_Calle.Dpi = 100F;
            this.L_Calle.LocationFloat = new DevExpress.Utils.PointFloat(729.2853F, 0F);
            this.L_Calle.Name = "L_Calle";
            this.L_Calle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Calle.SizeF = new System.Drawing.SizeF(300.7147F, 14.5F);
            this.L_Calle.StylePriority.UseTextAlignment = false;
            this.L_Calle.Text = "Calle";
            this.L_Calle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Municipio
            // 
            this.L_Municipio.Dpi = 100F;
            this.L_Municipio.LocationFloat = new DevExpress.Utils.PointFloat(466.2501F, 0F);
            this.L_Municipio.Name = "L_Municipio";
            this.L_Municipio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Municipio.SizeF = new System.Drawing.SizeF(262.2019F, 14.5F);
            this.L_Municipio.StylePriority.UseTextAlignment = false;
            this.L_Municipio.Text = "Municipio";
            this.L_Municipio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Clave
            // 
            this.L_Clave.Dpi = 100F;
            this.L_Clave.LocationFloat = new DevExpress.Utils.PointFloat(61.68F, 0F);
            this.L_Clave.Name = "L_Clave";
            this.L_Clave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Clave.SizeF = new System.Drawing.SizeF(111.17F, 14.5F);
            this.L_Clave.StylePriority.UseTextAlignment = false;
            this.L_Clave.Text = "Clave";
            this.L_Clave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_NombreCliente
            // 
            this.L_NombreCliente.Dpi = 100F;
            this.L_NombreCliente.LocationFloat = new DevExpress.Utils.PointFloat(172.89F, 0F);
            this.L_NombreCliente.Name = "L_NombreCliente";
            this.L_NombreCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_NombreCliente.SizeF = new System.Drawing.SizeF(282.79F, 14.5F);
            this.L_NombreCliente.StylePriority.UseTextAlignment = false;
            this.L_NombreCliente.Text = "NombreCliente";
            this.L_NombreCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_Secuencia
            // 
            this.L_Secuencia.Dpi = 100F;
            this.L_Secuencia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.L_Secuencia.Name = "L_Secuencia";
            this.L_Secuencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Secuencia.SizeF = new System.Drawing.SizeF(61.68F, 14.5F);
            this.L_Secuencia.StylePriority.UseTextAlignment = false;
            this.L_Secuencia.Text = "Sec";
            this.L_Secuencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 25F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 25F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "eRouteConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbCalle,
            this.lbMunicipio,
            this.xrLabel15});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 17.74359F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // lbCalle
            // 
            this.lbCalle.Dpi = 100F;
            this.lbCalle.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalle.LocationFloat = new DevExpress.Utils.PointFloat(728.8687F, 0F);
            this.lbCalle.Name = "lbCalle";
            this.lbCalle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCalle.SizeF = new System.Drawing.SizeF(301.1313F, 14.54873F);
            this.lbCalle.StyleName = "FieldCaption";
            this.lbCalle.StylePriority.UseFont = false;
            this.lbCalle.Text = "Calle";
            // 
            // lbMunicipio
            // 
            this.lbMunicipio.Dpi = 100F;
            this.lbMunicipio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMunicipio.LocationFloat = new DevExpress.Utils.PointFloat(465.8334F, 0F);
            this.lbMunicipio.Name = "lbMunicipio";
            this.lbMunicipio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbMunicipio.SizeF = new System.Drawing.SizeF(262.6186F, 14.54873F);
            this.lbMunicipio.StyleName = "FieldCaption";
            this.lbMunicipio.StylePriority.UseFont = false;
            this.lbMunicipio.Text = "Municipio";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(10.59138F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(167.8269F, 14.54873F);
            this.xrLabel15.StyleName = "FieldCaption";
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "Clientes No Visitados";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 21F);
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8F);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Arial", 9F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Rutas});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Fecha", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 40.625F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Fecha
            // 
            this.Fecha.Description = "fecha_ClienteNoVisitado";
            this.Fecha.Name = "Fecha";
            this.Fecha.Visible = false;
            // 
            // Ruta
            // 
            this.Ruta.Description = "Ruta de vendedor";
            this.Ruta.Name = "Ruta";
            this.Ruta.Visible = false;
            // 
            // Rutas
            // 
            this.Rutas.Dpi = 100F;
            this.Rutas.LocationFloat = new DevExpress.Utils.PointFloat(10.59138F, 10.00001F);
            this.Rutas.Name = "Rutas";
            this.Rutas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Rutas.SizeF = new System.Drawing.SizeF(282.79F, 14.5F);
            this.Rutas.StylePriority.UseTextAlignment = false;
            this.Rutas.Text = "NombreCliente";
            this.Rutas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // report_SubNoVisitadosVit
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.reportHeaderBand1,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.FilterString = "[Fecha] = ?Fecha And [Ruta] = ?Ruta";
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(33, 35, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Fecha,
            this.Ruta});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
