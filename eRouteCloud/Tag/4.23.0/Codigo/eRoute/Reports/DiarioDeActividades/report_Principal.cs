using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for report_Principal
/// </summary>
public class report_Principal : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private PageHeaderBand PageHeader;
    private XRLine xrLine4;
    public XRLabel xrLabel53;
    public XRLabel xrLabel52;
    public XRLabel xrLabel51;
    public XRLabel xrLabel50;
    public XRLabel xrLabel49;
    public XRLabel xrLabel48;
    public XRLabel xrLabel47;
    public XRLabel xrLabel46;
    public XRLabel xrLabel45;
    private XRLine xrLine3;
    public XRLabel xrLabel43;
    public GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    private XRLabel xrLabel7;
    public XRLabel Gpo_Ruta;
    public GroupHeaderBand GroupHeader3;
    private XRLabel xrLabel5;
    public XRLabel Gpo_Vendedor;
    public GroupHeaderBand GroupHeader4;
    private XRLabel xrLabel3;
    public XRLabel Gpo_CEDI;
    public GroupHeaderBand GroupHeader5;
    private XRLabel xrLabel1;
    public XRLabel Gpo_Fecha;
    private XRLabel xrLabel9;
    public XRLabel Gpo_JornadaInicio;
    public XRLabel L_Venta;
    public XRLabel L_TotalVta;
    public XRLabel L_Secuencia;
    public XRLabel L_Cliente;
    public XRLabel L_VisitaInicio;
    public XRLabel L_VisitaFin;
    public XRLabel L_FueraFrecuencia;
    public XRLabel L_Improductividad;
    public XRLabel L_NoLeido;
    public XRLabel L_NumCliente;
    private GroupFooterBand GroupFooter1;
    public XRLabel L_JornadaFin;
    private XRLabel xrLabel11;
    public XRSubreport Sub1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel71;
    private XRLabel xrLabel73;
    private XRLabel xrLabel74;
    private XRLabel xrLabel19;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    public XRLabel L_Visitados;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel55;
    private XRLabel xrLabel56;
    public XRLabel L_VisitaConVenta;
    public XRLabel L_TotalNoLeidos;
    private XRLabel xrLabel59;
    private XRLabel xrLabel60;
    private XRLabel xrLabel61;
    public XRLabel L_TotalClientes;
    public XRLabel L_NoVisitados;
    public XRLabel L_Porc_Eficiencia;
    public XRLabel L_VisitaSinVenta;
    public XRLabel L_Porc_Efectividad;
    public XRLabel L_FueraFrec;
    public XRLabel L_FueraFrecVenta;
    public XRLabel L_Porc_EfecFF;
    public XRLabel L_PromedioTransito;
    public XRLabel L_PromedioVisita;
    public XRLabel L_TiempoTransito;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel18;
    private XRLabel xrLabel30;
    public XRLabel L_TiempoRecorrido;
    public XRLabel L_Meta;
    public XRLabel L_Acumulado;
    public XRLabel L_DifMeta;
    public XRLabel L_Cuota;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel36;
    private XRPageInfo xrPageInfo2;
    public GroupHeaderBand GroupHeader6;
    private ReportHeaderBand ReportHeader;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel xrLabel69;
    public XRLabel xrLabel70;
    public XRLabel centro;
    public XRLabel fecha;
    public XRLabel empresa;
    private XRLabel nameFiltro;
    public XRLabel filtro;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public report_Principal()
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.L_Venta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalVta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Secuencia = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Cliente = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VisitaInicio = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VisitaFin = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FueraFrecuencia = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Improductividad = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NoLeido = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NumCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Gpo_JornadaInicio = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Gpo_Ruta = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Gpo_Vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Gpo_CEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Gpo_Fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.L_Meta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Acumulado = new DevExpress.XtraReports.UI.XRLabel();
            this.L_DifMeta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Cuota = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel71 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel73 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Visitados = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VisitaConVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalNoLeidos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TotalClientes = new DevExpress.XtraReports.UI.XRLabel();
            this.L_NoVisitados = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Porc_Eficiencia = new DevExpress.XtraReports.UI.XRLabel();
            this.L_VisitaSinVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Porc_Efectividad = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FueraFrec = new DevExpress.XtraReports.UI.XRLabel();
            this.L_FueraFrecVenta = new DevExpress.XtraReports.UI.XRLabel();
            this.L_Porc_EfecFF = new DevExpress.XtraReports.UI.XRLabel();
            this.L_PromedioTransito = new DevExpress.XtraReports.UI.XRLabel();
            this.L_PromedioVisita = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TiempoTransito = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.L_TiempoRecorrido = new DevExpress.XtraReports.UI.XRLabel();
            this.Sub1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.L_JornadaFin = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader6 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel70 = new DevExpress.XtraReports.UI.XRLabel();
            this.centro = new DevExpress.XtraReports.UI.XRLabel();
            this.fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.nameFiltro = new DevExpress.XtraReports.UI.XRLabel();
            this.filtro = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_Venta,
            this.L_TotalVta,
            this.L_Secuencia,
            this.L_Cliente,
            this.L_VisitaInicio,
            this.L_VisitaFin,
            this.L_FueraFrecuencia,
            this.L_Improductividad,
            this.L_NoLeido,
            this.L_NumCliente});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 16.66667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // L_Venta
            // 
            this.L_Venta.Dpi = 100F;
            this.L_Venta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Venta.LocationFloat = new DevExpress.Utils.PointFloat(726.4382F, 0F);
            this.L_Venta.Name = "L_Venta";
            this.L_Venta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Venta.SizeF = new System.Drawing.SizeF(59.11426F, 14.5F);
            this.L_Venta.StylePriority.UseFont = false;
            this.L_Venta.StylePriority.UseTextAlignment = false;
            this.L_Venta.Text = "Venta";
            this.L_Venta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_TotalVta
            // 
            this.L_TotalVta.Dpi = 100F;
            this.L_TotalVta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalVta.LocationFloat = new DevExpress.Utils.PointFloat(943.3362F, 0F);
            this.L_TotalVta.Name = "L_TotalVta";
            this.L_TotalVta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalVta.SizeF = new System.Drawing.SizeF(77.19196F, 14.5F);
            this.L_TotalVta.StylePriority.UseFont = false;
            this.L_TotalVta.StylePriority.UseTextAlignment = false;
            this.L_TotalVta.Text = "VtaTotal";
            this.L_TotalVta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Secuencia
            // 
            this.L_Secuencia.Dpi = 100F;
            this.L_Secuencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Secuencia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.L_Secuencia.Name = "L_Secuencia";
            this.L_Secuencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Secuencia.SizeF = new System.Drawing.SizeF(61.67797F, 14.5F);
            this.L_Secuencia.StylePriority.UseFont = false;
            this.L_Secuencia.StylePriority.UseTextAlignment = false;
            this.L_Secuencia.Text = "secuencia";
            this.L_Secuencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Cliente
            // 
            this.L_Cliente.Dpi = 100F;
            this.L_Cliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Cliente.LocationFloat = new DevExpress.Utils.PointFloat(172.8871F, 0F);
            this.L_Cliente.Name = "L_Cliente";
            this.L_Cliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Cliente.SizeF = new System.Drawing.SizeF(282.7871F, 14.5F);
            this.L_Cliente.StylePriority.UseFont = false;
            this.L_Cliente.StylePriority.UseTextAlignment = false;
            this.L_Cliente.Text = "Cliente";
            this.L_Cliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_VisitaInicio
            // 
            this.L_VisitaInicio.CanGrow = false;
            this.L_VisitaInicio.Dpi = 100F;
            this.L_VisitaInicio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VisitaInicio.LocationFloat = new DevExpress.Utils.PointFloat(602.4462F, 0F);
            this.L_VisitaInicio.Name = "L_VisitaInicio";
            this.L_VisitaInicio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VisitaInicio.SizeF = new System.Drawing.SizeF(54.77258F, 14.5F);
            this.L_VisitaInicio.StylePriority.UseFont = false;
            this.L_VisitaInicio.StylePriority.UseTextAlignment = false;
            this.L_VisitaInicio.Text = "Inicio";
            this.L_VisitaInicio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_VisitaFin
            // 
            this.L_VisitaFin.CanGrow = false;
            this.L_VisitaFin.Dpi = 100F;
            this.L_VisitaFin.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VisitaFin.LocationFloat = new DevExpress.Utils.PointFloat(657.2188F, 0F);
            this.L_VisitaFin.Name = "L_VisitaFin";
            this.L_VisitaFin.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VisitaFin.SizeF = new System.Drawing.SizeF(69.21924F, 14.5F);
            this.L_VisitaFin.StylePriority.UseFont = false;
            this.L_VisitaFin.StylePriority.UseTextAlignment = false;
            this.L_VisitaFin.Text = "Fin";
            this.L_VisitaFin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_FueraFrecuencia
            // 
            this.L_FueraFrecuencia.Dpi = 100F;
            this.L_FueraFrecuencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FueraFrecuencia.LocationFloat = new DevExpress.Utils.PointFloat(455.8438F, 0F);
            this.L_FueraFrecuencia.Name = "L_FueraFrecuencia";
            this.L_FueraFrecuencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_FueraFrecuencia.SizeF = new System.Drawing.SizeF(71.90234F, 14.5F);
            this.L_FueraFrecuencia.StylePriority.UseFont = false;
            this.L_FueraFrecuencia.StylePriority.UseTextAlignment = false;
            this.L_FueraFrecuencia.Text = "FueraF";
            this.L_FueraFrecuencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_Improductividad
            // 
            this.L_Improductividad.Dpi = 100F;
            this.L_Improductividad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Improductividad.LocationFloat = new DevExpress.Utils.PointFloat(785.8649F, 0F);
            this.L_Improductividad.Name = "L_Improductividad";
            this.L_Improductividad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Improductividad.SizeF = new System.Drawing.SizeF(157.4288F, 14.5F);
            this.L_Improductividad.StylePriority.UseFont = false;
            this.L_Improductividad.StylePriority.UseTextAlignment = false;
            this.L_Improductividad.Text = "improductividad";
            this.L_Improductividad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_NoLeido
            // 
            this.L_NoLeido.Dpi = 100F;
            this.L_NoLeido.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_NoLeido.LocationFloat = new DevExpress.Utils.PointFloat(528.4014F, 0F);
            this.L_NoLeido.Name = "L_NoLeido";
            this.L_NoLeido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_NoLeido.SizeF = new System.Drawing.SizeF(74.04474F, 14.5F);
            this.L_NoLeido.StylePriority.UseFont = false;
            this.L_NoLeido.StylePriority.UseTextAlignment = false;
            this.L_NoLeido.Text = "NoLeido";
            this.L_NoLeido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // L_NumCliente
            // 
            this.L_NumCliente.Dpi = 100F;
            this.L_NumCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_NumCliente.LocationFloat = new DevExpress.Utils.PointFloat(61.67797F, 0F);
            this.L_NumCliente.Name = "L_NumCliente";
            this.L_NumCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_NumCliente.SizeF = new System.Drawing.SizeF(111.1667F, 14.5F);
            this.L_NumCliente.StylePriority.UseFont = false;
            this.L_NumCliente.StylePriority.UseTextAlignment = false;
            this.L_NumCliente.Text = "NmeroCliente";
            this.L_NumCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine4,
            this.xrLabel53,
            this.xrLabel52,
            this.xrLabel51,
            this.xrLabel50,
            this.xrLabel49,
            this.xrLabel48,
            this.xrLabel47,
            this.xrLabel46,
            this.xrLabel45,
            this.xrLine3,
            this.xrLabel43});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 43.82436F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 37.9122F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1020.372F, 5.912161F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Dpi = 100F;
            this.xrLabel53.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(943.1378F, 5.912201F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(77.23F, 32F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UsePadding = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "Venta Total";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Dpi = 100F;
            this.xrLabel52.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(528.4437F, 5.912201F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(73.96F, 32F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UsePadding = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "Código No Leido";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Dpi = 100F;
            this.xrLabel51.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(785.5524F, 5.912201F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(157.585F, 32F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UsePadding = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "Motivo Improductividad";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel50
            // 
            this.xrLabel50.Dpi = 100F;
            this.xrLabel50.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(726.3959F, 5.912201F);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel50.SizeF = new System.Drawing.SizeF(59.15668F, 32F);
            this.xrLabel50.StylePriority.UseFont = false;
            this.xrLabel50.StylePriority.UsePadding = false;
            this.xrLabel50.StylePriority.UseTextAlignment = false;
            this.xrLabel50.Text = "Venta";
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel49
            // 
            this.xrLabel49.Dpi = 100F;
            this.xrLabel49.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(172.8447F, 5.912201F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(282.8719F, 32F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UsePadding = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "Cliente";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel48
            // 
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(657.2189F, 5.912201F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(69.17682F, 32F);
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.StylePriority.UsePadding = false;
            this.xrLabel48.StylePriority.UseTextAlignment = false;
            this.xrLabel48.Text = "Hora Final";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel47
            // 
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(602.4039F, 5.912201F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(54.815F, 32F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.StylePriority.UsePadding = false;
            this.xrLabel47.StylePriority.UseTextAlignment = false;
            this.xrLabel47.Text = "Hora Inicial";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(455.8437F, 5.912201F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(71.86F, 32F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.StylePriority.UsePadding = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "Fuera de Frecuencia";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel45
            // 
            this.xrLabel45.CanGrow = false;
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(61.63551F, 5.912201F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(111.2091F, 32F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.StylePriority.UsePadding = false;
            this.xrLabel45.StylePriority.UseTextAlignment = false;
            this.xrLabel45.Text = "Numero de Cliente";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(1020.372F, 5.912161F);
            this.xrLine3.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.912201F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(61.72034F, 32F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UsePadding = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "Secuencia";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.Gpo_JornadaInicio});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 16.5F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(36.51201F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(113.7403F, 14.54873F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Inicio de Recorrido";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Gpo_JornadaInicio
            // 
            this.Gpo_JornadaInicio.Dpi = 100F;
            this.Gpo_JornadaInicio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpo_JornadaInicio.LocationFloat = new DevExpress.Utils.PointFloat(602.9053F, 0F);
            this.Gpo_JornadaInicio.Name = "Gpo_JornadaInicio";
            this.Gpo_JornadaInicio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Gpo_JornadaInicio.SizeF = new System.Drawing.SizeF(54.39832F, 14.55F);
            this.Gpo_JornadaInicio.StylePriority.UseFont = false;
            this.Gpo_JornadaInicio.StylePriority.UseTextAlignment = false;
            this.Gpo_JornadaInicio.Text = "Fecha";
            this.Gpo_JornadaInicio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.Gpo_Ruta});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 16.5F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(36.09534F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(87.69865F, 14.54873F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Ruta";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Gpo_Ruta
            // 
            this.Gpo_Ruta.Dpi = 100F;
            this.Gpo_Ruta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpo_Ruta.LocationFloat = new DevExpress.Utils.PointFloat(157.2069F, 0F);
            this.Gpo_Ruta.Name = "Gpo_Ruta";
            this.Gpo_Ruta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Gpo_Ruta.SizeF = new System.Drawing.SizeF(275.68F, 14.55F);
            this.Gpo_Ruta.StylePriority.UseFont = false;
            this.Gpo_Ruta.StylePriority.UseTextAlignment = false;
            this.Gpo_Ruta.Text = "Ruta";
            this.Gpo_Ruta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.Gpo_Vendedor});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 16.5F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(23.13987F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(87.69865F, 14.54873F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Vendedor";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Gpo_Vendedor
            // 
            this.Gpo_Vendedor.Dpi = 100F;
            this.Gpo_Vendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpo_Vendedor.LocationFloat = new DevExpress.Utils.PointFloat(157.2069F, 0F);
            this.Gpo_Vendedor.Name = "Gpo_Vendedor";
            this.Gpo_Vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Gpo_Vendedor.SizeF = new System.Drawing.SizeF(275.68F, 14.55F);
            this.Gpo_Vendedor.StylePriority.UseFont = false;
            this.Gpo_Vendedor.StylePriority.UseTextAlignment = false;
            this.Gpo_Vendedor.Text = "Vendedor";
            this.Gpo_Vendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.Gpo_CEDI});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 16.5F;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(10.83333F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(139.419F, 14.54873F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Centro de Distribución";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Gpo_CEDI
            // 
            this.Gpo_CEDI.Dpi = 100F;
            this.Gpo_CEDI.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpo_CEDI.LocationFloat = new DevExpress.Utils.PointFloat(157.2069F, 0F);
            this.Gpo_CEDI.Name = "Gpo_CEDI";
            this.Gpo_CEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Gpo_CEDI.SizeF = new System.Drawing.SizeF(275.68F, 14.55F);
            this.Gpo_CEDI.StylePriority.UseFont = false;
            this.Gpo_CEDI.StylePriority.UseTextAlignment = false;
            this.Gpo_CEDI.Text = "CEDI";
            this.Gpo_CEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.Gpo_Fecha});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 16.5F;
            this.GroupHeader5.Level = 4;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.08474191F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(87.69865F, 14.54873F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Fecha";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Gpo_Fecha
            // 
            this.Gpo_Fecha.Dpi = 100F;
            this.Gpo_Fecha.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpo_Fecha.LocationFloat = new DevExpress.Utils.PointFloat(157.2069F, 0F);
            this.Gpo_Fecha.Name = "Gpo_Fecha";
            this.Gpo_Fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Gpo_Fecha.SizeF = new System.Drawing.SizeF(275.68F, 14.55F);
            this.Gpo_Fecha.StylePriority.UseFont = false;
            this.Gpo_Fecha.StylePriority.UseTextAlignment = false;
            this.Gpo_Fecha.Text = "Fecha";
            this.Gpo_Fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.L_Meta,
            this.L_Acumulado,
            this.L_DifMeta,
            this.L_Cuota,
            this.xrLabel14,
            this.xrLabel71,
            this.xrLabel73,
            this.xrLabel74,
            this.xrLabel19,
            this.xrLabel21,
            this.xrLabel22,
            this.xrLabel23,
            this.L_Visitados,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel55,
            this.xrLabel56,
            this.L_VisitaConVenta,
            this.L_TotalNoLeidos,
            this.xrLabel59,
            this.xrLabel60,
            this.xrLabel61,
            this.L_TotalClientes,
            this.L_NoVisitados,
            this.L_Porc_Eficiencia,
            this.L_VisitaSinVenta,
            this.L_Porc_Efectividad,
            this.L_FueraFrec,
            this.L_FueraFrecVenta,
            this.L_Porc_EfecFF,
            this.L_PromedioTransito,
            this.L_PromedioVisita,
            this.L_TiempoTransito,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel18,
            this.xrLabel30,
            this.L_TiempoRecorrido,
            this.Sub1,
            this.L_JornadaFin,
            this.xrLabel11});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 191.6666F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // L_Meta
            // 
            this.L_Meta.Dpi = 100F;
            this.L_Meta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Meta.LocationFloat = new DevExpress.Utils.PointFloat(972.9878F, 100.1666F);
            this.L_Meta.Name = "L_Meta";
            this.L_Meta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Meta.SizeF = new System.Drawing.SizeF(47.01221F, 14.5F);
            this.L_Meta.StylePriority.UseFont = false;
            this.L_Meta.StylePriority.UseTextAlignment = false;
            this.L_Meta.Text = "Total";
            this.L_Meta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Acumulado
            // 
            this.L_Acumulado.Dpi = 100F;
            this.L_Acumulado.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Acumulado.LocationFloat = new DevExpress.Utils.PointFloat(972.7653F, 114.6667F);
            this.L_Acumulado.Name = "L_Acumulado";
            this.L_Acumulado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Acumulado.SizeF = new System.Drawing.SizeF(47.23474F, 14.5F);
            this.L_Acumulado.StylePriority.UseFont = false;
            this.L_Acumulado.StylePriority.UseTextAlignment = false;
            this.L_Acumulado.Text = "valor";
            this.L_Acumulado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_DifMeta
            // 
            this.L_DifMeta.Dpi = 100F;
            this.L_DifMeta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DifMeta.LocationFloat = new DevExpress.Utils.PointFloat(972.7653F, 129.1666F);
            this.L_DifMeta.Name = "L_DifMeta";
            this.L_DifMeta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_DifMeta.SizeF = new System.Drawing.SizeF(47.23474F, 14.5F);
            this.L_DifMeta.StylePriority.UseFont = false;
            this.L_DifMeta.StylePriority.UseTextAlignment = false;
            this.L_DifMeta.Text = "valor";
            this.L_DifMeta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Cuota
            // 
            this.L_Cuota.Dpi = 100F;
            this.L_Cuota.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Cuota.LocationFloat = new DevExpress.Utils.PointFloat(972.7653F, 143.6667F);
            this.L_Cuota.Name = "L_Cuota";
            this.L_Cuota.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Cuota.SizeF = new System.Drawing.SizeF(47.23474F, 14.5F);
            this.L_Cuota.StylePriority.UseFont = false;
            this.L_Cuota.StylePriority.UseTextAlignment = false;
            this.L_Cuota.Text = "valor";
            this.L_Cuota.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(867.3288F, 100.1666F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(94.15F, 14.5F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "Meta";
            // 
            // xrLabel71
            // 
            this.xrLabel71.Dpi = 100F;
            this.xrLabel71.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel71.LocationFloat = new DevExpress.Utils.PointFloat(867.3288F, 114.6667F);
            this.xrLabel71.Name = "xrLabel71";
            this.xrLabel71.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel71.SizeF = new System.Drawing.SizeF(94.15F, 14.5F);
            this.xrLabel71.StylePriority.UseFont = false;
            this.xrLabel71.Text = "Acumulado";
            // 
            // xrLabel73
            // 
            this.xrLabel73.Dpi = 100F;
            this.xrLabel73.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel73.LocationFloat = new DevExpress.Utils.PointFloat(867.3288F, 129.1666F);
            this.xrLabel73.Name = "xrLabel73";
            this.xrLabel73.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel73.SizeF = new System.Drawing.SizeF(94.15F, 14.5F);
            this.xrLabel73.StylePriority.UseFont = false;
            this.xrLabel73.Text = "Dif. Meta";
            // 
            // xrLabel74
            // 
            this.xrLabel74.Dpi = 100F;
            this.xrLabel74.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(867.3288F, 143.6667F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(94.15F, 14.5F);
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.Text = "Cuota";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(0.9180784F, 100.1666F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(94.1519F, 14.5F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Total Clientes";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(0.9180784F, 114.6667F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(94.1519F, 14.5F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "Visitados";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0.9180784F, 129.1667F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(94.1519F, 14.5F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.Text = "No Visitados";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0.9180784F, 143.6667F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(94.1519F, 14.5F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "% Eficiencia";
            // 
            // L_Visitados
            // 
            this.L_Visitados.Dpi = 100F;
            this.L_Visitados.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Visitados.LocationFloat = new DevExpress.Utils.PointFloat(102.8446F, 114.6667F);
            this.L_Visitados.Name = "L_Visitados";
            this.L_Visitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Visitados.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_Visitados.StylePriority.UseFont = false;
            this.L_Visitados.StylePriority.UseTextAlignment = false;
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            this.L_Visitados.Summary = xrSummary1;
            this.L_Visitados.Text = "Total";
            this.L_Visitados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(185.7681F, 100.1666F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(136.4019F, 14.5F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.Text = "Visitados con Venta";
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(185.7681F, 114.6667F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(136.4019F, 14.5F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.Text = "Visitados sin Venta";
            // 
            // xrLabel55
            // 
            this.xrLabel55.Dpi = 100F;
            this.xrLabel55.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(186.0181F, 129.1667F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(136.1519F, 14.5F);
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.Text = "Total Códigos No Leidos";
            // 
            // xrLabel56
            // 
            this.xrLabel56.Dpi = 100F;
            this.xrLabel56.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(185.7681F, 143.6667F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(136.1519F, 14.5F);
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.Text = "% Efectividad";
            // 
            // L_VisitaConVenta
            // 
            this.L_VisitaConVenta.Dpi = 100F;
            this.L_VisitaConVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VisitaConVenta.LocationFloat = new DevExpress.Utils.PointFloat(333.2554F, 100.1666F);
            this.L_VisitaConVenta.Name = "L_VisitaConVenta";
            this.L_VisitaConVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VisitaConVenta.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_VisitaConVenta.StylePriority.UseFont = false;
            this.L_VisitaConVenta.StylePriority.UseTextAlignment = false;
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary2.IgnoreNullValues = true;
            this.L_VisitaConVenta.Summary = xrSummary2;
            this.L_VisitaConVenta.Text = "Total";
            this.L_VisitaConVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_TotalNoLeidos
            // 
            this.L_TotalNoLeidos.Dpi = 100F;
            this.L_TotalNoLeidos.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalNoLeidos.LocationFloat = new DevExpress.Utils.PointFloat(333.2554F, 129.1667F);
            this.L_TotalNoLeidos.Name = "L_TotalNoLeidos";
            this.L_TotalNoLeidos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalNoLeidos.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_TotalNoLeidos.StylePriority.UseFont = false;
            this.L_TotalNoLeidos.StylePriority.UseTextAlignment = false;
            xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary3.IgnoreNullValues = true;
            this.L_TotalNoLeidos.Summary = xrSummary3;
            this.L_TotalNoLeidos.Text = "Total";
            this.L_TotalNoLeidos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel59
            // 
            this.xrLabel59.Dpi = 100F;
            this.xrLabel59.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(428.3514F, 100.1666F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(127.9019F, 14.5F);
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.Text = "Fuera de Frecuencia";
            // 
            // xrLabel60
            // 
            this.xrLabel60.Dpi = 100F;
            this.xrLabel60.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel60.LocationFloat = new DevExpress.Utils.PointFloat(428.3514F, 114.6667F);
            this.xrLabel60.Name = "xrLabel60";
            this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel60.SizeF = new System.Drawing.SizeF(127.9019F, 14.5F);
            this.xrLabel60.StylePriority.UseFont = false;
            this.xrLabel60.Text = "Fuera Frec. Venta";
            // 
            // xrLabel61
            // 
            this.xrLabel61.Dpi = 100F;
            this.xrLabel61.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel61.LocationFloat = new DevExpress.Utils.PointFloat(428.3514F, 129.1667F);
            this.xrLabel61.Name = "xrLabel61";
            this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel61.SizeF = new System.Drawing.SizeF(127.9019F, 14.5F);
            this.xrLabel61.StylePriority.UseFont = false;
            this.xrLabel61.Text = "% Efect. Fuera Frec.";
            // 
            // L_TotalClientes
            // 
            this.L_TotalClientes.Dpi = 100F;
            this.L_TotalClientes.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TotalClientes.LocationFloat = new DevExpress.Utils.PointFloat(102.8446F, 100.1666F);
            this.L_TotalClientes.Name = "L_TotalClientes";
            this.L_TotalClientes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TotalClientes.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_TotalClientes.StylePriority.UseFont = false;
            this.L_TotalClientes.StylePriority.UseTextAlignment = false;
            this.L_TotalClientes.Text = "Total";
            this.L_TotalClientes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_NoVisitados
            // 
            this.L_NoVisitados.Dpi = 100F;
            this.L_NoVisitados.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_NoVisitados.LocationFloat = new DevExpress.Utils.PointFloat(102.8446F, 129.1667F);
            this.L_NoVisitados.Name = "L_NoVisitados";
            this.L_NoVisitados.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_NoVisitados.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_NoVisitados.StylePriority.UseFont = false;
            this.L_NoVisitados.StylePriority.UseTextAlignment = false;
            this.L_NoVisitados.Text = "Total";
            this.L_NoVisitados.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Porc_Eficiencia
            // 
            this.L_Porc_Eficiencia.Dpi = 100F;
            this.L_Porc_Eficiencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Porc_Eficiencia.LocationFloat = new DevExpress.Utils.PointFloat(102.8446F, 143.6667F);
            this.L_Porc_Eficiencia.Name = "L_Porc_Eficiencia";
            this.L_Porc_Eficiencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Porc_Eficiencia.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_Porc_Eficiencia.StylePriority.UseFont = false;
            this.L_Porc_Eficiencia.StylePriority.UseTextAlignment = false;
            this.L_Porc_Eficiencia.Text = "Total";
            this.L_Porc_Eficiencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_VisitaSinVenta
            // 
            this.L_VisitaSinVenta.Dpi = 100F;
            this.L_VisitaSinVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VisitaSinVenta.LocationFloat = new DevExpress.Utils.PointFloat(333.2554F, 114.6667F);
            this.L_VisitaSinVenta.Name = "L_VisitaSinVenta";
            this.L_VisitaSinVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_VisitaSinVenta.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_VisitaSinVenta.StylePriority.UseFont = false;
            this.L_VisitaSinVenta.StylePriority.UseTextAlignment = false;
            this.L_VisitaSinVenta.Text = "Total";
            this.L_VisitaSinVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Porc_Efectividad
            // 
            this.L_Porc_Efectividad.Dpi = 100F;
            this.L_Porc_Efectividad.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Porc_Efectividad.LocationFloat = new DevExpress.Utils.PointFloat(333.2554F, 143.6667F);
            this.L_Porc_Efectividad.Name = "L_Porc_Efectividad";
            this.L_Porc_Efectividad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Porc_Efectividad.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_Porc_Efectividad.StylePriority.UseFont = false;
            this.L_Porc_Efectividad.StylePriority.UseTextAlignment = false;
            this.L_Porc_Efectividad.Text = "Total";
            this.L_Porc_Efectividad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_FueraFrec
            // 
            this.L_FueraFrec.Dpi = 100F;
            this.L_FueraFrec.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FueraFrec.LocationFloat = new DevExpress.Utils.PointFloat(566.6278F, 100.1666F);
            this.L_FueraFrec.Name = "L_FueraFrec";
            this.L_FueraFrec.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_FueraFrec.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_FueraFrec.StylePriority.UseFont = false;
            this.L_FueraFrec.StylePriority.UseTextAlignment = false;
            this.L_FueraFrec.Text = "Total";
            this.L_FueraFrec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_FueraFrecVenta
            // 
            this.L_FueraFrecVenta.Dpi = 100F;
            this.L_FueraFrecVenta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FueraFrecVenta.LocationFloat = new DevExpress.Utils.PointFloat(566.6278F, 114.6667F);
            this.L_FueraFrecVenta.Name = "L_FueraFrecVenta";
            this.L_FueraFrecVenta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_FueraFrecVenta.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_FueraFrecVenta.StylePriority.UseFont = false;
            this.L_FueraFrecVenta.StylePriority.UseTextAlignment = false;
            this.L_FueraFrecVenta.Text = "Total";
            this.L_FueraFrecVenta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_Porc_EfecFF
            // 
            this.L_Porc_EfecFF.Dpi = 100F;
            this.L_Porc_EfecFF.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Porc_EfecFF.LocationFloat = new DevExpress.Utils.PointFloat(566.6278F, 129.1667F);
            this.L_Porc_EfecFF.Name = "L_Porc_EfecFF";
            this.L_Porc_EfecFF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_Porc_EfecFF.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_Porc_EfecFF.StylePriority.UseFont = false;
            this.L_Porc_EfecFF.StylePriority.UseTextAlignment = false;
            this.L_Porc_EfecFF.Text = "Total";
            this.L_Porc_EfecFF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_PromedioTransito
            // 
            this.L_PromedioTransito.Dpi = 100F;
            this.L_PromedioTransito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_PromedioTransito.LocationFloat = new DevExpress.Utils.PointFloat(785.4146F, 143.6667F);
            this.L_PromedioTransito.Name = "L_PromedioTransito";
            this.L_PromedioTransito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_PromedioTransito.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_PromedioTransito.StylePriority.UseFont = false;
            this.L_PromedioTransito.StylePriority.UseTextAlignment = false;
            this.L_PromedioTransito.Text = "valor";
            this.L_PromedioTransito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_PromedioVisita
            // 
            this.L_PromedioVisita.Dpi = 100F;
            this.L_PromedioVisita.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_PromedioVisita.LocationFloat = new DevExpress.Utils.PointFloat(785.4146F, 129.1666F);
            this.L_PromedioVisita.Name = "L_PromedioVisita";
            this.L_PromedioVisita.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_PromedioVisita.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_PromedioVisita.StylePriority.UseFont = false;
            this.L_PromedioVisita.StylePriority.UseTextAlignment = false;
            this.L_PromedioVisita.Text = "valor";
            this.L_PromedioVisita.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // L_TiempoTransito
            // 
            this.L_TiempoTransito.Dpi = 100F;
            this.L_TiempoTransito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TiempoTransito.LocationFloat = new DevExpress.Utils.PointFloat(785.4146F, 114.6667F);
            this.L_TiempoTransito.Name = "L_TiempoTransito";
            this.L_TiempoTransito.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TiempoTransito.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_TiempoTransito.StylePriority.UseFont = false;
            this.L_TiempoTransito.StylePriority.UseTextAlignment = false;
            this.L_TiempoTransito.Text = "valor";
            this.L_TiempoTransito.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(657.3035F, 143.6667F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(115.6167F, 14.5F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Promedio Tránsito";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(657.502F, 129.1666F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(115.6167F, 14.5F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Promedio Visita";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(657.3035F, 114.6667F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(115.6167F, 14.5F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Tiempo Tránsito";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(657.3035F, 100.1666F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(115.6167F, 14.5F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "Tiempo Recorrido";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // L_TiempoRecorrido
            // 
            this.L_TiempoRecorrido.Dpi = 100F;
            this.L_TiempoRecorrido.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TiempoRecorrido.LocationFloat = new DevExpress.Utils.PointFloat(785.6371F, 100.1666F);
            this.L_TiempoRecorrido.Name = "L_TiempoRecorrido";
            this.L_TiempoRecorrido.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_TiempoRecorrido.SizeF = new System.Drawing.SizeF(70F, 14.5F);
            this.L_TiempoRecorrido.StylePriority.UseFont = false;
            this.L_TiempoRecorrido.StylePriority.UseTextAlignment = false;
            this.L_TiempoRecorrido.Text = "Total";
            this.L_TiempoRecorrido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Sub1
            // 
            this.Sub1.Dpi = 100F;
            this.Sub1.LocationFloat = new DevExpress.Utils.PointFloat(1.00282F, 31.20832F);
            this.Sub1.Name = "Sub1";
            this.Sub1.SizeF = new System.Drawing.SizeF(220.8333F, 41.75F);
            // 
            // L_JornadaFin
            // 
            this.L_JornadaFin.Dpi = 100F;
            this.L_JornadaFin.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_JornadaFin.LocationFloat = new DevExpress.Utils.PointFloat(657.3035F, 0F);
            this.L_JornadaFin.Name = "L_JornadaFin";
            this.L_JornadaFin.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.L_JornadaFin.SizeF = new System.Drawing.SizeF(69.55127F, 14.5F);
            this.L_JornadaFin.StylePriority.UseFont = false;
            this.L_JornadaFin.StylePriority.UseTextAlignment = false;
            this.L_JornadaFin.Text = "Fecha";
            this.L_JornadaFin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(36.51201F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(118.1519F, 14.5F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Fin de Recorrido";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrLabel36,
            this.xrPageInfo2});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 18.86488F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "{0:dd/MM/yyyy hh:mm:ss tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(900.7427F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(123.8109F, 12.58333F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(740.0233F, 0F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(149.9999F, 12.58333F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UsePadding = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "Fecha Hora Impresión";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "{0} / {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(214.7886F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(312.9999F, 12.58333F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UsePadding = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupHeader6
            // 
            this.GroupHeader6.Dpi = 100F;
            this.GroupHeader6.HeightF = 16.5F;
            this.GroupHeader6.Level = 5;
            this.GroupHeader6.Name = "GroupHeader6";
            this.GroupHeader6.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.nameFiltro,
            this.filtro,
            this.logo,
            this.reporte,
            this.xrLabel69,
            this.xrLabel70,
            this.centro,
            this.fecha,
            this.empresa});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 160F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(50F, 15F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(140F, 80F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(300F, 55F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel69
            // 
            this.xrLabel69.Dpi = 100F;
            this.xrLabel69.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.StylePriority.UseTextAlignment = false;
            this.xrLabel69.Text = "Centro De Distribución:";
            this.xrLabel69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel70
            // 
            this.xrLabel70.Dpi = 100F;
            this.xrLabel70.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel70.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115F);
            this.xrLabel70.Name = "xrLabel70";
            this.xrLabel70.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel70.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.xrLabel70.StylePriority.UseFont = false;
            this.xrLabel70.StylePriority.UseTextAlignment = false;
            this.xrLabel70.Text = "Fecha:";
            this.xrLabel70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // centro
            // 
            this.centro.Dpi = 100F;
            this.centro.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.centro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 100F);
            this.centro.Name = "centro";
            this.centro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.centro.SizeF = new System.Drawing.SizeF(940F, 15F);
            this.centro.StylePriority.UseFont = false;
            this.centro.StylePriority.UseTextAlignment = false;
            this.centro.Text = "centro";
            this.centro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fecha
            // 
            this.fecha.Dpi = 100F;
            this.fecha.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.fecha.LocationFloat = new DevExpress.Utils.PointFloat(150F, 115F);
            this.fecha.Name = "fecha";
            this.fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fecha.SizeF = new System.Drawing.SizeF(940F, 15F);
            this.fecha.StylePriority.UseFont = false;
            this.fecha.StylePriority.UseTextAlignment = false;
            this.fecha.Text = "fecha";
            this.fecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(300F, 15F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(490F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // nameFiltro
            // 
            this.nameFiltro.Dpi = 100F;
            this.nameFiltro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.nameFiltro.LocationFloat = new DevExpress.Utils.PointFloat(0F, 130F);
            this.nameFiltro.Name = "nameFiltro";
            this.nameFiltro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nameFiltro.SizeF = new System.Drawing.SizeF(150F, 15F);
            this.nameFiltro.StylePriority.UseFont = false;
            this.nameFiltro.StylePriority.UseTextAlignment = false;
            this.nameFiltro.Text = "nameFiltro";
            this.nameFiltro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // filtro
            // 
            this.filtro.Dpi = 100F;
            this.filtro.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.filtro.LocationFloat = new DevExpress.Utils.PointFloat(150F, 130F);
            this.filtro.Name = "filtro";
            this.filtro.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.filtro.SizeF = new System.Drawing.SizeF(940F, 15F);
            this.filtro.StylePriority.UseFont = false;
            this.filtro.StylePriority.UseTextAlignment = false;
            this.filtro.Text = "filtro";
            this.filtro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // report_Principal
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.GroupHeader5,
            this.GroupFooter1,
            this.PageFooter,
            this.GroupHeader6,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
