<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/incidMaster.Master"
    CodeBehind="Default.aspx.vb" Inherits="appIncidencias.wfrmFormularioReq" %>

<%@ Register Src="Controls/AutoFillCombo.ascx" TagName="AutoFillCombo" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/AutoFillCombo.ascx" TagName="AutoFillCombo" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .izquierda
        {
            text-align: left;
        }
        .derecha
        {
            text-align: right;
        }
        .titulo
        {
            text-align: center;
        }
        td
        {
            vertical-align: top; /*border:solid 1px red;*/
        }
        .enlinea
        {
            display: inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table id="general" width="80%" cellspacing="5">
        <tr>
            <td class="titulo" colspan="4">
                <asp:Label CssClass="Title" ID="lblTitle" runat="server" Text="Registro de Requerimientos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="derecha">
                <asp:Label ID="Label1" runat="server" Text="Proyecto:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProyecto" runat="server" ValidationGroup="Necesario">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProyecto"
                            ErrorMessage="*" InitialValue="0" ValidationGroup="Necesario"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="derecha">
                <asp:Label ID="Label2" runat="server" Text="Producto:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProducto" runat="server" AutoPostBack="True" ValidationGroup="Necesario">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProducto"
                            ErrorMessage="*" InitialValue="0" ValidationGroup="Necesario"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="derecha">
                Prioridad:
            </td>
            <td class="izquierda">
            <asp:DropDownList ID="ddlPrioridad" runat="server" ValidationGroup="Necesario">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPrioridad"
                    ErrorMessage="*" InitialValue="0" ValidationGroup="Necesario"></asp:RequiredFieldValidator>
            </td>
            <td class="derecha">
                Estado:
            </td>
            <td class="izquierda">
            <asp:DropDownList ID="ddlEstado" runat="server" ValidationGroup="Necesario">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlEstado"
                    ErrorMessage="*" InitialValue="0" ValidationGroup="Necesario"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        <tr>
            <td class="derecha">
                <asp:Label ID="Label7" runat="server" Text="Fuente:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:TextBox ID="txtFuente" runat="server" ValidationGroup="Necesario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFuente"
                    ErrorMessage="*" ValidationGroup="Necesario">*</asp:RequiredFieldValidator>
            </td>
            <td class="derecha">
                <asp:Label ID="Label5" runat="server" Text="Funcionalidad:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:DropDownList ID="ddlFuncionalidad" runat="server" ValidationGroup="Necesario">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlFuncionalidad"
                    ErrorMessage="*" InitialValue="0" ValidationGroup="Necesario"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="derecha">
                <asp:Label ID="Label6" runat="server" Text="Requerimiento:"></asp:Label>
            </td>
            <td class="izquierda" colspan="3">
                <asp:TextBox ID="txtRequerimiento" runat="server" Rows="3" TextMode="MultiLine" Width="90%"
                    ValidationGroup="Necesario" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRequerimiento"
                    ErrorMessage="*" ValidationGroup="Necesario"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="derecha">
                <asp:Label ID="lbCliente" runat="server" Text="Clientes:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:Panel ID="Panel6" runat="server" DefaultButton="ibAddCliente">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                                ServiceMethod="ObtenerCliente" ServicePath="Autocomplete.asmx" TargetControlID="txtNewCliente">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtNewCliente" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ibAddCliente" runat="server" ImageUrl="~/Imagenes/add-icon.jpg"
                                Style="height: 16px" />
                            <asp:ImageButton ID="ibSearchCliente" runat="server" ImageUrl="~/Imagenes/magnifying_icon.gif"
                                Width="16px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td class="derecha">
                <asp:Label ID="lbModulo" runat="server" Text="Modulos:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:Panel ID="Panel7" runat="server" DefaultButton="ibAddModulo">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                ServiceMethod="ObtenerModulo" ServicePath="Autocomplete.asmx" TargetControlID="txtNewModulo">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtNewModulo" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ibAddModulo" runat="server" ImageUrl="~/Imagenes/add-icon.jpg" />
                            <asp:ImageButton ID="ibSearchModulo" runat="server" ImageUrl="~/Imagenes/magnifying_icon.gif"
                                Style="height: 16px; width: 16px;" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="updListCliente" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbClientes" runat="server" Width="154px"></asp:ListBox>
                        <asp:ImageButton ID="ibRemoveCliente" runat="server" ImageUrl="~/Imagenes/Borrar.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="updListModulo" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbModulos" runat="server" Width="155px"></asp:ListBox>
                        <asp:ImageButton ID="ibRemoveModulo" runat="server" ImageUrl="~/Imagenes/Borrar.gif"
                            Width="16px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="derecha">
                <asp:Label ID="Label8" runat="server" Text="Casos de Uso:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="ibAddCasoUso">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <cc1:AutoCompleteExtender ID="AutoCompleteCasoUso" runat="server" MinimumPrefixLength="1"
                                ServiceMethod="ObtenerCasoUso" ServicePath="Autocomplete.asmx" TargetControlID="txtNewCasoUso">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtNewCasoUso" runat="server" ></asp:TextBox>
                            <asp:ImageButton ID="ibAddCasoUso" runat="server" ImageUrl="~/Imagenes/add-icon.jpg"
                                Style="height: 16px" />
                            <asp:ImageButton ID="ibSearchCU" runat="server" ImageUrl="~/Imagenes/magnifying_icon.gif"
                                Width="16px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td class="derecha">
                <asp:Label ID="Label10" runat="server" Text="Componentes:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:Panel ID="Panel2" runat="server" DefaultButton="ibAddComponente">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <cc1:AutoCompleteExtender ID="AutoCompleteComponente" runat="server" MinimumPrefixLength="1"
                                ServiceMethod="ObtenerComponente" ServicePath="Autocomplete.asmx" TargetControlID="txtNewComponente">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtNewComponente" runat="server" ></asp:TextBox>
                            <asp:ImageButton ID="ibAddComponente" runat="server" ImageUrl="~/Imagenes/add-icon.jpg" />
                            <asp:ImageButton ID="ibSearchCO" runat="server" ImageUrl="~/Imagenes/magnifying_icon.gif"
                                Style="height: 16px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbCasoUso" runat="server" Width="154px"></asp:ListBox>
                        <asp:ImageButton ID="ibRemoveCasoUso" runat="server" ImageUrl="~/Imagenes/Borrar.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbComponentes" runat="server" Width="155px"></asp:ListBox>
                        <asp:ImageButton ID="ibRemoveComponente" runat="server" ImageUrl="~/Imagenes/Borrar.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="derecha">
                <asp:Label ID="Label9" runat="server" Text="Casos de Prueba:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:Panel ID="Panel3" runat="server" DefaultButton="ibAddCasoPrueba">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <cc1:AutoCompleteExtender ID="AutoCompleteCasoPrueba" runat="server" TargetControlID="txtNewCasoPrueba"
                                ServicePath="Autocomplete.asmx" ServiceMethod="ObtenerCasoPrueba" MinimumPrefixLength="1">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtNewCasoPrueba" runat="server"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ibAddCasoPrueba" runat="server" ImageUrl="~/Imagenes/add-icon.jpg" />
                            <asp:ImageButton ID="ibSearchCP" runat="server" ImageUrl="~/Imagenes/magnifying_icon.gif" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td class="derecha">
                <asp:Label ID="Label11" runat="server" Text="Especificaciones de Diseño:"></asp:Label>
            </td>
            <td class="izquierda">
                <asp:Panel ID="Panel4" runat="server" DefaultButton="ibAddEspecificacion">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <cc1:AutoCompleteExtender ID="AutoCompleteEspecificacion" runat="server" TargetControlID="txtEspecificacion"
                                ServicePath="Autocomplete.asmx" ServiceMethod="ObtenerEspecificacion" MinimumPrefixLength="1">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtEspecificacion" runat="server"  ValidationGroup="^\d{1,10}"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ibAddEspecificacion" runat="server" ImageUrl="~/Imagenes/add-icon.jpg" />
                            <asp:ImageButton ID="ibSearchE" runat="server" ImageUrl="~/Imagenes/magnifying_icon.gif" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbCasoPrueba" runat="server" Width="155px"></asp:ListBox>
                        <asp:ImageButton ID="ibRemoveCasoPrueba" runat="server" ImageUrl="~/Imagenes/Borrar.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbEspecificacion" runat="server" Width="155px"></asp:ListBox>
                        <asp:ImageButton ID="ibRemoveEspecificacion" runat="server" ImageUrl="~/Imagenes/Borrar.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="derecha">
                <asp:Label ID="lblNota" runat="server" Text="Nota de revision de cambios:" Visible="False"></asp:Label>
            </td>
            <td class="izquierda" colspan="3">
                <asp:TextBox ID="txtEditNota" runat="server" MaxLength="100" Rows="3" TextMode="MultiLine"
                    Width="90%" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="derecha">
                Versiones
            </td>
            <td class="izquierda" rowspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvVersiones" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="VersionID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVersionID" runat="server" Text='<%# Bind("ID") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Version" HeaderText="Version" />
                                <asp:TemplateField HeaderText="Status">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("Status") %>'
                                            DataSourceID="Status" DataTextField="vchNombre" DataValueField="iStausID">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="Status" runat="server" ConnectionString="<%$ ConnectionStrings:incidenciometro1ConnectionString %>"
                                            SelectCommand="SELECT [iStausID], [vchNombre] FROM [Status]" ProviderName="System.Data.SqlClient">
                                        </asp:SqlDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asignado">
                                    <EditItemTemplate>
                                        <br />
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAsignado" runat="server" Checked='<%# Bind("Asignado") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="No hay versiones para este producto"></asp:Label></EmptyDataTemplate>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="derecha">
                Folio:
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel5" runat="server" DefaultButton="ibAddFolio">
                            <asp:TextBox ID="txtFolio" runat="server" ValidationGroup="Folio"></asp:TextBox>
                            <asp:ImageButton ID="ibAddFolio" runat="server" ImageUrl="~/Imagenes/add-icon.jpg"
                                Width="16px" ValidationGroup="Folio" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFolio"
                                ErrorMessage="solo se aceptan numeros" ValidationGroup="Folio" ValidationExpression="^[1-9]+[0-9]*$"
                                CssClass="enlinea" Text="*"></asp:RegularExpressionValidator>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td class="izquierda">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbFolios" runat="server" Width="155px"></asp:ListBox>
                        <asp:ImageButton ID="ibRemoveFolio" runat="server" ImageUrl="~/Imagenes/Borrar.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" ValidationGroup="Necesario" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
