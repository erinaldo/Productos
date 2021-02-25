<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/incidMaster.Master"
    CodeBehind="catRequerimiento.aspx.vb" Inherits="appIncidencias.catRequerimiento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="80%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitle" runat="server" CssClass="Title" Text="Requerimientos"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="100%">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Proyecto:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlProyecto" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Text="Producto:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlProducto" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server" Text="Funcionalidad:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFuncionalidad" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label6" runat="server" Text="Modulo:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlModulo" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" Text="Fuente:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFuente" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label8" runat="server" Text="Fecha Creacion (inicio):"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDateB" runat="server" Style="height: 22px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtDateB"
                                        TargetControlID="txtDateB">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha Creacion (final):"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDateE" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtDateE"
                                        TargetControlID="txtDateE">
                                    </cc1:CalendarExtender>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblVersion" runat="server" Text="Version:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtVersion" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblFolios" runat="server" Text="Folios:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFolios" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" />
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvRequerimientos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataKeyNames="ID" PageSize="12">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Actualizar" />
                                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancelar" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            ImageUrl="~/Imagenes/edit icon.png" Text="Editar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" SortExpression="Proyecto" />
                                <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" />
                                <asp:BoundField DataField="Funcionalidad" HeaderText="Funcionalidad" SortExpression="Funcionalidad" />
                                <asp:BoundField DataField="Fuente" HeaderText="Fuente" SortExpression="Fuente" />
                                <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" SortExpression="Prioridad" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" />
                                <asp:BoundField DataField="Ultima" HeaderText="Ultima Actualizacion" SortExpression="Ultima" />
                                <asp:TemplateField HeaderText="Historial">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkHistorial" runat="server">Historial</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
