<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Filtros.aspx.vb" Inherits="FiltrosWEB" %>

<%@ Register Assembly="Janus.Web.GridEX.v3" Namespace="Janus.Web.GridEX.EditControls"
    TagPrefix="jwge" %>
<%@ Register Assembly="Janus.Web.GridEX.v3" Namespace="Janus.Web.GridEX" TagPrefix="jwg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AMESOL BASE >Filtros</title>
    <link rel="stylesheet" type="text/css" href="EstilosWeb.css" />

    <script type="text/javascript">
function Load()
{
var div =document.getElementById("Update");
div.style.visibility="visible";
}
function TABLE1_onclick() {

}

    </script>
    <style type="text/css">
        a.ClaseRoot
        {
            
            font-weight: normal;
	color: black;
	text-decoration: none;
        }
        a.ClaseParent
        {
        	text-decoration: none;
        	color: black;
        }
        a.ClaseHija
        {
        color: black;
        	text-decoration: none;
        		padding-left: 10px;
	padding-top: 3px;
        }     
         a.ClaseSeleccionada
        {
        	text-decoration: none;
        		padding-left: 10px;
	        padding-top: 3px;
	      font-weight: bold;
        }     
        a.ClaseParent:hover
        {
	       font-weight: bold;
        }     
         a.ClaseHija:hover
        {
	       font-weight: bold;
        }    
         a.ClaseRoot:hover
        {
	      font-weight: bold;
        }    
    </style>

</head>
<body id="CuerpoReportesWeb">
    <form id="form1" runat="server">
        <div  style="padding-left: 20px; width: 100%; height: 200px; background-image: url(images/FondoDegradado.gif);
            background-position: top; background-repeat: repeat-x;">
            <table>
                <tr>
                    <td>
                        <img alt="" src="images/ReportesWeb.png" />
                    </td>
                    <td>
                        <asp:Label ID="lbReporteW" runat="server" Text="Reportes Web" Font-Names="Arial"
                            Font-Size="24pt" Font-Bold="true" ForeColor="#191c1f"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Literal ID="litPopUp" runat="server"></asp:Literal>
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600" />
            <table id="TABLE1" border="0" cellpadding="0" cellspacing="0" style="vertical-align: top;
                width: 100%; height: 100%; text-align: left;" onclick="return TABLE1_onclick()">
                <tr>
                     <td style="vertical-align: top; width: 350px; text-align: left;">
                        <table id="TABLEIZQ" border="0" cellpadding="0" cellspacing="0">
                         <tr>
                        <td>
                         <asp:Label ID="Label2" runat="server" Text="Reporte: " Font-Names="Tahoma" Font-Size="9pt"
                                    Font-Bold="True"></asp:Label>
                        </td>
                        </tr>
                         
                        <tr>
                        <td>
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False" RenderMode="Inline">
                            <ContentTemplate>
                             
                                <asp:DropDownList ID="ddlReporte" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReporte_SelectedIndexChanged"
                                    Width="300px">
                                </asp:DropDownList>
                                <table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
                                    border-top-style: none; padding-top: 0px; border-right-style: none; border-left-style: none;
                                    border-collapse: collapse; border-bottom-style: none">
                                    <tr>
                                        <td style="width: 100px">
                                <asp:CheckBox ID="chboxDetallado" runat="server" AutoPostBack="true" Text="Detallado"
                                    Font-Names="Tahoma" Font-Size="9pt" Checked="True" OnCheckedChanged="chboxDetallado_CheckedChanged1" /></td>
                                        <td style="width: 100px">
                                <asp:CheckBox ID="chboxGeneral" runat="server" AutoPostBack="true" Text="General"
                                    Font-Names="Tahoma" Font-Size="9pt" OnCheckedChanged="chboxGeneral_CheckedChanged1" /></td>
                                        <td style="width: 100px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                <asp:CheckBox ID="chboxAsignados" runat="server" AutoPostBack="true" Text="Asignados"
                                    Font-Names="Tahoma" Font-Size="9pt" OnCheckedChanged="chboxAsignados_CheckedChanged" /></td>
                                        <td style="width: 100px">
                                            <asp:CheckBox
                                        ID="chboxNoAsignados" runat="server" AutoPostBack="true" Text="No Asignados"
                                        Font-Names="Tahoma" Font-Size="9pt" OnCheckedChanged="chboxNoAsignados_CheckedChanged" /></td>
                                        <td style="width: 100px">
                                            <asp:CheckBox
                                            ID="chboxPorFiltro" runat="server" AutoPostBack="true" Text="Por Filtro" Font-Names="Tahoma"
                                            Font-Size="9pt" OnCheckedChanged="chboxPorFiltro_CheckedChanged" /></td>
                                    </tr>
                                </table>
                                <cc1:MutuallyExclusiveCheckBoxExtender ID="mecheTipoReporte" TargetControlID="chboxDetallado"
                                    Key="tipoReporte" runat="server">
                                </cc1:MutuallyExclusiveCheckBoxExtender>
                                <cc1:MutuallyExclusiveCheckBoxExtender ID="mecheTipoReporte2" TargetControlID="chboxGeneral"
                                    Key="tipoReporte" runat="server">
                                </cc1:MutuallyExclusiveCheckBoxExtender>
                              <cc1:MutuallyExclusiveCheckBoxExtender
                                                ID="mecheTipoReporte3" TargetControlID="chboxAsignados" Key="tipoReporte" runat="server">
                                            </cc1:MutuallyExclusiveCheckBoxExtender>
                                <cc1:MutuallyExclusiveCheckBoxExtender ID="mecheTipoReporte4" TargetControlID="chboxNoAsignados"
                                    Key="tipoReporte" runat="server">
                                </cc1:MutuallyExclusiveCheckBoxExtender>
                                <cc1:MutuallyExclusiveCheckBoxExtender ID="mecheTipoReporte5" TargetControlID="chboxPorFiltro"
                                    Key="tipoReporte" runat="server">
                                </cc1:MutuallyExclusiveCheckBoxExtender>
                              <br />
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt"
                                    Text="Formato: "></asp:Label>
                             <br />
                                <asp:DropDownList ID="DdlFormato" runat="server" AutoPostBack="True"
                                    Width="300px">
                                </asp:DropDownList>
                                   <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                         <br />
                        </td>
                        </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False"
                                        RenderMode="Inline">
                                        <ContentTemplate>
                                            <table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
                                                border-top-style: none; padding-top: 0px; border-right-style: none; border-left-style: none;
                                                border-collapse: collapse; border-bottom-style: none">
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="ChBoxCentroDistribucion" runat="server" AutoPostBack="true" Font-Names="Tahoma"
                                                            Font-Size="9pt" OnCheckedChanged="ChBoxCentroDistribucion_CheckedChanged1" Font-Bold="True"
                                                            Text="Centros De Distribucion" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="PanelCentroDistribucion" runat="server">
                                                            <asp:DropDownList ID="DdlCentroDistribucion" runat="server" Width="299px">
                                                            </asp:DropDownList>
                                                            <br />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                        </tr>
                        
                         <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False"
                                RenderMode="Inline">
                                <ContentTemplate>
                                    <table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
                                        border-top-style: none; padding-top: 0px; border-right-style: none; border-left-style: none;
                                        border-collapse: collapse; border-bottom-style: none">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chboxVendedor" runat="server" AutoPostBack="true" Font-Names="Tahoma"
                                                    Font-Size="9pt" OnCheckedChanged="chboxVendedor_CheckedChanged" Text="Vendedor"
                                                    Font-Bold="True" />
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="PanelVendedor" runat="server" Visible="False">
                                                    <table style="width :100%">
                                                        <tr>
                                                            <td style="padding-left: 30px;">
                                                                <asp:CheckBox ID="chBoxVendedorActivo" runat="server" AutoPostBack="true" Text="Mostrar Inactivos"
                                                                    Font-Names="Tahoma" Font-Size="9pt" OnCheckedChanged="chboxVendedorActivo_checkedChanged"
                                                                    Width="224px" Font-Bold="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                                <asp:DropDownList ID="ddlVendedor" runat="server" AutoPostBack="True" Font-Names="verdana"
                                                                Font-Size="X-Small" Width="300px"></asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                       
                        </tr>
                        
                         <tr>
                         <td>
                          <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" RenderMode="Inline"
                            ChildrenAsTriggers="False">
                            <ContentTemplate>
                               <table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; border-top-style: none; padding-top: 0px; border-right-style: none; border-left-style: none; border-collapse: collapse; border-bottom-style: none">
                               <tr>
                               <td>
                                <asp:CheckBox ID="chboxFecha" runat="server" AutoPostBack="true" Font-Names="Tahoma"
                                    Font-Size="9pt" OnCheckedChanged="chboxFecha_CheckedChanged" Text="Fecha :" Font-Bold="True" />
                                    </td>
                                   <td>
                                <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="8pt" Text="dd/mm/aaaa"
                                                ForeColor="Gray" Visible="False"></asp:Label></td>
                                   <td>
                                   </td>
                                    </tr>
                               
                               <tr>
                               <td style="height: 22px">
                                <asp:DropDownList ID="ddlFecha" runat="server" AutoPostBack="True"
                                    Font-Names="verdana" Font-Size="X-Small" OnSelectedIndexChanged="ddlFecha_SelectedIndexChanged"
                                    Width="109px" Visible="False">
                                </asp:DropDownList>
                                       </td>
                                   <td style="height: 22px">
                        <asp:TextBox ID="txtFInicio" runat="server" Font-Names="Verdana"
                                    Font-Size="X-Small" Width="80px" Visible="False"></asp:TextBox></td>
                                   <td style="height: 22px">
                                <asp:TextBox ID="txtFFinal" runat="server" Font-Names="Verdana" Font-Size="X-Small" Width="80px" Visible="False"></asp:TextBox></td>
                                      </tr>
                              
                               </table>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFFinal"
                                    Format="dd/MM/yyyy" OnClientDateSelectionChanged=" hideCalendar">
                                </cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFInicio"
                                    Format="dd/MM/yyyy" OnClientDateSelectionChanged=" hideCalendar">
                                </cc1:CalendarExtender>
                                &nbsp;
                         </ContentTemplate>
                       
                        </asp:UpdatePanel>
                             <asp:UpdatePanel ID="UpdatePanel6" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                 <ContentTemplate>
                                <asp:Label ID="lbError" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="Red"></asp:Label>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                         
                        
                        </td>
                        </tr>
                        
                         
                         <tr>
                        <td style="text-align:right">
                                <br />
                    <asp:Button ID="btnContinuar" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="X-Small"
                            OnClick="btnContinuar_Click" Text="Continuar" OnClientClick="this.disabled = true; Load()"
                            UseSubmitBehavior="False" />
                        </td>
                        </tr>
                                              
                            </table>
                    </td>
                    <!--

Separacion Filas

-->
                    <td style="vertical-align: top; text-align: left;">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <asp:CheckBox ID="chboxRuta" runat="server" AutoPostBack="true" Enabled="true" OnCheckedChanged="chboxRuta_CheckedChanged"
                                    Text="Ruta :" Font-Names="Tahoma" Font-Size="9pt" Font-Bold="True" /><jwg:GridEX ID="GridEXRuta" runat="server" FilterMode="Automatic"
                                    GridLineColor="ScrollBar" GroupByBoxVisible="False" DefaultFilterRowComparison="Equal" Visible="False">
<SelectedFormatStyle VerticalAlign="top" BackColor="#316AC5" ForeColor="HighlightText" Height="20px"></SelectedFormatStyle>

<PageNavigatorSettings PageBlockSize="1000" PageSize="10"><BottomPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel Visible="False"></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorNextBlockPanel>
</BottomPageNavigatorPanels>
<TopPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</TopPageNavigatorPanels>
</PageNavigatorSettings>

<GroupTotalRowFormatStyle BackColor="Control" Height="20px"></GroupTotalRowFormatStyle>

<HeaderFormatStyle Appearance="RaisedLight" BackColor="Control" BorderColor="GrayText" BorderWidth="1px" BorderStyle="Solid" ForeColor="ControlText" Height="20px"></HeaderFormatStyle>

<AlternatingRowFormatStyle BackColor="Control" BorderWidth="1px" BorderStyle="Solid" Height="20px"></AlternatingRowFormatStyle>

<GroupRowFormatStyle TextAlign="left" VerticalAlign="middle" BackColor="Control" ForeColor="ControlText" Height="20px"></GroupRowFormatStyle>

<GroupByBoxFormatStyle Padding="5px 4px 5px 4px" BackColor="ControlDark"></GroupByBoxFormatStyle>

<FocusCellFormatStyle BorderColor="Highlight" BorderWidth="1px" BorderStyle="Solid"></FocusCellFormatStyle>

<PageNavigatorFormatStyle Appearance="RaisedLight" BackColor="Control"></PageNavigatorFormatStyle>

<TotalRowFormatStyle BackColor="Window" Height="20px"></TotalRowFormatStyle>

<GroupRowIndentJunctionFormatStyle BackColor="Control"></GroupRowIndentJunctionFormatStyle>

<EditorsFormatStyle BackColor="Control"></EditorsFormatStyle>

<NewRowFormatStyle BackColor="Window" ForeColor="WindowText" Height="20px"></NewRowFormatStyle>

<GroupByBoxInfoFormatStyle VerticalAlign="middle" Padding="4px 4px" BackColor="Control" ForeColor="ControlDark" Height="100%"></GroupByBoxInfoFormatStyle>

<RootTable><Columns>
<jwg:GridEXColumn ActAsSelector="True" AllowDrag="False" Key="Selector" Width="20px" DefaultGroupPrefix=":" ColumnType="CheckBox" EditType="CheckBox" FilterRowComparison="Equal" FilterEditType="NoEdit" InvalidValueAction="DiscardChanges" DataTypeCode="Boolean">
<CellStyle Width="20px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Clave" Key="RUTClave" HeaderAlignment="Center" DataMember="RUTClave" DefaultGroupPrefix="Clave:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object"></jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Descripcion" Key="Descripcion" Width="230px" HeaderAlignment="Center" DataMember="Descripcion" DefaultGroupPrefix="Descripcion:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object">
<CellStyle Width="230px"></CellStyle>
</jwg:GridEXColumn>
</Columns>
</RootTable>

<FilterRowFormatStyle BackColor="Window" ForeColor="WindowText"></FilterRowFormatStyle>

<RowFormatStyle TextAlign="left" VerticalAlign="top" BackColor="Window" BorderWidth="1px" BorderStyle="Solid" ForeColor="WindowText" Height="20px"></RowFormatStyle>

<GroupIndentFormatStyle BackColor="Control"></GroupIndentFormatStyle>

<PreviewRowFormatStyle ForeColor="Blue" Height="100%"></PreviewRowFormatStyle>
</jwg:GridEX>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="PanelEncuestas" Height="100%" Width="100%">
                                    <br />
                                    <asp:Label ID="LbEncuesta" runat="server" Text="Encuestas:" Font-Names="Tahoma" Font-Size="9pt"
                                        Font-Bold="True"></asp:Label>
                                         <asp:Panel ID="PanelEnc" runat="server" BorderStyle="Solid" Height="216px" ScrollBars="Auto"
                                            Width="352px" BorderColor="#002D96" BorderWidth="1px">
                                             &nbsp;
                                             <asp:TreeView ID="tvEncuesta" runat="server" ExpandDepth="2" OnSelectedNodeChanged="tvEncuesta_SelectedNodeChanged" Font-Names="Tahoma" Font-Size="9pt" Font-Bold="False" EnableClientScript="False" ExpandImageUrl="~/images/derecha.gif" NodeWrap="True" PopulateNodesFromClient="False" CollapseImageUrl="~/images/abajo.gif" NoExpandImageUrl="~/images/kfouleggs.gif" EnableTheming="True" SkipLinkText="?">
                                                <RootNodeStyle  CssClass="ClaseRoot" ImageUrl="~/images/esc_cliente.gif" />
                                                <LeafNodeStyle CssClass="ClaseParent"  />
                                                <NodeStyle CssClass="ClaseHija"  />
                                                <SelectedNodeStyle CssClass="ClaseSeleccionada" Font-Bold="True" />
                                                                                            </asp:TreeView>
                                             </asp:Panel>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="PanelEsquemas" Height="100%" Width="100%">
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt"
                                        Text="Esquemas:"></asp:Label>
                                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="216px" ScrollBars="Auto"
                                            Width="352px" BorderColor="#002D96" BorderWidth="1px">
                                            <asp:TreeView ID="tvEsquema" runat="server" ExpandDepth="2" OnSelectedNodeChanged="tvEsquema_SelectedNodeChanged" Font-Names="Tahoma" Font-Size="9pt" Font-Bold="False" EnableClientScript="False" ExpandImageUrl="~/images/derecha.gif" NodeWrap="True" PopulateNodesFromClient="False" CollapseImageUrl="~/images/abajo.gif" NoExpandImageUrl="~/images/kfouleggs.gif" EnableTheming="True" SkipLinkText="?">
                                                <RootNodeStyle  CssClass="ClaseRoot" ImageUrl="~/images/esc_cliente.gif" />
                                                <LeafNodeStyle CssClass="ClaseParent"  />
                                                <NodeStyle CssClass="ClaseHija"  />
                                                <SelectedNodeStyle CssClass="ClaseSeleccionada" Font-Bold="True" />
                                                
                                            </asp:TreeView>
                                        </asp:Panel>
                                        
                                        
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <br />
                                <asp:Panel ID="Pnlclientes" runat="server" Height="100%" Width="100%">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                        Font-Size="9pt" Text="Label"></asp:Label><br />
                                    <jwg:GridEX ID="GridEXCliente" runat="server" FilterMode="Automatic" GridLineColor="ScrollBar"
                                        GroupByBoxVisible="False" DefaultFilterRowComparison="Equal">
<SelectedFormatStyle VerticalAlign="top" BackColor="#316AC5" ForeColor="HighlightText" Height="20px"></SelectedFormatStyle>

<PageNavigatorSettings PageBlockSize="1000" PageSize="10"><BottomPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel Visible="False"></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorNextBlockPanel>
</BottomPageNavigatorPanels>
<TopPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</TopPageNavigatorPanels>
</PageNavigatorSettings>

<GroupTotalRowFormatStyle BackColor="Control" Height="20px"></GroupTotalRowFormatStyle>

<HeaderFormatStyle Appearance="RaisedLight" BackColor="Control" BorderColor="GrayText" BorderWidth="1px" BorderStyle="Solid" ForeColor="ControlText" Height="20px"></HeaderFormatStyle>

<AlternatingRowFormatStyle BackColor="Control" BorderWidth="1px" BorderStyle="Solid" Height="20px"></AlternatingRowFormatStyle>

<GroupRowFormatStyle TextAlign="left" VerticalAlign="middle" BackColor="Control" ForeColor="ControlText" Height="20px"></GroupRowFormatStyle>

<GroupByBoxFormatStyle Padding="5px 4px 5px 4px" BackColor="ControlDark"></GroupByBoxFormatStyle>

<FocusCellFormatStyle BorderColor="Highlight" BorderWidth="1px" BorderStyle="Solid"></FocusCellFormatStyle>

<PageNavigatorFormatStyle Appearance="RaisedLight" BackColor="Control"></PageNavigatorFormatStyle>

<TotalRowFormatStyle BackColor="Window" Height="20px"></TotalRowFormatStyle>

<GroupRowIndentJunctionFormatStyle BackColor="Control"></GroupRowIndentJunctionFormatStyle>

<EditorsFormatStyle BackColor="Control"></EditorsFormatStyle>

<NewRowFormatStyle BackColor="Window" ForeColor="WindowText" Height="20px"></NewRowFormatStyle>

<GroupByBoxInfoFormatStyle VerticalAlign="middle" Padding="4px 4px" BackColor="Control" ForeColor="ControlDark" Height="100%"></GroupByBoxInfoFormatStyle>

<RootTable><Columns>
<jwg:GridEXColumn ActAsSelector="True" AllowDrag="False" Key="Selector" Width="20px" DefaultGroupPrefix=":" ColumnType="CheckBox" EditType="CheckBox" FilterRowComparison="Equal" FilterEditType="NoEdit" InvalidValueAction="DiscardChanges" DataTypeCode="Boolean">
<CellStyle Width="20px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Clave" Key="ClienteClave" DataMember="ClienteClave" DefaultGroupPrefix="Clave:" FilterRowComparison="Contains" FilterEditType="TextBox" Visible="False" InvalidValueAction="DiscardChanges" DataTypeCode="Object"></jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Clave" Key="Clave" HeaderAlignment="Center" DataMember="Clave" DefaultGroupPrefix="Clave:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object"></jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Cliente" Key="RazonSocial" Width="230px" HeaderAlignment="Center" DataMember="RazonSocial" DefaultGroupPrefix="Cliente:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object">
<CellStyle Width="230px"></CellStyle>
</jwg:GridEXColumn>
</Columns>
</RootTable>

<FilterRowFormatStyle BackColor="Window" ForeColor="WindowText"></FilterRowFormatStyle>

<RowFormatStyle TextAlign="left" VerticalAlign="top" BackColor="Window" BorderWidth="1px" BorderStyle="Solid" ForeColor="WindowText" Height="20px"></RowFormatStyle>

<GroupIndentFormatStyle BackColor="Control"></GroupIndentFormatStyle>

<PreviewRowFormatStyle ForeColor="Blue" Height="100%"></PreviewRowFormatStyle>
</jwg:GridEX></asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <br />
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                    Font-Size="9pt" Text="Label"></asp:Label>&nbsp;<br />
                                <jwg:GridEX ID="GridEXProducto" runat="server" FilterMode="Automatic"
                                    GridLineColor="ScrollBar" GroupByBoxVisible="False" DefaultFilterRowComparison="Equal">
<SelectedFormatStyle VerticalAlign="top" BackColor="#316AC5" ForeColor="HighlightText" Height="20px"></SelectedFormatStyle>

<PageNavigatorSettings PageBlockSize="1000" PageSize="10"><BottomPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel Visible="False"></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorNextBlockPanel>
</BottomPageNavigatorPanels>
<TopPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</TopPageNavigatorPanels>
</PageNavigatorSettings>

<GroupTotalRowFormatStyle BackColor="Control" Height="20px"></GroupTotalRowFormatStyle>

<HeaderFormatStyle Appearance="RaisedLight" BackColor="Control" BorderColor="GrayText" BorderWidth="1px" BorderStyle="Solid" ForeColor="ControlText" Height="20px"></HeaderFormatStyle>

<AlternatingRowFormatStyle BackColor="Control" BorderWidth="1px" BorderStyle="Solid" Height="20px"></AlternatingRowFormatStyle>

<GroupRowFormatStyle TextAlign="left" VerticalAlign="middle" BackColor="Control" ForeColor="ControlText" Height="20px"></GroupRowFormatStyle>

<GroupByBoxFormatStyle Padding="5px 4px 5px 4px" BackColor="ControlDark"></GroupByBoxFormatStyle>

<FocusCellFormatStyle BorderColor="Highlight" BorderWidth="1px" BorderStyle="Solid"></FocusCellFormatStyle>

<PageNavigatorFormatStyle Appearance="RaisedLight" BackColor="Control"></PageNavigatorFormatStyle>

<TotalRowFormatStyle BackColor="Window" Height="20px"></TotalRowFormatStyle>

<GroupRowIndentJunctionFormatStyle BackColor="Control"></GroupRowIndentJunctionFormatStyle>

<EditorsFormatStyle BackColor="Control"></EditorsFormatStyle>

<NewRowFormatStyle BackColor="Window" ForeColor="WindowText" Height="20px"></NewRowFormatStyle>

<GroupByBoxInfoFormatStyle VerticalAlign="middle" Padding="4px 4px" BackColor="Control" ForeColor="ControlDark" Height="100%"></GroupByBoxInfoFormatStyle>

<RootTable><Columns>
<jwg:GridEXColumn ActAsSelector="True" AllowDrag="False" Key="Selector" Width="20px" DefaultGroupPrefix=":" ColumnType="CheckBox" EditType="CheckBox" FilterRowComparison="Equal" FilterEditType="NoEdit" InvalidValueAction="DiscardChanges" DataTypeCode="Boolean">
<CellStyle Width="20px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn Caption="EsquemaId" Key="EsquemaId" DataMember="EsquemaId" DefaultGroupPrefix="EsquemaId:" FilterRowComparison="Equal" Visible="False" InvalidValueAction="DiscardChanges" DataTypeCode="Object"></jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Clave" Key="Clave" HeaderAlignment="Center" DataMember="Clave" DefaultGroupPrefix="Clave:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object"></jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Producto" Key="Nombre" Width="230px" HeaderAlignment="Center" DataMember="Nombre" DefaultGroupPrefix="Producto:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object">
<CellStyle Width="230px"></CellStyle>
</jwg:GridEXColumn>
</Columns>
</RootTable>

<FilterRowFormatStyle BackColor="Window" ForeColor="WindowText"></FilterRowFormatStyle>

<RowFormatStyle TextAlign="left" VerticalAlign="top" BackColor="Window" BorderWidth="1px" BorderStyle="Solid" ForeColor="WindowText" Height="20px"></RowFormatStyle>

<GroupIndentFormatStyle BackColor="Control"></GroupIndentFormatStyle>

<PreviewRowFormatStyle ForeColor="Blue" Height="100%"></PreviewRowFormatStyle>
</jwg:GridEX>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <br />
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                    Font-Size="9pt" Text="Label"></asp:Label><br />
                                <jwg:GridEX ID="GridEXActivos" runat="server" DefaultFilterRowComparison="Equal" FilterMode="Automatic" GridLineColor="ScrollBar" GroupByBoxVisible="False">
<SelectedFormatStyle VerticalAlign="top" BackColor="#316AC5" ForeColor="HighlightText" Height="20px"></SelectedFormatStyle>

<PageNavigatorSettings PageBlockSize="1000" PageSize="10"><BottomPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel Visible="False"></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right" Visible="False"></jwg:GridEXPageNavigatorNextBlockPanel>
</BottomPageNavigatorPanels>
<TopPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</TopPageNavigatorPanels>
</PageNavigatorSettings>

<GroupTotalRowFormatStyle BackColor="Control" Height="20px"></GroupTotalRowFormatStyle>

<HeaderFormatStyle Appearance="RaisedLight" BackColor="Control" BorderColor="GrayText" BorderWidth="1px" BorderStyle="Solid" ForeColor="ControlText" Height="20px"></HeaderFormatStyle>

<AlternatingRowFormatStyle BackColor="Control" BorderWidth="1px" BorderStyle="Solid" Height="20px"></AlternatingRowFormatStyle>

<GroupRowFormatStyle TextAlign="left" VerticalAlign="middle" BackColor="Control" ForeColor="ControlText" Height="20px"></GroupRowFormatStyle>

<GroupByBoxFormatStyle Padding="5px 4px 5px 4px" BackColor="ControlDark"></GroupByBoxFormatStyle>

<FocusCellFormatStyle BorderColor="Highlight" BorderWidth="1px" BorderStyle="Solid"></FocusCellFormatStyle>

<PageNavigatorFormatStyle Appearance="RaisedLight" BackColor="Control"></PageNavigatorFormatStyle>

<TotalRowFormatStyle BackColor="Window" Height="20px"></TotalRowFormatStyle>

<GroupRowIndentJunctionFormatStyle BackColor="Control"></GroupRowIndentJunctionFormatStyle>

<EditorsFormatStyle BackColor="Control"></EditorsFormatStyle>

<NewRowFormatStyle BackColor="Window" ForeColor="WindowText" Height="20px"></NewRowFormatStyle>

<GroupByBoxInfoFormatStyle VerticalAlign="middle" Padding="4px 4px" BackColor="Control" ForeColor="ControlDark" Height="100%"></GroupByBoxInfoFormatStyle>

<RootTable><Columns>
<jwg:GridEXColumn ActAsSelector="True" AllowDrag="False" Key="Selector" Width="20px" DefaultGroupPrefix=":" ColumnType="CheckBox" EditType="CheckBox" FilterRowComparison="Equal" FilterEditType="NoEdit" InvalidValueAction="DiscardChanges" DataTypeCode="Boolean">
<CellStyle Width="20px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn Caption="Clave" Key="ActivoClave" HeaderAlignment="Center" DataMember="ActivoClave" DefaultGroupPrefix="Clave:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object"></jwg:GridEXColumn>
<jwg:GridEXColumn Caption="IdElectronico" Key="IdElectronico" Width="230px" HeaderAlignment="Center" DataMember="IdElectronico" DefaultGroupPrefix="Cliente:" FilterRowComparison="Contains" FilterEditType="TextBox" InvalidValueAction="DiscardChanges" DataTypeCode="Object">
<CellStyle Width="230px"></CellStyle>
</jwg:GridEXColumn>
</Columns>
</RootTable>

<FilterRowFormatStyle BackColor="Window" ForeColor="WindowText"></FilterRowFormatStyle>

<RowFormatStyle TextAlign="left" VerticalAlign="top" BackColor="Window" BorderWidth="1px" BorderStyle="Solid" ForeColor="WindowText" Height="20px"></RowFormatStyle>

<GroupIndentFormatStyle BackColor="Control"></GroupIndentFormatStyle>

<PreviewRowFormatStyle ForeColor="Blue" Height="100%"></PreviewRowFormatStyle>
</jwg:GridEX>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <br />
                                <div runat="server" id="divAlgo">
                                </div>
                                <asp:Panel ID="PanelLiquidacion" runat="server" Height="100%" Width="100%" Visible="False">
                                    <table>
                                        <tr>
                                            <td style="width: 61%">
                                                <asp:Label ID="LabelDegustacion" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="9pt" Text="Degustacion:" Width="158px"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtDegustacion" runat="server">0.00</asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 61%">
                                                <asp:Label ID="LabelChequesDevueltos" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="9pt" Text="ChequesDevueltos:" Width="158px"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtChequesDevueltos" runat="server">0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 61%">
                                                <asp:Label ID="LabelComision" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="9pt" Text="Comision:" Width="158px"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtComision" runat="server">0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp; &nbsp;
                                &nbsp;&nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:HiddenField ID="Logeado" runat="server" />
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                 <ProgressTemplate>
                    <iframe style="position: fixed; top: 0px; left: 0px; width: 100%; height: 100%; filter: alpha(opacity=40)">
                </iframe>
                    <div style="position: fixed; top: 0px; left: 0px; color: Blue">
                        <!--<img alt="" src="images/loader.gif" />-->
                        cargando
                    </div>
                    
                </ProgressTemplate>
            </asp:UpdateProgress>
            &nbsp;&nbsp;
            <div id="Update" style="visibility: hidden">
                <div style="position: fixed; top: 0px; left: 0px; width: 100%; height: 100%; background-color: #FFFFFF">
                </div>
                <div style="position: fixed; top: 35%; left: 45%">
                    <img alt="" src="images/loader2.gif" /></div>
            </div>
        </div>
    </form>
</body>
</html>
