<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="NavegacionEncuesta.aspx.cs" Inherits="NavegacionEncuesta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Encuestas"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="toolbar">
                <asp:LinkButton ID="lnkInsert" runat="server" OnClick="Nuevo_Registro_Click">#NuevoRegistro</asp:LinkButton>
                    <!--<asp:ImageButton OnClick="Nuevo_Registro_Click" ID="btnInsert" runat="server" ToolTip="#NuevoRegistro"
                        CommandName="" ImageUrl="~/img/Nuevo.jpg" Style="width: 16px" />-->
                </div>
                <asp:LinqDataSource ID="dsEncuestas" runat="server" OnSelecting="dsEncuestas_Selecting">
                </asp:LinqDataSource>
                <asp:ListView ID="dlEncuestas" runat="server" DataSourceID="dsEncuestas" OnItemCommand="dlEncuestas_ItemCommand">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titClave" runat="server" Text="#Clave"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titNombreEncuesta" runat="server" Text="#NombreEncuesta"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titTipo" runat="server" Text="#Tipo"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titActivo" runat="server" Text="#Activo"></asp:Label>
                                    </th>
                                    <th style = "width:80px;">
                                    </th>
                                </tr>
                                <tr class="navegacion">
                                    <td class="navegacion">
                                        <asp:TextBox ID="filClave" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filNombreEncuesta" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filTipo" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion" style="text-align: center;">
                                        <asp:ComboBox ID="cmbEstado" runat="server" Width="70" AutoCompleteMode="Suggest" DropDownStyle="DropDownList">
                                            <asp:ListItem Text="#Todos" Value="T">
                                            </asp:ListItem>
                                            <asp:ListItem Text="#Activos" Value="A">
                                            </asp:ListItem>
                                            <asp:ListItem Text="#Inactivos" Value="I">
                                            </asp:ListItem>
                                        </asp:ComboBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnFiltrar" runat="server" ToolTip="#Filtrar" ImageUrl="~/img/Document Down.jpg"
                                            CommandName="Filtrar" />
                                        <asp:ImageButton ID="btnQuitarFiltro" runat="server" ToolTip="#BorrarFiltros" ImageUrl="~/img/SinFiltro.gif"
                                            CommandName="QuitarFiltro" />
                                    </td>
                                </tr>
                                <tr runat="server" id="itemPlaceholder" />
                                <tr>
                                    <td>
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlEncuestas"
                                            PageSize="10">
                                            <Fields>
                                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="False"
                                                    ShowPreviousPageButton="False" />
                                                <asp:NumericPagerField />
                                                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                                                    ShowPreviousPageButton="False" />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion">
                                <%#  Eval("ClaveEncuesta") %>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Nombre")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("ValorReferencia.Descripcion")%>
                            </td>
                            <td class="navegacion">
                                <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# (bool)Eval("Estado") %>'
                                    Enabled="False" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%#Eval("ClaveEncuesta") %>'
                                    ImageUrl="~/img/Editar.jpg" ToolTip="#Editar" Visible='<%#  ((Eval("ClaveEncuesta")== null) || (Eval("ClaveEncuesta")=="")? false:true) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
