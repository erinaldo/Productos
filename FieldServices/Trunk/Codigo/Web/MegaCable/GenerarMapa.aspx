<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerarMapa.aspx.cs" Inherits="GenerarMapa" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: White; background-image:none;"  onunload="Cerrar()">
    <style type="text/css">
        v\:*
        {
            behavior: url(#default#VML);
        }
    </style>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        function Cerrar() {
            PageMethods.DescargarMapas('<%=Request["id"]%>');
        }
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Reportes"></asp:Label>
            </h1>
        </div>
    </div>
    <img alt="" src="img/logo-megacable2.gif" />
    <br />
    <table style="width: 100%; padding: 20px;">
        <tr>
            <td>
                <asp:Label ID="lblFecha" runat="server" Text="#Fecha"></asp:Label>:
                <asp:Label ID="lblFiltro" runat="server"></asp:Label>
            </td>
            <td style="text-align: right">
            </td>
        </tr>
    </table>
    <table style="padding: 20px;">
        <tr>
            <td style="vertical-align: top;">
                <asp:UpdatePanel ID="updMapa" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <cc1:GMap ID="GMap1" runat="server" Height="600px" Width="600px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="vertical-align: top; width: 100%;">
                <asp:UpdatePanel ID="updFiltros" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblGrupoSupervicion" runat="server" Text="#GruposSupervision"></asp:Label>
                        <br />
                        <asp:ComboBox ID="cmbSupervicion" runat="server" DropDownStyle="DropDownList" 
                            Width="250px" AutoPostBack="True" 
                            onselectedindexchanged="cmbSupervicion_SelectedIndexChanged">
                        </asp:ComboBox>
                        <br />
                        <br />
                        <asp:Label ID="lblTecnico" runat="server" Text="#Tecnico"></asp:Label>
                        <br />
                        <asp:Panel ID="pnlTecnico" runat="server" Height="300px" ScrollBars="Auto" Width="300px">
                            <asp:GridView ID="grdTecnico" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                Width="90%" OnRowCommand="grdTecnico_RowCommand">
                                <SelectedRowStyle BackColor="Yellow" />
                            </asp:GridView>
                            <center><asp:Button ID="btnFiltrar" runat="server" Text="#Filtrar" 
                                    onclick="btnFiltrar_Click" Visible="False" /></center>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
