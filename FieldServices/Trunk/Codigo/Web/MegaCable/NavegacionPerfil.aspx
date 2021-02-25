<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NavegacionPerfil.aspx.cs" Inherits="NavegacionPerfil" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Perfiles"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="toolbar">
                    <asp:LinkButton ID="lnkInsert" runat="server" OnClick="Nuevo_Registro_Click">#NuevoRegistro</asp:LinkButton>
                    <!--<asp:ImageButton OnClick="Nuevo_Registro_Click" ID="btnInsert" runat="server" 
                        ToolTip ="#NuevoRegistro"
                        ImageUrl="~/img/Nuevo.jpg" style="width: 16px" />-->
                </div>
                <asp:LinqDataSource ID="dsPerfiles" runat="server" OnSelecting="dsPerfiles_Selecting">
                </asp:LinqDataSource>
                <asp:ListView ID="dlPerfiles" runat="server" DataSourceID="dsPerfiles" 
                    onitemcommand="dlPerfiles_ItemCommand">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table id="tablaNavegacion" class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titPerfil" runat="server" Text="#Perfil"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titDescripcion" runat="server" Text="#Descripcion"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titActivo" runat="server" Text="#Activo"></asp:Label>
                                    </th>
                                    <th style = "width:80px;">
                                    </th>
                                </tr>
                                <tr class="navegacion">
                                    <td class="navegacion">
                                        <asp:TextBox ID="filPerfil" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filDescripcion" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                        <td class="navegacion" style="text-align: center;">
                                        <asp:ComboBox ID="cmbEstado" runat="server" Width="70" AutoCompleteMode="Suggest" DropDownStyle="DropDownList">
                                            <asp:ListItem Text="#Todos" Value="T"></asp:ListItem>
                                            <asp:ListItem Text="#Activos" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="#Inactivos" Value="I"></asp:ListItem>
                                        </asp:ComboBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnFiltrar" runat="server" ToolTip ="#Filtrar" ImageUrl="~/img/Document Down.jpg"
                                            CommandName="Filtrar" />
                                        <asp:ImageButton ID="btnQuitarFiltro" runat="server" ToolTip ="#BorrarFiltros" ImageUrl="~/img/SinFiltro.gif"
                                            CommandName="QuitarFiltro" />
                                    </td>
                                </tr>
                                <tr runat="server" id="itemPlaceholder" />
                                <tr>
                                    <td>
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlPerfiles"
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
                                <%#  Eval("ClavePerfil") %>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Nombre")%>
                            </td>
                            <td class="navegacion">
                               <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# (bool)Eval("Estado") %>'
                                    Enabled="False" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument = '<%#Eval("ClavePerfil") %>' ImageUrl="~/img/Editar.jpg"
                                    ToolTip="#Editar" Visible='<%#  ((Eval("ClavePerfil")== null) || (Eval("ClavePerfil")=="")? false:true) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

