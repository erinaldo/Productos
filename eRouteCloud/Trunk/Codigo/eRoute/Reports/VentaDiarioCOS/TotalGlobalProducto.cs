using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TotalGlobalProducto
/// </summary>
public class TotalGlobalProducto : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.XtraReports.Parameters.Parameter RutID;
    private XRLabel xrLabel4;
    private CalculatedField Cobertura;
    private CalculatedField CoberturaFueraRuta;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel103;
    private string QueryString = "";

    public TotalGlobalProducto()
    {
        //Consulta
        StringBuilder sConsulta = new StringBuilder();
        sConsulta.AppendLine("Select RUTClave, ProductoClave, PRONombre, VAD.Descripcion as Unidad, Avg(Precio) as Precio, ");
        sConsulta.AppendLine("sum(TotalClientesEnRuta) As TotalClientesEnRuta, sum(ClientesVentaEnRuta) As ClientesVentaEnRuta, sum(PiezasEnRuta) as PiezasEnRuta, sum(TotalEnRuta) as TotalEnRuta, ");
        sConsulta.AppendLine("sum(TotalClienteFueraRuta) as TotalClienteFueraRuta, sum(ClientesVentaFueraRuta) As ClientesVentaFueraRuta, sum(PiezasFueraRuta) as PiezasFueraRuta, sum(TotalFueraRuta) as TotalFueraRuta ");
        sConsulta.AppendLine("FROM( Select ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre,EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre, TipoUnidad, Precio, ");
        sConsulta.AppendLine("(select count(distinct ClienteClave) FROM agendavendedor AV where AV.clavecedi = T.ALMClave and AV.VendedorId = T.VendedorId and AV.diaclave = T.DiaClave and AV.rutClave = RUTClave) As TotalClientesEnRuta, ");
        sConsulta.AppendLine("count(distinct ClienteClave) As ClientesVentaEnRuta,sum(Cantidad) as PiezasEnRuta, sum(Total) as TotalEnRuta, ");
        sConsulta.AppendLine("(select count(distinct V.ClienteClave) from visita V WHERE V.diaclave =T.DiaClave and V.VendedorId = T.VendedorId  and V.RUTClave = T.RUTClave and FueraFrecuencia = 1) as TotalClienteFueraRuta, ");
        sConsulta.AppendLine("count(distinct ClienteClave1) As ClientesVentaFueraRuta, sum(Cantidad1) as PiezasFueraRuta, sum(Total1) as TotalFueraRuta, DiaClave ");
        sConsulta.AppendLine("FROM(SELECT ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, AGV.RUTClave, VEN.VendedorId, VEN.Nombre as VENNombre, ESQ.EsquemaId, ESQ.Nombre as ESQNombre,  ");
        sConsulta.AppendLine("Convert(VarChar(20), TRP.FechaHoraAlta,110) as FechaHoraAlta, TPD.ProductoClave, PRO.Nombre as PRONombre, TPD.TipoUnidad, TPD.Precio, TRP.DiaClave,  ");
        sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 0 THEN isnull(TPD.Cantidad,0) ELSE 0 END) as Cantidad,  ");
        sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 0 THEN (isnull((SELECT (TPD.SubTotal - sum(TDS.DesImporte) -((TPD.SubTotal - sum(TDS.DesImporte)) * (TRP.DescVendPor/100)))+ ");
        sConsulta.AppendLine("(TPD.Impuesto- sum(TDS.DesImpuesto)+ ((TPD.Impuesto- sum(TDS.DesImpuesto))*(TRP.DescVendPor/100))) FROM TpdDes TDS  ");
        sConsulta.AppendLine("WHERE TDS.TransProdId = TRP.TransProdId AND TDS.TransProdDetalleId = TPD.TransProdDetalleId  ), ");
        sConsulta.AppendLine("(TPD.SubTotal - (TPD.SubTotal * (TRP.DescVendPor/100)))+(TPD.Impuesto - ( TPD.Impuesto*(TRP.DescVendPor/100))))) ELSE 0 END) as Total, ");
        sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 0 THEN Vis.ClienteClave Else null end ) as ClienteClave, ");
        sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 1 THEN isnull(TPD.Cantidad,-44) ELSE 0 END) as Cantidad1, ");
        sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 1 THEN(isnull((SELECT (TPD.SubTotal - sum(TDS.DesImporte) - ((TPD.SubTotal - sum(TDS.DesImporte)) * (TRP.DescVendPor/100)))+ ");
        sConsulta.AppendLine("(TPD.Impuesto-sum(TDS.DesImpuesto)+((TPD.Impuesto- sum(TDS.DesImpuesto))*(TRP.DescVendPor/100))) FROM TpdDes TDS ");
        sConsulta.AppendLine("WHERE TDS.TransProdId = TRP.TransProdId AND TDS.TransProdDetalleId = TPD.TransProdDetalleId  ), ");
        sConsulta.AppendLine("(TPD.SubTotal - (TPD.SubTotal * (TRP.DescVendPor/100)))+(TPD.Impuesto - ( TPD.Impuesto*(TRP.DescVendPor/100))))) ELSE 0 END) as Total1, ");
        sConsulta.AppendLine("(CASE VIS.FueraFrecuencia WHEN 1 THEN Vis.ClienteClave Else null end ) as ClienteClave1 ");
        sConsulta.AppendLine("FROM TransProd TRP ");
        sConsulta.AppendLine("INNER JOIN Visita VIS ON VIS.VisitaClave=TRP.VisitaClave AND VIS.DiaClave=TRP.DiaClave  ");
        sConsulta.AppendLine("INNER JOIN Vendedor VEN ON VEN.VendedorId=VIS.VendedorId ");
        sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor) AGV ON AGV.DiaClave =TRP.DiaClave AND AGV.VendedorId = VIS.VendedorId AND AGV.RUTClave=VIS.RUTClave ");
        sConsulta.AppendLine("INNER JOIN Almacen ALM ON ALM.Clave=AGV.ClaveCEDI ");
        sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD ON TPD.TransProdId=TRP.TransProdId AND TPD.Precio<>0 AND TPD.Subtotal<>0 AND TPD.Total<>0 ");
        sConsulta.AppendLine("INNER JOIN ProductoEsquema PRE ON PRE.ProductoClave=TPD.ProductoClave ");
        sConsulta.AppendLine("INNER JOIN Esquema ESQ ON ESQ.EsquemaId=PRE.EsquemaId ");
        sConsulta.AppendLine("INNER JOIN Producto PRO ON PRO.ProductoClave=TPD.ProductoClave ");
        //sConsulta.AppendLine("where 1 = 1  and convert(datetime,Convert(varchar(20),TRP.FechaHoraAlta,112)) between '2018-01-01T00:00:00' and '2018-06-04T00:00:00'  and VIS.RUTClave in ('006')  AND ALM.Clave = 'MX00'  AND TRP.Tipo = 1 And TRP.TipoFase <> 0 and tpd.promocion<>2 ");
        sConsulta.AppendLine(" AND TRP.Tipo = 1 And TRP.TipoFase <> 0 and tpd.promocion<>2 ");
        sConsulta.AppendLine(") as T group by ALMClave, ALMNombre, RUTClave, VendedorId, VENNombre, EsquemaId, ESQNombre, FechaHoraAlta, ProductoClave, PRONombre, TipoUnidad, Precio, DiaClave ");
        sConsulta.AppendLine(") as Tabla ");
        sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and Tabla.TipoUnidad = VAD.VAVClave and VADTipoLenguaje = 'EM' ");
        sConsulta.AppendLine("group by RUTClave, ProductoClave, PRONombre, VAD.Descripcion");
        QueryString = "";
        QueryString = sConsulta.ToString();

        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //

        //Indicaciones para poder modificar el reporte en la parte visual
        //Sustituir estas lineas de codigo:
        //public TotalGlobalProducto(string pvCondicion)
        //InitializeComponent(QueryString);
        //private void InitializeComponent(string QueryString)
        //customSqlQuery1.Sql = QueryString;

        //Por estas lineas:
        //public TotalGlobalProducto()
        //InitializeComponent();
        //private void InitializeComponent()
        //customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");

        //Una vez hayas sustituido estas lineas de codigo, recompila y compila todo el proyecto para que los cambios surtan efecto
        //De igual manera una vez se realicen las modificaciones e le reporte, se deberan regresar las lineas de codigo a como estaban anteriormente
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
        DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotalGlobalProducto));
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.RutID = new DevExpress.XtraReports.Parameters.Parameter();
        this.Cobertura = new DevExpress.XtraReports.UI.CalculatedField();
        this.CoberturaFueraRuta = new DevExpress.XtraReports.UI.CalculatedField();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel103 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel4,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel22,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel26});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 15F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CoberturaFueraRuta", "{0:0.00%}")});
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(835F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(55F, 15F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "xrLabel2";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel1
        // 
        this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Cobertura", "{0:0.00%}")});
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(495F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(55F, 15F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "xrLabel1";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel4
        // 
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Precio", "{0:c}")});
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(929.9999F, 0F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel4.StyleName = "DataField";
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "xrLabel18";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel14
        // 
        this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ClientesVentaEnRuta", "{0:#,#}")});
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(449.9999F, 0F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(45F, 15F);
        this.xrLabel14.StyleName = "DataField";
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "xrLabel14";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel15
        // 
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ClientesVentaFueraRuta")});
        this.xrLabel15.Dpi = 100F;
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(789.9999F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(45F, 15F);
        this.xrLabel15.StyleName = "DataField";
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "xrLabel15";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel16
        // 
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PiezasEnRuta")});
        this.xrLabel16.Dpi = 100F;
        this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(549.9999F, 0F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(35F, 15F);
        this.xrLabel16.StyleName = "DataField";
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "xrLabel16";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PiezasFueraRuta")});
        this.xrLabel17.Dpi = 100F;
        this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(889.9999F, 0F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(40F, 15F);
        this.xrLabel17.StyleName = "DataField";
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "xrLabel17";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel18
        // 
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Precio", "{0:c}")});
        this.xrLabel18.Dpi = 100F;
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(584.9999F, 0F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel18.StyleName = "DataField";
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "xrLabel18";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.ProductoClave")});
        this.xrLabel19.Dpi = 100F;
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(69.9999F, 0F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel19.StyleName = "DataField";
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "xrLabel19";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel20
        // 
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PRONombre")});
        this.xrLabel20.Dpi = 100F;
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(119.9999F, 0F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(240F, 15F);
        this.xrLabel20.StyleName = "DataField";
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "xrLabel20";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel22
        // 
        this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalClienteFueraRuta")});
        this.xrLabel22.Dpi = 100F;
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(744.9999F, 0F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(45F, 15F);
        this.xrLabel22.StyleName = "DataField";
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "xrLabel22";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel23
        // 
        this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalClientesEnRuta", "{0:#,#}")});
        this.xrLabel23.Dpi = 100F;
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(409.9999F, 0F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(40F, 15F);
        this.xrLabel23.StyleName = "DataField";
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "xrLabel23";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel24
        // 
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalEnRuta", "{0:c}")});
        this.xrLabel24.Dpi = 100F;
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(664.9999F, 0F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel24.StyleName = "DataField";
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "xrLabel24";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel25
        // 
        this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TotalFueraRuta", "{0:c}")});
        this.xrLabel25.Dpi = 100F;
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(1010F, 0F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(80F, 15F);
        this.xrLabel25.StyleName = "DataField";
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "xrLabel25";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel26
        // 
        this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.Unidad", "{0:#,#}")});
        this.xrLabel26.Dpi = 100F;
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(359.9999F, 0F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(50F, 15F);
        this.xrLabel26.StyleName = "DataField";
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "xrLabel26";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 100F;
        this.TopMargin.HeightF = 10F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 100F;
        this.BottomMargin.HeightF = 10F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // sqlDataSource1
        // 
        this.sqlDataSource1.ConnectionName = "eRouteConnection";
        this.sqlDataSource1.Name = "sqlDataSource1";
        customSqlQuery1.Name = "Query";
        customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
        this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
        this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
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
        // RutID
        // 
        this.RutID.Description = "RutID";
        this.RutID.Name = "RutID";
        this.RutID.Visible = false;
        // 
        // Cobertura
        // 
        this.Cobertura.DataMember = "Query";
        this.Cobertura.Expression = "Iif([TotalClientesEnRuta] <= 0, 0, ToDouble([ClientesVentaEnRuta]) / ToDouble([To" +
"talClientesEnRuta]))";
        this.Cobertura.Name = "Cobertura";
        // 
        // CoberturaFueraRuta
        // 
        this.CoberturaFueraRuta.DataMember = "Query";
        this.CoberturaFueraRuta.Expression = "Iif([TotalClienteFueraRuta] <= 0, 0, ToDouble([ClientesVentaFueraRuta]) / ToDoubl" +
"e([TotalClienteFueraRuta]))";
        this.CoberturaFueraRuta.Name = "CoberturaFueraRuta";
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel103});
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.HeightF = 26.04167F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrLabel103
        // 
        this.xrLabel103.Dpi = 100F;
        this.xrLabel103.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel103.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel103.Name = "xrLabel103";
        this.xrLabel103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel103.SizeF = new System.Drawing.SizeF(500F, 20F);
        this.xrLabel103.StylePriority.UseFont = false;
        this.xrLabel103.StylePriority.UseTextAlignment = false;
        this.xrLabel103.Text = "Total Global Por Producto";
        this.xrLabel103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // TotalGlobalProducto
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.Cobertura,
            this.CoberturaFueraRuta});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
        this.DataMember = "Query";
        this.DataSource = this.sqlDataSource1;
        this.FilterString = "[RUTClave] = ?RutID";
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(5, 5, 10, 10);
        this.PageHeight = 850;
        this.PageWidth = 1100;
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.RutID});
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
