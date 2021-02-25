using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for ProximidadRIP
/// </summary>
public class ProximidadRIP : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private PageFooterBand pageFooterBand1;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private GroupFooterBand groupFooterBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.XtraReports.Parameters.Parameter parameterCEDIS;
    private DevExpress.XtraReports.Parameters.Parameter parameterEsquemas;
    private DevExpress.XtraReports.Parameters.Parameter parameterFechaInicial;
    private String CEDIS;
    private String Esquemas;
    private String FechaInit;
    private String FInicial;
    private String nombresEsquemas;
    private String nombreCEDIS;
    private int week = 0;
    private int count;
    private String QueryString;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private FormattingRule formattingRuleCoberturaRed;
    private FormattingRule formattingRuleCoberturaGreen;
    private FormattingRule formattingRuleClientesRed;
    private FormattingRule formattingRuleClientesGreen;
    private FormattingRule formattingRuleDevolucionGreen;
    private FormattingRule formattingRuleDevolucionRed;
    private FormattingRule formattingRuleVentaGreen;
    private FormattingRule formattingRuleVentaRed;
    private FormattingRule formattingRuleVentaPromGreen;
    private FormattingRule formattingRuleVentaPromRed;
    private PageHeaderBand PageHeader;
    private XRLabel empresa;
    private XRLabel fecha;
    private XRLabel centro;
    private XRLabel xrLabel72;
    private XRLabel xrLabel70;
    private XRLabel xrLabel69;
    private XRLabel xrLabel42;
    private XRLabel esquema;
    private XRPictureBox logo;
    private XRLabel semana;
    private XRLabel xrLabel27;
    private XRLabel labelP;
    private XRLabel labelW;
    private XRLabel xrLabel4;
    private XRLabel w5;
    private XRLabel xrLabel14;
    private XRLabel xrLabel10;
    private XRLabel xrLabel3;
    private XRLine xrLine4;
    private XRLine xrLine3;
    private XRLabel xrLabel34;
    private XRLabel xrLabel9;
    private XRLabel w4;
    private XRLabel xrLabel37;
    private XRLabel w3;
    private XRLabel xrLabel39;
    private XRLabel w2;
    private XRLabel xrLabel41;
    private XRLabel w1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel11;
    private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

    public XtraReport ProximidadRIPGet(String nombreCEDIS, String dateStatus, String CEDIS, String Esquemas, String nombresEsquemas, String FechaInicial)
    {
        if (FechaInicial != null)
        {
            DateTime init = DateTime.Parse(FechaInicial);
            switch (dateStatus)
            {
                case "Igual":
                    this.FechaInit = init.Date.ToString("yyyy-MM-ddTHH:mm:ss");
                    break;
            }
        }
        this.CEDIS = CEDIS;
        this.Esquemas = Esquemas;
        this.FInicial = FechaInicial;
        this.nombreCEDIS = nombreCEDIS;
        this.nombresEsquemas = nombresEsquemas;
        this.count = CountRows();
        if (this.count > 0)
        {
            InitializeComponent();
            return this;
        }
        else
        {
            return null;
        }
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
        DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
        DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProximidadRIP));
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.formattingRuleClientesGreen = new DevExpress.XtraReports.UI.FormattingRule();
        this.formattingRuleClientesRed = new DevExpress.XtraReports.UI.FormattingRule();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.formattingRuleCoberturaRed = new DevExpress.XtraReports.UI.FormattingRule();
        this.formattingRuleCoberturaGreen = new DevExpress.XtraReports.UI.FormattingRule();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.formattingRuleDevolucionGreen = new DevExpress.XtraReports.UI.FormattingRule();
        this.formattingRuleDevolucionRed = new DevExpress.XtraReports.UI.FormattingRule();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.formattingRuleVentaGreen = new DevExpress.XtraReports.UI.FormattingRule();
        this.formattingRuleVentaRed = new DevExpress.XtraReports.UI.FormattingRule();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.formattingRuleVentaPromGreen = new DevExpress.XtraReports.UI.FormattingRule();
        this.formattingRuleVentaPromRed = new DevExpress.XtraReports.UI.FormattingRule();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.parameterCEDIS = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterEsquemas = new DevExpress.XtraReports.Parameters.Parameter();
        this.parameterFechaInicial = new DevExpress.XtraReports.Parameters.Parameter();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.labelP = new DevExpress.XtraReports.UI.XRLabel();
        this.labelW = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.w5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.w4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.w3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
        this.w2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.w1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.empresa = new DevExpress.XtraReports.UI.XRLabel();
        this.fecha = new DevExpress.XtraReports.UI.XRLabel();
        this.centro = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.esquema = new DevExpress.XtraReports.UI.XRLabel();
        this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
        this.semana = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel26});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 15F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.StyleName = "DataField";
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel15
        // 
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.Clave")});
        this.xrLabel15.Dpi = 100F;
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(70F, 15F);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "xrLabel15";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel16
        // 
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.ClientesConVentaW")});
        this.xrLabel16.Dpi = 100F;
        this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel16.FormattingRules.Add(this.formattingRuleClientesGreen);
        this.xrLabel16.FormattingRules.Add(this.formattingRuleClientesRed);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(550F, 0F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "xrLabel16";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // formattingRuleClientesGreen
        // 
        this.formattingRuleClientesGreen.Condition = "ToDouble([ClientesConVentaW]) > [ClientesConVentaW4]";
        // 
        // 
        // 
        this.formattingRuleClientesGreen.Formatting.ForeColor = System.Drawing.Color.LimeGreen;
        this.formattingRuleClientesGreen.Name = "formattingRuleClientesGreen";
        // 
        // formattingRuleClientesRed
        // 
        this.formattingRuleClientesRed.Condition = "ToDouble([ClientesConVentaW]) < [ClientesConVentaW4]";
        // 
        // 
        // 
        this.formattingRuleClientesRed.Formatting.ForeColor = System.Drawing.Color.Red;
        this.formattingRuleClientesRed.Name = "formattingRuleClientesRed";
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.ClientesConVentaW4", "{0:n}")});
        this.xrLabel17.Dpi = 100F;
        this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(610F, 0F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "xrLabel17";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel18
        // 
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.CoberturaW", "{0:#0.0000}%")});
        this.xrLabel18.Dpi = 100F;
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel18.FormattingRules.Add(this.formattingRuleCoberturaRed);
        this.xrLabel18.FormattingRules.Add(this.formattingRuleCoberturaGreen);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(370F, 0F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "xrLabel18";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // formattingRuleCoberturaRed
        // 
        this.formattingRuleCoberturaRed.Condition = "[CoberturaW] < [CoberturaW4]";
        // 
        // 
        // 
        this.formattingRuleCoberturaRed.Formatting.BorderColor = System.Drawing.Color.Black;
        this.formattingRuleCoberturaRed.Formatting.ForeColor = System.Drawing.Color.Red;
        this.formattingRuleCoberturaRed.Name = "formattingRuleCoberturaRed";
        // 
        // formattingRuleCoberturaGreen
        // 
        this.formattingRuleCoberturaGreen.Condition = "[CoberturaW] > [CoberturaW4]";
        // 
        // 
        // 
        this.formattingRuleCoberturaGreen.Formatting.ForeColor = System.Drawing.Color.LimeGreen;
        this.formattingRuleCoberturaGreen.Name = "formattingRuleCoberturaGreen";
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.CoberturaW4", "{0:#0.0000}%")});
        this.xrLabel19.Dpi = 100F;
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(460F, 0F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "xrLabel19";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel20
        // 
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.DevolucionW", "{0:#0.0000}%")});
        this.xrLabel20.Dpi = 100F;
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel20.FormattingRules.Add(this.formattingRuleDevolucionGreen);
        this.xrLabel20.FormattingRules.Add(this.formattingRuleDevolucionRed);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(790F, 0F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "xrLabel20";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // formattingRuleDevolucionGreen
        // 
        this.formattingRuleDevolucionGreen.Condition = "[DevolucionW] > [DevolucionW4]";
        // 
        // 
        // 
        this.formattingRuleDevolucionGreen.Formatting.ForeColor = System.Drawing.Color.LimeGreen;
        this.formattingRuleDevolucionGreen.Name = "formattingRuleDevolucionGreen";
        // 
        // formattingRuleDevolucionRed
        // 
        this.formattingRuleDevolucionRed.Condition = "[DevolucionW] < [DevolucionW4]";
        // 
        // 
        // 
        this.formattingRuleDevolucionRed.Formatting.ForeColor = System.Drawing.Color.Red;
        this.formattingRuleDevolucionRed.Name = "formattingRuleDevolucionRed";
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.DevolucionW4", "{0:#0.0000}%")});
        this.xrLabel21.Dpi = 100F;
        this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(880F, 0F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "xrLabel21";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel22
        // 
        this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.Producto")});
        this.xrLabel22.Dpi = 100F;
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(70F, 0F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(300F, 15F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "xrLabel22";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel23
        // 
        this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.VentaNetaW", "{0:n1}")});
        this.xrLabel23.Dpi = 100F;
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel23.FormattingRules.Add(this.formattingRuleVentaGreen);
        this.xrLabel23.FormattingRules.Add(this.formattingRuleVentaRed);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(670F, 0F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "xrLabel23";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // formattingRuleVentaGreen
        // 
        this.formattingRuleVentaGreen.Condition = "[VentaNetaW] > [VentaNetaW4]";
        // 
        // 
        // 
        this.formattingRuleVentaGreen.Formatting.ForeColor = System.Drawing.Color.LimeGreen;
        this.formattingRuleVentaGreen.Name = "formattingRuleVentaGreen";
        // 
        // formattingRuleVentaRed
        // 
        this.formattingRuleVentaRed.Condition = "[VentaNetaW] < [VentaNetaW4]";
        // 
        // 
        // 
        this.formattingRuleVentaRed.Formatting.ForeColor = System.Drawing.Color.Red;
        this.formattingRuleVentaRed.Name = "formattingRuleVentaRed";
        // 
        // xrLabel24
        // 
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.VentaNetaW4", "{0:n1}")});
        this.xrLabel24.Dpi = 100F;
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(730F, 0F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "xrLabel24";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel25
        // 
        this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.VentPromSemW", "{0:n}")});
        this.xrLabel25.Dpi = 100F;
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel25.FormattingRules.Add(this.formattingRuleVentaPromGreen);
        this.xrLabel25.FormattingRules.Add(this.formattingRuleVentaPromRed);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(970F, 0F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "xrLabel25";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // formattingRuleVentaPromGreen
        // 
        this.formattingRuleVentaPromGreen.Condition = "[VentPromSemW] > [VentPromSemW4]";
        // 
        // 
        // 
        this.formattingRuleVentaPromGreen.Formatting.ForeColor = System.Drawing.Color.LimeGreen;
        this.formattingRuleVentaPromGreen.Name = "formattingRuleVentaPromGreen";
        // 
        // formattingRuleVentaPromRed
        // 
        this.formattingRuleVentaPromRed.Condition = "[VentPromSemW] < [VentPromSemW4]";
        // 
        // 
        // 
        this.formattingRuleVentaPromRed.Formatting.ForeColor = System.Drawing.Color.Red;
        this.formattingRuleVentaPromRed.Name = "formattingRuleVentaPromRed";
        // 
        // xrLabel26
        // 
        this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.VentPromSemW4", "{0:n}")});
        this.xrLabel26.Dpi = 100F;
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(1030F, 0F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "xrLabel26";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 100F;
        this.TopMargin.HeightF = 5F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 100F;
        this.BottomMargin.HeightF = 5F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // sqlDataSource1
        // 
        this.sqlDataSource1.ConnectionName = "eRouteConnection";
        this.sqlDataSource1.ConnectionOptions.CommandTimeout = 3000;
        this.sqlDataSource1.Name = "sqlDataSource1";
        storedProcQuery1.Name = "stpr_ReporteProximidadRIP";
        queryParameter1.Name = "@filtroCEDIS";
        queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterCEDIS]", typeof(string));
        queryParameter2.Name = "@filtroEsquemas";
        queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterEsquemas]", typeof(string));
        queryParameter3.Name = "@filtroFechaInicio";
        queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
        queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.parameterFechaInicial]", typeof(string));
        storedProcQuery1.Parameters.Add(queryParameter1);
        storedProcQuery1.Parameters.Add(queryParameter2);
        storedProcQuery1.Parameters.Add(queryParameter3);
        storedProcQuery1.StoredProcName = "stpr_ReporteProximidadRIP";
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
        // 
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
        this.groupHeaderBand1.Dpi = 100F;
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Esquema", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.HeightF = 15F;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        // 
        // xrLabel2
        // 
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "stpr_ReporteProximidadRIP.Esquema")});
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(80F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(500F, 15F);
        this.xrLabel2.StyleName = "DataField";
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "xrLabel2";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(20F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel1.StyleName = "FieldCaption";
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "Esquema";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // pageFooterBand1
        // 
        this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
        this.pageFooterBand1.Dpi = 100F;
        this.pageFooterBand1.HeightF = 15F;
        this.pageFooterBand1.Name = "pageFooterBand1";
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Dpi = 100F;
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(200F, 15F);
        this.xrPageInfo1.StyleName = "PageInfo";
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Dpi = 100F;
        this.xrPageInfo2.Format = "Página {0} de {1}";
        this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(990F, 0F);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.SizeF = new System.Drawing.SizeF(100F, 15F);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.StylePriority.UseTextAlignment = false;
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // groupFooterBand1
        // 
        this.groupFooterBand1.Dpi = 100F;
        this.groupFooterBand1.HeightF = 1F;
        this.groupFooterBand1.Name = "groupFooterBand1";
        // 
        // Title
        // 
        this.Title.BackColor = System.Drawing.Color.Transparent;
        this.Title.BorderColor = System.Drawing.Color.Black;
        this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.Title.BorderWidth = 1F;
        this.Title.Font = new System.Drawing.Font("Times New Roman", 24F);
        this.Title.ForeColor = System.Drawing.Color.Black;
        this.Title.Name = "Title";
        // 
        // FieldCaption
        // 
        this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
        this.FieldCaption.BorderColor = System.Drawing.Color.Black;
        this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.FieldCaption.BorderWidth = 1F;
        this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.FieldCaption.ForeColor = System.Drawing.Color.Black;
        this.FieldCaption.Name = "FieldCaption";
        // 
        // PageInfo
        // 
        this.PageInfo.BackColor = System.Drawing.Color.Transparent;
        this.PageInfo.BorderColor = System.Drawing.Color.Black;
        this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.PageInfo.BorderWidth = 1F;
        this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.PageInfo.ForeColor = System.Drawing.Color.Black;
        this.PageInfo.Name = "PageInfo";
        // 
        // DataField
        // 
        this.DataField.BackColor = System.Drawing.Color.Transparent;
        this.DataField.BorderColor = System.Drawing.Color.Black;
        this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.DataField.BorderWidth = 1F;
        this.DataField.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.DataField.ForeColor = System.Drawing.Color.Black;
        this.DataField.Name = "DataField";
        this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        // 
        // parameterCEDIS
        // 
        this.parameterCEDIS.Name = "parameterCEDIS";
        this.parameterCEDIS.Visible = false;
        // 
        // parameterEsquemas
        // 
        this.parameterEsquemas.Name = "parameterEsquemas";
        this.parameterEsquemas.Visible = false;
        // 
        // parameterFechaInicial
        // 
        this.parameterFechaInicial.Name = "parameterFechaInicial";
        this.parameterFechaInicial.ValueInfo = "2017-12-04T00:00:00";
        this.parameterFechaInicial.Visible = false;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.labelP,
            this.labelW,
            this.xrLabel4,
            this.w5,
            this.xrLabel14,
            this.xrLabel10,
            this.xrLabel3,
            this.xrLine4,
            this.xrLine3,
            this.xrLabel34,
            this.xrLabel9,
            this.w4,
            this.xrLabel37,
            this.w3,
            this.xrLabel39,
            this.w2,
            this.xrLabel41,
            this.w1,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel11,
            this.empresa,
            this.fecha,
            this.centro,
            this.xrLabel72,
            this.xrLabel70,
            this.xrLabel69,
            this.xrLabel42,
            this.esquema,
            this.logo,
            this.semana,
            this.xrLabel27});
        this.PageHeader.Dpi = 100F;
        this.PageHeader.HeightF = 253.9999F;
        this.PageHeader.Name = "PageHeader";
        // 
        // labelP
        // 
        this.labelP.Dpi = 100F;
        this.labelP.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.labelP.LocationFloat = new DevExpress.Utils.PointFloat(460F, 238.9999F);
        this.labelP.Name = "labelP";
        this.labelP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.labelP.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.labelP.StylePriority.UseFont = false;
        this.labelP.StylePriority.UseTextAlignment = false;
        this.labelP.Text = "labelP";
        this.labelP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // labelW
        // 
        this.labelW.Dpi = 100F;
        this.labelW.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.labelW.LocationFloat = new DevExpress.Utils.PointFloat(370F, 238.9999F);
        this.labelW.Name = "labelW";
        this.labelW.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.labelW.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.labelW.StylePriority.UseFont = false;
        this.labelW.StylePriority.UseTextAlignment = false;
        this.labelW.Text = "labelW";
        this.labelW.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(70F, 238.9999F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(300F, 15F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Venta Total (Pzas) = ";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // w5
        // 
        this.w5.Dpi = 100F;
        this.w5.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.w5.LocationFloat = new DevExpress.Utils.PointFloat(970F, 222F);
        this.w5.Name = "w5";
        this.w5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.w5.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.w5.StylePriority.UseFont = false;
        this.w5.StylePriority.UseTextAlignment = false;
        this.w5.Text = "W";
        this.w5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(1030F, 222F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Prom. W4";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(70F, 192F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(300F, 45F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Producto";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 192F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(70F, 45F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Clave";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLine4
        // 
        this.xrLine4.Dpi = 100F;
        this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 236.9999F);
        this.xrLine4.Name = "xrLine4";
        this.xrLine4.SizeF = new System.Drawing.SizeF(1090F, 2F);
        // 
        // xrLine3
        // 
        this.xrLine3.Dpi = 100F;
        this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 190F);
        this.xrLine3.Name = "xrLine3";
        this.xrLine3.SizeF = new System.Drawing.SizeF(1090F, 2F);
        // 
        // xrLabel34
        // 
        this.xrLabel34.Dpi = 100F;
        this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(970F, 192F);
        this.xrLabel34.Multiline = true;
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.SizeF = new System.Drawing.SizeF(120F, 30F);
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.StylePriority.UseTextAlignment = false;
        this.xrLabel34.Text = "Vta. Prom. X Clte.\r\nSem. (Pzas)";
        this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(880F, 221.9999F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Prom. W4";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // w4
        // 
        this.w4.Dpi = 100F;
        this.w4.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.w4.LocationFloat = new DevExpress.Utils.PointFloat(790F, 221.9999F);
        this.w4.Name = "w4";
        this.w4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.w4.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.w4.StylePriority.UseFont = false;
        this.w4.StylePriority.UseTextAlignment = false;
        this.w4.Text = "W";
        this.w4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel37
        // 
        this.xrLabel37.Dpi = 100F;
        this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(730F, 221.9999F);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        this.xrLabel37.Text = "Prom. W4";
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // w3
        // 
        this.w3.Dpi = 100F;
        this.w3.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.w3.LocationFloat = new DevExpress.Utils.PointFloat(670F, 221.9999F);
        this.w3.Name = "w3";
        this.w3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.w3.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.w3.StylePriority.UseFont = false;
        this.w3.StylePriority.UseTextAlignment = false;
        this.w3.Text = "W";
        this.w3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel39
        // 
        this.xrLabel39.Dpi = 100F;
        this.xrLabel39.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(610F, 221.9999F);
        this.xrLabel39.Name = "xrLabel39";
        this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel39.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.xrLabel39.StylePriority.UseFont = false;
        this.xrLabel39.StylePriority.UseTextAlignment = false;
        this.xrLabel39.Text = "Prom. W4";
        this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // w2
        // 
        this.w2.Dpi = 100F;
        this.w2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.w2.LocationFloat = new DevExpress.Utils.PointFloat(550F, 221.9999F);
        this.w2.Name = "w2";
        this.w2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.w2.SizeF = new System.Drawing.SizeF(60F, 15F);
        this.w2.StylePriority.UseFont = false;
        this.w2.StylePriority.UseTextAlignment = false;
        this.w2.Text = "W";
        this.w2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel41
        // 
        this.xrLabel41.Dpi = 100F;
        this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(460F, 222F);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel41.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.xrLabel41.StylePriority.UseFont = false;
        this.xrLabel41.StylePriority.UseTextAlignment = false;
        this.xrLabel41.Text = "Prom. W4";
        this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // w1
        // 
        this.w1.Dpi = 100F;
        this.w1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.w1.LocationFloat = new DevExpress.Utils.PointFloat(370F, 222F);
        this.w1.Name = "w1";
        this.w1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.w1.SizeF = new System.Drawing.SizeF(90F, 15F);
        this.w1.StylePriority.UseFont = false;
        this.w1.StylePriority.UseTextAlignment = false;
        this.w1.Text = "W";
        this.w1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Dpi = 100F;
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(370F, 192F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(180F, 30F);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "% Cobertura";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(550F, 192F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(120F, 30F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Clientes Con Venta";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(670F, 192F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(120F, 30F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Venta Neta (Pzas)";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Dpi = 100F;
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(790F, 192F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(180F, 30F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "% Devolución";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // empresa
        // 
        this.empresa.Dpi = 100F;
        this.empresa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
        this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(275F, 17.5F);
        this.empresa.Name = "empresa";
        this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
        this.empresa.StylePriority.UseFont = false;
        this.empresa.StylePriority.UseTextAlignment = false;
        this.empresa.Text = "empresa";
        this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // fecha
        // 
        this.fecha.Dpi = 100F;
        this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(155F, 157.5F);
        this.fecha.Name = "fecha";
        this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.fecha.SizeF = new System.Drawing.SizeF(930F, 15F);
        this.fecha.StylePriority.UseTextAlignment = false;
        this.fecha.Text = "fecha";
        this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // centro
        // 
        this.centro.Dpi = 100F;
        this.centro.LocationFloat = new DevExpress.Utils.PointFloat(155F, 127.5F);
        this.centro.Name = "centro";
        this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.centro.SizeF = new System.Drawing.SizeF(930F, 15F);
        this.centro.StylePriority.UseTextAlignment = false;
        this.centro.Text = "centro";
        this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel72
        // 
        this.xrLabel72.Dpi = 100F;
        this.xrLabel72.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(5F, 142.5F);
        this.xrLabel72.Name = "xrLabel72";
        this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel72.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel72.StylePriority.UseFont = false;
        this.xrLabel72.StylePriority.UseTextAlignment = false;
        this.xrLabel72.Text = "Esquemas:";
        this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel70
        // 
        this.xrLabel70.Dpi = 100F;
        this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(5F, 157.5F);
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
        this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(5F, 127.5F);
        this.xrLabel69.Name = "xrLabel69";
        this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel69.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel69.StylePriority.UseFont = false;
        this.xrLabel69.StylePriority.UseTextAlignment = false;
        this.xrLabel69.Text = "Centro De Distribución:";
        this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel42
        // 
        this.xrLabel42.Dpi = 100F;
        this.xrLabel42.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
        this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(275F, 77.5F);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.SizeF = new System.Drawing.SizeF(540F, 40F);
        this.xrLabel42.StyleName = "Title";
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.StylePriority.UseTextAlignment = false;
        this.xrLabel42.Text = "Reporte De Proximidad RIP";
        this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // esquema
        // 
        this.esquema.Dpi = 100F;
        this.esquema.LocationFloat = new DevExpress.Utils.PointFloat(155F, 142.5F);
        this.esquema.Name = "esquema";
        this.esquema.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.esquema.SizeF = new System.Drawing.SizeF(930F, 15F);
        this.esquema.StylePriority.UseTextAlignment = false;
        this.esquema.Text = "esquemas";
        this.esquema.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // logo
        // 
        this.logo.Dpi = 100F;
        this.logo.LocationFloat = new DevExpress.Utils.PointFloat(20F, 12.5F);
        this.logo.Name = "logo";
        this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
        // 
        // semana
        // 
        this.semana.Dpi = 100F;
        this.semana.LocationFloat = new DevExpress.Utils.PointFloat(155F, 172.5F);
        this.semana.Name = "semana";
        this.semana.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.semana.SizeF = new System.Drawing.SizeF(930F, 15F);
        this.semana.StylePriority.UseTextAlignment = false;
        this.semana.Text = "semana";
        this.semana.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Dpi = 100F;
        this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(5F, 172.5F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(150F, 15F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "Semana:";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ProximidadRIP
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.pageFooterBand1,
            this.PageHeader});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
        this.DataMember = "stpr_ReporteProximidadRIP";
        this.DataSource = this.sqlDataSource1;
        this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRuleCoberturaRed,
            this.formattingRuleCoberturaGreen,
            this.formattingRuleClientesRed,
            this.formattingRuleClientesGreen,
            this.formattingRuleVentaRed,
            this.formattingRuleVentaGreen,
            this.formattingRuleDevolucionRed,
            this.formattingRuleDevolucionGreen,
            this.formattingRuleVentaPromRed,
            this.formattingRuleVentaPromGreen});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterCEDIS,
            this.parameterEsquemas,
            this.parameterFechaInicial});
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "16.1";
        this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.ProximidadRIP_DataSourceDemanded);
        this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ProximidadRIP_BeforePrint);
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void ProximidadRIP_DataSourceDemanded(object sender, EventArgs e)
    {
        this.Parameters["parameterCEDIS"].Value = this.CEDIS;
        this.Parameters["parameterEsquemas"].Value = this.Esquemas;
        this.Parameters["parameterFechaInicial"].Value = this.FechaInit;
    }

    private void ProximidadRIP_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (FInicial != null)
        {
            DateTime fInicio = DateTime.Parse(FInicial);
            week = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fInicio, CalendarWeekRule.FirstDay, fInicio.DayOfWeek);
            FInicial = fInicio.Date.ToShortDateString();
        }
        string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK)";
        byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
        MemoryStream mStream = new MemoryStream(byteArrayIn);
        string empresaQuery = "SELECT NombreEmpresa FROM Configuracion (NOLOCK)";
        string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();
        this.empresa.Text = nombreEmpresa;
        this.logo.Image = Image.FromStream(mStream);
        this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        this.fecha.Text = FInicial;
        this.semana.Text = "W" + Convert.ToString(week);
        this.esquema.Text = nombresEsquemas;
        this.centro.Text = nombreCEDIS;
        this.w1.Text = "W" + Convert.ToString(week);
        this.w2.Text = "W" + Convert.ToString(week);
        this.w3.Text = "W" + Convert.ToString(week);
        this.w4.Text = "W" + Convert.ToString(week);
        this.w5.Text = "W" + Convert.ToString(week);

        StringBuilder sConsultaW = new StringBuilder();
        sConsultaW.AppendLine("SET DATEFIRST 1 ");
        sConsultaW.AppendLine("DECLARE @SemanaDelAño INT, @FechaIniSel DATETIME, @FechaFinSel DATETIME, @FechaIni4Semanas DATETIME, @FechaFin4Semanas DATETIME ");
        sConsultaW.AppendLine("DECLARE @FechaSel DATETIME ");
        sConsultaW.AppendLine("SET @FechaSel = '" + this.FechaInit + "' ");
        sConsultaW.AppendLine("SET @SemanaDelAño = (SELECT Datepart(WEEK,@FechaSel)) ");
        sConsultaW.AppendLine("SET @FechaIniSel = DATEADD(DAY, 1 - DATEPART(WEEKDAY, @FechaSel), CAST(@FechaSel AS DATE)) ");
        sConsultaW.AppendLine("SET @FechaFinSel = DATEADD(DAY, 7 - DATEPART(WEEKDAY, @FechaSel), CAST(@FechaSel AS DATE)) ");
        sConsultaW.AppendLine("SET @FechaIni4Semanas = DATEADD (WEEK, -4, @FechaIniSel) ");
        sConsultaW.AppendLine("SET @FechaFin4Semanas = DATEADD (DAY, -1, @FechaIniSel) ");
        sConsultaW.AppendLine("DECLARE @CantidadTotal FLOAT, @ClientesTotales FLOAT, @CantidadTotalHist FLOAT, @ClientesTotalesHist FLOAT ");
        sConsultaW.AppendLine("SELECT SUM(TPD.Cantidad * PRD.Factor) AS W ");
        sConsultaW.AppendLine("FROM TransProd TRP (NOLOCK) ");
        sConsultaW.AppendLine("INNER JOIN TransProdDetalle TPD(NOLOCK) ON TRP.TransProdID = TPD.TransProdID ");
        sConsultaW.AppendLine("INNER JOIN Visita VIS(NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
        sConsultaW.AppendLine("INNER JOIN Dia(NOLOCK) ON DIA.DiaClave = VIS.DiaClave ");
        sConsultaW.AppendLine("INNER JOIN ProductoDetalle PRD(NOLOCK) ON TPD.ProductoClave = PRD.ProductoClave AND TPD.ProductoClave = PRD.ProductoDetClave AND PRD.PRUTipoUnidad = TPD.TipoUnidad ");
        sConsultaW.AppendLine("INNER JOIN VENCentroDistHist VCH(NOLOCK) ON Dia.FechaCaptura between VCH.VCHFechaInicial AND VCH.FechaFinal AND VCH.VendedorId = VIS.VendedorID ");
        sConsultaW.AppendLine("INNER JOIN Almacen ALM(NOLOCK) ON ALM.AlmacenID = VCH.AlmacenID ");
        sConsultaW.AppendLine("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 1 AND DIA.FechaCaptura between @FechaIniSel AND @FechaFinSel ");
        sConsultaW.AppendLine("AND ALM.AlmacenID IN ('" + this.CEDIS + "')");
        string totalWQuery = sConsultaW.ToString();
        string totalW = Connection.Query<string>(totalWQuery, null, null, true, 9000).FirstOrDefault();
        this.labelW.Text = Convert.ToString(Convert.ToInt32(totalW).ToString("0#,#"));

        StringBuilder sConsultaP = new StringBuilder();
        sConsultaP.AppendLine("SET DATEFIRST 1 ");
        sConsultaP.AppendLine("DECLARE @SemanaDelAño INT, @FechaIniSel datetime, @FechaFinSel datetime, @FechaIni4Semanas datetime, @FechaFin4Semanas datetime ");
        sConsultaP.AppendLine("DECLARE @FechaSel datetime ");
        sConsultaP.AppendLine("SET @FechaSel = '" + this.FechaInit + "' ");
        sConsultaP.AppendLine("SET @SemanaDelAño = (SELECT DATEPART(WEEK,@FechaSel)) ");
        sConsultaP.AppendLine("SET @FechaIniSel = DATEADD(DAY, 1 - DATEPART(WEEKDAY, @FechaSel), CAST(@FechaSel AS DATE)) ");
        sConsultaP.AppendLine("SET @FechaFinSel = DATEADD(DAY, 7 - DATEPART(WEEKDAY, @FechaSel), CAST(@FechaSel AS DATE)) ");
        sConsultaP.AppendLine("SET @FechaIni4Semanas = DATEADD (WEEK, -4, @FechaIniSel) ");
        sConsultaP.AppendLine("SET @FechaFin4Semanas = DATEADD (DAY, -1, @FechaIniSel) ");
        sConsultaP.AppendLine("DECLARE @CantidadTotal FLOAT, @ClientesTotales FLOAT, @CantidadTotalHist FLOAT, @ClientesTotalesHist FLOAT ");
        sConsultaP.AppendLine("SELECT SUM(TPD.Cantidad * PRD.Factor) AS P ");
        sConsultaP.AppendLine("FROM TransProd TRP (NOLOCK) ");
        sConsultaP.AppendLine("INNER JOIN TransProdDetalle TPD(NOLOCK) ON TRP.TransProdID = TPD.TransProdID ");
        sConsultaP.AppendLine("INNER JOIN Visita VIS(NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave ");
        sConsultaP.AppendLine("INNER JOIN Dia(NOLOCK) ON DIA.DiaClave = VIS.DiaClave ");
        sConsultaP.AppendLine("INNER JOIN ProductoDetalle PRD(NOLOCK) ON TPD.ProductoClave = PRD.ProductoClave AND TPD.ProductoClave = PRD.ProductoDetClave AND PRD.PRUTipoUnidad = TPD.TipoUnidad ");
        sConsultaP.AppendLine("INNER JOIN VENCentroDistHist VCH(NOLOCK) ON Dia.FechaCaptura between VCH.VCHFechaInicial AND VCH.FechaFinal AND VCH.VendedorId = VIS.VendedorID ");
        sConsultaP.AppendLine("INNER JOIN Almacen ALM(NOLOCK) ON ALM.AlmacenID = VCH.AlmacenID ");
        sConsultaP.AppendLine("WHERE TRP.Tipo = 1 AND TRP.TipoFase = 1 AND DIA.FechaCaptura between @FechaIni4Semanas AND @FechaFin4Semanas ");
        sConsultaP.AppendLine("AND ALM.AlmacenID IN ('" + this.CEDIS + "')");
        string totalPQuery = sConsultaP.ToString();
        string totalP = Connection.Query<string>(totalPQuery, null, null, true, 9000).FirstOrDefault();
        this.labelP.Text = Convert.ToString(Convert.ToInt32(totalP).ToString("0#,#"));
    }

    public int CountRows()
    {
        StringBuilder sConsulta = new StringBuilder();
        sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteProximidadRIP] ");
        sConsulta.AppendLine("@filtroCEDIS = '" + this.CEDIS + "', ");
        sConsulta.AppendLine("@filtroEsquemas = '" + this.Esquemas + "', ");
        sConsulta.AppendLine("@filtroFechaInicio = '" + this.FechaInit + "'");
        QueryString = sConsulta.ToString();
        List<ProximidadRIPModel> Proximidad = Connection.Query<ProximidadRIPModel>(QueryString, null, null, true, 9000).ToList();
        return Proximidad.Count;
    }

    private class ProximidadRIPModel
    {
        public string Esquema { get; set; }
        public string Clave { get; set; }
        public string TransProdID { get; set; }
        public string Producto { get; set; }
        public Decimal CoberturaW { get; set; }
        public Decimal CoberturaW4 { get; set; }
        public Decimal ClientesConVentaW { get; set; }
        public Decimal ClientesConVentaW4 { get; set; }
        public Decimal VentaNetaW { get; set; }
        public Decimal DevolucionW { get; set; }
        public Decimal DevolucionW4 { get; set; }
        public Decimal VentaNetaW4 { get; set; }
        public Decimal VentPromSemW { get; set; }
        public Decimal VentPromSemW4 { get; set; }
    }
}
